using System.Data;
using System.Data.OleDb;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RBOS.EODDataSetTableAdapters
{
    partial class EODReconcileExTableAdapter
    {
    }

    partial class EOD_DebtorTableAdapter
    {
    }

    partial class EODReconcileTableAdapter
    {
    }

    partial class EOD_Debtor_TransReportDetailsTableAdapter
    {
    }

    partial class EOD_Debtor_TransReportHeaderTableAdapter
    {
    }

    partial class EOD_DiscountsTableAdapter
    {
      
    }

    partial class EOD_ShellCardsTableAdapter
    {

    }

    partial class EODReconcileSingleTableAdapter
    {
    }

    partial class EOD_BankDepTableAdapter
    {
    }

    public partial class EOD_SafePay_DepotbeholdningTableAdapter
    {
        /// <summary>
        /// Custom property for getting the InsertCommand.
        /// </summary>
        public OleDbCommand InsertCommand
        {
            get { return this._adapter.InsertCommand; }
        }
    }

    public partial class EOD_SafePay_OverfoerselTilSPTableAdapter
    {
        /// <summary>
        /// Custom property for getting the InsertCommand.
        /// </summary>
        public OleDbCommand InsertCommand
        {
            get { return this._adapter.InsertCommand; }
        }
    }

    public partial class EOD_SafePay_UdbetalingerTableAdapter
    {
        /// <summary>
        /// Custom property for getting the InsertCommand.
        /// </summary>
        public OleDbCommand InsertCommand
        {
            get { return this._adapter.InsertCommand; }
        }
    }

    public partial class EOD_SafePay_IndbetalingerTableAdapter
    {
        /// <summary>
        /// Custom property for getting the InsertCommand.
        /// </summary>
        public OleDbCommand InsertCommand
        {
            get { return this._adapter.InsertCommand; }
        }
    }
}

namespace RBOS
{

    public enum TransTypeLocalCred
    {
        LocalCredit = 1,
        LocalCreditPayin = 2,
        LocalCreditManual = 3
    }

    public enum TransTypeSales
    {
        POSSales = 1,
        ManualSales = 2
    }

    public enum TransTypePayinPayout
    {
        Payin = 1,
        Payout = 2
    }

    partial class EODDataSet
    {
        partial class EOD_Debtor_TransReportDetailsDataTable
        {
        }

        partial class EOD_Debtor_TransReportHeaderDataTable
        {
        }

