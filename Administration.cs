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
    public partial class Administration : Form
    {
        private bool ClosedByButton = false;
        private bool OpeningWindow = true;

        public Administration()
        {
            InitializeComponent();

#if RBA
            tabControl1.TabPages.Remove(tabModulesDO);
#else
            tabControl1.TabPages.Remove(tabModulesRBA);
#endif
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ClosedByButton = true;
            Close();
        }

        private void Administration_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ClosedByButton)
            {
                e.Cancel = true;
                MessageBox.Show(db.GetLangString("Application.UseCloseButton"));
                return;
            }
        }

        private void tabModulesDO_Enter(object sender, EventArgs e)
        {
            // load data for the DO modules tab

            chkItemsEnabled.Checked = db.GetConfigStringAsBool("Items.Enabled");

            chkVPRGmodule.Checked = db.GetConfigStringAsBool("VPRG.Enabled");
            comboRegnskabIF.SelectedItem = db.GetConfigString("RegnskabIF_flag");
            chkActivatePayrollModule.Checked = db.GetConfigStringAsBool("PayrollModuleActive");
            
            chkSafePayEnabled.Checked = db.GetConfigStringAsBool("SafePay.Enabled");
            chkSafePayOverfoerselTilSPManualInput.Checked = db.GetConfigStringAsBool("SafePay.OverfoerselTilSP.ManuelIndtastning");
            chkSafePayUdbetalingerManualInput.Checked = db.GetConfigStringAsBool("SafePay.Udbetalinger.ManuelIndtastning");
            chkSafePayIndbetalingerManualInput.Checked = db.GetConfigStringAsBool("SafePay.Indbetalinger.ManuelIndtastning");
            chkEconomics.Checked = db.GetConfigStringAsBool("Economics.Enabled");
            ToggleSafePayControls();

            chkSubtractAbsenseOnFuncWith0HoursDO.Checked = db.GetConfigStringAsBool("SubtractAbsenseOnFuncWith0Hours");
        }

        private void OpenManualUpdatesFormIfUpdatesPresent()
        {
            // if any manual updates are present, show ManualUpdatesForm
            ManualUpdatesForm muf = new ManualUpdatesForm();
            if (muf.ManualUpdatesPresent)
                muf.ShowDialog();
        }

        private void chkActivatePayrollModule_CheckedChanged(object sender, EventArgs e)
        {
            if (!OpeningWindow)
            {
                db.SetConfigString("PayrollModuleActive", chkActivatePayrollModule.Checked);

                if (this.Owner is MainForm)
                {
                    MainForm frm = (MainForm)this.Owner;
                    frm.BuildTreeMenu(db.Language);
                }

                if (chkActivatePayrollModule.Checked)
                    OpenManualUpdatesFormIfUpdatesPresent();
            }
        }

        private void comboRegnskabIF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!OpeningWindow)
                db.SetConfigString("RegnskabIF_flag", comboRegnskabIF.SelectedItem.ToString());
        }

        private void chkVPRGmodule_CheckedChanged(object sender, EventArgs e)
        {
            if (!OpeningWindow)
            {
                db.SetConfigString("VPRG.Enabled", chkVPRGmodule.Checked);
                if (chkVPRGmodule.Checked)
                    OpenManualUpdatesFormIfUpdatesPresent();
            }
        }

        private void tabConfigTable_Enter(object sender, EventArgs e)
        {
            // load config data on tab enter
            configTableAdapter.Connection = db.Connection;
            configTableAdapter.Fill(adminDataSet.config);
        }

        private void tabConfigTable_Leave(object sender, EventArgs e)
        {
            // save config data on tab leave
            configTableAdapter.Update(adminDataSet.config);
        }

        private void btnDecryptEODFile_Click(object sender, EventArgs e)
        {
            // only drs are allowed to do this
            if (UserLogon.ProfileID != AdminDataSet.UserProfilesDataTable.ProfileID.drs)
                return;

            // decrypt eod file (for testing the Encryption class)
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(dialog.FileName, tools.Encoding());
                string newfilename = dialog.FileName.Replace(".EOD", ".TXT");
                System.IO.StreamWriter writer = new System.IO.StreamWriter(newfilename, false, tools.Encoding());
                string header = "";
                int lineno = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    ++lineno;

                    // write header
                    if (line.Substring(0, 4) == "1000")
                    {
                        header = line;
                        writer.WriteLine(header);
                    }
                    else
                    {
                        // write records
                        writer.Write(line.Substring(0, 4));
                        writer.WriteLine(EncryptionAccounting.DecryptString(line.Substring(4), lineno, header));
                    }
                }

                reader.Close();
                writer.Close();

                // open decrypted EOD file
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.FileName = newfilename;
                process.Start();
            }
        }

        private bool MigrateSSIPData()
        {
            if (db.GetConfigStringAsBool("SSIPMigrated"))
            {
                MessageBox.Show("SSIP data er allerede markeret som migreret. Fjern markeringen først.");
                return false;
            }

            bool result = true;

            // select ssip mdb file
            OpenFileDialog files = new OpenFileDialog();
            files.Title = "Vælg SSIP mdb-fil";
            files.RestoreDirectory = true;
            if (files.ShowDialog() == DialogResult.OK)
            {
                // migrér data
                db.StartTransaction();
                MigrateSSIP migrate = new MigrateSSIP(files.FileName);
                if (chkIncRBAloen.Checked && result)
                    result = migrate.MigratePayroll();
#if RBA
                if (chkIncRBAdagsopg.Checked && result)
                    result = migrate.MigrateEOD();
                if (chkIncRBAbudget.Checked && result)
                    result = migrate.MigrateBudget();
                if (chkIncRBAdebitor.Checked && result)
                    result = migrate.MigrateDebtor();
                if (chkIncRBAstation.Checked && result)
                    result = migrate.MigrateStationAndConfig();
                if (chkIncRBAaflaesninger.Checked && result)
                    result = migrate.MigrateReadings();
                if (chkIncRBAvask.Checked && result)
                    result = migrate.MigrateWash();
#endif
                // afslut efter migrering
                if (result)
                {
                    db.SetConfigString("SSIPMigrated", true);
                    db.CommitTransaction();
                    MessageBox.Show("Migrering fuldført");
                }
                else
                {
                    if (db.CurrentTransaction != null)
                        db.RollbackTransaction();
                    MessageBox.Show(migrate.LastMsg);
                }
            }

            return result;
        }

        private void ToggleSafePayControls()
        {
#if RBA
            chkSafePayOverfoerselTilSPManualInputRBA.Enabled = chkSafePayEnabledRBA.Checked;
            chkSafePayUdbetalingerManualInputRBA.Enabled = chkSafePayEnabledRBA.Checked;
            chkSafePayIndbetalingerManualInputRBA.Enabled = chkSafePayEnabledRBA.Checked;
#else

            chkSafePayOverfoerselTilSPManualInput.Enabled = chkSafePayEnabled.Checked;
            chkSafePayUdbetalingerManualInput.Enabled = chkSafePayEnabled.Checked;
            chkSafePayIndbetalingerManualInput.Enabled = chkSafePayEnabled.Checked;
#endif
        }

        private void Administration_Load(object sender, EventArgs e)
        {
#if RBA
            tabModulesRBA_Enter(null, null);
#else
            tabModulesDO_Enter(null, null);
#endif
            OpeningWindow = false;
            chkEconomics.Text = db.GetLangString("Administration.Economics"); 
        }

        private void tabModulesRBA_Enter(object sender, EventArgs e)
        {
            // load data for the RBA modules tab
            chkOvertimeVisible.Checked = db.GetConfigStringAsBool("Payroll.OvertimeVisible");
            chkTakeTimeOffVisible.Checked = db.GetConfigStringAsBool("Payroll.TakeTimeOffVisible");
            
            chkSafePayEnabledRBA.Checked = db.GetConfigStringAsBool("SafePay.Enabled");
            chkSafePayOverfoerselTilSPManualInputRBA.Checked = db.GetConfigStringAsBool("SafePay.OverfoerselTilSP.ManuelIndtastning");
            chkSafePayUdbetalingerManualInputRBA.Checked = db.GetConfigStringAsBool("SafePay.Udbetalinger.ManuelIndtastning");
            chkSafePayIndbetalingerManualInputRBA.Checked = db.GetConfigStringAsBool("SafePay.Indbetalinger.ManuelIndtastning");
            ToggleSafePayControls();

            chkSubtractAbsenseOnFuncWith0HoursRBA.Checked = db.GetConfigStringAsBool("SubtractAbsenseOnFuncWith0Hours");
        }

        private void chkOvertimeVisible_CheckedChanged(object sender, EventArgs e)
        {
            db.SetConfigString("Payroll.OvertimeVisible", chkOvertimeVisible.Checked);
        }

        private void chkTakeTimeOffVisible_CheckedChanged(object sender, EventArgs e)
        {
            db.SetConfigString("Payroll.TakeTimeOffVisible", chkTakeTimeOffVisible.Checked);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Er du sikker på, at du vil genberegne lagerbeholdning på alle varer?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    db.StartTransaction();
                    ItemDataSet.ItemDataTable.ReCalculateInStockAllItems();
                    db.CommitTransaction();
                    MessageBox.Show("Færdig");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(log.WriteException("Genberegning af varebeholding på alle varer", ex.Message, ex.StackTrace));
                db.RollbackTransaction();
            }
        }

        private void btnCheckDuplicateFSDID_Click(object sender, EventArgs e)
        {
            if (ItemDataSet.ItemDataTable.HasItemsWithDuplicateFSD_IDs())
            {
                string filename = ItemDataSet.ItemDataTable.WriteDRSItemLog_DuplicateFSD_IDs("Admin interface", false);
                MessageBox.Show("Der er varer med samme FSD_ID. Logfil er skrevet og ligger her:\n" + System.IO.Directory.GetCurrentDirectory() + "\\" + filename);
            }
            else
            {
                MessageBox.Show("Der er ingen varer med samme FSD_ID");
            }
        }

        private void chkSafePayEnabled_CheckedChanged(object sender, EventArgs e)
        {
            db.SetConfigString("SafePay.Enabled", (sender as CheckBox).Checked);
            ToggleSafePayControls();
        }

        private void chkSafePayOverfoerselTilSPManualInput_CheckedChanged(object sender, EventArgs e)
        {
            db.SetConfigString("SafePay.OverfoerselTilSP.ManuelIndtastning", (sender as CheckBox).Checked);
        }

        private void chkSafePayUdbetalingerManualInput_CheckedChanged(object sender, EventArgs e)
        {
            db.SetConfigString("SafePay.Udbetalinger.ManuelIndtastning", (sender as CheckBox).Checked);
        }

        private void chkSafePayIndbetalingerManualInput_CheckedChanged(object sender, EventArgs e)
        {
            db.SetConfigString("SafePay.Indbetalinger.ManuelIndtastning", (sender as CheckBox).Checked);
        }

        private void chkSafePayEnabledRBA_CheckedChanged(object sender, EventArgs e)
        {
            db.SetConfigString("SafePay.Enabled", (sender as CheckBox).Checked);
            ToggleSafePayControls();
        }

        private void chkSafePayOverfoerselTilSPManualInputRBA_CheckedChanged(object sender, EventArgs e)
        {
            db.SetConfigString("SafePay.OverfoerselTilSP.ManuelIndtastning", (sender as CheckBox).Checked);
        }

        private void chkSafePayUdbetalingerManualInputRBA_CheckedChanged(object sender, EventArgs e)
        {
            db.SetConfigString("SafePay.Udbetalinger.ManuelIndtastning", (sender as CheckBox).Checked);
        }

        private void chkSafePayIndbetalingerManualInputRBA_CheckedChanged(object sender, EventArgs e)
        {
            db.SetConfigString("SafePay.Indbetalinger.ManuelIndtastning", (sender as CheckBox).Checked);
        }

        private void chkItemsEnabled_CheckedChanged(object sender, EventArgs e)
        {
            db.SetConfigString("Items.Enabled", chkItemsEnabled.Checked);
        }

        private void btnKlargoerTilSQLServer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Er du sikker på, at du vil klargøre databasen til SQL Server?\r\nDatabasen kan ikke bruges i denne version af RBOS efterfølgende.\r\n\r\nRBOS lukkes bagefter.", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            string msg;
            if (!db.PrepareDatabaseForSQLServer(out msg))
                MessageBox.Show(msg);
            else
            {
                MessageBox.Show("Databasen er nu klar til SQL Server. RBOS lukkes nu.");
                btnClose_Click(this, new EventArgs());
                Application.Exit();
            }
        }

        private void btnExportDisktilbudDTV_Click(object sender, EventArgs e)
        {
            ExportDTV export = new ExportDTV();
            if (export.Export(dtExportDisktilbudDTV.Value, true))
                MessageBox.Show("DTV fil dannet");
            else
                MessageBox.Show(export.LastError);
        }

        private void btnExportVGS_Click(object sender, EventArgs e)
        {
            int Month = tools.object2int(numVGSMonth.Value);
            int Year = tools.object2int(numVGSYear.Value);
            ExportVGS vgs = new ExportVGS();
            if (vgs.Export(Month, Year))
                MessageBox.Show("VGS fil dannet");
            else
                MessageBox.Show(vgs.LastError);                
        }

        private void tabMisc_Enter(object sender, EventArgs e)
        {
            numVGSMonth.Value = DateTime.Now.Month;
            numVGSYear.Value = DateTime.Now.Year;
        }

        private void btnChangeBankcToShellc_Click(object sender, EventArgs e)
        {
            if (ImportDataSet.Import_RPOS_MSM_ConfigDataTable.ChangeBankcToShellc())
                MessageBox.Show("Udført");
            else
                MessageBox.Show(ImportDataSet.Import_RPOS_MSM_ConfigDataTable.LastError);
        }

        private void btnRestoreBankcFromShellc_Click(object sender, EventArgs e)
        {
            if (ImportDataSet.Import_RPOS_MSM_ConfigDataTable.RestoreBankcFromShellc())
                MessageBox.Show("Udført");
            else
                MessageBox.Show(ImportDataSet.Import_RPOS_MSM_ConfigDataTable.LastError);
        }

        private void chkSubtractAbsenseOnFuncWith0HoursDO_CheckedChanged(object sender, EventArgs e)
        {
            db.SetConfigString("SubtractAbsenseOnFuncWith0Hours", chkSubtractAbsenseOnFuncWith0HoursDO.Checked);
        }

        private void chkSubtractAbsenseOnFuncWith0HoursRBA_CheckedChanged(object sender, EventArgs e)
        {
            db.SetConfigString("SubtractAbsenseOnFuncWith0Hours", chkSubtractAbsenseOnFuncWith0HoursRBA.Checked);
        }

        private void btnRecalcDisktilbud_Click(object sender, EventArgs e)
        {
            ImportRSM importer = new ImportRSM();
            bool ErrorsInDisktilbud;
            if (!importer.ReImportPEJFilesFromBackup(dtRecalcDisktilbudFrom.Value, dtRecalcDisktilbudTo.Value, out ErrorsInDisktilbud))
                MessageBox.Show(importer.LastError);
            else
            {
                if (ErrorsInDisktilbud)
                    MessageBox.Show("Genberegningen er gennemført, men der var fejl i disktilbud data. Se log-filen for mere information");
                else
                    MessageBox.Show("Genberegningen er gennemført");
            }
        }

        private void btnDelete2Pak_Click(object sender, EventArgs e)
        {
            // sletter alle 2-pak salgspakninger, hvor der er andre salgspakninger på varen.
            // der udføres alle de handlinger, som der ville, hvis man slettede manuelt i brugergrænsefladen.
            if (MessageBox.Show(this, "Er du sikker på at du vil semidelete alle 2-pak salgspakninger?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (ItemDataSet.SalesPackDataTable.Delete2PakRecords())
                    MessageBox.Show("2-pak salgspakninger er blevet semideleted.");
            }
        }

        

        private void chkEconomics_CheckStateChanged(object sender, EventArgs e)
        {
            db.SetConfigString("Economics.Enabled", chkEconomics.Checked);
        }
    }
}