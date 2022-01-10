using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace RBOS
{
    public partial class FTPAccountsForm : Form
    {
        private Modes CurrentMode = Modes.Browse;

        #region Constructor
        public FTPAccountsForm()
        {
            InitializeComponent();

            // fill and localize the TransferType combobox, then select Ascii as default.
            // NOTE: this must be done before loading data for table dsAdmin.LookupFTPAccounts,
            // as doing it after, will mess with the selected FTP Account's TransferType.
            comboTransferType.Items.Add("Ascii");
            comboTransferType.Items.Add(db.GetLangString("FTPAccountsForm.Binary"));
            comboTransferType.SelectedIndex = 0;

            // set connections
            adapterFTPAccounts.Connection = db.Connection;
            adapterLookupFTPAccounts.Connection = db.Connection;

            // load FTPAccounts lookup data
            adapterLookupFTPAccounts.Fill(dsAdmin.LookupFTPAccounts);

            // localization
            btnClose.Text = db.GetLangString("Application.Close");
            btnEdit.Text = db.GetLangString("Application.Edit");
            btnNew.Text = db.GetLangString("Application.New");
            btnDelete.Text = db.GetLangString("Application.Delete");
            btnCancel.Text = db.GetLangString("Application.Cancel");
            btnSave.Text = db.GetLangString("Application.Save");
            lbAccountName.Text = db.GetLangString("FTPAccountsForm.lbAccountName");
            boxFTPAccountSettings.Text = db.GetLangString("FTPAccountsForm.boxFTPAccountSettings");
            lbHost.Text = db.GetLangString("FTPAccountsForm.lbHost");
            lbPort.Text = db.GetLangString("FTPAccountsForm.lbPort");
            lbUsername.Text = db.GetLangString("FTPAccountsForm.lbUsername");
            lbPassword.Text = db.GetLangString("FTPAccountsForm.lbPassword");
            lbTransferType.Text = db.GetLangString("FTPAccountsForm.lbTransferType");
            lbPassive.Text = db.GetLangString("FTPAccountsForm.lbPassive");
            boxProxySettings.Text = db.GetLangString("FTPAccountsForm.boxProxySettings");
            lbProxyHost.Text = db.GetLangString("FTPAccountsForm.lbProxyHost");
            lbProxyPort.Text = db.GetLangString("FTPAccountsForm.lbProxyPort");
            lbProxyUsername.Text = db.GetLangString("FTPAccountsForm.lbProxyUsername");
            lbProxyPassword.Text = db.GetLangString("FTPAccountsForm.lbProxyPassword");
            boxFileSystemSettings.Text = db.GetLangString("FTPAccountsForm.boxFileSystemSettings");
            lbClientDepartureDir.Text = db.GetLangString("FTPAccountsForm.lbClientDepartureDir");
            lbClientArrivalDir.Text = db.GetLangString("FTPAccountsForm.lbClientArrivalDir");
            lbServerDepartureDir.Text = db.GetLangString("FTPAccountsForm.lbServerDepartureDir");
            lbServerArrivalDir.Text = db.GetLangString("FTPAccountsForm.lbServerArrivalDir");
            btnTestConnection.Text = db.GetLangString("FTPAccountsForm.btnTestConnection");

            // set controls mode
            SetMode(Modes.Browse);

            // load data for the first account in the combobox
            // or clear data properly if no account is present
            LoadDataForSelectedFTPAccount();
        }
        #endregion

        #region ENUM Modes
        private enum Modes
        {
            Browse,
            Edit,
            New
        }
        #endregion

        #region METHOD: LoadDataForSelectedFTPAccount
        /// <summary>
        /// Fills in data for the selected FTP Account.
        /// If no valid account is selected, the fields are cleared.
        /// </summary>
        private void LoadDataForSelectedFTPAccount()
        {
            // load FTP Account data according to the selected FTP Account in combobox
            if (comboFTPAccounts.SelectedIndex < 0) return;
            int id = tools.object2int(comboFTPAccounts.SelectedValue);
            adapterFTPAccounts.Fill(dsAdmin.FTPAccounts, id);
        }
        #endregion

        #region METHOD: ClearData
        /// <summary>
        /// Clears all fields of data.
        /// </summary>
        private void ClearData()
        {
            txtAccountName.Text = "";
            txtHost.Text = "";
            txtPort.Text = "21";
            txtUsername.Text = "";
            txtPassword.Text = "";
            chkPassive.Checked = true;
            if (comboTransferType.Items.Count > 0)
                comboTransferType.SelectedIndex = 0;
            txtProxyHost.Text = "";
            txtProxyPort.Text = "";
            txtProxyUsername.Text = "";
            txtProxyPassword.Text = "";
            txtClientArrivalDir.Text = "";
            txtClientDepartureDir.Text = "";
            txtServerArrivalDir.Text = "";
            txtServerDepartureDir.Text = "";
        }
        #endregion

        #region METHOD: SetMode
        /// <summary>
        /// Sets the GUI in the given mode.
        /// </summary>
        private void SetMode(Modes mode)
        {
            CurrentMode = mode;

            // toggle controls on/off
            txtHost.ReadOnly = (mode == Modes.Browse);
            txtPort.ReadOnly = (mode == Modes.Browse);
            txtUsername.ReadOnly = (mode == Modes.Browse);
            txtPassword.ReadOnly = (mode == Modes.Browse);
            chkPassive.Enabled = (mode != Modes.Browse);
            comboTransferType.Enabled = (mode != Modes.Browse);
            txtProxyHost.ReadOnly = (mode == Modes.Browse);
            txtProxyPort.ReadOnly = (mode == Modes.Browse);
            txtProxyUsername.ReadOnly = (mode == Modes.Browse);
            txtProxyPassword.ReadOnly = (mode == Modes.Browse);
            txtClientArrivalDir.ReadOnly = (mode == Modes.Browse);
            txtClientDepartureDir.ReadOnly = (mode == Modes.Browse);
            txtServerArrivalDir.ReadOnly = (mode == Modes.Browse);
            txtServerDepartureDir.ReadOnly = (mode == Modes.Browse);
            btnClientArrivalDir.Enabled = (mode != Modes.Browse);
            btnClientDepartureDir.Enabled = (mode != Modes.Browse);
            comboFTPAccounts.Visible = (mode == Modes.Browse);
            txtAccountName.Visible = (mode != Modes.Browse);
            btnCancel.Visible = (mode != Modes.Browse);
            btnClose.Visible = (mode == Modes.Browse);
            btnNew.Enabled = (mode == Modes.Browse);
            btnDelete.Enabled = ((mode == Modes.Browse) && (comboFTPAccounts.SelectedIndex >= 0));
            btnEdit.Enabled = ((mode == Modes.Browse) && (comboFTPAccounts.SelectedIndex >= 0));
            btnSave.Visible = (mode != Modes.Browse);
            btnTestConnection.Enabled = (mode == Modes.Browse);

            // position some now shown controls
            txtAccountName.Location = comboFTPAccounts.Location;
            btnCancel.Location = btnClose.Location;
            btnSave.Location = btnEdit.Location;
        }
        #endregion

        #region METHOD: TestConnection
        private void TestConnection()
        {
            // generate a file to be sent
            if (comboFTPAccounts.SelectedIndex < 0) return;
            FTP ftp = new FTP(tools.object2int(comboFTPAccounts.SelectedValue),(MainForm)this.MdiParent);
            ftp.TestConnection();
        }
        #endregion

        #region METHOD: ValidateFields
        private bool ValidateFields()
        {
            string msg = "";

            // check that all needed fields are filled in
            if (txtAccountName.Text == "")
                msg += db.GetLangString("FTPAccountsForm.SpecifyAccountName") + "\n";
            if (txtHost.Text == "")
                msg += db.GetLangString("FTPAccountsForm.SpecifyHost") + "\n";
            //if (txtPort.Text == "")
              //  msg += db.GetLangString("FTPAccountsForm.SpecifyPort") + "\n";
            if (txtUsername.Text == "")
                msg += db.GetLangString("FTPAccountsForm.SpecifyUsername") + "\n";
            if (txtPassword.Text == "")
                msg += db.GetLangString("FTPAccountsForm.SpecifyPassword") + "\n";
            if (txtClientDepartureDir.Text == "")
                msg += db.GetLangString("FTPAccountsForm.SpecifyClientDepartDir") + "\n";
            if (txtClientArrivalDir.Text == "")
                msg += db.GetLangString("FTPAccountsForm.SpecifyClientArriveDir") + "\n";
            if (txtServerDepartureDir.Text == "")
                msg += db.GetLangString("FTPAccountsForm.SpecifyServerDepartDir") + "\n";
            if (txtServerArrivalDir.Text == "")
                msg += db.GetLangString("FTPAccountsForm.SpecifyServerArriveDir") + "\n";

            // if AccountName has been filled and in edit-mode,
            // check that the name does not exist on another account
            if (txtAccountName.Text != "")
            {
                DataRow account = AdminDataSet.FTPAccountsDataTable.GetFTPAccount(txtAccountName.Text);
                if (account != null)
                {
                    if (tools.object2int(account["ID"]) != tools.object2int(comboFTPAccounts.SelectedValue))
                        msg += db.GetLangString("FTPAccountsForm.SpecifyNameNotUsed") + "\n";
                }
            }

            if (msg != "")
            {
                MessageBox.Show(msg);
                return false;
            }
            else
                return true;
        }
        #endregion

        // cancel button click event
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // comboFTPAccounts selected index changed event
        private void comboFTPAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataForSelectedFTPAccount();
        }

        // client departure dir button click event
        private void btnClientDepartureDir_Click(object sender, EventArgs e)
        {
            if (dialogFolderBrowser.ShowDialog(this) == DialogResult.OK)
            {
                txtClientDepartureDir.Text = dialogFolderBrowser.SelectedPath;
            }
        }

        // client arrival dir button click event
        private void btnClientArrivalDir_Click(object sender, EventArgs e)
        {
            if (dialogFolderBrowser.ShowDialog(this) == DialogResult.OK)
            {
                txtClientArrivalDir.Text = dialogFolderBrowser.SelectedPath;
            }
        }

        // edit button click event
        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetMode(Modes.Edit);
            if (txtAccountName.CanFocus)
                txtAccountName.Focus();
        }

        // cancel button click event
        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            bindingFTPAccounts.CancelEdit();
            SetMode(Modes.Browse);
        }

        // new button click event
        private void btnNew_Click(object sender, EventArgs e)
        {
            bindingFTPAccounts.AddNew();
            txtPort.Text = 21.ToString();
            SetMode(Modes.New);
        }

        // delete button click event
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string msg = db.GetLangString("FTPAccountsForm.DeleteFTPAccount");
            if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bindingFTPAccounts.RemoveCurrent();
                adapterFTPAccounts.Update(dsAdmin.FTPAccounts);
                adapterLookupFTPAccounts.Fill(dsAdmin.LookupFTPAccounts); // fill combo
                comboFTPAccounts.SelectedIndex = -1;
                SetMode(Modes.Browse);
            }
        }

        // save button click event
        private void btnSave_Click(object sender, EventArgs e)
        {
            bindingFTPAccounts.EndEdit();

            // validate fields
            if (!ValidateFields())
                return;

            // save the name as we want to position on it after reloading combobox
            string name = "";
            if (bindingFTPAccounts.Current != null)
            {
                DataRowView row = (DataRowView)bindingFTPAccounts.Current;
                name = row["AccountName"].ToString();
            }

            // save data to disk
            adapterFTPAccounts.Update(dsAdmin.FTPAccounts);

            // reload combobox and position on the account
            adapterLookupFTPAccounts.Fill(dsAdmin.LookupFTPAccounts);
            foreach (object o in comboFTPAccounts.Items)
            {
                if (o is DataRowView)
                {
                    DataRowView row = (DataRowView)o;
                    if (row["AccountName"].Equals(name))
                        comboFTPAccounts.SelectedItem = o;
                }
            }

            // set controls in browse mode
            SetMode(Modes.Browse);
        }

        // test connection button click event
        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            TestConnection();
        }

        // port textbox validating event
        private void txtPort_Validating(object sender, CancelEventArgs e)
        {
            // check for valid port number
            Regex regex = new Regex("^([0-9]+)$");
            if (regex.Match(txtPort.Text).Success == false)
            {
                MessageBox.Show(db.GetLangString("FTPAccountsForm.SpecifyValidPort"));
                e.Cancel = true;
            }
        }

        private void FTPAccountsForm_Activated(object sender, EventArgs e)
        {
            
        }
    }
}