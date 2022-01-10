using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Text;
using System.Configuration;
using System.Collections.Generic;

namespace RBOS
{
    class dbOleDb
    {
    }
    public class dbOleDb
    {
        #region Private variables

        // tells if Initialize has been called, which is
        // mandatory before using any other method in this class
        private static bool initialized = false;

        // only one connection to db
        private static OleDbConnection connection = null;

        // used for caching language strings from the db.
        // will only contain keys and values for one language
        private static SortedList langStrings = null;

        // transaction used if any
        private static OleDbTransaction transaction = null;

        #endregion

        #region Constructor
        /// <summary>
        /// Protected constructor so no instances can be made. Remember to call
        /// Initialize before use and Shutdown after use.
        /// </summary>
        protected dbOleDb()
        {
        }
        #endregion

        #region ENUM: TransactionTypes
        /// <summary>
        /// Enum that refers to the
        /// table LookupItemTransactionType
        /// </summary>
        public enum TransactionTypes
        {
            Sales = 1,
            Purchase = 2,
            Waste = 3,
            Count = 4,
            Adjustment = 5,
            Receive = 6,
            Transfer = 7,
            CountAdjustment = 8,
            SalesCount = 9
        }
        #endregion

        #region ENUM: ReasonCodes
        /// <summary>
        /// Enum that refers to the
        /// table LookupItemTransReasonCode
        /// </summary>
        public enum ReasonCodes
        {
            None = 0,
            Transfer = 1,
            Opening = 2,
            Damaged = 3,
            Age = 4,
            Other = 5
        }
        #endregion

        #region PROPERTY: Initialized
        /// <summary>
        /// Tells if database has been initialized. A call to Initialize must be done
        /// before using any of the database methods.
        /// </summary>
        public static bool Initialized
        {
            get { return initialized; }
        }
        #endregion

        #region PROPERTY: CurrentTransaction
        /// <summary>
        /// The current transaction created by a call to StartTransaction.
        /// Is only valid between a call to StartTransaction and
        /// CommitTransaction/RollbackTransaction.
        /// </summary>
        public static OleDbTransaction CurrentTransaction
        {
            get { return transaction; }
        }
        #endregion

        #region PROPERTY: Language
        /// <summary>
        /// Set the currently used language ("da", "en", "se", "no", "fi" etc.). Null returned if database not initialized.
        /// </summary>
        public static string Language
        {
            set
            {
                if (!initialized) return;
                // load language strings from the database into a cached list of key-value pairs for the given language
                langStrings = DataSet2SortedList(GetDataTable("select id, " + value + " from lang"), "id", value);
                // set the current language in database
                SetConfigString("CurrentLanguage", value);
            }
            get
            {
                if (!initialized) return null;
                // try to get current language from database, and if that fails, default to "da"
                return GetConfigString("CurrentLanguage", "da");
            }
        }
        #endregion

        #region PROPERTY: LanguageCamelCase
        /// <summary>
        /// Returns the language as CamelCase, and as lang string has two characters
        /// this will be for instance Da, En, Se, No etc.
        /// </summary>
        public static string LanguageCamelCase
        {
            get
            {
                if (Language.Length == 0) return "";
                return Language.ToUpper()[0] + Language.ToLower().Substring(1);
            }
        }
        #endregion

        #region PROPERTY: Connection
        /// <summary>
        /// Returns the connection object
        /// </summary>
        public static OleDbConnection Connection
        {
            get { return connection; }
        }
        #endregion

        #region METHOD: Initialize
        /// <summary>
        /// Loads and sets up a connection to the db. Loads the config strings to cached data.
        /// This method must be called prior to using any other methods in this class.
        /// </summary>
        /// <returns>true if success, false if failure. if false, the logfile will display the error.</returns>
        public static bool Initialize()
        {
            // database can only be initialized once
            if (initialized) return true;

            // create and open connection to database

            connection = new OleDbConnection(ConnectionString);
            connection.Open();

            initialized = true;

            // load last language from database and set it as the current language
            string currLang = dbOleDb.Language;
            dbOleDb.Language = currLang;

            // set the RBOSConnectionStringOLEDB so adapters by default connect correctly
            //Properties.Settings.Default["RBOSConnectionStringOLEDB"] = ConnectionString;            

            return true;
        }
        #endregion

