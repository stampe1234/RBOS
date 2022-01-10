using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class ImportEconomicsForm : Form
    {
        public ImportEconomicsForm()
        {
            InitializeComponent();
        }

        private void ImportEconomicsForm_Load(object sender, EventArgs e)
        {
            btnImportAll.Text = db.GetLangString("ImportEconomicsForm.Import");
            btnImportSince.Text = db.GetLangString("ImportEconomicsForm.btnImportSince");
            btnClose.Text = db.GetLangString("ImportEconomicsForm.Close");
            lbStatus.Text = db.GetLangString("ImportEconomicsForm.StatusStart");
            lbImportAll.Text = db.GetLangString("ImportEconomicsForm.lbImportAll");
            lbImportSince.Text = db.GetLangString("ImportEconomicsForm.lbImportSince");

            // sæt datetime picker til seneste dato hentet, og hvis
            // der ikke er en dato i databasen, så disable dattime picker og knappen til den
            DateTime SenesteDatoHentet = db.GetConfigStringAsDateTime("ImportEconomics.SenesteDatoHentet").Date;
            if (SenesteDatoHentet == DateTime.MinValue)
            {
                // bortset fra, at hvis man er drs bruger, har man felterne alligevel
                if (UserLogon.ProfileID != AdminDataSet.UserProfilesDataTable.ProfileID.drs)
                {
                    dtImportSince.Enabled = false;
                    btnImportSince.Enabled = false;
                }
            }
            else
            {
                dtImportSince.Value = SenesteDatoHentet;
            }
        }

        private void CommonImportClickHandler(object sender, EventArgs e)
        {
            DateTime SenesteDatoHentet = sender == btnImportAll ? DateTime.MinValue : dtImportSince.Value.Date;
            int AntalDebitorer;
            lbStatus.Text = lbStatus.Text = db.GetLangString("ImportEconomicsForm.StatusImport"); 
            this.Update();
            this.Cursor = Cursors.WaitCursor;
            ImportEconomics ImportEco = new ImportEconomics();
            AntalDebitorer = ImportEco.ImportDebitor(SenesteDatoHentet);
            this.Cursor = Cursors.Default;
            if (AntalDebitorer == -1 )
            {
                lbStatus.Text = lbStatus.Text = db.GetLangString("ImportEconomicsForm.StatusError"); 
            }
            else
            {
                lbStatus.Text = AntalDebitorer.ToString() +  db.GetLangString("ImportEconomicsForm.StatusSuccess");  
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}