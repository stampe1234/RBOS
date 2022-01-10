using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class EOD_BankCards : Form
    {
        private DateTime BookDate;
        private bool EditEnabled = false;

        public EOD_BankCards(DateTime BookDate)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.BookDate = BookDate;

            EditEnabled = db.GetConfigStringAsBool("EOD.BankCards.DETAIL.UnlockFields");

            colDescription.DisplayIndex = 0;
            colAmount.DisplayIndex = 1;

            btnSave.Visible = EditEnabled;
            dataGridView1.AllowUserToAddRows = EditEnabled;
            dataGridView1.AllowUserToDeleteRows = EditEnabled;
            dataGridView1.ReadOnly = !EditEnabled;
        }

        private void SaveData()
        {
            dataGridView1.EndEdit();
            bindingBankCards.EndEdit();
            adapterBankCards.Update(dsEOD.EOD_BankCards);
        }

        private void LoadData()
        {

            string test = db.Connection.ToString();
            adapterBankCards.Connection = db.Connection;
            adapterBankCards.Fill(dsEOD.EOD_BankCards, BookDate);

            // localization
            this.Text = db.GetLangString("EODBankCardForm.HeaderLbl");
            colDescription.HeaderText = db.GetLangString("EODBankCardForm.DescriptionLbl");
            colAmount.HeaderText = db.GetLangString("EODBankCardForm.AmountLbl");
            btnClose.Text = EditEnabled ? db.GetLangString("Application.Cancel") : db.GetLangString("Application.Close");
            btnSave.Text = db.GetLangString("Application.SaveClose");
        }

        private void EOD_BankCards_Load(object sender, EventArgs e)
        {
            LoadData();
            

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           //SaveData();
           // Close();
            dataGridView1.EndEdit();
            bindingBankCards.EndEdit();
            adapterBankCards.Update(dsEOD.EOD_BankCards);            
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (bindingBankCards.Current == null) return;
            DataRowView row = (DataRowView)bindingBankCards.Current;

            // write key values
            if (tools.IsNullOrDBNull(row["LineNo"]))
            {
                row["BookDate"] = BookDate;               
                row["LineNo"] = dsEOD.EOD_BankCards.GetNextLineNo();
            }
        }
    }
}