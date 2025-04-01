using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using GenericParsing;
using System.Diagnostics;

namespace RBOS
{
    /// <summary>
    /// Version class provides version updating and maintenance.
    /// This is put in code as we dont want users to play with the versioning.
    /// NOTE: Database MUST be initialized before using this class.
    /// NOTE: If you make a metadata change to a table, and also want to
    /// make data changes to a table, be sure to do the metadata changes first.
    /// Otherwise the metadata changes won't be successful and an exception is raised.
    /// </summary>
    class Version
    {
        #region Private variables

        // version history
        private static List<string> versionHistory = null;

        // last error message
        private static string errmsg = "";

        private static string _ExePatch = "";

        #endregion

        #region Constructor
        // Constructor.
        static Version()
        {
            /// Build version history. This should be
            /// expanded for every new version we send out.
            versionHistory = new List<string>();

            versionHistory.Add("4.00.011"); // Afskrivning virker også for DO 
            _ExePatch = "0";
            _ExePatch = "0";

            /// When copying an exe-file to distribution:
            /// -----------------------------------------
            /// Rebuild in release mode and copy files for test/distribution.
            /// Add a branch.
            /// Create a release.txt document and place it with the exe-file.
            /// IMPORTANT: In release.txt, write what revision the exe-file is from and what was changed/added/fixed.
            /// IMPORTANT: Create a branch in subversion that has the code just released.
            /// Copy the text from release.txt to the release document in the project.

            /// When starting on a new version:
            /// -------------------------------
            /// Add the next version number above and add a comment about what we are going to do with it.
            /// Set _ExePatch above to "0".
            /// Add an update function for the new version.
            /// Include the new update function in the VersionUpdater switch. 
            /// Set the exe filename of the service pack project output.
            /// Set the version in lang.xml.
            /// Commit with a comment about continuing the new version.
        }
        #endregion

        #region ExeVersion
        /// <summary>
        /// The current exe-file version.
        /// </summary>
        public static string ExeVersion
        {
            get
            {
                // return the last version
                return versionHistory[versionHistory.Count - 1];
            }
        }
        #endregion

        #region ExePatch
        public static string ExePatch
        {
            get { return _ExePatch; }
        }
        #endregion

        #region LastError
        /// <summary>
        /// The last error message produced by a method.
        /// If a method returns false or other indication
        /// of failure as well as if a property has indication
        /// of failure, this property will give the error message.
        /// </summary>
        public static string LastError
        {
            get { return errmsg; }
        }
        #endregion

        #region InstalledVersion
        /// <summary>
        /// The version in the database. This will differ from the ExeVersion
        /// when a new exe-file is distributed. Once the version updater has
        /// run, the InstalledVersion will be the same as the ExeVerion.
        /// </summary>
        private static string InstalledVersion
        {
            get
            {
                string version = "";

                try
                {
                    // return version from db
                    version = db.GetConfigString("InstalledVersion");
                }
                catch { }

                // if some error occured while reading version
                // from database assume first possible version
                if (version == "")
                {
                    if (versionHistory.Count > 0)
                        version = versionHistory[0];
                    else
                        version = "0.00.000"; // really hardcoded panic value, everything has gone wrong
                }

                return version;
            }
            set
            {
                try
                {
                    // update  version in database
                    db.SetConfigString("InstalledVersion", value);
                }
                catch { }
            }
        }
        #endregion

        #region NeedNewExe property
        /// <summary>
        /// If true, the MainClass should not start the program,
        /// but instead shutdown cleanly, that is for instance,
        /// shut down the database and quit.
        /// </summary>
        private static bool _NeedNewExe = false;
        public static bool NeedNewExe
        {
            get { return _NeedNewExe; }
        }
        #endregion

        #region VersionAsLong
        // converts the provided string version to a long.
        private static long VersionAsLong(string version)
        {
            long result;
            if (long.TryParse(version.Replace(".", ""), out result))
                return result;
            else
                return 0;
        }
        #endregion

