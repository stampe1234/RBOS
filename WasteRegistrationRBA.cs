using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class WasteRegistrationRBA : Form
    {
        private DateTime OpenDay = DateTime.MinValue;

        public WasteRegistrationRBA()
        {
            InitializeComponent();

            // set grid column order
            int index = 0;
            colVarenummer.DisplayIndex = index++;
            colLookupVare.DisplayIndex = index++;
            colBarcode.DisplayIndex = index++;
            colVarenavn.DisplayIndex = index++;
            colLevNr.DisplayIndex = index++;
            colVaregruppe.DisplayIndex = index++;
            colKostpris.DisplayIndex = index++;
            colSalgspris.DisplayIndex = index++;
            colAntal.DisplayIndex = index++;

            // event handlers
            dsItem.WasteRegistrationRBA.OnMultipleVareFoundByVarenummer += new ItemDataSet.WasteRegistrationRBADataTable.MultipleVareFoundByVarenummer(WasteRegistrationRBA_OnMultipleVareFound);
            dsItem.WasteRegistrationRBA.OnMultipleVareFoundByBarcode += new ItemDataSet.WasteRegistrationRBADataTable.MultipleVareFoundByBarcode(WasteRegistrationRBA_OnMultipleVareFoundByBarcode);
            dsItem.WasteRegistrationRBA.OnLookupValuesChanged += new ItemDataSet.WasteRegistrationRBADataTable.LookupValuesChanged(WasteRegistrationRBA_OnLookupValuesChanged);
        }

        void WasteRegistrationRBA_OnMultipleVareFoundByBarcode(out int LevNr, out double Varenummer, double Barcode)
        {
            SearchFormRBA search = new SearchFormRBA();
            search.PreSelectBarcodeFiltered(Barcode);
            if (search.ShowDialog(this) == DialogResult.OK)
            {
                LevNr = search.SelectedLevNr;
                Varenummer = search.SelectedVarenummer;
            }
            else
            {
                LevNr = 0;
                Varenummer = 0;
            }
        }

        void WasteRegistrationRBA_OnLookupValuesChanged()
        {
            grid.Refresh();
        }

        void WasteRegistrationRBA_OnMultipleVareFound(out int LevNr, double Varenummer)
        {
            SearchFormRBA search = new SearchFormRBA();
            search.PreSelectVarenummerFiltered(Varenummer);
            if (search.ShowDialog(this) == DialogResult.OK)
                LevNr = search.SelectedLevNr;
            else
                LevNr = 0;
        }

        private void LoadData()
        {
            adapterWasteRegistrationRBA.Connection = db.Connection;
            adapterWasteRegistrationRBA.Fill(dsItem.WasteRegistrationRBA);

            // localization
            lbOpenDay.Text = db.GetLangString("WasteRegistrationRBA.lbOpenDay");
            colVarenummer.HeaderText = db.GetLangString("WasteRegistrationRBA.colVarenummer");
            colVarenavn.HeaderText = db.GetLangString("WasteRegistrationRBA.colVarenavn");
            colBarcode.HeaderText = db.GetLangString("WasteRegistrationRBA.colBarcode");
            colLevNr.HeaderText = db.GetLangString("WasteRegistrationRBA.colLevNr");
            colVaregruppe.HeaderText = db.GetLangString("WasteRegistrationRBA.colVaregruppe");
            colKostpris.HeaderText = db.GetLangString("WasteRegistrationRBA.colKostpris");
            colSalgspris.HeaderText = db.GetLangString("WasteRegistrationRBA.colSalgspris");
            colAntal.HeaderText = db.GetLangString("WasteRegistrationRBA.colAntal");
            btnBook.Text = db.GetLangString("WasteRegistrationRBA.btnBook");
            btnSaveAndClose.Text = db.GetLangString("Application.SaveClose");

            DataRow row = EODDataSet.EODReconcileDataTable.GetCurrentOpenDay();
            if (row != null)
            {
                OpenDay = tools.object2datetime(row["BookDate"]);
                lbOpenDay.Text += " " + OpenDay.ToString("dd-MM-yyyy");
            }
        }

        private void SaveData()
        {
            grid.EndEdit();
            bindingWasteRegistrationRBA.EndEdit();
            adapterWasteRegistrationRBA.Update(dsItem.WasteRegistrationRBA);
        }

        private void Book()
        {
            SaveData();

            // check that we have data
            if (dsItem.WasteRegistrationRBA.Rows.Count < 1)
            {
                MessageBox.Show(db.GetLangString("WasteRegistrationRBA.NoDataToBook"));
                return;
            }

            // get initials from user
            WasteRegistrationRBAGetInitials initials = new WasteRegistrationRBAGetInitials();
            if (initials.ShowDialog(this) == DialogResult.OK)
            {
                // book
                string errmsg;
                if (!dsItem.WasteRegistrationRBA.Book(out errmsg, initials.Initials, OpenDay))
                {
                    MessageBox.Show(errmsg);
                    return;
                }
                else
                {
                    MessageBox.Show(db.GetLangString("WasteRegistrationRBA.Booked"));
                    Close();
                }
            }
        }

        private void LockUnlockManualCells(int RowIndex)
        {
            if (RowIndex < 0) return;

            if (tools.object2bool(grid[colManualInput.Index, RowIndex].Value))
            {
                grid[colVarenavn.Index, RowIndex].ReadOnly = false;
                grid[colSalgspris.Index, RowIndex].ReadOnly = false;
                grid[colVarenavn.Index, RowIndex].Style.BackColor = SystemColors.Window;
                grid[colSalgspris.Index, RowIndex].Style.BackColor = SystemColors.Window;
            }
            else
            {
                grid[colVarenavn.Index, RowIndex].ReadOnly = true;
                grid[colSalgspris.Index, RowIndex].ReadOnly = true;
                grid[colVarenavn.Index, RowIndex].Style.BackColor = SystemColors.ButtonFace;
                grid[colSalgspris.Index, RowIndex].Style.BackColor = SystemColors.ButtonFace;
            }
        }
        
        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            SaveData();
            Close();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            Book();
        }

        private void WasteRegistrationRBA_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != colLookupVare.Index) return;
            if (bindingWasteRegistrationRBA.Current == null) return;
            DataRow row = (bindingWasteRegistrationRBA.Current as DataRowView).Row;
            int LevNr = tools.object2int(row["LevNr"]);
            double Varenummer = tools.object2double(row["Varenummer"]);
            SearchFormRBA search = new SearchFormRBA();
            search.PreSelectVareUnfiltered(LevNr, Varenummer);
            if (search.ShowDialog(this) == DialogResult.OK)
            {                
                row["LevNr"] = search.SelectedLevNr;
                row["Varenummer"] = search.SelectedVarenummer;

                // jump to amount column
                for (int i = 0; i < 7; i++)
                    SendKeys.Send("{TAB}");
            }
        }

        private void grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == colLookupVare.Index)
                ImageButtonRender.OnCellPainting(e, colLookupVare.Index, ImageButtonRender.Images.Search);
            else if ((e.ColumnIndex == colVarenavn.Index) || (e.ColumnIndex == colSalgspris.Index))
                LockUnlockManualCells(e.RowIndex);
        }

        private void grid_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            // when row validates, we check some stuff...

            if (bindingWasteRegistrationRBA.Current == null)
                return;
            DataRow row = (bindingWasteRegistrationRBA.Current as DataRowView).Row;

            // if some input values are missing, delete the row
            if (tools.IsNullOrDBNull(row["Varenummer"]) ||
                tools.IsNullOrDBNull(row["Barcode"]) ||
                tools.IsNullOrDBNull(row["Antal"]))
            {
                bindingWasteRegistrationRBA.RemoveCurrent();
                return;
            }

            // validate Varenummer
            if (tools.IsNullOrDBNull(row["Varenummer"]))
            {
                MessageBox.Show(db.GetLangString("WasteRegistrationRBA.msgIndtastVarenummer"));
                e.Cancel = true;
                return;
            }
            else
            {
                double Varenummer = tools.object2double(row["Varenummer"]);
                if (ItemDataSet.AfskrProdDataTable.GetNumRecordsByVarenummer(Varenummer) <= 0)
                {
                    MessageBox.Show(db.GetLangString("WasteRegistrationRBA.msgNoItemWithThatNumber"));
                    e.Cancel = true;
                    return;
                }
            }

            // validate Barcode
            if (tools.IsNullOrDBNull(row["Barcode"]))
            {
                MessageBox.Show(db.GetLangString("WasteRegistrationRBA.msgEnterBarcode"));
                e.Cancel = true;
                return;
            }
            else
            {
                double barcode = tools.object2double(row["Barcode"]);
                if (ItemDataSet.AfskrProdDataTable.GetNumRecordsByBarcode(barcode) <= 0)
                {
                    MessageBox.Show(db.GetLangString("WasteRegistrationRBA.msgNoItemWithThatBarcode"));
                    e.Cancel = true;
                    return;
                }
            }

            // validate antal
            if (tools.object2int(row["Antal"]) <= 0)
            {
                MessageBox.Show(db.GetLangString("WasteRegistrationRBA.msgNumOfNotBelow0"));
                e.Cancel = true;
                return;
            }
            else if (tools.object2int(row["Antal"]) > 999)
            {
                MessageBox.Show(db.GetLangString("WasteRegistrationRBA.msgNumMax999"));
                e.Cancel = true;
                return;
            }

            // validate stuff on items that allow custom input
            if (tools.object2bool(row["ManualInput"]))
            {
                // validate varenavn
                if (tools.object2string(row["Varenavn"]) == "")
                {
                    MessageBox.Show(db.GetLangString("WasteRegistrationRBA.msgVarenavnEmpty"));
                    e.Cancel = true;
                    return;
                }

                // validate salgspris
                if (tools.object2double(row["Salgspris"]) <= 0)
                {
                    MessageBox.Show(db.GetLangString("WasteRegistrationRBA.msgSalgsprisInvalid"));
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void grid_KeyUp(object sender, KeyEventArgs e)
        {
            if (((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab)) &&
                (grid.CurrentCell != null) &&
                (grid.CurrentCell.ColumnIndex == colLookupVare.Index))
            {
                // jump to amount column
                for (int i = 0; i < 7; i++)
                    SendKeys.Send("{TAB}");
            }
        }
    }
}