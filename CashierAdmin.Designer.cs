namespace RBOS
{
    partial class CashierAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashierAdmin));
            this.grid = new DRS.Extensions.DRS_DataGridView();
            this.colCashierID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNavn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingCashier = new System.Windows.Forms.BindingSource(this.components);
            this.dsEOD = new RBOS.EODDataSet();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.adapterCashier = new RBOS.EODDataSetTableAdapters.CashierTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingCashier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEOD)).BeginInit();
            this.SuspendLayout();
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
            this.colCashierID,
            this.colNavn});
            this.grid.DataSource = this.bindingCashier;
            this.grid.Location = new System.Drawing.Point(12, 12);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.RowHeadersWidth = 25;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.Size = new System.Drawing.Size(379, 276);
            this.grid.TabIndex = 0;
            // 
            // colCashierID
            // 
            this.colCashierID.DataPropertyName = "CashierID";
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.colCashierID.DefaultCellStyle = dataGridViewCellStyle1;
            this.colCashierID.HeaderText = "[CashierID]";
            this.colCashierID.Name = "colCashierID";
            this.colCashierID.ReadOnly = true;
            // 
            // colNavn
            // 
            this.colNavn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNavn.DataPropertyName = "Navn";
            this.colNavn.HeaderText = "[Navn]";
            this.colNavn.Name = "colNavn";
            // 
            // bindingCashier
            // 
            this.bindingCashier.DataMember = "Cashier";
            this.bindingCashier.DataSource = this.dsEOD;
            // 
            // dsEOD
            // 
            this.dsEOD.DataSetName = "EODDataSet";
            this.dsEOD.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndClose.Location = new System.Drawing.Point(282, 294);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(109, 23);
            this.btnSaveAndClose.TabIndex = 1;
            this.btnSaveAndClose.Text = "[Gem og luk]";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // adapterCashier
            // 
            this.adapterCashier.ClearBeforeFill = true;
            // 
            // CashierAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 329);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.grid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CashierAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CashierAdmin";
            this.Load += new System.EventHandler(this.CashierAdmin_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CashierAdmin_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingCashier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEOD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DRS.Extensions.DRS_DataGridView grid;
        private System.Windows.Forms.Button btnSaveAndClose;
        private EODDataSet dsEOD;
        private System.Windows.Forms.BindingSource bindingCashier;
        private RBOS.EODDataSetTableAdapters.CashierTableAdapter adapterCashier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCashierID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNavn;
    }
}