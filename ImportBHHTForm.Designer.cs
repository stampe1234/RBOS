namespace RBOS
{
    partial class ImportBHHTForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportBHHTForm));
            this.btnImport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbInvAdjustT = new System.Windows.Forms.Label();
            this.lbInvAdjustR = new System.Windows.Forms.Label();
            this.lbInvAdjust = new System.Windows.Forms.Label();
            this.lbOrder = new System.Windows.Forms.Label();
            this.lbInvAdjustA = new System.Windows.Forms.Label();
            this.lbInvAdjustW = new System.Windows.Forms.Label();
            this.lbInvCount = new System.Windows.Forms.Label();
            this.lbImportData = new System.Windows.Forms.Label();
            this.lbImportedCount = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtInvAdjustA = new System.Windows.Forms.TextBox();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.txtInvAdjustW = new System.Windows.Forms.TextBox();
            this.txtInvAdjustR = new System.Windows.Forms.TextBox();
            this.txtInvAdjustT = new System.Windows.Forms.TextBox();
            this.txtInvCount = new System.Windows.Forms.TextBox();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnInvCount = new System.Windows.Forms.Button();
            this.btnInvAdjustA = new System.Windows.Forms.Button();
            this.btnInvAdjustR = new System.Windows.Forms.Button();
            this.btnInvAdjustT = new System.Windows.Forms.Button();
            this.btnInvAdjustW = new System.Windows.Forms.Button();
            this.txtInvCountOpen = new System.Windows.Forms.TextBox();
            this.txtInvAdjustTOpen = new System.Windows.Forms.TextBox();
            this.txtInvAdjustROpen = new System.Windows.Forms.TextBox();
            this.txtInvAdjustWOpen = new System.Windows.Forms.TextBox();
            this.txtOrderOpen = new System.Windows.Forms.TextBox();
            this.txtInvAdjustAOpen = new System.Windows.Forms.TextBox();
            this.txtOpen = new System.Windows.Forms.Label();
            this.txtShelfLabels = new System.Windows.Forms.TextBox();
            this.lbShelfLabels = new System.Windows.Forms.Label();
            this.btnPrintShelfLabels = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(247, 269);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "[Import]";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(328, 269);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbInvAdjustT
            // 
            this.lbInvAdjustT.AutoSize = true;
            this.lbInvAdjustT.Location = new System.Drawing.Point(25, 178);
            this.lbInvAdjustT.Name = "lbInvAdjustT";
            this.lbInvAdjustT.Size = new System.Drawing.Size(52, 13);
            this.lbInvAdjustT.TabIndex = 2;
            this.lbInvAdjustT.Text = "[Transfer]";
            // 
            // lbInvAdjustR
            // 
            this.lbInvAdjustR.AutoSize = true;
            this.lbInvAdjustR.Location = new System.Drawing.Point(25, 152);
            this.lbInvAdjustR.Name = "lbInvAdjustR";
            this.lbInvAdjustR.Size = new System.Drawing.Size(61, 13);
            this.lbInvAdjustR.TabIndex = 3;
            this.lbInvAdjustR.Text = "[Receiving]";
            // 
            // lbInvAdjust
            // 
            this.lbInvAdjust.AutoSize = true;
            this.lbInvAdjust.Location = new System.Drawing.Point(12, 102);
            this.lbInvAdjust.Name = "lbInvAdjust";
            this.lbInvAdjust.Size = new System.Drawing.Size(116, 13);
            this.lbInvAdjust.TabIndex = 4;
            this.lbInvAdjust.Text = "[Inventory adjustments]";
            // 
            // lbOrder
            // 
            this.lbOrder.AutoSize = true;
            this.lbOrder.Location = new System.Drawing.Point(12, 52);
            this.lbOrder.Name = "lbOrder";
            this.lbOrder.Size = new System.Drawing.Size(39, 13);
            this.lbOrder.TabIndex = 6;
            this.lbOrder.Text = "[Order]";
            // 
            // lbInvAdjustA
            // 
            this.lbInvAdjustA.AutoSize = true;
            this.lbInvAdjustA.Location = new System.Drawing.Point(25, 126);
            this.lbInvAdjustA.Name = "lbInvAdjustA";
            this.lbInvAdjustA.Size = new System.Drawing.Size(65, 13);
            this.lbInvAdjustA.TabIndex = 7;
            this.lbInvAdjustA.Text = "[Adjustment]";
            // 
            // lbInvAdjustW
            // 
            this.lbInvAdjustW.AutoSize = true;
            this.lbInvAdjustW.Location = new System.Drawing.Point(25, 204);
            this.lbInvAdjustW.Name = "lbInvAdjustW";
            this.lbInvAdjustW.Size = new System.Drawing.Size(44, 13);
            this.lbInvAdjustW.TabIndex = 8;
            this.lbInvAdjustW.Text = "[Waste]";
            // 
            // lbInvCount
            // 
            this.lbInvCount.AutoSize = true;
            this.lbInvCount.Location = new System.Drawing.Point(12, 78);
            this.lbInvCount.Name = "lbInvCount";
            this.lbInvCount.Size = new System.Drawing.Size(88, 13);
            this.lbInvCount.TabIndex = 13;
            this.lbInvCount.Text = "[Inventory Count]";
            // 
            // lbImportData
            // 
            this.lbImportData.AutoSize = true;
            this.lbImportData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbImportData.Location = new System.Drawing.Point(12, 18);
            this.lbImportData.Name = "lbImportData";
            this.lbImportData.Size = new System.Drawing.Size(95, 13);
            this.lbImportData.TabIndex = 15;
            this.lbImportData.Text = "[Imported Data]";
            // 
            // lbImportedCount
            // 
            this.lbImportedCount.AutoSize = true;
            this.lbImportedCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbImportedCount.Location = new System.Drawing.Point(155, 18);
            this.lbImportedCount.Name = "lbImportedCount";
            this.lbImportedCount.Size = new System.Drawing.Size(48, 13);
            this.lbImportedCount.TabIndex = 16;
            this.lbImportedCount.Text = "[Count]";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 304);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(413, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(38, 17);
            this.status.Text = "status";
            // 
            // txtInvAdjustA
            // 
            this.txtInvAdjustA.Location = new System.Drawing.Point(158, 123);
            this.txtInvAdjustA.Name = "txtInvAdjustA";
            this.txtInvAdjustA.ReadOnly = true;
            this.txtInvAdjustA.Size = new System.Drawing.Size(40, 20);
            this.txtInvAdjustA.TabIndex = 18;
            this.txtInvAdjustA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtOrder
            // 
            this.txtOrder.Location = new System.Drawing.Point(158, 49);
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.ReadOnly = true;
            this.txtOrder.Size = new System.Drawing.Size(40, 20);
            this.txtOrder.TabIndex = 19;
            this.txtOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtInvAdjustW
            // 
            this.txtInvAdjustW.Location = new System.Drawing.Point(158, 201);
            this.txtInvAdjustW.Name = "txtInvAdjustW";
            this.txtInvAdjustW.ReadOnly = true;
            this.txtInvAdjustW.Size = new System.Drawing.Size(40, 20);
            this.txtInvAdjustW.TabIndex = 20;
            this.txtInvAdjustW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtInvAdjustR
            // 
            this.txtInvAdjustR.Location = new System.Drawing.Point(158, 149);
            this.txtInvAdjustR.Name = "txtInvAdjustR";
            this.txtInvAdjustR.ReadOnly = true;
            this.txtInvAdjustR.Size = new System.Drawing.Size(40, 20);
            this.txtInvAdjustR.TabIndex = 21;
            this.txtInvAdjustR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtInvAdjustT
            // 
            this.txtInvAdjustT.Location = new System.Drawing.Point(158, 175);
            this.txtInvAdjustT.Name = "txtInvAdjustT";
            this.txtInvAdjustT.ReadOnly = true;
            this.txtInvAdjustT.Size = new System.Drawing.Size(40, 20);
            this.txtInvAdjustT.TabIndex = 22;
            this.txtInvAdjustT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtInvCount
            // 
            this.txtInvCount.Location = new System.Drawing.Point(158, 75);
            this.txtInvCount.Name = "txtInvCount";
            this.txtInvCount.ReadOnly = true;
            this.txtInvCount.Size = new System.Drawing.Size(40, 20);
            this.txtInvCount.TabIndex = 23;
            this.txtInvCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnOrder
            // 
            this.btnOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrder.Location = new System.Drawing.Point(296, 47);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(107, 23);
            this.btnOrder.TabIndex = 24;
            this.btnOrder.Text = "[Orders]";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnInvCount
            // 
            this.btnInvCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvCount.Location = new System.Drawing.Point(296, 73);
            this.btnInvCount.Name = "btnInvCount";
            this.btnInvCount.Size = new System.Drawing.Size(107, 23);
            this.btnInvCount.TabIndex = 25;
            this.btnInvCount.Text = "[Inventory Count]";
            this.btnInvCount.UseVisualStyleBackColor = true;
            this.btnInvCount.Click += new System.EventHandler(this.btnInvCount_Click);
            // 
            // btnInvAdjustA
            // 
            this.btnInvAdjustA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvAdjustA.Location = new System.Drawing.Point(296, 121);
            this.btnInvAdjustA.Name = "btnInvAdjustA";
            this.btnInvAdjustA.Size = new System.Drawing.Size(107, 23);
            this.btnInvAdjustA.TabIndex = 26;
            this.btnInvAdjustA.Text = "[Adjustment]";
            this.btnInvAdjustA.UseVisualStyleBackColor = true;
            this.btnInvAdjustA.Click += new System.EventHandler(this.btnInvAdjustA_Click);
            // 
            // btnInvAdjustR
            // 
            this.btnInvAdjustR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvAdjustR.Location = new System.Drawing.Point(296, 147);
            this.btnInvAdjustR.Name = "btnInvAdjustR";
            this.btnInvAdjustR.Size = new System.Drawing.Size(107, 23);
            this.btnInvAdjustR.TabIndex = 27;
            this.btnInvAdjustR.Text = "[Receiving]";
            this.btnInvAdjustR.UseVisualStyleBackColor = true;
            this.btnInvAdjustR.Click += new System.EventHandler(this.btnInvAdjustR_Click);
            // 
            // btnInvAdjustT
            // 
            this.btnInvAdjustT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvAdjustT.Location = new System.Drawing.Point(296, 173);
            this.btnInvAdjustT.Name = "btnInvAdjustT";
            this.btnInvAdjustT.Size = new System.Drawing.Size(107, 23);
            this.btnInvAdjustT.TabIndex = 28;
            this.btnInvAdjustT.Text = "[Transfer]";
            this.btnInvAdjustT.UseVisualStyleBackColor = true;
            this.btnInvAdjustT.Click += new System.EventHandler(this.btnInvAdjustT_Click);
            // 
            // btnInvAdjustW
            // 
            this.btnInvAdjustW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvAdjustW.Location = new System.Drawing.Point(296, 199);
            this.btnInvAdjustW.Name = "btnInvAdjustW";
            this.btnInvAdjustW.Size = new System.Drawing.Size(107, 23);
            this.btnInvAdjustW.TabIndex = 29;
            this.btnInvAdjustW.Text = "[Waste]";
            this.btnInvAdjustW.UseVisualStyleBackColor = true;
            this.btnInvAdjustW.Click += new System.EventHandler(this.btnInvAdjustW_Click);
            // 
            // txtInvCountOpen
            // 
            this.txtInvCountOpen.Location = new System.Drawing.Point(230, 75);
            this.txtInvCountOpen.Name = "txtInvCountOpen";
            this.txtInvCountOpen.ReadOnly = true;
            this.txtInvCountOpen.Size = new System.Drawing.Size(40, 20);
            this.txtInvCountOpen.TabIndex = 35;
            this.txtInvCountOpen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtInvAdjustTOpen
            // 
            this.txtInvAdjustTOpen.Location = new System.Drawing.Point(230, 175);
            this.txtInvAdjustTOpen.Name = "txtInvAdjustTOpen";
            this.txtInvAdjustTOpen.ReadOnly = true;
            this.txtInvAdjustTOpen.Size = new System.Drawing.Size(40, 20);
            this.txtInvAdjustTOpen.TabIndex = 34;
            this.txtInvAdjustTOpen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtInvAdjustROpen
            // 
            this.txtInvAdjustROpen.Location = new System.Drawing.Point(230, 149);
            this.txtInvAdjustROpen.Name = "txtInvAdjustROpen";
            this.txtInvAdjustROpen.ReadOnly = true;
            this.txtInvAdjustROpen.Size = new System.Drawing.Size(40, 20);
            this.txtInvAdjustROpen.TabIndex = 33;
            this.txtInvAdjustROpen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtInvAdjustWOpen
            // 
            this.txtInvAdjustWOpen.Location = new System.Drawing.Point(230, 201);
            this.txtInvAdjustWOpen.Name = "txtInvAdjustWOpen";
            this.txtInvAdjustWOpen.ReadOnly = true;
            this.txtInvAdjustWOpen.Size = new System.Drawing.Size(40, 20);
            this.txtInvAdjustWOpen.TabIndex = 32;
            this.txtInvAdjustWOpen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtOrderOpen
            // 
            this.txtOrderOpen.Location = new System.Drawing.Point(230, 49);
            this.txtOrderOpen.Name = "txtOrderOpen";
            this.txtOrderOpen.ReadOnly = true;
            this.txtOrderOpen.Size = new System.Drawing.Size(40, 20);
            this.txtOrderOpen.TabIndex = 31;
            this.txtOrderOpen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtInvAdjustAOpen
            // 
            this.txtInvAdjustAOpen.Location = new System.Drawing.Point(230, 123);
            this.txtInvAdjustAOpen.Name = "txtInvAdjustAOpen";
            this.txtInvAdjustAOpen.ReadOnly = true;
            this.txtInvAdjustAOpen.Size = new System.Drawing.Size(40, 20);
            this.txtInvAdjustAOpen.TabIndex = 30;
            this.txtInvAdjustAOpen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtOpen
            // 
            this.txtOpen.AutoSize = true;
            this.txtOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOpen.Location = new System.Drawing.Point(227, 18);
            this.txtOpen.Name = "txtOpen";
            this.txtOpen.Size = new System.Drawing.Size(45, 13);
            this.txtOpen.TabIndex = 36;
            this.txtOpen.Text = "[Open]";
            // 
            // txtShelfLabels
            // 
            this.txtShelfLabels.Location = new System.Drawing.Point(158, 227);
            this.txtShelfLabels.Name = "txtShelfLabels";
            this.txtShelfLabels.ReadOnly = true;
            this.txtShelfLabels.Size = new System.Drawing.Size(40, 20);
            this.txtShelfLabels.TabIndex = 38;
            this.txtShelfLabels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbShelfLabels
            // 
            this.lbShelfLabels.AutoSize = true;
            this.lbShelfLabels.Location = new System.Drawing.Point(12, 230);
            this.lbShelfLabels.Name = "lbShelfLabels";
            this.lbShelfLabels.Size = new System.Drawing.Size(69, 13);
            this.lbShelfLabels.TabIndex = 37;
            this.lbShelfLabels.Text = "[Shelf Labes]";
            // 
            // btnPrintShelfLabels
            // 
            this.btnPrintShelfLabels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintShelfLabels.Location = new System.Drawing.Point(296, 225);
            this.btnPrintShelfLabels.Name = "btnPrintShelfLabels";
            this.btnPrintShelfLabels.Size = new System.Drawing.Size(107, 23);
            this.btnPrintShelfLabels.TabIndex = 39;
            this.btnPrintShelfLabels.Text = "[Print Shelf Lables]";
            this.btnPrintShelfLabels.UseVisualStyleBackColor = true;
            this.btnPrintShelfLabels.Click += new System.EventHandler(this.btnPrintShelfLabels_Click);
            // 
            // ImportBHHTForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 326);
            this.Controls.Add(this.btnPrintShelfLabels);
            this.Controls.Add(this.txtShelfLabels);
            this.Controls.Add(this.lbShelfLabels);
            this.Controls.Add(this.txtOpen);
            this.Controls.Add(this.txtInvCountOpen);
            this.Controls.Add(this.txtInvAdjustTOpen);
            this.Controls.Add(this.txtInvAdjustROpen);
            this.Controls.Add(this.txtInvAdjustWOpen);
            this.Controls.Add(this.txtOrderOpen);
            this.Controls.Add(this.txtInvAdjustAOpen);
            this.Controls.Add(this.btnInvAdjustW);
            this.Controls.Add(this.btnInvAdjustT);
            this.Controls.Add(this.btnInvAdjustR);
            this.Controls.Add(this.btnInvAdjustA);
            this.Controls.Add(this.btnInvCount);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.txtInvCount);
            this.Controls.Add(this.txtInvAdjustT);
            this.Controls.Add(this.txtInvAdjustR);
            this.Controls.Add(this.txtInvAdjustW);
            this.Controls.Add(this.txtOrder);
            this.Controls.Add(this.txtInvAdjustA);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lbImportedCount);
            this.Controls.Add(this.lbImportData);
            this.Controls.Add(this.lbInvCount);
            this.Controls.Add(this.lbInvAdjustW);
            this.Controls.Add(this.lbInvAdjustA);
            this.Controls.Add(this.lbOrder);
            this.Controls.Add(this.lbInvAdjust);
            this.Controls.Add(this.lbInvAdjustR);
            this.Controls.Add(this.lbInvAdjustT);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnImport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ImportBHHTForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImportBHHTForm";
            this.Load += new System.EventHandler(this.ImportBHHTForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbInvAdjustT;
        private System.Windows.Forms.Label lbInvAdjustR;
        private System.Windows.Forms.Label lbInvAdjust;
        private System.Windows.Forms.Label lbOrder;
        private System.Windows.Forms.Label lbInvAdjustA;
        private System.Windows.Forms.Label lbInvAdjustW;
        private System.Windows.Forms.Label lbInvCount;
        private System.Windows.Forms.Label lbImportData;
        private System.Windows.Forms.Label lbImportedCount;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.TextBox txtInvAdjustA;
        private System.Windows.Forms.TextBox txtOrder;
        private System.Windows.Forms.TextBox txtInvAdjustW;
        private System.Windows.Forms.TextBox txtInvAdjustR;
        private System.Windows.Forms.TextBox txtInvAdjustT;
        private System.Windows.Forms.TextBox txtInvCount;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnInvCount;
        private System.Windows.Forms.Button btnInvAdjustA;
        private System.Windows.Forms.Button btnInvAdjustR;
        private System.Windows.Forms.Button btnInvAdjustT;
        private System.Windows.Forms.Button btnInvAdjustW;
        private System.Windows.Forms.TextBox txtInvCountOpen;
        private System.Windows.Forms.TextBox txtInvAdjustTOpen;
        private System.Windows.Forms.TextBox txtInvAdjustROpen;
        private System.Windows.Forms.TextBox txtInvAdjustWOpen;
        private System.Windows.Forms.TextBox txtOrderOpen;
        private System.Windows.Forms.TextBox txtInvAdjustAOpen;
        private System.Windows.Forms.Label txtOpen;
        private System.Windows.Forms.TextBox txtShelfLabels;
        private System.Windows.Forms.Label lbShelfLabels;
        private System.Windows.Forms.Button btnPrintShelfLabels;
    }
}