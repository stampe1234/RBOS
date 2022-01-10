using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class EOD_BankDep : Form
    {
        private DateTime BookDate;

        public EOD_BankDep(DateTime BookDate)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.BookDate = BookDate;
        }

        private void EOD_BankDep_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eODDS1.EOD_BankDep' table. You can move, or remove it, as needed.
            eOD_BankDepTableAdapter.Connection = db.Connection;
            eOD_BankDepTableAdapter.Fill(dsEOD.EOD_BankDep, BookDate);
           // adapterBankDep.Connection = db.Connection;
            //adapterBankDep.Fill(dsDS1.EOD_BankDep, BookDate);
           // adapterBankDep.Fill( dsEOD.EOD_BankDep, BookDate);
            this.Text = db.GetLangString("EODBankDepForm.HeaderLbl");

            colDescription.DisplayIndex = 0;
            colAmount.DisplayIndex = 1;

            colDescription.HeaderText = db.GetLangString("EODBankDepForm.DescriptionLbl");
            colAmount.HeaderText = db.GetLangString("EODBankDepForm.AmountLbl");
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
            
            petertest.EndEdit();
            eOD_BankDepTableAdapter.Update(dsEOD.EOD_BankDep);
            this.DialogResult = DialogResult.OK;
            Close();
            
            
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (petertest.Current == null) return;
            DataRowView row = (DataRowView)petertest.Current;

            // write key values
            if (tools.IsNullOrDBNull(row["LineNo"]))
            {
                row["BookDate"] = BookDate;
                row["LineNo"] =  dsEOD.EOD_BankDep.GetNextLineNo();
            }
        }

        private void drS_DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (petertest.Current == null) return;
            DataRowView row = (DataRowView)petertest.Current;

            // write key values
            if (tools.IsNullOrDBNull(row["LineNo"]))
            {
                row["BookDate"] = BookDate;
                row["LineNo"] = dsEOD.EOD_BankDep.GetNextLineNo();
            }
        }
    }
}