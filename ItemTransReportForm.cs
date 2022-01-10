using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Data.OleDb;
namespace RBOS
{
    public partial class ItemTransReportForm : Form
    {
        #region Private variables

        private string selectedSubCategoryID = "";
        private string selectedSubCategoryDesc = "";

        private int selectedItemID = -1;
        private string selectedItemName = "";

        #endregion

        #region Constructor
        public ItemTransReportForm()
        {
            InitializeComponent();

            // set lookup adapter connections
            adapterLookupPackSize.Connection = db.Connection;
            adapterLookupItemTransactionType.Connection = db.Connection;

            // load lookup data
            adapterLookupPackSize.Fill(dsReport.LookupPackSize_WithAllUnion);
            adapterLookupItemTransactionType.Fill(dsReport.LookupItemTransactionType_WithAllUnion);
        }
        #endregion

        #region  Print
        private void Print(bool Preview)
        {
            
            using (OleDbConnection conn = new OleDbConnection(db.ConnectionString))
            {
                //conn.Open();

                
            
                // append filter clauses to SQL where needed
                ReportDataSetTableAdapters.ItemTransactionsTableAdapter adapter =
                   new RBOS.ReportDataSetTableAdapters.ItemTransactionsTableAdapter();
                   
                



                string sql = adapter.GetOriginalSelectCommand();
                if (selectedSubCategoryID != "")
                    sql += string.Format(" AND (SubCategoryID = '{0}') ", selectedSubCategoryID);
                if (selectedItemName != "")
                    sql += string.Format(" AND (ItemName = '{0}') ", selectedItemName);
                if (dtPostingDateFrom.Checked)
                    sql += string.Format(" AND (PostingDate >= '{0}') ", dtPostingDateFrom.Value.Date);
                if (dtPostingDateTo.Checked)
                    sql += string.Format(" AND (PostingDate <= '{0}') ", dtPostingDateTo.Value.Date);
                if ((comboTransactionType.SelectedValue != null) &&
                    (!comboTransactionType.SelectedValue.Equals(0)))
                    sql += string.Format(" AND (ItemTransaction.TransactionType = {0}) ", comboTransactionType.SelectedValue);
                if ((comboPackType.SelectedValue != null) &&
                    (!comboPackType.SelectedValue.Equals(0)))
                    sql += string.Format(" AND (SalesPackType = {0}) ", comboPackType.SelectedValue);
                sql += " ORDER BY PostingDate, TransactionNumber ";
                adapter.SetSelectCommand(sql);

                // load data
                adapter.Connection = conn;
                adapter.Fill(dsReport.ItemTransactions);
            }
            // check that any data were loaded
            if (dsReport.ItemTransactions.Rows.Count <= 0)
            {
                MessageBox.Show(db.GetLangString("ItemTransReportForm.NoDataToPrint"));
                return;
            }

            // set report's data source
            ItemTransReport reportItemTransactions = new ItemTransReport();
            reportItemTransactions.SetDataSource((DataTable)dsReport.ItemTransactions);
            
            
            #region Build selected filter information for report header

            // retrieve unbound report objects
            ReportObjects reportObjects = reportItemTransactions.ReportDefinition.ReportObjects;
            TextObject toSubCategory = (TextObject)reportObjects["SubCategory"];
            TextObject toItemName = (TextObject)reportObjects["ItemName"];
            TextObject toPostingDateFrom = (TextObject)reportObjects["PostingDateFrom"];
            TextObject toPostingDateTo = (TextObject)reportObjects["PostingDateTo"];
            TextObject toTransactionType = (TextObject)reportObjects["TransactionType"];
            TextObject toSalesPackType = (TextObject)reportObjects["SalesPackType"];

            // set default values to unbound report objects
            toSubCategory.Text = "-";
            toItemName.Text = "-";
            toPostingDateFrom.Text = "-";
            toPostingDateTo.Text = "-";
            toTransactionType.Text = "-";
            toSalesPackType.Text = "-";

            // set unbound report objects if they have been set for filtering by user
            if (selectedSubCategoryID != "") toSubCategory.Text = selectedSubCategoryDesc;
            if (selectedItemID != -1) toItemName.Text = selectedItemName;
            if (dtPostingDateFrom.Checked)
                toPostingDateFrom.Text = dtPostingDateFrom.Value.ToString("dd-MM-yyyy");
            if (dtPostingDateTo.Checked)
                toPostingDateTo.Text = dtPostingDateTo.Value.ToString("dd-MM-yyyy");
            if (tools.object2int(comboTransactionType.SelectedValue) != 0)
                toTransactionType.Text = comboTransactionType.Text;
            if (tools.object2int(comboPackType.SelectedValue) != 0)
                toSalesPackType.Text = comboPackType.Text;

            #endregion

            // Site information
            tools.SetReportSiteInformation(reportItemTransactions);

            // print the report
            tools.Print(reportItemTransactions, Preview);
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

        // btnSubCategory click event
        private void btnSubCategory_Click(object sender, EventArgs e)
        {
            SubCategoryPopup subcat = new SubCategoryPopup();
            subcat.DisplaySelectNoneButton = true;
            if (subcat.ShowDialog() == DialogResult.OK)
            {
                selectedSubCategoryID = subcat.SelectedSubCategoryID;
                selectedSubCategoryDesc = subcat.SelectedSubCategoryDesc;
                if (selectedSubCategoryDesc == null) selectedSubCategoryDesc = "";
                txtSubCategory.Text = selectedSubCategoryDesc;
            }
        }

        // close button click event
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // btnItem click event
        private void btnItem_Click(object sender, EventArgs e)
        {
            SearchForm search = new SearchForm();
            search.SelectedItemID = tools.object2int(selectedItemID);
            if (search.ShowDialog() == DialogResult.OK)
            {
                selectedItemID = search.SelectedItemID;
                selectedItemName = search.SelectedItemName;
                txtItem.Text = selectedItemName;
            }
        }

        private void ItemTransReportForm_Load(object sender, EventArgs e)
        {
            // Localize
            lbSubCategory.Text = db.GetLangString("ItemTranRepForm.SubcategoryLbl");
            lbItem.Text = db.GetLangString("ItemTranRepForm.ItemLbl");
            lbPostingDateStart.Text = db.GetLangString("ItemTranRepForm.StartDateLbl");
            lbPostingDateEnd.Text = db.GetLangString("ItemTranRepForm.EndDateLbl");
            lbTransactionType.Text = db.GetLangString("ItemTranRepForm.TransTypeLbl");
            lbPackType.Text = db.GetLangString("ItemTranRepForm.PackSizeLbl");
            btnClose.Text = db.GetLangString("btnClose");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");


        }
    }
}