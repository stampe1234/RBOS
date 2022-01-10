using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RBOS.ImportDataSetTableAdapters;
using System.Data.OleDb;
using System.Windows.Forms;

namespace RBOS
{
    /// <summary>
    /// Import methods for EP data.
    /// </summary>
    class ImportEP
    {
        #region METHOD: LookupPackType()
        /// <summary>
        /// Lookup PackType id from LookupPackSize table.
        /// </summary>
        /// <param name="description">PackTypeName string.</param>
        /// <returns>The PackType id if found, otherwise 0.</returns>
        private static byte LookupPackType(string PackTypeName)
        {
            if (PackTypeName == "")
                PackTypeName = "Stk";
            string sql = string.Format(
                "select PackType from LookupPackSize where PackTypeName = '{0}'",
                PackTypeName.Trim());
            DataSet ds = new DataSet();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, db.Connection);
            adapter.Fill(ds);
            if ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
                return byte.Parse(ds.Tables[0].Rows[0]["PackType"].ToString());
            else
                return 0;
        }
        #endregion

        #region METHOD: LookupBCType()
        /// <summary>
        /// Translates the provided barcode type name to
        /// the lookup integer used in RBOS.
        /// </summary>
        /// <param name="BarcodeTypeName">"EAN8", "EAN13" or "Custom".</param>
        /// <returns>
        /// "EAN8" returns 3,
        /// "EAN13" returns 2,
        /// "Custom" returns 1.
        /// </returns>
        private static int LookupBCType(string BarcodeTypeName)
        {
            if (BarcodeTypeName.ToUpper() == "EAN8") return 3;
            else if (BarcodeTypeName.ToUpper() == "EAN13") return 2;
            else return 1; // custom
        }
        #endregion

