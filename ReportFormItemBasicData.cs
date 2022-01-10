using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.OleDb;
using Neodynamic.WinControls.BarcodeProfessional;

namespace RBOS
{
    public partial class ReportFormItemBasicData : Form
    {
        public enum ReportMode
        {
            BasicData,
            ShelfLabels
        }

        private string selectedSubCategoryID = "";
        private string selectedSubCategoryDesc = "";
        private ReportMode mode;

        public ReportFormItemBasicData(ReportMode mode)
        {
            InitializeComponent();
            this.mode = mode;

            this.Text = db.GetLangString("TreeMenu030906");

            // if this is shelflabels, hide some controls
            if (mode == ReportMode.ShelfLabels)
            {
                chkPosUpd.Visible = false;
                lbPosUpd.Visible = false;
                chkDisktilbud.Visible = false;
                lbDisktilbud.Visible = false;
            }
        }

        /// <summary>
        /// Prepares report for printing.
        /// </summary>
        /// <returns>True if ready, false if not.</returns>
        private bool PreparePrintBasicData()
        {
            // apply query filter
            string sql = adapterItemBasicData.GetOriginalSelectCommand();
            sql = ApplyQueryFilter(sql);
            adapterItemBasicData.SetSelectCommand(sql);

            // load data
            adapterItemBasicData.Connection = db.Connection;
            adapterItemBasicData.Fill(dsReport.ItemBasicData);

            // check that any data were loaded
            if (dsReport.ItemBasicData.Rows.Count <= 0)
            {
                MessageBox.Show(db.GetLangString("Application.NoDataToPrint"));
                return false;
            }

            // set report's data source
            reportItemBasicData.SetDataSource((DataTable)dsReport.ItemBasicData);

            // Site information
            tools.SetReportSiteInformation(reportItemBasicData);

            // set non-bound report labels...
            ReportObjects reportObjects = reportItemBasicData.ReportDefinition.ReportObjects;
            // subcategory
            if (selectedSubCategoryID != "")
                ((TextObject)reportObjects["txtSubCategory"]).Text = selectedSubCategoryDesc;
            else
                ((TextObject)reportObjects["txtSubCategory"]).Text = "-";
            // date time from
            if (dtChangeDateStart.Checked)
            {
                ((TextObject)reportObjects["txtDateTimeFrom"]).Text =
                    dtChangeDateStart.Value.ToString("dd-MM-yyyy") + " " + dtChangedTimeStart.Value.ToString("HH:mm");
            }
            else
                ((TextObject)reportObjects["txtDateTimeFrom"]).Text = "-";
            // date time to
            if (dtChangeDateEnd.Checked)
            {
                ((TextObject)reportObjects["txtDateTimeTo"]).Text =
                    dtChangeDateEnd.Value.ToString("dd-MM-yyyy") + " " + dtChangedTimeEnd.Value.ToString("HH:mm");
            }
            else
                ((TextObject)reportObjects["txtDateTimeTo"]).Text = "-";
            // pos updated flag
            if (chkPosUpd.CheckState != CheckState.Indeterminate)
            {
                ((TextObject)reportObjects["txtPosUpdated"]).Text =
                    chkPosUpd.Checked ? db.GetLangString("Application.Yes") : db.GetLangString("Application.No");
            }
            else
                ((TextObject)reportObjects["txtPosUpdated"]).Text = "-";
            // shelf label updated
            if (chkShelfLabelUpd.CheckState != CheckState.Indeterminate)
            {
                ((TextObject)reportObjects["txtShelfUpdated"]).Text =
                    chkShelfLabelUpd.Checked ? db.GetLangString("Application.Yes") : db.GetLangString("Application.No");
            }
            else
                ((TextObject)reportObjects["txtShelfUpdated"]).Text = "-";

            // ready for printing
            return true;
        }

