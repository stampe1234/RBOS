using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GenericParsing;

namespace RBOS
{
    /// <summary>
    /// The purpose of this class is to provide import of EOD data from Concerno POS.
    /// Concerno POS is installed in shops and restaurents (not Shell stations).
    /// </summary>

    class ImportConcernoPOS
    {
        /// <summary>
        /// If an error occurs in any of the import functions, the error message will be here.
        /// </summary>
        protected static string _LastError;
        public static string LastError { get { return _LastError; } }

        public static bool ImportFiles()
        {
            _LastError = "";
            string importdir = (db.GetConfigString("DRS_FTP_client_arrive_dir") + "\\").Replace("\\\\", "\\");
            string pattern = AdminDataSet.SiteInformationDataTable.GetSiteCode() + "_*.eod";
            string[] tmp = Directory.GetFiles(importdir, pattern, SearchOption.TopDirectoryOnly);
            List<string> files = new List<string>(tmp);
            files.Sort();
            int failedfiles = 0;
            foreach (string file in files)
            {
                // extract date from filename
                DateTime BookDate = tools.object2datetime(file.Substring(file.LastIndexOf("_") + 1, 8));

                /// check if there are no data already for the given bookdate.
                /// (if there is the file is ignored until the user actively
                /// re-imports those data by clicking on the re-import button
                /// in the EOD interface).
                if (!DataExistsAlready(BookDate))
                {
                    if (ImportFile(file, BookDate))
                    {
                        tools.RemoveFileWriteProtection(file);
                        File.Delete(file);
                    }
                    else
                    {
                        ++failedfiles;
                    }
                }
            }

            if (failedfiles > 0)
            {
                _LastError = string.Format("{0} ConcernoPOS file{1} failed to import. Please contact support.", failedfiles, failedfiles > 1 ? "s" : "");
                return false;
            }
            else
            {
                _LastError = "";
                return true;
            }
        }

        private static bool ImportFile(string filename, DateTime BookDate)
        {
            string ExceptionContext = "ImportConcernoPOS.ImportFile: " + filename + ", line: ";
            GenericParser parser = null;
            int linetracker = 0; // first line in file is 1 (not zero-based)
            try
            {
                db.StartTransaction();
                if (!File.Exists(filename))
                {
                    log.WriteException(ExceptionContext, "File not found", "");
                    return false;
                }

                parser = tools.CreateCSVParser(filename, ';', false);
                while (parser.Read())
                {
                    ++linetracker;
                    string recordtype = parser[0].Trim();
                    switch (recordtype)
                    {
                        case "1000": // header

                            // vi tjekker at BookDate i filen stemmer overens med
                            // BookDate i denne metodes parameter, da den dato enten
                            // er sat hvis man gen-importerer for et bestemt døgn eller
                            // den dato er sat ud fra at læse den i filnavnet.
                            DateTime fileBookDate = tools.object2datetime(parser[2].Trim());
                            if (BookDate.Date != fileBookDate.Date)
                            {
                                log.WriteException(ExceptionContext + linetracker.ToString(), "Date in file does not match with date expected to be imported", "");
                                return false;
                            }

                            // tjek at  butiknr i filen stemmer overens med butikkens nr.
                            string fileSiteCode = parser[1].Trim();
                            string SiteCode = AdminDataSet.SiteInformationDataTable.GetSiteCode();
                            if (fileSiteCode != SiteCode)
                            {
                                log.WriteException(ExceptionContext + linetracker.ToString(), "The site code in file does not match the site code for this installation", "");
                                return false;
                            }

                            break;
                        
                        case "1010": // Varesalg pr varegruppe pr momssats

                            string Varegruppe = parser[1].Trim();
                            double OmsEksMoms = tools.object2double(parser[2].Trim());
                            double MomsBeloeb = tools.object2double(parser[3].Trim());
                            double Momssats = tools.object2double(parser[4].Trim());
                            EODDataSet.EOD_SalesDataTable.CreateRecord_DETAIL(
                                BookDate, Varegruppe, OmsEksMoms, MomsBeloeb, Momssats);

                            break;

                        case "1020": // Elektroniske kort

                            string Korttype = tools.object2string(parser[1].Trim());
                            double Totalbeloeb = tools.object2double(parser[2].Trim());
                            EODDataSet.EOD_BankCardsDataTable.CreateRecord_DETAIL(
                                BookDate, Korttype, Totalbeloeb);

                            break;

                        case "1030": // Valuta DKK

                            int ValutaISOkode = tools.object2int(parser[1].Trim());
                            string Valuta = tools.object2string(parser[2].Trim());
                            double ValutaBeloeb = tools.object2double(parser[3].Trim());
                            double BeloebDKK = tools.object2double(parser[4].Trim());
                            EODDataSet.EOD_DETAIL_ValutaDataTable.CreateRecord(
                                BookDate, ValutaISOkode, Valuta, ValutaBeloeb, BeloebDKK);

                            break;

                        case "1040": // Udbetalinger

                            TimeSpan UdbTidspunkt = tools.object2timespan(parser[1].Trim());
                            double UdbBeloeb = tools.object2double(parser[2].Trim());
                            string UdbBeskrivelse = tools.object2string(parser[3].Trim());
                            EODDataSet.EOD_PayinPayoutDataTable.CreateNewRecord_DETAIL(
                                BookDate, TransTypePayinPayout.Payout, UdbBeskrivelse, UdbBeloeb, true, UdbTidspunkt);

                            break;

                        case "1050":

                            TimeSpan IndbTidspunkt = tools.object2timespan(parser[1].Trim());
                            double IndbBeloeb = tools.object2double(parser[2].Trim());
                            string IndbBeskrivelse = tools.object2string(parser[3].Trim());
                            EODDataSet.EOD_PayinPayoutDataTable.CreateNewRecord_DETAIL(
                                BookDate, TransTypePayinPayout.Payin, IndbBeskrivelse, IndbBeloeb, true, IndbTidspunkt);

                            break;
                    }
                }

                // calculate totals and write them to EODReconcile 
                CalculateTotalsAndWriteToEODReconcile(BookDate);

                // import successful
                db.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                log.WriteException(ExceptionContext + linetracker.ToString(), ex.Message, ex.StackTrace);
                return false;
            }
            finally
            {
                // roll back transaction for the whole import
                // of this file if an exception occurs
                // and if one of the checks above yields false.
                if (db.CurrentTransaction != null)
                    db.RollbackTransaction();
                
                if (parser != null)
                    parser.Close();
            }
        }

