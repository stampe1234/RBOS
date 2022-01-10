using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class ItemUpdates : Form
    {
        // constructor
        bool DOSite = (db.GetConfigStringAsBool("DOVersion"));
        public ItemUpdates()
        {
            InitializeComponent();

            LoadData();

            


            // position grid columns (bug in VS2005)
            colUpdDate.DisplayIndex = 0;
            colNoOfLines.DisplayIndex = 1;
            if (DOSite)
            {
                colNoOfOpen.DisplayIndex = 2;
                colNoOfOpen.Visible = true;
                colNoOfAproved.Visible = false;
            }
            else
            {
                colNoOfAproved.DisplayIndex = 2;
                colNoOfOpen.Visible = false;
            }


#if FSD
            colOrigin.DisplayIndex = 3;
#endif

            // localization
#if FSD
            this.Text = db.GetLangString("ItemUpdates.Title_FSD");
#else
            this.Text = db.GetLangString("ItemUpdates.Title");
#endif
            btnDetails.Text = db.GetLangString("Application.Details");
            btnClose.Text = db.GetLangString("Application.Close");
            btnReport.Text = db.GetLangString("ItemUpdates.btnReport");
            colUpdDate.HeaderText = db.GetLangString("ItemUpdates.colUpdDate");
            colNoOfLines.HeaderText = db.GetLangString("ItemUpdates.colNoOfLines");
            colNoOfOpen.HeaderText = db.GetLangString("ItemUpdates.colNoOfOpen");
            colOrigin.HeaderText = db.GetLangString("ItemUpdates.colOrigin");

#if !FSD
            colOrigin.Visible = false;
#endif
        }

        private void LoadData()
        {
            adapterItemUpdates.Connection = db.Connection;
            adapterItemUpdates.Fill(dsImport.ItemUpdates);
        }

        // opens the detail form for the selected header
        private void OpenDetails()
        {
            if (bindingItemUpdates.Current == null) return;
            DataRowView row = (DataRowView)bindingItemUpdates.Current;
            int NumOlderOpen;
            // figure out how many record exists that
            // is older and has open detail records
            if (!DOSite)
            {
                NumOlderOpen = tools.object2int(db.ExecuteScalar(string.Format(
                        " select count(*) " +
                        " from ItemUpdates" +
                        " where (ID < ('{0}')) " +
                        " and (NoOfAproved < NoOfLines) ",
                        row["ID"])));
            }
            else
            {
               
                 NumOlderOpen = tools.object2int(db.ExecuteScalar(string.Format(
                    " select count(*) " +
                    " from ItemUpdates" +
                    " where (UpdDate < ('{0}')) " +
                    " and (NoOfOpen > 0) ",
                    row["UpdDate"])));
            }




           
            // only allow opening the details form
            // if NumOlderOpen is 0
            if (NumOlderOpen <= 0)
            {
                int ID = tools.object2int(row["ID"]);
                ItemUpdLines details = new ItemUpdLines(ID);
                details.ShowDialog();

                // refresh the grid while keeping the selected record
                int index = bindingItemUpdates.Position;
                adapterItemUpdates.Fill(dsImport.ItemUpdates);
                if ((index >= 0) && (index < bindingItemUpdates.Count))
                    bindingItemUpdates.Position = index;
            }
            else
            {
                string msg = db.GetLangString("ItemUpdates.msgRecordCannotBeOpened");
                MessageBox.Show(msg);
            }
        }

        // preselect the record that can be worked on. this
        // is the oldest record with open detail records
        private void PreselectWorkRecord()
        {
            // get the ID of the current work record
            int ID;
            if (!DOSite)
            {
                ID = tools.object2int(db.ExecuteScalar(string.Format(
                   " select ID from ItemUpdates " +
                   " where NoOfAproved < NoOfLines " +
                   " order by ID ")));
            }
            else
            {
                ID = tools.object2int(db.ExecuteScalar(string.Format(
                " select ID from ItemUpdates " +
                " where NoOfOpen > 0 " +
                " order by UpdDate ")));
            }




            // attempt to locate the ID in the list and position on that record
            int index = bindingItemUpdates.Find("ID", ID);
            if ((index >= 0) && (index < bindingItemUpdates.Count))
                bindingItemUpdates.Position = index;
        }

        private void DeleteHeaderAndDetails()
        {
            // check we have a record
            if (bindingItemUpdates.Current == null) return;
            DataRowView row = (DataRowView)bindingItemUpdates.Current;
            string msg = "";

            // check that the number of open records are greater that 0
            int NumOpen = tools.object2int(row["NoOfOpen"]);
            int NumLines = tools.object2int(row["NoOfLines"]);
            if ((NumOpen <= 0) && (NumLines > 0))
            {
                msg = db.GetLangString("ItemUpdates.CannotDeleteWhenNonOpen");
                MessageBox.Show(msg);
                return;
            }

            // confirm that delete is ok to do
            msg = db.GetLangString("ItemUpdates.ConfirmDelete");
            if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            // delete
            db.StartTransaction();
            try
            {
                int pos = bindingItemUpdates.Position;

                int ID = tools.object2int(row["ID"]);
                ImportDataSet.ItemUpdLinesDataTable.DeleteRecords(ID);
                ImportDataSet.ItemUpdatesDataTable.DeleteRecord(ID);
                db.CommitTransaction();
                LoadData();
                dataGridView1.Refresh();

                if ((pos >= 0) && (pos < bindingItemUpdates.Count))
                    bindingItemUpdates.Position = pos;
            }
            finally
            {
                if (db.CurrentTransaction != null)
                    db.RollbackTransaction();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            OpenDetails();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenDetails();
        }

        private void ItemUpdates_Load(object sender, EventArgs e)
        {
            PreselectWorkRecord();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (bindingItemUpdates.Current == null) return;
            DataRowView row = (DataRowView)bindingItemUpdates.Current;

            int ID = tools.object2int(row["ID"]);
            ItemUpdRptFrm report = new ItemUpdRptFrm(ID);
            report.ShowDialog(this);
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = true; // let the method do the delete
            DeleteHeaderAndDetails();
        }

        private void ItemUpdates_FormClosing(object sender, FormClosingEventArgs e)
        {
            // check for due future prices
            //if (ItemDataSet.SalesPackFuturePricesPromptDataTable.CheckIfAnySalesPacksAreDue()) //PN20191004
            //{
            //    string msg = db.GetLangString("AskUserWhenFuturePricesAreDue");
            //    if (MessageBox.Show(this, msg, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //        (this.MdiParent as MainForm).OpenMenuWindow("TreeMenu.SalesPackFuturePricesPrompt");
            //}
        }
    }
}