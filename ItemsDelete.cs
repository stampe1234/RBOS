using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class ItemsDelete : Form
    {
        #region Constructor
        public ItemsDelete()
        {
            InitializeComponent();
            dtDaysBack.MaxDate = LatestDate();
            dtNotChangedSince.Value = LatestDate();

            // localization
            lbSubCategory.Text = db.GetLangString("ItemsDelete.lbSubCategory");
            lbDaysBack.Text = db.GetLangString("ItemsDelete.lbDaysBack");
            lbNotChangedSince.Text = db.GetLangString("ItemsDelete.lbNotChangedSince");
            chkDeleteItemsWithStock.Text = db.GetLangString("ItemsDelete.chkDeleteItemsWithStock");
            chkOnlyIncludeUdmeldte.Text = db.GetLangString("ItemsDelete.chkOnlyIncludeUdmeldte");
            btnShowItemsToBeDeleted.Text = db.GetLangString("ItemsDelete.btnShowItemsToBeDeleted");
            btnClose.Text = db.GetLangString("Application.Close");
        }
        #endregion

        #region LatestDate
        private DateTime LatestDate()
        {
            int DaysBack = db.GetConfigStringAsInt("ItemsDelete.DaysBackMinimum");
            if (DaysBack < 90)
                DaysBack = 90;
            return DateTime.Now.Date.AddDays(-DaysBack);
        }
        #endregion

        #region CheckCriterias
        private bool CheckCriterias()
        {
            if (txtSubCategory.Text == "")
            {
                MessageBox.Show(db.GetLangString("ItemsDelete.SelectSubCategory"));
                return false;
            }
            return true;
        }
        #endregion

        #region ShowPreviewForm
        private void ShowPreviewForm()
        {
            // check that user has selected the needed values
            if (!CheckCriterias()) return;

            // show the preview form
            ItemsDeleteList previewform = new ItemsDeleteList(
                txtSubCategory.Text,
                txtSubCategoryDesc.Text,
                dtDaysBack.Value.Date,
                dtNotChangedSince.Value.Date,
                chkDeleteItemsWithStock.Checked,
                chkOnlyIncludeUdmeldte.Checked);
            if (previewform.ShowDialog(this) == DialogResult.OK)
            {
                // show message to user that items has been deleted
                MessageBox.Show(db.GetLangString("ItemsDelete.ItemDeleted"));

                // refresh the number of items to be deleted
                // which now is 0 with the current criterias
                UpdateStatus();
            }
        }
        #endregion

        #region UpdateStatus
        private void UpdateStatus()
        {
            int num = ItemDataSet.SemiDeleteItemsAndChilds_HowManyWouldBeDeleted(
                txtSubCategory.Text,
                dtDaysBack.Value.Date,
                dtNotChangedSince.Value.Date,
                chkDeleteItemsWithStock.Checked,
                chkOnlyIncludeUdmeldte.Checked);

            statusLabel.Text = string.Format(db.GetLangString("ItemsDelete.NumItemsToBeDeleted"), num);
        }
        #endregion

        #region LookupSubCategory
        private void LookupSubCategory()
        {
            SubCategoryPopup subcat = new SubCategoryPopup();
            subcat.SelectedSubCategoryID = txtSubCategory.Text;
            subcat.AllowTypeCode15 = false;
            if (subcat.ShowDialog(this) == DialogResult.OK)
            {
                if (subcat.SelectedSubCategoryID != "")
                {
                    txtSubCategory.Text = subcat.SelectedSubCategoryID;
                    txtSubCategoryDesc.Text = subcat.SelectedSubCategoryDesc;
                }
            }
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLookupSubCategory_Click(object sender, EventArgs e)
        {
            LookupSubCategory();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ShowPreviewForm();
        }

        private void btnShowItemsToBeDeleted_Click(object sender, EventArgs e)
        {
            ShowPreviewForm();
        }

        private void txtSubCategory_TextChanged(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void dtDaysBack_ValueChanged(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void chkDeleteItemsWithStock_CheckedChanged(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void dtNotChangedSince_ValueChanged(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void chkOnlyIncludeUdmeldte_CheckedChanged(object sender, EventArgs e)
        {
            UpdateStatus();
        }
    }
}