namespace RBOS
{
    partial class SiteInformationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SiteInformationForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.lbBankAccount = new System.Windows.Forms.Label();
            this.txtBankAccount = new System.Windows.Forms.TextBox();
            this.bindingSiteInformation = new System.Windows.Forms.BindingSource(this.components);
            this.dsAdmin = new RBOS.AdminDataSet();
            this.lbNorddataKundenr = new System.Windows.Forms.Label();
            this.txtNorddataKundenr = new System.Windows.Forms.TextBox();
            this.lbSENo = new System.Windows.Forms.Label();
            this.txtSENo = new System.Windows.Forms.TextBox();
            this.lbFaxNo = new System.Windows.Forms.Label();
            this.txtFaxNo = new System.Windows.Forms.TextBox();
            this.lbTelephone = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lbZipCity = new System.Windows.Forms.Label();
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.lbAddress2 = new System.Windows.Forms.Label();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.lbAddress1 = new System.Windows.Forms.Label();
            this.txtAdress1 = new System.Windows.Forms.TextBox();
            this.lbSiteCode = new System.Windows.Forms.Label();
            this.txtSiteName = new System.Windows.Forms.TextBox();
            this.lbSiteName = new System.Windows.Forms.Label();
            this.txtSiteCode = new System.Windows.Forms.TextBox();
            this.tabBHHT = new System.Windows.Forms.TabPage();
            this.chkAutoCreateRBOSOrdersFromBHHT = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkBHHTImportBackupActive = new System.Windows.Forms.CheckBox();
            this.btnBHHTImportDir = new System.Windows.Forms.Button();
            this.btnBHHTImportBackupDir = new System.Windows.Forms.Button();
            this.txtBHHTImportDir = new System.Windows.Forms.TextBox();
            this.lbBHHTImportDir = new System.Windows.Forms.Label();
            this.txtBHHTImportBackupDir = new System.Windows.Forms.TextBox();
            this.lbBHHTImportBackupDir = new System.Windows.Forms.Label();
            this.lbBHHTImportBackupActive = new System.Windows.Forms.Label();
            this.groupBHHTExport = new System.Windows.Forms.GroupBox();
            this.chkBHHTExportBackupActive = new System.Windows.Forms.CheckBox();
            this.btnBHHTExportDir = new System.Windows.Forms.Button();
            this.btnBHHTExportBackupDir = new System.Windows.Forms.Button();
            this.txtBHHTExportDir = new System.Windows.Forms.TextBox();
            this.lbBHHTExportDir = new System.Windows.Forms.Label();
            this.txtBHHTExportBackupDir = new System.Windows.Forms.TextBox();
            this.lbBHHTExportBackupDir = new System.Windows.Forms.Label();
            this.lbBHHTBackupDirActive = new System.Windows.Forms.Label();
            this.lbAutoCreateRBOSOrdersFromBHHT = new System.Windows.Forms.Label();
            this.tabRSM = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkRSMImportBackupActive = new System.Windows.Forms.CheckBox();
            this.btnRSMImportDir = new System.Windows.Forms.Button();
            this.btnRSMImportBackupDir = new System.Windows.Forms.Button();
            this.txtRSMImportDir = new System.Windows.Forms.TextBox();
            this.lbRSMImportDir = new System.Windows.Forms.Label();
            this.txtRSMImportBackupDir = new System.Windows.Forms.TextBox();
            this.lbRSMImportBackupDir = new System.Windows.Forms.Label();
            this.lbRSMImportBackupActive = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkRSMExportBackupActive = new System.Windows.Forms.CheckBox();
            this.btnRSMExportDir = new System.Windows.Forms.Button();
            this.btnRSMExportBackupDir = new System.Windows.Forms.Button();
            this.txtRSMExportDir = new System.Windows.Forms.TextBox();
            this.lbRSMExportDir = new System.Windows.Forms.Label();
            this.txtRSMExportBackupDir = new System.Windows.Forms.TextBox();
            this.lbRSMExportBackupDir = new System.Windows.Forms.Label();
            this.lbRSMExportBackupActive = new System.Windows.Forms.Label();
            this.tabMisc = new System.Windows.Forms.TabPage();
            this.groupDebtor = new System.Windows.Forms.GroupBox();
            this.lbStandardDebtorStatementRemarks = new System.Windows.Forms.Label();
            this.txtStandardDebtorStatementRemarks = new System.Windows.Forms.TextBox();
            this.groupLastCreatedPrlFile = new System.Windows.Forms.GroupBox();
            this.lbLastCreatedPrlFile_Timestamp = new System.Windows.Forms.Label();
            this.txtLastCreatedPrlFile_Year = new System.Windows.Forms.TextBox();
            this.txtLastCreatedPrlFile_Period = new System.Windows.Forms.TextBox();
            this.lbLastCreatedPrlFile = new System.Windows.Forms.Label();
            this.groupReadings = new System.Windows.Forms.GroupBox();
            this.chkVaskeafstemning2 = new System.Windows.Forms.CheckBox();
            this.chkVaskeafstemning3 = new System.Windows.Forms.CheckBox();
            this.chkStationHasWash = new System.Windows.Forms.CheckBox();
            this.chkWashSeperateReadings = new System.Windows.Forms.CheckBox();
            this.groupACN = new System.Windows.Forms.GroupBox();
            this.chkACNEnabled = new System.Windows.Forms.CheckBox();
            this.txtACNLastExportedWeek = new System.Windows.Forms.TextBox();
            this.lbACNLastExported = new System.Windows.Forms.Label();
            this.txtACNLastExportedYear = new System.Windows.Forms.TextBox();
            this.tabSafePay = new System.Windows.Forms.TabPage();
            this.comboSafePayByttepengeOptaltInterval = new System.Windows.Forms.ComboBox();
            this.lbSafePayByttepengeOptaltInterval = new System.Windows.Forms.Label();
            this.GroupSafePayValutakurser = new System.Windows.Forms.GroupBox();
            this.txtSafePay_ValutaISO_SEK = new System.Windows.Forms.MaskedTextBox();
            this.txtSafePay_ValutaISO_NOK = new System.Windows.Forms.MaskedTextBox();
            this.txtSafePay_ValutaISO_EURO = new System.Windows.Forms.MaskedTextBox();
            this.lbSafePay_ValutaISO_NOK = new System.Windows.Forms.Label();
            this.lbSafePay_ValutaISO_SEK = new System.Windows.Forms.Label();
            this.lbSafePay_ValutaISO_EURO = new System.Windows.Forms.Label();
            this.tabEconomics = new System.Windows.Forms.TabPage();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtAftaleID = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblAftaleID = new System.Windows.Forms.Label();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.adapterSiteInformation = new RBOS.AdminDataSetTableAdapters.SiteInformationTableAdapter();
            this.folder = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSiteInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAdmin)).BeginInit();
            this.tabBHHT.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBHHTExport.SuspendLayout();
            this.tabRSM.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabMisc.SuspendLayout();
            this.groupDebtor.SuspendLayout();
            this.groupLastCreatedPrlFile.SuspendLayout();
            this.groupReadings.SuspendLayout();
            this.groupACN.SuspendLayout();
            this.tabSafePay.SuspendLayout();
            this.GroupSafePayValutakurser.SuspendLayout();
            this.tabEconomics.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabBHHT);
            this.tabControl1.Controls.Add(this.tabRSM);
            this.tabControl1.Controls.Add(this.tabMisc);
            this.tabControl1.Controls.Add(this.tabSafePay);
            this.tabControl1.Controls.Add(this.tabEconomics);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(374, 358);
            this.tabControl1.TabIndex = 0;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.lbBankAccount);
            this.tabGeneral.Controls.Add(this.txtBankAccount);
            this.tabGeneral.Controls.Add(this.lbNorddataKundenr);
            this.tabGeneral.Controls.Add(this.txtNorddataKundenr);
            this.tabGeneral.Controls.Add(this.lbSENo);
            this.tabGeneral.Controls.Add(this.txtSENo);
            this.tabGeneral.Controls.Add(this.lbFaxNo);
            this.tabGeneral.Controls.Add(this.txtFaxNo);
            this.tabGeneral.Controls.Add(this.lbTelephone);
            this.tabGeneral.Controls.Add(this.txtTelephone);
            this.tabGeneral.Controls.Add(this.txtCity);
            this.tabGeneral.Controls.Add(this.lbZipCity);
            this.tabGeneral.Controls.Add(this.txtZipCode);
            this.tabGeneral.Controls.Add(this.lbAddress2);
            this.tabGeneral.Controls.Add(this.txtAddress2);
            this.tabGeneral.Controls.Add(this.lbAddress1);
            this.tabGeneral.Controls.Add(this.txtAdress1);
            this.tabGeneral.Controls.Add(this.lbSiteCode);
            this.tabGeneral.Controls.Add(this.txtSiteName);
            this.tabGeneral.Controls.Add(this.lbSiteName);
            this.tabGeneral.Controls.Add(this.txtSiteCode);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(366, 332);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "[General]";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // lbBankAccount
            // 
            this.lbBankAccount.AutoSize = true;
            this.lbBankAccount.Location = new System.Drawing.Point(9, 234);
            this.lbBankAccount.Name = "lbBankAccount";
            this.lbBankAccount.Size = new System.Drawing.Size(81, 13);
            this.lbBankAccount.TabIndex = 20;
            this.lbBankAccount.Text = "[Bank Account]";
            // 
            // txtBankAccount
            // 
            this.txtBankAccount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSiteInformation, "BankAccount", true));
            this.txtBankAccount.Location = new System.Drawing.Point(134, 231);
            this.txtBankAccount.MaxLength = 20;
            this.txtBankAccount.Name = "txtBankAccount";
            this.txtBankAccount.Size = new System.Drawing.Size(106, 20);
            this.txtBankAccount.TabIndex = 19;
            // 
            // bindingSiteInformation
            // 
            this.bindingSiteInformation.DataMember = "SiteInformation";
            this.bindingSiteInformation.DataSource = this.dsAdmin;
            this.bindingSiteInformation.CurrentChanged += new System.EventHandler(this.bindingSiteInformation_CurrentChanged);
            // 
            // dsAdmin
            // 
            this.dsAdmin.DataSetName = "AdminDataSet";
            this.dsAdmin.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lbNorddataKundenr
            // 
            this.lbNorddataKundenr.AutoSize = true;
            this.lbNorddataKundenr.Location = new System.Drawing.Point(9, 260);
            this.lbNorddataKundenr.Name = "lbNorddataKundenr";
            this.lbNorddataKundenr.Size = new System.Drawing.Size(104, 13);
            this.lbNorddataKundenr.TabIndex = 18;
            this.lbNorddataKundenr.Text = "[Norddata Cust. No.]";
            // 
            // txtNorddataKundenr
            // 
            this.txtNorddataKundenr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSiteInformation, "NorddataKundenr", true));
            this.txtNorddataKundenr.Location = new System.Drawing.Point(134, 257);
            this.txtNorddataKundenr.MaxLength = 6;
            this.txtNorddataKundenr.Name = "txtNorddataKundenr";
            this.txtNorddataKundenr.Size = new System.Drawing.Size(106, 20);
            this.txtNorddataKundenr.TabIndex = 17;
            // 
            // lbSENo
            // 
            this.lbSENo.AutoSize = true;
            this.lbSENo.Location = new System.Drawing.Point(9, 208);
            this.lbSENo.Name = "lbSENo";
            this.lbSENo.Size = new System.Drawing.Size(42, 13);
            this.lbSENo.TabIndex = 16;
            this.lbSENo.Text = "[SE nr.]";
            // 
            // txtSENo
            // 
            this.txtSENo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSiteInformation, "SE", true));
            this.txtSENo.Location = new System.Drawing.Point(134, 205);
            this.txtSENo.MaxLength = 10;
            this.txtSENo.Name = "txtSENo";
            this.txtSENo.Size = new System.Drawing.Size(106, 20);
            this.txtSENo.TabIndex = 15;
            // 
            // lbFaxNo
            // 
            this.lbFaxNo.AutoSize = true;
            this.lbFaxNo.Location = new System.Drawing.Point(7, 182);
            this.lbFaxNo.Name = "lbFaxNo";
            this.lbFaxNo.Size = new System.Drawing.Size(44, 13);
            this.lbFaxNo.TabIndex = 14;
            this.lbFaxNo.Text = "[FaxNo]";
            // 
            // txtFaxNo
            // 
            this.txtFaxNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSiteInformation, "FaxNo", true));
            this.txtFaxNo.Location = new System.Drawing.Point(134, 179);
            this.txtFaxNo.MaxLength = 10;
            this.txtFaxNo.Name = "txtFaxNo";
            this.txtFaxNo.Size = new System.Drawing.Size(106, 20);
            this.txtFaxNo.TabIndex = 13;
            // 
            // lbTelephone
            // 
            this.lbTelephone.AutoSize = true;
            this.lbTelephone.Location = new System.Drawing.Point(7, 156);
            this.lbTelephone.Name = "lbTelephone";
            this.lbTelephone.Size = new System.Drawing.Size(64, 13);
            this.lbTelephone.TabIndex = 12;
            this.lbTelephone.Text = "[Telephone]";
            // 
            // txtTelephone
            // 
            this.txtTelephone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSiteInformation, "Telephone", true));
            this.txtTelephone.Location = new System.Drawing.Point(134, 153);
            this.txtTelephone.MaxLength = 10;
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(106, 20);
            this.txtTelephone.TabIndex = 11;
            // 
            // txtCity
            // 
            this.txtCity.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSiteInformation, "City", true));
            this.txtCity.Location = new System.Drawing.Point(188, 127);
            this.txtCity.MaxLength = 50;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(152, 20);
            this.txtCity.TabIndex = 10;
            // 
            // lbZipCity
            // 
            this.lbZipCity.AutoSize = true;
            this.lbZipCity.Location = new System.Drawing.Point(9, 130);
            this.lbZipCity.Name = "lbZipCity";
            this.lbZipCity.Size = new System.Drawing.Size(45, 13);
            this.lbZipCity.TabIndex = 9;
            this.lbZipCity.Text = "[ZipCity]";
            // 
            // txtZipCode
            // 
            this.txtZipCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSiteInformation, "ZipCode", true));
            this.txtZipCode.Location = new System.Drawing.Point(134, 127);
            this.txtZipCode.MaxLength = 10;
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(48, 20);
            this.txtZipCode.TabIndex = 8;
            // 
            // lbAddress2
            // 
            this.lbAddress2.AutoSize = true;
            this.lbAddress2.Location = new System.Drawing.Point(7, 104);
            this.lbAddress2.Name = "lbAddress2";
            this.lbAddress2.Size = new System.Drawing.Size(57, 13);
            this.lbAddress2.TabIndex = 7;
            this.lbAddress2.Text = "[Address2]";
            // 
            // txtAddress2
            // 
            this.txtAddress2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSiteInformation, "Adress2", true));
            this.txtAddress2.Location = new System.Drawing.Point(134, 101);
            this.txtAddress2.MaxLength = 50;
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(206, 20);
            this.txtAddress2.TabIndex = 6;
            // 
            // lbAddress1
            // 
            this.lbAddress1.AutoSize = true;
            this.lbAddress1.Location = new System.Drawing.Point(7, 77);
            this.lbAddress1.Name = "lbAddress1";
            this.lbAddress1.Size = new System.Drawing.Size(57, 13);
            this.lbAddress1.TabIndex = 5;
            this.lbAddress1.Text = "[Address1]";
            // 
            // txtAdress1
            // 
            this.txtAdress1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSiteInformation, "Adress1", true));
            this.txtAdress1.Location = new System.Drawing.Point(134, 74);
            this.txtAdress1.MaxLength = 50;
            this.txtAdress1.Name = "txtAdress1";
            this.txtAdress1.Size = new System.Drawing.Size(206, 20);
            this.txtAdress1.TabIndex = 4;
            // 
            // lbSiteCode
            // 
            this.lbSiteCode.AutoSize = true;
            this.lbSiteCode.Location = new System.Drawing.Point(7, 25);
            this.lbSiteCode.Name = "lbSiteCode";
            this.lbSiteCode.Size = new System.Drawing.Size(56, 13);
            this.lbSiteCode.TabIndex = 3;
            this.lbSiteCode.Text = "[SiteCode]";
            // 
            // txtSiteName
            // 
            this.txtSiteName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSiteInformation, "SiteName", true));
            this.txtSiteName.Location = new System.Drawing.Point(134, 48);
            this.txtSiteName.MaxLength = 50;
            this.txtSiteName.Name = "txtSiteName";
            this.txtSiteName.Size = new System.Drawing.Size(206, 20);
            this.txtSiteName.TabIndex = 2;
            // 
            // lbSiteName
            // 
            this.lbSiteName.AutoSize = true;
            this.lbSiteName.Location = new System.Drawing.Point(7, 51);
            this.lbSiteName.Name = "lbSiteName";
            this.lbSiteName.Size = new System.Drawing.Size(59, 13);
            this.lbSiteName.TabIndex = 1;
            this.lbSiteName.Text = "[SiteName]";
            // 
            // txtSiteCode
            // 
            this.txtSiteCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSiteInformation, "SiteCode", true));
            this.txtSiteCode.Location = new System.Drawing.Point(134, 22);
            this.txtSiteCode.MaxLength = 4;
            this.txtSiteCode.Name = "txtSiteCode";
            this.txtSiteCode.Size = new System.Drawing.Size(48, 20);
            this.txtSiteCode.TabIndex = 0;
            this.txtSiteCode.TextChanged += new System.EventHandler(this.txtSiteCode_TextChanged);
            this.txtSiteCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtSiteCode_Validating);
            // 
            // tabBHHT
            // 
            this.tabBHHT.Controls.Add(this.chkAutoCreateRBOSOrdersFromBHHT);
            this.tabBHHT.Controls.Add(this.groupBox2);
            this.tabBHHT.Controls.Add(this.groupBHHTExport);
            this.tabBHHT.Controls.Add(this.lbAutoCreateRBOSOrdersFromBHHT);
            this.tabBHHT.Location = new System.Drawing.Point(4, 22);
            this.tabBHHT.Name = "tabBHHT";
            this.tabBHHT.Padding = new System.Windows.Forms.Padding(3);
            this.tabBHHT.Size = new System.Drawing.Size(366, 332);
            this.tabBHHT.TabIndex = 1;
            this.tabBHHT.Text = "BHHT";
            this.tabBHHT.UseVisualStyleBackColor = true;
            // 
            // chkAutoCreateRBOSOrdersFromBHHT
            // 
            this.chkAutoCreateRBOSOrdersFromBHHT.AutoSize = true;
            this.chkAutoCreateRBOSOrdersFromBHHT.Location = new System.Drawing.Point(214, 218);
            this.chkAutoCreateRBOSOrdersFromBHHT.Name = "chkAutoCreateRBOSOrdersFromBHHT";
            this.chkAutoCreateRBOSOrdersFromBHHT.Size = new System.Drawing.Size(15, 14);
            this.chkAutoCreateRBOSOrdersFromBHHT.TabIndex = 24;
            this.chkAutoCreateRBOSOrdersFromBHHT.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkBHHTImportBackupActive);
            this.groupBox2.Controls.Add(this.btnBHHTImportDir);
            this.groupBox2.Controls.Add(this.btnBHHTImportBackupDir);
            this.groupBox2.Controls.Add(this.txtBHHTImportDir);
            this.groupBox2.Controls.Add(this.lbBHHTImportDir);
            this.groupBox2.Controls.Add(this.txtBHHTImportBackupDir);
            this.groupBox2.Controls.Add(this.lbBHHTImportBackupDir);
            this.groupBox2.Controls.Add(this.lbBHHTImportBackupActive);
            this.groupBox2.Location = new System.Drawing.Point(6, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 96);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BHHT Import";
            // 
            // chkBHHTImportBackupActive
            // 
            this.chkBHHTImportBackupActive.AutoSize = true;
            this.chkBHHTImportBackupActive.Location = new System.Drawing.Point(118, 71);
            this.chkBHHTImportBackupActive.Name = "chkBHHTImportBackupActive";
            this.chkBHHTImportBackupActive.Size = new System.Drawing.Size(15, 14);
            this.chkBHHTImportBackupActive.TabIndex = 17;
            this.chkBHHTImportBackupActive.UseVisualStyleBackColor = true;
            // 
            // btnBHHTImportDir
            // 
            this.btnBHHTImportDir.Location = new System.Drawing.Point(320, 17);
            this.btnBHHTImportDir.Name = "btnBHHTImportDir";
            this.btnBHHTImportDir.Size = new System.Drawing.Size(28, 23);
            this.btnBHHTImportDir.TabIndex = 16;
            this.btnBHHTImportDir.Text = "...";
            this.btnBHHTImportDir.UseVisualStyleBackColor = true;
            this.btnBHHTImportDir.Click += new System.EventHandler(this.btnBHHTImportDir_Click);
            // 
            // btnBHHTImportBackupDir
            // 
            this.btnBHHTImportBackupDir.Location = new System.Drawing.Point(320, 43);
            this.btnBHHTImportBackupDir.Name = "btnBHHTImportBackupDir";
            this.btnBHHTImportBackupDir.Size = new System.Drawing.Size(28, 23);
            this.btnBHHTImportBackupDir.TabIndex = 15;
            this.btnBHHTImportBackupDir.Text = "...";
            this.btnBHHTImportBackupDir.UseVisualStyleBackColor = true;
            this.btnBHHTImportBackupDir.Click += new System.EventHandler(this.btnBHHTImportBackupDir_Click);
            // 
            // txtBHHTImportDir
            // 
            this.txtBHHTImportDir.Location = new System.Drawing.Point(118, 19);
            this.txtBHHTImportDir.Name = "txtBHHTImportDir";
            this.txtBHHTImportDir.Size = new System.Drawing.Size(196, 20);
            this.txtBHHTImportDir.TabIndex = 14;
            this.txtBHHTImportDir.Leave += new System.EventHandler(this.txtBHHTImportDir_Leave);
            // 
            // lbBHHTImportDir
            // 
            this.lbBHHTImportDir.AutoSize = true;
            this.lbBHHTImportDir.Location = new System.Drawing.Point(6, 22);
            this.lbBHHTImportDir.Name = "lbBHHTImportDir";
            this.lbBHHTImportDir.Size = new System.Drawing.Size(84, 13);
            this.lbBHHTImportDir.TabIndex = 1;
            this.lbBHHTImportDir.Text = "[Import Directory";
            // 
            // txtBHHTImportBackupDir
            // 
            this.txtBHHTImportBackupDir.Location = new System.Drawing.Point(118, 45);
            this.txtBHHTImportBackupDir.Name = "txtBHHTImportBackupDir";
            this.txtBHHTImportBackupDir.Size = new System.Drawing.Size(197, 20);
            this.txtBHHTImportBackupDir.TabIndex = 15;
            this.txtBHHTImportBackupDir.Leave += new System.EventHandler(this.txtBHHTImportBackupDir_Leave);
            // 
            // lbBHHTImportBackupDir
            // 
            this.lbBHHTImportBackupDir.AutoSize = true;
            this.lbBHHTImportBackupDir.Location = new System.Drawing.Point(6, 48);
            this.lbBHHTImportBackupDir.Name = "lbBHHTImportBackupDir";
            this.lbBHHTImportBackupDir.Size = new System.Drawing.Size(93, 13);
            this.lbBHHTImportBackupDir.TabIndex = 2;
            this.lbBHHTImportBackupDir.Text = "[Backup directory]";
            // 
            // lbBHHTImportBackupActive
            // 
            this.lbBHHTImportBackupActive.AutoSize = true;
            this.lbBHHTImportBackupActive.Location = new System.Drawing.Point(7, 71);
            this.lbBHHTImportBackupActive.Name = "lbBHHTImportBackupActive";
            this.lbBHHTImportBackupActive.Size = new System.Drawing.Size(92, 13);
            this.lbBHHTImportBackupActive.TabIndex = 13;
            this.lbBHHTImportBackupActive.Text = "[Backup is active]";
            // 
            // groupBHHTExport
            // 
            this.groupBHHTExport.Controls.Add(this.chkBHHTExportBackupActive);
            this.groupBHHTExport.Controls.Add(this.btnBHHTExportDir);
            this.groupBHHTExport.Controls.Add(this.btnBHHTExportBackupDir);
            this.groupBHHTExport.Controls.Add(this.txtBHHTExportDir);
            this.groupBHHTExport.Controls.Add(this.lbBHHTExportDir);
            this.groupBHHTExport.Controls.Add(this.txtBHHTExportBackupDir);
            this.groupBHHTExport.Controls.Add(this.lbBHHTExportBackupDir);
            this.groupBHHTExport.Controls.Add(this.lbBHHTBackupDirActive);
            this.groupBHHTExport.Location = new System.Drawing.Point(6, 6);
            this.groupBHHTExport.Name = "groupBHHTExport";
            this.groupBHHTExport.Size = new System.Drawing.Size(354, 96);
            this.groupBHHTExport.TabIndex = 22;
            this.groupBHHTExport.TabStop = false;
            this.groupBHHTExport.Text = "[BHHTExport]";
            // 
            // chkBHHTExportBackupActive
            // 
            this.chkBHHTExportBackupActive.AutoSize = true;
            this.chkBHHTExportBackupActive.Location = new System.Drawing.Point(118, 71);
            this.chkBHHTExportBackupActive.Name = "chkBHHTExportBackupActive";
            this.chkBHHTExportBackupActive.Size = new System.Drawing.Size(15, 14);
            this.chkBHHTExportBackupActive.TabIndex = 17;
            this.chkBHHTExportBackupActive.UseVisualStyleBackColor = true;
            // 
            // btnBHHTExportDir
            // 
            this.btnBHHTExportDir.Location = new System.Drawing.Point(320, 17);
            this.btnBHHTExportDir.Name = "btnBHHTExportDir";
            this.btnBHHTExportDir.Size = new System.Drawing.Size(28, 23);
            this.btnBHHTExportDir.TabIndex = 16;
            this.btnBHHTExportDir.Text = "...";
            this.btnBHHTExportDir.UseVisualStyleBackColor = true;
            this.btnBHHTExportDir.Click += new System.EventHandler(this.btnBHHTExportDir_Click);
            // 
            // btnBHHTExportBackupDir
            // 
            this.btnBHHTExportBackupDir.Location = new System.Drawing.Point(320, 43);
            this.btnBHHTExportBackupDir.Name = "btnBHHTExportBackupDir";
            this.btnBHHTExportBackupDir.Size = new System.Drawing.Size(28, 23);
            this.btnBHHTExportBackupDir.TabIndex = 15;
            this.btnBHHTExportBackupDir.Text = "...";
            this.btnBHHTExportBackupDir.UseVisualStyleBackColor = true;
            this.btnBHHTExportBackupDir.Click += new System.EventHandler(this.btnBHHTExportBackupDir_Click);
            // 
            // txtBHHTExportDir
            // 
            this.txtBHHTExportDir.Location = new System.Drawing.Point(118, 19);
            this.txtBHHTExportDir.Name = "txtBHHTExportDir";
            this.txtBHHTExportDir.Size = new System.Drawing.Size(196, 20);
            this.txtBHHTExportDir.TabIndex = 14;
            this.txtBHHTExportDir.Leave += new System.EventHandler(this.txtBHHTExportDir_Leave);
            // 
            // lbBHHTExportDir
            // 
            this.lbBHHTExportDir.AutoSize = true;
            this.lbBHHTExportDir.Location = new System.Drawing.Point(6, 22);
            this.lbBHHTExportDir.Name = "lbBHHTExportDir";
            this.lbBHHTExportDir.Size = new System.Drawing.Size(85, 13);
            this.lbBHHTExportDir.TabIndex = 1;
            this.lbBHHTExportDir.Text = "[Export Directory";
            // 
            // txtBHHTExportBackupDir
            // 
            this.txtBHHTExportBackupDir.Location = new System.Drawing.Point(118, 45);
            this.txtBHHTExportBackupDir.Name = "txtBHHTExportBackupDir";
            this.txtBHHTExportBackupDir.Size = new System.Drawing.Size(197, 20);
            this.txtBHHTExportBackupDir.TabIndex = 15;
            this.txtBHHTExportBackupDir.Leave += new System.EventHandler(this.txtBHHTExportBackupDir_Leave);
            // 
            // lbBHHTExportBackupDir
            // 
            this.lbBHHTExportBackupDir.AutoSize = true;
            this.lbBHHTExportBackupDir.Location = new System.Drawing.Point(6, 48);
            this.lbBHHTExportBackupDir.Name = "lbBHHTExportBackupDir";
            this.lbBHHTExportBackupDir.Size = new System.Drawing.Size(93, 13);
            this.lbBHHTExportBackupDir.TabIndex = 2;
            this.lbBHHTExportBackupDir.Text = "[Backup directory]";
            // 
            // lbBHHTBackupDirActive
            // 
            this.lbBHHTBackupDirActive.AutoSize = true;
            this.lbBHHTBackupDirActive.Location = new System.Drawing.Point(7, 71);
            this.lbBHHTBackupDirActive.Name = "lbBHHTBackupDirActive";
            this.lbBHHTBackupDirActive.Size = new System.Drawing.Size(92, 13);
            this.lbBHHTBackupDirActive.TabIndex = 13;
            this.lbBHHTBackupDirActive.Text = "[Backup is active]";
            // 
            // lbAutoCreateRBOSOrdersFromBHHT
            // 
            this.lbAutoCreateRBOSOrdersFromBHHT.AutoSize = true;
            this.lbAutoCreateRBOSOrdersFromBHHT.Location = new System.Drawing.Point(6, 218);
            this.lbAutoCreateRBOSOrdersFromBHHT.Name = "lbAutoCreateRBOSOrdersFromBHHT";
            this.lbAutoCreateRBOSOrdersFromBHHT.Size = new System.Drawing.Size(192, 13);
            this.lbAutoCreateRBOSOrdersFromBHHT.TabIndex = 0;
            this.lbAutoCreateRBOSOrdersFromBHHT.Text = "[Auto Create RBOS Orders from BHHT]";
            // 
            // tabRSM
            // 
            this.tabRSM.Controls.Add(this.groupBox3);
            this.tabRSM.Controls.Add(this.groupBox4);
            this.tabRSM.Location = new System.Drawing.Point(4, 22);
            this.tabRSM.Name = "tabRSM";
            this.tabRSM.Padding = new System.Windows.Forms.Padding(3);
            this.tabRSM.Size = new System.Drawing.Size(366, 332);
            this.tabRSM.TabIndex = 2;
            this.tabRSM.Text = "RSM";
            this.tabRSM.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkRSMImportBackupActive);
            this.groupBox3.Controls.Add(this.btnRSMImportDir);
            this.groupBox3.Controls.Add(this.btnRSMImportBackupDir);
            this.groupBox3.Controls.Add(this.txtRSMImportDir);
            this.groupBox3.Controls.Add(this.lbRSMImportDir);
            this.groupBox3.Controls.Add(this.txtRSMImportBackupDir);
            this.groupBox3.Controls.Add(this.lbRSMImportBackupDir);
            this.groupBox3.Controls.Add(this.lbRSMImportBackupActive);
            this.groupBox3.Location = new System.Drawing.Point(6, 108);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(354, 96);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "RSM Import";
            // 
            // chkRSMImportBackupActive
            // 
            this.chkRSMImportBackupActive.AutoSize = true;
            this.chkRSMImportBackupActive.Location = new System.Drawing.Point(118, 71);
            this.chkRSMImportBackupActive.Name = "chkRSMImportBackupActive";
            this.chkRSMImportBackupActive.Size = new System.Drawing.Size(15, 14);
            this.chkRSMImportBackupActive.TabIndex = 17;
            this.chkRSMImportBackupActive.UseVisualStyleBackColor = true;
            // 
            // btnRSMImportDir
            // 
            this.btnRSMImportDir.Location = new System.Drawing.Point(320, 17);
            this.btnRSMImportDir.Name = "btnRSMImportDir";
            this.btnRSMImportDir.Size = new System.Drawing.Size(28, 23);
            this.btnRSMImportDir.TabIndex = 16;
            this.btnRSMImportDir.Text = "...";
            this.btnRSMImportDir.UseVisualStyleBackColor = true;
            this.btnRSMImportDir.Click += new System.EventHandler(this.btnRSMImportDir_Click);
            // 
            // btnRSMImportBackupDir
            // 
            this.btnRSMImportBackupDir.Location = new System.Drawing.Point(320, 43);
            this.btnRSMImportBackupDir.Name = "btnRSMImportBackupDir";
            this.btnRSMImportBackupDir.Size = new System.Drawing.Size(28, 23);
            this.btnRSMImportBackupDir.TabIndex = 15;
            this.btnRSMImportBackupDir.Text = "...";
            this.btnRSMImportBackupDir.UseVisualStyleBackColor = true;
            this.btnRSMImportBackupDir.Click += new System.EventHandler(this.btnRSMImportBackupDir_Click);
            // 
            // txtRSMImportDir
            // 
            this.txtRSMImportDir.Location = new System.Drawing.Point(118, 19);
            this.txtRSMImportDir.Name = "txtRSMImportDir";
            this.txtRSMImportDir.Size = new System.Drawing.Size(196, 20);
            this.txtRSMImportDir.TabIndex = 14;
            this.txtRSMImportDir.Leave += new System.EventHandler(this.txtRSMImportDir_Leave);
            // 
            // lbRSMImportDir
            // 
            this.lbRSMImportDir.AutoSize = true;
            this.lbRSMImportDir.Location = new System.Drawing.Point(6, 22);
            this.lbRSMImportDir.Name = "lbRSMImportDir";
            this.lbRSMImportDir.Size = new System.Drawing.Size(84, 13);
            this.lbRSMImportDir.TabIndex = 1;
            this.lbRSMImportDir.Text = "[Import Directory";
            // 
            // txtRSMImportBackupDir
            // 
            this.txtRSMImportBackupDir.Location = new System.Drawing.Point(118, 45);
            this.txtRSMImportBackupDir.Name = "txtRSMImportBackupDir";
            this.txtRSMImportBackupDir.Size = new System.Drawing.Size(197, 20);
            this.txtRSMImportBackupDir.TabIndex = 15;
            this.txtRSMImportBackupDir.Leave += new System.EventHandler(this.txtRSMImportBackupDir_Leave);
            // 
            // lbRSMImportBackupDir
            // 
            this.lbRSMImportBackupDir.AutoSize = true;
            this.lbRSMImportBackupDir.Location = new System.Drawing.Point(6, 48);
            this.lbRSMImportBackupDir.Name = "lbRSMImportBackupDir";
            this.lbRSMImportBackupDir.Size = new System.Drawing.Size(93, 13);
            this.lbRSMImportBackupDir.TabIndex = 2;
            this.lbRSMImportBackupDir.Text = "[Backup directory]";
            // 
            // lbRSMImportBackupActive
            // 
            this.lbRSMImportBackupActive.AutoSize = true;
            this.lbRSMImportBackupActive.Location = new System.Drawing.Point(7, 71);
            this.lbRSMImportBackupActive.Name = "lbRSMImportBackupActive";
            this.lbRSMImportBackupActive.Size = new System.Drawing.Size(92, 13);
            this.lbRSMImportBackupActive.TabIndex = 13;
            this.lbRSMImportBackupActive.Text = "[Backup is active]";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkRSMExportBackupActive);
            this.groupBox4.Controls.Add(this.btnRSMExportDir);
            this.groupBox4.Controls.Add(this.btnRSMExportBackupDir);
            this.groupBox4.Controls.Add(this.txtRSMExportDir);
            this.groupBox4.Controls.Add(this.lbRSMExportDir);
            this.groupBox4.Controls.Add(this.txtRSMExportBackupDir);
            this.groupBox4.Controls.Add(this.lbRSMExportBackupDir);
            this.groupBox4.Controls.Add(this.lbRSMExportBackupActive);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(354, 96);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "RSM Export";
            // 
            // chkRSMExportBackupActive
            // 
            this.chkRSMExportBackupActive.AutoSize = true;
            this.chkRSMExportBackupActive.Location = new System.Drawing.Point(118, 71);
            this.chkRSMExportBackupActive.Name = "chkRSMExportBackupActive";
            this.chkRSMExportBackupActive.Size = new System.Drawing.Size(15, 14);
            this.chkRSMExportBackupActive.TabIndex = 17;
            this.chkRSMExportBackupActive.UseVisualStyleBackColor = true;
            // 
            // btnRSMExportDir
            // 
            this.btnRSMExportDir.Location = new System.Drawing.Point(320, 17);
            this.btnRSMExportDir.Name = "btnRSMExportDir";
            this.btnRSMExportDir.Size = new System.Drawing.Size(28, 23);
            this.btnRSMExportDir.TabIndex = 16;
            this.btnRSMExportDir.Text = "...";
            this.btnRSMExportDir.UseVisualStyleBackColor = true;
            this.btnRSMExportDir.Click += new System.EventHandler(this.btnRSMExportDir_Click);
            // 
            // btnRSMExportBackupDir
            // 
            this.btnRSMExportBackupDir.Location = new System.Drawing.Point(320, 43);
            this.btnRSMExportBackupDir.Name = "btnRSMExportBackupDir";
            this.btnRSMExportBackupDir.Size = new System.Drawing.Size(28, 23);
            this.btnRSMExportBackupDir.TabIndex = 15;
            this.btnRSMExportBackupDir.Text = "...";
            this.btnRSMExportBackupDir.UseVisualStyleBackColor = true;
            this.btnRSMExportBackupDir.Click += new System.EventHandler(this.btnRSMExportBackupDir_Click);
            // 
            // txtRSMExportDir
            // 
            this.txtRSMExportDir.Location = new System.Drawing.Point(118, 19);
            this.txtRSMExportDir.Name = "txtRSMExportDir";
            this.txtRSMExportDir.Size = new System.Drawing.Size(196, 20);
            this.txtRSMExportDir.TabIndex = 14;
            this.txtRSMExportDir.Leave += new System.EventHandler(this.txtRSMExportDir_Leave);
            // 
            // lbRSMExportDir
            // 
            this.lbRSMExportDir.AutoSize = true;
            this.lbRSMExportDir.Location = new System.Drawing.Point(6, 22);
            this.lbRSMExportDir.Name = "lbRSMExportDir";
            this.lbRSMExportDir.Size = new System.Drawing.Size(85, 13);
            this.lbRSMExportDir.TabIndex = 1;
            this.lbRSMExportDir.Text = "[Export Directory";
            // 
            // txtRSMExportBackupDir
            // 
            this.txtRSMExportBackupDir.Location = new System.Drawing.Point(118, 45);
            this.txtRSMExportBackupDir.Name = "txtRSMExportBackupDir";
            this.txtRSMExportBackupDir.Size = new System.Drawing.Size(197, 20);
            this.txtRSMExportBackupDir.TabIndex = 15;
            this.txtRSMExportBackupDir.Leave += new System.EventHandler(this.txtRSMExportBackupDir_Leave);
            // 
            // lbRSMExportBackupDir
            // 
            this.lbRSMExportBackupDir.AutoSize = true;
            this.lbRSMExportBackupDir.Location = new System.Drawing.Point(6, 48);
            this.lbRSMExportBackupDir.Name = "lbRSMExportBackupDir";
            this.lbRSMExportBackupDir.Size = new System.Drawing.Size(93, 13);
            this.lbRSMExportBackupDir.TabIndex = 2;
            this.lbRSMExportBackupDir.Text = "[Backup directory]";
            // 
            // lbRSMExportBackupActive
            // 
            this.lbRSMExportBackupActive.AutoSize = true;
            this.lbRSMExportBackupActive.Location = new System.Drawing.Point(7, 71);
            this.lbRSMExportBackupActive.Name = "lbRSMExportBackupActive";
            this.lbRSMExportBackupActive.Size = new System.Drawing.Size(92, 13);
            this.lbRSMExportBackupActive.TabIndex = 13;
            this.lbRSMExportBackupActive.Text = "[Backup is active]";
            // 
            // tabMisc
            // 
            this.tabMisc.Controls.Add(this.groupDebtor);
            this.tabMisc.Controls.Add(this.groupLastCreatedPrlFile);
            this.tabMisc.Controls.Add(this.groupReadings);
            this.tabMisc.Controls.Add(this.groupACN);
            this.tabMisc.Location = new System.Drawing.Point(4, 22);
            this.tabMisc.Name = "tabMisc";
            this.tabMisc.Padding = new System.Windows.Forms.Padding(3);
            this.tabMisc.Size = new System.Drawing.Size(366, 332);
            this.tabMisc.TabIndex = 3;
            this.tabMisc.Text = "[Miscellaneous]";
            this.tabMisc.UseVisualStyleBackColor = true;
            // 
            // groupDebtor
            // 
            this.groupDebtor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupDebtor.Controls.Add(this.lbStandardDebtorStatementRemarks);
            this.groupDebtor.Controls.Add(this.txtStandardDebtorStatementRemarks);
            this.groupDebtor.Location = new System.Drawing.Point(6, 153);
            this.groupDebtor.Name = "groupDebtor";
            this.groupDebtor.Size = new System.Drawing.Size(354, 92);
            this.groupDebtor.TabIndex = 7;
            this.groupDebtor.TabStop = false;
            this.groupDebtor.Text = "[Debitor]";
            // 
            // lbStandardDebtorStatementRemarks
            // 
            this.lbStandardDebtorStatementRemarks.AutoSize = true;
            this.lbStandardDebtorStatementRemarks.Location = new System.Drawing.Point(6, 16);
            this.lbStandardDebtorStatementRemarks.Name = "lbStandardDebtorStatementRemarks";
            this.lbStandardDebtorStatementRemarks.Size = new System.Drawing.Size(222, 13);
            this.lbStandardDebtorStatementRemarks.TabIndex = 1;
            this.lbStandardDebtorStatementRemarks.Text = "[Standard bemærkning på debitor kontoudtog";
            // 
            // txtStandardDebtorStatementRemarks
            // 
            this.txtStandardDebtorStatementRemarks.Location = new System.Drawing.Point(6, 33);
            this.txtStandardDebtorStatementRemarks.Multiline = true;
            this.txtStandardDebtorStatementRemarks.Name = "txtStandardDebtorStatementRemarks";
            this.txtStandardDebtorStatementRemarks.Size = new System.Drawing.Size(342, 53);
            this.txtStandardDebtorStatementRemarks.TabIndex = 0;
            // 
            // groupLastCreatedPrlFile
            // 
            this.groupLastCreatedPrlFile.Controls.Add(this.lbLastCreatedPrlFile_Timestamp);
            this.groupLastCreatedPrlFile.Controls.Add(this.txtLastCreatedPrlFile_Year);
            this.groupLastCreatedPrlFile.Controls.Add(this.txtLastCreatedPrlFile_Period);
            this.groupLastCreatedPrlFile.Controls.Add(this.lbLastCreatedPrlFile);
            this.groupLastCreatedPrlFile.Location = new System.Drawing.Point(6, 6);
            this.groupLastCreatedPrlFile.Name = "groupLastCreatedPrlFile";
            this.groupLastCreatedPrlFile.Size = new System.Drawing.Size(354, 56);
            this.groupLastCreatedPrlFile.TabIndex = 6;
            this.groupLastCreatedPrlFile.TabStop = false;
            this.groupLastCreatedPrlFile.Text = "[Sidst lønfil dannet]";
            // 
            // lbLastCreatedPrlFile_Timestamp
            // 
            this.lbLastCreatedPrlFile_Timestamp.AutoSize = true;
            this.lbLastCreatedPrlFile_Timestamp.Location = new System.Drawing.Point(194, 26);
            this.lbLastCreatedPrlFile_Timestamp.Name = "lbLastCreatedPrlFile_Timestamp";
            this.lbLastCreatedPrlFile_Timestamp.Size = new System.Drawing.Size(66, 13);
            this.lbLastCreatedPrlFile_Timestamp.TabIndex = 3;
            this.lbLastCreatedPrlFile_Timestamp.Text = "<timestamp>";
            // 
            // txtLastCreatedPrlFile_Year
            // 
            this.txtLastCreatedPrlFile_Year.Location = new System.Drawing.Point(151, 23);
            this.txtLastCreatedPrlFile_Year.Name = "txtLastCreatedPrlFile_Year";
            this.txtLastCreatedPrlFile_Year.ReadOnly = true;
            this.txtLastCreatedPrlFile_Year.Size = new System.Drawing.Size(37, 20);
            this.txtLastCreatedPrlFile_Year.TabIndex = 1;
            this.txtLastCreatedPrlFile_Year.TabStop = false;
            // 
            // txtLastCreatedPrlFile_Period
            // 
            this.txtLastCreatedPrlFile_Period.Location = new System.Drawing.Point(123, 23);
            this.txtLastCreatedPrlFile_Period.Name = "txtLastCreatedPrlFile_Period";
            this.txtLastCreatedPrlFile_Period.ReadOnly = true;
            this.txtLastCreatedPrlFile_Period.Size = new System.Drawing.Size(22, 20);
            this.txtLastCreatedPrlFile_Period.TabIndex = 0;
            this.txtLastCreatedPrlFile_Period.TabStop = false;
            // 
            // lbLastCreatedPrlFile
            // 
            this.lbLastCreatedPrlFile.AutoSize = true;
            this.lbLastCreatedPrlFile.Location = new System.Drawing.Point(6, 26);
            this.lbLastCreatedPrlFile.Name = "lbLastCreatedPrlFile";
            this.lbLastCreatedPrlFile.Size = new System.Drawing.Size(102, 13);
            this.lbLastCreatedPrlFile.TabIndex = 0;
            this.lbLastCreatedPrlFile.Text = "[Sidste lønfil dannet]";
            // 
            // groupReadings
            // 
            this.groupReadings.Controls.Add(this.chkVaskeafstemning2);
            this.groupReadings.Controls.Add(this.chkVaskeafstemning3);
            this.groupReadings.Controls.Add(this.chkStationHasWash);
            this.groupReadings.Controls.Add(this.chkWashSeperateReadings);
            this.groupReadings.Location = new System.Drawing.Point(6, 251);
            this.groupReadings.Name = "groupReadings";
            this.groupReadings.Size = new System.Drawing.Size(354, 73);
            this.groupReadings.TabIndex = 5;
            this.groupReadings.TabStop = false;
            this.groupReadings.Text = "[Aflæsninger]";
            // 
            // chkVaskeafstemning2
            // 
            this.chkVaskeafstemning2.AutoSize = true;
            this.chkVaskeafstemning2.Location = new System.Drawing.Point(197, 22);
            this.chkVaskeafstemning2.Name = "chkVaskeafstemning2";
            this.chkVaskeafstemning2.Size = new System.Drawing.Size(122, 17);
            this.chkVaskeafstemning2.TabIndex = 2;
            this.chkVaskeafstemning2.Text = "[Vaskeafstemning 2]";
            this.chkVaskeafstemning2.UseVisualStyleBackColor = true;
            // 
            // chkVaskeafstemning3
            // 
            this.chkVaskeafstemning3.AutoSize = true;
            this.chkVaskeafstemning3.Location = new System.Drawing.Point(197, 45);
            this.chkVaskeafstemning3.Name = "chkVaskeafstemning3";
            this.chkVaskeafstemning3.Size = new System.Drawing.Size(122, 17);
            this.chkVaskeafstemning3.TabIndex = 3;
            this.chkVaskeafstemning3.Text = "[Vaskeafstemning 3]";
            this.chkVaskeafstemning3.UseVisualStyleBackColor = true;
            // 
            // chkStationHasWash
            // 
            this.chkStationHasWash.AutoSize = true;
            this.chkStationHasWash.Location = new System.Drawing.Point(7, 45);
            this.chkStationHasWash.Name = "chkStationHasWash";
            this.chkStationHasWash.Size = new System.Drawing.Size(121, 17);
            this.chkStationHasWash.TabIndex = 1;
            this.chkStationHasWash.Text = "[Stationen har vask]";
            this.chkStationHasWash.UseVisualStyleBackColor = true;
            // 
            // chkWashSeperateReadings
            // 
            this.chkWashSeperateReadings.AutoSize = true;
            this.chkWashSeperateReadings.Location = new System.Drawing.Point(7, 22);
            this.chkWashSeperateReadings.Name = "chkWashSeperateReadings";
            this.chkWashSeperateReadings.Size = new System.Drawing.Size(148, 17);
            this.chkWashSeperateReadings.TabIndex = 0;
            this.chkWashSeperateReadings.Text = "[Seperat vandmåler Vask]";
            this.chkWashSeperateReadings.UseVisualStyleBackColor = true;
            // 
            // groupACN
            // 
            this.groupACN.Controls.Add(this.chkACNEnabled);
            this.groupACN.Controls.Add(this.txtACNLastExportedWeek);
            this.groupACN.Controls.Add(this.lbACNLastExported);
            this.groupACN.Controls.Add(this.txtACNLastExportedYear);
            this.groupACN.Location = new System.Drawing.Point(6, 68);
            this.groupACN.Name = "groupACN";
            this.groupACN.Size = new System.Drawing.Size(354, 79);
            this.groupACN.TabIndex = 4;
            this.groupACN.TabStop = false;
            this.groupACN.Text = "[AC Nielsen]";
            // 
            // chkACNEnabled
            // 
            this.chkACNEnabled.AutoSize = true;
            this.chkACNEnabled.Location = new System.Drawing.Point(6, 19);
            this.chkACNEnabled.Name = "chkACNEnabled";
            this.chkACNEnabled.Size = new System.Drawing.Size(182, 17);
            this.chkACNEnabled.TabIndex = 0;
            this.chkACNEnabled.Text = "[Eksportér ugesalg til AC Nielsen]";
            this.chkACNEnabled.UseVisualStyleBackColor = true;
            // 
            // txtACNLastExportedWeek
            // 
            this.txtACNLastExportedWeek.Location = new System.Drawing.Point(180, 47);
            this.txtACNLastExportedWeek.Name = "txtACNLastExportedWeek";
            this.txtACNLastExportedWeek.ReadOnly = true;
            this.txtACNLastExportedWeek.Size = new System.Drawing.Size(22, 20);
            this.txtACNLastExportedWeek.TabIndex = 1;
            this.txtACNLastExportedWeek.TabStop = false;
            // 
            // lbACNLastExported
            // 
            this.lbACNLastExported.AutoSize = true;
            this.lbACNLastExported.Location = new System.Drawing.Point(3, 50);
            this.lbACNLastExported.Name = "lbACNLastExported";
            this.lbACNLastExported.Size = new System.Drawing.Size(142, 13);
            this.lbACNLastExported.TabIndex = 1;
            this.lbACNLastExported.Text = "[Sidste eksporterede uge/år]";
            // 
            // txtACNLastExportedYear
            // 
            this.txtACNLastExportedYear.Location = new System.Drawing.Point(208, 47);
            this.txtACNLastExportedYear.Name = "txtACNLastExportedYear";
            this.txtACNLastExportedYear.ReadOnly = true;
            this.txtACNLastExportedYear.Size = new System.Drawing.Size(36, 20);
            this.txtACNLastExportedYear.TabIndex = 2;
            this.txtACNLastExportedYear.TabStop = false;
            // 
            // tabSafePay
            // 
            this.tabSafePay.Controls.Add(this.comboSafePayByttepengeOptaltInterval);
            this.tabSafePay.Controls.Add(this.lbSafePayByttepengeOptaltInterval);
            this.tabSafePay.Controls.Add(this.GroupSafePayValutakurser);
            this.tabSafePay.Location = new System.Drawing.Point(4, 22);
            this.tabSafePay.Name = "tabSafePay";
            this.tabSafePay.Padding = new System.Windows.Forms.Padding(3);
            this.tabSafePay.Size = new System.Drawing.Size(366, 332);
            this.tabSafePay.TabIndex = 4;
            this.tabSafePay.Text = "[SafePay]";
            this.tabSafePay.UseVisualStyleBackColor = true;
            // 
            // comboSafePayByttepengeOptaltInterval
            // 
            this.comboSafePayByttepengeOptaltInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSafePayByttepengeOptaltInterval.FormattingEnabled = true;
            this.comboSafePayByttepengeOptaltInterval.Location = new System.Drawing.Point(171, 78);
            this.comboSafePayByttepengeOptaltInterval.Name = "comboSafePayByttepengeOptaltInterval";
            this.comboSafePayByttepengeOptaltInterval.Size = new System.Drawing.Size(121, 21);
            this.comboSafePayByttepengeOptaltInterval.TabIndex = 12;
            // 
            // lbSafePayByttepengeOptaltInterval
            // 
            this.lbSafePayByttepengeOptaltInterval.AutoSize = true;
            this.lbSafePayByttepengeOptaltInterval.Location = new System.Drawing.Point(6, 81);
            this.lbSafePayByttepengeOptaltInterval.Name = "lbSafePayByttepengeOptaltInterval";
            this.lbSafePayByttepengeOptaltInterval.Size = new System.Drawing.Size(133, 13);
            this.lbSafePayByttepengeOptaltInterval.TabIndex = 11;
            this.lbSafePayByttepengeOptaltInterval.Text = "[Byttepenge optalt interval]";
            // 
            // GroupSafePayValutakurser
            // 
            this.GroupSafePayValutakurser.Controls.Add(this.txtSafePay_ValutaISO_SEK);
            this.GroupSafePayValutakurser.Controls.Add(this.txtSafePay_ValutaISO_NOK);
            this.GroupSafePayValutakurser.Controls.Add(this.txtSafePay_ValutaISO_EURO);
            this.GroupSafePayValutakurser.Controls.Add(this.lbSafePay_ValutaISO_NOK);
            this.GroupSafePayValutakurser.Controls.Add(this.lbSafePay_ValutaISO_SEK);
            this.GroupSafePayValutakurser.Controls.Add(this.lbSafePay_ValutaISO_EURO);
            this.GroupSafePayValutakurser.Location = new System.Drawing.Point(6, 6);
            this.GroupSafePayValutakurser.Name = "GroupSafePayValutakurser";
            this.GroupSafePayValutakurser.Size = new System.Drawing.Size(354, 56);
            this.GroupSafePayValutakurser.TabIndex = 9;
            this.GroupSafePayValutakurser.TabStop = false;
            this.GroupSafePayValutakurser.Text = "[Valutakurser]";
            // 
            // txtSafePay_ValutaISO_SEK
            // 
            this.txtSafePay_ValutaISO_SEK.Location = new System.Drawing.Point(267, 22);
            this.txtSafePay_ValutaISO_SEK.Mask = "99.99";
            this.txtSafePay_ValutaISO_SEK.Name = "txtSafePay_ValutaISO_SEK";
            this.txtSafePay_ValutaISO_SEK.PromptChar = '0';
            this.txtSafePay_ValutaISO_SEK.Size = new System.Drawing.Size(35, 20);
            this.txtSafePay_ValutaISO_SEK.TabIndex = 15;
            this.txtSafePay_ValutaISO_SEK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSafePay_ValutaISO_SEK.ValidatingType = typeof(int);
            // 
            // txtSafePay_ValutaISO_NOK
            // 
            this.txtSafePay_ValutaISO_NOK.Location = new System.Drawing.Point(161, 22);
            this.txtSafePay_ValutaISO_NOK.Mask = "99.99";
            this.txtSafePay_ValutaISO_NOK.Name = "txtSafePay_ValutaISO_NOK";
            this.txtSafePay_ValutaISO_NOK.PromptChar = '0';
            this.txtSafePay_ValutaISO_NOK.Size = new System.Drawing.Size(35, 20);
            this.txtSafePay_ValutaISO_NOK.TabIndex = 14;
            this.txtSafePay_ValutaISO_NOK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSafePay_ValutaISO_NOK.ValidatingType = typeof(int);
            // 
            // txtSafePay_ValutaISO_EURO
            // 
            this.txtSafePay_ValutaISO_EURO.Location = new System.Drawing.Point(55, 22);
            this.txtSafePay_ValutaISO_EURO.Mask = "99.99";
            this.txtSafePay_ValutaISO_EURO.Name = "txtSafePay_ValutaISO_EURO";
            this.txtSafePay_ValutaISO_EURO.PromptChar = '0';
            this.txtSafePay_ValutaISO_EURO.Size = new System.Drawing.Size(35, 20);
            this.txtSafePay_ValutaISO_EURO.TabIndex = 13;
            this.txtSafePay_ValutaISO_EURO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSafePay_ValutaISO_EURO.ValidatingType = typeof(int);
            // 
            // lbSafePay_ValutaISO_NOK
            // 
            this.lbSafePay_ValutaISO_NOK.AutoSize = true;
            this.lbSafePay_ValutaISO_NOK.Location = new System.Drawing.Point(125, 25);
            this.lbSafePay_ValutaISO_NOK.Name = "lbSafePay_ValutaISO_NOK";
            this.lbSafePay_ValutaISO_NOK.Size = new System.Drawing.Size(30, 13);
            this.lbSafePay_ValutaISO_NOK.TabIndex = 4;
            this.lbSafePay_ValutaISO_NOK.Text = "NOK";
            // 
            // lbSafePay_ValutaISO_SEK
            // 
            this.lbSafePay_ValutaISO_SEK.AutoSize = true;
            this.lbSafePay_ValutaISO_SEK.Location = new System.Drawing.Point(233, 25);
            this.lbSafePay_ValutaISO_SEK.Name = "lbSafePay_ValutaISO_SEK";
            this.lbSafePay_ValutaISO_SEK.Size = new System.Drawing.Size(28, 13);
            this.lbSafePay_ValutaISO_SEK.TabIndex = 2;
            this.lbSafePay_ValutaISO_SEK.Text = "SEK";
            // 
            // lbSafePay_ValutaISO_EURO
            // 
            this.lbSafePay_ValutaISO_EURO.AutoSize = true;
            this.lbSafePay_ValutaISO_EURO.Location = new System.Drawing.Point(11, 25);
            this.lbSafePay_ValutaISO_EURO.Name = "lbSafePay_ValutaISO_EURO";
            this.lbSafePay_ValutaISO_EURO.Size = new System.Drawing.Size(38, 13);
            this.lbSafePay_ValutaISO_EURO.TabIndex = 0;
            this.lbSafePay_ValutaISO_EURO.Text = "EURO";
            // 
            // tabEconomics
            // 
            this.tabEconomics.Controls.Add(this.txtPassword);
            this.tabEconomics.Controls.Add(this.txtUserName);
            this.tabEconomics.Controls.Add(this.txtAftaleID);
            this.tabEconomics.Controls.Add(this.lblPassword);
            this.tabEconomics.Controls.Add(this.lblUserName);
            this.tabEconomics.Controls.Add(this.lblAftaleID);
            this.tabEconomics.Location = new System.Drawing.Point(4, 22);
            this.tabEconomics.Name = "tabEconomics";
            this.tabEconomics.Size = new System.Drawing.Size(366, 332);
            this.tabEconomics.TabIndex = 5;
            this.tabEconomics.Text = "[Economics]";
            this.tabEconomics.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSiteInformation, "EconomicsUserPassword", true));
            this.txtPassword.Location = new System.Drawing.Point(119, 70);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // txtUserName
            // 
            this.txtUserName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSiteInformation, "EconomicsUserID", true));
            this.txtUserName.Location = new System.Drawing.Point(119, 44);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 20);
            this.txtUserName.TabIndex = 4;
            // 
            // txtAftaleID
            // 
            this.txtAftaleID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSiteInformation, "EconomicsAftaleID", true));
            this.txtAftaleID.Location = new System.Drawing.Point(119, 18);
            this.txtAftaleID.Name = "txtAftaleID";
            this.txtAftaleID.Size = new System.Drawing.Size(100, 20);
            this.txtAftaleID.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(7, 77);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(59, 13);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "[Password]";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(7, 51);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(63, 13);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "[UserName]";
            // 
            // lblAftaleID
            // 
            this.lblAftaleID.AutoSize = true;
            this.lblAftaleID.Location = new System.Drawing.Point(7, 25);
            this.lblAftaleID.Name = "lblAftaleID";
            this.lblAftaleID.Size = new System.Drawing.Size(51, 13);
            this.lblAftaleID.TabIndex = 0;
            this.lblAftaleID.Text = "[AftaleID]";
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveClose.Location = new System.Drawing.Point(187, 376);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(118, 23);
            this.btnSaveClose.TabIndex = 0;
            this.btnSaveClose.Text = "[Save and Close]";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(311, 376);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "[Cancel]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // adapterSiteInformation
            // 
            this.adapterSiteInformation.ClearBeforeFill = true;
            // 
            // SiteInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 411);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveClose);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SiteInformationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SiteInformationForm";
            this.Load += new System.EventHandler(this.SiteInformation_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSiteInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAdmin)).EndInit();
            this.tabBHHT.ResumeLayout(false);
            this.tabBHHT.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBHHTExport.ResumeLayout(false);
            this.groupBHHTExport.PerformLayout();
            this.tabRSM.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabMisc.ResumeLayout(false);
            this.groupDebtor.ResumeLayout(false);
            this.groupDebtor.PerformLayout();
            this.groupLastCreatedPrlFile.ResumeLayout(false);
            this.groupLastCreatedPrlFile.PerformLayout();
            this.groupReadings.ResumeLayout(false);
            this.groupReadings.PerformLayout();
            this.groupACN.ResumeLayout(false);
            this.groupACN.PerformLayout();
            this.tabSafePay.ResumeLayout(false);
            this.tabSafePay.PerformLayout();
            this.GroupSafePayValutakurser.ResumeLayout(false);
            this.GroupSafePayValutakurser.PerformLayout();
            this.tabEconomics.ResumeLayout(false);
            this.tabEconomics.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AdminDataSet dsAdmin;
        private System.Windows.Forms.BindingSource bindingSiteInformation;
        private RBOS.AdminDataSetTableAdapters.SiteInformationTableAdapter adapterSiteInformation;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.Button btnSaveClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbSiteName;
        private System.Windows.Forms.TextBox txtSiteCode;
        private System.Windows.Forms.Label lbSiteCode;
        private System.Windows.Forms.TextBox txtSiteName;
        private System.Windows.Forms.Label lbAddress1;
        private System.Windows.Forms.TextBox txtAdress1;
        private System.Windows.Forms.Label lbZipCity;
        private System.Windows.Forms.TextBox txtZipCode;
        private System.Windows.Forms.Label lbAddress2;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lbFaxNo;
        private System.Windows.Forms.TextBox txtFaxNo;
        private System.Windows.Forms.Label lbTelephone;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label lbSENo;
        private System.Windows.Forms.TextBox txtSENo;
        private System.Windows.Forms.Label lbNorddataKundenr;
        private System.Windows.Forms.TextBox txtNorddataKundenr;
        private System.Windows.Forms.TabPage tabBHHT;
        private System.Windows.Forms.GroupBox groupBHHTExport;
        private System.Windows.Forms.TextBox txtBHHTExportDir;
        private System.Windows.Forms.Label lbBHHTExportDir;
        private System.Windows.Forms.TextBox txtBHHTExportBackupDir;
        private System.Windows.Forms.Label lbBHHTBackupDirActive;
        private System.Windows.Forms.Label lbBHHTExportBackupDir;
        private System.Windows.Forms.Label lbAutoCreateRBOSOrdersFromBHHT;
        private System.Windows.Forms.CheckBox chkBHHTExportBackupActive;
        private System.Windows.Forms.Button btnBHHTExportDir;
        private System.Windows.Forms.Button btnBHHTExportBackupDir;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkBHHTImportBackupActive;
        private System.Windows.Forms.Button btnBHHTImportDir;
        private System.Windows.Forms.Button btnBHHTImportBackupDir;
        private System.Windows.Forms.TextBox txtBHHTImportDir;
        private System.Windows.Forms.Label lbBHHTImportDir;
        private System.Windows.Forms.TextBox txtBHHTImportBackupDir;
        private System.Windows.Forms.Label lbBHHTImportBackupDir;
        private System.Windows.Forms.Label lbBHHTImportBackupActive;
        private System.Windows.Forms.TabPage tabRSM;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkRSMImportBackupActive;
        private System.Windows.Forms.Button btnRSMImportDir;
        private System.Windows.Forms.Button btnRSMImportBackupDir;
        private System.Windows.Forms.TextBox txtRSMImportDir;
        private System.Windows.Forms.Label lbRSMImportDir;
        private System.Windows.Forms.TextBox txtRSMImportBackupDir;
        private System.Windows.Forms.Label lbRSMImportBackupDir;
        private System.Windows.Forms.Label lbRSMImportBackupActive;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkRSMExportBackupActive;
        private System.Windows.Forms.Button btnRSMExportDir;
        private System.Windows.Forms.Button btnRSMExportBackupDir;
        private System.Windows.Forms.TextBox txtRSMExportDir;
        private System.Windows.Forms.Label lbRSMExportDir;
        private System.Windows.Forms.TextBox txtRSMExportBackupDir;
        private System.Windows.Forms.Label lbRSMExportBackupDir;
        private System.Windows.Forms.Label lbRSMExportBackupActive;
        private System.Windows.Forms.CheckBox chkAutoCreateRBOSOrdersFromBHHT;
        private System.Windows.Forms.FolderBrowserDialog folder;
        private System.Windows.Forms.TabPage tabMisc;
        private System.Windows.Forms.Label lbACNLastExported;
        private System.Windows.Forms.CheckBox chkACNEnabled;
        private System.Windows.Forms.TextBox txtACNLastExportedYear;
        private System.Windows.Forms.TextBox txtACNLastExportedWeek;
        private System.Windows.Forms.GroupBox groupACN;
        private System.Windows.Forms.Label lbBankAccount;
        private System.Windows.Forms.TextBox txtBankAccount;
        private System.Windows.Forms.GroupBox groupReadings;
        private System.Windows.Forms.CheckBox chkWashSeperateReadings;
        private System.Windows.Forms.CheckBox chkStationHasWash;
        private System.Windows.Forms.CheckBox chkVaskeafstemning2;
        private System.Windows.Forms.CheckBox chkVaskeafstemning3;
        private System.Windows.Forms.GroupBox groupLastCreatedPrlFile;
        private System.Windows.Forms.Label lbLastCreatedPrlFile;
        private System.Windows.Forms.TextBox txtLastCreatedPrlFile_Period;
        private System.Windows.Forms.TextBox txtLastCreatedPrlFile_Year;
        private System.Windows.Forms.Label lbLastCreatedPrlFile_Timestamp;
        private System.Windows.Forms.GroupBox groupDebtor;
        private System.Windows.Forms.Label lbStandardDebtorStatementRemarks;
        private System.Windows.Forms.TextBox txtStandardDebtorStatementRemarks;
        private System.Windows.Forms.TabPage tabSafePay;
        private System.Windows.Forms.GroupBox GroupSafePayValutakurser;
        private System.Windows.Forms.Label lbSafePay_ValutaISO_NOK;
        private System.Windows.Forms.Label lbSafePay_ValutaISO_SEK;
        private System.Windows.Forms.Label lbSafePay_ValutaISO_EURO;
        private System.Windows.Forms.Label lbSafePayByttepengeOptaltInterval;
        private System.Windows.Forms.ComboBox comboSafePayByttepengeOptaltInterval;
        private System.Windows.Forms.MaskedTextBox txtSafePay_ValutaISO_EURO;
        private System.Windows.Forms.MaskedTextBox txtSafePay_ValutaISO_SEK;
        private System.Windows.Forms.MaskedTextBox txtSafePay_ValutaISO_NOK;
        private System.Windows.Forms.TabPage tabEconomics;
        private System.Windows.Forms.Label lblAftaleID;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtAftaleID;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
    }
}