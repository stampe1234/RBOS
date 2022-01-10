namespace RBOS
{
    partial class SalesPackDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesPackDetailsForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbPrimary = new System.Windows.Forms.Label();
            this.lbPackSize = new System.Windows.Forms.Label();
            this.lbManualPrice = new System.Windows.Forms.Label();
            this.lbBarcodes = new System.Windows.Forms.Label();
            this.lbSalesPrice = new System.Windows.Forms.Label();
            this.chkPrimary = new System.Windows.Forms.CheckBox();
            this.bindingSalesPack = new System.Windows.Forms.BindingSource(this.components);
            this.dsItem = new RBOS.ItemDataSet();
            this.comboPackSize = new System.Windows.Forms.ComboBox();
            this.bindingLookupPackSize = new System.Windows.Forms.BindingSource(this.components);
            this.chkManualPrice = new System.Windows.Forms.CheckBox();
            this.btnBarcodes = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbNewShelfMarker = new System.Windows.Forms.Label();
            this.chkNewShelfMarker = new System.Windows.Forms.CheckBox();
            this.lbNumShelfMarkers = new System.Windows.Forms.Label();
            this.groupUnitPrice = new System.Windows.Forms.GroupBox();
            this.chkUnitPriceNotShown = new System.Windows.Forms.CheckBox();
            this.txtUnitContent = new System.Windows.Forms.NumericUpDown();
            this.lbPricePerXX = new System.Windows.Forms.Label();
            this.lbUnitContent = new System.Windows.Forms.Label();
            this.lbShowPricePr = new System.Windows.Forms.Label();
            this.txtPricePerXX = new System.Windows.Forms.TextBox();
            this.txtShowPricePerUnit = new System.Windows.Forms.TextBox();
            this.comboUnitDesc = new System.Windows.Forms.ComboBox();
            this.bindingLookupUnit = new System.Windows.Forms.BindingSource(this.components);
            this.lbUnitDescription = new System.Windows.Forms.Label();
            this.txtPrimaryBarcode = new System.Windows.Forms.TextBox();
            this.txtNumBarcodes = new System.Windows.Forms.TextBox();
            this.txtSalesPrice = new System.Windows.Forms.TextBox();
            this.groupChainItem = new System.Windows.Forms.GroupBox();
            this.btnChainRemove = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lbChainReceiptText = new System.Windows.Forms.Label();
            this.txtChainSalesPackDesc = new System.Windows.Forms.TextBox();
            this.bindingRelSalesPackChainItem = new System.Windows.Forms.BindingSource(this.components);
            this.txtChainSalesPack = new System.Windows.Forms.TextBox();
            this.lbChainSalesPack = new System.Windows.Forms.Label();
            this.lbChainBarcode = new System.Windows.Forms.Label();
            this.btnChainLookup = new System.Windows.Forms.Button();
            this.txtChainBarcode = new System.Windows.Forms.TextBox();
            this.txtNumShelfMarkers = new System.Windows.Forms.NumericUpDown();
            this.lbReceipt = new System.Windows.Forms.Label();
            this.txtReceipt = new System.Windows.Forms.TextBox();
            this.chkUpdateRSM = new System.Windows.Forms.CheckBox();
            this.lbUpdateRSM = new System.Windows.Forms.Label();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.chkUpdateStations = new System.Windows.Forms.CheckBox();
            this.lbUpdateStations = new System.Windows.Forms.Label();
            this.lbFuturePrices = new System.Windows.Forms.Label();
            this.bindingSalesPackFuturePrices = new System.Windows.Forms.BindingSource(this.components);
            this.adapterLookupPackSize = new RBOS.ItemDataSetTableAdapters.LookupPackSizeTableAdapter();
            this.adapterLookupUnit = new RBOS.ItemDataSetTableAdapters.LookupUnitTableAdapter();
            this.adapterSalesPackTable = new RBOS.ItemDataSetTableAdapters.SalesPackTableAdapter();
            this.adapterLookupBarcodeName = new RBOS.ItemDataSetTableAdapters.LookupBarcodeNameTableAdapter();
            this.adapterRelSalesPackChainItem = new RBOS.ItemDataSetTableAdapters.ChainItemTableAdapter();
            this.adapterSalesPackFuturePrices = new RBOS.ItemDataSetTableAdapters.SalesPackFuturePricesTableAdapter();
            this.gridSalesPackFuturePrices = new DRS.Extensions.DRS_DataGridView();
            this.colActivationDate = new DRS.Extensions.DRS_CalendarColumn();
            this.colOrigin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalesPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSentToStations = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colClosedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPerform = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtBCType = new DRS.Extensions.DRS_LookupTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSalesPack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupPackSize)).BeginInit();
            this.groupUnitPrice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupUnit)).BeginInit();
            this.groupChainItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingRelSalesPackChainItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumShelfMarkers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSalesPackFuturePrices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSalesPackFuturePrices)).BeginInit();
            this.SuspendLayout();
            // 
            // lbPrimary
            // 
            this.lbPrimary.AutoSize = true;
            this.lbPrimary.Location = new System.Drawing.Point(12, 13);
            this.lbPrimary.Name = "lbPrimary";
            this.lbPrimary.Size = new System.Drawing.Size(47, 13);
            this.lbPrimary.TabIndex = 0;
            this.lbPrimary.Text = "[Primary]";
            // 
            // lbPackSize
            // 
            this.lbPackSize.AutoSize = true;
            this.lbPackSize.Location = new System.Drawing.Point(12, 35);
            this.lbPackSize.Name = "lbPackSize";
            this.lbPackSize.Size = new System.Drawing.Size(58, 13);
            this.lbPackSize.TabIndex = 1;
            this.lbPackSize.Text = "[PackSize]";
            // 
            // lbManualPrice
            // 
            this.lbManualPrice.AutoSize = true;
            this.lbManualPrice.Location = new System.Drawing.Point(12, 60);
            this.lbManualPrice.Name = "lbManualPrice";
            this.lbManualPrice.Size = new System.Drawing.Size(75, 13);
            this.lbManualPrice.TabIndex = 2;
            this.lbManualPrice.Text = "[Manual Price]";
            // 
            // lbBarcodes
            // 
            this.lbBarcodes.AutoSize = true;
            this.lbBarcodes.Location = new System.Drawing.Point(12, 111);
            this.lbBarcodes.Name = "lbBarcodes";
            this.lbBarcodes.Size = new System.Drawing.Size(58, 13);
            this.lbBarcodes.TabIndex = 3;
            this.lbBarcodes.Text = "[Barcodes]";
            // 
            // lbSalesPrice
            // 
            this.lbSalesPrice.AutoSize = true;
            this.lbSalesPrice.Location = new System.Drawing.Point(12, 83);
            this.lbSalesPrice.Name = "lbSalesPrice";
            this.lbSalesPrice.Size = new System.Drawing.Size(66, 13);
            this.lbSalesPrice.TabIndex = 4;
            this.lbSalesPrice.Text = "[Sales Price]";
            // 
            // chkPrimary
            // 
            this.chkPrimary.AutoSize = true;
            this.chkPrimary.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSalesPack, "IsPrimary", true));
            this.chkPrimary.Enabled = false;
            this.chkPrimary.Location = new System.Drawing.Point(124, 13);
            this.chkPrimary.Name = "chkPrimary";
            this.chkPrimary.Size = new System.Drawing.Size(15, 14);
            this.chkPrimary.TabIndex = 11;
            this.chkPrimary.UseVisualStyleBackColor = true;
            // 
            // bindingSalesPack
            // 
            this.bindingSalesPack.DataMember = "SalesPack";
            this.bindingSalesPack.DataSource = this.dsItem;
            // 
            // dsItem
            // 
            this.dsItem.DataSetName = "ItemDataSet";
            this.dsItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboPackSize
            // 
            this.comboPackSize.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSalesPack, "PackType", true));
            this.comboPackSize.DataSource = this.bindingLookupPackSize;
            this.comboPackSize.DisplayMember = "PackTypeName";
            this.comboPackSize.Enabled = false;
            this.comboPackSize.FormattingEnabled = true;
            this.comboPackSize.Location = new System.Drawing.Point(124, 32);
            this.comboPackSize.Name = "comboPackSize";
            this.comboPackSize.Size = new System.Drawing.Size(71, 21);
            this.comboPackSize.TabIndex = 12;
            this.comboPackSize.ValueMember = "PackType";
            // 
            // bindingLookupPackSize
            // 
            this.bindingLookupPackSize.DataMember = "LookupPackSize";
            this.bindingLookupPackSize.DataSource = this.dsItem;
            // 
            // chkManualPrice
            // 
            this.chkManualPrice.AutoSize = true;
            this.chkManualPrice.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSalesPack, "ManualPrice", true));
            this.chkManualPrice.Location = new System.Drawing.Point(124, 60);
            this.chkManualPrice.Name = "chkManualPrice";
            this.chkManualPrice.Size = new System.Drawing.Size(15, 14);
            this.chkManualPrice.TabIndex = 13;
            this.chkManualPrice.UseVisualStyleBackColor = true;
            this.chkManualPrice.Validated += new System.EventHandler(this.chkManualPrice_Validated);
            // 
            // btnBarcodes
            // 
            this.btnBarcodes.Image = ((System.Drawing.Image)(resources.GetObject("btnBarcodes.Image")));
            this.btnBarcodes.Location = new System.Drawing.Point(247, 134);
            this.btnBarcodes.Name = "btnBarcodes";
            this.btnBarcodes.Size = new System.Drawing.Size(28, 23);
            this.btnBarcodes.TabIndex = 15;
            this.btnBarcodes.UseVisualStyleBackColor = true;
            this.btnBarcodes.Click += new System.EventHandler(this.btnBarcodes_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(486, 371);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbNewShelfMarker
            // 
            this.lbNewShelfMarker.AutoSize = true;
            this.lbNewShelfMarker.Location = new System.Drawing.Point(12, 183);
            this.lbNewShelfMarker.Name = "lbNewShelfMarker";
            this.lbNewShelfMarker.Size = new System.Drawing.Size(95, 13);
            this.lbNewShelfMarker.TabIndex = 18;
            this.lbNewShelfMarker.Text = "[New shelf marker]";
            // 
            // chkNewShelfMarker
            // 
            this.chkNewShelfMarker.AutoSize = true;
            this.chkNewShelfMarker.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSalesPack, "UpdateShelfLabel", true));
            this.chkNewShelfMarker.Enabled = false;
            this.chkNewShelfMarker.Location = new System.Drawing.Point(124, 183);
            this.chkNewShelfMarker.Name = "chkNewShelfMarker";
            this.chkNewShelfMarker.Size = new System.Drawing.Size(15, 14);
            this.chkNewShelfMarker.TabIndex = 19;
            this.chkNewShelfMarker.UseVisualStyleBackColor = true;
            // 
            // lbNumShelfMarkers
            // 
            this.lbNumShelfMarkers.AutoSize = true;
            this.lbNumShelfMarkers.Location = new System.Drawing.Point(12, 205);
            this.lbNumShelfMarkers.Name = "lbNumShelfMarkers";
            this.lbNumShelfMarkers.Size = new System.Drawing.Size(100, 13);
            this.lbNumShelfMarkers.TabIndex = 20;
            this.lbNumShelfMarkers.Text = "[Num shelf markers]";
            // 
            // groupUnitPrice
            // 
            this.groupUnitPrice.Controls.Add(this.chkUnitPriceNotShown);
            this.groupUnitPrice.Controls.Add(this.txtUnitContent);
            this.groupUnitPrice.Controls.Add(this.lbPricePerXX);
            this.groupUnitPrice.Controls.Add(this.lbUnitContent);
            this.groupUnitPrice.Controls.Add(this.lbShowPricePr);
            this.groupUnitPrice.Controls.Add(this.txtPricePerXX);
            this.groupUnitPrice.Controls.Add(this.txtShowPricePerUnit);
            this.groupUnitPrice.Controls.Add(this.comboUnitDesc);
            this.groupUnitPrice.Controls.Add(this.lbUnitDescription);
            this.groupUnitPrice.Location = new System.Drawing.Point(294, 12);
            this.groupUnitPrice.Name = "groupUnitPrice";
            this.groupUnitPrice.Size = new System.Drawing.Size(266, 155);
            this.groupUnitPrice.TabIndex = 22;
            this.groupUnitPrice.TabStop = false;
            this.groupUnitPrice.Text = "[Unit Price]";
            // 
            // chkUnitPriceNotShown
            // 
            this.chkUnitPriceNotShown.AutoSize = true;
            this.chkUnitPriceNotShown.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bindingSalesPack, "UnitPriceNotShown", true));
            this.chkUnitPriceNotShown.Enabled = false;
            this.chkUnitPriceNotShown.Location = new System.Drawing.Point(9, 19);
            this.chkUnitPriceNotShown.Name = "chkUnitPriceNotShown";
            this.chkUnitPriceNotShown.Size = new System.Drawing.Size(157, 17);
            this.chkUnitPriceNotShown.TabIndex = 35;
            this.chkUnitPriceNotShown.Text = "[Do not show on shelf label]";
            this.chkUnitPriceNotShown.UseVisualStyleBackColor = true;
            // 
            // txtUnitContent
            // 
            this.txtUnitContent.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSalesPack, "EnhedsIndhold", true));
            this.txtUnitContent.DecimalPlaces = 2;
            this.txtUnitContent.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.txtUnitContent.Location = new System.Drawing.Point(162, 98);
            this.txtUnitContent.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtUnitContent.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txtUnitContent.Name = "txtUnitContent";
            this.txtUnitContent.ReadOnly = true;
            this.txtUnitContent.Size = new System.Drawing.Size(59, 20);
            this.txtUnitContent.TabIndex = 31;
            this.txtUnitContent.ThousandsSeparator = true;
            this.txtUnitContent.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtUnitContent.Validated += new System.EventHandler(this.txtUnitContent_Validated);
            // 
            // lbPricePerXX
            // 
            this.lbPricePerXX.AutoSize = true;
            this.lbPricePerXX.Location = new System.Drawing.Point(6, 127);
            this.lbPricePerXX.Name = "lbPricePerXX";
            this.lbPricePerXX.Size = new System.Drawing.Size(71, 13);
            this.lbPricePerXX.TabIndex = 29;
            this.lbPricePerXX.Text = "[Price per xx.]";
            // 
            // lbUnitContent
            // 
            this.lbUnitContent.AutoSize = true;
            this.lbUnitContent.Location = new System.Drawing.Point(6, 101);
            this.lbUnitContent.Name = "lbUnitContent";
            this.lbUnitContent.Size = new System.Drawing.Size(71, 13);
            this.lbUnitContent.TabIndex = 30;
            this.lbUnitContent.Text = "[Unit content]";
            // 
            // lbShowPricePr
            // 
            this.lbShowPricePr.AutoSize = true;
            this.lbShowPricePr.Location = new System.Drawing.Point(6, 75);
            this.lbShowPricePr.Name = "lbShowPricePr";
            this.lbShowPricePr.Size = new System.Drawing.Size(104, 13);
            this.lbShowPricePr.TabIndex = 31;
            this.lbShowPricePr.Text = "[Show price per unit]";
            // 
            // txtPricePerXX
            // 
            this.txtPricePerXX.Location = new System.Drawing.Point(162, 124);
            this.txtPricePerXX.Name = "txtPricePerXX";
            this.txtPricePerXX.ReadOnly = true;
            this.txtPricePerXX.Size = new System.Drawing.Size(59, 20);
            this.txtPricePerXX.TabIndex = 32;
            // 
            // txtShowPricePerUnit
            // 
            this.txtShowPricePerUnit.Location = new System.Drawing.Point(162, 71);
            this.txtShowPricePerUnit.Name = "txtShowPricePerUnit";
            this.txtShowPricePerUnit.ReadOnly = true;
            this.txtShowPricePerUnit.Size = new System.Drawing.Size(59, 20);
            this.txtShowPricePerUnit.TabIndex = 34;
            // 
            // comboUnitDesc
            // 
            this.comboUnitDesc.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSalesPack, "SalesPackType", true));
            this.comboUnitDesc.DataSource = this.bindingLookupUnit;
            this.comboUnitDesc.DisplayMember = "Description";
            this.comboUnitDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboUnitDesc.FormattingEnabled = true;
            this.comboUnitDesc.Location = new System.Drawing.Point(162, 45);
            this.comboUnitDesc.Name = "comboUnitDesc";
            this.comboUnitDesc.Size = new System.Drawing.Size(59, 21);
            this.comboUnitDesc.TabIndex = 24;
            this.comboUnitDesc.ValueMember = "ID";
            this.comboUnitDesc.SelectedIndexChanged += new System.EventHandler(this.comboUnitDesc_SelectedIndexChanged);
            // 
            // bindingLookupUnit
            // 
            this.bindingLookupUnit.DataMember = "LookupUnit";
            this.bindingLookupUnit.DataSource = this.dsItem;
            // 
            // lbUnitDescription
            // 
            this.lbUnitDescription.AutoSize = true;
            this.lbUnitDescription.Location = new System.Drawing.Point(6, 48);
            this.lbUnitDescription.Name = "lbUnitDescription";
            this.lbUnitDescription.Size = new System.Drawing.Size(88, 13);
            this.lbUnitDescription.TabIndex = 23;
            this.lbUnitDescription.Text = "[Unit Description]";
            // 
            // txtPrimaryBarcode
            // 
            this.txtPrimaryBarcode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSalesPack, "Barcode", true));
            this.txtPrimaryBarcode.Location = new System.Drawing.Point(124, 108);
            this.txtPrimaryBarcode.Name = "txtPrimaryBarcode";
            this.txtPrimaryBarcode.ReadOnly = true;
            this.txtPrimaryBarcode.Size = new System.Drawing.Size(151, 20);
            this.txtPrimaryBarcode.TabIndex = 27;
            // 
            // txtNumBarcodes
            // 
            this.txtNumBarcodes.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSalesPack, "NumBarcodesCalc", true));
            this.txtNumBarcodes.Location = new System.Drawing.Point(220, 136);
            this.txtNumBarcodes.Name = "txtNumBarcodes";
            this.txtNumBarcodes.ReadOnly = true;
            this.txtNumBarcodes.Size = new System.Drawing.Size(21, 20);
            this.txtNumBarcodes.TabIndex = 28;
            // 
            // txtSalesPrice
            // 
            this.txtSalesPrice.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSalesPack, "SalesPrice", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.txtSalesPrice.Location = new System.Drawing.Point(124, 80);
            this.txtSalesPrice.Name = "txtSalesPrice";
            this.txtSalesPrice.ReadOnly = true;
            this.txtSalesPrice.Size = new System.Drawing.Size(60, 20);
            this.txtSalesPrice.TabIndex = 32;
            this.txtSalesPrice.Validated += new System.EventHandler(this.txtSalesPrice_Validated);
            // 
            // groupChainItem
            // 
            this.groupChainItem.Controls.Add(this.btnChainRemove);
            this.groupChainItem.Controls.Add(this.lbChainReceiptText);
            this.groupChainItem.Controls.Add(this.txtChainSalesPackDesc);
            this.groupChainItem.Controls.Add(this.txtChainSalesPack);
            this.groupChainItem.Controls.Add(this.lbChainSalesPack);
            this.groupChainItem.Controls.Add(this.lbChainBarcode);
            this.groupChainItem.Controls.Add(this.btnChainLookup);
            this.groupChainItem.Controls.Add(this.txtChainBarcode);
            this.groupChainItem.Location = new System.Drawing.Point(294, 173);
            this.groupChainItem.Name = "groupChainItem";
            this.groupChainItem.Size = new System.Drawing.Size(266, 105);
            this.groupChainItem.TabIndex = 33;
            this.groupChainItem.TabStop = false;
            this.groupChainItem.Text = "[Chain Item]";
            // 
            // btnChainRemove
            // 
            this.btnChainRemove.ImageIndex = 1;
            this.btnChainRemove.ImageList = this.imageList1;
            this.btnChainRemove.Location = new System.Drawing.Point(227, 17);
            this.btnChainRemove.Name = "btnChainRemove";
            this.btnChainRemove.Size = new System.Drawing.Size(28, 23);
            this.btnChainRemove.TabIndex = 45;
            this.btnChainRemove.UseVisualStyleBackColor = true;
            this.btnChainRemove.Click += new System.EventHandler(this.btnChainRemove_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "search_16.gif");
            this.imageList1.Images.SetKeyName(1, "trash.gif");
            // 
            // lbChainReceiptText
            // 
            this.lbChainReceiptText.AutoSize = true;
            this.lbChainReceiptText.Location = new System.Drawing.Point(6, 74);
            this.lbChainReceiptText.Name = "lbChainReceiptText";
            this.lbChainReceiptText.Size = new System.Drawing.Size(70, 13);
            this.lbChainReceiptText.TabIndex = 44;
            this.lbChainReceiptText.Text = "[Receipt text]";
            // 
            // txtChainSalesPackDesc
            // 
            this.txtChainSalesPackDesc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingRelSalesPackChainItem, "ReceiptText", true));
            this.txtChainSalesPackDesc.Location = new System.Drawing.Point(92, 71);
            this.txtChainSalesPackDesc.Name = "txtChainSalesPackDesc";
            this.txtChainSalesPackDesc.ReadOnly = true;
            this.txtChainSalesPackDesc.Size = new System.Drawing.Size(163, 20);
            this.txtChainSalesPackDesc.TabIndex = 43;
            // 
            // bindingRelSalesPackChainItem
            // 
            this.bindingRelSalesPackChainItem.DataMember = "SalesPack_ChainItem";
            this.bindingRelSalesPackChainItem.DataSource = this.bindingSalesPack;
            // 
            // txtChainSalesPack
            // 
            this.txtChainSalesPack.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingRelSalesPackChainItem, "PackTypeName", true));
            this.txtChainSalesPack.Location = new System.Drawing.Point(92, 45);
            this.txtChainSalesPack.Name = "txtChainSalesPack";
            this.txtChainSalesPack.ReadOnly = true;
            this.txtChainSalesPack.Size = new System.Drawing.Size(163, 20);
            this.txtChainSalesPack.TabIndex = 42;
            // 
            // lbChainSalesPack
            // 
            this.lbChainSalesPack.AutoSize = true;
            this.lbChainSalesPack.Location = new System.Drawing.Point(6, 48);
            this.lbChainSalesPack.Name = "lbChainSalesPack";
            this.lbChainSalesPack.Size = new System.Drawing.Size(67, 13);
            this.lbChainSalesPack.TabIndex = 41;
            this.lbChainSalesPack.Text = "[Sales Pack]";
            // 
            // lbChainBarcode
            // 
            this.lbChainBarcode.AutoSize = true;
            this.lbChainBarcode.Location = new System.Drawing.Point(6, 22);
            this.lbChainBarcode.Name = "lbChainBarcode";
            this.lbChainBarcode.Size = new System.Drawing.Size(53, 13);
            this.lbChainBarcode.TabIndex = 37;
            this.lbChainBarcode.Text = "[Barcode]";
            // 
            // btnChainLookup
            // 
            this.btnChainLookup.ImageIndex = 0;
            this.btnChainLookup.ImageList = this.imageList1;
            this.btnChainLookup.Location = new System.Drawing.Point(193, 17);
            this.btnChainLookup.Name = "btnChainLookup";
            this.btnChainLookup.Size = new System.Drawing.Size(28, 23);
            this.btnChainLookup.TabIndex = 35;
            this.btnChainLookup.UseVisualStyleBackColor = true;
            this.btnChainLookup.Click += new System.EventHandler(this.btnChainLookup_Click);
            // 
            // txtChainBarcode
            // 
            this.txtChainBarcode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingRelSalesPackChainItem, "Barcode", true));
            this.txtChainBarcode.Location = new System.Drawing.Point(92, 19);
            this.txtChainBarcode.Name = "txtChainBarcode";
            this.txtChainBarcode.ReadOnly = true;
            this.txtChainBarcode.Size = new System.Drawing.Size(95, 20);
            this.txtChainBarcode.TabIndex = 36;
            // 
            // txtNumShelfMarkers
            // 
            this.txtNumShelfMarkers.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSalesPack, "NoOfShLabels", true));
            this.txtNumShelfMarkers.Enabled = false;
            this.txtNumShelfMarkers.Location = new System.Drawing.Point(124, 203);
            this.txtNumShelfMarkers.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtNumShelfMarkers.Name = "txtNumShelfMarkers";
            this.txtNumShelfMarkers.Size = new System.Drawing.Size(40, 20);
            this.txtNumShelfMarkers.TabIndex = 34;
            this.txtNumShelfMarkers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbReceipt
            // 
            this.lbReceipt.AutoSize = true;
            this.lbReceipt.Location = new System.Drawing.Point(12, 232);
            this.lbReceipt.Name = "lbReceipt";
            this.lbReceipt.Size = new System.Drawing.Size(74, 13);
            this.lbReceipt.TabIndex = 35;
            this.lbReceipt.Text = "[Receipt Text]";
            // 
            // txtReceipt
            // 
            this.txtReceipt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSalesPack, "ReceiptText", true));
            this.txtReceipt.Location = new System.Drawing.Point(124, 229);
            this.txtReceipt.MaxLength = 30;
            this.txtReceipt.Name = "txtReceipt";
            this.txtReceipt.ReadOnly = true;
            this.txtReceipt.Size = new System.Drawing.Size(140, 20);
            this.txtReceipt.TabIndex = 36;
            // 
            // chkUpdateRSM
            // 
            this.chkUpdateRSM.AutoSize = true;
            this.chkUpdateRSM.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSalesPack, "UpdateRSM", true));
            this.chkUpdateRSM.Enabled = false;
            this.chkUpdateRSM.Location = new System.Drawing.Point(124, 162);
            this.chkUpdateRSM.Name = "chkUpdateRSM";
            this.chkUpdateRSM.Size = new System.Drawing.Size(15, 14);
            this.chkUpdateRSM.TabIndex = 38;
            this.chkUpdateRSM.UseVisualStyleBackColor = true;
            // 
            // lbUpdateRSM
            // 
            this.lbUpdateRSM.AutoSize = true;
            this.lbUpdateRSM.Location = new System.Drawing.Point(12, 162);
            this.lbUpdateRSM.Name = "lbUpdateRSM";
            this.lbUpdateRSM.Size = new System.Drawing.Size(75, 13);
            this.lbUpdateRSM.TabIndex = 37;
            this.lbUpdateRSM.Text = "[Update RSM]";
            // 
            // toolTips
            // 
            this.toolTips.ShowAlways = true;
            // 
            // chkUpdateStations
            // 
            this.chkUpdateStations.AutoSize = true;
            this.chkUpdateStations.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSalesPack, "UpdateRSM", true));
            this.chkUpdateStations.Enabled = false;
            this.chkUpdateStations.Location = new System.Drawing.Point(260, 161);
            this.chkUpdateStations.Name = "chkUpdateStations";
            this.chkUpdateStations.Size = new System.Drawing.Size(15, 14);
            this.chkUpdateStations.TabIndex = 40;
            this.chkUpdateStations.UseVisualStyleBackColor = true;
            this.chkUpdateStations.Visible = false;
            // 
            // lbUpdateStations
            // 
            this.lbUpdateStations.AutoSize = true;
            this.lbUpdateStations.Location = new System.Drawing.Point(156, 161);
            this.lbUpdateStations.Name = "lbUpdateStations";
            this.lbUpdateStations.Size = new System.Drawing.Size(87, 13);
            this.lbUpdateStations.TabIndex = 39;
            this.lbUpdateStations.Text = "[Update stations]";
            this.lbUpdateStations.Visible = false;
            // 
            // lbFuturePrices
            // 
            this.lbFuturePrices.AutoSize = true;
            this.lbFuturePrices.Location = new System.Drawing.Point(12, 268);
            this.lbFuturePrices.Name = "lbFuturePrices";
            this.lbFuturePrices.Size = new System.Drawing.Size(72, 13);
            this.lbFuturePrices.TabIndex = 42;
            this.lbFuturePrices.Text = "[FuturePrices]";
            // 
            // bindingSalesPackFuturePrices
            // 
            this.bindingSalesPackFuturePrices.DataMember = "SalesPackFuturePrices";
            this.bindingSalesPackFuturePrices.DataSource = this.dsItem;
            // 
            // adapterLookupPackSize
            // 
            this.adapterLookupPackSize.ClearBeforeFill = true;
            // 
            // adapterLookupUnit
            // 
            this.adapterLookupUnit.ClearBeforeFill = true;
            // 
            // adapterSalesPackTable
            // 
            this.adapterSalesPackTable.ClearBeforeFill = true;
            // 
            // adapterLookupBarcodeName
            // 
            this.adapterLookupBarcodeName.ClearBeforeFill = true;
            // 
            // adapterRelSalesPackChainItem
            // 
            this.adapterRelSalesPackChainItem.ClearBeforeFill = true;
            // 
            // adapterSalesPackFuturePrices
            // 
            this.adapterSalesPackFuturePrices.ClearBeforeFill = true;
            // 
            // gridSalesPackFuturePrices
            // 
            this.gridSalesPackFuturePrices.AllowUserToResizeColumns = false;
            this.gridSalesPackFuturePrices.AllowUserToResizeRows = false;
            this.gridSalesPackFuturePrices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gridSalesPackFuturePrices.AutoGenerateColumns = false;
            this.gridSalesPackFuturePrices.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridSalesPackFuturePrices.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridSalesPackFuturePrices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSalesPackFuturePrices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colActivationDate,
            this.colOrigin,
            this.colSalesPrice,
            this.colSentToStations,
            this.colClosedDate,
            this.colPerform});
            this.gridSalesPackFuturePrices.DataSource = this.bindingSalesPackFuturePrices;
            this.gridSalesPackFuturePrices.Location = new System.Drawing.Point(12, 285);
            this.gridSalesPackFuturePrices.MultiSelect = false;
            this.gridSalesPackFuturePrices.Name = "gridSalesPackFuturePrices";
            this.gridSalesPackFuturePrices.ReadOnly = true;
            this.gridSalesPackFuturePrices.RowHeadersWidth = 25;
            this.gridSalesPackFuturePrices.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridSalesPackFuturePrices.Size = new System.Drawing.Size(448, 109);
            this.gridSalesPackFuturePrices.TabIndex = 41;
            this.gridSalesPackFuturePrices.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridSalesPackFuturePrices_RowValidating);
            this.gridSalesPackFuturePrices.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.gridSalesPackFuturePrices_UserDeletingRow);
            // 
            // colActivationDate
            // 
            this.colActivationDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colActivationDate.DataPropertyName = "ActivationDate";
            dataGridViewCellStyle7.Format = "d";
            this.colActivationDate.DefaultCellStyle = dataGridViewCellStyle7;
            this.colActivationDate.FillWeight = 108.2898F;
            this.colActivationDate.HeaderText = "[Dato]";
            this.colActivationDate.Name = "colActivationDate";
            this.colActivationDate.ReadOnly = true;
            this.colActivationDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colActivationDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colOrigin
            // 
            this.colOrigin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colOrigin.DataPropertyName = "Origin";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colOrigin.DefaultCellStyle = dataGridViewCellStyle8;
            this.colOrigin.FillWeight = 103.6079F;
            this.colOrigin.HeaderText = "[Oprindelse]";
            this.colOrigin.Name = "colOrigin";
            this.colOrigin.ReadOnly = true;
            this.colOrigin.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colSalesPrice
            // 
            this.colSalesPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSalesPrice.DataPropertyName = "SalesPrice";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.colSalesPrice.DefaultCellStyle = dataGridViewCellStyle9;
            this.colSalesPrice.FillWeight = 86.57944F;
            this.colSalesPrice.HeaderText = "[Pris]";
            this.colSalesPrice.Name = "colSalesPrice";
            this.colSalesPrice.ReadOnly = true;
            // 
            // colSentToStations
            // 
            this.colSentToStations.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSentToStations.DataPropertyName = "SentToStations";
            this.colSentToStations.FillWeight = 101.5228F;
            this.colSentToStations.HeaderText = "SentToStations";
            this.colSentToStations.Name = "colSentToStations";
            this.colSentToStations.ReadOnly = true;
            // 
            // colClosedDate
            // 
            this.colClosedDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colClosedDate.DataPropertyName = "ClosedDate";
            this.colClosedDate.HeaderText = "ClosedDate";
            this.colClosedDate.Name = "colClosedDate";
            this.colClosedDate.ReadOnly = true;
            // 
            // colPerform
            // 
            this.colPerform.DataPropertyName = "Perform";
            this.colPerform.HeaderText = "Perform";
            this.colPerform.Name = "colPerform";
            this.colPerform.ReadOnly = true;
            this.colPerform.Width = 50;
            // 
            // txtBCType
            // 
            this.txtBCType.Location = new System.Drawing.Point(124, 136);
            this.txtBCType.LookupColumnDisplayFormat = "";
            this.txtBCType.LookupColumnDisplayName = "BarcodeName";
            this.txtBCType.LookupColumnValueName = "BCType";
            this.txtBCType.LookupTable = this.dsItem.LookupBarcodeName;
            this.txtBCType.Name = "txtBCType";
            this.txtBCType.ReadOnly = true;
            this.txtBCType.Size = new System.Drawing.Size(90, 20);
            this.txtBCType.SourceBinding = this.bindingSalesPack;
            this.txtBCType.SourceColumnName = "BCType";
            this.txtBCType.TabIndex = 30;
            // 
            // SalesPackDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 406);
            this.Controls.Add(this.lbFuturePrices);
            this.Controls.Add(this.gridSalesPackFuturePrices);
            this.Controls.Add(this.chkUpdateStations);
            this.Controls.Add(this.lbUpdateStations);
            this.Controls.Add(this.chkUpdateRSM);
            this.Controls.Add(this.lbUpdateRSM);
            this.Controls.Add(this.txtReceipt);
            this.Controls.Add(this.lbReceipt);
            this.Controls.Add(this.txtNumShelfMarkers);
            this.Controls.Add(this.groupChainItem);
            this.Controls.Add(this.txtSalesPrice);
            this.Controls.Add(this.txtBCType);
            this.Controls.Add(this.txtNumBarcodes);
            this.Controls.Add(this.txtPrimaryBarcode);
            this.Controls.Add(this.groupUnitPrice);
            this.Controls.Add(this.lbNumShelfMarkers);
            this.Controls.Add(this.chkNewShelfMarker);
            this.Controls.Add(this.lbNewShelfMarker);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBarcodes);
            this.Controls.Add(this.chkManualPrice);
            this.Controls.Add(this.comboPackSize);
            this.Controls.Add(this.chkPrimary);
            this.Controls.Add(this.lbSalesPrice);
            this.Controls.Add(this.lbBarcodes);
            this.Controls.Add(this.lbManualPrice);
            this.Controls.Add(this.lbPackSize);
            this.Controls.Add(this.lbPrimary);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SalesPackDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Sales Pack Details Form]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SalesPackDetailsForm_FormClosing);
            this.Load += new System.EventHandler(this.SalesPackDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSalesPack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupPackSize)).EndInit();
            this.groupUnitPrice.ResumeLayout(false);
            this.groupUnitPrice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupUnit)).EndInit();
            this.groupChainItem.ResumeLayout(false);
            this.groupChainItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingRelSalesPackChainItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumShelfMarkers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSalesPackFuturePrices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSalesPackFuturePrices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSalesPack;
        private System.Windows.Forms.Label lbPrimary;
        private System.Windows.Forms.Label lbPackSize;
        private System.Windows.Forms.Label lbManualPrice;
        private System.Windows.Forms.Label lbBarcodes;
        private System.Windows.Forms.Label lbSalesPrice;
        private System.Windows.Forms.CheckBox chkPrimary;
        private System.Windows.Forms.ComboBox comboPackSize;
        private System.Windows.Forms.BindingSource bindingLookupPackSize;
        private RBOS.ItemDataSetTableAdapters.LookupPackSizeTableAdapter adapterLookupPackSize;
        private System.Windows.Forms.CheckBox chkManualPrice;
        private System.Windows.Forms.Button btnBarcodes;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbNewShelfMarker;
        private System.Windows.Forms.CheckBox chkNewShelfMarker;
        private System.Windows.Forms.Label lbNumShelfMarkers;
        private System.Windows.Forms.GroupBox groupUnitPrice;
        private System.Windows.Forms.Label lbUnitDescription;
        private System.Windows.Forms.BindingSource bindingLookupUnit;
        private RBOS.ItemDataSetTableAdapters.LookupUnitTableAdapter adapterLookupUnit;
        private System.Windows.Forms.ComboBox comboUnitDesc;
        private ItemDataSet dsItem;
        private RBOS.ItemDataSetTableAdapters.SalesPackTableAdapter adapterSalesPackTable;
        private System.Windows.Forms.TextBox txtPrimaryBarcode;
        private System.Windows.Forms.TextBox txtNumBarcodes;
        private System.Windows.Forms.TextBox txtShowPricePerUnit;
        private System.Windows.Forms.Label lbPricePerXX;
        private System.Windows.Forms.Label lbUnitContent;
        private System.Windows.Forms.Label lbShowPricePr;
        private System.Windows.Forms.TextBox txtPricePerXX;
        private DRS.Extensions.DRS_LookupTextBox txtBCType;
        private RBOS.ItemDataSetTableAdapters.LookupBarcodeNameTableAdapter adapterLookupBarcodeName;
        private System.Windows.Forms.NumericUpDown txtUnitContent;
        private System.Windows.Forms.TextBox txtSalesPrice;
        private System.Windows.Forms.GroupBox groupChainItem;
        private System.Windows.Forms.NumericUpDown txtNumShelfMarkers;
        private System.Windows.Forms.Button btnChainLookup;
        private System.Windows.Forms.TextBox txtChainBarcode;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lbChainBarcode;
        private System.Windows.Forms.Label lbChainSalesPack;
        private System.Windows.Forms.TextBox txtChainSalesPackDesc;
        private System.Windows.Forms.TextBox txtChainSalesPack;
        private System.Windows.Forms.BindingSource bindingRelSalesPackChainItem;
        private RBOS.ItemDataSetTableAdapters.ChainItemTableAdapter adapterRelSalesPackChainItem;
        private System.Windows.Forms.Label lbReceipt;
        private System.Windows.Forms.TextBox txtReceipt;
        private System.Windows.Forms.Label lbChainReceiptText;
        private System.Windows.Forms.CheckBox chkUpdateRSM;
        private System.Windows.Forms.Label lbUpdateRSM;
        private System.Windows.Forms.Button btnChainRemove;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.CheckBox chkUnitPriceNotShown;
        private System.Windows.Forms.CheckBox chkUpdateStations;
        private System.Windows.Forms.Label lbUpdateStations;
        private DRS.Extensions.DRS_DataGridView gridSalesPackFuturePrices;
        private System.Windows.Forms.BindingSource bindingSalesPackFuturePrices;
        private RBOS.ItemDataSetTableAdapters.SalesPackFuturePricesTableAdapter adapterSalesPackFuturePrices;
        private System.Windows.Forms.Label lbFuturePrices;
        private DRS.Extensions.DRS_CalendarColumn colActivationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrigin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalesPrice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSentToStations;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClosedDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colPerform;
    }
}