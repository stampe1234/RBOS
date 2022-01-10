using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RBOS
{
    /// <summary>
    /// Provides access to the CentralRBOS database using SQL Client.
    /// </summary>
    class dbCentralRBOS
    {
        #region ConnectionString
        private static string _ConnectionString;
        public static string ConnectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }
        #endregion

        #region GetConfigString
        public static string GetConfigString(string Key)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetConfigValue", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("KeyString", SqlDbType.NVarChar).Value = Key;
                    cmd.Parameters.Add("ValueString", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return tools.object2string(cmd.Parameters["ValueString"].Value);
                }
            }
        }
        #endregion

        #region GetConfigStringAsInteger
        public static int GetConfigStringAsInteger(string Key)
        {
            return tools.object2int(GetConfigString(Key));
        }
        #endregion
    }
}
