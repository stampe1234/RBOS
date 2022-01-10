using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class EOD_ManualCards : Form
    {
        private DateTime BookDate;

        public EOD_ManualCards(DateTime BookDate)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.BookDate = BookDate;
        }

        private void EOD_ManualCards_Load(object sender, EventArgs e)
        {
            adapterManualCards.Connection = db.Connection;
            adapterManualCards.Fill(dsEOD.EOD_ManualCards, BookDate);

            this.Text = db.GetLangString("EODManualCardsForm.HeaderLbl");

            colDescription.DisplayIndex = 0;
            colAmount.DisplayIndex = 1;

            colDescription.HeaderText = db.GetLangString("EODManualCardsForm.DescriptionLbl");
            colAmount.HeaderText = db.GetLangString("EODManualCardsForm.AmountLbl");
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
            bindingManualCards.EndEdit();
            adapterManualCards.Update(dsEOD.EOD_ManualCards);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (bindingManualCards.Current == null) return;
            DataRowView row = (DataRowView)bindingManualCards.Current;

            // write key values
            if (tools.IsNullOrDBNull(row["LineNo"]))
            {
                row["BookDate"] = BookDate;
                row["LineNo"] = dsEOD.EOD_ManualCards.GetNextLineNo();
            }
        }
    }
}