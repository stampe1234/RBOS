using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class PrlRptSalaryDateFrm : Form
    {
        public PrlRptSalaryDateFrm()
        {
            InitializeComponent();

            // localization
            btnClose.Text = db.GetLangString("Application.Close");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");
            lbDate.Text = db.GetLangString("PrlRptSalaryForm.lbDate");
            lbOrderBy.Text = db.GetLangString("PrlRptSalaryForm.lbOrderBy");

            FillComboBox();
        }

        private void FillComboBox()
        {
            // fill combo with localized strings
            comboOrderBy.Items.Clear();
            comboOrderBy.Items.Add(db.GetLangString("PrlRptSalaryForm.comboOrderBy.Index0"));
            comboOrderBy.Items.Add(db.GetLangString("PrlRptSalaryForm.comboOrderBy.Index1"));
            comboOrderBy.Items.Add(db.GetLangString("PrlRptSalaryForm.comboOrderBy.Index2"));
            comboOrderBy.Items.Add(db.GetLangString("PrlRptSalaryForm.comboOrderBy.Index3"));

            // by default select first item in combobox
            if (comboOrderBy.Items.Count > 0)
                comboOrderBy.SelectedIndex = 0;
        }

        #region SQL
        private string SQL
        {
            get
            {
                return @"
select
  reg.EmployeeNo,
  (emp.FirstName + ' ' + emp.LastName) as EmployeeName,
  reg.FromTimeAsString,
  reg.ToTimeAsString,
  reg.Hours,
  reg.Bonus1010,
  reg.Bonus1020,
  reg.Bonus1030,
  reg.Bonus1040,
  reg.Bonus1050,
  reg.Overtime,
  reg.TakeTimeOff,
  reg.SiteCode,
  reg.Remarks
from (PrlSalaryRegistration reg
inner join PrlEmployee emp
on reg.EmployeeNo = emp.EmployeeNo)
where (reg.RegDateAsDateTime = '{0}')
order by {1}
";
            }
        }
        #endregion

        private void Print(bool Preview)
        {
            // get the selected date
            DateTime SelectedDate = dtDate.Value.Date;

            // get the selected order by
            string OrderBy;
            switch (comboOrderBy.SelectedIndex)
            {
                case 1: OrderBy = "emp.FirstName"; break;
                case 2: OrderBy = "emp.LastName"; break;
                case 3: OrderBy = "reg.FromTimeAsString"; break;
                default: OrderBy = "reg.EmployeeNo"; break;
            }

            // load data
            DataTable table = db.GetDataTable(string.Format(SQL, SelectedDate, OrderBy));

            // check we have data
            if (table.Rows.Count > 0)
            {
                // assign data to report
                rptPrlRptSalaryDate.SetDataSource(table);

                // set report site information
                tools.SetReportSiteInformation(rptPrlRptSalaryDate);

                // set report title
                string title = string.Format(SelectedDate.ToString("{0} dddd {1} dd-MM-yyyy"), "Løndata", "den");
                tools.SetReportObjectText(rptPrlRptSalaryDate, "txtTitle", title);

                // set report order by text
                string OrderByText = "Sortering: " + tools.object2string(comboOrderBy.SelectedItem);
                tools.SetReportObjectText(rptPrlRptSalaryDate, "txtOrderBy", OrderByText);

#if RBA
                // in RBA mode, if Overtime/TakeTimeOff is disabled, don't show
                if (!db.GetConfigStringAsBool("Payroll.TakeTimeOffVisible"))
                    tools.SetReportObjectText(rptPrlRptSalaryDate, "txtTakeTimeOff", "");
                if (!db.GetConfigStringAsBool("Payroll.OvertimeVisible"))
                    tools.SetReportObjectText(rptPrlRptSalaryDate, "txtOvertime", "");
#endif

                // print the report
                tools.Print(rptPrlRptSalaryDate, Preview, false);
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