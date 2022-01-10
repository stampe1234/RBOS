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
            versionHistory.Add("2.01.000"); // first initial developer version
            versionHistory.Add("2.01.005"); // first semi-public version, used in RSM integration test
            versionHistory.Add("2.01.006"); // pilot testing 21/02-06
            versionHistory.Add("2.01.007"); // pilot testing 21/02-06, had some corrections
            versionHistory.Add("2.01.008"); // next version after pilot test send out
            versionHistory.Add("2.01.009"); // for Blommenslyst pilot release 27/6-06 and other pilots 4/7-06
            versionHistory.Add("2.01.010"); // released 2006-08-03 for all 5 pilots
            versionHistory.Add("2.01.011"); // released 2006-09-07 for FSD integration test with RSM
            versionHistory.Add("2.01.012"); // released 2006-09-12 for pilots
            versionHistory.Add("2.01.013"); // released 2006-09-21 for pilots
            versionHistory.Add("2.01.014"); // released 2006-09-26 for pilots
            versionHistory.Add("2.01.015"); // released 2006-11-21
            versionHistory.Add("2.01.016"); // released 2007-01-19
            versionHistory.Add("2.01.017"); // released 2007-04-12
            versionHistory.Add("2.01.018"); // released 2007-07-04
            versionHistory.Add("2.01.019"); // released 2007-12-19 til pilot
            versionHistory.Add("2.01.020"); // released 2008-01-02 til pilot
            versionHistory.Add("2.01.021"); // released 2008-02-08 til RBA produktion
            versionHistory.Add("2.01.022"); // released 2008-02-25 til RBA produktion
            versionHistory.Add("2.01.023"); // released 2008-03-11 til RBA+DO pilot
            versionHistory.Add("2.01.024"); // released 2008-04-30
            versionHistory.Add("2.01.025"); // released 2008-05-26
            versionHistory.Add("2.01.026"); // released 2008-07-09
            versionHistory.Add("2.01.027"); // released 2009-01-07 til BFI
            versionHistory.Add("2.01.028"); // released 2009-02-25 til BFI (actually contains some SparPOS stuff too)
            versionHistory.Add("2.01.029"); // released 2009-02-26 til DO/RBA
            versionHistory.Add("2.01.030"); // released 2009-04-03 til BFI/DO (svn revision 12)
            versionHistory.Add("2.01.031"); // released 2009-04-15 til BFI (svn revision 18)
            versionHistory.Add("2.01.032"); // released 2009-04-16 til BFI (svn revision 22)
            versionHistory.Add("2.01.033"); // released 2009-04-24 til DO (svn revision 24)
            versionHistory.Add("2.01.034"); // released 2009-08-12 til DO
            versionHistory.Add("2.01.035"); // released 2009-11-04 til RBA (er allerede på 3 piloter)
                                            // re-released 2009-11-25 til DO med nogle DO-specifikke rettelser.
                                            // starter 26.11 på patch 1 RBA
            versionHistory.Add("2.01.036"); // released for 4 pilot stations in march 2010, but a db change needed to be done in v37
            versionHistory.Add("2.01.037"); // released for 4 pilot stations in march 2010
            versionHistory.Add("2.01.038");
            versionHistory.Add("2.01.039"); // released 2010-09-20 til BFI.
            versionHistory.Add("2.01.040"); // implementing fremtidige salgspriser
            versionHistory.Add("2.01.041"); // implementing SafePay
            versionHistory.Add("2.01.042"); // implementing DETAIL version and various corrections
            versionHistory.Add("2.01.043"); // implementing disktilbud to BFI/DO
            versionHistory.Add("2.01.044"); // corrections to disktilbud
            versionHistory.Add("2.01.045"); // corrections to disktilbud
            versionHistory.Add("2.01.046"); // additions to disktilbud distributed 24.05.2011
            versionHistory.Add("2.01.047"); // additions to disktilbud
            versionHistory.Add("2.01.048"); // additions to disktilbud
            versionHistory.Add("2.01.049"); // released to DO and FSD
            versionHistory.Add("2.01.050"); // DO import debitors from Economics, RBA optællinger og forbrugsvarer, v3 upgrade system prep
            versionHistory.Add("2.01.051"); // continuing on 2.01.051. Note: v3 is in production test.
            versionHistory.Add("2.01.052");
            versionHistory.Add("2.01.053");
            versionHistory.Add("2.01.054"); // Special Salgsstatestik rapport til DETAIL
            versionHistory.Add("2.01.055"); // Supergros FTP inf opdateres
            versionHistory.Add("2.01.056"); // Safepay logik implementeres ACN Fil logik ændres
            versionHistory.Add("2.01.057"); // Udviklet i VS 2010 Access 2007 database format, ændret funktionalitet ved indtastning af ordrer
            versionHistory.Add("2.01.058"); // Nyt felt på Item tabel til håndtering af nyt vaske anlæg
            versionHistory.Add("2.01.059"); // Ændret export til rsm
            versionHistory.Add("2.01.060"); // Danske Spil funktionalitet
            versionHistory.Add("2.01.061"); // Bug med stregkoder rettet
            versionHistory.Add("2.01.062"); // Danske Spil Tabel oprettes igen
            versionHistory.Add("2.01.063"); // Danske Spil Tabel oprettes igen
            versionHistory.Add("2.01.064"); // Danske Spil Tabel oprettes igen
            versionHistory.Add("2.01.065"); // 4 dynamiske felter
            versionHistory.Add("2.01.066"); // Ny rapport + ny tabel
            versionHistory.Add("2.01.067"); // Ny Economicskode .Net framework 4.0
            versionHistory.Add("2.01.068"); // Detail version kontrol af tekst ved indbetallinger
            versionHistory.Add("2.01.069"); // DO version ny V-Power Diesel
            versionHistory.Add("2.01.070"); // DO version nyt kal til economics connect
            versionHistory.Add("2.01.071"); // DO version ny håndtering af safepay
            versionHistory.Add("4.00.000"); // Helt ny version 
            versionHistory.Add("4.00.001"); // Første version hvor vi har mulighed for at teste på enkelte stationer
            versionHistory.Add("4.00.002"); // 
            versionHistory.Add("4.00.003"); // test version med ændret safepay valuta

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
                        case "2.01.008": ok = Upd_201008(); break;
                        case "2.01.009": ok = Upd_201009(); break;
                        case "2.01.010": ok = Upd_201010(); break;
                        case "2.01.011": ok = Upd_201011(); break;
                        case "2.01.012": ok = Upd_201012(); break;
                        case "2.01.013": ok = Upd_201013(); break;
                        case "2.01.014": ok = Upd_201014(); break;
                        case "2.01.015": ok = Upd_201015(); break;
                        case "2.01.016": ok = Upd_201016(); break;
                        case "2.01.017": ok = Upd_201017(); break;
                        case "2.01.018": ok = Upd_201018(); break;
                        case "2.01.019": ok = Upd_201019(); break;
                        case "2.01.020": ok = Upd_201020(); break;
                        case "2.01.021": ok = Upd_201021(); break;
                        case "2.01.022": ok = Upd_201022(); break;
                        case "2.01.023": ok = Upd_201023(); break;
                        case "2.01.024": ok = Upd_201024(); break;
                        case "2.01.025": ok = Upd_201025(); break;
                        case "2.01.026": ok = Upd_201026(); break;
                        case "2.01.027": ok = Upd_201027(); break;
                        case "2.01.028": ok = Upd_201028(); break;
                        case "2.01.030": ok = Upd_201030(); break;
                        case "2.01.031": ok = Upd_201031(); break;
                        case "2.01.034": ok = Upd_201034(); break;
                        case "2.01.035": ok = Upd_201035(); break;
                        case "2.01.036": ok = Upd_201036(); break;
                        case "2.01.037": ok = Upd_201037(); break;
                        case "2.01.038": ok = Upd_201038(); break;
                        case "2.01.039": ok = Upd_201039(); break;
                        case "2.01.040": ok = Upd_201040(); break;
                        case "2.01.041": ok = Upd_201041(); break;
                        case "2.01.042": ok = Upd_201042(); break;
                        case "2.01.043": ok = Upd_201043(); break;
                        case "2.01.044": ok = Upd_201044(); break;
                        case "2.01.045": ok = Upd_201045(); break;
                        case "2.01.046": ok = Upd_201046(); break;
                        case "2.01.047": ok = Upd_201047(); break;
                        case "2.01.048": ok = Upd_201048(); break;
                        case "2.01.050": ok = Upd_201050(); break;
                        case "2.01.051": ok = Upd_201051(); break;
                        case "2.01.052": ok = Upd_201052(); break;
                        case "2.01.053": ok = Upd_201053(); break;
                      //  case "2.01.055": ok = Upd_201055(); break;
                        case "2.01.056": ok = Upd_201056(); break;
                        case "2.01.058": ok = Upd_201058(); break;
                        case "2.01.060": ok = Upd_201060(); break;
                        case "2.01.062": ok = Upd_201062(); break;
                        case "2.01.063": ok = Upd_201063(); break;
                        case "2.01.064": ok = Upd_201064(); break;
                        case "2.01.065": ok = Upd_201065(); break;
                        case "2.01.066": ok = Upd_201066(); break;
                        case "2.01.067": ok = Upd_201067(); break;
                        case "2.01.068": ok = Upd_201068(); break;
                        case "2.01.069": ok = Upd_201069(); break;
                        case "2.01.070": ok = Upd_201070(); break;
                        case "2.01.071": ok = Upd_201071(); break;

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

        #region SkipInV3
        /// <summary>
        /// Tell v3 to skip the given patch, as it has already been done here in v2.
        /// <param name="version">Example: "3.01.010"</param>
        /// <param name="patch">Example: 2</param>
        /// <param name="conn">An active connection</param>
        /// <param name="trans">An active transaction</param>
        /// </summary>
        private static void SkipInV3(string version, int patch, OleDbConnection conn, OleDbTransaction trans)
        {
            string sql = @"
                    insert into UpdatesApplied (VersionNo, PatchNo)
                    values (@VersionNo, @PatchNo)
                    ";
            using (OleDbCommand cmd = new OleDbCommand(sql, conn, trans))
            {
                cmd.Parameters.Add("VersionNo", SqlDbType.NVarChar).Value = version;
                cmd.Parameters.Add("PatchNo", SqlDbType.Int).Value = patch;
                cmd.ExecuteNonQuery();
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

        #region METHOD: Upd_201008
        // update from version 2.01.007 -> 2.01.008
        private static bool Upd_201008()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                #region UnitPrice changes on SalesPack table

                // add boolean field UnitPriceNotShown to SalesPack table
                cmd.CommandText = " ALTER TABLE SalesPack ADD COLUMN UnitPriceNotShown BIT; ";
                cmd.ExecuteNonQuery();

                /// update new field UnitPriceNotShown, so all records where
                /// field SalesPackType is null or 0 will have the new field
                /// set to true
                cmd.CommandText =
                    " update SalesPack " +
                    " set UnitPriceNotShown = 1 " +
                    " where (SalesPackType is null) or (SalesPackType = 0) ";
                cmd.ExecuteNonQuery();

                /// bug fix: As field SalesPack.EnhedsIndhold's GUI field has
                /// as default value of 1, the database should have a default value of
                /// 1 too. 
                cmd.CommandText =
                    " update SalesPack set EnhedsIndhold = 1 " +
                    " where (EnhedsIndhold = 0) or (EnhedsIndhold is null) ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Changes to LookupPackSize table

                // change LookupPackSize table
                cmd.CommandText = " ALTER TABLE LookupPackSize ADD COLUMN Sys BIT "; cmd.ExecuteNonQuery();

                // existing LookupPackSize records in this version are system-generated,
                // so disable user mangleling of these records
                cmd.CommandText = " update LookupPackSize set Sys = true ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Create tables for BHHT import

                // add table BHHTOrderHeader
                cmd.CommandText =
                    " CREATE TABLE BHHTOrderHeader ( " +
                    " OrderID INTEGER NOT NULL, " +
                    " SupplierID INTEGER, " +
                    " OrderDate DATETIME, " +
                    " DeliveryDate DATETIME, " +
                    " NumExcludeFromOrder INTEGER, " +
                    " Status TEXT(3) ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_BHHTOrderHeader " +
                    " ON BHHTOrderHeader (OrderID) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // add table BHHTOrderDetails
                cmd.CommandText =
                    " CREATE TABLE BHHTOrderDetails ( " +
                    " BHHTOrderID INTEGER NOT NULL, " +
                    " LineNo INTEGER NOT NULL, " +
                    " ItemID INTEGER, " +
                    " ReceiptText TEXT(30), " +
                    " Cost FLOAT, " +
                    " PackageCost FLOAT, " +
                    " SuppItemID INTEGER, " +
                    " PackType TINYINT, " +
                    " OrderingNumber FLOAT, " +
                    " Kolli INTEGER, " +
                    " Quantity INTEGER, " +
                    " ExcludeFromOrder BIT ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_BHHTOrderDetails " +
                    " ON BHHTOrderDetails (BHHTOrderID,LineNo) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // add table BHHTInvCountHeader
                cmd.CommandText =
                    " CREATE TABLE BHHTInvCountHeader ( " +
                    " CountID INTEGER NOT NULL, " +
                    " CountDate DATETIME, " +
                    " BusinessDate DATETIME, " +
                    " WorkSheetID INTEGER, " +
                    " Status TEXT(3) ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_BHHTInvCountHeader " +
                    " ON BHHTInvCountHeader (CountID) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // add table BHHTInvCountDetails
                cmd.CommandText =
                    " CREATE TABLE BHHTInvCountDetails ( " +
                    " CountID INTEGER NOT NULL, " +
                    " LineNo INTEGER NOT NULL, " +
                    " ItemID INTEGER, " +
                    " PackType TINYINT, " +
                    " Quantity INTEGER, " +
                    " TimeStmp DATETIME ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_BHHTInvCountDetails " +
                    " ON BHHTInvCountDetails (CountID,LineNo) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // add table BHHTInvAdjustHeader
                cmd.CommandText =
                    " CREATE TABLE BHHTInvAdjustHeader ( " +
                    " AdjustID INTEGER NOT NULL, " +
                    " AdjustDate DATETIME, " +
                    " BusinessDate DATETIME, " +
                    " WorkSheetID INTEGER, " +
                    " Status TEXT(3), " +
                    " ReasonCode CHAR(1) ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_BHHTInvAdjustHeader " +
                    " ON BHHTInvAdjustHeader (AdjustID) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // add table BHHTInvAdjustDetails
                cmd.CommandText =
                    " CREATE TABLE BHHTInvAdjustDetails ( " +
                    " AdjustID INTEGER NOT NULL, " +
                    " LineNo INTEGER NOT NULL, " +
                    " ItemID INTEGER, " +
                    " PackType TINYINT, " +
                    " Quantity INTEGER, " +
                    " TimeStmp DATETIME, " +
                    " Exclude BIT ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_BHHTInvAdjustDetails " +
                    " ON BHHTInvAdjustDetails (AdjustID,LineNo) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // add table LookupInvAdjustType
                cmd.CommandText =
                    " CREATE TABLE LookupInvAdjustType ( " +
                    " InvAdjustType CHAR(1) NOT NULL, " +
                    " Description TEXT(20), " +
                    " SortOrder INTEGER ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_LookupInvAdjustType " +
                    " ON LookupInvAdjustType (InvAdjustType) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // fill new table LookupInvAdjustType
                for (int i = 0; i < 5; i++)
                {
                    string type = "";
                    string desc = "";
                    int sort = 0;
                    switch (i)
                    {
                        case 0: type = "w"; desc = "Afskrivninger"; sort = 2; break;
                        case 1: type = "r"; desc = "Modtag"; sort = 3; break;
                        case 2: type = "t"; desc = "Overførsel"; sort = 4; break;
                        case 3: type = "a"; desc = "Justering"; sort = 5; break;
                        case 4: type = "x"; desc = "Alle"; sort = 1; break;
                    }
                    cmd.CommandText = string.Format(
                        " insert into LookupInvAdjustType (InvAdjustType,Description,SortOrder) " +
                        " values ('{0}','{1}', {2}) ",
                        type, desc, sort);
                    cmd.ExecuteNonQuery();
                }

                #endregion

                #region BHHT export/import dir setup
                db.SetConfigString("BHHT_Export_Dir", "N:\\BHHTImport");
                db.SetConfigString("BHHT_Export_Backup_Active", "true");
                db.SetConfigString("BHHT_Export_dir_backup", "N:\\BHHTImport\\backup");
                db.SetConfigString("BHHT_Import_Dir", "N:\\BHHTExport");
                db.SetConfigString("BHHT_Import_Backup_Active", "true");
                db.SetConfigString("BHHT_Import_dir_backup", "N:\\BHHTExport\\backup");
                #endregion

                #region RSM export/import dir setup
                db.SetConfigString("NAXML_Export_Dir", "N:\\NAXMLImport");
                db.SetConfigString("NAXML_Export_Dir_Backup", "N:\\NAXMLImport\\backup");
                db.SetConfigString("NAXML_Import_Dir", "N:\\NAXMLExport");
                db.SetConfigString("NAXML_Import_Dir_Backup", "N:\\NAXMLExport\\backup");
                #endregion

                # region Create table LookupStatus

                // add table LookupStatus
                cmd.CommandText =
                    " CREATE TABLE LookupStatus ( " +
                    " StatusID TEXT(3) NOT NULL, " +
                    " Description TEXT(20) ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_LookupStatus " +
                    " ON LookupStatus (StatusID) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // fill in lookup table
                for (int i = 0; i < 3; i++)
                {
                    string status = "";
                    string desc = "";
                    switch (i)
                    {
                        case 0: status = "OPN"; desc = "Åben"; break;
                        case 1: status = "BKD"; desc = "Bogført"; break;
                        case 2: status = "SNT"; desc = "Sendt"; break;
                    }
                    cmd.CommandText = string.Format(
                        " insert into LookupStatus (StatusID,Description) " +
                        " values ('{0}','{1}') ",
                        status, desc);
                    cmd.ExecuteNonQuery();
                }

                #endregion

                #region Create tables OrderHeader and OrderDetails

                // create table OrderHeader
                cmd.CommandText =
                    " CREATE TABLE OrderHeader ( " +
                    " OrderID COUNTER NOT NULL, " +
                    " SupplierID INTEGER, " +
                    " OrderDate DATETIME, " +
                    " DeliveryDate DATETIME, " +
                    " SentDate DATETIME, " +
                    " BHHTOrderID INTEGER, " +
                    " OrderStatus TEXT(3), " +
                    " NumberDetails INTEGER, " +
                    " TotalCost FLOAT ) ";
                cmd.ExecuteNonQuery();
                // create index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_OrderHeader " +
                    " ON OrderHeader (OrderID) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // create table OrderDetails
                cmd.CommandText =
                    " CREATE TABLE OrderDetails ( " +
                    " OrderID INTEGER NOT NULL, " +
                    " LineNo INTEGER NOT NULL, " +
                    " SuppItemID INTEGER, " +
                    " OrderingNumber FLOAT, " +
                    " KolliSize INTEGER, " +
                    " PackageCost FLOAT, " +
                    " PackType TINYINT, " +
                    " ReceiptText TEXT(30), " +
                    " Cost FLOAT, " +
                    " Quantity INTEGER, " +
                    " ReceivedQuantity INTEGER ) ";
                cmd.ExecuteNonQuery();
                // create index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_OrderDetails " +
                    " ON OrderDetails (OrderID,LineNo) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Create tables OrderDraft and OrderDraftDetails

                // create table OrderDraft
                cmd.CommandText =
                    " CREATE TABLE OrderDraft ( " +
                    " DraftID COUNTER NOT NULL, " +
                    " DraftName TEXT(255), " +
                    " SupplierID INTEGER ) ";
                cmd.ExecuteNonQuery();
                // create index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_OrderDraft " +
                    " ON OrderDraft (DraftID) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // create table OrderDraftDetails
                cmd.CommandText =
                    " CREATE TABLE OrderDraftDetails ( " +
                    " DraftID INTEGER NOT NULL, " +
                    " LineNo INTEGER NOT NULL, " +
                    " SuppItemID INTEGER, " +
                    " OrderingNumber FLOAT, " +
                    " KolliSize INTEGER, " +
                    " PackageCost FLOAT, " +
                    " PackType TINYINT, " +
                    " ReceiptText TEXT(30), " +
                    " Cost FLOAT, " +
                    " Quantity INTEGER, " +
                    " ReceivedQuantity INTEGER ) ";
                cmd.ExecuteNonQuery();
                // create index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_OrderDraftDetails " +
                    " ON OrderDraftDetails (DraftID,LineNo) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Misc. config values

                db.SetConfigString("AutoCreateRBOSOrdersFromBHHT", "true");
                db.RemoveConfigString("MainForm.toolStripButtons.Top");
                db.RemoveConfigString("MainForm.toolStripButtons.Left");
                db.RemoveConfigString("MainForm.toolStripShortcuts.Top");
                db.RemoveConfigString("MainForm.toolStripShortcuts.Left");

                #endregion

                #region Create FTPAccounts table and add a couple of accounts

                cmd.CommandText =
                    " CREATE TABLE FTPAccounts ( " +
                    " ID COUNTER NOT NULL, " +
                    " AccountName TEXT(255), " +
                    " ClientDepartureDir TEXT(255), " +
                    " ClientArrivalDir TEXT(255), " +
                    " ServerDepartureDir TEXT(255), " +
                    " ServerArrivalDir TEXT(255), " +
                    " Host TEXT(255), " +
                    " Port INTEGER, " +
                    " Username TEXT(255), " +
                    " Passwd TEXT(255), " + // "Password" is reserved in Access
                    " Passive BIT, " +
                    " TransferType TEXT(10), " +
                    " ProxyHost TEXT(255), " +
                    " ProxyPort INTEGER, " +
                    " ProxyUsername TEXT(255), " +
                    " ProxyPassword TEXT(255) ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_FTPAccounts " +
                    " ON FTPAccounts (ID) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // add DRS Test account
                cmd.CommandText =
                    " INSERT INTO FTPAccounts " +
                    " (AccountName,ClientDepartureDir,ClientArrivalDir,ServerDepartureDir,ServerArrivalDir,Host,Port,Username,Passwd,Passive,TransferType) " +
                    " values ('DRS Test Account','c:\\DRS\\depart','c:\\DRS\\arrive','depart','arrive','ftp2.danskretail.dk',21,'drs0032','vte499sq',false,'ascii') ";
                cmd.ExecuteNonQuery();

                // add NordData account
                // @@@ complete account details when it is safe to do it
                cmd.CommandText =
                    " INSERT INTO FTPAccounts " +
                    " (AccountName,ClientDepartureDir,ClientArrivalDir,ServerDepartureDir,ServerArrivalDir,Host,Port,Username,Passwd,Passive,TransferType) " +
                    " values ('Norddata FTP Account','c:\\DRS\\depart','c:\\DRS\\arrive','depart','arrive','',21,'','',false,'ascii') ";
                cmd.ExecuteNonQuery();

                // create the needed directories
                string dirDepart = "c:\\DRS\\depart";
                string dirArrive = "c:\\DRS\\arrive";
                if (!Directory.Exists(dirArrive))
                    Directory.CreateDirectory(dirArrive);
                if (!Directory.Exists(dirDepart))
                    Directory.CreateDirectory(dirDepart);

                #endregion

                #region Add SendMode column to Supplier table and add values

                // add SendMode column to Supplier table
                cmd = new OleDbCommand("", db.Connection);
                cmd.Transaction = db.CurrentTransaction;
                cmd.CommandText = " ALTER TABLE Supplier ADD COLUMN SendMode TEXT(3); "; cmd.ExecuteNonQuery();
                cmd.CommandText = " ALTER TABLE Supplier ADD COLUMN FTPAccountID INTEGER; "; cmd.ExecuteNonQuery();
                cmd.CommandText = " ALTER TABLE Supplier ADD COLUMN OrderFileFormat TEXT(3); "; cmd.ExecuteNonQuery();

                // set default 'FAX' SendMode for all supplier rows
                cmd.CommandText = " update Supplier set SendMode = 'FAX' ";
                cmd.ExecuteNonQuery();

                // set randomly 'FTP' SendMode for some suppliers
                // @@@ REMOVE WHEN WE HAVE THE CORRECT LIST OF SUPPLIERS THAT USES FTP SENDMODE
                cmd.CommandText =
                    " update Supplier set SendMode = 'FTP' " +
                    " where (SupplierID = 4) " +    // Lekkerland
                    " or (SupplierID = 6) " +      // Frisko Is
                    " or (SupplierID = 22) " +     // KIMs A/S
                    " or (SupplierID = 163) ";     // Jydske Vestkysten
                cmd.ExecuteNonQuery();

                // set OrderFileFormat = 'NOR' (NordData)
                // for supplier rows that have SendMode = FTP
                cmd.CommandText = " update Supplier set OrderFileFormat = 'NOR' where SendMode = 'FTP' ";
                cmd.ExecuteNonQuery();

                // set FTPAccountID = 1 (DRS Test Account) 
                // @@@ // (2 = NordData FTP Account created in this update too)
                // for supplier rows that have SendMode = FTP
                cmd.CommandText = " update Supplier set FTPAccountID = 1 where SendMode = 'FTP' ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Fix table Supplier whitespaces in column Description

                cmd.CommandText = " update Supplier set Description = Trim(Description) ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Add rows to LookupItemTransactionType table

                cmd.CommandText =
                    " insert into LookupItemTransactionType " +
                    " (TransactionType,Description) " +
                    " values (6,'Modtag') ";
                cmd.ExecuteNonQuery();

                cmd.CommandText =
                    " insert into LookupItemTransactionType " +
                    " (TransactionType,Description) " +
                    " values (7,'Overførsel') ";
                cmd.ExecuteNonQuery();

                cmd.CommandText =
                    " insert into LookupItemTransactionType " +
                    " (TransactionType,Description) " +
                    " values (8,'OptReg') ";
                cmd.ExecuteNonQuery();

                cmd.CommandText =
                    " insert into LookupItemTransactionType " +
                    " (TransactionType,Description) " +
                    " values (9,'SalgOpt') ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Inverting existing NumberOf and Amount values in table ItemTransaction

                /// inverting the existing NumberOf and Amount values in table ItemTransaction
                /// if type is sales, because sales always 
                cmd.CommandText = string.Format(
                    " update ItemTransaction set " +
                    " NumberOf = -NumberOf, " +
                    " Amount = -Amount, " +
                    " NoOfSellingUnits = -NoOfSellingUnits " +
                    " where TransactionType = {0} ",
                    (byte)db.TransactionTypes.Sales);
                cmd.ExecuteNonQuery();

                #endregion

                #region Delete tables Import_RPOS_ISM_Files and Import_RPOS_ISM_ProblemLines

                cmd.CommandText = " DROP TABLE Import_RPOS_ISM_Files ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = " DROP TABLE Import_RPOS_ISM_ProblemLines ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Create 24H RSM import tables

                // add table Import_RPOS_24H_Header
                cmd.CommandText =
                    " CREATE TABLE Import_RPOS_24H_Header ( " +
                    " BookDate DATETIME NOT NULL, " +
                    " FGMImported BIT, " +
                    " FGMProblems INTEGER, " +
                    " MCMImported BIT, " +
                    " MCMProblems INTEGER, " +
                    " MSMImported BIT, " +
                    " MSMProblems INTEGER, " +
                    " ISMImported BIT, " +
                    " ISMProblems INTEGER, " +
                    " TPMImported BIT, " +
                    " TPMProblems INTEGER, " +
                    " Reconciled BIT ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_Import_RPOS_24H_Header " +
                    " ON Import_RPOS_24H_Header (BookDate) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // add table Import_RPOS_MCM_Details
                cmd.CommandText =
                    " CREATE TABLE Import_RPOS_MCM_Details ( " +
                    " BookDate DATETIME NOT NULL, " +
                    " LineNo INTEGER NOT NULL, " +
                    " MerchCode TEXT(20), " +
                    " SalesQuantity INTEGER, " +
                    " SalesAmount FLOAT ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_Import_RPOS_MCM_Details " +
                    " ON Import_RPOS_MCM_Details (BookDate,LineNo) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // add table Import_RPOS_FGM_Details
                cmd.CommandText =
                    " CREATE TABLE Import_RPOS_FGM_Details ( " +
                    " BookDate DATETIME NOT NULL, " +
                    " LineNo INTEGER NOT NULL, " +
                    " FuelGradeID INTEGER, " +
                    " SalesVolume FLOAT, " +
                    " SalesAmount FLOAT, " +
                    " PumpTestVolume FLOAT, " +
                    " PumpTestAmount FLOAT) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_Import_RPOS_FGM_Details " +
                    " ON Import_RPOS_FGM_Details (BookDate,LineNo) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // add table Import_RPOS_TPM_Details
                cmd.CommandText =
                    " CREATE TABLE Import_RPOS_TPM_Details ( " +
                    " BookDate DATETIME NOT NULL, " +
                    " TankID INTEGER NOT NULL, " +
                    " TReadingDateTime DATETIME, " +
                    " FuelProductID INTEGER, " +
                    " ReadingVolume FLOAT ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_Import_RPOS_TPM_Details " +
                    " ON Import_RPOS_TPM_Details (BookDate,TankID) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // add table Import_RPOS_MSM_Details
                cmd.CommandText =
                    " CREATE TABLE Import_RPOS_MSM_Details ( " +
                    " BookDate DATETIME NOT NULL, " +
                    " LineNo INTEGER NOT NULL, " +
                    " SummaryCode INTEGER, " +
                    " SubCode INTEGER, " +
                    " Modifier TEXT(8), " +
                    " TenderCode TEXT(4), " +
                    " TenderSubCode TEXT(4), " +
                    " Amount FLOAT, " +
                    " NumberOf INTEGER ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_Import_RPOS_MSM_Details " +
                    " ON Import_RPOS_MSM_Details (BookDate,LineNo) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // add table Import_RPOS_MSM_Config
                cmd.CommandText =
                    " CREATE TABLE Import_RPOS_MSM_Config ( " +
                    " ID COUNTER NOT NULL, " +
                    " SummaryCode INTEGER, " +
                    " SubCode INTEGER, " +
                    " Modifier TEXT(8), " +
                    " Description TEXT(50), " +
                    " ModifierDesc TEXT(50), " +
                    " TenderCode TEXT(4), " +
                    " TenderSubCode TEXT(4), " +
                    " IncludeInImport BIT, " +
                    " IncludeAction TEXT(4), " +
                    " IncludeCode TEXT(10) ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_Import_RPOS_MSM_Config " +
                    " ON Import_RPOS_MSM_Config (ID) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // add table Import_RPOS_24H_ProblemLines
                cmd.CommandText =
                    " CREATE TABLE Import_RPOS_24H_ProblemLines ( " +
                    " BookDate DATETIME NOT NULL, " +
                    " FileType TEXT(4) NOT NULL, " +
                    " LineNo INTEGER NOT NULL, " +
                    " ProblemDesc TEXT(255), " +
                    " DataExtract TEXT(255) ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_Import_RPOS_24H_ProblemLines " +
                    " ON Import_RPOS_24H_ProblemLines (BookDate,FileType,LineNo) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Add fields to table SiteInformation

                cmd.CommandText = " ALTER TABLE SiteInformation ADD COLUMN SE TEXT(10) "; cmd.ExecuteNonQuery();
                cmd.CommandText = " ALTER TABLE SiteInformation ADD COLUMN NorddataKundenr TEXT(6) "; cmd.ExecuteNonQuery();

                #endregion

                #region Add fields to table LookupTaxID and fill in data in existing records

                // add field TaxSymbol
                cmd.CommandText = " ALTER TABLE LookupTaxID ADD COLUMN TaxSymbol VARCHAR(1) "; cmd.ExecuteNonQuery();

                // fill in data in existing records
                cmd.CommandText = " UPDATE LookupTaxID SET TaxSymbol = 'A' where TaxPct = 25 "; cmd.ExecuteNonQuery();
                cmd.CommandText = " UPDATE LookupTaxID SET TaxSymbol = 'B' where TaxPct = 0 "; cmd.ExecuteNonQuery();

                #endregion

                #region Create tables for BHHT Worksheets

                // create table BHHTWorksheet
                cmd.CommandText =
                    " CREATE TABLE BHHTWorksheet ( " +
                    " ID COUNTER NOT NULL, " +
                    " Name TEXT(50), " +
                    " Type CHAR(1), " +
                    " Include CHAR(1) ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_BHHTWorksheet " +
                    " ON BHHTWorksheet (ID) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // create table BHHTWSCatList
                cmd.CommandText =
                    " CREATE TABLE BHHTWSCatList ( " +
                    " ID COUNTER NOT NULL, " +
                    " WSID INTEGER, " +
                    " SubCategoryID TEXT(20) ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_BHHTWSCatList " +
                    " ON BHHTWSCatList (ID) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // create table BHHTWSItemList
                cmd.CommandText =
                    " CREATE TABLE BHHTWSItemList ( " +
                    " ID COUNTER NOT NULL, " +
                    " WSID INTEGER, " +
                    " ItemID INTEGER ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_BHHTWSItemList " +
                    " ON BHHTWSItemList (ID) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Create table LookupKolliSize and add data

                // create table LookupKolliSize
                cmd.CommandText =
                    " CREATE TABLE LookupKolliSize ( " +
                    " KolliSize SMALLINT NOT NULL, " +
                    " Description TEXT(20), " +
                    " BHHTID int ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_LookupKolliSize " +
                    " ON LookupKolliSize (KolliSize) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // add rows to LookupKolliSize table. this is
                // done by traversing all supplieritem rows and collecting
                // all different kollisizes in that table
                // (could have used an adapter and a table, but this is fun and just as good :))
                cmd.CommandText =
                    " SELECT DISTINCT KolliSize " +
                    " FROM SupplierItem " +
                    " WHERE (KolliSize IS NOT NULL) " +
                    " ORDER BY KolliSize ";
                OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
                while (reader.Read())
                {
                    short kollisize = reader.GetInt16(0);
                    string desc = kollisize.ToString() + "-PK";
                    int bhhtid = 1000 + kollisize;
                    OleDbCommand cmdKolli = new OleDbCommand("", db.Connection);
                    cmdKolli.CommandText = string.Format(
                        " INSERT INTO LookupKolliSize " +
                        " (KolliSize,Description,BHHTID) " +
                        " values ({0},'{1}',{2}) ",
                        kollisize, desc, bhhtid);
                    cmdKolli.Transaction = db.CurrentTransaction;
                    cmdKolli.ExecuteNonQuery();
                }
                reader.Close();

                #endregion

                #region Create indexes on table SupplierItem to gain performance
                cmd.CommandText =
                    " CREATE INDEX idx_ItemID_SupplierItem " +
                    " ON SupplierItem (ItemID) ";
                cmd.ExecuteNonQuery();
                cmd.CommandText =
                    " CREATE INDEX idx_ItemIDSellingPackType_SupplierItem " +
                    " ON SupplierItem (ItemID,SellingPackType) ";
                cmd.ExecuteNonQuery();
                cmd.CommandText =
                    " CREATE INDEX idx_SellingPackType_SupplierItem " +
                    " ON SupplierItem (SellingPackType) ";
                cmd.ExecuteNonQuery();
                cmd.CommandText =
                    " CREATE INDEX idx_SupplierNo_SupplierItem " +
                    " ON SupplierItem (SupplierNo) ";
                cmd.ExecuteNonQuery();
                #endregion

                #region Create tables for processing and booking inventory count

                // create table BHHT_RSM_PEJSales
                cmd.CommandText =
                    " CREATE TABLE BHHT_RSM_PEJSales ( " +
                    " LineNo COUNTER NOT NULL, " +
                    " BHHTCountID INTEGER, " +
                    " ItemID INTEGER, " +
                    " SalesDateTime DATETIME, " +
                    " NoOfSold INTEGER, " +
                    " PackType TINYINT, " +
                    " SellingUnitSold INTEGER ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_BHHT_RSM_PEJSales " +
                    " ON BHHT_RSM_PEJSales (LineNo) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // create table InvCountWork
                cmd.CommandText =
                    " CREATE TABLE InvCountWork ( " +
                    " BHHTCountID INTEGER NOT NULL, " +
                    " ItemID INTEGER NOT NULL, " +
                    " CountDate DATETIME, " +
                    " SubCategory TEXT(20), " +
                    " StartOnHand INTEGER, " +
                    " SalesPEJ INTEGER, " +
                    " OnHandCalc INTEGER, " +
                    " CountTime DATETIME, " +
                    " CountBHHT INTEGER, " +
                    " ManCorrect INTEGER, " +
                    " CountDifference INTEGER, " +
                    " CostPrice FLOAT, " +
                    " StockValue FLOAT, " +
                    " DiffValue FLOAT ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_InvCountWork " +
                    " ON InvCountWork (BHHTCountID,ItemID) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // create table BookedInvCountHeader
                cmd.CommandText =
                    " CREATE TABLE BookedInvCountHeader ( " +
                    " ID COUNTER NOT NULL, " +
                    " BookDate DATETIME, " +
                    " SubCategory TEXT(20), " +
                    " TotalStockValue FLOAT, " +
                    " TotalDIffValue FLOAT, " +
                    " ExportedAccounting BIT ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_BookedInvCountHeader " +
                    " ON BookedInvCountHeader (ID) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // create table BookedInvCountDetail
                cmd.CommandText =
                    " CREATE TABLE BookedInvCountDetail ( " +
                    " LineNo INTEGER NOT NULL, " +
                    " HeaderID INTEGER NOT NULL, " +
                    " ItemID INTEGER, " +
                    " StartOnHand INTEGER, " +
                    " SalesPEJ INTEGER, " +
                    " CountTime DATETIME, " +
                    " CountBHHT INTEGER, " +
                    " ManCorrect INTEGER, " +
                    " ActualCount INTEGER, " +
                    " CostPrice FLOAT ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_BookedInvCountDetail " +
                    " ON BookedInvCountDetail (LineNo,HeaderID) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Set InStock on all items with transactions

                // set InStock on all items to the sum of NoOfSellingUnits
                // in ItemTransaction for each item found there.
                DataTable tableItemTransaction = db.GetDataTable(
                    " select ItemID, sum(NoOfSellingUnits) as SumVal " +
                    " from ItemTransaction " +
                    " group by ItemID ");
                foreach (DataRow row in tableItemTransaction.Rows)
                {
                    int sumval = tools.object2int(row["SumVal"]);
                    int itemid = tools.object2int(row["ItemID"]);
                    db.ExecuteNonQuery(string.Format(
                        " update Item " +
                        " set InStock = {0} " +
                        " where ItemID = {1} ",
                        sumval, itemid));
                }

                #endregion

                #region Create lookup tables for BHHTWorksheet and add data to them

                // create table LookupWSType
                cmd.CommandText =
                    " CREATE TABLE LookupWSType ( " +
                    " ID TEXT(1) NOT NULL, " +
                    " Description TEXT(20) ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_LookupWSType " +
                    " ON LookupWSType (ID) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // create table LookupWSInclude
                cmd.CommandText =
                    " CREATE TABLE LookupWSInclude ( " +
                    " ID TEXT(1) NOT NULL, " +
                    " Description TEXT(20) ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_LookupWSInclude " +
                    " ON LookupWSInclude (ID) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // add data to table LookupWSInclude
                cmd.CommandText =
                    " insert into LookupWSInclude (ID,Description) " +
                    " values ('c','Kategori') ";
                cmd.ExecuteNonQuery();
                cmd.CommandText =
                    " insert into LookupWSInclude (ID,Description) " +
                    " values ('i','Vare') ";
                cmd.ExecuteNonQuery();
                cmd.CommandText =
                    " insert into LookupWSInclude (ID,Description) " +
                    " values ('a','Alle') ";
                cmd.ExecuteNonQuery();

                // add data to table LookupWSType
                cmd.CommandText =
                    " insert into LookupWSType (ID,Description) " +
                    " values ('c','Optælling') ";
                cmd.ExecuteNonQuery();
                cmd.CommandText =
                    " insert into LookupWSType (ID,Description) " +
                    " values ('a','Justering') ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Create tables for EOD (End Of Day)

                // create table EODReconcile
                cmd.CommandText =
                    " CREATE TABLE EODReconcile ( " +
                    " BookDate DATETIME NOT NULL, " +
                    " Closed BIT, " +
                    " RSMDataImported BIT, " +
                    " BankDepAmount FLOAT, " +
                    " BankCardAmount FLOAT, " +
                    " ShellCardAmount FLOAT, " +
                    " MiscCards FLOAT, " +
                    " ManDankortSumB FLOAT, " +
                    " CashDiscount FLOAT, " +
                    " DriveOffTotal FLOAT, " +
                    " LocalCredit FLOAT, " +
                    " LocalCreditPayin FLOAT, " +
                    " ForeignCurrency FLOAT, " +
                    " POSSales FLOAT, " +
                    " ManualSales FLOAT, " +
                    " Payin FLOAT, " +
                    " Payout FLOAT, " +
                    " CashOverUnder FLOAT, " +
                    " TotalBank FLOAT, " +
                    " TotalShell FLOAT, " +
                    " TotalMisc FLOAT, " +
                    " TotalSales FLOAT, " +
                    " TotalABC FLOAT, " +
                    " TotalD FLOAT, " +
                    " ApprovedBy TEXT(50) ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_EODReconcile " +
                    " ON EODReconcile (BookDate) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // create table EOD_BankDep
                cmd.CommandText =
                    " CREATE TABLE EOD_BankDep ( " +
                    " BookDate DATETIME NOT NULL, " +
                    " LineNo INTEGER NOT NULL, " +
                    " Description TEXT(25), " +
                    " Amount FLOAT ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE INDEX idx_EOD_BankDep " +
                    " ON EOD_BankDep (BookDate,LineNo) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // create table EOD_BankCards
                cmd.CommandText =
                    " CREATE TABLE EOD_BankCards ( " +
                    " BookDate DATETIME NOT NULL, " +
                    " LineNo INTEGER NOT NULL, " +
                    " MOPCode TEXT(10), " +
                    " Description TEXT(25), " +
                    " Amount FLOAT ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE INDEX idx_EOD_BankCards " +
                    " ON EOD_BankCards (BookDate,LineNo) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // create table EOD_ShellCards
                cmd.CommandText =
                    " CREATE TABLE EOD_ShellCards ( " +
                    " BookDate DATETIME NOT NULL, " +
                    " LineNo INTEGER NOT NULL, " +
                    " MOPCode TEXT(10), " +
                    " Description TEXT(25), " +
                    " Amount FLOAT ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE INDEX idx_EOD_ShellCards " +
                    " ON EOD_ShellCards (BookDate,LineNo) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // create table EOD_LocalCred
                cmd.CommandText =
                    " CREATE TABLE EOD_LocalCred ( " +
                    " BookDate DATETIME NOT NULL, " +
                    " LineNo INTEGER NOT NULL, " +
                    " TransType TINYINT NOT NULL, " +
                    " CustomerNo INTEGER, " +
                    " CustomerName TEXT(50), " +
                    " Remark TEXT(25), " +
                    " Amount FLOAT ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE INDEX idx_EOD_LocalCred " +
                    " ON EOD_LocalCred (BookDate,LineNo,TransType) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // create table EOD_Sales
                cmd.CommandText =
                    " CREATE TABLE EOD_Sales ( " +
                    " BookDate DATETIME NOT NULL, " +
                    " LineNo INTEGER NOT NULL, " +
                    " TransType TINYINT NOT NULL, " +
                    " SubCategory TEXT(20), " +
                    " SubCatDesc TEXT(50), " +
                    " GLFinance INTEGER, " +
                    " GlFinDesc TEXT(25), " +
                    " NumberOf FLOAT, " +
                    " Amount FLOAT ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE INDEX idx_EOD_Sales " +
                    " ON EOD_Sales (BookDate,LineNo,TransType) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // create table EOD_PayinPayout
                cmd.CommandText =
                    " CREATE TABLE EOD_PayinPayout ( " +
                    " BookDate DATETIME NOT NULL, " +
                    " LineNo INTEGER NOT NULL, " +
                    " Transtype TINYINT NOT NULL, " +
                    " Description TEXT(25), " +
                    " Amount FLOAT ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE INDEX idx_EOD_PayinPayout " +
                    " ON EOD_PayinPayout (BookDate,LineNo,TransType) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Recalculate certain Item's CostPriceLatest and Margin

                // loop each item that has a CostPriceLatest value
                // between 0.00 and 0.05. re-calculate CostPriceLatest
                // and Margin using existing methods in the tools class.
                DataTable itemTable = db.GetDataTable(
                    " select * from Item " +
                    " where (CostPriceLatest >= 0) and (CostPriceLatest <= 0.05) ");
                foreach (DataRow row in itemTable.Rows)
                {
                    double budgetmargin = tools.object2double(row["BudgetMargin"]);
                    double salesprice = tools.object2double(row["POSSalesPrice"]);
                    double costprice = tools.CalcCostPrice(budgetmargin, salesprice);
                    double margin = tools.CalcMargin(salesprice, costprice);
                    db.ExecuteNonQuery(string.Format(
                        " update Item set " +
                        " CostPriceLatest = '{0}', " +
                        " Margin = '{1}' " +
                        " where ItemID = {2} ",
                        costprice, margin, tools.object2int(row["ItemID"])));
                }

                #endregion

                #region Insert some sample Worksheets

                // create a worksheet header and a catlist record
                int wsid = ItemDataSet.BHHTWorksheetDataTable.CreateNewRecord("Cigaretter", 'c', 'c');
                ItemDataSet.BHHTWSCatListDataTable.CreateNewRecord(wsid, "201020101");

                // create another worksheet and some catlist records
                wsid = ItemDataSet.BHHTWorksheetDataTable.CreateNewRecord("Tobak", 'c', 'c');
                ItemDataSet.BHHTWSCatListDataTable.CreateNewRecord(wsid, "201020201");
                ItemDataSet.BHHTWSCatListDataTable.CreateNewRecord(wsid, "201020301");
                ItemDataSet.BHHTWSCatListDataTable.CreateNewRecord(wsid, "201020401");
                ItemDataSet.BHHTWSCatListDataTable.CreateNewRecord(wsid, "201020501");

                #endregion

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, "2.01.008");
                return false;
            }
        }
        #endregion

        #region METHOD: Upd_201009
        // update from version 2.01.008 -> 2.01.009
        private static bool Upd_201009()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                #region Add columns CostPrice and Exported to ItemTransaction and do some related updating

                // add columns CostPrice and Exported to ItemTransaction
                cmd.CommandText = " ALTER TABLE ItemTransaction ADD COLUMN CostPrice FLOAT "; cmd.ExecuteNonQuery();
                cmd.CommandText = " ALTER TABLE ItemTransaction ADD COLUMN Exported BIT "; cmd.ExecuteNonQuery();

                // insert costprices from items in itemtransaction rows of type sales (1)
                using (DataTable table = db.GetDataTable(" select ItemID, CostPriceLatest from Item "))
                {
                    foreach (DataRow row in table.Rows)
                    {
                        OleDbCommand cmdItemTransaction = new OleDbCommand();
                        cmdItemTransaction.Connection = db.Connection;
                        cmdItemTransaction.Transaction = db.CurrentTransaction;
                        cmdItemTransaction.CommandText = string.Format(
                            " update ItemTransaction set " +
                            " CostPrice = '{0}' " +
                            " where ItemID = {1} " +
                            " and TransactionType = {2} ",
                            row["CostPriceLatest"],
                            row["ItemID"],
                            (int)db.TransactionTypes.Sales);
                        cmdItemTransaction.ExecuteNonQuery();
                    }
                }

                #endregion

                #region Update files are now located in the DRS_FTP_client_arrive_dir directory

                // create DRS FTP depart/arrive directories config entries
                db.SetConfigString("DRS_FTP_client_arrive_dir", "c:\\DRS\\arrive");
                db.SetConfigString("DRS_FTP_client_depart_dir", "c:\\DRS\\depart"); // for later purposes

                // delete upd directory under application
                if (Directory.Exists("upd"))
                    Directory.Delete("upd", true);

                #endregion

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, "2.01.009");
                return false;
            }
        }
        #endregion

        #region METHOD: Upd_201010
        // update from version 2.01.009 -> 2.01.010
        private static bool Upd_201010()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                #region Create flag and other stuff in config for Regnskab I/F

                db.SetConfigString("RegnskabIF_flag", "");
                db.SetConfigString("RegnskabIF_local_dir", "C:\\RetailRegnskab\\Import");
                // see EODDetails.cs method Approve for more info on what this is used for

                #endregion

                #region Create EOD_Debtor table and insert a default debtor

                cmd.CommandText =
                    " CREATE TABLE EOD_Debtor ( " +
                    " DebtorNo INTEGER NOT NULL, " +
                    " Name1 TEXT(255), " +
                    " Name2 TEXT(255), " +
                    " Address1 TEXT(255), " +
                    " Address2 TEXT(255), " +
                    " ZipCode TEXT(10), " +
                    " City TEXT(255), " +
                    " Phone TEXT(20), " +
                    " Att TEXT(255), " +
                    " Active BIT ) ";
                cmd.ExecuteNonQuery();
                // create index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_EOD_Debtor " +
                    " ON EOD_Debtor (DebtorNo) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // insert a default debtor 99 "Diverse debitor"
                cmd.CommandText =
                    " INSERT INTO EOD_Debtor " +
                    " (DebtorNo,Name1,Active) " +
                    " values (99,'Diverse debitor',true) ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Remove field CustomerName from table EOD_LocalCred

                cmd.CommandText = " ALTER TABLE EOD_LocalCred DROP COLUMN CustomerName ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Create index on table EOD_LocalCred to gain performance when looking up customerno

                cmd.CommandText =
                    " CREATE INDEX idx_CustomerNo_EOD_LocalCred " +
                    " ON EOD_LocalCred (CustomerNo) ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Create table LookupEODLocalCredTransType and insert data

                // create table
                cmd.CommandText =
                    " CREATE TABLE LookupEODLocalCredTransType ( " +
                    " TransType TINYINT, " +
                    " Description TEXT(20) ) ";
                cmd.ExecuteNonQuery();
                // create index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_LookupEODLocalCredTransType " +
                    " ON LookupEODLocalCredTransType (TransType) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // fill in data
                cmd.CommandText =
                    " INSERT INTO LookupEODLocalCredTransType " +
                    " (TransType,Description) " +
                    " values (1, 'Kredit') ";
                cmd.ExecuteNonQuery();
                cmd.CommandText =
                    " INSERT INTO LookupEODLocalCredTransType " +
                    " (TransType,Description) " +
                    " values (2, 'Indbetalt') ";
                cmd.ExecuteNonQuery();
                cmd.CommandText =
                    " INSERT INTO LookupEODLocalCredTransType " +
                    " (TransType,Description) " +
                    " values (3, 'Manuelt') ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Create tables GLAccount and GLBudget

                // create table GLAccount
                cmd.CommandText =
                    " CREATE TABLE GLAccount ( " +
                    " GLCode TEXT(8) NOT NULL, " +
                    " Description TEXT(25), " +
                    " ShowLitres BIT, " +
                    " ShowInReport BIT ) ";
                cmd.ExecuteNonQuery();
                // create index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_GLAccount " +
                    " ON GLAccount (GLCode) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // create table GLBudget
                cmd.CommandText =
                    " CREATE TABLE GLBudget ( " +
                    " GLCode TEXT(8) NOT NULL, " +
                    " BudgetYear INTEGER NOT NULL, " +
                    " BudgetMonth INTEGER NOT NULL, " +
                    " Volume FLOAT, " +
                    " Amount FLOAT ) ";
                cmd.ExecuteNonQuery();
                // create index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_GLBudget " +
                    " ON GLBudget (GLCode,BudgetYear,BudgetMonth) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Add column GLCode to SubCategory

                cmd.CommandText = " ALTER TABLE SubCategory ADD COLUMN GLCode TEXT(8); ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Add config value for telling if using encryption for EOD file

                db.SetConfigString("EODFileEncrypted", "true");

                #endregion

                #region Correct hysterically funny speling erors :P

                cmd.CommandText =
                    " UPDATE SubCategory " +
                    " SET Description = 'Sportsdrik' " +
                    " WHERE SubCategoryID = '201060301' ";
                cmd.ExecuteNonQuery();

                cmd.CommandText =
                    " UPDATE Supplier " +
                    " SET Description = 'Carlsberg/Tuborg/Coca-Cola' " +
                    " WHERE SupplierID = 1 ";
                cmd.ExecuteNonQuery();

                #endregion

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, "2.01.010");
                return false;
            }
        }
        #endregion

        #region METHOD: Upd_201011
        // update from version 2.01.010 -> 2.01.011
        private static bool Upd_201011()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                #region Create tables for LL (Lekkerland) update files

                // create table ItemUpdates
                cmd.CommandText =
                    " CREATE TABLE ItemUpdates ( " +
                    " ID COUNTER NOT NULL, " +
                    " UpdDate DATETIME, " +
                    " NoOfLines INTEGER, " +
                    " NoOfOpen INTEGER ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_ItemUpdates " +
                    " ON ItemUpdates (ID) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // create table ItemUpdLines
                cmd.CommandText =
                    " CREATE TABLE ItemUpdLines ( " +
                    " ID INTEGER NOT NULL, " +
                    " LineNo INTEGER NOT NULL, " +
                    " LLAction TEXT(2), " +
                    " Name TEXT(25), " +
                    " Category INTEGER, " +
                    " PackType TINYINT, " +
                    " LLSalesPr FLOAT, " +
                    " SalesPrice FLOAT, " +
                    " SalesPriceSaved FLOAT, " +
                    " Barcode FLOAT, " +
                    " SupplierNo INTEGER, " +
                    " OrderingNumber FLOAT, " +
                    " Kolli INTEGER, " +
                    " CostPrice FLOAT, " +
                    " FixedPrice BIT, " +
                    " SubstNr INTEGER, " +
                    " EnhBeteg TEXT(6), " +
                    " ActionSummary TEXT(30), " +
                    " ActionNewItem BIT, " +
                    " ActionNewCostPrice BIT, " +
                    " ActionNewSalesPrice BIT, " +
                    " ActionNewSupplierItemNo BIT, " +
                    " ActionNewBarcode BIT, " +
                    " ActionItemDiscarded BIT, " +
                    " ActionDoneSummary TEXT(10), " +
                    " ActionDoneNewItem BIT, " +
                    " ActionDoneNewCostPrice BIT, " +
                    " ActionDoneNewSalesPrice BIT, " +
                    " ActionDoneNewSupplierItemNo BIT, " +
                    " ActionDoneNewBarcode BIT, " +
                    " ActionDoneItemDiscarded BIT, " +
                    " Skip BIT, " +
                    " Status INTEGER, " +
                    " SubCat TEXT(25), " +
                    " LogCost FLOAT, " +
                    " LogSales FLOAT, " +
                    " NoChSales BIT ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_ItemUpdLines " +
                    " ON ItemUpdLines (ID,LineNo) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Expand Item table for LL data

                cmd.CommandText = " ALTER TABLE Item ADD COLUMN FastPrisVare BIT "; cmd.ExecuteNonQuery();
                cmd.CommandText = " ALTER TABLE Item ADD COLUMN IkkeBeholdningsVare BIT "; cmd.ExecuteNonQuery();
                cmd.CommandText = " ALTER TABLE Item ADD COLUMN UdmeldtPrDato DATETIME "; cmd.ExecuteNonQuery();

                #endregion

                #region Create LLSubcatRel table

                // create table
                cmd.CommandText =
                    " CREATE TABLE LLSubcatRel (" +
                    " LLCat INTEGER NOT NULL, " +
                    " SubCategory TEXT(20) )";
                cmd.ExecuteNonQuery();
                // create index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_LLSubcatRel " +
                    " ON LLSubcatRel (LLCat) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Create table for LL data grid status and insert data

                // create table
                cmd.CommandText =
                    " CREATE TABLE LookupLLStatus ( " +
                    " ID INTEGER NOT NULL, " +
                    " Description TEXT(20) )";
                cmd.ExecuteNonQuery();
                // create index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_LookupLLStatus " +
                    " ON LookupLLStatus (ID) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // insert data
                cmd.CommandText =
                    " INSERT INTO LookupLLStatus " +
                    " (ID,Description) " +
                    " values (1,'Åben') ";
                cmd.ExecuteNonQuery();
                cmd.CommandText =
                    " INSERT INTO LookupLLStatus " +
                    " (ID,Description) " +
                    " values (2,'Lukket') ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Delete SupplierItem records not having an existing Item

                /// We have discovered that Fensmark has some SupplierItem records
                /// where the ItemID cannot be found in the Item table. We
                /// guess that this is because Fensmark ealier had some problems
                /// with deleting SupplierItem records and creating them again.
                /// Anyways, we now scan the SupplierItem table for records, that
                /// points to Items that does not exist. We just delete those SupplierItems.

                cmd.CommandText =
                    " delete from SupplierItem " +
                    " where ItemID not in " +
                    " (select ItemID from Item) ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Correct possibly created barcode with value 0

                // we had an error in the validation of a barcode, so
                // a barcode with value 0 could be created in the gui.
                // at least one pilot had created a 0 barcode. the gui
                // has been fixed in this version, so here we fix the data

                // if a 0 barcode exists, change its barcode to a new value
                DataRow rowBarcode = ItemDataSet.BarcodeDataTable.GetBarcodeRecord(0);
                if (rowBarcode != null)
                {
                    // delete the invalid 0 barcode record
                    // NOTE: usually we have to semidelete the barcode, so the rsm
                    // will be notyfied of the change, but the program needs the
                    // 0 barcode to dissappear instantly, so we ignore that a single
                    // barcode of value 0 resides in the rsm system.
                    db.ExecuteNonQuery(" delete from Barcode where Barcode = 0 ");

                    // create a new barcode record
                    int ItemID = tools.object2int(rowBarcode["ItemID"]);
                    byte PackType = tools.object2byte(rowBarcode["PackType"]);
                    double NewBarcode = ItemDataSet.BarcodeDataTable.GenerateUniqueBarcode(3000);
                    byte BCType = 1; // custom barcode type
                    ItemDataSet.BarcodeDataTable.AddBarcode(ItemID, PackType, NewBarcode, BCType);
                }

                #endregion

                #region Change subcategory 201050601 name and activate it

                cmd.CommandText =
                    " update SubCategory set " +
                    " Description = 'Ikke salgsvarer', " +
                    " NotActive = false " +
                    " where SubCategoryID = '201050601' ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Add field LLSupplierNo to Supplier table

                // add column
                cmd.CommandText =
                    " ALTER TABLE Supplier " +
                    " ADD COLUMN LLSupplierNo INTEGER ";
                cmd.ExecuteNonQuery();

                // update data for Carlsberg/Tuborg/Coca-Cola
                cmd.CommandText =
                    " UPDATE Supplier set " +
                    " LLSupplierNo = 322222 " +
                    " where SupplierID = 1 ";
                cmd.ExecuteNonQuery();

                // update data for Royal Unibrew
                cmd.CommandText =
                    " UPDATE Supplier set " +
                    " LLSupplierNo = 103630, " +
                    " Description = 'Royal Unibrew' " +
                    " where SupplierID = 23 ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Import file with corrected kollisizes from LL

                // LL has corrected kollisizes for some ordering numbers.
                // Here we import those changes and updates the database as needed.

                // for testing purposes
                //List<string> list = new List<string>();

                // first check if the import file is present
                string fileCorrectedKolliSizes = db.GetConfigString("DRS_FTP_client_arrive_dir") + "\\LLKolliChange.csv";
                if (File.Exists(fileCorrectedKolliSizes))
                {
                    GenericParser parser = tools.CreateCSVParser(fileCorrectedKolliSizes, ';', true);
                    while (parser.Read())
                    {
                        // get the RBOS and LL values from file and compare them.
                        // if OrderingNumbers match and KolliSizes do not match, perform update.
                        double RBOSOrderingNumber = tools.object2double(parser["RBOSBestnr"]);
                        double LLOrderingNumber = tools.object2double(parser["LLBestnr"]);
                        int RBOSKolli = tools.object2int(parser["RBOSKolli"]);
                        int LLKolli = tools.object2int(parser["LLKolli"]);
                        if ((RBOSOrderingNumber == LLOrderingNumber) &&
                            (RBOSKolli != LLKolli))
                        {
                            // get LL SupplierNo from file and then look it up in RBOS
                            int SupplierNo = tools.object2int(parser["Levnr"]);
                            SupplierNo = dbSupplier.GetSupplierID(SupplierNo);

                            // perform the update
                            ItemDataSet.SupplierItemDataTable.UpdateKolliSize(
                                LLKolli, SupplierNo, RBOSOrderingNumber);

                            // for testing purposes
                            //list.Add(string.Format("SupplierNo: {0}, OrderingNumber: {1}", SupplierNo, RBOSOrderingNumber));
                        }
                    }

                    // delete the file when done
                    tools.RemoveFileWriteProtection(fileCorrectedKolliSizes);
                    File.Delete(fileCorrectedKolliSizes);
                }

                #endregion

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, "2.01.011");
                return false;
            }
        }
        #endregion

        #region METHOD: Upd_201012
        // update from version 2.01.011 -> 2.01.012
        private static bool Upd_201012()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                //

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, "2.01.012");
                return false;
            }
        }
        #endregion

        #region METHOD: Upd_201013
        // update from version 2.01.012 -> 2.01.013
        private static bool Upd_201013()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                #region Re-create table UserProfiles and fill it with data

                // delete table UserProfiles
                cmd.CommandText = " DROP TABLE UserProfiles ";
                cmd.ExecuteNonQuery();

                // create table
                cmd.CommandText =
                    " CREATE TABLE UserProfiles ( " +
                    " ProfileID INTEGER NOT NULL, " +
                    " ProfileName TEXT(50) ) ";
                cmd.ExecuteNonQuery();
                // create index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_UserProfiles " +
                    " ON UserProfiles (ProfileID) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // fill it with data
                cmd.CommandText = " INSERT INTO UserProfiles (ProfileID,ProfileName) VALUES (0,'drs') "; cmd.ExecuteNonQuery();
                cmd.CommandText = " INSERT INTO UserProfiles (ProfileID,ProfileName) VALUES (1,'support') "; cmd.ExecuteNonQuery();
                cmd.CommandText = " INSERT INTO UserProfiles (ProfileID,ProfileName) VALUES (2,'admin') "; cmd.ExecuteNonQuery();
                cmd.CommandText = " INSERT INTO UserProfiles (ProfileID,ProfileName) VALUES (3,'daglig') "; cmd.ExecuteNonQuery();
                cmd.CommandText = " INSERT INTO UserProfiles (ProfileID,ProfileName) VALUES (4,'assistent') "; cmd.ExecuteNonQuery();

                #endregion

                #region Re-create Users table and fill it with data

                // delete table Users
                cmd.CommandText = " DROP TABLE Users ";
                cmd.ExecuteNonQuery();

                // create table
                cmd.CommandText =
                    " CREATE TABLE Users ( " +
                    " Username TEXT(50) NOT NULL, " +
                    " Passwd TEXT(255), " +
                    " ProfileID INTEGER ) ";
                cmd.ExecuteNonQuery();
                // create index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_Users " +
                    " ON Users (Username) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // insert users
                cmd.CommandText = string.Format(
                    " INSERT INTO Users (Username,Passwd,ProfileID) " +
                    " VALUES ('drs','{0}',0) ", Encryption.EncryptString("cban15082005"));
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(
                    " INSERT INTO Users (Username,Passwd,ProfileID) " +
                    " VALUES ('support','{0}',1) ", Encryption.EncryptString("support"));
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(
                    " INSERT INTO Users (Username,Passwd,ProfileID) " +
                    " VALUES ('admin','{0}',2) ", Encryption.EncryptString("admin"));
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(
                    " INSERT INTO Users (Username,Passwd,ProfileID) " +
                    " VALUES ('daglig','{0}',3) ", Encryption.EncryptString("daglig"));
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(
                    " INSERT INTO Users (Username,Passwd,ProfileID) " +
                    " VALUES ('assistent','{0}',4) ", Encryption.EncryptString("assistent"));
                cmd.ExecuteNonQuery();

                #endregion

                #region Create table TreeviewProhibitions and insert data

                /// note that TreeviewProhibitions table gives
                /// which profiles do not have access to
                /// which treeview menu entries

                // create table
                cmd.CommandText =
                    " CREATE TABLE TreeviewProhibitions ( " +
                    " EntryID TEXT(50) NOT NULL, " +
                    " ProfileIDProhibited INTEGER NOT NULL ) ";
                cmd.ExecuteNonQuery();
                // create index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_TreeviewProhibitions " +
                    " ON TreeviewProhibitions (EntryID, ProfileIDProhibited) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // restrict certain menu entries from profiles daglig and assistent
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.System.Sitedata',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.daglig);
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.System.Sitedata',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.assistent);
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.System.SetupFolder',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.daglig);
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.System.SetupFolder',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.assistent);
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.System.Setup.Users',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.daglig);
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.System.Setup.Users',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.assistent);
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.System.PakningsTyper',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.daglig);
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.System.PakningsTyper',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.assistent);
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.System.Setup.KolliSizes',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.daglig);
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.System.Setup.KolliSizes',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.assistent);
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.System.Setup.BHHTWS',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.daglig);
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.System.Setup.BHHTWS',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.assistent);
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.System.Setup.FTPAccounts',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.daglig);
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.System.Setup.FTPAccounts',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.assistent);
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.System.PeriodicFolder',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.daglig);
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.System.PeriodicFolder',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.assistent);
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.System.Periodic.CleanUp',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.daglig);
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.System.Periodic.CleanUp',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.assistent);
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.System.SupportFolder',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.daglig);
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.System.SupportFolder',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.assistent);
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.System.Support.ViewLog',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.daglig);
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.System.Support.ViewLog',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.assistent);
                cmd.ExecuteNonQuery();

                // Daglig
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu02',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.assistent);
                cmd.ExecuteNonQuery();
                // Daglig > Dagsopgørelse
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.EODReconcile',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.assistent);
                cmd.ExecuteNonQuery();
                // Daglig > Debitor stamdata
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.EODDebitor',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.assistent);
                cmd.ExecuteNonQuery();
                // Daglig > Rapporter
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.EODReports',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.assistent);
                cmd.ExecuteNonQuery();
                // Daglig > Salgsrapport
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.EOD.Reports.SalesReport',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.assistent);
                cmd.ExecuteNonQuery();
                // Daglig > Debitor liste
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.EOD.Reports.Debitorlist',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.assistent);
                cmd.ExecuteNonQuery();
                // Daglig > Debitor kontoudtog
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.EOD.Reports.DebStatement',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.assistent);
                cmd.ExecuteNonQuery();
                // Varer > Ordrer
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu0302',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.assistent);
                cmd.ExecuteNonQuery();
                // Varer > Ordrer > Ordrer
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu030201',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.assistent);
                cmd.ExecuteNonQuery();
                // Varer > Ordrer > Ordrekladder
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu030202',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.assistent);
                cmd.ExecuteNonQuery();
                // Varer > Leverandører
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu0305',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.assistent);
                cmd.ExecuteNonQuery();
                // Varer > Import/Export > ImportFraLekkerland
                cmd.CommandText = string.Format(
                    " INSERT INTO TreeviewProhibitions (EntryID,ProfileIDProhibited) " +
                    " VALUES ('TreeMenu.ImportFromLL',{0}) ",
                    (int)AdminDataSet.UserProfilesDataTable.ProfileID.assistent);
                cmd.ExecuteNonQuery();

                #endregion

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, "2.01.013");
                return false;
            }
        }
        #endregion

        #region METHOD: Upd_201014
        // update from version 2.01.013 -> 2.01.014
        private static bool Upd_201014()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                #region Various corrections made on all items

                DataTable tableItems = db.GetDataTable(" select ItemID from Item ");
                foreach (DataRow row in tableItems.Rows)
                {
                    int ItemID = tools.object2int(row["ItemID"]);

                    #region Correct wrong InStock values on each item

                    // (WriteItemTransaction method fixed too)

                    // for this item, calculate InStock value correctly
                    ItemDataSet.ItemDataTable.ReCalculateInStock_v14upd(ItemID);

                    #endregion

                    #region Correct wrong LastInventDate on each item

                    /// Previously we made code in WriteItemTransaction method,
                    /// which erronoulsly updated the Item.LastInventDate field
                    /// whenever a non-count transaction type was created. This is
                    /// wrong, as the Item.LastInventDate may only be set when
                    /// the transaction type is count. This has now been fixed in the
                    /// WriteItemTransaction method, but data needs to be corrected too.
                    /// One approach would be to just null all the Item.LastInventDate fields,
                    /// but a more accurate approach is to look in the ItemTransaction
                    /// records for each item, and take the date of the latest record of
                    /// type count. If no count records exists, we just null the value.

                    // attempt to get the latest item transaction with record type count
                    // to use the PostingDate as the LastInventDate
                    DateTime LastInventDate = tools.object2datetime(db.ExecuteScalar(string.Format(
                        " select max(PostingDate) " +
                        " from ItemTransaction " +
                        " where (ItemID = {0}) " +
                        " and (TransactionType = {1}) ",
                        ItemID, (byte)db.TransactionTypes.Count)));

                    // update item's LastInventDate
                    if (LastInventDate != DateTime.MinValue)
                        ItemDataSet.ItemDataTable.UpdateLastInventDate(ItemID, LastInventDate);
                    else
                        ItemDataSet.ItemDataTable.NullLastInventDate(ItemID);

                    #endregion
                }

                #endregion

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, "2.01.014");
                return false;
            }
        }
        #endregion

        #region METHOD: Upd_201015
        // update from version 2.01.014 -> 2.01.015
        private static bool Upd_201015()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                #region Create tables for Payroll module

                // create table PrlEmployee
                cmd.CommandText =
                    " CREATE TABLE PrlEmployee ( " +
                    " EmployeeNo INTEGER NOT NULL, " +
                    " FirstName TEXT(50), " +
                    " LastName TEXT(50), " +
                    " Address1 TEXT(100), " +
                    " Address2 TEXT(100), " +
                    " ZipCode TEXT(10), " +
                    " City TEXT(50), " +
                    " Phone TEXT(20), " +
                    " ContactPhone TEXT(20), " +
                    " CPR TEXT(20), " +
                    " Post TEXT(50), " +
                    " StartDate DATETIME, " +
                    " EndDate DATETIME, " +
                    " EmployeeType TEXT(20), " +
                    " FuncHours INTEGER, " +
                    " Education BIT, " +
                    " NotIncludedInReg BIT ) ";
                cmd.ExecuteNonQuery();
                // create index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_PrlEmployee " +
                    " ON PrlEmployee (EmployeeNo) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // create table PrlSalaryPeriods
                cmd.CommandText =
                    " CREATE TABLE PrlSalaryPeriods ( " +
                    " PeriodYear INTEGER NOT NULL, " +
                    " Period INTEGER NOT NULL, " +
                    " StartDate DATETIME, " +
                    " EndDate DATETIME, " +
                    " Active BIT, " +
                    " Approved BIT, " +
                    " Sent BIT ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_PrlSalaryPeriods " +
                    " ON PrlSalaryPeriods (PeriodYear,Period) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // create table PrlAgreement (overenskomst).
                // should be joined with PrlBonusEx table.
                // they are not together because we only want
                // to transfer the dynamic content, which is in
                // this table.
                cmd.CommandText =
                    " CREATE TABLE PrlAgreement ( " +
                    " AgreementCode TEXT(4) NOT NULL, " +
                    " BonusCode INTEGER NOT NULL, " +
                    " FromTime DATETIME, " +
                    " ToTime DATETIME ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_PrlAgreement " +
                    " ON PrlAgreement (AgreementCode,BonusCode) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // create table PrlAgreementStatic (overenskomst static data),
                // the purpose of this table is to code less when 
                // selecting which bonus code a given hours falls within.
                // one could say that is helps narrowing down the bonus code.
                // it is designed to be joined with PrlBonus table.
                cmd.CommandText =
                    " CREATE TABLE PrlAgreementStatic ( " +
                    " BonusCode INTEGER NOT NULL, " +
                    " Description TEXT(50), " +
                    " Holiday BIT, " +
                    " Day1 BIT, " +
                    " Day2 BIT, " +
                    " Day3 BIT, " +
                    " Day4 BIT, " +
                    " Day5 BIT, " +
                    " Day6 BIT, " +
                    " Day7 BIT ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_PrlAgreementStatic " +
                    " ON PrlAgreementStatic (BonusCode) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // insert data into PrlAgreementStatic
                cmd.CommandText =
                    " INSERT INTO PrlAgreementStatic (BonusCode,Description,Holiday,Day1,Day2,Day3,Day4,Day5,Day6,Day7) " +
                    " VALUES (1010,'Aftentillæg',false,true,true,true,true,true,false,false) ";
                cmd.ExecuteNonQuery();
                cmd.CommandText =
                    " INSERT INTO PrlAgreementStatic (BonusCode,Description,Holiday,Day1,Day2,Day3,Day4,Day5,Day6,Day7) " +
                    " VALUES (1020,'Nattillæg',false,true,true,true,true,true,true,false) ";
                cmd.ExecuteNonQuery();
                cmd.CommandText =
                    " INSERT INTO PrlAgreementStatic (BonusCode,Description,Holiday,Day1,Day2,Day3,Day4,Day5,Day6,Day7) " +
                    " VALUES (1030,'Lørdagstillæg',false,false,false,false,false,false,true,false) ";
                cmd.ExecuteNonQuery();
                cmd.CommandText =
                    " INSERT INTO PrlAgreementStatic (BonusCode,Description,Holiday,Day1,Day2,Day3,Day4,Day5,Day6,Day7) " +
                    " VALUES (1040,'Søn- og helligdagstillæg',true,true,true,true,true,true,true,true) ";
                cmd.ExecuteNonQuery();
                cmd.CommandText =
                    " INSERT INTO PrlAgreementStatic (BonusCode,Description,Holiday,Day1,Day2,Day3,Day4,Day5,Day6,Day7) " +
                    " VALUES (1050,'Søn- og helligdagstillæg nat',true,true,true,true,true,true,true,true) ";
                cmd.ExecuteNonQuery();

                // create table PrlSalaryRegistration (lønregistrering)
                cmd.CommandText =
                    " CREATE TABLE PrlSalaryRegistration ( " +
                    " ID COUNTER NOT NULL, " +
                    " DayNo INTEGER, " +
                    " RegDate DATETIME, " +
                    " FromTime DATETIME, " +
                    " ToTime DATETIME, " +
                    " Hours DATETIME, " +
                    " Overtime DATETIME, " +
                    " TakeTimeOf DATETIME, " + // afspadsering
                    " Remarks TEXT(50), " +
                    " Bonus1010 DATETIME, " +
                    " Bonus1020 DATETIME, " +
                    " Bonus1030 DATETIME, " +
                    " Bonus1040 DATETIME, " +
                    " Bonus1050 DATETIME ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_PrlSalaryRegistration " +
                    " ON PrlSalaryRegistration (ID) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // create table PrlLookupDays
                cmd.CommandText =
                    " CREATE TABLE PrlLookupDays ( " +
                    " DayNo INTEGER NOT NULL,  " +
                    " DescShort TEXT(5), " +
                    " DescLong TEXT(20) ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_PrlLookupDays " +
                    " ON PrlLookupDays (DayNo) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // fill data into PrlLookupDays
                cmd.CommandText =
                    " INSERT INTO PrlLookupDays (DayNo,DescShort,DescLong) " +
                    " VALUES (1, 'Ma', 'Mandag') ";
                cmd.ExecuteNonQuery();
                cmd.CommandText =
                    " INSERT INTO PrlLookupDays (DayNo,DescShort,DescLong) " +
                    " VALUES (2, 'Ti', 'Tirsdag') ";
                cmd.ExecuteNonQuery();
                cmd.CommandText =
                    " INSERT INTO PrlLookupDays (DayNo,DescShort,DescLong) " +
                    " VALUES (3, 'On', 'Onsdag') ";
                cmd.ExecuteNonQuery();
                cmd.CommandText =
                    " INSERT INTO PrlLookupDays (DayNo,DescShort,DescLong) " +
                    " VALUES (4, 'To', 'Torsdag') ";
                cmd.ExecuteNonQuery();
                cmd.CommandText =
                    " INSERT INTO PrlLookupDays (DayNo,DescShort,DescLong) " +
                    " VALUES (5, 'Fr', 'Fredag') ";
                cmd.ExecuteNonQuery();
                cmd.CommandText =
                    " INSERT INTO PrlLookupDays (DayNo,DescShort,DescLong) " +
                    " VALUES (6, 'Lø', 'Lørdag') ";
                cmd.ExecuteNonQuery();
                cmd.CommandText =
                    " INSERT INTO PrlLookupDays (DayNo,DescShort,DescLong) " +
                    " VALUES (7, 'Sø', 'Søndag') ";
                cmd.ExecuteNonQuery();

                // create table PrlHolidays
                cmd.CommandText =
                    " CREATE TABLE PrlHolidays ( " +
                    " HolidayDate DATETIME NOT NULL, " +
                    " FromTime DATETIME, " +
                    " ToTime DATETIME ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_PrlHolidays " +
                    " ON PrlHolidays (HolidayDate) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Set agreement (overenskomst) code in config

                // assume standard agreement code
                db.SetConfigString("AgreementCode", "HK");

                #endregion

                #region Fix possible situation, where the same barcode exists on two items

                /// For this version, the BarcodeForm has been fixed, so that user
                /// cannot anymore enter the same barcode for two different items.
                /// Previously the user was shown an error message if this happened,
                /// but the user could still just click ok on the form and save the barcode.
                /// Also, in a special situation, the user wouldn't even get the error message.
                /// The database might now contain two or more items with the same barcode on.
                /// NOTE: Do not confuse this with the legal option to have the same barcode
                /// on the same item but on two different salespacks.

                // first detect same barcodes across different items
                // (Note that b2 is selected before b1,
                // as this gives the correct output
                // with the first-created record first.)
                DataTable tblBarcodes = db.GetDataTable(@"
                    select
                      b1.itemid,
                      b1.packtype,
                      b1.barcode,
                      b1.IsPrimary
                    from barcode b2, barcode b1
                    where b1.itemid <> b2.itemid
                    and b1.barcode = b2.barcode
                    and b1.semideleted <> true
                    and b2.semideleted <> true 
                    ");

                // write to logfile that we are going to change barcodes
                if (tblBarcodes.Rows.Count > 0)
                {
                    log.Write("***************** BEMÆRK *********************");
                    log.Write("Nogle barcoder er blevet ændret, da de var i konflikt med barcoder på andre varer:");
                }

                // generate list of barcodes
                List<double> distinctListOfBarcodes = new List<double>();
                foreach (DataRow row in tblBarcodes.Rows)
                {
                    double barcode = tools.object2double(row["Barcode"]);
                    if (!distinctListOfBarcodes.Contains(barcode))
                        distinctListOfBarcodes.Add(barcode);
                }

                // loop the list of distict barcodes.
                // within each set of equal barcodes,
                // we keep the first barcode intact and
                // change all subsequent barcode in that set.
                foreach (double barcode in distinctListOfBarcodes)
                {
                    // get records with this barcode
                    DataRow[] rows = tblBarcodes.Select("Barcode = " + barcode.ToString());

                    // loop records with this barcode
                    int ItemIDThatWillBeKept = 0;
                    foreach (DataRow row in rows)
                    {
                        if (ItemIDThatWillBeKept == 0)
                        {
                            // the first record will be kept
                            ItemIDThatWillBeKept = tools.object2int(row["ItemID"]);
                        }
                        else
                        {
                            // all subsequent records with the same barcode
                            // will get its barcode and bctype changed

                            // get values from the existing barcode
                            int ItemID = tools.object2int(row["ItemID"]);
                            byte PackType = tools.object2byte(row["PackType"]);
                            double Barcode = tools.object2double(row["Barcode"]);
                            bool IsPrimary = tools.object2bool(row["IsPrimary"]);

                            // semidelete existing barcode
                            ItemDataSet.BarcodeDataTable.SemiDeleteBarcode(ItemID, PackType, Barcode);

                            // generate a new unique barcode, where we change
                            // bctype to custom and keep all other values
                            double newBarcode = ItemDataSet.BarcodeDataTable.GenerateUniqueBarcode(Barcode);
                            int BCType = 1; // custom barcode type
                            db.ExecuteNonQuery(string.Format(
                                " insert into Barcode " +
                                " (ItemID,PackType,BCType,Barcode,IsPrimary) " +
                                " values ({0},{1},{2},{3},{4}) ",
                                ItemID, PackType, BCType, newBarcode, IsPrimary));

                            // also change primary barcode on the salespack, if it is the primary barcode
                            if (IsPrimary)
                            {
                                db.ExecuteNonQuery(string.Format(
                                    " update SalesPack set " +
                                    " Barcode = {0}, " +
                                    " BCType = {1} " +
                                    " where (ItemID = {2}) " +
                                    " and (PackType = {3}) ",
                                    newBarcode, BCType, ItemID, PackType));
                            }

                            // set UpdateRSM and UpdateShelfLabel
                            db.ExecuteNonQuery(string.Format(
                                " update SalesPack set " +
                                " UpdateRSM = true, " +
                                " UpdateShelfLabel = true " +
                                " where (ItemID = {0}) " +
                                " and (PackType = {1}) ",
                                ItemID, PackType));

                            // if this item was chain item for other items,
                            // update those other item's reference to this item.
                            // only ChainBarcode needs to be changed.
                            db.ExecuteNonQuery(string.Format(
                                " update SalesPack set " +
                                " ChainBarcode = {0} " +
                                " where (ChainItemID = {1}) " +
                                " and (ChainPackType = {2}) " +
                                " and (ChainBarcode = {3}) ",
                                newBarcode, ItemID, PackType, Barcode));

                            // get itemnames for writing into logfile
                            string ItemName = "";
                            DataRow itemRow = ItemDataSet.ItemDataTable.GetItemRecord(ItemID);
                            if (itemRow != null) ItemName = tools.object2string(itemRow["ItemName"]);

                            // write in logfile what was done
                            log.Write(string.Format(
                                "Barcode {0} er ændret til {1} på vare \"{2}\"",
                                Barcode, newBarcode, ItemName));
                        }
                    }
                }

                // write in logfile that we are done changing in barcode
                log.Write("Du bør opdatere RSM og checke for nye hyldeforkanter.");
                log.Write("**********************************************");

                // show log file to user asynchronous so updater will continue unaffected
                tools.ExecuteProcess("log.txt");

                #endregion

                #region Alter table SubCategory so it includes a flag for whether a subcategory needs deposit (pant)

                // add column
                cmd.CommandText = " ALTER TABLE SubCategory ADD COLUMN NeedsDeposit BIT ";
                cmd.ExecuteNonQuery();

                // fill in data for specific subcategories that needs deposit
                cmd.CommandText =
                    " update SubCategory " +
                    " set NeedsDeposit = true " +
                    " where SubCategoryID in ( " +
                    " '201060101', " + // sodavand
                    " '201060201', " + // vand
                    " '201060301', " + // sportsdrik
                    " '201060401', " + // energidrikke
                    " '201070101', " + // øl
                    " '201070301', " + // spiritus
                    " '201070401' ) "; // alcopops
                cmd.ExecuteNonQuery();

                #endregion

                #region By default, payroll module is disabled for a station and user Assistent never has access

                // disable payroll module
                db.SetConfigString("PayrollModuleActive", false);

                // assistent never has access
                AdminDataSet.TreeviewProhibitionsDataTable.SetAccessRights(
                    "TreeMenu01", AdminDataSet.UserProfilesDataTable.ProfileID.assistent, false);

                #endregion

                #region Remove items without a salespack and salespacks without a barcode

                // delete salespacks with barcode 0
                // (must be done before cleaning up items)
                cmd.CommandText = string.Format(
                    " delete from SalesPack " +
                    " where barcode = 0 ");
                cmd.ExecuteNonQuery();

                // delete items without a salespack
                cmd.CommandText = string.Format(
                    " delete from Item " +
                    " where ItemID in " +
                    " (select ItemID from item " +
                    "  where itemid not in " +
                    "  (select itemid from salespack)) ");
                cmd.ExecuteNonQuery();

                #endregion

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, "2.01.015");
                return false;
            }
        }
        #endregion

        #region METHOD: Upd_201016
        // update from version 2.01.015 -> 2.01.016
        private static bool Upd_201016()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                #region Re-create table PrlSalaryRegistration

                /// in version 2.01.015 we added the tabel PrlSalaryRegistration,
                /// but we did not use it in that version. we have now some changes
                /// to the table and the easiest is to just delete it and re-create it
                /// here with a modified copy of the code from the previous version.

                // first we drop the existing table
                cmd.CommandText = " DROP TABLE PrlSalaryRegistration ";
                cmd.ExecuteNonQuery();

                // create table PrlSalaryRegistration (lønregistrering)
                cmd.CommandText =
                    " CREATE TABLE PrlSalaryRegistration ( " +
                    " ID COUNTER NOT NULL, " +
                    " EmployeeNo INTEGER, " + // FK -> PrlSalaryEmployee
                    " DayNo INTEGER, " + // FK -> PrlLookupDays
                    " RegDateAsString TEXT(10), " + // needs to be text due to otherwise unwanted validation
                    " RegDateAsDateTime DATETIME, " +
                    " FromTimeAsString TEXT(5), " + // needs to be text due to otherwise unwanted validation
                    " ToTimeAsString TEXT(5), " + // needs to be text due to otherwise unwanted validation
                    " Hours FLOAT, " +
                    " Overtime FLOAT, " +
                    " TakeTimeOff FLOAT, " + // afspadsering
                    " SiteCode TEXT(4), " +
                    " Remarks TEXT(50), " +
                    " Bonus1010 FLOAT, " +
                    " Bonus1020 FLOAT, " +
                    " Bonus1030 FLOAT, " +
                    " Bonus1040 FLOAT, " +
                    " Bonus1050 FLOAT ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_PrlSalaryRegistration " +
                    " ON PrlSalaryRegistration (ID) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Create PrlClusterSites table for payroll module

                // create table
                cmd.CommandText =
                    " CREATE TABLE PrlClusterSites ( " +
                    " SiteCode TEXT(4) NOT NULL, " +
                    " SiteName TEXT(50) ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_PrlClusterSites " +
                    " ON PrlClusterSites (SiteCode) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Create PrlLookupAbsenseCodes table for payroll module

                // create table
                cmd.CommandText =
                    " CREATE TABLE PrlLookupAbsenseCodes ( " +
                    " AbsenseCode INTEGER NOT NULL, " +
                    " Description TEXT(50), " +
                    " OnlyFunc BIT ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_PrlLookupAbsenseCodes " +
                    " ON PrlLookupAbsenseCodes (AbsenseCode) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Create PrlAbsense table for payroll module

                // create table
                cmd.CommandText =
                    " CREATE TABLE PrlAbsense ( " +
                    " ID COUNTER NOT NULL, " +
                    " EmployeeNo INTEGER, " +
                    " DayNo INTEGER, " +
                    " FromDateAsString TEXT(10), " +
                    " FromDateAsDateTime DATETIME, " +
                    " ToDateAsString TEXT(10), " +
                    " ToDateAsDateTime DATETIME, " +
                    " AbsenseCode INTEGER, " +
                    " Hours FLOAT, " +
                    " Days INTEGER ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_PrlAbsense " +
                    " ON PrlAbsense (ID) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Add column IsFunc to PrlEmployee

                cmd.CommandText =
                    " ALTER TABLE PrlEmployee " +
                    " ADD COLUMN IsFunc BIT ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Add default backup settings to config

                // general settings
                db.SetConfigString("Backup_CompressDB", false);
                db.SetConfigString("Backup_NumDaysBack", 5);
                db.SetConfigString("Backup_LastExternalBackup", DateTime.Now.Date);
                db.SetConfigString("Backup_ExternalBackupInterval", 2); // weekly backup

                // local settings
                db.SetConfigString("Backup_LocalEnabled", true);
                db.SetConfigString("Backup_LocalDir", "C:\\DRS\\RBOSBackup"); // if changed, also change in Backup.CreateVersionUpdateBackup
                db.SetConfigString("Backup_LocalAuto", true);
                db.SetConfigString("Backup_LocalZip", false);

                // network settings
                db.SetConfigString("Backup_NetworkEnabled", true);
                db.SetConfigString("Backup_NetworkDir", "N:\\RBOSBackup");
                db.SetConfigString("Backup_NetworkAuto", true);
                db.SetConfigString("Backup_NetworkZip", false);

                // external settings
                db.SetConfigString("Backup_ExternalEnabled", true);
                db.SetConfigString("Backup_ExternalDir", "D:\\");
                db.SetConfigString("Backup_ExternalZip", false);

                #endregion

                #region Create LookupBackupInterval table

                cmd.CommandText =
                    " CREATE TABLE LookupBackupInterval ( " +
                    " ID INTEGER NOT NULL, " +
                    " Description TEXT(20) ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_LookupBackupInterval " +
                    " ON LookupBackupInterval (ID) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // add data
                cmd.CommandText = "INSERT INTO LookupBackupInterval (ID,Description) VALUES (1,'Dagligt') "; cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO LookupBackupInterval (ID,Description) VALUES (2,'Ugenligt') "; cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO LookupBackupInterval (ID,Description) VALUES (3,'Månedligt') "; cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO LookupBackupInterval (ID,Description) VALUES (4,'Aldrig') "; cmd.ExecuteNonQuery();

                #endregion

                #region Change column ItemTransaction.NumberOf from short to long

                /// For some reason, the column Number on table ItemTransaction
                /// has been created as a short. This should have been a long.
                /// We had a station that entered 100500 into this field, which
                /// gave an overflow exception. Upsizing the field size does not
                /// affect existing values.

                /* UPSIZE TEST
                DataTable t = db.GetDataTable(" select TransactionNumber, NumberOf from ItemTransaction ");
                 * */

                cmd.CommandText = " ALTER TABLE ItemTransaction ALTER COLUMN NumberOf INTEGER ";
                cmd.ExecuteNonQuery();

                /* UPSIZE TEST
                foreach (DataRow row in t.Rows)
                {
                    if (tools.object2int(db.ExecuteScalar(string.Format(
                        " select count(*) " +
                        " from ItemTransaction " +
                        " where (TransactionNumber = {0}) " +
                        " and (NumberOf = {1}) ",
                        row["TransactionNumber"],
                        row["NumberOf"]))) <= 0)
                    {
                        throw new Exception("Datafejl ved upsize af ItemTransaction.NumberOf");
                    }
                }
                 * */

                #endregion

                //#region Add ACN values to config table and create export history table

                //db.SetConfigString("ACN_Enabled", true);

                //// create export history table
                //cmd.CommandText =
                //    " CREATE TABLE ACNExportHistory ( " +
                //    " AYear INTEGER NOT NULL, " +
                //    " AWeek INTEGER NOT NULL, " +
                //    " Status INTEGER, " +
                //    " SystemDate DATETIME ) ";
                //cmd.ExecuteNonQuery();
                //// add index
                //cmd.CommandText =
                //    " CREATE UNIQUE INDEX idx_ACNExportHistory " +
                //    " ON ACNExportHistory (AYear,AWeek) " +
                //    " WITH PRIMARY ";
                //cmd.ExecuteNonQuery();

                //// set initial export week
                //cmd.CommandText = string.Format(
                //    " INSERT INTO ACNExportHistory " +
                //    " (AYear,AWeek,Status,SystemDate) " +
                //    " values (2006,52,{0},cdate('{1}')) ",
                //    (int)AdminDataSet.ACNExportHistoryDataTable.Status.Export_Ok,
                //    DateTime.Now);
                //cmd.ExecuteNonQuery();

                //#endregion

                #region Add columns to SiteInformation

                cmd.CommandText = " ALTER TABLE SiteInformation ADD COLUMN BankAccount TEXT(20) ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Fix possible errors in table BookedInvCountHeader

                /// We had a situation, where booking inventory count data,
                /// a header could be created but no details would be created.
                /// Thus we want to clean up this situation, if it has occured.
                ItemDataSet.BookedInvCountHeaderDataTable.DeleteHeadersWithoutDetails();

                #endregion

                #region Add some config strings

                /// boolean that indicates if user will be displayed a message
                /// if LL updates are ready to be treated in the LL window.
                db.SetConfigString("AskUserWhenLLUpdatesNotTreatedYet", true);

                #endregion

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, "2.01.016");
                return false;
            }
        }

        #endregion

        #region METHOD: Upd_201017
        // update from version 2.01.016 -> 2.01.017
        private static bool Upd_201017()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                #region Add table PrlWithdraw

                cmd.CommandText =
                    " CREATE TABLE PrlWithdraw ( " +
                    " ID COUNTER NOT NULL, " +
                    " EmployeeNo INTEGER, " +
                    " WithdrawType INTEGER, " +
                    " Remark TEXT(50), " +
                    " NumberOf INTEGER, " +
                    " Amount FLOAT, " +
                    " DateReg DATETIME ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_PrlWithdraw " +
                    " ON PrlWithdraw (ID) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Add table PrlWithdrawType

                cmd.CommandText =
                    " CREATE TABLE PrlWithdrawType ( " +
                    " WithdrawType INTEGER, " +
                    " Description TEXT(10) ) ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText =
                    " CREATE UNIQUE INDEX idx_PrlWithdrawType " +
                    " ON PrlWithdrawType (WithdrawType) " +
                    " WITH PRIMARY ";
                cmd.ExecuteNonQuery();

                // insert data
                cmd.CommandText =
                    " INSERT INTO PrlWithdrawType " +
                    " (WithdrawType,Description) " +
                    " values (1,'Løntræk') ";
                cmd.ExecuteNonQuery();
                cmd.CommandText =
                    " INSERT INTO PrlWithdrawType " +
                    " (WithdrawType,Description) " +
                    " values (2,'Benzinkøb') ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Change PrlEmployee.FuncHours to float

                cmd.CommandText = " ALTER TABLE PrlEmployee ALTER COLUMN FuncHours FLOAT ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Add config values

                db.SetConfigString("PayrollMigrated", false);
                db.SetConfigString("WeekFactor", 4.3);
                db.SetConfigString("Payroll.AvgHrsMinorLimit", 8);
                db.SetConfigString("Payroll.AvgHrsMajorLimit", 15);
                db.SetConfigString("Payroll.ExportFileEncrypted", false);
                db.SetConfigString("NAXML_Import_MaintainDaysBack", 90);
                db.SetConfigString("VPRG.Enabled", false); // create værkstedprogram flag

                /// We do not set the two config values "CompactAndRepair.LastDone"
                /// and "CompactAndRepair.Interval" in the version updater, as
                /// they are needed before the updater runs. Instead, the method
                /// that needs them, sets them to default values by itself, if they
                /// are not already set when the method is invoked. They are mentioned
                /// here in the version updater, so if we later make a search for them
                /// this file will tell about when they were created.

                #endregion

                #region Add columns to EOD_Debtor table

                cmd.CommandText = " ALTER TABLE EOD_Debtor ADD COLUMN RRNumber TEXT(20) ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = " ALTER TABLE EOD_Debtor ADD COLUMN Employee BIT ";
                cmd.ExecuteNonQuery();

                #endregion

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, "2.01.017");
                return false;
            }
        }

        #endregion

        #region METHOD: Upd_201018
        // update from version 2.01.017 -> 2.01.018
        private static bool Upd_201018()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                #region Create tables for inactive items catalog

                // create InactiveItem table
                cmd.CommandText = @"
                    CREATE TABLE InactiveItem (
                    ItemID INTEGER NOT NULL,
                    ItemName TEXT(50),
                    ItemType TINYINT,
                    SubCategory TEXT(20),
                    SuggSalesPrice FLOAT,
                    PriceRegulation FLOAT,
                    POSSalesPrice FLOAT,
                    CostPriceLatest FLOAT,
                    Margin FLOAT,
                    BudgetMargin FLOAT,
                    Supplier INTEGER,
                    InStock INTEGER,
                    MinimumStock INTEGER,
                    LastChangeDateTime DATETIME,
                    LastSalesDate DATETIME,
                    LastPurchDate DATETIME,
                    LastInventDate DATETIME,
                    FocusItem BIT,
                    ExternalID TEXT(30),
                    VatRate INTEGER,
                    VatOwner TEXT(20),
                    CreditCategory TEXT(10),
                    InheritCreditCat BIT,
                    AgeRestriction INTEGER,
                    InheritAgeRestric BIT,
                    MOPRestriction INTEGER,
                    InheritMOPRestr BIT,
                    SemiDeleted BIT,
                    ItemTypeCode INTEGER,
                    InheritItemTypeCode BIT,
                    FastPrisVare BIT,
                    IkkeBeholdningsVare BIT,
                    UdmeldtPrDato DATETIME )
                    ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText = @"
                    CREATE UNIQUE INDEX idx_InactiveItem
                    ON InactiveItem (ItemID)
                    WITH PRIMARY
                    ";
                cmd.ExecuteNonQuery();

                // create InactiveSalesPack table
                cmd.CommandText = @"
                    CREATE TABLE InactiveSalesPack (
                    ItemID INTEGER NOT NULL,
                    PackType TINYINT NOT NULL,
                    ReceiptText TEXT(30),
                    ManualPrice BIT,
                    SalesPrice FLOAT,
                    BCType INTEGER,
                    Barcode FLOAT,
                    UpdateShelfLabel BIT,
                    NoOfShLabels INTEGER,
                    SalesPackType TINYINT,
                    EnhedsIndhold FLOAT,
                    IsPrimary BIT,
                    SemiDeleted BIT,
                    ChainBarcode FLOAT,
                    ChainItemID INTEGER,
                    ChainPackType TINYINT,
                    UpdateRSM BIT,
                    UnitPriceNotShown BIT )
                    ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText = @"
                    CREATE UNIQUE INDEX idx_InactiveSalesPack
                    ON InactiveSalesPack (ItemID,PackType)
                    WITH PRIMARY
                    ";
                cmd.ExecuteNonQuery();

                // create InactiveBarcode
                cmd.CommandText = @"
                    CREATE TABLE InactiveBarcode (
                    ItemID INTEGER NOT NULL,
                    PackType TINYINT NOT NULL,
                    Barcode FLOAT NOT NULL,
                    BCType INTEGER,
                    IsPrimary BIT,
                    SemiDeleted BIT )
                    ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText = @"
                    CREATE UNIQUE INDEX idx_InactiveBarcode
                    ON InactiveBarcode (ItemID,PackType,Barcode)
                    WITH PRIMARY
                    ";
                cmd.ExecuteNonQuery();

                // create InactiveSupplierItem
                cmd.CommandText = @"
                    CREATE TABLE InactiveSupplierItem (
                    ID COUNTER NOT NULL,
                    ItemID INTEGER,
                    SupplierNo INTEGER,
                    OrderingNumber FLOAT,
                    KolliSize INTEGER,
                    PackageCost FLOAT,
                    PackageUnitCost FLOAT,
                    IsPrimary BIT,
                    SellingPackType TINYINT,
                    NoOfSellingUnits INTEGER,
                    SellingUnitCost FLOAT )
                    ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText = @"
                    CREATE UNIQUE INDEX idx_InactiveSupplierItem
                    ON InactiveSupplierItem (ID)
                    WITH PRIMARY
                    ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Create views containing SQL that .NET cannot parse in a dataset
                //pn20210211
                cmd.CommandText = @"
                    CREATE VIEW Search_Inactive_Items AS
                    SELECT DISTINCT
                      InactiveItem.ItemID,
                      InactiveItem.ItemName,
                      InactiveItem.SubCategory,
                      SubCategory.Description AS SubCategoryDesc,
                      InactiveBarcode.Barcode,
                      InactiveSalesPack.PackType,
                      InactiveItem.ItemTypeCode,
                      (select top 1 OrderingNumber
                       from InactiveSupplierItem
                       where (InactiveSupplierItem.ItemID = InactiveItem.ItemID)
                       and (InactiveSupplierItem.IsPrimary = Yes)) as OrderingNumber
                    FROM (((InactiveBarcode
                    RIGHT OUTER JOIN InactiveSalesPack
                     ON InactiveBarcode.ItemID = InactiveSalesPack.ItemID
                     AND InactiveBarcode.PackType = InactiveSalesPack.PackType)
                    RIGHT OUTER JOIN InactiveItem
                     ON InactiveSalesPack.ItemID = InactiveItem.ItemID)
                    LEFT OUTER JOIN SubCategory
                     ON InactiveItem.SubCategory = SubCategory.SubCategoryID)
                    WHERE (InactiveItem.SemiDeleted <> Yes)
                    ";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"
                    CREATE VIEW List_Inactive_Items AS
                    select
                      ii.ItemID,
                      ii.ItemName,
                      ii.POSSalesPrice,
                      ii.CostPriceLatest,
                      ii.LastChangeDateTime,
                      sc.Description as SubCategory,
                      (select Barcode from InactiveSalesPack isp where (ii.ItemID = isp.ItemID) and (isp.IsPrimary = true)) as Barcode,
                      (select PackTypeName from LookupPackSize where PackType in (select PackType from InactiveSalesPack isp where (ii.ItemID = isp.ItemID) and (isp.IsPrimary = true))) as PackTypeName,
                      (select SupplierNo from InactiveSupplierItem isi where (ii.ItemID = isi.ItemID) and (isi.IsPrimary = true)) as SupplierNo,
                      (select Description from Supplier where SupplierID in (select SupplierNo from InactiveSupplierItem isi where (ii.ItemID = isi.ItemID) and (isi.IsPrimary = true))) as SupplierName,
                      (select OrderingNumber from InactiveSupplierItem isi where (ii.ItemID = isi.ItemID) and (isi.IsPrimary = true)) as OrderingNumber
                    from (InactiveItem ii
                    left join SubCategory sc
                      on ii.SubCategory = sc.SubCategoryID)
                    ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Delete old views we never use

                cmd.CommandText = " DROP VIEW check_items_salespacks_missing_barcodes "; cmd.ExecuteNonQuery();
                cmd.CommandText = " DROP VIEW check_not_imported "; cmd.ExecuteNonQuery();
                cmd.CommandText = " DROP VIEW Export_ITT "; cmd.ExecuteNonQuery();
                cmd.CommandText = " DROP VIEW Export_MCT "; cmd.ExecuteNonQuery();
                cmd.CommandText = " DROP VIEW hvilke_items_har_ens_bctype_i_sig "; cmd.ExecuteNonQuery();
                cmd.CommandText = " DROP VIEW temp_treeview "; cmd.ExecuteNonQuery();
                cmd.CommandText = " DROP VIEW test "; cmd.ExecuteNonQuery();
                cmd.CommandText = " DROP VIEW testview_how_many_barcodes "; cmd.ExecuteNonQuery();
                cmd.CommandText = " DROP VIEW testview_how_many_salespacks_with_UpdateRSM "; cmd.ExecuteNonQuery();
                cmd.CommandText = " DROP VIEW testview_items_with_lastchangedatetime_not_null "; cmd.ExecuteNonQuery();

                #endregion

                #region Create field InactivateDateTime on Item and InactiveItem

                cmd.CommandText = " ALTER TABLE Item ADD COLUMN InactivateDateTime DATETIME ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = " ALTER TABLE InactiveItem ADD COLUMN InactivateDateTime DATETIME ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Add config values

                db.SetConfigString("ItemsDelete.DaysBackMinimum", 90);
                db.SetConfigString("ExportRSM.EnforceSubCatExport", false);
                db.SetConfigString("PrlRptSalaryEmp.PageBreakAfterEmp", false);

                #endregion

                #region Expand SubCategory table's field CategoryID from int to long
                cmd.CommandText = " ALTER TABLE SubCategory ALTER COLUMN CategoryID INTEGER ";
                cmd.ExecuteNonQuery();
                #endregion

                #region Create tables for waste sheets

                // create waste sheet header table
                cmd.CommandText = @"
                    CREATE TABLE WasteSheetHeader (
                    ID COUNTER NOT NULL,
                    Name TEXT(20) )
                    ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText = @"
                    CREATE UNIQUE INDEX idx_WasteSheetHeader
                    ON WasteSheetHeader (ID)
                    WITH PRIMARY
                    ";
                cmd.ExecuteNonQuery();

                // create waste sheet details table
                cmd.CommandText = @"
                    CREATE TABLE WasteSheetDetails (
                    HeaderID INTEGER,
                    LineNo INTEGER,
                    Barcode FLOAT )
                    ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText = @"
                    CREATE UNIQUE INDEX idx_WasteSheetDetails
                    ON WasteSheetDetails (HeaderID,LineNo)
                    WITH PRIMARY
                    ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Create extra table for EODReconcile to hold imported customer count

                /// When importing EPD files for EOD_Sales, the last record holds the number of customers.
                /// We originally wanted to just store the customer count in the EODReconcile
                /// table, but at the time where the count is imported, it is not guaranteed
                /// that the station has opened the record for the given day in EODReconcile.
                /// This record MUST be created first via the EOD forms. So the solution is to
                /// create a table, EODReconcileEx to hold such values and make a join between the tables.
                /// This will be needed in both DO and RBA.
                cmd.CommandText = @"
                    CREATE TABLE EODReconcileEx (
                    BookDate DATETIME NOT NULL,
                    CustomerCount INTEGER )
                    ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText = @"
                    CREATE UNIQUE INDEX idx_EODReconcileEx
                    ON EODReconcileEx (BookDate)
                    WITH PRIMARY
                    ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Add RBA fields to EODReconcile (will also exist in DO)

                cmd.CommandText = " ALTER TABLE EODReconcile ADD COLUMN NumberOfWashSold INTEGER ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Empty favorites table if this is RBA