        /// <summary>
        /// Prepares report for printing.
        /// </summary>
        /// <returns>True if ready, false if not.</returns>
        private bool PreparePrintShelfLabels()
        {
            // apply query filter
            string sql = adapterSalesPack.GetOriginalSelectCommand();
            sql = ApplyQueryFilter(sql);
            sql += " ORDER BY SalesPack.ItemID ";
            adapterSalesPack.SetSelectCommand(sql);

            // load data
            adapterSalesPack.Connection = db.Connection;
            adapterSalesPack.Fill( dsReport.SalesPack );

            // check that any data were loaded
            if (dsReport.SalesPack.Rows.Count <= 0)
            {
                MessageBox.Show(db.GetLangString("Application.NoDataToPrint"));
                return false;
            }

            // prepare barcode for printing
            BarcodeProfessional barcode = new BarcodeProfessional();
            barcode.ForeColor = Color.Black;
            barcode.AddChecksum = false;
            barcode.DisplayCode = true;
            //barcode.BarWidth = 1;
            //barcode.BarHeight = 40;
            barcode.BarRatio = 2;
            barcode.Text = "";
            barcode.AutoSize = true;
            //barcode.AntiAlias = true;

            // setup progress form
            ProgressForm progress = new ProgressForm(db.GetLangString("ReportFormItemBasicData.CreatingShelfLables"));
            progress.ProgressMax = dsReport.SalesPack.Rows.Count;
            progress.Show();

            // create barcode images for each barcode
            foreach (DataRow row in dsReport.SalesPack.Rows)
            {
                // advance progress bar
                progress.StatusText = tools.object2string(row["ReceiptText"]);

                // setup barcode further
                if (tools.object2int(row["BCType"]) == (int)Barcode.Types.EAN8)
                    barcode.Symbology = Symbology.Ean8;
                else if (tools.object2int(row["BCType"]) == (int)Barcode.Types.EAN13)
                    barcode.Symbology = Symbology.Ean13;
                else // custom
                {
                    barcode.Symbology = Symbology.Code39;
                    //barcode.Symbology = Symbology.Industrial2of5;
                    //barcode.Symbology = Symbology.Interleaved2of5; // appends a 0 if less than 4 digits
                }

                // get the barcode from table and create the barcode image
                barcode.Code = tools.object2string(row["Barcode"]);
                row["BarcodeImage"] = barcode.GetBarcodeImage(System.Drawing.Imaging.ImageFormat.Png);
            }

            progress.Close();
            
            // set report's data source
            reportItemShelfLabels.SetDataSource((DataTable)dsReport.SalesPack);            
            return true;
        }

        /// <summary>
        /// Apply filters from GUI on the provided sql and return it.
        /// </summary>
        private string ApplyQueryFilter(string sql)
        {
            // concatenate date time values for start/end interval
            DateTime startInterval = DateTime.Parse(
                dtChangeDateStart.Value.ToString("dd-MM-yyyy") +
                " " +
                dtChangedTimeStart.Value.ToString("HH:mm"));
            DateTime endInterval = DateTime.Parse(
                dtChangeDateEnd.Value.ToString("dd-MM-yyyy") +
                " " +
                dtChangedTimeEnd.Value.ToString("HH:mm"));

            // append filter clauses to SQL where needed
            if (selectedSubCategoryID != "")
                sql += string.Format(" AND (Item.SubCategory = '{0}') ", selectedSubCategoryID);
            if (chkPosUpd.CheckState != CheckState.Indeterminate)
                sql += string.Format(" AND (SalesPack.UpdateRSM = {0}) ", chkPosUpd.Checked ? 1 : 0);
            if (chkShelfLabelUpd.CheckState != CheckState.Indeterminate)
                sql += string.Format(" AND (SalesPack.UpdateShelfLabel = {0}) ", chkShelfLabelUpd.Checked ? 1 : 0);
            if (dtChangeDateStart.Checked)
                sql += string.Format(" AND (Item.LastChangeDateTime >= '{0}') ", startInterval);
            if (dtChangeDateEnd.Checked)
                sql += string.Format(" AND (Item.LastChangeDateTime <= '{0}') ", endInterval);
            if (chkDisktilbud.Checked)
            {
                sql += string.Format(" AND (Item.DisktilbudFraDato is not null) ");
                sql += string.Format(" AND (Item.DisktilbudTilDato is not null) ");
            }
            return sql;
        }

