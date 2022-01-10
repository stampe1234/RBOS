namespace RBOS
{
    partial class ForbrugsvareRegistrering
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForbrugsvareRegistrering));
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.btnBook = new System.Windows.Forms.Button();
            this.lbOpenDay = new System.Windows.Forms.Label();
            this.bindingForbrugsvareRegistrering = new System.Windows.Forms.BindingSource(this.components);
            this.dsItem = new RBOS.ItemDataSet();
            this.adapterForbrugsvareRegistrering = new RBOS.ItemDataSetTableAdapters.ForbrugsvareRegistreringTableAdapter();
            this.grid = new DRS.Extensions.DRS_DataGridView();
            this.colVarenummer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLookupVare = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVarenavn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLevNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVaregruppe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKostpris = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalgspris = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAntal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingForbrugsvareRegistrering)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndClose.Location = new System.Drawing.Point(671, 503);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(108, 23);
            this.btnSaveAndClose.TabIndex = 0;
            this.btnSaveAndClose.Text = "Save and Close";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // btnBook
            // 
            this.btnBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBook.Location = new System.Drawing.Point(589, 503);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(76, 23);
            this.btnBook.TabIndex = 1;
            this.btnBook.Text = "Book";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // lbOpenDay
            // 
            this.lbOpenDay.AutoSize = true;
            this.lbOpenDay.Location = new System.Drawing.Point(12, 9);
            this.lbOpenDay.Name = "lbOpenDay";
            this.lbOpenDay.Size = new System.Drawing.Size(68, 13);
            this.lbOpenDay.TabIndex = 3;
            this.lbOpenDay.Text = "[Åbent døgn]";
            // 
            // bindingForbrugsvareRegistrering
            // 
            this.bindingForbrugsvareRegistrering.DataMember = "ForbrugsvareRegistrering";
            this.bindingForbrugsvareRegistrering.DataSource = this.dsItem;
            // 
            // dsItem
            // 
            this.dsItem.DataSetName = "ItemDataSet";
            this.dsItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // adapterForbrugsvareRegistrering
            // 
            this.adapterForbrugsvareRegistrering.ClearBeforeFill = true;
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
            this.colVarenummer,
            this.colLookupVare,
            this.colBarcode,
            this.colVarenavn,
            this.colLevNr,
            this.colVaregruppe,
            this.colKostpris,
            this.colSalgspris,
            this.colAntal});
            this.grid.DataSource = this.bindingForbrugsvareRegistrering;
            this.grid.Location = new System.Drawing.Point(12, 27);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.RowHeadersWidth = 25;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.Size = new System.Drawing.Size(767, 470);
            this.grid.TabIndex = 2;
            this.grid.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grid_RowValidating);
            this.grid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grid_CellPainting);
            this.grid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grid_KeyUp);
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            // 
            // colVarenummer
            // 
            this.colVarenummer.DataPropertyName = "Varenummer";
            this.colVarenummer.HeaderText = "Varenummer";
            this.colVarenummer.Name = "colVarenummer";
            this.colVarenummer.Width = 80;
            // 
            // colLookupVare
            // 
            this.colLookupVare.HeaderText = "";
            this.colLookupVare.Name = "colLookupVare";
            this.colLookupVare.Width = 25;
            // 
            // colBarcode
            // 
            this.colBarcode.DataPropertyName = "Barcode";
            this.colBarcode.HeaderText = "Barcode";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.Width = 90;
            // 
            // colVarenavn
            // 
            this.colVarenavn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colVarenavn.DataPropertyName = "Varenavn";
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.colVarenavn.DefaultCellStyle = dataGridViewCellStyle1;
            this.colVarenavn.HeaderText = "Varenavn";
            this.colVarenavn.Name = "colVarenavn";
            this.colVarenavn.ReadOnly = true;
            // 
            // colLevNr
            // 
            this.colLevNr.DataPropertyName = "LevNr";
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            this.colLevNr.DefaultCellStyle = dataGridViewCellStyle2;
            this.colLevNr.HeaderText = "LevNr";
            this.colLevNr.Name = "colLevNr";
            this.colLevNr.ReadOnly = true;
            this.colLevNr.Width = 60;
            // 
            // colVaregruppe
            // 
            this.colVaregruppe.DataPropertyName = "Varegruppe";
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            this.colVaregruppe.DefaultCellStyle = dataGridViewCellStyle3;
            this.colVaregruppe.HeaderText = "Varegruppe";
            this.colVaregruppe.Name = "colVaregruppe";
            this.colVaregruppe.ReadOnly = true;
            this.colVaregruppe.Width = 70;
            // 
            // colKostpris
            // 
            this.colKostpris.DataPropertyName = "Kostpris";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Format = "N3";
            dataGridViewCellStyle4.NullValue = null;
            this.colKostpris.DefaultCellStyle = dataGridViewCellStyle4;
            this.colKostpris.HeaderText = "Kostpris";
            this.colKostpris.Name = "colKostpris";
            this.colKostpris.ReadOnly = true;
            this.colKostpris.Visible = false;
            this.colKostpris.Width = 60;
            // 
            // colSalgspris
            // 
            this.colSalgspris.DataPropertyName = "Salgspris";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.colSalgspris.DefaultCellStyle = dataGridViewCellStyle5;
            this.colSalgspris.HeaderText = "Salgspris";
            this.colSalgspris.Name = "colSalgspris";
            this.colSalgspris.Width = 60;
            // 
            // colAntal
            // 
            this.colAntal.DataPropertyName = "Antal";
            this.colAntal.HeaderText = "Antal";
            this.colAntal.Name = "colAntal";
            this.colAntal.Width = 50;
            // 
            // ForbrugsvareRegistrering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 538);
            this.Controls.Add(this.lbOpenDay);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.btnSaveAndClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ForbrugsvareRegistrering";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ForbrugsvareRegistrering";
            this.Load += new System.EventHandler(this.ForbrugsvareRegistrering_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingForbrugsvareRegistrering)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.Button btnBook;
        private DRS.Extensions.DRS_DataGridView grid;
        private ItemDataSet dsItem;
        private System.Windows.Forms.BindingSource bindingForbrugsvareRegistrering;
        private RBOS.ItemDataSetTableAdapters.ForbrugsvareRegistreringTableAdapter adapterForbrugsvareRegistrering;
        private System.Windows.Forms.Label lbOpenDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVarenummer;
        private System.Windows.Forms.DataGridViewButtonColumn colLookupVare;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVarenavn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLevNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVaregruppe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKostpris;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalgspris;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAntal;
    }
}