namespace RBOS
{
    partial class BHHTWSDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BHHTWSDetail));
            this.gridWSCatList = new DRS.Extensions.DRS_DataGridView();
            this.colSelectSubCategory = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colSubCategoryDescription = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bindingLookupSubCategory = new System.Windows.Forms.BindingSource(this.components);
            this.dsItem = new RBOS.ItemDataSet();
            this.colSubCategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingRelCatList = new System.Windows.Forms.BindingSource(this.components);
            this.bindingWorksheetSingle = new System.Windows.Forms.BindingSource(this.components);
            this.gridWSItemList = new DRS.Extensions.DRS_DataGridView();
            this.colSelectItem = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bindingLookupItem = new System.Windows.Forms.BindingSource(this.components);
            this.colItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingRelItemList = new System.Windows.Forms.BindingSource(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.comboIncludeCode = new System.Windows.Forms.ComboBox();
            this.bindingLookupWSInclude = new System.Windows.Forms.BindingSource(this.components);
            this.lbIncludeCode = new System.Windows.Forms.Label();
            this.comboType = new System.Windows.Forms.ComboBox();
            this.bindingLookupWSType = new System.Windows.Forms.BindingSource(this.components);
            this.lbType = new System.Windows.Forms.Label();
            this.adapterLookupItem = new RBOS.ItemDataSetTableAdapters.LookupItemTableAdapter();
            this.adapterLookupSubCategory = new RBOS.ItemDataSetTableAdapters.LookupSubCategoryTableAdapter();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.adapterWorksheetSingle = new RBOS.ItemDataSetTableAdapters.BHHTWorksheetSingleTableAdapter();
            this.adapterRelItemList = new RBOS.ItemDataSetTableAdapters.BHHTWSItemListTableAdapter();
            this.adapterRelCatList = new RBOS.ItemDataSetTableAdapters.BHHTWSCatListTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbWSName = new System.Windows.Forms.Label();
            this.txtWSName = new System.Windows.Forms.TextBox();
            this.adapterLookupWSType = new RBOS.ItemDataSetTableAdapters.LookupWSTypeTableAdapter();
            this.adapterLookupWSInclude = new RBOS.ItemDataSetTableAdapters.LookupWSIncludeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gridWSCatList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupSubCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingRelCatList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingWorksheetSingle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridWSItemList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingRelItemList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupWSInclude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupWSType)).BeginInit();
            this.SuspendLayout();
            // 
            // gridWSCatList
            // 
            this.gridWSCatList.AllowUserToDeleteRows = false;
            this.gridWSCatList.AllowUserToResizeColumns = false;
            this.gridWSCatList.AllowUserToResizeRows = false;
            this.gridWSCatList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridWSCatList.AutoGenerateColumns = false;
            this.gridWSCatList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridWSCatList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridWSCatList.ColumnHeadersHeight = 21;
            this.gridWSCatList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridWSCatList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelectSubCategory,
            this.colSubCategoryDescription,
            this.colSubCategoryID});
            this.gridWSCatList.ContextMenuStrip = this.contextMenu;
            this.gridWSCatList.DataSource = this.bindingRelCatList;
            this.gridWSCatList.Location = new System.Drawing.Point(39, 164);
            this.gridWSCatList.Margin = new System.Windows.Forms.Padding(4);
            this.gridWSCatList.MultiSelect = false;
            this.gridWSCatList.Name = "gridWSCatList";
            this.gridWSCatList.RowHeadersWidth = 25;
            this.gridWSCatList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridWSCatList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridWSCatList.Size = new System.Drawing.Size(584, 257);
            this.gridWSCatList.TabIndex = 4;
            this.gridWSCatList.Visible = false;
            this.gridWSCatList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridWSCatList_CellContentClick);
            this.gridWSCatList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gridWSCatList_CellPainting);
            this.gridWSCatList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridWSCatList_KeyDown);
            // 
            // colSelectSubCategory
            // 
            this.colSelectSubCategory.HeaderText = "";
            this.colSelectSubCategory.Name = "colSelectSubCategory";
            this.colSelectSubCategory.Text = "...";
            this.colSelectSubCategory.Width = 25;
            // 
            // colSubCategoryDescription
            // 
            this.colSubCategoryDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSubCategoryDescription.DataPropertyName = "SubCategoryID";
            this.colSubCategoryDescription.DataSource = this.bindingLookupSubCategory;
            this.colSubCategoryDescription.DisplayMember = "Description";
            this.colSubCategoryDescription.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colSubCategoryDescription.HeaderText = "SubCategoryDescription";
            this.colSubCategoryDescription.Name = "colSubCategoryDescription";
            this.colSubCategoryDescription.ReadOnly = true;
            this.colSubCategoryDescription.ValueMember = "SubCategoryID";
            // 
            // bindingLookupSubCategory
            // 
            this.bindingLookupSubCategory.DataMember = "LookupSubCategory";
            this.bindingLookupSubCategory.DataSource = this.dsItem;
            // 
            // dsItem
            // 
            this.dsItem.DataSetName = "ItemDataSet";
            this.dsItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // colSubCategoryID
            // 
            this.colSubCategoryID.DataPropertyName = "SubCategoryID";
            this.colSubCategoryID.HeaderText = "SubCategoryID";
            this.colSubCategoryID.Name = "colSubCategoryID";
            this.colSubCategoryID.ReadOnly = true;
            // 
            // contextMenu
            // 
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(123, 28);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // bindingRelCatList
            // 
            this.bindingRelCatList.DataMember = "BHHTWorksheetSingle_BHHTWSCatList";
            this.bindingRelCatList.DataSource = this.bindingWorksheetSingle;
            // 
            // bindingWorksheetSingle
            // 
            this.bindingWorksheetSingle.DataMember = "BHHTWorksheetSingle";
            this.bindingWorksheetSingle.DataSource = this.dsItem;
            // 
            // gridWSItemList
            // 
            this.gridWSItemList.AllowUserToDeleteRows = false;
            this.gridWSItemList.AllowUserToResizeColumns = false;
            this.gridWSItemList.AllowUserToResizeRows = false;
            this.gridWSItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridWSItemList.AutoGenerateColumns = false;
            this.gridWSItemList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridWSItemList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridWSItemList.ColumnHeadersHeight = 21;
            this.gridWSItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridWSItemList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelectItem,
            this.colItemName,
            this.colItemID});
            this.gridWSItemList.ContextMenuStrip = this.contextMenu;
            this.gridWSItemList.DataSource = this.bindingRelItemList;
            this.gridWSItemList.Location = new System.Drawing.Point(16, 113);
            this.gridWSItemList.Margin = new System.Windows.Forms.Padding(4);
            this.gridWSItemList.MultiSelect = false;
            this.gridWSItemList.Name = "gridWSItemList";
            this.gridWSItemList.RowHeadersWidth = 25;
            this.gridWSItemList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridWSItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridWSItemList.Size = new System.Drawing.Size(636, 335);
            this.gridWSItemList.TabIndex = 3;
            this.gridWSItemList.Visible = false;
            this.gridWSItemList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridWSItemList_CellContentClick);
            this.gridWSItemList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gridWSItemList_CellPainting);
            this.gridWSItemList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridWSItemList_KeyDown);
            // 
            // colSelectItem
            // 
            this.colSelectItem.HeaderText = "";
            this.colSelectItem.Name = "colSelectItem";
            this.colSelectItem.Text = "...";
            this.colSelectItem.Width = 25;
            // 
            // colItemName
            // 
            this.colItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colItemName.DataPropertyName = "ItemID";
            this.colItemName.DataSource = this.bindingLookupItem;
            this.colItemName.DisplayMember = "ItemName";
            this.colItemName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colItemName.HeaderText = "ItemName";
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            this.colItemName.ValueMember = "ItemID";
            // 
            // bindingLookupItem
            // 
            this.bindingLookupItem.DataMember = "LookupItem";
            this.bindingLookupItem.DataSource = this.dsItem;
            // 
            // colItemID
            // 
            this.colItemID.DataPropertyName = "ItemID";
            this.colItemID.HeaderText = "ItemID";
            this.colItemID.Name = "colItemID";
            this.colItemID.ReadOnly = true;
            // 
            // bindingRelItemList
            // 
            this.bindingRelItemList.DataMember = "BHHTWorksheetSingle_BHHTWSItemList";
            this.bindingRelItemList.DataSource = this.bindingWorksheetSingle;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(552, 455);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "[Cancel]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // comboIncludeCode
            // 
            this.comboIncludeCode.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingWorksheetSingle, "Include", true));
            this.comboIncludeCode.DataSource = this.bindingLookupWSInclude;
            this.comboIncludeCode.DisplayMember = "Description";
            this.comboIncludeCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboIncludeCode.FormattingEnabled = true;
            this.comboIncludeCode.Location = new System.Drawing.Point(164, 80);
            this.comboIncludeCode.Margin = new System.Windows.Forms.Padding(4);
            this.comboIncludeCode.Name = "comboIncludeCode";
            this.comboIncludeCode.Size = new System.Drawing.Size(160, 24);
            this.comboIncludeCode.TabIndex = 2;
            this.comboIncludeCode.ValueMember = "ID";
            this.comboIncludeCode.SelectedIndexChanged += new System.EventHandler(this.comboIncludeCode_SelectedIndexChanged);
            // 
            // bindingLookupWSInclude
            // 
            this.bindingLookupWSInclude.DataMember = "LookupWSInclude";
            this.bindingLookupWSInclude.DataSource = this.dsItem;
            // 
            // lbIncludeCode
            // 
            this.lbIncludeCode.AutoSize = true;
            this.lbIncludeCode.Location = new System.Drawing.Point(16, 84);
            this.lbIncludeCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbIncludeCode.Name = "lbIncludeCode";
            this.lbIncludeCode.Size = new System.Drawing.Size(98, 17);
            this.lbIncludeCode.TabIndex = 3;
            this.lbIncludeCode.Text = "[Include Code]";
            // 
            // comboType
            // 
            this.comboType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingWorksheetSingle, "Type", true));
            this.comboType.DataSource = this.bindingLookupWSType;
            this.comboType.DisplayMember = "Description";
            this.comboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboType.FormattingEnabled = true;
            this.comboType.Location = new System.Drawing.Point(164, 47);
            this.comboType.Margin = new System.Windows.Forms.Padding(4);
            this.comboType.Name = "comboType";
            this.comboType.Size = new System.Drawing.Size(160, 24);
            this.comboType.TabIndex = 1;
            this.comboType.ValueMember = "ID";
            // 
            // bindingLookupWSType
            // 
            this.bindingLookupWSType.DataMember = "LookupWSType";
            this.bindingLookupWSType.DataSource = this.dsItem;
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Location = new System.Drawing.Point(16, 50);
            this.lbType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(48, 17);
            this.lbType.TabIndex = 5;
            this.lbType.Text = "[Type]";
            // 
            // adapterLookupItem
            // 
            this.adapterLookupItem.ClearBeforeFill = true;
            // 
            // adapterLookupSubCategory
            // 
            this.adapterLookupSubCategory.ClearBeforeFill = true;
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveClose.Location = new System.Drawing.Point(393, 455);
            this.btnSaveClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(151, 28);
            this.btnSaveClose.TabIndex = 5;
            this.btnSaveClose.Text = "[Save and Close]";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // adapterWorksheetSingle
            // 
            this.adapterWorksheetSingle.ClearBeforeFill = true;
            // 
            // adapterRelItemList
            // 
            this.adapterRelItemList.ClearBeforeFill = true;
            // 
            // adapterRelCatList
            // 
            this.adapterRelCatList.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "WSID";
            this.dataGridViewTextBoxColumn2.HeaderText = "WSID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SubCategoryID";
            this.dataGridViewTextBoxColumn3.HeaderText = "SubCategoryID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn4.HeaderText = "ID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "WSID";
            this.dataGridViewTextBoxColumn5.HeaderText = "WSID";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ItemID";
            this.dataGridViewTextBoxColumn6.HeaderText = "ItemID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // lbWSName
            // 
            this.lbWSName.AutoSize = true;
            this.lbWSName.Location = new System.Drawing.Point(16, 18);
            this.lbWSName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbWSName.Name = "lbWSName";
            this.lbWSName.Size = new System.Drawing.Size(125, 17);
            this.lbWSName.TabIndex = 7;
            this.lbWSName.Text = "[Worksheet Name]";
            // 
            // txtWSName
            // 
            this.txtWSName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingWorksheetSingle, "Name", true));
            this.txtWSName.Location = new System.Drawing.Point(164, 15);
            this.txtWSName.Margin = new System.Windows.Forms.Padding(4);
            this.txtWSName.Name = "txtWSName";
            this.txtWSName.Size = new System.Drawing.Size(321, 22);
            this.txtWSName.TabIndex = 0;
            // 
            // adapterLookupWSType
            // 
            this.adapterLookupWSType.ClearBeforeFill = true;
            // 
            // adapterLookupWSInclude
            // 
            this.adapterLookupWSInclude.ClearBeforeFill = true;
            // 
            // BHHTWSDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 498);
            this.Controls.Add(this.txtWSName);
            this.Controls.Add(this.lbWSName);
            this.Controls.Add(this.gridWSCatList);
            this.Controls.Add(this.btnSaveClose);
            this.Controls.Add(this.gridWSItemList);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lbType);
            this.Controls.Add(this.comboIncludeCode);
            this.Controls.Add(this.comboType);
            this.Controls.Add(this.lbIncludeCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "BHHTWSDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BHHTWSDetail";
            this.Load += new System.EventHandler(this.BHHTWSDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridWSCatList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupSubCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingRelCatList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingWorksheetSingle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridWSItemList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingRelItemList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupWSInclude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupWSType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private DRS.Extensions.DRS_DataGridView gridWSCatList;
        private ItemDataSet dsItem;
        private DRS.Extensions.DRS_DataGridView gridWSItemList;
        private System.Windows.Forms.ComboBox comboIncludeCode;
        private System.Windows.Forms.Label lbIncludeCode;
        private System.Windows.Forms.ComboBox comboType;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.BindingSource bindingLookupItem;
        private RBOS.ItemDataSetTableAdapters.LookupItemTableAdapter adapterLookupItem;
        private System.Windows.Forms.BindingSource bindingLookupSubCategory;
        private RBOS.ItemDataSetTableAdapters.LookupSubCategoryTableAdapter adapterLookupSubCategory;
        private System.Windows.Forms.Button btnSaveClose;
        private System.Windows.Forms.BindingSource bindingRelCatList;
        private System.Windows.Forms.BindingSource bindingWorksheetSingle;
        private System.Windows.Forms.BindingSource bindingRelItemList;
        private RBOS.ItemDataSetTableAdapters.BHHTWorksheetSingleTableAdapter adapterWorksheetSingle;
        private RBOS.ItemDataSetTableAdapters.BHHTWSItemListTableAdapter adapterRelItemList;
        private RBOS.ItemDataSetTableAdapters.BHHTWSCatListTableAdapter adapterRelCatList;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Label lbWSName;
        private System.Windows.Forms.TextBox txtWSName;
        private System.Windows.Forms.BindingSource bindingLookupWSType;
        private RBOS.ItemDataSetTableAdapters.LookupWSTypeTableAdapter adapterLookupWSType;
        private System.Windows.Forms.BindingSource bindingLookupWSInclude;
        private RBOS.ItemDataSetTableAdapters.LookupWSIncludeTableAdapter adapterLookupWSInclude;
        private System.Windows.Forms.DataGridViewButtonColumn colSelectSubCategory;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSubCategoryDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubCategoryID;
        private System.Windows.Forms.DataGridViewButtonColumn colSelectItem;
        private System.Windows.Forms.DataGridViewComboBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemID;
    }
}