#if RBA
                AdminDataSet.favoritesDataTable.EmptyTable();
#endif
                #endregion

                #region Create tables for RBA EOD

                // create table EOD_ManualCards
                cmd.CommandText = @"
                    CREATE TABLE EOD_ManualCards (
                    BookDate DATETIME NOT NULL,
                    LineNo INTEGER NOT NULL,
                    Description TEXT(25),
                    Amount FLOAT )
                    ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText = @"
                    CREATE UNIQUE INDEX idx_EOD_ManualCards
                    ON EOD_ManualCards (BookDate,LineNo)
                    WITH PRIMARY
                    ";
                cmd.ExecuteNonQuery();

                // create table EOD_ForeignCurrency
                cmd.CommandText = @"
                    CREATE TABLE EOD_ForeignCurrency (
                    BookDate DATETIME NOT NULL,
                    LineNo INTEGER NOT NULL,
                    Description TEXT(25),
                    Amount FLOAT )
                    ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText = @"
                    CREATE UNIQUE INDEX idx_EOD_ForeignCurrency
                    ON EOD_ForeignCurrency (BookDate,LineNo)
                    WITH PRIMARY
                    ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Create table Readings

                cmd.CommandText = @"
                    CREATE TABLE Readings (
                    RegDate DATETIME NOT NULL,
                    MainWaterPrimo INTEGER,
                    MainWaterPrimoDate DATETIME,
                    MainWaterReading INTEGER,
                    WashPrimo INTEGER,
                    WashReading INTEGER,
                    KWPrimo INTEGER,
                    KWReading INTEGER )
                    ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText = @"
                    CREATE UNIQUE INDEX idx_Readings
                    ON Readings (RegDate)
                    WITH PRIMARY
                    ";
                cmd.ExecuteNonQuery();

                #endregion

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, "2.01.018");
                return false;
            }
        }

        #endregion

        #region METHOD: Upd_201019
        // update from version 2.01.018 -> 2.01.019
        private static bool Upd_201019()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                #region Set config values

                db.SetConfigString("Readings.SeperateWashReadings", true);
                db.SetConfigString("Readings.StationHasWash", false);
                db.SetConfigString("Readings.Vaskeafstemning2", false);
                db.SetConfigString("Readings.Vaskeafstemning3", false);
                db.SetConfigString("Payroll.ExportFileCreated.Timestamp", "");
                db.SetConfigString("Payroll.ExportFileCreated.Period", "");
                db.SetConfigString("Payroll.ExportFileCreated.PeriodYear", "");
                db.SetConfigString("ImportSalaryHours.RenameInsteadOfDelete", false);

