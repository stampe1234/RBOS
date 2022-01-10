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
    /// Methods for generating data into FVD exporting data to stations.
    /// </summary>
    class ExportFVD
    {
        #region SelectFVDData
        /// <summary>
        /// Creates data for FVD file and intermediate table.
        /// </summary>
        /// <param name="includeUpdateStations">If true, UpdateStations flag is checked for true.</param>
        /// <param name="subCategoryFrom">If not "", SubCategory range if checked for.</param>
        /// <param name="subCategoryTo">MUST be eiter same value as subCategoryFrom or another value. NOT "".</param>
        /// <param name="barcode">If not null, Barcode is checked for.</param>
        /// <param name="startDateTime">If not null, start/end interval of LastChangeDateTime is checked for.</param>
        /// <param name="endDateTime">MUST be either same value as startDateTime or another value. NOT null.</param>
        /// <returns></returns>
        public static DataTable SelectFVDData(
            bool includeUpdateStations,
            string subCategoryFrom,
            string subCategoryTo,
            Nullable<double> barcode,
            Nullable<DateTime> startDateTime,
            Nullable<DateTime> endDateTime)
        {
            string sqlWhereClause = "";

            // add UpdateStations flag to where clause
            if (includeUpdateStations)
                sqlWhereClause += " AND (SalesPack.UpdateStations = true) ";
            
            // add SubCategory range to where clause
            if((subCategoryFrom != "") && (subCategoryTo != ""))
            {
                sqlWhereClause += string.Format(
                    " AND ((Item.SubCategory >= \"{0}\") AND (Item.SubCategory <= \"{1}\")) ",
                    subCategoryFrom,subCategoryTo);
            }

            // add Barcode to where clause
            if (barcode != null)
                sqlWhereClause += string.Format(" AND (Barcode.Barcode = {0}) ", barcode);

            // add start/end DateTime range to where clause
            if((startDateTime != null) && (endDateTime != null))
            {
                sqlWhereClause += string.Format(
                    " AND ((Item.LastChangeDateTime >= cdate('{0}')) AND (Item.LastChangeDateTime <= cdate('{1}'))) ",
                    startDateTime.Value, endDateTime.Value);
            }

            string sql = string.Format(@"
                select distinct
                    Item.ItemID,
                    Barcode.IsPrimary as PrimaryBarcode,
                    Barcode.Barcode,
                    null as OrderingNumber,
                    Item.ItemName,
                    null as KolliSize,
                    Item.SubCategory,
                    Item.CostPriceLatest as CostPrice,
                    SalesPack.SalesPrice,
                    null as SupplierNo,
                    Item.KampagneID,
                    Item.FSD_ID,                    
                    SalesPack.PackType,
                    Item.DisktilbudFraDato,
                    Item.DisktilbudTilDato,
                    Item.DisktilbudThreshold,
                    (select top 1 future.ActivationDate
                        from SalesPackFuturePrices future
                        where future.ItemID = SalesPack.ItemID
                        and future.PackType = SalesPack.PackType
                        and future.SentToStations <> yes
                        and future.ActivationDate >= date()
                        order by future.ActivationDate) as FutureSalesPriceDate,
                    (select top 1 future.SalesPrice
                        from SalesPackFuturePrices future
                        where future.ItemID = SalesPack.ItemID
                        and future.PackType = SalesPack.PackType
                        and future.SentToStations <> yes
                        and future.ActivationDate >= date()
                        order by future.ActivationDate) as FutureSalesPrice,
                    (select top 1 future.PackType
                        from SalesPackFuturePrices future
                        where future.ItemID = SalesPack.ItemID
                        and future.PackType = SalesPack.PackType
                        and future.SentToStations <> yes
                        and future.ActivationDate >= date()
                        order by future.ActivationDate) as FutureSalesPricePackType
                FROM ((Item
                INNER JOIN SalesPack
                  ON Item.ItemID = SalesPack.ItemID)
                INNER JOIN Barcode
                  ON Item.ItemID = Barcode.ItemID
                  AND SalesPack.PackType = Barcode.PackType)
                where (SalesPack.IsPrimary = true)
                AND ( (1=1) {0} )
                order by Item.ItemID, Barcode.IsPrimary
                ", sqlWhereClause);

            ProgressForm progress = new ProgressForm("");
            progress.Show();

            DataTable tableItems = db.GetDataTable(sql);

            // build sorted list of unique ItemIDs
            progress.ProgressMax = tableItems.Rows.Count;
            List<int> ItemList = new List<int>();
            foreach (DataRow row in tableItems.Rows)
            {
                if (!ItemList.Contains(tools.object2int(row["ItemID"])))
                    ItemList.Add(tools.object2int(row["ItemID"]));
                progress.StatusText = "";
            }
            ItemList.Sort();

            progress.ProgressMax = ItemList.Count;
            DataTable newTable = tableItems.Clone();
            foreach (int ItemID in ItemList)
            {
                // select item and supplieritem rows matching the current ItemID
                DataRow[] rowsItems = tableItems.Select(string.Format("ItemID = {0}", ItemID));
                DataTable rowsSupplierItems = db.GetDataTable(string.Format(@"
                    select SupplierNo, OrderingNumber, KolliSize, PackageUnitCost, IsPrimary
                    from SupplierItem
                    where ItemID = {0}
                    ", ItemID));

                // row used when inserting additional SupplierItem records
                DataRow keepRowWithPrimaryBarcode = null;

                // row used when filling in missing SupplierItem data
                // (keep the primary SupplierItem for this)
                DataRow keepRowWithPrimarySupplierItem = null;
                foreach (DataRow row in rowsSupplierItems.Rows)
                {
                    if (tools.object2bool(row["IsPrimary"]))
                    {
                        keepRowWithPrimarySupplierItem = rowsSupplierItems.NewRow();
                        keepRowWithPrimarySupplierItem.ItemArray = row.ItemArray;
                    }
                }

                foreach (DataRow rowItem in rowsItems)
                {
                    // create a new record with copied data from the selected set,
                    // including inserting any SupplierItem data
                    DataRow newRow = newTable.NewRow();
                    newRow.ItemArray = rowItem.ItemArray;
                    if (rowsSupplierItems.Rows.Count > 0)
                    {
                        newRow["SupplierNo"] = rowsSupplierItems.Rows[0]["SupplierNo"];
                        newRow["OrderingNumber"] = rowsSupplierItems.Rows[0]["OrderingNumber"];
                        newRow["CostPrice"] = rowsSupplierItems.Rows[0]["PackageUnitCost"];
                        newRow["KolliSize"] = rowsSupplierItems.Rows[0]["KolliSize"];
                        rowsSupplierItems.Rows.RemoveAt(0);
                    }
                    newTable.Rows.Add(newRow);

                    // keep an item row with primary barcode, as this is used when
                    // inserting records with supplieritem records, that there
                    // was not enough room for
                    if (tools.object2bool(rowItem["PrimaryBarcode"]))
                    {
                        keepRowWithPrimaryBarcode = newTable.NewRow();
                        keepRowWithPrimaryBarcode.ItemArray = rowItem.ItemArray;
                    }
                }

                // If any SupplierItem records left after all item records with all barcodes have been made,
                // create new records with these, inserting data from record with the primary Barcode.
                while (rowsSupplierItems.Rows.Count > 0)
                {
                    if ((keepRowWithPrimaryBarcode != null) && (tools.object2int(keepRowWithPrimaryBarcode["ItemID"]) == ItemID))
                    {
                        DataRow newRow = newTable.NewRow();
                        newRow.ItemArray = keepRowWithPrimaryBarcode.ItemArray;
                        newRow["SupplierNo"] = rowsSupplierItems.Rows[0]["SupplierNo"];
                        newRow["OrderingNumber"] = rowsSupplierItems.Rows[0]["OrderingNumber"];
                        newRow["CostPrice"] = rowsSupplierItems.Rows[0]["PackageUnitCost"];
                        newRow["KolliSize"] = rowsSupplierItems.Rows[0]["KolliSize"];
                        newTable.Rows.Add(newRow);
                    }
                    else
                    {
                        /* unknown error */
                    }
                    rowsSupplierItems.Rows.RemoveAt(0);
                }

                // run through the generated records and check if there is
                // missing supplier information, for this item.
                // if so, we insert supplier information from the primary supplier.
                if (keepRowWithPrimarySupplierItem != null)
                {
                    foreach (DataRow row in newTable.Rows)
                    {
                        if ((tools.object2int(row["ItemID"]) == ItemID) &&
                            tools.IsNullOrDBNull(row["SupplierNo"]))
                        {
                            row["SupplierNo"] = keepRowWithPrimarySupplierItem["SupplierNo"];
                            row["OrderingNumber"] = keepRowWithPrimarySupplierItem["OrderingNumber"];
                            row["KolliSize"] = keepRowWithPrimarySupplierItem["KolliSize"];
                        }
                    }
                }

                progress.StatusText = "";

                // add disktilbud fra/til dato on items that has it
                foreach (DataRow row in newTable.Rows)
                {
                    int tmpItemID = tools.object2int(row["ItemID"]);
                    DateTime FraDato, TilDato;
                    int Threshold;
                    if (ItemDataSet.ItemDataTable.GetDisktilbudFraTilDatoer(tmpItemID, out FraDato, out TilDato, out Threshold))
                    {
                        row["DisktilbudFraDato"] = FraDato;
                        row["DisktilbudTilDato"] = TilDato;
                        row["DisktilbudThreshold"] = Threshold;
                    }
                }
            }

            progress.Close();
            return newTable;
        }
        #endregion

        #region LastError
        protected static string _LastError = "";
        public static string LastError
        {
            get { return _LastError; }
        }
        #endregion

        #region CreateFVDRecords
        /// <summary>
        /// Returns true if exported, false if not. True is also returned
        /// if no fvd export records were made but there are udmeldte to be sent.
        /// </summary>
        public static bool CreateFVDRecords(DataTable table, string Criteria)
        {
            _LastError = "";

            // check that there is no unsent records (must not be any)
            if (ItemDataSet.ExportFVDHeaderDataTable.HasAnyUnsentRecords())
            {
                _LastError = db.GetLangString("ExportFVD.ExportAlreadyExists");
                return false;
            }

            // check that there are records in the provided table
            if (table.Rows.Count <= 0)
            {
                // no records in here, but udmeldte might have
                if (ItemDataSet.FSDDeletedSupplierItemDataTable.GetNumNonHistoricRecords() <= 0)
                {
                    _LastError = db.GetLangString("ExportFVD.NoDataToExport");
                    return false;
                }
            }

            try
            {
                db.StartTransaction();

                // create FVD export header, with initial data in it
                int HeaderID = ItemDataSet.ExportFVDHeaderDataTable.CreateRecord(
                    table.Rows.Count, Criteria);

                // create the FVD detail records (can be empty if there is only udmeldte)
                foreach (DataRow row in table.Rows)
                {
                    // check if a record contains future sales price,
                    // as some of the values needs to be replaced if so
                    byte PackType = tools.object2byte(row["PackType"]);
                    double SalesPrice = tools.object2double(row["SalesPrice"]);
                    if (!tools.IsNullOrDBNull(row["FutureSalesPriceDate"]))
                    {
                        PackType = tools.object2byte(row["FutureSalesPricePackType"]);
                        SalesPrice = tools.object2double(row["FutureSalesPrice"]);
                    }

                    ItemDataSet.ExportFVDDetailsDataTable.CreateRecord(
                        HeaderID,
                        tools.object2double(row["Barcode"]),
                        tools.object2double(row["OrderingNumber"]),
                        tools.object2string(row["ItemName"]),
                        tools.object2int(row["KolliSize"]),
                        tools.object2string(row["SubCategory"]),
                        tools.object2double(row["CostPrice"]),
                        SalesPrice,
                        tools.object2int(row["SupplierNo"]),
                        tools.object2int(row["KampagneID"]),
                        tools.object2int(row["FSD_ID"]),
                        PackType,
                        row["FutureSalesPriceDate"],
                        tools.object2datetime(row["DisktilbudFraDato"]),
                        tools.object2datetime(row["DisktilbudTilDato"]),
                        tools.object2int(row["DisktilbudThreshold"])
                        );
                }

                db.CommitTransaction();
            }
            catch (Exception ex)
            {
                _LastError = log.WriteException("ExportFVD.CreateFVDRecords", ex.Message, ex.StackTrace);
                db.RollbackTransaction();
            }

            // export successful
            return true;
        }
        #endregion

        #region CreateFVDFile
        /// <summary>
        /// Will create the FVD file using the
        /// currently unsent FVD header/detail data.
        /// </summary>
        public static bool CreateFVDFile(int HeaderID)
        {
            _LastError = "";
            StreamWriter writer = null;
            string filepath = "";
            try
            {
                // writing to db is determined on whether the data in question has
                // been sent to stations or not. if unsent, data will be written to db,
                // if data is sent, no data with be written to db.
                bool WriteToDB = ItemDataSet.ExportFVDHeaderDataTable.IsUnsentRecord(HeaderID);

                // get data
                DataTable tableDetails;
                if (WriteToDB)
                    tableDetails = ItemDataSet.ExportFVDDetailsDataTable.GetUnsentData();
                else
                    tableDetails = ItemDataSet.ExportFVDDetailsDataTable.GetData(HeaderID);

                // do some data validation
                foreach (DataRow row in tableDetails.Rows)
                {
                    // check if the item is missing supplieritems, if so
                    // do not output anything but stop exporter and give an error
                    if ((tools.object2double(row["Bestillnr"]) <= 0) ||
                        (tools.object2int(row["Leverandoernr"]) <= 0))
                    {
                        _LastError = string.Format(
                            db.GetLangString("ExportFVD.ItemMissingSupplierItems"),
                            tools.object2string(row["Varetekst"]));
                        return false;
                    }

                    // check if the item has incomplete disktilbud and if so
                    // do not output anything but stop exporter and give an error
                    if (!VerifyDisktilbudIntegrity(row))
                        return false;
                }

                // generate SentOutDateTime
                // (in seperate variable than the filename as we need it later in here)
                DateTime SentOutDateTime = DateTime.Now;

                // generate filename for output file
                // (in seperate variable than the entire path as we need it later in here)
                string filename = "FSD" + SentOutDateTime.ToString("yyyyMMddHHmm") + ".FVD";

                // generate path for output file
                filepath = db.GetConfigString("FVDExportFileDir", "c:\\drs\\depart");
                if (!filepath.EndsWith("\\") && !filepath.EndsWith("/"))
                    filepath += "\\";
                filepath += filename;

                // check if file exist, delete if so
                DeleteExistingFile(filepath);

                writer = new StreamWriter(filepath, false, tools.Encoding());

                if (WriteToDB)
                    db.StartTransaction();
                
                // output header
                writer.WriteLine("Aktion;Stregkode;Bestillnr;Varetekst;Kolli;Subcat;Kostpris;Salgspris;Leverandørnr;KampagneID;FSD_ID;FremtidigSalgsprisDato;PackType;DisktilbudFraDato;DisktilbudTilDato;DisktilbudThreshold");

                // output items                
                foreach (DataRow row in tableDetails.Rows)
                {
                    writer.Write("10;");
                    writer.Write(row["Stregkode"].ToString() + ";");
                    writer.Write(row["Bestillnr"].ToString() + ";");
                    writer.Write(row["Varetekst"].ToString() + ";");
                    writer.Write(row["Kolli"].ToString() + ";");
                    writer.Write(row["Subcat"].ToString() + ";");
                    writer.Write(row["Kostpris"].ToString() + ";");
                    writer.Write(row["Salgspris"].ToString() + ";");
                    writer.Write(ItemDataSet.SupplierDataTable.GetLLSupplierNoFromSupplierID(tools.object2int(row["Leverandoernr"])).ToString() + ";");
                    writer.Write(row["KampagneID"].ToString() + ";");
                    writer.Write(row["FSD_ID"].ToString() + ";");
                    writer.Write(row["FutureSalesPriceDate"].ToString() + ";");
                    writer.Write(row["PackType"].ToString() + ";");
                    writer.Write(FormatDate(row["DisktilbudFraDato"]) + ";");
                    writer.Write(FormatDate(row["DisktilbudTilDato"]) + ";");
                    writer.Write(row["DisktilbudThreshold"].ToString());
                    writer.WriteLine("");

                    int ItemID = ItemDataSet.ItemDataTable.GetItemIDFromBarcodeOrSupplierItem(
                        tools.object2double(row["Stregkode"]),
                        tools.object2int(row["Leverandoernr"]),
                        tools.object2double(row["Bestillnr"]));
                    if (WriteToDB)
                    {
                        ItemDataSet.SalesPackDataTable.SetUpdateStations(ItemID, false);
                        
                        byte PackType = tools.object2byte(row["PackType"]);
                        if (!tools.IsNullOrDBNull(row["FutureSalesPriceDate"]))
                        {
                            ItemDataSet.SalesPackFuturePricesDataTable.MarkAsSentToStations(
                                ItemID, PackType, tools.object2datetime(row["FutureSalesPriceDate"]));
                            if (ItemDataSet.SalesPackFuturePricesDataTable.MoreFuturePricesExistNotSendToStations(ItemID, PackType))
                                ItemDataSet.SalesPackDataTable.SetUpdateStations(ItemID, true);
                        }
                    }
                }

                // output udmeldte
                DataTable tableUdmeldte;
                if (WriteToDB)
                    tableUdmeldte = ItemDataSet.FSDDeletedSupplierItemDataTable.GetNonHistoricData();
                else
                    tableUdmeldte = ItemDataSet.FSDDeletedSupplierItemDataTable.GetHistoricData(HeaderID);
                foreach (DataRow row in tableUdmeldte.Rows)
                {
                    writer.Write("20;");
                    writer.Write(";"); // Stregkode
                    writer.Write(row["OrderingNumber"].ToString() + ";");
                    writer.Write(";"); // Varetekst
                    writer.Write(row["KolliSize"].ToString() + ";");
                    writer.Write(";"); // Subcat
                    writer.Write(row["PackageUnitCost"].ToString() + ";");
                    writer.Write(row["SellingUnitCost"].ToString() + ";");
                    writer.Write(ItemDataSet.SupplierDataTable.GetLLSupplierNoFromSupplierID(tools.object2int(row["SupplierNo"])).ToString() + ";");
                    writer.Write(";"); // KampagneID
                    writer.Write(""); // FSD_ID
                    writer.WriteLine("");
                }

                if (WriteToDB)
                {
                    // write some values to export FVD header.
                    // this locks the header record for further edit.
                    ItemDataSet.ExportFVDHeaderDataTable.SetFilename(HeaderID, filename);
                    ItemDataSet.ExportFVDHeaderDataTable.SetSentOutDateTime(HeaderID, SentOutDateTime);

                    // write the export FVD header's HeaderID into the udmeldte records used in here.
                    // this turns those records into history records and locks them for further edit.
                    ItemDataSet.FSDDeletedSupplierItemDataTable.SetFVDExportHeaderIDOnNonHistoricRecords(HeaderID);

                    db.CommitTransaction();
                }

                // export successful
                return true;
            }
            catch (Exception ex)
            {
                if (writer != null)
                    writer.Close();
                DeleteExistingFile(filepath);
                _LastError = log.WriteException("ExportFVD.CreateFVDFile", ex.Message, ex.StackTrace);
                return false;
            }
            finally
            {
                if (writer != null)
                    writer.Close();
                if (db.CurrentTransaction != null)
                    db.RollbackTransaction();
            }
        }
        #endregion

        private static bool VerifyDisktilbudIntegrity(DataRow row)
        {
            if (!tools.IsNullOrDBNull(row["DisktilbudFraDato"]) ||
                !tools.IsNullOrDBNull(row["DisktilbudTilDato"]) ||
                tools.object2int(row["DisktilbudThreshold"]) > 0)
            {
                if (tools.IsNullOrDBNull(row["DisktilbudFraDato"]) ||
                    tools.IsNullOrDBNull(row["DisktilbudTilDato"]) ||
                    tools.object2int(row["DisktilbudThreshold"]) <= 0 ||
                    tools.object2int(row["KampagneID"]) <= 0)
                {
                    _LastError = string.Format(
                        db.GetLangString("ExportFVD.IncompleteDisktilbud"),
                        tools.object2string(row["Varetekst"]));
                    return false;
                }
            }
            return true;
        }

        #region CreateFVDFileAsCSV
        /// <summary>
        /// Will create a CSV file using the provided FVD header/detail data.
        /// The output file format fits with the importer in ImportItemsCSV.cs.
        /// </summary>
        public static bool CreateFVDFileAsCSV(int HeaderID)
        {
            _LastError = "";
            StreamWriter writer = null;
            string filepath = "";
            try
            {
                // get data
                DataTable tableDetails = ItemDataSet.ExportFVDDetailsDataTable.GetData(HeaderID);

                // do some data validation
                foreach (DataRow row in tableDetails.Rows)
                {
                    // check if the items in the data are missing supplieritems, if so
                    // do not output them but stop exporter and give an error
                    if ((tools.object2double(row["Bestillnr"]) <= 0) ||
                        (tools.object2int(row["Leverandoernr"]) <= 0))
                    {
                        _LastError = string.Format(
                            db.GetLangString("ExportFVD.ItemMissingSupplierItems"),
                            tools.object2string(row["Varetekst"]));
                        return false;
                    }

                    // check if the item has incomplete disktilbud and if so
                    // do not output anything but stop exporter and give an error
                    if (!VerifyDisktilbudIntegrity(row))
                        return false;
                }

                // generate SentOutDateTime
                // (in seperate variable than the filename as we need it later in here)
                DateTime SentOutDateTime = DateTime.Now;

                // generate filename for output file
                // (in seperate variable than the entire path as we need it later in here)
                string filename = "FSD" + SentOutDateTime.ToString("yyyyMMddHHmm") + ".CSV";

                // generate path for output file
                filepath = db.GetConfigString("FVDExportFileDir", "c:\\drs\\depart");
                if (!filepath.EndsWith("\\") && !filepath.EndsWith("/"))
                    filepath += "\\";
                filepath += filename;

                // check if file exist, delete if so
                DeleteExistingFile(filepath);

                writer = new StreamWriter(filepath, false, tools.Encoding());

                // output header
                writer.WriteLine("Stregkode;Bestillnr;Varetekst;Kolli;Subcat;Kostpris;Salgspris;Leverandørnr");

                // output items                
                foreach (DataRow row in tableDetails.Rows)
                {
                    writer.Write(row["Stregkode"].ToString() + ";");
                    writer.Write(row["Bestillnr"].ToString() + ";");
                    writer.Write(row["Varetekst"].ToString() + ";");
                    writer.Write(row["Kolli"].ToString() + ";");
                    writer.Write(row["Subcat"].ToString() + ";");
                    writer.Write(row["Kostpris"].ToString() + ";");
                    writer.Write(row["Salgspris"].ToString() + ";");
                    writer.Write(ItemDataSet.SupplierDataTable.GetLLSupplierNoFromSupplierID(tools.object2int(row["Leverandoernr"])).ToString() + ";");
                    writer.WriteLine("");
                }

                // export successful
                return true;
            }
            catch (Exception ex)
            {
                if (writer != null)
                    writer.Close();
                DeleteExistingFile(filepath);
                _LastError = log.WriteException("ExportFVD.CreateFVDFileAsCSV", ex.Message, ex.StackTrace);
                return false;
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
        #endregion

        /// <summary>
        /// Returns the given datetime as date only.
        /// If dt is null or DateTime.MinValue, "" is returned.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static string FormatDate(object dt)
        {
            DateTime datetime = tools.object2datetime(dt);
            if (datetime == DateTime.MinValue)
                return "";
            else
                return datetime.ToString("dd-MM-yyyy");
        }

        #region DeleteExistingFile
        private static void DeleteExistingFile(string filepath)
        {
            if (File.Exists(filepath))
            {
                tools.RemoveFileWriteProtection(filepath);
                File.Delete(filepath);
            }
        }
        #endregion
    }
}
