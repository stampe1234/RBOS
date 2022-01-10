namespace RBOS
{
    partial class PrlAbsense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrlAbsense));
            this.comboEmployeeNo = new System.Windows.Forms.ComboBox();
            this.bindingEmployeeDropDown = new System.Windows.Forms.BindingSource(this.components);
            this.dsPayroll = new RBOS.Payroll();
            this.lbEmployeeNo = new System.Windows.Forms.Label();
            this.txtSalaryPeriod = new System.Windows.Forms.Label();
            this.lbSalaryPeriod = new System.Windows.Forms.Label();
            this.adapterEmployeeDropDown = new RBOS.PayrollTableAdapters.PrlEmployeeDropDownTableAdapter();
            this.bindingLookupDays = new System.Windows.Forms.BindingSource(this.components);
            this.bindingAbsense = new System.Windows.Forms.BindingSource(this.components);
            this.adapterAbsense = new RBOS.PayrollTableAdapters.PrlAbsenseTableAdapter();
            this.adapterLookupDays = new RBOS.PayrollTableAdapters.PrlLookupDaysTableAdapter();
            this.btnClose = new System.Windows.Forms.Button();
            this.bindingLookupAbsenseCodesAll = new System.Windows.Forms.BindingSource(this.components);
            this.adapterLookupAbsenseCodesAll = new RBOS.PayrollTableAdapters.PrlLookupAbsenseCodesAllTableAdapter();
            this.txtTotalDays = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTotalHours = new System.Windows.Forms.TextBox();
            this.gridAbsense = new DRS.Extensions.DRS_DataGridView();
            this.colDayNo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colFromDateAsString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFromDatepPicker = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colToDateAsString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToDatePicker = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colAbsenseCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAbsenseCodeButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colAbsenseCodeDescription = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEjRefunderet = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingEmployeeDropDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPayroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingAbsense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupAbsenseCodesAll)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAbsense)).BeginInit();
            this.SuspendLayout();
            // 
            // comboEmployeeNo
            // 
            this.comboEmployeeNo.DataSource = this.bindingEmployeeDropDown;
            this.comboEmployeeNo.DisplayMember = "DisplayValue";
            this.comboEmployeeNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEmployeeNo.FormattingEnabled = true;
            this.comboEmployeeNo.Location = new System.Drawing.Point(118, 37);
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
            // lbEmployeeNo
            // 
            this.lbEmployeeNo.AutoSize = true;
            this.lbEmployeeNo.Location = new System.Drawing.Point(12, 37);
            this.lbEmployeeNo.Name = "lbEmployeeNo";
            this.lbEmployeeNo.Size = new System.Drawing.Size(84, 13);
            this.lbEmployeeNo.TabIndex = 7;
            this.lbEmployeeNo.Text = "[Medarbejdernr.]";
            // 
            // txtSalaryPeriod
            // 
            this.txtSalaryPeriod.AutoSize = true;
            this.txtSalaryPeriod.Location = new System.Drawing.Point(118, 13);
            this.txtSalaryPeriod.Name = "txtSalaryPeriod";
            this.txtSalaryPeriod.Size = new System.Drawing.Size(83, 13);
            this.txtSalaryPeriod.TabIndex = 6;
            this.txtSalaryPeriod.Text = "[lønperiodedata]";
            // 
            // lbSalaryPeriod
            // 
            this.lbSalaryPeriod.AutoSize = true;
            this.lbSalaryPeriod.Location = new System.Drawing.Point(12, 13);
            this.lbSalaryPeriod.Name = "lbSalaryPeriod";
            this.lbSalaryPeriod.Size = new System.Drawing.Size(66, 13);
            this.lbSalaryPeriod.TabIndex = 5;
            this.lbSalaryPeriod.Text = "[Lønperiode]";
            // 
            // adapterEmployeeDropDown
            // 
            this.adapterEmployeeDropDown.ClearBeforeFill = true;
            // 
            // bindingLookupDays
            // 
            this.bindingLookupDays.DataMember = "PrlLookupDays";
            this.bindingLookupDays.DataSource = this.dsPayroll;
            // 
            // bindingAbsense
            // 
            this.bindingAbsense.DataMember = "PrlAbsense";
            this.bindingAbsense.DataSource = this.dsPayroll;
            // 
            // adapterAbsense
            // 
            this.adapterAbsense.ClearBeforeFill = true;
            // 
            // adapterLookupDays
            // 
            this.adapterLookupDays.ClearBeforeFill = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(531, 437);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // bindingLookupAbsenseCodesAll
            // 
            this.bindingLookupAbsenseCodesAll.DataMember = "PrlLookupAbsenseCodesAll";
            this.bindingLookupAbsenseCodesAll.DataSource = this.dsPayroll;
            // 
            // adapterLookupAbsenseCodesAll
            // 
            this.adapterLookupAbsenseCodesAll.ClearBeforeFill = true;
            // 
            // txtTotalDays
            // 
            this.txtTotalDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalDays.Location = new System.Drawing.Point(528, 13);
            this.txtTotalDays.Name = "txtTotalDays";
            this.txtTotalDays.ReadOnly = true;
            this.txtTotalDays.Size = new System.Drawing.Size(50, 20);
            this.txtTotalDays.TabIndex = 1;
            this.txtTotalDays.TabStop = false;
            this.txtTotalDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtTotalHours);
            this.groupBox1.Controls.Add(this.txtTotalDays);
            this.groupBox1.Location = new System.Drawing.Point(12, 390);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 41);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[Totaler]";
            // 
            // txtTotalHours
            // 
            this.txtTotalHours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalHours.Location = new System.Drawing.Point(479, 13);
            this.txtTotalHours.Name = "txtTotalHours";
            this.txtTotalHours.ReadOnly = true;
            this.txtTotalHours.Size = new System.Drawing.Size(50, 20);
            this.txtTotalHours.TabIndex = 0;
            this.txtTotalHours.TabStop = false;
            this.txtTotalHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gridAbsense
            // 
            this.gridAbsense.AllowUserToResizeColumns = false;
            this.gridAbsense.AllowUserToResizeRows = false;
            this.gridAbsense.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridAbsense.AutoGenerateColumns = false;
            this.gridAbsense.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridAbsense.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridAbsense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAbsense.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDayNo,
            this.colFromDateAsString,
            this.colFromDatepPicker,
            this.colToDateAsString,
            this.colToDatePicker,
            this.colAbsenseCode,
            this.colAbsenseCodeButton,
            this.colAbsenseCodeDescription,
            this.colHours,
            this.colDays,
            this.colEjRefunderet});
            this.gridAbsense.DataSource = this.bindingAbsense;
            this.gridAbsense.Location = new System.Drawing.Point(12, 64);
            this.gridAbsense.MultiSelect = false;
            this.gridAbsense.Name = "gridAbsense";
            this.gridAbsense.RowHeadersWidth = 25;
            this.gridAbsense.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridAbsense.Size = new System.Drawing.Size(594, 320);
            this.gridAbsense.TabIndex = 1;
            this.gridAbsense.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridAbsense_CellBeginEdit);
            this.gridAbsense.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAbsense_RowEnter);
            this.gridAbsense.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridAbsense_RowValidating);
            this.gridAbsense.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gridAbsense_RowsAdded);
            this.gridAbsense.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAbsense_CellEndEdit);
            this.gridAbsense.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gridAbsense_CellPainting);
            this.gridAbsense.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridAbsense_KeyDown);
            this.gridAbsense.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.gridAbsense_RowsRemoved);
            this.gridAbsense.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridAbsense_KeyUp);
            this.gridAbsense.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAbsense_CellContentClick);
            // 
            // colDayNo
            // 
            this.colDayNo.DataPropertyName = "DayNo";
            this.colDayNo.DataSource = this.bindingLookupDays;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.colDayNo.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDayNo.DisplayMember = "DescShort";
            this.colDayNo.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colDayNo.HeaderText = "Day";
            this.colDayNo.Name = "colDayNo";
            this.colDayNo.ReadOnly = true;
            this.colDayNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDayNo.ValueMember = "DayNo";
            this.colDayNo.Width = 40;
            // 
            // colFromDateAsString
            // 
            this.colFromDateAsString.DataPropertyName = "FromDateAsString";
            this.colFromDateAsString.HeaderText = "FromDate";
            this.colFromDateAsString.Name = "colFromDateAsString";
            this.colFromDateAsString.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colFromDateAsString.Width = 70;
            // 
            // colFromDatepPicker
            // 
            this.colFromDatepPicker.HeaderText = "";
            this.colFromDatepPicker.Name = "colFromDatepPicker";
            this.colFromDatepPicker.Width = 25;
            // 
            // colToDateAsString
            // 
            this.colToDateAsString.DataPropertyName = "ToDateAsString";
            this.colToDateAsString.HeaderText = "ToDate";
            this.colToDateAsString.Name = "colToDateAsString";
            this.colToDateAsString.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colToDateAsString.Width = 70;
            // 
            // colToDatePicker
            // 
            this.colToDatePicker.HeaderText = "";
            this.colToDatePicker.Name = "colToDatePicker";
            this.colToDatePicker.Width = 25;
            // 
            // colAbsenseCode
            // 
            this.colAbsenseCode.DataPropertyName = "AbsenseCode";
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            this.colAbsenseCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.colAbsenseCode.HeaderText = "Code";
            this.colAbsenseCode.Name = "colAbsenseCode";
            this.colAbsenseCode.ReadOnly = true;
            this.colAbsenseCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAbsenseCode.Width = 50;
            // 
            // colAbsenseCodeButton
            // 
            this.colAbsenseCodeButton.HeaderText = "";
            this.colAbsenseCodeButton.Name = "colAbsenseCodeButton";
            this.colAbsenseCodeButton.Width = 25;
            // 
            // colAbsenseCodeDescription
            // 
            this.colAbsenseCodeDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAbsenseCodeDescription.DataPropertyName = "AbsenseCode";
            this.colAbsenseCodeDescription.DataSource = this.bindingLookupAbsenseCodesAll;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            this.colAbsenseCodeDescription.DefaultCellStyle = dataGridViewCellStyle3;
            this.colAbsenseCodeDescription.DisplayMember = "Description";
            this.colAbsenseCodeDescription.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colAbsenseCodeDescription.HeaderText = "Description";
            this.colAbsenseCodeDescription.Name = "colAbsenseCodeDescription";
            this.colAbsenseCodeDescription.ReadOnly = true;
            this.colAbsenseCodeDescription.ValueMember = "AbsenseCode";
            // 
            // colHours
            // 
            this.colHours.DataPropertyName = "Hours";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.colHours.DefaultCellStyle = dataGridViewCellStyle4;
            this.colHours.HeaderText = "Hours";
            this.colHours.Name = "colHours";
            this.colHours.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colHours.Width = 50;
            // 
            // colDays
            // 
            this.colDays.DataPropertyName = "Days";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            this.colDays.DefaultCellStyle = dataGridViewCellStyle5;
            this.colDays.HeaderText = "Days";
            this.colDays.Name = "colDays";
            this.colDays.ReadOnly = true;
            this.colDays.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDays.Width = 50;
            // 
            // colEjRefunderet
            // 
            this.colEjRefunderet.DataPropertyName = "EjRefunderet";
            this.colEjRefunderet.HeaderText = "[Ej refunderet]";
            this.colEjRefunderet.Name = "colEjRefunderet";
            this.colEjRefunderet.Width = 30;
            // 
            // PrlAbsense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 472);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gridAbsense);
            this.Controls.Add(this.comboEmployeeNo);
            this.Controls.Add(this.lbEmployeeNo);
            this.Controls.Add(this.txtSalaryPeriod);
            this.Controls.Add(this.lbSalaryPeriod);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PrlAbsense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrlAbsense";
            this.Load += new System.EventHandler(this.PrlAbsense_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrlAbsense_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.bindingEmployeeDropDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPayroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingAbsense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupAbsenseCodesAll)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAbsense)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboEmployeeNo;
        private System.Windows.Forms.Label lbEmployeeNo;
        private System.Windows.Forms.Label txtSalaryPeriod;
        private System.Windows.Forms.Label lbSalaryPeriod;
        private Payroll dsPayroll;
        private System.Windows.Forms.BindingSource bindingEmployeeDropDown;
        private RBOS.PayrollTableAdapters.PrlEmployeeDropDownTableAdapter adapterEmployeeDropDown;
        private DRS.Extensions.DRS_DataGridView gridAbsense;
        private System.Windows.Forms.BindingSource bindingAbsense;
        private RBOS.PayrollTableAdapters.PrlAbsenseTableAdapter adapterAbsense;
        private System.Windows.Forms.BindingSource bindingLookupDays;
        private RBOS.PayrollTableAdapters.PrlLookupDaysTableAdapter adapterLookupDays;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.BindingSource bindingLookupAbsenseCodesAll;
        private RBOS.PayrollTableAdapters.PrlLookupAbsenseCodesAllTableAdapter adapterLookupAbsenseCodesAll;
        private System.Windows.Forms.TextBox txtTotalDays;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTotalHours;
        private System.Windows.Forms.DataGridViewComboBoxColumn colDayNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFromDateAsString;
        private System.Windows.Forms.DataGridViewButtonColumn colFromDatepPicker;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToDateAsString;
        private System.Windows.Forms.DataGridViewButtonColumn colToDatePicker;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAbsenseCode;
        private System.Windows.Forms.DataGridViewButtonColumn colAbsenseCodeButton;
        private System.Windows.Forms.DataGridViewComboBoxColumn colAbsenseCodeDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDays;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEjRefunderet;
    }
}