namespace RBOS
{
    partial class SalesReportFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesReportFrm));
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnPrint = new System.Windows.Forms.Button();
            this.chkShowLitres = new System.Windows.Forms.CheckBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbEndDate = new System.Windows.Forms.Label();
            this.lbShowLitres = new System.Windows.Forms.Label();
            this.lbStartDate = new System.Windows.Forms.Label();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.lbDoNotShow0Lines = new System.Windows.Forms.Label();
            this.chkDoNotShow0Lines = new System.Windows.Forms.CheckBox();
            this.rptSales = new RBOS.SalesReport();
            this.chkIncludeFuel = new System.Windows.Forms.CheckBox();
            this.lbIncludeFuel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtEndDate
            // 
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEndDate.Location = new System.Drawing.Point(138, 38);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(89, 20);
            this.dtEndDate.TabIndex = 0;
            this.dtEndDate.ValueChanged += new System.EventHandler(this.dtEndDate_ValueChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.Location = new System.Drawing.Point(12, 148);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "[Print]";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // chkShowLitres
            // 
            this.chkShowLitres.AutoSize = true;
            this.chkShowLitres.Location = new System.Drawing.Point(138, 74);
            this.chkShowLitres.Name = "chkShowLitres";
            this.chkShowLitres.Size = new System.Drawing.Size(15, 14);
            this.chkShowLitres.TabIndex = 2;
            this.chkShowLitres.UseVisualStyleBackColor = true;
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPreview.Location = new System.Drawing.Point(93, 148);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 3;
            this.btnPreview.Text = "[Preview]";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(174, 148);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbEndDate
            // 
            this.lbEndDate.AutoSize = true;
            this.lbEndDate.Location = new System.Drawing.Point(12, 42);
            this.lbEndDate.Name = "lbEndDate";
            this.lbEndDate.Size = new System.Drawing.Size(88, 13);
            this.lbEndDate.TabIndex = 5;
            this.lbEndDate.Text = "[Select end date]";
            // 
            // lbShowLitres
            // 
            this.lbShowLitres.AutoSize = true;
            this.lbShowLitres.Location = new System.Drawing.Point(12, 74);
            this.lbShowLitres.Name = "lbShowLitres";
            this.lbShowLitres.Size = new System.Drawing.Size(64, 13);
            this.lbShowLitres.TabIndex = 6;
            this.lbShowLitres.Text = "[Show litres]";
            // 
            // lbStartDate
            // 
            this.lbStartDate.AutoSize = true;
            this.lbStartDate.Location = new System.Drawing.Point(12, 16);
            this.lbStartDate.Name = "lbStartDate";
            this.lbStartDate.Size = new System.Drawing.Size(90, 13);
            this.lbStartDate.TabIndex = 8;
            this.lbStartDate.Text = "[Select start date]";
            // 
            // dtStartDate
            // 
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStartDate.Location = new System.Drawing.Point(138, 12);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(89, 20);
            this.dtStartDate.TabIndex = 7;
            this.dtStartDate.ValueChanged += new System.EventHandler(this.dtStartDate_ValueChanged);
            // 
            // lbDoNotShow0Lines
            // 
            this.lbDoNotShow0Lines.AutoSize = true;
            this.lbDoNotShow0Lines.Location = new System.Drawing.Point(12, 94);
            this.lbDoNotShow0Lines.Name = "lbDoNotShow0Lines";
            this.lbDoNotShow0Lines.Size = new System.Drawing.Size(106, 13);
            this.lbDoNotShow0Lines.TabIndex = 10;
            this.lbDoNotShow0Lines.Text = "[Do not show 0-lines]";
            // 
            // chkDoNotShow0Lines
            // 
            this.chkDoNotShow0Lines.AutoSize = true;
            this.chkDoNotShow0Lines.Checked = true;
            this.chkDoNotShow0Lines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDoNotShow0Lines.Location = new System.Drawing.Point(138, 94);
            this.chkDoNotShow0Lines.Name = "chkDoNotShow0Lines";
            this.chkDoNotShow0Lines.Size = new System.Drawing.Size(15, 14);
            this.chkDoNotShow0Lines.TabIndex = 9;
            this.chkDoNotShow0Lines.UseVisualStyleBackColor = true;
            this.chkDoNotShow0Lines.CheckedChanged += new System.EventHandler(this.chkDoNotShow0Lines_CheckedChanged);
            // 
            // chkIncludeFuel
            // 
            this.chkIncludeFuel.AutoSize = true;
            this.chkIncludeFuel.Location = new System.Drawing.Point(138, 115);
            this.chkIncludeFuel.Name = "chkIncludeFuel";
            this.chkIncludeFuel.Size = new System.Drawing.Size(15, 14);
            this.chkIncludeFuel.TabIndex = 11;
            this.chkIncludeFuel.UseVisualStyleBackColor = true;
            this.chkIncludeFuel.CheckedChanged += new System.EventHandler(this.chkIncludeFuel_CheckedChanged);
            // 
            // lbIncludeFuel
            // 
            this.lbIncludeFuel.AutoSize = true;
            this.lbIncludeFuel.Location = new System.Drawing.Point(12, 115);
            this.lbIncludeFuel.Name = "lbIncludeFuel";
            this.lbIncludeFuel.Size = new System.Drawing.Size(100, 13);
            this.lbIncludeFuel.TabIndex = 12;
            this.lbIncludeFuel.Text = "[Medtag brændstof]";
            // 
            // SalesReportFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 187);
            this.Controls.Add(this.lbIncludeFuel);
            this.Controls.Add(this.chkIncludeFuel);
            this.Controls.Add(this.lbDoNotShow0Lines);
            this.Controls.Add(this.chkDoNotShow0Lines);
            this.Controls.Add(this.lbStartDate);
            this.Controls.Add(this.dtStartDate);
            this.Controls.Add(this.lbShowLitres);
            this.Controls.Add(this.lbEndDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.chkShowLitres);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dtEndDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SalesReportFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SalesReportFrm";
            this.Load += new System.EventHandler(this.SalesReportFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.CheckBox chkShowLitres;
        private SalesReport rptSales;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbEndDate;
        private System.Windows.Forms.Label lbShowLitres;
        private System.Windows.Forms.Label lbStartDate;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Label lbDoNotShow0Lines;
        private System.Windows.Forms.CheckBox chkDoNotShow0Lines;
        private System.Windows.Forms.CheckBox chkIncludeFuel;
        private System.Windows.Forms.Label lbIncludeFuel;
    }
}