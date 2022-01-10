namespace RBOS
{
    partial class FTPAccountsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTPAccountsForm));
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.comboFTPAccounts = new System.Windows.Forms.ComboBox();
            this.bindingLookupFTPAccounts = new System.Windows.Forms.BindingSource(this.components);
            this.dsAdmin = new RBOS.AdminDataSet();
            this.bindingFTPAccounts = new System.Windows.Forms.BindingSource(this.components);
            this.adapterFTPAccounts = new RBOS.AdminDataSetTableAdapters.FTPAccountsTableAdapter();
            this.adapterLookupFTPAccounts = new RBOS.AdminDataSetTableAdapters.LookupFTPAccountsTableAdapter();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtProxyHost = new System.Windows.Forms.TextBox();
            this.txtProxyPort = new System.Windows.Forms.TextBox();
            this.txtProxyUsername = new System.Windows.Forms.TextBox();
            this.txtProxyPassword = new System.Windows.Forms.TextBox();
            this.txtClientDepartureDir = new System.Windows.Forms.TextBox();
            this.lbAccountName = new System.Windows.Forms.Label();
            this.lbHost = new System.Windows.Forms.Label();
            this.lbPort = new System.Windows.Forms.Label();
            this.lbUsername = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbPassive = new System.Windows.Forms.Label();
            this.lbTransferType = new System.Windows.Forms.Label();
            this.lbProxyHost = new System.Windows.Forms.Label();
            this.lbProxyPort = new System.Windows.Forms.Label();
            this.lbProxyPassword = new System.Windows.Forms.Label();
            this.lbProxyUsername = new System.Windows.Forms.Label();
            this.lbClientDepartureDir = new System.Windows.Forms.Label();
            this.boxFTPAccountSettings = new System.Windows.Forms.GroupBox();
            this.comboTransferType = new System.Windows.Forms.ComboBox();
            this.chkPassive = new System.Windows.Forms.CheckBox();
            this.boxProxySettings = new System.Windows.Forms.GroupBox();
            this.boxFileSystemSettings = new System.Windows.Forms.GroupBox();
            this.txtServerDepartureDir = new System.Windows.Forms.TextBox();
            this.lbServerDepartureDir = new System.Windows.Forms.Label();
            this.btnClientArrivalDir = new System.Windows.Forms.Button();
            this.txtClientArrivalDir = new System.Windows.Forms.TextBox();
            this.lbClientArrivalDir = new System.Windows.Forms.Label();
            this.txtServerArrivalDir = new System.Windows.Forms.TextBox();
            this.lbServerArrivalDir = new System.Windows.Forms.Label();
            this.btnClientDepartureDir = new System.Windows.Forms.Button();
            this.dialogFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTestConnection = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupFTPAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAdmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingFTPAccounts)).BeginInit();
            this.boxFTPAccountSettings.SuspendLayout();
            this.boxProxySettings.SuspendLayout();
            this.boxFileSystemSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(89, 474);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "[New]";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(170, 474);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "[Delete]";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(251, 474);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "[Edit]";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(332, 474);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // comboFTPAccounts
            // 
            this.comboFTPAccounts.DataSource = this.bindingLookupFTPAccounts;
            this.comboFTPAccounts.DisplayMember = "AccountName";
            this.comboFTPAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFTPAccounts.FormattingEnabled = true;
            this.comboFTPAccounts.Location = new System.Drawing.Point(120, 6);
            this.comboFTPAccounts.Name = "comboFTPAccounts";
            this.comboFTPAccounts.Size = new System.Drawing.Size(236, 21);
            this.comboFTPAccounts.TabIndex = 4;
            this.comboFTPAccounts.ValueMember = "ID";
            this.comboFTPAccounts.SelectedIndexChanged += new System.EventHandler(this.comboFTPAccounts_SelectedIndexChanged);
            // 
            // bindingLookupFTPAccounts
            // 
            this.bindingLookupFTPAccounts.DataMember = "LookupFTPAccounts";
            this.bindingLookupFTPAccounts.DataSource = this.dsAdmin;
            // 
            // dsAdmin
            // 
            this.dsAdmin.DataSetName = "AdminDataSet";
            this.dsAdmin.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingFTPAccounts
            // 
            this.bindingFTPAccounts.DataMember = "FTPAccounts";
            this.bindingFTPAccounts.DataSource = this.dsAdmin;
            // 
            // adapterFTPAccounts
            // 
            this.adapterFTPAccounts.ClearBeforeFill = true;
            // 
            // adapterLookupFTPAccounts
            // 
            this.adapterLookupFTPAccounts.ClearBeforeFill = true;
            // 
            // txtAccountName
            // 
            this.txtAccountName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingFTPAccounts, "AccountName", true));
            this.txtAccountName.Location = new System.Drawing.Point(130, 12);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(236, 20);
            this.txtAccountName.TabIndex = 5;
            this.txtAccountName.Visible = false;
            // 
            // txtHost
            // 
            this.txtHost.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingFTPAccounts, "Host", true));
            this.txtHost.Location = new System.Drawing.Point(105, 19);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(188, 20);
            this.txtHost.TabIndex = 6;
            // 
            // txtPort
            // 
            this.txtPort.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingFTPAccounts, "Port", true));
            this.txtPort.Location = new System.Drawing.Point(340, 19);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(39, 20);
            this.txtPort.TabIndex = 7;
            this.txtPort.Text = "21";
            this.txtPort.Validating += new System.ComponentModel.CancelEventHandler(this.txtPort_Validating);
            // 
            // txtUsername
            // 
            this.txtUsername.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingFTPAccounts, "Username", true));
            this.txtUsername.Location = new System.Drawing.Point(105, 45);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(121, 20);
            this.txtUsername.TabIndex = 8;
            // 
            // txtPassword
            // 
            this.txtPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingFTPAccounts, "Passwd", true));
            this.txtPassword.Location = new System.Drawing.Point(105, 71);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(121, 20);
            this.txtPassword.TabIndex = 9;
            // 
            // txtProxyHost
            // 
            this.txtProxyHost.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingFTPAccounts, "ProxyHost", true));
            this.txtProxyHost.Location = new System.Drawing.Point(105, 19);
            this.txtProxyHost.Name = "txtProxyHost";
            this.txtProxyHost.Size = new System.Drawing.Size(188, 20);
            this.txtProxyHost.TabIndex = 10;
            // 
            // txtProxyPort
            // 
            this.txtProxyPort.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingFTPAccounts, "ProxyPort", true));
            this.txtProxyPort.Location = new System.Drawing.Point(340, 19);
            this.txtProxyPort.Name = "txtProxyPort";
            this.txtProxyPort.Size = new System.Drawing.Size(39, 20);
            this.txtProxyPort.TabIndex = 11;
            // 
            // txtProxyUsername
            // 
            this.txtProxyUsername.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingFTPAccounts, "ProxyUsername", true));
            this.txtProxyUsername.Location = new System.Drawing.Point(105, 45);
            this.txtProxyUsername.Name = "txtProxyUsername";
            this.txtProxyUsername.Size = new System.Drawing.Size(121, 20);
            this.txtProxyUsername.TabIndex = 12;
            // 
            // txtProxyPassword
            // 
            this.txtProxyPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingFTPAccounts, "ProxyPassword", true));
            this.txtProxyPassword.Location = new System.Drawing.Point(105, 71);
            this.txtProxyPassword.Name = "txtProxyPassword";
            this.txtProxyPassword.Size = new System.Drawing.Size(121, 20);
            this.txtProxyPassword.TabIndex = 13;
            // 
            // txtClientDepartureDir
            // 
            this.txtClientDepartureDir.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingFTPAccounts, "ClientDepartureDir", true));
            this.txtClientDepartureDir.Location = new System.Drawing.Point(161, 19);
            this.txtClientDepartureDir.Name = "txtClientDepartureDir";
            this.txtClientDepartureDir.Size = new System.Drawing.Size(186, 20);
            this.txtClientDepartureDir.TabIndex = 14;
            // 
            // lbAccountName
            // 
            this.lbAccountName.AutoSize = true;
            this.lbAccountName.Location = new System.Drawing.Point(12, 9);
            this.lbAccountName.Name = "lbAccountName";
            this.lbAccountName.Size = new System.Drawing.Size(84, 13);
            this.lbAccountName.TabIndex = 20;
            this.lbAccountName.Text = "[Account Name]";
            // 
            // lbHost
            // 
            this.lbHost.AutoSize = true;
            this.lbHost.Location = new System.Drawing.Point(6, 22);
            this.lbHost.Name = "lbHost";
            this.lbHost.Size = new System.Drawing.Size(35, 13);
            this.lbHost.TabIndex = 21;
            this.lbHost.Text = "[Host]";
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(302, 22);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(32, 13);
            this.lbPort.TabIndex = 22;
            this.lbPort.Text = "[Port]";
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Location = new System.Drawing.Point(6, 48);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(61, 13);
            this.lbUsername.TabIndex = 23;
            this.lbUsername.Text = "[Username]";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(6, 74);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(59, 13);
            this.lbPassword.TabIndex = 24;
            this.lbPassword.Text = "[Password]";
            // 
            // lbPassive
            // 
            this.lbPassive.AutoSize = true;
            this.lbPassive.Location = new System.Drawing.Point(6, 124);
            this.lbPassive.Name = "lbPassive";
            this.lbPassive.Size = new System.Drawing.Size(169, 13);
            this.lbPassive.TabIndex = 25;
            this.lbPassive.Text = "[Passive Mode (like www browser)";
            // 
            // lbTransferType
            // 
            this.lbTransferType.AutoSize = true;
            this.lbTransferType.Location = new System.Drawing.Point(6, 100);
            this.lbTransferType.Name = "lbTransferType";
            this.lbTransferType.Size = new System.Drawing.Size(79, 13);
            this.lbTransferType.TabIndex = 26;
            this.lbTransferType.Text = "[Transfer Type]";
            // 
            // lbProxyHost
            // 
            this.lbProxyHost.AutoSize = true;
            this.lbProxyHost.Location = new System.Drawing.Point(6, 22);
            this.lbProxyHost.Name = "lbProxyHost";
            this.lbProxyHost.Size = new System.Drawing.Size(35, 13);
            this.lbProxyHost.TabIndex = 27;
            this.lbProxyHost.Text = "[Host]";
            // 
            // lbProxyPort
            // 
            this.lbProxyPort.AutoSize = true;
            this.lbProxyPort.Location = new System.Drawing.Point(302, 22);
            this.lbProxyPort.Name = "lbProxyPort";
            this.lbProxyPort.Size = new System.Drawing.Size(32, 13);
            this.lbProxyPort.TabIndex = 28;
            this.lbProxyPort.Text = "[Port]";
            // 
            // lbProxyPassword
            // 
            this.lbProxyPassword.AutoSize = true;
            this.lbProxyPassword.Location = new System.Drawing.Point(6, 74);
            this.lbProxyPassword.Name = "lbProxyPassword";
            this.lbProxyPassword.Size = new System.Drawing.Size(59, 13);
            this.lbProxyPassword.TabIndex = 29;
            this.lbProxyPassword.Text = "[Password]";
            // 
            // lbProxyUsername
            // 
            this.lbProxyUsername.AutoSize = true;
            this.lbProxyUsername.Location = new System.Drawing.Point(6, 48);
            this.lbProxyUsername.Name = "lbProxyUsername";
            this.lbProxyUsername.Size = new System.Drawing.Size(61, 13);
            this.lbProxyUsername.TabIndex = 30;
            this.lbProxyUsername.Text = "[Username]";
            // 
            // lbClientDepartureDir
            // 
            this.lbClientDepartureDir.AutoSize = true;
            this.lbClientDepartureDir.Location = new System.Drawing.Point(6, 22);
            this.lbClientDepartureDir.Name = "lbClientDepartureDir";
            this.lbClientDepartureDir.Size = new System.Drawing.Size(134, 13);
            this.lbClientDepartureDir.TabIndex = 31;
            this.lbClientDepartureDir.Text = "[Client Departure Directory]";
            // 
            // boxFTPAccountSettings
            // 
            this.boxFTPAccountSettings.Controls.Add(this.comboTransferType);
            this.boxFTPAccountSettings.Controls.Add(this.chkPassive);
            this.boxFTPAccountSettings.Controls.Add(this.txtHost);
            this.boxFTPAccountSettings.Controls.Add(this.lbHost);
            this.boxFTPAccountSettings.Controls.Add(this.txtPort);
            this.boxFTPAccountSettings.Controls.Add(this.lbPort);
            this.boxFTPAccountSettings.Controls.Add(this.txtUsername);
            this.boxFTPAccountSettings.Controls.Add(this.lbUsername);
            this.boxFTPAccountSettings.Controls.Add(this.lbPassword);
            this.boxFTPAccountSettings.Controls.Add(this.txtPassword);
            this.boxFTPAccountSettings.Controls.Add(this.lbPassive);
            this.boxFTPAccountSettings.Controls.Add(this.lbTransferType);
            this.boxFTPAccountSettings.Location = new System.Drawing.Point(12, 33);
            this.boxFTPAccountSettings.Name = "boxFTPAccountSettings";
            this.boxFTPAccountSettings.Size = new System.Drawing.Size(395, 150);
            this.boxFTPAccountSettings.TabIndex = 35;
            this.boxFTPAccountSettings.TabStop = false;
            this.boxFTPAccountSettings.Text = "[FTP Account Settings]";
            // 
            // comboTransferType
            // 
            this.comboTransferType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingFTPAccounts, "TransferType", true));
            this.comboTransferType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTransferType.Enabled = false;
            this.comboTransferType.FormattingEnabled = true;
            this.comboTransferType.Location = new System.Drawing.Point(105, 97);
            this.comboTransferType.Name = "comboTransferType";
            this.comboTransferType.Size = new System.Drawing.Size(121, 21);
            this.comboTransferType.TabIndex = 27;
            // 
            // chkPassive
            // 
            this.chkPassive.AutoSize = true;
            this.chkPassive.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingFTPAccounts, "Passive", true));
            this.chkPassive.Location = new System.Drawing.Point(194, 124);
            this.chkPassive.Name = "chkPassive";
            this.chkPassive.Size = new System.Drawing.Size(15, 14);
            this.chkPassive.TabIndex = 26;
            this.chkPassive.UseVisualStyleBackColor = true;
            // 
            // boxProxySettings
            // 
            this.boxProxySettings.Controls.Add(this.txtProxyHost);
            this.boxProxySettings.Controls.Add(this.lbProxyHost);
            this.boxProxySettings.Controls.Add(this.txtProxyPort);
            this.boxProxySettings.Controls.Add(this.lbProxyPort);
            this.boxProxySettings.Controls.Add(this.txtProxyUsername);
            this.boxProxySettings.Controls.Add(this.txtProxyPassword);
            this.boxProxySettings.Controls.Add(this.lbProxyUsername);
            this.boxProxySettings.Controls.Add(this.lbProxyPassword);
            this.boxProxySettings.Location = new System.Drawing.Point(12, 189);
            this.boxProxySettings.Name = "boxProxySettings";
            this.boxProxySettings.Size = new System.Drawing.Size(395, 104);
            this.boxProxySettings.TabIndex = 36;
            this.boxProxySettings.TabStop = false;
            this.boxProxySettings.Text = "[Proxy Settings]";
            // 
            // boxFileSystemSettings
            // 
            this.boxFileSystemSettings.Controls.Add(this.txtServerDepartureDir);
            this.boxFileSystemSettings.Controls.Add(this.lbServerDepartureDir);
            this.boxFileSystemSettings.Controls.Add(this.btnClientArrivalDir);
            this.boxFileSystemSettings.Controls.Add(this.txtClientArrivalDir);
            this.boxFileSystemSettings.Controls.Add(this.lbClientArrivalDir);
            this.boxFileSystemSettings.Controls.Add(this.txtServerArrivalDir);
            this.boxFileSystemSettings.Controls.Add(this.lbServerArrivalDir);
            this.boxFileSystemSettings.Controls.Add(this.btnClientDepartureDir);
            this.boxFileSystemSettings.Controls.Add(this.txtClientDepartureDir);
            this.boxFileSystemSettings.Controls.Add(this.lbClientDepartureDir);
            this.boxFileSystemSettings.Location = new System.Drawing.Point(12, 299);
            this.boxFileSystemSettings.Name = "boxFileSystemSettings";
            this.boxFileSystemSettings.Size = new System.Drawing.Size(395, 133);
            this.boxFileSystemSettings.TabIndex = 37;
            this.boxFileSystemSettings.TabStop = false;
            this.boxFileSystemSettings.Text = "[File System Settings]";
            // 
            // txtServerDepartureDir
            // 
            this.txtServerDepartureDir.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingFTPAccounts, "ServerDepartureDir", true));
            this.txtServerDepartureDir.Location = new System.Drawing.Point(161, 71);
            this.txtServerDepartureDir.Name = "txtServerDepartureDir";
            this.txtServerDepartureDir.Size = new System.Drawing.Size(186, 20);
            this.txtServerDepartureDir.TabIndex = 39;
            // 
            // lbServerDepartureDir
            // 
            this.lbServerDepartureDir.AutoSize = true;
            this.lbServerDepartureDir.Location = new System.Drawing.Point(6, 74);
            this.lbServerDepartureDir.Name = "lbServerDepartureDir";
            this.lbServerDepartureDir.Size = new System.Drawing.Size(139, 13);
            this.lbServerDepartureDir.TabIndex = 40;
            this.lbServerDepartureDir.Text = "[Server Departure Directory]";
            // 
            // btnClientArrivalDir
            // 
            this.btnClientArrivalDir.Enabled = false;
            this.btnClientArrivalDir.Location = new System.Drawing.Point(353, 43);
            this.btnClientArrivalDir.Name = "btnClientArrivalDir";
            this.btnClientArrivalDir.Size = new System.Drawing.Size(26, 23);
            this.btnClientArrivalDir.TabIndex = 35;
            this.btnClientArrivalDir.Text = "...";
            this.btnClientArrivalDir.UseVisualStyleBackColor = true;
            this.btnClientArrivalDir.Click += new System.EventHandler(this.btnClientArrivalDir_Click);
            // 
            // txtClientArrivalDir
            // 
            this.txtClientArrivalDir.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingFTPAccounts, "ClientArrivalDir", true));
            this.txtClientArrivalDir.Location = new System.Drawing.Point(161, 45);
            this.txtClientArrivalDir.Name = "txtClientArrivalDir";
            this.txtClientArrivalDir.Size = new System.Drawing.Size(186, 20);
            this.txtClientArrivalDir.TabIndex = 36;
            // 
            // lbClientArrivalDir
            // 
            this.lbClientArrivalDir.AutoSize = true;
            this.lbClientArrivalDir.Location = new System.Drawing.Point(6, 48);
            this.lbClientArrivalDir.Name = "lbClientArrivalDir";
            this.lbClientArrivalDir.Size = new System.Drawing.Size(116, 13);
            this.lbClientArrivalDir.TabIndex = 37;
            this.lbClientArrivalDir.Text = "[Client Arrival Directory]";
            // 
            // txtServerArrivalDir
            // 
            this.txtServerArrivalDir.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingFTPAccounts, "ServerArrivalDir", true));
            this.txtServerArrivalDir.Location = new System.Drawing.Point(161, 97);
            this.txtServerArrivalDir.Name = "txtServerArrivalDir";
            this.txtServerArrivalDir.Size = new System.Drawing.Size(186, 20);
            this.txtServerArrivalDir.TabIndex = 33;
            // 
            // lbServerArrivalDir
            // 
            this.lbServerArrivalDir.AutoSize = true;
            this.lbServerArrivalDir.Location = new System.Drawing.Point(6, 100);
            this.lbServerArrivalDir.Name = "lbServerArrivalDir";
            this.lbServerArrivalDir.Size = new System.Drawing.Size(121, 13);
            this.lbServerArrivalDir.TabIndex = 34;
            this.lbServerArrivalDir.Text = "[Server Arrival Directory]";
            // 
            // btnClientDepartureDir
            // 
            this.btnClientDepartureDir.Enabled = false;
            this.btnClientDepartureDir.Location = new System.Drawing.Point(353, 17);
            this.btnClientDepartureDir.Name = "btnClientDepartureDir";
            this.btnClientDepartureDir.Size = new System.Drawing.Size(26, 23);
            this.btnClientDepartureDir.TabIndex = 0;
            this.btnClientDepartureDir.Text = "...";
            this.btnClientDepartureDir.UseVisualStyleBackColor = true;
            this.btnClientDepartureDir.Click += new System.EventHandler(this.btnClientDepartureDir_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(332, 465);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 38;
            this.btnCancel.Text = "[Cancel]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(251, 465);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "[Save]";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(276, 438);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(131, 23);
            this.btnTestConnection.TabIndex = 39;
            this.btnTestConnection.Text = "[Test Connection]";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // FTPAccountsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(427, 509);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.boxFileSystemSettings);
            this.Controls.Add(this.boxProxySettings);
            this.Controls.Add(this.lbAccountName);
            this.Controls.Add(this.boxFTPAccountSettings);
            this.Controls.Add(this.comboFTPAccounts);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtAccountName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FTPAccountsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FTPAccountsForm";
            this.Activated += new System.EventHandler(this.FTPAccountsForm_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupFTPAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAdmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingFTPAccounts)).EndInit();
            this.boxFTPAccountSettings.ResumeLayout(false);
            this.boxFTPAccountSettings.PerformLayout();
            this.boxProxySettings.ResumeLayout(false);
            this.boxProxySettings.PerformLayout();
            this.boxFileSystemSettings.ResumeLayout(false);
            this.boxFileSystemSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox comboFTPAccounts;
        private AdminDataSet dsAdmin;
        private System.Windows.Forms.BindingSource bindingFTPAccounts;
        private RBOS.AdminDataSetTableAdapters.FTPAccountsTableAdapter adapterFTPAccounts;
        private System.Windows.Forms.BindingSource bindingLookupFTPAccounts;
        private RBOS.AdminDataSetTableAdapters.LookupFTPAccountsTableAdapter adapterLookupFTPAccounts;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtProxyHost;
        private System.Windows.Forms.TextBox txtProxyPort;
        private System.Windows.Forms.TextBox txtProxyUsername;
        private System.Windows.Forms.TextBox txtProxyPassword;
        private System.Windows.Forms.TextBox txtClientDepartureDir;
        private System.Windows.Forms.Label lbAccountName;
        private System.Windows.Forms.Label lbHost;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbPassive;
        private System.Windows.Forms.Label lbTransferType;
        private System.Windows.Forms.Label lbProxyHost;
        private System.Windows.Forms.Label lbProxyPort;
        private System.Windows.Forms.Label lbProxyPassword;
        private System.Windows.Forms.Label lbProxyUsername;
        private System.Windows.Forms.Label lbClientDepartureDir;
        private System.Windows.Forms.GroupBox boxFTPAccountSettings;
        private System.Windows.Forms.CheckBox chkPassive;
        private System.Windows.Forms.ComboBox comboTransferType;
        private System.Windows.Forms.GroupBox boxProxySettings;
        private System.Windows.Forms.GroupBox boxFileSystemSettings;
        private System.Windows.Forms.Button btnClientDepartureDir;
        private System.Windows.Forms.FolderBrowserDialog dialogFolderBrowser;
        private System.Windows.Forms.TextBox txtServerArrivalDir;
        private System.Windows.Forms.Label lbServerArrivalDir;
        private System.Windows.Forms.Button btnClientArrivalDir;
        private System.Windows.Forms.TextBox txtClientArrivalDir;
        private System.Windows.Forms.Label lbClientArrivalDir;
        private System.Windows.Forms.TextBox txtServerDepartureDir;
        private System.Windows.Forms.Label lbServerDepartureDir;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnTestConnection;
    }
}