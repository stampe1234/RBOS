namespace RBOS
{
    partial class InactiveItemList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InactiveItemList));
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.bindingInactiveItem = new System.Windows.Forms.BindingSource(this.components);
            this.dsItem = new RBOS.ItemDataSet();
            this.adapterInactiveItem = new RBOS.ItemDataSetTableAdapters.InactiveItemTableAdapter();
            this.drS_DataGridView1 = new DRS.Extensions.DRS_DataGridView();
            this.colDetailsButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colInactivateDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastChangeDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPOSSalesPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostPriceLatest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingInactiveItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drS_DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(580, 450);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "[Slet]";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(471, 450);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(103, 23);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "[Opret vare]";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(661, 450);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "[Luk]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(390, 450);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "[Søg]";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // bindingInactiveItem
            // 
            this.bindingInactiveItem.DataMember = "InactiveItem";
            this.bindingInactiveItem.DataSource = this.dsItem;
            // 
            // dsItem
            // 
            this.dsItem.DataSetName = "ItemDataSet";
            this.dsItem.EnforceConstraints = false;
            this.dsItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // adapterInactiveItem
            // 
            this.adapterInactiveItem.ClearBeforeFill = true;
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
            this.drS_DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drS_DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDetailsButton,
            this.colInactivateDateTime,
            this.colBarcode,
            this.colLastChangeDateTime,
            this.colItemName,
            this.colSubCategory,
            this.colPOSSalesPrice,
            this.colCostPriceLatest});
            this.drS_DataGridView1.DataSource = this.bindingInactiveItem;
            this.drS_DataGridView1.Location = new System.Drawing.Point(12, 12);
            this.drS_DataGridView1.MultiSelect = false;
            this.drS_DataGridView1.Name = "drS_DataGridView1";
            this.drS_DataGridView1.ReadOnly = true;
            this.drS_DataGridView1.RowHeadersVisible = false;
            this.drS_DataGridView1.RowHeadersWidth = 25;
            this.drS_DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.drS_DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.drS_DataGridView1.Size = new System.Drawing.Size(724, 432);
            this.drS_DataGridView1.TabIndex = 0;
            this.drS_DataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.drS_DataGridView1_CellPainting);
            this.drS_DataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.drS_DataGridView1_CellMouseDoubleClick);
            this.drS_DataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.drS_DataGridView1_CellContentClick);
            // 
            // colDetailsButton
            // 
            this.colDetailsButton.HeaderText = "";
            this.colDetailsButton.Name = "colDetailsButton";
            this.colDetailsButton.ReadOnly = true;
            this.colDetailsButton.Width = 25;
            // 
            // colInactivateDateTime
            // 
            this.colInactivateDateTime.DataPropertyName = "InactivateDateTime";
            this.colInactivateDateTime.HeaderText = "InactivateDateTime";
            this.colInactivateDateTime.Name = "colInactivateDateTime";
            this.colInactivateDateTime.ReadOnly = true;
            // 
            // colBarcode
            // 
            this.colBarcode.DataPropertyName = "Barcode";
            this.colBarcode.HeaderText = "Barcode";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.ReadOnly = true;
            // 
            // colLastChangeDateTime
            // 
            this.colLastChangeDateTime.DataPropertyName = "LastChangeDateTime";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.colLastChangeDateTime.DefaultCellStyle = dataGridViewCellStyle1;
            this.colLastChangeDateTime.HeaderText = "LastChangeDateTime";
            this.colLastChangeDateTime.Name = "colLastChangeDateTime";
            this.colLastChangeDateTime.ReadOnly = true;
            this.colLastChangeDateTime.Width = 70;
            // 
            // colItemName
            // 
            this.colItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colItemName.DataPropertyName = "ItemName";
            this.colItemName.HeaderText = "ItemName";
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            // 
            // colSubCategory
            // 
            this.colSubCategory.DataPropertyName = "SubCategory";
            this.colSubCategory.HeaderText = "SubCategory";
            this.colSubCategory.Name = "colSubCategory";
            this.colSubCategory.ReadOnly = true;
            // 
            // colPOSSalesPrice
            // 
            this.colPOSSalesPrice.DataPropertyName = "POSSalesPrice";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.colPOSSalesPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.colPOSSalesPrice.HeaderText = "POSSalesPrice";
            this.colPOSSalesPrice.Name = "colPOSSalesPrice";
            this.colPOSSalesPrice.ReadOnly = true;
            this.colPOSSalesPrice.Width = 50;
            // 
            // colCostPriceLatest
            // 
            this.colCostPriceLatest.DataPropertyName = "CostPriceLatest";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = null;
            this.colCostPriceLatest.DefaultCellStyle = dataGridViewCellStyle3;
            this.colCostPriceLatest.HeaderText = "CostPriceLatest";
            this.colCostPriceLatest.Name = "colCostPriceLatest";
            this.colCostPriceLatest.ReadOnly = true;
            this.colCostPriceLatest.Width = 50;
            // 
            // InactiveItemList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 485);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.drS_DataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "InactiveItemList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InactiveItemList";
            this.Load += new System.EventHandler(this.InactiveItemList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingInactiveItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drS_DataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DRS.Extensions.DRS_DataGridView drS_DataGridView1;
        private ItemDataSet dsItem;
        private System.Windows.Forms.BindingSource bindingInactiveItem;
        private RBOS.ItemDataSetTableAdapters.InactiveItemTableAdapter adapterInactiveItem;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewButtonColumn colDetailsButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInactivateDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastChangeDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPOSSalesPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostPriceLatest;

    }
}