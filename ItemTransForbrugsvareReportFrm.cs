using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.OleDb;

namespace RBOS
{
    public partial class ItemTransForbrugsvareReportFrm : Form
    {
        #region Variables

        private string SelectedSubCategoryID = "";
        private int SelectedLevNr = 0;
        private double SelectedVarenummer = 0;

        #endregion

        #region Constructor
        public ItemTransForbrugsvareReportFrm()
        {
            InitializeComponent();
        }
        #endregion

        #region LoadData
        private void LoadData()
        {
            // Localize
            lbSubCategory.Text = db.GetLangString("ItemTransForbrugsvareReportFrm.lbSubCategory");
            lbItem.Text = db.GetLangString("ItemTransForbrugsvareReportFrm.lbItem");
            lbPostingDateStart.Text = db.GetLangString("ItemTransForbrugsvareReportFrm.lbStartDate");
            lbPostingDateEnd.Text = db.GetLangString("ItemTransForbrugsvareReportFrm.lbEndDate");
            lbLevKategori.Text = db.GetLangString("ItemTransForbrugsvareReportFrm.lbLevKategori");
            btnClose.Text = db.GetLangString("Application.Close");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");

            adapterLevKategori.Connection = db.Connection;
            adapterLevKategori.Fill(this.dsReport.LevKategoriRBA);
        }
        #endregion

        #region Print
        private void Print(bool Preview)
        {
            // create and setup adapter for the table
            ReportDataSetTableAdapters.ItemTransactionForbrugsvareTableAdapter adapter =
                new RBOS.ReportDataSetTableAdapters.ItemTransactionForbrugsvareTableAdapter();
            adapter.Connection = db.Connection;

            // load data into table
            adapter.Fill(dsReport.ItemTransactionForbrugsvare,
                SelectedSubCategoryID,
                SelectedLevNr,
                SelectedVarenummer,
                tools.object2string(ddLevKategori.SelectedValue),
                dtPostingDateFrom.Checked ? (Nullable<DateTime>)dtPostingDateFrom.Value.Date : null,
                dtPostingDateTo.Checked ? (Nullable<DateTime>)dtPostingDateTo.Value.Date : null);

            // check that any data were loaded
            if (dsReport.ItemTransactionForbrugsvare.Rows.Count <= 0)
            {
                MessageBox.Show(db.GetLangString("Application.NoDataToPrint"));
                return;
            }

            // fill virtual columns
            foreach (DataRow row in dsReport.ItemTransactionForbrugsvare)
            {
                row["PostingDateWeekday"] = tools.object2datetime(row["PostingDate"]).ToString("ddd");
            }

            // create and setup report
            ItemTransForbrugsvareReport report = new ItemTransForbrugsvareReport();
            report.SetDataSource((DataTable)dsReport.ItemTransactionForbrugsvare);

            // retrieve unbound report objects
            ReportObjects reportObjects = report.ReportDefinition.ReportObjects;
            TextObject toSubCategory = (TextObject)reportObjects["SubCategory"];
            TextObject toItemName = (TextObject)reportObjects["ItemName"];
            TextObject toLevKategori = (TextObject)reportObjects["LevKategori"];
            TextObject toPostingDateFrom = (TextObject)reportObjects["PostingDateFrom"];
            TextObject toPostingDateTo = (TextObject)reportObjects["PostingDateTo"];

            // set the unbound report object values
            toSubCategory.Text = SelectedSubCategoryID != "" ? SelectedSubCategoryID : "-";
            toItemName.Text = SelectedLevNr > 0 ? txtItem.Text : "-";
            toPostingDateFrom.Text = dtPostingDateFrom.Checked ? dtPostingDateFrom.Value.ToString("dd-MM-yyyy") : "-";
            toPostingDateTo.Text = dtPostingDateTo.Checked ? dtPostingDateTo.Value.ToString("dd-MM-yyyy") : "-";
            toLevKategori.Text = tools.object2string(ddLevKategori.SelectedValue) != "" ? tools.object2string(ddLevKategori.SelectedValue) : "-";

            // Site information
            tools.SetReportSiteInformation(report);

            // print the report
            tools.Print(report, Preview);
        }
        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print(false);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Print(true);
        }

        private void btnSubCategory_Click(object sender, EventArgs e)
        {
            SubCategoryPopup subcat = new SubCategoryPopup();
            subcat.DisplaySelectNoneButton = true;
            if (subcat.ShowDialog() == DialogResult.OK)
            {
                SelectedSubCategoryID = subcat.SelectedSubCategoryID;
                txtSubCategory.Text = subcat.SelectedSubCategoryDesc != null ? subcat.SelectedSubCategoryDesc : "";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            ForbrugsvareSearch search = new ForbrugsvareSearch();
            search.PreSelectVareUnfiltered(SelectedLevNr, SelectedVarenummer);
            search.IncludeInactiveItems = true;
            if (search.ShowDialog() == DialogResult.OK)
            {
                SelectedLevNr = search.SelectedLevNr;
                SelectedVarenummer = search.SelectedVarenummer;
                txtItem.Text = ItemDataSet.ForbrugsvareDataTable.GetVarenavn(SelectedLevNr, SelectedVarenummer);
            }
        }

        private void ItemTransForbrugsvareReportFrm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}