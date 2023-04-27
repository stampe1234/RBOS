using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Text.RegularExpressions;

namespace RBOS
{
    public partial class BkdInvCountIntvFrm : Form
    {
        #region Constructor
        public BkdInvCountIntvFrm()
        {
            InitializeComponent();
        }
        #endregion

        #region METHOD: Print
        private void Print(bool Preview)
        {
            // load data
            adapter.Connection = db.Connection;
            adapter.Fill(
                dsReport.BkdInvCountIntv,
                dtStartDate.Value.Date,
                dtEndDate.Value.Date);

            // check that any data were loaded
            if (dsReport.BkdInvCountIntv.Rows.Count <= 0)
            {
                MessageBox.Show(db.GetLangString("BkdInvCountIntvFrm.NoDataToBePrinted"));
                return;
            }
            
            // set report's data source
            report.SetDataSource((DataTable)dsReport.BkdInvCountIntv);

            // set unbound report header values
            ReportObjects reportObjects = report.ReportDefinition.ReportObjects;
            TextObject toStartDate = (TextObject)reportObjects["txtStartDate"];
            TextObject toEndDate = (TextObject)reportObjects["txtEndDate"];
            toStartDate.Text = dtStartDate.Value.ToString("dd-MM-yyyy");
            toEndDate.Text = dtEndDate.Value.ToString("dd-MM-yyyy");

            // Site information
            tools.SetReportSiteInformation(report);

            // print the report
            tools.Print(report, Preview);
        }
        #endregion

        // btnPrint click event
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print(false);
        }

        // btnPreview click event
        private void btnPreview_Click(object sender, EventArgs e)
        {
            Print(true);
        }

        // close button click event
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ItemSalesSumForm_Load(object sender, EventArgs e)
        {
            // localization
            lbPostingDateStart.Text = db.GetLangString("BkdInvCountIntvFrm.lbPostingDateStart");
            lbPostingDateEnd.Text = db.GetLangString("BkdInvCountIntvFrm.lbPostingDateEnd");
            btnClose.Text = db.GetLangString("Application.Close");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");
        }
    }
}