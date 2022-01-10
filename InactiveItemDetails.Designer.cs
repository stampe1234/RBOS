namespace RBOS
{
    partial class InactiveItemDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InactiveItemDetails));
            this.groupItem = new System.Windows.Forms.GroupBox();
            this.txtBugetMargin = new System.Windows.Forms.Label();
            this.BudgetMarginTextBox = new System.Windows.Forms.TextBox();
            this.bindinInactiveItemSingle = new System.Windows.Forms.BindingSource(this.components);
            this.dsItem = new RBOS.ItemDataSet();
            this.txtItemName = new System.Windows.Forms.Label();
            this.itemNameTextBox = new System.Windows.Forms.TextBox();
            this.txtVatRate = new System.Windows.Forms.Label();
            this.VatRateTextBox = new System.Windows.Forms.TextBox();
            this.subCategoryDescTextBox = new System.Windows.Forms.TextBox();
            this.txtMargin = new System.Windows.Forms.Label();
            this.marginTextBox = new System.Windows.Forms.TextBox();
            this.txtLatestCostPrice = new System.Windows.Forms.Label();
            this.costPriceLatestTextBox = new System.Windows.Forms.TextBox();
            this.txtSalesPrice = new System.Windows.Forms.Label();
            this.pOSSalesPriceTextBox = new System.Windows.Forms.TextBox();
            this.txtSubCategory = new System.Windows.Forms.Label();
            this.subCategoryTextBox = new System.Windows.Forms.TextBox();
            this.groupSalesPack = new System.Windows.Forms.GroupBox();
            this.bindingInactiveSalesPack = new System.Windows.Forms.BindingSource(this.components);
            this.groupBarcode = new System.Windows.Forms.GroupBox();
            this.bindingInactiveBarcode = new System.Windows.Forms.BindingSource(this.components);
            this.groupSupplierItem = new System.Windows.Forms.GroupBox();
            this.bindingInactiveSupplierItem = new System.Windows.Forms.BindingSource(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.adapterInactiveSupplierItem = new RBOS.ItemDataSetTableAdapters.InactiveSupplierItemTableAdapter();
            this.adapterInactiveSalesPack = new RBOS.ItemDataSetTableAdapters.InactiveSalesPackTableAdapter();
            this.adapterInactiveBarcode = new RBOS.ItemDataSetTableAdapters.InactiveBarcodeTableAdapter();
            this.adapterInactiveItemSingle = new RBOS.ItemDataSetTableAdapters.InactiveItemSingleTableAdapter();
            this.txtInactivateDateTime = new System.Windows.Forms.Label();
            this.inactivateDateTimeTextBox = new System.Windows.Forms.TextBox();
            this.drS_DataGridView1 = new DRS.Extensions.DRS_DataGridView();
            this.colSupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplierNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderingNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsPrimary_supplieritem = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colKolliSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackageCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackageUnitCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSellingPackType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNoOfSellingUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSellingUnitCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drS_DataGridView3 = new DRS.Extensions.DRS_DataGridView();
            this.colBarcodeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarcode_barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsPrimary_barcode = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.drS_DataGridView2 = new DRS.Extensions.DRS_DataGridView();
            this.colPackTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceiptText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalesPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsPrimary = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindinInactiveItemSingle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
            this.groupSalesPack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingInactiveSalesPack)).BeginInit();
            this.groupBarcode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingInactiveBarcode)).BeginInit();
            this.groupSupplierItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingInactiveSupplierItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drS_DataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drS_DataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drS_DataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupItem
            // 
            this.groupItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupItem.Controls.Add(this.txtInactivateDateTime);
            this.groupItem.Controls.Add(this.inactivateDateTimeTextBox);
            this.groupItem.Controls.Add(this.txtBugetMargin);
            this.groupItem.Controls.Add(this.BudgetMarginTextBox);
            this.groupItem.Controls.Add(this.txtItemName);
            this.groupItem.Controls.Add(this.itemNameTextBox);
            this.groupItem.Controls.Add(this.txtVatRate);
            this.groupItem.Controls.Add(this.VatRateTextBox);
            this.groupItem.Controls.Add(this.subCategoryDescTextBox);
            this.groupItem.Controls.Add(this.txtMargin);
            this.groupItem.Controls.Add(this.marginTextBox);
            this.groupItem.Controls.Add(this.txtLatestCostPrice);
            this.groupItem.Controls.Add(this.costPriceLatestTextBox);
            this.groupItem.Controls.Add(this.txtSalesPrice);
            this.groupItem.Controls.Add(this.pOSSalesPriceTextBox);
            this.groupItem.Controls.Add(this.txtSubCategory);
            this.groupItem.Controls.Add(this.subCategoryTextBox);
            this.groupItem.Location = new System.Drawing.Point(12, 12);
            this.groupItem.Name = "groupItem";
            this.groupItem.Size = new System.Drawing.Size(691, 164);
            this.groupItem.TabIndex = 1;
            this.groupItem.TabStop = false;
            this.groupItem.Text = "[Vare]";
            // 
            // txtBugetMargin
            // 
            this.txtBugetMargin.AutoSize = true;
            this.txtBugetMargin.Location = new System.Drawing.Point(179, 74);
            this.txtBugetMargin.Name = "txtBugetMargin";
            this.txtBugetMargin.Size = new System.Drawing.Size(66, 13);
            this.txtBugetMargin.TabIndex = 14;
            this.txtBugetMargin.Text = "[Budget DG]";
            // 
            // BudgetMarginTextBox
            // 
            this.BudgetMarginTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindinInactiveItemSingle, "BudgetMargin", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.BudgetMarginTextBox.Location = new System.Drawing.Point(300, 71);
            this.BudgetMarginTextBox.Name = "BudgetMarginTextBox";
            this.BudgetMarginTextBox.ReadOnly = true;
            this.BudgetMarginTextBox.Size = new System.Drawing.Size(53, 20);
            this.BudgetMarginTextBox.TabIndex = 6;
            this.BudgetMarginTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bindinInactiveItemSingle
            // 
            this.bindinInactiveItemSingle.DataMember = "InactiveItemSingle";
            this.bindinInactiveItemSingle.DataSource = this.dsItem;
            // 
            // dsItem
            // 
            this.dsItem.DataSetName = "ItemDataSet";
            this.dsItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtItemName
            // 
            this.txtItemName.AutoSize = true;
            this.txtItemName.Location = new System.Drawing.Point(6, 22);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(59, 13);
            this.txtItemName.TabIndex = 13;
            this.txtItemName.Text = "[Varenavn]";
            // 
            // itemNameTextBox
            // 
            this.itemNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindinInactiveItemSingle, "ItemName", true));
            this.itemNameTextBox.Location = new System.Drawing.Point(108, 19);
            this.itemNameTextBox.Name = "itemNameTextBox";
            this.itemNameTextBox.ReadOnly = true;
            this.itemNameTextBox.Size = new System.Drawing.Size(256, 20);
            this.itemNameTextBox.TabIndex = 0;
            // 
            // txtVatRate
            // 
            this.txtVatRate.AutoSize = true;
            this.txtVatRate.Location = new System.Drawing.Point(179, 100);
            this.txtVatRate.Name = "txtVatRate";
            this.txtVatRate.Size = new System.Drawing.Size(77, 13);
            this.txtVatRate.TabIndex = 12;
            this.txtVatRate.Text = "[Momsprocent]";
            // 
            // VatRateTextBox
            // 
            this.VatRateTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindinInactiveItemSingle, "VatRate", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.VatRateTextBox.Location = new System.Drawing.Point(300, 97);
            this.VatRateTextBox.Name = "VatRateTextBox";
            this.VatRateTextBox.ReadOnly = true;
            this.VatRateTextBox.Size = new System.Drawing.Size(53, 20);
            this.VatRateTextBox.TabIndex = 7;
            this.VatRateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // subCategoryDescTextBox
            // 
            this.subCategoryDescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindinInactiveItemSingle, "SubCategoryDesc", true));
            this.subCategoryDescTextBox.Location = new System.Drawing.Point(193, 45);
            this.subCategoryDescTextBox.Name = "subCategoryDescTextBox";
            this.subCategoryDescTextBox.ReadOnly = true;
            this.subCategoryDescTextBox.Size = new System.Drawing.Size(171, 20);
            this.subCategoryDescTextBox.TabIndex = 2;
            // 
            // txtMargin
            // 
            this.txtMargin.AutoSize = true;
            this.txtMargin.Location = new System.Drawing.Point(6, 126);
            this.txtMargin.Name = "txtMargin";
            this.txtMargin.Size = new System.Drawing.Size(83, 13);
            this.txtMargin.TabIndex = 8;
            this.txtMargin.Text = "[Dækningsgrad]";
            // 
            // marginTextBox
            // 
            this.marginTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindinInactiveItemSingle, "Margin", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.marginTextBox.Location = new System.Drawing.Point(108, 123);
            this.marginTextBox.Name = "marginTextBox";
            this.marginTextBox.ReadOnly = true;
            this.marginTextBox.Size = new System.Drawing.Size(53, 20);
            this.marginTextBox.TabIndex = 5;
            this.marginTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLatestCostPrice
            // 
            this.txtLatestCostPrice.AutoSize = true;
            this.txtLatestCostPrice.Location = new System.Drawing.Point(6, 100);
            this.txtLatestCostPrice.Name = "txtLatestCostPrice";
            this.txtLatestCostPrice.Size = new System.Drawing.Size(81, 13);
            this.txtLatestCostPrice.TabIndex = 6;
            this.txtLatestCostPrice.Text = "[Sidste kostpris]";
            // 
            // costPriceLatestTextBox
            // 
            this.costPriceLatestTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindinInactiveItemSingle, "CostPriceLatest", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N3"));
            this.costPriceLatestTextBox.Location = new System.Drawing.Point(108, 97);
            this.costPriceLatestTextBox.Name = "costPriceLatestTextBox";
            this.costPriceLatestTextBox.ReadOnly = true;
            this.costPriceLatestTextBox.Size = new System.Drawing.Size(53, 20);
            this.costPriceLatestTextBox.TabIndex = 4;
            this.costPriceLatestTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSalesPrice
            // 
            this.txtSalesPrice.AutoSize = true;
            this.txtSalesPrice.Location = new System.Drawing.Point(6, 74);
            this.txtSalesPrice.Name = "txtSalesPrice";
            this.txtSalesPrice.Size = new System.Drawing.Size(55, 13);
            this.txtSalesPrice.TabIndex = 4;
            this.txtSalesPrice.Text = "[Salgspris]";
            // 
            // pOSSalesPriceTextBox
            // 
            this.pOSSalesPriceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindinInactiveItemSingle, "POSSalesPrice", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.pOSSalesPriceTextBox.Location = new System.Drawing.Point(108, 71);
            this.pOSSalesPriceTextBox.Name = "pOSSalesPriceTextBox";
            this.pOSSalesPriceTextBox.ReadOnly = true;
            this.pOSSalesPriceTextBox.Size = new System.Drawing.Size(53, 20);
            this.pOSSalesPriceTextBox.TabIndex = 3;
            this.pOSSalesPriceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSubCategory
            // 
            this.txtSubCategory.AutoSize = true;
            this.txtSubCategory.Location = new System.Drawing.Point(6, 48);
            this.txtSubCategory.Name = "txtSubCategory";
            this.txtSubCategory.Size = new System.Drawing.Size(68, 13);
            this.txtSubCategory.TabIndex = 2;
            this.txtSubCategory.Text = "[Varegruppe]";
            // 
            // subCategoryTextBox
            // 
            this.subCategoryTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindinInactiveItemSingle, "SubCategory", true));
            this.subCategoryTextBox.Location = new System.Drawing.Point(108, 45);
            this.subCategoryTextBox.Name = "subCategoryTextBox";
            this.subCategoryTextBox.ReadOnly = true;
            this.subCategoryTextBox.Size = new System.Drawing.Size(79, 20);
            this.subCategoryTextBox.TabIndex = 1;
            // 
            // groupSalesPack
            // 
            this.groupSalesPack.Controls.Add(this.drS_DataGridView2);
            this.groupSalesPack.Location = new System.Drawing.Point(12, 182);
            this.groupSalesPack.Name = "groupSalesPack";
            this.groupSalesPack.Size = new System.Drawing.Size(383, 117);
            this.groupSalesPack.TabIndex = 2;
            this.groupSalesPack.TabStop = false;
            this.groupSalesPack.Text = "[Salgspakninger]";
            // 
            // bindingInactiveSalesPack
            // 
            this.bindingInactiveSalesPack.DataMember = "InactiveSalesPack";
            this.bindingInactiveSalesPack.DataSource = this.dsItem;
            this.bindingInactiveSalesPack.PositionChanged += new System.EventHandler(this.bindingInactiveSalesPack_PositionChanged);
            // 
            // groupBarcode
            // 
            this.groupBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBarcode.Controls.Add(this.drS_DataGridView3);
            this.groupBarcode.Location = new System.Drawing.Point(401, 182);
            this.groupBarcode.Name = "groupBarcode";
            this.groupBarcode.Size = new System.Drawing.Size(302, 117);
            this.groupBarcode.TabIndex = 3;
            this.groupBarcode.TabStop = false;
            this.groupBarcode.Text = "[Barcoder]";
            // 
            // bindingInactiveBarcode
            // 
            this.bindingInactiveBarcode.DataMember = "InactiveBarcode";
            this.bindingInactiveBarcode.DataSource = this.dsItem;
            // 
            // groupSupplierItem
            // 
            this.groupSupplierItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupSupplierItem.Controls.Add(this.drS_DataGridView1);
            this.groupSupplierItem.Location = new System.Drawing.Point(12, 305);
            this.groupSupplierItem.Name = "groupSupplierItem";
            this.groupSupplierItem.Size = new System.Drawing.Size(691, 132);
            this.groupSupplierItem.TabIndex = 4;
            this.groupSupplierItem.TabStop = false;
            this.groupSupplierItem.Text = "Bestillingsnumre";
            // 
            // bindingInactiveSupplierItem
            // 
            this.bindingInactiveSupplierItem.DataMember = "InactiveSupplierItem";
            this.bindingInactiveSupplierItem.DataSource = this.dsItem;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(628, 443);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // adapterInactiveSupplierItem
            // 
            this.adapterInactiveSupplierItem.ClearBeforeFill = true;
            // 
            // adapterInactiveSalesPack
            // 
            this.adapterInactiveSalesPack.ClearBeforeFill = true;
            // 
            // adapterInactiveBarcode
            // 
            this.adapterInactiveBarcode.ClearBeforeFill = true;
            // 
            // adapterInactiveItemSingle
            // 
            this.adapterInactiveItemSingle.ClearBeforeFill = true;
            // 
            // txtInactivateDateTime
            // 
            this.txtInactivateDateTime.AutoSize = true;
            this.txtInactivateDateTime.Location = new System.Drawing.Point(179, 126);
            this.txtInactivateDateTime.Name = "txtInactivateDateTime";
            this.txtInactivateDateTime.Size = new System.Drawing.Size(108, 13);
            this.txtInactivateDateTime.TabIndex = 15;
            this.txtInactivateDateTime.Text = "[Dato for inaktivering]";
            // 
            // inactivateDateTimeTextBox
            // 
            this.inactivateDateTimeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindinInactiveItemSingle, "InactivateDateTime", true));
            this.inactivateDateTimeTextBox.Location = new System.Drawing.Point(300, 123);
            this.inactivateDateTimeTextBox.Name = "inactivateDateTimeTextBox";
            this.inactivateDateTimeTextBox.ReadOnly = true;
            this.inactivateDateTimeTextBox.Size = new System.Drawing.Size(93, 20);
            this.inactivateDateTimeTextBox.TabIndex = 16;
            // 
            // drS_DataGridView1
            // 
            this.drS_DataGridView1.AllowUserToAddRows = false;
            this.drS_DataGridView1.AllowUserToDeleteRows = false;
            this.drS_DataGridView1.AllowUserToResizeColumns = false;
            this.drS_DataGridView1.AllowUserToResizeRows = false;
            this.drS_DataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.drS_DataGridView1.AutoGenerateColumns = false;
            this.drS_DataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.drS_DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.drS_DataGridView1.ColumnHeadersHeight = 21;
            this.drS_DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.drS_DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSupplierName,
            this.colSupplierNo,
            this.colOrderingNumber,
            this.colIsPrimary_supplieritem,
            this.colKolliSize,
            this.colPackageCost,
            this.colPackageUnitCost,
            this.colSellingPackType,
            this.colNoOfSellingUnits,
            this.colSellingUnitCost});
            this.drS_DataGridView1.DataSource = this.bindingInactiveSupplierItem;
            this.drS_DataGridView1.Location = new System.Drawing.Point(6, 19);
            this.drS_DataGridView1.MultiSelect = false;
            this.drS_DataGridView1.Name = "drS_DataGridView1";
            this.drS_DataGridView1.ReadOnly = true;
            this.drS_DataGridView1.RowHeadersVisible = false;
            this.drS_DataGridView1.RowHeadersWidth = 25;
            this.drS_DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.drS_DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.drS_DataGridView1.Size = new System.Drawing.Size(679, 107);
            this.drS_DataGridView1.TabIndex = 0;
            // 
            // colSupplierName
            // 
            this.colSupplierName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSupplierName.DataPropertyName = "SupplierName";
            this.colSupplierName.HeaderText = "SupplierName";
            this.colSupplierName.Name = "colSupplierName";
            this.colSupplierName.ReadOnly = true;
            // 
            // colSupplierNo
            // 
            this.colSupplierNo.DataPropertyName = "SupplierNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colSupplierNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.colSupplierNo.HeaderText = "SupplierNo";
            this.colSupplierNo.Name = "colSupplierNo";
            this.colSupplierNo.ReadOnly = true;
            this.colSupplierNo.Width = 40;
            // 
            // colOrderingNumber
            // 
            this.colOrderingNumber.DataPropertyName = "OrderingNumber";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colOrderingNumber.DefaultCellStyle = dataGridViewCellStyle3;
            this.colOrderingNumber.HeaderText = "OrderingNumber";
            this.colOrderingNumber.Name = "colOrderingNumber";
            this.colOrderingNumber.ReadOnly = true;
            this.colOrderingNumber.Width = 80;
            // 
            // colIsPrimary_supplieritem
            // 
            this.colIsPrimary_supplieritem.DataPropertyName = "IsPrimary";
            this.colIsPrimary_supplieritem.HeaderText = "IsPrimary";
            this.colIsPrimary_supplieritem.Name = "colIsPrimary_supplieritem";
            this.colIsPrimary_supplieritem.ReadOnly = true;
            this.colIsPrimary_supplieritem.Width = 30;
            // 
            // colKolliSize
            // 
            this.colKolliSize.DataPropertyName = "KolliSize";
            this.colKolliSize.HeaderText = "KolliSize";
            this.colKolliSize.Name = "colKolliSize";
            this.colKolliSize.ReadOnly = true;
            this.colKolliSize.Width = 60;
            // 
            // colPackageCost
            // 
            this.colPackageCost.DataPropertyName = "PackageCost";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N3";
            dataGridViewCellStyle4.NullValue = null;
            this.colPackageCost.DefaultCellStyle = dataGridViewCellStyle4;
            this.colPackageCost.HeaderText = "PackageCost";
            this.colPackageCost.Name = "colPackageCost";
            this.colPackageCost.ReadOnly = true;
            this.colPackageCost.Width = 60;
            // 
            // colPackageUnitCost
            // 
            this.colPackageUnitCost.DataPropertyName = "PackageUnitCost";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N3";
            dataGridViewCellStyle5.NullValue = null;
            this.colPackageUnitCost.DefaultCellStyle = dataGridViewCellStyle5;
            this.colPackageUnitCost.HeaderText = "PackageUnitCost";
            this.colPackageUnitCost.Name = "colPackageUnitCost";
            this.colPackageUnitCost.ReadOnly = true;
            this.colPackageUnitCost.Width = 60;
            // 
            // colSellingPackType
            // 
            this.colSellingPackType.DataPropertyName = "SellingPackType";
            this.colSellingPackType.HeaderText = "SellingPackType";
            this.colSellingPackType.Name = "colSellingPackType";
            this.colSellingPackType.ReadOnly = true;
            this.colSellingPackType.Width = 50;
            // 
            // colNoOfSellingUnits
            // 
            this.colNoOfSellingUnits.DataPropertyName = "NoOfSellingUnits";
            this.colNoOfSellingUnits.HeaderText = "NoOfSellingUnits";
            this.colNoOfSellingUnits.Name = "colNoOfSellingUnits";
            this.colNoOfSellingUnits.ReadOnly = true;
            this.colNoOfSellingUnits.Width = 50;
            // 
            // colSellingUnitCost
            // 
            this.colSellingUnitCost.DataPropertyName = "SellingUnitCost";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N3";
            dataGridViewCellStyle6.NullValue = null;
            this.colSellingUnitCost.DefaultCellStyle = dataGridViewCellStyle6;
            this.colSellingUnitCost.HeaderText = "SellingUnitCost";
            this.colSellingUnitCost.Name = "colSellingUnitCost";
            this.colSellingUnitCost.ReadOnly = true;
            this.colSellingUnitCost.Width = 60;
            // 
            // drS_DataGridView3
            // 
            this.drS_DataGridView3.AllowUserToAddRows = false;
            this.drS_DataGridView3.AllowUserToDeleteRows = false;
            this.drS_DataGridView3.AllowUserToResizeColumns = false;
            this.drS_DataGridView3.AllowUserToResizeRows = false;
            this.drS_DataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.drS_DataGridView3.AutoGenerateColumns = false;
            this.drS_DataGridView3.BackgroundColor = System.Drawing.SystemColors.Control;
            this.drS_DataGridView3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.drS_DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drS_DataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBarcodeName,
            this.colBarcode_barcode,
            this.colIsPrimary_barcode});
            this.drS_DataGridView3.DataSource = this.bindingInactiveBarcode;
            this.drS_DataGridView3.Location = new System.Drawing.Point(6, 19);
            this.drS_DataGridView3.MultiSelect = false;
            this.drS_DataGridView3.Name = "drS_DataGridView3";
            this.drS_DataGridView3.ReadOnly = true;
            this.drS_DataGridView3.RowHeadersVisible = false;
            this.drS_DataGridView3.RowHeadersWidth = 25;
            this.drS_DataGridView3.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.drS_DataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.drS_DataGridView3.Size = new System.Drawing.Size(290, 92);
            this.drS_DataGridView3.TabIndex = 0;
            // 
            // colBarcodeName
            // 
            this.colBarcodeName.DataPropertyName = "BarcodeName";
            this.colBarcodeName.HeaderText = "BarcodeName";
            this.colBarcodeName.Name = "colBarcodeName";
            this.colBarcodeName.ReadOnly = true;
            this.colBarcodeName.Width = 60;
            // 
            // colBarcode_barcode
            // 
            this.colBarcode_barcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBarcode_barcode.DataPropertyName = "Barcode";
            this.colBarcode_barcode.HeaderText = "Barcode";
            this.colBarcode_barcode.Name = "colBarcode_barcode";
            this.colBarcode_barcode.ReadOnly = true;
            // 
            // colIsPrimary_barcode
            // 
            this.colIsPrimary_barcode.DataPropertyName = "IsPrimary";
            this.colIsPrimary_barcode.HeaderText = "IsPrimary";
            this.colIsPrimary_barcode.Name = "colIsPrimary_barcode";
            this.colIsPrimary_barcode.ReadOnly = true;
            this.colIsPrimary_barcode.Width = 30;
            // 
            // drS_DataGridView2
            // 
            this.drS_DataGridView2.AllowUserToAddRows = false;
            this.drS_DataGridView2.AllowUserToDeleteRows = false;
            this.drS_DataGridView2.AllowUserToResizeColumns = false;
            this.drS_DataGridView2.AllowUserToResizeRows = false;
            this.drS_DataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.drS_DataGridView2.AutoGenerateColumns = false;
            this.drS_DataGridView2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.drS_DataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.drS_DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drS_DataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPackTypeName,
            this.colReceiptText,
            this.colSalesPrice,
            this.colBarcode,
            this.colIsPrimary});
            this.drS_DataGridView2.DataSource = this.bindingInactiveSalesPack;
            this.drS_DataGridView2.Location = new System.Drawing.Point(6, 19);
            this.drS_DataGridView2.MultiSelect = false;
            this.drS_DataGridView2.Name = "drS_DataGridView2";
            this.drS_DataGridView2.ReadOnly = true;
            this.drS_DataGridView2.RowHeadersVisible = false;
            this.drS_DataGridView2.RowHeadersWidth = 25;
            this.drS_DataGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.drS_DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.drS_DataGridView2.Size = new System.Drawing.Size(371, 92);
            this.drS_DataGridView2.TabIndex = 0;
            // 
            // colPackTypeName
            // 
            this.colPackTypeName.DataPropertyName = "PackTypeName";
            this.colPackTypeName.HeaderText = "PackTypeName";
            this.colPackTypeName.Name = "colPackTypeName";
            this.colPackTypeName.ReadOnly = true;
            this.colPackTypeName.Width = 45;
            // 
            // colReceiptText
            // 
            this.colReceiptText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colReceiptText.DataPropertyName = "ReceiptText";
            this.colReceiptText.HeaderText = "ReceiptText";
            this.colReceiptText.Name = "colReceiptText";
            this.colReceiptText.ReadOnly = true;
            // 
            // colSalesPrice
            // 
            this.colSalesPrice.DataPropertyName = "SalesPrice";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.colSalesPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.colSalesPrice.HeaderText = "SalesPrice";
            this.colSalesPrice.Name = "colSalesPrice";
            this.colSalesPrice.ReadOnly = true;
            this.colSalesPrice.Width = 60;
            // 
            // colBarcode
            // 
            this.colBarcode.DataPropertyName = "Barcode";
            this.colBarcode.HeaderText = "Barcode";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.ReadOnly = true;
            this.colBarcode.Width = 90;
            // 
            // colIsPrimary
            // 
            this.colIsPrimary.DataPropertyName = "IsPrimary";
            this.colIsPrimary.HeaderText = "IsPrimary";
            this.colIsPrimary.Name = "colIsPrimary";
            this.colIsPrimary.ReadOnly = true;
            this.colIsPrimary.Width = 30;
            // 
            // InactiveItemDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 478);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupSupplierItem);
            this.Controls.Add(this.groupBarcode);
            this.Controls.Add(this.groupSalesPack);
            this.Controls.Add(this.groupItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "InactiveItemDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InactiveItemDetails";
            this.Load += new System.EventHandler(this.InactiveItemDetails_Load);
            this.groupItem.ResumeLayout(false);
            this.groupItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindinInactiveItemSingle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
            this.groupSalesPack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingInactiveSalesPack)).EndInit();
            this.groupBarcode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingInactiveBarcode)).EndInit();
            this.groupSupplierItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingInactiveSupplierItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drS_DataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drS_DataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drS_DataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ItemDataSet dsItem;
        private System.Windows.Forms.GroupBox groupItem;
        private System.Windows.Forms.GroupBox groupSalesPack;
        private System.Windows.Forms.GroupBox groupBarcode;
        private System.Windows.Forms.GroupBox groupSupplierItem;
        private System.Windows.Forms.TextBox subCategoryTextBox;
        private System.Windows.Forms.Label txtSubCategory;
        private DRS.Extensions.DRS_DataGridView drS_DataGridView1;
        private System.Windows.Forms.BindingSource bindingInactiveSupplierItem;
        private RBOS.ItemDataSetTableAdapters.InactiveSupplierItemTableAdapter adapterInactiveSupplierItem;
        private DRS.Extensions.DRS_DataGridView drS_DataGridView2;
        private System.Windows.Forms.BindingSource bindingInactiveSalesPack;
        private DRS.Extensions.DRS_DataGridView drS_DataGridView3;
        private System.Windows.Forms.BindingSource bindingInactiveBarcode;
        private RBOS.ItemDataSetTableAdapters.InactiveSalesPackTableAdapter adapterInactiveSalesPack;
        private RBOS.ItemDataSetTableAdapters.InactiveBarcodeTableAdapter adapterInactiveBarcode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.BindingSource bindinInactiveItemSingle;
        private RBOS.ItemDataSetTableAdapters.InactiveItemSingleTableAdapter adapterInactiveItemSingle;
        private System.Windows.Forms.Label txtItemName;
        private System.Windows.Forms.TextBox itemNameTextBox;
        private System.Windows.Forms.Label txtVatRate;
        private System.Windows.Forms.TextBox VatRateTextBox;
        private System.Windows.Forms.TextBox subCategoryDescTextBox;
        private System.Windows.Forms.Label txtMargin;
        private System.Windows.Forms.TextBox marginTextBox;
        private System.Windows.Forms.Label txtLatestCostPrice;
        private System.Windows.Forms.TextBox costPriceLatestTextBox;
        private System.Windows.Forms.Label txtSalesPrice;
        private System.Windows.Forms.TextBox pOSSalesPriceTextBox;
        private System.Windows.Forms.Label txtBugetMargin;
        private System.Windows.Forms.TextBox BudgetMarginTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplierNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderingNumber;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsPrimary_supplieritem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKolliSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackageCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackageUnitCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSellingPackType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoOfSellingUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSellingUnitCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcodeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode_barcode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsPrimary_barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceiptText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalesPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsPrimary;
        private System.Windows.Forms.Label txtInactivateDateTime;
        private System.Windows.Forms.TextBox inactivateDateTimeTextBox;
    }
}