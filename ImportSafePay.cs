using System;
using System.Collections.Generic;
using System.Text;
using GenericParsing;
using System.IO;
using System.Windows.Forms;

namespace RBOS
{
    class ImportSafePay
    {
        #region ImportFiles
        /// <summary>
        /// Imports all SafePay files for days that have not
        /// yet been closed. Import files for closed days are 
        /// </summary>
        public static void ImportFiles()
        {
            // check that SafePay is enabled
            if (!db.GetConfigStringAsBool("SafePay.Enabled"))
                return;

            GenericParser parser = null;

            // load files and sort the list
            string searchPattern = string.Format("SafePay_End_{0}_*.txt", AdminDataSet.SiteInformationDataTable.GetSiteCode());
            string[] tmpSafePayFiles = Directory.GetFiles(tools.GetFTPArriveDir(), searchPattern, SearchOption.TopDirectoryOnly);
            List<string> SafePayFiles = new List<string>(tmpSafePayFiles);
            SafePayFiles.Sort();

            foreach (string SafePayFile in SafePayFiles)
            {
                db.StartTransaction();

                try
                {
                    // check we got a valid filename
                    if (!File.Exists(SafePayFile))
                    {
                        throw new Exception("File not found");
                    }

                    // extract bookdate from filename
                    DateTime BookDate = tools.object2datetime(SafePayFile.Substring(SafePayFile.LastIndexOf(".txt") - 8, 8));

                    // check that file does not belong to a closed date
                    if (!EODDataSet.EODReconcileDataTable.IsDayClosed(BookDate))
                    {
                        /// read the file
                        /// note, we can't read the entire file into the parser
                        /// as it has different sections with different number of columns,
                        /// so we split the file up into the sections and feed each section
                        /// to the parser.
                        string filecontent = File.ReadAllText(SafePayFile);
                        char[] seperator = { '!' };
                        string[] splitted = filecontent.Split(seperator);

                        foreach (string section in splitted)
                        {
                            /// After splitting the content, the first element will be empty
                            /// and the last element with be the "!Records", which we don't use.
                            if (section.Length > 0 && !section.StartsWith("Records"))
                            {
                                // all other sectios are fed to the parser
                                StringReader reader = new StringReader(section);
                                parser = tools.CreateCSVParser(reader, ';', true);

                                if (section.StartsWith("locationnumber_;apptype_;sploc_;spid_;when_;currency_;cnt_;value_;"))
                                {
                                    // Section: Depotbeholding

                                    EODDataSet.EOD_SafePay_DepotbeholdningDataTable table =
                                        new EODDataSet.EOD_SafePay_DepotbeholdningDataTable();
                                    int LineNo = 0;
                                    while (parser.Read())
                                    {
                                        string SiteCode = parser["locationnumber_"];
                                        int Enhedsnummer = tools.object2int(parser["spid_"]);
                                        DateTime Dato = tools.object2datetime(parser["when_"].Substring(0, 8));
                                        int ValutaISOKode = tools.object2int(parser["currency_"]);
                                        double ValutaBeloeb = tools.object2double(parser["value_"]) / 100;
                                        double ChangeBeloeb = tools.object2double(parser["sales_in_"]) / 100;
                                        double ChangeDKK = EODDataSet.EOD_SafePay_ValutakurserDataTable.GetValutakurs(ValutaISOKode) * ChangeBeloeb;
                                        double DKKBeloeb = EODDataSet.EOD_SafePay_ValutakurserDataTable.GetValutakurs(ValutaISOKode) * ValutaBeloeb;
                                        if (Dato.Date == BookDate.Date && SiteCode == AdminDataSet.SiteInformationDataTable.GetSiteCode())
                                        {
                                            table.AddEOD_SafePay_DepotbeholdningRow(
                                                Enhedsnummer,
                                                ValutaBeloeb,
                                                DKKBeloeb,
                                                ValutaISOKode,
                                                "", // ValutaText is a view only field
                                                ChangeDKK,
                                                ChangeBeloeb,
                                                BookDate.Date,
                                                ++LineNo);
                                        }
                                    }

                                    // if any Depotbeholding records were collected,
                                    // insert then into the table, after clearing the open day's data
                                    if (table.Rows.Count > 0)
                                    {
                                        EODDataSet.EOD_SafePay_DepotbeholdningDataTable.DeleteRecordsIfDayOpen(BookDate);
                                        EODDataSetTableAdapters.EOD_SafePay_DepotbeholdningTableAdapter adapter =
                                            new RBOS.EODDataSetTableAdapters.EOD_SafePay_DepotbeholdningTableAdapter();
                                        adapter.Connection = db.Connection;
                                        adapter.InsertCommand.Transaction = db.CurrentTransaction;
                                        adapter.Update(table);
                                    }
                                }
                                else if (section.StartsWith("locationnumber_;apptype_;sploc_;spid_;when_;trans_type_;currency_;cnt_;value_;unit_cnt_;"))
                                {
                                    // Section: Indbetalinger, Udbetalinger or 'Overførsel af mønt til SafePay'
                                    
                                    EODDataSet.EOD_SafePay_OverfoerselTilSPDataTable tableOverfoerselTilSP =
                                        new EODDataSet.EOD_SafePay_OverfoerselTilSPDataTable();
                                    EODDataSet.EOD_SafePay_IndbetalingerDataTable tableIndbetalinger =
                                        new EODDataSet.EOD_SafePay_IndbetalingerDataTable();
                                    EODDataSet.EOD_SafePay_UdbetalingerDataTable tableUdbetalinger =
                                        new EODDataSet.EOD_SafePay_UdbetalingerDataTable();

                                    int LineNoOverfoerselTilSP = 0;
                                    int LineNoIndbetalinger = 0;
                                    int LineNoUdbetalinger = 0;

                                    while (parser.Read())
                                    {
                                        string SiteCode = parser["locationnumber_"];
                                        int Kassenr = tools.object2int(parser["spid_"]);
                                        DateTime DatoTid = tools.object2datetime(parser["when_"]);
                                        int TransType = tools.object2int(parser["trans_type_"]);
                                        double Beloeb = tools.object2double(parser["value_"]) / 100;
                                        int Antal = tools.object2int(parser["cnt_"]);

                                        if (TransType == 2)
                                        {
                                            // Section: 'Overførsel af mønt til SafePay'
                                            if (DatoTid.Date == BookDate.Date && SiteCode == AdminDataSet.SiteInformationDataTable.GetSiteCode())
                                            {
                                                tableOverfoerselTilSP.AddEOD_SafePay_OverfoerselTilSPRow(
                                                    Kassenr,
                                                    DatoTid,
                                                    Antal,
                                                    Beloeb,
                                                    BookDate.Date,
                                                    ++LineNoOverfoerselTilSP);
                                            }
                                        }
                                        else if (TransType == 3)
                                        {
                                            if (Beloeb < 0)
                                            {
                                                // Section: Udbetalinger
                                                if (DatoTid.Date == BookDate.Date && SiteCode == AdminDataSet.SiteInformationDataTable.GetSiteCode())
                                                {
                                                    tableUdbetalinger.AddEOD_SafePay_UdbetalingerRow(
                                                        Kassenr,
                                                        DatoTid,
                                                        Antal,
                                                        Beloeb,
                                                        "", // beskrivelse is filled out by user
                                                        BookDate.Date,
                                                        ++LineNoUdbetalinger);
                                                }
                                            }
                                            else
                                            {
                                                // Section: Indbetalinger
                                                if (DatoTid.Date == BookDate.Date && SiteCode == AdminDataSet.SiteInformationDataTable.GetSiteCode())
                                                {
                                                    tableIndbetalinger.AddEOD_SafePay_IndbetalingerRow(
                                                        Kassenr,
                                                        DatoTid,
                                                        Antal,
                                                        Beloeb,
                                                        "", // beskrivelse is filled out by user
                                                        BookDate.Date,
                                                        ++LineNoIndbetalinger);
                                                }
                                            }
                                        }
                                    }

                                    // if any Overførsel til SafePay records were collected,
                                    // insert then into the table, after clearing the open day's data
                                    if (tableOverfoerselTilSP.Rows.Count > 0)
                                    {
                                        EODDataSet.EOD_SafePay_OverfoerselTilSPDataTable.DeleteRecordsIfDayOpen(BookDate);
                                        EODDataSetTableAdapters.EOD_SafePay_OverfoerselTilSPTableAdapter adapter =
                                            new RBOS.EODDataSetTableAdapters.EOD_SafePay_OverfoerselTilSPTableAdapter();
                                        adapter.Connection = db.Connection;
                                        adapter.InsertCommand.Transaction = db.CurrentTransaction;
                                        adapter.Update(tableOverfoerselTilSP);
                                    }

                                    // if any Udbetalinger records were collected,
                                    // insert then into the table, after clearing the open day's data
                                    if (tableUdbetalinger.Rows.Count > 0)
                                    {
                                        EODDataSet.EOD_SafePay_UdbetalingerDataTable.DeleteRecordsIfDayOpen(BookDate);
                                        EODDataSetTableAdapters.EOD_SafePay_UdbetalingerTableAdapter adapter =
                                            new RBOS.EODDataSetTableAdapters.EOD_SafePay_UdbetalingerTableAdapter();
                                        adapter.Connection = db.Connection;
                                        adapter.InsertCommand.Transaction = db.CurrentTransaction;
                                        adapter.Update(tableUdbetalinger);
                                    }

                                    // if any Indbetalinger records were collected,
                                    // insert then into the table, after clearing the open day's data
                                    if (tableIndbetalinger.Rows.Count > 0)
                                    {
                                        EODDataSet.EOD_SafePay_IndbetalingerDataTable.DeleteRecordsIfDayOpen(BookDate);
                                        EODDataSetTableAdapters.EOD_SafePay_IndbetalingerTableAdapter adapter =
                                            new RBOS.EODDataSetTableAdapters.EOD_SafePay_IndbetalingerTableAdapter();
                                        adapter.Connection = db.Connection;
                                        adapter.InsertCommand.Transaction = db.CurrentTransaction;
                                        adapter.Update(tableIndbetalinger);
                                    }
                                }
                            }
                        }                        

                        db.CommitTransaction();
                    }

                    // delete the file
                    tools.RemoveFileWriteProtection(SafePayFile);
                    File.Delete(SafePayFile);
                }
                catch (Exception ex)
                {
                    string msg = log.WriteException("Error importing SafePay data from file: " + SafePayFile, ex.Message, ex.StackTrace);
                    MessageBox.Show(msg);
                }
                finally
                {
                    if (parser != null)
                        parser.Close();
                    if (db.CurrentTransaction != null)
                        db.RollbackTransaction();
                }
            }
        }
        #endregion
    }
}
