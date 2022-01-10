namespace RBOS
{
    partial class WasteRegistrationRBAGetInitials
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WasteRegistrationRBAGetInitials));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lbEnterInitials = new System.Windows.Forms.Label();
            this.txtEnterInitials = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Location = new System.Drawing.Point(92, 49);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOk.Location = new System.Drawing.Point(11, 49);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lbEnterInitials
            // 
            this.lbEnterInitials.AutoSize = true;
            this.lbEnterInitials.Location = new System.Drawing.Point(12, 15);
            this.lbEnterInitials.Name = "lbEnterInitials";
            this.lbEnterInitials.Size = new System.Drawing.Size(100, 13);
            this.lbEnterInitials.TabIndex = 2;
            this.lbEnterInitials.Text = "Please enter initials:";
            // 
            // txtEnterInitials
            // 
            this.txtEnterInitials.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEnterInitials.Location = new System.Drawing.Point(132, 12);
            this.txtEnterInitials.Name = "txtEnterInitials";
            this.txtEnterInitials.Size = new System.Drawing.Size(34, 20);
            this.txtEnterInitials.TabIndex = 0;
            this.txtEnterInitials.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WasteRegistrationRBAGetInitials_KeyDown);
            // 
            // WasteRegistrationRBAGetInitials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(178, 84);
            this.Controls.Add(this.txtEnterInitials);
            this.Controls.Add(this.lbEnterInitials);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WasteRegistrationRBAGetInitials";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.WasteRegistrationRBAGetInitials_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WasteRegistrationRBAGetInitials_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lbEnterInitials;
        private System.Windows.Forms.TextBox txtEnterInitials;
    }
}