using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class EOD_SafePay_Depotbeholdning : Form
    {
        DateTime BookDate = DateTime.MinValue;

        public EOD_SafePay_Depotbeholdning(DateTime BookDate)
        {
            InitializeComponent();
            this.BookDate = BookDate;

            // setup grid columns
            int idx = 0;
            colEnhedsnummer.DisplayIndex = idx++;
            colValutaTekst.DisplayIndex = idx++;
            colValutaBeloeb.DisplayIndex = idx++;
            colDKKBeloeb.DisplayIndex = idx++;
        }

        private void LoadData()
        {
            adapterEODSafePayDepotbeholdning.Connection = db.Connection;
            adapterEODSafePayDepotbeholdning.FillWithValutaTekstLookup(dsEOD.EOD_SafePay_Depotbeholdning, BookDate);

            // localization
            this.Text = db.GetLangString("EOD_SafePay_Depotbeholdning.Title");
            btnClose.Text = db.GetLangString("Application.Close");
            colEnhedsnummer.HeaderText = db.GetLangString("EOD_SafePay_Depotbeholdning.colEnhedsnummer");
            colValutaTekst.HeaderText = db.GetLangString("EOD_SafePay_Depotbeholdning.colValutaTekst");
            colValutaBeloeb.HeaderText = db.GetLangString("EOD_SafePay_Depotbeholdning.colValutaBeloeb");
            colDKKBeloeb.HeaderText = db.GetLangString("EOD_SafePay_Depotbeholdning.colDKKBeloeb");
        }

        private void EOD_SafePay_Depotbeholdning_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}