        partial class EOD_DiscountsDataTable
        {
            public static double GetTotalDiscountsAmount(DateTime BookDate)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select sum(Amount) " +
                    " from EOD_Discounts " +
                    " where BookDate = '{0}' ",
                    BookDate));
                return tools.object2double(total);
            }

            public static int GetDiscountsRowCount(DateTime BookDate)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select count(*) " +
                    " from EOD_Discounts " +
                    " where BookDate = '{0}' ",
                    BookDate));
                return tools.object2int(total);
            }
        }

        partial class EOD_ShellCardsDataTable
        {

            public static double GetTotalShellCardsAmount(DateTime BookDate)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select sum(Amount) " +
                    " from EOD_ShellCards " +
                    " where BookDate = '{0}' ",
                    BookDate));
                return tools.object2double(total);
            }

            public static int GetShellCardsRowCount(DateTime BookDate)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select count(*) " +
                    " from EOD_ShellCards " +
                    " where BookDate = '{0}' ",
                    BookDate));
                return tools.object2int(total);
            }

            /// <summary>
            /// Gets the next lineno for the currently loaded table data.
            /// Non-static method that works with in-memory data.
            /// </summary>
            public int GetNextLineNo()
            {
                int highest = 0;
                foreach (DataRow row in this.Rows)
                {
                    if ((row.RowState != DataRowState.Deleted) &&
                        (row.RowState != DataRowState.Detached))
                    {
                        int currLineNo = tools.object2int(row["LineNo"]);
                        if (currLineNo > highest)
                            highest = currLineNo;
                    }
                }
                return highest + 1;
            }

            /// <summary>
            /// Gets the next lineno for the given BookDate.
            /// Static method that works with on-disk data.
            /// </summary>
            public static int GetNextLineNo(DateTime BookDate)
            {
                object o = db.ExecuteScalar(string.Format(
                    " select max([LineNo]) " +
                    " from EOD_ShellCards " +
                    " where BookDate = '{0}' ",
                    BookDate));
                return tools.object2int(o) + 1;
            }

        }

        partial class EOD_BankDepDataTable
        {
            public static double GetTotalBankDepAmount(DateTime BookDate)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select sum(Amount) " +
                    " from EOD_BankDep " +
                    " where BookDate = '{0}' ",
                    BookDate));
                return tools.object2double(total);
            }

            public static int GetBankDepRowCount(DateTime BookDate)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select count(*) " +
                    " from EOD_BankDep " +
                    " where BookDate = '{0}' ",
                    BookDate));
                return tools.object2int(total);
            }

            #region GetNextLineNo (2 overloads)

            public int GetNextLineNo()
            {
                int highest = 0;
                foreach (DataRow row in this.Rows)
                {
                    if ((row.RowState != DataRowState.Deleted) &&
                        (row.RowState != DataRowState.Detached))
                    {
                        int currLineNo = tools.object2int(row["LineNo"]);
                        if (currLineNo > highest)
                            highest = currLineNo;
                    }
                }
                return highest + 1;
            }

            /// <summary>
            /// Returns the next lineno per Bookdate.
            /// Static version that works with on-disk data.
            /// </summary>
            public static int GetNextLineNo(DateTime BookDate)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(@"
                    select max(LineNo)
                    from EOD_BankDep
                    where BookDate = '{0}'
                    ", BookDate.Date))) + 1;
            }

            #endregion

            public static void CreateNewRecord(
                DateTime BookDate,
                string Description,
                double Amount)
            {
                BookDate = BookDate.Date;
                int NextLineNo = GetNextLineNo(BookDate);

                db.ExecuteNonQuery(string.Format(@"
                    insert into EOD_BankDep
                    (BookDate,LineNo,Description,Amount)
                    values ({0},{1},{2},{3})
                    ",
                     tools.datetime4sql(BookDate),
                     tools.wholenumber4sql(NextLineNo),
                     tools.string4sql(Description, 25),
                     tools.decimalnumber4sql(Amount)));
            }
        }

        partial class EOD_SafePay_CurrenciesDataTable
        {

            public static double GetTotalSafePayCurrAmount(DateTime BookDate)
            {
                return tools.object2double(db.ExecuteScalar(string.Format(@"
                    select sum(Amount)
                    from EOD_SafePay_Currencies
                    where BookDate = '{0}'
                    ", BookDate.Date)));
            }


            public static int GetSafePayCurrRowCount(DateTime BookDate)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select count(*) " +
                    " from EOD_SafePay_Currencies " +
                    " where BookDate = '{0}' ",
                    BookDate.Date));
                return tools.object2int(total);
            }


        }

        partial class CashierSalesReportDataTable
        {
            public void LoadData(DateTime StartDate, DateTime EndDate, int KampagneID)
            {
                /// As I keep getting wrong data when building everything in a
                /// single SQL statement, i just do it the programming way

                /// It's important to select from DisktilbudSolgt as main data,
                /// as that is what we did before. This way, even if no data has
                /// been collected from CashierSales table yet, we still get the disktilbud.

                // collect CashierID and Disktilbud from DisktilbudSolgt into this table
                string sql = @"
                    select
                     CashierID,
                     sum(Disktilbud) as DisktilbudSum
                    from DisktilbudSolgt
                    where BookDate >= ? and BookDate <= ? {0}
                    group by CashierID
                    ";
                if (KampagneID > 0)
                    sql = string.Format(sql, " and KampagneID = ?");
                else
                    sql = string.Format(sql, "");
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection))
                {
                    cmd.Parameters.Add("StartDate", OleDbType.Date).Value = StartDate.Date;
                    cmd.Parameters.Add("EndDate", OleDbType.Date).Value = EndDate.Date;
                    if (KampagneID > 0)
                        cmd.Parameters.Add("KampagneID", OleDbType.BigInt).Value = KampagneID;
                    db.FillDataTable(cmd, this, true);
                }

                // collect AntalKunder from CashierSales
                DataTable CashierSales;
                sql = @"
                    select
                     CashierID,
                     sum(antalkunder) as AntalKunderSum
                    from CashierSales
                    where BookDate >= ? and BookDate <= ?
                    group by CashierID
                    ";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection))
                {
                    cmd.Parameters.Add("StartDate", OleDbType.Date).Value = StartDate.Date;
                    cmd.Parameters.Add("EndDate", OleDbType.Date).Value = EndDate.Date;
                    CashierSales = db.GetDataTable(cmd);
                }

                // merge AntalKunder into this table
                foreach (DataRow csrRow in this.Rows)
                {
                    int CashierID = tools.object2int(csrRow["CashierID"]);
                    double Disktilbud = tools.object2double(csrRow["DisktilbudSum"]);
                    DataRow[] csRows = CashierSales.Select(string.Format("CashierID  = {0}", CashierID));
                    if (csRows.Length > 0)
                    {
                        int AntalKunder = tools.object2int(csRows[0]["AntalKunderSum"]);
                        csrRow["AntalKunderSum"] = AntalKunder;

                        // while we are here, calculate percentage
                        csrRow["DisktilbudProcent"] = (Disktilbud / AntalKunder) * 100;
                    }
                }
            }
        }

        partial class DisktilbudHistorikDataTable
        {
            public static void CreateRecord(int ItemID, int FSD_ID, DateTime FraDato, DateTime TilDato, int Threshold, int KampagneID, OleDbTransaction Transaction)
            {
                // validér data
                if (ItemID <= 0) return;
                if (FSD_ID <= 0) return;
                if (FraDato == DateTime.MinValue) return;
                if (TilDato == DateTime.MinValue) return;
                if (Threshold <= 0) return;
                if (KampagneID <= 0) return;

                string sql;
                int ExistingID;

                // if the record already exists, get the ID
                sql = @"
                    select ID from DisktilbudHistorik
                    where ItemID = ?
                    and FSD_ID = ?
                    and FraDato = ?
                    and TilDato = ?
                    and Threshold = ?
                    and KampagneID = ?
                    ";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection))
                {
                    cmd.Parameters.Add("ItemID", OleDbType.Integer).Value = ItemID;
                    cmd.Parameters.Add("FSD_ID", OleDbType.Integer).Value = FSD_ID;
                    cmd.Parameters.Add("FraDato", OleDbType.Date).Value = FraDato.Date;
                    cmd.Parameters.Add("TilDato", OleDbType.Date).Value = TilDato.Date;
                    cmd.Parameters.Add("Threshold", OleDbType.Integer).Value = Threshold;
                    cmd.Parameters.Add("KampagneID", OleDbType.Integer).Value = KampagneID;
                    cmd.Transaction = Transaction;
                    ExistingID = tools.object2int(cmd.ExecuteScalar());
                }

                if (ExistingID > 0)
                {
                    // record exists, update the timestamp

                    sql = @"
                        update DisktilbudHistorik set
                        DatoTid = ?
                        where ID = ?
                        ";
                    using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection))
                    {
                        cmd.Parameters.Add("DatoTid", OleDbType.Date).Value = DateTime.Now;
                        cmd.Parameters.Add("ID", OleDbType.Integer).Value = ExistingID;
                        cmd.Transaction = Transaction;
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    // record does not exist, create a new record

                    sql = @"
                    insert into DisktilbudHistorik (ItemID, FSD_ID, FraDato, TilDato, Threshold, KampagneID, DatoTid)
                    values (?,?,?,?,?,?,?)
                    ";
                    using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection))
                    {
                        cmd.Parameters.Add("ItemID", OleDbType.Integer).Value = ItemID;
                        cmd.Parameters.Add("FSD_ID", OleDbType.Integer).Value = FSD_ID;
                        cmd.Parameters.Add("FraDato", OleDbType.Date).Value = FraDato.Date;
                        cmd.Parameters.Add("TilDato", OleDbType.Date).Value = TilDato.Date;
                        cmd.Parameters.Add("Threshold", OleDbType.Integer).Value = Threshold;
                        cmd.Parameters.Add("KampagneID", OleDbType.Integer).Value = KampagneID;
                        cmd.Parameters.Add("DatoTid", OleDbType.Date).Value = DateTime.Now;
                        cmd.Transaction = Transaction;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        partial class DisktilbudSolgtReportDataTable
        {
        }

        partial class CashierDataTable
        {
            /// <summary>
            /// Checks if the CashierID exists in the database and
            /// if not, it creates a record with that CashierID.
            /// </summary>
            public static void AddCashierID(int CashierID)
            {
                using (OleDbConnection conn = new OleDbConnection(db.ConnectionString))
                {
                    conn.Open();

                    // check if the cashier is already in the table, if so, exit the method
                    string sql = "select count(*) from Cashier where CashierID = ?";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.Add("CashierID", OleDbType.Integer).Value = CashierID;
                        if (tools.object2int(cmd.ExecuteScalar()) > 0)
                            return;
                    }

                    // cashier does not exist, add it
                    sql = "insert into Cashier (CashierID) values (?)";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.Add("CashierID", OleDbType.Integer).Value = CashierID;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        partial class CashierSalesDataTable
        {
            /// <summary>
            /// Deletes all records from table CashierSales
            /// where the bookdate is the given date.
            /// </summary>
            /// <param name="BookDate"></param>
            public static void ClearBookDate(DateTime BookDate)
            {
                /// Could have been made as a query in the dataset designer,
                /// but as we haven't switched to SQL Server yet, I don't want
                /// to make code there that I don't have to.

                using (OleDbConnection conn = new OleDbConnection(db.ConnectionString))
                {
                    string sql = "delete from CashierSales where BookDate = ?";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.Add("BookDate", OleDbType.Date).Value = BookDate.Date;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Serves as a detail table for DisktilbudSolgt.
        /// </summary>
        partial class DisktilbudSolgtDetaljerDataTable
        {
            /// <summary>
            /// Creates a record in table DisktilbudSolgtDetaljer.
            /// </summary>
            /// <param name="DisktilbudID">DisktlibudID from table DisktilbudSolgt.</param>
            /// <param name="ItemID">The item sold.</param>
            /// <param name="Antal">Number of items sold.</param>
            public static void CreateRecord(int DisktilbudID, int ItemID, int Antal)
            {
                using (OleDbConnection conn = new OleDbConnection(db.ConnectionString))
                {
                    string sql = "insert into DisktilbudSolgtDetaljer (DisktilbudID, ItemID, Antal) values (?,?,?)";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.Add("DisktilbudID", OleDbType.Integer).Value = DisktilbudID;
                        cmd.Parameters.Add("ItemID", OleDbType.Integer).Value = ItemID;
                        cmd.Parameters.Add("Antal", OleDbType.Integer).Value = Antal;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        partial class DisktilbudSolgtDataTable
        {
            #region CreateRecord
            /// <summary>
            /// Creates a record in table DisktilbudSolgt.
            /// Returns the autogenerated DisktilbudID for the created record.
            /// </summary>
            /// <param name="TransactionID">TransactionID from PEJ.</param>
            /// <param name="DatoTid">Date and time concatenated from PEJ. Date should always be the same as BookDate.</param>
            /// <param name="CashierID">CashierID from PEJ.</param>
            /// <param name="Disktilbud">Calculated across the KampagneID (can be different items).</param>
            /// <param name="KampagneID"></param>
            /// <param name="BookDate">The date being processed.</param>
            public static int CreateRecord(
                int TransactionID,
                DateTime DatoTid,
                int CashierID,
                int Disktilbud,
                int KampagneID,
                DateTime BookDate)
            {
                using (OleDbConnection conn = new OleDbConnection(db.ConnectionString))
                {
                    conn.Open(); // this time we open it first as it is used more than once

                    int DisktilbudID;
                    string sql = "select max(DisktilbudID) from DisktilbudSolgt";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        DisktilbudID = tools.object2int(cmd.ExecuteScalar()) + 1;
                    }

                    sql = @"
                        insert into DisktilbudSolgt (DisktilbudID, TransactionID, DatoTid, CashierID, Disktilbud, KampagneID, BookDate)
                        values (?,?,?,?,?,?,?)
                    ";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.Add("DisktilbudID", OleDbType.Integer).Value = DisktilbudID;
                        cmd.Parameters.Add("TransactionID", OleDbType.Integer).Value = TransactionID;
                        cmd.Parameters.Add("DatoTid", OleDbType.Date).Value = DatoTid;
                        cmd.Parameters.Add("CashierID", OleDbType.Integer).Value = CashierID;
                        cmd.Parameters.Add("Disktilbud", OleDbType.Integer).Value = Disktilbud;
                        cmd.Parameters.Add("KampagneID", OleDbType.Integer).Value = KampagneID;
                        cmd.Parameters.Add("BookDate", OleDbType.Date).Value = BookDate.Date;
                        cmd.ExecuteNonQuery();
                    }

                    // we also add the CashierID to the Cashier table if it is not already in it
                    CashierDataTable.AddCashierID(CashierID);

                    return DisktilbudID;
                }
            }
            #endregion

            #region ClearDataForThisBookDate
            /// <summary>
            /// Deletes all records from DisktilbudSolgt that
            /// has the given BookDate, and deletes all their
            /// corresponding detail records in DisktilbudSolgtDetaljer.
            /// </summary>
            public static void ClearDataForThisBookDate(DateTime BookDate)
            {
                using (OleDbConnection conn = new OleDbConnection(db.ConnectionString))
                {
                    conn.Open();

                    string sql = "delete from DisktilbudSolgtDetaljer where DisktilbudID in (select DisktilbudID from DisktilbudSolgt where BookDate = ?)";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.Add("BookDate", OleDbType.Date).Value = BookDate.Date;
                        cmd.ExecuteNonQuery();
                    }

                    sql = "delete from DisktilbudSolgt where BookDate = ?";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.Add("BookDate", OleDbType.Date).Value = BookDate.Date;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            #endregion

            #region GetDisktilbudInPeriod
            public static List<int> GetKampagneIDsInPeriod(DateTime StartDate, DateTime EndDate)
            {
                DataTable table;
                using (OleDbConnection conn = new OleDbConnection(db.ConnectionString))
                {
                    string sql = "select distinct KampagneID from DisktilbudSolgt where BookDate >= ? and BookDate <= ? order by KampagneID";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.Add("StartDate", OleDbType.Date).Value = StartDate.Date;
                        cmd.Parameters.Add("EndDate", OleDbType.Date).Value = EndDate.Date;
                        conn.Open();
                        table = db.GetDataTable(cmd);
                    }
                }
                List<int> list = new List<int>();
                foreach (DataRow row in table.Rows)
                {
                    int KampagneID = tools.object2int(row["KampagneID"]);
                    if (!list.Contains(KampagneID))
                        list.Add(KampagneID);
                }
                return list;
            }
            #endregion
        }

        partial class EOD_DETAIL_ValutaDataTable
        {
            public static double GetTotalDETAIL_BeloebDKK(DateTime BookDate)
            {
                return tools.object2double(db.ExecuteScalar(string.Format(@"
                    select sum(BeloebDKK)
                    from EOD_DETAIL_Valuta
                    where BookDate = '{0}'
                    ", BookDate.Date)));
            }

            public static bool HasRecords(DateTime BookDate)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(@"
                    select count(*) from EOD_DETAIL_Valuta
                    where BookDate = '{0}'
                    ", BookDate.Date))) > 0;
            }

            /// <summary>
            /// Creates a new record in the table and if
            /// a record already exists with the same
            /// ValutaISOkode, that record is deleted first.
            /// </summary>
            public static void CreateRecord(
                DateTime BookDate,
                int ValutaISOkode,
                string Valuta,
                double Valutabeloeb,
                double BeloebDKK)
            {
                db.ExecuteNonQuery(string.Format(@"
                    insert into EOD_DETAIL_Valuta
                    (BookDate,LineNo,ValutaISOkode,Valuta,Valutabeloeb,BeloebDKK)
                    values ({0},{1},{2},{3},{4},{5})
                    ",
                     tools.datetime4sql(BookDate.Date),
                     GetNextLineNo(BookDate.Date),
                     ValutaISOkode,
                     tools.string4sql(Valuta, 3),
                     tools.decimalnumber4sql(Valutabeloeb),
                     tools.decimalnumber4sql(BeloebDKK)));
            }

            //            private static bool RecordExists(DateTime BookDate)
            //            {
            //                return tools.object2int(db.ExecuteScalar(string.Format(@"
            //                    select count(*) from EOD_DETAIL_Valuta
            //                    where BookDate = cdate('{0}')
            //                    ", BookDate.Date))) > 0;
            //            }

            /// <summary>
            /// Deletes all records for the given BookDate.
            /// </summary>
            public static void DeleteRecords(DateTime BookDate)
            {
                db.ExecuteNonQuery(string.Format(@"
                    delete from EOD_DETAIL_Valuta
                    where BookDate = '{0}'
                    ", BookDate.Date));
            }

            public static int GetRowCount(DateTime BookDate)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select count(*) " +
                    " from EOD_DETAIL_Valuta " +
                    " where BookDate = '{0}' ",
                    BookDate.Date));
                return tools.object2int(total);
            }

            private static int GetNextLineNo(DateTime BookDate)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(@"
                    select max(LineNo)
                    from EOD_DETAIL_Valuta
                    where BookDate = '{0}'
                    ", BookDate.Date))) + 1;
            }

            protected override void OnColumnChanging(DataColumnChangeEventArgs e)
            {
                if (e.Column != BookDateColumn && e.Column != LineNoColumn)
                {
                    // get the bookdate of the open day
                    DataRow EODReconcileRow = EODReconcileDataTable.GetCurrentOpenDay();
                    DateTime BookDate = DateTime.MinValue;
                    if (EODReconcileRow != null)
                        BookDate = tools.object2datetime(EODReconcileRow["BookDate"]).Date;

                    if (BookDate != DateTime.MinValue)
                    {
                        if (tools.IsNullOrDBNull(e.Row[BookDateColumn]))
                            e.Row[BookDateColumn] = BookDate;
                    }

                    if (tools.IsNullOrDBNull(e.Row[LineNoColumn]))
                        e.Row[LineNoColumn] = GetNextLineNo(BookDate);
                }

                base.OnColumnChanging(e);
            }
        }

        partial class EOD_SafePay_DepotbeholdningDataTable
        {
            public static void UpdateDKKAmountOnCurrentOpenDay()
            {
                // first select all depotbeholding records for the open day
                DataTable depot = db.GetDataTable(@"
                    select * from EOD_SafePay_Depotbeholdning depot
                    where depot.BookDate = (Select reconcile.BookDate from EODReconcile reconcile where reconcile.Closed <> 1)
                    ");

                // for each of those records, update DKKBeloeb
                foreach (DataRow row in depot.Rows)
                {
                    DateTime BookDate = tools.object2datetime(row["BookDate"]);
                    int LineNo = tools.object2int(row["LineNo"]);
                    int ISOKode = tools.object2int(row["ValutaISOkode"]);
                    double ValutaBeloeb = tools.object2double(row["ValutaBeloeb"]);
                    double Kurs = EOD_SafePay_ValutakurserDataTable.GetValutakurs(ISOKode);
                    double DKKBeloeb = ValutaBeloeb * Kurs;
                    db.ExecuteNonQuery(string.Format(
                        "update EOD_SafePay_Depotbeholdning set DKKBeloeb = {0} where BookDate = '{1}' and [LineNo] = {2}",  //pn20191004
                        tools.decimalnumber4sql(DKKBeloeb), BookDate.Date, LineNo));
                }

                // can't seem to get the SQL to work
                //                db.ExecuteNonQuery(@"
                //                    update EOD_SafePay_Depotbeholdning depot set
                //                    depot.DKKBeloeb = ((select kurser.Kurs from EOD_SafePay_Valutakurser kurser where kurser.ISOKode = depot.ValutaISOkode) * depot.ValutaBeloeb)
                //                    where depot.BookDate = (Select reconcile.BookDate from EODReconcile reconcile where reconcile.Closed <> yes)
                //                    ");
            }

            public static int GetRowCount(DateTime BookDate)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select count(*) " +
                    " from EOD_SafePay_Depotbeholdning " +
                    " where BookDate = '{0}'",
                    BookDate.Date));
                return tools.object2int(total);
            }
            public static int GetRowCountValuta(DateTime BookDate)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select count(*) " +
                    " from EOD_SafePay_Depotbeholdning " +
                    " where BookDate = '{0}' AND ValutaISOkode <> 208",
                    BookDate.Date));
                return tools.object2int(total);
            }


            /// <summary>
            /// Returns true if SQL statement was executed, that is, if day is not closed.
            /// </summary>
            public static bool DeleteRecordsIfDayOpen(DateTime BookDate)
            {
                if (EODReconcileDataTable.IsDayClosed(BookDate))
                    return false;
                else
                {
                    db.ExecuteNonQuery(string.Format(@"
                        delete from EOD_SafePay_Depotbeholdning
                        where BookDate = '{0}'
                        ", BookDate.Date));
                    return true;
                }
            }

            /// <summary>
            /// Returns the sum of DKKBeloeb field.
            /// </summary>
            public static double GetTotalAmount(DateTime BookDate)
            {
                return tools.object2double(db.ExecuteScalar(string.Format(@"
                    select sum(DKKBeloeb) from EOD_SafePay_Depotbeholdning
                    where BookDate = '{0}'
                    ", BookDate.Date)));
            }
            public static double GetTotalSafePayCurrAmountDKK(DateTime BookDate)
            {
                return tools.object2double(db.ExecuteScalar(string.Format(@"
                    select sum(ChangeDKK) from EOD_SafePay_Depotbeholdning
                    where BookDate = '{0}' And ValutaISOkode <> {1}
                    ", BookDate.Date, 208)));
            }


        }



        partial class EOD_SafePay_ValutakurserDataTable
        {
            public enum ISOKode { EURO = 978, NOK = 578, SEK = 752, DKK = 208 }

            public static void UpdateValutakurs(ISOKode isokode, double valuta)
            {
                db.ExecuteNonQuery(string.Format(@"
                    update EOD_SafePay_Valutakurser
                    set Kurs = {1}
                    where ISOKode = {0}
                    ", (int)isokode, tools.decimalnumber4sql(valuta)));
            }

            public static double GetValutakurs(ISOKode isokode)
            {
                return GetValutakurs((int)isokode);
            }

            public static double GetValutakurs(int isokode)
            {
                return tools.object2double(db.ExecuteScalar(string.Format(@"
                    select Kurs from EOD_SafePay_Valutakurser
                    where ISOKode = {0}
                    ", (int)isokode)));
            }
        }

        partial class EOD_SafePay_IndbetalingerDataTable
        {
            protected override void OnColumnChanging(DataColumnChangeEventArgs e)
            {
                if (e.Column == TidColumn)
                {
                    /// Whenever user enters a time into the datetime field, we
                    /// substitute the date part with the current open day's bookdate
                    DataRow OpenDayRecord = EODReconcileDataTable.GetCurrentOpenDay();
                    if (OpenDayRecord != null)
                    {
                        TimeSpan ProposedTime = tools.object2datetime(e.ProposedValue).TimeOfDay;
                        DateTime OpenDate = tools.object2datetime(OpenDayRecord["BookDate"]).Date;
                        e.ProposedValue = OpenDate.Add(ProposedTime);
                    }
                }

                if ((e.Column == BeloebColumn && tools.IsNullOrDBNull(e.Row[BeloebColumn])) ||
                    (e.Column == BeskrivelseColumn && tools.IsNullOrDBNull(e.Row[BeskrivelseColumn])))
                {
                    // this is a new row so insert BookDate and LineNo
                    DataRow openday = EODReconcileDataTable.GetCurrentOpenDay();
                    if (openday != null)
                    {
                        e.Row[BookDateColumn] = openday["BookDate"];
                        e.Row[LineNoColumn] = GetNextLineNo();
                    }
                }

                base.OnColumnChanging(e);
            }

            protected int GetNextLineNo()
            {
                int highest = 0;
                foreach (DataRow row in this.Rows)
                {
                    if ((row.RowState != DataRowState.Deleted) &&
                        (row.RowState != DataRowState.Detached))
                    {
                        int currLineNo = tools.object2int(row["LineNo"]);
                        if (currLineNo > highest)
                            highest = currLineNo;
                    }
                }
                return highest + 1;
            }

            public static double GetTotalAmount(DateTime BookDate)
            {
                return tools.object2double(db.ExecuteScalar(string.Format(@"
                    select sum(Beloeb) from EOD_SafePay_Indbetalinger
                    where BookDate = '{0}'"
                    , BookDate.Date)));
            }

            public static int GetRowCount(DateTime BookDate)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select count(*) " +
                    " from EOD_SafePay_Indbetalinger " +
                    " where BookDate = '{0}' ",
                    BookDate.Date));
                return tools.object2int(total);
            }


            /// <summary>
            /// Returns true if SQL statement was executed, that is, if day is not closed.
            /// </summary>
            public static bool DeleteRecordsIfDayOpen(DateTime BookDate)
            {
                if (EODReconcileDataTable.IsDayClosed(BookDate))
                    return false;
                else
                {
                    db.ExecuteNonQuery(string.Format(@"
                        delete from EOD_SafePay_Indbetalinger
                        where BookDate = '{0}'
                        ", BookDate.Date));
                    return true;
                }
            }
        }

        partial class EOD_SafePay_UdbetalingerDataTable
        {
            protected override void OnColumnChanging(DataColumnChangeEventArgs e)
            {
                if (e.Column == TidColumn)
                {
                    /// Whenever user enters a time into the datetime field, we
                    /// substitute the date part with the current open day's bookdate
                    DataRow OpenDayRecord = EODReconcileDataTable.GetCurrentOpenDay();
                    if (OpenDayRecord != null)
                    {
                        TimeSpan ProposedTime = tools.object2datetime(e.ProposedValue).TimeOfDay;
                        DateTime OpenDate = tools.object2datetime(OpenDayRecord["BookDate"]).Date;
                        e.ProposedValue = OpenDate.Add(ProposedTime);
                    }
                }

                if ((e.Column == BeloebColumn && tools.IsNullOrDBNull(e.Row[BeloebColumn])) ||
                    (e.Column == BeskrivelseColumn && tools.IsNullOrDBNull(e.Row[BeskrivelseColumn])))
                {
                    // this is a new row so insert BookDate and LineNo
                    DataRow openday = EODReconcileDataTable.GetCurrentOpenDay();
                    if (openday != null)
                    {
                        e.Row[BookDateColumn] = openday["BookDate"];
                        e.Row[LineNoColumn] = GetNextLineNo();
                    }
                }

                base.OnColumnChanging(e);
            }

            protected int GetNextLineNo()
            {
                int highest = 0;
                foreach (DataRow row in this.Rows)
                {
                    if ((row.RowState != DataRowState.Deleted) &&
                        (row.RowState != DataRowState.Detached))
                    {
                        int currLineNo = tools.object2int(row["LineNo"]);
                        if (currLineNo > highest)
                            highest = currLineNo;
                    }
                }
                return highest + 1;
            }

            public static double GetTotalAmount(DateTime BookDate)
            {
                return tools.object2double(db.ExecuteScalar(string.Format(@"
                    select sum(Beloeb) from EOD_SafePay_Udbetalinger
                    where BookDate = '{0}'", BookDate.Date)));
            }

            public static int GetRowCount(DateTime BookDate)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select count(*) " +
                    " from EOD_SafePay_Udbetalinger " +
                    " where BookDate = '{0}'",
                    BookDate.Date));
                return tools.object2int(total);
            }

            /// <summary>
            /// Returns true if SQL statement was executed, that is, if day is not closed.
            /// </summary>
            public static bool DeleteRecordsIfDayOpen(DateTime BookDate)
            {
                if (EODReconcileDataTable.IsDayClosed(BookDate))
                    return false;
                else
                {
                    db.ExecuteNonQuery(string.Format(@"
                        delete from EOD_SafePay_Udbetalinger
                        where BookDate = '{0}'
                        ", BookDate.Date));
                    return true;
                }
            }
        }

        partial class EOD_SafePay_OverfoerselTilSPDataTable
        {
            protected override void OnColumnChanging(DataColumnChangeEventArgs e)
            {
                if (e.Column == TidColumn)
                {
                    /// Whenever user enters a time into the datetime field, we
                    /// substitute the date part with the current open day's bookdate
                    DataRow OpenDayRecord = EODReconcileDataTable.GetCurrentOpenDay();
                    if (OpenDayRecord != null)
                    {
                        TimeSpan ProposedTime = tools.object2datetime(e.ProposedValue).TimeOfDay;
                        DateTime OpenDate = tools.object2datetime(OpenDayRecord["BookDate"]).Date;
                        e.ProposedValue = OpenDate.Add(ProposedTime);
                    }
                }

                if (e.Column == BeloebColumn)
                {
                    if (tools.IsNullOrDBNull(e.Row[BeloebColumn]))
                    {
                        // this is a new row so insert BookDate and LineNo
                        DataRow openday = EODReconcileDataTable.GetCurrentOpenDay();
                        if (openday != null)
                        {
                            e.Row[BookDateColumn] = openday["BookDate"];
                            e.Row[LineNoColumn] = GetNextLineNo();
                        }
                    }
                }

                base.OnColumnChanging(e);
            }

            protected int GetNextLineNo()
            {
                int highest = 0;
                foreach (DataRow row in this.Rows)
                {
                    if ((row.RowState != DataRowState.Deleted) &&
                        (row.RowState != DataRowState.Detached))
                    {
                        int currLineNo = tools.object2int(row["LineNo"]);
                        if (currLineNo > highest)
                            highest = currLineNo;
                    }
                }
                return highest + 1;
            }

            public static double GetTotalAmount(DateTime BookDate)
            {
                return tools.object2double(db.ExecuteScalar(string.Format(@"
                    select sum(Beloeb) from EOD_SafePay_OverfoerselTilSP
                    where BookDate = '{0}'"
                    , BookDate.Date)));
            }

            public static int GetRowCount(DateTime BookDate)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select count(*) " +
                    " from EOD_SafePay_OverfoerselTilSP " +
                    " where BookDate = '{0}' ",
                    BookDate.Date));
                return tools.object2int(total);
            }

            /// <summary>
            /// Returns true if SQL statement was executed, that is, if day is not closed.
            /// </summary>
            public static bool DeleteRecordsIfDayOpen(DateTime BookDate)
            {
                if (EODReconcileDataTable.IsDayClosed(BookDate))
                    return false;
                else
                {
                    db.ExecuteNonQuery(string.Format(@"
                        delete from EOD_SafePay_OverfoerselTilSP
                        where BookDate = '{0}'
                        ", BookDate.Date));
                    return true;
                }
            }
        }

        partial class EOD_ReserveTerminalDataTable
        {
            public static double GetTotalAmount(DateTime BookDate)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select sum(Amount) " +
                    " from EOD_ReserveTerminal " +
                    " where BookDate = '{0}' ",
                    BookDate.Date));
                return tools.object2double(total);
            }

            public static int GetRowCount(DateTime BookDate)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(
                    " select count(*) " +
                    " from EOD_ReserveTerminal " +
                    " where BookDate = '{0}' ",
                    BookDate.Date)));
            }

            public int GetNextLineNo()
            {
                int highest = 0;
                foreach (DataRow row in this.Rows)
                {
                    if ((row.RowState != DataRowState.Deleted) &&
                        (row.RowState != DataRowState.Detached))
                    {
                        int currLineNo = tools.object2int(row["LineNo"]);
                        if (currLineNo > highest)
                            highest = currLineNo;
                    }
                }
                return highest + 1;
            }
        }

        partial class WashDataTable
        {
            #region OnUltimoTaellerBeregnetUpdated event

            // the delegate
            public delegate void UltimoTaellerBeregnetUpdated();
            // the event to be used by clients
            public event UltimoTaellerBeregnetUpdated OnUltimoTaellerBeregnetUpdated
                 = new UltimoTaellerBeregnetUpdated(OnUltimoTaellerBeregnetUpdatedDummy);
            // internal use of the event
            private static void OnUltimoTaellerBeregnetUpdatedDummy() { }

            #endregion

            #region OnSamletDifferenceUpdated event

            // the delegate
            public delegate void SamletDifferenceUpdated();

            // the event to be used by clients
            public event SamletDifferenceUpdated OnSamletDifferenceUpdated
                = new SamletDifferenceUpdated(SamletDifferenceUpdatedInternal);

            // internal event handler
            private static void SamletDifferenceUpdatedInternal() { }

            #endregion

            #region CreateRecord
            /// <summary>
            /// Creates a new record on the in-memory table.
            /// Fills default values in the record.
            /// </summary>
            public void CreateRecord(DateTime RegDate)
            {
                RegDate = RegDate.Date;
                WashRow row = this.NewWashRow();
                row["RegDate"] = RegDate;

                // insert vasketæller primo if possible,
                // which is the taeller ultimo beregnet field
                // from previous month.
                DataRow rowUltimoPrevMonth = UltimoWashPrevMonth(RegDate);
                if (rowUltimoPrevMonth != null)
                {
                    row["VaskeTaellerPrimo"] = tools.object2int(rowUltimoPrevMonth["TaellerUltimoAflaest"]);
                    row["VaskeTaellerPrimo2"] = tools.object2int(rowUltimoPrevMonth["TaellerUltimoAflaest2"]);
                    row["VaskeTaellerPrimo3"] = tools.object2int(rowUltimoPrevMonth["TaellerUltimoAflaest3"]);
                    row["VaskeTaellerPrimoDate"] = tools.object2datetime(rowUltimoPrevMonth["RegDate"]);
                }

                this.AddWashRow(row);

                // perform initial total calculations
                CalcAndSetTaellerUltimoBeregnet();
                CalcAndSetSamletDifference();
            }
            #endregion

            #region CreateRecordWhenMigratingFromSSIP
            public static void CreateRecordWhenMigratingFromSSIP(
                DateTime RegDate,
                long VaskeTaellerPrimo,
                long VaskeTaellerPrimo2,
                long VaskeTaellerPrimo3,
                long LuksusMedLakforsegler,
                long LuksusVask,
                long VaskA,
                long VaskB,
                long VaskC,
                long VolumenVask,
                long TeknikerVask,
                long TaellerUltimoAflaest,
                long TaellerUltimoAflaest2,
                long TaellerUltimoAflaest3)
            {
                RegDate = RegDate.Date;
                if (GetRecord(RegDate) == null)
                {
                    db.ExecuteNonQuery(string.Format(@"
                        insert into Wash
                        (RegDate,VaskeTaellerPrimo,VaskeTaellerPrimo2,VaskeTaellerPrimo3,
                         LuxusMedLakforsegler,LuksusVask,
                         VaskA,VaskB,VaskC,VolumenVask,TeknikerVask,
                         TaellerUltimoAflaest,TaellerUltimoAflaest2,TaellerUltimoAflaest3)
                        values ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13})
                        ",
                        tools.datetime4sql(RegDate),
                        tools.wholenumber4sql(VaskeTaellerPrimo),
                        tools.wholenumber4sql(VaskeTaellerPrimo2),
                        tools.wholenumber4sql(VaskeTaellerPrimo3),
                        tools.wholenumber4sql(LuksusMedLakforsegler),
                        tools.wholenumber4sql(LuksusVask),
                        tools.wholenumber4sql(VaskA),
                        tools.wholenumber4sql(VaskB),
                        tools.wholenumber4sql(VaskC),
                        tools.wholenumber4sql(VolumenVask),
                        tools.wholenumber4sql(TeknikerVask),
                        tools.wholenumber4sql(TaellerUltimoAflaest),
                        tools.wholenumber4sql(TaellerUltimoAflaest2),
                        tools.wholenumber4sql(TaellerUltimoAflaest3)));
                }
            }
            #endregion

            #region UltimoWashPrevMonth
            /// <summary>
            /// Gets the record that has a date
            /// that falls on the last day in previous month,
            /// when looking at the date provided.
            /// If no record is found, null is returned.
            /// </summary>
            private DataRow UltimoWashPrevMonth(DateTime RegDate)
            {
                DateTime LastDayInPrevMonth = RegDate.Date.AddDays(-RegDate.Date.Day);
                DataRow row = db.GetDataRow(string.Format(@"
                    select * from Wash
                    where RegDate = '{0}'
                    ", LastDayInPrevMonth.Date));
                return row;
            }
            #endregion

            #region WashExistsForPreviousMonth
            /// <summary>
            /// Tells if readings exist in the month prior to
            /// the date given. Only the reading on the ultimo date
            /// on the previous month is checked for, as this is the
            /// only date we are interested in when checking if there
            /// exists readings on the previous month.
            /// </summary>
            public bool WashExistsForPreviousMonth(DateTime RegDate)
            {
                return (UltimoWashPrevMonth(RegDate) != null);
            }
            #endregion

            #region CalcAndSetTaellerUltimoBeregnet
            /// <summary>
            /// Calculates and sets the field TaellerUltimoBeregnet
            /// on the currently loaded record (there will only be one record).
            /// </summary>
            public void CalcAndSetTaellerUltimoBeregnet()
            {
                if (Rows.Count <= 0) return;

                // save the old value before changning it
                int oldTaellerUltimoBeregnet = tools.object2int(Rows[0]["TaellerUltimoBeregnet"]);

                // if wash 2 and 3 are enabled, count them in
                int VaskeTaellerPrimo2 = tools.object2int(Rows[0]["VaskeTaellerPrimo2"]);
                int VaskeTaellerPrimo3 = tools.object2int(Rows[0]["VaskeTaellerPrimo3"]);

                // make the update
                Rows[0]["TaellerUltimoBeregnet"] =
                    tools.object2int(Rows[0]["VaskeTaellerPrimo"]) +
                    VaskeTaellerPrimo2 +
                    VaskeTaellerPrimo3 +
                    tools.object2int(Rows[0]["LuxusMedLakforsegler"]) +
                    tools.object2int(Rows[0]["LuksusVask"]) +
                    tools.object2int(Rows[0]["VaskA"]) +
                    tools.object2int(Rows[0]["VaskB"]) +
                    tools.object2int(Rows[0]["VaskC"]) +
                    tools.object2int(Rows[0]["VolumenVask"]) +
                    tools.object2int(Rows[0]["TeknikerVask"]);

                // notify subscribers if any changes
                if (oldTaellerUltimoBeregnet != tools.object2int(Rows[0]["TaellerUltimoBeregnet"]))
                    OnUltimoTaellerBeregnetUpdated();
            }
            #endregion

            #region CalcAndSetSamletDifference
            /// <summary>
            /// Calculates and sets the field SamletDifference
            /// on the currently loaded record (there will only be one record).
            /// </summary>
            public void CalcAndSetSamletDifference()
            {
                if (Rows.Count <= 0) return;

                // save the old value before changing it
                int oldSamletDifference = tools.object2int(Rows[0]["SamletDifference"]);

                // if wash 2 and 3 are enabled, count them in
                int TaellerUltimoAflaest2 = tools.object2int(Rows[0]["TaellerUltimoAflaest2"]);
                int TaellerUltimoAflaest3 = tools.object2int(Rows[0]["TaellerUltimoAflaest3"]);

                // make the update
                Rows[0]["SamletDifference"] =
                    tools.object2int(Rows[0]["TaellerUltimoBeregnet"]) -
                    tools.object2int(Rows[0]["TaellerUltimoAflaest"]) -
                    TaellerUltimoAflaest2 -
                    TaellerUltimoAflaest3;

                // notify subscribers if any changes
                if (oldSamletDifference != tools.object2int(Rows[0]["SamletDifference"]))
                    OnSamletDifferenceUpdated();
            }
            #endregion

            #region GetRecord
            /// <summary>
            /// Gets the record that has the given date.
            /// If no records were found, null is returned.
            /// </summary>
            public static DataRow GetRecord(DateTime RegDate)
            {
                return db.GetDataRow(string.Format(@"
                    select * from Wash
                    where RegDate = '{0}'
                    ", RegDate.Date));
            }
            #endregion

            #region ValidReadingsExist
            /// <summary>
            /// Validates whether TaellerUltimoAflaest, TaellerUltimoAflaest2, TaellerUltimoAflaest3
            /// have been filled in correctly.
            /// </summary>
            public static bool ValidReadingsExist(DateTime RegDate, out string ErrorMessage)
            {
                DataRow row = GetRecord(RegDate);
                if (row != null)
                {
                    // verify TaellerUltimoAflaest is above 0
                    if (tools.object2int(row["TaellerUltimoAflaest"]) <= 0)
                    {
                        ErrorMessage = db.GetLangString("WashDataTable.TaellerUltimoAflaestError");
                        return false;
                    }

                    // verify TaellerUltimoAflaest2 is above 0
                    if ((db.GetConfigStringAsBool("Readings.Vaskeafstemning2")) &&
                        (tools.object2int(row["TaellerUltimoAflaest2"]) <= 0))
                    {
                        ErrorMessage = db.GetLangString("WashDataTable.TaellerUltimoAflaest2Error");
                        return false;
                    }

                    // verify TaellerUltimoAflaest3 is above 0
                    if ((db.GetConfigStringAsBool("Readings.Vaskeafstemning3")) &&
                        (tools.object2int(row["TaellerUltimoAflaest3"]) <= 0))
                    {
                        ErrorMessage = db.GetLangString("WashDataTable.TaellerUltimoAflaest3Error");
                        return false;
                    }
                }
                else
                {
                    // no records found means no readings for the day,
                    // and this is perfectly allright
                }

                ErrorMessage = "";
                return true;
            }
            #endregion

            #region OnColumnChanged
            protected override void OnColumnChanged(DataColumnChangeEventArgs e)
            {
                if ((e.Column == VaskeTaellerPrimoColumn) ||
                    (e.Column == VaskeTaellerPrimo2Column) ||
                    (e.Column == VaskeTaellerPrimo3Column) ||
                    (e.Column == LuxusMedLakforseglerColumn) ||
                    (e.Column == LuksusVaskColumn) ||
                    (e.Column == VaskAColumn) ||
                    (e.Column == VaskBColumn) ||
                    (e.Column == VaskCColumn) ||
                    (e.Column == VolumenVaskColumn) ||
                    (e.Column == TeknikerVaskColumn))
                {
                    CalcAndSetTaellerUltimoBeregnet();

                }
                else if ((e.Column == TaellerUltimoBeregnetColumn) ||
                         (e.Column == TaellerUltimoAflaestColumn) ||
                         (e.Column == TaellerUltimoAflaest2Column) ||
                         (e.Column == TaellerUltimoAflaest3Column))
                {
                    CalcAndSetSamletDifference();
                }

                base.OnColumnChanged(e);
            }
            #endregion
        }

        partial class ReadingsDataTable
        {
            #region OnColumnChanged
            protected override void OnColumnChanged(DataColumnChangeEventArgs e)
            {
                if ((e.Column == columnMainWaterPrimo) || (e.Column == columnMainWaterReading))
                {
                    // mainwater primo or reading changed, update use column
                    e.Row[columnMainWaterUse] =
                        tools.object2int(e.Row[columnMainWaterReading]) -
                        tools.object2int(e.Row[columnMainWaterPrimo]);
                }
                else if ((e.Column == columnWashPrimo) || (e.Column == columnWashReading))
                {
                    // wash primo or reading changed, update use column
                    e.Row[columnWashUse] =
                        tools.object2int(e.Row[columnWashReading]) -
                        tools.object2int(e.Row[columnWashPrimo]);
                }
                else if ((e.Column == columnKWPrimo) || (e.Column == columnKWReading))
                {
                    // kw primo or reading changed, update use column
                    e.Row[columnKWUse] =
                        tools.object2int(e.Row[columnKWReading]) -
                        tools.object2int(e.Row[columnKWPrimo]);
                }

                base.OnColumnChanged(e);
            }
            #endregion

            #region UltimoReadingsPrevMonth
            /// <summary>
            /// Gets the record that has a date
            /// that falls on the last day in previous month,
            /// when looking at the date provided.
            /// If no record is found, null is returned.
            /// </summary>
            private DataRow UltimoReadingsPrevMonth(DateTime RegDate)
            {
                DateTime LastDayInPrevMonth = RegDate.Date.AddDays(-RegDate.Date.Day);
                DataRow row = db.GetDataRow(string.Format(@"
                    select * from Readings
                    where RegDate = '{0}'
                    ", LastDayInPrevMonth.Date));
                return row;
            }
            #endregion

            #region ReadingsExistForPreviousMonth
            /// <summary>
            /// Tells if readings exist in the month prior to
            /// the date given. Only the reading on the ultimo date
            /// on the previous month is checked for, as this is the
            /// only date we are interested in when checking if there
            /// exists readings on the previous month.
            /// </summary>
            /// <param name="RegDate"></param>
            /// <returns></returns>
            public bool ReadingsExistForPreviousMonth(DateTime RegDate)
            {
                return (UltimoReadingsPrevMonth(RegDate) != null);
            }
            #endregion

            #region CreateRecord
            /// <summary>
            /// Creates a new record on the in-memory table.
            /// Fills default values in the record.
            /// </summary>
            public void CreateRecord(DateTime RegDate)
            {
                RegDate = RegDate.Date;
                ReadingsRow row = this.NewReadingsRow();
                row["RegDate"] = RegDate;

                // if possible, fill in primo readings and date
                DataRow rowPrimo = UltimoReadingsPrevMonth(RegDate);
                if (rowPrimo != null)
                {
                    row["PrimoDate"] = rowPrimo["RegDate"];
                    row["MainWaterPrimo"] = rowPrimo["MainWaterReading"];
                    row["WashPrimo"] = rowPrimo["WashReading"];
                    row["KWPrimo"] = rowPrimo["KWReading"];
                }

                this.AddReadingsRow(row);
            }
            #endregion

            #region CreateRecordWhenMigratingFromSSIP
            public static void CreateRecordWhenMigratingFromSSIP(
                DateTime RegDate,
                int MainWaterReading,
                int MainWaterPrimo,
                int WashReading,
                int WashPrimo,
                int KWReading,
                int KWPrimo)
            {
                RegDate = RegDate.Date;
                if (GetRecord(RegDate) == null)
                {
                    db.ExecuteNonQuery(string.Format(@"
                        insert into Readings
                        (RegDate,MainWaterReading,MainWaterPrimo,WashReading,WashPrimo,KWReading,KWPrimo)
                        values ({0},{1},{2},{3},{4},{5},{6})
                        ",
                         tools.datetime4sql(RegDate),
                         tools.wholenumber4sql(MainWaterReading),
                         tools.wholenumber4sql(MainWaterPrimo),
                         tools.wholenumber4sql(WashReading),
                         tools.wholenumber4sql(WashPrimo),
                         tools.wholenumber4sql(KWReading),
                         tools.wholenumber4sql(KWPrimo)));
                }
            }
            #endregion

            #region Properties exposing fields on the current record (there is only one record)

            public int MainWaterPrimo
            {
                get
                {
                    if (this.Rows.Count > 0)
                        return tools.object2int(Rows[0]["MainWaterPrimo"]);
                    else
                        return 0;
                }
            }
            public int WashWaterPrimo
            {
                get
                {
                    if (this.Rows.Count > 0)
                        return tools.object2int(Rows[0]["WashPrimo"]);
                    else
                        return 0;
                }
            }
            public int KiloWattPrimo
            {
                get
                {
                    if (this.Rows.Count > 0)
                        return tools.object2int(Rows[0]["KWPrimo"]);
                    else
                        return 0;
                }
            }
            #endregion

            #region GetRecord
            /// <summary>
            /// Returns a Readings row that has the given RegDate.
            /// If no row was found, null is returned.
            /// </summary>
            private static DataRow GetRecord(DateTime RegDate)
            {
                return db.GetDataRow(string.Format(@"
                    select * from Readings
                    where RegDate = '{0}'"
                    , RegDate.Date));
            }
            #endregion

            #region ValidReadingsExist
            /// <summary>
            /// Checks for if a Readings record exist for the given date,
            /// and if the readings are positive and some other checks.
            /// Caller is responsible for checking if it is the last day in the month,
            /// if the last day is desired, as this method accepts any day in the month.
            /// </summary>
            public static bool ValidReadingsExist(DateTime RegDate, out string ErrorMessage)
            {
                ErrorMessage = "";
                bool LastDayInMonth = tools.IsLastDayInMonth(RegDate);

                DataRow row = EODDataSet.ReadingsDataTable.GetRecord(RegDate.Date);

                if (row == null)
                {
                    ErrorMessage = db.GetLangString("ReadingsDataTable.NoReadingsForTheDay");
                    return false;
                }

                // verify MainWaterReading
                if (tools.object2int(row["MainWaterReading"]) <= 0)
                {
                    ErrorMessage = db.GetLangString("ReadingsDataTable.MainWaterMustBePositive");
                    return false;
                }

                // verify WashWaterReading
                if ((tools.object2int(row["WashReading"]) <= 0) && db.GetConfigStringAsBool("Readings.SeperateWashReadings"))
                {
                    ErrorMessage = db.GetLangString("ReadingsDataTable.WashWaterMustBePositive");
                    return false;
                }

                // verify KWReading
                if (tools.object2int(row["KWReading"]) <= 0)
                {
                    ErrorMessage = db.GetLangString("ReadingsDataTable.KWMustBePositive");
                    return false;
                }

                // readings are valid
                return true;
            }
            #endregion
        }

        partial class GLBudgetDataTable
        {
            /// <summary>
            /// Enum der bruges til GetBudget metoden.
            /// </summary>
            public enum BudgetUnit
            {
                Volume,
                Amount
            }

            /// <summary>
            /// Generel metode, der henter volume/amount budgettal
            /// for de angivne GLCodes i den angive periode.
            /// </summary>
            public static double GetBudget(int Year, int Month, List<string> GLCodes, BudgetUnit Unit)
            {
                // prepare the list of codes for sql "in" statement
                string codes = "";
                foreach (string code in GLCodes)
                    codes += string.Format(",'{0}'", code);
                codes = "(" + codes.Remove(0, 1) + ")";

                string field = (Unit == BudgetUnit.Volume) ? "Volume" : "Amount";

                return tools.object2double(db.ExecuteScalar(string.Format(@"
                    select sum({0}) from GLBudget
                    where (GLCode in {1})
                    and (BudgetYear = {2})
                    and (BudgetMonth = {3})
                    ", field, codes, Year, Month)));
            }

            /// <summary>
            /// Henter volume budgettal for VPower kontoen.
            /// Se GLAccountDataTable.GetVPowerGLCode()
            /// for hvilken konto det er.
            /// </summary>
            public static double GetVPowerBudget(int Year, int Month)
            {
                List<string> list = new List<string>();
                list.Add(GLAccountDataTable.GetVPowerGLCode());
                return GetBudget(Year, Month, list, BudgetUnit.Volume);
            }

            public static void CreateRecord(
                string GLCode,
                int BudgetYear,
                int BudgetMonth,
                double Volume,
                double Amount)
            {
                if (!RecordExists(GLCode, BudgetYear, BudgetMonth))
                {
                    db.ExecuteNonQuery(string.Format(@"
                        insert into GLBudget
                        (GLCode, BudgetYear, BudgetMonth, Volume, Amount)
                        values ({0},{1},{2},{3},{4})
                        ", GLCode, BudgetYear, BudgetMonth, Volume, Amount));
                }
            }

            public static bool RecordExists(string GLCode, int BudgetYear, int BudgetMonth)
            {
                return (tools.object2int(db.ExecuteScalar(string.Format(@"
                    select count(*) from GLBudget
                    where (GLCode = '{0}')
                    and (BudgetYear = {1})
                    and (BudgetMonth = {2})
                    ",
                     GLCode.Replace("'", ""),
                     BudgetYear,
                     BudgetMonth))) > 0);
            }
        }

        partial class EOD_ForeignCurrencyDataTable
        {
            public static double GetTotalForeignCurrencyAmount(DateTime BookDate)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select sum(Amount) " +
                    " from EOD_ForeignCurrency " +
                    " where BookDate = '{0}' ",
                    BookDate.Date));
                return tools.object2double(total);
            }

            public static int GetForeignCurrencyRowCount(DateTime BookDate)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select count(*) " +
                    " from EOD_ForeignCurrency " +
                    " where BookDate = '{0}' ",
                    BookDate.Date));
                return tools.object2int(total);
            }

            public int GetNextLineNo()
            {
                int highest = 0;
                foreach (DataRow row in this.Rows)
                {
                    if ((row.RowState != DataRowState.Deleted) &&
                        (row.RowState != DataRowState.Detached))
                    {
                        int currLineNo = tools.object2int(row["LineNo"]);
                        if (currLineNo > highest)
                            highest = currLineNo;
                    }
                }
                return highest + 1;
            }

            /// <summary>
            /// Returns the next lineno per Bookdate.
            /// Static version that works with on-disk data.
            /// </summary>
            public static int GetNextLineNo(DateTime BookDate)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(@"
                    select max(LineNo)
                    from EOD_ForeignCurrency
                    where BookDate = '{0}'
                    ", BookDate.Date))) + 1;
            }

            public static void CreateNewRecord(
                DateTime BookDate,
                string Description,
                double Amount)
            {
                BookDate = BookDate.Date;
                int NextLineNo = GetNextLineNo(BookDate);

                db.ExecuteNonQuery(string.Format(@"
                    insert into EOD_ForeignCurrency
                    (BookDate,LineNo,Description,Amount)
                    values ({0},{1},{2},{3})
                    ",
                     tools.datetime4sql(BookDate),
                     tools.wholenumber4sql(NextLineNo),
                     tools.string4sql(Description, 25),
                     tools.decimalnumber4sql(Amount)));
            }
        }

        partial class EOD_ManualCardsDataTable
        {
            public static double GetTotalManualCardsAmount(DateTime BookDate)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select sum(Amount) " +
                    " from EOD_ManualCards " +
                    " where BookDate = '{0}' ",
                    BookDate.Date));
                return tools.object2double(total);
            }

            public static int GetManualCardsRowCount(DateTime BookDate)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select count(*) " +
                    " from EOD_ManualCards " +
                    " where BookDate = '{0}' ",
                    BookDate.Date));
                return tools.object2int(total);
            }

            public int GetNextLineNo()
            {
                int highest = 0;
                foreach (DataRow row in this.Rows)
                {
                    if ((row.RowState != DataRowState.Deleted) &&
                        (row.RowState != DataRowState.Detached))
                    {
                        int currLineNo = tools.object2int(row["LineNo"]);
                        if (currLineNo > highest)
                            highest = currLineNo;
                    }
                }
                return highest + 1;
            }

            /// <summary>
            /// Returns the next lineno per Bookdate.
            /// Static version that works with on-disk data.
            /// </summary>
            public static int GetNextLineNo(DateTime BookDate)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(@"
                    select max([LineNo])
                    from EOD_ManualCards
                    where BookDate = '{0}'
                    ", BookDate.Date))) + 1;
            }

            public static void CreateNewRecord(
                DateTime BookDate,
                string Description,
                double Amount)
            {
                BookDate = BookDate.Date;
                int NextLineNo = GetNextLineNo(BookDate);

                db.ExecuteNonQuery(string.Format(@"
                    insert into EOD_ManualCards
                    (BookDate,[LineNo],Description,Amount)
                    values ({0},{1},{2},{3})
                    ",
                     tools.datetime4sql(BookDate),
                     tools.wholenumber4sql(NextLineNo),
                     tools.string4sql(Description, 25),
                     tools.decimalnumber4sql(Amount)));
            }
        }

        partial class GLAccountDataTable
        {
            public static string GetDescription(string GLCode)
            {
                return tools.object2string(db.ExecuteScalar(string.Format(@"
                    select Description from GLAccount
                    where GLCode = '{0}'
                    ", GLCode.Replace("'", ""))));
            }

            /// <summary>
            /// Returnerer VPower's GLCode, som er 1005.
            /// Er defineret i en metode, da den hentes flere steder fra.
            /// </summary>
            public static string GetVPowerGLCode()
            {
                return "1005";
            }

            /// <summary>
            /// Returns the record with the given GLCode. If no record is found, null is returned.
            /// </summary>
            public static DataRow GetRecord(string GLCode)
            {
                return db.GetDataRow(string.Format("select * from GLAccount where GLCode = '{0}'", GLCode));
            }
        }

        partial class EOD_DebtorDataTable
        {
            #region CreateNewRecord
            /// <summary>
            /// Attempts to create a new debtor record with the given DebtorNo.
            /// The Active flag is always set to true when creating a new debtor.
            /// True is returned if no other debtor has that number.
            /// False is returned if a debtor has that number already.
            /// </summary>
            public bool CreateNewRecord(int NewDebtorNoProposal, string Name1)
            {
                // check if a debtor already exists with that DebtorNo
                object debtorAlreadyExists = db.ExecuteScalar(string.Format(
                    " select DebtorNo " +
                    " from EOD_Debtor " +
                    " where DebtorNo = {0} ",
                    NewDebtorNoProposal));
                if (tools.IsNullOrDBNull(debtorAlreadyExists))
                {
                    // no debtor exists with that DebtorNo, create record with that DebtorNo
                    db.ExecuteNonQuery(string.Format(
                        " insert into EOD_Debtor (DebtorNo,Name1,Active) values({0},{1},1) ",
                        NewDebtorNoProposal,
                        tools.string4sql(Name1, 255)));

                    // debtor created, return true
                    return true;
                }
                else
                {
                    // a debtor already exists with that DebtorNo, return false
                    return false;
                }
            }
            #endregion

            #region CreateNewRecord (all values)
            public static bool CreateNewRecord(
                int DebtorNo,
                string Name1,
                string Name2,
                string Address1,
                string Address2,
                string ZipCode,
                string City,
                string Phone,
                string Att,
                string RRNumber)
            {
                if (DebtorExists(DebtorNo))
                    return false;

                db.ExecuteNonQuery(string.Format(@"
                    insert into EOD_Debtor
                    (DebtorNo,Name1,Name2,Address1,Address2,ZipCode,City,Phone,Att,RRNumber,Active)
                    values({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10})
                    ",
                    DebtorNo,
                    tools.string4sql(Name1, 255),
                    tools.string4sql(Name2, 255),
                    tools.string4sql(Address1, 255),
                    tools.string4sql(Address2, 255),
                    tools.string4sql(ZipCode, 10),
                    tools.string4sql(City, 255),
                    tools.string4sql(Phone, 20),
                    tools.string4sql(Att, 255),
                    tools.string4sql(RRNumber, 20).Replace("'", ""),
                    true));

                // record created
                return true;
            }
            #endregion

            public static bool UpdateRecord(
                int DebtorNo,
                string Name1,
                string Name2,
                string Address1,
                string Address2,
                string ZipCode,
                string City,
                string Phone,
                string Att,
                string RRNumber,
                Nullable<bool> Active)
            {
                if (!DebtorExists(DebtorNo))
                    return false;

                db.ExecuteNonQuery(string.Format(@"
                    update EOD_Debtor set
                    Name1 = {1},
                    Name2 = {2},
                    Address1 = {3},
                    Address2 = {4},
                    ZipCode = {5},
                    City = {6},
                    Phone = {7},
                    Att = {8},
                    RRNumber = {9},
                    Active = {10}
                    where (DebtorNo = {0})
                    ",
                    DebtorNo,
                    tools.string4sql(Name1, 255),
                    tools.string4sql(Name2, 255),
                    tools.string4sql(Address1, 255),
                    tools.string4sql(Address2, 255),
                    tools.string4sql(ZipCode, 10),
                    tools.string4sql(City, 255),
                    tools.string4sql(Phone, 20),
                    tools.string4sql(Att, 255),
                    tools.string4sql(RRNumber, 20).Replace("'", ""),
                    tools.bool4sql(Active)));

                // record updated
                return true;
            }

            #region GetDebtor
            /// <summary>
            /// Attempts to find and return a debtor from the given RRNumber.
            /// First it tries to locate a debtor with that RRNumber. If
            /// this fails, it tries to locate a debtor with a DebtorNo
            /// that matches the given RRNumber.
            /// 0 is returned if no debtor was found.
            /// </summary>
            public static int GetDebtor(string RRNumber)
            {
                RRNumber = RRNumber.Replace("'", "");
                return tools.object2int(db.ExecuteScalar(string.Format(@"
                    select DebtorNo from EOD_Debtor
                    where (RRNumber = '{0}')
                    or (cstr(DebtorNo) = '{0}')
                    ", RRNumber)));
            }
            #endregion

            #region DebtorExists
            public static bool DebtorExists(int DebtorNo)
            {
                return (tools.object2int(db.ExecuteScalar(string.Format(@"
                    select count(*) from EOD_Debtor
                    where (DebtorNo = {0})
                    ", DebtorNo))) > 0);
            }
            #endregion

            #region GetNextUniqueDebtorNo
            public static int GetNextUniqueDebtorNo()
            {
                List<int> list = new List<int>();
                DataTable table = db.GetDataTable("select DebtorNo from EOD_Debtor");
                foreach (DataRow row in table.Rows)
                    list.Add(tools.object2int(row["DebtorNo"]));
                int DebtorNo = 100000;
                while (list.Contains(DebtorNo))
                    ++DebtorNo;
                return DebtorNo;
            }
            #endregion
        }

        partial class EODReconcileSingleDataTable
        {
            public void CalcTotalsInMemory(DateTime BookDate)
            {
                if (Rows.Count <= 0) return;
                DataRow row = Rows[0];

                // TotalBank
                row["TotalBank"] =
                    tools.object2double(row["BankDepAmount"]) +
                    // tools.object2double(row["ManDankortSumB"]) +
                    tools.object2double(row["BankCardAmount"]);


                // SafePay
                row["TotalSafePay"] =
                    tools.object2double(row["SafePayAmount"]) +
                    tools.object2double(row["SafePayAmountCurr"]);




                if (db.GetConfigStringAsBool("SafePay.Enabled"))
                {

                    // TotalShell Safepay
                    row["TotalShell"] =
                        tools.object2double(row["ShellCardAmount"]) +
                        tools.object2double(row["DiscountAmount"]) +
                        tools.object2double(row["MiscCards"]) +
                        tools.object2double(row["ManDankortSumB"]) +
                        tools.object2double(row["CashDiscount"]);
                }
                else
                {

                    // TotalShell
                    row["TotalShell"] =
                        tools.object2double(row["ShellCardAmount"]) +
                        tools.object2double(row["DiscountAmount"]) +
                        tools.object2double(row["MiscCards"]) +
                        tools.object2double(row["ManDankortSumB"]) +  //peter
                        tools.object2double(row["CashDiscount"]);
                }


                // TotalMisc
                row["TotalMisc"] =
                    tools.object2double(row["DriveOffTotal"]) +
                    tools.object2double(row["LocalCredit"]) -
                    tools.object2double(row["LocalCreditPayin"]) +
                    tools.object2double(row["ForeignCurrency"]) +
                    tools.object2double(row["MoentDaglig"]);

                // TotalSales
                row["TotalSales"] =
                    tools.object2double(row["POSSales"]) +
                    tools.object2double(row["ManualSales"]);

                if (db.GetConfigStringAsBool("SafePay.Enabled"))
                {
                    // TotalABC med safepay
                    row["TotalABC"] =
                        tools.object2double(row["TotalSafePay"]) +
                        tools.object2double(row["TotalShell"]) +
                        tools.object2double(row["TotalMisc"]);
                }
                else
                {
                    // TotalABC 
                    row["TotalABC"] =
                        tools.object2double(row["TotalBank"]) +
                        tools.object2double(row["TotalShell"]) +
                        tools.object2double(row["TotalMisc"]);
                }


                // TotalD
                row["TotalD"] = tools.object2double(row["TotalSales"]);

                // CashOverUnder
                row["CashOverUnder"] =
                    tools.object2double(row["TotalABC"]) -
                    tools.object2double(row["TotalD"]) -
                    tools.object2double(row["Payin"]) +
                    tools.object2double(row["Payout"]);
            }

            public static void CalcTotalsOnDisk(DateTime BookDate)
            {
                DataRow row = db.GetDataRow(string.Format(
                    " select * from EODReconcile " +
                    " where BookDate = '{0}' ",
                    BookDate.Date));

                if (row != null)
                {
                    // TotalBank
                    row["TotalBank"] =
                        tools.object2double(row["BankDepAmount"]) +
                        tools.object2double(row["ManDankortSumB"]) +
                        tools.object2double(row["BankCardAmount"]);


                    // SafePay
                    row["TotalSafePay"] =
                        tools.object2double(row["SafePayAmount"]) +
                        tools.object2double(row["SafePayAmountCurr"]);


                    // TotalShell
                    row["TotalShell"] =
                        tools.object2double(row["ShellCardAmount"]) +
                        tools.object2double(row["DiscountAmount"]) +
                        tools.object2double(row["MiscCards"]) +
                        tools.object2double(row["CashDiscount"]);

                    // TotalMisc
                    row["TotalMisc"] =
                        tools.object2double(row["DriveOffTotal"]) +
                        tools.object2double(row["LocalCredit"]) -
                        tools.object2double(row["LocalCreditPayin"]) +
                        tools.object2double(row["ForeignCurrency"]) +
                        tools.object2double(row["MoentDaglig"]);

                    // TotalSales
                    row["TotalSales"] =
                        tools.object2double(row["POSSales"]) +
                        tools.object2double(row["ManualSales"]);


                    if (db.GetConfigStringAsBool("SafePay.Enabled"))
                    {
                        // TotalABC med safepay
                        row["TotalABC"] =
                            tools.object2double(row["TotalSafePay"]) +
                            tools.object2double(row["TotalShell"]) +
                            tools.object2double(row["TotalMisc"]);
                    }
                    else
                    {
                        // TotalABC 
                        row["TotalABC"] =
                            tools.object2double(row["TotalBank"]) +
                            tools.object2double(row["TotalShell"]) +
                            tools.object2double(row["TotalMisc"]);
                    }



                    // TotalD
                    row["TotalD"] = tools.object2double(row["TotalSales"]);

                    // CashOverUnder
                    row["CashOverUnder"] =
                        tools.object2double(row["TotalABC"]) -
                        tools.object2double(row["TotalD"]) -
                        tools.object2double(row["Payin"]) +
                        tools.object2double(row["Payout"]);



                    EODDataSetTableAdapters.EODReconcileSingleTableAdapter adapter =
                        new RBOS.EODDataSetTableAdapters.EODReconcileSingleTableAdapter();
                    adapter.Connection = db.Connection;
                    adapter.Update(row);
                }
            }
        }

        partial class EOD_SalesDataTable
        {
            public static bool HasRecords(DateTime BookDate)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(@"
                    select count(*) from EOD_Sales
                    where BookDate = '{0}'
                    ", BookDate.Date))) > 0;
            }

            public static double GetTotalSalesAmount(DateTime BookDate, TransTypeSales TransType)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select sum(Amount) " +
                    " from EOD_Sales " +
                    " where TransType = {0} and BookDate = '{1}' ",
                    (int)TransType,
                    BookDate.Date));
                return tools.object2double(total);
            }

            public static double GetVPowerSalesLitres(DateTime BookDate)
            {
                return tools.object2double(db.ExecuteScalar(string.Format(@"
                    select sum(sales.NumberOf)
                    from EOD_Sales sales
                    left join SubCategory subcat
                    on sales.SubCategory = subcat.SubCategoryID
                    where (sales.BookDate = '{0}')
                    and (sales.TransType = {1})
                    and (subcat.GLCode = '{2}')
                    ",
                     BookDate.Date,
                     (int)db.TransactionTypes.Sales,
                     GLAccountDataTable.GetVPowerGLCode())));
            }

            public static int GetPOSSalesRowCount(DateTime BookDate)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select count(*) " +
                    " from EOD_Sales " +
                    " where TransType = 1 and BookDate = '{0}' ",
                    BookDate.Date));
                return tools.object2int(total);
            }

            public static int GetManSalesRowCount(DateTime BookDate)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select count(*) " +
                    " from EOD_Sales " +
                    " where TransType = 2 and BookDate = '{0}' ",
                    BookDate.Date));
                return tools.object2int(total);
            }
            public int GetNextLineNo()
            {
                int highest = 0;
                foreach (DataRow row in this.Rows)
                {
                    if ((row.RowState != DataRowState.Deleted) &&
                        (row.RowState != DataRowState.Detached))
                    {
                        int currLineNo = tools.object2int(row["LineNo"]);
                        if (currLineNo > highest)
                            highest = currLineNo;
                    }
                }
                return highest + 1;
            }

            public static int GetNextLineNo(DateTime BookDate, TransTypeSales TransType)
            {
                return (tools.object2int(db.ExecuteScalar(string.Format(@"
                    select max(LineNo)
                    from EOD_Sales
                    where (BookDate = '{0}')
                    and (TransType = {1})
                    ", BookDate.Date, (int)TransType))) + 1);
            }

            #region DeleteRecords
            /// <summary>
            /// Deletes all records on the given book date.
            /// </summary>
            public static void DeleteRecords(DateTime BookDate)
            {
                db.ExecuteNonQuery(string.Format(@"
                    delete from EOD_Sales
                    where BookDate = '{0}'
                    ", BookDate.Date));
            }
            #endregion

            #region CreateRecord
            public static void CreateRecord(
                DateTime BookDate,
                TransTypeSales TransType,
                string GLFinance,
                double NumberOf,
                double Amount)
            {
                // get next lineno
                int LineNo = GetNextLineNo(BookDate, TransType);

                // lookup subcategory id
                string SubCategoryID = ItemDataSet.SubCategoryDataTable.GetSubCategoryIDFromGLCode(GLFinance);

                // lookup subcategory desc
                string SubCatDesc = ItemDataSet.SubCategoryDataTable.GetSubCategoryDescription(SubCategoryID);

                // lookup GLFinance description
                string GLFinDesc = GLAccountDataTable.GetDescription(GLFinance);

                db.ExecuteNonQuery(string.Format(@"
                    insert into EOD_Sales
                    (BookDate,LineNo,TransType,SubCategory,SubCatDesc,GLFinance,GlFinDesc,NumberOf,Amount)
                    values ({0},{1},{2},{3},{4},{5},{6},{7},{8})
                    ",
                     tools.datetime4sql(BookDate.Date),
                     LineNo,
                     (int)TransType,
                     tools.string4sql(SubCategoryID, 20),
                     tools.string4sql(SubCatDesc, 50),
                     tools.string4sql(GLFinance, 8),
                     tools.string4sql(GLFinDesc, 25),
                     tools.decimalnumber4sql(NumberOf),
                     tools.decimalnumber4sql(Amount)));
            }
            #endregion

            /// <summary>
            /// Creates a record for the DETAIL version.
            /// </summary>
            public static void CreateRecord_DETAIL(
                DateTime BookDate,
                string SubCategoryID,
                double OmsEksMoms,
                double MomsBeloeb,
                double Momssats)
            {
                int LineNo = GetNextLineNo(BookDate, TransTypeSales.POSSales);
                string SubCatDesc = ItemDataSet.SubCategoryDataTable.GetSubCategoryDescription(SubCategoryID);

                // at the moment we just add OmsEksMoms with MomsBeloeb and write that to Amount
                double Amount = OmsEksMoms + MomsBeloeb;

                db.ExecuteNonQuery(string.Format(@"
                    insert into EOD_Sales
                    (BookDate,LineNo,TransType,SubCategory,SubCatDesc,GLFinance,GlFinDesc,NumberOf,Amount)
                    values ({0},{1},{2},{3},{4},{5},{6},{7},{8})
                    ",
                     tools.datetime4sql(BookDate.Date),
                     LineNo,
                     (int)TransTypeSales.POSSales, // TransType
                     tools.string4sql(SubCategoryID, 20),
                     tools.string4sql(SubCatDesc, 50),
                     "NULL", // GLFinance
                     "NULL", // GLFinDesc
                     "NULL", // NumberOf
                     tools.decimalnumber4sql(Amount)));
            }

            #region GetMaxSalesDate
            public static DateTime GetMaxSalesDate()
            {
                return tools.object2datetime(db.ExecuteScalar(@"
                    select max(BookDate)
                    from EOD_Sales
                    "));
            }
            #endregion

            #region GetMinSalesDate
            public static DateTime GetMinSalesDate()
            {
                return tools.object2datetime(db.ExecuteScalar(@"
                    select min(BookDate)
                    from EOD_Sales
                    "));
            }
            #endregion
        }

        partial class EOD_PayinPayoutDataTable
        {
            public static bool HasRecords(DateTime BookDate)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(@"
                    select count(*) from EOD_PayinPayout
                    where BookDate = '{0}' "
                    , BookDate.Date))) > 0;
            }

            public static double GetTotalPayinPayoutAmount(DateTime BookDate, TransTypePayinPayout TransType)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select sum(Amount) " +
                    " from EOD_PayinPayout " +
                    " where TransType = {0} and BookDate = '{1}' ",
                    (int)TransType,
                    BookDate.Date));
                return tools.object2double(total);
            }


            public static int GetPayinRowCount(DateTime BookDate)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select count(*) " +
                    " from EOD_PayinPayout " +
                    " where TransType = 1 and BookDate = '{0}' ",
                    BookDate.Date));
                return tools.object2int(total);
            }

            public static int GetPayoutRowCount(DateTime BookDate)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select count(*) " +
                    " from EOD_PayinPayout " +
                    " where TransType = 2 and BookDate = '{0}' ",
                    BookDate.Date));
                return tools.object2int(total);
            }

            public int GetNextLineNo()
            {
                int highest = 0;
                foreach (DataRow row in this.Rows)
                {
                    if ((row.RowState != DataRowState.Deleted) &&
                        (row.RowState != DataRowState.Detached))
                    {
                        int currLineNo = tools.object2int(row["LineNo"]);
                        if (currLineNo > highest)
                            highest = currLineNo;
                    }
                }
                return highest + 1;
            }

            /// <summary>
            /// Returns the next lineno per Bookdate and TransType.
            /// Static version that works with on-disk data.
            /// </summary>
            public static int GetNextLineNo(DateTime BookDate, TransTypePayinPayout TransactionType)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(@"
                    select max([LineNo])
                    from EOD_PayinPayout
                    where (BookDate = '{0}')
                    and (TransType = {1})
                    ", BookDate.Date, (int)TransactionType))) + 1;
            }

            /// <summary>
            /// Creates a new record in the database on disk.
            /// </summary>
            public static void CreateNewRecord(
                DateTime BookDate,
                TransTypePayinPayout TransactionType,
                string Description,
                double Amount,
                bool Imported)
            {
                BookDate = BookDate.Date;
                int NextLineNo = GetNextLineNo(BookDate, TransactionType);

                db.ExecuteNonQuery(string.Format(@"
                    insert into EOD_PayinPayout
                    (BookDate,LineNo,TransType,Description,Amount,Imported)
                    values ({0},{1},{2},{3},{4},{5})
                    ",
                     tools.datetime4sql(BookDate),
                     tools.wholenumber4sql(NextLineNo),
                     tools.wholenumber4sql((int)TransactionType),
                     tools.string4sql(Description, 25),
                     tools.decimalnumber4sql(Amount),
                     tools.bool4sql(Imported)));
            }

            /// <summary>
            /// Creates a record for the DETAIL version.
            /// </summary>
            public static void CreateNewRecord_DETAIL(
                DateTime BookDate,
                TransTypePayinPayout TransactionType,
                string Description,
                double Amount,
                bool Imported,
                TimeSpan Tidspunkt)
            {
                BookDate = BookDate.Date;
                int NextLineNo = GetNextLineNo(BookDate, TransactionType);

                db.ExecuteNonQuery(string.Format(@"
                    insert into EOD_PayinPayout
                    (BookDate,LineNo,TransType,Description,Amount,Imported,Tidspunkt_DETAIL)
                    values ({0},{1},{2},{3},{4},{5},{6})
                    ",
                     tools.datetime4sql(BookDate),
                     tools.wholenumber4sql(NextLineNo),
                     tools.wholenumber4sql((int)TransactionType),
                     tools.string4sql(Description, 25),
                     tools.decimalnumber4sql(Amount),
                     tools.bool4sql(Imported),
                     tools.timespan4sql(Tidspunkt)));
            }

            public static void DeleteRecords(DateTime BookDate)
            {
                db.ExecuteNonQuery(string.Format(@"
                    delete from EOD_PayinPayout
                    where BookDate = '{0}'
                    ", BookDate.Date));
            }
        }

        partial class EOD_Debtor_LocalCredDataTable
        {
            /// <summary>
            /// Returns the next lineno per BookDate and TransType.
            /// Checks in-memory and on-disk.
            /// </summary>
            public int GetNextLineNo(DateTime BookDate, TransTypeLocalCred TransType)
            {
                int highest = 0;

                // first check in-memory
                string filter = string.Format(
                    " (BookDate = '{0}') and (TransType = {1}) ",
                    BookDate.Date, (int)TransType);
                DataRow[] rows = this.Select(filter);
                foreach (DataRow row in rows)
                {
                    if ((row.RowState != DataRowState.Deleted) &&
                        (row.RowState != DataRowState.Detached))
                    {
                        int currLineNo = tools.object2int(row["LineNo"]);
                        if (currLineNo > highest)
                            highest = currLineNo;
                    }
                }

                // then check on-disk
                DataTable table = db.GetDataTable(string.Format(
                    " select [LineNo] from EOD_LocalCred " +
                    " where (BookDate = '{0}') " +
                    " and (TransType = {1}) ",
                    BookDate.Date, (int)TransType));
                foreach (DataRow row in table.Rows)
                {
                    int currLineNo = tools.object2int(row["LineNo"]);
                    if (currLineNo > highest)
                        highest = currLineNo;
                }

                return highest + 1;
            }
        }

        partial class EOD_LocalCredDataTable
        {
            public delegate void FieldValidationError(string Msg);
            public event FieldValidationError OnFieldValidationError = null;

            public static double GetTotalLocalCreditAmount(DateTime BookDate, TransTypeLocalCred TransType)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select sum(Amount) " +
                    " from EOD_LocalCred " +
                    " where TransType = {0} and BookDate = '{1}' ",
                    (int)TransType,
                    BookDate.Date));
                return tools.object2double(total);
            }

            public static int GetLocalCredRowCount(DateTime BookDate)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select count(*) " +
                    " from EOD_LocalCred " +
                    " where TransType = 1 and BookDate = '{0}' ",
                    BookDate.Date));
                return tools.object2int(total);
            }

            public static int GetLocalCredPayinRowCount(DateTime BookDate)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select count(*) " +
                    " from EOD_LocalCred " +
                    " where TransType = 2 and BookDate = '{0}' ",
                    BookDate.Date));
                return tools.object2int(total);
            }

            #region GetNextLineNo (2 overloads)

            /// <summary>
            /// Returns the next lineno per BookDate and TransType.
            /// Non-static version, that works with in-memory data.
            /// </summary>
            public int GetNextLineNo()
            {
                int highest = 0;
                foreach (DataRow row in this.Rows)
                {
                    if ((row.RowState != DataRowState.Deleted) &&
                        (row.RowState != DataRowState.Detached))
                    {
                        int currLineNo = tools.object2int(row["LineNo"]);
                        if (currLineNo > highest)
                            highest = currLineNo;
                    }
                }
                return highest + 1;
            }

            /// <summary>
            /// Returns the next lineno per Bookdate and TransType.
            /// Static version that works with on-disk data.
            /// </summary>
            public static int GetNextLineNo(DateTime BookDate, TransTypeLocalCred TransactionType)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(@"
                    select max(LineNo)
                    from EOD_localCred
                    where (BookDate = '{0}')
                    and (TransType = {1})
                    ", BookDate.Date, (int)TransactionType))) + 1;
            }

            #endregion

            /// <summary>
            /// Creates a new record in the database on disk.
            /// </summary>
            public static void CreateNewRecord(
                DateTime BookDate,
                TransTypeLocalCred TransactionType,
                int CustomerNo,
                string Remark,
                double Amount)
            {
                BookDate = BookDate.Date;
                int NextLineNo = GetNextLineNo(BookDate, TransactionType);

                db.ExecuteNonQuery(string.Format(@"
                    insert into EOD_LocalCred
                    (BookDate,LineNo,TransType,CustomerNo,Remark,Amount)
                    values ({0},{1},{2},{3},{4},{5})
                    ",
                     tools.datetime4sql(BookDate),
                     tools.wholenumber4sql(NextLineNo),
                     tools.wholenumber4sql((int)TransactionType),
                     tools.wholenumber4sql(CustomerNo),
                     tools.string4sql(Remark, 25),
                     tools.decimalnumber4sql(Amount)));
            }

            protected override void OnColumnChanging(DataColumnChangeEventArgs e)
            {
                if (e.Column == columnCustomerNo)
                {
                    // when user has selected/entered a customerno,
                    // we want to validate that this customer actually exists
                    int CustomerNo = tools.object2int(e.ProposedValue);
                    if (!EOD_DebtorDataTable.DebtorExists(CustomerNo))
                    {
                        e.ProposedValue = DBNull.Value;
                        if (OnFieldValidationError != null)
                            OnFieldValidationError(db.GetLangString("EOD_LocalCredDataTable.DebtorDoesNotExist"));
                    }
                }

                base.OnColumnChanging(e);
            }

            public static DateTime GetFirstDate(int? CustomerNo)
            {
                string sql = " SELECT min(BookDate) FROM EOD_LocalCred ";
                if (CustomerNo.HasValue)
                    sql += " WHERE CustomerNo = " + CustomerNo.Value;
                return tools.object2datetime(db.ExecuteScalar(sql));
            }

            public static DateTime GetLastDate(int? CustomerNo)
            {
                string sql = " SELECT max(BookDate) FROM EOD_LocalCred ";
                if (CustomerNo.HasValue)
                    sql += " WHERE CustomerNo = " + CustomerNo.Value;
                return tools.object2datetime(db.ExecuteScalar(sql));
            }
        }



        partial class EOD_BankCardsDataTable
        {
            public static bool HasRecords(DateTime BookDate)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(@"
                    select count(*) from EOD_BankCards
                    where BookDate = '{0}'
                    ", BookDate.Date))) > 0;
            }

            public static double GetTotalBankCardsAmount(DateTime BookDate)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select sum(Amount) " +
                    " from EOD_BankCards " +
                    " where BookDate = '{0}'",
                    BookDate.Date));
                return tools.object2double(total);
            }

            public static int GetBankCardsRowCount(DateTime BookDate)
            {
                object total = db.ExecuteScalar(string.Format(
                    " select count(*) " +
                    " from EOD_BankCards " +
                    " where BookDate = '{0}' ",
                    BookDate.Date));
                return tools.object2int(total);
            }

            /// <summary>
            /// Gets the next lineno for the currently loaded table data.
            /// </summary>
            public int GetNextLineNo()
            {
                int highest = 0;
                foreach (DataRow row in this.Rows)
                {
                    if ((row.RowState != DataRowState.Deleted) &&
                        (row.RowState != DataRowState.Detached))
                    {
                        int currLineNo = tools.object2int(row["LineNo"]);
                        if (currLineNo > highest)
                            highest = currLineNo;
                    }
                }
                return highest + 1;
            }

            /// <summary>
            /// Gets the next lineno for the given BookDate.
            /// Static method that works with on-disk data.
            /// </summary>
            public static int GetNextLineNo(DateTime BookDate)
            {
                object o = db.ExecuteScalar(string.Format(
                    " select max([LineNo]) " +
                    " from EOD_BankCards " +
                    " where BookDate = '{0}' ",
                    BookDate.Date));
                return tools.object2int(o) + 1;
            }

            /// <summary>
            /// Creates a record for the DETAIL version.
            /// </summary>
            public static void CreateRecord_DETAIL(
                DateTime BookDate,
                string Korttype,
                double TotalBeloeb)
            {
                int LineNo = GetNextLineNo(BookDate);

                db.ExecuteNonQuery(string.Format(@"
                    insert into EOD_BankCards (BookDate,LineNo,MOPCode,Description,Amount)
                    values ({0},{1},{2},{3},{4})
                    ",
                     tools.datetime4sql(BookDate),
                     LineNo,
                     tools.string4sql(Korttype, 10),
                     tools.string4sql(Korttype, 25),
                     tools.decimalnumber4sql(TotalBeloeb)));
            }

            public static void DeleteRecords(DateTime BookDate)
            {
                db.ExecuteNonQuery(string.Format(@"
                    delete from EOD_BankCards
                    where BookDate = '{0}'
                    ", BookDate.Date));
            }

            protected override void OnColumnChanging(DataColumnChangeEventArgs e)
            {
                if (e.Column != BookDateColumn && e.Column != LineNoColumn)
                {
                    // get the bookdate of the open day
                    DataRow EODReconcileRow = EODReconcileDataTable.GetCurrentOpenDay();
                    DateTime BookDate = DateTime.MinValue;
                    if (EODReconcileRow != null)
                        BookDate = tools.object2datetime(EODReconcileRow["BookDate"]).Date;

                    if (BookDate != DateTime.MinValue)
                    {
                        if (tools.IsNullOrDBNull(e.Row[BookDateColumn]))
                            e.Row[BookDateColumn] = BookDate;
                    }

                    if (tools.IsNullOrDBNull(e.Row[LineNoColumn]))
                        e.Row[LineNoColumn] = GetNextLineNo(BookDate);
                }

                base.OnColumnChanging(e);
            }
        }



        partial class EODReconcileDataTable
        {
            public static bool CreateNewDayRecord()
            {
                DateTime BookDate = DateTime.MinValue;

                // check that no day is open, if there is, give error
                string sql = "select BookDate from EODReconcile where Closed <> 1";
                if (db.GetDataTable(sql).Rows.Count > 0)
                {
                    System.Windows.Forms.MessageBox.Show(db.GetLangString("EODDataSet.EODReconcileDataTable.CannotOpenNewDay"));
                    return false;
                }

                // attempt to get the latest BookDate (if any)
                object oLastDate = db.ExecuteScalar(" select max(BookDate) from EODReconcile ");

                // check if this is the very first record
                // and create a new record if it is
                if (tools.IsNullOrDBNull(oLastDate))
                {
                    // ask user for the very first date
                    EOD_PromptFirstDate prompt = new EOD_PromptFirstDate();
                    if (prompt.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        // user has selected a first date, use it in the first record
                        BookDate = prompt.SelectedBookDate;
                    }
                    else
                    {
                        // date selection aborted by user
                        return false;
                    }
                }
                else
                {
                    // oLastDate contains the latest date, so increment
                    // it by one and use it for the new record
                    BookDate = tools.object2datetime(oLastDate).AddDays(1);
                }

                // make sure we only have the date part
                BookDate = BookDate.Date;

                // create the new record
                db.ExecuteNonQuery(string.Format(
                    " insert into EODReconcile (BookDate) values ('{0}') ",
                    BookDate));

#if DETAIL
                // the detail records were created before the header record
                // so we just need to calculate and write the totals
                ImportConcernoPOS.CalculateTotalsAndWriteToEODReconcile(BookDate);
#elif !RBA
                // import RSM data into the new record
                ImportRSMDataForEOD(BookDate);
#endif

                // record created successfully
                return true;
            }

            public static void ImportRSMDataForEOD(DateTime BookDate)
            {
                DataTable table = new DataTable();

                #region Import data from Import_RPOS_MCM_Details to EOD_Sales

                // remove existing imported EOD_Sales data
                db.ExecuteNonQuery(string.Format(
                    " delete from EOD_Sales " +
                    " where (BookDate = '{0}') " +
                    " and TransType = {1} ",
                    BookDate.Date, (int)TransTypeSales.POSSales));

                // import data
                table = db.GetDataTable(string.Format(
                    " select * from Import_RPOS_MCM_Details " +
                    " where BookDate = '{0}' ",
                    BookDate.Date));
                foreach (DataRow row in table.Rows)
                {


                    //peter 20220704

                    db.ExecuteNonQuery(string.Format(
                        " insert into EOD_Sales " +
                        " (BookDate,[LineNo],TransType,SubCategory,SubCatDesc,GLFinance,GLFinDesc,NumberOf,Amount) " +
                        " values ({0},{1},{2},{3},{4},{5},{6},{7},{8}) ",
                        "'" + BookDate + "'",
                        row["LineNo"],
                        (int)TransTypeSales.POSSales,
                        "'" + row["MerchCode"] + "'",
                        "'" + ItemDataSet.SubCategoryDataTable.GetSubCategoryDescription(row["MerchCode"].ToString()) + "'",
                        "NULL", // @@@ todo
                        "NULL", // @@@ todo
                        tools.decimalnumber4sql(tools.object2double(row["SalesQuantity2"])),

                        tools.decimalnumber4sql(tools.object2double(row["SalesAmount"]))));
                }

                // calculate total for EODReconcile.POSSales
                double totalPOSSales = EOD_SalesDataTable.GetTotalSalesAmount(BookDate, TransTypeSales.POSSales);
                db.ExecuteNonQuery(string.Format(
                    " update EODReconcile " +
                    " set POSSales = {0} " +
                    " where BookDate = '{1}' ",
                    tools.decimalnumber4sql(totalPOSSales), BookDate.Date));

                #endregion

                #region Import data from Import_RPOS_MSM_Details to EOD_BankCards and EOD_ShellCards

                // we loop two times, the first time working with EOD_BankCards
                // and the second time working with EOD_ShellCards. this way we
                // only need to write the code once as the import for the two
                // tables is identical.
                //for (int i = 0; i < 3; i++)
                //extra loop imlementet for SafePay

                for (int i = 0; i < 4; i++)
                {
                    // select to work with either EOD_BankCards or EOD_ShellCards

                    string EODTable = "EOD_BankCards";
                    string IncludeCode = "BANKC";
                    string EODReconcileField = "BankCardAmount";



                    if (i == 1)
                    {
                        EODTable = "EOD_ShellCards";
                        IncludeCode = "SHELLC";
                        EODReconcileField = "ShellCardAmount";
                    }
                    else if (i == 2)
                    {
                        EODTable = "EOD_Discounts";
                        IncludeCode = "DISCNT";
                        EODReconcileField = "DiscountAmount";
                    }
                    else if (i == 3)
                    {

                        EODTable = "EOD_SafePay_Currencies";
                        IncludeCode = "SPCUR";
                        EODReconcileField = "SafePayAmountCurr";


                    }



                    // remove existing imported EOD_BankCards data
                    //20200123
                    if (!db.GetConfigStringAsBool("MergeFiles")) //2020012PN         
                    {
                        db.ExecuteNonQuery(string.Format(
                        " delete from {0} " +
                        " where (BookDate = '{1}') ",
                        EODTable, BookDate.Date));
                    }
                    // import dta
                    //20181008
                    table = db.GetDataTable(string.Format(
                       " select details.SummaryCode ,details.SubCode ,details.Modifier as MOPCode," +
                       " config.ModifierDesc as Description,details.Amount " +
                       " from Import_RPOS_MSM_Config config " +
                       " inner join Import_RPOS_MSM_Details details " +
                       " on config.SummaryCode = details.SummaryCode " +
                       " and config.SubCode = details.SubCode " +
                       " and config.Modifier = details.Modifier " +
                       " where (details.BookDate = '{0}') " +
                       " and (config.IncludeCode = '{1}') ",
                       BookDate.Date, IncludeCode));





                    foreach (DataRow row in table.Rows)
                    {
                        int nextLineNo = 0;
                        //>>pn20210728
                        //if (i == 1) nextLineNo = EOD_ShellCardsDataTable.GetNextLineNo(BookDate);
                        //else nextLineNo = EOD_BankCardsDataTable.GetNextLineNo(BookDate);


                        switch (i)
                        {
                            case 1:
                                nextLineNo = EOD_ShellCardsDataTable.GetNextLineNo(BookDate);
                                break;
                            case 2:
                                nextLineNo = EOD_BankCardsDataTable.GetNextLineNo(BookDate);
                                break;
                            case 3:
                                nextLineNo = EOD_SafePay_CurrenciesDataTable.GetSafePayCurrRowCount(BookDate) + 1;
                                break;

                        }
                        //<<pn20210728

                        db.ExecuteNonQuery(string.Format(
                            " insert into {0} " +
                            " (BookDate,[LineNo],MOPCode,Description,Amount) " +
                            " values ({1},{2},{3},{4},{5}) ",
                            EODTable,
                            "'" + BookDate + "'",
                            nextLineNo,
                            "'" + row["MOPCode"] + "'",
                            "'" + tools.TruncString(row["Description"].ToString().Replace("'", ""), 24) + "'",
                             tools.decimalnumber4sql(tools.object2double(row["Amount"]))));
                    }

                    // calculate total for EODReconcile.BankCardAmount
                    double total = 0;
                    if (i == 1) total = EODDataSet.EOD_ShellCardsDataTable.GetTotalShellCardsAmount(BookDate);
                    else if (i == 2) total = EODDataSet.EOD_DiscountsDataTable.GetTotalDiscountsAmount(BookDate);
                    //else if (i == 3) total = EOD_SafePay_CurrenciesDataTable.GetTotalSafePayCurrAmount(BookDate);
                    else if (i == 3) total = EODDataSet.EOD_SafePay_DepotbeholdningDataTable.GetTotalSafePayCurrAmountDKK(BookDate);

                    else total = EOD_BankCardsDataTable.GetTotalBankCardsAmount(BookDate);
                    db.ExecuteNonQuery(string.Format(
                        " update EODReconcile " +
                        " set {0} = {1} " +
                        " where BookDate = '{2}' ",
                        EODReconcileField, tools.decimalnumber4sql(total), BookDate.Date));
                }

                #endregion

                #region Import misc single values from Import_RPOS_MSM_Details to EOD_Reconcile




                // import drive off value 20200326
                double drvoff = tools.object2double(db.ExecuteScalar(string.Format(
                    " select sum(details.Amount) " +
                    " from Import_RPOS_MSM_Config config " +
                    " inner join Import_RPOS_MSM_Details details " +
                    " on config.SummaryCode = details.SummaryCode " +
                    " and config.SubCode = details.SubCode " +
                    " and config.Modifier = details.Modifier " + // 20200327
                    " where (details.BookDate = '{0}') " +
                    " and (config.IncludeCode = 'DRVOFF') ",
                    BookDate.Date)));

                // update EODReconcile with drive off value  //pn20190806
                db.ExecuteNonQuery(string.Format(
                    " update EODReconcile " +
                    " set DriveOffTotal = {0} " +
                    " where BookDate = '{1}' ",
                    tools.decimalnumber4sql(drvoff), BookDate.Date));


                //>>PN20200814

                double CashBack = tools.object2double(db.ExecuteScalar(string.Format(
                  " select sum(details.Amount) " +
                  " from Import_RPOS_MSM_Config config " +
                  " inner join Import_RPOS_MSM_Details details " +
                  " on config.SummaryCode = details.SummaryCode " +
                  " and config.SubCode = details.SubCode " +
                  " and details.Modifier = config.Modifier " +
                  " where (details.BookDate = '{0}') " +
                  " and (config.IncludeCode = 'SPDEP') ",
                  BookDate.Date)));

                double SafePay = tools.object2double(db.ExecuteScalar(string.Format(
                  " select sum(details.Amount) " +
                  " from Import_RPOS_MSM_Config config " +
                  " inner join Import_RPOS_MSM_Details details " +
                  " on config.SummaryCode = details.SummaryCode " +
                  " and config.SubCode = details.SubCode " +
                  " and details.Modifier = config.Modifier " +
                  " where (details.BookDate = '{0}') " +
                  " and (config.IncludeCode = 'SAFEPAYDKK') ",
                  BookDate.Date)));



                //<<PN20200814
                // update EODReconcile with Safepayf value  //pn20190806
                db.ExecuteNonQuery(string.Format(
                    " update EODReconcile " +
                    " set SafePayAmount = {0} " +
                    " where BookDate = '{1}' ",
                    tools.decimalnumber4sql(SafePay + CashBack), BookDate.Date));
                //<<PN20200814
                //>>PN20200824
                //if (!db.GetConfigStringAsBool("SafePay.Enabled"))
                //{
                //    db.ExecuteNonQuery(string.Format(
                //    " update EODReconcile " +
                //    " set   BankDepAmount = {0} " +
                //    " where BookDate = '{1}' ",
                //    tools.decimalnumber4sql(SafePay), BookDate.Date));
                //}   
                //<<20200824

                //Import SafePayvaluta value
                //pn20200730                  
                double SafePayCurr = tools.object2double(db.ExecuteScalar(string.Format(
                  " select sum(details.Amount) " +
                  " from Import_RPOS_MSM_Config config " +
                  " inner join Import_RPOS_MSM_Details details " +
                  " on config.SummaryCode = details.SummaryCode " +
                  " and config.SubCode = details.SubCode " +
                  " and details.Modifier = config.Modifier " +
                  " where (details.BookDate = '{0}') " +
                  " and (config.IncludeCode = 'SAFEPAYCUR') ",
                  BookDate.Date)));

                // update EODReconcile with Safepayf value  //pn20190806
                db.ExecuteNonQuery(string.Format(
                    " update EODReconcile " +
                    " set  [SafePayAmountCurr] = {0} " +
                    " where BookDate = '{1}' ",
                    tools.decimalnumber4sql(SafePayCurr), BookDate.Date));
                //pn20200730   
                #endregion

                #region Import data from SparPOS, if active

                ImportSparPOS importSpar = new ImportSparPOS();
                if (importSpar.ImportIsActive())
                {
                    importSpar.ImportSparCatMap();
                    importSpar.ImportSparAccountActions();

                    // delete already imported payin and payout data for this bookdate
                    db.ExecuteNonQuery(string.Format(@"
                        delete from EOD_PayinPayout
                        where (BookDate = '{0}')
                        and (Imported = 1)
                        ", BookDate.Date));

                    table = db.GetDataTable(string.Format(
                        " select * from SparPOSTransactions " +
                        " where BookDate = '{0}' ",
                        BookDate.Date));
                    // get the largest EOD_Sales LineNo for this BookDate,TransType
                    int LargestEODSalesLineNo = tools.object2int(db.ExecuteScalar(string.Format(@"
                        select max(LineNo) from EOD_sales
                        where (BookDate = '{0}')
                        and (TransType = {1})
                        ", BookDate.Date, (int)TransTypeSales.POSSales)));
                    foreach (DataRow row in table.Rows)
                    {
                        // if SparPOSCategory is filled in, this is to be imported in EOD_Sales
                        string SparPOSCategory = tools.object2string(row["Category"]);
                        if (SparPOSCategory != "")
                        {
                            string RBOSSubCategory = ImportDataSet.SparPOSAccountMappingDataTable.LookupRBOSSubCategory(SparPOSCategory);
                            double Amount = tools.object2double(row["Amount"]) * -1;
                            db.ExecuteNonQuery(string.Format(
                                " insert into EOD_Sales " +
                                " (BookDate,LineNo,TransType,SubCategory,SubCatDesc,GLFinance,GLFinDesc,NumberOf,Amount) " +
                                " values ({0},{1},{2},{3},{4},{5},{6},{7},{8}) ",
                                tools.datetime4sql(BookDate),
                                tools.wholenumber4sql(++LargestEODSalesLineNo),
                                tools.wholenumber4sql((int)TransTypeSales.POSSales),
                                tools.string4sql(RBOSSubCategory, 20),
                                tools.string4sql(ItemDataSet.SubCategoryDataTable.GetSubCategoryDescription(RBOSSubCategory), 50),
                                "NULL",
                                "NULL",
                                tools.wholenumber4sql(row["NumberOf"]),
                                tools.decimalnumber4sql(Amount)));
                        }
                        else
                        {
                            string Account = tools.object2string(row["Account"]);
                            string ActionCode = ImportDataSet.SparPOSAccountActionsDataTable.LookupAccountActionCode(Account);
                            switch (ActionCode)
                            {
                                case "BANKC":
                                    int nextLineNo = EOD_BankCardsDataTable.GetNextLineNo(BookDate);
                                    db.ExecuteNonQuery(string.Format(@"
                                        insert into EOD_BankCards
                                        (BookDate,LineNo,MOPCode,Description,Amount)
                                        values ({0},{1},{2},{3},{4})
                                        ",
                                         tools.datetime4sql(BookDate),
                                         tools.wholenumber4sql(nextLineNo),
                                         tools.string4sql(row["Account"], 10),
                                         tools.string4sql(row["Description"], 25),
                                         tools.decimalnumber4sql(row["Amount"])
                                         ));
                                    break;
                                case "PAYIN":
                                    EODDataSet.EOD_PayinPayoutDataTable.CreateNewRecord(
                                        BookDate,
                                        TransTypePayinPayout.Payin,
                                        tools.object2string(row["Description"]),
                                        tools.object2double(row["Amount"]) * -1,
                                        true);
                                    break;
                                case "PAYOUT":
                                    EODDataSet.EOD_PayinPayoutDataTable.CreateNewRecord(
                                        BookDate,
                                        TransTypePayinPayout.Payout,
                                        tools.object2string(row["Description"]),
                                        tools.object2double(row["Amount"]),
                                        true);
                                    break;
                                default:
                                    /* any other account/action is ignored */
                                    break;
                            }
                        }
                    }

                    // calculate total for EODReconcile.POSSales again
                    double total = EOD_SalesDataTable.GetTotalSalesAmount(BookDate, TransTypeSales.POSSales);
                    db.ExecuteNonQuery(string.Format(
                        " update EODReconcile " +
                        " set POSSales = '{0}' " +
                        " where BookDate = '{1}' ",
                        total, BookDate.Date));

                    // calc bank totals again
                    total = EOD_BankCardsDataTable.GetTotalBankCardsAmount(BookDate);
                    db.ExecuteNonQuery(string.Format(
                        " update EODReconcile " +
                        " set BankCardAmount = '{0}' " +
                        " where BookDate = '{1}' ",
                        total, BookDate.Date));

                    // calc payin totals again
                    total = EOD_PayinPayoutDataTable.GetTotalPayinPayoutAmount(BookDate, TransTypePayinPayout.Payin);
                    db.ExecuteNonQuery(string.Format(
                        " update EODReconcile " +
                        " set Payin = '{0}' " +
                        " where BookDate = '{1}' ",
                        total, BookDate.Date));

                    // calc payout totals again
                    total = EOD_PayinPayoutDataTable.GetTotalPayinPayoutAmount(BookDate, TransTypePayinPayout.Payout);
                    db.ExecuteNonQuery(string.Format(
                        " update EODReconcile " +
                        " set Payout = '{0}' " +
                        " where BookDate = '{1}' ",
                        total, BookDate.Date));
                }
                #endregion

                // calculate total fields
                EODReconcileSingleDataTable.CalcTotalsOnDisk(BookDate);
            }

            #region ReImportRSMDataForEOD
            /// <summary>
            /// Deletes data from EOD_BankCards, EOD_ShellCards and EOD_POSSales
            /// where date is equal to the given date. After that it uses the method
            /// ImportRSMDataForEOD to do the import.
            /// Static method that works with on-disk data.
            /// </summary>
            public static void ReImportRSMDataForEOD(DateTime BookDate)
            {
                // delete data from tables EOD_BankCards, EOD_ShellCards and EOD_POSSales
                if (!db.GetConfigStringAsBool("MergeFiles")) //2020012PN         
                {
                    string test = string.Format("delete from EOD_ShellCards where BookDate = '{0}'", BookDate.Date);

                    db.ExecuteNonQuery(string.Format("delete from EOD_BankCards where BookDate = '{0}'", BookDate));
                    db.ExecuteNonQuery(string.Format("delete from EOD_ShellCards where BookDate = '{0}'", BookDate.Date));
                    db.ExecuteNonQuery(string.Format("delete from EOD_Sales where (BookDate = '{0}') and (TransType = {1})", BookDate.Date, (int)TransTypeSales.POSSales));
                    db.ExecuteNonQuery(string.Format("delete from EOD_Discounts where BookDate = '{0}'", BookDate.Date));
                    db.ExecuteNonQuery(string.Format("delete from EOD_SafePay_Currencies where BookDate = '{0}'", BookDate.Date));
                }
                // import data
                ImportRSMDataForEOD(BookDate);
            }
            #endregion

            #region METHOD: GetLastBookDate
            /// <summary>
            /// Returns the last bookdate.
            /// If no records are found, DateTime.MinValue is returned.
            /// </summary>
            public static DateTime GetLastBookDate()
            {
                return tools.object2datetime(db.ExecuteScalar(
                    " select max(BookDate) " +
                    " from EODReconcile "));
            }
            #endregion

            #region GetCurrentOpenDay
            /// <summary>
            /// Returns the record that has a BookDate
            /// and that is not closed. Null is returned if
            /// no record was found matching the criteria.
            /// </summary>
            public static DataRow GetCurrentOpenDay()
            {
                return db.GetDataRow(string.Format(@"
                    select * from EODReconcile
                    where (BookDate is not null)
                    and (Closed <> 1)
                    "));
            }
            #endregion

            #region CreateNewRecordWhenMigratingFromRBA
            /// <summary>
            /// Opretter en dagsopgørelsesrecord
            /// i forbindelse med migrering af data
            /// fra en RBA SSIP database. Hvis en bogføringsdato
            /// allerede findes, slettes recorden databasen først.
            /// Listen af parametre har ikke alle felter i tabellen,
            /// da der ikke migreres alle felter og nogle felter
            /// er hardcoded i metoden til en bestemt værdi.
            /// Grunden til at alle parametre er objects er,
            /// at det skal være nemt at kalde metoden, når man står med
            /// et generisk DataRow object og hiver feltværdier ud. Metoden
            /// håndterer selv konvertering af parametrene til typestærke værdier.
            /// </summary>
            public static void CreateNewRecordWhenMigratingFromRBA(
                object BookDate,
                object BankDepAmount,
                object ManDankortSumB,
                object CashDiscount,
                object LocalCredit,
                object LocalCreditPayin,
                object ForeignCurrency,
                object Payin,
                object Payout,
                object NumberOfWashSold)
            {
                // konvertér bogføringsdatoen til datetime, så den er lettere at arbejde med
                DateTime dtBookDate = tools.object2datetime(BookDate).Date;

                // hvis der allerede findes en record med den angivne bogføringsdato,
                // skal recorden i databasen slettes først.
                if (RecordExists(dtBookDate))
                    DeleteRecord(dtBookDate);

                // opret recorden
                db.ExecuteNonQuery(string.Format(@"
                    insert into EODReconcile
                    (BookDate,Closed,BankDepAmount,ManDankortSumB,CashDiscount,
                     LocalCredit,LocalCreditPayin,ForeignCurrency,Payin,Payout,
                     ApprovedBy,NumberOfWashSold)
                    values ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11})
                    ",
                     tools.datetime4sql(dtBookDate),
                     true,
                     tools.decimalnumber4sql(BankDepAmount),
                     tools.decimalnumber4sql(ManDankortSumB),
                     tools.decimalnumber4sql(CashDiscount),
                     tools.decimalnumber4sql(LocalCredit),
                     tools.decimalnumber4sql(LocalCreditPayin),
                     tools.decimalnumber4sql(ForeignCurrency),
                     tools.decimalnumber4sql(Payin),
                     tools.decimalnumber4sql(Payout),
                     "'MIGR'",
                     tools.wholenumber4sql(NumberOfWashSold)
                     ));
            }
            #endregion

            #region RecordExists
            public static bool RecordExists(DateTime BookDate)
            {
                return (tools.object2int(db.ExecuteScalar(string.Format(@"
                    select count(*) from EODReconcile
                    where BookDate = '{0}'
                    ", BookDate.Date))) > 0);
            }
            #endregion

            #region IsDayClosed
            public static bool IsDayClosed(DateTime BookDate)
            {
                return (tools.object2int(db.ExecuteScalar(string.Format(@"
                    select count(*) from EODReconcile
                    where BookDate = '{0}'
                    and Closed = 1
                    ", BookDate.Date))) > 0);
            }
            #endregion

            #region DeleteRecord
            /// <summary>
            /// Metoden er gjort private til at starte med, da den
            /// ved oprettelsen bruges internt i klassen og det er
            /// en lidt uheldig metode blot at stille public, da den sletter en record
            /// uden videre, hvis den finder en record med den angivne bogføringsdato.
            /// </summary>
            /// <param name="BookDate"></param>
            private static void DeleteRecord(DateTime BookDate)
            {
                db.ExecuteNonQuery(string.Format(@"
                    delete from EODReconcile
                    where BookDate = '{0}'
                    ", BookDate.Date));
            }
            #endregion

            public static void UpdateRecord_DETAIL(
                DateTime BookDate,
                double EOD_Sales_Total,
                double EOD_BankCards_Total,
                double EOD_DETAIL_Valuta_Total,
                double EOD_Payin_Total,
                double EOD_Payout_Total)
            {
                db.ExecuteNonQuery(string.Format(@"
                    update EODReconcile set
                    POSSales = {1},
                    BankCardAmount = {2},
                    ForeignCurrency = {3},
                    Payin = {4},
                    Payout = {5}
                    where BookDate = '{0}'",
                     BookDate.Date,
                     tools.decimalnumber4sql(EOD_Sales_Total),
                     tools.decimalnumber4sql(EOD_BankCards_Total),
                     tools.decimalnumber4sql(EOD_DETAIL_Valuta_Total),
                     tools.decimalnumber4sql(EOD_Payin_Total),
                     tools.decimalnumber4sql(EOD_Payout_Total)));
            }
        }

        partial class EODReconcileExDataTable
        {
            public static void InsertOrUpdateRecord(DateTime BookDate, int CustomerCount)
            {
                InsertOrUpdateRecord(BookDate, CustomerCount, null);
            }

            public static void InsertOrUpdateRecord(DateTime BookDate, int CustomerCount, Nullable<int> CustomerCountOriginalFromPOS)
            {
                string sql;
                if (RecordExists(BookDate))
                {
                    if (CustomerCountOriginalFromPOS.HasValue)
                    {
                        sql = string.Format(@"
                            update EODReconcileEx
                            set CustomerCount = {1}, CustomerCountOriginalFromPOS = {2}
                            where BookDate = '{0}'", BookDate.Date, CustomerCount, CustomerCountOriginalFromPOS);
                    }
                    else
                    {
                        sql = string.Format(@"
                            update EODReconcileEx
                            set CustomerCount = {1}
                            where BookDate = '{0}'", BookDate.Date, CustomerCount);
                    }
                }
                else
                {
                    if (CustomerCountOriginalFromPOS.HasValue)
                    {
                        sql = string.Format(@"
                            insert into EODReconcileEx
                            (BookDate,CustomerCount,CustomerCountOriginalFromPOS)
                            values ({0},{1},{2})
                        ",
                         tools.datetime4sql(BookDate),
                         tools.wholenumber4sql(CustomerCount),
                         tools.wholenumber4sql(CustomerCountOriginalFromPOS));
                    }
                    else
                    {
                        sql = string.Format(@"
                            insert into EODReconcileEx
                            (BookDate,CustomerCount)
                            values ({0},{1})
                        ",
                             tools.datetime4sql(BookDate),
                             tools.wholenumber4sql(CustomerCount));
                    }
                }
                db.ExecuteNonQuery(sql);
            }

            public static int GetCustomerCount(DateTime BookDate)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(@"
                    select CustomerCount
                    from EODReconcileEx
                    where BookDate = '{0}'
                    ", BookDate.Date)));
            }

            public static int GetCustomerCount(DateTime StartDate, DateTime EndDate)
            {
                using (OleDbConnection conn = new OleDbConnection(db.ConnectionString))
                {
                    string sql = @"
                        select sum(CustomerCount)
                        from EODReconcileEx
                        where BookDate >= ?
                        and BookDate <= ?
                        ";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.Add("StartDate", OleDbType.Date).Value = StartDate;
                        cmd.Parameters.Add("EndDate", OleDbType.Date).Value = EndDate;
                        conn.Open();
                        return tools.object2int(cmd.ExecuteScalar());
                    }
                }
            }

            public static bool RecordExists(DateTime BookDate)
            {
                return (tools.object2int(db.ExecuteScalar(string.Format(@"
                    select count(*) from EODReconcileEx
                    where BookDate = '{0}'
                    ", BookDate.Date))) > 0);
            }
        }
    }
}
