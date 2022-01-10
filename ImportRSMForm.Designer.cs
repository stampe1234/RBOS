namespace RBOS
{
    partial class ImportRSMForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportRSMForm));
            this.bindingHeader = new System.Windows.Forms.BindingSource(this.components);
            this.dsImport = new RBOS.ImportDataSet();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.adapterHeader = new RBOS.ImportDataSetTableAdapters.Import_RPOS_24H_HeaderTableAdapter();
            this.dataGridView1 = new DRS.Extensions.DRS_DataGridView();
            this.colFGMimported = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colMCMimported = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colMSMimported = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colISMimported = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colTPMimported = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colBookDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFGMproblems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMCMproblems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMSMproblems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colISMproblems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTPMproblems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingHeader
            // 
            this.bindingHeader.DataMember = "Import_RPOS_24H_Header";
            this.bindingHeader.DataSource = this.dsImport;
            // 
            // dsImport
            // 
            this.dsImport.DataSetName = "ImportDataSet";
            this.dsImport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(449, 454);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(364, 454);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "[Import]";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // adapterHeader
            // 
            this.adapterHeader.ClearBeforeFill = true;
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
            this.dataGridView1.ColumnHeadersHeight = 21;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFGMimported,
            this.colMCMimported,
            this.colMSMimported,
            this.colISMimported,
            this.colTPMimported,
            this.colBookDate,
            this.colFGMproblems,
            this.colMCMproblems,
            this.colMSMproblems,
            this.colISMproblems,
            this.colTPMproblems});
            this.dataGridView1.DataSource = this.bindingHeader;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(512, 436);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseLeave);
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
            // 
            // colFGMimported
            // 
            this.colFGMimported.DataPropertyName = "FGMImported";
            this.colFGMimported.HeaderText = "FGM";
            this.colFGMimported.Name = "colFGMimported";
            this.colFGMimported.Width = 35;
            // 
            // colMCMimported
            // 
            this.colMCMimported.DataPropertyName = "MCMImported";
            this.colMCMimported.HeaderText = "MCM";
            this.colMCMimported.Name = "colMCMimported";
            this.colMCMimported.Width = 35;
            // 
            // colMSMimported
            // 
            this.colMSMimported.DataPropertyName = "MSMImported";
            this.colMSMimported.HeaderText = "MSM";
            this.colMSMimported.Name = "colMSMimported";
            this.colMSMimported.Width = 35;
            // 
            // colISMimported
            // 
            this.colISMimported.DataPropertyName = "ISMImported";
            this.colISMimported.HeaderText = "ISM";
            this.colISMimported.Name = "colISMimported";
            this.colISMimported.ReadOnly = true;
            this.colISMimported.Width = 35;
            // 
            // colTPMimported
            // 
            this.colTPMimported.DataPropertyName = "TPMImported";
            this.colTPMimported.HeaderText = "TPM";
            this.colTPMimported.Name = "colTPMimported";
            this.colTPMimported.Width = 35;
            // 
            // colBookDate
            // 
            this.colBookDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBookDate.DataPropertyName = "BookDate";
            this.colBookDate.HeaderText = "BookDate";
            this.colBookDate.Name = "colBookDate";
            this.colBookDate.ReadOnly = true;
            // 
            // colFGMproblems
            // 
            this.colFGMproblems.DataPropertyName = "FGMProblems";
            this.colFGMproblems.HeaderText = "Pr";
            this.colFGMproblems.Name = "colFGMproblems";
            this.colFGMproblems.ReadOnly = true;
            this.colFGMproblems.Width = 40;
            // 
            // colMCMproblems
            // 
            this.colMCMproblems.DataPropertyName = "MCMProblems";
            this.colMCMproblems.HeaderText = "Pr";
            this.colMCMproblems.Name = "colMCMproblems";
            this.colMCMproblems.ReadOnly = true;
            this.colMCMproblems.Width = 40;
            // 
            // colMSMproblems
            // 
            this.colMSMproblems.DataPropertyName = "MSMProblems";
            this.colMSMproblems.HeaderText = "Pr";
            this.colMSMproblems.Name = "colMSMproblems";
            this.colMSMproblems.ReadOnly = true;
            this.colMSMproblems.Width = 40;
            // 
            // colISMproblems
            // 
            this.colISMproblems.DataPropertyName = "ISMProblems";
            this.colISMproblems.HeaderText = "Pr";
            this.colISMproblems.Name = "colISMproblems";
            this.colISMproblems.ReadOnly = true;
            this.colISMproblems.Width = 40;
            // 
            // colTPMproblems
            // 
            this.colTPMproblems.DataPropertyName = "TPMProblems";
            this.colTPMproblems.HeaderText = "Pr";
            this.colTPMproblems.Name = "colTPMproblems";
            this.colTPMproblems.ReadOnly = true;
            this.colTPMproblems.Width = 40;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "BookDate";
            this.dataGridViewTextBoxColumn1.HeaderText = "BookDate";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "FGMProblems";
            this.dataGridViewTextBoxColumn2.HeaderText = "Pr";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 40;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "MCMProblems";
            this.dataGridViewTextBoxColumn3.HeaderText = "Pr";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 40;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "MSMProblems";
            this.dataGridViewTextBoxColumn4.HeaderText = "Pr";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 40;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ISMProblems";
            this.dataGridViewTextBoxColumn5.HeaderText = "Pr";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 40;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TPMProblems";
            this.dataGridViewTextBoxColumn6.HeaderText = "Pr";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 40;
            // 
            // ImportRSMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 489);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ImportRSMForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImportRSMForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImportRSMForm_FormClosing);
            this.Load += new System.EventHandler(this.ImportRSMForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DRS.Extensions.DRS_DataGridView dataGridView1;
        private ImportDataSet dsImport;
        private System.Windows.Forms.BindingSource bindingHeader;
        private RBOS.ImportDataSetTableAdapters.Import_RPOS_24H_HeaderTableAdapter adapterHeader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colFGMimported;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMCMimported;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMSMimported;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colISMimported;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colTPMimported;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFGMproblems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMCMproblems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMSMproblems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colISMproblems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTPMproblems;
    }
}