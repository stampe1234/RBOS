using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace RBOS
{
    public partial class BHHTInvCountHeaderForm : Form
    {
        #region Constructor
        public BHHTInvCountHeaderForm()
        {
            InitializeComponent();
        }
        #endregion

        #region METHOD: DeleteSelected
        private void DeleteSelected()
        {
            if(bindingCountHeader.Current == null) return;
            DataRowView headerRow = (DataRowView)bindingCountHeader.Current;
            OleDbCommand cmd = new OleDbCommand("", db.Connection);

            // find out if work data exists for the selected InvCount
            bool workDataExists = false;
            int BHHTCountID = tools.object2int(headerRow["CountID"]);
            cmd.CommandText = string.Format(
                " select BHHTCountID from InvCountWork " +
                " where BHHTCountID = {0} ",
                BHHTCountID);
            object o = cmd.ExecuteScalar();
            if ((o != null) && (o != DBNull.Value))
                workDataExists = true;

            // user must confirm the delete
            string msg = db.GetLangString("BHHTInvCountHeaderForm.DeleteInvCount");
            if(workDataExists)
                msg = db.GetLangString("BHHTInvCountHeaderForm.DeleteInvCountPending");
            if(MessageBox.Show(msg,"",MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            // delete data from BHHTInvCountHeader table
            cmd.CommandText = string.Format(
                " delete from BHHTInvCountHeader " +
                " where CountID = {0} ",
                BHHTCountID);
            cmd.ExecuteNonQuery();

            // delete data from BHHTInvCountDetails table
            cmd.CommandText = string.Format(
                " delete from BHHTInvCountDetails " +
                " where CountID = {0} ",
                BHHTCountID);
            cmd.ExecuteNonQuery();

            // delete data from InvCountWork table
            cmd.CommandText = string.Format(
                " delete from InvCountWork " +
                " where BHHTCountID = {0} ",
                BHHTCountID);
            cmd.ExecuteNonQuery();

            // reload data
            adapterCountHeader.Fill(dsImport.BHHTInvCountHeader);
        }
        #endregion

        #region METHOD: LoadData
        /// <summary>
        /// Load Data.
        /// </summary>
        private void LoadData()
        {
            this.lookupStatusTableAdapter.Connection = db.Connection;
            this.lookupStatusTableAdapter.Fill(this.dsImport.LookupStatus);
            this.adapterCountHeader.Connection = db.Connection;
            this.adapterCountHeader.Fill(this.dsImport.BHHTInvCountHeader);         


        }
        #endregion

        // form load event
        private void BHHTInvCountHeaderForm_Load(object sender, EventArgs e)
        {
            LoadData();

            // Set Displayindex for colums
            colCountID.DisplayIndex = 0;
            colCountDate.DisplayIndex = 1;
            colWorkSheetName.DisplayIndex = 2;
            colStatus.DisplayIndex = 3;
            colStatusColor.DisplayIndex = 4;

            // Localization
            btnClose.Text = db.GetLangString("Application.Close");
            btnDetailLines.Text = db.GetLangString("BHHTInvCountForm.DetailsLabel");
            btnBook.Text = db.GetLangString("BHHTInvCountForm.BookLabel");
            btnDelete.Text = db.GetLangString("BHHTInvCountForm.DeleteLabel");

            colCountID.HeaderText = db.GetLangString("BHHTInvCountForm.CountIdLabel");
            colCountDate.HeaderText = db.GetLangString("BHHTInvCountForm.CountDateLabel");
            colWorkSheetName.HeaderText = db.GetLangString("BHHTInvCountForm.WorksheetNameLabel");
            colStatus.HeaderText = db.GetLangString("BHHTInvCountForm.StatusLabel");
        }

        // book button click event
        private void btnBook_Click(object sender, EventArgs e)
        {
            if (bindingCountHeader.Current == null) return;
            DataRowView headerRow = (DataRowView)bindingCountHeader.Current;

            // make sure the last record is selected
            if (gridInvCountHeader.CurrentRow.Index < gridInvCountHeader.Rows.Count - 1)
            {
                MessageBox.Show(db.GetLangString("BHHTInvCountHeaderForm.SelectOldestFirst"));
                return;
            }

            //>>pn20210520
           
                DataRowView row = (DataRowView)bindingCountHeader.Current;
                if (row["CountID"] != DBNull.Value)
                {

                    int id = int.Parse(row["CountID"].ToString());
                    DateTime CountDate = DateTime.Parse(row["CountDate"].ToString());
                    if (CountDate >= DateTime.Now)
                    {
                        String msg = db.GetLangString("Salg kan først hentes imorgen forsæt uden salg ?");
                        if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                            return;
                    }

                    ImportRHT rHT = new ImportRHT();
                    if (!rHT.ImportPEJRHT(CountDate, id))
                    {
                        return;
                    }

                }
            

            //<<pn20210521
            // open inventory count work form with the selected data
            int BHHTCountID = tools.object2int(headerRow["CountID"]);
            InvCountWorkForm work = new InvCountWorkForm(BHHTCountID);
            work.ShowDialog(this);
            LoadData();
        }

        // close button click event
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
              
        // detail lines button click event
        private void btnDetailLines_Click(object sender, EventArgs e)
        {

            // if user clicks on the detail lines button,
            // open the detail lines form

            if (bindingCountHeader.Current != null)
            {
                DataRowView row = (DataRowView)bindingCountHeader.Current;
                if (row["CountID"] != DBNull.Value)
                {
                    long id = long.Parse(row["CountID"].ToString());
                    BHHTInvCountDetailsForm form = new BHHTInvCountDetailsForm(id);
                    form.ShowDialog(this);
                }
            }

        }

        // grid cell painting event
        private void gridInvCountHeader_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // paint status color cell
            tools.PaintStatusCell(
                gridInvCountHeader,
                e.ColumnIndex,
                e.RowIndex,
                colStatus.Index,
                colStatusColor.Index);
        }

        // grid cell mouse double click event
        private void gridInvCountHeader_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // if user double clicks on a cell in grid,
            // open the detail lines form

            if (bindingCountHeader.Current != null)
            {
                DataRowView row = (DataRowView)bindingCountHeader.Current;
                if (row["CountID"] != DBNull.Value)
                {
                    int id = int.Parse(row["CountID"].ToString());
                    BHHTInvCountDetailsForm form = new BHHTInvCountDetailsForm(id);
                    form.ShowDialog(this);
                }
            }
        }

        // delete button click event
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSelected();
        }

        private void btnGetPejSale_Click(object sender, EventArgs e)
        {
            //pn20210520
            if (bindingCountHeader.Current != null)
            {
                DataRowView row = (DataRowView)bindingCountHeader.Current;
                if (row["CountID"] != DBNull.Value)
                {
                    
                    int id = int.Parse(row["CountID"].ToString());
                    DateTime CountDate = DateTime.Parse(row["CountDate"].ToString());
                    if (CountDate >= DateTime.Now)
                    {
                        String msg = db.GetLangString("Salg kan først hentes imorgen forsæt uden salg ?");
                        if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                            return;
                    }

                    ImportRHT rHT = new ImportRHT();
                    rHT.ImportPEJRHT(CountDate, id);                    
                    
                }
            }
        }
    }
}