        #region ReInitialize
        /// <summary>
        /// Creates a new connection object based on the connection string.
        /// This is used when the connection string has changed during the running application.
        /// Call Initialize to set it up the first time.
        /// </summary>
        /// <returns></returns>
        public static bool ReInitialize()
        {
            connection.Close();
            connection.Dispose();
            connection = new OleDbConnection(ConnectionString);
            connection.Open();
            return true;
        }
        #endregion

        #region ConnectionString
        /// <summary>
        /// Returns an OleDb connection string.
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                return Properties.Settings.Default.RBOSConnectionStringOLEDB;
            }
            set
            {
                Properties.Settings.Default["RBOSConnectionStringOLEDB"] = value;
            }
        }
        #endregion

        #region METHOD: Shutdown
        /// <summary>
        /// Shuts down the database in a good manner. Also saves the cached config strings.
        /// </summary>
        public static void Shutdown()
        {
            if (initialized)
            {
                connection.Dispose();
                connection = null;
                initialized = false;
            }
        }
        #endregion

        #region METHOD StartTransaction
        /// <summary>
        /// Starts a transaction on the connection.
        /// Remember to call CommitTransaction or RollbackTransaction.
        /// </summary>
        public static OleDbTransaction StartTransaction()
        {
            transaction = null;
            if (!initialized) return null;
            transaction = connection.BeginTransaction();
            return transaction;
        }
        #endregion

        #region METHOD: CommitTransaction
        /// <summary>
        /// Commits the current transaction on the connection.
        /// NOTE: StartTransaction must be called sometime before this method,
        /// otherwise this method has no effect.
        /// </summary>
        public static void CommitTransaction()
        {
            if (!initialized || (transaction == null)) return;
            transaction.Commit();
            transaction = null;
        }
        #endregion

        #region METHOD: RollbackTransaction
        /// <summary>
        /// Rolls back the current transaction on the connection,
        /// to the point where StartTransaction where called.
        /// NOTE: StartTransaction must be called sometime before this method,
        /// otherwise this method has no effect.
        /// </summary>
        public static void RollbackTransaction()
        {
            if (!initialized || (transaction == null)) return;
            transaction.Rollback();
            transaction = null;
        }
        #endregion

        #region GetDataTable
        /// <summary>
        /// Generates a plain data table from the given SQL.
        /// At least an empty table will be returned.
        /// </summary>
        /// <param name="sql">A valid SQL string</param>
        /// <returns>The data table. Empty if database not initialized.</returns>
        public static DataTable GetDataTable(string sql)
        {
            if (!initialized) return new DataTable();
            DataTable table = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, connection);
            adapter.SelectCommand.Transaction = transaction;
            adapter.Fill(table);
            return table;
        }

        /// <summary>
        /// Generates a data table from the given SQL.
        /// If no data is loaded, an empty table is returned.
        /// Note that the cmd object should be created with the using
        /// keyword so it is released correctedly when done.
        /// NOTE: Does not use the db.Connection or it's transaction
        /// and the command should not be created with the db class's connection.
        /// </summary>
        public static DataTable GetDataTable(OleDbCommand cmd)
        {
            DataTable table = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(table);
            return table;
        }

        #endregion

        #region GetDataRow
        /// <summary>
        /// Generated a DataRow from the given SQL.
        /// If more than one record is loaded,
        /// the first one is returned. If no
        /// records were loaded, null is returned.
        /// </summary>
        public static DataRow GetDataRow(string sql)
        {
            DataTable table = GetDataTable(sql);
            if (table.Rows.Count > 0)
                return table.Rows[0];
            else
                return null;
        }

        /// <summary>
        /// Generate a DataRow from the given SQL.
        /// If more than one record is loaded,
        /// the first one is returned. If no
        /// records were loaded, null is returned.
        /// Note that the cmd object should be created
        /// with the using keywords so it is released correctly.
        /// NOTE: Does not use the db.Connection or it's transaction
        /// and the command should not be created with the db class's connection.
        /// </summary>
        public static DataRow GetDataRow(OleDbCommand cmd)
        {
            DataTable table = GetDataTable(cmd);
            if (table.Rows.Count > 0)
                return table.Rows[0];
            else
                return null;
        }

        #endregion

        #region FillDataTable
        public static void FillDataTable(string sql, DataTable Table, bool ClearTableFirst)
        {
            if (!initialized) return;
            if (ClearTableFirst)
                Table.Clear();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, connection);
            adapter.SelectCommand.Transaction = transaction;
            adapter.Fill(Table);
        }
        public static void FillDataTable(OleDbCommand Cmd, DataTable Table, bool ClearTableFirst)
        {
            if (ClearTableFirst)
                Table.Clear();
            OleDbDataAdapter adapter = new OleDbDataAdapter(Cmd);
            adapter.SelectCommand.Transaction = transaction;
            adapter.Fill(Table);
        }
        #endregion

        #region METHOD: ExecuteNonQuery
        public static void ExecuteNonQuery(string sql)
        {
            if (!initialized) return;
            OleDbCommand cmd = new OleDbCommand(sql, connection);
            cmd.Transaction = transaction;
            cmd.ExecuteNonQuery();
        }
        #endregion

        #region METHOD: ExecuteScalar
        /// <summary>
        /// Executes and returns a OleDbCommad.ExecuteScalar() with the given SQL.
        /// </summary>
        public static object ExecuteScalar(string sql)
        {
            if (!initialized) return null;
            OleDbCommand cmd = new OleDbCommand(sql, connection);
            cmd.Transaction = transaction;
            return cmd.ExecuteScalar();
        }
        #endregion

        #region METHOD: GetConfigString
        /// <summary>
        /// Returns the value corresponding to the given key. Cached data.
        /// </summary>
        /// <param name="key">The key to look up</param>
        /// <returns>The value corresponding to the given key. Null if database not initialized.</returns>
        public static string GetConfigString(string key)
        {
            if (!initialized) return null;
            return GetConfigString(key, "");
        }
        #endregion

        #region METHOD: GetConfigString
        /// <summary>
        /// Returns the value corresponding to the given key and uses a given
        /// fallbackValue if key not found or value is an empty string. Cached data.
        /// </summary>
        /// <param name="key">The key to look up</param>
        /// <param name="fallbackValue">If the key is not found or value is an empty string, fallbackValue will be returned.</param>
        /// <returns>The value corresponding to the given key. Null if database not initialized.</returns>
        public static string GetConfigString(string key, string fallbackValue)
        {
            if (!initialized) return null;
            string returnValue = fallbackValue;
            DataTable table = GetDataTable(String.Format("select ValueString from config where KeyString = '{0}'", key));
            if ((table.Rows.Count > 0) &&
                (table.Rows[0]["ValueString"].ToString() != ""))
            {
                returnValue = table.Rows[0]["ValueString"].ToString();
            }
            return returnValue;
        }
        #endregion

        #region METHOD: GetConfigStringAsBool
        public static bool GetConfigStringAsBool(string key)
        {
            return tools.object2bool(GetConfigString(key));
        }
        #endregion

        #region METHOD: GetConfigStringAsByte
        public static byte GetConfigStringAsByte(string key)
        {
            string val = GetConfigString(key);
            if (val == "") return 0;
            try { return byte.Parse(val); }
            catch { return 0; }
        }
        #endregion

        #region METHOD: GetConfigStringAsInt
        public static int GetConfigStringAsInt(string key)
        {
            string val = GetConfigString(key);
            if (val == "") return 0;
            try { return int.Parse(val); }
            catch { return 0; }
        }
        #endregion

        #region METHOD: GetConfigStringAsLong
        public static long GetConfigStringAsLong(string key)
        {
            string val = GetConfigString(key);
            if (val == "") return 0;
            try { return long.Parse(val); }
            catch { return 0; }
        }
        #endregion

        #region METHOD: GetConfigStringAsFloat
        public static float GetConfigStringAsFloat(string key)
        {
            string val = GetConfigString(key);
            if (val == "") return 0;
            try { return float.Parse(val); }
            catch { return 0; }
        }
        #endregion

        #region METHOD: GetConfigStringAsDouble
        public static double GetConfigStringAsDouble(string key)
        {
            string val = GetConfigString(key);
            if (val == "") return 0;
            try { return tools.object2double(val); }
            catch { return 0; }
        }
        #endregion

        #region METHOD: GetConfigStringAsDateTime
        public static DateTime GetConfigStringAsDateTime(string key)
        {
            return tools.object2datetime(GetConfigString(key));
        }
        #endregion

        #region METHOD: SetConfigString (several overloads)

        public static void SetConfigString(string key, string val)
        {
            if (!initialized) return;
            // check if key already exist in database
            //(NOTE: do not just call GetConfigString to check if it exist, as this
            // method won't tell you if an empty string was returned because the
            // value was empty in the database and the key actually was found
            bool alreadyExists = false;
            DataTable table = GetDataTable(String.Format("select KeyString from config where KeyString = '{0}'", key));
            alreadyExists = (table.Rows.Count > 0);

            // update/insert the key-value pair in the database
            if (alreadyExists)
                ExecuteNonQuery(String.Format("update config set ValueString = '{0}' where KeyString = '{1}'", val, key));
            else
                ExecuteNonQuery(String.Format("insert into config (KeyString,ValueString) values ('{0}','{1}')", key, val));
        }

        public static void SetConfigString(string key, bool val)
        {
            SetConfigString(key, val.ToString().ToLower());
        }

        public static void SetConfigString(string key, int val)
        {
            SetConfigString(key, val.ToString());
        }

        public static void SetConfigString(string key, long val)
        {
            SetConfigString(key, val.ToString());
        }

        public static void SetConfigString(string key, DateTime val)
        {
            SetConfigString(key, val.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        public static void SetConfigString(string key, double val)
        {
            SetConfigString(key, val.ToString());
        }

        #endregion

        #region METHOD: RemoveConfigString
        /// <summary>
        /// Removes the given key and its value from the config table.
        /// </summary>
        public static void RemoveConfigString(string key)
        {
            string sql = string.Format(" delete from config where KeyString = '{0}' ", key);
            ExecuteNonQuery(sql);

        }
        #endregion

        #region METHOD: GetLangString
        /// <summary>
        /// Returns the string for the given id. This string is localized
        /// according to the InitLangStrings method. Cached data.
        /// </summary>
        /// <param name="id">The id used to look up the string in the lang table</param>
        /// <returns>A localized string, empty if id not found. Null if database not initialized.</returns>
        public static string GetLangString(string id)
        {
            if (!initialized) return null;
            if (langStrings == null) return "";
            if (langStrings.ContainsKey(id))
                return langStrings[id].ToString();
            else
            {
                System.Windows.Forms.MessageBox.Show("Error: GetLangString can't find string for id: " + id);
                return "";
            }
        }
        #endregion

        #region METHOD: GetFavorites
        /// <summary>
        /// Loads all favorites from the database
        /// </summary>
        /// <returns>Favorites returned as a TreeNode array</returns>
        public static TreeNode[] GetFavorites()
        {
            try
            {
                ArrayList list = new ArrayList();

                // first get all favorite strings from the database
                DataTable table = GetDataTable("select * from favorites");
                foreach (DataRow row in table.Rows)
                {
                    TreeNode n = new TreeNode(
                        GetLangString(row["ID"].ToString()), // get the localized node text
                        int.Parse(row["ImageIndex"].ToString()),
                        int.Parse(row["ImageIndexSelected"].ToString()));
                    n.Tag = row["ID"].ToString();
                    list.Add(n);
                }


                // convert the string list to an array of TreeNodes
                TreeNode[] nodes = new TreeNode[list.Count];
                for (int i = 0; i < list.Count; i++)
                    nodes[i] = (TreeNode)list[i];

                // return array of TreeNodes
                return nodes;
            }
            catch (Exception e) { throw (e); }
        }
        #endregion

        #region METHOD: SetFavorites
        /// <summary>
        /// Save the favorites to the database. Placed here as it can be used all over.
        /// </summary>
        /// <param name="nodes">The favorites treeview nodes</param>
        public static void SetFavorites(TreeNodeCollection nodes)
        {
            // first delete all favorites from the database, then
            // traverse the list of nodes, inserting each node into the database
            ExecuteNonQuery("delete from favorites");
            foreach (TreeNode node in nodes)
            {
                string sql = String.Format("insert into favorites (ID,ImageIndex,ImageIndexSelected) values ('{0}','{1}',{2})", node.Tag, node.ImageIndex, node.SelectedImageIndex);
                try { ExecuteNonQuery(sql); }
                catch (Exception) { }
            }
        }
        #endregion

        #region METHOD: DataSet2SortedList
        /// <summary>
        /// Internal helper method that converts a DataSet to a SortedList. The dataset
        /// must contain a key field and a value field
        /// </summary>
        /// <param name="ds">The dataset to convert</param>
        /// <param name="keyField">The key field that uniquely identifies a key-value pair</param>
        /// <param name="valueField">The value field</param>
        /// <returns>A key-value list. Null if database not initialized</returns>
        private static SortedList DataSet2SortedList(DataTable table, string keyField, string valueField)
        {
            if (!initialized) return null;
            SortedList list = new SortedList(table.Rows.Count);
            foreach (DataRow row in table.Rows)
            {
                if ((row.RowState != DataRowState.Deleted) &&
                    (row.RowState != DataRowState.Detached))
                    list.Add(row[keyField].ToString(), row[valueField]);
            }
            return list;
        }
        #endregion

        #region GetNextItemTransactionID
        /// <summary>
        /// Gets the next ItemTransactionID + 1 from config table.
        /// This is used when writing ItemTransaction/ItemTransactionRBA lines.
        /// </summary>
        /// <param name="writeBack">
        /// If true, the incremented value s written back to 
        /// the database, which is what you usually would do.
        /// </param>
        /// <returns>The next incremented ItemTransactionID.</returns>
        public static long GetNextItemTransactionID(bool writeBack)
        {
            string s = dbOleDb.GetConfigString("ItemTransactionID");
            if (s == "") s = "0";
            long i = long.Parse(s) + 1;
            if (writeBack)
                dbOleDb.SetConfigString("ItemTransactionID", i.ToString());
            return i;
        }
        #endregion

        #region GetNextItemTransactionIDStockCountRBA
        /// <summary>
        /// Gets the next ItemTransactionIDStockCount + 1 from config table.
        /// This is used when writing ItemTransactionStockCountRBA lines.
        /// </summary>
        /// <param name="writeBack">
        /// If true, the incremented value s written back to 
        /// the database, which is what you usually would do.
        /// </param>
        /// <returns>The next incremented ItemTransactionIDStockCountRBA.</returns>
        public static long GetNextItemTransactionIDStockCountRBA(bool writeBack)
        {
            long i = dbOleDb.GetConfigStringAsInt("ItemTransactionIDStockCountRBA") + 1;
            if (writeBack)
                dbOleDb.SetConfigString("ItemTransactionIDStockCountRBA", i);
            return i;
        }
        #endregion

        #region GetNextItemTransactionIDForbrugsvare
        /// <summary>
        /// Gets the next ItemTransactionIDForbrugsvare + 1 from config table.
        /// This is used when writing ItemTransactionForbrugsvare lines.
        /// </summary>
        /// <param name="writeBack">
        /// If true, the incremented value s written back to 
        /// the database, which is what you usually would do.
        /// </param>
        /// <returns>The next incremented ItemTransactionIDForbrugsvare.</returns>
        public static long GetNextItemTransactionIDForbrugsvare(bool writeBack)
        {
            long i = dbOleDb.GetConfigStringAsInt("ItemTransactionIDForbrugsvare") + 1;
            if (writeBack)
                dbOleDb.SetConfigString("ItemTransactionIDForbrugsvare", i);
            return i;
        }
        #endregion
    }
}
