using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class SupplierItemSearchForm : Form
    {
        #region Private variables

        private double selectedOrderingNumber = -1;
        private int selectedSupplierID = -1;
        private string selectedSubCatID = "";

        #endregion

        #region Constructor
        public SupplierItemSearchForm()
        {
            InitializeComponent();

            // set connection
            adapterSupplierItemSearch.Connection = db.Connection;

            // load data
            adapterSupplierItemSearch.Fill(dsItem.SupplierItemSearch);

            // default DialogResult is Cancel
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion

        #region Property: SelectedOrderingNumber
        /// <summary>
        /// Gets or sets the selected ordering number.
        /// </summary>
        public double SelectedOrderingNumber
        {
            get { return selectedOrderingNumber; }
            set
            {
                selectedOrderingNumber = value;

                // attempt to find the OrderingNumber and position on that row
                int index = bindingSupplierItemSearch.Find("OrderingNumber", selectedOrderingNumber);
                if((index >= 0) && (index < bindingSupplierItemSearch.Count))
                    bindingSupplierItemSearch.Position = index;
            }
        }
        #endregion

        #region Property: SelectedSupplierID
        /// <summary>
        /// Gets or sets the selected supplier ID.
        /// </summary>
        public int SelectedSupplierID
        {
            get { return selectedSupplierID; }
            set
            {
                selectedSupplierID = value;

                // preselect SupplierID
                txtSupplierID.Text = selectedSupplierID.ToString();

                // lookup SupplierName and preselect it
                DataRow supplier = dbSupplier.GetSupplier(selectedSupplierID);
                if (supplier != null)
                    txtSupplierName.Text = supplier["Description"].ToString();

                // apply search filter
                ApplySearchFilter();
            }
        }
        #endregion

        #region Property: LockSupplier
        /// <summary>
        /// Locks/unlocks the controls that allows searching a supplier.
        /// Locking is usually done in conjunction to preselecting a supplier
        /// with a call to SelectedSupplierID.
        /// </summary>
        public bool LockSupplier
        {
            set
            {
                txtSupplierID.ReadOnly = value;
                btnLookupSupplier.Enabled = !value;
                txtSupplierID.TabStop = !value;
                btnLookupSupplier.TabStop = !value;
            }
        }
        #endregion

        #region Method: ApplySearchFilter
        /// <summary>
        /// Performs searching based on the filter user entered.
        /// </summary>
        private void ApplySearchFilter()
        {
            string filter = "";
            
            // apply SupplierID search (exact match)
            if (txtSupplierID.Text != "")
            {
                if (filter != "") filter += " AND ";
                filter += string.Format(" (SupplierID = {0}) ", txtSupplierID.Text);
            }

            // apply OrderingNumber search (exact match)
            if (txtOrderingNumber.Text != "")
            {
                if (filter != "") filter += " AND ";
                filter += string.Format(" (OrderingNumber = {0}) ", txtOrderingNumber.Text);
            }

            // apply ReceiptText search (like match)
            if (txtReceiptText.Text != "")
            {
                txtReceiptText.Text = txtReceiptText.Text.Replace("'", "\""); // replace illigal chars
                if (filter != "") filter += " AND ";
                filter += string.Format(" (ReceiptText LIKE '%{0}%') ", txtReceiptText.Text);
            }

            // apply SubCategory search (exact match)
            if (selectedSubCatID != "")
            {
                if (filter != "") filter += " AND ";
                filter += string.Format(" (SubCategory = {0}) ", selectedSubCatID);
            }

            bindingSupplierItemSearch.Filter = filter;
        }
        #endregion

        #region Method: SelectAndClose
        /// <summary>
        /// Sets the selected... variables and closes the form.
        /// </summary>
        private void SelectAndClose()
        {
            if (bindingSupplierItemSearch.Current != null)
            {
                DataRowView row = (DataRowView)bindingSupplierItemSearch.Current;
                selectedOrderingNumber = tools.object2double(row["OrderingNumber"]);
                selectedSupplierID = tools.object2int(row["SupplierID"]);
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        // select button click event
        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectAndClose();
        }

        // cancel button click event
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // lookup supplier button click event
        private void btnLookupSupplier_Click(object sender, EventArgs e)
        {
            SupplierPopup suppliers = new SupplierPopup();
            suppliers.SelectedSupplierID = tools.object2int(txtSupplierID.Text);
            if (suppliers.ShowDialog() == DialogResult.OK)
            {
                txtSupplierID.Text = suppliers.SelectedSupplierID.ToString();
                txtSupplierName.Text = suppliers.SelectedSupplierDescription;
                ApplySearchFilter();
            }
        }

        // supplierid text box leave event
        private void txtSupplierID_Leave(object sender, EventArgs e)
        {
            if (!txtSupplierID.ReadOnly)
                ApplySearchFilter();
        }

        // form load event
        private void SupplierItemSearchForm_Load(object sender, EventArgs e)
        {
            // if supplier is preselected, it is readonly,
            // so set focus on ReceiptText text field
            if(txtSupplierID.ReadOnly && txtReceiptText.CanFocus)
                txtReceiptText.Focus();

            // Localization
            this.Text = db.GetLangString("SupplSearchForm.HeaderString");
            lbSupplierID.Text = db.GetLangString("SupplSearchForm.SupplierIDLabel");
            lbSupplierName.Text = db.GetLangString("SupplSearchForm.SupplierNameLabel");
            lbReceiptText.Text = db.GetLangString("SupplSearchForm.ItemNameLabel");
            lbSubCategory.Text = db.GetLangString("SupplSearchForm.CategoryLabel");
            lbOrderingNumber.Text = db.GetLangString("SupplierItemSearchForm.lbOrderingNumber");
            btnCancel.Text = db.GetLangString("Application.Cancel");
            btnSelect.Text = db.GetLangString("Application.Select");

            colSupplierID.HeaderText = db.GetLangString("SupplSearchForm.SupplierIDLabel");
            colOrderingNumber.HeaderText = db.GetLangString("SupplSearchForm.OrderingNoLabel");
            colReceiptText.HeaderText = db.GetLangString("SupplSearchForm.ItemNameLabel");
            colKolliSize.HeaderText = db.GetLangString("SupplSearchForm.KolliSizeLabel");
            colSalesPack.HeaderText = db.GetLangString("SupplSearchForm.SalesPackLabel");
            colPackageCost.HeaderText = db.GetLangString("SupplSearchForm.KolliCostLabel");
            colSubCategory.HeaderText = db.GetLangString("SupplSearchForm.CategoryLabel");



        }

        // grid key down event
        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectAndClose();
        }

        // grid mouse double click event
        private void grid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectAndClose();
        }

        // receipttext text box leave event
        private void txtReceiptText_Leave(object sender, EventArgs e)
        {
            ApplySearchFilter();
        }

        // supplierid text box keydown event
        private void txtSupplierID_KeyDown(object sender, KeyEventArgs e)
        {
            tools.EnterAsTab(e);
        }

        // reciepttext text box keydown event
        private void txtReceiptText_KeyDown(object sender, KeyEventArgs e)
        {
            tools.EnterAsTab(e);
        }

        // subcategory lookup button click event
        private void btnLookupSubCategory_Click(object sender, EventArgs e)
        {
            SubCategoryPopup subcat = new SubCategoryPopup();
            subcat.SelectedSubCategoryID = selectedSubCatID;
            subcat.DisplaySelectNoneButton = true;
            if (subcat.ShowDialog() == DialogResult.OK)
            {
                selectedSubCatID = subcat.SelectedSubCategoryID;
                txtSubCategory.Text = subcat.SelectedSubCategoryDesc;
                ApplySearchFilter();
            }
        }

        private void txtOrderingNumber_KeyDown(object sender, KeyEventArgs e)
        {
            tools.EnterAsTab(e);
        }

        private void txtOrderingNumber_Leave(object sender, EventArgs e)
        {
            ApplySearchFilter();
        }
    }
}