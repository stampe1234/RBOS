namespace RBOS
{
    partial class ItemUpdLines
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemUpdLines));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAllSales = new System.Windows.Forms.Button();
            this.btnSkipAllSalesPrices = new System.Windows.Forms.Button();
            this.groupPerformAllButtons = new System.Windows.Forms.GroupBox();
            this.btnAllNewItems = new System.Windows.Forms.Button();
            this.bindingLookupSubCategory = new System.Windows.Forms.BindingSource(this.components);
            this.dsItem = new RBOS.ItemDataSet();
            this.adapterLookupSubCategory = new RBOS.ItemDataSetTableAdapters.LookupSubCategoryTableAdapter();
            this.bindingLookupLLStatus = new System.Windows.Forms.BindingSource(this.components);
            this.dsImport = new RBOS.ImportDataSet();
            this.bindingItemUpdLines = new System.Windows.Forms.BindingSource(this.components);
            this.adapterItemUpdLines = new RBOS.ImportDataSetTableAdapters.ItemUpdLinesTableAdapter();
            this.adapterLookupLLStatus = new RBOS.ImportDataSetTableAdapters.LookupLLStatusTableAdapter();
            this.btnAccept = new System.Windows.Forms.Button();
            this.dataGridView1 = new DRS.Extensions.DRS_DataGridView();
            this.colInfoButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colActionDoneSummary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colExecuteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colActionSummary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalesPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKolli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSkip = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colSubCat = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colStatusColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKampagneID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFutureSalesPriceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupPerformAllButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupSubCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupLLStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingItemUpdLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(1132, 610);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAllSales
            // 
            this.btnAllSales.Location = new System.Drawing.Point(423, 23);
            this.btnAllSales.Margin = new System.Windows.Forms.Padding(4);
            this.btnAllSales.Name = "btnAllSales";
            this.btnAllSales.Size = new System.Drawing.Size(139, 28);
            this.btnAllSales.TabIndex = 5;
            this.btnAllSales.Text = "[Sales]";
            this.btnAllSales.UseVisualStyleBackColor = true;
            this.btnAllSales.Click += new System.EventHandler(this.btnAllSales_Click);
            // 
            // btnSkipAllSalesPrices
            // 
            this.btnSkipAllSalesPrices.Location = new System.Drawing.Point(104, 23);
            this.btnSkipAllSalesPrices.Margin = new System.Windows.Forms.Padding(4);
            this.btnSkipAllSalesPrices.Name = "btnSkipAllSalesPrices";
            this.btnSkipAllSalesPrices.Size = new System.Drawing.Size(164, 28);
            this.btnSkipAllSalesPrices.TabIndex = 7;
            this.btnSkipAllSalesPrices.Text = "[Skip sales prices]";
            this.btnSkipAllSalesPrices.UseVisualStyleBackColor = true;
            this.btnSkipAllSalesPrices.Click += new System.EventHandler(this.btnSkipAllSalesPrices_Click);
            // 
            // groupPerformAllButtons
            // 
            this.groupPerformAllButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPerformAllButtons.Controls.Add(this.btnAllNewItems);
            this.groupPerformAllButtons.Controls.Add(this.btnSkipAllSalesPrices);
            this.groupPerformAllButtons.Controls.Add(this.btnAllSales);
            this.groupPerformAllButtons.Location = new System.Drawing.Point(416, 588);
            this.groupPerformAllButtons.Margin = new System.Windows.Forms.Padding(4);
            this.groupPerformAllButtons.Name = "groupPerformAllButtons";
            this.groupPerformAllButtons.Padding = new System.Windows.Forms.Padding(4);
            this.groupPerformAllButtons.Size = new System.Drawing.Size(600, 64);
            this.groupPerformAllButtons.TabIndex = 8;
            this.groupPerformAllButtons.TabStop = false;
            this.groupPerformAllButtons.Text = "[Perform All]";
            // 
            // btnAllNewItems
            // 
            this.btnAllNewItems.Location = new System.Drawing.Point(276, 23);
            this.btnAllNewItems.Margin = new System.Windows.Forms.Padding(4);
            this.btnAllNewItems.Name = "btnAllNewItems";
            this.btnAllNewItems.Size = new System.Drawing.Size(139, 28);
            this.btnAllNewItems.TabIndex = 8;
            this.btnAllNewItems.Text = "[New Items]";
            this.btnAllNewItems.UseVisualStyleBackColor = true;
            this.btnAllNewItems.Click += new System.EventHandler(this.btnAllNewItems_Click);
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
            // adapterLookupSubCategory
            // 
            this.adapterLookupSubCategory.ClearBeforeFill = true;
            // 
            // bindingLookupLLStatus
            // 
            this.bindingLookupLLStatus.DataMember = "LookupLLStatus";
            this.bindingLookupLLStatus.DataSource = this.dsImport;
            // 
            // dsImport
            // 
            this.dsImport.DataSetName = "ImportDataSet";
            this.dsImport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingItemUpdLines
            // 
            this.bindingItemUpdLines.DataMember = "ItemUpdLines";
            this.bindingItemUpdLines.DataSource = this.dsImport;
            // 
            // adapterItemUpdLines
            // 
            this.adapterItemUpdLines.ClearBeforeFill = true;
            // 
            // adapterLookupLLStatus
            // 
            this.adapterLookupLLStatus.ClearBeforeFill = true;
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(1043, 610);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(83, 28);
            this.btnAccept.TabIndex = 9;
            this.btnAccept.Text = "Godkend alle";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
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
            this.dataGridView1.ColumnHeadersHeight = 21;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInfoButton,
            this.colActionDoneSummary,
            this.colStatus,
            this.colExecuteButton,
            this.colActionSummary,
            this.colName,
            this.colSalesPrice,
            this.colKolli,
            this.colCostPrice,
            this.colSkip,
            this.colSubCat,
            this.colStatusColor,
            this.colKampagneID,
            this.colFutureSalesPriceDate,
            this.colPackType});
            this.dataGridView1.DataSource = this.bindingItemUpdLines;
            this.dataGridView1.Location = new System.Drawing.Point(16, 15);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1216, 565);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // colInfoButton
            // 
            this.colInfoButton.HeaderText = "[Info]";
            this.colInfoButton.Name = "colInfoButton";
            this.colInfoButton.ReadOnly = true;
            this.colInfoButton.Text = "...";
            this.colInfoButton.Width = 25;
            // 
            // colActionDoneSummary
            // 
            this.colActionDoneSummary.DataPropertyName = "ActionDoneSummary";
            this.colActionDoneSummary.HeaderText = "[Done]";
            this.colActionDoneSummary.Name = "colActionDoneSummary";
            this.colActionDoneSummary.ReadOnly = true;
            this.colActionDoneSummary.Width = 50;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.DataSource = this.bindingLookupLLStatus;
            this.colStatus.DisplayMember = "Description";
            this.colStatus.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.ValueMember = "ID";
            this.colStatus.Width = 60;
            // 
            // colExecuteButton
            // 
            this.colExecuteButton.HeaderText = "[Execute]";
            this.colExecuteButton.Name = "colExecuteButton";
            this.colExecuteButton.ReadOnly = true;
            this.colExecuteButton.Text = "...";
            this.colExecuteButton.Width = 25;
            // 
            // colActionSummary
            // 
            this.colActionSummary.DataPropertyName = "ActionSummary";
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.colActionSummary.DefaultCellStyle = dataGridViewCellStyle1;
            this.colActionSummary.HeaderText = "[ActionSummary]";
            this.colActionSummary.Name = "colActionSummary";
            this.colActionSummary.ReadOnly = true;
            this.colActionSummary.Width = 121;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "[Name]";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colSalesPrice
            // 
            this.colSalesPrice.DataPropertyName = "SalesPrice";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.colSalesPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.colSalesPrice.HeaderText = "[Sales]";
            this.colSalesPrice.Name = "colSalesPrice";
            this.colSalesPrice.ReadOnly = true;
            this.colSalesPrice.Width = 60;
            // 
            // colKolli
            // 
            this.colKolli.DataPropertyName = "Kolli";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.NullValue = null;
            this.colKolli.DefaultCellStyle = dataGridViewCellStyle3;
            this.colKolli.HeaderText = "[Kolli]";
            this.colKolli.Name = "colKolli";
            this.colKolli.ReadOnly = true;
            this.colKolli.Width = 50;
            // 
            // colCostPrice
            // 
            this.colCostPrice.DataPropertyName = "CostPrice";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N3";
            dataGridViewCellStyle4.NullValue = null;
            this.colCostPrice.DefaultCellStyle = dataGridViewCellStyle4;
            this.colCostPrice.HeaderText = "[CostPrice]";
            this.colCostPrice.Name = "colCostPrice";
            this.colCostPrice.ReadOnly = true;
            this.colCostPrice.Width = 60;
            // 
            // colSkip
            // 
            this.colSkip.DataPropertyName = "Skip";
            this.colSkip.HeaderText = "[Skip]";
            this.colSkip.Name = "colSkip";
            this.colSkip.Visible = false;
            this.colSkip.Width = 40;
            // 
            // colSubCat
            // 
            this.colSubCat.DataPropertyName = "SubCat";
            this.colSubCat.DataSource = this.bindingLookupSubCategory;
            this.colSubCat.DisplayMember = "Description";
            this.colSubCat.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colSubCat.HeaderText = "[SubCat]";
            this.colSubCat.Name = "colSubCat";
            this.colSubCat.ReadOnly = true;
            this.colSubCat.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSubCat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSubCat.ValueMember = "SubCategoryID";
            this.colSubCat.Width = 80;
            // 
            // colStatusColor
            // 
            this.colStatusColor.HeaderText = "";
            this.colStatusColor.Name = "colStatusColor";
            this.colStatusColor.ReadOnly = true;
            this.colStatusColor.Width = 20;
            // 
            // colKampagneID
            // 
            this.colKampagneID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colKampagneID.DataPropertyName = "KampagneID";
            this.colKampagneID.HeaderText = "KampagneID";
            this.colKampagneID.Name = "colKampagneID";
            this.colKampagneID.ReadOnly = true;
            this.colKampagneID.Visible = false;
            this.colKampagneID.Width = 118;
            // 
            // colFutureSalesPriceDate
            // 
            this.colFutureSalesPriceDate.DataPropertyName = "FutureSalesPriceDate";
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.colFutureSalesPriceDate.DefaultCellStyle = dataGridViewCellStyle5;
            this.colFutureSalesPriceDate.HeaderText = "FutureSalesPriceDate";
            this.colFutureSalesPriceDate.Name = "colFutureSalesPriceDate";
            this.colFutureSalesPriceDate.ReadOnly = true;
            this.colFutureSalesPriceDate.Visible = false;
            this.colFutureSalesPriceDate.Width = 70;
            // 
            // colPackType
            // 
            this.colPackType.DataPropertyName = "PackType";
            this.colPackType.HeaderText = "PackType";
            this.colPackType.Name = "colPackType";
            this.colPackType.Visible = false;
            this.colPackType.Width = 30;
            // 
            // ItemUpdLines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 666);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.groupPerformAllButtons);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ItemUpdLines";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ItemUpdLines";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ItemUpdLines_FormClosing);
            this.Load += new System.EventHandler(this.ItemUpdLines_Load);
            this.groupPerformAllButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupSubCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupLLStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingItemUpdLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DRS.Extensions.DRS_DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingItemUpdLines;
        private ImportDataSet dsImport;
        private RBOS.ImportDataSetTableAdapters.ItemUpdLinesTableAdapter adapterItemUpdLines;
        private ItemDataSet dsItem;
        private System.Windows.Forms.BindingSource bindingLookupSubCategory;
        private RBOS.ItemDataSetTableAdapters.LookupSubCategoryTableAdapter adapterLookupSubCategory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.BindingSource bindingLookupLLStatus;
        private RBOS.ImportDataSetTableAdapters.LookupLLStatusTableAdapter adapterLookupLLStatus;
        private System.Windows.Forms.Button btnAllSales;
        private System.Windows.Forms.Button btnSkipAllSalesPrices;
        private System.Windows.Forms.GroupBox groupPerformAllButtons;
        private System.Windows.Forms.Button btnAllNewItems;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.DataGridViewButtonColumn colInfoButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActionDoneSummary;
        private System.Windows.Forms.DataGridViewComboBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewButtonColumn colExecuteButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActionSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalesPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKolli;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostPrice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSkip;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSubCat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatusColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKampagneID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFutureSalesPriceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackType;
    }
}