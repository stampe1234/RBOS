namespace RBOS
{
    partial class BFIStations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BFIStations));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.bindingBFIStations = new System.Windows.Forms.BindingSource(this.components);
            this.dsItem = new RBOS.ItemDataSet();
            this.adapterBFIStations = new RBOS.ItemDataSetTableAdapters.BFI_StationsTableAdapter();
            this.bindingBFIExportHistory = new System.Windows.Forms.BindingSource(this.components);
            this.adapterBFIExportHistory = new RBOS.ItemDataSetTableAdapters.BFI_ExportHistoryTableAdapter();
            this.bFIExportHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grid = new DRS.Extensions.DRS_DataGridView();
            this.colStationsnr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStationsnavn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAktivFTP = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colSidsteFilnavn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colSidsteFilDatoTid = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colIsTest = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.comboSelectFTP = new System.Windows.Forms.ComboBox();
            this.bindingFTPAccounts = new System.Windows.Forms.BindingSource(this.components);
            this.dsAdmin = new RBOS.AdminDataSet();
            this.lbSelectFTP = new System.Windows.Forms.Label();
            this.adapterFTPAccounts = new RBOS.AdminDataSetTableAdapters.FTPAccountsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bindingBFIStations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingBFIExportHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bFIExportHistoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingFTPAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAdmin)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(509, 491);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "[Annullér]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndClose.Location = new System.Drawing.Point(407, 491);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(96, 23);
            this.btnSaveAndClose.TabIndex = 2;
            this.btnSaveAndClose.Text = "[Gem og luk]";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // bindingBFIStations
            // 
            this.bindingBFIStations.DataMember = "BFI_Stations";
            this.bindingBFIStations.DataSource = this.dsItem;
            // 
            // dsItem
            // 
            this.dsItem.DataSetName = "ItemDataSet";
            this.dsItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // adapterBFIStations
            // 
            this.adapterBFIStations.ClearBeforeFill = true;
            // 
            // bindingBFIExportHistory
            // 
            this.bindingBFIExportHistory.DataMember = "BFI_ExportHistory";
            this.bindingBFIExportHistory.DataSource = this.dsItem;
            // 
            // adapterBFIExportHistory
            // 
            this.adapterBFIExportHistory.ClearBeforeFill = true;
            // 
            // bFIExportHistoryBindingSource
            // 
            this.bFIExportHistoryBindingSource.DataMember = "BFI_ExportHistory";
            this.bFIExportHistoryBindingSource.DataSource = this.dsItem;
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
            this.colStationsnr,
            this.colStationsnavn,
            this.colAktivFTP,
            this.colSidsteFilnavn,
            this.colSidsteFilDatoTid,
            this.colIsTest});
            this.grid.DataSource = this.bindingBFIStations;
            this.grid.Location = new System.Drawing.Point(12, 12);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.RowHeadersWidth = 25;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.Size = new System.Drawing.Size(582, 423);
            this.grid.TabIndex = 0;
            // 
            // colStationsnr
            // 
            this.colStationsnr.DataPropertyName = "SiteCode";
            this.colStationsnr.HeaderText = "[Station]";
            this.colStationsnr.Name = "colStationsnr";
            this.colStationsnr.Width = 50;
            // 
            // colStationsnavn
            // 
            this.colStationsnavn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStationsnavn.DataPropertyName = "SiteName";
            this.colStationsnavn.HeaderText = "[Stationsnavn]";
            this.colStationsnavn.Name = "colStationsnavn";
            // 
            // colAktivFTP
            // 
            this.colAktivFTP.DataPropertyName = "ExportBFI_ActiveFTP";
            this.colAktivFTP.HeaderText = "[FTP]";
            this.colAktivFTP.Name = "colAktivFTP";
            this.colAktivFTP.Width = 40;
            // 
            // colSidsteFilnavn
            // 
            this.colSidsteFilnavn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSidsteFilnavn.DataPropertyName = "ExportBFI_HistoryID";
            this.colSidsteFilnavn.DataSource = this.bindingBFIExportHistory;
            this.colSidsteFilnavn.DisplayMember = "Filename";
            this.colSidsteFilnavn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colSidsteFilnavn.HeaderText = "[Sidste filnavn]";
            this.colSidsteFilnavn.Name = "colSidsteFilnavn";
            this.colSidsteFilnavn.ReadOnly = true;
            this.colSidsteFilnavn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSidsteFilnavn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSidsteFilnavn.ValueMember = "ID";
            // 
            // colSidsteFilDatoTid
            // 
            this.colSidsteFilDatoTid.DataPropertyName = "ExportBFI_HistoryID";
            this.colSidsteFilDatoTid.DataSource = this.bFIExportHistoryBindingSource;
            this.colSidsteFilDatoTid.DisplayMember = "DateTimeSentOut";
            this.colSidsteFilDatoTid.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colSidsteFilDatoTid.HeaderText = "[Sidste fil dato/tid]";
            this.colSidsteFilDatoTid.Name = "colSidsteFilDatoTid";
            this.colSidsteFilDatoTid.ReadOnly = true;
            this.colSidsteFilDatoTid.ValueMember = "ID";
            // 
            // colIsTest
            // 
            this.colIsTest.DataPropertyName = "ExportBFI_IsTestStation";
            this.colIsTest.HeaderText = "[Test]";
            this.colIsTest.Name = "colIsTest";
            this.colIsTest.Width = 40;
            // 
            // comboSelectFTP
            // 
            this.comboSelectFTP.DataSource = this.bindingFTPAccounts;
            this.comboSelectFTP.DisplayMember = "AccountName";
            this.comboSelectFTP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSelectFTP.FormattingEnabled = true;
            this.comboSelectFTP.Location = new System.Drawing.Point(12, 455);
            this.comboSelectFTP.Name = "comboSelectFTP";
            this.comboSelectFTP.Size = new System.Drawing.Size(214, 21);
            this.comboSelectFTP.TabIndex = 3;
            this.comboSelectFTP.ValueMember = "ID";
            // 
            // bindingFTPAccounts
            // 
            this.bindingFTPAccounts.DataMember = "FTPAccounts";
            this.bindingFTPAccounts.DataSource = this.dsAdmin;
            // 
            // dsAdmin
            // 
            this.dsAdmin.DataSetName = "AdminDataSet";
            this.dsAdmin.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lbSelectFTP
            // 
            this.lbSelectFTP.AutoSize = true;
            this.lbSelectFTP.Location = new System.Drawing.Point(12, 438);
            this.lbSelectFTP.Name = "lbSelectFTP";
            this.lbSelectFTP.Size = new System.Drawing.Size(91, 13);
            this.lbSelectFTP.TabIndex = 4;
            this.lbSelectFTP.Text = "[Vælg FTP-konto]";
            // 
            // adapterFTPAccounts
            // 
            this.adapterFTPAccounts.ClearBeforeFill = true;
            // 
            // BFIStations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 526);
            this.Controls.Add(this.lbSelectFTP);
            this.Controls.Add(this.comboSelectFTP);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BFIStations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[BFI stationer]";
            this.Load += new System.EventHandler(this.BFIStations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingBFIStations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingBFIExportHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bFIExportHistoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingFTPAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAdmin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DRS.Extensions.DRS_DataGridView grid;
        private ItemDataSet dsItem;
        private System.Windows.Forms.BindingSource bindingBFIStations;
        private RBOS.ItemDataSetTableAdapters.BFI_StationsTableAdapter adapterBFIStations;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.BindingSource bindingBFIExportHistory;
        private RBOS.ItemDataSetTableAdapters.BFI_ExportHistoryTableAdapter adapterBFIExportHistory;
        private System.Windows.Forms.BindingSource bFIExportHistoryBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStationsnr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStationsnavn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAktivFTP;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSidsteFilnavn;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSidsteFilDatoTid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsTest;
        private System.Windows.Forms.ComboBox comboSelectFTP;
        private System.Windows.Forms.Label lbSelectFTP;
        private System.Windows.Forms.BindingSource bindingFTPAccounts;
        private AdminDataSet dsAdmin;
        private RBOS.AdminDataSetTableAdapters.FTPAccountsTableAdapter adapterFTPAccounts;
    }
}