using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace RBOS
{
    public partial class OrderDetailsForm : Form
    {
        #region Private variables

        // the current OrderID
        private int OrderID = -1;

        FormState CurrentFormState = FormState.Edit;

        #endregion

        #region ENUM: FormState
        /// <summary>
        /// Used when setting the form's state, that is,
        /// setting control's visiblity, enabled etc.
        /// </summary>
        private enum FormState
        {
            Edit,
            Sent,
            Receive,
            Booked
        }
        #endregion

        #region Constructor

        public OrderDetailsForm(int OrderID)
        {
            InitializeComponent();

            // set connections
            adapterOrderHeaderSingle.Connection = db.Connection;
            adapterRelOrderDetails.Connection = db.Connection;
            adapterLookupSupplier.Connection = db.Connection;
            adapterLookupStatus.Connection = db.Connection;
            adapterLookupPackSize.Connection = db.Connection;

            // load data
            this.OrderID = OrderID;
            adapterOrderHeaderSingle.Fill(dsItem.OrderHeaderSingle, OrderID);
            adapterRelOrderDetails.Fill(dsItem.OrderDetails, OrderID);
            adapterLookupSupplier.Fill(dsItem.LookupSupplier);
            adapterLookupStatus.Fill(dsItem.LookupStatus);
            adapterLookupPackSize.Fill(dsItem.LookupPackSize);

            /// localization
            /// NOTE: This MUST be done before calling SetFormState
            /// as that method sets some language string(s) too.
            this.Text = db.GetLangString("OrderDetailsForm.Title");
            btnCancel.Text = db.GetLangString("Application.Cancel");

            // set initial form state
            if (bindingOrderHeaderSingle.Current != null)
            {
                DataRowView row = (DataRowView)bindingOrderHeaderSingle.Current;
                switch(row["OrderStatus"].ToString())
                {
                    case "OPN": SetFormState(FormState.Edit); break;
                    case "SNT": SetFormState(FormState.Sent); break;
                    case "BKD": SetFormState(FormState.Booked); break;
                    default: SetFormState(FormState.Edit); break;
                }
            }

            // default dialog result is cancel
            this.DialogResult = DialogResult.Cancel;

            // position grid columns (bug in VS2005)
            int DisplayIndex = -1;
            colOrderingNumber.DisplayIndex = ++DisplayIndex;
            colOrderingNumberButton.DisplayIndex = ++DisplayIndex;
            colDescription.DisplayIndex = ++DisplayIndex;
            colKolli.DisplayIndex = ++DisplayIndex;
            colPackType.DisplayIndex = ++DisplayIndex;
            colKolliCost.DisplayIndex = ++DisplayIndex;
            colQuantity.DisplayIndex = ++DisplayIndex;
            colReceivedQuantity.DisplayIndex = ++DisplayIndex;
            colCostExVat.DisplayIndex = ++DisplayIndex;
            colCost.DisplayIndex = ++DisplayIndex;

            // fix a bug in the 3rd party NullableDateTimePicker
            // that causes first the selected date to be some fixed
            // date in the past.
            if (dtOrderingDate.Value == null)
            {
                dtOrderingDate.Value = DateTime.Now;
                //dtOrderingDate.Value = null;
            }
            if (dtDeliveryDate.Value == null)
            {
                dtDeliveryDate.Value = DateTime.Now;
                //dtDeliveryDate.Value = null;
            }

            // subscribe to the OnCostPriceChanged event in the OrderDetails class
            dsItem.OrderDetails.OnCostPriceChanged += new ItemDataSet.OrderDetailsDataTable.CostPriceChanged(OrderDetails_OnCostPriceChanged);
        }

        #region OnCostPriceChanged event handler
        /// <summary>
        /// Whenever cost price changes, recalculate cost totals.
        /// </summary>
        void OrderDetails_OnCostPriceChanged()
        {
            CalculateCostTotals();
        }
        #endregion

        #endregion

        #region METHOD: SetFormState
        /// <summary>
        /// Checks if the order's status is OPN, and if not,
        /// some controls are locked on the form so user
        /// cannot edit the order anymore.
        /// </summary>
        private void SetFormState(FormState state)
        {
            CurrentFormState = state;

            gridOrderDetails.ReadOnly = ((state == FormState.Sent) || (state == FormState.Booked));
            dtOrderingDate.Enabled = (state == FormState.Edit);
            dtDeliveryDate.Enabled = ((state == FormState.Edit) || (state == FormState.Receive));
            btnSaveAndSend.Enabled = (state == FormState.Edit);
            btnSaveAndClose.Enabled = (state == FormState.Edit || state == FormState.Receive);
            gridOrderDetails.AllowUserToAddRows = (state == FormState.Edit);
            btnAddItemInRecvMode.Visible = (state == FormState.Receive);

            if (state != FormState.Edit)
            {
                gridOrderDetails.DefaultCellStyle.BackColor = SystemColors.Control;
                btnCancel.Text = db.GetLangString("Application.Close");
            }

            if (state == FormState.Receive)
            {
                // copy all Quantity values to ReceivedQuantity
                // if no value is present in ReceivedQuantity
                foreach (DataRow row in dsItem.OrderDetails.Rows)
                {
                    if ((row.RowState != DataRowState.Deleted) &&
                        (row.RowState != DataRowState.Detached) &&
                        tools.IsNullOrDBNull(row["ReceivedQuantity"]))
                    {
                        row["ReceivedQuantity"] = row["Quantity"];
                    }
                }
                
                gridOrderDetails.Refresh();

                // enable ReceivedQuantity column in grid while disabling all other columns
                foreach (DataGridViewColumn col in gridOrderDetails.Columns)
                {
                    if(col.Index != colReceivedQuantity.Index)
                        col.ReadOnly = true;
                }

                // set background color of ReceivedQuantity column to window (white)
                colReceivedQuantity.DefaultCellStyle.BackColor = SystemColors.Window;

                // position book button at receive button's location
                btnBook.Location = btnReceive.Location;

                btnCancel.Text = db.GetLangString("Application.Cancel");

                if (gridOrderDetails.CanFocus)
                    gridOrderDetails.Focus();
                gridOrderDetails.JumpToColumn(colReceivedQuantity);
            }

            if (state == FormState.Booked)
            {
                // set background color of ReceivedQuantity column to control
                colReceivedQuantity.DefaultCellStyle.BackColor = SystemColors.Control;
            }

            // must be set after checking for FormState.Receive
            btnReceive.Visible = (state != FormState.Receive);
            btnReceive.Enabled = (state == FormState.Sent);
            btnBook.Visible = (state == FormState.Receive);
        }
        #endregion

        #region METHOD: SaveData
        /// <summary>
        /// Saves the OrderHeader and OrderDetails data to disk.
        /// </summary>
        private bool SaveDataToDisk()
        {
            /// The reason why this method is called SaveDataToDisk
            /// is because we want to make 100% sure this method does
            /// not get changed so it does not save to disk as it is
            /// passed to a method that expects it to save to disk.

            // save OrderDetails
            bindingRelOrderDetails.EndEdit();
            if (!CheckDates()) return false;
            adapterRelOrderDetails.Update(dsItem.OrderDetails);

            // perform OrderDetail calculations to be inserted in OrderHeader row
            if (bindingOrderHeaderSingle.Current != null)
            {
                // assign number of details to OrderHeader.NumberDetails
                DataRowView headerRow = (DataRowView)bindingOrderHeaderSingle.Current;
                headerRow["NumberDetails"] = dsItem.OrderDetails.Count;
                headerRow["TotalCost"] = OrderCommon.CalculateCostTotal(dsItem.OrderDetails, bindingRelOrderDetails);
            }

            // save OrderHeader
            bindingOrderHeaderSingle.EndEdit();
            adapterOrderHeaderSingle.Update(dsItem.OrderHeaderSingle);

            // save ok
            return true;
        }
        #endregion

        #region METHOD: SendOrder
        /// <summary>
        /// Sends the selected order. This is public
        /// as the OrderDetails window needs it too.
        /// Note: This method does not save the Order,
        /// as this is done from the OrderDetails window.
        /// </summary>
        public void SendOrder(bool DisplayConfirmMessage)
        {
            // end edit of any data
            bindingOrderHeaderSingle.EndEdit();
            bindingRelOrderDetails.EndEdit();

            if (bindingOrderHeaderSingle.Current == null) return;
            DataRowView orderRow = (DataRowView)bindingOrderHeaderSingle.Current;

            // check that the order's status is OPN
            if (!orderRow["OrderStatus"].Equals("OPN"))
            {
                string msg = db.GetLangString("OrderDetailsForm.NotSendAgainMsg");
                MessageBox.Show(msg);
                return;
            }

            // check that the order has details
            if(tools.object2int(orderRow["NumberDetails"]) <= 0)
            {
                string msg = db.GetLangString("OrderDetailsForm.No DetailLinesMsg");
                MessageBox.Show(msg);
                return;
            }

            // check that DeliveryDate is not earlier than OrderDate
            DateTime dtOrder = tools.object2datetime(orderRow["OrderDate"]);
            DateTime dtDeliver = tools.object2datetime(orderRow["DeliveryDate"]);
            if (dtDeliver.Date < dtOrder.Date)
            {
                string msg = db.GetLangString("OrderDetailsForm.DelivDateNotBefOrdDateMsg");
                MessageBox.Show(msg);
                return;
            }

            // check other needed values for null
            if ((orderRow["OrderID"] == DBNull.Value) ||
                (orderRow["SupplierID"] == DBNull.Value) ||
                (orderRow["OrderDate"] == DBNull.Value) ||
                (orderRow["DeliveryDate"] == DBNull.Value))
            {
                string msg = db.GetLangString("OrderDetailsForm.ValuesMissingHeaderMsg");
                MessageBox.Show(msg);
                return;
            }

            // check that the order's details rows has needed values for sending out the order
            string sqlDetails = string.Format(
                " select * from OrderDetails " +
                " where (OrderID = {0}) " +
                " and ((SuppItemID is null) " +
                " or (OrderingNumber is null) " +
                " or (Quantity is null)) ",
                orderRow["OrderID"]);
            OleDbCommand cmd = new OleDbCommand(sqlDetails, db.Connection);
            object o = cmd.ExecuteScalar();
            if ((o != null) && (o != DBNull.Value))
            {
                string msg = db.GetLangString("OrderDetailsForm.DetailRowsWithError");
                MessageBox.Show(msg);
                return;
            }

            // display send confirm message (if on)
            if (DisplayConfirmMessage)
            {
                string msg = db.GetLangString("OrderDetailsForm.DoYouWantToSendOrder");
                if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return; // user cancels the send
            }

            // get supplier for this order
            DataRow supplierRow = dbSupplier.GetSupplier(tools.object2int(orderRow["SupplierID"]));
            if (supplierRow == null)
            {
                MessageBox.Show(db.GetLangString("OrderDetailsForm.ErrorLookupSupplier"));
                return;
            }

            // determine if the order's selected supplier sends by fax,
            // if not, the supplier sends by FTP
            bool sendByFax = supplierRow["SendMode"].Equals("FAX");

            // finally do the actual sending of the order
            if (sendByFax)
            {
                // send by fax

                // if supplier sends by fax, the OrderPrint dialog is displayed
                OrderReportForm report = new OrderReportForm(OrderID);
                if (report.ShowDialog() == DialogResult.OK)
                {
                    MarkOrderAsSent(orderRow);
                    MessageBox.Show(db.GetLangString("OrderDetailsForm.OrderSentMsg"));
                }
            }
            else
            {
                // send by ftp

                // get FTP account for supplier
                int FTPAccoundID = tools.object2int(supplierRow["FTPAccountID"]);
                DataRow ftpAccount = AdminDataSet.FTPAccountsDataTable.GetFTPAccount(FTPAccoundID);
                if (ftpAccount == null)
                {
                    MessageBox.Show(db.GetLangString("OrderDetailsForm.SupplierFTPMissing"));
                    return;
                }

                // get the order file format
                string orderFileFormat = supplierRow["OrderFileFormat"].ToString();

                // get where to place the order file
                string orderFileDir = ftpAccount["ClientDepartureDir"].ToString();

                string orderFilename = "";
                string fullOrderFilePath = "";
                // generate order file
                if (orderFileFormat == "NOR")
                {

                    // get norddata kundenr
                    string norddatakundenr = AdminDataSet.SiteInformationDataTable.GetNorddataKundenr();

                    // generate order file name and a full path version
                    orderFilename =
                        AdminDataSet.SiteInformationDataTable.GetSiteCode() +
                        DateTime.Now.ToString("yyyyMMddHHmmss") + ".drs";
                    fullOrderFilePath = orderFileDir + "\\" + orderFilename;
                                        
                    // create file
                    StreamWriter writer = new StreamWriter(fullOrderFilePath);

                    // write order header
                    writer.Write("H"); // pos 01-01
                    writer.Write(tools.object2int(norddatakundenr).ToString("000000")); // pos 02-07 = 6 padded digits
                    writer.Write(tools.object2datetime(orderRow["DeliveryDate"]).ToString("yyyyMMdd")); // pos 08-15
                    writer.Write("00"); // @@@ TODO (Ordrekode) // pos 16-17 = 2 padded digits
                    writer.Write(" "); // pos 18-18 = 1 blank
                    writer.WriteLine("");

                    // write order details
                    int detailCount = 0;
                    foreach (DataRow detailRow in dsItem.OrderDetails.Rows)
                    {
                        if ((detailRow.RowState != DataRowState.Deleted) &&
                            (detailRow.RowState != DataRowState.Detached) &&
                            (tools.object2int(detailRow["Quantity"]) > 0) ) // do not send details with quantity <= 0
                        {
                            writer.Write("D"); // pos 01-01
                            writer.Write(tools.object2int(detailRow["OrderingNumber"]).ToString("0000000000000")); // pos 02-14 = 13 padded digits
                            writer.Write(tools.object2int(detailRow["Quantity"]).ToString("0000")); // pos 15-18 = 4 padded digits
                            writer.WriteLine("");
                            ++detailCount;
                        }                        
                    }

                    // write order footer
                    writer.Write("T"); // pos 01-01
                    writer.Write(detailCount.ToString("0000000")); // pos 02-08 = 7 padded digits
                    writer.Write("          "); // pos 09-18 = 10 blanks

                    // close file
                    writer.Close();
                }

                if (orderFileFormat== "OIO")
                {
                                        
                    ExportOIO OIOexport = new ExportOIO();
                    DataTable OrderDetails = OIOexport.CreateOIOData(tools.object2int(orderRow["OrderID"]));
                    orderFilename = "Reitan" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml";
                    fullOrderFilePath = orderFileDir + "\\" + orderFilename;
                    OIOexport.ExportOIOData(OrderDetails, fullOrderFilePath);
                   

                }
                
                // send order via FTP
                FTP ftp = new FTP(tools.object2int(ftpAccount["ID"]), this);
                if (!ftp.UploadFile(orderFilename))
                {
                    // error sending file via FTP
                    MessageBox.Show(db.GetLangString("OrderDetailsForm.ErrorSendingFile"));
                    // delete the unsent order file
                    if (File.Exists(fullOrderFilePath))
                        File.Delete(fullOrderFilePath);
                    return;
                }
                else
                {
                    MarkOrderAsSent(orderRow);

                    // display success message
                    MessageBox.Show(db.GetLangString("OrderDetailsForm.FileSentSuccessfully"));

                    // automatically close FTP log window
                    ftp.CloseLogWindow();
                }
            } // end if FTP
        }
        #endregion

        #region METHOD: MarkOrderAsSent
        /// <summary>
        /// Marks the order as sent and sets the form state to sent.
        /// Update Sent Date with Today
        /// </summary>
        /// <param name="orderRow"></param>
        private void MarkOrderAsSent(DataRowView orderRow)
        {
            // mark order as sent
            orderRow["OrderStatus"] = "SNT";
            orderRow["SentDate"] = DateTime.Now;
            bindingOrderHeaderSingle.EndEdit();
            adapterOrderHeaderSingle.Update(dsItem.OrderHeaderSingle);

            // set form state to sent
            SetFormState(FormState.Sent);
        }
        #endregion

        #region METHOD: BookOrder
        private void BookOrder()
        {
            // confirm with user that book is wanted
            string msg = db.GetLangString("OrderDetailsForm.BookThisOrderMsg");  
            if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            if(bindingOrderHeaderSingle.Current == null) return;
            DataRowView headerRow = (DataRowView)bindingOrderHeaderSingle.Current;
            
            // end edit of any data
            bindingOrderHeaderSingle.EndEdit();
            bindingRelOrderDetails.EndEdit();

            // move order data to ItemTransaction
            foreach (DataRow detailRow in dsItem.OrderDetails.Rows)
            {
                if ((detailRow.RowState != DataRowState.Deleted) &&
                    (detailRow.RowState != DataRowState.Detached))
                {
                    // lookup SupplierItem to get additional data
                    int SupplierItemID = tools.object2int(detailRow["SuppItemID"]);
                    DataRow supplierItemRow = ItemDataSet.SupplierItemDataTable.GetSupplierItem(SupplierItemID);
                    if (supplierItemRow != null)
                    {
                        // get all values for the new ItemTransaction row
                        int ItemID = tools.object2int(supplierItemRow["ItemID"]);
                        DateTime PostingDate = tools.object2datetime(headerRow["DeliveryDate"]).Date;
                        byte TransactionType = (byte)db.TransactionTypes.Purchase;
                        int NumberOf = tools.object2int(detailRow["ReceivedQuantity"]);
                        double Amount = tools.object2double(detailRow["Cost"]);
                        byte SalesPackType = tools.object2byte(detailRow["PackType"]);
                        //byte ReasonCode = (byte)db.ReasonCodes.None;
                        int tmpKolliSize = tools.object2int(detailRow["KolliSize"]);
                        //>>pn20200928
                        //int NoOfSellingUnits = tools.object2int(supplierItemRow["NoOfSellingUnits"]) * NumberOf * tmpKolliSize;
                        int NoOfSellingUnits =  NumberOf * tmpKolliSize;

                        //<<pn20200928
                        // write item transaction record
                        ItemDataSet.ItemTransactionDataTable.WriteTransactionRecord(
                            ItemID,
                            PostingDate,
                            TransactionType,
                            NumberOf,
                            Amount,
                            SalesPackType,
                            null,
                            NoOfSellingUnits,
                            0,
                            true);
                    }
                }
            }

            // mark the order as booked
            if (bindingOrderHeaderSingle.Current != null)
            {
                headerRow["OrderStatus"] = "BKD";
                SaveDataToDisk();
                gridOrderDetails.Refresh();
                SetFormState(FormState.Booked);
            }
        }
        #endregion

        #region METHOD: CheckDates
        /// <summary>
        /// Checks if DeliveryDate is earlier than OrdringDate.
        /// Display a message if so.
        /// </summary>
        /// <returns>
        /// False if delivery date is earlier than order date.
        /// In any other case, true is returned,
        /// also if one or both dates are null.
        /// </returns>
        private bool CheckDates()
        {
            if ((dtOrderingDate.Value != null) && (dtDeliveryDate.Value != null))
            {
                DateTime dtOrder = tools.object2datetime(dtOrderingDate.Value);
                DateTime dtDeliver = tools.object2datetime(dtDeliveryDate.Value);
                if (dtDeliver.Date < dtOrder.Date)
                {
                    MessageBox.Show(db.GetLangString("OrderDetailsForm.DelivDateNotBefOrdDateMsg"));
                    return false;
                }
            }
            return true;
        }
        #endregion

        private void CalculateCostTotals()
        {
            double sum = 0;
            double sumExVAT = 0;
            foreach (DataGridViewRow row in gridOrderDetails.Rows)
            {
                sum += tools.object2double(row.Cells[colCost.Index].Value);
                sumExVAT += tools.object2double(row.Cells[colCostExVat.Index].Value);
            }
            txtTotalCost.Text = sum.ToString("N2");
            txtTotalCostExVAT.Text = sumExVAT.ToString("N2");
        }

        // save and close button click event
        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            if (SaveDataToDisk())
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        // cancel button click event
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // form load event
        private void OrderDetailsForm_Load(object sender, EventArgs e)
        {
            CalculateCostTotals();

            lbOrderID.Text = db.GetLangString("OrderDetailForm.OrderIDLabel");
            lbSupplierID.Text = db.GetLangString("OrderDetailForm.SupplIDLabel");
            lbSupplierName.Text = db.GetLangString("OrderDetailForm.SupplNameLabel");
            lbStatus.Text = db.GetLangString("OrderDetailForm.StatusLabel");
            lbOrderingDate.Text = db.GetLangString("OrderDetailForm.OrderDateLabel");
            lbDeliveryDate.Text = db.GetLangString("OrderDetailForm.DeliveryDateLabel");
            lbSentDate.Text = db.GetLangString("OrderDetailForm.SentDateLabel");
            
            colDescription.HeaderText = db.GetLangString("OrderDetailForm.DescriptionLabel");
            colPackType.HeaderText = db.GetLangString("OrderDetailForm.PackTypeLabel");
            colKolli.HeaderText = db.GetLangString("OrderDetailForm.KolliLabel");
            colKolliCost.HeaderText = db.GetLangString("OrderDetailForm.KolliCostLabel");
            colOrderingNumber.HeaderText = db.GetLangString("OrderDetailForm.OrderingNumberLabel");
            colCost.HeaderText = db.GetLangString("OrderDetailForm.LineCostLabel");
            colCostExVat.HeaderText = db.GetLangString("OrderDetailForm.colCostExVAT");
            colQuantity.HeaderText = db.GetLangString("OrderDetailForm.QuantityLabel");
            colReceivedQuantity.HeaderText = db.GetLangString("OrderDetailForm.ReceivedQuanLabel");

            lbNumberOfDetails.Text = db.GetLangString("OrderDetailForm.NumberOfDetailLinesLabel");
            lbTotalCost.Text = db.GetLangString("OrderDetailForm.TotalCostLabel");
            lbTotalCostExVAT.Text = db.GetLangString("OrderDetailForm.lbTotalCostExVAT");
            btnPrint.Text = db.GetLangString("OrderDetailForm.PrintOrderLabel");
            btnBook.Text = db.GetLangString("OrderDetailForm.BookOrderLabel");
            btnReceive.Text = db.GetLangString("OrderDetailForm.ReceiveLabel");
            btnSaveAndSend.Text = db.GetLangString("OrderDetailForm.SaveAndSendLabel");
            btnSaveAndClose.Text = db.GetLangString("OrderDetailForm.SaveAndCloseLabel");
            // DO NOT LOCALIZE IT HERE - btnCancel.Text = db.GetLangString("Application.Cancel");
            btnAddItemInRecvMode.Text = db.GetLangString("OrderDetailsForm.AddItemButton");
            btnCreateAsDraft.Text = db.GetLangString("OrderDetailsForm.CreateAsDraftButton");
        }

        // textbox suppliername text changed event
        private void txtSupplierName_TextChanged(object sender, EventArgs e)
        {
            // lookup supplier name
            txtSupplierName.Text = tools.LookupValue(
                bindingOrderHeaderSingle,
                bindingLookupSupplier,
                "SupplierID",
                "SupplierID",
                "Description");
        }

        // status text - text changed event
        private void txtStatus_TextChanged(object sender, EventArgs e)
        {
            // lookup status text
            txtStatus.Text = tools.LookupValue(
                 bindingOrderHeaderSingle,
                 bindingLookupStatus,
                 "OrderStatus",
                 "StatusID",
                 "Description");
        }

        // grid rows added event
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            OrderCommon.DisplayNumberOfDetailRecords(gridOrderDetails, txtNumberOfDetails);
        }

        // grid rows removed event
        private void gridOrderDetails_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            OrderCommon.DisplayNumberOfDetailRecords(gridOrderDetails, txtNumberOfDetails);
            CalculateCostTotals();
        }

        // grid cell validating event
        private void gridOrderDetails_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (gridOrderDetails.CurrentCell == null) return;
            if (e.ColumnIndex == colOrderingNumber.Index)
            {
                // get the just entered OrderingNumber and the old OrdringNumber
                double newOrderingNumber = tools.object2double(e.FormattedValue);
                double oldOrderingNumber = tools.object2double(gridOrderDetails.CurrentCell.FormattedValue);
                
                // check if a new value has been entered before performing the lookup
                if (oldOrderingNumber != newOrderingNumber)
                {
                    if (!OrderCommon.InsertNewOrderingNumberAndLookups(
                        bindingOrderHeaderSingle,
                        bindingRelOrderDetails,
                        gridOrderDetails,
                        newOrderingNumber))
                        e.Cancel = true;
                }
            }
        }

        // grid cell end edit event
        private void gridOrderDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            /* DO NOT PUT A GRID REFRESH CODE LINE IN HERE, AS IT CAUSES
             * THE GRID TO CRASH IF PRESSING ESC WHEN EDITING A CELL ON
             * A NEW ROW. INSTEAD USE THE CellValidated EVENT, WHERE THE
             * GRID DOES NOT CRASH IN THE OTHERWISE SAME SCENARIO. */
        }

        // grid row validating event
        private void gridOrderDetails_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (bindingRelOrderDetails.Current == null) return;
            DataRowView row = (DataRowView)bindingRelOrderDetails.Current;

            // check that needed values have been entered in the row, before validating ok
            if (row["SuppItemID"] != DBNull.Value)
            {
                // supplier item has been specified, check for quantity
                if (row["Quantity"] == DBNull.Value)
                {
                    MessageBox.Show(db.GetLangString("OrderDetailsForm.SpecifyQuantityMsg"));
                    e.Cancel = true; 
                }

                // if in received mode, check that received quantity is not empty
                if (CurrentFormState == FormState.Receive)
                {
                    if (row["ReceivedQuantity"] == DBNull.Value)
                    {
                        MessageBox.Show(db.GetLangString("OrderDetailsForm.SpecifyQuantityMsg"));
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                // SupplierItemID not filled in, and as the only other
                // field that can be filled in is the Quantity, calling
                // cancel will cancel the row.
                if (row["SuppItemID"] == DBNull.Value)
                    gridOrderDetails.CancelEdit();
            }
        }

        // grid cell validated event
        private void gridOrderDetails_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (bindingOrderHeaderSingle.Current == null) return;
            if (bindingRelOrderDetails.Current == null) return;
            DataRowView detailRow = (DataRowView)bindingRelOrderDetails.Current;

            // when ending edit of columns OrderingNumber or Quantity,
            // update Cost, Cost ex. VAT, Total Cost and Total Cost ex. VAT.
            if ((CurrentFormState != FormState.Booked) &&
                ((e.ColumnIndex == colOrderingNumber.Index) ||
                 (e.ColumnIndex == colQuantity.Index) ||
                 (e.ColumnIndex == colReceivedQuantity.Index)))
            {
                // calculate and save Cost (if value was changed)
                int Quantity = tools.object2int(detailRow["Quantity"]);
                if(CurrentFormState == FormState.Receive)
                    Quantity = tools.object2int(detailRow["ReceivedQuantity"]);
                double PackageCost = tools.object2double(detailRow["PackageCost"]);
                double Cost = Quantity * PackageCost;
                if (Cost != tools.object2double(detailRow["Cost"]))
                {
                    // set cost (cost ex. vat is set in the database code)
                    detailRow["Cost"] = Cost;

                    // refresh grid to reflect changes
                    gridOrderDetails.Refresh();
                }                
            }
        }

        // save and send button click event
        private void btnSaveAndSend_Click(object sender, EventArgs e)
        {
            if(SaveDataToDisk())
                SendOrder(true);
        }

        // ordering date leave event
        private void dtOrderingDate_Leave(object sender, EventArgs e)
        {
            CheckDates();
        }

        // delivery date leave event
        private void dtDeliveryDate_Leave(object sender, EventArgs e)
        {
            CheckDates();
        }

        // receive button click event
        private void btnReceive_Click(object sender, EventArgs e)
        {
            SetFormState(FormState.Receive);
        }

        // book button click event
        private void btnBook_Click(object sender, EventArgs e)
        {
            BookOrder();
        }

        // print button click event
        private void btnPrint_Click(object sender, EventArgs e)
        {
            OrderReportForm print = new OrderReportForm(OrderID);
            print.ShowDialog();
        }

        // btnAddItemInRecvMode click event
        private void btnAddItemInRecvMode_Click(object sender, EventArgs e)
        {
            // when user clicks the add-item-in-recv-mode button
            try
            {
                // this is much done in the grid and by user simulated input
                // to be able to use already implemented methods that handles user input

                // focus the grid to better simulate user input
                if (gridOrderDetails.CanFocus)
                    gridOrderDetails.Focus();

                // create a new record
                bindingRelOrderDetails.AddNew();

                // set default quantity value to 1 and default received quantity value to 0
                gridOrderDetails[colQuantity.Index, gridOrderDetails.CurrentCell.RowIndex].Value = 1;
                gridOrderDetails[colReceivedQuantity.Index, gridOrderDetails.CurrentCell.RowIndex].Value = 0;

                // set the grid's current cell to the ordering number column
                gridOrderDetails.CurrentCell = gridOrderDetails[colOrderingNumber.Index, gridOrderDetails.CurrentCell.RowIndex];

                // perform the logic usually applied when hitting clicking
                // search supplier no button to select and insert an ordering number
                if (OrderCommon.OpenSupplierItemSearchForm(
                    bindingOrderHeaderSingle,
                    bindingRelOrderDetails,
                    gridOrderDetails,
                    colOrderingNumber,
                    colReceivedQuantity))
                {
                    // item selected so end the edit operation
                    bindingRelOrderDetails.EndEdit();
                }
                else
                {
                    // no item selected so cancel the edit operation
                    bindingRelOrderDetails.CancelEdit();
                }
            }
            catch { }
        }

        // button CreateAsDract click event
        private void btnCreateAsDraft_Click(object sender, EventArgs e)
        {
            OrderAsDraft form = new OrderAsDraft(OrderID, this.SaveDataToDisk);
            form.ShowDialog();
        }

        private void gridOrderDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colOrderingNumberButton.Index)
            {
                // show supplier search form
                if (CurrentFormState == FormState.Edit)
                {
                    OrderCommon.OpenSupplierItemSearchForm(
                        bindingOrderHeaderSingle,
                        bindingRelOrderDetails,
                        gridOrderDetails,
                        colOrderingNumber,
                        colQuantity);
                }

                // do NOT call grid.EndEdit() here
                // as it spoils the possibility of checking if
                // a value has changed.
            }
        }

        private void gridOrderDetails_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            ImageButtonRender.OnCellPainting(e, colOrderingNumberButton.Index, ImageButtonRender.Images.Search);
        }

        private void gridOrderDetails_KeyUp(object sender, KeyEventArgs e)
        {
            if (CurrentFormState != FormState.Receive)
            {
                if (gridOrderDetails.CurrentColumn == colOrderingNumberButton)
                {
                    if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                        gridOrderDetails.JumpToColumn(colQuantity);
                }
                else if (gridOrderDetails.CurrentColumn == colReceivedQuantity)
                {
                    if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                        gridOrderDetails.JumpToNextRow();
                }
            }
            else // dvs vi er i FormState.Recieve mode
            {
                if (gridOrderDetails.CurrentColumn == colCostExVat)
                {
                    if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                    {
                        gridOrderDetails.JumpLeft();
                        gridOrderDetails.JumpDown();
                    }
                }
            }
        }
    }
}