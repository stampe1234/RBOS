using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class ExportFVDHeader : Form
    {
        #region ExportFVDHeader
        public ExportFVDHeader()
        {
            InitializeComponent();

            int index = 0;
            colID.DisplayIndex = index++;
            colExportDateTime.DisplayIndex = index++;
            colSentOutDateTime.DisplayIndex = index++;
            colFilename.DisplayIndex = index++;
            colNumDetailRecords.DisplayIndex = index++;
            colCalcNumDeletedSupplierItems.DisplayIndex = index++;
            colCriteria.DisplayIndex = index++;
        }
        #endregion

        #region LoadData
        private void LoadData()
        {
            adapterExportFVDHeader.Connection = db.Connection;
            adapterExportFVDHeader.Fill(dsItem.ExportFVDHeader);
            dsItem.ExportFVDHeader.CalculateNumDeletedSupplierItems();
        }
        #endregion

        #region DeleteSelectedRecord
        /// <summary>
        /// Deletes the selected header record and it's
        /// detail records, if user confirms.
        /// </summary>
        private void DeleteSelectedRecord()
        {
            try
            {
                if (bindingExportFVDHeader.Current == null) return;
                DataRowView row = (DataRowView)bindingExportFVDHeader.Current;
                string msg = "";

                // check that the selected header record is not sent out yet
                if (!tools.IsNullOrDBNull(row["SentOutDateTime"]))
                {
                    msg = db.GetLangString("ExportFVDHeader.CannotDeleteFVDData");
                    MessageBox.Show(msg);
                    return;
                }

                // confirm that delete is what user want
                msg = db.GetLangString("ExportFVDHeader.ConfirmDeleteFVDData");
                if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                db.StartTransaction();

                // delete detail records
                int HeaderID = tools.object2int(row.Row["ID"]);
                ItemDataSet.ExportFVDDetailsDataTable.DeleteRecords(HeaderID);

                // delete header record
                bindingExportFVDHeader.RemoveCurrent();
                adapterExportFVDHeader.SetTransaction(db.CurrentTransaction);
                adapterExportFVDHeader.Update(dsItem.ExportFVDHeader);

                // commit changes
                db.CommitTransaction();
            }
            finally
            {
                if (db.CurrentTransaction != null)
                {
                    db.RollbackTransaction();
                    bindingExportFVDHeader.ResetCurrentItem();
                }
            }
        }
        #endregion

        #region OpenDetails
        private void OpenDetails()
        {
            // open detail form for the selected header
            if (bindingExportFVDHeader.Current == null) return;
            DataRowView row = (DataRowView)bindingExportFVDHeader.Current;
            int HeaderID = tools.object2int(row[colID.Index]);
            ExportFVDDetails details = new ExportFVDDetails(HeaderID);
            if (details.ShowDialog(this) == DialogResult.OK)
            {
                if (!details.Readonly)
                {
                    // reload header data and reposition on the same record in the grid
                    int pos = bindingExportFVDHeader.Position;
                    LoadData();
                    if ((pos >= 0) && (pos < bindingExportFVDHeader.Count))
                        bindingExportFVDHeader.Position = pos;
                }
            }
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ExportFVDHeader_Load(object sender, EventArgs e)
        {
            LoadData();

            colID.HeaderText = db.GetLangString("ExportFVDHeader.colID");
            colExportDateTime.HeaderText = db.GetLangString("ExportFVDHeader.colIDcolExportDateTime");
            colSentOutDateTime.HeaderText = db.GetLangString("ExportFVDHeader.colSentOutDateTime");
            colFilename.HeaderText = db.GetLangString("ExportFVDHeader.colFilename");
            colNumDetailRecords.HeaderText = db.GetLangString("ExportFVDHeader.colNumDetailRecords");
            colCalcNumDeletedSupplierItems.HeaderText = db.GetLangString("ExportFVDHeader.colCalcNumDeletedSupplierItems");
            colCriteria.HeaderText = db.GetLangString("ExportFVDHeader.colCriteria");
            btnDelete.Text = db.GetLangString("Application.Delete");
            btnClose.Text = db.GetLangString("Application.Close");
            btnDetails.Text = db.GetLangString("Application.Details");
        }

        private void grid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = true; // we do this manually
            DeleteSelectedRecord();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedRecord();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            OpenDetails();
        }

        private void grid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void grid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.RowIndex >= grid.Rows.Count) return;
            OpenDetails();
        }
    }
}