        #region METHOD: ImportItemTestData()
        /// <summary>
        /// Import test data from Import_testdata_item table. This table is imported in Access from
        /// an Excel file. It is assumed that the SubCategory has rows that correspond to the
        /// SubCategories needed in the imported item data.
        /// NOTE: ALL DATA FROM TABLES Item, SubCategory and Barcode WILL BE DELETED FIRST.
        /// </summary>
        public static void ImportItemTestData()
        {
            //@@@ TO BE ADDED:
            // set default Item.VatRate to 2 (25% moms)

            // delete existing Item, SalesPack and Barcode data
            string sqlDel = " delete from Item";
            OleDbCommand cmdDel = new OleDbCommand(sqlDel, db.Connection);
            cmdDel.ExecuteNonQuery();
            sqlDel = " delete from SalesPack";
            cmdDel = new OleDbCommand(sqlDel, db.Connection);
            cmdDel.ExecuteNonQuery();
            sqlDel = " delete from Barcode";
            cmdDel = new OleDbCommand(sqlDel, db.Connection);
            cmdDel.ExecuteNonQuery();

            ImportDataSet dsImport = new ImportDataSet();

            // load testdata_item data
            Import_testdata_itemTableAdapter adapterTestdata = new Import_testdata_itemTableAdapter();
            adapterTestdata.Connection = db.Connection;
            adapterTestdata.Fill(dsImport.Import_testdata_item);

            // assume that the SQL for testdata_item data is
            // ordered by ItemName, PackSize, Barcode

            string prevItemName = "";
            string prevPackSize = "";
            double prevBarcode = 0;

            bool createItemRow = false;
            bool createPackSizeRow = false;
            bool createBarcodeRow = false;

            int currItemID = 0;
            byte currPackSize = 0;
            bool primarySalesPack = false;

            // iterate through each test data row
            foreach (ImportDataSet.Import_testdata_itemRow row in dsImport.Import_testdata_item.Rows)
            {
                primarySalesPack = false;

                // if encountered a new item name, then flag for creation of
                // a new item row, a new packsize row and a new barcode row
                if (prevItemName != row.Itemname.Trim().ToLower())
                {
                    createItemRow = true;
                    createPackSizeRow = true;
                    primarySalesPack = true; // only set the first salespack in the item to primary
                    createBarcodeRow = true;
                }
                else
                {
                    // if encountered a new packsize within same item, then flag 
                    // for creation of a new packsize row and a new barcode row
                    if (prevPackSize != row.PackSize.Trim().ToLower())
                    {
                        createPackSizeRow = true;
                        createBarcodeRow = true;
                    }
                    else
                    {
                        // if encounted a new barcode within same item and 
                        // same packsize, then flag for creation of a new barcode
                        if (prevBarcode != row.Barcode)
                            createBarcodeRow = true;
                    }
                }

                // create new Item row as flagged above
                if (createItemRow)
                {
                    string sql = string.Format(
                        "insert into Item (ItemName,SubCategory) values (\"{0}\",\"{1}\")",
                        row.Itemname.Trim(), row.SubCategory.Trim());
                    OleDbCommand cmd = new OleDbCommand(sql, db.Connection);
                    cmd.ExecuteNonQuery();
                    currItemID = ItemDataSet.GetLatestItemID();
                    createItemRow = false;
                }

                // create new PackSize row as flagged above
                if (createPackSizeRow)
                {
                    currPackSize = LookupPackType(row.PackSize);
                    string tmpReceiptText = row.Itemname.Trim();
                    if (tmpReceiptText.Length > 30) tmpReceiptText = tmpReceiptText.Remove(30);
                    double tmpSalesPrice = 0;
                    try { tmpSalesPrice = double.Parse(row.RetailPrice.ToString()); }
                    catch(Exception) {}
                    
                    string sql = string.Format(
                        "insert into SalesPack (ItemID,PackType,SalesPrice,ReceiptText,IsPrimary) values ({0},{1},\"{2}\",\"{3}\",{4})",
                        currItemID,currPackSize,tmpSalesPrice,tmpReceiptText,primarySalesPack);
                    OleDbCommand cmd = new OleDbCommand(sql, db.Connection);
                    cmd.ExecuteNonQuery();
                    createPackSizeRow = false;
                }

                // create new Barcode row as flagged above
                if (createBarcodeRow)
                {
                    int bctype = 1; // default custom barcode type
                    if (row.Barcode.ToString().Length == 8) bctype = 3;
                    else if (row.Barcode.ToString().Length == 13) bctype = 2;
                    string sql = string.Format(
                        "insert into Barcode (ItemID,PackType,Barcode,BCType) values ({0},{1},{2},{3})",
                        currItemID, currPackSize, row.Barcode, bctype);
                    OleDbCommand cmd = new OleDbCommand(sql, db.Connection);
                    cmd.ExecuteNonQuery();
                    createBarcodeRow = false;

                    // if this is the first barcode row with this
                    // ItemID and PackType make it primary
                    // and write its values to SalesPack table too
                    sql = string.Format(
                        " select IsPrimary from Barcode " +
                        " where (IsPrimary = true) " +
                        " and (ItemID = {0}) " +
                        " and (PackType = {1}) ",
                        currItemID, currPackSize);
                    DataSet dsCheck = new DataSet();
                    OleDbDataAdapter adapterCheck = new OleDbDataAdapter(sql, db.Connection);
                    adapterCheck.Fill(dsCheck);
                    if ((dsCheck.Tables.Count > 0) && (dsCheck.Tables[0].Rows.Count == 0))
                    {
                        // mark this as primary
                        sql = string.Format(
                            " update Barcode set IsPrimary = true " +
                            " where (ItemID = {0}) and (PackType = {1}) and (Barcode = {2}) ",
                            currItemID, currPackSize, row.Barcode);
                        cmd = new OleDbCommand(sql, db.Connection);
                        cmd.ExecuteNonQuery();

                        // copy its values to SalesPack table
                        sql = string.Format(
                            " update SalesPack set Barcode = {0}, BCType = {1} " +
                            " where (ItemID = {2}) and (PackType = {3}) ",
                            row.Barcode, bctype, currItemID, currPackSize);
                        cmd = new OleDbCommand(sql, db.Connection);
                        cmd.ExecuteNonQuery();
                    }
                }

                prevItemName = row.Itemname.Trim().ToLower();
                prevPackSize = row.PackSize.Trim().ToLower();
                prevBarcode = row.Barcode;
            }

            MessageBox.Show("Done importing");
        }
        #endregion

        #region METHOD: ImportEPdata()


