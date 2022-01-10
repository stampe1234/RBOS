using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class DepositMissing : Form
    {
        private bool OkToClose = false;

        #region ShowAlwaysAssumeYesCheckBox property
        private static bool _ShowAlwaysAssumeYesCheckBox = false;
        /// <summary>
        /// Toggles visibility of "Always assume yes checkbox"
        /// when the form is created. Must be set before calling the constructor.
        /// It is important that the value is set back to
        /// false after using it in for instance a loop, as
        /// the item form otherwise would display it when calling
        /// this in ordinary use of item form.
        /// </summary>
        public static bool ShowAlwaysAssumeYesCheckBox
        {
            set { _ShowAlwaysAssumeYesCheckBox = value; }
        }
        #endregion

        private static bool _AlwaysAssumeYes = false;
        public static bool AlwaysAssumeYes
        {
            set { _AlwaysAssumeYes = value; }
            get { return _AlwaysAssumeYes; }
        }

        public DepositMissing()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
            
            // setup checkbox
            chkAlwaysAssumeYes.Visible = _ShowAlwaysAssumeYesCheckBox;
            Height = (_ShowAlwaysAssumeYesCheckBox ? 140 : 111);

            // localization
            lbText.Text = db.GetLangString("DepositMissing.ItemNeedsDepositSaveAnyway");
            btnYes.Text = db.GetLangString("Application.Yes");
            btnNo.Text = db.GetLangString("Application.No");
            chkAlwaysAssumeYes.Text = db.GetLangString("DepotMissing.chkAlwaysAssumeYes");
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            OkToClose = true;
            DialogResult = DialogResult.No;
            Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            OkToClose = true;
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void DepositMissing_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!OkToClose)
            {
                MessageBox.Show(db.GetLangString("Application.UseCloseButton"));
                e.Cancel = true;
            }

            // save whether user has chosen to not be asked about this again
            // (this is not saved in db, programmer has to set it before/after needed)
            AlwaysAssumeYes = ((DialogResult == DialogResult.Yes) && chkAlwaysAssumeYes.Checked);
        }        
    }
}