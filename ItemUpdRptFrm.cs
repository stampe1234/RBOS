using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class ItemUpdRptFrm : Form
    {
        private int ID = 0; // ItemUpdates ID

        public ItemUpdRptFrm(int ID)
        {
            InitializeComponent();
            this.ID = ID;

            // localization
            btnClose.Text = db.GetLangString("Application.Close");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            this.Text = db.GetLangString("ItemUpdRptFrm.Title");
            lbInfo.Text = db.GetLangString("ItemUpdRptFrm.lbInfo");
        }

        private void Print(bool Preview)
        {
            // create db objects
            ReportDataSetTableAdapters.ItemUpdatesTableAdapter adapterHeader =
                new RBOS.ReportDataSetTableAdapters.ItemUpdatesTableAdapter();
            ReportDataSetTableAdapters.ItemUpdLinesTableAdapter adapterDetails =
                new RBOS.ReportDataSetTableAdapters.ItemUpdLinesTableAdapter();
            adapterHeader.Connection = db.Connection;
            adapterDetails.Connection = db.Connection;
            ReportDataSet dsReport = new ReportDataSet();

            // load data
            adapterHeader.Fill(dsReport.ItemUpdates, ID);
            adapterDetails.Fill(dsReport.ItemUpdLines, ID);

            // calculate before/after margins
            // NOTE: we do NOT do this in the query, as we
            // want to use our central calculation method for this
            foreach (DataRow row in dsReport.ItemUpdLines.Rows)
            {
                double BeforeSales = tools.object2double(row["LogSales"]);
                double BeforeCost = tools.object2double(row["LogCost"]);
                row["MarginBefore"] = tools.CalcMargin(BeforeSales, BeforeCost);

                double AfterSales = tools.object2double(row["SalesPrice"]);
                double AfterCost = tools.object2double(row["CostPrice"]);
                row["MarginAfter"] = tools.CalcMargin(AfterSales,AfterCost);
            }

            // Site information
            tools.SetReportSiteInformation(rptItemUpdates);

            // print the report
            rptItemUpdates.SetDataSource(dsReport);
            tools.Print(rptItemUpdates, Preview, false);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print(false);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Print(true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}