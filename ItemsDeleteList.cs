using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class ItemsDeleteList : Form
    {
        private string _SubCategory = "";
        private string _SubCategoryDesc = "";
        private DateTime _LatestAllowedDate = DateTime.MinValue;
        private DateTime _LatestAllowedItemChangeDateTime = DateTime.MinValue;
        private bool _DeleteItemsWithStock = false;
        private bool _OnlyIncludeUdmeldte = false;

        public ItemsDeleteList(string SubCategory, string SubCategoryDesc, DateTime LatestAllowedDate, DateTime LatestAllowedItemChangeDateTime, bool DeleteItemsWithStock, bool OnlyIncludeUdmeldte)
        {
            InitializeComponent();
            _SubCategory = SubCategory;
            _SubCategoryDesc = SubCategoryDesc;
            _LatestAllowedDate = LatestAllowedDate;
            _LatestAllowedItemChangeDateTime = LatestAllowedItemChangeDateTime;
            _DeleteItemsWithStock = DeleteItemsWithStock;
            _OnlyIncludeUdmeldte = OnlyIncludeUdmeldte;
            DialogResult = DialogResult.Cancel;
            LoadData();
            DisplayNumSelectedItems();

            int index = 0;
            colIncludeInSemiDelete.DisplayIndex = index++;
            colItemName.DisplayIndex = index++;
            colPackTypeName.DisplayIndex = index++;
            colBarcode.DisplayIndex = index++;
            colOrderingNumber.DisplayIndex = index++;
            colInStock.DisplayIndex = index++;

            // localization
            this.Text = db.GetLangString("ItemsDeleteList.Title");
            btnDelete.Text = db.GetLangString("ItemsDeleteList.btnDelete");
            btnCancel.Text = db.GetLangString("Application.Cancel");
            lbNumSelectedItems.Text = db.GetLangString("ItemsDeleteList.lbNumSelectedItems");
            colItemName.HeaderText = db.GetLangString("ItemsDeletelist.colItemName");
            colPackTypeName.HeaderText = db.GetLangString("ItemsDeleteList.colPackTypeName");
            colBarcode.HeaderText = db.GetLangString("ItemsDeleteList.colBarcode");
            colOrderingNumber.HeaderText = db.GetLangString("ItemsDeleteList.colOrderingNumber");
            colInStock.HeaderText = db.GetLangString("ItemsDeleteList.colInStock");
            colIncludeInSemiDelete.HeaderText = db.GetLangString("ItemsDeleteList.colIncludeInSemiDelete");
        }

        private void LoadData()
        {
            ItemDataSet.SemiDeleteItemsAndChilds_FillTable(
                _SubCategory,
                _LatestAllowedDate,
                _LatestAllowedItemChangeDateTime,
                _DeleteItemsWithStock,
                _OnlyIncludeUdmeldte,
                dsItem.ItemsDelete);
        }

        private int CountSelectedItems()
        {
            grid.EndEdit();
            bindingItemsDelete.EndEdit();
            int num = 0;
            foreach (DataRow row in dsItem.ItemsDelete.Rows)
            {
                if (tools.object2bool(row["IncludeInSemiDelete"]))
                    num++;
            }
            return num;
        }

        private void DisplayNumSelectedItems()
        {
            txtNumSelectedItems.Text = CountSelectedItems().ToString();
        }

        private void DeleteItems()
        {
            int num = CountSelectedItems();
            if (num <= 0)
            {
                // no items marked for delete
                MessageBox.Show(db.GetLangString("ItemsDeleteList.NoItemsSelected"));
                return;
            }
            else
            {
                // ask user if it is ok to delete the items
                string msg = string.Format(db.GetLangString("ItemsDeleteList.DeleteItems"), num);
                if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // delete loaded list of items
                    ItemDataSet.SemiDeleteItemsAndChilds(dsItem.ItemsDelete);

                    // after deleting, show report of deleted items

                    // print loaded list of items
                    report.SetDataSource((DataTable)dsItem.ItemsDelete);

                    // set report texts
                    tools.SetReportObjectText(report, "txtSubCategory", _SubCategory + " " + _SubCategoryDesc);
                    tools.SetReportObjectText(report, "txtLatestAllowedDate", _LatestAllowedDate.ToString("dd-MM-yyyy"));
                    tools.SetReportObjectText(report, "txtDeleteItemsWithStock", (_DeleteItemsWithStock ? "Ja" : "Nej"));
                    tools.SetReportObjectText(report, "txtNumDeleted", num.ToString());

                    // set report site information
                    tools.SetReportSiteInformation(report);

                    // preview the report
                    tools.Print(report, true);

                    // return to calling form
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteItems();
        }

        private void grid_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == colIncludeInSemiDelete.Index)
                DisplayNumSelectedItems();
        }

        private void grid_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colIncludeInSemiDelete.Index)
                DisplayNumSelectedItems();
        }
    }
}