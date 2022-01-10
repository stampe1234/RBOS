using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class EODDebtorPopup : Form
    {
        private Nullable<int> selectedDebtorNo = null;

        #region Constructor
        public EODDebtorPopup(bool ShowInactiveDebtors)
        {
            InitializeComponent();

            // by default the active flag is checked for true,
            // but 
            Nullable<bool> active = true;
            if (ShowInactiveDebtors) active = null;

            adapterEODDebtorPopup.Connection = db.Connection;
            if (active ==true)            
                adapterEODDebtorPopup.FillOnlyActive(dsEOD.EOD_DebtorPopup);
            else
                adapterEODDebtorPopup.Fill(dsEOD.EOD_DebtorPopup);
            this.DialogResult = DialogResult.Cancel;

            // localization
            this.Text = db.GetLangString("EODDebtorPopup.Title");
            btnSelect.Text = db.GetLangString("Application.Select");
            btnCancel.Text = db.GetLangString("Application.Cancel");
            btnSelectNone.Text = db.GetLangString("EODDebtorPopup.btnSelectNone");
            colName.HeaderText = db.GetLangString("EODDebtorPopup.colName");
            colDebtorNo.HeaderText = db.GetLangString("EODDebtorPopup.colDebtorNo");
            colRRNumber.HeaderText = db.GetLangString("EODDebtorPopup.colRRNumber");

            // customize form based on whether VPRG is enabled
            bool VPRG_enabled = db.GetConfigStringAsBool("VPRG.Enabled");
            colRRNumber.Visible = VPRG_enabled;
            if (!VPRG_enabled)
            {
                this.Width = this.Width - colRRNumber.Width;
                txtName.Left = txtRRNumber.Left;
                txtName.Width = txtName.Width + txtRRNumber.Width;
            }
            txtRRNumber.Visible = VPRG_enabled;

            // position columns in grid
            int index = -1;
            colDebtorNo.DisplayIndex = ++index;
            if (VPRG_enabled)
                colRRNumber.DisplayIndex = ++index;
            colName.DisplayIndex = ++index;
        }
        #endregion

        #region SelectAndClose
        /// <summary>
        /// Sets an internal variable, that holds the
        /// selected DebtorNo and closes the form. Users
        /// of this class can then use the property
        /// SelectedDebtorNo to retrieve the selected value.
        /// </summary>
        private void SelectAndClose()
        {
            selectedDebtorNo = null;
            if (bindingEODDebtorPopup.Current != null)
            {
                DataRowView row = (DataRowView)bindingEODDebtorPopup.Current;
                selectedDebtorNo = tools.object2int(row["DebtorNo"]);
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        #region SelectedDebtorNo
        /// <summary>
        /// Get or set the selected DebtorNo.
        /// Nothing selected is -1.
        /// </summary>
        public Nullable<int> SelectedDebtorNo
        {
            get { return selectedDebtorNo; }
            set
            {
                selectedDebtorNo = value;
                int pos = bindingEODDebtorPopup.Find("DebtorNo", selectedDebtorNo);
                if (pos >= 0) bindingEODDebtorPopup.Position = pos;
                else selectedDebtorNo = null;
            }
        }
        #endregion

        #region SelectedDebtorName1
        /// <summary>
        /// Gets the Name1 field value of the selected debtor.
        /// If no debtor is selected, "" is returned.
        /// </summary>
        public string SelectedDebtorName1
        {
            get
            {
                return tools.object2string(db.ExecuteScalar(string.Format(
                    " select Name1 from EOD_Debtor where DebtorNo = {0} ",
                    selectedDebtorNo)));
            }
        }
        #endregion

        #region PROPERTY DisplaySelectNoneButton
        /// <summary>
        /// Toggles visibility of select none button.
        /// </summary>
        public bool DisplaySelectNoneButton
        {
            set { btnSelectNone.Visible = value; }
        }
        #endregion

        private void ApplyFilter()
        {
            string filter = " (1=1) ";
            if (txtDebtorNo.Text != "")
                filter += string.Format(" AND (DebtorNoAsString LIKE '%{0}%') ", txtDebtorNo.Text);
            if (txtName.Text != "")
                filter += string.Format(" AND (Name1 LIKE '%{0}%') ", txtName.Text);
            if (txtRRNumber.Visible && (txtRRNumber.Text != ""))
                filter += string.Format(" AND (RRNumber LIKE '%{0}%') ", txtRRNumber.Text);
            bindingEODDebtorPopup.Filter = filter;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectAndClose();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            SelectAndClose();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Return)
                SelectAndClose();
        }

        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            selectedDebtorNo = null;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void txtDebtorNo_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void txtRRNumber_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }
    }
}