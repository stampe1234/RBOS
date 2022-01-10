namespace RBOS
{
    partial class StockCountRegistrationRBA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockCountRegistrationRBA));
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.btnBook = new System.Windows.Forms.Button();
            this.lbUltimoDate = new System.Windows.Forms.Label();
            this.bindingStockCountRegistrationRBA = new System.Windows.Forms.BindingSource(this.components);
            this.dsItem = new RBOS.ItemDataSet();
            this.adapterStockCountRegistrationRBA = new RBOS.ItemDataSetTableAdapters.StockCountRegistrationRBATableAdapter();
            this.ddUltimoYear = new System.Windows.Forms.ComboBox();
            this.ddUltimoMonth = new System.Windows.Forms.ComboBox();
            this.grid = new DRS.Extensions.DRS_DataGridView();
            this.colVarenummer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLookupVare = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVarenavn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLevNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVaregruppe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAntal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKostprisExMoms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIalt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingStockCountRegistrationRBA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndClose.Location = new System.Drawing.Point(671, 503);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(108, 23);
            this.btnSaveAndClose.TabIndex = 0;
            this.btnSaveAndClose.Text = "Save and Close";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // btnBook
            // 
            this.btnBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBook.Location = new System.Drawing.Point(589, 503);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(76, 23);
            this.btnBook.TabIndex = 1;
            this.btnBook.Text = "Book";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // lbUltimoDate
            // 
            this.lbUltimoDate.AutoSize = true;
            this.lbUltimoDate.Location = new System.Drawing.Point(12, 15);
            this.lbUltimoDate.Name = "lbUltimoDate";
            this.lbUltimoDate.Size = new System.Drawing.Size(63, 13);
            this.lbUltimoDate.TabIndex = 3;
            this.lbUltimoDate.Text = "[Ultimodato]";
            // 
            // bindingStockCountRegistrationRBA
            // 
            this.bindingStockCountRegistrationRBA.DataMember = "StockCountRegistrationRBA";
            this.bindingStockCountRegistrationRBA.DataSource = this.dsItem;
            // 
            // dsItem
            // 
            this.dsItem.DataSetName = "ItemDataSet";
            this.dsItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // adapterStockCountRegistrationRBA
            // 
            this.adapterStockCountRegistrationRBA.ClearBeforeFill = true;
            // 
            // ddUltimoYear
            // 
            this.ddUltimoYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddUltimoYear.FormattingEnabled = true;
            this.ddUltimoYear.Location = new System.Drawing.Point(92, 12);
            this.ddUltimoYear.Name = "ddUltimoYear";
            this.ddUltimoYear.Size = new System.Drawing.Size(84, 21);
            this.ddUltimoYear.TabIndex = 4;
            this.ddUltimoYear.SelectedIndexChanged += new System.EventHandler(this.ddUltimoYear_SelectedIndexChanged);
            // 
            // ddUltimoMonth
            // 
            this.ddUltimoMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddUltimoMonth.FormattingEnabled = true;
            this.ddUltimoMonth.Location = new System.Drawing.Point(182, 12);
            this.ddUltimoMonth.Name = "ddUltimoMonth";
            this.ddUltimoMonth.Size = new System.Drawing.Size(56, 21);
            this.ddUltimoMonth.TabIndex = 5;
            this.ddUltimoMonth.SelectedIndexChanged += new System.EventHandler(this.ddUltimoMonth_SelectedIndexChanged);
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
            this.colVarenummer,
            this.colLookupVare,
            this.colBarcode,
            this.colVarenavn,
            this.colLevNr,
            this.colVaregruppe,
            this.colAntal,
            this.colKostprisExMoms,
            this.colIalt});
            this.grid.DataSource = this.bindingStockCountRegistrationRBA;
            this.grid.Location = new System.Drawing.Point(12, 39);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.RowHeadersWidth = 25;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.Size = new System.Drawing.Size(767, 458);
            this.grid.TabIndex = 2;
            this.grid.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellLeave);
            this.grid.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grid_RowValidating);
            this.grid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellEndEdit);
            this.grid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grid_CellPainting);
            this.grid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grid_KeyUp);
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            // 
            // colVarenummer
            // 
            this.colVarenummer.DataPropertyName = "Varenummer";
            this.colVarenummer.HeaderText = "Varenummer";
            this.colVarenummer.Name = "colVarenummer";
            this.colVarenummer.Width = 80;
            // 
            // colLookupVare
            // 
            this.colLookupVare.HeaderText = "";
            this.colLookupVare.Name = "colLookupVare";
            this.colLookupVare.Width = 25;
            // 
            // colBarcode
            // 
            this.colBarcode.DataPropertyName = "Barcode";
            this.colBarcode.HeaderText = "Barcode";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.Width = 90;
            // 
            // colVarenavn
            // 
            this.colVarenavn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colVarenavn.DataPropertyName = "Varenavn";
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.colVarenavn.DefaultCellStyle = dataGridViewCellStyle1;
            this.colVarenavn.HeaderText = "Varenavn";
            this.colVarenavn.Name = "colVarenavn";
            this.colVarenavn.ReadOnly = true;
            // 
            // colLevNr
            // 
            this.colLevNr.DataPropertyName = "LevNr";
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            this.colLevNr.DefaultCellStyle = dataGridViewCellStyle2;
            this.colLevNr.HeaderText = "LevNr";
            this.colLevNr.Name = "colLevNr";
            this.colLevNr.ReadOnly = true;
            this.colLevNr.Width = 60;
            // 
            // colVaregruppe
            // 
            this.colVaregruppe.DataPropertyName = "Varegruppe";
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            this.colVaregruppe.DefaultCellStyle = dataGridViewCellStyle3;
            this.colVaregruppe.HeaderText = "Varegruppe";
            this.colVaregruppe.Name = "colVaregruppe";
            this.colVaregruppe.ReadOnly = true;
            this.colVaregruppe.Width = 70;
            // 
            // colAntal
            // 
            this.colAntal.DataPropertyName = "Antal";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colAntal.DefaultCellStyle = dataGridViewCellStyle4;
            this.colAntal.HeaderText = "Antal";
            this.colAntal.Name = "colAntal";
            this.colAntal.Width = 50;
            // 
            // colKostprisExMoms
            // 
            this.colKostprisExMoms.DataPropertyName = "KostprisExMoms";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Format = "N3";
            dataGridViewCellStyle5.NullValue = null;
            this.colKostprisExMoms.DefaultCellStyle = dataGridViewCellStyle5;
            this.colKostprisExMoms.HeaderText = "KostprisExMoms";
            this.colKostprisExMoms.Name = "colKostprisExMoms";
            this.colKostprisExMoms.ReadOnly = true;
            this.colKostprisExMoms.Width = 80;
            // 
            // colIalt
            // 
            this.colIalt.DataPropertyName = "Ialt";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.colIalt.DefaultCellStyle = dataGridViewCellStyle6;
            this.colIalt.HeaderText = "Ialt";
            this.colIalt.Name = "colIalt";
            this.colIalt.ReadOnly = true;
            this.colIalt.Width = 90;
            // 
            // StockCountRegistrationRBA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 538);
            this.Controls.Add(this.ddUltimoMonth);
            this.Controls.Add(this.ddUltimoYear);
            this.Controls.Add(this.lbUltimoDate);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.btnSaveAndClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StockCountRegistrationRBA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StockCountRegistrationRBA";
            this.Load += new System.EventHandler(this.StockCountRegistrationRBA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingStockCountRegistrationRBA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.Button btnBook;
        private DRS.Extensions.DRS_DataGridView grid;
        private ItemDataSet dsItem;
        private System.Windows.Forms.BindingSource bindingStockCountRegistrationRBA;
        private RBOS.ItemDataSetTableAdapters.StockCountRegistrationRBATableAdapter adapterStockCountRegistrationRBA;
        private System.Windows.Forms.Label lbUltimoDate;
        private System.Windows.Forms.ComboBox ddUltimoYear;
        private System.Windows.Forms.ComboBox ddUltimoMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVarenummer;
        private System.Windows.Forms.DataGridViewButtonColumn colLookupVare;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVarenavn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLevNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVaregruppe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAntal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKostprisExMoms;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIalt;
    }
}