namespace RBOS
{
    partial class PrlRptSalRegFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrlRptSalRegFrm));
            this.comboEmployee = new System.Windows.Forms.ComboBox();
            this.bindingPrlEmployeeComboWithAll = new System.Windows.Forms.BindingSource(this.components);
            this.dsPayroll = new RBOS.Payroll();
            this.adapterPrlEmployeeComboWithAll = new RBOS.PayrollTableAdapters.PrlEmployeeComboWithAllTableAdapter();
            this.lbEmployee = new System.Windows.Forms.Label();
            this.comboSalaryPeriod = new System.Windows.Forms.ComboBox();
            this.bindingPrlSalaryPeriods = new System.Windows.Forms.BindingSource(this.components);
            this.lbSalaryPeriod = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.chkIncludeFunc = new System.Windows.Forms.CheckBox();
            this.adapterPrlSalaryPeriods = new RBOS.PayrollTableAdapters.PrlSalaryPeriodsTableAdapter();
            this.rptSalReg = new RBOS.PrlRptSalRegRpt();
            ((System.ComponentModel.ISupportInitialize)(this.bindingPrlEmployeeComboWithAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPayroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingPrlSalaryPeriods)).BeginInit();
            this.SuspendLayout();
            // 
            // comboEmployee
            // 
            this.comboEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboEmployee.DataSource = this.bindingPrlEmployeeComboWithAll;
            this.comboEmployee.DisplayMember = "Description";
            this.comboEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEmployee.FormattingEnabled = true;
            this.comboEmployee.Location = new System.Drawing.Point(12, 67);
            this.comboEmployee.Name = "comboEmployee";
            this.comboEmployee.Size = new System.Drawing.Size(295, 21);
            this.comboEmployee.TabIndex = 0;
            // 
            // bindingPrlEmployeeComboWithAll
            // 
            this.bindingPrlEmployeeComboWithAll.DataMember = "PrlEmployeeComboWithAll";
            this.bindingPrlEmployeeComboWithAll.DataSource = this.dsPayroll;
            this.bindingPrlEmployeeComboWithAll.PositionChanged += new System.EventHandler(this.bindingPrlEmployeeComboWithAll_PositionChanged);
            // 
            // dsPayroll
            // 
            this.dsPayroll.DataSetName = "Payroll";
            this.dsPayroll.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // adapterPrlEmployeeComboWithAll
            // 
            this.adapterPrlEmployeeComboWithAll.ClearBeforeFill = true;
            // 
            // lbEmployee
            // 
            this.lbEmployee.AutoSize = true;
            this.lbEmployee.Location = new System.Drawing.Point(12, 50);
            this.lbEmployee.Name = "lbEmployee";
            this.lbEmployee.Size = new System.Drawing.Size(72, 13);
            this.lbEmployee.TabIndex = 1;
            this.lbEmployee.Text = "[Medarbejder]";
            // 
            // comboSalaryPeriod
            // 
            this.comboSalaryPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboSalaryPeriod.DataSource = this.bindingPrlSalaryPeriods;
            this.comboSalaryPeriod.DisplayMember = "PeriodString";
            this.comboSalaryPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSalaryPeriod.FormattingEnabled = true;
            this.comboSalaryPeriod.Location = new System.Drawing.Point(12, 26);
            this.comboSalaryPeriod.Name = "comboSalaryPeriod";
            this.comboSalaryPeriod.Size = new System.Drawing.Size(295, 21);
            this.comboSalaryPeriod.TabIndex = 2;
            // 
            // bindingPrlSalaryPeriods
            // 
            this.bindingPrlSalaryPeriods.DataMember = "PrlSalaryPeriods";
            this.bindingPrlSalaryPeriods.DataSource = this.dsPayroll;
            this.bindingPrlSalaryPeriods.PositionChanged += new System.EventHandler(this.bindingPrlSalaryPeriods_PositionChanged);
            // 
            // lbSalaryPeriod
            // 
            this.lbSalaryPeriod.AutoSize = true;
            this.lbSalaryPeriod.Location = new System.Drawing.Point(12, 9);
            this.lbSalaryPeriod.Name = "lbSalaryPeriod";
            this.lbSalaryPeriod.Size = new System.Drawing.Size(66, 13);
            this.lbSalaryPeriod.TabIndex = 3;
            this.lbSalaryPeriod.Text = "[Lønperiode]";
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(151, 133);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 4;
            this.btnPreview.Text = "[Preview]";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(232, 133);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(70, 133);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "[Print]";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // chkIncludeFunc
            // 
            this.chkIncludeFunc.AutoSize = true;
            this.chkIncludeFunc.Location = new System.Drawing.Point(12, 101);
            this.chkIncludeFunc.Name = "chkIncludeFunc";
            this.chkIncludeFunc.Size = new System.Drawing.Size(131, 17);
            this.chkIncludeFunc.TabIndex = 7;
            this.chkIncludeFunc.Text = "[Medtag funktionærer]";
            this.chkIncludeFunc.UseVisualStyleBackColor = true;
            // 
            // adapterPrlSalaryPeriods
            // 
            this.adapterPrlSalaryPeriods.ClearBeforeFill = true;
            // 
            // PrlRptSalRegFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 168);
            this.Controls.Add(this.chkIncludeFunc);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.lbSalaryPeriod);
            this.Controls.Add(this.comboSalaryPeriod);
            this.Controls.Add(this.lbEmployee);
            this.Controls.Add(this.comboEmployee);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PrlRptSalRegFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Lønregistrering]";
            this.Load += new System.EventHandler(this.PrlRptSalRegFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingPrlEmployeeComboWithAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPayroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingPrlSalaryPeriods)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboEmployee;
        private Payroll dsPayroll;
        private System.Windows.Forms.BindingSource bindingPrlEmployeeComboWithAll;
        private RBOS.PayrollTableAdapters.PrlEmployeeComboWithAllTableAdapter adapterPrlEmployeeComboWithAll;
        private System.Windows.Forms.Label lbEmployee;
        private System.Windows.Forms.ComboBox comboSalaryPeriod;
        private System.Windows.Forms.Label lbSalaryPeriod;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.CheckBox chkIncludeFunc;
        private System.Windows.Forms.BindingSource bindingPrlSalaryPeriods;
        private RBOS.PayrollTableAdapters.PrlSalaryPeriodsTableAdapter adapterPrlSalaryPeriods;
        private PrlRptSalRegRpt rptSalReg;
    }
}