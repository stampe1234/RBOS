namespace RBOS
{
    partial class BkdInvCountIntvFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BkdInvCountIntvFrm));
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.lbPostingDateEnd = new System.Windows.Forms.Label();
            this.lbPostingDateStart = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.dsReport = new RBOS.ReportDataSet();
            this.report = new RBOS.BkdInvCountIntvRpt();
            this.adapter = new RBOS.ReportDataSetTableAdapters.BkdInvCountIntvTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsReport)).BeginInit();
            this.SuspendLayout();
            // 
            // dtEndDate
            // 
            this.dtEndDate.Checked = false;
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEndDate.Location = new System.Drawing.Point(170, 38);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(94, 20);
            this.dtEndDate.TabIndex = 17;
            // 
            // dtStartDate
            // 
            this.dtStartDate.Checked = false;
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStartDate.Location = new System.Drawing.Point(170, 12);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(94, 20);
            this.dtStartDate.TabIndex = 15;
            // 
            // lbPostingDateEnd
            // 
            this.lbPostingDateEnd.AutoSize = true;
            this.lbPostingDateEnd.Location = new System.Drawing.Point(13, 42);
            this.lbPostingDateEnd.Name = "lbPostingDateEnd";
            this.lbPostingDateEnd.Size = new System.Drawing.Size(84, 13);
            this.lbPostingDateEnd.TabIndex = 25;
            this.lbPostingDateEnd.Text = "[Posting date to]";
            // 
            // lbPostingDateStart
            // 
            this.lbPostingDateStart.AutoSize = true;
            this.lbPostingDateStart.Location = new System.Drawing.Point(13, 16);
            this.lbPostingDateStart.Name = "lbPostingDateStart";
            this.lbPostingDateStart.Size = new System.Drawing.Size(95, 13);
            this.lbPostingDateStart.TabIndex = 23;
            this.lbPostingDateStart.Text = "[Posting date from]";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(75, 80);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 24;
            this.btnPrint.Text = "[Print]";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(237, 80);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(156, 80);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 26;
            this.btnPreview.Text = "[Preview]";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // dsReport
            // 
            this.dsReport.DataSetName = "ReportDataSet";
            this.dsReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // adapter
            // 
            this.adapter.ClearBeforeFill = true;
            // 
            // BkdInvCountIntvFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 115);
            this.Controls.Add(this.dtEndDate);
            this.Controls.Add(this.dtStartDate);
            this.Controls.Add(this.lbPostingDateEnd);
            this.Controls.Add(this.lbPostingDateStart);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BkdInvCountIntvFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BkdInvCountIntvFrm";
            this.Load += new System.EventHandler(this.ItemSalesSumForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReportDataSet dsReport;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Label lbPostingDateEnd;
        private System.Windows.Forms.Label lbPostingDateStart;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPreview;
        private BkdInvCountIntvRpt report;
        private RBOS.ReportDataSetTableAdapters.BkdInvCountIntvTableAdapter adapter;

    }
}