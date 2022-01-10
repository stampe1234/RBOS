using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class ImportRSMForm : Form
    {
        #region Constructor
        public ImportRSMForm()
        {
            InitializeComponent();

            LoadData();

            // position grid columns (bug in VS2005)
            colBookDate.DisplayIndex = 0;
            colFGMimported.DisplayIndex = 1;
            colFGMproblems.DisplayIndex = 2;
            colMCMimported.DisplayIndex = 3;
            colMCMproblems.DisplayIndex = 4;
            colMSMimported.DisplayIndex = 5;
            colMSMproblems.DisplayIndex = 6;
            colISMimported.DisplayIndex = 7;
            colISMproblems.DisplayIndex = 8;
            colTPMimported.DisplayIndex = 9;
            colTPMproblems.DisplayIndex = 10;
           
        }
        #endregion

        #region LoadData
        private void LoadData()
        {
            adapterHeader.Connection = db.Connection;
            adapterHeader.Fill(dsImport.Import_RPOS_24H_Header);
        }
        #endregion

        // close button click event
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // import button click event
        private void btnImport_Click(object sender, EventArgs e)
        {
            // save header table to reflect any unchecked checkmarks
            bindingHeader.EndEdit();
            adapterHeader.Update(dsImport.Import_RPOS_24H_Header);

            // perform import
            ImportRSM importer = new ImportRSM();
            bool ErrorsInDisktilbud;
            if (importer.ImportRSMFiles(out ErrorsInDisktilbud))
            {
                string msg = db.GetLangString("ImportRSMForm.ImportCompleted");
                if (ErrorsInDisktilbud)
                    msg += db.GetLangString("ImportRSMForm.ErrorsInDisktilbud");
                MessageBox.Show(msg);
            }
            else
                MessageBox.Show(importer.LastError);
            LoadData();

            // if station has SparPOS, also import that
            ImportSparPOS importSpar = new ImportSparPOS();
            if (importSpar.ImportIsActive())
            {
                if (importSpar.ImportSparPOSTransactions())
                    MessageBox.Show(db.GetLangString("ImportRSMForm.SparPOSImported"));
                else
                    MessageBox.Show(importSpar.LastError);
            }
        }

        // grid cell mouse enter event
        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // display hand cursor when mouse is over problem line cells,
            // to indicate for user, that those cells can be clicked on
            if ((e.ColumnIndex == colFGMproblems.Index) ||
                (e.ColumnIndex == colISMproblems.Index) ||
                (e.ColumnIndex == colMCMproblems.Index) ||
                (e.ColumnIndex == colMSMproblems.Index) ||
                (e.ColumnIndex == colTPMproblems.Index))
            {
                // only allow hand cursor to be shown
                // if the cell actually holds a value
                try
                {
                    if ((e.ColumnIndex >= 0) &&
                        (e.RowIndex >= 0) &&
                        (!dataGridView1[e.ColumnIndex, e.RowIndex].Value.Equals(0)) &&
                        (dataGridView1[e.ColumnIndex, e.RowIndex].Value != DBNull.Value))
                    {
                        dataGridView1.Cursor = Cursors.Hand;
                    }
                }
                catch { }
            }
        }

        // grid cell mouse leave event
        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            // set default cursor when leaving any cell,
            // as some cells set another cursor on enter
            dataGridView1.Cursor = Cursors.Default;
        }

        // grid cell click event
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell == null) return;
            if (bindingHeader.Current == null) return;
            DataRowView row = (DataRowView)bindingHeader.Current;

            // get FileType for selected problem line cell
            string FileType = "";
            if (e.ColumnIndex == colFGMproblems.Index) FileType = "FGM";
            else if (e.ColumnIndex == colMCMproblems.Index) FileType = "MCM";
            else if (e.ColumnIndex == colMSMproblems.Index) FileType = "MSM";
            else if (e.ColumnIndex == colTPMproblems.Index) FileType = "TPM";
            else if (e.ColumnIndex == colISMproblems.Index) FileType = "ISM";

            if (FileType != "")
            {
                // check that a problem line exist for the selected cell
                if ((!dataGridView1.CurrentCell.Value.Equals(0)) &&
                    (dataGridView1.CurrentCell.Value != DBNull.Value))
                {
                    // get BookDate for selected record
                    DateTime BookDate = tools.object2datetime(row["BookDate"]);

                    // show problem lines form
                    ImportRSMFormPL pl = new ImportRSMFormPL(BookDate, FileType);
                    pl.ShowDialog(this);
                }
            }
        }

        // form closing event
        private void ImportRSMForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // if user has unchecked some checkmarks, but no import has been
            // performed for these data afterwards, make sure those checkmarks
            // are re-enabled the next time this form is opened. We still have the
            // data - they are just enabled for re-import when user unchecks a checkmark.
            bindingHeader.EndEdit();
            dsImport.Import_RPOS_24H_Header.RestoreCheckMarksStillWithData();
            adapterHeader.Update(dsImport.Import_RPOS_24H_Header);
        }

        // grid cell begin edit event
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (bindingHeader.Current == null) return;
            DataRowView row = (DataRowView)bindingHeader.Current;

            // if row has Reconciled flag = true, then it is not
            // legal to uncheck a checkmark for this row, as re-import
            // is not allowed after reconcile.
            if (tools.object2bool(row["Reconciled"]) == true)
                e.Cancel = true;
        }

        private void ImportRSMForm_Load(object sender, EventArgs e)
        {
            // localization
            btnImport.Text = db.GetLangString("ImportRSMForm.btnImport");
            btnClose.Text = db.GetLangString("Application.Close");
            colBookDate.HeaderText = db.GetLangString("ImportRSMForm.colBookDate");
        }
    }
}