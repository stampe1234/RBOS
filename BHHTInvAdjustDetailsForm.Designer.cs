namespace RBOS
{
    partial class BHHTInvAdjustDetailsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BHHTInvAdjustDetailsForm));
            this.bindingLookupItem = new System.Windows.Forms.BindingSource(this.components);
            this.dsImport = new RBOS.ImportDataSet();
            this.bindingLookupPackType = new System.Windows.Forms.BindingSource(this.components);
            this.dsItem = new RBOS.ItemDataSet();
            this.bindingInvAdjustDetails = new System.Windows.Forms.BindingSource(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.adapterInvAdjustDetails = new RBOS.ImportDataSetTableAdapters.BHHTInvAdjustDetailsTableAdapter();
            this.adapterLookupItem = new RBOS.ImportDataSetTableAdapters.LookupItemTableAdapter();
            this.adapterLookupPackType = new RBOS.ItemDataSetTableAdapters.LookupPackSizeTableAdapter();
            this.dataGridView1 = new DRS.Extensions.DRS_DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colPackType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colExclude = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colAdjustID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeStmp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupPackType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingInvAdjustDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingLookupItem
            // 
            this.bindingLookupItem.DataMember = "LookupItem";
            this.bindingLookupItem.DataSource = this.dsImport;
            // 
            // dsImport
            // 
            this.dsImport.DataSetName = "ImportDataSet";
            this.dsImport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingLookupPackType
            // 
            this.bindingLookupPackType.DataMember = "LookupPackSize";
            this.bindingLookupPackType.DataSource = this.dsItem;
            this.bindingLookupPackType.CurrentChanged += new System.EventHandler(this.lookupPackSizeBindingSource_CurrentChanged);
            // 
            // dsItem
            // 
            this.dsItem.DataSetName = "ItemDataSet";
            this.dsItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingInvAdjustDetails
            // 
            this.bindingInvAdjustDetails.DataMember = "BHHTInvAdjustDetails";
            this.bindingInvAdjustDetails.DataSource = this.dsImport;
            this.bindingInvAdjustDetails.CurrentChanged += new System.EventHandler(this.bindingInvAdjustDetails_CurrentChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(456, 317);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // adapterInvAdjustDetails
            // 
            this.adapterInvAdjustDetails.ClearBeforeFill = true;
            // 
            // adapterLookupItem
            // 
            this.adapterLookupItem.ClearBeforeFill = true;
            // 
            // adapterLookupPackType
            // 
            this.adapterLookupPackType.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItemID,
            this.colPackType,
            this.colExclude,
            this.colAdjustID,
            this.colQuantity,
            this.colTimeStmp});
            this.dataGridView1.DataSource = this.bindingInvAdjustDetails;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(519, 299);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowValidated);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "AdjustID";
            this.dataGridViewTextBoxColumn1.HeaderText = "AdjustID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 96;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "LineNo";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn2.HeaderText = "LineNo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 96;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ItemID";
            this.dataGridViewTextBoxColumn3.HeaderText = "ItemID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PackType";
            this.dataGridViewTextBoxColumn4.HeaderText = "PackType";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Quantity";
            this.dataGridViewTextBoxColumn5.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 96;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TimeStmp";
            this.dataGridViewTextBoxColumn6.HeaderText = "TimeStmp";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 96;
            // 
            // colItemID
            // 
            this.colItemID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colItemID.DataPropertyName = "ItemID";
            this.colItemID.DataSource = this.bindingLookupItem;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.colItemID.DefaultCellStyle = dataGridViewCellStyle1;
            this.colItemID.DisplayMember = "ItemName";
            this.colItemID.HeaderText = "ItemID";
            this.colItemID.Name = "colItemID";
            this.colItemID.ReadOnly = true;
            this.colItemID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colItemID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colItemID.ValueMember = "ItemID";
            // 
            // colPackType
            // 
            this.colPackType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPackType.DataPropertyName = "PackType";
            this.colPackType.DataSource = this.bindingLookupPackType;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            this.colPackType.DefaultCellStyle = dataGridViewCellStyle2;
            this.colPackType.DisplayMember = "PackTypeName";
            this.colPackType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colPackType.HeaderText = "PackType";
            this.colPackType.Name = "colPackType";
            this.colPackType.ReadOnly = true;
            this.colPackType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPackType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colPackType.ValueMember = "PackType";
            // 
            // colExclude
            // 
            this.colExclude.DataPropertyName = "Exclude";
            this.colExclude.HeaderText = "Exclude";
            this.colExclude.Name = "colExclude";
            this.colExclude.Width = 50;
            // 
            // colAdjustID
            // 
            this.colAdjustID.DataPropertyName = "AdjustID";
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            this.colAdjustID.DefaultCellStyle = dataGridViewCellStyle3;
            this.colAdjustID.HeaderText = "AdjustID";
            this.colAdjustID.Name = "colAdjustID";
            this.colAdjustID.ReadOnly = true;
            this.colAdjustID.Width = 50;
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colQuantity.DefaultCellStyle = dataGridViewCellStyle4;
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Width = 50;
            // 
            // colTimeStmp
            // 
            this.colTimeStmp.DataPropertyName = "TimeStmp";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            this.colTimeStmp.DefaultCellStyle = dataGridViewCellStyle5;
            this.colTimeStmp.HeaderText = "TimeStmp";
            this.colTimeStmp.Name = "colTimeStmp";
            this.colTimeStmp.ReadOnly = true;
            // 
            // BHHTInvAdjustDetailsForm
            // 
            this.ClientSize = new System.Drawing.Size(543, 352);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BHHTInvAdjustDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[BHHTInvAdjustDetails]";
            this.Load += new System.EventHandler(this.BHHTInvAdjustDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupPackType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingInvAdjustDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DRS.Extensions.DRS_DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingInvAdjustDetails;
        private ImportDataSet dsImport;
        private RBOS.ImportDataSetTableAdapters.BHHTInvAdjustDetailsTableAdapter adapterInvAdjustDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.BindingSource bindingLookupItem;
        private RBOS.ImportDataSetTableAdapters.LookupItemTableAdapter adapterLookupItem;
        private ItemDataSet dsItem;
        private System.Windows.Forms.BindingSource bindingLookupPackType;
        private RBOS.ItemDataSetTableAdapters.LookupPackSizeTableAdapter adapterLookupPackType;
        private System.Windows.Forms.DataGridViewComboBoxColumn colItemID;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPackType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colExclude;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdjustID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeStmp;
    }
}