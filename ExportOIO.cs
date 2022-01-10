using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Data;
using System.Data.OleDb;
namespace RBOS
{
    class ExportOIO
    {
        #region Private variables

        private string filenameITT = "";
        private string filenameMCT = "";
        private string filenameTSM = "";
        private string filenameILT = "";

        #endregion

        #region METHOD: CreateOIOData
       
        public DataTable CreateOIOData( int OrderID)
        {
            string sql = string.Format(@"


SELECT t1.[OrderID],t1.[SuppItemID],t1.[OrderingNumber],t1.[KolliSize],
                t1.[PackType] ,t1.[ReceiptText],t1.[Cost],t1.[Quantity] as Qty,t2.DeliveryDate as Deldate,t3.ItemID as ItemID,t4.Barcode as barcode
                FROM[dbo].[OrderDetails] as t1 Join OrderHeader As t2 on t1.[OrderID]  = t2.OrderID
				join [dbo].[SupplierItem] as t3 on t1.OrderingNumber = t3.OrderingNumber
				left join Barcode AS t4 on t3.ItemID = t4.ItemID
				Where t2.OrderID = {0} and t4.PackType=t1.PackType", OrderID);
             
            // load and return data
            DataTable table = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, db.Connection);
            adapter.Fill(table);
            return table;
        }
        #endregion

