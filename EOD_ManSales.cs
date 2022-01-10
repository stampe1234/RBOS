using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class EOD_ManSales : Form
    {
        private DateTime BookDate;
        private int TransType = (int)TransTypeSales.ManualSales;

        public EOD_ManSales(DateTime BookDate)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.BookDate = BookDate;
        }

        private void EOD_ManSales_Load(object sender, EventArgs e)
        {
            adapterLookupGLCodes.Connection = db.Connection;
            adapterLookupGLCodes.Fill(dsEOD.LookupGLCodes);

            adapterEODSales.Connection = db.Connection;
            adapterEODSales.Fill(dsEOD.EOD_Sales, BookDate, TransType);

            this.Text = db.GetLangString("EODManSalesForm.HeaderLbl");

            colSubCategory.DisplayIndex = 0;
            colSelectSubCat.DisplayIndex = 1;
            colSubCatDescription.DisplayIndex = 2;
            colGLCode.DisplayIndex = 3;
            colNumberOf.DisplayIndex = 4;
            colAmount.DisplayIndex = 5;

            colSubCategory.HeaderText = db.GetLangString("EODManSalesForm.SubCatLbl");
            colSubCatDescription.HeaderText = db.GetLangString("EODManSalesForm.SubCatNameLbl");
            colGLCode.HeaderText = db.GetLangString("EODManSalesForm.GLCodeLbl");
            colNumberOf.HeaderText = db.GetLangString("EODManSalesForm.NumberOfLbl");
            colAmount.HeaderText = db.GetLangString("EODManSalesForm.AmountLbl");

            btnCancel.Text = db.GetLangString("Application.Cancel");
            btnSaveClose.Text = db.GetLangString("Application.SaveClose");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            // save data and return ok when closing
            bindingEODSales.EndEdit();
            adapterEODSales.Update(dsEOD.EOD_Sales);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (bindingEODSales.Current == null) return;
            DataRowView row = (DataRowView)bindingEODSales.Current;

            // write key values
            if (tools.IsNullOrDBNull(row["LineNo"]))
            {
                row["BookDate"] = BookDate;
                row["LineNo"] = dsEOD.EOD_Sales.GetNextLineNo();
                row["TransType"] = TransType;
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // render colSelectSubCat button image
            ImageButtonRender.OnCellPainting(e, colSelectSubCat.Index, ImageButtonRender.Images.LookupForm);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(bindingEODSales.Current == null) return;
            DataRowView row = (DataRowView)bindingEODSales.Current;

            // if user clicks on the select subcat column button
            if (e.ColumnIndex == colSelectSubCat.Index)
            {
                // open the subcategory popup and let user select a subcategory
                SubCategoryPopup subcat = new SubCategoryPopup();
                subcat.SelectedSubCategoryID = row["SubCategory"].ToString();
                if (subcat.ShowDialog() == DialogResult.OK)
                {
                    row["SubCategory"] = subcat.SelectedSubCategoryID;
                    row["SubCatDesc"] = subcat.SelectedSubCategoryDesc;
                    // if no value has been selected in
                    // NumberOf field set it to default 1
                    if (tools.IsNullOrDBNull(row["NumberOf"]))
                        row["NumberOf"] = 1;
                    dataGridView1.Refresh();

                    // attempt to select the Amount column
                    try { dataGridView1.CurrentCell = dataGridView1[colAmount.Index, e.RowIndex]; }
                    catch { }
                }
            }
        }

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (bindingEODSales.Current == null) return;
            DataRowView row = (DataRowView)bindingEODSales.Current;

            // validate that NumberOf and Amount columns has been filled in
            if (tools.IsNullOrDBNull(row["NumberOf"]) || tools.IsNullOrDBNull(row["Amount"]))
                bindingEODSales.CancelEdit();
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (bindingEODSales.Current == null) return;
            DataRowView row = (DataRowView)bindingEODSales.Current;

            // check that SubCategory has been filled in before allowing editing NumberOf and Amount
            if (tools.IsNullOrDBNull(row["SubCategory"]))
            {
                MessageBox.Show(db.GetLangString("EOD_ManSales.SelectSubCategoryFirst"));
                e.Cancel = true;
            }
        }
    }
}