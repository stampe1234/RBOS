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
    public partial class BHHTOrderDetailForm : Form
    {
        private int OrderID = -1;

        #region Constructor
        public BHHTOrderDetailForm(int OrderID)
        {
            InitializeComponent();

            this.OrderID = OrderID;
            adapterOrderDetails.Connection = db.Connection;
            adapterOrderDetails.Fill(dsImport.BHHTOrderDetails,OrderID);
            adapterLookupPackType.Connection = db.Connection;
            adapterLookupPackType.Fill(itemDataSet.LookupPackSize);
        }
        #endregion

        #region METHOD: SaveData
        /// <summary>
        /// Saves any changes to the detail table.
        /// </summary>
        private void SaveData()
        {
            bindingOrderDetails.EndEdit();

            // if any changes
            DataTable changes = dsImport.BHHTOrderDetails.GetChanges();
            if ((changes != null) && (changes.Rows.Count > 0))
            {
                // save order details
                adapterOrderDetails.Update(dsImport.BHHTOrderDetails);

                // update number of excluded order details in order header
                int num = dsImport.BHHTOrderDetails.Select("ExcludeFromOrder = true").Length;
                string sql = string.Format(
                    " update BHHTOrderHeader " +
                    " set NumExcludeFromOrder = {0} " +
                    " where OrderID = {1} ",
                    num, OrderID);
                OleDbCommand cmd = new OleDbCommand(sql, db.Connection);
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        // close button click event
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // form load event
        private void BHHTOrderDetailForm_Load(object sender, EventArgs e)
        {            
            colLineNumber.DisplayIndex = 0;
            colOrderingNumber.DisplayIndex = 1;
            colReceiptText.DisplayIndex = 2;
            colPackType.DisplayIndex = 3;
            colKolliSize.DisplayIndex = 4;
            colQuantity.DisplayIndex = 5;
            colExcludeFromOrder.DisplayIndex = 6;

            // Localization

            btnClose.Text = db.GetLangString("Application.Close");
            colLineNumber.HeaderText = db.GetLangString("BHHTOrdDetForm.LineNoLabel");
            colOrderingNumber.HeaderText = db.GetLangString("BHHTOrdDetForm.OrderingNoLabel");
            colReceiptText.HeaderText = db.GetLangString("BHHTOrdDetForm.ItemNameLabel");
            colPackType.HeaderText = db.GetLangString("BHHTOrdDetForm.PacktypeLabel");
            colKolliSize.HeaderText = db.GetLangString("BHHTOrdDetForm.KolliLabel");
            colQuantity.HeaderText = db.GetLangString("BHHTOrdDetForm.NumberOfLabel");
            colExcludeFromOrder.HeaderText = db.GetLangString("BHHTOrdDetForm.ExcludeLabel");
            
        }

        // grid row validated event
        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            SaveData();
        }

        // grid cell value changed event
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (bindingOrderDetails.Current == null) return;
            DataRowView row = (DataRowView)bindingOrderDetails.Current;

            if (e.ColumnIndex == colExcludeFromOrder.Index)
            {
                // if unchecking the ExcludeFromOrder checkmark,
                // check that all other fields are filled in on the record
                if(!tools.object2bool(row["ExcludeFromOrder"]))
                {
                    if ((row["BHHTOrderID"] == DBNull.Value) ||
                        (row["LineNo"] == DBNull.Value) ||
                        (row["ItemID"] == DBNull.Value) ||
                        (row["ReceiptText"] == DBNull.Value) ||
                        (row["Cost"] == DBNull.Value) ||
                        (row["PackageCost"] == DBNull.Value) ||
                        (row["SuppItemID"] == DBNull.Value) ||
                        (row["PackType"] == DBNull.Value) ||
                        (row["OrderingNumber"] == DBNull.Value) ||
                        (row["Kolli"] == DBNull.Value) ||
                        (row["Quantity"] == DBNull.Value))
                    {
                        MessageBox.Show(db.GetLangString("BHHTOrderDetailForm.CannotRemoveCheckmark"));
                        row["ExcludeFromOrder"] = true;
                        dataGridView1.Refresh();
                    }
                }
            }
        }
    }
}