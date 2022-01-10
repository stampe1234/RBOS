namespace RBOS
{
    partial class PrlRptLentOutFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrlRptLentOutFrm));
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbSalaryPeriod = new System.Windows.Forms.Label();
            this.lbFromDate = new System.Windows.Forms.Label();
            this.lbSite = new System.Windows.Forms.Label();
            this.lbToDate = new System.Windows.Forms.Label();
            this.comboSalaryPeriod = new System.Windows.Forms.ComboBox();
            this.bindingSalaryPeriods = new System.Windows.Forms.BindingSource(this.components);
            this.dsPayroll = new RBOS.Payroll();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.comboSite = new System.Windows.Forms.ComboBox();
            this.bindingClusterSites = new System.Windows.Forms.BindingSource(this.components);
            this.adapterSalaryPeriods = new RBOS.PayrollTableAdapters.PrlSalaryPeriodsTableAdapter();
            this.adapterClusterSites = new RBOS.PayrollTableAdapters.PrlClusterSitesComboWithAllTableAdapter();
            this.rptLentOut = new RBOS.PrlRptLentOutRpt();
            this.comboEmployee = new System.Windows.Forms.ComboBox();
            this.lbEmployee = new System.Windows.Forms.Label();
            this.bindingEmployees = new System.Windows.Forms.BindingSource(this.components);
            this.adapterEmployees = new RBOS.PayrollTableAdapters.PrlRptLentOutFrm_EmployeesComboTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSalaryPeriods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPayroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingClusterSites)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(54, 180);
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
            this.btnPreview.Location = new System.Drawing.Point(135, 180);
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
            this.btnClose.Location = new System.Drawing.Point(216, 180);
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
            this.lbSalaryPeriod.Location = new System.Drawing.Point(12, 9);
            this.lbSalaryPeriod.Name = "lbSalaryPeriod";
            this.lbSalaryPeriod.Size = new System.Drawing.Size(66, 13);
            this.lbSalaryPeriod.TabIndex = 3;
            this.lbSalaryPeriod.Text = "[Lønperiode]";
            // 
            // lbFromDate
            // 
            this.lbFromDate.AutoSize = true;
            this.lbFromDate.Location = new System.Drawing.Point(12, 50);
            this.lbFromDate.Name = "lbFromDate";
            this.lbFromDate.Size = new System.Drawing.Size(52, 13);
            this.lbFromDate.TabIndex = 4;
            this.lbFromDate.Text = "[Fra dato]";
            // 
            // lbSite
            // 
            this.lbSite.AutoSize = true;
            this.lbSite.Location = new System.Drawing.Point(12, 89);
            this.lbSite.Name = "lbSite";
            this.lbSite.Size = new System.Drawing.Size(46, 13);
            this.lbSite.TabIndex = 5;
            this.lbSite.Text = "[Station]";
            // 
            // lbToDate
            // 
            this.lbToDate.AutoSize = true;
            this.lbToDate.Location = new System.Drawing.Point(102, 50);
            this.lbToDate.Name = "lbToDate";
            this.lbToDate.Size = new System.Drawing.Size(48, 13);
            this.lbToDate.TabIndex = 6;
            this.lbToDate.Text = "[Til dato]";
            // 
            // comboSalaryPeriod
            // 
            this.comboSalaryPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboSalaryPeriod.DataSource = this.bindingSalaryPeriods;
            this.comboSalaryPeriod.DisplayMember = "PeriodString";
            this.comboSalaryPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSalaryPeriod.FormattingEnabled = true;
            this.comboSalaryPeriod.Location = new System.Drawing.Point(12, 26);
            this.comboSalaryPeriod.Name = "comboSalaryPeriod";
            this.comboSalaryPeriod.Size = new System.Drawing.Size(279, 21);
            this.comboSalaryPeriod.TabIndex = 7;
            // 
            // bindingSalaryPeriods
            // 
            this.bindingSalaryPeriods.DataMember = "PrlSalaryPeriods";
            this.bindingSalaryPeriods.DataSource = this.dsPayroll;
            this.bindingSalaryPeriods.CurrentChanged += new System.EventHandler(this.bindingSalaryPeriods_CurrentChanged);
            // 
            // dsPayroll
            // 
            this.dsPayroll.DataSetName = "Payroll";
            this.dsPayroll.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtFromDate
            // 
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFromDate.Location = new System.Drawing.Point(12, 66);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(84, 20);
            this.dtFromDate.TabIndex = 8;
            this.dtFromDate.ValueChanged += new System.EventHandler(this.dtFromDate_ValueChanged);
            // 
            // dtToDate
            // 
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToDate.Location = new System.Drawing.Point(102, 66);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(84, 20);
            this.dtToDate.TabIndex = 9;
            this.dtToDate.ValueChanged += new System.EventHandler(this.dtToDate_ValueChanged);
            // 
            // comboSite
            // 
            this.comboSite.DataSource = this.bindingClusterSites;
            this.comboSite.DisplayMember = "Description";
            this.comboSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSite.FormattingEnabled = true;
            this.comboSite.Location = new System.Drawing.Point(12, 105);
            this.comboSite.Name = "comboSite";
            this.comboSite.Size = new System.Drawing.Size(174, 21);
            this.comboSite.TabIndex = 10;
            this.comboSite.ValueMember = "SiteCode";
            // 
            // bindingClusterSites
            // 
            this.bindingClusterSites.DataMember = "PrlClusterSitesComboWithAll";
            this.bindingClusterSites.DataSource = this.dsPayroll;
            // 
            // adapterSalaryPeriods
            // 
            this.adapterSalaryPeriods.ClearBeforeFill = true;
            // 
            // adapterClusterSites
            // 
            this.adapterClusterSites.ClearBeforeFill = true;
            // 
            // comboEmployee
            // 
            this.comboEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboEmployee.DataSource = this.bindingEmployees;
            this.comboEmployee.DisplayMember = "Description";
            this.comboEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEmployee.FormattingEnabled = true;
            this.comboEmployee.Location = new System.Drawing.Point(12, 146);
            this.comboEmployee.Name = "comboEmployee";
            this.comboEmployee.Size = new System.Drawing.Size(279, 21);
            this.comboEmployee.TabIndex = 11;
            this.comboEmployee.ValueMember = "EmployeeNo";
            // 
            // lbEmployee
            // 
            this.lbEmployee.AutoSize = true;
            this.lbEmployee.Location = new System.Drawing.Point(12, 129);
            this.lbEmployee.Name = "lbEmployee";
            this.lbEmployee.Size = new System.Drawing.Size(72, 13);
            this.lbEmployee.TabIndex = 12;
            this.lbEmployee.Text = "[Medarbejder]";
            // 
            // bindingEmployees
            // 
            this.bindingEmployees.DataMember = "PrlRptLentOutFrm_EmployeesCombo";
            this.bindingEmployees.DataSource = this.dsPayroll;
            // 
            // adapterEmployees
            // 
            this.adapterEmployees.ClearBeforeFill = true;
            // 
            // PrlRptLentOutFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 215);
            this.Controls.Add(this.lbEmployee);
            this.Controls.Add(this.comboEmployee);
            this.Controls.Add(this.comboSite);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.comboSalaryPeriod);
            this.Controls.Add(this.lbToDate);
            this.Controls.Add(this.lbSite);
            this.Controls.Add(this.lbFromDate);
            this.Controls.Add(this.lbSalaryPeriod);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PrlRptLentOutFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Udlånte medarbejdere]";
            this.Load += new System.EventHandler(this.PrlRptLentOutFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSalaryPeriods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPayroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingClusterSites)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingEmployees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbSalaryPeriod;
        private System.Windows.Forms.Label lbFromDate;
        private System.Windows.Forms.Label lbSite;
        private System.Windows.Forms.Label lbToDate;
        private System.Windows.Forms.ComboBox comboSalaryPeriod;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.ComboBox comboSite;
        private Payroll dsPayroll;
        private System.Windows.Forms.BindingSource bindingSalaryPeriods;
        private RBOS.PayrollTableAdapters.PrlSalaryPeriodsTableAdapter adapterSalaryPeriods;
        private System.Windows.Forms.BindingSource bindingClusterSites;
        private RBOS.PayrollTableAdapters.PrlClusterSitesComboWithAllTableAdapter adapterClusterSites;
        private PrlRptLentOutRpt rptLentOut;
        private System.Windows.Forms.ComboBox comboEmployee;
        private System.Windows.Forms.Label lbEmployee;
        private System.Windows.Forms.BindingSource bindingEmployees;
        private RBOS.PayrollTableAdapters.PrlRptLentOutFrm_EmployeesComboTableAdapter adapterEmployees;
    }
}