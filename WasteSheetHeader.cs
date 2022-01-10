using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class WasteSheetHeader : Form
    {
        public WasteSheetHeader()
        {
            InitializeComponent();

            // localization
            colName.HeaderText = db.GetLangString("WasteSheetHeader.colName");
            colNumDetailRecords.HeaderText = db.GetLangString("WasteSheetHeader.colNumDetailRecords");
            btnClose.Text = db.GetLangString("Application.Close");
            btnEdit.Text = db.GetLangString("Application.Edit");
            btnDelete.Text = db.GetLangString("Application.Delete");
            btnNew.Text = db.GetLangString("Application.New");
            btnReport.Text = db.GetLangString("Application.Report");
        }

        private void LoadData()
        {
            adapterWasteSheetLookups.Connection = db.Connection;
#if RBA || DETAIL
            adapterWasteSheetLookups.FillRBA(dsItem.WasteSheetHeaderLookups);
#else
            adapterWasteSheetLookups.Fill(dsItem.WasteSheetHeaderLookups);
#endif

            adapterWasteSheetHeader.Connection = db.Connection;
            adapterWasteSheetHeader.Fill(dsItem.WasteSheetHeader);
        }

        #region OpenDetail
        /// <summary>
        /// Opens waste details form. Creates a new header record if requested.
        /// </summary>
        /// <param name="CreateNew"></param>
        private void OpenDetail(bool CreateNew)
        {
            int ID = 0;

            if (CreateNew)
            {
                // create a new waste sheet header and get the ID
                ID = ItemDataSet.WasteSheetHeaderDataTable.CreateNewRecord();
            }
            else
            {
                // get ID of currently selected waste sheet
                if (bindingWasteSheetHeader.Current == null) return;
                DataRowView row = (DataRowView)bindingWasteSheetHeader.Current;
                ID = tools.object2int(row["ID"]);
            }

            // open details form
            if (ID > 0)
            {
#if !RBA && !DETAIL
                WasteSheetDetails details = new WasteSheetDetails(ID);
#else
                WasteSheetDetailsRBA details = new WasteSheetDetailsRBA(ID);
#endif
                if (details.ShowDialog(this) == DialogResult.OK)
                {
                    // reload data from disk and reposition on current record
                    int Pos = bindingWasteSheetHeader.Position;
                    LoadData();
                    if ((Pos >= 0) && (Pos < bindingWasteSheetHeader.Count))
                        bindingWasteSheetHeader.Position = Pos;
                }
                else
                {
                    if (CreateNew)
                    {
                        // a new header record was created and user selected cancel,
                        // so we must delete the header record
                        ItemDataSet.WasteSheetHeaderDataTable.DeleteRecord(ID);
                    }
                }
            }
        }
        #endregion

        private void Delete()
        {
            if (bindingWasteSheetHeader.Current == null) return;
            string msg = db.GetLangString("WasteSheetHeader.DeleteWasteSheet");
            if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataRowView row = (DataRowView)bindingWasteSheetHeader.Current;
                int ID = tools.object2int(row["ID"]);
                ItemDataSet.WasteSheetHeaderDataTable.DeleteRecord(ID);
                bindingWasteSheetHeader.RemoveCurrent();
            }
        }

        private void OpenReportForm()
        {
            if (bindingWasteSheetHeader.Current == null) return;
            DataRowView row = (DataRowView)bindingWasteSheetHeader.Current;
            int ID = tools.object2int(row["ID"]);
            WasteSheetRptFrm frm = new WasteSheetRptFrm(ID);
            frm.ShowDialog(this);
        }

        private void WasteSheetHeader_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void grid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpenDetail(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            OpenDetail(true);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            OpenReportForm();
        }

        private void grid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenDetail(false);
        }
    }
}