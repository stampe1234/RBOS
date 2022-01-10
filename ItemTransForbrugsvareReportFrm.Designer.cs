namespace RBOS
{
    partial class ItemTransForbrugsvareReportFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemTransForbrugsvareReportFrm));
            this.dtPostingDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtPostingDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lbPostingDateEnd = new System.Windows.Forms.Label();
            this.lbPostingDateStart = new System.Windows.Forms.Label();
            this.lbSubCategory = new System.Windows.Forms.Label();
            this.btnSubCategory = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtSubCategory = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.lbItem = new System.Windows.Forms.Label();
            this.btnItem = new System.Windows.Forms.Button();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.ddLevKategori = new System.Windows.Forms.ComboBox();
            this.bindingLevKategori = new System.Windows.Forms.BindingSource(this.components);
            this.dsReport = new RBOS.ReportDataSet();
            this.lbLevKategori = new System.Windows.Forms.Label();
            this.adapterLevKategori = new RBOS.ReportDataSetTableAdapters.LevKategoriRBATableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLevKategori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsReport)).BeginInit();
            this.SuspendLayout();
            // 
            // dtPostingDateTo
            // 
            this.dtPostingDateTo.Checked = false;
            this.dtPostingDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPostingDateTo.Location = new System.Drawing.Point(137, 117);
            this.dtPostingDateTo.Name = "dtPostingDateTo";
            this.dtPostingDateTo.ShowCheckBox = true;
            this.dtPostingDateTo.Size = new System.Drawing.Size(94, 20);
            this.dtPostingDateTo.TabIndex = 17;
            // 
            // dtPostingDateFrom
            // 
            this.dtPostingDateFrom.Checked = false;
            this.dtPostingDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPostingDateFrom.Location = new System.Drawing.Point(137, 91);
            this.dtPostingDateFrom.Name = "dtPostingDateFrom";
            this.dtPostingDateFrom.ShowCheckBox = true;
            this.dtPostingDateFrom.Size = new System.Drawing.Size(94, 20);
            this.dtPostingDateFrom.TabIndex = 15;
            // 
            // lbPostingDateEnd
            // 
            this.lbPostingDateEnd.AutoSize = true;
            this.lbPostingDateEnd.Location = new System.Drawing.Point(12, 121);
            this.lbPostingDateEnd.Name = "lbPostingDateEnd";
            this.lbPostingDateEnd.Size = new System.Drawing.Size(84, 13);
            this.lbPostingDateEnd.TabIndex = 25;
            this.lbPostingDateEnd.Text = "[Posting date to]";
            // 
            // lbPostingDateStart
            // 
            this.lbPostingDateStart.AutoSize = true;
            this.lbPostingDateStart.Location = new System.Drawing.Point(12, 95);
            this.lbPostingDateStart.Name = "lbPostingDateStart";
            this.lbPostingDateStart.Size = new System.Drawing.Size(95, 13);
            this.lbPostingDateStart.TabIndex = 23;
            this.lbPostingDateStart.Text = "[Posting date from]";
            // 
            // lbSubCategory
            // 
            this.lbSubCategory.AutoSize = true;
            this.lbSubCategory.Location = new System.Drawing.Point(12, 15);
            this.lbSubCategory.Name = "lbSubCategory";
            this.lbSubCategory.Size = new System.Drawing.Size(74, 13);
            this.lbSubCategory.TabIndex = 20;
            this.lbSubCategory.Text = "[SubCategory]";
            // 
            // btnSubCategory
            // 
            this.btnSubCategory.ImageIndex = 1;
            this.btnSubCategory.ImageList = this.imageList1;
            this.btnSubCategory.Location = new System.Drawing.Point(261, 10);
            this.btnSubCategory.Name = "btnSubCategory";
            this.btnSubCategory.Size = new System.Drawing.Size(29, 23);
            this.btnSubCategory.TabIndex = 14;
            this.btnSubCategory.UseVisualStyleBackColor = true;
            this.btnSubCategory.Click += new System.EventHandler(this.btnSubCategory_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "search_16.gif");
            this.imageList1.Images.SetKeyName(1, "lookupform2.gif");
            // 
            // txtSubCategory
            // 
            this.txtSubCategory.Location = new System.Drawing.Point(137, 12);
            this.txtSubCategory.Name = "txtSubCategory";
            this.txtSubCategory.ReadOnly = true;
            this.txtSubCategory.Size = new System.Drawing.Size(118, 20);
            this.txtSubCategory.TabIndex = 18;
            this.txtSubCategory.TabStop = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(54, 155);
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
            this.btnClose.Location = new System.Drawing.Point(216, 155);
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
            this.btnPreview.Location = new System.Drawing.Point(135, 155);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 26;
            this.btnPreview.Text = "[Preview]";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // lbItem
            // 
            this.lbItem.AutoSize = true;
            this.lbItem.Location = new System.Drawing.Point(12, 41);
            this.lbItem.Name = "lbItem";
            this.lbItem.Size = new System.Drawing.Size(33, 13);
            this.lbItem.TabIndex = 30;
            this.lbItem.Text = "[Item]";
            // 
            // btnItem
            // 
            this.btnItem.ImageIndex = 0;
            this.btnItem.ImageList = this.imageList1;
            this.btnItem.Location = new System.Drawing.Point(261, 36);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(29, 23);
            this.btnItem.TabIndex = 28;
            this.btnItem.UseVisualStyleBackColor = true;
            this.btnItem.Click += new System.EventHandler(this.btnItem_Click);
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(137, 38);
            this.txtItem.Name = "txtItem";
            this.txtItem.ReadOnly = true;
            this.txtItem.Size = new System.Drawing.Size(118, 20);
            this.txtItem.TabIndex = 29;
            this.txtItem.TabStop = false;
            // 
            // ddLevKategori
            // 
            this.ddLevKategori.DataSource = this.bindingLevKategori;
            this.ddLevKategori.DisplayMember = "LevKategori";
            this.ddLevKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddLevKategori.FormattingEnabled = true;
            this.ddLevKategori.Location = new System.Drawing.Point(137, 64);
            this.ddLevKategori.Name = "ddLevKategori";
            this.ddLevKategori.Size = new System.Drawing.Size(153, 21);
            this.ddLevKategori.TabIndex = 31;
            this.ddLevKategori.ValueMember = "LevKategori";
            // 
            // bindingLevKategori
            // 
            this.bindingLevKategori.DataMember = "LevKategoriRBA";
            this.bindingLevKategori.DataSource = this.dsReport;
            // 
            // dsReport
            // 
            this.dsReport.DataSetName = "ReportDataSet";
            this.dsReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lbLevKategori
            // 
            this.lbLevKategori.AutoSize = true;
            this.lbLevKategori.Location = new System.Drawing.Point(12, 67);
            this.lbLevKategori.Name = "lbLevKategori";
            this.lbLevKategori.Size = new System.Drawing.Size(72, 13);
            this.lbLevKategori.TabIndex = 34;
            this.lbLevKategori.Text = "[Lev.kategori]";
            // 
            // adapterLevKategori
            // 
            this.adapterLevKategori.ClearBeforeFill = true;
            // 
            // ItemTransForbrugsvareReportFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 190);
            this.Controls.Add(this.lbLevKategori);
            this.Controls.Add(this.ddLevKategori);
            this.Controls.Add(this.lbItem);
            this.Controls.Add(this.btnItem);
            this.Controls.Add(this.txtItem);
            this.Controls.Add(this.dtPostingDateTo);
            this.Controls.Add(this.dtPostingDateFrom);
            this.Controls.Add(this.lbPostingDateEnd);
            this.Controls.Add(this.lbPostingDateStart);
            this.Controls.Add(this.lbSubCategory);
            this.Controls.Add(this.btnSubCategory);
            this.Controls.Add(this.txtSubCategory);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ItemTransForbrugsvareReportFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ItemTransForbrugsvareReportFrm";
            this.Load += new System.EventHandler(this.ItemTransForbrugsvareReportFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingLevKategori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReportDataSet dsReport;
        private System.Windows.Forms.DateTimePicker dtPostingDateTo;
        private System.Windows.Forms.DateTimePicker dtPostingDateFrom;
        private System.Windows.Forms.Label lbPostingDateEnd;
        private System.Windows.Forms.Label lbPostingDateStart;
        private System.Windows.Forms.Label lbSubCategory;
        private System.Windows.Forms.Button btnSubCategory;
        private System.Windows.Forms.TextBox txtSubCategory;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lbItem;
        private System.Windows.Forms.Button btnItem;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.ComboBox ddLevKategori;
        private System.Windows.Forms.Label lbLevKategori;
        private System.Windows.Forms.BindingSource bindingLevKategori;
        private RBOS.ReportDataSetTableAdapters.LevKategoriRBATableAdapter adapterLevKategori;

    }
}