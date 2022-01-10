using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class EOD_PromptFirstDate : Form
    {
        public EOD_PromptFirstDate()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;

            // localization
            this.Text = db.GetLangString("EODPromptFirstDateForm.Title");
            btnOk.Text = db.GetLangString("Application.Ok");
            btnCancel.Text = db.GetLangString("Application.Cancel");
            lbTextTitle.Text = db.GetLangString("EODPromptFirstDateForm.TextTitle");
            lbText.Text = db.GetLangString("EODPromptFirstDateForm.Text");
        }

        public DateTime SelectedBookDate
        {
            get { return comboDate.Value.Date; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = string.Format(
                db.GetLangString("EODPromptFirstDateForm.ConfirmSelectedDate"),
                comboDate.Value.ToString("dd-MM-yyyy"));
            if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}