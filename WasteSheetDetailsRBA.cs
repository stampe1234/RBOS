using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class WasteSheetDetailsRBA : Form
    {
        private int HeaderID = 0;

        #region Constructor
        public WasteSheetDetailsRBA(int HeaderID)
        {
            InitializeComponent();
            this.HeaderID = HeaderID;
            this.DialogResult = DialogResult.Cancel;

            // position grid columns
            int index = 0;
            colLevNr.DisplayIndex = index++;
            colVarenummer.DisplayIndex = index++;
            colVarenavn.DisplayIndex = index++;
            colLookupItemButton.DisplayIndex = index++;
            colBarcode.DisplayIndex = index++;
            colKostpris.DisplayIndex = index++;
            colSalgspris.DisplayIndex = index++;

            LoadData();

            // localization
            this.Text = db.GetLangString("WasteSheetDetailsRBA.Title");
            lbName.Text = db.GetLangString("WasteSheetDetailsRBA.lbName");
            colLevNr.HeaderText = db.GetLangString("WasteSheetDetailsRBA.colLevNr");
            colVarenummer.HeaderText = db.GetLangString("WasteSheetDetailsRBA.colVarenummer");
            colVarenavn.HeaderText = db.GetLangString("WasteSheetDetailsRBA.colVarenavn");
            colBarcode.HeaderText = db.GetLangString("WasteSheetDetailsRBA.colBarcode");
            colKostpris.HeaderText = db.GetLangString("WasteSheetDetailsRBA.colKostpris");
            colSalgspris.HeaderText = db.GetLangString("WasteSheetDetailsRBA.colSalgspris");
            btnSaveAndClose.Text = db.GetLangString("Application.SaveClose");
            btnUp.Text = db.GetLangString("WasteSheetDetailsRBA.btnMoveUp");
            btnDown.Text = db.GetLangString("WasteSheetDetailsRBA.btnMoveDown");
        }
        #endregion

        private void LoadData()
        {
            adapterWasteSheetHeader.Connection = db.Connection;
            adapterWasteSheetHeader.FillSingle(dsItem.WasteSheetHeader, HeaderID);

            adapterWasteSheetDetailsRBA.Connection = db.Connection;
            adapterWasteSheetDetailsRBA.FillWithLookups(dsItem.WasteSheetDetailsRBA, HeaderID);
        }

        private void SaveData()
        {
            // updates the single headerrecord loaded
            bindingWasteSheetHeader.EndEdit();
            adapterWasteSheetHeader.Update(dsItem.WasteSheetHeader);

            // updates the detail records
            grid.EndEdit();
            bindingWasteSheetDetailsRBA.EndEdit();
            adapterWasteSheetDetailsRBA.Update(dsItem.WasteSheetDetailsRBA);
        }

        private void MoveSelectedRecordUp()
        {
            if (bindingWasteSheetDetailsRBA.Current != null)
            {
                int pos = bindingWasteSheetDetailsRBA.Position;
                if (pos > 0)
                {
                    SaveData();

                    DataRow CurrRow = ((DataRowView)bindingWasteSheetDetailsRBA.Current).Row;
                    int CurrLineNo = tools.object2int(CurrRow["LineNo"]);
                    
                    bindingWasteSheetDetailsRBA.MovePrevious();
                    DataRow PrevRow = ((DataRowView)bindingWasteSheetDetailsRBA.Current).Row;
                    int PrevLineNo = tools.object2int(PrevRow["LineNo"]);

                    ItemDataSet.WasteSheetDetailsRBADataTable.SwapRecords(HeaderID, CurrLineNo, PrevLineNo);

                    LoadData();

                    bindingWasteSheetDetailsRBA.Position = pos - 1;
                }
            }
        }

        private void MoveSelectedRecordDown()
        {
            if (bindingWasteSheetDetailsRBA.Current != null)
            {
                int pos = bindingWasteSheetDetailsRBA.Position;
                if ((pos >= 0) && (pos < bindingWasteSheetDetailsRBA.Count - 1))
                {
                    SaveData();

                    DataRow CurrRow = ((DataRowView)bindingWasteSheetDetailsRBA.Current).Row;
                    int CurrLineNo = tools.object2int(CurrRow["LineNo"]);

                    bindingWasteSheetDetailsRBA.MoveNext();
                    DataRow NextRow = ((DataRowView)bindingWasteSheetDetailsRBA.Current).Row;
                    int NextLineNo = tools.object2int(NextRow["LineNo"]);

                    ItemDataSet.WasteSheetDetailsRBADataTable.SwapRecords(HeaderID, CurrLineNo, NextLineNo);

                    LoadData();

                    bindingWasteSheetDetailsRBA.Position = pos + 1;
                }
            }
        }

        private void WasteSheetDetailsRBA_Load(object sender, EventArgs e)
        {
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

                    if (bindingWasteSheetDetailsRBA.Current == null) return;
                    DataRowView row = (DataRowView)bindingWasteSheetDetailsRBA.Current;

                    SearchFormRBA search = new SearchFormRBA();
                    if (search.ShowDialog(this) == DialogResult.OK)
                    {
                        // check that the item has not already been selected
                        if (!dsItem.WasteSheetDetailsRBA.ItemAlreadySelected(search.SelectedLevNr, search.SelectedVarenummer))
                        {
                            row["HeaderID"] = HeaderID;
                            row["LineNo"] = dsItem.WasteSheetDetailsRBA.GetNextLineNo();
                            row["LevNr"] = search.SelectedLevNr;
                            row["Varenummer"] = search.SelectedVarenummer;
                            
                            grid.EndEdit();
                            bindingWasteSheetDetailsRBA.EndEdit();
                            grid.Invalidate();
                        }
                        else
                        {
                            MessageBox.Show(db.GetLangString("WasteSheetDetailsRBA.ItemAlreadySelected"));
                        }
                    }
                }
            }
        }

        private void grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            ImageButtonRender.OnCellPainting(e, colLookupItemButton.Index, ImageButtonRender.Images.Search);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            MoveSelectedRecordUp();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            MoveSelectedRecordDown();
        }

      
    }
}