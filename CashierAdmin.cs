using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class CashierAdmin : Form
    {
        public CashierAdmin()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            adapterCashier.Connection = db.Connection;
            adapterCashier.Fill(dsEOD.Cashier);

            // localization
            Text = db.GetLangString("CashierAdmin.Title");
            btnSaveAndClose.Text = db.GetLangString("Application.SaveClose");
            colCashierID.HeaderText = db.GetLangString("CashierAdmin.colCashierID");
            colNavn.HeaderText = db.GetLangString("CashierAdmin.colNavn");
        }

        private void SaveData()
        {
            grid.EndEdit();
            bindingCashier.EndEdit();
            adapterCashier.Update(dsEOD.Cashier);
        }

        private void CashierAdmin_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CashierAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
        }
    }
}