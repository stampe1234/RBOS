using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;


namespace RBOS
{
    class ImportRHT
    {
        private ImportRHTForm caller = null;
        private List<string> pejFilesToDeleteAfterImport = new List<string>();


        #region PROPERTIES

        private string lastError = "";
        public string LastError
        {
            get { return lastError; }
        }

        private int importedOrders = 0;
        public int ImportedOrders
        {
            get { return importedOrders; }
        }

        private int importedInvCount = 0;
        public int ImportedInvCount
        {
            get { return importedInvCount; }
        }

        private int importedInvAdjustA = 0;
        public int ImportedInvAdjustA
        {
            get { return importedInvAdjustA; }
        }

        private int importedInvAdjustR = 0;
        public int ImportedInvAdjustR
        {
            get { return importedInvAdjustR; }
        }

        private int importedInvAdjustT = 0;
        public int ImportedInvAdjustT
        {
            get { return importedInvAdjustT; }
        }

        private int importedInvAdjustW = 0;
        public int ImportedInvAdjustW
        {
            get { return importedInvAdjustW; }
        }

        private int importedShelfLabel = 0;  

        public int ImportedShelfLabel
        {
            get { return importedShelfLabel; }
        }

        #endregion

        #region METHOD: CheckImportDirsExists
        /// <summary>
        /// Checks if the input directories given in config string
        /// BHHT_Import_Dir and BHHT_Import_Dir_Backup exists.
        /// Only checks for backup dir if BHHT_Export_Backup_Active is true.
        /// If false is returned, LastError contains an error message.
        /// </summary>
        private bool CheckImportDirsExists()
        {
            byte dirCount = 0;
            lastError = "";

            if (!Directory.Exists(db.GetConfigString("Delfi_Import_Dir")))
            {
                lastError += db.GetConfigString("Delfi_Import_Dir") + "\n";
                ++dirCount;
            }

            if (db.GetConfigStringAsBool("Delfi_Import_Backup_Active"))
            {
                //if (!Directory.Exists(db.GetConfigString("RHT_Import_Dir_Backup")))
                //{
                //    lastError += db.GetConfigString("RHT_Import_Dir_Backup") + "\n";
                //    ++dirCount;
                //}
            }

            if (dirCount > 0)
            {
                string dir = db.GetLangString("Delfi_Import_Backup_Active");
                if (dirCount > 1) dir = db.GetLangString("Delfi_Import_Backup_Active");
                lastError = string.Format(db.GetLangString("ImportBHHT.ImportDirDoesNotExist") + "\n\n", dir) + lastError;
            }

            return (dirCount == 0);
        }
        #endregion

        #region METHOD: ImportBHE
        /// <summary>
        /// Imports all BHE files from the directory given 
        /// in config table with key RHT_Import_Dir to RBOS.
        /// </summary>
        public bool ImportBHE(ImportRHTForm callerX)
        {
            lastError = "";
            caller = callerX;
            caller.StatusText = "";

            // reset import counters
      
            importedInvCount = 0;
            importedInvAdjustA = 0;
            importedInvAdjustR = 0;
            importedInvAdjustT = 0;
            importedInvAdjustW = 0;
            importedShelfLabel = 0;

            try
            {
                // check that import directories exists
                if (!CheckImportDirsExists())
                    return false;

                // get BHE filelist
                List<string> bheFiles = ScanRHTFileList();

                // check that import files were found
                if ((bheFiles == null) || (bheFiles.Count <= 0))
                {
                    lastError = db.GetLangString("ImportBHHT.NothingToDo");
                    return false;
                }

                // import data from all BHE files
                foreach (string file in bheFiles)
                {
                    try
                    {
                        // read BHE file XML data
                        DataSet dsXML = new DataSet();
                        dsXML.ReadXml(file);

                        // import data for tables BHHTInvCountHeader and BHHTInvCountDetails
                        
                        int RHTCountID = ImportInvCount(dsXML);
                                               

                        // import data for tables BHHTInvAdjustHeader and BHHTInvAdjustDetails
                        ImportInvAdjust(dsXML);

                        // import data for updating shelf label flag in table SalesPack
                        ImportShelfLabel(dsXML);

                        ImportStockregulation(dsXML);
                    }
                    catch (Exception ex)
                    {
                        
                        log.WriteException("ImportRHT.ImportBHE", ex.Message, ex.StackTrace);
                    }
                }

                // cleanup bhe semaphore files
                //tools.CleanupSEMfiles(GetRHTImportDir(), bheFiles);

                // move BHE files now imported to backup dir or delete them
                foreach (string file in bheFiles)
                {
                    if (db.GetConfigStringAsBool("Delfi_Import_Backup_Active"))
                        MoveFileToBackupDir(file);
                    else
                        File.Delete(file);
                }

                          

                // import successfully completed
                caller.StatusText = "";
                return true;
            }
            catch (Exception ex)
            {
                lastError =
                    log.WriteException("ImportRHT.ImportBHE()", ex.Message, ex.StackTrace);
                return false;
            }
        }
        #endregion
        #region METHOD:IsTotalCount
        private bool IsTotalCount(DataSet dsXML)
        {
            DataTable tableHeader = dsXML.Tables["StatusHeader"];
            DataTable tableDetails = dsXML.Tables["StatusLine"];
            if ((tableHeader != null) && (tableDetails != null))
            {
                DataRow rowHeader = tableHeader.Rows[0];
                int ItemGroupFilter = tools.object2int(rowHeader["ItemGroupFilter"]);  //hvis 99 er det total optælling
                if (ItemGroupFilter == 99)
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
                
            }
            else
                return (false);
        }
        #endregion

