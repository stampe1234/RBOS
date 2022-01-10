using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace RBOS
{
    /// <summary>
    /// Export af VGS filer (varegruppesalg pr. måned) i seperat
    /// format. Blev implementeret i forbindelse med
    /// disktilbud som supplement til export af DTV filerne,
    /// men i princippet er denne exporter selvstændig.
    /// </summary>
    class ExportVGS
    {
        private string _LastError = "";
        public string LastError
        {
            get { return _LastError; }
        }

        /// <summary>
        /// Exports varegruppesalg for the given month.
        /// </summary>
        public bool Export(int Month, int Year)
        {
            StreamWriter writer = null;
            try
            {
                DateTime StartDate = new DateTime(Year, Month, 1);
                DateTime EndDate = tools.GetLastDateInMonth(StartDate);
                _LastError = "";
                string SiteCode = AdminDataSet.SiteInformationDataTable.GetSiteCode();

                using (OleDbConnection conn = new OleDbConnection(db.ConnectionString))
                {
                    conn.Open();

                    // get the data
                    string sql = @"
                        select
                            SubCategory as Varegruppe,
                            (select top 1 SubCategory.Description from SubCategory where SubCategory.SubCategoryID = sales.SubCategory) as VaregruppeBeskr,
                            (select top 1 GLCode from SubCategory where SubCategoryID = SubCategory) as Konto,
                            sum(NumberOf) as Antal,
                            sum(Amount) as Beloeb
                        from EOD_Sales sales
                        where BookDate >= ?
                        and BookDate <= ?
                        group by SubCategory
                    ";
                    DataTable table;
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.Add("StartDate", OleDbType.Date).Value = StartDate.Date;
                        cmd.Parameters.Add("EndDate", OleDbType.Date).Value = EndDate.Date;
                        table = db.GetDataTable(cmd);
                    }

                    /// fetch the max date for the above loaded data
                    /// Note: we cannot include date in the above sql statement,
                    /// as it would disturb the output, so we need to query it
                    /// seperately against the database, using the same interval.
                    DateTime MaxDate;
                    sql = @"
                        select max(BookDate) from EOD_Sales
                        where BookDate >= ?
                        and BookDate <= ?
                        ";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.Add("StartDate", OleDbType.Date).Value = StartDate.Date;
                        cmd.Parameters.Add("EndDate", OleDbType.Date).Value = EndDate.Date;
                        MaxDate = tools.object2datetime(cmd.ExecuteScalar()).Date;
                    }

                    /// If MaxDate is not the last day in the month, this means 
                    /// EOD_Sales does not have data for the entire month, and
                    /// we will need to get the remaining data from Import_RPOS_MCM_Details.
                    /// The reason why we don't always get the data from that table
                    /// is that it doesn't contain any user-entered data from the EOD form.
                    if (MaxDate == DateTime.MinValue || !tools.IsLastDayInMonth(MaxDate))
                    {
                        if (MaxDate == DateTime.MinValue)
                            MaxDate = StartDate.AddDays(-1);

                        // we need to get the remaining data from Import_PROS_MCM_Details
                        // and add it the the table we already have, so both sets of data are exported as one set.
                        sql = @"
                            select
                                MerchCode as Varegruppe,
                                (select top 1 Description from SubCategory where SubCategoryID = MerchCode) as Varegruppebeskr,
                                (select top 1 GLCode from SubCategory where SubCategoryID = MerchCode) as Konto,
                                sum(SalesQuantity) as Antal,
                                sum(SalesAmount) as Beloeb
                            from Import_RPOS_MCM_Details
                            where BookDate >= ?
                            and BookDate <= ?
                            group by MerchCode
                            ";
                        DataTable mcmTable = new DataTable();
                        using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                        {
                            cmd.Parameters.Add("StartDate", OleDbType.Date).Value = MaxDate.AddDays(1);
                            cmd.Parameters.Add("EndDate", OleDbType.Date).Value = EndDate;
                            mcmTable = db.GetDataTable(cmd);
                        }
                        // loop the mcm data and either accumulate values on rows
                        // both tables has or add the rows that EOD_Sales doesn't have
                        foreach (DataRow mcmRow in mcmTable.Rows)
                        {
                            DataRow [] row = table.Select(string.Format("Varegruppe = '{0}'", tools.object2string(mcmRow["Varegruppe"])));
                            if (row.Length > 0)
                            {
                                // EOD_Sales has this SubCategory, so accumulate values
                                row[0]["Antal"] = tools.object2int(row[0]["Antal"]) + tools.object2int(mcmRow["Antal"]);
                                row[0]["Beloeb"] = tools.object2int(row[0]["Beloeb"]) + tools.object2int(mcmRow["Beloeb"]);
                            }
                            else
                            {
                                // EOD_Sales does not have this SubCategory yet, add the row
                                table.Rows.Add(mcmRow.ItemArray);
                            }
                        }
                    }

                    // check if any data were loaded
                    if (table.Rows.Count <= 0)
                    {
                        _LastError = db.GetLangString("ExportVGS.NoDataToExport");
                        return false;
                    }

                    // create filename and file
                    string dir = db.GetConfigString("DRS_FTP_client_depart_dir");
                    string filename = SiteCode + "_" + Year.ToString("0000") + Month.ToString("00") + ".VGS";
                    filename = (dir + "\\" + filename).Replace("\\\\", "\\");
                    writer = new StreamWriter(filename);

                    // output header
                    writer.WriteLine(string.Format("1000;{0};{1}-{2};{3}#{4}",
                        SiteCode.Replace(";", ""), Year.ToString("0000"), Month.ToString("00"), Version.ExeVersion.Replace(";", ""), Version.ExePatch.Replace(";", "")));

                    // output data
                    foreach (DataRow row in table.Rows)
                    {
                        // get varegruppe and beloeb, and VAT needed for beloeb
                        string Varegruppe = tools.object2string(row["Varegruppe"]).Replace(";", "");
                        double VAT = tools.GetSubCategoryVAT(Varegruppe);
                        double BeloebExMoms = tools.DeductVAT(tools.object2double(row["Beloeb"]), VAT);

                        writer.WriteLine(string.Format("2000;{0};{1};{2};{3};{4}",
                            Varegruppe,
                            tools.object2int(row["Konto"]),
                            tools.object2string(row["Varegruppebeskr"]).Replace(";", ""),
                            tools.object2int(row["Antal"]),
                            BeloebExMoms));
                    }
                }

                // file export complete
                return true;
            }
            catch (Exception ex)
            {
                _LastError = log.WriteException("ExportVGS.Export()", ex.Message, ex.StackTrace);
                return false;
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
    }
}
