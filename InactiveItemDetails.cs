using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class InactiveItemDetails : Form
    {
        private int _ItemID = 0;

        public InactiveItemDetails(int ItemID)
        {
            InitializeComponent();
            _ItemID = ItemID;
            LoadData();

            // position columns in salespack grid
            int index = 0;
            colIsPrimary.DisplayIndex = index++;
            colPackTypeName.DisplayIndex = index++;
            colSalesPrice.DisplayIndex = index++;
            colBarcode.DisplayIndex = index++;
            colReceiptText.DisplayIndex = index++;

            // position columns in barcode grid
            index = 0;
            colBarcodeName.DisplayIndex = index++;
            colBarcode_barcode.DisplayIndex = index++;
            colIsPrimary_barcode.DisplayIndex = index++;

            // position columns in supplieritem grid
            index = 0;
            colSupplierNo.DisplayIndex = index++;
            colSupplierName.DisplayIndex = index++;
            colOrderingNumber.DisplayIndex = index++;
            colIsPrimary_supplieritem.DisplayIndex = index++;
            colKolliSize.DisplayIndex = index++;
            colPackageCost.DisplayIndex = index++;
            colPackageUnitCost.DisplayIndex = index++;
            colSellingPackType.DisplayIndex = index++;
            colNoOfSellingUnits.DisplayIndex = index++;
            colSellingUnitCost.DisplayIndex = index++;

            // localization
            this.Text = db.GetLangString("InactiveItemDetails.Title");
            btnClose.Text = db.GetLangString("Application.Close");
            txtItemName.Text = db.GetLangString("InactiveItemDetails.txtItemName");
            txtSubCategory.Text = db.GetLangString("InactiveItemDetails.txtSubCategory");
            txtSalesPrice.Text = db.GetLangString("InactiveItemDetails.txtSalesPrice");
            txtLatestCostPrice.Text = db.GetLangString("InactiveItemDetails.txtLatestCostPrice");
            txtMargin.Text = db.GetLangString("InactiveItemDetails.txtMargin");
            txtBugetMargin.Text = db.GetLangString("InactiveItemDetails.txtBudgetMargin");
            txtVatRate.Text = db.GetLangString("InactiveItemDetails.txtVatRate");
            txtInactivateDateTime.Text = db.GetLangString("InactiveItemDetails.txtInactivateDateTime");
            // salespack grid
            colIsPrimary.HeaderText = db.GetLangString("InactiveItemDetails.colIsPrimary");
            colPackTypeName.HeaderText = db.GetLangString("InactiveItemDetails.colPackTypeName");
            colSalesPrice.HeaderText = db.GetLangString("InactiveItemDetails.colSalesPrice");
            colBarcode.HeaderText = db.GetLangString("InactiveItemDetails.colBarcode");
            colReceiptText.HeaderText = db.GetLangString("InactiveItemDetails.colReceiptText");
            // barcode grid
            colBarcodeName.HeaderText = db.GetLangString("InactiveItemDetails.colBarcodeName");
            colBarcode_barcode.HeaderText = db.GetLangString("InactiveItemDetails.colBarcode_barcode");
            colIsPrimary_barcode.HeaderText = db.GetLangString("InactiveItemDetails.colIsPrimary_barcode");
            // supplieritem grid
            colSupplierNo.HeaderText = db.GetLangString("InactiveItemDetails.colSupplierNo");
            colSupplierName.HeaderText = db.GetLangString("InactiveItemDetails.colSupplierName");
            colOrderingNumber.HeaderText = db.GetLangString("InactiveItemDetails.colOrderingNumber");
            colIsPrimary_supplieritem.HeaderText = db.GetLangString("InactiveItemDetails.colIsPrimary_sup");
            colKolliSize.HeaderText = db.GetLangString("InactiveItemDetails.colKolliSize");
            colPackageCost.HeaderText = db.GetLangString("InactiveItemDetails.colPackageCost");
            colPackageUnitCost.HeaderText = db.GetLangString("InactiveItemDetails.colPackageUnitCost");
            colSellingPackType.HeaderText = db.GetLangString("InactiveItemDetails.colSellingPackType");
            colNoOfSellingUnits.HeaderText = db.GetLangString("InactiveItemDetails.colNoOfSellingUnits");
            colSellingUnitCost.HeaderText = db.GetLangString("InactiveItemDetails.colSellingUnitCost");
            // groupboxes
            groupItem.Text = db.GetLangString("InactiveItemDetails.groupItem");
            groupSalesPack.Text = db.GetLangString("InactiveItemDetails.groupSalesPack");
            groupBarcode.Text = db.GetLangString("InactiveItemDetails.groupBarcode");
            groupSupplierItem.Text = db.GetLangString("InactiveItemDetails.groupSupplierItem");
        }

        private void LoadData()
        {
            adapterInactiveItemSingle.Connection = db.Connection;
            adapterInactiveItemSingle.FillSingle(dsItem.InactiveItemSingle, _ItemID);

            adapterInactiveSalesPack.Connection = db.Connection;
            adapterInactiveSalesPack.FillSingle(dsItem.InactiveSalesPack, _ItemID);

            adapterInactiveSupplierItem.Connection = db.Connection;
            adapterInactiveSupplierItem.FillSingle(dsItem.InactiveSupplierItem, _ItemID);
        }

        private void InactiveItemDetails_Load(object sender, EventArgs e)
        {
        }

        private void bindingInactiveSalesPack_PositionChanged(object sender, EventArgs e)
        {
            if (bindingInactiveSalesPack.Current == null) return;
            DataRowView row = (DataRowView)bindingInactiveSalesPack.Current;
            byte PackType = tools.object2byte(row["PackType"]);
            adapterInactiveBarcode.Connection = db.Connection;
            adapterInactiveBarcode.FillSingle(dsItem.InactiveBarcode, _ItemID, PackType);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}