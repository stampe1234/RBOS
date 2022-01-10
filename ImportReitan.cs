using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Data;
using System.Data.OleDb;

namespace RBOS
{
    /// <summary>
    /// Methods for importing data from BHHT.
    /// </summary>
    class ImportReitan
    {
        private ImportBHHTForm caller = null;
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

            if (!Directory.Exists(db.GetConfigString("BHHT_Import_Dir")))
            {
                lastError += db.GetConfigString("BHHT_Import_Dir") + "\n";
                ++dirCount;
            }

            if (db.GetConfigStringAsBool("BHHT_Import_Backup_Active"))
            {
                if (!Directory.Exists(db.GetConfigString("BHHT_Import_Dir_Backup")))
                {
                    lastError += db.GetConfigString("BHHT_Import_Dir_Backup") + "\n";
                    ++dirCount;
                }
            }

            if (dirCount > 0)
            {
                string dir = db.GetLangString("ImportBHHT.Directory");
                if (dirCount > 1) dir = db.GetLangString("ImportBHHT.Directories");
                lastError = string.Format(db.GetLangString("ImportBHHT.ImportDirDoesNotExist") + "\n\n", dir) + lastError;
            }

            return (dirCount == 0);
        }
        #endregion
        #region METHOD: ScanBHEFileList
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
        private List<string> ScanBHEFileList()
        {
            // check that import dirs exist
            if (!CheckImportDirsExists())
                return null;

            // get import dir
            string importDir = GetBHHTImportDir();

            List<string> bheFiles = new List<string>();

            // scan list of semaphore files and collect references to BHE files
            string[] semaphoreFiles = Directory.GetFiles(importDir, "*.xml", SearchOption.TopDirectoryOnly);
            foreach (string file in semaphoreFiles)
            {
                // open the semaphore xml document
                XmlDocument xml = new XmlDocument();
                xml.Load(file);

                /// traverse all File elements in the semaphore file
                /// and collect references to BHE files
                XmlNodeList list = xml.SelectNodes("FileList/File");
                foreach (XmlElement e in list)
                {
                    // if element is reference to BHE file
                    if (e.InnerText.StartsWith("BHE"))
                    {
                        // collect BHE file reference for import
                        bheFiles.Add(importDir + e.InnerText);
                    }
                }
            }

            // sort BHE filelist by date ("SEMyyyymmdd...")
            bheFiles.Sort();

            return bheFiles;
        }
        #endregion
        #region METHOD: ImportBHE
        /// <summary>
        /// Imports all BHE files from the directory given 
        /// in config table with key BHHT_Import_Dir to RBOS.
        /// </summary>
        public bool ImportReitanOrders()
        {
            lastError = "";
            

            // reset import counters
            importedOrders = 0;
      

            try
            {
                // check that import directories exists
                if (!CheckImportDirsExists())
                    return false;

                // get BHE filelist
                List<string> bheFiles = ScanBHEFileList();

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

                        // import data for tables BHHTOrderHeader and BHHTOrderDetails
                        ImportOrder(dsXML);

                                            }
                    catch (Exception ex)
                    {
                        log.WriteException("ImportBHHT.ImportBHE", ex.Message, ex.StackTrace);
                    }
                }

                
               

                // move BHE files now imported to backup dir or delete them
                foreach (string file in bheFiles)
                {
                    if (db.GetConfigStringAsBool("BHHT_Import_Backup_Active"))
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
                    log.WriteException("ImportBHHT.ImportBHE()", ex.Message, ex.StackTrace);
                return false;
            }
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

