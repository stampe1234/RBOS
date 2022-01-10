using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class EOD_Discounts : Form
    {
        private DateTime BookDate;

        public EOD_Discounts(DateTime BookDate)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.BookDate = BookDate;
        }

        private void EOD_Discounts_Load(object sender, EventArgs e)
        {
            adapterDiscounts.Connection = db.Connection;
            adapterDiscounts.Fill(dsEOD.EOD_Discounts, BookDate);

            this.Text = db.GetLangString("EOD_Discounts.Title");

            colDescription.DisplayIndex = 0;
            colAmount.DisplayIndex = 1;

            colDescription.HeaderText = db.GetLangString("EOD_Discounts.Description");
            colAmount.HeaderText = db.GetLangString("EOD_Discounts.Amount");
            btnClose.Text = db.GetLangString("Application.Close");
        }
       
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}