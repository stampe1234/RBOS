namespace RBOS
{
    partial class ReportFormItemBasicData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportFormItemBasicData));
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtSubCategory = new System.Windows.Forms.TextBox();
            this.btnSubCategory = new System.Windows.Forms.Button();
            this.lbSubCategory = new System.Windows.Forms.Label();
            this.lbChangeDateStart = new System.Windows.Forms.Label();
            this.lbChangeDateEnd = new System.Windows.Forms.Label();
            this.dtChangeDateStart = new System.Windows.Forms.DateTimePicker();
            this.dtChangeDateEnd = new System.Windows.Forms.DateTimePicker();
            this.chkShelfLabelUpd = new System.Windows.Forms.CheckBox();
            this.chkPosUpd = new System.Windows.Forms.CheckBox();
            this.lbPosUpd = new System.Windows.Forms.Label();
            this.lbShelfLabelUpd = new System.Windows.Forms.Label();
            this.dtChangedTimeStart = new System.Windows.Forms.DateTimePicker();
            this.dtChangedTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.chkDisktilbud = new System.Windows.Forms.CheckBox();
            this.lbDisktilbud = new System.Windows.Forms.Label();
            this.reportItemBasicData = new RBOS.ReportItemBasicData();
            this.dsReport = new RBOS.ReportDataSet();
            this.adapterItemBasicData = new RBOS.ReportDataSetTableAdapters.ItemBasicDataTableAdapter();
            this.adapterSalesPack = new RBOS.ReportDataSetTableAdapters.SalesPackTableAdapter();
            this.reportItemShelfLabels = new RBOS.ReportItemShelfLabels();
            ((System.ComponentModel.ISupportInitialize)(this.dsReport)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(227, 218);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(100, 28);
            this.btnPreview.TabIndex = 8;
            this.btnPreview.Text = "[Preview]";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(335, 218);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(119, 218);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 28);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "[Print]";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtSubCategory
            // 
            this.txtSubCategory.Location = new System.Drawing.Point(220, 15);
            this.txtSubCategory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSubCategory.Name = "txtSubCategory";
            this.txtSubCategory.ReadOnly = true;
            this.txtSubCategory.Size = new System.Drawing.Size(156, 22);
            this.txtSubCategory.TabIndex = 3;
            this.txtSubCategory.TabStop = false;
            // 
            // btnSubCategory
            // 
            this.btnSubCategory.Image = ((System.Drawing.Image)(resources.GetObject("btnSubCategory.Image")));
            this.btnSubCategory.Location = new System.Drawing.Point(385, 12);
            this.btnSubCategory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSubCategory.Name = "btnSubCategory";
            this.btnSubCategory.Size = new System.Drawing.Size(39, 28);
            this.btnSubCategory.TabIndex = 0;
            this.btnSubCategory.UseVisualStyleBackColor = true;
            this.btnSubCategory.Click += new System.EventHandler(this.btnSubCategory_Click);
            // 
            // lbSubCategory
            // 
            this.lbSubCategory.AutoSize = true;
            this.lbSubCategory.Location = new System.Drawing.Point(16, 18);
            this.lbSubCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSubCategory.Name = "lbSubCategory";
            this.lbSubCategory.Size = new System.Drawing.Size(98, 17);
            this.lbSubCategory.TabIndex = 5;
            this.lbSubCategory.Text = "[SubCategory]";
            // 
            // lbChangeDateStart
            // 
            this.lbChangeDateStart.AutoSize = true;
            this.lbChangeDateStart.Location = new System.Drawing.Point(16, 53);
            this.lbChangeDateStart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbChangeDateStart.Name = "lbChangeDateStart";
            this.lbChangeDateStart.Size = new System.Drawing.Size(187, 17);
            this.lbChangeDateStart.TabIndex = 6;
            this.lbChangeDateStart.Text = "[Changed interval start date]";
            // 
            // lbChangeDateEnd
            // 
            this.lbChangeDateEnd.AutoSize = true;
            this.lbChangeDateEnd.Location = new System.Drawing.Point(16, 85);
            this.lbChangeDateEnd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbChangeDateEnd.Name = "lbChangeDateEnd";
            this.lbChangeDateEnd.Size = new System.Drawing.Size(183, 17);
            this.lbChangeDateEnd.TabIndex = 7;
            this.lbChangeDateEnd.Text = "[Changed interval end date]";
            // 
            // dtChangeDateStart
            // 
            this.dtChangeDateStart.Checked = false;
            this.dtChangeDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtChangeDateStart.Location = new System.Drawing.Point(220, 48);
            this.dtChangeDateStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtChangeDateStart.Name = "dtChangeDateStart";
            this.dtChangeDateStart.ShowCheckBox = true;
            this.dtChangeDateStart.Size = new System.Drawing.Size(124, 22);
            this.dtChangeDateStart.TabIndex = 1;
            this.dtChangeDateStart.ValueChanged += new System.EventHandler(this.dtChangeDateStart_ValueChanged);
            // 
            // dtChangeDateEnd
            // 
            this.dtChangeDateEnd.Checked = false;
            this.dtChangeDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtChangeDateEnd.Location = new System.Drawing.Point(220, 80);
            this.dtChangeDateEnd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtChangeDateEnd.Name = "dtChangeDateEnd";
            this.dtChangeDateEnd.ShowCheckBox = true;
            this.dtChangeDateEnd.Size = new System.Drawing.Size(124, 22);
            this.dtChangeDateEnd.TabIndex = 3;
            this.dtChangeDateEnd.ValueChanged += new System.EventHandler(this.dtChangeDateEnd_ValueChanged);
            // 
            // chkShelfLabelUpd
            // 
            this.chkShelfLabelUpd.AutoSize = true;
            this.chkShelfLabelUpd.Checked = true;
            this.chkShelfLabelUpd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShelfLabelUpd.Location = new System.Drawing.Point(220, 137);
            this.chkShelfLabelUpd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkShelfLabelUpd.Name = "chkShelfLabelUpd";
            this.chkShelfLabelUpd.Size = new System.Drawing.Size(18, 17);
            this.chkShelfLabelUpd.TabIndex = 6;
            this.chkShelfLabelUpd.ThreeState = true;
            this.chkShelfLabelUpd.UseVisualStyleBackColor = true;
            // 
            // chkPosUpd
            // 
            this.chkPosUpd.AutoSize = true;
            this.chkPosUpd.Checked = true;
            this.chkPosUpd.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkPosUpd.Location = new System.Drawing.Point(220, 112);
            this.chkPosUpd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkPosUpd.Name = "chkPosUpd";
            this.chkPosUpd.Size = new System.Drawing.Size(18, 17);
            this.chkPosUpd.TabIndex = 5;
            this.chkPosUpd.ThreeState = true;
            this.chkPosUpd.UseVisualStyleBackColor = true;
            // 
            // lbPosUpd
            // 
            this.lbPosUpd.AutoSize = true;
            this.lbPosUpd.Location = new System.Drawing.Point(16, 112);
            this.lbPosUpd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPosUpd.Name = "lbPosUpd";
            this.lbPosUpd.Size = new System.Drawing.Size(103, 17);
            this.lbPosUpd.TabIndex = 12;
            this.lbPosUpd.Text = "[POS Updated]";
            // 
            // lbShelfLabelUpd
            // 
            this.lbShelfLabelUpd.AutoSize = true;
            this.lbShelfLabelUpd.Location = new System.Drawing.Point(16, 137);
            this.lbShelfLabelUpd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbShelfLabelUpd.Name = "lbShelfLabelUpd";
            this.lbShelfLabelUpd.Size = new System.Drawing.Size(145, 17);
            this.lbShelfLabelUpd.TabIndex = 13;
            this.lbShelfLabelUpd.Text = "[Shelf Label Updated]";
            // 
            // dtChangedTimeStart
            // 
            this.dtChangedTimeStart.CustomFormat = "HH:mm";
            this.dtChangedTimeStart.Enabled = false;
            this.dtChangedTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtChangedTimeStart.Location = new System.Drawing.Point(353, 48);
            this.dtChangedTimeStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtChangedTimeStart.Name = "dtChangedTimeStart";
            this.dtChangedTimeStart.ShowUpDown = true;
            this.dtChangedTimeStart.Size = new System.Drawing.Size(69, 22);
            this.dtChangedTimeStart.TabIndex = 2;
            // 
            // dtChangedTimeEnd
            // 
            this.dtChangedTimeEnd.CustomFormat = "HH:mm";
            this.dtChangedTimeEnd.Enabled = false;
            this.dtChangedTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtChangedTimeEnd.Location = new System.Drawing.Point(353, 80);
            this.dtChangedTimeEnd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtChangedTimeEnd.Name = "dtChangedTimeEnd";
            this.dtChangedTimeEnd.ShowUpDown = true;
            this.dtChangedTimeEnd.Size = new System.Drawing.Size(69, 22);
            this.dtChangedTimeEnd.TabIndex = 4;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // chkDisktilbud
            // 
            this.chkDisktilbud.AutoSize = true;
            this.chkDisktilbud.Location = new System.Drawing.Point(220, 161);
            this.chkDisktilbud.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkDisktilbud.Name = "chkDisktilbud";
            this.chkDisktilbud.Size = new System.Drawing.Size(18, 17);
            this.chkDisktilbud.TabIndex = 6;
            this.chkDisktilbud.UseVisualStyleBackColor = true;
            // 
            // lbDisktilbud
            // 
            this.lbDisktilbud.AutoSize = true;
            this.lbDisktilbud.Location = new System.Drawing.Point(16, 161);
            this.lbDisktilbud.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDisktilbud.Name = "lbDisktilbud";
            this.lbDisktilbud.Size = new System.Drawing.Size(125, 17);
            this.lbDisktilbud.TabIndex = 13;
            this.lbDisktilbud.Text = "[Vis kun disktilbud]";
            // 
            // dsReport
            // 
            this.dsReport.DataSetName = "ReportDataSet";
            this.dsReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // adapterItemBasicData
            // 
            this.adapterItemBasicData.ClearBeforeFill = true;
            // 
            // adapterSalesPack
            // 
            this.adapterSalesPack.ClearBeforeFill = true;
            // 
            // ReportFormItemBasicData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 261);
            this.Controls.Add(this.dtChangedTimeEnd);
            this.Controls.Add(this.dtChangedTimeStart);
            this.Controls.Add(this.lbDisktilbud);
            this.Controls.Add(this.lbShelfLabelUpd);
            this.Controls.Add(this.lbPosUpd);
            this.Controls.Add(this.chkPosUpd);
            this.Controls.Add(this.chkDisktilbud);
            this.Controls.Add(this.chkShelfLabelUpd);
            this.Controls.Add(this.dtChangeDateEnd);
            this.Controls.Add(this.dtChangeDateStart);
            this.Controls.Add(this.lbChangeDateEnd);
            this.Controls.Add(this.lbChangeDateStart);
            this.Controls.Add(this.lbSubCategory);
            this.Controls.Add(this.btnSubCategory);
            this.Controls.Add(this.txtSubCategory);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportFormItemBasicData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportFormItemBasicData";
            this.Load += new System.EventHandler(this.ReportFormItemBasicData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPreview;
        private ReportDataSet dsReport;
        private ReportItemBasicData reportItemBasicData;
        private RBOS.ReportDataSetTableAdapters.ItemBasicDataTableAdapter adapterItemBasicData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtSubCategory;
        private System.Windows.Forms.Button btnSubCategory;
        private System.Windows.Forms.Label lbSubCategory;
        private System.Windows.Forms.Label lbChangeDateStart;
        private System.Windows.Forms.Label lbChangeDateEnd;
        private System.Windows.Forms.DateTimePicker dtChangeDateStart;
        private System.Windows.Forms.DateTimePicker dtChangeDateEnd;
        private System.Windows.Forms.CheckBox chkShelfLabelUpd;
        private System.Windows.Forms.CheckBox chkPosUpd;
        private System.Windows.Forms.Label lbPosUpd;
        private System.Windows.Forms.Label lbShelfLabelUpd;
        private System.Windows.Forms.DateTimePicker dtChangedTimeStart;
        private System.Windows.Forms.DateTimePicker dtChangedTimeEnd;
        private System.Windows.Forms.PrintDialog printDialog1;
        private RBOS.ReportDataSetTableAdapters.SalesPackTableAdapter adapterSalesPack;
        private RBOS.ReportItemShelfLabels reportItemShelfLabels;
        private System.Windows.Forms.CheckBox chkDisktilbud;
        private System.Windows.Forms.Label lbDisktilbud;
    }
}