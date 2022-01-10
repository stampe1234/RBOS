using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Data;
using System.Data.OleDb;

namespace RBOS
{
    /// <summary>
    /// Methods for exporting data to RSM.
    /// </summary>
    class ExportRSM
    {
        #region Private variables

        private string filenameITT = "";
        private string filenameMCT = "";
        private string filenameTSM = "";
        private string filenameILT = "";

        #endregion

        #region METHOD: CreateITTData
        /// <summary>
        /// Creates ITT XML export file to Radiant.
        /// Location of output directory is set in config table with key "NAXML_Export_Dir".
        /// </summary>
        /// <param name="includeUpdateRSM">If true, UpdateRSM flag is checked for true.</param>
        /// <param name="subCategoryFrom">If not "", SubCategory range if checked for.</param>
        /// <param name="subCategoryTo">MUST be eiter same value as subCategoryFrom or another value. NOT "".</param>
        /// <param name="barcode">If not null, Barcode is checked for.</param>
        /// <param name="startDateTime">If not null, start/end interval of LastChangeDateTime is checked for.</param>
        /// <param name="endDateTime">MUST be either same value as startDateTime or another value. NOT null.</param>
        /// <returns></returns>
        public DataTable CreateITTData(
            bool includeUpdateRSM,
            string subCategoryFrom,
            string subCategoryTo,
            Nullable<double> barcode,
            Nullable<DateTime> startDateTime,
            Nullable<DateTime> endDateTime,
            bool initialiser)
        {
            string sqlWhereClause = "";

            // add UpdateRSM flag to where clause
            if (includeUpdateRSM)
                sqlWhereClause += " AND (SalesPack.UpdateRSM = 1) ";
            
            // add SubCategory range to where clause
            if((subCategoryFrom != "") && (subCategoryTo != ""))
            {
                sqlWhereClause += string.Format(
                    " AND ((Item.SubCategory >= '{0}') AND (Item.SubCategory <= '{1}')) ",
                    subCategoryFrom,subCategoryTo);
            }

            // add Barcode to where clause
            if (barcode != null)
                sqlWhereClause += string.Format(" AND (Barcode.Barcode = {0}) ", barcode);

            // add start/end DateTime range to where clause
            if((startDateTime != null) && (endDateTime != null))
            {
                sqlWhereClause += string.Format(
                    " AND ((Item.LastChangeDateTime >= '{0}') AND (Item.LastChangeDateTime <= '{1}')) ",
                    startDateTime.Value, endDateTime.Value);
            }

            // select all SemiDeleted records or records that meet above criteria...
            if (initialiser)
            {
                sqlWhereClause = "";
            }

            //20200130
            string sql = string.Format(@"

SELECT DISTINCT
    Item.ItemID,
    Item.ItemName,
    Item.SubCategory,
    Item.FSD_ID,
    Item.SemiDeleted,
      
    
    LookupPackSize.PackTypeName,
    SalesPack.PackType,
    SalesPack.SalesPrice,
    SalesPack.ReceiptText,
    Item.ItemTypeCode,
    Item.CreditCategory,
    LookupTaxID.RSMTaxIDCode,
    Item.AgeRestriction,
    Item.InheritAgeRestric,
    SalesPack.ChainBarcode,
    SalesPack.ChainItemID,  
    SalesPack.UpdateRSM,
    Item.RSMNeedsNewID,
    Item.ItemTypeSubCode,
    SalesPack.ManualPrice  

FROM ((((((Item

INNER JOIN SalesPack
ON Item.ItemID = SalesPack.ItemID)

INNER JOIN Barcode
ON Item.ItemID = Barcode.ItemID
AND SalesPack.PackType = Barcode.PackType)

INNER JOIN LookupPackSize
ON Barcode.PackType = LookupPackSize.PackType)

INNER JOIN LookupTaxID
ON Item.VatRate = LookupTaxID.TaxID)

INNER JOIN LookupBarcodeType
ON Barcode.BCType = LookupBarcodeType.BCType)

LEFT OUTER JOIN SubCategory
ON Item.SubCategory = SubCategory.SubCategoryID)

WHERE (Barcode.SemiDeleted = 1)

OR ( Item.RSMNeedsNewID = 1 )

OR ( (1=1) {0} )

ORDER BY Item.ItemID, SalesPack.PackType

", sqlWhereClause);

            // load and return data
            DataTable table = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, db.Connection);
            adapter.Fill(table);
            return table;
        }
        #endregion

