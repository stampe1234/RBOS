using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class DisktilbudSolgtRptFrm : Form
    {
        private string AlleKampagneIDs = "";

        public DisktilbudSolgtRptFrm()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            // localization
            Text = db.GetLangString("DisktilbudRptFrm.Title");
            btnClose.Text = db.GetLangString("Application.Close");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            lbFromToDates.Text = db.GetLangString("DisktilbudRptFrm.lbFromToDates");
            lbDetails.Text = db.GetLangString("DisktilbudRptFrm.lbDetails");
            lbItemDetails.Text = db.GetLangString("DisktilbudRptFrm.lbItemDetails");
            lbKampagneID.Text = db.GetLangString("DisktilbudSolgtRptFrm.lbKampagneID");
            AlleKampagneIDs = db.GetLangString("DisktilbudSolgtRptFrm.AllKampagneIDs");
        }

        private void FillDisktlbudIDList()
        {
            // get selected dates
            DateTime StartDate = dtFromDate.Value.Date;
            DateTime EndDate = dtToDate.Value.Date;
            
            // get the list of KampagneIDs and add an "All" at the top
            List<int> iList = EODDataSet.DisktilbudSolgtDataTable.GetKampagneIDsInPeriod(StartDate, EndDate);
            List<string> sList = new List<string>();
            sList.Add(AlleKampagneIDs);
            foreach (int i in iList)
                sList.Add(i.ToString());
            comboKampagneID.DataSource = sList;
            if (comboKampagneID.Items.Count > 0)
                comboKampagneID.SelectedIndex = 0; // select the All entry by default
            else
            {
                comboKampagneID.SelectedIndex = -1;
                comboKampagneID.Text = "";
            }
        }

        private void InitialzeDateTimePickers()
        {
            // initially set both date time pickers to the day before the current day
            DateTime Yesterday = DateTime.Now.AddDays(-1).Date;
            dtFromDate.Value = Yesterday;
            dtToDate.Value = Yesterday;
        }

        private void Print(bool Preview)
        {
            EODDataSetTableAdapters.CashierReportTableAdapter adapterCashier =
                new RBOS.EODDataSetTableAdapters.CashierReportTableAdapter();
            EODDataSetTableAdapters.DisktilbudSolgtReportTableAdapter adapterDisktilbudSolgt =
                new RBOS.EODDataSetTableAdapters.DisktilbudSolgtReportTableAdapter();
            EODDataSetTableAdapters.DisktilbudSolgtDetaljerReportTableAdapter adapterDisktilbudSolgtDetaljer =
                new RBOS.EODDataSetTableAdapters.DisktilbudSolgtDetaljerReportTableAdapter();

            adapterCashier.Connection = db.Connection;
            adapterDisktilbudSolgt.Connection = db.Connection;
            adapterDisktilbudSolgtDetaljer.Connection = db.Connection;

            EODDataSet dsEOD = new EODDataSet();
            DateTime FromDate = dtFromDate.Value.Date;
            DateTime ToDate = dtToDate.Value.Date;

            int SelectedKampagneID = tools.object2int(comboKampagneID.Text); // must use the Text property, as user can enter a value that does not exist in the list

            // note that we have to load all data,
            // even if we haven't selected it in the interface,
            // as it is needed for the report to calculate totals.
            adapterCashier.Fill(dsEOD.CashierReport);
            dsEOD.CashierSalesReport.LoadData(FromDate, ToDate, tools.object2int(comboKampagneID.SelectedValue));
            if (SelectedKampagneID > 0)
                adapterDisktilbudSolgt.Fill2(dsEOD.DisktilbudSolgtReport, FromDate, ToDate, SelectedKampagneID);
            else
                adapterDisktilbudSolgt.Fill(dsEOD.DisktilbudSolgtReport, FromDate, ToDate);
            adapterDisktilbudSolgtDetaljer.Fill(dsEOD.DisktilbudSolgtDetaljerReport, FromDate, ToDate);

            int AntalKunder = EODDataSet.EODReconcileExDataTable.GetCustomerCount(FromDate, ToDate);
            dsEOD.DisktilbudSolgtReportParams.Rows.Add(chkDetails.Checked, chkItemDetails.Checked, AntalKunder);

            DisktilbudSolgtRpt report = new DisktilbudSolgtRpt();            
            report.SetDataSource(dsEOD);
            tools.SetReportObjectText(report, "txtDatoFraTil", FromDate.ToString("dd-MM-yyyy") + " - " + ToDate.ToString("dd-MM-yyyy"));
            tools.SetReportObjectText(report, "txtKampagneID", SelectedKampagneID > 0 ? SelectedKampagneID.ToString() : AlleKampagneIDs);
            tools.SetReportSiteInformation(report);
            tools.Print(report, Preview);
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DisktilbudSolgtRptFrm_Load(object sender, EventArgs e)
        {
            LoadData();
            InitialzeDateTimePickers();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Print(true);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print(false);
        }

        private void chkDetails_CheckedChanged(object sender, EventArgs e)
        {
            chkItemDetails.Enabled = chkDetails.Checked;
            if (!chkItemDetails.Enabled)
                chkItemDetails.Checked = false;
        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
            // from date changed, make sure to date cannot be set before this date
            dtToDate.MinDate = dtFromDate.Value.Date;

            // re-fill disktilbud ids
            FillDisktlbudIDList();
        }

        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {
            // to date changed, make sure from date cannot be set after this date
            dtFromDate.MaxDate = dtToDate.Value.Date;

            // re-fill disktilbud ids
            FillDisktlbudIDList();
        }
    }
}