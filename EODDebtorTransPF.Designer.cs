namespace RBOS
{
    partial class EODDebtorTransPF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EODDebtorTransPF));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lbDebtor = new System.Windows.Forms.Label();
            this.lbFromDate = new System.Windows.Forms.Label();
            this.lbToDate = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.txtDebtor = new System.Windows.Forms.TextBox();
            this.btnDebtor = new System.Windows.Forms.Button();
            this.rptEODDebtorTrans = new RBOS.EODDebtorTransRpt();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(173, 100);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(92, 100);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 1;
            this.btnPreview.Text = "[Preview]";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(11, 100);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "[Print]";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lbDebtor
            // 
            this.lbDebtor.AutoSize = true;
            this.lbDebtor.Location = new System.Drawing.Point(12, 15);
            this.lbDebtor.Name = "lbDebtor";
            this.lbDebtor.Size = new System.Drawing.Size(45, 13);
            this.lbDebtor.TabIndex = 4;
            this.lbDebtor.Text = "[Debtor]";
            // 
            // lbFromDate
            // 
            this.lbFromDate.AutoSize = true;
            this.lbFromDate.Location = new System.Drawing.Point(12, 42);
            this.lbFromDate.Name = "lbFromDate";
            this.lbFromDate.Size = new System.Drawing.Size(60, 13);
            this.lbFromDate.TabIndex = 5;
            this.lbFromDate.Text = "[From date]";
            // 
            // lbToDate
            // 
            this.lbToDate.AutoSize = true;
            this.lbToDate.Location = new System.Drawing.Point(12, 68);
            this.lbToDate.Name = "lbToDate";
            this.lbToDate.Size = new System.Drawing.Size(50, 13);
            this.lbToDate.TabIndex = 6;
            this.lbToDate.Text = "[To date]";
            // 
            // dtFromDate
            // 
            this.dtFromDate.Checked = false;
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFromDate.Location = new System.Drawing.Point(98, 38);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.ShowCheckBox = true;
            this.dtFromDate.Size = new System.Drawing.Size(100, 20);
            this.dtFromDate.TabIndex = 7;
            this.dtFromDate.ValueChanged += new System.EventHandler(this.dtFromDate_ValueChanged);
            // 
            // dtToDate
            // 
            this.dtToDate.Checked = false;
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToDate.Location = new System.Drawing.Point(98, 64);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.ShowCheckBox = true;
            this.dtToDate.Size = new System.Drawing.Size(100, 20);
            this.dtToDate.TabIndex = 8;
            this.dtToDate.ValueChanged += new System.EventHandler(this.dtToDate_ValueChanged);
            // 
            // txtDebtor
            // 
            this.txtDebtor.Location = new System.Drawing.Point(98, 12);
            this.txtDebtor.Name = "txtDebtor";
            this.txtDebtor.ReadOnly = true;
            this.txtDebtor.Size = new System.Drawing.Size(100, 20);
            this.txtDebtor.TabIndex = 10;
            // 
            // btnDebtor
            // 
            this.btnDebtor.Image = ((System.Drawing.Image)(resources.GetObject("btnDebtor.Image")));
            this.btnDebtor.Location = new System.Drawing.Point(204, 10);
            this.btnDebtor.Name = "btnDebtor";
            this.btnDebtor.Size = new System.Drawing.Size(27, 23);
            this.btnDebtor.TabIndex = 11;
            this.btnDebtor.UseVisualStyleBackColor = true;
            this.btnDebtor.Click += new System.EventHandler(this.btnDebtor_Click);
            // 
            // EODDebtorTransPF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(260, 135);
            this.Controls.Add(this.btnDebtor);
            this.Controls.Add(this.txtDebtor);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.lbToDate);
            this.Controls.Add(this.lbFromDate);
            this.Controls.Add(this.lbDebtor);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EODDebtorTransPF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EODDebtorTransPF";
            this.Load += new System.EventHandler(this.EODDebtorTransPF_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lbDebtor;
        private System.Windows.Forms.Label lbFromDate;
        private System.Windows.Forms.Label lbToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.TextBox txtDebtor;
        private System.Windows.Forms.Button btnDebtor;
        private EODDebtorTransRpt rptEODDebtorTrans;
    }
}