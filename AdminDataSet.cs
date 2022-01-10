using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System;

namespace RBOS
{


    partial class AdminDataSet
    {

        partial class favoritesDataTable
        {
            public static void EmptyTable()
            {
                db.ExecuteNonQuery("delete from favorites");
            }
        }

        #region Partial class ACNExportHistoryDataTable
        partial class ACNExportHistoryDataTable
        {
            public enum Status
            {
                Not_Set = 0,
                Export_Ok = 1,
                RPOS_Headers_Missing = 2,
                RPOS_ISM_Data_Missing = 3,
                ACN_Export_Disabled = 4
            }

            #region GetLastOkWeek
            public static bool GetLastOkWeek(out int Year, out int Week)
            {
                DataRow row = db.GetDataRow(string.Format(
                    " select top 1 AYear, AWeek " +
                    " from ACNExportHistory " +
                    " where (Status = {0}) " +
                    " order by AYear desc, AWeek desc ",
                    (int)Status.Export_Ok));
                if (row != null)
                {
                    Year = tools.object2int(row["AYear"]);
                    Week = tools.object2int(row["AWeek"]);
                    return true;
                }
                else
                {
                    Year = 0;
                    Week = 0;
                    return false;
                }
            }
            #endregion

            #region SetWeekStatus
            /// <summary>
            /// Sets the week's status.
            /// True is returned if the status could be set,
            /// false if not. The status is only set if:
            /// 1. The week is not already in the history table, or
            /// 2. The status is being set from not-ok to ok.
            /// </summary>
            public static bool SetWeekStatus(DateTime Sunday, Status status)
            {
                // convert from datetime to year/week
                int Year, Week;
                tools.GetISOWeekNumberFromDate(Sunday, out Year, out Week);

                // attempt to get existing week in history
                DataRow row = db.GetDataRow(string.Format(
                    " select * from ACNExportHistory " +
                    " where (AYear = {0}) and (AWeek = {1}) ",
                    Year, Week));

                // check if the week already exist in the history
                if (row != null)
                {
                    // week already exist in history, now check
                    // if we are going from not-ok to ok status
                    if ((status == Status.Export_Ok) &&
                        (tools.object2int(row["Status"]) != (int)Status.Export_Ok))
                    {
                        // we are going from not-ok to ok status on the week
                        db.ExecuteNonQuery(string.Format(
                            " update ACNExportHistory set " +
                            " Status = {0}, " +
                            " SystemDate = cdate('{1}') " +
                            " where (AYear = {2}) and (AWeek = {3}) ",
                            (int)status, DateTime.Now, Year, Week));

                        // setting week status was allowed
                        return true;
                    }
                }
                else
                {
                    // week does not already exist in history
                    db.ExecuteNonQuery(string.Format(
                        " insert into ACNExportHistory " +
                        " (AYear, AWeek, Status, SystemDate) " +
                        " values ({0},{1},{2},'{3}') ",
                        Year, Week, (int)status, DateTime.Now));

                    // setting week status was allowed
                    return true;
                }

                // setting week status was not allowed
                return false;
            }
            #endregion

            #region GetFirstSundayNotInHistory
            /// <summary>
            /// Gets the first sunday not in ACNExportHistory table.
            /// If something goes wrong, DateTime.MinValue is returned.
            /// </summary>
            public static DateTime GetFirstSundayNotInHistory()
            {
                /// usually we use DateTime.MinValue as fallback value for datetimes
                /// but here it could mean that a pretty large amount of ACN files
                /// would be generated if the program had to run from 1-1-1001 to
                /// the most recent calendar sunday. so we just set the first sunday of 2006.
                DateTime FallBackDate = new DateTime(2006, 1, 1);

                DataTable table = db.GetDataTable(" select * from ACNExportHistory ");
                if (table.Rows.Count > 0)
                {
                    int Year = tools.object2int(table.Rows[table.Rows.Count - 1]["AYear"]);
                    int Week = tools.object2int(table.Rows[table.Rows.Count - 1]["AWeek"]);
                    if ((Year != 0) && (Week != 0))
                        return tools.GetDateFromISOWeekNumber(Year, Week, DayOfWeek.Sunday).AddDays(7);
                    else
                        return FallBackDate;
                }
                else
                    return FallBackDate;
            }
            #endregion

            #region GetHistoryNotOk
            /// <summary>
            /// Returns records from ACNExportHistory
            /// where status is not Ok.
            /// </summary>
            public static DataTable GetHistoryNotOk()
            {
                return db.GetDataTable(string.Format(
                    " select * from ACNExportHistory " +
                    " where (Status <> {0}) ",
                    (int)Status.Export_Ok));
            }
            #endregion


        }
        #endregion

