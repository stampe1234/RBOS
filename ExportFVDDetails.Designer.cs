namespace RBOS
{
    partial class ExportFVDDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportFVDDetails));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.btnCreateFVDFile = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lbUdmeldteBestillingsnumre = new System.Windows.Forms.Label();
            this.btnCreateCSVFile = new System.Windows.Forms.Button();
            this.bindingFSDDeletedSupplierItem = new System.Windows.Forms.BindingSource(this.components);
            this.dsItem = new RBOS.ItemDataSet();
            this.bindingExportFVDDetails = new System.Windows.Forms.BindingSource(this.components);
            this.adapterExportFVDDetails = new RBOS.ItemDataSetTableAdapters.ExportFVDDetailsTableAdapter();
            this.adapterFSDDeletedSupplierItem = new RBOS.ItemDataSetTableAdapters.FSDDeletedSupplierItemTableAdapter();
            this.gridUdmeldte = new DRS.Extensions.DRS_DataGridView();
            this.colSupplierNo_udmeldte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplierName_udmeldte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderingNumber_udmeldte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKolliSize_udmeldte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackageCost_udmeldte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackageUnitCost_udmeldte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridItems = new DRS.Extensions.DRS_DataGridView();
            this.colStregkode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLeverandoernr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBestillnr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVaretekst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKolli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKostpris = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalgspris = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFutureSalesPriceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingFSDDeletedSupplierItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingExportFVDDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUdmeldte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(632, 537);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "[Annullér]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveClose.Location = new System.Drawing.Point(533, 537);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(93, 23);
            this.btnSaveClose.TabIndex = 2;
            this.btnSaveClose.Text = "[Gem og luk]";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // btnCreateFVDFile
            // 
            this.btnCreateFVDFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateFVDFile.Location = new System.Drawing.Point(267, 537);
            this.btnCreateFVDFile.Name = "btnCreateFVDFile";
            this.btnCreateFVDFile.Size = new System.Drawing.Size(98, 23);
            this.btnCreateFVDFile.TabIndex = 11;
            this.btnCreateFVDFile.Text = "[Dan FVD fil]";
            this.btnCreateFVDFile.UseVisualStyleBackColor = true;
            this.btnCreateFVDFile.Click += new System.EventHandler(this.btnCreateFVDFile_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(452, 537);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 10;
            this.btnPreview.Text = "[Preview]";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(371, 537);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "[Udskriv]";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lbUdmeldteBestillingsnumre
            // 
            this.lbUdmeldteBestillingsnumre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbUdmeldteBestillingsnumre.AutoSize = true;
            this.lbUdmeldteBestillingsnumre.Location = new System.Drawing.Point(12, 423);
            this.lbUdmeldteBestillingsnumre.Name = "lbUdmeldteBestillingsnumre";
            this.lbUdmeldteBestillingsnumre.Size = new System.Drawing.Size(135, 13);
            this.lbUdmeldteBestillingsnumre.TabIndex = 13;
            this.lbUdmeldteBestillingsnumre.Text = "[Udmeldte bestillingsnumre]";
            // 
            // btnCreateCSVFile
            // 
            this.btnCreateCSVFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateCSVFile.Location = new System.Drawing.Point(163, 537);
            this.btnCreateCSVFile.Name = "btnCreateCSVFile";
            this.btnCreateCSVFile.Size = new System.Drawing.Size(98, 23);
            this.btnCreateCSVFile.TabIndex = 11;
            this.btnCreateCSVFile.Text = "[Dan CSV fil]";
            this.btnCreateCSVFile.UseVisualStyleBackColor = true;
            this.btnCreateCSVFile.Click += new System.EventHandler(this.btnCreateCSVFile_Click);
            // 
            // bindingFSDDeletedSupplierItem
            // 
            this.bindingFSDDeletedSupplierItem.DataMember = "FSDDeletedSupplierItem";
            this.bindingFSDDeletedSupplierItem.DataSource = this.dsItem;
            // 
            // dsItem
            // 
            this.dsItem.DataSetName = "ItemDataSet";
            this.dsItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingExportFVDDetails
            // 
            this.bindingExportFVDDetails.DataMember = "ExportFVDDetails";
            this.bindingExportFVDDetails.DataSource = this.dsItem;
            // 
            // adapterExportFVDDetails
            // 
            this.adapterExportFVDDetails.ClearBeforeFill = true;
            // 
            // adapterFSDDeletedSupplierItem
            // 
            this.adapterFSDDeletedSupplierItem.ClearBeforeFill = true;
            // 
            // gridUdmeldte
            // 
            this.gridUdmeldte.AllowUserToAddRows = false;
            this.gridUdmeldte.AllowUserToResizeColumns = false;
            this.gridUdmeldte.AllowUserToResizeRows = false;
            this.gridUdmeldte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridUdmeldte.AutoGenerateColumns = false;
            this.gridUdmeldte.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridUdmeldte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridUdmeldte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUdmeldte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSupplierNo_udmeldte,
            this.colSupplierName_udmeldte,
            this.colOrderingNumber_udmeldte,
            this.colKolliSize_udmeldte,
            this.colPackageCost_udmeldte,
            this.colPackageUnitCost_udmeldte});
            this.gridUdmeldte.DataSource = this.bindingFSDDeletedSupplierItem;
            this.gridUdmeldte.Location = new System.Drawing.Point(13, 442);
            this.gridUdmeldte.MultiSelect = false;
            this.gridUdmeldte.Name = "gridUdmeldte";
            this.gridUdmeldte.ReadOnly = true;
            this.gridUdmeldte.RowHeadersWidth = 25;
            this.gridUdmeldte.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridUdmeldte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUdmeldte.Size = new System.Drawing.Size(695, 89);
            this.gridUdmeldte.TabIndex = 12;
            this.gridUdmeldte.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.gridUdmeldte_UserDeletingRow);
            // 
            // colSupplierNo_udmeldte
            // 
            this.colSupplierNo_udmeldte.DataPropertyName = "SupplierNo";
            this.colSupplierNo_udmeldte.HeaderText = "[Lev.nr.]";
            this.colSupplierNo_udmeldte.Name = "colSupplierNo_udmeldte";
            this.colSupplierNo_udmeldte.ReadOnly = true;
            this.colSupplierNo_udmeldte.Width = 60;
            // 
            // colSupplierName_udmeldte
            // 
            this.colSupplierName_udmeldte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSupplierName_udmeldte.DataPropertyName = "SupplierName";
            this.colSupplierName_udmeldte.HeaderText = "[Leverandør]";
            this.colSupplierName_udmeldte.Name = "colSupplierName_udmeldte";
            this.colSupplierName_udmeldte.ReadOnly = true;
            // 
            // colOrderingNumber_udmeldte
            // 
            this.colOrderingNumber_udmeldte.DataPropertyName = "OrderingNumber";
            this.colOrderingNumber_udmeldte.HeaderText = "[Bestillingsnr.]";
            this.colOrderingNumber_udmeldte.Name = "colOrderingNumber_udmeldte";
            this.colOrderingNumber_udmeldte.ReadOnly = true;
            this.colOrderingNumber_udmeldte.Width = 120;
            // 
            // colKolliSize_udmeldte
            // 
            this.colKolliSize_udmeldte.DataPropertyName = "KolliSize";
            this.colKolliSize_udmeldte.HeaderText = "[Kolli]";
            this.colKolliSize_udmeldte.Name = "colKolliSize_udmeldte";
            this.colKolliSize_udmeldte.ReadOnly = true;
            this.colKolliSize_udmeldte.Width = 50;
            // 
            // colPackageCost_udmeldte
            // 
            this.colPackageCost_udmeldte.DataPropertyName = "PackageCost";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "n3";
            this.colPackageCost_udmeldte.DefaultCellStyle = dataGridViewCellStyle1;
            this.colPackageCost_udmeldte.HeaderText = "[K.kost]";
            this.colPackageCost_udmeldte.Name = "colPackageCost_udmeldte";
            this.colPackageCost_udmeldte.ReadOnly = true;
            this.colPackageCost_udmeldte.Width = 80;
            // 
            // colPackageUnitCost_udmeldte
            // 
            this.colPackageUnitCost_udmeldte.DataPropertyName = "PackageUnitCost";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "n3";
            this.colPackageUnitCost_udmeldte.DefaultCellStyle = dataGridViewCellStyle2;
            this.colPackageUnitCost_udmeldte.HeaderText = "[K.E.kost]";
            this.colPackageUnitCost_udmeldte.Name = "colPackageUnitCost_udmeldte";
            this.colPackageUnitCost_udmeldte.ReadOnly = true;
            this.colPackageUnitCost_udmeldte.Width = 80;
            // 
            // gridItems
            // 
            this.gridItems.AllowUserToAddRows = false;
            this.gridItems.AllowUserToResizeColumns = false;
            this.gridItems.AllowUserToResizeRows = false;
            this.gridItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridItems.AutoGenerateColumns = false;
            this.gridItems.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStregkode,
            this.colLeverandoernr,
            this.colBestillnr,
            this.colVaretekst,
            this.colKolli,
            this.colKostpris,
            this.colSalgspris,
            this.colFutureSalesPriceDate,
            this.colPackType});
            this.gridItems.DataSource = this.bindingExportFVDDetails;
            this.gridItems.Location = new System.Drawing.Point(12, 12);
            this.gridItems.MultiSelect = false;
            this.gridItems.Name = "gridItems";
            this.gridItems.ReadOnly = true;
            this.gridItems.RowHeadersWidth = 25;
            this.gridItems.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridItems.Size = new System.Drawing.Size(695, 406);
            this.gridItems.TabIndex = 0;
            this.gridItems.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grid_UserDeletingRow);
            // 
            // colStregkode
            // 
            this.colStregkode.DataPropertyName = "Stregkode";
            this.colStregkode.HeaderText = "Stregkode";
            this.colStregkode.Name = "colStregkode";
            this.colStregkode.ReadOnly = true;
            // 
            // colLeverandoernr
            // 
            this.colLeverandoernr.DataPropertyName = "Leverandoernr";
            this.colLeverandoernr.HeaderText = "[Lev.nr.]";
            this.colLeverandoernr.Name = "colLeverandoernr";
            this.colLeverandoernr.ReadOnly = true;
            this.colLeverandoernr.Width = 60;
            // 
            // colBestillnr
            // 
            this.colBestillnr.DataPropertyName = "Bestillnr";
            this.colBestillnr.HeaderText = "Bestillnr";
            this.colBestillnr.Name = "colBestillnr";
            this.colBestillnr.ReadOnly = true;
            // 
            // colVaretekst
            // 
            this.colVaretekst.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colVaretekst.DataPropertyName = "Varetekst";
            this.colVaretekst.HeaderText = "Varetekst";
            this.colVaretekst.Name = "colVaretekst";
            this.colVaretekst.ReadOnly = true;
            // 
            // colKolli
            // 
            this.colKolli.DataPropertyName = "Kolli";
            this.colKolli.HeaderText = "Kolli";
            this.colKolli.Name = "colKolli";
            this.colKolli.ReadOnly = true;
            this.colKolli.Width = 50;
            // 
            // colKostpris
            // 
            this.colKostpris.DataPropertyName = "Kostpris";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "n3";
            this.colKostpris.DefaultCellStyle = dataGridViewCellStyle3;
            this.colKostpris.HeaderText = "Kostpris";
            this.colKostpris.Name = "colKostpris";
            this.colKostpris.ReadOnly = true;
            this.colKostpris.Width = 60;
            // 
            // colSalgspris
            // 
            this.colSalgspris.DataPropertyName = "Salgspris";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "n2";
            this.colSalgspris.DefaultCellStyle = dataGridViewCellStyle4;
            this.colSalgspris.HeaderText = "Salgspris";
            this.colSalgspris.Name = "colSalgspris";
            this.colSalgspris.ReadOnly = true;
            this.colSalgspris.Width = 60;
            // 
            // colFutureSalesPriceDate
            // 
            this.colFutureSalesPriceDate.DataPropertyName = "FutureSalesPriceDate";
            this.colFutureSalesPriceDate.HeaderText = "FutureSalesPriceDate";
            this.colFutureSalesPriceDate.Name = "colFutureSalesPriceDate";
            this.colFutureSalesPriceDate.ReadOnly = true;
            this.colFutureSalesPriceDate.Width = 70;
            // 
            // colPackType
            // 
            this.colPackType.DataPropertyName = "PackType";
            this.colPackType.HeaderText = "PackType";
            this.colPackType.Name = "colPackType";
            this.colPackType.ReadOnly = true;
            this.colPackType.Width = 40;
            // 
            // ExportFVDDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 572);
            this.Controls.Add(this.lbUdmeldteBestillingsnumre);
            this.Controls.Add(this.gridUdmeldte);
            this.Controls.Add(this.btnCreateCSVFile);
            this.Controls.Add(this.btnCreateFVDFile);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSaveClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gridItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ExportFVDDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ExportFVDDetails";
            this.Load += new System.EventHandler(this.ExportFVDDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingFSDDeletedSupplierItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingExportFVDDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUdmeldte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DRS.Extensions.DRS_DataGridView gridItems;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveClose;
        private ItemDataSet dsItem;
        private System.Windows.Forms.BindingSource bindingExportFVDDetails;
        private RBOS.ItemDataSetTableAdapters.ExportFVDDetailsTableAdapter adapterExportFVDDetails;
        private System.Windows.Forms.Button btnCreateFVDFile;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnPrint;
        private DRS.Extensions.DRS_DataGridView gridUdmeldte;
        private System.Windows.Forms.Label lbUdmeldteBestillingsnumre;
        private System.Windows.Forms.BindingSource bindingFSDDeletedSupplierItem;
        private RBOS.ItemDataSetTableAdapters.FSDDeletedSupplierItemTableAdapter adapterFSDDeletedSupplierItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplierNo_udmeldte;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplierName_udmeldte;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderingNumber_udmeldte;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKolliSize_udmeldte;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackageCost_udmeldte;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackageUnitCost_udmeldte;
        private System.Windows.Forms.Button btnCreateCSVFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStregkode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLeverandoernr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBestillnr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVaretekst;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKolli;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKostpris;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalgspris;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFutureSalesPriceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackType;
    }
}