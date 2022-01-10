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
    public partial class EODReportFrm : Form
    {
        private DateTime BookDate;

        #region Constructor
        public EODReportFrm(DateTime BookDate)
        {
            InitializeComponent();
            this.BookDate = BookDate;

            // load chkSalesPerGLCode value
            chkSalesPerGLCode.Checked = db.GetConfigStringAsBool("EODSalesReportPerGLCode");
        }
        #endregion

        #region METHOD: Print
        private void Print(bool Preview)
        {
            // create adapters (that are not added on the form)
            EODDataSetTableAdapters.EOD_SafePay_OverfoerselTilSPTableAdapter adapterOverfoerseTilSP =
                new RBOS.EODDataSetTableAdapters.EOD_SafePay_OverfoerselTilSPTableAdapter();
            EODDataSetTableAdapters.EOD_SafePay_UdbetalingerTableAdapter adapterSafePayUdbetalinger =
                new RBOS.EODDataSetTableAdapters.EOD_SafePay_UdbetalingerTableAdapter();
            EODDataSetTableAdapters.EOD_SafePay_IndbetalingerTableAdapter adapterSafePayIndbetalinger =
                new RBOS.EODDataSetTableAdapters.EOD_SafePay_IndbetalingerTableAdapter();
            EODDataSetTableAdapters.EOD_SafePay_DepotbeholdningTableAdapter adapterSafePayDepotbeholdning =
                new RBOS.EODDataSetTableAdapters.EOD_SafePay_DepotbeholdningTableAdapter();
            EODDataSetTableAdapters.EOD_SafePay_ValutakurserTableAdapter adapterSafePayValutakurser =
                new RBOS.EODDataSetTableAdapters.EOD_SafePay_ValutakurserTableAdapter();
            EODDataSetTableAdapters.EOD_DiscountsTableAdapter adapterDiscounts =
                new RBOS.EODDataSetTableAdapters.EOD_DiscountsTableAdapter();
            

            // set connections
            adapterBankCards.Connection = db.Connection;
            adapterBankDep.Connection = db.Connection;
            adapterEODReconcile.Connection = db.Connection;
            adapterLocalCredReport.Connection = db.Connection;
            adapterPayinPayout.Connection = db.Connection;
            adapterSalesReport.Connection = db.Connection;
            adapterShellCards.Connection = db.Connection;
            adapterReportParams.Connection = db.Connection;
            adapterSalesReportPerGLCode.Connection = db.Connection;
            adapterReadings.Connection = db.Connection;
            adapterWash.Connection = db.Connection;
            adapterManualCards.Connection = db.Connection;
            adapterForeignCurrency.Connection = db.Connection;
            adapterReserveTerminal.Connection = db.Connection;
            adapterOverfoerseTilSP.Connection = db.Connection;
            adapterSafePayUdbetalinger.Connection = db.Connection;
            adapterSafePayIndbetalinger.Connection = db.Connection;
            adapterSafePayDepotbeholdning.Connection = db.Connection;
            adapterSafePayValutakurser.Connection = db.Connection;
            adapterDiscounts.Connection = db.Connection;

            // some adapters will not clear tables before fill,
            // so clear those tables manually
            dsEOD.EOD_LocalCred.Clear();
            dsEOD.EOD_PayinPayout.Clear();
            dsEOD.EOD_Sales.Clear();
           
            bool SafePayEnabled = db.GetConfigStringAsBool("SafePay.Enabled");

            // load data
            adapterEODReconcile.Fill(dsEOD.EODReconcileSingle, BookDate);
            adapterBankCards.Fill(dsEOD.EOD_BankCards, BookDate);
            adapterBankDep.Fill(dsEOD.EOD_BankDep, BookDate);
            adapterLocalCredReport.Fill(dsEOD.EOD_LocalCred_Report, BookDate, (int)TransTypeLocalCred.LocalCredit);
            adapterLocalCredReport.Fill(dsEOD.EOD_LocalCred_Report, BookDate, (int)TransTypeLocalCred.LocalCreditPayin);
            adapterPayinPayout.Fill(dsEOD.EOD_PayinPayout, BookDate, (int)TransTypePayinPayout.Payin);
            adapterPayinPayout.Fill(dsEOD.EOD_PayinPayout, BookDate, (int)TransTypePayinPayout.Payout);
            adapterSalesReport.Fill(dsEOD.EOD_Sales_Report, BookDate, (int)TransTypeSales.POSSales);
            adapterSalesReport.Fill(dsEOD.EOD_Sales_Report, BookDate, (int)TransTypeSales.ManualSales);
            adapterShellCards.Fill(dsEOD.EOD_ShellCards, BookDate);
            adapterReportParams.Fill(dsEOD.EODReportParams, BookDate);
            adapterSalesReportPerGLCode.Fill(dsEOD.EOD_Sales_Report_Per_GLCode, BookDate);
            adapterDiscounts.Fill(dsEOD.EOD_Discounts, BookDate);
            if (SafePayEnabled)
            {
                adapterOverfoerseTilSP.Fill(dsEOD.EOD_SafePay_OverfoerselTilSP, BookDate);
                adapterSafePayUdbetalinger.Fill(dsEOD.EOD_SafePay_Udbetalinger, BookDate);
                adapterSafePayIndbetalinger.Fill(dsEOD.EOD_SafePay_Indbetalinger, BookDate);
                adapterSafePayDepotbeholdning.FillWithValutaTekstLookup(dsEOD.EOD_SafePay_Depotbeholdning, BookDate);
                adapterSafePayValutakurser.Fill(dsEOD.EOD_SafePay_Valutakurser);
            }
#if RBA
            adapterReadings.Fill(dsEOD.Readings, BookDate);
            adapterWash.Fill(dsEOD.Wash, BookDate);
            adapterManualCards.Fill(dsEOD.EOD_ManualCards, BookDate);
            adapterForeignCurrency.Fill(dsEOD.EOD_ForeignCurrency, BookDate);
            adapterReserveTerminal.Fill(dsEOD.EOD_ReserveTerminal, BookDate);
#endif

            dsEOD.EOD_DETAIL_Valuta.Clear();
#if DETAIL
            EODDataSetTableAdapters.EOD_DETAIL_ValutaTableAdapter adapterDETAILValuta =
                new RBOS.EODDataSetTableAdapters.EOD_DETAIL_ValutaTableAdapter();
            adapterDETAILValuta.Connection = db.Connection;
            adapterDETAILValuta.Fill(dsEOD.EOD_DETAIL_Valuta, BookDate);
#endif

            // convert NULL to 0 in header data
            if (dsEOD.EODReconcileSingle.Rows.Count > 0)
            {
                DataRow headerRow = dsEOD.EODReconcileSingle[0];
                CorrectNull(headerRow, "BankDepAmount");
                CorrectNull(headerRow, "BankCardAmount");
                CorrectNull(headerRow, "ManDankortSumB");
                CorrectNull(headerRow, "TotalBank");
                CorrectNull(headerRow, "ShellCardAmount");
                CorrectNull(headerRow, "MiscCards");
                CorrectNull(headerRow, "CashDiscount");
                CorrectNull(headerRow, "ReserveTerminal");
                CorrectNull(headerRow, "TotalShell");
                CorrectNull(headerRow, "DriveOffTotal");
                CorrectNull(headerRow, "LocalCredit");
                CorrectNull(headerRow, "LocalCreditPayin");
                CorrectNull(headerRow, "ForeignCurrency");
                CorrectNull(headerRow, "TotalMisc");
                CorrectNull(headerRow, "POSSales");
                CorrectNull(headerRow, "ManualSales");
                CorrectNull(headerRow, "TotalSales");
                CorrectNull(headerRow, "TotalABC");
                CorrectNull(headerRow, "TotalD");
                CorrectNull(headerRow, "Payin");
                CorrectNull(headerRow, "Payout");
                CorrectNull(headerRow, "CashOverUnder");
                CorrectNull(headerRow, "DiscountAmount");

                if (SafePayEnabled)
                {
                    CorrectNull(headerRow, "SafePay_OverfoerselTilSP");
                    CorrectNull(headerRow, "SafePay_Udbetalinger");
                    CorrectNull(headerRow, "SafePay_Indbetalinger");
                    CorrectNull(headerRow, "SafePay_ByttepengeOptalt");
                    CorrectNull(headerRow, "SafePay_TilfoertByttepengeFraLomis");
                    CorrectNull(headerRow, "SafePay_BeloebTilfoertDobbelt");
                    CorrectNull(headerRow, "SafePay_Depotbeholdning");
                }
            }

#if RBA
            // convert NULL to 0 in wash data
            if (dsEOD.Wash.Rows.Count > 0)
            {
                DataRow washRow = dsEOD.Wash.Rows[0];
                CorrectNull(washRow, "VaskeTaellerPrimo");
                CorrectNull(washRow, "LuxusMedLakforsegler");
                CorrectNull(washRow, "LuksusVask");
                CorrectNull(washRow, "VaskA");
                CorrectNull(washRow, "VaskB");
                CorrectNull(washRow, "VaskC");
                CorrectNull(washRow, "VolumenVask");
                CorrectNull(washRow, "TeknikerVask");
                CorrectNull(washRow, "TaellerUltimoBeregnet");
                CorrectNull(washRow, "TaellerUltimoAflaest");
                CorrectNull(washRow, "SamletDifference");
            }

            // convert NULL to 0 in readings data
            if (dsEOD.Readings.Rows.Count > 0)
            {
                DataRow readingsRow = dsEOD.Readings.Rows[0];
                CorrectNull(readingsRow, "MainWaterPrimo");
                CorrectNull(readingsRow, "MainWaterReading");
                CorrectNull(readingsRow, "MainWaterUse");
                CorrectNull(readingsRow, "WashPrimo");
                CorrectNull(readingsRow, "WashReading");
                CorrectNull(readingsRow, "WashUse");
                CorrectNull(readingsRow, "KWPrimo");
                CorrectNull(readingsRow, "KWReading");
                CorrectNull(readingsRow, "KWUse");
            }
#endif

            // set report params
            if (dsEOD.EODReportParams.Rows.Count > 0)
            {
                DataRow row = dsEOD.EODReportParams.Rows[0];
                row["OnlyFirstPage"] = chkShortReport.Checked;
                row["SuppressWash"] = dsEOD.Wash.Rows.Count <= 0;
                row["SuppressReadings"] = dsEOD.Readings.Rows.Count <= 0;
                row["SuppressBankCards"] = dsEOD.EOD_BankCards.Rows.Count <= 0;
                row["SuppressBankDep"] = dsEOD.EOD_BankDep.Rows.Count <= 0;
                row["SuppressManualCards"] = dsEOD.EOD_ManualCards.Rows.Count <= 0;
                row["SuppressShellCards"] = dsEOD.EOD_ShellCards.Rows.Count <= 0;
                row["SuppressLocalCred"] = dsEOD.EOD_LocalCred_Report.Rows.Count <= 0;
                row["SuppressForeignCurrency"] = dsEOD.EOD_ForeignCurrency.Rows.Count <= 0;
                row["SuppressReserveTerminal"] = dsEOD.EOD_ReserveTerminal.Rows.Count <= 0;
                row["SuppressPayinPayout"] = dsEOD.EOD_PayinPayout.Rows.Count <= 0;
                row["SuppressSales"] = dsEOD.EOD_Sales_Report.Rows.Count <= 0;
                row["SuppressSalesPrGlCode"] = dsEOD.EOD_Sales_Report_Per_GLCode.Rows.Count <= 0;
                row["SuppressDETAILvaluta"] = dsEOD.EOD_DETAIL_Valuta.Rows.Count <= 0;
                row["SuppressSafePay"] = !SafePayEnabled;
                row["SuppressDiscounts"] = dsEOD.EOD_Discounts.Rows.Count <= 0;

#if RBA
                row["RBA"] = true;
#else
                row["RBA"] = false;
#endif

#if DETAIL
                row["DETAIL"] = true;
#else
                row["DETAIL"] = false;
#endif
            }

            // Site information
            tools.SetReportSiteInformation(report);
            
            // manually suppress some sections (easiest)
            report.Section_SalesPerGLCode.SectionFormat.EnableSuppress =
                (!chkSalesPerGLCode.Checked || chkShortReport.Checked);

            
            // set RBA sales max date
#if RBA
            tools.SetReportObjectText(report, "txtSalesMaxDate",
                EODDataSet.EOD_SalesDataTable.GetMaxSalesDate().ToString("dd-MM-yyyy"));
#endif

            // set report's data source
            report.SetDataSource((DataSet)dsEOD);
            

            // print the report
            tools.Print(report, Preview);
        }
        #endregion

        private void CorrectNull(DataRow row, string field)
        {
            if (tools.IsNullOrDBNull(row[field]))
                row[field] = 0;
        }

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

        // close button click event
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EODReportForm_Load(object sender, EventArgs e)
        {
            // localization
            btnClose.Text = db.GetLangString("Application.Close");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");
            lbExportFile.Text = db.GetLangString("EODReportFrm.lbExportFile");
            lbSalesPerGLCode.Text = db.GetLangString("EODReportFrm.lbSalesPerGLCode");
            this.Text = db.GetLangString("EODReportFrm.Title");

#if RBA
            lbSalesPerGLCode.Visible = false;
            chkSalesPerGLCode.Visible = false;
#endif
        }

        private void EODReportFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // save chkSalesPerGLCode value
            db.SetConfigString("EODSalesReportPerGLCode", chkSalesPerGLCode.Checked);
        }
    }
}