using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class PrlRptWithdrawFrm : Form
    {
        #region Constructor
        public PrlRptWithdrawFrm()
        {
            InitializeComponent();
            LoadData();

            // localization
            btnClose.Text = db.GetLangString("Application.Close");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");
            lbDateInterval.Text = db.GetLangString("PrlRptWithdrawFrm.lbDateInterval");
            lbWithdrawType.Text = db.GetLangString("PrlRptWithdrawFrm.lbWithdrawType");
            lbEmployee.Text = db.GetLangString("PrlRptWithdrawFrm.lbEmployee");
        }
        #endregion

        #region LoadData
        private void LoadData()
        {
            adapterPrlWithdrawType.Connection = db.Connection;
            adapterPrlWithdrawType.Fill(dsPayroll.PrlWithdrawType);
        }
        #endregion

        private void SetInitialStartEndDates()
        {
            DateTime DateToPassIn, StartDate, EndDate;

            /// If an active salary period can be found,
            /// start/end dates are set to the first/last
            /// dates of the last date in the salary period.
            /// If an active salary period cannot be found,
            /// start/end dates are set to the current
            /// month's start/end dates.
            DataRow rowSalaryPeriod = Payroll.PrlSalaryPeriodsDataTable.GetActiveSalaryPeriod();
            if (rowSalaryPeriod != null)
                DateToPassIn = tools.object2datetime(rowSalaryPeriod["EndDate"]);
            else
                DateToPassIn = DateTime.Now;

            // set initial start/end dates
            tools.GetStartEndDatesInMonth(DateToPassIn, out StartDate, out EndDate);
            dtStartDate.Value = StartDate;
            dtEndDate.Value = EndDate;
        }

        /// <summary>
        /// Loads data for the employee combo.
        /// Only employees with registrations in the selected
        /// salary period will be loaded.
        /// </summary>
        private void LoadEmployeeComboData()
        {
            adapterPrlEmployeeComboWithAll.Connection = db.Connection;
            adapterPrlEmployeeComboWithAll.FillHasTransactionsInProvidedPeriod(
                dsPayroll.PrlEmployeeComboWithAll,
                dtStartDate.Value,
                dtEndDate.Value);
        }

        #region Print
        private void Print(bool Preview)
        {
            if (bindingPrlWithdrawType.Current == null) return;
            if (bindingPrlEmployeeComboWithAll.Current == null) return;

            // get selected date interval
            DateTime StartDate = dtStartDate.Value.Date;
            DateTime EndDate = dtEndDate.Value.Date;

            // get selected withdraw type
            DataRowView rowWithdrawType = (DataRowView)bindingPrlWithdrawType.Current;
            int WithdrawType = tools.object2int(rowWithdrawType["WithdrawType"]);

            // get selected employee and build employee where clause
            DataRowView rowEmp = (DataRowView)bindingPrlEmployeeComboWithAll.Current;
            int EmployeeNo = tools.object2int(rowEmp["EmployeeNo"]);
            string sEmployeeWhere = "";
            if (EmployeeNo > 0)
                sEmployeeWhere = string.Format(" and (w.EmployeeNo = {0}) ", EmployeeNo);

            // build SQL and load data
            DataTable table = db.GetDataTable(SQL(StartDate, EndDate, WithdrawType, sEmployeeWhere));

            // check we have data
            if (table.Rows.Count > 0)
            {
                // assign data to the report
                rptPrlRptWithdraw.SetDataSource(table);

                // set report site information
                tools.SetReportSiteInformation(rptPrlRptWithdraw);

                // set report title
                string sTitle = tools.object2string(rowWithdrawType["Description"]);
                tools.SetReportObjectText(rptPrlRptWithdraw, "txtTitle", sTitle);

                // set report date interval text object
                string sDateInterval = string.Format(
                    "{0} - {1}", StartDate.ToString("dd-MM-yyyy"), EndDate.ToString("dd-MM-yyyy"));
                tools.SetReportObjectText(rptPrlRptWithdraw, "txtDateInterval", sDateInterval);

                // print
                tools.Print(rptPrlRptWithdraw, Preview);
            }
            else
            {
                MessageBox.Show(db.GetLangString("Application.NoDataToPrint"));
            }
        }
        #endregion

        #region SQL
        private string SQL(DateTime StartDate, DateTime EndDate, int WithdrawType, string EmployeeWhereClause)
        {
            return string.Format(@"
select
  (str(w.EmployeeNo) + '  ' + emp.FirstName + ' ' + emp.LastName) as EmployeeNoAndName,
  w.DateReg,
  w.Remark,
  w.NumberOf,
  w.Amount
from (PrlWithdraw w
inner join PrlEmployee emp
on w.EmployeeNo = emp.EmployeeNo)
where (w.WithdrawType = {0}) {1}
and (w.DateReg >= '{2}')
and (w.DateReg <= '{3}')
order by w.EmployeeNo
"
                , WithdrawType, EmployeeWhereClause, StartDate, EndDate);
        }
        #endregion

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

        private void PrlRptWithdrawFrm_Load(object sender, EventArgs e)
        {
            SetInitialStartEndDates();
        }

        private void dtStartDate_ValueChanged(object sender, EventArgs e)
        {
            LoadEmployeeComboData();
        }

        private void dtEndDate_ValueChanged(object sender, EventArgs e)
        {
            LoadEmployeeComboData();
        }
    }
}