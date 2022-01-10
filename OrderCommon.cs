using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace RBOS
{
    /// <summary>
    /// Class that implements common code for the classes
    /// OrderDetailsForm and OrderDraftDetailsForm. This could
    /// have been accomplished by deriving the two classes from
    /// the same base class, but this gets rather complicated
    /// when dealing with GUI. This is an acceptable alternative.
    /// </summary>
    class OrderCommon
    {
        #region METHOD: CalculateCostTotal
        /// <summary>
        /// Calculates the total order cost by
        /// summing up all detail row's Cost values.
        /// </summary>
        /// <returns></returns>
        public static double CalculateCostTotal(DataTable TableDetails, BindingSource BindingDetails)
        {
            BindingDetails.EndEdit();
            double sum = 0;
            foreach (DataRow row in TableDetails.Rows)
            {
                if ((row.RowState != DataRowState.Deleted) &&
                    (row.RowState != DataRowState.Detached))
                    sum += tools.object2double(row["Cost"]);
            }
            return sum;
        }
        #endregion

        #region METHOD: InsertNewOrderingNumberAndLookups
        /// <summary>
        /// Inserts the given ordering number in the header field OrderingNumber.
        /// First the number is validated for a number of things.
        /// </summary>
        /// <returns>True if insert was successful, false if not.</returns>
        public static bool InsertNewOrderingNumberAndLookups(
            BindingSource bindingHeader,
            BindingSource bindingDetails,
            DataGridView gridDetails,
            double newOrderingNumber)
        {
            if (bindingHeader.Current == null) return false;
            if (bindingDetails.Current == null) return false;

            DataRowView headerRow = (DataRowView)bindingHeader.Current;
            DataRowView detailRow = (DataRowView)bindingDetails.Current;

            // Find the combination of this OrderingNumber and the header's
            // SupplierID in the table SupplierItem. With this combination
            // we can get that row's ID (refered to here as SupplierItemID).
            // This ID we assign to details's SuppItemID field along with
            // other needed SupplierItem data for the detail row.

            // getting the header's SupplierID and the just entered OrderingNumber
            int SupplierID = tools.object2int(headerRow["SupplierID"]);

            // variables needed more than once
            string sql = "";
            object o = null;
            OleDbCommand cmd = new OleDbCommand("", db.Connection);

            // check if there is a valid combination of SupplierNo and the new OrderingNumber
            // in the SupplierItem table. if so, continue to get values for the detail.
            sql = string.Format(
                " select * from SupplierItem " +
                " where (SupplierNo = {0}) and (OrderingNumber = {1}) ",
                SupplierID, (long)newOrderingNumber); // casting to long to avoid commas
            DataTable table = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, db.Connection);
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                // valid combination found
                DataRow supplierItemRow = table.Rows[0];

                // lookup ReceiptText
                string ReceiptText = "";
                cmd.CommandText = string.Format(
                    " select ReceiptText from SalesPack " +
                    " where (ItemID = {0}) and (PackType = 1) ",
                    supplierItemRow["ItemID"]);
                o = cmd.ExecuteScalar();
                if ((o != null) && (o != DBNull.Value))
                    ReceiptText = o.ToString();
                else
                {
                    // Seems like we cannot find a SalesPack row
                    // with this ItemID and PackType. This can be
                    // because user has created a SupplierItem with
                    // and has specified an IteMID and a PackType,
                    // but has not yet created that PackType on that Item.
                    // So to get a text on the order line, we use the
                    // primary SalesPack's ReceiptText instead.
                    cmd.CommandText = string.Format(
                        " select ReceiptText from SalesPack " +
                        " where (ItemID = {0}) and (IsPrimary = 1) ",
                        supplierItemRow["ItemID"]);
                    o = cmd.ExecuteScalar();
                    if ((o != null) && (o != DBNull.Value))
                        ReceiptText = o.ToString();
                }

                // calculate cost for this order line.
                // this is based on PackageCost * Quantity.
                // however, the quantity might not be present yet,
                // in which case the object2double below will return 0.
                double PackageCost = tools.object2double(supplierItemRow["PackageCost"]);
                double Cost = tools.object2double(detailRow["Quantity"]) * PackageCost;

                // insert data
                detailRow["OrderingNumber"] = newOrderingNumber; // some callers don't do this
                detailRow["SuppItemID"] = supplierItemRow["ID"];
                detailRow["KolliSize"] = supplierItemRow["KolliSize"];
                detailRow["PackageCost"] = PackageCost;
                detailRow["PackType"] = supplierItemRow["SellingPackType"];
                detailRow["ReceiptText"] = ReceiptText;
                detailRow["Cost"] = Cost;
                gridDetails.Refresh();

                // new ordring number successfully inserted
                return true;
            }
            else
            {
                MessageBox.Show(db.GetLangString("OrderCommon.OrderingNumberCombination"));
                return false;
            }
        }
        #endregion

        #region METHOD: DisplayNumberOfDetailRecords
        /// <summary>
        /// When adding new records in the grid, update number of rows
        /// </summary>
        public static void DisplayNumberOfDetailRecords(
            DataGridView grid,
            TextBox textbox)
        {
            int num = grid.Rows.Count;
            if (grid.AllowUserToAddRows)
                num -= 1;
            textbox.Text = num.ToString();
        }
        #endregion

        #region METHOD: OpenSupplierItemSearchForm
        /// <summary>
        /// Opens the supplier item search form with
        /// the header's SupplierID preselected.
        /// Returns true if a value was selected, false if not.
        /// </summary>
        public static bool OpenSupplierItemSearchForm(
            BindingSource bindingHeader,
            BindingSource bindingDetails,
            DRS.Extensions.DRS_DataGridView gridDetails,
            DataGridViewColumn colOrderingNumber,
            DataGridViewColumn colQuantity)
        {
            if (bindingHeader.Current == null) return false;
            if (bindingDetails.Current == null) return false;

            DataRowView headerRow = (DataRowView)bindingHeader.Current;
            DataRowView detailRow = (DataRowView)bindingDetails.Current;
            double oldOrderingNumber = tools.object2double(detailRow["OrderingNumber"]);

            // open the search form with preselected and locked supplier,
            // and try to select the orderingnumber.
            SupplierItemSearchForm searchForm = new SupplierItemSearchForm();
            searchForm.SelectedSupplierID = tools.object2int(headerRow["SupplierID"]);
            searchForm.LockSupplier = true;
            searchForm.SelectedOrderingNumber = oldOrderingNumber;
            if (searchForm.ShowDialog() == DialogResult.OK)
            {
                // user clicked select in search form, so update orderingnumber if new value
                double newOrderingNumber = searchForm.SelectedOrderingNumber;
                if (newOrderingNumber != oldOrderingNumber)
                {
                    OrderCommon.InsertNewOrderingNumberAndLookups(
                        bindingHeader,
                        bindingDetails,
                        gridDetails,
                        newOrderingNumber);
                }

                // user clicked Select in search form,
                // so move focus to quantity cell
                gridDetails.JumpToColumn(colQuantity);

                return true;
            }
            else
                return false;
        }
        #endregion

        #region METHOD: JumpToQuantityColumn
        /// <summary>
        /// Focuses the Quantity column of the grid's current row.
        /// </summary>
        public static void JumpToQuantityColumn(
            DataGridView gridDetails,
            int colOrderingNumberIndex,
            int colQuantityIndex)
        {
            try
            {
                if (gridDetails.CurrentCell == null) return;
                if (gridDetails.CurrentRow == null) return;
                if (gridDetails.CurrentCell.ColumnIndex == colOrderingNumberIndex)
                {
                    // we can't perform the jump when i edit-mode
                    if (gridDetails.CurrentCell.IsInEditMode)
                        gridDetails.EndEdit();

                    // perform the jump
                    gridDetails.CurrentCell =
                        gridDetails[colQuantityIndex, gridDetails.CurrentRow.Index];
                }
            }
            catch { }
        }
        #endregion
       

    }
}
