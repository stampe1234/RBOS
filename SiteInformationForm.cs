using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace RBOS
{
    public partial class SiteInformationForm : Form
    {
        // Constructor
        public SiteInformationForm()
        {
            InitializeComponent();
            LoadData();

            // restrict access to tabs
            if (UserLogon.ProfileID != AdminDataSet.UserProfilesDataTable.ProfileID.drs)
            {
                tabControl1.TabPages.Remove(tabBHHT);
                tabControl1.TabPages.Remove(tabRSM);
            }
        }

        #region LoadData
        private void LoadData()
        {
            // load sitinformation data (only one record)
            adapterSiteInformation.Connection = db.Connection;
            adapterSiteInformation.Fill(dsAdmin.SiteInformation);

            // load BHHT export config strings
            txtBHHTExportDir.Text = db.GetConfigString("BHHT_Export_Dir");
            txtBHHTExportBackupDir.Text = db.GetConfigString("BHHT_Export_dir_backup");
            chkBHHTExportBackupActive.Checked = db.GetConfigStringAsBool("BHHT_Export_Backup_Active");

            // load BHHT import config strings
            txtBHHTImportDir.Text = db.GetConfigString("BHHT_Import_Dir");
            txtBHHTImportBackupDir.Text = db.GetConfigString("BHHT_Import_dir_backup");
            chkBHHTImportBackupActive.Checked = db.GetConfigStringAsBool("BHHT_Import_Backup_Active");

            // load RSM export config strings
            txtRSMExportDir.Text = db.GetConfigString("NAXML_Export_Dir");
            txtRSMExportBackupDir.Text = db.GetConfigString("NAXML_Export_Dir_Backup");
            chkRSMExportBackupActive.Checked = db.GetConfigStringAsBool("NAXML_Export_Backup_Active");

            // load RSM import config strings
            txtRSMImportDir.Text = db.GetConfigString("NAXML_Import_Dir");
            txtRSMImportBackupDir.Text = db.GetConfigString("NAXML_Import_Dir_Backup");
            chkRSMImportBackupActive.Checked = db.GetConfigStringAsBool("NAXML_Import_Backup_Active");

            // load AutoCreateRBOSOrdersFromBHHT
            chkAutoCreateRBOSOrdersFromBHHT.Checked = db.GetConfigStringAsBool("AutoCreateRBOSOrdersFromBHHT");

            // load ACN values 20181009
            //chkACNEnabled.Checked = db.GetConfigStringAsBool("ACN_Enabled");
            //int Year, Week;
            //AdminDataSet.ACNExportHistoryDataTable.GetLastOkWeek(out Year, out Week);
            //txtACNLastExportedYear.Text = Year.ToString();
            //txtACNLastExportedWeek.Text = Week.ToString("00");

            // load readings values
            chkWashSeperateReadings.Checked = db.GetConfigStringAsBool("Readings.SeperateWashReadings");
            chkStationHasWash.Checked = db.GetConfigStringAsBool("Readings.StationHasWash");
            chkVaskeafstemning2.Checked = db.GetConfigStringAsBool("Readings.Vaskeafstemning2");
            chkVaskeafstemning3.Checked = db.GetConfigStringAsBool("Readings.Vaskeafstemning3");

            // load last generated payroll file values
            txtLastCreatedPrlFile_Period.Text = db.GetConfigString("Payroll.ExportFileCreated.Period");
            txtLastCreatedPrlFile_Year.Text = db.GetConfigString("Payroll.ExportFileCreated.PeriodYear");
            lbLastCreatedPrlFile_Timestamp.Text =
                db.GetConfigStringAsDateTime("Payroll.ExportFileCreated.Timestamp").ToString("dd-MM-yyyy HH:mm");

            // load standard debtor statement remarks
            txtStandardDebtorStatementRemarks.Text = db.GetConfigString("EOD.Debtor.Statement.StandardRemarks");

            // load SafePay data
            if (db.GetConfigStringAsBool("SafePay.Enabled"))
            {
                // kurser
                txtSafePay_ValutaISO_EURO.Text = EODDataSet.EOD_SafePay_ValutakurserDataTable.GetValutakurs(EODDataSet.EOD_SafePay_ValutakurserDataTable.ISOKode.EURO).ToString("00.00");
                txtSafePay_ValutaISO_NOK.Text = EODDataSet.EOD_SafePay_ValutakurserDataTable.GetValutakurs(EODDataSet.EOD_SafePay_ValutakurserDataTable.ISOKode.NOK).ToString("00.00");
                txtSafePay_ValutaISO_SEK.Text = EODDataSet.EOD_SafePay_ValutakurserDataTable.GetValutakurs(EODDataSet.EOD_SafePay_ValutakurserDataTable.ISOKode.SEK).ToString("00.00");

                // byttepenge optalt interval
                comboSafePayByttepengeOptaltInterval.Items.Add(db.GetLangString("SafePay.ByttepengeOptalt.CommoBox.Daily"));
                comboSafePayByttepengeOptaltInterval.Items.Add(db.GetLangString("SafePay.ByttepengeOptalt.CommoBox.Monthly"));
                comboSafePayByttepengeOptaltInterval.SelectedIndex = db.GetConfigStringAsBool("SafePay.ByttepengeOptalt.Daily") ? 0 : 1;
            }
            else // SafePay not enabled, hide the tab
            {
                tabControl1.TabPages.Remove(tabSafePay);
            }
            //load Economics 
            if ((db.GetConfigStringAsBool("Economics.Enabled")) & (db.GetConfigString("TokenLocal") ==""))
            {
                lblAftaleID.Text  = db.GetLangString("SiteInfoForm.Economics.ContractID");
                lblUserName.Text  = db.GetLangString("SiteInfoForm.Economics.UserName");
                lblPassword.Text  = db.GetLangString("SiteInfoForm.Economics.PassWord");
                tabEconomics.Text = db.GetLangString("SiteInfoForm.tabEconomics");
            }
            else
            {
                tabControl1.TabPages.Remove(tabEconomics);  
            }
        }
        #endregion

        #region SaveData
        private void SaveData()
        {
            // save siteinformation data
            bindingSiteInformation.EndEdit();
            adapterSiteInformation.Update(dsAdmin.SiteInformation);

            // save BHHT export config strings
            db.SetConfigString("BHHT_Export_Dir", txtBHHTExportDir.Text);
            db.SetConfigString("BHHT_Export_dir_backup", txtBHHTExportBackupDir.Text);
            db.SetConfigString("BHHT_Export_Backup_Active", chkBHHTExportBackupActive.Checked.ToString());

            // save BHHT import config strings
            db.SetConfigString("BHHT_Import_Dir", txtBHHTImportDir.Text);
            db.SetConfigString("BHHT_Import_dir_backup", txtBHHTImportBackupDir.Text);
            db.SetConfigString("BHHT_Import_Backup_Active", chkBHHTImportBackupActive.Checked.ToString());

            // save RSM export config strings
            db.SetConfigString("NAXML_Export_Dir", txtRSMExportDir.Text);
            db.SetConfigString("NAXML_Export_Dir_Backup", txtRSMExportBackupDir.Text);
            db.SetConfigString("NAXML_Export_Backup_Active", chkRSMExportBackupActive.Checked.ToString());

            // save RSM import config strings
            db.SetConfigString("NAXML_Import_Dir", txtRSMImportDir.Text);
            db.SetConfigString("NAXML_Import_Dir_Backup", txtRSMImportBackupDir.Text);
            db.SetConfigString("NAXML_Import_Backup_Active", chkRSMImportBackupActive.Checked.ToString());

            // save AutoCreateRBOSOrdersFromBHHT
            db.SetConfigString("AutoCreateRBOSOrdersFromBHHT", chkAutoCreateRBOSOrdersFromBHHT.Checked.ToString());

            // save ACN values
            db.SetConfigString("ACN_Enabled", chkACNEnabled.Checked);

            // save readings values
            db.SetConfigString("Readings.SeperateWashReadings", chkWashSeperateReadings.Checked);
            db.SetConfigString("Readings.StationHasWash", chkStationHasWash.Checked);
            db.SetConfigString("Readings.Vaskeafstemning2", chkVaskeafstemning2.Checked);
            db.SetConfigString("Readings.Vskeafstemning3", chkVaskeafstemning3.Checked);

            // save standard debtor statement remarks
            db.SetConfigString("EOD.Debtor.Statement.StandardRemarks", txtStandardDebtorStatementRemarks.Text);

            // save SafePay data
            if (db.GetConfigStringAsBool("SafePay.Enabled"))
            {
                // valutakurser
                EODDataSet.EOD_SafePay_ValutakurserDataTable.UpdateValutakurs(
                    EODDataSet.EOD_SafePay_ValutakurserDataTable.ISOKode.EURO, tools.object2double(txtSafePay_ValutaISO_EURO.Text));
                EODDataSet.EOD_SafePay_ValutakurserDataTable.UpdateValutakurs(
                    EODDataSet.EOD_SafePay_ValutakurserDataTable.ISOKode.NOK, tools.object2double(txtSafePay_ValutaISO_NOK.Text));
                EODDataSet.EOD_SafePay_ValutakurserDataTable.UpdateValutakurs(
                    EODDataSet.EOD_SafePay_ValutakurserDataTable.ISOKode.SEK, tools.object2double(txtSafePay_ValutaISO_SEK.Text));

                // byttepenge optalt interval
                if (comboSafePayByttepengeOptaltInterval.SelectedIndex == 0)
                    db.SetConfigString("SafePay.ByttepengeOptalt.Daily", true);
                else
                    db.SetConfigString("SafePay.ByttepengeOptalt.Daily", false);
            }
        }
        #endregion

        #region CheckDirectory
        /// <summary>
        /// Checks if the directory specified in
        /// the given textbox (sender) exists.
        /// If not an error message is shown.
        /// </summary>
        /// <param name="sender">A TextBox.</param>
        private void CheckDirectory(object sender)
        {
            if (sender is TextBox)
            {
                string dir = ((TextBox)sender).Text;
                if ((dir != "") && !Directory.Exists(dir))
                {
                    MessageBox.Show(db.GetLangString("SiteInformationForm.SpecifyExistingDir"));
                    if (((TextBox)sender).CanFocus)
                        ((TextBox)sender).Focus();
                }
            }
        }
        #endregion

        #region SelectDirectory
        /// <summary>
        /// Opens a folder browser dialog and if user
        /// selects a directory, that directory is inserted
        /// into the provided textbox. Existing text in the
        /// textbox is used as the startup selected directory
        /// for the folder browser dialog.
        /// </summary>
        /// <param name="textbox">
        /// TextBox to write selected directory to.
        /// </param>
        private void SelectDirectory(object textbox)
        {
            folder.SelectedPath = ((TextBox)textbox).Text;
            if (folder.ShowDialog() == DialogResult.OK)
                ((TextBox)textbox).Text = folder.SelectedPath;
        }
        #endregion

        private void SiteInformation_Load(object sender, EventArgs e)
        {
            // Localization
            tabGeneral.Text = db.GetLangString("SiteInfoForm.TabGeneralLabel");
#if DETAIL
            lbSiteCode.Text = db.GetLangString("SiteInfoForm.SiteCodeLabel.Butik");
#else
            lbSiteCode.Text = db.GetLangString("SiteInfoForm.SiteCodeLabel");
#endif
            lbSiteName.Text = db.GetLangString("SiteInfoForm.SiteNameLabel");
            lbAddress1.Text = db.GetLangString("SiteInfoForm.Address1Label");
            lbAddress2.Text = db.GetLangString("SiteInfoForm.Address2Label");
            lbZipCity.Text = db.GetLangString("SiteInfoForm.ZipCityLabel");
            lbTelephone.Text = db.GetLangString("SiteInfoForm.TelephoneLabel");
            lbFaxNo.Text = db.GetLangString("SiteInfoForm.FaxNoLabel");
            lbSENo.Text = db.GetLangString("SiteInfoForm.SENoLabel");
            lbNorddataKundenr.Text = db.GetLangString("SiteInfoForm.NorddataKundenrLabel");
            lbACNLastExported.Text = db.GetLangString("SiteInfoForm.lbACNLastExported");
            chkACNEnabled.Text = db.GetLangString("SiteInfoForm.chkACNEnabled");
            groupACN.Text = db.GetLangString("SiteInfoForm.groupACN");
            lbBankAccount.Text = db.GetLangString("SiteInfoForm.BankAccount");
            chkWashSeperateReadings.Text = db.GetLangString("SiteInfoForm.Readings.SeperateWashReadings");
            chkStationHasWash.Text = db.GetLangString("SiteInfoForm.Readings.StationHasWash");
            chkVaskeafstemning2.Text = db.GetLangString("SiteInfoForm.Readings.Vaskeafstemning2");
            chkVaskeafstemning3.Text = db.GetLangString("SiteInfoForm.Readings.Vaskeafstemning3");
            groupLastCreatedPrlFile.Text = db.GetLangString("SiteInfoForm.groupLastCreatedPrlFile");
            lbLastCreatedPrlFile.Text = db.GetLangString("SiteInfoForm.lbLastCreatedPrlFile");           
            btnCancel.Text = db.GetLangString("Application.Cancel");
            btnSaveClose.Text = db.GetLangString("Application.SaveClose");
            tabMisc.Text = db.GetLangString("SiteInfoForm.tabMisc");
            groupReadings.Text = db.GetLangString("SiteInfoForm.groupReadings");
            chkWashSeperateReadings.Text = db.GetLangString("SiteInfoForm.chkWashSeperateReadings");
            chkStationHasWash.Text = db.GetLangString("SiteInfoForm.chkStationHasWash");
            chkVaskeafstemning2.Text = db.GetLangString("SiteInfoForm.chkVaskeafstemning2");
            chkVaskeafstemning3.Text = db.GetLangString("SiteInfoForm.chkVaskeafstemning3");
            lbStandardDebtorStatementRemarks.Text = db.GetLangString("SiteInformationForm.StandardDebtorStatementRemarks");
            groupDebtor.Text = db.GetLangString("SiteInformationForm.groupDebtor");
            GroupSafePayValutakurser.Text = db.GetLangString("SiteInformationForm.GroupSafePayValutakurser");
            lbSafePayByttepengeOptaltInterval.Text = db.GetLangString("SiteInformationForm.lbSafePayByttepengeOptInterval");
            tabSafePay.Text = db.GetLangString("SiteInformationForm.tabSafePay");
#if RBA
            txtSENo.Visible = false;
            lbSENo.Visible = false;
            txtBankAccount.Visible = false;
            lbBankAccount.Visible = false;
            txtNorddataKundenr.Visible = false;
            lbNorddataKundenr.Visible = false;
            groupReadings.Top = groupACN.Top;
            groupACN.Visible = false;
#else
            groupReadings.Visible = false;
#endif
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            // save data and close form
            SaveData();
            Close();
        }

        private void txtSiteCode_Validating(object sender, CancelEventArgs e)
        {
            // check for valid site code
            Regex regex = new Regex("^([0-9]{4})$");
            if (regex.Match(txtSiteCode.Text).Success == false)
            {
                MessageBox.Show(db.GetLangString("SiteInformationForm.SiteCodeMustBe4Digits"));
                e.Cancel = true;
            }
        }

        private void txtBHHTExportDir_Leave(object sender, EventArgs e)
        {
            CheckDirectory(sender);
        }

        private void txtBHHTExportBackupDir_Leave(object sender, EventArgs e)
        {
            CheckDirectory(sender);
        }

        private void txtBHHTImportDir_Leave(object sender, EventArgs e)
        {
            CheckDirectory(sender);
        }

        private void txtBHHTImportBackupDir_Leave(object sender, EventArgs e)
        {
            CheckDirectory(sender);
        }

        private void txtRSMExportDir_Leave(object sender, EventArgs e)
        {
            CheckDirectory(sender);
        }

        private void txtRSMExportBackupDir_Leave(object sender, EventArgs e)
        {
            CheckDirectory(sender);
        }

        private void txtRSMImportDir_Leave(object sender, EventArgs e)
        {
            CheckDirectory(sender);
        }

        private void txtRSMImportBackupDir_Leave(object sender, EventArgs e)
        {
            CheckDirectory(sender);
        }

        private void btnBHHTExportDir_Click(object sender, EventArgs e)
        {
            SelectDirectory(txtBHHTExportDir);
        }

        private void btnBHHTExportBackupDir_Click(object sender, EventArgs e)
        {
            SelectDirectory(txtBHHTExportBackupDir);
        }

        private void btnBHHTImportDir_Click(object sender, EventArgs e)
        {
            SelectDirectory(txtBHHTImportDir);
        }

        private void btnBHHTImportBackupDir_Click(object sender, EventArgs e)
        {
            SelectDirectory(txtBHHTImportBackupDir);
        }

        private void btnRSMExportDir_Click(object sender, EventArgs e)
        {
            SelectDirectory(txtRSMExportDir);
        }

        private void btnRSMExportBackupDir_Click(object sender, EventArgs e)
        {
            SelectDirectory(txtRSMExportBackupDir);
        }

        private void btnRSMImportDir_Click(object sender, EventArgs e)
        {
            SelectDirectory(txtRSMImportDir);
        }

        private void btnRSMImportBackupDir_Click(object sender, EventArgs e)
        {
            SelectDirectory(txtRSMImportBackupDir);
        }

        private void txtSiteCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bindingSiteInformation_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}