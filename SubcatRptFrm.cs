using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class SubcatRptFrm : Form
    {
        public SubcatRptFrm()
        {
            InitializeComponent();

            // localization
            btnClose.Text = db.GetLangString("Application.Close");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");

        }

        private void Print(bool Preview)
        {
                    

            // create db objects
            ReportDataSetTableAdapters.SubCategoryTableAdapter adapter =
                new RBOS.ReportDataSetTableAdapters.SubCategoryTableAdapter();
            adapter.Connection = db.Connection;
            ReportDataSet dsReport = new ReportDataSet();
            // load data
            adapter.Fill(dsReport.SubCategory);

            // Site information
            tools.SetReportSiteInformation( rptSubcategory );

            // print the report
            rptSubcategory.SetDataSource(dsReport);
            tools.Print(rptSubcategory, Preview, true);
            
        }


        

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Print(true);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print(false);
        }
    }

}