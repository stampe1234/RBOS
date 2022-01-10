using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class OrderAsDraft : Form
    {
        // delegate used for calling OrderDetail's SaveData method
        public delegate bool Delegate_OrderDetails_SaveData();

        // variable to hold the above delegate instance
        Delegate_OrderDetails_SaveData delegate_orderdetails_savedata = null;

        int OrderID = -1;

        // constructor
        public OrderAsDraft(int OrderID, Delegate_OrderDetails_SaveData savedataMethod)
        {
            InitializeComponent();

            // create orderdetails savedata delegate instance
            // and pass it the savedata method provided
            delegate_orderdetails_savedata = new Delegate_OrderDetails_SaveData(savedataMethod);

            // keep orderid
            this.OrderID = OrderID;

            // localize
            this.Text = db.GetLangString("OrderAsDraft.Title");
            lbDraftName.Text = db.GetLangString("OrderAsDraft.lbDraftName");
            lbInfo.Text = db.GetLangString("OrderAsDraft.lbInfo");
            btnCreate.Text = db.GetLangString("Application.Create");
            btnCancel.Text = db.GetLangString("Application.Cancel");
        }

        // create button click event
        private void btnCreate_Click(object sender, EventArgs e)
        {
            // check that a draft name has been specified
            if (txtDraftName.Text == "")
            {
                MessageBox.Show(db.GetLangString("OrderAsDraft.PleaseSpecifyADraftName"));
                if (txtDraftName.CanFocus)
                    txtDraftName.Focus();
                return;
            }

            // call OrderDetail's savedata method
            if (delegate_orderdetails_savedata())
            {
                ItemDataSet dsItem = new ItemDataSet();

                // create a new order draft header, so we get the
                // autogeneratd id from the database
                int DraftID = dsItem.OrderDraft.CreateNewOrderDraft();

                // lookup order header row
                DataRow rowHeader = db.GetDataRow(string.Format(
                    " select * from OrderHeader where OrderID = {0} ", OrderID));

                if(rowHeader != null)
                {
                    // insert the remaining order draft header values pn20190809
                    db.ExecuteNonQuery(string.Format(
                        " update OrderDraft set " +
                        " DraftName = '{0}', " +
                        " SupplierID = {1} " + 
                        " where DraftID = {2} ",
                        txtDraftName.Text,
                        rowHeader["SupplierID"],
                        DraftID));

                    // now we want to copy values from
                    // OrderDetails rows to OrderDraftDetails row

                    // first create a table with OrderDetails data
                    DataTable tableOrderDetails = db.GetDataTable(string.Format(
                        " select * from OrderDetails where OrderID = {0} ", OrderID));
                    
                    // traverse the OrderDetails rows and copy
                    // the values to the OrderDraftDetails table
                    foreach (DataRow row in tableOrderDetails.Rows)
                    {
                        db.ExecuteNonQuery(string.Format(
                            " insert into OrderDraftDetails " +
                            " (DraftID,[LineNo],SuppItemID,OrderingNumber,KolliSize,PackageCost,PackType,ReceiptText,Cost,Quantity,ReceivedQuantity) " +
                            " values ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}) ",
                            DraftID,
                            ItemDataSet.OrderDraftDetailsDataTable.GenerateNextLineNo(DraftID),
                            tools.wholenumber4sql(row["SuppItemID"]),
                            tools.decimalnumber4sql(row["OrderingNumber"]),
                            tools.wholenumber4sql(row["KolliSize"]),
                            tools.decimalnumber4sql(row["PackageCost"]),
                            tools.wholenumber4sql(row["PackType"]),
                            tools.string4sql(row["ReceiptText"], 30),
                            tools.decimalnumber4sql(row["Cost"]),
                            tools.wholenumber4sql(row["Quantity"]),
                            tools.wholenumber4sql(row["ReceivedQuantity"])));
                    }

                    // draft creating complete
                    MessageBox.Show(db.GetLangString("OrderAsDraft.CreationCompleted"));
                    Close();
                }
            }
        }

        // cancel button click event
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OrderAsDraft_Load(object sender, EventArgs e)
        {
        }

        private void txtDraftName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnCreate.PerformClick();
        }
    }
}