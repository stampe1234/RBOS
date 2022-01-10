namespace RBOS
{
    partial class ForbrugsvareSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForbrugsvareSearch));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtVaregruppe = new System.Windows.Forms.TextBox();
            this.txtVarenavn = new System.Windows.Forms.TextBox();
            this.lbBarcode = new System.Windows.Forms.Label();
            this.lbVarenavn = new System.Windows.Forms.Label();
            this.lbVaregruppe = new System.Windows.Forms.Label();
            this.btnLookupVaregruppe = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.txtVarenummer = new System.Windows.Forms.TextBox();
            this.lbVarenummer = new System.Windows.Forms.Label();
            this.bindingForbrugsvareSearch = new System.Windows.Forms.BindingSource(this.components);
            this.dsItem = new RBOS.ItemDataSet();
            this.adapterForbrugsvareSearch = new RBOS.ItemDataSetTableAdapters.ForbrugsvareSearchTableAdapter();
            this.dataGridView1 = new DRS.Extensions.DRS_DataGridView();
            this.colVarenummer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVarenavn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVaregruppeDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLevKategori = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingForbrugsvareSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(626, 466);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "[select]";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(707, 466);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "[cancel]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtVaregruppe
            // 
            this.txtVaregruppe.Location = new System.Drawing.Point(513, 28);
            this.txtVaregruppe.Name = "txtVaregruppe";
            this.txtVaregruppe.ReadOnly = true;
            this.txtVaregruppe.Size = new System.Drawing.Size(82, 20);
            this.txtVaregruppe.TabIndex = 3;
            this.txtVaregruppe.TabStop = false;
            this.txtVaregruppe.Leave += new System.EventHandler(this.txtVaregruppe_Leave);
            // 
            // txtVarenavn
            // 
            this.txtVarenavn.Location = new System.Drawing.Point(213, 28);
            this.txtVarenavn.Name = "txtVarenavn";
            this.txtVarenavn.Size = new System.Drawing.Size(299, 20);
            this.txtVarenavn.TabIndex = 2;
            this.txtVarenavn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVarenavn_KeyDown);
            this.txtVarenavn.Leave += new System.EventHandler(this.txtVarenavn_Leave);
            // 
            // lbBarcode
            // 
            this.lbBarcode.AutoSize = true;
            this.lbBarcode.Location = new System.Drawing.Point(11, 9);
            this.lbBarcode.Name = "lbBarcode";
            this.lbBarcode.Size = new System.Drawing.Size(47, 13);
            this.lbBarcode.TabIndex = 8;
            this.lbBarcode.Text = "Barcode";
            // 
            // lbVarenavn
            // 
            this.lbVarenavn.AutoSize = true;
            this.lbVarenavn.Location = new System.Drawing.Point(212, 9);
            this.lbVarenavn.Name = "lbVarenavn";
            this.lbVarenavn.Size = new System.Drawing.Size(53, 13);
            this.lbVarenavn.TabIndex = 9;
            this.lbVarenavn.Text = "Varenavn";
            // 
            // lbVaregruppe
            // 
            this.lbVaregruppe.AutoSize = true;
            this.lbVaregruppe.Location = new System.Drawing.Point(512, 9);
            this.lbVaregruppe.Name = "lbVaregruppe";
            this.lbVaregruppe.Size = new System.Drawing.Size(62, 13);
            this.lbVaregruppe.TabIndex = 10;
            this.lbVaregruppe.Text = "Varegruppe";
            // 
            // btnLookupVaregruppe
            // 
            this.btnLookupVaregruppe.Image = ((System.Drawing.Image)(resources.GetObject("btnLookupVaregruppe.Image")));
            this.btnLookupVaregruppe.Location = new System.Drawing.Point(597, 26);
            this.btnLookupVaregruppe.Name = "btnLookupVaregruppe";
            this.btnLookupVaregruppe.Size = new System.Drawing.Size(27, 23);
            this.btnLookupVaregruppe.TabIndex = 4;
            this.btnLookupVaregruppe.UseVisualStyleBackColor = true;
            this.btnLookupVaregruppe.Click += new System.EventHandler(this.btnLookupVaregruppe_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(12, 28);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(100, 20);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            this.txtBarcode.Leave += new System.EventHandler(this.txtBarcode_Leave);
            // 
            // txtVarenummer
            // 
            this.txtVarenummer.Location = new System.Drawing.Point(113, 28);
            this.txtVarenummer.Name = "txtVarenummer";
            this.txtVarenummer.Size = new System.Drawing.Size(99, 20);
            this.txtVarenummer.TabIndex = 1;
            this.txtVarenummer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVarenummer_KeyDown);
            this.txtVarenummer.Leave += new System.EventHandler(this.txtVarenummer_Leave);
            // 
            // lbVarenummer
            // 
            this.lbVarenummer.AutoSize = true;
            this.lbVarenummer.Location = new System.Drawing.Point(111, 9);
            this.lbVarenummer.Name = "lbVarenummer";
            this.lbVarenummer.Size = new System.Drawing.Size(66, 13);
            this.lbVarenummer.TabIndex = 12;
            this.lbVarenummer.Text = "Varenummer";
            // 
            // bindingForbrugsvareSearch
            // 
            this.bindingForbrugsvareSearch.DataMember = "ForbrugsvareSearch";
            this.bindingForbrugsvareSearch.DataSource = this.dsItem;
            // 
            // dsItem
            // 
            this.dsItem.DataSetName = "ItemDataSet";
            this.dsItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // adapterForbrugsvareSearch
            // 
            this.adapterForbrugsvareSearch.ClearBeforeFill = true;
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
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colVarenummer,
            this.colVarenavn,
            this.colBarcode,
            this.colVaregruppeDesc,
            this.colLevKategori});
            this.dataGridView1.DataSource = this.bindingForbrugsvareSearch;
            this.dataGridView1.Location = new System.Drawing.Point(12, 54);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(770, 406);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // colVarenummer
            // 
            this.colVarenummer.DataPropertyName = "Varenummer";
            this.colVarenummer.HeaderText = "Varenummer";
            this.colVarenummer.Name = "colVarenummer";
            this.colVarenummer.ReadOnly = true;
            // 
            // colVarenavn
            // 
            this.colVarenavn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colVarenavn.DataPropertyName = "Varenavn";
            this.colVarenavn.HeaderText = "Varenavn";
            this.colVarenavn.Name = "colVarenavn";
            this.colVarenavn.ReadOnly = true;
            // 
            // colBarcode
            // 
            this.colBarcode.DataPropertyName = "Barcode";
            this.colBarcode.HeaderText = "Barcode";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.ReadOnly = true;
            // 
            // colVaregruppeDesc
            // 
            this.colVaregruppeDesc.DataPropertyName = "VaregruppeDesc";
            this.colVaregruppeDesc.HeaderText = "Varegruppe";
            this.colVaregruppeDesc.Name = "colVaregruppeDesc";
            this.colVaregruppeDesc.ReadOnly = true;
            // 
            // colLevKategori
            // 
            this.colLevKategori.DataPropertyName = "LevKategori";
            this.colLevKategori.HeaderText = "LevKategori";
            this.colLevKategori.Name = "colLevKategori";
            this.colLevKategori.ReadOnly = true;
            this.colLevKategori.Width = 150;
            // 
            // ForbrugsvareSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 501);
            this.Controls.Add(this.lbVarenummer);
            this.Controls.Add(this.txtVarenummer);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.btnLookupVaregruppe);
            this.Controls.Add(this.lbVaregruppe);
            this.Controls.Add(this.lbVarenavn);
            this.Controls.Add(this.lbBarcode);
            this.Controls.Add(this.txtVarenavn);
            this.Controls.Add(this.txtVaregruppe);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ForbrugsvareSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ForbrugsvareSearch";
            this.Load += new System.EventHandler(this.ForbrugsvareSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingForbrugsvareSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DRS.Extensions.DRS_DataGridView dataGridView1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtVaregruppe;
        private System.Windows.Forms.TextBox txtVarenavn;
        private System.Windows.Forms.Label lbBarcode;
        private System.Windows.Forms.Label lbVarenavn;
        private System.Windows.Forms.Label lbVaregruppe;
        private System.Windows.Forms.Button btnLookupVaregruppe;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.TextBox txtVarenummer;
        private System.Windows.Forms.Label lbVarenummer;
        private ItemDataSet dsItem;
        private System.Windows.Forms.BindingSource bindingForbrugsvareSearch;
        private RBOS.ItemDataSetTableAdapters.ForbrugsvareSearchTableAdapter adapterForbrugsvareSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVarenummer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVarenavn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVaregruppeDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLevKategori;
    }
}