        #region VersionUpdater
        /// <summary>
        /// Updates the installed version to the version in the exe-file
        /// by running though each version to see what should be done.
        /// </summary>
        public static bool VersionUpdater()
        {
            errmsg = "";
            long installedVersion = VersionAsLong(InstalledVersion);
            long exeVersion = VersionAsLong(ExeVersion);

            // update exe if new version available
            Upd_ExeFile();
            if (NeedNewExe)
                return true; // return true to avoid error message

            // before we make any updates to the database,
            // create a version updater backup of the file,
            // and insert it's version in it's backup filename
            // (NOTE: keep it here after updating the exe)
            //if (installedVersion < exeVersion)
             //   Backup.CreateVersionUpdateBackup(installedVersion.ToString());

            // remaining code is for content update

            // import lang.xml file if existing.
            // This code always runs.
            if (!Upd_Lang()) return false;

            // find the version to update from
            foreach (string version in versionHistory)
            {
                if (installedVersion < VersionAsLong(version))
                {
                    // found a version in exe-file newer than 
                    // the installed version, so update

                    bool ok = false;
                    errmsg = "";

                    switch (version)
                    {
                        
                      

                        default: ok = true; break; // no updater available = ok as nothing to do
                    }

                    if (ok)
                    {
                        // update installed version number
                        InstalledVersion = version;
                    }
                    else
                    {
                        // some error occured, the last update did not succeed
                        if (errmsg == "")
                        {
                            // if no error message is provided at this point,
                            // it is an unknown error
                            errmsg = "Ukendt fejl i versions opdateringen. Kontakt venligst support.";
                        }
                        return false;
                    }
                }
            }

            // check for and create directories
            // pointed at in various places in the database.
            // This code always runs.
            CheckForAndCreateDirectories();

            // update content files
            // (must run after call to CheckForAndCreateDirectories)
            Upd_ContentFiles();

            // import config.txt file if existing.
            // must run after call to CheckForAndCreateDirectories.
            Upd_ConfigFile();

            /// we have a special case where we had some problems with
            /// disktilbud is not being calculated correctly, and we 
            /// haven't really found the problem yet, so we want to be
            /// able to recalculate disktilbud and created new DTV files
            /// on demand, so we can correct the problem and analyse it.
            /// therefore we allow triggering of the recalculation here.
            TriggerDTVRecalculation();            

            // version updater finished ok
            return true;
        }

        #endregion
        
        #region HandleErrorMessages
        // writes error message to log and to errmsg variable for LastError property.
        private static void HandleErrorMessages(Exception ex, string action, string version)
        {
            log.Write("------------------------------------");
            log.Write("Error upgrading to version " + version + ".");
            log.Write("Action: " + action);
            log.Write("Message: " + ex.Message);
            log.Write("Stacktrace: " + ex.StackTrace);
            log.Write("------------------------------------");
            errmsg = ex.Message;
        }
        #endregion

        #region CheckForAndCreateDirectories
        /// <summary>
        /// Checks for and creates directories refered to
        /// in various places in the database if these does not exist.
        /// </summary>
        private static void CheckForAndCreateDirectories()
        {
            List<string> dirs = new List<string>();

            // collect directories given in FTP accounts
            DataTable tableFTPAccounts =
                db.GetDataTable(" select ClientDepartureDir, ClientArrivalDir from FTPAccounts ");
            foreach (DataRow rowFTP in tableFTPAccounts.Rows)
            {
                dirs.Add(rowFTP["ClientDepartureDir"].ToString());
                dirs.Add(rowFTP["ClientArrivalDir"].ToString());
            }

            // collect directories given in config strings
            dirs.Add(db.GetConfigString("DRS_FTP_client_arrive_dir"));
            dirs.Add(db.GetConfigString("DRS_FTP_client_depart_dir"));
            if (db.GetConfigString("RegnskabIF_flag") != "")
                dirs.Add(db.GetConfigString("RegnskabIF_local_dir"));

            // create collected directories as needed
            foreach (string dir in dirs)
            {
                if ((dir != "") && (dir != null) && (!Directory.Exists(dir)))
                    Directory.CreateDirectory(dir);
            }
        }
        #endregion

        #region Upd_ExeFile