        #region METHOD: ImportInvCount
        /// <summary>
        /// Import data for tables BHHTInvCountHeader and BHHTInvCountDetails.
        /// Is called from method ImportBHE each time a BHE file is loaded for import.
        /// </summary>
        /// <param name="dsXML">DataSet with loaded XML file.</param>
        /// <returns>
        /// The CountID from BHHTInvCountHeader table. 0 if no InvCount data were imported.
        /// </returns>
        private int ImportInvCount(DataSet dsXML)
        {
            int ReturnedRHTCountID = 0;
            
            DataTable tableHeader = dsXML.Tables["StatusHeader"];
            DataTable tableDetails = dsXML.Tables["StatusLine"];
            if ((tableHeader != null) && (tableDetails != null))
            {
                // traverse header records
                foreach (DataRow rowHeader in tableHeader.Rows)
                {
                    // get CountID from the header row
                    int WorkSheetID  = tools.object2int(rowHeader["ItemGroupFilter"]);
                    DateTime CountDate = tools.RadiantXmlDateTime2DateTime(rowHeader["ConfirmedDateTime"].ToString());
                    //laver int ud af yyyymmddhhmmss
                    string DatoTidString = CountDate.ToString("HHmmss");
                    DateTime StartDate = DateTime.ParseExact("2020-09-01 00:00:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    int NoOffDayes =   CountDate.Subtract(StartDate).Days;
                    DatoTidString = NoOffDayes.ToString() + DatoTidString;
                    DateTime BusinessDate = CountDate.Date;
                    int CountID = Int32.Parse(DatoTidString);
                   
                    // only import this header and its details if not yet imported
                    if (RHTInvCountHeader_CountIDNotImportedYet(CountID))
                    {
                        // get further needed header values from the header row
                                              
                        // get detail records
                        DataRow[] rowsDetails =
                            tableDetails.Select();


                        // traverse detail records
                        long LineNo = 0;
                        int TotalCountID = 0;
                        DateTime TimeStmp = BusinessDate;
                        if (WorkSheetID ==  99 )  //total optælling
                        {
                            
                            string sql = string.Format(
                            "Select [CountID] from BHHTInvCountHeader Where Convert(Date,CountDate) = {0} And WorkSheetID = 99 And Status ='OPN'", tools.datetime4sql(BusinessDate));
                                
                            OleDbCommand cmd = new OleDbCommand(sql, db.Connection);
                            object o = cmd.ExecuteScalar();
                            TotalCountID = tools.object2int(o);
                            if (TotalCountID != 0)
                            {
                                CountID = TotalCountID;
                                sql = string.Format(
                                "Select Max([LineNo]) From[BHHTInvCountDetails] Where CountID = {0} ", CountID);

                                 cmd = new OleDbCommand(sql, db.Connection);
                                 o = cmd.ExecuteScalar();
                                LineNo = tools.object2int(o);

                            }
                                                       
                        }

                        foreach (DataRow rowDetails in rowsDetails)
                        {
                            ++LineNo;

                            // get values from the detail row
                            int ItemID = ItemDataSet.ItemDataTable.GetItemIDFromImportID(tools.object2int(rowDetails["BTItemNo"]));
                            byte PackType = 1;
                            long Quantity = (long)tools.object2double(rowDetails["Quantity"]);
                            TimeStmp = tools.RadiantXmlDateTime2DateTime(rowDetails["ScanningDateTime"].ToString());
                            string sql;
                            // save detail data
                            if (WorkSheetID != 99)
                            {
                                //sql = string.Format(
                                //    " insert into BHHTInvCountDetails " +
                                //    " (CountID,[LineNo],ItemID,PackType,Quantity,TimeStmp) " +
                                //    " values ({0},{1},{2},{3},{4},'{5}') ",
                                //    CountID, LineNo, ItemID, PackType, Quantity, TimeStmp);
                                sql = string.Format("if exists(SELECT * from BHHTInvCountDetails where CountID= {0}  and ItemID = {2}) " +
                              "BEGIN  update BHHTInvCountDetails set Quantity = (Quantity + {4}), TimeStmp = '{5}' where CountID= {0}  and ItemID = {2} END" +
                              " else begin insert into BHHTInvCountDetails  " +
                               " (CountID,[LineNo],ItemID,PackType,Quantity,TimeStmp) " +
                                  " values ({0},{1},{2},{3},{4},'{5}') end ",
                                  CountID, LineNo, ItemID, PackType, Quantity, TimeStmp);
                            }
                            else
                            {
                                sql = string.Format("if exists(SELECT * from BHHTInvCountDetails where  ItemID = {2}) " +
                                "BEGIN  update BHHTInvCountDetails set Quantity = (Quantity + {4}) Where ItemID = {2} END" +
                                " else begin insert into BHHTInvCountDetails  " +
                                 " (CountID,[LineNo],ItemID,PackType,Quantity,TimeStmp) " +
                                    " values ({0},{1},{2},{3},{4},'{5}') end ",
                                    CountID, LineNo, ItemID, PackType, Quantity,TimeStmp );
                            }


                            OleDbCommand cmd = new OleDbCommand(sql, db.Connection);
                            cmd.Transaction = db.CurrentTransaction;
                            cmd.ExecuteNonQuery();
                        } // foreach detail record

                        //alle varer i gruppen som ikke er talt skal også med 
                        if (rowsDetails.Length > 0)
                        {

                            DataTable Items = GetAllItems(WorkSheetID);
                            if (Items != null)
                            { 
                                DataRow[] ItemLines = Items.Select();

                                foreach (DataRow Item in ItemLines)
                                {
                                    ++LineNo;
                                    string sql = string.Format("if not exists(SELECT * from BHHTInvCountDetails where CountID= {0}  and ItemID = {2}) " +
                                  "begin insert into BHHTInvCountDetails  " +
                                   " (CountID,[LineNo],ItemID,PackType,Quantity,TimeStmp) " +
                                      " values ({0},{1},{2},{3},{4},'{5}') end ",
                                      CountID, LineNo, Item[0].ToString(), 1, 0, TimeStmp);

                                    OleDbCommand cmd = new OleDbCommand(sql, db.Connection);
                                    cmd.Transaction = db.CurrentTransaction;
                                    cmd.ExecuteNonQuery();
                                }

                            }
                        }


                            // if any detail records, save the header
                        if (rowsDetails.Length > 0)
                        {
                            // increment counter
                            if (TotalCountID == 0)
                                ++importedInvCount;

                            // message to user
                            //caller.StatusText = db.GetLangString("ImportBHHT.ImportInvCount") + importedInvCount.ToString();

                            // create string versions of nullable variables to use in sql
                            // as if they contain null, we need to write "NULL" to db fields
                         

                            // save header data
                            // (do NOT embrace string versions of nullable variables with "" or '')
                            string sql = string.Format(
                                " insert into BHHTInvCountHeader (CountID,CountDate,WorkSheetID, Status, BusinessDate) " +
                                " values ({0},'{1}',{2},'{3}','{4}') ",
                                CountID, CountDate, WorkSheetID , "OPN",BusinessDate);
                            OleDbCommand cmd = new OleDbCommand(sql, db.Connection);
                            cmd.Transaction = db.CurrentTransaction;
                            cmd.ExecuteNonQuery();

                            // as we have successfully imported some InvCount data,
                            // set flag for looking for PEJ files too
                            ReturnedRHTCountID = CountID;

                        }
                    } // if not imported yet
                } // foreach header record
            } // if tables exists

            // return whether to look for PEJ xml file as the next action
            return ReturnedRHTCountID;
        }

     
        #endregion

        #region METHOD: ImportInvAdjust
        /// <summary>
        /// Import data for tables BHHTInvAdjustHeader and BHHTInvAdjustDetails.
        /// Is called from method ImportBHE each time a BHE file is loaded for import.
        /// </summary>
        /// <param name="dsXML">DataSet with loaded XML file.</param>
        private void ImportInvAdjust(DataSet dsXML)
        {
            DataTable tableHeader = dsXML.Tables["DepreciationHeader"];
            if (tableHeader != null)
            { 
            DataRow rowheader = tableHeader.Rows[0];
            DateTime ConfirmDT = tools.object2datetime(rowheader["ConfirmedDateTime"].ToString());
            DateTime DepreciationDate = tools.object2datetime(rowheader["DepreciationDate"].ToString());


            //laver int ud af yyyymmddhhmmss
            string DatoTidString = ConfirmDT.ToString("HHmmss");
            DateTime StartDate = DateTime.ParseExact("2020-09-01 00:00:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            int NoOffDayes = ConfirmDT.Subtract(StartDate).Days;
            DatoTidString = NoOffDayes.ToString() + DatoTidString;
            int AdjustID = Int32.Parse(DatoTidString);
            
          
            DataTable tableDetails = dsXML.Tables["DepreciationLine"];
                if ((tableDetails != null) & (RHTInvAdjustHeader_AdjustIDNotImportedYet(AdjustID)))
                {
                    // Lav Header i RBOS
                    string sql = string.Format(
                        " insert into BHHTInvAdjustHeader (AdjustID,AdjustDate,[BusinessDate],[Status],[ReasonCode]) " +
                        " values ({0},'{1}','{2}', '{3}','{4}') ",
                        AdjustID, DepreciationDate, ConfirmDT, "OPN", "w");
                    OleDbCommand cmd = new OleDbCommand(sql, db.Connection);
                    cmd.Transaction = db.CurrentTransaction;
                    cmd.ExecuteNonQuery();


                    foreach (DataRow rowDetails in tableDetails.Rows)
                    {

                        // get values from the detail row
                        int ItemID = ItemDataSet.ItemDataTable.GetItemIDFromImportID(tools.object2int(rowDetails["BTItemNo"]));
                        int LineNo = tools.object2int(rowDetails["PositionNo"]);
                        long Quantity = (long)tools.object2double(rowDetails["Quantity"]);
                        byte PackType = 1;// tools.object2byte(rowDetails["UOMId"]);

                        DateTime TimeStmp = tools.RadiantXmlDateTime2DateTime(rowDetails["ScanningDateTime"].ToString());
                        // save detail data
                        sql = string.Format(
                            " insert into BHHTInvAdjustDetails " +
                            " (AdjustID,[LineNo],ItemID,PackType,Quantity,TimeStmp) " +
                            " values ({0},{1},{2},{3},{4},'{5}') ",
                            AdjustID, LineNo, ItemID, PackType, Quantity, TimeStmp);
                        cmd = new OleDbCommand(sql, db.Connection);
                        cmd.Transaction = db.CurrentTransaction;
                        cmd.ExecuteNonQuery();
                    }

                    
                }   
            } // if tables exists
        }
        #endregion

        #region METHOD: ImportStockregulation
        /// <summary>
        /// Import data for tables BHHTInvAdjustHeader and BHHTInvAdjustDetails.
        /// Is called from method ImportBHE each time a BHE file is loaded for import.
        /// </summary>
        /// <param name="dsXML">DataSet with loaded XML file.</param>
        private void ImportStockregulation(DataSet dsXML)
        {
            DataTable tableHeader = dsXML.Tables["StockregulationHeader"];
            DataRow rowheader = tableHeader.Rows[0];
            DateTime ConfirmDT = tools.object2datetime(rowheader["ConfirmedDateTime"].ToString());
            DateTime StockregulationDate = tools.object2datetime(rowheader["StockregulationDate"].ToString());


            //laver int ud af yyyymmddhhmmss
            string DatoTidString = ConfirmDT.ToString("HHmmss");
            DateTime StartDate = DateTime.ParseExact("2020-09-01 00:00:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            int NoOffDayes = ConfirmDT.Subtract(StartDate).Days;
            DatoTidString = NoOffDayes.ToString() + DatoTidString;
            int AdjustID = Int32.Parse(DatoTidString);


            DataTable tableDetails = dsXML.Tables["StockregulationLine"];
            if ((tableDetails != null) & (RHTInvAdjustHeader_AdjustIDNotImportedYet(AdjustID)))
            {
                // Lav Header i RBOS
                string sql = string.Format(
                    " insert into BHHTInvAdjustHeader (AdjustID,AdjustDate,[BusinessDate],[Status],[ReasonCode]) " +
                    " values ({0},'{1}','{2}', '{3}','{4}') ",
                    AdjustID, StockregulationDate, ConfirmDT, "OPN", "a");
                OleDbCommand cmd = new OleDbCommand(sql, db.Connection);
                cmd.Transaction = db.CurrentTransaction;
                cmd.ExecuteNonQuery();


                foreach (DataRow rowDetails in tableDetails.Rows)
                {

                    // get values from the detail row
                    int ItemID = ItemDataSet.ItemDataTable.GetItemIDFromImportID(tools.object2int(rowDetails["BTItemNo"]));
                    int LineNo = tools.object2int(rowDetails["PositionNo"]);
                    long Quantity = (long)tools.object2double(rowDetails["Quantity"]);
                    byte PackType = 1;// tools.object2byte(rowDetails["UOMId"]);

                    DateTime TimeStmp = tools.RadiantXmlDateTime2DateTime(rowDetails["ScanningDateTime"].ToString());
                    // save detail data
                    sql = string.Format(
                        " insert into BHHTInvAdjustDetails " +
                        " (AdjustID,[LineNo],ItemID,PackType,Quantity,TimeStmp) " +
                        " values ({0},{1},{2},{3},{4},'{5}') ",
                        AdjustID, LineNo, ItemID, PackType, Quantity, TimeStmp);
                    cmd = new OleDbCommand(sql, db.Connection);
                    cmd.Transaction = db.CurrentTransaction;
                    cmd.ExecuteNonQuery();
                }

                // if any detail records, save the header
                //if (rowDetails.Length > 0)
                //{
                //    // increment counters
                //    switch (ReasonCode)
                //    {
                //        case 'a': ++importedInvAdjustA; break; // adjustment
                //        case 'r': ++importedInvAdjustR; break; // receiving
                //        case 't': ++importedInvAdjustT; break; // transfer
                //        case 'w': ++importedInvAdjustW; break; // waste
                //    }

                //    //importedInvCount

                //    // create string versions of nullable variables to use in sql
                //    // as if they contain null, we need to write "NULL" to db fields
                //    string sBusinessDate = (BusinessDate.HasValue ? "'" + BusinessDate.ToString() + "'" : "NULL");
                //    string sWorkSheetID = (WorkSheetID.HasValue ? WorkSheetID.ToString() : "NULL");

                //    // save header data
                //    // (do NOT embrace string versions of nullable variables with "" or '')
                //    string sql = string.Format(
                //        " insert into BHHTInvAdjustHeader (AdjustID,AdjustDate,BusinessDate,WorkSheetID,Status,ReasonCode) " +
                //        " values ({0},'{1}',{2},{3},'{4}','{5}') ",
                //        AdjustID, AdjustDate, sBusinessDate, sWorkSheetID, "OPN", ReasonCode);
                //    OleDbCommand cmd = new OleDbCommand(sql, db.Connection);
                //    cmd.Transaction = db.CurrentTransaction;
                //    cmd.ExecuteNonQuery();

                //} // if not imported yet

            } // if tables exists
        }
        #endregion

        #region METHOD: ImportShelfLabel

        /// <summary>
        /// Import data for marking SalesPack records as needing a new shelf label.
        /// Is called from method ImportBHE each time a BHE file is loaded for import.
        /// </summary>
        /// <param name="dsXML">DataSet with loaded XML file.</param>
        private void ImportShelfLabel(DataSet dsXML)
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.CurrentTransaction;
            DataTable table = dsXML.Tables["ShelfFrontEdgeLine"];
            if (table != null)
            {
                // traverse records
                foreach (DataRow row in table.Rows)
                {
                    // get ItemID and PackType from the row
                    int ItemID = ItemDataSet.ItemDataTable.GetItemIDFromImportID(tools.object2int(row["BTItemNo"]));
                   // byte PackType = tools.object2byte(row["UOMId"]);
                    byte PackType = 1;
                    
                    // update salespack table
                    cmd.CommandText = string.Format(
                        " update SalesPack " +
                        " set UpdateShelfLabel = 1 " +
                        " where (ItemID = {0}) and (PackType = {1}) ",
                        ItemID, PackType);
                    cmd.ExecuteNonQuery();

                    // increment counter
                    ++importedShelfLabel;

                    // message to user
                    caller.StatusText = db.GetLangString("ImportBHHT.ImportShelfLabel") + importedShelfLabel.ToString();

                } // foreach record
            } // if tables exists
        }

        #endregion

        #region METHOD: GetSupplierItem
        // internal helper method to lookup a supplier item
        private DataRow GetSupplierItem(long SupplierItemID)
        {
            string sql = " select * from SupplierItem where ID = " + SupplierItemID.ToString();
            DataTable table = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, db.Connection);
            adapter.SelectCommand.Transaction = db.CurrentTransaction;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
                return table.Rows[0];
            else
                return null;
        }
        #endregion

        #region METHOD: GetAllItems
        private DataTable GetAllItems(long WSID)
        {
            string sql;
            if (WSID == 99)
            {
                // sql = "Select t2.ItemID, t2.ItemName from  Item as t2 ";  //pn20201124
                sql = "Select ItemID, ItemName from Item where Exists(Select * from ItemTransaction Where Item.ItemID = ItemTransaction.ItemID And ItemTransaction.NumberOf != 0)";
            }
            else
                sql = "Select t2.ItemID, t2.ItemName from  [BHHTWSCatList] As t1  join Item as t2 on t1.SubCategoryID = t2.SubCategory  Where t1.WSID = " + WSID.ToString();
            DataTable table = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, db.Connection);
            adapter.SelectCommand.Transaction = db.CurrentTransaction;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
                return table;
            else
                return null;
        }
        #endregion




