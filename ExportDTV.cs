using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Data.OleDb;

namespace RBOS
{
    /// <summary>
    /// Export disktilbud data from ItemTransaction records to .DTV files.
    /// See the Export method for more information.
    /// </summary>

    class ExportDTV
    {
        private string _LastError = "";
        public string LastError
        {
            get { return _LastError; }
        }

        /// <summary>
        /// Exports ItemTransaction sales records with disktilbud set to true for the given date.
        /// </summary>
        public bool Export(DateTime date, bool recalculation)
        {
            StreamWriter filewriter = null;
            try
            {
                date = date.Date;
                _LastError = "";
                string SiteCode = AdminDataSet.SiteInformationDataTable.GetSiteCode();

                using (OleDbConnection conn = new OleDbConnection(db.ConnectionString))
                {
                    conn.Open();

                    // get DisktilbudSolgt data
                    string sql = @"
                        select
                            ds.DisktilbudID,
                            ds.TransactionID,
                            ds.CashierID,
                            ds.Disktilbud,
                            ds.KampagneID,
                            (select top 1 c.Navn from Cashier c where c.CashierID = ds.CashierID) as CashierName
                        from DisktilbudSolgt ds
                        where ds.BookDate = ?
                        ";
                    DataTable DisktilbudSolgt;
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.Add("BookDate", OleDbType.Date).Value = date.Date;
                        DisktilbudSolgt = db.GetDataTable(cmd);
                    }

                    // create stringwriter to output data to,
                    // as some condition may give that we don't
                    // output any file at all
                    StringWriter writer = new StringWriter();

                    // output header
                    writer.WriteLine(string.Format("1000;{0};{1};{2}#{3};{4}",
                        SiteCode.Replace(";", ""),
                        date.ToString("yyyy-MM-dd"),
                        Version.ExeVersion.Replace(";", ""),
                        Version.ExePatch.Replace(";", ""),
                        recalculation));

                    // output DisktilbudSolgt data
                    foreach (DataRow Disktilbud in DisktilbudSolgt.Rows)
                    {
                        int DisktilbudID = tools.object2int(Disktilbud["DisktilbudID"]);
                        writer.WriteLine(string.Format("2000;{0};{1};{2};{3};{4};{5}",
                            DisktilbudID,
                            tools.object2int(Disktilbud["TransactionID"]),
                            tools.object2int(Disktilbud["CashierID"]),
                            tools.object2int(Disktilbud["Disktilbud"]),
                            tools.object2int(Disktilbud["KampagneID"]),
                            tools.object2string(Disktilbud["CashierName"])));

                        // for this disktilbud, output it's details
                        sql = @"
                            select
                                ItemID,
                                (select top 1 Barcode from Barcode b where b.ItemID = dsd.ItemID and b.IsPrimary = ?) as Barcode,
                                Antal,
                                (select top 1 ReceiptText from SalesPack sp where sp.ItemID = dsd.ItemID) as ItemName
                            from DisktilbudSolgtDetaljer dsd
                            where DisktilbudID = ?
                            ";
                        DataTable DisktilbudSolgtDetaljer;
                        using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                        {
                            cmd.Parameters.Add("IsPrimary", OleDbType.Boolean).Value = true;
                            cmd.Parameters.Add("DisktilbudID", OleDbType.Integer).Value = DisktilbudID;
                            DisktilbudSolgtDetaljer = db.GetDataTable(cmd);
                        }
                        foreach (DataRow DisktilbudDetalje in DisktilbudSolgtDetaljer.Rows)
                        {
                            writer.WriteLine(string.Format("2500;{0};{1};{2};{3};{4}",
                                DisktilbudID,
                                tools.object2int(DisktilbudDetalje["ItemID"]),
                                tools.object2double(DisktilbudDetalje["Barcode"]),
                                tools.object2int(DisktilbudDetalje["Antal"]),
                                tools.object2string(DisktilbudDetalje["ItemName"])));
                        }
                    }

                    /// Output antal ekspeditioner (antal kunder)
                    /// Check if EODReconcileEx contains a record for the given date
                    /// and if the EODReconcileEx.CustomerCount has a positivalue.
                    /// If so, use that value. If not, calcualte the valute from MSM values.
                    int CustomerCount = 0;
                    int CustomerCountOriginalFromPOS = 0;
                    sql = @"
                        select CustomerCount, CustomerCountOriginalFromPOS from EODReconcileEx
                        where BookDate = ?
                    ";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.Add("BookDate", OleDbType.Date).Value = date.Date;
                        DataRow row = db.GetDataRow(cmd);
                        if (row != null)
                        {
                            CustomerCount = tools.object2int(row["CustomerCount"]);
                            CustomerCountOriginalFromPOS = tools.object2int(row["CustomerCountOriginalFromPOS"]);
                        }
                    }
                    writer.WriteLine(string.Format("3000;{0};{1}", CustomerCount, CustomerCountOriginalFromPOS));

                    if (CustomerCount > 0)
                    {
                        // output stringwriter to file
                        string dir = db.GetConfigString("DRS_FTP_client_depart_dir");
                        string filename = SiteCode + "_" + date.ToString("yyyyMMdd") + ".DTV";
                        filename = (dir + "\\" + filename).Replace("\\\\", "\\");
                        filewriter = new StreamWriter(filename);
                        filewriter.Write(writer.ToString());
                    }
                }

                // file export complete
                return true;
            }
            catch (Exception ex)
            {
                _LastError = log.WriteException("ExportDTV.Export()", ex.Message, ex.StackTrace);
                return false;
            }
            finally
            {
                if (filewriter != null)
                    filewriter.Close();
            }
        }
    }
}
