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
    public partial class BookedInvCountReportF : Form
    {
        int BookedCountID = -1;

        public BookedInvCountReportF(int BookedCountID)
        {
            InitializeComponent();
            this.BookedCountID = BookedCountID;
        }

        private void PreparePrint()
        {
            // setup header adapter
            ReportDataSetTableAdapters.BookedInvCountHeaderPrintTableAdapter adapterHeader =
                new RBOS.ReportDataSetTableAdapters.BookedInvCountHeaderPrintTableAdapter();
            adapterHeader.Connection = db.Connection;

            // setup details adapter
            ReportDataSetTableAdapters.BookedInvCountDetailPrintTableAdapter adapterDetail = 
                new RBOS.ReportDataSetTableAdapters.BookedInvCountDetailPrintTableAdapter();
            adapterDetail.Connection = db.Connection;

            // load data
            ReportDataSet ds = new ReportDataSet();
            DataSet ds2 = new DataSet();
            adapterHeader.Fill(ds.BookedInvCountHeaderPrint,BookedCountID);
            adapterDetail.Fill(ds.BookedInvCountDetailPrint,BookedCountID);
            
            //peter
            DataView dv = ds.DefaultViewManager.CreateDataView(ds.BookedInvCountDetailPrint);
            dv.Sort = "ActualCount DESC"; 
            DataTable DT2 = dv.ToTable();
            ds2.Tables.Add(DT2);
            DataView dv2 = ds.DefaultViewManager.CreateDataView(ds.BookedInvCountHeaderPrint);
            
            DataTable DT3 = dv2.ToTable();
            ds2.Tables.Add(DT3);
            //peter
            
            
            // Site information
            tools.SetReportSiteInformation(reportBookedInvCount);

            reportBookedInvCount.SetDataSource((DataSet)ds2);
            
        }

        private void BookedInvCountReport_Load(object sender, EventArgs e)
        {
            // localization
            this.Text = db.GetLangString("BookedInvCountPrintform.HeaderTxt");
            lbTitle.Text = db.GetLangString("BookedInvCountPrintform.ChooseActionLbl");
            btnClose.Text = db.GetLangString("Application.Close");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PreparePrint();
            tools.Print(reportBookedInvCount, false, false);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            PreparePrint();
            tools.Print(reportBookedInvCount, true, false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}