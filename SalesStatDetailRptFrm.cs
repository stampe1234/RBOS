using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class SalesStatDetailRptFrm : Form
    {
        #region Constructor
        public SalesStatDetailRptFrm()
        {
            InitializeComponent();

            // localization
            btnClose.Text = db.GetLangString("Application.Close");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            lbSelectDate.Text = db.GetLangString("SalesStatRptFrm.lbSelectDate");
        }
        #endregion

        #region Print
        private void Print(bool Preview)
        {
            // collect data
            SalesStatDS ds = new SalesStatDS();
            SalesStatDSTableAdapters.SalesStatRptTableAdapter adapter =
                new RBOS.SalesStatDSTableAdapters.SalesStatRptTableAdapter();
            Dictionary<string,string> ColumnHeaders = new Dictionary<string,string>();
            Dictionary<string,string> ColumnUnitOrAmount = new Dictionary<string,string>();
            adapter.FillWithCollectedData(
                ds.SalesStatRpt,
                ColumnHeaders,
                ColumnUnitOrAmount,
                dtEndDate.Value);

            // save collected data to database for 1-step history
            adapter.EmptyTableOnDisk();
            adapter.Update(ds.SalesStatRpt);

            // assign dynamic column headers
            tools.SetReportObjectText(rptSalesStatDetail, "txtTotalShop", ColumnHeaders["TotalShop"]);
            tools.SetReportObjectText(rptSalesStatDetail, "txtTotalBenzin", ColumnHeaders["TotalBenzin"]);
            tools.SetReportObjectText(rptSalesStatDetail, "txtTotalDiesel", ColumnHeaders["TotalDiesel"]);
            tools.SetReportObjectText(rptSalesStatDetail, "txtCustom1", ColumnHeaders["Custom1"]);
            tools.SetReportObjectText(rptSalesStatDetail, "txtCustom2", ColumnHeaders["Custom2"]);
            tools.SetReportObjectText(rptSalesStatDetail, "txtCustom3", ColumnHeaders["Custom3"]);
            tools.SetReportObjectText(rptSalesStatDetail, "txtGnsSalgKolPrKunde", ColumnHeaders["GnsSalgKolPrKunde"]);

            // assign dynamic column unit/amount
            tools.SetReportObjectText(rptSalesStatDetail, "txtTotalShopUnit", ColumnUnitOrAmount["TotalShop"]);
            tools.SetReportObjectText(rptSalesStatDetail, "txtTotalBenzinUnit", ColumnUnitOrAmount["TotalBenzin"]);
            tools.SetReportObjectText(rptSalesStatDetail, "txtTotalDieselUnit", ColumnUnitOrAmount["TotalDiesel"]);
            tools.SetReportObjectText(rptSalesStatDetail, "txtCustom1Unit", ColumnUnitOrAmount["Custom1"]);
            tools.SetReportObjectText(rptSalesStatDetail, "txtCustom2Unit", ColumnUnitOrAmount["Custom2"]);
            tools.SetReportObjectText(rptSalesStatDetail, "txtCustom3Unit", ColumnUnitOrAmount["Custom3"]);
            tools.SetReportObjectText(rptSalesStatDetail, "txtGnsSalgKolPrKundeUnit", ColumnUnitOrAmount["GnsSalgKolPrKunde"]);

            // set date interval display string
            string datointerval = string.Format("{0} - {1}",
                tools.GetFirstDateInMonth(dtEndDate.Value).ToString("dd-MM-yyyy"),
                dtEndDate.Value.ToString("dd-MM-yyyy"));                
            tools.SetReportObjectText(rptSalesStatDetail, "txtDatoInterval", datointerval);

            // set site information
            tools.SetReportSiteInformation(rptSalesStatDetail);

            // set title
            string title = string.Format("Daglig salgsstatistik, {0}", dtEndDate.Value.ToString("MMMM yyyy"));
            tools.SetReportObjectText(rptSalesStatDetail, "txtTitle", title);

            // print
            rptSalesStatDetail.SetDataSource(ds);
            tools.Print(rptSalesStatDetail, Preview);
        }
        #endregion

        #region SetMinMaxDateRange
        /// <summary>
        /// Set min/max possible dates for the date selector.
        /// </summary>
        private void SetMinMaxDateRange()
        {
            dtEndDate.MinDate = EODDataSet.EOD_SalesDataTable.GetMinSalesDate();
            dtEndDate.MaxDate = EODDataSet.EOD_SalesDataTable.GetMaxSalesDate();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SalesStatDetailRptFrm_Load(object sender, EventArgs e)
        {
            SetMinMaxDateRange();
        }
    }
}