using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class ReportPreview : Form
    {
        public ReportPreview(CrystalDecisions.CrystalReports.Engine.ReportDocument document)
        {
            InitializeComponent();

            // set the report document to the one passed in
            this.crystalReportViewer1.ReportSource = document;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}