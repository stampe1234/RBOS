namespace RBOS
{
    partial class EOD_SafePayCurr
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
            this.dsEOD = new RBOS.EODDataSet();
            this.btnClose = new System.Windows.Forms.Button();
            this.bindingSafePayDepot = new System.Windows.Forms.BindingSource(this.components);
            this.AdapterSafePay_Depotbeholdning = new RBOS.EODDataSetTableAdapters.EOD_SafePay_DepotbeholdningTableAdapter();
            this.drS_DataGridView1 = new DRS.Extensions.DRS_DataGridView();
            this.dataGridView1 = new DRS.Extensions.DRS_DataGridView();
            this.bookDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mOPCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChangeDKK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColChangeValuta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dsEOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSafePayDepot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drS_DataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dsEOD
            // 
            this.dsEOD.DataSetName = "EODDataSet";
            this.dsEOD.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(353, 181);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(77, 34);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Luk";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // bindingSafePayDepot
            // 
            this.bindingSafePayDepot.DataMember = "EOD_SafePay_Depotbeholdning";
            this.bindingSafePayDepot.DataSource = this.dsEOD;
            // 
            // AdapterSafePay_Depotbeholdning
            // 
            this.AdapterSafePay_Depotbeholdning.ClearBeforeFill = true;
            // 
            // drS_DataGridView1
            // 
            this.drS_DataGridView1.AllowUserToAddRows = false;
            this.drS_DataGridView1.AllowUserToDeleteRows = false;
            this.drS_DataGridView1.AllowUserToResizeColumns = false;
            this.drS_DataGridView1.AllowUserToResizeRows = false;
            this.drS_DataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drS_DataGridView1.AutoGenerateColumns = false;
            this.drS_DataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.drS_DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.drS_DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drS_DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDescription,
            this.ChangeDKK,
            this.ColChangeValuta});
            this.drS_DataGridView1.DataSource = this.bindingSafePayDepot;
            this.drS_DataGridView1.Location = new System.Drawing.Point(16, 15);
            this.drS_DataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.drS_DataGridView1.MultiSelect = false;
            this.drS_DataGridView1.Name = "drS_DataGridView1";
            this.drS_DataGridView1.ReadOnly = true;
            this.drS_DataGridView1.RowHeadersWidth = 25;
            this.drS_DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.drS_DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.drS_DataGridView1.Size = new System.Drawing.Size(414, 130);
            this.drS_DataGridView1.TabIndex = 5;
            // 
            // dataGridView1
            // 
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
            this.bookDateDataGridViewTextBoxColumn,
            this.lineNoDataGridViewTextBoxColumn,
            this.mOPCodeDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn});
            this.dataGridView1.Location = new System.Drawing.Point(12, -1);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(525, 146);
            this.dataGridView1.TabIndex = 5;
            // 
            // bookDateDataGridViewTextBoxColumn
            // 
            this.bookDateDataGridViewTextBoxColumn.DataPropertyName = "BookDate";
            this.bookDateDataGridViewTextBoxColumn.HeaderText = "BookDate";
            this.bookDateDataGridViewTextBoxColumn.Name = "bookDateDataGridViewTextBoxColumn";
            // 
            // lineNoDataGridViewTextBoxColumn
            // 
            this.lineNoDataGridViewTextBoxColumn.DataPropertyName = "LineNo";
            this.lineNoDataGridViewTextBoxColumn.HeaderText = "LineNo";
            this.lineNoDataGridViewTextBoxColumn.Name = "lineNoDataGridViewTextBoxColumn";
            // 
            // mOPCodeDataGridViewTextBoxColumn
            // 
            this.mOPCodeDataGridViewTextBoxColumn.DataPropertyName = "MOPCode";
            this.mOPCodeDataGridViewTextBoxColumn.HeaderText = "MOPCode";
            this.mOPCodeDataGridViewTextBoxColumn.Name = "mOPCodeDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "ValutaTekst";
            this.colDescription.HeaderText = "ValutaTekst";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // ChangeDKK
            // 
            this.ChangeDKK.DataPropertyName = "ChangeDKK";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.ChangeDKK.DefaultCellStyle = dataGridViewCellStyle1;
            this.ChangeDKK.HeaderText = "ChangeDKK";
            this.ChangeDKK.Name = "ChangeDKK";
            this.ChangeDKK.ReadOnly = true;
            // 
            // ColChangeValuta
            // 
            this.ColChangeValuta.DataPropertyName = "ChangeValuta";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.ColChangeValuta.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColChangeValuta.HeaderText = "ChangeValuta";
            this.ColChangeValuta.Name = "ColChangeValuta";
            this.ColChangeValuta.ReadOnly = true;
            // 
            // EOD_SafePayCurr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 228);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.drS_DataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EOD_SafePayCurr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SafePayCurr";
            this.Load += new System.EventHandler(this.EOD_SafePayCurr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsEOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSafePayDepot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drS_DataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DRS.Extensions.DRS_DataGridView dataGridView1;
        private EODDataSet dsEOD;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mOPCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private DRS.Extensions.DRS_DataGridView drS_DataGridView1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.BindingSource bindingSafePayDepot;
        private EODDataSetTableAdapters.EOD_SafePay_DepotbeholdningTableAdapter AdapterSafePay_Depotbeholdning;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChangeDKK;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChangeValuta;
    }
}