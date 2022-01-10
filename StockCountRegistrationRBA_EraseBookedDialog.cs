using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class StockCountRegistrationRBA_EraseBookedDialog : Form
    {
        public StockCountRegistrationRBA_EraseBookedDialog()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private void StockCountRegistrationRBA_EraseBookedDialog_Load(object sender, EventArgs e)
        {
            lbText.Text = db.GetLangString("StockCountRegRBA_EraseBookedDialog.EraseBooked");
            btnCancel.Text = db.GetLangString("Application.Cancel");
            btnDelete.Text = db.GetLangString("StockCountRegRBA_EraseBookedDialog.Erase");
            btnAdd.Text = db.GetLangString("StockCountRegRBA_EraseBookedDialog.Add");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            db.SetConfigString("StockCountRegistrationRBA.EraseBooked", true);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            db.SetConfigString("StockCountRegistrationRBA.EraseBooked", false);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}