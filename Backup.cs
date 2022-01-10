using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;

namespace RBOS
{
    class Backup
    {
        /// Multithreading notice:
        /// When programming in this class, always have in mind, that
        /// it is multithreaded, so variables must be access with this in mind.
        /// However, the RunBackup method checks if another thread is already
        /// running, so after that it should be safe to access variables.
        /// The only variable that should need to be synchronized with a mutex
        /// is the BackupRunning property. In RunBackup we must be careful
        /// not to access non-synchronized variables from multiple threads.

        #region Private variables

        // mutex used when setting/getting BackupRunning
        private static Mutex mutex = new Mutex();

        // flag to invoke backups that are include
        // in autoback functionality
        private static bool autobackup = false;

        // the path to the working copy of the database.
        // is only set by GetDBSourcePath
        private static string workingcopy = "";

        #endregion

        #region DestinationDirectory (public enum)
        private enum DestinationDirectory
        {
            Local,
            Network,
            External
        }
        #endregion

        #region BackupRunning (public property)
        private static bool _BackupRunning = false;
        /// <summary>
        /// Tells if a backup is in progress.
        /// </summary>
        public static bool BackupRunning
        {
            get
            {
                mutex.WaitOne();
                bool tmp = _BackupRunning;
                mutex.ReleaseMutex();
                return tmp;
            }
            private set
            {
                mutex.WaitOne();
                _BackupRunning = value;
                mutex.ReleaseMutex();
            }
        }
        #endregion

        #region LastMessage (public property)
        private static string _LastMessage = "";
        /// <summary>
        /// The last message given by a backup.
        /// Note that if RunBackup returned false,
        /// this means another backup is already
        /// in progress, thus this property will
        /// contain messages for that already running backup.
        /// </summary>
        public static string LastMessage
        {
            get
            {
                return _LastMessage;
            }
        }
        #endregion

        #region RunBackup (public method)
        /// <summary>
        /// Runs a backup.
        /// If false is returned, backup was not startet because another backup is in progress.
        /// If true is returned and Async is set to true, this means backup was startet.
        /// If true is returned and Async is set to false, this means backup has finished.
        /// In the case that false is returned, it makes no sense to use LastMessage, as the
        /// messages will belong to the already running thread. If true is returned,
        /// LastMessage will contain messages relevant to the just startet/ended backup.
        /// </summary>
        public static bool RunBackup(bool Async, bool AutoBackup)
        {
            /// NOTE: See in top of class to read about
            /// multithreading and accessing variables.

            if (!BackupRunning)
            {
                autobackup = AutoBackup;

                if (Async)
                {
                    // perform threaded backup
                    BackgroundWorker bw = new BackgroundWorker();
                    bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                    bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
                    bw.RunWorkerAsync();

                    // threaded backup startet
                    return true;
                }
                else
                {
                    // perform non-threaded backup
                    DoBackup();
                    
                    // non-threaded backup completed
                    return true;
                }
            }

            // backup not startet
            // because another backup
            // is in progress
            return false;
        }

        #endregion

        #region AsyncBackupComplete (public delegate)
        public delegate void AsyncBackupComplete(); // the delegate type
        public static AsyncBackupComplete AsyncBackupCompleteEvent = null; // the delegate instance
        #endregion

