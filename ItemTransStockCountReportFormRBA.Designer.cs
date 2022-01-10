namespace RBOS
{
    partial class ItemTransStockCountReportFormRBA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemTransStockCountReportFormRBA));
            this.ddUltimoMonth = new System.Windows.Forms.ComboBox();
            this.ddUltimoYear = new System.Windows.Forms.ComboBox();
            this.lbUltimoDate = new System.Windows.Forms.Label();
            this.chkVisVaredetaljer = new System.Windows.Forms.CheckBox();
            this.lbVisVaredetaljer = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.chkCreateOPTfile = new System.Windows.Forms.CheckBox();
            this.lbCreateOPTfile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ddUltimoMonth
            // 
            this.ddUltimoMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddUltimoMonth.FormattingEnabled = true;
            this.ddUltimoMonth.Location = new System.Drawing.Point(176, 12);
            this.ddUltimoMonth.Name = "ddUltimoMonth";
            this.ddUltimoMonth.Size = new System.Drawing.Size(56, 21);
            this.ddUltimoMonth.TabIndex = 8;
            // 
            // ddUltimoYear
            // 
            this.ddUltimoYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddUltimoYear.FormattingEnabled = true;
            this.ddUltimoYear.Location = new System.Drawing.Point(86, 12);
            this.ddUltimoYear.Name = "ddUltimoYear";
            this.ddUltimoYear.Size = new System.Drawing.Size(84, 21);
            this.ddUltimoYear.TabIndex = 7;
            // 
            // lbUltimoDate
            // 
            this.lbUltimoDate.AutoSize = true;
            this.lbUltimoDate.Location = new System.Drawing.Point(17, 15);
            this.lbUltimoDate.Name = "lbUltimoDate";
            this.lbUltimoDate.Size = new System.Drawing.Size(63, 13);
            this.lbUltimoDate.TabIndex = 6;
            this.lbUltimoDate.Text = "[Ultimodato]";
            this.lbUltimoDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkVisVaredetaljer
            // 
            this.chkVisVaredetaljer.AutoSize = true;
            this.chkVisVaredetaljer.Checked = true;
            this.chkVisVaredetaljer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVisVaredetaljer.Location = new System.Drawing.Point(155, 52);
            this.chkVisVaredetaljer.Name = "chkVisVaredetaljer";
            this.chkVisVaredetaljer.Size = new System.Drawing.Size(15, 14);
            this.chkVisVaredetaljer.TabIndex = 9;
            this.chkVisVaredetaljer.UseVisualStyleBackColor = true;
            // 
            // lbVisVaredetaljer
            // 
            this.lbVisVaredetaljer.AutoSize = true;
            this.lbVisVaredetaljer.Location = new System.Drawing.Point(17, 52);
            this.lbVisVaredetaljer.Name = "lbVisVaredetaljer";
            this.lbVisVaredetaljer.Size = new System.Drawing.Size(85, 13);
            this.lbVisVaredetaljer.TabIndex = 10;
            this.lbVisVaredetaljer.Text = "[Vis varedetaljer]";
            this.lbVisVaredetaljer.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(14, 110);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 29;
            this.btnPrint.Text = "[Print]";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(176, 110);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 31;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(95, 110);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 30;
            this.btnPreview.Text = "[Preview]";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // chkCreateOPTfile
            // 
            this.chkCreateOPTfile.AutoSize = true;
            this.chkCreateOPTfile.Location = new System.Drawing.Point(155, 72);
            this.chkCreateOPTfile.Name = "chkCreateOPTfile";
            this.chkCreateOPTfile.Size = new System.Drawing.Size(15, 14);
            this.chkCreateOPTfile.TabIndex = 9;
            this.chkCreateOPTfile.UseVisualStyleBackColor = true;
            // 
            // lbCreateOPTfile
            // 
            this.lbCreateOPTfile.AutoSize = true;
            this.lbCreateOPTfile.Location = new System.Drawing.Point(17, 72);
            this.lbCreateOPTfile.Name = "lbCreateOPTfile";
            this.lbCreateOPTfile.Size = new System.Drawing.Size(100, 13);
            this.lbCreateOPTfile.TabIndex = 10;
            this.lbCreateOPTfile.Text = "[Dan fil til regnskab]";
            this.lbCreateOPTfile.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ItemTransStockCountReportFormRBA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 145);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.lbCreateOPTfile);
            this.Controls.Add(this.lbVisVaredetaljer);
            this.Controls.Add(this.chkCreateOPTfile);
            this.Controls.Add(this.chkVisVaredetaljer);
            this.Controls.Add(this.ddUltimoMonth);
            this.Controls.Add(this.ddUltimoYear);
            this.Controls.Add(this.lbUltimoDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ItemTransStockCountReportFormRBA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StockCountRegistrationRBARpt";
            this.Load += new System.EventHandler(this.StockCountRegistrationRBARpt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddUltimoMonth;
        private System.Windows.Forms.ComboBox ddUltimoYear;
        private System.Windows.Forms.Label lbUltimoDate;
        private System.Windows.Forms.CheckBox chkVisVaredetaljer;
        private System.Windows.Forms.Label lbVisVaredetaljer;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.CheckBox chkCreateOPTfile;
        private System.Windows.Forms.Label lbCreateOPTfile;
    }
}