        #region Partial class TreeviewProhibitionsDataTable
        partial class TreeviewProhibitionsDataTable
        {
            #region SetAccessRights
            public static void SetAccessRights(string MenuEntryID, AdminDataSet.UserProfilesDataTable.ProfileID UserProfileID, bool HasAccess)
            {
                // if user already exists in the prohibitions table,
                // remove user so we can make an insert, and if user
                // does not have access, he/she is now removed from
                // the prohibitions table.
                db.ExecuteNonQuery(string.Format(
                    " delete from TreeviewProhibitions " +
                    " where (EntryID = {0}) " +
                    " and (ProfileIDProhibited = {1}) ",
                    tools.string4sql(MenuEntryID, 50),
                    (int)UserProfileID));

                // insert user in prohibitions table
                if (!HasAccess)
                {
                    db.ExecuteNonQuery(string.Format(
                        " insert into TreeviewProhibitions " +
                        " (EntryID,ProfileIDProhibited) " +
                        " values ({0},{1}) ",
                        tools.string4sql(MenuEntryID, 50),
                        (int)UserProfileID));
                }
            }
            #endregion

            #region RestrictAccessToTreeNodes
            /// <summary>
            /// Restricts access to the treemenu in the application.
            /// Pass in the root node of the treemenu. When a node
            /// is restricted, all subnodes of that nodes are restricted too.
            /// </summary>
            public static void RestrictAccessToTreeNodes(TreeNode Node)
            {
                // if this node is prohibited or if it's parent is prohobited
                // disable the node and change to greyscale images
                if (TreeviewEntryProhibited(Node.Tag.ToString()) ||
                    ((Node.Parent != null) && (Node.Parent.Tag.Equals(""))))
                {
                    Node.Tag = ""; // disable entry action

                    // greyscale entry image
                    if (Node.ImageIndex == 0)
                    {
                        // folder closed
                        Node.ImageIndex = 7;
                        Node.SelectedImageIndex = 7;
                    }
                    else if (Node.ImageIndex == 1)
                    {
                        // folder open
                        Node.ImageIndex = 8;
                        Node.SelectedImageIndex = 8;
                    }
                    else if (Node.ImageIndex == 4)
                    {
                        // window
                        Node.ImageIndex = 9;
                        Node.SelectedImageIndex = 9;
                    }
                    else if (Node.ImageIndex == 5)
                    {
                        // print
                        Node.ImageIndex = 10;
                        Node.SelectedImageIndex = 10;
                    }
                    else if (Node.ImageIndex == 6)
                    {
                        // print folder
                        Node.ImageIndex = 11;
                        Node.SelectedImageIndex = 11;
                    }
                }

                // now we process this node's children
                foreach (TreeNode n in Node.Nodes)
                    RestrictAccessToTreeNodes(n);
            }
            #endregion

            #region TreeviewEntryProhibited
            /// <summary>
            /// Returns true if the given EntryID (treeview tag)
            /// is prohibited for the logged on user.
            /// False is returned if user has access.
            /// </summary>
            /// <param name="EntryID">The treeview node's Tag.</param>
            public static bool TreeviewEntryProhibited(string EntryID)
            {
                int x = tools.object2int(db.ExecuteScalar(string.Format(
                    " select count(*) from TreeviewProhibitions " +
                    " where (EntryID = '{0}') " +
                    " and (ProfileIDProhibited = {1}) ",
                    EntryID, (int)UserLogon.ProfileID)));

                return x > 0;
            }
            #endregion
        }
        #endregion

        #region Partial class UserProfilesDataTable
        partial class UserProfilesDataTable
        {
            #region ProfileID
            /// <summary>
            /// Represents the values in table UserProfiles
            /// </summary>
            public enum ProfileID
            {
                invalid = -1,
                drs = 0,
                support = 1,
                admin = 2,
                daglig = 3,
                assistent = 4
            }
            #endregion
        }
        #endregion

        #region Partial class UsersDataTable
        partial class UsersDataTable
        {
            #region HowManyAdmins
            /// <summary>
            /// Checks in-memory how many admins exists in table Users.
            /// </summary>
            /// <param name="InMemoryDataTable"></param>
            public int HowManyAdmins()
            {
                string filter = string.Format(" ProfileID = {0} ", (int)UserProfilesDataTable.ProfileID.admin);
                return this.Select(filter).Length;
            }
            #endregion

            #region UsernameAlreadyExists
            /// <summary>
            /// Checks in-memory wheather a user exists with that username.
            /// </summary>
            public bool UsernameAlreadyExists(string Username)
            {
                string filter = string.Format(" Username = '{0}' ", Username);
                return (this.Select(filter).Length > 0);
            }
            #endregion

