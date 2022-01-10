namespace RBOS
{
    partial class Readings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Readings));
            this.lbBookDate = new System.Windows.Forms.Label();
            this.bindingReadings = new System.Windows.Forms.BindingSource(this.components);
            this.dsEOD = new RBOS.EODDataSet();
            this.groupWaterReadings = new System.Windows.Forms.GroupBox();
            this.lbWashWaterUse = new System.Windows.Forms.Label();
            this.lbMainWaterUse = new System.Windows.Forms.Label();
            this.txtWashWaterUse = new System.Windows.Forms.TextBox();
            this.txtMainWaterUse = new System.Windows.Forms.TextBox();
            this.lbWashWaterReading = new System.Windows.Forms.Label();
            this.lbMainWaterReading = new System.Windows.Forms.Label();
            this.lbWashWaterPrimo = new System.Windows.Forms.Label();
            this.lbMainWaterPrimo = new System.Windows.Forms.Label();
            this.txtWashWaterReading = new System.Windows.Forms.TextBox();
            this.txtMainWaterReading = new System.Windows.Forms.TextBox();
            this.lbWashWater = new System.Windows.Forms.Label();
            this.lbMainWater = new System.Windows.Forms.Label();
            this.txtWashWaterPrimo = new System.Windows.Forms.TextBox();
            this.txtMainWaterPrimo = new System.Windows.Forms.TextBox();
            this.lbPrimoDate = new System.Windows.Forms.Label();
            this.groupPowerReadings = new System.Windows.Forms.GroupBox();
            this.lbKWUse = new System.Windows.Forms.Label();
            this.lbKW = new System.Windows.Forms.Label();
            this.txtKWPrimo = new System.Windows.Forms.TextBox();
            this.txtKWUse = new System.Windows.Forms.TextBox();
            this.txtKWReading = new System.Windows.Forms.TextBox();
            this.lbKWPrimo = new System.Windows.Forms.Label();
            this.lbKWReading = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.adapterReadings = new RBOS.EODDataSetTableAdapters.ReadingsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bindingReadings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEOD)).BeginInit();
            this.groupWaterReadings.SuspendLayout();
            this.groupPowerReadings.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbBookDate
            // 
            this.lbBookDate.AutoSize = true;
            this.lbBookDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingReadings, "RegDate", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            this.lbBookDate.Location = new System.Drawing.Point(205, 9);
            this.lbBookDate.Name = "lbBookDate";
            this.lbBookDate.Size = new System.Drawing.Size(64, 13);
            this.lbBookDate.TabIndex = 1;
            this.lbBookDate.Text = "<bookdate>";
            // 
            // bindingReadings
            // 
            this.bindingReadings.DataMember = "Readings";
            this.bindingReadings.DataSource = this.dsEOD;
            // 
            // dsEOD
            // 
            this.dsEOD.DataSetName = "EODDataSet";
            this.dsEOD.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupWaterReadings
            // 
            this.groupWaterReadings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupWaterReadings.Controls.Add(this.lbWashWaterUse);
            this.groupWaterReadings.Controls.Add(this.lbMainWaterUse);
            this.groupWaterReadings.Controls.Add(this.txtWashWaterUse);
            this.groupWaterReadings.Controls.Add(this.txtMainWaterUse);
            this.groupWaterReadings.Controls.Add(this.lbWashWaterReading);
            this.groupWaterReadings.Controls.Add(this.lbMainWaterReading);
            this.groupWaterReadings.Controls.Add(this.lbWashWaterPrimo);
            this.groupWaterReadings.Controls.Add(this.lbMainWaterPrimo);
            this.groupWaterReadings.Controls.Add(this.txtWashWaterReading);
            this.groupWaterReadings.Controls.Add(this.txtMainWaterReading);
            this.groupWaterReadings.Controls.Add(this.lbWashWater);
            this.groupWaterReadings.Controls.Add(this.lbMainWater);
            this.groupWaterReadings.Controls.Add(this.txtWashWaterPrimo);
            this.groupWaterReadings.Controls.Add(this.txtMainWaterPrimo);
            this.groupWaterReadings.Location = new System.Drawing.Point(12, 25);
            this.groupWaterReadings.Name = "groupWaterReadings";
            this.groupWaterReadings.Size = new System.Drawing.Size(339, 107);
            this.groupWaterReadings.TabIndex = 2;
            this.groupWaterReadings.TabStop = false;
            this.groupWaterReadings.Text = "[Vandaflæsning]";
            // 
            // lbWashWaterUse
            // 
            this.lbWashWaterUse.AutoSize = true;
            this.lbWashWaterUse.Location = new System.Drawing.Point(259, 55);
            this.lbWashWaterUse.Name = "lbWashWaterUse";
            this.lbWashWaterUse.Size = new System.Drawing.Size(49, 13);
            this.lbWashWaterUse.TabIndex = 7;
            this.lbWashWaterUse.Text = "[Forbrug]";
            // 
            // lbMainWaterUse
            // 
            this.lbMainWaterUse.AutoSize = true;
            this.lbMainWaterUse.Location = new System.Drawing.Point(259, 16);
            this.lbMainWaterUse.Name = "lbMainWaterUse";
            this.lbMainWaterUse.Size = new System.Drawing.Size(49, 13);
            this.lbMainWaterUse.TabIndex = 7;
            this.lbMainWaterUse.Text = "[Forbrug]";
            // 
            // txtWashWaterUse
            // 
            this.txtWashWaterUse.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingReadings, "WashUse", true));
            this.txtWashWaterUse.Location = new System.Drawing.Point(262, 72);
            this.txtWashWaterUse.Name = "txtWashWaterUse";
            this.txtWashWaterUse.ReadOnly = true;
            this.txtWashWaterUse.Size = new System.Drawing.Size(60, 20);
            this.txtWashWaterUse.TabIndex = 5;
            // 
            // txtMainWaterUse
            // 
            this.txtMainWaterUse.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingReadings, "MainWaterUse", true));
            this.txtMainWaterUse.Location = new System.Drawing.Point(262, 33);
            this.txtMainWaterUse.Name = "txtMainWaterUse";
            this.txtMainWaterUse.ReadOnly = true;
            this.txtMainWaterUse.Size = new System.Drawing.Size(60, 20);
            this.txtMainWaterUse.TabIndex = 2;
            // 
            // lbWashWaterReading
            // 
            this.lbWashWaterReading.AutoSize = true;
            this.lbWashWaterReading.Location = new System.Drawing.Point(193, 55);
            this.lbWashWaterReading.Name = "lbWashWaterReading";
            this.lbWashWaterReading.Size = new System.Drawing.Size(60, 13);
            this.lbWashWaterReading.TabIndex = 5;
            this.lbWashWaterReading.Text = "[Aflæsning]";
            // 
            // lbMainWaterReading
            // 
            this.lbMainWaterReading.AutoSize = true;
            this.lbMainWaterReading.Location = new System.Drawing.Point(193, 16);
            this.lbMainWaterReading.Name = "lbMainWaterReading";
            this.lbMainWaterReading.Size = new System.Drawing.Size(60, 13);
            this.lbMainWaterReading.TabIndex = 5;
            this.lbMainWaterReading.Text = "[Aflæsning]";
            // 
            // lbWashWaterPrimo
            // 
            this.lbWashWaterPrimo.AutoSize = true;
            this.lbWashWaterPrimo.Location = new System.Drawing.Point(125, 55);
            this.lbWashWaterPrimo.Name = "lbWashWaterPrimo";
            this.lbWashWaterPrimo.Size = new System.Drawing.Size(39, 13);
            this.lbWashWaterPrimo.TabIndex = 4;
            this.lbWashWaterPrimo.Text = "[Primo]";
            // 
            // lbMainWaterPrimo
            // 
            this.lbMainWaterPrimo.AutoSize = true;
            this.lbMainWaterPrimo.Location = new System.Drawing.Point(125, 16);
            this.lbMainWaterPrimo.Name = "lbMainWaterPrimo";
            this.lbMainWaterPrimo.Size = new System.Drawing.Size(39, 13);
            this.lbMainWaterPrimo.TabIndex = 4;
            this.lbMainWaterPrimo.Text = "[Primo]";
            // 
            // txtWashWaterReading
            // 
            this.txtWashWaterReading.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingReadings, "WashReading", true));
            this.txtWashWaterReading.Location = new System.Drawing.Point(196, 72);
            this.txtWashWaterReading.Name = "txtWashWaterReading";
            this.txtWashWaterReading.ReadOnly = true;
            this.txtWashWaterReading.Size = new System.Drawing.Size(60, 20);
            this.txtWashWaterReading.TabIndex = 4;
            this.txtWashWaterReading.Validated += new System.EventHandler(this.txtWashWaterReading_Validated);
            // 
            // txtMainWaterReading
            // 
            this.txtMainWaterReading.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingReadings, "MainWaterReading", true));
            this.txtMainWaterReading.Location = new System.Drawing.Point(196, 33);
            this.txtMainWaterReading.Name = "txtMainWaterReading";
            this.txtMainWaterReading.Size = new System.Drawing.Size(60, 20);
            this.txtMainWaterReading.TabIndex = 1;
            this.txtMainWaterReading.Validated += new System.EventHandler(this.txtMainWaterReading_Validated);
            // 
            // lbWashWater
            // 
            this.lbWashWater.AutoSize = true;
            this.lbWashWater.Location = new System.Drawing.Point(6, 75);
            this.lbWashWater.Name = "lbWashWater";
            this.lbWashWater.Size = new System.Drawing.Size(89, 13);
            this.lbWashWater.TabIndex = 1;
            this.lbWashWater.Text = "[Vask vandmåler]";
            // 
            // lbMainWater
            // 
            this.lbMainWater.AutoSize = true;
            this.lbMainWater.Location = new System.Drawing.Point(6, 36);
            this.lbMainWater.Name = "lbMainWater";
            this.lbMainWater.Size = new System.Drawing.Size(94, 13);
            this.lbMainWater.TabIndex = 1;
            this.lbMainWater.Text = "[Hovedvandmåler]";
            // 
            // txtWashWaterPrimo
            // 
            this.txtWashWaterPrimo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingReadings, "WashPrimo", true));
            this.txtWashWaterPrimo.Location = new System.Drawing.Point(128, 72);
            this.txtWashWaterPrimo.Name = "txtWashWaterPrimo";
            this.txtWashWaterPrimo.ReadOnly = true;
            this.txtWashWaterPrimo.Size = new System.Drawing.Size(62, 20);
            this.txtWashWaterPrimo.TabIndex = 3;
            // 
            // txtMainWaterPrimo
            // 
            this.txtMainWaterPrimo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingReadings, "MainWaterPrimo", true));
            this.txtMainWaterPrimo.Location = new System.Drawing.Point(128, 33);
            this.txtMainWaterPrimo.Name = "txtMainWaterPrimo";
            this.txtMainWaterPrimo.ReadOnly = true;
            this.txtMainWaterPrimo.Size = new System.Drawing.Size(62, 20);
            this.txtMainWaterPrimo.TabIndex = 0;
            // 
            // lbPrimoDate
            // 
            this.lbPrimoDate.AutoSize = true;
            this.lbPrimoDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingReadings, "PrimoDate", true));
            this.lbPrimoDate.Location = new System.Drawing.Point(137, 9);
            this.lbPrimoDate.Name = "lbPrimoDate";
            this.lbPrimoDate.Size = new System.Drawing.Size(54, 13);
            this.lbPrimoDate.TabIndex = 2;
            this.lbPrimoDate.Text = "<pri.date>";
            // 
            // groupPowerReadings
            // 
            this.groupPowerReadings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPowerReadings.Controls.Add(this.lbKWUse);
            this.groupPowerReadings.Controls.Add(this.lbKW);
            this.groupPowerReadings.Controls.Add(this.txtKWPrimo);
            this.groupPowerReadings.Controls.Add(this.txtKWUse);
            this.groupPowerReadings.Controls.Add(this.txtKWReading);
            this.groupPowerReadings.Controls.Add(this.lbKWPrimo);
            this.groupPowerReadings.Controls.Add(this.lbKWReading);
            this.groupPowerReadings.Location = new System.Drawing.Point(12, 138);
            this.groupPowerReadings.Name = "groupPowerReadings";
            this.groupPowerReadings.Size = new System.Drawing.Size(339, 64);
            this.groupPowerReadings.TabIndex = 3;
            this.groupPowerReadings.TabStop = false;
            this.groupPowerReadings.Text = "[EL aflæsning]";
            // 
            // lbKWUse
            // 
            this.lbKWUse.AutoSize = true;
            this.lbKWUse.Location = new System.Drawing.Point(259, 14);
            this.lbKWUse.Name = "lbKWUse";
            this.lbKWUse.Size = new System.Drawing.Size(49, 13);
            this.lbKWUse.TabIndex = 7;
            this.lbKWUse.Text = "[Forbrug]";
            // 
            // lbKW
            // 
            this.lbKW.AutoSize = true;
            this.lbKW.Location = new System.Drawing.Point(6, 34);
            this.lbKW.Name = "lbKW";
            this.lbKW.Size = new System.Drawing.Size(59, 13);
            this.lbKW.TabIndex = 1;
            this.lbKW.Text = "[KW måler]";
            // 
            // txtKWPrimo
            // 
            this.txtKWPrimo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingReadings, "KWPrimo", true));
            this.txtKWPrimo.Location = new System.Drawing.Point(128, 31);
            this.txtKWPrimo.Name = "txtKWPrimo";
            this.txtKWPrimo.ReadOnly = true;
            this.txtKWPrimo.Size = new System.Drawing.Size(62, 20);
            this.txtKWPrimo.TabIndex = 0;
            // 
            // txtKWUse
            // 
            this.txtKWUse.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingReadings, "KWUse", true));
            this.txtKWUse.Location = new System.Drawing.Point(262, 31);
            this.txtKWUse.Name = "txtKWUse";
            this.txtKWUse.ReadOnly = true;
            this.txtKWUse.Size = new System.Drawing.Size(60, 20);
            this.txtKWUse.TabIndex = 2;
            // 
            // txtKWReading
            // 
            this.txtKWReading.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingReadings, "KWReading", true));
            this.txtKWReading.Location = new System.Drawing.Point(196, 31);
            this.txtKWReading.Name = "txtKWReading";
            this.txtKWReading.Size = new System.Drawing.Size(60, 20);
            this.txtKWReading.TabIndex = 1;
            this.txtKWReading.Validated += new System.EventHandler(this.txtKWReading_Validated);
            // 
            // lbKWPrimo
            // 
            this.lbKWPrimo.AutoSize = true;
            this.lbKWPrimo.Location = new System.Drawing.Point(125, 14);
            this.lbKWPrimo.Name = "lbKWPrimo";
            this.lbKWPrimo.Size = new System.Drawing.Size(39, 13);
            this.lbKWPrimo.TabIndex = 4;
            this.lbKWPrimo.Text = "[Primo]";
            // 
            // lbKWReading
            // 
            this.lbKWReading.AutoSize = true;
            this.lbKWReading.Location = new System.Drawing.Point(193, 14);
            this.lbKWReading.Name = "lbKWReading";
            this.lbKWReading.Size = new System.Drawing.Size(60, 13);
            this.lbKWReading.TabIndex = 5;
            this.lbKWReading.Text = "[Aflæsning]";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(276, 219);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "[Annuller]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndClose.Location = new System.Drawing.Point(173, 219);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(97, 23);
            this.btnSaveAndClose.TabIndex = 0;
            this.btnSaveAndClose.Text = "[Gem og luk]";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // adapterReadings
            // 
            this.adapterReadings.ClearBeforeFill = true;
            // 
            // Readings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 254);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupPowerReadings);
            this.Controls.Add(this.groupWaterReadings);
            this.Controls.Add(this.lbPrimoDate);
            this.Controls.Add(this.lbBookDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Readings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Aflæsninger]";
            this.Load += new System.EventHandler(this.Readings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingReadings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEOD)).EndInit();
            this.groupWaterReadings.ResumeLayout(false);
            this.groupWaterReadings.PerformLayout();
            this.groupPowerReadings.ResumeLayout(false);
            this.groupPowerReadings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbBookDate;
        private System.Windows.Forms.GroupBox groupWaterReadings;
        private System.Windows.Forms.GroupBox groupPowerReadings;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.TextBox txtMainWaterPrimo;
        private System.Windows.Forms.BindingSource bindingReadings;
        private EODDataSet dsEOD;
        private RBOS.EODDataSetTableAdapters.ReadingsTableAdapter adapterReadings;
        private System.Windows.Forms.Label lbMainWater;
        private System.Windows.Forms.Label lbPrimoDate;
        private System.Windows.Forms.TextBox txtMainWaterReading;
        private System.Windows.Forms.Label lbMainWaterPrimo;
        private System.Windows.Forms.Label lbMainWaterReading;
        private System.Windows.Forms.Label lbMainWaterUse;
        private System.Windows.Forms.TextBox txtMainWaterUse;
        private System.Windows.Forms.Label lbWashWaterUse;
        private System.Windows.Forms.TextBox txtWashWaterUse;
        private System.Windows.Forms.Label lbWashWaterReading;
        private System.Windows.Forms.Label lbWashWaterPrimo;
        private System.Windows.Forms.TextBox txtWashWaterReading;
        private System.Windows.Forms.Label lbWashWater;
        private System.Windows.Forms.TextBox txtWashWaterPrimo;
        private System.Windows.Forms.Label lbKWUse;
        private System.Windows.Forms.Label lbKW;
        private System.Windows.Forms.TextBox txtKWPrimo;
        private System.Windows.Forms.TextBox txtKWUse;
        private System.Windows.Forms.TextBox txtKWReading;
        private System.Windows.Forms.Label lbKWPrimo;
        private System.Windows.Forms.Label lbKWReading;
    }
}