#if RBA
                db.SetConfigString("Backup_ExternalEnabled", false);
                db.SetConfigString("PayrollModuleActive", true);
                db.SetConfigString("RegnskabIF_flag", "service");
                db.SetConfigString("EOD.CheckForWashCount", true);
                db.SetConfigString("Payroll.OvertimeVisible", true);
                db.SetConfigString("Payroll.TakeTimeOffVisible", true);
#endif

                #endregion

                #region Create table Wash

                cmd.CommandText = @"
                    CREATE TABLE Wash (
                    RegDate DATETIME NOT NULL,
                    VaskeTaellerPrimo INTEGER,
                    VaskeTaellerPrimo2 INTEGER,
                    VaskeTaellerPrimo3 INTEGER,
                    VaskeTaellerPrimoDate DATETIME,
                    LuxusMedLakforsegler INTEGER,
                    LuksusVask INTEGER,
                    VaskA INTEGER,
                    VaskB INTEGER,
                    VaskC INTEGER,
                    VolumenVask INTEGER,
                    TeknikerVask INTEGER,
                    TaellerUltimoBeregnet INTEGER,
                    TaellerUltimoAflaest INTEGER,
                    TaellerUltimoAflaest2 INTEGER,
                    TaellerUltimoAflaest3 INTEGER,
                    SamletDifference INTEGER )
                    ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText = @"
                    CREATE UNIQUE INDEX idx_Wash
                    ON Wash (RegDate)
                    WITH PRIMARY
                    ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Drop view List_Inactive_Items

                // we do not use the view List_Inactive_Items anymore
                // as it was too slow and created a constraint-violation
                // exceptions for some reason. instead we have simplified
                // the data extraction and have inserted the sql directly
                // into the dataadapter ItemDataSet.IncativeItem instead.

                cmd.CommandText = " DROP VIEW List_Inactive_Items ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Add tables for Daglig salgsstatistik

                // create table SalesStatDailyColumns
                cmd.CommandText = @"
                    CREATE TABLE SalesStatDailyColumns (
                    ID INTEGER NOT NULL,
                    HeaderText TEXT(20),
                    Description TEXT(50),
                    UnitOrAmount INTEGER,
                    ColumnNo INTEGER,
                    Average BIT,
                    SystemColumn BIT)
                    ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText = @"
                    CREATE UNIQUE INDEX idx_SalesStatDailyColumns
                    ON SalesStatDailyColumns (ID)
                    WITH PRIMARY
                    ";
                cmd.ExecuteNonQuery();

                // create table SalesStatDailyAccounts
                cmd.CommandText = @"
                    CREATE TABLE SalesStatDailyAccounts (
                    ID COUNTER NOT NULL,
                    ColumnID INTEGER NOT NULL,
                    AccountFrom TEXT(8),
                    AccountTo TEXT(8) )
                    ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText = @"
                    CREATE UNIQUE INDEX idx_SalesStatDailyAccounts
                    ON SalesStatDailyAccounts (ID,ColumnID)
                    WITH PRIMARY
                    ";
                cmd.ExecuteNonQuery();

                // create table LookupUnitOrAmount
                cmd.CommandText = @"
                    CREATE TABLE LookupUnitOrAmount (
                    ID INTEGER NOT NULL,
                    Description TEXT(10) )
                    ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText = @"
                    CREATE UNIQUE INDEX idx_LookupUnitOrAmount
                    ON LookupUnitOrAmount (ID)
                    WITH PRIMARY
                    ";
                cmd.ExecuteNonQuery();

                // fill table LookupUnitOrAmount
                cmd.CommandText = @"
                    INSERT INTO LookupUnitOrAmount (ID,Description)
                    VALUES (1,'Liter');
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    INSERT INTO LookupUnitOrAmount (ID,Description)
                    VALUES (2,'Beløb');
                    ";
                cmd.ExecuteNonQuery();

                // fill table SalesStatDailyColumns with default values
                cmd.CommandText = @"
                    INSERT INTO SalesStatDailyColumns (ID,HeaderText,Description,UnitOrAmount,ColumnNo,Average,SystemColumn)
                    VALUES (1,'Total Shop','Shop',2,1,0,true)
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    INSERT INTO SalesStatDailyColumns (ID,HeaderText,Description,UnitOrAmount,ColumnNo,Average,SystemColumn)
                    VALUES (2,'Total benzin','Benzin litre',1,2,0,true)
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    INSERT INTO SalesStatDailyColumns (ID,HeaderText,Description,UnitOrAmount,ColumnNo,Average,SystemColumn)
                    VALUES (3,'Total diesel','Diesel litre',1,3,0,true)
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    INSERT INTO SalesStatDailyColumns (ID,HeaderText,Description,UnitOrAmount,ColumnNo,Average,SystemColumn)
                    VALUES (4,'Fastfood','Fastfood',2,4,0,false)
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    INSERT INTO SalesStatDailyColumns (ID,HeaderText,Description,UnitOrAmount,ColumnNo,Average,SystemColumn)
                    VALUES (5,'Vask','Vask kr.',2,5,0,false)
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    INSERT INTO SalesStatDailyColumns (ID,HeaderText,Description,UnitOrAmount,ColumnNo,Average,SystemColumn)
                    VALUES (6,'Cigaretter','Cigaretter',2,6,1,false)
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    INSERT INTO SalesStatDailyColumns (ID,HeaderText,Description,UnitOrAmount,ColumnNo,Average,SystemColumn)
                    VALUES (7,'Bakeoff','Bakeoff',2,0,0,false)
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    INSERT INTO SalesStatDailyColumns (ID,HeaderText,Description,UnitOrAmount,ColumnNo,Average,SystemColumn)
                    VALUES (8,'Drikkevarer','Drikkevarer',2,0,0,false)
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    INSERT INTO SalesStatDailyColumns (ID,HeaderText,Description,UnitOrAmount,ColumnNo,Average,SystemColumn)
                    VALUES (9,'Taletid kort','Taletid kort',2,0,0,false)
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    INSERT INTO SalesStatDailyColumns (ID,HeaderText,Description,UnitOrAmount,ColumnNo,Average,SystemColumn)
                    VALUES (10,'Konfekture','Konfekture',2,0,0,false)
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    INSERT INTO SalesStatDailyColumns (ID,HeaderText,Description,UnitOrAmount,ColumnNo,Average,SystemColumn)
                    VALUES (11,'Anden tobak','Anden tobak',2,0,0,false)
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    INSERT INTO SalesStatDailyColumns (ID,HeaderText,Description,UnitOrAmount,ColumnNo,Average,SystemColumn)
                    VALUES (12,'Vinterprodukter','Vinterprodukter',2,0,0,false)
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    INSERT INTO SalesStatDailyColumns (ID,HeaderText,Description,UnitOrAmount,ColumnNo,Average,SystemColumn)
                    VALUES (13,'Is','Is',2,0,0,false)
                    ";
                cmd.ExecuteNonQuery();

                // fill data into SalesStatDailyAccounts
                cmd.CommandText = @"
                    INSERT INTO SalesStatDailyAccounts (ColumnID,AccountFrom,AccountTo)
                    VALUES (1,'1050','1289')
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    INSERT INTO SalesStatDailyAccounts (ColumnID,AccountFrom,AccountTo)
                    VALUES (1,'1300','1449')
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    INSERT INTO SalesStatDailyAccounts (ColumnID,AccountFrom,AccountTo)
                    VALUES (2,'1004','1008')
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    INSERT INTO SalesStatDailyAccounts (ColumnID,AccountFrom,AccountTo)
                    VALUES (3,'1012','1012')
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    INSERT INTO SalesStatDailyAccounts (ColumnID,AccountFrom,AccountTo)
                    VALUES (4,'1446','1446')
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    INSERT INTO SalesStatDailyAccounts (ColumnID,AccountFrom,AccountTo)
                    VALUES (5,'1290','1296')
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    INSERT INTO SalesStatDailyAccounts (ColumnID,AccountFrom,AccountTo)
                    VALUES (6,'1080','1080')
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    INSERT INTO SalesStatDailyAccounts (ColumnID,AccountFrom,AccountTo)
                    VALUES (7,'1441','1441')
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    INSERT INTO SalesStatDailyAccounts (ColumnID,AccountFrom,AccountTo)
                    VALUES (8,'1146','1148')
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    INSERT INTO SalesStatDailyAccounts (ColumnID,AccountFrom,AccountTo)
                    VALUES (9,'1180','1180')
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    INSERT INTO SalesStatDailyAccounts (ColumnID,AccountFrom,AccountTo)
                    VALUES (10,'1121','1121')
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    INSERT INTO SalesStatDailyAccounts (ColumnID,AccountFrom,AccountTo)
                    VALUES (11,'1090','1090')
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    INSERT INTO SalesStatDailyAccounts (ColumnID,AccountFrom,AccountTo)
                    VALUES (12,'1056','1056')
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    INSERT INTO SalesStatDailyAccounts (ColumnID,AccountFrom,AccountTo)
                    VALUES (13,'1122','1122')
                    ";
                cmd.ExecuteNonQuery();

                // create table SalesStatRpt
                cmd.CommandText = @"
                    CREATE TABLE SalesStatRpt (
                    PrintSection TEXT(20) NOT NULL,
                    RowText TEXT(20) NOT NULL,
                    BookDate DATETIME,
                    TotalShop FLOAT,
                    TotalBenzin FLOAT,
                    TotalDiesel FLOAT,
                    Custom1 FLOAT,
                    Custom2 FLOAT,
                    Custom3 FLOAT,
                    AntalKunder INTEGER,
                    GnsSalgKolPrKunde FLOAT,
                    VPowerPct FLOAT,
                    VPowerLiter FLOAT,
                    SortOrder INTEGER )
                    ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText = @"
                    CREATE UNIQUE INDEX idx_SalesStatRpt
                    ON SalesStatRpt (PrintSection,RowText)
                    WITH PRIMARY
                    ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Rename config string "PayrollMigrated" to "SSIPMigrated"

                db.SetConfigString("SSIPMigrated", db.GetConfigString("PayrollMigrated"));
                db.RemoveConfigString("PayrollMigrated");

                #endregion

                #region Clean user table but leave standard users
                cmd.CommandText = @"
                    delete from Users
                    where (Username <> 'admin')
                    and (Username <> 'drs')
                    and (Username <> 'support')
                    and (Username <> 'daglig')
                    and (Username <> 'assistent')
                    ";
                cmd.ExecuteNonQuery();
                #endregion

                #region Create table Readings again (had errors before)

                /// It seems like something was wrong in the Readings table.
                /// First of all it shouldn't have been created before version 2.01.019.
                /// Second, some fields were missing, so now we recreate it.
                /// Third, it was discovered for version 2.01.023, that some DO stations
                /// did actually not have that Readings table created, so we have encapsulated
                /// the drop table statement in a try catch block.
                
                try
                {
                    // drop table Readings (if existing)
                    cmd.CommandText = "DROP TABLE Readings";
                    cmd.ExecuteNonQuery();
                }
                catch { /* Readings table was not found */ }

                cmd.CommandText = @"
                    CREATE TABLE Readings (
                    RegDate DATETIME NOT NULL,
                    PrimoDate DATETIME,
                    MainWaterPrimo INTEGER,
                    MainWaterReading INTEGER,
                    MainWaterUse INTEGER,
                    WashPrimo INTEGER,
                    WashReading INTEGER,
                    WashUse INTEGER,
                    KWPrimo INTEGER,
                    KWReading INTEGER,
                    KWUse INTEGER)
                    ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText = @"
                    CREATE UNIQUE INDEX idx_Readings
                    ON Readings (RegDate)
                    WITH PRIMARY
                    ";
                cmd.ExecuteNonQuery();

                #endregion

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, "2.01.019");
                return false;
            }
        }

        #endregion

        #region METHOD: Upd_201020
        // update from version 2.01.019 -> 2.01.020
        private static bool Upd_201020()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                #region Add RBA ReserveTerminal field to EOD tables

                cmd.CommandText = " ALTER TABLE EODReconcile ADD COLUMN ReserveTerminal FLOAT ";
                cmd.ExecuteNonQuery();

                // create table EOD_ReserveTerminal
                cmd.CommandText = @"
                    CREATE TABLE EOD_ReserveTerminal (
                    BookDate DATETIME NOT NULL,
                    LineNo INTEGER NOT NULL,
                    Description TEXT(25),
                    Amount FLOAT )
                    ";
                cmd.ExecuteNonQuery();
                // add index
                cmd.CommandText = @"
                    CREATE UNIQUE INDEX idx_EOD_ReserveTerminal
                    ON EOD_ReserveTerminal (BookDate,LineNo)
                    WITH PRIMARY
                    ";
                cmd.ExecuteNonQuery();
                // save data to disk
                db.CommitTransaction();

                #endregion

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, "2.01.020");
                return false;
            }
        }

        #endregion

        #region METHOD: Upd_201021
        // update from version 2.01.020 -> 2.01.021
        private static bool Upd_201021()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                // select the latest migration date
                cmd.CommandText = "select max(BookDate) from EODReconcile where ApprovedBy = 'MIGR'";
                DateTime MaxMigrBookDate = tools.object2datetime(cmd.ExecuteScalar()).Date;
                // all EOD_LocalCred records of type 1 and 2 up until and including this date will be swapped
                if (MaxMigrBookDate != DateTime.MinValue)
                {
                    // first convert transtype 1 to 9 to avoid key vilations when swapping
                    cmd.CommandText = string.Format(@"
            update EOD_LocalCred
            set TransType = 9
            where (TransType = 1)
            and (BookDate <= cdate('{0}'))
            ", MaxMigrBookDate);
                    cmd.ExecuteNonQuery();
                    // convert transtype 2 to 1
                    cmd.CommandText = string.Format(@"
            update EOD_LocalCred
            set TransType = 1
            where (TransType = 2)
            and (BookDate <= cdate('{0}'))
            ", MaxMigrBookDate);
                    cmd.ExecuteNonQuery();
                    // convert transtype 1 to 2 (via temp type 9)
                    cmd.CommandText = string.Format(@"
            update EOD_LocalCred
            set TransType = 2
            where (TransType = 9)
            and (BookDate <= cdate('{0}'))
            ", MaxMigrBookDate);
                    cmd.ExecuteNonQuery();
                    // revert transtype 3 figures
                    cmd.CommandText = string.Format(@"
            update EOD_LocalCred
            set Amount = (Amount * -1)
            where (TransType = 3)
            and (BookDate <= cdate('{0}'))
            ", MaxMigrBookDate);
                    cmd.ExecuteNonQuery();
                }

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, "2.01.021");
                return false;
            }
        }

        #endregion

        #region METHOD: Upd_201022
        // update from version 2.01.021 -> 2.01.022
        private static bool Upd_201022()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                #region Create two new salary period fields on table PrlAbsense

                cmd.CommandText = "ALTER TABLE PrlAbsense ADD COLUMN PeriodYear INTEGER";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "ALTER TABLE PrlAbsense ADD COLUMN Period INTEGER";
                cmd.ExecuteNonQuery();

                #endregion

                #region Bind PrlAbsense registrations to the two new salary period fields

                DataTable AbsenseRegistrations = db.GetDataTable("select ID,FromDateAsDateTime from PrlAbsense");
                foreach(DataRow AbsenseRegistration in AbsenseRegistrations.Rows)
                {
                    int ID = tools.object2int(AbsenseRegistration["ID"]);
                    DateTime StartDate = tools.object2datetime(AbsenseRegistration["FromDateAsDateTime"]);
                    DataRow SalaryPeriod = Payroll.PrlSalaryPeriodsDataTable.GetSalaryPeriod(StartDate);
                    if (SalaryPeriod != null)
                    {
                        int PeriodYear = tools.object2int(SalaryPeriod["PeriodYear"]);
                        int Period = tools.object2int(SalaryPeriod["Period"]);
                        db.ExecuteNonQuery(string.Format(@"
                            update PrlAbsense set
                            PeriodYear = {1},
                            Period = {2}
                            where ID = {0}
                            ", ID, PeriodYear, Period));
                    }
                }

                #endregion

                #region Repair incorrectly migrated absense data

                /// The migrater has copied absense data from the ssip database to rbos.
                /// In this process, the migrater didn't correctly copy absense records
                /// that had equal to/from dates and had 0 in hours. This should have been
                /// interpreted as 1 day, but instead it was interpreted as 0 days (and 0 hours).

                cmd.CommandText = @"
                    update PrlAbsense
                    set Days = 1
                    where (FromDateAsDateTime = ToDateAsDateTime)
                    and ((Hours = 0) or (Hours is null))
                    and ((Days = 0) or (Days is null))
                    ";
                cmd.ExecuteNonQuery();

                #endregion

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, "2.01.022");
                return false;
            }
        }
        #endregion

        #region METHOD: Upd_201023
        // update from version 2.01.022 -> 2.01.023
        private static bool Upd_201023()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                #region Alter primary index on PrlAgreement

                cmd.CommandText = "DROP INDEX idx_PrlAgreement ON PrlAgreement";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "ALTER TABLE PrlAgreement ALTER COLUMN FromTime DATETIME NOT NULL";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "ALTER TABLE PrlAgreement ALTER COLUMN ToTime DATETIME NOT NULL";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"
                                CREATE UNIQUE INDEX idx_PrlAgreement
                                ON PrlAgreement (AgreementCode,BonusCode,FromTime,ToTime)
                                WITH PRIMARY
                                ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Alter primary index on PrlAgreementStatic

                cmd.CommandText = "DROP INDEX idx_PrlAgreementStatic ON PrlAgreementStatic";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "ALTER TABLE PrlAgreementStatic ALTER COLUMN Day1 BIT NOT NULL";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "ALTER TABLE PrlAgreementStatic ALTER COLUMN Day2 BIT NOT NULL";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "ALTER TABLE PrlAgreementStatic ALTER COLUMN Day3 BIT NOT NULL";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "ALTER TABLE PrlAgreementStatic ALTER COLUMN Day4 BIT NOT NULL";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "ALTER TABLE PrlAgreementStatic ALTER COLUMN Day5 BIT NOT NULL";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "ALTER TABLE PrlAgreementStatic ALTER COLUMN Day6 BIT NOT NULL";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "ALTER TABLE PrlAgreementStatic ALTER COLUMN Day7 BIT NOT NULL";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"
                                CREATE UNIQUE INDEX idx_PrlAgreementStatic
                                ON PrlAgreementStatic (BonusCode,Day1,Day2,Day3,Day4,Day5,Day6,Day7)
                                WITH PRIMARY
                                ";
                cmd.ExecuteNonQuery();

                #endregion

                #region This may only be done on DO stations