        #region METHOD: ExportITT
        public string ExportITT(DataTable table, bool update)
        {
            // get site code value
            string sitecode = AdminDataSet.SiteInformationDataTable.GetSiteCode();
            // get application version
            string version = Version.ExeVersion;
            //>>PN20200421
            bool DOSite = (db.GetConfigStringAsBool("DOVersion"));
            //<<PN20200421
            // write xml
            XmlTextWriter xml = null;
            try
            {
                #region Setup xml file
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");

                filenameITT = "";
                string filename = string.Format("ITT330{0}.xml", timestamp);
                string filepath = db.GetConfigString("NAXML_Export_Dir") + "\\" + filename;
                filepath = filepath.Replace("\\\\", "\\"); // make sure we don't have double backslashes
                
                // check if output dir exists

                string msgError = CheckExportDirsExists();
                if (msgError != "") return msgError;

                xml = new XmlTextWriter(filepath, Encoding.UTF8);

                #endregion

                #region Write ITT Header

                xml.Formatting = Formatting.Indented;
                xml.WriteStartDocument(false);
                
                xml.WriteStartElement("NAXML-MaintenanceRequest");
                xml.WriteAttributeString("version", "3.4");
                xml.WriteAttributeString("xmlns", "http://www.naxml.org/POSBO/Vocabulary/2003-10-16");
                xml.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            // xml.WriteAttributeString("xsi:schemaLocation", "http://www.naxml.org/POSBO/Vocabulary/2003-10-16 NAXML-PBIMaintenance33.xsd");
            // xml.WriteAttributeString("xsi:schemaLocation", "http://www.naxml.org/POSBO/Vocabulary/2003-10-16 NAXML-PBI34RadiantExtended.xsd");
             xml.WriteAttributeString("xsi:schemaLocation", "http://www.radiantsystems.com/NAXML-Extension NAXML-PBI34RadiantExtended.xsd");
        

                xml.WriteAttributeString("xmlns:radiant", "http://www.radiantsystems.com/NAXML-Extension");
                xml.WriteAttributeString("xmlns:xmime", "http://www.w3.org/2005/05/xmlmime");


                   xml.WriteStartElement("TransmissionHeader");
                xml.WriteElementString("StoreLocationID", sitecode);
                xml.WriteElementString("VendorName", "Dansk Retail Services");
                xml.WriteElementString("VendorModelVersion", version);
                xml.WriteEndElement();
                xml.WriteStartElement("ItemMaintenance");
                xml.WriteStartElement("TableAction");
                if (update)
                    xml.WriteAttributeString("type", "update");
                else
                    xml.WriteAttributeString("type", "initialize");
                xml.WriteEndElement();

                xml.WriteStartElement("RecordAction");
                xml.WriteAttributeString("type", "addchange");
                xml.WriteEndElement();

                #endregion

                // traversing dataset
                foreach (DataRow row in table.Rows)
                {
                    /// We loop the output of item records twice.
                    /// First time handles output of either item change,
                    /// item delete or item delete for chanigng itemid.
                    /// In first loop, it is always ItemID that is written.
                    /// Second time handles creating itemid after deleting
                    /// the item in first loop, that is itemid changed.
                    /// In second loop, it is always ExportID (ItemID or FSD_ID)
                    /// that is written.
                    bool loopTwice = false;
                    for (int outputloop = 0; outputloop < 2; outputloop++)
                    {
                        if ((outputloop == 0) || loopTwice)
                        //    ((outputloop == 1) && tools.object2bool(row["RSMNeedsNewID"])))
                        {
                            // if first loop, check for SemiDelete or RSMNeedsNewID,
                            // and if so, set the recordaction to delete
                            string recordaction = "addchange";
                            if ((outputloop == 0) &&
                                (tools.object2bool(row["SemiDeleted"]) ||
                                 tools.object2bool(row["RSMNeedsNewID"])))                           
                            {
                            recordaction = "delete";
                            }

                            // parse out AgeRestriction
                            bool ageRestrictionUsed = false;
                            if (row["AgeRestriction"] != DBNull.Value)
                            {
                                int loop = int.Parse(row["AgeRestriction"].ToString());
                                bool Inherited = tools.object2bool(row["InheritAgeRestric"]);
                                // we use age striction either if it between 10 and 99
                                // or if it is 0 and not inherited.
                                ageRestrictionUsed = (((loop >= 1) && (loop <= 99)) || ((loop == 0) && (!Inherited)));
                            }
                       
                            bool manualPrice = false;
                            manualPrice = tools.object2bool(row["ManualPrice"]);
                            // parse out ChainBarcode
                            bool chainbarcodeUsed =
                                ((row["ChainBarcode"] != DBNull.Value) && (row["ChainBarcode"].ToString() != "0"));                         
                            bool chainitemidcodeUsed =
                               ((row["ChainItemID"] != DBNull.Value) && (row["ChainItemID"].ToString() != "0"));

                            // parse out CreditCategory (required field in xml)
                            string creditcat = "0000";
                            if (row["CreditCategory"] != DBNull.Value)
                                creditcat = row["CreditCategory"].ToString();

                            // parse out sales price (must be with us decimal point
                            string salesprice = "0";
                            if (row["SalesPrice"] != DBNull.Value)
                                salesprice = tools.object2double(row["SalesPrice"]).ToString(".00").Replace(",",".");
                            // detail record start
                            xml.WriteStartElement("ITTDetail"); // ...

                            // detail record header
                            xml.WriteStartElement("RecordAction"); // ...
                            xml.WriteAttributeString("type", recordaction);
                            xml.WriteEndElement(); // ...RecordAction
                            // ItemCode
                            xml.WriteStartElement("ItemCode"); // ...
                            xml.WriteStartElement("POSCodeFormat"); // ...
                            xml.WriteAttributeString("format", "plu");
                            xml.WriteEndElement(); // ...POSCodeFormat   
                            int ItemID;//20200309                           
                            if ((outputloop == 0) && tools.object2bool(row["RSMNeedsNewID"]))
                            {
                                // changing id to exportid. this is the first
                                // loop, so delete is on the old itemid.                             

                                ItemID = tools.object2int(row["ItemID"]);
                                //PN20200421
                                //Se om vi kan finde Old_FSD_ID hvis ja sættes dette som ItemID                                
                                if ((DOSite) && (recordaction == "delete"))
                                {
                                    int Old_FSD_ID =
                                    tools.object2int(db.ExecuteScalar(string.Format(@"
                                    select Old_FSD_ID from Item
                                    where ItemID = {0}", ItemID)));
                                    if (Old_FSD_ID != 0)
                                        ItemID = Old_FSD_ID;
                                }
                                                                
                                loopTwice = true;
                            }
                            else
                            {
                                // this is either addchange, semidelete or
                                // second loop in changning id to exportid.
                                // in theese cases we output exportid.                           
                                ItemID = ItemDataSet.ItemDataTable.GetExportID(tools.object2int(row["ItemID"]));
                            }
                            xml.WriteElementString("POSCode", ItemID.ToString());
                            xml.WriteStartElement("POSCodeModifier"); // ...                                                                    
                            xml.WriteAttributeString("name", "Stk");
                            xml.WriteString("1");
                            xml.WriteEndElement(); // ...POSCodeModifier
                            xml.WriteEndElement(); // ...ItemCode
                            // prepare description for ITTData
                            string Description = row["ReceiptText"].ToString();
                            // ITTData
                            xml.WriteStartElement("ITTData"); // ...
                            xml.WriteStartElement("ActiveFlag"); // ...
                            xml.WriteAttributeString("value", "yes");
                            xml.WriteEndElement(); // ...ActiveFlag
                            xml.WriteElementString("MerchandiseCode", row["SubCategory"].ToString());
                            xml.WriteElementString("RegularSellPrice", salesprice);                          
                            xml.WriteElementString("Description", Description);                            
                            // 20210119
                          //  int ItemID;
                          if ((outputloop == 0) &&
                              !tools.object2bool(row["SemiDeleted"]) &&
                              tools.object2bool(row["RSMNeedsNewID"]))
                          //  if ((outputloop == 0) && tools.object2bool(row["RSMNeedsNewID"]))
                                    
                            {
                            // changing id to exportid. this is the first
                            // loop, so delete is on the old itemid.
                            ItemID = tools.object2int(row["ItemID"]);
                            loopTwice = true;
                            }
                            else
                            {
                                // this is either addchange, semidelete or
                                // second loop in changning id to exportid.
                                // in theese cases we output exportid.
                                ItemID = ItemDataSet.ItemDataTable.GetExportID(tools.object2int(row["ItemID"]));
                            }
                           // xml.WriteElementString("ItemID", ItemID.ToString());pn 20210218
                          //  20210119
                            xml.WriteStartElement("ItemType"); // ...
                            int ItemTypeCode = tools.object2int(row["ItemTypeCode"]);
                            if (ItemTypeCode == 0)
                            {
                                ItemTypeCode = 1;
                            }                           
                            xml.WriteElementString("ItemTypeCode", ItemTypeCode.ToString());
                            int ItemTypeSubCode = tools.object2int(row["ItemTypeSubCode"]);
                            if (ItemTypeSubCode == 0 )
                            {
                               ItemTypeSubCode = 1;
                            }
                            xml.WriteElementString("ItemTypeSubCode", ItemTypeSubCode.ToString());
                            
                            xml.WriteEndElement(); // ...ItemType
                                                  
                            if (chainitemidcodeUsed)
                            {
                                xml.WriteStartElement("LinkCode");
                                xml.WriteAttributeString("type", "itemList");                                
                                xml.WriteString(row["ChainItemID"].ToString());
                                xml.WriteEndElement();
                            }
                             xml.WriteElementString("PaymentSystemsProductCode", creditcat);
                            if (manualPrice)
                            {
                                xml.WriteElementString("SalesRestrictCode", "128");     

                            }
                            if (ageRestrictionUsed)
                            {
                                xml.WriteStartElement("SalesRestriction");
                                xml.WriteElementString("MinimumCustomerAge", row["AgeRestriction"].ToString());
                                xml.WriteEndElement();
                            }
                            xml.WriteElementString("SellingUnits", "1");
                            xml.WriteElementString("TaxStrategyID", row["RSMTaxIDCode"].ToString());
                          
                            xml.WriteEndElement(); // ...ITTData
                            //20190509 Peter lav  loop gennem barcodes
                            // ITTDetailExtension
                            xml.WriteStartElement("radiant:ITTDetailExtension"); // ...
                            int RBOSItemID = tools.object2int(row["ItemID"]);
                            DataTable Barcodes = ItemDataSet.BarcodeDataTable.GetBarcodeRecordsFromItemID(RBOSItemID);
                            foreach (DataRow BarcodeRow in Barcodes.Rows)
                            {
                                xml.WriteStartElement("ItemCode"); // ...
                                xml.WriteStartElement("POSCodeFormat"); // ...
                                xml.WriteAttributeString("format", BarcodeRow["BCType"].ToString());
                                xml.WriteEndElement(); // ...POSCodeFormat
                                xml.WriteElementString("POSCode", BarcodeRow["Barcode"].ToString());
                                xml.WriteStartElement("POSCodeModifier"); // ...                              
                                xml.WriteAttributeString("name", "Stk");
                                xml.WriteString(BarcodeRow["PackType"].ToString());
                                xml.WriteEndElement(); // ...POSCodeModifier
                                xml.WriteEndElement(); // ...ItemCode
                            }
                            xml.WriteElementString("radiant:RawPaymentSystemsProductCode", row["CreditCategory"].ToString());                           
                            xml.WriteEndElement(); // ...ITTDetailExtension
                            xml.WriteEndElement(); // ...ITTDetail
                        }
                    }
                }

                #region Finish ITT Header

                xml.WriteEndElement(); // ItemMaintenance

#if FSD
                /// Write supplier records (all suppliers).
                /// This is only done if BFI and if enabled in config.
                if (ExportSupplierItem)
                {
                    xml.WriteStartElement("Extension");
                    xml.WriteStartElement("radiant:SupplierMaintenance");

                    xml.WriteStartElement("TableAction");
                    xml.WriteAttributeString("type", "update");
                    xml.WriteEndElement(); // TableAction

                    xml.WriteStartElement("RecordAction");
                    xml.WriteAttributeString("type", "addchange");
                    xml.WriteEndElement(); // RecordAction

                    // output the supplier data
                    DataTable SupplierData = db.GetDataTable("select SupplierID, Description from Supplier");
                    foreach (DataRow SupplierRow in SupplierData.Rows)
                    {
                        xml.WriteStartElement("radiant:SupplierDetail");

                        xml.WriteStartElement("RecordAction");
                        xml.WriteAttributeString("type", "addchange");
                        xml.WriteEndElement(); // RecordAction

                        // make sure supplier does not contain invalid xml characters
                        string SupplierName = tools.object2string(SupplierRow["Description"]);

                        xml.WriteElementString("radiant:SupplierID", tools.object2string(SupplierRow["SupplierID"]));
                        xml.WriteElementString("radiant:SupplierName", SupplierName);

                        xml.WriteEndElement(); // radiant:SupplierDetail
                    }

                    xml.WriteEndElement(); // radiant:SupplierMaintenance
                    xml.WriteEndElement(); // Extension
                }
#endif

                xml.WriteEndElement(); // NAXML-MaintenanceRequest
                xml.WriteEndDocument();
                xml.Close();

                // save filename
                filenameITT = filename;

                // save a backup of the file, if backup is active
                if (db.GetConfigStringAsBool("NAXML_Export_Backup_Active"))
                    CopyFileToBackupDir(filepath);

                return ""; // ok
            }
            catch (Exception ex)
            {
                log.Write("Exception in Export.ExportITT():");
                log.Write("--------------------------------------------");
                log.Write("Message: " + ex.Message);
                log.Write("StackTrace: " + ex.StackTrace);
                log.Write("--------------------------------------------");

                return
                    "Exception in Export.ExportITT().\n" +
                    "Message: " + ex.Message + ".\n" +
                    "Please contact support.\n" +
                    "The logfile has more detailed information.\n" +
                    "Do not run the program before making a copy of the\n" +
                    "log file (located in the application folder";
            }
            finally
            {
                if(xml != null)
                    xml.Close();
            }

            #endregion
        }
        #endregion

        #region METHOD: ExportILT
        public string ExportILT(DataTable table, bool update)
        {

            string sql = "Select * from Item Where [ItemTypeCode] = 15";
            DataTable ILTtable = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, db.Connection);
            adapter.Fill(ILTtable);



            // get site code value
            string sitecode = AdminDataSet.SiteInformationDataTable.GetSiteCode();
            // get application version
            string version = Version.ExeVersion;

            // write xml
            XmlTextWriter xml = null;
            try
            {
                #region Setup xml file

                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string filename = string.Format("ILT334{0}.xml", timestamp);
                string filepath = db.GetConfigString("NAXML_Export_Dir") + "\\" + filename;
                filepath = filepath.Replace("\\\\", "\\"); // make sure we don't have double backslashes

                // check if output dir exists
                
                string msgError = CheckExportDirsExists();
                if (msgError != "") return msgError;

                xml = new XmlTextWriter(filepath, Encoding.UTF8);

                #endregion

                #region Write ITT Header

                xml.Formatting = Formatting.Indented;
                xml.WriteStartDocument(false);

                xml.WriteStartElement("NAXML-MaintenanceRequest");
                xml.WriteAttributeString("version", "3.4");
                xml.WriteAttributeString("xmlns", "http://www.naxml.org/POSBO/Vocabulary/2003-10-16");
                xml.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
             
                xml.WriteAttributeString("xsi:schemaLocation", "http://www.radiantsystems.com/NAXML-Extension NAXML-PBI34RadiantExtended.xsd");


                xml.WriteAttributeString("xmlns:radiant", "http://www.radiantsystems.com/NAXML-Extension");
                xml.WriteAttributeString("xmlns:xmime", "http://www.w3.org/2005/05/xmlmime");


                xml.WriteStartElement("TransmissionHeader");
                xml.WriteElementString("StoreLocationID", sitecode);
                xml.WriteElementString("VendorName", "Dansk Retail Services");
                xml.WriteElementString("VendorModelVersion", version);
                xml.WriteEndElement();
                xml.WriteStartElement("ItemListMaintenance");
                xml.WriteStartElement("TableAction");
                //xml.WriteAttributeString("type", "initialize"); //pn20200121
                xml.WriteAttributeString("type", "update");
                xml.WriteEndElement();

                xml.WriteStartElement("RecordAction");
                xml.WriteAttributeString("type", "addchange");
                xml.WriteEndElement();

                #endregion

                // traversing dataset
                foreach (DataRow row in ILTtable.Rows)
                {                    
                    // detail record start
                    xml.WriteStartElement("ILTDetail"); // ...
                    // detail record header
                    xml.WriteStartElement("RecordAction"); // ...
                    xml.WriteAttributeString("type", "addchange");
                    xml.WriteEndElement(); // ...RecordAction

                    xml.WriteStartElement("ItemListID"); // 20191101...

                    //if (row["FSD_ID"].ToString() != "") pn2020020
                    //    xml.WriteString(row["FSD_ID"].ToString());
                 
                    //else
                        xml.WriteString(row["ItemID"].ToString());

                    xml.WriteEndElement(); // ...ItemListID

                    //string Description = row["ReceiptText"].ToString();
                    xml.WriteStartElement("ItemListDescription"); // ...
                    xml.WriteString(row["ItemName"].ToString());
                    xml.WriteEndElement(); // ...ItemListDescription
                    // ItemCode
                    xml.WriteStartElement("ItemListEntry"); // ...
                    xml.WriteStartElement("ItemCode"); // ...
                    xml.WriteStartElement("POSCodeFormat"); // ...
                    xml.WriteAttributeString("format", "plu");
                    xml.WriteEndElement(); // ...POSCodeFormat
                    //xml.WriteElementString("POSCode", row["FSD_ID"].ToString());20191101
                    if (row["FSD_ID"].ToString() != "")
                        xml.WriteElementString("POSCode", row["FSD_ID"].ToString());
                    else
                        xml.WriteElementString("POSCode", row["ItemID"].ToString());
                    // xml.WriteEndElement(); // ...POSCode
                    xml.WriteStartElement("POSCodeModifier"); // ...                                                        
                    xml.WriteAttributeString("name", "Stk");
                    xml.WriteString("1");
                    xml.WriteEndElement(); // ...POSCodeModifier
                    xml.WriteEndElement(); // ...ItemCode
                    xml.WriteEndElement(); // ...ItemListEntry      
                    xml.WriteEndElement(); // ...ITT Detail     

                }                   
                
                #region Finish ILT Header
                xml.WriteEndElement(); // ItemMaintenance
                xml.WriteEndElement(); // NAXML-MaintenanceRequest
                xml.WriteEndDocument();
                xml.Close();

                // save filename
                filenameILT = filename;

                // save a backup of the file, if backup is active
                if (db.GetConfigStringAsBool("NAXML_Export_Backup_Active"))
                    CopyFileToBackupDir(filepath);

                return ""; // ok
            }
            catch (Exception ex)
            {
                log.Write("Exception in Export.ExportILT():");
                log.Write("--------------------------------------------");
                log.Write("Message: " + ex.Message);
                log.Write("StackTrace: " + ex.StackTrace);
                log.Write("--------------------------------------------");

                return
                    "Exception in Export.ExportILT().\n" +
                    "Message: " + ex.Message + ".\n" +
                    "Please contact support.\n" +
                    "The logfile has more detailed information.\n" +
                    "Do not run the program before making a copy of the\n" +
                    "log file (located in the application folder";
            }
            finally
            {
                if (xml != null)
                    xml.Close();
            }

            #endregion
        }
        #endregion

        #region METHOD: CreateMCTData
        public DataTable CreateMCTData()
        {
            string sql = @"

SELECT DISTINCT top 12
    1 as merch_level,
    DepartmentID as merch_id,
    Description as merch_desc,
    null as merch_parent,
    null as merch_vatrate,
    null as merch_creditcategory,
    null as merch_agerestriction
FROM Department

UNION

SELECT DISTINCT
    2 as merch_level,
    CategoryID as merch_id,
    Description as merch_desc,
    DepartmentID as merch_parent,
    null as merch_vatrate,
    null as merch_creditcategory,
    null as merch_agerestriction
FROM Category

UNION

SELECT DISTINCT
    3 as merch_level,
    SubCategoryID as merch_id,
    Description as merch_desc,
    CategoryID as merch_parent,
    LookupTaxID.RSMTaxIDCode as merch_vatrate,
    CreditCategory as merch_creditcategory,
    AgeRestriction as merch_agerestriction
FROM (SubCategory
INNER JOIN LookupTaxID
ON SubCategory.VatRate = LookupTaxID.TaxID)
WHERE SubCategory.NotActive <> 1;

";

            // load and return data
            DataTable table = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, db.Connection);
            adapter.Fill(table);
            return table;
        }
        #endregion

        #region METHOD: ExportMCT
        public string ExportMCT(DataTable table)
        {
            // load site code value
            string sitecode = AdminDataSet.SiteInformationDataTable.GetSiteCode();

            // get application version
            string version = Version.ExeVersion;

            // write xml
            XmlTextWriter xml = null;
            try
            {
                #region Setup xml file

                filenameMCT = "";
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string filename = string.Format("MCT330{0}.xml", timestamp);
                string filepath = db.GetConfigString("NAXML_Export_Dir") + "\\" + filename;
                filepath = filepath.Replace("\\\\", "\\"); // make sure we don't have double backslashes

                // check if output dir exists
                string msgError = CheckExportDirsExists();
                if (msgError != "") return msgError;

                xml = new XmlTextWriter(filepath, Encoding.UTF8);

                #endregion

                #region Write ITT Header

                xml.Formatting = Formatting.Indented;
                xml.WriteStartDocument(false);

                xml.WriteStartElement("NAXML-MaintenanceRequest");
                xml.WriteAttributeString("version", "3.3");
                xml.WriteAttributeString("xmlns", "http://www.naxml.org/POSBO/Vocabulary/2003-10-16");
                xml.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                xml.WriteAttributeString("xsi:schemaLocation", "http://www.naxml.org/POSBO/Vocabulary/2003-10-16 NAXML-PBIMaintenance33.xsd");

                xml.WriteStartElement("TransmissionHeader");
                xml.WriteElementString("StoreLocationID", sitecode);
                xml.WriteElementString("VendorName", "Dansk Retail Services");
                xml.WriteElementString("VendorModelVersion", version);
                xml.WriteEndElement();

                xml.WriteStartElement("MerchandiseCodeMaintenance");

                xml.WriteStartElement("TableAction"); // Only support sending whole Category structure
                xml.WriteAttributeString("type", "initialize");
                xml.WriteEndElement();

                xml.WriteStartElement("RecordAction");
                xml.WriteAttributeString("type", "delete");
                xml.WriteEndElement();

                #endregion

                // traversing dataset
                foreach (DataRow row in table.Rows)
                {
                    
                    // parse out AgeRestriction
                    bool ageRestrictionUsed = false;
                    if (row["merch_agerestriction"] != DBNull.Value)
                    {
                        int i = int.Parse(row["merch_agerestriction"].ToString());
                        ageRestrictionUsed = ((i >= 10) && (i <= 99));
                    }

                    // parse out CreditCategory (required field in xml)
                    string creditcat = "0000";
                    if (row["merch_creditcategory"] != DBNull.Value)
                        creditcat = row["merch_creditcategory"].ToString();
                    
                    
                    // detail record start
                    xml.WriteStartElement("MCTDetail"); // ...

                    // detail record header
                    xml.WriteStartElement("RecordAction"); // ...
                    xml.WriteAttributeString("type", "addchange");
                    xml.WriteEndElement(); // ...RecordAction

                    xml.WriteElementString("MerchandiseCode", row["merch_id"].ToString());
                    xml.WriteStartElement("ActiveFlag"); // ...
                    xml.WriteAttributeString("value", "yes");
                    xml.WriteEndElement(); // ...ActiveFlag
                    xml.WriteElementString("MerchandiseCodeDescription", row["merch_desc"].ToString());

                    
                    // Only for level 3 = SubCategory
                    if (row["Merch_level"].ToString() == "3")
                    {
                        xml.WriteElementString("PaymentSystemsProductCode", creditcat);
                        if (ageRestrictionUsed)
                        {
                            xml.WriteStartElement("SalesRestriction");
                            xml.WriteElementString("MinimumCustomerAge", row["merch_agerestriction"].ToString());
                            xml.WriteEndElement();
                        }
                        xml.WriteElementString("TaxStrategyID", row["merch_vatrate"].ToString());
                    }

                    xml.WriteStartElement("Extension");  // ...

                    xml.WriteElementString("MerchandiseCodeLevel", row["merch_level"].ToString());
                    // Department has no parent
                    if (row["Merch_level"].ToString() != "1")
                        xml.WriteElementString("ParentMerchandiseCode", row["merch_parent"].ToString());

                    xml.WriteEndElement(); // ...Extension

                    xml.WriteEndElement(); // ...MCTDetail
                }

                #region Finish ITT Header

                xml.WriteEndElement(); // MCTMaintenance
                xml.WriteEndElement(); // NAXML-MaintenanceRequest
                xml.WriteEndDocument();
                xml.Close();

                // save filename
                filenameMCT = filename;

                // save a backup of the file, if backup is active
                if (db.GetConfigStringAsBool("NAXML_Export_Backup_Active"))
                    CopyFileToBackupDir(filepath);

                return ""; // ok
            }
            catch (Exception ex)
            {
                log.Write("Exception in Export.ExportMCT():");
                log.Write("--------------------------------------------");
                log.Write("Message: " + ex.Message);
                log.Write("StackTrace: " + ex.StackTrace);
                log.Write("--------------------------------------------");

                return
                    "Exception in Export.ExportMCT().\n" +
                    "Message: " + ex.Message + ".\n" +
                    "Please contact support.\n" +
                    "The logfile has more detailed information.\n" +
                    "Do not run the program before making a copy of the\n" +
                    "log file (located in the application folder";
            }
            finally
            {
                if (xml != null)
                    xml.Close();
            }

                #endregion
        }
        #endregion

        #region METHOD: CreateTSMData
        public DataTable CreateTSMData()
        {
            string sql = @"
SELECT
    TaxID,
    TaxDescription as TaxReceiptDescription,
    TaxDescription as TaxStrategyDescription,
    TaxPct as TaxRate,
    RSMTaxIDCode as TaxLevelID,
    RSMTaxIDCode as TaxStrategyID,
    TaxSymbol
FROM LookupTaxID    
";

            // load and return data
            DataTable table = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, db.Connection);
            adapter.Fill(table);
            return table;
        }
        #endregion

