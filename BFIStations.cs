using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class BFIStations : Form
    {
        public BFIStations()
        {
            InitializeComponent();

            int displayIndex = -1;
            colStationsnr.DisplayIndex = ++displayIndex;
            colStationsnavn.DisplayIndex = ++displayIndex; 
            colAktivFTP.DisplayIndex = ++displayIndex;
            colSidsteFilnavn.DisplayIndex = ++displayIndex;
            colSidsteFilDatoTid.DisplayIndex = ++displayIndex;
            colIsTest.DisplayIndex = ++displayIndex;
        }

        private void LoadData()
        {
            adapterBFIExportHistory.Connection = db.Connection;
            adapterBFIExportHistory.Fill(dsItem.BFI_ExportHistory);
            adapterBFIStations.Connection = db.Connection;
            adapterBFIStations.Fill(dsItem.BFI_Stations);
            adapterFTPAccounts.Connection = db.Connection;
            adapterFTPAccounts.FillAll(dsAdmin.FTPAccounts);
            comboSelectFTP.SelectedValue = db.GetConfigStringAsInt("BFI.Export.FTPAccount");

            // localization
            btnSaveAndClose.Text = db.GetLangString("Application.SaveClose");
            btnCancel.Text = db.GetLangString("Application.Cancel");
            colStationsnr.HeaderText = db.GetLangString("BFIStations.colStationsnr");
            colStationsnavn.HeaderText = db.GetLangString("BFIStations.colStationsnavn");
            colAktivFTP.HeaderText = db.GetLangString("BFIStations.colAktivFTP");
            colSidsteFilnavn.HeaderText = db.GetLangString("BFIStations.colSidsteFilnavn");
            colSidsteFilDatoTid.HeaderText = db.GetLangString("BFIStations.colSidsteFilDatoTid");
            colIsTest.HeaderText = db.GetLangString("BFIStations.colIsTest");
            lbSelectFTP.Text = db.GetLangString("BFIStations.lbSelectFTP");
        }

        private void SaveAndClose()
        {
            grid.EndEdit();
            bindingBFIStations.EndEdit();
            adapterBFIStations.Update(dsItem.BFI_Stations);
            db.SetConfigString("BFI.Export.FTPAccount", tools.object2int(comboSelectFTP.SelectedValue));
            Close();
        }

        private void BFIStations_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            SaveAndClose();
        }
    }
}