#if !RBA        

                #region Run through all Import_RPOS_MSM_Details records and calculate customercount for EODReconcileEx records

                ProgressForm progress = new ProgressForm("Beregner antal kunder");
                progress.Show();
                DataTable table_Import_RPOS_MSM_Details = db.GetDataTable("select * from Import_RPOS_MSM_Details");
                progress.ProgressMax = table_Import_RPOS_MSM_Details.Rows.Count;
                foreach (DataRow row in table_Import_RPOS_MSM_Details.Rows)
                {
                    /*disabled in v43
                    DateTime BookDate = tools.object2datetime(row["BookDate"]);
                    int CustomerCount = ImportDataSet.Import_RPOS_MSM_DetailsDataTable.CalculateCustomerCount(BookDate);
                    EODDataSet.EODReconcileExDataTable.InsertOrUpdateRecord(BookDate, CustomerCount);
                    progress.StatusText = "Beregner";*/
                }
                progress.Close();

                #endregion

                #region Repair ItemTransaction data

                ItemDataSet.ItemTransactionDataTable.RepairSalgOptRecords();
                ItemDataSet.ItemDataTable.ReCalculateInStockAllItems();

                #endregion

#endif

                #endregion

                #region Create config value for salesreport "do not show 0-lines" checkmark

                db.SetConfigString("SalesReportFrm.DoNotShow0Lines", true);

                #endregion

                #region Add column CostExVAT column to OrderDetails table

                cmd.CommandText = "ALTER TABLE OrderDetails ADD COLUMN CostExVAT FLOAT";
                cmd.ExecuteNonQuery();

                #endregion

                #region Correct a system column for sales statistics report
                cmd.CommandText = @"
                    update SalesStatDailyAccounts
                    set AccountFrom = '1005'
                    where (ColumnID = 2)
                    and (AccountFrom = '1004')
                    and (AccountTo = '1008')
                    ";
                cmd.ExecuteNonQuery();
                #endregion

                #region Create config value SalesReportFrm.IncludeFuel
                /// NOTE: vi har tilføjet en config value "SalesReportFrm.IncludeFuel" i
                /// formen SalesReportFrm, som ikke er lagt ind her i version updater, da
                /// vi ikke ønskede at lave en database update, da den allerede var i pilot.
                #endregion

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, "2.01.023");
                return false;
            }
        }
        #endregion

        #region METHOD: Upd_201024
        // update from version 2.01.023 -> 2.01.024
        private static bool Upd_201024()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                /* nothing to be done in this version */

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, "2.01.024");
                return false;
            }
        }
        #endregion

        #region METHOD: Upd_201025
        // update from version 2.01.024 -> 2.01.025
        private static bool Upd_201025()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                /* nothing done yet in this version */

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, "2.01.025");
                return false;
            }
        }
        #endregion

        #region METHOD: Upd_201026
        // update from version 2.01.025 -> 2.01.026
        private static bool Upd_201026()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                #region Add new FSD fields to various tables
                cmd.CommandText = " ALTER TABLE ItemUpdLines ADD COLUMN FSD_ID INTEGER ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = " ALTER TABLE ItemUpdLines ADD COLUMN KampagneID INTEGER ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = " ALTER TABLE Item ADD COLUMN KampagneID INTEGER ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = " ALTER TABLE Item ADD COLUMN FSD_ID INTEGER ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = " ALTER TABLE Item ADD COLUMN RSMNeedsNewID BIT ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = " ALTER TABLE InactiveItem ADD COLUMN KampagneID INTEGER ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = " ALTER TABLE InactiveItem ADD COLUMN FSD_ID INTEGER ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = " ALTER TABLE SalesPack ADD COLUMN UpdateStations BIT ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = " ALTER TABLE InactiveSalesPack ADD COLUMN UpdateStations BIT ";
                cmd.ExecuteNonQuery();
                #endregion

                #region Add some config values

                db.SetConfigString("FSD_ID", 0); // will be overwritten i FSD version, is here just to have consistency
                db.SetConfigString("FVDExportFileDir", "c:\\drs\\depart"); // just a suggestion
                db.SetConfigString("BackupFVDFilesActive", false);
                db.SetConfigString("ImportItemsCSVFrm.LastUsedDir", ""); // for remembering dir when importing 3rd party csv file with item data
                db.SetConfigString("ImportItemsCSVFrm.IncludeNewItems", false);
                

                #endregion

                #region Expand a column on ItemUpdLines table
                cmd.CommandText = " alter table ItemUpdLines alter column Name text(50) ";
                cmd.ExecuteNonQuery();
                #endregion

                #region Opret tabel til udmeldte bestillingsnumre fra FSD til stationerne
                /// Denne tabel bruges til at kopiere semideled bestillingsnumre ind i,
                /// således at vi har dem, når der sendes ud til stationerne. Bruges
                /// kun i FSD version. Basalt en klon af SupplierItem tabellen bortset
                /// fra at ID ikke er en autoint her, men en integer, så der kan kopieres
                /// direkte fra SupplierItem tabellen, samt at der er et HistoricExportFVDHeaderID
                /// felt, der, hvis det er udfyldt, betyder, at recorden ikke må røres igen,
                /// da den nu er bundet til en ExportFVDHeader record, der er sendt til stationerne.
                cmd.CommandText = @"
                    create table FSDDeletedSupplierItem (
                    ID integer not null,
                    ItemID integer,
                    SupplierNo integer,
                    OrderingNumber float,
                    KolliSize integer,
                    PackageCost float,
                    PackageUnitCost float,
                    IsPrimary bit,
                    SellingPackType tinyint,
                    NoOfSellingUnits integer,
                    SellingUnitCost float,
                    HistoricExportFVDHeaderID integer) ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    create unique index idx_FSDDeletedSupplierItem
                    on FSDDeletedSupplierItem (ID)
                    with primary
                    ";
                cmd.ExecuteNonQuery();
                #endregion

                #region Opret header tabel til FVD udtræk
                cmd.CommandText = string.Format(@"
                    create table ExportFVDHeader (
                    ID counter not null,
                    ExportDateTime datetime,
                    SentOutDateTime datetime,
                    Filename text(255),
                    NumDetailRecords integer,
                    Criteria text(255)
                    )");
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(@"
                    create unique index idx_ExportFVDHeader
                    on ExportFVDHeader (ID)
                    with primary
                    ");
                cmd.ExecuteNonQuery();
                #endregion

                #region Opret details tabel til FVD udtræk
                cmd.CommandText = string.Format(@"
                    create table ExportFVDDetails (
                    ID counter not null,
                    HeaderID integer,
                    Stregkode float,
                    Bestillnr float,
                    Varetekst text(50),
                    Kolli integer,
                    Subcat text(20),
                    Kostpris float,
                    Salgspris float,
                    Leverandoernr integer,
                    KampagneID integer,
                    FSD_ID integer
                    )");
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(@"
                    create unique index idx_ExportFVDDetails
                    on ExportFVDDetails (ID)
                    with primary
                    ");
                cmd.ExecuteNonQuery();
                #endregion

                #region Create a default set of LLSupplierNo values on Supplier table where they are NULL
                cmd.CommandText = @"
                    update Supplier set
                    LLSupplierNo = (1000 + SupplierID)
                    where (LLSupplierNo is null)
                    or (LLSupplierNo = 0)
                    ";
                cmd.ExecuteNonQuery();
                #endregion

                #region If FSD, assign values to FSD_ID where they are NULL
#if FSD
                cmd.CommandText = "update Item set FSD_ID = (1000000 + ItemID) where FSD_ID is null";
                cmd.ExecuteNonQuery();

                // nu da vi har udfyldt alle FSD_IDer, sætter vi den næste mulige FSD_ID i config
                int NextFSD_ID = tools.object2int(db.ExecuteScalar("select max(FSD_ID) from Item"));
                db.SetConfigString("FSD_ID", NextFSD_ID);

#endif
                #endregion

                #region Add column Origin to table ItemUpdates

                cmd.CommandText = " ALTER TABLE ItemUpdates ADD COLUMN Origin TEXT(3) ";
                cmd.ExecuteNonQuery();

                #endregion

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, "2.01.026");
                return false;
            }
        }
        #endregion

        #region METHOD: Upd_201027
        // update from version 2.01.026 -> 2.01.027
        private static bool Upd_201027()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                #region Create BFI_Stations table

                /// When we, in the GUI, want to show the latest
                /// export file, that a station has been sent, link
                /// this table with the BFI_ExportHistory table.

                cmd.CommandText = @"
                    create table BFI_Stations (
                    SiteCode text(4) not null,
                    SiteName text(50),
                    ExportBFI_ActiveFTP bit,
                    ExportBFI_HistoryID int,
                    ExportBFI_IsTestStation bit
                    )";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    create unique index BFI_Stations
                    on BFI_Stations (SiteCode)
                    with primary
                    ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Create BFI_ExportHistory table

                /// This is the BFI export history table that
                /// gets a record each time a BFI file is sent out.
                /// When showing it in the GUI and we want to
                /// show how many stations were included, link this
                /// table with the BFI_ExportHistory_rel_Stations table.

                cmd.CommandText = @"
                    create table BFI_ExportHistory (
                    ID counter not null,
                    Filename text(255),
                    DateTimeSentOut datetime
                    )";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    create unique index idx_BFI_ExportHistory
                    on BFI_ExportHistory (ID)
                    with primary
                    ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Create BFI history/stations relation table

                /// When a BFI is sent out (exported),
                /// it is saved in the BFI_ExportHistory table.
                /// For each entry in this table, there will be
                /// a number of stations that got the file.
                /// This relation is saved in the BFI_ExportHistory_rel_Stations table.

                cmd.CommandText = @"
                    create table BFI_ExportHistory_rel_Stations (
                    HistoryID integer not null,
                    SiteCode text(4) not null
                    )";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    create unique index idx_BFI_ExportHistory_rel_Stations
                    on BFI_ExportHistory_rel_Stations (HistoryID,SiteCode)
                    with primary
                    ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Create BFI export config values

                /// This value is set by selecting a value in the BFI Stations window.
                /// It is used to select which FTP account (created in the FTP account window)
                /// that is to be used when uploading the BFI file to multiple stations)
                db.SetConfigString("BFI.Export.FTPAccount", "");
                
                /// This value will be used as directory where BFI files
                /// will be archived after they have been sent out.
                db.SetConfigString("BFI.Export.ArchiveDir", "");

                /// This is the directory to be opened by default
                /// when looking for a BFI file to send out.
                db.SetConfigString("BFI.Export.LastDir", "");

                #endregion

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, "2.01.027");
                return false;
            }
        }
        #endregion

        #region METHOD: Upd_201028
        // update from version 2.01.027 -> 2.01.028
        private static bool Upd_201028()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                #region SparPOS additions

                // create table SparPOSTransactions
                cmd.CommandText = @"
                    create table SparPOSTransactions (
                    ID counter not null,
                    BookDate datetime,
                    BookType text(4),
                    Account text(12),
                    Category text(4),
                    Description text(40),
                    Amount float,
                    NumberOf int
                    )";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    create unique index idx_SparPOSTransactions
                    on SparPOSTransactions (ID)
                    with primary
                    ";
                cmd.ExecuteNonQuery();

                // create table SparPOSAccountActions
                cmd.CommandText = @"
                    create table SparPOSAccountActions (
                    Account text(12) not null,
                    ActionCode text(10) not null
                    )";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    create unique index idx_SparPOSAccountActions
                    on SparPOSAccountActions (Account,ActionCode)
                    with primary
                    ";
                cmd.ExecuteNonQuery();

                // create table SparPOSAccountMapping
                cmd.CommandText = @"
                    create table SparPOSAccountMapping (
                    SparPOSCategory text(4) not null,
                    RBOSSubCategory text(20) not null
                    )";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    create unique index idx_SparPOSAccountMapping
                    on SparPOSAccountMapping (SparPOSCategory,RBOSSubCategory)
                    with primary
                    ";
                cmd.ExecuteNonQuery();

                // add config entries
                db.SetConfigString("SparPOS.ImportActive", false);
                db.SetConfigString("SparPOS.ImportFolder", "");
                db.SetConfigString("SparPOS.ImportFilePattern", "Spar*.csv");
                db.SetConfigString("SparPOS.ImportBackupActive", false);
                db.SetConfigString("SparPOS.ImportBackupFolder", "");

                // expand table EOD_PayinPayout with a field indicating if the data was imported or entered
                cmd.CommandText = "alter table EOD_PayinPayout add column Imported bit";
                cmd.ExecuteNonQuery();

                #endregion

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, "2.01.028");
                return false;
            }
        }
        #endregion

        #region METHOD: Upd_201030
        // update from version 2.01.029 -> 2.01.030
        private static bool Upd_201030()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                // boolean telling if ITT exporter will write supplier items in the ITT file.
                // this is only in BFI versions sending to RCM.
                db.SetConfigString("ExportRSM.ExportITT.ExportSupplierItems", false);

                /// Boolean telling if IIT exporter will write price information
                /// into the Description field.
                db.SetConfigString("ExportRSM.ExportITT.MapPriceInDescription", false);

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, "2.01.030");
                return false;
            }
        }
        #endregion

        #region METHOD: Upd_201031
        // update from version 2.01.030 -> 2.01.031
        private static bool Upd_201031()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                // alter debtor table to hold a remarks field
                cmd.CommandText = "alter table EOD_Debtor add column Remarks TEXT(255)";
                cmd.ExecuteNonQuery();

                // add a general debtor remarks entry in config
                db.SetConfigString("EOD.Debtor.Statement.StandardRemarks", "");

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, "2.01.030");
                return false;
            }
        }
        #endregion

        #region Update to version 2.01.034
        private static bool Upd_201034()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                // Detect items with duplicate FSD_IDs and write log to DRS if needed
                ItemDataSet.ItemDataTable.WriteDRSItemLog_DuplicateFSD_IDs("Version updater", true);

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, ExeVersion);
                return false;
            }
        }
        #endregion

        #region Update to version 2.01.035
        private static bool Upd_201035()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                #region Create table AfskrProd (RBA)

                /// This is the RBA version of the Item table.
                /// RBA only has afskrivninger at the moment and
                /// this is the afskrivninger produktkatalog.

                cmd.CommandText = @"
                    create table AfskrProd (
                    LevNr integer not null,
                    Varenummer float not null,
                    Beskrivelse text(255),
                    Kostpris float,
                    Salgspris float,
                    Varegruppe text(20),
                    Barcode float,
                    GenerelVare bit,
                    LevKategori text(30))";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    create unique index idx_AfskrProd
                    on AfskrProd (LevNr,Varenummer)
                    with primary";
                cmd.ExecuteNonQuery();
                #endregion

                #region Create waste sheet details table for RBA
                cmd.CommandText = @"
                    CREATE TABLE WasteSheetDetailsRBA (
                    HeaderID INTEGER,
                    LineNo INTEGER,
                    LevNr INTEGER,
                    Varenummer FLOAT)
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    CREATE UNIQUE INDEX idx_WasteSheetDetailsRBA
                    ON WasteSheetDetailsRBA (HeaderID,LineNo)
                    WITH PRIMARY
                    ";
                cmd.ExecuteNonQuery();
                #endregion

                #region Create waste registration table for RBA
                cmd.CommandText = @"
                    create table WasteRegistrationRBA (
                    ID counter not null,
                    LevNr integer,
                    Varenummer double,
                    Varenavn text(255),
                    Salgspris float,
                    Barcode float,
                    Kostpris float,
                    Varegruppe text(20),
                    Antal integer,
                    ManualInput bit)
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    create unique index idx_WasteRegistrationRBA
                    on WasteRegistrationRBA (ID)
                    with primary
                    ";
                cmd.ExecuteNonQuery();
                #endregion

                #region Create ItemTransactionRBA table

                /// RBA gets their own transaction table,
                /// as many fields are different from the DO version.
                /// The TransactionNumber is still fetched from the
                /// TransactionID in the config table.
                
                /// Varenavn is redundatly put in here on purpose,
                /// as we cannot guarantee that the corresponding item
                /// in AfskrProd still exists when user prints out the
                /// transactions, hence the item name would not be possible
                /// to look up.

                cmd.CommandText = @"
                    create table ItemTransactionRBA (
                    TransactionNumber integer not null,
                    PostingDate datetime,
                    LevNr integer,
                    Varenummer float,
                    Varenavn text(255),
                    NumberOf integer,
                    Amount float,
                    Initials text(10) )";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    create unique index idx_ItemTransactionRBA
                    on ItemTransactionRBA (TransactionNumber)
                    with primary ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Repair items with invalid chain item

                /// These changes were actually made after 3 RBA stations had
                /// the 35 release. However, the changes are DO specific, so it
                /// does not matter.

                /// Some items might by an error have a chain item reference, that points to nothing.
