using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class ItemUpdLines : Form
    {
        #region enum ActionType
        private enum ActionType
        {
            NewItem,
            NewSupplierNo,
            ItemDiscarded,
            NewCostPrice,
            NewSalesPrice,
            NewBarcode
        }
        #endregion

        #region Private variables

        int ID = 0; // header ID

        int NewItemLineNo = 0; // used when creating new item

        /// variable used when counting how many imported items that
        /// was coming with a FSD_ID that already existed on another item.
        /// This we will show to the user after import.
        Dictionary<int, int> ItemsWithFSD_IDsAlreadyOnAnotherItem = new Dictionary<int, int>();

        bool DOSite = (db.GetConfigStringAsBool("DOVersion"));

        #endregion

        #region Constructor
        public ItemUpdLines(int ID)
        {
            InitializeComponent();
            this.ID = ID;

#if FSD
            colKampagneID.Visible = false;
#endif

            // position grid columns (bug in VS2005)
            int idx = 0;
            colName.DisplayIndex = idx++;
            colSubCat.DisplayIndex = idx++;
            colKolli.DisplayIndex = idx++;
            colCostPrice.DisplayIndex = idx++;
            colSalesPrice.DisplayIndex = idx++;
            // colFutureSalesPriceDate.DisplayIndex = idx++;
            //colPackType.DisplayIndex = idx++;
#if !FSD
            //colKampagneID.DisplayIndex = idx++;
#endif
            colActionSummary.DisplayIndex = idx++;
            colActionDoneSummary.DisplayIndex = idx++;
            colSkip.DisplayIndex = idx++;
            colStatus.DisplayIndex = idx++;
            colStatusColor.DisplayIndex = idx++;          

            colInfoButton.DisplayIndex = idx++;
            colExecuteButton.DisplayIndex = idx++;

            // localization
#if FSD
            this.Text = db.GetLangString("ItemUpdLines.Title_FSD");
#else
            this.Text = db.GetLangString("ItemUpdLines.Title");
#endif
            btnClose.Text = db.GetLangString("Application.Close");
            //btnAllDiscarded.Text = db.GetLangString("ItemUpdLines.btnAllDiscarded");
            //btnAllSupplierItemNo.Text = db.GetLangString("ItemUpdLines.btnAllSupplierItemNo");
            btnAllSales.Text = db.GetLangString("ItemUpdLines.btnAllSales");
            //btnAllCost.Text = db.GetLangString("ItemUpdLines.btnAllCost");
            btnSkipAllSalesPrices.Text = db.GetLangString("ItemUpdLines.btnSkipAllSalesPrices");
            btnAllNewItems.Text = db.GetLangString("ItemUpdLines.btnAllNewItems");
            colActionDoneSummary.HeaderText = db.GetLangString("ItemUpdLines.colActionDoneSummary");
            colActionSummary.HeaderText = db.GetLangString("ItemUpdLines.colActionSummary");
            colCostPrice.HeaderText = db.GetLangString("ItemUpdLines.colCostPrice");
            colKolli.HeaderText = db.GetLangString("ItemUpdLines.colKolli");
            colName.HeaderText = db.GetLangString("ItemUpdLines.colName");
            colSalesPrice.HeaderText = db.GetLangString("ItemUpdLines.colSalesPrice");
            colSkip.HeaderText = db.GetLangString("ItemUpdLines.colSkip");
            colStatus.HeaderText = db.GetLangString("ItemUpdLines.colStatus");
            colSubCat.HeaderText = db.GetLangString("ItemUpdLines.colSubCat");
           // colFutureSalesPriceDate.HeaderText = db.GetLangString("ItemUpdLines.colFutureSalesPriceDate");
           // colPackType.HeaderText = db.GetLangString("ItemUpdLines.colPackType");
            colExecuteButton.HeaderText = db.GetLangString("ItemUpdLines.colExecuteButton");
            colInfoButton.HeaderText = db.GetLangString("ItemUpdLines.colInfoButton");
           // colKampagneID.HeaderText = db.GetLangString("ItemUpdLines.colKampagneID");
           // colAprovedBy.HeaderText = "Godkendt af";
            groupPerformAllButtons.Text = db.GetLangString("ItemUpdLines.groupPerformAllButtons");                           
                        
            if (!DOSite)
            {
                groupPerformAllButtons.Visible = false;
                string sql = string.Format(@"
                select count(*) from ItemUpdLines Where ID = {0} And AprovedBy is null", ID);

                object test = db.ExecuteScalar(sql);
                int Qty = tools.object2int(test);
                if (Qty > 0)
                    btnAccept.Visible = true;
                else
                    btnAccept.Visible = false;
            }
            else 
            {
                string sql = string.Format(@"
                select count(*) from ItemUpdLines Where ID = {0} And Status = 1", ID);
                object test = db.ExecuteScalar(sql);
                int Qty = tools.object2int(test);
                if (Qty > 0)
                    btnAccept.Visible = true;
                else
                    btnAccept.Visible = false;

                btnAccept.Visible = false;
                colSkip.Visible = true;
            }




        }
        #endregion

        #region ExecuteAllActionsForSelectedRow
        private void ExecuteAllActionsForSelectedRow()
        {
            // get selected record's LineNo
            if (bindingItemUpdLines.Current == null) return;
            DataRowView row = (DataRowView)bindingItemUpdLines.Current;
            int LineNo = tools.object2int(row["LineNo"]);

            // perform actions. newitem, newsupplieritemno and itemdiscarded are done seperately
            // while newcostprice, newsalesprice and newbarcode can be done together.
            if (tools.object2bool(row["ActionNewItem"]))
                ActionNewItem(LineNo, true);
            else if (tools.object2bool(row["ActionNewSupplierItemNo"]))
                ActionNewSupplierItemNo(LineNo);
            else if (tools.object2bool(row["ActionItemDiscarded"]))
                ActionItemDiscarded(LineNo);
            else
            {
                if (tools.object2bool(row["ActionNewCostPrice"]))
                    ActionNewCostPrice(LineNo);
                if (tools.object2bool(row["ActionNewBarcode"]))
                    ActionNewBarcode(LineNo);
                if (tools.object2bool(row["ActionNewSalesPrice"]))
                    ActionNewSalesPrice(LineNo);
            }

            dataGridView1.Refresh();
        }
#endregion

#region ExecuteAllCostPrices
        private void ExecuteAllCostPrices()
        {
            // select ActionNewCostPrice records
            DataRow[] rows = dsImport.ItemUpdLines.Select("ActionNewCostPrice = true");

            // setup progress form
            ProgressForm progress = new ProgressForm(db.GetLangString("ItemUpdLines.ProgressCostPrices"));
            progress.ProgressMax = rows.Length;
            progress.Show();

            // loop all ActionNewCostPrice records and perform action
            int count = 0;
            foreach (DataRow row in rows)
            {
                progress.StatusText = tools.object2string(row["Name"]);
                if (ActionNewCostPrice(tools.object2int(row["LineNo"])))
                    ++count;
            }
            
            progress.Close();
            dataGridView1.Refresh();

            string msg = string.Format(db.GetLangString("ItemUpdLines.msgNewCostPricesSet"), count);
            MessageBox.Show(msg);
        }
#endregion

#region ExecuteAllSalesPrices
        private void ExecuteAllSalesPrices()
        {
            // select ActionNewSalesPrice records
            DataRow[] rows = dsImport.ItemUpdLines.Select("ActionNewSalesPrice = true");

            // setup progress form
            ProgressForm progress = new ProgressForm(db.GetLangString("ItemUpdLines.ProgressSalesPrices"));
            progress.ProgressMax = rows.Length;
            progress.Show();

            // loop all ActionNewSalesPrice records and perform action
            int count = 0;
            foreach (DataRow row in rows)
            {
                progress.StatusText = tools.object2string(row["Name"]);
                if (ActionNewSalesPrice(tools.object2int(row["LineNo"])))
                    ++count;
            }

            progress.Close();
            dataGridView1.Refresh();

            string msg = string.Format(db.GetLangString("ItemUpdLines.msgNewSalesPricesSet"), count);
            MessageBox.Show(msg);
        }
#endregion

#region ExecuteAllSupplierItemNo
        private void ExecuteAllSupplierItemNo()
        {
            // select ActionNewSupplierItemNo records
            DataRow[] rows = dsImport.ItemUpdLines.Select("ActionNewSupplierItemNo = true");

            // setup progress form
            ProgressForm progress = new ProgressForm(db.GetLangString("ItemUpdLines.ProgressSupplierItems"));
            progress.ProgressMax = rows.Length;
            progress.Show();

            // loop all ActionNewSupplierItemNo records and perform action
            int count = 0;
            foreach (DataRow row in rows)
            {
                progress.StatusText = tools.object2string(row["Name"]);
                if (ActionNewSupplierItemNo(tools.object2int(row["LineNo"])))
                    ++count;
            }

            progress.Close();
            dataGridView1.Refresh();

            string msg = string.Format(db.GetLangString("ItemUpdLines.msgNewSupplierItemsCreated"), count);
            MessageBox.Show(msg);
        }
#endregion

#region ExecuteAllDiscarded
        private void ExecuteAllDiscarded()
        {
            // select ActionItemDiscarded records
            DataRow[] rows = dsImport.ItemUpdLines.Select("ActionItemDiscarded = true");

            // setup progress form
            ProgressForm progress = new ProgressForm(db.GetLangString("ItemUpdLines.ProgressItemsDiscarded"));
            progress.ProgressMax = rows.Length;
            progress.Show();

            // loop all ActionItemDiscarded records and perform action
            int count = 0;
            foreach (DataRow row in rows)
            {
                progress.StatusText = tools.object2string(row["Name"]);
                if (ActionItemDiscarded(tools.object2int(row["LineNo"])))
                    ++count;
            }

            progress.Close();
            dataGridView1.Refresh();

            string msg = string.Format(db.GetLangString("ItemUpdLines.msgItemsDiscarded"), count);
            MessageBox.Show(msg);
        }
#endregion

#region ExecuteAllNewItems
        private void ExecuteAllNewItems()
        {
            /// IMPORTANT: do NOT use same logic as in the
            /// other ExecuteAll methods, where we select out
            /// the action type, as the action type might change
            /// during the update.

            try
            {
                // setup depositmissing dialog if needed
                DepositMissing.ShowAlwaysAssumeYesCheckBox = true;
                DepositMissing.AlwaysAssumeYes = false;

                // loop all records and perform action newitem on
                // those records that have that action set to true
                int count = 0;
                foreach (DataRow row in dsImport.ItemUpdLines.Rows)
                {
                    int LineNo = tools.object2int(row["LineNo"]);
                    //if (tools.object2int(row["Status"]) == 1)//pn20210414
                    if ((tools.object2int(row["Status"]) == 1)& (tools.object2bool(row["ActionNewItem"]) == true))
                        {
                        DataRow r = PrepareAction(LineNo, ActionType.NewItem);
                        if (r != null)
                        {
                            if (ActionNewItem(tools.object2int(row["LineNo"]), false))
                            {
                                ++count;
                                this.Refresh();
                            }
                            else
                                return;
                        }
                    }
                }
                dataGridView1.Refresh();

                string msg = string.Format(db.GetLangString("ItemUpdLines.msgNewItemsCreated"), count);
                MessageBox.Show(msg);
            }
            finally
            {
                // setdown depotmissing dialog
                DepositMissing.ShowAlwaysAssumeYesCheckBox = false;
                DepositMissing.AlwaysAssumeYes = false;
            }
        }
#endregion

#region PrepareAction
        /// <summary>
        /// Saves any pending data in GUI and
        /// finds and returns the record with the given LineNo.
        /// Call this in the beginning of all Action methods.
        /// If the action is not enabled, null is returned.
        /// An action is enabled if it is set to true,
        /// and it is not done and the record is not closed
        /// and the record is not skipped.
        /// </summary>
        private DataRow PrepareAction(int LineNo, ActionType action)
        {
            DataRow row = null;

            // get the row to work with
            DataRow[] rows = dsImport.ItemUpdLines.Select("LineNo = " + LineNo);
            if (rows.Length > 0)
                row = rows[0];
            else
                return null;

            // build two string to use in
            // checking if the action is enabled
            string sAction = "";
            string sDoneAction = "";
            switch (action)
            {
                case ActionType.NewItem:
                    sAction = "ActionNewItem";
                    sDoneAction = "ActionDoneNewItem";
                    break;
                case ActionType.NewSupplierNo:
                    sAction = "ActionNewSupplierItemNo";
                    sDoneAction = "ActionDoneNewSupplierItemNo";
                    break;
                case ActionType.ItemDiscarded:
                    sAction = "ActionItemDiscarded";
                    sDoneAction = "ActionDoneItemDiscarded";
                    break;
                case ActionType.NewCostPrice:
                    sAction = "ActionNewCostPrice";
                    sDoneAction = "ActionDoneNewCostPrice";
                    break;
                case ActionType.NewSalesPrice:
                    sAction = "ActionNewSalesPrice";
                    sDoneAction = "ActionDoneNewSalesPrice";
                    break;
                case ActionType.NewBarcode:
                    sAction = "ActionNewBarcode";
                    sDoneAction = "ActionDoneNewBarcode";
                    break;
            }

            // check if action is enabled

            if (DOSite)
            {
                groupPerformAllButtons.Visible = true;
                                
                bool Enabled =
               ((tools.object2bool(row[sAction]) == true) &&                   // check that action is active
               (tools.object2bool(row[sDoneAction]) == false) &&               // check that action is not already done 
               (tools.object2int(row["Status"]) == (int)ImportDataSet.LookupLLStatusDataTable.LLStatus.Open) &&   // check that record is not closed 
               (tools.object2bool(row["Skip"]) == false));

                Enabled = Enabled;


            }
            else
            {
                btnAccept.Visible = true;

                bool Enabled =
                    ((tools.object2bool(row[sAction]) == true) &&                   // check that action is active              
                    (tools.object2bool(row["Skip"]) == false));                     // check that record is not skipped
            }






            // if action is not enabled, return null
            // indicating that the action is not to be performed
            // as no record to work with is returned
            if (!Enabled)
                return null;

            // record found and enabled
            return row;
        }
#endregion

#region FinishActionWhenDone
        private void FinishActionWhenDone(DataRow row, ActionType type)
        {
           
            // set status to closed on selected record
            if (type == ActionType.NewItem)
            {
                UpdateFSDStuffAsNeeded(row);
                row["ActionDoneNewItem"] = true;
                row["Status"] = (int)ImportDataSet.LookupLLStatusDataTable.LLStatus.Closed;
            }
            else if (type == ActionType.NewSupplierNo)
            {
                UpdateFSDStuffAsNeeded(row);
                row["ActionDoneNewSupplierItemNo"] = true;
                row["Status"] = (int)ImportDataSet.LookupLLStatusDataTable.LLStatus.Closed;
            }
            else if (type == ActionType.ItemDiscarded)
            {
                row["ActionDoneItemDiscarded"] = true;
                row["Status"] = (int)ImportDataSet.LookupLLStatusDataTable.LLStatus.Closed;
            }
            else if (type == ActionType.NewCostPrice)
            {
                UpdateFSDStuffAsNeeded(row);
                row["ActionDoneNewCostPrice"] = true;
                if ((!tools.object2bool(row["ActionNewSalesPrice"]) || tools.object2bool(row["ActionDoneNewSalesPrice"])) &&
                    (!tools.object2bool(row["ActionNewBarcode"]) || tools.object2bool(row["ActionDoneNewBarcode"])))
                    row["Status"] = (int)ImportDataSet.LookupLLStatusDataTable.LLStatus.Closed;
            }
            else if (type == ActionType.NewSalesPrice)
            {
                UpdateFSDStuffAsNeeded(row);  //20190912
                row["ActionDoneNewSalesPrice"] = true;
                if ((!tools.object2bool(row["ActionNewCostPrice"]) || tools.object2bool(row["ActionDoneNewCostPrice"])) &&
                    (! tools.object2bool(row["ActionNewBarcode"]) || tools.object2bool(row["ActionDoneNewBarcode"])))
                    row["Status"] = (int)ImportDataSet.LookupLLStatusDataTable.LLStatus.Closed;
            }
            else if (type == ActionType.NewBarcode)
            {
                UpdateFSDStuffAsNeeded(row);
                row["ActionDoneNewBarcode"] = true;
                if ((!tools.object2bool(row["ActionNewSalesPrice"]) || tools.object2bool(row["ActionDoneNewSalesPrice"])) &&
                    (!tools.object2bool(row["ActionNewCostPrice"]) || tools.object2bool(row["ActionDoneNewCostPrice"])))
                    row["Status"] = (int)ImportDataSet.LookupLLStatusDataTable.LLStatus.Closed;
            }

            SetActionDoneSummary(row);

            /// Save data. This is also done when
            /// calling this method while looping
            /// records. Experience has shown, that
            /// the framework takes a considerable amount
            /// of time to run through all changed records
            /// after the loop and saving changes to disk,
            /// so we want this call to be performed in each
            /// record processed, as it is done now. It will
            /// take slightly more time for each record in the
            /// loop, but we avoid a delay in the end. This is
            /// a better user experience.
            SaveData();
        }
#endregion

#region ActionNewItem + ItemForm closing event handler
        /// <summary>
        /// Returns true if item created, false if not.
        /// This is ONLY applicable if Single is true.
        /// </summary>
        private bool ActionNewItem(int LineNo, bool Single)
        {
            DataRow row = PrepareAction(LineNo, ActionType.NewItem);
            if (row != null)
            {
                // create the new item
                ItemForm item = new ItemForm();
                

                // keep the LineNo
                NewItemLineNo = LineNo;

                if (Single)
                {
                    // subscribe to itemform's closing event,
                    // as the form is show asynchronously below
                    // and we need to perform something when
                    // returning from the form.
                    item.FormClosing += new FormClosingEventHandler(ActionNewItem_ItemFormClosingEvent);
                   double test = tools.object2double(row["SalesPrice"]);
                    test = test;
                    // create new item and show form to user asynchronously
                    item.CreateNewItemAsync(
                        // tools.object2int(row["ItemID"]),//20190410
                        tools.object2string(row["Name"]),
                        tools.object2string(row["SubCat"]),
                        tools.object2byte(row["PackType"]),
                        tools.object2double(row["SalesPrice"]),
                        tools.object2double(row["Barcode"]),
                        tools.object2int(row["SupplierNo"]),
                        tools.object2double(row["OrderingNumber"]),
                        tools.object2int(row["Kolli"]),
                        tools.object2double(row["CostPrice"]),
                        tools.object2int(row["FSD_ID"]),
                        tools.object2int(row["KampagneID"]),
                        tools.object2datetime(row["DisktilbudFraDato"]),
                        tools.object2datetime(row["DisktilbudTilDato"]),
                        tools.object2int(row["DisktilbudThreshold"]),
                        tools.object2int(row["SubstNr"]))
                        ;
                        
                }
                else
                {
                    // create new item and only show form to user if error occurs
                    if (item.CreateNewItemSync(
                        // tools.object2int(row["ItemID"]), 20190410
                        tools.object2string(row["Name"]),
                        tools.object2string(row["SubCat"]),
                        tools.object2byte(row["PackType"]),
                        tools.object2double(row["SalesPrice"]),
                        tools.object2double(row["Barcode"]),
                        tools.object2int(row["SupplierNo"]),
                        tools.object2double(row["OrderingNumber"]),
                        tools.object2int(row["Kolli"]),
                        tools.object2double(row["CostPrice"]),
                        tools.object2int(row["FSD_ID"]),
                        tools.object2int(row["KampagneID"]),
                        tools.object2datetime(row["DisktilbudFraDato"]),
                        tools.object2datetime(row["DisktilbudTilDato"]),
                        tools.object2int(row["DisktilbudThreshold"]),
                        tools.object2int(row["SubstNr"])))
                        
                    {
                        // item created successfully, manually
                        // call do stuff when item has been created
                        DoStuffWhenNewItemHasBeenCreated(item);
                        return true;
                    }
                    else
                    {
                        // some error occured in ItemForm so user has
                        // to take action. we want to do stuff when item has been created,
                        // so subscribe to the itemform's formclosing event.
                        item.FormClosing += new FormClosingEventHandler(ActionNewItem_ItemFormClosingEvent);
                        int Position = bindingItemUpdLines.Find("LineNo", NewItemLineNo);
                        if ((Position >= 0) && (Position < bindingItemUpdLines.Count))
                            bindingItemUpdLines.Position = Position;
                        return false;
                    }
                }

                // dummy return value used when Single is true
                // and CreateNewItemAsync was called above
                return true;
            }

            // action not performed
            return false;
        }

        // event handler than "continues" method ActionNewItem as
        // it is invoked when user closes Item form which is opened
        // in method ActionNewItem.
        void ActionNewItem_ItemFormClosingEvent(object sender, FormClosingEventArgs e)
        {
            DoStuffWhenNewItemHasBeenCreated((ItemForm)sender);
        }

        // method that does stuff when new item has been created.
        // it is checked that the item form has dialogresult ok before doing anything.
        private void DoStuffWhenNewItemHasBeenCreated(ItemForm item)
        {
            // handle when itemform is closing, as user has then
            // either saved data or cancelled/closed.
            if (item.DialogResult == DialogResult.OK)
            {
                // get record that was selected when new item was selected to be created
                int Position = bindingItemUpdLines.Find("LineNo", NewItemLineNo);
                if ((Position >= 0) && (Position < bindingItemUpdLines.Count))
                {
                    bindingItemUpdLines.Position = Position;
                    if (bindingItemUpdLines.Current != null)
                    {
                        DataRowView row = (DataRowView)bindingItemUpdLines.Current;
                        double Barcode = tools.object2double(row["Barcode"]);

                        // also create a history record of this new item's disktilbud (if it has disktilbud)
                        DateTime DisktilbudFraDato = tools.object2datetime(row["DisktilbudFraDato"]);
                        DateTime DisktilbudTilDato = tools.object2datetime(row["DisktilbudTilDato"]);
                        if (DisktilbudFraDato != DateTime.MinValue && DisktilbudTilDato != DateTime.MinValue)
                        {
                            int DisktilbudThreshold = tools.object2int(row["DisktilbudThreshold"]);
                            int KampagneID = tools.object2int(row["KampagneID"]);
                            int ItemID = ItemDataSet.ItemDataTable.GetItemIDFromBarcode(Barcode);
                            int FSD_ID = ItemDataSet.ItemDataTable.GetFSD_ID(ItemID);
                            EODDataSet.DisktilbudHistorikDataTable.CreateRecord(ItemID, FSD_ID, DisktilbudFraDato, DisktilbudTilDato, DisktilbudThreshold, KampagneID, db.CurrentTransaction);
                        }

                        FinishActionWhenDone(row.Row, ActionType.NewItem);

                        // if lekkerland has sent us multiple records with
                        // same barcodes but different supplierinfo, these have
                        // all been marked as new items when they were imported,
                        // so now we need to change action from newitem to newsupplieritem
                        // on the remaining open records with the same barcode.
                        // note that we don't do it if the barcode is 0,
                        // as many wrong items might get set to newsupplieritem.
                        if (Barcode != 0)
                        {
                            foreach (DataRow tmprow in dsImport.ItemUpdLines.Rows)
                            {
                                if ((tools.object2double(tmprow["Barcode"]) == Barcode) &&
                                    (tools.object2int(tmprow["Status"]) == (int)ImportDataSet.LookupLLStatusDataTable.LLStatus.Open))
                                {
                                    tmprow["ActionNewItem"] = false;
                                    tmprow["ActionNewBarcode"] = false;
                                    tmprow["ActionNewSalesPrice"] = false;
                                    tmprow["ActionNewCostPrice"] = false;
                                    tmprow["ActionItemDiscarded"] = false;                                   
                                    tmprow["ActionNewSupplierItemNo"] = true;
                                    BuildActionSummary(tmprow);
                                }
                            }
                        }

                        SaveData();

                        // re-evaluering efter varen er blevet oprettet.
                        // gøres kun på records der hører til samme vare.
                        ReEvaluateActionsOnSameItemOtherRecords(row.Row, false);
                    }
                }
            }
        }

#endregion

#region ReEvaluateActionsOnSameItemOtherRecords
        /// <summary>
        /// Finds records in the grid that belongs to the same item
        /// and runs the re-evaluation on them. The records are found
        /// by checking for either:
        /// 1) Same FSD_ID
        /// 2) Same Barcode
        /// 3) Same Supplier info
        /// </summary>
        /// <param name="currRow">
        /// The row that has just been processed, most likely a row
        /// that contained a new item that now has been created.
        /// </param>
        /// <param name="SaveFirst">
        /// If set to true, saves data to dsImport.ItemUpdLines before starting.
        /// If setting this to false, make sure to save data to that table before running this method.
        /// </param>
        private void ReEvaluateActionsOnSameItemOtherRecords(DataRow currRow, bool SaveFirst)
        {
            if (SaveFirst)
                SaveData();

            foreach (DataRow row in dsImport.ItemUpdLines.Rows)
            {
                if (row != currRow &&
                    ((tools.object2int(row["FSD_ID"]) == tools.object2int(currRow["FSD_ID"])) ||
                     (tools.object2double(row["Barcode"]) == tools.object2double(currRow["Barcode"])) ||
                     (tools.object2int(row["SupplierNo"]) == tools.object2int(currRow["SupplierNo"]) && tools.object2double(row["OrderingNumber"]) == tools.object2double(currRow["OrderingNumber"]))))
                {
                    // dette er en anden record, der hører til samme vare som den record vi kom fra, så den skal re-evalueres
                    bool dummy1;
                    ImportDataSet.LookupLLStatusDataTable.LLStatus dummy2;
                    ReEvaluateActionsSingleRecord(row, out dummy1, out dummy2);
                }
            }
        }
#endregion

#region ActionNewSupplierItemNo
        private bool ActionNewSupplierItemNo(int LineNo)
        {
            DataRow row = PrepareAction(LineNo, ActionType.NewSupplierNo);
            if (row != null)
            {
                // as this is not a new item, the item has been found
                // via the barcode, so get the itemid via the barcode
                int ItemID = ItemDataSet.ItemDataTable.GetItemIDFromBarcode(tools.object2double(row["Barcode"]));

                // verify that item exists and is not semideleted
                if ((ItemID != 0) && (!ItemDataSet.ItemDataTable.IsSemiDeleted(ItemID)))
                {
                    // check that user has not created the same supplieritemno
                    // between the import and now
                    bool AlreadyExists = (tools.object2int(db.ExecuteScalar(string.Format(
                        " select count(*) from SupplierItem " +
                        " where (ItemID = {0}) " +
                        " and (SupplierNo = {1}) " +
                        " and (OrderingNumber = {2}) ",
                        ItemID, row["SupplierNo"], row["OrderingNumber"]))) > 0);
                    if (AlreadyExists)
                    {
                        // set status to closed on selected record
                        row["Status"] = (int)ImportDataSet.LookupLLStatusDataTable.LLStatus.Closed;
                        row["ActionDoneNewSupplierItemNo"] = true;
                        SetActionDoneSummary(row);

                        SaveData();

                        // action not performed
                        return false;
                    }

                    // this new supplieritem will be primary if no
                    // other supplieritems exists for this item
                    bool IsPrimary = (tools.object2int(db.ExecuteScalar(string.Format(
                        " select count(*) from SupplierItem " +
                        " where ItemID = {0} ", ItemID))) <= 0);

                    
                    // get CostPrice out of the row, as we will work with it several times
                    double CostPrice = tools.object2double(row["CostPrice"]);

                    // create the supplieritem record
                    db.ExecuteNonQuery(string.Format(
                        " insert into SupplierItem " +
                        " (ItemID,SupplierNo,OrderingNumber,KolliSize,PackageCost,PackageUnitCost," +
                        "  IsPrimary,SellingPackType,NoOfSellingUnits,SellingUnitCost) " +
                        " values ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9}) ",
                        ItemID,
                        row["SupplierNo"],
                        tools.decimalnumber4sql(row["OrderingNumber"]),
                        row["Kolli"], // KolliSize
                        tools.decimalnumber4sql(tools.object2int(row["Kolli"]) * tools.object2double(row["CostPrice"])), // PackageCost
                        tools.decimalnumber4sql(CostPrice), //PackageUnitCost
                        tools.bool4sql(IsPrimary),  //PN20191023
                        1, // SellingPackType
                        1, // NoOfSellingUnits
                        tools.decimalnumber4sql(row["CostPrice"]))); // SellingUnitCost

                    if (IsPrimary)
                    {
                        ItemDataSet.ItemDataTable.UpdateCostPriceLatest(ItemID, CostPrice);
                    }

                    // if missing kollisize in table LookupKolliSize, create it
                    int KolliSize = tools.object2int(row["Kolli"]);
                    ItemDataSet.LookupKolliSizeAdminDataTable.CreateUserDefinedKolliSizeIfNonExisting(KolliSize);

                    // null Item.UdmeldtPrDato to be sure that if LL has send
                    // us update data that first discards a supplieritem and then
                    // creates a new on the same item (found by barcode), then
                    // the item will not have the udmeldt flag on while still active.
                    if (ItemID != 0)
                        ItemDataSet.ItemDataTable.NullUdmeldtPrDatoToNow(ItemID);

                    // action performed
                    FinishActionWhenDone(row, ActionType.NewSupplierNo);
                    return true;
                }
                else
                {
                    // item not found, so update cannot be done. close record
                    row["Status"] = (int)ImportDataSet.LookupLLStatusDataTable.LLStatus.Closed;
                    row["ActionDoneNewSupplierItemNo"] = true;
                    SetActionDoneSummary(row);
                    SaveData();
                }
            }

            // action not performed
            return false;
        }

#endregion

#region ActionItemDiscarded
        private bool ActionItemDiscarded(int LineNo)
        {
            DataRow row = PrepareAction(LineNo, ActionType.ItemDiscarded);
            if (row != null)
            {
                // get supplieritem info
                int SupplierNo = tools.object2int(row["SupplierNo"]);
                double OrderingNumber = tools.object2double(row["OrderingNumber"]);

                // get the ItemID via either Barcode or SupplierItem info
                int ItemID = 0;
                double Barcode = tools.object2double(row["Barcode"]);
                if (Barcode != 0)
                    ItemID = ItemDataSet.ItemDataTable.GetItemIDFromBarcode(Barcode);
                if (Barcode == 0 || ItemID == 0)
                {
                    if ((SupplierNo != 0) && (OrderingNumber != 0))
                        ItemID = ItemDataSet.ItemDataTable.GetItemIDFromSupplierItem(SupplierNo, OrderingNumber);
                }

                // verify that item exists and is not semideleted
                if ((ItemID != 0) && (!ItemDataSet.ItemDataTable.IsSemiDeleted(ItemID)))
                {
                    // if FSD copy supplier item to fsd supplieritem deleted table
#if FSD
                    ItemDataSet.FSDDeletedSupplierItemDataTable.CopySupplierItem_To_FSDDeletedSupplierItem(
                        SupplierNo, OrderingNumber);
#endif

                    // delete supplieritem
                    ItemDataSet.SupplierItemDataTable.DeleteSupplierItem(SupplierNo, OrderingNumber);

                    // if other records in-memory and on-disk references
                    // the same item, do not semidelete or Udmeld item
                    if (!DoesOtherRecordsReferenceSameItem(row))
                    {
                        // check if the item has any more supplieritems
                        if (ItemDataSet.ItemDataTable.NumSupplierItemsOnItem(ItemID) <= 0)
                        {
                            // if InStock == 0 on Item, semidelete item,
                            // otherwise set UdmeldtPrDato to Now on Item
                            //if (ItemDataSet.ItemDataTable.GetInStock(ItemID) == 0)
                                //ItemDataSet.SemiDeleteItemAndChilds(ItemID);
                            //else
                                ItemDataSet.ItemDataTable.SetUdmeldtPrDatoToNow(ItemID);
                        }
                    }

                    // action performed
                    FinishActionWhenDone(row, ActionType.ItemDiscarded);
                    return true;
                }
                else
                {
                    // item not found, so update cannot be done. close record
                    row["Status"] = (int)ImportDataSet.LookupLLStatusDataTable.LLStatus.Closed;
                    row["ActionDoneItemDiscarded"] = true;
                    SetActionDoneSummary(row);
                    SaveData();
                }
            }

            // action not performed
            return false;
        }
#endregion

#region ActionNewCostPrice
        private bool ActionNewCostPrice(int LineNo)
        {
            DataRow row = PrepareAction(LineNo, ActionType.NewCostPrice);
            if (row != null)
            {
                // update cost price and additional related updates
                ItemDataSet.SupplierItemDataTable.UpdateCostPrice(
                    tools.object2double(row["CostPrice"]),
                    tools.object2int(row["SupplierNo"]),
                    tools.object2double(row["OrderingNumber"]));

                // action performed
                FinishActionWhenDone(row, ActionType.NewCostPrice);
                return true;
            }

            // action not performed
            return false;
        }
#endregion

#region ActionNewSalesPrice
        private bool ActionNewSalesPrice(int LineNo)
        {
            DataRow row = PrepareAction(LineNo, ActionType.NewSalesPrice);
            if (row != null)
            {
                // get the ItemID via either Barcode or SupplierItem info
                int ItemID = 0;
                double Barcode = tools.object2double(row["Barcode"]);
                int SupplierNo = tools.object2int(row["SupplierNo"]);
                double OrderingNumber = tools.object2double(row["OrderingNumber"]);
                if (Barcode != 0)
                    ItemID = ItemDataSet.ItemDataTable.GetItemIDFromBarcode(Barcode);
                if (Barcode == 0 || ItemID == 0)
                {
                    if ((SupplierNo != 0) && (OrderingNumber != 0))
                        ItemID = ItemDataSet.ItemDataTable.GetItemIDFromSupplierItem(SupplierNo, OrderingNumber);
                }

                // verify that item exists and is not semideleted
                if ((ItemID != 0) && (!ItemDataSet.ItemDataTable.IsSemiDeleted(ItemID)))
                {
                    // if this is an ordinary sales price update (not future)
                    if (tools.IsNullOrDBNull(row["FutureSalesPriceDate"])) 
                    {
                        int PackType = tools.object2int(row["PackType"]);
                        if (PackType == 0)
                        {
                            // this is the old file format without PackType in it,
                            // so get it from the only sales pack there is on the item

                            // check that user has not added a salespack extra since the import
                            int NumSalesPacks = ItemDataSet.ItemDataTable.NumSalesPacksOnItem(ItemID);
                            if (NumSalesPacks == 1)
                            {
                                PackType = tools.object2int(db.ExecuteScalar(string.Format(
                                    " select PackType from SalesPack " +
                                    " where ItemID = {0} ", ItemID)));
                                double SalesPrice = tools.object2double(row["SalesPrice"]);
                                ItemDataSet.SalesPackDataTable.UpdateSalesPrice(ItemID, (byte)PackType, SalesPrice);

                                // action performed
                                FinishActionWhenDone(row, ActionType.NewSalesPrice);
                                return true;
                            }
                        }
                        else // PackType != 0
                        {
                            // this is the new file format with PackType
                            double SalesPrice = tools.object2double(row["SalesPrice"]);
                            ItemDataSet.SalesPackDataTable.UpdateSalesPrice(ItemID, (byte)PackType, SalesPrice);

                            // action performed
                            FinishActionWhenDone(row, ActionType.NewSalesPrice);
                            return true;
                        }
                    }
                    else // it's a future salespack                    
                    {
                        // create future sales price record
                        ItemDataSet.SalesPackFuturePricesDataTable.CreateRecord(
                            ItemID,
                            tools.object2byte(row["PackType"]),
                            tools.object2datetime(row["FutureSalesPriceDate"]),
                            ItemDataSet.SalesPackFuturePriceOrigin.BFI,
                            tools.object2double(row["SalesPrice"]));

                        // action performed
                        FinishActionWhenDone(row, ActionType.NewSalesPrice);
                        return true;
                    }
                }
                else
                {
                    // item not found, so update cannot be done. close record
                    row["Status"] = (int)ImportDataSet.LookupLLStatusDataTable.LLStatus.Closed;
                    row["ActionDoneNewSalesPrice"] = true;
                    SetActionDoneSummary(row);
                    SaveData();
                }
            }

            // action not performed
            return false;
        }
#endregion

#region ActionNewBarcode
        private bool ActionNewBarcode(int LineNo)
        {
            DataRow row = PrepareAction(LineNo, ActionType.NewBarcode);
            if (row != null)
            {
                // get the ItemID via SupplierItem info
                int SupplierNo = tools.object2int(row["SupplierNo"]);
                double OrderingNumber = tools.object2double(row["OrderingNumber"]);
                int ItemID = ItemDataSet.ItemDataTable.GetItemIDFromSupplierItem(SupplierNo, OrderingNumber);

                // attach the barcode to the primary salespack
                short PackType = ItemDataSet.SalesPackDataTable.GetPrimaryPackType(ItemID);

                // check that packtype exists and that item is not semideleted
                if ((PackType != 0) && (!ItemDataSet.ItemDataTable.IsSemiDeleted(ItemID)))
                {
                    // create the barcode record
                    double Barcode = tools.object2double(row["Barcode"]);
                    ItemDataSet.BarcodeDataTable.AddBarcode(ItemID, PackType, Barcode);

                    // action performed
                    FinishActionWhenDone(row, ActionType.NewBarcode);
                    return true;
                }
                else
                {
                    // item not found, so update cannot be done. close record
                    row["Status"] = (int)ImportDataSet.LookupLLStatusDataTable.LLStatus.Closed;
                    row["ActionDoneNewBarcode"] = true;
                    SetActionDoneSummary(row);
                    SaveData();
                }
            }

            // action not performed
            return false;
        }
#endregion

#region BuildActionSummary (2 overloads)

        private static void BuildActionSummary(DataRow row)
        {
            bool ActionNoChange = false; // ignored
            row["ActionSummary"] = BuildActionSummary(
                tools.object2bool(row["ActionNewItem"]),
                tools.object2bool(row["ActionNewCostPrice"]),
                tools.object2bool(row["ActionNewSalesPrice"]),
                tools.object2bool(row["ActionNewBarcode"]),
                tools.object2bool(row["ActionNewSupplierItemNo"]),
                tools.object2bool(row["ActionItemDiscarded"]),
                ref ActionNoChange);
        }

        /// <summary>
        /// Builds the action summary string.
        /// Static so it can be called from ManualUpdatesForm too.
        /// </summary>
        public static string BuildActionSummary(
            bool ActionNewItem,
            bool ActionNewCostPrice,
            bool ActionNewSalesPrice,
            bool ActionNewBarcode,
            bool ActionNewSupplierItemNo,
            bool ActionItemDiscarded,
            ref bool ActionNoChange)
        {
            // detect action No Change
            ActionNoChange =
                (!ActionNewItem &&
                !ActionNewCostPrice &&
                !ActionNewSalesPrice &&
                !ActionNewBarcode &&
                !ActionNewSupplierItemNo &&
                !ActionItemDiscarded);

            // build ActionSummary
            string ActionSummary = "";
            if (ActionNoChange)
                ActionSummary = db.GetLangString("ManualUpdatesForm.UpdateLL.NoChange");
            else if (ActionNewItem)
                ActionSummary = db.GetLangString("ManualUpdatesForm.UpdateLL.NewItem");
            else if (ActionNewSupplierItemNo)
                ActionSummary = db.GetLangString("ManualUpdatesForm.UpdateLL.NewSupplierNo");
            else if (ActionItemDiscarded)
                ActionSummary = db.GetLangString("ManualUpdatesForm.UpdateLL.ItemDiscarded");
            else
            {
                if (ActionNewCostPrice)
                    ActionSummary = db.GetLangString("ManualUpdatesForm.UpdateLL.NewCostPrice");
                if (ActionNewSalesPrice)
                {
                    if (ActionSummary != "") ActionSummary += " + ";
                    ActionSummary += db.GetLangString("ManualUpdatesForm.UpdateLL.NewSalesPrice");
                }
                if (ActionNewBarcode)
                {
                    if (ActionSummary != "") ActionSummary += " + ";
                    ActionSummary += db.GetLangString("ManualUpdatesForm.UpdateLL.NewBarcode");
                }
            }
            return ActionSummary;
        }
#endregion

#region SetActionDoneSummary
        private void SetActionDoneSummary(DataRow row)
        {
            bool ActionDoneNewItem = tools.object2bool(row["ActionDoneNewItem"]);
            bool ActionDoneNewCostPrice = tools.object2bool(row["ActionDoneNewCostPrice"]);
            bool ActionDoneNewSalesPrice = tools.object2bool(row["ActionDoneNewSalesPrice"]);
            bool ActionDoneNewBarcode = tools.object2bool(row["ActionDoneNewBarcode"]);
            bool ActionDoneNewSupplierItemNo = tools.object2bool(row["ActionDoneNewSupplierItemNo"]);
            bool ActionDoneItemDiscarded = tools.object2bool(row["ActionDoneItemDiscarded"]);

            // build DoneActionSummary
            string ActionDoneSummary = "";
            if (ActionDoneNewItem)
                ActionDoneSummary = "N";
            else if (ActionDoneNewSupplierItemNo)
                ActionDoneSummary = "Be";
            else if (ActionDoneItemDiscarded)
                ActionDoneSummary = "U";
            else
            {
                if (ActionDoneNewCostPrice)
                    ActionDoneSummary = "K";
                if (ActionDoneNewSalesPrice)
                {
                    if (ActionDoneSummary != "") ActionDoneSummary += " + ";
                    ActionDoneSummary += "S";
                }
                if (ActionDoneNewBarcode)
                {
                    if (ActionDoneSummary != "") ActionDoneSummary += " + ";
                    ActionDoneSummary += "Ba";
                }
            }

            row["ActionDoneSummary"] = ActionDoneSummary;
        }
#endregion

#region ReEvaluateActionsSingleRecord
        /// <summary>
        /// Remember to clear ItemsWithFSD_IDsAlreadyOnAnotherItem
        /// before running this method in a loop and then show a message
        /// to user and log after.
        /// </summary>
        private void ReEvaluateActionsSingleRecord(DataRow row, out bool FoundInInactiveItems, out ImportDataSet.LookupLLStatusDataTable.LLStatus StatusAfterEvaluation)
        {
#region get data from the row and other initial stuff

            double rowBarcode = tools.object2double(row["Barcode"]);
            double rowCostPrice = tools.object2double(row["CostPrice"]);
            double rowSalesPrice = tools.object2double(row["SalesPrice"]);
            int rowSupplierNo = tools.object2int(row["SupplierNo"]);
            double rowOrderingNumber = tools.object2double(row["OrderingNumber"]);
            int rowKolli = tools.object2int(row["Kolli"]);
            int rowKampagneID = tools.object2int(row["KampagneID"]);
            int rowFSD_ID = tools.object2int(row["FSD_ID"]);
           
            int rowPackType = 1;
            
            StatusAfterEvaluation = ImportDataSet.LookupLLStatusDataTable.LLStatus.Open;

            #endregion

            #region Check if item has been inactivated

            // check to see if item has been inactivated
            FoundInInactiveItems = ItemDataSet.XVDDataFoundInInactiveItems(rowBarcode, rowOrderingNumber, rowSupplierNo);
            if (FoundInInactiveItems)
            {
                if (rowKampagneID > 0)
                {
                    /// item is in kampagne and found in inactive items. we cannot just
                    /// update it in inactive items and remove it from the grid as this
                    /// item must appear in the campaign. so we delete it from inactive items
                    /// and mark it as not found in there as it then will be considered a new item
                    ItemDataSet.DeleteXVDDataInInactiveItemsCompletely(rowBarcode, rowOrderingNumber, rowSupplierNo);
                    FoundInInactiveItems = false;
                }
                else
                {
                    // item is not in kampagne so we can update it in inactive items
                    // and it will be removed from the grid
                    ItemDataSet.UpdateXVDDataInInactiveItems(
                        rowBarcode,
                        rowOrderingNumber,
                        rowSupplierNo,
                        rowCostPrice,
                        rowSalesPrice,
                        rowKolli,
                        rowKampagneID,
                        rowFSD_ID,
                        rowPackType);
                }
            }
            
            // item found in inactive items
            // so it will be deleted from this grid
            if (FoundInInactiveItems)
                return;

#endregion

#region Continue with the re-evaluation

            bool ActionNewItem = false;
            bool ActionNewCostPrice = false;
       
            bool ActionNewSalesPrice = false;
            bool ActionNewBarcode = false;
            bool ActionNewSupplierItemNo = false;
            bool ActionNoChange = false;//pn20200128

            bool FoundBarcode = ItemDataSet.BarcodeDataTable.GetBarcodeRecord(rowBarcode) != null;
            DataRow FoundSupplierItemRow = ItemDataSet.SupplierItemDataTable.GetSupplierItem(rowSupplierNo, rowOrderingNumber);

            // we need the item id, so get it from either barcode or supplieritem
            int ItemID = 0;
            if (FoundBarcode)
                ItemID = ItemDataSet.ItemDataTable.GetItemIDFromBarcode(rowBarcode);
            if (!FoundBarcode || ItemID == 0)
            {
                if (FoundSupplierItemRow != null)
                    ItemID = ItemDataSet.ItemDataTable.GetItemIDFromSupplierItem(
                        tools.object2int(FoundSupplierItemRow["SupplierNo"]),
                        tools.object2double(FoundSupplierItemRow["OrderingNumber"]));
            }

#endregion

#region Handle updating KampagneID directly if needed
            // If FSD_ID is not already in use on another item, perform some updates
            if ((rowFSD_ID == 0) || (ItemDataSet.ItemDataTable.FSD_ID_AlreadyInUseOnOtherItem(ItemID, rowFSD_ID) == ""))
            {
                // directly update item with KampagneID, if needed
                if (ItemID > 0)
                {
                    if (ItemDataSet.ItemDataTable.UpdateKampagneIDIfChanged(ItemID, rowKampagneID))
                    {
                        if (ItemDataSet.ItemDataTable.GetFSD_ID(ItemID) != rowFSD_ID)
                            ItemDataSet.ItemDataTable.UpdateFSD_ID(ItemID, rowFSD_ID, rowKampagneID);
                    }
                }
            }
            else
            {
                /// FSD_ID is in use on another item, so we write in the item log
                /// and send it to DRS. We also notify the user about this, after all items
                /// have been imported.                
                if (!ItemsWithFSD_IDsAlreadyOnAnotherItem.ContainsKey(ItemID))
                    ItemsWithFSD_IDsAlreadyOnAnotherItem.Add(ItemID, rowFSD_ID);
            }
#endregion

#region detect action new item

            // criteria: neither barcode nor supplieritem can be found in db

            if (!FoundBarcode && (FoundSupplierItemRow == null))
                ActionNewItem = true;

#endregion

#region detect action cost price

            // criteria: supplieritem can be found in db.
            // criteria: cost price must be different
            //pn20200217
            //if (FoundSupplierItemRow != null)
            //{
            //    double dbCostPrice = tools.object2double(FoundSupplierItemRow["PackageUnitCost"]);
            //    row["LogCost"] = dbCostPrice; // update LogCost to reflect any updates in db
            //    if (Math.Round(dbCostPrice, 3) != Math.Round(rowCostPrice, 3))
            //        ActionNewCostPrice = true;
            //}

#endregion

#region detect action new sales price

            // criteria: either barcode or supplier info must be found in db.
            // criteria: only 1 supplieritem and 1 salespack must exist.
            // criteria: salesprice must be different than on disk.
            // criteria: salesprice must be different that 0

            if ((rowSalesPrice != 0) &&
                (FoundBarcode || (FoundSupplierItemRow != null)))
            {
                // only set ActionNewSalesPrice if
                // only one salespack exists on the item
                if (ItemDataSet.ItemDataTable.NumSalesPacksOnItem(ItemID) == 1)
                {
                    // check that salesprice is different
                    double dbSalesPrice = tools.object2double(db.ExecuteScalar(string.Format(
                        " select SalesPrice " +
                        " from SalesPack " +
                        " where ItemID = {0} ",
                        ItemID)));
                    row["LogSales"] = dbSalesPrice; // update LogSales to reflect any changes in db
                    if (Math.Round(dbSalesPrice, 2) != Math.Round(rowSalesPrice, 2))
                    {
                        ActionNewSalesPrice = true;
                    }
                }
            }

#endregion

#region detect action new barcode

            // criteria: barcode not 0
            // criteria: barcode not found but supplier info found
            // criteria: barcode is different

            if ((rowBarcode != 0) &&
                (!FoundBarcode && (FoundSupplierItemRow != null)))
            {
                // check that barcode is different
                // (assumes that a barcode can only exists once in the Barcode table)
                int tmpNumBarcodes = tools.object2int(db.ExecuteScalar(string.Format(
                    " select count(*) " +
                    " from Barcode " +
                    " where Barcode = {0} ",
                    rowBarcode)));
                if (tmpNumBarcodes < 1)
                    ActionNewBarcode = true;
            }

#endregion

#region detect action new supplier item number

            // criteria: barcode found
            // criteria: supplier info not found in db
            // criteria: supplier info exists in row

            if (FoundBarcode &&
                (FoundSupplierItemRow == null) &&
                (rowOrderingNumber > 0) &&
                (rowSupplierNo > 0))
            {
                ActionNewSupplierItemNo = true;
            }

#endregion

#region ensure actions does not conflict

            // if ActionNewItem or ActionNewSupplierItemNo,
            // disable any possible actions on
            // NewBarcode, NewCostPrice and NewSalesPrice
            if (ActionNewItem || ActionNewSupplierItemNo)
            {
                ActionNewBarcode = false;
                ActionNewCostPrice = false;
                ActionNewSalesPrice = false;
            }

#endregion

#region detect action no change and build action summary

            string ActionSummary = BuildActionSummary(
                ActionNewItem,
                ActionNewCostPrice,
                ActionNewSalesPrice,
                ActionNewBarcode,
                ActionNewSupplierItemNo,
                false, // ActionItemDiscarded
                ref ActionNoChange);

#endregion

#region set the actions, action summary and status

            row["ActionNewItem"] = ActionNewItem;
            row["ActionNewCostPrice"] = ActionNewCostPrice;
            row["ActionNewSalesPrice"] = ActionNewSalesPrice;
            row["ActionNewBarcode"] = ActionNewBarcode;
            row["ActionNewSupplierItemNo"] = ActionNewSupplierItemNo;
            row["ActionSummary"] = ActionSummary;

            StatusAfterEvaluation = ActionNoChange ? ImportDataSet.LookupLLStatusDataTable.LLStatus.Closed : ImportDataSet.LookupLLStatusDataTable.LLStatus.Open;
            row["Status"] = (int)StatusAfterEvaluation;

#endregion
        }
#endregion

#region ReEvaluateActionsAllRecords
        private void ReEvaluateActionsAllRecords()
        {
            SaveData();
            List<DataRow> InactivatedItems = new List<DataRow>();
            int NoOfOpen = 0;

            // iterate through each item
            ItemsWithFSD_IDsAlreadyOnAnotherItem.Clear();
            ImportDataSet ds = bindingItemUpdLines.DataSource as ImportDataSet;
            foreach (DataRow row in ds.ItemUpdLines.Rows)
            {
                if ((tools.object2string(row["LLAction"]) != "20") && // 20 is udmeldt vare
                    (tools.object2string(row["LLAction"]) != "UV") && // LV is udmeldt vare
                    (tools.object2int(row["Status"]) != (int)ImportDataSet.LookupLLStatusDataTable.LLStatus.Closed) &&
                    (!tools.object2bool(row["Skip"])))
                {
                    bool FoundInInactiveItems;
                    ImportDataSet.LookupLLStatusDataTable.LLStatus StatusAfterEvaluation;

                    ReEvaluateActionsSingleRecord(row, out FoundInInactiveItems, out StatusAfterEvaluation);

                    // handle the returned states
                    if (FoundInInactiveItems)
                        InactivatedItems.Add(row);
                    else if (StatusAfterEvaluation == ImportDataSet.LookupLLStatusDataTable.LLStatus.Open)
                        ++NoOfOpen;
                }
            }

            //Pn20200225
            adapterItemUpdLines.Update(dsImport.ItemUpdLines);
            // if FSD_IDs were prevented in any of the imported files, notify user
            if (ItemsWithFSD_IDsAlreadyOnAnotherItem.Count > 0)
            {
                MessageBox.Show(db.GetLangString("ImportFVD.ErrorFSD_IDAlreadyOnAnotherItem"));
                ItemDataSet.ItemDataTable.UpdateFVD_WriteDRSItemLog_PreventedDuplicateFSD_ID(ItemsWithFSD_IDsAlreadyOnAnotherItem, "@@@TODO");
            }

            // if any items were inactivated, remove them from the grid
            if (InactivatedItems.Count > 0)
            {
                // delete the items from ItemUpdLines
                foreach (DataRow row in InactivatedItems)
                {
                    db.ExecuteNonQuery(string.Format(@"
                        delete from ItemUpdLines
                        where (ID = {0})
                        and ([LineNo] = {1})
                        ",
                         tools.object2int(row["ID"]),
                         tools.object2int(row["LineNo"])));
                }

                // re-load ItemUpdLines data so inactivated items does not appear
            //pn20200225   
             adapterItemUpdLines.Connection = db.Connection;
             adapterItemUpdLines.Fill(dsImport.ItemUpdLines, ID);
            }

            // update header records with counters
            db.ExecuteNonQuery(string.Format(
                " update ItemUpdates set " +
                " NoOfLines = {0}, " +
                " NoOfOpen = {1} " +
                " where ID = {2} ",
                ds.ItemUpdLines.Rows.Count, NoOfOpen, ID));

            // make the grid reload its data
            bindingItemUpdLines.ResetBindings(false);
        }

        #endregion

#region ReEvaluateActionsAllRecordsRBANEW
private void ReEvaluateActionsAllRecordsRBANEW()
{
    SaveData();
   // List<DataRow> InactivatedItems = new List<DataRow>();
   // int NoOfOpen = 0;

    // iterate through each item
    ItemsWithFSD_IDsAlreadyOnAnotherItem.Clear();
    ImportDataSet ds = bindingItemUpdLines.DataSource as ImportDataSet;
    foreach (DataRow row in ds.ItemUpdLines.Rows)
    {
        if ((tools.object2bool (row["ActionNewSalesPrice"]) == true))
            row["ActionSummary"] = "Ny salgspris";
        if ((tools.object2bool(row["ActionNewItem"]) == true))
            row["ActionSummary"] = "Ny vare";
            
        if ((tools.object2bool(row["ActionNewSupplierItemNo"]) == true))
            row["ActionSummary"] = "Nyt bestillings nummer";
        }

        // make the grid reload its data
        bindingItemUpdLines.ResetBindings(false);
}

#endregion

        #region OpenInfoForm
        private void OpenInfoForm(DataRowView row)
        {
            // when info button is clicked in the grid,
            // open the info form for the selected record
            int LineNo = tools.object2int(row["LineNo"]);
            ItemUpdInfo info = new ItemUpdInfo(bindingItemUpdLines, ID, LineNo);
            info.ShowDialog(this);

            // rebuild action summary and reflect changes in grid
            BuildActionSummary(row.Row);
            dataGridView1.Refresh();
        }
#endregion

#region SkipAllSalesPrices
        /// <summary>
        /// Runs through all records and skips sales prices,
        /// if the record has a salesprice change enabled.
        /// </summary>
        private void SkipAllSalesPrices()
        {
            // save any pending changes in controls to underlying dataset
            bindingItemUpdLines.EndEdit();

            // select ActionNewSalesPrice records
            DataRow[] rows = dsImport.ItemUpdLines.Select("ActionNewSalesPrice = true");

            // setup progress form
            ProgressForm progress = new ProgressForm(db.GetLangString("ItemUpdLines.ProgressSkipAllSalesPrices"));
            progress.ProgressMax = rows.Length;
            progress.Show();

            // skip all enabled sales prices
            foreach (DataRow row in rows)
            {
                progress.StatusText = tools.object2string(row["Name"]);
                ImportDataSet.ItemUpdLinesDataTable.ToggleSalesPriceChange(row, true);
                BuildActionSummary(row);

                /// Saving data to disk. Yes, it does seem a bit strange that
                /// we don't wait with this until the loop is over, but it seems
                /// that it takes a considerable amount of time (more than 10 seconds)
                /// for the framework to run through large amounts of changed records
                /// and saving the changes to disk, so we decided to save for each
                /// record processed, which will take slighty more time when looping,
                /// but we then don't have the 10 seconds delay at the end.
                /// This gives a much better user experience.
                SaveData();
            }

            // reflect changed in grid
            progress.Close();
            dataGridView1.Refresh();

            MessageBox.Show(db.GetLangString("ItemUpdLines.msgAllSalesPriceChangesSkipped"));
        }
#endregion

#region DoesOtherRecordsReferenceSameItem
        /// <summary>
        /// Checks if other records references the same item.
        /// The item is determined from either barcode or supplierno+orderingnumber.
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private bool DoesOtherRecordsReferenceSameItem(DataRow row)
        {
            /// Note: Previously we checked for the item both
            /// on-disk and in-memory, but this leads to the situation
            /// where an item will be found twice, even if it only exists once.
            /// So we only check on-disk.

            // save data to disk
            dataGridView1.EndEdit();
            bindingItemUpdLines.EndEdit();
            SaveData();

            double Barcode = tools.object2double(row["Barcode"]);
            int SupplierNo = tools.object2int(row["SupplierNo"]);
            double OrderingNumber = tools.object2double(row["OrderingNumber"]);
            int LineNo = tools.object2int(row["LineNo"]);
            DateTime UpdDate = ImportDataSet.ItemUpdatesDataTable.GetUpdDate(ID);

            // check for same reference on-disk
            return (tools.object2int(db.ExecuteScalar(string.Format(
                " SELECT COUNT(*) FROM ItemUpdLines " +
                " INNER JOIN ItemUpdates " +
                " ON ItemUpdLines.ID = ItemUpdates.ID " +
                " WHERE (LineNo <> {0}) " +
                " AND ((Barcode = {1}) OR ((SupplierNo = {2}) AND (OrderingNumber = {3}))) " +
                " AND (ItemUpdates.UpdDate >= cdate('{4}')) ",
                LineNo, Barcode, SupplierNo, OrderingNumber, UpdDate))) > 0);
        }
#endregion

#region UpdateFSDStuffAsNeeded
        private void UpdateFSDStuffAsNeeded(DataRow row)
        {
            // at this point, for any action (including new item)
            // there will be an item related to the information in
            // the given record.
            int ItemID = ItemDataSet.ItemDataTable.GetItemIDFromBarcodeOrSupplierItem(
                tools.object2double(row["Barcode"]),
                tools.object2int(row["SupplierNo"]),
                tools.object2double(row["OrderingNumber"]));
            if (ItemID > 0)
            {
                int FSD_ID = tools.object2int(row["FSD_ID"]);
                int KampagneID = tools.object2int(row["KampagneID"]);
                ItemDataSet.ItemDataTable.UpdateFSD_ID(ItemID, FSD_ID, KampagneID);
            }
        }
#endregion

#region LoadData
        private void LoadData()
        {
            // load LookupSubCategory data
            adapterLookupSubCategory.Connection = db.Connection;
            adapterLookupSubCategory.Fill(dsItem.LookupSubCategory);

            // load LookupLLStatus data
            adapterLookupLLStatus.Connection = db.Connection;
            adapterLookupLLStatus.Fill(dsImport.LookupLLStatus);

            // load ItemUpdLines data
            adapterItemUpdLines.Connection = db.Connection;
            adapterItemUpdLines.Fill(dsImport.ItemUpdLines, ID);
            if (!DOSite)
                ReEvaluateActionsAllRecordsRBANEW();
            else
                ReEvaluateActionsAllRecords();

            //pn20200224
            //dataGridView1.Update();
        }
#endregion

#region SaveData
        private void SaveData()
        {
            // save ItemUpdLines to disk
            dataGridView1.EndEdit();
            bindingItemUpdLines.EndEdit();
            adapterItemUpdLines.Update(dsImport.ItemUpdLines);

            // update ItemUpdates header
            ImportDataSet.ItemUpdLinesDataTable.UpdateHeaderAfterSaveToDisk(ID,DOSite);
        }
#endregion

        private void ItemUpdLines_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // don't take action if clicking the column header :)
            if (e.RowIndex < 0)
                return;

            if (bindingItemUpdLines.Current == null) return;
            DataRowView row = (DataRowView)bindingItemUpdLines.Current;

            if (e.ColumnIndex == colInfoButton.Index)
            {
                OpenInfoForm(row);
            }
            else if (e.ColumnIndex == colExecuteButton.Index)
            {
                if (DOSite)
                {
                    ExecuteAllActionsForSelectedRow();
                }
                else
                {
                    if (tools.IsNullOrDBNull(row["AprovedBy"]) && ((tools.object2bool(row["ActionNewSupplierItemNo"]) == false)))
                    {
                        ItemForm itemform = new ItemForm();
                        int ItemID = ItemDataSet.ItemDataTable.GetItemIDFromImportID(tools.object2int(row["FSD_ID"]));
                        if (itemform.EditSingleItem(ItemID) == DialogResult.OK)
                        {

                            row["SalesPrice"] = ItemDataSet.ItemDataTable.GetSalesPackSalesPrice(ItemID);  //20190913
                            dataGridView1.Refresh();
                        }
                    }

                }
                




            }
            else if (e.ColumnIndex == colSkip.Index)
            {
                // user cannot touch the skip flag if 
                // the subcategory is missing
                // (the record is forced to be skipped)
                // NOTE: CANNOT BE IMPLEMENTED IN CellBeginEdit DUE TO SPACE KEY
                if (tools.object2string(row["SubCat"]) == "")
                {
                    MessageBox.Show(db.GetLangString("ItemUpdLines.RecordMissingSubCat"));
                    SendKeys.Send("{ESC}");
                    return;
                }

                // when user tries to skip a record,
                // we must validate that the record
                // has not been closed by the program,
                // that is, is the record closed and not skipped.
                // NOTE: CANNOT BE IMPLEMENTED IN CellBeginEdit DUE TO SPACE KEY
                if ((tools.object2bool(row["Skip"]) == false) &&
                    (tools.object2int(row["Status"]) == (int)ImportDataSet.LookupLLStatusDataTable.LLStatus.Closed))
                {
                    MessageBox.Show(db.GetLangString("ItemUpdLines.msgCannotSkipRecord"));
                    SendKeys.Send("{ESC}");
                    return;
                }

                /// user cannot skip a new item if that item is part of a campaign
                /// (this is a bug in radiant that remedy here)
                if (tools.object2bool(row["ActionNewItem"]) && (tools.object2int(row["KampagneID"]) != 0))
                {
                    MessageBox.Show(db.GetLangString("ItemUpdLines.CannotSkipCampaignItem"));
                    SendKeys.Send("{ESC}");
                    return;
                }

                // when user skips a record, set status to closed.
                // when user unskips a record, set status to open.

                // remember that at this point,
                // the Skip field has not yet reflected
                // the user's input, so assume that it
                // is the old value, that is, assume it is reversed
                if (tools.object2bool(row["Skip"]) == true)
                {
                    row["Skip"] = false; // reflect the current input
                    row["Status"] = (int)ImportDataSet.LookupLLStatusDataTable.LLStatus.Open;
                }
                else
                {
                    row["Skip"] = true; // reflect the current input
                    row["Status"] = (int)ImportDataSet.LookupLLStatusDataTable.LLStatus.Closed;
                }

                if (!tools.object2bool(row["Skip"]))
                {
                    bool dummy1;
                    ImportDataSet.LookupLLStatusDataTable.LLStatus dummy2;
                    ReEvaluateActionsSingleRecord(row.Row, out dummy1, out dummy2);
                }

                dataGridView1.Refresh();
                SaveData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == colStatusColor.Index)
            {
                // color status cell
                tools.PaintStatusCell(dataGridView1, e.ColumnIndex, e.RowIndex, colStatus.Index, colStatusColor.Index);
            }
            else if (e.ColumnIndex == colInfoButton.Index)
            {
                // render details image on grid info button
                ImageButtonRender.OnCellPainting(e, colInfoButton.Index, ImageButtonRender.Images.Details);
            }
            else if (e.ColumnIndex == colExecuteButton.Index)
            {
                // render details image on grid execute button
                ImageButtonRender.OnCellPainting(e, colExecuteButton.Index, ImageButtonRender.Images.Execute);
            }
        }

        private void btnAllCost_Click(object sender, EventArgs e)
        {
            ExecuteAllCostPrices();
        }

        private void btnAllSales_Click(object sender, EventArgs e)
        {
            ExecuteAllSalesPrices();
        }

        private void btnAllSupplierItemNo_Click(object sender, EventArgs e)
        {
            ExecuteAllSupplierItemNo();
        }

        private void btnAllDiscarded_Click(object sender, EventArgs e)
        {
            ExecuteAllDiscarded();
        }

        private void btnSkipAllSalesPrices_Click(object sender, EventArgs e)
        {
            SkipAllSalesPrices();
        }

        private void ItemUpdLines_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
        }

        private void btnAllNewItems_Click(object sender, EventArgs e)
        {
            ExecuteAllNewItems();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            //  bool test = UserLogon.EditSalesPrice();
            //ExecuteAllSalesPrices();
            DataRow[] rows = dsImport.ItemUpdLines.Select("AprovedBy Is NULL ");
            int test = dsImport.ItemUpdLines.Count;


            foreach (DataRow row in rows)
            {
                             
                row["AprovedBy"] = Environment.UserName.ToString();
                row["Status"] = (int)ImportDataSet.LookupLLStatusDataTable.LLStatus.Closed;

            }
            dataGridView1.Refresh();
            SaveData();
          
        }
    }
}