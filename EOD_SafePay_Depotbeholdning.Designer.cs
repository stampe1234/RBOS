namespace RBOS
{
    partial class EOD_SafePay_Depotbeholdning
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EOD_SafePay_Depotbeholdning));
            this.btnClose = new System.Windows.Forms.Button();
            this.bindingEODSafePayDepotbeholdning = new System.Windows.Forms.BindingSource(this.components);
            this.dsEOD = new RBOS.EODDataSet();
            this.adapterEODSafePayDepotbeholdning = new RBOS.EODDataSetTableAdapters.EOD_SafePay_DepotbeholdningTableAdapter();
            this.grid = new DRS.Extensions.DRS_DataGridView();
            this.colEnhedsnummer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValutaTekst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValutaBeloeb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDKKBeloeb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingEODSafePayDepotbeholdning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(288, 275);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "[Annuller]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // bindingEODSafePayDepotbeholdning
            // 
            this.bindingEODSafePayDepotbeholdning.DataMember = "EOD_SafePay_Depotbeholdning";
            this.bindingEODSafePayDepotbeholdning.DataSource = this.dsEOD;
            // 
            // dsEOD
            // 
            this.dsEOD.DataSetName = "EODDataSet";
            this.dsEOD.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // adapterEODSafePayDepotbeholdning
            // 
            this.adapterEODSafePayDepotbeholdning.ClearBeforeFill = true;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEnhedsnummer,
            this.colValutaTekst,
            this.colValutaBeloeb,
            this.colDKKBeloeb});
            this.grid.DataSource = this.bindingEODSafePayDepotbeholdning;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.DefaultCellStyle = dataGridViewCellStyle4;
            this.grid.Location = new System.Drawing.Point(11, 11);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersWidth = 25;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.Size = new System.Drawing.Size(352, 258);
            this.grid.TabIndex = 3;
            // 
            // colEnhedsnummer
            // 
            this.colEnhedsnummer.DataPropertyName = "Enhedsnummer";
            this.colEnhedsnummer.HeaderText = "Enhedsnummer";
            this.colEnhedsnummer.Name = "colEnhedsnummer";
            this.colEnhedsnummer.ReadOnly = true;
            this.colEnhedsnummer.Width = 90;
            // 
            // colValutaTekst
            // 
            this.colValutaTekst.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colValutaTekst.DataPropertyName = "ValutaTekst";
            this.colValutaTekst.HeaderText = "ValutaTekst";
            this.colValutaTekst.Name = "colValutaTekst";
            this.colValutaTekst.ReadOnly = true;
            // 
            // colValutaBeloeb
            // 
            this.colValutaBeloeb.DataPropertyName = "ValutaBeloeb";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.colValutaBeloeb.DefaultCellStyle = dataGridViewCellStyle2;
            this.colValutaBeloeb.HeaderText = "ValutaBeloeb";
            this.colValutaBeloeb.Name = "colValutaBeloeb";
            this.colValutaBeloeb.ReadOnly = true;
            this.colValutaBeloeb.Width = 70;
            // 
            // colDKKBeloeb
            // 
            this.colDKKBeloeb.DataPropertyName = "DKKBeloeb";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.colDKKBeloeb.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDKKBeloeb.HeaderText = "DKKBeloeb";
            this.colDKKBeloeb.Name = "colDKKBeloeb";
            this.colDKKBeloeb.ReadOnly = true;
            this.colDKKBeloeb.Width = 70;
            // 
            // EOD_SafePay_Depotbeholdning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 309);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EOD_SafePay_Depotbeholdning";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EOD_SafePay_Depotbeholdning";
            this.Load += new System.EventHandler(this.EOD_SafePay_Depotbeholdning_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingEODSafePayDepotbeholdning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private DRS.Extensions.DRS_DataGridView grid;
        private EODDataSet dsEOD;
        private System.Windows.Forms.BindingSource bindingEODSafePayDepotbeholdning;
        private RBOS.EODDataSetTableAdapters.EOD_SafePay_DepotbeholdningTableAdapter adapterEODSafePayDepotbeholdning;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEnhedsnummer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValutaTekst;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValutaBeloeb;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDKKBeloeb;
    }
}