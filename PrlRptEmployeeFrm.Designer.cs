namespace RBOS
{
    partial class PrlRptEmployeeFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrlRptEmployeeFrm));
            this.comboEmployee = new System.Windows.Forms.ComboBox();
            this.comboOrdering = new System.Windows.Forms.ComboBox();
            this.lbEmployee = new System.Windows.Forms.Label();
            this.lbOrdering = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.rptPrlEmployee = new RBOS.PrlRptEmployee();
            this.chkIncludeInactive = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // comboEmployee
            // 
            this.comboEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEmployee.FormattingEnabled = true;
            this.comboEmployee.Location = new System.Drawing.Point(123, 12);
            this.comboEmployee.Name = "comboEmployee";
            this.comboEmployee.Size = new System.Drawing.Size(156, 21);
            this.comboEmployee.TabIndex = 0;
            // 
            // comboOrdering
            // 
            this.comboOrdering.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOrdering.FormattingEnabled = true;
            this.comboOrdering.Location = new System.Drawing.Point(123, 39);
            this.comboOrdering.Name = "comboOrdering";
            this.comboOrdering.Size = new System.Drawing.Size(156, 21);
            this.comboOrdering.TabIndex = 1;
            // 
            // lbEmployee
            // 
            this.lbEmployee.AutoSize = true;
            this.lbEmployee.Location = new System.Drawing.Point(12, 15);
            this.lbEmployee.Name = "lbEmployee";
            this.lbEmployee.Size = new System.Drawing.Size(72, 13);
            this.lbEmployee.TabIndex = 2;
            this.lbEmployee.Text = "[Medarbejder]";
            // 
            // lbOrdering
            // 
            this.lbOrdering.AutoSize = true;
            this.lbOrdering.Location = new System.Drawing.Point(12, 42);
            this.lbOrdering.Name = "lbOrdering";
            this.lbOrdering.Size = new System.Drawing.Size(92, 13);
            this.lbOrdering.TabIndex = 3;
            this.lbOrdering.Text = "[Sorter listen efter]";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(42, 102);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "[Print]";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(123, 102);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 5;
            this.btnPreview.Text = "[Preview]";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(204, 102);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkIncludeInactive
            // 
            this.chkIncludeInactive.AutoSize = true;
            this.chkIncludeInactive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIncludeInactive.Location = new System.Drawing.Point(171, 72);
            this.chkIncludeInactive.Name = "chkIncludeInactive";
            this.chkIncludeInactive.Size = new System.Drawing.Size(110, 17);
            this.chkIncludeInactive.TabIndex = 7;
            this.chkIncludeInactive.Text = "[Inkludér inaktive]";
            this.chkIncludeInactive.UseVisualStyleBackColor = true;
            // 
            // PrlRptEmployeeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 137);
            this.Controls.Add(this.chkIncludeInactive);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lbOrdering);
            this.Controls.Add(this.lbEmployee);
            this.Controls.Add(this.comboOrdering);
            this.Controls.Add(this.comboEmployee);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PrlRptEmployeeFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrlRptEmployee";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboEmployee;
        private System.Windows.Forms.ComboBox comboOrdering;
        private System.Windows.Forms.Label lbEmployee;
        private System.Windows.Forms.Label lbOrdering;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnClose;
        private PrlRptEmployee rptPrlEmployee;
        private System.Windows.Forms.CheckBox chkIncludeInactive;
    }
}