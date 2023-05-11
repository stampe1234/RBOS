using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Data.OleDb;
using CrystalDecisions.Windows.Forms;

namespace RBOS
{
    public partial class LadeDataReportForm : Form
    {
        public LadeDataReportForm()
        {
            InitializeComponent();
        }

        private void LoadData()
        {



            // Localize

            lbPostingDateStart.Text = db.GetLangString("ItemTranRepForm.StartDateLbl");
            lbPostingDateEnd.Text = db.GetLangString("ItemTranRepForm.EndDateLbl");
            btnClose.Text = db.GetLangString("btnClose");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");

        }

        //private void button2_Click(object sender, EventArgs e)
        //{
           


        //    DataSet2TableAdapters.LadeDataTableAdapter ladeDataTableAdapter = new DataSet2TableAdapters.LadeDataTableAdapter();
        //    using (OleDbConnection conn = new OleDbConnection(db.ConnectionString))
        //    {

        //        ladeDataTableAdapter.Connection = conn;
        //        ladeDataTableAdapter.Fill(dataSet2.LadeData,dtPostingDateFrom.Value.Date,dtPostingDateTo.Value.Date);
        //        LadeRapport1 ladeRapport1 = new LadeRapport1();
        //        ladeRapport1.SetDataSource((DataTable)dataSet2.LadeData);
        //        tools.SetReportSiteInformation(ladeRapport1);

        //        tools.Print(ladeRapport1, true);                

        //    }
        //}

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print(false);
        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            Print(true);
        }

        #region  Print
        private void Print(bool Preview)
        {

            DataSet2TableAdapters.LadeDataTableAdapter ladeDataTableAdapter = new DataSet2TableAdapters.LadeDataTableAdapter();
            using (OleDbConnection conn = new OleDbConnection(db.ConnectionString))
            {

                ladeDataTableAdapter.Connection = conn;
                ladeDataTableAdapter.Fill(dataSet2.LadeData, dtPostingDateFrom.Value.Date, dtPostingDateTo.Value.Date);
                LadeRapport1 ladeRapport1 = new LadeRapport1();
                ladeRapport1.SetDataSource((DataTable)dataSet2.LadeData);

                // write start-end dates
                tools.SetReportObjectText(
                   ladeRapport1,
                    "StartEndDate",
                    dtPostingDateFrom.Value.Date.ToString("dd-MM-yyyy") + " - " + dtPostingDateTo.Value.Date.ToString("dd-MM-yyyy"));



                tools.SetReportSiteInformation(ladeRapport1);


                tools.Print(ladeRapport1, Preview);

               
            }
            // check that any data were loaded
            if (dataSet2.LadeData.Rows.Count <= 0)
            {
                MessageBox.Show(db.GetLangString("ItemTransReportForm.NoDataToPrint"));
                return;
            }

            
            #endregion

            // Site information
            //tools.SetReportSiteInformation(ladeRapport1);

            // print the report
           // tools.Print(reportItemTransactions, Preview);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

     
      
    
