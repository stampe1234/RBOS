namespace RBOS
{
    partial class PrlWithdraw
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrlWithdraw));
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSalaryPeriod = new System.Windows.Forms.Label();
            this.lbSalaryPeriod = new System.Windows.Forms.Label();
            this.bindingLookupEmployeeName = new System.Windows.Forms.BindingSource(this.components);
            this.dsPayroll = new RBOS.Payroll();
            this.bindingWithdrawType = new System.Windows.Forms.BindingSource(this.components);
            this.bindingWithdraw = new System.Windows.Forms.BindingSource(this.components);
            this.adapterWithdraw = new RBOS.PayrollTableAdapters.PrlWithdrawTableAdapter();
            this.adapterLookupEmployeeName = new RBOS.PayrollTableAdapters.PrlLookupEmployeeNameTableAdapter();
            this.adapterWithdrawType = new RBOS.PayrollTableAdapters.PrlWithdrawTypeTableAdapter();
            this.gridWithdraw = new DRS.Extensions.DRS_DataGridView();
            this.colEmployeeButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEmployeeName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colEmployeeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWithdrawType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumberOf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateReg = new DRS.Extensions.DRS_CalendarColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupEmployeeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPayroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingWithdrawType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingWithdraw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridWithdraw)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(598, 461);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtSalaryPeriod
            // 
            this.txtSalaryPeriod.AutoSize = true;
            this.txtSalaryPeriod.Location = new System.Drawing.Point(118, 9);
            this.txtSalaryPeriod.Name = "txtSalaryPeriod";
            this.txtSalaryPeriod.Size = new System.Drawing.Size(83, 13);
            this.txtSalaryPeriod.TabIndex = 5;
            this.txtSalaryPeriod.Text = "[lønperiodedata]";
            // 
            // lbSalaryPeriod
            // 
            this.lbSalaryPeriod.AutoSize = true;
            this.lbSalaryPeriod.Location = new System.Drawing.Point(12, 9);
            this.lbSalaryPeriod.Name = "lbSalaryPeriod";
            this.lbSalaryPeriod.Size = new System.Drawing.Size(66, 13);
            this.lbSalaryPeriod.TabIndex = 4;
            this.lbSalaryPeriod.Text = "[Lønperiode]";
            // 
            // bindingLookupEmployeeName
            // 
            this.bindingLookupEmployeeName.DataMember = "PrlLookupEmployeeName";
            this.bindingLookupEmployeeName.DataSource = this.dsPayroll;
            // 
            // dsPayroll
            // 
            this.dsPayroll.DataSetName = "Payroll";
            this.dsPayroll.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingWithdrawType
            // 
            this.bindingWithdrawType.DataMember = "PrlWithdrawType";
            this.bindingWithdrawType.DataSource = this.dsPayroll;
            // 
            // bindingWithdraw
            // 
            this.bindingWithdraw.DataMember = "PrlWithdraw";
            this.bindingWithdraw.DataSource = this.dsPayroll;
            // 
            // adapterWithdraw
            // 
            this.adapterWithdraw.ClearBeforeFill = true;
            // 
            // adapterLookupEmployeeName
            // 
            this.adapterLookupEmployeeName.ClearBeforeFill = true;
            // 
            // adapterWithdrawType
            // 
            this.adapterWithdrawType.ClearBeforeFill = true;
            // 
            // gridWithdraw
            // 
            this.gridWithdraw.AllowUserToResizeColumns = false;
            this.gridWithdraw.AllowUserToResizeRows = false;
            this.gridWithdraw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridWithdraw.AutoGenerateColumns = false;
            this.gridWithdraw.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridWithdraw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridWithdraw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridWithdraw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEmployeeButton,
            this.colEmployeeName,
            this.colEmployeeNo,
            this.colWithdrawType,
            this.colRemark,
            this.colNumberOf,
            this.colAmount,
            this.colDateReg});
            this.gridWithdraw.DataSource = this.bindingWithdraw;
            this.gridWithdraw.Location = new System.Drawing.Point(12, 32);
            this.gridWithdraw.MultiSelect = false;
            this.gridWithdraw.Name = "gridWithdraw";
            this.gridWithdraw.RowHeadersWidth = 25;
            this.gridWithdraw.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridWithdraw.Size = new System.Drawing.Size(661, 422);
            this.gridWithdraw.TabIndex = 3;
            this.gridWithdraw.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridWithdraw_RowValidating);
            this.gridWithdraw.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gridWithdraw_CellPainting);
            this.gridWithdraw.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridWithdraw_CellEndEdit);
            this.gridWithdraw.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.drS_DataGridView1_CellContentClick);
            // 
            // colEmployeeButton
            // 
            this.colEmployeeButton.HeaderText = "";
            this.colEmployeeButton.Name = "colEmployeeButton";
            this.colEmployeeButton.Width = 25;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.DataPropertyName = "EmployeeNo";
            this.colEmployeeName.DataSource = this.bindingLookupEmployeeName;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.colEmployeeName.DefaultCellStyle = dataGridViewCellStyle1;
            this.colEmployeeName.DisplayMember = "Name";
            this.colEmployeeName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colEmployeeName.HeaderText = "Name";
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.ReadOnly = true;
            this.colEmployeeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEmployeeName.ValueMember = "EmployeeNo";
            // 
            // colEmployeeNo
            // 
            this.colEmployeeNo.DataPropertyName = "EmployeeNo";
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            this.colEmployeeNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.colEmployeeNo.HeaderText = "No.";
            this.colEmployeeNo.Name = "colEmployeeNo";
            this.colEmployeeNo.ReadOnly = true;
            this.colEmployeeNo.Width = 60;
            // 
            // colWithdrawType
            // 
            this.colWithdrawType.DataPropertyName = "WithdrawType";
            this.colWithdrawType.DataSource = this.bindingWithdrawType;
            this.colWithdrawType.DisplayMember = "Description";
            this.colWithdrawType.HeaderText = "Type";
            this.colWithdrawType.Name = "colWithdrawType";
            this.colWithdrawType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colWithdrawType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colWithdrawType.ValueMember = "WithdrawType";
            // 
            // colRemark
            // 
            this.colRemark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRemark.DataPropertyName = "Remark";
            this.colRemark.HeaderText = "Remark";
            this.colRemark.MaxInputLength = 50;
            this.colRemark.Name = "colRemark";
            // 
            // colNumberOf
            // 
            this.colNumberOf.DataPropertyName = "NumberOf";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colNumberOf.DefaultCellStyle = dataGridViewCellStyle3;
            this.colNumberOf.HeaderText = "Number Of";
            this.colNumberOf.Name = "colNumberOf";
            this.colNumberOf.Width = 40;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Width = 60;
            // 
            // colDateReg
            // 
            this.colDateReg.DataPropertyName = "DateReg";
            this.colDateReg.HeaderText = "Date";
            this.colDateReg.Name = "colDateReg";
            this.colDateReg.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDateReg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDateReg.Width = 80;
            // 
            // PrlWithdraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 496);
            this.Controls.Add(this.txtSalaryPeriod);
            this.Controls.Add(this.lbSalaryPeriod);
            this.Controls.Add(this.gridWithdraw);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PrlWithdraw";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrlWithdraw";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrlWithdraw_FormClosing);
            this.Load += new System.EventHandler(this.PrlWithdraw_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupEmployeeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPayroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingWithdrawType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingWithdraw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridWithdraw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private DRS.Extensions.DRS_DataGridView gridWithdraw;
        private System.Windows.Forms.Label txtSalaryPeriod;
        private System.Windows.Forms.Label lbSalaryPeriod;
        private Payroll dsPayroll;
        private System.Windows.Forms.BindingSource bindingWithdraw;
        private RBOS.PayrollTableAdapters.PrlWithdrawTableAdapter adapterWithdraw;
        private System.Windows.Forms.BindingSource bindingLookupEmployeeName;
        private RBOS.PayrollTableAdapters.PrlLookupEmployeeNameTableAdapter adapterLookupEmployeeName;
        private System.Windows.Forms.BindingSource bindingWithdrawType;
        private RBOS.PayrollTableAdapters.PrlWithdrawTypeTableAdapter adapterWithdrawType;
        private System.Windows.Forms.DataGridViewButtonColumn colEmployeeButton;
        private System.Windows.Forms.DataGridViewComboBoxColumn colEmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployeeNo;
        private System.Windows.Forms.DataGridViewComboBoxColumn colWithdrawType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumberOf;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private DRS.Extensions.DRS_CalendarColumn colDateReg;
    }
}