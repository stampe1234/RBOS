namespace RBOS
{
    partial class ManualUpdatesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManualUpdatesForm));
            this.chkMSM = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.chkGLSubcatRel = new System.Windows.Forms.CheckBox();
            this.chkBudget = new System.Windows.Forms.CheckBox();
            this.chkLL = new System.Windows.Forms.CheckBox();
            this.chkLLSubcatRel = new System.Windows.Forms.CheckBox();
            this.chkPrlEmployee = new System.Windows.Forms.CheckBox();
            this.chkPrlAgreement = new System.Windows.Forms.CheckBox();
            this.chkPrlHolidays = new System.Windows.Forms.CheckBox();
            this.chkPrlSalaryPeriods = new System.Windows.Forms.CheckBox();
            this.chkPrlClusterSites = new System.Windows.Forms.CheckBox();
            this.chkPrlAbsense = new System.Windows.Forms.CheckBox();
            this.chkRRDebitorData = new System.Windows.Forms.CheckBox();
            this.chkSubCatSetup = new System.Windows.Forms.CheckBox();
            this.chkEPD = new System.Windows.Forms.CheckBox();
            this.chkWPF = new System.Windows.Forms.CheckBox();
            this.chkDanskeSpil = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkMSM
            // 
            this.chkMSM.AutoSize = true;
            this.chkMSM.Location = new System.Drawing.Point(12, 14);
            this.chkMSM.Name = "chkMSM";
            this.chkMSM.Size = new System.Drawing.Size(146, 17);
            this.chkMSM.TabIndex = 0;
            this.chkMSM.Text = "[RPOS MSM config data]";
            this.chkMSM.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(268, 229);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "[Cancel]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(187, 229);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "[Ok]";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusText,
            this.ProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 260);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(355, 25);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusText
            // 
            this.StatusText.AutoSize = false;
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(150, 20);
            this.StatusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProgressBar
            // 
            this.ProgressBar.AutoSize = false;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(170, 19);
            this.ProgressBar.Step = 1;
            this.ProgressBar.Visible = false;
            // 
            // chkGLSubcatRel
            // 
            this.chkGLSubcatRel.AutoSize = true;
            this.chkGLSubcatRel.Location = new System.Drawing.Point(12, 37);
            this.chkGLSubcatRel.Name = "chkGLSubcatRel";
            this.chkGLSubcatRel.Size = new System.Drawing.Size(120, 17);
            this.chkGLSubcatRel.TabIndex = 4;
            this.chkGLSubcatRel.Text = "[GLSubcatRel data]";
            this.chkGLSubcatRel.UseVisualStyleBackColor = true;
            // 
            // chkBudget
            // 
            this.chkBudget.AutoSize = true;
            this.chkBudget.Location = new System.Drawing.Point(12, 60);
            this.chkBudget.Name = "chkBudget";
            this.chkBudget.Size = new System.Drawing.Size(104, 17);
            this.chkBudget.TabIndex = 5;
            this.chkBudget.Text = "[GLBudget data]";
            this.chkBudget.UseVisualStyleBackColor = true;
            // 
            // chkLL
            // 
            this.chkLL.AutoSize = true;
            this.chkLL.Location = new System.Drawing.Point(12, 106);
            this.chkLL.Name = "chkLL";
            this.chkLL.Size = new System.Drawing.Size(109, 17);
            this.chkLL.TabIndex = 6;
            this.chkLL.Text = "[Lekkerland data]";
            this.chkLL.UseVisualStyleBackColor = true;
            // 
            // chkLLSubcatRel
            // 
            this.chkLLSubcatRel.AutoSize = true;
            this.chkLLSubcatRel.Location = new System.Drawing.Point(12, 83);
            this.chkLLSubcatRel.Name = "chkLLSubcatRel";
            this.chkLLSubcatRel.Size = new System.Drawing.Size(118, 17);
            this.chkLLSubcatRel.TabIndex = 7;
            this.chkLLSubcatRel.Text = "[LLSubcatRel data]";
            this.chkLLSubcatRel.UseVisualStyleBackColor = true;
            // 
            // chkPrlEmployee
            // 
            this.chkPrlEmployee.AutoSize = true;
            this.chkPrlEmployee.Enabled = false;
            this.chkPrlEmployee.Location = new System.Drawing.Point(195, 14);
            this.chkPrlEmployee.Name = "chkPrlEmployee";
            this.chkPrlEmployee.Size = new System.Drawing.Size(138, 17);
            this.chkPrlEmployee.TabIndex = 8;
            this.chkPrlEmployee.Text = "[Løndata medarbejdere]";
            this.chkPrlEmployee.UseVisualStyleBackColor = true;
            // 
            // chkPrlAgreement
            // 
            this.chkPrlAgreement.AutoSize = true;
            this.chkPrlAgreement.Enabled = false;
            this.chkPrlAgreement.Location = new System.Drawing.Point(195, 37);
            this.chkPrlAgreement.Name = "chkPrlAgreement";
            this.chkPrlAgreement.Size = new System.Drawing.Size(140, 17);
            this.chkPrlAgreement.TabIndex = 9;
            this.chkPrlAgreement.Text = "[Løndata overenskomst]";
            this.chkPrlAgreement.UseVisualStyleBackColor = true;
            // 
            // chkPrlHolidays
            // 
            this.chkPrlHolidays.AutoSize = true;
            this.chkPrlHolidays.Enabled = false;
            this.chkPrlHolidays.Location = new System.Drawing.Point(195, 60);
            this.chkPrlHolidays.Name = "chkPrlHolidays";
            this.chkPrlHolidays.Size = new System.Drawing.Size(122, 17);
            this.chkPrlHolidays.TabIndex = 10;
            this.chkPrlHolidays.Text = "[Løndata helligdage]";
            this.chkPrlHolidays.UseVisualStyleBackColor = true;
            // 
            // chkPrlSalaryPeriods
            // 
            this.chkPrlSalaryPeriods.AutoSize = true;
            this.chkPrlSalaryPeriods.Enabled = false;
            this.chkPrlSalaryPeriods.Location = new System.Drawing.Point(195, 83);
            this.chkPrlSalaryPeriods.Name = "chkPrlSalaryPeriods";
            this.chkPrlSalaryPeriods.Size = new System.Drawing.Size(126, 17);
            this.chkPrlSalaryPeriods.TabIndex = 11;
            this.chkPrlSalaryPeriods.Text = "[Løndata lønperioder]";
            this.chkPrlSalaryPeriods.UseVisualStyleBackColor = true;
            // 
            // chkPrlClusterSites
            // 
            this.chkPrlClusterSites.AutoSize = true;
            this.chkPrlClusterSites.Enabled = false;
            this.chkPrlClusterSites.Location = new System.Drawing.Point(195, 106);
            this.chkPrlClusterSites.Name = "chkPrlClusterSites";
            this.chkPrlClusterSites.Size = new System.Drawing.Size(126, 17);
            this.chkPrlClusterSites.TabIndex = 12;
            this.chkPrlClusterSites.Text = "[Løndata clustersites]";
            this.chkPrlClusterSites.UseVisualStyleBackColor = true;
            // 
            // chkPrlAbsense
            // 
            this.chkPrlAbsense.AutoSize = true;
            this.chkPrlAbsense.Enabled = false;
            this.chkPrlAbsense.Location = new System.Drawing.Point(195, 129);
            this.chkPrlAbsense.Name = "chkPrlAbsense";
            this.chkPrlAbsense.Size = new System.Drawing.Size(105, 17);
            this.chkPrlAbsense.TabIndex = 13;
            this.chkPrlAbsense.Text = "[Løndata fravær]";
            this.chkPrlAbsense.UseVisualStyleBackColor = true;
            // 
            // chkRRDebitorData
            // 
            this.chkRRDebitorData.AutoSize = true;
            this.chkRRDebitorData.Enabled = false;
            this.chkRRDebitorData.Location = new System.Drawing.Point(12, 129);
            this.chkRRDebitorData.Name = "chkRRDebitorData";
            this.chkRRDebitorData.Size = new System.Drawing.Size(112, 17);
            this.chkRRDebitorData.TabIndex = 14;
            this.chkRRDebitorData.Text = "[Debitor stamdata]";
            this.chkRRDebitorData.UseVisualStyleBackColor = true;
            // 
            // chkSubCatSetup
            // 
            this.chkSubCatSetup.AutoSize = true;
            this.chkSubCatSetup.Location = new System.Drawing.Point(12, 152);
            this.chkSubCatSetup.Name = "chkSubCatSetup";
            this.chkSubCatSetup.Size = new System.Drawing.Size(140, 17);
            this.chkSubCatSetup.TabIndex = 15;
            this.chkSubCatSetup.Text = "[Varegruppe opsætning]";
            this.chkSubCatSetup.UseVisualStyleBackColor = true;
            // 
            // chkEPD
            // 
            this.chkEPD.AutoSize = true;
            this.chkEPD.Enabled = false;
            this.chkEPD.Location = new System.Drawing.Point(12, 175);
            this.chkEPD.Name = "chkEPD";
            this.chkEPD.Size = new System.Drawing.Size(69, 17);
            this.chkEPD.TabIndex = 16;
            this.chkEPD.Text = "[Salgstal]";
            this.chkEPD.UseVisualStyleBackColor = true;
            // 
            // chkWPF
            // 
            this.chkWPF.AutoSize = true;
            this.chkWPF.Enabled = false;
            this.chkWPF.Location = new System.Drawing.Point(12, 198);
            this.chkWPF.Name = "chkWPF";
            this.chkWPF.Size = new System.Drawing.Size(124, 17);
            this.chkWPF.TabIndex = 16;
            this.chkWPF.Text = "[Afskrivningskatalog]";
            this.chkWPF.UseVisualStyleBackColor = true;
            // 
            // chkDanskeSpil
            // 
            this.chkDanskeSpil.AutoSize = true;
            this.chkDanskeSpil.Enabled = false;
            this.chkDanskeSpil.Location = new System.Drawing.Point(195, 152);
            this.chkDanskeSpil.Name = "chkDanskeSpil";
            this.chkDanskeSpil.Size = new System.Drawing.Size(106, 17);
            this.chkDanskeSpil.TabIndex = 17;
            this.chkDanskeSpil.Text = "[Danske spil filer]";
            this.chkDanskeSpil.UseVisualStyleBackColor = true;
            // 
            // ManualUpdatesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 285);
            this.Controls.Add(this.chkDanskeSpil);
            this.Controls.Add(this.chkWPF);
            this.Controls.Add(this.chkEPD);
            this.Controls.Add(this.chkSubCatSetup);
            this.Controls.Add(this.chkRRDebitorData);
            this.Controls.Add(this.chkPrlAbsense);
            this.Controls.Add(this.chkPrlClusterSites);
            this.Controls.Add(this.chkPrlSalaryPeriods);
            this.Controls.Add(this.chkPrlHolidays);
            this.Controls.Add(this.chkPrlAgreement);
            this.Controls.Add(this.chkPrlEmployee);
            this.Controls.Add(this.chkLLSubcatRel);
            this.Controls.Add(this.chkLL);
            this.Controls.Add(this.chkBudget);
            this.Controls.Add(this.chkGLSubcatRel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chkMSM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManualUpdatesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManualUpdatesForm";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkMSM;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusText;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.CheckBox chkGLSubcatRel;
        private System.Windows.Forms.CheckBox chkBudget;
        private System.Windows.Forms.CheckBox chkLL;
        private System.Windows.Forms.CheckBox chkLLSubcatRel;
        private System.Windows.Forms.CheckBox chkPrlEmployee;
        private System.Windows.Forms.CheckBox chkPrlAgreement;
        private System.Windows.Forms.CheckBox chkPrlHolidays;
        private System.Windows.Forms.CheckBox chkPrlSalaryPeriods;
        private System.Windows.Forms.CheckBox chkPrlClusterSites;
        private System.Windows.Forms.CheckBox chkPrlAbsense;
        private System.Windows.Forms.CheckBox chkRRDebitorData;
        private System.Windows.Forms.CheckBox chkSubCatSetup;
        private System.Windows.Forms.CheckBox chkEPD;
        private System.Windows.Forms.CheckBox chkWPF;
        private System.Windows.Forms.CheckBox chkDanskeSpil;
    }
}