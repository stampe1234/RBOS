using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            txtVersion.Text = Version.ExeVersion;
            if ((Version.ExePatch != "") && (Version.ExePatch != "0"))
                txtVersion.Text = txtVersion.Text + " #" + Version.ExePatch;
            txtUser.Text = UserLogon.Username;
            lbUser.Text = db.GetLangString("About.User");
			lbCopyright.Text = string.Format(lbCopyright.Text, DateTime.Now.Year);
#if RBA
            lbRBOSApplName.Text = lbRBOSApplName.Text + " RBA";
#endif
#if FSD
            lbRBOSApplName.Text = lbRBOSApplName.Text + " BFI";
#endif
#if DETAIL
            lbRBOSApplName.Text = lbRBOSApplName.Text + " DETAIL";
#endif
        }

        private void About_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}