namespace RBOS
{
    partial class BHHTInvAdjustForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BHHTInvAdjustForm));
            this.lbShowType = new System.Windows.Forms.Label();
            this.comboShowType = new System.Windows.Forms.ComboBox();
            this.bindingLookupInvAdjustType = new System.Windows.Forms.BindingSource(this.components);
            this.dsImport = new RBOS.ImportDataSet();
            this.gridInvAdjustHeader = new DRS.Extensions.DRS_DataGridView();
            this.colAdjustID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdjustDate = new DRS.Extensions.DRS_CalendarColumn();
            this.colReasonCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bindingStatusLookup = new System.Windows.Forms.BindingSource(this.components);
            this.colStatusColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingInvAdjustHeader = new System.Windows.Forms.BindingSource(this.components);
            this.bindingBHHTWorksheet = new System.Windows.Forms.BindingSource(this.components);
            this.dsItem = new RBOS.ItemDataSet();
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnBook = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adapterInvAdjustHeader = new RBOS.ImportDataSetTableAdapters.BHHTInvAdjustHeaderTableAdapter();
            this.adapterLookupInvAdjustType = new RBOS.ImportDataSetTableAdapters.LookupInvAdjustTypeTableAdapter();
            this.adapterStatusLookup = new RBOS.ImportDataSetTableAdapters.LookupStatusTableAdapter();
            this.adapterBHHTWorksheet = new RBOS.ItemDataSetTableAdapters.BHHTWorksheetTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupInvAdjustType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvAdjustHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingStatusLookup)).BeginInit();
            this.contextDelete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingInvAdjustHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingBHHTWorksheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
            this.SuspendLayout();
            // 
            // lbShowType
            // 
            this.lbShowType.AutoSize = true;
            this.lbShowType.Location = new System.Drawing.Point(12, 12);
            this.lbShowType.Name = "lbShowType";
            this.lbShowType.Size = new System.Drawing.Size(40, 13);
            this.lbShowType.TabIndex = 0;
            this.lbShowType.Text = "[Show]";
            // 
            // comboShowType
            // 
            this.comboShowType.DataSource = this.bindingLookupInvAdjustType;
            this.comboShowType.DisplayMember = "Description";
            this.comboShowType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboShowType.FormattingEnabled = true;
            this.comboShowType.Location = new System.Drawing.Point(76, 9);
            this.comboShowType.Name = "comboShowType";
            this.comboShowType.Size = new System.Drawing.Size(131, 21);
            this.comboShowType.TabIndex = 1;
            this.comboShowType.ValueMember = "InvAdjustType";
            this.comboShowType.SelectedIndexChanged += new System.EventHandler(this.comboShowType_SelectedIndexChanged);
            // 
            // bindingLookupInvAdjustType
            // 
            this.bindingLookupInvAdjustType.DataMember = "LookupInvAdjustType";
            this.bindingLookupInvAdjustType.DataSource = this.dsImport;
            // 
            // dsImport
            // 
            this.dsImport.DataSetName = "ImportDataSet";
            this.dsImport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridInvAdjustHeader
            // 
            this.gridInvAdjustHeader.AllowUserToAddRows = false;
            this.gridInvAdjustHeader.AllowUserToResizeColumns = false;
            this.gridInvAdjustHeader.AllowUserToResizeRows = false;
            this.gridInvAdjustHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridInvAdjustHeader.AutoGenerateColumns = false;
            this.gridInvAdjustHeader.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridInvAdjustHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridInvAdjustHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridInvAdjustHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAdjustID,
            this.colAdjustDate,
            this.colReasonCode,
            this.colStatus,
            this.colStatusColor});
            this.gridInvAdjustHeader.ContextMenuStrip = this.contextDelete;
            this.gridInvAdjustHeader.DataSource = this.bindingInvAdjustHeader;
            this.gridInvAdjustHeader.Location = new System.Drawing.Point(12, 36);
            this.gridInvAdjustHeader.MultiSelect = false;
            this.gridInvAdjustHeader.Name = "gridInvAdjustHeader";
            this.gridInvAdjustHeader.RowHeadersWidth = 25;
            this.gridInvAdjustHeader.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridInvAdjustHeader.Size = new System.Drawing.Size(476, 336);
            this.gridInvAdjustHeader.TabIndex = 2;
            this.gridInvAdjustHeader.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridInvAdjustHeader_CellBeginEdit);
            this.gridInvAdjustHeader.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridInvAdjustHeader_CellDoubleClick);
            this.gridInvAdjustHeader.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gridInvAdjustHeader_CellPainting);
            this.gridInvAdjustHeader.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridInvAdjustHeader_RowValidated);
            this.gridInvAdjustHeader.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.gridInvAdjustHeader_UserDeletingRow);
            // 
            // colAdjustID
            // 
            this.colAdjustID.DataPropertyName = "AdjustID";
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.colAdjustID.DefaultCellStyle = dataGridViewCellStyle1;
            this.colAdjustID.HeaderText = "AdjustID";
            this.colAdjustID.Name = "colAdjustID";
            this.colAdjustID.ReadOnly = true;
            this.colAdjustID.Width = 50;
            // 
            // colAdjustDate
            // 
            this.colAdjustDate.DataPropertyName = "AdjustDate";
            this.colAdjustDate.HeaderText = "AdjustDate";
            this.colAdjustDate.Name = "colAdjustDate";
            this.colAdjustDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAdjustDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colAdjustDate.Width = 80;
            // 
            // colReasonCode
            // 
            this.colReasonCode.DataPropertyName = "ReasonCode";
            this.colReasonCode.DataSource = this.bindingLookupInvAdjustType;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            this.colReasonCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.colReasonCode.DisplayMember = "Description";
            this.colReasonCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colReasonCode.HeaderText = "ReasonCode";
            this.colReasonCode.Name = "colReasonCode";
            this.colReasonCode.ReadOnly = true;
            this.colReasonCode.ValueMember = "InvAdjustType";
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.DataSource = this.bindingStatusLookup;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            this.colStatus.DefaultCellStyle = dataGridViewCellStyle3;
            this.colStatus.DisplayMember = "Description";
            this.colStatus.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.ValueMember = "StatusID";
            // 
            // bindingStatusLookup
            // 
            this.bindingStatusLookup.DataMember = "LookupStatus";
            this.bindingStatusLookup.DataSource = this.dsImport;
            // 
            // colStatusColor
            // 
            this.colStatusColor.DataPropertyName = "StatusColor";
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            this.colStatusColor.DefaultCellStyle = dataGridViewCellStyle4;
            this.colStatusColor.HeaderText = "";
            this.colStatusColor.Name = "colStatusColor";
            this.colStatusColor.ReadOnly = true;
            this.colStatusColor.Width = 20;
            // 
            // contextDelete
            // 
            this.contextDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDelete});
            this.contextDelete.Name = "contextDelete";
            this.contextDelete.Size = new System.Drawing.Size(116, 26);
            // 
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(115, 22);
            this.btnDelete.Text = "[Delete]";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // bindingInvAdjustHeader
            // 
            this.bindingInvAdjustHeader.DataMember = "BHHTInvAdjustHeader";
            this.bindingInvAdjustHeader.DataSource = this.dsImport;
            // 
            // bindingBHHTWorksheet
            // 
            this.bindingBHHTWorksheet.DataMember = "BHHTWorksheet";
            this.bindingBHHTWorksheet.DataSource = this.dsItem;
            // 
            // dsItem
            // 
            this.dsItem.DataSetName = "ItemDataSet";
            this.dsItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnDetails
            // 
            this.btnDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetails.Location = new System.Drawing.Point(329, 381);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(75, 23);
            this.btnDetails.TabIndex = 4;
            this.btnDetails.Text = "[Details]";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(410, 381);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnBook
            // 
            this.btnBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBook.Location = new System.Drawing.Point(248, 381);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(75, 23);
            this.btnBook.TabIndex = 6;
            this.btnBook.Text = "[Book]";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "AdjustID";
            this.dataGridViewTextBoxColumn1.HeaderText = "AdjustID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "AdjustDate";
            this.dataGridViewTextBoxColumn2.HeaderText = "AdjustDate";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "BusinessDate";
            this.dataGridViewTextBoxColumn3.HeaderText = "BusinessDate";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "WorkSheetID";
            this.dataGridViewTextBoxColumn4.HeaderText = "WorkSheetID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn5.HeaderText = "Status";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ReasonCode";
            this.dataGridViewTextBoxColumn6.HeaderText = "ReasonCode";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // adapterInvAdjustHeader
            // 
            this.adapterInvAdjustHeader.ClearBeforeFill = true;
            // 
            // adapterLookupInvAdjustType
            // 
            this.adapterLookupInvAdjustType.ClearBeforeFill = true;
            // 
            // adapterStatusLookup
            // 
            this.adapterStatusLookup.ClearBeforeFill = true;
            // 
            // adapterBHHTWorksheet
            // 
            this.adapterBHHTWorksheet.ClearBeforeFill = true;
            // 
            // BHHTInvAdjustForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 416);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.comboShowType);
            this.Controls.Add(this.lbShowType);
            this.Controls.Add(this.gridInvAdjustHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BHHTInvAdjustForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BHHTInvAdjustForm";
            this.Load += new System.EventHandler(this.BHHTInvAdjustForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupInvAdjustType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvAdjustHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingStatusLookup)).EndInit();
            this.contextDelete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingInvAdjustHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingBHHTWorksheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbShowType;
        private System.Windows.Forms.ComboBox comboShowType;
        private DRS.Extensions.DRS_DataGridView gridInvAdjustHeader;
        private ImportDataSet dsImport;
        private System.Windows.Forms.BindingSource bindingInvAdjustHeader;
        private RBOS.ImportDataSetTableAdapters.BHHTInvAdjustHeaderTableAdapter adapterInvAdjustHeader;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.BindingSource bindingLookupInvAdjustType;
        private RBOS.ImportDataSetTableAdapters.LookupInvAdjustTypeTableAdapter adapterLookupInvAdjustType;
        private System.Windows.Forms.ContextMenuStrip contextDelete;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
        private System.Windows.Forms.BindingSource bindingStatusLookup;
        private RBOS.ImportDataSetTableAdapters.LookupStatusTableAdapter adapterStatusLookup;
        private ItemDataSet dsItem;
        private System.Windows.Forms.BindingSource bindingBHHTWorksheet;
        private RBOS.ItemDataSetTableAdapters.BHHTWorksheetTableAdapter adapterBHHTWorksheet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdjustID;
        private DRS.Extensions.DRS_CalendarColumn colAdjustDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn colReasonCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatusColor;
    }
}