        /// <summary>
        /// Updates the current exe file with a
        /// newer or same version if available. The property
        /// NeedNewExe is set during this method.
        /// </summary>
        private static void Upd_ExeFile()
        {
            /// The idea is that when a service pack file arrives
            /// then an exe updater arrives too. The files are named as follows:
            /// Service pack file: RBOS201015SP.exe,
            /// Exe updater file:  RBOS201015.exe.
            /// The examples would be for a version 2.01.015.

            _NeedNewExe = false;

            // get sorted list of available service files.
            // (more than one service pack file may have arrived, we only use the newest)
            string arrivedir = db.GetConfigString("DRS_FTP_client_arrive_dir");
            if (Directory.Exists(arrivedir))
            {
                string[] spfilesTmp = Directory.GetFiles(arrivedir, "RBOS*SP.exe", SearchOption.TopDirectoryOnly);
                List<string> spfiles = new List<string>();
                foreach (string s in spfilesTmp)
                    spfiles.Add(s);
                spfiles.Sort();

                if (spfiles.Count > 0)
                {
                    // retrieve the newest service pack file (list is sorted)
                    // and remove it from the list
                    string spfile = spfiles[spfiles.Count - 1];
                    spfiles.RemoveAt(spfiles.Count - 1);

                    // delete from disk all the other service pack files in the list
                    // including each corresponding exe updater file.
                    foreach (string spfilePrev in spfiles)
                        DeleteServicePackFile(spfilePrev);

                    // if the service pack file exist, but the exe updater does not exist,
                    // this means that the service pack has run the update, so stop updating the exe
                    string exeupdater = spfile.ToLower().Replace("sp.exe", ".exe");
                    if (!File.Exists(exeupdater))
                    {
                        // detect running RBOSServicePack and wait for it to close
                        bool StillRunning = true;
                        while (StillRunning)
                        {
                            string RBOSServicePackProcessName = tools.GetCmdArg("RBOSServicePackProcessName");
                            Process[] allProcesses = Process.GetProcessesByName(RBOSServicePackProcessName);
                            if (allProcesses.Length <= 0)
                                StillRunning = false;
                            System.Threading.Thread.Sleep(1000);
                        }

                        // delete the service pack
                        DeleteServicePackFile(spfile);

                        return;
                    }

                    // get the version of the service pack file
                    long spversion = tools.object2long(
                        tools.StripDirectoryFromPath(spfile.ToLower()).Replace("rbos", "").Replace("sp.exe", ""));

                    // check that the service pack file has a newer or same
                    // version number than the current running exe file
                    if (spversion >= VersionAsLong(ExeVersion))
                    {
                        // convert the service pack long version number to string
                        string spversionStr = spversion.ToString();
                        if (spversionStr.Length > 4)
                        {
                            spversionStr = spversionStr.Insert(1, ".");
                            spversionStr = spversionStr.Insert(4, ".");
                        }

                        // make sure exe is not readonly
                        tools.RemoveFileWriteProtection(Application.ExecutablePath);

                        // start the service pack and exit RBOS
                        log.Write("RBOS Service Pack is going to update RBOS to version " + spversion.ToString());
                        _NeedNewExe = true;
                        Process p = new Process();
                        p.StartInfo.FileName = spfile;
                        p.StartInfo.Arguments = "";
                        p.StartInfo.Arguments += "\"RBOSProcessName=" + Process.GetCurrentProcess().ProcessName + "\"";
                        p.StartInfo.Arguments += " ";
                        p.StartInfo.Arguments += "\"RBOSExeFile=" + Application.ExecutablePath + "\"";
                        p.StartInfo.Arguments += " ";
                        p.StartInfo.Arguments += "\"NewVersion=" + spversionStr + "\"";
                        p.Start();
                        return;
                    }
                    else
                    {
                        // the newest service pack available is older than
                        // the currently running exe file, so just delete it
                        // (service pack has not been running)
                        DeleteServicePackFile(spfile);
                    }
                }
            }
        }

        #endregion

