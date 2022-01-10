namespace RBOS
{
    partial class PrlRptWithdrawFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrlRptWithdrawFrm));
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.comboWithdrawType = new System.Windows.Forms.ComboBox();
            this.bindingPrlWithdrawType = new System.Windows.Forms.BindingSource(this.components);
            this.dsPayroll = new RBOS.Payroll();
            this.comboEmployee = new System.Windows.Forms.ComboBox();
            this.bindingPrlEmployeeComboWithAll = new System.Windows.Forms.BindingSource(this.components);
            this.lbDateInterval = new System.Windows.Forms.Label();
            this.lbWithdrawType = new System.Windows.Forms.Label();
            this.lbEmployee = new System.Windows.Forms.Label();
            this.adapterPrlEmployeeComboWithAll = new RBOS.PayrollTableAdapters.PrlEmployeeComboWithAllTableAdapter();
            this.adapterPrlWithdrawType = new RBOS.PayrollTableAdapters.PrlWithdrawTypeTableAdapter();
            this.rptPrlRptWithdraw = new RBOS.PrlRptWithdrawRpt();
            ((System.ComponentModel.ISupportInitialize)(this.bindingPrlWithdrawType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPayroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingPrlEmployeeComboWithAll)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(92, 103);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "[Print]";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(173, 103);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 1;
            this.btnPreview.Text = "[Preview]";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(254, 103);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtEndDate
            // 
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEndDate.Location = new System.Drawing.Point(198, 12);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(89, 20);
            this.dtEndDate.TabIndex = 3;
            this.dtEndDate.ValueChanged += new System.EventHandler(this.dtEndDate_ValueChanged);
            // 
            // dtStartDate
            // 
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStartDate.Location = new System.Drawing.Point(103, 12);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(89, 20);
            this.dtStartDate.TabIndex = 4;
            this.dtStartDate.ValueChanged += new System.EventHandler(this.dtStartDate_ValueChanged);
            // 
            // comboWithdrawType
            // 
            this.comboWithdrawType.DataSource = this.bindingPrlWithdrawType;
            this.comboWithdrawType.DisplayMember = "Description";
            this.comboWithdrawType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboWithdrawType.FormattingEnabled = true;
            this.comboWithdrawType.Location = new System.Drawing.Point(103, 38);
            this.comboWithdrawType.Name = "comboWithdrawType";
            this.comboWithdrawType.Size = new System.Drawing.Size(119, 21);
            this.comboWithdrawType.TabIndex = 5;
            this.comboWithdrawType.ValueMember = "WithdrawType";
            // 
            // bindingPrlWithdrawType
            // 
            this.bindingPrlWithdrawType.DataMember = "PrlWithdrawType";
            this.bindingPrlWithdrawType.DataSource = this.dsPayroll;
            // 
            // dsPayroll
            // 
            this.dsPayroll.DataSetName = "Payroll";
            this.dsPayroll.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboEmployee
            // 
            this.comboEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboEmployee.DataSource = this.bindingPrlEmployeeComboWithAll;
            this.comboEmployee.DisplayMember = "Description";
            this.comboEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEmployee.FormattingEnabled = true;
            this.comboEmployee.Location = new System.Drawing.Point(103, 65);
            this.comboEmployee.Name = "comboEmployee";
            this.comboEmployee.Size = new System.Drawing.Size(226, 21);
            this.comboEmployee.TabIndex = 6;
            this.comboEmployee.ValueMember = "EmployeeNo";
            // 
            // bindingPrlEmployeeComboWithAll
            // 
            this.bindingPrlEmployeeComboWithAll.DataMember = "PrlEmployeeComboWithAll";
            this.bindingPrlEmployeeComboWithAll.DataSource = this.dsPayroll;
            // 
            // lbDateInterval
            // 
            this.lbDateInterval.AutoSize = true;
            this.lbDateInterval.Location = new System.Drawing.Point(12, 16);
            this.lbDateInterval.Name = "lbDateInterval";
            this.lbDateInterval.Size = new System.Drawing.Size(73, 13);
            this.lbDateInterval.TabIndex = 7;
            this.lbDateInterval.Text = "[Dato interval]";
            // 
            // lbWithdrawType
            // 
            this.lbWithdrawType.AutoSize = true;
            this.lbWithdrawType.Location = new System.Drawing.Point(12, 41);
            this.lbWithdrawType.Name = "lbWithdrawType";
            this.lbWithdrawType.Size = new System.Drawing.Size(76, 13);
            this.lbWithdrawType.TabIndex = 9;
            this.lbWithdrawType.Text = "[Løntræk type]";
            // 
            // lbEmployee
            // 
            this.lbEmployee.AutoSize = true;
            this.lbEmployee.Location = new System.Drawing.Point(12, 68);
            this.lbEmployee.Name = "lbEmployee";
            this.lbEmployee.Size = new System.Drawing.Size(72, 13);
            this.lbEmployee.TabIndex = 10;
            this.lbEmployee.Text = "[Medarbejder]";
            // 
            // adapterPrlEmployeeComboWithAll
            // 
            this.adapterPrlEmployeeComboWithAll.ClearBeforeFill = true;
            // 
            // adapterPrlWithdrawType
            // 
            this.adapterPrlWithdrawType.ClearBeforeFill = true;
            // 
            // PrlRptWithdrawFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 138);
            this.Controls.Add(this.lbEmployee);
            this.Controls.Add(this.lbWithdrawType);
            this.Controls.Add(this.lbDateInterval);
            this.Controls.Add(this.comboEmployee);
            this.Controls.Add(this.comboWithdrawType);
            this.Controls.Add(this.dtStartDate);
            this.Controls.Add(this.dtEndDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PrlRptWithdrawFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Løn- og benzintræk]";
            this.Load += new System.EventHandler(this.PrlRptWithdrawFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingPrlWithdrawType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPayroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingPrlEmployeeComboWithAll)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.ComboBox comboWithdrawType;
        private System.Windows.Forms.ComboBox comboEmployee;
        private System.Windows.Forms.Label lbDateInterval;
        private System.Windows.Forms.Label lbWithdrawType;
        private System.Windows.Forms.Label lbEmployee;
        private Payroll dsPayroll;
        private System.Windows.Forms.BindingSource bindingPrlEmployeeComboWithAll;
        private RBOS.PayrollTableAdapters.PrlEmployeeComboWithAllTableAdapter adapterPrlEmployeeComboWithAll;
        private System.Windows.Forms.BindingSource bindingPrlWithdrawType;
        private RBOS.PayrollTableAdapters.PrlWithdrawTypeTableAdapter adapterPrlWithdrawType;
        private PrlRptWithdrawRpt rptPrlRptWithdraw;
    }
}