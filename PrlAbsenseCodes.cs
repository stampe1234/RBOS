using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class PrlAbsenseCodes : Form
    {
        private int _SelectedAbsenseCode = 0;
        public int SelectedAbsenseCode
        {
            get { return _SelectedAbsenseCode; }

            set
            {
                // reset selected absensecode
                _SelectedAbsenseCode = 0;

                // select absensecode in grid if possible
                int index = prlLookupAbsenseCodesBindingSource.Find("AbsenseCode", value);
                if (index > -1)
                {
                    prlLookupAbsenseCodesBindingSource.Position = index;
                    _SelectedAbsenseCode = value;
                }
            }
        }

        // constructor
        public PrlAbsenseCodes(bool ShowFuncData)
        {
            InitializeComponent();
            LoadData(ShowFuncData);
            this.DialogResult = DialogResult.Cancel;

            // localization
            this.Text = db.GetLangString("PrlAbsenseCodes.Title");
            btnOk.Text = db.GetLangString("Application.Select");
            btnCancel.Text = db.GetLangString("Application.Cancel");
            colAbsenseCode.HeaderText = db.GetLangString("PrlAbsenseCodes.colAbsenseCode");
            colDescription.HeaderText = db.GetLangString("PrlAbsenseCodes.colDescription");
        }

        private void LoadData(bool ShowFuncData)
        {
            prlLookupAbsenseCodesTableAdapter.Connection = db.Connection;
            prlLookupAbsenseCodesTableAdapter.Fill(payroll.PrlLookupAbsenseCodes, ShowFuncData);
        }

        private void SelectAndClose()
        {
            if (prlLookupAbsenseCodesBindingSource.Current != null)
            {
                DataRowView row = (DataRowView)prlLookupAbsenseCodesBindingSource.Current;
                _SelectedAbsenseCode = tools.object2int(row["AbsenseCode"]);
                this.DialogResult = DialogResult.OK;
            }
            Close();
        }

        private void PrlAbsenseCodes_Load(object sender, EventArgs e)
        {
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SelectAndClose();
        }

        private void drS_DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectAndClose();
        }

        private void drS_DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            SelectAndClose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}