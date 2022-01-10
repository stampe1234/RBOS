using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class SalesPackFuturePricesPrompt : Form
    {
        public SalesPackFuturePricesPrompt()
        {
            InitializeComponent();
        }

        protected void LoadData()
        {
            // reorder columns in grid
            int idx = 0;
            colActivationDate.DisplayIndex = idx++;
            colDescription.DisplayIndex = idx++;
            colBarcode.DisplayIndex = idx++;
            colCurrentSalesPrice.DisplayIndex = idx++;
            colFutureSalesPrice.DisplayIndex = idx++;
            colPackType.DisplayIndex = idx++;
            colOrigin.DisplayIndex = idx++;
            colPerform.DisplayIndex = idx++;

            // localization
            colActivationDate.HeaderText = db.GetLangString("SalesPackFuturePricesPrompt.colActivationDate");
            colDescription.HeaderText = db.GetLangString("SalesPackFuturePricesPrompt.colDescription");
            colBarcode.HeaderText = db.GetLangString("SalesPackFuturePricesPrompt.colBarcode");
            colCurrentSalesPrice.HeaderText = db.GetLangString("SalesPackFuturePricesPrompt.colCurrentSalesPrice");
            colFutureSalesPrice.HeaderText = db.GetLangString("SalesPackFuturePricesPrompt.colFutureSalesPrice");
            colPackType.HeaderText = db.GetLangString("SalesPackFuturePricesPrompt.colPackType");
            colOrigin.HeaderText = db.GetLangString("SalesPackFuturePricesPrompt.colOrigin");
            colPerform.HeaderText = db.GetLangString("SalesPackFuturePricesPrompt.colPerform");
            btnCancel.Text = db.GetLangString("Application.Cancel");
            btnPerform.Text = db.GetLangString("SalesPackFuturePricesPrompt.btnPerform");
            lbDescription.Text = db.GetLangString("SalesPackFuturePricesPrompt.lbDescription");

            // first close future sales packs that are past due and not marked for perform,
            // and then load futue sales packs that are due and marked for perform
            adapterSalesPackFuturePricesPrompt.Connection = db.Connection;
            ItemDataSet.SalesPackFuturePricesPromptDataTable.CloseDueSalesPacksNotMarkedForPerform();
            adapterSalesPackFuturePricesPrompt.Fill(dsItem.SalesPackFuturePricesPrompt);
        }

        private void Perform()
        {
            grid.EndEdit();
            bindingSalesPackFuturePricesPrompt.EndEdit();
            dsItem.SalesPackFuturePricesPrompt.ApplyFutureSalesPacksMarkedForPerform();
            MessageBox.Show(db.GetLangString("SalesPackFuturePricesPrompt.PerformedMsg"));
            Close();
        }

        private void SalesPackFuturePricesPrompt_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPerform_Click(object sender, EventArgs e)
        {
            Perform();
        }
    }
}