        #region METHOD: ExportOIOData
        public string ExportOIOData(DataTable table,string filepath)
        {
            // get site code value
            string sitecode = AdminDataSet.SiteInformationDataTable.GetSiteCode();
            // get application version
            string version = Version.ExeVersion;

            // write xml
            XmlTextWriter xml = null;
            try
            {
                #region Setup xml file
                               
                

                // check if output dir exists

                //string msgError = CheckExportDirsExists();
                //if (msgError != "") return msgError;

                xml = new XmlTextWriter(filepath, Encoding.UTF8);

                #endregion

                #region Write OIO Header
                DataRow row1 = table.Rows[0];
                xml.Formatting = Formatting.Indented;
                xml.WriteStartDocument(false);               
              
                xml.WriteStartElement("Order");
                xml.WriteAttributeString("xsi:schemaLocation", "urn:oasis:names:specification:ubl:schema:xsd:Order-2 UBL-Order-2.0.xsd");

                xml.WriteAttributeString("xmlns", "urn:oasis:names:specification:ubl:schema:xsd:Order-2" );
                xml.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");                              

                xml.WriteAttributeString("xmlns:cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
                xml.WriteAttributeString("xmlns:cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
                xml.WriteAttributeString("xmlns:udt", "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2");
                xml.WriteAttributeString("xmlns:ccts", "urn:oasis:names:specification:ubl:schema:xsd:CoreComponentParameters-2");
                xml.WriteAttributeString("xmlns:sdt", "urn:oasis:names:specification:ubl:schema:xsd:SpecializedDatatypes-2");
                xml.WriteElementString("cbc:UBLVersionID", "2.0");
                xml.WriteElementString("cbc:CustomizationID", "OIOUBL-2.02");
                xml.WriteStartElement("cbc:ProfileID");
                    xml.WriteAttributeString("schemeAgencyID", "320");
                    xml.WriteAttributeString("schemeID", "urn:oioubl:id:profileid-1.2");
                    xml.WriteString("urn:www.nesubl.eu:profiles:profile5:ver2.0");
                xml.WriteEndElement();
                xml.WriteElementString("cbc:ID", tools.object2string(row1["OrderID"]));
                xml.WriteElementString("cbc:CopyIndicator", "false");
                xml.WriteElementString("cbc:UUID", tools.object2string(Guid.NewGuid()));
                xml.WriteElementString("cbc:IssueDate", DateTime.Now.ToShortDateString());
                xml.WriteElementString("cbc:IssueTime", DateTime.Now.ToShortTimeString());
                xml.WriteElementString("cbc:DocumentCurrencyCode", "DKK");
                xml.WriteStartElement("cac:BuyerCustomerParty");
                    xml.WriteElementString("cbc:CustomerAssignedAccountID", sitecode);
                    xml.WriteStartElement("cac:Party");
                        xml.WriteStartElement("cbc:EndpointID");
                            xml.WriteAttributeString("schemeAgencyID", "9");
                            xml.WriteAttributeString("schemeID", "GLN");
                            xml.WriteString("5790000012664");
                        xml.WriteEndElement();
                    xml.WriteEndElement();
                    xml.WriteStartElement("cac:PartyIdentification");
                            xml.WriteStartElement("cbc:ID");
                                xml.WriteAttributeString("schemeAgencyID", "9");
                                xml.WriteAttributeString("schemeID", "GLN");
                                xml.WriteString("5790000695652");
                            xml.WriteEndElement();
                        xml.WriteEndElement();                                                      
                xml.WriteEndElement();

                xml.WriteStartElement("cac:SellerSupplierParty");               
                    xml.WriteStartElement("cac:Party");
                        xml.WriteStartElement("cbc:EndpointID");
                            xml.WriteAttributeString("schemeAgencyID", "9");
                            xml.WriteAttributeString("schemeID", "GLN");
                            xml.WriteString("5790000681556");
                        xml.WriteEndElement();
                        xml.WriteStartElement("cac:PartyIdentification");
                            xml.WriteStartElement("cbc:ID");
                                xml.WriteAttributeString("schemeAgencyID", "9");
                                xml.WriteAttributeString("schemeID", "GLN");
                                xml.WriteString("5790000681556");                
                            xml.WriteEndElement();
                        xml.WriteEndElement();
                    xml.WriteEndElement();
                xml.WriteEndElement();


                #endregion

                // traversing dataset
                int LineCounter = 0;
                foreach (DataRow row in table.Rows)
                {
                    LineCounter++;
                    xml.WriteStartElement("cac:OrderLine");
                        xml.WriteStartElement("cac:LineItem");
                            xml.WriteStartElement("cbc:ID");
                                xml.WriteString(LineCounter.ToString());
                            xml.WriteEndElement(); 
                            xml.WriteStartElement("cbc:Quantity");
                                xml.WriteAttributeString("unitCode", "EA");
                                xml.WriteString(tools.object2string(row["Qty"]));
                            xml.WriteEndElement(); 
                            xml.WriteStartElement("cac:Delivery");
                                xml.WriteElementString("cbc:ActualDeliveryDate",tools.object2datetime(row["DelDate"]).ToShortDateString() );
                                xml.WriteEndElement();
                            xml.WriteEndElement(); 
                            xml.WriteStartElement("cac:Item");
                                xml.WriteElementString("cbc:Name", tools.object2string(row["BarCode"]));
                                xml.WriteStartElement("cac:BuyersItemIdentification");
                                    xml.WriteElementString("cbc:ID", tools.object2string(row["ItemID"]));
                                xml.WriteEndElement();
                                xml.WriteStartElement("cac:StandardItemIdentification");
                                    xml.WriteElementString("cbc:ID", tools.object2string(row["BarCode"]));
                                xml.WriteEndElement();


                            xml.WriteEndElement(); 
                        xml.WriteEndElement(); 

                    xml.WriteEndElement(); //OrderLine


                  
                }
              
                xml.WriteEndElement(); //order

             


                xml.Close();
                
                // save filename
                //filenameOIO = filename;

                // save a backup of the file, if backup is active
               // if (db.GetConfigStringAsBool("NAXML_Export_Backup_Active"))
                //    CopyFileToBackupDir(filepath);

                return ""; // ok
            }
            catch (Exception ex)
            {
                log.Write("Exception in Export.OIO():");
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
                if (xml != null)
                    xml.Close();
            }

            #endregion
        }
        

               

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

            

            if (dirCount > 0)
            {
                string dir = db.GetLangString("ExportRSM.Directory");
                if (dirCount > 1) dir = db.GetLangString("ExportRSM.Directories");
                msg = string.Format(db.GetLangString("ExportRSM.ExportDoesNotExist"), dir) + "\n\n" + msg;
            }

            return msg;
        }
        #endregion

        
    }
}
