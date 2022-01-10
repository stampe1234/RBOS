using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.ComponentModel;
using System.Timers;
using Microsoft.Win32;
using System.Diagnostics;

namespace RBOS
{
	/// <summary>
	/// A collection of static methods and properties related to
	/// users in the system. For more general database items, use db.
	/// This class makes use of the methods and properties in the db class,
	/// thus the Initialize method must be called on db before using this class.
	/// </summary>
	public class UserLogon
    {
        #region Private variables

        private static bool _LoggedOn = false;
        private static Timer AliveTimer = null;

        // filled in when successfully logged on
        private static string SelectedAndLockedDatabase = "";
        private static string LoggedOnUsername = "";
        private static string LoggodOnPassword = "";
        private static string LoggedOnServer_ = "";
        private static bool CanEditSalesPrice;
        private static bool CanEditItem;


        #endregion

        #region Constructor
        // protected constructor to avoid instances of the class
        protected UserLogon()
		{
        }
        #endregion

        #region LastMessage
        private static string _LastMessage = "";
        public static string LastMessage
        {
            get { return _LastMessage; }
        }
        #endregion

        private static string prevConnStringOleDb = "";
        private static string prevConnStringSqlClient = "";
        private static string prevDatabase = "";
        private static string prevServer = "";
        public static void SelectPrevDatabase()
        {
            SelectedAndLockedDatabase = prevDatabase;
            LoggedOnServer_ = prevServer;
            dbOleDb.ConnectionString = prevConnStringOleDb;
            db.ConnectionString = prevConnStringSqlClient;
            dbOleDb.ReInitialize();
        }