        #region DoBackup (private method)
        // the backup operation itself
        private static void DoBackup()
        {
            // only allow one backup at a time
            if (BackupRunning) return;

            // signal that a backup is running
            BackupRunning = true;

            // get the source path once (copy of dbfile is created)
            string SourcePath = GetDBSourcePath();
            _LastMessage = "";

            // flag telling if any backup was performed,
            // is used at the end of the method to tell
            // whether to set a completed message
            bool BackupPerformed = false;

            // perform local backup
            try
            {
                if (db.GetConfigStringAsBool("Backup_LocalEnabled"))
                {
                    if (!autobackup || db.GetConfigStringAsBool("Backup_LocalAuto"))
                    {
                        // backing up db file to local dir
                        string DestPath = GetDBDestinationPath(DestinationDirectory.Local, !autobackup);
                        if (DestPath != "")
                        {
                            _LastMessage = db.GetLangString("Backup.BackingUpToLocal");
                            File.Copy(SourcePath, DestPath, true);
                            BackupPerformed = true;
                        }
                    }
                }
            }
            catch { }

            // perform network backup
            try
            {
                if (db.GetConfigStringAsBool("Backup_NetworkEnabled"))
                {
                    if (!autobackup || db.GetConfigStringAsBool("Backup_NetworkAuto"))
                    {
                        // backup to external is done to radiant site controller,
                        // and we are allowed to make the backup outside the time interval 00:00 - 01:00.
                        if (!((DateTime.Now.Hour >= 0) && (DateTime.Now.Hour < 1)))
                        {
                            string DestPath = GetDBDestinationPath(DestinationDirectory.Network, !autobackup);
                            if (DestPath != "")
                            {
                                _LastMessage = db.GetLangString("Backup.BackingUpToNetwork");
                                File.Copy(SourcePath, DestPath, true);
                                BackupPerformed = true;
                            }
                        }
                    }
                }
            }
            catch { }

            // perform external backup           
            try
            {
                if (db.GetConfigStringAsBool("Backup_ExternalEnabled"))
                {
                    if (!autobackup)
                    {
                        string DestPath = GetDBDestinationPath(DestinationDirectory.External, true);
                        if (DestPath != "")
                        {
                            _LastMessage = db.GetLangString("Backup.BackingUpToExternal");
                            File.Copy(SourcePath, DestPath, true);

                            // save date for when the external backup was performed
                            db.SetConfigString("Backup_LastExternalBackup", DateTime.Now.Date);

                            BackupPerformed = true;
                        }
                    }
                    else
                    {
                        // in autobackup for external location, we just check for when the
                        // user last time made a backup held together with the selected
                        // backup interval

                        // get values from config
                        DateTime LastBackup = db.GetConfigStringAsDateTime("Backup_LastExternalBackup");
                        int BackupInterval = db.GetConfigStringAsInt("Backup_ExternalBackupInterval");
                        DateTime LastNeededBackup;
                        string msg = "";

                        // build interval
                        switch(BackupInterval)
                        {
                            case 1: // daily
                                LastNeededBackup = DateTime.Now.Date - (new TimeSpan(1, 0, 0, 0));
                                msg = db.GetLangString("Backup.ExternalBackupIntervalMetDay");
                                break;
                            case 2: // weekly
                                LastNeededBackup = DateTime.Now.Date - (new TimeSpan(7, 0, 0, 0));
                                msg = db.GetLangString("Backup.ExternalBackupIntervalMetWeek");
                                break;
                            case 3: // monthly
                                LastNeededBackup = DateTime.Now.Date - (new TimeSpan(30, 0, 0, 0));
                                msg = db.GetLangString("Backup.ExternalBackupIntervalMetMonth");
                                break;
                            default: // never (actually this has value 4 in database)
                                LastNeededBackup = DateTime.MinValue;
                                break;
                        }

                        // make the check and display messasge if it is time to make external backup
                        if (LastNeededBackup != DateTime.MinValue)
                        {
                            if (LastBackup < LastNeededBackup)
                                ShowMessage(msg);
                        }
                    }
                }
            }
            catch { }

            // clean up destination directories
            DeleteOldBackupFiles();

            // backup process completed so give message
            // and signal backup is not running
            if (BackupPerformed)
                _LastMessage = db.GetLangString("Backup.BackupCompleted");
            BackupRunning = false;
        }

        private static void ShowMessage(string msg)
        {
            bool BackupRunningOld = BackupRunning;
            BackupRunning = false;
            MessageBox.Show(msg);
            BackupRunning = BackupRunningOld;
        }
        #endregion

