using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class PrlExportFrm : Form
    {
        public PrlExportFrm()
        {
            InitializeComponent();
            LoadData();

            // localization
            lbSalaryPeriod.Text = db.GetLangString("PrlAll.lbPrlSalaryPeriod");
            btnClose.Text = db.GetLangString("Application.Close");
            btnStart.Text = db.GetLangString("PrlExportFrm.btnStart");
        }

        private void LoadData()
        {
            adapterSalaryPeriods.Connection = db.Connection;
            adapterSalaryPeriods.FillExportable(dsPayroll.PrlSalaryPeriods);
            dsPayroll.PrlSalaryPeriods.FillPeriodStringColumn();
            Payroll.PrlSalaryPeriodsDataTable.SelectActiveSalaryPeriod(bindingSalaryPeriods);
        }        

        private void Export()
        {
            if (bindingSalaryPeriods.Current != null)
            {
                DataRow row = ((DataRowView)bindingSalaryPeriods.Current).Row;
                if (PrlExport.GeneratePRLFile(row))
                {
                    MessageBox.Show(db.GetLangString("PrlExportFrm.ExportFileCreated"));

                    // set salary period as not exported
                    Payroll.PrlSalaryPeriodsDataTable.SetSalaryPeriodExported(row);
                }
            }
        }

        private void PrlExportFrm_Load(object sender, EventArgs e)
        {
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}