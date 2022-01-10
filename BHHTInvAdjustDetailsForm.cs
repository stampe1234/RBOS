using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class BHHTInvAdjustDetailsForm : Form
    {
        // constructor
        public BHHTInvAdjustDetailsForm(int AdjustID)
        {
            InitializeComponent();

            // load data
            adapterInvAdjustDetails.Connection = db.Connection;
            adapterInvAdjustDetails.Fill(dsImport.BHHTInvAdjustDetails, AdjustID);
            adapterLookupItem.Connection = db.Connection;
            adapterLookupItem.Fill(dsImport.LookupItem);
            adapterLookupPackType.Connection = db.Connection;
            adapterLookupPackType.Fill(dsItem.LookupPackSize);

            // position grid columns (bug in VS2005)
            
            colAdjustID.DisplayIndex = 0;
            colItemID.DisplayIndex = 1;
            colPackType.DisplayIndex = 2;
            colQuantity.DisplayIndex = 3;
            colTimeStmp.DisplayIndex = 4;
            
        }

        #region METHOD: SaveData
        /// <summary>
        /// Saves any changes to the header table.
        /// </summary>
        private void SaveData()
        {
            DataTable changes = dsImport.BHHTInvAdjustDetails.GetChanges();
            if ((changes != null) && (changes.Rows.Count > 0))
                adapterInvAdjustDetails.Update(dsImport.BHHTInvAdjustDetails);
        }
        #endregion

        // close button click event
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // grid row validated event
        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            SaveData();
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
        }

        private void BHHTInvAdjustDetailsForm_Load(object sender, EventArgs e)
        {
         
            this.adapterLookupPackType.Fill(this.dsItem.LookupPackSize);
            
            // Localization

            colItemID.HeaderText = db.GetLangString("InvAdjDetailForm.ItemIDLabel");
            colPackType.HeaderText = db.GetLangString("InvAdjDetailForm.PackTypeLabel");
            colExclude.HeaderText = db.GetLangString("InvAdjDetailForm.ExcludeLabel");
            colAdjustID.HeaderText = db.GetLangString("InvAdjDetailForm.IDLabel");
            colQuantity.HeaderText = db.GetLangString("InvAdjDetailForm.QuantityLabel");
            colTimeStmp.HeaderText = db.GetLangString("InvAdjDetailForm.TimeStampLabel");

            btnClose.Text = db.GetLangString("Application.Close");
            this.Text = db.GetLangString("BHHTInvAdjustDetailsForm.Title");
        }

        private void lookupPackSizeBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void bindingInvAdjustDetails_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}