namespace RBOS
{
    partial class TestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            this.btnCalculateWeekNumber = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.txtCalculatedYear = new System.Windows.Forms.TextBox();
            this.txtCalculatedMonth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExportACNFile = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBCalculate = new System.Windows.Forms.Button();
            this.txtBResult = new System.Windows.Forms.TextBox();
            this.txtBWeek = new System.Windows.Forms.TextBox();
            this.txtBYear = new System.Windows.Forms.TextBox();
            this.btnDummyValuesInEODReconcileEx = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEODReconcileEx_fromyear = new System.Windows.Forms.TextBox();
            this.txtEODReconcileEx_toyear = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCalculateWeekNumber
            // 
            this.btnCalculateWeekNumber.Location = new System.Drawing.Point(16, 236);
            this.btnCalculateWeekNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCalculateWeekNumber.Name = "btnCalculateWeekNumber";
            this.btnCalculateWeekNumber.Size = new System.Drawing.Size(219, 28);
            this.btnCalculateWeekNumber.TabIndex = 0;
            this.btnCalculateWeekNumber.Text = "Calculate weeknumber";
            this.btnCalculateWeekNumber.UseVisualStyleBackColor = true;
            this.btnCalculateWeekNumber.Click += new System.EventHandler(this.btnCalculateWeekNumber_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(16, 31);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.ShowWeekNumbers = true;
            this.monthCalendar1.TabIndex = 1;
            // 
            // txtCalculatedYear
            // 
            this.txtCalculatedYear.Location = new System.Drawing.Point(157, 272);
            this.txtCalculatedYear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCalculatedYear.Name = "txtCalculatedYear";
            this.txtCalculatedYear.Size = new System.Drawing.Size(76, 22);
            this.txtCalculatedYear.TabIndex = 2;
            // 
            // txtCalculatedMonth
            // 
            this.txtCalculatedMonth.Location = new System.Drawing.Point(157, 304);
            this.txtCalculatedMonth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCalculatedMonth.Name = "txtCalculatedMonth";
            this.txtCalculatedMonth.Size = new System.Drawing.Size(76, 22);
            this.txtCalculatedMonth.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 308);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Calculated week#";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 276);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Calculated year";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.monthCalendar1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnCalculateWeekNumber);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCalculatedYear);
            this.groupBox1.Controls.Add(this.txtCalculatedMonth);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(251, 342);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Testing tools.WeekNumber";
            // 
            // btnExportACNFile
            // 
            this.btnExportACNFile.Location = new System.Drawing.Point(8, 39);
            this.btnExportACNFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExportACNFile.Name = "btnExportACNFile";
            this.btnExportACNFile.Size = new System.Drawing.Size(219, 28);
            this.btnExportACNFile.TabIndex = 8;
            this.btnExportACNFile.Text = "Export ACN file";
            this.btnExportACNFile.UseVisualStyleBackColor = true;
            this.btnExportACNFile.Click += new System.EventHandler(this.btnExportACNFile_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(447, 553);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnExportACNFile);
            this.groupBox2.Location = new System.Drawing.Point(16, 364);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(251, 150);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Testing Export ACN file";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 79);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Exports all pending ACN files";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 98);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(219, 28);
            this.button1.TabIndex = 11;
            this.button1.Text = "Export ACN files";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Uses the above calendar";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnBCalculate);
            this.groupBox3.Controls.Add(this.txtBResult);
            this.groupBox3.Controls.Add(this.txtBWeek);
            this.groupBox3.Controls.Add(this.txtBYear);
            this.groupBox3.Location = new System.Drawing.Point(275, 15);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(272, 97);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Testing tools.DateFromYearAndWeek";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(116, 27);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Week";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Year";
            // 
            // btnBCalculate
            // 
            this.btnBCalculate.Location = new System.Drawing.Point(12, 55);
            this.btnBCalculate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBCalculate.Name = "btnBCalculate";
            this.btnBCalculate.Size = new System.Drawing.Size(152, 28);
            this.btnBCalculate.TabIndex = 11;
            this.btnBCalculate.Text = "Calculate sunday";
            this.btnBCalculate.UseVisualStyleBackColor = true;
            this.btnBCalculate.Click += new System.EventHandler(this.btnBCalculate_Click);
            // 
            // txtBResult
            // 
            this.txtBResult.Location = new System.Drawing.Point(172, 58);
            this.txtBResult.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBResult.Name = "txtBResult";
            this.txtBResult.Size = new System.Drawing.Size(83, 22);
            this.txtBResult.TabIndex = 2;
            // 
            // txtBWeek
            // 
            this.txtBWeek.Location = new System.Drawing.Point(172, 23);
            this.txtBWeek.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBWeek.Name = "txtBWeek";
            this.txtBWeek.Size = new System.Drawing.Size(31, 22);
            this.txtBWeek.TabIndex = 1;
            // 
            // txtBYear
            // 
            this.txtBYear.Location = new System.Drawing.Point(55, 23);
            this.txtBYear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBYear.Name = "txtBYear";
            this.txtBYear.Size = new System.Drawing.Size(52, 22);
            this.txtBYear.TabIndex = 0;
            // 
            // btnDummyValuesInEODReconcileEx
            // 
            this.btnDummyValuesInEODReconcileEx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDummyValuesInEODReconcileEx.Location = new System.Drawing.Point(8, 151);
            this.btnDummyValuesInEODReconcileEx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDummyValuesInEODReconcileEx.Name = "btnDummyValuesInEODReconcileEx";
            this.btnDummyValuesInEODReconcileEx.Size = new System.Drawing.Size(256, 28);
            this.btnDummyValuesInEODReconcileEx.TabIndex = 11;
            this.btnDummyValuesInEODReconcileEx.Text = "Opret records";
            this.btnDummyValuesInEODReconcileEx.UseVisualStyleBackColor = true;
            this.btnDummyValuesInEODReconcileEx.Click += new System.EventHandler(this.btnDummyValuesInEODReconcileEx_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txtEODReconcileEx_fromyear);
            this.groupBox4.Controls.Add(this.txtEODReconcileEx_toyear);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.btnDummyValuesInEODReconcileEx);
            this.groupBox4.Location = new System.Drawing.Point(275, 119);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(272, 187);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "EODReconcileEx dummy værdier";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 80);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "Fra år";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 112);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Til år";
            // 
            // txtEODReconcileEx_fromyear
            // 
            this.txtEODReconcileEx_fromyear.Location = new System.Drawing.Point(61, 76);
            this.txtEODReconcileEx_fromyear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEODReconcileEx_fromyear.Name = "txtEODReconcileEx_fromyear";
            this.txtEODReconcileEx_fromyear.Size = new System.Drawing.Size(85, 22);
            this.txtEODReconcileEx_fromyear.TabIndex = 14;
            // 
            // txtEODReconcileEx_toyear
            // 
            this.txtEODReconcileEx_toyear.Location = new System.Drawing.Point(61, 108);
            this.txtEODReconcileEx_toyear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEODReconcileEx_toyear.Name = "txtEODReconcileEx_toyear";
            this.txtEODReconcileEx_toyear.Size = new System.Drawing.Size(85, 22);
            this.txtEODReconcileEx_toyear.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 20);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(251, 53);
            this.label7.TabIndex = 12;
            this.label7.Text = "Indsæt dummy  BookDate og CustomerCount værdier i tabellen EODReconcileEx.";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(389, 404);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 596);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TestForm";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCalculateWeekNumber;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.TextBox txtCalculatedYear;
        private System.Windows.Forms.TextBox txtCalculatedMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExportACNFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBCalculate;
        private System.Windows.Forms.TextBox txtBResult;
        private System.Windows.Forms.TextBox txtBWeek;
        private System.Windows.Forms.TextBox txtBYear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDummyValuesInEODReconcileEx;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEODReconcileEx_fromyear;
        private System.Windows.Forms.TextBox txtEODReconcileEx_toyear;
        private System.Windows.Forms.Button button2;
    }
}