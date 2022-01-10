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
    public partial class SearchFormRBA : Form
    {
        #region Variables

        private string selectedVaregruppeID = "";
        private int selectedLevNr = 0;
        private double selectedVarenummer = 0;
        private bool _IncludeInactiveItems = false;

        #endregion

        #region Constructor

        public SearchFormRBA()
        {
            InitializeComponent();

            // set grid column order
            int index = 0;
            colBarcode.DisplayIndex = index++;
            colVarenummer.DisplayIndex = index++;
            colVarenavn.DisplayIndex = index++;
            colVaregruppeDesc.DisplayIndex = index++;
            colLevKategori.DisplayIndex = index++;

            // by default, the forms DialogResult is Cancel
            this.DialogResult = DialogResult.Cancel;
        }

        #endregion

        #region IncludeInactiveItems
        public bool IncludeInactiveItems
        {
            get { return _IncludeInactiveItems; }
            set { _IncludeInactiveItems = value; }
        }
        #endregion

        #region SelectedLevNr
        public int SelectedLevNr
        {
            get
            {
                return selectedLevNr;
            }
        }
        #endregion

        #region SelectedVarenummer
        public double SelectedVarenummer
        {
            get
            {
                return selectedVarenummer;
            }
        }
        #endregion

        #region PreSelectVarenummerFiltered
        /// <summary>
        /// Pre-enters the varenummer and filters the list.
        /// This is used when more than two records have the same varenummer
        /// and user needs to select one of them. Is called before showing the form.
        /// </summary>
        public void PreSelectVarenummerFiltered(double Varenummer)
        {
            selectedVarenummer = Varenummer;
            txtVarenummer.Text = selectedVarenummer.ToString();
            PerformFiltering();
        }
        #endregion

        #region PreSelectBarcodeFiltered
        /// <summary>
        /// Pre-enters the barcode and filters the list.
        /// This is used when more than two records have the same barcode
        /// and user needs to select one of them. Is called before showing the form.
        /// </summary>
        public void PreSelectBarcodeFiltered(double Barcode)
        {
            txtBarcode.Text = Barcode.ToString();
            PerformFiltering();
        }
        #endregion

        #region PreSelectVareUnfiltered
        /// <summary>
        /// Positions the cursor on the record, that has the given LevNr and Varenuumer,
        /// but does not filter the list nor enters values anywhere.
        /// </summary>
        public void PreSelectVareUnfiltered(int LevNr, double Varenummer)
        {
            // usually we would use the Find method on the BindingSource,
            // but Find does not support two fields, so instead we search
            // through the binding source's data.
            bindingAfskrProdSearch.SuspendBinding();
            int index = 0;
            foreach (object o in bindingAfskrProdSearch.List)
            {
                DataRow row = (o as DataRowView).Row;
                if (row["LevNr"].Equals(LevNr) && row["Varenummer"].Equals(Varenummer))
                {
                    bindingAfskrProdSearch.ResumeBinding();
                    bindingAfskrProdSearch.Position = index;
                    break;
                }
                ++index;
            }
            if (bindingAfskrProdSearch.IsBindingSuspended)
                bindingAfskrProdSearch.ResumeBinding();
        }
        #endregion

        #region GetCurrentlySelectedAndClose method
        /// <summary>
        /// Internal helper method to get the selected vare from the binding source.
        /// </summary>
        private void GetCurrentlySelectedAndClose()
        {
            // attempt to get selected vare from selected grid row
            DataRowView row = (DataRowView)bindingAfskrProdSearch.Current;
            if (row != null)
            {
                selectedLevNr = tools.object2int(row["LevNr"]);
                selectedVarenummer = tools.object2double(row["Varenummer"]);
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        #region PerformFiltering method
        /// <summary>
        /// Performs the filtering based on values entered in the text boxes and the selectedVaregruppeID variable.
        /// txtBarcode will select the specific vare and close the form by itself, so it is not part of the filtering
        /// </summary>
        private void PerformFiltering()
        {
            // reset the filter
            bindingAfskrProdSearch.Filter = "";

            // apply barcode filter
            if (txtBarcode.Text != "")
            {
                // check that barcode is a sequence of numbers only
                Regex regex = new Regex("^([0-9]*)$");
                if (regex.Match(txtBarcode.Text).Success)
                {
                    if (bindingAfskrProdSearch.Filter != "")
                        bindingAfskrProdSearch.Filter += " AND ";
                    bindingAfskrProdSearch.Filter +=
                        string.Format(" (Barcode = '{0}') ", txtBarcode.Text.Replace("'", ""));
                }
                else
                {
                    MessageBox.Show(db.GetLangString("SearchFormRBA.EnterOnlyBarcodeWithNumbers"));
                    if (txtBarcode.CanFocus)
                        txtBarcode.Focus();
                    return;
                }
            }

            // apply varenavn filter
            if (txtVarenavn.Text != "")
            {
                if (bindingAfskrProdSearch.Filter != "")
                    bindingAfskrProdSearch.Filter += " AND ";
                bindingAfskrProdSearch.Filter +=
                    string.Format(" (Varenavn like '%{0}%') ", txtVarenavn.Text.Replace("'", ""));
            }

            // apply varegruppe filter
            if (selectedVaregruppeID != "")
            {
                if (bindingAfskrProdSearch.Filter != "")
                    bindingAfskrProdSearch.Filter += " AND ";
                bindingAfskrProdSearch.Filter +=
                    string.Format(" (Varegruppe = '{0}') ", selectedVaregruppeID);
            }

            // apply varenummer filter
            if (txtVarenummer.Text != "")
            {
                // check that varenummer is a sequence of numbers only
                Regex regex = new Regex("^([0-9]*)$");
                if (regex.Match(txtVarenummer.Text).Success)
                {
                    if (bindingAfskrProdSearch.Filter != "")
                        bindingAfskrProdSearch.Filter += " AND ";
                    bindingAfskrProdSearch.Filter +=
                        string.Format(" (Varenummer = '{0}') ", txtVarenummer.Text.Replace("'", ""));
                }
                else
                {
                    MessageBox.Show(db.GetLangString("SearchFormRBA.EnterOnlyVarenummerWithNumbers"));
                    if (txtVarenummer.CanFocus)
                        txtVarenummer.Focus();
                    return;
                }
            }

            // if filter has removed all records, disable btnOk
            btnOk.Enabled = (bindingAfskrProdSearch.Count > 0);

            // if only one vare is filtered out, select it and close
            if (bindingAfskrProdSearch.Count == 1)
                GetCurrentlySelectedAndClose();
        }
        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            GetCurrentlySelectedAndClose();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GetCurrentlySelectedAndClose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtBarcode_Leave(object sender, EventArgs e)
        {
            PerformFiltering();
        }

        private void txtVarenavn_Leave(object sender, EventArgs e)
        {
            PerformFiltering();
        }

        private void txtVaregruppe_Leave(object sender, EventArgs e)
        {
            PerformFiltering();
        }

        private void txtVarenummer_Leave(object sender, EventArgs e)
        {
            PerformFiltering();
        }

        private void SearchFormRBA_Load(object sender, EventArgs e)
        {
            // localization
            this.Text = db.GetLangString("SearchFormRBA.Title");
            lbBarcode.Text = db.GetLangString("SearchFormRBA.BarcodeLabel");
            lbVarenavn.Text = db.GetLangString("SearchFormRBA.VarenavnLabel");
            lbVaregruppe.Text = db.GetLangString("SearchFormRBA.Varegruppe");
            lbVarenummer.Text = db.GetLangString("SearchFormRBA.lbVarenummer");
            btnOk.Text = db.GetLangString("Application.Ok");
            btnCancel.Text = db.GetLangString("Application.Cancel");

            // load AfskrProdSearch data from database
            adapterAfskrProdSearch.Connection = db.Connection;
            adapterAfskrProdSearch.Fill(dsItem.AfskrProdSearch, IncludeInactiveItems);
        }

        private void btnLookupVaregruppe_Click(object sender, EventArgs e)
        {
            // show varegruppe popup
            SubCategoryPopup subcat = new SubCategoryPopup();
            subcat.DisplaySelectNoneButton = true;
            subcat.SelectedSubCategoryID = selectedVaregruppeID;
            if (subcat.ShowDialog() == DialogResult.OK)
            {
                // setup and perform filtering
                if (subcat.SelectedSubCategoryID != "")
                {
                    selectedVaregruppeID = subcat.SelectedSubCategoryID;
                    txtVaregruppe.Text = subcat.SelectedSubCategoryDesc;
                }
                else
                {
                    selectedVaregruppeID = "";
                    txtVaregruppe.Text = "";
                }
                PerformFiltering();
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            tools.EnterAsTab(e);
        }

        private void txtVarenavn_KeyDown(object sender, KeyEventArgs e)
        {
            tools.EnterAsTab(e);
        }

        private void txtVarenummer_KeyDown(object sender, KeyEventArgs e)
        {
            tools.EnterAsTab(e);
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                GetCurrentlySelectedAndClose();
        }
    }
}