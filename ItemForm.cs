using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace RBOS
{
    public partial class ItemForm : Form
    {

        bool DOSite = (db.GetConfigStringAsBool("DOVersion"));
        #region Private variables

        // flag telling whether we are currently creating a new item
        private bool newItemMode = false;

        // flag telling whether this form was opened via the
        // CreateNewItem method. if this is the case, then when
        // user saves data, the form should close with a dialogresult ok.
        // if the user cancels or closes the form on the red cross, the
        // form is closed with dialogresult cancel.
        private bool WasOpenedWithCreateNewItemMethod = false;

        // internal kept flag that tells if list of items is filtered,
        // as this is needed to know when toggling edit mode and setting
        // btnRemoveFilter.Enabled
        private bool itemDataFiltered = false;

        // semideleted row font color
        private Color SemiDeletedColor = Color.Red;

        // variables used when editing a single item
        private bool _EditSingleMode = false;
        private int _EditSingleMode_ItemID = 0;

        //tab index
        private int TabIndex = 0;

        #endregion

        #region Constructor
        /// <summary>
        /// ItemForm constructor
        /// </summary>
        public ItemForm()
        {
            InitializeComponent();

            // use our global database object
            adapterItem.Connection = db.Connection;
            adapterSalesPack.Connection = db.Connection;
            adapterBarcode.Connection = db.Connection;
            adapterRelSalesPackFuturePrices.Connection = db.Connection;
            adapterRelTransac.Connection = db.Connection;
            adapterRelSupplierItem.Connection = db.Connection;
            adapterLookupBarcodeType.Connection = db.Connection;
            adapterLookupPackType.Connection = db.Connection;
            adapterLookupSubCategory.Connection = db.Connection;
            adapterLookupVatRate.Connection = db.Connection;
            adapterLookupSupplier.Connection = db.Connection;
            adapterLookupKolliSize.Connection = db.Connection;

            // subscribe to item column changed event,
            // as we want to set UpdateRSM = true in salespack whenever
            // item values changes (salespack has this code in
            // it's own ColumnChanged/NewRow event subscription, and
            // barcode has equivalent code in this file when closing barcode)
            dsItem.Item.ColumnChanged += new DataColumnChangeEventHandler(Item_ColumnChanged);

            // subscribe to salespack column changed event to update
            // GUI controls UpdateRSM or UpdateShelfLabel whenever
            // they change in database. The change is merely in item GUI, not in db.
            // If any UpdateRSM is set on salespack, it is set in item GUI.
            // If any UpdateShelfLabel is set on salespack, it is set in item GUI.
            dsItem.SalesPack.ColumnChanged += new DataColumnChangeEventHandler(SalesPack_ColumnChanged);

            // see documentation above for variable
            // WasOpenedWithCreateNewItemMethod which
            // explains why this is set default cancel
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion

        #region DELEGATE: Item_ColumnChanged
        // item column changed event subscription
        private void Item_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            // item has changed, set all salespack's UpdateRSM = true
            if ((e.Column.ColumnName != dsItem.Item.MarginColumn.ColumnName) &&         // skip calculated column
                (e.Column.ColumnName != dsItem.Item.POSSalesPriceColumn.ColumnName) &&  // skip calculated column
                (e.Column.ColumnName != dsItem.Item.SemiDeletedColumn.ColumnName) &&    // skip SemiDeleted column
                (e.Column.ColumnName != dsItem.Item.LastChangeDateTimeColumn.ColumnName) && // skip LastChanged column
                (e.Column.ColumnName != dsItem.Item.CostPriceLatestColumn.ColumnName)) // skip CostPriceLatest column
            {
                dsItem.SalesPack.SetUpdateRSM();
            }
        }
        #endregion

        #region DELEGATE: SalesPack_ColumnChanged
        // salespack column changed event subscription
        void SalesPack_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (bindingRelItemSalesPack.Current != null)
            {
                DataRowView row = (DataRowView)bindingRelItemSalesPack.Current;

                // If any UpdateRSM is set on salespack, it is set in item GUI.
                if (e.Column.ColumnName == dsItem.SalesPack.UpdateRSMColumn.ColumnName)
                {
                    // both check db and binding
                    bool currentUpdateRSM = false;
                    if ((row["UpdateRSM"] != DBNull.Value) && bool.Parse(row["UpdateRSM"].ToString()))
                        currentUpdateRSM = true;
                    chkUpdateRSM.Checked = (dsItem.SalesPack.HasAnyUpdateRSM() || currentUpdateRSM);
                }

                // if any UpdateStations is set on SalesPack, it is set in item GUI.
                if (e.Column.ColumnName == dsItem.SalesPack.UpdateStationsColumn.ColumnName)
                {
                    // both check db and binding
                    bool currentUpdateStations = tools.object2bool(row["UpdateStations"]);
                    chkUpdateStations.Checked = (dsItem.SalesPack.HasAnyUpdateStations() || currentUpdateStations);
                }

                // If any UpdateShelfLabel is set on salespack, it is set in item GUI.
                if (e.Column.ColumnName == dsItem.SalesPack.UpdateShelfLabelColumn.ColumnName)
                {
                    // both check db and binding
                    bool currentUpdateShelfLabel = false;
                    if ((row["UpdateShelfLabel"] != DBNull.Value) && bool.Parse(row["UpdateShelfLabel"].ToString()))
                        currentUpdateShelfLabel = true;
                    chkNewShelfMarker.Checked = (dsItem.SalesPack.HasAnyUpdateShelfLabel() || currentUpdateShelfLabel);
                }

            }
        }
        #endregion

        #region DELEGATE: SalesPack_RowAdded
        // salespack column changed event subscription
        //void SalesPack_RowAdded(object sender, DataRowChangeEventArgs e)
        //{



        //}
        #endregion

        #region METHOD: LoadSubCategoryData
        /// <summary>
        /// Loads data into SubCategory dsItem.SubCategory table
        /// for the subcategory corresponding to the subcategory
        /// selected for the current item. So the subcategory must
        /// have been set in the curent item before calling this method.
        /// </summary>
        private void LoadSubCategoryData()
        {
            if (bindingItem.Current != null)
            {
                // clear subcategory table
                dsItem.SubCategory.Clear();

                // get current item row
                ItemDataSet.ItemRow itemRow =
                    (ItemDataSet.ItemRow)((DataRowView)bindingItem.Current).Row;

                // if current Item's SubCategory is valid,
                // use it to load the corresponding subcategory row
                if (itemRow["SubCategory"] is string)
                {
                    // load subcategory row
                    ItemDataSetTableAdapters.SubCategoryTableAdapter adapter =
                        new RBOS.ItemDataSetTableAdapters.SubCategoryTableAdapter();
                    adapter.Connection = db.Connection;
                    adapter.Fill(dsItem.SubCategory, itemRow.SubCategory);
                }
            }
        }
        #endregion

        #region METHOD: InheritCreditCategory
        /// <summary>
        /// Copies CreditCategory from subcategory to item.
        /// LoadSubCategoryData() must have been called first.
        /// Call binding.ResetCurrentItem afterwards to reflect changes in GUI.
        /// </summary>
        private void InheritCreditCategory()
        {
            if ((bindingItem.Current != null) &&
                (dsItem.SubCategory.Rows.Count > 0))
            {
                DataRowView row = (DataRowView)bindingItem.Current;
                object newVal = dsItem.SubCategory.Rows[0]["CreditCategory"];
                row["CreditCategory"] = newVal;
                row["InheritCreditCat"] = true;
            }
        }
        #endregion

        #region METHOD: InheritAgeRestriction
        /// <summary>
        /// Copies AgeRestriction from subcategory to item.
        /// LoadSubCategoryData() must have been called first.
        /// Call binding.ResetCurrentItem afterwards to reflect changes in GUI.
        /// </summary>
        private void InheritAgeRestriction()
        {
            if ((bindingItem.Current != null) &&
                (dsItem.SubCategory.Rows.Count > 0))
            {
                DataRowView row = (DataRowView)bindingItem.Current;
                object newVal = dsItem.SubCategory.Rows[0]["AgeRestriction"];
                if (newVal == DBNull.Value) newVal = 0; // convert db null to 0
                row["AgeRestriction"] = newVal;
                row["InheritAgeRestric"] = true;
            }
        }
        #endregion

        #region METHOD: InheritMOPRestriction
        /// <summary>
        /// Copies MOPRestriction from subcategory to item.
        /// LoadSubCategoryData() must have been called first.
        /// Call binding.ResetCurrentItem afterwards to reflect changes in GUI.
        /// </summary>
        private void InheritMOPRestriction()
        {
            if ((bindingItem.Current != null) &&
                (dsItem.SubCategory.Rows.Count > 0))
            {
                DataRowView row = (DataRowView)bindingItem.Current;
                object newVal = dsItem.SubCategory.Rows[0]["MOPRestriction"];
                if (newVal != DBNull.Value)
                {
                    row["MOPRestriction"] = newVal;
                    row["InheritMOPRestr"] = true;
                }
            }
        }
        #endregion

        #region METHOD: InheritItemTypeCode
        /// <summary>
        /// Copies ItemTypeCode from subcategory to item.
        /// LoadSubCategoryData() must have been called first.
        /// Call binding.ResetCurrentItem afterwards to reflect changes in GUI.
        /// </summary>
        private void InheritItemTypeCode()
        {
            if ((bindingItem.Current != null) &&
                (dsItem.SubCategory.Rows.Count > 0))
            {
                DataRowView row = (DataRowView)bindingItem.Current;
                object newVal = dsItem.SubCategory.Rows[0]["ItemTypeCode"];
                row["ItemTypeCode"] = newVal;
                row["InheritItemTypeCode"] = true;
            }
        }
        #endregion

        #region METHOD: InheritOtherSubCategoyValues
        /// <summary>
        /// Copies VatRate, VatOwner and BudgetDG from subcategory to item.
        /// LoadSubCategoryData() must have been called first.
        /// Call binding.ResetCurrentItem afterwards to reflect changes in GUI.
        /// </summary>
        private void InheritOtherSubCategoyValues()
        {
            if ((bindingItem.Current != null) &&
               (dsItem.SubCategory.Rows.Count > 0))
            {
                DataRowView row = (DataRowView)bindingItem.Current;
                row["VatRate"] = dsItem.SubCategory.Rows[0]["VatRate"];     // VatRate
                row["VatOwner"] = dsItem.SubCategory.Rows[0]["VatOwner"];   // VatOwner
                row["BudgetMargin"] = dsItem.SubCategory.Rows[0]["BudgetMargin"];   // BudgetMargin
            }
        }
        #endregion

        #region METHOD: PositionSaveAndCancelButtons
        // position save and cancel buttons
        private void PositionSaveAndCancelButtons()
        {
            btnSave.Left = btnEdit.Left;
            btnSave.Top = btnEdit.Top;
            btnCancel.Left = btnClose.Left;
            btnCancel.Top = btnClose.Top;
        }
        #endregion

        #region METHOD: ToggleEdit
        /// <summary>
        /// Toggles edit mode of controls
        /// </summary>
        private void ToggleEdit(bool editMode)
        {
            if (!DOSite)
            {
                bool editMode1 = false;

                // general controls
                gridPackSize.ReadOnly = !editMode;
                btnSearch.Enabled = !editMode1;
                btnSave.Visible = editMode;
                btnCancel.Visible = editMode1;
                btnEdit.Visible = !editMode;

                btnClose.Visible = !editMode1;
                btnNew.Enabled = !editMode1;
                btnDelete.Enabled = !editMode1;
                txtItemName.ReadOnly = !editMode1;

                // controls on "General" tabsheet
                txtMinStock.ReadOnly = !editMode1;
                navFilterList.Enabled = !editMode1;
                btnLookupSubCategory.Enabled = editMode1;
                txtLastCostPrice.ReadOnly = !editMode1;
                chkNewShelfMarker.Enabled = editMode;

                // controls on "Order" tabsheet (supplier items)
                gridSupplierItem.ReadOnly = !editMode1;
                // some columns are always readonly

                ColInActiveDate.ReadOnly = true;
                // controls on "Other" tabsheet
                chkCreditCategory.Enabled = editMode1;
                chkAgeRestriction.Enabled = editMode1;
                chkMOPRestriction.Enabled = editMode1;
                txtItemTypeCode.Enabled = editMode1;
                chkItemTypeCode.Enabled = editMode;
                txtItemTypeSubCode.Enabled = editMode;
                //chkFocusItem.Enabled = editMode;            
                btnCreditCategory.Enabled = (!chkCreditCategory.Checked && editMode1);
                txtAgeRestriction.ReadOnly = !(!chkAgeRestriction.Checked && editMode1);
                txtMOPRestriction.ReadOnly = !(!chkMOPRestriction.Checked && editMode1);
                btnItemTypeCode.Enabled = (!chkItemTypeCode.Checked && editMode1);
                txtFSD_ID.ReadOnly = !(editMode && (UserLogon.ProfileID == AdminDataSet.UserProfilesDataTable.ProfileID.drs));
                txtKampagneID.ReadOnly = !(editMode && (UserLogon.ProfileID == AdminDataSet.UserProfilesDataTable.ProfileID.drs));







                if (!txtMOPRestriction.ReadOnly)
                    txtMOPRestriction.Increment = 1;
                else
                    txtMOPRestriction.Increment = 0;

                // when entering edit mode, btnRemoveFilter is disabled,
                // but when entering view mode, btnRemoveFiler is enabled
                // if the list of items is currently filtered
                if (editMode)
                    btnRemoveFilter.Enabled = false;
                else
                    btnRemoveFilter.Enabled = itemDataFiltered;

                // position save and cancel buttons
                // to make sure they are correctly positioned
                PositionSaveAndCancelButtons();
            }
            if (DOSite)
            {


                // general controls
                gridPackSize.ReadOnly = !editMode;
                //>>PN20210422
                colPackType.ReadOnly = true;
                colIsPrimary.ReadOnly = true;
                colBarcodeButton.ReadOnly = !editMode; 
                colBtnSalesPackDetailsForm.ReadOnly = !editMode;
                //<<PN20210422
                btnSearch.Enabled = !editMode;
                btnSave.Visible = editMode;
                btnCancel.Visible = editMode;
                btnEdit.Visible = !editMode;

                btnClose.Visible = !editMode;
                btnNew.Enabled = !editMode;
                btnDelete.Enabled = !editMode;
                txtItemName.ReadOnly = !editMode;

                // controls on "General" tabsheet
                txtMinStock.ReadOnly = !editMode;
                navFilterList.Enabled = !editMode;
                btnLookupSubCategory.Enabled = editMode;
                txtLastCostPrice.ReadOnly = !editMode;
                chkNewShelfMarker.Enabled = editMode;

                // controls on "Order" tabsheet (supplier items)
                gridSupplierItem.ReadOnly = !editMode;
                // some columns are always readonly
                //colNoOfSellingUnits.ReadOnly = true; //pn20190819
                // colSellingUnitCost.ReadOnly = true; //pn20190819
                ColInActiveDate.ReadOnly = true;
                // controls on "Other" tabsheet
                chkCreditCategory.Enabled = editMode;
                chkAgeRestriction.Enabled = editMode;
                chkMOPRestriction.Enabled = editMode;
                chkItemTypeCode.Enabled = editMode;
                txtItemTypeSubCode.Enabled = editMode;
                //chkFocusItem.Enabled = editMode;            
                btnCreditCategory.Enabled = (!chkCreditCategory.Checked && editMode);
                txtAgeRestriction.ReadOnly = !(!chkAgeRestriction.Checked && editMode);
                txtMOPRestriction.ReadOnly = !(!chkMOPRestriction.Checked && editMode);
                btnItemTypeCode.Enabled = (!chkItemTypeCode.Checked && editMode);
                // txtFSD_ID.ReadOnly = !(editMode && (UserLogon.ProfileID == AdminDataSet.UserProfilesDataTable.ProfileID.drs));
                //txtKampagneID.ReadOnly = !(editMode && (UserLogon.ProfileID == AdminDataSet.UserProfilesDataTable.ProfileID.drs));
                txtKampagneID.ReadOnly = !(editMode && UserLogon.EditItem() && txtKampagneID.Text != "" );  //PN20220705
                txtFSD_ID.ReadOnly = !(editMode && UserLogon.EditItem());
                chkRSMNeedsNewID.Visible = (editMode && UserLogon.EditItem());






                if (!txtMOPRestriction.ReadOnly)
                    txtMOPRestriction.Increment = 1;
                else
                    txtMOPRestriction.Increment = 0;

                // when entering edit mode, btnRemoveFilter is disabled,
                // but when entering view mode, btnRemoveFiler is enabled
                // if the list of items is currently filtered
                if (editMode)
                    btnRemoveFilter.Enabled = false;
                else
                    btnRemoveFilter.Enabled = itemDataFiltered;

                // position save and cancel buttons
                // to make sure they are correctly positioned
                PositionSaveAndCancelButtons();
            }


        }
        #endregion

        #region METHOD: NewPendingItemStart
        /// <summary>
        /// Start new pending item creation
        /// </summary>
        private void NewPendingItemStart()
        {
            // enter new mode
            NewPendingItemToggleControls(true);
            newItemMode = true;

            // add a new dummy item to the item list,
            // as this will blank all fields in gui and we
            // have an item in the binder to work with.
            // it's ItemID will be overwritten when ItemID is generated.
            bindingFilterList.Position = bindingFilterList.Add(0);

            // focus itemname control
            if (txtItemName.CanFocus)
                txtItemName.Focus();
        }
        #endregion

        #region METHOD: NewPendingItemCancel
        /// <summary>
        /// Cancel new pending item creation.
        /// </summary>
        private void NewPendingItemCancel()
        {
            // check that we are in new item mode
            if (!newItemMode) return;

            if (bindingFilterList.Current != null)
            {
                // get the new ItemID (might be a dummy if nothing saved to database yet)
                int newItemID = int.Parse(bindingFilterList.Current.ToString());

                // delete new item from item list
                bindingFilterList.RemoveCurrent();

                // if item was saved to database, delete it
                if (newItemID > 0)
                    ItemDataSet.DeleteNewPendingItemAndChilds(newItemID);
            }

            // leave new/edit mode
            NewPendingItemToggleControls(false);
            ToggleEdit(false);
            newItemMode = false;

            // cancelling new pending item
            // so ItemName field must be enabled
            // again, as it was disabled when saving
            // new pending item. field is still readonly
            txtItemName.Enabled = true;
        }
        #endregion

        #region METHOD: NewPendingItemSave
        /// <summary>
        /// Save new pending item.
        /// </summary>
        private void NewPendingItemSave()
        {
            if (!newItemMode) return;

            if (txtItemName.Text == "")
            {
                // entered item name cannot be empty
                MessageBox.Show(db.GetLangString("ItemForm.NewItemNameCannotBeEmptyMess"), "", MessageBoxButtons.OK);
                if (txtItemName.CanFocus)
                    txtItemName.Focus();
            }
            else if (ItemDataSet.IsUniqueItemName(txtItemName.Text, 0))
            {
                // entered item name is unique, save it and
                // assign the autogenerated ItemID to the item
                // at the current position in the item list
                int ItemID = ItemDataSet.SaveNewItem(txtItemName.Text);
                bindingFilterList[bindingFilterList.Position] = ItemID;

                // get any generated database data out to the gui
                // by reloading the created item
                adapterItem.Fill(dsItem.Item, ItemID); //Peter20190410

                // clear the default selected SubCategory in the GUI
                // so the user is forced to select one
                ((DataRowView)bindingItem.Current).Row["SubCategory"] = DBNull.Value;

                // edit the item and focus subcategory lookup button
                NewPendingItemToggleControls(false);
                ToggleEdit(true);
                if (btnLookupSubCategory.CanFocus)
                    btnLookupSubCategory.Focus();

                // disable ItemName field so
                // user cannot place cursor in the
                // field because this would cause the validation
                // to invoke on the field when trying to leave
                // it again while in new pending mode.
                txtItemName.Enabled = false;

            }
            else
            {
                // entered item name is not unique
                MessageBox.Show(db.GetLangString("ItemForm.NewItemNameMustBeUniqueMess"), "", MessageBoxButtons.OK);
                if (txtItemName.CanFocus)
                    txtItemName.Focus();
            }
        }
        #endregion

        #region METHOD: NewPendingItemToggleControls
        /// <summary>
        /// Helper method for the NewPendingItem methods.
        /// </summary>
        private void NewPendingItemToggleControls(bool newMode)
        {
            // toggle controls
            txtItemName.ReadOnly = !newMode;
            tabControl1.Enabled = !newMode;
            gridPackSize.Enabled = !newMode;
            btnSearch.Enabled = !newMode;
            navFilterList.Enabled = !newMode;
            btnNew.Visible = !newMode;
            btnDelete.Visible = !newMode;
            btnEdit.Visible = !newMode;
            btnClose.Visible = !newMode;
            btnCancel.Visible = newMode;
            //>>PN2210422
            gridPackSize.AllowUserToAddRows = !newMode;
            //<<PN20210422
        }
        #endregion

        #region METHOD: DeleteCurrentItem
        /// <summary>
        /// Delete current item.
        /// </summary>
        private void DeleteCurrentItem()
        {
            if ((bindingItem.Current != null) && (bindingFilterList.Current != null))
            {
                string itemName = ((DataRowView)bindingItem.Current)["ItemName"].ToString();
                int itemID = int.Parse(bindingFilterList.Current.ToString());
                if (dsItem.Item.IsChainItem())
                {
                    // if this is a chain item, do not allow delete
                    MessageBox.Show(db.GetLangString("ItemForm.YouCannotDeleteThisChainItem"));
                    return;
                }
                else if (dsItem.Item.IsInCampaign())
                {
                    MessageBox.Show(db.GetLangString("ItemForm.CannotDeleteItemInCampaign"));
                    return;
                }
                else
                {
                    // build message to user. ask if delete is ok. if stock is diff. from 0, ask about that.
                    string msg;
                    if (ItemDataSet.ItemDataTable.GetInStock(itemID) == 0)
                        msg = string.Format(db.GetLangString("ItemForm.DeleteItem"), itemName);
                    else
                        msg = string.Format(db.GetLangString("ItemForm.DeleteItemWithStock").Replace("\\n", "\n"), itemName);

                    if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        // semi delete from database and delete from item list
                        msg = ItemDataSet.SemiDeleteItemAndChilds(itemID);
                        if (msg == "")
                        {
                            // semi-delete successful
                            bindingFilterList.RemoveCurrent();
                        }
                        else
                        {
                            // semi-delete failed, display error
                            MessageBox.Show(msg);
                        }
                        return;
                    }
                }
            }
        }
        #endregion

        #region METHOD: DeleteSalesPackAndBarcodes
        /// <summary>
        /// Confirms delete with user and sets the salespack rows's SemiDeleted = true,
        /// and also sets related barcode row's SemiDeleted = true
        /// </summary>
        /// <returns></returns>
        private void DeleteSalesPackAndBarcodes()
        {
            // only allow deleting sales pack rows when in edit-mode
            if (gridPackSize.ReadOnly)
            {
                MessageBox.Show(db.GetLangString("ItemForm.SwitchToEditModeFirstMsg"));
                return;
            }

            if (bindingRelItemSalesPack.Current != null)
            {
                ItemDataSet.SalesPackRow row =
                    (ItemDataSet.SalesPackRow)((DataRowView)bindingRelItemSalesPack.Current).Row;

                // check that user didn't click on a non-existing row
                if (row["PackType"] != DBNull.Value)
                {
                    string msg = string.Format(
                        db.GetLangString("ItemForm.delete packsize {0}?Mess"),
                        dsItem.LookupPackSize.GetPackTypeName(row.PackType));
                    if (MessageBox.Show(this, msg, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        /// @@@ This is where the salespack is deleted,
                        /// @@@ so check that it also deletes barcodes
                        /// @@@ OBS: dette kan ikke testes før vi kan oprette barcoder igen

                        // set SemiDeleted = true on salespack row
                        row.SemiDeleted = true;

                        // remove IsPrimary flag to false if it is set to true
                        if ((row["IsPrimary"] != DBNull.Value) && row.IsPrimary)
                        {
                            row.IsPrimary = false;
                            // also set in gui and avoid calling binder.ResetCurrentItem
                            gridPackSize.CurrentRow.Cells["colIsPrimary"].Value = false;
                        }

                        // set SemiDeleted = true on related barcodes
                        bindingRelItemsSalesPackBarcode.MoveFirst();
                        foreach (DataRowView barcodeRow in bindingRelItemsSalesPackBarcode)
                            barcodeRow["SemiDeleted"] = true;

                        // paint SemiDeleted salespack row red
                        gridPackSize.CurrentRow.DefaultCellStyle.ForeColor = SemiDeletedColor;
                        gridPackSize.CurrentRow.DefaultCellStyle.SelectionForeColor = SemiDeletedColor;
                    }
                }
            }
        }
        #endregion

        #region METHOD: CalculateNumBarcodesOnGrid
        /// <summary>
        /// Calculates and writes the number of barcodes for all rows in the grid.
        /// </summary>
        private void CalculateNumBarcodesOnGrid()
        {
            dsItem.SalesPack.SetNumBarcodesCalcAllRows(dsItem.Barcode);
        }
        #endregion

        #region METHOD: ValidateBeforeSave
        /// <summary>
        /// Perform validation before attempting to save.
        /// </summary>
        private bool ValidateBeforeSave()
        {
            if (bindingItem.Current != null)
            {
                if (bindingItem.Current == null) return false;
                DataRowView row = (DataRowView)bindingItem.Current;


                // check that itemname is not empty
                if (tools.object2string(row["ItemName"]) == "")
                {
                    MessageBox.Show(db.GetLangString("ItemForm.ItemNameCannotBeEmpty"));
                    return false;
                }

                // check that itemname is unique
                if (!ItemDataSet.IsUniqueItemName(
                    tools.object2string(row["ItemName"]),
                    tools.object2int(row["ItemID"])))
                {
                    MessageBox.Show(db.GetLangString("ItemForm.ItemNameAlreadyExists"));
                    return false;
                }

                // check that subcategory has been filled in
                if (row["SubCategory"] == DBNull.Value)
                {
                    MessageBox.Show(db.GetLangString("ItemForm.subcategory cannot be emptyMess"));
                    return false;
                }

                // check that cost price is not 0
                if ((row["CostPriceLatest"] == DBNull.Value) || (float.Parse(row["CostPriceLatest"].ToString()) == 0))
                {
                    MessageBox.Show(db.GetLangString("ItemForm.CostPriceCannotBeZero"));
                    if (txtLastCostPrice.CanFocus)
                        txtLastCostPrice.Focus();
                    return false;
                }


            }

            // check that we have at least one SalesPack row
            if (bindingRelItemSalesPack.Count <= 0)
            {
                MessageBox.Show(db.GetLangString("ItemForm.at least one sales pack for itemMess"));
                return false;
            }

            // check that we have at least one barcode row
            if (bindingRelItemsSalesPackBarcode.Count <= 0)
            {
                MessageBox.Show(db.GetLangString("ItemForm.at least one barcode for this itemMess"));
                return false;
            }

            // check that we have at least one primary sales pack
            if (!dsItem.SalesPack.HasPrimaryBarcode())
            {
                MessageBox.Show(db.GetLangString("ItemForm.YouMustSpecifyPrimarySPMsg"));
                return false;
            }

            // count how many valid supplier item records that exist
            int numValidSupplRows = 0;
            foreach (DataRow row in dsItem.SupplierItem.Rows)
            {
                if ((row.RowState != DataRowState.Deleted) &&
                    (row.RowState != DataRowState.Detached))
                    ++numValidSupplRows;
            }
            // check that we have a least one primary supplier item,
            // but only do the check if any supplier records exists
            if ((numValidSupplRows > 0) && !dsItem.SupplierItem.HasAPrimaryRecord())
            {
                MessageBox.Show(db.GetLangString("ItemForm.PleaseSelectAPrimarySupplierItem"));
                return false;
            }


            //pn20200604
            DataRowView packtypeRow = (DataRowView)bindingRelItemSalesPack.Current;

            Boolean ManualPriceTest = bool.Parse(packtypeRow["ManualPrice"].ToString());


            if (ManualPriceTest == true)
            {
                DataRowView itemRow = (DataRowView)bindingItem.Current;
                float SalesPriceTest = float.Parse(packtypeRow["SalesPrice"].ToString());
                int c = int.Parse(packtypeRow["ItemID"].ToString());
                int ItemAgeRestriction;
                ItemAgeRestriction = int.Parse(itemRow["AgeRestriction"].ToString());
                if (ItemAgeRestriction != 0)
                {
                    MessageBox.Show("Manual pris ikke tilladt når der er Alders restriction på varen");
                    return false;
                }
                if (SalesPriceTest != 0)
                {
                    MessageBox.Show("ved Manual pris skal salgspris være 0");
                    return false;
                }

            }



            // check if the item's subcategory needs deposit,
            // and if so, check if the item has a chain item
            if ((bindingItem.Current != null) && (bindingRelItemSalesPack.Current != null))
            {
                DataRowView itemRow = (DataRowView)bindingItem.Current;
                string SubCategory = tools.object2string(itemRow["SubCategory"]);
                if (ItemDataSet.SubCategoryDataTable.NeedsDeposit(SubCategory))
                {
                    if (ItemDataSet.SalesPackDataTable.DoesARowNotHaveChainItem(dsItem.SalesPack))
                    {
                        // ask user if it is ok to save even though this item needs deposit
                        // while one or more salespacks are missing deposit
                        DepositMissing dm = new DepositMissing();
                        if ((!DepositMissing.AlwaysAssumeYes) && (dm.ShowDialog() != DialogResult.Yes))
                            return false;
                    }
                }
            }

            return true;
        }
        #endregion

        #region METHOD: CopyPrimarySalesPrice
        /// <summary>
        /// Internal helper method to copy sales 
        /// price from primary sales pack to item.
        /// </summary>
        private void CopyPrimarySalesPrice(object SalesPrice)
        {
            if (bindingItem.Current != null)
            {
                // save to copy even if same value, as SalesPrice is a calculated
                // column and will not trigger UpdateRSM.
                DataRowView itemRow = (DataRowView)bindingItem.Current;
                if ((SalesPrice != null) && (SalesPrice != DBNull.Value))
                    itemRow["POSSalesPrice"] = SalesPrice;
                else if (dsItem.SalesPack.Rows.Count > 0)
                    itemRow["POSSalesPrice"] = dsItem.SalesPack.GetPrimarySalesPackSalesPrice().ToString();

                /// save to gui control too to avoid reflect change in gui with
                /// a call to bindingItem.ResetCurrentItem(), as that will mess
                /// up with detail salespack rows, especially when creating a
                /// brand new item, salespack and barcode.
                txtSalesPrice.Text = tools.object2double(itemRow["POSSalesPrice"]).ToString("n2");

                txtMargin.Text = tools.object2double(itemRow["Margin"]).ToString("n2");
                txtLastCostPrice.Text = tools.object2double(itemRow["CostPriceLatest"]).ToString("n3");
            }
        }
        #endregion

        #region METHOD: GetSupplierName
        /// <summary>
        /// Gets the suppliername from the supplier table.
        /// </summary>
        private string GetSupplierName(object val)
        {
            if ((val != null) && (val != DBNull.Value))
            {
                DataRow supplierRow = dbSupplier.GetSupplier(tools.object2int(val));
                if (supplierRow != null)
                    return supplierRow["Description"].ToString();
            }
            return "";
        }
        #endregion

        #region METHOD: SearchSupplier
        /// <summary>
        /// Opens the supplier popup and writes selected value to the current record.
        /// </summary>
        /// <param name="promptUserToOverwrite">
        /// If parameter is set to true and a value already exists in the cell,
        /// prompt user to overwrite the value. If parameter is false and there
        /// already is a value, the value is overwritten without prompting user.
        /// </param>
        private void SearchSupplier()
        {
            if (bindingRelSupplierItem.Current == null) return;
            if (gridSupplierItem.ReadOnly) return;
            if (gridSupplierItem.CurrentCell == null) return;

            DataRowView row = (DataRowView)bindingRelSupplierItem.Current;
            SupplierPopup popup = new SupplierPopup();
            popup.SelectedSupplierID = tools.object2int(row["SupplierNo"]);
            if (popup.ShowDialog(this) == DialogResult.OK)
            {
                row["SupplierNo"] = popup.SelectedSupplierID;
                txtSupplierName.Text = popup.SelectedSupplierDescription;
                gridSupplierItem.Refresh(); // refresh grid if in view-mode
            }
        }
        #endregion

        #region CreateNewItemSync
        /// <summary>
        /// Creates a new item and returns true if successfully saved and false if not.
        /// If false is returned, the ItemForm remains open for user to complete input.
        /// If true is returned, DialogResult is Ok. If false is returned, DialogResult is Cancel.
        /// </summary>
        public bool CreateNewItemSync(
            //int ItemID,
            string ItemName,
            string SubCategory,
            byte PackType,
            double SalesPrice,
            double Barcode,
            int SupplierNo,
            double OrderingNumber,
            int Kolli,
            double KolliCost,
            int FSD_ID,
            int KampagneID,
            DateTime DisktilbudFraDato,
            DateTime DisktilbudTilDato,
            int DisktilbudThreshold,
            int ChainItemID)
        {
            CreateNewItemAsync(ItemName, SubCategory, PackType, SalesPrice, Barcode, SupplierNo, OrderingNumber, Kolli, KolliCost, FSD_ID, KampagneID, DisktilbudFraDato, DisktilbudTilDato, DisktilbudThreshold, ChainItemID);
            if (SaveData())
            {
                // data saved successfully,
                // close form and return true.
                Close();
                this.DialogResult = DialogResult.OK;
                return true;
            }
            else
            {
                // data not saved for some reason.
                // let the form display so user can see 
                // the error message and take action.
                this.DialogResult = DialogResult.Cancel;
                return false;
            }
        }
        #endregion

        #region CreateNewItemAsync
        /// <summary>
        /// Creates a new item and leaves the ItemForm open for user to take action.
        /// </summary>
        public void CreateNewItemAsync(
            //  int ItemID,
            string ItemName,
            string SubCategory,
            byte PackType,
            double SalesPrice,
            double Barcode,
            int SupplierNo,
            double OrderingNumber,
            int Kolli,
            double KolliCost,
            int FSD_ID,
            int KampagneID,
            DateTime DisktilbudFraDato,
            DateTime DisktilbudTilDato,
            int DisktilbudThreshold,
            int ChainItemID)

        {
            // set flag that this form was opened with
            // this method. this will also flag, that if
            // user saves data, the form will close with
            // dialogresult ok, otherwise it will be closed
            // with dialogresult cancel.
            // MUST BE SET HERE IN THE BEGINNING, AND
            // DEFINETELY BEFORE CALLING Show()
            WasOpenedWithCreateNewItemMethod = true;

            #region Create Item record

            // make sure ItemName is unique
            ItemName = ItemDataSet.ItemDataTable.GetUniqueItemName(ItemName); //peter20190411

            // simulate creating a new item in the GUI
            // (NOTE: the following 5 lines of code mode be executed in that order)
            Show();
            txtItemName.Enabled = false;
            NewPendingItemStart();
            txtItemName.Text = ItemName;
            txtFSD_ID.Text = FSD_ID.ToString();
            txtKampagneID.Text = KampagneID.ToString();
            // txtItemID.Text = ItemID.ToString();
            NewPendingItemSave();

            // we are still in new pending item mode.
            // let's fill in the data we have and then
            // let user complete the data before saving

            // get the current item row
            if (bindingItem.Current == null) return;
            DataRowView itemRow = (DataRowView)bindingItem.Current;

            // set subcategory
            itemRow["SubCategory"] = SubCategory;
            // inherit subcategory values to item
            LoadSubCategoryData();
            InheritCreditCategory();
            InheritAgeRestriction();
            InheritMOPRestriction();
            InheritItemTypeCode();
            InheritOtherSubCategoyValues();
            itemRow["FSD_ID"] = FSD_ID;
            itemRow["CostPriceLatest"] = KolliCost; //peter20190411
            itemRow["KampagneID"] = KampagneID;
            itemRow["DisktilbudFraDato"] = DisktilbudFraDato.Date == DateTime.MinValue ? (object)DBNull.Value : DisktilbudFraDato.Date;
            itemRow["DisktilbudTilDato"] = DisktilbudTilDato.Date == DateTime.MinValue ? (object)DBNull.Value : DisktilbudTilDato.Date;
            itemRow["DisktilbudThreshold"] = DisktilbudThreshold >= 0 ? DisktilbudThreshold : 0;

            #endregion

            #region Create PackType record

            // create a new packtype record and get a handle to it
            bindingRelItemSalesPack.AddNew();
            if (bindingRelItemSalesPack.Current == null) return;
            DataRowView packtypeRow = (DataRowView)bindingRelItemSalesPack.Current;

            // insert packtype data
            packtypeRow["PackType"] = 1;
            packtypeRow["SalesPackType"] = 3;  //STK
            packtypeRow["SalesPrice"] = SalesPrice;
            //pn20191022
            //pn20210304
            packtypeRow["UnitPriceNotShown"] = 1;
            //pn20210304
            //packtypeRow["IsPrimary"] = 1;

            // set barcode type
            byte BCType = 1; // default custom
            if (Barcode.ToString().Length == 13)
                BCType = 2;
            else if (Barcode.ToString().Length == 8)
                BCType = 3;

            if (Barcode != 0)
            {
                // if a barcode is given, check that it is unique.
                // if it is not unique, blank it
                if (ItemDataSet.BarcodeDataTable.BarcodeAlreadyExist(Barcode))
                {
                    packtypeRow["BCType"] = DBNull.Value;
                    packtypeRow["Barcode"] = DBNull.Value;
                }
                else
                {
                    packtypeRow["BCType"] = BCType;
                    packtypeRow["Barcode"] = Barcode;
                }
            }
            else
            {
                // if no barcode is given, generate a new unique barcode from SupplierNo
                Barcode = ItemDataSet.BarcodeDataTable.GenerateUniqueBarcode(OrderingNumber);
                packtypeRow["BCType"] = BCType;
                packtypeRow["Barcode"] = Barcode;
            }

            //pn20200218
            if (ChainItemID != 0)
            {
                packtypeRow["ChainItemID"] = ChainItemID;
                packtypeRow["ChainPackType"] = 1;
                packtypeRow["ChainBarcode"] = ItemDataSet.BarcodeDataTable.GetPrimaryBarcodeByItemID(ChainItemID);

            }



            // copy first 30 characters from Item's
            // ItemName to the salespack's ReceiptText
            string ReceiptText = ItemName;
            if (ReceiptText.Length > 30)
                ReceiptText = ReceiptText.Remove(29);
            packtypeRow["ReceiptText"] = ReceiptText;

            // copy the sales price to item
            CopyPrimarySalesPrice(SalesPrice);

            bindingRelItemSalesPack.EndEdit();

            // barcode record is created automatically
            // when the barcode is created on salespack table

            #endregion

            #region Create SupplierItem record

            if (OrderingNumber > 0)
            {
                // if missing kollisize in table LookupKolliSize, create it
                ItemDataSet.LookupKolliSizeAdminDataTable.CreateUserDefinedKolliSizeIfNonExisting(Kolli);

                // create a supplieritem record and insert values
                DataRowView supplieritemRow = (DataRowView)bindingRelSupplierItem.AddNew();
                DataGridViewCellEventArgs args = null;

                supplieritemRow["SupplierNo"] = SupplierNo;
                args = new DataGridViewCellEventArgs(colSupplierNumber.Index, 0);
                gridSupplierItem_CellEndEdit(gridSupplierItem, args);

                supplieritemRow["OrderingNumber"] = OrderingNumber;
                args = new DataGridViewCellEventArgs(colOrderingNumber.Index, 0);
                gridSupplierItem_CellEndEdit(gridSupplierItem, args);

                supplieritemRow["KolliSize"] = Kolli;
                args = new DataGridViewCellEventArgs(colKollisize.Index, 0);
                gridSupplierItem_CellEndEdit(gridSupplierItem, args);

                supplieritemRow["PackageUnitCost"] = KolliCost;
                args = new DataGridViewCellEventArgs(colPackageUnitCost.Index, 0);
                gridSupplierItem_CellEndEdit(gridSupplierItem, args);

                //supplieritemRow["SellingPackType"] = PackType; //pN20190819
                //args = new DataGridViewCellEventArgs(colSellingPackType.Index, 0);
                //gridSupplierItem_CellEndEdit(gridSupplierItem, args);
                //pn20200928
                bindingRelSupplierItem.EndEdit();
            }

            #endregion

            // reflect changes in GUI
            bindingItem.ResetCurrentItem();
            bindingRelItemSalesPack.ResetCurrentItem();
            bindingRelSupplierItem.ResetCurrentItem();
        }
        #endregion

        #region SaveData
        private bool SaveData()
        {
            if (!ValidateBeforeSave())
            {
                // save failed
                return false;
            }

            // update item timestamp
            dsItem.Item.UpdateLastChangeDateTime();

            // flag used to enable/disable transactions while
            // developing on transactions, as it causes some problems
            bool enableTransaction = true;

            try
            {
                // start a transaction before saving data
                if (enableTransaction)
                    db.StartTransaction();

                // save Item data
                if (enableTransaction)
                {
                    adapterItem.UpdateCommand.Transaction = db.CurrentTransaction;
                    adapterItem.InsertCommand.Transaction = db.CurrentTransaction;
                }
                bindingItem.EndEdit();

                /// If FSD_ID has been changed we need to check if there are
                /// any other items with this FSD_ID, and if so, these items
                /// needs to have UpdateRSM marked.
                if (bindingItem.Current != null)
                {
                    DataRow row = (bindingItem.Current as DataRowView).Row;
                    int ItemID = tools.object2int(row["ItemID"]); //peter 20190410
                    int FSD_ID_ondisk = ItemDataSet.ItemDataTable.GetFSD_ID(ItemID);
                    int FSD_ID_inmemory = tools.object2int(row["FSD_ID"]);
                    if ((FSD_ID_ondisk > 0) && (FSD_ID_ondisk != FSD_ID_inmemory))
                    {
                        List<int> itemsWithGivenFSD_ID = ItemDataSet.ItemDataTable.GetItemIDsWithGivenFSD_ID(FSD_ID_ondisk);
                        foreach (int tmpItemID in itemsWithGivenFSD_ID)
                        {
                            if (tmpItemID != ItemID) // we don't need to change this very item here
                                ItemDataSet.SalesPackDataTable.SetUpdateRSM(tmpItemID);
                        }
                    }
                }

                adapterItem.Update(dsItem.Item);

                // save related SalesPack data
                if (enableTransaction)
                {
                    adapterSalesPack.UpdateCommand.Transaction = db.CurrentTransaction;
                    adapterSalesPack.InsertCommand.Transaction = db.CurrentTransaction;
                }
                bindingRelItemSalesPack.EndEdit();
                adapterSalesPack.Update(dsItem.SalesPack);

                // save related Barcode data.
                if (enableTransaction)
                {
                    adapterBarcode.UpdateCommand.Transaction = db.CurrentTransaction;
                    adapterBarcode.InsertCommand.Transaction = db.CurrentTransaction;
                }
                bindingRelItemsSalesPackBarcode.EndEdit();
                adapterBarcode.Update(dsItem.Barcode);

                // save related Sales Pack Future Prices
                if (enableTransaction)
                {
                    adapterRelSalesPackFuturePrices.UpdateCommand.Transaction = db.CurrentTransaction;
                    adapterRelSalesPackFuturePrices.InsertCommand.Transaction = db.CurrentTransaction;
                    adapterRelSalesPackFuturePrices.DeleteCommand.Transaction = db.CurrentTransaction;
                }
                bindingRelSalesPackFuturePrices.EndEdit();
                adapterRelSalesPackFuturePrices.Update(dsItem.SalesPackFuturePrices);

                // save related SupplierItem data
                if (enableTransaction)
                {
                    adapterRelSupplierItem.UpdateCommand.Transaction = db.CurrentTransaction;
                    adapterRelSupplierItem.InsertCommand.Transaction = db.CurrentTransaction;
                    adapterRelSupplierItem.DeleteCommand.Transaction = db.CurrentTransaction;
                }
                bindingRelSupplierItem.EndEdit();
                adapterRelSupplierItem.Update(dsItem.SupplierItem);//peter20190411



                // save ok, commit transaction
                if (enableTransaction)
                    db.CommitTransaction();
            }
            catch (Exception ex)
            {
                // error while saving, rollback transaction
                if (enableTransaction)
                    db.RollbackTransaction();

                // if item were new pending item, cancel it
                if (newItemMode)
                    NewPendingItemCancel();

                // save exception in log file and display error
                MessageBox.Show(log.WriteException(
                    "ItemForm.btnSave_Click",
                    ex.Message,
                    ex.StackTrace));

                // save failed
                return false;
            }
            finally
            {
                // remove now invalid transactions from adapters
                if (enableTransaction)
                {
                    adapterItem.UpdateCommand.Transaction = null;
                    adapterItem.InsertCommand.Transaction = null;
                    adapterSalesPack.UpdateCommand.Transaction = null;
                    adapterSalesPack.InsertCommand.Transaction = null;
                    adapterBarcode.UpdateCommand.Transaction = null;
                    adapterBarcode.InsertCommand.Transaction = null;
                    adapterRelSalesPackFuturePrices.UpdateCommand.Transaction = null;
                    adapterRelSalesPackFuturePrices.InsertCommand.Transaction = null;
                    adapterRelSupplierItem.UpdateCommand.Transaction = null;
                    adapterRelSupplierItem.InsertCommand.Transaction = null;
                }
            }

            ToggleEdit(false);

            // successfully saved, exit new item mode (if we were in it)
            newItemMode = false;

            // saving data, so if ItemName field had
            // been disabled by new pending mode, re-enable it.
            // it is still readonly
            txtItemName.Enabled = true;

            /// reload all data due to some sync error.
            /// we had some sync problems when creating a salespack record, saving data,
            /// then deleting the salespack record again. it seems that the table on disk
            /// and the in-memmory table were not in sync. we got the exception
            /// "DBConcurrencyException", "Concurrency violation: the DeleteCommand
            /// affected 0 of the expected 1 records".
            if (bindingItem.Current != null)
            {
                if (((DataRowView)bindingItem.Current)["ItemID"] is int)
                {
                    int ItemID = int.Parse(((DataRowView)bindingItem.Current)["ItemID"].ToString());
                    adapterItem.Fill(dsItem.Item, ItemID);
                    adapterSalesPack.Fill(dsItem.SalesPack, ItemID);
                    adapterBarcode.Fill(dsItem.Barcode, ItemID);
                    adapterRelTransac.Fill(dsItem.ItemTransaction, ItemID);
                    adapterRelSupplierItem.Fill(dsItem.SupplierItem, ItemID);
                    adapterRelSalesPackFuturePrices.FillAcrossSalesPacks(dsItem.SalesPackFuturePrices, ItemID);
                    dsItem.SalesPack.SetNumBarcodesCalcAllRows(dsItem.Barcode);
                }
            }

            // save ok
            return true;
        }
        #endregion

        /// <summary>
        /// Opens the itemform for editing a single item.
        /// When user clicks save or cancel, the form is closed
        /// with a dialogresult corresponding to the selection.
        /// </summary>
        public DialogResult EditSingleItem(int ItemID)
        {
            _EditSingleMode = true;
            _EditSingleMode_ItemID = ItemID;
            return this.ShowDialog();
        }

        // form load event
        private void ItemForm_Load(object sender, EventArgs e)
        {
            ToggleEdit(false);

            // order SalesPack columns
            int idx = 0;
            //>>PN20210422
            colBarcodeType.DisplayIndex = idx++;
            colBarcode.DisplayIndex = idx++;
            colSalesPrice.DisplayIndex = idx++;
            //<<PN20210422

            colPackType.DisplayIndex = idx++;           

            colIsPrimary.DisplayIndex = idx++;
            colManualPrice.DisplayIndex = idx++;
            


            colHasFuturePrices.DisplayIndex = idx++;

            colCalcNumBarcodes.DisplayIndex = idx++;
            colBarcodeButton.DisplayIndex = idx++;
            colBtnSalesPackDetailsForm.DisplayIndex = idx++;

            // fill lookup tables
            adapterLookupBarcodeType.Fill(dsItem.LookupBarcodeType);
            adapterLookupPackType.Fill(dsItem.LookupPackSize);
            adapterLookupSubCategory.Fill(dsItem.LookupSubCategory);
            adapterLookupVatRate.Fill(dsItem.LookupVatRate);
            adapterLookupSupplier.Fill(dsItem.LookupSupplier);
            adapterLookupKolliSize.Fill(dsItem.LookupKolliSize);

            // allow browsing in all Items from beginning
            if (!WasOpenedWithCreateNewItemMethod)
            {
                if (!_EditSingleMode)
                {
                    // the normal way this form is opened
                    SearchForm search = new SearchForm();  //20181010
                    bindingFilterList.DataSource = search.ItemList;
                }
                else
                {
                    // when opened editing an inactive item, only show that item, in editmode
                    List<int> tmpItemList = new List<int>();
                    tmpItemList.Add(_EditSingleMode_ItemID);
                    bindingFilterList.DataSource = tmpItemList;
                    btnEdit.PerformClick();
                }
            }

            // localization
            this.Text = db.GetLangString("TreeMenu0301"); // set here too as it is called from LL interface too
            lbItemName.Text = db.GetLangString("ItemForm.ItemNameLabel");
            lbSubCategory.Text = db.GetLangString("ItemForm.SubCatIDLabel");
            lbNewShelfMarker.Text = db.GetLangString("ItemForm.NewShelfMarkerLabel");
            lbUpdateRSM.Text = db.GetLangString("ItemForm.UpdateRSMLabel");
            lbUpdateStations.Text = db.GetLangString("ItemForm.lbUpdateStations");
            lbLastCounted.Text = db.GetLangString("ItemForm.LastInventoryLabel");
            lbLastChanged.Text = db.GetLangString("ItemForm.LastChangedLabel");
            lbStock.Text = db.GetLangString("ItemForm.StockOnHandLabel");
            lbMinStock.Text = db.GetLangString("ItemForm.MinOnHandLabel");
            lbSalesPrice.Text = db.GetLangString("ItemForm.SalesPriceLabel");
            lbLastCostPrice.Text = db.GetLangString("ItemForm.LastCostpriceLabel");
            lbMargin.Text = db.GetLangString("ItemForm.MarginLabel");
            lbBudgetMargin.Text = db.GetLangString("ItemForm.BudgetMarLabel");
            lbGroupPrimSP.Text = db.GetLangString("ItemForm.GroupPrimarySPHeadLabel");
            lbSalesPacks.Text = db.GetLangString("ItemForm.SalesPackLabel");
            lbDiscardedPer.Text = db.GetLangString("ItemForm.lbDiscardedPer");
            btnRemoveFilter.Text = db.GetLangString("ItemForm.RemoveFilterBtn");
            btnNew.Text = db.GetLangString("ItemForm.NewItemBtn");
            btnDelete.Text = db.GetLangString("ItemForm.DeleteItemBtn");
            btnSave.Text = db.GetLangString("ItemForm.SaveBtn");
            btnEdit.Text = db.GetLangString("Application.Edit");
            btnCancel.Text = db.GetLangString("Application.Cancel");
            btnClose.Text = db.GetLangString("Application.Close");


            colPackType.HeaderText = db.GetLangString("ItemFormGrid.TypeHeadLabel");
            colManualPrice.HeaderText = db.GetLangString("ItemFormGrid.ManualPriceLabel");
            colSalesPrice.HeaderText = db.GetLangString("ItemFormGrid.SalesPriceLabel");
            colBarcodeType.HeaderText = db.GetLangString("ItemFormGrid.BarcTypeLabel");
            colBarcode.HeaderText = db.GetLangString("ItemFormGrid.BarcodeLabel");
            colCalcNumBarcodes.HeaderText = db.GetLangString("ItemFormGrid.BarcNoOfLabel");
            colBarcodeButton.HeaderText = db.GetLangString("ItemFormGrid.EditBarcLabel");
            colBtnSalesPackDetailsForm.HeaderText = db.GetLangString("ItemFormGrid.EditSPDetailLabel");
            colCalcNumBarcodes.ToolTipText = db.GetLangString("ItemFormGrid.BarcNoOfHintMsg");
            colBarcodeButton.ToolTipText = db.GetLangString("ItemFormGrid.EditBarcHintMsg");
            colBtnSalesPackDetailsForm.ToolTipText = db.GetLangString("ItemFormGrid.EditSalesPaDetailHintMsg");
            colHasFuturePrices.HeaderText = db.GetLangString("ItemForm.colHasFutureSalesPrices");

            tabGeneral.Text = db.GetLangString("ItemFormTabHead.GeneralLabel");
            tabItems.Text = db.GetLangString("ItemFormTabHead.TransactionLabel");
            tabOrder.Text = db.GetLangString("ItemFormTabHead.OrderNoLabel");
            tabOther.Text = db.GetLangString("ItemFormTabHead.OtherLabel");

            lbCategoryGroupBox.Text = db.GetLangString("ItemForm.GroupBoxCategoryLabel");

            lbVateRate.Text = db.GetLangString("ItemForm.VatRateLabel");
            lbVatOwner.Text = db.GetLangString("ItemForm.VatOwnerLabel");
            lbCreditCategory.Text = db.GetLangString("ItemForm.CreditCategoryLabel");
            lbAgeRestriction.Text = db.GetLangString("ItemForm.AgeRestrictLabel");
            lbMOPRestriction.Text = db.GetLangString("ItemForm.MOPRestrictLabel");
            //lbFocusItem.Text = db.GetLangString("ItemForm.FocusItemLabel");
            //lbTransfered.Text = db.GetLangString("ItemForm.TranferredCategoryLabel");
            lbItemTypeCode.Text = db.GetLangString("ItemForm.ItemTypeCodeLabel");
            lblItemTypeSubCode.Text = db.GetLangString("ItemForm.ItemTypeSubCodeLabel");
            lbFSD_ID.Text = db.GetLangString("ItemForm.lbFSD_ID");
            lbKampagneID.Text = db.GetLangString("ItemForm.lbKampagneID");
            lbIsInCampaign.Text = db.GetLangString("ItemForm.lbIsInCampaign");

            // lbDisktilbud.Text = db.GetLangString("ItemForm.lbDisktilbud");
            //lbDisktilbudTreshold.Text = db.GetLangString("ItemForm.lbDisktilbudTreshold");

            colTransacTransNo.HeaderText = db.GetLangString("ItemFormTran.TransNoLabel");
            colTransacPostDate.HeaderText = db.GetLangString("ItemFormTran.PostDateLabel");
            colTransacTranType.HeaderText = db.GetLangString("ItemFormTran.TransTypeLabel");
            colTransacNoOff.HeaderText = db.GetLangString("ItemFormTran.NoOfLabel");
            colTransacAmount.HeaderText = db.GetLangString("ItemFormTran.AmountLabel");
            //colTransacReasonC.HeaderText = db.GetLangString("ItemFormTran.ReasonCodeLabel");
            colTransacSPType.HeaderText = db.GetLangString("ItemFormTran.PackTypeLabel");
            colTransacBarcode.HeaderText = db.GetLangString("ItemFormTran.BarcodeLabel");
            colSalesUnits.HeaderText = db.GetLangString("ItemFormTran.SalgsEnh");

            // copy primary sales pack sales price to item (in-memory)
            CopyPrimarySalesPrice(null);

            // Set column order in SalesTransaction grid
            colTransacTransNo.DisplayIndex = 0;
            colTransacPostDate.DisplayIndex = 1;
            colTransacTranType.DisplayIndex = 2;
            colTransacNoOff.DisplayIndex = 3;
            colTransacAmount.DisplayIndex = 4;
            colSeparatorColumn.DisplayIndex = 5;
            colSalesUnits.DisplayIndex = 6;
            colTransacSPType.DisplayIndex = 7;
            colTransacBarcode.DisplayIndex = 8;
            //colTransacReasonC.DisplayIndex = 9;

            // Set column order in SupplierItem grid
            int DisplayIndex = -1;
            colSupplierNumber.DisplayIndex = ++DisplayIndex;
            colSupplierNumberButton.DisplayIndex = ++DisplayIndex;
            colOrderingNumber.DisplayIndex = ++DisplayIndex;
            colIsPrimarySupplItem.DisplayIndex = ++DisplayIndex;
            colKollisize.DisplayIndex = ++DisplayIndex;
            colPackageCost.DisplayIndex = ++DisplayIndex;
            colPackageUnitCost.DisplayIndex = ++DisplayIndex;
            colSeparatorSupplItems.DisplayIndex = ++DisplayIndex;
            //colSellingPackType.DisplayIndex = ++DisplayIndex;
            // colNoOfSellingUnits.DisplayIndex = ++DisplayIndex;
            //colSellingUnitCost.DisplayIndex = ++DisplayIndex; Pn20190819
            ColInActiveDate.DisplayIndex = ++DisplayIndex;


            if (!DOSite)
            {
                btnDelete.Visible = false;
                btnNew.Visible = false;
                btnEdit.Enabled = UserLogon.EditSalesPrice();

            }


        }



        // filter index changed event
        private void bindingFilterList_CurrentChanged(object sender, EventArgs e)
        {
            if (bindingFilterList.Current != null)
            {
                // get the currently selected ItemID
                int ItemID = int.Parse(bindingFilterList.Current.ToString());

                // load Item data
                adapterItem.Fill(dsItem.Item, ItemID);
                // load SalesPack data
                adapterSalesPack.Fill(dsItem.SalesPack, ItemID);
                // load Barcode data

                // note that we only provide ItemID, as we want to be able to
                // update all data in one bundle for this ItemID and not only for
                // each SalesPack individually. we let the relation and binder handle
                // displaying only the barcodes for each selected SalesPack.
                adapterBarcode.Fill(dsItem.Barcode, ItemID);

                // fill SalesPackFuturePrices (across all salespack at once)
                adapterRelSalesPackFuturePrices.FillAcrossSalesPacks(dsItem.SalesPackFuturePrices, ItemID);

                // fill Transaction
                if (TabIndex == 3)
                    adapterRelTransac.Fill(dsItem.ItemTransaction, ItemID);//20181010

                // fill SupplierItem
                adapterRelSupplierItem.Fill(dsItem.SupplierItem, ItemID);

                // calculate all barcodes on sales pack table
                dsItem.SalesPack.SetNumBarcodesCalcAllRows(dsItem.Barcode);

                // update item GUI controls UpdateRSM and UpdateShelfLabel (not databound)
                chkUpdateRSM.Checked = dsItem.SalesPack.HasAnyUpdateRSM();
                chkUpdateStations.Checked = dsItem.SalesPack.HasAnyUpdateStations();
                chkNewShelfMarker.Checked = dsItem.SalesPack.HasAnyUpdateShelfLabel();


            }
        }

        // save button click event
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                // if this form was opened with method CreateNewItem or inactive item
                // and data was saved, close the form with dialogresult ok
                if (WasOpenedWithCreateNewItemMethod || _EditSingleMode)
                {
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        // cancel button click event
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            if (newItemMode)
            {
                NewPendingItemCancel();
            }
            else
            {
                if (bindingFilterList.Current != null)
                {
                    int ItemID = int.Parse(bindingFilterList.Current.ToString());

                    // cancel Item data
                    bindingItem.CancelEdit();
                    adapterItem.Fill(dsItem.Item, ItemID);

                    // cancel related SalesPack data and  reload data from in-memory table (for grid)
                    bindingRelItemSalesPack.CancelEdit();
                    adapterSalesPack.Fill(dsItem.SalesPack, ItemID);

                    // cancel related Barcode data and reload data from in-memory table (for grid)
                    bindingRelItemsSalesPackBarcode.CancelEdit();
                    adapterBarcode.Fill(dsItem.Barcode, ItemID);

                    // cancel related future sales prices data from in-memory table
                    bindingRelSalesPackFuturePrices.CancelEdit();
                    adapterRelSalesPackFuturePrices.FillAcrossSalesPacks(dsItem.SalesPackFuturePrices, ItemID);

                    // cancel related SupplierItem data and reload data from in-memory table (for grid)
                    bindingRelSupplierItem.CancelEdit(); //20191121
                    adapterRelSupplierItem.Fill(dsItem.SupplierItem, ItemID);
                    if (TabIndex == 3) //20181011
                        adapterRelTransac.Fill(dsItem.ItemTransaction, ItemID);

                    // re-calculate all barcodes on sales pack table
                    dsItem.SalesPack.SetNumBarcodesCalcAllRows(dsItem.Barcode);

                    // update item GUI fields UpdateRSM and UpdateShelfLabel (not databound)
                    chkUpdateRSM.Checked = dsItem.SalesPack.HasAnyUpdateRSM();
                    chkUpdateStations.Checked = dsItem.SalesPack.HasAnyUpdateStations();
                    chkNewShelfMarker.Checked = dsItem.SalesPack.HasAnyUpdateShelfLabel();

                    ToggleEdit(false);
                }
            }



            // if this form was opened with method CreateNewItem or editing inactive item
            // close the form (with default dialogresult cancel)
            if (WasOpenedWithCreateNewItemMethod || _EditSingleMode)
                Close();
        }

        // close button click event
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // edit button click event
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // toggle edit mode
            if (UserLogon.EditSalesPrice() == true)
                ToggleEdit(true);
        }

        // sales pack grid content click event
        private void gridPackSize_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // do not process column header click
            //Pn20200103
            if (e.RowIndex < 0) return;


            DataRowView row = (DataRowView)bindingRelItemSalesPack.Current;

            // check we have a record
            if (row == null) return;

            ItemDataSet.SalesPackRow typedRow = (ItemDataSet.SalesPackRow)row.Row;

            // check that a packtype id exists
            if (row["PackType"] == DBNull.Value)
            {
                MessageBox.Show(db.GetLangString("ItemFormMsg.PleaseEnterAPacktypeIdFirst"));
                return;
            }

            // check that row is not SemiDeleted
            if ((row["SemiDeleted"] != DBNull.Value) && bool.Parse(row["SemiDeleted"].ToString()))
                return;

            // open detail forms for Barcode or SalesPack
            if (((e.ColumnIndex == colBarcodeButton.Index) && (colBarcodeButton.ReadOnly == false)) ||
                ((e.ColumnIndex == colBtnSalesPackDetailsForm.Index)&& (colBtnSalesPackDetailsForm.ReadOnly == false)))
            {
                // check that barcodetype and barcode exists
                if ((row["BCType"] == DBNull.Value) || (row["Barcode"] == DBNull.Value))
                {
                    MessageBox.Show(db.GetLangString("ItemForm.PleaseSpecifyBarcodeFirst"));
                    return;
                }
                else
                {
                    // copy barcode to barcode table (the function only copies if new values)
                    dsItem.Barcode.SetPrimaryBarcode(
                        typedRow.ItemID,
                        typedRow.PackType,
                        typedRow.BCType,
                        typedRow.Barcode);

                }

                // end edit of salespack first, as this is needed for two reasons:
                // 1. reflect changes so they can be seen in salespackdetails form
                // 2. avoid cancel of salespack row after detail forms has been opened
                bindingRelItemSalesPack.EndEdit();

                if (colBarcodeButton.Index == e.ColumnIndex)
                {
                    // if clicked column is barcode button, open barcode form

                    // create and open BarcodeForm
                    BarcodeForm form = new BarcodeForm(dsItem, bindingRelItemsSalesPackBarcode);

                    form.ShowDialog(this);
                }
                else if (e.ColumnIndex == colBtnSalesPackDetailsForm.Index)
                {
                    // if clicked column is sales pack detail form button, open that form
                    //2020031
                    // create and open sales pack detail form
                    SalesPackDetailsForm form = new SalesPackDetailsForm(dsItem, bindingRelItemSalesPack, bindingRelItemsSalesPackBarcode, bindingRelSalesPackFuturePrices);
                    form.ShowDialog(this);
                }

                // below things are done after both closing barcode and 
                // salespackdetail forms, as both might change, add or delete barcodes

                // if barcode table has changed, set UpdateRSM on salespack
                DataTable changes = dsItem.Barcode.GetChanges();
                if ((changes != null) && (changes.Rows.Count > 0))
                {
                    row["UpdateRSM"] = true;
                    row["UpdateStations"] = true;
                }

                // re-calculate number of barcodes for this sales pack
                short packType = short.Parse(row["PackType"].ToString());
                row["NumBarcodesCalc"] = dsItem.Barcode.GetNumBarcodes(packType); //20181011
                bindingRelItemSalesPack.ResetCurrentItem();
            }
        }

        // grid cell validated event
        private void gridPackSize_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            // do not process column header click
            if (e.RowIndex < 0) return;

            DataRowView row = (DataRowView)bindingRelItemSalesPack.Current;
            if ((!gridPackSize.ReadOnly) && (row != null) && (row.Row["PackType"] != DBNull.Value))
            {
                if (e.ColumnIndex == colPackType.Index)
                {
                    // if PackType approved, copy first 30 characters
                    // from Item's ItemName to the salespack's ReceiptText,
                    // if salespack does not have ReceiptText
                    if ((bindingItem.Current != null) &&
                        ((row["ReceiptText"] == DBNull.Value) || (row["ReceiptText"].ToString() == "")))
                    {
                        DataRowView itemRow = (DataRowView)bindingItem.Current;
                        if (itemRow["ItemName"] is string)
                        {
                            string text = itemRow["ItemName"].ToString();
                            if (text.Length > 30)
                                text = text.Remove(29, text.Length - 30);
                            row["ReceiptText"] = text;
                        }
                    }
                }
                else if (e.ColumnIndex == colSalesPrice.Index)
                {
                    // if salesprice is null, set it to 0
                    if (row["SalesPrice"] == DBNull.Value)
                        row["SalesPrice"] = 0;

                    // if this is the primary salespack, copy the sales price to item
                    if ((row["IsPrimary"] is bool) && bool.Parse(row["IsPrimary"].ToString()))
                    {
                        CopyPrimarySalesPrice(row["SalesPrice"]);
                    }

                    // if salesprice is 0, reflect that db sets
                    // manual price to true
                    if ((double)row["SalesPrice"] == 0)
                    {
                        gridPackSize[colManualPrice.Index, e.RowIndex].Value = row["ManualPrice"];
                        gridPackSize.Refresh();
                    }
                    //>>pn20210507
                    if ((bindingItem.Current != null) &&
                       ((row["ReceiptText"] == DBNull.Value) || (row["ReceiptText"].ToString() == "")))
                    {
                        DataRowView itemRow = (DataRowView)bindingItem.Current;
                        if (itemRow["ItemName"] is string)
                        {
                            string text = itemRow["ItemName"].ToString();
                            if (text.Length > 30)
                                text = text.Remove(29, text.Length - 30);
                            row["ReceiptText"] = text;
                        }
                    }
                    //pn20210507
                }
                else if (e.ColumnIndex == colManualPrice.Index)
                {
                    // sales price is 0, db will set manual price back to true,
                    // so reflect this in GUI by refetching data
                    bindingRelItemSalesPack.ResetCurrentItem();
                }
                else if (e.ColumnIndex == colIsPrimary.Index)
                {
                    // when ending edit of IsPrimaryColumn
                    // reflect changes made in table when selecting a
                    // checkmark, as all other checkmarks are removed
                    bindingRelItemSalesPack.ResetCurrentItem();

                    // if primary sales pack selected, copy sales price to item
                    if (tools.object2bool(row["IsPrimary"]) == true)
                    {
                        // only copy if not null
                        if (row["SalesPrice"] != DBNull.Value)
                            CopyPrimarySalesPrice(row["SalesPrice"]);
                    }
                }
            }
        }

        // packsize grid cell validating event
        private void gridPackSize_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // do not process column header click
            if (e.RowIndex < 0) return;
            if (gridPackSize.ReadOnly) return;

            if (bindingRelItemSalesPack.Current != null)
            {
                DataRowView row = (DataRowView)bindingRelItemSalesPack.Current;
                ItemDataSet.SalesPackRow typedRow = (ItemDataSet.SalesPackRow)row.Row;
                if (e.ColumnIndex == colPackType.Index)
                {
                    // when selecting a new PackType,
                    // check that it would be unique

                    if (e.FormattedValue is string)
                    {
                        short packtype = dsItem.SalesPack.ReverseLookupPackType(e.FormattedValue.ToString());
                        // check that user has selected something else.
                        // either existing packtype is null = new salespack,
                        // or the existing packtype is the same as the formatted = no change.
                        if ((row["PackType"] == DBNull.Value) || (typedRow.PackType != packtype))
                        {
                            if (!dsItem.SalesPack.IsUniqueKey(typedRow.ItemID, packtype))
                            {
                                // user selected a PackType that has already been used on another salespack row,
                                // so ask user to either modify the selection and focus that cell or have user
                                // cancel the entire row edit
                                MessageBox.Show(db.GetLangString("ItemFormMsg.PackTypeAlreadyExistOnThisItem"));
                                e.Cancel = true;
                            }
                        }
                    }
                    else
                        e.Cancel = true;
                }
                else if (e.ColumnIndex == colBarcode.Index)
                {
                    // don't even try to validate barcode if BCType is null,
                    // as user won't be able to escape the barcode field as
                    // e.Cancel = true prevents user from leaving the barcode field
                    if (row["BCType"] != DBNull.Value)
                    {
                        object newValue = e.FormattedValue;

                        // if creating a new salespack row and
                        // emptying the barcode value, null the bctype
                        // field so we can leave the barcode field
                        // without getting validation errors
                        if ((tools.object2string(newValue) == "") &&
                            (row.IsNew == true))
                        {
                            row["BCType"] = DBNull.Value;
                            return;
                        }

                        // when changing barcode value, check that 
                        // the entered barcode value can be used
                        if (!dsItem.Barcode.VerifyBarcode(
                            row["Barcode"], ref newValue, row["ItemID"], row["PackType"], row["BCType"]))
                        {
                            if (dsItem.Barcode.VerifyBarcodeMsg != "")
                                MessageBox.Show(dsItem.Barcode.VerifyBarcodeMsg);
                            e.Cancel = true;
                        }
                        else
                        {
                            // barcode ok and might have had checksum added
                            gridPackSize[e.ColumnIndex, e.RowIndex].Value = newValue;
                            //>>PN20210507
                            //bindingRelItemSalesPack.ResetCurrentItem();
                            //<<PN20210507
                        }
                    }
                }


            }
        }

        // grid data error event
        private void gridPackSize_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            /* hiding default exception message */

            // cancel data change and return focus to the row with error
            e.Cancel = true;
        }

        // context menu salespack delete click
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSalesPackAndBarcodes();
        }




        // grid cell begin edit event
        private void gridPackSize_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // do not process column header click
            //>>PN20210416
            if (e.RowIndex < 0) return;
            if (bindingRelItemSalesPack.Current != null)
            {
                DataRowView row = (DataRowView)bindingRelItemSalesPack.Current;
                ItemDataSet.SalesPackRow typedRow = (ItemDataSet.SalesPackRow)row.Row;




                // do not allow edit on a SemiDeleted record
                if ((row["SemiDeleted"] != DBNull.Value) && bool.Parse(row["SemiDeleted"].ToString()))
                {
                    e.Cancel = true;
                    return;
                }

                if (e.ColumnIndex != colPackType.Index)
                {
                    // no cells may be edited before packtype has been selected (key)
                    //>>pn20210416                                      

                    gridPackSize.AllowUserToAddRows = true;
                    if (gridPackSize.Rows.Count > 1)
                    {
                        gridPackSize.AllowUserToAddRows = false;
                    }

                    row["PackType"] = 1;
                    row["IsPrimary"] = true;
                    //if (row["PackType"] == DBNull.Value)
                    //{
                    //    MessageBox.Show(db.GetLangString("ItemFormMsg.PleaseEnterAPacktypeIdFirst"));
                    //    e.Cancel = true;
                    //    return;
                    //}
                    //<<pn20210416
                }
                else
                {
                    // do not allow editing salespack when it has been saved to database
                    DataRowState rowstate = ((ItemDataSet.SalesPackRow)row.Row).RowState;
                    if ((rowstate != DataRowState.Added) && (rowstate != DataRowState.Detached))
                    {
                        e.Cancel = true;
                        MessageBox.Show(db.GetLangString("ItemForm.CannotEditSavedPackType"));
                        return;
                    }
                }

                // check the other columns
                if (e.ColumnIndex == colBarcodeType.Index)
                {
                    // do not allow editing the barcod type if salespack record has been saved to database
                    DataRowState rowstate = ((ItemDataSet.SalesPackRow)row.Row).RowState;
                    if ((rowstate != DataRowState.Added) && (rowstate != DataRowState.Detached))
                    {
                        e.Cancel = true;
                        MessageBox.Show(db.GetLangString("ItemForm.CannotEditPrimaryBarcodeType"));
                        return;
                    }

                    // if beginning edit of bctype cell, check if barcode is already filled in,
                    // and if so, ask user to either accept that barcode will be deleted or to cancel
                    if (row["Barcode"] != DBNull.Value)
                    {
                        if (MessageBox.Show(db.GetLangString("ItemForm.BarcodeWillBeDeletedOK?Msg"), "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            // null the barcode value (in grid so ESC still can cancel)
                            gridPackSize[colBarcode.Index, e.RowIndex].Value = DBNull.Value;
                            // null the barcode value and reflect the null in the GUI
                            //@@@row["Barcode"] = DBNull.Value;
                            //@@@bindingRelItemSalesPack.ResetCurrentItem();
                        }
                        else
                            e.Cancel = true;
                    }
                }
                else if (e.ColumnIndex == colBarcode.Index)
                {
                    // do not allow editing the barcod type if salespack record has been saved to database
                    DataRowState rowstate = ((ItemDataSet.SalesPackRow)row.Row).RowState;
                    if ((rowstate != DataRowState.Added) && (rowstate != DataRowState.Detached))
                    {
                        e.Cancel = true;
                        MessageBox.Show(db.GetLangString("ItemForm.CannotEditPrimaryBarcode"));
                        return;
                    }

                    // if beginning edit of barcode cell,
                    // check that a barcode type has been selected,
                    if (row["BCType"] == DBNull.Value)
                    {
                        MessageBox.Show(db.GetLangString("ItemFormMsg.PleaseSelectBarcodeTypeFirst"));
                        e.Cancel = true;
                    }
                }
                else if (e.ColumnIndex == colIsPrimary.Index)
                {
                    /// if beginning edit of IsPrimary cell,
                    /// check to see if this is the first salespack
                    /// record, and if it is, do not allow the
                    /// mouse click to affect the checkbox, as
                    /// the database has already set this flag, so
                    /// this would lead to the checkbox being selected
                    /// and then deselected at once.
                    if (dsItem.SalesPack.Rows.Count <= 0)
                    {
                        e.Cancel = true;
                    }
                }
                else if (e.ColumnIndex == colHasFuturePrices.Index)
                {
                    /// do not allow editing the HasFuturePrices column as it
                    /// is supposed to be readonly, but for some reason, the
                    /// grid allows the user to toggle the checkbox.
                    e.Cancel = true;
                }
            }
        }

        //>>PN20210


    

    



    // btnSearch click event
    private void btnSearch_Click(object sender, EventArgs e)
        {
            if (bindingFilterList.Current != null)
            {
                // get the current ItemID for selecting it on search form
                int itemID = int.Parse(bindingFilterList.Current.ToString());

                // open search form
                SearchForm search = new SearchForm();
                search.SelectedItemID = itemID;
                search.ShowDialog(this);
                if (search.DialogResult == DialogResult.OK)
                {
                    // if user clicked ok on search form,
                    // get list of items and position on the selected item
                    bindingFilterList.DataSource = search.ItemList;
                    bindingFilterList.Position = search.SelectedItemListIndex;
                    itemDataFiltered = search.ClosedWithFilter;
                    btnRemoveFilter.Enabled = itemDataFiltered;
                }
            }
        }

        // btnRemoveFilter click event
        private void btnRemoveFilter_Click(object sender, EventArgs e)
        {
            // remove the item data filter, so all items are shown
            // and keep the current position

            // keep current ItemID
            int currItemID = int.Parse(bindingFilterList.Current.ToString());

            // create a search form, as this will load all items
            // and then we can retrieve the full ItemID list
            SearchForm search = new SearchForm();
            bindingFilterList.DataSource = search.ItemList;

            // set flag that items are not filtered and disabled remove filter button
            itemDataFiltered = false;
            btnRemoveFilter.Enabled = itemDataFiltered;

            // find the currently selected ItemID in the new full list
            int index = bindingFilterList.IndexOf(currItemID);
            bindingFilterList.Position = index;
        }

        // btnLookupSubCategory click event
        private void btnLookupSubCategory_Click(object sender, EventArgs e)
        {
            // open subcategory popup form and insert returned
            // subcategoryid into current item's subcategory field
            DataRowView row = (DataRowView)bindingItem.Current;
            if (row != null)
            {
                SubCategoryPopup subcat = new SubCategoryPopup();
                subcat.SelectedSubCategoryID = row["SubCategory"].ToString();
                if (subcat.ShowDialog(this) == DialogResult.OK)
                {
                    // if user selects a subcategory and it is valid,
                    // assign it to item's SubCategory field
                    if (subcat.SelectedSubCategoryID != "")
                    {                        
                        row["SubCategory"] = subcat.SelectedSubCategoryID;

                        // inherit subcategory values to item
                        LoadSubCategoryData();
                        InheritCreditCategory();
                        InheritAgeRestriction();
                        InheritMOPRestriction();
                        InheritItemTypeCode();
                        InheritOtherSubCategoyValues();

                        // reflect changes in GUI
                        bindingItem.ResetCurrentItem();
                    }
                }
            }
        }

        // new button click event
        private void btnNew_Click(object sender, EventArgs e)
        {
            NewPendingItemStart();
        }

        // form closing event
        private void ItemForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(newItemMode)
                NewPendingItemCancel();
        }

        // txtItemName keydown event
        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (newItemMode)
            {
                if (e.KeyCode == Keys.Enter)
                    tools.EnterAsTab(e); // focus any next control to start validation
                if (e.KeyCode == Keys.Escape)
                    NewPendingItemCancel();
            }
        }

        // btnDelete click event
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteCurrentItem();
        }

        // grid RowsRemoved event
        private void gridPackSize_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            // if this is the last row in the sales pack table, for the item,
            // and IsPrimary is = false, set IsPrimary = true
            if (bindingRelItemSalesPack.Count == 1)
            {
                bindingRelItemSalesPack.Position = 0;
                if (bindingRelItemSalesPack.Current != null)
                {
                    ItemDataSet.SalesPackRow row =
                        (ItemDataSet.SalesPackRow)((DataRowView)bindingRelItemSalesPack.Current).Row;
                    if (row.IsIsPrimaryNull() || !row.IsPrimary)
                       row.IsPrimary = true;  
                }
            }
            else if (bindingRelItemSalesPack.Count == 0)
            {
                gridPackSize.CancelEdit();
                bindingRelItemSalesPack.CancelEdit();
            }
        }

        // txtLastCostPrice validated event
        private void txtLastCostPrice_Validated(object sender, EventArgs e)
        {
            // changes to last cost price affect calculations and changes done in db,
            // so reflect these changes by refetching data
            bindingItem.ResetCurrentItem();
        }

        // grid row validating event
        private void gridPackSize_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            // do not process column header click
            if (e.RowIndex < 0) return;

            if (gridPackSize.ReadOnly) return;
            if (bindingRelItemSalesPack.Current == null) return;

            DataRowView row = (DataRowView)bindingRelItemSalesPack.Current;
            ItemDataSet.SalesPackRow typedRow = (ItemDataSet.SalesPackRow)row.Row;

            // when validating row, validate certain fields to be non-null values
            if (row["PackType"] != DBNull.Value)
            {
                /// we no longer need to ask user if he/she wants to
                /// cancel or correct row changes, as ESC works now.
                /// Further, if we show a dialogbox in the middle of this event,
                /// the application freezes after closing the dialogbox.
                bool ok = true;
                if (row["SalesPrice"] == DBNull.Value) ok = false;
                else if (row["BCType"] == DBNull.Value) ok = false;
                else if (row["Barcode"] == DBNull.Value) ok = false;
                if (!ok)
                {
                    //if (gridPackSize.CurrentCell.ColumnIndex == colPackType.Index)
                    //{
                    // HACK: some bug freezes the program if
                    // setting the Cancel = true when PackType column is selected.
                    // Can't figure out what is wrong, so if that column is selected,
                    // row changes are cancelled.
                    
                    bindingRelItemSalesPack.CancelEdit();
                    
                    //}
                    //else
                      //  e.Cancel = true;
                }
                else
                {
                    // all values validated ok, copy barcode to barcode table,
                    // the function only copies if new values
                    dsItem.Barcode.SetPrimaryBarcode(
                        typedRow.ItemID,
                        typedRow.PackType,
                        typedRow.BCType,
                        typedRow.Barcode);
                }
            }
        }

        // context sales pack opening event
        private void contextSalesPack_Opening(object sender, CancelEventArgs e)
        {
            // do not allow delete if grid in readonly mode
            if (gridPackSize.ReadOnly)
            {
                e.Cancel = true;
                return;
            }

            // if either semideleted or new, do not allow delete
            if (bindingRelItemSalesPack.Current != null)
            {
                DataRowView row = (DataRowView)bindingRelItemSalesPack.Current;
                if (((row["SemiDeleted"] != DBNull.Value) && bool.Parse(row["SemiDeleted"].ToString()))
                    || row.IsNew)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        // credit category checkbox changed event
        private void chkCreditCategory_CheckedChanged(object sender, EventArgs e)
        {
            // toggle credit category lookup button
            // (skip if checkbox disabled - happens when browsing items)
            if (chkCreditCategory.Enabled)
            {
                btnCreditCategory.Enabled = !chkCreditCategory.Checked;

                // if CreditCategory checked, inherit from subcategory
                if (chkCreditCategory.Checked)
                {
                    LoadSubCategoryData();
                    InheritCreditCategory();
                    bindingItem.ResetCurrentItem();
                }
            }
        }

        // item type code checkbox changed event
        private void chkItemTypeCode_CheckedChanged(object sender, EventArgs e)
        {
            // toggle item type code lookup button
            // (skip if checkbox disabled - happens when browsing items)
            if (chkItemTypeCode.Enabled)
            {
                btnItemTypeCode.Enabled = !chkItemTypeCode.Checked;

                // if ItemTypeCode checked, inherit from subcategory
                if (chkItemTypeCode.Checked)
                {
                    LoadSubCategoryData();
                    InheritItemTypeCode();
                    bindingItem.ResetCurrentItem();
                }
            }
        }

        // age restriction checkbox changed event
        private void chkAgeRestriction_CheckedChanged(object sender, EventArgs e)
        {
            // toggle age restriction textbox
            // (skip if checkbox disabled - happens when browsing items)
            if (chkAgeRestriction.Enabled)
            {
                txtAgeRestriction.ReadOnly = chkAgeRestriction.Checked;

                // if AgeRestriction checked, inherit from subcategory
                if (chkAgeRestriction.Checked)
                {
                    LoadSubCategoryData();
                    InheritAgeRestriction();
                    bindingItem.ResetCurrentItem();
                }
            }
        }

        // mop restriction checkbox changed event
        private void chkMOPRestriction_CheckedChanged(object sender, EventArgs e)
        {
            // toggle mop restriction textbox
            // (skip if checkbox disabled - happens when browsing items)
            if (chkMOPRestriction.Enabled)
            {
                txtMOPRestriction.ReadOnly = chkMOPRestriction.Checked;
                txtMOPRestriction.Increment = (txtMOPRestriction.ReadOnly ? 0 : 1);

                // if MOPRestriction checked, inherit from subcategory
                if (chkMOPRestriction.Checked)
                {
                    LoadSubCategoryData();
                    InheritMOPRestriction();
                    bindingItem.ResetCurrentItem();
                }
            }
        }

        // credit category lookup button click event
        private void btnCreditCategory_Click(object sender, EventArgs e)
        {
            /// Show CreditCategory popup so user can select.
            /// If user selects something, and it is different
            /// from what was selected before, set the CreditCategory
            /// value on the item.
            if (bindingItem.Current != null)
            {
                CreditCategoryPopup lookup = new CreditCategoryPopup();
                ItemDataSet.ItemRow row =
                    (ItemDataSet.ItemRow)((DataRowView)bindingItem.Current).Row;
                // select the current CreditCategory if any
                if (row["CreditCategory"] != DBNull.Value)
                    lookup.SelectedCreditCategoryID = row.CreditCategory;
                if (lookup.ShowDialog(this) == DialogResult.OK)
                {
                    if ((row["CreditCategory"] == DBNull.Value) ||
                        (row.CreditCategory != lookup.SelectedCreditCategoryID))
                    {
                        // user has selected a new CreditCategory, update item
                        row.CreditCategory = lookup.SelectedCreditCategoryID;

                        // reflect the change in GUI
                        bindingItem.ResetCurrentItem();
                    }
                }
            }
        }

        // item type code lookup button click event
        private void btnItemTypeCode_Click(object sender, EventArgs e)
        {
            /// Show ItemTypeCode popup so user can select.
            /// If user selects something, and it is different
            /// from what was selected before, set the ItemTypeCode
            /// value on the item.
            if (bindingItem.Current != null)
            {
                ItemTypeCodePopup lookup = new ItemTypeCodePopup();
                ItemDataSet.ItemRow row =
                    (ItemDataSet.ItemRow)((DataRowView)bindingItem.Current).Row;
                // select the current ItemTypeCode if any
                if (row["ItemTypeCode"] != DBNull.Value)
                    lookup.SelectedItemTypeCodeID = row.ItemTypeCode;
                if (lookup.ShowDialog(this) == DialogResult.OK)
                {
                    if ((row["ItemTypeCode"] == DBNull.Value) ||
                        (row.ItemTypeCode != lookup.SelectedItemTypeCodeID))
                    {
                        // user has selected a new ItemTypeCode, update item
                        row["ItemTypeCode"] = lookup.SelectedItemTypeCodeID;

                        // reflect the change in GUI
                        bindingItem.ResetCurrentItem();
                    }
                }
            }
        }

        // age restriction validating event
        private void txtAgeRestriction_Validating(object sender, CancelEventArgs e)
        {
            /// Validate age restriction to be either 0 or between 1 and 99.
            /// The textbox's databind is setup to format in integer,
            /// so we don't have to call cancel if user enters non-integer value.
            if (!txtAgeRestriction.ReadOnly)
            {
                if (tools.object2int(txtAgeRestriction.Text) < 0)
                    txtAgeRestriction.Text = "0";
                else if (tools.object2int(txtAgeRestriction.Text) > 99)
                    txtAgeRestriction.Text = "99";
            }
        }

        // item name textbox validating event
        private void txtItemName_Validating(object sender, CancelEventArgs e)
        {
            if(newItemMode)
                NewPendingItemSave();
        }

        // supplier grid row enter event
        private void gridSupplierItem_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // get supplier name for current row and write it to txtSupplierName field
            txtSupplierName.Text = "";
            if (e.RowIndex >= 0)
            {
                object val = gridSupplierItem[colSupplierNumber.Index, e.RowIndex].Value;
                txtSupplierName.Text = GetSupplierName(val);
            }
        }
                
        // supplier grid cell validating event 20191121
        private void gridSupplierItem_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (gridSupplierItem.ReadOnly) return;

            // don't validate on an empty value
            if (e.FormattedValue.ToString() == "") return;

            if (e.ColumnIndex == colPackageCost.Index)
            {
                // dissallow PackageCost (K.Kost) field value of 0
                double newValue = tools.object2double(e.FormattedValue);
                if (newValue == 0)
                {
                    MessageBox.Show(db.GetLangString("ItemForm.KolliCostCannotBeZeroOrEmpty"));
                    e.Cancel = true;
                    return;
                }
            }
            else if (e.ColumnIndex == colSupplierNumber.Index)
            {
                // check that supplier number exists
                DataRow supplierRow = dbSupplier.GetSupplier(tools.object2int(e.FormattedValue));
                if (supplierRow == null)
                {
                    MessageBox.Show(db.GetLangString("ItemForm.SupplierDoesNotExist"));
                    e.Cancel = true;
                    return;
                }

                // check that the combination of Supplier Number and Ordering Number
                // is unique for the entire SupplierItem table (is not the key, but must be unique)
                if (bindingRelSupplierItem.Current == null) return;
                DataRowView row = (DataRowView)bindingRelSupplierItem.Current;
                long id = tools.object2long(row["ID"]);
                long newValue = tools.object2long(e.FormattedValue);
                long oldValue = tools.object2long(gridSupplierItem[e.ColumnIndex, e.RowIndex].FormattedValue);
                if (oldValue != newValue)
                {
                    double OrderingNo = tools.object2double(row["OrderingNumber"]);
                    if (!dsItem.SupplierItem.CheckCombinationOfSupplierNoAndOrderingNumberIsUnique(
                        id, newValue, OrderingNo))
                    {
                        MessageBox.Show(dsItem.SupplierItem.LastError);
                        e.Cancel = true;
                        return;
                    }
                }
            }
            else if (e.ColumnIndex == colOrderingNumber.Index)
            {
                // check that the combination of Supplier Number and Ordering Number
                // is unique for the entire SupplierItem table (is not the key, but must be unique)
                if (bindingRelSupplierItem.Current == null) return;
                DataRowView row = (DataRowView)bindingRelSupplierItem.Current;
                long id = tools.object2long(row["ID"]);
                double newValue = tools.object2double(e.FormattedValue);
                double oldValue = tools.object2double(gridSupplierItem[e.ColumnIndex, e.RowIndex].FormattedValue);
                if (oldValue != newValue)
                {
                    long SupplierNo = tools.object2long(row["SupplierNo"]);
                    if (!dsItem.SupplierItem.CheckCombinationOfSupplierNoAndOrderingNumberIsUnique(
                        id, SupplierNo, newValue))
                    {
                        MessageBox.Show(dsItem.SupplierItem.LastError);
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }

        // supplier grid cell begin edit event
        private void gridSupplierItem_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (gridSupplierItem.CurrentCell == null) return;
            if (bindingRelSupplierItem.Current == null) return;
            DataRowView row = (DataRowView)bindingRelSupplierItem.Current;

            if ((e.ColumnIndex == colOrderingNumber.Index) && (row["OrderingNumber"] != DBNull.Value))
            {
                // if entering edit mode on field OrderingNumber with a value, ask user to proceed
                string msg = db.GetLangString("ItemForm.ChangeValueOfOrderingNumber");
                if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
            }
            else if (e.ColumnIndex == colIsPrimarySupplItem.Index)
            {
                // if entering edit mode on field IsPrimary and that
                // field is already true, cancel the edit
                if(gridSupplierItem.CurrentCell.Value.Equals(true))
                    e.Cancel = true;
            }
        }

        // supplier grid cell end edit event
        private void gridSupplierItem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (bindingRelSupplierItem.Current == null) return;
            DataRowView row = (DataRowView)bindingRelSupplierItem.Current;

            /// IMPORTANT: BELOW COMES 3 CALCULATIONS,
            /// AND THEY NEED TO RUN IN THAT ORDER.
            /// ALSO, DO *NOT* INCLUDE THEM IN FURTHER
            /// IF-STATEMENTS AS THEY ALWAYS NEED TO RUN.

#region 1st calculation (has 3 if statements)

            // clear PackageCost and PackageUnitCost
            // when  setting KolliSize
            if (e.ColumnIndex == colKollisize.Index)
            {
                row["PackageCost"] = DBNull.Value;
                row["PackageUnitCost"] = DBNull.Value;
                gridSupplierItem.Refresh();
            }
            // calculate PackageUnitCost when field PackageCost changes
            else if (e.ColumnIndex == colPackageCost.Index)
            {
                // we can calculate the PackageUnitCost when
                // we have values in both KolliSize and PackageCost
                if ((row["KolliSize"] != DBNull.Value) && (row["PackageCost"] != DBNull.Value))
                {
                    //  calculate PackageUnitCost
                    int kolliSize = tools.object2int(row["KolliSize"]);
                    double packageCost = tools.object2double(row["PackageCost"]);
                    if (kolliSize != 0)
                    {
                        double newValue = packageCost / kolliSize;

                        // if we have a new value, assign it to the field
                        double oldValue = tools.object2double(row["PackageUnitCost"]);
                        if (oldValue != newValue)
                        {
                            row["PackageUnitCost"] = newValue;
                            gridSupplierItem.Refresh();
                        }
                    }
                }
                else
                {
                    // one of the fields needed to make the calculation is null,
                    // so null the calculated field.
                    row["PackageUnitCost"] = DBNull.Value;
                }
            }
            else if (e.ColumnIndex == colPackageUnitCost.Index)
            {
                // we can calculate the PackageCost when
                // we have values in both KolliSize and PackageUuitCost
                if ((row["KolliSize"] != DBNull.Value) && (row["PackageUnitCost"] != DBNull.Value))
                {
                    //  calculate PackageCost
                    int kolliSize = tools.object2int(row["KolliSize"]);
                    double packageUnitCost = tools.object2double(row["PackageUnitCost"]);
                    if (kolliSize != 0)
                    {
                        double newValue = packageUnitCost * kolliSize;

                        // if we have a new value, assign it to the field
                        double oldValue = tools.object2double(row["PackageCost"]);
                        if (oldValue != newValue)
                        {
                            row["PackageCost"] = newValue;
                            gridSupplierItem.Refresh();
                        }
                    }
                }
                else
                {
                    // one of the fields needed to make the calculation is null,
                    // so null the calculated field.
                    row["PackageCost"] = DBNull.Value;
                }
            }

#endregion

#region 2nd calculation
            // When updating PackageCost or PackageUnitCost field on primary supplier item
            // or setting IsPrimary field to true on supplier item,
            // copy the value to Item's CostPriceLatest field.
            // A method i the db class will update the Margin field.
            // NOTE: This MUST be done after PackageUnitCost has been calculated.
            if ((e.ColumnIndex == colPackageCost.Index) ||
                (e.ColumnIndex == colPackageUnitCost.Index) ||
                (e.ColumnIndex == colIsPrimarySupplItem.Index))
            {
                if ((bindingItem.Current != null) && tools.object2bool(row["IsPrimary"]))
                {
                    DataRowView itemRow = (DataRowView)bindingItem.Current;
                    double oldPackageCost = tools.object2double(itemRow["CostPriceLatest"]);
                    double newPackageCost = tools.object2double(row["PackageCost"]);
                    if (oldPackageCost != newPackageCost)
                    {
                        itemRow["CostPriceLatest"] = row["PackageUnitCost"]; //peter 20200106
                        txtLastCostPrice.Text = tools.object2double(row["PackageUnitCost"]).ToString("n3"); // reflect in gui
                        // margin is re-calculated in db class, so make sure it is reflected in gui
                        txtMargin.Refresh();
                        txtLastCostPrice.Refresh();
                    }
                }
            }
            else if (e.ColumnIndex == colSupplierNumber.Index)
            {
                // if ending edit on supplier number field, show the supplier name in text box
                //object val = gridSupplierItem[colSupplierNumber.Index, e.RowIndex].Value;
                txtSupplierName.Text = GetSupplierName(row["SupplierNo"]);
            }
#endregion

#region 3rd calculation
            // calculate SellingUnitCost and NoOfSellingUnits when 
            // fields SellingPackType, KolliSize, PackageCost or PackageUnitCost changes.
            // This MUST be done after calculating PackageUnitCost
            //if ((e.ColumnIndex == colSellingPackType.Index) ||
            //    (e.ColumnIndex == colKollisize.Index) ||
            if ((e.ColumnIndex == colKollisize.Index) ||
               (e.ColumnIndex == colPackageCost.Index) ||
                (e.ColumnIndex == colPackageUnitCost.Index))
            {
                // if SellingPackType changed, update the NoOfSellingUnits fields first
               // if (e.ColumnIndex == colSellingPackType.Index)
                {
                    byte packType = tools.object2byte(row["SellingPackType"]);
                    int oldValue = tools.object2int(row["NoOfSellingUnits"]);
                    int newValue = ItemDataSet.LookupPackTypeAmount(packType);
                    if (oldValue != newValue)
                    {
                        row["NoOfSellingUnits"] = newValue;
                        gridSupplierItem.Refresh();
                    }
                }

                // we can calculate the SellingUnitCost (S.U.kost) when
                // we have values in PackageUnitCost and NoOfSellingUnits.
                if ((row["PackageUnitCost"] != DBNull.Value) && (row["NoOfSellingUnits"] != DBNull.Value))
                {
                    // calculate SellingUnitCost
                    double packageUnitCost = tools.object2double(row["PackageUnitCost"]);
                    int noOfSellingUnits = tools.object2int(row["NoOfSellingUnits"]);
                    if (noOfSellingUnits != 0)
                    {
                        double newValue = packageUnitCost / noOfSellingUnits;

                        // if we have a new value, assign it to the field
                        double oldValue = tools.object2double(row["SellingUnitCost"]);
                        if (oldValue != newValue)
                        {
                            row["SellingUnitCost"] = newValue;
                            gridSupplierItem.Refresh();
                        }
                    }
                }
                else
                {
                    // one of the fields needed to make the calculation is null,
                    // so null the calculated field.
                    row["SellingUnitCost"] = DBNull.Value;
                }
            }
#endregion
        }

        // supplier grid row validating event
        private void gridSupplierItem_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (bindingRelSupplierItem.Current == null) return;
            DataRowView row = (DataRowView)bindingRelSupplierItem.Current;
            string test = row["SupplierNo"].ToString();
            //20191122_start
            // check that user has entered needed values
            if ((row["SupplierNo"] == DBNull.Value) ||
                (row["OrderingNumber"] == DBNull.Value) ||
                (row["KolliSize"] == DBNull.Value) ||
                (row["PackageCost"] == DBNull.Value) ||
                (row["PackageUnitCost"] == DBNull.Value)) //20191121
               // (row["SellingPackType"] == DBNull.Value) ||
               // (row["NoOfSellingUnits"] == DBNull.Value) ||
              //  (row["SellingUnitCost"] == DBNull.Value))
            {
                bindingRelSupplierItem.CancelEdit();
                return;

                /// note: do not try to use gridSupplierItem.CancelEdit();
                /// as this won't work. we had a problem that this did
                /// work except in one case; when user selected another
                /// tab while row was not completed. in this case an empty
                /// extra record was inserted instead and the current was
                /// left too, thus there were two invalid records. when debugging
                /// this event was called twice when selecting another tab, while
                /// if just selecting another control, this event was called once.
            }

            // if leaving a row and no other rows has
            // field IsPrimary set to true, set it to true on this row.
            if (!dsItem.SupplierItem.HasAPrimaryRecord())
                row["IsPrimary"] = 1;  //peter20190411
        }

        // supplier grid cell content click event
        private void gridSupplierItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridSupplierItem.ReadOnly) return;

            // when clicking on IsPrimary column, de-select any other records's isprimary checkmarks
            if (e.ColumnIndex == colIsPrimarySupplItem.Index)
            {
                // first remove any other checkmark
                foreach (DataGridViewRow row in gridSupplierItem.Rows)
                {
                    if (tools.object2bool(row.Cells[colIsPrimarySupplItem.Index].Value) == true)
                        row.Cells[colIsPrimarySupplItem.Index].Value = false;
                }

                // set selected cells checkmark to true
                gridSupplierItem[e.ColumnIndex, e.RowIndex].Value = true;
            }
            else if (e.ColumnIndex == colSupplierNumberButton.Index)
            {
                SearchSupplier();

                // do NOT call gridSupplierItem.EndEdit() here
                // as it spoils the possibility of checking if
                // a value has changed. instead focus the next cell.

                // check that the combination of Supplier Number and Ordering Number
                // is unique for the entire SupplierItem table (is not the key, but must be unique)
                if (bindingRelSupplierItem.Current == null) return;
                DataRowView row = (DataRowView)bindingRelSupplierItem.Current;
                long id = tools.object2long(row["ID"]);
                int SupplierNo = tools.object2int(row["SupplierNo"]);
                double OrderingNo = tools.object2double(row["OrderingNumber"]);
                if (!dsItem.SupplierItem.CheckCombinationOfSupplierNoAndOrderingNumberIsUnique(
                    id, SupplierNo, OrderingNo))
                {
                    MessageBox.Show(dsItem.SupplierItem.LastError);
                    row["SupplierNo"] = DBNull.Value;
                    gridSupplierItem.Refresh();
                }
            }
        }

        // supplier grid rows added event
        private void gridSupplierItem_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (bindingRelSupplierItem.Current == null) return;
            DataRowView row = (DataRowView)bindingRelSupplierItem.Current;

            // when adding the first supplier item row, set the IsPrimary checkmark
            if (dsItem.SupplierItem.Rows.Count <= 0)
            {
                row["IsPrimary"] = true;
                gridSupplierItem.Refresh();
            }
        }

        // supplier user deleting row event
        private void gridSupplierItem_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // do not allow deleting a supplier item
            // if grid is in readonly mode
            if (gridSupplierItem.ReadOnly)
                e.Cancel = true;
            else
            {
#if FSD
                /// if FSD, before deleting, copy the SupplierItem record on disk
                /// to the FSDDeletedSupplierItem table
                if (e.Row.DataBoundItem != null)
                {
                    DataRow row = (e.Row.DataBoundItem as DataRowView).Row;
                    ItemDataSet.FSDDeletedSupplierItemDataTable.CopySupplierItem_To_FSDDeletedSupplierItem(row);
                }
#endif
            }
        }

        // grid cell click event (note: this is not the CellContentClick event)
        private void gridPackSize_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /// If user clicks the salespack CalcNumBarcodes column,
            /// make sure it is readonly. The grid's ReadOnly property
            /// is set continually during use, thus causing each cell's
            /// ReadOnly to be modified too, so we have to manually make
            /// sure this column is readonly all the time.
            if (e.ColumnIndex == colCalcNumBarcodes.Index)
            {
                gridPackSize.CurrentRow.Cells[colCalcNumBarcodes.Index].ReadOnly = true;
            }

        }

        private void gridPackSize_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            ImageButtonRender.OnCellPainting(e, colBarcodeButton.Index, ImageButtonRender.Images.Barcode);
            ImageButtonRender.OnCellPainting(e, colBtnSalesPackDetailsForm.Index, ImageButtonRender.Images.DetailForm);
        }

        private void ItemForm_KeyDown(object sender, KeyEventArgs e)
        {
            tools.EnterAsTab(e);
        }

        private void gridSupplierItem_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            ImageButtonRender.OnCellPainting(e, colSupplierNumberButton.Index, ImageButtonRender.Images.LookupForm);
        }

        private void txtFSD_ID_Validating(object sender, CancelEventArgs e)
        {
            // validation prevents us from emptying the field,
            // so if user does that, we write a 0 and in the underlying
            // database-class code we convert any 0 on this field to DBNull.Value.
            if (txtFSD_ID.Text.Length <= 0)
                txtFSD_ID.Text = "0";
            else
            {
                // when entering a FSD_ID, check that is does not already exist on other items.
                if (bindingItem.Current == null) return;
                int ItemID = tools.object2int((bindingItem.Current as DataRowView).Row["ItemID"]);
                int FSD_ID = tools.object2int(txtFSD_ID.Text);
                string msg = ItemDataSet.ItemDataTable.FSD_ID_AlreadyInUseOnOtherItem(ItemID, FSD_ID);
                if (msg != "")
                {
                    MessageBox.Show("Den FSD ID bliver allerede brugt på vare: " + msg);
                    e.Cancel = true;
                }
            }
        }

        private void txtKampagneID_Validating(object sender, CancelEventArgs e)
        {
            // validation prevents us from emptying the field,
            // so if user does that, we write a 0 and in the underlying
            // database-class code we convert any 0 on this field to DBNull.Value.
            if (txtKampagneID.Text.Length <= 0)
                txtKampagneID.Text = "0";
        }

        private void btnSearchItemID_Click(object sender, EventArgs e)
        {
            SearchItemID frm = new SearchItemID(SearchType.ItemID);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.FoundItemID > 0)
                {
                    // only one item, so position on it
                    int idx = 0;
                    foreach (int ItemID in bindingFilterList)
                    {
                        if (ItemID == frm.FoundItemID)
                        {
                            bindingFilterList.Position = idx;
                            return;
                        }
                        ++idx;
                    }
                }
                MessageBox.Show(db.GetLangString("ItemForm.Dialog.ItemIDNotFound"));
            }
        }

        private void btnSearchFSD_ID_Click(object sender, EventArgs e)
        {
            SearchItemID frm = new SearchItemID(SearchType.FSD_ID);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.FoundItemIDs != null)
                {
                    if (frm.FoundItemIDs.Count > 1)
                    {
                        // if multiple items found with the same FSD_ID
                        bindingFilterList.DataSource = frm.FoundItemIDs;
                        btnRemoveFilter.Enabled = true;
                        bindingFilterList.Position = 0;
                        return;
                    }
                    else
                    {
                        // only one item, so position on it
                        int idx = 0;
                        int FoundItemID = frm.FoundItemIDs[0];
                        foreach (int ItemID in bindingFilterList)
                        {
                            if (ItemID == FoundItemID)
                            {
                                bindingFilterList.Position = idx;
                                return;
                            }
                            ++idx;
                        }
                    }
                }
                MessageBox.Show(db.GetLangString("ItemForm.Dialog.FSD_IDNotFound"));
            }
        }

        private void btnSearchKampagneID_Click(object sender, EventArgs e)
        {
            SearchItemID frm = new SearchItemID(SearchType.KampagneID);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.FoundItemIDs != null)
                {
                    if (frm.FoundItemIDs.Count > 1)
                    {
                        // if multiple items found with the same KampagneID
                        bindingFilterList.DataSource = frm.FoundItemIDs;
                        btnRemoveFilter.Enabled = true;
                        bindingFilterList.Position = 0;
                        return;
                    }
                    else
                    {
                        // only one item, so position on it
                        int idx = 0;
                        int FoundItemID = frm.FoundItemIDs[0];
                        foreach (int ItemID in bindingFilterList)
                        {
                            if (ItemID == FoundItemID)
                            {
                                bindingFilterList.Position = idx;
                                return;
                            }
                            ++idx;
                        }
                    }
                }
                MessageBox.Show(db.GetLangString("ItemForm.Dialog.KampagneIDNotFound"));
            }
        }

   

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            //MessageBox.Show(tabControl1.SelectedIndex.ToString());
            //3 = vareposter
            TabIndex = tabControl1.SelectedIndex;
            if (TabIndex == 3)
            {
                int TmpItemID = int.Parse(bindingFilterList.Current.ToString());
                adapterRelTransac.Fill(dsItem.ItemTransaction, TmpItemID);
            }
        }

        private void txtKampagneID_Enter(object sender, EventArgs e)
        {
            if (!txtKampagneID.ReadOnly)
            {
                if (txtKampagneID.Text.Length > 0)
                {
                    var confirmResult = MessageBox.Show("Vil du slette KampangeID på denne vare", "", MessageBoxButtons.YesNo);  //pn20220705
                    if (confirmResult == DialogResult.Yes)
                    {
                        txtKampagneID.Text = "0";
                    }
                }
            }
        }
    }
}