        // btnPrint click event
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (mode == ReportMode.BasicData)
            {
                if (PreparePrintBasicData())
                {
                    // show print dialog file, and if user clicks Print,
                    // take the settings from the dialog and setup the
                    // report to print directly to the printer using the
                    // user's selections
                    printDialog1.AllowPrintToFile = false;
                    if (printDialog1.ShowDialog(this) == DialogResult.OK)
                    {
                        // use selected printer
                        reportItemBasicData.PrintOptions.PrinterName =
                            printDialog1.PrinterSettings.PrinterName;
                        // use selected paper orientation (portrait/landscape)
                        if (printDialog1.PrinterSettings.DefaultPageSettings.Landscape)
                            reportItemBasicData.PrintOptions.PaperOrientation =
                                CrystalDecisions.Shared.PaperOrientation.Landscape;
                        else
                            reportItemBasicData.PrintOptions.PaperOrientation =
                                CrystalDecisions.Shared.PaperOrientation.Landscape;

                        
                        // finally collect the user's selection of
                        // number of copies, collation, to/from page,
                        // and print the page to the printer
                        reportItemBasicData.PrintToPrinter(
                            printDialog1.PrinterSettings.Copies,
                            printDialog1.PrinterSettings.Collate,
                            printDialog1.PrinterSettings.FromPage,
                            printDialog1.PrinterSettings.ToPage);
                    }
                }
            }
            else if (mode == ReportMode.ShelfLabels)
            {
                if (PreparePrintShelfLabels())
                {
                    // show print dialog file, and if user clicks Print,
                    // take the settings from the dialog and setup the
                    // report to print directly to the printer using the
                    // user's selections
                    printDialog1.AllowPrintToFile = false;
                    if (printDialog1.ShowDialog(this) == DialogResult.OK)
                    {
                        // use selected printer
                        reportItemShelfLabels.PrintOptions.PrinterName =
                            printDialog1.PrinterSettings.PrinterName;
                        // always Portrait
                        reportItemShelfLabels.PrintOptions.PaperOrientation =
                                CrystalDecisions.Shared.PaperOrientation.Portrait;                        
                        if (db.GetConfigStringAsInt("LabelReport.Topmargin") != 0)
                        {
                            CrystalDecisions.Shared.PageMargins margin;
                            margin = reportItemShelfLabels.PrintOptions.PageMargins;
                            margin.topMargin = db.GetConfigStringAsInt("LabelReport.Topmargin");
                            reportItemShelfLabels.PrintOptions.ApplyPageMargins(margin);
                        }
                                                // finally collect the user's selection of
                        // number of copies, collation, to/from page,
                        // and print the page to the printer
                        reportItemShelfLabels.PrintToPrinter(
                            printDialog1.PrinterSettings.Copies,
                            printDialog1.PrinterSettings.Collate,
                            printDialog1.PrinterSettings.FromPage,
                            printDialog1.PrinterSettings.ToPage);

                        // ask user to update db with shelf label printed
                        RemoveShelfLabelFlagInDB();
                    }
                }
            }
        }

        // btnPreview click event
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if(mode == ReportMode.BasicData)
            {
                // open report preview form
                if (PreparePrintBasicData())
                {
                    ReportPreview printForm =
                        new ReportPreview(reportItemBasicData);
                    printForm.ShowDialog();
                }
            }
            else if (mode == ReportMode.ShelfLabels)
            {
                if (PreparePrintShelfLabels())
                {
                    ReportPreview printForm =
                            new ReportPreview(reportItemShelfLabels);
                    printForm.ShowDialog();

                    // ask user to update db with shelf label printed
                    RemoveShelfLabelFlagInDB();
                }
            }
        }

        /// <summary>
        /// Sets UpdateShelfLabel flag = false for all salespacks in
        /// the loaded table dsReport.SalesPack
        /// </summary>
        private void RemoveShelfLabelFlagInDB()
        {
            string msg = db.GetLangString("ReportFormItemBasicData.UpdateAsPrinted");
            if (MessageBox.Show(msg,"",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataRow row in dsReport.SalesPack.Rows)
                {
                    if ((row.RowState != DataRowState.Deleted) &&
                        (row.RowState != DataRowState.Detached))
                    {
                        string sql = string.Format(
                            " update SalesPack set UpdateShelfLabel = 0 where ItemID = {0} and PackType = {1} ",
                            row["ItemID"], row["PackType"]);
                        OleDbCommand cmd = new OleDbCommand(sql, db.Connection);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // btnClose click event
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // btnSubCategory click event
        private void btnSubCategory_Click(object sender, EventArgs e)
        {
            SubCategoryPopup subcat = new SubCategoryPopup();
            subcat.DisplaySelectNoneButton = true;
            if (subcat.ShowDialog() == DialogResult.OK)
            {
                selectedSubCategoryID = subcat.SelectedSubCategoryID;
                selectedSubCategoryDesc = subcat.SelectedSubCategoryDesc;
                if (selectedSubCategoryDesc == null) selectedSubCategoryDesc = "";
                txtSubCategory.Text = selectedSubCategoryDesc;
            }
        }

        private void dtChangeDateStart_ValueChanged(object sender, EventArgs e)
        {
            dtChangedTimeStart.Enabled = dtChangeDateStart.Checked;
        }

        private void dtChangeDateEnd_ValueChanged(object sender, EventArgs e)
        {
            dtChangedTimeEnd.Enabled = dtChangeDateEnd.Checked;
        }

        private void ReportFormItemBasicData_Load(object sender, EventArgs e)
        {
            // localization
            lbSubCategory.Text = db.GetLangString("ReportItemBasForm.SubcategoryLabel");
            lbChangeDateStart.Text = db.GetLangString("ReportItemBasForm.ChangedDateTimeFromLabel");
            lbChangeDateEnd.Text = db.GetLangString("ReportItemBasForm.ChangedDateTimeToLabel");
            lbPosUpd.Text = db.GetLangString("ReportItemBasForm.RSMNotUpdatedLabel");
            lbShelfLabelUpd.Text = db.GetLangString("ReportItemBasForm.ShelfLabelNeededLabel");
            btnClose.Text = db.GetLangString("Application.Close");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");
            lbDisktilbud.Text = db.GetLangString("ReportFormItemBasicData.chkDisktilbud");
        }
    }
}