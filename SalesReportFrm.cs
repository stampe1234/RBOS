using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class SalesReportFrm : Form
    {
        public SalesReportFrm()
        {
            InitializeComponent();

            // localization
            lbStartDate.Text = db.GetLangString("SalesReportFrm.lbStartDate");
            lbEndDate.Text = db.GetLangString("SalesReportFrm.lbEndDate");
            lbShowLitres.Text = db.GetLangString("SalesReportFrm.lbShowLitres");
            lbDoNotShow0Lines.Text = db.GetLangString("SalesReportFrm.DoNotShow0Lines");
            lbIncludeFuel.Text = db.GetLangString("SalesReportFrm.lbIncludeFuel");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            btnClose.Text = db.GetLangString("Application.Close");
        }

        private void Print(bool preview)
        {
            // through this method, a postfix "LY" in variables names
            // means last year. for instance startDateLY.

            // prepare db objects
            ReportDataSet.SalesReportDataTable tableSalesReport =
                new ReportDataSet.SalesReportDataTable();
            ReportDataSetTableAdapters.SalesReportTableAdapter adapterSalesReport =
                new RBOS.ReportDataSetTableAdapters.SalesReportTableAdapter();

            // get selected start/end dates
            DateTime startDate = dtStartDate.Value.Date;
            DateTime endDate = dtEndDate.Value.Date;
            DateTime startDateLY = startDate.AddYears(-1);
            DateTime endDateLY = endDate.AddYears(-1);

            // load GL data
            adapterSalesReport.Connection = db.Connection;
            string StartingGLCode = chkIncludeFuel.Checked ? "1005" : "1050";

            if (chkShowLitres.Checked)
                adapterSalesReport.FillLitresOnly(tableSalesReport);
            else
                adapterSalesReport.Fill(tableSalesReport, StartingGLCode);

            // variables needed
            double TotalSalesPeriod = 0;
            double TotalBudgetPeriod = 0;
            double TotalSalesPeriodLY = 0;

            // loop the loaded GL data and fill in virtual columns
            foreach (DataRow row in tableSalesReport)
            {
                string GLCode = tools.object2string(row["GLCode"]);

                // lookup the VAT used for this GLCode
                // (assumed same VAT for all subcats with this GLCode)
                string subcat = tools.object2string(db.ExecuteScalar(string.Format(
                    " select SubCategoryID " +
                    " from SubCategory " +
                    " where GLCode = '{0}'",
                    GLCode)));

                if (subcat != "")
                {
                    double VAT = tools.GetSubCategoryVAT(subcat);

                    // determine which columns to use
                    // in various sql statements below
                    // (choosing between amount and volume)
                    string ColAmountOrVolume = "Amount";
                    string ColAmountOrNumberOf = "Amount";
                    if (chkShowLitres.Checked)
                    {
                        ColAmountOrVolume = "Volume";
                        ColAmountOrNumberOf = "NumberOf";
                    }

                    // get budget for period for this GLCode
                    // in this we get the days in the beginning, the whole months and the days in the end.
                    double BudgetPeriod = 0;
                    for (DateTime tmpDate = startDate; tmpDate <= tools.GetLastDateInMonth(endDate); tmpDate = tmpDate.AddMonths(1))
                    {
                        double tmpBudgetPeriod = tools.object2double(db.ExecuteScalar(string.Format(
                            " select {0} from GLBudget " +
                            " where (GLCode = '{1}') " +
                            " and (BudgetYear = {2}) " +
                            " and (BudgetMonth = {3}) "
                            , ColAmountOrVolume, GLCode, tmpDate.Year, tmpDate.Month)));
                        int tmpDaysInBudget = DateTime.DaysInMonth(tmpDate.Year, tmpDate.Month);
                        int tmpDaysToUse = tmpDaysInBudget; // for middle months
                        if (startDate.ToString("yyyyMM") == endDate.ToString("yyyyMM")) // only one month
                            tmpDaysToUse = endDate.Day - (startDate.Day - 1);
                        else if (tmpDate.ToString("yyyyMM") == startDate.ToString("yyyyMM")) // first month
                            tmpDaysToUse = (tmpDaysInBudget - (startDate.Day - 1));
                        else if (tmpDate.ToString("yyyyMM") == endDate.ToString("yyyyMM")) // last month
                            tmpDaysToUse = endDate.Day;
                        BudgetPeriod += (tmpBudgetPeriod / tmpDaysInBudget) * tmpDaysToUse;
                    }
                    row["BudgetPeriod"] = BudgetPeriod;
                    TotalBudgetPeriod += BudgetPeriod; // sum total

                    //// get budget for period last year for this GLCode
                    //// in this we get the days in the beginning, the whole months and the days in the end.
                    //double BudgetPeriodLY = 0;
                    //for (DateTime tmpDateLY = startDateLY; tmpDateLY <= endDateLY; tmpDateLY = tmpDateLY.AddMonths(1))
                    //{
                    //    double tmpBudgetPeriodLY = tools.object2double(db.ExecuteScalar(string.Format(
                    //        " select {0} from GLBudget " +
                    //        " where (GLCode = '{1}') " +
                    //        " and (BudgetYear = {2}) " +
                    //        " and (BudgetMonth = {3}) "
                    //        , ColAmountOrVolume, GLCode, tmpDateLY.Year, tmpDateLY.Month)));
                    //    int tmpDaysInBudgetLY = DateTime.DaysInMonth(tmpDateLY.Year, tmpDateLY.Month);
                    //    int tmpDaysToUseLY = tmpDaysInBudgetLY;
                    //    if (startDateLY.ToString("yyyyMM") == endDateLY.ToString("yyyyMM"))
                    //        tmpDaysToUseLY = endDateLY.Day - (startDateLY.Day - 1);
                    //    else if (tmpDateLY.ToString("yyyyMM") == startDateLY.ToString("yyyyMM"))
                    //        tmpDaysToUseLY = (tmpDaysInBudgetLY - (startDateLY.Day - 1));
                    //    else if (tmpDateLY.ToString("yyyyMM") == endDateLY.ToString("yyyyMM"))
                    //        tmpDaysToUseLY = endDateLY.Day;
                    //    BudgetPeriodLY += (tmpBudgetPeriodLY / tmpDaysInBudgetLY) * tmpDaysToUseLY;
                    //}
                    //row["BudgetPeriodLY"] = BudgetPeriodLY;
                    //TotalBudgetPeriodLY += BudgetPeriodLY; // sum total

                    // create list of subcategories for this glcode, to be used in below sql's
                    DataTable tableSubCats = db.GetDataTable(string.Format(
                        " select SubCategoryID from SubCategory where GLCode = '{0}' ", GLCode));
                    string subcats = "";
                    for (int i = 0; i < tableSubCats.Rows.Count; i++)
                    {
                        subcats += "'" + tools.object2string(tableSubCats.Rows[i]["SubCategoryID"]) + "'";
                        if (i < tableSubCats.Rows.Count - 1)
                            subcats += ",";
                    }

                    // get period amount/volume for this glcode
                    double SalesPeriod = tools.object2double(db.ExecuteScalar(string.Format(
                        " SELECT SUM({0}) " +
                        " FROM EOD_Sales " +
                        " WHERE (BookDate >= '{1}') " +
                        " AND (BookDate <= '{2}') " +
                        " AND (SubCategory IN ({3})) ",
                        ColAmountOrNumberOf, startDate.Date, endDate.Date, subcats)));
                    if (!chkShowLitres.Checked)
                        SalesPeriod = tools.DeductVAT(SalesPeriod, VAT);
                    row["SalesPeriod"] = SalesPeriod;

                    // sum total sales month
                    TotalSalesPeriod += SalesPeriod;

                    // get period last year amount/volume for this glcode
                    double SalesPeriodLY = tools.object2double(db.ExecuteScalar(string.Format(
                        " SELECT SUM({0}) " +
                        " FROM EOD_Sales " +
                        " WHERE (BookDate >= '{1}') " +
                        " AND (BookDate <= '{2}') " +
                        " AND (SubCategory IN ({3})) ",
                        ColAmountOrNumberOf, startDateLY.Date, endDateLY.Date, subcats)));
                    if (!chkShowLitres.Checked)
                        SalesPeriodLY = tools.DeductVAT(SalesPeriodLY, VAT);
                    row["SalesPeriodLY"] = SalesPeriodLY;

                    // sum total sales year
                    TotalSalesPeriodLY += SalesPeriodLY;

                    // calculate period index
                    row["IndexPeriod"] = tools.CalcIndex(SalesPeriod, BudgetPeriod);

                    // calculate last year period index
                    row["IndexPeriodLY"] = tools.CalcIndex(SalesPeriod, SalesPeriodLY);

                    // set null values in salesmonth and salesyear to 0
                    if (row["SalesPeriod"] == DBNull.Value)
                        row["SalesPeriod"] = 0;
                    if (row["SalesPeriodLY"] == DBNull.Value)
                        row["SalesPeriodLY"] = 0;

                    /// By default, the record is shown in print. However, if
                    /// the user has selected the checkmark so as not to show
                    /// records with only 0 values, we check if the record has only 0 values.
                    row["ShowInPrint"] = true;
                    if (chkDoNotShow0Lines.Checked)
                    {
                        bool AtLeastOneHasValue = false;
                        for (int i = 0; i < tableSalesReport.Columns.Count; i++)
                        {
                            if ((row[i] is double) && (tools.object2double(row[i]) != 0))
                                AtLeastOneHasValue = true;
                        }
                        if (!AtLeastOneHasValue)
                            row["ShowInPrint"] = false;
                    }
                }
            } // end of looping gl data to fill in virtual columns

            // set some report labels based on if using volume or amount
            if (chkShowLitres.Checked)
            {
                tools.SetReportObjectText(rptSales, "PeriodTitle", "Litre");
                tools.SetReportObjectText(rptSales, "PeriodLYTitle", "Litre");
            }
            else
            {
                tools.SetReportObjectText(rptSales, "PeriodTitle", "");
                tools.SetReportObjectText(rptSales, "PeriodLYTitle", "");
            }

            // write start-end dates
            tools.SetReportObjectText(
                rptSales,
                "StartEndDate",
                startDate.ToString("dd-MM-yyyy") + " - " + endDate.ToString("dd-MM-yyyy"));

            // write start-end dates last year
            tools.SetReportObjectText(
                rptSales,
                "StartEndDateLY",
                startDateLY.ToString("dd-MM-yyyy") + " - " + endDateLY.ToString("dd-MM-yyyy"));

            // Site information
            tools.SetReportSiteInformation(rptSales);

            // calculate and write total index period into report
            double TotalIndexPeriod = tools.CalcIndex(TotalSalesPeriod, TotalBudgetPeriod);
            tools.SetReportObjectText(rptSales, "TotalIndexPeriod", TotalIndexPeriod.ToString("N1"));

            // calculate and write total index last year period into report
            double TotalIndexPeriodLY = tools.CalcIndex(TotalSalesPeriod, TotalSalesPeriodLY);
            tools.SetReportObjectText(rptSales, "TotalIndexPeriodLY", TotalIndexPeriodLY.ToString("N1"));

            // print
            rptSales.SetDataSource((DataTable)tableSalesReport);
            
            tools.Print(rptSales, preview);
        }

        /// <summary>
        /// Makes sure the startdate is not later that the enddate and visa versa.
        /// </summary>
        private void EnsureDateInterval()
        {
            dtStartDate.MaxDate = dtEndDate.Value.Date;
            dtEndDate.MinDate = dtStartDate.Value.Date;
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

        private void dtStartDate_ValueChanged(object sender, EventArgs e)
        {
            EnsureDateInterval();
        }

        private void dtEndDate_ValueChanged(object sender, EventArgs e)
        {
            EnsureDateInterval();
        }

        private void SalesReportFrm_Load(object sender, EventArgs e)
        {
            // make sure datetime pickers cannot select dates
            // before or after sales record dates
            DateTime MinSalesDate = EODDataSet.EOD_SalesDataTable.GetMinSalesDate();
            DateTime MaxSalesDate = EODDataSet.EOD_SalesDataTable.GetMaxSalesDate();
            if ((MinSalesDate != DateTime.MinValue) && (MaxSalesDate != DateTime.MinValue))
            {
                dtStartDate.MinDate = MinSalesDate;
                dtEndDate.MaxDate = MaxSalesDate;

                // make sure datetime pickers cannot overlap interval
                EnsureDateInterval();

                // by default enddate is the last date there is sales data on
                dtEndDate.Value = dtEndDate.MaxDate;

                // and by default the startdate is the first in that month,
                // or the first possible date if no data in the beginning of the month
                DateTime dtFirstDateInMonth = new DateTime(dtEndDate.Value.Year, dtEndDate.Value.Month, 1);
                if (dtFirstDateInMonth < dtStartDate.MinDate)
                    dtStartDate.Value = dtStartDate.MinDate;
                else
                    dtStartDate.Value = dtFirstDateInMonth;
            }
            else
            {
                dtEndDate.Enabled = false;
                dtStartDate.Enabled = false;
            }

            // get config values
            chkDoNotShow0Lines.Checked = db.GetConfigStringAsBool("SalesReportFrm.DoNotShow0Lines");
            chkIncludeFuel.Checked = db.GetConfigStringAsBool("SalesReportFrm.IncludeFuel");
        }

        private void chkDoNotShow0Lines_CheckedChanged(object sender, EventArgs e)
        {
            db.SetConfigString("SalesReportFrm.DoNotShow0Lines", chkDoNotShow0Lines.Checked);
        }

        private void chkIncludeFuel_CheckedChanged(object sender, EventArgs e)
        {
            db.SetConfigString("SalesReportFrm.IncludeFuel", chkIncludeFuel.Checked);
        }
    }
}