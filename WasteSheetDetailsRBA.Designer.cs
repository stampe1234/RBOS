namespace RBOS
{
    partial class WasteSheetDetailsRBA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WasteSheetDetailsRBA));
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.bindingWasteSheetHeader = new System.Windows.Forms.BindingSource(this.components);
            this.dsItem = new RBOS.ItemDataSet();
            this.adapterWasteSheetHeader = new RBOS.ItemDataSetTableAdapters.WasteSheetHeaderTableAdapter();
            this.bindingWasteSheetDetailsRBA = new System.Windows.Forms.BindingSource(this.components);
            this.adapterWasteSheetDetailsRBA = new RBOS.ItemDataSetTableAdapters.WasteSheetDetailsRBATableAdapter();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.grid = new DRS.Extensions.DRS_DataGridView();
            this.colLookupItemButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colLevNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVarenummer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVarenavn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKostpris = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalgspris = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingWasteSheetHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingWasteSheetDetailsRBA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndClose.Location = new System.Drawing.Point(557, 402);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(105, 23);
            this.btnSaveAndClose.TabIndex = 1;
            this.btnSaveAndClose.Text = "[Gem og luk]";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(12, 15);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(39, 13);
            this.lbName.TabIndex = 2;
            this.lbName.Text = "[Navn]";
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingWasteSheetHeader, "Name", true));
            this.txtName.Location = new System.Drawing.Point(70, 12);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(209, 20);
            this.txtName.TabIndex = 3;
            // 
            // bindingWasteSheetHeader
            // 
            this.bindingWasteSheetHeader.DataMember = "WasteSheetHeader";
            this.bindingWasteSheetHeader.DataSource = this.dsItem;
            // 
            // dsItem
            // 
            this.dsItem.DataSetName = "ItemDataSet";
            this.dsItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // adapterWasteSheetHeader
            // 
            this.adapterWasteSheetHeader.ClearBeforeFill = true;
            // 
            // bindingWasteSheetDetailsRBA
            // 
            this.bindingWasteSheetDetailsRBA.DataMember = "WasteSheetDetailsRBA";
            this.bindingWasteSheetDetailsRBA.DataSource = this.dsItem;
            // 
            // adapterWasteSheetDetailsRBA
            // 
            this.adapterWasteSheetDetailsRBA.ClearBeforeFill = true;
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Location = new System.Drawing.Point(335, 402);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(105, 23);
            this.btnUp.TabIndex = 5;
            this.btnUp.Text = "[Flyt op]";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Location = new System.Drawing.Point(446, 402);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(105, 23);
            this.btnDown.TabIndex = 6;
            this.btnDown.Text = "[Flyt ned]";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // grid
            // 
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
            this.colLookupItemButton,
            this.colLevNr,
            this.colVarenummer,
            this.colVarenavn,
            this.colBarcode,
            this.colKostpris,
            this.colSalgspris});
            this.grid.DataSource = this.bindingWasteSheetDetailsRBA;
            this.grid.Location = new System.Drawing.Point(12, 38);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.RowHeadersWidth = 25;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(650, 358);
            this.grid.TabIndex = 4;
            this.grid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grid_CellPainting);
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            // 
            // colLookupItemButton
            // 
            this.colLookupItemButton.HeaderText = "";
            this.colLookupItemButton.Name = "colLookupItemButton";
            this.colLookupItemButton.Width = 25;
            // 
            // colLevNr
            // 
            this.colLevNr.DataPropertyName = "LevNr";
            this.colLevNr.HeaderText = "LevNr";
            this.colLevNr.Name = "colLevNr";
            this.colLevNr.ReadOnly = true;
            this.colLevNr.Width = 60;
            // 
            // colVarenummer
            // 
            this.colVarenummer.DataPropertyName = "Varenummer";
            this.colVarenummer.HeaderText = "Varenummer";
            this.colVarenummer.Name = "colVarenummer";
            this.colVarenummer.ReadOnly = true;
            // 
            // colVarenavn
            // 
            this.colVarenavn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colVarenavn.DataPropertyName = "Varenavn";
            this.colVarenavn.HeaderText = "Varenavn";
            this.colVarenavn.Name = "colVarenavn";
            this.colVarenavn.ReadOnly = true;
            // 
            // colBarcode
            // 
            this.colBarcode.DataPropertyName = "Barcode";
            this.colBarcode.HeaderText = "Barcode";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.ReadOnly = true;
            // 
            // colKostpris
            // 
            this.colKostpris.DataPropertyName = "Kostpris";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N3";
            dataGridViewCellStyle1.NullValue = null;
            this.colKostpris.DefaultCellStyle = dataGridViewCellStyle1;
            this.colKostpris.HeaderText = "Kostpris";
            this.colKostpris.Name = "colKostpris";
            this.colKostpris.ReadOnly = true;
            this.colKostpris.Width = 70;
            // 
            // colSalgspris
            // 
            this.colSalgspris.DataPropertyName = "Salgspris";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.colSalgspris.DefaultCellStyle = dataGridViewCellStyle2;
            this.colSalgspris.HeaderText = "Salgspris";
            this.colSalgspris.Name = "colSalgspris";
            this.colSalgspris.ReadOnly = true;
            this.colSalgspris.Width = 70;
            // 
            // WasteSheetDetailsRBA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 437);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.btnSaveAndClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WasteSheetDetailsRBA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WasteSheetDetailsRBA";
            ((System.ComponentModel.ISupportInitialize)(this.bindingWasteSheetHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingWasteSheetDetailsRBA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox txtName;
        private DRS.Extensions.DRS_DataGridView grid;
        private ItemDataSet dsItem;
        private System.Windows.Forms.BindingSource bindingWasteSheetHeader;
        private RBOS.ItemDataSetTableAdapters.WasteSheetHeaderTableAdapter adapterWasteSheetHeader;
        private System.Windows.Forms.BindingSource bindingWasteSheetDetailsRBA;
        private RBOS.ItemDataSetTableAdapters.WasteSheetDetailsRBATableAdapter adapterWasteSheetDetailsRBA;
        private System.Windows.Forms.DataGridViewButtonColumn colLookupItemButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLevNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVarenummer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVarenavn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKostpris;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalgspris;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
    }
}