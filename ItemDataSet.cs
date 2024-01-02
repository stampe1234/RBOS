using System;
using System.Data;
using System.Data.OleDb;
using System.Data.Sql;

using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace RBOS.ItemDataSetTableAdapters
{
    partial class WasteSheetDetailsTableAdapter
    {
    }

    partial class InactiveItemTableAdapter
    {
    }

    partial class ChainItemTableAdapter
    {
    }

    partial class BookedInvCountDetailTableAdapter
    {
    }

    partial class OrderDraftSingleTableAdapter
    {
    }

    partial class InvCountWorkTableAdapter
    {
    }

    partial class BookedInvCountHeaderTableAdapter
    {
    }

    partial class SalesPackFuturePricesPromptTableAdapter
    {
    }

    partial class LookupBarcodeTypeTableAdapter
    {
    }

    partial class LookupPackSizeTableAdapter
    {
    }
    #region PARTIAL CLASS: ItemTableAdapter

    /// <summary>
    /// Custom addons for the ItemTableAdapter.
    /// </summary>
    public partial class ItemTableAdapter : System.ComponentModel.Component
    {
        /// <summary>
        /// Custom property for getting the UpdateCommand.
        /// </summary>
        public OleDbCommand UpdateCommand
        {
            get { return this._adapter.UpdateCommand; }
        }

        /// <summary>
        /// Custom property for getting the InsertCommand.
        /// </summary>
        public OleDbCommand InsertCommand
        {
            get { return this._adapter.InsertCommand; }
        }
    }

    #endregion

    #region PARTIAL CLASS: SalesPackTableAdapter

    /// <summary>
    /// Custom addons for the SalesPackTableAdapter.
    /// </summary>
    public partial class SalesPackTableAdapter : System.ComponentModel.Component
    {
        /// <summary>
        /// Custom property for getting the UpdateCommand.
        /// </summary>
        public OleDbCommand UpdateCommand
        {
            get { return this._adapter.UpdateCommand; }
        }

        /// <summary>
        /// Custom property for getting the InsertCommand.
        /// </summary>
        public OleDbCommand InsertCommand
        {
            get { return this._adapter.InsertCommand; }
        }
    }

    #endregion

    #region PARTIAL CLASS: BarcodeTableAdapter

    /// <summary>
    /// Custom addons for the BarcodeTableAdapter.
    /// </summary>
    public partial class BarcodeTableAdapter : System.ComponentModel.Component
    {
        /// <summary>
        /// Custom property for getting the UpdateCommand.
        /// </summary>
        public OleDbCommand UpdateCommand
        {
            get { return this._adapter.UpdateCommand; }
        }

        /// <summary>
        /// Custom property for getting the InsertCommand.
        /// </summary>
        public OleDbCommand InsertCommand
        {
            get { return this._adapter.InsertCommand; }
        }
    }

    #endregion

    #region PARTIAL CLASS: SalesPackFuturePricesTableAdapter

    /// <summary>
    /// Custom addons for the SalesPackFuturePricesTableAdapter.
    /// </summary>
    public partial class SalesPackFuturePricesTableAdapter : System.ComponentModel.Component
    {
        /// <summary>
        /// Custom property for getting the UpdateCommand.
        /// </summary>
        public OleDbCommand UpdateCommand
        {
            get { return this._adapter.UpdateCommand; }
        }

        /// <summary>
        /// Custom property for getting the InsertCommand.
        /// </summary>
        public OleDbCommand InsertCommand
        {
            get { return this._adapter.InsertCommand; }
        }
        
        /// <summary>
        /// Custom property for getting the DeleteCommand.
        /// </summary>
        public OleDbCommand DeleteCommand
        {
            get { return this._adapter.DeleteCommand; }
        }
    }

    #endregion

    #region PARTIAL CLASS: SupplierItemTableAdapter

    /// <summary>
    /// Custom addons for the SupplierItemTableAdapter.
    /// </summary>
    public partial class SupplierItemTableAdapter : System.ComponentModel.Component
    {
        /// <summary>
        /// Custom property for getting the UpdateCommand.
        /// </summary>
        public OleDbCommand UpdateCommand
        {
            get { return this._adapter.UpdateCommand; }
        }

        /// <summary>
        /// Custom property for getting the InsertCommand.
        /// </summary>
        public OleDbCommand InsertCommand
        {
            get { return this._adapter.InsertCommand; }
        }

        /// <summary>
        /// Custom property for getting the DeleteCommand.
        /// </summary>
        public OleDbCommand DeleteCommand
        {
            get { return this._adapter.DeleteCommand; }
        }
    }

    #endregion

    #region PARTIAL CLASS: SubCategoryTableAdapter

    /// <summary>
    /// Custom addons for the SubCategoryTableAdapter.
    /// </summary>
    public partial class SubCategoryTableAdapter : System.ComponentModel.Component
    {
        /// <summary>
        /// Custom property for getting the UpdateCommand.
        /// </summary>
        public OleDbCommand UpdateCommand
        {
            get { return this._adapter.UpdateCommand; }
        }

        /// <summary>
        /// Custom property for getting the InsertCommand.
        /// </summary>
        public OleDbCommand InsertCommand
        {
            get { return this._adapter.InsertCommand; }
        }
    }

    #endregion

    #region PARTIAL CLASS: ExportFVDHeaderTableAdapter

    /// <summary>
    /// Custom addons for the ExportFVDHeaderTableAdapter.
    /// </summary>
    public partial class ExportFVDHeaderTableAdapter : System.ComponentModel.Component
    {
        public void SetTransaction(OleDbTransaction Transaction)
        {
            this._adapter.SelectCommand.Transaction = Transaction;
            this._adapter.InsertCommand.Transaction = Transaction;
            this._adapter.UpdateCommand.Transaction = Transaction;
            this._adapter.DeleteCommand.Transaction = Transaction;
        }
    }

    #endregion

    public partial class AfskrProdTableAdapter
    {
        public void SetTransaction(OleDbTransaction Transaction)
        {
            foreach (OleDbCommand cmd in this._commandCollection)
                cmd.Transaction = Transaction;
        }
    }

    public partial class ForbrugsvareTableAdapter
    {
        public void SetTransaction(OleDbTransaction Transaction)
        {
            foreach (OleDbCommand cmd in this._commandCollection)
                cmd.Transaction = Transaction;
        }
    }
}

namespace RBOS
{

    /// <summary>
    /// Custom code on the ItemDataSet.
    /// 
    /// IMPORTANT: Whenever working with fields in the tables Item, SalesPack or Barcode,
    /// make sure you don't inadvertently update fields that don't need update. This is
    /// because we have a rule saying, that when certain fields
    /// (almost all non-calculated and non-foreign key fields) changes, the flag
    /// UpdateRSM is set to true. This will lead to the item/salespack/barcode being
    /// sent to the RSM (Radiant Site Manager) / POS.
    /// Fields that don't need update are fields that are overwritten with
    /// the same values as what they already had or fields that are changed
    /// while just browsing data without editing anything, usually caused by
    /// validation events, gui clicks/checks, row leaves etc.
    /// *** The way to check if you are having fields that inadvertenly sets
    /// *** UpdateRSM flag, is to check if it has been set in the GUI / DB.
    /// </summary>
    partial class ItemDataSet
    {
        partial class WasteSheetHeaderLookupsDataTable
        {
        }

        partial class LookupKolliSizeDataTable
        {
        }

        partial class ChainItemDataTable
        {
        }

        partial class FutureCostPricesDataTable
        {
            #region CheckIfAnyCostPricesAreDue
            public static bool CheckIfAnyCostPricesAreDue()
            {
                ItemDataSetTableAdapters.FutureCostPricesTableAdapter adapter =
                    new RBOS.ItemDataSetTableAdapters.FutureCostPricesTableAdapter();
                adapter.Connection = db.Connection;
                return adapter.GetData().Rows.Count > 0;
            }
            #endregion



        }

        partial class DataTable1DataTable
        {
        }

        partial class LookupBarcodeNameDataTable
        {
        }

        partial class LookupSubCategoryDataTable
        {
        }
        #region StockCountRegistrationRBADataTable
        partial class StockCountRegistrationRBADataTable
        {
            private bool SettingMutualValues_Varenummer_Barcode = false;

            #region OnMultipleVareFoundByVarenummer
            // event for letting GUI handle that more than one vare has been found by Varenummer
            public delegate void MultipleVareFoundByVarenummer(out int LevNr, double Varenummer);
            public event MultipleVareFoundByVarenummer OnMultipleVareFoundByVarenummer = null;
            #endregion

            #region OnMultipleVareFoundByBarcode
            // event for letting GUI handle that more than one vare has been found by Barcode
            public delegate void MultipleVareFoundByBarcode(out int LevNr, out double Varenummer, double Barcode);
            public event MultipleVareFoundByBarcode OnMultipleVareFoundByBarcode = null;
            #endregion

            #region OnLookupValuesChanged
            // event for letting GUI know that lookup values has changed
            // so GUI needs to update the grid
            public delegate void LookupValuesChanged();
            public event LookupValuesChanged OnLookupValuesChanged = null;
            #endregion

            #region OnColumnChanged
            protected override void OnColumnChanged(DataColumnChangeEventArgs e)
            {
                if (e.Column == VarenummerColumn)
                {
                    if (!SettingMutualValues_Varenummer_Barcode)
                    {
                        // clear fields
                        SettingMutualValues_Varenummer_Barcode = true;
                        e.Row[BarcodeColumn] = DBNull.Value;
                        SettingMutualValues_Varenummer_Barcode = false;
                        e.Row[VarenavnColumn] = DBNull.Value;
                        e.Row[LevNrColumn] = DBNull.Value;
                        e.Row[VaregruppeColumn] = DBNull.Value;
                        e.Row[KostprisExMomsColumn] = DBNull.Value;
                        e.Row[IaltColumn] = DBNull.Value;
                        e.Row[AntalColumn] = DBNull.Value; // and clear the Antal field

                        // extract just entered Varenummer
                        double Varenummer = tools.object2double(e.ProposedValue);

                        int LevNr = 0;

                        // attempt to find the vare in the catalog
                        int num = AfskrProdDataTable.GetNumRecordsByVarenummer(Varenummer);
                        if (num > 1)
                        {
                            // more that one vare found, so user
                            // has to select the one needed and LevNr will be set,
                            // so invoke the event handler
                            if (OnMultipleVareFoundByVarenummer != null)
                                OnMultipleVareFoundByVarenummer(out LevNr, Varenummer);
                        }
                        else if (num == 1)
                        {
                            LevNr = AfskrProdDataTable.GetLevNr(Varenummer);
                        }

                        // if LevNr is greater than 0, one vare record was found,
                        // and the lookup values can be set
                        if (LevNr > 0)
                        {
                            DataRow row = AfskrProdDataTable.GetRecord(LevNr, Varenummer);
                            if (row != null)
                            {
                                e.Row[LevNrColumn] = row["LevNr"];
                                e.Row[VarenavnColumn] = row["Beskrivelse"];
                                e.Row[KostprisExMomsColumn] = tools.DeductVAT(tools.object2double(row["Kostpris"]), tools.object2string(row["Varegruppe"]));
                                e.Row[VaregruppeColumn] = row["Varegruppe"];
                                SettingMutualValues_Varenummer_Barcode = true;
                                e.Row[BarcodeColumn] = row["Barcode"];
                                SettingMutualValues_Varenummer_Barcode = false;

                                // let GUI know that it needs to refresh the grid
                                if (OnLookupValuesChanged != null)
                                    OnLookupValuesChanged();
                            }
                        }
                    }
                }
                else if (e.Column == BarcodeColumn)
                {
                    if (!SettingMutualValues_Varenummer_Barcode)
                    {
                        // clear fields
                        SettingMutualValues_Varenummer_Barcode = true;
                        e.Row[VarenummerColumn] = DBNull.Value;
                        SettingMutualValues_Varenummer_Barcode = false;
                        e.Row[VarenavnColumn] = DBNull.Value;
                        e.Row[LevNrColumn] = DBNull.Value;
                        e.Row[VaregruppeColumn] = DBNull.Value;
                        e.Row[KostprisExMomsColumn] = DBNull.Value;
                        e.Row[IaltColumn] = DBNull.Value;
                        e.Row[AntalColumn] = DBNull.Value;

                        // extract just entered Barcode
                        double Barcode = tools.object2double(e.ProposedValue);

                        int LevNr = 0;
                        double Varenummer = 0;

                        // attempt to find the vare in the catalog
                        int num = AfskrProdDataTable.GetNumRecordsByBarcode(Barcode);
                        if (num > 1)
                        {
                            // more that one vare found, so user
                            // has to select the one needed and LevNr will be set,
                            // so invoke the event handler
                            if (OnMultipleVareFoundByBarcode != null)
                                OnMultipleVareFoundByBarcode(out LevNr, out Varenummer, Barcode);
                        }
                        else if (num == 1)
                        {
                            AfskrProdDataTable.GetPrimaryKey(Barcode, out LevNr, out Varenummer);
                        }

                        // if LevNr and Varenummer are greater than 0, one vare record was found,
                        // and the lookup values can be set
                        if ((LevNr > 0) && (Varenummer > 0))
                        {
                            DataRow row = AfskrProdDataTable.GetRecord(LevNr, Varenummer);
                            if (row != null)
                            {
                                e.Row[LevNrColumn] = row["LevNr"];
                                SettingMutualValues_Varenummer_Barcode = true;
                                e.Row[VarenummerColumn] = row["Varenummer"];
                                SettingMutualValues_Varenummer_Barcode = false;
                                e.Row[VarenavnColumn] = row["Beskrivelse"];
                                e.Row[KostprisExMomsColumn] = tools.DeductVAT(tools.object2double(row["Kostpris"]), tools.object2string(row["Varegruppe"]));
                                e.Row[VaregruppeColumn] = row["Varegruppe"];

                                // let GUI know that it needs to refresh the grid
                                if (OnLookupValuesChanged != null)
                                    OnLookupValuesChanged();
                            }
                        }
                    }
                }
                else if (e.Column == AntalColumn)
                {
                    /// When setting the Antal column,
                    /// we want to calculate the Ialt column.

                    e.Row[IaltColumn] = DBNull.Value;
                    int Antal = tools.object2int(e.ProposedValue);
                    if (Antal > 0)
                    {
                        double KostExMoms = tools.object2double(e.Row["KostprisExMoms"]);
                        e.Row[IaltColumn] = Antal * KostExMoms;

                        // let GUI know that it needs to refresh the grid
                        if (OnLookupValuesChanged != null)
                            OnLookupValuesChanged();
                    }
                }

                base.OnColumnChanged(e);
            }
            #endregion

            #region Book
            public bool Book(out string ErrorMessage, string Initials, DateTime UltimoDate)
            {
                db.StartTransaction();
                ErrorMessage = "";
                try
                {
                    // if user has selected to wipe existing booked data, do so first
                    bool EraseBooked = db.GetConfigStringAsBool("StockCountRegistrationRBA.EraseBooked");
                    if (EraseBooked)
                    {
                        ItemDataSet.ItemTransactionStockCountRBADataTable.Delete(
                            UltimoDate.Date, db.Connection, db.CurrentTransaction);
                    }

                    // book each record currently in memory
                    foreach (StockCountRegistrationRBARow row in Rows)
                    {
                        if (row.RowState != DataRowState.Deleted &&
                            row.RowState != DataRowState.Detached)
                        {
                            ItemDataSet.ItemTransactionStockCountRBADataTable.WriteTransactionRecord(
                                row.LevNr, row.Varenummer, row.Varenavn, row.Varegruppe, row.Antal, row.KostprisExMoms, Initials, UltimoDate, db.Connection, db.CurrentTransaction);
                        }
                    }

                    db.ExecuteNonQuery("delete from StockCountRegistrationRBA");
                    db.SetConfigString("StockCountRegistrationRBA.UltimoYear", "");
                    db.SetConfigString("StockCountRegistrationRBA.UltimoMonth", "");
                    db.SetConfigString("StockCountRegistrationRBA.EraseBooked", "");
                    db.CommitTransaction();
                    Rows.Clear();
                    return true;
                }
                catch (Exception ex)
                {
                    log.WriteException("Calling StockCountRegistrationRBA.Book", ex.Message, ex.StackTrace);
                    ErrorMessage = db.GetLangString("StockCountRegistrationRBA.BookError");
                    db.RollbackTransaction();
                    return false;
                }

            }
            #endregion

            #region CheckIfAnyUnbookedRecords
            public static bool CheckIfAnyUnbookedRecords()
            {
                return tools.object2int(db.ExecuteScalar("select count (*) from StockCountRegistrationRBA")) > 0;
            }
            #endregion
        }
        #endregion

        #region ItemTransactionStockCountRBADataTable
        partial class ItemTransactionStockCountRBADataTable
        {
            public static bool CheckIfAnyData(DateTime UltimoDate)
            {
                using (OleDbConnection conn = new OleDbConnection(db.ConnectionString))
                {
                    string sql = "select count(*) from ItemTransactionStockCountRBA where UltimoDate = ?";
                    using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection))
                    {
                        cmd.Parameters.Add("PostingDate", OleDbType.Date).Value = UltimoDate.Date;
                        conn.Open();
                        return tools.object2int(cmd.ExecuteScalar()) > 0;
                    }
                }
            }

            /// <summary>
            /// Checks if the given item exist on the given ultimodate.
            /// If so, the TransactionNumber is returned. If not, 0 is returned.
            /// </summary>
            public static long CheckIfRecordExsits(DateTime UltimoDate, double Varenummer, OleDbConnection conn, OleDbTransaction trans)
            {
                string sql = "select TransactionNumber from ItemTransactionStockCountRBA where UltimoDate = ? and Varenummer = ?";
                using (OleDbCommand cmd = new OleDbCommand(sql, conn, trans))
                {
                    cmd.Parameters.Add("PostingDate", OleDbType.Date).Value = UltimoDate.Date;
                    cmd.Parameters.Add("Varenummer", OleDbType.Double).Value = Varenummer;
                    return tools.object2long(cmd.ExecuteScalar());
                }
            }

            #region WriteTransactionRecord
            public static void WriteTransactionRecord(
                int LevNr, double Varenummer, string Varenavn, string Varegruppe, int NumberOf, double Kostpris, string Initials,
                DateTime UltimoDate, OleDbConnection conn, OleDbTransaction transaction)
            {
                double Amount = NumberOf * Kostpris;

                // check if we already have the item on the ultimodate,
                // if so, delete the existing record before inserting the new one and keep the existing transactionnumber,
                // otherwise, if we do not have the item already, generate the next transactionnumber
                long TransactionNumber = CheckIfRecordExsits(UltimoDate.Date, Varenummer, conn, transaction);
                if (TransactionNumber > 0)
                {
                    // update the record

                    string sql = @"
                        update ItemTransactionStockCountRBA set
                        UltimoDate = ?, LevNr = ?, Varenummer = ?, Varenavn = ?,
                        Varegruppe = ?, NumberOf = ?, Amount = ?, Initials = ?
                        where TransactionNumber = ?
                        ";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn, transaction))
                    {
                        cmd.Parameters.Add("UltimoDate", OleDbType.Date).Value = UltimoDate.Date;
                        cmd.Parameters.Add("LevNr", OleDbType.Integer).Value = LevNr;
                        cmd.Parameters.Add("Varenummer", OleDbType.Double).Value = Varenummer;
                        cmd.Parameters.Add("Varenavn", OleDbType.WChar).Value = Varenavn;
                        cmd.Parameters.Add("Varegruppe", OleDbType.WChar).Value = Varegruppe;
                        cmd.Parameters.Add("NumberOf", OleDbType.Integer).Value = NumberOf;
                        cmd.Parameters.Add("Amount", OleDbType.Double).Value = Amount;
                        cmd.Parameters.Add("Initials", OleDbType.WChar).Value = Initials;
                        cmd.Parameters.Add("TransactionNumber", OleDbType.BigInt).Value = TransactionNumber;
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    // insert the record

                    TransactionNumber = db.GetNextItemTransactionIDStockCountRBA(true);
                    string sql = @"
                    insert into ItemTransactionStockCountRBA
                    (TransactionNumber, UltimoDate, LevNr, Varenummer, Varenavn, Varegruppe, NumberOf, Amount, Initials)
                    values (?,?,?,?,?,?,?,?,?)
                    ";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn, transaction))
                    {
                        cmd.Parameters.Add("TransactionNumber", OleDbType.BigInt).Value = TransactionNumber;
                        cmd.Parameters.Add("UltimoDate", OleDbType.Date).Value = UltimoDate.Date;
                        cmd.Parameters.Add("LevNr", OleDbType.Integer).Value = LevNr;
                        cmd.Parameters.Add("Varenummer", OleDbType.Double).Value = Varenummer;
                        cmd.Parameters.Add("Varenavn", OleDbType.WChar).Value = Varenavn;
                        cmd.Parameters.Add("Varegruppe", OleDbType.WChar).Value = Varegruppe;
                        cmd.Parameters.Add("NumberOf", OleDbType.Integer).Value = NumberOf;
                        cmd.Parameters.Add("Amount", OleDbType.Double).Value = Amount;
                        cmd.Parameters.Add("Initials", OleDbType.WChar).Value = Initials;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            #endregion

            public static DateTime GetLastUltimoDate()
            {
                using (OleDbConnection conn = new OleDbConnection(db.ConnectionString))
                {
                    string sql = "select top 1 UltimoDate from ItemTransactionStockCountRBA order by UltimoDate desc";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        conn.Open();
                        return tools.object2datetime(cmd.ExecuteScalar());
                    }
                }
            }

            public static void Delete(DateTime UltimoDate, OleDbConnection conn, OleDbTransaction trans)
            {
                string sql = "delete from ItemTransactionStockCountRBA where UltimoDate = ?";
                using (OleDbCommand cmd = new OleDbCommand(sql, conn, trans))
                {
                    cmd.Parameters.Add("UltimoDate", OleDbType.Date).Value = UltimoDate.Date;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region WasteRegistrationRBADataTable
        partial class WasteRegistrationRBADataTable
        {
            private bool SettingMutualValues_Varenummer_Barcode = false;
            private bool LookingUpSalgspris = false;

            #region OnMultipleVareFoundByVarenummer
            // event for letting GUI handle that more than one vare has been found by Varenummer
            public delegate void MultipleVareFoundByVarenummer(out int LevNr, double Varenummer);
            public event MultipleVareFoundByVarenummer OnMultipleVareFoundByVarenummer = null;
            #endregion

            #region OnMultipleVareFoundByBarcode
            // event for letting GUI handle that more than one vare has been found by Barcode
            public delegate void MultipleVareFoundByBarcode(out int LevNr, out double Barcou, double Barcode);
            public event MultipleVareFoundByBarcode OnMultipleVareFoundByBarcode = null;
            #endregion

            #region OnLookupValuesChanged
            // event for letting GUI know that lookup values has changed
            // so GUI needs to update the grid
            public delegate void LookupValuesChanged();
            public event LookupValuesChanged OnLookupValuesChanged = null;
            #endregion

            #region OnColumnChanged
            protected override void OnColumnChanged(DataColumnChangeEventArgs e)
            {
                if (e.Column == VarenummerColumn)
                {
                    if (!SettingMutualValues_Varenummer_Barcode)
                    {
                        // clear fields
                        SettingMutualValues_Varenummer_Barcode = true;
                        e.Row[BarcodeColumn] = DBNull.Value;
                        SettingMutualValues_Varenummer_Barcode = false;
                        e.Row[VarenavnColumn] = DBNull.Value;
                        e.Row[LevNrColumn] = DBNull.Value;
                        e.Row[VaregruppeColumn] = DBNull.Value;
                        e.Row[KostprisColumn] = DBNull.Value;
                        LookingUpSalgspris = true;
                        e.Row[SalgsprisColumn] = DBNull.Value;
                        LookingUpSalgspris = false;
                        e.Row[AntalColumn] = DBNull.Value; // and clear the Antal field
                        e.Row[ManualInputColumn] = DBNull.Value;

                        // extract just entered Varenummer
                        double Varenummer = tools.object2double(e.ProposedValue);

                        int LevNr = 0;

                        // attempt to find the vare in the catalog
                        int num = AfskrProdDataTable.GetNumRecordsByVarenummer(Varenummer);
                        if (num > 1)
                        {
                            // more that one vare found, so user
                            // has to select the one needed and LevNr will be set,
                            // so invoke the event handler
                            if (OnMultipleVareFoundByVarenummer != null)
                                OnMultipleVareFoundByVarenummer(out LevNr, Varenummer);
                        }
                        else if (num == 1)
                        {
                            LevNr = AfskrProdDataTable.GetLevNr(Varenummer);
                        }

                        // if LevNr is greater than 0, one vare record was found,
                        // and the lookup values can be set
                        if (LevNr > 0)
                        {
                            DataRow row = AfskrProdDataTable.GetRecord(LevNr, Varenummer);
                            if (row != null)
                            {
                                e.Row[LevNrColumn] = row["LevNr"];
                                e.Row[VarenavnColumn] = row["Beskrivelse"];
                                e.Row[KostprisColumn] = row["Kostpris"];
                                LookingUpSalgspris = true;
                                e.Row[SalgsprisColumn] = row["Salgspris"];
                                LookingUpSalgspris = false;
                                e.Row[VaregruppeColumn] = row["Varegruppe"];
                                SettingMutualValues_Varenummer_Barcode = true;
                                e.Row[BarcodeColumn] = row["Barcode"];
                                SettingMutualValues_Varenummer_Barcode = false;
                                e.Row[ManualInputColumn] = row["GenerelVare"];

                                // let GUI know that it needs to refresh the grid
                                if (OnLookupValuesChanged != null)
                                    OnLookupValuesChanged();
                            }
                        }
                    }
                }
                else if (e.Column == BarcodeColumn)
                {
                    if (!SettingMutualValues_Varenummer_Barcode)
                    {
                        // clear fields
                        SettingMutualValues_Varenummer_Barcode = true;
                        e.Row[VarenummerColumn] = DBNull.Value;
                        SettingMutualValues_Varenummer_Barcode = false;
                        e.Row[VarenavnColumn] = DBNull.Value;
                        e.Row[LevNrColumn] = DBNull.Value;
                        e.Row[VaregruppeColumn] = DBNull.Value;
                        e.Row[KostprisColumn] = DBNull.Value;
                        LookingUpSalgspris = true;
                        e.Row[SalgsprisColumn] = DBNull.Value;
                        LookingUpSalgspris = false;
                        e.Row[AntalColumn] = DBNull.Value;
                        e.Row[ManualInputColumn] = DBNull.Value;

                        // extract just entered Barcode
                        double Barcode = tools.object2double(e.ProposedValue);

                        int LevNr = 0;
                        double Varenummer = 0;

                        // attempt to find the vare in the catalog
                        int num = AfskrProdDataTable.GetNumRecordsByBarcode(Barcode);
                        if (num > 1)
                        {
                            // more that one vare found, so user
                            // has to select the one needed and LevNr will be set,
                            // so invoke the event handler
                            if (OnMultipleVareFoundByBarcode != null)
                                OnMultipleVareFoundByBarcode(out LevNr, out Varenummer, Barcode);
                        }
                        else if (num == 1)
                        {
                            AfskrProdDataTable.GetPrimaryKey(Barcode, out LevNr, out Varenummer);
                        }

                        // if LevNr and Varenummer are greater than 0, one vare record was found,
                        // and the lookup values can be set
                        if ((LevNr > 0) && (Varenummer > 0))
                        {
                            DataRow row = AfskrProdDataTable.GetRecord(LevNr, Varenummer);
                            if (row != null)
                            {
                                e.Row[LevNrColumn] = row["LevNr"];
                                SettingMutualValues_Varenummer_Barcode = true;
                                e.Row[VarenummerColumn] = row["Varenummer"];
                                SettingMutualValues_Varenummer_Barcode = false;
                                e.Row[VarenavnColumn] = row["Beskrivelse"];
                                e.Row[KostprisColumn] = row["Kostpris"];
                                LookingUpSalgspris = true;
                                e.Row[SalgsprisColumn] = row["Salgspris"];
                                LookingUpSalgspris = false;
                                e.Row[VaregruppeColumn] = row["Varegruppe"];
                                e.Row[ManualInputColumn] = row["GenerelVare"];

                                // let GUI know that it needs to refresh the grid
                                if (OnLookupValuesChanged != null)
                                    OnLookupValuesChanged();
                            }
                        }
                    }
                }
                else if ((e.Column == SalgsprisColumn) && !LookingUpSalgspris)
                {
                    /// If this is a manual edit of Salgspris column,
                    /// calculate Kostpris using Salgspris and
                    /// BudgetMargin (dækningsgrad) on the subcategory.

                    double Salgspris = tools.object2double(e.ProposedValue);
                    string SubCategoryID = tools.object2string(e.Row[VaregruppeColumn]);
                    double BudgetMargin = SubCategoryDataTable.GetBudgetMargin(SubCategoryID);
                    e.Row[KostprisColumn] = tools.CalcCostPrice(BudgetMargin, Salgspris);

                    // let GUI know that it needs to refresh the grid
                    if (OnLookupValuesChanged != null)
                        OnLookupValuesChanged();

                    // @@@ så var der noget med varer uden moms
                }

                base.OnColumnChanged(e);
            }
            #endregion

            #region Book
            public bool Book(out string ErrorMessage, string Initials, DateTime OpenDay)
            {
                db.StartTransaction();
                ErrorMessage = "";
                try
                {
                    foreach (WasteRegistrationRBARow row in Rows)
                    {
                        if (row.RowState != DataRowState.Deleted &&
                            row.RowState != DataRowState.Detached)
                        {
                            ItemDataSet.ItemTransactionRBADataTable.WriteTransactionRecord(
                                row.LevNr, row.Varenummer, row.Antal, Initials, OpenDay);
                        }
                    }
                    db.ExecuteNonQuery("delete from WasteRegistrationRBA");
                    db.CommitTransaction();
                    Rows.Clear();
                    return true;
                }
                catch (Exception ex)
                {
                    log.WriteException("Calling WasteRegistrationRBA.Book", ex.Message, ex.StackTrace);
                    ErrorMessage = db.GetLangString("WasteRegistrationRBA.BookError");
                    db.RollbackTransaction();
                    return false;
                }

            }
            #endregion

            #region CheckIfAnyUnbookedRecords
            public static bool CheckIfAnyUnbookedRecords()
            {
                return tools.object2int(db.ExecuteScalar("select count (*) from WasteRegistrationRBA")) > 0;
            }
            #endregion
        }
        #endregion

        #region ForbrugsvareDataTable
        partial class ForbrugsvareDataTable
        {
            #region CreateOrUpdateRecord
            public static void CreateOrUpdateRecord(
                int LevNr,
                double Varenummer,
                string Beskrivelse,
                double Kostpris,
                double Salgspris,
                string Varegruppe,
                double Barcode,
                bool GenerelVare,
                string LevKategori)
            {
                if (RecordExists(LevNr, Varenummer))
                {
                    Adapter.UpdateRecord(
                        Beskrivelse,
                        (decimal?)Kostpris,
                        (decimal?)Salgspris,
                        Varegruppe,
                        Barcode > 0 ? (decimal?)Barcode : null,
                        GenerelVare,
                        LevKategori,
                        LevNr,
                        (decimal)Varenummer);
                }
                else
                {
                    Adapter.CreateRecord(
                        LevNr,
                        (decimal)Varenummer,
                        Beskrivelse,
                        (decimal?)Kostpris,
                        (decimal?)Salgspris,
                        Varegruppe,
                        Barcode > 0 ? (decimal?)Barcode : null,
                        GenerelVare,
                        LevKategori);
                }
            }
            #endregion

            #region DeleteAllRecords
            public static void InactivateAllRecords()
            {
                string sql = "update Forbrugsvare set Inactive = 1";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            #endregion

            #region RecordExists
            private static bool RecordExists(int LevNr, double Varenummer)
            {
                return tools.object2int(Adapter.NumRows(LevNr, (decimal)Varenummer)) > 0;
            }
            #endregion

            #region Adapter
            private static ItemDataSetTableAdapters.ForbrugsvareTableAdapter Adapter
            {
                get
                {
                    ItemDataSetTableAdapters.ForbrugsvareTableAdapter adapter =
                                new RBOS.ItemDataSetTableAdapters.ForbrugsvareTableAdapter();
                    adapter.Connection = db.Connection;
                    adapter.SetTransaction(db.CurrentTransaction);
                    return adapter;
                }
            }
            #endregion

            #region GetPrimaryKey
            public static bool GetPrimaryKey(double Barcode, out int LevNr, out double Varenummer)
            {
                DataRow row = null;
                string sql = @"
                    select LevNr, Varenummer
                    from Forbrugsvare
                    where Barcode = ?
                    ";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.Parameters.Add("Barcode", OleDbType.Double).Value = Barcode;
                    row = db.GetDataRow(cmd);
                }
                if (row != null)
                {
                    LevNr = tools.object2int(row["LevNr"]);
                    Varenummer = tools.object2double(row["Varenummer"]);
                    return true;
                }
                else
                {
                    LevNr = 0;
                    Varenummer = 0;
                    return false;
                }
            }
            #endregion

            #region GetNumRecordsByVarenummer
            public static int GetNumRecordsByVarenummer(double Varenummer)
            {
                string sql = "select count(*) from Forbrugsvare where (Varenummer = ?) and (Inactive <> ?)";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.Parameters.Add("Varenummer", OleDbType.Double).Value = Varenummer;
                    cmd.Parameters.Add("Inactive", OleDbType.Boolean).Value = true;
                    return tools.object2int(cmd.ExecuteScalar());
                }
            }
            #endregion

            #region GetNumRecordsByBarcode
            public static int GetNumRecordsByBarcode(double Barcode)
            {
                //string sql = "select count(*) from Forbrugsvare where (Barcode = ?) and (Inactive <> ?)";
                //using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                //{
                //    cmd.Parameters.Add("Barcode", OleDbType.Double).Value = Barcode;
                //    cmd.Parameters.Add("Inactive", OleDbType.Boolean).Value = true;
                //    return tools.object2int(cmd.ExecuteScalar());

                //    dbOleDb.ExecuteNonQuery(string.Format(
                //      " update ACNExportHistory set " +
                //      " Status = {0}, " +
                //      " SystemDate = dbo.cdate('{1}') " +
                //      " where (AYear = {2}) and (AWeek = {3}) ",
                //      (int)status, DateTime.Now, Year, Week));

                //}
                return (1);
            }
            #endregion

            #region GetLevNr
            public static int GetLevNr(double Varenummer)
            {
                string sql = "select LevNr from Forbrugsvare where Varenummer = ?";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.Parameters.Add("Varenummer", OleDbType.Double).Value = Varenummer;
                    return tools.object2int(cmd.ExecuteScalar());
                }
            }
            #endregion

            #region GetRecord
            /// <summary>
            /// Returns null if not found.
            /// </summary>
            public static DataRow GetRecord(int LevNr, double Varenummer)
            {
                string sql = "select * from Forbrugsvare where LevNr = ? and Varenummer = ?";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.Parameters.Add("LevNr", OleDbType.Integer).Value = LevNr;
                    cmd.Parameters.Add("Varenummer", OleDbType.Double).Value = Varenummer;
                    return db.GetDataRow(cmd);
                }
            }
            #endregion

            #region GetVarenavn
            public static string GetVarenavn(int LevNr, double Varenummer)
            {
                string sql = "select Beskrivelse from Forbrugsvare where LevNr = ? and Varenummer = ?";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.Parameters.Add("LevNr", OleDbType.Integer).Value = LevNr;
                    cmd.Parameters.Add("Varenummer", OleDbType.Double).Value = Varenummer;
                    return tools.object2string(cmd.ExecuteScalar());
                }
            }
            #endregion

            #region GetKostpris
            public static double GetKostpris(int LevNr, double Varenummer)
            {
                string sql = "select Kostpris from Forbrugsvare where LevNr = ? and Varenummer = ?";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.Parameters.Add("LevNr", OleDbType.Integer).Value = LevNr;
                    cmd.Parameters.Add("Varenummer", OleDbType.Double).Value = Varenummer;
                    return tools.object2double(cmd.ExecuteScalar());
                }
            }
            #endregion
        }
        #endregion

        #region ForbrugsvareRegsitreringDataTable
        partial class ForbrugsvareRegistreringDataTable
        {
            private bool SettingMutualValues_Varenummer_Barcode = false;
            private bool LookingUpSalgspris = false;

            #region OnMultipleVareFoundByVarenummer
            // event for letting GUI handle that more than one vare has been found by Varenummer
            public delegate void MultipleVareFoundByVarenummer(out int LevNr, double Varenummer);
            public event MultipleVareFoundByVarenummer OnMultipleVareFoundByVarenummer = null;
            #endregion

            #region OnMultipleVareFoundByBarcode
            // event for letting GUI handle that more than one vare has been found by Barcode
            public delegate void MultipleVareFoundByBarcode(out int LevNr, out double Barcou, double Barcode);
            public event MultipleVareFoundByBarcode OnMultipleVareFoundByBarcode = null;
            #endregion

            #region OnLookupValuesChanged
            // event for letting GUI know that lookup values has changed
            // so GUI needs to update the grid
            public delegate void LookupValuesChanged();
            public event LookupValuesChanged OnLookupValuesChanged = null;
            #endregion

