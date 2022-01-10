using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class OrderReportForm : Form
    {
        #region Private variables

        private int OrderID = -1;

        #endregion

        #region Constructor
        public OrderReportForm(int OrderID)
        {
            InitializeComponent();

            this.DialogResult = DialogResult.Cancel;

            this.OrderID = OrderID;
            txtOrderID.Text = OrderID.ToString();
            txtSupplier.Text = ItemDataSet.OrderHeaderDataTable.GetSupplierName(OrderID);

            // load show cost checkbox state
            chkShowCost.Checked = db.GetConfigStringAsBool("OrderReportForm.ShowCostChecked");
        }
        #endregion

        private void Print(bool preview)
        {
            // create adapters
            ReportDataSetTableAdapters.OrderHeaderTableAdapter adapterOrderHeader =
                new RBOS.ReportDataSetTableAdapters.OrderHeaderTableAdapter();
            ReportDataSetTableAdapters.OrderDetailsTableAdapter adapterOrderDetails =
                new RBOS.ReportDataSetTableAdapters.OrderDetailsTableAdapter();

            // set connections
            adapterOrderHeader.Connection = db.Connection;
            adapterOrderDetails.Connection = db.Connection;

            // create dataset (we need two tables to be passed to the report)
            ReportDataSet ds = new ReportDataSet();

            // load data
            adapterOrderHeader.Fill(ds.OrderHeader, OrderID);
            if (ddOrderBy.SelectedIndex == 0)
                adapterOrderDetails.FillByOrderingNumber(ds.OrderDetails, OrderID);
            else
                adapterOrderDetails.FillByReceiptText(ds.OrderDetails, OrderID);

            // set calculated field ShowCostCalc in header
            if (ds.OrderHeader.Rows.Count > 0)
                ds.OrderHeader.Rows[0]["ShowCostCalc"] = chkShowCost.Checked;

            // create report at assign the loaded data
            OrderReport report = new OrderReport();
            report.SetDataSource(ds);

            // print report
            tools.Print(report, preview);
        }

        // cancel button click event
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // btnPrint click event
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print(false);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        // btnPreview click event
        private void btnPreview_Click(object sender, EventArgs e)
        {
            Print(true);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        // form closing event
        private void OrderReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // save show cost checkbox state
            db.SetConfigString("OrderReportForm.ShowCostChecked", chkShowCost.Checked.ToString());
        }

        private void OrderReportForm_Load(object sender, EventArgs e)
        {
            // Localization
            this.Text = db.GetLangString("OrderPrintForm.Title");
            btnCancel.Text = db.GetLangString("Application.Cancel");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");
            lbOrderID.Text = db.GetLangString("OrderPrintForm.OrderIDLabel");
            lbSupplier.Text = db.GetLangString("OrderPrintForm.SupplierLabel");
            txtShowCost.Text = db.GetLangString("OrderPrintForm.ShowCostLabel");
            lbOrderBy.Text = db.GetLangString("OrderReportForm.lbOrderBy");

            // fill order by selection box
            ddOrderBy.Items.Clear();
            ddOrderBy.Items.Add(db.GetLangString("OrderReportForm.ddOrderByItem1"));
            ddOrderBy.Items.Add(db.GetLangString("OrderReportForm.ddOrderByItem2"));
            if (ddOrderBy.Items.Count > 0)
                ddOrderBy.SelectedIndex = 0;
        }
    }
}