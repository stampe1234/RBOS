using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace RBOS
{
    public partial class BackupFrm : Form
    {
        private string OriginalExternalDir = "";
        private bool OkToClose = false;

        public BackupFrm()
        {
            InitializeComponent();
            LoadData();

            // localization
            btnBackup.Text = db.GetLangString("BackupFrm.btnBackup");
            btnClose.Text = db.GetLangString("Application.Close");
            chkCompressDB.Text = db.GetLangString("BackupFrm.chkCompressDB");
            chkLocal.Text = db.GetLangString("BackupFrm.chkLocal");
            chkNetwork.Text = db.GetLangString("BackupFrm.chkNetwork");
            chkExternal.Text = db.GetLangString("BackupFrm.chkExternal");
            lbLocalDir.Text = db.GetLangString("BackupFrm.lbDir");
            lbNetworkDir.Text = db.GetLangString("BackupFrm.lbDir");
            lbExternalDir.Text = db.GetLangString("BackupFrm.lbDir");
            chkLocalAuto.Text = db.GetLangString("BackupFrm.chkAuto");
            chkNetworkAuto.Text = db.GetLangString("BackupFrm.chkAuto");
            chkLocalZip.Text = db.GetLangString("BackupFrm.chkZip");
            chkNetworkZip.Text = db.GetLangString("BackupFrm.chkZip");
            chkExternalZip.Text = db.GetLangString("BackupFrm.chkZip");
            lbExternalBackupInterval.Text = db.GetLangString("BackupFrm.lbExternalBackupInterval");
            lbLastExternalBackup.Text = db.GetLangString("BackupFrm.lbLastExternalBackup");
        }

        private void LoadData()
        {
            // load backup interval lookup data
            adapterLookupBackupInterval.Connection = db.Connection;
            adapterLookupBackupInterval.Fill(adminDataSet.LookupBackupInterval);

            // load general settings
            chkCompressDB.Checked = db.GetConfigStringAsBool("Backup_CompressDB");

            // load local settings
            chkLocal.Checked = db.GetConfigStringAsBool("Backup_LocalEnabled");
            txtLocalDir.Text = db.GetConfigString("Backup_LocalDir");
            chkLocalAuto.Checked = db.GetConfigStringAsBool("Backup_LocalAuto");
            chkLocalZip.Checked = db.GetConfigStringAsBool("Backup_LocalZip");

            // load network settings
            chkNetwork.Checked = db.GetConfigStringAsBool("Backup_NetworkEnabled");
            txtNetworkDir.Text = db.GetConfigString("Backup_NetworkDir");
            chkNetworkAuto.Checked = db.GetConfigStringAsBool("Backup_NetworkAuto");
            chkNetworkZip.Checked = db.GetConfigStringAsBool("Backup_NetworkZip");

            // load external settings
            chkExternal.Checked = db.GetConfigStringAsBool("Backup_ExternalEnabled");
            txtExternalDir.Text = db.GetConfigString("Backup_ExternalDir");
            chkExternalZip.Checked = db.GetConfigStringAsBool("Backup_ExternalZip");
            txtLastExternalBackup.Text = db.GetConfigStringAsDateTime("Backup_LastExternalBackup").ToString("dd-MM-yyyy");
            comboExternalBackupInterval.SelectedValue = db.GetConfigStringAsInt("Backup_ExternalBackupInterval");

            // save original dirs
            OriginalExternalDir = txtExternalDir.Text;

            // enable/disable groups
            ToggleLocalGroup();
            ToggleNetworkGroup();
            ToggleExternalGroup();
        }

        private void SaveData()
        {
            // save general settings
            db.SetConfigString("Backup_CompressDB", chkCompressDB.Checked);

            // save local settings
            db.SetConfigString("Backup_LocalEnabled", chkLocal.Checked);
            db.SetConfigString("Backup_LocalAuto", chkLocalAuto.Checked);
            db.SetConfigString("Backup_LocalZip", chkLocalZip.Checked);

            // save network settings
            db.SetConfigString("Backup_NetworkEnabled", chkNetwork.Checked);
            db.SetConfigString("Backup_NetworkDir", txtNetworkDir.Text);
            db.SetConfigString("Backup_NetworkAuto", chkNetworkAuto.Checked);
            db.SetConfigString("Backup_NetworkZip", chkNetworkZip.Checked);

            // save external settings
            db.SetConfigString("Backup_ExternalEnabled", chkExternal.Checked);
            db.SetConfigString("Backup_ExternalDir", txtExternalDir.Text);
            db.SetConfigString("Backup_ExternalZip", chkExternalZip.Checked);
            db.SetConfigString("Backup_ExternalBackupInterval",
                tools.object2int(comboExternalBackupInterval.SelectedValue));
        }

        private void ToggleLocalGroup()
        {
            lbLocalDir.Enabled = chkLocal.Checked;
            txtLocalDir.Enabled = chkLocal.Checked;
            chkLocalAuto.Enabled = chkLocal.Checked;
            // chkLocalZip.Enabled = chkLocal.Checked; // disabled until implemented
        }

        private void ToggleNetworkGroup()
        {
            lbNetworkDir.Enabled = chkNetwork.Checked;
            txtNetworkDir.Enabled = chkNetwork.Checked;
            chkNetworkAuto.Enabled = chkNetwork.Checked;
            // chkNetworkZip.Enabled = chkNetwork.Checked; // disabled until implemented
        }

        private void ToggleExternalGroup()
        {
            lbExternalDir.Enabled = chkExternal.Checked;
            txtExternalDir.Enabled = chkExternal.Checked;
            btnExternalDir.Enabled = chkExternal.Checked;
            // chkExternalZip.Enabled = chkExternal.Checked; // disabled until implemented
        }

        private void ValidateExternalDir()
        {
            // check for valid external dir
            if (!Directory.Exists(txtExternalDir.Text))
            {
                MessageBox.Show(db.GetLangString("BackupFrm.ExternalLocationDoesNotExist"));
                txtExternalDir.Text = OriginalExternalDir;
                return;
            }
            else
            {
                // external dir validated, keep as original dir
                OriginalExternalDir = txtExternalDir.Text;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OkToClose = true;
            Close();
        }

        private void BackupFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Backup.BackupRunning)
            {
                MessageBox.Show(db.GetLangString("BackupFrm.BackupRunningPleaseWait"));
                e.Cancel = true;
                return;
            }
            else if (OkToClose)
            {
                SaveData();
                return;
            }
            else
            {
                MessageBox.Show(db.GetLangString("Application.UseCloseButton"));
                e.Cancel = true;
                return;
            }
        }

        private void chkLocal_CheckedChanged(object sender, EventArgs e)
        {
            ToggleLocalGroup();
        }

        private void chkNetwork_CheckedChanged(object sender, EventArgs e)
        {
            ToggleNetworkGroup();
        }

        private void chkExternal_CheckedChanged(object sender, EventArgs e)
        {
            ToggleExternalGroup();
        }

        private void btnExternalDir_Click(object sender, EventArgs e)
        {
            // select external dir
            folders.SelectedPath = txtExternalDir.Text;
            if (folders.ShowDialog(this) == DialogResult.OK)
            {
                txtExternalDir.Text = folders.SelectedPath;
                ValidateExternalDir();
            }
        }

        private void txtExternalDir_Leave(object sender, EventArgs e)
        {
            ValidateExternalDir();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            SaveData();
            if (Backup.RunBackup(false, false))
            {
                txtLastExternalBackup.Text = db.GetConfigStringAsDateTime("Backup_LastExternalBackup").ToString("dd-MM-yyyy");
                if (Backup.LastMessage != "")
                    MessageBox.Show(Backup.LastMessage);
            }
            else
                MessageBox.Show(db.GetLangString("BackupFrm.BackupRunningPleaseWait"));
        }

        private void BackupFrm_Load(object sender, EventArgs e)
        {
        }
    }
}