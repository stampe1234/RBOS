using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class PrlClusterSites : Form
    {
        private string _SelectedSiteCode = "";
        public string SelectedSiteCode
        {
            get
            {
                return _SelectedSiteCode;
            }
            set
            {
                // make sure null is not set to the internal sitecode
                if (value == null)
                    value = "";

                // reset selected sitecode
                _SelectedSiteCode = "";

                // select sitecode in grid if possible
                int index = bindingClusterSites.Find("SiteCode", value);
                if (index > -1)
                {
                    bindingClusterSites.Position = index;
                    _SelectedSiteCode = value;
                }
            }
        }

        public PrlClusterSites()
        {
            InitializeComponent();
            LoadData();
            this.DialogResult = DialogResult.Cancel;

            // localization
            this.Text = db.GetLangString("PrlClusterSites.Title");
            btnSelectNone.Text = db.GetLangString("Application.SelectNone");
            btnSelect.Text = db.GetLangString("Application.Select");
            btnCancel.Text = db.GetLangString("Application.Cancel");
            colSiteCode.HeaderText = db.GetLangString("PrlClusterSites.colSiteCode");
            colSiteName.HeaderText = db.GetLangString("PrlClusterSites.colSiteName");
        }

        private void LoadData()
        {
            adapterClusterSites.Connection = db.Connection;
            adapterClusterSites.Fill(dsPayroll.PrlClusterSites);
        }

        private void SelectAndClose()
        {
            if (bindingClusterSites.Current != null)
            {
                DataRowView row = (DataRowView)bindingClusterSites.Current;
                _SelectedSiteCode = tools.object2string(row["SiteCode"]);
                this.DialogResult = DialogResult.OK;
            }
            Close();
        }

        private void SelectNoneAndClose()
        {
            _SelectedSiteCode = "";
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void PrlClusterSites_Load(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectAndClose();
        }

        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            SelectNoneAndClose();
        }

        private void gridClusterSites_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectAndClose();
        }

        private void gridClusterSites_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                SelectAndClose();
        }
    }
}