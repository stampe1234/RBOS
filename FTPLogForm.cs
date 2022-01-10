using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class FTPLogForm : Form
    {
        public FTPLogForm(Form Owner)
        {
            InitializeComponent();

            this.Owner = Owner;
            this.Text = db.GetLangString("FTPLogForm.Title");
            btnClose.Text = db.GetLangString("Application.Close");
            StartLog();
        }

        public void StartLog()
        {
            btnClose.Enabled = false;
            output.Text = "";
            this.Visible = false;
            this.Show(Owner);
            this.Refresh();
        }

        public void EndLog()
        {
            btnClose.Enabled = true;
        }

        public string Message
        {
            set
            {
                output.Text += value + "\n";
                output.Refresh();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}