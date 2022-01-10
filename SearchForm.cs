using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace RBOS
{
    public partial class SearchForm : Form
    {
        #region Private variables

        // private variables
        private List<int> itemList = null;
        private bool closedWithFilter = false;
        private int selectedItemID = -1;
        private string selectedItemName = "";
        private byte selectedPackType = 0;
        private double selectedBarcode = 0;
        private string txtSubCategoryID = "";
        private bool onlyDisplayContainerDeposits = false;
        private bool _UseInactiveItems = false;

        #endregion

        #region Constructor

        /// <summary>
        /// SearchForm constructor
        /// </summary>

        public SearchForm() : this(false)
        {            
        }

        public SearchForm(bool UseInactiveItems)
        {
            InitializeComponent();

            _UseInactiveItems = UseInactiveItems;

            // set grid column order
            int index = 0;
            colBarcode.DisplayIndex = index++;
            colItemName.DisplayIndex = index++;
            colOrderingNumber.DisplayIndex = index++;
            colSubCategory.DisplayIndex = index++;

            // by default, the forms DialogResult is Cancel
            this.DialogResult = DialogResult.Cancel;

            // load ItemSearch data from database
            adapterItemSearch.Connection = db.Connection;
            //search_Inactive_ItemsTableAdapter.Connection = db.Connection;
            //search_Inactive_ItemsTableAdapter.;

            if (!_UseInactiveItems)
                adapterItemSearch.Fill(dsItem.ItemSearch);
            else                
                //search_Inactive_ItemsTableAdapter.Fill(dsInactiveItems.Search_Inactive_Items);
                 adapterItemSearch.FillInactive(dsItem.ItemSearch); //pn20210212

            // show amount of rows out of total
            UpdateAmountLabel(); 
        }

        #endregion

        #region ItemList property
        /// <summary>
        /// The list of items selected, sorted and without dublets.
        /// If the IsListFiltered is true, this list is a subset of
        /// all Items in the database. If IsListFiltered is false,
        /// this list is all Items in the database. If this value is null,
        /// it means nothing has been selected, which only can happen
        /// if no Items exist in the database.
        /// </summary>
        public List<int> ItemList
        {
            get
            {
                // initialize itemList first time
                if (itemList == null)
                    itemList = new List<int>();

                // build returned ItemList distinguishing 
                // between a filtered list or the full list
                if (!closedWithFilter)
                {
                    // build the full ItemID list
                    foreach (ItemDataSet.ItemSearchRow row in dsItem.ItemSearch.Rows)
                    {
                                              
                        if ((row.RowState != DataRowState.Deleted) &&
                            (row.RowState != DataRowState.Detached))                   
                            if (!itemList.Contains(row.ItemID))                            
                                itemList.Add(row.ItemID);
                    }
                }
                else
                {
                    // build the filtered ItemID list
                    bindingItemSearch.SuspendBinding();
                    foreach (DataRowView row in bindingItemSearch)
                        if (!itemList.Contains(int.Parse(row["ItemID"].ToString())))      
                            itemList.Add(int.Parse(row["ItemID"].ToString()));
                    bindingItemSearch.ResumeBinding();
                }

                // remove dublets in itemList //20181010 erstattet af contains
                //if ((itemList != null) && (itemList.Count > 0))
                //{
                //    itemList.Sort();
                //    int prev = -1;
                //    int i = 0;
                //    while (i < itemList.Count)
                //    {
                //        if (itemList[i] == prev)
                //            itemList.RemoveAt(i);
                //        else
                //        {
                //            prev = itemList[i];
                //            ++i;
                //        }
                //    }
                //}

                // return list of ItemIDs (filtered or not)
                return itemList;
            }
        }
        #endregion

        #region ClosedWithFilter property
        /// <summary>
        /// Get or set a flag telling if the ItemList returned will be filtered.
        /// If ItemList is not filtered, it will contain all ItemIDs from the database.
        /// If it is filtered, it will contain the ItemIDs that were present when searching.
        /// </summary>
        public bool ClosedWithFilter
        {
            get { return closedWithFilter; }
        }
        #endregion

        #region SelectedItemListIndex property
        /// <summary>
        /// Index of the selected item in ItemList. -1 means nothing selected.
        /// </summary>
        public int SelectedItemListIndex
        {
            get
            {
                if (SelectedItemID == -1) return -1;
                for(int i=0; i<itemList.Count; i++)
                {
                    if (itemList[i] == SelectedItemID)
                        return i;
                }
                return -1;
            }
        }
        #endregion

        #region SelectedItemID property
        /// <summary>
        /// ItemID of the item selected in ItemList.
        /// If ItemList is null, this value is -1.
        /// </summary>
        public int SelectedItemID
        {
            get { return selectedItemID; }
            set
            {
                // attempt to select the row with the ItemID
                int index = bindingItemSearch.Find("ItemID", value);
                if (index >= 0)
                {
                    bindingItemSearch.Position = index;
                    selectedItemID = value;
                }
                
            }
        }
        #endregion

        #region SelectedItemName property
        /// <summary>
        /// ItemName of the item selected.
        /// If no item selected, this value is "".
        /// </summary>
        public string SelectedItemName
        {
            get
            {
                // using tools.object2string to make sure
                // null or DBNull is not returned but "" instead
                // if either of those values are present in the variable
                return tools.object2string(selectedItemName);
            }
        }
        #endregion

        #region SelectedPackType property
        public byte SelectedPackType
        {
            get { return selectedPackType; }
        }
        #endregion

        #region SelectedBarcode property
        public double SelectedBarcode
        {
            get { return selectedBarcode; }
            set
            {
                // attempt to find the row with the given barcode.
                int index = bindingItemSearch.Find("Barcode", value);
                if (index >= 0)
                {
                    bindingItemSearch.Position = index;
                    selectedBarcode = value;
                }
            }
        }
        #endregion

        #region DisplaySelectWithFilterButton property
        public bool DisplaySelectWithFilterButton
        {
            set { btnOkFilter.Visible = value; }
        }
        #endregion

        #region OnlyDisplayContainerDeposits property
        public bool OnlyDisplayContainerDeposits
        {
            set
            {
                onlyDisplayContainerDeposits = value;
                PerformFiltering();
            }
            get
            {
                return onlyDisplayContainerDeposits;
            }
        }
        #endregion

        #region GetCurrentlySelectedAndClose method
        /// <summary>
        /// Internal helper method to get the selected ItemID from the binding source.
        /// </summary>
        private void GetCurrentlySelectedAndClose()
        {
            // attempt to get selected item from selected grid row
            DataRowView row = (DataRowView)bindingItemSearch.Current;
            if (row != null)
            {
                selectedItemID = int.Parse(row["ItemID"].ToString());
                selectedItemName = row["ItemName"].ToString();                
                selectedPackType = byte.Parse(row["PackType"].ToString());
                selectedBarcode = double.Parse(row["Barcode"].ToString());
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        #region PerformFiltering method
        /// <summary>
        /// Performs the filtering based on values entered in txtItemName and txtSubCategoryID (variable).
        /// txtBarcode will select the specific item and close the form by itself, so it
        /// is not part of the filtering
        /// </summary>
        private void PerformFiltering()
        {
            string filterItemName = "";
            string filterSubCategory = "";
            string filterOrderingNumber = "";

            // build filter
            if (txtItemName.Text != "")
                filterItemName = string.Format(" (ItemName like '%{0}%') ", txtItemName.Text.Replace("'", ""));
            if (txtSubCategoryID != "")
                filterSubCategory = string.Format(" (SubCategory = '{0}') ", txtSubCategoryID);
            if (txtOrderingNumber.Text != "")
                filterOrderingNumber = CreateOrderingNumberFilter();

            // apply itemname filter
            bindingItemSearch.Filter = filterItemName;
            // apply subcategory filter
            if ((bindingItemSearch.Filter != "") && (filterSubCategory != ""))
                bindingItemSearch.Filter += " AND " + filterSubCategory;
            else
                bindingItemSearch.Filter += filterSubCategory;
            // apply orderingnumber filter
            if ((bindingItemSearch.Filter != "") && (filterOrderingNumber != ""))
                bindingItemSearch.Filter += " AND " + filterOrderingNumber;
            else
                bindingItemSearch.Filter += filterOrderingNumber;

            // apply ItemTypeCode filter (15 = container deposits)
            if (onlyDisplayContainerDeposits)
            {
                string tmp = " (ItemTypeCode = 15) ";
                if (bindingItemSearch.Filter != "")
                    bindingItemSearch.Filter += " AND " + tmp;
                else
                    bindingItemSearch.Filter += tmp;
            }

            // toggle btnOkFilter enabled, so if view is filtered and has records,
            // enabled the button, otherwise disable it
            btnOkFilter.Enabled = 
                ((bindingItemSearch.Count > 0) && 
                (bindingItemSearch.Count != dsItem.ItemSearch.DefaultView.Count));

            // if filter has removed all records, disable btnOk
            btnOk.Enabled = (bindingItemSearch.Count > 0);

            // show amount of rows out of total
            UpdateAmountLabel();

            // if only one item is filtered out, select it and close
            if (bindingItemSearch.Count == 1)
            {
                this.closedWithFilter = false;
                GetCurrentlySelectedAndClose();
            }
        }
        #endregion

        #region UpdateAmountLabel method
        /// <summary>
        /// Updates the amount label with number of visible rows out of total
        /// </summary>
        private void UpdateAmountLabel()
        {
            lbAmount.Text = string.Format(db.GetLangString("SearchForm.AmountLabel"),
                bindingItemSearch.Count,
                dsItem.ItemSearch.DefaultView.Count);
        }
        #endregion

        #region CreateOrderingNumberFilter method
        private string CreateOrderingNumberFilter()
        {
            // check that orderingnumber is a sequence of numbers only
            Regex regex = new Regex("^([0-9]*)$");
            if (!regex.IsMatch(txtOrderingNumber.Text))
            {
                MessageBox.Show(db.GetLangString("SearchForm.OrderingNumberOnlyNumbers"));
                if (txtOrderingNumber.CanFocus)
                    txtOrderingNumber.Focus();
                return "";
            }

            // check that a value has been entered
            if (txtOrderingNumber.Text == "") return "";

            // perform search based on orderingnumber entered
            double OrderingNumber = tools.object2double(txtOrderingNumber.Text);
            List<int> items;
            if (!_UseInactiveItems)
                items = ItemDataSet.SupplierItemDataTable.SearchItemsWithOrderingNumber(OrderingNumber);
            else
                items = ItemDataSet.InactiveSupplierItemDataTable.SearchItemsWithOrderingNumber(OrderingNumber);
            if (items.Count > 0)
            {
                // build sql in clause
                string sql = "";
                foreach (int ItemID in items)
                {
                    if (sql != "")
                        sql += ", ";
                    sql += ItemID.ToString();
                }
                sql = " (ItemID in ( " + sql + " )) ";

                return sql;
            }
            else
            {
                return " (ItemID = -1) "; // filter out items
            }
        }
        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.closedWithFilter = false;
            GetCurrentlySelectedAndClose();
        }

        private void btnOkFilter_Click(object sender, EventArgs e)
        {
            this.closedWithFilter = true;
            GetCurrentlySelectedAndClose();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.closedWithFilter = false;
            GetCurrentlySelectedAndClose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close(); // by default, the form's DialogResult is Cancel
        }

        private void txtBarcode_Leave(object sender, EventArgs e)
        {
            // check that barcode is a sequence of numbers only
            Regex regex = new Regex("^([0-9]*)$");
            if (!regex.Match(txtBarcode.Text).Success)
            {
                MessageBox.Show(db.GetLangString("SearchForm.EnterOnlyBarcodeWithNumbers"));
                if (txtBarcode.CanFocus)
                    txtBarcode.Focus();
                return;
            }

            // perform filtering based on barcode entered
            if (txtBarcode.Text == "") return;
            DataRow[] rows = dsItem.ItemSearch.Select(string.Format("Barcode = {0}", txtBarcode.Text));
            if (rows.Length > 0)
            {
                // barcode found, so select the item and close the form
                // as if user had clicked on select button (without filter)
                // as by design when an exact barcode match is found
                selectedItemID = int.Parse(rows[0]["ItemID"].ToString());
                selectedItemName = rows[0]["ItemName"].ToString();
                selectedPackType = byte.Parse(rows[0]["PackType"].ToString());
                selectedBarcode = double.Parse(rows[0]["Barcode"].ToString());
                closedWithFilter = false;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                // barcode not found so show message and focus barcode field
                MessageBox.Show(db.GetLangString("SearchForm.BarcodeNotFoundInDB"));
                if (txtBarcode.CanFocus)
                    txtBarcode.Focus();
            }
        }

        private void txtItemName_Leave(object sender, EventArgs e)
        {

            PerformFiltering();
        }

        private void txtSubCategory_Leave(object sender, EventArgs e)
        {
            PerformFiltering();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
       
            // localization
            this.Text = db.GetLangString("SearchForm.Title");
            lbBarcode.Text = db.GetLangString("SearchForm.BarcodeLabel");
            lbItemName.Text = db.GetLangString("SearchForm.ItemNameLabel");
            lbSubCategory.Text = db.GetLangString("SearchForm.SubCategory");
            btnOkFilter.Text = db.GetLangString("SearchForm.OKFilterBtn");
            btnOk.Text = db.GetLangString("Application.Ok");
            btnCancel.Text = db.GetLangString("Application.Cancel");
            lbOrderingNumber.Text = db.GetLangString("SearchForm.lbOrderingNumber");
        }

        private void btnLookupSubCategory_Click(object sender, EventArgs e)
        {
            // show subcategory popup
            SubCategoryPopup subcat = new SubCategoryPopup();
            subcat.DisplaySelectNoneButton = true;
            subcat.SelectedSubCategoryID = txtSubCategoryID;
            if (subcat.ShowDialog() == DialogResult.OK)
            {
                // setup and perform filtering
                if (subcat.SelectedSubCategoryID != "")
                {
                    txtSubCategoryID = subcat.SelectedSubCategoryID;
                    txtSubCategory.Text = subcat.SelectedSubCategoryDesc;
                }
                else
                {
                    txtSubCategoryID = "";
                    txtSubCategory.Text = "";
                }
                PerformFiltering();
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            tools.EnterAsTab(e);
        }

        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            tools.EnterAsTab(e);
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.closedWithFilter = false;
                GetCurrentlySelectedAndClose();
            }
        }

        private void txtOrderingNumber_Leave(object sender, EventArgs e)
        {
            PerformFiltering();
        }

        private void txtOrderingNumber_KeyDown(object sender, KeyEventArgs e)
        {
            tools.EnterAsTab(e);
        }
    }
}