using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class DanskeSpilReportFrm : Form
    {
        #region Constructor
        public DanskeSpilReportFrm()
        {
            InitializeComponent();
        }
        #endregion

        #region Print
        private void Print(bool preview)
        {
            
            // get selected start/end dates
            DateTime startDate = dtStartDate.Value.Date;
            DateTime endDate = dtEndDate.Value.Date;      
            
            // prepare db objects
            DanskeSpilDataSet.Danske_SpilDataTable.UpdateDanskeSpil(startDate, endDate);
              
            DanskeSpilDataSet.Danske_SpilDataTable  tableDanskeSpilReport =
                new DanskeSpilDataSet.Danske_SpilDataTable ();           
            
                      
            DanskeSpilDataSetTableAdapters.Danske_SpilTableAdapter adapterDanskeSpilReport =
                new DanskeSpilDataSetTableAdapters.Danske_SpilTableAdapter();            
         
            adapterDanskeSpilReport.Connection = db.Connection;                  

            // variables needed           
          
            bool PrintPortrait = false;

            adapterDanskeSpilReport.Fill(tableDanskeSpilReport, startDate, endDate);                       
                                               
            DanskeSpilReport rptDanskeSpil = new DanskeSpilReport();
                                

            // write start-end dates
            tools.SetReportObjectText(
               rptDanskeSpil ,
                "StartEndDate",
                startDate.ToString("dd-MM-yyyy") + " - " + endDate.ToString("dd-MM-yyyy"));
           

          
            tools.SetReportSiteInformation(rptDanskeSpil);
                                      

            // print
            tableDanskeSpilReport.DefaultView.Sort = "BookDate";
            //rptDanskeSpil.SetDataSource(adapterDanskeSpilReport);

            rptDanskeSpil.SetDataSource(((DataTable)tableDanskeSpilReport));
            tools.Print(rptDanskeSpil, preview, PrintPortrait);
        }
        #endregion
               

        #region EnsureDateInterval
        /// <summary>
        /// Makes sure the startdate is not later that the enddate and visa versa.
        /// </summary>
        private void EnsureDateInterval()
        {
            dtStartDate.MaxDate = dtEndDate.Value.Date;
            dtEndDate.MinDate = dtStartDate.Value.Date;
        }
        #endregion

      

        #region LoadData
        private void LoadData()
        {
            // make sure datetime pickers cannot select dates
            // before or after sales record dates
            //DateTime MaxSalesDate = DanskeSpilDataSet.Danske_SpilDataTable.GetMaxDanskeSpilDate();
            DateTime MaxSalesDate = EODDataSet.EOD_SalesDataTable.GetMaxSalesDate();
            DateTime MinSalesDate = DanskeSpilDataSet.Danske_SpilDataTable.GetDanskeSpilMinDate();
            if ((MinSalesDate != DateTime.MinValue) && (MaxSalesDate != DateTime.MinValue))
            {
                dtStartDate.MinDate = MinSalesDate;
                dtEndDate.MaxDate = MaxSalesDate;

                // make sure datetime pickers cannot overlap interval
                EnsureDateInterval();

                // by default enddate is the last date there is sales data on
                dtEndDate.Value = dtEndDate.MaxDate;

                // and by default the startdate is the first in that month,
                // or the first possible date if no data in the beginning of the month
                DateTime dtFirstDateInMonth = new DateTime(dtEndDate.Value.Year, dtEndDate.Value.Month, 1);
                if (dtFirstDateInMonth < dtStartDate.MinDate)
                    dtStartDate.Value = dtStartDate.MinDate;
                else
                    dtStartDate.Value = dtFirstDateInMonth;
            }
            else
            {
                dtEndDate.Enabled = false;
                dtStartDate.Enabled = false;
            }


            // Localize

            lbStartDate.Text = db.GetLangString("ItemTranRepForm.StartDateLbl");
            lbEndDate.Text = db.GetLangString("ItemTranRepForm.EndDateLbl");           
            btnClose.Text = db.GetLangString("btnClose");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");           

        }

        #endregion

       

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print(false);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Print(true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtStartDate_ValueChanged(object sender, EventArgs e)
        {
            EnsureDateInterval();
        }

        private void dtEndDate_ValueChanged(object sender, EventArgs e)
        {
            EnsureDateInterval();
        }

        private void DanskeSpilReportFrm_Load(object sender, EventArgs e)
        {
            
            LoadData();
        }              

       
    }
}