            #region ValidUsernameOrPassword
            public static bool ValidUsernameOrPassword(string s)
            {
                Regex regex = new Regex("^(([0-9a-zA-ZæøåÆØÅ])+)$");
                return regex.IsMatch(s);
            }
            #endregion
        }
        #endregion

        #region Partial class SiteInformationDataTable
        /// <summary>
        /// Custom code for the SiteInformation table.
        /// </summary>
        partial class SiteInformationDataTable
        {
            public static string GetSiteCode()
            {
                OleDbCommand cmd = new OleDbCommand("select SiteCode from SiteInformation", db.Connection);
                cmd.Transaction = db.CurrentTransaction;
                return tools.object2string(cmd.ExecuteScalar());
            }

            public static string GetSE()
            {
                OleDbCommand cmd = new OleDbCommand("select SE from SiteInformation", db.Connection);
                return tools.object2string(cmd.ExecuteScalar());
            }

            public static string GetSiteName()
            {
                OleDbCommand cmd = new OleDbCommand("select SiteName from SiteInformation", db.Connection);
                return tools.object2string(cmd.ExecuteScalar());
            }

            public static string GetNorddataKundenr()
            {
                OleDbCommand cmd = new OleDbCommand("select NorddataKundenr from SiteInformation", db.Connection);
                return tools.object2string(cmd.ExecuteScalar());
            }

            public static string GetBankAccount()
            {
                OleDbCommand cmd = new OleDbCommand("select BankAccount from SiteInformation", db.Connection);
                return tools.object2string(cmd.ExecuteScalar());
            }
            public static int GetEconomicsContractID()
            {
                OleDbCommand cmd = new OleDbCommand("select EconomicsAftaleID from SiteInformation", db.Connection);
                return tools.object2int(cmd.ExecuteScalar());
            }
            public static string GetEconomicsUserID()
            {
                OleDbCommand cmd = new OleDbCommand("select EconomicsUserID from SiteInformation", db.Connection);
                return tools.object2string(cmd.ExecuteScalar());
            }
            public static string GetEconomicsUserPassword()
            {
                OleDbCommand cmd = new OleDbCommand("select EconomicsUserPassword from SiteInformation", db.Connection);
                return tools.object2string(cmd.ExecuteScalar());
            }

            public static void SetSiteCode(string SiteCode)
            {
                db.ExecuteNonQuery(string.Format("update SiteInformation set SiteCode = {0}",
                    tools.string4sql(SiteCode, 4)));
            }

            public static void SetAddress1(string Address1)
            {
                db.ExecuteNonQuery(string.Format("update SiteInformation set Adress1 = {0}",
                    tools.string4sql(Address1, 50)));
            }

            public static void SetAddress2(string Address2)
            {
                db.ExecuteNonQuery(string.Format("update SiteInformation set Adress2 = {0}",
                    tools.string4sql(Address2, 50)));
            }

            public static void SetZipCode(string ZipCode)
            {
                db.ExecuteNonQuery(string.Format("update SiteInformation set ZipCode = {0}",
                    tools.string4sql(ZipCode, 10)));
            }

            public static void SetCity(string City)
            {
                db.ExecuteNonQuery(string.Format("update SiteInformation set City = {0}",
                    tools.string4sql(City, 50)));
            }

            public static void SetTelephone(string Telephone)
            {
                db.ExecuteNonQuery(string.Format("update SiteInformation set Telephone = {0}",
                    tools.string4sql(Telephone, 10)));
            }

            public static void SetFaxNo(string FaxNo)
            {
                db.ExecuteNonQuery(string.Format("update SiteInformation set FaxNo = {0}",
                    tools.string4sql(FaxNo, 10)));
            }
        }
        #endregion

        #region Partial class FTPAccountsDataTable
        partial class FTPAccountsDataTable
        {
            /// <summary>
            /// Returns the FTPAccount record with the given ID or null if not found.
            /// </summary>
            /// <param name="ID">The ID column in table FTPAccounts.</param>
            public static DataRow GetFTPAccount(int ID)
            {
                string sql = " select * from FTPAccounts where ID = " + ID.ToString();
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, db.Connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                    return table.Rows[0];
                else
                    return null;
            }

            /// <summary>
            /// Returns the FTPAccount record with the given ID or null if not found.
            /// </summary>
            /// <param name="AccountName">The AccountName column (unique) in table FTPAccounts.</param>
            public static DataRow GetFTPAccount(string AccountName)
            {
                //string sql = " select * from FTPAccounts where AccountName = \"" + AccountName.ToString() + "\"";
                string sql = " select * from FTPAccounts where AccountName =  '" + AccountName.ToString() + "'";
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, db.Connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                    return table.Rows[0];
                else
                    return null;
            }
        }
        #endregion

