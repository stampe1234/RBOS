using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class PrlRptAvgHrsWeekFrm : Form
    {
        public PrlRptAvgHrsWeekFrm()
        {
            InitializeComponent();
            LoadData();

            // localization
            btnClose.Text = db.GetLangString("Application.Close");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");
            lbEmployee.Text = db.GetLangString("PrlRptAvgHrsWeekFrm.lbEmployee");
            lbStartWeek.Text = db.GetLangString("PrlRptAvgHrsWeekFrm.lbStartWeek");
            lbEndWeek.Text = db.GetLangString("PrlRptAvgHrsWeekFrm.lbEndWeek");
            lbNumWeeks.Text = db.GetLangString("PrlRptAvgHrsWeekFrm.lbNumWeeks");
        }

        private void LoadData()
        {
            // load employee dropdown data
            adapterEmployee.Connection = db.Connection;
        }

        /// <summary>
        /// Loads data for the employee combo.
        /// Only employees with registrations in the selected
        /// salary period will be loaded.
        /// </summary>
        private void LoadEmployeeComboData()
        {
            adapterEmployee.Connection = db.Connection;
            adapterEmployee.FillHasTransactionsInProvidedPeriod(
                dsPayroll.PrlEmployeeComboWithAll,
                dtStartWeek.Value,
                dtEndWeek.Value);
        }

        /// <summary>
        /// Calculates number of weeks between the two
        /// selected dates. Two dates in the same week gives one week.
        /// Sets the txtNumWeeks.Text field with the number of weeks
        /// as well as returning this value as an integer.
        /// </summary>
        private int CalculateNumWeeks()
        {
            TimeSpan span = dtEndWeek.Value.Date - dtStartWeek.Value.Date;
            int weeks = (span.Days / 7) + 1;
            txtNumWeeks.Text = weeks.ToString();
            return weeks;
        }

        private void Print(bool Preview)
        {
            // prepare variables for loading data
            DateTime StartDate = dtStartWeek.Value.Date;
            DateTime EndDate = dtEndWeek.Value.Date;
            double TotalHoursAcrossEmployees =
                Payroll.PrlSalaryRegistrationDataTable.CalculateTotalHoursAcrossEmployees(StartDate, EndDate);

            // load data
            db.FillDataTable(
                SQL(StartDate, EndDate, TotalHoursAcrossEmployees),
                dsPayroll.PrlRptAvgHrsWeek,
                true);

            // check we have data
            if (dsPayroll.PrlRptAvgHrsWeek.Rows.Count > 0)
            {
                // assign data to report
                rptAvgHrsWeek.SetDataSource((DataTable)dsPayroll.PrlRptAvgHrsWeek);

                // set report siteinformation
                tools.SetReportSiteInformation(rptAvgHrsWeek);

                // set report start/end dates
                string StartEndDates =
                    dtStartWeek.Value.ToString("dd-MM-yyyy") + " - " +
                    dtEndWeek.Value.ToString("dd-MM-yyyy");
                tools.SetReportObjectText(rptAvgHrsWeek, "txtStartEndDates", StartEndDates);

                // set report num weeks
                tools.SetReportObjectText(rptAvgHrsWeek, "txtNumWeeks", CalculateNumWeeks().ToString());

                // set total number of hours across employees
                tools.SetReportObjectText(rptAvgHrsWeek, "TotalHours", TotalHoursAcrossEmployees.ToString("n2"));

                // print
                tools.Print(rptAvgHrsWeek, Preview);
            }
            else
            {
                MessageBox.Show(db.GetLangString("Application.NoDataToPrint"));
            }
        }

        private string SQL(DateTime StartDate, DateTime EndDate, double TotalHoursAcrossEmployees)
        {
            // calculate number of weeks
            int NumWeeks = CalculateNumWeeks();

            StartDate = StartDate.Date;
            EndDate = EndDate.Date;

            // get hour limits
            int MinorLimit = db.GetConfigStringAsInt("Payroll.AvgHrsMinorLimit");
            int MajorLimit = db.GetConfigStringAsInt("Payroll.AvgHrsMajorLimit");

            // build where clause
            string where = "";
            if (bindingEmployee.Current != null)
            {
                DataRowView row = (DataRowView)bindingEmployee.Current;
                int EmployeeNo = tools.object2int(row["EmployeeNo"]);
                if (EmployeeNo > 0)
                {
                    where = string.Format(" and (sal.EmployeeNo = {0}) ", EmployeeNo);
                }
            }

            // build and return sql
            return string.Format(@"
                 select
                  (cast(sal.EmployeeNo as nvarchar(20)) + ' ' + emp.FirstName + ' ' + emp.LastName) as EmployeeNoAndName,
                  sum(sal.Hours) as TotalHours,
                  (sum(sal.Hours) / {0}) as AvgHours,
                  ((sum(sal.Hours) / ({6})) * 100) as Percentage,
                  case when (sum(sal.Hours) / {0}) < {3} then '' when (sum(sal.Hours) / {0}) < {4} then '*' else '**' end as Stars -- changed IIF
                from (PrlSalaryRegistration sal
                inner join PrlEmployee emp
                on sal.EmployeeNo = emp.EmployeeNo)
                where (sal.RegDateAsDateTime >= '{1}')
                and (sal.RegDateAsDateTime <= '{2}')
                {5}
                group by
                  sal.EmployeeNo,
                  emp.FirstName,
                  emp.LastName
                
                ",
                NumWeeks,
                StartDate.Date,
                EndDate.Date,
                MinorLimit,
                MajorLimit,
                where,
                tools.decimalnumber4sql(TotalHoursAcrossEmployees));
        }

        private void EnforceWeekSelect(DateTimePicker dt)
        {
            // force select sunday
            int DayNo = tools.DayOfWeek2DayNo(dt.Value.DayOfWeek);
            dt.Value = dt.Value.AddDays(1 - DayNo + 6);
        }

        private void PrlRptAvgHrsWeekFrm_Load(object sender, EventArgs e)
        {
            // set enddate to the sunday of the last finished week
            // (-6 as if we are on sunday today, this week is the last finished week)
            // (sunday is automatically selected)
            dtEndWeek.Value = DateTime.Now.Date.AddDays(-6);

            // set startdate to 12 weeks before enddate
            // (sunday is automatically selected)
            dtStartWeek.Value = dtEndWeek.Value.AddDays(-(7*(12-1))); // -1 because two dates in the same week gives 1 week.

            // calculate initial number of weeks
            CalculateNumWeeks();
        }

        private void dtStartWeek_ValueChanged(object sender, EventArgs e)
        {
            EnforceWeekSelect(dtStartWeek);
            CalculateNumWeeks();
            dtEndWeek.MinDate = dtStartWeek.Value; // avoid date overlap
            LoadEmployeeComboData();
        }

        private void dtEndWeek_ValueChanged(object sender, EventArgs e)
        {
            EnforceWeekSelect(dtEndWeek);
            CalculateNumWeeks();
            dtStartWeek.MaxDate = dtEndWeek.Value; // avoid date overlap
            LoadEmployeeComboData();
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
    }
}