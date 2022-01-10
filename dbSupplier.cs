using System;
using System.Data;
using System.Collections;
using System.Text;
using System.Data.OleDb;

namespace RBOS
{
	/// <summary>
	/// A collection of static methods and properties related to
	/// suppliers in the system. For more general database items, use db.
	/// This class makes use of the methods and properties in the db class,
	/// thus the Initialize method must be called on db before using this class.
	/// </summary>
	public class dbSupplier
	{
		// protected constructor to avoid instantiation
		protected dbSupplier()
		{
		}

		/// <summary>
		/// Returns a list of supplier IDs ordered by the supplier's Description in database
		/// </summary>
 		public static ArrayList GetSupplierIDs()
		{
			if(!db.Initialized) return null;
			ArrayList list = new ArrayList();
            DataTable table = db.GetDataTable("select SupplierID from Supplier order by SupplierID");
			foreach(DataRow row in table.Rows)
				list.Add(row["SupplierID"]);
			return list;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public static DataRow GetSupplier(int id)
		{
			if(!db.Initialized) return null;
			DataTable table = db.GetDataTable(String.Format("select * from Supplier where SupplierID = {0}",id));
			if(table.Rows.Count > 0)
				return table.Rows[0];
			else
				return null;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="description"></param>
		/// <param name="contact"></param>
		/// <param name="phone"></param>
		/// <param name="fax"></param>
		/// <returns></returns>
		public static void UpdateSupplier(
			int id,
			string description,
			string contact,
			string phone,
			string fax,
            string sendmode,
            string orderfileformat,
            int ftpaccountid,
            int llsupplierno)
		{
			StringBuilder sql = new StringBuilder();
			sql.Append(" update supplier set ");
			sql.Append(String.Format(" Description = '{0}', ",description));
            sql.Append(String.Format(" Contact = '{0}', ",contact));
			sql.Append(String.Format(" PhoneNumber = '{0}', ",phone.Replace(" ","")));
            sql.Append(String.Format(" FaxNumber = '{0}', ", fax.Replace(" ", "")));
            sql.Append(String.Format(" SendMode = '{0}', ", sendmode));
            sql.Append(String.Format(" OrderFileFormat = '{0}', ", orderfileformat));
            sql.Append(String.Format(" FTPAccountID = {0}, ", ftpaccountid));
            sql.Append(String.Format(" LLSupplierNo = {0} ", llsupplierno));
			sql.Append(String.Format(" where supplierID = {0} ",id.ToString()));
			db.ExecuteNonQuery(sql.ToString());
		}

		/// <summary>
		/// Returns if a supplier with the given id already exist in the base
		/// </summary>
		/// <param name="id">The supplier id to look for</param>
		/// <returns>True for found, false for not found</returns>
		public static bool SupplierExists(int id)
		{
			DataTable table = db.GetDataTable(String.Format("select * from supplier where SupplierID = {0}",id.ToString()));
			return (table.Rows.Count > 0);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="description"></param>
		/// <param name="contact"></param>
		/// <param name="phone"></param>
		/// <param name="fax"></param>
		public static void NewSupplier(
			int id,
			string description,
			string contact,
			string phone,
			string fax,
            string sendmode,
            string orderfileformat,
            int ftpaccountid,
            int llsupplierno)
		{
			StringBuilder sql = new StringBuilder();
			sql.Append(" insert into supplier (SupplierID, Description,Contact,PhoneNumber,FaxNumber,SendMode,OrderFileFormat,FTPAccountID,LLSupplierNo) values ");
            sql.Append(String.Format(
                " ({0},'{1}','{2}','{3}','{4}','{5}','{6}',{7},{8}) ",
                id.ToString(),
                description,
                contact,
                phone.Replace(" ", ""),
                fax.Replace(" ", ""),
                sendmode,
                orderfileformat,
                ftpaccountid,
                llsupplierno));
			db.ExecuteNonQuery(sql.ToString());
		}

		/// <summary>
		/// Deletes the supplier from the database.
		/// Note that the GUI must ask user for ok, as this
		/// method assumes that deletion is approved and does not ask.
		/// </summary>
		/// <param name="id"></param>
		public static void DeleteSupplier(int id)
		{
			string sql = String.Format("delete from supplier where SupplierID = {0}",id.ToString());
			db.ExecuteNonQuery(sql);
		}

        #region GetSupplierID
        /// <summary>
        /// Gets the SupplierID that has the given LLSupplierNo.
        /// If no supplier is found, the default supplier is returned,
        /// which is 4 Lekkerland.
        /// </summary>
        public static int GetSupplierID(int LLSupplierNo)
        {
            int DefaultSupplierID = 4; // Lekkerland

            if (LLSupplierNo == 0)
                return DefaultSupplierID;

            int SupplierID = tools.object2int(db.ExecuteScalar(string.Format(
                " select SupplierID " +
                " from Supplier " +
                " where LLSupplierNo = {0} ",
                LLSupplierNo)));

            if (SupplierID != 0)
                return SupplierID;
            else
                return DefaultSupplierID;
        }
        #endregion
	}
}