        #region Partial class ACNExportHistoryNewDataTable
        partial class ACNExportHistoryNewDataTable
        {
            public enum Status
            {
                Not_Set = 0,
                Export_Ok = 1,
                RPOS_Headers_Missing = 2,
                RPOS_ISM_Data_Missing = 3,
                ACN_Export_Disabled = 4
            }

            #region GetLastOkWeek
            public static bool GetLastOkWeek(out int Year, out int Week)
            {
                DataRow row = db.GetDataRow(string.Format(
                    " select top 1 AYear, AWeek " +
                    " from ACNExportHistory_New " +
                    " where (Status = {0}) " +
                    " order by AYear desc, AWeek desc ",
                    (int)Status.Export_Ok));
                if (row != null)
                {
                    Year = tools.object2int(row["AYear"]);
                    Week = tools.object2int(row["AWeek"]);
                    return true;
                }
                else
                {
                    Year = 0;
                    Week = 0;
                    return false;
                }
            }
            #endregion

            #region SetWeekStatus
            /// <summary>
            /// Sets the week's status.
            /// True is returned if the status could be set,
            /// false if not. The status is only set if:
            /// 1. The week is not already in the history table, or
            /// 2. The status is being set from not-ok to ok.
            /// </summary>
            public static bool SetWeekStatus(DateTime Saturday, Status status)
            {
                // convert from datetime to year/week
                int Year, Week;
                tools.GetISOWeekNumberFromDate(Saturday, out Year, out Week);

                // attempt to get existing week in history
                DataRow row = db.GetDataRow(string.Format(
                    " select * from ACNExportHistory_New " +
                    " where (AYear = {0}) and (AWeek = {1}) ",
                    Year, Week));

                // check if the week already exist in the history
                if (row != null)
                {
                    // week already exist in history, now check
                    // if we are going from not-ok to ok status
                    if ((status == Status.Export_Ok) &&
                        (tools.object2int(row["Status"]) != (int)Status.Export_Ok))
                    {
                        // we are going from not-ok to ok status on the week
                        db.ExecuteNonQuery(string.Format(
                            " update ACNExportHistory_New set " +
                            " Status = {0}, " +
                            " SystemDate = '{1}' " +
                            " where (AYear = {2}) and (AWeek = {3}) ",
                            (int)status, DateTime.Now, Year, Week));

                        // setting week status was allowed
                        return true;
                    }
                }
                else
                {
                    // week does not already exist in history
                    db.ExecuteNonQuery(string.Format(
                        " insert into ACNExportHistory_New " +
                        " (AYear, AWeek, Status, SystemDate) " +
                        " values ({0},{1},{2},'{3}') ",
                        Year, Week, (int)status, DateTime.Now));

                    // setting week status was allowed
                    return true;
                }

                // setting week status was not allowed
                return false;
            }
            #endregion

            #region GetFirstSaturdayNotInHistory
            /// <summary>
            /// Gets the first saturday not in ACNExportHistory_New table.
            /// If something goes wrong, DateTime.MinValue is returned.
            /// </summary>
            public static DateTime GetFirstSaturdayNotInHistory()
            {
                /// usually we use DateTime.MinValue as fallback value for datetimes
                /// but here it could mean that a pretty large amount of ACN files
                /// would be generated if the program had to run from 1-1-1001 to
                /// the most recent calendar sunday. so we just set the first saturday of 2013.
                DateTime FallBackDate = new DateTime(2013, 1, 5);

                DataTable table = db.GetDataTable(" select * from ACNExportHistory_New ");
                if (table.Rows.Count > 0)
                {
                    int Year = tools.object2int(table.Rows[table.Rows.Count - 1]["AYear"]);
                    int Week = tools.object2int(table.Rows[table.Rows.Count - 1]["AWeek"]);
                    if ((Year != 0) && (Week != 0))
                        return tools.GetDateFromISOWeekNumber(Year, Week, DayOfWeek.Saturday).AddDays(7);
                    else
                        return FallBackDate;
                }
                else
                    return FallBackDate;
            }
            #endregion

            #region GetHistoryNotOk
            /// <summary>
            /// Returns records from ACNExportHistory
            /// where status is not Ok.
            /// </summary>
            public static DataTable GetHistoryNotOk()
            {
                return db.GetDataTable(string.Format(
                    " select * from ACNExportHistory_New " +
                    " where (Status <> {0}) ",
                    (int)Status.Export_Ok));
            }
            #endregion


        }
        #endregion
    }
}

namespace RBOS.AdminDataSetTableAdapters
{
    partial class UserProfilesTableAdapter
    {
    }

    partial class FTPAccountsTableAdapter
    {
    }

    public partial class SiteInformationTableAdapter {
    }
}
