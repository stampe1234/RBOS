using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class SupplierPopup : Form
    {
        #region PROPERTY: SelectedSupplierID
        private int selectedSupplierID = 0;
        public int SelectedSupplierID
        {
            get { return selectedSupplierID; }
            set
            {
                // attempt to find the supplier
                selectedSupplierID = 0;
                if (value <= 0) return;
                int index = bindingSupplier.Find("SupplierID", value);
                if ((index >= 0) && (index < bindingSupplier.Count))
                {
                    bindingSupplier.Position = index;
                    selectedSupplierID = value;
                }
            }
        }
        #endregion

        #region PROPERTY: SelectedSupplierDescription
        private string selectedSupplierDescription = "";
        public string SelectedSupplierDescription
        {
            get { return selectedSupplierDescription; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public SupplierPopup()
        {
            InitializeComponent();

            // load data
            adapterSupplier.Connection = db.Connection;
            adapterSupplier.Fill(dsItem.LookupSupplier);

            // default dialog result is cancel
            this.DialogResult = DialogResult.Cancel;

            // localization
            this.Text = db.GetLangString("SupplierPopup.Title");
            btnOk.Text = db.GetLangString("Application.Ok");
            btnCancel.Text = db.GetLangString("Application.Cancel");
            colSupplierID.HeaderText = db.GetLangString("SupplierPopup.colSupplierID");
            colDescription.HeaderText = db.GetLangString("SupplierPopup.colDescription");
        }
        #endregion

        #region METHOD: SelectAndClose
        /// <summary>
        /// Sets the selected supplier values and closes the form.
        /// </summary>
        private void SelectAndClose()
        {
            if (bindingSupplier.Current != null)
            {
                // set selected values
                DataRowView row = (DataRowView)bindingSupplier.Current;
                selectedSupplierID = tools.object2int(row["SupplierID"]);
                selectedSupplierDescription = row["Description"].ToString();

                // set dialog result
                this.DialogResult = DialogResult.OK;
            }

            Close();
        }
        #endregion

        // close button click event
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // select button click event
        private void btnOk_Click(object sender, EventArgs e)
        {
            SelectAndClose();
        }

        // grid mouse double click event
        private void gridSuppliers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectAndClose();
        }

        // form keydown event
        private void SupplierPopup_KeyDown(object sender, KeyEventArgs e)
        {
            /// when user presses Escape key anywhere in the
            /// form and  controls, the form is closed with
            /// default dialog result of Cancel. the form should
            /// have the KeyPreview property set = true, so this
            /// event is invoked automatically from any control on the form.
            if (e.KeyCode == Keys.Escape)
                Close();
        }
        
        // grid key down event
        private void gridSuppliers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectAndClose();
        }
    }
}