        #region VerifyUserAndSelectDatabase
        /// <summary>
		/// Verifies the user in the database.
		/// After verification, the public property 
		/// </summary>
		/// <returns>True or false for whether verification was successfull.</returns>
        public static bool VerifyUserAndSelectDatabase(string username, string password)
        {
            return VerifyUserAndSelectDatabase(username, password, true);
        }
        public static bool VerifyUserAndSelectDatabase(string username, string password, bool doUserVerification)
        {
            _LastMessage = "";

            // in case we need to return if failed
            prevConnStringSqlClient = db.ConnectionString;
            prevConnStringOleDb = dbOleDb.ConnectionString;
            prevDatabase = LoggedOnDatabase;
            prevServer = LoggedOnServer;

            if (doUserVerification)
            {
                _LoggedOn = false;
                LoggedOnUsername = "";
                LoggodOnPassword = "";
                _IsMultiUser = false;
                SelectedAndLockedDatabase = "";
                LoggedOnServer_ = "";
            }
            else // no user verification, just changing database
            {
                username = LoggedOnUsername;
                password = LoggodOnPassword;
            }

            // get InstallationID
            //string RegistryInstallationID = GetInstallationID();

            if (doUserVerification)
            {
                // do not allow blank username or passwords
                if ((username == "") || (password == "")) return false;
            }

            //dbCentralRBOS.ConnectionString =    .GetConnectionString("RBOS.Properties.Settings.LogonConnectionString", username, password, "CentralRBOS");

            using (SqlConnection conn = new SqlConnection(dbCentralRBOS.ConnectionString))
            {
                // open connection to the database with the user's credentials (which also verifies his/her credentials)
                ProgressForm progress = null;
                try { conn.Open(); }
                catch (Exception ex)
                {
                    // check the exception
                    if (ex.Message.ToLower().Contains("login failed"))
                    {
                        log.Write("Login not correct.");
                        _LastMessage = "Login ikke korrekt";
                        return false;
                    }
                    else
                    {
                    
                    
                    }
                }
                finally
                {
                    if (progress != null)
                        progress.Close();
                }

                if (doUserVerification)
                {
                    // save the username and password for unlocking the database on program shutdown
                    LoggedOnUsername = username;
                    LoggodOnPassword = password;

                    // check if the user has access to the installation (the physical machine)
                  
                }

                //check if the user are allowed to edit Sales prices

                
                
                
                // get a list of databases the user has access to
                DataTable DatabaseList = GetDatabaseList(Environment.UserName, conn);

               
                // if more than one result, let user select a database
                DataRow row;
                if (DatabaseList.Rows.Count == 1)
                {
                    // only one database, so use it
                    row = DatabaseList.Rows[0];
                }
                else if (DatabaseList.Rows.Count > 1)
                {
                    // there are more than one databases for this user, present a list to chose from
                    _IsMultiUser = true;
                    if (!doUserVerification)
                    {
                        // if changing db from RBOS, we don't want to present the
                        // database that the user is currently logged on to
                        foreach (DataRow r in DatabaseList.Rows)
                        {
                            if (tools.object2string(r["DatabaseName"]) == SelectedAndLockedDatabase)
                            {
                                DatabaseList.Rows.Remove(r);
                                break;
                            }
                        }
                    }
                    UserLogonDBList selecter = new UserLogonDBList(DatabaseList);
                    if (selecter.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        row = selecter.SelectedDatabase;
                    else
                        return false; // user canceled the selection dialog
                }
                else
                {
                    // user does not have access to any databases
                    _LastMessage = "Du har ikke adgang til en database";
                    return false;
                }

                // extract values from the row
                string SelectedDatabase = tools.object2string(row["DatabaseName"]);
                string LockedByLoginName = tools.object2string(row["LockedByLoginName"]);
                string LockedByInstallationID = tools.object2string(row["LockedByInstallationID"]);

                // some cleanup
                row = null;
                DatabaseList.Clear();
                DatabaseList = null;

                // check if the database is already locked
                if (LockedByLoginName != "")
                {
                    /// database is locked, but before we check by who, we check if the RBOS installation
                    /// that locked the database is no longer reporting itself as alive, in which
                    /// case we assume RBOS has crashed, and in which case we just take over the database.
                    bool LockValid;
                    using (SqlCommand cmd = new SqlCommand("HasValidLock", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("DatabaseName", SqlDbType.NVarChar).Value = SelectedDatabase;
                        cmd.Parameters.Add("Result", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        LockValid = tools.object2bool(cmd.Parameters["Result"].Value);
                    }

                    if (LockValid)
                    {
                        // ok, the database has a valid lock

                        if (LockedByLoginName != LoggedOnUsername)
                        {
                            _LastMessage = string.Format("'{0}' er allerede logget på databasen", LockedByLoginName);
                            return false;
                        }
                        
                    }
                }

                // check that client OS language is the same as SQL-login language
                if (!SQLLoginIsSameLanguageAsOS(dbCentralRBOS.ConnectionString))
                {
                    _LastMessage = "Sproget i Windows og dit SQL login stemmer ikke overens. Kontakt venligst support.";
                    return false;
                }

                // logon and database selection successful, finish up

                // if alive timer was running (for instance when changing database),
                // we must first stop the timer and then unlock the current database
                if (AliveTimer != null)
                {
                    AliveTimer.Stop();
                    AliveTimer = null;
                    UnlockCurrentDatabase();
                }

                // build SQL Client connection string to use when connecting to the
                // user's database using the new SQL statements (written after starting using SQL Server)
               // string tmpSQLClientConnString = ConfigFile.GetConnectionString("RBOS.Properties.Settings.LogonConnectionString", username, password, SelectedDatabase);
               // db.ConnectionString = tmpSQLClientConnString;

                // build OLE DB connection string to use when connecting to the
                // user's database using legacy code (converted MS Access code).
                // we base this on the SQL Client version.
                SqlConnectionStringBuilder a = new SqlConnectionStringBuilder("");
                OleDbConnectionStringBuilder b = new OleDbConnectionStringBuilder();
                b["Provider"] = "SQLOLEDB";
                b.DataSource = a.DataSource;
                b["Persist Security Info"] = true;
                b["Initial Catalog"] = a.InitialCatalog;
                b["User Id"] = a.UserID;
                b["Password"] = a.Password;
                string tmpOleDBConnString = b.ConnectionString; ;
                dbOleDb.ConnectionString = tmpOleDBConnString;

                // save the databasename
                LoggedOnServer_ = a.DataSource;

                // lock the selected database and mark as logged on
                LockDatabase(SelectedDatabase, Environment.UserName, conn);
                _LoggedOn = true;

                // start a timer that keeps reporting RBOS being alive
                int Interval = dbCentralRBOS.GetConfigStringAsInteger("ReportAliveInterval") * 1000;
                AliveTimer = new Timer(Interval);
                AliveTimer.Elapsed += new ElapsedEventHandler(AliveTimer_Elapsed);
                AliveTimer.AutoReset = true;
                AliveTimer.Start();
                AliveTimer_Elapsed(null, null); // report alive now (don't wait for the timer elapse)

                // return success
                return true;

            } // connection using
        }


        #endregion

        #region EditSalesPrice

        public static bool EditSalesPrice()
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default["RBOSInitConnectionStringSQL"].ToString()))
            
             {
            using (SqlCommand cmd = new SqlCommand("GetEditSalesPrice", conn))
                {
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("LoginName", SqlDbType.NVarChar).Value = Environment.UserName;
                    cmd.Parameters.Add("EditSalesPriceAllowed", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    object o = cmd.Parameters["EditSalesPriceAllowed"].Value;
                    CanEditSalesPrice = tools.object2bool(o);
                }
                return CanEditSalesPrice;
            }
        }
        #endregion

        #region EditItem

        public static bool EditItem()
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default["RBOSInitConnectionStringSQL"].ToString()))

