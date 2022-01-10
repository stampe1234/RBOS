using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class EOD_SafePay_Indbetalinger : Form
    {
        private DateTime BookDate;

        public EOD_SafePay_Indbetalinger(DateTime BookDate)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.BookDate = BookDate;

            int idx = 0;
            colKassenr.DisplayIndex = idx++;
            colTid.DisplayIndex = idx++;
            colAntal.DisplayIndex = idx++;
            colBeloeb.DisplayIndex = idx++;
            colBeskrivelse.DisplayIndex = idx++;
        }

        private void SaveData()
        {
            grid.EndEdit();
            bindingEODSafePayIndbetalinger.EndEdit();
            adapterEODSafePayIndbetalinger.Update(dsEOD.EOD_SafePay_Indbetalinger);
        }

        private void LoadData()
        {
            adapterEODSafePayIndbetalinger.Connection = db.Connection;
            adapterEODSafePayIndbetalinger.Fill(dsEOD.EOD_SafePay_Indbetalinger, BookDate);

            // localization
            this.Text = db.GetLangString("EOD_SafePay_Indbetalinger.Title");
            colKassenr.HeaderText = db.GetLangString("EOD_SafePay_Indbetalinger.colKassenr");
            colTid.HeaderText = db.GetLangString("EOD_SafePay_Indbetalinger.colTid");
            colAntal.HeaderText = db.GetLangString("EOD_SafePay_Indbetalinger.colAntal");
            colBeloeb.HeaderText = db.GetLangString("EOD_SafePay_Indbetalinger.colBeloeb");
            colBeskrivelse.HeaderText = db.GetLangString("EOD_SafePay_Indbetalinger.colBeskrivelse");
            btnSaveAndClose.Text = db.GetLangString("Application.SaveClose");
            btnCancel.Text = db.GetLangString("Application.Cancel");

            // toggle manual input
            if (db.GetConfigStringAsBool("SafePay.Indbetalinger.ManuelIndtastning"))
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

        private void EOD_SafePay_Indbetalinger_Load(object sender, EventArgs e)
        {
            LoadData();
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
    }
}