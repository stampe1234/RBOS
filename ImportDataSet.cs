using System;
using System.Data;
using System.Data.OleDb;

namespace RBOS
{

    partial class ImportDataSet
    {
        partial class ItemImportDataTable
        {
        }

        partial class Import_RPOS_MSM_DetailsDataTable
        {
        }

        partial class ImportSalaryHoursDataTable
        {
        }

        partial class Import_RPOS_MSM_ConfigDataTable
        {
            private static string _LastError = "";
            public static string LastError
            {
                get { return _LastError; }
            }

            public static bool ChangeBankcToShellc()
            {
                _LastError = "";
                using (OleDbConnection conn = new OleDbConnection(db.ConnectionString))
                {
                    conn.Open();
                    string sql;

                    // check that there are any records with BANKC (ie if this has been done already)
                    sql = "select count(*) from Import_RPOS_MSM_Config where IncludeCode = 'BANKC'";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        bool HasBankcRecords = tools.object2int(cmd.ExecuteScalar()) > 0;
                        if (!HasBankcRecords)
                        {
                            _LastError = "Der er ikke nogen BANKC records";
                            return false;
                        }
                    }

                    sql = "update Import_RPOS_MSM_Config set IncludeAction = NULL";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    sql = "update Import_RPOS_MSM_Config set IncludeCode = 'SHELLC', IncludeAction = '1' where IncludeCode = 'BANKC'";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    return true;
                }
            }

