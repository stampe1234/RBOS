namespace RBOS
{
    partial class PrlRptAbsenseFrm
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrlRptAbsenseFrm));
          this.btnPrint = new System.Windows.Forms.Button();
          this.btnPreview = new System.Windows.Forms.Button();
          this.btnClose = new System.Windows.Forms.Button();
          this.comboSalaryPeriodNonFunc = new System.Windows.Forms.ComboBox();
          this.bindingPrlSalaryPeriods = new System.Windows.Forms.BindingSource(this.components);
          this.dsPayroll = new RBOS.Payroll();
          this.lbSalaryPeriodNonFunc = new System.Windows.Forms.Label();
          this.adapterPrlSalaryPeriods = new RBOS.PayrollTableAdapters.PrlSalaryPeriodsTableAdapter();
          this.rptPrlAbsense = new RBOS.PrlRptAbsenseRpt();
          ((System.ComponentModel.ISupportInitialize)(this.bindingPrlSalaryPeriods)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.dsPayroll)).BeginInit();
          this.SuspendLayout();
          // 
          // btnPrint
          // 
          this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
          this.btnPrint.Location = new System.Drawing.Point(56, 68);
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
          this.btnPreview.Location = new System.Drawing.Point(137, 68);
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
          this.btnClose.Location = new System.Drawing.Point(218, 68);
          this.btnClose.Name = "btnClose";
          this.btnClose.Size = new System.Drawing.Size(75, 23);
          this.btnClose.TabIndex = 2;
          this.btnClose.Text = "[Close]";
          this.btnClose.UseVisualStyleBackColor = true;
          this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
          // 
          // comboSalaryPeriodNonFunc
          // 
          this.comboSalaryPeriodNonFunc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.comboSalaryPeriodNonFunc.DataSource = this.bindingPrlSalaryPeriods;
          this.comboSalaryPeriodNonFunc.DisplayMember = "PeriodString";
          this.comboSalaryPeriodNonFunc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.comboSalaryPeriodNonFunc.FormattingEnabled = true;
          this.comboSalaryPeriodNonFunc.Location = new System.Drawing.Point(12, 26);
          this.comboSalaryPeriodNonFunc.Name = "comboSalaryPeriodNonFunc";
          this.comboSalaryPeriodNonFunc.Size = new System.Drawing.Size(281, 21);
          this.comboSalaryPeriodNonFunc.TabIndex = 3;
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
          // lbSalaryPeriodNonFunc
          // 
          this.lbSalaryPeriodNonFunc.AutoSize = true;
          this.lbSalaryPeriodNonFunc.Location = new System.Drawing.Point(12, 9);
          this.lbSalaryPeriodNonFunc.Name = "lbSalaryPeriodNonFunc";
          this.lbSalaryPeriodNonFunc.Size = new System.Drawing.Size(66, 13);
          this.lbSalaryPeriodNonFunc.TabIndex = 4;
          this.lbSalaryPeriodNonFunc.Text = "[Lønperiode]";
          // 
          // adapterPrlSalaryPeriods
          // 
          this.adapterPrlSalaryPeriods.ClearBeforeFill = true;
          // 
          // PrlRptAbsenseFrm
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(305, 103);
          this.Controls.Add(this.lbSalaryPeriodNonFunc);
          this.Controls.Add(this.comboSalaryPeriodNonFunc);
          this.Controls.Add(this.btnClose);
          this.Controls.Add(this.btnPreview);
          this.Controls.Add(this.btnPrint);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.MaximizeBox = false;
          this.Name = "PrlRptAbsenseFrm";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "[Fravær pr. medarbejder]";
          ((System.ComponentModel.ISupportInitialize)(this.bindingPrlSalaryPeriods)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.dsPayroll)).EndInit();
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox comboSalaryPeriodNonFunc;
      private System.Windows.Forms.Label lbSalaryPeriodNonFunc;
        private Payroll dsPayroll;
        private System.Windows.Forms.BindingSource bindingPrlSalaryPeriods;
        private RBOS.PayrollTableAdapters.PrlSalaryPeriodsTableAdapter adapterPrlSalaryPeriods;
        private PrlRptAbsenseRpt rptPrlAbsense;
    }
}