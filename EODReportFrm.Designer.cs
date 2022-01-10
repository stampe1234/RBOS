namespace RBOS
{
    partial class EODReportFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EODReportFrm));
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.chkShortReport = new System.Windows.Forms.CheckBox();
            this.lbExportFile = new System.Windows.Forms.Label();
            this.report = new RBOS.EODReport();
            this.dsEOD = new RBOS.EODDataSet();
            this.adapterBankCards = new RBOS.EODDataSetTableAdapters.EOD_BankCardsTableAdapter();
            this.adapterBankDep = new RBOS.EODDataSetTableAdapters.EOD_BankDepTableAdapter();
            this.adapterLocalCredReport = new RBOS.EODDataSetTableAdapters.EOD_LocalCred_ReportTableAdapter();
            this.adapterPayinPayout = new RBOS.EODDataSetTableAdapters.EOD_PayinPayoutTableAdapter();
            this.adapterSalesReport = new RBOS.EODDataSetTableAdapters.EOD_Sales_ReportTableAdapter();
            this.adapterShellCards = new RBOS.EODDataSetTableAdapters.EOD_ShellCardsTableAdapter();
            this.adapterEODReconcile = new RBOS.EODDataSetTableAdapters.EODReconcileSingleTableAdapter();
            this.adapterReportParams = new RBOS.EODDataSetTableAdapters.EODReportParamsTableAdapter();
            this.adapterSalesReportPerGLCode = new RBOS.EODDataSetTableAdapters.EOD_Sales_Report_Per_GLCodeTableAdapter();
            this.lbSalesPerGLCode = new System.Windows.Forms.Label();
            this.chkSalesPerGLCode = new System.Windows.Forms.CheckBox();
            this.adapterReadings = new RBOS.EODDataSetTableAdapters.ReadingsTableAdapter();
            this.adapterWash = new RBOS.EODDataSetTableAdapters.WashTableAdapter();
            this.adapterManualCards = new RBOS.EODDataSetTableAdapters.EOD_ManualCardsTableAdapter();
            this.adapterForeignCurrency = new RBOS.EODDataSetTableAdapters.EOD_ForeignCurrencyTableAdapter();
            this.adapterReserveTerminal = new RBOS.EODDataSetTableAdapters.EOD_ReserveTerminalTableAdapter();
         
            ((System.ComponentModel.ISupportInitialize)(this.dsEOD)).BeginInit();
           
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(100, 94);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 28);
            this.btnPrint.TabIndex = 24;
            this.btnPrint.Text = "[Print]";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(316, 94);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(208, 94);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(100, 28);
            this.btnPreview.TabIndex = 26;
            this.btnPreview.Text = "[Preview]";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // chkShortReport
            // 
            this.chkShortReport.AutoSize = true;
            this.chkShortReport.Location = new System.Drawing.Point(243, 22);
            this.chkShortReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkShortReport.Name = "chkShortReport";
            this.chkShortReport.Size = new System.Drawing.Size(18, 17);
            this.chkShortReport.TabIndex = 28;
            this.chkShortReport.UseVisualStyleBackColor = true;
            // 
            // lbExportFile
            // 
            this.lbExportFile.AutoSize = true;
            this.lbExportFile.Location = new System.Drawing.Point(16, 22);
            this.lbExportFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbExportFile.Name = "lbExportFile";
            this.lbExportFile.Size = new System.Drawing.Size(194, 17);
            this.lbExportFile.TabIndex = 29;
            this.lbExportFile.Text = "[Kort dagsopgørelse, èn side]";
            // 
            // dsEOD
            // 
            this.dsEOD.DataSetName = "EODDataSet";
            this.dsEOD.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // adapterBankCards
            // 
            this.adapterBankCards.ClearBeforeFill = true;
            // 
            // adapterBankDep
            // 
            this.adapterBankDep.ClearBeforeFill = true;
            // 
            // adapterLocalCredReport
            // 
            this.adapterLocalCredReport.ClearBeforeFill = false;
            // 
            // adapterPayinPayout
            // 
            this.adapterPayinPayout.ClearBeforeFill = false;
            // 
            // adapterSalesReport
            // 
            this.adapterSalesReport.ClearBeforeFill = false;
            // 
            // adapterShellCards
            // 
            this.adapterShellCards.ClearBeforeFill = true;
            // 
            // adapterEODReconcile
            // 
            this.adapterEODReconcile.ClearBeforeFill = true;
            // 
            // adapterReportParams
            // 
            this.adapterReportParams.ClearBeforeFill = true;
            // 
            // adapterSalesReportPerGLCode
            // 
            this.adapterSalesReportPerGLCode.ClearBeforeFill = true;
            // 
            // lbSalesPerGLCode
            // 
            this.lbSalesPerGLCode.AutoSize = true;
            this.lbSalesPerGLCode.Location = new System.Drawing.Point(16, 52);
            this.lbSalesPerGLCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSalesPerGLCode.Name = "lbSalesPerGLCode";
            this.lbSalesPerGLCode.Size = new System.Drawing.Size(153, 17);
            this.lbSalesPerGLCode.TabIndex = 31;
            this.lbSalesPerGLCode.Text = "[Vis varesalg pr. konto]";
            // 
            // chkSalesPerGLCode
            // 
            this.chkSalesPerGLCode.AutoSize = true;
            this.chkSalesPerGLCode.Location = new System.Drawing.Point(243, 52);
            this.chkSalesPerGLCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkSalesPerGLCode.Name = "chkSalesPerGLCode";
            this.chkSalesPerGLCode.Size = new System.Drawing.Size(18, 17);
            this.chkSalesPerGLCode.TabIndex = 30;
            this.chkSalesPerGLCode.UseVisualStyleBackColor = true;
            // 
            // adapterReadings
            // 
            this.adapterReadings.ClearBeforeFill = true;
            // 
            // adapterWash
            // 
            this.adapterWash.ClearBeforeFill = true;
            // 
            // adapterManualCards
            // 
            this.adapterManualCards.ClearBeforeFill = true;
            // 
            // adapterForeignCurrency
            // 
            this.adapterForeignCurrency.ClearBeforeFill = true;
            // 
            // adapterReserveTerminal
            // 
            this.adapterReserveTerminal.ClearBeforeFill = true;
            // 
            
            // 
            // EODReportFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 137);
            this.Controls.Add(this.lbSalesPerGLCode);
            this.Controls.Add(this.chkSalesPerGLCode);
            this.Controls.Add(this.lbExportFile);
            this.Controls.Add(this.chkShortReport);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "EODReportFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EODReportForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EODReportFrm_FormClosing);
            this.Load += new System.EventHandler(this.EODReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsEOD)).EndInit();
          
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.CheckBox chkShortReport;
        private System.Windows.Forms.Label lbExportFile;
        private EODReport report;
        private EODDataSet dsEOD;
      
        private RBOS.EODDataSetTableAdapters.EOD_BankCardsTableAdapter adapterBankCards;
        private RBOS.EODDataSetTableAdapters.EOD_BankDepTableAdapter adapterBankDep;
       
        private RBOS.EODDataSetTableAdapters.EOD_LocalCred_ReportTableAdapter adapterLocalCredReport;
        private RBOS.EODDataSetTableAdapters.EOD_PayinPayoutTableAdapter adapterPayinPayout;
        private RBOS.EODDataSetTableAdapters.EOD_Sales_ReportTableAdapter adapterSalesReport;
        private RBOS.EODDataSetTableAdapters.EOD_ShellCardsTableAdapter adapterShellCards;
        private RBOS.EODDataSetTableAdapters.EODReconcileSingleTableAdapter adapterEODReconcile;
        private RBOS.EODDataSetTableAdapters.EODReportParamsTableAdapter adapterReportParams;
        private RBOS.EODDataSetTableAdapters.EOD_Sales_Report_Per_GLCodeTableAdapter adapterSalesReportPerGLCode;
        private System.Windows.Forms.Label lbSalesPerGLCode;
        private System.Windows.Forms.CheckBox chkSalesPerGLCode;
        private RBOS.EODDataSetTableAdapters.ReadingsTableAdapter adapterReadings;
        private RBOS.EODDataSetTableAdapters.WashTableAdapter adapterWash;
        private RBOS.EODDataSetTableAdapters.EOD_ManualCardsTableAdapter adapterManualCards;
        private RBOS.EODDataSetTableAdapters.EOD_ForeignCurrencyTableAdapter adapterForeignCurrency;
        private RBOS.EODDataSetTableAdapters.EOD_ReserveTerminalTableAdapter adapterReserveTerminal;
       

    }
}