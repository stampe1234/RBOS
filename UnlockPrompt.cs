using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    /// <summary>
    /// The purpose of this form is to show the user that a multiuser has requested an unlock of the database.
    /// </summary>

    public partial class UnlockPrompt : Form
    {
        private System.Timers.Timer timer = null;
        private string basicTimerText = "";
        private int counter = 15;

        public UnlockPrompt()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.No;

            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.AutoReset = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }

        #region AutoClosingRBOS
        private static bool _AutoClosingRBOS = false;
        /// <summary>
        /// This tells whether RBOS in going to close automatically
        /// because a multiuser unlock request has not been responded
        /// to with in the given amount of time.
        /// </summary>
        public static bool AutoClosingRBOS
        {
            get { return _AutoClosingRBOS; }
        }
        #endregion

        private void CloseWithYes()
        {
            this.DialogResult = DialogResult.Yes;
            if (!AutoClosingRBOS)
            {
                /// if AutoClosingRBOS = true that means
                /// this happens from another thread
                /// so do NOT close the form as we 
                /// have another thread in MainForm that
                /// does this.

                Close();
            }
        }

        private void CloseWithNo()
        {
            this.DialogResult = DialogResult.No;
            Close();
        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // check if user has closed form
            if (!this.Created)
                return;

            timer.Enabled = false;
            lbSeconds.Invoke(new MethodInvoker(delegate
            {
                lbSeconds.Text = string.Format(basicTimerText, --counter);
            }));

            if (counter <= 0)
            {
                _AutoClosingRBOS = true;
                CloseWithYes();
            }
            else
            {
                timer.Enabled = true;
            }
        }

        private void UserLogonUnlockPrompt_Load(object sender, EventArgs e)
        {
            // get the SQL login name of the multiuser that has requested the login
            string MultiUserLoginName = UserLogon.UnlockRequetedBy();

            // localization
            lbMessage.Text = string.Format(dbOleDb.GetLangString("UserLogonUnlockPrompt.lbMessage"), MultiUserLoginName);
            basicTimerText = dbOleDb.GetLangString("UserLogonUnlockPrompt.lbSeconds");
            lbSeconds.Text = string.Format(basicTimerText, 15);
            btnYes.Text = dbOleDb.GetLangString("Application.Yes");
            btnNo.Text = dbOleDb.GetLangString("Application.No");
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            CloseWithYes();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            CloseWithNo();
        }
    }
}