namespace RBOS
{
    partial class OrderDraftDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderDraftDetailsForm));
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.txtDraftName = new System.Windows.Forms.TextBox();
            this.bindingOrderDraftSingle = new System.Windows.Forms.BindingSource(this.components);
            this.dsItem = new RBOS.ItemDataSet();
            this.txtSupplierID = new System.Windows.Forms.TextBox();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.lbDraftname = new System.Windows.Forms.Label();
            this.lbSupplierName = new System.Windows.Forms.Label();
            this.lbNumberOfDetails = new System.Windows.Forms.Label();
            this.lbTotalCost = new System.Windows.Forms.Label();
            this.txtNumberOfDetails = new System.Windows.Forms.TextBox();
            this.txtTotalCost = new System.Windows.Forms.TextBox();
            this.bindingRelDraftDetails = new System.Windows.Forms.BindingSource(this.components);
            this.btnLookupSupplier = new System.Windows.Forms.Button();
            this.bindingLookupPackSize = new System.Windows.Forms.BindingSource(this.components);
            this.bindingLookupSupplier = new System.Windows.Forms.BindingSource(this.components);
            this.adapterLookupSupplier = new RBOS.ItemDataSetTableAdapters.LookupSupplierTableAdapter();
            this.bindingLookupStatus = new System.Windows.Forms.BindingSource(this.components);
            this.adapterLookupStatus = new RBOS.ItemDataSetTableAdapters.LookupStatusTableAdapter();
            this.adapterLookupPackSize = new RBOS.ItemDataSetTableAdapters.LookupPackSizeTableAdapter();
            this.adapterOrderDraftSingle = new RBOS.ItemDataSetTableAdapters.OrderDraftSingleTableAdapter();
            this.adapterRelDraftDetails = new RBOS.ItemDataSetTableAdapters.OrderDraftDetailsTableAdapter();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.gridDraftDetails = new DRS.Extensions.DRS_DataGridView();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colKolli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKolliCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderingNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceivedQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderingNumberButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingOrderDraftSingle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingRelDraftDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupPackSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupSupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDraftDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(752, 641);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "[Cancel]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndClose.Location = new System.Drawing.Point(591, 641);
            this.btnSaveAndClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(153, 28);
            this.btnSaveAndClose.TabIndex = 4;
            this.btnSaveAndClose.Text = "[Save and Close]";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // txtDraftName
            // 
            this.txtDraftName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingOrderDraftSingle, "DraftName", true));
            this.txtDraftName.Location = new System.Drawing.Point(131, 15);
            this.txtDraftName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDraftName.Name = "txtDraftName";
            this.txtDraftName.Size = new System.Drawing.Size(284, 22);
            this.txtDraftName.TabIndex = 0;
            this.txtDraftName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDraftName_KeyDown);
            // 
            // bindingOrderDraftSingle
            // 
            this.bindingOrderDraftSingle.DataMember = "OrderDraftSingle";
            this.bindingOrderDraftSingle.DataSource = this.dsItem;
            // 
            // dsItem
            // 
            this.dsItem.DataSetName = "ItemDataSet";
            this.dsItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtSupplierID
            // 
            this.txtSupplierID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingOrderDraftSingle, "SupplierID", true));
            this.txtSupplierID.Location = new System.Drawing.Point(541, 15);
            this.txtSupplierID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.ReadOnly = true;
            this.txtSupplierID.Size = new System.Drawing.Size(53, 22);
            this.txtSupplierID.TabIndex = 3;
            this.txtSupplierID.TabStop = false;
            this.txtSupplierID.TextChanged += new System.EventHandler(this.txtSupplierID_TextChanged);
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Location = new System.Drawing.Point(604, 15);
            this.txtSupplierName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.ReadOnly = true;
            this.txtSupplierName.Size = new System.Drawing.Size(205, 22);
            this.txtSupplierName.TabIndex = 6;
            this.txtSupplierName.TabStop = false;
            // 
            // lbDraftname
            // 
            this.lbDraftname.AutoSize = true;
            this.lbDraftname.Location = new System.Drawing.Point(13, 18);
            this.lbDraftname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDraftname.Name = "lbDraftname";
            this.lbDraftname.Size = new System.Drawing.Size(88, 17);
            this.lbDraftname.TabIndex = 7;
            this.lbDraftname.Text = "[Draft Name]";
            // 
            // lbSupplierName
            // 
            this.lbSupplierName.AutoSize = true;
            this.lbSupplierName.Location = new System.Drawing.Point(444, 18);
            this.lbSupplierName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSupplierName.Name = "lbSupplierName";
            this.lbSupplierName.Size = new System.Drawing.Size(68, 17);
            this.lbSupplierName.TabIndex = 9;
            this.lbSupplierName.Text = "[Supplier]";
            // 
            // lbNumberOfDetails
            // 
            this.lbNumberOfDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbNumberOfDetails.AutoSize = true;
            this.lbNumberOfDetails.Location = new System.Drawing.Point(32, 601);
            this.lbNumberOfDetails.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNumberOfDetails.Name = "lbNumberOfDetails";
            this.lbNumberOfDetails.Size = new System.Drawing.Size(127, 17);
            this.lbNumberOfDetails.TabIndex = 13;
            this.lbNumberOfDetails.Text = "[Number of details]";
            // 
            // lbTotalCost
            // 
            this.lbTotalCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTotalCost.AutoSize = true;
            this.lbTotalCost.Location = new System.Drawing.Point(669, 601);
            this.lbTotalCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTotalCost.Name = "lbTotalCost";
            this.lbTotalCost.Size = new System.Drawing.Size(80, 17);
            this.lbTotalCost.TabIndex = 15;
            this.lbTotalCost.Text = "[Total Cost]";
            // 
            // txtNumberOfDetails
            // 
            this.txtNumberOfDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNumberOfDetails.Location = new System.Drawing.Point(167, 597);
            this.txtNumberOfDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNumberOfDetails.Name = "txtNumberOfDetails";
            this.txtNumberOfDetails.ReadOnly = true;
            this.txtNumberOfDetails.Size = new System.Drawing.Size(44, 22);
            this.txtNumberOfDetails.TabIndex = 23;
            this.txtNumberOfDetails.TabStop = false;
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalCost.Location = new System.Drawing.Point(759, 597);
            this.txtTotalCost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.ReadOnly = true;
            this.txtTotalCost.Size = new System.Drawing.Size(92, 22);
            this.txtTotalCost.TabIndex = 24;
            this.txtTotalCost.TabStop = false;
            this.txtTotalCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bindingRelDraftDetails
            // 
            this.bindingRelDraftDetails.DataMember = "OrderDraftSingle_OrderDraftDetails";
            this.bindingRelDraftDetails.DataSource = this.bindingOrderDraftSingle;
            // 
            // btnLookupSupplier
            // 
            this.btnLookupSupplier.Image = ((System.Drawing.Image)(resources.GetObject("btnLookupSupplier.Image")));
            this.btnLookupSupplier.Location = new System.Drawing.Point(819, 12);
            this.btnLookupSupplier.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLookupSupplier.Name = "btnLookupSupplier";
            this.btnLookupSupplier.Size = new System.Drawing.Size(33, 28);
            this.btnLookupSupplier.TabIndex = 1;
            this.btnLookupSupplier.UseVisualStyleBackColor = true;
            this.btnLookupSupplier.Click += new System.EventHandler(this.btnLookupSupplier_Click);
            // 
            // bindingLookupPackSize
            // 
            this.bindingLookupPackSize.DataMember = "LookupPackSize";
            this.bindingLookupPackSize.DataSource = this.dsItem;
            // 
            // bindingLookupSupplier
            // 
            this.bindingLookupSupplier.DataMember = "LookupSupplier";
            this.bindingLookupSupplier.DataSource = this.dsItem;
            // 
            // adapterLookupSupplier
            // 
            this.adapterLookupSupplier.ClearBeforeFill = true;
            // 
            // bindingLookupStatus
            // 
            this.bindingLookupStatus.DataMember = "LookupStatus";
            this.bindingLookupStatus.DataSource = this.dsItem;
            // 
            // adapterLookupStatus
            // 
            this.adapterLookupStatus.ClearBeforeFill = true;
            // 
            // adapterLookupPackSize
            // 
            this.adapterLookupPackSize.ClearBeforeFill = true;
            // 
            // adapterOrderDraftSingle
            // 
            this.adapterOrderDraftSingle.ClearBeforeFill = true;
            // 
            // adapterRelDraftDetails
            // 
            this.adapterRelDraftDetails.ClearBeforeFill = true;
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Location = new System.Drawing.Point(448, 641);
            this.btnCreateOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(135, 28);
            this.btnCreateOrder.TabIndex = 3;
            this.btnCreateOrder.Text = "[Create Order]";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // gridDraftDetails
            // 
            this.gridDraftDetails.AllowUserToResizeColumns = false;
            this.gridDraftDetails.AllowUserToResizeRows = false;
            this.gridDraftDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDraftDetails.AutoGenerateColumns = false;
            this.gridDraftDetails.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridDraftDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridDraftDetails.ColumnHeadersHeight = 21;
            this.gridDraftDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridDraftDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDescription,
            this.colPackType,
            this.colKolli,
            this.colKolliCost,
            this.colOrderingNumber,
            this.colCost,
            this.colReceivedQuantity,
            this.colQuantity,
            this.colOrderingNumberButton});
            this.gridDraftDetails.DataSource = this.bindingRelDraftDetails;
            this.gridDraftDetails.Location = new System.Drawing.Point(16, 47);
            this.gridDraftDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridDraftDetails.MultiSelect = false;
            this.gridDraftDetails.Name = "gridDraftDetails";
            this.gridDraftDetails.RowHeadersWidth = 25;
            this.gridDraftDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridDraftDetails.Size = new System.Drawing.Size(836, 543);
            this.gridDraftDetails.TabIndex = 2;
            this.gridDraftDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDraftDetails_CellContentClick);
            this.gridDraftDetails.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOrderDraftDetails_CellEndEdit);
            this.gridDraftDetails.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gridDraftDetails_CellPainting);
            this.gridDraftDetails.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOrderDraftDetails_CellValidated);
            this.gridDraftDetails.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gridOrderDraftDetails_CellValidating);
            this.gridDraftDetails.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.gridDraftDetails.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.gridOrderDraftDetails_RowsRemoved);
            this.gridDraftDetails.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridOrderDraftDetails_RowValidating);
            this.gridDraftDetails.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridDraftDetails_KeyUp);
            // 
            // colDescription
            // 
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescription.DataPropertyName = "ReceiptText";
            this.colDescription.HeaderText = "Desc.";
            this.colDescription.Name = "colDescription";
            this.colDescription.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colPackType
            // 
            this.colPackType.DataPropertyName = "PackType";
            this.colPackType.DataSource = this.bindingLookupPackSize;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.colPackType.DefaultCellStyle = dataGridViewCellStyle1;
            this.colPackType.DisplayMember = "PackTypeName";
            this.colPackType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colPackType.HeaderText = "SP";
            this.colPackType.Name = "colPackType";
            this.colPackType.ReadOnly = true;
            this.colPackType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colPackType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colPackType.ValueMember = "PackType";
            this.colPackType.Width = 50;
            // 
            // colKolli
            // 
            this.colKolli.DataPropertyName = "KolliSize";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            this.colKolli.DefaultCellStyle = dataGridViewCellStyle2;
            this.colKolli.HeaderText = "Kolli";
            this.colKolli.Name = "colKolli";
            this.colKolli.ReadOnly = true;
            this.colKolli.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colKolli.Width = 40;
            // 
            // colKolliCost
            // 
            this.colKolliCost.DataPropertyName = "PackageCost";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.colKolliCost.DefaultCellStyle = dataGridViewCellStyle3;
            this.colKolliCost.HeaderText = "Kolli cost";
            this.colKolliCost.Name = "colKolliCost";
            this.colKolliCost.ReadOnly = true;
            this.colKolliCost.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colKolliCost.Width = 60;
            // 
            // colOrderingNumber
            // 
            this.colOrderingNumber.DataPropertyName = "OrderingNumber";
            this.colOrderingNumber.HeaderText = "OrderingNumber";
            this.colOrderingNumber.Name = "colOrderingNumber";
            this.colOrderingNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colOrderingNumber.Width = 90;
            // 
            // colCost
            // 
            this.colCost.DataPropertyName = "Cost";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.colCost.DefaultCellStyle = dataGridViewCellStyle4;
            this.colCost.HeaderText = "Cost";
            this.colCost.Name = "colCost";
            this.colCost.ReadOnly = true;
            this.colCost.Width = 65;
            // 
            // colReceivedQuantity
            // 
            this.colReceivedQuantity.DataPropertyName = "ReceivedQuantity";
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            this.colReceivedQuantity.DefaultCellStyle = dataGridViewCellStyle5;
            this.colReceivedQuantity.HeaderText = "R.Quantity";
            this.colReceivedQuantity.Name = "colReceivedQuantity";
            this.colReceivedQuantity.ReadOnly = true;
            this.colReceivedQuantity.Width = 60;
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "Quantity";
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Width = 60;
            // 
            // colOrderingNumberButton
            // 
            this.colOrderingNumberButton.HeaderText = "";
            this.colOrderingNumberButton.Name = "colOrderingNumberButton";
            this.colOrderingNumberButton.Width = 25;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "OrderID";
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn1.HeaderText = "OrderID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "LineNo";
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn2.HeaderText = "LineNo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 50;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SuppItemID";
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn3.HeaderText = "SuppItemID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "UOMID";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn4.HeaderText = "UOMID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 50;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Quantity";
            this.dataGridViewTextBoxColumn5.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.Width = 50;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ReceivedQuantity";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn6.HeaderText = "ReceivedQuantity";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 60;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "OrderID";
            this.dataGridViewTextBoxColumn7.HeaderText = "OrderID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn7.Width = 50;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "LineNo";
            this.dataGridViewTextBoxColumn8.HeaderText = "LineNo";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn8.Width = 60;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "SuppItemID";
            this.dataGridViewTextBoxColumn9.HeaderText = "SuppItemID";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "UOMID";
            this.dataGridViewTextBoxColumn10.HeaderText = "UOMID";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Quantity";
            this.dataGridViewTextBoxColumn11.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "ReceivedQuantity";
            this.dataGridViewTextBoxColumn12.HeaderText = "ReceivedQuantity";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // OrderDraftDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 684);
            this.Controls.Add(this.btnCreateOrder);
            this.Controls.Add(this.btnLookupSupplier);
            this.Controls.Add(this.lbDraftname);
            this.Controls.Add(this.txtDraftName);
            this.Controls.Add(this.txtTotalCost);
            this.Controls.Add(this.txtNumberOfDetails);
            this.Controls.Add(this.gridDraftDetails);
            this.Controls.Add(this.txtSupplierName);
            this.Controls.Add(this.lbTotalCost);
            this.Controls.Add(this.lbNumberOfDetails);
            this.Controls.Add(this.txtSupplierID);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lbSupplierName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "OrderDraftDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OrderDraftDetailsForm";
            this.Load += new System.EventHandler(this.OrderDraftDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingOrderDraftSingle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingRelDraftDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupPackSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupSupplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDraftDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveAndClose;
        private ItemDataSet dsItem;
        private System.Windows.Forms.TextBox txtSupplierID;
        private System.Windows.Forms.BindingSource bindingLookupSupplier;
        private RBOS.ItemDataSetTableAdapters.LookupSupplierTableAdapter adapterLookupSupplier;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.Label lbDraftname;
        private System.Windows.Forms.Label lbSupplierName;
        private System.Windows.Forms.Label lbNumberOfDetails;
        private System.Windows.Forms.Label lbTotalCost;
        private DRS.Extensions.DRS_DataGridView gridDraftDetails;
        private System.Windows.Forms.TextBox txtNumberOfDetails;
        private System.Windows.Forms.TextBox txtTotalCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.BindingSource bindingLookupStatus;
        private RBOS.ItemDataSetTableAdapters.LookupStatusTableAdapter adapterLookupStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.BindingSource bindingLookupPackSize;
        private RBOS.ItemDataSetTableAdapters.LookupPackSizeTableAdapter adapterLookupPackSize;
        private System.Windows.Forms.TextBox txtDraftName;
        private System.Windows.Forms.BindingSource bindingOrderDraftSingle;
        private RBOS.ItemDataSetTableAdapters.OrderDraftSingleTableAdapter adapterOrderDraftSingle;
        private System.Windows.Forms.BindingSource bindingRelDraftDetails;
        private RBOS.ItemDataSetTableAdapters.OrderDraftDetailsTableAdapter adapterRelDraftDetails;
        private System.Windows.Forms.Button btnLookupSupplier;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPackType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKolli;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKolliCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderingNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceivedQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewButtonColumn colOrderingNumberButton;
    }
}