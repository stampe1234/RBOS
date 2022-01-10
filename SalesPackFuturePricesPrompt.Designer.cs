namespace RBOS
{
    partial class SalesPackFuturePricesPrompt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesPackFuturePricesPrompt));
            this.btnPerform = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.bindingSalesPackFuturePricesPrompt = new System.Windows.Forms.BindingSource(this.components);
            this.dsItem = new RBOS.ItemDataSet();
            this.adapterSalesPackFuturePricesPrompt = new RBOS.ItemDataSetTableAdapters.SalesPackFuturePricesPromptTableAdapter();
            this.lbDescription = new System.Windows.Forms.Label();
            this.grid = new DRS.Extensions.DRS_DataGridView();
            this.colPackType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActivationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFutureSalesPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrentSalesPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrigin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPerform = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSalesPackFuturePricesPrompt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPerform
            // 
            this.btnPerform.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPerform.Location = new System.Drawing.Point(541, 386);
            this.btnPerform.Name = "btnPerform";
            this.btnPerform.Size = new System.Drawing.Size(75, 23);
            this.btnPerform.TabIndex = 0;
            this.btnPerform.Text = "[Udfør]";
            this.btnPerform.UseVisualStyleBackColor = true;
            this.btnPerform.Click += new System.EventHandler(this.btnPerform_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(622, 386);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "[Annuller]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // bindingSalesPackFuturePricesPrompt
            // 
            this.bindingSalesPackFuturePricesPrompt.DataMember = "SalesPackFuturePricesPrompt";
            this.bindingSalesPackFuturePricesPrompt.DataSource = this.dsItem;
            // 
            // dsItem
            // 
            this.dsItem.DataSetName = "ItemDataSet";
            this.dsItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // adapterSalesPackFuturePricesPrompt
            // 
            this.adapterSalesPackFuturePricesPrompt.ClearBeforeFill = true;
            // 
            // lbDescription
            // 
            this.lbDescription.Location = new System.Drawing.Point(12, 9);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(685, 31);
            this.lbDescription.TabIndex = 3;
            this.lbDescription.Text = "label1";
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
            this.colPackType,
            this.colActivationDate,
            this.colFutureSalesPrice,
            this.colBarcode,
            this.colCurrentSalesPrice,
            this.colOrigin,
            this.colDescription,
            this.colPerform});
            this.grid.DataSource = this.bindingSalesPackFuturePricesPrompt;
            this.grid.Location = new System.Drawing.Point(12, 43);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.RowHeadersWidth = 25;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.Size = new System.Drawing.Size(685, 337);
            this.grid.TabIndex = 2;
            // 
            // colPackType
            // 
            this.colPackType.DataPropertyName = "PackType";
            this.colPackType.HeaderText = "PackType";
            this.colPackType.Name = "colPackType";
            this.colPackType.ReadOnly = true;
            this.colPackType.Width = 30;
            // 
            // colActivationDate
            // 
            this.colActivationDate.DataPropertyName = "ActivationDate";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.colActivationDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.colActivationDate.HeaderText = "ActivationDate";
            this.colActivationDate.Name = "colActivationDate";
            this.colActivationDate.ReadOnly = true;
            this.colActivationDate.Width = 80;
            // 
            // colFutureSalesPrice
            // 
            this.colFutureSalesPrice.DataPropertyName = "FutureSalesPrice";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.colFutureSalesPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.colFutureSalesPrice.HeaderText = "FutureSalesPrice";
            this.colFutureSalesPrice.Name = "colFutureSalesPrice";
            this.colFutureSalesPrice.ReadOnly = true;
            this.colFutureSalesPrice.Width = 70;
            // 
            // colBarcode
            // 
            this.colBarcode.DataPropertyName = "Barcode";
            this.colBarcode.HeaderText = "Barcode";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.ReadOnly = true;
            // 
            // colCurrentSalesPrice
            // 
            this.colCurrentSalesPrice.DataPropertyName = "CurrentSalesPrice";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.colCurrentSalesPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.colCurrentSalesPrice.HeaderText = "CurrentSalesPrice";
            this.colCurrentSalesPrice.Name = "colCurrentSalesPrice";
            this.colCurrentSalesPrice.ReadOnly = true;
            this.colCurrentSalesPrice.Width = 70;
            // 
            // colOrigin
            // 
            this.colOrigin.DataPropertyName = "Origin";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colOrigin.DefaultCellStyle = dataGridViewCellStyle4;
            this.colOrigin.HeaderText = "Origin";
            this.colOrigin.Name = "colOrigin";
            this.colOrigin.ReadOnly = true;
            this.colOrigin.Width = 65;
            // 
            // colDescription
            // 
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // colPerform
            // 
            this.colPerform.DataPropertyName = "Perform";
            this.colPerform.HeaderText = "Perform";
            this.colPerform.Name = "colPerform";
            this.colPerform.Width = 50;
            // 
            // SalesPackFuturePricesPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 421);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPerform);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SalesPackFuturePricesPrompt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Fremtidige salgspriser]";
            this.Load += new System.EventHandler(this.SalesPackFuturePricesPrompt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSalesPackFuturePricesPrompt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPerform;
        private System.Windows.Forms.Button btnCancel;
        private DRS.Extensions.DRS_DataGridView grid;
        private ItemDataSet dsItem;
        private System.Windows.Forms.BindingSource bindingSalesPackFuturePricesPrompt;
        private RBOS.ItemDataSetTableAdapters.SalesPackFuturePricesPromptTableAdapter adapterSalesPackFuturePricesPrompt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActivationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFutureSalesPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrentSalesPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrigin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colPerform;
        private System.Windows.Forms.Label lbDescription;
    }
}