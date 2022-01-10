namespace RBOS
{
    partial class PrlRptSalarySumFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrlRptSalarySumFrm));
            this.lbSalaryPeriod = new System.Windows.Forms.Label();
            this.comboSalaryPeriods = new System.Windows.Forms.ComboBox();
            this.bindingSalaryPeriods = new System.Windows.Forms.BindingSource(this.components);
            this.dsPayroll = new RBOS.Payroll();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.adapterSalaryPeriods = new RBOS.PayrollTableAdapters.PrlSalaryPeriodsTableAdapter();
            this.chkIncludeAbsense = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSalaryPeriods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPayroll)).BeginInit();
            this.SuspendLayout();
            // 
            // lbSalaryPeriod
            // 
            this.lbSalaryPeriod.AutoSize = true;
            this.lbSalaryPeriod.Location = new System.Drawing.Point(12, 9);
            this.lbSalaryPeriod.Name = "lbSalaryPeriod";
            this.lbSalaryPeriod.Size = new System.Drawing.Size(66, 13);
            this.lbSalaryPeriod.TabIndex = 20;
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
            this.comboSalaryPeriods.Size = new System.Drawing.Size(292, 21);
            this.comboSalaryPeriods.TabIndex = 19;
            // 
            // bindingSalaryPeriods
            // 
            this.bindingSalaryPeriods.DataMember = "PrlSalaryPeriods";
            this.bindingSalaryPeriods.DataSource = this.dsPayroll;
            // 
            // dsPayroll
            // 
            this.dsPayroll.DataSetName = "Payroll";
            this.dsPayroll.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(229, 90);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(148, 90);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 17;
            this.btnPreview.Text = "[Preview]";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(67, 90);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 16;
            this.btnPrint.Text = "[Print]";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // adapterSalaryPeriods
            // 
            this.adapterSalaryPeriods.ClearBeforeFill = true;
            // 
            // chkIncludeAbsense
            // 
            this.chkIncludeAbsense.AutoSize = true;
            this.chkIncludeAbsense.Location = new System.Drawing.Point(15, 53);
            this.chkIncludeAbsense.Name = "chkIncludeAbsense";
            this.chkIncludeAbsense.Size = new System.Drawing.Size(190, 17);
            this.chkIncludeAbsense.TabIndex = 21;
            this.chkIncludeAbsense.Text = "[Inkludér fravær alle medarbejdere]";
            this.chkIncludeAbsense.UseVisualStyleBackColor = true;
            // 
            // PrlRptSalarySumFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 125);
            this.Controls.Add(this.chkIncludeAbsense);
            this.Controls.Add(this.lbSalaryPeriod);
            this.Controls.Add(this.comboSalaryPeriods);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PrlRptSalarySumFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Løndata alle medarbejdere]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrlRptSalarySumFrm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSalaryPeriods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPayroll)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbSalaryPeriod;
        private System.Windows.Forms.ComboBox comboSalaryPeriods;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnPrint;
        private Payroll dsPayroll;
        private System.Windows.Forms.BindingSource bindingSalaryPeriods;
        private RBOS.PayrollTableAdapters.PrlSalaryPeriodsTableAdapter adapterSalaryPeriods;
        private System.Windows.Forms.CheckBox chkIncludeAbsense;
    }
}