using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace RBOS
{
    public partial class SalesMarginRptFrm : Form
    {
        #region Private variables

        private string selectedSubCategoryID = "";
        private string selectedSubCategoryDesc = "";

        private int selectedItemID = -1;
        private string selectedItemName = "";

        #endregion

        #region Constructor
        public SalesMarginRptFrm()
        {
            InitializeComponent();
        }
        #endregion

        #region Print
        private void Print(bool Preview)
        {
            // create db objects
            ReportDataSet dsReport = new ReportDataSet();
            ReportDataSetTableAdapters.SalesMarginTableAdapter adapterSalesMargin =
                new RBOS.ReportDataSetTableAdapters.SalesMarginTableAdapter();

            

            // build where clause to SQL
            string whereClause = " (1 = 1) ";
            if (selectedSubCategoryID != "")
                whereClause += string.Format(" AND (SubCategoryID = '{0}') ", selectedSubCategoryID);  //pn20200316
            if (selectedItemName != "")
                whereClause += string.Format(" AND (ItemName = '{0}') ", selectedItemName);//pn20200226
            if (dtPostingDateFrom.Checked)
                whereClause += string.Format(" AND (PostingDate >= {0}) ", tools.datetime4sql(dtPostingDateFrom.Value.Date));
            if (dtPostingDateTo.Checked)
                whereClause += string.Format(" AND (PostingDate <= {0}) ", tools.datetime4sql(dtPostingDateTo.Value.Date));

            // replace (1 = 1) in SalesMargin SQL with where clause
            string sql = adapterSalesMargin.GetOriginalSelectCommand();
            sql = sql.Replace("(1 = 1)", whereClause);
            adapterSalesMargin.SetSelectCommand(sql);

            // load SalesMargin data.
            adapterSalesMargin.Connection = db.Connection;            
            adapterSalesMargin.Fill(dsReport.SalesMargin);

            // check that any totals data were loaded.
            if (dsReport.SalesMargin.Rows.Count <= 0)
            {
                MessageBox.Show(db.GetLangString("Application.NoDataToPrint"));
                return;
            }

            // fill SalesMargin virtual columns with data
            foreach (DataRow row in dsReport.SalesMargin.Rows)
            {
                double SalesAmount = tools.object2double(row["SalesAmount"]);
                double CostAmount = tools.object2double(row["CostAmount"]);
                row["DB"] = tools.CalcDB(SalesAmount, CostAmount); //pn20200326
                row["DG"] = tools.CalcMargin(SalesAmount, CostAmount);
                row["Index"] = tools.CalcIndex(tools.object2double(row["DG"]), tools.object2double(row["BudgetMargin"]));
                double DiffDG = tools.CalcDGDiff(tools.object2double(row["DG"]), tools.object2double(row["BudgetMargin"]));
                row["DiffDB"] = tools.CalcDBDiff(SalesAmount, DiffDG);
            }

            // set report's data source
            rptSalesMargin.SetDataSource(dsReport);

            // suppress detail sections if user has selected to only view subcategories
            rptSalesMargin.Section3.SectionFormat.EnableSuppress = chkOnlySubCats.Checked;
            rptSalesMargin.GroupHeaderSection1.SectionFormat.EnableSuppress = chkOnlySubCats.Checked;

            // build string for inserting criteria into report
            string printSubCategory = "-";
            string printItemName = "-";
            string printDateFrom = "-";
            string printDateTo = "-";
            if (selectedSubCategoryDesc != "")
                printSubCategory = selectedSubCategoryDesc;
            if (selectedItemName != "")
                printItemName = selectedItemName;
            if (dtPostingDateFrom.Checked)
                printDateFrom = dtPostingDateFrom.Value.ToString("dd-MM-yyyy");
            if (dtPostingDateTo.Checked)
                printDateTo = dtPostingDateTo.Value.ToString("dd-MM-yyyy");

            // insert criteria information into report
            tools.SetReportObjectText(rptSalesMargin, "SubCategory", printSubCategory);
            tools.SetReportObjectText(rptSalesMargin, "ItemName", printItemName);
            tools.SetReportObjectText(rptSalesMargin, "DateFrom", printDateFrom);
            tools.SetReportObjectText(rptSalesMargin, "DateTo", printDateTo);

            // insert site information into report
            tools.SetReportSiteInformation(rptSalesMargin);

            // print the report
            tools.Print(rptSalesMargin, Preview);
        }
        #endregion

        #region SelectSubCategory
        private void SelectSubCategory()
        {
            SubCategoryPopup subcat = new SubCategoryPopup();
            subcat.DisplaySelectNoneButton = true;
            if (subcat.ShowDialog() == DialogResult.OK)
            {
                // did user select a new subcategory?
                if (selectedSubCategoryID != subcat.SelectedSubCategoryID)
                {
                    // set selected subcategory information
                    selectedSubCategoryID = subcat.SelectedSubCategoryID;
                    selectedSubCategoryDesc = subcat.SelectedSubCategoryDesc;
                    if (selectedSubCategoryDesc == null) selectedSubCategoryDesc = "";
                    txtSubCategory.Text = selectedSubCategoryDesc;

                    // when selecting a new subcategory, blank selected item
                    selectedItemID = -1;
                    selectedItemName = "";
                    txtItem.Text = "";
                }
            }
        }
        #endregion

        #region SelectItem
        private void SelectItem()
        {
            SearchForm search = new SearchForm();
            search.SelectedItemID = tools.object2int(selectedItemID);
            if (search.ShowDialog() == DialogResult.OK)
            {
                // did user select a new item?
                if (selectedItemID != search.SelectedItemID)
                {
                    selectedItemID = search.SelectedItemID;
                    selectedItemName = search.SelectedItemName;
                    txtItem.Text = selectedItemName;

                    // when selecting a new subcategory, blank selected subcategory
                    selectedSubCategoryID = "";
                    selectedSubCategoryDesc = "";
                    txtSubCategory.Text = "";
                }
            }
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
            SelectSubCategory();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            SelectItem();
        }

        private void SalesMarginRptFrm_Load(object sender, EventArgs e)
        {
            // Localize
            lbSubCategory.Text = db.GetLangString("SalesMarginRptFrm.SubcategoryLbl");
            lbItem.Text = db.GetLangString("SalesMarginRptFrm.ItemLbl");
            lbPostingDateStart.Text = db.GetLangString("SalesMarginRptFrm.StartDateLbl");
            lbPostingDateEnd.Text = db.GetLangString("SalesMarginRptFrm.EndDateLbl");
            chkOnlySubCats.Text = db.GetLangString("SalesMarginRptFrm.chkOnlySubCats");
            btnClose.Text = db.GetLangString("Application.Close");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");
        }
    }
}