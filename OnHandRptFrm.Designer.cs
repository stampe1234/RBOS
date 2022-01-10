namespace RBOS
{
    partial class OnHandRptFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnHandRptFrm));
            this.dtPostingDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtPostingDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lbPostingDateEnd = new System.Windows.Forms.Label();
            this.lbPostingDateStart = new System.Windows.Forms.Label();
            this.lbSubCategoryFrom = new System.Windows.Forms.Label();
            this.btnSubCategoryFrom = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtSubCategoryFrom = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.chkOnlySubCats = new System.Windows.Forms.CheckBox();
            this.lbSubCategoryTo = new System.Windows.Forms.Label();
            this.btnSubCategoryTo = new System.Windows.Forms.Button();
            this.txtSubCategoryTo = new System.Windows.Forms.TextBox();
            this.rptOnHand = new RBOS.OnHandRpt();
            this.chkGenerateAccountingFile = new System.Windows.Forms.CheckBox();
            this.chkSortBySale = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // dtPostingDateTo
            // 
            this.dtPostingDateTo.Checked = false;
            this.dtPostingDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPostingDateTo.Location = new System.Drawing.Point(183, 111);
            this.dtPostingDateTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtPostingDateTo.Name = "dtPostingDateTo";
            this.dtPostingDateTo.Size = new System.Drawing.Size(124, 22);
            this.dtPostingDateTo.TabIndex = 17;
            this.dtPostingDateTo.CloseUp += new System.EventHandler(this.dtPostingDateTo_CloseUp);
            this.dtPostingDateTo.Validated += new System.EventHandler(this.dtPostingDateTo_Validated);
            // 
            // dtPostingDateFrom
            // 
            this.dtPostingDateFrom.Checked = false;
            this.dtPostingDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPostingDateFrom.Location = new System.Drawing.Point(183, 79);
            this.dtPostingDateFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtPostingDateFrom.Name = "dtPostingDateFrom";
            this.dtPostingDateFrom.Size = new System.Drawing.Size(124, 22);
            this.dtPostingDateFrom.TabIndex = 15;
            this.dtPostingDateFrom.CloseUp += new System.EventHandler(this.dtPostingDateFrom_CloseUp);
            this.dtPostingDateFrom.Validated += new System.EventHandler(this.dtPostingDateFrom_Validated);
            // 
            // lbPostingDateEnd
            // 
            this.lbPostingDateEnd.AutoSize = true;
            this.lbPostingDateEnd.Location = new System.Drawing.Point(16, 116);
            this.lbPostingDateEnd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPostingDateEnd.Name = "lbPostingDateEnd";
            this.lbPostingDateEnd.Size = new System.Drawing.Size(111, 17);
            this.lbPostingDateEnd.TabIndex = 25;
            this.lbPostingDateEnd.Text = "[Posting date to]";
            // 
            // lbPostingDateStart
            // 
            this.lbPostingDateStart.AutoSize = true;
            this.lbPostingDateStart.Location = new System.Drawing.Point(16, 84);
            this.lbPostingDateStart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPostingDateStart.Name = "lbPostingDateStart";
            this.lbPostingDateStart.Size = new System.Drawing.Size(127, 17);
            this.lbPostingDateStart.TabIndex = 23;
            this.lbPostingDateStart.Text = "[Posting date from]";
            // 
            // lbSubCategoryFrom
            // 
            this.lbSubCategoryFrom.AutoSize = true;
            this.lbSubCategoryFrom.Location = new System.Drawing.Point(16, 18);
            this.lbSubCategoryFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSubCategoryFrom.Name = "lbSubCategoryFrom";
            this.lbSubCategoryFrom.Size = new System.Drawing.Size(134, 17);
            this.lbSubCategoryFrom.TabIndex = 20;
            this.lbSubCategoryFrom.Text = "[SubCategory From]";
            // 
            // btnSubCategoryFrom
            // 
            this.btnSubCategoryFrom.ImageIndex = 1;
            this.btnSubCategoryFrom.ImageList = this.imageList1;
            this.btnSubCategoryFrom.Location = new System.Drawing.Point(348, 12);
            this.btnSubCategoryFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSubCategoryFrom.Name = "btnSubCategoryFrom";
            this.btnSubCategoryFrom.Size = new System.Drawing.Size(39, 28);
            this.btnSubCategoryFrom.TabIndex = 14;
            this.btnSubCategoryFrom.UseVisualStyleBackColor = true;
            this.btnSubCategoryFrom.Click += new System.EventHandler(this.btnSubCategoryFrom_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "search_16.gif");
            this.imageList1.Images.SetKeyName(1, "lookupform2.gif");
            // 
            // txtSubCategoryFrom
            // 
            this.txtSubCategoryFrom.Location = new System.Drawing.Point(183, 15);
            this.txtSubCategoryFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSubCategoryFrom.Name = "txtSubCategoryFrom";
            this.txtSubCategoryFrom.ReadOnly = true;
            this.txtSubCategoryFrom.Size = new System.Drawing.Size(156, 22);
            this.txtSubCategoryFrom.TabIndex = 18;
            this.txtSubCategoryFrom.TabStop = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(72, 238);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 28);
            this.btnPrint.TabIndex = 24;
            this.btnPrint.Text = "[Print]";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(288, 238);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(180, 238);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(100, 28);
            this.btnPreview.TabIndex = 26;
            this.btnPreview.Text = "[Preview]";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // chkOnlySubCats
            // 
            this.chkOnlySubCats.AutoSize = true;
            this.chkOnlySubCats.Location = new System.Drawing.Point(20, 155);
            this.chkOnlySubCats.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkOnlySubCats.Name = "chkOnlySubCats";
            this.chkOnlySubCats.Size = new System.Drawing.Size(195, 21);
            this.chkOnlySubCats.TabIndex = 31;
            this.chkOnlySubCats.Text = "[Show only subcategories]";
            this.chkOnlySubCats.UseVisualStyleBackColor = true;
            // 
            // lbSubCategoryTo
            // 
            this.lbSubCategoryTo.AutoSize = true;
            this.lbSubCategoryTo.Location = new System.Drawing.Point(16, 50);
            this.lbSubCategoryTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSubCategoryTo.Name = "lbSubCategoryTo";
            this.lbSubCategoryTo.Size = new System.Drawing.Size(134, 17);
            this.lbSubCategoryTo.TabIndex = 34;
            this.lbSubCategoryTo.Text = "[SubCategory From]";
            // 
            // btnSubCategoryTo
            // 
            this.btnSubCategoryTo.ImageIndex = 1;
            this.btnSubCategoryTo.ImageList = this.imageList1;
            this.btnSubCategoryTo.Location = new System.Drawing.Point(348, 44);
            this.btnSubCategoryTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSubCategoryTo.Name = "btnSubCategoryTo";
            this.btnSubCategoryTo.Size = new System.Drawing.Size(39, 28);
            this.btnSubCategoryTo.TabIndex = 32;
            this.btnSubCategoryTo.UseVisualStyleBackColor = true;
            this.btnSubCategoryTo.Click += new System.EventHandler(this.btnSubCategoryTo_Click);
            // 
            // txtSubCategoryTo
            // 
            this.txtSubCategoryTo.Location = new System.Drawing.Point(183, 47);
            this.txtSubCategoryTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSubCategoryTo.Name = "txtSubCategoryTo";
            this.txtSubCategoryTo.ReadOnly = true;
            this.txtSubCategoryTo.Size = new System.Drawing.Size(156, 22);
            this.txtSubCategoryTo.TabIndex = 33;
            this.txtSubCategoryTo.TabStop = false;
            // 
            // chkGenerateAccountingFile
            // 
            this.chkGenerateAccountingFile.AutoSize = true;
            this.chkGenerateAccountingFile.Location = new System.Drawing.Point(20, 183);
            this.chkGenerateAccountingFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkGenerateAccountingFile.Name = "chkGenerateAccountingFile";
            this.chkGenerateAccountingFile.Size = new System.Drawing.Size(209, 21);
            this.chkGenerateAccountingFile.TabIndex = 35;
            this.chkGenerateAccountingFile.Text = "[Generate file to accounting]";
            this.chkGenerateAccountingFile.UseVisualStyleBackColor = true;
            // 
            // chkSortBySale
            // 
            this.chkSortBySale.AutoSize = true;
            this.chkSortBySale.Location = new System.Drawing.Point(20, 211);
            this.chkSortBySale.Name = "chkSortBySale";
            this.chkSortBySale.Size = new System.Drawing.Size(132, 21);
            this.chkSortBySale.TabIndex = 36;
            this.chkSortBySale.Text = "Sorter efter salg";
            this.chkSortBySale.UseVisualStyleBackColor = true;
            // 
            // OnHandRptFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 281);
            this.Controls.Add(this.chkSortBySale);
            this.Controls.Add(this.chkGenerateAccountingFile);
            this.Controls.Add(this.lbSubCategoryTo);
            this.Controls.Add(this.btnSubCategoryTo);
            this.Controls.Add(this.txtSubCategoryTo);
            this.Controls.Add(this.chkOnlySubCats);
            this.Controls.Add(this.dtPostingDateTo);
            this.Controls.Add(this.dtPostingDateFrom);
            this.Controls.Add(this.lbPostingDateEnd);
            this.Controls.Add(this.lbPostingDateStart);
            this.Controls.Add(this.lbSubCategoryFrom);
            this.Controls.Add(this.btnSubCategoryFrom);
            this.Controls.Add(this.txtSubCategoryFrom);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "OnHandRptFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OnHandRptFrm";
            this.Load += new System.EventHandler(this.OnHandRptFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtPostingDateTo;
        private System.Windows.Forms.DateTimePicker dtPostingDateFrom;
        private System.Windows.Forms.Label lbPostingDateEnd;
        private System.Windows.Forms.Label lbPostingDateStart;
        private System.Windows.Forms.Label lbSubCategoryFrom;
        private System.Windows.Forms.Button btnSubCategoryFrom;
        private System.Windows.Forms.TextBox txtSubCategoryFrom;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox chkOnlySubCats;
        private System.Windows.Forms.Label lbSubCategoryTo;
        private System.Windows.Forms.Button btnSubCategoryTo;
        private System.Windows.Forms.TextBox txtSubCategoryTo;
        private OnHandRpt rptOnHand;
        private System.Windows.Forms.CheckBox chkGenerateAccountingFile;
        private System.Windows.Forms.CheckBox chkSortBySale;

    }
}