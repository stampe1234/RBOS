using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class PrlAbsense : Form
    {
        #region Private variables

        private bool OkToClose = false;
        private bool UserIsFunc = false;

        // used to override UserIsFunc if station has set that
        // date time pickers are disallowed no matter what
        private bool InputFuncAbsenseWithText = false;

        #endregion

        #region Constructor
        public PrlAbsense()
        {
            InitializeComponent();

            // load data
            LoadData(false);

            // position grid columns (bug in vs2005)
            int index = 0;
            colDayNo.DisplayIndex = index++;
            colFromDateAsString.DisplayIndex = index++;
            colFromDatepPicker.DisplayIndex = index++;
            colToDateAsString.DisplayIndex = index++;
            colToDatePicker.DisplayIndex = index++;
            colAbsenseCode.DisplayIndex = index++;
            colAbsenseCodeButton.DisplayIndex = index++;
            colAbsenseCodeDescription.DisplayIndex = index++;
            colHours.DisplayIndex = index++;
            colDays.DisplayIndex = index++;
            colEjRefunderet.DisplayIndex = index++;

            // localization
            btnClose.Text = db.GetLangString("Application.Close");
            lbSalaryPeriod.Text = db.GetLangString("PrlAbsense.lbSalaryPeriod");
            lbEmployeeNo.Text = db.GetLangString("PrlAbsense.lbEmployee");
            groupBox1.Text = db.GetLangString("PrlAbsense.groupTotals");
            colDayNo.HeaderText = db.GetLangString("PrlAbsense.colDayNo");
            colFromDateAsString.HeaderText = db.GetLangString("PrlAbsense.colFromDateAsString");
            colToDateAsString.HeaderText = db.GetLangString("PrlAbsense.colToDateAsString");
            colAbsenseCode.HeaderText = db.GetLangString("PrlAbsense.colAbsenseCode");
            colAbsenseCodeDescription.HeaderText = db.GetLangString("PrlAbsense.colAbsenseCodeDescription");
            colHours.HeaderText = db.GetLangString("PrlAbsense.colHours");
            colDays.HeaderText = db.GetLangString("PrlAbsense.colDays");
            colEjRefunderet.HeaderText = db.GetLangString("PrlAbsense.colEjRefunderet");
        }
        #endregion

        #region LoadData
        private void LoadData(bool OnlyLoadAbsenseData)
        {
            if (!OnlyLoadAbsenseData)
            {
                // load day strings for the grid
                adapterLookupDays.Connection = db.Connection;
                adapterLookupDays.Fill(dsPayroll.PrlLookupDays);

                // load absense code lookup data for the grid
                adapterLookupAbsenseCodesAll.Connection = db.Connection;
                adapterLookupAbsenseCodesAll.Fill(dsPayroll.PrlLookupAbsenseCodesAll);

                // load data for employee drop down
                adapterEmployeeDropDown.Connection = db.Connection;
                adapterEmployeeDropDown.FillActiveInSalaryPeriod(dsPayroll.PrlEmployeeDropDown);
            }

            if (comboEmployeeNo.SelectedIndex >= 0)
            {
                // get selected employeeno
                int EmployeeNo = tools.object2int(comboEmployeeNo.SelectedValue);

                // get the active salary period
                DataRow ActiveSalaryPeriod = Payroll.PrlSalaryPeriodsDataTable.GetActiveSalaryPeriod();

                // get whether station disallows using datetime pickers for func
                InputFuncAbsenseWithText = db.GetConfigStringAsBool("Payroll.InputFuncAbsenseWithText");

                // load salary registration data
                if (ActiveSalaryPeriod != null)
                {
                    // get active salary period text
                    txtSalaryPeriod.Text = Payroll.PrlSalaryPeriodsDataTable.GetActiveSalaryPeriodString();

                    // load salary registration for selected employee in active period
                    int PeriodYear = tools.object2int(ActiveSalaryPeriod["PeriodYear"]);
                    int Period = tools.object2int(ActiveSalaryPeriod["Period"]);
                    adapterAbsense.Connection = db.Connection;
                    adapterAbsense.Fill(dsPayroll.PrlAbsense, EmployeeNo, PeriodYear, Period);

                    // calculate totals
                    CalculateTotals();

                    // get whether user is func
                    UserIsFunc = Payroll.PrlEmployeeDataTable.IsFunc(EmployeeNo);

                    // if employee is funktionær, disable entering to and from dates with textfields,
                    // and if employee is non-funktionær, disable entering the dates with datetime pickers
                    if (UserIsFunc && !InputFuncAbsenseWithText)
                    {
                        colToDateAsString.DefaultCellStyle.BackColor = SystemColors.Control;
                        colToDateAsString.ReadOnly = true;
                        colFromDateAsString.DefaultCellStyle.BackColor = SystemColors.Control;
                        colFromDateAsString.ReadOnly = true;
                    }
                    else
                    {
                        colToDateAsString.DefaultCellStyle.BackColor = SystemColors.Window;
                        colToDateAsString.ReadOnly = false;
                        colFromDateAsString.DefaultCellStyle.BackColor = SystemColors.Window;
                        colFromDateAsString.ReadOnly = false;
                    }

                    // loop the grid and toggle the Hours field
                    foreach (DataGridViewRow row in gridAbsense.Rows)
                    {
                        if (row.DataBoundItem is DataRowView)
                            ToggleHoursField(((DataRowView)row.DataBoundItem).Row, row.Index);
                    }
                }
            }
        }
        #endregion

        #region SaveData
        private void SaveData()
        {
            gridAbsense.EndEdit();
            bindingAbsense.EndEdit();
            adapterAbsense.Update(dsPayroll.PrlAbsense);
        }
        #endregion

        #region CalculateTotals
        /// <summary>
        /// Calculates totals and displays them in textboxes on the form.
        /// It is not nessecary to call EndEdit first, as values are
        /// calculated from values in grid.
        /// </summary>
        private void CalculateTotals()
        {
            // calculate totals using values in grid
            // as we then don't have to endedit pending data in the grid

            double TotalHours = 0;
            int TotalDays = 0;
            foreach (DataGridViewRow row in gridAbsense.Rows)
            {
                TotalHours += tools.object2double(row.Cells[colHours.Index].Value);
                TotalDays += tools.object2int(row.Cells[colDays.Index].Value);
            }

            txtTotalHours.Text = TotalHours.ToString("N2");
            txtTotalDays.Text = TotalDays.ToString();
        }
        #endregion

        #region VerifyIfFieldCanBeEdited
        private bool VerifyIfFieldCanBeEdited(int ColumnIndex)
        {
            if (bindingAbsense.Current == null) return false;
            DataRowView row = (DataRowView)bindingAbsense.Current;

            // if user attempt to enter values in fields while
            // any of the required fields are empty, prohibit the action
            if ((ColumnIndex != colFromDateAsString.Index) &&
                (ColumnIndex != colToDateAsString.Index) &&
                (ColumnIndex != colFromDatepPicker.Index) && 
                (ColumnIndex != colToDatePicker.Index))
            {
                if (tools.IsNullOrDBNull(row["FromDateAsString"]) ||
                    tools.IsNullOrDBNull(row["ToDateAsString"]))
                {
                    MessageBox.Show(db.GetLangString("PrlAbsense.SpecifyDatesFirst"));
                    return false;
                }
            }

            // field can be edited
            return true;
        }
        #endregion

        #region SelectDateWithDateTimeDialog
        private void SelectDateWithDateTimeDialog(DataRowView Row, string FieldName)
        {
            // create a new DateTimeDialog object
            DateTimeDialog dt = new DateTimeDialog();

            // set minimum and maximum allowed dates in the dialog
            dt.MinDate = Payroll.PrlSalaryPeriodsDataTable.GetActiveSalaryPeriodStartDate();
            dt.MaxDate = Payroll.PrlAbsenseDataTable.GetActiveSalaryPeriodEndDate(UserIsFunc);

            // if there already is a date in the field,
            // use it as the selected date in the dialog,
            // otherwise select a default date
            if (!tools.IsNullOrDBNull(Row[FieldName]))
              dt.SelectedDateTime = tools.object2datetime(Row[FieldName]).Date;
            else
              dt.SelectedDateTime = dt.MinDate;

            // show the dialog
            if (dt.ShowDialog() == DialogResult.OK)
            {
                // before we insert the value, we must make sure
                // that the employeeno has been inserted, as it is
                // needed in the base code
                if (tools.IsNullOrDBNull(Row["EmployeeNo"]))
                    Row["EmployeeNo"] = tools.object2int(comboEmployeeNo.SelectedValue);

                // user selected a date so insert it in row
                Row[FieldName] = dt.SelectedDateTime.ToString("d");

                // toggle Hours field
                if (gridAbsense.CurrentRow != null)
                    ToggleHoursField(Row.Row, gridAbsense.CurrentRow.Index);

                CalculateTotals();

                // refresh grid to reflect changes made by base code
                gridAbsense.Refresh();
            }
        }
        #endregion

        private bool SelectAbsenseCode(DataRowView row)
        {
            // open the absense code popup with the current absense code (if any)
            // and provide whether to show funktionær data
            int AbsenseCode = tools.object2int(row["AbsenseCode"]);
            PrlAbsenseCodes codes = new PrlAbsenseCodes(UserIsFunc);
            codes.SelectedAbsenseCode = AbsenseCode;
            if (codes.ShowDialog() == DialogResult.OK)
            {
                row["AbsenseCode"] = codes.SelectedAbsenseCode;

                /// HACK: if using datetimepickers to insert dates,
                /// and user does not enter value in hours field,
                /// grid does not recognize this state as a new row,
                /// so after inserting the absense code, we issue an
                /// EndEdit on the binder, thus forcing the new row
                /// to be accepted
                if (UserIsFunc && row.IsNew)
                    bindingAbsense.EndEdit();

                gridAbsense.Refresh();

                return true;
            }
            else
                return false;
        }

        #region LockUnlockHoursField
        /// <summary>
        /// Sets the Hours cells for the current grid row to
        /// readonly or not readonly based on what
        /// Payroll.PrlAbsenseDataTable.HoursAndDaysLocked(Row) returns.
        /// </summary>
        private void ToggleHoursField(DataRow Row, int GridRowIndex)
        {
            if ((GridRowIndex >= 0) &&
                (GridRowIndex < gridAbsense.Rows.Count))
            {
                DataGridViewCell cell = gridAbsense.Rows[GridRowIndex].Cells[colHours.Index];
                if (Payroll.PrlAbsenseDataTable.HoursAndDaysLocked(Row))
                {
                    cell.ReadOnly = true;
                    cell.Style.BackColor = SystemColors.Control;
                }
                else
                {
                    cell.ReadOnly = false;
                    cell.Style.BackColor = SystemColors.Window;
                }
            }
        }
        #endregion

        private void PrlAbsense_Load(object sender, EventArgs e)
        {
            // loop the grid and toggle the Hours field
            // (must be done here inspite it is also done in LoadData,
            // as this event seems to reset the grid layout)
            foreach (DataGridViewRow row in gridAbsense.Rows)
            {
                if (row.DataBoundItem is DataRowView)
                    ToggleHoursField(((DataRowView)row.DataBoundItem).Row, row.Index);
            }
        }

        private void PrlAbsense_FormClosing(object sender, FormClosingEventArgs e)
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

        private void gridAbsense_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (bindingAbsense.Current == null) return;
            DataRowView row = (DataRowView)bindingAbsense.Current;
            if (e.RowIndex < 0) return;

            // when ending edit on certain fields, we need to refresh the grid,
            // as some data might have been calculated in base code.
            if ((e.ColumnIndex == colFromDateAsString.Index) ||
                (e.ColumnIndex == colToDateAsString.Index) ||
                (e.ColumnIndex == colHours.Index))
            {
                // when ending edit on fields FromDateAsString and ToDateAsString
                if ((e.ColumnIndex == colFromDateAsString.Index) ||
                    (e.ColumnIndex == colToDateAsString.Index))
                {
                    // toggle Hours field
                    ToggleHoursField(row.Row, e.RowIndex);
                }
                
                gridAbsense.Refresh();
                CalculateTotals();
            }
        }

        private void gridAbsense_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (bindingAbsense.Current == null) return;
            DataRowView row = (DataRowView)bindingAbsense.Current;

            // if user has added a row
            if (tools.IsNullOrDBNull(row["EmployeeNo"]))
            {
                // insert the selected employee id
                row["EmployeeNo"] = tools.object2int(comboEmployeeNo.SelectedValue);
            }
        }

        private void comboEmployeeNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // an employee has been selected

            // first save changes to this employee
            SaveData();

            // load data for the next employee
            LoadData(true);
        }

        private void gridAbsense_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // check that cells can be edited
            if (!VerifyIfFieldCanBeEdited(e.ColumnIndex))
                return;

            if (bindingAbsense.Current == null) return;
            DataRowView row = (DataRowView)bindingAbsense.Current;

            // if user clicks on the button to select an absense code
            if (e.ColumnIndex == colAbsenseCodeButton.Index)
            {
                SelectAbsenseCode(row);
            }
            // if user clicks on the button to select from date
            else if (e.ColumnIndex == colFromDatepPicker.Index)
            {
                if (UserIsFunc && !InputFuncAbsenseWithText)
                    SelectDateWithDateTimeDialog(row, "FromDateAsString");
            }
            // if user clicks on the button to select to date
            else if (e.ColumnIndex == colToDatePicker.Index)
            {
                if (UserIsFunc && !InputFuncAbsenseWithText)
                    SelectDateWithDateTimeDialog(row, "ToDateAsString");
            }
        }

        private void gridAbsense_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            ImageButtonRender.OnCellPainting(e, colAbsenseCodeButton.Index, ImageButtonRender.Images.LookupForm);
            if (UserIsFunc && !InputFuncAbsenseWithText)
            {
                ImageButtonRender.OnCellPainting(e, colFromDatepPicker.Index, ImageButtonRender.Images.DateTime);
                ImageButtonRender.OnCellPainting(e, colToDatePicker.Index, ImageButtonRender.Images.DateTime);
            }
            else
            {
                ImageButtonRender.OnCellPainting(e, colFromDatepPicker.Index, ImageButtonRender.Images.DateTimeGreyScale);
                ImageButtonRender.OnCellPainting(e, colToDatePicker.Index, ImageButtonRender.Images.DateTimeGreyScale);
            }
        }

        private void gridAbsense_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!VerifyIfFieldCanBeEdited(e.ColumnIndex))
                e.Cancel = true;
        }

        private void gridAbsense_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculateTotals();
        }

        private void gridAbsense_KeyUp(object sender, KeyEventArgs e)
        {
            // skip read-only cells
            if (gridAbsense.CurrentCell != null)
            {
                if (!UserIsFunc)
                {
                    if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
                    {
                        if (gridAbsense.CurrentCell.ColumnIndex == colDayNo.Index)
                        {
                            // jump from DayNo to FromDateAsString
                            gridAbsense.CurrentCell = gridAbsense[colFromDateAsString.Index, gridAbsense.CurrentCell.RowIndex];
                        }
                        else if (gridAbsense.CurrentCell.ColumnIndex == colFromDatepPicker.Index)
                        {
                            // jump from FromDatePicker to ToDateAsString
                            gridAbsense.CurrentCell = gridAbsense[colToDateAsString.Index, gridAbsense.CurrentCell.RowIndex];
                        }
                        else if (gridAbsense.CurrentCell.ColumnIndex == colToDatePicker.Index)
                        {
                            // jump from ToDatePicker to AbsenseCodeButton
                            gridAbsense.CurrentCell = gridAbsense[colAbsenseCodeButton.Index, gridAbsense.CurrentCell.RowIndex];
                            // autoopen absense code dialog
                            if (bindingAbsense.Current != null)
                            {
                                // user selects a value, continue to next field
                                if (SelectAbsenseCode((DataRowView)bindingAbsense.Current))
                                    SendKeys.Send("{TAB}");
                            }
                        }
                        else if (gridAbsense.CurrentCell.ColumnIndex == colAbsenseCodeDescription.Index)
                        {                            
                            if (!gridAbsense[colHours.Index, gridAbsense.CurrentCell.RowIndex].ReadOnly)
                            {
                                // if Hours is not readonly, jump from AbsenseCodeDescription to Hours
                                gridAbsense.CurrentCell = gridAbsense[colHours.Index, gridAbsense.CurrentCell.RowIndex];
                            }
                            else
                            {
                                // if Hours is readonly, jump to next line
                                // (will also hit a cell that itself jumps)
                                SendKeys.Send("{TAB}");
                                SendKeys.Send("{TAB}");
                            }
                        }
                        else if (gridAbsense.CurrentCell.ColumnIndex == colDays.Index)
                        {
                            // jump from Days to next line
                            SendKeys.Send("{TAB}");
                            SendKeys.Send("{TAB}");
                        }
                    }
                }
            }
        }

        private void gridAbsense_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (bindingAbsense.Current == null) return;
            DataRowView row = (DataRowView)bindingAbsense.Current;

            // if any of the required fields have not been filled
            // in when leaving the row, cancel the row.
            if (tools.IsNullOrDBNull(row["FromDateAsString"]) ||
                tools.IsNullOrDBNull(row["ToDateAsString"]) ||
                (tools.IsNullOrDBNull(row["Hours"]) && tools.IsNullOrDBNull(row["Days"])) ||
                tools.IsNullOrDBNull(row["AbsenseCode"]))
            {
                //gridAbsense.CancelEdit(); // causes crash if a record is deleted and form is closed
                bindingAbsense.CancelEdit();
            }
        }

        private void gridAbsense_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void gridAbsense_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            CalculateTotals();
        }
    }
}