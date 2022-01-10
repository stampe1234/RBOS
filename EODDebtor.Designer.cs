namespace RBOS
{
    partial class EODDebtor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EODDebtor));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.lbRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.bindingEODDebtor = new System.Windows.Forms.BindingSource(this.components);
            this.dsEOD = new RBOS.EODDataSet();
            this.lbEmployee = new System.Windows.Forms.Label();
            this.chkEmployee = new System.Windows.Forms.CheckBox();
            this.lbRRNumber = new System.Windows.Forms.Label();
            this.txtRRNumber = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.lbActive = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.lbZipCodeCity = new System.Windows.Forms.Label();
            this.lbBalance = new System.Windows.Forms.Label();
            this.lbAtt = new System.Windows.Forms.Label();
            this.lbPhone = new System.Windows.Forms.Label();
            this.lbAddress = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbDebtorNo = new System.Windows.Forms.Label();
            this.txtDebtorNo = new System.Windows.Forms.TextBox();
            this.txtName2 = new System.Windows.Forms.TextBox();
            this.txtName1 = new System.Windows.Forms.TextBox();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.txtAtt = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.tabTransactions = new System.Windows.Forms.TabPage();
            this.gridTransactions = new DRS.Extensions.DRS_DataGridView();
            this.colBookDate = new DRS.Extensions.DRS_CalendarColumn();
            this.colTransType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bindingLookupEODLocalCredTransType = new System.Windows.Forms.BindingSource(this.components);
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingEODDebtorLocalCred = new System.Windows.Forms.BindingSource(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.comboDebtor = new System.Windows.Forms.ComboBox();
            this.bindingEODDebtorList = new System.Windows.Forms.BindingSource(this.components);
            this.lbDebtor = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.adapterEODDebtorList = new RBOS.EODDataSetTableAdapters.EOD_DebtorListTableAdapter();
            this.adapterEODDebtor = new RBOS.EODDataSetTableAdapters.EOD_DebtorTableAdapter();
            this.adapterEODDebtorLocalCred = new RBOS.EODDataSetTableAdapters.EOD_Debtor_LocalCredTableAdapter();
            this.adapterLookupEODLocalCredTransType = new RBOS.EODDataSetTableAdapters.LookupEODLocalCredTransTypeTableAdapter();
            this.btnLookupDebtor = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingEODDebtor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEOD)).BeginInit();
            this.tabTransactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupEODLocalCredTransType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingEODDebtorLocalCred)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingEODDebtorList)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabTransactions);
            this.tabControl1.Location = new System.Drawing.Point(12, 38);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(504, 418);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.lbRemarks);
            this.tabGeneral.Controls.Add(this.txtRemarks);
            this.tabGeneral.Controls.Add(this.lbEmployee);
            this.tabGeneral.Controls.Add(this.chkEmployee);
            this.tabGeneral.Controls.Add(this.lbRRNumber);
            this.tabGeneral.Controls.Add(this.txtRRNumber);
            this.tabGeneral.Controls.Add(this.chkActive);
            this.tabGeneral.Controls.Add(this.lbActive);
            this.tabGeneral.Controls.Add(this.txtBalance);
            this.tabGeneral.Controls.Add(this.lbZipCodeCity);
            this.tabGeneral.Controls.Add(this.lbBalance);
            this.tabGeneral.Controls.Add(this.lbAtt);
            this.tabGeneral.Controls.Add(this.lbPhone);
            this.tabGeneral.Controls.Add(this.lbAddress);
            this.tabGeneral.Controls.Add(this.lbName);
            this.tabGeneral.Controls.Add(this.lbDebtorNo);
            this.tabGeneral.Controls.Add(this.txtDebtorNo);
            this.tabGeneral.Controls.Add(this.txtName2);
            this.tabGeneral.Controls.Add(this.txtName1);
            this.tabGeneral.Controls.Add(this.txtAddress1);
            this.tabGeneral.Controls.Add(this.txtAddress2);
            this.tabGeneral.Controls.Add(this.txtZipCode);
            this.tabGeneral.Controls.Add(this.txtAtt);
            this.tabGeneral.Controls.Add(this.txtCity);
            this.tabGeneral.Controls.Add(this.txtPhone);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(496, 392);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "[General]";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // lbRemarks
            // 
            this.lbRemarks.AutoSize = true;
            this.lbRemarks.Location = new System.Drawing.Point(6, 291);
            this.lbRemarks.Name = "lbRemarks";
            this.lbRemarks.Size = new System.Drawing.Size(82, 13);
            this.lbRemarks.TabIndex = 34;
            this.lbRemarks.Text = "[Bemærkninger]";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemarks.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingEODDebtor, "Remarks", true));
            this.txtRemarks.Location = new System.Drawing.Point(6, 308);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(484, 78);
            this.txtRemarks.TabIndex = 33;
            // 
            // bindingEODDebtor
            // 
            this.bindingEODDebtor.DataMember = "EOD_Debtor";
            this.bindingEODDebtor.DataSource = this.dsEOD;
            // 
            // dsEOD
            // 
            this.dsEOD.DataSetName = "EODDataSet";
            this.dsEOD.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lbEmployee
            // 
            this.lbEmployee.AutoSize = true;
            this.lbEmployee.Location = new System.Drawing.Point(6, 245);
            this.lbEmployee.Name = "lbEmployee";
            this.lbEmployee.Size = new System.Drawing.Size(75, 13);
            this.lbEmployee.TabIndex = 32;
            this.lbEmployee.Text = "[Medarbejder:]";
            // 
            // chkEmployee
            // 
            this.chkEmployee.AutoSize = true;
            this.chkEmployee.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingEODDebtor, "Employee", true));
            this.chkEmployee.Location = new System.Drawing.Point(87, 245);
            this.chkEmployee.Name = "chkEmployee";
            this.chkEmployee.Size = new System.Drawing.Size(15, 14);
            this.chkEmployee.TabIndex = 31;
            this.chkEmployee.UseVisualStyleBackColor = true;
            // 
            // lbRRNumber
            // 
            this.lbRRNumber.AutoSize = true;
            this.lbRRNumber.Location = new System.Drawing.Point(179, 19);
            this.lbRRNumber.Name = "lbRRNumber";
            this.lbRRNumber.Size = new System.Drawing.Size(47, 13);
            this.lbRRNumber.TabIndex = 30;
            this.lbRRNumber.Text = "[RR nr.:]";
            // 
            // txtRRNumber
            // 
            this.txtRRNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingEODDebtor, "RRNumber", true));
            this.txtRRNumber.Location = new System.Drawing.Point(239, 16);
            this.txtRRNumber.Name = "txtRRNumber";
            this.txtRRNumber.ReadOnly = true;
            this.txtRRNumber.Size = new System.Drawing.Size(60, 20);
            this.txtRRNumber.TabIndex = 29;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingEODDebtor, "Active", true));
            this.chkActive.Location = new System.Drawing.Point(87, 225);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(15, 14);
            this.chkActive.TabIndex = 28;
            this.chkActive.UseVisualStyleBackColor = true;
            this.chkActive.KeyUp += new System.Windows.Forms.KeyEventHandler(this.chkActive_KeyUp);
            this.chkActive.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chkActive_MouseUp);
            // 
            // lbActive
            // 
            this.lbActive.AutoSize = true;
            this.lbActive.Location = new System.Drawing.Point(6, 225);
            this.lbActive.Name = "lbActive";
            this.lbActive.Size = new System.Drawing.Size(46, 13);
            this.lbActive.TabIndex = 27;
            this.lbActive.Text = "[Active:]";
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(87, 268);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(60, 20);
            this.txtBalance.TabIndex = 8;
            this.txtBalance.TabStop = false;
            // 
            // lbZipCodeCity
            // 
            this.lbZipCodeCity.AutoSize = true;
            this.lbZipCodeCity.Location = new System.Drawing.Point(6, 149);
            this.lbZipCodeCity.Name = "lbZipCodeCity";
            this.lbZipCodeCity.Size = new System.Drawing.Size(53, 13);
            this.lbZipCodeCity.TabIndex = 26;
            this.lbZipCodeCity.Text = "[Zip/City:]";
            // 
            // lbBalance
            // 
            this.lbBalance.AutoSize = true;
            this.lbBalance.Location = new System.Drawing.Point(6, 271);
            this.lbBalance.Name = "lbBalance";
            this.lbBalance.Size = new System.Drawing.Size(55, 13);
            this.lbBalance.TabIndex = 24;
            this.lbBalance.Text = "[Balance:]";
            // 
            // lbAtt
            // 
            this.lbAtt.AutoSize = true;
            this.lbAtt.Location = new System.Drawing.Point(6, 201);
            this.lbAtt.Name = "lbAtt";
            this.lbAtt.Size = new System.Drawing.Size(29, 13);
            this.lbAtt.TabIndex = 23;
            this.lbAtt.Text = "[Att:]";
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.Location = new System.Drawing.Point(6, 175);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(47, 13);
            this.lbPhone.TabIndex = 22;
            this.lbPhone.Text = "[Phone:]";
            // 
            // lbAddress
            // 
            this.lbAddress.AutoSize = true;
            this.lbAddress.Location = new System.Drawing.Point(6, 97);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(54, 13);
            this.lbAddress.TabIndex = 21;
            this.lbAddress.Text = "[Address:]";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(6, 45);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(44, 13);
            this.lbName.TabIndex = 20;
            this.lbName.Text = "[Name:]";
            // 
            // lbDebtorNo
            // 
            this.lbDebtorNo.AutoSize = true;
            this.lbDebtorNo.Location = new System.Drawing.Point(6, 19);
            this.lbDebtorNo.Name = "lbDebtorNo";
            this.lbDebtorNo.Size = new System.Drawing.Size(60, 13);
            this.lbDebtorNo.TabIndex = 19;
            this.lbDebtorNo.Text = "[Debtorno:]";
            // 
            // txtDebtorNo
            // 
            this.txtDebtorNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingEODDebtor, "DebtorNo", true));
            this.txtDebtorNo.Location = new System.Drawing.Point(87, 16);
            this.txtDebtorNo.Name = "txtDebtorNo";
            this.txtDebtorNo.Size = new System.Drawing.Size(60, 20);
            this.txtDebtorNo.TabIndex = 0;
            this.txtDebtorNo.TabStop = false;
            // 
            // txtName2
            // 
            this.txtName2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingEODDebtor, "Name2", true));
            this.txtName2.Location = new System.Drawing.Point(87, 68);
            this.txtName2.Name = "txtName2";
            this.txtName2.Size = new System.Drawing.Size(248, 20);
            this.txtName2.TabIndex = 2;
            // 
            // txtName1
            // 
            this.txtName1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingEODDebtor, "Name1", true));
            this.txtName1.Location = new System.Drawing.Point(87, 42);
            this.txtName1.Name = "txtName1";
            this.txtName1.Size = new System.Drawing.Size(248, 20);
            this.txtName1.TabIndex = 1;
            // 
            // txtAddress1
            // 
            this.txtAddress1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingEODDebtor, "Address1", true));
            this.txtAddress1.Location = new System.Drawing.Point(87, 94);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(248, 20);
            this.txtAddress1.TabIndex = 3;
            // 
            // txtAddress2
            // 
            this.txtAddress2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingEODDebtor, "Address2", true));
            this.txtAddress2.Location = new System.Drawing.Point(87, 120);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(248, 20);
            this.txtAddress2.TabIndex = 4;
            // 
            // txtZipCode
            // 
            this.txtZipCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingEODDebtor, "ZipCode", true));
            this.txtZipCode.Location = new System.Drawing.Point(87, 146);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(36, 20);
            this.txtZipCode.TabIndex = 5;
            // 
            // txtAtt
            // 
            this.txtAtt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingEODDebtor, "Att", true));
            this.txtAtt.Location = new System.Drawing.Point(87, 198);
            this.txtAtt.Name = "txtAtt";
            this.txtAtt.Size = new System.Drawing.Size(248, 20);
            this.txtAtt.TabIndex = 8;
            // 
            // txtCity
            // 
            this.txtCity.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingEODDebtor, "City", true));
            this.txtCity.Location = new System.Drawing.Point(129, 146);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(206, 20);
            this.txtCity.TabIndex = 6;
            // 
            // txtPhone
            // 
            this.txtPhone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingEODDebtor, "Phone", true));
            this.txtPhone.Location = new System.Drawing.Point(87, 172);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(100, 20);
            this.txtPhone.TabIndex = 7;
            // 
            // tabTransactions
            // 
            this.tabTransactions.Controls.Add(this.gridTransactions);
            this.tabTransactions.Location = new System.Drawing.Point(4, 22);
            this.tabTransactions.Name = "tabTransactions";
            this.tabTransactions.Padding = new System.Windows.Forms.Padding(3);
            this.tabTransactions.Size = new System.Drawing.Size(496, 392);
            this.tabTransactions.TabIndex = 1;
            this.tabTransactions.Text = "[Transactions]";
            this.tabTransactions.UseVisualStyleBackColor = true;
            // 
            // gridTransactions
            // 
            this.gridTransactions.AllowUserToResizeColumns = false;
            this.gridTransactions.AllowUserToResizeRows = false;
            this.gridTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridTransactions.AutoGenerateColumns = false;
            this.gridTransactions.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridTransactions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridTransactions.ColumnHeadersHeight = 21;
            this.gridTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBookDate,
            this.colTransType,
            this.colRemark,
            this.colAmount});
            this.gridTransactions.DataSource = this.bindingEODDebtorLocalCred;
            this.gridTransactions.Location = new System.Drawing.Point(6, 6);
            this.gridTransactions.MultiSelect = false;
            this.gridTransactions.Name = "gridTransactions";
            this.gridTransactions.RowHeadersWidth = 25;
            this.gridTransactions.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridTransactions.Size = new System.Drawing.Size(484, 380);
            this.gridTransactions.TabIndex = 0;
            this.gridTransactions.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.gridTransactions_UserDeletingRow);
            this.gridTransactions.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_RowValidating);
            // 
            // colBookDate
            // 
            this.colBookDate.DataPropertyName = "BookDate";
            this.colBookDate.HeaderText = "BookDate";
            this.colBookDate.Name = "colBookDate";
            this.colBookDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBookDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colBookDate.Width = 80;
            // 
            // colTransType
            // 
            this.colTransType.DataPropertyName = "TransType";
            this.colTransType.DataSource = this.bindingLookupEODLocalCredTransType;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.colTransType.DefaultCellStyle = dataGridViewCellStyle1;
            this.colTransType.DisplayMember = "Description";
            this.colTransType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colTransType.HeaderText = "TransType";
            this.colTransType.Name = "colTransType";
            this.colTransType.ReadOnly = true;
            this.colTransType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTransType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colTransType.ValueMember = "TransType";
            // 
            // bindingLookupEODLocalCredTransType
            // 
            this.bindingLookupEODLocalCredTransType.DataMember = "LookupEODLocalCredTransType";
            this.bindingLookupEODLocalCredTransType.DataSource = this.dsEOD;
            // 
            // colRemark
            // 
            this.colRemark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRemark.DataPropertyName = "Remark";
            this.colRemark.HeaderText = "Remark";
            this.colRemark.Name = "colRemark";
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Width = 70;
            // 
            // bindingEODDebtorLocalCred
            // 
            this.bindingEODDebtorLocalCred.DataMember = "EOD_Debtor_LocalCred";
            this.bindingEODDebtorLocalCred.DataSource = this.dsEOD;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(279, 462);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "[Delete]";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(360, 448);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "[Save]";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(360, 462);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "[Edit]";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(441, 448);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "[Cancel]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(441, 462);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // comboDebtor
            // 
            this.comboDebtor.DataSource = this.bindingEODDebtorList;
            this.comboDebtor.DisplayMember = "DisplayValue";
            this.comboDebtor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDebtor.FormattingEnabled = true;
            this.comboDebtor.Location = new System.Drawing.Point(103, 6);
            this.comboDebtor.Name = "comboDebtor";
            this.comboDebtor.Size = new System.Drawing.Size(251, 21);
            this.comboDebtor.TabIndex = 6;
            this.comboDebtor.ValueMember = "DebtorNo";
            this.comboDebtor.SelectedIndexChanged += new System.EventHandler(this.comboDebtor_SelectedIndexChanged);
            // 
            // bindingEODDebtorList
            // 
            this.bindingEODDebtorList.DataMember = "EOD_DebtorList";
            this.bindingEODDebtorList.DataSource = this.dsEOD;
            // 
            // lbDebtor
            // 
            this.lbDebtor.AutoSize = true;
            this.lbDebtor.Location = new System.Drawing.Point(22, 9);
            this.lbDebtor.Name = "lbDebtor";
            this.lbDebtor.Size = new System.Drawing.Size(48, 13);
            this.lbDebtor.TabIndex = 8;
            this.lbDebtor.Text = "[Debtor:]";
            this.lbDebtor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(198, 462);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "[New]";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // adapterEODDebtorList
            // 
            this.adapterEODDebtorList.ClearBeforeFill = true;
            // 
            // adapterEODDebtor
            // 
            this.adapterEODDebtor.ClearBeforeFill = true;
            // 
            // adapterEODDebtorLocalCred
            // 
            this.adapterEODDebtorLocalCred.ClearBeforeFill = true;
            // 
            // adapterLookupEODLocalCredTransType
            // 
            this.adapterLookupEODLocalCredTransType.ClearBeforeFill = true;
            // 
            // btnLookupDebtor
            // 
            this.btnLookupDebtor.Image = ((System.Drawing.Image)(resources.GetObject("btnLookupDebtor.Image")));
            this.btnLookupDebtor.Location = new System.Drawing.Point(360, 5);
            this.btnLookupDebtor.Name = "btnLookupDebtor";
            this.btnLookupDebtor.Size = new System.Drawing.Size(25, 23);
            this.btnLookupDebtor.TabIndex = 9;
            this.btnLookupDebtor.UseVisualStyleBackColor = true;
            this.btnLookupDebtor.Click += new System.EventHandler(this.btnLookupDebtor_Click);
            // 
            // EODDebtor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 497);
            this.Controls.Add(this.btnLookupDebtor);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lbDebtor);
            this.Controls.Add(this.comboDebtor);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "EODDebtor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Debtor]";
            this.Load += new System.EventHandler(this.EODDebtor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EODDebtor_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingEODDebtor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEOD)).EndInit();
            this.tabTransactions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupEODLocalCredTransType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingEODDebtorLocalCred)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingEODDebtorList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabTransactions;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox comboDebtor;
        private System.Windows.Forms.Label lbDebtor;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lbZipCodeCity;
        private System.Windows.Forms.Label lbBalance;
        private System.Windows.Forms.Label lbAtt;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.Label lbAddress;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbDebtorNo;
        private System.Windows.Forms.TextBox txtDebtorNo;
        private System.Windows.Forms.TextBox txtName2;
        private System.Windows.Forms.TextBox txtName1;
        private System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.TextBox txtZipCode;
        private System.Windows.Forms.TextBox txtAtt;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtPhone;
        private EODDataSet dsEOD;
        private System.Windows.Forms.BindingSource bindingEODDebtorList;
        private RBOS.EODDataSetTableAdapters.EOD_DebtorListTableAdapter adapterEODDebtorList;
        private System.Windows.Forms.BindingSource bindingEODDebtor;
        private RBOS.EODDataSetTableAdapters.EOD_DebtorTableAdapter adapterEODDebtor;
        private System.Windows.Forms.TextBox txtBalance;
        private DRS.Extensions.DRS_DataGridView gridTransactions;
        private System.Windows.Forms.BindingSource bindingEODDebtorLocalCred;
        private RBOS.EODDataSetTableAdapters.EOD_Debtor_LocalCredTableAdapter adapterEODDebtorLocalCred;
        private System.Windows.Forms.BindingSource bindingLookupEODLocalCredTransType;
        private RBOS.EODDataSetTableAdapters.LookupEODLocalCredTransTypeTableAdapter adapterLookupEODLocalCredTransType;
        private DRS.Extensions.DRS_CalendarColumn colBookDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn colTransType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label lbActive;
        private System.Windows.Forms.Label lbRRNumber;
        private System.Windows.Forms.TextBox txtRRNumber;
        private System.Windows.Forms.Button btnLookupDebtor;
        private System.Windows.Forms.Label lbEmployee;
        private System.Windows.Forms.CheckBox chkEmployee;
        private System.Windows.Forms.Label lbRemarks;
        private System.Windows.Forms.TextBox txtRemarks;
    }
}