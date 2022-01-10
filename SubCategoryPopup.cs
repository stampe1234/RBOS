using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class SubCategoryPopup : Form
    {
        private string selectedSubCategoryID = "";
        private bool _AllowTypeCode15 = true;

        // constructor
        public SubCategoryPopup()
        {
            InitializeComponent();

            // default dialogresult to cancel
            this.DialogResult = DialogResult.Cancel;

            // set column order (bug in vs2005)
            colSubCategoryID.DisplayIndex = 0;
            colDescription.DisplayIndex = 1;
        }

        /// <summary>
        /// Returns the selected SubCategoryID string.
        /// Null is returned if nothing selected or cancel clicked.
        /// </summary>
        public string SelectedSubCategoryID
        {
            get { return selectedSubCategoryID; }
            set
            {
                // attempt to find the subcategory
                selectedSubCategoryID = "";
                if ((value == null) || (value == "")) return;
                int index = bindingSubCategory.Find("SubCategoryID", value);
                if ((index >= 0) && (index < bindingSubCategory.Count))
                {
                    bindingSubCategory.Position = index;
                    selectedSubCategoryID = value;
                }
            }
        }

        /// <summary>
        /// Returns the selected SubCategoryDesc string.
        /// Null is returned if nothing selected or cancel clicked.
        /// </summary>
        public string SelectedSubCategoryDesc
        {
            get
            {
                if (selectedSubCategoryID != "")
                {
                    int index = bindingSubCategory.Find("SubCategoryID", selectedSubCategoryID);
                    if ((index >= 0) && (index < bindingSubCategory.Count))
                        return ((DataRowView)bindingSubCategory[index])["Description"].ToString();
                }
                return null;
            }
        }

        /// <summary>
        /// Toggles visibility of Select None button. Default visibility is false/hidden.
        /// </summary>
        public bool DisplaySelectNoneButton
        {
            set { btnSelectNone.Visible = value; }
        }

        public bool AllowTypeCode15
        {
            /// This is a quick and dirty fix so we can set whether ItemTypeCode 15 is displayed or not.
            /// Normally we would have put this in the query, but we lack the time to do it and 
            /// there are not too many records with typecode 15 anyway. Besides, this dialog is
            /// used a lot of places, where itemtypecode is not relevant.
            set { _AllowTypeCode15 = value; }
        }

        /// <summary>
        /// By default the grid is sorted by subcategory description.
        /// Calling this method causes the grid to be sorted by subcategory id.
        /// NOTE: It is very important to call this method BEFORE
        /// setting the property SelectedSubCategoryID,
        /// as otherwise a wrong record is selected.
        /// </summary>
        public void OrderBySubCategoryID()
        {
            dataGridView1.Sort(colSubCategoryID, ListSortDirection.Ascending);
        }

        /// <summary>
        /// Closes the form and returns the selected
        /// subcategory by putting it in a property
        /// </summary>
        private void CloseAndReturn()
        {
            // get the selected SubCategoryID
            if (bindingSubCategory.Current != null)
            {
                DataRowView row = (DataRowView)bindingSubCategory.Current;
                selectedSubCategoryID = row["SubCategoryID"].ToString();
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }

        // form load event
        private void SubCategoryPopup_Load(object sender, EventArgs e)
        {
            this.Text = db.GetLangString("CatLookupForm.Header");
            btnSelectNone.Text = db.GetLangString("CatLookupForm.SelectNoneBtn");
            btnOk.Text = db.GetLangString("Application.Ok");
            btnCancel.Text = db.GetLangString("Application.Cancel");
            colSubCategoryID.HeaderText = db.GetLangString("CatLookupForm.colSubCategoryID");
            colDescription.HeaderText = db.GetLangString("CatLookupForm.colDescription");

            // fill SubCategoryPopupView with data
            adapterSubCategory.Connection = db.Connection;
            if (_AllowTypeCode15)
                adapterSubCategory.Fill(dsItem.LookupSubCategory);
            else
                adapterSubCategory.FillWithoutItemTypeCode15(dsItem.LookupSubCategory);
        }

        // grid mouse double click event
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CloseAndReturn();
        }

        // ok button click event
        private void btnOk_Click(object sender, EventArgs e)
        {
            CloseAndReturn();
        }

        // cancel button click event
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // btnSelectNone click event
        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            SelectedSubCategoryID = "";
            this.DialogResult = DialogResult.OK;
            Close();
        }

        // grid key down
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CloseAndReturn();
        }
    }
}