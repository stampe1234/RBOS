using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public enum SearchType
    {
        ItemID,
        FSD_ID,
        KampagneID
    }

    public partial class SearchItemID : Form
    {
        private int _FoundItemID = 0;
        private SearchType _SearchType;
        private List<int> _FoundItemIDs = null;

        public SearchItemID(SearchType SearchType)
        {
            InitializeComponent();
            this._SearchType = SearchType;
        }

        public int FoundItemID
        {
            get { return _FoundItemID; }
        }

        public List<int> FoundItemIDs
        {
            get { return _FoundItemIDs; }
        }

        private void Search()
        {
            int tmpID = tools.object2int(txtSearch.Text);
            if (tmpID <= 0) return;
            if (_SearchType == SearchType.ItemID)
            {
                _FoundItemID = tmpID;
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else if (_SearchType == SearchType.FSD_ID)
            {
                _FoundItemIDs = ItemDataSet.ItemDataTable.GetItemIDsWithGivenFSD_ID(tmpID);
                if (_FoundItemIDs.Count <= 0)
                    _FoundItemIDs = null;
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else if (_SearchType == SearchType.KampagneID)
            {
                _FoundItemIDs = ItemDataSet.ItemDataTable.GetItemIDsWithGivenKampagneID(tmpID);
                if (_FoundItemIDs.Count <= 0)
                    _FoundItemIDs = null;
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
            else if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void SearchItemID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void btnSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void SearchItemID_Load(object sender, EventArgs e)
        {
            // localization
            if (_SearchType == SearchType.ItemID)
                this.Text = db.GetLangString("SearchItemID.Title.ItemID");
            else if (_SearchType == SearchType.FSD_ID)
                this.Text = db.GetLangString("SearchItemID.Title.FSD_ID");
            else if (_SearchType == SearchType.KampagneID)
                this.Text = db.GetLangString("SearchItemID.Title.KampagneID");
            btnSearch.Text = db.GetLangString("Application.Search");
        }
    }
}