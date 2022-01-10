namespace RBOS
{
    partial class PrlSalaryPeriods
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrlSalaryPeriods));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bindingPrlSalaryPeriods = new System.Windows.Forms.BindingSource(this.components);
            this.dsPayroll = new RBOS.Payroll();
            this.adapterPrlSalaryPeriods = new RBOS.PayrollTableAdapters.PrlSalaryPeriodsTableAdapter();
            this.comboYears = new System.Windows.Forms.ComboBox();
            this.bindingSalaryPeriodYears = new System.Windows.Forms.BindingSource(this.components);
            this.adapterSalaryPeriodYears = new RBOS.PayrollTableAdapters.PrlSalaryPeriodYearsTableAdapter();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbYears = new System.Windows.Forms.Label();
            this.gridSalaryPeriods = new DRS.Extensions.DRS_DataGridView();
            this.colPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActiveImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.colApprovedImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.colSentImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingPrlSalaryPeriods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPayroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSalaryPeriodYears)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSalaryPeriods)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingPrlSalaryPeriods
            // 
            this.bindingPrlSalaryPeriods.DataMember = "PrlSalaryPeriods";
            this.bindingPrlSalaryPeriods.DataSource = this.dsPayroll;
            // 
            // dsPayroll
            // 
            this.dsPayroll.DataSetName = "Payroll";
            this.dsPayroll.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // adapterPrlSalaryPeriods
            // 
            this.adapterPrlSalaryPeriods.ClearBeforeFill = true;
            // 
            // comboYears
            // 
            this.comboYears.DataSource = this.bindingSalaryPeriodYears;
            this.comboYears.DisplayMember = "PeriodYear";
            this.comboYears.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboYears.FormattingEnabled = true;
            this.comboYears.Location = new System.Drawing.Point(67, 12);
            this.comboYears.Name = "comboYears";
            this.comboYears.Size = new System.Drawing.Size(68, 21);
            this.comboYears.TabIndex = 1;
            this.comboYears.ValueMember = "PeriodYear";
            // 
            // bindingSalaryPeriodYears
            // 
            this.bindingSalaryPeriodYears.DataMember = "PrlSalaryPeriodYears";
            this.bindingSalaryPeriodYears.DataSource = this.dsPayroll;
            this.bindingSalaryPeriodYears.CurrentChanged += new System.EventHandler(this.prlSalaryPeriodYearsBindingSource_CurrentChanged);
            // 
            // adapterSalaryPeriodYears
            // 
            this.adapterSalaryPeriodYears.ClearBeforeFill = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(299, 349);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "[Save && Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbYears
            // 
            this.lbYears.AutoSize = true;
            this.lbYears.Location = new System.Drawing.Point(12, 15);
            this.lbYears.Name = "lbYears";
            this.lbYears.Size = new System.Drawing.Size(40, 13);
            this.lbYears.TabIndex = 3;
            this.lbYears.Text = "[Years]";
            // 
            // gridSalaryPeriods
            // 
            this.gridSalaryPeriods.AllowUserToAddRows = false;
            this.gridSalaryPeriods.AllowUserToDeleteRows = false;
            this.gridSalaryPeriods.AllowUserToResizeColumns = false;
            this.gridSalaryPeriods.AllowUserToResizeRows = false;
            this.gridSalaryPeriods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSalaryPeriods.AutoGenerateColumns = false;
            this.gridSalaryPeriods.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridSalaryPeriods.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridSalaryPeriods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSalaryPeriods.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPeriod,
            this.colStartDate,
            this.colEndDate,
            this.colActiveImg,
            this.colApprovedImg,
            this.colSentImg});
            this.gridSalaryPeriods.DataSource = this.bindingPrlSalaryPeriods;
            this.gridSalaryPeriods.Location = new System.Drawing.Point(12, 39);
            this.gridSalaryPeriods.MultiSelect = false;
            this.gridSalaryPeriods.Name = "gridSalaryPeriods";
            this.gridSalaryPeriods.RowHeadersVisible = false;
            this.gridSalaryPeriods.RowHeadersWidth = 25;
            this.gridSalaryPeriods.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridSalaryPeriods.Size = new System.Drawing.Size(469, 304);
            this.gridSalaryPeriods.TabIndex = 0;
            this.gridSalaryPeriods.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSalaryPeriods_CellMouseLeave);
            this.gridSalaryPeriods.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSalaryPeriods_CellClick);
            this.gridSalaryPeriods.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSalaryPeriods_CellMouseEnter);
            this.gridSalaryPeriods.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridSalaryPeriods_KeyUp);
            // 
            // colPeriod
            // 
            this.colPeriod.DataPropertyName = "Period";
            this.colPeriod.HeaderText = "Period";
            this.colPeriod.Name = "colPeriod";
            this.colPeriod.ReadOnly = true;
            this.colPeriod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPeriod.Width = 50;
            // 
            // colStartDate
            // 
            this.colStartDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStartDate.DataPropertyName = "StartDate";
            this.colStartDate.HeaderText = "StartDate";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.ReadOnly = true;
            this.colStartDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colEndDate
            // 
            this.colEndDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEndDate.DataPropertyName = "EndDate";
            this.colEndDate.HeaderText = "EndDate";
            this.colEndDate.Name = "colEndDate";
            this.colEndDate.ReadOnly = true;
            this.colEndDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colActiveImg
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle4.NullValue")));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.colActiveImg.DefaultCellStyle = dataGridViewCellStyle4;
            this.colActiveImg.HeaderText = "Active";
            this.colActiveImg.Name = "colActiveImg";
            this.colActiveImg.Width = 70;
            // 
            // colApprovedImg
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle5.NullValue")));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.colApprovedImg.DefaultCellStyle = dataGridViewCellStyle5;
            this.colApprovedImg.HeaderText = "Approved";
            this.colApprovedImg.Name = "colApprovedImg";
            this.colApprovedImg.Width = 70;
            // 
            // colSentImg
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle6.NullValue")));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.colSentImg.DefaultCellStyle = dataGridViewCellStyle6;
            this.colSentImg.HeaderText = "Sent";
            this.colSentImg.Name = "colSentImg";
            this.colSentImg.Width = 70;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(406, 349);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "[Cancel]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PrlSalaryPeriods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 384);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lbYears);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.comboYears);
            this.Controls.Add(this.gridSalaryPeriods);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PrlSalaryPeriods";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrlSalaryPeriods";
            this.Load += new System.EventHandler(this.PrlSalaryPeriods_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingPrlSalaryPeriods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPayroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSalaryPeriodYears)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSalaryPeriods)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DRS.Extensions.DRS_DataGridView gridSalaryPeriods;
        private Payroll dsPayroll;
        private System.Windows.Forms.BindingSource bindingPrlSalaryPeriods;
        private RBOS.PayrollTableAdapters.PrlSalaryPeriodsTableAdapter adapterPrlSalaryPeriods;
        private System.Windows.Forms.ComboBox comboYears;
        private System.Windows.Forms.BindingSource bindingSalaryPeriodYears;
        private RBOS.PayrollTableAdapters.PrlSalaryPeriodYearsTableAdapter adapterSalaryPeriodYears;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbYears;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndDate;
        private System.Windows.Forms.DataGridViewImageColumn colActiveImg;
        private System.Windows.Forms.DataGridViewImageColumn colApprovedImg;
        private System.Windows.Forms.DataGridViewImageColumn colSentImg;

    }
}