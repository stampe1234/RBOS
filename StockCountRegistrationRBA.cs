using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class StockCountRegistrationRBA : Form
    {
        private bool SettingUltimoControlsFromConstructor = true; // must start out as true

        public StockCountRegistrationRBA()
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
            colKostprisExMoms.DisplayIndex = index++;
            colAntal.DisplayIndex = index++;
            colIalt.DisplayIndex = index++;
            
            // event handlers
            dsItem.StockCountRegistrationRBA.OnMultipleVareFoundByVarenummer += new ItemDataSet.StockCountRegistrationRBADataTable.MultipleVareFoundByVarenummer(StockCountRegistrationRBA_OnMultipleVareFound);
            dsItem.StockCountRegistrationRBA.OnMultipleVareFoundByBarcode += new ItemDataSet.StockCountRegistrationRBADataTable.MultipleVareFoundByBarcode(StockCountRegistrationRBA_OnMultipleVareFoundByBarcode);
            dsItem.StockCountRegistrationRBA.OnLookupValuesChanged += new ItemDataSet.StockCountRegistrationRBADataTable.LookupValuesChanged(StockCountRegistrationRBA_OnLookupValuesChanged);
        }

        void StockCountRegistrationRBA_OnMultipleVareFoundByBarcode(out int LevNr, out double Varenummer, double Barcode)
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

        void StockCountRegistrationRBA_OnLookupValuesChanged()
        {
            grid.Refresh();
        }

        void StockCountRegistrationRBA_OnMultipleVareFound(out int LevNr, double Varenummer)
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
            adapterStockCountRegistrationRBA.Connection = db.Connection;
            adapterStockCountRegistrationRBA.Fill(dsItem.StockCountRegistrationRBA);

            // localization
            lbUltimoDate.Text = db.GetLangString("StockCountRegistrationRBA.lbUltimoDate");
            colVarenummer.HeaderText = db.GetLangString("StockCountRegistrationRBA.colVarenummer");
            colVarenavn.HeaderText = db.GetLangString("StockCountRegistrationRBA.colVarenavn");
            colBarcode.HeaderText = db.GetLangString("StockCountRegistrationRBA.colBarcode");
            colLevNr.HeaderText = db.GetLangString("StockCountRegistrationRBA.colLevNr");
            colVaregruppe.HeaderText = db.GetLangString("StockCountRegistrationRBA.colVaregruppe");
            colKostprisExMoms.HeaderText = db.GetLangString("StockCountRegistrationRBA.colKostprisExMoms");
            colIalt.HeaderText = db.GetLangString("StockCountRegistrationRBA.colIalt");
            colAntal.HeaderText = db.GetLangString("StockCountRegistrationRBA.colAntal");
            btnBook.Text = db.GetLangString("StockCountRegistrationRBA.btnBook");
            btnSaveAndClose.Text = db.GetLangString("Application.SaveClose");

            FillUltimoDateControls();
        }

        private void SaveData()
        {
            grid.EndEdit();
            bindingStockCountRegistrationRBA.EndEdit();
            adapterStockCountRegistrationRBA.Update(dsItem.StockCountRegistrationRBA);

            // save ultimo values
            db.SetConfigString("StockCountRegistrationRBA.UltimoYear", tools.object2string(ddUltimoYear.SelectedValue));
            db.SetConfigString("StockCountRegistrationRBA.UltimoMonth", tools.object2string(ddUltimoMonth.SelectedValue));
        }

        private void Book()
        {
            SaveData();

            // check that we have data
            if (ddUltimoYear.SelectedIndex < 0 || ddUltimoMonth.SelectedIndex < 0)
            {
                MessageBox.Show(db.GetLangString("StockCountRegistrationRBA.MissingUltimoDate"));
                return;
            }
            if (dsItem.StockCountRegistrationRBA.Rows.Count < 1)
            {
                MessageBox.Show(db.GetLangString("StockCountRegistrationRBA.NoDataToBook"));
                return;
            }

            // get initials from user
            WasteRegistrationRBAGetInitials initials = new WasteRegistrationRBAGetInitials();
            if (initials.ShowDialog(this) == DialogResult.OK)
            {
                // book
                string errmsg;
                if (!dsItem.StockCountRegistrationRBA.Book(out errmsg, initials.Initials, GetUltimoDate()))
                {
                    MessageBox.Show(errmsg);
                    return;
                }
                else
                {
                    MessageBox.Show(db.GetLangString("StockCountRegistrationRBA.Booked"));
                    Close();
                }
            }
        }

        #region GetUltimoDate
        /// <summary>
        /// Uses the selected year and month from the dropdowns and creates the ultimodate.
        /// If some error occurs or some invalid values exist, DateTime.MinValue is returned.
        /// </summary>
        /// <returns></returns>
        private DateTime GetUltimoDate()
        {
            try
            {
                int year = tools.object2int(ddUltimoYear.SelectedValue);
                int month = tools.object2int(ddUltimoMonth.SelectedValue);
                return tools.GetLastDateInMonth(new DateTime(year, month, 1));
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
        #endregion

        private void FillUltimoDateControls()
        {
            // build ultimo years
            List<int> Years = new List<int>();
            for (int i = 2000; i <= DateTime.Now.Year; i++)
                Years.Add(i);
            ddUltimoYear.DataSource = Years;

            // build ultimo months
            List<int> Months = new List<int>();
            for (int i = 1; i <= 12; i++)
                Months.Add(i);
            ddUltimoMonth.DataSource = Months;

            // get ultimo values from config (if there is any)
            int UltimoYear = db.GetConfigStringAsInt("StockCountRegistrationRBA.UltimoYear");
            int UltimoMonth = db.GetConfigStringAsInt("StockCountRegistrationRBA.UltimoMonth");

            // check if we had ultimo values in the config
            if (UltimoYear > 0)
            {
                // we did, so use those values
                ddUltimoYear.SelectedIndex = ddUltimoYear.Items.IndexOf(UltimoYear);
                ddUltimoMonth.SelectedIndex = ddUltimoMonth.Items.IndexOf(UltimoMonth);
            }
            else
            {
                // we did not, so do not select anything
                /// NOTE: at some point we did have code that selected the
                /// ultimodate in last month. however, this got confusing for
                /// the user as if there was already booked data on that ultimodate,
                /// the user had to be prompted immediately after openning the interface,
                /// whether or not to wipe existing data or add to them.
                ddUltimoYear.SelectedIndex = -1;
                ddUltimoMonth.SelectedIndex = -1;
            }

            SettingUltimoControlsFromConstructor = false;
        }

        private void SelectedNewUltimoDate()
        {
            if (SettingUltimoControlsFromConstructor)
                return;

            DateTime UltimoDate = GetUltimoDate();
            if (UltimoDate != DateTime.MinValue)
            {
                // check in table ItemTransactionStockCountRBA if we already have data for the date
                if (ItemDataSet.ItemTransactionStockCountRBADataTable.CheckIfAnyData(UltimoDate))
                {
                    // we have data, so user must be asked if he/she wanst to wipe existing data or add to them
                    StockCountRegistrationRBA_EraseBookedDialog dialog = new StockCountRegistrationRBA_EraseBookedDialog();
                    if (dialog.ShowDialog(this) == DialogResult.Cancel)
                    {
                        ddUltimoYear.SelectedIndex = -1;
                        ddUltimoMonth.SelectedIndex = -1;
                    }
                }
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

        private void StockCountRegistrationRBA_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != colLookupVare.Index) return;
            if (bindingStockCountRegistrationRBA.Current == null) return;
            DataRow row = (bindingStockCountRegistrationRBA.Current as DataRowView).Row;
            int LevNr = tools.object2int(row["LevNr"]);
            double Varenummer = tools.object2double(row["Varenummer"]);
            SearchFormRBA search = new SearchFormRBA();
            search.PreSelectVareUnfiltered(LevNr, Varenummer);
            if (search.ShowDialog(this) == DialogResult.OK)
            {                
                row["LevNr"] = search.SelectedLevNr;
                row["Varenummer"] = search.SelectedVarenummer;

                // jump to amount column
                if (grid.CurrentRow != null && grid.CurrentRow.Cells[colAntal.Index] != null)
                    grid.CurrentRow.Cells[colAntal.Index].Selected = true;
            }
        }

        private void grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == colLookupVare.Index)
                ImageButtonRender.OnCellPainting(e, colLookupVare.Index, ImageButtonRender.Images.Search);
        }

        private void grid_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            // when row validates, we check some stuff...

            if (bindingStockCountRegistrationRBA.Current == null)
                return;
            DataRow row = (bindingStockCountRegistrationRBA.Current as DataRowView).Row;

            // if some input values are missing, delete the row
            if (tools.IsNullOrDBNull(row["Varenummer"]) ||
                tools.IsNullOrDBNull(row["Barcode"]) ||
                tools.IsNullOrDBNull(row["Antal"]))
            {
                bindingStockCountRegistrationRBA.RemoveCurrent();
                return;
            }

            // validate Varenummer
            if (tools.IsNullOrDBNull(row["Varenummer"]))
            {
                MessageBox.Show(db.GetLangString("StockCountRegistrationRBA.msgIndtastVarenummer"));
                e.Cancel = true;
                return;
            }
            else
            {
                double Varenummer = tools.object2double(row["Varenummer"]);
                if (ItemDataSet.AfskrProdDataTable.GetNumRecordsByVarenummer(Varenummer) <= 0)
                {
                    MessageBox.Show(db.GetLangString("StockCountRegistrationRBA.msgNoItemWithThatNumber"));
                    e.Cancel = true;
                    return;
                }
            }

            // validate Barcode
            if (tools.IsNullOrDBNull(row["Barcode"]))
            {
                MessageBox.Show(db.GetLangString("StockCountRegistrationRBA.msgEnterBarcode"));
                e.Cancel = true;
                return;
            }
            else
            {
                double barcode = tools.object2double(row["Barcode"]);
                if (ItemDataSet.AfskrProdDataTable.GetNumRecordsByBarcode(barcode) <= 0)
                {
                    MessageBox.Show(db.GetLangString("StockCountRegistrationRBA.msgNoItemWithThatBarcode"));
                    e.Cancel = true;
                    return;
                }
            }

            // validate antal
            if (tools.object2int(row["Antal"]) <= 0)
            {
                MessageBox.Show(db.GetLangString("StockCountRegistrationRBA.msgNumOfNotBelow0"));
                e.Cancel = true;
                return;
            }
            else if (tools.object2int(row["Antal"]) > 999)
            {
                MessageBox.Show(db.GetLangString("StockCountRegistrationRBA.msgNumMax999"));
                e.Cancel = true;
                return;
            }
        }

        private void ddUltimoYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedNewUltimoDate();
        }

        private void ddUltimoMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedNewUltimoDate();
        }

        private void grid_KeyUp(object sender, KeyEventArgs e)
        {
            /// jump to colAntal if coming from Varenummer or Barcode columns.
            /// Note that the checks are done on the columns after those two columns,
            /// as the KeyUp has already positioned the cursor in the next column.
            if (grid.CurrentRow != null &&
                grid.CurrentCell != null &&
                (grid.CurrentCell.ColumnIndex == colLookupVare.Index || grid.CurrentCell.ColumnIndex == colVarenavn.Index) &&
                (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab))
            {
                grid.CurrentCell = grid.CurrentRow.Cells[colAntal.Index];
            }
        }

        private void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void grid_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}