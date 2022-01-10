using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace RBOS
{
    public partial class SalesPackDetailsForm : Form
    {
        private BindingSource callersBarcodeBinding = null;
        bool DOSite = (db.GetConfigStringAsBool("DOVersion"));
        #region Constructor
        public SalesPackDetailsForm(ItemDataSet dataset, BindingSource bindingSalesPackX, BindingSource bindingBarcodeX, BindingSource bindingSalesPackFuturePricesX)
        {
            InitializeComponent();

            // overwrite dataset with provided dataset
            dsItem = dataset;

            // now we must rebind binding sources that
            // were connected to the overwritten dataset:
            // sales pack
            bindingSalesPack.DataSource = dsItem;
            bindingSalesPack.DataMember = "SalesPack";
            bindingSalesPack.Position = bindingSalesPackX.Position;
            // chain item
            bindingRelSalesPackChainItem.DataSource = dsItem;
            bindingRelSalesPackChainItem.DataMember = "ChainItem";
            // lookup pack size
            bindingLookupPackSize.DataSource = dsItem;
            bindingLookupPackSize.DataMember = "LookupPackSize";
            // lookup unit
            bindingLookupUnit.DataSource = dsItem;
            bindingLookupUnit.DataMember = "LookupUnit";
            // future prices
            bindingSalesPackFuturePrices = bindingSalesPackFuturePricesX;
            gridSalesPackFuturePrices.DataSource = bindingSalesPackFuturePrices;
            // load lookup barcode name data
            adapterLookupBarcodeName.Connection = db.Connection;
            adapterLookupBarcodeName.Fill(dsItem.LookupBarcodeName);
            // rebind lookup table for txtBCType as it
            // were connected to the overridden dataset
            // will be cleared from dataset when form closes)
            txtBCType.LookupTable = dsItem.LookupBarcodeName;

            // load lookup unit data (will be cleared from dataset when form closes)
            adapterLookupUnit.Connection = db.Connection;
            adapterLookupUnit.Fill(dsItem.LookupUnit);

            // load chain item data
            if(bindingSalesPack.Current != null)
            {
                dsItem.ChainItem.Clear();
                ItemDataSet.SalesPackRow row =
                    (ItemDataSet.SalesPackRow)((DataRowView)bindingSalesPack.Current).Row;  //pn20200121
                adapterRelSalesPackChainItem.Connection = db.Connection;
                if (!DOSite)
                {
                    if ((row["ChainItemLocalID"] != DBNull.Value) &&
                    (row["ChainPackType"] != DBNull.Value) &&
                    (row["ChainBarcode"] != DBNull.Value))
                    {
                        adapterRelSalesPackChainItem.Fill(dsItem.ChainItem, row.ChainItemLocalID, row.ChainPackType, row.ChainBarcode);
                    }
                }
                else
                {
                    if ((row["ChainItemID"] != DBNull.Value) &&
                    (row["ChainPackType"] != DBNull.Value) &&
                    (row["ChainBarcode"] != DBNull.Value))
                    {
                        adapterRelSalesPackChainItem.Fill(dsItem.ChainItem, row.ChainItemID, row.ChainPackType, row.ChainBarcode);
                    }
                }
            }

            callersBarcodeBinding = bindingBarcodeX;

            UpdateNumBarcodes();

            // if the item on which this sales pack belong is a chain item
            // disable the btnChainLookup button, as user may not select a chain item
            btnChainLookup.Enabled = !dsItem.Item.IsChainItem();

           


            // subscribe to salespack column changed event, to update
            // gui whenever UpdateRSM or UpdateShelfLabel is changed
            dsItem.SalesPack.ColumnChanged += new DataColumnChangeEventHandler(SalesPack_ColumnChanged);

            // do not allow editing salespack when it has been saved to database
            if (bindingSalesPack.Current != null)
            {
                DataRowView row = (DataRowView)bindingSalesPack.Current;
                DataRowState rowstate = ((ItemDataSet.SalesPackRow)row.Row).RowState;
                if ((rowstate != DataRowState.Added) && (rowstate != DataRowState.Detached))
                    comboPackSize.Enabled = false;
            }
           
            
          
            
            // setup future prices grid columns
            int idx = 0;
            colActivationDate.DisplayIndex = idx++;
            colSalesPrice.DisplayIndex = idx++;
            colOrigin.DisplayIndex = idx++;
#if FSD
            colOrigin.Visible = false;
            colSentToStations.DisplayIndex = idx++;
            colClosedDate.Visible = false;
            colPerform.Visible = false;
            gridSalesPackFuturePrices.Width = (int)(gridSalesPackFuturePrices.Width / 1.7); // fewer columns in FSD mode, so narrow it
#else
            colSentToStations.Visible = false;
            colOrigin.DisplayIndex = idx++;
            colClosedDate.DisplayIndex = idx++;
            colPerform.DisplayIndex = idx++;
#endif
        }
        #endregion

        #region UpdateNumBarcodes
        /// <summary>
        /// Updates number of barcode displayed
        /// </summary>
        private void UpdateNumBarcodes()
        {
            if (bindingSalesPack.Current != null)
            {
                ItemDataSet.SalesPackRow row =
                    (ItemDataSet.SalesPackRow)((DataRowView)bindingSalesPack.Current).Row;
                row.NumBarcodesCalc = dsItem.Barcode.GetNumBarcodes(row.PackType);
                bindingSalesPack.ResetCurrentItem();
            }
        }
        #endregion

        #region ApplyUnitRules
        /// <summary>
        /// Applies rules regarding units.
        /// </summary>
        private void ApplyUnitRules()
        {
            txtShowPricePerUnit.Text = "";
            txtPricePerXX.Text = "";
            if (comboUnitDesc.SelectedValue != null)
            {
                // apply unit rules
                int key = 0;
                if (!int.TryParse(comboUnitDesc.SelectedValue.ToString(), out key)) key = 0;
                if (key != 0)
                {
                    ItemDataSet.LookupUnitRow row = (ItemDataSet.LookupUnitRow)dsItem.LookupUnit.Rows.Find(key);
                    txtShowPricePerUnit.Text = row.Amount.ToString();
                    lbPricePerXX.Text =
                        db.GetLangString("SPDetailForm.PricePrXXLabel") +
                        " " + txtShowPricePerUnit.Text +
                        " " + comboUnitDesc.Text;

                    // calc pcs. price
                    int amount = int.Parse(txtShowPricePerUnit.Text);
                    float unitContent = (float)txtUnitContent.Value;
                    float price = float.Parse(txtSalesPrice.Text);
                    float result = ((amount / unitContent) * price);
                    txtPricePerXX.Text = result.ToString("N");
                }
            }
        }
        #endregion

        #region ProcessRowLock
        protected void ProcessRowLock(int RowIndex)
        {
#if !FSD
            if (RowIndex < 0) return;
            if (RowIndex >= gridSalesPackFuturePrices.Rows.Count) return;
            if (gridSalesPackFuturePrices.Rows[RowIndex] == null) return;
            if (gridSalesPackFuturePrices.Rows[RowIndex].DataBoundItem == null) return;
            DataRow datarow = ((DataRowView)gridSalesPackFuturePrices.Rows[RowIndex].DataBoundItem).Row;

            // if record is closed, paint it grey and lock it
            if (!tools.IsNullOrDBNull(datarow["ClosedDate"]))
            {
                foreach (DataGridViewCell cell in gridSalesPackFuturePrices.Rows[RowIndex].Cells)
                    cell.Style.BackColor = SystemColors.Control;
                gridSalesPackFuturePrices.Rows[RowIndex].ReadOnly = true;
            }
            else
            {
                foreach (DataGridViewCell cell in gridSalesPackFuturePrices.Rows[RowIndex].Cells)
                    cell.Style.BackColor = SystemColors.Window;
                gridSalesPackFuturePrices.Rows[RowIndex].ReadOnly = false;
            }
            gridSalesPackFuturePrices.Refresh();
#endif
        }
        #endregion

        #region Subscribe to salespack column changed event
        void SalesPack_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if ((e.Column.ColumnName == dsItem.SalesPack.UpdateShelfLabelColumn.ColumnName) ||
                (e.Column.ColumnName == dsItem.SalesPack.UpdateRSMColumn.ColumnName))
            {
                // update GUI to reflect change in UpdateRSM or UpdateShelfLabel
                bindingSalesPack.ResetCurrentItem();
            }
        }
        #endregion

        private void SalesPackDetailsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // detect and prevent click on X or ALT+F4
            if (DialogResult == DialogResult.Cancel)
            {
                MessageBox.Show(db.GetLangString("Application.UseCloseButton"));
                e.Cancel = true;
                return;
            }

            // validate that needed values has been entered if
            // checkmark "Do not show on shelf label" has been unchecked
            if (bindingSalesPack.Current != null)
            {
                //DataRowView row = (DataRowView)bindingSalesPack.Current; //20200103 PN
                //if (!tools.object2bool(row["UnitPriceNotShown"]) &&
                //    (tools.object2byte(row["SalesPackType"]) == 0))
                //{
                //    MessageBox.Show(db.GetLangString("SalesPackDetailsForm.MustSelectUnitDescription"));
                //    e.Cancel = true;
                //    return;
                //}
            }

            // save any pending field data
            bindingSalesPack.EndEdit();

            // clear lookup values used in this form only
            dsItem.LookupUnit.Clear();
            dsItem.LookupBarcodeName.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // set dialogresult to ok, otherwise
            // closing event will prevent the close
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnBarcodes_Click(object sender, EventArgs e)
        {
            // edit barcodes in barcode editor
            BarcodeForm bf = new BarcodeForm(this.dsItem, callersBarcodeBinding);
            bf.ShowDialog(this);

            // if barcode table has changed, set UpdateRSM on salespack
            if (bindingSalesPack.Current != null)
            {
                DataRowView row = (DataRowView)bindingSalesPack.Current;
                DataTable changes = dsItem.Barcode.GetChanges();
                if ((changes != null) && (changes.Rows.Count > 0))
                {
                    row["UpdateRSM"] = true;
                    row["UpdateStations"] = true;
                }
            }

            // update number of barcodes displayed for this salespack
            UpdateNumBarcodes();
        }

        private void comboUnitDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyUnitRules();
        }

        private void txtSalesPrice_Validated(object sender, EventArgs e)
        {
            // apply unit rules after validation is approved
            ApplyUnitRules();

            // if sales price is set to 0, db will set ManualPrice = true,
            // so make sure this is reflected in GUI by refetching data
            bindingSalesPack.ResetCurrentItem();
        }

        private void txtUnitContent_Validated(object sender, EventArgs e)
        {
            // apply unit rules after validation is approved
            ApplyUnitRules();
        }

        private void chkManualPrice_Validated(object sender, EventArgs e)
        {
            // if setting manual price to false while
            // sales price is 0, db will set manual price back to true,
            // so reflect this in GUI by refetching data
            bindingSalesPack.ResetCurrentItem();
        }

        private void btnChainLookup_Click(object sender, EventArgs e)
        {
            if (bindingSalesPack.Current != null)
            {
                // open search dialog so user can select a barcode to chain to,
                // and if user makes a selection, update sales pack with selected chain key
                SearchForm search = new SearchForm();
                
                search.OnlyDisplayContainerDeposits = true; //20200102 Find ud af hvorfor den fejler
            
                if (search.ShowDialog(this) == DialogResult.OK)                  
                    {
                                            
                    ItemDataSet.SalesPackRow salesPackRow =
                        (ItemDataSet.SalesPackRow)((DataRowView)bindingSalesPack.Current).Row;

                    // check if user is trying to chain a salespack 
                    // to the item on which is belongs itself
                    if (search.SelectedItemID == salesPackRow.ItemID)
                    {
                        MessageBox.Show(db.GetLangString("SPDetailForm.CannotChainToSelfItemMsg"));
                        return;
                    }

                    // copy values
                    salesPackRow.ChainItemID = search.SelectedItemID;
                    salesPackRow.ChainPackType = search.SelectedPackType;
                    salesPackRow.ChainBarcode = search.SelectedBarcode;

                    //20200102
                    //salesPackRow.ChainItemLocalID = search.SelectedItemID;

                    // refill ChainItem table to reflect changes
                    adapterRelSalesPackChainItem.Fill(dsItem.ChainItem, salesPackRow.ChainItemID, salesPackRow.ChainPackType, salesPackRow.ChainBarcode);

                }
            }
        }

        private void SalesPackDetailsForm_Load(object sender, EventArgs e)
        {
            string receipt = "";
            if (bindingSalesPack.Current != null)
            {
                DataRowView row = (DataRowView)bindingSalesPack.Current;
                receipt = row["ReceiptText"].ToString();
            }
             
            // localization       
            this.Text = db.GetLangString("SPDetailForm.HeaderText") + " - " + receipt;
            lbPrimary.Text = db.GetLangString("SPDetailForm.PrimaryLabel");
            lbPackSize.Text = db.GetLangString("SPDetailForm.PackTypeLabel");
            lbManualPrice.Text = db.GetLangString("SPDetailForm.ManualPriceLabel");
            lbSalesPrice.Text = db.GetLangString("SPDetailForm.SalesPriceLabel");
            lbBarcodes.Text = db.GetLangString("SPDetailForm.BarcodesLabel");
            //btnBarcodes.Text = db.GetLangString("SPDetailForm.BarcodeEditBtn");
            lbNewShelfMarker.Text = db.GetLangString("SPDetailForm.NewShelfLblLabel");
            lbNumShelfMarkers.Text = db.GetLangString("SPDetailForm.NoOfShelfLblLabel");
            lbReceipt.Text = db.GetLangString("SPDetailForm.ReceiptTextLabel");
            groupUnitPrice.Text = db.GetLangString("SPDetailForm.UnitGroupHeadTxtLabel");
            lbUnitDescription.Text = db.GetLangString("SPDetailForm.UnitDescriptionLabel");
            lbShowPricePr.Text = db.GetLangString("SPDetailForm.ShowPricePrUnitLabel");
            lbUnitContent.Text = db.GetLangString("SPDetailForm.UnitContentLabel");
            lbPricePerXX.Text = db.GetLangString("SPDetailForm.PricePrXXLabel");
            groupChainItem.Text = db.GetLangString("SPDetailForm.ChItemGroupHeadLabel");
            lbChainBarcode.Text = db.GetLangString("SPDetailForm.ChainBarcodeLabel");
            lbChainSalesPack.Text = db.GetLangString("SPDetailForm.ChainSalesPackLabel");
            lbChainReceiptText.Text = db.GetLangString("SPDetailForm.ChainReceiptTxtLabel");
            lbUpdateRSM.Text = db.GetLangString("SPDetailForm.UpdateRSMTxtLabel");
            lbUpdateStations.Text = db.GetLangString("SPDetailForm.lbUpdateStations");
            btnClose.Text = db.GetLangString("Application.Close");
            chkUnitPriceNotShown.Text = db.GetLangString("SalesPackDetailsForm.chkUnitPriceNotShown");
            colActivationDate.HeaderText = db.GetLangString("SPDetailForm.colActivationDate");
            colOrigin.HeaderText = db.GetLangString("SPDetailForm.colOrigin");
            colSalesPrice.HeaderText = db.GetLangString("SPDetailForm.colSalesPrice");
            colSentToStations.HeaderText = db.GetLangString("SPDetailForm.colSentToStations");
            colClosedDate.HeaderText = db.GetLangString("SPDetailForm.colClosedDate");
            colPerform.HeaderText = db.GetLangString("SPDetailForm.colPerform");
            lbFuturePrices.Text = db.GetLangString("ItemForm.lbFuturePrices");
#if FSD
            chkUpdateStations.Visible = true;
            lbUpdateStations.Visible = true;
#endif
            if (DOSite)
            {
                txtReceipt.Enabled = true;
                txtReceipt.ReadOnly = false;
                gridSalesPackFuturePrices.ReadOnly = false; //20200812
            }

            // process row locks on the future grid
            for (int i = 0; i < gridSalesPackFuturePrices.Rows.Count; i++)
                ProcessRowLock(i);
        }

        private void btnChainRemove_Click(object sender, EventArgs e)
        {
            // remove chain item from this salespack, if user approves
            if (bindingSalesPack.Current != null)
            {
                if (MessageBox.Show(db.GetLangString("SalesPackDetailsForm.RemoveChainItem"), "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // remove chain item values
                    DataRowView row = (DataRowView)bindingSalesPack.Current;
                    row["ChainBarcode"] = DBNull.Value;
                    row["ChainItemID"] = DBNull.Value;
                    row["ChainPackType"] = DBNull.Value;

                    // clear ChainItem table to reflect changes
                    dsItem.ChainItem.Clear();
                }
            }
        }

        private void gridSalesPackFuturePrices_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (bindingSalesPackFuturePrices.Current == null) return;
            DataRow datarow = ((DataRowView)bindingSalesPackFuturePrices.Current).Row;

            // prevent user from deleting a row that has been closed
            if (!tools.IsNullOrDBNull(datarow["ClosedDate"]))
                e.Cancel = true;
        }

        private void gridSalesPackFuturePrices_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            /// when validating future grid row
            /// (as when leaving the grid or changing row),
            /// make sure valid data has been entered
            if (bindingSalesPackFuturePrices.Current == null) return;
            DataRow row = ((DataRowView)bindingSalesPackFuturePrices.Current).Row;
            if (!tools.IsNullOrDBNull(row["ActivationDate"]) &&
                tools.IsNullOrDBNull(row["SalesPrice"]))
            {
                string msg = db.GetLangString("SalesPackDetailsForm.MissingFutureRecordData");
                MessageBox.Show(msg);
                e.Cancel = true;
            }
        }
    }
}