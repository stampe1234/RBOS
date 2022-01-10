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
    public partial class ItemTransReportFormRBA : Form
    {
        #region Variables

        private string SelectedSubCategoryID = "";
        private int SelectedLevNr = 0;
        private double SelectedVarenummer = 0;

        #endregion

        #region Constructor
        public ItemTransReportFormRBA()
        {
            InitializeComponent();
        }
        #endregion

        #region LoadData
        private void LoadData()
        {
            // Localize
            lbSubCategory.Text = db.GetLangString("ItemTransReportFormRBA.lbSubCategory");
            lbItem.Text = db.GetLangString("ItemTransReportFormRBA.lbItem");
            lbPostingDateStart.Text = db.GetLangString("ItemTransReportFormRBA.lbStartDate");
            lbPostingDateEnd.Text = db.GetLangString("ItemTransReportFormRBA.lbEndDate");
            lbLevKategori.Text = db.GetLangString("ItemTransReportFormRBA.lbLevKategori");
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
            ReportDataSetTableAdapters.ItemTransactionRBATableAdapter adapter =
                new RBOS.ReportDataSetTableAdapters.ItemTransactionRBATableAdapter();
            adapter.Connection = db.Connection;

            // load data into table
            adapter.Fill(dsReport.ItemTransactionRBA,
                SelectedSubCategoryID,
                SelectedLevNr,
                SelectedVarenummer,
                tools.object2string(ddLevKategori.SelectedValue),
                dtPostingDateFrom.Checked ? (Nullable<DateTime>)dtPostingDateFrom.Value.Date : null,
                dtPostingDateTo.Checked ? (Nullable<DateTime>)dtPostingDateTo.Value.Date : null);

            // check that any data were loaded
            if (dsReport.ItemTransactionRBA.Rows.Count <= 0)
            {
                MessageBox.Show(db.GetLangString("Application.NoDataToPrint"));
                return;
            }

            // fill virtual columns
            foreach (DataRow row in dsReport.ItemTransactionRBA)
            {
                row["PostingDateWeekday"] = tools.object2datetime(row["PostingDate"]).ToString("ddd");
            }

            // create and setup report
            ItemTransReportRBA report = new ItemTransReportRBA();
            report.SetDataSource((DataTable)dsReport.ItemTransactionRBA);

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
            SearchFormRBA search = new SearchFormRBA();
            search.PreSelectVareUnfiltered(SelectedLevNr, SelectedVarenummer);
            search.IncludeInactiveItems = true;
            if (search.ShowDialog() == DialogResult.OK)
            {
                SelectedLevNr = search.SelectedLevNr;
                SelectedVarenummer = search.SelectedVarenummer;
                txtItem.Text = ItemDataSet.AfskrProdDataTable.GetVarenavn(SelectedLevNr, SelectedVarenummer);
            }
        }

        private void ItemTransReportFormRBA_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}