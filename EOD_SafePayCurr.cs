using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class EOD_SafePayCurr : Form
    {
        
        private DateTime BookDate;

        public EOD_SafePayCurr(DateTime BookDate)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.BookDate = BookDate;
        }

        private void EOD_SafePayCurr_Load(object sender, EventArgs e)
        {
            //AdapterSafePayCurr.Connection = db.Connection;
            //AdapterSafePayCurr.Fill(dsEOD.EOD_SafePay_Currencies, BookDate);

            AdapterSafePay_Depotbeholdning.Connection = db.Connection;
            AdapterSafePay_Depotbeholdning.FillBy(dsEOD.EOD_SafePay_Depotbeholdning, BookDate);
            this.Text = db.GetLangString("SafePayCurrForm.HeaderLbl");

            colDescription.DisplayIndex = 0;
            ColChangeValuta.DisplayIndex = 1;

            colDescription.HeaderText = "Valuta";// db.GetLangString("EODBankDepForm.DescriptionLbl");
            ColChangeValuta.HeaderText = "Beløb i valuta";// db.GetLangString("EODBankDepForm.AmountLbl");
            
            
            this.ActiveControl = btnClose;

            this.dataGridView1.Enabled = false;

        }
                          
        

      

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
      
    }
}