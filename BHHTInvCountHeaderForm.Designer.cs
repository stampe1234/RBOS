namespace RBOS
{
    partial class BHHTInvCountHeaderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BHHTInvCountHeaderForm));
            this.lookupStatusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsImport = new RBOS.ImportDataSet();
            this.bindingCountHeader = new System.Windows.Forms.BindingSource(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDetailLines = new System.Windows.Forms.Button();
            this.btnBook = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.adapterCountHeader = new RBOS.ImportDataSetTableAdapters.BHHTInvCountHeaderTableAdapter();
            this.lookupStatusTableAdapter = new RBOS.ImportDataSetTableAdapters.LookupStatusTableAdapter();
            this.btnGetPejSale = new System.Windows.Forms.Button();
            this.gridInvCountHeader = new DRS.Extensions.DRS_DataGridView();
            this.colStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colWorkSheetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatusColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCountDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lookupStatusBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingCountHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvCountHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // lookupStatusBindingSource
            // 
            this.lookupStatusBindingSource.DataMember = "LookupStatus";
            this.lookupStatusBindingSource.DataSource = this.dsImport;
            // 
            // dsImport
            // 
            this.dsImport.DataSetName = "ImportDataSet";
            this.dsImport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingCountHeader
            // 
            this.bindingCountHeader.DataMember = "BHHTInvCountHeader";
            this.bindingCountHeader.DataSource = this.dsImport;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(708, 718);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(138, 42);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDetailLines
            // 
            this.btnDetailLines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetailLines.Location = new System.Drawing.Point(559, 718);
            this.btnDetailLines.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnDetailLines.Name = "btnDetailLines";
            this.btnDetailLines.Size = new System.Drawing.Size(138, 42);
            this.btnDetailLines.TabIndex = 2;
            this.btnDetailLines.Text = "[Detail lines]";
            this.btnDetailLines.UseVisualStyleBackColor = true;
            this.btnDetailLines.Click += new System.EventHandler(this.btnDetailLines_Click);
            // 
            // btnBook
            // 
            this.btnBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBook.Location = new System.Drawing.Point(411, 718);
            this.btnBook.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(138, 42);
            this.btnBook.TabIndex = 3;
            this.btnBook.Text = "[Book]";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(262, 718);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(138, 42);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "[Delete]";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // adapterCountHeader
            // 
            this.adapterCountHeader.ClearBeforeFill = true;
            // 
            // lookupStatusTableAdapter
            // 
            this.lookupStatusTableAdapter.ClearBeforeFill = true;
            // 
            // btnGetPejSale
            // 
            this.btnGetPejSale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetPejSale.Enabled = false;
            this.btnGetPejSale.Location = new System.Drawing.Point(110, 718);
            this.btnGetPejSale.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnGetPejSale.Name = "btnGetPejSale";
            this.btnGetPejSale.Size = new System.Drawing.Size(141, 42);
            this.btnGetPejSale.TabIndex = 8;
            this.btnGetPejSale.Text = "Hent Salg";
            this.btnGetPejSale.UseVisualStyleBackColor = true;
            this.btnGetPejSale.Visible = false;
            this.btnGetPejSale.Click += new System.EventHandler(this.btnGetPejSale_Click);
            // 
            // gridInvCountHeader
            // 
            this.gridInvCountHeader.AllowUserToAddRows = false;
            this.gridInvCountHeader.AllowUserToDeleteRows = false;
            this.gridInvCountHeader.AllowUserToResizeColumns = false;
            this.gridInvCountHeader.AllowUserToResizeRows = false;
            this.gridInvCountHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridInvCountHeader.AutoGenerateColumns = false;
            this.gridInvCountHeader.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridInvCountHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridInvCountHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridInvCountHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStatus,
            this.colWorkSheetName,
            this.colStatusColor,
            this.colCountID,
            this.colCountDate});
            this.gridInvCountHeader.DataSource = this.bindingCountHeader;
            this.gridInvCountHeader.Location = new System.Drawing.Point(22, 22);
            this.gridInvCountHeader.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gridInvCountHeader.MultiSelect = false;
            this.gridInvCountHeader.Name = "gridInvCountHeader";
            this.gridInvCountHeader.ReadOnly = true;
            this.gridInvCountHeader.RowHeadersWidth = 25;
            this.gridInvCountHeader.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridInvCountHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridInvCountHeader.Size = new System.Drawing.Size(823, 685);
            this.gridInvCountHeader.TabIndex = 0;
            this.gridInvCountHeader.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridInvCountHeader_CellMouseDoubleClick);
            this.gridInvCountHeader.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gridInvCountHeader_CellPainting);
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.DataSource = this.lookupStatusBindingSource;
            this.colStatus.DisplayMember = "Description";
            this.colStatus.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colStatus.ValueMember = "StatusID";
            // 
            // colWorkSheetName
            // 
            this.colWorkSheetName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colWorkSheetName.DataPropertyName = "WorkSheetName";
            this.colWorkSheetName.HeaderText = "WorkSheetName";
            this.colWorkSheetName.Name = "colWorkSheetName";
            this.colWorkSheetName.ReadOnly = true;
            // 
            // colStatusColor
            // 
            this.colStatusColor.HeaderText = "";
            this.colStatusColor.Name = "colStatusColor";
            this.colStatusColor.ReadOnly = true;
            this.colStatusColor.Width = 20;
            // 
            // colCountID
            // 
            this.colCountID.DataPropertyName = "CountID";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colCountID.DefaultCellStyle = dataGridViewCellStyle1;
            this.colCountID.HeaderText = "CountID";
            this.colCountID.Name = "colCountID";
            this.colCountID.ReadOnly = true;
            this.colCountID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colCountID.Width = 50;
            // 
            // colCountDate
            // 
            this.colCountDate.DataPropertyName = "CountDate";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colCountDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCountDate.HeaderText = "CountDate";
            this.colCountDate.Name = "colCountDate";
            this.colCountDate.ReadOnly = true;
            this.colCountDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CountID";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn1.HeaderText = "CountID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CountDate";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn2.HeaderText = "CountDate";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "BusinessDate";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn3.HeaderText = "BusinessDate";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "WorkSheetID";
            this.dataGridViewTextBoxColumn4.HeaderText = "WorkSheetID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn5.HeaderText = "Status";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 50;
            // 
            // BHHTInvCountHeaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 783);
            this.Controls.Add(this.btnGetPejSale);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.btnDetailLines);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gridInvCountHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "BHHTInvCountHeaderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BHHTInvCountHeaderForm";
            this.Load += new System.EventHandler(this.BHHTInvCountHeaderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lookupStatusBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingCountHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvCountHeader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DRS.Extensions.DRS_DataGridView gridInvCountHeader;
        private ImportDataSet dsImport;
        private System.Windows.Forms.BindingSource bindingCountHeader;
        private RBOS.ImportDataSetTableAdapters.BHHTInvCountHeaderTableAdapter adapterCountHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDetailLines;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.BindingSource lookupStatusBindingSource;
        private RBOS.ImportDataSetTableAdapters.LookupStatusTableAdapter lookupStatusTableAdapter;
        private System.Windows.Forms.DataGridViewComboBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkSheetName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatusColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCountDate;
        private System.Windows.Forms.Button btnGetPejSale;
    }
}