            #region OnColumnChanged
            protected override void OnColumnChanged(DataColumnChangeEventArgs e)
            {
                if (e.Column == VarenummerColumn)
                {
                    if (!SettingMutualValues_Varenummer_Barcode)
                    {
                        // clear fields
                        SettingMutualValues_Varenummer_Barcode = true;
                        e.Row[BarcodeColumn] = DBNull.Value;
                        SettingMutualValues_Varenummer_Barcode = false;
                        e.Row[VarenavnColumn] = DBNull.Value;
                        e.Row[LevNrColumn] = DBNull.Value;
                        e.Row[VaregruppeColumn] = DBNull.Value;
                        e.Row[KostprisColumn] = DBNull.Value;
                        LookingUpSalgspris = true;
                        e.Row[SalgsprisColumn] = DBNull.Value;
                        LookingUpSalgspris = false;
                        e.Row[AntalColumn] = DBNull.Value; // and clear the Antal field

                        // extract just entered Varenummer
                        double Varenummer = tools.object2double(e.ProposedValue);

                        int LevNr = 0;

                        // attempt to find the vare in the catalog
                        int num = ForbrugsvareDataTable.GetNumRecordsByVarenummer(Varenummer);
                        if (num > 1)
                        {
                            // more that one vare found, so user
                            // has to select the one needed and LevNr will be set,
                            // so invoke the event handler
                            if (OnMultipleVareFoundByVarenummer != null)
                                OnMultipleVareFoundByVarenummer(out LevNr, Varenummer);
                        }
                        else if (num == 1)
                        {
                            LevNr = ForbrugsvareDataTable.GetLevNr(Varenummer);
                        }

                        // if LevNr is greater than 0, one vare record was found,
                        // and the lookup values can be set
                        if (LevNr > 0)
                        {
                            DataRow row = ForbrugsvareDataTable.GetRecord(LevNr, Varenummer);
                            if (row != null)
                            {
                                e.Row[LevNrColumn] = row["LevNr"];
                                e.Row[VarenavnColumn] = row["Beskrivelse"];
                                e.Row[KostprisColumn] = row["Kostpris"];
                                LookingUpSalgspris = true;
                                e.Row[SalgsprisColumn] = row["Salgspris"];
                                LookingUpSalgspris = false;
                                e.Row[VaregruppeColumn] = row["Varegruppe"];
                                SettingMutualValues_Varenummer_Barcode = true;
                                e.Row[BarcodeColumn] = row["Barcode"];
                                SettingMutualValues_Varenummer_Barcode = false;

                                // let GUI know that it needs to refresh the grid
                                if (OnLookupValuesChanged != null)
                                    OnLookupValuesChanged();
                            }
                        }
                    }
                }
                else if (e.Column == BarcodeColumn)
                {
                    if (!SettingMutualValues_Varenummer_Barcode)
                    {
                        // clear fields
                        SettingMutualValues_Varenummer_Barcode = true;
                        e.Row[VarenummerColumn] = DBNull.Value;
                        SettingMutualValues_Varenummer_Barcode = false;
                        e.Row[VarenavnColumn] = DBNull.Value;
                        e.Row[LevNrColumn] = DBNull.Value;
                        e.Row[VaregruppeColumn] = DBNull.Value;
                        e.Row[KostprisColumn] = DBNull.Value;
                        LookingUpSalgspris = true;
                        e.Row[SalgsprisColumn] = DBNull.Value;
                        LookingUpSalgspris = false;
                        e.Row[AntalColumn] = DBNull.Value;

                        // extract just entered Barcode
                        double Barcode = tools.object2double(e.ProposedValue);

                        int LevNr = 0;
                        double Varenummer = 0;

                        // attempt to find the vare in the catalog
                        int num = ForbrugsvareDataTable.GetNumRecordsByBarcode(Barcode);
                        if (num > 1)
                        {
                            // more that one vare found, so user
                            // has to select the one needed and LevNr will be set,
                            // so invoke the event handler
                            if (OnMultipleVareFoundByBarcode != null)
                                OnMultipleVareFoundByBarcode(out LevNr, out Varenummer, Barcode);
                        }
                        else if (num == 1)
                        {
                            ForbrugsvareDataTable.GetPrimaryKey(Barcode, out LevNr, out Varenummer);
                        }

                        // if LevNr and Varenummer are greater than 0, one vare record was found,
                        // and the lookup values can be set
                        if ((LevNr > 0) && (Varenummer > 0))
                        {
                            DataRow row = ForbrugsvareDataTable.GetRecord(LevNr, Varenummer);
                            if (row != null)
                            {
                                e.Row[LevNrColumn] = row["LevNr"];
                                SettingMutualValues_Varenummer_Barcode = true;
                                e.Row[VarenummerColumn] = row["Varenummer"];
                                SettingMutualValues_Varenummer_Barcode = false;
                                e.Row[VarenavnColumn] = row["Beskrivelse"];
                                e.Row[KostprisColumn] = row["Kostpris"];
                                LookingUpSalgspris = true;
                                e.Row[SalgsprisColumn] = row["Salgspris"];
                                LookingUpSalgspris = false;
                                e.Row[VaregruppeColumn] = row["Varegruppe"];

                                // let GUI know that it needs to refresh the grid
                                if (OnLookupValuesChanged != null)
                                    OnLookupValuesChanged();
                            }
                        }
                    }
                }
                else if ((e.Column == SalgsprisColumn) && !LookingUpSalgspris)
                {
                    /// If this is a manual edit of Salgspris column,
                    /// calculate Kostpris using Salgspris and
                    /// BudgetMargin (dækningsgrad) on the subcategory.

                    double Salgspris = tools.object2double(e.ProposedValue);
                    string SubCategoryID = tools.object2string(e.Row[VaregruppeColumn]);
                    double BudgetMargin = SubCategoryDataTable.GetBudgetMargin(SubCategoryID);
                    e.Row[KostprisColumn] = tools.CalcCostPrice(BudgetMargin, Salgspris);

                    // let GUI know that it needs to refresh the grid
                    if (OnLookupValuesChanged != null)
                        OnLookupValuesChanged();

                    // @@@ så var der noget med varer uden moms
                }

                base.OnColumnChanged(e);
            }
            #endregion

            #region Book
            public bool Book(out string ErrorMessage, string Initials, DateTime OpenDay)
            {
                db.StartTransaction();
                ErrorMessage = "";
                try
                {
                    foreach (ForbrugsvareRegistreringRow row in Rows)
                    {
                        if (row.RowState != DataRowState.Deleted &&
                            row.RowState != DataRowState.Detached)
                        {
                            ItemDataSet.ItemTransactionForbrugsvareDataTable.WriteTransactionRecord(
                                row.LevNr, row.Varenummer, row.Antal, row.Salgspris, Initials, OpenDay);
                        }
                    }
                    db.ExecuteNonQuery("delete from ForbrugsvareRegistrering");
                    db.CommitTransaction();
                    Rows.Clear();
                    return true;
                }
                catch (Exception ex)
                {
                    log.WriteException("Calling ForbrugsvareRegistrering.Book", ex.Message, ex.StackTrace);
                    ErrorMessage = db.GetLangString("ForbrugsvareRegistrering.BookError");
                    db.RollbackTransaction();
                    return false;
                }

            }
            #endregion

