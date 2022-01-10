namespace RBOS
{
    partial class BHHTOrderDetailForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BHHTOrderDetailForm));
            this.dataGridView1 = new DRS.Extensions.DRS_DataGridView();
            this.colPackType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bindingLookupPackType = new System.Windows.Forms.BindingSource(this.components);
            this.itemDataSet = new RBOS.ItemDataSet();
            this.colReceiptText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExcludeFromOrder = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colLineNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderingNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKolliSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingOrderDetails = new System.Windows.Forms.BindingSource(this.components);
            this.dsImport = new RBOS.ImportDataSet();
            this.btnClose = new System.Windows.Forms.Button();
            this.adapterLookupPackType = new RBOS.ItemDataSetTableAdapters.LookupPackSizeTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adapterOrderDetails = new RBOS.ImportDataSetTableAdapters.BHHTOrderDetailsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupPackType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingOrderDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsImport)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPackType,
            this.colReceiptText,
            this.colExcludeFromOrder,
            this.colLineNumber,
            this.colOrderingNumber,
            this.colKolliSize,
            this.colQuantity});
            this.dataGridView1.DataSource = this.bindingOrderDetails;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.Size = new System.Drawing.Size(561, 382);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowValidated);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // colPackType
            // 
            this.colPackType.DataPropertyName = "PackType";
            this.colPackType.DataSource = this.bindingLookupPackType;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colPackType.DefaultCellStyle = dataGridViewCellStyle1;
            this.colPackType.DisplayMember = "PackTypeName";
            this.colPackType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colPackType.HeaderText = "PackType";
            this.colPackType.Name = "colPackType";
            this.colPackType.ReadOnly = true;
            this.colPackType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colPackType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colPackType.ValueMember = "PackType";
            this.colPackType.Width = 70;
            // 
            // bindingLookupPackType
            // 
            this.bindingLookupPackType.DataMember = "LookupPackSize";
            this.bindingLookupPackType.DataSource = this.itemDataSet;
            // 
            // itemDataSet
            // 
            this.itemDataSet.DataSetName = "ItemDataSet";
            this.itemDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // colReceiptText
            // 
            this.colReceiptText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colReceiptText.DataPropertyName = "ReceiptText";
            this.colReceiptText.HeaderText = "ReceiptText";
            this.colReceiptText.Name = "colReceiptText";
            this.colReceiptText.ReadOnly = true;
            // 
            // colExcludeFromOrder
            // 
            this.colExcludeFromOrder.DataPropertyName = "ExcludeFromOrder";
            this.colExcludeFromOrder.HeaderText = "ExcludeFromOrder";
            this.colExcludeFromOrder.Name = "colExcludeFromOrder";
            this.colExcludeFromOrder.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colExcludeFromOrder.Width = 50;
            // 
            // colLineNumber
            // 
            this.colLineNumber.DataPropertyName = "LineNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colLineNumber.DefaultCellStyle = dataGridViewCellStyle2;
            this.colLineNumber.HeaderText = "LineNo";
            this.colLineNumber.Name = "colLineNumber";
            this.colLineNumber.ReadOnly = true;
            this.colLineNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colLineNumber.Width = 50;
            // 
            // colOrderingNumber
            // 
            this.colOrderingNumber.DataPropertyName = "OrderingNumber";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.NullValue = null;
            this.colOrderingNumber.DefaultCellStyle = dataGridViewCellStyle3;
            this.colOrderingNumber.HeaderText = "OrderingNumber";
            this.colOrderingNumber.Name = "colOrderingNumber";
            this.colOrderingNumber.ReadOnly = true;
            this.colOrderingNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colKolliSize
            // 
            this.colKolliSize.DataPropertyName = "Kolli";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.colKolliSize.DefaultCellStyle = dataGridViewCellStyle4;
            this.colKolliSize.HeaderText = "Kolli";
            this.colKolliSize.Name = "colKolliSize";
            this.colKolliSize.ReadOnly = true;
            this.colKolliSize.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colKolliSize.Width = 50;
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.colQuantity.DefaultCellStyle = dataGridViewCellStyle5;
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colQuantity.Width = 50;
            // 
            // bindingOrderDetails
            // 
            this.bindingOrderDetails.DataMember = "BHHTOrderDetails";
            this.bindingOrderDetails.DataSource = this.dsImport;
            // 
            // dsImport
            // 
            this.dsImport.DataSetName = "ImportDataSet";
            this.dsImport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(498, 406);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // adapterLookupPackType
            // 
            this.adapterLookupPackType.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "LineNo";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn1.HeaderText = "LineNo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "OrderingNumber";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn2.HeaderText = "OrderingNumber";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ItemDescription";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn3.HeaderText = "ItemDescription";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PackType";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn4.HeaderText = "PackType";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Width = 50;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Kolli";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N0";
            dataGridViewCellStyle10.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn5.HeaderText = "Kolli";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.Width = 70;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Quantity";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N0";
            dataGridViewCellStyle11.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn6.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn6.Width = 50;
            // 
            // adapterOrderDetails
            // 
            this.adapterOrderDetails.ClearBeforeFill = true;
            // 
            // BHHTOrderDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 441);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BHHTOrderDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BHHTOrderDetailForm";
            this.Load += new System.EventHandler(this.BHHTOrderDetailForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupPackType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingOrderDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsImport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DRS.Extensions.DRS_DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingOrderDetails;
        private ImportDataSet dsImport;
        private RBOS.ImportDataSetTableAdapters.BHHTOrderDetailsTableAdapter adapterOrderDetails;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private ItemDataSet itemDataSet;
        private System.Windows.Forms.BindingSource bindingLookupPackType;
        private RBOS.ItemDataSetTableAdapters.LookupPackSizeTableAdapter adapterLookupPackType;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPackType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceiptText;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colExcludeFromOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderingNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKolliSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
    }
}