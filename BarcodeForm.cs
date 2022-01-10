using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class BarcodeForm : Form
    {
        // semideleted row font color
        private Color SemiDeletedColor = Color.Red;

        bool DOSite = (db.GetConfigStringAsBool("DOVersion"));
        /// <summary>
        /// Constructor that takes an existing dataset and binding source as parameters.
        /// </summary>
        /// <param name="dataset">The calling form's dataset instance</param>
        /// <param name="binding">The calling form's barcode binding source instance</param>
        public BarcodeForm(ItemDataSet dataset, BindingSource binding )
        {
            this.InitializeComponent();

            // copy the dataset and binding source references from calling
            // form to this form and re-assign the grid's datasource. this
            // way all barcode data is preserved for a later single
            // transanction save in calling form as all load and save
            // is done by calling form
            this.itemDataSet = dataset;
            this.bindingBarcode = binding;
            this.dataGridView1.DataSource = bindingBarcode;
            
            // order grid columns
            colBarcodeType.DisplayIndex = 0;
            colBarcode.DisplayIndex = 1;
            colIsPrimary.DisplayIndex = 2;

            //Pn20191223
            if (!DOSite)
             {
                colBarcodeType.ReadOnly = true;
                colBarcode.ReadOnly = true;
                colIsPrimary.ReadOnly = true;
             }
            //Pn20191003

            // load lookup barcode type data
            adapterLookupBarcodeType.Connection = db.Connection;
            adapterLookupBarcodeType.Fill(itemDataSet.LookupBarcodeType);

            // setup barcode type lookup combo
            colBarcodeType.DataSource = itemDataSet.LookupBarcodeType;
            colBarcodeType.DataPropertyName = "BCType";
            colBarcodeType.ValueMember = "BCType";
            colBarcodeType.DisplayMember = "BarcodeName";
        }

        /// <summary>
        /// Confirms delete with user and sets the barcode row's SemiDeleted = true
        /// </summary>
        private void DeleteBarcode()
        {
            if (bindingBarcode.Current != null)
            {
                string msg = String.Format(db.GetLangString("BarcodeForm.DeleteBarcode"), ((DataRowView)bindingBarcode.Current)["Barcode"]);
                if(MessageBox.Show(this, msg, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // set SemiDeleted = true in table
                    DataRowView row = (DataRowView)bindingBarcode.Current;
                    row["SemiDeleted"] = true;

                    // remove IsPrimary flag if true
                    if ((row["IsPrimary"] != DBNull.Value) && bool.Parse(row["IsPrimary"].ToString()))
                    {
                        row["IsPrimary"] = false;
                        // also set in gui and avoid calling binder.ResetCurrentItem
                        dataGridView1.CurrentRow.Cells["colIsPrimary"].Value = false;
                    }

                    // paint semideleted row red
                    dataGridView1.CurrentRow.DefaultCellStyle.ForeColor = SemiDeletedColor;
                    dataGridView1.CurrentRow.DefaultCellStyle.SelectionForeColor = SemiDeletedColor;
                }
            }
        }

        // grid data error event
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            /* hiding default exception message */

            // cancel data change and return focus to the row with error
            e.Cancel = true;
        }

        // ok button click event
        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        // grid context menu delete click event
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteBarcode();//Pn20200804
        }

        // grid cell end edit event
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // reflect changes made in table when selecting a
            // checkmark, as all other checkmarks are removed
            if(e.ColumnIndex == colIsPrimary.Index)
                bindingBarcode.ResetCurrentItem();
        }

        // grid cell content click event
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // when selecting a checkmark, end grid edit, so the removal
            // of all other checkmarks are reflected at once in CellEndEdit event
            if (e.ColumnIndex == colIsPrimary.Index)
                dataGridView1.EndEdit();
        }

        // grid cell validating event
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (bindingBarcode.Current != null)
            {
                DataRowView row = (DataRowView)bindingBarcode.Current;
                ItemDataSet.BarcodeRow typedRow = (ItemDataSet.BarcodeRow)row.Row;

                if (e.ColumnIndex == colBarcode.Index)
                {
                    // check that anything was changed, as if we do not do this,
                    // the barcode verification will say that the barcode already exists,
                    // even if we did not actually change anything
                    object newValue = e.FormattedValue;
                    object oldValue = dataGridView1[e.ColumnIndex, e.RowIndex].FormattedValue;
                    if (!newValue.Equals(oldValue))
                    {
                        // restore barcode column's AllowDBNull = false
                        RestoreBarcodeColumnAllowDBNullFalse();

                        // when changing barcode value, check that 
                        // the entered barcode value can be used

                        if (!itemDataSet.Barcode.VerifyBarcode(
                            row["Barcode"], ref newValue, row["ItemID"], row["PackType"], row["BCType"]))
                        {
                            if (itemDataSet.Barcode.VerifyBarcodeMsg != "")
                                MessageBox.Show(itemDataSet.Barcode.VerifyBarcodeMsg);
                            e.Cancel = true;
                        }
                        else
                        {
                            // barcode ok and might have had added checksum
                            dataGridView1[e.ColumnIndex, e.RowIndex].Value = newValue;
                            bindingBarcode.ResetCurrentItem();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Restore barcode column's AllowDBNull = false
        /// </summary>
        private void RestoreBarcodeColumnAllowDBNullFalse()
        {
            try
            {
                DataColumn col = itemDataSet.Barcode.Columns["Barcode"];
                if (col.AllowDBNull)
                    col.AllowDBNull = false;
            }
            catch (Exception ex)
            {
                // write exception to log as this should not occur
                log.Write("Exception caught in BarcodeForm.RestoreBarcodeColumnAllowDBNullFalse():");
                log.Write("-----------------------------------------------------------------------");
                log.Write("Message: " + ex.Message);
                log.Write("StackTrace: " + ex.StackTrace);
                log.Write("-----------------------------------------------------------------------");
            }
        }

        // grid cell begin edit
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (bindingBarcode.Current != null)
            {
                DataRowView row = (DataRowView)bindingBarcode.Current;

                // do not allow editing a SemiDeleted row
                if ((row["SemiDeleted"] != DBNull.Value) && bool.Parse(row["SemiDeleted"].ToString()))
                {
                    e.Cancel = true;
                    return;
                }

                if (e.ColumnIndex == colBarcode.Index)
                {
                    // do not allow editing barcode when it has been saved to database
                    DataRowState rowstate = ((ItemDataSet.BarcodeRow)row.Row).RowState;
                    if ((rowstate != DataRowState.Added) && (rowstate != DataRowState.Detached))
                    {
                        e.Cancel = true;
                        MessageBox.Show(db.GetLangString("BarcodeForm.CannotEditExistingBarcode"));
                        return;
                    }

                    // if beginning edit of barcode column,
                    // check that bctype columns is filled in
                    if (row["BCType"] == DBNull.Value)
                    {
                        MessageBox.Show(db.GetLangString("BarcodeForm.SelectBarcodeTypeFirst"));
                        e.Cancel = true;
                    }
                }
                else if (e.ColumnIndex == colBarcodeType.Index)
                {
                    // do not allow editing barcode when it has been saved to database
                    DataRowState rowstate = ((ItemDataSet.BarcodeRow)row.Row).RowState;
                    if ((rowstate != DataRowState.Added) && (rowstate != DataRowState.Detached))
                    {
                        e.Cancel = true;
                        MessageBox.Show(db.GetLangString("BarcodeForm.CannotEditExistingBarcodeType"));
                        return;
                    }

                    // if beginning edit of barcode type column,
                    // ask if it is ok to delete barcode
                    if (row["Barcode"] != DBNull.Value)
                    {
                        if (MessageBox.Show(db.GetLangString("BarcodeForm.OkDeleteBarcode"), "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            // null the barcode value and reflect the null in the GUI
                            // NOTE: AllowDBNull is set to true here and MUST be restored!
                            DataColumn col = itemDataSet.Barcode.Columns["Barcode"];
                            col.AllowDBNull = true;
                            row["Barcode"] = DBNull.Value;
                            bindingBarcode.ResetCurrentItem();

                            // save barcode type change in grid
                            dataGridView1.EndEdit();
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                }
            }
        }

        // form closing event
        private void BarcodeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // detect and prevent click on X and ALT+F4
            if (DialogResult == DialogResult.Cancel)
            {
                MessageBox.Show(db.GetLangString("Application.UseCloseButton"));
                e.Cancel = true;
                return;
            }

            // restore barcode column's AllowDBNull = false as a final chance to do this
            RestoreBarcodeColumnAllowDBNullFalse();

            // get data from grid to binder
            dataGridView1.EndEdit();

            if (bindingBarcode.Current != null)
            {
                // get the barcode row
                ItemDataSet.BarcodeRow row =
                    (ItemDataSet.BarcodeRow)((DataRowView)bindingBarcode.Current).Row;

                // check if a barcode row has IsPrimary set within this packsize
                if ((itemDataSet.Barcode.Rows.Count > 0) && !itemDataSet.Barcode.HasPrimaryBarcode(row.PackType))
                {
                    MessageBox.Show(db.GetLangString("BarcodeForm.SelectPrimary"));
                    e.Cancel = true;
                    return;
                }
            }

            // update data from binder to table in memory
            bindingBarcode.EndEdit();

            // update primary barcode for the current packtype
            if ((!e.Cancel) && (bindingBarcode.Current != null))
            {
                ItemDataSet.BarcodeRow row =
                    (ItemDataSet.BarcodeRow)((DataRowView)bindingBarcode.Current).Row;
                itemDataSet.SalesPack.SetPrimaryBarcode(
                    row.ItemID,
                    row.PackType,
                    itemDataSet.Barcode.GetPrimaryBCType(row.PackType),
                    itemDataSet.Barcode.GetPrimaryBarcode(row.PackType));
            }
        }

        // grid rows removed event
        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (bindingBarcode.Current != null)
            {
                // if this is the last row in the barcode table
                // for this packtype in this item, mark it as primary
                ItemDataSet.BarcodeRow row =
                    (ItemDataSet.BarcodeRow)((DataRowView)bindingBarcode.Current).Row;
                itemDataSet.Barcode.CheckForLastBarcodeAndSetIsPrimary(row.PackType);
            }
        }

        // context menu strip 1 opening event
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (bindingBarcode.Current != null)
            {
                // if either semideleted or new, do not allow delete
                DataRowView row = (DataRowView)bindingBarcode.Current;
                if (((row["SemiDeleted"] != DBNull.Value) && bool.Parse(row["SemiDeleted"].ToString()))
                    || row.IsNew)
                    e.Cancel = true;
            }

        }

        // form load event
        private void BarcodeForm_Load(object sender, EventArgs e)
        {
            this.Text = db.GetLangString("BarcodeForm.HeaderText");
            colIsPrimary.HeaderText = db.GetLangString("BarcodeForm.IsPrimaryHead");
            colBarcodeType.HeaderText = db.GetLangString("BarcodeForm.BarcodeTypeHead");
            colBarcode.HeaderText = db.GetLangString("BarcodeForm.BarcodeHead");
            btnClose.Text = db.GetLangString("Application.Close");

            // paint all SemiDeleted rows red
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataRowView rowView = (DataRowView)row.DataBoundItem;
                if (rowView != null)
                {
                    if ((rowView["SemiDeleted"] != DBNull.Value) && bool.Parse(rowView["SemiDeleted"].ToString()))
                    {
                        row.DefaultCellStyle.ForeColor = SemiDeletedColor;
                        row.DefaultCellStyle.SelectionForeColor = SemiDeletedColor;
                    }
                }
            }
        }
    }
}