            #region CheckIfAnyUnbookedRecords
            public static bool CheckIfAnyUnbookedRecords()
            {
                string sql = "select count (*) from ForbrugsvareRegistrering";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    return tools.object2int(cmd.ExecuteScalar()) > 0;
                }
            }
            #endregion
        }
        #endregion

        #region ItemTransactionForbrugsvareDataTable
        partial class ItemTransactionForbrugsvareDataTable
        {
            #region WriteTransactionRecord
            public static void WriteTransactionRecord(int LevNr, double Varenummer, int NumberOf, double Salgspris, string Initials, DateTime OpenDay)
            {
                // lookup som values
                long TransactionNumber = db.GetNextItemTransactionIDForbrugsvare(true);
                string Varenavn = ForbrugsvareDataTable.GetVarenavn(LevNr, Varenummer);
                double Amount = NumberOf * Salgspris;

                // write transaction record
                string sql = @"
                    insert into ItemTransactionForbrugsvare
                    (TransactionNumber, PostingDate, LevNr, Varenummer, Varenavn, NumberOf, Amount, Initials)
                    values (?,?,?,?,?,?,?,?)
                    ";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.Parameters.Add("TransactionNumber", OleDbType.BigInt).Value = TransactionNumber;
                    cmd.Parameters.Add("PostingDate", OleDbType.Date).Value = OpenDay.Date;
                    cmd.Parameters.Add("LevNr", OleDbType.Integer).Value = LevNr;
                    cmd.Parameters.Add("Varenummer", OleDbType.Double).Value = Varenummer;
                    cmd.Parameters.Add("Varenavn", OleDbType.VarWChar).Value = Varenavn;
                    cmd.Parameters.Add("NumberOf", OleDbType.Integer).Value = NumberOf;
                    cmd.Parameters.Add("Amount", OleDbType.Double).Value = Amount;
                    cmd.Parameters.Add("Initials", OleDbType.VarWChar).Value = Initials;
                    cmd.ExecuteNonQuery();
                }
            }
            #endregion

            #region CheckIfAnyTransactionRecords
            public static bool CheckIfAnyTransactionRecords(DateTime OpenDay)
            {
                string sql = @"
                    select count(*) from ItemTransactionForbrugsvare
                    where PostingDate = ?
                    ";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
                {
                    cmd.Parameters.Add("PostingDate", OleDbType.Date).Value = OpenDay.Date;
                    return tools.object2int(cmd.ExecuteScalar()) > 0;
                }
            }
            #endregion
        }
        #endregion

        #region AfskrProdDataTable
        partial class AfskrProdDataTable
        {
            #region CreateOrUpdateRecord
            public static void CreateOrUpdateRecord(
                int LevNr,
                double Varenummer,
                string Beskrivelse,
                double Kostpris,
                double Salgspris,
                string Varegruppe,
                double Barcode,
                bool GenerelVare,
                string LevKategori)
            {
                if (RecordExists(LevNr, Varenummer))
                {
                    Adapter.UpdateRecord(
                        Beskrivelse,
                        (decimal?)Kostpris,
                        (decimal?)Salgspris,
                        Varegruppe,
                        Barcode > 0 ? (decimal?)Barcode : null,
                        GenerelVare,
                        LevKategori,
                        LevNr,
                        (decimal)Varenummer);
                }
                else
                {
                    Adapter.CreateRecord(
                        LevNr,
                        (decimal)Varenummer,
                        Beskrivelse,
                        (decimal?)Kostpris,
                        (decimal?)Salgspris,
                        Varegruppe,
                        Barcode > 0 ? (decimal?)Barcode : null,
                        GenerelVare,
                        LevKategori);
                }
            }
            #endregion

            #region DeleteAllRecords
            public static void InactivateAllRecords()
            {
                db.ExecuteNonQuery("update AfskrProd set Inactive = 1");
            }
            #endregion

            #region RecordExists
            private static bool RecordExists(int LevNr, double Varenummer)
            {
                return tools.object2int(Adapter.NumRows(LevNr, (decimal)Varenummer)) > 0;
            }
            #endregion

            #region Adapter
            private static ItemDataSetTableAdapters.AfskrProdTableAdapter Adapter
            {
                get
                {
                    ItemDataSetTableAdapters.AfskrProdTableAdapter adapter =
                                new RBOS.ItemDataSetTableAdapters.AfskrProdTableAdapter();
                    adapter.Connection = db.Connection;
                    adapter.SetTransaction(db.CurrentTransaction);
                    return adapter;
                }
            }
            #endregion

            #region GetPrimaryKey
            public static bool GetPrimaryKey(double Barcode, out int LevNr, out double Varenummer)
            {
                string sql = string.Format(@"
                    select LevNr, Varenummer
                    from AfskrProd
                    where Barcode = {0}
                    ", Barcode);
                DataRow row = db.GetDataRow(sql);
                if (row != null)
                {
                    LevNr = tools.object2int(row["LevNr"]);
                    Varenummer = tools.object2double(row["Varenummer"]);
                    return true;
                }
                else
                {
                    LevNr = 0;
                    Varenummer = 0;
                    return false;
                }
            }
            #endregion

            #region GetNumRecordsByVarenummer
            public static int GetNumRecordsByVarenummer(double Varenummer)
            {
                string sql = string.Format("select count(*) from AfskrProd where (Varenummer = {0}) and (Inactive <> true)", Varenummer);
                return tools.object2int(db.ExecuteScalar(sql));
            }
            #endregion

            #region GetNumRecordsByBarcode
            public static int GetNumRecordsByBarcode(double Barcode)
            {
                string sql = string.Format("select count(*) from AfskrProd where (Barcode = {0}) and (Inactive <> true)", Barcode);
                return tools.object2int(db.ExecuteScalar(sql));
            }
            #endregion

            #region GetLevNr
            public static int GetLevNr(double Varenummer)
            {
                string sql = string.Format("select LevNr from AfskrProd where Varenummer = {0}", Varenummer);
                return tools.object2int(db.ExecuteScalar(sql));
            }
            #endregion

            #region GetRecord
            /// <summary>
            /// Returns null if not found.
            /// </summary>
            public static DataRow GetRecord(int LevNr, double Varenummer)
            {
                string sql = string.Format("select * from AfskrProd where LevNr = {0} and Varenummer = {1}", LevNr, Varenummer);
                return db.GetDataRow(sql);
            }
            #endregion

            public static string GetVarenavn(int LevNr, double Varenummer)
            {
                string sql = string.Format("select Beskrivelse from AfskrProd where LevNr = {0} and Varenummer = {1}", LevNr, Varenummer);
                return tools.object2string(db.ExecuteScalar(sql));
            }

            public static double GetKostpris(int LevNr, double Varenummer)
            {
                string sql = string.Format("select Kostpris from AfskrProd where LevNr = {0} and Varenummer = {1}", LevNr, Varenummer);
                return tools.object2double(db.ExecuteScalar(sql));
            }
        }
        #endregion

        #region PARTIAL CLASS SupplierDataTable
        partial class SupplierDataTable
        {
            #region GetLLSupplierNoFromSupplierID
            /// <summary>
            /// Looks up the LLSupplierNo from the provided SupplierID.
            /// </summary>
            public static int GetLLSupplierNoFromSupplierID(int SupplierID)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(@"
                    select LLSupplierNo from Supplier
                    where SupplierID = {0}
                    ", SupplierID)));
            }
            #endregion
        }
        #endregion

        #region PARTIAL CLASS WasteSheetDetailsDataTable
        partial class WasteSheetDetailsDataTable
        {
            #region GetNextLineNo
            /// <summary>
            /// Returns the next lineno for the currently loaded waste sheet.
            /// </summary>
            public int GetNextLineNo()
            {
                int MaxLineNo = 0;
                foreach (DataRow row in this.Rows)
                {
                    if ((row.RowState != DataRowState.Deleted) &&
                        (row.RowState != DataRowState.Detached))
                    {
                        int LineNo = tools.object2int(row["LineNo"]);
                        if (LineNo > MaxLineNo)
                            MaxLineNo = LineNo;
                    }
                }
                return (MaxLineNo + 1);
            }
            #endregion

            #region ItemAlreadySelected
            public bool ItemAlreadySelected(int ItemID)
            {
                foreach (DataRow row in this.Rows)
                {
                    if ((row.RowState != DataRowState.Deleted) &&
                        (row.RowState != DataRowState.Detached))
                    {
                        int dbItemID = ItemDataTable.GetItemIDFromBarcode(tools.object2double(row["Barcode"]));
                        if (dbItemID == ItemID)
                            return true;
                    }
                }
                return false;
            }
            #endregion
        }
        #endregion

        #region WasteSheetDetailsRBADataTable
        /// <summary>
        /// Class handling the table WasteSheetDetailsRBA.
        /// </summary>
        partial class WasteSheetDetailsRBADataTable
        {
            #region GetNextLineNo
            /// <summary>
            /// Returns the next lineno for the currently loaded waste sheet.
            /// </summary>
            public int GetNextLineNo()
            {
                int MaxLineNo = 0;
                foreach (DataRow row in this.Rows)
                {
                    if ((row.RowState != DataRowState.Deleted) &&
                        (row.RowState != DataRowState.Detached))
                    {
                        int LineNo = tools.object2int(row["LineNo"]);
                        if (LineNo > MaxLineNo)
                            MaxLineNo = LineNo;
                    }
                }
                return (MaxLineNo + 1);
            }
            #endregion

            #region ItemAlreadySelected
            public bool ItemAlreadySelected(int LevNr, double Varenummer)
            {
                foreach (DataRow row in this.Rows)
                {
                    if ((row.RowState != DataRowState.Deleted) &&
                        (row.RowState != DataRowState.Detached))
                    {
                        int dbLevNr = tools.object2int(row["LevNr"]);
                        double dbVarenummer = tools.object2double(row["Varenummer"]);
                        if ((dbLevNr == LevNr) && (dbVarenummer == Varenummer))
                            return true;
                    }
                }
                return false;
            }
            #endregion

            protected override void OnColumnChanged(DataColumnChangeEventArgs e)
            {
                if ((e.Column == LevNrColumn) || (e.Column == VarenummerColumn))
                {
                    // if either LevNr or Varenummer column was changed
                    // set lookup values. These are automatically set when
                    // loading the grid from the database.

                    ItemDataSetTableAdapters.AfskrProdTableAdapter tmp =
                        new RBOS.ItemDataSetTableAdapters.AfskrProdTableAdapter();
                    int LevNr = tools.object2int(e.Row[LevNrColumn]);
                    double Varenummer = tools.object2double(e.Row[VarenummerColumn]);
                    if ((LevNr > 0) && (Varenummer > 0))
                    {
                        e.Row[VarenavnColumn] = tmp.GetVarenavn(LevNr, (decimal)Varenummer);
                        e.Row[BarcodeColumn] = tmp.GetBarcode(LevNr, (decimal)Varenummer);
                        e.Row[KostprisColumn] = tmp.GetKostpris(LevNr, (decimal)Varenummer);
                        e.Row[SalgsprisColumn] = tmp.GetSalgspris(LevNr, (decimal)Varenummer);
                    }

                    /// Note that we usually did this before by using a lookupcombo
                    /// in the grids, but in this case there was two fields in the
                    /// primary key and that is not supported. This is by the way
                    /// much faster, as the grid loads data wihtout combos but with real
                    /// sql queries.
                }

                base.OnColumnChanged(e);
            }

            public static void SwapRecords(int HeaderID, int LineNo1, int LineNo2)
            {
                // to avoid key violation, we first set the record with LineNo1 in the table to max + 1
                db.ExecuteNonQuery(string.Format(@"
                    update WasteSheetDetailsRBA
                    set [LineNo] = -999
                    where HeaderID = {0}
                    and [LineNo] = {1}
                    ", HeaderID, LineNo1));

                // now assign LineNo1 to the record that has LineNo2
                db.ExecuteNonQuery(string.Format(@"
                    update WasteSheetDetailsRBA
                    set [LineNo] = {2}
                    where HeaderID = {0}
                    and [LineNo] = {1}
                    ", HeaderID, LineNo2, LineNo1));

                // now assign LineNo2 to the record that has -999
                db.ExecuteNonQuery(string.Format(@"
                    update WasteSheetDetailsRBA
                    set [LineNo] = {1}
                    where HeaderID = {0}
                    and [LineNo] = -999
                    ", HeaderID, LineNo2));
            }
        }
        #endregion

        #region PARTIAL CLASS WasteSheetHeaderDataTable
        partial class WasteSheetHeaderDataTable
        {
            #region CreateNewRecord
            /// <summary>
            /// Creates a new WasteSheetHeader record and returns the autogenerated ID.
            /// </summary>
            /// <returns></returns>
            public static int CreateNewRecord()
            {
                db.ExecuteNonQuery(@"
                    insert into WasteSheetHeader
                    (Name) values ('')
                    ");
                return tools.object2int(db.ExecuteScalar(string.Format(@"
                    select max(ID) from WasteSheetHeader
                    ")));
            }
            #endregion

            #region DeleteRecord
            /// <summary>
            /// Deletes the header record in WasteSheetHeader table
            /// and any related detail records in WasteSheetDetails table.
            /// </summary>
            /// <param name="ID"></param>
            public static void DeleteRecord(int ID)
            {
                db.ExecuteNonQuery(string.Format(@"
                    delete from WasteSheetHeader
                    where ID = {0}
                    ", ID));

                db.ExecuteNonQuery(string.Format(@"
                    delete from WasteSheetDetails
                    where HeaderID = {0}
                    ", ID));

            }
            #endregion

            #region GetRecord
            public static DataRow GetRecord(int ID)
            {
                return db.GetDataRow(string.Format(@"
                    select * from WasteSheetHeader
                    where ID = {0}
                    ", ID));
            }
            #endregion
            #region UpdateRecord
            public static void UpdateWasteSheetHeader(int HeaderID)
            {


                // update the record
                db.ExecuteNonQuery(string.Format(@" Update[dbo].[WasteSheetHeader] Set[NoOffRegistrations] =
                (select COUNT(*) from[dbo].[WasteSheetDetails] where[dbo].[WasteSheetDetails].HeaderID = WasteSheetHeader.ID
                And[dbo].[WasteSheetDetails].Antal <> 0) Where WasteSheetHeader.ID = {0}", HeaderID));

            }

            public static void ClearWasteSheetHeader()
            {


                // update the record
                db.ExecuteNonQuery(string.Format(@" Update[dbo].[WasteSheetHeader] Set[NoOffRegistrations] = 0"));

            }

            public static int ReturnAntalWasteHeader()
            {
                OleDbCommand cmd = new OleDbCommand("", db.Connection);
                cmd.CommandText = string.Format(" Select COUNT(*) from [WasteSheetHeader]");
                return (tools.object2int(cmd.ExecuteScalar()));
            }
            public static int ReturnSC()
            {
                OleDbCommand cmd = new OleDbCommand("", db.Connection);
                cmd.CommandText = string.Format(" Select COUNT(*) from [WasteSheetHeader] Where SC = 1");
                return (tools.object2int(cmd.ExecuteScalar()));
            }
            public static int ReturnWaste()
            {
                OleDbCommand cmd = new OleDbCommand("", db.Connection);
                cmd.CommandText = string.Format(" Select COUNT(*) from [WasteSheetHeader] Where Waste = 1");
                return (tools.object2int(cmd.ExecuteScalar()));
            }
            #endregion
        }



        #endregion


        #region PARTIAL CLASS: BookedInvCountDetailDataTable

        partial class BookedInvCountDetailDataTable
        {
            #region METHOD: InsertRecord
            /// <summary>
            /// Inserts a record into BookedInvCountDetail table
            /// with the given values.
            /// Static method that works with on-disk data.
            /// </summary>
            public static void InsertRecord(
                int HeaderID,
                int ItemID,
                int StartOnHand,
                int SalesPEJ,
                DateTime CountTime,
                int CountBHHT,
                int ManCorrect,
                int ActualCount,
                double CostPrice)
            {
                OleDbCommand cmd = new OleDbCommand("", db.Connection);
                cmd.CommandText = string.Format(
                    " insert into BookedInvCountDetail " +
                    " ([LineNo],HeaderID,ItemID,StartOnHand,SalesPEJ,CountTime,CountBHHT,ManCorrect,ActualCount,CostPrice) " +
                    " values ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9}) ",
                    GetNetLineNo(HeaderID),
                    HeaderID,
                    ItemID,
                    StartOnHand,
                    SalesPEJ,
                    tools.datetime4sql(CountTime),
                    CountBHHT,
                    ManCorrect,
                    ActualCount,
                    tools.decimalnumber4sql(CostPrice));
                cmd.ExecuteNonQuery();
            }
            #endregion

            #region METHOD: GetNetLineNo
            /// <summary>
            /// Gets the next LineNo for the given HeaderID.
            /// Static method that works with on-disk data.
            /// </summary>
            private static int GetNetLineNo(int HeaderID)
            {
                OleDbCommand cmd = new OleDbCommand("", db.Connection);
                cmd.CommandText = string.Format(
                    " select max([LineNo]) " +
                    " from BookedInvCountDetail " +
                    " where HeaderID = {0} ",
                    HeaderID);
                return (tools.object2int(cmd.ExecuteScalar()) + 1);
            }
            #endregion
        }

        #endregion

        #region PARTIAL CLASS: BookedInvCountHeaderDataTable

        partial class BookedInvCountHeaderDataTable
        {
            #region METHOD: InsertRecord
            /// <summary>
            /// Writes a record into BookedInvCountHeader table.
            /// Returns the autogenerated id.
            /// Static method that works with on-disk data.
            /// </summary>
            public static int InsertRecord(
                DateTime BookDate,
                string SubCategoryID,
                double TotalStockValue,
                double TotalDiffValue)
            {
                // insert record
                OleDbCommand cmd = new OleDbCommand("", db.Connection);
                cmd.CommandText = string.Format(
                    " insert into BookedInvCountHeader " +
                    " (BookDate,SubCategory,TotalStockValue,TotalDiffValue) " +
                    " values ({0},{1},{2},{3}) ",
                    "'" + BookDate + "'",
                    "'" + SubCategoryID + "'",
                    tools.decimalnumber4sql(TotalStockValue),
                    tools.decimalnumber4sql(TotalDiffValue));
                cmd.ExecuteNonQuery();

                // get and return just autogenerated id
                cmd.CommandText = " select max(ID) from BookedInvCountHeader ";
                return tools.object2int(cmd.ExecuteScalar());

            }
            #endregion

            #region DeleteHeadersWithoutDetails
            /// <summary>
            /// Deletes records from BookedInvCountHeader
            /// that does not have detail records in BookedInvCountDetail.
            /// This can happen, if an error occurs while booking inventory count data.
            /// </summary>
            public static void DeleteHeadersWithoutDetails()
            {
                db.ExecuteNonQuery(string.Format(
                    " delete from BookedInvCountHeader " +
                    " where ID not in " +
                    " (select HeaderID from BookedInvCountDetail) "));
            }
            #endregion
        }

        #endregion

        #region PARTIAL CLASS: InvCountWorkDataTable

        partial class InvCountWorkDataTable
        {
            #region EVENT: OnColumnChanged
            /// <summary>
            /// OnColumnChanged event handler
            /// </summary>
            protected override void OnColumnChanged(DataColumnChangeEventArgs e)
            {
                /// when user changes a value in the ManCorrect column
                /// the columns StockValue, CountDifference and DiffValue
                /// has to be re-calculated
                if (e.Column.ColumnName == ManCorrectColumn.ColumnName)
                {
                    /// if ManCorrect has been set to null:
                    /// StockValue = CountBHHT * CostPrice
                    /// CountDifference = CountBHHT - OnHandCalc

                    /// if ManCorrect has been set to a value other than null:
                    /// StockValue = ManCorrect * CostPrice
                    /// CountDifference = ManCorrect - OnHandCalc

                    double CostPrice = tools.object2double(e.Row["CostPrice"]);
                    int OnHandCalc = tools.object2int(e.Row["OnHandCalc"]);
                    int CountBHHT_or_ManCorrect = 0;
                    if ((e.ProposedValue == null) || (e.ProposedValue == DBNull.Value))
                        CountBHHT_or_ManCorrect = tools.object2int(e.Row["CountBHHT"]);
                    else
                        CountBHHT_or_ManCorrect = tools.object2int(e.ProposedValue);
                    e.Row["StockValue"] = CountBHHT_or_ManCorrect * CostPrice;
                    e.Row["CountDifference"] = CountBHHT_or_ManCorrect - OnHandCalc;

                    // DiffValue is based on CountDifference,
                    // which just changed, so recalculate it
                    int CountDifference = tools.object2int(e.Row["CountDifference"]);
                    e.Row["DiffValue"] = CountDifference * CostPrice;
                }

                base.OnColumnChanged(e);
            }
            #endregion

            #region METHOD: WriteRecord
            /// <summary>
            /// Inserts a record into table InvCountWork.
            /// Static method that works with on-disk data.
            /// </summary>
            public static void InsertRecord(
                int BHHTCountID,
                DateTime BHHTCountDate,
                int ItemID,
                DateTime CountTime,
                int CountBHHT,
                int StartOnHand,
                int SalesPEJ,
                int OnHandCalc,
                string ManCorrect,
                int CountDifference,
                double CostPrice,
                double StockValue,
                double DiffValue,
                string SubCategory,
                string ItemName)
            {
                string sCountTime = "'" + CountTime.ToString() + "'";
                if (CountTime == DateTime.MinValue)
                    sCountTime = "NULL";

                OleDbCommand cmd = new OleDbCommand("", db.Connection);
                cmd.CommandText = string.Format(
                    " insert into InvCountWork " +
                    " (BHHTCountID,CountDate,SubCategory,ItemID,StartOnHand,SalesPEJ," +
                    "  OnHandCalc,CountTime,CountBHHT,ManCorrect,CountDifference," +
                    "  CostPrice,StockValue,DiffValue,ItemName) " +
                    " values ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},'{14}') ",
                    BHHTCountID,
                    "'" + BHHTCountDate + "'",
                    "'" + tools.TruncString(SubCategory.Replace("'", "\""), 20) + "'",
                    ItemID,
                    StartOnHand,
                    SalesPEJ,
                    OnHandCalc,
                    sCountTime,
                    CountBHHT,
                    ManCorrect,
                    CountDifference,
                    tools.decimalnumber4sql(CostPrice), //pn20190812
                    tools.decimalnumber4sql(StockValue),
                    tools.decimalnumber4sql(DiffValue),
                    ItemName);
                cmd.ExecuteNonQuery();
            }
            #endregion

            #region METHOD: HasRecords
            /// <summary>
            /// Tells if the InvCountWork table has records.
            /// Static method that works with on-disk data.
            /// </summary>
            /// <returns></returns>
            public static bool HasRecords()
            {
                return !tools.IsNullOrDBNull(db.ExecuteScalar("select top 1 BHHTCountID from InvCountWork"));
            }
            #endregion
        }

        #endregion

        #region PARTIAL CLASS: SubCategoryDataTable

        partial class SubCategoryDataTable
        {
            #region GetSubCategoryDescription
            /// <summary>
            /// Returns the Description for the SubCategoryID provided.
            /// If not found, "" is returned.
            /// </summary>
            public static string GetSubCategoryDescription(string SubCategoryID)
            {
                return tools.object2string(db.ExecuteScalar(string.Format(
                    " select Description from SubCategory " +
                    " where SubCategoryID = '{0}' ",
                    SubCategoryID)));
            }
            #endregion

            #region GetBudgetMargin
            /// <summary>
            /// Returns the BudgetMargin for the given SubCategory.
            /// If subcategory was not found or some error occurs, 0 is returned.
            /// </summary>
            /// <param name="SubCategoryID"></param>
            /// <returns></returns>
            public static double GetBudgetMargin(string SubCategoryID)
            {
                return tools.object2double(db.ExecuteScalar(string.Format(
                    " select BudgetMargin from SubCategory " +
                    " where SubCategoryID = '{0}' ",
                    SubCategoryID)));
            }
            #endregion
            #region GetAgerestiction
            /// <summary>
            /// Returns the Agerestriction  for the given SubCategory.
            /// pn20200511
            /// </summary>
            /// <param name="SubCategoryID"></param>
            /// <returns></returns>
            public static int GetAgerestiction(string SubCategoryID)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(
                    " select AgeRestriction from SubCategory " +
                    " where SubCategoryID = '{0}' ",
                    SubCategoryID)));
            }
            #endregion

            #region NeedsDeposit
            /// <summary>
            /// Checks if the given subcategory has NeedsDeposit set to true.
            /// Static method that ONLY works with on-disk data.
            /// </summary>
            public static bool NeedsDeposit(string SubCategoryID)
            {
                return (tools.object2int(db.ExecuteScalar(string.Format(
                    " select count(*) " +
                    " from SubCategory " +
                    " where (NeedsDeposit = 1) " +
                    " and (SubCategoryID = {0}) ",
                    tools.string4sql(SubCategoryID, 20)))) > 0);
            }
            #endregion

            #region GetFirstSubCategoryID
            /// <summary>
            /// Returns the subcategory with the lowest id.
            /// Does not include "NotActive" subcategories.
            /// Does not include "HideInLookup" subcategories.
            /// </summary>
            public static string GetFirstSubCategoryID()
            {
                return tools.object2string(db.ExecuteScalar(
                    " select top 1 SubCategoryID " +
                    " from SubCategory " +
                    " where (NotActive <> true) " +
                    " and (HideInLookup <> true) " +
                    " order by SubCategoryID "));
            }
            #endregion

            #region GetLastSubCategoryID
            /// <summary>
            /// Returns the subcategory with the highest id.
            /// Does not include "NotActive" subcategories.
            /// Does not include "HideInLookup" subcategories.
            /// </summary>
            public static string GetLastSubCategoryID()
            {
                return tools.object2string(db.ExecuteScalar(
                    " select top 1 SubCategoryID " +
                    " from SubCategory " +
                    " where (NotActive <> true) " +
                    " and (HideInLookup <> true) " +
                    " order by SubCategoryID DESC "));
            }
            #endregion

            #region GetSubCategoryRow
            public static DataRow GetSubCategoryRow(string SubCategoryID)
            {
                return db.GetDataRow(string.Format(@"
                    select * from SubCategory
                    where SubCategoryID = '{0}'
                    ", SubCategoryID.Replace("'", "")));
            }
            #endregion

            #region UpdateFieldAndInheritedIfChanged
            public static void UpdateFieldAndInheritedIfChanged(string SubCategoryID, string Field, object Value)
            {
                SubCategoryID = tools.string4sql(SubCategoryID, 20);

                if (Value == null)
                    Value = DBNull.Value;

                object dbValue = db.ExecuteScalar(string.Format(@"
                    select {1} from SubCategory
                    where SubCategoryID = {0}
                    ", SubCategoryID, Field));

                // compare the new value with the one in db
                // using tostring to avoid that for instance
                // int and short will not be interpreted the same
                string sDBvalue = !tools.IsNullOrDBNull(dbValue) ? dbValue.ToString() : "";
                string sValue = !tools.IsNullOrDBNull(Value) ? Value.ToString() : "";
                if (sValue != sDBvalue)
                {
                    switch (Field)
                    {
                        case "Description": Value = tools.string4sql(Value, 50); break;
                        case "CategoryID": Value = tools.wholenumber4sql(Value); break;
                        case "VatRate":
                            Value = tools.decimalnumber4sql(Value);
                            // update inherited values on items
                            db.ExecuteNonQuery(string.Format(@"
                            update Item
                            set VatRate = {1}
                            where SubCategory = {0}
                            ", SubCategoryID, Value));
                            // set related salespacks to rsm and station update
                            db.ExecuteNonQuery(string.Format(@"
                            update SalesPack sp
                            set sp.UpdateRSM = 1, sp.UpdateStations = 1
                            where sp.ItemID in
                            (select i.ItemID from Item i
                             where i.SubCategory = {0})
                            ", SubCategoryID));
                            break;
                        case "VatOwner":
                            Value = tools.string4sql(Value, 20);
                            // update inherited values on items
                            db.ExecuteNonQuery(string.Format(@"
                            update Item
                            set VatOwner = {1}
                            where SubCategory = {0}
                            ", SubCategoryID, Value));
                            // set related salespacks to rsm and station update
                            db.ExecuteNonQuery(string.Format(@"
                            update SalesPack sp
                            set sp.UpdateRSM = 1, sp.UpdateStations = 1
                            where sp.ItemID in
                            (select i.ItemID from Item i
                             where i.SubCategory = {0})
                            ", SubCategoryID));
                            break;
                        case "CreditCategory":
                            Value = tools.string4sql(Value, 10);
                            // update inherited values on items
                            db.ExecuteNonQuery(string.Format(@"
                            update Item
                            set CreditCategory = {1}
                            where (SubCategory = {0})
                            and (InheritCreditCat = 1)
                            ", SubCategoryID, Value));
                            // set related salespacks to rsm and station update
                            db.ExecuteNonQuery(string.Format(@"
                            update SalesPack sp
                            set sp.UpdateRSM = 1, sp.UpdateStations = 1
                            where sp.ItemID in
                            (select i.ItemID from Item i
                             where (i.SubCategory = {0})
                             and (i.InheritCreditCat = 1))
                            ", SubCategoryID));
                            break;
                        case "AgeRestriction":
                            Value = tools.wholenumber4sql(Value);
                            // update inherited values on items
                            db.ExecuteNonQuery(string.Format(@"
                            update Item
                            set AgeRestriction = {1}
                            where (SubCategory = {0})
                            and (InheritAgeRestric = 1)
                            ", SubCategoryID, Value));
                            // set related salespacks to rsm and station update
                            db.ExecuteNonQuery(string.Format(@"
                            update SalesPack sp
                            set sp.UpdateRSM = 1, sp.UpdateStations = 1
                            where sp.ItemID in
                            (select i.ItemID from Item i
                             where (i.SubCategory = {0})
                             and (i.InheritAgeRestric = 1))
                            ", SubCategoryID));
                            break;
                        case "MOPRestriction":
                            Value = tools.wholenumber4sql(Value);
                            // update inherited values on items
                            db.ExecuteNonQuery(string.Format(@"
                            update Item
                            set MOPRestriction = {1}
                            where (SubCategory = {0})
                            and (InheritMOPRestr = 1)
                            ", SubCategoryID, Value));
                            // set related salespacks to rsm and station update
                            db.ExecuteNonQuery(string.Format(@"
                            update SalesPack sp
                            set sp.UpdateRSM = 1, sp.UpdateStations = 1
                            where sp.ItemID in
                            (select i.ItemID from Item i
                             where (i.SubCategory = {0})
                             and (i.InheritMOPRestr = 1))
                            ", SubCategoryID));
                            break;
                        case "ExternalID": Value = tools.string4sql(Value, 30); break;
                        case "BudgetMargin": Value = tools.decimalnumber4sql(Value); break;
                        case "ItemTypeCode":
                            Value = tools.wholenumber4sql(Value);
                            // update inherited values on items
                            db.ExecuteNonQuery(string.Format(@"
                            update Item
                            set ItemTypeCode = {1}
                            where (SubCategory = {0})
                            and (InheritItemTypeCode = 1)
                            ", SubCategoryID, Value));
                            // set related salespacks to rsm and station update
                            db.ExecuteNonQuery(string.Format(@"
                            update SalesPack sp
                            set sp.UpdateRSM = 1, sp.UpdateStations = 1
                            where sp.ItemID in
                            (select i.ItemID from Item i
                             where (i.SubCategory = {0})
                             and (i.InheritItemTypeCode = 1))
                            ", SubCategoryID));
                            break;
                        case "HideInLookup": Value = tools.bool4sql(Value); break;
                        case "NotActive": Value = tools.bool4sql(Value); break;
                        case "GLCode": Value = tools.string4sql(Value, 8); break;
                        case "NeedsDeposit": Value = tools.bool4sql(Value); break;
                    }

                    db.ExecuteNonQuery(string.Format(@"
                    update SubCategory
                    set {1} = {2}
                    where (SubCategoryID = {0})
                    ", SubCategoryID, Field, Value));

                    // set config flag to enforce export of subcategories to rsm
                    db.SetConfigString("ExportRSM.EnforceSubCatExport", true);
                }
            }
            #endregion

            #region UpdateSubCategory
            /// <summary>
            /// Updates each field if needed.
            /// Items with inherited values are also updated.
            /// </summary>
            public static void UpdateSubCategory(
                string SubCategoryID,
                string Description,
                int CategoryID,
                double VatRate,
                string VatOwner,
                string CreditCategory,
                int AgeRestriction,
                int MOPRestriction,
                string ExternalID,
                double BudgetMargin,
                int ItemTypeCode,
                bool HideInLookup,
                bool NotActive,
                string GLCode,
                bool NeedsDeposit)
            {
                if (ItemDataSet.SubCategoryDataTable.GetSubCategoryRow(SubCategoryID) != null)
                {
                    // check each field for different value and update if needed.
                    // also, for those fields that are inherited on items, update
                    // items too, if inherited
                    UpdateFieldAndInheritedIfChanged(SubCategoryID, "Description", Description);
                    UpdateFieldAndInheritedIfChanged(SubCategoryID, "CategoryID", CategoryID);
                    UpdateFieldAndInheritedIfChanged(SubCategoryID, "VatRate", VatRate);
                    UpdateFieldAndInheritedIfChanged(SubCategoryID, "VatOwner", VatOwner);
                    UpdateFieldAndInheritedIfChanged(SubCategoryID, "CreditCategory", CreditCategory);
                    UpdateFieldAndInheritedIfChanged(SubCategoryID, "AgeRestriction", AgeRestriction);
                    UpdateFieldAndInheritedIfChanged(SubCategoryID, "MOPRestriction", MOPRestriction);
                    UpdateFieldAndInheritedIfChanged(SubCategoryID, "ExternalID", ExternalID);
                    UpdateFieldAndInheritedIfChanged(SubCategoryID, "BudgetMargin", BudgetMargin);
                    UpdateFieldAndInheritedIfChanged(SubCategoryID, "ItemTypeCode", ItemTypeCode);
                    UpdateFieldAndInheritedIfChanged(SubCategoryID, "HideInLookup", HideInLookup);
                    if (NotActive == false)
                    {
                        // activating subcategory
                        UpdateFieldAndInheritedIfChanged(SubCategoryID, "NotActive", false);
                    }
                    else
                    {
                        // inactivating subcategory if no items exist on the subcategory
                        bool ItemsExists = (tools.object2int(db.ExecuteScalar(string.Format(@"
                        select count(*) from Item
                        where SubCategory = {0}
                        ", tools.string4sql(SubCategoryID, 20)))) > 0);
                        if (!ItemsExists)
                            UpdateFieldAndInheritedIfChanged(SubCategoryID, "NotActive", true);
                    }
                    UpdateFieldAndInheritedIfChanged(SubCategoryID, "GLCode", GLCode);
                    UpdateFieldAndInheritedIfChanged(SubCategoryID, "NeedsDeposit", NeedsDeposit);
                }
            }
            #endregion

            #region CreateSubCategory

            public static bool CreateSubCategory(
                string SubCategoryID,
                string Description,
                int CategoryID,
                double VatRate,
                string VatOwner,
                string CreditCategory,
                int AgeRestriction,
                int MOPRestriction,
                string ExternalID,
                double BudgetMargin,
                int ItemTypeCode,
                bool HideInLookup,
                bool NotActive,
                string GLCode,
                bool NeedsDeposit)
            {
                if (GetSubCategoryRow(SubCategoryID) == null)
                {
                    db.ExecuteNonQuery(string.Format(@"
                        insert into SubCategory
                        (SubCategoryID,Description,CategoryID,VatRate,VatOwner,CreditCategory,
                         AgeRestriction,MOPRestriction,ExternalID,BudgetMargin,ItemTypeCode,
                         HideInLookup,NotActive,GLCode,NeedsDeposit)
                        values ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14})
                        ",
                         tools.string4sql(SubCategoryID, 20),
                         tools.string4sql(Description, 50),
                         tools.wholenumber4sql(CategoryID),
                         tools.decimalnumber4sql(VatRate),
                         tools.string4sql(VatOwner, 20),
                         tools.string4sql(CreditCategory, 10),
                         tools.wholenumber4sql(AgeRestriction),
                         tools.wholenumber4sql(MOPRestriction),
                         tools.string4sql(ExternalID, 30),
                         tools.decimalnumber4sql(BudgetMargin),
                         tools.wholenumber4sql(ItemTypeCode),
                         tools.bool4sql(HideInLookup),
                         tools.bool4sql(NotActive),
                         tools.string4sql(GLCode, 8),
                         tools.bool4sql(NeedsDeposit)));

                    // set config flag to enforce export of subcategories to rsm
                    db.SetConfigString("ExportRSM.EnforceSubCatExport", true);

                    // subcategory created
                    return true;
                }
                else
                {
                    // already exists
                    return false;
                }
            }

            #endregion

            #region MoveItems
            public static bool MoveItems(string SourceSubCategoryID, string TargetSubCategoryID)
            {
                DataRow SourceSubCatRow = GetSubCategoryRow(SourceSubCategoryID);
                DataRow TargetSubCatRow = GetSubCategoryRow(TargetSubCategoryID);
                if ((SourceSubCatRow != null) && (TargetSubCatRow != null))
                {
                    // set update rsm and station (if FSD) on related salespacks
                    db.ExecuteNonQuery(string.Format(@"
                        update SalesPack sp
                        set sp.UpdateRSM = 1, sp.UpdateStations = 1
                        where sp.ItemID in
                        (select i.ItemID from Item i
                         where i.SubCategory = {0})
                        ",
                         tools.string4sql(SourceSubCategoryID, 20)));

                    // inherit settings from the new subcategory to the items being moved.
                    // (done by updating the old subcategory and related items before moving items)
                    UpdateFieldAndInheritedIfChanged(SourceSubCategoryID, "VatRate", TargetSubCatRow["VatRate"]);
                    UpdateFieldAndInheritedIfChanged(SourceSubCategoryID, "VatOwner", TargetSubCatRow["VatOwner"]);
                    UpdateFieldAndInheritedIfChanged(SourceSubCategoryID, "CreditCategory", TargetSubCatRow["CreditCategory"]);
                    UpdateFieldAndInheritedIfChanged(SourceSubCategoryID, "AgeRestriction", TargetSubCatRow["AgeRestriction"]);
                    UpdateFieldAndInheritedIfChanged(SourceSubCategoryID, "MOPRestriction", TargetSubCatRow["MOPRestriction"]);
                    UpdateFieldAndInheritedIfChanged(SourceSubCategoryID, "ItemTypeCode", TargetSubCatRow["ItemTypeCode"]);

                    // move items to new subcategory
                    db.ExecuteNonQuery(string.Format(@"
                        update Item
                        set SubCategory = {1}
                        where SubCategory = {0}
                        ",
                         tools.string4sql(SourceSubCategoryID, 20),
                         tools.string4sql(TargetSubCategoryID, 20)));

                    // restore the old (now empty) subcategory's values if we later use it again
                    UpdateFieldAndInheritedIfChanged(SourceSubCategoryID, "VatRate", SourceSubCatRow["VatRate"]);
                    UpdateFieldAndInheritedIfChanged(SourceSubCategoryID, "VatOwner", SourceSubCatRow["VatOwner"]);
                    UpdateFieldAndInheritedIfChanged(SourceSubCategoryID, "CreditCategory", SourceSubCatRow["CreditCategory"]);
                    UpdateFieldAndInheritedIfChanged(SourceSubCategoryID, "AgeRestriction", SourceSubCatRow["AgeRestriction"]);
                    UpdateFieldAndInheritedIfChanged(SourceSubCategoryID, "MOPRestriction", SourceSubCatRow["MOPRestriction"]);
                    UpdateFieldAndInheritedIfChanged(SourceSubCategoryID, "ItemTypeCode", SourceSubCatRow["ItemTypeCode"]);

                    // items moved
                    return true;
                }
                else
                {
                    // items not moved
                    return false;
                }
            }
            #endregion

            public static string GetSubCategoryIDFromGLCode(string GLCode)
            {
                return tools.object2string(db.ExecuteScalar(string.Format(@"
                    select SubCategoryID from SubCategory
                    where GLCode = '{0}'
                    ", GLCode.Replace("'", ""))));
            }
        }

        #endregion

        #region PARTIAL CLASS: LookupVatRateDataTable

        partial class LookupVatRateDataTable
        {
            public static double DefaultVATRate = 25;

            /// <summary>
            /// Gets the TaxPct in table LookupTaxID.
            /// </summary>
            /// <param name="TaxID">The TaxID to lookup.</param>
            /// <returns>The found TaxPct. 0 if not found.</returns>
            public static double GetVATPct(int TaxID)
            {
                OleDbCommand cmd = new OleDbCommand("", db.Connection);
                cmd.CommandText = string.Format(
                    " select TaxPct from LookupTaxID " +
                    " where TaxID = {0} ",
                    TaxID);
                return tools.object2double(cmd.ExecuteScalar());
            }

            public static double GetVATPctBySubCategory(string SubCategory)
            {
                DataRow row = ItemDataSet.SubCategoryDataTable.GetSubCategoryRow(SubCategory);
                if (row != null)
                {
                    double VATrate = tools.object2double(row["VatRate"]);
                    return GetVATPct((int)VATrate);
                }
                else
                    return DefaultVATRate;
            }

            public static double GetVATPctByItemID(int ItemID)
            {
                DataRow row = ItemDataSet.ItemDataTable.GetItemRecord(ItemID);
                if (row != null)
                    return GetVATPctBySubCategory(tools.object2string(row["SubCategory"]));
                else
                    return DefaultVATRate;
            }

            public static double GetVATPctBySupplierItem(int SupplierNo, double OrderingNumber)
            {
                return GetVATPctByItemID(ItemDataSet.ItemDataTable.GetItemIDFromSupplierItem(SupplierNo, OrderingNumber));
            }
        }

        #endregion

        #region PARTIAL CLASS: LookupKolliSizeAdminDataTable
        partial class LookupKolliSizeAdminDataTable
        {
            /// <summary>
            /// Checks if the given KolliSize already exists in the table.
            /// Remember to check for actualy changes as if edit a field and
            /// change it to the same value, this method will report as if
            /// the value already exists and the calling code will properly
            /// respond with an error to the user.
            /// </summary>
            /// <returns>True if already exists. False if unique.</returns>
            public bool KolliSizeAlreadyExists(int KolliSize)
            {
                DataRow[] rows = Select("KolliSize = " + KolliSize.ToString());
                return (rows.Length > 0);
            }

            /// <summary>
            /// Checks the SupplierItem table and Item table to find
            /// and display an return that references the given KolliSize.
            /// </summary>
            /// <param name="KolliSize">The kollisize to find in table SupplierItem.</param>
            /// <returns>The name of the item that references the kollisize or "" if none found.</returns>
            public string ReturnFirstItemThatReferencesThis(int KolliSize)
            {
                // to find which item that references the given kollisize,
                // we need to use the supplieritem table

                OleDbCommand cmd = new OleDbCommand("", db.Connection);
                cmd.CommandText = " select ItemID from SupplierItem where KolliSize = " + KolliSize.ToString();
                int ItemID = tools.object2int(cmd.ExecuteScalar());
                cmd.CommandText = " select ItemName from Item where ItemID = " + ItemID.ToString();
                return tools.object2string(cmd.ExecuteScalar());
            }

            #region CreateUserDefinedKolliSizeIfNonExisting
            /// <summary>
            /// Checks if the KolliSize already exists in table LookupKolliSize,
            /// and if not, the KolliSize will be created
            /// </summary>
            public static void CreateUserDefinedKolliSizeIfNonExisting(int KolliSize)
            {
                bool KolliSizeLookupNotFound = (tools.object2int(db.ExecuteScalar(string.Format(
                    " select count(*) from LookupKolliSize " +
                    " where KolliSize = {0} ", KolliSize))) <= 0);
                if (KolliSizeLookupNotFound)
                {
                    db.ExecuteNonQuery(string.Format(
                        " insert into LookupKolliSize " +
                        " (KolliSize,Description,BHHTID) " +
                        " values ({0},{1},{2}) ",
                        KolliSize,
                        tools.string4sql(KolliSize.ToString() + "-PK", 20),
                        1000 + KolliSize));
                }
            }
            #endregion
        }
        #endregion

        #region PARTIAL CLASS: BHHTWSCatListDataTable
        partial class BHHTWSCatListDataTable
        {
            #region CreateNewRecord
            /// <summary>
            /// Inserts a recod into table BHHTCatList using
            /// db.ExecuteNonQuery which works with the active
            /// transaction in db. Static method that works on-disk.
            /// </summary>
            /// <param name="WSID">The autogenerated worksheet header id.</param>
            /// <param name="SubCategoryID">The SubCategoryID.</param>
            public static void CreateNewRecord(int WSID, string SubCategoryID)
            {
                db.ExecuteNonQuery(string.Format(
                    " insert into BHHTWSCatList " +
                    " (WSID, SubCategoryID) " +
                    " values ({0},'{1}') ",
                    WSID,
                    SubCategoryID));
            }
            #endregion

            #region AlreadyExists
            /// <summary>
            /// Checks if the subcategory already exists
            /// within the currently loaded worksheet.
            /// </summary>
            public bool AlreadyExists(string SubCategoryID)
            {
                DataRow[] rows = this.Select(string.Format(" (SubCategoryID = '{0}') ", SubCategoryID.Replace("'", "")));
                return (rows.Length > 0);
            }
            #endregion
        }
        #endregion

        #region PARTIAL CLASS: BHHTWSItemListDataTable
        partial class BHHTWSItemListDataTable
        {
            #region AlreadyExists
            /// <summary>
            /// Checks if the item already exists
            /// within the currently loaded worksheet.
            /// </summary>
            public bool AlreadyExists(int ItemID)
            {
                DataRow[] rows = this.Select(string.Format(" (ItemID = '{0}') ", ItemID.ToString()));
                return (rows.Length > 0);
            }
            #endregion
        }
        #endregion

        #region PARTIAL CLASS: BHHTWorksheetDataTable
        partial class BHHTWorksheetDataTable
        {
            public static int CreateNewRecord()
            {
                OleDbCommand cmd = new OleDbCommand("", db.Connection);

                cmd.CommandText = " insert into BHHTWorksheet (Name) values (NULL) ";
                cmd.ExecuteNonQuery();

                cmd.CommandText = " select max(ID) from BHHTWorksheet ";
                return tools.object2int(cmd.ExecuteScalar());
            }

            #region CreateNewRecord
            /// <summary>
            /// Inserts a record into table BHHTWorksheet.
            /// Uses the db.ExecuteNonQuery method which uses
            /// any active transaction. This makes this method
            /// useful in the updater too as the updater uses
            /// a transaction. Static method that works with
            /// on-disk data.
            /// </summary>
            /// <param name="name">The worksheet name.</param>
            /// <param name="type">The worksheet type. c = count, a = adjustment.</param>
            /// <param name="include">The worksheet include code. c = category, i = item, a = all.</param>
            /// <returns>The autogenerated header id.</returns>
            public static int CreateNewRecord(string name, char type, char include)
            {
                // insert new record
                db.ExecuteNonQuery(string.Format(
                    " insert into BHHTWorksheet " +
                    " (Name,Type,Include) " +
                    " values ('{0}','{1}','{2}') ",
                    name, type, include));

                // get and return autocreated worksheet id
                return tools.object2int(db.ExecuteScalar(" select max(ID) from BHHTWorksheet "));
            }
            #endregion
        }
        #endregion

        #region ItemTransactionRBADataTable
        partial class ItemTransactionRBADataTable
        {
            #region WriteTransactionRecord
            public static void WriteTransactionRecord(int LevNr, double Varenummer, int NumberOf, string Initials, DateTime OpenDay)
            {
                // lookup som values
                long TransactionNumber = db.GetNextItemTransactionID(true);
                string Varenavn = AfskrProdDataTable.GetVarenavn(LevNr, Varenummer);
                double Amount = NumberOf * AfskrProdDataTable.GetKostpris(LevNr, Varenummer);

                // build sql
                string sql = string.Format(@"
                    insert into ItemTransactionRBA
                    (TransactionNumber, PostingDate, LevNr, Varenummer, Varenavn, NumberOf, Amount, Initials)
                    values ({0},{1},{2},{3},{4},{5},{6},{7})
                    ",
                     TransactionNumber,
                     tools.datetime4sql(OpenDay),
                     tools.wholenumber4sql(LevNr),
                     tools.decimalnumber4sql(Varenummer),
                     tools.string4sql(Varenavn, 255),
                     tools.wholenumber4sql(NumberOf),
                     tools.decimalnumber4sql(Amount),
                     tools.string4sql(Initials, 10)
                     );

                // write transaction record
                db.ExecuteNonQuery(sql);
            }
            #endregion

            #region CheckIfAnyTransactionRecords
            public static bool CheckIfAnyTransactionRecords(DateTime OpenDay)
            {
                string sql = string.Format(@"
select count(*) from ItemTransactionRBA
where PostingDate = '{0}'
", OpenDay);
                return tools.object2int(db.ExecuteScalar(sql)) > 0;
            }
            #endregion
        }
        #endregion

        #region PARTIAL CLASS: ItemTransactionDataTable

        partial class ItemTransactionDataTable
        {
            #region METHOD: WriteTransactionRecord

            /// <summary>
            /// Writes a record in ItemTransaction.
            /// This is the only way you should write data to ItemTransaction,
            /// as some stock calculations are performed too.
            /// Overloaded.
            /// </summary>
            public static void WriteTransactionRecord(
                int ItemID,
                DateTime PostingDate,
                int TransactionType,
                int NumberOf,
                double Amount,
                int SalesPackType,
                Nullable<double> Barcode,
                int NoOfSellingUnits,
                double CostPrice,
                bool UpdateItemInStock)
            {
                // note: ReasonCode field is left NULL, as we don't use it at all

                // variables needed more than once
                OleDbCommand cmd = new OleDbCommand("", db.Connection);

                // get the next item transaction number
                long TransactionNumber = db.GetNextItemTransactionID(true);

                // Barcode can be null as some callers don't have this value,
                // so handle null to be inserted in database
                string sBarcode = (Barcode.HasValue ? "'" + Barcode.ToString() + "'" : "NULL");

                // handle that CostPrice can be null
                //string sCostPrice = (CostPrice.HasValue ? "'" + CostPrice.ToString() + "'" : "NULL");

                // write item transaction record
                cmd.CommandText = string.Format(
                    " insert into ItemTransaction " +
                    " (TransactionNumber,ItemID,PostingDate,TransactionType,NumberOf,Amount,SalesPackType,Barcode,NoOfSellingUnits,CostPrice) " +
                    " values ( {0},{1},{2},{3},{4},{5},{6},{7},{8},{9} ) ",
                    TransactionNumber,
                    ItemID,
                    "'" + PostingDate + "'",
                    TransactionType,
                    NumberOf,
                    tools.decimalnumber4sql(Amount),
                    SalesPackType,
                    sBarcode, // '' is added above
                    NoOfSellingUnits,
                    tools.decimalnumber4sql(CostPrice)); // '' is added above
                string test = cmd.CommandText;
                cmd.Transaction = db.CurrentTransaction;
                cmd.ExecuteNonQuery();

                // if transaction type is Count
                if (TransactionType == (byte)db.TransactionTypes.Count)
                {
                    // set LastInventDate on item
                    ItemDataSet.ItemDataTable.UpdateLastInventDate(ItemID, PostingDate);
                }

                // update the item's InStock value
                if (UpdateItemInStock)
                    ItemDataSet.ItemDataTable.ReCalculateInStock(ItemID);
            }

            #endregion

            //#region METHOD: CalcItemOnHandPerDate

            ///// <summary>
            ///// Calculates all on hand stock on the given item
            ///// and does not enclose records with transaction type Count (optælling).
            ///// Static method that operates directly with on-disk data.
            ///// </summary>
            //public static int CalcItemOnHandPerDate(int ItemID)
            //{
            //    return CalcItemOnHandPerDate(ItemID, DateTime.MaxValue);
            //}

            ///// <summary>
            ///// Calculates the on hand stock on the given item up to the given date
            ///// and does not enclose records with transaction type Count (optælling)
            ///// and type SalesCount.
            ///// Static method that operates directly with on-disk data.
            ///// </summary>
            //public static int CalcItemOnHandPerDate(int ItemID, DateTime Date)
            //{
            //    // find the last record with type count (opt).
            //    // if not found TransactionNumber will be 0,
            //    // and so calculation will start from beginning.
            //    int TransactionNumber = tools.object2int(db.ExecuteScalar(string.Format(
            //        " select max(TransactionNumber) " +
            //        " from ItemTransaction " +
            //        " where (ItemID = {0}) " +
            //        " and (TransactionType = {1}) ",
            //        ItemID, (byte)db.TransactionTypes.Count)));

            //    // type count adjustment can never exist after count
            //    // so they are already excluded
            //    OleDbCommand cmd = new OleDbCommand("", db.Connection);
            //    cmd.CommandText = string.Format(
            //        " select sum(NoOfSellingUnits) from ItemTransaction " +
            //        " where (ItemID = {0}) " +
            //        " and (PostingDate <= cdate('{1}')) " +
            //        " and (TransactionType <> {2}) " +
            //        " and (TransactionNumber >= {3}) ",
            //        ItemID,
            //        Date,
            //        (int)db.TransactionTypes.SalesCount,
            //        TransactionNumber);
            //    return tools.object2int(cmd.ExecuteScalar());
            //}

            //#endregion

            //#region CalcItemOnHandPerDateNoLimit
            ///// <summary>
            ///// Calculates the on hand stock on the given date.
            ///// Does not limit to from the last Count.
            ///// </summary>
            //public static int CalcItemOnHandPerDateNoLimit(int ItemID, DateTime Date)
            //{
            //    return tools.object2int(db.ExecuteScalar(string.Format(
            //        " select sum(NoOfSellingUnits) from ItemTransaction " +
            //        " where (ItemID = {0}) " +
            //        " and (PostingDate <= cdate('{1}')) " +
            //        " and (TransactionType <> {2}) ",
            //        ItemID,
            //        Date,
            //        (int)db.TransactionTypes.Count)));
            //}
            //#endregion

            #region CalcItemOnHandPerDateNoLimit
            /// <summary>
            /// Calculates the on hand stock on the given period.
            /// Does not limit to from the last Count.
            /// </summary>
            public static int CalcItemOnHandPerDateNoLimit(
                int ItemID,
                DateTime StartDate,
                DateTime EndDate,
                db.TransactionTypes TransactionType)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(
                    " select sum(NoOfSellingUnits) from ItemTransaction " +
                    " where (ItemID = {0}) " +
                    " and (PostingDate >= '{1}') " +
                    " and (PostingDate <= '{2}') " +
                    " and (TransactionType = {3}) ",
                    ItemID,
                    StartDate,
                    EndDate,
                    (int)TransactionType)));
            }
            #endregion

            #region CalculateStock
            public static int CalculateStock(int ItemID, DateTime ToDate)
            {
                /// NOTE: if the logic in this method changed,
                /// it is important to also change the logic in the
                /// method ItemDataTabe.ReCalculateInStock, as it
                /// contains the same logic.

                // find the last record with type count (opt).
                // if not found, record will be null,
                // and calculation will start from beginning
                int TransactionNumber = 0;
                DateTime PostingDate = new DateTime(2020, 01, 01);//pn20190812           
                DataRow LatestOptaellingRow = db.GetDataRow(string.Format(@"
                    select top 1 TransactionNumber, PostingDate
                    from ItemTransaction
                    where (ItemID = {0})
                    and (TransactionType = {1})
                    and (PostingDate <= '{2}')
                    order by ItemID,  TransactionType, PostingDate desc, TransactionNumber desc
                    ", ItemID, (byte)db.TransactionTypes.Count, ToDate));
                //pn20210114
                if (LatestOptaellingRow != null)
                {
                    TransactionNumber = tools.object2int(LatestOptaellingRow["TransactionNumber"]);
                    PostingDate = tools.object2datetime(LatestOptaellingRow["PostingDate"]);
                }


                //calculate everything after optælling including the optælling
                //or from the beginning within the given item.
                return tools.object2int(db.ExecuteScalar(string.Format(@"
                        select sum(NoOfSellingUnits)
                        from ItemTransaction
                        where (ItemID = {0})
                        and ((PostingDate > '{2}') or ((PostingDate = '{2}') and (TransactionNumber >= {1})))
                        and (PostingDate <= '{3}') ",
                    ItemID,
                    TransactionNumber,
                    PostingDate,
                    ToDate)));


            }
            #endregion

            #region METHOD: TransactionExists
            /// <summary>
            /// Tells if a record exists with the given values.
            /// Static method that works with on-disk data.
            /// </summary>
            public static bool TransactionExists(
                int ItemID,
                DateTime PostingDate,
                int TransactionType)
            {
                OleDbCommand cmd = new OleDbCommand("", db.Connection);
                cmd.CommandText = string.Format(
                    " select TransactionNumber " +
                    " from ItemTransaction " +
                    " where (ItemID = {0}) " +
                    " and (PostingDate = '{1}') " +
                    " and (TransactionType = {2}) ",
                    ItemID, PostingDate, TransactionType);
                return (!tools.IsNullOrDBNull(cmd.ExecuteScalar()));
            }
            #endregion

            #region DeleteRecords
            public static void DeleteRecords(int ItemID)
            {
                db.ExecuteNonQuery(string.Format(@"
                    delete from ItemTransaction where ItemID = {0}
                    ", ItemID));
            }
            #endregion

            #region RepairSalgOptRecords
            /// <summary>
            /// Repairs an error in the ItemTransaction records,
            /// where we have been zeroing records of type SalgOpt when
            /// we got the say's sales. The days sales is okay, but instead
            /// of zeroing the SalesOpt record, we want to make a counter-SalesOpt
            /// record that comes after the SalesOpt record and before the next
            /// Sales record. In this repair, the counter-SalesOpt record will not
            /// come before the Sales record, but that doesn't matter. The
            /// counter-SalesOpt record will be of type Sales.
            /// </summary>
            public static void RepairSalgOptRecords()
            {
                ProgressForm progress = new ProgressForm("Tjekker varetransaktioner");
                progress.StatusText = "Starter op";
                progress.Show();

                /// as we potentially are going to process a large number of records,
                /// it would be nicests for memory consumption if we make a list of dates
                /// to traverse in the table ItemTransaction. then we can limit the data
                /// load from variouis tables to related data.
                DataTable ListOfDatesAndItems = db.GetDataTable(string.Format(@"
                select distinct PostingDate, ItemID
                from ItemTransaction
                where TransactionType = {0}
                order by PostingDate"
                  , (int)db.TransactionTypes.SalesCount));
                progress.ProgressMax = ListOfDatesAndItems.Rows.Count;
                foreach (DataRow rowDateAndItem in ListOfDatesAndItems.Rows)
                {
                    DateTime PostingDate = tools.object2datetime(rowDateAndItem["PostingDate"]).Date;
                    int ItemID = tools.object2int(rowDateAndItem["ItemID"]);

                    // show progress
                    progress.StatusText = string.Format(
                      "Behandler dato {0} for vare {1}",
                      PostingDate.ToString("dd-MM-yyyy"),
                      ItemDataTable.GetItemName(ItemID));

                    // load ItemTransaction records for the current date and item
                    DataTable SetOfTransations = db.GetDataTable(string.Format(@"
                  select * from ItemTransaction
                  where (PostingDate = '{0}')
                  and (ItemID = {1})
                  order by TransactionNumber
                  ", PostingDate, ItemID));

                    if (SetOfTransations.Rows.Count > 0)
                    {
                        // find the records SalgOpt, Optaelling and the Sales record
                        // that comes just after the SalgOpt
                        DataRow rowSalgOpt = null;
                        DataRow rowOptaelling = null;
                        DataRow rowSalgLigeEfterSalgOpt = null;
                        bool NowWeNeedToFindTheNextSalesRow = false;
                        foreach (DataRow row in SetOfTransations.Rows)
                        {
                            // find SalgOpt record
                            if (tools.object2int(row["TransactionType"]) == (int)db.TransactionTypes.SalesCount)
                            {
                                rowSalgOpt = row;
                                NowWeNeedToFindTheNextSalesRow = true;
                            }
                            // find Optaelling record
                            if (tools.object2int(row["TransactionType"]) == (int)db.TransactionTypes.Count)
                                rowOptaelling = row;
                            // find the Sales record that comes just after the SalgOpt record
                            if ((NowWeNeedToFindTheNextSalesRow) &&
                                (tools.object2int(row["TransactionType"]) == (int)db.TransactionTypes.Sales))
                            {
                                rowSalgLigeEfterSalgOpt = row;
                                NowWeNeedToFindTheNextSalesRow = false;
                            }
                        }

                        // if this date and item has a SalgOpt, Optælling and efterfølgende Salg record, we will process it
                        if ((rowSalgOpt != null) && (rowOptaelling != null) && (rowSalgLigeEfterSalgOpt != null))
                        {
                            /// Check that the SalgOpt record has 0 in Amount. If it does not, the record has either:
                            /// 1) been fixed already, or
                            /// 2) was created correctly from the beginning, or
                            /// 3) the efterfølgende Salg record has not yet come in from the ISM file
                            /// In either case, if the Amount is different from 0, we do not process this date and item
                            if (tools.object2double(rowSalgOpt["Amount"]) == 0)
                            {
                                /// Now, to figure out what originally was in the SalgOpt record,
                                /// we need to look in that date's and item's handterminal detail count records.
                                /// Those can be found in the tables BookedInvCountDetail and BookedInvCountHeader.

                                // get the SalesPEJ (sellingunit) for this date and item
                                int NoOfSellingUnits = tools.object2int(db.ExecuteScalar(string.Format(@"
                      select sum(details.SalesPEJ)
                      from BookedInvCountDetail details
                      inner join BookedInvCountHeader header
                        on details.HeaderID = header.ID
                      where (header.BookDate = '{0}')
                      and (details.ItemID = {1})
                      ", PostingDate, ItemID))) * -1;

                                // calculate the Amount by first calculating the price per unit
                                double UnitPrice =
                                  tools.object2double(rowSalgLigeEfterSalgOpt["Amount"]) /
                                  tools.object2int(rowSalgLigeEfterSalgOpt["NoOfSellingUnits"]);
                                double Amount = UnitPrice * NoOfSellingUnits;

                                // update the existing SalesOpt record
                                db.ExecuteNonQuery(string.Format(@"
                      update ItemTransaction set
                      NumberOf = -1,
                      NoOfSellingUnits = {1},
                      Amount = '{2}'
                      where TransactionNumber = {0}                                             
                      ",
                                   tools.object2int(rowSalgOpt["TransactionNumber"]),
                                   NoOfSellingUnits,
                                   Amount));

                                // create the counter-Sales record
                                WriteTransactionRecord(
                                  ItemID,
                                  PostingDate,
                                  (byte)db.TransactionTypes.Sales,
                                  1, // number of
                                  Amount * -1,
                                  1, // packtype
                                  null, // barcode
                                  NoOfSellingUnits * -1,
                                  0,
                                  false);
                            }
                        }
                    }
                }
            }
            #endregion

            /// <summary>
            /// Creates a counter SalgOpt record (counter SalesCount)
            /// for the SalgOpt record that was created before the Count was done.
            /// This is done because the ISM import contains the sales for the whole day,
            /// so we need to make a record to eliminate the previously recorded sales before Count.
            /// </summary>
            public static void CreateSalgOptCounterRecordAsNeeded(DateTime PostingDate, int ItemID)
            {
                PostingDate = PostingDate.Date;

                // find out if there is a Salg record on this date and item
                bool SalgExists = (tools.object2int(db.ExecuteScalar(string.Format(@"
          select count(*) from ItemTransaction
          where (PostingDate = '{0}')
          and (ItemID = {1})
          and (TransactionType = {2})
          ", PostingDate, ItemID, (byte)db.TransactionTypes.Sales))) > 0);
                if (!SalgExists)
                {
                    // get the SalgOpt record (if any) for this date and item
                    DataRow SalgOptRecord = db.GetDataRow(string.Format(@"
          select * from ItemTransaction
          where (PostingDate = '{0}')
          and (ItemID = {1})
          and (TransactionType = {2})
          ", PostingDate, ItemID, (byte)db.TransactionTypes.SalesCount));
                    if (SalgOptRecord != null)
                    {
                        int NumberOf = tools.object2int(SalgOptRecord["NumberOf"]) * -1;
                        double Amount = tools.object2double(SalgOptRecord["Amount"]) * -1;
                        int NoOfSellingUnits = tools.object2int(SalgOptRecord["NoOfSellingUnits"]) * -1;

                        // create the counter-Sales record
                        WriteTransactionRecord(
                          ItemID,
                          PostingDate,
                          (byte)db.TransactionTypes.Sales,
                          NumberOf,
                          Amount,
                          1, // PackType
                          null, // Barcode
                          NoOfSellingUnits,
                          0, // CostPrice
                          false); // UpdateItemInStock
                    }
                }
            }
        }

        #endregion

        #region PARTIAL CLASS: OrderDetailsDataTable

        partial class OrderDetailsDataTable
        {
            public delegate void CostPriceChanged();
            public event CostPriceChanged OnCostPriceChanged = null;

            #region OnColumnChanged
            // OnColumnChanged event handler
            protected override void OnColumnChanged(DataColumnChangeEventArgs e)
            {
                // whenever a column changes, and the LineNo field is NULL,
                // assign the next LineNo to that row.
                if (e.Row["LineNo"] == DBNull.Value)
                    e.Row["LineNo"] = GenerateNextLineNo();

                // whenever the value of cost changes, we change the cost ex vat value too
                if (e.Column == CostColumn)
                {
                    // get the parent order's SupplierNo and this record's OrderingNumber
                    int OrderID = tools.object2int(e.Row[OrderIDColumn]);
                    int SupplierNo = OrderHeaderDataTable.GetSupplierNo(OrderID);
                    double OrderingNumber = tools.object2double(e.Row[OrderingNumberColumn]);

                    // get the VAT rate associated with this supplier item
                    double VAT = ItemDataSet.LookupVatRateDataTable.GetVATPctBySupplierItem(SupplierNo, OrderingNumber);

                    // calculate the cost price ex. VAT and write it to the record
                    e.Row[CostExVATColumn] = tools.DeductVAT(tools.object2double(e.ProposedValue), VAT);

                    // as we have changed the cost column, call the 
                    if (OnCostPriceChanged != null)
                        OnCostPriceChanged();
                }

                base.OnColumnChanged(e);
            }
            #endregion

            #region GenerateNextLineNo (non-static version)
            /// <summary>
            /// Non-static version of this method. Note that
            /// there is also a static version.
            /// Returns the max LineNo + 1 for the loaded order.
            /// Does not write the value to the table.
            /// This method works with in-memory data.
            /// </summary>
            public int GenerateNextLineNo()
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
            #endregion

            #region GenerateNextLineNo (static version)
            /// <summary>
            /// Static version of this method. Note that
            /// there is also a non-static version.
            /// Returns the max LineNo + 1 for the given order.
            /// Does not write the value to the table.
            /// This method works with on-disk data.
            /// </summary>
            public static int GenerateNextLineNo(int OrderID)
            {
                OleDbCommand cmd = new OleDbCommand("", db.Connection);
                cmd.CommandText = string.Format(
                    " select max([LineNo]) from OrderDetails where OrderID = {0} ",
                    OrderID);
                return (tools.object2int(cmd.ExecuteScalar()) + 1);
            }
            #endregion
        }

        #endregion

        #region PARTIAL CLASS: OrderHeaderDataTable

        partial class OrderHeaderDataTable
        {
            #region CreateNewOrderHeader
            /// <summary>
            /// Creates a new OrderHeader record and returns the
            /// auto created OrderID. The OrderStatus of the record
            /// is set to "OPN".
            /// </summary>
            /// <returns>Auto generated OrderID</returns>
            public int CreateNewOrderHeader(int SupplierID)
            {
                OleDbCommand cmd = new OleDbCommand("", db.Connection);

                // create new empty order header record and save it to disk.
                cmd.CommandText = string.Format(
                    " insert into OrderHeader (OrderStatus,SupplierID) values ('OPN',{0}) ",
                    SupplierID);
                cmd.ExecuteNonQuery();

                // retrieve and return the auto created OrderID
                return RetrieveMaxOrderID();
            }
            #endregion

            #region RetrieveMaxOrderID
            /// <summary>
            /// Retrieves the max(OrderID) from table OrderHeader.
            /// This is a static method and works with on-disk data,
            /// NOT with in-memory data.
            /// </summary>
            public static int RetrieveMaxOrderID()
            {
                // retrieve and return the auto created OrderID
                OleDbCommand cmd = new OleDbCommand("", db.Connection);
                cmd.CommandText = " select max(OrderID) from OrderHeader ";
                return tools.object2int(cmd.ExecuteScalar());
            }
            #endregion

            #region DeleteOrderAndItsDetails
            /// <summary>
            /// Deletes a OrderHeader record and all
            /// its related OrderDetail records. Prompt
            /// user first if this is ok before calling this method.
            /// </summary>
            public void DeleteOrderAndItsDetails(long OrderID)
            {
                OleDbCommand cmd = new OleDbCommand("", db.Connection);

                // delete all header records
                cmd.CommandText = string.Format(" delete from OrderHeader where OrderID = {0} ", OrderID);
                cmd.ExecuteNonQuery();

                // delete all detail records
                cmd.CommandText = string.Format(" delete from OrderDetails where OrderID = {0} ", OrderID);
                cmd.ExecuteNonQuery();
            }
            #endregion

            #region GetSupplierName
            /// <summary>
            /// Gets the name of the supplier
            /// selected for the given order.
            /// Works with on-disk data.
            /// </summary>
            /// <returns>The SupplierName or "" if some error or not found.</returns>
            public static string GetSupplierName(int OrderID)
            {
                OleDbCommand cmd = new OleDbCommand("", db.Connection);
                cmd.CommandText = string.Format(
                    " select Supplier.Description " +
                    " from OrderHeader " +
                    " inner join Supplier " +
                    " on OrderHeader.SupplierID = Supplier.SupplierID " +
                    " where OrderHeader.OrderID = {0} ",
                    OrderID);
                return tools.object2string(cmd.ExecuteScalar());
            }
            #endregion

            public static int GetSupplierNo(int OrderID)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(@"
                    select SupplierID from OrderHeader
                    where OrderID = {0}
                    ", OrderID)));
            }
        }

        #endregion

        #region PARTIAL CLASS: OrderDraftDetailsDataTable
        partial class OrderDraftDetailsDataTable
        {
            #region OnColumnChanged
            // OnColumnChanged event handler
            protected override void OnColumnChanged(DataColumnChangeEventArgs e)
            {
                // whenever a column changes, and the LineNo field is NULL,
                // assign the next LineNo to that row.
                if (e.Row["LineNo"] == DBNull.Value)
                    e.Row["LineNo"] = GenerateNextLineNo();

                base.OnColumnChanged(e);
            }
            #endregion

            #region GenerateNextLineNo (2 overloads)

            /// <summary>
            /// Returns the max LineNo + 1 for the loaded draft.
            /// This overload of the method works with in-memory data.
            /// </summary>
            private int GenerateNextLineNo()
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
            /// Returns the max LineNo + 1 for the loaded draft.
            /// This static overload of the method works with on-disk data.
            /// </summary>
            public static int GenerateNextLineNo(int DraftID)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(
                    " select max([LineNo]) " +
                    " from OrderDraftDetails " +
                    " where DraftID = {0} ",
                    DraftID))) + 1;
            }

            #endregion

            #region NumberOfValidRecords
            /// <summary>
            /// Finds out how many valid records this table has.
            /// A valid record has a RowState which is neither
            /// Deleted or Detached. Works on in-memory data.
            /// One could just call AcceptChanges before checking
            /// ds.table.Rows.Count, but then a call an adapter's Update
            /// will not write new records back to the database.
            /// </summary>
            public int NumberOfValidRecords()
            {
                int num = 0;
                foreach (DataRow row in this.Rows)
                {
                    if ((row.RowState != DataRowState.Deleted) &&
                        (row.RowState != DataRowState.Detached))
                        ++num;
                }
                return num;
            }
            #endregion
        }
        #endregion

        #region PARTIAL CLASS OrderDraftDataTable

        partial class OrderDraftDataTable
        {
            #region CreateNewOrderDraft
            /// <summary>
            /// Creates a new OrderDraft record and returns the
            /// auto created DraftID.
            /// </summary>
            /// <returns>Auto generated DraftID</returns>
            public int CreateNewOrderDraft()
            {
                OleDbCommand cmd = new OleDbCommand("", db.Connection);

                // create new empty order draft record and save it to disk.
                cmd.CommandText = " insert into OrderDraft (SupplierID) values (NULL) ";
                cmd.ExecuteNonQuery();

                // retrieve and return the auto created DraftID
                cmd.CommandText = " select max(DraftID) from OrderDraft ";
                object o = cmd.ExecuteScalar();
                return tools.object2int(o);
            }
            #endregion

            #region DeleteDraftAndItsDetails
            /// <summary>
            /// Deletes a OrderDraft record and all
            /// its related OrderDraftDetail records. Prompt
            /// user first if this is ok before calling this method.
            /// </summary>
            public void DeleteDraftAndItsDetails(long DraftID)
            {
                OleDbCommand cmd = new OleDbCommand("", db.Connection);

                // delete all header records
                cmd.CommandText = string.Format(" delete from OrderDraft where DraftID = {0} ", DraftID);
                cmd.ExecuteNonQuery();

                // delete all detail records
                cmd.CommandText = string.Format(" delete from OrderDraftDetails where DraftID = {0} ", DraftID);
                cmd.ExecuteNonQuery();
            }
            #endregion
        }

        #endregion

        #region PARTIAL CLASS: SupplierItemDataTable

        /// <summary>
        /// Custom code for table SupplierItem
        /// </summary>
        partial class SupplierItemDataTable
        {
            #region PROPERTY LastError
            private string lastError = "";
            public string LastError
            {
                get { return lastError; }
            }
            #endregion

            #region METHOD: CheckCombinationOfSupplierNoAndOrderingNumberIsUnique
            /// <summary>
            /// Checks whether the combination of SupplierNo and OrderingNo is unique,
            /// both checing in-memory suppliers and on-disk suppliers. If the ID is
            /// the same as the found combination, it is still considered unique, as
            /// it is the same value written to the same row.
            /// </summary>
            /// <param name="SupplierNo"></param>
            /// <param name="OrderingNo"></param>
            /// <returns></returns>
            public bool CheckCombinationOfSupplierNoAndOrderingNumberIsUnique(long ID, long SupplierNo, double OrderingNo)
            {
                lastError = db.GetLangString("ItemDataSet.SupplierItem.CombinationNotUnique");

                // check in-memory table (only contains (edited) data for current item)
                string filter = string.Format(
                    " (SupplierNo = {0}) and (OrderingNumber = '{1}') and (ID <> {2}) ",
                    SupplierNo, OrderingNo, ID);
                DataRow[] rows = this.Select(filter);
                if (rows.Length > 0)
                {
                    string ItemName = ItemDataSet.ItemDataTable.GetItemName(tools.object2int(rows[0]["ItemID"]));
                    lastError = string.Format(lastError, ItemName);
                    return false; // not unique
                }

                // check on-disk table (all non-edited data)
                string sql = string.Format(
                    " select ItemID from SupplierItem " +
                    " where (SupplierNo = {0}) and (OrderingNumber = {1}) and (ID <> {2}) ",
                    SupplierNo, OrderingNo, ID);
                OleDbCommand cmd = new OleDbCommand(sql, db.Connection);
                object o = cmd.ExecuteScalar();
                if ((o != null) && (o != DBNull.Value))
                {
                    string ItemName = ItemDataSet.ItemDataTable.GetItemName(tools.object2int(o));
                    lastError = string.Format(lastError, ItemName);
                    return false; // not unique
                }

                // combination is unique
                lastError = "";
                return true;
            }
            #endregion

            #region METHOD: HasAPrimaryRecord
            /// <summary>
            /// Checks if the SupplierItem table has at least one record
            /// with IsPrimary set  for the loaded table.
            /// </summary>
            /// <returns></returns>            
            public bool HasAPrimaryRecord()
            {
                return (this.Select("IsPrimary = 1").Length > 0);
            }
            #endregion

            #region METHOD: GetSupplierItem
            /// <summary>
            /// Gets the SupplierItem row with the given ID.
            /// This method is static and works with on-disk data.
            /// </summary>
            /// <param name="SupplierItemID">The ID column in table SupplierItem.</param>
            /// <returns>The supplier item DataRow if found. Null if not found.</returns>
            public static DataRow GetSupplierItem(int SupplierItemID)
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter("", db.Connection);
                DataTable table = new DataTable();
                adapter.SelectCommand.CommandText = string.Format(
                    " select * from SupplierItem " +
                    " where ID = {0} ",
                    SupplierItemID);
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                    return table.Rows[0];
                else
                    return null;
            }

            public static DataRow GetSupplierItem(int SupplierNo, double OrderingNumber)
            {
                return db.GetDataRow(string.Format(@"
                    select * from SupplierItem
                    where (SupplierNo = {0})
                    and (OrderingNumber = {1})
                    ", SupplierNo, OrderingNumber));
            }
            #endregion

            #region METHOD: GetSupplierItemPackageCost
            /// <summary>
            /// Returns PackageCostfor the supplieritem found with itemid and packtype.
            /// If not found, the itemid is used to locate an item and return its
            /// costpricelatest. If that fails too, 0 is returned.
            /// </summary>
            public static double GetSupplierItemPackageCost(int ItemID, int PackType)
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter("", db.Connection);
                DataTable table = new DataTable();
                adapter.SelectCommand.CommandText = string.Format(
                    " select PackageUnitCost from SupplierItem " +
                    " where (ItemID = {0}) and (SellingPackType = {1}) ",
                    ItemID, PackType);
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                    return tools.object2double(table.Rows[0]["PackageUnitCost"]);
                else
                {
                    OleDbCommand cmd = new OleDbCommand("", db.Connection);
                    cmd.CommandText = string.Format(
                        " select CostPriceLatest from Item " +
                        " where ItemID = {0} ",
                        ItemID);
                    return tools.object2double(cmd.ExecuteScalar());
                }
            }
            #endregion

            #region CalculatePackageCost
            public static double CalculatePackageCost(double PackageUnitCost, int KolliSize)
            {
                return PackageUnitCost * KolliSize;
            }
            #endregion

            #region CalcCostPriceExVAT
            public static double CalcCostPriceExVAT(int ItemID)
            {
                OleDbCommand cmd = new OleDbCommand("", db.Connection);
                double CostPrice = 0;

                // we need to access the item
                DataRow rowItem = ItemDataSet.ItemDataTable.GetItemRecord(ItemID);

                // check for valid ItemID
                if (rowItem == null) return 0;

                // first try to get the selling unit cost from the primary SupplierItem
                cmd.CommandText = string.Format(
                    " select SellingUnitCost " +
                    " from SupplierItem " +
                    " where (ItemID = {0}) " +
                    " and (IsPrimary = 1) ",
                    ItemID);
                CostPrice = tools.object2double(cmd.ExecuteScalar());

                // if that fails
                if (CostPrice == 0)
                {
                    // try to get the latest cost price from the item
                    CostPrice = tools.object2double(rowItem["CostPriceLatest"]);

                    // if that fails
                    if (CostPrice == 0)
                    {
                        // calculate the cost price by using the sales price and margin (dækningsgrad)
                        double SalesPrice = tools.object2double(rowItem["POSSalesPrice"]);
                        double Margin = tools.object2double(rowItem["BudgetMargin"]);
                        CostPrice = SalesPrice * ((100 - Margin) / 100);
                    }
                }

                // deduct VAT
                double VATPct = LookupVatRateDataTable.GetVATPct(tools.object2int(rowItem["VatRate"]));
                CostPrice = CostPrice / ((100 + VATPct) / 100);

                // return cost price without VAT
                return CostPrice;
            }
            #endregion

            #region UpdateCostPrice
            /// <summary>
            /// Updates the cost price / PackageUnitCost.
            /// Static method that ONLY works with on-disk data.
            /// </summary>
            public static void UpdateCostPrice(double CostPrice, int SupplierNo, double OrderingNumber)
            {
                double PackageUnitCost = CostPrice;

                // get a SupplierItem record to work with
                DataRow supplierItem = db.GetDataRow(string.Format(
                    " select * from SupplierItem " +
                    " where (SupplierNo = {0}) " +
                    " and (OrderingNumber = {1}) ",
                    SupplierNo, OrderingNumber));
                if (supplierItem == null) return; // data check

                // re-calculate PackageCost
                int KolliSize = tools.object2int(supplierItem["KolliSize"]);
                double PackageCost = PackageUnitCost * KolliSize;

                // re-calculate SellingUnitCost       
                double SellingUnitCost = 0;
                int NoOfSellingUnits = tools.object2int(supplierItem["NoOfSellingUnits"]);
                if (NoOfSellingUnits != 0)
                    SellingUnitCost = PackageUnitCost / NoOfSellingUnits;

                // perform the update
                db.ExecuteNonQuery(string.Format(
                    " update SupplierItem set " +
                    " PackageUnitCost = {0}, " +
                    " PackageCost = {1}, " +
                    " SellingUnitCost = {2} " +
                    " where ID = {3} ",
                    tools.decimalnumber4sql(PackageUnitCost),
                    tools.decimalnumber4sql(PackageCost),
                    tools.decimalnumber4sql(SellingUnitCost),
                    supplierItem["ID"]));

                int ItemID = tools.object2int(supplierItem["ItemID"]);

                // if this is the primary supplier item, update item
                if (tools.object2bool(supplierItem["IsPrimary"]))
                {
                    ItemDataTable.UpdateCostPriceLatest(ItemID, PackageUnitCost);
                }

                // mark item for update on stations, if BFI version
#if FSD
                SalesPackDataTable.SetUpdateStations(ItemID, true);
#endif
            }
            #endregion

            #region UpdateKolliSizeAndKeepPackageUnitCost
            /// <summary>
            /// Updates the KolliSize and recalculates and updates the PackageCost.
            /// Static method that ONLY works with on-disk data.
            /// </summary>
            public static void UpdateKolliSize(int KolliSize, int SupplierNo, double OrderingNumber)
            {
                // get a SupplierItem record to work with
                DataRow supplierItem = db.GetDataRow(string.Format(
                    " select * from SupplierItem " +
                    " where (SupplierNo = {0}) " +
                    " and (OrderingNumber = {1}) ",
                    SupplierNo, OrderingNumber));
                if (supplierItem == null) return; // data check

                // we need to recalculate the PackageCost,
                // and for that we need the PackageUnitCost.
                double PackageUnitCost = tools.object2double(supplierItem["PackageUnitCost"]);
                double PackageCost = CalculatePackageCost(PackageUnitCost, KolliSize);

                // perform the update
                db.ExecuteNonQuery(string.Format(
                    " update SupplierItem set " +
                    " KolliSize = {0}, " +
                    " PackageCost = '{1}' " +
                    " where (SupplierNo = {2}) " +
                    " and (OrderingNumber = {3}) ",
                    KolliSize,
                    PackageCost,
                    SupplierNo,
                    OrderingNumber));
            }
            #endregion

            #region DeleteSupplierItem
            /// <summary>
            /// Deletes the record if it can be found.
            /// If the primary supplier item is deleted,
            /// it is attempted to select a new primary supplier
            /// item for the item, that refers to the row that is deleted.
            /// </summary>
            public static void DeleteSupplierItem(int SupplierNo, double OrderingNumber)
            {
                // before deleting the supplieritem, retrieve it's ItemID
                DataRow row = GetSupplierItem(SupplierNo, OrderingNumber);
                if (row == null) return;
                int ItemID = tools.object2int(row["ItemID"]);

                // delete supplier item
                db.ExecuteNonQuery(string.Format(
                    " delete from SupplierItem " +
                    " where (SupplierNo = {0}) " +
                    " and (OrderingNumber = {1}) ",
                    SupplierNo, OrderingNumber));

                // if no primary supplieritem now exist for the item,
                // attempt to select a new primary supplieritem
                SetFirstAndBestToPrimaryIfPrimaryIsMissing(ItemID);
            }
            #endregion

            #region SearchItemsWithOrderingNumber
            /// <summary>
            /// Searches items that has the given ordering number in SupplierItem table.
            /// </summary>
            public static List<int> SearchItemsWithOrderingNumber(double OrderingNumber)
            {
                List<int> list = new List<int>();
                DataTable table = db.GetDataTable(string.Format(
                    " select distinct ItemID " +
                    " from SupplierItem " +
                    " where (OrderingNumber = {0}) ",
                    OrderingNumber));
                foreach (DataRow row in table.Rows)
                    list.Add(tools.object2int(row["ItemID"]));
                return list;
            }
            #endregion

            #region GetPrimarySupplierItem
            public static DataRow GetPrimarySupplierItem(int ItemID)
            {
                return db.GetDataRow(string.Format(@"
                    select * from SupplierItem
                    where (ItemID = {0})
                    and (IsPrimary = 1)
                    ", ItemID));
            }
            #endregion

            #region SetFirstAndBestToPrimaryIfPrimaryIsMissing
            public static void SetFirstAndBestToPrimaryIfPrimaryIsMissing(int ItemID)
            {
                if (GetPrimarySupplierItem(ItemID) == null)
                {
                    // set first and best supplieritem
                    // on the item to primary, if the item does not
                    // have any primary supplier item, if any
                    // supplieritems exists
                    db.ExecuteNonQuery(string.Format(@"
                    update SupplierItem
                    set IsPrimary = 1
                    where ID in
                    (
                        select top 1 ID
                        from SupplierItem
                        where ItemID = {0}
                    )
                    ", ItemID));

                    // if a supplieritem has been set
                    // copy PackageUnitCost to item's CostPriceLatest
                    DataRow PrimaryRow = GetPrimarySupplierItem(ItemID);
                    if (PrimaryRow != null)
                    {
                        double PackageUnitCost = tools.object2double(PrimaryRow["PackageUnitCost"]);
                        db.ExecuteNonQuery(string.Format(@"
                            update Item
                            set CostPriceLatest = {0}
                            where ItemID = {1}
                            ",
                             tools.decimalnumber4sql(PackageUnitCost),
                             ItemID));
                    }
                }
            }
            #endregion

            #region GetSupplierItems
            /// <summary>
            /// Returns all supplier items for the given item.
            /// An empty table is returned if no records found.
            /// </summary>
            public static DataTable GetSupplierItems(int ItemID)
            {
                return db.GetDataTable(string.Format(@"
                    select * from SupplierItem
                    where (ItemID = {0})
                    ", ItemID));
            }
            #endregion
        }

        #endregion // end of SupplierItemDataTable

        #region FSDDeletedSupplierItemDataTable class
        partial class FSDDeletedSupplierItemDataTable
        {
            #region CopySupplierItem_To_FSDDeletedSupplierItems

            /// <summary>
            /// Method copies the given supplieritem to the table
            /// SemiDeletedSupplierItem. This is used when deleting
            /// supplieritems when semideleting items or just deleting supplieritems.
            /// Only available to FSD version.
            /// </summary>
            public static bool CopySupplierItem_To_FSDDeletedSupplierItem(DataRow SupplierItemRow)
            {
                if (SupplierItemRow == null) return false;
                int SupplierNo = tools.object2int(SupplierItemRow["SupplierNo"]);
                double OrderingNumber = tools.object2double(SupplierItemRow["OrderingNumber"]);
                return CopySupplierItem_To_FSDDeletedSupplierItem(SupplierNo, OrderingNumber);
            }
            /// This overloaded version takes an ItemID and copies all supplieritem
            /// records with that ItemID to the FSDDeletedSupplierItem table.
            public static bool CopySupplierItem_To_FSDDeletedSupplierItem(int ItemID)
            {
                string WhereClause = string.Format(" (ItemID = {0})", ItemID);
                return CopySupplierItem_To_FSDDeletedSupplierItem(WhereClause);
            }
            /// <summary>
            /// This overloaded version takes a SupplierNo and an OrderingNumber
            /// and copies that record to the FSDDeletedSupplierItem table.
            /// </summary>
            public static bool CopySupplierItem_To_FSDDeletedSupplierItem(int SupplierNo, double OrderingNumber)
            {
                string WhereClause = string.Format(
                    " ((SupplierNo = {0}) and (OrderingNumber = {1})) ",
                    SupplierNo, OrderingNumber);
                return CopySupplierItem_To_FSDDeletedSupplierItem(WhereClause);
            }
            /// <summary>
            /// Private helper method for the methods of same name.
            /// </summary>
            private static bool CopySupplierItem_To_FSDDeletedSupplierItem(string WhereClause)
            {
                db.ExecuteNonQuery(string.Format(@"
                    insert into FSDDeletedSupplierItem
                        (ID,ItemID,SupplierNo,OrderingNumber,KolliSize,PackageCost,
                        PackageUnitCost,IsPrimary,SellingPackType,NoOfSellingUnits,SellingUnitCost)
                    select
                        ID,ItemID,SupplierNo,OrderingNumber,KolliSize,PackageCost,
                        PackageUnitCost,IsPrimary,SellingPackType,NoOfSellingUnits,SellingUnitCost
                    from SupplierItem
                    where {0}
                    ", WhereClause));

                return true;
            }
            #endregion

            #region RemoveSupplierItem_From_FSDDeletedSupplierItem
            /// <summary>
            /// Takes and ItemID and finds SupplierItem records with that ItemID.
            /// Those records are considered still valid, and if they exist in the
            /// FSDDeletedSupplierItem table, remove them from that delete-table.
            /// This is used when cancelling deletion of supplieritem records.
            /// </summary>
            public static void RemoveNonHistoricSupplierItem_From_FSDDeletedSupplierItem(int ItemID)
            {
                db.ExecuteNonQuery(string.Format(@"
                    delete from FSDDeletedSupplierItem
                    where (ItemID = {0})
                    and ((HistoricExportFVDHeaderID is null) or (HistoricExportFVDHeaderID = 0))
                    ", ItemID));
            }
            #endregion

            #region GetNumNonHistoricRecords
            public static int GetNumNonHistoricRecords()
            {
                return tools.object2int(db.ExecuteScalar(string.Format(@"
                    select count(*) from FSDDeletedSupplierItem
                    where ((HistoricExportFVDHeaderID is null) or (HistoricExportFVDHeaderID = 0))
                    ")));
            }
            #endregion

            #region GetNumHistoricRecords
            public static int GetNumHistoricRecords(int ExportFVDHeaderID)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(@"
                    select count(*) from FSDDeletedSupplierItem
                    where (HistoricExportFVDHeaderID = {0})
                    ", ExportFVDHeaderID)));
            }
            #endregion

            #region GetNonHistoricData
            public static DataTable GetNonHistoricData()
            {
                return db.GetDataTable(string.Format(@"
                    select * from FSDDeletedSupplierItem
                    where ((HistoricExportFVDHeaderID is null) or (HistoricExportFVDHeaderID = 0))
                    "));
            }
            #endregion

            #region GetData
            public static DataTable GetHistoricData(int HeaderID)
            {
                return db.GetDataTable(string.Format(@"
                    select * from FSDDeletedSupplierItem
                    where HistoricExportFVDHeaderID = {0}
                    ", HeaderID));
            }
            #endregion

            #region SetFVDExportHeaderIDOnNonHistoricRecords
            public static void SetFVDExportHeaderIDOnNonHistoricRecords(int HeaderID)
            {
                db.ExecuteNonQuery(string.Format(@"
                    update FSDDeletedSupplierItem set
                    HistoricExportFVDHeaderID = {0}
                    where ((HistoricExportFVDHeaderID is null) or (HistoricExportFVDHeaderID = 0))
                    ", HeaderID));
            }
            #endregion
        }
        #endregion // end of FSDDeletedSupplierItemDataTable class

        #region PARTIAL CLASS: ItemDataTable
        /// <summary>
        /// Custom code on ItemDataTable
        /// </summary>
        partial class ItemDataTable
        {
            #region METHOD: OnColumnChanged
            /// <summary>
            /// ItemDataTable.OnColumnChanged event.
            /// </summary>
            /// <param name="e"></param>
            protected override void OnColumnChanged(DataColumnChangeEventArgs e)
            {
                // if CostPriceLatest has been set to 0,
                // calculate it based on 
                if (e.Column.ColumnName == CostPriceLatestColumn.ColumnName)
                {
                    if (tools.object2double(e.Row["CostPriceLatest"]) == 0)
                    {
                        double budgetmargin = tools.object2double(e.Row["BudgetMargin"]);
                        double salesprice = tools.object2double(e.Row["POSSalesPrice"]);
                        double costprice = tools.CalcCostPrice(budgetmargin, salesprice);
                        if (costprice != 0)
                            e.Row["CostPriceLatest"] = costprice;
                    }
                }

                // if changed POSSalesPrice or CostPriceLatest columns,
                // re-calculate and write Margin (dækningsgrad) value
                if ((e.Column.ColumnName == POSSalesPriceColumn.ColumnName) ||
                    (e.Column.ColumnName == CostPriceLatestColumn.ColumnName))
                {
                    e.Row["Margin"] = CalcMargin();
                }

                if (e.Column.ColumnName == FSD_IDColumn.ColumnName)
                {
                    // if setting FSD_ID to 0, change that to DBNull
                    if ((e.ProposedValue != DBNull.Value) && (tools.object2int(e.ProposedValue) == 0))
                        e.Row["FSD_ID"] = DBNull.Value;

                    // prevent setting FSD_ID to a value that is already present on another item.
                    // if we dont have an ItemID on the record yet, then just check if there is the FSD_ID is anywhere already
                    int tmpItemID = tools.object2int(e.Row["ItemID"]);
                    int tmpFSD_ID = tools.object2int(e.ProposedValue);
                    if ((e.ProposedValue != DBNull.Value) && FSD_ID_AlreadyInUseOnOtherItem(tmpItemID, tmpFSD_ID) != "")
                    {
                        // write in the itemlog
                        Dictionary<int, int> tmpEntry = new Dictionary<int, int>();
                        tmpEntry.Add(tmpItemID, tmpFSD_ID);
                        UpdateFVD_WriteDRSItemLog_PreventedDuplicateFSD_ID(tmpEntry, "ItemDataSet.ItemDataTable.OnColumnChanged (FSD_ID column");
                        // null the value
                        e.Row["FSD_ID"] = DBNull.Value;
                    }
                }

                // intercept setting KampagneID to 0
                if (e.Column.ColumnName == KampagneIDColumn.ColumnName)
                {
                    if ((e.ProposedValue != DBNull.Value) && (tools.object2int(e.ProposedValue) == 0))
                        e.Row["KampagneID"] = DBNull.Value;
                }

                base.OnColumnChanged(e);
            }
            #endregion

#if FSD
            public delegate void DisktilbudValidationFailed();
            public event DisktilbudValidationFailed OnDisktilbudValidationFailed = null;

            public delegate void DisktilbudFromDateLaterThanToDate();
            public event DisktilbudFromDateLaterThanToDate OnDisktilbudFromDateLaterThanToDate = null;

            public delegate void DisktilbudToDateEarlierThanFromDate();
            public event DisktilbudToDateEarlierThanFromDate OnDisktilbudToDateEarlierThanFromDate = null;
#endif
            protected override void OnColumnChanging(DataColumnChangeEventArgs e)
            {
#if FSD
                // if FSD and if changing one of the disktilbud values
                if (e.Column == DisktilbudFraDatoColumn || e.Column == DisktilbudTilDatoColumn || e.Column == DisktilbudThresholdColumn)
                {
                    // verify that there is a campaign ID before allowing entering disktilbud values
                    if (tools.IsNullOrDBNull(e.Row[KampagneIDColumn]) && !tools.IsNullOrDBNull(e.ProposedValue))
                    {
                        e.ProposedValue = DBNull.Value;
                        if (OnDisktilbudValidationFailed != null)
                            OnDisktilbudValidationFailed();
                    }

                    // if changing the disktilbud from date,
                    // make sure it's not after the to date
                    if (e.Column == DisktilbudFraDatoColumn)
                    {
                        DateTime FraDato = tools.object2datetime(e.ProposedValue);
                        DateTime TilDato = tools.object2datetime(e.Row["DisktilbudTilDato"]);
                        if (TilDato != DateTime.MinValue)
                        {
                            if (FraDato > TilDato)
                            {
                                e.ProposedValue = DBNull.Value;
                                if (OnDisktilbudFromDateLaterThanToDate != null)
                                    OnDisktilbudFromDateLaterThanToDate();
                            }
                        }
                    }

                    // if changing the disktilbud to date,
                    // make sure it's not before the from date
                    if (e.Column == DisktilbudTilDatoColumn)
                    {
                        DateTime FraDato = tools.object2datetime(e.Row["DisktilbudFraDato"]);
                        DateTime TilDato = tools.object2datetime(e.ProposedValue);
                        if (FraDato != DateTime.MinValue)
                        {
                            if (TilDato < FraDato)
                            {
                                e.ProposedValue = DBNull.Value;
                                if (OnDisktilbudToDateEarlierThanFromDate != null)
                                    OnDisktilbudToDateEarlierThanFromDate();
                            }
                        }
                    }
                }
#endif

                base.OnColumnChanging(e);
            }

            #region METHOD: CalcMargin
            /// <summary>
            /// Calculates margin (dækningsgrad) for the Item.
            /// </summary>
            /// <returns>The margin.</returns>
            private double CalcMargin()
            {
                double margin = 0;

                // check for valid values
                if (this.Rows.Count <= 0) return margin;
                if (Rows[0]["POSSalesPrice"] == DBNull.Value) return margin;
                if (Rows[0]["CostPriceLatest"] == DBNull.Value) return margin;

                // get values for calculating margin
                ItemRow row = (ItemRow)this.Rows[0];
                double salesPrice = row.POSSalesPrice;
                double costPrice = row.CostPriceLatest;

                return tools.CalcMargin(salesPrice, costPrice);
            }
            #endregion

            #region METHOD: IsChainItem
            /// <summary>
            /// Checks if the current item (there is only one row at a time)
            /// is a chain item, that is, are there any sales packs that
            /// refer to this item in the sales pack's ChainItemID field
            /// </summary>
            /// <returns></returns>
            public bool IsChainItem()
            {
                if (this.Rows.Count <= 0) return false;
                int ItemID = int.Parse(this.Rows[0]["ItemID"].ToString()); // there is only one Item row
                string sql = string.Format("select ChainItemID from SalesPack where ChainItemID = {0}", ItemID);
                DataTable table = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, db.Connection);
                adapter.Fill(table);
                return (table.Rows.Count > 0);
            }
            #endregion

            #region IsInCampaign
            public bool IsInCampaign()
            {
                if (this.Rows.Count <= 0) return false;
                int ItemID = tools.object2int(this.Rows[0]["ItemID"].ToString()); // there is only one Item row
                return (tools.object2int(db.ExecuteScalar(string.Format(@"
                    select count(*) from Item
                    where (KampagneID <> 0)
                    and (ItemID = {0})
                    ", ItemID))) > 0);
            }
            #endregion

            #region METHOD: UpdateLastChangeDateTime
            /// <summary>
            /// Updates field LastChangeDateTime with DateTime.Now on the item.
            /// </summary>
            public void UpdateLastChangeDateTime()
            {
                if (this.Rows.Count <= 0) return;
                this.Rows[0]["LastChangeDateTime"] = DateTime.Now;
            }
            #endregion

            #region METHOD: LookupItemName
            /// <summary>
            /// Looks up the ItemName from the given ItemID.
            /// Do NOT use this to get the itemname of an in-memory
            /// record, as this method searched in the database file.
            /// </summary>
            /// <param name="ItemID">ItemID.</param>
            /// <returns>ItemName if found or "" if not found.</returns>
            public static string LookupItemName(int ItemID)
            {
                string sql = string.Format("select ItemName from Item where ItemID = {0}", ItemID);
                OleDbCommand cmd = new OleDbCommand(sql, db.Connection);
                object result = cmd.ExecuteScalar();
                if ((result != null) && (result != DBNull.Value))
                    return result.ToString();
                else
                    return "";
            }
            #endregion

            #region METHOD: GetItemRecord
            /// <summary>
            /// Returns the item row with the given ItemID or null if not found.
            /// </summary>
            public static DataRow GetItemRecord(int ItemID)
            {
                DataRow rowItem = null;
                OleDbDataAdapter adapter = new OleDbDataAdapter("", db.Connection);
                adapter.SelectCommand.CommandText = string.Format(
                    " select * from Item where ItemID = {0} ",
                    ItemID);
                adapter.SelectCommand.Transaction = db.CurrentTransaction;
                DataTable table = new DataTable();
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                    rowItem = table.Rows[0];
                return rowItem;
            }
            #endregion

            #region GetItemIDFromBarcode
            /// <summary>
            /// If barcode is found in Barcode table, the ItemID
            /// is returned. Otherwise 0 is returned.
            /// Static method that ONLY works with on-disk data.
            /// </summary>
            public static int GetItemIDFromBarcode(double Barcode)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(
                    " select ItemID from Barcode " +
                    " where Barcode = {0} ", Barcode)));
            }
            #endregion

            #region GetItemIDFromSupplierItem
            /// <summary>
            /// If combination of SupplierNo and OrderingNumber
            /// is found in table SupplierItem, ItemID is returned.
            /// Otherwise 0 is returned.
            /// Static method that ONLY works with on-disk data.
            /// </summary>
            public static int GetItemIDFromSupplierItem(int SupplierNo, double OrderingNumber)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(
                    " select ItemID from SupplierItem " +
                    " where (SupplierNo = {0}) " +
                    " and (OrderingNumber = {1}) ",
                    SupplierNo, OrderingNumber)));
            }
            #endregion

            #region GetItemIDFromBarcodeOrSupplierItem
            public static int GetItemIDFromBarcodeOrSupplierItem(double Barcode, int SupplierNo, double OrderingNumber)
            {
                int ItemID = GetItemIDFromBarcode(Barcode);
                if (ItemID <= 0)
                    ItemID = GetItemIDFromSupplierItem(SupplierNo, OrderingNumber);
                return ItemID;
            }
            #endregion

            #region GetItemName
            public static string GetItemName(int ItemID)
            {
                return tools.object2string(db.ExecuteScalar(string.Format(
                    " select ItemName from Item " +
                    " where ItemID = {0} ", ItemID)));
            }
            #endregion

            #region NumSalesPacksOnItem
            /// <summary>
            /// Returns the number of salespacks on the given item.
            /// Static method that ONLY works with on-disk data.
            /// </summary>
            public static int NumSalesPacksOnItem(int ItemID)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(
                    " select count(*) from SalesPack " +
                    " where ItemID = {0} ", ItemID)));
            }
            #endregion

            #region NumSupplierItemsOnItem
            /// <summary>
            /// Returns the number of supplieritems on the given item.
            /// Static method that ONLY works with on-disk data.
            /// </summary>
            public static int NumSupplierItemsOnItem(int ItemID)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(
                    " select count(*) from SupplierItem " +
                    " where ItemID = {0} ", ItemID)));
            }
            #endregion

            #region UpdateCostPriceLatest
            /// <summary>
            /// Update CostPriceLatest and Margin on Item.
            /// May only be called if cost price is also set on a supplier item.
            /// Static method that ONLY works with on-disk data.
            /// </summary>
            public static void UpdateCostPriceLatest(int ItemID, double CostPrice)
            {
                // set CostPriceLatest and set and calculate Margin on Item
                double SalesPrice = tools.object2double(db.ExecuteScalar(string.Format(
                    " select POSSalesPrice from Item " +
                    " where ItemID = {0} ", ItemID)));
                db.ExecuteScalar(string.Format(
                    " update Item set " +
                    " CostPriceLatest = {0}, " +
                    " Margin = {1} " +
                    " where ItemID = {2} ",
                    tools.decimalnumber4sql(CostPrice),
                    tools.decimalnumber4sql(tools.CalcMargin(SalesPrice, CostPrice)),
                    ItemID));

                UpdateItemLastChangeDateTimeNow(ItemID);
            }
            #endregion

            #region UpdateItemLastChangeDateTimeNow
            /// <summary>
            /// Update Item's LastChangeDateTime field to Now.
            /// Static method that ONLY works with on-disk data.
            /// </summary>
            public static void UpdateItemLastChangeDateTimeNow(int ItemID)
            {
                // we need to set datetime item was updated
                db.ExecuteNonQuery(string.Format(
                    " update Item set " +
                    " LastChangeDateTime = GETDATE()" +
                    " where ItemID = {0}", ItemID));
            }
            #endregion

            #region GetInStock
            /// <summary>
            /// Returns the value of InStock for the item.
            /// Static method that ONLY works with on-disk data.
            /// </summary>
            public static int GetInStock(int ItemID)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(
                    " select InStock from Item " +
                    " where ItemID = {0} ", ItemID)));
            }
            #endregion

            #region SetUdmeldtPrDatoToNow
            /// <summary>
            /// Sets the field UdmeldtPrDato on the item to Now.
            /// </summary>
            public static void SetUdmeldtPrDatoToNow(int ItemID)
            {
                db.ExecuteNonQuery(string.Format(
                    " update Item set " +
                    " UdmeldtPrDato = Now " +
                    " where ItemID = {0} ",
                    ItemID));
            }
            #endregion

            #region NullUdmeldtPrDatoToNow
            /// <summary>
            /// Sets the field UdmeldtPrDato on the item to NULL.
            /// </summary>
            public static void NullUdmeldtPrDatoToNow(int ItemID)
            {
                db.ExecuteNonQuery(string.Format(
                    " update Item set " +
                    " UdmeldtPrDato = NULL " +
                    " where ItemID = {0} ",
                    ItemID));
            }
            #endregion

            #region GetCostPriceLatest
            /// <summary>
            /// Returns the CostPriceLatest for the item.
            /// If item is not found, 0 is returned.
            /// Static method that ONLY works with on-disk data.
            /// </summary>
            public static double GetCostPriceLatest(int ItemID)
            {
                return tools.object2double(db.ExecuteScalar(string.Format(
                    " select CostPriceLatest from Item " +
                    " where ItemID = {0} ", ItemID)));
            }
            #endregion

            #region GetPOSSalesPrice
            /// <summary>
            /// Returns POSSalesPrice for the item.
            /// If item not found, 0 is returned.
            /// Static method that ONLY works with on-disk data.
            /// </summary>
            public static double GetPOSSalesPrice(int ItemID)
            {
                return tools.object2double(db.ExecuteScalar(string.Format(
                    " select POSSalesPrice from Item " +
                    " where ItemID = {0} ", ItemID)));
            }
            #endregion
            #region GetSalesPackSalesPrice
            /// <summary>
            /// Returns POSSalesPrice for the item.
            /// If item not found, 0 is returned.
            /// Static method that ONLY works with on-disk data.
            /// </summary>
            public static double GetSalesPackSalesPrice(int ItemID)
            {
                return tools.object2double(db.ExecuteScalar(string.Format(
                    "SELECT [SalesPrice] from [SalesPack] Where ItemID = {0} And PackType = 1 ", ItemID)));
            }
            #endregion

            #region IsSemiDeleted
            public static bool IsSemiDeleted(int ItemID)
            {
                return tools.object2bool(db.ExecuteScalar(string.Format(
                    " select SemiDeleted from Item " +
                    " where ItemID = {0} ", ItemID)));
            }
            #endregion

            #region ReCalculateInStockAllItems
            public static void ReCalculateInStockAllItems()
            {
                ProgressForm progress = new ProgressForm("Genberegner beholding på alle varer");
                DataTable items = db.GetDataTable("select ItemID from Item");
                progress.ProgressMax = items.Rows.Count;
                progress.Show();
                foreach (DataRow row in items.Rows)
                {
                    int ItemID = tools.object2int(row["ItemID"]);
                    ReCalculateInStock(ItemID);
                    progress.StatusText = "Beregner beholding for vare: " + GetItemName(ItemID);
                }
                progress.Close();
            }
            #endregion

            #region ReCalculateInStock
            /// <summary>
            /// Re-calculates the InStock value of the given item.
            /// The table ItemTransaction is used for this.
            /// Method has been renamed after update version 2.01.014,
            /// as we needed it for another purpose and we did not want to
            /// touch the method used in the v14 updater.
            /// </summary>
            public static void ReCalculateInStock(int ItemID)
            {
                /// NOTE: if the logic in this method changed,
                /// it is important to also change the logic in the
                /// method ItemTransactionDataTabe.CalculateStock, as it
                /// contains the same logic.

                // find the last record with type count (opt).
                // if not found, record will be null,
                // and calculation will start from beginning
                int TransactionNumber = 0;
                //DateTime PostingDate = DateTime.MinValue;//pn20190808
                DateTime PostingDate = new DateTime(2001, 12, 25);

                DataRow LatestOptaellingRow = db.GetDataRow(string.Format(@"
                    select top 1 TransactionNumber, PostingDate
                    from ItemTransaction
                    where (ItemID = {0})
                    and (TransactionType = {1})
                    order by PostingDate desc, TransactionNumber desc
                    ", ItemID, (byte)db.TransactionTypes.Count));
                if (LatestOptaellingRow != null)
                {
                    TransactionNumber = tools.object2int(LatestOptaellingRow["TransactionNumber"]);
                    PostingDate = tools.object2datetime(LatestOptaellingRow["PostingDate"]);
                }

                // calculate everything after optælling including the optælling
                // or from the beginning within the given item.
                int InStockCalc = tools.object2int(db.ExecuteScalar(string.Format(@"
                    select sum(NoOfSellingUnits)
                    from ItemTransaction
                    where (ItemID = {0})
                    and ((PostingDate > '{2}') or ((PostingDate = '{2}') and (TransactionNumber >= {1})))
                    ",
                    ItemID,
                    TransactionNumber,
                    PostingDate)));

                // update this item's InStock
                db.ExecuteNonQuery(string.Format(
                    " update Item set " +
                    " InStock = {0} " +
                    " where ItemID = {1} ",
                    InStockCalc, ItemID));
            }

            #endregion

            #region ReCalculateInStock_v14upd
            /// <summary>
            /// Re-calculates the InStock value of the given item.
            /// The table ItemTransaction is used for this.
            /// Method has been renamed after update version 2.01.014,
            /// as we needed it for another purpose and we did not want to
            /// touch the method used in the v14 updater.
            /// </summary>
            public static void ReCalculateInStock_v14upd(int ItemID)
            {
                // find the last record with type count (opt).
                // if not found TransactionNumber will be 0,
                // and so calculation will start from beginning.
                int TransactionNumber = tools.object2int(db.ExecuteScalar(string.Format(
                    " select max(TransactionNumber) " +
                    " from ItemTransaction " +
                    " where (ItemID = {0}) " +
                    " and (TransactionType = {1}) ",
                    ItemID, (byte)db.TransactionTypes.Count)));

                // calculate sum of all non-countadjustment (optreg)
                // records from and including the last count (opt) record
                // or from the beginning within the given item.
                int InStockCalc = tools.object2int(db.ExecuteScalar(string.Format(
                    " select sum(NoOfSellingUnits) " +
                    " from ItemTransaction " +
                    " where (ItemID = {0}) " +
                    " and (TransactionType <> {1}) " +
                    " and (TransactionNumber >= {2}) ",
                    ItemID,
                    (byte)db.TransactionTypes.CountAdjustment,
                    TransactionNumber)));

                // update this item's InStock
                db.ExecuteNonQuery(string.Format(
                    " update Item set " +
                    " InStock = {0} " +
                    " where ItemID = {1} ",
                    InStockCalc, ItemID));
            }

            #endregion

            #region UpdateLastInventDate
            public static void UpdateLastInventDate(int ItemID, DateTime LastInventDate)
            {
                db.ExecuteNonQuery(string.Format(
                            " update Item set " +
                            " LastInventDate = '{1}' " +
                            " where ItemID = {0} ",
                            ItemID, LastInventDate.Date));
            }
            #endregion

            #region NullLastInventDate
            public static void NullLastInventDate(int ItemID)
            {
                db.ExecuteNonQuery(string.Format(
                            " update Item set " +
                            " LastInventDate = NULL " +
                            " where ItemID = {0} ",
                            ItemID));
            }
            #endregion

            #region GetUniqueItemName
            public static string GetUniqueItemName(string ItemName)
            {
                ItemDataTable x = new ItemDataTable();
                int maxlength = x.ItemNameColumn.MaxLength;

                string OriginalItemName = ItemName;
                int NameCounter = 1;
                while (!ItemDataSet.IsUniqueItemName(ItemName, 0))
                {
                    ItemName = OriginalItemName + " " + (++NameCounter).ToString();
                    if (ItemName.Length > maxlength)
                    {
                        int counterlength = NameCounter.ToString().Length + 1;
                        ItemName = ItemName.Remove(ItemName.Length - counterlength - counterlength, counterlength);
                    }
                }
                return ItemName;
            }
            #endregion

            #region GetNewestItemID
            public static int GetNewestItemID()
            {
                return tools.object2int(db.ExecuteScalar("select max(ItemID) from Item"));
            }
            #endregion

            #region UpdateKampagneIDIfChanged
            /// <summary>
            /// Updates the KampagneID if it is different
            /// from what the item already has. True is returned
            /// if an update was perfomed, false otherwise.
            /// </summary>
            public static bool UpdateKampagneIDIfChanged(int ItemID, int KampagneID)
            {
                DataRow itemrow = GetItemRecord(ItemID);
                if (itemrow != null)
                {
                    if (tools.object2int(itemrow["KampagneID"]) != KampagneID)
                    {
                        db.ExecuteNonQuery(string.Format(@"
                            update Item
                            set KampagneID = {1}
                            where ItemID = {0}
                            ", ItemID, KampagneID));
#if FSD
                        SalesPackDataTable.SetUpdateStations(ItemID, true);
#endif
                        return true; // report updated
                    }
                }
                // nothing updated
                return false;
            }
            #endregion

            #region ClearAllKampagneID
            /// <summary>
            /// Will set KampagneID = NULL on all items.
            /// </summary>
            public static void ClearAllKampagneID()
            {
                db.ExecuteNonQuery("update Item set KampagneID = null");
            }
            #endregion

            #region UpdateFSD_ID
            /// <summary>
            /// Updates FSD_ID if the item's FSD_ID is different from
            /// what is passed in and if KampagneID passed in is different from 0.
            /// If FSD_ID is changed on the item, RSMNeedsNewID is set to true on
            /// the item, KampagneID on the item is assigned the passed in value
            /// and UpdateRSM is set to true on all child salespacks related to that item.
            /// A boolean value is returned telling if the update was done.
            /// </summary>
            public static bool UpdateFSD_ID(int ItemID, int FSD_ID, int KampagneID)
            {
                if (ItemID <= 0) return false;
                if (KampagneID == 0) return false;

                // check if there is another item with this FSD_ID
                if (FSD_ID_AlreadyInUseOnOtherItem(ItemID, FSD_ID) != "")
                {
                    // this FSD_ID is present on another item, which is not allowed,
                    // so we write in the item log about it and then return false
                    Dictionary<int, int> tmpPreventedDuplicates = new Dictionary<int, int>();
                    tmpPreventedDuplicates.Add(ItemID, FSD_ID);
                    UpdateFVD_WriteDRSItemLog_PreventedDuplicateFSD_ID(tmpPreventedDuplicates, "ItemDataSet.ItemDataTable.UpdateFSD_ID()");
                    return false;
                }

                DataRow itemrow = GetItemRecord(ItemID);
                if (itemrow != null)
                {
                    if (FSD_ID != tools.object2int(itemrow["FSD_ID"]))
                    {
                        // set FSD_ID and RSMNeedsNewID on item
                        db.ExecuteNonQuery(string.Format(@"
                            update Item set
                            FSD_ID = {1},
                            KampagneID = {2},
                            RSMNeedsNewID = 1
                            where ItemID = {0}
                            ", ItemID, FSD_ID, KampagneID));

                        // set UpdateRSM on child sales records
                        SalesPackDataTable.SetUpdateRSM(ItemID);

                        // updated
                        return true;
                    }
                }

                // not updated
                return false;
            }
            #endregion

            #region GetIDForExport
            /// <summary>
            /// If the item passed in has a FSD_ID,
            /// the FSD_ID is returned, otherwise the passed in ItemID
            /// is returned. If the passed in ItemID is less than or equal to 0, 0 returned.
            /// This is used when exporting to RSM/BHHT
            /// as RSM/BHHT needs the central FSD_ID if present.
            /// </summary>
            public static int GetExportID(int ItemID)
            {
                if (ItemID <= 0) return 0;
                int FSD_ID = GetFSD_ID(ItemID);
                return (FSD_ID > 0) ? FSD_ID : ItemID;
            }
            #endregion

            #region GetItemID
            /// <summary>
            /// Looks in the Item table to find an item where
            /// ItemID or FSD_ID matches ImportID. If found, ItemID
            /// is returned. If not found, 0 is returned.
            /// </summary>
            public static int GetItemIDFromImportID(int ImportID)
            {
                if (ImportID <= 0) return 0;
                return tools.object2int(db.ExecuteScalar(string.Format(@"
                    select ItemID from Item
                    where (ItemID = {0}) or (FSD_ID = {0})
                    ", ImportID)));
            }
            #endregion

            #region GetItemAgeRestriction 
            /// <summary>
            /// pn20200604
            /// Looks in the Item table to find an item where
            /// ItemID or FSD_ID matches ImportID. If found, ItemID
            /// is returned. If not found, 0 is returned.
            /// </summary>
            public static int GetItemAgeRestriction(int ItemID)
            {
                if (ItemID <= 0) return 0;
                return tools.object2int(db.ExecuteScalar(string.Format(@"
                    select AgeRestriction from Item
                    where (ItemID = {0}) 
                    ", ItemID)));
            }
            #endregion

            #region GetFSD_ID
            /// <summary>
            /// Returns the FSD_ID for the given item.
            /// If no FSD_ID exists, 0 is returned.
            /// </summary>
            public static int GetFSD_ID(int ItemID)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(@"
                    select FSD_ID from Item
                    where ItemID = {0}
                    ", ItemID)));
            }
            #endregion

            #region UnsetRSMNeedsNewID
            public static void UnsetRSMNeedsNewID(int ItemID)
            {
                db.ExecuteNonQuery(string.Format(@"
                    update Item
                    set RSMNeedsNewID = 0
                    where ItemID = {0}
                    ", ItemID));
            }
            #endregion

            #region GetSubCategory
            public static string GetSubCategory(int ItemID)
            {
                return tools.object2string(db.ExecuteScalar(string.Format(@"
                    select SubCategory from Item
                    where ItemID = {0}
                    ", ItemID)));
            }
            #endregion

            #region UpdateSubCategoryIfChanged
            /// <summary>
            /// Updates SubCategory on the item if the item
            /// does not already have that SubCategory and if the
            /// subcategory exists in the SubCategory table.
            /// If the update is performed, UpdateRSM is set
            /// on related child salespacks.
            /// </summary>
            /// <param name="ItemID"></param>
            /// <param name="SubCategory"></param>
            /// <returns></returns>
            public static bool UpdateSubCategoryIfChanged(int ItemID, string SubCategory)
            {
                // get item row and check that item exits
                DataRow row = GetItemRecord(ItemID);
                if (row == null)
                    return false; // not found

                // check if item already has that subcat
                if (GetSubCategory(ItemID) == SubCategory)
                    return false; // already have that subcat

                // check if the subcat exists in the SubCategory table
                if (ItemDataSet.SubCategoryDataTable.GetSubCategoryRow(SubCategory) == null)
                    return false; // subcat not found in SubCategory table

                // perform the update
                db.ExecuteNonQuery(string.Format(@"
                    update Item set
                    SubCategory = {1}
                    where ItemID = {0}
                    ", ItemID, SubCategory));

                // set UpdateRSM = true on related child salespacks
                ItemDataSet.SalesPackDataTable.SetUpdateRSM(ItemID);

                // update performed
                return true;
            }
            #endregion

            #region AssignNextFSD_ID
            /// <summary>
            /// Assign the next FSD_ID to the given item.
            /// Is only used in FSD version.
            /// </summary>
            /// <param name="ItemID"></param>
            public static void AssignNextFSD_ID(int ItemID)
            {
                int NextFSD_ID = GetNextFSD_ID(true);
                db.ExecuteNonQuery(string.Format(@"
                    update Item set
                    FSD_ID = {1}
                    where ItemID = {0}
                    ", ItemID, NextFSD_ID));
            }
            #endregion

            #region GetNextFSD_ID
            /// <summary>
            /// Generates the next FSD_ID and if WriteBack
            /// is set to true, the value is written back to db,
            /// which is what you would usually do.
            /// </summary>
            private static int GetNextFSD_ID(bool WriteBack)
            {
                int id = db.GetConfigStringAsInt("FSD_ID");
                if (id <= 0)
                    id = 1000000;
                ++id;
                if (WriteBack)
                    db.SetConfigString("FSD_ID", id);
                return id;
            }
            #endregion

            #region GetNumItemsWithDuplicateFSD_IDs
            public static bool HasItemsWithDuplicateFSD_IDs()
            {
                string sql = @"
select count(FSD_ID)
from Item
group by FSD_ID
having (count(FSD_ID) > 1)
";
                return tools.object2int(db.ExecuteScalar(sql)) > 0;
            }
            #endregion

            #region GetItemsWithDuplicateFSD_IDs
            public static DataTable GetItemsWithDuplicateFSD_IDs()
            {
                string sql = @"
select
  i1.ItemID,
  i1.ItemName,
  i1.FSD_ID,
  b1.Barcode
from Item i1
inner join Barcode b1
on i1.ItemID = b1.ItemID
where i1.FSD_ID in
(
  select i2.FSD_ID
  from Item i2
  group by i2.FSD_ID
  having (count(i2.FSD_ID) > 1)
)
order by i1.FSD_ID, i1.ItemID
";
                return db.GetDataTable(sql);
            }
            #endregion

            #region GetItemIDsWithGivenFSD_ID
            public static List<int> GetItemIDsWithGivenFSD_ID(int FSD_ID)
            {
                DataTable table = db.GetDataTable(string.Format(@"
                    select ItemID from Item
                    where FSD_ID = {0}
                    ", FSD_ID));
                List<int> list = new List<int>();
                foreach (DataRow row in table.Rows)
                    list.Add(tools.object2int(row["ItemID"]));
                return list;
            }
            #endregion

            #region GetItemIDsWithGivenKampagneID
            public static List<int> GetItemIDsWithGivenKampagneID(int KampagneID)
            {
                DataTable table = db.GetDataTable(string.Format(@"
                    select ItemID from Item
                    where KampagneID = {0}
                    ", KampagneID));
                List<int> list = new List<int>();
                foreach (DataRow row in table.Rows)
                    list.Add(tools.object2int(row["ItemID"]));
                return list;
            }
            #endregion

            #region WriteDRSItemLog_DuplicateFSD_IDs
            /// <summary>
            /// Returns the filename written including path.
            /// </summary>
            /// <returns></returns>
            public static string WriteDRSItemLog_DuplicateFSD_IDs(string CalledFrom, bool CopyToDepartDir)
            {
                DataTable table = GetItemsWithDuplicateFSD_IDs();
                if (table.Rows.Count <= 0)
                    return "";

                string filename = string.Format("DRSItemLog{0}_{1}.txt",
                    DateTime.Now.ToString("yyyyMMdd"),
                    AdminDataSet.SiteInformationDataTable.GetSiteCode());
                string filepath = Application.StartupPath + "\\log-history\\" + filename;
                StreamWriter writer = new StreamWriter(filepath, true, tools.Encoding());

                writer.WriteLine("Log entry timestamp: " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + ".");
                writer.WriteLine("RBOS user: " + UserLogon.Username + ".");
                writer.WriteLine("RBOS exe version: " + Version.ExeVersion + ".");
                writer.WriteLine("Kaldt fra: " + CalledFrom + ".");
                writer.WriteLine("Varer i databasen, der indeholder samme FSD_ID:");
                writer.WriteLine("-------------------------------------------------------------------------------");

                string GroupHeader = "";
                foreach (DataRow row in table.Rows)
                {
                    string FSD_ID = tools.object2int(row["FSD_ID"]).ToString();
                    if (GroupHeader != FSD_ID)
                    {
                        GroupHeader = FSD_ID;
                        writer.WriteLine("FSD_ID: " + FSD_ID);
                    }

                    writer.WriteLine(string.Format("  {0,-10}  {1,-50}  {2,13}",
                        tools.object2string(row["ItemID"]),
                        tools.object2string(row["ItemName"]),
                        tools.object2string(row["Barcode"])
                        ));
                }

                writer.WriteLine("-------------------------------------------------------------------------------");
                writer.WriteLine("");
                writer.Close();

                if (CopyToDepartDir)
                {
                    string departpath = db.GetConfigString("DRS_FTP_client_depart_dir") + "\\" + filename;
                    File.Copy(filepath, departpath, true);
                }
                return filepath;
            }
            #endregion

            #region UpdateFVD_WriteDRSItemLog_PreventedDuplicateFSD_ID
            /// <summary>
            /// Writes prevented FSD_ID duplicates to the DRSItemLog file.
            /// <param name="Items">The list of items gathered that had FSD_IDs that were prevented from being set in the database.</param>
            /// </summary>
            public static void UpdateFVD_WriteDRSItemLog_PreventedDuplicateFSD_ID(Dictionary<int, int> Items, string FVDFilename)
            {
                string filename = string.Format("DRSItemLog{0}_{1}.txt",
                    DateTime.Now.ToString("yyyyMMdd"),
                    AdminDataSet.SiteInformationDataTable.GetSiteCode());
                string filepath = Application.StartupPath + "\\log-history\\" + filename;
                StreamWriter writer = new StreamWriter(filepath, true, tools.Encoding());

                writer.WriteLine("Log entry timestamp: " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + ".");
                writer.WriteLine("RBOS user: " + UserLogon.Username + ".");
                writer.WriteLine("RBOS exe version: " + Version.ExeVersion + ".");
                writer.WriteLine("Import af FVD-fil: " + FVDFilename + ".");
                writer.WriteLine("Varer der er blevet forhindret i at opdatere FSD_ID i databasen under FVD import,");
                writer.WriteLine("da det FSD_ID allerede eksisterede på en anden vare og en dublet ville opstå:");
                writer.WriteLine("--------------------------------------------------------------------------------------------------");

                foreach (KeyValuePair<int, int> item in Items)
                {
                    writer.WriteLine("FSD_ID: " + item.Value.ToString());

                    int fvdItemID = item.Key;
                    string fvdItemName = ItemDataSet.ItemDataTable.GetItemName(fvdItemID);
                    double fvdBarcode = ItemDataSet.BarcodeDataTable.GetPrimaryBarcodeByItemID(fvdItemID);
                    writer.WriteLine(string.Format("  Vare fra FVD-fil:  {0,-10}  {1,-50}  {2,13}",
                        fvdItemID, fvdItemName, fvdBarcode));

                    List<int> dbItemIDs = ItemDataSet.ItemDataTable.GetItemIDsWithGivenFSD_ID(item.Value);
                    foreach (int dbItemID in dbItemIDs)
                    {
                        string dbItemName = ItemDataSet.ItemDataTable.GetItemName(dbItemID);
                        double dbBarcode = ItemDataSet.BarcodeDataTable.GetPrimaryBarcodeByItemID(dbItemID);
                        writer.WriteLine(string.Format("  Vare fra database: {0,-10}  {1,-50}  {2,13}",
                            dbItemID, dbItemName, dbBarcode));
                    }

                    /// NOTE that we assume that more than one item in the database might have this FSD_ID.
                    /// Previoius importers did not have this protection and if this installation has not yet
                    /// had the drs admin run the cleanup tools tailored to fix it, this log will give usefull information.
                }

                writer.WriteLine("--------------------------------------------------------------------------------------------------");
                writer.WriteLine("");
                writer.Close();

                string departpath = db.GetConfigString("DRS_FTP_client_depart_dir") + "\\" + filename;
                File.Copy(filepath, departpath, true);
                log.Write("FVD importer: One ore more items had FVD_IDs that were prevented from being written to database to avoid duplicates. See seperate log file " + filepath + " which has been sent to DRS.");
            }
            #endregion

            #region FSD_ID_AlreadyInUse
            /// <summary>
            /// Checks whether the FSD_ID is in use already
            /// on one ore more other items that the ItemID provided.
            /// The item with the ItemID provided does not count.
            /// The name of the first conflicting item is returned.
            /// </summary>
            public static string FSD_ID_AlreadyInUseOnOtherItem(int ItemID, int FSD_ID)
            {
                string sql = string.Format(@"
                    select ItemName from Item
                    where (ItemID <> {0}) and (FSD_ID = {1})
                    ", ItemID, FSD_ID);
                return tools.object2string(db.ExecuteScalar(sql));
            }
            #endregion

            #region RepairItemsWithInvalidChainItem
            /// <summary>
            /// Removes any chain item reference that points
            /// to an item that does not exist.
            /// </summary>
            public static void RepairItemsWithInvalidChainItem()
            {
                string sql = @"
update SalesPack
set ChainItemID = null, ChainPackType = null, ChainBarcode = null
where ChainBarcode is not null
and ChainBarcode <> 0
and ChainBarcode not in
(
    select Barcode.Barcode
    from Barcode
)
";
                db.ExecuteNonQuery(sql);
            }
            #endregion

            #region GetDisktilbudFraTilDatoer
            /// <summary>
            /// Returns disktilbud fra/til dates from the item.
            /// If item not found or if no disktilbud is set on the item
            /// false is returned and the dates are filled with DateTime.MinValue
            /// </summary>
            public static bool GetDisktilbudFraTilDatoer(int ItemID, out DateTime FraDato, out DateTime TilDato, out int Threshold)
            {
                using (OleDbConnection conn = new OleDbConnection(db.ConnectionString))
                {
                    string sql = @"
                        select DisktilbudFraDato, DisktilbudTilDato, DisktilbudThreshold from Item
                        where ItemID = ?
                        and DisktilbudFraDato is not null
                        and DisktilbudTilDato is not null
                    ";
                    using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection))
                    {
                        cmd.Parameters.Add("ItemID", OleDbType.Integer).Value = ItemID;
                        DataRow row = db.GetDataRow(cmd);
                        if (row != null)
                        {
                            FraDato = tools.object2datetime(row["DisktilbudFraDato"]).Date;
                            TilDato = tools.object2datetime(row["DisktilbudTilDato"]).Date;
                            Threshold = tools.object2int(row["DisktilbudThreshold"]);
                            return true;
                        }
                        else
                        {
                            FraDato = DateTime.MinValue;
                            TilDato = DateTime.MinValue;
                            Threshold = 0;
                            return false;
                        }
                    }
                }
            }
            #endregion

            #region UpdateDisktilbud
            /// <summary>
            /// Used when DO versions run the FVD importer and
            /// disktilbud to/from dates is included in the file from BFI.
            /// </summary>
            public static void UpdateDisktilbud(int ItemID, DateTime FraDato, DateTime TilDato, int Threshold)
            {
                string sql = "update Item set DisktilbudFraDato = ?, DisktilbudTildato = ?, DisktilbudThreshold = ? where ItemID = ?";
                using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection))
                {
                    cmd.Parameters.Add("DisktilbudFraDato", OleDbType.Date).Value = FraDato.Date == DateTime.MinValue ? (object)DBNull.Value : FraDato.Date;
                    cmd.Parameters.Add("DisktilbudTildato", OleDbType.Date).Value = TilDato.Date == DateTime.MinValue ? (object)DBNull.Value : TilDato.Date;
                    cmd.Parameters.Add("DisktilbudThreshold", OleDbType.Integer).Value = Threshold <= 0 ? (object)DBNull.Value : Threshold;

                    cmd.Parameters.Add("ItemID", OleDbType.Integer).Value = ItemID;
                    cmd.Transaction = db.CurrentTransaction;
                    cmd.ExecuteNonQuery();
                }
            }
            #endregion

            #region GetDisktilbud
            /// <summary>
            /// Returns the items that have disktilbud
            /// where the BookDate falls within the disktilbud date interval.
            /// If ErrorsinDisktilbud is set to true, information has been written
            /// in the log and callers should inform user to contact support.
            /// </summary>
            public static DataTable GetDisktilbud(DateTime BookDate, out bool ErrorsInDisktilbud)
            {
                using (OleDbConnection conn = new OleDbConnection(db.ConnectionString))
                {
                    /// SQL statement forklaring:
                    /// Indre statement giver maxdato for hvert item, hvor bookdate ligger inden for fradato/tildato.
                    /// Ydre statement giver alle de historik-records, der har de datoer. 

                    /// Det betyder at hvis der er flere disktilbud der passer til BookDate for et item,
                    /// så hentes der for det item kun det seneste disktilbud ud.

                    string sql = @"
                        select
                          h1.ItemID,
                          h1.FSD_ID,
                          h1.KampagneID,
                          h1.Threshold,
                          0 as AccumulatedOnBon,
                          0 as HasErrors
                        from DisktilbudHistorik h1
                        where h1.ItemID & '#' & h1.DatoTid in
                        (
                            select h2.ItemID & '#' & max(h2.DatoTid)
                            from DisktilbudHistorik h2
                            where h2.FraDato <= ?
                            and h2.TilDato >= ?
                            and h2.FraDato is not null
                            and h2.TilDato is not null
                            and h2.Threshold is not null and h2.Threshold > 0
                            and h2.KampagneID is not null and h2.KampagneID > 0
                            group by h2.ItemID
                        )
                        order by h1.KampagneID
                    ";
                    using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection))
                    {
                        cmd.Parameters.Add("FraDato", OleDbType.Date).Value = BookDate.Date;
                        cmd.Parameters.Add("TilDato", OleDbType.Date).Value = BookDate.Date;
                        DataTable table = db.GetDataTable(cmd);
                        ErrorsInDisktilbud = false;

                        // check for errors, mark them and write them to the log
                        foreach (DataRow row in table.Rows)
                        {
                            if (tools.object2int(row["FSD_ID"]) <= 0 ||
                                tools.object2int(row["KampagneID"]) <= 0 ||
                                tools.object2int(row["Threshold"]) <= 0)
                            {
                                row["HasErrors"] = 1;

                                // write more detailed in the log
                                string errors = "";

                                if (tools.object2int(row["FSD_ID"]) <= 0)
                                {
                                    if (errors != "")
                                        errors += ", ";
                                    errors += "FSD ID";
                                }
                                if (tools.object2int(row["KampagneID"]) <= 0)
                                {
                                    if (errors != "")
                                        errors += ", ";
                                    errors += "Kampaign ID";
                                }
                                if (tools.object2int(row["Threshold"]) <= 0)
                                {
                                    if (errors != "")
                                        errors += ", ";
                                    errors += "Threshold (criteria)";
                                }
                                int ItemID = tools.object2int(row["ItemID"]);
                                string ItemName = ItemDataTable.GetItemName(ItemID);
                                log.Write(string.Format("GetDisktilbud: Item '{0}' ({1}) is missing {2}",
                                    ItemName,
                                    ItemID,
                                    errors));

                                // report errors
                                ErrorsInDisktilbud = true;
                            }
                        } // end of loop checking for errors

                        // return the data
                        return table;

                    } // end of using sql command object
                } // end of using sql connection object
            }
            #endregion
        }
        #endregion

        #region PARTIAL CLASS: PackSizeConfigDataTable
        /// <summary>
        /// Custom code on PackSizeConfigDataTable (table LookupPackSize)
        /// </summary>
        partial class PackSizeConfigDataTable
        {
            // contains the last error for methods that supports this by returned a failure value.
            private string lastError = "";
            public string LastError
            {
                get { return lastError; }
            }

            /// <summary>
            /// Returns the next possible user assigned PackType.
            /// </summary>
            /// <returns>A number between 50 and 255 or 0 if overflow.</returns>
            public int GetNextPossblePackTypeID()
            {
                int highest = 49;
                foreach (DataRow row in this.Rows)
                {
                    if ((row.RowState != DataRowState.Deleted) &&
                        (row.RowState != DataRowState.Detached))
                    {
                        int b = tools.object2int(row["PackType"]);
                        if (b > highest) highest = b;
                    }
                }
                if (highest < 255)
                    return ++highest;
                else
                    return 0;
            }

            /// <summary>
            /// Validates the given PackTypeName. If true is returned all is ok.
            /// If false is returned, LastError contains an error message to display to user.
            /// </summary>
            /// <param name="PackTypeName">A string of max 8 characters.</param>
            /// <returns>True if all ok, false if not.</returns>
            public bool ValidatePackTypeName(string PackTypeName)
            {
                lastError = "";

                // check that given PackTypeName is not empty
                if (PackTypeName == "")
                {
                    lastError = db.GetLangString("ItemDataSet.PackSizeConfig.NameNotEmpty");
                    return false;
                }

                // check if given PackTypeName is too long
                if (PackTypeName.Length > this.PackTypeNameColumn.MaxLength)
                {
                    lastError = string.Format(
                        db.GetLangString("ItemDataSet.PackSizeConfig.NameTooLong"),
                        this.PackTypeNameColumn.MaxLength);
                    return false;
                }

                // check that no invalid characters has been entered
                if (PackTypeName.Contains("\"") ||
                    PackTypeName.Contains("'"))
                {
                    lastError = db.GetLangString("ItemDataSetPackSizeConfig.NameCannotContain");
                    return false;
                }

                // check if given PackTypeName already exists (case insensitive by default)
                string sql = string.Format(" PackTypeName = '{0}' ", PackTypeName);
                DataRow[] rows = this.Select(sql);
                if (rows.Length > 0)
                {
                    lastError = db.GetLangString("ItemDataSet.PackSizeConfig.NameAlreadyExist");
                    return false;
                }

                // all ok
                return true;
            }
        }
        #endregion

        #region PARTIAL CLASS: BarcodeDataTable

        /// <summary>
        /// Custom code on the BarcodeDataTable.
        /// 
        /// Note that the BarcodeDataTable is filled with barcode data from
        /// all sales packes in an item, so if you need to uniquely identify
        /// which packtype to operate on in a method, provide a byte PackType
        /// parameter and use it in filters etc.
        /// </summary>
        partial class BarcodeDataTable
        {
            #region VerifyBarcodeMsg property
            /// <summary>
            /// Error message for method VerifyBarcode
            /// </summary>
            private string verifyBarcodeMsg = "";
            public string VerifyBarcodeMsg
            {
                get { return verifyBarcodeMsg; }
            }
            #endregion

            #region VerifyBarcode
            /// <summary>
            /// Before changing the barcode value in the GUI, it must
            /// be checked to see if it can be used. Various conditions
            /// determine this and this method collects all of them centrally
            /// so different places in the GUI has a common validation of barcode.
            /// </summary>
            /// <param name="oldBarcode">The old barcode before change.</param>
            /// <param name="newBarcode">The new barcode after change.</param>
            /// <returns>T
            /// True if all ok. In this case it is safe to use the barcode.
            /// False if something went wrong. ErrBarcodeValidation will
            /// any error message generated by this method.
            /// If false is returned and ErrBarcodeValidation is empty,
            /// just cancel the edit operation (e.Cancel = true) and don't show message
            /// as for instance if a non-double value was entered and user just 
            /// have to provide a correct double.
            /// </returns>
            public bool VerifyBarcode(
                object old_Barcode,
                ref object new_Barcode, // will contain the modified barcode
                object ItemID,
                object PackType,
                object BCType)
            {
                verifyBarcodeMsg = "";
                double oldBarcode = 0;
                double newBarcode = 0;
                int itemID = 0;
                short packType = 0;
                short bcType = 0;
                Barcode bc = new Barcode();

                // verify that ItemID is a valid int
                if (!(ItemID is int))
                    return false;
                else
                    itemID = int.Parse(ItemID.ToString());

                // verify that PackType is a valid byte
                if (!(PackType is short))
                    return false;
                else
                    packType = short.Parse(PackType.ToString());

                // verify that BCType is a valid short
                if (!(BCType is short))
                    return false;
                else
                    bcType = short.Parse(BCType.ToString());

                // check if barcode has correct format
                if (!bc.IsValidBarcode(bcType, new_Barcode.ToString()))
                {
                    verifyBarcodeMsg = bc.ErrorMsg;
                    return false;
                }

                // barcode has correct format, so convert it from object to double
                newBarcode = tools.object2double(new_Barcode);

                // handle that old barcode can be DBNull
                if (old_Barcode != DBNull.Value)
                    oldBarcode = double.Parse(old_Barcode.ToString());

                // calculate any missing checksum on the new barcode
                newBarcode = bc.TryCalculateChecksum(newBarcode, bcType);

                // if barcode has changed
                if (oldBarcode != newBarcode)
                {
                    // check if it exists on another item
                    string errItem = BarcodeExistOnOtherItem(itemID, newBarcode);
                    if (errItem != "")
                    {
                        verifyBarcodeMsg =
                            string.Format(db.GetLangString("ItemDataSet.BarcodeAlreadyExistsOnAnotherItem"), errItem);
                        return false;
                    }

                    // check if it will be an unique key
                    if (!KeyDoesNotAlreadyExist(itemID, packType, newBarcode))
                    {
                        verifyBarcodeMsg = db.GetLangString("ItemDataSet.BarcodeAlreadyExistOnPackSize");
                        return false;
                    }
                }

                // no errors occured
                new_Barcode = newBarcode;
                return true;
            }
            #endregion

            #region OnColumnChanging
            /// <summary>
            /// Perform data validation when columns on table Barcode changes.
            /// </summary>
            protected override void OnColumnChanging(DataColumnChangeEventArgs e)
            {
                // Barcode column changing
                if (e.Column.ColumnName == BarcodeColumn.ColumnName)
                {
                }

                // IsPrimary column changing
                else if (e.Column.ColumnName == IsPrimaryColumn.ColumnName)
                {
                    // If checkmark set, remove any other checkmarks.
                    // Remember to call bindingSource.ResetCurrentItem
                    // in GUI to reflect changes in table.
                    bool checkOn = (bool)e.ProposedValue;
                    if (checkOn)
                    {
                        // NOTE: as this table is filled with data from all sales packs
                        // for an item, we may only remove checkmarks from records, where
                        // PackType is the same as this row's PackType

                        foreach (DataRow row in this.Rows)
                        {
                            if ((row.RowState != DataRowState.Deleted) && (row.RowState != DataRowState.Detached) &&
                                (byte.Parse(row["PackType"].ToString()) == byte.Parse(e.Row["PackType"].ToString())))
                            {
                                if (bool.TrueString == row["IsPrimary"].ToString())
                                    row["IsPrimary"] = false;
                            }
                        }
                    }
                }

                //base.OnColumnChanging(e);
            }
            #endregion

            #region KeyDoesNotAlreadyExist
            // internal method for checking if barcode key is unique
            public bool KeyDoesNotAlreadyExist(int ItemID, int PackType, double Barcode)
            {
                // we just need to search in our internal barcode table, as it holds
                // the current barcode records for this item and this packtype
                string sql = string.Format(
                    "(ItemID = {0}) and (PackType = {1}) and (Barcode = {2})",
                    ItemID, PackType, Barcode);
                DataRow[] rows = this.Select(sql);
                return (rows.Length <= 0);
            }
            #endregion

            #region BarcodeExistOnOtherItem
            // internal method for checking if barcode already exists on another item
            public string BarcodeExistOnOtherItem(int ItemID, double Barcode)
            {
                // this check needs to search in the full table of barcodes
                string sql = string.Format(
                    " select i.ItemName from Item i " +
                    " inner join Barcode b " +
                    " on (i.ItemID = b.ItemID) " +
                    " where (b.ItemID <> {0}) and (b.Barcode = {1})",
                    ItemID, Barcode);
                DataSet ds = new DataSet();
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, db.Connection);
                adapter.Fill(ds);
                if ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
                    return ds.Tables[0].Rows[0]["ItemName"].ToString();
                else
                    return "";
            }
            #endregion

            #region BarcodeAlreadyExist
            /// <summary>
            /// Checks if the given barcode exists.
            /// Static method that ONLY works with on-disk data.
            /// </summary>
            public static bool BarcodeAlreadyExist(double Barcode)
            {
                return (tools.object2int(db.ExecuteScalar(string.Format(
                    " select count(*) from Barcode " +
                    " where Barcode = {0} ", Barcode))) > 0);
            }
            #endregion

            #region HasPrimaryBarcode
            /// <summary>
            /// Checks if a row has the IsPrimary set to true.
            /// </summary>
            /// <returns>True if a row has IsPrimary set to true, false if not.</returns>
            public bool HasPrimaryBarcode(int PackType)
            {
                // just search in the current set of data,
                // that is, for this item and this packsize
                string filter = string.Format("(IsPrimary = 1) and (PackType = {0})", PackType);
                return (this.Select(filter).Length > 0);
            }
            #endregion

            #region SetPrimaryBarcode
            /// <summary>
            /// Updates existing primary barcode or creates new primary barcode if none found.
            /// Used when entering barcode data on salespack grid. barcode parameter 
            /// must include checksum.
            /// </summary>
            /// <returns>Any column errors that might occur as when working with Barcode table.</returns>
            public string SetPrimaryBarcode(int itemID, short packtype, short bctype, double barcode)
            {
                BarcodeRow row = null;

                // first calculate any missing checksum
                Barcode bc = new Barcode();
                barcode = bc.TryCalculateChecksum(barcode, bctype);

                // try to find an existing primary barcode
                DataRow[] rows = this.Select(string.Format(
                    "(IsPrimary = 1) and (PackType = {0})",
                    packtype));
                if (rows.Length > 0)
                {
                    row = (BarcodeRow)rows[0];
                    try
                    {
                        // found the primary barcode, update it
                        if (row.BCType != bctype)
                            row.BCType = bctype; // MUST be set before Barcode due to validation
                        if (row.Barcode != barcode)
                            row.Barcode = barcode;
                        // write barcode back as it might have been modified by a validation
                        return row.GetColumnError(columnBarcode.ColumnName);
                    }
                    catch (Exception ex)
                    {
                        // either a validation is present, so return it,
                        // otherwise just return the exception message
                        string colError = row.GetColumnError(columnBarcode.ColumnName);
                        if ((colError != null) && (colError != ""))
                            return row.GetColumnError(columnBarcode.ColumnName);
                        else
                            return ex.Message;
                    }
                }
                else
                {
                    // no primary barcode found, create it
                    row = this.NewBarcodeRow();
                    row.ItemID = itemID;
                    row.PackType = packtype;
                    row.BCType = bctype; // MUST be set before Barcode due to validation
                    row.Barcode = barcode;
                    row.IsPrimary = true;
                    this.AddBarcodeRow(row);
                    // write barcode back as it is modified by a validation
                    barcode = row.Barcode;
                    // return any column error
                    return row.GetColumnError("Barcode");
                }
            }
            #endregion

            #region GetPrimaryBCType
            /// <summary>
            /// Returns the BCType of the primary barcode
            /// for the specified packtype
            /// or -1 if no primary or some error
            /// </summary>
            public short GetPrimaryBCType(short PackType)
            {
                DataRow[] rows = this.Select(string.Format("(IsPrimary = 1) and (PackType = {0})", PackType));
                if (rows.Length > 0)
                {
                    try { return short.Parse(rows[0]["BCType"].ToString()); }
                    catch (Exception) { return -1; }
                }
                else
                    return -1;
            }
            #endregion

            #region GetPrimaryBarcode
            /// <summary>
            /// Returns the Barcode of the primary barcode
            /// for the specified packtype
            /// or -1 if no primary or some error
            /// </summary>
            public double GetPrimaryBarcode(short PackType)
            {
                DataRow[] rows = this.Select(string.Format("(IsPrimary = 1) and (PackType = {0})", PackType));
                if (rows.Length > 0)
                {
                    try { return double.Parse(rows[0]["Barcode"].ToString()); }
                    catch (Exception) { return -1; }
                }
                else
                    return -1;
            }
            #endregion

            #region CheckForLastBarcodeAndSetIsPrimary
            /// <summary>
            /// Checks if the specified packtype on the item has
            /// only one barcode, and ensures this barcode has
            /// IsPrimary = true.
            /// </summary>
            /// <param name="PackType"></param>
            public void CheckForLastBarcodeAndSetIsPrimary(int PackType)
            {
                DataRow[] rows = this.Select(string.Format("PackType = {0}", PackType));
                if (rows.Length == 1)
                {
                    BarcodeRow row = (BarcodeRow)rows[0];
                    if (row["IsPrimary"] != DBNull.Value)
                    {
                        if (!row.IsPrimary)
                            row.IsPrimary = true;
                    }
                    else
                        row.IsPrimary = true;
                }
            }
            #endregion

            #region GetNumBarcodes
            /// <summary>
            /// Returns the number of barcodes on the
            /// salespack on the item.
            /// </summary>
            /// <param name="PackType"></param>
            /// <returns></returns>
            public int GetNumBarcodes(short PackType)
            {
                DataRow[] rows = this.Select(string.Format("PackType = {0}", PackType));
                return rows.Length;
            }
            #endregion

            #region AddBarcode (2 overloads)

            /// <summary>
            /// See documentation for the other overloaded method.
            /// </summary>
            public static bool AddBarcode(int ItemID, short PackType, double Barcode)
            {
                // adds a barcode where the bctype will be detected
                return AddBarcode(ItemID, PackType, Barcode, null);
            }

            /// <summary>
            /// Creates a barcode assuming the Barcode is valid.
            /// Returns true if barcode was created.
            /// Returns false if barcode was already found
            /// in the database or if barcode is 0 and thus were not created.
            /// UpdateRSM is set to true on the related SalesPack record.
            /// IsPrimary is set to true if no other barcodes exist on the salespack.
            /// A null BCType will cause the method to autodetect the BCType from the Barcode.
            /// Static method that ONLY works with on-disk data.
            /// </summary>
            public static bool AddBarcode(int ItemID, short PackType, double Barcode, Nullable<short> BCType)
            {
                // check that barcode is not 0
                if (Barcode == 0)
                    return false;

                // check if the barcode already exists
                if (BarcodeAlreadyExist(Barcode))
                    return false;

                // detect barcode type
                short bctype;
                if (!BCType.HasValue)
                {
                    // no BCType given, autodetect barcode type
                    bctype = 1; // custom barcode
                    if (Barcode.ToString().Length == 13)
                        bctype = 2;
                    else if (Barcode.ToString().Length == 8)
                        bctype = 3;
                }
                else
                {
                    // BCType given, so use it
                    bctype = BCType.Value;
                }

                // detect if barcode should be primary on the salespack
                bool IsPrimary = (!SalesPackDataTable.HasPrimaryBarcode(ItemID, PackType));

                // create barcode row
                db.ExecuteNonQuery(string.Format(
                    " insert into Barcode " +
                    " (ItemID,PackType,BCType,Barcode,IsPrimary) " +
                    " values ({0},{1},{2},{3},{4}) ",
                    ItemID, PackType, bctype, Barcode, tools.bool4sql(IsPrimary)));

                // we need to update rsm and stations too
                db.ExecuteNonQuery(string.Format(
                    " update SalesPack set " +
                    " UpdateRSM = 1, " +
                    " UpdateStations = 1 " +
                    " where (ItemID = {0}) " +
                    " and (PackType = {1}) ",
                    ItemID, PackType));

                ItemDataTable.UpdateItemLastChangeDateTimeNow(ItemID);

                // successfully created
                return true;
            }

            #endregion

            #region GenerateUniqueBarcode
            /// <summary>
            /// Increments barcode numbers until a unique barcode is found,
            /// starting from StartingPointBarcode. Does not consider
            /// ItemID or PackType, just generates a barcode that does not
            /// already exist in the barcode table.
            /// NOTE: when you use the returned value, make sure the
            /// barcode type is set to custom, as if it for instance was
            /// a valid EAN-13 before, the new barcode will most likely not
            /// be a valid EAN-13.
            /// Static method that ONLY works with on-disk data.
            /// </summary>
            public static double GenerateUniqueBarcode(double StartingPointBarcode)
            {
                double NewBarcode = StartingPointBarcode;
                while (ItemDataSet.BarcodeDataTable.BarcodeAlreadyExist(NewBarcode))
                    ++NewBarcode;
                return NewBarcode;
            }
            #endregion

            #region GetBarcodeRecord
            /// <summary>
            /// Returns the barcode with the given Barcode.
            /// It is assumed that all barcodes are unique
            /// regardless of ItemID and PackType. If no record
            /// was found, null is returned.
            /// Static method that ONLY works with on-disk data.
            /// </summary>
            /// <param name="Barcode"></param>
            /// <returns></returns>
            public static DataRow GetBarcodeRecord(double Barcode)
            {
                return db.GetDataRow(string.Format(
                    " select * from Barcode " +
                    " where Barcode = {0} ",
                    Barcode));
            }
            #endregion

            #region GetBarcodeRecord
            /// <summary>
            /// Returns the barcode with the given Barcode.
            /// It is assumed that all barcodes are unique
            /// regardless of ItemID and PackType. If no record
            /// was found, null is returned.
            /// Static method that ONLY works with on-disk data.
            /// </summary>
            /// <param name="Barcode"></param>
            /// <returns></returns>
            public static DataTable GetBarcodeRecordsFromItemID(double ItemID)
            {
                return db.GetDataTable(string.Format(
                    " select * from Barcode " +
                    " where ItemID = {0} And SemiDeleted <> 1",
                    ItemID)); //PN20210319
            }
            #endregion

            #region SemiDeleteBarcode
            /// <summary>
            /// Sets the SemiDeleted field to true on the given barcode.
            /// </summary>
            public static void SemiDeleteBarcode(int ItemID, int PackType, double Barcode)
            {
                db.ExecuteNonQuery(string.Format(
                    " update Barcode set " +
                    " SemiDeleted = 1 " +
                    " where (ItemID = {0}) " +
                    " and (PackType = {1}) " +
                    " and (Barcode = {2}) ",
                    ItemID, PackType, Barcode));
            }
            #endregion

            #region GetPrimaryBarcodeByItemID
            public static double GetPrimaryBarcodeByItemID(int ItemID)
            {
                return tools.object2double(db.ExecuteScalar(string.Format(@"
                    select top 1 Barcode from Barcode
                    where (ItemID = {0})
                    and (IsPrimary = 1)"
                    , ItemID)));
            }
            #endregion
        }

        #endregion

        #region PARTIAL CLASS: SalesPackDataTable

        /// <summary>
        /// Custom code on SalesPackDataTable. 
        /// </summary>
        partial class SalesPackDataTable
        {
            /// <summary>
            /// Perform data validation when columns on table SalesPackDataTable changes.
            /// </summary>
            protected override void OnColumnChanging(DataColumnChangeEventArgs e)
            {
                if (e.Column.ColumnName == PackTypeColumn.ColumnName)
                {
                    // when PackType column changes

                    // if this is the first row, set is as primary
                    if (this.Rows.Count == 0)
                        e.Row["IsPrimary"] = true;
                }
                else if (e.Column.ColumnName == IsPrimaryColumn.ColumnName)
                {
                    // when IsPrimary column changes

                    // If checkmark set, remove any other checkmarks for 
                    // sales packs on the item.
                    // Remember to call bindingSource.ResetCurrentItem
                    // in GUI to reflect changes in table.
                    bool checkOn = (bool)e.ProposedValue;
                    if (checkOn)
                    {
                        foreach (DataRow row in this.Rows)
                        {
                            if ((row.RowState != DataRowState.Deleted) &&
                                (row.RowState != DataRowState.Detached))
                            {
                                if (bool.TrueString == row["IsPrimary"].ToString())
                                    row["IsPrimary"] = false;
                            }
                        }
                    }
                }

                base.OnColumnChanging(e);
            }

            /// <summary>
            /// Perform data validation when columns on table SalesPackDataTable has finished changing.
            /// </summary>
            protected override void OnColumnChanged(DataColumnChangeEventArgs e)
            {
                // when a column changes in SalesPack, set UpdateRSM = true
                if ((e.Column.ColumnName != UpdateRSMColumn.ColumnName) &&          // skip UpdateRSM column
                    (e.Column.ColumnName != UpdateStationsColumn.ColumnName) &&           // skip UpdateStations column
                    (e.Column.ColumnName != NumBarcodesCalcColumn.ColumnName) &&    // skip calculated column peter20190605
                    (e.Column.ColumnName != ItemIDColumn.ColumnName) &&             // skip foreign key column
                    (e.Column.ColumnName != SemiDeletedColumn.ColumnName))          // skip SemiDeleted column
                {
                    e.Row["UpdateRSM"] = 1;
                    e.Row["UpdateStations"] = 1;
                }

                // when changing shelf label related values,
                // set shelf label update flag
                if ((e.Column.ColumnName == ReceiptTextColumn.ColumnName) ||
                    (e.Column.ColumnName == SalesPriceColumn.ColumnName) ||
                    (e.Column.ColumnName == SalesPackTypeColumn.ColumnName))
                {
                    e.Row["UpdateShelfLabel"] = 1;
                }

                if (e.Column.ColumnName == SalesPriceColumn.ColumnName)
                {
                    // when SalesPrice column has changed

                    // set ManualPrice = true if proposed SalesPrice is 0
                    if (float.Parse(e.ProposedValue.ToString()) == 0)
                    {
                        SalesPackRow row = (SalesPackRow)e.Row;
                        if ((e.Row["ManualPrice"] == DBNull.Value) || (!row.ManualPrice))
                            e.Row["ManualPrice"] = true;  //pn20200207
                    }
                }
                else if (e.Column.ColumnName == ManualPriceColumn.ColumnName)
                {
                    // when ManualPrice column has changed

                    // if proposed ManualPrice is false, check if SalesPrice
                    // is 0, and if so, set the ManualPrice to true
                    if (bool.Parse(e.ProposedValue.ToString()) == false) //pn20200603
                    {
                        SalesPackRow row = (SalesPackRow)e.Row;
                        if ((row["SalesPrice"] != DBNull.Value) && (row.SalesPrice == 0))
                            e.Row["ManualPrice"] = true;
                    }
                    else
                    {
                        // if proposed ManualPrice is true,
                        // and SalesPrice is null, set SalesPrice = 0
                        if (e.Row["SalesPrice"] == DBNull.Value)
                            e.Row["SalesPrice"] = 0;
                    }
                }
                else if (e.Column.ColumnName == PackTypeColumn.ColumnName)
                {
                    // when PackType changed

                    // below should only be done when a new salespack is added,
                    // so each field is checked for null first

                    /// as unit description is set to 0 by default, this means that
                    /// unit price may not be printed on shelf labels, so set flag
                    if (e.Row["UnitPriceNotShown"] == DBNull.Value)
                        e.Row["UnitPriceNotShown"] = 1;

                    // the GUI field for EnhedsIndhold has a default value of 1
                    // but unless user actually touches that field, nothing is written
                    // to the database, so set a default value of the same 1 in the db
                    if (e.Row["EnhedsIndhold"] == DBNull.Value)
                        e.Row["EnhedsIndhold"] = 1;
                }

                base.OnColumnChanged(e);
            }

            // SalesPackDataTable OnTableNewRow event
            protected override void OnTableNewRow(DataTableNewRowEventArgs e)
            {
                if (e.Row.RowState == DataRowState.Added)
                {
                    e.Row["UpdateRSM"] = 1;
                    e.Row["UpdateStations"] = 1;
                    base.OnTableNewRow(e);
                }
            }

            /// <summary>
            /// Update SalesPack table primary barcode.
            /// Used when copying data from barcode form to salespack grid.
            /// </summary>
            public void SetPrimaryBarcode(int itemID, short packtype, short bctype, double barcode)
            {
                // check that we have valid barcode data
                if ((bctype >= 0) && (barcode >= 0))
                {
                    // update existing salespack row
                    string filter = string.Format(
                        " (ItemID = {0}) and (PackType = {1}) ",
                        itemID, packtype);
                    DataRow[] rows = this.Select(filter);
                    if (rows.Length > 0)
                    {
                        // if bctype has changed, set it
                        if ((rows[0]["BCType"] == DBNull.Value) ||
                            (byte.Parse(rows[0]["BCType"].ToString()) != bctype))
                            rows[0]["BCType"] = bctype;
                        // if barcode has changed, set it
                        if ((rows[0]["Barcode"] == DBNull.Value) ||
                            (double.Parse(rows[0]["Barcode"].ToString()) != barcode))
                            rows[0]["Barcode"] = barcode;
                    }
                }
            }

            /*
            /// <summary>
            /// Checks if the specified salespack has only one row
            /// for the item, and if so, sets it's IsPrimary = true
            /// </summary>
            public void CheckForOnlySalesPackAndSetIsPrimary()
            {
                if(Rows.Count == 1)
                {
                    SalesPackRow row = (SalesPackRow)Rows[0];
                    if (!row.IsPrimary)
                        row.IsPrimary = true;
                }
            }
             * */

            /// <summary>
            /// Checks if a sales pack in the item has the IsPrimary set to true.
            /// </summary>
            /// <returns>True if a row has IsPrimary set to true, false if not.</returns>
            public bool HasPrimaryBarcode()
            {
                return (this.Select("IsPrimary = 1").Length > 0);
            }

            #region HasPrimaryBarcode
            /// <summary>
            /// Checks if a SalesPack record has a primary barcode.
            /// Static method that ONLY works with on-disk data.
            /// </summary>
            public static bool HasPrimaryBarcode(int ItemID, int PackType)
            {
                return (tools.object2int(db.ExecuteScalar(string.Format(
                    " select count(*) " +
                    " from Barcode " +
                    " where (ItemID = {0}) " +
                    " and (PackType = {1}) " +
                    " and IsPrimary = 1 ",
                    ItemID, PackType))) > 0);
            }
            #endregion

            /// <summary>
            /// Calculates and set the number of barcodes 
            /// for each sales pack row in the table in the
            /// calculated field NumBarcodesCalc
            /// </summary>
            /// <param name="barcodeTable"></param>
            public void SetNumBarcodesCalcAllRows(BarcodeDataTable barcodeTable)
            {
                foreach (SalesPackRow row in this.Rows)
                {
                    if ((row.RowState != DataRowState.Deleted) &&
                        (row.RowState != DataRowState.Detached))
                        row["NumBarcodesCalc"] = barcodeTable.GetNumBarcodes(row.PackType);
                }
            }

            /// <summary>
            /// Tells if another salespack row on the item has the given PackType.
            /// This is basically a check for if there will be a primary key violation
            /// if that PackType would be used on a new row.
            /// </summary>
            public bool PackTypeAlreadyUsed(int PackType)
            {
                DataRow[] rows = Select(string.Format("PackType = {0}", PackType));
                return (rows.Length > 0);
            }

            /// <summary>
            /// Reverse looks up the PackType (byte) value
            /// for the given PackTypeName (string) in the
            /// table LookupPackSize
            /// </summary>
            /// <returns>The PackType if found or 0 if not found.</returns>
            public short ReverseLookupPackType(string PackTypeName)
            {
                string sql = string.Format(
                    "select PackType from LookupPackSize where PackTypeName = '{0}'",
                    PackTypeName);
                OleDbCommand cmd = new OleDbCommand(sql, db.Connection);
                object result = cmd.ExecuteScalar();
                if (result is short) return short.Parse(result.ToString());
                else return 0;
            }

            /// <summary>
            /// Checks if the primary salespack key would be unique if used
            /// on salespack row related to the item.
            /// </summary>
            public bool IsUniqueKey(int ItemID, short PackType)
            {
                // check in-memory table
                string sql = string.Format("PackType = {0}", PackType);
                DataRow[] rows = this.Select(sql);
                if (rows.Length > 0)
                    return false;

                // check on-disk table
                sql = string.Format(
                    " select PackType from SalesPack where (ItemID = {0}) and (PackType = {1}) ",
                    ItemID, PackType);
                OleDbCommand cmd = new OleDbCommand(sql, db.Connection);
                object o = cmd.ExecuteScalar();
                if ((o != null) && (o != DBNull.Value))
                    return false;

                return true;
            }

            #region GetPrimarySalesPackSalesPrice
            /// <summary>
            /// Returns the sales price for the primary sales pack
            /// </summary>
            public double GetPrimarySalesPackSalesPrice()
            {
                DataRow[] rows = this.Select("IsPrimary = 1");
                if ((rows.Length == 1) && (rows[0]["SalesPrice"] != DBNull.Value))
                    return double.Parse(rows[0]["SalesPrice"].ToString());
                else
                    return 0;
            }
            #endregion

            #region SetUpdateRSM (overloaded)

            /// <summary>
            /// Sets UpdateRSM and UpdateStations = true for all salespacks in the item.
            /// </summary>
            public void SetUpdateRSM()
            {
                foreach (DataRow row in Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        row["UpdateRSM"] = 1;
                        row["UpdateStations"] = 1;
                    }
                }
            }

            /// <summary>
            /// Sets UpdateRSM and UpdateStations = true for all salespacks in the given item.
            /// </summary>
            /// <param name="ItemID"></param>
            public static void SetUpdateRSM(int ItemID)
            {
                db.ExecuteNonQuery(string.Format(@"
                    update SalesPack
                    set UpdateRSM = 1, UpdateStations = 1
                    where ItemID = {0}
                    ", ItemID));
            }

            #endregion

            #region UnsetUpdateRSM
            /// <summary>
            /// Sets UpdateRSM = false for the given salespack.
            /// This is static so it can be used without having
            /// a filled SalesPackDataTable.
            /// </summary>
            public static void UnsetUpdateRSM(int ItemID, short PackType)
            {
                string sql = string.Format(
                    "update SalesPack set UpdateRSM = 0 where (ItemID = {0}) and (PackType = {1})",
                    ItemID, PackType);
                OleDbCommand cmd = new OleDbCommand(sql, db.Connection);
                cmd.ExecuteNonQuery();
            }
            #endregion

            #region SetUpdateStations
            /// <summary>
            /// Sets UpdateStations = true for all salespacks in the given item.
            /// </summary>
            /// <param name="ItemID"></param>
            public static void SetUpdateStations(int ItemID, bool NewValue)
            {
                db.ExecuteNonQuery(string.Format(@"
                    update SalesPack
                    set UpdateStations = {1}
                    where ItemID = {0}
                    ", ItemID, NewValue));
            }
            #endregion

            #region HasAnyUpdateRSM
            // checks if any salespacks has UpdateRSM = true
            public bool HasAnyUpdateRSM()
            {
                return (Select("UpdateRSM = 1").Length > 0);
            }
            #endregion

            #region HasAnyUpdateStations
            // checks if any salespacks has UpdateRSM = true
            public bool HasAnyUpdateStations()
            {
                return (Select("UpdateStations = 1").Length > 0);
            }
            #endregion

            #region HasAnyUpdateShelfLabel
            // checks if any salespacks has UpdateShelfLabel = true
            public bool HasAnyUpdateShelfLabel()
            {
                return (Select("UpdateShelfLabel = 1").Length > 0);
            }
            #endregion

            #region UpdateSalesPriceLatest
            /// <summary>
            /// Update SalesPrice on salespack and
            /// update POSSalesPrice and Margin on Item.
            /// Static method that ONLY works with on-disk data.
            /// </summary>
            public static void UpdateSalesPrice(int ItemID, short PackType, double SalesPrice)
            {
                // update salesprice on salespack
                // and mark for update on rsm and stations and new shelf markers
                db.ExecuteNonQuery(string.Format(
                    " update SalesPack set " +
                    " SalesPrice = {0}, " +
                    " UpdateRSM = 1, " +
                    " UpdateStations = 1, " +
                    " UpdateShelfLabel = 1 " +
                    " where (ItemID = {1}) " +
                    " and (PackType = {2}) ",
                    tools.decimalnumber4sql(SalesPrice),
                    ItemID,
                    PackType));

                // check if this salespack is the primary on the item
                bool IsPrimary = tools.object2bool(db.ExecuteScalar(string.Format(
                    " select IsPrimary from SalesPack " +
                    " where (ItemID = {0}) " +
                    " and (PackType = {1}) ",
                    ItemID, PackType)));

                if (IsPrimary)
                {
                    // set POSSalesPrice and set and calculate Margin on Item
                    double CostPriceLatest = tools.object2double(db.ExecuteScalar(string.Format(
                        " select CostPriceLatest from Item " +
                        " where ItemID = {0} ", ItemID)));
                    db.ExecuteScalar(string.Format(
                        " update Item set " +
                        " POSSalesPrice = {0}, " +
                        " Margin = {1}, " +
                        " LastChangeDateTime = GETDATE() " +
                        " where ItemID = {2} ",
                        tools.decimalnumber4sql(SalesPrice),
                        tools.decimalnumber4sql(tools.CalcMargin(SalesPrice, CostPriceLatest)),
                        ItemID));

                    ItemDataTable.UpdateItemLastChangeDateTimeNow(ItemID);
                }
            }
            #endregion

            #region GetPrimaryPackType
            /// <summary>
            /// Returns the PackType for the primary salespack.
            /// If not found, 0 is returned.
            /// </summary>
            public static short GetPrimaryPackType(int ItemID)
            {
                return tools.object2byte(db.ExecuteScalar(string.Format(
                    " select PackType " +
                    " from SalesPack" +
                    " where (ItemID = {0}) " +
                    " and (IsPrimary = 1) ",
                    ItemID)));
            }
            #endregion

            #region DoesARowNotHaveChainItem
            public static bool DoesARowNotHaveChainItem(SalesPackDataTable table)
            {
                foreach (DataRow row in table.Rows)
                {
                    if (tools.IsNullOrDBNull(row["ChainItemID"]) ||
                        tools.IsNullOrDBNull(row["ChainPackType"]) ||
                        tools.IsNullOrDBNull(row["ChainBarcode"]))
                    {
                        // this row does not have a chain item
                        return true;
                    }
                }

                // all rows has chain items
                return false;
            }
            #endregion

            #region RecordExist
            public static bool RecordExist(int ItemID, int PackType)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(@"
                    select count(*) from SalesPack where ItemID = {0} and PackType = {1}
                    ", ItemID, PackType))) > 0;
            }
            #endregion

            #region Delete2PakRecords
            /// <summary>
            /// Support method meant to be called by drs ONLY.
            /// In fact, if a non-drs user calls it, nothing happens.
            /// It finds all 2-pack salespack record where the
            /// items have more than that salespack record.
            /// It does all the things that happen if it had
            /// been deleted in the UI.
            /// </summary>
            public static bool Delete2PakRecords()
            {
                if (UserLogon.Username != "drs")
                    return false;

                /// When the user deletes a SalesPack in the UI, the following happens:
                /// 1) SemiDeleted is set to true on the salespack record.
                /// 2) IsPrimary is set to false on the salespack record.
                /// 3) SemiDeleted is set to true on all related barcode records.
                /// 4) The font is set to red on the salespack grid record.

                using (OleDbConnection conn = new OleDbConnection(db.ConnectionString))
                {
                    conn.Open();
                    // first get a list of 2-pak salespacks
                    string sql = "select ItemID, PackType from SalesPack where PackType = 2";
                    using (OleDbCommand cmdGet2PakSP = new OleDbCommand(sql, conn))
                    {
                        DataTable SalesPacks2Pak = db.GetDataTable(cmdGet2PakSP);
                        foreach (DataRow SP2Pak in SalesPacks2Pak.Rows)
                        {
                            // check if this item has more that one salespack
                            int ItemID = tools.object2int(SP2Pak["ItemID"]);
                            sql = "select count(*) from SalesPack where ItemID = ?";
                            using (OleDbCommand cmdSelectNumSP = new OleDbCommand(sql, conn))
                            {
                                cmdSelectNumSP.Parameters.Add("ItemID", OleDbType.Integer).Value = ItemID;
                                if (tools.object2int(cmdSelectNumSP.ExecuteScalar()) > 1)
                                {
                                    // this item has a 2-pak salespack and has more than one salespack

                                    int PackType = tools.object2byte(SP2Pak["PackType"]);

                                    // update the salespack record
                                    sql = @"
                                        update SalesPack set
                                        SemiDeleted = ?,
                                        IsPrimary = ?,
                                        UpdateRSM = ?
                                        where ItemID = ?
                                        and PackType = ?
                                        ";
                                    using (OleDbCommand cmdSemiDeleteSalesPacks = new OleDbCommand(sql, conn))
                                    {
                                        cmdSemiDeleteSalesPacks.Parameters.Add("SemiDeleted", OleDbType.Boolean).Value = true;
                                        cmdSemiDeleteSalesPacks.Parameters.Add("IsPrimary", OleDbType.Boolean).Value = false;
                                        cmdSemiDeleteSalesPacks.Parameters.Add("UpdateRSM", OleDbType.Boolean).Value = true;
                                        cmdSemiDeleteSalesPacks.Parameters.Add("ItemID", OleDbType.Integer).Value = ItemID;
                                        cmdSemiDeleteSalesPacks.Parameters.Add("PackType", OleDbType.TinyInt).Value = PackType;
                                        cmdSemiDeleteSalesPacks.ExecuteNonQuery();
                                    }

                                    // if the item now doesn't have any primary salespack, select one
                                    sql = "select count(*) from SalesPack where IsPrimary = ? and ItemID = ?";
                                    using (OleDbCommand cmdCheckForPrimary = new OleDbCommand(sql, conn))
                                    {
                                        cmdCheckForPrimary.Parameters.Add("IsPrimary", OleDbType.Boolean).Value = true;
                                        cmdCheckForPrimary.Parameters.Add("ItemID", OleDbType.Integer).Value = ItemID;
                                        if (tools.object2int(cmdCheckForPrimary.ExecuteScalar()) < 1)
                                        {
                                            // the item does not have any primary salespack, select one
                                            sql = @"
                                                update SalesPack set
                                                IsPrimary = ?
                                                where PackType in
                                                (
                                                    select top 1 PackType from SalesPack
                                                    where ItemID = ?
                                                )
                                                and ItemID = ?
                                                ";
                                            using (OleDbCommand cmdUpdPrimary = new OleDbCommand(sql, conn))
                                            {
                                                cmdUpdPrimary.Parameters.Add("IsPrimary", OleDbType.Boolean).Value = true;
                                                cmdUpdPrimary.Parameters.Add("ItemID", OleDbType.Integer).Value = ItemID;
                                                cmdUpdPrimary.Parameters.Add("ItemID", OleDbType.Integer).Value = ItemID;
                                                cmdUpdPrimary.ExecuteNonQuery();
                                            }
                                        }
                                    }

                                    // update related barcodes
                                    sql = @"
                                        update Barcode set
                                        SemiDeleted = ?
                                        where ItemID = ?
                                        and PackType = ?
                                        ";
                                    using (OleDbCommand cmdSemiDeleteBarcodes = new OleDbCommand(sql, conn))
                                    {
                                        cmdSemiDeleteBarcodes.Parameters.Add("SemiDeleted", OleDbType.Boolean).Value = true;
                                        cmdSemiDeleteBarcodes.Parameters.Add("ItemID", OleDbType.Integer).Value = ItemID;
                                        cmdSemiDeleteBarcodes.Parameters.Add("PackType", OleDbType.TinyInt).Value = PackType;
                                        cmdSemiDeleteBarcodes.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }

                return true;
            }
            #endregion
        }

        #endregion

        #region SalesPackFuturePricesDataTable
        public enum SalesPackFuturePriceOrigin { BFI, LOK }
        partial class SalesPackFuturePricesDataTable
        {
            protected bool AlreadyAutoEditingAField = false;

            #region OnColumnChanged
            protected override void OnColumnChanged(DataColumnChangeEventArgs e)
            {
                /// Note: The below code inserts default values to some fields.
                /// While this could have been done in a row created event, we wanted
                /// the values to be shown immeidately to the user, which happens if
                /// it's done this way.

                if (!AlreadyAutoEditingAField)
                {
                    if (e.Column != this.OriginColumn)
                    {
#if FSD
                        e.Row[OriginColumn] = SalesPackFuturePriceOrigin.BFI.ToString();
#else
                        AlreadyAutoEditingAField = true;
                        e.Row[OriginColumn] = SalesPackFuturePriceOrigin.LOK.ToString();
#endif
                    }

                    /// If the row is changing and it isn't user who does it
                    /// (which means when the row is created)
                    if (e.Column != this.PerformColumn &&
                        e.Column != this.SalesPriceColumn &&
                        e.Column != this.ActivationDateColumn)
                    {
                        AlreadyAutoEditingAField = true;
                        e.Row[PerformColumn] = true;
                    }
                }
                else
                    AlreadyAutoEditingAField = false;
                base.OnColumnChanged(e);
            }
            #endregion

            #region CreateRecord
            /// <summary>
            /// Creates the record in the database. If a record with the same
            /// key already existed, it is deleted first, regardless of what state it had.
            /// This is by design as user has accepted to create the record.
            /// </summary>
            public static void CreateRecord(
                int ItemID,
                int PackType,
                DateTime ActivationDate,
                SalesPackFuturePriceOrigin Origin,
                double SalesPrice)
            {
                // if record already existed, delete it no matter what state it had
                if (RecordExists(ItemID, PackType, ActivationDate))
                    DeleteRecord(ItemID, PackType, ActivationDate);
                PackType = 1; //20191120
                // create new record
                db.ExecuteNonQuery(string.Format(@"
                    insert into SalesPackFuturePrices (ItemID, PackType, ActivationDate, Origin, SalesPrice, Perform)
                    values ({0}, {1}, {2}, {3}, {4}, {5})
                    ", ItemID, PackType, tools.datetime4sql(ActivationDate.Date), tools.string4sql(Origin.ToString(), 5), tools.decimalnumber4sql(SalesPrice), 1));
            }
            #endregion

            #region DeleteRecord
            protected static void DeleteRecord(int ItemID, int PackType, DateTime ActivationDate)
            {
                db.ExecuteNonQuery(string.Format(@"
                    delete from SalesPackFuturePrices
                    where ItemID = {0}
                    and PackType = {1}
                    and ActivationDate = '{2}'
                    ", ItemID, PackType, ActivationDate));
            }
            #endregion

            #region RecordExists
            public static bool RecordExists(
                int ItemID,
                int PackType,
                DateTime ActivationDate)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(@"
                    select count(*) from SalesPackFuturePrices
                    where ItemID = {0} and PackType = {1} and ActivationDate = '{2}'
                    ", ItemID, PackType, ActivationDate))) > 0;
            }
            #endregion

            #region MarkAsSentToStations
            public static void MarkAsSentToStations(int ItemID, int PackType, DateTime ActivationDate)
            {
                db.ExecuteNonQuery(string.Format(@"
                        update SalesPackFuturePrices
                        set SentToStations = 1
                        where ItemID = {0}
                        and PackType = {1}
                        and ActivationDate = '{2}'
                        ", ItemID, PackType, ActivationDate));
            }
            #endregion

            #region MoreFuturePricesExistNotSendToStations
            /// <summary>
            /// This method checks to see if there are more records in SalesPackFuturePrices
            /// that has not been sent to stations. It does not look at the date, only if it is sent or not.
            /// </summary>
            public static bool MoreFuturePricesExistNotSendToStations(int ItemID, int PackType)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(@"
                    select count(*) from SalesPackFuturePrices
                    where ItemID = {0}
                    and PackType = {1}
                    and SentToStations <> 1
                    ", ItemID, PackType))) > 0;
            }
            #endregion
        }
        #endregion

        #region SalesPackFuturePricesPromptDataTable
        partial class SalesPackFuturePricesPromptDataTable
        {
            #region CheckIfAnySalesPacksAreDue
            public static bool CheckIfAnySalesPacksAreDue()
            {
                ItemDataSetTableAdapters.SalesPackFuturePricesPromptTableAdapter adapter =
                    new RBOS.ItemDataSetTableAdapters.SalesPackFuturePricesPromptTableAdapter();
                adapter.Connection = db.Connection;
                return adapter.GetData().Rows.Count > 0;
            }
            #endregion

            #region CloseDueSalesPacksNotMarkedForPerform
            public static void CloseDueSalesPacksNotMarkedForPerform()
            {
                ItemDataSetTableAdapters.SalesPackFuturePricesPromptTableAdapter adapter =
                    new RBOS.ItemDataSetTableAdapters.SalesPackFuturePricesPromptTableAdapter();
                adapter.Connection = db.Connection;
                adapter.CloseDueSalesPacks();
            }
            #endregion

            #region ApplyFutureSalesPacksMarkedForPerform
            public void ApplyFutureSalesPacksMarkedForPerform()
            {
                /// We do this on the already loaded data, as if we did it with a query and the form was opened before
                /// midnight and it now is past midnight, we could close records that user would not be aware off

                foreach (DataRow row in this.Rows)
                {
                    if (row.RowState != DataRowState.Deleted &&
                        row.RowState != DataRowState.Detached)
                    {
                        // update sales price on sales pack if marked for perform
                        if (tools.object2bool(row[PerformColumn]) == true)
                        {
                            ItemDataSet.SalesPackDataTable.UpdateSalesPrice(
                                tools.object2int(row[ItemIDColumn]),
                                tools.object2byte(row[PackTypeColumn]),
                                tools.object2double(row[FutureSalesPriceColumn]));
                        }

                        // close the record (no matter what state the Perform field has)
                        db.ExecuteNonQuery(string.Format(@"
                            update SalesPackFuturePrices set
                            ClosedDate = GETDATE()
                            where ItemID = {0}
                            and PackType = {1}
                            and ActivationDate = '{2}'
                            ",
                             tools.object2int(row[ItemIDColumn]),
                             tools.object2byte(row[PackTypeColumn]),
                             tools.object2datetime(row[ActivationDateColumn])));
                    }
                }
            }
            #endregion
        }
        #endregion

        #region PARTIAL CLASS: LookupPackSizeDataTable

        /// <summary>
        /// Custom code on LookupPackSizeDataTable
        /// </summary>
        partial class LookupPackSizeDataTable
        {
            /// <summary>
            /// Looks up the PackTypeName from the given PackType
            /// </summary>
            /// <returns>The PackTypeName or empty string if not found</returns>
            public string GetPackTypeName(short packType)
            {
                LookupPackSizeRow row = this.FindByPackType(packType);
                if (row != null)
                    return row.PackTypeName;
                else
                    return "";
            }

            /// <summary>
            /// Static method that returns the Amount (a quantity)
            /// field for the given PackType. 0 is returned if not found or error.
            /// </summary>
            public static int GetPackTypeQuantity(short PackType)
            {
                OleDbCommand cmd = new OleDbCommand("", db.Connection);
                cmd.CommandText = string.Format(
                    " select Amount from LookupPackSize where PackType = {0} ",
                    PackType);
                return tools.object2int(cmd.ExecuteScalar());
            }
        }

        #endregion

        #region PARTIAL CLASS: InactiveItemDataTable
        partial class InactiveItemDataTable
        {
            #region GetNextAvailableItemID
            public static int GetNextAvailableItemID()
            {
                return (tools.object2int(db.ExecuteScalar(string.Format(
                    " select max(ItemID) from InactiveItem "))) + 1);
            }
            #endregion

            #region SetLastChangeDateTime
            public static void SetLastChangeDateTime(int ItemID, DateTime LastChangeDateTime)
            {
                db.ExecuteNonQuery(string.Format(@"
                    update InactiveItem
                    set LastChangeDateTime = {1}
                    where ItemID = {0}
                    ",
                     ItemID,
                     tools.datetime4sql(LastChangeDateTime)));
            }
            #endregion

            #region GetInactiveItemFromItemID
            public static DataRow GetInactiveItemFromItemID(int ItemID)
            {
                return db.GetDataRow(string.Format(@"
                    select * from InactiveItem
                    where ItemID = {0}
                    ", ItemID));
            }
            #endregion

            #region GetInactiveItemFromBarcode
            public static DataRow GetInactiveItemFromBarcode(double Barcode)
            {
                return db.GetDataRow(string.Format(@"
                    select top 1 i.*
                    from (InactiveItem i
                    inner join InactiveBarcode b
                    on i.ItemID = b.ItemID)
                    where b.Barcode = {0}
                    ", Barcode));
            }
            #endregion

            #region GetInactiveItemFromSupplierItem
            public static DataRow GetInactiveItemFromSupplierItem(int SupplierNo, double OrderingNumber)
            {
                return db.GetDataRow(string.Format(@"
                    select top 1 i.*
                    from (InactiveItem i
                    inner join InactiveSupplierItem si
                    on i.ItemID = si.ItemID)
                    where (si.SupplierNo = {0})
                    and (si.OrderingNumber = {1})
                    ", SupplierNo, OrderingNumber));
            }
            #endregion

            #region UpdateCostPriceLatest
            public static void UpdateCostPriceLatest(int ItemID, double CostPrice)
            {
                // set CostPriceLatest and set and calculate Margin on InactiveItem
                double SalesPrice = tools.object2double(db.ExecuteScalar(string.Format(
                    " select POSSalesPrice from InactiveItem " +
                    " where ItemID = {0} ", ItemID)));
                db.ExecuteScalar(string.Format(
                    " update InactiveItem set " +
                    " CostPriceLatest = {0}, " +
                    " Margin = {1} " +
                    " where ItemID = {2} ",
                    tools.decimalnumber4sql(CostPrice),
                    tools.decimalnumber4sql(tools.CalcMargin(SalesPrice, CostPrice)),
                    ItemID));
            }
            #endregion

            #region NullUdmeldtPrDatoToNow
            public static void NullUdmeldtPrDatoToNow(int ItemID)
            {
                db.ExecuteNonQuery(string.Format(
                    " update InactiveItem set " +
                    " UdmeldtPrDato = NULL " +
                    " where ItemID = {0} ",
                    ItemID));
            }
            #endregion

            #region DeleteInactiveItem
            public static void DeleteInactiveItem(int ItemID)
            {
                db.ExecuteNonQuery(string.Format(@"
                    delete from InactiveItem
                    where ItemID = {0}
                    ", ItemID));
            }
            #endregion

            #region SetKampagneID
            public static void SetKampagneID_and_FSD_ID(int ItemID, int KampagneID, int FSD_ID)
            {
                if (GetInactiveItemFromItemID(ItemID) != null)
                {
                    db.ExecuteNonQuery(string.Format(@"
                        update InactiveItem set
                        KampagneID = {1},
                        FSD_ID = {2}
                        where ItemID = {0}                    
                        ", ItemID, KampagneID, FSD_ID));
                }
            }
            #endregion
        }
        #endregion

        #region PARTIAL CLASS InactiveSalesPackDataTable
        partial class InactiveSalesPackDataTable
        {
            #region GetPrimaryInactiveSalesPack
            public static DataRow GetPrimaryInactiveSalesPack(int ItemID)
            {
                return db.GetDataRow(string.Format(@"
                    select top 1 *
                    from InactiveSalesPack
                    where (ItemID = {0})
                    and (IsPrimary = 1)
                    ", ItemID));
            }
            #endregion

            #region GetSalesPackFromBarcode
            public static DataRow GetSalesPackFromBarcode(double Barcode)
            {
                return db.GetDataRow(string.Format(@"
                    select top 1 *
                    from (InactiveSalesPack sp
                    inner join InactiveBarcode b
                    on (sp.ItemID = b.ItemID)
                    and (sp.PackType = b.PackType))
                    where b.Barcode = {0}
                    ", Barcode));
            }
            #endregion

            #region UpdateSalesPrice
            public static void UpdateSalesPrice(int ItemID, int PackType, double SalesPrice)
            {
                // update salesprice on inactivesalespack
                db.ExecuteNonQuery(string.Format(
                    " update InactiveSalesPack set " +
                    " SalesPrice = {0} " +
                    " where (ItemID = {1}) " +
                    " and (PackType = {2}) ",
                    tools.decimalnumber4sql(SalesPrice),
                    ItemID,
                    PackType));

                // check if this inactive salespack is the primary on the inactive item
                bool IsPrimary = tools.object2bool(db.ExecuteScalar(string.Format(
                    " select IsPrimary from InactiveSalesPack " +
                    " where (ItemID = {0}) " +
                    " and (PackType = {1}) ",
                    ItemID, PackType)));

                if (IsPrimary)
                {
                    // set POSSalesPrice and set and calculate Margin on inactive Item
                    double CostPriceLatest = tools.object2double(db.ExecuteScalar(string.Format(
                        " select CostPriceLatest from InactiveItem " +
                        " where ItemID = {0} ", ItemID)));
                    db.ExecuteNonQuery(string.Format(
                        " update InactiveItem set " +
                        " POSSalesPrice = {0}, " +
                        " Margin = {1} " +
                        " where ItemID = {2} ",
                        tools.decimalnumber4sql(SalesPrice),
                        tools.decimalnumber4sql(tools.CalcMargin(SalesPrice, CostPriceLatest)),
                        ItemID));
                }
            }
            #endregion

            #region DeleteInactiveSalesPacks
            public static void DeleteInactiveSalesPacks(int ItemID)
            {
                db.ExecuteNonQuery(string.Format(@"
                    delete from InactiveSalesPack
                    where ItemID = {0}
                    ", ItemID));
            }
            #endregion
        }
        #endregion

        #region PARTIAL CLASS InactiveBarcodeDataTable

        partial class InactiveBarcodeDataTable
        {
            #region AddInactiveBarcode
            public static void AddInactiveBarcode(int ItemID, int PackType, double Barcode)
            {
                // generate BCType
                int BCType = 1; // default custom
                if (Barcode.ToString().Length == 13)
                    BCType = 2;
                else if (Barcode.ToString().Length == 8)
                    BCType = 3;

                db.ExecuteNonQuery(string.Format(@"
                    insert into InactiveBarcode
                    (ItemID, PackType, Barcode, BCType)
                    values ({0},{1},{2},{3})
                    ", ItemID, PackType, Barcode, BCType));
            }
            #endregion

            #region InactiveBarcodeExists
            public static bool InactiveBarcodeExists(double barcode)
            {
                return (!tools.IsNullOrDBNull(db.ExecuteScalar(string.Format(@"
                    select Barcode from InactiveBarcode
                    where Barcode = {0}
                    ", barcode))));
            }
            #endregion

            #region DeleteInactiveBarcodes
            public static void DeleteInactiveBarcodes(int ItemID)
            {
                db.ExecuteNonQuery(string.Format(@"
                    delete from InactiveBarcode
                    where ItemID = {0}
                    ", ItemID));
            }
            #endregion
        }

        #endregion

        #region PARTIAL CLASS InactiveSupplierItemDataTable
        partial class InactiveSupplierItemDataTable
        {
            #region SearchItemsWithOrderingNumber
            /// <summary>
            /// Searches items that has the given ordering number in InactiveSupplierItem table.
            /// </summary>
            public static List<int> SearchItemsWithOrderingNumber(double OrderingNumber)
            {
                List<int> list = new List<int>();
                DataTable table = db.GetDataTable(string.Format(
                    " select distinct ItemID " +
                    " from InactiveSupplierItem " +
                    " where (OrderingNumber = {0}) ",
                    OrderingNumber));
                foreach (DataRow row in table.Rows)
                    list.Add(tools.object2int(row["ItemID"]));
                return list;
            }
            #endregion

            #region UpdateCostPrice
            public static void UpdateCostPrice(double CostPrice, int SupplierNo, double OrderingNumber)
            {
                double PackageUnitCost = CostPrice;

                // get an InactiveSupplierItem record to work with
                DataRow InactiveSupplierItemRow = db.GetDataRow(string.Format(
                    " select * from InactiveSupplierItem " +
                    " where (SupplierNo = {0}) " +
                    " and (OrderingNumber = {1}) ",
                    SupplierNo, OrderingNumber));
                if (InactiveSupplierItemRow == null) return; // data check

                // re-calculate PackageCost
                int KolliSize = tools.object2int(InactiveSupplierItemRow["KolliSize"]);
                double PackageCost = PackageUnitCost * KolliSize;

                // re-calculate SellingUnitCost       
                double SellingUnitCost = 0;
                int NoOfSellingUnits = tools.object2int(InactiveSupplierItemRow["NoOfSellingUnits"]);
                if (NoOfSellingUnits != 0)
                    SellingUnitCost = PackageUnitCost / NoOfSellingUnits;

                // perform the update
                db.ExecuteNonQuery(string.Format(
                    " update InactiveSupplierItem set " +
                    " PackageUnitCost = {0}, " +
                    " PackageCost = {1}, " +
                    " SellingUnitCost = {2} " +
                    " where ID = {3} ",
                    tools.decimalnumber4sql(PackageUnitCost),
                    tools.decimalnumber4sql(PackageCost),
                    tools.decimalnumber4sql(SellingUnitCost),
                    InactiveSupplierItemRow["ID"]));

                // if this is the primary inactive supplier item, update inactive item
                if (tools.object2bool(InactiveSupplierItemRow["IsPrimary"]))
                {
                    int ItemID = tools.object2int(InactiveSupplierItemRow["ItemID"]);
                    InactiveItemDataTable.UpdateCostPriceLatest(ItemID, PackageUnitCost);
                }
            }
            #endregion

            #region AddInactiveSupplierItem
            public static void AddInactiveSupplierItem(int ItemID, int SupplierNo, double OrderingNumber, double CostPrice, int Kolli)
            {
                // this new inactive supplieritem will be primary if no
                // other inactive supplieritems exists for this inactive item
                bool IsPrimary = (tools.object2int(db.ExecuteScalar(string.Format(
                    " select count(*) from InactiveSupplierItem " +
                    " where ItemID = {0} ", ItemID))) <= 0);


                // create the inactive supplieritem record
                db.ExecuteNonQuery(string.Format(
                    " insert into InactiveSupplierItem " +
                    " (ItemID,SupplierNo,OrderingNumber,KolliSize,PackageCost,PackageUnitCost," +
                    "  IsPrimary,SellingPackType,NoOfSellingUnits,SellingUnitCost) " +
                    " values ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9}) ",
                    ItemID,
                    SupplierNo,
                    tools.decimalnumber4sql(OrderingNumber),
                    Kolli, // KolliSize
                    tools.decimalnumber4sql(Kolli * CostPrice), // PackageCost
                    tools.decimalnumber4sql(CostPrice), //PackageUnitCost
                    tools.bool4sql(IsPrimary),
                    1, // SellingPackType
                    1, // NoOfSellingUnits
                    tools.decimalnumber4sql(CostPrice))); // SellingUnitCost

                if (IsPrimary)
                {
                    InactiveItemDataTable.UpdateCostPriceLatest(ItemID, CostPrice);
                }

                // if missing kollisize in table LookupKolliSize, create it
                int KolliSize = Kolli;
                LookupKolliSizeAdminDataTable.CreateUserDefinedKolliSizeIfNonExisting(KolliSize);

                // null InactiveItem.UdmeldtPrDato to be sure that if LL has send
                // us update data that first discards a supplieritem and then
                // creates a new on the same item (found by barcode), then
                // the item will not have the udmeldt flag on while still active.
                if (ItemID != 0)
                    InactiveItemDataTable.NullUdmeldtPrDatoToNow(ItemID);
            }
            #endregion

            #region GetInactiveSupplierItem
            public static DataRow GetInactiveSupplierItem(double OrderingNumber, int SupplierNo)
            {
                return db.GetDataRow(string.Format(@"
                    select * from InactiveSupplierItem
                    where (OrderingNumber = {0})
                    and (SupplierNo = {1})
                    ", OrderingNumber, SupplierNo));
            }
            #endregion

            #region DeleteInactiveSupplierItem
            public static void DeleteInactiveSupplierItem(double OrderingNumber, int SupplierNo)
            {
                db.ExecuteNonQuery(string.Format(@"
                    delete from InactiveSupplierItem
                    where (OrderingNumber = {0})
                    and (SupplierNo = {1})
                    ", OrderingNumber, SupplierNo));
            }
            #endregion

            #region DeleteInactiveSupplierItems
            public static void DeleteInactiveSupplierItems(int ItemID)
            {
                db.ExecuteNonQuery(string.Format(@"
                    delete from InactiveSupplierItem
                    where (ItemID = {0})
                    ", ItemID));
            }
            #endregion

            #region NumSupplierItemsOnItem
            public static int NumSupplierItemsOnItem(int ItemID)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(
                    " select count(*) from InactiveSupplierItem " +
                    " where ItemID = {0} ", ItemID)));
            }
            #endregion

            #region GetPrimaryInactiveSupplierItem
            public static DataRow GetPrimaryInactiveSupplierItem(int ItemID)
            {
                return db.GetDataRow(string.Format(@"
                    select * from InactiveSupplierItem
                    where (ItemID = {0})
                    and (IsPrimary = 1)
                    ", ItemID));
            }
            #endregion

            #region SetFirstAndBestToPrimaryIfPrimaryIsMissing
            public static void SetFirstAndBestToPrimaryIfPrimaryIsMissing(int ItemID)
            {
                if (GetPrimaryInactiveSupplierItem(ItemID) == null)
                {
                    // set first and best inactive supplieritem
                    // on the item to primary, if the item does not
                    // have any primary supplier item, if any
                    // inactive supplieritems exists
                    db.ExecuteNonQuery(string.Format(@"
                    update InactiveSupplierItem
                    set IsPrimary = 1
                    where ID in
                    (
                        select top 1 ID
                        from InactiveSupplierItem
                        where ItemID = {0}
                    )
                    ", ItemID));

                    // if an inactive supplieritem has been set
                    // copy PackageUnitCost to inactiveitem's CostPriceLatest
                    DataRow PrimaryRow = GetPrimaryInactiveSupplierItem(ItemID);
                    if (PrimaryRow != null)
                    {
                        double PackageUnitCost = tools.object2double(PrimaryRow["PackageUnitCost"]);
                        db.ExecuteNonQuery(string.Format(@"
                            update InactiveItem
                            set CostPriceLatest = {0}
                            where ItemID = {1}
                            ",
                             tools.decimalnumber4sql(PackageUnitCost),
                             ItemID));
                    }
                }
            }
            #endregion
        }
        #endregion

        #region PARTIAL CLASS: ExportFVDHeaderDataTable
        partial class ExportFVDHeaderDataTable
        {
            #region CreateRecord
            /// <summary>
            /// Create FVD export header, with initial data in it,
            /// then return the autocreated id.
            /// </summary>
            /// <returns></returns>
            public static int CreateRecord(
                int NumDetailRecords,
                string Criteria)
            {
                db.ExecuteNonQuery(string.Format(@"
                    insert into ExportFVDHeader
                    (ExportDateTime,NumDetailRecords,Criteria)
                    values ({0},{1},{2})",
                    tools.datetime4sql(DateTime.Now),
                    tools.wholenumber4sql(NumDetailRecords),
                    tools.string4sql(Criteria, 255)));

                return tools.object2int(db.ExecuteScalar(
                    " select max(ID) from ExportFVDHeader "));
            }
            #endregion

            #region SetFilename
            public static void SetFilename(int HeaderID, string Filename)
            {
                db.ExecuteNonQuery(string.Format(@"
                    update ExportFVDHeader
                    set Filename = {1}
                    where ID = {0}
                    ",
                     HeaderID,
                     tools.string4sql(Filename, 255)));
            }
            #endregion

            #region SetSentOutDateTime
            public static void SetSentOutDateTime(int HeaderID, DateTime SentOutDateTime)
            {
                db.ExecuteNonQuery(string.Format(@"
                    update ExportFVDHeader
                    set SentOutDateTime = {1}
                    where ID = {0}
                    ",
                     HeaderID,
                     tools.datetime4sql(SentOutDateTime)));
            }
            #endregion

            #region HasAnyUnsentRecords
            /// <summary>
            /// Reports if any records does not have a value in SentOutDateTime.
            /// </summary>
            public static bool HasAnyUnsentRecords()
            {
                return (tools.object2int(db.ExecuteScalar(@"
                    select count(*) from ExportFVDHeader
                    where SentOutDateTime is null
                    ")) > 0);
            }
            #endregion

            #region CalculateNumDeletedSupplierItems
            /// <summary>
            /// Calculates the number of records in FSDDeletedSupplierItemDataTable
            /// related to each record's header ID. Writes the values into the
            /// calculated field CalcNumDeletedSupplierItems.
            /// </summary>
            public void CalculateNumDeletedSupplierItems()
            {
                foreach (DataRow row in this.Rows)
                {
                    if ((row.RowState != DataRowState.Deleted) &&
                        (row.RowState != DataRowState.Detached))
                    {
                        if (tools.IsNullOrDBNull(row[SentOutDateTimeColumn]))
                        {
                            // export data has not been sent yet,
                            // so get the non-historic deleted supplier items
                            row[CalcNumDeletedSupplierItemsColumn] =
                                FSDDeletedSupplierItemDataTable.GetNumNonHistoricRecords();
                        }
                        else
                        {
                            // export data has been sent out, so
                            // get the historic deleted supplier items
                            // related to this export header
                            int ID = tools.object2int(row[IDColumn]);
                            row[CalcNumDeletedSupplierItemsColumn] =
                                FSDDeletedSupplierItemDataTable.GetNumHistoricRecords(ID);
                        }
                    }
                }
            }
            #endregion

            #region RecalculateAndWriteNumDetailRecords
            /// <summary>
            /// Recalculates the field NumDetailRecords by counting the
            /// number of records in ExportFVDDetails that has the HeaderID.
            /// This is used when deleting the detail records and the header
            /// needs to be updated.
            /// </summary>
            public static void RecalculateAndWriteNumDetailRecords(int HeaderID)
            {
                int numdetails = ExportFVDDetailsDataTable.GetNumRecords(HeaderID);

                db.ExecuteNonQuery(string.Format(@"
                    update ExportFVDHeader set
                    NumDetailRecords = {1}
                    where ID = {0}
                    ", HeaderID, numdetails));
            }
            #endregion

            #region IsUnsentRecord
            public static bool IsUnsentRecord(int HeaderID)
            {
                return (tools.object2int(db.ExecuteScalar(string.Format(@"
                    select count(*) from ExportFVDHeader
                    where (ID = {0})
                    and (SentOutDateTime is null)
                    ", HeaderID))) > 0);
            }
            #endregion
        }
        #endregion

        #region PARTIAL CLASS: ExportFVDDetailsDataTable
        partial class ExportFVDDetailsDataTable
        {
            #region CreateRecord
            /// <summary>
            /// Create FVD detail record.
            /// FutureSalesPriceDate can be null
            /// </summary>
            public static void CreateRecord(int HeaderID, double Stregkode, double Bestillnr, string Varetekst,
                int Kolli, string Subcat, double Kostpris, double Salgspris,
                int Leverandoernr, int KampagneID, int FSD_ID, int PackType, object FutureSalesPriceDate,
                DateTime DisktilbudFraDato, DateTime DisktilbudTilDato, int DisktilbudThreshold)
            {
                db.ExecuteNonQuery(string.Format(@"
                    insert into ExportFVDDetails
                    (HeaderID,Stregkode,Bestillnr,Varetekst,Kolli,
                     Subcat,Kostpris,Salgspris,Leverandoernr,KampagneID,FSD_ID,
                     PackType,FutureSalesPriceDate,DisktilbudFraDato,DisktilbudTilDato,DisktilbudThreshold)
                    values ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15})
                    ",
                     tools.wholenumber4sql(HeaderID),
                     tools.decimalnumber4sql(Stregkode),
                     tools.decimalnumber4sql(Bestillnr),
                     tools.string4sql(Varetekst, 50),
                     tools.wholenumber4sql(Kolli),
                     tools.string4sql(Subcat, 20),
                     tools.decimalnumber4sql(Kostpris),
                     tools.decimalnumber4sql(Salgspris),
                     tools.wholenumber4sql(Leverandoernr),
                     tools.wholenumber4sql(KampagneID),
                     tools.wholenumber4sql(FSD_ID),
                     tools.wholenumber4sql(PackType),
                     tools.datetime4sql(FutureSalesPriceDate),
                     tools.datetime4sql(DisktilbudFraDato),
                     tools.datetime4sql(DisktilbudTilDato),
                     tools.wholenumber4sql(DisktilbudThreshold)
                     ));
            }
            #endregion

            #region DeleteRecords
            /// <summary>
            /// Deletes records with the given HeaderID.
            /// This is used when deleting a header record and
            /// it's detail records needs to be deleted too.
            /// </summary>
            /// <param name="HeaderID"></param>
            public static void DeleteRecords(int HeaderID)
            {
                db.ExecuteNonQuery(string.Format(@"
                    delete from ExportFVDDetails
                    where HeaderID = {0}
                    ", HeaderID));
            }
            #endregion

            #region GetNumRecords
            public static int GetNumRecords(int HeaderID)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(@"
                    select count(*) from ExportFVDDetails
                    where HeaderID = {0}
                    ", HeaderID)));
            }
            #endregion

            #region GetUnsentData
            public static DataTable GetUnsentData()
            {
                return db.GetDataTable(string.Format(@"
                    select * from ExportFVDDetails d
                    left join ExportFVDHeader h
                    on d.HeaderID = h.ID
                    where h.SentOutDateTime is null
                    "));
            }
            #endregion

            #region GetData
            public static DataTable GetData(int HeaderID)
            {
                return db.GetDataTable(string.Format(@"
                    select * from ExportFVDDetails
                    where HeaderID = {0}
                    ", HeaderID));
            }
            #endregion
        }
        #endregion

        #region PARTIAL CLASS: ExportFVDReportHeaderDataTable
        partial class ExportFVDReportHeaderDataTable
        {
            /// <summary>
            /// Will calculate the number of deleted
            /// supplier items for this set of exported data
            /// and set the field CalcNumDeletedSupplierItems
            /// with this value on the only record loaded.
            /// </summary>
            public void SetCalcNumDeletedSupplierItems()
            {
                if (this.Rows.Count > 0)
                {
                    int HeaderID = tools.object2int(this.Rows[0][IDColumn]);
                    this.Rows[0][CalcNumDeletedSupplierItemsColumn] =
                        FSDDeletedSupplierItemDataTable.GetNumHistoricRecords(HeaderID);
                }
            }
        }
        #endregion

        #region Static methods on ItemDataSet

        #region IsUniqueItemName
        /// <summary>
        /// Checks Item table in database to see if the provided itemName
        /// is unique. Is static as no instance is needed and no tables needs to be filled.
        /// </summary>
        /// <param name="itemName">New item name.</param>
        /// <param name="itemID">
        /// If editing an itemname, this is the id of
        /// the existing item on which the rename is performed.
        /// If creating a new item, just set this to 0.
        /// This id is used to check all other items than the one being renamed.</param>
        /// <returns>True if unique, false if not or if some error occured.</returns>
        public static bool IsUniqueItemName(string itemName, int itemID)
        {
            //string sql = string.Format(
            //    " select ItemName from Item " +
            //    " where (ItemName = \"{0}\") " +
            //    " and (ItemID <> {1}) ", // if 0, all items are checked against
            //    itemName.Replace("\"", "'"), itemID);
            //string sql = string.Format(
            //    " select ItemName from Item " +
            //    " where (ItemName = '{0}') " +
            //    " and (ItemID <> {1}) ", // if 0, all items are checked against
            //    itemName, itemID);
            //return (db.GetDataRow(sql) == null);
            return (true);// PN20191205 
        }
        #endregion

        #region SaveNewItem
        /// <summary>
        /// Generates an Item record and returns the autogenerated ItemID.
        /// PRECONDITION: caller MUST have checked that the ItemName is unique,
        /// and this can be done with a call to IsUniqueItemName first.
        /// </summary>
        /// <param name="itemName">Unique ItemName (use IsUniqueItemName to check first).</param>
        /// <returns>Autogenerated ItemID or 0 if not generated.</returns>
        public static int SaveNewItem(string itemName)
        {
            // select the first subcategory to use as default value for the subcategory field
            string sql = " select top 1 SubCategoryID from SubCategory order by SubCategoryID asc ";
            OleDbCommand cmd = new OleDbCommand(sql, db.Connection);
            object o = cmd.ExecuteScalar();
            string subCategoryID = ((o != DBNull.Value) && (o != null)) ? o.ToString() : "";

            // generate Item record
            sql = string.Format(
                " insert into Item (ItemName,SubCategory) values ({0},'{1}') ",
                tools.string4sql(itemName, 50),
                subCategoryID);
            cmd = new OleDbCommand(sql, db.Connection);
            cmd.ExecuteNonQuery();

            // get generated ItemID
            int NewItemID = GetLatestItemID();

#if FSD
            // if FSD version, set the FSD_ID to next FSD_ID
            ItemDataTable.AssignNextFSD_ID(NewItemID);
#endif

            // return generated ItemID
            return NewItemID;
        }
        #endregion

        #region GetLatestItemID
        /// <summary>
        /// Returns the currently latest ItemID.
        /// </summary>
        public static int GetLatestItemID()
        {
            string sql = "select max(ItemID) from Item";
            OleDbCommand cmd = new OleDbCommand(sql, db.Connection);
            object o = cmd.ExecuteScalar();
            if ((o != DBNull.Value) && (o != null))
                return int.Parse(o.ToString().Clone().ToString());
            else
                return 0;
        }
        #endregion

        #region SemiDeleteItemAndChilds
        /// <summary>
        /// Deletes the specified Item record and related SalesPack and Barcode records.
        /// This is a semi delete, that is, the SemiDelete flag is set on the records.
        /// </summary>
        /// <returns>An empty string "" if all ok, otherwise an error if transaction failed.</returns>
        public static string SemiDeleteItemAndChilds(int ItemID)
        {
            try
            {
                // start a transaction before semi-deleting item
                db.StartTransaction();

                // before delete is done, we copy the item and
                // related detail records to the inactive tables
                ItemDataSet.CopyItemToInactiveItems(ItemID);

                // semi-delete item in Item table
                string sql = string.Format(" update Item set SemiDeleted = 1 where ItemID = {0} ", ItemID);
                OleDbCommand cmd = new OleDbCommand(sql, db.Connection);
                cmd.Transaction = db.CurrentTransaction;
                cmd.ExecuteNonQuery();

                // semi-delete related records in SalesPack table
                sql = string.Format(" update SalesPack set SemiDeleted = 1 where ItemID = {0} ", ItemID);
                cmd = new OleDbCommand(sql, db.Connection);
                cmd.Transaction = db.CurrentTransaction;
                cmd.ExecuteNonQuery();

                // semi-delete related records in Barcode table
                sql = string.Format(" update Barcode set SemiDeleted = 1 where ItemID = {0} ", ItemID);
                cmd = new OleDbCommand(sql, db.Connection);
                cmd.Transaction = db.CurrentTransaction;
                cmd.ExecuteNonQuery();

#if FSD
                FSDDeletedSupplierItemDataTable.CopySupplierItem_To_FSDDeletedSupplierItem(ItemID);
#endif

                // delete related records in SupplierItem table (not a semi-delete)
                db.ExecuteNonQuery(string.Format(" delete from SupplierItem where ItemID = {0} ", ItemID));

                // delete ItemTransactions that belonged to the inactivated item
                ItemTransactionDataTable.DeleteRecords(ItemID);

                // commit transaction
                db.CommitTransaction();

                // all ok
                return "";
            }
            catch (Exception ex)
            {
                // error occured while semi-deleting, rollback changes and inform user
                db.RollbackTransaction();

                // save exception in log file
                log.Write("--------------------------------------------");
                log.Write("ERROR WHILE SEMI-DELETING ITEM:");
                log.Write("MESSAGE: " + ex.Message);
                log.Write("STACKTRACE: " + ex.StackTrace);
                log.Write("--------------------------------------------");

                string msg =
                    "Error occured while semi-deleting data. Undoing delete. Please contact support.\n" +
                    "The log file contains detail information about the error.";
                return msg;
            }
        }
        #endregion

        #region SemiDeleteItemsAndChilds (4 methods included)

        /// <summary>
        /// Helper method for:
        /// SemiDeleteItemsAndChilds_HowManyWouldBeDeleted and
        /// SemiDeleteItemsAndChilds_FillTable, both expected
        /// to be called when using the delete multiple items functionallity.
        /// </summary>
        private static string SemiDeleteItemsAndChilds_SQL(
            string SubCategory,
            DateTime LatestAllowedTransactionDate,
            DateTime LatestAllowedItemChangeDateTime,
            bool AllowDeleteItemsWithStock,
            bool OnlyIncludeUdmeldte,
            bool OutputDetailedFields)
        {
            // remove time from the datetime variable
            LatestAllowedTransactionDate = LatestAllowedTransactionDate.Date;



            // build sql
            string sql = string.Format(@"
            select distinct i.ItemID, i.ItemName ###FIELDS###
            from (Item i
            inner join SalesPack sp
            on i.ItemID = sp.ItemID)
            where (i.SubCategory = '{1}')
            and (i.SemiDeleted <> 1)
            and (i.KampagneID = 0 or i.KampagneID is null)
            and ((i.InStock = 0) or (i.InStock is null) or (1 = {2}))
            and ((i.UdmeldtPrDato is not null) and (1 = {4}) or (0 = {4}))
            and ((sp.ChainBarcode is null) or (sp.ChainBarcode = 0))
            and (i.LastChangeDateTime < '{3}')
            and not exists
            (
              select distinct it.ItemID
              from ItemTransaction it
              where (it.PostingDate >= '{0}')
              and (it.TransactionType not in (4,8) )   
              and (i.ItemID = it.ItemID)
            )
            order by i.ItemName
            ",
                 LatestAllowedTransactionDate,
                 SubCategory,
                 tools.bool4sql(AllowDeleteItemsWithStock),
                 LatestAllowedItemChangeDateTime,
                 tools.bool4sql(OnlyIncludeUdmeldte));
            //pn20210118  
            if (OutputDetailedFields)
            {
                string sqlExtra = @", i.InStock,
                  (select Barcode from SalesPack sp where (i.ItemID = sp.ItemID) and (sp.IsPrimary = 1)) as Barcode,
                  (select PackTypeName from LookupPackSize where PackType in (select PackType from SalesPack sp2 where (i.ItemID = sp2.ItemID) and (sp2.IsPrimary = 1))) as PackTypeName,
                  (select OrderingNumber from SupplierItem si where (i.ItemID = si.ItemID) and (si.IsPrimary = 1)) as OrderingNumber
                    ";

                sql = sql.Replace("###FIELDS###", sqlExtra);
            }
            else
            {
                sql = sql.Replace("###FIELDS###", "");
            }

            return sql;
        }

        /// <summary>
        /// Returns how many items and childs would be deleted applying the provided criterias.
        /// </summary>
        public static int SemiDeleteItemsAndChilds_HowManyWouldBeDeleted(
            string SubCategory,
            DateTime LatestAllowedTransactionDate,
            DateTime LatestAllowedItemChangeDateTime,
            bool AllowDeleteItemsWithStock,
            bool OnlyIncludeUdmeldte)
        {
            // build sql


            string sql = SemiDeleteItemsAndChilds_SQL(
                SubCategory,
                LatestAllowedTransactionDate,
                LatestAllowedItemChangeDateTime,
                AllowDeleteItemsWithStock,
                OnlyIncludeUdmeldte,
                false);

            // return how many records
            return db.GetDataTable(sql).Rows.Count;
        }

        /// <summary>
        /// Fills a table with detailed fields of what would be deleted
        /// applying the provided criterias. This is used for viewing.
        /// </summary>
        public static void SemiDeleteItemsAndChilds_FillTable(
            string SubCategory,
            DateTime LatestAllowedTransactionDate,
            DateTime LatestAllowedItemChangeDateTime,
            bool AllowDeleteItemsWithStock,
            bool OnlyIncludeUdmeldte,
            ItemsDeleteDataTable Items)
        {
            // build sql
            string sql = SemiDeleteItemsAndChilds_SQL(
                SubCategory,
                LatestAllowedTransactionDate,
                LatestAllowedItemChangeDateTime,
                AllowDeleteItemsWithStock,
                OnlyIncludeUdmeldte,
                true);

            // fill table
            db.FillDataTable(sql, Items, true);
        }

        /// <summary>
        /// Semideletes the items provided.
        /// </summary>
        public static void SemiDeleteItemsAndChilds(ItemsDeleteDataTable Items)
        {
            // semidelete items
            ProgressForm progress = new ProgressForm(db.GetLangString("ItemDataSet.SemiDeleteItemsAndChilds.Deleting"));
            progress.ProgressMax = Items.Rows.Count;
            progress.Show();
            foreach (DataRow row in Items.Rows)
            {
                if (tools.object2bool(row["IncludeInSemiDelete"]))
                {
                    progress.StatusText = tools.object2string(row["ItemName"]);
                    SemiDeleteItemAndChilds(tools.object2int(row["ItemID"]));
                }
            }
            progress.Close();
        }

        #endregion

        #region DeleteInactiveItemAndChilds
        /// <returns>An empty string "" if all ok, otherwise an error if transaction failed.</returns>
        public static string DeleteInactiveItemAndChilds(int ItemID)
        {
            try
            {
                // start a transaction before deleting item
                db.StartTransaction();

                db.ExecuteNonQuery(string.Format(" delete from InactiveItem where ItemID = {0} ", ItemID));
                db.ExecuteNonQuery(string.Format(" delete from InactiveSalesPack where ItemID = {0} ", ItemID));
                db.ExecuteNonQuery(string.Format(" delete from InactiveBarcode where ItemID = {0} ", ItemID));
                db.ExecuteNonQuery(string.Format(" delete from InactiveSupplierItem where ItemID = {0} ", ItemID));

                // commit transaction
                db.CommitTransaction();

                // all ok
                return "";
            }
            catch (Exception ex)
            {
                // error occured while deleting, rollback changes and inform user
                db.RollbackTransaction();

                // save exception in log file
                log.Write("--------------------------------------------");
                log.Write("ERROR WHILE DELETING INACTIVE ITEM:");
                log.Write("MESSAGE: " + ex.Message);
                log.Write("STACKTRACE: " + ex.StackTrace);
                log.Write("--------------------------------------------");

                string msg =
                    "Error occured while deleting inactive item. Undoing delete. Please contact support.\n" +
                    "The log file contains detail information about the error.";
                return msg;
            }
        }
        #endregion

        #region DeleteActiveItemAndChilds
        /// <summary>
        /// Delete the records from Item, SalesPack, Barcode and SupplierItem.
        /// This method is to be used in conjunction with cancelling an inactive
        /// item copy to active tables. Error message is returned or empty string if all ok.
        /// </summary>
        public static string DeleteActiveItemAndChilds(int ItemID)
        {
            try
            {
                // start a transaction before deleting item
                db.StartTransaction();

                db.ExecuteNonQuery(string.Format(" delete from Item where ItemID = {0} ", ItemID));
                db.ExecuteNonQuery(string.Format(" delete from SalesPack where ItemID = {0} ", ItemID));
                db.ExecuteNonQuery(string.Format(" delete from Barcode where ItemID = {0} ", ItemID));
                db.ExecuteNonQuery(string.Format(" delete from SupplierItem where ItemID = {0} ", ItemID));

                // commit transaction
                db.CommitTransaction();

                // all ok
                return "";
            }
            catch (Exception ex)
            {
                // error occured while deleting, rollback changes and inform user
                db.RollbackTransaction();

                // save exception in log file
                log.Write("--------------------------------------------");
                log.Write("ERROR WHILE DELETING ACTIVE ITEM:");
                log.Write("MESSAGE: " + ex.Message);
                log.Write("STACKTRACE: " + ex.StackTrace);
                log.Write("--------------------------------------------");

                string msg =
                    "Error occured while deleting active item. Undoing delete. Please contact support.\n" +
                    "The log file contains detail information about the error.";
                return msg;
            }
        }
        #endregion

        #region DeleteNewPendingItemAndChilds
        /// <summary>
        /// Completely deletes the specified Item record and related SalesPack and Barcode records.
        /// This is NOT a semi delete, as the item and childs was never sent to POS.
        /// </summary>
        public static void DeleteNewPendingItemAndChilds(int ItemID)
        {
            // delete record from Item table
            string sql = string.Format(" delete from Item where ItemID = {0} ", ItemID);
            OleDbCommand cmd = new OleDbCommand(sql, db.Connection);
            cmd.ExecuteNonQuery();

            // delete related records from SalesPack table
            sql = string.Format(" delete from SalesPack where ItemID = {0} ", ItemID);
            cmd = new OleDbCommand(sql, db.Connection);
            cmd.ExecuteNonQuery();

            // delete related records from Barcode table
            sql = string.Format(" delete from Barcode where ItemID = {0} ", ItemID);
            cmd = new OleDbCommand(sql, db.Connection);
            cmd.ExecuteNonQuery();
        }
        #endregion

        #region DeleteAllSemiDeleted
        /// <summary>
        /// Deletes all Items, SalesPacks and Barcodes with SemiDeleted == true.
        /// WARNING: Be sure that these data have been sent to POS first!!!
        /// </summary>
        public static void DeleteAllSemiDeleted()
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand("", db.Connection);
                cmd.Transaction = db.StartTransaction();

                // delete items with SemiDeleted == true
                cmd.CommandText = "delete from Item where SemiDeleted = 1";
                cmd.ExecuteNonQuery();

                // delete related salespack future prices
                cmd.CommandText = @"
                delete from SalesPackFuturePrices
                where exists (
                    select ItemID, PackType from SalesPack sp
                    where sp.ItemID = SalesPackFuturePrices.ItemID
                    and sp.PackType = SalesPackFuturePrices.PackType
                    and sp.SemiDeleted = 1 )
                ";
                cmd.ExecuteNonQuery();

                // delete salespacks with SemiDeleted == true
                cmd.CommandText = "delete from SalesPack where SemiDeleted = 1";
                cmd.ExecuteNonQuery();

                // delete barcodes with SemiDeleted == true
                cmd.CommandText = "delete from Barcode where SemiDeleted = 1";
                cmd.ExecuteNonQuery();

                db.CommitTransaction();
            }
            catch (Exception ex)
            {
                if (db.CurrentTransaction != null)
                    db.RollbackTransaction();
                log.WriteException("ItemDataSet.DeleteAllSemideleted", ex.Message, ex.StackTrace);
                MessageBox.Show("There was an error deleting the item(s). Please contact support");
            }
        }
        #endregion

        #region LookupPackTypeAmount
        /// <summary>
        /// Lookup PackType's Amount from LookupPackSize table.
        /// </summary>
        /// <param name="PackType"></param>
        /// <returns></returns>
        public static int LookupPackTypeAmount(int PackType)
        {
            string sql = string.Format("select Amount from LookupPackSize where PackType = {0}", PackType);
            OleDbCommand cmd = new OleDbCommand(sql, db.Connection);
            object o = cmd.ExecuteScalar();
            if ((o != null) && (o != DBNull.Value))
                return int.Parse(o.ToString());
            else
                return 0;
        }
        #endregion

        #region CopyItemToInactiveItems
        public static void CopyItemToInactiveItems(int ItemID)
        {
            List<DataRow> AllowedBarcodes = new List<DataRow>();

            /// Build a list of barcodes that are allowed to be copied.
            /// Barcodes must be unique in the InactiveBarcode table.
            DataTable barcodes = db.GetDataTable(string.Format(@"
                select ItemID, PackType, Barcode from Barcode
                where ItemID = {0}
                ", ItemID));
            foreach (DataRow r in barcodes.Rows)
            {
                bool AlreadyExists = (tools.object2int(db.ExecuteScalar(string.Format(@"
                    select count(*) from InactiveBarcode
                    where Barcode = {0}
                    ", tools.object2double(r["Barcode"])))) > 0);
                if (!AlreadyExists)
                    AllowedBarcodes.Add(r);
            }

            /// If least one allowed barcode exists,
            /// continue copying the item
            if (AllowedBarcodes.Count > 0)
            {
                // get the next itemid in inactive items table
                int InactiveItemID = InactiveItemDataTable.GetNextAvailableItemID();

                // copy item
                DataRow rowItem = db.GetDataRow(string.Format(
                    " select * from Item where ItemID = {0} ", ItemID));
                if (rowItem != null)
                {
                    db.ExecuteNonQuery(string.Format(@"
                        insert into InactiveItem
                          (ItemID,ItemName,ItemType,SubCategory,SuggSalesPrice,PriceRegulation,
                          POSSalesPrice,CostPriceLatest,Margin,BudgetMargin,Supplier,InStock,
                          MinimumStock,LastChangeDateTime,LastSalesDate,LastPurchDate,LastInventDate,FocusItem,
                          ExternalID,VatRate,VatOwner,CreditCategory,InheritCreditCat,AgeRestriction,
                          InheritAgeRestric,MOPRestriction,InheritMOPRestr,SemiDeleted,
                          ItemTypeCode,InheritItemTypeCode,FastPrisVare,IkkeBeholdningsVare,UdmeldtPrDato,InactivateDateTime)
                        select
                          {0} as ItemID,ItemName,ItemType,SubCategory,SuggSalesPrice,PriceRegulation,
                          POSSalesPrice,CostPriceLatest,Margin,BudgetMargin,Supplier,NULL,
                          MinimumStock,LastChangeDateTime,LastSalesDate,LastPurchDate,LastInventDate,FocusItem,
                          ExternalID,VatRate,VatOwner,CreditCategory,InheritCreditCat,AgeRestriction,
                          InheritAgeRestric,MOPRestriction,InheritMOPRestr,SemiDeleted,
                          ItemTypeCode,InheritItemTypeCode,FastPrisVare,IkkeBeholdningsVare,UdmeldtPrDato,{2}
                        from Item
                        where ItemID = {1}
                        ",
                         InactiveItemID,
                         ItemID,
                         tools.datetime4sql(DateTime.Now)));
                }

                // build a list of allowed SalesPacks
                string packtypes = "";
                foreach (DataRow row in AllowedBarcodes)
                    packtypes += tools.object2string(row["PackType"]) + ",";
                packtypes = packtypes.Remove(packtypes.Length - 1);
                DataTable AllowedSalesPacks = db.GetDataTable(string.Format(@"
                        select * from SalesPack
                        where (ItemID = {0}) and (PackType in ({1}))
                        ", ItemID, packtypes));

                // copy salespacks
                foreach (DataRow AllowedSalesPack in AllowedSalesPacks.Rows)
                {
                    db.ExecuteNonQuery(string.Format(@"
                        insert into InactiveSalesPack
                          (ItemID,PackType,ReceiptText,ManualPrice,SalesPrice,BCType,Barcode,UpdateShelfLabel,
                          NoOfShLabels,SalesPackType,EnhedsIndhold,IsPrimary,SemiDeleted,ChainBarcode,
                          ChainItemID,ChainPackType,UpdateRSM,UnitPriceNotShown,UpdateStations)
                        select
                          {0} as ItemID,PackType,ReceiptText,ManualPrice,SalesPrice,BCType,Barcode,UpdateShelfLabel,
                          NoOfShLabels,SalesPackType,EnhedsIndhold,IsPrimary,SemiDeleted,NULL,
                          NULL,NULL,UpdateRSM,UnitPriceNotShown,UpdateStations
                        from SalesPack
                        where (ItemID = {1}) and (PackType = {2})
                        ",
                         InactiveItemID,
                         AllowedSalesPack["ItemID"],
                         AllowedSalesPack["PackType"]));
                }

                // copy barcodes
                foreach (DataRow AllowedBarcode in AllowedBarcodes)
                {
                    db.ExecuteNonQuery(string.Format(@"
                        insert into InactiveBarcode
                          (ItemID,PackType,Barcode,BCType,IsPrimary,SemiDeleted)
                        select
                          {0} as ItemID,PackType,Barcode,BCType,IsPrimary,SemiDeleted
                        from Barcode
                        where (ItemID = {1}) and (PackType = {2}) and (Barcode = {3})
                    ",
                     InactiveItemID,
                     AllowedBarcode["ItemID"],
                     AllowedBarcode["PackType"],
                     AllowedBarcode["Barcode"]));
                }

                /// Build list of allowed SupplierItems
                /// SupplierItems must belong to the item and
                /// the combination of the SupplierNo and OrderingNumber
                /// must be unique in the inactive table.
                List<DataRow> AllowedSupplierItems = new List<DataRow>();
                DataTable supplieritems = db.GetDataTable(string.Format(
                    " select * from SupplierItem where ItemID = {0} ", ItemID));
                foreach (DataRow row in supplieritems.Rows)
                {
                    int SupplierNo = tools.object2int(row["SupplierNo"]);
                    double OrderingNumber = tools.object2double(row["OrderingNumber"]);
                    bool AlreadyExists = (tools.object2int(db.ExecuteScalar(string.Format(@"
                        select count(*) from InactiveSupplierItem
                        where (SupplierNo = {0}) and (OrderingNumber = {1})
                        ", SupplierNo, OrderingNumber))) > 0);
                    if (!AlreadyExists)
                        AllowedSupplierItems.Add(row);
                }

                // copy SupplierItems
                foreach (DataRow row in AllowedSupplierItems)
                {
                    db.ExecuteNonQuery(string.Format(@"
                        insert into InactiveSupplierItem
                            (ItemID,SupplierNo,OrderingNumber,KolliSize,PackageCost,PackageUnitCost,
                            IsPrimary,SellingPackType,NoOfSellingUnits,SellingUnitCost)
                        select
                            {0} as ItemID,SupplierNo,OrderingNumber,KolliSize,PackageCost,PackageUnitCost,
                            IsPrimary,SellingPackType,NoOfSellingUnits,SellingUnitCost
                            from SupplierItem
                        where (ID = {1})
                        ", InactiveItemID, row["ID"]));
                }

            } // if allowed to copy
        }
        #endregion

        #region CopyInactiveItemToItems
        /// <summary>
        /// Attempts to copy the inactive item along with salespacks, barcodes and supplieritems
        /// to the active tables. If creation can be done, the itemform is show in editmode, for
        /// user to accept or reject. If accepted, the inactive records are deleted. If rejected,
        /// the just created active records are deleted. The itemform is shown modal.
        /// True is returned if the records was copied, false otherwise.
        /// </summary>
        public static bool CopyInactiveItemToItems(int InactiveItemID)
        {
            db.StartTransaction();

            try
            {
                /// select all inactive barcodes that belongs to this item and
                /// which does not exist in the Barcode table
                DataTable AllowedBarcodes = db.GetDataTable(string.Format(@"
                    select * from InactiveBarcode
                    where (ItemID = {0})
                    and (Barcode not in (select Barcode from Barcode))
                    ", InactiveItemID));

                // at least one barcode needs to be valid to copy
                if (AllowedBarcodes.Rows.Count > 0)
                {
                    // ask user if copy is ok
                    string msg = db.GetLangString("ItemDataSet.CopyInactiveItem.Create");
                    if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        db.RollbackTransaction();
                        return false;
                    }

                    // make sure the itemname is unique
                    DataRow AllowedItem = db.GetDataRow(string.Format(
                        " select * from InactiveItem where ItemID = {0} ", InactiveItemID));
                    string UniqueItemName = tools.object2string(AllowedItem["ItemName"]);
                    UniqueItemName = ItemDataTable.GetUniqueItemName(UniqueItemName);

                    // copy item
                    db.ExecuteNonQuery(string.Format(@"
                        insert into Item
                            (ItemName,ItemType,SubCategory,SuggSalesPrice,PriceRegulation,
                            POSSalesPrice,CostPriceLatest,Margin,BudgetMargin,Supplier,InStock,
                            MinimumStock,LastChangeDateTime,LastSalesDate,LastPurchDate,LastInventDate,FocusItem,
                            ExternalID,VatRate,VatOwner,CreditCategory,InheritCreditCat,AgeRestriction,
                            InheritAgeRestric,MOPRestriction,InheritMOPRestr,SemiDeleted,
                            ItemTypeCode,InheritItemTypeCode,FastPrisVare,IkkeBeholdningsVare,UdmeldtPrDato,
                            InactivateDateTime,KampagneID,FSD_ID)
                        select
                            {1},ItemType,SubCategory,SuggSalesPrice,PriceRegulation,
                            POSSalesPrice,CostPriceLatest,Margin,BudgetMargin,Supplier,InStock,
                            MinimumStock,LastChangeDateTime,LastSalesDate,LastPurchDate,LastInventDate,FocusItem,
                            ExternalID,VatRate,VatOwner,CreditCategory,InheritCreditCat,AgeRestriction,
                            InheritAgeRestric,MOPRestriction,InheritMOPRestr,SemiDeleted,
                            ItemTypeCode,InheritItemTypeCode,FastPrisVare,IkkeBeholdningsVare,UdmeldtPrDato,
                            NULL,KampagneID,FSD_ID
                        from InactiveItem
                        where ItemID = {0}
                        ", InactiveItemID, tools.string4sql(UniqueItemName, 50)));

                    // retrieve generated itemid
                    int NewItemID = ItemDataTable.GetNewestItemID();

#if FSD
                    // if FSD version, overwrite FSD_ID with next FSD_ID
                    ItemDataTable.AssignNextFSD_ID(NewItemID);
#endif

                    // copy salespacks
                    // by selecting inactive salespacks that belongs to this item
                    // and that does not have barcodes that exist in the Barcode table.
                    db.ExecuteNonQuery(string.Format(@"
                        insert into SalesPack
                            (ItemID,PackType,ReceiptText,ManualPrice,SalesPrice,BCType,Barcode,UpdateShelfLabel,
                            NoOfShLabels,SalesPackType,EnhedsIndhold,IsPrimary,SemiDeleted,ChainBarcode,
                            ChainItemID,ChainPackType,UpdateRSM,UnitPriceNotShown,UpdateStations)
                        select distinct
                            {1},isp.PackType,isp.ReceiptText,isp.ManualPrice,isp.SalesPrice,isp.BCType,isp.Barcode,isp.UpdateShelfLabel,
                            isp.NoOfShLabels,isp.SalesPackType,isp.EnhedsIndhold,isp.IsPrimary,isp.SemiDeleted,isp.ChainBarcode,
                            isp.ChainItemID,isp.ChainPackType,isp.UpdateRSM,isp.UnitPriceNotShown,isp.UpdateStations
                        from (InactiveSalesPack isp
                        inner join InactiveBarcode ib
                            on isp.ItemID = ib.ItemID
                            and isp.PackType = ib.PackType)
                        where (isp.ItemID = {0})
                        and (ib.Barcode not in (select Barcode from Barcode))
                        ", InactiveItemID, NewItemID));

                    /// copy barcodes
                    /// by selecting barcodes that belongs to this item
                    /// and that does not have barcodes that exist in the Barcodes table.
                    db.ExecuteNonQuery(string.Format(@"
                        insert into Barcode
                            (ItemID,PackType,Barcode,BCType,IsPrimary,SemiDeleted)
                        select distinct
                            {1} as ItemID,PackType,Barcode,BCType,IsPrimary,SemiDeleted
                        from InactiveBarcode
                        where (ItemID = {0}) and (Barcode not in (select Barcode from Barcode))
                        ", InactiveItemID, NewItemID));

                    /// copy supplieritems
                    /// by selecting inactive supplier items that belongs to this item
                    /// and that does not have supplierno,orderingnumber combination
                    /// that exist in the SupplierItem table.
                    db.ExecuteNonQuery(string.Format(@"
                        insert into SupplierItem
                            (ItemID,SupplierNo,OrderingNumber,KolliSize,PackageCost,PackageUnitCost,
                            IsPrimary,SellingPackType,NoOfSellingUnits,SellingUnitCost)
                        select distinct
                            {1} as ItemID,SupplierNo,OrderingNumber,KolliSize,PackageCost,PackageUnitCost,
                            IsPrimary,SellingPackType,NoOfSellingUnits,SellingUnitCost
                            from InactiveSupplierItem isi
                            where (ItemID = {0})
                            and not exists
                            (
                                select si.SupplierNo,si.OrderingNumber
                                from SupplierItem si
                                where isi.SupplierNo = si.SupplierNo
                                and isi.OrderingNumber = si.OrderingNumber
                            )
                        ", InactiveItemID, NewItemID));

                    // check if there is a primary salespack,
                    bool HasPrimarySalesPack = (tools.object2int(db.ExecuteScalar(string.Format(@"
                        select count(*) from SalesPack
                        where (ItemID = {0}) and (IsPrimary = 1)
                        ", NewItemID))) > 0);

                    // check if there is a primary supplieritem
                    bool HasPrimarySupplierItem = (tools.object2int(db.ExecuteScalar(string.Format(@"
                        select count(*) from SupplierItem
                        where (ItemID = {0}) and (IsPrimary = 1)
                        ", NewItemID))) > 0);

                    // if missing a primary salespack or primary supplieritem
                    // we need to select new primary records and copy some values to item
                    if (!HasPrimarySalesPack || !HasPrimarySupplierItem)
                    {
                        // if no primary salespack exists,
                        // set the first to be primary
                        if (!HasPrimarySalesPack)
                        {
                            db.ExecuteNonQuery(string.Format(@"
                                update SalesPack set IsPrimary = 1
                                where (ItemID = {0})
                                and PackType in
                                (
                                    select top 1 PackType
                                    from SalesPack
                                    where (ItemID = {0})
                                    order by PackType
                                )
                                ", NewItemID));
                        }

                        // if no primary supplieritem exists,
                        // set the first to be primary (if there is any)
                        if (!HasPrimarySupplierItem)
                        {
                            db.ExecuteNonQuery(string.Format(@"
                                update SupplierItem set IsPrimary = 1
                                where ID in
                                (
                                    select top 1 ID
                                    from SupplierItem
                                    where (ItemID = {0})
                                    order by ID
                                )
                            ", NewItemID));
                        }

                        // get primary salespack
                        DataRow rowPrimarySalesPack = db.GetDataRow(string.Format(@"
                            select * from SalesPack
                            where (ItemID = {0})
                            and (IsPrimary = 1)
                            ", NewItemID));

                        // get salesprice from primary salespack
                        double SalesPrice = tools.object2double(rowPrimarySalesPack["SalesPrice"]);

                        // get primary supplieritem
                        DataRow rowPrimarySupplierItem = db.GetDataRow(string.Format(@"
                            select * from SupplierItem
                            where (ItemID = {0})
                            and (IsPrimary = 1)
                            ", NewItemID));

                        /// get costprice from primary supplier item.
                        /// if no primary supplier item exist, calculate
                        /// costprice from budgetmargin and salesprice.
                        double CostPrice;
                        if (rowPrimarySupplierItem != null)
                            CostPrice = tools.object2double(rowPrimarySupplierItem["PackageUnitCost"]);
                        else
                        {
                            double BudgetMargin = tools.object2double(db.ExecuteScalar(string.Format(
                                " select BudgetMargin from Item where ItemID = {0} ", NewItemID)));
                            CostPrice = tools.CalcCostPrice(BudgetMargin, SalesPrice);
                        }

                        // copy some values from the primary records to the item
                        double Margin = tools.CalcMargin(SalesPrice, CostPrice);
                        db.ExecuteNonQuery(string.Format(@"
                            update Item set
                            POSSalesPrice = {1},
                            CostPriceLatest = {2},
                            Margin = {3}
                            where ItemID = {0}
                            ", NewItemID, tools.decimalnumber4sql(SalesPrice), tools.decimalnumber4sql(CostPrice), tools.decimalnumber4sql(Margin)));
                    }

                    /// check that each salespack's barcodes has a primary barcode,
                    /// and if not, set a primary barcode
                    DataTable SalesPacks = db.GetDataTable(string.Format(@"
                        select * from SalesPack
                        where ItemID = {0}
                        ", NewItemID));
                    foreach (DataRow row in SalesPacks.Rows)
                    {
                        int PackType = tools.object2byte(row["PackType"]);

                        bool HasPrimaryBarcode = (tools.object2int(db.ExecuteScalar(string.Format(@"
                            select count(*) from Barcode
                            where (ItemID = {0})
                            and (PackType = {1})
                            and (IsPrimary = 1)
                            ", NewItemID, PackType))) > 0);
                        if (!HasPrimaryBarcode)
                        {
                            // get the barcode that will be set to primary (the first barcode record)
                            DataRow rowPrimaryBarcode = db.GetDataRow(string.Format(@"
                                select * from Barcode
                                where (ItemID = {0})
                                and (PackType = {1})
                                ", NewItemID, PackType));

                            int BCType = tools.object2int(rowPrimaryBarcode["BCType"]);
                            double Barcode = tools.object2double(rowPrimaryBarcode["Barcode"]);

                            // set the selected barcode to primary
                            db.ExecuteNonQuery(string.Format(@"
                                update Barcode b1 set IsPrimary = 1
                                where (ItemID = {0})
                                and (PackType = {1})
                                and (Barcode = {2})
                                ", NewItemID, PackType, Barcode));

                            // copy some values from the new primary barcode to the salespack
                            db.ExecuteNonQuery(string.Format(@"
                                update SalesPack set
                                BCType = {2},
                                Barcode = {3}
                                where (ItemID = {0})
                                and (PackType = {1})
                                ", NewItemID, PackType, BCType, Barcode));
                        }
                    }

                    // update some other things on Item
                    db.ExecuteNonQuery(string.Format(@"
                        update Item set
                        LastChangeDateTime = '{1}'
                        where (ItemID = {0})
                        ", NewItemID, DateTime.Now));

                    // update some other things on SalesPack
                    db.ExecuteNonQuery(string.Format(@"
                        update SalesPack set
                        UpdateRSM = 1,
                        UpdateStations = 1,
                        UpdateShelfLabel = 1                        
                        where (ItemID = {0})
                        ", NewItemID));

                    // make sure we have the needed LookupKolliSize records
                    DataTable SupplierItems = db.GetDataTable(string.Format(@"
                        select distinct KolliSize from SupplierItem
                        where ItemID = {0}
                        ", NewItemID));
                    foreach (DataRow row in SupplierItems.Rows)
                    {
                        int KolliSize = tools.object2int(row["KolliSize"]);
                        LookupKolliSizeAdminDataTable.CreateUserDefinedKolliSizeIfNonExisting(KolliSize);
                    }

                    // we commit now as the item form is by
                    // no way set up to handle transactions.
                    db.CommitTransaction();

                    // user is presented with itemform in editmode
                    ItemForm itemform = new ItemForm();
                    if (itemform.EditSingleItem(NewItemID) == DialogResult.OK)
                    {
                        // user accepts - delete from inactive tables
                        DeleteInactiveItemAndChilds(InactiveItemID);

                        // copy successful
                        return true;
                    }
                    else
                    {
                        // user cancels - delete from active tables
                        DeleteActiveItemAndChilds(NewItemID);

                        // copy cancelled
                        return false;
                    }
                }
                else
                {
                    string msg = "";

                    /// if the item was semideleted and not yet
                    /// sent to pos, the records will still exist
                    /// in the active tables. detect this and inform user.
                    DataTable SemiDeleletedBarcodes = db.GetDataTable(string.Format(@"
                        select * from InactiveBarcode
                        where (ItemID = {0})
                        and (Barcode in (select Barcode from Barcode where SemiDeleted = 1))
                        ", InactiveItemID));
                    if (SemiDeleletedBarcodes.Rows.Count > 0)
                    {
                        msg = db.GetLangString("ItemDataSet.CopyInactiveItem.StillSemiDeleted");
                    }
                    else
                    {
                        /// otherwise the records have simply been created in the active tables
                        /// after the inactivation was done, so in that case a copy is not possible.
                        msg = db.GetLangString("ItemDataSet.CopyInactiveItem.BarcodeAlreadyExists");
                    }

                    MessageBox.Show(msg);
                    db.RollbackTransaction();
                    return false;
                }
            }
            catch (Exception ex)
            {
                string msg = log.WriteException("CopyInactiveItemToItems", ex.Message, ex.StackTrace);
                MessageBox.Show(msg);
                db.RollbackTransaction();
                return false;
            }
        }
        #endregion

        #region XVDDataFoundInInactiveItems
        /// <summary>
        /// Checks if LVD or FVD item is found in inactive items.
        /// </summary>
        public static bool XVDDataFoundInInactiveItems(double EANNR, double VARENR, int LEVERANDOER)
        {
            bool FoundInactiveBarcode = InactiveBarcodeDataTable.InactiveBarcodeExists(EANNR);
            DataRow FoundInactiveSupplierItemRow = InactiveSupplierItemDataTable.GetInactiveSupplierItem(VARENR, LEVERANDOER);
            return (FoundInactiveBarcode || (FoundInactiveSupplierItemRow != null));
        }
        #endregion

        #region UpdateXVDDataInInactiveItems
        /// <summary>
        /// Updates LVD or FVD item i inactive items.
        /// True is returned if the item was found in the inactive
        /// tables and thus updated. False is returned if not found.
        /// </summary>
        public static bool UpdateXVDDataInInactiveItems(
            double EANNR,       // barcode
            double VARENR,         // orderingnumber
            int LEVERANDOER,    // supplierno
            double ENHPRIS,     // costprice
            double SalesPrice,
            int STKENH,          // kolli
            int KampagneID,
            int FSD_ID,
            int PackType
            )
        {
            // check if inactive item can be found via inactive barcode
            bool FoundInactiveBarcode = InactiveBarcodeDataTable.InactiveBarcodeExists(EANNR);

            // check if inactive item can be found via inactive supplier item
            DataRow FoundInactiveSupplierItemRow = InactiveSupplierItemDataTable.GetInactiveSupplierItem(VARENR, LEVERANDOER);
            bool FoundInactiveSupplierItem = (FoundInactiveSupplierItemRow != null);

            // get inactive item record
            DataRow InactiveItemRow = null;
            if (FoundInactiveBarcode)
                InactiveItemRow = InactiveItemDataTable.GetInactiveItemFromBarcode(EANNR);
            else if (VARENR != 0)
                InactiveItemRow = InactiveItemDataTable.GetInactiveItemFromSupplierItem(LEVERANDOER, VARENR);

            // if found inactive item, continue updating
            if (InactiveItemRow != null)
            {
                // get values from inactive item record
                int InactiveItemID = tools.object2int(InactiveItemRow["ItemID"]);
                double CostPriceLatest = tools.object2double(InactiveItemRow["CostPriceLatest"]);

                // get primary salespack record and retreive values from the record
                DataRow PrimaryInactiveSalesPack = InactiveSalesPackDataTable.GetPrimaryInactiveSalesPack(InactiveItemID);
                byte PrimaryPackType = tools.object2byte(PrimaryInactiveSalesPack["PackType"]);

                // we track any changes done
                bool Changed = false;

                // detect new barcode
                if ((EANNR != 0) &&
                    !FoundInactiveBarcode &&
                    FoundInactiveSupplierItem &&
                    (PrimaryInactiveSalesPack != null))
                {
                    // add new barcode to the primary salespack
                    InactiveBarcodeDataTable.AddInactiveBarcode(InactiveItemID, PrimaryPackType, EANNR);
                    Changed = true;
                }

                // detect new salesprice
                double dbSalesPrice = tools.object2double(PrimaryInactiveSalesPack["SalesPrice"]);
                if ((SalesPrice != 0) &&
                    (FoundInactiveBarcode || FoundInactiveSupplierItem) &&
                    (Math.Round(dbSalesPrice, 2) != Math.Round(SalesPrice, 2)))
                {
                    // update salesprice on primary salespack
                    InactiveSalesPackDataTable.UpdateSalesPrice(InactiveItemID, PrimaryPackType, SalesPrice);
                    Changed = true;
                }

                // detect new costprice
                if (FoundInactiveSupplierItemRow != null)
                {
                    double dbCostPrice = tools.object2double(FoundInactiveSupplierItemRow["PackageUnitCost"]);
                    if (FoundInactiveSupplierItem &&
                        (Math.Round(dbCostPrice, 3) != Math.Round(ENHPRIS, 3)))
                    {
                        // update costprice on inactive supplieritem
                        InactiveSupplierItemDataTable.UpdateCostPrice(ENHPRIS, LEVERANDOER, VARENR);
                        Changed = true;
                    }
                }

                // detect new supplieritem
                if (FoundInactiveBarcode && !FoundInactiveSupplierItem)
                {
                    // add new inactive supplier item
                    InactiveSupplierItemDataTable.AddInactiveSupplierItem(
                        InactiveItemID,
                        LEVERANDOER,
                        VARENR,
                        ENHPRIS,
                        STKENH);
                    Changed = true;
                }

                // detect different kampagneid
                int dbKampangeID = tools.object2int(InactiveItemRow["KampagneID"]);
                if (dbKampangeID != KampagneID)
                {
                    InactiveItemDataTable.SetKampagneID_and_FSD_ID(InactiveItemID, KampagneID, FSD_ID);
                    Changed = true;
                }

                // if a change has been done, mark it
                if (Changed)
                    InactiveItemDataTable.SetLastChangeDateTime(InactiveItemID, DateTime.Now);

                // report found
                return true;
            }
            else
            {
                // inactive item not found, report not found
                return false;
            }
        }
        #endregion

        #region DeleteXVDDataInInactiveItems
        /// <summary>
        /// Deletes LVD or FVD item i inactive items (if found).
        /// </summary>
        public static bool DeleteXVDDataInInactiveItems(double EANNR, double VARENR, int LEVERANDOER)
        {
            // check if inactive item can be found via inactive barcode
            bool FoundInactiveBarcode = InactiveBarcodeDataTable.InactiveBarcodeExists(EANNR);

            // check if inactive item can be found via inactive supplier item
            DataRow FoundInactiveSupplierItemRow = InactiveSupplierItemDataTable.GetInactiveSupplierItem(VARENR, LEVERANDOER);

            // get inactive item record
            DataRow InactiveItemRow;
            if (FoundInactiveBarcode)
                InactiveItemRow = InactiveItemDataTable.GetInactiveItemFromBarcode(EANNR);
            else
                InactiveItemRow = InactiveItemDataTable.GetInactiveItemFromSupplierItem(LEVERANDOER, VARENR);

            // if inactive item found, we can delete from the inactive tables
            if (InactiveItemRow != null)
            {
                // if found inactive supplier item, delete it
                if (FoundInactiveSupplierItemRow != null)
                {
                    int SupplierNo = tools.object2int(FoundInactiveSupplierItemRow["SupplierNo"]);
                    double OrderingNumber = tools.object2int(FoundInactiveSupplierItemRow["OrderingNumber"]);
                    InactiveSupplierItemDataTable.DeleteInactiveSupplierItem(OrderingNumber, SupplierNo);
                }
                // if no more supplieritems exist on the item, delete it
                int ItemID = tools.object2int(InactiveItemRow["ItemID"]);
                if (InactiveSupplierItemDataTable.NumSupplierItemsOnItem(ItemID) <= 0)
                {
                    InactiveItemDataTable.DeleteInactiveItem(ItemID);
                    InactiveSalesPackDataTable.DeleteInactiveSalesPacks(ItemID);
                    InactiveBarcodeDataTable.DeleteInactiveBarcodes(ItemID);
                }
                else
                {
                    // if primary supplier item has been removed, set the first and best found to primary
                    InactiveSupplierItemDataTable.SetFirstAndBestToPrimaryIfPrimaryIsMissing(ItemID);

                    InactiveItemDataTable.SetLastChangeDateTime(ItemID, DateTime.Now);
                }

                // found and deleted
                return true;
            }
            else
            {
                // not found and nothing deleted
                return false;
            }
        }
        #endregion

        #region DeleteXVDDataInInactiveItemsCompletely
        /// <summary>
        /// Deletes LVD or FVD item i inactive items (if found).
        /// This version of the function deletes the item no matter how many supplier item records it has.
        /// </summary>
        public static bool DeleteXVDDataInInactiveItemsCompletely(double EANNR, double VARENR, int LEVERANDOER)
        {
            // check if inactive item can be found via inactive barcode
            bool FoundInactiveBarcode = InactiveBarcodeDataTable.InactiveBarcodeExists(EANNR);

            // check if inactive item can be found via inactive supplier item
            DataRow FoundInactiveSupplierItemRow = InactiveSupplierItemDataTable.GetInactiveSupplierItem(VARENR, LEVERANDOER);

            // get inactive item record
            DataRow InactiveItemRow;
            if (FoundInactiveBarcode)
                InactiveItemRow = InactiveItemDataTable.GetInactiveItemFromBarcode(EANNR);
            else
                InactiveItemRow = InactiveItemDataTable.GetInactiveItemFromSupplierItem(LEVERANDOER, VARENR);

            // if inactive item found, we can delete from the inactive tables
            if (InactiveItemRow != null)
            {
                int ItemID = tools.object2int(InactiveItemRow["ItemID"]);
                InactiveItemDataTable.DeleteInactiveItem(ItemID);
                InactiveSalesPackDataTable.DeleteInactiveSalesPacks(ItemID);
                InactiveBarcodeDataTable.DeleteInactiveBarcodes(ItemID);
                InactiveSupplierItemDataTable.DeleteInactiveSupplierItems(ItemID);

                // found and deleted
                return true;
            }
            else
            {
                // not found and nothing deleted
                return false;
            }
        }
        #endregion

        #endregion
    }
}
