using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class ForbrugsvareRegistrering : Form
    {
        private DateTime OpenDay = DateTime.MinValue;

        public ForbrugsvareRegistrering()
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
            colKostpris.DisplayIndex = index++; // for now this columns is hidden
            colSalgspris.DisplayIndex = index++;
            colAntal.DisplayIndex = index++;

            // event handlers
            dsItem.ForbrugsvareRegistrering.OnMultipleVareFoundByVarenummer += new ItemDataSet.ForbrugsvareRegistreringDataTable.MultipleVareFoundByVarenummer(ForbrugsvareRegistrering_OnMultipleVareFound);
            dsItem.ForbrugsvareRegistrering.OnMultipleVareFoundByBarcode += new ItemDataSet.ForbrugsvareRegistreringDataTable.MultipleVareFoundByBarcode(ForbrugsvareRegistrering_OnMultipleVareFoundByBarcode);
            dsItem.ForbrugsvareRegistrering.OnLookupValuesChanged += new ItemDataSet.ForbrugsvareRegistreringDataTable.LookupValuesChanged(ForbrugsvareRegistrering_OnLookupValuesChanged);
        }

        void ForbrugsvareRegistrering_OnMultipleVareFoundByBarcode(out int LevNr, out double Varenummer, double Barcode)
        {
            ForbrugsvareSearch search = new ForbrugsvareSearch();
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

        void ForbrugsvareRegistrering_OnLookupValuesChanged()
        {
            grid.Refresh();
        }

        void ForbrugsvareRegistrering_OnMultipleVareFound(out int LevNr, double Varenummer)
        {
            ForbrugsvareSearch search = new ForbrugsvareSearch();
            search.PreSelectVarenummerFiltered(Varenummer);
            if (search.ShowDialog(this) == DialogResult.OK)
                LevNr = search.SelectedLevNr;
            else
                LevNr = 0;
        }

        private void LoadData()
        {
            adapterForbrugsvareRegistrering.Connection = db.Connection;
            adapterForbrugsvareRegistrering.Fill(dsItem.ForbrugsvareRegistrering);

            // localization
            lbOpenDay.Text = db.GetLangString("ForbrugsvareRegistrering.lbOpenDay");
            colVarenummer.HeaderText = db.GetLangString("ForbrugsvareRegistrering.colVarenummer");
            colVarenavn.HeaderText = db.GetLangString("ForbrugsvareRegistrering.colVarenavn");
            colBarcode.HeaderText = db.GetLangString("ForbrugsvareRegistrering.colBarcode");
            colLevNr.HeaderText = db.GetLangString("ForbrugsvareRegistrering.colLevNr");
            colVaregruppe.HeaderText = db.GetLangString("ForbrugsvareRegistrering.colVaregruppe");
            colKostpris.HeaderText = db.GetLangString("ForbrugsvareRegistrering.colKostpris");
            colSalgspris.HeaderText = db.GetLangString("ForbrugsvareRegistrering.colSalgspris");
            colAntal.HeaderText = db.GetLangString("ForbrugsvareRegistrering.colAntal");
            btnBook.Text = db.GetLangString("ForbrugsvareRegistrering.btnBook");
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
            bindingForbrugsvareRegistrering.EndEdit();
            adapterForbrugsvareRegistrering.Update(dsItem.ForbrugsvareRegistrering);
        }

        private void Book()
        {
            SaveData();

            // check that we have data
            if (dsItem.ForbrugsvareRegistrering.Rows.Count < 1)
            {
                MessageBox.Show(db.GetLangString("ForbrugsvareRegistrering.NoDataToBook"));
                return;
            }

            // get initials from user
            WasteRegistrationRBAGetInitials initials = new WasteRegistrationRBAGetInitials();
            if (initials.ShowDialog(this) == DialogResult.OK)
            {
                // book
                string errmsg;
                if (!dsItem.ForbrugsvareRegistrering.Book(out errmsg, initials.Initials, OpenDay))
                {
                    MessageBox.Show(errmsg);
                    return;
                }
                else
                {
                    MessageBox.Show(db.GetLangString("ForbrugsvareRegistrering.Booked"));
                    Close();
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

        private void ForbrugsvareRegistrering_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != colLookupVare.Index) return;
            if (bindingForbrugsvareRegistrering.Current == null) return;
            DataRow row = (bindingForbrugsvareRegistrering.Current as DataRowView).Row;
            int LevNr = tools.object2int(row["LevNr"]);
            double Varenummer = tools.object2double(row["Varenummer"]);
            ForbrugsvareSearch search = new ForbrugsvareSearch();
            search.PreSelectVareUnfiltered(LevNr, Varenummer);
            if (search.ShowDialog(this) == DialogResult.OK)
            {                
                row["LevNr"] = search.SelectedLevNr;
                row["Varenummer"] = search.SelectedVarenummer;

                // jump to amount column
                for (int i = 0; i < 6; i++)
                    SendKeys.Send("{TAB}");
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

            if (bindingForbrugsvareRegistrering.Current == null)
                return;
            DataRow row = (bindingForbrugsvareRegistrering.Current as DataRowView).Row;

            // if some input values are missing, delete the row
            if (tools.IsNullOrDBNull(row["Varenummer"]) ||
                tools.IsNullOrDBNull(row["Barcode"]) ||
                tools.IsNullOrDBNull(row["Antal"]))
            {
                bindingForbrugsvareRegistrering.RemoveCurrent();
                return;
            }

            // validate Varenummer
            if (tools.IsNullOrDBNull(row["Varenummer"]))
            {
                MessageBox.Show(db.GetLangString("ForbrugsvareRegistrering.msgIndtastVarenummer"));
                e.Cancel = true;
                return;
            }
            else
            {
                double Varenummer = tools.object2double(row["Varenummer"]);
                if (ItemDataSet.ForbrugsvareDataTable.GetNumRecordsByVarenummer(Varenummer) <= 0)
                {
                    MessageBox.Show(db.GetLangString("ForbrugsvareRegistrering.msgNoItemWithThatNumber"));
                    e.Cancel = true;
                    return;
                }
            }

            // validate Barcode
            if (tools.IsNullOrDBNull(row["Barcode"]))
            {
                MessageBox.Show(db.GetLangString("ForbrugsvareRegistrering.msgEnterBarcode"));
                e.Cancel = true;
                return;
            }
            else
            {
                double barcode = tools.object2double(row["Barcode"]);
                if (ItemDataSet.ForbrugsvareDataTable.GetNumRecordsByBarcode(barcode) <= 0)
                {
                    MessageBox.Show(db.GetLangString("ForbrugsvareRegistrering.msgNoItemWithThatBarcode"));
                    e.Cancel = true;
                    return;
                }
            }

            // validate antal
            if (tools.object2int(row["Antal"]) <= 0)
            {
                MessageBox.Show(db.GetLangString("ForbrugsvareRegistrering.msgNumOfNotBelow0"));
                e.Cancel = true;
                return;
            }
            else if (tools.object2int(row["Antal"]) > 999)
            {
                MessageBox.Show(db.GetLangString("ForbrugsvareRegistrering.msgNumMax999"));
                e.Cancel = true;
                return;
            }

            // validate salgspris
            if (tools.object2double(row["Salgspris"]) <= 0)
            {
                MessageBox.Show(db.GetLangString("ForbrugsvareRegistrering.msgSalgsprisInvalid"));
                e.Cancel = true;
                return;
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