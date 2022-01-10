using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GenericParsing;

namespace RBOS
{
    class ImportSparPOS
    {
        #region LastError
        private string _LastError = "";
        public string LastError
        {
            get { return _LastError; }
        }
        #endregion

        #region ImportIsActive
        public bool ImportIsActive()
        {
            return db.GetConfigStringAsBool("SparPOS.ImportActive");
        }
        #endregion

        #region ImportSparPOSTransactions
        public bool ImportSparPOSTransactions()
        {
            _LastError = "";

            // get the import dir
            string ImportDir = db.GetConfigString("SparPOS.ImportFolder");
            if (ImportDir.EndsWith("\\"))
                ImportDir = ImportDir.Substring(0, ImportDir.Length - 1);
            
            // check that import dir exists and give error if not
            if (!Directory.Exists(ImportDir))
            {
                _LastError = db.GetLangString("ImportSparPOSTransactions.ImportDirDoesNotExist");
                return false;
            }

            // get a list of files in the import dir
            string pattern = db.GetConfigString("SparPOS.ImportFilePattern");
            string[] tmpfiles = Directory.GetFiles(ImportDir, pattern, SearchOption.TopDirectoryOnly);
            List<string> files = new List<string>(tmpfiles);
            files.Sort();

            foreach (string file in files)
            {
                try
                {
                    // do not import the setup files (they fit into the file pattern)
                    if (!file.Contains("SparAccountActions.csv") && !file.Contains("SparCatMap.csv"))
                    {

                        // when we import data from the file to the transaction table,
                        // we delete records in the table that has dates that exist in the file.
                        // we keep a list of dates that was deleted from the table, so records with
                        // each date is only deleted once.
                        List<DateTime> DatesDeletedFromTable = new List<DateTime>();

                        GenericParser parser = tools.CreateCSVParser(file, ',', false);
                        while (parser.Read())
                        {
                            try
                            {
                                // read values from file
                                DateTime BookDate = tools.object2datetime(parser[0]);
                                string BookType = tools.object2string(parser[2]);
                                string Account = tools.object2string(parser[3]);
                                string Description = tools.object2string(parser[4]);
                                double Amount = tools.object2double(parser[5]);

                                // check if this date has not been deleted from the import table,
                                // and if not, check if it already exists in the import table, because
                                // then records with this date needs to be deleted from the import table.
                                if (!DatesDeletedFromTable.Contains(BookDate))
                                {
                                    if (ImportDataSet.SparPOSTransactionsDataTable.RecordsExistsWithThisDate(BookDate))
                                        ImportDataSet.SparPOSTransactionsDataTable.DeleteRecord(BookDate);
                                    DatesDeletedFromTable.Add(BookDate);
                                }

                                // create transaction record
                                ImportDataSet.SparPOSTransactionsDataTable.CreateRecord(
                                    BookDate, BookType, Account, Description, Amount);
                            }
                            catch
                            {
                                // some error in reading the line
                                _LastError = string.Format(db.GetLangString("ImportSparPOSTransactions.ErrorImportingRecord"), file);
                            }
                        }

                        /// if configured so, move the imported SparPOS to an archive folder,
                        /// otherwise delete the imported file.
                        tools.RemoveFileWriteProtection(file);
                        if (db.GetConfigStringAsBool("SparPOS.ImportBackupActive"))
                        {
                            string ArchiveFilename =
                                (db.GetConfigString("SparPOS.ImportBackupFolder") +
                                 "\\" + tools.StripDirectoryFromPath(file)).Replace(@"\\", @"\");
                            File.Move(file, ArchiveFilename);
                        }
                        else
                        {
                            File.Delete(file);
                        }
                    }
                }
                catch
                {
                    // some error in reading the file.
                    _LastError = string.Format(db.GetLangString("ImportSparPOSTransactions.ErrorImportingFile"), file);
                }
            }

            // import completed
            return true;
        }
        #endregion

        #region ImportSparCatMap
        public void ImportSparCatMap()
        {
            string Filename = (db.GetConfigString("DRS_FTP_client_arrive_dir") + "\\SparCatMap.csv").Replace("\\\\", "\\");
            if (File.Exists(Filename))
            {
                GenericParser parser = null;
                try
                {
                    // we start a transaction because if the file was
                    // empty, we want to roll back the empty of the table
                    db.StartTransaction();
                    int NumProcessRecords = 0;

                    // empty table
                    ImportDataSet.SparPOSAccountMappingDataTable.EmptyTable();

                    // import file
                    parser = tools.CreateCSVParser(Filename, ';', true);
                    while (parser.Read())
                    {
                        // protect against empty fields and duplicate records, as the importer
                        string SparPOSCategory = tools.object2string(parser["SparPOSCategory"]).TrimStart(new char[] { '0' });
                        string RBOSSubCategory = tools.object2string(parser["RBOSSubCategory"]);
                        if ((SparPOSCategory != "") && (RBOSSubCategory != "") &&
                            !ImportDataSet.SparPOSAccountMappingDataTable.RecordAlreadyExists(SparPOSCategory, RBOSSubCategory))
                        {
                            ImportDataSet.SparPOSAccountMappingDataTable.CreateRecord(SparPOSCategory, RBOSSubCategory);
                            ++NumProcessRecords;
                        }
                    }

                    // delete file after import
                    tools.RemoveFileWriteProtection(Filename);
                    File.Delete(Filename);

                    // if some records were processed, commit the transaction
                    if (NumProcessRecords > 0)
                        db.CommitTransaction();
                }
                catch (Exception ex)
                {
                    // if some exception occurs, write the exception to the log
                    // and ask user to contact support.
                    log.WriteException("ImportSparCatMap", ex.Message, ex.StackTrace);
                    string msg = db.GetLangString("ImportSparCatMap.ErrorImportingFile");
                    System.Windows.Forms.MessageBox.Show(msg);
                }
                finally
                {
                    if (parser != null)
                        parser.Close();

                    // if transaction at this time has not been committed,
                    // this means something went wrong, so rollback.
                    if (db.CurrentTransaction != null)
                        db.RollbackTransaction();
                }
            }
        }
        #endregion

        #region ImportSparAccountActions
        public void ImportSparAccountActions()
        {
            string Filename = (db.GetConfigString("DRS_FTP_client_arrive_dir") + "\\SparAccountActions.csv").Replace("\\\\", "\\");
            if (File.Exists(Filename))
            {
                GenericParser parser = null;
                try
                {
                    // we start a transaction because if the file was
                    // empty, we want to roll back the empty of the table
                    db.StartTransaction();
                    int NumProcessRecords = 0;

                    // empty table
                    ImportDataSet.SparPOSAccountActionsDataTable.EmptyTable();

                    // import file
                    parser = tools.CreateCSVParser(Filename, ';', true);
                    while (parser.Read())
                    {
                        // protect against empty fields and duplicate records, as the importer
                        string Account = tools.object2string(parser["Account"]);
                        string ActionCode = tools.object2string(parser["ActionCode"]);
                        if ((Account != "") && (ActionCode != "") &&
                            !ImportDataSet.SparPOSAccountActionsDataTable.RecordAlreadyExists(Account, ActionCode))
                        {
                            ImportDataSet.SparPOSAccountActionsDataTable.CreateRecord(Account, ActionCode);
                            ++NumProcessRecords;
                        }
                    }

                    // delete file after import
                    tools.RemoveFileWriteProtection(Filename);
                    File.Delete(Filename);

                    // if some records were processed, commit the transaction
                    if (NumProcessRecords > 0)
                        db.CommitTransaction();
                }
                catch (Exception ex)
                {
                    // if some exception occurs, write the exception to the log
                    // and ask user to contact support.
                    log.WriteException("ImportSparAccountActions", ex.Message, ex.StackTrace);
                    string msg = db.GetLangString("ImportSparAccountActions.ErrorImportingFile");
                    System.Windows.Forms.MessageBox.Show(msg);
                }
                finally
                {
                    if (parser != null)
                        parser.Close();

                    // if transaction at this time has not been committed,
                    // this means something went wrong, so rollback.
                    if (db.CurrentTransaction != null)
                        db.RollbackTransaction();
                }
            }
        }
        #endregion
    }
}
