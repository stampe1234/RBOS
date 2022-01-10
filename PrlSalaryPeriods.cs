using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class PrlSalaryPeriods : Form
    {
        #region Constructor
        public PrlSalaryPeriods()
        {
            InitializeComponent();
            LoadData(true);

            // position grid columns (bug in vs2005)
            int index = 0;
            colPeriod.DisplayIndex = index++;
            colStartDate.DisplayIndex = index++;
            colEndDate.DisplayIndex = index++;
            colActiveImg.DisplayIndex = index++;
            colApprovedImg.DisplayIndex = index++;
            colSentImg.DisplayIndex = index++;

            // center image columns header text
            colActiveImg.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colApprovedImg.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colSentImg.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // localization
            btnClose.Text = db.GetLangString("Application.SaveClose");
            btnCancel.Text = db.GetLangString("Application.Cancel");
            lbYears.Text = db.GetLangString("PrlSalaryPeriods.lbYears");
            colPeriod.HeaderText = db.GetLangString("PrlSalaryPeriods.colPeriod");
            colStartDate.HeaderText = db.GetLangString("PrlSalaryPeriods.colStartDate");
            colEndDate.HeaderText = db.GetLangString("PrlSalaryPeriods.colEndDate");
            colActiveImg.HeaderText = db.GetLangString("PrlSalaryPeriods.colActiveImg");
            colApprovedImg.HeaderText = db.GetLangString("PrlSalaryPeriods.colApprovedImg");
            colSentImg.HeaderText = db.GetLangString("PrlSalaryPeriods.colSentImg");
        }
        #endregion

        #region LoadData
        private void LoadData(bool LoadAllData)
        {
            if (LoadAllData)
            {
                adapterSalaryPeriodYears.Connection = db.Connection;
                adapterSalaryPeriodYears.Fill(dsPayroll.PrlSalaryPeriodYears);
            }

            // load period data from all years
            // (when selecting a year, we just filter out what
            // data to look at. we use filter instead of selecting
            // a subset of data, as when user makes changes in one
            // year and then selects another year, then the
            // "Save & Close" and "Cancel" buttons should be applied to
            // all data modified across all years)
            adapterPrlSalaryPeriods.Connection = db.Connection;
            adapterPrlSalaryPeriods.Fill(dsPayroll.PrlSalaryPeriods);

            // now data has been loaded, we want to show the year in
            // which the active period is. if no active period exists
            // we show the current year.
            DataRow ActiveSalaryPeriod = Payroll.PrlSalaryPeriodsDataTable.GetActiveSalaryPeriod();
            int YearToSelect = DateTime.Now.Year;
            if (ActiveSalaryPeriod != null)
                YearToSelect = tools.object2int(ActiveSalaryPeriod["PeriodYear"]);
            int idx = bindingSalaryPeriodYears.Find("PeriodYear", YearToSelect);
            if (idx >= 0)
                bindingSalaryPeriodYears.Position = idx;
        }
        #endregion

        #region SaveData
        private void SaveData()
        {
            gridSalaryPeriods.EndEdit();
            bindingPrlSalaryPeriods.EndEdit();
            adapterPrlSalaryPeriods.Update(dsPayroll.PrlSalaryPeriods);
        }
        #endregion

        #region LoadVirtualGridImages
        /// fill in images in virtual columns ActiveImg, ApprovedImg and SentImg.
        /// (even when calling LoadData in constructor, which calls this method,
        /// this method must be called from the form Load event, as images gets nulled otherwise)
        private void LoadVirtualGridImages()
        {
            foreach (DataGridViewRow row in gridSalaryPeriods.Rows)
            {
                if (row.DataBoundItem is DataRowView)
                {
                    DataRowView drw = (DataRowView)row.DataBoundItem;

                    // set ActiveImg
                    if (tools.object2bool(drw["Active"]))
                        row.Cells[colActiveImg.Index].Value = ImageButtonRender.GetImage(ImageButtonRender.Images.Checkmark);
                    else
                        row.Cells[colActiveImg.Index].Value = ImageButtonRender.GetImage(ImageButtonRender.Images.Trash);

                    // set ApprovedImg
                    if (tools.object2bool(drw["Approved"]))
                        row.Cells[colApprovedImg.Index].Value = ImageButtonRender.GetImage(ImageButtonRender.Images.Checkmark);
                    else
                        row.Cells[colApprovedImg.Index].Value = ImageButtonRender.GetImage(ImageButtonRender.Images.Trash);

                    // set SentImg
                    if (tools.object2bool(drw["Sent"]))
                        row.Cells[colSentImg.Index].Value = ImageButtonRender.GetImage(ImageButtonRender.Images.Checkmark);
                    else
                        row.Cells[colSentImg.Index].Value = ImageButtonRender.GetImage(ImageButtonRender.Images.Trash);
                }
            }
        }
        #endregion

        #region ToggleFlagsAndImages
        /// <summary>
        /// Toggles boolean values in fields Active, Approved and Sent
        /// and their displayed images respectively.
        /// </summary>
        private void ToggleFlagsAndImages(int ColumnIndex, int RowIndex)
        {
            if (RowIndex < 0) return;
            if (ColumnIndex < 0) return;
            if (RowIndex >= gridSalaryPeriods.Rows.Count) return;
            if (ColumnIndex >= gridSalaryPeriods.Columns.Count) return;

            if (bindingPrlSalaryPeriods.Current == null) return;
            DataRowView row = (DataRowView)bindingPrlSalaryPeriods.Current;

            // when user clicks on the ActiveImg column,
            // toggle image and toggle Active field boolean value
            if ((ColumnIndex == colActiveImg.Index) && (RowIndex >= 0))
            {
                if (tools.object2bool(row["Active"]))
                {
                    // toggle from active to inactive
                    row["Active"] = false;
                    gridSalaryPeriods[ColumnIndex, RowIndex].Value =
                        ImageButtonRender.GetImage(ImageButtonRender.Images.Trash);
                }
                else
                {
                    // when setting active, remove all true flags
                    // from table (where all unfiltered data resides)
                    foreach (DataRow r in dsPayroll.PrlSalaryPeriods.Rows)
                    {
                        if ((r.RowState != DataRowState.Deleted) &&
                            (r.RowState != DataRowState.Detached))
                        {
                            if (tools.object2bool(r["Active"]))
                                r["Active"] = false;
                        }
                    }

                    // reflect the boolean changes by
                    // updating the graphical checkmarks
                    LoadVirtualGridImages();

                    // toggle from inactive to active
                    row["Active"] = true;
                    gridSalaryPeriods[ColumnIndex, RowIndex].Value =
                        ImageButtonRender.GetImage(ImageButtonRender.Images.Checkmark);
                }
            }
            // when user clicks on the ApprovedImg column,
            // toggle image and toggle Approved field boolean value
            else if ((ColumnIndex == colApprovedImg.Index) && (RowIndex >= 0))
            {
                if (tools.object2bool(row["Approved"]))
                {
                    // toggle from active to inactive
                    row["Approved"] = false;
                    gridSalaryPeriods[ColumnIndex, RowIndex].Value =
                        ImageButtonRender.GetImage(ImageButtonRender.Images.Trash);
                }
                else
                {
                    // toggle from inactive to active
                    row["Approved"] = true;
                    gridSalaryPeriods[ColumnIndex, RowIndex].Value =
                        ImageButtonRender.GetImage(ImageButtonRender.Images.Checkmark);
                }
            }
            // when user clicks on the SentImg column,
            // toggle image and toggle Sent field boolean value
            else if ((ColumnIndex == colSentImg.Index) && (RowIndex >= 0))
            {
                if (tools.object2bool(row["Sent"]))
                {
                    // toggle from active to inactive
                    row["Sent"] = false;
                    gridSalaryPeriods[ColumnIndex, RowIndex].Value =
                        ImageButtonRender.GetImage(ImageButtonRender.Images.Trash);
                }
                else
                {
                    // toggle inactive to active
                    row["Sent"] = true;
                    gridSalaryPeriods[ColumnIndex, RowIndex].Value =
                        ImageButtonRender.GetImage(ImageButtonRender.Images.Checkmark);
                }
            }
        }
        #endregion

        #region SelectYear
        /// <summary>
        /// Displays data for the currently selected year in the combo.
        /// </summary>
        private void SelectYear()
        {
            // end any pending edit data
            gridSalaryPeriods.EndEdit();
            bindingPrlSalaryPeriods.EndEdit();

            // filter to only show selected year
            int Year = tools.object2int(comboYears.SelectedValue);
            bindingPrlSalaryPeriods.Filter = string.Format(" (PeriodYear = {0}) ", Year);

            // load virtual images
            LoadVirtualGridImages();
        }
        #endregion

        private void PrlSalaryPeriods_Load(object sender, EventArgs e)
        {
            // select the year currently selected in the combo
            SelectYear();

            // title is set as the form is sometimes loaded from somewhere else than the menu
            this.Text = db.GetLangString("TreeMenu.Loen.Stamdata.Loenperioder");
        }

        private void prlSalaryPeriodYearsBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            SelectYear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            SaveData();
            Close();
        }

        private void gridSalaryPeriods_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ToggleFlagsAndImages(e.ColumnIndex, e.RowIndex);
        }

        private void gridSalaryPeriods_KeyUp(object sender, KeyEventArgs e)
        {
            if ((gridSalaryPeriods.CurrentCell != null) &&
                (e.KeyCode == Keys.Space))
            {
                ToggleFlagsAndImages(
                    gridSalaryPeriods.CurrentCell.ColumnIndex,
                    gridSalaryPeriods.CurrentCell.RowIndex);
            }
        }

        private void gridSalaryPeriods_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if ((e.ColumnIndex == colActiveImg.Index) ||
                    (e.ColumnIndex == colApprovedImg.Index) ||
                    (e.ColumnIndex == colSentImg.Index))
                {
                    if (gridSalaryPeriods.Cursor != Cursors.Hand)
                        gridSalaryPeriods.Cursor = Cursors.Hand;
                }
            }
        }

        private void gridSalaryPeriods_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            gridSalaryPeriods.Cursor = Cursors.Default;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}