        #region METHOD: GetItem
        // internal helper method to lookup an item
        private DataRow GetItem(Nullable<long> ItemID)
        {
            string sql = " select * from Item where ItemID = " + ItemID.ToString();
            DataTable table = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, db.Connection);
            adapter.SelectCommand.Transaction = db.CurrentTransaction;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
                return table.Rows[0];
            else
                return null;
        }
        #endregion 

     
        #region METHOD: RHTInvCountHeader_CountIDNotImportedYet
        // internal helper method to check if a given
        // BHHTInvCountHeader.CountID has not yet been imported
        private bool RHTInvCountHeader_CountIDNotImportedYet(long CountID)
        {
            string sql = " select CountID from BHHTInvCountHeader where CountID = " + CountID.ToString();
            OleDbCommand cmd = new OleDbCommand(sql, db.Connection);
            object o = cmd.ExecuteScalar();
            return ((o == null) || (o == DBNull.Value));
        }
        #endregion

        #region METHOD: RHTInvAdjustHeader_AdjustIDNotImportedYet
        // internal helper method to check if a given
        // BHHTInvAdjustHeader.AdjustID has not yet been imported
        private bool RHTInvAdjustHeader_AdjustIDNotImportedYet(long AdjustID)
        {
            string sql = " select AdjustID from BHHTInvAdjustHeader where AdjustID = " + AdjustID.ToString();
            OleDbCommand cmd = new OleDbCommand(sql, db.Connection);
            object o = cmd.ExecuteScalar();
            return ((o == null) || (o == DBNull.Value));
        }
        #endregion