        #region METHOD: ExportTSM
        public string ExportTSM(bool update)
        {
            XmlTextWriter xml = null;
            try
            {
                // setup xml file
                filenameTSM = "";
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string filename = string.Format("TSM330{0}.xml", timestamp);
                string filepath = db.GetConfigString("NAXML_Export_Dir") + "\\" + filename;
                filepath = filepath.Replace("\\\\", "\\"); // make sure we don't have double backslashes

                // check if output dir exists
                string msgError = CheckExportDirsExists();
                if (msgError != "") return msgError;

                // load xml file
                xml = new XmlTextWriter(filepath, Encoding.UTF8);

                // get site data
                string StoreLocationID = AdminDataSet.SiteInformationDataTable.GetSiteCode();
                string TaxRegistrationNumber = AdminDataSet.SiteInformationDataTable.GetSE();
                if (TaxRegistrationNumber == "")
                {
                    xml.Close();
                    tools.RemoveFileWriteProtection(filepath);
                    File.Delete(filepath);
                    return db.GetLangString("ExportRadiantForm.SEMissing");
                }
                string Owner = AdminDataSet.SiteInformationDataTable.GetSiteName();

                // get application version
                string VendorModelVersion = Version.ExeVersion;

                // write TSM Header

                xml.Formatting = Formatting.Indented;
                xml.WriteStartDocument(false);

                xml.WriteStartElement("NAXML-MaintenanceRequest");
                xml.WriteAttributeString("version", "3.3");
                xml.WriteAttributeString("xmlns", "http://www.naxml.org/POSBO/Vocabulary/2003-10-16");
                xml.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                xml.WriteAttributeString("xsi:schemaLocation", "http://www.naxml.org/POSBO/Vocabulary/2003-10-16 NAXML-PBIMaintenance33.xsd");

                xml.WriteStartElement("TransmissionHeader");
                xml.WriteElementString("StoreLocationID", StoreLocationID);
                xml.WriteElementString("VendorName", "Dansk Retail Services");
                xml.WriteElementString("VendorModelVersion", VendorModelVersion);
                xml.WriteEndElement();

                // load data for TaxStrategyManagement
                DataTable tableLevel = CreateTSMData();

                // traverse rows to output TaxLevelMaintenance
                foreach (DataRow rowLevel in tableLevel.Rows)
                {
                    // write TaxLevelMaintenance header

                    xml.WriteStartElement("TaxLevelMaintenance"); // ...
                    xml.WriteStartElement("TableAction");
                    if (update)
                        xml.WriteAttributeString("type", "update");
                    else
                        xml.WriteAttributeString("type", "initialize");
                    xml.WriteEndElement();
                    xml.WriteStartElement("RecordAction");
                    xml.WriteAttributeString("type", "addchange");
                    xml.WriteEndElement();

                    // detail record header
                    xml.WriteStartElement("TLTDetail"); // ...
                    xml.WriteStartElement("RecordAction"); // ...
                    xml.WriteAttributeString("type", "addchange");
                    xml.WriteEndElement(); // ...RecordAction

                    xml.WriteElementString("TaxLevelID", rowLevel["TaxLevelID"].ToString());
                    xml.WriteElementString("TaxTypeID", "1");
                    xml.WriteStartElement("TaxActiveFlag"); // ...
                    xml.WriteAttributeString("value", "yes");
                    xml.WriteEndElement(); // ...ActiveFlag
                    xml.WriteElementString("TaxReceiptDescription", rowLevel["TaxReceiptDescription"].ToString());
                    xml.WriteElementString("TaxRegistrationNumber", TaxRegistrationNumber);
                    xml.WriteElementString("TaxSymbol", rowLevel["TaxSymbol"].ToString());
                    xml.WriteElementString("TaxRate", rowLevel["TaxRate"].ToString());
                    xml.WriteStartElement("Extension");  // ...
                    xml.WriteElementString("Owner", Owner);
                    xml.WriteEndElement(); // ...Extension

                    xml.WriteEndElement(); // ...TLTDetail
                    xml.WriteEndElement(); // TaxLevelMaintenance
                }

                // traverse rows to output TaxStrategyMaintenance
                foreach (DataRow rowStrategy in tableLevel.Rows)
                {
                    // write TaxLevelMaintenance header

                    xml.WriteStartElement("TaxStrategyMaintenance"); // ...
                    xml.WriteStartElement("TableAction");
                    xml.WriteAttributeString("type", "update");
                    xml.WriteEndElement();
                    xml.WriteStartElement("RecordAction");
                    xml.WriteAttributeString("type", "addchange");
                    xml.WriteEndElement();

                    // detail record header
                    xml.WriteStartElement("TSTDetail"); // ...
                    xml.WriteStartElement("RecordAction"); // ...
                    xml.WriteAttributeString("type", "addchange");
                    xml.WriteEndElement(); // ...RecordAction

                    xml.WriteElementString("TaxStrategyID", rowStrategy["TaxStrategyID"].ToString());
                    xml.WriteElementString("TaxLevelID", rowStrategy["TaxLevelID"].ToString());
                    xml.WriteElementString("TaxStrategyDescription", rowStrategy["TaxStrategyDescription"].ToString());

                    xml.WriteEndElement(); // ...TSTDetail
                    xml.WriteEndElement(); // TaxStrategyMaintenance
                }

                // finish TSM tags
                xml.WriteEndElement(); // NAXML-MaintenanceRequest
                xml.WriteEndDocument();
                xml.Close();

                // save filename
                filenameTSM = filename;

                // save a backup of the file, if backup is active
                if (db.GetConfigStringAsBool("NAXML_Export_Backup_Active"))
                    CopyFileToBackupDir(filepath);

                return ""; // ok
            }
            catch (Exception ex)
            {
                log.Write("Exception in Export.ExportTSM():");
                log.Write("--------------------------------------------");
                log.Write("Message: " + ex.Message);
                log.Write("StackTrace: " + ex.StackTrace);
                log.Write("--------------------------------------------");

                return
                    "Exception in Export.ExportTSM().\n" +
                    "Message: " + ex.Message + ".\n" +
                    "Please contact support.\n" +
                    "The logfile has more detailed information.\n" +
                    "Do not run the program before making a copy of the\n" +
                    "log file (located in the application folder";
            }
            finally
            {
                if (xml != null)
                    xml.Close();
            }
        }
        #endregion

