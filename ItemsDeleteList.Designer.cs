namespace RBOS
{
    partial class ItemsDeleteList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemsDeleteList));
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.report = new RBOS.ItemsDeleteRpt();
            this.lbNumSelectedItems = new System.Windows.Forms.Label();
            this.txtNumSelectedItems = new System.Windows.Forms.TextBox();
            this.bindingItemsDelete = new System.Windows.Forms.BindingSource(this.components);
            this.dsItem = new RBOS.ItemDataSet();
            this.grid = new DRS.Extensions.DRS_DataGridView();
            this.colPackTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIncludeInSemiDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderingNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingItemsDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(398, 371);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(117, 23);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "[Slet valgte varer]";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(521, 371);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "[Annuller]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbNumSelectedItems
            // 
            this.lbNumSelectedItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbNumSelectedItems.AutoSize = true;
            this.lbNumSelectedItems.Location = new System.Drawing.Point(23, 374);
            this.lbNumSelectedItems.Name = "lbNumSelectedItems";
            this.lbNumSelectedItems.Size = new System.Drawing.Size(90, 13);
            this.lbNumSelectedItems.TabIndex = 3;
            this.lbNumSelectedItems.Text = "[Antal varer valgt]";
            // 
            // txtNumSelectedItems
            // 
            this.txtNumSelectedItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNumSelectedItems.Location = new System.Drawing.Point(133, 371);
            this.txtNumSelectedItems.Name = "txtNumSelectedItems";
            this.txtNumSelectedItems.ReadOnly = true;
            this.txtNumSelectedItems.Size = new System.Drawing.Size(41, 20);
            this.txtNumSelectedItems.TabIndex = 4;
            // 
            // bindingItemsDelete
            // 
            this.bindingItemsDelete.DataMember = "ItemsDelete";
            this.bindingItemsDelete.DataSource = this.dsItem;
            // 
            // dsItem
            // 
            this.dsItem.DataSetName = "ItemDataSet";
            this.dsItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPackTypeName,
            this.colInStock,
            this.colIncludeInSemiDelete,
            this.colItemName,
            this.colBarcode,
            this.colOrderingNumber});
            this.grid.DataSource = this.bindingItemsDelete;
            this.grid.Location = new System.Drawing.Point(12, 12);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.RowHeadersWidth = 25;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.Size = new System.Drawing.Size(584, 353);
            this.grid.TabIndex = 2;
            this.grid.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellLeave);
            this.grid.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grid_CellMouseUp);
            // 
            // colPackTypeName
            // 
            this.colPackTypeName.DataPropertyName = "PackTypeName";
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.colPackTypeName.DefaultCellStyle = dataGridViewCellStyle1;
            this.colPackTypeName.HeaderText = "PackTypeName";
            this.colPackTypeName.Name = "colPackTypeName";
            this.colPackTypeName.ReadOnly = true;
            this.colPackTypeName.Width = 50;
            // 
            // colInStock
            // 
            this.colInStock.DataPropertyName = "InStock";
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            this.colInStock.DefaultCellStyle = dataGridViewCellStyle2;
            this.colInStock.HeaderText = "InStock";
            this.colInStock.Name = "colInStock";
            this.colInStock.ReadOnly = true;
            this.colInStock.Width = 45;
            // 
            // colIncludeInSemiDelete
            // 
            this.colIncludeInSemiDelete.DataPropertyName = "IncludeInSemiDelete";
            this.colIncludeInSemiDelete.HeaderText = "IncludeInSemiDelete";
            this.colIncludeInSemiDelete.Name = "colIncludeInSemiDelete";
            this.colIncludeInSemiDelete.Width = 20;
            // 
            // colItemName
            // 
            this.colItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colItemName.DataPropertyName = "ItemName";
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            this.colItemName.DefaultCellStyle = dataGridViewCellStyle3;
            this.colItemName.HeaderText = "ItemName";
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            // 
            // colBarcode
            // 
            this.colBarcode.DataPropertyName = "Barcode";
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            this.colBarcode.DefaultCellStyle = dataGridViewCellStyle4;
            this.colBarcode.HeaderText = "Barcode";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.ReadOnly = true;
            // 
            // colOrderingNumber
            // 
            this.colOrderingNumber.DataPropertyName = "OrderingNumber";
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            this.colOrderingNumber.DefaultCellStyle = dataGridViewCellStyle5;
            this.colOrderingNumber.HeaderText = "OrderingNumber";
            this.colOrderingNumber.Name = "colOrderingNumber";
            this.colOrderingNumber.ReadOnly = true;
            // 
            // ItemsDeleteList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 406);
            this.Controls.Add(this.txtNumSelectedItems);
            this.Controls.Add(this.lbNumSelectedItems);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ItemsDeleteList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ItemsDeleteList";
            ((System.ComponentModel.ISupportInitialize)(this.bindingItemsDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private ItemsDeleteRpt report;
        private System.Windows.Forms.Button btnCancel;
        private DRS.Extensions.DRS_DataGridView grid;
        private System.Windows.Forms.BindingSource bindingItemsDelete;
        private ItemDataSet dsItem;
        private System.Windows.Forms.Label lbNumSelectedItems;
        private System.Windows.Forms.TextBox txtNumSelectedItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInStock;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIncludeInSemiDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderingNumber;
    }
}