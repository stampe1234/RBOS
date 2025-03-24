using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class EODDetails : Form
    {
        private DateTime BookDate;

        public EODDetails(DateTime BookDate)
        {
            InitializeComponent();
            this.BookDate = BookDate;
        }

        private void LoadData()
        {
            adapterReconcileSingle.Connection = db.Connection;
            adapterReconcileSingle.Fill(dsEOD.EODReconcileSingle, BookDate);
            txtCustomerCountDO.Text = EODDataSet.EODReconcileExDataTable.GetCustomerCount(BookDate).ToString();
#if RBA
            DateTime SalesMaxDate = EODDataSet.EOD_SalesDataTable.GetMaxSalesDate();
            if (SalesMaxDate != DateTime.MinValue)
                txtSalesMaxDate.Text = SalesMaxDate.ToString("dd-MM-yyyy");
#endif

            // check if any SafePay data has arrived and import if so
            // then calculate totals for EODReconcile record
            if (db.GetConfigStringAsBool("SafePay.Enabled"))
            {
                ImportSafePay.ImportFiles();
                if (bindingReconcileSingle.Current != null)
                {
                    DataRowView row = (DataRowView)bindingReconcileSingle.Current;
                    row["SafePay_Udbetalinger"] = EODDataSet.EOD_SafePay_UdbetalingerDataTable.GetTotalAmount(BookDate);
                    row["SafePay_Indbetalinger"] = EODDataSet.EOD_SafePay_IndbetalingerDataTable.GetTotalAmount(BookDate);
                    row["SafePay_OverfoerselTilSP"] = EODDataSet.EOD_SafePay_OverfoerselTilSPDataTable.GetTotalAmount(BookDate);
                    row["SafePay_Depotbeholdning"] = EODDataSet.EOD_SafePay_DepotbeholdningDataTable.GetTotalAmount(BookDate);
                    
                }

            }

#if DETAIL
            if (!ImportConcernoPOS.ImportFiles())
                MessageBox.Show(ImportConcernoPOS.LastError);
#endif
        }

        private void SaveData()
        {
            bindingReconcileSingle.EndEdit();
            EODDataSet.EODReconcileSingleDataTable.UpdateWolt(BookDate, tools.object2double(txtManCardAmountSP.Text));
            adapterReconcileSingle.Update(dsEOD.EODReconcileSingle);
            EODDataSet.EODReconcileExDataTable.InsertOrUpdateRecord(BookDate, tools.object2int(txtCustomerCountDO.Text));
           
        }

        private void Approve()
        {
            string msg = "";

            if (bindingReconcileSingle.Current == null) return;
            DataRowView row = (DataRowView)bindingReconcileSingle.Current;
            bindingReconcileSingle.EndEdit();

            // check if user has entered name
            if (tools.object2string(row["ApprovedBy"]) == "")
            {
                MessageBox.Show(db.GetLangString("EODDetails.ApprovedByCannotBeEmpty"), "", MessageBoxButtons.OK);
                return;
            }
#if !RBA
            // check if it is ok to end with a pos sales of 0
            if (tools.object2double(row["POSSales"]) == 0)
            {
                msg = db.GetLangString("EODDetails.RSMSalesIs0");
                if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
            }
#endif
            // check if it is ok to end with a bank deposit of 0

            if (!db.GetConfigStringAsBool("SafePay.Enabled"))
            {
                if (tools.object2double(row["TotalBank"]) == 0)
                {
                    msg = db.GetLangString("EODDetails.BankDepositIs0");
                    if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;
                }
            }
#if !RBA
            // check if it is ok to end with shell cards value of 0
            if (tools.object2double(row["TotalShell"]) == 0)
            {
                msg = db.GetLangString("EODDetails.ShellCardsTotalIs0");
                if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
            }

            /// If customer count is below a certain treshhold value,
            /// ask user if it is ok to end the day with that.
            /// Note that we che ck the UI field as it has not yet been saved to the database.
            int CustomerCount = tools.object2int(txtCustomerCountDO.Text);
            int CustomerCountThreshold = db.GetConfigStringAsInt("EOD.CustomerCountThreshold");
            if (CustomerCount < CustomerCountThreshold)
            {
                msg = string.Format(db.GetLangString("EODDetails.CustomerCountTooLow"), CustomerCountThreshold);
                if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
            }

            // final DO approve prompt
            double CashOverUnder = tools.object2double(row["CashOverUnder"]);
            msg = string.Format(db.GetLangString("EODDetails.WantToApproveEOD"), CashOverUnder.ToString("N2"));
            if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
#endif

#if RBA
            //
            if (db.GetConfigStringAsBool("Readings.StationHasWash") &&
                db.GetConfigStringAsBool("EOD.CheckForWashCount") &&
                tools.object2int(row["NumberOfWashSold"]) == 0)
            {
                msg = db.GetLangString("EODDetails.NumWashSoldMustBeFilledIn");
                MessageBox.Show(msg);
                return;
            }

            // RBA things to check for, if this is the last day in the month
            if (tools.IsLastDayInMonth(BookDate.Date))
            {
                // verify that a reading has been done for the day,
                string msgReadings;
                if (!EODDataSet.ReadingsDataTable.ValidReadingsExist(BookDate.Date, out msgReadings))
                {
                    MessageBox.Show(msgReadings);
                    return;
                }

                // if the station has wash, verify that ultimo aflæst is positive
                if (db.GetConfigStringAsBool("Readings.StationHasWash"))
                {
                    string ErrorMessage;
                    if (!EODDataSet.WashDataTable.ValidReadingsExist(BookDate.Date, out ErrorMessage))
                    {
                        MessageBox.Show(ErrorMessage);
                        return;
                    }
                }
            }

            if (db.GetConfigStringAsBool("WasteRBA.Active"))
            {
                // check that there are no unbooked waste registrations
                if (ItemDataSet.WasteRegistrationRBADataTable.CheckIfAnyUnbookedRecords())
                {
                    MessageBox.Show(db.GetLangString("EODDetails.UnbookedRBAWasteRegistrations"));
                    return;
                }
                // check if there are ALSO no waste registrations booked at all
                else if (!ItemDataSet.ItemTransactionRBADataTable.CheckIfAnyTransactionRecords(BookDate))
                {
                    if (MessageBox.Show(db.GetLangString("EODDetails.AnyRBATransactions"), "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;
                }
            }

            if (db.GetConfigStringAsBool("SafePay.Enabled"))
            {
                // SafePay byttepenge optalt skal være udfyldt, men der skal
                // enten checkes dagligt eller månedligt den sidste dag i måneden
                bool SafePayByttepengeDaily = db.GetConfigStringAsBool("SafePay.ByttepengeOptalt.Daily");
                if (SafePayByttepengeDaily || tools.IsLastDayInMonth(BookDate.Date))
                {
                    if (tools.object2double(row["SafePay_ByttepengeOptalt"]) == 0)
                    {
                        MessageBox.Show(db.GetLangString("EODDetails.SafePayByttepengeOptaltMissing"));
                        return;
                    }
                }

                /// Der skal tjekks for om der er modtaget SafePay data. Det gør
                /// vi ved at se om der er kommet data i depot-tabellen, da vi
                /// antager, at der altid kommer import data til den tabel og bruger
                /// kan ikke manuelt indtaste data til den tabel.
                if (EODDataSet.EOD_SafePay_DepotbeholdningDataTable.GetRowCount(BookDate) <= 0)
                {
                    MessageBox.Show(db.GetLangString("EODDetails.SafePayMissingImportData"));
                    return;
                }
            }

            // final RBA approve prompt
            msg = db.GetLangString("EODDetails.FinalRBAApprovePrompt");
            if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
#endif

            // close (approve) the EOD
            row["Closed"] = 1;
            // row["BookDate"] = "11-09-2018 00:00:00";
            EODDataSet.EODReconcileSingleDataTable.UpdateWolt(BookDate, tools.object2double(txtManCardAmountSP.Text)); //pn20240403
            bindingReconcileSingle.EndEdit();
            adapterReconcileSingle.Update(dsEOD.EODReconcileSingle);

            // EOD is close by now. the following generates various output files
            
#if !RBA
            // generate EOD file if applicable
            ExportAccounting.GenerateEODFile(tools.object2datetime(row["BookDate"]));

            // generate VGS file if data present and if enabled and if it's the last day in the month
            if (db.GetConfigStringAsBool("ExportVGS.Enabled") && tools.IsLastDayInMonth(BookDate))
            {
                ExportVGS vgs = new ExportVGS();
                vgs.Export(BookDate.Month, BookDate.Year);
            }
#else
            // generate EOD file if applicable
            ExportAccounting.GenerateOPGFile(tools.object2datetime(row["BookDate"]));
#endif

            // close window
            Close();
        }

        private void ReImport()
        {
            string msg = db.GetLangString("EODDetails.ReimportRSMData");//pn20200123
            if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // re-import RSM data
                SaveData();
                EODDataSet.EODReconcileDataTable.ReImportRSMDataForEOD(BookDate);
                LoadData();
            }
        }

        private void EODDetails_Load(object sender, EventArgs e)
        {


            LoadData();

            // localization

            this.Text = db.GetLangString("EODDetailsForm.HeaderLbl");

            tabBankOgShell.Text = db.GetLangString("EODDetailsForm.BankShellTabLbl");
            tabDivOgSalg.Text = db.GetLangString("EODDetailsForm.MiscSalesTabLbl");
            tabOpgoerelse.Text = db.GetLangString("EODDetailsForm.ReconcileTabLbl");
            lbBankDepAmount.Text = db.GetLangString("EODDetailsForm.BankDepLbl");
            lbTotalBank.Text = db.GetLangString("EODDetailsForm.TotalBankLbl");
            lbShellCardAmount.Text = db.GetLangString("EODDetailsForm.ShellCardsLbl");
            lbMiscCardAmount.Text = db.GetLangString("EODDetailsForm.MiscCardsLbl");
            lbManCardAmount.Text = db.GetLangString("EODDetailsForm.ManualCardsLbl");
            lbTotalShell.Text = db.GetLangString("EODDetailsForm.TotalShellLbl");
            lbDriveOff.Text = db.GetLangString("EODDetailsForm.DriveOffsLbl");
            lbLocalCredit.Text = db.GetLangString("EODDetailsForm.LocalCreditLbl");
            lbLocalCreditPayin.Text = db.GetLangString("EODDetailsForm.LocalCredPayinLbl");
            lbForrCurrency.Text = db.GetLangString("EODDetailsForm.ForCurrencyLbl");
            lbMiscTotal.Text = db.GetLangString("EODDetailsForm.TotalMiscLbl");
            lbTotalSalesRSM.Text = db.GetLangString("EODDetailsForm.TotalPOSSalesLbl");
            lbManualSales.Text = db.GetLangString("EODDetailsForm.TotalManSalesLbl");
            lbSalesTotal.Text = db.GetLangString("EODDetailsForm.SalesTotalLbl");
            lbTotalABC.Text = db.GetLangString("EODDetailsForm.TotalPayinLbl");
            lbTotalOfD.Text = db.GetLangString("EODDetailsForm.TotalSalesDLbl");
            lbPayinTotal.Text = db.GetLangString("EODDetailsForm.PayinTotalLbl");
            lbPayout.Text = db.GetLangString("EODDetailsForm.PayoutTotalLbl");
            lbCashDiff.Text = db.GetLangString("EODDetailsForm.CashOverUnderLbl");
            lbApprovedBy.Text = db.GetLangString("EODDetailsForm.ApprovedByLbl");
            lbBookDate.Text = db.GetLangString("EODDetailsForm.BookDateLbl");
            lbCustomerCountDO.Text = db.GetLangString("EODDetailsForm.lbCustomerCountDO");
            tabSafePay.Text = db.GetLangString("EODDetailsForm.tabSafePay");
            lbEODSafePayIndbetalinger.Text = db.GetLangString("EODDetailsForm.lbEODSafePayIndbetalinger");
            lbTransferExchangeToSafePay.Text = db.GetLangString("EODDetailsForm.lbTransferExchangeToSafePay");
            lbSafePayUdbetalinger.Text = db.GetLangString("EODDetailsForm.lbSafePayUdbetalinger");
            lbSafePayByttepengeOptalt.Text = db.GetLangString("EODDetailsForm.lbSafePayByttepengeOptalt");
            lbSafePayTilfoertByttepengeFraLomis.Text = db.GetLangString("EODDetailsForm.lbSafePayTilfoertByttepengeFraLomis");
            lbSafePayBeloebTilfoertDobbelt.Text = db.GetLangString("EODDetailsForm.lbSafePayBeloebTilfoertDobbelt");
            lbSafePayDepotbeholding.Text = db.GetLangString("EODDetailsForm.lbSafePayDepotbeholding");
            GroupSafePayValutakurser.Text = db.GetLangString("EODDetailsForm.GroupSafePayValutakurser");
            lbDiscountAmount.Text = db.GetLangString("EODDetailsForm.lbDiscountAmount");

            // many of the RBA strings are gotten from the DO strings
            lbBankDepAmountRBA.Text = db.GetLangString("EODDetailsForm.BankDepLbl");
            lbManualCardsRBA.Text = db.GetLangString("EODDetailsForm.ManualCardsLblRBA");
            lbCashDiscountAmountRBA.Text = db.GetLangString("EODDetailsForm.CashdiscountLbl");
            lbForeignCurrencyRBA.Text = db.GetLangString("EODDetailsForm.ForCurrencyLbl");
            lbReserveTerminalRBA.Text = db.GetLangString("EODDetailsForm.lbReserveTerminalRBA");
            lbLocalCreditRBA.Text = db.GetLangString("EODDetailsForm.LocalCreditLbl");
            lbLocalCreditPayinRBA.Text = db.GetLangString("EODDetailsForm.LocalCredPayinLbl");
            lbPayinRBA.Text = db.GetLangString("EODDetailsForm.PayinTotalLbl");
            lbPayoutRBA.Text = db.GetLangString("EODDetailsForm.PayoutTotalLbl");
            lbNumWashSold.Text = db.GetLangString("EODDetailsForm.lbNumWashSold");
            lbSalesMaxDate.Text = db.GetLangString("EODDetailsForm.lbSalesMaxDate");
            lbApprovedByRBA.Text = db.GetLangString("EODDetailsForm.ApprovedByLbl");
            tabDailyRBA.Text = db.GetLangString("EODDetailsForm.TabDailyRBA");

            btnSaveClose.Text = db.GetLangString("Application.Close");
            btnApprove.Text = db.GetLangString("EODDetailsForm.ApproveLbl");
            btnReImport.Text = db.GetLangString("EODDetailsForm.btnReImport");

            tabBankOgShellSafePay.Text = db.GetLangString("EODDetailsForm.BankShellTabLbl");
            lbDepotAmount.Text = db.GetLangString("EODDetailsForm.lbDepotAmount");
            lbDepotTilgangValuta.Text = db.GetLangString("EODDetailsForm.lbDepotTilgangValuta");
                                                      
            
            lbTotalDepot.Text = db.GetLangString("EODDetailsForm.lbTotalDepot");
            //lOptprepayreserveterminal.Text = db.GetLangString("EODDetailsForm.lOptprepayreserveterminal");                      
            //lOptprepayreserveterminalSP.Text = lOptprepayreserveterminal.Text;
            lbShellCardAmountSP.Text = lbShellCardAmount.Text;
            //lbDiscountAmountSP.Text = lbDiscountAmount.Text;
            lbMiscCardAmountSP.Text = lbMiscCardAmount.Text;
            lbTotalShellSP.Text = lbTotalShell.Text;
            lblManualDepBank.Text = db.GetLangString("EODDetailsForm.lblManualDepBank");
            lbWoltAmount.Text = "Wolt";
            lbManCardAmount.Text = db.GetLangString("EODDetailsForm.lbManCardAmountSP");
            lbDiscountAmount.Visible = false;
            txtDiscountAmount.Visible = false;
            txtDiscountAmountCount.Visible = false;
            btnDiscountAmount.Visible = false;
           // lOptprepayreserveterminal.Visible = false;
          //  txtOPTprepayreserveterminal.Visible = false;


            tabControl1.TabPages.Remove(tabDailyRBA);
            if (!db.GetConfigStringAsBool("SafePay.Enabled"))
            {
                // SafePay is not enabled
                tabControl1.TabPages.Remove(tabSafePay);
                tabControl1.TabPages.Remove(tabBankOgShellSafePay);
            }
            else // SafePay is enabled
            {
                /// it is assumed that since this form is opened,
                /// the day is open and thus we want to update exchange
                /// rate calculated danish amounts in EOD_SafePay_Depotbetholding table.
                tabControl1.TabPages.Remove(tabBankOgShell);
                EODDataSet.EOD_SafePay_DepotbeholdningDataTable.UpdateDKKAmountOnCurrentOpenDay();

                
#if RBA
                // disable some of the other fields
                btnForeignCurrencyRBA.Enabled = false;
                btnPayinRBA.Enabled = false;
                btnPayoutRBA.Enabled = false;
                btnLocalCreditPayinRBA.Enabled = false;
#else
                // disable some of the other fields
                //txtForrCurrency.ReadOnly = true;
                txtForrCurrency.Visible = false;
                //btnPayin.Enabled = false;
                lbPayinTotal.Visible = false;
                btnPayin.Visible = false;
                //btnPayout.Enabled = false;
                txtPayinTotal.Visible = false;
                lbPayout.Visible = false;
                btnPayout.Visible = false;
                txtPayout.Visible = false;
                btnLocalCreditPayin.Enabled = false;
                lbForrCurrency.Visible = false;
                txtPayinCount.Visible = false;
                txtPayoutCount.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                lbDiscountAmount.Visible = false;
                txtDiscountAmount.Visible = false;
                txtDiscountAmountCount.Visible = false;
                btnDiscountAmount.Visible = false;
                //lOptprepayreserveterminal.Visible = false;
                //txtOPTprepayreserveterminal.Visible = false;
#endif
            }
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // BankDepAmount button click event
        private void btnBankDepAmount_Click(object sender, EventArgs e)
        {
            if (bindingReconcileSingle.Current == null) return;
            DataRowView row = (DataRowView)bindingReconcileSingle.Current;

            EOD_BankDep bankdep = new EOD_BankDep(BookDate);
            if (bankdep.ShowDialog() == DialogResult.OK)
            {
                row["BankDepAmount"] =  EODDataSet.EOD_BankDepDataTable.GetTotalBankDepAmount(BookDate);
                bindingReconcileSingle.EndEdit();
            }

            dsEOD.EODReconcileSingle.CalcTotalsInMemory(BookDate);
        }

        // txtBankDepAmount text changed event - update row count
        private void txtBankDepAmount_TextChanged(object sender, EventArgs e)
        {
            txtBankDepAmountCount.Text =
                EODDataSet.EOD_BankDepDataTable.GetBankDepRowCount(BookDate).ToString();
            //DS.EODDS.EODDS1.DataSet1.EOD_BankDepDataTable.GetBankDepRowCount(BookDate).ToString();
            

        }

        private void btnBankCardsAmount_Click(object sender, EventArgs e)
        {
            EOD_SafePayCurr bankcards = new EOD_SafePayCurr(BookDate);
            bankcards.ShowDialog();
        }

        private void btnShellCardsAmount_Click(object sender, EventArgs e)
        {
            EOD_ShellCards shellcards = new EOD_ShellCards(BookDate);
            shellcards.ShowDialog();
        }

        private void txtShellCardAmount_TextChanged(object sender, EventArgs e)
        {
            txtShellCardAmountCount.Text =                
                EODDataSet.EOD_ShellCardsDataTable.GetShellCardsRowCount(BookDate).ToString();
                //Peter
        }

        private void btnLocalCredit_Click(object sender, EventArgs e)
        {
            if (bindingReconcileSingle.Current == null) return;
            DataRowView row = (DataRowView)bindingReconcileSingle.Current;

            EOD_LocalCredit localcred = new EOD_LocalCredit(BookDate, TransTypeLocalCred.LocalCredit);
            if (localcred.ShowDialog() == DialogResult.OK)
            {
                row["LocalCredit"] = EODDataSet.EOD_LocalCredDataTable.GetTotalLocalCreditAmount(BookDate, TransTypeLocalCred.LocalCredit);
                bindingReconcileSingle.EndEdit();
            }

            dsEOD.EODReconcileSingle.CalcTotalsInMemory(BookDate);
        }

        private void txtLocalCredit_TextChanged(object sender, EventArgs e)
        {
            txtLocalCreditCount.Text =
                EODDataSet.EOD_LocalCredDataTable.GetLocalCredRowCount(BookDate).ToString();
        }

        private void btnLocalCreditPayin_Click(object sender, EventArgs e)
        {
            if (bindingReconcileSingle.Current == null) return;
            DataRowView row = (DataRowView)bindingReconcileSingle.Current;

            EOD_LocalCredit localcredpay = new EOD_LocalCredit(BookDate, TransTypeLocalCred.LocalCreditPayin);
            if (localcredpay.ShowDialog() == DialogResult.OK)
            {
                row["LocalCreditPayin"] = 
                    EODDataSet.EOD_LocalCredDataTable.GetTotalLocalCreditAmount(BookDate, TransTypeLocalCred.LocalCreditPayin);
                bindingReconcileSingle.EndEdit();
            }

            dsEOD.EODReconcileSingle.CalcTotalsInMemory(BookDate);
        }

        private void txtLocalCreditPayin_TextChanged(object sender, EventArgs e)
        {
            txtLocalCreditPayinCount.Text =
                  EODDataSet.EOD_LocalCredDataTable.GetLocalCredPayinRowCount(BookDate).ToString();
        }

        private void btnPayin_Click(object sender, EventArgs e)
        {
            TransTypePayinPayout TransType = TransTypePayinPayout.Payin;


            if (bindingReconcileSingle.Current == null) return;
            DataRowView row = (DataRowView)bindingReconcileSingle.Current;

            EOD_Payin payin = new EOD_Payin(BookDate);
            if (payin.ShowDialog() == DialogResult.OK)
            {
                row["PayIn"] = EODDataSet.EOD_PayinPayoutDataTable.GetTotalPayinPayoutAmount(BookDate, TransType);
                bindingReconcileSingle.EndEdit();
            }

            dsEOD.EODReconcileSingle.CalcTotalsInMemory(BookDate);
        }

        private void txtPayinTotal_TextChanged(object sender, EventArgs e)
        {
            txtPayinCount.Text =
                 EODDataSet.EOD_PayinPayoutDataTable.GetPayinRowCount(BookDate).ToString();
        }

        private void btnPayout_Click(object sender, EventArgs e)
        {
            TransTypePayinPayout TransType = TransTypePayinPayout.Payout;
            
            if (bindingReconcileSingle.Current == null) return;
            DataRowView row = (DataRowView)bindingReconcileSingle.Current;

            EOD_Payout payout = new EOD_Payout(BookDate);
            if (payout.ShowDialog() == DialogResult.OK)
            {
                row["PayOut"] = EODDataSet.EOD_PayinPayoutDataTable.GetTotalPayinPayoutAmount(BookDate, TransType);
                bindingReconcileSingle.EndEdit();
            }

            dsEOD.EODReconcileSingle.CalcTotalsInMemory(BookDate);
        }

        private void txtPayout_TextChanged(object sender, EventArgs e)
        {
            txtPayoutCount.Text =
                 EODDataSet.EOD_PayinPayoutDataTable.GetPayoutRowCount(BookDate).ToString();
        }

        private void btnPOSSales_Click(object sender, EventArgs e)
        {
            EOD_POSSales possales = new EOD_POSSales(BookDate);
            possales.ShowDialog();
        }

        private void txtPOSSales_TextChanged(object sender, EventArgs e)
        {
            txtPOSSalesCount.Text =
                 EODDataSet.EOD_SalesDataTable.GetPOSSalesRowCount(BookDate).ToString();
        }

        private void btnManualSales_Click(object sender, EventArgs e)
        {
            TransTypeSales TransType = TransTypeSales.ManualSales;

            if (bindingReconcileSingle.Current == null) return;
            DataRowView row = (DataRowView)bindingReconcileSingle.Current;

            EOD_ManSales mansales = new EOD_ManSales(BookDate);
            if (mansales.ShowDialog() == DialogResult.OK)
            {
                row["ManualSales"] = EODDataSet.EOD_SalesDataTable.GetTotalSalesAmount(BookDate, TransType);
                bindingReconcileSingle.EndEdit();
            }

            dsEOD.EODReconcileSingle.CalcTotalsInMemory(BookDate);
        }

        private void txtManualSales_TextChanged(object sender, EventArgs e)
        {
            txtManualSalesCount.Text =
                 EODDataSet.EOD_SalesDataTable.GetManSalesRowCount(BookDate).ToString();
        }

        private void txtMiscCardAmount_Leave(object sender, EventArgs e)
        {
            bindingReconcileSingle.EndEdit();
            dsEOD.EODReconcileSingle.CalcTotalsInMemory(BookDate);
        }

        private void txtManCardAmount_Leave(object sender, EventArgs e)
        {
            bindingReconcileSingle.EndEdit();
            dsEOD.EODReconcileSingle.CalcTotalsInMemory(BookDate);
        }

        private void txtCashDiscountAmount_Leave(object sender, EventArgs e)
        {
            bindingReconcileSingle.EndEdit();
            dsEOD.EODReconcileSingle.CalcTotalsInMemory(BookDate);
        }

        private void txtForrCurrency_Leave(object sender, EventArgs e)
        {
            bindingReconcileSingle.EndEdit();
            dsEOD.EODReconcileSingle.CalcTotalsInMemory(BookDate);
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            Approve();
        }

        private void btnReImport_Click(object sender, EventArgs e)
        {
            ReImport();
        }

        private void EODDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
        }

        private void txtBankDepAmountRBA_TextChanged(object sender, EventArgs e)
        {
            txtBankDepAmountCountRBA.Text =
              EODDataSet.EOD_BankDepDataTable.GetBankDepRowCount(BookDate).ToString();
           

        }

        private void txtLocalCreditRBA_TextChanged(object sender, EventArgs e)
        {
            txtLocalCreditCountRBA.Text =
                EODDataSet.EOD_LocalCredDataTable.GetLocalCredRowCount(BookDate).ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            txtLocalCreditPayinCountRBA.Text =
                  EODDataSet.EOD_LocalCredDataTable.GetLocalCredPayinRowCount(BookDate).ToString();
        }

        private void txtPayinRBA_TextChanged(object sender, EventArgs e)
        {
            txtPayinCountRBA.Text =
                EODDataSet.EOD_PayinPayoutDataTable.GetPayinRowCount(BookDate).ToString();
        }

        private void txtPayoutRBA_TextChanged(object sender, EventArgs e)
        {
            txtPayoutCountRBA.Text =
                 EODDataSet.EOD_PayinPayoutDataTable.GetPayoutRowCount(BookDate).ToString();
        }

        // ManualCards button click event
        private void btnManualCardsRBA_Click(object sender, EventArgs e)
        {
            if (bindingReconcileSingle.Current == null) return;
            DataRowView row = (DataRowView)bindingReconcileSingle.Current;

            EOD_ManualCards ManualCards = new EOD_ManualCards(BookDate);
            if (ManualCards.ShowDialog() == DialogResult.OK)
            {
                row["ManDankortSumB"] = EODDataSet.EOD_ManualCardsDataTable.GetTotalManualCardsAmount(BookDate);
                bindingReconcileSingle.EndEdit();
            }

            dsEOD.EODReconcileSingle.CalcTotalsInMemory(BookDate);
        }

        // ForeignCurrency button click event
        private void btnForeignCurrencyRBA_Click(object sender, EventArgs e)
        {
            if (bindingReconcileSingle.Current == null) return;
            DataRowView row = (DataRowView)bindingReconcileSingle.Current;

            EOD_ForeignCurrency ForeignCurrency = new EOD_ForeignCurrency(BookDate);
            if (ForeignCurrency.ShowDialog() == DialogResult.OK)
            {
                row["ForeignCurrency"] = EODDataSet.EOD_ForeignCurrencyDataTable.GetTotalForeignCurrencyAmount(BookDate);
                bindingReconcileSingle.EndEdit();
            }

            dsEOD.EODReconcileSingle.CalcTotalsInMemory(BookDate);
        }

        private void txManualCardsRBA_TextChanged(object sender, EventArgs e)
        {
            txtManualCardsCountRBA.Text =
                EODDataSet.EOD_ManualCardsDataTable.GetManualCardsRowCount(BookDate).ToString();
        }

        private void txtForeignCurrencyRBA_TextChanged(object sender, EventArgs e)
        {
            txtForeignCurrencyCountRBA.Text =
                EODDataSet.EOD_ForeignCurrencyDataTable.GetForeignCurrencyRowCount(BookDate).ToString();
        }

        private void txtReserveTerminalRBA_TextChanged(object sender, EventArgs e)
        {
            txtReserveTerminalRBACount.Text =
                EODDataSet.EOD_ReserveTerminalDataTable.GetRowCount(BookDate).ToString();
        }

        private void btnReserveTerminalRBA_Click(object sender, EventArgs e)
        {
            if (bindingReconcileSingle.Current == null) return;
            DataRowView row = (DataRowView)bindingReconcileSingle.Current;

            EOD_ReserveTerminal ReserveTerminal = new EOD_ReserveTerminal(BookDate);
            if (ReserveTerminal.ShowDialog() == DialogResult.OK)
            {
                row["ReserveTerminal"] = EODDataSet.EOD_ReserveTerminalDataTable.GetTotalAmount(BookDate);
                bindingReconcileSingle.EndEdit();
            }
        }

        private void btnEODSafePayIndbetalinger_Click(object sender, EventArgs e)
        {
            EOD_SafePay_Indbetalinger form = new EOD_SafePay_Indbetalinger(BookDate);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                if (bindingReconcileSingle.Current == null) return;
                DataRowView row = (DataRowView)bindingReconcileSingle.Current;
                row["SafePay_Indbetalinger"] = EODDataSet.EOD_SafePay_IndbetalingerDataTable.GetTotalAmount(BookDate);
                bindingReconcileSingle.EndEdit();
                txtSafePayIndbetalingerCount.Text = EODDataSet.EOD_SafePay_IndbetalingerDataTable.GetRowCount(BookDate).ToString();
            }
        }

        private void btnTransferExchangeToSafePay_Click(object sender, EventArgs e)
        {
            EOD_SafePay_OverfoerselTilSP form = new EOD_SafePay_OverfoerselTilSP(BookDate);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                if (bindingReconcileSingle.Current == null) return;
                DataRowView row = (DataRowView)bindingReconcileSingle.Current;
                row["SafePay_OverfoerselTilSP"] = EODDataSet.EOD_SafePay_OverfoerselTilSPDataTable.GetTotalAmount(BookDate);
                bindingReconcileSingle.EndEdit();
                txtSafePayOverfoerselTilSPCount.Text = EODDataSet.EOD_SafePay_OverfoerselTilSPDataTable.GetRowCount(BookDate).ToString();
            }
        }

        private void btnSafePayPayouts_Click(object sender, EventArgs e)
        {
            EOD_SafePay_Udbetalinger form = new EOD_SafePay_Udbetalinger(BookDate);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                if (bindingReconcileSingle.Current == null) return;
                DataRowView row = (DataRowView)bindingReconcileSingle.Current;
                row["SafePay_Udbetalinger"] = EODDataSet.EOD_SafePay_UdbetalingerDataTable.GetTotalAmount(BookDate);
                bindingReconcileSingle.EndEdit();
                txtSafePayUdbetalingerCount.Text = EODDataSet.EOD_SafePay_UdbetalingerDataTable.GetRowCount(BookDate).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EOD_SafePay_Depotbeholdning form = new EOD_SafePay_Depotbeholdning(BookDate);
            form.ShowDialog(this);
        }

        private void tabSafePay_Enter(object sender, EventArgs e)
        {
            txtSafePay_ValutaISO_EURO.Text = EODDataSet.EOD_SafePay_ValutakurserDataTable.GetValutakurs(EODDataSet.EOD_SafePay_ValutakurserDataTable.ISOKode.EURO).ToString("n2");
            txtSafePay_ValutaISO_NOK.Text = EODDataSet.EOD_SafePay_ValutakurserDataTable.GetValutakurs(EODDataSet.EOD_SafePay_ValutakurserDataTable.ISOKode.NOK).ToString("n2");
            txtSafePay_ValutaISO_SEK.Text = EODDataSet.EOD_SafePay_ValutakurserDataTable.GetValutakurs(EODDataSet.EOD_SafePay_ValutakurserDataTable.ISOKode.SEK).ToString("n2");
        }

        private void txtSafePayOverfoerselTilSP_TextChanged(object sender, EventArgs e)
        {
            txtSafePayOverfoerselTilSPCount.Text = EODDataSet.EOD_SafePay_OverfoerselTilSPDataTable.GetRowCount(BookDate).ToString();
        }

        private void txtSafePayUdbetalinger_TextChanged(object sender, EventArgs e)
        {
            txtSafePayUdbetalingerCount.Text = EODDataSet.EOD_SafePay_UdbetalingerDataTable.GetRowCount(BookDate).ToString();
        }

        private void txtSafePayIndbetalinger_TextChanged(object sender, EventArgs e)
        {
            txtSafePayIndbetalingerCount.Text = EODDataSet.EOD_SafePay_IndbetalingerDataTable.GetRowCount(BookDate).ToString();
        }

        private void txtSafePayDepotbeholding_TextChanged(object sender, EventArgs e)
        {
            txtSafePayDepotbeholdingCount.Text = EODDataSet.EOD_SafePay_DepotbeholdningDataTable.GetRowCount(BookDate).ToString();
        }

        private void btnDiscountAmount_Click(object sender, EventArgs e)
        {
            EOD_Discounts discounts = new EOD_Discounts(BookDate);
            discounts.ShowDialog();
        }

        private void txtDiscountAmount_TextChanged(object sender, EventArgs e)
        {
           txtDiscountAmountCount.Text = EODDataSet.EOD_DiscountsDataTable.GetDiscountsRowCount(BookDate).ToString();
            
        }



       

        private void txtMiscCardAmountSP_Leave(object sender, EventArgs e)
        {
            bindingReconcileSingle.EndEdit();
            dsEOD.EODReconcileSingle.CalcTotalsInMemory(BookDate);
        }

        private void txtManCardAmountSP_Leave(object sender, EventArgs e)
        {            
            bindingReconcileSingle.EndEdit();
            dsEOD.EODReconcileSingle.CalcTotalsInMemory(BookDate);
        }

        private void bindingReconcileSingle_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void txtBankDepAmountSP_Leave(object sender, EventArgs e)
        {
            //>>PN20200803
            //DataRowView row = (DataRowView)bindingReconcileSingle.Current;
            //txtTotalDepot.Text = EODDataSet.EOD_SafePay_UdbetalingerDataTable.GetTotalAmount(BookDate).ToString();
            //<<PN20200803
            //bindingReconcileSingle.EndEdit();
            //dsEOD.EODReconcileSingle.CalcTotalsInMemory(BookDate);
            
        }

        private void txtShellCardAmountCountSP_TextChanged(object sender, EventArgs e)
        {
            txtShellCardAmountCountSP.Text =
                EODDataSet.EOD_ShellCardsDataTable.GetShellCardsRowCount(BookDate).ToString();
        }

        private void btnShellCardsAmountSP_Click(object sender, EventArgs e)
        {
            EOD_ShellCards shellcards = new EOD_ShellCards(BookDate);
            shellcards.ShowDialog();
        }

        private void btnDiscountAmountSP_Click(object sender, EventArgs e)
        {
            EOD_Discounts discounts = new EOD_Discounts(BookDate);
            discounts.ShowDialog();
        }

        private void txtShellCardAmountSP_TextChanged(object sender, EventArgs e)
        {
            txtShellCardAmountCountSP.Text =
                EODDataSet.EOD_ShellCardsDataTable.GetShellCardsRowCount(BookDate).ToString();
        }

       

        private void txtManCardAmount_Leave_1(object sender, EventArgs e)
        {
        
            bindingReconcileSingle.EndEdit();
            dsEOD.EODReconcileSingle.CalcTotalsInMemory(BookDate);
        
        }

        //private void txtDiscountAmountSP_TextChanged(object sender, EventArgs e)
        //{
        //    txtDiscountAmountCountSP.Text = EODDataSet.EOD_DiscountsDataTable.GetDiscountsRowCount(BookDate).ToString();
        //}

        

        

        

       
    }
}