        #region GetDBSourcePath (private method)
        /// <summary>
        /// Creates a working copy of the dbfile and
        /// returns it's path. the variable workingcopy
        /// is also set to this path.
        /// Note that this should
        /// only be called once when backing up to the
        /// various backup locations, for instance before
        /// backing up and then reusing the path string.
        /// </summary>
        private static string GetDBSourcePath()
        {
            // build path for the current database file
            string tmp = Application.StartupPath + "\\RBOS20.accdb";
            tmp = tmp.Replace("\\\\", "\\");

            // build path for working copy of the file
            string path = Application.StartupPath + "\\RBOS20.rbk";
            path = path.Replace("\\\\", "\\");

            // make a working copy
            File.Copy(tmp, path, true);

            // return path to the working copy
            workingcopy = path;
            return path;
        }
        #endregion

        #region GetDBDestinationPath (private method)
        /// <summary>
        /// Returns the destination path for the db file including
        /// directory and a new unique filename. If the directory
        /// does not exist, it will be created in the method. If the
        /// file already exist for the same date or an error occurs, "" is returned,
        /// meaning no backup is to be performed. "" is also returned if an
        /// error occurs and backup cannot be performed to the directory.
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        private static string GetDBDestinationPath(DestinationDirectory dir, bool BackupNoMatterExistingFiles)
        {
            // get correct directory
            string directory = "";
            switch (dir)
            {
                case DestinationDirectory.Local:
                    directory = db.GetConfigString("Backup_LocalDir");
                    break;
                case DestinationDirectory.Network:
                    directory = db.GetConfigString("Backup_NetworkDir");
                    break;
                case DestinationDirectory.External:
                    directory = db.GetConfigString("Backup_ExternalDir");
                    break;
            }

            // make sure the destination directory exists
            if (!Directory.Exists(directory))
            {
                try { Directory.CreateDirectory(directory); }
                catch
                {
                    switch(dir)
                    {
                        case DestinationDirectory.Local:
                            ShowMessage(db.GetLangString("Backup.AccessErrorLocal"));
                            return "";
                        case DestinationDirectory.Network:
                            ShowMessage(db.GetLangString("Backup.AccessErrorNetwork"));
                            return "";
                        case DestinationDirectory.External:
                            ShowMessage(db.GetLangString("Backup.AccessErrorExternal"));
                            return "";
                    }
                }
            }

            // test that we can write to destination directory
            string testfile = directory + "\\alasjlakjsflkjasflkjs.test";
            try
            {
                testfile = testfile.Replace("\\\\", "\\");
                StreamWriter writer = new StreamWriter(testfile);
                writer.Write("test");
                writer.Close();
            }
            catch { }
            if (File.Exists(testfile))
                File.Delete(testfile);
            else
            {
                switch (dir)
                {
                    case DestinationDirectory.Local:
                        ShowMessage(db.GetLangString("Backup.WriteErrorLocal"));
                        return "";
                    case DestinationDirectory.Network:
                        ShowMessage(db.GetLangString("Backup.WriteErrorNetwork"));
                        return "";
                    case DestinationDirectory.External:
                        ShowMessage(db.GetLangString("Backup.WriteErrorExternal"));
                        return "";
                }
            }

            // build path
            DateTime now = DateTime.Now;
            string path = directory + "\\RBOSBackup" + now.ToString("yyyyMMddHHmmss") + ".rbk";
            path = path.Replace("\\\\", "\\");

            bool AlreadyExist = false;

            // checks if a file with the pattern "<path>\RBOSBackup<yyyyMMdd><time>.rbk"
            // already exist in the destination directory (time is ignored)
            string p = @"^(.*\\RBOSBackup" + now.ToString("yyyyMMdd") + @"[0-9]{6}\.rbk)$";
            Regex regex = new Regex(p, RegexOptions.IgnoreCase);
            List<string> SorteFileList = GetSortedFileList(dir); // get list of backup files
            foreach (string s in SorteFileList)
            {
                if (regex.IsMatch(s))
                    AlreadyExist = true;
            }

            // if not already existing, return
            // the generated path, otherwise return ""
            if ((!AlreadyExist) || (BackupNoMatterExistingFiles))
                return path;
            else
                return "";
        }
        #endregion

