using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class ExportFVDDetails : Form
    {
        private int HeaderID = 0;

        #region Readonly
        private bool _Readonly = true;
        public bool Readonly
        {
            get { return _Readonly; }
        }
        #endregion

        #region Constructor
        public ExportFVDDetails(int HeaderID)
        {
            InitializeComponent();

            this.HeaderID = HeaderID;
            _Readonly = !ItemDataSet.ExportFVDHeaderDataTable.IsUnsentRecord(HeaderID);
            this.DialogResult = DialogResult.Cancel;
            LoadData();

            if (Readonly)
                btnSaveClose.Enabled = false;

            int index = 0;
            colStregkode.DisplayIndex = index++;
            colVaretekst.DisplayIndex = index++;
            colKostpris.DisplayIndex = index++;
            colSalgspris.DisplayIndex = index++;
            colFutureSalesPriceDate.DisplayIndex = index++;
            colPackType.DisplayIndex = index++;
            colLeverandoernr.DisplayIndex = index++;
            colBestillnr.DisplayIndex = index++;
            colKolli.DisplayIndex = index++;

            index = 0;
            colSupplierNo_udmeldte.DisplayIndex = index++;
            colSupplierName_udmeldte.DisplayIndex = index++;
            colOrderingNumber_udmeldte.DisplayIndex = index++;
            colKolliSize_udmeldte.DisplayIndex = index++;
            colPackageCost_udmeldte.DisplayIndex = index++;
            colPackageUnitCost_udmeldte.DisplayIndex = index++;
        }
        #endregion

        #region LoadData
        private void LoadData()
        {
            // load export fvd details data
            adapterExportFVDDetails.Connection = db.Connection;
            adapterExportFVDDetails.Fill(dsItem.ExportFVDDetails, HeaderID);

            // load deleted supplier items
            adapterFSDDeletedSupplierItem.Connection = db.Connection;
            if (Readonly)
                adapterFSDDeletedSupplierItem.Fill_WithLookups_ByHeaderID(dsItem.FSDDeletedSupplierItem, HeaderID);
            else
                adapterFSDDeletedSupplierItem.Fill_WithLookups_HeaderIDNULL(dsItem.FSDDeletedSupplierItem);
        }
        #endregion

        #region SaveData
        private void SaveData()
        {
            adapterExportFVDDetails.Update(dsItem.ExportFVDDetails);
            adapterFSDDeletedSupplierItem.Update(dsItem.FSDDeletedSupplierItem);
            ItemDataSet.ExportFVDHeaderDataTable.RecalculateAndWriteNumDetailRecords(HeaderID); // recalc detail count in header
        }
        #endregion

        #region SaveAndClose
        private void SaveAndClose()
        {
            SaveData();
            this.DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        #region CreateFVDFile
        private void CreateFVDFile()
        {
            SaveData();
            if (ExportFVD.CreateFVDFile(HeaderID))
            {
                string msg = db.GetLangString("ExportFVDDetails.FVDFileCreatedWindowsClosing");
                MessageBox.Show(msg);
                SaveAndClose();
            }
            else
            {
                MessageBox.Show(ExportFVD.LastError);
            }
        }
        #endregion

        #region CreateCSVFile
        private void CreateCSVFile()
        {
            SaveData();
            if (ExportFVD.CreateFVDFileAsCSV(HeaderID))
            {
                string msg = db.GetLangString("ExportFVDDetails.FVDFileAsCSVCreatedWindowsClosing");
                MessageBox.Show(msg);
                SaveAndClose();
            }
            else
            {
                MessageBox.Show(ExportFVD.LastError);
            }
        }
        #endregion

        #region Print
        private void Print(bool Preview)
        {
            SaveData();
            ExportFVDRpt report = new ExportFVDRpt();

            // load report data
            ItemDataSetTableAdapters.ExportFVDReportHeaderTableAdapter adapterHeader =
                new RBOS.ItemDataSetTableAdapters.ExportFVDReportHeaderTableAdapter();
            ItemDataSetTableAdapters.ExportFVDReportDetailsTableAdapter adapterDetails =
                new RBOS.ItemDataSetTableAdapters.ExportFVDReportDetailsTableAdapter();
            ItemDataSet ds = new ItemDataSet();
            adapterHeader.Fill(ds.ExportFVDReportHeader, HeaderID);
            adapterDetails.Fill(ds.ExportFVDReportDetails, HeaderID);

            // fill additional header data
            ds.ExportFVDReportHeader.SetCalcNumDeletedSupplierItems();

            // set additional header information in the report
            tools.SetReportSiteInformation(report);
            
            // assign data to the report and print it
            report.SetDataSource(ds);
            tools.Print(report, Preview);
        }
        #endregion

        private void ExportFVDDetails_Load(object sender, EventArgs e)
        {
            this.Text = db.GetLangString("ExportFVDDetails.Title");
            btnCancel.Text = db.GetLangString("Application.Cancel");
            btnSaveClose.Text = db.GetLangString("Application.SaveClose");
            colStregkode.HeaderText = db.GetLangString("ExportFVDDetails.colStregkode");
            colVaretekst.HeaderText = db.GetLangString("ExportFVDDetails.colVaretekst");
            colKostpris.HeaderText = db.GetLangString("ExportFVDDetails.colKostpris");
            colSalgspris.HeaderText = db.GetLangString("ExportFVDDetails.colSalgspris");
            colLeverandoernr.HeaderText = db.GetLangString("ExportFVDDetails.colLeverandoernr");
            colBestillnr.HeaderText = db.GetLangString("ExportFVDDetails.colBestillnr");
            colKolli.HeaderText = db.GetLangString("ExportFVDDetails.colKolli");
            colFutureSalesPriceDate.HeaderText = db.GetLangString("ExportFVDDetails.colFutureSalesPriceDate");
            colPackType.HeaderText = db.GetLangString("ExportFVDDetails.colPackType");
            colSupplierNo_udmeldte.HeaderText = db.GetLangString("ExportFVDDetails.colSupplierNo_udmeldte");
            colSupplierName_udmeldte.HeaderText = db.GetLangString("ExportFVDDetails.colSupplierName_udmeldte");
            colOrderingNumber_udmeldte.HeaderText = db.GetLangString("ExportFVDDetails.colOrderingNumber_udmeldte");
            colKolliSize_udmeldte.HeaderText = db.GetLangString("ExportFVDDetails.colKolliSize_udmeldte");
            colPackageCost_udmeldte.HeaderText = db.GetLangString("ExportFVDDetails.colPackageCost_udmeldte");
            colPackageUnitCost_udmeldte.HeaderText = db.GetLangString("ExportFVDDetails.colPackageUnitCost_udmeldte");
            lbUdmeldteBestillingsnumre.Text = db.GetLangString("ExportFVDDetails.lbUdmeldteBestillingsnumre");
            btnCreateFVDFile.Text = db.GetLangString("ExportFVDDetails.btnCreateFVDFile");
            btnCreateCSVFile.Text = db.GetLangString("ExportFVDDetails.btnCreateCSVFile");
            btnPrint.Text = db.GetLangString("Application.ReportPrint");
            btnPreview.Text = db.GetLangString("Application.ReportPreview");
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            SaveAndClose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void grid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (Readonly)
                e.Cancel = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print(false);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Print(true);
        }

        private void btnCreateFVDFile_Click(object sender, EventArgs e)
        {
            CreateFVDFile();
        }

        private void gridUdmeldte_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (Readonly)
                e.Cancel = true;
            else
            {
                string msg = db.GetLangString("ExportFVDDetails.ConfirmDeleteSupplierNumber").Replace("\\n","\n");
                if (MessageBox.Show(this, msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    e.Cancel = true;
            }
        }

        private void btnCreateCSVFile_Click(object sender, EventArgs e)
        {
            CreateCSVFile();
        }       
    }
}