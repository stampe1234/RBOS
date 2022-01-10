using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class GLAccountPopup : Form
    {
        private string selectedGLCode = "";

        // constructor
        public GLAccountPopup()
        {
            InitializeComponent();

            // fill SubCategoryPopupView with data
            adapterGLAccount.Connection = db.Connection;
            adapterGLAccount.Fill(dsEOD.GLAccount);

            // default dialogresult to cancel
            this.DialogResult = DialogResult.Cancel;

            // set column order (bug in vs2005)
            colGLCode.DisplayIndex = 0;
            colDesc.DisplayIndex = 1;

            // localization
            this.Text = db.GetLangString("GLAccountPopup.Title");
            btnOk.Text = db.GetLangString("Application.Ok");
            btnCancel.Text = db.GetLangString("Application.Cancel");
            colGLCode.HeaderText = db.GetLangString("GLAccountPopup.colGLCode");
            colDesc.HeaderText = db.GetLangString("GLAccountPopup.colDesc");
        }

        /// <summary>
        /// Returns the selected GLCode string.
        /// Null is returned if nothing selected or cancel clicked.
        /// </summary>
        public string SelectedGLCode
        {
            get { return selectedGLCode; }
            set
            {
                // attempt to find the account
                selectedGLCode = "";
                if ((value == null) || (value == "")) return;
                int index = bindingGLAccount.Find("GLCode", value);
                if ((index >= 0) && (index < bindingGLAccount.Count))
                {
                    bindingGLAccount.Position = index;
                    selectedGLCode = value;
                }
            }
        }

        /// <summary>
        /// Closes the form and returns the selected
        /// glcode by putting it in a property
        /// </summary>
        private void CloseAndReturn()
        {
            // get the selected glcode
            if (bindingGLAccount.Current != null)
            {
                DataRowView row = (DataRowView)bindingGLAccount.Current;
                selectedGLCode = row["GLCode"].ToString();
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CloseAndReturn();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            CloseAndReturn();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CloseAndReturn();
        }
    }
}