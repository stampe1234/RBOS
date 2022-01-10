namespace RBOS
{
    partial class DisktilbudSolgtRptFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisktilbudSolgtRptFrm));
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.lbFromToDates = new System.Windows.Forms.Label();
            this.lbDetails = new System.Windows.Forms.Label();
            this.chkDetails = new System.Windows.Forms.CheckBox();
            this.lbItemDetails = new System.Windows.Forms.Label();
            this.chkItemDetails = new System.Windows.Forms.CheckBox();
            this.comboKampagneID = new System.Windows.Forms.ComboBox();
            this.lbKampagneID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(72, 123);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(153, 123);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 1;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(234, 123);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtFromDate
            // 
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFromDate.Location = new System.Drawing.Point(122, 12);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(90, 20);
            this.dtFromDate.TabIndex = 3;
            this.dtFromDate.ValueChanged += new System.EventHandler(this.dtFromDate_ValueChanged);
            // 
            // dtToDate
            // 
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToDate.Location = new System.Drawing.Point(218, 12);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(90, 20);
            this.dtToDate.TabIndex = 4;
            this.dtToDate.ValueChanged += new System.EventHandler(this.dtToDate_ValueChanged);
            // 
            // lbFromToDates
            // 
            this.lbFromToDates.AutoSize = true;
            this.lbFromToDates.Location = new System.Drawing.Point(12, 16);
            this.lbFromToDates.Name = "lbFromToDates";
            this.lbFromToDates.Size = new System.Drawing.Size(76, 13);
            this.lbFromToDates.TabIndex = 5;
            this.lbFromToDates.Text = "[Fra/ til datoer]";
            // 
            // lbDetails
            // 
            this.lbDetails.AutoSize = true;
            this.lbDetails.Location = new System.Drawing.Point(12, 71);
            this.lbDetails.Name = "lbDetails";
            this.lbDetails.Size = new System.Drawing.Size(49, 13);
            this.lbDetails.TabIndex = 6;
            this.lbDetails.Text = "[Detaljer]";
            // 
            // chkDetails
            // 
            this.chkDetails.AutoSize = true;
            this.chkDetails.Location = new System.Drawing.Point(153, 72);
            this.chkDetails.Name = "chkDetails";
            this.chkDetails.Size = new System.Drawing.Size(15, 14);
            this.chkDetails.TabIndex = 7;
            this.chkDetails.UseVisualStyleBackColor = true;
            this.chkDetails.CheckedChanged += new System.EventHandler(this.chkDetails_CheckedChanged);
            // 
            // lbItemDetails
            // 
            this.lbItemDetails.AutoSize = true;
            this.lbItemDetails.Location = new System.Drawing.Point(12, 91);
            this.lbItemDetails.Name = "lbItemDetails";
            this.lbItemDetails.Size = new System.Drawing.Size(69, 13);
            this.lbItemDetails.TabIndex = 6;
            this.lbItemDetails.Text = "[Varedetaljer]";
            // 
            // chkItemDetails
            // 
            this.chkItemDetails.AutoSize = true;
            this.chkItemDetails.Enabled = false;
            this.chkItemDetails.Location = new System.Drawing.Point(153, 91);
            this.chkItemDetails.Name = "chkItemDetails";
            this.chkItemDetails.Size = new System.Drawing.Size(15, 14);
            this.chkItemDetails.TabIndex = 7;
            this.chkItemDetails.UseVisualStyleBackColor = true;
            // 
            // comboKampagneID
            // 
            this.comboKampagneID.FormattingEnabled = true;
            this.comboKampagneID.Location = new System.Drawing.Point(122, 38);
            this.comboKampagneID.Name = "comboKampagneID";
            this.comboKampagneID.Size = new System.Drawing.Size(90, 21);
            this.comboKampagneID.TabIndex = 8;
            // 
            // lbKampagneID
            // 
            this.lbKampagneID.AutoSize = true;
            this.lbKampagneID.Location = new System.Drawing.Point(12, 41);
            this.lbKampagneID.Name = "lbKampagneID";
            this.lbKampagneID.Size = new System.Drawing.Size(78, 13);
            this.lbKampagneID.TabIndex = 9;
            this.lbKampagneID.Text = "[Kampagne ID]";
            // 
            // DisktilbudSolgtRptFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 158);
            this.Controls.Add(this.lbKampagneID);
            this.Controls.Add(this.comboKampagneID);
            this.Controls.Add(this.chkItemDetails);
            this.Controls.Add(this.chkDetails);
            this.Controls.Add(this.lbItemDetails);
            this.Controls.Add(this.lbDetails);
            this.Controls.Add(this.lbFromToDates);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DisktilbudSolgtRptFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DisktilbudSolgtRptFrm";
            this.Load += new System.EventHandler(this.DisktilbudSolgtRptFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label lbFromToDates;
        private System.Windows.Forms.Label lbDetails;
        private System.Windows.Forms.CheckBox chkDetails;
        private System.Windows.Forms.Label lbItemDetails;
        private System.Windows.Forms.CheckBox chkItemDetails;
        private System.Windows.Forms.ComboBox comboKampagneID;
        private System.Windows.Forms.Label lbKampagneID;
    }
}