        #region DeleteOldBackupFiles (private method)
        // will delete old files that exceeds the n limit of files
        // in local and network dirs (not in external dir)
        private static void DeleteOldBackupFiles()
        {
            // get number of days for backup history
            int NumDaysBack = db.GetConfigStringAsInt("Backup_NumDaysBack");

            // disallow 0 days backup history
            if (NumDaysBack == 0)
                NumDaysBack = 3;

            // clean up files in local and network dir
            for (int x = 0; x < 2; x++)
            {
                // get a list of backup files
                List<string> list = null;
                switch (x)
                {
                    case 0: list = GetSortedFileList(DestinationDirectory.Local); break;
                    case 1: list = GetSortedFileList(DestinationDirectory.Network); break;
                }

                // delete database files older than NumDaysBack days
                foreach (string file in list)
                {
                    DateTime dt = DateWithoutDashes2DateTime(file);
                    if (dt < (DateTime.Now.Date - (new TimeSpan(NumDaysBack,0,0,0))))
                    {
                        try
                        {
                            if (File.Exists(file))
                                File.Delete(file);
                        }
                        catch { }
                    }
                }
            }

            // clean up working copy of database
            if (File.Exists(workingcopy))
            {
                try
                {
                    File.Delete(workingcopy);
                    workingcopy = "";
                }
                catch {}
            }
        }
        #endregion

        #region DateWithoutDashes2DateTime (private method)
        private static DateTime DateWithoutDashes2DateTime(string dbfile)
        {
            string sDate = tools.SubStringSafe(dbfile, dbfile.Length - 18, 8);
            return tools.object2datetime(sDate);
        }
        #endregion

        #region GetSortedFileList
        private static List<string> GetSortedFileList(DestinationDirectory dir)
        {
            string destdir = "";

            switch (dir)
            {
                case DestinationDirectory.Local:
                    destdir = db.GetConfigString("Backup_LocalDir");
                    break;
                case DestinationDirectory.Network:
                    destdir = db.GetConfigString("Backup_NetworkDir");
                    break;
                case DestinationDirectory.External:
                    destdir = db.GetConfigString("Backup_ExternalDir");
                    break;
                default:
                    return null;
            }

            if (Directory.Exists(destdir))
            {
                try
                {
                    string[] files = Directory.GetFiles(destdir, "*.rbk*", SearchOption.TopDirectoryOnly);
                    List<string> list = tools.StringArray2StringList(files);
                    list.Sort();
                    return list;
                }
                catch
                {
                    return new List<string>();
                }
            }
            else
                return new List<string>();
        }
        #endregion

        #region CreateVersionUpdateBackup
        /// <summary>
        /// Creates a backup that should be
        /// created before performing a version update
        /// of RBOS. Should be called from the version updater.
        /// </summary>
        public static void CreateVersionUpdateBackup(string Version)
        {
            // build path for the current database file
            string tmp = Application.StartupPath + "\\RBOS20.accdb";
            tmp = tmp.Replace("\\\\", "\\");

            // the config string Backup_LocalDir was added in version 2.01.016
            // and it was also in that version that this code was added. this code
            // runs before the config string is added, so if it is empty, hardcode it.
            string localbackupdir = db.GetConfigString("Backup_LocalDir");
            if (localbackupdir == "")
                localbackupdir = "C:\\DRS\\RBOSBackup";
            localbackupdir = localbackupdir.Replace("\\\\", "\\");

            // make sure the localbackupdir exists
            if (!Directory.Exists(localbackupdir))
                Directory.CreateDirectory(localbackupdir);

            // build path for the copy
            string path = localbackupdir + "\\RBOSBackup" + Version + ".rvbk";
            path = path.Replace("\\\\", "\\");

            // copy the file
            File.Copy(tmp, path, true);                        
        }
        #endregion

        private static void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            // event handler for doing the background worker's work
            DoBackup();
        }

        private static void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // invoke delegate instance asyncBackupComplete
            AsyncBackupCompleteEvent();
        }
    }
}
