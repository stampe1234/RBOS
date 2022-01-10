namespace RBOS
{
    partial class LookupKolliSizeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LookupKolliSizeForm));
            this.bindingLookupKolliSizeAdmin = new System.Windows.Forms.BindingSource(this.components);
            this.dsItem = new RBOS.ItemDataSet();
            this.adapterLookupKolliSizeAdmin = new RBOS.ItemDataSetTableAdapters.LookupKolliSizeAdminTableAdapter();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.popupGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridKolliSizes = new DRS.Extensions.DRS_DataGridView();
            this.colKolliSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBHHTID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupKolliSizeAdmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
            this.popupGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridKolliSizes)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingLookupKolliSizeAdmin
            // 
            this.bindingLookupKolliSizeAdmin.AllowNew = false;
            this.bindingLookupKolliSizeAdmin.DataMember = "LookupKolliSizeAdmin";
            this.bindingLookupKolliSizeAdmin.DataSource = this.dsItem;
            // 
            // dsItem
            // 
            this.dsItem.DataSetName = "ItemDataSet";
            this.dsItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // adapterLookupKolliSizeAdmin
            // 
            this.adapterLookupKolliSizeAdmin.ClearBeforeFill = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(315, 272);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "[Cancel]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Location = new System.Drawing.Point(209, 272);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(100, 23);
            this.btnSaveClose.TabIndex = 2;
            this.btnSaveClose.Text = "[Save and Close]";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // popupGrid
            // 
            this.popupGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.popupGrid.Name = "popupGrid";
            this.popupGrid.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // gridKolliSizes
            // 
            this.gridKolliSizes.AllowUserToResizeColumns = false;
            this.gridKolliSizes.AllowUserToResizeRows = false;
            this.gridKolliSizes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridKolliSizes.AutoGenerateColumns = false;
            this.gridKolliSizes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridKolliSizes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridKolliSizes.ColumnHeadersHeight = 21;
            this.gridKolliSizes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridKolliSizes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKolliSize,
            this.colDescription,
            this.colBHHTID});
            this.gridKolliSizes.ContextMenuStrip = this.popupGrid;
            this.gridKolliSizes.DataSource = this.bindingLookupKolliSizeAdmin;
            this.gridKolliSizes.Location = new System.Drawing.Point(12, 12);
            this.gridKolliSizes.MultiSelect = false;
            this.gridKolliSizes.Name = "gridKolliSizes";
            this.gridKolliSizes.RowHeadersWidth = 25;
            this.gridKolliSizes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridKolliSizes.Size = new System.Drawing.Size(378, 254);
            this.gridKolliSizes.TabIndex = 0;
            this.gridKolliSizes.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            this.gridKolliSizes.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.gridKolliSizes.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.gridKolliSizes_UserDeletingRow);
            // 
            // colKolliSize
            // 
            this.colKolliSize.DataPropertyName = "KolliSize";
            dataGridViewCellStyle1.NullValue = null;
            this.colKolliSize.DefaultCellStyle = dataGridViewCellStyle1;
            this.colKolliSize.HeaderText = "KolliSize";
            this.colKolliSize.Name = "colKolliSize";
            this.colKolliSize.Width = 60;
            // 
            // colDescription
            // 
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            // 
            // colBHHTID
            // 
            this.colBHHTID.DataPropertyName = "BHHTID";
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            this.colBHHTID.DefaultCellStyle = dataGridViewCellStyle2;
            this.colBHHTID.HeaderText = "BHHTID";
            this.colBHHTID.Name = "colBHHTID";
            this.colBHHTID.ReadOnly = true;
            this.colBHHTID.Width = 60;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "KolliSize";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn1.HeaderText = "KolliSize";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn2.HeaderText = "Description";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "BHHTID";
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn3.HeaderText = "BHHTID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // LookupKolliSizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 307);
            this.Controls.Add(this.btnSaveClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gridKolliSizes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LookupKolliSizeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LookupKolliSizeForm";
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupKolliSizeAdmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
            this.popupGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridKolliSizes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DRS.Extensions.DRS_DataGridView gridKolliSizes;
        private ItemDataSet dsItem;
        private System.Windows.Forms.BindingSource bindingLookupKolliSizeAdmin;
        private RBOS.ItemDataSetTableAdapters.LookupKolliSizeAdminTableAdapter adapterLookupKolliSizeAdmin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKolliSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBHHTID;
        private System.Windows.Forms.ContextMenuStrip popupGrid;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}