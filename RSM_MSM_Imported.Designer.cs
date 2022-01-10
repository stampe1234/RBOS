namespace RBOS
{
    partial class RSM_MSM_Imported
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
            this.comboDate = new System.Windows.Forms.DateTimePicker();
            this.grid = new System.Windows.Forms.DataGridView();
            this.count = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // comboDate
            // 
            this.comboDate.Location = new System.Drawing.Point(12, 12);
            this.comboDate.Name = "comboDate";
            this.comboDate.Size = new System.Drawing.Size(137, 20);
            this.comboDate.TabIndex = 0;
            this.comboDate.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(12, 38);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(648, 483);
            this.grid.TabIndex = 1;
            // 
            // count
            // 
            this.count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.count.AutoSize = true;
            this.count.Location = new System.Drawing.Point(625, 16);
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(13, 13);
            this.count.TabIndex = 2;
            this.count.Text = "0";
            // 
            // RSM_MSM_Imported
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 533);
            this.Controls.Add(this.count);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.comboDate);
            this.Name = "RSM_MSM_Imported";
            this.Text = "RSM_MSM_Imported";
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker comboDate;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label count;
    }
}