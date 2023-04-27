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
    public partial class EODDebtorTransPF : Form
    {
        private Nullable<int> SelectedDebtor = null;
        private string allDebtorsText = db.GetLangString("EODDebtorTransPF.msgAllDebtors");

        #region Constructor
        public EODDebtorTransPF()
        {
            InitializeComponent();

            // localization
            btnPrint.Text = db.GetLangString("Application.ReportPrint");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            btnClose.Text = db.GetLangString("Application.Close");
            lbDebtor.Text = db.GetLangString("EODDebtorTransPF.lbDebtor");
            lbFromDate.Text = db.GetLangString("EODDebtorTransPF.lbFromDate");
            lbToDate.Text = db.GetLangString("EODDebtorTransPF.lbToDate");
            txtDebtor.Text = allDebtorsText;
        }
        #endregion

        #region Print
        private void Print(bool preview)
        {
            // create objects for loading data
            EODDataSet ds = new EODDataSet();
            EODDataSetTableAdapters.EOD_Debtor_TransReportHeaderTableAdapter adapterHeader =
                new RBOS.EODDataSetTableAdapters.EOD_Debtor_TransReportHeaderTableAdapter();
            EODDataSetTableAdapters.EOD_Debtor_TransReportDetailsTableAdapter adapterDetails =
                new RBOS.EODDataSetTableAdapters.EOD_Debtor_TransReportDetailsTableAdapter();
            adapterHeader.Connection = db.Connection;
           // adapterHeader.Connection = dbOleDb.Connection;
            adapterDetails.Connection = db.Connection;

            // if one debtor has been selected, the active flag is ignored.
            // if all debtors have been selected, the active flag is checked for true.
            //Nullable<bool> Active = null; // if one debtor has been selected peter20190514
            
            // prepare start/end dates (unchecked dates are set to first/last dates)
            DateTime StartDate;
            DateTime EndDate;
            if (dtFromDate.Checked)
                StartDate = dtFromDate.Value.Date;
            else
                StartDate = EODDataSet.EOD_LocalCredDataTable.GetFirstDate(SelectedDebtor);
            if (dtToDate.Checked)
                EndDate = dtToDate.Value.Date;
            else
                EndDate = EODDataSet.EOD_LocalCredDataTable.GetLastDate(SelectedDebtor);

            // load data
            if (SelectedDebtor == null)
            {
                adapterHeader.FillAll(ds.EOD_Debtor_TransReportHeader);
                adapterDetails.FillAll(ds.EOD_Debtor_TransReportDetails, StartDate, EndDate);
            }
            else
            {
                adapterHeader.Fill(ds.EOD_Debtor_TransReportHeader, SelectedDebtor);
                adapterDetails.Fill(ds.EOD_Debtor_TransReportDetails, SelectedDebtor, StartDate, EndDate);
            }

            

            // check we have data
            if (ds.EOD_Debtor_TransReportDetails.Rows.Count > 0)
            {
                // perform various stuff on the detail dataset per debtor
                foreach (DataRow row in ds.EOD_Debtor_TransReportHeader.Rows)
                {
                    // get the current debtor and it's related detail records
                    int DebtorNo = tools.object2int(row["DebtorNo"]);
                    DataRow[] detailRows = ds.EOD_Debtor_TransReportDetails.Select("CustomerNo = " + DebtorNo.ToString());

                    if (detailRows.Length == 0)
                    {
                        // if after loading data, a debtor does not have
                        // any detail records, do not print the debtor
                        row["SuppressInPrint"] = true;
                    }
                    else
                    {
                        
                     
                        // accumulate all amounts up til the selected date interval
                        double amountAcc = tools.object2double(db.ExecuteScalar(string.Format(
                            " select sum(choose(TransType, - EOD_LocalCred.Amount, EOD_LocalCred.Amount, EOD_LocalCred.Amount)) as Amount " +
                            " from EOD_LocalCred " +
                            " where (CustomerNo = {0}) " +
                            " and BookDate < dbo.cdate('{1}') ",
                            DebtorNo,
                            StartDate)));
                        
                        // keep this accumulated amounts to display in print as previous saldo
                        row["PrevSaldo"] = amountAcc;

                        // accumulate amounts in the selected date interval
                        foreach (DataRow detailRow in detailRows)
                        {
                            // calculate running totals for this debtor
                            detailRow["AmountAcc"] = amountAcc + tools.object2double(detailRow["Amount"]);
                            amountAcc = tools.object2double(detailRow["AmountAcc"]);
                        }

                        // if debtor does not have anything in the remarks field,
                        // and the station has a standard remark, insert the standard remark
                        if (tools.object2string(row["Remarks"]) == "")
                        {
                            string StandardDebtorStatementRemarks = db.GetConfigString("EOD.Debtor.Statement.StandardRemarks");
                            if (StandardDebtorStatementRemarks != "")
                            {
                                row["Remarks"] = StandardDebtorStatementRemarks;
                            }
                        }
                    }
                }

                // add site information to report
                tools.SetReportSiteInformation(rptEODDebtorTrans);

                // add SE and BankAccount information to report
                tools.SetReportObjectText(rptEODDebtorTrans, "txtSE", AdminDataSet.SiteInformationDataTable.GetSE());
                tools.SetReportObjectText(rptEODDebtorTrans, "txtBankAccount", AdminDataSet.SiteInformationDataTable.GetBankAccount());

                // set date from - to
                string dateFrom = StartDate.ToString("dd-MM-yyyy");
                string dateTo = EndDate.ToString("dd-MM-yyyy");
                tools.SetReportObjectText(rptEODDebtorTrans, "DateFromTo", dateFrom + " - " + dateTo);

                // print
                rptEODDebtorTrans.SetDataSource(ds);
                tools.Print(rptEODDebtorTrans, preview);
            }
            else
            {
                MessageBox.Show(db.GetLangString("Application.NoDataToPrint"));
            }
        }
        #endregion

        #region ResetDates
        private void ResetDates()
        {
            DateTime MinDate, MaxDate;
            GetMinMaxDBDatesForCurrentDebitor(out MinDate, out MaxDate);

            // below must be done in the order written

            dtFromDate.MinDate = DateTimePicker.MinimumDateTime;
            dtFromDate.MaxDate = DateTimePicker.MaximumDateTime;
            dtToDate.MinDate = DateTimePicker.MinimumDateTime;
            dtToDate.MaxDate = DateTimePicker.MaximumDateTime;

            if ((MinDate != DateTime.MinValue) && (MaxDate != DateTime.MaxValue))
            {
                // if there are records in EOD_LocalCred
                // we take the last date and use that to
                // make a default interval
                dtToDate.Value = MaxDate;
                dtFromDate.Value = tools.GetFirstDateInMonth(MaxDate);

                dtFromDate.MinDate = MinDate;
                dtFromDate.MaxDate = MaxDate;
                dtToDate.MinDate = MinDate;
                dtToDate.MaxDate = MaxDate;
            }

            dtFromDate.Checked = false;
            dtToDate.Checked = false;
        }
        #endregion

        #region GetMinMaxDBDatesForCurrentDebitor
        private void GetMinMaxDBDatesForCurrentDebitor(out DateTime MinDate, out DateTime MaxDate)
        {
            string whereClause = "";
            if (SelectedDebtor != null)
                whereClause = " where CustomerNo = " + SelectedDebtor.Value.ToString();

            DataRow row = db.GetDataRow(string.Format(@"
                select min(BookDate) as MinDate, max(BookDate) as MaxDate
                from EOD_LocalCred {0} "
                , whereClause));
            if (row != null)
            {
                MinDate = tools.object2datetime(row["MinDate"]);
                MaxDate = tools.object2datetime(row["MaxDate"]);
            }
            else
            {
                MinDate = DateTime.MinValue;
                MaxDate = DateTime.MaxValue;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDebtor_Click(object sender, EventArgs e)
        {
            // select debtor or select no debtor (all debtors)
            EODDebtorPopup debtor = new EODDebtorPopup(true);
            debtor.DisplaySelectNoneButton = true;
            if(SelectedDebtor != null)
                debtor.SelectedDebtorNo = SelectedDebtor.Value;
            if (debtor.ShowDialog() == DialogResult.OK)
            {
                if (debtor.SelectedDebtorNo.HasValue)
                {
                    SelectedDebtor = debtor.SelectedDebtorNo.Value;
                    txtDebtor.Text = debtor.SelectedDebtorName1;
                }
                else
                {
                    SelectedDebtor = null;
                    txtDebtor.Text = allDebtorsText;
                }
                ResetDates();
            }
        }

        private void EODDebtorTransPF_Load(object sender, EventArgs e)
        {
            ResetDates();
        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
            dtToDate.MinDate = dtFromDate.Value;
        }

        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {
            dtFromDate.MaxDate = dtToDate.Value;
        }
    }
}