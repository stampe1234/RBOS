using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class EODOverview : Form
    {
        public EODOverview()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            adapterEODReconcile.Connection = db.Connection;
            adapterEODReconcile.Fill(dsEOD.EODReconcile);
        }

        private void NewDay()
        {
            if (EODDataSet.EODReconcileDataTable.CreateNewDayRecord())
            {
                LoadData();
                bindingEODReconcile.MoveFirst(); // should be done implicit, but I want to be 100% sure
                Open();
            }
        }

        private void Open()
        {
            if(bindingEODReconcile.Current == null) return;
            DataRowView row = (DataRowView)bindingEODReconcile.Current;

            // if record is not closed, open it
            if (!tools.object2bool(row["Closed"]))
            {
                DateTime BookDate = tools.object2datetime(row["BookDate"]);
#if !DETAIL
                EODDetails details = new EODDetails(BookDate);
                details.ShowDialog();
#else
                EODDetailsDETAIL details = new EODDetailsDETAIL(BookDate);
                details.ShowDialog();
#endif
                LoadData();
            }
            else
            {
                MessageBox.Show(db.GetLangString("EODOverview.CannotOpenAClosedEOD"));
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(bindingEODReconcile.Current == null) return;
            DataRowView row = (DataRowView)bindingEODReconcile.Current;

            DateTime BookDate = tools.object2datetime(row["BookDate"]);
            EODReportFrm report = new EODReportFrm(BookDate);
            report.ShowDialog();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewDay();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Open();
        }

        private void EODOverview_Load(object sender, EventArgs e)
        {
            int index = 0;
            colBookDate.DisplayIndex = index++;
            ColTotalPaymentABC.DisplayIndex = index++;
            colTotalSalesD.DisplayIndex = index++;
            colBankDepAmount.DisplayIndex = index++;
            colPayinTotal.DisplayIndex = index++;
            colPayoutTotal.DisplayIndex = index++;
            colCashOverUnder.DisplayIndex = index++;
            colApprovedBy.DisplayIndex = index++;
            colClosed.DisplayIndex = index++;

            this.Text = db.GetLangString("EODOverviewForm.HeaderLbl");

            colBookDate.HeaderText = db.GetLangString("EODOverviewForm.BookdateLbl");
            ColTotalPaymentABC.HeaderText = db.GetLangString("EODOverviewForm.TotalPaymentLbl");
            colTotalSalesD.HeaderText = db.GetLangString("EODOverviewForm.TotalSalesLbl");
            colPayinTotal.HeaderText = db.GetLangString("EODOverviewForm.PayinTotalLbl");
            colPayoutTotal.HeaderText = db.GetLangString("EODOverviewForm.PayoutTotalLbl");
            colCashOverUnder.HeaderText = db.GetLangString("EODOverviewForm.CashOverUnderLbl");
            colApprovedBy.HeaderText = db.GetLangString("EODOverviewForm.ApprovedByLbl");
            colClosed.HeaderText = db.GetLangString("EODOverviewForm.ClosedLbl");
            colBankDepAmount.HeaderText = db.GetLangString("EODOverview.colBankDepAmount");
            btnClose.Text = db.GetLangString("Application.Close");
            btnPrint.Text = db.GetLangString("EODOverviewForm.EODReportLbl");
            btnOpen.Text = db.GetLangString("EODOverviewForm.OpenLbl");
            btnNew.Text = db.GetLangString("EODOverviewForm.NewDayLbl");
            btnGenerateEODFile.Text = db.GetLangString("EODOverviewForm.btnGenerateEODFile");

            if ((db.GetConfigString("RegnskabIF_flag") != "service") &&
                (db.GetConfigString("RegnskabIF_flag") != "local"))
                btnGenerateEODFile.Visible = false;

#if RBA
            // show/hide some columns in RBA mode
            ColTotalPaymentABC.Visible = false;
            colTotalSalesD.Visible = false;
            colCashOverUnder.Visible = false;
            colBankDepAmount.Visible = true;

            // resize the form in RBA mode
            this.Width = this.Width -
                ColTotalPaymentABC.Width -
                colTotalSalesD.Width -
                colCashOverUnder.Width +
                colBankDepAmount.Width;
#endif
        }

        private void btnGenerateEODFile_Click(object sender, EventArgs e)
        {
            if (bindingEODReconcile.Current == null) return;
            DataRowView row = (DataRowView)bindingEODReconcile.Current;

            // check that EOD record has been marked as closed,
            // and if not, tell user that EOD file cannot be re-generated yet
            if (!tools.object2bool(row["Closed"]))
            {
                MessageBox.Show(db.GetLangString("EODOverview.CannotRegenrateEODFileYet"));
                return;
            }

            // EOD record has been marked as closed, so re-generate the EOD/OPG file
#if !RBA
            if (ExportAccounting.GenerateEODFile(tools.object2datetime(row["BookDate"])))
                MessageBox.Show(db.GetLangString("EODOverview.EODFileGenerated"));
#else
            if (ExportAccounting.GenerateOPGFile(tools.object2datetime(row["BookDate"])))
                MessageBox.Show(db.GetLangString("EODOverview.OPGFileGenerated"));
#endif
        }
    }
}
