namespace RBOS
{
    partial class WasteSheetDetailsLocal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WasteSheetDetailsLocal));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.bindingWasteSheetHeaderLocal = new System.Windows.Forms.BindingSource(this.components);
            this.dsItem = new RBOS.ItemDataSet();
            this.bindingWasteSheetDetailsLocal = new System.Windows.Forms.BindingSource(this.components);
            this.adapterwasteSheetDetailsLocal = new RBOS.ItemDataSetTableAdapters.WasteSheetDetailsLocalTableAdapter();
            this.adapterwasteSheetHeaderLocal = new RBOS.ItemDataSetTableAdapters.WasteSheetHeaderLocalTableAdapter();
            this.bindingwasteSheetDetailsLocalLookups = new System.Windows.Forms.BindingSource(this.components);
            this.adapterwasteSheetDetailsLocalLookups = new RBOS.ItemDataSetTableAdapters.WasteSheetDetailsLocalLookupsTableAdapter();
            this.grid = new DRS.Extensions.DRS_DataGridView();
            this.colItemName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colLookupItemButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colbarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackTypeName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colCostPriceLatest = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colSalesPrice = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingWasteSheetHeaderLocal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingWasteSheetDetailsLocal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingwasteSheetDetailsLocalLookups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(601, 426);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "[Annuller]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndClose.Location = new System.Drawing.Point(453, 426);
            this.btnSaveAndClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(140, 28);
            this.btnSaveAndClose.TabIndex = 1;
            this.btnSaveAndClose.Text = "[Gem og luk]";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(16, 18);
            this.lbName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(47, 16);
            this.lbName.TabIndex = 2;
            this.lbName.Text = "[Navn]";
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingWasteSheetHeaderLocal, "Name", true));
            this.txtName.Location = new System.Drawing.Point(93, 14);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(278, 22);
            this.txtName.TabIndex = 3;
            // 
            // bindingWasteSheetHeaderLocal
            // 
            this.bindingWasteSheetHeaderLocal.DataMember = "WasteSheetHeaderLocal";
            this.bindingWasteSheetHeaderLocal.DataSource = this.dsItem;
            // 
            // dsItem
            // 
            this.dsItem.DataSetName = "ItemDataSet";
            this.dsItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingWasteSheetDetailsLocal
            // 
            this.bindingWasteSheetDetailsLocal.DataMember = "WasteSheetDetailsLocal";
            this.bindingWasteSheetDetailsLocal.DataSource = this.dsItem;
            // 
            // adapterwasteSheetDetailsLocal
            // 
            this.adapterwasteSheetDetailsLocal.ClearBeforeFill = true;
            // 
            // adapterwasteSheetHeaderLocal
            // 
            this.adapterwasteSheetHeaderLocal.ClearBeforeFill = true;
            // 
            // bindingwasteSheetDetailsLocalLookups
            // 
            this.bindingwasteSheetDetailsLocalLookups.DataMember = "WasteSheetDetailsLocalLookups";
            this.bindingwasteSheetDetailsLocalLookups.DataSource = this.dsItem;
            // 
            // adapterwasteSheetDetailsLocalLookups
            // 
            this.adapterwasteSheetDetailsLocalLookups.ClearBeforeFill = true;
            // 
            // grid
            // 
            this.grid.AllowUserToResizeColumns = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.AutoGenerateColumns = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItemName,
            this.colLookupItemButton,
            this.colbarcode,
            this.colPackTypeName,
            this.colCostPriceLatest,
            this.colSalesPrice});
            this.grid.DataSource = this.bindingWasteSheetDetailsLocal;
            this.grid.Location = new System.Drawing.Point(20, 46);
            this.grid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.RowHeadersWidth = 25;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(685, 372);
            this.grid.TabIndex = 4;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            this.grid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grid_CellPainting);
            // 
            // colItemName
            // 
            this.colItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colItemName.DataPropertyName = "Barcode";
            this.colItemName.DataSource = this.bindingwasteSheetDetailsLocalLookups;
            this.colItemName.DisplayMember = "ItemName";
            this.colItemName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colItemName.HeaderText = "ItemName";
            this.colItemName.MinimumWidth = 8;
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            this.colItemName.ValueMember = "Barcode";
            // 
            // colLookupItemButton
            // 
            this.colLookupItemButton.HeaderText = "";
            this.colLookupItemButton.MinimumWidth = 8;
            this.colLookupItemButton.Name = "colLookupItemButton";
            this.colLookupItemButton.Width = 25;
            // 
            // colbarcode
            // 
            this.colbarcode.DataPropertyName = "Barcode";
            this.colbarcode.HeaderText = "Barcode";
            this.colbarcode.MinimumWidth = 8;
            this.colbarcode.Name = "colbarcode";
            this.colbarcode.Width = 150;
            // 
            // colPackTypeName
            // 
            this.colPackTypeName.DataPropertyName = "Barcode";
            this.colPackTypeName.DataSource = this.bindingwasteSheetDetailsLocalLookups;
            this.colPackTypeName.DisplayMember = "PackTypeName";
            this.colPackTypeName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colPackTypeName.HeaderText = "PackType";
            this.colPackTypeName.MinimumWidth = 8;
            this.colPackTypeName.Name = "colPackTypeName";
            this.colPackTypeName.ReadOnly = true;
            this.colPackTypeName.ValueMember = "Barcode";
            this.colPackTypeName.Width = 70;
            // 
            // colCostPriceLatest
            // 
            this.colCostPriceLatest.DataPropertyName = "Barcode";
            this.colCostPriceLatest.DataSource = this.bindingwasteSheetDetailsLocalLookups;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N3";
            dataGridViewCellStyle1.NullValue = null;
            this.colCostPriceLatest.DefaultCellStyle = dataGridViewCellStyle1;
            this.colCostPriceLatest.DisplayMember = "CostPriceLatest";
            this.colCostPriceLatest.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colCostPriceLatest.HeaderText = "CostPrice";
            this.colCostPriceLatest.MinimumWidth = 8;
            this.colCostPriceLatest.Name = "colCostPriceLatest";
            this.colCostPriceLatest.ReadOnly = true;
            this.colCostPriceLatest.ValueMember = "Barcode";
            this.colCostPriceLatest.Width = 70;
            // 
            // colSalesPrice
            // 
            this.colSalesPrice.DataPropertyName = "Barcode";
            this.colSalesPrice.DataSource = this.bindingwasteSheetDetailsLocalLookups;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.colSalesPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.colSalesPrice.DisplayMember = "SalesPrice";
            this.colSalesPrice.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colSalesPrice.HeaderText = "SalesPrice";
            this.colSalesPrice.MinimumWidth = 8;
            this.colSalesPrice.Name = "colSalesPrice";
            this.colSalesPrice.ReadOnly = true;
            this.colSalesPrice.ValueMember = "Barcode";
            this.colSalesPrice.Width = 70;
            // 
            // WasteSheetDetailsLocal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 469);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "WasteSheetDetailsLocal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WasteSheetDetails";
            this.Load += new System.EventHandler(this.WasteSheetDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingWasteSheetHeaderLocal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingWasteSheetDetailsLocal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingwasteSheetDetailsLocalLookups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox txtName;
        private DRS.Extensions.DRS_DataGridView grid;
        private ItemDataSet dsItem;
        private ItemDataSetTableAdapters.WasteSheetDetailsLocalTableAdapter adapterwasteSheetDetailsLocal;
        private System.Windows.Forms.BindingSource bindingWasteSheetDetailsLocal;
        private ItemDataSetTableAdapters.WasteSheetHeaderLocalTableAdapter adapterwasteSheetHeaderLocal;
        private System.Windows.Forms.BindingSource bindingWasteSheetHeaderLocal;
        private System.Windows.Forms.BindingSource bindingwasteSheetDetailsLocalLookups;
        private ItemDataSetTableAdapters.WasteSheetDetailsLocalLookupsTableAdapter adapterwasteSheetDetailsLocalLookups;
        private System.Windows.Forms.DataGridViewComboBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewButtonColumn colLookupItemButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn colbarcode;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPackTypeName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCostPriceLatest;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSalesPrice;
    }
}