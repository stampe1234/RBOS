namespace RBOS
{
    partial class PrlSalaryReg
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrlSalaryReg));
            this.btnClose = new System.Windows.Forms.Button();
            this.lbSalaryPeriod = new System.Windows.Forms.Label();
            this.txtSalaryPeriod = new System.Windows.Forms.Label();
            this.lbEmployeeNo = new System.Windows.Forms.Label();
            this.comboEmployeeNo = new System.Windows.Forms.ComboBox();
            this.bindingEmployeeDropDown = new System.Windows.Forms.BindingSource(this.components);
            this.dsPayroll = new RBOS.Payroll();
            this.bindingLookupDays = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSalaryRegistration = new System.Windows.Forms.BindingSource(this.components);
            this.adapterSalaryRegistration = new RBOS.PayrollTableAdapters.PrlSalaryRegistrationTableAdapter();
            this.adapterLookupDays = new RBOS.PayrollTableAdapters.PrlLookupDaysTableAdapter();
            this.adapterEmployeeDropDown = new RBOS.PayrollTableAdapters.PrlEmployeeDropDownTableAdapter();
            this.groupTotals = new System.Windows.Forms.GroupBox();
            this.txtTotalTakeTimeOff = new System.Windows.Forms.TextBox();
            this.txtTotalOvertime = new System.Windows.Forms.TextBox();
            this.txtTotalHours = new System.Windows.Forms.TextBox();
            this.txtTotalBonus1050 = new System.Windows.Forms.TextBox();
            this.txtTotalBonus1040 = new System.Windows.Forms.TextBox();
            this.txtTotalBonus1030 = new System.Windows.Forms.TextBox();
            this.txtTotalBonus1020 = new System.Windows.Forms.TextBox();
            this.txtTotalBonus1010 = new System.Windows.Forms.TextBox();
            this.gridSalary = new DRS.Extensions.DRS_DataGridView();
            this.colFromTimeAsString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegDateAsString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToTimeAsString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTakeTimeOff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBonus1010 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBonus1020 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBonus1030 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBonus1040 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBonus1050 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSiteCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSiteCodeButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDay = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOvertime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingEmployeeDropDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPayroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSalaryRegistration)).BeginInit();
            this.groupTotals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSalary)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(654, 466);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbSalaryPeriod
            // 
            this.lbSalaryPeriod.AutoSize = true;
            this.lbSalaryPeriod.Location = new System.Drawing.Point(15, 14);
            this.lbSalaryPeriod.Name = "lbSalaryPeriod";
            this.lbSalaryPeriod.Size = new System.Drawing.Size(66, 13);
            this.lbSalaryPeriod.TabIndex = 1;
            this.lbSalaryPeriod.Text = "[Lønperiode]";
            // 
            // txtSalaryPeriod
            // 
            this.txtSalaryPeriod.AutoSize = true;
            this.txtSalaryPeriod.Location = new System.Drawing.Point(121, 14);
            this.txtSalaryPeriod.Name = "txtSalaryPeriod";
            this.txtSalaryPeriod.Size = new System.Drawing.Size(83, 13);
            this.txtSalaryPeriod.TabIndex = 2;
            this.txtSalaryPeriod.Text = "[lønperiodedata]";
            // 
            // lbEmployeeNo
            // 
            this.lbEmployeeNo.AutoSize = true;
            this.lbEmployeeNo.Location = new System.Drawing.Point(15, 38);
            this.lbEmployeeNo.Name = "lbEmployeeNo";
            this.lbEmployeeNo.Size = new System.Drawing.Size(84, 13);
            this.lbEmployeeNo.TabIndex = 3;
            this.lbEmployeeNo.Text = "[Medarbejdernr.]";
            // 
            // comboEmployeeNo
            // 
            this.comboEmployeeNo.DataSource = this.bindingEmployeeDropDown;
            this.comboEmployeeNo.DisplayMember = "DisplayValue";
            this.comboEmployeeNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEmployeeNo.FormattingEnabled = true;
            this.comboEmployeeNo.Location = new System.Drawing.Point(121, 38);
            this.comboEmployeeNo.Name = "comboEmployeeNo";
            this.comboEmployeeNo.Size = new System.Drawing.Size(262, 21);
            this.comboEmployeeNo.TabIndex = 0;
            this.comboEmployeeNo.ValueMember = "EmployeeNo";
            this.comboEmployeeNo.SelectedIndexChanged += new System.EventHandler(this.comboEmployeeNo_SelectedIndexChanged);
            // 
            // bindingEmployeeDropDown
            // 
            this.bindingEmployeeDropDown.DataMember = "PrlEmployeeDropDown";
            this.bindingEmployeeDropDown.DataSource = this.dsPayroll;
            // 
            // dsPayroll
            // 
            this.dsPayroll.DataSetName = "Payroll";
            this.dsPayroll.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingLookupDays
            // 
            this.bindingLookupDays.DataMember = "PrlLookupDays";
            this.bindingLookupDays.DataSource = this.dsPayroll;
            // 
            // bindingSalaryRegistration
            // 
            this.bindingSalaryRegistration.DataMember = "PrlSalaryRegistration";
            this.bindingSalaryRegistration.DataSource = this.dsPayroll;
            // 
            // adapterSalaryRegistration
            // 
            this.adapterSalaryRegistration.ClearBeforeFill = true;
            // 
            // adapterLookupDays
            // 
            this.adapterLookupDays.ClearBeforeFill = true;
            // 
            // adapterEmployeeDropDown
            // 
            this.adapterEmployeeDropDown.ClearBeforeFill = true;
            // 
            // groupTotals
            // 
            this.groupTotals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupTotals.Controls.Add(this.txtTotalTakeTimeOff);
            this.groupTotals.Controls.Add(this.txtTotalOvertime);
            this.groupTotals.Controls.Add(this.txtTotalHours);
            this.groupTotals.Controls.Add(this.txtTotalBonus1050);
            this.groupTotals.Controls.Add(this.txtTotalBonus1040);
            this.groupTotals.Controls.Add(this.txtTotalBonus1030);
            this.groupTotals.Controls.Add(this.txtTotalBonus1020);
            this.groupTotals.Controls.Add(this.txtTotalBonus1010);
            this.groupTotals.Location = new System.Drawing.Point(15, 418);
            this.groupTotals.Name = "groupTotals";
            this.groupTotals.Size = new System.Drawing.Size(714, 41);
            this.groupTotals.TabIndex = 6;
            this.groupTotals.TabStop = false;
            this.groupTotals.Text = "[Totaler]";
            // 
            // txtTotalTakeTimeOff
            // 
            this.txtTotalTakeTimeOff.Location = new System.Drawing.Point(501, 13);
            this.txtTotalTakeTimeOff.Name = "txtTotalTakeTimeOff";
            this.txtTotalTakeTimeOff.ReadOnly = true;
            this.txtTotalTakeTimeOff.Size = new System.Drawing.Size(45, 20);
            this.txtTotalTakeTimeOff.TabIndex = 7;
            this.txtTotalTakeTimeOff.TabStop = false;
            this.txtTotalTakeTimeOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalOvertime
            // 
            this.txtTotalOvertime.Location = new System.Drawing.Point(457, 13);
            this.txtTotalOvertime.Name = "txtTotalOvertime";
            this.txtTotalOvertime.ReadOnly = true;
            this.txtTotalOvertime.Size = new System.Drawing.Size(45, 20);
            this.txtTotalOvertime.TabIndex = 6;
            this.txtTotalOvertime.TabStop = false;
            this.txtTotalOvertime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalHours
            // 
            this.txtTotalHours.Location = new System.Drawing.Point(193, 13);
            this.txtTotalHours.Name = "txtTotalHours";
            this.txtTotalHours.ReadOnly = true;
            this.txtTotalHours.Size = new System.Drawing.Size(45, 20);
            this.txtTotalHours.TabIndex = 5;
            this.txtTotalHours.TabStop = false;
            this.txtTotalHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalBonus1050
            // 
            this.txtTotalBonus1050.Location = new System.Drawing.Point(413, 13);
            this.txtTotalBonus1050.Name = "txtTotalBonus1050";
            this.txtTotalBonus1050.ReadOnly = true;
            this.txtTotalBonus1050.Size = new System.Drawing.Size(45, 20);
            this.txtTotalBonus1050.TabIndex = 4;
            this.txtTotalBonus1050.TabStop = false;
            this.txtTotalBonus1050.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalBonus1040
            // 
            this.txtTotalBonus1040.Location = new System.Drawing.Point(369, 13);
            this.txtTotalBonus1040.Name = "txtTotalBonus1040";
            this.txtTotalBonus1040.ReadOnly = true;
            this.txtTotalBonus1040.Size = new System.Drawing.Size(45, 20);
            this.txtTotalBonus1040.TabIndex = 3;
            this.txtTotalBonus1040.TabStop = false;
            this.txtTotalBonus1040.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalBonus1030
            // 
            this.txtTotalBonus1030.Location = new System.Drawing.Point(325, 13);
            this.txtTotalBonus1030.Name = "txtTotalBonus1030";
            this.txtTotalBonus1030.ReadOnly = true;
            this.txtTotalBonus1030.Size = new System.Drawing.Size(45, 20);
            this.txtTotalBonus1030.TabIndex = 2;
            this.txtTotalBonus1030.TabStop = false;
            this.txtTotalBonus1030.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalBonus1020
            // 
            this.txtTotalBonus1020.Location = new System.Drawing.Point(281, 13);
            this.txtTotalBonus1020.Name = "txtTotalBonus1020";
            this.txtTotalBonus1020.ReadOnly = true;
            this.txtTotalBonus1020.Size = new System.Drawing.Size(45, 20);
            this.txtTotalBonus1020.TabIndex = 1;
            this.txtTotalBonus1020.TabStop = false;
            this.txtTotalBonus1020.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalBonus1010
            // 
            this.txtTotalBonus1010.Location = new System.Drawing.Point(237, 13);
            this.txtTotalBonus1010.Name = "txtTotalBonus1010";
            this.txtTotalBonus1010.ReadOnly = true;
            this.txtTotalBonus1010.Size = new System.Drawing.Size(45, 20);
            this.txtTotalBonus1010.TabIndex = 0;
            this.txtTotalBonus1010.TabStop = false;
            this.txtTotalBonus1010.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gridSalary
            // 
            this.gridSalary.AllowUserToResizeColumns = false;
            this.gridSalary.AllowUserToResizeRows = false;
            this.gridSalary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSalary.AutoGenerateColumns = false;
            this.gridSalary.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridSalary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridSalary.ColumnHeadersHeight = 35;
            this.gridSalary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridSalary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFromTimeAsString,
            this.colRegDateAsString,
            this.colToTimeAsString,
            this.colTakeTimeOff,
            this.colBonus1010,
            this.colBonus1020,
            this.colBonus1030,
            this.colBonus1040,
            this.colBonus1050,
            this.colSiteCode,
            this.colSiteCodeButton,
            this.colRemarks,
            this.colDay,
            this.colHours,
            this.colOvertime});
            this.gridSalary.DataSource = this.bindingSalaryRegistration;
            this.gridSalary.Location = new System.Drawing.Point(15, 72);
            this.gridSalary.MultiSelect = false;
            this.gridSalary.Name = "gridSalary";
            this.gridSalary.RowHeadersWidth = 25;
            this.gridSalary.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridSalary.Size = new System.Drawing.Size(714, 340);
            this.gridSalary.TabIndex = 1;
            this.gridSalary.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridSalary_CellBeginEdit);
            this.gridSalary.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.drS_DataGridView1_RowValidating);
            this.gridSalary.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gridSalary_CellPainting);
            this.gridSalary.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gridSalary_RowsAdded);
            this.gridSalary.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.drS_DataGridView1_CellEndEdit);
            this.gridSalary.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridSalary_KeyUp);
            this.gridSalary.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.gridSalary_RowsRemoved);
            this.gridSalary.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSalary_CellContentClick);
            // 
            // colFromTimeAsString
            // 
            this.colFromTimeAsString.DataPropertyName = "FromTimeAsString";
            this.colFromTimeAsString.HeaderText = "[Fra kl.]";
            this.colFromTimeAsString.MaxInputLength = 5;
            this.colFromTimeAsString.Name = "colFromTimeAsString";
            this.colFromTimeAsString.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colFromTimeAsString.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colFromTimeAsString.Width = 35;
            // 
            // colRegDateAsString
            // 
            this.colRegDateAsString.DataPropertyName = "RegDateAsString";
            this.colRegDateAsString.HeaderText = "[Dato]";
            this.colRegDateAsString.Name = "colRegDateAsString";
            this.colRegDateAsString.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRegDateAsString.Width = 67;
            // 
            // colToTimeAsString
            // 
            this.colToTimeAsString.DataPropertyName = "ToTimeAsString";
            this.colToTimeAsString.HeaderText = "[Til kl.]";
            this.colToTimeAsString.Name = "colToTimeAsString";
            this.colToTimeAsString.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colToTimeAsString.Width = 35;
            // 
            // colTakeTimeOff
            // 
            this.colTakeTimeOff.DataPropertyName = "TakeTimeOff";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.colTakeTimeOff.DefaultCellStyle = dataGridViewCellStyle1;
            this.colTakeTimeOff.HeaderText = "[Afsp.]";
            this.colTakeTimeOff.Name = "colTakeTimeOff";
            this.colTakeTimeOff.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTakeTimeOff.Width = 45;
            // 
            // colBonus1010
            // 
            this.colBonus1010.DataPropertyName = "Bonus1010";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Format = "N2";
            this.colBonus1010.DefaultCellStyle = dataGridViewCellStyle2;
            this.colBonus1010.HeaderText = "[Aften]";
            this.colBonus1010.Name = "colBonus1010";
            this.colBonus1010.ReadOnly = true;
            this.colBonus1010.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBonus1010.Width = 45;
            // 
            // colBonus1020
            // 
            this.colBonus1020.DataPropertyName = "Bonus1020";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Format = "N2";
            this.colBonus1020.DefaultCellStyle = dataGridViewCellStyle3;
            this.colBonus1020.HeaderText = "[Nat]";
            this.colBonus1020.Name = "colBonus1020";
            this.colBonus1020.ReadOnly = true;
            this.colBonus1020.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBonus1020.Width = 45;
            // 
            // colBonus1030
            // 
            this.colBonus1030.DataPropertyName = "Bonus1030";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Format = "N2";
            this.colBonus1030.DefaultCellStyle = dataGridViewCellStyle4;
            this.colBonus1030.HeaderText = "[Lørdag]";
            this.colBonus1030.Name = "colBonus1030";
            this.colBonus1030.ReadOnly = true;
            this.colBonus1030.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBonus1030.Width = 45;
            // 
            // colBonus1040
            // 
            this.colBonus1040.DataPropertyName = "Bonus1040";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Format = "N2";
            this.colBonus1040.DefaultCellStyle = dataGridViewCellStyle5;
            this.colBonus1040.HeaderText = "[Søn- & helligd.]";
            this.colBonus1040.Name = "colBonus1040";
            this.colBonus1040.ReadOnly = true;
            this.colBonus1040.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBonus1040.Width = 45;
            // 
            // colBonus1050
            // 
            this.colBonus1050.DataPropertyName = "Bonus1050";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Format = "N2";
            this.colBonus1050.DefaultCellStyle = dataGridViewCellStyle6;
            this.colBonus1050.HeaderText = "[Søn- & h. nat]";
            this.colBonus1050.Name = "colBonus1050";
            this.colBonus1050.ReadOnly = true;
            this.colBonus1050.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBonus1050.Width = 45;
            // 
            // colSiteCode
            // 
            this.colSiteCode.DataPropertyName = "SiteCode";
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            this.colSiteCode.DefaultCellStyle = dataGridViewCellStyle7;
            this.colSiteCode.HeaderText = "[Station]";
            this.colSiteCode.Name = "colSiteCode";
            this.colSiteCode.ReadOnly = true;
            this.colSiteCode.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colSiteCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSiteCode.Width = 45;
            // 
            // colSiteCodeButton
            // 
            this.colSiteCodeButton.HeaderText = "";
            this.colSiteCodeButton.Name = "colSiteCodeButton";
            this.colSiteCodeButton.Width = 25;
            // 
            // colRemarks
            // 
            this.colRemarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRemarks.DataPropertyName = "Remarks";
            this.colRemarks.HeaderText = "[Bemærkninger]";
            this.colRemarks.Name = "colRemarks";
            this.colRemarks.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colDay
            // 
            this.colDay.DataPropertyName = "DayNo";
            this.colDay.DataSource = this.bindingLookupDays;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            this.colDay.DefaultCellStyle = dataGridViewCellStyle8;
            this.colDay.DisplayMember = "DescShort";
            this.colDay.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colDay.HeaderText = "[Dag]";
            this.colDay.Name = "colDay";
            this.colDay.ReadOnly = true;
            this.colDay.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDay.ValueMember = "DayNo";
            this.colDay.Width = 30;
            // 
            // colHours
            // 
            this.colHours.DataPropertyName = "Hours";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Format = "N2";
            this.colHours.DefaultCellStyle = dataGridViewCellStyle9;
            this.colHours.HeaderText = "[I alt timer]";
            this.colHours.Name = "colHours";
            this.colHours.ReadOnly = true;
            this.colHours.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colHours.Width = 45;
            // 
            // colOvertime
            // 
            this.colOvertime.DataPropertyName = "Overtime";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            this.colOvertime.DefaultCellStyle = dataGridViewCellStyle10;
            this.colOvertime.HeaderText = "[Overtid]";
            this.colOvertime.Name = "colOvertime";
            this.colOvertime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colOvertime.Width = 45;
            // 
            // PrlSalaryReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 501);
            this.Controls.Add(this.groupTotals);
            this.Controls.Add(this.gridSalary);
            this.Controls.Add(this.comboEmployeeNo);
            this.Controls.Add(this.lbEmployeeNo);
            this.Controls.Add(this.txtSalaryPeriod);
            this.Controls.Add(this.lbSalaryPeriod);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PrlSalaryReg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrlSalaryReg";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrlSalaryReg_FormClosing);
            this.Load += new System.EventHandler(this.PrlSalaryReg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingEmployeeDropDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPayroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSalaryRegistration)).EndInit();
            this.groupTotals.ResumeLayout(false);
            this.groupTotals.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSalary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbSalaryPeriod;
        private System.Windows.Forms.Label txtSalaryPeriod;
        private System.Windows.Forms.Label lbEmployeeNo;
        private System.Windows.Forms.ComboBox comboEmployeeNo;
        private DRS.Extensions.DRS_DataGridView gridSalary;
        private Payroll dsPayroll;
        private System.Windows.Forms.BindingSource bindingSalaryRegistration;
        private RBOS.PayrollTableAdapters.PrlSalaryRegistrationTableAdapter adapterSalaryRegistration;
        private System.Windows.Forms.BindingSource bindingLookupDays;
        private RBOS.PayrollTableAdapters.PrlLookupDaysTableAdapter adapterLookupDays;
        private System.Windows.Forms.BindingSource bindingEmployeeDropDown;
        private RBOS.PayrollTableAdapters.PrlEmployeeDropDownTableAdapter adapterEmployeeDropDown;
        private System.Windows.Forms.GroupBox groupTotals;
        private System.Windows.Forms.TextBox txtTotalTakeTimeOff;
        private System.Windows.Forms.TextBox txtTotalOvertime;
        private System.Windows.Forms.TextBox txtTotalHours;
        private System.Windows.Forms.TextBox txtTotalBonus1050;
        private System.Windows.Forms.TextBox txtTotalBonus1040;
        private System.Windows.Forms.TextBox txtTotalBonus1030;
        private System.Windows.Forms.TextBox txtTotalBonus1020;
        private System.Windows.Forms.TextBox txtTotalBonus1010;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFromTimeAsString;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegDateAsString;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToTimeAsString;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTakeTimeOff;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBonus1010;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBonus1020;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBonus1030;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBonus1040;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBonus1050;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSiteCode;
        private System.Windows.Forms.DataGridViewButtonColumn colSiteCodeButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemarks;
        private System.Windows.Forms.DataGridViewComboBoxColumn colDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOvertime;
    }
}