        #region DeleteServicePackFile
        /// <summary>
        /// Helper method for Upd_ExeFile(). Deletes
        /// the service pack file and all related
        /// executable files as the pdb file, exe config file,
        /// vshost file, vshost config file and the
        /// rbos exe updater for that version.
        /// </summary>
        /// <param name="spfile"></param>
        private static void DeleteServicePackFile(string spfile)
        {
            try
            {
                // delete service pack file
                if (File.Exists(spfile))
                {
                    tools.RemoveFileWriteProtection(spfile);
                    File.Delete(spfile);
                }

                // delete service pack pdb file (if debug)
                string pdbfile = spfile.ToLower().Replace(".exe", ".pdb");
                if (File.Exists(pdbfile))
                {
                    tools.RemoveFileWriteProtection(pdbfile);
                    File.Delete(pdbfile);
                }

                // delete service pack config file
                string configfile = spfile + ".config";
                if (File.Exists(configfile))
                {
                    tools.RemoveFileWriteProtection(configfile);
                    File.Delete(configfile);
                }

                // delete service pack vshost file (if running from vstudio)
                string vshostfile = spfile.ToLower().Replace(".exe", ".vshost.exe");
                if (File.Exists(vshostfile))
                {
                    tools.RemoveFileWriteProtection(vshostfile);
                    File.Delete(vshostfile);
                }

                // delete service pack vshost config file (if running from vstudio)
                string vshostconfigfile = vshostfile + ".config";
                if (File.Exists(vshostconfigfile))
                {
                    tools.RemoveFileWriteProtection(vshostconfigfile);
                    File.Delete(vshostconfigfile);
                }

                // delete exe updater file
                string exeupdater = spfile.ToLower().Replace("sp.exe", ".exe");
                if (File.Exists(exeupdater))
                {
                    tools.RemoveFileWriteProtection(exeupdater);
                    File.Delete(exeupdater);
                }
            }
            catch { }
        }

        #endregion

        #region Upd_ContentFiles
        /// <summary>
        /// Copies content files like images and dlls to
        /// their respectively correct places.
        /// Must run after call to CheckForAndCreateDirectories.
        /// </summary>
        private static void Upd_ContentFiles()
        {
            try
            {
                string arrivedir = db.GetConfigString("DRS_FTP_client_arrive_dir").Replace("\\\\", "\\");

                /// If any content files needs to 
                /// be copied to a specific place other
                /// that specified below, do it here.

                #region Move image files to img dir

                List<string> images = new List<string>();
                images.AddRange(Directory.GetFiles(arrivedir, "*.gif", SearchOption.TopDirectoryOnly));
                images.AddRange(Directory.GetFiles(arrivedir, "*.jpg", SearchOption.TopDirectoryOnly));
                images.AddRange(Directory.GetFiles(arrivedir, "*.jpeg", SearchOption.TopDirectoryOnly));
                images.AddRange(Directory.GetFiles(arrivedir, "*.bmp", SearchOption.TopDirectoryOnly));
                images.AddRange(Directory.GetFiles(arrivedir, "*.png", SearchOption.TopDirectoryOnly));
                foreach (string srcfile in images)
                {
                    string destfile = (Application.StartupPath + "\\img\\" + tools.StripDirectoryFromPath(srcfile)).Replace("\\\\", "\\");
                    if (File.Exists(srcfile))
                    {
                        tools.RemoveFileWriteProtection(destfile);
                        tools.RemoveFileWriteProtection(srcfile);
                        File.Copy(srcfile, destfile, true);
                        File.Delete(srcfile);
                    }
                }

                #endregion

                #region Move DLL files to application dir

                string[] dlls = Directory.GetFiles(arrivedir, "*.dll", SearchOption.TopDirectoryOnly);
                foreach (string srcfile in dlls)
                {
                    string destfile = (Application.StartupPath + "\\" + tools.StripDirectoryFromPath(srcfile)).Replace("\\\\", "\\");
                    if (File.Exists(srcfile))
                    {
                        tools.RemoveFileWriteProtection(destfile);
                        tools.RemoveFileWriteProtection(srcfile);
                        File.Copy(srcfile, destfile, true);
                        File.Delete(srcfile);
                    }
                }

                #endregion

                #region Move XML files to application dir

                string[] xmls = Directory.GetFiles(arrivedir, "*.xml", SearchOption.TopDirectoryOnly);
                foreach (string srcfile in xmls)
                {
                    string destfile = (Application.StartupPath + "\\" + tools.StripDirectoryFromPath(srcfile)).Replace("\\\\", "\\");
                    if (File.Exists(srcfile))
                    {
                        tools.RemoveFileWriteProtection(destfile);
                        tools.RemoveFileWriteProtection(srcfile);
                        File.Copy(srcfile, destfile, true);
                        File.Delete(srcfile);
                    }
                }

                #endregion

                #region Move RBOS.exe.config files to application dir

                string[] RBOSConfig = Directory.GetFiles(arrivedir, "RBOS.exe.config", SearchOption.TopDirectoryOnly);
                foreach (string srcfile in RBOSConfig)
                {
                    string destfile = (Application.StartupPath + "\\" + tools.StripDirectoryFromPath(srcfile)).Replace("\\\\", "\\");
                    if (File.Exists(srcfile))
                    {
                        tools.RemoveFileWriteProtection(destfile);
                        tools.RemoveFileWriteProtection(srcfile);
                        File.Copy(srcfile, destfile, true);
                        File.Delete(srcfile);
                    }
                }

                #endregion
            }
            catch { }
        }
        #endregion

