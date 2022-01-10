using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class BHHTWorksheet : Form
    {
        #region Constructor
        public BHHTWorksheet()
        {
            InitializeComponent();

            // position grid columns
            colID.DisplayIndex = 0;
            colName.DisplayIndex = 1;
            colType.DisplayIndex = 2;
            colInclude.DisplayIndex = 3;

            // localization
            btnClose.Text = db.GetLangString("Application.Close");
            btnEdit.Text = db.GetLangString("Application.Edit");
            btnDelete.Text = db.GetLangString("Application.Delete");
            btnNew.Text = db.GetLangString("BHHTWorksheet.NewSheet");
            colType.HeaderText = db.GetLangString("BHHTWorksheet.ColType");
            colInclude.HeaderText = db.GetLangString("BHHTWorksheet.ColInclude");
            colID.HeaderText = db.GetLangString("BHHTWorksheet.ColID");
            colName.HeaderText = db.GetLangString("BHHTWorksheet.ColName");
        }
        #endregion

        #region METHOD: NewWorksheet
        /// <summary>
        /// Creates a new worksheet header record and
        /// opens the detail form with the generated WSID.
        /// </summary>
        private void NewWorksheet()
        {
            int WSID = ItemDataSet.BHHTWorksheetDataTable.CreateNewRecord();
            BHHTWSDetail detail = new BHHTWSDetail(WSID);
            if (detail.ShowDialog(this) == DialogResult.OK)
            {
                // user might have updated header data on detail form
                // so reflect these changes in the header grid, then
                // position on the new record
                LoadData();
                bindingWorksheet.MoveLast();
            }
            else
            {
                // user cancels the detail form, and as this
                // method is creating a new worksheet, we can
                // delete the just created worksheet
                DeleteWorksheet(WSID, false);
            }
        }
        #endregion

        #region METHOD: EditWorksheet
        /// <summary>
        /// Gets the selected worksheet's WSID and
        /// opens the detail form with that id.
        /// </summary>
        private void EditWorksheet()
        {
            if (bindingWorksheet.Current == null) return;
            DataRowView row = (DataRowView)bindingWorksheet.Current;

            int WSID = tools.object2int(row["ID"]);
            BHHTWSDetail detail = new BHHTWSDetail(WSID);
            if (detail.ShowDialog(this) == DialogResult.OK)
            {
                // user might have updated header data on detail form
                // so reflect these changes in the header grid, then
                // re-position on the selected record
                int pos = bindingWorksheet.Position;
                LoadData();
                bindingWorksheet.Position = pos;
            }
        }
        #endregion

        #region METHOD: DeleteWorksheet

        /// <summary>
        /// Deletes the selected worksheet and related data from detail tables.
        /// </summary>
        private void DeleteWorksheet()
        {
            // get the currently seleted worksheet's id
            if (bindingWorksheet.Current == null) return;
            DataRowView headerRow = (DataRowView)bindingWorksheet.Current;
            int WSID = tools.object2int(headerRow["ID"]);
            // delete the selected worksheet
            DeleteWorksheet(WSID, true);
        }

        /// <summary>
        /// Deletes the given worksheet and related data from detail tables.
        /// </summary>
        private void DeleteWorksheet(int WSID, bool Prompt)
        {
            if(Prompt)
            {
                string msg = db.GetLangString("BHHTWorksheet.DeleteSelectedWS");
                if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
            }

            // delete the record from worksheet header table            
            db.ExecuteNonQuery(string.Format(
                " delete from BHHTWorksheet " +
                " where ID = {0} ", WSID));

            // delete related records from worksheet catlist detail table
            db.ExecuteNonQuery(string.Format(
                " delete from BHHTWSCatList " +
                " where WSID = {0} ", WSID));

            // delete related records from worksheet itemlist detail table
            db.ExecuteNonQuery(string.Format(
                " delete from BHHTWSItemList " +
                " where WSID = {0} ", WSID));

            // reload data
            LoadData();
        }

        #endregion

        #region METHOD: LoadData
        /// <summary>
        /// Loads the worksheet headers.
        /// </summary>
        private void LoadData()
        {
            // load LookupWSInclude data
            adapterLookupWSInclude.Connection = db.Connection;
            adapterLookupWSInclude.Fill(dsItem.LookupWSInclude);

            // load LookupWSType data
            adapterLookupWSType.Connection = db.Connection;
            adapterLookupWSType.Fill(dsItem.LookupWSType);
            
            // load worksheet data
            adapterWorksheet.Connection = db.Connection;
            adapterWorksheet.Fill(dsItem.BHHTWorksheet);
        }
        #endregion

        // form load event
        private void BHHTWorksheet_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // new button click event
        private void btnNew_Click(object sender, EventArgs e)
        {
            NewWorksheet();
        }

        // delete button click event
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteWorksheet();
        }

        // edit button click event
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditWorksheet();
        }

        // close button click event
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // grid mouse double click event
        private void gridWorksheet_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditWorksheet();
        }
    }
}