        #region METHOD: MoveFileToBackupDir
        /// <summary>
        /// Moves the provided file to the backup dir given
        /// by the config string "BHHT_import_dir_backup"
        /// </summary>
        /// <param name="file">Full path and filename.</param>
        private void MoveFileToBackupDir(string file)
        {
            int idx = file.LastIndexOf("\\");
            if (idx >= 0)
            {

                string Arkivfolder = file.Substring(0, idx);
                Arkivfolder = Arkivfolder + "\\Arkiv";
                string destFile = Arkivfolder + file.Remove(0, idx);
                destFile = destFile.Replace("\\\\", "\\"); // make sure we don't have double backslashes
                if (File.Exists(destFile))
                    File.Delete(destFile); // just to be sure
                File.Move(file, destFile);
            }
        }
        #endregion

        #region METHOD: GetBHHTImportDir
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetRHTImportDir()
        {
            string importDir = db.GetConfigString("Delfi_Import_Dir");

            // check that import dir has a length
            if (importDir.Length <= 0)
            {
                lastError = db.GetLangString("ImportRHT.ImportDirCannotBeEmpty");
                return null;
            }

            // make sure we have a trailing backslash
            if (importDir[importDir.Length - 1] != '\\')
                importDir += "\\";

            return importDir;
        }
        #endregion

