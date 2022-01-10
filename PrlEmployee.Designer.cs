namespace RBOS
{
    partial class PrlEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrlEmployee));
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.bindingPrlEmployee = new System.Windows.Forms.BindingSource(this.components);
            this.dsPayroll = new RBOS.Payroll();
            this.lbEmpNo = new System.Windows.Forms.Label();
            this.lbCPR = new System.Windows.Forms.Label();
            this.lbContactPhone = new System.Windows.Forms.Label();
            this.lbPhone = new System.Windows.Forms.Label();
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.lbPost = new System.Windows.Forms.Label();
            this.lbZipCodeCity = new System.Windows.Forms.Label();
            this.lbAddress1 = new System.Windows.Forms.Label();
            this.lbLastName = new System.Windows.Forms.Label();
            this.lbFirstName = new System.Windows.Forms.Label();
            this.txtPost = new System.Windows.Forms.TextBox();
            this.txtCPR = new System.Windows.Forms.TextBox();
            this.txtContactPhone = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.chkEducation = new System.Windows.Forms.CheckBox();
            this.lbFuncHours = new System.Windows.Forms.Label();
            this.txtFuncHours = new System.Windows.Forms.TextBox();
            this.lbEmpType = new System.Windows.Forms.Label();
            this.txtEmpType = new System.Windows.Forms.TextBox();
            this.lbEndDate = new System.Windows.Forms.Label();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.lbStartDate = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.lbEmpList = new System.Windows.Forms.Label();
            this.comboEmpList = new System.Windows.Forms.ComboBox();
            this.bindingPrlEmployeeDropDown = new System.Windows.Forms.BindingSource(this.components);
            this.adapterPrlEmployee = new RBOS.PayrollTableAdapters.PrlEmployeeTableAdapter();
            this.prlEmployeeDropDownTableAdapter = new RBOS.PayrollTableAdapters.PrlEmployeeDropDownTableAdapter();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupGeneral = new System.Windows.Forms.GroupBox();
            this.groupEmployment = new System.Windows.Forms.GroupBox();
            this.lbInactiveFrom = new System.Windows.Forms.Label();
            this.txtInactiveFrom = new System.Windows.Forms.TextBox();
            this.chkIncludeInactive = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingPrlEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPayroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingPrlEmployeeDropDown)).BeginInit();
            this.groupGeneral.SuspendLayout();
            this.groupEmployment.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingPrlEmployee, "EmployeeNo", true));
            this.txtEmpNo.Location = new System.Drawing.Point(147, 23);
            this.txtEmpNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.ReadOnly = true;
            this.txtEmpNo.Size = new System.Drawing.Size(132, 22);
            this.txtEmpNo.TabIndex = 0;
            // 
            // bindingPrlEmployee
            // 
            this.bindingPrlEmployee.DataMember = "PrlEmployee";
            this.bindingPrlEmployee.DataSource = this.dsPayroll;
            // 
            // dsPayroll
            // 
            this.dsPayroll.DataSetName = "Payroll";
            this.dsPayroll.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lbEmpNo
            // 
            this.lbEmpNo.AutoSize = true;
            this.lbEmpNo.Location = new System.Drawing.Point(8, 27);
            this.lbEmpNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbEmpNo.Name = "lbEmpNo";
            this.lbEmpNo.Size = new System.Drawing.Size(113, 17);
            this.lbEmpNo.TabIndex = 1;
            this.lbEmpNo.Text = "[Medarbejdernr.]";
            // 
            // lbCPR
            // 
            this.lbCPR.AutoSize = true;
            this.lbCPR.Location = new System.Drawing.Point(8, 283);
            this.lbCPR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCPR.Name = "lbCPR";
            this.lbCPR.Size = new System.Drawing.Size(66, 17);
            this.lbCPR.TabIndex = 19;
            this.lbCPR.Text = "[CPR-nr.]";
            // 
            // lbContactPhone
            // 
            this.lbContactPhone.AutoSize = true;
            this.lbContactPhone.Location = new System.Drawing.Point(8, 251);
            this.lbContactPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbContactPhone.Name = "lbContactPhone";
            this.lbContactPhone.Size = new System.Drawing.Size(111, 17);
            this.lbContactPhone.TabIndex = 18;
            this.lbContactPhone.Text = "[Kontakt telefon]";
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.Location = new System.Drawing.Point(8, 219);
            this.lbPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(64, 17);
            this.lbPhone.TabIndex = 17;
            this.lbPhone.Text = "[Telefon]";
            // 
            // txtZipCode
            // 
            this.txtZipCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingPrlEmployee, "ZipCode", true));
            this.txtZipCode.Location = new System.Drawing.Point(147, 183);
            this.txtZipCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.ReadOnly = true;
            this.txtZipCode.Size = new System.Drawing.Size(47, 22);
            this.txtZipCode.TabIndex = 5;
            // 
            // lbPost
            // 
            this.lbPost.AutoSize = true;
            this.lbPost.Location = new System.Drawing.Point(8, 315);
            this.lbPost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPost.Name = "lbPost";
            this.lbPost.Size = new System.Drawing.Size(57, 17);
            this.lbPost.TabIndex = 15;
            this.lbPost.Text = "[Stilling]";
            // 
            // lbZipCodeCity
            // 
            this.lbZipCodeCity.AutoSize = true;
            this.lbZipCodeCity.Location = new System.Drawing.Point(8, 187);
            this.lbZipCodeCity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbZipCodeCity.Name = "lbZipCodeCity";
            this.lbZipCodeCity.Size = new System.Drawing.Size(89, 17);
            this.lbZipCodeCity.TabIndex = 14;
            this.lbZipCodeCity.Text = "[Postnr. / By]";
            // 
            // lbAddress1
            // 
            this.lbAddress1.AutoSize = true;
            this.lbAddress1.Location = new System.Drawing.Point(8, 123);
            this.lbAddress1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAddress1.Name = "lbAddress1";
            this.lbAddress1.Size = new System.Drawing.Size(68, 17);
            this.lbAddress1.TabIndex = 13;
            this.lbAddress1.Text = "[Adresse]";
            // 
            // lbLastName
            // 
            this.lbLastName.AutoSize = true;
            this.lbLastName.Location = new System.Drawing.Point(8, 91);
            this.lbLastName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLastName.Name = "lbLastName";
            this.lbLastName.Size = new System.Drawing.Size(77, 17);
            this.lbLastName.TabIndex = 12;
            this.lbLastName.Text = "[Efternavn]";
            // 
            // lbFirstName
            // 
            this.lbFirstName.AutoSize = true;
            this.lbFirstName.Location = new System.Drawing.Point(8, 59);
            this.lbFirstName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFirstName.Name = "lbFirstName";
            this.lbFirstName.Size = new System.Drawing.Size(68, 17);
            this.lbFirstName.TabIndex = 11;
            this.lbFirstName.Text = "[Fornavn]";
            // 
            // txtPost
            // 
            this.txtPost.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingPrlEmployee, "Post", true));
            this.txtPost.Location = new System.Drawing.Point(147, 311);
            this.txtPost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPost.Name = "txtPost";
            this.txtPost.ReadOnly = true;
            this.txtPost.Size = new System.Drawing.Size(235, 22);
            this.txtPost.TabIndex = 10;
            // 
            // txtCPR
            // 
            this.txtCPR.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingPrlEmployee, "CPR", true));
            this.txtCPR.Location = new System.Drawing.Point(147, 279);
            this.txtCPR.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCPR.Name = "txtCPR";
            this.txtCPR.ReadOnly = true;
            this.txtCPR.Size = new System.Drawing.Size(132, 22);
            this.txtCPR.TabIndex = 9;
            // 
            // txtContactPhone
            // 
            this.txtContactPhone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingPrlEmployee, "ContactPhone", true));
            this.txtContactPhone.Location = new System.Drawing.Point(147, 247);
            this.txtContactPhone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtContactPhone.Name = "txtContactPhone";
            this.txtContactPhone.ReadOnly = true;
            this.txtContactPhone.Size = new System.Drawing.Size(132, 22);
            this.txtContactPhone.TabIndex = 8;
            // 
            // txtPhone
            // 
            this.txtPhone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingPrlEmployee, "Phone", true));
            this.txtPhone.Location = new System.Drawing.Point(147, 215);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(132, 22);
            this.txtPhone.TabIndex = 7;
            // 
            // txtAddress2
            // 
            this.txtAddress2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingPrlEmployee, "Address2", true));
            this.txtAddress2.Location = new System.Drawing.Point(147, 151);
            this.txtAddress2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.ReadOnly = true;
            this.txtAddress2.Size = new System.Drawing.Size(235, 22);
            this.txtAddress2.TabIndex = 4;
            // 
            // txtCity
            // 
            this.txtCity.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingPrlEmployee, "City", true));
            this.txtCity.Location = new System.Drawing.Point(203, 183);
            this.txtCity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCity.Name = "txtCity";
            this.txtCity.ReadOnly = true;
            this.txtCity.Size = new System.Drawing.Size(179, 22);
            this.txtCity.TabIndex = 6;
            // 
            // txtAddress1
            // 
            this.txtAddress1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingPrlEmployee, "Address1", true));
            this.txtAddress1.Location = new System.Drawing.Point(147, 119);
            this.txtAddress1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.ReadOnly = true;
            this.txtAddress1.Size = new System.Drawing.Size(235, 22);
            this.txtAddress1.TabIndex = 3;
            // 
            // txtLastName
            // 
            this.txtLastName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingPrlEmployee, "LastName", true));
            this.txtLastName.Location = new System.Drawing.Point(147, 87);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.ReadOnly = true;
            this.txtLastName.Size = new System.Drawing.Size(235, 22);
            this.txtLastName.TabIndex = 2;
            // 
            // txtFirstName
            // 
            this.txtFirstName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingPrlEmployee, "FirstName", true));
            this.txtFirstName.Location = new System.Drawing.Point(147, 55);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.ReadOnly = true;
            this.txtFirstName.Size = new System.Drawing.Size(235, 22);
            this.txtFirstName.TabIndex = 1;
            // 
            // chkEducation
            // 
            this.chkEducation.AutoSize = true;
            this.chkEducation.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingPrlEmployee, "Education", true));
            this.chkEducation.Enabled = false;
            this.chkEducation.Location = new System.Drawing.Point(12, 186);
            this.chkEducation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkEducation.Name = "chkEducation";
            this.chkEducation.Size = new System.Drawing.Size(155, 21);
            this.chkEducation.TabIndex = 4;
            this.chkEducation.Text = "[Under uddannelse]";
            this.chkEducation.UseVisualStyleBackColor = true;
            // 
            // lbFuncHours
            // 
            this.lbFuncHours.AutoSize = true;
            this.lbFuncHours.Location = new System.Drawing.Point(8, 123);
            this.lbFuncHours.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFuncHours.Name = "lbFuncHours";
            this.lbFuncHours.Size = new System.Drawing.Size(119, 17);
            this.lbFuncHours.TabIndex = 9;
            this.lbFuncHours.Text = "[Funktionærtimer]";
            // 
            // txtFuncHours
            // 
            this.txtFuncHours.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingPrlEmployee, "FuncHours", true));
            this.txtFuncHours.Location = new System.Drawing.Point(164, 119);
            this.txtFuncHours.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFuncHours.Name = "txtFuncHours";
            this.txtFuncHours.ReadOnly = true;
            this.txtFuncHours.Size = new System.Drawing.Size(143, 22);
            this.txtFuncHours.TabIndex = 3;
            // 
            // lbEmpType
            // 
            this.lbEmpType.AutoSize = true;
            this.lbEmpType.Location = new System.Drawing.Point(8, 91);
            this.lbEmpType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbEmpType.Name = "lbEmpType";
            this.lbEmpType.Size = new System.Drawing.Size(123, 17);
            this.lbEmpType.TabIndex = 7;
            this.lbEmpType.Text = "[Medarbejdertype]";
            // 
            // txtEmpType
            // 
            this.txtEmpType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingPrlEmployee, "EmployeeType", true));
            this.txtEmpType.Location = new System.Drawing.Point(164, 87);
            this.txtEmpType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEmpType.Name = "txtEmpType";
            this.txtEmpType.ReadOnly = true;
            this.txtEmpType.Size = new System.Drawing.Size(143, 22);
            this.txtEmpType.TabIndex = 2;
            // 
            // lbEndDate
            // 
            this.lbEndDate.AutoSize = true;
            this.lbEndDate.Location = new System.Drawing.Point(8, 59);
            this.lbEndDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbEndDate.Name = "lbEndDate";
            this.lbEndDate.Size = new System.Drawing.Size(128, 17);
            this.lbEndDate.TabIndex = 5;
            this.lbEndDate.Text = "[Fratrædelsesdato]";
            // 
            // txtEndDate
            // 
            this.txtEndDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingPrlEmployee, "EndDate", true));
            this.txtEndDate.Location = new System.Drawing.Point(164, 55);
            this.txtEndDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.ReadOnly = true;
            this.txtEndDate.Size = new System.Drawing.Size(143, 22);
            this.txtEndDate.TabIndex = 1;
            // 
            // lbStartDate
            // 
            this.lbStartDate.AutoSize = true;
            this.lbStartDate.Location = new System.Drawing.Point(8, 27);
            this.lbStartDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbStartDate.Name = "lbStartDate";
            this.lbStartDate.Size = new System.Drawing.Size(122, 17);
            this.lbStartDate.TabIndex = 3;
            this.lbStartDate.Text = "[Ansættelsesdato]";
            // 
            // txtStartDate
            // 
            this.txtStartDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingPrlEmployee, "StartDate", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            this.txtStartDate.Location = new System.Drawing.Point(164, 23);
            this.txtStartDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.ReadOnly = true;
            this.txtStartDate.Size = new System.Drawing.Size(143, 22);
            this.txtStartDate.TabIndex = 0;
            // 
            // lbEmpList
            // 
            this.lbEmpList.AutoSize = true;
            this.lbEmpList.Location = new System.Drawing.Point(16, 18);
            this.lbEmpList.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbEmpList.Name = "lbEmpList";
            this.lbEmpList.Size = new System.Drawing.Size(96, 17);
            this.lbEmpList.TabIndex = 4;
            this.lbEmpList.Text = "[Medarbejder]";
            // 
            // comboEmpList
            // 
            this.comboEmpList.DataSource = this.bindingPrlEmployeeDropDown;
            this.comboEmpList.DisplayMember = "DisplayValue";
            this.comboEmpList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEmpList.FormattingEnabled = true;
            this.comboEmpList.Location = new System.Drawing.Point(139, 15);
            this.comboEmpList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboEmpList.Name = "comboEmpList";
            this.comboEmpList.Size = new System.Drawing.Size(307, 24);
            this.comboEmpList.TabIndex = 0;
            this.comboEmpList.ValueMember = "EmployeeNo";
            this.comboEmpList.SelectedIndexChanged += new System.EventHandler(this.comboEmployeeList_SelectedIndexChanged);
            // 
            // bindingPrlEmployeeDropDown
            // 
            this.bindingPrlEmployeeDropDown.AllowNew = true;
            this.bindingPrlEmployeeDropDown.DataMember = "PrlEmployeeDropDown";
            this.bindingPrlEmployeeDropDown.DataSource = this.dsPayroll;
            // 
            // adapterPrlEmployee
            // 
            this.adapterPrlEmployee.ClearBeforeFill = true;
            // 
            // prlEmployeeDropDownTableAdapter
            // 
            this.prlEmployeeDropDownTableAdapter.ClearBeforeFill = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(656, 417);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "[Luk]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupGeneral
            // 
            this.groupGeneral.Controls.Add(this.txtEmpNo);
            this.groupGeneral.Controls.Add(this.txtPhone);
            this.groupGeneral.Controls.Add(this.txtContactPhone);
            this.groupGeneral.Controls.Add(this.lbCPR);
            this.groupGeneral.Controls.Add(this.txtAddress2);
            this.groupGeneral.Controls.Add(this.txtCPR);
            this.groupGeneral.Controls.Add(this.txtCity);
            this.groupGeneral.Controls.Add(this.txtPost);
            this.groupGeneral.Controls.Add(this.lbContactPhone);
            this.groupGeneral.Controls.Add(this.txtAddress1);
            this.groupGeneral.Controls.Add(this.lbFirstName);
            this.groupGeneral.Controls.Add(this.txtLastName);
            this.groupGeneral.Controls.Add(this.lbLastName);
            this.groupGeneral.Controls.Add(this.lbPhone);
            this.groupGeneral.Controls.Add(this.txtFirstName);
            this.groupGeneral.Controls.Add(this.lbAddress1);
            this.groupGeneral.Controls.Add(this.lbEmpNo);
            this.groupGeneral.Controls.Add(this.lbZipCodeCity);
            this.groupGeneral.Controls.Add(this.txtZipCode);
            this.groupGeneral.Controls.Add(this.lbPost);
            this.groupGeneral.Location = new System.Drawing.Point(16, 48);
            this.groupGeneral.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupGeneral.Name = "groupGeneral";
            this.groupGeneral.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupGeneral.Size = new System.Drawing.Size(404, 356);
            this.groupGeneral.TabIndex = 20;
            this.groupGeneral.TabStop = false;
            this.groupGeneral.Text = "[Generelt]";
            // 
            // groupEmployment
            // 
            this.groupEmployment.Controls.Add(this.txtStartDate);
            this.groupEmployment.Controls.Add(this.lbStartDate);
            this.groupEmployment.Controls.Add(this.txtEndDate);
            this.groupEmployment.Controls.Add(this.chkEducation);
            this.groupEmployment.Controls.Add(this.lbEndDate);
            this.groupEmployment.Controls.Add(this.txtEmpType);
            this.groupEmployment.Controls.Add(this.lbInactiveFrom);
            this.groupEmployment.Controls.Add(this.lbFuncHours);
            this.groupEmployment.Controls.Add(this.txtInactiveFrom);
            this.groupEmployment.Controls.Add(this.lbEmpType);
            this.groupEmployment.Controls.Add(this.txtFuncHours);
            this.groupEmployment.Location = new System.Drawing.Point(428, 48);
            this.groupEmployment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupEmployment.Name = "groupEmployment";
            this.groupEmployment.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupEmployment.Size = new System.Drawing.Size(333, 356);
            this.groupEmployment.TabIndex = 21;
            this.groupEmployment.TabStop = false;
            this.groupEmployment.Text = "[Ansættelse]";
            // 
            // lbInactiveFrom
            // 
            this.lbInactiveFrom.AutoSize = true;
            this.lbInactiveFrom.Location = new System.Drawing.Point(8, 155);
            this.lbInactiveFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbInactiveFrom.Name = "lbInactiveFrom";
            this.lbInactiveFrom.Size = new System.Drawing.Size(77, 17);
            this.lbInactiveFrom.TabIndex = 9;
            this.lbInactiveFrom.Text = "[Inaktiv fra]";
            // 
            // txtInactiveFrom
            // 
            this.txtInactiveFrom.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingPrlEmployee, "InactiveDate", true));
            this.txtInactiveFrom.Location = new System.Drawing.Point(164, 151);
            this.txtInactiveFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtInactiveFrom.Name = "txtInactiveFrom";
            this.txtInactiveFrom.ReadOnly = true;
            this.txtInactiveFrom.Size = new System.Drawing.Size(143, 22);
            this.txtInactiveFrom.TabIndex = 3;
            // 
            // chkIncludeInactive
            // 
            this.chkIncludeInactive.AutoSize = true;
            this.chkIncludeInactive.Location = new System.Drawing.Point(472, 17);
            this.chkIncludeInactive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkIncludeInactive.Name = "chkIncludeInactive";
            this.chkIncludeInactive.Size = new System.Drawing.Size(140, 21);
            this.chkIncludeInactive.TabIndex = 22;
            this.chkIncludeInactive.Text = "[Inkludér inaktive]";
            this.chkIncludeInactive.UseVisualStyleBackColor = true;
            this.chkIncludeInactive.CheckedChanged += new System.EventHandler(this.chkIncludeInactive_CheckedChanged);
            // 
            // PrlEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 460);
            this.Controls.Add(this.chkIncludeInactive);
            this.Controls.Add(this.groupEmployment);
            this.Controls.Add(this.groupGeneral);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.comboEmpList);
            this.Controls.Add(this.lbEmpList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "PrlEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Medarbejder]";
            this.Load += new System.EventHandler(this.PrlEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingPrlEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPayroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingPrlEmployeeDropDown)).EndInit();
            this.groupGeneral.ResumeLayout(false);
            this.groupGeneral.PerformLayout();
            this.groupEmployment.ResumeLayout(false);
            this.groupEmployment.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmpNo;
        private Payroll dsPayroll;
        private System.Windows.Forms.BindingSource bindingPrlEmployee;
        private RBOS.PayrollTableAdapters.PrlEmployeeTableAdapter adapterPrlEmployee;
        private System.Windows.Forms.Label lbEmpNo;
        private System.Windows.Forms.Label lbEmpList;
        private System.Windows.Forms.ComboBox comboEmpList;
        private System.Windows.Forms.BindingSource bindingPrlEmployeeDropDown;
        private RBOS.PayrollTableAdapters.PrlEmployeeDropDownTableAdapter prlEmployeeDropDownTableAdapter;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lbCPR;
        private System.Windows.Forms.Label lbContactPhone;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.TextBox txtZipCode;
        private System.Windows.Forms.Label lbPost;
        private System.Windows.Forms.Label lbZipCodeCity;
        private System.Windows.Forms.Label lbAddress1;
        private System.Windows.Forms.Label lbLastName;
        private System.Windows.Forms.Label lbFirstName;
        private System.Windows.Forms.TextBox txtPost;
        private System.Windows.Forms.TextBox txtCPR;
        private System.Windows.Forms.TextBox txtContactPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbStartDate;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.CheckBox chkEducation;
        private System.Windows.Forms.Label lbFuncHours;
        private System.Windows.Forms.TextBox txtFuncHours;
        private System.Windows.Forms.Label lbEmpType;
        private System.Windows.Forms.TextBox txtEmpType;
        private System.Windows.Forms.Label lbEndDate;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.GroupBox groupGeneral;
        private System.Windows.Forms.GroupBox groupEmployment;
        private System.Windows.Forms.CheckBox chkIncludeInactive;
        private System.Windows.Forms.Label lbInactiveFrom;
        private System.Windows.Forms.TextBox txtInactiveFrom;
    }
}