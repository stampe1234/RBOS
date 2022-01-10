using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class ExportFVDFrm : Form
    {
        // constructor
        public ExportFVDFrm()
        {
            InitializeComponent();
        }

        /// Generates a DataTable based on the
        /// current filter setup.
        private DataTable GenerateFilteredDataTable()
        {
            // inform user that calculation is being performed
            statusMsg.Text = db.GetLangString("ExportFVDFrm.Pleasewait");
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
            DataTable table = ExportFVD.SelectFVDData(
                chkItemsNotUpdatedInStations.Checked,
                txtSubCategoryStart.Text,
                txtSubCategoryEnd.Text,
                barcode,
                startInterval,
                endInterval);

            // show number of records in data for update and delete
            statusMsg.Text = string.Format("{0} {1} ({2} {3})",
                db.GetLangString("ExportFVDFrm.NumberOfMatchingCriteriaStatusMsg1"),
                table.Rows.Count.ToString(),
                ItemDataSet.FSDDeletedSupplierItemDataTable.GetNumNonHistoricRecords(),
                db.GetLangString("ExportFVDFrm.NumberOfMatchingCriteriaStatusMsg2"));
            
            this.Cursor = Cursors.Default;

            // return data
            return table;
        }

        private string BuildCriteriaString()
        {
            string criteria = "";

            criteria += db.GetLangString("ExportFVDFrm.ItemNoUpdatedLabel") + ": ";
            criteria += chkItemsNotUpdatedInStations.Checked ? "Ja" : "Nej";
            criteria += "\n";

            criteria += db.GetLangString("ExportFVDFrm.CategoryFromLabel") + ": ";
            criteria += txtSubCategoryDescStart.Text;
            criteria += "\n";

            criteria += db.GetLangString("ExportFVDFrm.CategoryToLabel") + ": ";
            criteria += txtSubCategoryDescEnd.Text;
            criteria += "\n";

            criteria += db.GetLangString("ExportFVDFrm.BarcodeLabel") + ": ";
            criteria += txtBarcode.Text;
            criteria += "\n";

            criteria += db.GetLangString("ExportFVDFrm.ItemNameLabel") + ": ";
            criteria += txtItemName.Text;
            criteria += "\n";

            criteria += db.GetLangString("ExportFVDFrm.ChangedFromDateTimeLabel") + ": ";
            if (dtChangeDateStart.Checked)
            {
                criteria += dtChangeDateStart.Value.ToString("dd-MM-yyyy") + " ";
                criteria += dtChangedTimeStart.Value.ToString("HH:mm");
            }
            criteria += "\n";

            criteria += db.GetLangString("ExportFVDFrm.ChangedToDateTimeLabel") + ": ";
            if (dtChangeDateEnd.Checked)
            {
                criteria += dtChangeDateEnd.Value.ToString("dd-MM-yyyy") + " ";
                criteria += dtChangedTimeEnd.Value.ToString("HH:mm");
            }
            criteria += "\n";

            return criteria;
        }

        // form load event
        private void ExportFVDFrm_Load(object sender, EventArgs e)
        {
            // update how many ITT records would be exported
            GenerateFilteredDataTable();

            // localization
            lbItemsNotUpdatedInRSM.Text = db.GetLangString("ExportFVDFrm.ItemNoUpdatedLabel");
            lbSubCategoryFrom.Text = db.GetLangString("ExportFVDFrm.CategoryFromLabel");
            lbSubCategoryTo.Text = db.GetLangString("ExportFVDFrm.CategoryToLabel");
            lbBarcode.Text = db.GetLangString("ExportFVDFrm.BarcodeLabel");
            lbItemName.Text = db.GetLangString("ExportFVDFrm.ItemNameLabel");
            lbChangeDateStart.Text = db.GetLangString("ExportFVDFrm.ChangedFromDateTimeLabel");
            lbChangeDateEnd.Text = db.GetLangString("ExportFVDFrm.ChangedToDateTimeLabel");
            btnClose.Text = db.GetLangString("Application.Close");
            btnExport.Text = db.GetLangString("ExportFVDFrm.ExportBtn");
            groupItem.Text = db.GetLangString("ExportFVDFrm.groupItem");
        }

        // close button event
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // UpdateRSM checkbox changed event
        private void chkItemsNotUpdatedInRSM_CheckedChanged(object sender, EventArgs e)
        {
            // update how many records would be exported
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

        // subcategory start lookup button click event
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
        // subcategory end lookup button click event
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

        // salespack lookup button click event
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

        // salespack clear button click event
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

        // export button click event
        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable data = GenerateFilteredDataTable();
            string criteria = BuildCriteriaString();
            if (!ExportFVD.CreateFVDRecords(data, criteria))
            {
                MessageBox.Show(ExportFVD.LastError);
                return;
            }

            // open ExportFVDHeader window
            (this.MdiParent as MainForm).OpenMenuWindow("TreeMenu.ExportFVDHeader");

            Close();
        }
    }
}