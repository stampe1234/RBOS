namespace RBOS
{
    partial class ImportItemsCSVFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportItemsCSVFrm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtFilepath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.lbFilepath = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkIncludeNewItems = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "CSV-filer (*.csv)|*.csv|Tekst-filer (*.txt)|*.txt|Alle filer|*.*";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // txtFilepath
            // 
            this.txtFilepath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilepath.Location = new System.Drawing.Point(12, 25);
            this.txtFilepath.Name = "txtFilepath";
            this.txtFilepath.Size = new System.Drawing.Size(192, 20);
            this.txtFilepath.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(210, 23);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(241, 23);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "[Import]";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lbFilepath
            // 
            this.lbFilepath.AutoSize = true;
            this.lbFilepath.Location = new System.Drawing.Point(12, 8);
            this.lbFilepath.Name = "lbFilepath";
            this.lbFilepath.Size = new System.Drawing.Size(113, 13);
            this.lbFilepath.TabIndex = 3;
            this.lbFilepath.Text = "[Vælg CSV fil til import]";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(241, 81);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "[Luk]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkIncludeNewItems
            // 
            this.chkIncludeNewItems.AutoSize = true;
            this.chkIncludeNewItems.Location = new System.Drawing.Point(12, 51);
            this.chkIncludeNewItems.Name = "chkIncludeNewItems";
            this.chkIncludeNewItems.Size = new System.Drawing.Size(115, 17);
            this.chkIncludeNewItems.TabIndex = 5;
            this.chkIncludeNewItems.Text = "[Medtag nye varer]";
            this.chkIncludeNewItems.UseVisualStyleBackColor = true;
            this.chkIncludeNewItems.CheckedChanged += new System.EventHandler(this.chkIncludeNewItems_CheckedChanged);
            // 
            // ImportItemsCSVFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 116);
            this.Controls.Add(this.chkIncludeNewItems);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbFilepath);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFilepath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ImportItemsCSVFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImportItemsCSV";
            this.Load += new System.EventHandler(this.ImportItemsCSV_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtFilepath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label lbFilepath;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkIncludeNewItems;
    }
}