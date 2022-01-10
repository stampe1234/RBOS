using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class EOD_SafePay_OverfoerselTilSP : Form
    {
        private DateTime BookDate;

        public EOD_SafePay_OverfoerselTilSP(DateTime BookDate)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.BookDate = BookDate;

            // setup grid columns
            int idx = 0;
            colKassenr.DisplayIndex = idx++;
            colTid.DisplayIndex = idx++;
            colAntal.DisplayIndex = idx++;
            colBeloeb.DisplayIndex = idx++;
        }

        private void SaveData()
        {
            grid.EndEdit();
            bindingEODSafePayOverfoerselTilSP.EndEdit();
            adapterEODSafePayOverfoerselTilSP.Update(dsEOD.EOD_SafePay_OverfoerselTilSP);
        }

        private void LoadData()
        {
            adapterEODSafePayOverfoerselTilSP.Connection = db.Connection;
            adapterEODSafePayOverfoerselTilSP.Fill(dsEOD.EOD_SafePay_OverfoerselTilSP, BookDate);

            // localization
            this.Text = db.GetLangString("EOD_SafePay_OverfoerselTilSP.Title");
            btnSaveAndClose.Text = db.GetLangString("Application.SaveClose");
            btnCancel.Text = db.GetLangString("Application.Cancel");
            colKassenr.HeaderText = db.GetLangString("EOD_SafePay_OverfoerselTilSP.colKassenr");
            colTid.HeaderText = db.GetLangString("EOD_SafePay_OverfoerselTilSP.colTid");
            colAntal.HeaderText = db.GetLangString("EOD_SafePay_OverfoerselTilSP.colAntal");
            colBeloeb.HeaderText = db.GetLangString("EOD_SafePay_OverfoerselTilSP.colBeloeb");

            // setup manual input
            if (db.GetConfigStringAsBool("SafePay.OverfoerselTilSP.ManuelIndtastning"))
            {
                grid.AllowUserToAddRows = true;
                grid.AllowUserToDeleteRows = true;
                colBeloeb.ReadOnly = false;
                colBeloeb.DefaultCellStyle.BackColor = SystemColors.Window;
            }
            else
            {
                btnSaveAndClose.Visible = false;
                btnCancel.Text = db.GetLangString("Application.Close"); // must be called after localization above
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            SaveData();
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void EOD_SafePay_OverfoerselTilSP_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}