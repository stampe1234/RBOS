using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace RBOS
{
    public partial class PrlRptSalarySumFrmWk : Form
    {
        public PrlRptSalarySumFrmWk()
        {
            InitializeComponent();

            // localization
            btnClose.Text = db.GetLangString("Application.Close");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");
            lbText.Text = db.GetLangString("PrlRptSalarySumFrmWk.lbText");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Print(bool Preview)
        {
            int Week, Year;
            tools.GetISOWeekNumberFromDate(monthCalendar1.SelectionEnd, out Year, out Week);
            Payroll p = new Payroll();
            p.PrintEmployeeSalarySum(Preview, Week, Year);
        }

        private void EnforceWeekSelect()
        {
            // force select sunday
            int DayNo = tools.DayOfWeek2DayNo(monthCalendar1.SelectionEnd.DayOfWeek);
            monthCalendar1.SelectionEnd = monthCalendar1.SelectionEnd.AddDays(1 - DayNo + 6);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Print(true);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print(false);
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            EnforceWeekSelect();
        }

        private void PrlRptSalarySumFrmWk_Load(object sender, EventArgs e)
        {
            EnforceWeekSelect();
        }
    }
}