            {
                using (SqlCommand cmd = new SqlCommand("GetEditItem", conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("LoginName", SqlDbType.NVarChar).Value = Environment.UserName;
                    cmd.Parameters.Add("EditItemAllowed", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    object o = cmd.Parameters["EditItemAllowed"].Value;
                    CanEditItem = tools.object2bool(o);
                }
                return CanEditItem;
            }
        }
        #endregion

        #region GetDatabaseList
        public static DataTable GetDatabaseList()
        {
            using (SqlConnection conn = new SqlConnection(dbCentralRBOS.ConnectionString))
            {
                return GetDatabaseList(Environment.UserName, conn);
            }
        }
        public static DataTable GetDatabaseList(string InstallationID, SqlConnection conn)
        {
            DataTable DatabaseList;
            using (SqlCommand cmd = new SqlCommand("DatabaseList", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("InstallationID", SqlDbType.NVarChar).Value = InstallationID;
                DatabaseList = db.GetDataTable("");
            }
            return DatabaseList;
        }
        #endregion

        #region AliveTimer_Elapsed
        static void AliveTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(dbCentralRBOS.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ReportRBOSAlive", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("DatabaseName", SqlDbType.NVarChar).Value = SelectedAndLockedDatabase;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region LoggedOn
        /// <summary>
		/// Tells whether the user has successfully logged onto the system,
		/// that is, has the method VerifyUser successfully been able to
		/// approve the given username and password against the database.
		/// </summary>
		public static bool LoggedOn
		{
			get
			{
                //return _LoggedOn;
                return true;  //peter
			}
        }
        #endregion

        #region Username
        /// <summary>
        /// The logged on user's Username.
        /// </summary>
        public static string Username
        {
            get
            {
                if (!_LoggedOn) return "";
                return LoggedOnUsername;
            }
        }
        #endregion

        #region ProfileID
        /// <summary>
        /// The logged on user's ProfileID.
        /// </summary>
        public static AdminDataSet.UserProfilesDataTable.ProfileID ProfileID
        {
            get
            {
                // if user somehow is not logged on, return invalid profileid
                if (!_LoggedOn) return AdminDataSet.UserProfilesDataTable.ProfileID.invalid;

                // check if user exists in database. if not, -1 is returned.
                // if user is found, the user's profileid is returned.
                // NOTE: Do NOT avoid extracting the value into an object first,
                // as we need to know if the user was found at all. Returning the
                // default value from tools.object2int will give 0 if null was found,
                // and 0 means drs user, which is the superuser, and we don't want
                // the default user to be superuser.
                using (SqlConnection conn = new SqlConnection(dbCentralRBOS.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetProfileID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("LoginName", SqlDbType.NVarChar).Value = LoggedOnUsername;
                        cmd.Parameters.Add("ProfileID", SqlDbType.NVarChar, 20).Direction = ParameterDirection.Output;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        object o = cmd.Parameters["ProfileID"].Value;
                        if (tools.IsNullOrDBNull(o))
                            return AdminDataSet.UserProfilesDataTable.ProfileID.invalid;
                        else
                        {
                            try { return (AdminDataSet.UserProfilesDataTable.ProfileID)tools.object2int(o); }
                            catch { return AdminDataSet.UserProfilesDataTable.ProfileID.invalid; }
                        }
                    }
                }
            }
        }
        #endregion

        #region LockDatabase
        public static void LockDatabase(string DatabaseName)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default["RBOSInitConnectionStringSQL"].ToString()))
            {
                conn.Open();
                LockDatabase(DatabaseName, Environment.UserName, conn);
            }
        }
        private static void LockDatabase(string DatabaseName, string UserName, SqlConnection conn)
        {
            //if (LoggedOnUsername != "")
            //{
                using (SqlCommand cmd = new SqlCommand("LockDatabase", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("DatabaseName", SqlDbType.NVarChar).Value = DatabaseName;
                    cmd.Parameters.Add("UserName", SqlDbType.NVarChar).Value = UserName;
                    cmd.ExecuteNonQuery();
                    SelectedAndLockedDatabase = DatabaseName;
                }
            //}
        }
        #endregion

        #region UnlockCurrentDatabase
        public static void UnlockCurrentDatabase()
        {
            if (SelectedAndLockedDatabase != "" && Environment.UserName != "")
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default["RBOSInitConnectionStringSQL"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("UnlockDatabase", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("DatabaseName", SqlDbType.NVarChar).Value = SelectedAndLockedDatabase;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        SelectedAndLockedDatabase = "";
                    }
                }
            }
        }
        #endregion

