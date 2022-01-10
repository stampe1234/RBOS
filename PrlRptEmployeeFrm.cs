using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class PrlRptEmployeeFrm : Form
    {
        public PrlRptEmployeeFrm()
        {
            InitializeComponent();
            LoadData();

            // localization
            btnClose.Text = db.GetLangString("Application.Close");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            lbEmployee.Text = db.GetLangString("PrlRptEmployee.lbEmployee");
            lbOrdering.Text = db.GetLangString("PrlPrtEmployee.lbOrdering");
            chkIncludeInactive.Text = db.GetLangString("PrlRptEmployeeFrm.chkIncludeInactive");
        }

        private void LoadData()
        {
            // create employee combo list
            comboEmployee.Items.Clear();
            comboEmployee.Items.Add(db.GetLangString("PrlRptEmployee.comboEmployee.Index0"));
            comboEmployee.Items.Add(db.GetLangString("PrlRptEmployee.comboEmployee.Index1"));
            comboEmployee.Items.Add(db.GetLangString("PrlRptEmployee.comboEmployee.Index2"));

            // create ordering list
            comboOrdering.Items.Clear();
            comboOrdering.Items.Add(db.GetLangString("PrlRptEmployee.comboOrdering.Index0"));
            comboOrdering.Items.Add(db.GetLangString("PrlRptEmployee.comboOrdering.Index1"));
            comboOrdering.Items.Add(db.GetLangString("PrlRptEmployee.comboOrdering.Index2"));

            // preselect first item in the two lists
            if (comboEmployee.Items.Count > 0)
                comboEmployee.SelectedIndex = 0;
            if (comboOrdering.Items.Count > 0)
                comboOrdering.SelectedIndex = 0;
        }

        private void Print(bool Preview)
        {
            // get selected filter criteria
            string Filter = " where (EmployeeNo <> " + Payroll.PrlEmployeeDataTable.LentEmployeeNo.ToString() + ") ";
            if (comboEmployee.SelectedIndex == 1)
                Filter += " and ( EndDate is NULL ) ";
            else if (comboEmployee.SelectedIndex == 2)
                Filter += " and ( EndDate is not NULL ) ";
            
            // add filter if only including active employees
            if (!chkIncludeInactive.Checked)
            {
                DataRow ActiveSalaryPeriod = Payroll.PrlSalaryPeriodsDataTable.GetActiveSalaryPeriod();
                DateTime SalaryPeriodStartDate = tools.object2datetime(ActiveSalaryPeriod["StartDate"]);
                if (ActiveSalaryPeriod != null)
                    Filter += string.Format(" and ((InactiveDate IS NULL) OR (InactiveDate >= '{0}')) ", SalaryPeriodStartDate.Date);
            }

            // get selected ordering
            string Ordering = " order by";
            if (comboOrdering.SelectedIndex == 0) Ordering += " EmployeeNo ";
            else if (comboOrdering.SelectedIndex == 1) Ordering += " FirstName ";
            else if (comboOrdering.SelectedIndex == 2) Ordering += " LastName ";

            // load data (same fields as in adapter Payroll.PrlRptEmployee)
            DataTable table = db.GetDataTable(string.Format(
                " select EmployeeNo, FirstName, LastName, Address1, Address2, ZipCode, City, Phone, ContactPhone, Left(CPR,6) as CPR, Post, StartDate, EndDate, EmployeeType, FuncHours, Education, NotIncludedInReg, IsFunc, InactiveDate, " +
                " (FirstName + ' ' + LastName) as FullName, " +
                " case when Education = 1 then 'Ja' else '' end as EducationString " +
                " from PrlEmployee {0} {1} ",
                Filter, Ordering));

            // check we have data
            if (table.Rows.Count > 0)
            {
                // set additional report information
                tools.SetReportObjectText(rptPrlEmployee, "txtMedarbejder", tools.object2string(comboEmployee.SelectedItem));
                tools.SetReportObjectText(rptPrlEmployee, "txtSortering", tools.object2string(comboOrdering.SelectedItem));
                tools.SetReportSiteInformation(rptPrlEmployee);

                // assign data to report
                rptPrlEmployee.SetDataSource(table);

                // print
                tools.Print(rptPrlEmployee, Preview);
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