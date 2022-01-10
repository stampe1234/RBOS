namespace RBOS
{
    partial class PrlClusterSites
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrlClusterSites));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnSelectNone = new System.Windows.Forms.Button();
            this.dsPayroll = new RBOS.Payroll();
            this.bindingClusterSites = new System.Windows.Forms.BindingSource(this.components);
            this.adapterClusterSites = new RBOS.PayrollTableAdapters.PrlClusterSitesTableAdapter();
            this.gridClusterSites = new DRS.Extensions.DRS_DataGridView();
            this.colSiteCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSiteName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dsPayroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingClusterSites)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridClusterSites)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(261, 221);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "[Cancel]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(180, 221);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "[Select]";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnSelectNone
            // 
            this.btnSelectNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectNone.Location = new System.Drawing.Point(69, 221);
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(105, 23);
            this.btnSelectNone.TabIndex = 1;
            this.btnSelectNone.Text = "[Select none]";
            this.btnSelectNone.UseVisualStyleBackColor = true;
            this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
            // 
            // dsPayroll
            // 
            this.dsPayroll.DataSetName = "Payroll";
            this.dsPayroll.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingClusterSites
            // 
            this.bindingClusterSites.DataMember = "PrlClusterSites";
            this.bindingClusterSites.DataSource = this.dsPayroll;
            // 
            // adapterClusterSites
            // 
            this.adapterClusterSites.ClearBeforeFill = true;
            // 
            // gridClusterSites
            // 
            this.gridClusterSites.AllowUserToAddRows = false;
            this.gridClusterSites.AllowUserToDeleteRows = false;
            this.gridClusterSites.AllowUserToResizeColumns = false;
            this.gridClusterSites.AllowUserToResizeRows = false;
            this.gridClusterSites.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridClusterSites.AutoGenerateColumns = false;
            this.gridClusterSites.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridClusterSites.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridClusterSites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridClusterSites.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSiteCode,
            this.colSiteName});
            this.gridClusterSites.DataSource = this.bindingClusterSites;
            this.gridClusterSites.Location = new System.Drawing.Point(12, 12);
            this.gridClusterSites.MultiSelect = false;
            this.gridClusterSites.Name = "gridClusterSites";
            this.gridClusterSites.ReadOnly = true;
            this.gridClusterSites.RowHeadersVisible = false;
            this.gridClusterSites.RowHeadersWidth = 25;
            this.gridClusterSites.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridClusterSites.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridClusterSites.Size = new System.Drawing.Size(324, 203);
            this.gridClusterSites.TabIndex = 0;
            this.gridClusterSites.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridClusterSites_KeyDown);
            this.gridClusterSites.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridClusterSites_CellDoubleClick);
            // 
            // colSiteCode
            // 
            this.colSiteCode.DataPropertyName = "SiteCode";
            this.colSiteCode.HeaderText = "SiteCode";
            this.colSiteCode.Name = "colSiteCode";
            this.colSiteCode.ReadOnly = true;
            this.colSiteCode.Width = 70;
            // 
            // colSiteName
            // 
            this.colSiteName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSiteName.DataPropertyName = "SiteName";
            this.colSiteName.HeaderText = "SiteName";
            this.colSiteName.Name = "colSiteName";
            this.colSiteName.ReadOnly = true;
            // 
            // PrlClusterSites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 256);
            this.Controls.Add(this.gridClusterSites);
            this.Controls.Add(this.btnSelectNone);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrlClusterSites";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrlClusterSites";
            this.Load += new System.EventHandler(this.PrlClusterSites_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsPayroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingClusterSites)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridClusterSites)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnSelectNone;
        private DRS.Extensions.DRS_DataGridView gridClusterSites;
        private Payroll dsPayroll;
        private System.Windows.Forms.BindingSource bindingClusterSites;
        private RBOS.PayrollTableAdapters.PrlClusterSitesTableAdapter adapterClusterSites;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSiteCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSiteName;
    }
}