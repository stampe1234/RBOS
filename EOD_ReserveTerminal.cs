using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class EOD_ReserveTerminal : Form
    {
        private DateTime BookDate;

        public EOD_ReserveTerminal(DateTime BookDate)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.BookDate = BookDate;
        }

        private void EOD_ReserveTerminal_Load(object sender, EventArgs e)
        {
            adapterReserveTerminal.Connection = db.Connection;
            adapterReserveTerminal.Fill(dsEOD.EOD_ReserveTerminal, BookDate);

            this.Text = db.GetLangString("EODReserveTerminalForm.HeaderLbl");

            colDescription.DisplayIndex = 0;
            colAmount.DisplayIndex = 1;

            colDescription.HeaderText = db.GetLangString("EODReserveTerminalForm.DescriptionLbl");
            colAmount.HeaderText = db.GetLangString("EODReserveTerminalForm.AmountLbl");
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
            bindingReserveTerminal.EndEdit();
            adapterReserveTerminal.Update(dsEOD.EOD_ReserveTerminal);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (bindingReserveTerminal.Current == null) return;
            DataRowView row = (DataRowView)bindingReserveTerminal.Current;

            // write key values
            if (tools.IsNullOrDBNull(row["LineNo"]))
            {
                row["BookDate"] = BookDate;
                row["LineNo"] = dsEOD.EOD_ReserveTerminal.GetNextLineNo();
            }
        }
    }
}