        #region METHOD: WriteSemaphoreFile
        public string WriteSemaphoreFile()
        {
            try
            {
                /// Write a temporary semaphore file with a list 
                /// of files that were exported (the ITT and MCT files).
                /// When done generating the file, it is renamed to the
                /// correct semaphore filename, so the semaphore is in effect.
                if ((filenameITT == "") && (filenameMCT == "") && (filenameTSM == "")) return ""; // nothing to do
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string filename = string.Format("SEM330{0}.tmp", timestamp); // tmp to start with
                string filepath = db.GetConfigString("NAXML_Export_Dir") + "\\" + filename;
                filepath = filepath.Replace("\\\\", "\\"); // make sure we don't have double backslashes
                XmlTextWriter sem = new XmlTextWriter(filepath, Encoding.UTF8);
                sem.Formatting = Formatting.Indented;
                sem.WriteStartDocument();
                sem.WriteStartElement("FileList");
                if (filenameITT != "")
                    sem.WriteElementString("File", filenameITT);
                if (filenameILT != "")
                    sem.WriteElementString("File", filenameILT);
                if (filenameMCT != "")
                    sem.WriteElementString("File", filenameMCT);
                if (filenameTSM != "")
                    sem.WriteElementString("File", filenameTSM);
                sem.WriteEndElement();
                sem.WriteEndDocument();
                sem.Close();
                filenameITT = "";
                filenameMCT = "";
                filenameTSM = "";
                string finalSemFilepath = filepath.Substring(0, filepath.Length - 3) + "xml";
                File.Move(filepath, finalSemFilepath); // rename to enable semaphore
                // save a backup of the file, if backup is active
                //if (db.GetConfigStringAsBool("NAXML_Export_Backup_Active"))
                //    CopyFileToBackupDir(finalSemFilepath);
                return ""; // ok
            }
            catch (Exception ex)
            {
                log.Write("Exception in Export.WriteSemaphoreFile():");
                log.Write("--------------------------------------------");
                log.Write("Message: " + ex.Message);
                log.Write("StackTrace: " + ex.StackTrace);
                log.Write("--------------------------------------------");

                return
                    "Exception in Export.WriteSemaphoreFile().\n" +
                    "Message: " + ex.Message + ".\n" +
                    "Please contact support.\n" +
                    "The logfile has more detailed information.\n" +
                    "Do not run the program before making a copy of the\n" +
                    "log file (located in the application folder";
            }
        }
        #endregion

