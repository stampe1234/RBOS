using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class PrlRptAbsenseFrm : Form
    {
        public PrlRptAbsenseFrm()
        {
            InitializeComponent();
            LoadData();

            // localization
            btnClose.Text = db.GetLangString("Application.Close");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");
            lbSalaryPeriodNonFunc.Text = db.GetLangString("PrlRptAbsenseForm.lbSalaryPeriod");
        }

        private void LoadData()
        {
            adapterPrlSalaryPeriods.Connection = db.Connection;
            adapterPrlSalaryPeriods.Fill(dsPayroll.PrlSalaryPeriods);
            dsPayroll.PrlSalaryPeriods.FillPeriodStringColumn();
            Payroll.PrlSalaryPeriodsDataTable.SelectActiveSalaryPeriod(bindingPrlSalaryPeriods);
        }

        #region SQL
        private string SQL
        {
            get
            {
                return @"
select
  Str(ab.EmployeeNo) + '  ' + (emp.FirstName + ' ' + emp.LastName) as EmployeeNoAndName,
  '' as FromDayName,
  '' as ToDayName,
  ab.FromDateAsDateTime,
  ab.ToDateAsDateTime,
  ab.AbsenseCode,
  ac.Description as AbsenseCodeDesc,
  sum(ab.Hours) as Hours,
  sum(ab.Days) as Days
from ((PrlAbsense ab
inner join PrlEmployee emp
on ab.EmployeeNo = emp.EmployeeNo)
left join PrlLookupAbsenseCodes ac
on ab.AbsenseCode = ac.AbsenseCode)
where (ab.PeriodYear = {0})
and (ab.Period = {1})
group by
  ab.EmployeeNo,
  emp.FirstName,
  emp.LastName,
  ab.FromDateAsDateTime,
  ab.ToDateAsDateTime,
  ab.AbsenseCode,
  ac.Description
";
            }
        }
        #endregion

        /// <summary>
        /// A version of the form's print method that allows
        /// callers to invoke the print without showing the GUI.
        /// It requires the period to be given and whether previewing.
        /// </summary>
        public void Print(bool Preview, int PeriodYear, int Period)
        {
            // select the period
            int pos = -1;
            foreach (DataRowView row in bindingPrlSalaryPeriods)
            {
                ++pos;
                int tmpPeriodYear = tools.object2int(row["PeriodYear"]);
                int tmpPeriod = tools.object2int(row["Period"]);
                if ((PeriodYear == tmpPeriodYear) && (Period == tmpPeriod))
                {
                    bindingPrlSalaryPeriods.Position = pos;
                    break;
                }
            }

            Print(Preview);
        }

        private void Print(bool Preview)
        {
            if (bindingPrlSalaryPeriods.Current == null) return;

            // get salary period from selected salary period
            DataRow SelectedSalaryPeriod = ((DataRowView)bindingPrlSalaryPeriods.Current).Row;
            int PeriodYear = tools.object2int(SelectedSalaryPeriod["PeriodYear"]);
            int Period = tools.object2int(SelectedSalaryPeriod["Period"]);

            // load data
            Payroll.PrlRptAbsenseDataTable table = new Payroll.PrlRptAbsenseDataTable();
            string sql = string.Format(SQL, PeriodYear, Period);
            db.FillDataTable(sql, table, true);

            // check we have data
            if (table.Rows.Count > 0)
            {
                // fill FromDayName and ToDayName columns
                foreach (DataRow row in table.Rows)
                {
                    row["FromDayName"] = tools.object2datetime(row["FromDateAsDateTime"]).ToString("ddd");
                    row["ToDayName"] = tools.object2datetime(row["ToDateAsDateTime"]).ToString("ddd");
                }

                // assign data to report
                rptPrlAbsense.SetDataSource((DataTable)table);

                // set report site information
                tools.SetReportSiteInformation(rptPrlAbsense);

                // set report salary period text
                string SalaryPeriod = tools.object2string(SelectedSalaryPeriod["PeriodString"]);
                tools.SetReportObjectText(rptPrlAbsense, "txtSalaryPeriod", SalaryPeriod);

                // modify title
                if (bindingPrlSalaryPeriods.Current != null)
                {
                    DateTime ToDate = tools.object2datetime(SelectedSalaryPeriod["EndDate"]);
                    string title = "Fravær - " + ToDate.ToString("MMMM");
                    tools.SetReportObjectText(rptPrlAbsense, "txtTitle", title);
                }

                // print
                tools.Print(rptPrlAbsense, Preview);
            }
            else
            {
                MessageBox.Show(db.GetLangString("Application.NoDataToPrint"));
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
    }
}