using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class PrlRptLentOutFrm : Form
    {
        public PrlRptLentOutFrm()
        {
            InitializeComponent();
            LoadData();

            // localization
            btnClose.Text = db.GetLangString("Application.Close");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");
            lbSalaryPeriod.Text = db.GetLangString("PrlAll.lbPrlSalaryPeriod");
            lbFromDate.Text = db.GetLangString("PrlRptLentOutFrm.lbFromDate");
            lbToDate.Text = db.GetLangString("PrlRptLentOutFrm.lbToDate");
            lbSite.Text = db.GetLangString("PrlRptLentOutFrm.lbSite");
            lbEmployee.Text = db.GetLangString("PrlRptLentOutFrm.lbEmployee");
        }

        private void LoadData()
        {
            // load salary periods
            adapterSalaryPeriods.Connection = db.Connection;
            adapterSalaryPeriods.Fill(dsPayroll.PrlSalaryPeriods);
            dsPayroll.PrlSalaryPeriods.FillPeriodStringColumn();
            Payroll.PrlSalaryPeriodsDataTable.SelectActiveSalaryPeriod(bindingSalaryPeriods);
            

            // load cluster sites drop down data
            adapterClusterSites.Connection = db.Connection;
            adapterClusterSites.Fill(dsPayroll.PrlClusterSitesComboWithAll);
        }

        /// <summary>
        /// Loads data for the employee combo.
        /// Only employees with registrations in the selected
        /// salary period will be loaded.
        /// </summary>
        private void LoadEmployeeComboData()
        {
            // load employee drop down data
            adapterEmployees.Connection = db.Connection;
            adapterEmployees.FillHasTransactionsInProvidedPeriod(
                dsPayroll.PrlRptLentOutFrm_EmployeesCombo,
                Payroll.PrlEmployeeDataTable.LentEmployeeNo,
                dtFromDate.Value,
                dtToDate.Value);
        }

        private void Print(bool Preview)
        {
            // fill a table
            db.FillDataTable(SQL, dsPayroll.PrlRptLentOut, true);

            // check we have data
            if (dsPayroll.PrlRptLentOut.Rows.Count > 0)
            {
                // assign data to report
                rptLentOut.SetDataSource((DataTable)dsPayroll.PrlRptLentOut);

                // set report site information
                tools.SetReportSiteInformation(rptLentOut);

                // set report date interval
                string dateinterval = string.Format("{0:dd-MM-yyyy} - {1:dd-MM-yyyy}", dtFromDate.Value, dtToDate.Value);
                tools.SetReportObjectText(rptLentOut, "txtDateInterval", dateinterval);

                

#if RBA
                // in RBA mode, if Overtime/TakeTimeOff is disabled, don't show
                if (!db.GetConfigStringAsBool("Payroll.TakeTimeOffVisible"))
                    tools.SetReportObjectText(rptLentOut, "txtTakeTimeOff", "");
                if (!db.GetConfigStringAsBool("Payroll.OvertimeVisible"))
                    tools.SetReportObjectText(rptLentOut, "txtOvertime", "");
#endif

                // print
                tools.Print(rptLentOut, Preview, false);
            }
            else
            {
                MessageBox.Show(db.GetLangString("Application.NoDataToPrint"));
            }
        }

        #region SQL
        private string SQL
        {
            get
            {
                // get dates
                DateTime StartDate = dtFromDate.Value.Date;
                DateTime EndDate = dtToDate.Value.Date;

                // get sitecode (if any)
                string SiteCodeWhere = "";
                if (bindingClusterSites.Current != null)
                {
                    DataRowView rowClusterSites = (DataRowView)bindingClusterSites.Current;
                    string SiteCode = tools.object2string(rowClusterSites["SiteCode"]);
                    if (SiteCode != "0000")
                        SiteCodeWhere = string.Format(" and (sal.SiteCode = '{0}') ", SiteCode.Replace("'", "\""));
                }

                // get employeeno (if any)
                string EmployeeNoWhere = "";
                if (bindingEmployees.Current != null)
                {
                    DataRowView rowEmp = (DataRowView)bindingEmployees.Current;
                    int EmployeeNo = tools.object2int(rowEmp["EmployeeNo"]);
                    if (EmployeeNo > 0)
                        EmployeeNoWhere = string.Format(" and (sal.EmployeeNo = {0}) ", EmployeeNo);
                }

                return string.Format(@"
select
  sal.SiteCode,
  clu.SiteName,
  sal.EmployeeNo,
  (emp.FirstName + ' ' + emp.LastName) as EmployeeName,
  sal.RegDateAsDateTime,
  sal.Hours,
  sal.FromTimeAsString,
  sal.ToTimeAsString,
  Bonus1010,
  Bonus1020,
  Bonus1030,
  Bonus1040,
  Bonus1050,
  Overtime,
  TakeTimeOff,
  Remarks
from ((PrlSalaryRegistration sal
left join PrlClusterSites clu
on sal.SiteCode = clu.SiteCode)
inner join PrlEmployee emp
on sal.EmployeeNo = emp.EmployeeNo)
where (sal.SiteCode is not null) and (sal.SiteCode <> '')
and (sal.RegDateAsDateTime >= '{0}')
and (sal.RegDateAsDateTime <= '{1}')
and (sal.EmployeeNo <> {4})
{2} {3}
order by
  sal.SiteCode,
  sal.EmployeeNo,
  sal.RegDateAsDateTime,
  sal.FromTimeAsString,
  sal.ToTimeAsString
",
                    StartDate,
                    EndDate,
                    SiteCodeWhere,
                    EmployeeNoWhere,
                    Payroll.PrlEmployeeDataTable.LentEmployeeNo);
            }
        }
        #endregion

        private void PrlRptLentOutFrm_Load(object sender, EventArgs e)
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

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
            // set todate's minimum boundary to fromdate's value
            dtToDate.MinDate = dtFromDate.Value;

            LoadEmployeeComboData();
        }

        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {
            // set fromdate's maximum boundary to todate's value
            dtFromDate.MaxDate = dtToDate.Value;

            LoadEmployeeComboData();
        }

        private void bindingSalaryPeriods_CurrentChanged(object sender, EventArgs e)
        {
            // whenever the selected salary period changes...

            // get salary period start/end dates
            if (bindingSalaryPeriods.Current == null) return;
            DataRowView row = (DataRowView)bindingSalaryPeriods.Current;
            DateTime StartDate = tools.object2datetime(row["StartDate"]);
            DateTime EndDate = tools.object2datetime(row["EndDate"]);

            // remove previously set boundaries from datetime pickers
            dtFromDate.MaxDate = DateTimePicker.MaximumDateTime;
            dtToDate.MinDate = DateTimePicker.MinimumDateTime;

            // set datetime pickers to salary period dates
            dtFromDate.Value = StartDate;
            dtToDate.Value = EndDate;
        }
    }
}