        /// <summary>
        /// Import data from EP tables to RBOS tables:
        /// Import_EP_Barcodes -> Barcode
        /// Import_EP_PazkSizes -> SalesPack
        /// Import_EP_RetailItems -> Item
        /// Import_EP_SupplierItems -> SupplierItem
        /// Usually this is done once. All existing data
        /// must be deleted from target tables first.
        /// </summary>
        public static void ImportEPdata()
        {
            // erase all data
            OleDbCommand cmdDelete = new OleDbCommand("", db.Connection);
            cmdDelete.CommandText = "delete from Item";
            cmdDelete.ExecuteNonQuery();
            cmdDelete.CommandText = "delete from SalesPack";
            cmdDelete.ExecuteNonQuery();
            cmdDelete.CommandText = "delete from Barcode";
            cmdDelete.ExecuteNonQuery();
            cmdDelete.CommandText = "delete from SupplierItem";
            cmdDelete.ExecuteNonQuery();

            if (MessageBox.Show("Fix missing chainitem barcodes in source tables? (takes forever)", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                /// fix all missing chainitem barcodes
                /// (radiant ep gui seems to allow creation of item-salespack without a barcode,
                /// if this is used as a chain item - RBOS does not allow this so generate a custom barcode)
                string sqlMissingBarcodes =
                    " select * " +
                    " from (import_ep_retailitems item " +
                    " inner join import_ep_packsizes salespack " +
                    " on item.ItemId = salespack.ItemId) " +
                    " where salespack.ItemPackId not in " +
                    " ( select ItemPackId from import_ep_barcodes ) ";
                OleDbDataAdapter adapterMissingBarcodes = new OleDbDataAdapter(sqlMissingBarcodes, db.Connection);
                DataTable tableMissingBarcodes = new DataTable();
                adapterMissingBarcodes.Fill(tableMissingBarcodes);
                int customCounter = 0;
                foreach (DataRow row in tableMissingBarcodes.Rows)
                {
                    string sqlNewBarcode = string.Format(
                        " insert into import_ep_barcodes (CodeType,Barcode,ItemPackId) " +
                        " values (\"{0}\",\"{1}\",{2}) ",
                        "Custom", (9000 + customCounter++).ToString(), row["ItemPackId"]);
                    OleDbCommand cmdNewBarcode = new OleDbCommand(sqlNewBarcode, db.Connection);
                    cmdNewBarcode.ExecuteNonQuery();
                }
            }

            // set all NotImported flags
            OleDbCommand cmdImported = new OleDbCommand("", db.Connection);
            cmdImported.CommandText = "update import_ep_retailitems set NotImported = true";
            cmdImported.ExecuteNonQuery();
            cmdImported.CommandText = "update import_ep_packsizes set NotImported = true";
            cmdImported.ExecuteNonQuery();
            cmdImported.CommandText = "update import_ep_barcodes set NotImported = true";
            cmdImported.ExecuteNonQuery();
            cmdImported.CommandText = "update import_ep_supplieritems set NotImported = true";
            cmdImported.ExecuteNonQuery();

            OleDbDataAdapter adapter = new OleDbDataAdapter("", db.Connection);
            DataTable tableBarcodeSrc = new DataTable();
            DataTable tableSalesPackSrc = new DataTable();
            DataTable tableItemSrc = new DataTable();
            DataTable tableSupplierItemSrc = new DataTable();

            // load source tables
            // distinct item select to fix Radiant EP export error of multiple item rows with same ItemID (when more than one salespack)
            adapter.SelectCommand.CommandText = "select distinct * from Import_EP_RetailItems";
            adapter.Fill(tableItemSrc);
            adapter.SelectCommand.CommandText = "select * from Import_EP_PackSizes";
            adapter.Fill(tableSalesPackSrc);
            adapter.SelectCommand.CommandText = "select * from Import_EP_Barcodes order by ItemPackId, CodeType desc"; // order 'Custom' last
            adapter.Fill(tableBarcodeSrc);
            adapter.SelectCommand.CommandText = "select * from Import_EP_SupplierItems";
            adapter.Fill(tableSupplierItemSrc);

            // create extra in-memory columns on import sales pack table,
            // to keep the generated RBOS ItemID and PackType,
            // for later reference in this method
            tableSalesPackSrc.Columns.Add("GeneratedRBOSItemID");
            tableSalesPackSrc.Columns.Add("GeneratedRBOSPackType");
            tableSalesPackSrc.Columns.Add("GeneratedRBOSPrimaryBarcode");
            tableSalesPackSrc.Columns.Add("GeneratedRBOSIsPrimary");

            // iterate items
            foreach(DataRow itemRow in tableItemSrc.Rows)
            {
                if (itemRow["ItemId"] != DBNull.Value)
                {
                    // iterate salespack for this item
                    long epItemID = long.Parse(itemRow["ItemId"].ToString());
                    bool itemCreated = false;
                    bool primarySalesPackSet = false;
                    long ItemID = 0;
                    DataRow[] salespackRows = tableSalesPackSrc.Select(string.Format("ItemId = {0}", epItemID));
                    foreach (DataRow salespackRow in salespackRows)
                    {
                        // barcodes for this salespack
                        long epItemPackID = long.Parse(salespackRow["ItemPackId"].ToString());
                        bool salespackCreated = false;
                        bool primaryBarcodeSet = false;
                        byte PackType = 0;
                        DataRow[] barcodeRows = tableBarcodeSrc.Select(string.Format("ItemPackId = {0}", epItemPackID));
                        foreach (DataRow barcodeRow in barcodeRows)
                        {
                            // integrity ok, so create the
                            // parent item and parent salespack once,
                            // and create the barcodes

                            if (!itemCreated)
                            {
                                // correct 5 to 2 in subcategory in source data
                                if (itemRow["SubCategory"].ToString()[0] == '5')
                                {
                                    string s = itemRow["SubCategory"].ToString();
                                    itemRow["SubCategory"] = '2' + s.Substring(1);
                                }

                                // select subcategory to inherit from
                                string sqlSubCat = string.Format(
                                    " select * from SubCategory where SubCategoryID = '{0}' ", itemRow["SubCategory"]);
                                DataTable tableSubCat = new DataTable();
                                OleDbDataAdapter adapterSubCat = new OleDbDataAdapter(sqlSubCat, db.Connection);
                                adapterSubCat.Fill(tableSubCat);
                                if (tableSubCat.Rows.Count <= 0)
                                {
                                    MessageBox.Show(string.Format("Error: subcategory in item {0} can't be found in subcategory table",itemRow["ItemName"]));
                                    return;
                                }
                                DataRow rowSubCat = tableSubCat.Rows[0];

                                // pick out inherited values
                                int vatrate = int.Parse(rowSubCat["VatRate"].ToString()); // double parsed as int as all values are int
                                string creditCat = itemRow["CreditCategory"].ToString().PadLeft(4, '0');
                                if (creditCat == "0000") creditCat = rowSubCat["CreditCategory"].ToString();
                                bool creditCatInherited = (creditCat == rowSubCat["CreditCategory"].ToString());
                                int ageRestriction = int.Parse(itemRow["AgeRestriction"].ToString());
                                bool ageRestrictionInherited = (ageRestriction == int.Parse(rowSubCat["AgeRestriction"].ToString()));
                                int mopRestriction = int.Parse(rowSubCat["MOPRestriction"].ToString());
                                bool mopRestrictionInherited = true;
                                int itemTypeCode = int.Parse(rowSubCat["ItemTypeCode"].ToString());
                                bool itemTypeCodeInherited = true;
                                double budgetMargin = double.Parse(rowSubCat["BudgetMargin"].ToString());

                                // create item
                                string sqlCreateItem = string.Format(
                                    " insert into Item ( " +
                                    " ItemName,SubCategory,VatRate,CreditCategory,InheritCreditCat, " +
                                    " AgeRestriction,InheritAgeRestric,MOPRestriction,InheritMOPRestr, " +
                                    " ItemTypeCode,InheritItemTypeCode, BudgetMargin, LastChangeDateTime) " +
                                    " values (\"{0}\",\"{1}\",{2},\"{3}\",{4},{5},{6},{7},{8},{9},{10},{11},'{12}')",
                                    itemRow["ItemName"],
                                    itemRow["SubCategory"],
                                    vatrate,
                                    creditCat,
                                    creditCatInherited,
                                    ageRestriction,
                                    ageRestrictionInherited,
                                    mopRestriction,
                                    mopRestrictionInherited,
                                    itemTypeCode,
                                    itemTypeCodeInherited,
                                    budgetMargin.ToString().Replace(',','.'),
                                    DateTime.Now);
                                OleDbCommand cmdItem = new OleDbCommand(sqlCreateItem, db.Connection);
                                cmdItem.ExecuteNonQuery();
                                // get created ItemID
                                cmdItem.CommandText = "select max(ItemID) from Item";
                                ItemID = long.Parse(cmdItem.ExecuteScalar().ToString().Clone().ToString());

                                // only create this item once
                                itemCreated = true;

                                // mark item as imported
                                cmdImported.CommandText = string.Format(
                                    "update import_ep_retailitems set NotImported = false where ItemId = {0}",
                                    itemRow["ItemId"]);
                                cmdImported.ExecuteNonQuery();
                            }

                            if (!salespackCreated)
                            {
                                // get receipt text from truncated itemname
                                string receiptText = salespackRow["ItemName"].ToString();
                                if (receiptText.Length > 30) receiptText = receiptText.Remove(30);

                                // get manual price. further, if retail price is 0,
                                // we force manualprice = true
                                bool manualPrice = (double.Parse(salespackRow["ManualPrice"].ToString()) == 1);
                                if (double.Parse(salespackRow["RetailPrice"].ToString()) == 0)
                                    manualPrice = true;

                                // get packtype
                                PackType = LookupPackType(salespackRow["PackType"].ToString());

                                // sanity check
                                if (PackType == 0)
                                {
                                    MessageBox.Show(string.Format("PackType {0} converts to 0",salespackRow["PackType"]));
                                    return;
                                }

                                double retailPrice = double.Parse(salespackRow["RetailPrice"].ToString());

                                // create salespack
                                string sqlCreateSalesPack = string.Format(
                                    " insert into SalesPack (ItemID,PackType,ReceiptText,ManualPrice,SalesPrice,IsPrimary,UpdateShelfLabel,NoOfShLabels,UpdateRSM) " +
                                    " values ({0},{1},\"{2}\",{3},{4},{5},{6},{7},{8}) ",
                                    ItemID,
                                    PackType,
                                    receiptText,
                                    manualPrice,
                                    retailPrice.ToString().Replace(',', '.'),
                                    !primarySalesPackSet, // IsPrimary
                                    true, // UpdateShelfLabel
                                    1, // NoOfShLabels
                                    true); // UpdateRSM
                                OleDbCommand cmdSalesPack = new OleDbCommand(sqlCreateSalesPack, db.Connection);
                                cmdSalesPack.ExecuteNonQuery();

                                // keep IsPrimary in-memory for later reference
                                salespackRow["GeneratedRBOSIsPrimary"] = !primarySalesPackSet; // IsPrimary

                                // update POSSalesPrice on Item,
                                // that is, copy primary salespack's salesprice
                                if (!primarySalesPackSet)
                                {
                                    string sqlItemSetSalesPrice = string.Format(
                                        " update Item set POSSalesPrice = \"{0}\" where ItemID = {1} ",
                                        retailPrice, ItemID);
                                    OleDbCommand cmdItemSetSalesPrice = new OleDbCommand(sqlItemSetSalesPrice, db.Connection);
                                    cmdItemSetSalesPrice.ExecuteNonQuery();
                                }

                                // only one primary salespack in this item
                                primarySalesPackSet = true;

                                // only create this salespack once
                                salespackCreated = true;

                                // mark salespack as imported
                                cmdImported.CommandText = string.Format(
                                    "update import_ep_packsizes set NotImported = false where ItemPackId = {0}",
                                    salespackRow["ItemPackId"]);
                                cmdImported.ExecuteNonQuery();
                                salespackRow["NotImported"] = false; // also in-memory for later reference
                            }

                            /// create barcode ('Custom' barcodes are sorted after 'EAN8' and 'EAN13'),
                            /// if only one barcode, import it,
                            /// else if custom barcode and no other barcode has been imported, then import it,
                            /// else take everything except custom
                            if ((barcodeRows.Length == 1) ||
                                ((barcodeRow["CodeType"].ToString().ToLower() == "custom") && (!primaryBarcodeSet)) ||
                                ((barcodeRow["CodeType"].ToString().ToLower() != "custom")))
                            {
                                int bctype = LookupBCType(barcodeRow["CodeType"].ToString());
                                double barcode = double.Parse(barcodeRow["BarCode"].ToString());

                                if (barcode == 0)
                                {
                                    MessageBox.Show("Barcode parsed to 0");
                                    return;
                                }

                                string sqlCreateBarcode = string.Format(
                                    " insert into Barcode (ItemID,PackType,BCType,Barcode,IsPrimary) " +
                                    " values ({0},{1},{2},{3},{4}) ",
                                    ItemID,
                                    PackType,
                                    bctype,
                                    barcode,
                                    !primaryBarcodeSet);
                                OleDbCommand cmdBarcode = new OleDbCommand(sqlCreateBarcode, db.Connection);
                                cmdBarcode.ExecuteNonQuery();

                                if (!primaryBarcodeSet)
                                {
                                    // update parent salespack's primary barcode
                                    string sqlParentSalesPack = string.Format(
                                        " update SalesPack set " +
                                        " BCType = {0}, Barcode = {1} " +
                                        " where (ItemID = {2}) and (PackType = {3}) ",
                                        bctype, barcode, ItemID, PackType);
                                    OleDbCommand cmdParentSalesPack = new OleDbCommand(sqlParentSalesPack, db.Connection);
                                    cmdParentSalesPack.ExecuteNonQuery();

                                    // keep generated RBOS ItemID, PackType and Barcode for later reference (in-memory only)
                                    salespackRow["GeneratedRBOSItemID"] = ItemID;
                                    salespackRow["GeneratedRBOSPackType"] = PackType;
                                    salespackRow["GeneratedRBOSPrimaryBarcode"] = barcode;
                                }

                                // only one primary barcode in this salespack
                                primaryBarcodeSet = true;

                                // mark barcode as imported
                                cmdImported.CommandText = string.Format(
                                    "update import_ep_barcodes set NotImported = false where (ItemPackId = {0}) and (Barcode = \"{1}\")",
                                    barcodeRow["ItemPackId"], barcodeRow["Barcode"]);
                                cmdImported.ExecuteNonQuery();
                            }
                        } // foreach barcode
                    } // foreach salespack
                } // end check for if itemid dbnull
            } // foreach item

            /// Import chain items references
            /// 
            /// The logic is this:
            /// Iterate through each import_ep_packsizes row and extract
            /// the RBOS ItemID, PackType and Barcode. Use ItemID and PackType
            /// to find the generated equal row in SalesPack.
            /// Lookup the chained salespack row and extract it's
            /// RBOS ItemID, PackType and Barcode. Copy these values
            /// to the found RBOS row. Done.
            foreach (DataRow salespackRow in tableSalesPackSrc.Rows)
            {
                bool imported = ((salespackRow["NotImported"] != DBNull.Value) && (!bool.Parse(salespackRow["NotImported"].ToString())));
                if (imported && (salespackRow["ChainItemId"] != DBNull.Value))
                {
                    // get kept RBOS ItemID and PackType,
                    // these will be used to locate the generated RBOS SalesPack row
                    int rboslookupItemID = int.Parse(salespackRow["GeneratedRBOSItemID"].ToString());
                    byte rboslookupPackType = byte.Parse(salespackRow["GeneratedRBOSPackType"].ToString());

                    // lookup chained salespack row and get kept RBOS ItemID, PackType and primary Barcode,
                    // these will be copied to the generated RBOS SalesPack row
                    int importChainItemID = int.Parse(salespackRow["ChainItemId"].ToString());
                    DataRow[] lookupRows = tableSalesPackSrc.Select(string.Format("ItemPackId = {0}", importChainItemID));
                    if (lookupRows.Length > 0)
                    {
                        int rboscopyItemID = int.Parse(lookupRows[0]["GeneratedRBOSItemID"].ToString());
                        byte rboscopyPackType = byte.Parse(lookupRows[0]["GeneratedRBOSPackType"].ToString());
                        double rboscopyBarcode = double.Parse(lookupRows[0]["GeneratedRBOSPrimaryBarcode"].ToString());

                        // update the RBOS SalesPack row 
                        // corresponding to the import salespack row
                        string sqlChain = string.Format(
                            " update SalesPack set " +
                            " ChainItemID = {0}, " +
                            " ChainPackType = {1}, " +
                            " ChainBarcode = {2} " +
                            " where (ItemID = {3}) and (PackType = {4}) ",
                            rboscopyItemID, rboscopyPackType, rboscopyBarcode, rboslookupItemID, rboslookupPackType);
                        OleDbCommand cmdChain = new OleDbCommand(sqlChain, db.Connection);
                        cmdChain.ExecuteNonQuery();
                    }
                }
            }

            /// Import supplier items
            /// 
            /// We use the already loaded import salespack table,
            /// as this has some virtual columns and one of those is
            /// GeneratedRBOSItemID, which we will use to link the
            /// SupplierItem to the Item. BUT, we select out only
            /// the rows with IsPrimary = true.
            DataRow[] impPrimarySalesPacks = tableSalesPackSrc.Select("(GeneratedRBOSIsPrimary = true) AND (NotImported = false)");
            foreach (DataRow salespackRow in impPrimarySalesPacks)
            {
                // get import supplier data row for this import item
                DataRow[] importSuppliers = tableSupplierItemSrc.Select(
                    string.Format("ItemId = {0}", salespackRow["ItemId"]));
                if (importSuppliers.Length > 0)
                {
                    // looping each supplier for this item
                    int numLoops = 0;
                    foreach (DataRow impSupplier in importSuppliers)
                    {
                        ++numLoops;
                        // needed for the sql
                        int ItemID = int.Parse(salespackRow["GeneratedRBOSItemID"].ToString());

                        // get the item's vatrate, as it is needed
                        // for fixing the ep package costprice
                        string sqlGetVatRate = string.Format(
                            "select VatRate from Item where ItemID = {0}", ItemID);
                        OleDbCommand cmdGetVatRate = new OleDbCommand(sqlGetVatRate, db.Connection);
                        int vatid = int.Parse(cmdGetVatRate.ExecuteScalar().ToString()); // get lookup id
                        cmdGetVatRate.CommandText = string.Format("select TaxPct from LookupTaxID where TaxID = {0}",vatid);
                        float vatrate = float.Parse(cmdGetVatRate.ExecuteScalar().ToString()); // get vatrate
                        vatrate = 1 + (vatrate / 100);

                        // more variables needed for the sql
                        int SupplierNo = int.Parse(impSupplier["SupplierNumber"].ToString()) - 1000000;
                        double OrderingNumber = double.Parse(impSupplier["OrderingNumber"].ToString()); // no decimals
                        int KolliSize = int.Parse(impSupplier["KolliSize"].ToString());
                        double PackageCost = double.Parse(impSupplier["PackageCost"].ToString()) * vatrate; // fix cost price
                        double PackageUnitCost = PackageCost / KolliSize;
                        bool IsPrimary = (numLoops == 1);
                        byte SellingPackType = LookupPackType(salespackRow["PackType"].ToString());
                        int NoOfSellingUnits = ItemDataSet.LookupPackTypeAmount(SellingPackType);
                        double SellingUnitCost = PackageUnitCost / NoOfSellingUnits;

                        // build sql
                        string sqlSupplierDest = string.Format(
                            " insert into SupplierItem " +
                            " (ItemID, SupplierNo, OrderingNumber, KolliSize, PackageCost, " +
                            " PackageUnitCost, IsPrimary, SellingPackType, NoOfSellingUnits, SellingUnitCost) " +
                            " values ({0},{1},{2},{3},\"{4}\",\"{5}\",{6},{7},{8},\"{9}\") ",
                            ItemID, SupplierNo, OrderingNumber, KolliSize, PackageCost,
                            PackageUnitCost, IsPrimary, SellingPackType, NoOfSellingUnits, SellingUnitCost);

                        // insert into SupplierItem
                        OleDbCommand cmdSupplierDest = new OleDbCommand(sqlSupplierDest, db.Connection);
                        cmdSupplierDest.ExecuteNonQuery();

                        // copy PackageUnitCost and Margin to Item
                        if (IsPrimary)
                        {
                            double SalesPrice = double.Parse(salespackRow["RetailPrice"].ToString());
                            double Margin = 0;
                            if (SalesPrice != 0)
                                Margin = (((SalesPrice - PackageUnitCost) / SalesPrice) * 100);
                            string sqlUpdateItem = string.Format(
                                " update Item set Margin = \"{0}\", CostPriceLatest = \"{1}\" where ItemID = {2} ",
                                Margin, PackageUnitCost, ItemID);
                            OleDbCommand cmdUpdateItem = new OleDbCommand(sqlUpdateItem, db.Connection);
                            cmdUpdateItem.ExecuteNonQuery();
                        }
                    }
                }
            }

            MessageBox.Show("Done importing EP data");

        } // end method

        #endregion
    }
}
