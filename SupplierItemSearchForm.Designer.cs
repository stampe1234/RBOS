namespace RBOS
{
    partial class SupplierItemSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierItemSearchForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bindingSupplierItemSearch = new System.Windows.Forms.BindingSource(this.components);
            this.dsItem = new RBOS.ItemDataSet();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtSupplierID = new System.Windows.Forms.TextBox();
            this.txtSubCategory = new System.Windows.Forms.TextBox();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.txtReceiptText = new System.Windows.Forms.TextBox();
            this.lbSupplierID = new System.Windows.Forms.Label();
            this.lbSupplierName = new System.Windows.Forms.Label();
            this.lbReceiptText = new System.Windows.Forms.Label();
            this.lbSubCategory = new System.Windows.Forms.Label();
            this.btnLookupSupplier = new System.Windows.Forms.Button();
            this.btnLookupSubCategory = new System.Windows.Forms.Button();
            this.adapterSupplierItemSearch = new RBOS.ItemDataSetTableAdapters.SupplierItemSearchTableAdapter();
            this.txtOrderingNumber = new System.Windows.Forms.TextBox();
            this.lbOrderingNumber = new System.Windows.Forms.Label();
            this.grid = new DRS.Extensions.DRS_DataGridView();
            this.colSupplierID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderingNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceiptText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKolliSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalesPack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackageCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSupplierItemSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSupplierItemSearch
            // 
            this.bindingSupplierItemSearch.DataMember = "SupplierItemSearch";
            this.bindingSupplierItemSearch.DataSource = this.dsItem;
            // 
            // dsItem
            // 
            this.dsItem.DataSetName = "ItemDataSet";
            this.dsItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(419, 448);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 6;
            this.btnSelect.Text = "[Select]";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(500, 448);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "[Cancel]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtSupplierID
            // 
            this.txtSupplierID.Location = new System.Drawing.Point(12, 26);
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.Size = new System.Drawing.Size(51, 20);
            this.txtSupplierID.TabIndex = 0;
            this.txtSupplierID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupplierID_KeyDown);
            this.txtSupplierID.Leave += new System.EventHandler(this.txtSupplierID_Leave);
            // 
            // txtSubCategory
            // 
            this.txtSubCategory.Location = new System.Drawing.Point(452, 26);
            this.txtSubCategory.Name = "txtSubCategory";
            this.txtSubCategory.ReadOnly = true;
            this.txtSubCategory.Size = new System.Drawing.Size(91, 20);
            this.txtSubCategory.TabIndex = 4;
            this.txtSubCategory.TabStop = false;
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Location = new System.Drawing.Point(101, 26);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.ReadOnly = true;
            this.txtSupplierName.Size = new System.Drawing.Size(106, 20);
            this.txtSupplierName.TabIndex = 2;
            this.txtSupplierName.TabStop = false;
            // 
            // txtReceiptText
            // 
            this.txtReceiptText.Location = new System.Drawing.Point(318, 26);
            this.txtReceiptText.MaxLength = 30;
            this.txtReceiptText.Name = "txtReceiptText";
            this.txtReceiptText.Size = new System.Drawing.Size(128, 20);
            this.txtReceiptText.TabIndex = 3;
            this.txtReceiptText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReceiptText_KeyDown);
            this.txtReceiptText.Leave += new System.EventHandler(this.txtReceiptText_Leave);
            // 
            // lbSupplierID
            // 
            this.lbSupplierID.AutoSize = true;
            this.lbSupplierID.Location = new System.Drawing.Point(12, 8);
            this.lbSupplierID.Name = "lbSupplierID";
            this.lbSupplierID.Size = new System.Drawing.Size(54, 13);
            this.lbSupplierID.TabIndex = 7;
            this.lbSupplierID.Text = "[Suppl.ID]";
            // 
            // lbSupplierName
            // 
            this.lbSupplierName.AutoSize = true;
            this.lbSupplierName.Location = new System.Drawing.Point(98, 8);
            this.lbSupplierName.Name = "lbSupplierName";
            this.lbSupplierName.Size = new System.Drawing.Size(82, 13);
            this.lbSupplierName.TabIndex = 8;
            this.lbSupplierName.Text = "[Supplier Name]";
            // 
            // lbReceiptText
            // 
            this.lbReceiptText.AutoSize = true;
            this.lbReceiptText.Location = new System.Drawing.Point(315, 9);
            this.lbReceiptText.Name = "lbReceiptText";
            this.lbReceiptText.Size = new System.Drawing.Size(71, 13);
            this.lbReceiptText.TabIndex = 9;
            this.lbReceiptText.Text = "[ReceiptText]";
            // 
            // lbSubCategory
            // 
            this.lbSubCategory.AutoSize = true;
            this.lbSubCategory.Location = new System.Drawing.Point(449, 8);
            this.lbSubCategory.Name = "lbSubCategory";
            this.lbSubCategory.Size = new System.Drawing.Size(74, 13);
            this.lbSubCategory.TabIndex = 10;
            this.lbSubCategory.Text = "[SubCategory]";
            // 
            // btnLookupSupplier
            // 
            this.btnLookupSupplier.Image = ((System.Drawing.Image)(resources.GetObject("btnLookupSupplier.Image")));
            this.btnLookupSupplier.Location = new System.Drawing.Point(69, 24);
            this.btnLookupSupplier.Name = "btnLookupSupplier";
            this.btnLookupSupplier.Size = new System.Drawing.Size(26, 23);
            this.btnLookupSupplier.TabIndex = 1;
            this.btnLookupSupplier.UseVisualStyleBackColor = true;
            this.btnLookupSupplier.Click += new System.EventHandler(this.btnLookupSupplier_Click);
            // 
            // btnLookupSubCategory
            // 
            this.btnLookupSubCategory.Image = ((System.Drawing.Image)(resources.GetObject("btnLookupSubCategory.Image")));
            this.btnLookupSubCategory.Location = new System.Drawing.Point(549, 23);
            this.btnLookupSubCategory.Name = "btnLookupSubCategory";
            this.btnLookupSubCategory.Size = new System.Drawing.Size(26, 23);
            this.btnLookupSubCategory.TabIndex = 4;
            this.btnLookupSubCategory.UseVisualStyleBackColor = true;
            this.btnLookupSubCategory.Click += new System.EventHandler(this.btnLookupSubCategory_Click);
            // 
            // adapterSupplierItemSearch
            // 
            this.adapterSupplierItemSearch.ClearBeforeFill = true;
            // 
            // txtOrderingNumber
            // 
            this.txtOrderingNumber.Location = new System.Drawing.Point(213, 26);
            this.txtOrderingNumber.MaxLength = 30;
            this.txtOrderingNumber.Name = "txtOrderingNumber";
            this.txtOrderingNumber.Size = new System.Drawing.Size(99, 20);
            this.txtOrderingNumber.TabIndex = 2;
            this.txtOrderingNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrderingNumber_KeyDown);
            this.txtOrderingNumber.Leave += new System.EventHandler(this.txtOrderingNumber_Leave);
            // 
            // lbOrderingNumber
            // 
            this.lbOrderingNumber.AutoSize = true;
            this.lbOrderingNumber.Location = new System.Drawing.Point(210, 9);
            this.lbOrderingNumber.Name = "lbOrderingNumber";
            this.lbOrderingNumber.Size = new System.Drawing.Size(93, 13);
            this.lbOrderingNumber.TabIndex = 9;
            this.lbOrderingNumber.Text = "[Ordering Number]";
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeColumns = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.AutoGenerateColumns = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid.ColumnHeadersHeight = 21;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSupplierID,
            this.colOrderingNumber,
            this.colReceiptText,
            this.colKolliSize,
            this.colSalesPack,
            this.colPackageCost,
            this.colSubCategory});
            this.grid.DataSource = this.bindingSupplierItemSearch;
            this.grid.Location = new System.Drawing.Point(12, 52);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.RowHeadersWidth = 25;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(563, 390);
            this.grid.StandardTab = true;
            this.grid.TabIndex = 5;
            this.grid.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grid_MouseDoubleClick);
            this.grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            // 
            // colSupplierID
            // 
            this.colSupplierID.DataPropertyName = "SupplierID";
            this.colSupplierID.HeaderText = "Suppl.ID";
            this.colSupplierID.Name = "colSupplierID";
            this.colSupplierID.ReadOnly = true;
            this.colSupplierID.Width = 50;
            // 
            // colOrderingNumber
            // 
            this.colOrderingNumber.DataPropertyName = "OrderingNumber";
            this.colOrderingNumber.HeaderText = "Order.No";
            this.colOrderingNumber.Name = "colOrderingNumber";
            this.colOrderingNumber.ReadOnly = true;
            this.colOrderingNumber.Width = 90;
            // 
            // colReceiptText
            // 
            this.colReceiptText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colReceiptText.DataPropertyName = "ReceiptText";
            this.colReceiptText.HeaderText = "Receipt Text";
            this.colReceiptText.Name = "colReceiptText";
            this.colReceiptText.ReadOnly = true;
            // 
            // colKolliSize
            // 
            this.colKolliSize.DataPropertyName = "KolliSize";
            this.colKolliSize.HeaderText = "Kolli";
            this.colKolliSize.Name = "colKolliSize";
            this.colKolliSize.ReadOnly = true;
            this.colKolliSize.Width = 35;
            // 
            // colSalesPack
            // 
            this.colSalesPack.DataPropertyName = "PackTypeName";
            this.colSalesPack.HeaderText = "SP";
            this.colSalesPack.Name = "colSalesPack";
            this.colSalesPack.ReadOnly = true;
            this.colSalesPack.Width = 50;
            // 
            // colPackageCost
            // 
            this.colPackageCost.DataPropertyName = "PackageCost";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.colPackageCost.DefaultCellStyle = dataGridViewCellStyle1;
            this.colPackageCost.HeaderText = "Kolli Cost";
            this.colPackageCost.Name = "colPackageCost";
            this.colPackageCost.ReadOnly = true;
            this.colPackageCost.Width = 60;
            // 
            // colSubCategory
            // 
            this.colSubCategory.DataPropertyName = "SubCategory";
            this.colSubCategory.HeaderText = "SubCategory";
            this.colSubCategory.Name = "colSubCategory";
            this.colSubCategory.ReadOnly = true;
            this.colSubCategory.Width = 75;
            // 
            // SupplierItemSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 483);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.btnLookupSubCategory);
            this.Controls.Add(this.btnLookupSupplier);
            this.Controls.Add(this.lbSubCategory);
            this.Controls.Add(this.lbOrderingNumber);
            this.Controls.Add(this.lbReceiptText);
            this.Controls.Add(this.lbSupplierName);
            this.Controls.Add(this.lbSupplierID);
            this.Controls.Add(this.txtOrderingNumber);
            this.Controls.Add(this.txtReceiptText);
            this.Controls.Add(this.txtSupplierName);
            this.Controls.Add(this.txtSubCategory);
            this.Controls.Add(this.txtSupplierID);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SupplierItemSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SupplierSearchForm";
            this.Load += new System.EventHandler(this.SupplierItemSearchForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSupplierItemSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtSupplierID;
        private System.Windows.Forms.TextBox txtSubCategory;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.TextBox txtReceiptText;
        private System.Windows.Forms.Label lbSupplierID;
        private System.Windows.Forms.Label lbSupplierName;
        private System.Windows.Forms.Label lbReceiptText;
        private System.Windows.Forms.Label lbSubCategory;
        private System.Windows.Forms.Button btnLookupSupplier;
        private System.Windows.Forms.Button btnLookupSubCategory;
        private ItemDataSet dsItem;
        private System.Windows.Forms.BindingSource bindingSupplierItemSearch;
        private RBOS.ItemDataSetTableAdapters.SupplierItemSearchTableAdapter adapterSupplierItemSearch;
        private DRS.Extensions.DRS_DataGridView grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplierID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderingNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceiptText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKolliSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalesPack;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackageCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubCategory;
        private System.Windows.Forms.TextBox txtOrderingNumber;
        private System.Windows.Forms.Label lbOrderingNumber;
    }
}