namespace RBOS
{
    partial class InvCountWorkForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvCountWorkForm));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.comboSubCategory = new System.Windows.Forms.ComboBox();
            this.lbSubCategory = new System.Windows.Forms.Label();
            this.txtSubCategoryDesc = new System.Windows.Forms.TextBox();
            this.txtCountDate = new System.Windows.Forms.TextBox();
            this.lbCountDate = new System.Windows.Forms.Label();
            this.txtTotalStockValue = new System.Windows.Forms.TextBox();
            this.txtTotalDiffValue = new System.Windows.Forms.TextBox();
            this.lbTotal = new System.Windows.Forms.Label();
            this.lbTotalDiff = new System.Windows.Forms.Label();
            this.bindingLookupItem = new System.Windows.Forms.BindingSource(this.components);
            this.dsItem = new RBOS.ItemDataSet();
            this.bindingInvCountWork = new System.Windows.Forms.BindingSource(this.components);
            this.adapterInvCountWork = new RBOS.ItemDataSetTableAdapters.InvCountWorkTableAdapter();
            this.adapterLookupItem = new RBOS.ItemDataSetTableAdapters.LookupItemTableAdapter();
            this.dataGridView1 = new DRS.Extensions.DRS_DataGridView();
            this.colItemName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colStartOnHand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalesPEJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOnHandCalc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCountTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCountBHHT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colManCorrect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCountDifference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiffValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingInvCountWork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(680, 567);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "[Cancel]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveClose.Location = new System.Drawing.Point(572, 567);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(102, 23);
            this.btnSaveClose.TabIndex = 3;
            this.btnSaveClose.Text = "[Save and Close]";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApprove.Location = new System.Drawing.Point(491, 567);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(75, 23);
            this.btnApprove.TabIndex = 2;
            this.btnApprove.Text = "[Approve]";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // comboSubCategory
            // 
            this.comboSubCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSubCategory.FormattingEnabled = true;
            this.comboSubCategory.Location = new System.Drawing.Point(105, 38);
            this.comboSubCategory.Name = "comboSubCategory";
            this.comboSubCategory.Size = new System.Drawing.Size(92, 21);
            this.comboSubCategory.TabIndex = 0;
            this.comboSubCategory.SelectedIndexChanged += new System.EventHandler(this.comboSubCategory_SelectedIndexChanged);
            // 
            // lbSubCategory
            // 
            this.lbSubCategory.AutoSize = true;
            this.lbSubCategory.Location = new System.Drawing.Point(12, 41);
            this.lbSubCategory.Name = "lbSubCategory";
            this.lbSubCategory.Size = new System.Drawing.Size(74, 13);
            this.lbSubCategory.TabIndex = 5;
            this.lbSubCategory.Text = "[SubCategory]";
            // 
            // txtSubCategoryDesc
            // 
            this.txtSubCategoryDesc.Location = new System.Drawing.Point(203, 38);
            this.txtSubCategoryDesc.Name = "txtSubCategoryDesc";
            this.txtSubCategoryDesc.ReadOnly = true;
            this.txtSubCategoryDesc.Size = new System.Drawing.Size(210, 20);
            this.txtSubCategoryDesc.TabIndex = 6;
            this.txtSubCategoryDesc.TabStop = false;
            // 
            // txtCountDate
            // 
            this.txtCountDate.Location = new System.Drawing.Point(105, 12);
            this.txtCountDate.Name = "txtCountDate";
            this.txtCountDate.ReadOnly = true;
            this.txtCountDate.Size = new System.Drawing.Size(76, 20);
            this.txtCountDate.TabIndex = 7;
            this.txtCountDate.TabStop = false;
            // 
            // lbCountDate
            // 
            this.lbCountDate.AutoSize = true;
            this.lbCountDate.Location = new System.Drawing.Point(12, 15);
            this.lbCountDate.Name = "lbCountDate";
            this.lbCountDate.Size = new System.Drawing.Size(67, 13);
            this.lbCountDate.TabIndex = 8;
            this.lbCountDate.Text = "[Count Date]";
            // 
            // txtTotalStockValue
            // 
            this.txtTotalStockValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalStockValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalStockValue.Location = new System.Drawing.Point(660, 12);
            this.txtTotalStockValue.Name = "txtTotalStockValue";
            this.txtTotalStockValue.ReadOnly = true;
            this.txtTotalStockValue.Size = new System.Drawing.Size(95, 20);
            this.txtTotalStockValue.TabIndex = 9;
            this.txtTotalStockValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalDiffValue
            // 
            this.txtTotalDiffValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalDiffValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDiffValue.Location = new System.Drawing.Point(660, 38);
            this.txtTotalDiffValue.Name = "txtTotalDiffValue";
            this.txtTotalDiffValue.ReadOnly = true;
            this.txtTotalDiffValue.Size = new System.Drawing.Size(95, 20);
            this.txtTotalDiffValue.TabIndex = 10;
            this.txtTotalDiffValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbTotal
            // 
            this.lbTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTotal.AutoSize = true;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.Location = new System.Drawing.Point(541, 15);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(95, 13);
            this.lbTotal.TabIndex = 11;
            this.lbTotal.Text = "[Total stock value]";
            // 
            // lbTotalDiff
            // 
            this.lbTotalDiff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTotalDiff.AutoSize = true;
            this.lbTotalDiff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalDiff.Location = new System.Drawing.Point(541, 41);
            this.lbTotalDiff.Name = "lbTotalDiff";
            this.lbTotalDiff.Size = new System.Drawing.Size(80, 13);
            this.lbTotalDiff.TabIndex = 12;
            this.lbTotalDiff.Text = "[Total diff. cost]";
            this.lbTotalDiff.Click += new System.EventHandler(this.label1_Click);
            // 
            // bindingLookupItem
            // 
            this.bindingLookupItem.DataMember = "LookupItem";
            this.bindingLookupItem.DataSource = this.dsItem;
            // 
            // dsItem
            // 
            this.dsItem.DataSetName = "ItemDataSet";
            this.dsItem.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingInvCountWork
            // 
            this.bindingInvCountWork.DataMember = "InvCountWork";
            this.bindingInvCountWork.DataSource = this.dsItem;
            this.bindingInvCountWork.Sort = "";
            // 
            // adapterInvCountWork
            // 
            this.adapterInvCountWork.ClearBeforeFill = true;
            // 
            // adapterLookupItem
            // 
            this.adapterLookupItem.ClearBeforeFill = true;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItemName,
            this.colStartOnHand,
            this.colSalesPEJ,
            this.colOnHandCalc,
            this.colCountTime,
            this.colCountBHHT,
            this.colManCorrect,
            this.colCountDifference,
            this.colCostPrice,
            this.colStockValue,
            this.colDiffValue});
            this.dataGridView1.DataSource = this.bindingInvCountWork;
            this.dataGridView1.Location = new System.Drawing.Point(12, 65);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(743, 496);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            // 
            // colItemName
            // 
            this.colItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colItemName.DataPropertyName = "ItemName";
            this.colItemName.DataSource = this.bindingLookupItem;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            this.colItemName.DefaultCellStyle = dataGridViewCellStyle2;
            this.colItemName.DisplayMember = "ItemName";
            this.colItemName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colItemName.HeaderText = "Varenavn";
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            this.colItemName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colItemName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colItemName.ValueMember = "ItemName";
            // 
            // colStartOnHand
            // 
            this.colStartOnHand.DataPropertyName = "StartOnHand";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.colStartOnHand.DefaultCellStyle = dataGridViewCellStyle3;
            this.colStartOnHand.HeaderText = "Beholdn. midnat";
            this.colStartOnHand.Name = "colStartOnHand";
            this.colStartOnHand.ReadOnly = true;
            this.colStartOnHand.Width = 50;
            // 
            // colSalesPEJ
            // 
            this.colSalesPEJ.DataPropertyName = "SalesPEJ";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            this.colSalesPEJ.DefaultCellStyle = dataGridViewCellStyle4;
            this.colSalesPEJ.HeaderText = "Salg POS";
            this.colSalesPEJ.Name = "colSalesPEJ";
            this.colSalesPEJ.ReadOnly = true;
            this.colSalesPEJ.Width = 50;
            // 
            // colOnHandCalc
            // 
            this.colOnHandCalc.DataPropertyName = "OnHandCalc";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            this.colOnHandCalc.DefaultCellStyle = dataGridViewCellStyle5;
            this.colOnHandCalc.HeaderText = "Beholdn.";
            this.colOnHandCalc.Name = "colOnHandCalc";
            this.colOnHandCalc.ReadOnly = true;
            this.colOnHandCalc.Width = 50;
            // 
            // colCountTime
            // 
            this.colCountTime.DataPropertyName = "CountTime";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Format = "t";
            dataGridViewCellStyle6.NullValue = null;
            this.colCountTime.DefaultCellStyle = dataGridViewCellStyle6;
            this.colCountTime.HeaderText = "Talt tidspkt.";
            this.colCountTime.Name = "colCountTime";
            this.colCountTime.ReadOnly = true;
            this.colCountTime.Width = 50;
            // 
            // colCountBHHT
            // 
            this.colCountBHHT.DataPropertyName = "CountBHHT";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            this.colCountBHHT.DefaultCellStyle = dataGridViewCellStyle7;
            this.colCountBHHT.HeaderText = "Optalt";
            this.colCountBHHT.Name = "colCountBHHT";
            this.colCountBHHT.ReadOnly = true;
            this.colCountBHHT.Width = 50;
            // 
            // colManCorrect
            // 
            this.colManCorrect.DataPropertyName = "ManCorrect";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = null;
            this.colManCorrect.DefaultCellStyle = dataGridViewCellStyle8;
            this.colManCorrect.HeaderText = "Rettet";
            this.colManCorrect.Name = "colManCorrect";
            this.colManCorrect.Width = 50;
            // 
            // colCountDifference
            // 
            this.colCountDifference.DataPropertyName = "CountDifference";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = null;
            this.colCountDifference.DefaultCellStyle = dataGridViewCellStyle9;
            this.colCountDifference.HeaderText = "Opt. diff.";
            this.colCountDifference.Name = "colCountDifference";
            this.colCountDifference.ReadOnly = true;
            this.colCountDifference.Width = 50;
            // 
            // colCostPrice
            // 
            this.colCostPrice.DataPropertyName = "CostPrice";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Format = "N3";
            dataGridViewCellStyle10.NullValue = null;
            this.colCostPrice.DefaultCellStyle = dataGridViewCellStyle10;
            this.colCostPrice.HeaderText = "Kostpris ex.moms";
            this.colCostPrice.Name = "colCostPrice";
            this.colCostPrice.ReadOnly = true;
            this.colCostPrice.Width = 60;
            // 
            // colStockValue
            // 
            this.colStockValue.DataPropertyName = "StockValue";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = null;
            this.colStockValue.DefaultCellStyle = dataGridViewCellStyle11;
            this.colStockValue.HeaderText = "Lager værdi";
            this.colStockValue.Name = "colStockValue";
            this.colStockValue.ReadOnly = true;
            this.colStockValue.Width = 78;
            // 
            // colDiffValue
            // 
            this.colDiffValue.DataPropertyName = "DiffValue";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = null;
            this.colDiffValue.DefaultCellStyle = dataGridViewCellStyle12;
            this.colDiffValue.HeaderText = "Diff. kost";
            this.colDiffValue.Name = "colDiffValue";
            this.colDiffValue.ReadOnly = true;
            this.colDiffValue.Width = 70;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "StartOnHand";
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn1.HeaderText = "StartOnHand";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SalesPEJ";
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn2.HeaderText = "SalesPEJ";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 50;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "OnHandCalc";
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewTextBoxColumn3.HeaderText = "OnHandCalc";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CountTime";
            dataGridViewCellStyle16.Format = "g";
            dataGridViewCellStyle16.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewTextBoxColumn4.HeaderText = "CountTime";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 50;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "CountBHHT";
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewTextBoxColumn5.HeaderText = "CountBHHT";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 50;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "CountDifference";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTextBoxColumn6.HeaderText = "CountDifference";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 50;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ManCorrect";
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewTextBoxColumn7.HeaderText = "ManCorrect";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 50;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "CostPrice";
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewTextBoxColumn8.HeaderText = "CostPrice";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 60;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "StockValue";
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewTextBoxColumn9.HeaderText = "StockValue";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 60;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "DiffValue";
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridViewTextBoxColumn10.HeaderText = "DiffValue";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 60;
            // 
            // InvCountWorkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 602);
            this.Controls.Add(this.lbTotalDiff);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.txtTotalDiffValue);
            this.Controls.Add(this.txtTotalStockValue);
            this.Controls.Add(this.lbCountDate);
            this.Controls.Add(this.txtCountDate);
            this.Controls.Add(this.txtSubCategoryDesc);
            this.Controls.Add(this.lbSubCategory);
            this.Controls.Add(this.comboSubCategory);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnSaveClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "InvCountWorkForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InvCountWorkForm";
            this.Load += new System.EventHandler(this.InvCountWorkForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingInvCountWork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DRS.Extensions.DRS_DataGridView dataGridView1;
        private ItemDataSet dsItem;
        private System.Windows.Forms.BindingSource bindingInvCountWork;
        private RBOS.ItemDataSetTableAdapters.InvCountWorkTableAdapter adapterInvCountWork;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveClose;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.ComboBox comboSubCategory;
        private System.Windows.Forms.Label lbSubCategory;
        private System.Windows.Forms.TextBox txtSubCategoryDesc;
        private System.Windows.Forms.TextBox txtCountDate;
        private System.Windows.Forms.Label lbCountDate;
        private System.Windows.Forms.BindingSource bindingLookupItem;
        private RBOS.ItemDataSetTableAdapters.LookupItemTableAdapter adapterLookupItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.TextBox txtTotalStockValue;
        private System.Windows.Forms.TextBox txtTotalDiffValue;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label lbTotalDiff;
        private System.Windows.Forms.DataGridViewComboBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartOnHand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalesPEJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOnHandCalc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCountTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCountBHHT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManCorrect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCountDifference;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiffValue;
    }
}