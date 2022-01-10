using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class EOD_DETAIL_Valuta : Form
    {
        private DateTime BookDate;
        private bool EditEnabled = false;

        public EOD_DETAIL_Valuta(DateTime BookDate)
        {
            InitializeComponent();
            this.BookDate = BookDate;
            this.EditEnabled = db.GetConfigStringAsBool("EOD.Valuta.DETAIL.UnlockFields");

            // setup grid column order
            int idx = 0;
            colValutaISOkode.DisplayIndex = idx++;
            colValuta.DisplayIndex = idx++;
            colValutabeloeb.DisplayIndex = idx++;
            colBeloebDKK.DisplayIndex = idx++;

            btnSave.Visible = EditEnabled;
            dataGridView1.AllowUserToAddRows = EditEnabled;
            dataGridView1.AllowUserToDeleteRows = EditEnabled;
            dataGridView1.ReadOnly = !EditEnabled;
            colValutaISOkode.ReadOnly = true; // always readonly
        }

        private void LoadData()
        {
            adapterValuta.Connection = db.Connection;
            adapterValuta.Fill(dsEOD.EOD_DETAIL_Valuta, BookDate);

            // localization
            this.Text = db.GetLangString("EOD_DETAIL_Valuta.Title");
            btnClose.Text = EditEnabled ? db.GetLangString("Application.Cancel") : db.GetLangString("Application.Close");
            colValutaISOkode.HeaderText = db.GetLangString("EOD_DETAIL_Valuta.colValutaISOkode");
            colValuta.HeaderText = db.GetLangString("EOD_DETAIL_Valuta.colValuta");
            colValutabeloeb.HeaderText = db.GetLangString("EOD_DETAIL_Valuta.colValutabeloeb");
            colBeloebDKK.HeaderText = db.GetLangString("EOD_DETAIL_Valuta.colBeloebDKK");
            btnSave.Text = db.GetLangString("Application.SaveClose");
        }

        private void SaveData()
        {
            dataGridView1.EndEdit();
            bindingValuta.EndEdit();
            adapterValuta.Update(dsEOD.EOD_DETAIL_Valuta);
        }

        private void EOD_DETAIL_Valuta_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }
    }
}