using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class OrderHeaderForm : Form
    {
        #region Constructor
        public OrderHeaderForm()
        {
            InitializeComponent();

            // position grid columns (bug in VS2005)
            colOrderID.DisplayIndex = 0;
            colSupplierID.DisplayIndex = 1;
            colSupplierName.DisplayIndex = 2;
            colOrderDate.DisplayIndex = 3;
            colDeliveryDate.DisplayIndex = 4;
            colSentDate.DisplayIndex = 5;
            colNumberDetails.DisplayIndex = 6;
            colTotalCost.DisplayIndex = 7;
            colOrderStatus.DisplayIndex = 8;
            colStatusColor.DisplayIndex = 9;

            // load data
            adapterOrderHeader.Connection = db.Connection;
            adapterOrderHeader.Fill(dsItem.OrderHeader);
            lookupSupplierTableAdapter.Connection = db.Connection;
            lookupSupplierTableAdapter.Fill(dsItem.LookupSupplier);
            lookupStatusTableAdapter.Connection = db.Connection;
            lookupStatusTableAdapter.Fill(dsItem.LookupStatus);
        }
        #endregion

        #region METHOD: EditOrder
        /// <summary>
        /// Opens the OrderDetails form with
        /// data for the selected order.
        /// </summary>
        private void EditOrder()
        {
            // open order details
            if (bindingOrderHeader.Current == null) return;
            DataRowView row = (DataRowView)bindingOrderHeader.Current;
            int OrderID = tools.object2int(row["OrderID"]);
            OrderDetailsForm details = new OrderDetailsForm(OrderID);
            details.ShowDialog(this);

            // save position of current order in the grid
            int index = bindingOrderHeader.Find("OrderID", OrderID);

            // reflect changes made to OrderHeader in OrderDetails form (if any)
            adapterOrderHeader.Fill(dsItem.OrderHeader);

            // position on the order in the grid
            if ((index >= 0) && (index < bindingOrderHeader.Count))
                bindingOrderHeader.Position = index;
        }
        #endregion

        #region METHOD: DeleteOrder
        /// <summary>
        /// Deletes the selected order and its details.
        /// </summary>
        private void DeleteOrder()
        {
            if (bindingOrderHeader.Current == null) return;
            if (gridOrderHeader.CurrentRow == null) return;
            DataRowView row = (DataRowView)bindingOrderHeader.Current;

            // if status is not "OPN" or "BKD", delete is not allowed
            if (!row["OrderStatus"].Equals("OPN") && !row["OrderStatus"].Equals("BKD"))
            {
                MessageBox.Show(db.GetLangString("OrderHeaderForm.CannotDeleteOrder"));
                return;
            }

            // prompt user if delete is what is wanted
            string msg = db.GetLangString("OrderHeaderForm.DeleteOrder");
            if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // get selected row index in the binder,
                // so we can position on the next row after delete
                int index = bindingOrderHeader.Position;

                // get order id from selected order header
                long OrderID = tools.object2long(row["OrderID"]);

                // delete the order and its details
                dsItem.OrderHeader.DeleteOrderAndItsDetails(OrderID);

                // reload order header data to reflect the delete in gui
                adapterOrderHeader.Fill(dsItem.OrderHeader);

                // attempt to select the record that now has
                // the position the deleted record had, or if
                // the last record was deleted, thus the index is
                // too high now, position on the last record
                if (index >= bindingOrderHeader.Count)
                    bindingOrderHeader.Position = bindingOrderHeader.Count - 1;
                else if ((index < bindingOrderHeader.Count) && (index >= 0))
                    bindingOrderHeader.Position = index;
            }
        }
        #endregion

        #region METHOD: NewManualOrder
        /// <summary>
        /// Creates a new empty order header and opens
        /// focuses the new order in the order header grid
        /// and opens the order detail window for this order.
        /// </summary>
        private void NewManualOrder()
        {
            // before creating the order header,
            // ask user to selected a supplier
            SupplierPopup supplier = new SupplierPopup();
            supplier.Text = db.GetLangString("OrderHeaderForm.SelectSupplier");
            if(supplier.ShowDialog(this) == DialogResult.OK)
            {
                // create new order header
                int OrderID = dsItem.OrderHeader.CreateNewOrderHeader(supplier.SelectedSupplierID);

                // reload the order header data, so the new record is reflected in gui
                adapterOrderHeader.Fill(dsItem.OrderHeader);

                // position on the new order in the order header grid
                int index = bindingOrderHeader.Find("OrderID", OrderID);
                if ((index >= 0) && (index < bindingOrderHeader.Count))
                    bindingOrderHeader.Position = index;

                // open the order detail window
                OrderDetailsForm details = new OrderDetailsForm(OrderID);
                details.ShowDialog(this);

                // reflect changes made to OrderHeader in OrderDetails form (if any)
                adapterOrderHeader.Fill(dsItem.OrderHeader);

                // after loading data, re-position on the new order in the order header grid
                if ((index >= 0) && (index < bindingOrderHeader.Count))
                    bindingOrderHeader.Position = index;
            }
        }
        
        #endregion

        #region METHOD: NewTemplateOrder
        private void NewTemplateOrder()
        {
        }
        #endregion

        #region METHOD: PrintOrder
        private void PrintOrder()
        {
        }
        #endregion

        // grid mouse double click event
        private void gridOrderHeader_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditOrder();
        }

        // order details button click event
        private void btnDetails_Click(object sender, EventArgs e)
        {
            EditOrder();
        }

        // new order button click event
        private void btnNew_Click(object sender, EventArgs e)
        {
            NewManualOrder();
        }

        // delete order button click event
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteOrder();
        }

        // grid user deleting row event
        private void gridOrderHeader_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DeleteOrder();
            e.Cancel = true; // let DeleteOrder do the delete
        }

        // close button click event
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // form load event
        private void OrderHeaderForm_Load(object sender, EventArgs e)
        {
            colSupplierName.HeaderText = db.GetLangString("OrderForm.SupplNameLabel");
            colOrderStatus.HeaderText = db.GetLangString("OrderForm.StatusLabel");
            colSupplierID.HeaderText = db.GetLangString("OrderForm.SupplIDLabel");
            colDeliveryDate.HeaderText = db.GetLangString("OrderForm.DelivDateLabel");
            colOrderID.HeaderText = db.GetLangString("OrderForm.OrderIDLabel");
            colOrderDate.HeaderText = db.GetLangString("OrderForm.OrderDateLabel");
            colSentDate.HeaderText = db.GetLangString("OrderForm.SentDateLabel");
            colNumberDetails.HeaderText = db.GetLangString("OrderForm.NoOfDetailsLabel");
            colTotalCost.HeaderText = db.GetLangString("OrderForm.OrderCostLabel");

            btnClose.Text = db.GetLangString("Application.Close");
            btnDetails.Text = db.GetLangString("OrderForm.DetailsBtn");
            btnDelete.Text = db.GetLangString("Application.Delete");
            btnNew.Text = db.GetLangString("OrderForm.NewBtn");

        }

        // print button click event
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintOrder();
        }

        // grid cell painting event
        private void gridOrderHeader_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // paint status color cell
            tools.PaintStatusCell(
                gridOrderHeader,
                e.ColumnIndex,
                e.RowIndex,
                colOrderStatus.Index,
                colStatusColor.Index);
        }

        // grid key down event
        private void gridOrderHeader_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EditOrder();
                e.Handled = true;
            }
        }
    }
}