using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class WasteSheetDetails : Form
    {
        private int HeaderID = 0;

        #region Constructor
        public WasteSheetDetails(int HeaderID)
        {
            InitializeComponent();
            this.HeaderID = HeaderID;
            this.DialogResult = DialogResult.Cancel;

            // position grid columns
            int index = 0;
            colItemName.DisplayIndex = index++;            
            colBarcode.DisplayIndex = index++;
            colPackTypeName.DisplayIndex = index++;
            colCostPriceLatest.DisplayIndex = index++;
            colSalesPrice.DisplayIndex = index++;
            colLookupItemButton.DisplayIndex = index++;

            LoadData();

            // localization
            this.Text = db.GetLangString("WasteSheetDetails.Title");
            lbName.Text = db.GetLangString("WasteSheetDetails.lbName");
            colItemName.HeaderText = db.GetLangString("WasteSheetDetails.colItemName");
            colBarcode.HeaderText = db.GetLangString("WasteSheetDetails.colBarcode");
            colPackTypeName.HeaderText = db.GetLangString("WasteSheetDetails.colPackTypeName");
            colCostPriceLatest.HeaderText = db.GetLangString("WasteSheetDetails.colCostPriceLatest");
            colSalesPrice.HeaderText = db.GetLangString("WasteSheetDetails.colSalesPrice");
            btnSaveAndClose.Text = db.GetLangString("Application.SaveClose");
            btnCancel.Text = db.GetLangString("Application.Cancel");
        }
        #endregion

        private void LoadData()
        {
            adapterWasteSheetHeader.Connection = db.Connection;
            adapterWasteSheetHeader.FillSingle(dsItem.WasteSheetHeader, HeaderID);

            adapterWasteSheetDetailsLookups.Connection = db.Connection;
            adapterWasteSheetDetailsLookups.Fill(dsItem.WasteSheetDetailsLookups);

            adapterWasteSheetDetails.Connection = db.Connection;
            adapterWasteSheetDetails.Fill(dsItem.WasteSheetDetails, HeaderID);
        }

        private void SaveData()
        {
            // updates the single headerrecord loaded
           
            bindingWasteSheetHeader.EndEdit();
            adapterWasteSheetHeader.Update(dsItem.WasteSheetHeader);                       
           

            // updates the detail records
            grid.EndEdit();
            bindingWasteSheetDetails.EndEdit();            
            adapterWasteSheetDetails.Update(dsItem.WasteSheetDetails);
            ItemDataSet.WasteSheetHeaderDataTable.UpdateWasteSheetHeader(HeaderID);
            

        }

        private void WasteSheetDetails_Load(object sender, EventArgs e)
        {
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

                    if (bindingWasteSheetDetails.Current == null) return;
                    DataRowView row = (DataRowView)bindingWasteSheetDetails.Current;
                    double Barcode = tools.object2double(row["Barcode"]);

                    SearchForm search = new SearchForm();
                    search.SelectedBarcode = Barcode;
                    search.DisplaySelectWithFilterButton = false;
                    if (search.ShowDialog(this) == DialogResult.OK)
                    {
                        // check that the item has not already been selected
                        if (!dsItem.WasteSheetDetails.ItemAlreadySelected(search.SelectedItemID))
                        {
                            row["HeaderID"] = HeaderID;
                            row["LineNo"] = dsItem.WasteSheetDetails.GetNextLineNo();
                            row["Barcode"] = search.SelectedBarcode;

                            grid.EndEdit();
                            bindingWasteSheetDetails.EndEdit();
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


    
        

        private void cBoxWaste_CheckedChanged(object sender, EventArgs e)
        {
           
             
           
        }

        private void cBoxStockCount_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void cBoxWaste_Click(object sender, EventArgs e)
        {
            if (cBoxWaste.Checked)
            {
                cBoxStockCount.Checked = false;
            }
            else
            { cBoxStockCount.Checked = true; }

        }

        private void cBoxStockCount_Click(object sender, EventArgs e)
        {
            if (cBoxStockCount.Checked)
            { cBoxWaste.Checked = false; }
            else { cBoxStockCount.Checked = true; }

        }

        private void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == colAntal.Index)
                {

                    if (bindingWasteSheetDetails.Current == null) return;
                    DataRowView row = (DataRowView)bindingWasteSheetDetails.Current;
                    row["DatoTid"] = System.DateTime.Now;                                  

                    grid.EndEdit();
                    bindingWasteSheetDetails.EndEdit();
                    grid.Refresh();
                   
                }
            }

        }
    }
}