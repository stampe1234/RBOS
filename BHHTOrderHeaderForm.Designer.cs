namespace RBOS
{
    partial class BHHTOrderHeaderForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BHHTOrderHeaderForm));
            this.gridOrderHeader = new DRS.Extensions.DRS_DataGridView();
            this.bindingLookupSupplier = new System.Windows.Forms.BindingSource(this.components);
            this.dsImport = new RBOS.ImportDataSet();
            this.bindingLookupStatus = new System.Windows.Forms.BindingSource(this.components);
            this.bindingOrderHeader = new System.Windows.Forms.BindingSource(this.components);
            this.btnDetail = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.adapterOrderHeader = new RBOS.ImportDataSetTableAdapters.BHHTOrderHeaderTableAdapter();
            this.adapterLookupSupplier = new RBOS.ImportDataSetTableAdapters.LookupSupplierTableAdapter();
            this.adapterLookupStatus = new RBOS.ImportDataSetTableAdapters.LookupStatusTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplDescription = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colBHHTOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplierNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExcluted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatusColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridOrderHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupSupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingOrderHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // gridOrderHeader
            // 
            this.gridOrderHeader.AllowUserToAddRows = false;
            this.gridOrderHeader.AllowUserToDeleteRows = false;
            this.gridOrderHeader.AllowUserToResizeColumns = false;
            this.gridOrderHeader.AllowUserToResizeRows = false;
            this.gridOrderHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridOrderHeader.AutoGenerateColumns = false;
            this.gridOrderHeader.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridOrderHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridOrderHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSupplDescription,
            this.colStatus,
            this.colBHHTOrderId,
            this.colSupplierNo,
            this.colOrderDate,
            this.colDeliveryDate,
            this.colExcluted,
            this.colStatusColor});
            this.gridOrderHeader.DataSource = this.bindingOrderHeader;
            this.gridOrderHeader.Location = new System.Drawing.Point(12, 12);
            this.gridOrderHeader.Name = "gridOrderHeader";
            this.gridOrderHeader.RowHeadersWidth = 25;
            this.gridOrderHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridOrderHeader.Size = new System.Drawing.Size(534, 340);
            this.gridOrderHeader.TabIndex = 0;
            this.gridOrderHeader.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            this.gridOrderHeader.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridOrderHeader_MouseDoubleClick);
            // 
            // bindingLookupSupplier
            // 
            this.bindingLookupSupplier.DataMember = "LookupSupplier";
            this.bindingLookupSupplier.DataSource = this.dsImport;
            // 
            // dsImport
            // 
            this.dsImport.DataSetName = "ImportDataSet";
            this.dsImport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingLookupStatus
            // 
            this.bindingLookupStatus.DataMember = "LookupStatus";
            this.bindingLookupStatus.DataSource = this.dsImport;
            // 
            // bindingOrderHeader
            // 
            this.bindingOrderHeader.DataMember = "BHHTOrderHeader";
            this.bindingOrderHeader.DataSource = this.dsImport;
            // 
            // btnDetail
            // 
            this.btnDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetail.Location = new System.Drawing.Point(371, 361);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(85, 23);
            this.btnDetail.TabIndex = 2;
            this.btnDetail.Text = "[Detail lines]";
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(462, 361);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateOrder.Location = new System.Drawing.Point(279, 361);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(86, 23);
            this.btnCreateOrder.TabIndex = 4;
            this.btnCreateOrder.Text = "[Create order]";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // adapterOrderHeader
            // 
            this.adapterOrderHeader.ClearBeforeFill = true;
            // 
            // adapterLookupSupplier
            // 
            this.adapterLookupSupplier.ClearBeforeFill = true;
            // 
            // adapterLookupStatus
            // 
            this.adapterLookupStatus.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Description";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn1.HeaderText = "Description";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "OrderID";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn2.HeaderText = "ID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 50;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SupplierID";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "d";
            dataGridViewCellStyle8.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn3.HeaderText = "SuppNo";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "OrderDate";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "d";
            dataGridViewCellStyle9.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn4.HeaderText = "OrderDate";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DeliveryDate";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N0";
            dataGridViewCellStyle10.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn5.HeaderText = "DeliveryDate";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.Width = 70;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "NumExcludeFromOrder";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N0";
            dataGridViewCellStyle11.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn6.HeaderText = "Excluded";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn6.Width = 50;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "StatusColor";
            this.dataGridViewTextBoxColumn7.HeaderText = "StatusColor";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn7.Width = 20;
            // 
            // colSupplDescription
            // 
            this.colSupplDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSupplDescription.DataPropertyName = "SupplierID";
            this.colSupplDescription.DataSource = this.bindingLookupSupplier;
            this.colSupplDescription.DisplayMember = "Description";
            this.colSupplDescription.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colSupplDescription.HeaderText = "Description";
            this.colSupplDescription.Name = "colSupplDescription";
            this.colSupplDescription.ReadOnly = true;
            this.colSupplDescription.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colSupplDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSupplDescription.ValueMember = "SupplierID";
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.DataSource = this.bindingLookupStatus;
            this.colStatus.DisplayMember = "Description";
            this.colStatus.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colStatus.ValueMember = "StatusID";
            this.colStatus.Width = 50;
            // 
            // colBHHTOrderId
            // 
            this.colBHHTOrderId.DataPropertyName = "OrderID";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.colBHHTOrderId.DefaultCellStyle = dataGridViewCellStyle1;
            this.colBHHTOrderId.HeaderText = "ID";
            this.colBHHTOrderId.Name = "colBHHTOrderId";
            this.colBHHTOrderId.ReadOnly = true;
            this.colBHHTOrderId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colBHHTOrderId.Width = 50;
            // 
            // colSupplierNo
            // 
            this.colSupplierNo.DataPropertyName = "SupplierID";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colSupplierNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.colSupplierNo.HeaderText = "SuppNo";
            this.colSupplierNo.Name = "colSupplierNo";
            this.colSupplierNo.ReadOnly = true;
            this.colSupplierNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colSupplierNo.Width = 50;
            // 
            // colOrderDate
            // 
            this.colOrderDate.DataPropertyName = "OrderDate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.colOrderDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.colOrderDate.HeaderText = "OrderDate";
            this.colOrderDate.Name = "colOrderDate";
            this.colOrderDate.ReadOnly = true;
            this.colOrderDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colOrderDate.Width = 90;
            // 
            // colDeliveryDate
            // 
            this.colDeliveryDate.DataPropertyName = "DeliveryDate";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.colDeliveryDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.colDeliveryDate.HeaderText = "DeliveryDate";
            this.colDeliveryDate.Name = "colDeliveryDate";
            this.colDeliveryDate.ReadOnly = true;
            this.colDeliveryDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDeliveryDate.Width = 90;
            // 
            // colExcluted
            // 
            this.colExcluted.DataPropertyName = "NumExcludeFromOrder";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.colExcluted.DefaultCellStyle = dataGridViewCellStyle5;
            this.colExcluted.HeaderText = "Excluded";
            this.colExcluted.Name = "colExcluted";
            this.colExcluted.ReadOnly = true;
            this.colExcluted.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colExcluted.Width = 50;
            // 
            // colStatusColor
            // 
            this.colStatusColor.DataPropertyName = "StatusColor";
            this.colStatusColor.HeaderText = "";
            this.colStatusColor.Name = "colStatusColor";
            this.colStatusColor.ReadOnly = true;
            this.colStatusColor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colStatusColor.Width = 20;
            // 
            // BHHTOrderHeaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 396);
            this.Controls.Add(this.btnCreateOrder);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDetail);
            this.Controls.Add(this.gridOrderHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BHHTOrderHeaderForm";
            this.Text = "BHHTOrderHeaderForm";
            this.Load += new System.EventHandler(this.BHHTOrderHeaderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridOrderHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupSupplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingOrderHeader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DRS.Extensions.DRS_DataGridView gridOrderHeader;
        private ImportDataSet dsImport;
        private System.Windows.Forms.BindingSource bindingOrderHeader;
        private RBOS.ImportDataSetTableAdapters.BHHTOrderHeaderTableAdapter adapterOrderHeader;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.BindingSource bindingLookupSupplier;
        private RBOS.ImportDataSetTableAdapters.LookupSupplierTableAdapter adapterLookupSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.BindingSource bindingLookupStatus;
        private RBOS.ImportDataSetTableAdapters.LookupStatusTableAdapter adapterLookupStatus;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSupplDescription;
        private System.Windows.Forms.DataGridViewComboBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBHHTOrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplierNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliveryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExcluted;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatusColor;
    }
}