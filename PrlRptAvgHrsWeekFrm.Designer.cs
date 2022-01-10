namespace RBOS
{
    partial class PrlRptAvgHrsWeekFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrlRptAvgHrsWeekFrm));
            this.comboEmployee = new System.Windows.Forms.ComboBox();
            this.bindingEmployee = new System.Windows.Forms.BindingSource(this.components);
            this.dsPayroll = new RBOS.Payroll();
            this.lbEmployee = new System.Windows.Forms.Label();
            this.adapterEmployee = new RBOS.PayrollTableAdapters.PrlEmployeeComboWithAllTableAdapter();
            this.lbStartWeek = new System.Windows.Forms.Label();
            this.lbEndWeek = new System.Windows.Forms.Label();
            this.dtEndWeek = new System.Windows.Forms.DateTimePicker();
            this.dtStartWeek = new System.Windows.Forms.DateTimePicker();
            this.lbNumWeeks = new System.Windows.Forms.Label();
            this.txtNumWeeks = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.rptAvgHrsWeek = new RBOS.PrlRptAvgHrsWeekRpt();
            ((System.ComponentModel.ISupportInitialize)(this.bindingEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPayroll)).BeginInit();
            this.SuspendLayout();
            // 
            // comboEmployee
            // 
            this.comboEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboEmployee.DataSource = this.bindingEmployee;
            this.comboEmployee.DisplayMember = "Description";
            this.comboEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEmployee.FormattingEnabled = true;
            this.comboEmployee.Location = new System.Drawing.Point(12, 26);
            this.comboEmployee.Name = "comboEmployee";
            this.comboEmployee.Size = new System.Drawing.Size(294, 21);
            this.comboEmployee.TabIndex = 0;
            this.comboEmployee.ValueMember = "EmployeeNo";
            // 
            // bindingEmployee
            // 
            this.bindingEmployee.DataMember = "PrlEmployeeComboWithAll";
            this.bindingEmployee.DataSource = this.dsPayroll;
            // 
            // dsPayroll
            // 
            this.dsPayroll.DataSetName = "Payroll";
            this.dsPayroll.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lbEmployee
            // 
            this.lbEmployee.AutoSize = true;
            this.lbEmployee.Location = new System.Drawing.Point(12, 9);
            this.lbEmployee.Name = "lbEmployee";
            this.lbEmployee.Size = new System.Drawing.Size(72, 13);
            this.lbEmployee.TabIndex = 1;
            this.lbEmployee.Text = "[Medarbejder]";
            // 
            // adapterEmployee
            // 
            this.adapterEmployee.ClearBeforeFill = true;
            // 
            // lbStartWeek
            // 
            this.lbStartWeek.AutoSize = true;
            this.lbStartWeek.Location = new System.Drawing.Point(12, 50);
            this.lbStartWeek.Name = "lbStartWeek";
            this.lbStartWeek.Size = new System.Drawing.Size(49, 13);
            this.lbStartWeek.TabIndex = 2;
            this.lbStartWeek.Text = "[Fra uge]";
            // 
            // lbEndWeek
            // 
            this.lbEndWeek.AutoSize = true;
            this.lbEndWeek.Location = new System.Drawing.Point(105, 50);
            this.lbEndWeek.Name = "lbEndWeek";
            this.lbEndWeek.Size = new System.Drawing.Size(45, 13);
            this.lbEndWeek.TabIndex = 3;
            this.lbEndWeek.Text = "[Til uge]";
            // 
            // dtEndWeek
            // 
            this.dtEndWeek.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEndWeek.Location = new System.Drawing.Point(105, 66);
            this.dtEndWeek.Name = "dtEndWeek";
            this.dtEndWeek.Size = new System.Drawing.Size(87, 20);
            this.dtEndWeek.TabIndex = 4;
            this.dtEndWeek.ValueChanged += new System.EventHandler(this.dtEndWeek_ValueChanged);
            // 
            // dtStartWeek
            // 
            this.dtStartWeek.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStartWeek.Location = new System.Drawing.Point(12, 66);
            this.dtStartWeek.Name = "dtStartWeek";
            this.dtStartWeek.Size = new System.Drawing.Size(87, 20);
            this.dtStartWeek.TabIndex = 5;
            this.dtStartWeek.ValueChanged += new System.EventHandler(this.dtStartWeek_ValueChanged);
            // 
            // lbNumWeeks
            // 
            this.lbNumWeeks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNumWeeks.AutoSize = true;
            this.lbNumWeeks.Location = new System.Drawing.Point(206, 69);
            this.lbNumWeeks.Name = "lbNumWeeks";
            this.lbNumWeeks.Size = new System.Drawing.Size(61, 13);
            this.lbNumWeeks.TabIndex = 6;
            this.lbNumWeeks.Text = "[Antal uger]";
            // 
            // txtNumWeeks
            // 
            this.txtNumWeeks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumWeeks.Location = new System.Drawing.Point(273, 66);
            this.txtNumWeeks.Name = "txtNumWeeks";
            this.txtNumWeeks.ReadOnly = true;
            this.txtNumWeeks.Size = new System.Drawing.Size(33, 20);
            this.txtNumWeeks.TabIndex = 7;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(69, 103);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "[Print]";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(150, 103);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 9;
            this.btnPreview.Text = "[Preview]";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(231, 103);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // PrlRptAvgHrsWeekFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 138);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtNumWeeks);
            this.Controls.Add(this.lbNumWeeks);
            this.Controls.Add(this.dtStartWeek);
            this.Controls.Add(this.dtEndWeek);
            this.Controls.Add(this.lbEndWeek);
            this.Controls.Add(this.lbStartWeek);
            this.Controls.Add(this.lbEmployee);
            this.Controls.Add(this.comboEmployee);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PrlRptAvgHrsWeekFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Gennemsnitlig timer pr. uge]";
            this.Load += new System.EventHandler(this.PrlRptAvgHrsWeekFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPayroll)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboEmployee;
        private System.Windows.Forms.Label lbEmployee;
        private Payroll dsPayroll;
        private System.Windows.Forms.BindingSource bindingEmployee;
        private RBOS.PayrollTableAdapters.PrlEmployeeComboWithAllTableAdapter adapterEmployee;
        private System.Windows.Forms.Label lbStartWeek;
        private System.Windows.Forms.Label lbEndWeek;
        private System.Windows.Forms.DateTimePicker dtEndWeek;
        private System.Windows.Forms.DateTimePicker dtStartWeek;
        private System.Windows.Forms.Label lbNumWeeks;
        private System.Windows.Forms.TextBox txtNumWeeks;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnClose;
        private PrlRptAvgHrsWeekRpt rptAvgHrsWeek;
    }
}