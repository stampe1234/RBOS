using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class EOD_POSSales : Form
    {
        private DateTime BookDate;
        private int TransType = (int)TransTypeSales.POSSales;

        public EOD_POSSales(DateTime BookDate)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.BookDate = BookDate;
        }

        private void EOD_POSSales_Load(object sender, EventArgs e)
        {
            adapterLookupGLCodes.Connection = db.Connection;
            adapterLookupGLCodes.Fill(dsEOD.LookupGLCodes);

            adapterEODSales.Connection = db.Connection;
            adapterEODSales.Fill(dsEOD.EOD_Sales, BookDate, TransType);

#if DETAIL
            this.Text = db.GetLangString("EODPOSSalesForm.HeaderLbl.DETAIL");
#else
            this.Text = db.GetLangString("EODPOSSalesForm.HeaderLbl");
#endif

            colSubCategory.DisplayIndex = 0;
            colSubCatDescription.DisplayIndex = 1;
            colGLCode.DisplayIndex = 2;
            colNumberOf.DisplayIndex = 3;
            colAmount.DisplayIndex = 4;

#if DETAIL
            colNumberOf.Visible = false;
#endif

            colSubCategory.HeaderText = db.GetLangString("EODPOSSalesForm.SubCatLbl");
            colSubCatDescription.HeaderText = db.GetLangString("EODPOSSalesForm.SubCatNameLbl");
            colGLCode.HeaderText = db.GetLangString("EODPOSSalesForm.GLCodeLbl");
            colNumberOf.HeaderText = db.GetLangString("EODPOSSalesForm.NumberOfLbl");
            colAmount.HeaderText = db.GetLangString("EODPOSSalesForm.AmountLbl");

            btnClose.Text = db.GetLangString("Application.Close");

            // sort the grid by the SubCategory column
            // (can't be done in the SQL as it is being usd
            // for manual sales too, which may not be sorted)
            dataGridView1.Sort(colSubCategory, ListSortDirection.Ascending);
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

        

       
    }
}