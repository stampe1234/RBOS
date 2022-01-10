using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class PrlRptSalarySumFrm : Form
    {
        public PrlRptSalarySumFrm()
        {
            InitializeComponent();
            LoadData();

            // localization
            btnClose.Text = db.GetLangString("Application.Close");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");
            lbSalaryPeriod.Text = db.GetLangString("PrlAll.lbPrlSalaryPeriod");
            chkIncludeAbsense.Text = db.GetLangString("PrlRptSalarySumFrm.chkIncludeAbsense");
        }

        private void LoadData()
        {
            // load data for Salary Periods combo
            adapterSalaryPeriods.Connection = db.Connection;
            adapterSalaryPeriods.Fill(dsPayroll.PrlSalaryPeriods);
            dsPayroll.PrlSalaryPeriods.FillPeriodStringColumn();
            Payroll.PrlSalaryPeriodsDataTable.SelectActiveSalaryPeriod(bindingSalaryPeriods);
            chkIncludeAbsense.Checked = db.GetConfigStringAsBool("PrlRptSalarySumFrm.chkIncludeAbsense");
        }

        private void SaveData()
        {
            db.SetConfigString("PrlRptSalarySumFrm.chkIncludeAbsense", chkIncludeAbsense.Checked);
        }

        private void Print(bool Preview)
        {
            if ((dsPayroll.PrlSalaryPeriods.Rows.Count > 0) &&
                (bindingSalaryPeriods.Current != null))
            {
                DataRow row = ((DataRowView)bindingSalaryPeriods.Current).Row;
                dsPayroll.PrintEmployeeSalarySum(Preview, row);
                
                if (chkIncludeAbsense.Checked)
                {
                    using (PrlRptAbsenseFrm absense = new PrlRptAbsenseFrm())
                    {
                        int PeriodYear = tools.object2int(row["PeriodYear"]);
                        int Period = tools.object2int(row["Period"]);
                        absense.Print(Preview, PeriodYear, Period);
                    }
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

        private void PrlRptSalarySumFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
        }
    }
}