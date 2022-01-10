using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class ItemUpdInfo : Form
    {
        #region Constructor
        public ItemUpdInfo(BindingSource Binder, int ID, int LineNo)
        {
            InitializeComponent();

            // make binder point to callers data
            bindingItemUpdLines.DataSource = Binder.DataSource;
            bindingItemUpdLines.DataMember = Binder.DataMember;

            // only work with current record
            bindingItemUpdLines.Filter = string.Format(" (ID = {0}) AND (LineNo = {1}) ", ID, LineNo);

            // fill virtual fields
            if (bindingItemUpdLines.Current != null)
            {
                DataRowView row = (DataRowView)bindingItemUpdLines.Current;
                ImportDataSet.ItemUpdLinesDataTable.FillVirtualFields(row.Row);
            }

            // calculate margins
            CalculateMargins();

            // set form state
            SetFormState();

            // localization
            btnOk.Text = db.GetLangString("Application.Ok");
            btnOpenSalesPriceForEdit.Text = db.GetLangString("ItemUpdInfo.btnOpenSalesPriceForEdit");
            chkSkipSalesPriceChange.Text = db.GetLangString("ItemUpdInfo.chkSkipSalesPriceChange");
            lbActions.Text = db.GetLangString("ItemUpdInfo.lbActions");
            lbAfter.Text = db.GetLangString("ItemUpdInfo.lbAfter");
            lbBarcode.Text = db.GetLangString("ItemUpdInfo.lbBarcode");
            lbBefore.Text = db.GetLangString("ItemUpdInfo.lbBefore");
            lbCostPrice.Text = db.GetLangString("ItemUpdInfo.lbCostPrice");
            lbItemName.Text = db.GetLangString("ItemUpdInfo.lbItemName");
            lbKolliCost.Text = db.GetLangString("ItemUpdInfo.lbKolliCost");
            lbKolli.Text = db.GetLangString("ItemUpdInfo.lbKolli");
            lbMargin.Text = db.GetLangString("ItemUpdInfo.lbMargin");
            lbOrderingNumber.Text = db.GetLangString("ItemUpdInfo.lbOrderingNumber");
            lbSalesPrice.Text = db.GetLangString("ItemUpdInfo.lbSalesPrice");
            lbSubCategory.Text = db.GetLangString("ItemUpdInfo.lbSubCategory");
            lbSupplier.Text = db.GetLangString("ItemUpdInfo.lbSupplier");
            lbKampagneID.Text = db.GetLangString("ItemUpdInfo.lbKampagneID");
            lbFutureSalesPriceDate.Text = db.GetLangString("ItemUpdInfo.lbFutureSalesPriceDate");
            lbPackType.Text = db.GetLangString("ItemUpdInfo.lbPackType");

#if FSD
            lbKampagneID.Visible = false;
            txtKampagneID.Visible = false;
#endif
        }
        #endregion

        #region SetFormState
        private void SetFormState()
        {
            if (bindingItemUpdLines.Current == null) return;
            DataRowView row = (DataRowView)bindingItemUpdLines.Current;

            // as this method can be called again
            // once the form has been loaded,
            // reset some controls
            
            //txtSalesPriceAfter.ReadOnly = false;
            chkSkipSalesPriceChange.Enabled = true;
            chkSkipSalesPriceChange.Checked = false;

            // Skip Sales Price checkbox is checked if
            // user has previously skipped sales price
            chkSkipSalesPriceChange.Checked = tools.object2bool(row["NoChSales"]);

            // textbox Sales Price After is readonly if
            // user has previously skipped sales price
            txtSalesPriceAfter.ReadOnly = chkSkipSalesPriceChange.Checked;

            // if sales price change is disabled,
            // user cannot touch certain controls
            if (ImportDataSet.ItemUpdLinesDataTable.SalesPriceChangeDisabled(row.Row))
            {
                txtSalesPriceAfter.ReadOnly = true;
                chkSkipSalesPriceChange.Enabled = false;
            }

            // if user can open sales price for edit,
            // enable button btnEnableSalesPriceForEdit
            //pn20190829
            //btnOpenSalesPriceForEdit.Enabled =
            //    ImportDataSet.ItemUpdLinesDataTable.SalesPriceCanBeOpenedForEdit(row.Row);
            btnOpenSalesPriceForEdit.Enabled = UserLogon.EditSalesPrice();
            
        }
        #endregion

        #region CalculateMargins
        private void CalculateMargins()
        {
            if (bindingItemUpdLines.Current == null) return;
            DataRowView row = (DataRowView)bindingItemUpdLines.Current;

            double SalesPriceBefore = tools.object2double(row["LogSales"]);
            double CostPriceBefore = tools.object2double(row["LogCost"]);
            double SalesPriceAfter = tools.object2double(row["SalesPrice"]);
            double CostPriceAfter = tools.object2double(row["CostPrice"]);

            txtMarginBefore.Text = tools.CalcMargin(SalesPriceBefore, CostPriceBefore).ToString("N2");
            txtMarginAfter.Text = tools.CalcMargin(SalesPriceAfter, CostPriceAfter).ToString("N2");
        }
        #endregion

        #region OpenSalesPriceForEdit
        private void OpenSalesPriceForEdit()
        {
            // set ActionNewSalesPrice to true 
            // and set form state again to reflect
            // now open controls

            if (bindingItemUpdLines.Current == null) return;
            
          

            DataRowView row = (DataRowView)bindingItemUpdLines.Current;
            row["ActionNewSalesPrice"] = true;
            bindingItemUpdLines.EndEdit();
            SetFormState();
            txtSalesPriceAfter.ReadOnly = false;
        }
        #endregion

        #region ToggleSkipSalesPrice
        private void ToggleSkipSalesPrice()
        {
            if (bindingItemUpdLines.Current == null) return;
            DataRowView row = (DataRowView)bindingItemUpdLines.Current;

            // toggle salesprice skip
            ImportDataSet.ItemUpdLinesDataTable.ToggleSalesPriceChange(row.Row, false);
            CalculateMargins();
            txtSalesPriceAfter.ReadOnly = chkSkipSalesPriceChange.Checked;

            // reload data for controls
            txtSalesPriceAfter.Refresh();
        }
        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkSkipSalesPrice_Click(object sender, EventArgs e)
        {
            ToggleSkipSalesPrice();
        }

        private void txtSalesPriceAfter_Validated(object sender, EventArgs e)
        {
            CalculateMargins();
        }

        private void btnEnableSalesPrice_Click(object sender, EventArgs e)
        {
            OpenSalesPriceForEdit();
        }

        private void ItemUpdInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            bindingItemUpdLines.EndEdit();
        }
    }
}