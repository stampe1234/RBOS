using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class ItemTypeCodePopup : Form
    {
        private Nullable<short> selectedItemTypeCodeID = null;

        // constructor
        public ItemTypeCodePopup()
        {
            InitializeComponent();

            // load lookup data
            adapter.Connection = db.Connection;
            adapter.Fill(dsItem.LookupItemTypeCode);

            // default dialogresult to cancel
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Returns the selected ItemTypeCode ID.
        /// Null is returned if nothing selected or cancel clicked.
        /// </summary>
        public Nullable<short> SelectedItemTypeCodeID
        {
            get { return selectedItemTypeCodeID; }
            set
            {
                // attempt to find the itemtypecode
                selectedItemTypeCodeID = -1;
                if ((value == null) || (value == -1)) return;
                int index = binding.Find("ItemTypeCode", value);
                if ((index >= 0) && (index < binding.Count))
                {
                    binding.Position = index;
                    selectedItemTypeCodeID = value;
                }
            }
        }

        /// <summary>
        /// Returns the selected ItemTypeCode description.
        /// Null is returned if nothing selected or cancel clicked.
        /// </summary>
        public string SelectedSubCategoryDesc
        {
            get
            {
                if (selectedItemTypeCodeID != null)
                {
                    int index = binding.Find("ItemTypeCode", selectedItemTypeCodeID);
                    if ((index >= 0) && (index < binding.Count))
                        return ((DataRowView)binding[index])["Description"].ToString();
                }
                return null;
            }
        }

        /// <summary>
        /// Closes the form and returns the selected
        /// itemtypecode by putting it in a property
        /// </summary>
        private void CloseAndReturn()
        {
            // get the selected ItemTypeCodeID
            selectedItemTypeCodeID = null;
            if (binding.Current != null)
            {
                DataRowView row = (DataRowView)binding.Current;
                if (row["ItemTypeCode"] is short)
                    selectedItemTypeCodeID = short.Parse(row["ItemTypeCode"].ToString());
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }

        // form load event
        private void ItemTypeCodePopup_Load(object sender, EventArgs e)
        {
            this.Text = db.GetLangString("ItemTypeCodeForm.Header");
            btnOk.Text = db.GetLangString("Application.Ok");
            btnCancel.Text = db.GetLangString("Application.Cancel");

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

        // grid keydown event
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CloseAndReturn();
        }
    }
}