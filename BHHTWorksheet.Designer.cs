namespace RBOS
{
    partial class BHHTWorksheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BHHTWorksheet));
            this.gridWorksheet = new DRS.Extensions.DRS_DataGridView();
            this.bindingWorksheet = new System.Windows.Forms.BindingSource(this.components);
            this.dsItem = new RBOS.ItemDataSet();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.adapterWorksheet = new RBOS.ItemDataSetTableAdapters.BHHTWorksheetTableAdapter();
            this.bindingLookupWSType = new System.Windows.Forms.BindingSource(this.components);
            this.adapterLookupWSType = new RBOS.ItemDataSetTableAdapters.LookupWSTypeTableAdapter();
            this.bindingLookupWSInclude = new System.Windows.Forms.BindingSource(this.components);
            this.adapterLookupWSInclude = new RBOS.ItemDataSetTableAdapters.LookupWSIncludeTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colInclude = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridWorksheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingWorksheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupWSType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupWSInclude)).BeginInit();
            this.SuspendLayout();
            // 
            // gridWorksheet
            // 
            this.gridWorksheet.AllowUserToAddRows = false;
            this.gridWorksheet.AllowUserToDeleteRows = false;
            this.gridWorksheet.AllowUserToResizeColumns = false;
            this.gridWorksheet.AllowUserToResizeRows = false;
            this.gridWorksheet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridWorksheet.AutoGenerateColumns = false;
            this.gridWorksheet.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridWorksheet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridWorksheet.ColumnHeadersHeight = 21;
            this.gridWorksheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridWorksheet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colType,
            this.colInclude,
            this.colID,
            this.colName});
            this.gridWorksheet.DataSource = this.bindingWorksheet;
            this.gridWorksheet.Location = new System.Drawing.Point(13, 13);
            this.gridWorksheet.MultiSelect = false;
            this.gridWorksheet.Name = "gridWorksheet";
            this.gridWorksheet.ReadOnly = true;
            this.gridWorksheet.RowHeadersWidth = 25;
            this.gridWorksheet.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridWorksheet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridWorksheet.Size = new System.Drawing.Size(463, 299);
            this.gridWorksheet.TabIndex = 0;
            this.gridWorksheet.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridWorksheet_MouseDoubleClick);
            // 
            // bindingWorksheet
            // 
            this.bindingWorksheet.DataMember = "BHHTWorksheet";
            this.bindingWorksheet.DataSource = this.dsItem;
            // 
            // dsItem
            // 
            this.dsItem.DataSetName = "ItemDataSet";
            this.dsItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(401, 318);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(158, 318);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "[New sheet]";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(239, 318);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "[Delete]";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(320, 318);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "[Edit]";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // adapterWorksheet
            // 
            this.adapterWorksheet.ClearBeforeFill = true;
            // 
            // bindingLookupWSType
            // 
            this.bindingLookupWSType.DataMember = "LookupWSType";
            this.bindingLookupWSType.DataSource = this.dsItem;
            // 
            // adapterLookupWSType
            // 
            this.adapterLookupWSType.ClearBeforeFill = true;
            // 
            // bindingLookupWSInclude
            // 
            this.bindingLookupWSInclude.DataMember = "LookupWSInclude";
            this.bindingLookupWSInclude.DataSource = this.dsItem;
            // 
            // adapterLookupWSInclude
            // 
            this.adapterLookupWSInclude.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Type";
            this.dataGridViewTextBoxColumn3.HeaderText = "Type";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Include";
            this.dataGridViewTextBoxColumn4.HeaderText = "Include";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 50;
            // 
            // colType
            // 
            this.colType.DataPropertyName = "Type";
            this.colType.DataSource = this.bindingLookupWSType;
            this.colType.DisplayMember = "Description";
            this.colType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colType.ValueMember = "ID";
            this.colType.Width = 80;
            // 
            // colInclude
            // 
            this.colInclude.DataPropertyName = "Include";
            this.colInclude.DataSource = this.bindingLookupWSInclude;
            this.colInclude.DisplayMember = "Description";
            this.colInclude.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colInclude.HeaderText = "Include";
            this.colInclude.Name = "colInclude";
            this.colInclude.ReadOnly = true;
            this.colInclude.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colInclude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colInclude.ValueMember = "ID";
            this.colInclude.Width = 80;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 50;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // BHHTWorksheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 353);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gridWorksheet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BHHTWorksheet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BHHTWorksheet";
            this.Load += new System.EventHandler(this.BHHTWorksheet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridWorksheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingWorksheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupWSType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupWSInclude)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DRS.Extensions.DRS_DataGridView gridWorksheet;
        private System.Windows.Forms.Button btnClose;
        private ItemDataSet dsItem;
        private System.Windows.Forms.BindingSource bindingWorksheet;
        private RBOS.ItemDataSetTableAdapters.BHHTWorksheetTableAdapter adapterWorksheet;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.BindingSource bindingLookupWSType;
        private RBOS.ItemDataSetTableAdapters.LookupWSTypeTableAdapter adapterLookupWSType;
        private System.Windows.Forms.BindingSource bindingLookupWSInclude;
        private RBOS.ItemDataSetTableAdapters.LookupWSIncludeTableAdapter adapterLookupWSInclude;
        private System.Windows.Forms.DataGridViewComboBoxColumn colType;
        private System.Windows.Forms.DataGridViewComboBoxColumn colInclude;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
    }
}