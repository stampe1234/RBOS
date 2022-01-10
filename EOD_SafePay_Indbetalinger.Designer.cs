namespace RBOS
{
    partial class EOD_SafePay_Indbetalinger
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EOD_SafePay_Indbetalinger));
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dsEOD = new RBOS.EODDataSet();
            this.bindingEODSafePayIndbetalinger = new System.Windows.Forms.BindingSource(this.components);
            this.adapterEODSafePayIndbetalinger = new RBOS.EODDataSetTableAdapters.EOD_SafePay_IndbetalingerTableAdapter();
            this.grid = new DRS.Extensions.DRS_DataGridView();
            this.colKassenr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAntal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBeloeb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBeskrivelse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dsEOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingEODSafePayIndbetalinger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndClose.Location = new System.Drawing.Point(195, 258);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(113, 23);
            this.btnSaveAndClose.TabIndex = 1;
            this.btnSaveAndClose.Text = "[Save && Close]";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(314, 258);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "[Annuller]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dsEOD
            // 
            this.dsEOD.DataSetName = "EODDataSet";
            this.dsEOD.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingEODSafePayIndbetalinger
            // 
            this.bindingEODSafePayIndbetalinger.DataMember = "EOD_SafePay_Indbetalinger";
            this.bindingEODSafePayIndbetalinger.DataSource = this.dsEOD;
            // 
            // adapterEODSafePayIndbetalinger
            // 
            this.adapterEODSafePayIndbetalinger.ClearBeforeFill = true;
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
            this.colKassenr,
            this.colTid,
            this.colAntal,
            this.colBeloeb,
            this.colBeskrivelse});
            this.grid.DataSource = this.bindingEODSafePayIndbetalinger;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.DefaultCellStyle = dataGridViewCellStyle6;
            this.grid.Location = new System.Drawing.Point(12, 12);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.RowHeadersWidth = 25;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.Size = new System.Drawing.Size(377, 240);
            this.grid.TabIndex = 0;
            // 
            // colKassenr
            // 
            this.colKassenr.DataPropertyName = "Kassenr";
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            this.colKassenr.DefaultCellStyle = dataGridViewCellStyle2;
            this.colKassenr.HeaderText = "Kassenr";
            this.colKassenr.Name = "colKassenr";
            this.colKassenr.ReadOnly = true;
            this.colKassenr.Width = 50;
            // 
            // colTid
            // 
            this.colTid.DataPropertyName = "Tid";
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Format = "t";
            dataGridViewCellStyle3.NullValue = null;
            this.colTid.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTid.HeaderText = "Tid";
            this.colTid.Name = "colTid";
            this.colTid.ReadOnly = true;
            this.colTid.Width = 50;
            // 
            // colAntal
            // 
            this.colAntal.DataPropertyName = "Antal";
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            this.colAntal.DefaultCellStyle = dataGridViewCellStyle4;
            this.colAntal.HeaderText = "Antal";
            this.colAntal.Name = "colAntal";
            this.colAntal.ReadOnly = true;
            this.colAntal.Width = 50;
            // 
            // colBeloeb
            // 
            this.colBeloeb.DataPropertyName = "Beloeb";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.colBeloeb.DefaultCellStyle = dataGridViewCellStyle5;
            this.colBeloeb.HeaderText = "Beloeb";
            this.colBeloeb.Name = "colBeloeb";
            this.colBeloeb.ReadOnly = true;
            this.colBeloeb.Width = 70;
            // 
            // colBeskrivelse
            // 
            this.colBeskrivelse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBeskrivelse.DataPropertyName = "Beskrivelse";
            this.colBeskrivelse.HeaderText = "Beskrivelse";
            this.colBeskrivelse.Name = "colBeskrivelse";
            // 
            // EOD_SafePay_Indbetalinger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 293);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.grid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EOD_SafePay_Indbetalinger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EOD_SafePay_Indbetalinger";
            this.Load += new System.EventHandler(this.EOD_SafePay_Indbetalinger_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsEOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingEODSafePayIndbetalinger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DRS.Extensions.DRS_DataGridView grid;
        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.Button btnCancel;
        private EODDataSet dsEOD;
        private System.Windows.Forms.BindingSource bindingEODSafePayIndbetalinger;
        private RBOS.EODDataSetTableAdapters.EOD_SafePay_IndbetalingerTableAdapter adapterEODSafePayIndbetalinger;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKassenr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAntal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBeloeb;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBeskrivelse;
    }
}