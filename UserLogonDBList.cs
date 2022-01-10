using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class UserLogonDBList : Form
    {
        public UserLogonDBList(DataTable DatabaseList)
        {
            InitializeComponent();
            grid.AutoGenerateColumns = false;
            this.DialogResult = DialogResult.Cancel;
            grid.DataSource = DatabaseList;
        }

        #region SelectedDatabase
        private DataRow _SelectedDatabase = null;
        public DataRow SelectedDatabase
        {
            get { return _SelectedDatabase; }
        }
        #endregion

        #region ToggleUnlockButton
        /// <summary>
        /// Enables the unlock button if the selected database is locked
        /// and disables the button if the database not locked.
        /// </summary>
        /// <param name="IndexOfSelectedRow">Index of the selected row. Is passed in from the event.</param>
        private void ToggleUnlockButton(int IndexOfSelectedRow)
        {
            DataGridViewRow row = null;
            if (IndexOfSelectedRow >= 0 && IndexOfSelectedRow < grid.Rows.Count)
                row = grid.Rows[IndexOfSelectedRow];
            if (row != null)
            {
                string LockedBy = tools.object2string(row.Cells[colLockedBy.Index].Value);
                btnUnlock.Enabled = LockedBy != "";
            }
        }
        #endregion

        private void btnLogOn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && grid.SelectedCells != null)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void UserLogonDBList_Load(object sender, EventArgs e)
        {

        }

        private void UserLogonDBList_FormClosing(object sender, FormClosingEventArgs e)
        {
            // save the selected row on form closing, so we are sure it is saved before the form is destroyed
            if (grid.CurrentRow != null)
                _SelectedDatabase = (grid.CurrentRow.DataBoundItem as DataRowView).Row;
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow == null || grid.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vælg venligst en database først");
                return;
            }
            DataRow row = (grid.CurrentRow.DataBoundItem as DataRowView).Row;
            if (row == null)
            {
                MessageBox.Show("Vælg venligst en database først");
                return;
            }
            string database = tools.object2string(row["DatabaseName"]);
            //UserLogonUnlockDB unlock = new UserLogonUnlockDB(database);
            //if (unlock.ShowDialog(this) == DialogResult.OK)
            //{
            //    // database has been unlocked
                
            //    // so we clear the LockedBy field in the grid
            //    grid.CurrentRow.Cells[colLockedBy.Index].Value = "";

            //    // log into the database
            //    this.DialogResult = DialogResult.OK;
            //    Close();
            //}
        }

        private void grid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            ToggleUnlockButton(e.RowIndex);
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}