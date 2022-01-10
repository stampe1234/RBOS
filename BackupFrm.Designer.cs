namespace RBOS
{
    partial class BackupFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupFrm));
            this.groupLocal = new System.Windows.Forms.GroupBox();
            this.chkLocal = new System.Windows.Forms.CheckBox();
            this.chkLocalZip = new System.Windows.Forms.CheckBox();
            this.chkLocalAuto = new System.Windows.Forms.CheckBox();
            this.lbLocalDir = new System.Windows.Forms.Label();
            this.txtLocalDir = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.groupNetwork = new System.Windows.Forms.GroupBox();
            this.chkNetwork = new System.Windows.Forms.CheckBox();
            this.chkNetworkZip = new System.Windows.Forms.CheckBox();
            this.chkNetworkAuto = new System.Windows.Forms.CheckBox();
            this.lbNetworkDir = new System.Windows.Forms.Label();
            this.txtNetworkDir = new System.Windows.Forms.TextBox();
            this.groupExternal = new System.Windows.Forms.GroupBox();
            this.txtLastExternalBackup = new System.Windows.Forms.TextBox();
            this.lbLastExternalBackup = new System.Windows.Forms.Label();
            this.comboExternalBackupInterval = new System.Windows.Forms.ComboBox();
            this.bindingLookupBackupInterval = new System.Windows.Forms.BindingSource(this.components);
            this.adminDataSet = new RBOS.AdminDataSet();
            this.lbExternalBackupInterval = new System.Windows.Forms.Label();
            this.chkExternal = new System.Windows.Forms.CheckBox();
            this.btnExternalDir = new System.Windows.Forms.Button();
            this.chkExternalZip = new System.Windows.Forms.CheckBox();
            this.lbExternalDir = new System.Windows.Forms.Label();
            this.txtExternalDir = new System.Windows.Forms.TextBox();
            this.chkCompressDB = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.folders = new System.Windows.Forms.FolderBrowserDialog();
            this.adapterLookupBackupInterval = new RBOS.AdminDataSetTableAdapters.LookupBackupIntervalTableAdapter();
            this.groupLocal.SuspendLayout();
            this.groupNetwork.SuspendLayout();
            this.groupExternal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupBackupInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adminDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // groupLocal
            // 
            this.groupLocal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupLocal.Controls.Add(this.chkLocal);
            this.groupLocal.Controls.Add(this.chkLocalZip);
            this.groupLocal.Controls.Add(this.chkLocalAuto);
            this.groupLocal.Controls.Add(this.lbLocalDir);
            this.groupLocal.Controls.Add(this.txtLocalDir);
            this.groupLocal.Location = new System.Drawing.Point(12, 12);
            this.groupLocal.Name = "groupLocal";
            this.groupLocal.Size = new System.Drawing.Size(363, 72);
            this.groupLocal.TabIndex = 0;
            this.groupLocal.TabStop = false;
            this.groupLocal.Text = "     ";
            // 
            // chkLocal
            // 
            this.chkLocal.AutoSize = true;
            this.chkLocal.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkLocal.Location = new System.Drawing.Point(10, 0);
            this.chkLocal.Name = "chkLocal";
            this.chkLocal.Size = new System.Drawing.Size(58, 17);
            this.chkLocal.TabIndex = 4;
            this.chkLocal.Text = "[Lokal]";
            this.chkLocal.UseVisualStyleBackColor = true;
            this.chkLocal.CheckedChanged += new System.EventHandler(this.chkLocal_CheckedChanged);
            // 
            // chkLocalZip
            // 
            this.chkLocalZip.AutoSize = true;
            this.chkLocalZip.Enabled = false;
            this.chkLocalZip.Location = new System.Drawing.Point(205, 45);
            this.chkLocalZip.Name = "chkLocalZip";
            this.chkLocalZip.Size = new System.Drawing.Size(47, 17);
            this.chkLocalZip.TabIndex = 3;
            this.chkLocalZip.Text = "[Zip]";
            this.chkLocalZip.UseVisualStyleBackColor = true;
            // 
            // chkLocalAuto
            // 
            this.chkLocalAuto.AutoSize = true;
            this.chkLocalAuto.Location = new System.Drawing.Point(94, 45);
            this.chkLocalAuto.Name = "chkLocalAuto";
            this.chkLocalAuto.Size = new System.Drawing.Size(90, 17);
            this.chkLocalAuto.TabIndex = 2;
            this.chkLocalAuto.Text = "[Autobackup]";
            this.chkLocalAuto.UseVisualStyleBackColor = true;
            // 
            // lbLocalDir
            // 
            this.lbLocalDir.AutoSize = true;
            this.lbLocalDir.Location = new System.Drawing.Point(6, 22);
            this.lbLocalDir.Name = "lbLocalDir";
            this.lbLocalDir.Size = new System.Drawing.Size(57, 13);
            this.lbLocalDir.TabIndex = 1;
            this.lbLocalDir.Text = "[Placering]";
            // 
            // txtLocalDir
            // 
            this.txtLocalDir.Location = new System.Drawing.Point(94, 19);
            this.txtLocalDir.Name = "txtLocalDir";
            this.txtLocalDir.ReadOnly = true;
            this.txtLocalDir.Size = new System.Drawing.Size(224, 20);
            this.txtLocalDir.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(300, 300);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "[Luk]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackup.Location = new System.Drawing.Point(178, 300);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(116, 23);
            this.btnBackup.TabIndex = 2;
            this.btnBackup.Text = "[Udfør backup]";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // groupNetwork
            // 
            this.groupNetwork.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupNetwork.Controls.Add(this.chkNetwork);
            this.groupNetwork.Controls.Add(this.chkNetworkZip);
            this.groupNetwork.Controls.Add(this.chkNetworkAuto);
            this.groupNetwork.Controls.Add(this.lbNetworkDir);
            this.groupNetwork.Controls.Add(this.txtNetworkDir);
            this.groupNetwork.Location = new System.Drawing.Point(12, 90);
            this.groupNetwork.Name = "groupNetwork";
            this.groupNetwork.Size = new System.Drawing.Size(363, 72);
            this.groupNetwork.TabIndex = 1;
            this.groupNetwork.TabStop = false;
            this.groupNetwork.Text = "     ";
            // 
            // chkNetwork
            // 
            this.chkNetwork.AutoSize = true;
            this.chkNetwork.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkNetwork.Location = new System.Drawing.Point(10, 0);
            this.chkNetwork.Name = "chkNetwork";
            this.chkNetwork.Size = new System.Drawing.Size(74, 17);
            this.chkNetwork.TabIndex = 5;
            this.chkNetwork.Text = "[Netværk]";
            this.chkNetwork.UseVisualStyleBackColor = true;
            this.chkNetwork.CheckedChanged += new System.EventHandler(this.chkNetwork_CheckedChanged);
            // 
            // chkNetworkZip
            // 
            this.chkNetworkZip.AutoSize = true;
            this.chkNetworkZip.Enabled = false;
            this.chkNetworkZip.Location = new System.Drawing.Point(205, 45);
            this.chkNetworkZip.Name = "chkNetworkZip";
            this.chkNetworkZip.Size = new System.Drawing.Size(47, 17);
            this.chkNetworkZip.TabIndex = 7;
            this.chkNetworkZip.Text = "[Zip]";
            this.chkNetworkZip.UseVisualStyleBackColor = true;
            // 
            // chkNetworkAuto
            // 
            this.chkNetworkAuto.AutoSize = true;
            this.chkNetworkAuto.Location = new System.Drawing.Point(94, 45);
            this.chkNetworkAuto.Name = "chkNetworkAuto";
            this.chkNetworkAuto.Size = new System.Drawing.Size(90, 17);
            this.chkNetworkAuto.TabIndex = 6;
            this.chkNetworkAuto.Text = "[Autobackup]";
            this.chkNetworkAuto.UseVisualStyleBackColor = true;
            // 
            // lbNetworkDir
            // 
            this.lbNetworkDir.AutoSize = true;
            this.lbNetworkDir.Location = new System.Drawing.Point(6, 22);
            this.lbNetworkDir.Name = "lbNetworkDir";
            this.lbNetworkDir.Size = new System.Drawing.Size(57, 13);
            this.lbNetworkDir.TabIndex = 5;
            this.lbNetworkDir.Text = "[Placering]";
            // 
            // txtNetworkDir
            // 
            this.txtNetworkDir.Location = new System.Drawing.Point(94, 19);
            this.txtNetworkDir.Name = "txtNetworkDir";
            this.txtNetworkDir.ReadOnly = true;
            this.txtNetworkDir.Size = new System.Drawing.Size(224, 20);
            this.txtNetworkDir.TabIndex = 4;
            // 
            // groupExternal
            // 
            this.groupExternal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupExternal.Controls.Add(this.txtLastExternalBackup);
            this.groupExternal.Controls.Add(this.lbLastExternalBackup);
            this.groupExternal.Controls.Add(this.comboExternalBackupInterval);
            this.groupExternal.Controls.Add(this.lbExternalBackupInterval);
            this.groupExternal.Controls.Add(this.chkExternal);
            this.groupExternal.Controls.Add(this.btnExternalDir);
            this.groupExternal.Controls.Add(this.chkExternalZip);
            this.groupExternal.Controls.Add(this.lbExternalDir);
            this.groupExternal.Controls.Add(this.txtExternalDir);
            this.groupExternal.Location = new System.Drawing.Point(12, 168);
            this.groupExternal.Name = "groupExternal";
            this.groupExternal.Size = new System.Drawing.Size(363, 104);
            this.groupExternal.TabIndex = 1;
            this.groupExternal.TabStop = false;
            this.groupExternal.Text = "     ";
            // 
            // txtLastExternalBackup
            // 
            this.txtLastExternalBackup.Location = new System.Drawing.Point(145, 72);
            this.txtLastExternalBackup.Name = "txtLastExternalBackup";
            this.txtLastExternalBackup.ReadOnly = true;
            this.txtLastExternalBackup.Size = new System.Drawing.Size(74, 20);
            this.txtLastExternalBackup.TabIndex = 16;
            // 
            // lbLastExternalBackup
            // 
            this.lbLastExternalBackup.AutoSize = true;
            this.lbLastExternalBackup.Location = new System.Drawing.Point(6, 75);
            this.lbLastExternalBackup.Name = "lbLastExternalBackup";
            this.lbLastExternalBackup.Size = new System.Drawing.Size(117, 13);
            this.lbLastExternalBackup.TabIndex = 15;
            this.lbLastExternalBackup.Text = "[Sidste udførte backup]";
            // 
            // comboExternalBackupInterval
            // 
            this.comboExternalBackupInterval.DataSource = this.bindingLookupBackupInterval;
            this.comboExternalBackupInterval.DisplayMember = "Description";
            this.comboExternalBackupInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboExternalBackupInterval.FormattingEnabled = true;
            this.comboExternalBackupInterval.Location = new System.Drawing.Point(145, 45);
            this.comboExternalBackupInterval.Name = "comboExternalBackupInterval";
            this.comboExternalBackupInterval.Size = new System.Drawing.Size(107, 21);
            this.comboExternalBackupInterval.TabIndex = 14;
            this.comboExternalBackupInterval.ValueMember = "ID";
            // 
            // bindingLookupBackupInterval
            // 
            this.bindingLookupBackupInterval.DataMember = "LookupBackupInterval";
            this.bindingLookupBackupInterval.DataSource = this.adminDataSet;
            // 
            // adminDataSet
            // 
            this.adminDataSet.DataSetName = "AdminDataSet";
            this.adminDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lbExternalBackupInterval
            // 
            this.lbExternalBackupInterval.AutoSize = true;
            this.lbExternalBackupInterval.Location = new System.Drawing.Point(6, 48);
            this.lbExternalBackupInterval.Name = "lbExternalBackupInterval";
            this.lbExternalBackupInterval.Size = new System.Drawing.Size(111, 13);
            this.lbExternalBackupInterval.TabIndex = 13;
            this.lbExternalBackupInterval.Text = "[Mind mig om backup]";
            // 
            // chkExternal
            // 
            this.chkExternal.AutoSize = true;
            this.chkExternal.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkExternal.Location = new System.Drawing.Point(10, 0);
            this.chkExternal.Name = "chkExternal";
            this.chkExternal.Size = new System.Drawing.Size(68, 17);
            this.chkExternal.TabIndex = 9;
            this.chkExternal.Text = "[Ekstern]";
            this.chkExternal.UseVisualStyleBackColor = true;
            this.chkExternal.CheckedChanged += new System.EventHandler(this.chkExternal_CheckedChanged);
            // 
            // btnExternalDir
            // 
            this.btnExternalDir.Location = new System.Drawing.Point(324, 17);
            this.btnExternalDir.Name = "btnExternalDir";
            this.btnExternalDir.Size = new System.Drawing.Size(25, 23);
            this.btnExternalDir.TabIndex = 12;
            this.btnExternalDir.Text = "...";
            this.btnExternalDir.UseVisualStyleBackColor = true;
            this.btnExternalDir.Click += new System.EventHandler(this.btnExternalDir_Click);
            // 
            // chkExternalZip
            // 
            this.chkExternalZip.AutoSize = true;
            this.chkExternalZip.Enabled = false;
            this.chkExternalZip.Location = new System.Drawing.Point(305, 74);
            this.chkExternalZip.Name = "chkExternalZip";
            this.chkExternalZip.Size = new System.Drawing.Size(47, 17);
            this.chkExternalZip.TabIndex = 11;
            this.chkExternalZip.Text = "[Zip]";
            this.chkExternalZip.UseVisualStyleBackColor = true;
            // 
            // lbExternalDir
            // 
            this.lbExternalDir.AutoSize = true;
            this.lbExternalDir.Location = new System.Drawing.Point(6, 22);
            this.lbExternalDir.Name = "lbExternalDir";
            this.lbExternalDir.Size = new System.Drawing.Size(57, 13);
            this.lbExternalDir.TabIndex = 10;
            this.lbExternalDir.Text = "[Placering]";
            // 
            // txtExternalDir
            // 
            this.txtExternalDir.Location = new System.Drawing.Point(94, 19);
            this.txtExternalDir.Name = "txtExternalDir";
            this.txtExternalDir.Size = new System.Drawing.Size(224, 20);
            this.txtExternalDir.TabIndex = 9;
            this.txtExternalDir.Leave += new System.EventHandler(this.txtExternalDir_Leave);
            // 
            // chkCompressDB
            // 
            this.chkCompressDB.AutoSize = true;
            this.chkCompressDB.Enabled = false;
            this.chkCompressDB.Location = new System.Drawing.Point(22, 278);
            this.chkCompressDB.Name = "chkCompressDB";
            this.chkCompressDB.Size = new System.Drawing.Size(128, 17);
            this.chkCompressDB.TabIndex = 3;
            this.chkCompressDB.Text = "[Komprimér database]";
            this.chkCompressDB.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 332);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(387, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // adapterLookupBackupInterval
            // 
            this.adapterLookupBackupInterval.ClearBeforeFill = true;
            // 
            // BackupFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 354);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.chkCompressDB);
            this.Controls.Add(this.groupNetwork);
            this.Controls.Add(this.groupExternal);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupLocal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BackupFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BackupFrm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BackupFrm_FormClosing);
            this.Load += new System.EventHandler(this.BackupFrm_Load);
            this.groupLocal.ResumeLayout(false);
            this.groupLocal.PerformLayout();
            this.groupNetwork.ResumeLayout(false);
            this.groupNetwork.PerformLayout();
            this.groupExternal.ResumeLayout(false);
            this.groupExternal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupBackupInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adminDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupLocal;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.GroupBox groupNetwork;
        private System.Windows.Forms.GroupBox groupExternal;
        private System.Windows.Forms.CheckBox chkLocalZip;
        private System.Windows.Forms.CheckBox chkLocalAuto;
        private System.Windows.Forms.Label lbLocalDir;
        private System.Windows.Forms.TextBox txtLocalDir;
        private System.Windows.Forms.CheckBox chkNetworkZip;
        private System.Windows.Forms.CheckBox chkNetworkAuto;
        private System.Windows.Forms.Label lbNetworkDir;
        private System.Windows.Forms.TextBox txtNetworkDir;
        private System.Windows.Forms.Button btnExternalDir;
        private System.Windows.Forms.CheckBox chkExternalZip;
        private System.Windows.Forms.Label lbExternalDir;
        private System.Windows.Forms.TextBox txtExternalDir;
        private System.Windows.Forms.CheckBox chkCompressDB;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.CheckBox chkLocal;
        private System.Windows.Forms.CheckBox chkNetwork;
        private System.Windows.Forms.CheckBox chkExternal;
        private System.Windows.Forms.FolderBrowserDialog folders;
        private System.Windows.Forms.TextBox txtLastExternalBackup;
        private System.Windows.Forms.Label lbLastExternalBackup;
        private System.Windows.Forms.ComboBox comboExternalBackupInterval;
        private System.Windows.Forms.Label lbExternalBackupInterval;
        private AdminDataSet adminDataSet;
        private System.Windows.Forms.BindingSource bindingLookupBackupInterval;
        private RBOS.AdminDataSetTableAdapters.LookupBackupIntervalTableAdapter adapterLookupBackupInterval;
    }
}