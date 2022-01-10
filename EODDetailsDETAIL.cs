using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class EODDetailsDETAIL : Form
    {
        private DateTime BookDate;
        private bool ValutaPopupEnabled;

        public EODDetailsDETAIL(DateTime BookDate)
        {
            InitializeComponent();
            this.BookDate = BookDate;

            // set valuta popup controls
            ValutaPopupEnabled = db.GetConfigStringAsBool("ValutaPopup_DETAIL.Enabled");
            txtValutaiDKKCount.Visible = ValutaPopupEnabled;
            btnValutaiDKK.Visible = ValutaPopupEnabled;
            txtValutaiDKK.ReadOnly = ValutaPopupEnabled;
        }

        private void LoadData()
        {
            adapterReconcileSingle.Connection = db.Connection;
            adapterReconcileSingle.Fill(dsEOD.EODReconcileSingle, BookDate);
            txtAntalKunder.Text = EODDataSet.EODReconcileExDataTable.GetCustomerCount(BookDate).ToString();
            //4 dynamiske felter
            lblTmpAmt1.Visible = false;
            txtTmpAmt1.Visible = false;
            if (db.GetConfigString("TMPAmt1Ledetekst") !="")
            {                
                lblTmpAmt1.Visible = true;
                lblTmpAmt1.Text = db.GetConfigString("TMPAmt1Ledetekst");
                txtTmpAmt1.Visible = true;
            }
            lblTmpAmt2.Visible = false;
            txtTmpAmt2.Visible = false;
            if (db.GetConfigString("TMPAmt2Ledetekst") != "")
            {
                lblTmpAmt2.Visible = true;
                lblTmpAmt2.Text = db.GetConfigString("TMPAmt2Ledetekst");
                txtTmpAmt2.Visible = true;
            }
            lblTmpAmt3.Visible = false;
            txtTmpAmt3.Visible = false;
            if (db.GetConfigString("TMPAmt3Ledetekst") != "")
            {
                lblTmpAmt3.Visible = true;
                lblTmpAmt3.Text = db.GetConfigString("TMPAmt3Ledetekst");
                txtTmpAmt3.Visible = true;
            }
            lblTmpAmt4.Visible = false;
            txtTmpAmt4.Visible = false;
            if (db.GetConfigString("TMPAmt4Ledetekst") != "")
            {
                lblTmpAmt4.Visible = true;
                lblTmpAmt4.Text = db.GetConfigString("TMPAmt4Ledetekst");
                txtTmpAmt4.Visible = true;
            }
        }

        private void SaveData()
        {
            bindingReconcileSingle.EndEdit();
            adapterReconcileSingle.Update(dsEOD.EODReconcileSingle);
            EODDataSet.EODReconcileExDataTable.InsertOrUpdateRecord(BookDate, tools.object2int(txtAntalKunder.Text));
        }

        private void Approve()
        {
            string msg = "";

            if (bindingReconcileSingle.Current == null) return;
            DataRowView row = (DataRowView)bindingReconcileSingle.Current;
            bindingReconcileSingle.EndEdit();

            // validate some data
            if (tools.object2string(row["ApprovedBy"]) == "")
            {
                MessageBox.Show(db.GetLangString("EODDetailsDETAIL.ApprovedByCannotBeEmpty"), "", MessageBoxButtons.OK);
                return;
            }

            if (tools.object2double(row["POSSales"]) == 0)
            {
                msg = db.GetLangString("EODDetailsDETAIL.RSMSalesIs0");
                if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
            }
            
            if (tools.object2double(row["TotalBank"]) == 0)
            {
                msg = db.GetLangString("EODDetailsDETAIL.BankDepositIs0");
                if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
            }

            // final DO approve prompt
            double CashOverUnder = tools.object2double(row["CashOverUnder"]);
            msg = string.Format(db.GetLangString("EODDetailsDETAIL.WantToApproveEOD"), CashOverUnder.ToString("N2"));
            if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            //Dynamiske felter
            if (db.GetConfigString("TMPAmt1Ledetekst") != "")            
                row["TMPAmt1Descr"] = db.GetConfigString("TMPAmt1Ledetekst");                            
            if (db.GetConfigString("TMPAmt2Ledetekst") != "")            
                row["TMPAmt2Descr"] = db.GetConfigString("TMPAmt2Ledetekst");            
            if (db.GetConfigString("TMPAmt3Ledetekst") != "")            
                row["TMPAmt3Descr"] = db.GetConfigString("TMPAmt3Ledetekst");            
            if (db.GetConfigString("TMPAmt4Ledetekst") != "")            
                row["TMPAmt4Descr"] = db.GetConfigString("TMPAmt4Ledetekst");
            row["TMPAmtTotal"] = tools.object2double(row["TMPAmt1"]) +
                                 tools.object2double(row["TMPAmt2"]) +
                                 tools.object2double(row["TMPAmt3"]) +
                                 tools.object2double(row["TMPAmt4"]);
            
            // close (approve) the EOD
            row["Closed"] = true;
            bindingReconcileSingle.EndEdit();
            adapterReconcileSingle.Update(dsEOD.EODReconcileSingle);

            // generate EOD file if applicable
#if DETAIL // have to ask otherwise RBA won't build
            ExportAccounting.GenerateEODFile(tools.object2datetime(row["BookDate"]));
#endif

            // close window
            Close();
        }

        private void ReImport()
        {
            string msg = db.GetLangString("EODDetailsDETAIL.ReimportPOSData");
            if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // re-import POS data
                SaveData();
                if (ImportConcernoPOS.ReImportFile(BookDate))
                    LoadData();
                else
                    MessageBox.Show(ImportConcernoPOS.LastError);
            }
        }

        private void EODDetailsDETAIL_Load(object sender, EventArgs e)
        {
            LoadData();

            // localization
            this.Text = db.GetLangString("EODDetailsDETAIL.Title");
            tabBankOgShell.Text = db.GetLangString("EODDetailsDETAIL.tabBankOgShell");
            tabDivOgSalg.Text = db.GetLangString("EODDetailsDETAIL.tabDivOgSalg");
            tabOpgoerelse.Text = db.GetLangString("EODDetailsDETAIL.tabOpgoerelse");
            lbIaltIndsatBank.Text = db.GetLangString("EODDetailsDETAIL.lbIaltIndsatBank");
            lbBankkort.Text = db.GetLangString("EODDetailsDETAIL.lbBankkort");
            lbIaltBank.Text = db.GetLangString("EODDetailsDETAIL.lbIaltBank");
            lbLokalkredit.Text = db.GetLangString("EODDetailsDETAIL.lbLokalkredit");
            lbLokalkreditIndbetalt.Text = db.GetLangString("EODDetailsDETAIL.lbLokalkreditIndbetalt");
            lbValutaiDKK.Text = db.GetLangString("EODDetailsDETAIL.lbValutaiDKK");
            lbIaltDiverse.Text = db.GetLangString("EODDetailsDETAIL.lbIaltDiverse");
            lbVaresalgPOStotal.Text = db.GetLangString("EODDetailsDETAIL.lbVaresalgPOStotal");
            lbVaresalgIOevrigt.Text = db.GetLangString("EODDetailsDETAIL.lbVaresalgIOevrigt");
            lbTotalVaresalg.Text = db.GetLangString("EODDetailsDETAIL.lbTotalVaresalg");
            lbTotalAB.Text = db.GetLangString("EODDetailsDETAIL.lbTotalAB");
            lbTotalVaresalgC.Text = db.GetLangString("EODDetailsDETAIL.lbTotalVaresalgC");
            lbIndbetalinger.Text = db.GetLangString("EODDetailsDETAIL.lbIndbetalinger");
            lbUdbetalinger.Text = db.GetLangString("EODDetailsDETAIL.lbUdbetalinger");
            lbKassedifference.Text = db.GetLangString("EODDetailsDETAIL.lbKassedifference");
            lbGodkendtAf.Text = db.GetLangString("EODDetailsDETAIL.lbGodkendtAf");
            lbBookDate.Text = db.GetLangString("EODDetailsDETAIL.lbBookDate");
            lbAntalKunder.Text = db.GetLangString("EODDetailsDETAIL.lbAntalKunder");
            btnSaveClose.Text = db.GetLangString("Application.Close");
            btnApprove.Text = db.GetLangString("EODDetailsDETAIL.btnApprove");
            btnReImport.Text = db.GetLangString("EODDetailsDETAIL.btnReImport");
            lbMoentBank.Text = db.GetLangString("EODDetailsDETAIL.lbMoentBank");
            lbMoentDaglig.Text = db.GetLangString("EODDetailsDETAIL.lbMoentDaglig");
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
            txtIaltIndsatBankCount.Text =
                EODDataSet.EOD_BankDepDataTable.GetBankDepRowCount(BookDate).ToString();
        }

        private void btnBankCardsAmount_Click(object sender, EventArgs e)
        {

            if (bindingReconcileSingle.Current == null) return;
            DataRowView row = (DataRowView)bindingReconcileSingle.Current;
            EOD_BankCards bankcards = new EOD_BankCards(BookDate);
            //bankcards.ShowDialog();
            //dsEOD.EODReconcileSingle.CalcTotalsInMemory(BookDate);//peter
            if (bankcards.ShowDialog() == DialogResult.OK)
            {                
                row["BankCardAmount"] = EODDataSet.EOD_BankCardsDataTable.GetTotalBankCardsAmount(BookDate);
                bindingReconcileSingle.EndEdit();
            }

            dsEOD.EODReconcileSingle.CalcTotalsInMemory(BookDate);
        }

        private void txtBankCardAmount_TextChanged(object sender, EventArgs e)
        {
            txtBankkortCount.Text =
                EODDataSet.EOD_BankCardsDataTable.GetBankCardsRowCount(BookDate).ToString();
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
            txtLokalkreditCount.Text =
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
            txtLokalkreditIndbetaltCount.Text =
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
            txtIndbetalingerCount.Text =
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
            txtUdbetalingerCount.Text =
                 EODDataSet.EOD_PayinPayoutDataTable.GetPayoutRowCount(BookDate).ToString();
        }

        private void btnPOSSales_Click(object sender, EventArgs e)
        {
            EOD_POSSales possales = new EOD_POSSales(BookDate);
            possales.ShowDialog();
        }

        private void txtPOSSales_TextChanged(object sender, EventArgs e)
        {
            txtVaresalgPOStotalCount.Text =
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
            txtVaresalgIOevrigtCount.Text =
                 EODDataSet.EOD_SalesDataTable.GetManSalesRowCount(BookDate).ToString();
        }
    
        private void txtForrCurrency_Leave(object sender, EventArgs e)
        {
            if (!ValutaPopupEnabled)
            {
                bindingReconcileSingle.EndEdit();
                dsEOD.EODReconcileSingle.CalcTotalsInMemory(BookDate);
            }
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

        private void btnValuta_DETAIL_Click(object sender, EventArgs e)
        {
            EOD_DETAIL_Valuta valuta = new EOD_DETAIL_Valuta(BookDate);
            valuta.ShowDialog(this);
        }

        private void txtValutaiDKK_TextChanged(object sender, EventArgs e)
        {
            if (ValutaPopupEnabled)
                txtValutaiDKKCount.Text = EODDataSet.EOD_DETAIL_ValutaDataTable.GetRowCount(BookDate).ToString();
        }

        private void tabDivOgSalg_Enter(object sender, EventArgs e)
        {
            // stuff to do when entering Diverse og Salg tab

            dsEOD.EODReconcileSingle.CalcTotalsInMemory(BookDate);
        }

        private void txtMoentDaglig_Leave(object sender, EventArgs e)
        {
            bindingReconcileSingle.EndEdit();
            dsEOD.EODReconcileSingle.CalcTotalsInMemory(BookDate);
        }
    }
}