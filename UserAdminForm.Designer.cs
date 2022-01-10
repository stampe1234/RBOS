namespace RBOS
{
    partial class UserAdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAdminForm));
            this.comboUsers = new System.Windows.Forms.ComboBox();
            this.bindingUsers = new System.Windows.Forms.BindingSource(this.components);
            this.dsAdmin = new RBOS.AdminDataSet();
            this.lbUsers = new System.Windows.Forms.Label();
            this.adapterUsers = new RBOS.AdminDataSetTableAdapters.UsersTableAdapter();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.comboProfile = new System.Windows.Forms.ComboBox();
            this.bindingUserProfiles = new System.Windows.Forms.BindingSource(this.components);
            this.adapterUserProfiles = new RBOS.AdminDataSetTableAdapters.UserProfilesTableAdapter();
            this.groupUserInfo = new System.Windows.Forms.GroupBox();
            this.btnShowPassword = new System.Windows.Forms.Button();
            this.txtPasswordDecrypted = new System.Windows.Forms.TextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbUserProfile = new System.Windows.Forms.Label();
            this.lbUsername = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAdmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingUserProfiles)).BeginInit();
            this.groupUserInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboUsers
            // 
            this.comboUsers.DataSource = this.bindingUsers;
            this.comboUsers.DisplayMember = "Username";
            this.comboUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboUsers.FormattingEnabled = true;
            this.comboUsers.Location = new System.Drawing.Point(111, 12);
            this.comboUsers.Name = "comboUsers";
            this.comboUsers.Size = new System.Drawing.Size(210, 21);
            this.comboUsers.TabIndex = 0;
            this.comboUsers.ValueMember = "Username";
            // 
            // bindingUsers
            // 
            this.bindingUsers.DataMember = "Users";
            this.bindingUsers.DataSource = this.dsAdmin;
            // 
            // dsAdmin
            // 
            this.dsAdmin.DataSetName = "AdminDataSet";
            this.dsAdmin.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lbUsers
            // 
            this.lbUsers.AutoSize = true;
            this.lbUsers.Location = new System.Drawing.Point(21, 15);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(40, 13);
            this.lbUsers.TabIndex = 1;
            this.lbUsers.Text = "[Users]";
            // 
            // adapterUsers
            // 
            this.adapterUsers.ClearBeforeFill = true;
            // 
            // txtUsername
            // 
            this.txtUsername.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingUsers, "Username", true));
            this.txtUsername.Location = new System.Drawing.Point(96, 19);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(210, 20);
            this.txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingUsers, "Passwd", true));
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(96, 72);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(176, 20);
            this.txtPassword.TabIndex = 4;
            // 
            // comboProfile
            // 
            this.comboProfile.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingUsers, "ProfileID", true));
            this.comboProfile.DataSource = this.bindingUserProfiles;
            this.comboProfile.DisplayMember = "ProfileName";
            this.comboProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProfile.FormattingEnabled = true;
            this.comboProfile.Location = new System.Drawing.Point(96, 45);
            this.comboProfile.Name = "comboProfile";
            this.comboProfile.Size = new System.Drawing.Size(210, 21);
            this.comboProfile.TabIndex = 5;
            this.comboProfile.ValueMember = "ProfileID";
            this.comboProfile.Validating += new System.ComponentModel.CancelEventHandler(this.comboProfile_Validating);
            // 
            // bindingUserProfiles
            // 
            this.bindingUserProfiles.DataMember = "UserProfiles";
            this.bindingUserProfiles.DataSource = this.dsAdmin;
            // 
            // adapterUserProfiles
            // 
            this.adapterUserProfiles.ClearBeforeFill = true;
            // 
            // groupUserInfo
            // 
            this.groupUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupUserInfo.Controls.Add(this.btnShowPassword);
            this.groupUserInfo.Controls.Add(this.txtPasswordDecrypted);
            this.groupUserInfo.Controls.Add(this.lbPassword);
            this.groupUserInfo.Controls.Add(this.txtUsername);
            this.groupUserInfo.Controls.Add(this.lbUserProfile);
            this.groupUserInfo.Controls.Add(this.comboProfile);
            this.groupUserInfo.Controls.Add(this.lbUsername);
            this.groupUserInfo.Controls.Add(this.txtPassword);
            this.groupUserInfo.Location = new System.Drawing.Point(15, 39);
            this.groupUserInfo.Name = "groupUserInfo";
            this.groupUserInfo.Size = new System.Drawing.Size(317, 105);
            this.groupUserInfo.TabIndex = 6;
            this.groupUserInfo.TabStop = false;
            this.groupUserInfo.Text = "[User Information]";
            // 
            // btnShowPassword
            // 
            this.btnShowPassword.Location = new System.Drawing.Point(278, 72);
            this.btnShowPassword.Name = "btnShowPassword";
            this.btnShowPassword.Size = new System.Drawing.Size(28, 23);
            this.btnShowPassword.TabIndex = 11;
            this.btnShowPassword.Text = "...";
            this.btnShowPassword.UseVisualStyleBackColor = true;
            this.btnShowPassword.Click += new System.EventHandler(this.btnShowPassword_Click);
            // 
            // txtPasswordDecrypted
            // 
            this.txtPasswordDecrypted.Location = new System.Drawing.Point(96, 79);
            this.txtPasswordDecrypted.Name = "txtPasswordDecrypted";
            this.txtPasswordDecrypted.Size = new System.Drawing.Size(176, 20);
            this.txtPasswordDecrypted.TabIndex = 10;
            this.txtPasswordDecrypted.Visible = false;
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(6, 75);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(59, 13);
            this.lbPassword.TabIndex = 9;
            this.lbPassword.Text = "[Password]";
            // 
            // lbUserProfile
            // 
            this.lbUserProfile.AutoSize = true;
            this.lbUserProfile.Location = new System.Drawing.Point(6, 48);
            this.lbUserProfile.Name = "lbUserProfile";
            this.lbUserProfile.Size = new System.Drawing.Size(67, 13);
            this.lbUserProfile.TabIndex = 8;
            this.lbUserProfile.Text = "[User Profile]";
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Location = new System.Drawing.Point(6, 22);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(61, 13);
            this.lbUsername.TabIndex = 7;
            this.lbUsername.Text = "[Username]";
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(14, 153);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 7;
            this.btnNew.Text = "[New]";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(95, 153);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "[Edit]";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(257, 153);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(258, 162);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "[Cancel]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(177, 162);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "[Save]";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(176, 153);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "[Delete]";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // UserAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 188);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.groupUserInfo);
            this.Controls.Add(this.lbUsers);
            this.Controls.Add(this.comboUsers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UserAdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserAdminForm";
            this.Load += new System.EventHandler(this.UserAdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAdmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingUserProfiles)).EndInit();
            this.groupUserInfo.ResumeLayout(false);
            this.groupUserInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboUsers;
        private System.Windows.Forms.Label lbUsers;
        private AdminDataSet dsAdmin;
        private System.Windows.Forms.BindingSource bindingUsers;
        private RBOS.AdminDataSetTableAdapters.UsersTableAdapter adapterUsers;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox comboProfile;
        private System.Windows.Forms.BindingSource bindingUserProfiles;
        private RBOS.AdminDataSetTableAdapters.UserProfilesTableAdapter adapterUserProfiles;
        private System.Windows.Forms.GroupBox groupUserInfo;
        private System.Windows.Forms.Label lbUserProfile;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtPasswordDecrypted;
        private System.Windows.Forms.Button btnShowPassword;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
    }
}