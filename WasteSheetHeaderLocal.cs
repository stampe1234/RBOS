using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class WasteSheetHeaderLocal : Form
    {
        public WasteSheetHeaderLocal()
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

       
            adapterwasteSheetHeaderLocalLookups.Connection = db.Connection;
            adapterwasteSheetHeaderLocalLookups.Fill(dsItem.WasteSheetHeaderLocalLookups);                   
            adapterWasteSheetHeaderLocal.Connection = db.Connection;
            adapterWasteSheetHeaderLocal.Fill(dsItem.WasteSheetHeaderLocal);


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
              //  ID = ItemDataSet.WasteSheetHeaderDataTable.CreateNewRecord();  20240318
                ID = ItemDataSet.WasteSheetHeaderLocalDataTable.CreateNewRecord();
                
            }
            else
            {
                // get ID of currently selected waste sheet
                if (bindingWasteSheetLookupsLocal.Current == null) return;
                DataRowView row = (DataRowView) bindingWasteSheetHeaderLocal.Current;
                ID = tools.object2int(row["ID"]);
            }

            // open details form
            if (ID > 0)
            {

                WasteSheetDetailsLocal details = new WasteSheetDetailsLocal(ID);
                if (details.ShowDialog(this) == DialogResult.OK)
                {
                    // reload data from disk and reposition on current record
                    
                    int Pos = bindingWasteSheetHeaderLocal.Position;
                    LoadData();
                    if ((Pos >= 0) && (Pos < bindingWasteSheetHeaderLocal.Count))
                        bindingWasteSheetHeaderLocal.Position = Pos;
                }
                else
                {
                    if (CreateNew)
                    {
                        // a new header record was created and user selected cancel,
                        // so we must delete the header record
                        //ItemDataSet.WasteSheetHeaderDataTable.DeleteRecord(ID); 18032024
                        ItemDataSet.WasteSheetHeaderLocalDataTable.DeleteRecord(ID);
                    }
                }
            }
        }
        #endregion

        private void Delete()
        {
            if (bindingWasteSheetHeaderLocal.Current == null) return;
            string msg = db.GetLangString("WasteSheetHeader.DeleteWasteSheet");
            if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataRowView row = (DataRowView)bindingWasteSheetHeaderLocal.Current;
                int ID = tools.object2int(row["ID"]);
                ItemDataSet.WasteSheetHeaderLocalDataTable.DeleteRecord(ID);
                bindingWasteSheetHeaderLocal.RemoveCurrent();
            }
        }

        private void OpenReportForm()
        {
            if (bindingWasteSheetHeaderLocal.Current == null) return;
            DataRowView row = (DataRowView)bindingWasteSheetHeaderLocal.Current;
            int ID = tools.object2int(row["ID"]);
            WasteSheetLocalRptFrm frm = new WasteSheetLocalRptFrm(ID);            
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