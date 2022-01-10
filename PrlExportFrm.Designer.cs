namespace RBOS
{
    partial class PrlExportFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrlExportFrm));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lbSalaryPeriod = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dsPayroll = new RBOS.Payroll();
            this.bindingSalaryPeriods = new System.Windows.Forms.BindingSource(this.components);
            this.adapterSalaryPeriods = new RBOS.PayrollTableAdapters.PrlSalaryPeriodsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsPayroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSalaryPeriods)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DataSource = this.bindingSalaryPeriods;
            this.comboBox1.DisplayMember = "PeriodString";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(281, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // lbSalaryPeriod
            // 
            this.lbSalaryPeriod.AutoSize = true;
            this.lbSalaryPeriod.Location = new System.Drawing.Point(12, 9);
            this.lbSalaryPeriod.Name = "lbSalaryPeriod";
            this.lbSalaryPeriod.Size = new System.Drawing.Size(75, 13);
            this.lbSalaryPeriod.TabIndex = 1;
            this.lbSalaryPeriod.Text = "[Salary Period]";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(137, 60);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "[Start]";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(218, 60);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dsPayroll
            // 
            this.dsPayroll.DataSetName = "Payroll";
            this.dsPayroll.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingSalaryPeriods
            // 
            this.bindingSalaryPeriods.DataMember = "PrlSalaryPeriods";
            this.bindingSalaryPeriods.DataSource = this.dsPayroll;
            // 
            // adapterSalaryPeriods
            // 
            this.adapterSalaryPeriods.ClearBeforeFill = true;
            // 
            // PrlExportFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 95);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lbSalaryPeriod);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PrlExportFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrlExportFrm";
            this.Load += new System.EventHandler(this.PrlExportFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsPayroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSalaryPeriods)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lbSalaryPeriod;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnClose;
        private Payroll dsPayroll;
        private System.Windows.Forms.BindingSource bindingSalaryPeriods;
        private RBOS.PayrollTableAdapters.PrlSalaryPeriodsTableAdapter adapterSalaryPeriods;
    }
}