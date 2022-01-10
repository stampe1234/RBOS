using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace RBOS
{
    public partial class LookupKolliSizeForm : Form
    {
        #region Constructor
        public LookupKolliSizeForm()
        {
            InitializeComponent();

            adapterLookupKolliSizeAdmin.Connection = db.Connection;
            adapterLookupKolliSizeAdmin.Fill(dsItem.LookupKolliSizeAdmin);

            // position columns (bug in VS2005)
            colKolliSize.DisplayIndex = 0;
            colDescription.DisplayIndex = 1;
            colBHHTID.DisplayIndex = 2;

            // Localize
            colKolliSize.HeaderText = db.GetLangString("KolliLookupForm.KollisizeLabel");
            colDescription.HeaderText = db.GetLangString("KolliLookupForm.DescriptionLabel");
            colBHHTID.HeaderText = db.GetLangString("KolliLookupForm.BHHTIDLabel");
            btnCancel.Text = db.GetLangString("btnClose");
            btnSaveClose.Text = db.GetLangString("Application.SaveClose");

            // focus the grid
            if (gridKolliSizes.CanFocus)
                gridKolliSizes.Focus();
        }
        #endregion

        #region METHOD: DeleteAllowedForCurrentRow
        /// <summary>
        /// Checks if the 
        /// </summary>
        /// <returns></returns>
        private bool DeleteAllowedForCurrentRow()
        {
            if (bindingLookupKolliSizeAdmin.Current == null) return false;
            DataRowView row = (DataRowView)bindingLookupKolliSizeAdmin.Current;
            int KolliSize = tools.object2int(row["KolliSize"]);
            string ItemName = dsItem.LookupKolliSizeAdmin.ReturnFirstItemThatReferencesThis(KolliSize);
            if(ItemName != "")
            {
                string msg = string.Format(
                    db.GetLangString("LookupKolliSizeForm.DeleteCancelled"),
                    ItemName);
                MessageBox.Show(msg);
                return false;
            }
            else
                return true;
        }
        #endregion

        // cancel button click event
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // grid data error event
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception is FormatException)
            {
                MessageBox.Show(db.GetLangString("KolliLookupForm.EnterCorrectFormatMsg"));
                e.ThrowException = false;
            }
        }

        // grid cell validating event
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // check that a change has occured
            if (gridKolliSizes.CurrentCell == null) return;
            if (gridKolliSizes.CurrentCell.FormattedValue.Equals(e.FormattedValue)) return;

            // get a reference to the underlying datarow
            if (bindingLookupKolliSizeAdmin.Current == null) return;
            DataRowView row = (DataRowView)bindingLookupKolliSizeAdmin.Current;

            if (e.ColumnIndex == colKolliSize.Index)
            {
                // check for valid KolliSize value and give error if wrong
                Regex regex = new Regex("^([0-9]*)^");
                if (!regex.Match(tools.object2string(e.FormattedValue)).Success)
                {
                    MessageBox.Show(db.GetLangString("LookupKolliSizeForm.KolliSizeMustBeInteger"));
                    e.Cancel = true;
                    return;
                }

                // check that this KolliSize does not already exists
                int newKolliSize = tools.object2int(e.FormattedValue);
                if (dsItem.LookupKolliSizeAdmin.KolliSizeAlreadyExists(newKolliSize))
                {
                    MessageBox.Show(db.GetLangString("LookupKolliSizeForm.KolliSizeAlreadyExist"));
                    e.Cancel = true;
                    return;
                }

                // suggest a value for the description field
                if (tools.object2string(row["Description"]) == "")
                {
                    int maxlength = dsItem.LookupKolliSizeAdmin.DescriptionColumn.MaxLength;
                    row["Description"] = newKolliSize.ToString() + "-PK";
                }

                // generate a value for the BHHTID field
                row["BHHTID"] = 1000 + newKolliSize;

                // reflect generated values in GUI
                gridKolliSizes.Refresh();
            }
            else if (e.ColumnIndex == colDescription.Index)
            {
                // check for max Description characters and give error if wrong
                int maxlength = dsItem.LookupKolliSizeAdmin.DescriptionColumn.MaxLength;
                if (tools.object2string(e.FormattedValue).Length > maxlength)
                {
                    MessageBox.Show(string.Format(db.GetLangString("LookupKolliSizeForm.DescriptionMaxSize"), maxlength));
                    e.Cancel = true;
                    return;
                }
            }
        }

        // save and close button click event
        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            // save data and close form
            adapterLookupKolliSizeAdmin.Update(dsItem.LookupKolliSizeAdmin);
            Close();
        }

        // grid user deleting row event
        private void gridKolliSizes_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!DeleteAllowedForCurrentRow())
                e.Cancel = true;
        }

        // grid popup menu delete button click event
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DeleteAllowedForCurrentRow())
                bindingLookupKolliSizeAdmin.RemoveCurrent();
        }
    }
}