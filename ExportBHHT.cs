using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace RBOS
{
    class ExportBHHT
    {
        #region Private variables

        private string filenameBHI = "";

        #endregion

        #region PROPERTY: ErrorMessage
        private string errmsg = "";
        public string ErrorMessage
        {
            get { return errmsg; }
        }
        #endregion

        #region METHOD: ExportBHI
        public bool ExportBHI()
        {
            // write xml
            XmlTextWriter xml = null;
            ProgressForm progress = new ProgressForm(db.GetLangString("ExportBHHT.ExportToBHHTProgressHead"));
            try
            {
                progress.Show();

                // setup output path
                filenameBHI = "";
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string filename = string.Format("BHI330{0}.xml", timestamp);
                string filepath = db.GetConfigString("BHHT_Export_Dir") + "\\" + filename;
                filepath = filepath.Replace("\\\\", "\\"); // make sure we don't have double backslashes

                // check if output dir exists
                if(!CheckExportDirsExists())
                    return false;

                // create and setup XML file
                xml = new XmlTextWriter(filepath, Encoding.UTF8);
                xml.Formatting = Formatting.Indented;
                xml.WriteStartDocument(false);

                // XML header
                xml.WriteStartElement("BHHTImport");
                xml.WriteAttributeString("xmlns", "http://www.radiantsystems.com/BatchHHT");
                xml.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                xml.WriteAttributeString("xsi:schemaLocation", "http://www.radiantsystems.com/BatchHHT BHHTImport.xsd");


                // traversing all LookupPackSize rows to output UOM nodes
                foreach (DataRow row in this.LookupPackSize().Rows)
                {
                    progress.StatusText = "PackType: " + row["PackTypeName"].ToString();
                    xml.WriteStartElement("UOM"); // ...
                    xml.WriteElementString("UOMId", row["PackType"].ToString());
                    xml.WriteElementString("Name", row["PackTypename"].ToString());
                    xml.WriteEndElement(); // ...UOM
                }
                // traversing all LookupKolliSize rows to output further UOM nodes
                foreach (DataRow row in this.LookupKolliSize().Rows)
                {
                    progress.StatusText = "BHHTID: " + row["Description"].ToString();
                    xml.WriteStartElement("UOM"); // ...
                    xml.WriteElementString("UOMId", row["BHHTID"].ToString());
                    xml.WriteElementString("Name", row["Description"].ToString());
                    xml.WriteEndElement(); // ...UOM
                }

                #region outputting Items
                
                // traversing all Item rows to output InventoryItem
                foreach (DataRow rowItem in this.ItemTable().Rows)
                {
                    progress.StatusText = "Item: " + rowItem["ItemName"].ToString();
                                        
                    xml.WriteStartElement("InventoryItem"); // ...
                    xml.WriteElementString("ItemId", ItemDataSet.ItemDataTable.GetExportID(tools.object2int(rowItem["ItemID"])).ToString());
                    xml.WriteElementString("Name", rowItem["ItemName"].ToString());
                    xml.WriteElementString("ItemCategoryId", rowItem["Subcategory"].ToString());
                    xml.WriteElementString("AllowFractional", "false");
                    
                    // loop salespack
                    int itemID = tools.object2int(rowItem["ItemID"]);
                    foreach (DataRow rowSalesPack in this.SalesPack(itemID).Rows)
                    {
                        // parse out sales price 
                        string salesprice = "0";
                        if (rowSalesPack["SalesPrice"] != DBNull.Value)
                            salesprice = double.Parse(rowSalesPack["SalesPrice"].ToString()).ToString("0.00").Replace(",", ".");
                        
                        xml.WriteStartElement("InventoryItemRetailPackList"); // ...
                        xml.WriteElementString("UOMId", rowSalesPack["PackType"].ToString());
                        xml.WriteElementString("Name", rowSalesPack["ReceiptText"].ToString());
                        xml.WriteElementString("RetailPrice", salesprice );

                        // loop barcode
                        foreach (DataRow rowBarcode in this.Barcode(itemID, tools.object2byte(rowSalesPack["PackType"])).Rows)
                        {
                            xml.WriteStartElement("InventoryItemBarcodeList"); // ...
                            xml.WriteElementString("Barcode", rowBarcode["Barcode"].ToString());
                            xml.WriteEndElement(); // ...InventoryItemBarcodeList
                        }
                                             
                        xml.WriteEndElement(); // ...InventoryItemRetailPackList
                    }

                    xml.WriteEndElement(); // ...InventoryItem
                }
                #endregion

                #region outputting Worksheets

                // traversing all Worksheet rows to output InventoryWS
                foreach (DataRow row in this.WorksheetTable().Rows)
                {
                    progress.StatusText = "Worksheet: " + row["Name"].ToString();
                    int WSID = tools.object2int(row["ID"]);

                    // write worksheet header
                    xml.WriteStartElement("InventoryWS"); // ...
                    xml.WriteElementString("WorksheetId", row["ID"].ToString());
                    xml.WriteElementString("Name", row["Name"].ToString());
                    xml.WriteElementString("Type", row["Type"].ToString());
                    xml.WriteElementString("IncludeCode", row["Include"].ToString());

                    // write worksheet catlist details
                    foreach(DataRow rowCategory in WSCatListTable(WSID).Rows)
                    {
                        xml.WriteStartElement("InventoryWSCategoryList"); // ...
                        xml.WriteElementString("ItemCategoryId", rowCategory["SubCategoryID"].ToString());
                        xml.WriteEndElement();
                    }

                    // write worksheet itemlist details
                    foreach (DataRow rowItem in WSItemListTable(WSID).Rows)
                    {
                        xml.WriteStartElement("InventoryWSItemList");
                        xml.WriteElementString("ItemId", ItemDataSet.ItemDataTable.GetExportID(tools.object2int(rowItem["ItemId"])).ToString());
                        xml.WriteEndElement();
                    }

                    // end the worksheet
                    xml.WriteEndElement(); //... InventoryWS
                }

                #endregion

                #region outputting SupplierItems

                // traversing all Supplier rows to output InventoryItem
                foreach (DataRow rowSupplier in this.SupplierAll().Rows)
                {
                    int supplID = tools.object2int(rowSupplier["SupplierID"]);

                    xml.WriteStartElement("Supplier"); // ...
                    xml.WriteElementString("SupplierId", rowSupplier["SupplierID"].ToString());
                    xml.WriteElementString("Name", rowSupplier["Description"].ToString());
                    xml.WriteElementString("HideCost", "false");
                    xml.WriteElementString("AllowFractional", "false");

                    // loop supplierItems
                    foreach (DataRow rowSuppItem in this.SupplierItem(supplID).Rows)
                    {
                        // parse out cost price (3 decimals)
                        string costprice = "0";
                        if (rowSuppItem["PackageCost"] != DBNull.Value)
                            costprice = double.Parse(rowSuppItem["PackageCost"].ToString()).ToString("0.000").Replace(",", ".");

                        // get UOMId
                        int KolliSize = tools.object2int(rowSuppItem["KolliSize"]);
                        int UOMId = LookupBHHTID(KolliSize);

                        progress.StatusText = string.Format(
                            "Supplier : {0} Orderingnumber : {1} ",
                            rowSupplier["Description"].ToString(),
                            rowSuppItem["OrderingNumber"].ToString());

                        xml.WriteStartElement("SupplierItemList"); // ...
                        xml.WriteElementString("SupplierItemId", rowSuppItem["ID"].ToString());
                        xml.WriteElementString("Name", rowSuppItem["ItemName"].ToString());
                        xml.WriteElementString("ShipperFlag", "false");

                        xml.WriteStartElement("SupplierItemUOMList"); // ...
                        xml.WriteElementString("UOMId", UOMId.ToString());
                        xml.WriteElementString("ProductCode", rowSuppItem["OrderingNumber"].ToString());
                        xml.WriteElementString("Cost", costprice);

                        // loop Selling Barcodes for SupplierItem ItemID + Packtype
                        foreach (DataRow rowBarcode in this.Barcode(tools.object2int(rowSuppItem["ItemID"]), 
                                                                    tools.object2byte(rowSuppItem["SellingPackType"])).Rows)
                        {
                            xml.WriteStartElement("SupplierItemUOMBarcodeList"); // ...
                            xml.WriteElementString("Barcode", rowBarcode["Barcode"].ToString());
                            xml.WriteEndElement(); // ...SupplierItemUOMBarcodeList
                        }
                                                
                        xml.WriteEndElement(); // ...SupplierItemUOMList
                        xml.WriteEndElement(); // ...SupplierItemList
                    }

                    xml.WriteEndElement(); // ...Supplier

                }

                #endregion

                // end off XML
                xml.WriteEndElement(); // BHHTImport
                xml.WriteEndDocument();
                xml.Close();

                // save filename
                filenameBHI = filename;

                // save a backup of the file, if backup is active
                if (db.GetConfigStringAsBool("BHHT_Export_Backup_Active"))
                    CopyFileToBackupDir(filepath);
                
                // write semaphore file
                if (!WriteSemaphoreFile())
                    return false;

                return true; // ok
            }
            catch (Exception ex)
            {
                log.Write("Exception in RBOS.export.ExportBHHT.ExportBHI():");
                log.Write("--------------------------------------------");
                log.Write("Message: " + ex.Message);
                log.Write("StackTrace: " + ex.StackTrace);
                log.Write("--------------------------------------------");

                errmsg =
                    "Exception in RBOS.export.ExportBHHT.ExportBHI().\n" +
                    "Message: " + ex.Message + ".\n" +
                    "Please contact support.\n" +
                    "The logfile has more detailed information.\n" +
                    "Do not run the program before making a copy of the\n" +
                    "log file (located in the application folder";
                return false;
            }
            finally
            {
                if (xml != null)
                    xml.Close();
                if (progress != null)
                    progress.Close();
            }
        }
        #endregion
        public bool ExportDelfi()
        {
            //Pn20200617
            // dan 4 filer
            if (!CheckDelfiExportDirsExists())
            {
                MessageBox.Show("Folder findes ikke");
              
            }
                ProgressForm progress = new ProgressForm(db.GetLangString("ExportBHHT.ExportToBHHTProgressHead"));
            try
            {
                progress.Show();
                #region BT_Tfilter.dat
                // setup output path

                string filename = "BT_Tfilter.dat";
                string filepath = db.GetConfigString("Delfi_Export_Dir") + "\\" + filename;
                filepath = filepath.Replace("\\\\", "\\"); // make sure we don't have double backslashes
             
                StreamWriter writer = new StreamWriter(filepath, false);
                foreach (DataRow row in this.BHHTWorksheet().Rows)
                {

                    writer.WriteLine(string.Format("{0,-3}{1,-20}",
                       row["ID"].ToString(), row["Name"].ToString()));

                    progress.StatusText = " " + row["Name"].ToString();
                   
                }

                writer.WriteLine(string.Format("{0,-3}{1,-20}",
                       "99", "Totalstatus"));
                writer.Close();
                #endregion

                #region BT_TfilterLinjer.dat
                filename = "BT_TfilterLinjer.dat";
                filepath = db.GetConfigString("Delfi_Export_Dir") + "\\" + filename;
                filepath = filepath.Replace("\\\\", "\\"); // make sure we don't have double backslashes

                writer = new StreamWriter(filepath, false);
                foreach (DataRow row in this.LookupCatList().Rows)
                {

                    writer.WriteLine(string.Format("{0,-3}{1,-10}{2,-30}",
                       row["WSID"].ToString(), row["SubCategoryID"].ToString(), row["Descr"].ToString()));

                    progress.StatusText = " " + row["Descr"].ToString();

                }

                writer.WriteLine(string.Format("{0,-3}{1,-10}{1,-30}",
                       "99", "99", "Totalstatus"));
                writer.Close();
                #endregion

                #region BT_Varegrp.dat
                filename = "BT_Varegrp.dat";
                filepath = db.GetConfigString("Delfi_Export_Dir") + "\\" + filename;
                filepath = filepath.Replace("\\\\", "\\"); // make sure we don't have double backslashes

                writer = new StreamWriter(filepath, false);
                foreach (DataRow row in this.LookupSubcategory().Rows)
                {

                    writer.WriteLine(string.Format("{0,-10}{1,-25}",
                       row["SubCategoryID"].ToString(), row["Description"].ToString()));

                    progress.StatusText = " " + row["Description"].ToString();

                }
                writer.Close();

                #endregion

                #region BT_Varekatalog.dat
                int AntalUger = db.GetConfigStringAsInt("Delfi_AntalUger");

                
                                   //først finder vi ud af om der overhoved er salg i perioden 
                DayOfWeek weekStart = DayOfWeek.Monday; // or Sunday, or whenever
                DateTime startingDate = DateTime.Today;
                DateTime[] WeekStartArray = new DateTime[8];
                DateTime[] WeekEndArray = new DateTime[8];

                while (startingDate.DayOfWeek != weekStart)
                    startingDate = startingDate.AddDays(-1);

                WeekStartArray[0] = startingDate.AddDays(-7 );
                WeekEndArray[0] =  startingDate.AddDays(-1);


                for (int ugeloop = 1; ugeloop < AntalUger; ugeloop++)
                {
                    WeekStartArray[ugeloop] = WeekStartArray[ugeloop - 1].AddDays(-7);
                    WeekEndArray[ugeloop] = WeekEndArray[ugeloop - 1].AddDays(-7);


                }

                                   
                DataTable VareAktiv = new DataTable();
                List<String> list = new List<String>();
                if (AntalUger > 0)
                {
                    string sql = string.Format(@"  Select distinct(t1.ItemId) FROM ItemTransaction  as t1 join SupplierItem as t2 on t1.ItemID = t2.ItemID " +
                    "Where t1.TransactionType = 1  And t1.PostingDate Between  {0} And {1}  And t2.SupplierNo = 12",
                    tools.datetime4sql(WeekStartArray[AntalUger - 1]), tools.datetime4sql(WeekEndArray[0]));
                                       
                    OleDbDataAdapter adapter = new OleDbDataAdapter(sql, db.Connection);
                    adapter.SelectCommand.Transaction = db.CurrentTransaction;
                    adapter.Fill(VareAktiv);
                   
                    foreach (DataRow dr in VareAktiv.Rows)
                    {
                        list.Add(dr[0].ToString());
                    }

                }


                filename = "BT_Varekatalog.dat";
                filepath = db.GetConfigString("Delfi_Export_Dir") + "\\" + filename;
                filepath = filepath.Replace("\\\\", "\\"); // make sure we don't have double backslashes
                int AntalMedSalg = 0;
                writer = new StreamWriter(filepath, false);
                Regex rgx = new Regex("[^a-zA-Z0-9 - . , Æ æ Ø ø Å å]");
                foreach (DataRow row in this.LookupBarcode().Rows)
                {
                    //fjern ulovlige karakter fra item name 20201027                  
                    String ItemName = row["ItemName"].ToString();
                                      
                    ItemName = rgx.Replace(ItemName, "");

                    //flag der viser om det er retain vare
        
                    int RetainItem = (tools.object2int(db.ExecuteScalar(string.Format(@"
                    select count(*) from [SupplierItem] Where SupplierNo = 12 And ItemID = {0} ", tools.object2double(row["ItemID2"].ToString())))));
                    if (RetainItem > 1)
                        RetainItem = 1;
                    int[] UgeSalg  = new int[8];
                    if ((AntalUger != 0) &&(RetainItem != 0))
                    {
                                                
                        bool Aktiv  = list.Contains(row["ItemID2"].ToString());
                        if (Aktiv )
                        {
                            AntalMedSalg++;
                            for (int ugeloop = 0; ugeloop < AntalUger; ugeloop++)
                            {
                                                          
                                UgeSalg[ugeloop] = tools.object2int(db.ExecuteScalar(string.Format(@" 
                                    Select Sum(NumberOf) from ItemTransaction Where ItemID = {0} And TransactionType = 1  And PostingDate Between {1} And {2}  ",
                                
                                     tools.object2double(row["ItemID2"].ToString()), tools.datetime4sql(WeekStartArray[ugeloop]), tools.datetime4sql(WeekEndArray[ugeloop]))));

                                UgeSalg[ugeloop] = UgeSalg[ugeloop] * -1;

                            }
                        }
                    }



                    writer.WriteLine(string.Format("{0,-10}{1,-20}{2,-50}{3,-10}{4,-9}{5,-1}{6,-5}{7,-5}{8,-5}{9,-5}{10,-5}{11,-5}{12,-5}{13,-5}",
                       row["ItemID"].ToString(),
                       row["Barcode"].ToString(),
                       ItemName,
                       row["SalesPrice"].ToString(),
                       row["SubCategory"].ToString(),
                       RetainItem.ToString(),
                       UgeSalg[0].ToString(),
                       UgeSalg[1].ToString(),
                       UgeSalg[2].ToString(),
                       UgeSalg[3].ToString(),
                       UgeSalg[4].ToString(),
                       UgeSalg[5].ToString(),
                       UgeSalg[6].ToString(),
                       UgeSalg[7].ToString()
                       ));

                    progress.StatusText = " " + row["ItemName"].ToString();

                }
                writer.Close();

                #endregion



                return true; // ok
            }
            catch (Exception ex)
            {
                log.Write("Exception in RBOS.export.ExportBHHT.ExportBHI():");
                log.Write("--------------------------------------------");
                log.Write("Message: " + ex.Message);
                log.Write("StackTrace: " + ex.StackTrace);
                log.Write("--------------------------------------------");

                errmsg =
                    "Exception in RBOS.export.ExportBHHT.ExportBHI().\n" +
                    "Message: " + ex.Message + ".\n" +
                    "Please contact support.\n" +
                    "The logfile has more detailed information.\n" +
                    "Do not run the program before making a copy of the\n" +
                    "log file (located in the application folder";
                return false;
            }
            finally
            {
               
                if (progress != null)
                    progress.Close();
            }
        }
        #region METHOD: WriteSemaphoreFile
        private bool WriteSemaphoreFile()
        {
            try
            {
                /// Write a temporary semaphore file with a list 
                /// of files that were exported (actually only one BHI file).
                /// When done generating the file, it is renamed to the
                /// correct semaphore filename, so the semaphore is in effect.
                if (filenameBHI == "") return false; // nothing to do
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string filename = string.Format("SEM330{0}.tmp", timestamp); // tmp to start with
                string filepath = db.GetConfigString("BHHT_Export_Dir") + "\\" + filename;
                filepath = filepath.Replace("\\\\", "\\"); // make sure we don't have double backslashes
                XmlTextWriter sem = new XmlTextWriter(filepath, Encoding.UTF8);
                sem.Formatting = Formatting.Indented;
                sem.WriteStartDocument();
                sem.WriteStartElement("FileList");
                if (filenameBHI != "")
                    sem.WriteElementString("File", filenameBHI);
                sem.WriteEndElement();
                sem.WriteEndDocument();
                sem.Close();
                filenameBHI = "";
                string finalSemFilepath = filepath.Substring(0, filepath.Length - 3) + "xml";
                File.Move(filepath, finalSemFilepath); // rename to enable semaphore
                // save a backup of the file, if backup is active
                if (db.GetConfigStringAsBool("BHHT_Export_Backup_Active"))
                    CopyFileToBackupDir(finalSemFilepath);
                return true; // ok
            }
            catch (Exception ex)
            {
                log.Write("Exception in Export.WriteSemaphoreFile():");
                log.Write("--------------------------------------------");
                log.Write("Message: " + ex.Message);
                log.Write("StackTrace: " + ex.StackTrace);
                log.Write("--------------------------------------------");

                errmsg =
                    "Exception in Export.WriteSemaphoreFile().\n" +
                    "Message: " + ex.Message + ".\n" +
                    "Please contact support.\n" +
                    "The logfile has more detailed information.\n" +
                    "Do not run the program before making a copy of the\n" +
                    "log file (located in the application folder";
                return false;
            }
        }
        #endregion

        #region METHOD: CopyFileToBackupDir
        // copies the file to the directory given in config string BHHT_export_dir_backup
        private void CopyFileToBackupDir(string file)
        {
            int idx = file.LastIndexOf("\\");
            if (idx >= 0)
            {
                string destFile = db.GetConfigString("BHHT_export_dir_backup") + file.Remove(0, idx);
                destFile = destFile.Replace("\\\\", "\\"); // make sure we don't have double backslashes
                File.Copy(file, destFile, true);
            }
        }
        #endregion

        #region METHOD: CheckExportDirsExists
        /// <summary>
        /// Checks if the output directory given in config string
        /// BHHT_Export_Dir and BHHT_Export_Dir_Backup exists.
        /// Only checks for backup dir if BHHT_Export_Backup_Active is true.
        /// </summary>
        /// <returns>
        /// Returns an empty string if output dir found.
        /// If not found, the expected dir is returned.
        /// </returns>
        public bool CheckExportDirsExists()
        {
            byte dirCount = 0;
            errmsg = "";

            if (!Directory.Exists(db.GetConfigString("BHHT_Export_Dir")))
            {
                errmsg += db.GetConfigString("BHHT_Export_Dir") + "\n";
                ++dirCount;
            }

            if (db.GetConfigStringAsBool("BHHT_Export_Backup_Active"))
            {
                if (!Directory.Exists(db.GetConfigString("BHHT_Export_Dir_Backup")))
                {
                    errmsg += db.GetConfigString("BHHT_Export_Dir_Backup") + "\n";
                    ++dirCount;
                }
            }

            if (dirCount > 0)
            {
                string dir = db.GetLangString("ExportBHHT.Directory");
                if (dirCount > 1) dir = db.GetLangString("ExportBHHT.Directories");
                errmsg = string.Format(db.GetLangString("ExportBHHT.ExportDirDoesNotExist") + "\n\n", dir) + errmsg;
            }

            return (errmsg == "");
        }
        #endregion
        public bool CheckDelfiExportDirsExists()
        {
            
           

            if (!Directory.Exists(db.GetConfigString("Delfi_Export_Dir")))           
               return (false);
            else
                return (true);




        }

        #region METHOD: ItemTable
        private DataTable ItemTable()
        {
            string sql = " SELECT ItemID, ItemName, SubCategory FROM Item ";
            return CreateTable(sql);
        }
        #endregion

        #region METHOD: WorksheetTable
        private DataTable WorksheetTable()
        {
            string sql = " select * from BHHTWorksheet ";
            return CreateTable(sql);
        }
        #endregion

        #region METHOD: WSCatListTable
        private DataTable WSCatListTable(int WSID)
        {

            string sql = " select * from BHHTWSCatList where WSID = " + WSID.ToString();
            return CreateTable(sql);
        }
        #endregion

        #region METHOD: WSItemListTable
        private DataTable WSItemListTable(int WSID)
        {
            string sql = " select * from BHHTWSItemList where WSID = " + WSID.ToString();
            return CreateTable(sql);
        }
        #endregion

        #region METHOD: LookupPackSize
        private DataTable LookupPackSize()
        {
            string sql = " select PackType, PackTypeName from LookupPackSize ";
            return CreateTable(sql);
        }
        #endregion

        #region METHOD: LookupKolliSize
        private DataTable LookupKolliSize()
        {
            string sql = " select BHHTID, Description from LookupKolliSize ";
            return CreateTable(sql);
        }
        #endregion

        #region METHOD: LookupSubcategory
        private DataTable LookupSubcategory()
        {
            string sql = "Select SubCategoryID, [Description]  from SubCategory Where HideInLookup <> 1 And NotActive <> 1";
            return CreateTable(sql);
        }
        #endregion


      

#region METHOD: LookupBarcode
        private DataTable LookupBarcode()
        {          
         
            string sql = " Select Case When t2.FSD_ID is not null Then t2.FSD_ID else T2.ItemID End AS 'ItemID', t1.Barcode , t2.ItemName,T2.ItemID AS 'ItemID2' , " +
                 
        "Replace(cast(t3.SalesPrice as decimal(10, 2)), '.', ',') As 'SalesPrice'," 
               + "t2.SubCategory from Barcode as t1 "
            + " join Item as t2  on t1.ItemID = t2.ItemID join SalesPack as t3 on t1.ItemID = t3.ItemID";

            return CreateTable(sql);
        }
        #endregion

        #region METHOD: LookupCatList
        private DataTable LookupCatList()
        {
            string sql = "SELECT t1.[WSID], t1.[SubCategoryID],t2.[Description] as 'Descr' FROM[BHHTWSCatList] as t1 " 
                + "join SubCategory as t2 on t1.SubCategoryID = t2.SubCategoryID Order By T1.WSID, T1.SubCategoryID";
        
            return CreateTable(sql);
        }
        #endregion

        #region METHOD: BHHTWorksheet
        private DataTable BHHTWorksheet()
        {
            string sql = "SELECT  [ID],[Name]  FROM [BHHTWorksheet] Where [Include] <> 'a'";
            return CreateTable(sql);
        }
        #endregion

        #region METHOD: SalesPack
        private DataTable SalesPack(int ItemID)
        {
            string sql = string.Format(
                " select * from SalesPack where ItemID = {0} ", ItemID);
            return CreateTable(sql);
        }
        #endregion

        #region METHOD: Barcode
        private DataTable Barcode(int ItemID, int PackType)
        {
            string sql = string.Format(
                " select * from Barcode " +
                " where (ItemID = {0}) and (PackType = {1}) ",
                ItemID, PackType);
            return CreateTable(sql);
        }
        #endregion

        #region METHOD: Supplier
        private DataTable SupplierAll()
        {
            string sql = " select SupplierID, Description from Supplier ";
            return CreateTable(sql);
        }


        #endregion

        #region METHOD: SupplierItem
        private DataTable SupplierItem(int SupplierID)
        {
            string sql = string.Format(@"
select SupplierItem.*, Item.ItemName
from SupplierItem 
inner join Item
on SupplierItem.ItemID = Item.ItemID
Where InActiveDate > GetDate() Or InActiveDate is null
And SupplierNo = {0}
", SupplierID);
            return CreateTable(sql);
        }


        #endregion

        #region METHOD: LookupBHHTID
        /// <summary>
        /// Looks up the BHHTID in table LookupKolliSize
        /// that has the corresponding KolliSize.
        /// </summary>
        /// <param name="KolliSize">The KolliSize to find.</param>
        /// <returns>The found BHHTID or 0 if not found.</returns>
        public int LookupBHHTID(int KolliSize)
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.CommandText = string.Format(
                " select BHHTID from LookupKolliSize " +
                " where KolliSize = {0} ",
                KolliSize);
            return tools.object2int(cmd.ExecuteScalar());
        }
        #endregion

        #region METHOD: CreateTable
        // helper method
        private DataTable CreateTable(string sql)
        {
            DataTable table = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, db.Connection);
            adapter.Fill(table);
            return table;
        }
        #endregion
    }
}
