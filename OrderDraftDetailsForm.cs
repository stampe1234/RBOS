using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace RBOS
{
    public partial class OrderDraftDetailsForm : Form
    {
        #region Private variables

        // the current DraftID
        private int DraftID = -1;

        #endregion

        #region Constructor

        public OrderDraftDetailsForm(int DraftID)
        {
            InitializeComponent();

            // set connections
            adapterOrderDraftSingle.Connection = db.Connection;
            adapterRelDraftDetails.Connection = db.Connection;
            adapterLookupSupplier.Connection = db.Connection;
            adapterLookupStatus.Connection = db.Connection;
            adapterLookupPackSize.Connection = db.Connection;

            // load data
            this.DraftID = DraftID;
            adapterOrderDraftSingle.Fill(dsItem.OrderDraftSingle, DraftID);
            adapterRelDraftDetails.Fill(dsItem.OrderDraftDetails, DraftID);
            adapterLookupSupplier.Fill(dsItem.LookupSupplier);
            adapterLookupStatus.Fill(dsItem.LookupStatus);
            adapterLookupPackSize.Fill(dsItem.LookupPackSize);

            SetFormState();

            /// localization
            this.Text = db.GetLangString("OrderDraftDetailsForm.Title");
            
            // Note, shares column header texts with OrderDetails form
            // This since same build in columns and design
            colDescription.HeaderText = db.GetLangString("OrderDetailForm.DescriptionLabel");
            colPackType.HeaderText = db.GetLangString("OrderDetailForm.PackTypeLabel");
            colKolli.HeaderText = db.GetLangString("OrderDetailForm.KolliLabel");
            colKolliCost.HeaderText = db.GetLangString("OrderDetailForm.KolliCostLabel");
            colOrderingNumber.HeaderText = db.GetLangString("OrderDetailForm.OrderingNumberLabel");
            colCost.HeaderText = db.GetLangString("OrderDetailForm.LineCostLabel");
            colQuantity.HeaderText = db.GetLangString("OrderDetailForm.QuantityLabel");
            colReceivedQuantity.HeaderText = db.GetLangString("OrderDetailForm.ReceivedQuanLabel");
            // End of share

            lbDraftname.Text = db.GetLangString("OrderDraftDetailsForm.DraftNameLabel");
            lbSupplierName.Text = db.GetLangString("OrderDraftDetailsForm.SupplierLabel");
            lbTotalCost.Text = db.GetLangString("OrderDraftDetailsForm.TotalCostLabel");
            lbNumberOfDetails.Text = db.GetLangString("OrderDraftDetailsForm.NoOfDetailLinesLabel");
            btnCancel.Text = db.GetLangString("Application.Cancel");
            btnSaveAndClose.Text = db.GetLangString("Application.SaveClose");
            btnCreateOrder.Text = db.GetLangString("OrderDraftDetailsForm.CreateOrderLabel");
            

            // default dialog result is cancel
            this.DialogResult = DialogResult.Cancel;

            // position grid columns (bug in VS2005)
            int DisplayIndex = -1;
            colOrderingNumber.DisplayIndex = ++DisplayIndex;
            colOrderingNumberButton.DisplayIndex = ++DisplayIndex;
            colDescription.DisplayIndex = ++DisplayIndex;
            colKolli.DisplayIndex = ++DisplayIndex;
            colPackType.DisplayIndex = ++DisplayIndex;
            colKolliCost.DisplayIndex = ++DisplayIndex;
            colQuantity.DisplayIndex = ++DisplayIndex;
            colReceivedQuantity.DisplayIndex = ++DisplayIndex;
            colCost.DisplayIndex = ++DisplayIndex;
        }

        #endregion

        #region METHOD: SetFormState
        /// <summary>
        /// Sets various controls enabled, visible, colors etc.
        /// </summary>
        private void SetFormState()
        {
            if (bindingOrderDraftSingle.Current == null) return;
            DataRowView row = (DataRowView)bindingOrderDraftSingle.Current;

            // if supplier has been selected,
            // user is allowed to add detail rows
            if (row["SupplierID"] != DBNull.Value)
            {
                gridDraftDetails.Enabled = true;
                colOrderingNumber.DefaultCellStyle.BackColor = SystemColors.Window;
                colQuantity.DefaultCellStyle.BackColor = SystemColors.Window;
            }
            else
            {
                gridDraftDetails.Enabled = false;
                gridDraftDetails.DefaultCellStyle.BackColor = SystemColors.Control;
            }
        }
        #endregion

        #region METHOD: SaveData
        /// <summary>
        /// Saves the OrderDraft and OrderDraftDetails data.
        /// Performs various checks first. IsValidDraft is
        /// called before performing the save.
        /// </summary>
        /// <returns>True if save was ok. False otherwise.</returns>
        private bool SaveData()
        {
            // end edit
            bindingRelDraftDetails.EndEdit();//pn20190812
            bindingOrderDraftSingle.EndEdit();

            // validate values
            if (!IsValidDraft())
                return false;

            // save data
            adapterRelDraftDetails.Update(dsItem.OrderDraftDetails);
            adapterOrderDraftSingle.Update(dsItem.OrderDraftSingle);

            // save ok
            return true;
        }
        #endregion

        #region METHOD: IsValidDraft
        /// <summary>
        /// Validates if values needed to create a meaningful
        /// draft has been filled in. This includes values such
        /// as DraftName, SupplierID and that some detail records exists.
        /// Messages will be displayed to user, telling what is needed.
        /// </summary>
        /// <returns>True if needed values are filled in. False otherwise.</returns>
        private bool IsValidDraft()
        {
            if (bindingOrderDraftSingle.Current == null) return false;
            DataRowView headerRow = (DataRowView)bindingOrderDraftSingle.Current;

            // end edit
            bindingOrderDraftSingle.EndEdit();

            // check that DraftName has been filled in
            if (tools.object2string(headerRow["DraftName"]) == "")
            {
                string msg = db.GetLangString("OrderDraftDetailsForm.GiveDraftNameMsg");
                MessageBox.Show(msg);
                if (txtDraftName.CanFocus)
                    txtDraftName.Focus();
                return false;
            }

            // check that SupplierID has been filled in
            if (headerRow["SupplierID"] == DBNull.Value)
            {
                string msg = db.GetLangString("OrderDraftDetailsForm.SelectSupplierMsg");
                MessageBox.Show(msg);
                if (btnLookupSupplier.CanFocus)
                    btnLookupSupplier.Focus();
                return false;
            }

            // check that some detail records have been created.
            // only valid details can be created, so trust these.
            if (dsItem.OrderDraftDetails.NumberOfValidRecords() <= 0)
            {
                MessageBox.Show(db.GetLangString("OrderDraftDetailsForm.SpecifySomeLinesMsg"));
                return false;
            }

            // all ok
            return true;
        }
        #endregion
      
        #region METHOD: UpdateSupplierName
        /// <summary>
        /// Looks up the supplier name and writes
        /// it to txtSupplierName based on the value
        /// in the SupplierID field.
        /// </summary>
        private void UpdateSupplierName()
        {
            // lookup suppliername when supplierid changes
            txtSupplierName.Text = tools.LookupValue(
                bindingOrderDraftSingle,
                bindingLookupSupplier,
                "SupplierID",
                "SupplierID",
                "Description");
        }
        #endregion

        #region METHOD: CreateOrderFromTemplate
        private void CreateOrderFromTemplate()
        {
            // validate values
            if (!IsValidDraft())
                return;

            // usually we check the Current for null first, but in this  case,
            // the IsValidDraft method gives the user some
            // messages if something is wrong. so to avoid coding
            // duplicate messages, IsValidDraft is called first.

            if (bindingOrderDraftSingle.Current == null) return;
            if (bindingRelDraftDetails.Current == null) return;

            DataRowView rowHeader = (DataRowView)bindingOrderDraftSingle.Current;
            DataRowView rowDetail = (DataRowView)bindingRelDraftDetails.Current;
            OleDbCommand cmd = new OleDbCommand("", db.Connection);

            // end edit
            bindingRelDraftDetails.EndEdit();
            bindingOrderDraftSingle.EndEdit();
            
            // gather header values
            int SupplierID = tools.object2int(rowHeader["SupplierID"]);
            int NumberDetails = dsItem.OrderDraftDetails.NumberOfValidRecords();
            double TotalCost = OrderCommon.CalculateCostTotal(dsItem.OrderDraftDetails, bindingRelDraftDetails);

            // build and execute header sql
            cmd.CommandText = string.Format(
                " insert into OrderHeader " +
                " (SupplierID,OrderStatus,NumberDetails,TotalCost) " +
                " values ({0},{1},{2},{3}) ",
                SupplierID,
                "'OPN'",
                NumberDetails,
                  tools.decimalnumber4sql(TotalCost)  );
            cmd.ExecuteNonQuery();

            // retrieve the autogenerated OrderID
            int OrderID = ItemDataSet.OrderHeaderDataTable.RetrieveMaxOrderID();

            // iterate through the detail records
            foreach (DataRow detailRow in dsItem.OrderDraftDetails.Rows)
            {
                if ((detailRow.RowState != DataRowState.Deleted) &&
                    (detailRow.RowState != DataRowState.Detached))
                {
                    // calculate cost ex. vat
                    double OrderingNumber = tools.object2double(detailRow["OrderingNumber"]);
                    double VAT = ItemDataSet.LookupVatRateDataTable.GetVATPctBySupplierItem(SupplierID, OrderingNumber);
                    double Cost = tools.object2double(detailRow["Cost"]);
                    double CostExVAT = tools.DeductVAT(Cost, VAT);

                    // build and execute detail sql
                    cmd.CommandText = string.Format(
                        " insert into OrderDetails " +
                        " (OrderID,[LineNo],SuppItemID,OrderingNumber,KolliSize,PackageCost,PackType,ReceiptText,Cost,CostExVAT,Quantity) " +
                        " values ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}) ",
                        OrderID,
                        ItemDataSet.OrderDetailsDataTable.GenerateNextLineNo(OrderID),
                        detailRow["SuppItemID"],
                        "'" + detailRow["OrderingNumber"] + "'",
                        detailRow["KolliSize"],
                        tools.decimalnumber4sql(detailRow["PackageCost"]),
                        //detailRow["PackType"],pn20190819
                        '1',
                        tools.string4sql(detailRow["ReceiptText"], 30),
                        tools.decimalnumber4sql(detailRow["Cost"]),
                        tools.decimalnumber4sql(CostExVAT),
                        detailRow["Quantity"]);
                    cmd.ExecuteNonQuery();
                }
            }

            string msg = db.GetLangString("OrderDraftDetailsForm.OrderCreated");
            MessageBox.Show(msg);
        }
        #endregion

        // save and close button click event
        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        // cancel button click event
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // form load event
        private void OrderDraftDetailsForm_Load(object sender, EventArgs e)
        {
            // NOTE: Do NOT localize in this method. See constructor.

            // calculate and display total cost
            txtTotalCost.Text = OrderCommon.CalculateCostTotal(dsItem.OrderDraftDetails, bindingRelDraftDetails).ToString("N2");
        }

        // grid rows added event
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            OrderCommon.DisplayNumberOfDetailRecords(gridDraftDetails, txtNumberOfDetails);
        }

        // grid rows removed event
        private void gridOrderDraftDetails_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            OrderCommon.DisplayNumberOfDetailRecords(gridDraftDetails, txtNumberOfDetails);
            txtTotalCost.Text = OrderCommon.CalculateCostTotal(dsItem.OrderDraftDetails, bindingRelDraftDetails).ToString("N2");
        }

        // grid cell validating event
        private void gridOrderDraftDetails_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (gridDraftDetails.CurrentCell == null) return;
            if (e.ColumnIndex == colOrderingNumber.Index)
            {
                // get the just entered OrderingNumber and the old OrdringNumber
                double newOrderingNumber = tools.object2double(e.FormattedValue);
                double oldOrderingNumber = tools.object2double(gridDraftDetails.CurrentCell.FormattedValue);
                
                // check if a new value has been entered before performing the lookup
                if (oldOrderingNumber != newOrderingNumber)
                {
                    if (!OrderCommon.InsertNewOrderingNumberAndLookups(
                        bindingOrderDraftSingle,
                        bindingRelDraftDetails,
                        gridDraftDetails,
                        newOrderingNumber))
                        e.Cancel = true;
                }
            }
        }

        // grid cell end edit event
        private void gridOrderDraftDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            /* DO NOT PUT A GRID REFRESH CODE LINE IN HERE, AS IT CAUSES
             * THE GRID TO CRASH IF PRESSING ESC WHEN EDITING A CELL ON
             * A NEW ROW. INSTEAD USE THE CellValidated EVENT, WHERE THE
             * GRID DOES NOT CRASH IN THE OTHERWISE SAME SCENARIO. */
        }

        // grid row validating event
        private void gridOrderDraftDetails_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (bindingRelDraftDetails.Current == null) return;
            DataRowView row = (DataRowView)bindingRelDraftDetails.Current;

            // check that needed values have been entered in the row, before validating ok
            if (row["SuppItemID"] != DBNull.Value)
            {
                // supplier item has been specified, check for quantity
                if (row["Quantity"] == DBNull.Value)
                {
                    MessageBox.Show(db.GetLangString("OrderDraftDetailForm.SpecifyQuantityLine"));
                    e.Cancel = true;
                }
            }
            else
            {
                // SupplierItemID not filled in, and as the only other
                // field that can be filled in is the Quantity, calling
                // cancel will cancel the row.
                if (row["SuppItemID"] == DBNull.Value)
                    gridDraftDetails.CancelEdit();
            }
        }

        // grid cell validated event
        private void gridOrderDraftDetails_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (bindingRelDraftDetails.Current == null) return;
            DataRowView detailRow = (DataRowView)bindingRelDraftDetails.Current;

            // when ending edit of columns OrderingNumber or Quantity,
            // update Cost and Total Cost.
            if ((e.ColumnIndex == colOrderingNumber.Index) ||
                (e.ColumnIndex == colQuantity.Index))
            {
                // calculate and save Cost (if value was changed)
                int Quantity = tools.object2int(detailRow["Quantity"]);
                double PackageCost = tools.object2double(detailRow["PackageCost"]);
                double Cost = Quantity * PackageCost;
                if (Cost != tools.object2double(detailRow["Cost"]))
                {
                    detailRow["Cost"] = Cost;
                    gridDraftDetails.Refresh();

                    // calculate and display TotalCost
                    txtTotalCost.Text = OrderCommon.CalculateCostTotal(dsItem.OrderDraftDetails, bindingRelDraftDetails).ToString("N2");
                }                
            }

            SetFormState();
        }

        // supplier text changed event
        private void txtSupplierID_TextChanged(object sender, EventArgs e)
        {
            UpdateSupplierName();
        }

        // lookup supplier button click event
        private void btnLookupSupplier_Click(object sender, EventArgs e)
        {
            // check that no detail rows exists
            bindingRelDraftDetails.EndEdit();
            if (dsItem.OrderDraftDetails.NumberOfValidRecords() > 0)
            {
                MessageBox.Show(db.GetLangString("OrderDraftDetailForm.NoChangeSupplRowsExistsMsg"));
                return;
            }

            if (bindingOrderDraftSingle.Current == null) return;
            DataRowView row = (DataRowView)bindingOrderDraftSingle.Current;

            SupplierPopup supplier = new SupplierPopup();
            supplier.SelectedSupplierID = tools.object2int(row["SupplierID"]);
            if (supplier.ShowDialog() == DialogResult.OK)
            {
                row["SupplierID"] = supplier.SelectedSupplierID.ToString();
                txtSupplierID.Text = row["SupplierID"].ToString();
                UpdateSupplierName();
                SetFormState();
            }
        }

        // create order button click event
        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            CreateOrderFromTemplate();
        }

        // draft name keydown event
        private void txtDraftName_KeyDown(object sender, KeyEventArgs e)
        {
            // treat enter key as tab key
            tools.EnterAsTab(e);
        }

        private void gridDraftDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colOrderingNumberButton.Index)
            {
                // show supplier search form
                OrderCommon.OpenSupplierItemSearchForm(
                    bindingOrderDraftSingle,
                    bindingRelDraftDetails,
                    gridDraftDetails,
                    colOrderingNumberButton,
                    colQuantity);
            }

            // do NOT call grid.EndEdit() here
            // as it spoils the possibility of checking if
            // a value has changed.
        }

        private void gridDraftDetails_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            ImageButtonRender.OnCellPainting(e, colOrderingNumberButton.Index, ImageButtonRender.Images.Search);
        }

        private void gridDraftDetails_KeyUp(object sender, KeyEventArgs e)
        {
            if (gridDraftDetails.CurrentColumn == colOrderingNumberButton)
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                    gridDraftDetails.JumpToColumn(colQuantity);
            }
            else if (gridDraftDetails.CurrentColumn == colReceivedQuantity)
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                    gridDraftDetails.JumpToNextRow();
            }
        }
    }
}