namespace RBOS
{
    partial class LadeDataReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LadeDataReportForm));
            this.button1 = new System.Windows.Forms.Button();
            this.dataSet2 = new RBOS.DataSet2();
            this.ladeDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableAdapterManager = new RBOS.DataSet2TableAdapters.TableAdapterManager();
            this.dtPostingDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtPostingDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lbPostingDateEnd = new System.Windows.Forms.Label();
            this.lbPostingDateStart = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ladeDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "DataSet2";
            this.dataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ladeDataBindingSource
            // 
            this.ladeDataBindingSource.DataMember = "LadeData";
            this.ladeDataBindingSource.DataSource = this.dataSet2;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.InactiveItemTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = RBOS.DataSet2TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dtPostingDateTo
            // 
            this.dtPostingDateTo.Checked = false;
            this.dtPostingDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPostingDateTo.Location = new System.Drawing.Point(137, 31);
            this.dtPostingDateTo.Name = "dtPostingDateTo";
            this.dtPostingDateTo.ShowCheckBox = true;
            this.dtPostingDateTo.Size = new System.Drawing.Size(94, 20);
            this.dtPostingDateTo.TabIndex = 27;
            // 
            // dtPostingDateFrom
            // 
            this.dtPostingDateFrom.Checked = false;
            this.dtPostingDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPostingDateFrom.Location = new System.Drawing.Point(137, 5);
            this.dtPostingDateFrom.Name = "dtPostingDateFrom";
            this.dtPostingDateFrom.ShowCheckBox = true;
            this.dtPostingDateFrom.Size = new System.Drawing.Size(94, 20);
            this.dtPostingDateFrom.TabIndex = 26;
            // 
            // lbPostingDateEnd
            // 
            this.lbPostingDateEnd.AutoSize = true;
            this.lbPostingDateEnd.Location = new System.Drawing.Point(12, 35);
            this.lbPostingDateEnd.Name = "lbPostingDateEnd";
            this.lbPostingDateEnd.Size = new System.Drawing.Size(84, 13);
            this.lbPostingDateEnd.TabIndex = 29;
            this.lbPostingDateEnd.Text = "[Posting date to]";
            // 
            // lbPostingDateStart
            // 
            this.lbPostingDateStart.AutoSize = true;
            this.lbPostingDateStart.Location = new System.Drawing.Point(12, 9);
            this.lbPostingDateStart.Name = "lbPostingDateStart";
            this.lbPostingDateStart.Size = new System.Drawing.Size(95, 13);
            this.lbPostingDateStart.TabIndex = 28;
            this.lbPostingDateStart.Text = "[Posting date from]";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(173, 104);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 32;
            this.btnClose.Text = "[Close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPreview.Location = new System.Drawing.Point(92, 104);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 31;
            this.btnPreview.Text = "[Preview]";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.Location = new System.Drawing.Point(11, 104);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 30;
            this.btnPrint.Text = "[Print]";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // LadeDataReportForm
            // 
            this.ClientSize = new System.Drawing.Size(302, 135);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dtPostingDateTo);
            this.Controls.Add(this.dtPostingDateFrom);
            this.Controls.Add(this.lbPostingDateEnd);
            this.Controls.Add(this.lbPostingDateStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LadeDataReportForm";
            this.Load += LadeDataReportForm_Load;
            this.Text = "Ladedata rapport";
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ladeDataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void LadeDataReportForm_Load(object sender, System.EventArgs e)
        {
            btnClose.Text = db.GetLangString("Application.Close");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");           
            lbPostingDateStart.Text = db.GetLangString("OnHandRptFrm.lbPostingDateStart");
            lbPostingDateEnd.Text = db.GetLangString("OnHandRptFrm.lbPostingDateEnd");
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private DataSet2 dataSet2;
        private System.Windows.Forms.BindingSource ladeDataBindingSource;
        private DataSet2TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DateTimePicker dtPostingDateTo;
        private System.Windows.Forms.DateTimePicker dtPostingDateFrom;
        private System.Windows.Forms.Label lbPostingDateEnd;
        private System.Windows.Forms.Label lbPostingDateStart;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnPrint;
    }
}