#if !RBA
                ItemDataSet.ItemDataTable.RepairItemsWithInvalidChainItem();
#endif

                #endregion

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, ExeVersion);
                return false;
            }
        }
        #endregion

        #region Update to version 2.01.036
        private static bool Upd_201036()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                #region Adding EjRefunderet column to the PrlAbsense table

                cmd.CommandText = "alter table PrlAbsense add column EjRefunderet bit";
                cmd.ExecuteNonQuery();

                #endregion

                #region Add config values
                db.SetConfigString("FullTimeHours", 160.33);
                db.SetConfigString("Payroll.InputFuncAbsenseWithText", false); // used to disallow datetime pickers for func absense registration
                db.SetConfigString("WasteRBA.Active", true);
                db.SetConfigString("ImportFVD.AllowAutoUpdateSubCategory", true);
                #endregion

                #region Add column InactiveDate to table PrlEmployee

                /// NOTE: The field NotIncludedInReg in table PrlEmployee was originally
                /// thought to have a functionallity similar to what we create with the InactiveDate
                /// field. NotIncludedInReg is a remnisence from the old SSIP system. We have
                /// not removed it, as it does not matter and if we remove it we have to test it.
                /// We have however removed it's language string from lang.xml and we have removed
                /// the control from the UI.

                cmd.CommandText = "alter table PrlEmployee add column InactiveDate datetime";
                cmd.ExecuteNonQuery();

                #endregion

                #region Create lent employee
                cmd.CommandText = string.Format(@"
                    insert into PrlEmployee (EmployeeNo, FirstName, LastName, StartDate, EmployeeType, Funchours)
                    values ({0}, 'Indlånt', 'medarbejder', cdate('{1}'), 'Arbejder', 0)",
                    Payroll.PrlEmployeeDataTable.LentEmployeeNo,
                    new DateTime(2000, 1, 1));
                cmd.ExecuteNonQuery();
                #endregion

                #region For all stations disable BHI export backup files
                /// We disable this because nobody ever uses those backup files
                /// and the backup is very slow over the stations local network
                /// and causes the export progress form to freeze while copying the file.
                db.SetConfigString("BHHT_Export_Backup_Active", false);
                #endregion

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, ExeVersion);
                return false;
            }
        }
        #endregion

        #region Update to version 2.01.037
        private static bool Upd_201037()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                #region Add column Inactive to table AfskrProd
                cmd.CommandText = "alter table AfskrProd add column Inactive bit";
                cmd.ExecuteNonQuery();
                #endregion

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, ExeVersion);
                return false;
            }
        }
        #endregion

        #region Update to version 2.01.038
        private static bool Upd_201038()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                #region Add config values
                db.SetConfigString("Payroll.AbsensePrintFollowPayrollPeriod", false);
                #endregion

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, ExeVersion);
                return false;
            }
        }
        #endregion

        #region Update to version 2.01.039
        private static bool Upd_201039()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                /// Vi har et problem i databasen når BFI udmelder LL varer. Der kommer en exception
                /// når den prøver at kopiere en record fra SupplierItem over i FSDDeletedSupplierItem,
                /// hvis source tabellens ID allerede eksisterer i destination tabellen. Dette kan ske
                /// hvis der er blevet udmeldt varer fra source tabellen og databasen efterfølgende er
                /// blevet trimmet, hvilket er ret sansynligt vil ske. Det er en fejl i det hele taget
                /// at kopiere et autogenereret id fra én tabel og lægge det over i en anden tabel,
                /// som en nøgle i den anden tabel. Løsningen er at lave et autogenereret ID på destination
                /// tabellen, kaldet UID, sætte det felt til autogenerering og nøgle og ellers gøre som vi plejer.
                /// Bemærk at alle eksisterende data bevares og at det nye counter felt automatisk bliver udfyldt.

                cmd.CommandText = "alter table FSDDeletedSupplierItem add column UID counter not null";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "drop index idx_FSDDeletedSupplierItem on FSDDeletedSupplierItem";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "alter table FSDDeletedSupplierItem alter column ID integer";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"
                    create unique index idx_FSDDeletedSupplierItem
                    on FSDDeletedSupplierItem (UID)
                    with primary
                    ";
                cmd.ExecuteNonQuery();

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, ExeVersion);
                return false;
            }
        }
        #endregion

        #region Update to version 2.01.040
        private static bool Upd_201040()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                #region Create the new fremtidige salgspriser table

                cmd.CommandText = @"
                    create table SalesPackFuturePrices (
                    ItemID integer not null,
                    PackType integer not null,
                    ActivationDate datetime not null,
                    Origin text(5) not null,
                    SalesPrice double not null,
                    SentToStations bit,
                    ClosedDate datetime,
                    Perform bit)
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    create unique index idx_SalesPackFuturePrices
                    on SalesPackFuturePrices (ItemID, PackType, ActivationDate)
                    with primary
                    ";
                cmd.ExecuteNonQuery();

                #endregion

                #region Expand ItemUpdLines table with FutureSalesPriceDate and PackType

                cmd.CommandText = "alter table ItemUpdLines add column FutureSalesPriceDate datetime";
                cmd.ExecuteNonQuery();

                #endregion

                #region Add a couple of columns to table ExportFVDDetails

                cmd.CommandText = "alter table ExportFVDDetails add column PackType integer";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "alter table ExportFVDDetails add column FutureSalesPriceDate datetime";
                cmd.ExecuteNonQuery();

                #endregion

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, ExeVersion);
                return false;
            }
        }
        #endregion

        #region Update to version 2.01.041
        private static bool Upd_201041()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                #region Creating SafePay tables and other related stuff

                cmd.CommandText = @"
                    create table EOD_SafePay_OverfoerselTilSP (
                    BookDate datetime not null,
                    LineNo integer not null,
                    Kassenr integer,
                    Tid datetime,
                    Antal integer,
                    Beloeb float)
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    create unique index idx_EOD_SafePay_OverfoerselTilSP
                    on EOD_SafePay_OverfoerselTilSP (BookDate,LineNo)
                    with primary
                    ";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"
                    create table EOD_SafePay_Udbetalinger (
                    BookDate datetime not null,
                    LineNo integer not null,
                    Kassenr integer,
                    Tid datetime,
                    Antal integer,
                    Beloeb float,
                    Beskrivelse text(50))
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    create unique index idx_EOD_SafePay_Udbetalinger
                    on EOD_SafePay_Udbetalinger (BookDate,LineNo)
                    with primary
                    ";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"
                    create table EOD_SafePay_Indbetalinger (
                    BookDate datetime not null,
                    LineNo integer not null,
                    Kassenr integer,
                    Tid datetime,
                    Antal integer,
                    Beloeb float,
                    Beskrivelse text(50))
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    create unique index idx_EOD_SafePay_Indbetalinger
                    on EOD_SafePay_Indbetalinger (BookDate,LineNo)
                    with primary
                    ";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"
                    create table EOD_SafePay_Depotbeholdning (
                    BookDate datetime not null,
                    LineNo integer not null,
                    Enhedsnummer integer,
                    ValutaISOkode int,
                    ValutaBeloeb float,
                    DKKBeloeb float)
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    create unique index idx_EOD_SafePay_Depotbeholdning
                    on EOD_SafePay_Depotbeholdning (BookDate,LineNo)
                    with primary
                    ";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"
                    create table EOD_SafePay_Valutakurser (
                    ISOKode int not null,
                    Tekst text(10),
                    Kurs float)
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    create unique index idx_EOD_SafePay_Valutakurser
                    on EOD_SafePay_Valutakurser (ISOKode)
                    with primary
                    ";
                cmd.ExecuteNonQuery();

                cmd.CommandText = string.Format(
                    "insert into EOD_SafePay_Valutakurser (ISOKode, Tekst, Kurs) values ('{0}', '{1}', 7.45)",
                    (int)EODDataSet.EOD_SafePay_ValutakurserDataTable.ISOKode.EURO,
                    EODDataSet.EOD_SafePay_ValutakurserDataTable.ISOKode.EURO.ToString());
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(
                    "insert into EOD_SafePay_Valutakurser (ISOKode, Tekst, Kurs) values ('{0}', '{1}', 0.92)",
                    (int)EODDataSet.EOD_SafePay_ValutakurserDataTable.ISOKode.NOK,
                    EODDataSet.EOD_SafePay_ValutakurserDataTable.ISOKode.NOK.ToString());
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(
                    "insert into EOD_SafePay_Valutakurser (ISOKode, Tekst, Kurs) values ('{0}', '{1}', 0.80)",
                    (int)EODDataSet.EOD_SafePay_ValutakurserDataTable.ISOKode.SEK,
                    EODDataSet.EOD_SafePay_ValutakurserDataTable.ISOKode.SEK.ToString());
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format(
                    "insert into EOD_SafePay_Valutakurser (ISOKode, Tekst, Kurs) values ('{0}', '{1}', 1.00)",
                    (int)EODDataSet.EOD_SafePay_ValutakurserDataTable.ISOKode.DKK,
                    EODDataSet.EOD_SafePay_ValutakurserDataTable.ISOKode.DKK.ToString());
                cmd.ExecuteNonQuery();

                db.SetConfigString("SafePay.Enabled", false);
                db.SetConfigString("SafePay.ByttepengeOptalt.Daily", true);
                db.SetConfigString("SafePay.OverfoerselTilSP.ManuelIndtastning", true);
                db.SetConfigString("SafePay.Udbetalinger.ManuelIndtastning", true);
                db.SetConfigString("SafePay.Indbetalinger.ManuelIndtastning", true);

                cmd.CommandText = "alter table EODReconcile add column SafePay_OverfoerselTilSP float";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "alter table EODReconcile add column SafePay_Udbetalinger float";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "alter table EODReconcile add column SafePay_Indbetalinger float";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "alter table EODReconcile add column SafePay_ByttepengeOptalt float";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "alter table EODReconcile add column SafePay_TilfoertByttepengeFraLomis float";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "alter table EODReconcile add column SafePay_BeloebTilfoertDobbelt float";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "alter table EODReconcile add column SafePay_Depotbeholdning float";
                cmd.ExecuteNonQuery();
                #endregion

                #region Correct inactivated employees that does not have EndDates filled out
                /// for emplyees that have been inactivated and that for some reason does not
                /// have EndDate filled out, we set the enddate to the last day of the previous
                /// salary period, looking from their inactivation date.
                DataTable tmpEmp = db.GetDataTable(string.Format(@"
                    select * from PrlEmployee
                    where EmployeeNo <> {0} and EndDate is null and InactiveDate is not null
                    ", Payroll.PrlEmployeeDataTable.LentEmployeeNo));
                foreach (DataRow emp in tmpEmp.Rows)
                {
                    int empNo = tools.object2int(emp["EmployeeNo"]);
                    DateTime empInactivateDate = tools.object2datetime(emp["InactiveDate"]).Date;
                    DataRow salPeriod = Payroll.PrlSalaryPeriodsDataTable.GetSalaryPeriod(empInactivateDate);
                    if (salPeriod != null)
                    {
                        DateTime LastDayInPrevSalaryPeriod = tools.object2datetime(salPeriod["StartDate"]).AddDays(-1).Date;
                        db.ExecuteNonQuery(string.Format(@"
                            update PrlEmployee set EndDate = cdate('{1}')
                            where EmployeeNo = {0}
                            ", empNo, LastDayInPrevSalaryPeriod));
                    }
                    else
                    {
                        /// there was no active salary period so
                        /// instead we set EndDate to InactiveDate on the relevant employee
                        db.ExecuteNonQuery(string.Format(@"
                            update PrlEmployee set EndDate = InactiveDate
                            where EmployeeNo = {0}
                            ", empNo));
                    }
                }
                #endregion

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, ExeVersion);
                return false;
            }
        }
        #endregion

        #region Update to version 2.01.042
        private static bool Upd_201042()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                #region DETAIL stuff

                // in DETAIL version we want to be able to toggle Item related stuff on and off.
#if !DETAIL
                db.SetConfigString("Items.Enabled", true);
#else
                db.SetConfigString("Items.Enabled", false);
#endif

                // table Valuta DKK for DETAIL version (created for all versions)
                cmd.CommandText = @"
                    create table EOD_DETAIL_Valuta (
                    BookDate datetime not null,
                    LineNo integer not null,
                    ValutaISOkode integer,
                    Valuta text(3),
                    Valutabeloeb float,
                    BeloebDKK float)
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    create unique index idx_EOD_DETAIL_Valuta
                    on EOD_DETAIL_Valuta (BookDate,LineNo)
                    with primary
                    ";
                cmd.ExecuteNonQuery();

                // expand EOD_PayinPayout table with a time column
                cmd.CommandText = "alter table EOD_PayinPayout add column Tidspunkt_DETAIL datetime";
                cmd.ExecuteNonQuery();

                // add a boolean in config for enabling/disabling valuta popup in DETAIL EOD
                db.SetConfigString("ValutaPopup_DETAIL.Enabled", true);

                #endregion

                // add a boolean in config for toggling the entire daily section on and off
                db.SetConfigString("Daily.Enabled", true);

                # region Add a new subcategory and corresponding GLAccount record

                if (ItemDataSet.SubCategoryDataTable.GetSubCategoryRow("201010102") == null)
                {
                    db.ExecuteNonQuery(@"
                        insert into SubCategory 
                        (SubCategoryID,Description,CategoryID,VatRate,CreditCategory,AgeRestriction,
                         MOPRestriction,BudgetMargin,ItemTypeCode,HideInLookup,NotActive,GLCode,NeedsDeposit)
                        values ('201010102','Ice Shake',20101,2,3007,0,3,'50,00',1,false,false,1447,false)
                        ");
                }
                else
                {
                    db.ExecuteNonQuery(@"
                        update SubCategory set
                        Description = 'Ice Shake',
                        CategoryID = 20101,
                        VatRate = 2,
                        VatOwner = NULL,
                        CreditCategory = 3007,
                        AgeRestriction = 0,
                        MOPRestriction= 3,
                        ExternalID = NULL,
                        BudgetMargin = '50,00',
                        ItemTypeCode = 1,
                        HideInLookup = false,
                        NotActive = false,
                        GLCode = 1447,
                        NeedsDeposit = false
                        where SubCategoryID = '201010102'
                        ");
                }

                if (EODDataSet.GLAccountDataTable.GetRecord("1447") == null)
                {
                    db.ExecuteNonQuery(@"
                        insert into GLAccount (GLCode,Description,ShowLitres,ShowInReport)
                        values ('1447','Ice Shake',false,true)
                        ");
                }
                else
                {
                    db.ExecuteNonQuery(@"
                        update GLAccount set
                        Description = 'Ice Shake',
                        ShowLitres = false,
                        ShowInReport = true
                        where GLCode = '1447'
                        ");
                }

                // set config flag to enforce export of subcategories to rsm
                db.SetConfigString("ExportRSM.EnforceSubCatExport", true);

                #endregion

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, ExeVersion);
                return false;
            }
        }
        #endregion

        #region Update to version 2.01.043
        private static bool Upd_201043()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
                #region Modifying db for disktilbud

                // adding columns to Item table
                cmd.CommandText = "alter table Item add column DisktilbudFraDato datetime";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "alter table Item add column DisktilbudTilDato datetime";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "alter table Item add column DisktilbudThreshold integer";
                cmd.ExecuteNonQuery();

                // adding columns to ExportFVDDetails table
                cmd.CommandText = "alter table ExportFVDDetails add column DisktilbudFraDato datetime";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "alter table ExportFVDDetails add column DisktilbudTilDato datetime";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "alter table ExportFVDDetails add column DisktilbudThreshold integer";
                cmd.ExecuteNonQuery();

                // adding columns to ItemUpdLines table
                cmd.CommandText = "alter table ItemUpdLines add column DisktilbudFraDato datetime";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "alter table ItemUpdLines add column DisktilbudTilDato datetime";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "alter table ItemUpdLines add column DisktilbudThreshold integer";
                cmd.ExecuteNonQuery();

                // create table Cashier
                cmd.CommandText = @"
                    create table Cashier (
                    CashierID integer not null,
                    Navn text(255) )
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    create unique index idx_Cashier
                    on Cashier (CashierID)
                    with primary
                    ";
                cmd.ExecuteNonQuery();

                // create table DisktilbudSolgt
                // NOTE: do not make the DisktilbudID autogenerated,
                // as it will serve as a foreign key in DisktilbudSolgtDetaljer.
                // Instead a CreateRecord method is created for the table that
                // generates the ID.
                cmd.CommandText = @"
                    create table DisktilbudSolgt (
                    DisktilbudID integer not null,
                    TransactionID integer,
                    DatoTid datetime,
                    CashierID integer,
                    Disktilbud integer,
                    KampagneID integer,
                    BookDate datetime )
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    create unique index idx_DisktilbudSolgt
                    on DisktilbudSolgt (DisktilbudID)
                    with primary
                    ";
                cmd.ExecuteNonQuery();

                // create table DisktilbudSolgtDetailjer
                cmd.CommandText = @"
                    create table DisktilbudSolgtDetaljer (
                    DisktilbudID integer not null,
                    ItemID integer not null,
                    Antal integer )
                    ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    create unique index idx_DisktilbudSolgtDetaljer
                    on DisktilbudSolgtDetaljer (DisktilbudID,ItemID)
                    with primary
                    ";
                cmd.ExecuteNonQuery();
                
                db.SetConfigString("ExportDTV.Enabled", true);
                
                #endregion

                #region Perform stuff regarding the new VGS exporter (varegruppesalg)

                db.SetConfigString("ExportVGS.Enabled", true);
                
                // create a file for each month since 1.1.2010
                ExportVGS vgs = new ExportVGS();
                for (DateTime dt = new DateTime(2010, 1, 1); dt < tools.GetFirstDateInMonth(DateTime.Now.Date); dt = dt.AddMonths(1))
                {
                    vgs.Export(dt.Month, dt.Year);
                }
                // if today is the last day in the month and EOD is closed,
                // we need to create the VGS file, as EOD won't do it.
                if (tools.IsLastDayInMonth(DateTime.Now.Date) && EODDataSet.EODReconcileDataTable.IsDayClosed(DateTime.Now.Date))
                    vgs.Export(DateTime.Now.Month, DateTime.Now.Year);

                #endregion

                // add a config value that holds a threshold value for
                // the minimum customer count needed when approving EOD
                db.SetConfigString("EOD.CustomerCountThreshold", 10);

                // Add a field to EODReconcileEx that holds the original CustomerCount
                // values that was retrieved from the PEJ file when RSM files were imported
                cmd.CommandText = "alter table EODReconcileEx add column CustomerCountOriginalFromPOS integer";
                cmd.ExecuteNonQuery();

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, ExeVersion);
                return false;
            }
        }
        #endregion

        #region Update to version 2.01.044
        private static bool Upd_201044()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            cmd.Transaction = db.StartTransaction();
            try
            {
#if !RBA && !FSD
                // correct an error where no DTV files where exported since
                // 21.3.2011 when a specific condition were met. The files
                // are generated up to the day before the updater runs.
                ExportDTV dtv = new ExportDTV();
                for (DateTime dt = new DateTime(2011, 3, 21); dt < DateTime.Now.Date; dt = dt.AddDays(1))
                {
                    dtv.Export(dt, true);
                }
#endif

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, cmd.CommandText, ExeVersion);
                return false;
            }
        }
        #endregion

        #region Update to version 2.01.045
        private static bool Upd_201045()
        {
            try
            {
                // NOTE: update code has been removed as it was incompatible
                // with changes introduced in v47 and installations updating
                // from v44-v45 would fail in the upgrade process.

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                HandleErrorMessages(ex, "Upd_201045()", ExeVersion);
                return false;
            }
        }
        #endregion

        #region Update to version 2.01.046
        private static bool Upd_201046()
        {
            try
            {
                // NOTE: most update code has been removed as it was incompatible
                // with changes introduced in v47 and installations updating
                // from v45-46 would fail in the upgrade process.

                // some config value needed
                db.SetConfigString("ImportRSM.ImportPEJFiles.CopyToDepart", false);

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                HandleErrorMessages(ex, "Upd_201046()", ExeVersion);
                return false;
            }
        }
        #endregion

        #region Update to version 2.01.047
        private static bool Upd_201047()
        {
            string sql = "";
            db.StartTransaction();

            try
            {
                /// create the DisktilbudHistorik table,
                /// used for saving every disktilbud that
                /// comes from BFI via the FVD file.
                sql = @"
                    create table DisktilbudHistorik (
                    ID counter not null,
                    ItemID integer not null,
                    FSD_ID integer not null,
                    FraDato datetime not null,
                    TilDato datetime not null,
                    Threshold integer not null,
                    KampagneID integer not null,
                    DatoTid datetime
                    )";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.ExecuteNonQuery();
                }
                sql = @"
                    create unique index idx_DisktilbudHistorik
                    on DisktilbudHistorik (ID)
                    with primary
                    ";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.ExecuteNonQuery();
                }