        #region METHOD: GetNAXMLImportDir
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetNAXMLImportDir()
        {
            string importDir = db.GetConfigString("NAXML_Import_Dir");

            // check that import dir has a length
            if (importDir.Length <= 0)
            {
                lastError = db.GetLangString("ImportBHHT.ImportDirCannotBeEmpty");
                return null;
            }

            // make sure we have a trailing backslash
            if (importDir[importDir.Length - 1] != '\\')
                importDir += "\\";

            return importDir;
        }
        #endregion

        #region METHOD: ScanRHTFileList
        /// <summary>
        /// Scans BHHT_Import_Dir (config string) directory for
        /// BHE files listed in corresponding SEM files and returns
        /// them sorted by date. The semaphore files used will be
        /// deleted if empty afterwards.
        /// </summary>
        /// <returns>
        /// BHE files sorted by date. Remember to delete them after import.
        /// If this value is null, lastError has an error message.
        /// </returns>
        private List<string> ScanRHTFileList()
        {

            // nyt da filer ligger i sepearate folderne med arkiv folder i samme folder er vi nød til at ændre logikken her
            // check that import dirs exist


            if (!CheckImportDirsExists())
                return null;

            // get import dir
            string importDir = GetRHTImportDir();

            List<string> RHTFileList = new List<string>();

            string[] SubFolderArray = { db.GetConfigString("Delfi_Hyldemark_Dir"), db.GetConfigString("Delfi_LagerOpt_Dir"), db.GetConfigString("Delfi_Nedskrivn_Dir"), db.GetConfigString("Delfi_StockReg_Dir") };

            for (int i = 0; i < 4; i++)
            {
               
                string importSubFolder = importDir + SubFolderArray[i];
                string[] RHTFiles = Directory.GetFiles(importSubFolder, "*.XML", SearchOption.TopDirectoryOnly);
                foreach (string file in RHTFiles)
                {
                   
                    RHTFileList.Add(file);
                }

                // sort BHE filelist by date ("SEMyyyymmdd...")
                RHTFileList.Sort();
            }
            return RHTFileList;
        }
        #endregion

