using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class PrlRptSalRegFrm : Form
    {
        public PrlRptSalRegFrm()
        {
            InitializeComponent();
            LoadData();

            // localization
            btnClose.Text = db.GetLangString("Application.Close");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");
            lbEmployee.Text = db.GetLangString("PrlRptSalRegFrm.lbEmployee");
            lbSalaryPeriod.Text = db.GetLangString("PrlRptSalRegFrm.lbSalaryPeriod");
            chkIncludeFunc.Text = db.GetLangString("PrlRptSalRegFrm.chkIncludeFunc");
        }

        private void LoadData()
        {
            adapterPrlSalaryPeriods.Connection = db.Connection;
            adapterPrlSalaryPeriods.Fill(dsPayroll.PrlSalaryPeriods);
            dsPayroll.PrlSalaryPeriods.FillPeriodStringColumn();
            Payroll.PrlSalaryPeriodsDataTable.SelectActiveSalaryPeriod(bindingPrlSalaryPeriods);            
        }

        private bool GetSelectedSalaryPeriod(out DateTime StartDate, out DateTime EndDate)
        {
            if (bindingPrlSalaryPeriods.Current != null)
            {
                DataRow row = ((DataRowView)bindingPrlSalaryPeriods.Current).Row;
                StartDate = tools.object2datetime(row["StartDate"]);
                EndDate = tools.object2datetime(row["EndDate"]);
                return true;
            }
            else
            {
                StartDate = DateTime.MinValue;
                EndDate = DateTime.MinValue;
                return false;
            }
        }

        /// <summary>
        /// Loads data for the employee combo.
        /// Only employees with registrations in the selected
        /// salary period will be loaded.
        /// </summary>
        private void LoadEmployeeComboData()
        {
            DateTime StartDate, EndDate;
            if (GetSelectedSalaryPeriod(out StartDate, out EndDate))
            {
                adapterPrlEmployeeComboWithAll.Connection = db.Connection;
                adapterPrlEmployeeComboWithAll.FillActiveInProvidedPeriod(
                    dsPayroll.PrlEmployeeComboWithAll, StartDate);
            }
        }

        private void Print(bool Preview)
        {
            // get salary period binding object
            if (bindingPrlSalaryPeriods.Current == null) return;
            DataRowView RowSalaryPeriods = (DataRowView)bindingPrlSalaryPeriods.Current;

            // clear Payroll.PrlRptSalReg table
            dsPayroll.PrlRptSalReg.Clear();

            // get salary period start/end dates
            DateTime StartDate = tools.object2datetime(RowSalaryPeriods["StartDate"]);
            DateTime EndDate = tools.object2datetime(RowSalaryPeriods["EndDate"]);

            // get a list of employee and for each employee
            // we build a schema with all the dates in the salary period
            DataTable Employees = GetEmployees();
            foreach (DataRow rowEmp in Employees.Rows)
            {
                for (DateTime date = StartDate; date <= EndDate; date = date.AddDays(1))
                {
                    DataRow row = dsPayroll.PrlRptSalReg.NewRow();
                    row["EmployeeNameAndNo"] = tools.object2string(rowEmp["EmployeeNameAndNo"]);
                    row["WeekDay"] = date.Date.ToString("dddd");
                    row["RegDate"] = date.Date.ToString("dd-MM-yyyy");

                    // each new row is added to Payroll.PrlRptSalReg table
                    dsPayroll.PrlRptSalReg.Rows.Add(row);
                }
            }

            // check we have data
            if (dsPayroll.PrlRptSalReg.Rows.Count > 0)
            {
                // set report site information
                tools.SetReportSiteInformation(rptSalReg);

                // set report period string
                string PeriodString = tools.object2string(RowSalaryPeriods["PeriodString"]);
                tools.SetReportObjectText(rptSalReg, "txtSalaryPeriod", PeriodString);

                // modify title
                string title = "Lønregistreringsskema - " + EndDate.ToString("MMMM");
                tools.SetReportObjectText(rptSalReg, "txtTitle", title);

                // set report data and print
                rptSalReg.SetDataSource((DataTable)dsPayroll.PrlRptSalReg);
                tools.Print(rptSalReg, Preview);
            }
            else
            {
                MessageBox.Show(db.GetLangString("Application.NoDataToPrint"));
            }
        }

        #region GetEmployees
        /// <summary>
        /// Returns a list of employees based on the employee selection in the gui.
        /// Read the field "EmployeeNameAndNo" to get the list data.
        /// </summary>
        private DataTable GetEmployees()
        {
            if (bindingPrlEmployeeComboWithAll.Current == null) return new DataTable();
            DataRowView RowEmployee = (DataRowView)bindingPrlEmployeeComboWithAll.Current;

            // build sql
            string sql = string.Format(@"
                select emp.FirstName + ' ' + emp.LastName + ' (' + str(emp.EmployeeNo) + ')' as EmployeeNameAndNo
                from PrlEmployee emp
                ");

            // build where clause
            int EmployeeNo = tools.object2int(RowEmployee["EmployeeNo"]);
            if (EmployeeNo > 0)
            {
                // a single employee has been selected
                sql += string.Format(" where (EmployeeNo = {0}) ", EmployeeNo);
            }
            else // all employees selected
            {
                DateTime StartDate, EndDate;
                GetSelectedSalaryPeriod(out StartDate, out EndDate);
                string skipFunc = !chkIncludeFunc.Checked ? " and (IsFunc <> 1) " : "";
                sql += string.Format(@" WHERE ((InactiveDate IS NULL) OR (InactiveDate >= '{0}')) {1} ",
                    StartDate.Date, skipFunc);
            }

            // append order by to sql
            sql += " order by 1 ";

            // get and return data
            return db.GetDataTable(sql);
        }
        #endregion

        private void ToggleIncludeFuncCheckbox()
        {
            if (bindingPrlEmployeeComboWithAll.Current == null) return;
            DataRowView row = (DataRowView)bindingPrlEmployeeComboWithAll.Current;
            chkIncludeFunc.Enabled = (tools.object2int(row["EmployeeNo"]) <= 0);
            if (!chkIncludeFunc.Enabled)
                chkIncludeFunc.Checked = false;
        }

        private void PrlRptSalRegFrm_Load(object sender, EventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Print(true);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print(false);
        }

        private void bindingPrlEmployeeComboWithAll_PositionChanged(object sender, EventArgs e)
        {
            ToggleIncludeFuncCheckbox();
        }

        private void bindingPrlSalaryPeriods_PositionChanged(object sender, EventArgs e)
        {
            LoadEmployeeComboData();
        }
    }
}