            public static bool RestoreBankcFromShellc()
            {
                _LastError = "";
                using (OleDbConnection conn = new OleDbConnection(db.ConnectionString))
                {
                    string sql = "update Import_RPOS_MSM_Config set IncludeCode = 'BANKC', IncludeAction = NULL where IncludeAction = '1' and IncludeCode = 'SHELLC'";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }

                    return true;
                }
            }
        }

        partial class SparPOSAccountActionsDataTable
        {
            public static void CreateRecord(string Account, string ActionCode)
            {
                db.ExecuteNonQuery(string.Format(@"
                    insert into SparPOSAccountActions
                    (Account,ActionCode)
                    values ({0},{1})
                    ",
                     tools.string4sql(Account, 12),
                     tools.string4sql(ActionCode, 10)
                     ));
            }

            public static void EmptyTable()
            {
                db.ExecuteNonQuery("delete from SparPOSAccountActions");
            }

            public static bool RecordAlreadyExists(string Account, string ActionCode)
            {
                return (tools.object2int(db.ExecuteScalar(string.Format(@"
                    select count(*) from SparPOSAccountActions
                    where (Account = '{0}')
                    and (ActionCode = '{1}') 
                    ",
                     Account.Replace("'", ""),
                     ActionCode.Replace("'", "")))) > 0);
            }

            public static string LookupAccountActionCode(string Account)
            {
                return tools.object2string(db.ExecuteScalar(string.Format(@"
                    select ActionCode
                    from SparPOSAccountActions
                    where (Account = '{0}')
                    ", Account.Replace("'", ""))));
            }
        }

        partial class SparPOSAccountMappingDataTable
        {
            public static void CreateRecord(string SparPOSCategory, string RBOSSubCategory)
            {
                db.ExecuteNonQuery(string.Format(@"
                    insert into SparPOSAccountMapping
                    (SparPOSCategory,RBOSSubCategory)
                    values ({0},{1})
                    ",
                     tools.string4sql(SparPOSCategory, 4),
                     tools.string4sql(RBOSSubCategory, 20)
                     ));
            }

            public static void EmptyTable()
            {
                db.ExecuteNonQuery("delete from SparPOSAccountMapping");
            }

            public static bool RecordAlreadyExists(string SparPOSCategory, string RBOSSubCategory)
            {
                return (tools.object2int(db.ExecuteScalar(string.Format(@"
                    select count(*) from SparPOSAccountMapping
                    where (SparPOSCategory = '{0}')
                    and (RBOSSubCategory = '{1}') 
                    ",
                     SparPOSCategory.Replace("'", ""),
                     RBOSSubCategory.Replace("'", "")))) > 0);
            }

            public static string LookupRBOSSubCategory(string SparPOSCategory)
            {
                string result = tools.object2string(db.ExecuteScalar(string.Format(@"
                    select RBOSSubCategory
                    from SparPOSAccountMapping
                    where (SparPOSCategory = '{0}')
                    ", SparPOSCategory.Replace("'", ""))));

                /// in case we do not have a mapping between
                /// the SparPOSCategory and RBOSSubCategory
                /// default to 201050601 Ikke salgsvarer.
                if (result == "")
                    result = "201050601";

                return result;
            }
        }

        partial class SparPOSTransactionsDataTable
        {
            public static void CreateRecord(
                DateTime BookDate,
                string BookType,
                string Account,
                string Description,
                double Amount)
            {
                string Category = "";
                int numToGet = 3;
                if (Account.StartsWith("200"))
                {
                    Category = Account.Substring(Account.Length - numToGet, numToGet);
                    Category = Category.TrimStart(new char[] { '0' });
                }

                db.ExecuteNonQuery(string.Format(@"
                    insert into SparPOSTransactions
                    (BookDate,BookType,Account,Category,Description,Amount,NumberOf)
                    values ({0},{1},{2},{3},{4},{5},NULL)
                    ",
                     tools.datetime4sql(BookDate),
                     tools.string4sql(BookType, 4),
                     tools.string4sql(Account, 12),
                     tools.string4sql(Category, 4),
                     tools.string4sql(Description, 40),
                     tools.decimalnumber4sql(Amount)
                     ));
            }

            public static bool RecordsExistsWithThisDate(DateTime BookDate)
            {
                return (tools.object2int(db.ExecuteScalar(string.Format(@"
                    select count (*) from SparPOSTransactions
                    where BookDate = '{0}'
                    ", BookDate))) > 0);
            }

            public static void DeleteRecord(DateTime BookDate)
            {
                db.ExecuteNonQuery(string.Format(@"
                    delete from SparPOSTransactions
                    where BookDate = '{0}'
                    ", BookDate));
            }
        }



        partial class LookupLLStatusDataTable
        {
            #region ENUM: LLStatus

            /// <summary>
            /// Reflects the table LookupLLStatus.
            /// </summary>
            public enum LLStatus
            {
                Open = 1,
                Closed = 2
            }

            #endregion
        }

        #region PARTIAL CLASS: BHHTOrderHeaderDataTable
        partial class BHHTOrderHeaderDataTable
        {
            public static bool HasIncompleteOrders()
            {
                return (tools.object2int(db.ExecuteScalar(string.Format(
                    " select count(*) from BHHTOrderHeader "))) > 0);
            }
        }
        #endregion

        #region PARTIAL CLASS: ItemUpdatesDataTable
        partial class ItemUpdatesDataTable
        {
            public static bool RecordWithDateTimeAlreadyExists(DateTime datetime)
            {
                return (tools.object2int(db.ExecuteScalar(string.Format(
                    " select count(*) from ItemUpdates " +
                    " where UpdDate = '{0}' ",
                    datetime))) > 0);
            }

            public static DateTime GetUpdDate(int ID)
            {
                return tools.object2datetime(db.ExecuteScalar(string.Format(
                    " select UpdDate " +
                    " from ItemUpdates " +
                    " where ID = {0} ", ID)));
            }

            public static bool UpdatesPresent()
            {
                //return (tools.object2int(db.ExecuteScalar(
                //    " select count(*) " +
                //    " from ItemUpdates " +
                //    " where (NoOfOpen > 0) ")) > 0);
                return (tools.object2int(db.ExecuteScalar(
                    " select count(*) " +
                    " from ItemUpdates " +
                    " where (NoOfAproved < NoOfLines) ")) > 0);

            }

            #region DeleteRecord
            public static void DeleteRecord(int ID)
            {
                db.ExecuteNonQuery(string.Format(@"
                    delete from ItemUpdates
                    where ID = {0}
                    ", ID));
            }
            #endregion
        }
        #endregion

        #region PARTIAL CLASS: ItemUpdLinesDataTable
        partial class ItemUpdLinesDataTable
        {
            #region UpdateHeaderAfterSaveToDisk
            /// <summary>
            /// Updates table ItemUpdates with
            /// how many open records exist in table
            /// ItemUpdLines for the given ID.
            /// Static method that works with on-disk data.
            /// IMPORTANT: Any pending changes to ItemUpdLines MUST
            /// be saved to disk before calling this method.
            /// </summary>
            /// <returns></returns>
            public static void UpdateHeaderAfterSaveToDisk(int ID, bool DOSite)
            {
                // get how many open records exists
                int NumOpenRecordsLeft;
                if (!DOSite)
                {
                    NumOpenRecordsLeft = tools.object2int(db.ExecuteScalar(string.Format(
                     " select count(*) " +
                     " from ItemUpdLines " +
                     " where (ID = {0}) " +
                     " and (AprovedBy is not null) ",
                     ID
                     )));

                    // update header with open count
                    db.ExecuteNonQuery(string.Format(
                        " update ItemUpdates " +
                        " set NoOfAproved = {0} " +
                        " where ID = {1} ",
                        NumOpenRecordsLeft, ID));
                }
                else
                {
                    NumOpenRecordsLeft = tools.object2int(db.ExecuteScalar(string.Format(
                    " select count(*) " +
                    " from ItemUpdLines " +
                    " where (ID = {0}) " +
                    " and (Status = {1}) " +
                    " and (Skip = {2}) ",
                    ID,
                    (int)ImportDataSet.LookupLLStatusDataTable.LLStatus.Open,
                    0)));

                    // update header with open count
                    db.ExecuteNonQuery(string.Format(
                        " update ItemUpdates " +
                        " set NoOfOpen = {0} " +
                        " where ID = {1} ",
                        NumOpenRecordsLeft, ID));
                }

            }
            #endregion

            #region FillVirtualFields
            /// <summary>
            /// Fills the fields LookupSubCategory and LookupSupplierName
            /// with lookup values by looking up values for fields SubCat and SupplierNo.
            /// </summary>
            public static void FillVirtualFields(DataRow row)
            {
                // get subcategory description
                //Pn20190625
                string subcat = tools.object2string(row["SubCat"]);
                row["LookupSubCategory"] = ItemDataSet.SubCategoryDataTable.GetSubCategoryDescription(subcat);

                //// get suppliername
                int supplierno = tools.object2int(row["SupplierNo"]);
                DataRow rowSupplier = dbSupplier.GetSupplier(supplierno);
                if (rowSupplier != null)
                    row["LookupSupplierName"] = tools.object2string(rowSupplier["Description"]);

                // calculate PackageCost
                double CostPrice = tools.object2double(row["CostPrice"]);
                int KolliSize = tools.object2int(row["Kolli"]);
                row["CalcPackageCost"] = ItemDataSet.SupplierItemDataTable.CalculatePackageCost(CostPrice, KolliSize);
            }
            #endregion

            #region SalesPriceChangeDisabled
            /// <summary>
            /// Checks if sales price change is disabled for the given row.
            /// If one of the folloing criteria is true,
            /// true is returned, otherwise false is returned.
            /// 1. is the new sales price action enabled?
            /// 2. is skip sales price false while record skip is set?
            /// 3. is skip sales price false while the new sales price action is not set?
            /// 4. is skip sales price false while status is set to closed?
            /// </summary>
            public static bool SalesPriceChangeDisabled(DataRow row)
            {
                return (tools.object2bool(row["ActionDoneNewSalesPrice"]) ||
                        (!tools.object2bool(row["NoChSales"]) && tools.object2bool(row["Skip"])) ||
                        (!tools.object2bool(row["NoChSales"]) && !tools.object2bool(row["ActionNewSalesPrice"])) ||
                        (!tools.object2bool(row["NoChSales"]) && tools.object2int(row["Status"]) == (int)ImportDataSet.LookupLLStatusDataTable.LLStatus.Closed));
            }
            #endregion

            #region ToggleSalesPriceChange
            /// <summary>
            /// Skip/enabled sales price and handles all needed logic and checks.
            /// </summary>
            /// <param name="row"></param>
            public static void ToggleSalesPriceChange(DataRow row, bool SkippingSalesPriceOnly)
            {
                if (SalesPriceChangeDisabled(row))
                {
                    return;
                }

                if (SkippingSalesPriceOnly || (tools.object2bool(row["NoChSales"]) == false))
                {
                    // we are now going to skip the sales price

                    // save the sales price and use db sales price instead
                    row["SalesPriceSaved"] = row["SalesPrice"];
                    row["SalesPrice"] = row["LogSales"];

                    // disable ActionNewSalesPrice
                    row["ActionNewSalesPrice"] = false;

                    // if ActionNewSalesPrice is the last not done action
                    // skip and close record, as no actions are enabled now
                    if (!((tools.object2bool(row["ActionNewCostPrice"]) && !tools.object2bool(row["ActionDoneNewCostPrice"])) ||
                          (tools.object2bool(row["ActionNewBarcode"]) && !tools.object2bool(row["ActionDoneNewBarcode"]))))
                    {
                        row["Skip"] = true;
                        row["Status"] = (int)ImportDataSet.LookupLLStatusDataTable.LLStatus.Closed;
                    }

                    // toggle NoChSales (disable sales price)
                    row["NoChSales"] = true;
                }
                else
                {
                    // we are now going to re-enable the
                    // sales price after a skip sales price

                    // restore saved sales price and null saved sales price
                    row["SalesPrice"] = row["SalesPriceSaved"];
                    row["SalesPriceSaved"] = DBNull.Value;

                    // we know that ActionNewSalesPrice was true before the sales price skip
                    row["ActionNewSalesPrice"] = true;

                    // we know that Skip was false and Status was open before the sales price skip
                    row["Skip"] = false;
                    row["Status"] = (int)ImportDataSet.LookupLLStatusDataTable.LLStatus.Open;

                    // toggle NoChSales (re-enable sales price)
                    row["NoChSales"] = false;
                }
            }
            #endregion

            #region SalesPriceCanBeOpenedForEdit
            /// <summary>
            /// Tells if sales price can be opened for edit,
            /// which is determined by a number of criterias.
            /// </summary>
            public static bool SalesPriceCanBeOpenedForEdit(DataRow row)
            {
                // get the ItemID via either Barcode or SupplierItem info
                // (needed to check that there is only one salespack on the item)
                int ItemID = 0;
                double Barcode = tools.object2double(row["Barcode"]);
                int SupplierNo = tools.object2int(row["SupplierNo"]);
                double OrderingNumber = tools.object2double(row["OrderingNumber"]);
                if (Barcode != 0)
                    ItemID = ItemDataSet.ItemDataTable.GetItemIDFromBarcode(Barcode);
                else if ((SupplierNo != 0) && (OrderingNumber != 0))
                    ItemID = ItemDataSet.ItemDataTable.GetItemIDFromSupplierItem(SupplierNo, OrderingNumber);

                // perform check
                return (tools.object2bool(row["ActionNewCostPrice"]) &&
                        !tools.object2bool(row["ActionDoneNewSalesPrice"]) &&
                        !tools.object2bool(row["NoChSales"]) &&
                        !tools.object2bool(row["Skip"]) &&
                        !tools.object2bool(row["ActionNewSalesPrice"]) &&
                        (tools.object2int(row["Status"]) != (int)ImportDataSet.LookupLLStatusDataTable.LLStatus.Closed) &&
                        (ItemDataSet.ItemDataTable.NumSalesPacksOnItem(ItemID) == 1));
            }
            #endregion

            #region DeleteRecords
            public static void DeleteRecords(int HeaderID)
            {
                db.ExecuteNonQuery(string.Format(@"
                    delete from ItemUpdLines
                    where ID = {0}
                    ", HeaderID));
            }
            #endregion
        }
        #endregion

        #region PARTIAL CLASS: BHHTInvCountDetailsDataTable
        partial class BHHTInvCountDetailsDataTable
        {
            /// <summary>
            /// Deletes all records from the table
            /// that has the given BHHTCountID.
            /// Static method that works with on-disk data.
            /// </summary>
            public static void DeleteAllRecords(int BHHTCountID)
            {
                string sql = " delete from BHHTInvCountDetails where CountID = " + BHHTCountID.ToString();
                db.ExecuteNonQuery(sql);
            }
        }
        #endregion

        #region PARTIAL CLASS: BHHTInvCountHeaderDataTable
        partial class BHHTInvCountHeaderDataTable
        {
            /// <summary>
            /// Deletes all records from the table
            /// that has the given BHHTCountID.
            /// Static method that works with on-disk data.
            /// </summary>
            public static void DeleteAllRecords(int BHHTCountID)
            {
                string sql = " delete from BHHTInvCountHeader where CountID = " + BHHTCountID.ToString();
                db.ExecuteNonQuery(sql);
            }
        }
        #endregion

        #region PARTIAL CLASS: BHHT_RSM_PEJSalesDataTable

        partial class BHHT_RSM_PEJSalesDataTable
        {
            #region METHOD: CalcSumSelllingUnitSold
            public static int CalcSumSelllingUnitSold(
                int BHHTCountID,
                int ItemID,
                byte PackType,
                DateTime SalesDateTime)
            {
                OleDbCommand cmd = new OleDbCommand("", db.Connection);
                cmd.CommandText = string.Format(
                    " select sum(SellingUnitSold) from BHHT_RSM_PEJSales " +
                    " where (BHHTCountID = {0}) " +
                    " and (ItemID = {1}) " +
                    " and (PackType = {2}) " +
                    " and (SalesDateTime <= '{3}') ",  //pn20210210
                    BHHTCountID,
                    ItemID,
                    PackType,
                    SalesDateTime);
                int test = tools.object2int(cmd.ExecuteScalar()); //pn20210210
                return (test);
            }
            #endregion

            #region METHOD: DeleteAllRecords
            /// <summary>
            /// Deletes all records from the table
            /// that has the given BHHTCountID.
            /// Static method that works with on-disk data.
            /// </summary>
            public static void DeleteAllRecords(int BHHTCountID)
            {
                string sql = " delete from BHHT_RSM_PEJSales where BHHTCountID = " + BHHTCountID.ToString();
                db.ExecuteNonQuery(sql);
            }
            #endregion
        }

        #endregion

        #region PARTIAL CLASS: Import_RPOS_24H_HeaderDataTable

        partial class Import_RPOS_24H_HeaderDataTable
        {
            #region METHOD: RecordAlreadyExists (two overloads)

            /// <summary>
            /// Checks if a record already exist with the given BookDate and FileType.
            /// </summary>
            public static bool RecordAlreadyExists(DateTime BookDate, string FileType)
            {
                OleDbCommand cmd = new OleDbCommand("", db.Connection);
                cmd.CommandText = string.Format(
                    " select BookDate " +
                    " from Import_RPOS_24H_Header " +
                    " where (BookDate = '{0}') " +
                    " and ({1}Imported = 1) ",
                    BookDate, FileType);
                object o = cmd.ExecuteScalar();
                return ((o != DBNull.Value) && (o != null));
            }

            /// <summary>
            /// Checks if a record already exist with the given BookDate.
            /// </summary>
            public static bool RecordAlreadyExists(DateTime BookDate)
            {
                OleDbCommand cmd = new OleDbCommand("", db.Connection);
                cmd.CommandText = string.Format(
                    " select BookDate " +
                    " from Import_RPOS_24H_Header " +
                    " where (BookDate = '{0}') ",
                    BookDate);
                object o = cmd.ExecuteScalar();
                return ((o != DBNull.Value) && (o != null));
            }

            #endregion

            #region METHOD: RestoreCheckMarksStillWithData
            /// <summary>
            /// If user has set som imported flags to false, but no import has been
            /// performed for these data afterwards, make sure those checkmarks
            /// are re-enabled. We still have the data - they are just enabled for re-import
            /// when user sets those flags in the GUI with checkmarks in the grid.
            /// NOTE: Remember to call Update after calling this method.
            /// </summary>
            public void RestoreCheckMarksStillWithData()
            {
                OleDbCommand cmd = new OleDbCommand("", db.Connection);

                // traverse all header rows
                foreach (DataRow row in Rows)
                {
                    // get bookdate for header row
                    DateTime HeaderBookDate = tools.object2datetime(row["BookDate"]);

                    // make a look to access all applicable import types for this header row
                    for (int i = 0; i < 4; i++)
                    {
                        // select flag in header table and what child table to use
                        string field = "";
                        string childTable = "";
                        switch (i)
                        {
                            case 0: field = "FGMImported"; childTable = "Import_RPOS_FGM_Details"; break;
                            case 1: field = "MSMImported"; childTable = "Import_RPOS_MSM_Details"; break;
                            case 2: field = "TPMImported"; childTable = "Import_RPOS_TPM_Details"; break;
                            case 3: field = "MCMImported"; childTable = "Import_RPOS_MCM_Details"; break;
                        }

                        // perform the check and possible correction of flag in header row
                        if ((field != "") && (childTable != ""))
                        {
                            if (tools.object2bool(row[field]) != true)
                            {
                                cmd.CommandText = string.Format(
                                    " select BookDate from {1} " +
                                    " where BookDate = '{0}' ",
                                    HeaderBookDate, childTable);
                                object o = cmd.ExecuteScalar();
                                if ((o != null) && (o != DBNull.Value))
                                {
                                    // data were found for this uncheceked checkbox,
                                    // so re-enable the checkbox
                                    row[field] = true;
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            #region METHOD: GetLastBookDate
            /// <summary>
            /// Returns the last bookdate.
            /// If no records are found, DateTime.MinValue is returned.
            /// </summary>
            /// <returns></returns>
            public static DateTime GetLastBookDate()
            {
                return tools.object2datetime(db.ExecuteScalar(
                    " select max(BookDate) " +
                    " from Import_RPOS_24H_Header "));
            }
            #endregion
        }

        #endregion

        #region PARTIAL CLASS: Import_RPOS_24H_ProblemLinesDataTable

        partial class Import_RPOS_24H_ProblemLinesDataTable
        {
            #region METHOD: GetNextLineNo
            /// <summary>
            /// Returns the next LineNo in table Import_RPOS_24H_ProblemLines
            /// for the given BookDate and FileType.
            /// This method is static and works with on-disk data.
            /// </summary>
            public static int GetNextLineNo(DateTime BookDate, string FileType)
            {
                OleDbCommand cmd = new OleDbCommand("", db.Connection);
                cmd.CommandText = string.Format(
                    " select max([LineNo]) from Import_RPOS_24H_ProblemLines " +
                    " where (BookDate = '{0}') and (FileType = '{1}') ",
                    BookDate.Date, FileType);
                return (tools.object2int(cmd.ExecuteScalar()) + 1);
            }
            #endregion

            #region METHOD: GetNumberOfProblemLines
            /// <summary>
            /// Returns the number of problem lines for the given BookDate and FileType.
            /// This method is static and works with on-disk data.
            /// </summary>
            public static int GetNumberOfProblemLines(DateTime BookDate, string FileType)
            {
                OleDbCommand cmd = new OleDbCommand("", db.Connection);
                cmd.CommandText = string.Format(
                    " select count(BookDate) from Import_RPOS_24H_ProblemLines " +
                    " where (BookDate = '{0}') and (FileType = '{1}') ",
                    BookDate, FileType);
                return tools.object2int(cmd.ExecuteScalar());
            }
            #endregion
        }

        #endregion
    }
}

namespace RBOS.ImportDataSetTableAdapters {
    
    
    public partial class ItemUpdatesTableAdapter {
    }
}
