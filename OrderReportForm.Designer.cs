namespace RBOS
{
    partial class OrderReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderReportForm));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.chkShowCost = new System.Windows.Forms.CheckBox();
            this.txtShowCost = new System.Windows.Forms.Label();
            this.lbSupplier = new System.Windows.Forms.Label();
            this.lbOrderID = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.ddOrderBy = new System.Windows.Forms.ComboBox();
            this.lbOrderBy = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(174, 135);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "[Cancel]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(12, 135);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "[Print]";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(93, 135);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 2;
            this.btnPreview.Text = "[Preview]";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // chkShowCost
            // 
            this.chkShowCost.AutoSize = true;
            this.chkShowCost.Checked = true;
            this.chkShowCost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowCost.Location = new System.Drawing.Point(95, 64);
            this.chkShowCost.Name = "chkShowCost";
            this.chkShowCost.Size = new System.Drawing.Size(15, 14);
            this.chkShowCost.TabIndex = 3;
            this.chkShowCost.UseVisualStyleBackColor = true;
            // 
            // txtShowCost
            // 
            this.txtShowCost.AutoSize = true;
            this.txtShowCost.Location = new System.Drawing.Point(12, 64);
            this.txtShowCost.Name = "txtShowCost";
            this.txtShowCost.Size = new System.Drawing.Size(64, 13);
            this.txtShowCost.TabIndex = 4;
            this.txtShowCost.Text = "[Show Cost]";
            // 
            // lbSupplier
            // 
            this.lbSupplier.AutoSize = true;
            this.lbSupplier.Location = new System.Drawing.Point(11, 41);
            this.lbSupplier.Name = "lbSupplier";
            this.lbSupplier.Size = new System.Drawing.Size(51, 13);
            this.lbSupplier.TabIndex = 5;
            this.lbSupplier.Text = "[Supplier]";
            // 
            // lbOrderID
            // 
            this.lbOrderID.AutoSize = true;
            this.lbOrderID.Location = new System.Drawing.Point(12, 15);
            this.lbOrderID.Name = "lbOrderID";
            this.lbOrderID.Size = new System.Drawing.Size(50, 13);
            this.lbOrderID.TabIndex = 6;
            this.lbOrderID.Text = "[OrderID]";
            // 
            // txtSupplier
            // 
            this.txtSupplier.Location = new System.Drawing.Point(95, 38);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.ReadOnly = true;
            this.txtSupplier.Size = new System.Drawing.Size(130, 20);
            this.txtSupplier.TabIndex = 7;
            // 
            // txtOrderID
            // 
            this.txtOrderID.Location = new System.Drawing.Point(95, 12);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.ReadOnly = true;
            this.txtOrderID.Size = new System.Drawing.Size(130, 20);
            this.txtOrderID.TabIndex = 8;
            // 
            // ddOrderBy
            // 
            this.ddOrderBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddOrderBy.FormattingEnabled = true;
            this.ddOrderBy.Items.AddRange(new object[] {
            "[Varenummer]",
            "[Beskrivelse]"});
            this.ddOrderBy.Location = new System.Drawing.Point(95, 84);
            this.ddOrderBy.Name = "ddOrderBy";
            this.ddOrderBy.Size = new System.Drawing.Size(130, 21);
            this.ddOrderBy.TabIndex = 9;
            // 
            // lbOrderBy
            // 
            this.lbOrderBy.AutoSize = true;
            this.lbOrderBy.Location = new System.Drawing.Point(12, 87);
            this.lbOrderBy.Name = "lbOrderBy";
            this.lbOrderBy.Size = new System.Drawing.Size(54, 13);
            this.lbOrderBy.TabIndex = 10;
            this.lbOrderBy.Text = "[Order By]";
            // 
            // OrderReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 170);
            this.Controls.Add(this.lbOrderBy);
            this.Controls.Add(this.ddOrderBy);
            this.Controls.Add(this.txtOrderID);
            this.Controls.Add(this.txtSupplier);
            this.Controls.Add(this.lbOrderID);
            this.Controls.Add(this.lbSupplier);
            this.Controls.Add(this.txtShowCost);
            this.Controls.Add(this.chkShowCost);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderReportForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrderReportForm_FormClosing);
            this.Load += new System.EventHandler(this.OrderReportForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.CheckBox chkShowCost;
        private System.Windows.Forms.Label txtShowCost;
        private System.Windows.Forms.Label lbSupplier;
        private System.Windows.Forms.Label lbOrderID;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.ComboBox ddOrderBy;
        private System.Windows.Forms.Label lbOrderBy;
    }
}