        #region METHOD: CheckExportDirsExists
        /// <summary>
        /// Checks if the output directory given in config string
        /// NAXML_Export_Dir and NAXML_Export_Dir_Backup exists.
        /// Only checks for backup dir if NAXML_Export_Backup_Active is true.
        /// </summary>
        /// <returns>
        /// Returns an empty string if output dir found.
        /// If not found, the expected dir is returned.
        /// </returns>
        public string CheckExportDirsExists()
        {
            byte dirCount = 0;
            string msg = "";


            if (!Directory.Exists(db.GetConfigString("NAXML_Export_Dir")))
            {
                msg += db.GetConfigString("NAXML_Export_Dir") + "\n";
                ++dirCount;
            }

            if (db.GetConfigStringAsBool("NAXML_Export_Backup_Active"))
            {
                if (!Directory.Exists(db.GetConfigString("NAXML_Export_Dir_Backup")))
                {
                    msg += db.GetConfigString("NAXML_Export_Dir_Backup") + "\n";
                    ++dirCount;
                }
            }

            if (dirCount > 0)
            {
                string dir = db.GetLangString("ExportRSM.Directory");
                if (dirCount > 1) dir = db.GetLangString("ExportRSM.Directories");
                msg = string.Format(db.GetLangString("ExportRSM.ExportDoesNotExist"), dir) + "\n\n" + msg;
            }

            return msg;
        }
        #endregion

        #region METHOD: CopyFileToBackupDir
        // copies the file to the directory given in config string NAXML_export_dir_backup
        private void CopyFileToBackupDir(string file)
        {
            int idx = file.LastIndexOf("\\");
            if (idx >= 0)
            {
                string destFile = db.GetConfigString("NAXML_export_dir_backup") + file.Remove(0, idx);
                destFile = destFile.Replace("\\\\", "\\"); // make sure we don't have double backslashes
                File.Copy(file, destFile, true);
            }
        }
        #endregion
    }
}
