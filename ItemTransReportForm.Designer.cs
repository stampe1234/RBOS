namespace RBOS
{
    partial class ItemTransReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemTransReportForm));
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
            this.comboTransactionType = new System.Windows.Forms.ComboBox();
            this.bindingLookupItemTransactionType = new System.Windows.Forms.BindingSource(this.components);
            this.dsReport = new RBOS.ReportDataSet();
            this.comboPackType = new System.Windows.Forms.ComboBox();
            this.bindingLookupPackSize = new System.Windows.Forms.BindingSource(this.components);
            this.lbPackType = new System.Windows.Forms.Label();
            this.lbTransactionType = new System.Windows.Forms.Label();
            this.adapterLookupItemTransactionType = new RBOS.ReportDataSetTableAdapters.LookupItemTransactionType_WithAllUnionTableAdapter();
            this.adapterLookupPackSize = new RBOS.ReportDataSetTableAdapters.LookupPackSize_WithAllUnionTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupItemTransactionType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupPackSize)).BeginInit();
            this.SuspendLayout();
            // 
            // dtPostingDateTo
            // 
            this.dtPostingDateTo.Checked = false;
            this.dtPostingDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPostingDateTo.Location = new System.Drawing.Point(183, 111);
            this.dtPostingDateTo.Margin = new System.Windows.Forms.Padding(4);
            this.dtPostingDateTo.Name = "dtPostingDateTo";
            this.dtPostingDateTo.ShowCheckBox = true;
            this.dtPostingDateTo.Size = new System.Drawing.Size(124, 22);
            this.dtPostingDateTo.TabIndex = 17;
            // 
            // dtPostingDateFrom
            // 
            this.dtPostingDateFrom.Checked = false;
            this.dtPostingDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPostingDateFrom.Location = new System.Drawing.Point(183, 79);
            this.dtPostingDateFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dtPostingDateFrom.Name = "dtPostingDateFrom";
            this.dtPostingDateFrom.ShowCheckBox = true;
            this.dtPostingDateFrom.Size = new System.Drawing.Size(124, 22);
            this.dtPostingDateFrom.TabIndex = 15;
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
            // lbSubCategory
            // 
            this.lbSubCategory.AutoSize = true;
            this.lbSubCategory.Location = new System.Drawing.Point(16, 18);
            this.lbSubCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSubCategory.Name = "lbSubCategory";
            this.lbSubCategory.Size = new System.Drawing.Size(98, 17);
            this.lbSubCategory.TabIndex = 20;
            this.lbSubCategory.Text = "[SubCategory]";
            // 
            // btnSubCategory
            // 
            this.btnSubCategory.ImageIndex = 1;
            this.btnSubCategory.ImageList = this.imageList1;
            this.btnSubCategory.Location = new System.Drawing.Point(348, 12);
            this.btnSubCategory.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubCategory.Name = "btnSubCategory";
            this.btnSubCategory.Size = new System.Drawing.Size(39, 28);
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
            this.txtSubCategory.Location = new System.Drawing.Point(183, 15);
            this.txtSubCategory.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubCategory.Name = "txtSubCategory";
            this.txtSubCategory.ReadOnly = true;
            this.txtSubCategory.Size = new System.Drawing.Size(156, 22);
            this.txtSubCategory.TabIndex = 18;
            this.txtSubCategory.TabStop = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(72, 238);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
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
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
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
            this.btnPreview.Margin = new System.Windows.Forms.Padding(4);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(100, 28);
            this.btnPreview.TabIndex = 26;
            this.btnPreview.Text = "[Preview]";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // lbItem
            // 
            this.lbItem.AutoSize = true;
            this.lbItem.Location = new System.Drawing.Point(16, 50);
            this.lbItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbItem.Name = "lbItem";
            this.lbItem.Size = new System.Drawing.Size(42, 17);
            this.lbItem.TabIndex = 30;
            this.lbItem.Text = "[Item]";
            // 
            // btnItem
            // 
            this.btnItem.ImageIndex = 0;
            this.btnItem.ImageList = this.imageList1;
            this.btnItem.Location = new System.Drawing.Point(348, 44);
            this.btnItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(39, 28);
            this.btnItem.TabIndex = 28;
            this.btnItem.UseVisualStyleBackColor = true;
            this.btnItem.Click += new System.EventHandler(this.btnItem_Click);
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(183, 47);
            this.txtItem.Margin = new System.Windows.Forms.Padding(4);
            this.txtItem.Name = "txtItem";
            this.txtItem.ReadOnly = true;
            this.txtItem.Size = new System.Drawing.Size(156, 22);
            this.txtItem.TabIndex = 29;
            this.txtItem.TabStop = false;
            // 
            // comboTransactionType
            // 
            this.comboTransactionType.DataSource = this.bindingLookupItemTransactionType;
            this.comboTransactionType.DisplayMember = "Description";
            this.comboTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTransactionType.FormattingEnabled = true;
            this.comboTransactionType.Location = new System.Drawing.Point(183, 143);
            this.comboTransactionType.Margin = new System.Windows.Forms.Padding(4);
            this.comboTransactionType.Name = "comboTransactionType";
            this.comboTransactionType.Size = new System.Drawing.Size(160, 24);
            this.comboTransactionType.TabIndex = 31;
            this.comboTransactionType.ValueMember = "TransactionType";
            // 
            // bindingLookupItemTransactionType
            // 
            this.bindingLookupItemTransactionType.DataMember = "LookupItemTransactionType_WithAllUnion";
            this.bindingLookupItemTransactionType.DataSource = this.dsReport;
            // 
            // dsReport
            // 
            this.dsReport.DataSetName = "ReportDataSet";
            this.dsReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboPackType
            // 
            this.comboPackType.DataSource = this.bindingLookupPackSize;
            this.comboPackType.DisplayMember = "PackTypeName";
            this.comboPackType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPackType.FormattingEnabled = true;
            this.comboPackType.Location = new System.Drawing.Point(183, 176);
            this.comboPackType.Margin = new System.Windows.Forms.Padding(4);
            this.comboPackType.Name = "comboPackType";
            this.comboPackType.Size = new System.Drawing.Size(160, 24);
            this.comboPackType.TabIndex = 32;
            this.comboPackType.ValueMember = "PackType";
            // 
            // bindingLookupPackSize
            // 
            this.bindingLookupPackSize.DataMember = "LookupPackSize_WithAllUnion";
            this.bindingLookupPackSize.DataSource = this.dsReport;
            // 
            // lbPackType
            // 
            this.lbPackType.AutoSize = true;
            this.lbPackType.Location = new System.Drawing.Point(17, 180);
            this.lbPackType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPackType.Name = "lbPackType";
            this.lbPackType.Size = new System.Drawing.Size(122, 17);
            this.lbPackType.TabIndex = 33;
            this.lbPackType.Text = "[Sales Pack Type]";
            // 
            // lbTransactionType
            // 
            this.lbTransactionType.AutoSize = true;
            this.lbTransactionType.Location = new System.Drawing.Point(16, 146);
            this.lbTransactionType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTransactionType.Name = "lbTransactionType";
            this.lbTransactionType.Size = new System.Drawing.Size(127, 17);
            this.lbTransactionType.TabIndex = 34;
            this.lbTransactionType.Text = "[Transaction Type]";
            // 
            // adapterLookupItemTransactionType
            // 
            this.adapterLookupItemTransactionType.ClearBeforeFill = true;
            // 
            // adapterLookupPackSize
            // 
            this.adapterLookupPackSize.ClearBeforeFill = true;
            // 
            // ItemTransReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 281);
            this.Controls.Add(this.lbTransactionType);
            this.Controls.Add(this.lbPackType);
            this.Controls.Add(this.comboPackType);
            this.Controls.Add(this.comboTransactionType);
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ItemTransReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ItemTransReportForm";
            this.Load += new System.EventHandler(this.ItemTransReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupItemTransactionType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupPackSize)).EndInit();
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
        private System.Windows.Forms.ComboBox comboTransactionType;
        private System.Windows.Forms.ComboBox comboPackType;
        private System.Windows.Forms.Label lbPackType;
        private System.Windows.Forms.Label lbTransactionType;
        private System.Windows.Forms.BindingSource bindingLookupItemTransactionType;
        private RBOS.ReportDataSetTableAdapters.LookupItemTransactionType_WithAllUnionTableAdapter adapterLookupItemTransactionType;
        private System.Windows.Forms.BindingSource bindingLookupPackSize;
        private RBOS.ReportDataSetTableAdapters.LookupPackSize_WithAllUnionTableAdapter adapterLookupPackSize;

    }
}