        public static void CalculateTotalsAndWriteToEODReconcile(DateTime BookDate)
        {
            double EOD_Sales_Total = EODDataSet.EOD_SalesDataTable.GetTotalSalesAmount(BookDate, TransTypeSales.POSSales);
            double EOD_BankCards_Total = EODDataSet.EOD_BankCardsDataTable.GetTotalBankCardsAmount(BookDate);
            double EOD_DETAIL_Valuta_Total = EODDataSet.EOD_DETAIL_ValutaDataTable.GetTotalDETAIL_BeloebDKK(BookDate);
            double EOD_Payout_Total = EODDataSet.EOD_PayinPayoutDataTable.GetTotalPayinPayoutAmount(BookDate, TransTypePayinPayout.Payout);
            double EOD_Payin_Total = EODDataSet.EOD_PayinPayoutDataTable.GetTotalPayinPayoutAmount(BookDate, TransTypePayinPayout.Payin);
            EODDataSet.EODReconcileDataTable.UpdateRecord_DETAIL(
                BookDate,
                EOD_Sales_Total,
                EOD_BankCards_Total,
                EOD_DETAIL_Valuta_Total,
                EOD_Payin_Total,
                EOD_Payout_Total);
        }

        public static bool ReImportFile(DateTime BookDate)
        {
            // build filename
            string filename = string.Format("{0}{1}_{2}.eod",
                (db.GetConfigString("DRS_FTP_client_arrive_dir") + "\\").Replace("\\\\", "\\"),
                AdminDataSet.SiteInformationDataTable.GetSiteCode(),
                BookDate.ToString("yyyyMMdd"));

            _LastError = "";

            // check that there is a file for the bookdate
            if (!File.Exists(filename))
            {
                _LastError = db.GetLangString("ImportConcernoPOS.NoReImportFile");
                return false;
            }

            // delete data from the tables
            EODDataSet.EOD_SalesDataTable.DeleteRecords(BookDate);
            EODDataSet.EOD_BankCardsDataTable.DeleteRecords(BookDate);
            EODDataSet.EOD_DETAIL_ValutaDataTable.DeleteRecords(BookDate);
            EODDataSet.EOD_PayinPayoutDataTable.DeleteRecords(BookDate);

            // import data again
            ImportFile(filename, BookDate);

            // reimport successful
            return true;
        }

        private static bool DataExistsAlready(DateTime BookDate)
        {
            return EODDataSet.EOD_SalesDataTable.HasRecords(BookDate) ||
                   EODDataSet.EOD_BankCardsDataTable.HasRecords(BookDate) ||
                   EODDataSet.EOD_DETAIL_ValutaDataTable.HasRecords(BookDate) ||
                   EODDataSet.EOD_PayinPayoutDataTable.HasRecords(BookDate);
        }
    }
}
