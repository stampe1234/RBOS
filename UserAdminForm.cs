using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace RBOS
{
    public partial class UserAdminForm : Form
    {
        #region Private variables

        private FormState CurrentFormState = FormState.View;
        private int SelectedUserIndexBeforeNew = -1;

        #endregion

        #region FormState enum
        private enum FormState
        {
            New,
            Edit,
            View
        }
        #endregion

        #region Constructor
        public UserAdminForm()
        {
            InitializeComponent();
        }
        #endregion

        #region LoadData
        private void LoadData()
        {
            adapterUsers.Connection = db.Connection;
            adapterUsers.Fill(dsAdmin.Users);

            adapterUserProfiles.Connection = db.Connection;
            adapterUserProfiles.Fill(dsAdmin.UserProfiles);
        }
        #endregion

        #region SetFormState
        private void SetFormState(FormState state)
        {
            // save state
            CurrentFormState = state;

            // set controls' state
            btnNew.Enabled = (state == FormState.View);
            btnEdit.Enabled = (state == FormState.View);
            btnCancel.Visible = (state != FormState.View);
            btnClose.Visible = (state == FormState.View);
            btnSave.Visible = (state != FormState.View);
            btnDelete.Visible = (state == FormState.View);
            comboUsers.Enabled = (state == FormState.View);
            txtUsername.ReadOnly = (state == FormState.View);
            comboProfile.Enabled = (state != FormState.View);
            txtPassword.ReadOnly = (state == FormState.View);
            btnShowPassword.Enabled = (state == FormState.Edit);
            txtPasswordDecrypted.Visible = (state == FormState.New);
            txtPassword.Visible = (state != FormState.New);
            
            // position invisible buttons
            btnCancel.Location = btnClose.Location;
            btnSave.Location = btnDelete.Location;
            txtPasswordDecrypted.Location = txtPassword.Location;

            // when entering edit mode, get the decrypted password,
            // otherwise remove the decrypted password
            if (state == FormState.Edit)
                txtPasswordDecrypted.Text = Encryption.DecryptString(txtPassword.Text);
            else
                txtPasswordDecrypted.Text = "";
        }
        #endregion

        #region AddNewUser
        private void AddNewUser()
        {
            // Keep selected index of user in combo for restoring if cancelling.
            // NOTE: this must be done before calling AddNew on the binder.
            SelectedUserIndexBeforeNew = comboUsers.SelectedIndex;

            bindingUsers.AddNew();
            SetFormState(FormState.New);
        }
        #endregion

        #region CancelEditOrNew
        private void CancelEditOrNew()
        {
            bindingUsers.CancelEdit();

            // if cancelling a new user, restore
            // the user that was selected in the
            // combobox before clicking the new button.
            // NOTE: this must be done before calling SetFormState
            // and after cancelling edit on the binder.
            if (CurrentFormState == FormState.New)
            {
                if (SelectedUserIndexBeforeNew < comboUsers.Items.Count)
                    comboUsers.SelectedIndex = SelectedUserIndexBeforeNew;
                SelectedUserIndexBeforeNew = -1;
            }

            SetFormState(FormState.View);
        }
        #endregion

        #region EditUser
        private void EditCurrentUser()
        {
            SetFormState(FormState.Edit);
        }
        #endregion

        #region SaveCurrentUser
        private void SaveCurrentUser()
        {
            // check for empty username
            if (txtUsername.Text == "")
            {
                MessageBox.Show(db.GetLangString("UserAdminForm.FillInUsername"));
                return;
            }

            // check for valid username
            if (!AdminDataSet.UsersDataTable.ValidUsernameOrPassword(txtUsername.Text))
            {
                MessageBox.Show(db.GetLangString("UserAdminForm.UsernameValidChars"));
                return;
            }

            // check for already existing username
            if (CurrentFormState == FormState.New)
            {
                if (dsAdmin.Users.UsernameAlreadyExists(txtUsername.Text))
                {
                    MessageBox.Show(db.GetLangString("UserAdminForm.UsernameAlreadyInUse"));
                    return;
                }
            }
            
            // check for empty unencrypted password
            if (txtPasswordDecrypted.Text == "")
            {
                MessageBox.Show(db.GetLangString("UserAdminForm.FillInPassword"));
                return;
            }

            // check for valid unencrypted password
            if (!AdminDataSet.UsersDataTable.ValidUsernameOrPassword(txtPasswordDecrypted.Text))
            {
                MessageBox.Show(db.GetLangString("UserAdminForm.PasswordValidChars"));
                return;
            }

            // check for empty profile
            if (comboProfile.SelectedIndex < 0)
            {
                MessageBox.Show(db.GetLangString("UserAdminForm.SelectUserProfile"));
                return;
            }

            // encrypt and save password
            txtPassword.Text = Encryption.EncryptString(txtPasswordDecrypted.Text);

            // all above checks should be done before EndEdit,
            // especially username, as it is the primary key.

            // save data
            bindingUsers.EndEdit();
            adapterUsers.Update(dsAdmin.Users);
            SetFormState(FormState.View);
        }
        #endregion

        #region DeleteCurrentUser
        private void DeleteCurrentUser()
        {
            // first check that this is not the last admin
            if (tools.object2int(comboProfile.SelectedValue) == (int)AdminDataSet.UserProfilesDataTable.ProfileID.admin)
            {
                if (dsAdmin.Users.HowManyAdmins() < 2)
                {
                    MessageBox.Show(db.GetLangString("UserAdminForm.LastAdminCannotBeDeleted"));
                    return;
                }
            }

            // confirm delete
            string msg = string.Format(db.GetLangString("UserAdminForm.DeleteUser"), txtUsername.Text);
            if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            // get the index of the previous user in the combobox
            int index = comboUsers.SelectedIndex - 1;

            // delete and save
            bindingUsers.RemoveCurrent();
            adapterUsers.Update(dsAdmin.Users);
            SetFormState(FormState.View);

            // attempt to select the previous user in the combobox
            if (comboUsers.Items.Count > 0)
            {
                if (index < 0)
                    index = 0;
                if (index >= comboUsers.Items.Count)
                    index = comboUsers.Items.Count - 1;
                comboUsers.SelectedIndex = index;
            }
        }
        #endregion

        #region ToggleShowPassword
        private void ToggleShowPassword()
        {
            // determine if going to show/hide password
            bool show = txtPassword.Visible;

            // decrypt the password if showing it
            if (show)
                txtPasswordDecrypted.Text = Encryption.DecryptString(txtPassword.Text);
            else
                txtPasswordDecrypted.Text = "";

            // toggle visibility of the
            // encrypted/decrypted password textboxes
            txtPassword.Visible = !show;
            txtPasswordDecrypted.Visible = show;
        }
        #endregion

        #region EnsureLastAdminKeepsProfile
        /// <summary>
        /// Ensures that if user tries to change the last admin's
        /// profile to something else than admin, this will be prohibited.
        /// </summary>
        private void EnsureLastAdminKeepsProfile()
        {
            // check that last admin is not trying to be changed to other profile
            if ((CurrentFormState == FormState.Edit) &&
                (bindingUsers.Current != null) &&
                (bindingUserProfiles.Current != null))
            {
                DataRowView row = (DataRowView)bindingUsers.Current;
                DataRowView rowProfile = (DataRowView)bindingUserProfiles.Current;
                int AdminProfileID = (int)AdminDataSet.UserProfilesDataTable.ProfileID.admin;
                if ((dsAdmin.Users.HowManyAdmins() < 2) &&                              // check if last admin
                    (tools.object2int(row["ProfileID"]) == AdminProfileID) &&           // check if this is admin
                    (tools.object2int(rowProfile["ProfileID"]) != AdminProfileID))      // check if changing to other profile
                {
                    // re-select admin in profiles combo
                    int pos = bindingUserProfiles.Find("ProfileID", (int)AdminDataSet.UserProfilesDataTable.ProfileID.admin);
                    if ((pos >= 0) && (pos < bindingUserProfiles.Count))
                        bindingUserProfiles.Position = pos;
                    comboProfile.Refresh();

                    // display message to user
                    MessageBox.Show(db.GetLangString("UserAdminForm.CannotChangeProfileOnLastAdmin"));
                }
            }
        }
        #endregion

        private void UserAdminForm_Load(object sender, EventArgs e)
        {
            LoadData();
            SetFormState(FormState.View);

            // localization
            btnNew.Text = db.GetLangString("Application.New");
            btnEdit.Text = db.GetLangString("Application.Edit");
            btnDelete.Text = db.GetLangString("Application.Delete");
            btnSave.Text = db.GetLangString("Application.Save");
            btnClose.Text = db.GetLangString("Application.Close");
            btnCancel.Text = db.GetLangString("Application.Cancel");
            lbUsers.Text = db.GetLangString("UserAdminForm.lbUsers");
            lbUsername.Text = db.GetLangString("UserAdminForm.lbUsername");
            lbUserProfile.Text = db.GetLangString("UserAdminForm.lbUserProfile");
            lbPassword.Text = db.GetLangString("UserAdminForm.lbPassword");
            groupUserInfo.Text = db.GetLangString("UserAdminForm.groupUserInfo");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AddNewUser();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditCurrentUser();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelEditOrNew();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            ToggleShowPassword();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveCurrentUser();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteCurrentUser();
        }

        private void comboProfile_Validating(object sender, CancelEventArgs e)
        {
            EnsureLastAdminKeepsProfile();
        }
    }
}