        #region METHOD: ImportPEJRHT
        /// <summary>
        /// Imports data from PEJ xml files for table BHHT_RSM_PEJSales.
        /// This method is only to be called if data has been imported for
        /// InvCount from the provided file.
        /// </summary>
        /// <param name="CurrentBHEfile">
        /// The file that InvCount data were imported from. Is used
        /// to scan out its filename and the use it to look for a similar
        /// PEJ filename.
        /// </param>
        public Boolean ImportPEJRHT(DateTime CountDate, int RHTCountID)
        {
            #region Algorithm description
            /// The algorithm for finding a PEJ file for the
            /// provided BHE file with InvCount data is as follows:
            /// We scan out the date from the BHE filename. This date
            /// we use to make a list of PEJ files with the same date
            /// in the filename. We then take this is list of files and
            /// from the timestamp in their names we figure out which of
            /// them is the one last generated. This file we use to
            /// import PEJ data. We keep the files in a global list
            /// so they can be deleted/backed up all at once when all imports are done.
            #endregion

            #region Get the PEJ file to use for import

            // make sure only the filename is present in CurrentBHEFile and not also the path
            //CurrentBHEfile = tools.StripDirectoryFromPath(CurrentBHEfile);

            // scan out date from bheFile (radiant xml filename format)
            DateTime bheDate = CountDate; // only keep date


            //>>pn20210520 sletter evt. records i BHHT_RSM_PEJSales
            OleDbCommand cmd2 = new OleDbCommand("", db.Connection);
            cmd2.CommandText = string.Format("Delete from BHHT_RSM_PEJSales Where BHHTCountID = {0} ", RHTCountID);
            cmd2.ExecuteNonQuery();
            //<<pn20210520


            // load list of all PEJ files
            string ImportDir = GetNAXMLImportDir();
            string[] AllPEJFilesInDir = Directory.GetFiles(ImportDir, "PEJ*.xml", SearchOption.TopDirectoryOnly);

            DateTime latestPEJFileDateTime = DateTime.MinValue;
            string pejFileToUse = "";

            // traverse these PEJ files
            foreach (string pejFile in AllPEJFilesInDir)
            {
                // scan out date and time from PEJ file (has format PEJyyyyMMddHHmmss.xml)
                DateTime pejFileDateTime = tools.RadiantXmlFilename2DateTime(pejFile);

                // if PEJ file has same date in name as the given BHE file
                if (pejFileDateTime.Date == bheDate.Date)
                {
                    // add the PEJ file to the list of PEJ
                    // files to be deleted when import is done
                    if (!pejFilesToDeleteAfterImport.Contains(pejFile))
                        pejFilesToDeleteAfterImport.Add(pejFile);

                    // keep the PEJ filename if it has the latest timestamp
                    if (pejFileDateTime > latestPEJFileDateTime)
                    {
                        latestPEJFileDateTime = pejFileDateTime;
                        pejFileToUse = pejFile;
                    }
                }
            }
            //pn20210520
            if (pejFileToUse == "")  //kigger også i backup dir
            {
                AllPEJFilesInDir = Directory.GetFiles(ImportDir, "PEJ*.xml", SearchOption.AllDirectories);

                foreach (string pejFile in AllPEJFilesInDir)
                {
                    // scan out date and time from PEJ file (has format PEJyyyyMMddHHmmss.xml)
                    DateTime pejFileDateTime = tools.RadiantXmlFilename2DateTime(pejFile);

                    // if PEJ file has same date in name as the given BHE file
                    if (pejFileDateTime.Date == bheDate.Date)
                    {
                        // add the PEJ file to the list of PEJ
                        // files to be deleted when import is done
                        if (!pejFilesToDeleteAfterImport.Contains(pejFile))
                            pejFilesToDeleteAfterImport.Add(pejFile);

                        // keep the PEJ filename if it has the latest timestamp
                        if (pejFileDateTime > latestPEJFileDateTime)
                        {
                            latestPEJFileDateTime = pejFileDateTime;
                            pejFileToUse = pejFile;
                        }
                    }
                }
            }
            //<<Pn20210520
            // we now have the PEJ file to use for import

            #endregion
            //>>PN20210520
            if (pejFileToUse == "")
            {                
                if (MessageBox.Show("Ingen PEJ fil ønsker du at bogføre uden salg fra midnat til tælletidspunkt", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return(false);
            }
            //<<PN20210520
            if (pejFileToUse != "")
            {
                try
                {
                    OleDbCommand cmd = new OleDbCommand("", db.Connection);
                    DataSet ds = new DataSet();
                    XmlDocument doc = new XmlDocument();            
                    doc.Load(pejFileToUse);
                    XmlNode HeaderNode = doc.DocumentElement;
                    XmlNodeList results = HeaderNode.ChildNodes;
                    DateTime dtTimeOfDay = DateTime.MinValue;

                    foreach (XmlNode result in results)
                    {
                        string atribute = result.Name;
                        if (atribute == "JournalReport")
                        {
                            XmlNodeList Lines = result.ChildNodes;
                            foreach (XmlNode TransLines in Lines)
                            {
                                string TransType = TransLines.Name;
                                if (TransType == "SaleEvent")
                                {
                                    bool SaleBeforeCount = false;
                                    XmlNodeList LineInfo = TransLines.ChildNodes;
                                    foreach (XmlNode LineInfoNode in LineInfo)
                                    {
                                        string NodeName = LineInfoNode.Name;
                                        if (NodeName == "EventEndTime")
                                        {
                                            string tidtest = LineInfoNode.InnerText;
                                            dtTimeOfDay = Convert.ToDateTime(CountDate.ToString("yyyy/MM/dd ") + tidtest);
                                            if (dtTimeOfDay < CountDate)  //disse linjer er før optælling og skal tages med 20210210
                                            {
                                                SaleBeforeCount = true;
                                            }
                                        }
                                    }
                                    if (SaleBeforeCount == true)
                                    {
                                        foreach (XmlNode LineInfoNode in LineInfo)
                                        {
                                            string NodeName2 = LineInfoNode.Name;
                                            if (NodeName2 == "TransactionDetailGroup")
                                            {
                                                XmlNodeList TransActionsDetailGroup = LineInfoNode.ChildNodes;
                                                foreach (XmlNode TransLinesDetail in TransActionsDetailGroup)
                                                {
                                                    if (TransLinesDetail.Name == "TransactionLine")
                                                    {
                                                        XmlNodeList TransActionsLines = TransLinesDetail.ChildNodes;
                                                        {
                                                            foreach (XmlNode TransactionLine in TransActionsLines)
                                                            {
                                                                if (TransactionLine.Name == "ItemLine")
                                                                {
                                                                    byte PackType = 1;
                                                                    string ItemIDtxt = null;
                                                                    int SellingUnitSold = 0;
                                                                    int ItemID = 0;
                                                                    // lookup the PackSize quantity
                                                                    int tmpPackSizeQuantity =  ItemDataSet.LookupPackSizeDataTable.GetPackTypeQuantity(PackType);                                                                  
                                                                    XmlNodeList ItemLineFields = TransactionLine.ChildNodes;
                                                                    foreach (XmlNode ItemLineField in ItemLineFields)
                                                                    {
                                                                        if (ItemLineField.Name == "SalesQuantity")
                                                                        {
                                                                            SellingUnitSold = Convert.ToInt32(ItemLineField.InnerText);
                                                                        }
                                                                        if (ItemLineField.Name == "ItemCode")
                                                                        {
                                                                            XmlNodeList ItemLineItemCodes = ItemLineField.ChildNodes;
                                                                            foreach (XmlNode ItemLineItemCode in ItemLineItemCodes)
                                                                            {
                                                                                if (ItemLineItemCode.Name == "POSCode")
                                                                                {
                                                                                    ItemIDtxt = ItemLineItemCode.InnerText;
                                                                                    // get ItemID
                                                                                    ItemID = ItemDataSet.ItemDataTable.GetItemIDFromImportID(tools.object2int(ItemIDtxt));
                                                                                }
                                                                            }
                                                                        }                                                                    
                                                                            
                                                                        

                                                                        
                                                                    }
                                                                    if ((ItemID != 0) && (SellingUnitSold != 0))
                                                                    {
                                                                        // insert record in database
                                                                        cmd.CommandText = string.Format(
                                                                            "insert into BHHT_RSM_PEJSales " +
                                                                            " (BHHTCountID,ItemID,SalesDateTime,NoOfSold,SellingUnitSold,PackType) " +
                                                                            " values ({0},{1},'{2}',{3},{4},{5}) ",
                                                                            RHTCountID,
                                                                            ItemID,
                                                                            dtTimeOfDay,
                                                                            1,
                                                                            SellingUnitSold,
                                                                            1);                                                                        
                                                                        cmd.ExecuteNonQuery();
                                                                    }

                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }                                       
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.WriteException("ImportBHHT.ImportPEJ", ex.Message, ex.StackTrace);
                }
            }
            return (true);
        } // method end
        #endregion


    }
}

