#region Documentation

/// EODDebtorListPF class is a print form
/// for printing the EODDebtorList report.

#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace RBOS
{
    public partial class EODDebtorListPF : Form
    {
        public EODDebtorListPF()
        {
            InitializeComponent();

            // localization
            btnPrint.Text = db.GetLangString("Application.ReportPrint");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            btnClose.Text = db.GetLangString("Application.Close");
            lbDateTo.Text = db.GetLangString("EODDebtorListPF.lbDateTo");
        }

        private void Print(bool preview)
        {
            // load data
            EODDataSet ds = new EODDataSet();
            EODDataSetTableAdapters.EOD_Debtor_ListReportTableAdapter adapter =
                new RBOS.EODDataSetTableAdapters.EOD_Debtor_ListReportTableAdapter();
            adapter.Connection = db.Connection;
            adapter.Fill(ds.EOD_Debtor_ListReport, tools.object2datetime(dtDateTo.Value));

            // check we have data
            if (ds.EOD_Debtor_ListReport.Rows.Count > 0)
            {
                // set selected date in report
                tools.SetReportObjectText(rptEODDebtorList, "DateTo", dtDateTo.Value.ToShortDateString());

                // Site information
                tools.SetReportSiteInformation(rptEODDebtorList);

                // print
                rptEODDebtorList.SetDataSource((DataTable)ds.EOD_Debtor_ListReport);
                tools.Print(rptEODDebtorList, preview);
            }
            else
            {
                MessageBox.Show(db.GetLangString("Application.NoDataToPrint"));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print(false);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Print(true);
        }

        private void lbDateTo_Click(object sender, EventArgs e)
        {

        }
    }
}