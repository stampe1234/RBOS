using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace RBOS
{
    class ExportACNNew
    {
        #region LastStatus property
        
        private static AdminDataSet.ACNExportHistoryNewDataTable.Status _LastStatus;
      
        public static AdminDataSet.ACNExportHistoryNewDataTable.Status LastStatus
        {
            get { return _LastStatus; }
        }
        #endregion

        #region ExportACNFileNew
        /// <summary>
        /// Exports ItemTransaction data to ACN file.
        /// The date passed in must be on a sunday.
        /// The data will be extracted for the week in
        /// which this sunday is, that is, monday to sunday.
        /// </summary>
        
        
        public static bool ExportACNFileNew(DateTime Saturday, bool AutoExporting)
        {
            
            try
            {
                
                Saturday = Saturday.Date; // eliminate any time values
                string SiteCode =  AdminDataSet.SiteInformationDataTable.GetSiteCode();
                int Year, Week;
                tools.GetISOWeekNumberFromDate(Saturday, out Year, out Week);
                string pathFirstPart = (db.GetConfigString("DRS_FTP_client_depart_dir") + "\\NEW_" + SiteCode + "_" + Week.ToString("00") + Year.ToString("0000")).Replace("\\\\", "\\");
                _LastStatus =  AdminDataSet.ACNExportHistoryNewDataTable.Status.Not_Set;
                string ErrorList = "";

                // create ACN export file...
                if (!db.GetConfigStringAsBool("ACN_Enabled"))
                {
                    // ACN export is disabled
                    _LastStatus = AdminDataSet.ACNExportHistoryNewDataTable.Status.ACN_Export_Disabled;
                    if (AutoExporting && AdminDataSet.ACNExportHistoryNewDataTable.SetWeekStatus(Saturday, _LastStatus))
                    {
                        // allowed to set week's history status so create "NO" file
                        StreamWriter writer = new StreamWriter(pathFirstPart + "_NO.ACN", false, tools.Encoding());
                        writer.WriteLine("ACN fravalgt");
                        writer.Close();
                    }
                    return false;
                }
                else if (RPOSImportHeadersMissing(Saturday, out ErrorList))
                {
                    // ACN export is missing RPOS import headers
                    _LastStatus = AdminDataSet.ACNExportHistoryNewDataTable.Status.RPOS_Headers_Missing;
                    if (AutoExporting && AdminDataSet.ACNExportHistoryNewDataTable.SetWeekStatus(Saturday, _LastStatus))
                    {
                        // allowed to set week's history status so create "NO" file
                        StreamWriter writer = new StreamWriter(pathFirstPart + "_NO.ACN", false, tools.Encoding());
                        writer.Write(ErrorList);
                        writer.Close();
                    }
                    return false;
                }
                else if (RBPOSImportISMDataMissing(Saturday, out ErrorList))
                {
                    // ACN export is missing ISM data in RPOS import headers
                    _LastStatus = AdminDataSet.ACNExportHistoryNewDataTable.Status.RPOS_ISM_Data_Missing;
                    if (AutoExporting && AdminDataSet.ACNExportHistoryNewDataTable.SetWeekStatus(Saturday, _LastStatus))
                    {
                        // allowed to set week's history status so create "NO" file
                        StreamWriter writer = new StreamWriter(pathFirstPart + "_NO.ACN", false, tools.Encoding());
                        writer.Write(ErrorList);
                        writer.Close();
                    }
                    return false;
                }
                else
                {
                    // ACN export allowed for this week so output the file with ItemTransaction data
                    _LastStatus = AdminDataSet.ACNExportHistoryNewDataTable.Status.Export_Ok;
                    if (AutoExporting)
                    {
                        // when auto exporting, we need to check for setting week status first
                        if (AdminDataSet.ACNExportHistoryNewDataTable.SetWeekStatus(Saturday, _LastStatus))
                            NewMethod(Saturday, SiteCode, Year, Week, pathFirstPart);
                    }
                    else
                    {
                        // when manually exporting, we don't set the week status
                        NewMethod(Saturday, SiteCode, Year, Week, pathFirstPart);
                    }

                    // return success
                    return true;
                }
            }
            catch (Exception ex)
            {
                // display error and return failure
                MessageBox.Show(log.WriteException("ExportACN.ExportACNFile", ex.Message, ex.StackTrace));
                return false;
            }
        }

        private static void NewMethod(DateTime Saturday, string SiteCode, int Year, int Week, string pathFirstPart)
        {
            // allowed to set week's history status so create file
            StreamWriter writer = new StreamWriter(pathFirstPart + ".ACN", false, tools.Encoding());
            DataTable table = db.GetDataTable(SQL(Saturday));
            foreach (DataRow row in table.Rows)
            {
                int NumberOf = tools.object2int(row["NumberOf"]) * -1;
                int Amount = tools.object2int(row["Amount"]) * -1;
                int AvgPrice = ((NumberOf != 0) ? (Amount / NumberOf) : 0);

                string preNumberOf = (NumberOf >= 0) ? "0" : "";
                string preAmount = (Amount >= 0) ? "0" : "";
                string preAvgPrice = (AvgPrice >= 0) ? "0" : "";

                writer.WriteLine(
                    Week.ToString("00") +
                    ((int)(Year % 100)).ToString("00") + // % 100 to only get 06 of 2006
                    tools.object2int(SiteCode).ToString("0000000") +
                    tools.object2double(row["EAN"]).ToString("0000000000000") +
                    preNumberOf + NumberOf.ToString("00000") +
                    preAmount + Amount.ToString("00000000") +
                    preAvgPrice + AvgPrice.ToString("000000") +
                    tools.SubStringSafe(tools.object2string(row["ItemName"]), 0, 30).PadRight(30, ' ') +
                    tools.SubStringSafe(tools.object2string(row["UnitDescription"]), 0, 3).PadRight(3, ' ') +
                    tools.object2int(row["UnitVolume"]).ToString("000000") +
                    "0000000000000"); // they don't get our ItemID
            }
            writer.Close();
        }
        #endregion

        #region ExportACNFileNew
        /// <summary>
        /// Exports ItemTransaction data to ACN file.
        /// Data will be extracted for the week given,
        /// that is, Sunday to Saturday.
        /// </summary>
        public static bool ExportACNFileNew(int Year, int Week, bool SetHistoryStatus)
        {
            DateTime Saturday = tools.GetDateFromISOWeekNumber(Year, Week, DayOfWeek.Saturday);
            return ExportACNFileNew(Saturday, SetHistoryStatus);
        }
        #endregion

        #region ExportPendingACNFiles
        /// <summary>
        /// Exports all ACN files that has not
        /// been exported since the last exported date.
        /// </summary>
        public static void ExportPendingACNFiles()
        {
            // loop the existing history Saturday that were not previously exported ok
            DataTable table = AdminDataSet.ACNExportHistoryNewDataTable.GetHistoryNotOk();
            foreach (DataRow row in table.Rows)
            {
                int Year = tools.object2int(row["AYear"]);
                int Week = tools.object2int(row["AWeek"]);
                ExportACNFileNew(Year, Week, true);
            }

            // loop the not yet exported weeks
            DateTime StartingSaturday = AdminDataSet.ACNExportHistoryNewDataTable.GetFirstSaturdayNotInHistory();
            DateTime EndingSaturday = tools.GetLastWeekDay(ImportDataSet.Import_RPOS_24H_HeaderDataTable.GetLastBookDate(), DayOfWeek.Saturday);
            if ((StartingSaturday != DateTime.MinValue) && (EndingSaturday != DateTime.MinValue))
            {
                for (DateTime Saturday = StartingSaturday; Saturday <= EndingSaturday; Saturday = Saturday.AddDays(7))
                    ExportACNFileNew(Saturday, true);
            }
        }
        
        #endregion

        #region SQL string
        private static string SQL(DateTime Saturday)
        {
            DateTime Sunday = Saturday.AddDays(-6);

            return string.Format(@"
select
  Item.ItemName,
  ItemTransaction.Barcode as EAN,
  sum(ItemTransaction.NumberOf) as NumberOf,
  (sum(ItemTransaction.Amount) * 100) as Amount,
  LookupUnit.Description as UnitDescription,
  (SalesPack.EnhedsIndhold * 1000) as UnitVolume
from (((ItemTransaction
inner join Item
on ItemTransaction.ItemID = Item.ItemID)
inner join SalesPack
on ItemTransaction.ItemID = SalesPack.ItemID
and ItemTransaction.SalesPackType = SalesPack.PackType)
left outer join LookupUnit
on SalesPack.SalesPackType = LookupUnit.ID)
where
  (ItemTransaction.TransactionType = 1) and
  (ItemTransaction.PostingDate >= cdate('{0}')) and
  (ItemTransaction.PostingDate <= cdate('{1}'))
group by
  ItemTransaction.Barcode,
  Item.ItemName,
  LookupUnit.Description,
  SalesPack.EnhedsIndhold
order by
  Item.ItemName

", Sunday, Saturday);
        }
        #endregion

        #region RPOSImportHeadersMissing
        /// <summary>
        /// Reports if headers are missing for the given week
        /// in table Import_RPOS_24H_Header.
        /// Should be called before calling RBPOSImportISMDataMissing.
        /// </summary>
        private static bool RPOSImportHeadersMissing(DateTime Saturday, out string ErrorList)
        {
            ErrorList = "";
            DateTime Sunday = Saturday.AddDays(-6);

            // check table Import_RPOS_24H_Header for
            // missing headers in the given period
            for (DateTime date = Sunday; date <= Saturday; date = date.AddDays(1))
            {
                if (!ImportDataSet.Import_RPOS_24H_HeaderDataTable.RecordAlreadyExists(date))
                {
                    if (ErrorList != "") ErrorList += "\r\n";
                    ErrorList += date.ToString("dd-MM-yyyy") + ": " + db.GetLangString("ExportACN.GenerallyMissingDataFromRSM");
                }
            }

            if (ErrorList != "")
                return true;
            else
                return false;
        }
        #endregion

        #region RBPOSImportISMDataMissing
        /// <summary>
        /// Reports if ISM data are missing for the given week
        /// in table Import_RPOS_24H_Header. All headers are present.
        /// Should be called after calling RPOSImportHeadersMissing.
        /// </summary>
        private static bool RBPOSImportISMDataMissing(DateTime Saturday, out string ErrorList)
        {
            ErrorList = "";
            DateTime Sunday = Saturday.AddDays(-6);

            // check table Import_RPOS_24H_Header for
            // missing ISM data in the given period
            for (DateTime date =Sunday ; date <= Saturday; date = date.AddDays(1))
            {
                if (!ImportDataSet.Import_RPOS_24H_HeaderDataTable.RecordAlreadyExists(date, "ISM"))
                {
                    if (ErrorList != "") ErrorList += "\r\n";
                    ErrorList += date.ToString("dd-MM-yyyy") + ": " + db.GetLangString("ExportACN.MissingItemTransactionDataFromRSM");
                }
            }

            if (ErrorList != "")
                return true;
            else
                return false;
        }
        #endregion
    }
}
