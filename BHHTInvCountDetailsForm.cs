using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class BHHTInvCountDetailsForm : Form
    {
        public BHHTInvCountDetailsForm( long CountID )
        {
            InitializeComponent();
            
            this.adapterCountDetails.Connection = db.Connection;
            this.adapterCountDetails.Fill(this.dsImport.BHHTInvCountDetails, CountID);

            adapterLookupItem.Connection = db.Connection;
            adapterLookupItem.Fill(dsImport.LookupItem);

            adapterLookupPackSize.Connection = db.Connection;
            adapterLookupPackSize.Fill(dsItem.LookupPackSize);
        }

        private void bHHTInvCountDetailsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        #region Method: SaveData
        /// <summary>
        /// Saves any changes to the detail table.
        /// </summary>
        private void SaveData()
        {
            DataTable changes = dsImport.BHHTInvCountDetails.GetChanges();
            if ((changes != null) && (changes.Rows.Count > 0))
                adapterCountDetails.Update(dsImport.BHHTInvCountDetails);
        }
        
        #endregion


        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BHHTInvCountDetailsForm_Load(object sender, EventArgs e)
        {
            // Set display index for colums
            colCountID.DisplayIndex = 0;
            colItemName.DisplayIndex = 1;
            colPackType.DisplayIndex = 2;
            colQuantity.DisplayIndex = 3;
            colTimeStamp.DisplayIndex = 4;
            colSubCat.DisplayIndex = 5;
            colCostPrice.DisplayIndex = 6;

            // Localization

            btnClose.Text = db.GetLangString("Application.Close");
            colItemName.HeaderText = db.GetLangString("BHHTInvCoDetForm.ItemNameLabel");
            colSubCat.HeaderText = db.GetLangString("BHHTInvCoDetForm.CategoryLabel");
            colCostPrice.HeaderText = db.GetLangString("BHHTInvCoDetForm.CostPriceLabel");
            colPackType.HeaderText = db.GetLangString("BHHTInvCoDetForm.PackTypeLabel");
            colCountID.HeaderText = db.GetLangString("BHHTInvCoDetForm.CountIDLabel");
            colQuantity.HeaderText = db.GetLangString("BHHTInvCoDetForm.NoOfLabel");
            colTimeStamp.HeaderText = db.GetLangString("BHHTInvCoDetForm.TimeStampLabel");

            this.Text = db.GetLangString("BHHTInvCoDetForm.Title");
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            SaveData();
        }
    }
}