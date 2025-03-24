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
    public partial class WasteSheetLocalRptFrm : Form
    {
        int HeaderID = 0;

        #region Constructor
        public WasteSheetLocalRptFrm(int WasteHeaderID)
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
            DataRow row =  ItemDataSet.WasteSheetHeaderLocalDataTable.GetRecord(HeaderID);  
            if (row != null)
                txtName.Text = tools.object2string(row["Name"]);
            
        }
        #endregion

        #region Print
        private void Print(bool Preview)
        {


            // create db objects and load data
            ItemDataSet3TableAdapters.WasteSheetReportLocalTableAdapter adapter2 = new ItemDataSet3TableAdapters.WasteSheetReportLocalTableAdapter();
            // ItemDataSetTableAdapters3.WasteSheetReportLocalTableAdapter adapter = new ItemDataSetTableAdapters3.WasteSheetReportLocalTableAdapter();
           // ItemDataSet4TableAdapters.WasteSheetReportLocalTableAdapter adapter1 = new ItemDataSet4TableAdapters.WasteSheetReportLocalTableAdapter();
            //ItemDataSet3TableAdapters.WasteSheetReportLocalTableAdapter adapter = new ItemDataSet3TableAdapters.WasteSheetReportLocalTableAdapter();
            adapter2.Connection = db.Connection;
            //adapter.Connection = db.Connection;
            //ItemDataSet3.WasteSheetReportLocalDataTable table =
            //    new ItemDataSet3.WasteSheetReportLocalDataTable();
            //adapter.Fill(table, HeaderID);
            ItemDataSet3.WasteSheetReportLocalDataTable table = new ItemDataSet3.WasteSheetReportLocalDataTable();
            adapter2.Fill(table, HeaderID);
            //ItemDataSet4.WasteSheetReportLocalDataTable table = new ItemDataSet4.WasteSheetReportLocalDataTable();
            //adapter1.Fill(table, HeaderID);
            // check we have data
            if (table.Rows.Count > 0)
            {
                // create barcode images on table
                string msgProgressTitle = db.GetLangString("WasteSheetRptFrm.CreatingBarcodeImages");
                CreateBarcodeImages(table, "BCType", "Barcode", "BarcodeImage", msgProgressTitle, "ItemName");

                // create report and assign data
                WasteSheetLocalRpt  report = new WasteSheetLocalRpt();
                report.SetDataSource((DataTable)table);

                // set report site information
                tools.SetReportSiteInformation(report);

                // set report waste sheet information
                tools.SetReportObjectText(report, "txtName", txtName.Text);

                // print the report
                tools.Print(report, Preview);
            }
            else
            {
                MessageBox.Show(db.GetLangString("Application.NoDataToPrint"));
            }

        }
        #endregion

        #region CreateBarcodeImages
        /// <summary>
        /// Fills a column with barcode images by using provided BCType and Barcode columns.
        /// </summary>
        /// <param name="Table">The table upon which to make the barcode.</param>
        /// <param name="BCTypeFieldName">The field name in the table containing the BCType.</param>
        /// <param name="BarcodeFieldName">The field name in the table containing the Barcode.</param>
        /// <param name="BarcodeImageFieldName">The field name in the table to be filled in with the barcode image. This column must be of type byte[].</param>
        /// <param name="ProgressTitle">The title of the progress form shown.</param>
        /// <param name="ProgressTextFieldName">The field name in the table containing text to display as progress text.</param>
        private void CreateBarcodeImages(
            DataTable Table,
            string BCTypeFieldName,
            string BarcodeFieldName,
            string BarcodeImageFieldName,
            string ProgressTitle,
            string ProgressTextFieldName)
        {
            // prepare barcode object
            BarcodeProfessional barcode = new BarcodeProfessional();
            barcode.ForeColor = Color.Black;
            barcode.AddChecksum = false;
            barcode.DisplayCode = true;
            barcode.BarRatio = 2;
            barcode.Text = "";
            barcode.AutoSize = true;

            // setup progress form
            ProgressForm progress = new ProgressForm(ProgressTitle);
            progress.ProgressMax = Table.Rows.Count;
            progress.Show();

            // create barcode images for each barcode
            foreach (DataRow row in Table.Rows)
            {
                // advance progress bar
                progress.StatusText = tools.object2string(row[ProgressTextFieldName]);

                // setup barcode symbology based on bctype
                if (tools.object2int(row[BCTypeFieldName]) == (int)Barcode.Types.EAN8)
                    barcode.Symbology = Symbology.Ean8;
                else if (tools.object2int(row[BCTypeFieldName]) == (int)Barcode.Types.EAN13)
                    barcode.Symbology = Symbology.Ean13;
                else // custom
                    barcode.Symbology = Symbology.Code39;

                // get the barcode from table and create the barcode image
                barcode.Code = tools.object2string(row[BarcodeFieldName]);
                row[BarcodeImageFieldName] = barcode.GetBarcodeImage(System.Drawing.Imaging.ImageFormat.Png);
            }

            progress.Close();
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