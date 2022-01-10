using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class PrlRptSalaryEmpFrm : Form
    {
        public PrlRptSalaryEmpFrm()
        {
            InitializeComponent();
            LoadData();

            // localization
            btnClose.Text = db.GetLangString("Application.Close");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");
            lbSalaryPeriod.Text = db.GetLangString("PrlAll.lbPrlSalaryPeriod");
            lbEmployee.Text = db.GetLangString("PrlRptSalaryEmpForm.lbEmployee");
            chkPageBreakPerEmp.Text = db.GetLangString("PrlRptSalaryEmpFrm.chkPageBreakPerEmp");
        }

        private void LoadData()
        {
            // load data for Salary Periods combo
            adapterSalaryPeriods.Connection = db.Connection;
            adapterSalaryPeriods.Fill(dsPayroll.PrlSalaryPeriods);
            dsPayroll.PrlSalaryPeriods.FillPeriodStringColumn();
            Payroll.PrlSalaryPeriodsDataTable.SelectActiveSalaryPeriod(bindingSalaryPeriods);

            LoadEmployeeComboData();

            chkPageBreakPerEmp.Checked = db.GetConfigStringAsBool("PrlRptSalaryEmp.PageBreakAfterEmp");
        }

        private bool GetSelectedSalaryPeriod(out DateTime StartDate, out DateTime EndDate)
        {
            if (bindingSalaryPeriods.Current != null)
            {
                DataRow row = ((DataRowView)bindingSalaryPeriods.Current).Row;
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
                adapterEmployeeComboWithAll.Connection = db.Connection;
                adapterEmployeeComboWithAll.FillHasTransactionsInProvidedPeriod(
                    dsPayroll.PrlEmployeeComboWithAll, StartDate, EndDate);
            }
        }

        private void Print(bool Preview)
        {
            // make sure we have data to create filters
            if ((dsPayroll.PrlSalaryPeriods.Rows.Count > 0) &&
                (dsPayroll.PrlEmployeeComboWithAll.Rows.Count > 0) &&
                (bindingSalaryPeriods.Current != null) &&
                (bindingEmployeeComboWithAll.Current != null))
            {
                // get the selected salary period's StartDate and EndDate
                DataRowView rowSalaryPeriod = (DataRowView)bindingSalaryPeriods.Current;
                DateTime StartDate = tools.object2datetime(rowSalaryPeriod["StartDate"]);
                DateTime EndDate = tools.object2datetime(rowSalaryPeriod["EndDate"]);

                // get the selected employee and build sql string
                // (first item is all employees, EmployeeNo will be 0)
                string EmployeeSQL = "";
                DataRowView rowEmployee = (DataRowView)bindingEmployeeComboWithAll.Current;
                if (tools.object2int(rowEmployee["EmployeeNo"]) != 0)
                {
                    EmployeeSQL = string.Format(
                        " and (PrlSalaryRegistration.EmployeeNo = {0}) ",
                        tools.object2int(rowEmployee["EmployeeNo"]));
                }

                // load salary registration data
                string sql = string.Format(
                    " select " +
                    "  PrlSalaryRegistration.*, " +
                    "  (PrlEmployee.FirstName + ' ' + PrlEmployee.LastName) as EmployeeName " + 
                    " from (PrlSalaryRegistration " +
                    " inner join PrlEmployee " +
                    " on PrlSalaryRegistration.EmployeeNo = PrlEmployee.EmployeeNo) " +
                    " where (RegDateAsDateTime >= '{0}') " +
                    " and (RegDateAsDateTime <= '{1}') " +
                    " {2} " +
                    " order by PrlSalaryRegistration.EmployeeNo, RegDateAsDateTime ",
                    StartDate.Date, EndDate.Date, EmployeeSQL);
                db.FillDataTable(sql, dsPayroll.PrlRptSalaryEmp, true);                    

                // check we have data
                if (dsPayroll.PrlRptSalaryEmp.Rows.Count > 0)
                {
                    // load paramter data
                    dsPayroll.PrlRptSalaryEmp_params.Clear();
                    dsPayroll.PrlRptSalaryEmp_params.Rows.Add(chkPageBreakPerEmp.Checked);

                    // assign data to report
                    rptPrlSalaryEmp.SetDataSource(dsPayroll);

                    // set misc report information
                    tools.SetReportSiteInformation(rptPrlSalaryEmp);
                    tools.SetReportObjectText(rptPrlSalaryEmp, "txtSalaryPeriod",
                        tools.object2string(rowSalaryPeriod["PeriodString"]));

                    string title = "Løndata pr. medarbejder - " + EndDate.ToString("MMMM");
                    tools.SetReportObjectText(rptPrlSalaryEmp, "txtTitle",  title);
                    

#if RBA
                    // in RBA mode, if Overtime/TakeTimeOff is disabled, don't show
                    if (!db.GetConfigStringAsBool("Payroll.TakeTimeOffVisible"))
                        tools.SetReportObjectText(rptPrlSalaryEmp, "txtTakeTimeOff", "");
                    if (!db.GetConfigStringAsBool("Payroll.OvertimeVisible"))
                        tools.SetReportObjectText(rptPrlSalaryEmp, "txtOvertime", "");
#endif

                    // print report
                    tools.Print(rptPrlSalaryEmp, Preview);
                }
                else
                {
                    MessageBox.Show(db.GetLangString("Application.NoDataToPrint"));
                }
            }
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

        private void PrlRptSalaryEmpFrm_Load(object sender, EventArgs e)
        {
        }

        private void chkPageBreakPerEmp_CheckedChanged(object sender, EventArgs e)
        {
            db.SetConfigString("PrlRptSalaryEmp.PageBreakAfterEmp", chkPageBreakPerEmp.Checked);
        }

        private void comboSalaryPeriods_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void bindingSalaryPeriods_PositionChanged(object sender, EventArgs e)
        {
            LoadEmployeeComboData();
        }
    }
}