using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class BHHTWSDetail : Form
    {
        #region Private variables

        private int WSID = -1;

        #endregion

        #region Constructor
        public BHHTWSDetail(int WSID)
        {
            InitializeComponent();

            this.DialogResult = DialogResult.Cancel;
            this.WSID = WSID;
            LoadData();

            // position catlist grid columns
            int index = 0;
            colSubCategoryID.DisplayIndex = index++;
            colSelectSubCategory.DisplayIndex = index++;
            colSubCategoryDescription.DisplayIndex = index++;

            // position itemlist grid columns
            index = 0;
            colItemID.DisplayIndex = index++;
            colSelectItem.DisplayIndex = index++;
            colItemName.DisplayIndex = index++;

            // localization
            this.Text = db.GetLangString("BHHTWSDetail.Title");
            btnCancel.Text = db.GetLangString("Application.Cancel");
            btnSaveClose.Text = db.GetLangString("Application.SaveClose");
            lbWSName.Text = db.GetLangString("BHHTWSDetail.WSName");
            lbType.Text = db.GetLangString("BHHTWSDetail.Type");
            lbIncludeCode.Text = db.GetLangString("BHHTWSDetail.IncludeCode");
            colItemName.HeaderText = db.GetLangString("BHHTWSDetail.ColItemName");
            colItemID.HeaderText = db.GetLangString("BHHTWSDetail.ColItemID");
            colSubCategoryDescription.HeaderText = db.GetLangString("BHHTWSDetail.ColSubCategoryDescription");
            colSubCategoryID.HeaderText = db.GetLangString("BHHTWSDetail.ColSubCategoryID");
            deleteToolStripMenuItem.Text = db.GetLangString("Application.Delete");
        }
        #endregion

        #region LoadData
        /// <summary>
        /// Loads data for detail tables and comboboxes.
        /// </summary>
        private void LoadData()
        {
            // load LookupWSInclude data
            adapterLookupWSInclude.Connection = db.Connection;
            adapterLookupWSInclude.Fill(dsItem.LookupWSInclude);
            
            // load LookupWSType data
            adapterLookupWSType.Connection = db.Connection;
            adapterLookupWSType.Fill(dsItem.LookupWSType);

            // load item lookup data
            adapterLookupItem.Connection = db.Connection;
            adapterLookupItem.Fill(dsItem.LookupItem);

            // load subcategory lookup data
            adapterLookupSubCategory.Connection = db.Connection;
            adapterLookupSubCategory.Fill(dsItem.LookupSubCategory);

            // load worksheet data
            adapterWorksheetSingle.Connection = db.Connection;
            adapterWorksheetSingle.Fill(dsItem.BHHTWorksheetSingle, WSID);

            // load catlist data
            adapterRelCatList.Connection = db.Connection;
            adapterRelCatList.Fill(dsItem.BHHTWSCatList, WSID);

            // load itemlist data
            adapterRelItemList.Connection = db.Connection;
            adapterRelItemList.Fill(dsItem.BHHTWSItemList, WSID);

            // wait with calling ToggleCombos in form load event,
            // so controls has gotten data first
        }
        #endregion

        #region SaveData
        /// <summary>
        /// Saves data for detail tables.
        /// </summary>
        /// <returns>
        /// True if save was ok, false if not alowed to save yet (missing values).
        /// An error message is displayed to the user if false is returned.
        /// </returns>
        private bool SaveData()
        {
            // end edit of any pending field
            bindingWorksheetSingle.EndEdit();
            bindingRelCatList.EndEdit();
            bindingRelItemList.EndEdit();

            // verify that user has entered a worksheet name
            if (txtWSName.Text == "")
            {
                MessageBox.Show(db.GetLangString("BHHTWSDetail.EnterWSName"));
                return false;
            }
            
            // verify that user has selected a value in both comboboxes
            if ((comboIncludeCode.SelectedIndex < 0) ||
                (comboType.SelectedIndex < 0))
            {
                MessageBox.Show(db.GetLangString("BHHTWSDetail.SelectBothIncludeCodeAndType"));
                return false;
            }

            // verify that user has entered detail data
            if (tools.object2string(comboIncludeCode.SelectedValue) == "c")
            {
                if (bindingRelCatList.Count <= 0)
                {
                    MessageBox.Show(db.GetLangString("BHHTWSDetail.AddCatListRecords"));
                    return false;
                }
            }
            else if (tools.object2string(comboIncludeCode.SelectedValue) == "i")
            {
                if (bindingRelItemList.Count <= 0)
                {
                    MessageBox.Show(db.GetLangString("BHHTWSDetail.AddItemListRecords"));
                    return false;
                }
            }

            // save data
            adapterWorksheetSingle.Update(dsItem.BHHTWorksheetSingle);
            adapterRelCatList.Update(dsItem.BHHTWSCatList);
            adapterRelItemList.Update(dsItem.BHHTWSItemList);

            // save ok
            return true;
        }
        #endregion

        #region ToggleCombos
        /// <summary>
        /// Enables/disables comboboxes.
        /// If selected include code is c and catlist table has data or
        /// if selected include code is i and itemlist table has data,
        /// then the comboboxes are disabled, otherwise they are enabled.
        /// </summary>
        private void ToggleCombos()
        {
            bindingRelCatList.EndEdit();
            bindingRelItemList.EndEdit();
            bool enabled = true;
            if (((tools.object2string(comboIncludeCode.SelectedValue) == "c") && (bindingRelCatList.Count > 0)) ||
                ((tools.object2string(comboIncludeCode.SelectedValue) == "i") && (bindingRelItemList.Count > 0)))
                enabled = false;
            comboIncludeCode.Enabled = enabled;
            comboType.Enabled = enabled;
        }
        #endregion

        #region DeleteItemListRecord
        /// <summary>
        /// Deletes the current record from the itemlist binder.
        /// </summary>
        private void DeleteItemListRecord()
        {
            bindingRelItemList.RemoveCurrent();
            ToggleCombos();
        }
        #endregion

        #region DeleteCatListRecord
        /// <summary>
        /// Deletes the current record from the catlist binder.
        /// </summary>
        private void DeleteCatListRecord()
        {
            bindingRelCatList.RemoveCurrent();
            ToggleCombos();
        }
        #endregion

        #region DisplayDetailGrid
        /// <summary>
        /// Display the correct detail grid coresponding
        /// to that is selected in includecode combo.
        /// </summary>
        private void DisplayDetailGrid()
        {
            // display the correct tab
            if (tools.object2string(comboIncludeCode.SelectedValue) == "c")
            {
                gridWSCatList.Visible = true;
                gridWSItemList.Visible = false;
            }
            else if (tools.object2string(comboIncludeCode.SelectedValue) == "i")
            {
                gridWSCatList.Visible = false;
                gridWSItemList.Visible = true;
            }
            else
            {
                gridWSCatList.Visible = false;
                gridWSItemList.Visible = false;
            }

            // position and size the catlist grid as the itemlist grid
            gridWSCatList.Location = gridWSItemList.Location;
            gridWSCatList.Size = gridWSItemList.Size;
        }
        #endregion

        // comboIncludeCode selected index changed event
        private void comboIncludeCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayDetailGrid();
        }

        // cancel button click event
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // save and close button click event
        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        // catlist grid cell content click event
        private void gridWSCatList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bindingRelCatList.Current == null) return;
            DataRowView rowCatList = (DataRowView)bindingRelCatList.Current;

            if (e.ColumnIndex == colSelectSubCategory.Index)
            {
                // when clicking on the select subcategory button
                // open and insert the selected subcategory in the current row
                string subcatID = rowCatList["SubCategoryID"].ToString();
                SubCategoryPopup subcat = new SubCategoryPopup();
                subcat.SelectedSubCategoryID = subcatID;
                if (subcat.ShowDialog() == DialogResult.OK)
                {
                    if (!dsItem.BHHTWSCatList.AlreadyExists(subcat.SelectedSubCategoryID))
                    {
                        rowCatList["SubCategoryID"] = subcat.SelectedSubCategoryID;
                        bindingRelCatList.EndEdit();
                        gridWSCatList.Refresh();

                        /// Note the above use of binder.EndEdit().
                        /// This is nessecary in case of adding a new record.
                        /// We use a button to select a value for ItemID
                        /// and therefore the user never actually enters any
                        /// value maually. Omitting the call causes the grid
                        /// to not recognize that a record is created even
                        /// though it displays the new value.

                        ToggleCombos();
                    }
                    else
                    {
                        MessageBox.Show(db.GetLangString("BHHTWSDetail.CannotAddSubCatTwice"));
                    }
                }
            }
        }

        // itemlist grid cell content click event
        private void gridWSItemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bindingRelItemList.Current == null) return;
            DataRowView rowItem = (DataRowView)bindingRelItemList.Current;

            if (e.ColumnIndex == colSelectItem.Index)
            {
                // when clicking on the select item button
                // open and insert the selected item in the current row
                int itemID = tools.object2int(rowItem["ItemID"]);
                SearchForm search = new SearchForm();
                search.SelectedItemID = itemID;
                search.DisplaySelectWithFilterButton = false;
                if (search.ShowDialog() == DialogResult.OK)
                {
                    if (!dsItem.BHHTWSItemList.AlreadyExists(search.SelectedItemID))
                    {
                        rowItem["ItemID"] = search.SelectedItemID;
                        bindingRelItemList.EndEdit();
                        gridWSItemList.Refresh();

                        /// Note the above use of binder.EndEdit().
                        /// This is nessecary in case of adding a new record.
                        /// We use a button to select a value for ItemID
                        /// and therefore the user never actually enters any
                        /// value maually. Omitting the call causes the grid
                        /// to not recognize that a record is created even
                        /// though it displays the new value.

                        ToggleCombos();
                    }
                    else
                    {
                        MessageBox.Show(db.GetLangString("BHHTWSDetail.CannotAddItemTwice"));
                    }
                }
            }
        }

        // itemlist grid keydown event
        private void gridWSItemList_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
                DeleteItemListRecord();
        }

        // catlist grid keydown event
        private void gridWSCatList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                DeleteCatListRecord();
        }

        // context menu delete button click event
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // the delete button has been called from
            // either itemlist grid or catlist grid
            if (bindingRelItemList.Count > 0)
                DeleteItemListRecord();
            else if(bindingRelCatList.Count > 0)
                DeleteCatListRecord();
        }

        // form load event
        private void BHHTWSDetail_Load(object sender, EventArgs e)
        {
            ToggleCombos();
            DisplayDetailGrid();
        }

        private void gridWSItemList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // render detail form on button on worksheet item list
            ImageButtonRender.OnCellPainting(e, colSelectItem.Index, ImageButtonRender.Images.Search);
        }

        private void gridWSCatList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // render detail form on button on worksheet subcat list
            ImageButtonRender.OnCellPainting(e, colSelectSubCategory.Index, ImageButtonRender.Images.DetailForm);
        }
    }
}