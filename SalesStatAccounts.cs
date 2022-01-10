using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    /// <summary>
    /// This class has the purpose of creating rows in the
    /// table SalesStatDailyAccounts. Each row will be bound
    /// to the parent table SalesStatDailyColumns with the
    /// fields SalesStatDailyColumns.ID -> SalesStatDailyAccounts.ColumnID.
    /// </summary>
    public partial class SalesStatAccounts : Form
    {
        // the parent row's column id.
        // (the parent row represent a column in a print).
        private int ColumnID = 0;

        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="ParentDataSet">
        /// The parent's dataset is provided because we want to be able to
        /// select ok in this form, but still be able to cancel changes in
        /// the parent form. Providing the parent's dataset makes it possible
        /// not to commit changes when closing this form.
        /// </param>
        /// <param name="ColumnID">
        /// The parent row's ID field 
        /// (the parent row represent a column in a print).
        /// </param>
        public SalesStatAccounts(SalesStatDS ParentDataSet, int ColumnID)
        {
            InitializeComponent();

            // save the parent row's id
            this.ColumnID = ColumnID;

            SetDataSet(ParentDataSet);
            LoadData();

            // set grid column order
            int index = 0;
            colAccountFrom.DisplayIndex = index++;
            colAccountFromBtn.DisplayIndex = index++;
            colAccountFromDesc.DisplayIndex = index++;
            colAccountTo.DisplayIndex = index++;
            colAccountToBtn.DisplayIndex = index++;
            colAccountToDesc.DisplayIndex = index++;

            // localization
            this.Text = string.Format(db.GetLangString("SalesStatAccounts.Title"));
            btnOk.Text = db.GetLangString("Application.Ok");
            btnCancel.Text = db.GetLangString("Application.Cancel");
            colAccountFrom.HeaderText = db.GetLangString("SalesStatAccounts.colAccountsFrom");
            colAccountTo.HeaderText = db.GetLangString("SalesStatAccounts.colAccountsTo");
            colAccountFromDesc.HeaderText = db.GetLangString("SalesStatAccounts.colAccountsFromDesc");
            colAccountToDesc.HeaderText = db.GetLangString("SalesStatAccounts.colAccountsToDesc");

            dsSalesStat.SalesStatDailyAccounts.OnFieldChangedError += new SalesStatDS.SalesStatDailyAccountsDataTable.FieldChangedError(SalesStatDailyAccounts_OnFieldChangedError);
        }

        #endregion

        #region SetDataSet
        private void SetDataSet(SalesStatDS ParentDataSet)
        {
            // save binding object's DataMember reference
            // before overwriting the dataset
            string bindingAccountsDataMember = bindingAccounts.DataMember;
            string bindingLookupGLAccountDataMember = bindingLookupGLAccount.DataMember;

            // overwriting this form's dataset.
            dsSalesStat = ParentDataSet;

            // when overwriting the form's dataset,
            // we must repair the binding object's
            // DataSource and DataMember references
            
            bindingLookupGLAccount.DataSource = dsSalesStat;
            bindingLookupGLAccount.DataMember = bindingLookupGLAccountDataMember;

            bindingAccounts.DataSource = dsSalesStat;
            bindingAccounts.DataMember = bindingAccountsDataMember;
        }
        #endregion

        #region LoadData
        private void LoadData()
        {
            adapterLookupGLAccount.Connection = db.Connection;
            adapterLookupGLAccount.Fill(dsSalesStat.LookupGLAccount);

            // accounts fill is called in SalesStatColumns
        }
        #endregion

        #region SaveData
        private void SaveData()
        {
            grid.EndEdit();
            bindingAccounts.EndEdit();
            
            // accounts update is called in SalesStatColumns
        }
        #endregion

        private void InsertMasterID()
        {
            if (bindingAccounts.Current == null) return;
            DataRowView row = (DataRowView)bindingAccounts.Current;
            if (tools.IsNullOrDBNull(row["ColumnID"]))
                row["ColumnID"] = ColumnID;
        }

        private void SalesStatDailyAccounts_OnFieldChangedError(string ErrorMessage)
        {
            bindingAccounts.ResetCurrentItem();
            MessageBox.Show(ErrorMessage);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SaveData();
            Close();
        }

        private void grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            ImageButtonRender.OnCellPainting(e, colAccountFromBtn.Index, ImageButtonRender.Images.LookupForm);
            ImageButtonRender.OnCellPainting(e, colAccountToBtn.Index, ImageButtonRender.Images.LookupForm);
        }

        private void SalesStatAccounts_Load(object sender, EventArgs e)
        {
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (bindingAccounts.Current == null) return;
            if (grid.CurrentRow == null) return;

            DataRowView row = (DataRowView)bindingAccounts.Current;
            if (e.ColumnIndex == colAccountFromBtn.Index)
            {
                string GLCode = tools.object2string(row["AccountFrom"]);
                GLAccountPopup lookup = new GLAccountPopup();
                lookup.SelectedGLCode = GLCode;
                if (lookup.ShowDialog(this) == DialogResult.OK)
                {
                    row["AccountFrom"] = lookup.SelectedGLCode;
                    // check if dbclass has nulled due to an error
                    if (!tools.IsNullOrDBNull(row["AccountFrom"]))
                    {
                        InsertMasterID();
                        bindingAccounts.EndEdit(); // provoke generate a new record
                        grid.Refresh();
                    }
                }
            }
            else if (e.ColumnIndex == colAccountToBtn.Index)
            {
                string GLCode = tools.object2string(row["AccountTo"]);
                GLAccountPopup lookup = new GLAccountPopup();
                lookup.SelectedGLCode = GLCode;
                if (lookup.ShowDialog(this) == DialogResult.OK)
                {
                    row["AccountTo"] = lookup.SelectedGLCode;
                    // check if dbclass has nulled due to an error
                    if (!tools.IsNullOrDBNull(row["AccountTo"]))
                    {
                        InsertMasterID();
                        bindingAccounts.EndEdit(); // provoke generate a new record
                        grid.Refresh();
                    }
                }
            }
        }
    }
}