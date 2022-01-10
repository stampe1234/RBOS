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
    public partial class ItemTransStockCountReportFormRBA : Form
    {
        #region Constructor
        public ItemTransStockCountReportFormRBA()
        {
            InitializeComponent();
        }
        #endregion

        #region FillUltimoDateControls
        private void FillUltimoDateControls()
        {
            // build ultimo years
            List<int> Years = new List<int>();
            for (int i = 2000; i <= DateTime.Now.Year; i++)
                Years.Add(i);
            ddUltimoYear.DataSource = Years;

            // build ultimo months
            List<int> Months = new List<int>();
            for (int i = 1; i <= 12; i++)
                Months.Add(i);
            ddUltimoMonth.DataSource = Months;

            // find the date of the last transaction and pre-select that as ultimodate
            DateTime LastUltimoDate = ItemDataSet.ItemTransactionStockCountRBADataTable.GetLastUltimoDate();
            if (LastUltimoDate != DateTime.MinValue)
            {
                ddUltimoYear.SelectedIndex = ddUltimoYear.Items.IndexOf(LastUltimoDate.Year);
                ddUltimoMonth.SelectedIndex = ddUltimoMonth.Items.IndexOf(LastUltimoDate.Month);
            }
            else
            {
                // no last ultimodate was found, probably because no registrations were found,
                // so clear the dropdown boxes selections
                ddUltimoYear.SelectedIndex = -1;
                ddUltimoMonth.SelectedIndex = -1;
            }
        }
        #endregion

        #region GetUltimoDate
        /// <summary>
        /// Uses the selected year and month from the dropdowns and creates the ultimodate.
        /// If some error occurs or some invalid values exist, DateTime.MinValue is returned.
        /// </summary>
        /// <returns></returns>
        private DateTime GetUltimoDate()
        {
            try
            {
                int year = tools.object2int(ddUltimoYear.SelectedValue);
                int month = tools.object2int(ddUltimoMonth.SelectedValue);
                return tools.GetLastDateInMonth(new DateTime(year, month, 1));
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
        #endregion

        #region LoadData
        private void LoadData()
        {
            // localization
            btnClose.Text = db.GetLangString("Application.Close");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            lbUltimoDate.Text = db.GetLangString("ItemTransStockCountReportFormRBA.lbUltimoDate");
            lbVisVaredetaljer.Text = db.GetLangString("ItemTransStockCountReportFormRBA.lbVisVaredetaljer");
            lbCreateOPTfile.Text = db.GetLangString("ItemTransStockCountReportFormRBA.lbCreateOPTfile");

            FillUltimoDateControls();
        }
        #endregion

        private void Print(bool Preview)
        {
            // create and setup adapter
            ReportDataSetTableAdapters.ItemTransactionStockCountRBATableAdapter adapter =
                new RBOS.ReportDataSetTableAdapters.ItemTransactionStockCountRBATableAdapter();
            adapter.Connection = db.Connection;

            // create dataset
            ReportDataSet ds = new ReportDataSet();

            // get ultimodate and verify it
            DateTime UltimoDate = GetUltimoDate();
            if (UltimoDate == DateTime.MinValue)
            {
                MessageBox.Show(db.GetLangString("ItemTransStockCountReportFormRBA.SelectUltimoDate"));
                return;
            }
            
            // load transaction data
            adapter.Fill(ds.ItemTransactionStockCountRBA, UltimoDate);

            // check that any data were loaded
            if (ds.ItemTransactionStockCountRBA.Rows.Count <= 0)
            {
                MessageBox.Show(db.GetLangString("Application.NoDataToPrint"));
                return;
            }

            // set report parameters
            ds.ItemTransactionStockCountRBAParams.AddItemTransactionStockCountRBAParamsRow(
                chkVisVaredetaljer.Checked);

            // create and setup report
            ItemTransStockCountReportRBA report = new ItemTransStockCountReportRBA();
            report.SetDataSource((DataSet)ds);

            // retrieve unbound report objects
            ReportObjects reportObjects = report.ReportDefinition.ReportObjects;
            TextObject toUltimoDate = (TextObject)reportObjects["UltimoDate"];
            
            // set the unbound report object values
            toUltimoDate.Text = UltimoDate.ToString("dd-MM-yyyy");
            
            // set site information
            tools.SetReportSiteInformation(report);

            // print the report
            tools.Print(report, Preview);

            // create OPT export file if user has selected so
            if (chkCreateOPTfile.Checked)
                ExportAccounting.GenerateOPTFileRBA(UltimoDate.Date);
        }

        private void StockCountRegistrationRBARpt_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print(false);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Print(true);
        }
    }
}