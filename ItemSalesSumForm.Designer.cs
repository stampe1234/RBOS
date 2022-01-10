namespace RBOS
{
    partial class ItemSalesSumForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemSalesSumForm));
            this.dtPostingDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtPostingDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lbPostingDateEnd = new System.Windows.Forms.Label();
            this.lbPostingDateStart = new System.Windows.Forms.Label();
            this.lbSubCategory = new System.Windows.Forms.Label();
            this.btnSubCategory = new System.Windows.Forms.Button();
            this.txtSubCategory = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.dsReport = new RBOS.ReportDataSet();
            this.adapterItemSalesSum = new RBOS.ReportDataSetTableAdapters.ItemSalesSumTableAdapter();
            this.reportItemSalesSum = new RBOS.ItemSalesSumReport();
            this.comboTopBottom = new System.Windows.Forms.ComboBox();
            this.comboNumber = new System.Windows.Forms.ComboBox();
            this.lbChoose = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dsReport)).BeginInit();
            this.SuspendLayout();
            // 
            // dtPostingDateTo
            // 
            this.dtPostingDateTo.Checked = false;
            this.dtPostingDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPostingDateTo.Location = new System.Drawing.Point(137, 64);
            this.dtPostingDateTo.Name = "dtPostingDateTo";
            this.dtPostingDateTo.ShowCheckBox = true;
            this.dtPostingDateTo.Size = new System.Drawing.Size(94, 20);
            this.dtPostingDateTo.TabIndex = 17;
            // 
            // dtPostingDateFrom
            // 
            this.dtPostingDateFrom.Checked = false;
            this.dtPostingDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPostingDateFrom.Location = new System.Drawing.Point(137, 38);
            this.dtPostingDateFrom.Name = "dtPostingDateFrom";
            this.dtPostingDateFrom.ShowCheckBox = true;
            this.dtPostingDateFrom.Size = new System.Drawing.Size(94, 20);
            this.dtPostingDateFrom.TabIndex = 15;
            // 
            // lbPostingDateEnd
            // 
            this.lbPostingDateEnd.AutoSize = true;
            this.lbPostingDateEnd.Location = new System.Drawing.Point(12, 68);
            this.lbPostingDateEnd.Name = "lbPostingDateEnd";
            this.lbPostingDateEnd.Size = new System.Drawing.Size(84, 13);
            this.lbPostingDateEnd.TabIndex = 25;
            this.lbPostingDateEnd.Text = "[Posting date to]";
            // 
            // lbPostingDateStart
            // 
            this.lbPostingDateStart.AutoSize = true;
            this.lbPostingDateStart.Location = new System.Drawing.Point(12, 42);
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
            this.btnSubCategory.Image = ((System.Drawing.Image)(resources.GetObject("btnSubCategory.Image")));
            this.btnSubCategory.Location = new System.Drawing.Point(261, 10);
            this.btnSubCategory.Name = "btnSubCategory";
            this.btnSubCategory.Size = new System.Drawing.Size(29, 23);
            this.btnSubCategory.TabIndex = 14;
            this.btnSubCategory.UseVisualStyleBackColor = true;
            this.btnSubCategory.Click += new System.EventHandler(this.btnSubCategory_Click);
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
            this.btnPrint.Location = new System.Drawing.Point(76, 135);
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
            this.btnClose.Location = new System.Drawing.Point(238, 135);
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
            this.btnPreview.Location = new System.Drawing.Point(157, 135);
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
            // adapterItemSalesSum
            // 
            this.adapterItemSalesSum.ClearBeforeFill = true;
            // 
            // comboTopBottom
            // 
            this.comboTopBottom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTopBottom.FormattingEnabled = true;
            this.comboTopBottom.Location = new System.Drawing.Point(137, 90);
            this.comboTopBottom.Name = "comboTopBottom";
            this.comboTopBottom.Size = new System.Drawing.Size(97, 21);
            this.comboTopBottom.TabIndex = 28;
            this.comboTopBottom.SelectedIndexChanged += new System.EventHandler(this.comboTopBottom_SelectedIndexChanged);
            // 
            // comboNumber
            // 
            this.comboNumber.FormattingEnabled = true;
            this.comboNumber.Items.AddRange(new object[] {
            "5",
            "10",
            "25",
            "50",
            "100",
            "250",
            "500",
            "1000"});
            this.comboNumber.Location = new System.Drawing.Point(240, 90);
            this.comboNumber.Name = "comboNumber";
            this.comboNumber.Size = new System.Drawing.Size(72, 21);
            this.comboNumber.TabIndex = 29;
            this.comboNumber.Leave += new System.EventHandler(this.comboNumber_Leave);
            this.comboNumber.TextUpdate += new System.EventHandler(this.comboNumber_TextUpdate);
            // 
            // lbChoose
            // 
            this.lbChoose.AutoSize = true;
            this.lbChoose.Location = new System.Drawing.Point(12, 93);
            this.lbChoose.Name = "lbChoose";
            this.lbChoose.Size = new System.Drawing.Size(38, 13);
            this.lbChoose.TabIndex = 30;
            this.lbChoose.Text = "[Vælg]";
            // 
            // ItemSalesSumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 170);
            this.Controls.Add(this.lbChoose);
            this.Controls.Add(this.comboNumber);
            this.Controls.Add(this.comboTopBottom);
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
            this.Name = "ItemSalesSumForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ItemSalesSumReportForm";
            this.Load += new System.EventHandler(this.ItemSalesSumForm_Load);
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
        private RBOS.ReportDataSetTableAdapters.ItemSalesSumTableAdapter adapterItemSalesSum;
        private ItemSalesSumReport reportItemSalesSum;
        private System.Windows.Forms.ComboBox comboTopBottom;
        private System.Windows.Forms.ComboBox comboNumber;
        private System.Windows.Forms.Label lbChoose;

    }
}