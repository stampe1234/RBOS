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
            //chkWithPrintNumOfAndTotal.Text = db.GetLangString("WasteSheetRptFrm.chkWithPrintNumOfAndTotal");
            //chkPrintWithWeekdays.Text = db.GetLangString("WasteSheetRptFrm.chkPrintWithWeekdays");
            //chkPrintCount.Text = db.GetLangString("WasteSheetRptFrm.chkPrintCount");
        }
        #endregion

        #region LoadData
        private void LoadData()
        {
            DataRow row = ItemDataSet.WasteSheetHeaderDataTable.GetRecord(HeaderID);
            if (row != null)
                txtName.Text = tools.object2string(row["Name"]);

            //chkWithPrintNumOfAndTotal.Checked = db.GetConfigStringAsBool("WasteSheetRptFrm.chkWithPrintNumOfAndTotal");
            //chkPrintWithWeekdays.Checked = db.GetConfigStringAsBool("WasteSheetRptFrm.chkPrintWithWeekdays");
            //chkPrintCount.Checked = db.GetConfigStringAsBool("WasteSheetRptFrm.chkPrintCount");

            //if (!chkWithPrintNumOfAndTotal.Checked && !chkPrintWithWeekdays.Checked && !chkPrintCount.Checked)
            //    chkWithPrintNumOfAndTotal.Checked = true;
        }
        #endregion

        #region Print
        private void Print(bool Preview)
        {
#if !RBA
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
                // create barcode images on table
                string msgProgressTitle = db.GetLangString("WasteSheetRptFrm.CreatingBarcodeImages");
                CreateBarcodeImages(table, "BCType", "Barcode", "BarcodeImage", msgProgressTitle, "ItemName");

                // create report and assign data
                WasteSheetRpt report = new WasteSheetRpt();
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
#else
            DataTable table;

            // create db objects and load data
            if (chkPrintCount.Checked)
            {
                ItemDataSetTableAdapters.WasteSheetCountReportRBATableAdapter adapter =
                    new RBOS.ItemDataSetTableAdapters.WasteSheetCountReportRBATableAdapter();
                table = new ItemDataSet.WasteSheetCountReportRBADataTable();
                adapter.Fill((ItemDataSet.WasteSheetCountReportRBADataTable)table, HeaderID);

                // subtract VAT from cost price
                foreach (DataRow row in table.Rows)
                    row["Kostpris"] = tools.DeductVAT(tools.object2double(row["Kostpris"]), tools.object2string(row["SubCategoryID"]));
            }
            else
            {
                ItemDataSetTableAdapters.WasteSheetReportRBATableAdapter adapter =
                    new RBOS.ItemDataSetTableAdapters.WasteSheetReportRBATableAdapter();
                adapter.Connection = db.Connection;
                table = new ItemDataSet.WasteSheetReportRBADataTable();
                adapter.Fill((ItemDataSet.WasteSheetReportRBADataTable)table, HeaderID);
            }

            // check we have data
            if (table.Rows.Count > 0)
            {
                // create barcode images on table
                string msgProgressTitle = db.GetLangString("WasteSheetRptFrm.CreatingBarcodeImages");
                CreateBarcodeImagesRBA(table, "Varenummer", "VarenummerImage", msgProgressTitle, "Varenavn");

                // create report and assign data
                CrystalDecisions.CrystalReports.Engine.ReportClass report;
                if (chkWithPrintNumOfAndTotal.Checked)
                    report = new WasteSheetRptRBA();
                else if (chkPrintWithWeekdays.Checked)
                    report = new WasteSheetRptRBAWeekdays();
                else
                    report = new WasteSheetCountRptRBA();
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
#endif
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

        //#region CreateBarcodeImagesRBA
        ///// <summary>
        ///// Fills a column with barcode images by using provided BCType and Barcode columns.
        ///// </summary>
        ///// <param name="Table">The table upon which to make the barcode.</param>
        ///// <param name="VarenummerFieldName">The field name in the table containing the Varenummer.</param>
        ///// <param name="VarenummerImageFieldName">The field name in the table to be filled in with the varenummer barcode image. This column must be of type byte[].</param>
        ///// <param name="ProgressTitle">The title of the progress form shown.</param>
        ///// <param name="ProgressTextFieldName">The field name in the table containing text to display as progress text.</param>
        //private void CreateBarcodeImagesRBA(
        //    DataTable Table,
        //    string VarenummerFieldName,
        //    string VarenummerImageFieldName,
        //    string ProgressTitle,
        //    string ProgressTextFieldName)
        //{
        //    // prepare varenummer barcode object
        //    BarcodeProfessional varenummerBarcode = new BarcodeProfessional();
        //    varenummerBarcode.ForeColor = Color.Black;
        //    varenummerBarcode.AddChecksum = false;
        //    varenummerBarcode.DisplayCode = true;
        //    varenummerBarcode.BarRatio = 2;
        //    varenummerBarcode.Text = "";
        //    varenummerBarcode.AutoSize = true;

        //    // setup progress form
        //    ProgressForm progress = new ProgressForm(ProgressTitle);
        //    progress.ProgressMax = Table.Rows.Count;
        //    progress.Show();

        //    // create barcode images for each varenummer barcode
        //    foreach (DataRow row in Table.Rows)
        //    {
        //        // advance progress bar
        //        progress.StatusText = tools.object2string(row[ProgressTextFieldName]);

        //        // setup varenummer barcode symbology based on bctype (assume custom barcode)
        //        varenummerBarcode.Symbology = Symbology.Code39;

        //        // get the varenummer from table and create the varenummer barcode image
        //        varenummerBarcode.Code = tools.object2string(row[VarenummerFieldName]);
        //        row[VarenummerImageFieldName] = varenummerBarcode.GetBarcodeImage(System.Drawing.Imaging.ImageFormat.Png);
        //    }

        //    progress.Close();
        //}
        //#endregion

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

        //private void chkWithPrintNumOfAndTotal_CheckedChanged(object sender, EventArgs e)
        //{
        //    db.SetConfigString("WasteSheetRptFrm.chkWithPrintNumOfAndTotal", chkWithPrintNumOfAndTotal.Checked);
        //}

        //private void chkPrintWithWeekdays_CheckedChanged(object sender, EventArgs e)
        //{
        //    db.SetConfigString("WasteSheetRptFrm.chkPrintWithWeekdays", chkPrintWithWeekdays.Checked);
        //}

        //private void chkPrintCount_CheckedChanged(object sender, EventArgs e)
        //{
        //    db.SetConfigString("WasteSheetRptFrm.chkPrintCount", chkPrintCount.Checked);
        //}
    }
}