namespace RBOS
{
    partial class PackSizeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PackSizeForm));
            this.popupDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingPackSize = new System.Windows.Forms.BindingSource(this.components);
            this.dsItem = new RBOS.ItemDataSet();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.adapterPackSize = new RBOS.ItemDataSetTableAdapters.PackSizeConfigTableAdapter();
            this.gridPackSizes = new DRS.Extensions.DRS_DataGridView();
            this.colSys = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colPackType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.popupDelete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingPackSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPackSizes)).BeginInit();
            this.SuspendLayout();
            // 
            // popupDelete
            // 
            this.popupDelete.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.popupDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.popupDelete.Name = "popupDelete";
            this.popupDelete.Size = new System.Drawing.Size(145, 36);
            this.popupDelete.Opening += new System.ComponentModel.CancelEventHandler(this.popupDelete_Opening);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(144, 32);
            this.deleteToolStripMenuItem.Text = "[Delete]";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // bindingPackSize
            // 
            this.bindingPackSize.DataMember = "PackSizeConfig";
            this.bindingPackSize.DataSource = this.dsItem;
            // 
            // dsItem
            // 
            this.dsItem.DataSetName = "ItemDataSet";
            this.dsItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(448, 534);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 35);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "[Save]";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(570, 534);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 35);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "[Cancel]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // adapterPackSize
            // 
            this.adapterPackSize.ClearBeforeFill = true;
            // 
            // gridPackSizes
            // 
            this.gridPackSizes.AllowUserToResizeColumns = false;
            this.gridPackSizes.AllowUserToResizeRows = false;
            this.gridPackSizes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPackSizes.AutoGenerateColumns = false;
            this.gridPackSizes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridPackSizes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridPackSizes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPackSizes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSys,
            this.colPackType,
            this.colPackTypeName,
            this.colAmount});
            this.gridPackSizes.ContextMenuStrip = this.popupDelete;
            this.gridPackSizes.DataSource = this.bindingPackSize;
            this.gridPackSizes.Location = new System.Drawing.Point(18, 18);
            this.gridPackSizes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridPackSizes.MultiSelect = false;
            this.gridPackSizes.Name = "gridPackSizes";
            this.gridPackSizes.RowHeadersWidth = 25;
            this.gridPackSizes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridPackSizes.Size = new System.Drawing.Size(664, 506);
            this.gridPackSizes.TabIndex = 0;
            this.gridPackSizes.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridPackSizes_CellBeginEdit);
            this.gridPackSizes.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gridPackSizes_CellValidating);
            this.gridPackSizes.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridPackSizes_RowValidating);
            this.gridPackSizes.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.gridPackSizes_UserAddedRow);
            this.gridPackSizes.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.gridPackSizes_UserDeletingRow);
            // 
            // colSys
            // 
            this.colSys.DataPropertyName = "Sys";
            this.colSys.HeaderText = "[Sys]";
            this.colSys.MinimumWidth = 8;
            this.colSys.Name = "colSys";
            this.colSys.ReadOnly = true;
            this.colSys.Width = 40;
            // 
            // colPackType
            // 
            this.colPackType.DataPropertyName = "PackType";
            this.colPackType.HeaderText = "[ID]";
            this.colPackType.MinimumWidth = 8;
            this.colPackType.Name = "colPackType";
            this.colPackType.ReadOnly = true;
            this.colPackType.Width = 50;
            // 
            // colPackTypeName
            // 
            this.colPackTypeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPackTypeName.DataPropertyName = "PackTypeName";
            this.colPackTypeName.HeaderText = "[Description]";
            this.colPackTypeName.MaxInputLength = 8;
            this.colPackTypeName.MinimumWidth = 8;
            this.colPackTypeName.Name = "colPackTypeName";
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            this.colAmount.HeaderText = "[Sell. Units]";
            this.colAmount.MinimumWidth = 8;
            this.colAmount.Name = "colAmount";
            this.colAmount.Width = 90;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PackType";
            this.dataGridViewTextBoxColumn1.HeaderText = "[ID]";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PackTypeName";
            this.dataGridViewTextBoxColumn2.HeaderText = "[Description]";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 8;
            this.dataGridViewTextBoxColumn2.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Amount";
            this.dataGridViewTextBoxColumn3.HeaderText = "[Sell. Units]";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 90;
            // 
            // PackSizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 588);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gridPackSizes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "PackSizeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PackSizeForm";
            this.Load += new System.EventHandler(this.PackSizeForm_Load);
            this.popupDelete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingPackSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPackSizes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DRS.Extensions.DRS_DataGridView gridPackSizes;
        private ItemDataSet dsItem;
        private System.Windows.Forms.BindingSource bindingPackSize;
        private RBOS.ItemDataSetTableAdapters.PackSizeConfigTableAdapter adapterPackSize;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ContextMenuStrip popupDelete;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSys;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;



    }
}