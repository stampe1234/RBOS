using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DRS.Extensions
{
    /// <summary>
    /// Extension of .NET class DataGridView
    /// to suite our needs better.
    /// </summary>
    class DRS_DataGridView : DataGridView
    {
        private static string _DataErrorString = "";
        public static string DataErrorString
        {
            set { _DataErrorString = value; }
        }

        // constructor
        public DRS_DataGridView()
        {
            // setup default property values
            this.AllowUserToResizeRows = false;
            this.AllowUserToResizeColumns = false;
            this.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            this.BackgroundColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = BorderStyle.Fixed3D;
            this.MultiSelect = false;
            this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.RowHeadersWidth = 25;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ColumnHeadersHeight = 21;

            // subscribe to DataError event
            this.DataError += new DataGridViewDataErrorEventHandler(DRS_DataGridView_DataError);
        }

        // DataError event delegate
        protected void DRS_DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception is FormatException)
            {
                MessageBox.Show(_DataErrorString);
                e.ThrowException = false;
            }
        }

        // make Enter key move to the right in the grid
        protected override bool ProcessDialogKey(Keys keyData)
        {
            Keys key = (keyData & Keys.KeyCode);
            if (key == Keys.Enter)
            {
                return this.ProcessTabKey(keyData);

                // NOTE: we process the Tab key instead of the Right key
                // as we want the cursor to make a newline at the end of a record.
                // The code with the ProcessRightKey was what originally
                // was suggested by Microsoft.
                //return this.ProcessRightKey(keyData);
            }

            // sometimes we get an unexplainable crash
            // if user hits esc key in grid.
            try { return base.ProcessDialogKey(keyData); }
            catch (Exception ex)
            {
                RBOS.log.WriteException(
                    "DRS_DataGridView.ProcessDialogKey",
                    ex.Message, ex.StackTrace);
                return false;
            }
        }

        // make Enter key move to the right in the grid
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                return this.ProcessTabKey(e.KeyData);

                // NOTE: we process the Tab key instead of the Right key
                // as we want the cursor to make a newline at the end of a record.
                // The code with the ProcessRightKey was what originally
                // was suggested by Microsoft.
                //return this.ProcessRightKey(e.KeyData);
            }

            // sometimes we get an unexplainable crash
            // if user hits esc key in grid.
            try { return base.ProcessDataGridViewKey(e); }
            catch (Exception ex)
            {
                RBOS.log.WriteException(
                    "DRS_DataGridView.ProcessDataGridViewKey",
                    ex.Message, ex.StackTrace);
                return false;
            }
        }

        public void JumpToColumn(DataGridViewColumn destCol)
        {
            DataGridViewCell currCell = this.CurrentCell;
            if (currCell == null)
                return;
            DataGridViewColumn startCol = this.Columns[currCell.ColumnIndex];
            if (currCell.IsInEditMode)
                this.EndEdit();
            if (startCol.DisplayIndex >= destCol.DisplayIndex)
                return;
            for (int i = startCol.DisplayIndex; i < destCol.DisplayIndex; i++)
                SendKeys.SendWait("{TAB}");
        }

        public void JumpToNextRow()
        {
            SendKeys.SendWait("{HOME}");
            SendKeys.SendWait("{DOWN}");
        }

        public void JumpDown()
        {
            SendKeys.SendWait("{DOWN}");
        }

        public void JumpLeft()
        {
            SendKeys.SendWait("{LEFT}");
        }

        public DataGridViewColumn CurrentColumn
        {
            get
            {
                if (this.CurrentCell == null) return null;
                return this.Columns[this.CurrentCell.ColumnIndex];
            }
        }
    }
}