#if !RBA && !FSD
                /// to make the history complete, we run through all the
                /// existing valid disktilbud and add them to the history table.
                /// note that the date 11. may 2011 is the earliest disktilbud date we support,
                /// as before that we cannot guarantee the integrity of the data.
                sql = @"
                    insert into DisktilbudHistorik (ItemID, FSD_ID, FraDato, TilDato, Threshold, KampagneID, DatoTid)
                    select ItemID, FSD_ID, DisktilbudFraDato, DisktilbudTilDato, DisktilbudThreshold, KampagneID, Now
                    from Item
                    where FSD_ID is not null
                    and DisktilbudFraDato is not null
                    and DisktilbudTilDato is not null
                    and DisktilbudThreshold is not null
                    and KampagneID is not null
                    and DisktilbudFraDato >= ?
                    and DisktilbudTilDato >= ?
                    ";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.Parameters.Add("DisktilbudFraDato", OleDbType.Date).Value = new DateTime(2011, 5, 11);
                    cmd.Parameters.Add("DisktilbudTilDato", OleDbType.Date).Value = new DateTime(2011, 5, 11);
                    cmd.ExecuteNonQuery();
                }
#endif

                // the following lines were added after we released v47 for DO and FSD,
                // but the changes only affects the DETAIL version, so it's ok.
                db.SetConfigString("EOD.Payout.DETAIL.UnlockFields", false);
                db.SetConfigString("EOD.Payin.DETAIL.UnlockFields", false);

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, sql, ExeVersion);
                return false;
            }
        }
        #endregion

        #region Update to version 2.01.048
        private static bool Upd_201048()
        {
            string sql = "";
            db.StartTransaction();

            try
            {
                #region add some DETAIL columns to EODReconcile table

                sql = "alter table EODReconcile add column MoentDaglig float";                
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.ExecuteNonQuery();
                }

                sql = "alter table EODReconcile add column MoentBank float";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.ExecuteNonQuery();
                } 

                #endregion

                #region create new table PEJSalesSummary

                /// This table will hold summary data about the
                /// sales (bon'er) from each day for each cashier.

                sql = @"
                    create table CashierSales (
                    BookDate datetime,
                    CashierID integer,
                    AntalKunder integer,
                    SalgTotalBeloeb float,
                    DisktilbudTotalBeloeb float
                    )";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.ExecuteNonQuery();
                }

                sql = @"
                    create unique index idx_CashierSales
                    on CashierSales (BookDate, CashierID)
                    with primary
                    ";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.ExecuteNonQuery();
                }

                #endregion

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, sql, ExeVersion);
                return false;
            }
        }
        #endregion

        #region Update to version 2.01.050
        private static bool Upd_201050()
        {
            string sql = "";
            db.StartTransaction();

            try
            {
                #region Create 3 new Columns in SiteInformation Table
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.CommandText = "alter table SiteInformation add column EconomicsAftaleID integer";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "alter table SiteInformation add column EconomicsUserID text(50)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "alter table SiteInformation add column EconomicsUserPassword text(50)";
                    cmd.ExecuteNonQuery();
                }
                #endregion

                #region Economics config value
                db.SetConfigString("Economics.Enabled", "false");
                #endregion

                #region Create stock count related tables

                // StockCountRegistrationRBA

                sql = @"
                    create table StockCountRegistrationRBA (
                    ID counter not null,
                    LevNr integer,
                    Varenummer float,
                    Varenavn text(255),
                    KostprisExMoms float,
                    Barcode float,
                    Varegruppe text(20),
                    Antal integer,
                    Ialt float )
                    ";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.ExecuteNonQuery();
                }
                sql = @"
                    create unique index idx_StockCountRegistrationRBA
                    on StockCountRegistrationRBA (ID)
                    with primary
                    ";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.ExecuteNonQuery();
                }

                // ItemTransactionStockCountRBA table

                db.SetConfigString("ItemTransactionStockCountRBA_ID", 0);

                /// This table is used for RBA to register stock count (optællinger).

                /// Varenavn is redundatly put in here on purpose,
                /// as we cannot guarantee that the corresponding item
                /// in AfskrProd still exists when user prints out the
                /// transactions, hence the item name would not be possible
                /// to look up.

                sql = @"
                    create table ItemTransactionStockCountRBA (
                    TransactionNumber integer not null,
                    UltimoDate datetime,
                    LevNr integer,
                    Varenummer float,
                    Varenavn text(255),
                    Varegruppe text(20),
                    NumberOf integer,
                    Amount float,
                    Initials text(10) )";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.ExecuteNonQuery();
                }

                sql = @"
                    create unique index idx_ItemTransactionStockCountRBA
                    on ItemTransactionStockCountRBA (TransactionNumber)
                    with primary ";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.ExecuteNonQuery();
                }

                #endregion

                #region Create Forbrugsvarer related tables

                // Forbrugsvare table
                sql = @"
                    create table Forbrugsvare (
                    LevNr integer not null,
                    Varenummer float not null,
                    Beskrivelse text(255),
                    Kostpris float,
                    Salgspris float,
                    Varegruppe text(20),
                    Barcode float,
                    GenerelVare bit,
                    LevKategori text(30),
                    Inactive bit) 
                    ";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.ExecuteNonQuery();
                }

                // Forbrugsvare table index
                sql = @"
                    create unique index idx_Forbrugsvare
                    on Forbrugsvare (LevNr,Varenummer)
                    with primary
                    ";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.ExecuteNonQuery();
                }

                // ForbrugsvareRegistrering table
                sql = @"
                    create table ForbrugsvareRegistrering (
                    ID counter not null,
                    LevNr integer,
                    Varenummer double,
                    Varenavn text(255),
                    Salgspris float,
                    Barcode float,
                    Kostpris float,
                    Varegruppe text(20),
                    Antal integer)
                    ";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.ExecuteNonQuery();
                }

                // ForbrugsvareRegistrering index
                sql = @"
                    create unique index idx_ForbrugsvareRegistrering
                    on ForbrugsvareRegistrering (ID)
                    with primary
                    ";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.ExecuteNonQuery();
                }

                // ItemTransactionForbrugsvare table
                sql = @"
                    create table ItemTransactionForbrugsvare (
                    TransactionNumber integer not null,
                    PostingDate datetime,
                    LevNr integer,
                    Varenummer float,
                    Varenavn text(255),
                    NumberOf integer,
                    Amount float,
                    Initials text(10) )";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.ExecuteNonQuery();
                }

                // ItemTransactionForbrugsvare index
                sql = @"
                    create unique index idx_ItemTransactionForbrugsvare
                    on ItemTransactionForbrugsvare (TransactionNumber)
                    with primary ";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.ExecuteNonQuery();
                }

                #endregion

                #region Creating the UpdatesApplied table as preparation for the new v3 upgrade system
                
                /// Creating UpdatesApplied table. This constitute the
                /// new v3 patch system where we know what patch code has
                /// been applied and what haven't.
                /// 
                /// The reason it is created here in v2 is that we are releasing a v3 version very soon
                /// and when that happens we will have to implement v2 upgrade code parallel with v3 upgrade code,
                /// so in v2 we will need to be able to mark upgrade code as already applied so that v3
                /// does not attempt to re-apply it when that database is migrated.

                sql = @"
                        create table UpdatesApplied (
                        VersionNo text(10) not null,
                        PatchNo integer not null )
                        ";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.ExecuteNonQuery();
                }

                sql = @"
                        create unique index idx_UpdatesApplied
                        on UpdatesApplied (VersionNo, PatchNo)
                        with primary
                    ";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.ExecuteNonQuery();
                }

                #endregion

                /// Any database code implemented both in v2 and in v3
                /// must be marked as already done, so it won't
                /// attempt to run again when migrating to v3.
                //SkipInV3("3.01.001", 2, db.Connection, db.CurrentTransaction);

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, sql, ExeVersion);
                return false;
            }
        }
        #endregion

        #region Update to version 2.01.051
        private static bool Upd_201051()
        {
            string sql = "";
            db.StartTransaction();

            try
            {
                #region Nød-håndtering af fejl i brændstof rabatter

                db.SetConfigString("COPY_RSM_TO_DRS", true);
                db.SetConfigString("COPY_PEJ_TO_DRS", false);

                // lav en liste af MSM filer i C:\DRS\NAXML\NAXMLExport\Backup
                List<string> msmFiles = new List<string>(Directory.GetFiles(db.GetConfigString("NAXML_Import_Dir_Backup"), "MSM*.xml"));

                // hvis der ikke er nogen filer backup folderen, dannes en fil til DRS
                if (msmFiles.Count <= 0)
                {
                    string statusfile = db.GetConfigString("DRS_FTP_client_depart_dir") + "\\MSM_Missing.txt";
                    statusfile = statusfile.Replace("\\\\", "\\");
                    if (File.Exists(statusfile))
                    {
                        tools.RemoveFileWriteProtection(statusfile);
                        File.Delete(statusfile);
                    }
                    File.WriteAllText(statusfile, "Ingen MSM filer i backup folder");
                }

                // tilføj MSM filer fra C:\DRS\NAXML\NAXMLExport
                msmFiles.AddRange(Directory.GetFiles(db.GetConfigString("NAXML_Import_Dir"), "MSM*.xml"));
                
                // loop igennem de fundne filer
                foreach (string file in msmFiles)
                {
                    // lav dato
                    string filename = tools.StripDirectoryFromPath(file);
                    int year = tools.object2int(filename.Substring(3, 4));
                    int month = tools.object2int(filename.Substring(7, 2));
                    int day = tools.object2int(filename.Substring(9, 2));
                    DateTime date = new DateTime(year, month, day);

                    // hvis datoen er større end 19.06.2012, skal filen kopieres til depart
                    if (date > new DateTime(2012, 6, 19))
                        tools.FuelDiscountFix_CopyMSM2DRS(file);
                }

                // vær sikker på at backup flaget er sat
                db.SetConfigString("NAXML_Export_Backup_Active", true);

                #endregion

                /// Any database code implemented both in v2 and in v3
                /// must be marked as already done, so it won't
                /// attempt to run again when migrating to v3.
                //SkipInV3("3.01.001", 2, db.Connection, db.CurrentTransaction);

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, sql, ExeVersion);
                return false;
            }
        }
        #endregion

        #region Update to version 2.01.052
        private static bool Upd_201052()
        {
            string sql = "";
            db.StartTransaction();

            try
            {
                using (OleDbCommand cmd = new OleDbCommand("", db.Connection, db.CurrentTransaction))
                {
                    // Udvid kolonnen Modifier til 16 karakterer i tabellen Import_RPOS_MSM_Details
                    cmd.CommandText = "alter table Import_RPOS_MSM_Details alter column Modifier text(16)";
                    cmd.ExecuteNonQuery();
                
                    // udvid kolonnen Modifier til 16 karakterer i tabellen Import_RPOS_MSM_Config
                    cmd.CommandText = "alter table Import_RPOS_MSM_Config alter column Modifier text(16)";
                    cmd.ExecuteNonQuery();

                    // tilføj kolonne DiscountAmount til tabellen EODReconcile
                    cmd.CommandText = "alter table EODReconcile add column DiscountAmount double";
                    cmd.ExecuteNonQuery();
                }

                using (OleDbCommand cmd = new OleDbCommand("", db.Connection, db.CurrentTransaction))
                {
                    // opdater tabellen Import_RPOS_MSM_Config så den indeholder DISCNT koden
                    cmd.CommandText = @"
                        insert into Import_RPOS_MSM_Config
                          (SummaryCode,SubCode,Modifier,Description,ModifierDesc,IncludeInImport,IncludeCode)
                          values (?,?,?,?,?,?,?)
                        ";
                    cmd.Parameters.Add("SummaryCode", OleDbType.Integer).Value = 7;
                    cmd.Parameters.Add("SubCode", OleDbType.Integer).Value = 2;
                    cmd.Parameters.Add("Modifier", OleDbType.VarChar).Value = "5000000645";
                    cmd.Parameters.Add("Description", OleDbType.VarChar).Value = "Discount";
                    cmd.Parameters.Add("ModifierDesc", OleDbType.VarChar).Value = "Brændstofsrabat";
                    cmd.Parameters.Add("IncludeInImport", OleDbType.Boolean).Value = true;
                    cmd.Parameters.Add("IncludeCode", OleDbType.VarChar).Value = "DISCNT";
                    cmd.ExecuteNonQuery();
                }

                using (OleDbCommand cmd = new OleDbCommand("", db.Connection, db.CurrentTransaction))
                {
                    // opret en ny tabel til at indeholde brændstofsrabatterne, der importeres fra Import_RPOS_MSM_Details
                    cmd.CommandText = @"
                        create table EOD_Discounts (
                            BookDate datetime not null,
                            LineNo integer not null,
                            MOPCode text(30),
                            Description text(25),
                            Amount double)
                        ";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"
                        create unique index idx_EOD_Discounts
                        on EOD_Discounts (BookDate,LineNo)
                        with primary
                        ";
                    cmd.ExecuteNonQuery();
                }

                // ryd op i DisktilbudHistorik tabellen, så der ikke ligger inkomplette data
                using (OleDbCommand cmd = new OleDbCommand("", db.Connection, db.CurrentTransaction))
                {
                    cmd.CommandText = @"
                        delete from DisktilbudHistorik
                        where FraDato is null
                        or TilDato is null
                        or Threshold is null or Threshold <= 0
                        or KampagneID is null or KampagneID <= 0
                        ";
                    cmd.ExecuteNonQuery();
                }

                /// Any database code implemented both in v2 and in v3
                /// must be marked as already done, so it won't
                /// attempt to run again when migrating to v3.
                //SkipInV3("3.01.001", 2, db.Connection, db.CurrentTransaction);

                // save data to disk
                db.CommitTransaction();

                // genberegn disktilbud (uden at melde til bruger om der er sket en fejl)
                // OBS: Skal køre efter commit af transaktionen, da den selv har en transaktion
                ImportRSM importer = new ImportRSM();
                bool ErrorsInDisktilbud;
                DateTime FraDato = new DateTime(2012, 8, 1);
                DateTime TilDato = DateTime.Now;
                importer.ReImportPEJFilesFromBackup(FraDato.Date, TilDato.Date, out ErrorsInDisktilbud);

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, sql, ExeVersion);
                return false;
            }
        }
        #endregion

        #region Update to version 2.01.053
        private static bool Upd_201053()
        {
            string sql = "";
            db.StartTransaction();

            try
            {
                using (OleDbCommand cmd = new OleDbCommand("", db.Connection, db.CurrentTransaction))
                {
                    // erstat 'Sol center' tekst med 'GLS'
                    cmd.CommandText = "update SubCategory set Description = 'GLS' where SubCategoryID = '201110801'";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "update GLAccount set Description = 'GLS' where GLCode = '1351'";
                    cmd.ExecuteNonQuery();
                }

                /// NOTE: vi kalder ikke længere SkipInV3. vi har opgivet at
                /// beholde den samme kodebase for DO/RBA, især også nu fordi
                /// vi kører to forskellige databaser.

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, sql, ExeVersion);
                return false;
            }
        }
        #endregion

        #region Update to version 2.01.055
        private static bool Upd_201055()
        {
#if !RBA && !FSD && !DETAIL
            string sql = "";
            db.StartTransaction();

            try
            {
                using (OleDbCommand cmd = new OleDbCommand("", db.Connection, db.CurrentTransaction))
                {
                    // Ny FTP Account indsættes
                    cmd.CommandText = "Insert into FTPAccounts (AccountName,ClientDepartureDir,ClientArrivalDir,Host,Port,UserName,Passwd,TransferType,ServerArrivalDir)" +
                                      "Values ('Supergros Shell BFI account','c:\\DRS\\depart','c:\\DRS\\arrive','Ftphub.supergros.dk','21','SHELLBFIPROD','2AsiYem1','ascii','\\PROD\\SHELLBFIPROD\\D1101-FROM-SHELLBFI')";
                    cmd.ExecuteNonQuery();

                    //Finder nummer på den FTP account der lige er blevet oprettet
                    String FTPAccID;
                    cmd.CommandText = "Select ID From FTPAccounts where FTPAccounts.AccountName = 'Supergros Shell BFI account'";
                    FTPAccID = Convert.ToString(cmd.ExecuteScalar());

                    //Opdaterer Supplier Supergros med nyt FTP Account og omdøber samtidig
                    cmd.CommandText = "Update Supplier Set FTPAccountID = ?, Description = 'Supergros' Where Supplier.SupplierID = 4";
                    cmd.Parameters.Add("FTPAccNo", SqlDbType.NVarChar).Value = FTPAccID;
                    cmd.ExecuteNonQuery();
                }

                // save data to disk
                db.CommitTransaction();

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, sql, ExeVersion);
                return false;
            }
