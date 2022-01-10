namespace RBOS
{
    partial class ItemUpdInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemUpdInfo));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bindingItemUpdLines = new System.Windows.Forms.BindingSource(this.components);
            this.dsImport = new RBOS.ImportDataSet();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.txtMarginBefore = new System.Windows.Forms.TextBox();
            this.txtSalesPriceAfter = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.txtMarginAfter = new System.Windows.Forms.TextBox();
            this.lbActions = new System.Windows.Forms.Label();
            this.lbItemName = new System.Windows.Forms.Label();
            this.lbBarcode = new System.Windows.Forms.Label();
            this.lbSubCategory = new System.Windows.Forms.Label();
            this.lbSupplier = new System.Windows.Forms.Label();
            this.lbOrderingNumber = new System.Windows.Forms.Label();
            this.lbKolliCost = new System.Windows.Forms.Label();
            this.lbKolli = new System.Windows.Forms.Label();
            this.lbBefore = new System.Windows.Forms.Label();
            this.lbSalesPrice = new System.Windows.Forms.Label();
            this.lbCostPrice = new System.Windows.Forms.Label();
            this.lbMargin = new System.Windows.Forms.Label();
            this.lbAfter = new System.Windows.Forms.Label();
            this.chkSkipSalesPriceChange = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnOpenSalesPriceForEdit = new System.Windows.Forms.Button();
            this.txtKampagneID = new System.Windows.Forms.TextBox();
            this.lbKampagneID = new System.Windows.Forms.Label();
            this.lbFutureSalesPriceDate = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.txtPackType = new System.Windows.Forms.TextBox();
            this.lbPackType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingItemUpdLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsImport)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingItemUpdLines, "ActionSummary", true));
            this.textBox1.Location = new System.Drawing.Point(161, 15);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(264, 22);
            this.textBox1.TabIndex = 0;
            // 
            // bindingItemUpdLines
            // 
            this.bindingItemUpdLines.DataMember = "ItemUpdLines";
            this.bindingItemUpdLines.DataSource = this.dsImport;
            // 
            // dsImport
            // 
            this.dsImport.DataSetName = "ImportDataSet";
            this.dsImport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingItemUpdLines, "Name", true));
            this.textBox2.Location = new System.Drawing.Point(161, 47);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(264, 22);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingItemUpdLines, "LookupSubCategory", true));
            this.textBox3.Location = new System.Drawing.Point(161, 79);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(264, 22);
            this.textBox3.TabIndex = 2;
            // 
            // textBox4
            // 
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingItemUpdLines, "Barcode", true));
            this.textBox4.Location = new System.Drawing.Point(161, 111);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(132, 22);
            this.textBox4.TabIndex = 3;
            // 
            // textBox5
            // 
            this.textBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingItemUpdLines, "LookupSupplierName", true));
            this.textBox5.Location = new System.Drawing.Point(161, 143);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(264, 22);
            this.textBox5.TabIndex = 4;
            // 
            // textBox6
            // 
            this.textBox6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingItemUpdLines, "OrderingNumber", true));
            this.textBox6.Location = new System.Drawing.Point(161, 175);
            this.textBox6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(99, 22);
            this.textBox6.TabIndex = 5;
            // 
            // textBox7
            // 
            this.textBox7.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingItemUpdLines, "CalcPackageCost", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N3"));
            this.textBox7.Location = new System.Drawing.Point(161, 207);
            this.textBox7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(75, 22);
            this.textBox7.TabIndex = 6;
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox8
            // 
            this.textBox8.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingItemUpdLines, "Kolli", true));
            this.textBox8.Location = new System.Drawing.Point(360, 175);
            this.textBox8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(65, 22);
            this.textBox8.TabIndex = 7;
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox9
            // 
            this.textBox9.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingItemUpdLines, "LogSales", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.textBox9.Location = new System.Drawing.Point(161, 315);
            this.textBox9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(75, 22);
            this.textBox9.TabIndex = 8;
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox10
            // 
            this.textBox10.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingItemUpdLines, "LogCost", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N3"));
            this.textBox10.Location = new System.Drawing.Point(161, 347);
            this.textBox10.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(75, 22);
            this.textBox10.TabIndex = 9;
            this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMarginBefore
            // 
            this.txtMarginBefore.Location = new System.Drawing.Point(161, 379);
            this.txtMarginBefore.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMarginBefore.Name = "txtMarginBefore";
            this.txtMarginBefore.ReadOnly = true;
            this.txtMarginBefore.Size = new System.Drawing.Size(75, 22);
            this.txtMarginBefore.TabIndex = 10;
            this.txtMarginBefore.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSalesPriceAfter
            // 
            this.txtSalesPriceAfter.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingItemUpdLines, "SalesPrice", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.txtSalesPriceAfter.Location = new System.Drawing.Point(260, 315);
            this.txtSalesPriceAfter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSalesPriceAfter.Name = "txtSalesPriceAfter";
            this.txtSalesPriceAfter.ReadOnly = true;
            this.txtSalesPriceAfter.Size = new System.Drawing.Size(75, 22);
            this.txtSalesPriceAfter.TabIndex = 11;
            this.txtSalesPriceAfter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSalesPriceAfter.Validated += new System.EventHandler(this.txtSalesPriceAfter_Validated);
            // 
            // textBox13
            // 
            this.textBox13.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingItemUpdLines, "CostPrice", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N3"));
            this.textBox13.Location = new System.Drawing.Point(260, 347);
            this.textBox13.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new System.Drawing.Size(75, 22);
            this.textBox13.TabIndex = 12;
            this.textBox13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMarginAfter
            // 
            this.txtMarginAfter.Location = new System.Drawing.Point(260, 379);
            this.txtMarginAfter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMarginAfter.Name = "txtMarginAfter";
            this.txtMarginAfter.ReadOnly = true;
            this.txtMarginAfter.Size = new System.Drawing.Size(75, 22);
            this.txtMarginAfter.TabIndex = 13;
            this.txtMarginAfter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbActions
            // 
            this.lbActions.AutoSize = true;
            this.lbActions.Location = new System.Drawing.Point(16, 18);
            this.lbActions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbActions.Name = "lbActions";
            this.lbActions.Size = new System.Drawing.Size(62, 17);
            this.lbActions.TabIndex = 14;
            this.lbActions.Text = "[Actions]";
            // 
            // lbItemName
            // 
            this.lbItemName.AutoSize = true;
            this.lbItemName.Location = new System.Drawing.Point(16, 50);
            this.lbItemName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbItemName.Name = "lbItemName";
            this.lbItemName.Size = new System.Drawing.Size(83, 17);
            this.lbItemName.TabIndex = 15;
            this.lbItemName.Text = "[Item Name]";
            // 
            // lbBarcode
            // 
            this.lbBarcode.AutoSize = true;
            this.lbBarcode.Location = new System.Drawing.Point(16, 114);
            this.lbBarcode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbBarcode.Name = "lbBarcode";
            this.lbBarcode.Size = new System.Drawing.Size(69, 17);
            this.lbBarcode.TabIndex = 16;
            this.lbBarcode.Text = "[Barcode]";
            // 
            // lbSubCategory
            // 
            this.lbSubCategory.AutoSize = true;
            this.lbSubCategory.Location = new System.Drawing.Point(16, 82);
            this.lbSubCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSubCategory.Name = "lbSubCategory";
            this.lbSubCategory.Size = new System.Drawing.Size(96, 17);
            this.lbSubCategory.TabIndex = 17;
            this.lbSubCategory.Text = "[Subcategory]";
            // 
            // lbSupplier
            // 
            this.lbSupplier.AutoSize = true;
            this.lbSupplier.Location = new System.Drawing.Point(16, 146);
            this.lbSupplier.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSupplier.Name = "lbSupplier";
            this.lbSupplier.Size = new System.Drawing.Size(68, 17);
            this.lbSupplier.TabIndex = 18;
            this.lbSupplier.Text = "[Supplier]";
            // 
            // lbOrderingNumber
            // 
            this.lbOrderingNumber.AutoSize = true;
            this.lbOrderingNumber.Location = new System.Drawing.Point(16, 178);
            this.lbOrderingNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbOrderingNumber.Name = "lbOrderingNumber";
            this.lbOrderingNumber.Size = new System.Drawing.Size(122, 17);
            this.lbOrderingNumber.TabIndex = 19;
            this.lbOrderingNumber.Text = "[OrderingNumber]";
            // 
            // lbKolliCost
            // 
            this.lbKolliCost.AutoSize = true;
            this.lbKolliCost.Location = new System.Drawing.Point(16, 210);
            this.lbKolliCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbKolliCost.Name = "lbKolliCost";
            this.lbKolliCost.Size = new System.Drawing.Size(74, 17);
            this.lbKolliCost.TabIndex = 20;
            this.lbKolliCost.Text = "[Kolli Cost]";
            // 
            // lbKolli
            // 
            this.lbKolli.Location = new System.Drawing.Point(269, 178);
            this.lbKolli.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbKolli.Name = "lbKolli";
            this.lbKolli.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbKolli.Size = new System.Drawing.Size(83, 16);
            this.lbKolli.TabIndex = 21;
            this.lbKolli.Text = "[Kolli]";
            // 
            // lbBefore
            // 
            this.lbBefore.Location = new System.Drawing.Point(157, 295);
            this.lbBefore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbBefore.Name = "lbBefore";
            this.lbBefore.Size = new System.Drawing.Size(80, 16);
            this.lbBefore.TabIndex = 22;
            this.lbBefore.Text = "[Before]";
            this.lbBefore.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbSalesPrice
            // 
            this.lbSalesPrice.AutoSize = true;
            this.lbSalesPrice.Location = new System.Drawing.Point(16, 319);
            this.lbSalesPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSalesPrice.Name = "lbSalesPrice";
            this.lbSalesPrice.Size = new System.Drawing.Size(87, 17);
            this.lbSalesPrice.TabIndex = 24;
            this.lbSalesPrice.Text = "[Sales Price]";
            // 
            // lbCostPrice
            // 
            this.lbCostPrice.AutoSize = true;
            this.lbCostPrice.Location = new System.Drawing.Point(16, 351);
            this.lbCostPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCostPrice.Name = "lbCostPrice";
            this.lbCostPrice.Size = new System.Drawing.Size(80, 17);
            this.lbCostPrice.TabIndex = 25;
            this.lbCostPrice.Text = "[Cost Price]";
            // 
            // lbMargin
            // 
            this.lbMargin.AutoSize = true;
            this.lbMargin.Location = new System.Drawing.Point(16, 383);
            this.lbMargin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMargin.Name = "lbMargin";
            this.lbMargin.Size = new System.Drawing.Size(59, 17);
            this.lbMargin.TabIndex = 26;
            this.lbMargin.Text = "[Margin]";
            // 
            // lbAfter
            // 
            this.lbAfter.Location = new System.Drawing.Point(260, 295);
            this.lbAfter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAfter.Name = "lbAfter";
            this.lbAfter.Size = new System.Drawing.Size(76, 16);
            this.lbAfter.TabIndex = 32;
            this.lbAfter.Text = "[After]";
            this.lbAfter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chkSkipSalesPriceChange
            // 
            this.chkSkipSalesPriceChange.AutoSize = true;
            this.chkSkipSalesPriceChange.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSkipSalesPriceChange.Location = new System.Drawing.Point(16, 432);
            this.chkSkipSalesPriceChange.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkSkipSalesPriceChange.Name = "chkSkipSalesPriceChange";
            this.chkSkipSalesPriceChange.Size = new System.Drawing.Size(193, 21);
            this.chkSkipSalesPriceChange.TabIndex = 33;
            this.chkSkipSalesPriceChange.Text = "[Skip Sales Price Change]";
            this.chkSkipSalesPriceChange.UseVisualStyleBackColor = true;
            this.chkSkipSalesPriceChange.Click += new System.EventHandler(this.chkSkipSalesPrice_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(331, 478);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 28);
            this.btnOk.TabIndex = 34;
            this.btnOk.Text = "[Ok]";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnOpenSalesPriceForEdit
            // 
            this.btnOpenSalesPriceForEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenSalesPriceForEdit.Enabled = false;
            this.btnOpenSalesPriceForEdit.Location = new System.Drawing.Point(176, 478);
            this.btnOpenSalesPriceForEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpenSalesPriceForEdit.Name = "btnOpenSalesPriceForEdit";
            this.btnOpenSalesPriceForEdit.Size = new System.Drawing.Size(147, 28);
            this.btnOpenSalesPriceForEdit.TabIndex = 36;
            this.btnOpenSalesPriceForEdit.Text = "[Edit Sales Price]";
            this.btnOpenSalesPriceForEdit.UseVisualStyleBackColor = true;
            this.btnOpenSalesPriceForEdit.Visible = false;
            this.btnOpenSalesPriceForEdit.Click += new System.EventHandler(this.btnEnableSalesPrice_Click);
            // 
            // txtKampagneID
            // 
            this.txtKampagneID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingItemUpdLines, "KampagneID", true));
            this.txtKampagneID.Location = new System.Drawing.Point(360, 207);
            this.txtKampagneID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtKampagneID.Name = "txtKampagneID";
            this.txtKampagneID.ReadOnly = true;
            this.txtKampagneID.Size = new System.Drawing.Size(65, 22);
            this.txtKampagneID.TabIndex = 37;
            this.txtKampagneID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbKampagneID
            // 
            this.lbKampagneID.Location = new System.Drawing.Point(248, 210);
            this.lbKampagneID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbKampagneID.Name = "lbKampagneID";
            this.lbKampagneID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbKampagneID.Size = new System.Drawing.Size(104, 16);
            this.lbKampagneID.TabIndex = 38;
            this.lbKampagneID.Text = "[Kampagne ID]";
            // 
            // lbFutureSalesPriceDate
            // 
            this.lbFutureSalesPriceDate.Location = new System.Drawing.Point(16, 242);
            this.lbFutureSalesPriceDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFutureSalesPriceDate.Name = "lbFutureSalesPriceDate";
            this.lbFutureSalesPriceDate.Size = new System.Drawing.Size(133, 16);
            this.lbFutureSalesPriceDate.TabIndex = 39;
            this.lbFutureSalesPriceDate.Text = "[Sales price date]";
            // 
            // textBox11
            // 
            this.textBox11.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingItemUpdLines, "FutureSalesPriceDate", true));
            this.textBox11.Location = new System.Drawing.Point(161, 239);
            this.textBox11.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(93, 22);
            this.textBox11.TabIndex = 40;
            // 
            // txtPackType
            // 
            this.txtPackType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingItemUpdLines, "PackType", true));
            this.txtPackType.Location = new System.Drawing.Point(360, 239);
            this.txtPackType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPackType.Name = "txtPackType";
            this.txtPackType.ReadOnly = true;
            this.txtPackType.Size = new System.Drawing.Size(65, 22);
            this.txtPackType.TabIndex = 42;
            // 
            // lbPackType
            // 
            this.lbPackType.Location = new System.Drawing.Point(264, 242);
            this.lbPackType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPackType.Name = "lbPackType";
            this.lbPackType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbPackType.Size = new System.Drawing.Size(88, 16);
            this.lbPackType.TabIndex = 41;
            this.lbPackType.Text = "[Pack Type]";
            // 
            // ItemUpdInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 521);
            this.Controls.Add(this.txtPackType);
            this.Controls.Add(this.lbPackType);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.lbFutureSalesPriceDate);
            this.Controls.Add(this.lbKampagneID);
            this.Controls.Add(this.txtKampagneID);
            this.Controls.Add(this.btnOpenSalesPriceForEdit);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.chkSkipSalesPriceChange);
            this.Controls.Add(this.lbAfter);
            this.Controls.Add(this.lbMargin);
            this.Controls.Add(this.lbCostPrice);
            this.Controls.Add(this.lbSalesPrice);
            this.Controls.Add(this.lbBefore);
            this.Controls.Add(this.lbKolli);
            this.Controls.Add(this.lbKolliCost);
            this.Controls.Add(this.lbOrderingNumber);
            this.Controls.Add(this.lbSupplier);
            this.Controls.Add(this.lbSubCategory);
            this.Controls.Add(this.lbBarcode);
            this.Controls.Add(this.lbItemName);
            this.Controls.Add(this.lbActions);
            this.Controls.Add(this.txtMarginAfter);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.txtSalesPriceAfter);
            this.Controls.Add(this.txtMarginBefore);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "ItemUpdInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ItemUpdInfo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ItemUpdInfo_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.bindingItemUpdLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsImport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox txtMarginBefore;
        private System.Windows.Forms.TextBox txtSalesPriceAfter;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox txtMarginAfter;
        private System.Windows.Forms.Label lbActions;
        private System.Windows.Forms.Label lbItemName;
        private System.Windows.Forms.Label lbBarcode;
        private System.Windows.Forms.Label lbSubCategory;
        private System.Windows.Forms.Label lbSupplier;
        private System.Windows.Forms.Label lbOrderingNumber;
        private System.Windows.Forms.Label lbKolliCost;
        private System.Windows.Forms.Label lbKolli;
        private System.Windows.Forms.Label lbBefore;
        private System.Windows.Forms.Label lbSalesPrice;
        private System.Windows.Forms.Label lbCostPrice;
        private System.Windows.Forms.Label lbMargin;
        private System.Windows.Forms.Label lbAfter;
        private System.Windows.Forms.CheckBox chkSkipSalesPriceChange;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.BindingSource bindingItemUpdLines;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnOpenSalesPriceForEdit;
        private ImportDataSet dsImport;
        private System.Windows.Forms.TextBox txtKampagneID;
        private System.Windows.Forms.Label lbKampagneID;
        private System.Windows.Forms.Label lbFutureSalesPriceDate;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox txtPackType;
        private System.Windows.Forms.Label lbPackType;
    }
}