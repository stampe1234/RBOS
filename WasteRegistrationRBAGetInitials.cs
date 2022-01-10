using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class WasteRegistrationRBAGetInitials : Form
    {
        public WasteRegistrationRBAGetInitials()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        private void Accept()
        {
            if (txtEnterInitials.Text == "")
            {
                MessageBox.Show(db.GetLangString("WasteRegistrationRBAGetInitials.InitialsMissing"));
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        public string Initials
        {
            get { return txtEnterInitials.Text; }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Accept();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void WasteRegistrationRBAGetInitials_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
            else if (e.KeyCode == Keys.Enter)
                Accept();
        }

        private void WasteRegistrationRBAGetInitials_Load(object sender, EventArgs e)
        {
            // localization
            lbEnterInitials.Text = db.GetLangString("WasteRegistrationRBAGetInitials.lbInitials");
            btnOk.Text = db.GetLangString("Application.Ok");
            btnCancel.Text = db.GetLangString("Application.Cancel");
        }
    }
}