using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class PackSizeForm : Form
    {
        // constructor
        public PackSizeForm()
        {
            InitializeComponent();
        }

        // form load event
        private void PackSizeForm_Load(object sender, EventArgs e)
        {
            // load data
            adapterPackSize.Connection = db.Connection;
            adapterPackSize.Fill(dsItem.PackSizeConfig);

            // position grid columns (bug in VS2005)
            colPackType.DisplayIndex = 0;
            colPackTypeName.DisplayIndex = 1;
            colAmount.DisplayIndex = 2;
            colSys.DisplayIndex = 3;

            // focus packsize grid
            if(gridPackSizes.CanFocus)
                gridPackSizes.Focus();

            // localization goes here...
            colSys.HeaderText = db.GetLangString("PackSizeForm.SysColLabel");
            colPackType.HeaderText = db.GetLangString("PackSizeForm.PackTypeLabel");
            colPackTypeName.HeaderText = db.GetLangString("PackSizeForm.PackTypeNameLabel");
            colAmount.HeaderText = db.GetLangString("PackSizeForm.SellUnitsLabel");
            btnCancel.Text = db.GetLangString("btnClose");
            btnSave.Text = db.GetLangString("Application.SaveClose");

        }

        // save button
        private void btnSave_Click(object sender, EventArgs e)
        {
            // save packsize data and close form
            adapterPackSize.Update(dsItem.PackSizeConfig);
            Close();
        }

        // cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // cancel packsize data and close form
            Close();
        }

        // grid cell validating event
        private void gridPackSizes_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // check that required variables are present
            if (bindingPackSize.Current == null) return;
            if (gridPackSizes.CurrentCell == null) return;

            // check that cell is in edit mode
            if(!gridPackSizes.CurrentCell.IsInEditMode) return;

            // check that value has changed
            string oldValue = tools.object2string(gridPackSizes.CurrentCell.FormattedValue);
            string newValue = tools.object2string(e.FormattedValue);
            if (oldValue == newValue) return;

            // if column is PackTypeName
            DataRowView row = (DataRowView)bindingPackSize.Current;
            if (e.ColumnIndex == colPackTypeName.Index)
            {
                // check that user entered a valid PackTypeName
                string newPackTypeName = e.FormattedValue.ToString();
                if (!dsItem.PackSizeConfig.ValidatePackTypeName(newPackTypeName))
                {
                    MessageBox.Show(dsItem.PackSizeConfig.LastError);
                    e.Cancel = true;
                }
            }
        }

        // grid cell begin edit event
        private void gridPackSizes_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // check for needed variables
            if(bindingPackSize.Current == null) return;

            // user may not edit a system PackSize
            DataRowView row = (DataRowView)bindingPackSize.Current;
            if (tools.object2bool(row["Sys"]) == true)
            {
                e.Cancel = true;
                return;
            }
        }

        // delete context menu opening event
        private void popupDelete_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = true;

            /* @@@ DELETE DISABLED UNTIL DATAMODEL IS IN PLACE

            // check for needed variables
            if (bindingPackSize.Current == null) return;

            // user may not get the delete context menu if row is a system row
            DataRowView row = (DataRowView)bindingPackSize.Current;
            if (tools.object2bool(row["Sys"]) == true)
                e.Cancel = true;
            */
        }

        // grid user deleting row event
        private void gridPackSizes_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = true;

            /* @@@ DELETE DISABLED UNTIL DATAMODEL IS IN PLACE
             * - DELETE MUST FIRST CHECK IF ANY SALESPACKS USES THIS PACKSIZE

            // check for needed variables
            if (bindingPackSize.Current == null) return;

            // user may not delete a system row
            DataRowView row = (DataRowView)bindingPackSize.Current;
            if (tools.object2bool(row["Sys"]) == true)
            {
                e.Cancel = true;
                return;
            }

            // check that user wants to delete a row
            if (MessageBox.Show("[Delete PackSize?]", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
             * */
        }

        // delete context menu click
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* @@@ DELETE DISABLED UNTIL DATAMODEL IS IN PLACE
             * - DELETE MUST FIRST CHECK IF ANY SALESPACKS USES THIS PACKSIZE
            // check that user wants to delete a row
            if (MessageBox.Show("[Delete PackSize?]", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bindingPackSize.RemoveCurrent();
            }
             * */
        }

        // grid row validating event
        private void gridPackSizes_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (bindingPackSize.Current == null) return;
            DataRowView row = (DataRowView)bindingPackSize.Current;

            // check that 2 required fields are filled in.
            // if not, cancel the record
            if ((row["PackTypeName"] == DBNull.Value) || (row["Amount"] == DBNull.Value))
            {
                gridPackSizes.CancelEdit();
                gridPackSizes.Refresh();
                return;
            }
        }

        private void gridPackSizes_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            // generate packsize id for the new row
            if (bindingPackSize.Current == null) return;
            DataRowView row = (DataRowView)bindingPackSize.Current;
            if (row["PackType"] == DBNull.Value)
            {
                int packtype = dsItem.PackSizeConfig.GetNextPossblePackTypeID();
                if (packtype > 0)
                {
                    // next possible packtype ok
                    row["PackType"] = packtype;
                    gridPackSizes.Refresh(); // reflect in GUI
                }
                else
                {
                    // if too many packsizes created (packtype would have been higher than 255)
                    MessageBox.Show(db.GetLangString("PackSizeForm.NoMorePackTypesCanBeCreated"));
                    gridPackSizes.CancelEdit();
                    bindingPackSize.CancelEdit();
                }
            }
        }
    }
}