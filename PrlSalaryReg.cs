using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class PrlSalaryReg : Form
    {
        private bool OkToClose = false;
        private string WaterMarkLentEmp = "";
        
        public PrlSalaryReg()
        {
            InitializeComponent();

            // load data
            LoadData(false);

            // hide some columns in RBA mode if disabled
            colOvertime.Visible = db.GetConfigStringAsBool("Payroll.OvertimeVisible");
            colTakeTimeOff.Visible = db.GetConfigStringAsBool("Payroll.TakeTimeOffVisible");

            // position grid columns (bug in vs2005)
            int index = 0;
            colDay.DisplayIndex = index++;
            colRegDateAsString.DisplayIndex = index++;
            colFromTimeAsString.DisplayIndex = index++;
            colToTimeAsString.DisplayIndex = index++;
            colHours.DisplayIndex = index++;
            colBonus1010.DisplayIndex = index++;
            colBonus1020.DisplayIndex = index++;
            colBonus1030.DisplayIndex = index++;
            colBonus1040.DisplayIndex = index++;
            colBonus1050.DisplayIndex = index++;
            if (colOvertime.Visible)
                colOvertime.DisplayIndex = index++;
            if (colTakeTimeOff.Visible)
                colTakeTimeOff.DisplayIndex = index++;
            colSiteCode.DisplayIndex = index++;
            colSiteCodeButton.DisplayIndex = index++;
            colRemarks.DisplayIndex = index++;

            // localization
            btnClose.Text = db.GetLangString("Application.Close");
            lbSalaryPeriod.Text = db.GetLangString("PrlSalaryReg.lbSalaryPeriod");
            lbEmployeeNo.Text = db.GetLangString("PrlSalaryReg.lbEmployeeNo");
            groupTotals.Text = db.GetLangString("PrlSalaryReg.groupTotals");
            colFromTimeAsString.HeaderText = db.GetLangString("PrlSalaryReg.colFromTime");
            colToTimeAsString.HeaderText = db.GetLangString("PrlSalaryReg.colToTime");
            colRegDateAsString.HeaderText = db.GetLangString("PrlSalaryReg.colRegDate");
            colTakeTimeOff.HeaderText = db.GetLangString("PrlSalaryReg.colTakeTimeOff");
            colBonus1010.HeaderText = db.GetLangString("PrlSalaryReg.colBonus1010");
            colBonus1020.HeaderText = db.GetLangString("PrlSalaryReg.colBonus1020");
            colBonus1030.HeaderText = db.GetLangString("PrlSalaryReg.colBonus1030");
            colBonus1040.HeaderText = db.GetLangString("PrlSalaryReg.colBonus1040");
            colBonus1050.HeaderText = db.GetLangString("PrlSalaryReg.colBonus1050");
            colSiteCode.HeaderText = db.GetLangString("PrlSalaryReg.colSiteCode");
            colRemarks.HeaderText = db.GetLangString("PrlSalaryReg.colRemarks");
            colDay.HeaderText = db.GetLangString("PrlSalaryReg.colDay");
            colHours.HeaderText = db.GetLangString("PrlSalaryReg.colHours");
            colOvertime.HeaderText = db.GetLangString("PrlSalaryReg.colOvertime");
        }

        private void LoadData(bool OnlyLoadSalaryData)
        {
            // get the active salary period
            DataRow ActiveSalaryPeriod = Payroll.PrlSalaryPeriodsDataTable.GetActiveSalaryPeriod();
            DateTime StartDate = tools.object2datetime(ActiveSalaryPeriod["StartDate"]);
            DateTime EndDate = tools.object2datetime(ActiveSalaryPeriod["EndDate"]);

            if (!OnlyLoadSalaryData)
            {
                // load day strings for the grid
                adapterLookupDays.Connection = db.Connection;
                adapterLookupDays.Fill(dsPayroll.PrlLookupDays);

                // load data for employee drop down
                adapterEmployeeDropDown.Connection = db.Connection;
                adapterEmployeeDropDown.FillActiveInSalaryPeriod(dsPayroll.PrlEmployeeDropDown);
            }

            // get selected employeeno
            int EmployeeNo = GetSelectedEmployeeNo();

            // load salary registration data
            if (ActiveSalaryPeriod != null)
            {
                txtSalaryPeriod.Text = Payroll.PrlSalaryPeriodsDataTable.GetActiveSalaryPeriodString();

                // load salary registration for this period and selected employee
                adapterSalaryRegistration.Connection = db.Connection;
                adapterSalaryRegistration.Fill(dsPayroll.PrlSalaryRegistration, StartDate, EndDate, EmployeeNo);

                // calculated totals
                CalculateTotals();
            }

            WaterMarkLentEmp = db.GetLangString("PrlSalaryReg.WaterMarkLentEmp");
        }

        private void SaveData()
        {
            gridSalary.EndEdit();
            bindingSalaryRegistration.EndEdit();
            adapterSalaryRegistration.Update(dsPayroll.PrlSalaryRegistration);
        }

        private void CalculateTotals()
        {
            // only perform calculation if needed basic values are present
            // (empty rows might be produced otherwise due to EndEdit calls below)
            if (bindingSalaryRegistration.Current == null) return;
            DataRowView row = (DataRowView)bindingSalaryRegistration.Current;
            if (tools.IsNullOrDBNull(row["RegDateAsString"]) ||
                tools.IsNullOrDBNull(row["FromTimeAsString"]) ||
                tools.IsNullOrDBNull(row["ToTimeAsString"]))
                return;

            // post pending edit data to underlying dataset
            gridSalary.EndEdit();
            bindingSalaryRegistration.EndEdit();

            // calculate the totals
            DataRow rowTotal = dsPayroll.PrlSalaryRegistration.CalculateTotals();
            txtTotalBonus1010.Text = tools.object2double(rowTotal["Bonus1010"]).ToString("n2");
            txtTotalBonus1020.Text = tools.object2double(rowTotal["Bonus1020"]).ToString("n2");
            txtTotalBonus1030.Text = tools.object2double(rowTotal["Bonus1030"]).ToString("n2");
            txtTotalBonus1040.Text = tools.object2double(rowTotal["Bonus1040"]).ToString("n2");
            txtTotalBonus1050.Text = tools.object2double(rowTotal["Bonus1050"]).ToString("n2");
            txtTotalHours.Text = tools.object2double(rowTotal["Hours"]).ToString("n2");
            txtTotalOvertime.Text = tools.object2double(rowTotal["Overtime"]).ToString("n2");
            txtTotalTakeTimeOff.Text = tools.object2double(rowTotal["TakeTimeOff"]).ToString("n2");
        }

        private void ClearTotals()
        {
            txtTotalBonus1010.Text = "";
            txtTotalBonus1020.Text = "";
            txtTotalBonus1030.Text = "";
            txtTotalBonus1040.Text = "";
            txtTotalBonus1050.Text = "";
            txtTotalHours.Text = "";
            txtTotalOvertime.Text = "";
            txtTotalTakeTimeOff.Text = "";
        }

        private int GetSelectedEmployeeNo()
        {
            return tools.object2int(comboEmployeeNo.SelectedValue);
        }

        private bool VerifyIfFieldCanBeEdited(int ColumnIndex)
        {
            if (bindingSalaryRegistration.Current == null) return false;
            DataRowView row = (DataRowView)bindingSalaryRegistration.Current;

            // if user attempt to enter values in fields while
            // any of the required fields are empty, prohibit the action
            if ((ColumnIndex != colRegDateAsString.Index) &&
                (ColumnIndex != colFromTimeAsString.Index) &&
                (ColumnIndex != colToTimeAsString.Index))
            {
                if (tools.IsNullOrDBNull(row["RegDateAsString"]) ||
                    tools.IsNullOrDBNull(row["FromTimeAsString"]) ||
                    tools.IsNullOrDBNull(row["ToTimeAsString"]))
                {
                    MessageBox.Show(db.GetLangString("PrlSalaryReg.FillInNeededDataFirst"));
                    return false;
                }
            }

            // field can be edited
            return true;
        }

        private void PrlSalaryReg_Load(object sender, EventArgs e)
        {
        }

        private void PrlSalaryReg_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!OkToClose)
            {
                MessageBox.Show(db.GetLangString("Application.UseCloseButton"));
                e.Cancel = true;
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            SaveData();
            OkToClose = true;
            Close();
        }

        private void drS_DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (bindingSalaryRegistration.Current == null) return;
            DataRow row = ((DataRowView)bindingSalaryRegistration.Current).Row;

            // when ending edit on fields RegDateAsString, FromTimeAsString and ToTimeAsString
            // we need to refresh the grid, as some data might have been calculated in base code.
            if ((e.ColumnIndex == colRegDateAsString.Index) ||
                (e.ColumnIndex == colFromTimeAsString.Index) ||
                (e.ColumnIndex == colToTimeAsString.Index))
            {
                gridSalary.Refresh();
            }

            // when certain cells have been edited, calculate totals
            if ((e.ColumnIndex == colRegDateAsString.Index) ||
                (e.ColumnIndex == colFromTimeAsString.Index) ||
                (e.ColumnIndex == colToTimeAsString.Index) ||
                (e.ColumnIndex == colOvertime.Index) ||
                (e.ColumnIndex == colTakeTimeOff.Index))
            {
                CalculateTotals();
            }
        }

        private void drS_DataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (bindingSalaryRegistration.Current == null) return;
            DataRowView row = (DataRowView)bindingSalaryRegistration.Current;

            // if any of the required fields have not been filled
            // in when leaving the row, cancel the row.
            if (tools.IsNullOrDBNull(row["RegDateAsString"]) ||
                tools.IsNullOrDBNull(row["FromTimeAsString"]) ||
                tools.IsNullOrDBNull(row["ToTimeAsString"]))
            {
                gridSalary.CancelEdit();
                bindingSalaryRegistration.CancelEdit();
                return;
            }

            // if lent employee
            if (tools.object2int(row["EmployeeNo"]) == Payroll.PrlEmployeeDataTable.LentEmployeeNo)
            {
                // replace empty remark with water mark
                if (tools.object2string(row["Remarks"]) == "")
                {
                    row["Remarks"] = WaterMarkLentEmp;
                    gridSalary[e.ColumnIndex, e.RowIndex].Value = WaterMarkLentEmp;
                }

                // check if no remark has been written
                if (tools.object2string(row["Remarks"]).ToLower() == WaterMarkLentEmp.ToLower())
                {
                    e.Cancel = true;
                    string msg = db.GetLangString("PrlSalaryReg.MissingNameLentEmp");
                    MessageBox.Show(msg);
                    return;
                }

                // check that field SiteCode has been filled in
                if (tools.object2string(row["SiteCode"]) == "")
                {
                    e.Cancel = true;
                    string msg = db.GetLangString("PrlSalaryReg.MissingSiteCodeLentEmp");
                    MessageBox.Show(msg);
                    return;
                }
            }
        }

        private void gridSalary_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (bindingSalaryRegistration.Current == null) return;
            DataRowView row = (DataRowView)bindingSalaryRegistration.Current;

            // if user has added a row
            if (tools.IsNullOrDBNull(row["EmployeeNo"]))
            {
                // insert the selected employee id
                row["EmployeeNo"] = tools.object2int(comboEmployeeNo.SelectedValue);

                // if employee 9999999, insert water mark in comments field
                if (tools.object2int(row["EmployeeNo"]) == Payroll.PrlEmployeeDataTable.LentEmployeeNo)
                    row["Remarks"] = WaterMarkLentEmp;
            }
        }

        private void comboEmployeeNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // an employee has been selected

            // first save changes to this employee
            SaveData();

            // clear totals
            ClearTotals();

            // load data for the next employee
            LoadData(true);
        }

        private void gridSalary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // check that cells can be edited
            if (!VerifyIfFieldCanBeEdited(e.ColumnIndex))
                return;

            if (bindingSalaryRegistration.Current == null) return;
            DataRowView row = (DataRowView)bindingSalaryRegistration.Current;

            // if user clicks on the button to select a site
            if (e.ColumnIndex == colSiteCodeButton.Index)
            {
                string SiteCode = tools.object2string(row["SiteCode"]);
                PrlClusterSites sites = new PrlClusterSites();
                sites.SelectedSiteCode = SiteCode;
                if (sites.ShowDialog() == DialogResult.OK)
                {
                    if (sites.SelectedSiteCode != "")
                        row["SiteCode"] = sites.SelectedSiteCode;
                    else
                        row["SiteCode"] = DBNull.Value;
                    gridSalary.Refresh();
                }
            }
        }

        private void gridSalary_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            ImageButtonRender.OnCellPainting(e, colSiteCodeButton.Index, ImageButtonRender.Images.LookupForm);
        }

        private void gridSalary_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!VerifyIfFieldCanBeEdited(e.ColumnIndex))
                e.Cancel = true;
            else
            {
                if (bindingSalaryRegistration.Current == null) return;
                DataRow row = ((DataRowView)bindingSalaryRegistration.Current).Row;

                // if user starts editing the remarks field and if it is lent employee and
                // if the field only contains the water mark, empty the grid field
                if ((e.ColumnIndex == colRemarks.Index) &&
                    (tools.object2int(row["EmployeeNo"]) == Payroll.PrlEmployeeDataTable.LentEmployeeNo) &&
                    (tools.object2string(row["Remarks"]).ToLower() == WaterMarkLentEmp.ToLower()))
                {
                    row["Remarks"] = "";
                    gridSalary[e.ColumnIndex, e.RowIndex].Value = "";
                }
            }
        }

        private void gridSalary_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            // when deleting a row,
            // we need to recalculate totals
            CalculateTotals();
        }

        private void gridSalary_KeyUp(object sender, KeyEventArgs e)
        {
            // skip read-only cells
            if (gridSalary.CurrentCell == null) return;
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
            {
                if (gridSalary.CurrentCell.ColumnIndex == colHours.Index)
                {
                    if (colOvertime.Visible)
                        gridSalary.CurrentCell = gridSalary[colOvertime.Index, gridSalary.CurrentCell.RowIndex];
                    else
                        gridSalary.CurrentCell = gridSalary[colRemarks.Index, gridSalary.CurrentCell.RowIndex];
                }
                else if (gridSalary.CurrentCell.ColumnIndex == colSiteCode.Index)
                    gridSalary.CurrentCell = gridSalary[colRemarks.Index, gridSalary.CurrentCell.RowIndex];
                else if (gridSalary.CurrentCell.ColumnIndex == colDay.Index)
                    gridSalary.CurrentCell = gridSalary[colRegDateAsString.Index, gridSalary.CurrentCell.RowIndex];
            }
        }
    }
}