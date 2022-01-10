using System;
using System.Collections.Generic;
using System.Text;
using Indy.Sockets;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace RBOS
{
    class FTP
    {
        #region Private variables

        private Indy.Sockets.FTP ftp = null;
        private int FTPAccountID = 0;
        private string client_departure_dir = "";
        private string client_arrival_dir = "";
        private string server_departure_dir = "";
        private string server_arrival_dir = "";
        private FTPLogForm log = null;

        #endregion

        #region ENUM: TransferType
        enum TransferType
        {
            ASCII,
            Binary
        }
        #endregion

        #region Constructor
        public FTP(int FTPAccountID, Form Owner)
        {
            log = new FTPLogForm(Owner);
            ftp = new Indy.Sockets.FTP();
            LoadFTPAccountSettings(FTPAccountID);
        }
        #endregion

        #region METHOD: LoadFTPAccountSettings
        private void LoadFTPAccountSettings(int FTPAccountID)
        {
            log.StartLog();

            // load FTP account settings
            this.FTPAccountID = FTPAccountID;
            DataRow ftpAccount = AdminDataSet.FTPAccountsDataTable.GetFTPAccount(FTPAccountID);
            if (ftpAccount == null)
            {
                log.Message = db.GetLangString("FTP.ERROR.AccuntNotFound");
                return;
            }

            // setup FTP connection
            ftp.Host = ftpAccount["Host"].ToString();
            ftp.Port = tools.object2int(ftpAccount["Port"]);
            ftp.Username = ftpAccount["Username"].ToString();
            ftp.Password = ftpAccount["Passwd"].ToString();
            ftp.Passive = tools.object2bool(ftpAccount["Passive"]);
            ftp.TransferType = FTPTransferType.ftASCII;
            if (ftpAccount["TransferType"].ToString().ToLower() == "binary")
                ftp.TransferType = FTPTransferType.ftBinary;
            ftp.ProxySettings.Host = ftpAccount["ProxyHost"].ToString();
            ftp.ProxySettings.Port = tools.object2int(ftpAccount["ProxyPort"]);
            ftp.ProxySettings.UserName = ftpAccount["ProxyUsername"].ToString();
            ftp.ProxySettings.Password = ftpAccount["ProxyPassword"].ToString();

            // setup local/remote directories
            client_departure_dir = ftpAccount["ClientDepartureDir"].ToString();
            client_arrival_dir = ftpAccount["ClientArrivalDir"].ToString();
            server_departure_dir = ftpAccount["ServerDepartureDir"].ToString();
            server_arrival_dir = ftpAccount["ServerArrivalDir"].ToString();
        }
        #endregion

        #region METHOD: Connect
        private void Connect()
        {
            if (ftp.Connected())
                ftp.Disconnect();
            log.Message = db.GetLangString("FTP.ConnectingToFTPServer");
            ftp.Connect();
            log.Message = db.GetLangString("FTP.ConnectedToFTPServerOK");
        }
        #endregion

        #region METHOD: Disconnect
        private void Disconnect()
        {
            if (ftp.Connected())
            {
                ftp.Disconnect();
                log.Message = db.GetLangString("FTP.DisconnectedFromServer");
            }
        }
        #endregion

        #region METHOD: UploadFile
        /// <summary>
        /// Uploads the given file to the FTP
        /// account given in the constructor. Only
        /// specify the file name as the directory
        /// is fetched from the FTP account given in the constructor.
        /// </summary>
        /// <param name="Filename"></param>
        /// <returns></returns>
        public bool UploadFile(string Filename)
        {
            bool ok = true;

            try
            {
                // connect to FTP server
                Connect();

                // go to server arrival directory
                try { ftp.MakeDir(server_arrival_dir); }
                catch { }
                ftp.ChangeDir(server_arrival_dir);
                log.Message = db.GetLangString("FTP.CurrentDirIs") + ": " + ftp.RetrieveCurrentDir();
              
                // Upload file
                string localUploadFilename = client_departure_dir + "\\" + Filename;
                log.Message = db.GetLangString("FTP.UploadingFile") + ": " + localUploadFilename;
                try
                {
                    // allocate space for the file on the
                    // server (some servers needs this)
                    FileStream stream = File.OpenRead(localUploadFilename);
                    int fsize = (int)stream.Length;
                    stream.Close();
                    try { ftp.Allocate(fsize); }
                    catch { }

                    // upload the file
                    ftp.Put(localUploadFilename, Filename, false);

                    // if upload ok, delete local file
                    // if FTP return code is 226 (file operation ok)
                    if (ftp.LastCmdResult.Code == "226")
                    {
                        File.Delete(localUploadFilename);
                        log.Message = db.GetLangString("FTP.UploadedFileOK");
                    }
                    else
                    {
                        log.Message = db.GetLangString("FTP.ERROR.UploadingFile") + ": " + ftp.LastCmdResult.DisplayName;
                        ok = false;
                    }
                }
                catch (Exception ex)
                {
                    log.Message = db.GetLangString("FTP.ERROR.UploadingFile") + ": " + ex.Message;
                    ok = false;
                }
            }
            catch(Exception ex)
            {
                log.Message = db.GetLangString("FTP.ERROR") + ": " + ex.Message;
                ok = false;
            }
            finally
            {
                // disconnect from FTP server
                Disconnect();
                log.EndLog();
            }

            return ok;
        }
        #endregion

        #region METHOD: UploadFileToMultipleStations
        /// <summary>
        /// Uploads the given file to each station's ftp directory.
        /// </summary>
        public bool UploadFileToMultipleStations(string FullFilePath, List<string> SiteCodes)
        {
            bool ok = true;

            try
            {
                Connect();
                string Filename = tools.StripDirectoryFromPath(FullFilePath);
                string ClientDir = tools.StripFilenameFromPath(FullFilePath);
                string localUploadFilename = ClientDir + (ClientDir.EndsWith("\\") ? "" : "\\") + Filename;
                FileStream stream = File.OpenRead(localUploadFilename);
                int LocalFileSize = (int)stream.Length;
                stream.Close();

                foreach (string SiteCode in SiteCodes)
                {
                    string ServerDir = SiteCode + "/Depart";

                    // go to server arrival directory
                    ftp.ChangeDir("/");
                    try { ftp.MakeDir(ServerDir); }
                    catch { }
                    ftp.ChangeDir(ServerDir);
                    log.Message = db.GetLangString("FTP.CurrentDirIs") + ": " + ftp.RetrieveCurrentDir();

                    // Upload file
                    log.Message = db.GetLangString("FTP.UploadingFile") + ": " + localUploadFilename;
                    try
                    {
                        // allocate space for the file on the
                        // server (some servers needs this)
                        try { ftp.Allocate(LocalFileSize); }
                        catch { }

                        // upload the file
                        ftp.Put(localUploadFilename, Filename, false);

                        // if upload ok
                        if (ftp.LastCmdResult.Code == "226")
                        {
                            log.Message = db.GetLangString("FTP.UploadedFileOK");
                        }
                        else
                        {
                            log.Message = db.GetLangString("FTP.ERROR.UploadingFile") + ": " + ftp.LastCmdResult.DisplayName;
                            ok = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Message = db.GetLangString("FTP.ERROR.UploadingFile") + ": " + ex.Message;
                        ok = false;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Message = db.GetLangString("FTP.ERROR") + ": " + ex.Message;
                ok = false;
            }
            finally
            {
                // disconnect from FTP server
                Disconnect();
                log.EndLog();
            }

            return ok;
        }
        #endregion

        #region METHOD: DeleteRemoteFile
        public bool DeleteRemoteFile(string Filepath)
        {
            try
            {
                // connect to FTP server
                Connect();

                // delete file
                log.Message = db.GetLangString("FTP.DeletingRemoteFile") + ": " + Filepath;
                try { ftp.Delete(Filepath); }
                catch
                {
                    log.Message = db.GetLangString("FTP.ERROR.DeletingFile");
                    return false;
                }

                // check command result
                if (ftp.LastCmdResult.Code == "250")
                    log.Message = db.GetLangString("FTP.FileDeletedOK");
                else if (ftp.LastCmdResult.Code == "550")
                {
                    log.Message = db.GetLangString("FTP.FileNotFound");
                    return false;
                }
                else
                {
                    log.Message = db.GetLangString("FTP.ERROR") + ": " + ftp.LastCmdResult.DisplayName;
                    return false;
                }

                // delete ok
                return true;
            }
            catch (Exception ex)
            {
                log.Message = db.GetLangString("FTP.ERROR") + ": " + ex.Message;
                return false;
            }
            finally
            {
                // disconnect from FTP server
                Disconnect();
            }
        }
        #endregion

        #region METHOD: TestConnection
        /// <summary>
        /// Test the connection with the loaded FTP account settings.
        /// </summary>
        /// <returns>
        /// True for success false for failure.
        /// If false is returned, LastError will contain an error message.
        /// </returns>
        public bool TestConnection()
        {
            try
            {
                log.StartLog();
                log.Message = db.GetLangString("FTP.TestingConnection");

                string filename = "rbos-ftp-testfile.txt";
                string dir = "";

                // get client depart dir from FTP account settings
                DataRow ftpAccount = AdminDataSet.FTPAccountsDataTable.GetFTPAccount(FTPAccountID);
                if (ftpAccount != null)
                {
                    dir = ftpAccount["ClientDepartureDir"].ToString();
                }
                else
                {
                    log.Message = db.GetLangString("FTP.ERROR.AccuntNotFound");
                    return false;
                }

                // generate a file to be sent
                string filepath = dir + "\\" + filename;
                File.WriteAllText(filepath, "Test file for RBOS built-in FTP");

                // send the file (is deleted when sent)
                if (!UploadFile(filename))
                    return false;

                // delete file remotely
                if (!DeleteRemoteFile(ftpAccount["ServerArrivalDir"].ToString() + "/" + filename))
                    return false;

                // test succeded
                log.Message = db.GetLangString("FTP.TestedConnectionOK");
                return true;
            }
            catch (Exception ex)
            {
                log.Message = db.GetLangString("FTP.ERROR") + ": " + ex.Message;
                return false;
            }
            finally
            {
                log.Message = db.GetLangString("FTP.TestCompleted");
                log.EndLog();
            }

        }
        #endregion

        #region METHOD: CloseLogWindow
        /// <summary>
        /// Provided so log window can be closed
        /// without user having to click Ok.
        /// </summary>
        public void CloseLogWindow()
        {
            log.Close();
        }
        #endregion
    }
}