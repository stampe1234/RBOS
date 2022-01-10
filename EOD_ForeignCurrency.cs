using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class EOD_ForeignCurrency : Form
    {
        private DateTime BookDate;

        public EOD_ForeignCurrency(DateTime BookDate)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.BookDate = BookDate;
        }

        private void EOD_ForeignCurrency_Load(object sender, EventArgs e)
        {
            adapterForeignCurrency.Connection = db.Connection;
            adapterForeignCurrency.Fill(dsEOD.EOD_ForeignCurrency, BookDate);

            this.Text = db.GetLangString("EODForeignCurrencyForm.HeaderLbl");

            colDescription.DisplayIndex = 0;
            colAmount.DisplayIndex = 1;

            colDescription.HeaderText = db.GetLangString("EODForeignCurrencyForm.DescriptionLbl");
            colAmount.HeaderText = db.GetLangString("EODForeignCurrencyForm.AmountLbl");
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
            bindingForeignCurrency.EndEdit();
            adapterForeignCurrency.Update(dsEOD.EOD_ForeignCurrency);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (bindingForeignCurrency.Current == null) return;
            DataRowView row = (DataRowView)bindingForeignCurrency.Current;

            // write key values
            if (tools.IsNullOrDBNull(row["LineNo"]))
            {
                row["BookDate"] = BookDate;
                row["LineNo"] = dsEOD.EOD_ForeignCurrency.GetNextLineNo();
            }
        }
    }
}