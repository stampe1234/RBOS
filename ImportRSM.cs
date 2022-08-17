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
    /// Methods for importing data from RSM.
    /// </summary>
    class ImportRSM
    {
        #region Private variables

        List<string> ismFiles;
        List<string> fgmFiles;
        List<string> mcmFiles;
        List<string> msmFiles;
        List<string> tpmFiles;
        List<string> pejFiles;

        ProgressForm progress;

        List<DateTime> BookDatesForVGS = new List<DateTime>();

        #endregion

        #region Constructor
        public ImportRSM()
        {
            ResetPrivateData();
            progress = new ProgressForm("");
        }
        #endregion

        #region PROPERTY: LastError
        private string lastError = "";
        public string LastError
        {
            get { return lastError; }
        }
        #endregion

        #region METHOD: ResetPrivateData
        private void ResetPrivateData()
        {
            // empty filelists
            ismFiles = null;
            fgmFiles = null;
            mcmFiles = null;
            msmFiles = null;
            tpmFiles = null;
        }
        #endregion

        #region METHOD: ImportRSMFiles
        /// <summary>
        /// Main entry point for importing RSM files.
        /// That means these file types: ISM, FGM, MCM, MSM, TPM.
        /// </summary>
        /// <returns>
        /// True if import completed ok.
        /// If false, LastError contains an error message.
        /// </returns>
        public bool ImportRSMFiles(out bool ErrorsInDisktilbud)
        {
            ErrorsInDisktilbud = false;

            // reset data
            ResetPrivateData();

            // check that import directories exists
            if (!ValidateImportDirs())
                return false;

            // setup and display progress bar
            progress.Title = db.GetLangString("ImportRSM.ProgressTitleRSM");
            progress.Show();

            // build filelists
            BuildFileLists();
            
            // check that there is anything to import
            if ((ismFiles.Count <= 0) &&
                (fgmFiles.Count <= 0) &&
                (mcmFiles.Count <= 0) &&
                (msmFiles.Count <= 0) &&
                (tpmFiles.Count <= 0) &&
                (pejFiles.Count <= 0))
            {
                lastError = db.GetLangString("ImportRSM.NothingToDo");

                // clean up records more than n days old
                CleanUpOldRecords();

                progress.Close();

                // generate any missing ACN files (also for the very first export)
                //ExportACN.ExportPendingACNFiles();
                
                return false;
            }

            // import files
            ImportISMFiles();//pn20190801             
            ImportFGMFiles();
            ImportMCMFiles();
            ImportMSMFiles();
            ImportTPMFiles();
            ImportPEJFiles(out ErrorsInDisktilbud);
                       
            
            // clean up semaphore files
            tools.CleanupSEMfiles(GetImportDir(), ismFiles);
            tools.CleanupSEMfiles(GetImportDir(), fgmFiles);
            tools.CleanupSEMfiles(GetImportDir(), mcmFiles);
            tools.CleanupSEMfiles(GetImportDir(), msmFiles);
            tools.CleanupSEMfiles(GetImportDir(), tpmFiles);
            tools.CleanupSEMfiles(GetImportDir(), pejFiles); // handle Radiant bug - see ImportPEJFiles

            
            
            // export VGS file for each day that has been collected as
            // the last day in a month during the MCM files importer
            // (MCM because it is used in the VGS exporter).
            // NOTE: This must run after the MCM importer has run.
            if (BookDatesForVGS.Count > 0)
            {
                ExportVGS vgs = new ExportVGS();
                foreach (DateTime BookDate in BookDatesForVGS)
                    vgs.Export(BookDate.Month, BookDate.Year);
            }
            BookDatesForVGS.Clear();

            // clean up records more than n days old
            CleanUpOldRecords();

            // close progress bar
            progress.Close();

            // generate ACN files
            
            //ACN 3 options Export Old, New or Both

            if (db.GetConfigStringAsBool("ACN_New_Enabled"))
            {
                ExportACNNew.ExportPendingACNFiles();
            }
            
            // import completed ok
            return true;
        }
        #endregion

        #region CleanUpOldRecords
        /// <summary>
        /// 
        /// </summary>
        private void CleanUpOldRecords()
        {
            // get n days back from config
            int iDaysBack = db.GetConfigStringAsInt("NAXML_Import_MaintainDaysBack");
            if (iDaysBack < 30)
                iDaysBack = 30;

            // get the last import book date.
            // if DateTime.MinValue is returned, this means that no
            // imports exists, thus nothing exist to delete
            DateTime LastImportBookDate = ImportDataSet.Import_RPOS_24H_HeaderDataTable.GetLastBookDate().Date;
            if (LastImportBookDate != DateTime.MinValue)
            {
                // get a date n days before last import book date
                DateTime BookDate = LastImportBookDate.AddDays(-iDaysBack);

                // attempt to get the last eod book date.
                // if DateTime.MinValue is returned, this means no
                // eod records exist, and then we do not want to delete records,
                // as we then don't know if the import bookdates will be needed in the future.
                DateTime LastEODBookDate = EODDataSet.EODReconcileDataTable.GetLastBookDate().Date;
                if (LastEODBookDate != DateTime.MinValue)
                {
                    // check that the n days back date is older than the last eod bookdate.
                    // we only delete import records older than the last eod bookdate,
                    // as newer import refords are needed by eod.
                    if (BookDate < LastEODBookDate)
                    {
                        // cleanup Import_RPOS_24H_Header table
                        db.ExecuteNonQuery(string.Format(
                            " delete from Import_RPOS_24H_Header " +
                            " where BookDate < '{0}' ", BookDate));

                        // cleanup Import_RPOS_24H_ProblemLines table
                        db.ExecuteNonQuery(string.Format(
                            " delete from Import_RPOS_24H_ProblemLines " +
                            " where BookDate < '{0}' ", BookDate));

                        // cleanup Import_RPOS_FGM_Details table
                        db.ExecuteNonQuery(string.Format(
                            " delete from Import_RPOS_FGM_Details " +
                            " where BookDate < '{0}' ", BookDate));

                        // cleanup Import_RPOS_MCM_Details table
                        db.ExecuteNonQuery(string.Format(
                            " delete from Import_RPOS_MCM_Details " +
                            " where BookDate < '{0}' ", BookDate));

                        // cleanup Import_RPOS_MSM_Details table
                        db.ExecuteNonQuery(string.Format(
                            " delete from Import_RPOS_MSM_Details " +
                            " where BookDate < '{0}' ", BookDate));

                        // cleanup Import_RPOS_TPM_Details table
                        db.ExecuteNonQuery(string.Format(
                            " delete from Import_RPOS_TPM_Details " +
                            " where BookDate < '{0}' ", BookDate));
                    }
                }
            }
        }
        #endregion

        #region METHOD: ImportISMFiles
        private void ImportISMFiles()
        {
            // check that import files exists
            if (ismFiles == null) return;

            progress.Title = db.GetLangString("ImportRSM.ProgressTitleISM");

            // import
            foreach (string file in ismFiles)
            {
                if (File.Exists(file))
                {
                    try
                    {
                        DataSet dsXML = new DataSet();
                        dsXML.ReadXml(file);

                        // extract BookDate from ISM header
                        DateTime BookDate = ExtractBookDate(dsXML).Date;

                        progress.Title = db.GetLangString("ImportRSM.ProgressTitleISM") + " " + BookDate.ToString() ;

                        bool SalgExists = false;

                        SalgExists = (tools.object2int(db.ExecuteScalar(string.Format(@"
                              select count(*) from ItemTransaction
                              where (PostingDate = '{0}')                              
                              and (TransactionType = {1})
                              ", BookDate,  (byte)db.TransactionTypes.SalesCount))) > 0);

                        // import this ISM file (if not already imported in header)
                        if (!ImportDataSet.Import_RPOS_24H_HeaderDataTable.RecordAlreadyExists(BookDate, "ISM"))
                        {
                            long numISMrecords = 0;
                            long numISMproblems = 0;

                            // traverse all ISMDetail data
                            DataTable tableISMDetail = dsXML.Tables["ISMDetail"];
                            if (tableISMDetail != null)
                            {
                                foreach (DataRow row in tableISMDetail.Rows)
                                {
                                    try
                                    {
                                        // extract data from ISMDetail
                                        
                                        // extract data from ISMDetail/ISMSellPriceSummary/ISMSalesTotals
                                        DataRow rowRadiantISMDetailExt = dsXML.Tables["ISMDetailExtension"].Select("ISMDetail_id = " + row["ISMDetail_id"])[0];
                                       
                                        long  Barcode = tools.object2long(rowRadiantISMDetailExt["ItemBarcode"]);

                                        if (Barcode != 0)
                                        {
                                            DataRow rowISMSellPriceSummary = dsXML.Tables["ISMSellPriceSummary"].Select("ISMDetail_id = " + row["ISMDetail_id"])[0];
                                            
                                            DataRow rowISMSalesTotals = dsXML.Tables["ISMSalesTotals"].Select("ISMSellPriceSummary_id = " + rowISMSellPriceSummary["ISMSellPriceSummary_id"])[0];

                                            // NumberOf
                                            int NumberOf = (int)tools.USStringNumberToDouble(rowISMSalesTotals["SalesQuantity"].ToString());
                                            NumberOf *= -1;
                                            // Amount
                                            double Amount = tools.USStringNumberToDouble(rowISMSalesTotals["SalesAmount"].ToString());
                                            Amount *= -1;

                                            // extract data from ISMDetail/ItemCode
                                            DataRow rowItemCode = dsXML.Tables["ItemCode"].Select("ISMDetail_id = " + row["ISMDetail_id"])[0];
                                            byte SalesPackType = 1;
                                            
                                            int FSDID = tools.object2int(rowItemCode["POSCode"]);
                                            int ItemID = 0;
                                            Nullable<double> costprice = null;
                                            DataRow itemRow2 = db.GetDataRow(string.Format(
                                                    " select ItemID ,CostPriceLatest from Item " +
                                                    " where FSD_ID = {0} ",
                                                    FSDID));
                                            if ((itemRow2 != null) && (itemRow2["ItemID"] != DBNull.Value))
                                            {
                                                ItemID = tools.object2int(itemRow2["ItemID"]);
                                                costprice = tools.object2double(itemRow2["CostPriceLatest"]);
                                            }
                                            //pn20200730
                                            if (ItemID == 0)
                                             {
                                                DataRow itemRow3 = db.GetDataRow(string.Format(
                                                    " select ItemID,CostPriceLatest from Item " +
                                                    " where ItemID = {0} ",
                                                    FSDID));
                                                if ((itemRow3 != null) && (itemRow3["ItemID"] != DBNull.Value))
                                                {
                                                    ItemID = tools.object2int(itemRow3["ItemID"]);
                                                    costprice = tools.object2double(itemRow3["CostPriceLatest"]);
                                                }
                                            }
                                            //pn20200730
                                            // NoOfSellingUnits                                                                                                                                 
                                            long NoOfSellingUnits = NumberOf * ItemDataSet.LookupPackTypeAmount(SalesPackType);

                                            // lookup item to get costprice
                                          
                                            double costprice2 = 0;

                                            //DataRow itemRow = db.GetDataRow(string.Format(
                                            //        " select CostPriceLatest from Item " +
                                            //        " where ItemID = {0} ",
                                            //        ItemID));
                                            //if ((itemRow != null) && (itemRow["CostPriceLatest"] != DBNull.Value))
                                            //    costprice = tools.object2double(itemRow["CostPriceLatest"]);
                                            
                                            costprice2 = costprice ?? 0;

                                            // create counter-SalgOpt record as needed
                                            //pn20200814
                                            if (SalgExists)
                                            ItemDataSet.ItemTransactionDataTable.CreateSalgOptCounterRecordAsNeeded(
                                              BookDate, ItemID);

                                            //  insert transaction in ItemTransaction
                                            ItemDataSet.ItemTransactionDataTable.WriteTransactionRecord(
                                                ItemID,
                                                BookDate,
                                                (byte)db.TransactionTypes.Sales,
                                                NumberOf, // always negative in sales (out of stock)
                                                Amount, // alwasy negative in sales (out of stock)
                                                SalesPackType,
                                                Barcode,
                                                ((int)NoOfSellingUnits),
                                                costprice2,
                                                true);

                                            // show progress
                                            //Pn20200814
                                            //if (numISMrecords % 20 == 0)  //opdaterer kun for hver 20 record p.g.a performance
                                            //{
                                            //    progress.StatusText = string.Format(
                                            //    db.GetLangString("ImportRSM.ProgressItemTransaction"),
                                            //    ++numISMrecords, file);
                                            //}
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        // some unknown error, write an error line
                                        WriteProblemLine(BookDate, "ISM", ex.Message, ex.StackTrace);
                                        ++numISMproblems;

                                        // show progress
                                        progress.StatusText = string.Format(
                                            db.GetLangString("ImportRSM.ProgressProblemLine"),
                                            numISMproblems, file);
                                    }
                                } // foreach ISM detail row in XML file

                                // mark in header that ISM file type has been imported
                                UpdateHeaderLine(BookDate, "ISM");
                            } // check that tableISMDetail != null
                        } // check if already imported
                    }
                    catch (Exception ex)
                    {
                        log.WriteException("ImportRSM.ImportISMFiles", ex.Message, ex.StackTrace);
                    }
                } // check that file exists
            } // foreach ism file)

            // move ISM files now imported to backup dir or delete them
            //Peter
            foreach (string file in ismFiles)
            {
                // copy the ISM file to depart dir, if enabled
                if (db.GetConfigStringAsBool("ImportRSM.ImportISMFiles.CopyToDepart"))
                {
                    string destdir = db.GetConfigString("DRS_FTP_client_depart_dir").Trim();
                    string destfile = tools.StripDirectoryFromPath(file).Trim();
                    string destpath = (destdir + "\\" + destfile).Replace("\\\\", "\\");
                    tools.RemoveFileWriteProtection(destpath);
                    File.Copy(file, destpath, true);
                }
                
                
                
                
                if (db.GetConfigStringAsBool("NAXML_Import_Backup_Active"))
                    MoveFileToBackupDir(file);
                else
                    File.Delete(file);
            }
        }

        #endregion

        #region METHOD: ImportMCMFiles
        private void ImportMCMFiles()
        {
            // check that import files exists
            if (mcmFiles == null) return;

            progress.Title = db.GetLangString("ImportRSM.ProgressTitleMCM");

            // import
            foreach (string file in mcmFiles)
            {
                if (File.Exists(file))
                {
                    try
                    {
                        DataSet dsXML = new DataSet();
                        dsXML.ReadXml(file);

                        // extract BookDate from MCM header
                        DateTime BookDate = ExtractBookDate(dsXML).Date;

                        // import this MCM file (if not already imported in header)
                        if (!ImportDataSet.Import_RPOS_24H_HeaderDataTable.RecordAlreadyExists(BookDate, "MCM"))
                        {
                            long numMCMrecords = 0;
                            long numMCMproblems = 0;

                            // traverse all MCMDetail data
                            DataTable tableMCMDetail = dsXML.Tables["MCMDetail"];
                            if (tableMCMDetail != null)
                            {
                                OleDbCommand cmd = new OleDbCommand("", db.Connection);
                                bool existingDataDeleted = false;

                                if (db.GetConfigStringAsBool("MergeFiles"))
                                    existingDataDeleted = true;


                                foreach (DataRow row in tableMCMDetail.Rows)
                                {
                                    try
                                    {
                                        // extract data from MCMDetail
                                        string MerchCode = tools.object2string(row["MerchandiseCode"]);

                                        // extract data from MCMSalesTotals
                                        DataRow rowMCMSalesTotals = dsXML.Tables["MCMSalesTotals"].Select("MCMDetail_id = " + row["MCMDetail_id"])[0];
                                        // SalesQuantity
                                        double SalesQuantity = tools.USStringNumberToDouble(rowMCMSalesTotals["SalesQuantity"].ToString());//pn20190801
                                        int SalesQuantityInt = Convert.ToInt32(System.Math.Floor(SalesQuantity));
                                       
                                        // SalesAmount
                                        double SalesAmount = tools.USStringNumberToDouble(rowMCMSalesTotals["SalesAmount"].ToString());//pn20190801
                                   
                                        // verify that merchandise code (subcategory)
                                        // can be found in RBOS database
                                        cmd.CommandText = string.Format(
                                            " select SubCategoryID from SubCategory " +
                                            " where SubCategoryID = '{0}' ", MerchCode);
                                        object o = cmd.ExecuteScalar();
                                        if ((o == DBNull.Value) || (o == null))
                                        {
                                            // merch code not found, write error line
                                            string ProblemDescription = db.GetLangString("ImportRSM.SubCategoryNotFound");
                                            WriteProblemLine(BookDate, "MCM", ProblemDescription, MerchCode);
                                            ++numMCMproblems;

                                            // show progress
                                            progress.StatusText = string.Format(
                                                db.GetLangString("ImportRSM.ProgressProblemLine"),
                                                numMCMproblems, file);
                                        }
                                        else
                                        {
                                            // data verified ok, insert MCM data in Import_RPOS_MCM_Details

                                            /// Erase any previous data (happens if user has previously imported
                                            /// these data and has removed the "already-imported" checkmark
                                            /// so importer thinks these data has not yet been imported). We put
                                            /// it in here, as we want to make absolutely sure that there will
                                            /// be imported new data before deleting the existing data.

                                            if (db.GetConfigStringAsBool("MergeFiles")) //20200123
                                                existingDataDeleted = true;

                                            if (!existingDataDeleted)
                                            {
                                                cmd.CommandText = string.Format(
                                                    " delete from Import_RPOS_MCM_Details " +
                                                    " where BookDate = '{0}' ",
                                                    BookDate);
                                                cmd.ExecuteNonQuery();
                                                existingDataDeleted = true;
                                            }

                                            // insert data
                                            cmd.CommandText = string.Format(
                                                " insert into Import_RPOS_MCM_Details " +
                                                " (BookDate,[LineNo],MerchCode,SalesQuantity,SalesQuantity2,SalesAmount) " +
                                                " values ({0},{1},{2},{3},{4},{5}) ",
                                                "'" + BookDate + "'",
                                                GetNextDetailsLineNo(BookDate, "MCM"),
                                                "'" + MerchCode + "'",
                                                "'" + SalesQuantityInt + "'",
                                                 tools.decimalnumber4sql(SalesQuantity),
                                                  tools.decimalnumber4sql(SalesAmount));
                                            cmd.ExecuteNonQuery();

                                            // if this is the last day in the month, keep it for the VGS exporter
                                            if (tools.IsLastDayInMonth(BookDate) && !BookDatesForVGS.Contains(BookDate))
                                                BookDatesForVGS.Add(BookDate);

                                            // show progress
                                            progress.StatusText = string.Format(
                                                db.GetLangString("ImportRSM.ProgressRecord"),
                                                ++numMCMrecords, file);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        // some unknown error, write an error line
                                        WriteProblemLine(BookDate, "MCM", ex.Message, ex.StackTrace);
                                        ++numMCMproblems;

                                        // show progress
                                        progress.StatusText = string.Format(
                                            db.GetLangString("ImportRSM.ProgressProblemLine"),
                                            numMCMproblems, file);
                                    }
                                } // foreach MCM detail row in XML file

                                // mark in header that MCM file type has been imported
                                UpdateHeaderLine(BookDate, "MCM");

                            } // check that tableMCMDetail != null
                        } // check if already imported
                    }
                    catch (Exception ex)
                    {
                        log.WriteException("ImportRSM.ImportMCMFiles", ex.Message, ex.StackTrace);
                    }
                } // check that file exists
            } // foreach mcm file)

            // move MCM files now imported to backup dir or delete them
            foreach (string file in mcmFiles)
            {
                if (db.GetConfigStringAsBool("NAXML_Import_Backup_Active"))
                    MoveFileToBackupDir(file);
                else
                    File.Delete(file);
            }
        }

        #endregion

        #region METHOD: ImportFGMFiles
        private void ImportFGMFiles()
        {
            // check that import files exists
            if (fgmFiles == null) return;

            progress.Title = db.GetLangString("ImportRSM.ProgressTitleFGM");

            // import
            #region Udremmet////peter
            foreach (string file in fgmFiles)
            {
                if (File.Exists(file))
                {
                    try
                    {
                        DataSet dsXML = new DataSet();
                        dsXML.ReadXml(file);

                        // extract BookDate from FGM header
                        DateTime BookDate = ExtractBookDate(dsXML).Date;

                        // import this FGM file (if not already imported in header)
                        if (!ImportDataSet.Import_RPOS_24H_HeaderDataTable.RecordAlreadyExists(BookDate, "FGM"))
                        {
                            long numFGMrecords = 0;
                            long numFGMproblems = 0;

                            // traverse all FGMDetail data
                            DataTable tableFGMDetail = dsXML.Tables["FGMDetail"];
                            if (tableFGMDetail != null)
                            {
                                bool existingDataDeleted = false;

                                foreach (DataRow row in tableFGMDetail.Rows)
                                {
                                    try
                                    {
                                        OleDbCommand cmd = new OleDbCommand("", db.Connection);

                                        // extract data from FGMDetail
                                        long FuelGradeID = tools.object2long(row["FuelGradeID"]);

                                        // extract data from FGMDetail/FGMSalesTotals
                                        DataRow rowFGMSalesTotals = dsXML.Tables["FGMSalesTotals"].Select("FGMDetail_id = " + row["FGMDetail_id"])[0];
                                        // SalesVolume
                                        double SalesVolume = tools.USStringNumberToDouble(rowFGMSalesTotals["FuelGradeSalesVolume"].ToString());
                                        // SalesAmount
                                        double SalesAmount = tools.USStringNumberToDouble(rowFGMSalesTotals["FuelGradeSalesAmount"].ToString());

                                        // extract data from FGMDetail/FGMSalesTotals/PumpTestTotals
                                        DataRow rowFGMPumpTestTotals = dsXML.Tables["PumpTestTotals"].Select("FGMSalesTotals_id = " + rowFGMSalesTotals["FGMSalesTotals_id"])[0];
                                        // PumpTestVolume
                                        double PumpTestVolume = tools.USStringNumberToDouble(rowFGMPumpTestTotals["PumpTestVolume"].ToString());
                                        // PumpTestAmount
                                        double PumpTestAmount = tools.USStringNumberToDouble(rowFGMPumpTestTotals["PumpTestAmount"].ToString());

                                        // verify that FuelGradeID (SubCategoryID) can be found in SubCategory
                                        cmd.CommandText = string.Format(
                                            " select SubCategoryID from SubCategory " +
                                            " where SubCategoryID = '{0}' ", FuelGradeID);
                                        object o = cmd.ExecuteScalar();
                                        if ((o == DBNull.Value) || (o == null))
                                        {
                                            // FuelGradeId not found, write error line
                                            string ProblemDescription = db.GetLangString("ImportRSM.SubCategoryNotFound");
                                            WriteProblemLine(BookDate, "FGM", ProblemDescription, FuelGradeID.ToString());
                                            ++numFGMproblems;

                                            // show progress
                                            progress.StatusText = string.Format(
                                                db.GetLangString("ImportRSM.ProgressProblemLine"),
                                                numFGMproblems, file);
                                        }
                                        else
                                        {
                                            // data verified ok, insert FGM data in Import_RPOS_FGM_Details

                                            /// Erase any previous data (happens if user has previously imported
                                            /// these data and has removed the "already-imported" checkmark
                                            /// so importer thinks these data has not yet been imported). We put
                                            /// it in here, as we want to make absolutely sure that there will
                                            /// be imported new data before deleting the existing data.
                                            if (!existingDataDeleted)
                                            {
                                                cmd.CommandText = string.Format(
                                                    " delete from Import_RPOS_FGM_Details " +
                                                    " where BookDate = '{0}' ",
                                                    BookDate);
                                                cmd.ExecuteNonQuery();
                                                existingDataDeleted = true;
                                            }

                                            // insert data
                                            cmd.CommandText = string.Format(
                                                " insert into Import_RPOS_FGM_Details " +
                                                " (BookDate,[LineNo],FuelGradeID,SalesVolume,SalesAmount,PumpTestVolume,PumpTestAmount) " +
                                                " values ({0},{1},{2},{3},{4},{5},{6}) ",
                                                "'" + BookDate + "'",
                                                GetNextDetailsLineNo(BookDate, "FGM"),
                                                FuelGradeID,
                                                "'" + SalesVolume + "'",
                                                "'" + SalesAmount + "'",
                                                "'" + PumpTestVolume + "'",
                                                "'" + PumpTestAmount + "'");
                                            cmd.ExecuteNonQuery();

                                            // show progress
                                            progress.StatusText = string.Format(
                                                db.GetLangString("ImportRSM.ProgressRecord"),
                                                ++numFGMrecords, file);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        // some unknown error, write an error line
                                        WriteProblemLine(BookDate, "FGM", ex.Message, ex.StackTrace);
                                        ++numFGMproblems;

                                        // show progress
                                        progress.StatusText = string.Format(
                                            db.GetLangString("ImportRSM.ProgressProblemLine"),
                                            numFGMproblems, file);
                                    }
                                } // foreach FGM detail row in XML file

                                // mark in header that FGM file type has been imported
                                UpdateHeaderLine(BookDate, "FGM");

                            } // check that tableFGMDetail != null
                        } // check if already imported
                    }
                    catch (Exception ex)
                    {
                        log.WriteException("ImportRSM.ImportFGMFiles", ex.Message, ex.StackTrace);
                    }
                } // check that file exists
            } // foreach FGM file)

            //// move FGM files now imported to backup dir or delete them
            #endregion////Peter
            foreach (string file in fgmFiles)
            {
                if (db.GetConfigStringAsBool("NAXML_Import_Backup_Active"))
                    MoveFileToBackupDir(file);
                else
                    File.Delete(file);
            }
        }

        #endregion

        #region METHOD: ImportTPMFiles
        private void ImportTPMFiles()
        {
            // check that import files exists
            if (tpmFiles == null) return;

            progress.Title = db.GetLangString("ImportRSM.ProgressTitleTPM");

            // import

            #region udremmet
            foreach (string file in tpmFiles)
            {
                if (File.Exists(file))
                {
                    try
                    {
                        DataSet dsXML = new DataSet();
                        dsXML.ReadXml(file);

                        if (CheckContentExists(dsXML))
                        {
                            // extract BookDate from TPM header
                            DateTime BookDate = ExtractBookDate(dsXML).Date;

                            // import this TPM file (if not already imported in header)
                            if (!ImportDataSet.Import_RPOS_24H_HeaderDataTable.RecordAlreadyExists(BookDate, "TPM"))
                            {
                                long numTPMrecords = 0;
                                long numTPMproblems = 0;

                                // extract data from TankProdMovementHeader
                                DataTable tableTPMH = dsXML.Tables["TankProdMovementHeader"];
                                Nullable<DateTime> TReadingDateTime = null;
                                if ((tableTPMH != null) && (tableTPMH.Rows.Count > 0))
                                {
                                    DataRow rowTPMH = tableTPMH.Rows[0];
                                    if ((rowTPMH["ReadingDate"] != DBNull.Value) && (rowTPMH["ReadingTime"] != DBNull.Value))
                                    {
                                        TReadingDateTime = tools.RadiantXmlDateTime2DateTime(
                                            rowTPMH["ReadingDate"].ToString() + "T" + rowTPMH["ReadingTime"].ToString());
                                    }
                                }

                                // traverse all TPMDetail data
                                DataTable tableTPMDetail = dsXML.Tables["TPMDetail"];
                                if ((tableTPMDetail != null) && (TReadingDateTime != null))
                                {
                                    bool existingDataDeleted = false;

                                    foreach (DataRow rowTPMDetail in tableTPMDetail.Rows)
                                    {
                                        try
                                        {
                                            OleDbCommand cmd = new OleDbCommand("", db.Connection);

                                            // extract data from TPMDetail
                                            int TankID = tools.object2int(rowTPMDetail["TankID"]);
                                            //20200330
                                            //int FuelProductID = tools.object2int(rowTPMDetail["FuelProductID"]);
                                            int FuelProductID = 0;
                                            string FuelProductIDtxt = tools.object2string(rowTPMDetail["FuelProductID"]);

                                            switch (FuelProductIDtxt)
                                            {
                                                case "UNL92":
                                                    FuelProductID = 10000002;
                                                    break;

                                                case "UNL95" :
                                                    FuelProductID = 10000003;
                                                    break;

                                                case "FYRINGSOL":
                                                    FuelProductID = 10000004;
                                                    break;

                                                case "FSD":
                                                    FuelProductID = 10000005;
                                                    break;

                                                case "VPOWER":
                                                    FuelProductID = 10000006;
                                                    break;

                                                case "VPD":
                                                    FuelProductID = 10000007;
                                                    break;
                                             
                                                case "ADB":
                                                    FuelProductID = 10000008;
                                                    break;
                                                
                                            }

                                                                                                                                                                          
                                            double ReadingVolume = tools.object2double(rowTPMDetail["FuelProductVolume"]);

                                            /* @@@ FOR NOW WE DON'T VERIFY THE DATA - WE NEED A MAPPING TABLE TO CHECK FuelProductID AGAINST.
                                            // verify that FuelProductID (subcategory)
                                            // can be found in RBOS database
                                            cmd.CommandText = string.Format(
                                                " select SubCategoryID from SubCategory " +
                                                " where SubCategoryID = '{0}' ", FuelProductID);
                                            object o = cmd.ExecuteScalar();
                                            if ((o == DBNull.Value) || (o == null))
                                            {
                                                // FuelProductID not found, write error line
                                                string ProblemDescription = db.GetLangString("ImportRSM.SubCategoryNotFound");
                                                WriteProblemLine(BookDate, "TPM", ProblemDescription, FuelProductID.ToString());
                                                ++numTPMproblems;

                                                // show progress
                                                progress.StatusText = string.Format(
                                                    db.GetLangString("ImportRSM.ProgressProblemLine"),
                                                    numTPMproblems, file);
                                            }
                                            else */
                                            {
                                                // data verified ok, insert TPM data in Import_RPOS_TPM_Details

                                                /// Erase any previous data (happens if user has previously imported
                                                /// these data and has removed the "already-imported" checkmark
                                                /// so importer thinks these data has not yet been imported). We put
                                                /// it in here, as we want to make absolutely sure that there will
                                                /// be imported new data before deleting the existing data.
                                                if (!existingDataDeleted)
                                                {
                                                    cmd.CommandText = string.Format(
                                                        " delete from Import_RPOS_TPM_Details " +
                                                        " where BookDate = '{0}' ",
                                                        BookDate);
                                                    cmd.ExecuteNonQuery();
                                                    existingDataDeleted = true;
                                                }

                                                // insert data
                                                cmd.CommandText = string.Format(
                                                    " insert into Import_RPOS_TPM_Details " +
                                                    " (BookDate,TankID,TReadingDateTime,FuelProductID,ReadingVolume) " +
                                                    " values ({0},{1},{2},{3},{4}) ",
                                                    "'" + BookDate + "'",
                                                    TankID,
                                                    "'" + TReadingDateTime + "'",
                                                    FuelProductID,
                                                    "'" + tools.decimalnumber4sql(ReadingVolume) + "'"); //20200330
                                                cmd.ExecuteNonQuery();

                                                // show progress
                                                progress.StatusText = string.Format(
                                                    db.GetLangString("ImportRSM.ProgressRecord"),
                                                    ++numTPMrecords, file);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            // some unknown error, write an error line
                                            WriteProblemLine(BookDate, "TPM", ex.Message, ex.StackTrace);
                                            ++numTPMproblems;

                                            // show progress
                                            progress.StatusText = string.Format(
                                                db.GetLangString("ImportRSM.ProgressProblemLine"),
                                                numTPMproblems, file);
                                        }
                                    } // foreach TPM detail row in XML file

                                    // mark in header that TPM file type has been imported
                                    UpdateHeaderLine(BookDate, "TPM");

                                } // check that tableTPMDetail != null
                            } // check if already imported
                        } // check that content exists
                    }
                    catch (Exception ex)
                    {
                        log.WriteException("ImportRSM.ImportTPMFiles", ex.Message, ex.StackTrace);
                    }
                } // check that file exists
            } // foreach tpm file)
            #endregion////Peter
            // move TPM files now imported to backup dir or delete them
            foreach (string file in tpmFiles)
            {
                if (db.GetConfigStringAsBool("NAXML_Import_Backup_Active"))
                    MoveFileToBackupDir(file);
                else
                    File.Delete(file);
            }
        }

        #endregion

        #region METHOD: ImportPEJFiles
        /// <summary>
        /// We extract some information from the PEJ file.
        /// </summary>
        private void ImportPEJFiles(out bool ErrorsInDisktilbud)
        {
            ErrorsInDisktilbud = false;

            // process PEJ files
            if (pejFiles == null) return;
            //Peter
            foreach (string file in pejFiles)
            {
                tools.FuelDiscountFix_CopyPEJ2DRS(file);

                try
                {
                    // collect disktilbud from the PEJ file
                    bool tmpErrorsInDisktilbud;  //20200312
                    CollectDisktilbudFromPEJ(file, false, out tmpErrorsInDisktilbud);
                    if (tmpErrorsInDisktilbud)
                        ErrorsInDisktilbud = true;

                    // done so move PEJ file to backup dir or delete it
                    if (db.GetConfigStringAsBool("NAXML_Import_Backup_Active"))
                        MoveFileToBackupDir(file);
                    else
                        File.Delete(file);

                }
                catch (Exception ex)
                {
                    log.WriteException("ImportRSM.ImportPEJFiles", ex.Message, ex.StackTrace);
                }
            }
        }

        #endregion

        #region
        /// <summary>
        /// In case something has gone wrong when importing disktilbud from PEJ files,
        /// this method is provided so we can re-import the data from the PEJ file in the backup dir.
        /// If the PEJ file exist, we clear the data in the database for the given date, and re-import the data.
        /// If the PEJ file does not exist, we do not clear any data in the database.
        /// </summary>
        public bool ReImportPEJFilesFromBackup(DateTime FromDate, DateTime ToDate, out bool ErrorsInDisktilbud)
        {
            ErrorsInDisktilbud = false;

            ProgressForm progress = new ProgressForm("");
            progress.Title = "Genberegner disktilbud fra PEJ backup";
            progress.Show();

            // import any FVD file now, as we need it when recalculating all disktilbud
            progress.StatusText = "Importerer først eventuelle FVD filer";
            ManualUpdatesForm updates = new ManualUpdatesForm();
            updates.UpdateFVD();

            // the dates may not be before 11-05-2011 because the data
            // pool before that date is inadequate for recalculation
            DateTime EarliestAllowedRecalcDate = new DateTime(2011, 5, 11);
            if (FromDate < EarliestAllowedRecalcDate)
                FromDate = EarliestAllowedRecalcDate;
            if (ToDate < EarliestAllowedRecalcDate)
                ToDate = EarliestAllowedRecalcDate;

            // the PEJ files contain data for the day before the file is named,
            // so if we want data for 08.11.2010, we need to use the date 09.11.2010.
            // therefore we add a day to the two dates before using them.
            FromDate = FromDate.AddDays(1);
            ToDate = ToDate.AddDays(1);

            lastError = "";
            // traverse the date range
            for (DateTime dt = FromDate.Date; dt <= ToDate.Date; dt = dt = dt.AddDays(1))
            {
                string file = "";
                try
                {
                    // get the file with this date
                    // note that in some crazy case there could be more than one, so we take the latest
                    string pattern = string.Format("PEJ{0}*.xml", dt.ToString("yyyyMMdd"));
                    string dir = db.GetConfigString("NAXML_import_dir_backup");
                    List<string> files = new List<string>(Directory.GetFiles(dir, pattern, SearchOption.TopDirectoryOnly));
                    if (files.Count > 1)
                    {
                        // more than one PEJ file with this date, take the latest
                        files.Sort();
                        files.Reverse();
                        file = files[0];
                    }
                    else if (files.Count == 1)
                        file = files[0]; // only one PEJ file, use it

                    progress.StatusText = file;

                    // if we have a PEJ file, re-collect disktilbud from it
                    if (file != "")
                    {
                        bool tmpErrorsInDisktilbud;
                        CollectDisktilbudFromPEJ(file, true, out tmpErrorsInDisktilbud);
                        if (tmpErrorsInDisktilbud)
                            ErrorsInDisktilbud = true;
                    }
                }
                catch (Exception ex)
                {
                    log.WriteException(string.Format("ReImportPEJFilesFromBackup, file: {0}", file), ex.Message, ex.StackTrace);
                    lastError = "At least one file failed during re-importing PEJ from backup. The log-file contains more information. Please contact support.";
                    return false;
                }
            }

            // re-import successful
            progress.Close();
            return true;
        }
        #endregion

        #region GetISMFilesFromBackup
        /// <summary>
        /// Til brug for baseline i vaske konkurence
       
        /// </summary>
        public bool GetISMFilesFromBackup(DateTime FromDate, DateTime ToDate)
        {
            ProgressForm progress = new ProgressForm("");
            progress.Title = "Henter ISM filer";
            progress.Show();           

            // the dates may not be before 11-05-2011 because the data
            // pool before that date is inadequate for recalculation
            DateTime EarliestAllowedRecalcDate = new DateTime(2011, 5, 11);
            if (FromDate < EarliestAllowedRecalcDate)
                FromDate = EarliestAllowedRecalcDate;
            if (ToDate < EarliestAllowedRecalcDate)
                ToDate = EarliestAllowedRecalcDate;

            FromDate = FromDate.AddDays(1);
            ToDate = ToDate.AddDays(1);

            lastError = "";
            // traverse the date range
            for (DateTime dt = FromDate.Date; dt <= ToDate.Date; dt = dt = dt.AddDays(1))
            {
                string file = "";
                try
                {
                    // get the file with this date
                    // note that in some crazy case there could be more than one, so we take the latest
                    string pattern = string.Format("ISM{0}*.xml", dt.ToString("yyyyMMdd"));
                    string dir = db.GetConfigString("NAXML_import_dir_backup");
                    List<string> files = new List<string>(Directory.GetFiles(dir, pattern, SearchOption.TopDirectoryOnly));
                    if (files.Count > 1)
                    {
                        // more than one PEJ file with this date, take the latest
                        files.Sort();
                        files.Reverse();
                        file = files[0];
                    }
                    else if (files.Count == 1)
                        file = files[0]; // only one PEJ file, use it

                    progress.StatusText = file;

                    // if we have a ISM file, copy to depart
                    if (file != "")
                    {                                               
                        int idx = file.LastIndexOf("\\");
                        if (idx >= 0)
                        {
                            string destFile = db.GetConfigString("DRS_FTP_client_depart_dir") + file.Remove(0, idx);
                            destFile = destFile.Replace("\\\\", "\\"); // make sure we don't have double backslashes
                            if (File.Exists(destFile))
                                File.Delete(destFile); // just to be sure
                            File.Copy(file, destFile);
                        }
                        
                        
                    }
                }
                catch (Exception ex)
                {
                    log.WriteException(string.Format("GetISMFilesFromBackup, file: {0}", file), ex.Message, ex.StackTrace);
                    lastError = "At least one file failed during re-importing ISM from backup. The log-file contains more information. Please contact support.";
                    return false;
                }
            }

            // re-import successful
            progress.Close();
            return true;
        }
        #endregion

        #region CollectDisktilbudFromPEJ
        /// <summary>
        /// Helper method from ImportPEJFiles that
        /// handles collecting Disktilbud data from the PEJ file.
        /// <param name="ErrorsInDisktilbud">
        /// If true, the table DisktilbudHistory contains errors.
        /// See log for more information after method ends. We
        /// are just supposed to inform the user that an error is
        /// present and that the user should contact support.
        /// 
        /// Metoden bliver brugt fra et par steder og de håndterer
        /// exceptions fra denne metode forskelligt, så der skal ikke
        /// laves en exception-håndtering her inde i funktionen, men ude
        /// fra hvor den kaldes.
        /// </param>
        /// </summary>
        private void CollectDisktilbudFromPEJ(string file, bool recalculation, out bool ErrorsInDisktilbud)
        {
            // extract book date


            XmlDocument doc = new XmlDocument();
            doc.Load(file);

            XmlNodeList xnList = doc.GetElementsByTagName("BeginDate");

            int CustomerCount = xnList.Count;
            string sbeginDate = xnList[0].InnerXml;
            //string Xml = doc.DocumentElement.InnerXml;
            DateTime BookDate = tools.RadiantXmlDateAndTime2DateTime(sbeginDate, "00:00:00");

            xnList = doc.GetElementsByTagName("SaleEvent");
            CustomerCount  = xnList.Count;

            ErrorsInDisktilbud = false;

            //DataSet dsXML = new DataSet();


            //dsXML.ReadXml(file  );  //20200312
            //string sBookDate = dsXML.Tables["JournalHeader"].Rows[0]["BeginDate"].ToString();
            //DateTime BookDate = tools.RadiantXmlDateAndTime2DateTime(sBookDate, "00:00:00");

            // extract CustomerCount and write it to EODReconcileEx
            //int CustomerCount = dsXML.Tables["SaleEvent"].Rows.Count;

            if (db.GetConfigStringAsBool("ModifyCustomerCount.Enabled"))
            {
                CustomerCount = CustomerCount / 2;
            }
            if (BookDate != DateTime.MinValue)
                EODDataSet.EODReconcileExDataTable.InsertOrUpdateRecord(BookDate, CustomerCount, CustomerCount);

            // delete existing disktilbud records for this date
            //EODDataSet.DisktilbudSolgtDataTable.ClearDataForThisBookDate(BookDate);

            //// get the items that have disktilbud on the bookdate
            //DataTable ItemsWithDisktilbud = ItemDataSet.ItemDataTable.GetDisktilbud(BookDate.Date, out ErrorsInDisktilbud);

            //// make a list of KampagneID in the list of items with disktilbud
            //List<int> KampagneIDlist = new List<int>();
            //foreach (DataRow item in ItemsWithDisktilbud.Rows)
            //{
            //    int KampagneID = tools.object2int(item["KampagneID"]);
            //    if (!KampagneIDlist.Contains(KampagneID))
            //        KampagneIDlist.Add(KampagneID);
            //}

            //// temporary in-memory table for accumulating sales data per cashier per bookdate
            //EODDataSet.CashierSalesDataTable CashierSalesMem = new EODDataSet.CashierSalesDataTable();
            
            //// loop each SaleEvent (bon)
            //foreach (DataRow SaleEventRow in dsXML.Tables["SaleEvent"].Rows)
            //{
            //    // extract values needed in a moment
            //    int TransactionID = tools.object2int(SaleEventRow["TransactionID"]);
            //    DateTime DatoTid = tools.object2datetime(SaleEventRow["EventStartDate"]).Date + tools.object2timespan(SaleEventRow["EventStartTime"]);
            //    int CashierID = tools.object2int(SaleEventRow["CashierID"]);

            //    // select existing row or create new row in the PEJSalesSummary in-memory table
            //    DataRow CashierSalesMemRow;
            //    DataRow[] tmpCashierSalesMemRows = CashierSalesMem.Select("CashierID = " + CashierID.ToString());
            //    if (tmpCashierSalesMemRows.Length > 0)
            //    {
            //        // use an existing row from a previous SalesEvent (bon) on this cashier
            //        CashierSalesMemRow = tmpCashierSalesMemRows[0];
            //    }
            //    else
            //    {
            //        // create a new row for this SalesEvent (bon) for this cashier
            //        CashierSalesMemRow = CashierSalesMem.NewCashierSalesRow();
            //        CashierSalesMemRow["BookDate"] = BookDate.Date;
            //        CashierSalesMemRow["CashierID"] = CashierID;
            //        CashierSalesMem.AddCashierSalesRow((EODDataSet.CashierSalesRow)CashierSalesMemRow);
            //    }

            //    // accumulate the number of customers for this cashier on this bookdate
            //    CashierSalesMemRow["AntalKunder"] = tools.object2int(CashierSalesMemRow["AntalKunder"]) + 1;

            //    // before we start looping each item on this SaleEvent (bon),
            //    // clear out the temporary AccumulatedOnBon field on each item in the memory list
            //    foreach (DataRow tmp1 in ItemsWithDisktilbud.Rows)
            //        tmp1["AccumulatedOnBon"] = 0;

            //    /// for this SalesEvent (bon) go through all the items sold (this is the 4 loops below)
            //    int SaleEvent_id = tools.object2int(SaleEventRow["SaleEvent_id"]);
            //    foreach (DataRow TransactionDetailGroupRow in dsXML.Tables["TransactionDetailGroup"].Select("SaleEvent_id=" + SaleEvent_id))
            //    {
            //        int TransactionDetailGroup_id = tools.object2int(TransactionDetailGroupRow["TransactionDetailGroup_id"]);
            //        foreach (DataRow TransactionLineRow in dsXML.Tables["TransactionLine"].Select("TransactionDetailGroup_id=" + TransactionDetailGroup_id))
            //        {
            //            int TransactionLine_id = tools.object2int(TransactionLineRow["TransactionLine_id"]);
            //            foreach (DataRow ItemLineRow in dsXML.Tables["ItemLine"].Select("TransactionLine_id=" + TransactionLine_id))
            //            {
            //                // extract the SalesQuantity for use in a moment
            //               // int SalesQuantity = tools.object2int(ItemLineRow["SalesQuantity"]);
            //                int SalesQuantity = Convert.ToInt32(tools.object2double(ItemLineRow["SalesQuantity"])); 
            //                // accumulate the sales amount for this cashier on this bookdate
            //                double SalesAmount = tools.object2double(ItemLineRow["SalesAmount"]);
            //                double AccumulatedSalesAmount = tools.object2double(CashierSalesMemRow["SalgTotalBeloeb"]);
            //                CashierSalesMemRow["SalgTotalBeloeb"] = SalesAmount + AccumulatedSalesAmount;

            //                int ItemLine_id = tools.object2int(ItemLineRow["ItemLine_id"]);
            //                foreach (DataRow ItemCodeRow in dsXML.Tables["ItemCode"].Select("ItemLine_id=" + ItemLine_id))
            //                {
            //                    int InventoryItemID = tools.object2int(ItemCodeRow["InventoryItemID"]);

            //                    // if the item is in the list, accumulate is sales quantity
            //                    // (note: first try to identify by FSD_ID then ItemID)
            //                    DataRow[] ItemRows = ItemsWithDisktilbud.Select("FSD_ID=" + InventoryItemID);
            //                    if (ItemRows.Length <= 0)
            //                        ItemRows = ItemsWithDisktilbud.Select("ItemID=" + InventoryItemID);
            //                    if (ItemRows.Length > 0)
            //                        ItemRows[0]["AccumulatedOnBon"] = tools.object2int(ItemRows[0]["AccumulatedOnBon"]) + SalesQuantity;
            //                }
            //            }
            //        }
            //    } // done looping all the sold items on the SaleEvent (bon)

            //    // the SaleEvent (bon) is done, now calculate how many
            //    // disktilbud was triggered and accumulated and add that
            //    // to the calculated field for each item in the memory list.
            //    // This is now done across all items in the same campaign.

            //    foreach (int KampagneID in KampagneIDlist)
            //    {
            //        /// first get a list of items from ItemsWithDisktilbud that
            //        /// is in this campaign and has a value in AccumulatedOnBon
            //        /// different from 0
            //        DataRow[] Items = ItemsWithDisktilbud.Select(string.Format("KampagneID={0} and AccumulatedOnBon<>0", KampagneID));

            //        // proceed if any items where found that meet the criteria
            //        if (Items.Length > 0)
            //        {
            //            // accumulate across the bon for this campaign
            //            int AccumulatedOnBonAcrossCampaign = 0;
            //            int Threshold = 0;
            //            foreach (DataRow item in Items)
            //            {
            //                AccumulatedOnBonAcrossCampaign += tools.object2int(item["AccumulatedOnBon"]);
            //                Threshold = tools.object2int(item["Threshold"]); // keep the last used in this campaign
            //            }

            //            // calculate how many disktilbud was triggered in this campaign
            //            int DisktilbudThisCampaign = 0;
            //            if (Threshold > 0)
            //                DisktilbudThisCampaign = (int)(Math.Floor((double)(AccumulatedOnBonAcrossCampaign / Threshold)));

            //            // if there was one or more disktilbud
            //            // triggered for this campaign, create records in db.
            //            // note that the value can be both positive and negative.
            //            if (DisktilbudThisCampaign != 0)
            //            {
            //                // create record in DisktilbudSolgt
            //                int DisktilbudID = EODDataSet.DisktilbudSolgtDataTable.CreateRecord(TransactionID, DatoTid, CashierID, DisktilbudThisCampaign, KampagneID, BookDate);

            //                // create detail records in DisktilbudSolgtDetaljer
            //                foreach (DataRow item2 in Items)
            //                {
            //                    int ItemID = tools.object2int(item2["ItemID"]);
            //                    int AccumulatedOnBon = tools.object2int(item2["AccumulatedOnBon"]);
            //                    EODDataSet.DisktilbudSolgtDetaljerDataTable.CreateRecord(DisktilbudID, ItemID, AccumulatedOnBon);
            //                }

            //                // accumulate the disktilbud in cashier sales data too
            //                // @@@ TODO - jeg skal have fundet ud af, hvordan jeg får den samlede salgspris for disktilbuddet.
            //            }
            //        }
            //    }
            //} // end looping each SalesEvent (bon)

            //// post the accumulated cashier sales data to database
            //if (CashierSalesMem.Rows.Count > 0)
            //{
            //    // first clear any cashier sales data for this bookdate
            //    EODDataSet.CashierSalesDataTable.ClearBookDate(BookDate.Date);

            //    // post the accumulated data to the database
            //    EODDataSetTableAdapters.CashierSalesTableAdapter adapterCashierSales =
            //        new RBOS.EODDataSetTableAdapters.CashierSalesTableAdapter();
            //    adapterCashierSales.Update(CashierSalesMem);
            //}

            //// create DTV export file for this date
            //if (BookDate != DateTime.MinValue)
            //{
            //    if (db.GetConfigStringAsBool("ExportDTV.Enabled"))
            //    {
            //        ExportDTV dtv = new ExportDTV();
            //        dtv.Export(BookDate.Date, recalculation);
            //    }
            //}

            // copy the PEJ file to depart dir, if enabled
            if (db.GetConfigStringAsBool("ImportRSM.ImportPEJFiles.CopyToDepart"))
            {
                string destdir = db.GetConfigString("DRS_FTP_client_depart_dir").Trim();
                string destfile = tools.StripDirectoryFromPath(file).Trim();
                string destpath = (destdir + "\\" + destfile).Replace("\\\\", "\\");
                tools.RemoveFileWriteProtection(destpath);
                File.Copy(file, destpath, true);
            }
        }
        #endregion

        #region METHOD: ImportMSMFiles
        private void ImportMSMFiles()
        {
            // check that import files exists
            if (msmFiles == null) return;

            progress.Title = db.GetLangString("ImportRSM.ProgressTitleMSM");

            // import
            foreach (string file in msmFiles)
            {
                if (File.Exists(file))
                {
                    try
                    {
                        tools.FuelDiscountFix_CopyMSM2DRS(file);

                        DataSet dsXML = new DataSet();
                        dsXML.ReadXml(file);

                        // extract BookDate from MSM header
                        DateTime BookDate = ExtractBookDate(dsXML).Date;

                        // import this MSM file (if not already imported in header)
                        if (!ImportDataSet.Import_RPOS_24H_HeaderDataTable.RecordAlreadyExists(BookDate, "MSM"))
                        {
                            long numMSMrecords = 0;
                            long numMSMproblems = 0;

                            // traverse all MSMDetail data
                            DataTable tableMSMDetail = dsXML.Tables["MSMDetail"];
                            if (tableMSMDetail != null)
                            {
                                bool existingDataDeleted = false;
                                if (db.GetConfigStringAsBool("MergeFiles"))
                                    existingDataDeleted = true;



                                foreach (DataRow row in tableMSMDetail.Rows)
                                {
                                    try
                                    {
                                        OleDbCommand cmd = new OleDbCommand("", db.Connection);

                                        // extract data from MSMDetail/MiscellaneousSummaryCodes
                                        DataRow rowSummaryCodes = dsXML.Tables["MiscellaneousSummaryCodes"].Select("MSMDetail_id = " + row["MSMDetail_id"])[0];
                                        // SummaryCode
                                        int SummaryCode = tools.object2int(rowSummaryCodes["MiscellaneousSummaryCode"]);
                                        // SubCode
                                        int SubCode = tools.object2int(rowSummaryCodes["MiscellaneousSummarySubCode"]);
                                        // Modifier
                                        string Modifier = rowSummaryCodes["MiscellaneousSummarySubCodeModifier"].ToString();
                                        //PN20191018
                                        int ActionCode = 0;
                                        if (Modifier !="")
                                        {



                                            //
                                            cmd.CommandText = string.Format(
                                                  " Select count(*) from Import_RPOS_MSM_Config Where " +
                                                  "(SummaryCode = {0}) and (SubCode = {1}) And (Modifier = '{2}') " +
                                                  " And (IncludeCode is not null) And (IncludeAction =2)",
                                                  SummaryCode, SubCode, Modifier);

                                           // string test = cmd.CommandText.ToString();
                                         
                                            object IncludeAction = cmd.ExecuteScalar();
                                            if (tools.object2int(IncludeAction) == 1)                                          
                                            {
                                                ActionCode = 2;
                                            }
                                               
                                        }



                                        // extract data from MSMDetail/MSMSalesTotals
                                        DataRow rowMSMSalesTotals = dsXML.Tables["MSMSalesTotals"].Select("MSMDetail_id = " + row["MSMDetail_id"])[0];
                                       
                                        // Amount
                                        double Amount = tools.USStringNumberToDouble(rowMSMSalesTotals["MiscellaneousSummaryAmount"].ToString());
                                        //PN20191018
                                        if (ActionCode == 2)
                                         {
                                            Amount = Amount * -1;       
                                         }
                                        // Count
                                        int NumberOf = tools.object2int(rowMSMSalesTotals["MiscellaneousSummaryCount"]);

                                        // extract data from MSMDetail/MSMSalesTotals/Tender
                                        DataRow rowTender = dsXML.Tables["Tender"].Select("MSMSalesTotals_id = " + rowMSMSalesTotals["MSMSalesTotals_id"])[0];
                                        // TenderCode
                                        string TenderCode = rowTender["TenderCode"].ToString();
                                        // TenderSubCode
                                        string TenderSubCode = rowTender["TenderSubCode"].ToString();

                                        // truncate strings to make sure they fit in database
                                        if (Modifier.Length > 16) Modifier = Modifier.Remove(16);
                                        if (TenderCode.Length > 4) TenderCode = TenderCode.Remove(4);
                                        if (TenderSubCode.Length > 4) TenderSubCode = TenderSubCode.Remove(4);

                                        // verify that SummaryCode and SubCode combination
                                        // can be found in table Import_RPOS_MSM_Config
                                        // (selecting IncludeInImport to be able to check that flag too)
                                        cmd.CommandText = string.Format(
                                            " select IncludeInImport from Import_RPOS_MSM_Config " +
                                            " where (SummaryCode = {0}) and (SubCode = {1}) ",
                                            SummaryCode, SubCode);
                                        object IncludeInImport = cmd.ExecuteScalar();
                                        if ((IncludeInImport == DBNull.Value) || (IncludeInImport == null))
                                        {
                                            // SummaryCode/SubCode combination not found, write error line
                                            string ProblemDescription = db.GetLangString("ImportRSM.SummaryCodeSubCodeCombiNotFound");
                                            WriteProblemLine(BookDate, "MSM", ProblemDescription, SummaryCode.ToString() + " + " + SubCode.ToString());
                                            ++numMSMproblems;

                                            // show progress
                                            progress.StatusText = string.Format(
                                                db.GetLangString("ImportRSM.ProgressProblemLine"),
                                                numMSMproblems, file);
                                        }
                                        else
                                        {
                                            // data verified ok, insert MSM data in Import_RPOS_MSM_Details

                                            // use the extracted IncludeInImport flag to check
                                            // if the given combination is allowed to be imported
                                            if (tools.object2bool(IncludeInImport))
                                            {
                                                /// Erase any previous data (happens if user has previously imported
                                                /// these data and has removed the "already-imported" checkmark
                                                /// so importer thinks these data has not yet been imported). We put
                                                /// it in here, as we want to make absolutely sure that there will
                                                /// be imported new data before deleting the existing data.
                                                if (!existingDataDeleted)
                                                {
                                                    cmd.CommandText = string.Format(
                                                        " delete from Import_RPOS_MSM_Details " +
                                                        " where BookDate = '{0}' ",
                                                        BookDate);
                                                    cmd.ExecuteNonQuery();
                                                    existingDataDeleted = true;
                                                }

                                                // insert data
                                                cmd.CommandText = string.Format(
                                                    " insert into Import_RPOS_MSM_Details " +
                                                    " (BookDate,[LineNo],SummaryCode,SubCode,Modifier,TenderCode,TenderSubCode,Amount,NumberOf) " +
                                                    " values ({0},{1},{2},{3},{4},{5},{6},{7},{8}) ",
                                                    "'" + BookDate + "'",
                                                    GetNextDetailsLineNo(BookDate, "MSM"),
                                                    SummaryCode,
                                                    SubCode,
                                                    "'" + Modifier + "'",
                                                    "'" + TenderCode + "'",
                                                    "'" + TenderSubCode + "'",
                                                    tools.decimalnumber4sql(Amount) ,
                                                    NumberOf);
                                                cmd.ExecuteNonQuery();

                                                // show progress
                                                progress.StatusText = string.Format(
                                                    db.GetLangString("ImportRSM.ProgressRecord"),
                                                    ++numMSMrecords, file);
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        // some unknown error, write an error line
                                        WriteProblemLine(BookDate, "MSM", ex.Message, ex.StackTrace);
                                        ++numMSMproblems;

                                        // show progress
                                        progress.StatusText = string.Format(
                                            db.GetLangString("ImportRSM.ProgressProblemLine"),
                                            numMSMproblems, file);
                                    }
                                } // foreach MSM detail row in XML file

                                // mark in header that MSM file type has been imported
                                UpdateHeaderLine(BookDate, "MSM");

                                // calculate customer count for the day
                                // and update EODReconcileEx record
                                /* disabled as it is now done in ImportPEJ
                                int CustomerCount =
                                    ImportDataSet.Import_RPOS_MSM_DetailsDataTable.CalculateCustomerCount(BookDate);
                                EODDataSet.EODReconcileExDataTable.InsertOrUpdateRecord(BookDate, CustomerCount);*/

                            } // check that tableMSMDetail != null
                        } // check if already imported
                    }
                    catch (Exception ex)
                    {
                        log.WriteException("ImportRSM.ImportMSMFiles", ex.Message, ex.StackTrace);
                    }
                } // check that file exists
            } // foreach msm file)

            // move MSM files now imported to backup dir or delete them
            foreach (string file in msmFiles)
            {
                if (db.GetConfigStringAsBool("NAXML_Import_Backup_Active"))
                    MoveFileToBackupDir(file);
                else
                    File.Delete(file);
            }
        }

        #endregion

        #region METHOD: ExtractBookDate
        private DateTime ExtractBookDate(DataSet dsXML)
        {
            string dtTmp = dsXML.Tables["MovementHeader"].Rows[0]["BeginDate"].ToString();
            DateTime postingdate = tools.RadiantXmlDateAndTime2DateTime(dtTmp, "00:00:00");
            return postingdate;
        }
        #endregion

        #region METHOD: CheckContentExists
        /// <summary>
        /// Due to a bug in Radiant, a TPM file
        /// might be generated without any content,
        /// so a file exist with just a header. This method
        /// checks for content by checking if the table MovementHeader
        /// exists in the file. It can be used in all import methods,
        /// to ensure that all the types of RSM import
        /// files are checked for content.
        /// </summary>
        /// <returns>True if content is present. False if not.</returns>
        private bool CheckContentExists(DataSet dsXML)
        {
            try
            {
                if(dsXML.Tables.IndexOf("MovementHeader") >= 0)
                    return true;
            }
            catch { }
            return false;
        }
        #endregion

        #region METHOD: GetNextDetailsLineNo
        /// <summary>
        /// Returns the next LineNo for the given Import_RPOS_{FileType}_Details table for the given BookDate.
        /// FileType can be MCM, MSM and FGM.
        /// </summary>
        private int GetNextDetailsLineNo(DateTime BookDate, string FileType)
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.CommandText = string.Format(
                " select max([LineNo]) from Import_RPOS_{0}_Details " +
                " where BookDate = '{1}' ",
                FileType, BookDate);
            return (tools.object2int(cmd.ExecuteScalar()) + 1);
        }
        #endregion

        #region METHOD: MoveFileToBackupDir
        /// <summary>
        /// Moves the provided file to the backup dir given
        /// by the config string "NAXML_import_dir_backup"
        /// </summary>
        /// <param name="file">Full path and filename.</param>
        private void MoveFileToBackupDir(string file)
        {
            if (!File.Exists(file)) return;
            int idx = file.LastIndexOf("\\");
            if (idx >= 0)
            {
                string destFile = db.GetConfigString("NAXML_import_dir_backup") + file.Remove(0, idx);
                destFile = destFile.Replace("\\\\", "\\"); // make sure we don't have double backslashes
                if(File.Exists(destFile))
                    File.Delete(destFile); // just to be sure
                File.Move(file, destFile);
            }
        }
        #endregion

        #region METHOD: WriteProblemLine
        /// <summary>
        /// Writes a record in Import_RPOS_24H_ProblemLines.
        /// </summary>
        private void WriteProblemLine(
            DateTime BookDate,
            string FileType,
            string ProblemDesc,
            string DataExtract)
        {
            // make sure strings fit in database
            if (ProblemDesc.Length > 255)
                ProblemDesc = ProblemDesc.Remove(255);
            if (DataExtract.Length > 255)
                DataExtract = DataExtract.Remove(255);
           
            //  build and execute query
            string sql = string.Format(
                " insert into Import_RPOS_24H_ProblemLines " +
                " (BookDate,FileType,[LineNo],ProblemDesc,DataExtract) " +
                " values ({0},{1},{2},{3},{4}) ",
                  "'" + BookDate +"'" ,
                "'" + FileType + "'",
                ImportDataSet.Import_RPOS_24H_ProblemLinesDataTable.GetNextLineNo(BookDate,FileType),
                "'" + ProblemDesc + "'",
                "'" + DataExtract + "'");
            OleDbCommand cmd = new OleDbCommand(sql,db.Connection);
            cmd.ExecuteNonQuery();
        }
        #endregion

        #region METHOD: UpdateHeaderLine
        /// <summary>
        /// Writes/updates a record in Import_RPOS_24H_Header.
        /// </summary>
        private void UpdateHeaderLine(DateTime BookDate, string FileType)
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            int NumberOfProblemLines = ImportDataSet.Import_RPOS_24H_ProblemLinesDataTable.GetNumberOfProblemLines(BookDate, FileType);
            bool HeaderRecordAlreadyExists = ImportDataSet.Import_RPOS_24H_HeaderDataTable.RecordAlreadyExists(BookDate);

            // determine imported / problems columns to insert into or update
            string colImported = FileType + "Imported";
            string colProblems = FileType + "Problems";

            if (!HeaderRecordAlreadyExists)
            {
                // first time a header record is created with this BookDate
                cmd.CommandText = string.Format(
                            " insert into Import_RPOS_24H_Header " +
                            " (BookDate,{0},{1}) " +
                            " values ({2},{3},{4}) ",
                            colImported,
                            colProblems,
                            "'" + BookDate + "'",
                            1,
                            NumberOfProblemLines);
                cmd.ExecuteNonQuery();
            }
            else
            {
                // subsequent times a header record is updated with this BookDate
                cmd.CommandText = string.Format(
                            " update Import_RPOS_24H_Header set " +
                            " {0} = {1}, " +
                            " {2} = {3} " +
                            " where BookDate = {4} ",
                            colImported, 1,
                            colProblems, NumberOfProblemLines,
                            "'" + BookDate + "'");
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region METHOD: BuildFileLists
        /// <summary>
        /// Scans NAXML_Import_Dir (config string) directory for
        /// RSM (ISM, FGM, MCM, MSM and TPM) data files listed in SEM files.
        /// The result is filelists for each type assigned to this
        /// class' private filelist variables (ismFiles, fgmFiles etc.).
        /// Each filelist is sorted by date. Remember to delete the
        /// files after import. The semaphore files will be deleted if empty.
        /// Before using the resulting filelists, check the variables for null.
        /// </summary>
        private void BuildFileLists()
        {
            ResetPrivateData();

            string importDir = GetImportDir();
         
            // create new filelists
            ismFiles = new List<string>();
            fgmFiles = new List<string>();
            mcmFiles = new List<string>();
            msmFiles = new List<string>();
            tpmFiles = new List<string>();
            pejFiles = new List<string>();

            // scan list of semaphore files and collect references to data files
            string[] semaphoreFiles = Directory.GetFiles(importDir, "SEM*.xml", SearchOption.TopDirectoryOnly);
            foreach (string file in semaphoreFiles)
            {
                if (File.Exists(file))
                {
                    // open the semaphore xml document
                    XmlDocument xml = new XmlDocument();
                    xml.Load(file);

                    /// traverse all File elements in the semaphore file
                    /// and collect references to data files
                    XmlNodeList list = xml.SelectNodes("FileList/File");
                    foreach (XmlElement e in list)
                    {
                        // collect all 5 datafile types
                        for (int i = 0; i < 6; i++)
                        {
                            // select type and filelist
                            string type = "";
                            List<string> filelist = null;
                            switch (i)
                            {
                                case 0: type = "ISM"; filelist = ismFiles; break;
                                case 1: type = "FGM"; filelist = fgmFiles; break;
                                case 2: type = "MCM"; filelist = mcmFiles; break;
                                case 3: type = "MSM"; filelist = msmFiles; break;
                                case 4: type = "TPM"; filelist = tpmFiles; break;
                                case 5: type = "PEJ"; filelist = pejFiles; break; // handle Radiant bug - see ImportPEJFiles
                            }

                            // if current file is of selected type
                            if (list != null)
                            {
                                if (e.InnerText.StartsWith(type))
                                {
                                    // collect data file reference for import
                                    filelist.Add(importDir + e.InnerText);
                                }
                            }
                        }
                    }

                }
                // Gem semaphor fil inden oprydning
                if (db.GetConfigStringAsBool("ImportRSM.ImportISMFiles.CopyToDepart"))
                {
                    string destdir = db.GetConfigString("NAXML_import_dir_backup").Trim();
                    string destfile = tools.StripDirectoryFromPath(file).Trim();
                    string destpath = (destdir + "\\" + destfile).Replace("\\\\", "\\");
                    tools.RemoveFileWriteProtection(destpath);
                    File.Copy(file, destpath, true);
                }
            }
            



            // sort datafile lists by date
            ismFiles.Sort();
            fgmFiles.Sort();
            mcmFiles.Sort();
            msmFiles.Sort();
            tpmFiles.Sort();
        }
        #endregion

        #region METHOD: GetImportDir
        private static string GetImportDir()
        {
            // get import dir (is now checked for validity)
            string importDir = db.GetConfigString("NAXML_Import_Dir");

            // make sure we have a trailing backslash
            if (importDir[importDir.Length - 1] != '\\')
                importDir += "\\";
            return importDir;
        }
        #endregion

        #region METHOD: CheckImportDirsExists
        /// <summary>
        /// Checks if the input directories given in config string
        /// NAXML_Import_Dir and NAXML_Import_Dir_Backup are valid,
        /// that is, are they filled in, does the dirs exists etc.
        /// Only checks for backup dir if NAXML_Export_Backup_Active is true.
        /// If false is returned, LastError contains an error message.
        /// </summary>
        private bool ValidateImportDirs()
        {
            byte dirCount = 0;
            lastError = "";

            // get import dirs from db (use tools to make sure null is not returned)
            string NAXML_Import_Dir = tools.object2string(db.GetConfigString("NAXML_Import_Dir"));
            string NAXML_Import_Dir_Backup = tools.object2string(db.GetConfigString("NAXML_Import_Dir_Backup"));
            bool checkForBackupDir = db.GetConfigStringAsBool("NAXML_Import_Backup_Active");

            // check if import dirs has not been specified
            if (NAXML_Import_Dir == "")
            {
                lastError =  db.GetLangString("ImportRSM.ImportDirNotSpecified");
                return false;
            }
            if (checkForBackupDir && (NAXML_Import_Dir_Backup == ""))
            {
                lastError = db.GetLangString("ImportRSM.ImportBackupDirNotSpecified");
                return false;
            }

            // check if import dirs exists
            if (!Directory.Exists(NAXML_Import_Dir))
            {
                lastError += NAXML_Import_Dir + "\n";
                ++dirCount;
            }
            if (checkForBackupDir)
            {
                if (!Directory.Exists(NAXML_Import_Dir_Backup))
                {
                    lastError += NAXML_Import_Dir_Backup + "\n";
                    ++dirCount;
                }
            }
            if (dirCount > 0)
            {
                string dir = db.GetLangString("ImportRSM.Dir");
                if (dirCount > 1) dir = db.GetLangString("ImportRSM.Dirs");
                lastError = string.Format(
                    db.GetLangString("ImportRSM.ImportDirNotExist")+"\n\n", dir) + lastError;
            }
            return (dirCount == 0);
        }
        #endregion
    }
}
