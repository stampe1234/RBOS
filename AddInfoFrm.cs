using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class AddInfoFrm : Form
    {
        public AddInfoFrm()
        {
            InitializeComponent();
            // localization
            lbStartDate.Text = db.GetLangString("SalesReportFrm.lbStartDate");
            lbEndDate.Text = db.GetLangString("SalesReportFrm.lbEndDate");            
            btnPrint.Text = db.GetLangString("Application.ReportPrint");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            btnClose.Text = db.GetLangString("Application.Close");
        }
        #region Print
        private void Print(bool preview)
        {
            // get selected start/end dates
            DateTime startDate = dtStartDate.Value.Date;
            DateTime endDate = dtEndDate.Value.Date;    
            
            AddInfoRpt rptAddInfo = new AddInfoRpt();
            AddInfoDataSet dsAddInfo = new AddInfoDataSet();               
            //>>nyt
            //slet
            db.ExecuteNonQuery(string.Format(
                       " delete from AddInfo "));
            //Bank dep
            
            db.ExecuteNonQuery(string.Format(
                       " insert into AddInfo " +
                       " (BookDate, [Type], SubType, [Description], Amount) " +
                       " SELECT BookDate, 'Bank indsætning', [LineNo], [Description], Amount FROM EOD_BankDep" +
                       " WHERE  (BookDate >= '{0}') AND (BookDate <= '{1}')",
                       startDate,endDate));
            //Bank card
            db.ExecuteNonQuery(string.Format(
                       " insert into AddInfo " +
                       " (BookDate, [Type], SubType, [Description], Amount) " +
                       " SELECT BookDate, 'Bank kort', [LineNo], [Description], Amount FROM EOD_BankCards" +
                        " WHERE  (BookDate >= '{0}') AND (BookDate <= '{1}')",
                       startDate,endDate));
                     
            //Dyn. felt 1
            db.ExecuteNonQuery(string.Format(
                       " insert into AddInfo " +
                       " (BookDate, [Type], SubType, [Description], Amount) " +
                       " SELECT BookDate, TmpAmt1Descr AS Type, '1' AS Subtype, '' AS Description, TmpAmt1 AS Amount " +
                       " FROM EODReconcile  WHERE  TmpAmt1 > 0  AND" +
                        " (BookDate >= '{0}') AND (BookDate <= '{1}')",
                       startDate,endDate));
                      
            //Dyn. felt 2
            db.ExecuteNonQuery(string.Format(
                       " insert into AddInfo " +
                       " (BookDate, [Type], SubType, [Description], Amount) " +
                       " SELECT BookDate, TmpAmt2Descr AS Type, '1' AS Subtype, '' AS Description, TmpAmt2 AS Amount " +
                       " FROM EODReconcile  WHERE  TmpAmt2 <> 0 AND " +
                       " (BookDate >= '{0}') AND (BookDate <= '{1}')",
                       startDate,endDate));
                     
            //Dyn. felt 3
            db.ExecuteNonQuery(string.Format(
                       " insert into AddInfo " +
                       " (BookDate, [Type], SubType, [Description], Amount) " +
                       " SELECT BookDate, TmpAmt3Descr AS Type, '1' AS Subtype, '' AS Description, TmpAmt3 AS Amount " +
                       " FROM EODReconcile  WHERE  TmpAmt3 > 0 AND" +
                        " (BookDate >= '{0}') AND (BookDate <= '{1}')",
                       startDate,endDate));
                       
            //Dyn. felt 4
            db.ExecuteNonQuery(string.Format(
                       " insert into AddInfo " +
                       " (BookDate, [Type], SubType, [Description], Amount) " +
                       " SELECT BookDate, TmpAmt4Descr AS Type, '1' AS Subtype, '' AS Description, TmpAmt4 AS Amount " +
                       " FROM EODReconcile  WHERE  TmpAmt4 > 0 AND " +
                       " (BookDate >= '{0}') AND (BookDate <= '{1}')",
                       startDate,endDate));
                           

            //<<nyt
            
            AddInfoDataSetTableAdapters.AddInfoTableAdapter adapterAddInfo =
                new AddInfoDataSetTableAdapters.AddInfoTableAdapter();
            adapterAddInfo.Fill(dsAddInfo.AddInfo, startDate, endDate);
            rptAddInfo.SetDataSource((DataSet)dsAddInfo);                                
            tools.SetReportObjectText(
                rptAddInfo,
                "StartEndDate",
                startDate.ToString("dd-MM-yyyy") + " - " + endDate.ToString("dd-MM-yyyy"));
            tools.SetReportSiteInformation(rptAddInfo);
            //rptAddInfo.DataDefinition.SortFields.;
            tools.Print(rptAddInfo, preview, true);
           
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
    }
}
