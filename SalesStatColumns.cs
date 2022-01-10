using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class SalesStatColumns : Form
    {
        public SalesStatColumns()
        {
            InitializeComponent();
            LoadData();

            // set column order in grid
            int index = 0;
            colDescription.DisplayIndex = index++;
            colHeaderText.DisplayIndex = index++;
            colUnitOrAmount.DisplayIndex = index++;
            colAccountBtn.DisplayIndex = index++;
            colColumnNo.DisplayIndex = index++;
            colAverage.DisplayIndex = index++;
        }

        private void LoadData()
        {
            // load unit or amount lookup data
            adapterLookupUnitOrAmount.Connection = db.Connection;
            adapterLookupUnitOrAmount.Fill(dsSalesStat.LookupUnitOrAmount);

            // load short list of column numbers to select from
            adapterLookupColumnNoShort.Connection = db.Connection;
            adapterLookupColumnNoShort.Fill(this.dsSalesStat.LookupColumnNoShort);

            // load long list of column numbers to display from
            adapterLookupColumnNoLong.Connection = db.Connection;
            adapterLookupColumnNoLong.Fill(this.dsSalesStat.LookupColumnNoLong);

            // load sales stat daily columns data
            adapterSalesStatDailyColumns.Connection = db.Connection;
            adapterSalesStatDailyColumns.Fill(dsSalesStat.SalesStatDailyColumns);

            // localization
            colHeaderText.HeaderText = db.GetLangString("SalesStatColumns.colHeaderText");
            colDescription.HeaderText = db.GetLangString("SalesStatColumns.colDescription");
            colUnitOrAmount.HeaderText = db.GetLangString("SalesStatColumns.colUnitOrAmount");
            colAccountBtn.HeaderText = db.GetLangString("SalesStatColumns.colAccountBtn");
            colColumnNo.HeaderText = db.GetLangString("SalesStatColumn.colColumnNo");
            colAverage.HeaderText = db.GetLangString("SalesStatColumn.colAverage");
            btnSaveAndClose.Text = db.GetLangString("Application.SaveClose");
            btnCancel.Text = db.GetLangString("Application.Cancel");
        }

        /// <summary>
        /// System records are painted grey and made readonly
        /// except the Average column, which users can still modify.
        /// </summary>
        private void SetupSystemRecords()
        {
            foreach (DataGridViewRow dgvr in grid.Rows)
            {
                DataRowView row = (DataRowView)dgvr.DataBoundItem;
                if (row != null)
                {
                    if (dsSalesStat.SalesStatDailyColumns.IsSystemRecord(row.Row))
                    {
                        dgvr.ReadOnly = true;
                        dgvr.DefaultCellStyle.BackColor = SystemColors.Control;
                        dgvr.Cells[colAverage.Index].ReadOnly = false;
                        dgvr.Cells[colAverage.Index].Style.BackColor = SystemColors.Window;
                    }
                }
            }
        }

        private bool SaveData()
        {
            grid.EndEdit();
            bindingSalesStatDailyColumns.EndEdit();

            // only allow save if data verification is successful
            if (!dsSalesStat.SalesStatDailyColumns.VerifyNeededValues())
            {
                MessageBox.Show(dsSalesStat.SalesStatDailyColumns.LastMsg);
                return false;
            }

            // save accounts data (edited on detail form)
            SalesStatDSTableAdapters.SalesStatDailyAccountsTableAdapter adapterAccounts =
                new RBOS.SalesStatDSTableAdapters.SalesStatDailyAccountsTableAdapter();
            adapterAccounts.Connection = db.Connection;
            adapterAccounts.Update(dsSalesStat.SalesStatDailyAccounts);
            
            // save columns data
            adapterSalesStatDailyColumns.Update(dsSalesStat.SalesStatDailyColumns);

            return true;
        }

        private void OpenAccountEditor()
        {
            if (bindingSalesStatDailyColumns.Current == null) return;
            DataRowView row = (DataRowView)bindingSalesStatDailyColumns.Current;

            if (!dsSalesStat.SalesStatDailyColumns.IsSystemRecord(row.Row))
            {
                int ColumnID = tools.object2int(row["ID"]);

                // before we open the accounts form, we load it's accounts data
                SalesStatDSTableAdapters.SalesStatDailyAccountsTableAdapter adapterAccounts =
                    new RBOS.SalesStatDSTableAdapters.SalesStatDailyAccountsTableAdapter();
                adapterAccounts.Connection = db.Connection;
                adapterAccounts.Fill(dsSalesStat.SalesStatDailyAccounts, ColumnID);

                // create and open the accounts form
                SalesStatAccounts ssa = new SalesStatAccounts(dsSalesStat, ColumnID);
                ssa.ShowDialog(this);
            }
        }

        // sets the datasource of the passed in datagridviewcombobox editing control
        // to the short list of columnnos, that is 1,2,3
        private void UseShortColumnNoList(DataGridViewComboBoxEditingControl combo)
        {
            if (combo.SelectedValue != null)
            {
                object SelectedValue = combo.SelectedValue; // save selected value (will be reset)
                combo.DataSource = bindingLookupColumnNoShort;
                combo.SelectedValue = SelectedValue; // restore selected value
            }
        }

        // sets the datasource of the passed in datagridviewcombobox editing control
        // to the long list of columnnos, that is 1,2,3,4,5,6
        private void UseLongColumnNoList(DataGridViewComboBoxEditingControl combo)
        {
            if (combo.SelectedValue != null)
            {
                object SelectedValue = combo.SelectedValue; // save selected value (will be reset)
                combo.DataSource = bindingLookupColumnNoLong;
                combo.SelectedValue = SelectedValue; // restore selected value
            }
        }

        private void SalesStatColumns_Load(object sender, EventArgs e)
        {
            SetupSystemRecords();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            if (SaveData())
                Close();
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == colAccountBtn.Index)
                OpenAccountEditor();
        }

        private void grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // render colAccountBtn image
            ImageButtonRender.OnCellPainting(e, colAccountBtn.Index, ImageButtonRender.Images.DetailForm);

            // if this is a system row, render a greyscale version
            if ((e.ColumnIndex == colAccountBtn.Index) &&
                (e.RowIndex >= 0) &&
                (e.RowIndex < grid.Rows.Count) &&
                (grid.Rows[e.RowIndex].DataBoundItem != null))
            {
                DataRowView row = (DataRowView)grid.Rows[e.RowIndex].DataBoundItem;
                if (dsSalesStat.SalesStatDailyColumns.IsSystemRecord(row.Row))
                    ImageButtonRender.OnCellPainting(e, colAccountBtn.Index, ImageButtonRender.Images.DetailFormGreyScale);
            }
        }

        private void grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (bindingSalesStatDailyColumns.Current == null) return;
            DataRowView row = (DataRowView)bindingSalesStatDailyColumns.Current;
            
            if (e.ColumnIndex == colAverage.Index)
            {
                if (!dsSalesStat.SalesStatDailyColumns.RecordCanBeSetAverage(row.Row))
                {
                    e.Cancel = true;
                    MessageBox.Show(db.GetLangString("SalesStatColumn.CannotSetAverage"));
                }
            }
        }

        private void grid_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // when mouse up on the Average column, end edit
            // so it is reflected that any other Average value is cleared
            if (e.ColumnIndex == colAverage.Index)
            {
                grid.EndEdit();
                bindingSalesStatDailyColumns.EndEdit();
            }
        }

        private void grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // check that we have a current valid control from the grid
            if (grid.CurrentCell == null) return;
            if (grid.CurrentCell.RowIndex < 0) return;
            if (grid.CurrentCell.ColumnIndex < 0) return;

            /// when showing ColumnNo editing combobox, replace the combobox'
            /// list with the short selectable list, so user can only select 4,5,6
            if ((grid.CurrentCell.ColumnIndex == colColumnNo.Index) && (e.Control is ComboBox))
            {
                DataGridViewComboBoxEditingControl combo = (DataGridViewComboBoxEditingControl)e.Control;
#if DETAIL
                UseLongColumnNoList(combo);
#else
                UseShortColumnNoList(combo);
#endif
                // note that we do not need to assign the long list to the
                // combobox after edit, as user can only edit the numbers 4,5,6
                // so there will never be the need for showing 1,2,3,4,5,6.
            }
        }
    }
}