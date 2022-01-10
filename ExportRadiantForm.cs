using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class ExportRadiantForm : Form
    {
        private ExportRSM export = null;

        #region Constructor
        public ExportRadiantForm()
        {
            InitializeComponent();
            export = new ExportRSM();
        }
        #endregion

        #region GenerateFilteredDataTable
        /// Generates a DataTable based on the
        /// current filter setup.
        private DataTable GenerateFilteredDataTable()
        {
            // inform user that calculation is being performed
            statusMsg.Text = db.GetLangString("RSMExportForm.Pleasewait");
            this.Refresh();
            this.Cursor = Cursors.WaitCursor;

            // get barcode
            Nullable<double> barcode = null;
            if(txtBarcode.Text != "")
                barcode = double.Parse(txtBarcode.Text);

            // concatenate date time values for start/end interval
            Nullable<DateTime> startInterval = null;
            Nullable<DateTime> endInterval = null;
            if (dtChangeDateStart.Checked && dtChangeDateEnd.Checked)
            {
                startInterval = DateTime.Parse(
                    dtChangeDateStart.Value.ToString("dd-MM-yyyy") +
                    " " +
                    dtChangedTimeStart.Value.ToString("HH:mm"));
                endInterval = DateTime.Parse(
                    dtChangeDateEnd.Value.ToString("dd-MM-yyyy") +
                    " " +
                    dtChangedTimeEnd.Value.ToString("HH:mm"));
            }
            
            // load filtered data
            DataTable table = export.CreateITTData(
                chkItemsNotUpdatedInRSM.Checked,
                txtSubCategoryStart.Text,
                txtSubCategoryEnd.Text,
                barcode,
                startInterval,
                endInterval,
                chkInitialize.Checked);
            
            // show number of records in data for update and delete
            DataRow[] rows = table.Select("SemiDeleted <> 1");
            DataRow[] rowsForDelete = table.Select("SemiDeleted = 1");
            DataRow[] rowsForIDChange = table.Select("RSMNeedsNewID = 1");
            statusMsg.Text =
                db.GetLangString("RSMExportForm.NumberOfMatchingCriteriaStatusMsg1") + "  " + table.Rows.Count.ToString()+ " "+ 
                string.Format(db.GetLangString("RSMExportForm.NumberOfMatchingCriteriaStatusMsg2"),rowsForDelete.Length) + " / " +
                string.Format(db.GetLangString("RSMExportForm.NumberOfMatchingCriteriaStatusMsg3") , rowsForIDChange.Length );
            this.Cursor = Cursors.Default;

            // return data
            return table;
        }
        #endregion

        #region IsITTUpdate
        /// <summary>
        /// If user has made selections in the GUI that
        /// will export all items to RSM including subcategories,
        /// this method will return false, as we then have an
        /// initialize of RSM (all data sent). If only some data
        /// will be sent, this method returns true.
        /// </summary>
        private bool IsUpdate()
        {

            return !chkInitialize.Checked;

            //if ((!chkItemsNotUpdatedInRSM.Checked) &&
            //    (txtSubCategoryStart.Text == "") &&
            //    (txtSubCategoryEnd.Text == "") &&
            //    (txtBarcode.Text == "") &&
            //    (!dtChangeDateStart.Checked) &&
            //    (!dtChangeDateEnd.Checked) &&
            //    (chkMCT.Checked) &&
            //    (chkTSM.Checked))
            //    return false; // intialize
            //else
            //    return true; // update

        }
        #endregion

        #region Localize
        private void Localize()
        {
#if !FSD
            lbItemsNotUpdatedInRSM.Text = db.GetLangString("RSMExportForm.ItemNoUpdatedLabel");
#else
            lbItemsNotUpdatedInRSM.Text = db.GetLangString("RSMExportForm.ItemNoUpdatedLabel_FSD");
#endif
            lbSubCategoryFrom.Text = db.GetLangString("RSMExportForm.CategoryFromLabel");
            lbSubCategoryTo.Text = db.GetLangString("RSMExportForm.CategoryToLabel");
            lbBarcode.Text = db.GetLangString("RSMExportForm.BarcodeLabel");
            lbItemName.Text = db.GetLangString("RSMExportForm.ItemNameLabel");
            lbChangeDateStart.Text = db.GetLangString("RSMExportForm.ChangedFromDateTimeLabel");
            lbChangeDateEnd.Text = db.GetLangString("RSMExportForm.ChangedToDateTimeLabel");
            lbMCT.Text = db.GetLangString("RSMExportForm.IncludeCategorySetupFileLabel");
            btnClose.Text = db.GetLangString("Application.Close");
            btnExport.Text = db.GetLangString("RSMExportForm.ExportBtn");
            lbTSM.Text = db.GetLangString("RSMExportForm.lbTSM");
            groupItem.Text = db.GetLangString("RSMExportForm.groupItem");
            lbInitialize.Text = db.GetLangString("RSMExportForm.lbInitialize");
        }
        #endregion

        #region SetupControls
        /// <summary>
        /// Sets up various controls.
        /// Should be called from the form load event.
        /// </summary>
        private void SetupControls()
        {
#if FSD
            chkMCT.Visible = false;
            chkMCT.Checked = false;
            chkTSM.Visible = false;
            chkTSM.Checked = false;
            lbMCT.Visible = false;
            lbTSM.Visible = false;
            lbInitialize.Location = lbMCT.Location;
            chkInitialize.Location = chkMCT.Location;
#else
            //20200130 PN
            //chkInitialize.Visible = false;
            chkInitialize.Checked = false;
            //lbInitialize.Visible = false;

            // check in config if a flag has been set to enforce export of subcats
            if (db.GetConfigStringAsBool("ExportRSM.EnforceSubCatExport"))
            {
                chkMCT.Checked = true;
                chkMCT.Enabled = false;
            }
#endif
        }
        #endregion

        #region ToggleControlsOnFSDInitialize
        private void ToggleControlsOnFSDInitialize()
        {
            bool locked = chkInitialize.Checked;
            chkItemsNotUpdatedInRSM.Enabled = !locked;
            btnLookupSubCategoryStart.Enabled = !locked;
            btnLookupSubCategoryEnd.Enabled = !locked;
            btnSalesPackLookup.Enabled = !locked;
            btnSalesPackClear.Enabled = !locked;
            dtChangeDateStart.Enabled = !locked;
            dtChangeDateEnd.Enabled = !locked;
            dtChangedTimeStart.Enabled = !locked;
            dtChangedTimeEnd.Enabled = !locked;
            if (locked)
            {
                chkItemsNotUpdatedInRSM.Checked = false;
                txtSubCategoryStart.Text = "";
                txtSubCategoryEnd.Text = "";
                txtSubCategoryDescStart.Text = "";
                txtSubCategoryDescEnd.Text = "";
                txtBarcode.Text = "";
                txtItemName.Text = "";
                dtChangeDateStart.Checked = false;
                dtChangeDateEnd.Checked = false;
            }
        }
        #endregion

        private void ExportRadiantForm_Load(object sender, EventArgs e)
        {
            GenerateFilteredDataTable(); // update how many ITT records would be exported
            SetupControls();
            Localize();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkItemsNotUpdatedInRSM_CheckedChanged(object sender, EventArgs e)
        {
            // update how many ITT records would be exported
            GenerateFilteredDataTable();
        }

        private void ValidateSelectSubCategoryRange(bool callerIsStart)
        {
            string start = txtSubCategoryStart.Text;
            string end = txtSubCategoryEnd.Text;

            if ((callerIsStart) && (start != ""))
            {
                // if end has an invalid value and start is valid, copy from start
                if ((end == "") || (long.Parse(end) < long.Parse(start)))
                {
                    txtSubCategoryEnd.Text = txtSubCategoryStart.Text;
                    txtSubCategoryDescEnd.Text = txtSubCategoryDescStart.Text;
                }
            }
            else if((!callerIsStart) && (end != ""))
            {
                // if start has an invalid value, copy from end
                if ((start == "") || (long.Parse(start) > long.Parse(end)))
                {
                    txtSubCategoryStart.Text = txtSubCategoryEnd.Text;
                    txtSubCategoryDescStart.Text = txtSubCategoryDescEnd.Text;
                }
            }
            else
            {
                txtSubCategoryStart.Text = "";
                txtSubCategoryDescStart.Text = "";
                txtSubCategoryEnd.Text = "";
                txtSubCategoryDescEnd.Text = "";
            }

            // update num records label
            GenerateFilteredDataTable();
        }

        private void btnLookupSubCategoryFrom_Click(object sender, EventArgs e)
        {
            SubCategoryPopup popup = new SubCategoryPopup();
            popup.SelectedSubCategoryID = txtSubCategoryStart.Text;
            popup.DisplaySelectNoneButton = true;
            if (popup.ShowDialog() == DialogResult.OK)
            {
                txtSubCategoryStart.Text = popup.SelectedSubCategoryID;
                txtSubCategoryDescStart.Text = popup.SelectedSubCategoryDesc;
                ValidateSelectSubCategoryRange(true);
            }
        }

        private void btnLookupSubCategoryTo_Click(object sender, EventArgs e)
        {
            SubCategoryPopup popup = new SubCategoryPopup();
            popup.SelectedSubCategoryID = txtSubCategoryEnd.Text;
            popup.DisplaySelectNoneButton = true;
            if (popup.ShowDialog() == DialogResult.OK)
            {
                txtSubCategoryEnd.Text = popup.SelectedSubCategoryID;
                txtSubCategoryDescEnd.Text = popup.SelectedSubCategoryDesc;
                ValidateSelectSubCategoryRange(false);
            }
        }

        private void btnSalesPackLookup_Click(object sender, EventArgs e)
        {
            SearchForm search = new SearchForm();
            double barcode = 0;
            if(double.TryParse(txtBarcode.Text,out barcode))
                search.SelectedBarcode = barcode;
            if(search.ShowDialog() == DialogResult.OK)
            {
                // get selected barcode
                txtBarcode.Text = search.SelectedBarcode.ToString();

                // get itemname by looking it up from the selected itemid
                txtItemName.Text = ItemDataSet.ItemDataTable.LookupItemName(search.SelectedItemID);

                // update num rows label
                GenerateFilteredDataTable();
            }
        }

        private void btnSalesPackClear_Click(object sender, EventArgs e)
        {
            if (txtBarcode.Text != "")
            {
                txtBarcode.Text = "";
                txtItemName.Text = "";
                // update num rows label
                GenerateFilteredDataTable();
            }
        }

        private void dtChangeDateStart_ValueChanged(object sender, EventArgs e)
        {
            dtChangedTimeStart.Enabled = dtChangeDateStart.Checked;
            dtChangedTimeEnd.Enabled = dtChangeDateStart.Checked;
            dtChangeDateEnd.Checked = dtChangeDateStart.Checked;
            // update num rows label
            GenerateFilteredDataTable();
        }

        private void dtChangeDateEnd_ValueChanged(object sender, EventArgs e)
        {
            dtChangedTimeEnd.Enabled = dtChangeDateEnd.Checked;
            dtChangedTimeStart.Enabled = dtChangeDateEnd.Checked;
            dtChangeDateStart.Checked = dtChangeDateEnd.Checked;
            // update num rows label
            GenerateFilteredDataTable();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string msgSuccess = "";
            string msgError = "";

            // check that output directory exists
            msgError = export.CheckExportDirsExists();
            if (msgError != "")
            {
                // output dir does not exist, stop exporting
                MessageBox.Show(msgError);
                return;
            }

            // export MCT file if selected
            if (chkMCT.Checked)
            {
                msgError = export.ExportMCT(export.CreateMCTData());
                if (msgError != "")
                {
                    // MCT file export error, display the error and stop exporting
                    MessageBox.Show(msgError);
                    return;
                }
                else
                {
                    // MCT file export successful, continue exporting
                    msgSuccess += db.GetLangString("RSMExportForm.MCTXMLfileExportedSuccessfully") + "\n";

                    // reset config flag that enforces subcat export.
                    // export window will close after export, so 
                    if (db.GetConfigStringAsBool("ExportRSM.EnforceSubCatExport"))
                        db.SetConfigString("ExportRSM.EnforceSubCatExport", false);
                }
            }

            // export TSM file if selected
            if (chkTSM.Checked)
            {
                msgError = export.ExportTSM(IsUpdate());
                if (msgError != "")
                {
                    // TSM file export error, display the error and stop exporting
                    MessageBox.Show(msgError);
                    return;
                }
                else
                {
                    // TSM file export successful, continue exporting
                    msgSuccess += db.GetLangString("RSMExportForm.TSMExported") + "\n";
                }
            }

            // export ITT file

            DataTable table = GenerateFilteredDataTable();

            // if no work to do, just exit
            if ((!chkMCT.Checked) && (!chkTSM.Checked) && (table.Rows.Count <= 0))
            {
                MessageBox.Show(db.GetLangString("RSMExportForm.NothingToDoMsg"));
                return;
            }

            if (table.Rows.Count <= 0)
            {
                // no records to export, inform user (still MCT or TSM has data)
                msgSuccess += (db.GetLangString( "RSMExportForm.ITTFileNotCreatedNoItemsSelected")) + "\n";
            }
            else
            {
                msgError = export.ExportITT(table, IsUpdate());
                if (msgError != "")
                {
                    // ITT file export error, display the error and stop exporting
                    MessageBox.Show(msgError);
                    return;
                }
                else
                {
                    // ITT file export successful
                    msgSuccess += (db.GetLangString("RSMExportForm.ITTFileExportedSuccessfully")) + "\n";
                }
            }

            //peter20190604
            export.ExportILT(table, IsUpdate());
            // write semaphore file
            string semErr = export.WriteSemaphoreFile();
            if (semErr != "")
            {
                // error writing semaphore file
                MessageBox.Show(semErr);
                return;
            }

            /// any errors encountered underway will stop and return from export above,
            /// so at this point, all exports should be ok. now we can update/delete
            /// records in the database

            // iterate through the exported items
            foreach (DataRow row in table.Rows)
            {
                // retrieve needed fields values
                int ItemID = int.Parse(row["ItemID"].ToString());
                byte PackType = byte.Parse(row["PackType"].ToString());

                // if record action was update, set UpdateRSM = false in database
                bool updated = ((row["UpdateRSM"] is bool) && (bool.Parse(row["UpdateRSM"].ToString())));
                if (updated)
                    ItemDataSet.SalesPackDataTable.UnsetUpdateRSM(ItemID,PackType);

                // if record action was needsnewid, set RSMNeedsNewID = false in database
                if (tools.object2bool(row["RSMNeedsNewID"]))
                    ItemDataSet.ItemDataTable.UnsetRSMNeedsNewID(ItemID);
            }

            // now we can permanently delete SemiDeleted records
            ItemDataSet.DeleteAllSemiDeleted();

            // done exporting, show success message and close window
            msgSuccess += db.GetLangString("RSMExportForm.DatabaseWasUpdated") + "\n";
            msgSuccess += db.GetLangString("RSMExportForm.ExportCompleteWindowWillNowClose");
            MessageBox.Show(msgSuccess);
            Close();
        }

        private void chkInitialize_CheckedChanged(object sender, EventArgs e)
        {
            ToggleControlsOnFSDInitialize();
        }

        private void chkTSM_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTSM.Checked && AdminDataSet.SiteInformationDataTable.GetSE() == "")
            {
                MessageBox.Show(db.GetLangString("ExportRadiantForm.SEMissing"));
                chkTSM.Checked = false;
            }
        }
    }
}