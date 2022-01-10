namespace RBOS
{
    partial class OrderDetailsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderDetailsForm));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.bindingOrderHeaderSingle = new System.Windows.Forms.BindingSource(this.components);
            this.dsItem = new RBOS.ItemDataSet();
            this.txtSupplierID = new System.Windows.Forms.TextBox();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.lbOrderID = new System.Windows.Forms.Label();
            this.lbSupplierID = new System.Windows.Forms.Label();
            this.lbSupplierName = new System.Windows.Forms.Label();
            this.lbOrderingDate = new System.Windows.Forms.Label();
            this.lbDeliveryDate = new System.Windows.Forms.Label();
            this.lbNumberOfDetails = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbTotalCost = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.bindingRelOrderDetails = new System.Windows.Forms.BindingSource(this.components);
            this.txtNumberOfDetails = new System.Windows.Forms.TextBox();
            this.txtTotalCost = new System.Windows.Forms.TextBox();
            this.btnSaveAndSend = new System.Windows.Forms.Button();
            this.btnBook = new System.Windows.Forms.Button();
            this.btnReceive = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lbSentDate = new System.Windows.Forms.Label();
            this.txtSentDate = new System.Windows.Forms.TextBox();
            this.btnAddItemInRecvMode = new System.Windows.Forms.Button();
            this.btnCreateAsDraft = new System.Windows.Forms.Button();
            this.txtTotalCostExVAT = new System.Windows.Forms.TextBox();
            this.lbTotalCostExVAT = new System.Windows.Forms.Label();
            this.bindingLookupPackSize = new System.Windows.Forms.BindingSource(this.components);
            this.bindingLookupSupplier = new System.Windows.Forms.BindingSource(this.components);
            this.adapterLookupSupplier = new RBOS.ItemDataSetTableAdapters.LookupSupplierTableAdapter();
            this.bindingLookupStatus = new System.Windows.Forms.BindingSource(this.components);
            this.adapterLookupStatus = new RBOS.ItemDataSetTableAdapters.LookupStatusTableAdapter();
            this.adapterOrderHeaderSingle = new RBOS.ItemDataSetTableAdapters.OrderHeaderSingleTableAdapter();
            this.adapterRelOrderDetails = new RBOS.ItemDataSetTableAdapters.OrderDetailsTableAdapter();
            this.adapterLookupPackSize = new RBOS.ItemDataSetTableAdapters.LookupPackSizeTableAdapter();
            this.dtDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.dtOrderingDate = new System.Windows.Forms.DateTimePicker();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.lblReitanID = new System.Windows.Forms.Label();
            this.gridOrderDetails = new DRS.Extensions.DRS_DataGridView();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostExVat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderingNumberButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colPackType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colKolli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKolliCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderingNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceivedQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.bindingOrderHeaderSingle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingRelOrderDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupPackSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupSupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOrderDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(616, 521);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "[Cancel]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndClose.Location = new System.Drawing.Point(495, 521);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(115, 23);
            this.btnSaveAndClose.TabIndex = 5;
            this.btnSaveAndClose.Text = "[Save and Close]";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // txtOrderID
            // 
            this.txtOrderID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingOrderHeaderSingle, "OrderID", true));
            this.txtOrderID.Location = new System.Drawing.Point(113, 12);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.ReadOnly = true;
            this.txtOrderID.Size = new System.Drawing.Size(74, 20);
            this.txtOrderID.TabIndex = 2;
            // 
            // bindingOrderHeaderSingle
            // 
            this.bindingOrderHeaderSingle.DataMember = "OrderHeaderSingle";
            this.bindingOrderHeaderSingle.DataSource = this.dsItem;
            // 
            // dsItem
            // 
            this.dsItem.DataSetName = "ItemDataSet";
            this.dsItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtSupplierID
            // 
            this.txtSupplierID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingOrderHeaderSingle, "SupplierID", true));
            this.txtSupplierID.Location = new System.Drawing.Point(113, 38);
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.ReadOnly = true;
            this.txtSupplierID.Size = new System.Drawing.Size(74, 20);
            this.txtSupplierID.TabIndex = 3;
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingOrderHeaderSingle, "SupplierID", true));
            this.txtSupplierName.Location = new System.Drawing.Point(113, 64);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.ReadOnly = true;
            this.txtSupplierName.Size = new System.Drawing.Size(182, 20);
            this.txtSupplierName.TabIndex = 6;
            this.txtSupplierName.TextChanged += new System.EventHandler(this.txtSupplierName_TextChanged);
            // 
            // lbOrderID
            // 
            this.lbOrderID.AutoSize = true;
            this.lbOrderID.Location = new System.Drawing.Point(10, 15);
            this.lbOrderID.Name = "lbOrderID";
            this.lbOrderID.Size = new System.Drawing.Size(50, 13);
            this.lbOrderID.TabIndex = 7;
            this.lbOrderID.Text = "[OrderID]";
            // 
            // lbSupplierID
            // 
            this.lbSupplierID.AutoSize = true;
            this.lbSupplierID.Location = new System.Drawing.Point(10, 41);
            this.lbSupplierID.Name = "lbSupplierID";
            this.lbSupplierID.Size = new System.Drawing.Size(62, 13);
            this.lbSupplierID.TabIndex = 8;
            this.lbSupplierID.Text = "[SupplierID]";
            // 
            // lbSupplierName
            // 
            this.lbSupplierName.AutoSize = true;
            this.lbSupplierName.Location = new System.Drawing.Point(10, 67);
            this.lbSupplierName.Name = "lbSupplierName";
            this.lbSupplierName.Size = new System.Drawing.Size(79, 13);
            this.lbSupplierName.TabIndex = 9;
            this.lbSupplierName.Text = "[SupplierName]";
            // 
            // lbOrderingDate
            // 
            this.lbOrderingDate.AutoSize = true;
            this.lbOrderingDate.Location = new System.Drawing.Point(352, 41);
            this.lbOrderingDate.Name = "lbOrderingDate";
            this.lbOrderingDate.Size = new System.Drawing.Size(79, 13);
            this.lbOrderingDate.TabIndex = 10;
            this.lbOrderingDate.Text = "[Ordering Date]";
            // 
            // lbDeliveryDate
            // 
            this.lbDeliveryDate.AutoSize = true;
            this.lbDeliveryDate.Location = new System.Drawing.Point(352, 67);
            this.lbDeliveryDate.Name = "lbDeliveryDate";
            this.lbDeliveryDate.Size = new System.Drawing.Size(77, 13);
            this.lbDeliveryDate.TabIndex = 11;
            this.lbDeliveryDate.Text = "[Delivery Date]";
            // 
            // lbNumberOfDetails
            // 
            this.lbNumberOfDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbNumberOfDetails.AutoSize = true;
            this.lbNumberOfDetails.Location = new System.Drawing.Point(24, 488);
            this.lbNumberOfDetails.Name = "lbNumberOfDetails";
            this.lbNumberOfDetails.Size = new System.Drawing.Size(95, 13);
            this.lbNumberOfDetails.TabIndex = 13;
            this.lbNumberOfDetails.Text = "[Number of details]";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(352, 15);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(43, 13);
            this.lbStatus.TabIndex = 14;
            this.lbStatus.Text = "[Status]";
            // 
            // lbTotalCost
            // 
            this.lbTotalCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTotalCost.Location = new System.Drawing.Point(541, 488);
            this.lbTotalCost.Name = "lbTotalCost";
            this.lbTotalCost.Size = new System.Drawing.Size(74, 13);
            this.lbTotalCost.TabIndex = 15;
            this.lbTotalCost.Text = "[Total Cost]";
            this.lbTotalCost.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtStatus
            // 
            this.txtStatus.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingOrderHeaderSingle, "OrderStatus", true));
            this.txtStatus.Location = new System.Drawing.Point(475, 12);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(96, 20);
            this.txtStatus.TabIndex = 21;
            this.txtStatus.TextChanged += new System.EventHandler(this.txtStatus_TextChanged);
            // 
            // bindingRelOrderDetails
            // 
            this.bindingRelOrderDetails.DataMember = "OrderHeaderSingle_OrderDetails";
            this.bindingRelOrderDetails.DataSource = this.bindingOrderHeaderSingle;
            // 
            // txtNumberOfDetails
            // 
            this.txtNumberOfDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNumberOfDetails.Location = new System.Drawing.Point(125, 485);
            this.txtNumberOfDetails.Name = "txtNumberOfDetails";
            this.txtNumberOfDetails.ReadOnly = true;
            this.txtNumberOfDetails.Size = new System.Drawing.Size(34, 20);
            this.txtNumberOfDetails.TabIndex = 23;
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalCost.Location = new System.Drawing.Point(621, 485);
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.ReadOnly = true;
            this.txtTotalCost.Size = new System.Drawing.Size(70, 20);
            this.txtTotalCost.TabIndex = 24;
            this.txtTotalCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSaveAndSend
            // 
            this.btnSaveAndSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndSend.Location = new System.Drawing.Point(376, 521);
            this.btnSaveAndSend.Name = "btnSaveAndSend";
            this.btnSaveAndSend.Size = new System.Drawing.Size(113, 23);
            this.btnSaveAndSend.TabIndex = 4;
            this.btnSaveAndSend.Text = "[Save and Send]";
            this.btnSaveAndSend.UseVisualStyleBackColor = true;
            this.btnSaveAndSend.Click += new System.EventHandler(this.btnSaveAndSend_Click);
            // 
            // btnBook
            // 
            this.btnBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBook.Location = new System.Drawing.Point(295, 503);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(75, 23);
            this.btnBook.TabIndex = 27;
            this.btnBook.Text = "[Book]";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Visible = false;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // btnReceive
            // 
            this.btnReceive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReceive.Enabled = false;
            this.btnReceive.Location = new System.Drawing.Point(295, 521);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(75, 23);
            this.btnReceive.TabIndex = 28;
            this.btnReceive.Text = "[Receive]";
            this.btnReceive.UseVisualStyleBackColor = true;
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(214, 521);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 29;
            this.btnPrint.Text = "[Print]";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lbSentDate
            // 
            this.lbSentDate.AutoSize = true;
            this.lbSentDate.Location = new System.Drawing.Point(352, 92);
            this.lbSentDate.Name = "lbSentDate";
            this.lbSentDate.Size = new System.Drawing.Size(61, 13);
            this.lbSentDate.TabIndex = 30;
            this.lbSentDate.Text = "[Sent Date]";
            // 
            // txtSentDate
            // 
            this.txtSentDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingOrderHeaderSingle, "SentDate", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "g"));
            this.txtSentDate.Location = new System.Drawing.Point(475, 89);
            this.txtSentDate.Name = "txtSentDate";
            this.txtSentDate.ReadOnly = true;
            this.txtSentDate.Size = new System.Drawing.Size(96, 20);
            this.txtSentDate.TabIndex = 31;
            // 
            // btnAddItemInRecvMode
            // 
            this.btnAddItemInRecvMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddItemInRecvMode.Location = new System.Drawing.Point(12, 521);
            this.btnAddItemInRecvMode.Name = "btnAddItemInRecvMode";
            this.btnAddItemInRecvMode.Size = new System.Drawing.Size(75, 23);
            this.btnAddItemInRecvMode.TabIndex = 32;
            this.btnAddItemInRecvMode.Text = "[Add Item]";
            this.btnAddItemInRecvMode.UseVisualStyleBackColor = true;
            this.btnAddItemInRecvMode.Visible = false;
            this.btnAddItemInRecvMode.Click += new System.EventHandler(this.btnAddItemInRecvMode_Click);
            // 
            // btnCreateAsDraft
            // 
            this.btnCreateAsDraft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateAsDraft.Location = new System.Drawing.Point(93, 521);
            this.btnCreateAsDraft.Name = "btnCreateAsDraft";
            this.btnCreateAsDraft.Size = new System.Drawing.Size(115, 23);
            this.btnCreateAsDraft.TabIndex = 33;
            this.btnCreateAsDraft.Text = "[Create as draft]";
            this.btnCreateAsDraft.UseVisualStyleBackColor = true;
            this.btnCreateAsDraft.Click += new System.EventHandler(this.btnCreateAsDraft_Click);
            // 
            // txtTotalCostExVAT
            // 
            this.txtTotalCostExVAT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalCostExVAT.Location = new System.Drawing.Point(465, 485);
            this.txtTotalCostExVAT.Name = "txtTotalCostExVAT";
            this.txtTotalCostExVAT.ReadOnly = true;
            this.txtTotalCostExVAT.Size = new System.Drawing.Size(70, 20);
            this.txtTotalCostExVAT.TabIndex = 35;
            this.txtTotalCostExVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbTotalCostExVAT
            // 
            this.lbTotalCostExVAT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTotalCostExVAT.Location = new System.Drawing.Point(332, 487);
            this.lbTotalCostExVAT.Name = "lbTotalCostExVAT";
            this.lbTotalCostExVAT.Size = new System.Drawing.Size(127, 13);
            this.lbTotalCostExVAT.TabIndex = 34;
            this.lbTotalCostExVAT.Text = "[Total Cost ex. VAT]";
            this.lbTotalCostExVAT.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            // adapterOrderHeaderSingle
            // 
            this.adapterOrderHeaderSingle.ClearBeforeFill = true;
            // 
            // adapterRelOrderDetails
            // 
            this.adapterRelOrderDetails.ClearBeforeFill = true;
            // 
            // adapterLookupPackSize
            // 
            this.adapterLookupPackSize.ClearBeforeFill = true;
            // 
            // dtDeliveryDate
            // 
            this.dtDeliveryDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingOrderHeaderSingle, "DeliveryDate", true));
            this.dtDeliveryDate.Location = new System.Drawing.Point(475, 63);
            this.dtDeliveryDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtDeliveryDate.Name = "dtDeliveryDate";
            this.dtDeliveryDate.Size = new System.Drawing.Size(151, 20);
            this.dtDeliveryDate.TabIndex = 36;
            // 
            // dtOrderingDate
            // 
            this.dtOrderingDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingOrderHeaderSingle, "OrderDate", true));
            this.dtOrderingDate.Location = new System.Drawing.Point(475, 38);
            this.dtOrderingDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtOrderingDate.Name = "dtOrderingDate";
            this.dtOrderingDate.Size = new System.Drawing.Size(151, 20);
            this.dtOrderingDate.TabIndex = 37;
            // 
            // textBox15
            // 
            this.textBox15.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingOrderHeaderSingle, "BHHTOrderID", true));
            this.textBox15.Location = new System.Drawing.Point(113, 96);
            this.textBox15.Name = "textBox15";
            this.textBox15.ReadOnly = true;
            this.textBox15.Size = new System.Drawing.Size(182, 20);
            this.textBox15.TabIndex = 38;
            // 
            // lblReitanID
            // 
            this.lblReitanID.AutoSize = true;
            this.lblReitanID.Location = new System.Drawing.Point(14, 99);
            this.lblReitanID.Name = "lblReitanID";
            this.lblReitanID.Size = new System.Drawing.Size(52, 13);
            this.lblReitanID.TabIndex = 39;
            this.lblReitanID.Text = "Reitan ID";
            // 
            // gridOrderDetails
            // 
            this.gridOrderDetails.AllowUserToResizeColumns = false;
            this.gridOrderDetails.AllowUserToResizeRows = false;
            this.gridOrderDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridOrderDetails.AutoGenerateColumns = false;
            this.gridOrderDetails.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridOrderDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridOrderDetails.ColumnHeadersHeight = 21;
            this.gridOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridOrderDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDescription,
            this.colCostExVat,
            this.colOrderingNumberButton,
            this.colPackType,
            this.colKolli,
            this.colKolliCost,
            this.colOrderingNumber,
            this.colCost,
            this.colQuantity,
            this.colReceivedQuantity});
            this.gridOrderDetails.DataSource = this.bindingRelOrderDetails;
            this.gridOrderDetails.Location = new System.Drawing.Point(12, 122);
            this.gridOrderDetails.MultiSelect = false;
            this.gridOrderDetails.Name = "gridOrderDetails";
            this.gridOrderDetails.RowHeadersWidth = 25;
            this.gridOrderDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridOrderDetails.Size = new System.Drawing.Size(679, 357);
            this.gridOrderDetails.TabIndex = 3;
            this.gridOrderDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOrderDetails_CellContentClick);
            this.gridOrderDetails.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOrderDetails_CellEndEdit);
            this.gridOrderDetails.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gridOrderDetails_CellPainting);
            this.gridOrderDetails.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOrderDetails_CellValidated);
            this.gridOrderDetails.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gridOrderDetails_CellValidating);
            this.gridOrderDetails.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.gridOrderDetails.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.gridOrderDetails_RowsRemoved);
            this.gridOrderDetails.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridOrderDetails_RowValidating);
            this.gridOrderDetails.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridOrderDetails_KeyUp);
            // 
            // colDescription
            // 
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescription.DataPropertyName = "ReceiptText";
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.colDescription.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDescription.HeaderText = "Desc.";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colCostExVat
            // 
            this.colCostExVat.DataPropertyName = "CostExVAT";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.colCostExVat.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCostExVat.HeaderText = "[Cost ex. VAT]";
            this.colCostExVat.Name = "colCostExVat";
            this.colCostExVat.ReadOnly = true;
            this.colCostExVat.Width = 65;
            // 
            // colOrderingNumberButton
            // 
            this.colOrderingNumberButton.HeaderText = "";
            this.colOrderingNumberButton.Name = "colOrderingNumberButton";
            this.colOrderingNumberButton.Width = 25;
            // 
            // colPackType
            // 
            this.colPackType.DataPropertyName = "PackType";
            this.colPackType.DataSource = this.bindingLookupPackSize;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            this.colPackType.DefaultCellStyle = dataGridViewCellStyle3;
            this.colPackType.DisplayMember = "PackTypeName";
            this.colPackType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colPackType.HeaderText = "SP";
            this.colPackType.Name = "colPackType";
            this.colPackType.ReadOnly = true;
            this.colPackType.ValueMember = "PackType";
            this.colPackType.Width = 50;
            // 
            // colKolli
            // 
            this.colKolli.DataPropertyName = "KolliSize";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            this.colKolli.DefaultCellStyle = dataGridViewCellStyle4;
            this.colKolli.HeaderText = "Kolli";
            this.colKolli.Name = "colKolli";
            this.colKolli.ReadOnly = true;
            this.colKolli.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colKolli.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colKolli.Width = 40;
            // 
            // colKolliCost
            // 
            this.colKolliCost.DataPropertyName = "PackageCost";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Format = "N2";
            this.colKolliCost.DefaultCellStyle = dataGridViewCellStyle5;
            this.colKolliCost.HeaderText = "Kolli cost";
            this.colKolliCost.Name = "colKolliCost";
            this.colKolliCost.ReadOnly = true;
            this.colKolliCost.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colKolliCost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.colCost.DefaultCellStyle = dataGridViewCellStyle6;
            this.colCost.HeaderText = "Cost";
            this.colCost.Name = "colCost";
            this.colCost.ReadOnly = true;
            this.colCost.Width = 65;
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colQuantity.DefaultCellStyle = dataGridViewCellStyle7;
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colQuantity.Width = 50;
            // 
            // colReceivedQuantity
            // 
            this.colReceivedQuantity.DataPropertyName = "ReceivedQuantity";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            this.colReceivedQuantity.DefaultCellStyle = dataGridViewCellStyle8;
            this.colReceivedQuantity.HeaderText = "R.Quantity";
            this.colReceivedQuantity.Name = "colReceivedQuantity";
            this.colReceivedQuantity.ReadOnly = true;
            this.colReceivedQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colReceivedQuantity.Width = 60;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "OrderID";
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn1.HeaderText = "OrderID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "LineNo";
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle10;
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
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle11;
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
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle12;
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
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N2";
            dataGridViewCellStyle13.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle13;
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
            // OrderDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 556);
            this.Controls.Add(this.lblReitanID);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.dtOrderingDate);
            this.Controls.Add(this.dtDeliveryDate);
            this.Controls.Add(this.txtTotalCostExVAT);
            this.Controls.Add(this.lbTotalCostExVAT);
            this.Controls.Add(this.btnCreateAsDraft);
            this.Controls.Add(this.txtSentDate);
            this.Controls.Add(this.lbSentDate);
            this.Controls.Add(this.btnAddItemInRecvMode);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnReceive);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.lbOrderID);
            this.Controls.Add(this.txtOrderID);
            this.Controls.Add(this.btnSaveAndSend);
            this.Controls.Add(this.txtSupplierID);
            this.Controls.Add(this.txtTotalCost);
            this.Controls.Add(this.txtNumberOfDetails);
            this.Controls.Add(this.txtSupplierName);
            this.Controls.Add(this.gridOrderDetails);
            this.Controls.Add(this.lbSupplierID);
            this.Controls.Add(this.lbTotalCost);
            this.Controls.Add(this.lbNumberOfDetails);
            this.Controls.Add(this.lbSupplierName);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.lbOrderingDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lbDeliveryDate);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.txtStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OrderDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OrderDetailsBaseForm";
            this.Load += new System.EventHandler(this.OrderDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingOrderHeaderSingle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingRelOrderDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupPackSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupSupplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOrderDetails)).EndInit();
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
        private System.Windows.Forms.Label lbOrderID;
        private System.Windows.Forms.Label lbSupplierID;
        private System.Windows.Forms.Label lbSupplierName;
        private System.Windows.Forms.Label lbOrderingDate;
        private System.Windows.Forms.Label lbDeliveryDate;
        private System.Windows.Forms.Label lbNumberOfDetails;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label lbTotalCost;
        private System.Windows.Forms.TextBox txtStatus;
        private DRS.Extensions.DRS_DataGridView gridOrderDetails;
        private System.Windows.Forms.TextBox txtNumberOfDetails;
        private System.Windows.Forms.TextBox txtTotalCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Button btnSaveAndSend;
        private System.Windows.Forms.BindingSource bindingLookupStatus;
        private RBOS.ItemDataSetTableAdapters.LookupStatusTableAdapter adapterLookupStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.BindingSource bindingOrderHeaderSingle;
        private RBOS.ItemDataSetTableAdapters.OrderHeaderSingleTableAdapter adapterOrderHeaderSingle;
        private System.Windows.Forms.BindingSource bindingRelOrderDetails;
        private RBOS.ItemDataSetTableAdapters.OrderDetailsTableAdapter adapterRelOrderDetails;
        private System.Windows.Forms.BindingSource bindingLookupPackSize;
        private RBOS.ItemDataSetTableAdapters.LookupPackSizeTableAdapter adapterLookupPackSize;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Button btnReceive;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lbSentDate;
        private System.Windows.Forms.TextBox txtSentDate;
        private System.Windows.Forms.Button btnAddItemInRecvMode;
        private System.Windows.Forms.Button btnCreateAsDraft;
        private System.Windows.Forms.TextBox txtTotalCostExVAT;
        private System.Windows.Forms.Label lbTotalCostExVAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostExVat;
        private System.Windows.Forms.DataGridViewButtonColumn colOrderingNumberButton;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPackType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKolli;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKolliCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderingNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceivedQuantity;
        private System.Windows.Forms.DateTimePicker dtDeliveryDate;
        private System.Windows.Forms.DateTimePicker dtOrderingDate;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.Label lblReitanID;
    }
}