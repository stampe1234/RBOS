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
    public partial class ItemSalesSumForm : Form
    {
        #region Private variables

        private string selectedSubCategoryID = "";
        private string selectedSubCategoryDesc = "";

        #endregion

        #region Constructor
        public ItemSalesSumForm()
        {
            InitializeComponent();

            // fill in and localize top/bottom combobox
            comboTopBottom.Items.Add(db.GetLangString("FormSaleSum.OptionALLtxt"));
            comboTopBottom.Items.Add(db.GetLangString("FormSaleSum.OptionTOPtxt"));
            comboTopBottom.Items.Add(db.GetLangString("FormSaleSum.OptionBOTTOMtxt"));
            comboTopBottom.SelectedIndex = 0;
        }
        #endregion

        #region METHOD: Print
        private void Print(bool Preview)
        {
            // check that if user has selected to specify number of top/bottom
            // records to display, that there is a number value
            if ((comboTopBottom.SelectedIndex != 0) && (comboNumber.Text == ""))
            {
                MessageBox.Show(db.GetLangString("FormSalesSum.SpecifyNumRecords"));
                return;
            }

            // append filter clauses to SQL where needed

            // build additional where clause based on user selected criteria
            string sqlWhere = "";
            if (selectedSubCategoryID != "")
                sqlWhere += string.Format(" AND (Item.SubCategory = {0})" , selectedSubCategoryID);
            if (dtPostingDateFrom.Checked)
                sqlWhere += string.Format(" AND (ItemTransaction.PostingDate >= '{0}') ", dtPostingDateFrom.Value.Date);
            if (dtPostingDateTo.Checked)
                sqlWhere += string.Format(" AND (ItemTransaction.PostingDate <= '{0}') ", dtPostingDateTo.Value.Date);

            // apply additional where clause
            string sql = adapterItemSalesSum.GetOriginalSelectCommand();
            sql = sql.Replace("AND (1 = 1)", "{0}");
            sql = string.Format(sql, sqlWhere);
            adapterItemSalesSum.SetSelectCommand(sql);

            // load data based on criteria
            adapterItemSalesSum.Connection = db.Connection;
            adapterItemSalesSum.Fill(dsReport.ItemSalesSum);

            // check that any data were loaded
            if (dsReport.ItemSalesSum.Rows.Count <= 0)
            {
                MessageBox.Show(db.GetLangString("Application.NoDataToPrint"));
                return;
            }

            // calculate numberof and amount totals within criteria
            int NumberOfTotal = -dsReport.ItemSalesSum.CalculateNumberOfTotal();
            double AmountTotal = -dsReport.ItemSalesSum.CalculateAmountTotal();

            // calculate each amount percentage
            dsReport.ItemSalesSum.CalculateAmountPercentages(AmountTotal);

            // select table data to provide to report.
            // if user has selected top or bottom, create and use a new table with
            // the specified number of records, otherwise use the full set of data
            ReportDataSet.ItemSalesSumDataTable table = null;
            if (comboTopBottom.SelectedIndex == 1)
                table = dsReport.ItemSalesSum.GetTop((uint)tools.object2int(comboNumber.Text));
            else if (comboTopBottom.SelectedIndex == 2)
                table = dsReport.ItemSalesSum.GetBottom((uint)tools.object2int(comboNumber.Text));
            else
                table = dsReport.ItemSalesSum;

            // calculate accumulated amounts and percentages
            table = dsReport.ItemSalesSum.CalculateAccumulatedAmountsAndPercentages(table);

            // set report's data source
            reportItemSalesSum.SetDataSource((DataTable)table);

            #region Build selected filter information for report header

            // retrieve unbound report objects
            ReportObjects reportObjects = reportItemSalesSum.ReportDefinition.ReportObjects;
            TextObject toSubCategory = (TextObject)reportObjects["SubCategory"];
            TextObject toPostingDateFrom = (TextObject)reportObjects["PostingDateFrom"];
            TextObject toPostingDateTo = (TextObject)reportObjects["PostingDateTo"];
            TextObject toNumberOfSum = (TextObject)reportObjects["NumberOfSum"];
            TextObject toAmountSum = (TextObject)reportObjects["AmountSum"];
            TextObject toTopBottom = (TextObject)reportObjects["TopBottom"];

            // set default values to unbound report objects
            toSubCategory.Text = "-";
            toPostingDateFrom.Text = "-";
            toPostingDateTo.Text = "-";
            toNumberOfSum.Text = "-";
            toAmountSum.Text = "-";
            toTopBottom.Text = comboTopBottom.Text;

            // set unbound report objects if they have been set for filtering by user
            if (selectedSubCategoryID != "") toSubCategory.Text = selectedSubCategoryDesc;
            if (dtPostingDateFrom.Checked)
                toPostingDateFrom.Text = dtPostingDateFrom.Value.ToString("dd-MM-yyyy");
            if (dtPostingDateTo.Checked)
                toPostingDateTo.Text = dtPostingDateTo.Value.ToString("dd-MM-yyyy");
            toNumberOfSum.Text = NumberOfTotal.ToString();
            toAmountSum.Text = AmountTotal.ToString("n");
            if (comboTopBottom.SelectedIndex != 0)
                toTopBottom.Text = comboTopBottom.Text + " " + comboNumber.Text;

            #endregion

            // SiteInformation
            tools.SetReportSiteInformation(reportItemSalesSum);

            // print the report
            tools.Print(reportItemSalesSum, Preview);
        }
        #endregion

        #region METHOD: VerifyComboNumberValue
        /// <summary>
        /// Check that user has entered a number or empty string in comboNumber (no blanks).
        /// Displays error and focuses the combo if error.
        /// </summary>
        private void VerifyComboNumberValue()
        {
            if (comboNumber.Text != "")
            {
                Regex regex = new Regex("^([0-9]+)$");
                if (!regex.Match(comboNumber.Text).Success)
                {
                    MessageBox.Show(db.GetLangString("ItemSalesSumForm.SpecifyInteger"));
                    if (comboNumber.CanFocus)
                        comboNumber.Focus();
                }
            }
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

        // comboTopBottom selected index changed event
        private void comboTopBottom_SelectedIndexChanged(object sender, EventArgs e)
        {
            // enable/disable comboNumber and focus it
            comboNumber.Enabled = (comboTopBottom.SelectedIndex != 0);
            if ((comboNumber.Enabled) && (comboNumber.CanFocus))
                comboNumber.Focus();
        }

        // comboNumber text update event
        private void comboNumber_TextUpdate(object sender, EventArgs e)
        {
            VerifyComboNumberValue();
        }

        // comboNumber leave event
        private void comboNumber_Leave(object sender, EventArgs e)
        {
            VerifyComboNumberValue();
        }

        private void ItemSalesSumForm_Load(object sender, EventArgs e)
        {
            // Localize
            lbSubCategory.Text = db.GetLangString("FormSalesSum.SubcatLbl");
            lbPostingDateStart.Text = db.GetLangString("FormSalesSum.StartDateLbl");
            lbPostingDateEnd.Text = db.GetLangString("FormSalesSum.EndDateLbl");
            lbChoose.Text = db.GetLangString("FormSalesSum.SelectLbl");
            btnClose.Text = db.GetLangString("btnClose");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");

        }
    }
}