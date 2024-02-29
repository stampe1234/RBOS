using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Neodynamic.WinControls.BarcodeProfessional;

namespace RBOS
{
    public partial class WasteSheetRptFrm : Form
    {
        int HeaderID = 0;
        string ReportType = "";

        #region Constructor
        public WasteSheetRptFrm(int WasteHeaderID)
        {
            InitializeComponent();
            this.HeaderID = WasteHeaderID;
            LoadData();
            
            // localization
            this.Text = db.GetLangString("WasteSheetRptFrm.Title");
            btnClose.Text = db.GetLangString("Application.Close");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");
            lbName.Text = db.GetLangString("WasteSheetRptFrm.lbName");        
        }
        #endregion

        #region LoadData
        private void LoadData()
        {
            DataRow row = ItemDataSet.WasteSheetHeaderDataTable.GetRecord(HeaderID);
           
            if (row != null)
                txtName.Text = tools.object2string(row["Name"]);      
            if (tools.object2int(row["SC"]) == 1)
            {
                ReportType = "OptællingsArk";
            }
            if (tools.object2int(row["Waste"]) == 1)
            {
                ReportType = "AfskrivningsArk";
            }

            //if ((tools.object2int(row["SC"]) != 1) & (tools.object2int(row["Waste"]) != 1))
            //{
            //    MessageBox.Show("Vælg enten Optælling eller Afskrivning");
            //}


        }
        #endregion

        #region Print
        private void Print(bool Preview)
        {

            // create db objects and load data
            ItemDataSetTableAdapters.WasteSheetReportTableAdapter adapter =
                new RBOS.ItemDataSetTableAdapters.WasteSheetReportTableAdapter();
            adapter.Connection = db.Connection;
            ItemDataSet.WasteSheetReportDataTable table =
                new ItemDataSet.WasteSheetReportDataTable();
            adapter.Fill(table, HeaderID);

            // check we have data
            if (table.Rows.Count > 0)
            {
              
               
                // create report and assign data
                WasteSheetRpt report = new WasteSheetRpt();

               // report.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;

                report.SetDataSource((DataTable)table);

                // set report site information
                tools.SetReportSiteInformation(report);

                // set report waste sheet information
                tools.SetReportObjectText(report, "txtName", txtName.Text);
                tools.SetReportObjectText(report, "ReportType", ReportType);
                // report.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                // print the report

                tools.Print(report, Preview,false);
            }
            else
            {
                MessageBox.Show(db.GetLangString("Application.NoDataToPrint"));
            }

        }
        #endregion



        private void btnClose_Click(object sender, EventArgs e)
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