namespace RBOS
{
    partial class PrlRptSalaryEmpFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrlRptSalaryEmpFrm));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lbEmployee = new System.Windows.Forms.Label();
            this.comboEmployee = new System.Windows.Forms.ComboBox();
            this.bindingEmployeeComboWithAll = new System.Windows.Forms.BindingSource(this.components);
            this.dsPayroll = new RBOS.Payroll();
            this.lbSalaryPeriod = new System.Windows.Forms.Label();
            this.comboSalaryPeriods = new System.Windows.Forms.ComboBox();
            this.bindingSalaryPeriods = new System.Windows.Forms.BindingSource(this.components);
            this.adapterSalaryPeriods = new RBOS.PayrollTableAdapters.PrlSalaryPeriodsTableAdapter();
            this.adapterEmployeeComboWithAll = new RBOS.PayrollTableAdapters.PrlEmployeeComboWithAllTableAdapter();
            this.rptPrlSalaryEmp = new RBOS.PrlRptSalaryEmp();
            this.chkPageBreakPerEmp = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingEmployeeComboWithAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPayroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSalaryPeriods)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(225, 122);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(144, 122);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 12;
            this.btnPreview.Text = "[Preview]";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(63, 122);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "[Print]";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lbEmployee
            // 
            this.lbEmployee.AutoSize = true;
            this.lbEmployee.Location = new System.Drawing.Point(12, 50);
            this.lbEmployee.Name = "lbEmployee";
            this.lbEmployee.Size = new System.Drawing.Size(72, 13);
            this.lbEmployee.TabIndex = 9;
            this.lbEmployee.Text = "[Medarbejder]";
            // 
            // comboEmployee
            // 
            this.comboEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboEmployee.DataSource = this.bindingEmployeeComboWithAll;
            this.comboEmployee.DisplayMember = "Description";
            this.comboEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEmployee.FormattingEnabled = true;
            this.comboEmployee.Location = new System.Drawing.Point(12, 67);
            this.comboEmployee.Name = "comboEmployee";
            this.comboEmployee.Size = new System.Drawing.Size(287, 21);
            this.comboEmployee.TabIndex = 7;
            // 
            // bindingEmployeeComboWithAll
            // 
            this.bindingEmployeeComboWithAll.DataMember = "PrlEmployeeComboWithAll";
            this.bindingEmployeeComboWithAll.DataSource = this.dsPayroll;
            // 
            // dsPayroll
            // 
            this.dsPayroll.DataSetName = "Payroll";
            this.dsPayroll.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lbSalaryPeriod
            // 
            this.lbSalaryPeriod.AutoSize = true;
            this.lbSalaryPeriod.Location = new System.Drawing.Point(12, 9);
            this.lbSalaryPeriod.Name = "lbSalaryPeriod";
            this.lbSalaryPeriod.Size = new System.Drawing.Size(66, 13);
            this.lbSalaryPeriod.TabIndex = 15;
            this.lbSalaryPeriod.Text = "[Lønperiode]";
            // 
            // comboSalaryPeriods
            // 
            this.comboSalaryPeriods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboSalaryPeriods.DataSource = this.bindingSalaryPeriods;
            this.comboSalaryPeriods.DisplayMember = "PeriodString";
            this.comboSalaryPeriods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSalaryPeriods.FormattingEnabled = true;
            this.comboSalaryPeriods.Location = new System.Drawing.Point(12, 26);
            this.comboSalaryPeriods.Name = "comboSalaryPeriods";
            this.comboSalaryPeriods.Size = new System.Drawing.Size(287, 21);
            this.comboSalaryPeriods.TabIndex = 14;
            this.comboSalaryPeriods.SelectedIndexChanged += new System.EventHandler(this.comboSalaryPeriods_SelectedIndexChanged);
            // 
            // bindingSalaryPeriods
            // 
            this.bindingSalaryPeriods.DataMember = "PrlSalaryPeriods";
            this.bindingSalaryPeriods.DataSource = this.dsPayroll;
            this.bindingSalaryPeriods.PositionChanged += new System.EventHandler(this.bindingSalaryPeriods_PositionChanged);
            // 
            // adapterSalaryPeriods
            // 
            this.adapterSalaryPeriods.ClearBeforeFill = true;
            // 
            // adapterEmployeeComboWithAll
            // 
            this.adapterEmployeeComboWithAll.ClearBeforeFill = true;
            // 
            // chkPageBreakPerEmp
            // 
            this.chkPageBreakPerEmp.AutoSize = true;
            this.chkPageBreakPerEmp.Location = new System.Drawing.Point(15, 94);
            this.chkPageBreakPerEmp.Name = "chkPageBreakPerEmp";
            this.chkPageBreakPerEmp.Size = new System.Drawing.Size(151, 17);
            this.chkPageBreakPerEmp.TabIndex = 16;
            this.chkPageBreakPerEmp.Text = "[Skift side pr. medarbejder]";
            this.chkPageBreakPerEmp.UseVisualStyleBackColor = true;
            this.chkPageBreakPerEmp.CheckedChanged += new System.EventHandler(this.chkPageBreakPerEmp_CheckedChanged);
            // 
            // PrlRptSalaryEmpFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 157);
            this.Controls.Add(this.chkPageBreakPerEmp);
            this.Controls.Add(this.lbSalaryPeriod);
            this.Controls.Add(this.comboSalaryPeriods);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lbEmployee);
            this.Controls.Add(this.comboEmployee);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PrlRptSalaryEmpFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Løndata pr. medarbejder]";
            this.Load += new System.EventHandler(this.PrlRptSalaryEmpFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingEmployeeComboWithAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPayroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSalaryPeriods)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lbEmployee;
        private System.Windows.Forms.ComboBox comboEmployee;
        private System.Windows.Forms.Label lbSalaryPeriod;
        private System.Windows.Forms.ComboBox comboSalaryPeriods;
        private Payroll dsPayroll;
        private System.Windows.Forms.BindingSource bindingSalaryPeriods;
        private RBOS.PayrollTableAdapters.PrlSalaryPeriodsTableAdapter adapterSalaryPeriods;
        private System.Windows.Forms.BindingSource bindingEmployeeComboWithAll;
        private RBOS.PayrollTableAdapters.PrlEmployeeComboWithAllTableAdapter adapterEmployeeComboWithAll;
        private PrlRptSalaryEmp rptPrlSalaryEmp;
        private System.Windows.Forms.CheckBox chkPageBreakPerEmp;
    }
}