        #region Upd_Lang
        /// <summary>
        /// Imports lang.xml if existing in upd directory.
        /// Must run after call to CheckForAndCreateDirectories.
        /// </summary>
        /// <returns>True if no errors occured.</returns>
        private static bool Upd_Lang()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);

            try
            {
                // check if a lang.xml file exist
                string langFile = db.GetConfigString("DRS_FTP_client_arrive_dir") + "\\lang.xml";
                if (File.Exists(langFile))
                {
                    // lang file exists, check if version header fits with this exe-version
                    XmlDocument xml = new XmlDocument();
                    xml.Load(langFile);
                    if (xml.SelectSingleNode("lang/header/version").InnerText == ExeVersion)
                    {
                        // lang file has data for this exe-version.

                        // get the lang strings
                        XmlNodeList nodes = xml.SelectNodes("lang/row");
                        if ((nodes != null) && (nodes.Count > 0))
                        {
                            // now empty the lang table and import the data from the xml file
                            // (this is done inside the if, as we only empty the lang table if the import xml file has data)
                            cmd.CommandText = " delete from lang ";
                            cmd.ExecuteNonQuery();

                            // import lang nodes
                            foreach (XmlNode n in nodes)
                            {
                                string id = n.SelectSingleNode("id").InnerText;
                                string local = n.SelectSingleNode("local").InnerText;
                                string en = n.SelectSingleNode("en").InnerText;
                                if (id != "")
                                {
                                    // @@@ change "da" column name in database and code to "local"
                                    cmd.CommandText = string.Format(
                                        " insert into lang (id,da,en) values (\"{0}\",\"{1}\",\"{2}\") ",
                                        id, local, en);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        // lang file successfully imported, delete it
                        tools.RemoveFileWriteProtection(langFile);
                        File.Delete(langFile);

                        // reload language strings into the cached list
                        string currLang = db.Language;
                        db.Language = currLang;
                    }
                }

                // no errors occured
                return true;
            }
            catch (Exception ex)
            {
                // error import lang.xml
                HandleErrorMessages(ex, "Importing lang.xml", ExeVersion);
                return false;
            }
        }
        #endregion

        #region Upd_ConfigFile
        /// <summary>
        /// Import config.txt file. It only imports allowed values.
        /// </summary>
        private static void Upd_ConfigFile()
        {
            StreamReader r = null;
            string configfile = "";
            try
            {
                string arrivedir = db.GetConfigString("DRS_FTP_client_arrive_dir");
                configfile = (arrivedir + "\\config.txt").Replace("\\\\", "\\");
                if (File.Exists(configfile))
                {
                    r = new StreamReader(configfile);
                    while (!r.EndOfStream)
                    {
                        try
                        {
                            string line = r.ReadLine();
                            if (line.Contains("="))
                            {
                                string[] pair = line.Split(new char[] { '=' });
                                string key = pair[0].Trim();
                                string value = pair[1].Trim();
                                // list of allowed keys
                                switch (key)
                                {
                                    case "ACN_Enabled":
                                    case "AgreementCode":
                                    case "AskUserWhenLLUpdatesNotTreatedYet":
                                    case "AutoCreateRBOSOrdersFromBHHT":
                                    case "Backup_CompressDB":
                                    case "Backup_ExternalBackupInterval":
                                    case "Backup_ExternalDir":
                                    case "Backup_ExternalEnabled":
                                    case "Backup_ExternalZip":
                                    case "Backup_LocalAuto":
                                    case "Backup_LocalDir":
                                    case "Backup_LocalEnabled":
                                    case "Backup_LocalZip":
                                    case "Backup_NetworkAuto":
                                    case "Backup_NetworkDir":
                                    case "Backup_NetworkEnabled":
                                    case "Backup_NetworkZip":
                                    case "Backup_NumDaysBack":
                                    case "BackupFVDFilesActive":
                                    case "BFI.Export.ArchiveDir":
                                    case "BFI.Export.FTPAccount":
                                    case "BFI.Export.LastDir":
                                    case "BHHT_Export_Backup_Active":
                                    case "BHHT_Export_Dir":
                                    case "BHHT_Export_dir_backup":
                                    case "BHHT_Import_Backup_Active":
                                    case "BHHT_Import_Dir":
                                    case "BHHT_Import_dir_backup":
                                    case "CompactAndRepair.Interval":
                                    case "CompactAndRepair.Enabled":
                                    case "DRS_FTP_client_arrive_dir":
                                    case "DRS_FTP_client_depart_dir":
                                    case "EOD.Payin.DETAIL.UnlockFields":
                                    case "EOD.Payout.DETAIL.UnlockFields":
                                    case "FullTimeHours":
                                    case "FVDExportFileDir":
                                    case "ImportFVD.AllowAutoUpdateSubCategory":
                                    case "ImportItemsCSVFrm.IncludeNewItems":
                                    case "ImportRSM.ImportPEJFiles.CopyToDepart":
                                    case "ImportSalaryHours.RenameInsteadOfDelete":
                                    case "ItemsDelete.DaysBackMinimum":
                                    case "NAXML_Export_Backup_Active":
                                    case "NAXML_Export_Dir":
                                    case "NAXML_Export_Dir_Backup":
                                    case "NAXML_Import_Backup_Active":
                                    case "NAXML_Import_Dir":
                                    case "NAXML_Import_Dir_Backup":
                                    case "NAXML_Import_MaintainDaysBack":
                                    case "NAXML_ITT_Header":
                                    case "OrderReportForm.ShowCostChecked":
                                    case "Payroll.AbsensePrintFollowPayrollPeriod":
                                    case "Payroll.AvgHrsMajorLimit":
                                    case "Payroll.AvgHrsMinorLimit":
                                    case "Payroll.InputFuncAbsenseWithText":
                                    case "RegnskabIF_flag":
                                    case "RegnskabIF_local_dir":
                                    case "SparPOS.ImportActive":
                                    case "SparPOS.ImportBackupActive":
                                    case "SparPOS.ImportBackupFolder":
                                    case "SparPOS.ImportFilePattern":
                                    case "SparPOS.ImportFolder":
                                    case "VPRG.Enabled":
                                    case "WasteRBA.Active":
                                    case "WeekFactor":
                                    case "ImportRSM.ImportISMFiles.CopyToDepart":
                                    case "TMPAmt1Ledetekst":
                                    case "TMPAmt2Ledetekst":
                                    case "TMPAmt3Ledetekst":
                                    case "TMPAmt4Ledetekst":
                                        {
                                            db.SetConfigString(key, value);
                                            break;
                                        }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            log.WriteException("Version.Upd_ConfigFile inside loop", ex.Message, ex.StackTrace);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.WriteException("Version.Upd_ConfigFile outside loop", ex.Message, ex.StackTrace);
            }
            finally
            {
                if (r != null)
                    r.Close();

                if (File.Exists(configfile))
                {
                    tools.RemoveFileWriteProtection(configfile);
                    File.Delete(configfile);
                }
            }
        }
        #endregion

        
        

        private static void TriggerDTVRecalculation()
        {
            string arrivedir = db.GetConfigString("DRS_FTP_client_arrive_dir");
            string recalcfile = (arrivedir + "\\RecalcDTV.txt").Replace("\\\\", "\\");
            if (File.Exists(recalcfile))
            {
                // read the dates out of the file
                GenericParser parser = tools.CreateCSVParser(recalcfile, ';', false);
                if (parser.Read())
                {
                    DateTime FromDate = tools.object2datetime(parser[0]);
                    DateTime ToDate = tools.object2datetime(parser[1]);
                    if (ToDate == DateTime.MinValue)
                        ToDate = DateTime.Now.Date;
                    ImportRSM importer = new ImportRSM();
                    bool ErrorsInDisktilbud_ignored;
                    importer.ReImportPEJFilesFromBackup(FromDate, ToDate, out ErrorsInDisktilbud_ignored);
                }
                // delete file
                tools.RemoveFileWriteProtection(recalcfile);
                File.Delete(recalcfile);
            }
        }

      

    }
}

