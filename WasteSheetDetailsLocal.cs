using RBOS.ItemDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class WasteSheetDetailsLocal : Form
    {
        private int HeaderID = 0;

        #region Constructor
        public WasteSheetDetailsLocal(int HeaderID)
        {
            InitializeComponent();
            this.HeaderID = HeaderID;
            this.DialogResult = DialogResult.Cancel;

            // position grid columns
            int index = 0;
            colItemName.DisplayIndex = index++;
            colLookupItemButton.DisplayIndex = index++;
            colbarcode.DisplayIndex = index++;
            colPackTypeName.DisplayIndex = index++;
            colCostPriceLatest.DisplayIndex = index++;
            colSalesPrice.DisplayIndex = index++;
            

            LoadData();

            // localization
            this.Text = db.GetLangString("WasteSheetDetails.Title");
            lbName.Text = db.GetLangString("WasteSheetDetails.lbName");
            colItemName.HeaderText = db.GetLangString("WasteSheetDetails.colItemName");
            // colBarcode.HeaderText = db.GetLangString("WasteSheetDetails.colBarcode");
            colPackTypeName.HeaderText = db.GetLangString("WasteSheetDetails.colPackTypeName");
            colCostPriceLatest.HeaderText = db.GetLangString("WasteSheetDetails.colCostPriceLatest");
            colSalesPrice.HeaderText = db.GetLangString("WasteSheetDetails.colSalesPrice");
            btnSaveAndClose.Text = db.GetLangString("Application.SaveClose");
            btnCancel.Text = db.GetLangString("Application.Cancel");
        }
        #endregion

        private void LoadData()
        {

            adapterwasteSheetHeaderLocal.Connection = db.Connection;
            adapterwasteSheetHeaderLocal.FillSingle(dsItem.WasteSheetHeaderLocal, HeaderID);
            adapterwasteSheetDetailsLocalLookups.Connection = db.Connection;
            adapterwasteSheetDetailsLocalLookups.Fill(dsItem.WasteSheetDetailsLocalLookups);

            adapterwasteSheetDetailsLocal.Connection = db.Connection;
            adapterwasteSheetDetailsLocal.Fill(dsItem.WasteSheetDetailsLocal, HeaderID);
        }

        private void SaveData()
        {
            // updates the single headerrecord loaded


            bindingWasteSheetHeaderLocal.EndEdit();
            adapterwasteSheetHeaderLocal.Update(dsItem.WasteSheetHeaderLocal);
            string test2 = string.Format(" Update WasteSheetHeaderLocal set NoOffRegistrations = (select COUNT([HeaderID]) from [dbo].[WasteSheetDetailsLocal] " +
                    "   Where [dbo].[WasteSheetDetailsLocal].HeaderID = WasteSheetHeaderLocal.ID)");
            db.ExecuteNonQuery(test2);




            // updates the detail records
            grid.EndEdit();
            bindingWasteSheetDetailsLocal.EndEdit();
            //adapterwasteSheetDetailsLocal.Update(dsItem.WasteSheetDetailsLocal);
            //ItemDataSet.WasteSheetHeaderDataTable.UpdateWasteSheetHeader(HeaderID);
            //ItemDataSet.WasteSheetHeaderLocalDataTable.UpdateWasteSheetHeaderLocal(HeaderID);
        }

        private void WasteSheetDetails_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsItem.WasteSheetDetailsLocalLookups' table. You can move, or remove it, as needed.
            // this.adapterwasteSheetDetailsLocalLookups.Fill(this.dsItem.WasteSheetDetailsLocalLookups) ;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {

            SaveData();
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == colLookupItemButton.Index)
                {
                    // lookup item

                    if (bindingWasteSheetDetailsLocal.Current == null) return;
                    //DataRowView row = (DataRowView)bindingWasteSheetDetails.Current;
                    DataRowView row = (DataRowView)bindingWasteSheetDetailsLocal.Current;
                    double Barcode = tools.object2double(row["Barcode"]);

                    SearchForm search = new SearchForm();
                    search.SelectedBarcode = Barcode;
                    search.DisplaySelectWithFilterButton = false;
                    if (search.ShowDialog(this) == DialogResult.OK)
                    {
                        // check that the item has not already been selected
                        if (!dsItem.WasteSheetDetailsLocal.ItemAlreadySelected(search.SelectedItemID))
                        {
                            row["HeaderID"] = HeaderID;
                            row["LineNo"] = dsItem.WasteSheetDetailsLocal.GetNextLineNo();
                            row["Barcode"] = search.SelectedBarcode;

                            string test2 = string.Format(" INSERT INTO [WasteSheetDetailsLocal] ([HeaderID],[LineNo],[Barcode]) Values ({0}, {1},{2} ) ",
                                HeaderID, dsItem.WasteSheetDetailsLocal.GetNextLineNo(), search.SelectedBarcode);
                            db.ExecuteNonQuery(test2);

                            grid.EndEdit();
                            bindingWasteSheetDetailsLocal.EndEdit();
                            grid.Refresh();
                        }
                        else
                        {
                            MessageBox.Show(db.GetLangString("WasteSheetDetails.ItemAlreadySelected"));
                        }
                    }
                }
            }
        }
        private void grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            ImageButtonRender.OnCellPainting(e, colLookupItemButton.Index, ImageButtonRender.Images.Search);
        }

      

       

        private void grid_UserDeletingRow_1(object sender, DataGridViewRowCancelEventArgs e)
        {
            int i = grid.CurrentRow.Index;
            int Headercolindex = colHeaderID.Index;
            int LineNocolIndex = colLineNo.Index;
            int HeaderID = Convert.ToInt32(grid.Rows[i].Cells[Headercolindex].Value);
            int LineNo = Convert.ToInt32(grid.Rows[i].Cells[LineNocolIndex].Value);
            int test = dsItem.WasteSheetDetailsLocal.Rows.Count;
            test = bindingWasteSheetDetailsLocal.Count;
            dsItem.WasteSheetDetailsLocal.Rows.RemoveAt(i);
            test = dsItem.WasteSheetDetailsLocal.Rows.Count;
            //bindingWasteSheetDetailsLocal.RemoveAt(i);
            test = bindingWasteSheetDetailsLocal.Count;
            string test2 = string.Format(" delete from WasteSheetDetailsLocal Where (HeaderID = {0} ) And ([LineNo] = {1}) ", HeaderID, LineNo);
            db.ExecuteNonQuery(test2);
            test = dsItem.WasteSheetDetailsLocal.Rows.Count;
            grid.Refresh();

        }

        private void grid_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            int i = grid.CurrentRow.Index;
            int Headercolindex = colHeaderID.Index;
            int LineNocolIndex = colLineNo.Index;
            int HeaderID = Convert.ToInt32(grid.Rows[i].Cells[Headercolindex].Value);
            int LineNo = Convert.ToInt32(grid.Rows[i].Cells[LineNocolIndex].Value);


        }
    }
}

        