        #region METHOD: ImportOrder
        /// <summary>
        /// Import data for tables BHHTOrderHeader and BHHTOrderDetails.
        /// Is called from method ImportBHE each time a BHE file is loaded for import.
        /// </summary>
        /// <param name="dsXML">DataSet with loaded XML file.</param>
        private void ImportOrder(DataSet dsXML)
        {
            DataTable tableOrderHeader = dsXML.Tables["PurchaseOrder"];
            DataTable tableOrderDetails = dsXML.Tables["PurchaseOrderItemList"];
            if ((tableOrderHeader != null) && (tableOrderDetails != null))
            {
                // traverse order header records
                foreach (DataRow rowOrderHeader in tableOrderHeader.Rows)
                {
                    // get OrderID from the row
                    long OrderID = tools.object2long(rowOrderHeader["PurchaseOrderId"]);

                    // reset rbos bhht order id if already imported
                   

                    // get further needed header values from the row
                    long SupplierID = tools.object2long(rowOrderHeader["SupplierId"]);
                    DateTime OrderDate = tools.RadiantXmlDateTime2DateTime(rowOrderHeader["OrderDate"].ToString());
                    DateTime DeliveryDate = tools.RadiantDate2DateTime(rowOrderHeader["DeliveryDate"].ToString());

                    // check that delivery date is not ealier than order date.
                    // if it is, set it to order date
                    if (DeliveryDate.Date < OrderDate.Date)
                        DeliveryDate = OrderDate.Date;

                    // get the autogenerated header id (refered to in order details table)
                    int tableOrderHeaderID = tools.object2int(rowOrderHeader["PurchaseOrder_id"]);

                    // get order detail records
                    DataRow[] rowsOrderDetails =
                        tableOrderDetails.Select("PurchaseOrder_id = " + tableOrderHeaderID.ToString());

                    // traverse order detail records
                    long LineNo = 0;
                    long numExcludeFromOrder = 0;
                    foreach (DataRow rowOrderDetails in rowsOrderDetails)
                    {
                        ++LineNo;

                        // get supplier item id for lookup and save
                        long SuppItemID = tools.object2long(rowOrderDetails["SupplierItemId"]);

                        // get supplier item record for lookup
                        DataRow supplierItemLookup = GetSupplierItem(SuppItemID);

                        bool useSupplierItem = (supplierItemLookup != null);

                        // get further needed detail values from the row
                        byte PackType = 1;
                        long Quantity = (long)tools.object2double(rowOrderDetails["Quantity"]);
                        //bool ExcludeFromOrder = false;
                        int ExcludeFromOrder = 0;
                        Nullable<long> ItemID = null;
                        string ReceiptText = null;
                        Nullable<long> OrderingNumber = null;
                        Nullable<long> Kolli = null;
                        Nullable<double> PackageCost = null;
                        Nullable<double> Cost = null;

                        // if supplieritem found in rbos
                        if (supplierItemLookup != null)
                        {
                            // get PackType from supplieritem
                            PackType = tools.object2byte(supplierItemLookup["SellingPackType"]);

                            // get ItemID from supplier item lookup for further lookup and saving
                            ItemID = tools.object2long(supplierItemLookup["ItemID"]);

                            // get item record for lookup
                            DataRow itemLookup = GetItem(ItemID);

                            // get remaining needed detail values from the row
                            OrderingNumber = tools.object2long(supplierItemLookup["OrderingNumber"]);
                            Kolli = tools.object2long(supplierItemLookup["KolliSize"]);
                            PackageCost = tools.object2double(supplierItemLookup["PackageCost"]);

                            // lookup ReceiptText
                            string sqlReceiptText = string.Format(
                                " select ReceiptText from SalesPack " +
                                " where (ItemID = {0}) and (PackType = {1}) ",
                                ItemID, PackType);
                            OleDbCommand cmdReceiptText = new OleDbCommand(sqlReceiptText, db.Connection);
                            object o = cmdReceiptText.ExecuteScalar();
                            if ((o != null) && (o != DBNull.Value))
                            {
                                // get receipt text and fix possible invalid " char
                                ReceiptText = o.ToString().Replace("\"", "'");
                            }

                            // calculate cost (for this order line)
                            Cost = Quantity * PackageCost;
                        }
                        else
                        {
                            // as supplieritem was not found in rbos,
                            // exclude from order
                            ExcludeFromOrder = 1;
                            ++numExcludeFromOrder;
                        }

                        // create string versions of nullable variables to use in sql
                        // as if they contain null, we need to write "NULL" to db fields
                        string sItemID = (ItemID.HasValue ? ItemID.ToString() : "NULL");
                        string sOrderingNumber = (OrderingNumber.HasValue ? OrderingNumber.ToString() : "NULL");
                        string sKolli = (Kolli.HasValue ? Kolli.ToString() : "NULL");
                        //ReceiptText = ((ReceiptText != null) ? "\"" + ReceiptText + "\"" : "NULL");//pn20191010
                        ReceiptText = ((ReceiptText != null) ? "'" + ReceiptText + "'" : "NULL");
                        //string sPackageCost = (PackageCost.HasValue ? "'" + PackageCost.ToString() + "'" : "NULL");
                        //string sCost = (Cost.HasValue ? "'" + Cost.ToString() + "'" : "NULL");
                        string sPackageCost = tools.decimalnumber4sql(PackageCost);  //pn20191111
                        string sCost =  tools.decimalnumber4sql(Cost)  ;

                        // save detail data
                        // (DO NOT embrace ReceiptText in "", that is done above)
                        string sql = string.Format(
                            " insert into BHHTOrderDetails " +
                            " (BHHTOrderID,[LineNo],SuppItemID,ItemID,ReceiptText,PackType,OrderingNumber,Kolli,Quantity,ExcludeFromOrder,PackageCost,Cost) " +
                            " values ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}) ",
                            OrderID, LineNo, SuppItemID, sItemID, ReceiptText, PackType, sOrderingNumber, sKolli, Quantity, ExcludeFromOrder, sPackageCost, sCost);
                        OleDbCommand cmd = new OleDbCommand(sql, db.Connection);
                        cmd.Transaction = db.CurrentTransaction;
                        cmd.ExecuteNonQuery();
                    } // foreach order detail

                    // if any detail records, save the header
                    if (rowsOrderDetails.Length > 0)
                    {
                        // increment counter
                        ++importedOrders;

                        // message to user
                        caller.StatusText = db.GetLangString("ImportBHHT.ImportOrder") + importedOrders.ToString();

                        string sql = string.Format(
                            " insert into BHHTOrderHeader (OrderID, SupplierID, OrderDate, DeliveryDate, NumExcludeFromOrder, Status) " +
                            " values ({0},{1},'{2}','{3}',{4},'{5}') ",
                            OrderID, SupplierID, OrderDate, DeliveryDate, numExcludeFromOrder,"OPN");
                        OleDbCommand cmd = new OleDbCommand(sql, db.Connection);
                        cmd.Transaction = db.CurrentTransaction;
                        cmd.ExecuteNonQuery();

                        /// if AutoCreateOrdersFromBHHT is true in config,
                        /// the just created order has to be automatically
                        /// moved into the RBOS order tables, if no detail
                        /// lines have ExcludeFromOrder == true.
                        if (tools.object2bool(db.GetConfigString("AutoCreateRBOSOrdersFromBHHT")))
                        {
                            MoveBHHTOrderToRBOSOrderTables((int)OrderID, true);
                        }
                    }
                } // foreach order header
            } // if order tables exists
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
                string destFile = db.GetConfigString("BHHT_import_dir_backup") + file.Remove(0, idx);
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
        private string GetBHHTImportDir()
        {
            string importDir = db.GetConfigString("BHHT_Import_Dir");

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

        #region METHOD: ScanReitanFileList
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
        private List<string> ScanReitanFileList()
        {
            // check that import dirs exist
            if (!CheckImportDirsExists())
                return null;

            // get import dir
            string importDir = GetBHHTImportDir();

            List<string> bheFiles = new List<string>();

            // scan list of semaphore files and collect references to BHE files
            string[] semaphoreFiles = Directory.GetFiles(importDir, "SEM*.xml", SearchOption.TopDirectoryOnly);
            foreach (string file in semaphoreFiles)
            {
                // open the semaphore xml document
                XmlDocument xml = new XmlDocument();
                xml.Load(file);

                /// traverse all File elements in the semaphore file
                /// and collect references to BHE files
                XmlNodeList list = xml.SelectNodes("FileList/File");
                foreach (XmlElement e in list)
                {
                    // if element is reference to BHE file
                    if (e.InnerText.StartsWith("BHE"))
                    {
                        // collect BHE file reference for import
                        bheFiles.Add(importDir + e.InnerText);
                    }
                }
            }

            // sort BHE filelist by date ("SEMyyyymmdd...")
            bheFiles.Sort();

            return bheFiles;
        }
        #endregion

        #region METHOD: MoveBHHTOrdersToRBOSOrders
        public void MoveBHHTOrderToRBOSOrderTables(int BHHTOrderID, bool AutoMode)
        {
            // variables needed more than once
            OleDbDataAdapter adapter = new OleDbDataAdapter("", db.Connection);
            OleDbCommand cmd = new OleDbCommand("", db.Connection);

            // AutoMode == true means that this method has been called
            // from the automatic move of BHHT data to Order data.
            // If any order detail rows have ExcludeFromOrder == true,
            // the order may not be moved to the Order tables, but must remain
            // in the BHHTOrderHeader GUI/tables.

            // If AutoMode is false this method has been called from the GUI
            // when user creates an order. In that case it is ok to just skip
            // those order details in the move code below.

            if (AutoMode)
            {
                cmd.CommandText = string.Format(
                    " select BHHTOrderID from BHHTOrderDetails " +
                    " where BHHTOrderID = {0} and ExcludeFromOrder = 1 ",
                    BHHTOrderID);
                object o = cmd.ExecuteScalar();
                if ((o != null) && (o != DBNull.Value))
                    return;
            }

            // load all BHHTOrderHeader data
            adapter.SelectCommand.CommandText = " select * from BHHTOrderHeader where OrderID = " + BHHTOrderID.ToString();
            DataTable tableHeaderSrc = new DataTable();
            adapter.Fill(tableHeaderSrc);

            // check that BHHTOrderHeader exists
            if (tableHeaderSrc.Rows.Count <= 0) return;

            // get the BHHTOrderHeader
            DataRow rowHeaderSrc = tableHeaderSrc.Rows[0];

            // get source header values for creating dest header
            int SupplierID = tools.object2int(rowHeaderSrc["SupplierID"]);
            DateTime OrderDate = tools.object2datetime(rowHeaderSrc["OrderDate"]);
            DateTime DeliveryDate = tools.object2datetime(rowHeaderSrc["DeliveryDate"]);
            string OrderStatus = "'" + rowHeaderSrc["Status"].ToString() + "'";

            // insert new OrderHeader row.
            cmd.CommandText = string.Format(
                " insert into OrderHeader " +
                " (SupplierID,OrderDate,DeliveryDate,BHHTOrderID,OrderStatus) " +
                " values ({0},{1},{2},{3},{4}) ",
                SupplierID,
                "'" + OrderDate.ToString() + "'",
                "'" + DeliveryDate.ToString() + "'",
                BHHTOrderID,
                OrderStatus);
            cmd.ExecuteNonQuery();

            // extract the autogenerated OrderID 
            // to use when inserting new OrderDetail rows
            int OrderID = ItemDataSet.OrderHeaderDataTable.RetrieveMaxOrderID();

            // load related BHHTOrderDetails data
            adapter.SelectCommand.CommandText = string.Format(
                " select * from BHHTOrderDetails where BHHTOrderID = {0} ",
                BHHTOrderID);
            DataTable tableDetailsSrc = new DataTable();
            adapter.Fill(tableDetailsSrc);

            // NumberDetails and TotalCost for this header
            int NumberDetails = 0;
            double TotalCost = 0;

            // iterate through each source detail row
            foreach (DataRow rowDetailSrc in tableDetailsSrc.Rows)
            {
                /// If this order detail has been flagged for not to be
                /// imported, this either means that there are invalid
                /// fields in the row from BHHT import or that user
                /// has chosen to skip the record. In either case, we
                /// don't import the record if this flag is true.
                bool ExcludeFromOrder = tools.object2bool(rowDetailSrc["ExcludeFromOrder"]);

                // check that orderdetail is not excluded from order
                if (!ExcludeFromOrder)
                {
                    // generate next LineNo
                    int LineNo = 0;
                    cmd.CommandText = string.Format(
                        " select max([LineNo]) from OrderDetails " +
                        " where OrderID = {0} ",
                        OrderID);
                    LineNo = tools.object2int(cmd.ExecuteScalar()) + 1;

                    // get source detail values for creating dest detail row
                    int SupplierItemID = tools.object2int(rowDetailSrc["SuppItemID"]);
                    double OrderingNumber = tools.object2double(rowDetailSrc["OrderingNumber"]);
                    int KolliSize = tools.object2int(rowDetailSrc["Kolli"]);
                    double PackageCost = tools.object2double(rowDetailSrc["PackageCost"]);
                    byte PackType = tools.object2byte(rowDetailSrc["PackType"]);
                    string ReceiptText = rowDetailSrc["ReceiptText"].ToString();
                    double Cost = tools.object2double(rowDetailSrc["Cost"]);
                    double VAT = ItemDataSet.LookupVatRateDataTable.GetVATPctBySupplierItem(SupplierID, OrderingNumber);
                    double CostExVAT = tools.DeductVAT(Cost, VAT);
                    int Quantity = tools.object2int(rowDetailSrc["Quantity"]);

                    // no need to fix possible receipt text char errors,
                    // as this is fixed in ImportOrder.

                    // create the detail row
                    cmd.CommandText = string.Format(
                        " insert into OrderDetails " +
                        " (OrderID,[LineNo],SuppItemID,OrderingNumber,KolliSize,PackageCost,PackType,ReceiptText,Cost,CostExVAT,Quantity) " +
                        " values ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}) ",
                        OrderID,
                        LineNo,
                        SupplierItemID,
                        "'" + OrderingNumber.ToString() + "'",
                        KolliSize,
                        tools.decimalnumber4sql(PackageCost) ,
                        PackType,
                        "'" + ReceiptText + "'",
                        tools.decimalnumber4sql(Cost),
                        tools.decimalnumber4sql(CostExVAT)  ,
                        Quantity);
                    cmd.ExecuteNonQuery();

                    // increment NumberDetails and sum up TotalCost
                    ++NumberDetails;
                    TotalCost += Cost;
                }
            }

            /// It is by design, that if no order detail rows has
            /// been created, we still want to create the header.
            /// Thus the user will get an order header with no details.

            // update header with NumberDetails and TotalCost
            cmd.CommandText = string.Format(
                " update OrderHeader set " +
                " NumberDetails = {0}, " +
                " TotalCost = {1} " +
                " where OrderID = {2} ",
                NumberDetails,
                //"'" + TotalCost.ToString() + "'",
                tools.decimalnumber4sql(TotalCost),
                OrderID);
            cmd.ExecuteNonQuery();

            // delete BHHTOrderHeader and BHHTOrderDetails records
            // just copied to OrderHeader and OrderDetails tables
            cmd.CommandText =
                " delete from BHHTOrderHeader where OrderID = " + BHHTOrderID.ToString();
            cmd.ExecuteNonQuery();
            cmd.CommandText =
                " delete from BHHTOrderDetails where BHHTOrderID = " + BHHTOrderID.ToString();
            cmd.ExecuteNonQuery();
        }
        #endregion
    }
}
