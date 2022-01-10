namespace RBOS
{
    partial class PrlAbsenseCodes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrlAbsenseCodes));
            this.btnOk = new System.Windows.Forms.Button();
            this.prlLookupAbsenseCodesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.payroll = new RBOS.Payroll();
            this.prlLookupAbsenseCodesTableAdapter = new RBOS.PayrollTableAdapters.PrlLookupAbsenseCodesTableAdapter();
            this.drS_DataGridView1 = new DRS.Extensions.DRS_DataGridView();
            this.colAbsenseCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.prlLookupAbsenseCodesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.payroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drS_DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.Location = new System.Drawing.Point(142, 225);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "[Ok]";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // prlLookupAbsenseCodesBindingSource
            // 
            this.prlLookupAbsenseCodesBindingSource.DataMember = "PrlLookupAbsenseCodes";
            this.prlLookupAbsenseCodesBindingSource.DataSource = this.payroll;
            // 
            // payroll
            // 
            this.payroll.DataSetName = "Payroll";
            this.payroll.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // prlLookupAbsenseCodesTableAdapter
            // 
            this.prlLookupAbsenseCodesTableAdapter.ClearBeforeFill = true;
            // 
            // drS_DataGridView1
            // 
            this.drS_DataGridView1.AllowUserToAddRows = false;
            this.drS_DataGridView1.AllowUserToDeleteRows = false;
            this.drS_DataGridView1.AllowUserToResizeColumns = false;
            this.drS_DataGridView1.AllowUserToResizeRows = false;
            this.drS_DataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.drS_DataGridView1.AutoGenerateColumns = false;
            this.drS_DataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.drS_DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.drS_DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drS_DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAbsenseCode,
            this.colDescription});
            this.drS_DataGridView1.DataSource = this.prlLookupAbsenseCodesBindingSource;
            this.drS_DataGridView1.Location = new System.Drawing.Point(12, 12);
            this.drS_DataGridView1.MultiSelect = false;
            this.drS_DataGridView1.Name = "drS_DataGridView1";
            this.drS_DataGridView1.ReadOnly = true;
            this.drS_DataGridView1.RowHeadersWidth = 25;
            this.drS_DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.drS_DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.drS_DataGridView1.Size = new System.Drawing.Size(286, 207);
            this.drS_DataGridView1.TabIndex = 0;
            this.drS_DataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.drS_DataGridView1_KeyDown);
            this.drS_DataGridView1.DoubleClick += new System.EventHandler(this.drS_DataGridView1_DoubleClick);
            // 
            // colAbsenseCode
            // 
            this.colAbsenseCode.DataPropertyName = "AbsenseCode";
            this.colAbsenseCode.HeaderText = "Code";
            this.colAbsenseCode.Name = "colAbsenseCode";
            this.colAbsenseCode.ReadOnly = true;
            this.colAbsenseCode.Width = 50;
            // 
            // colDescription
            // 
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(223, 225);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "[Cancel]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PrlAbsenseCodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(310, 260);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.drS_DataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PrlAbsenseCodes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrlAbsenseCodes";
            this.Load += new System.EventHandler(this.PrlAbsenseCodes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.prlLookupAbsenseCodesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.payroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drS_DataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DRS.Extensions.DRS_DataGridView drS_DataGridView1;
        private Payroll payroll;
        private System.Windows.Forms.BindingSource prlLookupAbsenseCodesBindingSource;
        private RBOS.PayrollTableAdapters.PrlLookupAbsenseCodesTableAdapter prlLookupAbsenseCodesTableAdapter;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAbsenseCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.Button btnCancel;
    }
}