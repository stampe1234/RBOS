namespace RBOS
{
    partial class SearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbAmount = new System.Windows.Forms.Label();
            this.txtSubCategory = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lbBarcode = new System.Windows.Forms.Label();
            this.lbItemName = new System.Windows.Forms.Label();
            this.lbSubCategory = new System.Windows.Forms.Label();
            this.btnOkFilter = new System.Windows.Forms.Button();
            this.btnLookupSubCategory = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.bindingItemSearch = new System.Windows.Forms.BindingSource(this.components);
            this.dsItem = new RBOS.ItemDataSet();
            this.adapterItemSearch = new RBOS.ItemDataSetTableAdapters.ItemSearchTableAdapter();
            this.txtOrderingNumber = new System.Windows.Forms.TextBox();
            this.lbOrderingNumber = new System.Windows.Forms.Label();
            this.dataGridView1 = new DRS.Extensions.DRS_DataGridView();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderingNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingInactiveItems = new System.Windows.Forms.BindingSource(this.components);
            this.inactiveItemTableAdapter = new RBOS.ItemDataSetTableAdapters.InactiveItemTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bindingItemSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingInactiveItems)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(624, 574);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 28);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "[select]";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(732, 574);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "[cancel]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbAmount
            // 
            this.lbAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbAmount.AutoSize = true;
            this.lbAmount.Location = new System.Drawing.Point(16, 574);
            this.lbAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAmount.Name = "lbAmount";
            this.lbAmount.Size = new System.Drawing.Size(75, 17);
            this.lbAmount.TabIndex = 4;
            this.lbAmount.Text = "[lbAmount]";
            // 
            // txtSubCategory
            // 
            this.txtSubCategory.Location = new System.Drawing.Point(684, 34);
            this.txtSubCategory.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubCategory.Name = "txtSubCategory";
            this.txtSubCategory.ReadOnly = true;
            this.txtSubCategory.Size = new System.Drawing.Size(108, 22);
            this.txtSubCategory.TabIndex = 3;
            this.txtSubCategory.TabStop = false;
            this.txtSubCategory.Leave += new System.EventHandler(this.txtSubCategory_Leave);
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(151, 34);
            this.txtItemName.Margin = new System.Windows.Forms.Padding(4);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(397, 22);
            this.txtItemName.TabIndex = 1;
            this.txtItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemName_KeyDown);
            this.txtItemName.Leave += new System.EventHandler(this.txtItemName_Leave);
            // 
            // lbBarcode
            // 
            this.lbBarcode.AutoSize = true;
            this.lbBarcode.Location = new System.Drawing.Point(15, 11);
            this.lbBarcode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbBarcode.Name = "lbBarcode";
            this.lbBarcode.Size = new System.Drawing.Size(68, 17);
            this.lbBarcode.TabIndex = 8;
            this.lbBarcode.Text = "[barcode]";
            // 
            // lbItemName
            // 
            this.lbItemName.AutoSize = true;
            this.lbItemName.Location = new System.Drawing.Point(149, 11);
            this.lbItemName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbItemName.Name = "lbItemName";
            this.lbItemName.Size = new System.Drawing.Size(77, 17);
            this.lbItemName.TabIndex = 9;
            this.lbItemName.Text = "[itemname]";
            // 
            // lbSubCategory
            // 
            this.lbSubCategory.AutoSize = true;
            this.lbSubCategory.Location = new System.Drawing.Point(683, 11);
            this.lbSubCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSubCategory.Name = "lbSubCategory";
            this.lbSubCategory.Size = new System.Drawing.Size(94, 17);
            this.lbSubCategory.TabIndex = 10;
            this.lbSubCategory.Text = "[subcategory]";
            // 
            // btnOkFilter
            // 
            this.btnOkFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOkFilter.Enabled = false;
            this.btnOkFilter.Location = new System.Drawing.Point(516, 574);
            this.btnOkFilter.Margin = new System.Windows.Forms.Padding(4);
            this.btnOkFilter.Name = "btnOkFilter";
            this.btnOkFilter.Size = new System.Drawing.Size(100, 28);
            this.btnOkFilter.TabIndex = 6;
            this.btnOkFilter.Text = "[select with filter]";
            this.btnOkFilter.UseVisualStyleBackColor = true;
            this.btnOkFilter.Click += new System.EventHandler(this.btnOkFilter_Click);
            // 
            // btnLookupSubCategory
            // 
            this.btnLookupSubCategory.Image = ((System.Drawing.Image)(resources.GetObject("btnLookupSubCategory.Image")));
            this.btnLookupSubCategory.Location = new System.Drawing.Point(796, 32);
            this.btnLookupSubCategory.Margin = new System.Windows.Forms.Padding(4);
            this.btnLookupSubCategory.Name = "btnLookupSubCategory";
            this.btnLookupSubCategory.Size = new System.Drawing.Size(36, 28);
            this.btnLookupSubCategory.TabIndex = 4;
            this.btnLookupSubCategory.UseVisualStyleBackColor = true;
            this.btnLookupSubCategory.Click += new System.EventHandler(this.btnLookupSubCategory_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(16, 34);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(4);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(132, 22);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            this.txtBarcode.Leave += new System.EventHandler(this.txtBarcode_Leave);
            // 
            // bindingItemSearch
            // 
            this.bindingItemSearch.DataMember = "ItemSearch";
            this.bindingItemSearch.DataSource = this.dsItem;
            // 
            // dsItem
            // 
            this.dsItem.DataSetName = "ItemDataSet";
            this.dsItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // adapterItemSearch
            // 
            this.adapterItemSearch.ClearBeforeFill = true;
            // 
            // txtOrderingNumber
            // 
            this.txtOrderingNumber.Location = new System.Drawing.Point(551, 34);
            this.txtOrderingNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtOrderingNumber.Name = "txtOrderingNumber";
            this.txtOrderingNumber.Size = new System.Drawing.Size(131, 22);
            this.txtOrderingNumber.TabIndex = 2;
            this.txtOrderingNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrderingNumber_KeyDown);
            this.txtOrderingNumber.Leave += new System.EventHandler(this.txtOrderingNumber_Leave);
            // 
            // lbOrderingNumber
            // 
            this.lbOrderingNumber.AutoSize = true;
            this.lbOrderingNumber.Location = new System.Drawing.Point(548, 11);
            this.lbOrderingNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbOrderingNumber.Name = "lbOrderingNumber";
            this.lbOrderingNumber.Size = new System.Drawing.Size(117, 17);
            this.lbOrderingNumber.TabIndex = 12;
            this.lbOrderingNumber.Text = "[orderingnumber]";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBarcode,
            this.colItemName,
            this.colOrderingNumber,
            this.colSubCategory});
            this.dataGridView1.DataSource = this.bindingItemSearch;
            this.dataGridView1.Location = new System.Drawing.Point(13, 64);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(816, 500);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // colBarcode
            // 
            this.colBarcode.DataPropertyName = "Barcode";
            this.colBarcode.HeaderText = "Barcode";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.ReadOnly = true;
            // 
            // colItemName
            // 
            this.colItemName.DataPropertyName = "ItemName";
            this.colItemName.HeaderText = "ItemName";
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            this.colItemName.Width = 300;
            // 
            // colOrderingNumber
            // 
            this.colOrderingNumber.DataPropertyName = "OrderingNumber";
            this.colOrderingNumber.HeaderText = "OrderingNumber";
            this.colOrderingNumber.Name = "colOrderingNumber";
            this.colOrderingNumber.ReadOnly = true;
            // 
            // colSubCategory
            // 
            this.colSubCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSubCategory.DataPropertyName = "SubCategoryDesc";
            this.colSubCategory.HeaderText = "SubCategory";
            this.colSubCategory.Name = "colSubCategory";
            this.colSubCategory.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ItemID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ItemID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ItemName";
            this.dataGridViewTextBoxColumn2.HeaderText = "ItemName";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 300;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SubCategory";
            this.dataGridViewTextBoxColumn3.HeaderText = "SubCategory";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Barcode";
            this.dataGridViewTextBoxColumn4.HeaderText = "Barcode";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // bindingInactiveItems
            // 
            this.bindingInactiveItems.DataMember = "InactiveItem";
            this.bindingInactiveItems.DataSource = this.dsItem;
            // 
            // inactiveItemTableAdapter
            // 
            this.inactiveItemTableAdapter.ClearBeforeFill = true;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 617);
            this.Controls.Add(this.lbOrderingNumber);
            this.Controls.Add(this.txtOrderingNumber);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.btnLookupSubCategory);
            this.Controls.Add(this.btnOkFilter);
            this.Controls.Add(this.lbSubCategory);
            this.Controls.Add(this.lbItemName);
            this.Controls.Add(this.lbBarcode);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.txtSubCategory);
            this.Controls.Add(this.lbAmount);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SearchForm";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingItemSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingInactiveItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingItemSearch;
        private ItemDataSet dsItem;
        private RBOS.ItemDataSetTableAdapters.ItemSearchTableAdapter adapterItemSearch;
        private DRS.Extensions.DRS_DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbAmount;
        private System.Windows.Forms.TextBox txtSubCategory;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label lbBarcode;
        private System.Windows.Forms.Label lbItemName;
        private System.Windows.Forms.Label lbSubCategory;
        private System.Windows.Forms.Button btnOkFilter;
        private System.Windows.Forms.Button btnLookupSubCategory;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderingNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubCategory;
        private System.Windows.Forms.TextBox txtOrderingNumber;
        private System.Windows.Forms.Label lbOrderingNumber;
        private System.Windows.Forms.BindingSource bindingInactiveItems;
        private ItemDataSetTableAdapters.InactiveItemTableAdapter inactiveItemTableAdapter;
    }
}