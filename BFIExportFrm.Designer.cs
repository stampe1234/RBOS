namespace RBOS
{
    partial class BFIExportFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BFIExportFrm));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnDeselectAll = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnSendTest = new System.Windows.Forms.Button();
            this.dsItem = new RBOS.ItemDataSet();
            this.bindingBFIStations = new System.Windows.Forms.BindingSource(this.components);
            this.adapterBFIStations = new RBOS.ItemDataSetTableAdapters.BFI_StationsTableAdapter();
            this.btnSelectBFIFile = new System.Windows.Forms.Button();
            this.lbSelectBFIFile = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtSelectBFIFile = new System.Windows.Forms.TextBox();
            this.grid = new DRS.Extensions.DRS_DataGridView();
            this.colStation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStationsnavn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInkluder = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsTest = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingBFIStations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(424, 356);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "[Luk]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(12, 356);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(77, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "[Send]";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeselectAll.Location = new System.Drawing.Point(312, 356);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(106, 23);
            this.btnDeselectAll.TabIndex = 3;
            this.btnDeselectAll.Text = "[Fravælg alle]";
            this.btnDeselectAll.UseVisualStyleBackColor = true;
            this.btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAll.Location = new System.Drawing.Point(210, 356);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(96, 23);
            this.btnSelectAll.TabIndex = 5;
            this.btnSelectAll.Text = "[Vælg alle]";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnSendTest
            // 
            this.btnSendTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendTest.Location = new System.Drawing.Point(95, 356);
            this.btnSendTest.Name = "btnSendTest";
            this.btnSendTest.Size = new System.Drawing.Size(109, 23);
            this.btnSendTest.TabIndex = 6;
            this.btnSendTest.Text = "[Send til test]";
            this.btnSendTest.UseVisualStyleBackColor = true;
            this.btnSendTest.Click += new System.EventHandler(this.btnSendTest_Click);
            // 
            // dsItem
            // 
            this.dsItem.DataSetName = "ItemDataSet";
            this.dsItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingBFIStations
            // 
            this.bindingBFIStations.DataMember = "BFI_Stations";
            this.bindingBFIStations.DataSource = this.dsItem;
            // 
            // adapterBFIStations
            // 
            this.adapterBFIStations.ClearBeforeFill = true;
            // 
            // btnSelectBFIFile
            // 
            this.btnSelectBFIFile.Location = new System.Drawing.Point(474, 23);
            this.btnSelectBFIFile.Name = "btnSelectBFIFile";
            this.btnSelectBFIFile.Size = new System.Drawing.Size(25, 23);
            this.btnSelectBFIFile.TabIndex = 8;
            this.btnSelectBFIFile.Text = "...";
            this.btnSelectBFIFile.UseVisualStyleBackColor = true;
            this.btnSelectBFIFile.Click += new System.EventHandler(this.btnSelectBFIFile_Click);
            // 
            // lbSelectBFIFile
            // 
            this.lbSelectBFIFile.AutoSize = true;
            this.lbSelectBFIFile.Location = new System.Drawing.Point(12, 9);
            this.lbSelectBFIFile.Name = "lbSelectBFIFile";
            this.lbSelectBFIFile.Size = new System.Drawing.Size(67, 13);
            this.lbSelectBFIFile.TabIndex = 9;
            this.lbSelectBFIFile.Text = "[Vælg BFI fil]";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // txtSelectBFIFile
            // 
            this.txtSelectBFIFile.Location = new System.Drawing.Point(12, 25);
            this.txtSelectBFIFile.Name = "txtSelectBFIFile";
            this.txtSelectBFIFile.Size = new System.Drawing.Size(456, 20);
            this.txtSelectBFIFile.TabIndex = 10;
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
            this.colStation,
            this.colStationsnavn,
            this.colInkluder,
            this.colIsTest});
            this.grid.DataSource = this.bindingBFIStations;
            this.grid.Location = new System.Drawing.Point(12, 51);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.RowHeadersWidth = 25;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.Size = new System.Drawing.Size(487, 299);
            this.grid.TabIndex = 7;
            // 
            // colStation
            // 
            this.colStation.DataPropertyName = "SiteCode";
            this.colStation.HeaderText = "[Station]";
            this.colStation.Name = "colStation";
            this.colStation.ReadOnly = true;
            this.colStation.Width = 50;
            // 
            // colStationsnavn
            // 
            this.colStationsnavn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStationsnavn.DataPropertyName = "SiteName";
            this.colStationsnavn.HeaderText = "[Stationsnavn]";
            this.colStationsnavn.Name = "colStationsnavn";
            this.colStationsnavn.ReadOnly = true;
            // 
            // colInkluder
            // 
            this.colInkluder.DataPropertyName = "ExportBFI_ActiveFTP";
            this.colInkluder.HeaderText = "[Inkludér]";
            this.colInkluder.Name = "colInkluder";
            this.colInkluder.Width = 50;
            // 
            // colIsTest
            // 
            this.colIsTest.DataPropertyName = "ExportBFI_IsTestStation";
            this.colIsTest.HeaderText = "[Test]";
            this.colIsTest.Name = "colIsTest";
            this.colIsTest.Width = 40;
            // 
            // BFIExportFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 391);
            this.Controls.Add(this.txtSelectBFIFile);
            this.Controls.Add(this.lbSelectBFIFile);
            this.Controls.Add(this.btnSelectBFIFile);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.btnSendTest);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnDeselectAll);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BFIExportFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[BFI eksport]";
            this.Load += new System.EventHandler(this.BFIExportFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingBFIStations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnDeselectAll;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnSendTest;
        private DRS.Extensions.DRS_DataGridView grid;
        private ItemDataSet dsItem;
        private System.Windows.Forms.BindingSource bindingBFIStations;
        private RBOS.ItemDataSetTableAdapters.BFI_StationsTableAdapter adapterBFIStations;
        private System.Windows.Forms.Button btnSelectBFIFile;
        private System.Windows.Forms.Label lbSelectBFIFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtSelectBFIFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStationsnavn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colInkluder;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsTest;
    }
}