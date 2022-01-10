namespace RBOS
{
    partial class SubCategoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubCategoryForm));
            this.dataGridView1 = new DRS.Extensions.DRS_DataGridView();
            this.subCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.adminDataSet = new RBOS.AdminDataSet();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.subCategoryTableAdapter = new RBOS.AdminDataSetTableAdapters.SubCategoryTableAdapter();
            this.subCategoryIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vatRateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vatOwnerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditCategoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ageRestrictionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mOPRestrictionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.budgetMarginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemTypeCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hideInLookupDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.notActiveDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subCategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adminDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.subCategoryIDDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.categoryIDDataGridViewTextBoxColumn,
            this.vatRateDataGridViewTextBoxColumn,
            this.vatOwnerDataGridViewTextBoxColumn,
            this.creditCategoryDataGridViewTextBoxColumn,
            this.ageRestrictionDataGridViewTextBoxColumn,
            this.mOPRestrictionDataGridViewTextBoxColumn,
            this.budgetMarginDataGridViewTextBoxColumn,
            this.itemTypeCodeDataGridViewTextBoxColumn,
            this.hideInLookupDataGridViewCheckBoxColumn,
            this.notActiveDataGridViewCheckBoxColumn});
            this.dataGridView1.DataSource = this.subCategoryBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(756, 329);
            this.dataGridView1.TabIndex = 0;
            // 
            // subCategoryBindingSource
            // 
            this.subCategoryBindingSource.DataMember = "SubCategory";
            this.subCategoryBindingSource.DataSource = this.adminDataSet;
            // 
            // adminDataSet
            // 
            this.adminDataSet.DataSetName = "AdminDataSet";
            this.adminDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(611, 357);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "[Save]";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(693, 357);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button2_Click);
            // 
            // subCategoryTableAdapter
            // 
            this.subCategoryTableAdapter.ClearBeforeFill = true;
            // 
            // subCategoryIDDataGridViewTextBoxColumn
            // 
            this.subCategoryIDDataGridViewTextBoxColumn.DataPropertyName = "SubCategoryID";
            this.subCategoryIDDataGridViewTextBoxColumn.HeaderText = "SubCategoryID";
            this.subCategoryIDDataGridViewTextBoxColumn.Name = "subCategoryIDDataGridViewTextBoxColumn";
            this.subCategoryIDDataGridViewTextBoxColumn.Width = 70;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // categoryIDDataGridViewTextBoxColumn
            // 
            this.categoryIDDataGridViewTextBoxColumn.DataPropertyName = "CategoryID";
            this.categoryIDDataGridViewTextBoxColumn.HeaderText = "CategoryID";
            this.categoryIDDataGridViewTextBoxColumn.Name = "categoryIDDataGridViewTextBoxColumn";
            this.categoryIDDataGridViewTextBoxColumn.Width = 50;
            // 
            // vatRateDataGridViewTextBoxColumn
            // 
            this.vatRateDataGridViewTextBoxColumn.DataPropertyName = "VatRate";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.vatRateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.vatRateDataGridViewTextBoxColumn.HeaderText = "VatRate";
            this.vatRateDataGridViewTextBoxColumn.Name = "vatRateDataGridViewTextBoxColumn";
            this.vatRateDataGridViewTextBoxColumn.Width = 40;
            // 
            // vatOwnerDataGridViewTextBoxColumn
            // 
            this.vatOwnerDataGridViewTextBoxColumn.DataPropertyName = "VatOwner";
            this.vatOwnerDataGridViewTextBoxColumn.HeaderText = "VatOwner";
            this.vatOwnerDataGridViewTextBoxColumn.Name = "vatOwnerDataGridViewTextBoxColumn";
            this.vatOwnerDataGridViewTextBoxColumn.Width = 40;
            // 
            // creditCategoryDataGridViewTextBoxColumn
            // 
            this.creditCategoryDataGridViewTextBoxColumn.DataPropertyName = "CreditCategory";
            this.creditCategoryDataGridViewTextBoxColumn.HeaderText = "CreditCategory";
            this.creditCategoryDataGridViewTextBoxColumn.Name = "creditCategoryDataGridViewTextBoxColumn";
            this.creditCategoryDataGridViewTextBoxColumn.Width = 40;
            // 
            // ageRestrictionDataGridViewTextBoxColumn
            // 
            this.ageRestrictionDataGridViewTextBoxColumn.DataPropertyName = "AgeRestriction";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.ageRestrictionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.ageRestrictionDataGridViewTextBoxColumn.HeaderText = "AgeRestriction";
            this.ageRestrictionDataGridViewTextBoxColumn.Name = "ageRestrictionDataGridViewTextBoxColumn";
            this.ageRestrictionDataGridViewTextBoxColumn.Width = 50;
            // 
            // mOPRestrictionDataGridViewTextBoxColumn
            // 
            this.mOPRestrictionDataGridViewTextBoxColumn.DataPropertyName = "MOPRestriction";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.mOPRestrictionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.mOPRestrictionDataGridViewTextBoxColumn.HeaderText = "MOPRestriction";
            this.mOPRestrictionDataGridViewTextBoxColumn.Name = "mOPRestrictionDataGridViewTextBoxColumn";
            this.mOPRestrictionDataGridViewTextBoxColumn.Width = 50;
            // 
            // budgetMarginDataGridViewTextBoxColumn
            // 
            this.budgetMarginDataGridViewTextBoxColumn.DataPropertyName = "BudgetMargin";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.budgetMarginDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.budgetMarginDataGridViewTextBoxColumn.HeaderText = "BudgetMargin";
            this.budgetMarginDataGridViewTextBoxColumn.Name = "budgetMarginDataGridViewTextBoxColumn";
            this.budgetMarginDataGridViewTextBoxColumn.Width = 50;
            // 
            // itemTypeCodeDataGridViewTextBoxColumn
            // 
            this.itemTypeCodeDataGridViewTextBoxColumn.DataPropertyName = "ItemTypeCode";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.itemTypeCodeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.itemTypeCodeDataGridViewTextBoxColumn.HeaderText = "ItemTypeCode";
            this.itemTypeCodeDataGridViewTextBoxColumn.Name = "itemTypeCodeDataGridViewTextBoxColumn";
            this.itemTypeCodeDataGridViewTextBoxColumn.Width = 50;
            // 
            // hideInLookupDataGridViewCheckBoxColumn
            // 
            this.hideInLookupDataGridViewCheckBoxColumn.DataPropertyName = "HideInLookup";
            this.hideInLookupDataGridViewCheckBoxColumn.HeaderText = "HideInLookup";
            this.hideInLookupDataGridViewCheckBoxColumn.Name = "hideInLookupDataGridViewCheckBoxColumn";
            this.hideInLookupDataGridViewCheckBoxColumn.Width = 50;
            // 
            // notActiveDataGridViewCheckBoxColumn
            // 
            this.notActiveDataGridViewCheckBoxColumn.DataPropertyName = "NotActive";
            this.notActiveDataGridViewCheckBoxColumn.HeaderText = "NotActive";
            this.notActiveDataGridViewCheckBoxColumn.Name = "notActiveDataGridViewCheckBoxColumn";
            this.notActiveDataGridViewCheckBoxColumn.Width = 50;
            // 
            // SubCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 392);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SubCategoryForm";
            this.Text = "SubCategoryForm";
            this.Load += new System.EventHandler(this.SubCategoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subCategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adminDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DRS.Extensions.DRS_DataGridView dataGridView1;
        private AdminDataSet adminDataSet;
        private System.Windows.Forms.BindingSource subCategoryBindingSource;
        private RBOS.AdminDataSetTableAdapters.SubCategoryTableAdapter subCategoryTableAdapter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn subCategoryIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vatRateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vatOwnerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditCategoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ageRestrictionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mOPRestrictionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn budgetMarginDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemTypeCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hideInLookupDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn notActiveDataGridViewCheckBoxColumn;


    }
}