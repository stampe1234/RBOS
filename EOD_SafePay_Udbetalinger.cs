using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class EOD_SafePay_Udbetalinger : Form
    {
        private DateTime BookDate;

        public EOD_SafePay_Udbetalinger(DateTime BookDate)
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
            colBeskrivelse.DisplayIndex = idx++;
        }

        private void LoadData()
        {
            adapterEODSafePayUdbetalinger.Connection = db.Connection;
            adapterEODSafePayUdbetalinger.Fill(dsEOD.EOD_SafePay_Udbetalinger, BookDate);

            // localization
            this.Text = db.GetLangString("EOD_SafePay_Udbetalinger.Title");
            btnSaveAndClose.Text = db.GetLangString("Application.SaveClose");
            btnCancel.Text = db.GetLangString("Application.Cancel");
            colKassenr.HeaderText = db.GetLangString("EOD_SafePay_Udbetalinger.colKassenr");
            colTid.HeaderText = db.GetLangString("EOD_SafePay_Udbetalinger.colTid");
            colAntal.HeaderText = db.GetLangString("EOD_SafePay_Udbetalinger.colAntal");
            colBeloeb.HeaderText = db.GetLangString("EOD_SafePay_Udbetalinger.colBeloeb");
            colBeskrivelse.HeaderText = db.GetLangString("EOD_SafePay_Udbetalinger.colBeskrivelse");

            // toggle manual input
            if (db.GetConfigStringAsBool("SafePay.Udbetalinger.ManuelIndtastning"))
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

        private void SaveData()
        {
            grid.EndEdit();
            bindingEODSafePayUdbetalinger.EndEdit();
            adapterEODSafePayUdbetalinger.Update(dsEOD.EOD_SafePay_Udbetalinger);
        }

        private void EOD_SafePay_Udbetalinger_Load(object sender, EventArgs e)
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