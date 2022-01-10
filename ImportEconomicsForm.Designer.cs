namespace RBOS
{
    partial class ImportEconomicsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportEconomicsForm));
            this.btnImportAll = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.dtImportSince = new System.Windows.Forms.DateTimePicker();
            this.lbImportAll = new System.Windows.Forms.Label();
            this.lbImportSince = new System.Windows.Forms.Label();
            this.btnImportSince = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnImportAll
            // 
            this.btnImportAll.Location = new System.Drawing.Point(227, 45);
            this.btnImportAll.Name = "btnImportAll";
            this.btnImportAll.Size = new System.Drawing.Size(75, 23);
            this.btnImportAll.TabIndex = 4;
            this.btnImportAll.Text = "[Start]";
            this.btnImportAll.UseVisualStyleBackColor = true;
            this.btnImportAll.Click += new System.EventHandler(this.CommonImportClickHandler);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(227, 108);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(12, 77);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(290, 28);
            this.lbStatus.TabIndex = 5;
            // 
            // dtImportSince
            // 
            this.dtImportSince.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtImportSince.Location = new System.Drawing.Point(127, 18);
            this.dtImportSince.Name = "dtImportSince";
            this.dtImportSince.Size = new System.Drawing.Size(94, 20);
            this.dtImportSince.TabIndex = 6;
            // 
            // lbImportAll
            // 
            this.lbImportAll.AutoSize = true;
            this.lbImportAll.Location = new System.Drawing.Point(12, 50);
            this.lbImportAll.Name = "lbImportAll";
            this.lbImportAll.Size = new System.Drawing.Size(164, 13);
            this.lbImportAll.TabIndex = 7;
            this.lbImportAll.Text = "[Importér alle data (tager lang tid)]";
            // 
            // lbImportSince
            // 
            this.lbImportSince.AutoSize = true;
            this.lbImportSince.Location = new System.Drawing.Point(12, 21);
            this.lbImportSince.Name = "lbImportSince";
            this.lbImportSince.Size = new System.Drawing.Size(103, 13);
            this.lbImportSince.TabIndex = 8;
            this.lbImportSince.Text = "[Importér data siden]";
            // 
            // btnImportSince
            // 
            this.btnImportSince.Location = new System.Drawing.Point(227, 16);
            this.btnImportSince.Name = "btnImportSince";
            this.btnImportSince.Size = new System.Drawing.Size(75, 23);
            this.btnImportSince.TabIndex = 9;
            this.btnImportSince.Text = "[Start]";
            this.btnImportSince.UseVisualStyleBackColor = true;
            this.btnImportSince.Click += new System.EventHandler(this.CommonImportClickHandler);
            // 
            // ImportEconomicsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 143);
            this.Controls.Add(this.btnImportSince);
            this.Controls.Add(this.lbImportSince);
            this.Controls.Add(this.lbImportAll);
            this.Controls.Add(this.dtImportSince);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.btnImportAll);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ImportEconomicsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImportEconomics";
            this.Load += new System.EventHandler(this.ImportEconomicsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImportAll;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.DateTimePicker dtImportSince;
        private System.Windows.Forms.Label lbImportAll;
        private System.Windows.Forms.Label lbImportSince;
        private System.Windows.Forms.Button btnImportSince;
    }
}