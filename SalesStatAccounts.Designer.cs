namespace RBOS
{
    partial class SalesStatAccounts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesStatAccounts));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.bindingAccounts = new System.Windows.Forms.BindingSource(this.components);
            this.dsSalesStat = new RBOS.SalesStatDS();
            this.bindingLookupGLAccount = new System.Windows.Forms.BindingSource(this.components);
            this.adapterLookupGLAccount = new RBOS.SalesStatDSTableAdapters.LookupGLAccountTableAdapter();
            this.grid = new DRS.Extensions.DRS_DataGridView();
            this.colAccountFromBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colAccountToBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colAccountFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountFromDesc = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colAccountTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountToDesc = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSalesStat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupGLAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(271, 287);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "[Ok]";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(352, 287);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "[Cancel]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // bindingAccounts
            // 
            this.bindingAccounts.DataMember = "SalesStatDailyAccounts";
            this.bindingAccounts.DataSource = this.dsSalesStat;
            // 
            // dsSalesStat
            // 
            this.dsSalesStat.DataSetName = "SalesStatDS";
            this.dsSalesStat.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingLookupGLAccount
            // 
            this.bindingLookupGLAccount.DataMember = "LookupGLAccount";
            this.bindingLookupGLAccount.DataSource = this.dsSalesStat;
            // 
            // adapterLookupGLAccount
            // 
            this.adapterLookupGLAccount.ClearBeforeFill = true;
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
            this.grid.ColumnHeadersHeight = 21;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAccountFromBtn,
            this.colAccountToBtn,
            this.colAccountFrom,
            this.colAccountFromDesc,
            this.colAccountTo,
            this.colAccountToDesc});
            this.grid.DataSource = this.bindingAccounts;
            this.grid.Location = new System.Drawing.Point(12, 12);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.RowHeadersWidth = 25;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.Size = new System.Drawing.Size(415, 269);
            this.grid.TabIndex = 2;
            this.grid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grid_CellPainting);
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            // 
            // colAccountFromBtn
            // 
            this.colAccountFromBtn.DataPropertyName = "ID";
            this.colAccountFromBtn.HeaderText = "";
            this.colAccountFromBtn.Name = "colAccountFromBtn";
            this.colAccountFromBtn.Width = 25;
            // 
            // colAccountToBtn
            // 
            this.colAccountToBtn.DataPropertyName = "ID";
            this.colAccountToBtn.HeaderText = "";
            this.colAccountToBtn.Name = "colAccountToBtn";
            this.colAccountToBtn.Width = 25;
            // 
            // colAccountFrom
            // 
            this.colAccountFrom.DataPropertyName = "AccountFrom";
            this.colAccountFrom.HeaderText = "[Konto fra]";
            this.colAccountFrom.Name = "colAccountFrom";
            this.colAccountFrom.ReadOnly = true;
            this.colAccountFrom.Width = 65;
            // 
            // colAccountFromDesc
            // 
            this.colAccountFromDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAccountFromDesc.DataPropertyName = "AccountFrom";
            this.colAccountFromDesc.DataSource = this.bindingLookupGLAccount;
            this.colAccountFromDesc.DisplayMember = "Description";
            this.colAccountFromDesc.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colAccountFromDesc.HeaderText = "[Beskrivelse]";
            this.colAccountFromDesc.Name = "colAccountFromDesc";
            this.colAccountFromDesc.ReadOnly = true;
            this.colAccountFromDesc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAccountFromDesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colAccountFromDesc.ValueMember = "GLCode";
            // 
            // colAccountTo
            // 
            this.colAccountTo.DataPropertyName = "AccountTo";
            this.colAccountTo.HeaderText = "[Konto til]";
            this.colAccountTo.Name = "colAccountTo";
            this.colAccountTo.ReadOnly = true;
            this.colAccountTo.Width = 65;
            // 
            // colAccountToDesc
            // 
            this.colAccountToDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAccountToDesc.DataPropertyName = "AccountTo";
            this.colAccountToDesc.DataSource = this.bindingLookupGLAccount;
            this.colAccountToDesc.DisplayMember = "Description";
            this.colAccountToDesc.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colAccountToDesc.HeaderText = "[Beskrivelse]";
            this.colAccountToDesc.Name = "colAccountToDesc";
            this.colAccountToDesc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAccountToDesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colAccountToDesc.ValueMember = "GLCode";
            // 
            // SalesStatAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 322);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SalesStatAccounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Konti]";
            this.Load += new System.EventHandler(this.SalesStatAccounts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSalesStat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupGLAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private DRS.Extensions.DRS_DataGridView grid;
        private System.Windows.Forms.BindingSource bindingAccounts;
        private SalesStatDS dsSalesStat;
        private System.Windows.Forms.BindingSource bindingLookupGLAccount;
        private RBOS.SalesStatDSTableAdapters.LookupGLAccountTableAdapter adapterLookupGLAccount;
        private System.Windows.Forms.DataGridViewButtonColumn colAccountFromBtn;
        private System.Windows.Forms.DataGridViewButtonColumn colAccountToBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountFrom;
        private System.Windows.Forms.DataGridViewComboBoxColumn colAccountFromDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountTo;
        private System.Windows.Forms.DataGridViewComboBoxColumn colAccountToDesc;
    }
}