using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RBOS
{
    public partial class BFIExportFrm : Form
    {
        public BFIExportFrm()
        {
            InitializeComponent();

            int idx = -1;
            colStation.DisplayIndex = ++idx;
            colStationsnavn.DisplayIndex = ++idx;
            colInkluder.DisplayIndex = ++idx;
            colIsTest.DisplayIndex = ++idx;
        }

        private void LoadData()
        {
            adapterBFIStations.Connection = db.Connection;
            adapterBFIStations.FillOnlyActiveFTP(dsItem.BFI_Stations);

            // localization
            lbSelectBFIFile.Text = db.GetLangString("BFIExportFrm.lbSelectBFIFile");
            btnSend.Text = db.GetLangString("BFIExportFrm.btnSend");
            btnSendTest.Text = db.GetLangString("BFIExportFrm.btnSendTest");
            btnSelectAll.Text = db.GetLangString("BFIExportFrm.btnSelectAll");
            btnDeselectAll.Text = db.GetLangString("BFIExportFrm.btnDeselectAll");
            btnClose.Text = db.GetLangString("Application.Close");
            colStation.HeaderText = db.GetLangString("BFIExportFrm.colStation");
            colStationsnavn.HeaderText = db.GetLangString("BFIExportFrm.colStationsnavn");
            colInkluder.HeaderText = db.GetLangString("BFIExportFrm.colInkluder");
            colIsTest.HeaderText = db.GetLangString("BFIExportFrm.colIsTest");
        }

        private void Send(bool SendToTest)
        {
            if (!File.Exists(txtSelectBFIFile.Text))
                return;

            List<string> SiteCodes = new List<string>();
            grid.EndEdit();
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (SendToTest)
                {
                    // check if this is a test station
                    if ((bool)row.Cells[colIsTest.Index].Value == true)
                        SiteCodes.Add((string)row.Cells[colStation.Index].Value);
                }
                else
                {
                    // check if this is not a test station and if it is still selected
                    if (((bool)row.Cells[colIsTest.Index].Value != true) &&
                        ((bool)row.Cells[colInkluder.Index].Value == true))
                    {
                        SiteCodes.Add((string)row.Cells[colStation.Index].Value);
                    }
                }
            }

            // send
            if (SiteCodes.Count > 0)
            {
                string msg = db.GetLangString("BFIExportFrm.ConfirmSend");
                if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                FTP ftp = new FTP(db.GetConfigStringAsInt("BFI.Export.FTPAccount"), (MainForm)this.MdiParent);
                ftp.UploadFileToMultipleStations(txtSelectBFIFile.Text, SiteCodes);

                // archive the file if chosen and if not sending to test
                if (!SendToTest && Directory.Exists(db.GetConfigString("BFI.Export.ArchiveDir")))
                {
                    string archivedir = db.GetConfigString("BFI.Export.ArchiveDir");
                    string filenameonly = tools.StripDirectoryFromPath(txtSelectBFIFile.Text);
                    string NewFileName = archivedir + (archivedir.EndsWith("\\") ? "" : "\\") + filenameonly;
                    tools.RemoveFileWriteProtection(txtSelectBFIFile.Text);
                    File.Move(txtSelectBFIFile.Text, NewFileName);
                }
            }
        }

        private void ToggleSelection(bool SelectAll)
        {
            grid.EndEdit();
            foreach (DataGridViewRow row in grid.Rows)
                row.Cells[colInkluder.Index].Value = SelectAll;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BFIExportFrm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSelectBFIFile_Click(object sender, EventArgs e)
        {
            string LastDir = db.GetConfigString("BFI.Export.LastDir");
            if (LastDir != "")
                openFileDialog1.InitialDirectory = LastDir;
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                txtSelectBFIFile.Text = openFileDialog1.FileName;
                db.SetConfigString("BFI.Export.LastDir", tools.StripFilenameFromPath(txtSelectBFIFile.Text));
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Send(false);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            ToggleSelection(true);
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            ToggleSelection(false);
        }

        private void btnSendTest_Click(object sender, EventArgs e)
        {
            Send(true);
        }
    }
}