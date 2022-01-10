using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class EOD_ShellCards : Form
    {
        private DateTime BookDate;

        public EOD_ShellCards(DateTime BookDate)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.BookDate = BookDate;
        }

        private void EOD_ShellCards_Load(object sender, EventArgs e)
        {
// TODO: This line of code loads data into the 'eoddS11.EOD_BankDep' table. You can move, or remove it, as needed.
            adapterShellCards.Connection = db.Connection;

           // dsEOD_ShellCardsTableAdapter.Connection= db.Connection;
           
            //dsEOD.EOD_ShellCards.s.s_ShellCardsTableAdapter.Fill(dsEOD.EOD_ShellCards,BookDate);
            adapterShellCards.Fill(dsEOD.EOD_ShellCards, BookDate);   
           
            this.Text = db.GetLangString("EODShellCardForm.HeaderLbl");

            colDescription.DisplayIndex = 0;
            colAmount.DisplayIndex = 1;

            colDescription.HeaderText = db.GetLangString("EODShellCardForm.DescriptionLbl");
            colAmount.HeaderText = db.GetLangString("EODShellCardForm.AmountLbl");
            btnClose.Text = db.GetLangString("Application.Close");
            
        }
       
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}