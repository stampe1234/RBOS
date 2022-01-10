namespace RBOS
{
    partial class SalesStatColumns
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesStatColumns));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.bindingSalesStatDailyColumns = new System.Windows.Forms.BindingSource(this.components);
            this.dsSalesStat = new RBOS.SalesStatDS();
            this.bindingLookupUnitOrAmount = new System.Windows.Forms.BindingSource(this.components);
            this.adapterSalesStatDailyColumns = new RBOS.SalesStatDSTableAdapters.SalesStatDailyColumnsTableAdapter();
            this.adapterLookupUnitOrAmount = new RBOS.SalesStatDSTableAdapters.LookupUnitOrAmountTableAdapter();
            this.grid = new DRS.Extensions.DRS_DataGridView();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeaderText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitOrAmount = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colAccountBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colColumnNo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bindingLookupColumnNoLong = new System.Windows.Forms.BindingSource(this.components);
            this.colAverage = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.adapterLookupColumnNoLong = new RBOS.SalesStatDSTableAdapters.LookupColumnNoLongTableAdapter();
            this.bindingLookupColumnNoShort = new System.Windows.Forms.BindingSource(this.components);
            this.adapterLookupColumnNoShort = new RBOS.SalesStatDSTableAdapters.LookupColumnNoShortTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSalesStatDailyColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSalesStat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupUnitOrAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupColumnNoLong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupColumnNoShort)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(443, 349);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "[Anuller]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndClose.Location = new System.Drawing.Point(328, 349);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(109, 23);
            this.btnSaveAndClose.TabIndex = 4;
            this.btnSaveAndClose.Text = "[Gem && luk]";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // bindingSalesStatDailyColumns
            // 
            this.bindingSalesStatDailyColumns.DataMember = "SalesStatDailyColumns";
            this.bindingSalesStatDailyColumns.DataSource = this.dsSalesStat;
            // 
            // dsSalesStat
            // 
            this.dsSalesStat.DataSetName = "SalesStatDS";
            this.dsSalesStat.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingLookupUnitOrAmount
            // 
            this.bindingLookupUnitOrAmount.DataMember = "LookupUnitOrAmount";
            this.bindingLookupUnitOrAmount.DataSource = this.dsSalesStat;
            // 
            // adapterSalesStatDailyColumns
            // 
            this.adapterSalesStatDailyColumns.ClearBeforeFill = true;
            // 
            // adapterLookupUnitOrAmount
            // 
            this.adapterLookupUnitOrAmount.ClearBeforeFill = true;
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
            this.colDescription,
            this.colHeaderText,
            this.colUnitOrAmount,
            this.colAccountBtn,
            this.colColumnNo,
            this.colAverage});
            this.grid.DataSource = this.bindingSalesStatDailyColumns;
            this.grid.Location = new System.Drawing.Point(14, 12);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.RowHeadersWidth = 25;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.Size = new System.Drawing.Size(504, 331);
            this.grid.TabIndex = 3;
            this.grid.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grid_CellMouseUp);
            this.grid.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grid_CellBeginEdit);
            this.grid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grid_CellPainting);
            this.grid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grid_EditingControlShowing);
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            // 
            // colDescription
            // 
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Beskrivelse";
            this.colDescription.Name = "colDescription";
            // 
            // colHeaderText
            // 
            this.colHeaderText.DataPropertyName = "HeaderText";
            this.colHeaderText.HeaderText = "Overskrift";
            this.colHeaderText.Name = "colHeaderText";
            // 
            // colUnitOrAmount
            // 
            this.colUnitOrAmount.DataPropertyName = "UnitOrAmount";
            this.colUnitOrAmount.DataSource = this.bindingLookupUnitOrAmount;
            this.colUnitOrAmount.DisplayMember = "Description";
            this.colUnitOrAmount.HeaderText = "Enhed/beløb";
            this.colUnitOrAmount.Name = "colUnitOrAmount";
            this.colUnitOrAmount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colUnitOrAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colUnitOrAmount.ValueMember = "ID";
            this.colUnitOrAmount.Width = 75;
            // 
            // colAccountBtn
            // 
            this.colAccountBtn.HeaderText = "Konti";
            this.colAccountBtn.Name = "colAccountBtn";
            this.colAccountBtn.Text = "...";
            this.colAccountBtn.ToolTipText = "...";
            this.colAccountBtn.Width = 35;
            // 
            // colColumnNo
            // 
            this.colColumnNo.DataPropertyName = "ColumnNo";
            this.colColumnNo.DataSource = this.bindingLookupColumnNoLong;
            this.colColumnNo.DisplayMember = "ColumnNo";
            this.colColumnNo.HeaderText = "Kol.nr.";
            this.colColumnNo.Name = "colColumnNo";
            this.colColumnNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colColumnNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colColumnNo.ValueMember = "ColumnNo";
            this.colColumnNo.Width = 40;
            // 
            // bindingLookupColumnNoLong
            // 
            this.bindingLookupColumnNoLong.DataMember = "LookupColumnNoLong";
            this.bindingLookupColumnNoLong.DataSource = this.dsSalesStat;
            // 
            // colAverage
            // 
            this.colAverage.DataPropertyName = "Average";
            this.colAverage.HeaderText = "Gns.";
            this.colAverage.Name = "colAverage";
            this.colAverage.Width = 30;
            // 
            // adapterLookupColumnNoLong
            // 
            this.adapterLookupColumnNoLong.ClearBeforeFill = true;
            // 
            // bindingLookupColumnNoShort
            // 
            this.bindingLookupColumnNoShort.DataMember = "LookupColumnNoShort";
            this.bindingLookupColumnNoShort.DataSource = this.dsSalesStat;
            // 
            // adapterLookupColumnNoShort
            // 
            this.adapterLookupColumnNoShort.ClearBeforeFill = true;
            // 
            // SalesStatColumns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 384);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.grid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SalesStatColumns";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SalesStatColumns";
            this.Load += new System.EventHandler(this.SalesStatColumns_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSalesStatDailyColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSalesStat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupUnitOrAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupColumnNoLong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupColumnNoShort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveAndClose;
        private DRS.Extensions.DRS_DataGridView grid;
        private System.Windows.Forms.BindingSource bindingSalesStatDailyColumns;
        private RBOS.SalesStatDSTableAdapters.SalesStatDailyColumnsTableAdapter adapterSalesStatDailyColumns;
        private System.Windows.Forms.BindingSource bindingLookupUnitOrAmount;
        private RBOS.SalesStatDSTableAdapters.LookupUnitOrAmountTableAdapter adapterLookupUnitOrAmount;
        private SalesStatDS dsSalesStat;
        private System.Windows.Forms.BindingSource bindingLookupColumnNoLong;
        private RBOS.SalesStatDSTableAdapters.LookupColumnNoLongTableAdapter adapterLookupColumnNoLong;
        private System.Windows.Forms.BindingSource bindingLookupColumnNoShort;
        private RBOS.SalesStatDSTableAdapters.LookupColumnNoShortTableAdapter adapterLookupColumnNoShort;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeaderText;
        private System.Windows.Forms.DataGridViewComboBoxColumn colUnitOrAmount;
        private System.Windows.Forms.DataGridViewButtonColumn colAccountBtn;
        private System.Windows.Forms.DataGridViewComboBoxColumn colColumnNo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAverage;
    }
}