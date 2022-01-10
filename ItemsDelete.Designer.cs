namespace RBOS
{
    partial class ItemsDelete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemsDelete));
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSubCategory = new System.Windows.Forms.TextBox();
            this.btnLookupSubCategory = new System.Windows.Forms.Button();
            this.lbSubCategory = new System.Windows.Forms.Label();
            this.lbDaysBack = new System.Windows.Forms.Label();
            this.dtDaysBack = new System.Windows.Forms.DateTimePicker();
            this.txtSubCategoryDesc = new System.Windows.Forms.TextBox();
            this.chkDeleteItemsWithStock = new System.Windows.Forms.CheckBox();
            this.btnShowItemsToBeDeleted = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbNotChangedSince = new System.Windows.Forms.Label();
            this.dtNotChangedSince = new System.Windows.Forms.DateTimePicker();
            this.chkOnlyIncludeUdmeldte = new System.Windows.Forms.CheckBox();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(193, 211);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "[Luk]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtSubCategory
            // 
            this.txtSubCategory.Location = new System.Drawing.Point(100, 16);
            this.txtSubCategory.Name = "txtSubCategory";
            this.txtSubCategory.ReadOnly = true;
            this.txtSubCategory.Size = new System.Drawing.Size(133, 20);
            this.txtSubCategory.TabIndex = 15;
            this.txtSubCategory.TabStop = false;
            this.txtSubCategory.TextChanged += new System.EventHandler(this.txtSubCategory_TextChanged);
            // 
            // btnLookupSubCategory
            // 
            this.btnLookupSubCategory.Image = ((System.Drawing.Image)(resources.GetObject("btnLookupSubCategory.Image")));
            this.btnLookupSubCategory.Location = new System.Drawing.Point(239, 14);
            this.btnLookupSubCategory.Name = "btnLookupSubCategory";
            this.btnLookupSubCategory.Size = new System.Drawing.Size(25, 23);
            this.btnLookupSubCategory.TabIndex = 13;
            this.btnLookupSubCategory.UseVisualStyleBackColor = true;
            this.btnLookupSubCategory.Click += new System.EventHandler(this.btnLookupSubCategory_Click);
            // 
            // lbSubCategory
            // 
            this.lbSubCategory.AutoSize = true;
            this.lbSubCategory.Location = new System.Drawing.Point(12, 19);
            this.lbSubCategory.Name = "lbSubCategory";
            this.lbSubCategory.Size = new System.Drawing.Size(68, 13);
            this.lbSubCategory.TabIndex = 16;
            this.lbSubCategory.Text = "[Varegruppe]";
            // 
            // lbDaysBack
            // 
            this.lbDaysBack.AutoSize = true;
            this.lbDaysBack.Location = new System.Drawing.Point(12, 83);
            this.lbDaysBack.Name = "lbDaysBack";
            this.lbDaysBack.Size = new System.Drawing.Size(114, 13);
            this.lbDaysBack.TabIndex = 17;
            this.lbDaysBack.Text = "[Varer ikke solgt siden]";
            // 
            // dtDaysBack
            // 
            this.dtDaysBack.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDaysBack.Location = new System.Drawing.Point(162, 79);
            this.dtDaysBack.Name = "dtDaysBack";
            this.dtDaysBack.Size = new System.Drawing.Size(89, 20);
            this.dtDaysBack.TabIndex = 18;
            this.dtDaysBack.ValueChanged += new System.EventHandler(this.dtDaysBack_ValueChanged);
            // 
            // txtSubCategoryDesc
            // 
            this.txtSubCategoryDesc.Location = new System.Drawing.Point(100, 42);
            this.txtSubCategoryDesc.Name = "txtSubCategoryDesc";
            this.txtSubCategoryDesc.ReadOnly = true;
            this.txtSubCategoryDesc.Size = new System.Drawing.Size(164, 20);
            this.txtSubCategoryDesc.TabIndex = 19;
            // 
            // chkDeleteItemsWithStock
            // 
            this.chkDeleteItemsWithStock.AutoSize = true;
            this.chkDeleteItemsWithStock.Location = new System.Drawing.Point(15, 149);
            this.chkDeleteItemsWithStock.Name = "chkDeleteItemsWithStock";
            this.chkDeleteItemsWithStock.Size = new System.Drawing.Size(217, 17);
            this.chkDeleteItemsWithStock.TabIndex = 21;
            this.chkDeleteItemsWithStock.Text = "[Slet varer med beholding forskellig fra 0]";
            this.chkDeleteItemsWithStock.UseVisualStyleBackColor = true;
            this.chkDeleteItemsWithStock.CheckedChanged += new System.EventHandler(this.chkDeleteItemsWithStock_CheckedChanged);
            // 
            // btnShowItemsToBeDeleted
            // 
            this.btnShowItemsToBeDeleted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowItemsToBeDeleted.Location = new System.Drawing.Point(98, 211);
            this.btnShowItemsToBeDeleted.Name = "btnShowItemsToBeDeleted";
            this.btnShowItemsToBeDeleted.Size = new System.Drawing.Size(89, 23);
            this.btnShowItemsToBeDeleted.TabIndex = 22;
            this.btnShowItemsToBeDeleted.Text = "[Vis varer]";
            this.btnShowItemsToBeDeleted.UseVisualStyleBackColor = true;
            this.btnShowItemsToBeDeleted.Click += new System.EventHandler(this.btnShowItemsToBeDeleted_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 247);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(280, 22);
            this.statusStrip.TabIndex = 23;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(37, 17);
            this.statusLabel.Text = "status";
            // 
            // lbNotChangedSince
            // 
            this.lbNotChangedSince.AutoSize = true;
            this.lbNotChangedSince.Location = new System.Drawing.Point(12, 110);
            this.lbNotChangedSince.Name = "lbNotChangedSince";
            this.lbNotChangedSince.Size = new System.Drawing.Size(126, 13);
            this.lbNotChangedSince.TabIndex = 24;
            this.lbNotChangedSince.Text = "[Varer ikke ændret siden]";
            // 
            // dtNotChangedSince
            // 
            this.dtNotChangedSince.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNotChangedSince.Location = new System.Drawing.Point(162, 106);
            this.dtNotChangedSince.Name = "dtNotChangedSince";
            this.dtNotChangedSince.Size = new System.Drawing.Size(89, 20);
            this.dtNotChangedSince.TabIndex = 25;
            this.dtNotChangedSince.ValueChanged += new System.EventHandler(this.dtNotChangedSince_ValueChanged);
            // 
            // chkOnlyIncludeUdmeldte
            // 
            this.chkOnlyIncludeUdmeldte.AutoSize = true;
            this.chkOnlyIncludeUdmeldte.Location = new System.Drawing.Point(15, 172);
            this.chkOnlyIncludeUdmeldte.Name = "chkOnlyIncludeUdmeldte";
            this.chkOnlyIncludeUdmeldte.Size = new System.Drawing.Size(135, 17);
            this.chkOnlyIncludeUdmeldte.TabIndex = 26;
            this.chkOnlyIncludeUdmeldte.Text = "[Medtag kun udmeldte]";
            this.chkOnlyIncludeUdmeldte.UseVisualStyleBackColor = true;
            this.chkOnlyIncludeUdmeldte.CheckedChanged += new System.EventHandler(this.chkOnlyIncludeUdmeldte_CheckedChanged);
            // 
            // ItemsDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 269);
            this.Controls.Add(this.chkOnlyIncludeUdmeldte);
            this.Controls.Add(this.dtNotChangedSince);
            this.Controls.Add(this.lbNotChangedSince);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.btnShowItemsToBeDeleted);
            this.Controls.Add(this.chkDeleteItemsWithStock);
            this.Controls.Add(this.txtSubCategoryDesc);
            this.Controls.Add(this.dtDaysBack);
            this.Controls.Add(this.lbDaysBack);
            this.Controls.Add(this.lbSubCategory);
            this.Controls.Add(this.txtSubCategory);
            this.Controls.Add(this.btnLookupSubCategory);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ItemsDelete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Slet varer]";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtSubCategory;
        private System.Windows.Forms.Button btnLookupSubCategory;
        private System.Windows.Forms.Label lbSubCategory;
        private System.Windows.Forms.Label lbDaysBack;
        private System.Windows.Forms.DateTimePicker dtDaysBack;
        private System.Windows.Forms.TextBox txtSubCategoryDesc;
        private System.Windows.Forms.CheckBox chkDeleteItemsWithStock;
        private System.Windows.Forms.Button btnShowItemsToBeDeleted;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Label lbNotChangedSince;
        private System.Windows.Forms.DateTimePicker dtNotChangedSince;
        private System.Windows.Forms.CheckBox chkOnlyIncludeUdmeldte;
    }
}