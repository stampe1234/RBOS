using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace RBOS
{
    public partial class BHHTInvAdjustForm : Form
    {
        // constructor
        public BHHTInvAdjustForm(char ReasonCode)
        {
            InitializeComponent();
            LoadData(ReasonCode);

            // position grid columns (bug in VS2005)
            colAdjustID.DisplayIndex = 0;
            colAdjustDate.DisplayIndex = 1;
            colReasonCode.DisplayIndex = 2;
            colStatus.DisplayIndex = 3;
        }

        #region METHOD: LoadData
        /// <summary>
        /// Loads data and sets up various parts of the GUI.
        /// </summary>
        /// <param name="ReasonCode">
        /// The reason code passed into the constructor
        /// and which is set in the combobox's selected value.
        /// </param>
        private void LoadData(char ReasonCode)
        {
            // set connections
            adapterInvAdjustHeader.Connection = db.Connection;
            adapterLookupInvAdjustType.Connection = db.Connection;
            adapterStatusLookup.Connection = db.Connection;
            adapterBHHTWorksheet.Connection = db.Connection;

            // load data
            adapterInvAdjustHeader.Fill(dsImport.BHHTInvAdjustHeader);
            adapterLookupInvAdjustType.Fill(dsImport.LookupInvAdjustType);
            adapterStatusLookup.Fill(dsImport.LookupStatus);
            adapterBHHTWorksheet.Fill(dsItem.BHHTWorksheet);

            // filter out based on ReasonCode (only way to do it as we want to support all records too)
            if (ReasonCode != 'x')
                bindingInvAdjustHeader.Filter = "ReasonCode = '" + ReasonCode.ToString() + "'";

            // set selected ReasonCode in drop down box
            comboShowType.SelectedValue = ReasonCode.ToString();
        }
        #endregion

        #region METHOD: DeleteData
        /// <summary>
        /// Deletes the selected BHHTInvAdjustHeader record and it's related BHHTInvAdjustDetails records.
        /// </summary>
        /// <returns>True if delete ok. False if not allowed to delete.</returns>
        private void DeleteData()
        {
            if (bindingInvAdjustHeader.Current != null)
            {
                DataRowView row = (DataRowView)bindingInvAdjustHeader.Current;

                // if status of the row is "OPN" (open), the row may be deleted along with its detail records
                if (tools.object2string(row["Status"]) == "OPN")
                {
                    string msg = db.GetLangString("InvAdjustForm.DeleteAdjustDetailsMsg");
                    if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        OleDbCommand cmd = new OleDbCommand("", db.Connection);

                        // delete detail records
                        cmd.CommandText = string.Format(
                            " delete from BHHTInvAdjustDetails where AdjustID = {0} ",
                            row["AdjustID"]);
                        cmd.ExecuteNonQuery();

                        // delete header record
                        cmd.CommandText = string.Format(
                            " delete from BHHTInvAdjustHeader where AdjustID = {0} ",
                            row["AdjustID"]);
                        cmd.ExecuteNonQuery();

                        // reload data
                        char ReasonCode = tools.object2char(comboShowType.SelectedValue);
                        LoadData(ReasonCode);
                    }
                }
                else
                {
                    // status is not "OPN", do not allow delete
                    MessageBox.Show(db.GetLangString("BHHTInvAdjustForm.CannotDeleteBooked"));
                }
            }
        }
        #endregion

        #region METHOD: SaveData
        /// <summary>
        /// Saves any changes to the header table.
        /// </summary>
        private void SaveData()
        {
            DataTable changes = dsImport.BHHTInvAdjustHeader.GetChanges();
            if((changes != null) && (changes.Rows.Count > 0))
                adapterInvAdjustHeader.Update(dsImport.BHHTInvAdjustHeader);
        }
        #endregion

        #region METHOD: BookData
        private void BookData()
        {
            // confirm with user that book is wanted
            string msg = db.GetLangString("InvAdjustForm.BookThisAdjustmentMsg");
            if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            // get AdjustID and ReasonCode for selected header
            if(bindingInvAdjustHeader.Current == null) return;
            bindingInvAdjustHeader.EndEdit();
            DataRowView currHeaderRow = (DataRowView)bindingInvAdjustHeader.Current;
            int AdjustID = tools.object2int(currHeaderRow["AdjustID"]);
            string ReasonCode = currHeaderRow["ReasonCode"].ToString();

            // variables needed more than once
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            OleDbDataAdapter adapter = new OleDbDataAdapter("", db.Connection);

            // load header data
            DataTable tableHeader = new DataTable();
            adapter.SelectCommand.CommandText = string.Format(
                " select * from BHHTInvAdjustHeader " +
                " where (AdjustID = {0}) and (ReasonCode = '{1}') ",
                AdjustID, ReasonCode);
            adapter.Fill(tableHeader);

            // check we have header record and create header row if ok
            if (tableHeader.Rows.Count <= 0) return;
            DataRow headerRow = tableHeader.Rows[0];

            // load detail data
            DataTable tableDetails = new DataTable();
            adapter.SelectCommand.CommandText = string.Format(
                " select * from BHHTInvAdjustDetails where AdjustID = {0} ",
                headerRow["AdjustID"]);
            adapter.Fill(tableDetails);

            // move adjustment data to ItemTransaction
            foreach (DataRow detailRow in tableDetails.Rows)
            {
                // get all values for the new ItemTransaction row
                int ItemID = tools.object2int(detailRow["ItemID"]);
                DateTime PostingDate = tools.object2datetime(headerRow["AdjustDate"]).Date;
                int NumberOf = tools.object2int(detailRow["Quantity"]);
                byte SalesPackType = tools.object2byte(detailRow["PackType"]);
                //byte obsoleteReasonCode = (byte)db.ReasonCodes.None;

                byte TransactionType = (byte)db.TransactionTypes.Adjustment;
                if ((headerRow["ReasonCode"].Equals("w")))
                {
                    TransactionType = (byte)db.TransactionTypes.Waste;
                    NumberOf *= -1;
                }
                else if ((headerRow["ReasonCode"].Equals("a")))
                    TransactionType = (byte)db.TransactionTypes.Adjustment;
                else if ((headerRow["ReasonCode"].Equals("t")))
                {
                    TransactionType = (byte)db.TransactionTypes.Transfer;
                    NumberOf *= -1;
                }
                else if ((headerRow["ReasonCode"].Equals("r")))
                    TransactionType = (byte)db.TransactionTypes.Receive;

                int NoOfSellingUnits = ItemDataSet.LookupPackTypeAmount(SalesPackType) * NumberOf;
                double Amount = ItemDataSet.SupplierItemDataTable.GetSupplierItemPackageCost(ItemID, SalesPackType);
                Amount = Amount * NumberOf;

                // write item transaction record
                ItemDataSet.ItemTransactionDataTable.WriteTransactionRecord(
                    ItemID,
                    PostingDate,
                    TransactionType,
                    NumberOf,
                    Amount,
                    SalesPackType,
                    0,
                    NoOfSellingUnits,
                    0,
                    true);
            }

            // delete BHHT records for this header and its details
            cmd.CommandText = string.Format(
                " delete from BHHTInvAdjustHeader " +
                " where AdjustID = {0} ",
                AdjustID);
            cmd.ExecuteNonQuery();
            cmd.CommandText = string.Format(
                " delete from BHHTInvAdjustDetails " +
                " where AdjustID = {0} ",
                AdjustID);
            cmd.ExecuteNonQuery();

            // show message to user
            MessageBox.Show(db.GetLangString("InvAdjustForm.AdjustmentBookedMsg"));

            // reload data
            char r = tools.object2char(comboShowType.SelectedValue);
            LoadData(r);
        }
        #endregion

        // combobox selected index changed event
        private void comboShowType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // filter/unfilter data
            if (comboShowType.SelectedIndex >= 0)
            {
                if (comboShowType.SelectedValue.ToString() == "x")
                    bindingInvAdjustHeader.Filter = "";
                else
                    bindingInvAdjustHeader.Filter = "ReasonCode = '" + comboShowType.SelectedValue.ToString() + "'";
            }
        }

        // close button click event
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // details button click event
        private void btnDetails_Click(object sender, EventArgs e)
        {
            if(bindingInvAdjustHeader.Current != null)
            {
                DataRowView row = (DataRowView)bindingInvAdjustHeader.Current;

                // get selected header's id
                int id = tools.object2int(row["AdjustID"]);

                // open details form
                BHHTInvAdjustDetailsForm form = new BHHTInvAdjustDetailsForm(id);
                form.ShowDialog(this);
            }
        }

        // grid user deleting row event
        private void gridInvAdjustHeader_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DeleteData();
            e.Cancel = true; // data is deleted directly in database, so skip binder's delete.
        }

        // context menu delete button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        // grid row validated event
        private void gridInvAdjustHeader_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
           SaveData();
        }

        // grid cell painting event - coloring the StatusColor cells
        private void gridInvAdjustHeader_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            tools.PaintStatusCell(
                gridInvAdjustHeader,
                e.ColumnIndex,
                e.RowIndex,
                colStatus.Index,
                colStatusColor.Index);
        }

        // grid cell begin edit event
        private void gridInvAdjustHeader_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (bindingInvAdjustHeader.Current == null) return;

            // if user tries to change adjust date, check the row's status.
            // if stats is "BKD", the record is readonly.
            if (e.ColumnIndex == colAdjustDate.Index)
            {
                DataRowView row = (DataRowView)bindingInvAdjustHeader.Current;
                e.Cancel = (row["Status"].ToString() == "BKD");
            }
        }

        // details, cell double click event
        private void gridInvAdjustHeader_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bindingInvAdjustHeader.Current != null)
            {
                DataRowView row = (DataRowView)bindingInvAdjustHeader.Current;

                // get selected header's id
                int id = tools.object2int(row["AdjustID"]);

                // open details form
                BHHTInvAdjustDetailsForm form = new BHHTInvAdjustDetailsForm(id);
                form.ShowDialog(this);
            }
        }

        // book button click event
        private void btnBook_Click(object sender, EventArgs e)
        {
            BookData();
        }

        private void BHHTInvAdjustForm_Load(object sender, EventArgs e)
        {
            // Localization

            lbShowType.Text = db.GetLangString("InvAdjustForm.ShowLabel");
            btnClose.Text = db.GetLangString("Application.Close");
            btnDetails.Text = db.GetLangString("InvAdjustForm.DetailsLabel");
            btnBook.Text = db.GetLangString("InvAdjustForm.BookLabel");

            colAdjustID.HeaderText = db.GetLangString("InvAdjustForm.AdjustIdLabel");
            colAdjustDate.HeaderText = db.GetLangString("InvAdjustForm.AdjustDateLabel");
            colReasonCode.HeaderText = db.GetLangString("InvAdjustForm.ReasonCodeLabel");
            colStatus.HeaderText = db.GetLangString("InvAdjustForm.StatusLabel");

        }

        private void btnGetPejSale_Click(object sender, EventArgs e)
        {
            if (bindingInvAdjustHeader.Current != null)
            {
                DataRowView row = (DataRowView)bindingInvAdjustHeader.Current;

                // get selected header's id
                int id = tools.object2int(row["AdjustID"]);

                // open details form
                BHHTInvAdjustDetailsForm form = new BHHTInvAdjustDetailsForm(id);
                form.ShowDialog(this);
            }
        }
    }
}