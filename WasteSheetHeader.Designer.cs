namespace RBOS
{
    partial class WasteSheetHeader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WasteSheetHeader));
            this.btnReport = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SC = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Waste = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Book = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.bindingWasteSheetLookups = new System.Windows.Forms.BindingSource(this.components);
            this.dsItem = new RBOS.ItemDataSet();
            this.bindingWasteSheetHeader = new System.Windows.Forms.BindingSource(this.components);
            this.btnBook = new System.Windows.Forms.Button();
            this.adapterWasteSheetHeader = new RBOS.ItemDataSetTableAdapters.WasteSheetHeaderTableAdapter();
            this.adapterWasteSheetLookups = new RBOS.ItemDataSetTableAdapters.WasteSheetHeaderLookupsTableAdapter();
            this.adapterInvCountWork = new RBOS.ItemDataSetTableAdapters.InvCountWorkTableAdapter();
            this.grid = new DRS.Extensions.DRS_DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumDetailRecords = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoOffRegistrations = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingWasteSheetLookups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingWasteSheetHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.Location = new System.Drawing.Point(366, 400);
            this.btnReport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(112, 35);
            this.btnReport.TabIndex = 1;
            this.btnReport.Text = "[Rapport]";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(514, 400);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(112, 35);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Registrering";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(634, 400);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 35);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "[Luk]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // SC
            // 
            this.SC.DataPropertyName = "SC";
            this.SC.HeaderText = "Optælling";
            this.SC.MinimumWidth = 8;
            this.SC.Name = "SC";
            this.SC.ReadOnly = true;
            this.SC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SC.Width = 60;
            // 
            // Waste
            // 
            this.Waste.DataPropertyName = "Waste";
            this.Waste.HeaderText = "Afskrivning";
            this.Waste.MinimumWidth = 8;
            this.Waste.Name = "Waste";
            this.Waste.ReadOnly = true;
            this.Waste.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Waste.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Waste.Width = 60;
            // 
            // Book
            // 
            this.Book.DataPropertyName = "Book";
            this.Book.HeaderText = "Bogfør";
            this.Book.MinimumWidth = 8;
            this.Book.Name = "Book";
            this.Book.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Book.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Book.Visible = false;
            this.Book.Width = 50;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 320);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 28);
            this.button1.TabIndex = 7;
            this.button1.Text = "Bogfør";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // bindingWasteSheetLookups
            // 
            this.bindingWasteSheetLookups.DataMember = "WasteSheetHeaderLookups";
            this.bindingWasteSheetLookups.DataSource = this.dsItem;
            // 
            // dsItem
            // 
            this.dsItem.DataSetName = "ItemDataSet";
            this.dsItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingWasteSheetHeader
            // 
            this.bindingWasteSheetHeader.DataMember = "WasteSheetHeader";
            this.bindingWasteSheetHeader.DataSource = this.dsItem;
            // 
            // btnBook
            // 
            this.btnBook.Location = new System.Drawing.Point(261, 400);
            this.btnBook.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(84, 32);
            this.btnBook.TabIndex = 7;
            this.btnBook.Text = "Bogfør";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // adapterWasteSheetHeader
            // 
            this.adapterWasteSheetHeader.ClearBeforeFill = true;
            // 
            // adapterWasteSheetLookups
            // 
            this.adapterWasteSheetLookups.ClearBeforeFill = true;
            // 
            // adapterInvCountWork
            // 
            this.adapterInvCountWork.ClearBeforeFill = true;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
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
            this.colName,
            this.colNumDetailRecords,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewTextBoxColumn1});
            this.grid.DataSource = this.bindingWasteSheetHeader;
            this.grid.Location = new System.Drawing.Point(14, 15);
            this.grid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.RowHeadersWidth = 25;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(734, 302);
            this.grid.TabIndex = 6;
            this.grid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentDoubleClick);
            this.grid.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grid_MouseDoubleClick);
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.MinimumWidth = 8;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colNumDetailRecords
            // 
            this.colNumDetailRecords.DataPropertyName = "ID";
            this.colNumDetailRecords.DataSource = this.bindingWasteSheetLookups;
            this.colNumDetailRecords.DisplayMember = "NumDetailRecords";
            this.colNumDetailRecords.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colNumDetailRecords.HeaderText = "Items";
            this.colNumDetailRecords.MinimumWidth = 8;
            this.colNumDetailRecords.Name = "colNumDetailRecords";
            this.colNumDetailRecords.ReadOnly = true;
            this.colNumDetailRecords.ValueMember = "HeaderID";
            this.colNumDetailRecords.Width = 60;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "SC";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Optælling";
            this.dataGridViewCheckBoxColumn1.MinimumWidth = 6;
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.Width = 80;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "Waste";
            this.dataGridViewCheckBoxColumn2.HeaderText = "Afskrivning";
            this.dataGridViewCheckBoxColumn2.MinimumWidth = 6;
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.ReadOnly = true;
            this.dataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "NoOffRegistrations";
            this.dataGridViewTextBoxColumn1.HeaderText = "Antal poster";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // NoOffRegistrations
            // 
            this.NoOffRegistrations.DataPropertyName = "NoOffRegistrations";
            this.NoOffRegistrations.HeaderText = "NoOffRegistrations";
            this.NoOffRegistrations.MinimumWidth = 6;
            this.NoOffRegistrations.Name = "NoOffRegistrations";
            this.NoOffRegistrations.Width = 125;
            // 
            // WasteSheetHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 454);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "WasteSheetHeader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WasteSheetHeader";
            this.Load += new System.EventHandler(this.WasteSheetHeader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingWasteSheetLookups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingWasteSheetHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private DRS.Extensions.DRS_DataGridView grid;
        private ItemDataSet dsItem;
        private System.Windows.Forms.BindingSource bindingWasteSheetHeader;
        private RBOS.ItemDataSetTableAdapters.WasteSheetHeaderTableAdapter adapterWasteSheetHeader;
        private System.Windows.Forms.BindingSource bindingWasteSheetLookups;
        private RBOS.ItemDataSetTableAdapters.WasteSheetHeaderLookupsTableAdapter adapterWasteSheetLookups;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SC;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Waste;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Book;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoOffRegistrations;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colNumDetailRecords;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private ItemDataSetTableAdapters.InvCountWorkTableAdapter adapterInvCountWork;
    }
}