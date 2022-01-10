using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class CreditCategoryPopup : Form
    {
        private string selectedCreditCategoryID = null;

        // constructor
        public CreditCategoryPopup()
        {
            InitializeComponent();

            // load lookup data
            adapter.Connection = db.Connection;
            adapter.Fill(dsItem.LookupCreditCategory);

            // default dialogresult to cancel
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Returns the selected CreditCategory ID.
        /// Null is returned if nothing selected or cancel clicked.
        /// </summary>
        public string SelectedCreditCategoryID
        {
            get { return selectedCreditCategoryID; }
            set
            {
                // attempt to find the credit category
                selectedCreditCategoryID = null;
                if ((value == null) || (value == "")) return;
                int index = binding.Find("CredCat", value);
                if ((index >= 0) && (index < binding.Count))
                {
                    binding.Position = index;
                    selectedCreditCategoryID = value;
                }
            }
        }

        /// <summary>
        /// Returns the selected CreditCategory description.
        /// Null is returned if nothing selected or cancel clicked.
        /// </summary>
        public string SelectedCreditCategoryDesc
        {
            get
            {
                if (selectedCreditCategoryID != null)
                {
                    int index = binding.Find("SubCategoryID", selectedCreditCategoryID);
                    if ((index >= 0) && (index < binding.Count))
                        return ((DataRowView)binding[index])["Description"].ToString();
                }
                return null;
            }
        }

        /// <summary>
        /// Closes the form and returns the selected
        /// credit category by putting it in a property
        /// </summary>
        private void CloseAndReturn()
        {
            // get the selected SubCategoryID
            if (binding.Current != null)
            {
                DataRowView row = (DataRowView)binding.Current;
                selectedCreditCategoryID = row["CredCat"].ToString();
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }

        // form load event
        private void CreditCategoryPopup_Load(object sender, EventArgs e)
        {
            this.Text = db.GetLangString("CreditCategoryForm.Header");
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