#endif
            return true;
        }
         #endregion

        #region Update to version 2.01.056
        private static bool Upd_201056()
        {

            string sql = "";
            db.StartTransaction();

            try
            {
                using (OleDbCommand cmd = new OleDbCommand("", db.Connection, db.CurrentTransaction))
                {
                    // opdater tabellen Import_RPOS_MSM_Config så den indeholder SPCUR koden
                    cmd.CommandText = @"
                            insert into Import_RPOS_MSM_Config
                              (SummaryCode,SubCode,Modifier,Description,ModifierDesc,IncludeInImport,IncludeCode)
                            values (?,?,?,?,?,?,?)
                            ";
                    cmd.Parameters.Add("SummaryCode", OleDbType.Integer).Value = 7;
                    cmd.Parameters.Add("SubCode", OleDbType.Integer).Value = 16;
                    cmd.Parameters.Add("Modifier", OleDbType.VarChar).Value = "2";
                    cmd.Parameters.Add("Description", OleDbType.VarChar).Value = "Safepay";
                    cmd.Parameters.Add("ModifierDesc", OleDbType.VarChar).Value = "Safepay Valuta";
                    cmd.Parameters.Add("IncludeInImport", OleDbType.Boolean).Value = true;
                    cmd.Parameters.Add("IncludeCode", OleDbType.VarChar).Value = "SPCUR";
                    cmd.ExecuteNonQuery();
                }
                using (OleDbCommand cmd = new OleDbCommand("", db.Connection, db.CurrentTransaction))
                {
                    // opdater tabellen Import_RPOS_MSM_Config så den indeholder SPDEPOT koden
                    cmd.CommandText = @"
                            insert into Import_RPOS_MSM_Config
                              (SummaryCode,SubCode,Modifier,Description,ModifierDesc,IncludeInImport,IncludeCode)
                            values (?,?,?,?,?,?,?)
                            ";
                    cmd.Parameters.Add("SummaryCode", OleDbType.Integer).Value = 19;
                    cmd.Parameters.Add("SubCode", OleDbType.Integer).Value = 4;
                    cmd.Parameters.Add("Modifier", OleDbType.VarChar).Value = "1";
                    cmd.Parameters.Add("Description", OleDbType.VarChar).Value = "Safepay";
                    cmd.Parameters.Add("ModifierDesc", OleDbType.VarChar).Value = "Safepay Depot";
                    cmd.Parameters.Add("IncludeInImport", OleDbType.Boolean).Value = true;
                    cmd.Parameters.Add("IncludeCode", OleDbType.VarChar).Value = "SPDEP";
                    cmd.ExecuteNonQuery();
                }
                // opret en ny tabel til at indeholde SafePay valuta poster
                using (OleDbCommand cmd = new OleDbCommand("", db.Connection, db.CurrentTransaction))
                {
                    cmd.CommandText = @"
                        create table EOD_SafePay_Currencies (
                            BookDate datetime not null,
                            LineNo integer not null,
                            MOPCode text(30),
                            Description text(25),
                            Amount double)
                        ";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"
                        create unique index idx_EOD_SafePay_Currencies
                        on EOD_SafePay_Currencies (BookDate,LineNo)
                        with primary
                        ";
                    cmd.ExecuteNonQuery();

                }
                //4 nye felter på tabel EOD Reconcile 

                using (OleDbCommand cmd = new OleDbCommand("", db.Connection, db.CurrentTransaction))
                {
                    cmd.CommandText = " ALTER TABLE EODReconcile ADD COLUMN SafePayAmount Double ";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = " ALTER TABLE EODReconcile ADD COLUMN SafePayAmountCurr Double  ";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = " ALTER TABLE EODReconcile ADD COLUMN TotalSafePay Double  ";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = " ALTER TABLE EODReconcile ADD COLUMN ManBankDep Double  ";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = " ALTER TABLE EODReconcile ADD COLUMN OPTPrepayAmount Double  ";
                    cmd.ExecuteNonQuery();
                }

                // opret en ny tabel til at indeholde NY ACNHistorik
                using (OleDbCommand cmd = new OleDbCommand("", db.Connection, db.CurrentTransaction))
                {
                    
                    cmd.CommandText = @"
                        create table ACNExportHistory_New (
                            AYear Long not null,
                            AWeek Long not null,
                            Status Long,
                            SystemDate datetime)
                        ";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"
                        create unique index idx_ACNExportHistory_New
                        on ACNExportHistory_New (AYear,AWeek)
                        with primary
                        ";
                    cmd.ExecuteNonQuery();
                }
                //2 nye config values 
                db.SetConfigString("ACN_Old_Enabled", true);
                db.SetConfigString("ACN_New_Enabled", true);
                db.CommitTransaction();
                return true;
            }


            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, sql, ExeVersion);
                return false;
            }

        }    
    #endregion

        #region Update to version 2.01.058
        private static bool Upd_201058()
        {

            string sql = "";
            db.StartTransaction();

            try
            {
                
                
                //1 nyt felt på tabel Item  

                using (OleDbCommand cmd = new OleDbCommand("", db.Connection, db.CurrentTransaction))
                {
                    cmd.CommandText = " ALTER TABLE Item ADD COLUMN ItemTypeSubCode Integer ";
                    cmd.ExecuteNonQuery();                    
                }

                db.SetConfigString("eGruppe.Active", "false");
                db.SetConfigString("eGruppe.CompID", "");
                db.SetConfigString("eGruppe.PassWord", "Vinter2014");
                db.SetConfigString("eGruppe.TimeRegURL", "https://secure.egruppe.net/sync/getRegistrations.php?id={0}&from={1}&to={2}&departmentCode={3}&locked=1");
                db.SetConfigString("eGruppe.UserID", "admin");
                db.SetConfigString("eGruppe.AbsenseRegURL", "https://secure.egruppe.net/sync/getAbsence.php?id={0}&from={1}&to={2}&departmentCode={3}&getAllApproved=1");
                db.CommitTransaction();
                return true;
            }


            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, sql, ExeVersion);
                return false;
            }

        }
        #endregion

        #region Update to version 2.01.059
        private static bool Upd_201059()
        {
            string sql = "";
            db.StartTransaction();

            try
            {                                         
                using (OleDbCommand cmd = new OleDbCommand("", db.Connection, db.CurrentTransaction))
                {
                    // opret en ny tabel til at indeholde Danske Spil info 
                    cmd.CommandText = @"
                        CREATE TABLE Danske_Spil(
	                        BookDate datetime not null,
	                        OnlineSalesTerminal double null,
	                        OnlineSalesDesk double null,
	                        DiffOnlineSales double null,
	                        OnlinePayoutTerminal double null,
	                        OnlinePayoutDesk double null,
	                        OnlinePayoutDiff double null,
	                        QuickTerminal double null,
	                        QuickDesk double null,
	                        QuickDiff double null,
	                        MixQuickPayout double null)                       	                                                                    
                        ";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"
                        create unique index idx_Danske_Spil
                        on Danske_Spil (BookDate)
                        with primary
                        ";
                    cmd.ExecuteNonQuery();
                    
                }
              
                
                db.CommitTransaction();

                

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, sql, ExeVersion);
                return false;
            }
        }
        #endregion

        #region Update to version 2.01.060
        private static bool Upd_201060()
        {
            string sql = "";
            db.StartTransaction();

            try
            {                                   
                db.SetConfigString("DanskeSpil.Enabled", "false");
                db.CommitTransaction();
                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, sql, ExeVersion);
                return false;
            }
        }
        #endregion

        #region Update to version 2.01.062
        private static bool Upd_201062()
        {
            string sql = "";
            db.StartTransaction();

            try
            {
                using (OleDbCommand cmd = new OleDbCommand("", db.Connection, db.CurrentTransaction))
                {
                    // opret en ny tabel til at indeholde Danske Spil info 
                    cmd.CommandText = @"
                        CREATE TABLE Danske_Spil(
	                        BookDate datetime not null,
	                        OnlineSalesTerminal double null,
	                        OnlineSalesDesk double null,
	                        DiffOnlineSales double null,
	                        OnlinePayoutTerminal double null,
	                        OnlinePayoutDesk double null,
	                        OnlinePayoutDiff double null,
	                        QuickTerminal double null,
	                        QuickDesk double null,
	                        QuickDiff double null,
	                        MixQuickPayout double null)                       	                                                                    
                        ";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"
                        create unique index idx_Danske_Spil
                        on Danske_Spil (BookDate)
                        with primary
                        ";
                    cmd.ExecuteNonQuery();
                    db.SetConfigString("DanskeSpil.Enabled", true);

                }
                db.CommitTransaction();
                                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                db.StartTransaction();
                db.SetConfigString("DanskeSpil.Enabled", true);
                db.CommitTransaction();

               // HandleErrorMessages(ex, sql, ExeVersion);
                return true;
            }            
        }
        #endregion

        #region Update to version 2.01.063
        private static bool Upd_201063()
        {
            try
            {
               
                //backup folder igennem for et dato interval find ism filer og kopier til depart
                ImportRSM importer = new ImportRSM();
                DateTime FromDate = new DateTime(2014, 6, 21);
                DateTime ToDate = new DateTime(2014, 7, 23);
                importer.GetISMFilesFromBackup(FromDate,ToDate);
                
                // some config value needed
                db.SetConfigString("ImportRSM.ImportISMFiles.CopyToDepart", false);
                db.SetConfigString("LabelReport.Topmargin", 0);

                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                HandleErrorMessages(ex, "Upd_201063()", ExeVersion);
                return false;
            }
        }
        #endregion

        #region Update to version 2.01.064
        private static bool Upd_201064()
        {
            try
            {   // some config value needed
                db.SetConfigString("StocCountFiles.Enabled", true);
                db.SetConfigString("ModifyCustomerCount.Enabled", true);
                return true;
            }
            catch (Exception ex)
            {
                HandleErrorMessages(ex, "Upd_201064()", ExeVersion);
                return false;
            }
        }
        #endregion

        #region Update to version 2.01.065
        private static bool Upd_201065()
        {
                        
            db.StartTransaction();

            try
            {                                                         
                //4 nye felter på tabel EOD Reconcile 
                using (OleDbCommand cmd = new OleDbCommand("", db.Connection, db.CurrentTransaction))
                {
                    cmd.CommandText = @"alter table EODReconcile add column TmpAmt1 double null";                    
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"alter table EODReconcile add column TmpAmt2 double null";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"alter table EODReconcile add column TmpAmt3 double null";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"alter table EODReconcile add column TmpAmt4 double null";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"alter table EODReconcile add column TmpAmtTotal double null";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"alter table EODReconcile add column TmpAmt1Descr text(25)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"alter table EODReconcile add column TmpAmt2Descr text(25)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"alter table EODReconcile add column TmpAmt3Descr text(25)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"alter table EODReconcile add column TmpAmt4Descr text(25)";
                    cmd.ExecuteNonQuery();
                
                }
                db.CommitTransaction();
                //2 nye config values 
                db.SetConfigString("TMPAmt1Ledetekst","Deals" );
                db.SetConfigString("TMPAmt2Ledetekst", "Smartbox");        
                return true;
            }

            catch (Exception ex)
            {
                db.RollbackTransaction();
                HandleErrorMessages(ex, "Upd_201065()", ExeVersion);
                return false;
            }
        }
        #endregion            

        #region Update to version 2.01.066
        private static bool Upd_201066()
        {            
            db.StartTransaction();

            try
            {
                using (OleDbCommand cmd = new OleDbCommand("", db.Connection, db.CurrentTransaction))
                {
                    // Ny tabel til at info vedr. bankcards, bankdep og dynamiske felter 
                    cmd.CommandText = @"
                        CREATE TABLE AddInfo(
	                        BookDate datetime not null,
	                        Type String not null,
                            SubType String not null,
                            Description text(25),
                            Amount double null)                                                                 	                                                                    
                        ";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"
                        create unique index idx_AddInfo
                        on AddInfo (BookDate,Type,SubType)
                        with primary
                        ";
                    cmd.ExecuteNonQuery();
                   

                }
                db.CommitTransaction();
                db.SetConfigString("EOD.BankCards.DETAIL.UnlockFields", true);
                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                

                // HandleErrorMessages(ex, sql, ExeVersion);
                return true;
            }
        }
        #endregion

        #region Update to version 2.01.067
        private static bool Upd_201067()
        {           

            try
            {
               
                // update completed successfully
                return true;
            }
            catch (Exception ex)
            {                
                HandleErrorMessages(ex, "Upd_201067()", ExeVersion);
                return true;
            }
        }
        #endregion

        #region Update to version 2.01.068
        private static bool Upd_201068()
        {

            try
            {
                
                // update completed successfully
                #if DETAIL
                db.SetConfigString("EOD.Payout.DETAIL.InputMask", "M:,m:D:,d:,F:,f:,A:,a:");
                #endif
                return true;
            }
            catch (Exception ex)
            {
                HandleErrorMessages(ex, "Upd_201068()", ExeVersion);
                return true;
            }
        }
        #endregion
        #region Update to version 2.01.069
        private static bool Upd_201069()
        {

            try
            {

                // update completed successfully
                #if !RBA && !FSD && !DETAIL

                using (OleDbCommand cmd = new OleDbCommand("", db.Connection, db.CurrentTransaction))
                {
                    //indsæt Subcategory record
                    cmd.CommandText = @"
                            insert into SubCategory 
                              (SubCategoryID,Description,CategoryID,VatRate,CreditCategory,ItemTypeCode,HideInLookup,NotActive,GLCode)
                            values (?,?,?,?,?,?,?,?,?)
                            ";
                    cmd.Parameters.Add("SubCategoryID", OleDbType.VarChar).Value = "102010401";
                    cmd.Parameters.Add("Description", OleDbType.VarChar).Value = "V-Power Diesel";
                    cmd.Parameters.Add("CategoryID", OleDbType.Integer).Value = 10201;
                    cmd.Parameters.Add("VatRate", OleDbType.Integer).Value = 2;
                    cmd.Parameters.Add("CreditCategory", OleDbType.VarChar).Value = "0200";
                    cmd.Parameters.Add("ItemTypeCode", OleDbType.Integer).Value = 1;
                    cmd.Parameters.Add("HideInLookup", OleDbType.Boolean).Value = true;
                    cmd.Parameters.Add("NotActive", OleDbType.Boolean).Value = false;
                    cmd.Parameters.Add("GLCode", OleDbType.VarChar).Value = "1014";
                    cmd.ExecuteNonQuery();
                }
//                using (OleDbCommand cmd = new OleDbCommand("", db.Connection, db.CurrentTransaction))
//                {
//                    //indsæt  LookupCreditCategory record
//                    cmd.CommandText = @"
//                            insert into LookupCreditCategory 
//                              (CredCat,[Code XX],DescriptionUK,DescriptionLocal)
//                            values (?,?,?,?)
//                            ";
//                    cmd.Parameters.Add("CredCat", OleDbType.VarChar).Value = "0206";
//                    cmd.Parameters.Add("[Code XX]", OleDbType.VarChar).Value = "033";
//                    cmd.Parameters.Add("DescriptionUK", OleDbType.VarChar).Value = "V-Power Diesel";
//                    cmd.Parameters.Add("DescriptionLocal", OleDbType.VarChar).Value = "V-Power Diesel";
//                    cmd.ExecuteNonQuery();
//                }
                 using (OleDbCommand cmd = new OleDbCommand("", db.Connection, db.CurrentTransaction))
                 {
                    //indsæt GLAccount record
                     cmd.CommandText = @"
                            insert into GLAccount 
                              (GLCode,Description,ShowLitres,ShowInReport)
                            values (?,?,?,?)
                            ";
                     cmd.Parameters.Add("GLCode", OleDbType.VarChar).Value = "1014";
                     cmd.Parameters.Add("Description", OleDbType.VarChar).Value = "V-Power Diesel";
                     cmd.Parameters.Add("ShowLitres", OleDbType.Boolean).Value = true;
                     cmd.Parameters.Add("ShowInReport", OleDbType.Boolean).Value = true;

                     cmd.ExecuteNonQuery();
                }
                

               
                
             #endif
                return true;
            }
            catch (Exception ex)
            {
                HandleErrorMessages(ex, "Upd_201069()", ExeVersion);
                return true;
            }
        }
        #endregion
        #region Update to version 2.01.070
        private static bool Upd_201070()
        {
            try
            {   // some config value needed
                db.SetConfigString("ModifyCustomerCount.Enabled", false);           
                db.SetConfigString("TokenLocal", "");
                db.SetConfigString("TokenDRS", "vp0qkIyMQqYxDKDV8M8RBdABPRjfOCRfBBZbl96HKaE1");
                return true;
            }
            catch (Exception ex)
            {
                HandleErrorMessages(ex, "Upd_201070()", ExeVersion);
                return false;
            }
        }
        #endregion
        #region Update to version 2.01.071
        private static bool Upd_201071()
        {

            try
            {

                // update completed successfully
                //
                //4 nye felter på tabel EOD Reconcile 
                using (OleDbCommand cmd = new OleDbCommand("", db.Connection, db.CurrentTransaction))
                {
                    cmd.CommandText = @"alter table EOD_SafePay_Depotbeholdning add ChangeDKK double null";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"alter table EOD_SafePay_Depotbeholdning add ChangeValuta double null";
                    cmd.ExecuteNonQuery();
                    

                }
                db.CommitTransaction();

                return true;
            }
            catch (Exception ex)
            {
                HandleErrorMessages(ex, "Upd_201071()", ExeVersion);
                return true;
            }
        }
        #endregion
    }
}

