using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class OrderDraftForm : Form
    {
        #region Constructor
        public OrderDraftForm()
        {
            InitializeComponent();

            // position grid columns (bug in VS2005)
            colDraftName.DisplayIndex = 0;
            colSupplierID.DisplayIndex = 1;
            colSupplierName.DisplayIndex = 2;

            // load data
            adapterDraft.Connection = db.Connection;
            adapterDraft.Fill(dsItem.OrderDraft);
        }
        #endregion

        #region METHOD: EditDraft
        /// <summary>
        /// Opens the OrderDraftDetails form with
        /// data for the selected draft.
        /// </summary>
        private void EditDraft()
        {
            // open draft details
            if (bindingDraft.Current == null) return;
            DataRowView row = (DataRowView)bindingDraft.Current;
            int DraftID = tools.object2int(row["DraftID"]);
            OrderDraftDetailsForm details = new OrderDraftDetailsForm(DraftID);
            if (details.ShowDialog(this) == DialogResult.OK)
            {
                // save position of current draft in the grid
                int index = bindingDraft.Find("DraftID", DraftID);

                // reflect changes made to OrderDraft in OrderDraftDetails form (if any)
                adapterDraft.Fill(dsItem.OrderDraft);

                // position on the draft in the grid
                if ((index >= 0) && (index < bindingDraft.Count))
                    bindingDraft.Position = index;
            }
        }
        #endregion

        #region METHOD: DeleteDraft
        /// <summary>
        /// Deletes the selected draft and its details.
        /// </summary>
        private void DeleteDraft()
        {
            if (bindingDraft.Current == null) return;
            if (gridDraft.CurrentRow == null) return;
            DataRowView row = (DataRowView)bindingDraft.Current;

            // prompt user if delete is what is wanted
            string msg = db.GetLangString("OrderDraftForm.DoYouWantToDeleteMsg");
            if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // get selected row index in the binder,
                // so we can position on the next row after delete
                int index = bindingDraft.Position;

                // get draft id from selected draft
                long DraftID = tools.object2long(row["DraftID"]);

                // delete the draft and its details
                dsItem.OrderDraft.DeleteDraftAndItsDetails(DraftID);

                // reload draft data to reflect the delete in gui
                adapterDraft.Fill(dsItem.OrderDraft);

                // attempt to select the record that now has
                // the position the deleted record had, or if
                // the last record was deleted, thus the index is
                // too high now, position on the last record
                if (index >= bindingDraft.Count)
                    bindingDraft.Position = bindingDraft.Count - 1;
                else if ((index < bindingDraft.Count) && (index >= 0))
                    bindingDraft.Position = index;
            }
        }
        #endregion

        #region METHOD: NewDraft
        /// <summary>
        /// Creates a new empty order draft and
        /// focuses the new draft in the order draft grid
        /// and opens the order draft detail window for this draft.
        /// </summary>
        private void NewDraft()
        {
            // create the new order draft record
            int DraftID = dsItem.OrderDraft.CreateNewOrderDraft();

            // reload the order draft data, so the new record is reflected in gui
            adapterDraft.Fill(dsItem.OrderDraft);

            // position on the new draft in the grid
            int index = bindingDraft.Find("DraftID", DraftID);
            if ((index >= 0) && (index < bindingDraft.Count))
                bindingDraft.Position = index;

            // open the order draft detail window
            OrderDraftDetailsForm details = new OrderDraftDetailsForm(DraftID);
            if (details.ShowDialog(this) == DialogResult.OK)
            {
                // reflect changes made to OrderDraft in OrderDraftDetails form (if any)
                adapterDraft.Fill(dsItem.OrderDraft);

                // after loading data, re-position on the new draft in the grid
                if ((index >= 0) && (index < bindingDraft.Count))
                    bindingDraft.Position = index;
            }
            else
            {
                // user cancelled creation of new draft, so delete the draft
                dsItem.OrderDraft.DeleteDraftAndItsDetails(DraftID);
                adapterDraft.Fill(dsItem.OrderDraft);
            }
        }
        
        #endregion

        // grid mouse double click event
        private void gridDraft_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditDraft();
        }

        // details button click event
        private void btnDetails_Click(object sender, EventArgs e)
        {
            EditDraft();
        }

        // new draft button click event
        private void btnNew_Click(object sender, EventArgs e)
        {
            NewDraft();
        }

        // delete draft button click event
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteDraft();
        }

        // grid user deleting row event
        private void gridDraft_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DeleteDraft();
            e.Cancel = true; // let DeleteDraft do the delete
        }

        // close button click event
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // grid key down event
        private void gridDraft_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EditDraft();
                e.Handled = true;
            }
        }

        private void OrderDraftForm_Load(object sender, EventArgs e)
        {

            colDraftName.HeaderText = db.GetLangString("OrderDraftForm.DraftNameLabel");
            colSupplierID.HeaderText = db.GetLangString("OrderDraftForm.SupplIDLabel");
            colSupplierName.HeaderText = db.GetLangString("OrderDraftForm.SupplNameLabel");
            btnClose.Text = db.GetLangString("Application.Close");
            btnDetails.Text = db.GetLangString("OrderDraftForm.DetailsBtn");
            btnDelete.Text = db.GetLangString("Application.Delete");
            btnNew.Text = db.GetLangString("OrderDraftForm.NewDraft");

        }
    }
}