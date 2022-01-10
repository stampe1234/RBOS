namespace RBOS
{
    partial class ExportRadiantForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportRadiantForm));
            this.btnClose = new System.Windows.Forms.Button();
            this.chkItemsNotUpdatedInRSM = new System.Windows.Forms.CheckBox();
            this.lbItemsNotUpdatedInRSM = new System.Windows.Forms.Label();
            this.txtSubCategoryStart = new System.Windows.Forms.TextBox();
            this.lbSubCategoryFrom = new System.Windows.Forms.Label();
            this.btnLookupSubCategoryStart = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtSubCategoryEnd = new System.Windows.Forms.TextBox();
            this.lbSubCategoryTo = new System.Windows.Forms.Label();
            this.btnLookupSubCategoryEnd = new System.Windows.Forms.Button();
            this.txtSubCategoryDescStart = new System.Windows.Forms.TextBox();
            this.txtSubCategoryDescEnd = new System.Windows.Forms.TextBox();
            this.groupItem = new System.Windows.Forms.GroupBox();
            this.btnSalesPackClear = new System.Windows.Forms.Button();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lbItemName = new System.Windows.Forms.Label();
            this.lbBarcode = new System.Windows.Forms.Label();
            this.btnSalesPackLookup = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.dtChangedTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.dtChangedTimeStart = new System.Windows.Forms.DateTimePicker();
            this.dtChangeDateEnd = new System.Windows.Forms.DateTimePicker();
            this.dtChangeDateStart = new System.Windows.Forms.DateTimePicker();
            this.lbChangeDateEnd = new System.Windows.Forms.Label();
            this.lbChangeDateStart = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbMCT = new System.Windows.Forms.Label();
            this.chkMCT = new System.Windows.Forms.CheckBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.chkTSM = new System.Windows.Forms.CheckBox();
            this.lbTSM = new System.Windows.Forms.Label();
            this.chkInitialize = new System.Windows.Forms.CheckBox();
            this.lbInitialize = new System.Windows.Forms.Label();
            this.groupItem.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(278, 342);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkItemsNotUpdatedInRSM
            // 
            this.chkItemsNotUpdatedInRSM.AutoSize = true;
            this.chkItemsNotUpdatedInRSM.Checked = true;
            this.chkItemsNotUpdatedInRSM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkItemsNotUpdatedInRSM.Location = new System.Drawing.Point(193, 9);
            this.chkItemsNotUpdatedInRSM.Name = "chkItemsNotUpdatedInRSM";
            this.chkItemsNotUpdatedInRSM.Size = new System.Drawing.Size(15, 14);
            this.chkItemsNotUpdatedInRSM.TabIndex = 3;
            this.chkItemsNotUpdatedInRSM.UseVisualStyleBackColor = true;
            this.chkItemsNotUpdatedInRSM.CheckedChanged += new System.EventHandler(this.chkItemsNotUpdatedInRSM_CheckedChanged);
            // 
            // lbItemsNotUpdatedInRSM
            // 
            this.lbItemsNotUpdatedInRSM.AutoSize = true;
            this.lbItemsNotUpdatedInRSM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbItemsNotUpdatedInRSM.Location = new System.Drawing.Point(12, 9);
            this.lbItemsNotUpdatedInRSM.Name = "lbItemsNotUpdatedInRSM";
            this.lbItemsNotUpdatedInRSM.Size = new System.Drawing.Size(158, 13);
            this.lbItemsNotUpdatedInRSM.TabIndex = 4;
            this.lbItemsNotUpdatedInRSM.Text = "[Items not updated in RSM";
            // 
            // txtSubCategoryStart
            // 
            this.txtSubCategoryStart.Location = new System.Drawing.Point(193, 38);
            this.txtSubCategoryStart.Name = "txtSubCategoryStart";
            this.txtSubCategoryStart.ReadOnly = true;
            this.txtSubCategoryStart.Size = new System.Drawing.Size(133, 20);
            this.txtSubCategoryStart.TabIndex = 8;
            // 
            // lbSubCategoryFrom
            // 
            this.lbSubCategoryFrom.AutoSize = true;
            this.lbSubCategoryFrom.Location = new System.Drawing.Point(12, 41);
            this.lbSubCategoryFrom.Name = "lbSubCategoryFrom";
            this.lbSubCategoryFrom.Size = new System.Drawing.Size(100, 13);
            this.lbSubCategoryFrom.TabIndex = 6;
            this.lbSubCategoryFrom.Text = "[Sub Category from]";
            // 
            // btnLookupSubCategoryStart
            // 
            this.btnLookupSubCategoryStart.ImageIndex = 2;
            this.btnLookupSubCategoryStart.ImageList = this.imageList1;
            this.btnLookupSubCategoryStart.Location = new System.Drawing.Point(332, 36);
            this.btnLookupSubCategoryStart.Name = "btnLookupSubCategoryStart";
            this.btnLookupSubCategoryStart.Size = new System.Drawing.Size(27, 23);
            this.btnLookupSubCategoryStart.TabIndex = 7;
            this.btnLookupSubCategoryStart.UseVisualStyleBackColor = true;
            this.btnLookupSubCategoryStart.Click += new System.EventHandler(this.btnLookupSubCategoryFrom_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "search_16.gif");
            this.imageList1.Images.SetKeyName(1, "trash.gif");
            this.imageList1.Images.SetKeyName(2, "lookupform2.gif");
            // 
            // txtSubCategoryEnd
            // 
            this.txtSubCategoryEnd.Location = new System.Drawing.Point(193, 90);
            this.txtSubCategoryEnd.Name = "txtSubCategoryEnd";
            this.txtSubCategoryEnd.ReadOnly = true;
            this.txtSubCategoryEnd.Size = new System.Drawing.Size(133, 20);
            this.txtSubCategoryEnd.TabIndex = 12;
            // 
            // lbSubCategoryTo
            // 
            this.lbSubCategoryTo.AutoSize = true;
            this.lbSubCategoryTo.Location = new System.Drawing.Point(12, 93);
            this.lbSubCategoryTo.Name = "lbSubCategoryTo";
            this.lbSubCategoryTo.Size = new System.Drawing.Size(89, 13);
            this.lbSubCategoryTo.TabIndex = 10;
            this.lbSubCategoryTo.Text = "[Sub Category to]";
            // 
            // btnLookupSubCategoryEnd
            // 
            this.btnLookupSubCategoryEnd.ImageIndex = 2;
            this.btnLookupSubCategoryEnd.ImageList = this.imageList1;
            this.btnLookupSubCategoryEnd.Location = new System.Drawing.Point(332, 88);
            this.btnLookupSubCategoryEnd.Name = "btnLookupSubCategoryEnd";
            this.btnLookupSubCategoryEnd.Size = new System.Drawing.Size(27, 23);
            this.btnLookupSubCategoryEnd.TabIndex = 11;
            this.btnLookupSubCategoryEnd.UseVisualStyleBackColor = true;
            this.btnLookupSubCategoryEnd.Click += new System.EventHandler(this.btnLookupSubCategoryTo_Click);
            // 
            // txtSubCategoryDescStart
            // 
            this.txtSubCategoryDescStart.Location = new System.Drawing.Point(193, 64);
            this.txtSubCategoryDescStart.Name = "txtSubCategoryDescStart";
            this.txtSubCategoryDescStart.ReadOnly = true;
            this.txtSubCategoryDescStart.Size = new System.Drawing.Size(166, 20);
            this.txtSubCategoryDescStart.TabIndex = 13;
            // 
            // txtSubCategoryDescEnd
            // 
            this.txtSubCategoryDescEnd.Location = new System.Drawing.Point(193, 116);
            this.txtSubCategoryDescEnd.Name = "txtSubCategoryDescEnd";
            this.txtSubCategoryDescEnd.ReadOnly = true;
            this.txtSubCategoryDescEnd.Size = new System.Drawing.Size(166, 20);
            this.txtSubCategoryDescEnd.TabIndex = 14;
            // 
            // groupItem
            // 
            this.groupItem.Controls.Add(this.btnSalesPackClear);
            this.groupItem.Controls.Add(this.txtItemName);
            this.groupItem.Controls.Add(this.lbItemName);
            this.groupItem.Controls.Add(this.lbBarcode);
            this.groupItem.Controls.Add(this.btnSalesPackLookup);
            this.groupItem.Controls.Add(this.txtBarcode);
            this.groupItem.Location = new System.Drawing.Point(15, 142);
            this.groupItem.Name = "groupItem";
            this.groupItem.Size = new System.Drawing.Size(344, 78);
            this.groupItem.TabIndex = 34;
            this.groupItem.TabStop = false;
            this.groupItem.Text = "[Item]";
            // 
            // btnSalesPackClear
            // 
            this.btnSalesPackClear.ImageIndex = 1;
            this.btnSalesPackClear.ImageList = this.imageList1;
            this.btnSalesPackClear.Location = new System.Drawing.Point(310, 17);
            this.btnSalesPackClear.Name = "btnSalesPackClear";
            this.btnSalesPackClear.Size = new System.Drawing.Size(28, 23);
            this.btnSalesPackClear.TabIndex = 43;
            this.btnSalesPackClear.UseVisualStyleBackColor = true;
            this.btnSalesPackClear.Click += new System.EventHandler(this.btnSalesPackClear_Click);
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(178, 45);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(160, 20);
            this.txtItemName.TabIndex = 42;
            // 
            // lbItemName
            // 
            this.lbItemName.AutoSize = true;
            this.lbItemName.Location = new System.Drawing.Point(6, 48);
            this.lbItemName.Name = "lbItemName";
            this.lbItemName.Size = new System.Drawing.Size(64, 13);
            this.lbItemName.TabIndex = 41;
            this.lbItemName.Text = "[Item Name]";
            // 
            // lbBarcode
            // 
            this.lbBarcode.AutoSize = true;
            this.lbBarcode.Location = new System.Drawing.Point(6, 22);
            this.lbBarcode.Name = "lbBarcode";
            this.lbBarcode.Size = new System.Drawing.Size(53, 13);
            this.lbBarcode.TabIndex = 37;
            this.lbBarcode.Text = "[Barcode]";
            // 
            // btnSalesPackLookup
            // 
            this.btnSalesPackLookup.ImageIndex = 0;
            this.btnSalesPackLookup.ImageList = this.imageList1;
            this.btnSalesPackLookup.Location = new System.Drawing.Point(276, 17);
            this.btnSalesPackLookup.Name = "btnSalesPackLookup";
            this.btnSalesPackLookup.Size = new System.Drawing.Size(28, 23);
            this.btnSalesPackLookup.TabIndex = 35;
            this.btnSalesPackLookup.UseVisualStyleBackColor = true;
            this.btnSalesPackLookup.Click += new System.EventHandler(this.btnSalesPackLookup_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(178, 19);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.ReadOnly = true;
            this.txtBarcode.Size = new System.Drawing.Size(92, 20);
            this.txtBarcode.TabIndex = 36;
            // 
            // dtChangedTimeEnd
            // 
            this.dtChangedTimeEnd.CustomFormat = "HH:mm";
            this.dtChangedTimeEnd.Enabled = false;
            this.dtChangedTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtChangedTimeEnd.Location = new System.Drawing.Point(293, 252);
            this.dtChangedTimeEnd.Name = "dtChangedTimeEnd";
            this.dtChangedTimeEnd.ShowUpDown = true;
            this.dtChangedTimeEnd.Size = new System.Drawing.Size(53, 20);
            this.dtChangedTimeEnd.TabIndex = 42;
            // 
            // dtChangedTimeStart
            // 
            this.dtChangedTimeStart.CustomFormat = "HH:mm";
            this.dtChangedTimeStart.Enabled = false;
            this.dtChangedTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtChangedTimeStart.Location = new System.Drawing.Point(293, 226);
            this.dtChangedTimeStart.Name = "dtChangedTimeStart";
            this.dtChangedTimeStart.ShowUpDown = true;
            this.dtChangedTimeStart.Size = new System.Drawing.Size(53, 20);
            this.dtChangedTimeStart.TabIndex = 40;
            // 
            // dtChangeDateEnd
            // 
            this.dtChangeDateEnd.Checked = false;
            this.dtChangeDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtChangeDateEnd.Location = new System.Drawing.Point(193, 252);
            this.dtChangeDateEnd.Name = "dtChangeDateEnd";
            this.dtChangeDateEnd.ShowCheckBox = true;
            this.dtChangeDateEnd.Size = new System.Drawing.Size(94, 20);
            this.dtChangeDateEnd.TabIndex = 41;
            this.dtChangeDateEnd.ValueChanged += new System.EventHandler(this.dtChangeDateEnd_ValueChanged);
            // 
            // dtChangeDateStart
            // 
            this.dtChangeDateStart.Checked = false;
            this.dtChangeDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtChangeDateStart.Location = new System.Drawing.Point(193, 226);
            this.dtChangeDateStart.Name = "dtChangeDateStart";
            this.dtChangeDateStart.ShowCheckBox = true;
            this.dtChangeDateStart.Size = new System.Drawing.Size(94, 20);
            this.dtChangeDateStart.TabIndex = 39;
            this.dtChangeDateStart.ValueChanged += new System.EventHandler(this.dtChangeDateStart_ValueChanged);
            // 
            // lbChangeDateEnd
            // 
            this.lbChangeDateEnd.AutoSize = true;
            this.lbChangeDateEnd.Location = new System.Drawing.Point(21, 256);
            this.lbChangeDateEnd.Name = "lbChangeDateEnd";
            this.lbChangeDateEnd.Size = new System.Drawing.Size(162, 13);
            this.lbChangeDateEnd.TabIndex = 44;
            this.lbChangeDateEnd.Text = "[Changed interval end date/time]";
            // 
            // lbChangeDateStart
            // 
            this.lbChangeDateStart.AutoSize = true;
            this.lbChangeDateStart.Location = new System.Drawing.Point(21, 230);
            this.lbChangeDateStart.Name = "lbChangeDateStart";
            this.lbChangeDateStart.Size = new System.Drawing.Size(164, 13);
            this.lbChangeDateStart.TabIndex = 43;
            this.lbChangeDateStart.Text = "[Changed interval start date/time]";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusMsg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 378);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(375, 22);
            this.statusStrip1.TabIndex = 45;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusMsg
            // 
            this.statusMsg.Name = "statusMsg";
            this.statusMsg.Size = new System.Drawing.Size(118, 17);
            this.statusMsg.Text = "toolStripStatusLabel1";
            // 
            // lbMCT
            // 
            this.lbMCT.AutoSize = true;
            this.lbMCT.Location = new System.Drawing.Point(21, 291);
            this.lbMCT.Name = "lbMCT";
            this.lbMCT.Size = new System.Drawing.Size(141, 13);
            this.lbMCT.TabIndex = 46;
            this.lbMCT.Text = "[Include SubCategory setup]";
            this.lbMCT.Visible = false;
            // 
            // chkMCT
            // 
            this.chkMCT.AutoSize = true;
            this.chkMCT.Location = new System.Drawing.Point(193, 291);
            this.chkMCT.Name = "chkMCT";
            this.chkMCT.Size = new System.Drawing.Size(15, 14);
            this.chkMCT.TabIndex = 47;
            this.chkMCT.UseVisualStyleBackColor = true;
            this.chkMCT.Visible = false;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(197, 342);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 48;
            this.btnExport.Text = "[Export]";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // chkTSM
            // 
            this.chkTSM.AutoSize = true;
            this.chkTSM.Location = new System.Drawing.Point(193, 311);
            this.chkTSM.Name = "chkTSM";
            this.chkTSM.Size = new System.Drawing.Size(15, 14);
            this.chkTSM.TabIndex = 50;
            this.chkTSM.UseVisualStyleBackColor = true;
            this.chkTSM.Visible = false;
            this.chkTSM.CheckedChanged += new System.EventHandler(this.chkTSM_CheckedChanged);
            // 
            // lbTSM
            // 
            this.lbTSM.AutoSize = true;
            this.lbTSM.Location = new System.Drawing.Point(21, 311);
            this.lbTSM.Name = "lbTSM";
            this.lbTSM.Size = new System.Drawing.Size(137, 13);
            this.lbTSM.TabIndex = 49;
            this.lbTSM.Text = "[Include TaxStrategyMaint.]";
            this.lbTSM.Visible = false;
            // 
            // chkInitialize
            // 
            this.chkInitialize.AutoSize = true;
            this.chkInitialize.Location = new System.Drawing.Point(293, 291);
            this.chkInitialize.Name = "chkInitialize";
            this.chkInitialize.Size = new System.Drawing.Size(15, 14);
            this.chkInitialize.TabIndex = 51;
            this.chkInitialize.UseVisualStyleBackColor = true;
            this.chkInitialize.CheckedChanged += new System.EventHandler(this.chkInitialize_CheckedChanged);
            // 
            // lbInitialize
            // 
            this.lbInitialize.AutoSize = true;
            this.lbInitialize.Location = new System.Drawing.Point(211, 291);
            this.lbInitialize.Name = "lbInitialize";
            this.lbInitialize.Size = new System.Drawing.Size(76, 13);
            this.lbInitialize.TabIndex = 52;
            this.lbInitialize.Text = "Fuld download";
            // 
            // ExportRadiantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 400);
            this.Controls.Add(this.lbInitialize);
            this.Controls.Add(this.chkInitialize);
            this.Controls.Add(this.chkTSM);
            this.Controls.Add(this.lbTSM);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.chkMCT);
            this.Controls.Add(this.lbMCT);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dtChangedTimeEnd);
            this.Controls.Add(this.dtChangedTimeStart);
            this.Controls.Add(this.dtChangeDateEnd);
            this.Controls.Add(this.dtChangeDateStart);
            this.Controls.Add(this.lbChangeDateEnd);
            this.Controls.Add(this.lbChangeDateStart);
            this.Controls.Add(this.groupItem);
            this.Controls.Add(this.txtSubCategoryDescEnd);
            this.Controls.Add(this.txtSubCategoryDescStart);
            this.Controls.Add(this.txtSubCategoryEnd);
            this.Controls.Add(this.lbSubCategoryTo);
            this.Controls.Add(this.btnLookupSubCategoryEnd);
            this.Controls.Add(this.txtSubCategoryStart);
            this.Controls.Add(this.lbSubCategoryFrom);
            this.Controls.Add(this.btnLookupSubCategoryStart);
            this.Controls.Add(this.lbItemsNotUpdatedInRSM);
            this.Controls.Add(this.chkItemsNotUpdatedInRSM);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ExportRadiantForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExportRadiantForm";
            this.Load += new System.EventHandler(this.ExportRadiantForm_Load);
            this.groupItem.ResumeLayout(false);
            this.groupItem.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkItemsNotUpdatedInRSM;
        private System.Windows.Forms.Label lbItemsNotUpdatedInRSM;
        private System.Windows.Forms.TextBox txtSubCategoryStart;
        private System.Windows.Forms.Label lbSubCategoryFrom;
        private System.Windows.Forms.Button btnLookupSubCategoryStart;
        private System.Windows.Forms.TextBox txtSubCategoryEnd;
        private System.Windows.Forms.Label lbSubCategoryTo;
        private System.Windows.Forms.Button btnLookupSubCategoryEnd;
        private System.Windows.Forms.TextBox txtSubCategoryDescStart;
        private System.Windows.Forms.TextBox txtSubCategoryDescEnd;
        private System.Windows.Forms.GroupBox groupItem;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label lbItemName;
        private System.Windows.Forms.Label lbBarcode;
        private System.Windows.Forms.Button btnSalesPackLookup;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button btnSalesPackClear;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DateTimePicker dtChangedTimeEnd;
        private System.Windows.Forms.DateTimePicker dtChangedTimeStart;
        private System.Windows.Forms.DateTimePicker dtChangeDateEnd;
        private System.Windows.Forms.DateTimePicker dtChangeDateStart;
        private System.Windows.Forms.Label lbChangeDateEnd;
        private System.Windows.Forms.Label lbChangeDateStart;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusMsg;
        private System.Windows.Forms.Label lbMCT;
        private System.Windows.Forms.CheckBox chkMCT;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.CheckBox chkTSM;
        private System.Windows.Forms.Label lbTSM;
        private System.Windows.Forms.CheckBox chkInitialize;
        private System.Windows.Forms.Label lbInitialize;
    }
}