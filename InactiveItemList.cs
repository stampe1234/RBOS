using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class InactiveItemList : Form
    {
        #region Constructor
        public InactiveItemList()
        {
            InitializeComponent();
            LoadData();

            // position columns
            int index = 0;
            colItemName.DisplayIndex = index++;
            colSubCategory.DisplayIndex = index++;
            colPOSSalesPrice.DisplayIndex = index++;
            colCostPriceLatest.DisplayIndex = index++;
            colLastChangeDateTime.DisplayIndex = index++;
            colBarcode.DisplayIndex = index++;
            colInactivateDateTime.DisplayIndex = index++;
            colDetailsButton.DisplayIndex = index++;

            // localization
            colItemName.HeaderText = db.GetLangString("InactiveItemList.colItemName");
            colSubCategory.HeaderText = db.GetLangString("InactiveItemList.colSubCategory");
            colPOSSalesPrice.HeaderText = db.GetLangString("InactiveItemList.colPOSSalesPrice");
            colCostPriceLatest.HeaderText = db.GetLangString("InactiveItemList.colCostPriceLatest");
            colLastChangeDateTime.HeaderText = db.GetLangString("InactiveItemList.colLastChangeDateTime");
            colBarcode.HeaderText = db.GetLangString("InactiveItemList.colBarcode");
            colInactivateDateTime.HeaderText = db.GetLangString("InactiveItemList.colInactivateDateTime");
            btnClose.Text = db.GetLangString("Application.Close");
            btnCreate.Text = db.GetLangString("Application.Create");
            btnDelete.Text = db.GetLangString("Application.Delete");
            btnSearch.Text = db.GetLangString("Application.Search");
        }
        #endregion

        #region LoadData
        private void LoadData()
        {
            adapterInactiveItem.Connection = db.Connection;
            adapterInactiveItem.FillList(dsItem.InactiveItem);
        }
        #endregion

        #region DeleteCurrent
        private void DeleteCurrent()
        {
            if (bindingInactiveItem.Current != null)
            {
                DataRowView row = (DataRowView)bindingInactiveItem.Current;
                string itemName = tools.object2string(row["ItemName"]);
                string msg = string.Format(db.GetLangString("InactiveItemList.DeleteInactiveItem"), itemName);
                if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int itemID = tools.object2int(row["ItemID"]);
                    msg = ItemDataSet.DeleteInactiveItemAndChilds(itemID);
                    if (msg == "")
                        bindingInactiveItem.RemoveCurrent();
                    else
                        MessageBox.Show(msg);
                }
            }
        }
        #endregion

        #region CreateNew
        private void CreateNew()
        {
            if (bindingInactiveItem.Current == null) return;
            DataRowView row = (DataRowView)bindingInactiveItem.Current;
            int ItemID = tools.object2int(row["ItemID"]);
            if (ItemDataSet.CopyInactiveItemToItems(ItemID))
                bindingInactiveItem.RemoveCurrent();
        }
        #endregion

        #region Search
        private void Search()
        {
            if (bindingInactiveItem.Current == null) return;
            DataRowView row = (DataRowView)bindingInactiveItem.Current;
            SearchForm search = new SearchForm(true);
            search.SelectedItemID = tools.object2int(row["ItemID"]);
            search.DisplaySelectWithFilterButton = false;
            if (search.ShowDialog(this) == DialogResult.OK)
            {
                int Pos = bindingInactiveItem.Find("ItemID", search.SelectedItemID);
                if ((Pos >= 0) && (Pos < bindingInactiveItem.Count))
                    bindingInactiveItem.Position = Pos;
            }
        }
        #endregion

        #region ViewDetails
        private void ViewDetails()
        {
            if (bindingInactiveItem.Current == null) return;
            DataRowView row = (DataRowView)bindingInactiveItem.Current;
            int ItemID = tools.object2int(row["ItemID"]);
            if (ItemID > 0)
            {
                InactiveItemDetails details = new InactiveItemDetails(ItemID);
                details.ShowDialog(this);
            }
        }
        #endregion

        private void InactiveItemList_Load(object sender, EventArgs e)
        {
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteCurrent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateNew();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void drS_DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            ImageButtonRender.OnCellPainting(e, colDetailsButton.Index, ImageButtonRender.Images.DetailForm);
        }

        private void drS_DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colDetailsButton.Index)
            {
                ViewDetails();
            }
        }

        private void drS_DataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
                ViewDetails();
        }
    }
}