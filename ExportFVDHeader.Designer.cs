namespace RBOS
{
    partial class ExportFVDHeader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportFVDHeader));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.bindingExportFVDHeader = new System.Windows.Forms.BindingSource(this.components);
            this.dsItem = new RBOS.ItemDataSet();
            this.adapterExportFVDHeader = new RBOS.ItemDataSetTableAdapters.ExportFVDHeaderTableAdapter();
            this.grid = new DRS.Extensions.DRS_DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExportDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCalcNumDeletedSupplierItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSentOutDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumDetailRecords = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCriteria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingExportFVDHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(509, 353);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "[Luk]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetails.Location = new System.Drawing.Point(428, 353);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(75, 23);
            this.btnDetails.TabIndex = 3;
            this.btnDetails.Text = "[Detaljer]";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(347, 353);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "[Slet]";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // bindingExportFVDHeader
            // 
            this.bindingExportFVDHeader.DataMember = "ExportFVDHeader";
            this.bindingExportFVDHeader.DataSource = this.dsItem;
            // 
            // dsItem
            // 
            this.dsItem.DataSetName = "ItemDataSet";
            this.dsItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // adapterExportFVDHeader
            // 
            this.adapterExportFVDHeader.ClearBeforeFill = true;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
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
            this.colID,
            this.colExportDateTime,
            this.colCalcNumDeletedSupplierItems,
            this.colSentOutDateTime,
            this.colFilename,
            this.colNumDetailRecords,
            this.colCriteria});
            this.grid.DataSource = this.bindingExportFVDHeader;
            this.grid.Location = new System.Drawing.Point(12, 12);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersWidth = 25;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(572, 335);
            this.grid.TabIndex = 1;
            this.grid.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grid_UserDeletingRow);
            this.grid.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grid_MouseDoubleClick);
            this.grid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grid_CellMouseDoubleClick);
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colID.Width = 40;
            // 
            // colExportDateTime
            // 
            this.colExportDateTime.DataPropertyName = "ExportDateTime";
            dataGridViewCellStyle1.Format = "g";
            dataGridViewCellStyle1.NullValue = null;
            this.colExportDateTime.DefaultCellStyle = dataGridViewCellStyle1;
            this.colExportDateTime.HeaderText = "[Udtræksdato]";
            this.colExportDateTime.Name = "colExportDateTime";
            this.colExportDateTime.ReadOnly = true;
            this.colExportDateTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colCalcNumDeletedSupplierItems
            // 
            this.colCalcNumDeletedSupplierItems.DataPropertyName = "CalcNumDeletedSupplierItems";
            this.colCalcNumDeletedSupplierItems.HeaderText = "[Udmeldte]";
            this.colCalcNumDeletedSupplierItems.Name = "colCalcNumDeletedSupplierItems";
            this.colCalcNumDeletedSupplierItems.ReadOnly = true;
            this.colCalcNumDeletedSupplierItems.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCalcNumDeletedSupplierItems.Width = 60;
            // 
            // colSentOutDateTime
            // 
            this.colSentOutDateTime.DataPropertyName = "SentOutDateTime";
            dataGridViewCellStyle2.Format = "g";
            this.colSentOutDateTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.colSentOutDateTime.HeaderText = "[Udsendelsesdato]";
            this.colSentOutDateTime.Name = "colSentOutDateTime";
            this.colSentOutDateTime.ReadOnly = true;
            this.colSentOutDateTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colFilename
            // 
            this.colFilename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFilename.DataPropertyName = "Filename";
            this.colFilename.HeaderText = "[Filnavn]";
            this.colFilename.Name = "colFilename";
            this.colFilename.ReadOnly = true;
            this.colFilename.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colNumDetailRecords
            // 
            this.colNumDetailRecords.DataPropertyName = "NumDetailRecords";
            this.colNumDetailRecords.HeaderText = "[Detaljer]";
            this.colNumDetailRecords.Name = "colNumDetailRecords";
            this.colNumDetailRecords.ReadOnly = true;
            this.colNumDetailRecords.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colNumDetailRecords.Width = 55;
            // 
            // colCriteria
            // 
            this.colCriteria.DataPropertyName = "Criteria";
            this.colCriteria.HeaderText = "[Kriterier]";
            this.colCriteria.Name = "colCriteria";
            this.colCriteria.ReadOnly = true;
            this.colCriteria.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ExportFVDHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 388);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ExportFVDHeader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExportFVDHeader";
            this.Load += new System.EventHandler(this.ExportFVDHeader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingExportFVDHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private DRS.Extensions.DRS_DataGridView grid;
        private ItemDataSet dsItem;
        private System.Windows.Forms.BindingSource bindingExportFVDHeader;
        private RBOS.ItemDataSetTableAdapters.ExportFVDHeaderTableAdapter adapterExportFVDHeader;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExportDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCalcNumDeletedSupplierItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSentOutDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFilename;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumDetailRecords;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCriteria;
    }
}