        #region SQLLoginIsSameLanguageAsOS
        /// <summary>
        /// Checks whether the language of the used SQL login is the same as windows.
        /// <param name="ConnectionString">Must be the SQL Client connection string for the database the user selected</param>
        /// </summary>
        private static bool SQLLoginIsSameLanguageAsOS(string ConnectionString)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                System.Globalization.CultureInfo currentCulture = System.Threading.Thread.CurrentThread.CurrentCulture;
                SqlConnectionStringBuilder tmp = new SqlConnectionStringBuilder(ConnectionString);
                string SqlLoginName = tmp.UserID;                

                string sql = @"
                    select [language]
                    from master.dbo.syslogins
                    where [name] = @name
                ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("name", SqlDbType.NVarChar).Value = SqlLoginName;
                    conn.Open();
                    string SQLLoginLang = tools.object2string(cmd.ExecuteScalar()).ToLower();
                    string OSLang = currentCulture.Parent.NativeName.ToLower();
                    return OSLang == SQLLoginLang;
                }
            }
        }
        #endregion

        #region LoggedOnDatabase
        public static string LoggedOnDatabase
        {
            get
            {
                return SelectedAndLockedDatabase;
            }
        }
        #endregion

        #region LoggedOnServer
        public static string LoggedOnServer
        {
            get
            {
                return LoggedOnServer_;
            }
        }
        #endregion

        #region IsMultiUser
        private static bool _IsMultiUser = false;
        /// <summary>
        /// Tells whether the logged on user has access to multiple database.
        /// </summary>
        public static bool IsMultiUser
        {
            get { return _IsMultiUser; }
        }
        #endregion

    


        #region InitialSetupCompleted
        //public static bool InitialSetupCompleted()
       // {
        //    bool InstallationIDExists = GetInstallationID() != "";
        //   // bool LogonConnectionStringExists = ConfigFile.GetConnectionString("RBOS.Properties.Settings.LogonConnectionString", "", "", "") != "";
        //    return InstallationIDExists && LogonConnectionStringExists;
        //}
        #endregion

        #region RequestDatabaseUnlock
        public static void RequestDatabaseUnlock(string database)
        {
            using (SqlConnection conn = new SqlConnection(dbCentralRBOS.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("RequestDatabaseUnlock", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("DatabaseName", SqlDbType.NVarChar, 50).Value = database;
                    cmd.Parameters.Add("LoginName", SqlDbType.NVarChar).Value = LoggedOnUsername;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region RemoveRequestDatabaseUnlock
        /// <summary>
        /// Removes the flag UnlockRequested for the given database.
        /// </summary>
        /// <param name="database">The database to remove the lock on</param>
        public static void RemoveRequestDatabaseUnlock(string database)
        {
            using (SqlConnection conn = new SqlConnection(dbCentralRBOS.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("RemoveRequestDatabaseUnlock", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("DatabaseName", SqlDbType.NVarChar, 50).Value = database;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Removes the flag UnlockRequested for the currently selected database
        /// </summary>
        public static void RemoveRequestDatabaseUnlock()
        {
            RemoveRequestDatabaseUnlock(SelectedAndLockedDatabase);
        }
        #endregion

        #region DatabaseHasValidLock
        public static bool DatabaseHasValidLock(string database)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default["RBOSInitConnectionStringSQL"].ToString())) 
            {
                using (SqlCommand cmd = new SqlCommand("HasValidLock", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("DatabaseName", SqlDbType.NVarChar).Value = database;
                    cmd.Parameters.Add("Result", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return tools.object2bool(cmd.Parameters["Result"].Value);
                }
            }
        }
        #endregion

        #region DatabaseUnlockRequested
        /// <summary>
        /// Checks if an unlock as been requested on the given databaae.
        /// </summary>
        /// <returns></returns>
        public static bool DatabaseUnlockRequested(string database)
        {
            using (SqlConnection conn = new SqlConnection(dbCentralRBOS.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("CheckUnlockRequested", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("DatabaseName", SqlDbType.NVarChar).Value = database;
                    cmd.Parameters.Add("Result", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return tools.object2bool(cmd.Parameters["Result"].Value);
                }
            }
        }
        /// <summary>
        /// Checks if an unlock as been requested on the currently selected and locked databaae.
        /// </summary>
        /// <returns></returns>
        public static bool DatabaseUnlockRequested()
        {
            return DatabaseUnlockRequested(SelectedAndLockedDatabase);
        }
        #endregion

        #region UnlockRequetedBy
        /// <summary>
        /// Gets the SQL login name of the multiuser who has requested to unlock the currently selected database.
        /// </summary>
        public static string UnlockRequetedBy()
        {
            using (SqlConnection conn = new SqlConnection(dbCentralRBOS.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UnlockRequestedBy", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("DatabaseName", SqlDbType.NVarChar).Value = SelectedAndLockedDatabase;
                    cmd.Parameters.Add("Result", SqlDbType.NVarChar, 20).Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return tools.object2string(cmd.Parameters["Result"].Value).Trim();
                }
            }
        }
        #endregion
    }
}
