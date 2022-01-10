using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace RBOS
{
    public partial class ImportRHTForm : Form
    {
        // constructor
        public ImportRHTForm()
        {
            InitializeComponent();
            ResetLabels();
            CalculateOpenRecords();
            CalculateOpenRecordsRegulation();
        }

        #region METHOD: ResetLabels
        /// <summary>
        /// Resets all labels on the form
        /// </summary>
        private void ResetLabels()
        {

            txtInvAdjustW.Text = "0";
            txtInvCount.Text = "0";
            txtShelfLabels.Text = "0";
            txtInvAdjustR.Text = "0";

            // open fields

            txtInvAdjustWOpen.Text = "0";
            txtInvCountOpen.Text = "0";
            txtInvAdjustROpen.Text = "0";
        }
        #endregion

        #region PROPERTY: StatusText
        /// <summary>
        /// Sets the status text of the control and updates the GUI.
        /// </summary>
        public string StatusText
        {
            set
            {
                status.Text = value;
                statusStrip1.Refresh();
            }
        }
        #endregion

        #region METHOD: CalculateOpenRecords
        private void CalculateOpenRecords()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);


            // inventory count
            cmd.CommandText =
                " select count(CountID) from BHHTInvCountHeader " +
                " where Status = 'OPN'";
            txtInvCountOpen.Text = tools.object2string(cmd.ExecuteScalar());
        }

        private void CalculateOpenRecordsRegulation()
        {
            OleDbCommand cmd = new OleDbCommand("", db.Connection);


            // Adjust count
            cmd.CommandText =
                " select count(AdjustID) from BHHTInvAdjustHeader " +
                " where Status = 'OPN' And ReasonCode = 'a'";
            txtInvAdjustROpen.Text = tools.object2string(cmd.ExecuteScalar());

            cmd.CommandText =
                " select count(AdjustID) from BHHTInvAdjustHeader " +
                " where ReasonCode = 'a'";
            txtInvAdjustR.Text = tools.object2string(cmd.ExecuteScalar());


            cmd.CommandText =
                " select count(AdjustID) from BHHTInvAdjustHeader " +
                " where Status = 'OPN' And ReasonCode = 'w'";
            txtInvAdjustWOpen.Text = tools.object2string(cmd.ExecuteScalar());

            cmd.CommandText =
                " select count(AdjustID) from BHHTInvAdjustHeader " +
                " where ReasonCode = 'w'";
            txtInvAdjustW.Text = tools.object2string(cmd.ExecuteScalar());
        }


        #endregion

        #region DELEGATE: DataFormClosing
        /// <summary>
        /// Delegate for when data forms are closing.
        /// We want to update data on this form, when any of the
        /// data forms closes.
        /// </summary>
        void DataFormClosing(object sender, FormClosingEventArgs e)
        {
            CalculateOpenRecords();
            CalculateOpenRecordsRegulation();
        }
        #endregion

        // close button click event
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // import button click event
        private void btnImport_Click(object sender, EventArgs e)
        {
            ImportRHT importer = new ImportRHT();
            if (importer.ImportBHE(this))
            {

                txtInvAdjustW.Text = importer.ImportedInvAdjustW.ToString();
                txtInvCount.Text = importer.ImportedInvCount.ToString();
                txtInvAdjustR.Text = importer.ImportedInvAdjustR.ToString();
                txtShelfLabels.Text = importer.ImportedShelfLabel.ToString();
                MessageBox.Show("Import færdig");
            }
            else
                MessageBox.Show(importer.LastError);

            CalculateOpenRecords();
            CalculateOpenRecordsRegulation();

        }

        // inventory adjust 'a' click event
        private void btnInvAdjustA_Click(object sender, EventArgs e)
        {

        }

        // inventory adjust 'r' click event
        private void btnInvAdjustR_Click(object sender, EventArgs e)
        {

        }

        // inventory adjust 't' click event
        private void btnInvAdjustT_Click(object sender, EventArgs e)
        {

        }

        // inventory adjust 'w' click event
        private void btnInvAdjustW_Click(object sender, EventArgs e)
        {

        }

        // order button click event
        private void btnOrder_Click(object sender, EventArgs e)
        {

        }

        // inventory count click event
        private void btnInvCount_Click(object sender, EventArgs e)
        {

        }

        private void ImportRHTForm_Load(object sender, EventArgs e)
        {


            lbImportData.Text = db.GetLangString("BHHTImportForm.ImportColHeadLbl");
            lbInvCount.Text = db.GetLangString("BHHTImportForm.InvCountLbl");

            lbInvAdjustW.Text = db.GetLangString("BHHTImportForm.WastageLbl");
            lbShelfLabels.Text = db.GetLangString("BHHTImportForm.ShelfLabelsLbl");


            btnInvCount.Text = db.GetLangString("BHHTImportForm.InvCountBtn");

            btnInvAdjustW.Text = db.GetLangString("BHHTImportForm.WastageBtn");

            lbImportedCount.Text = db.GetLangString("BHHTImportForm.ImportCountLbl");
            txtOpen.Text = db.GetLangString("BHHTImportForm.OpenCountLbl");
            btnClose.Text = db.GetLangString("Application.Close");
            btnImport.Text = db.GetLangString("BHHTImportForm.ImportBtn");



        }

        private void btnPrintShelfLabels_Click(object sender, EventArgs e)
        {
            ReportFormItemBasicData print = new ReportFormItemBasicData(ReportFormItemBasicData.ReportMode.ShelfLabels);
            print.ShowDialog();
        }

        private void btnInvCount_Click_1(object sender, EventArgs e)
        {
            // open BHHT Inventory Count form
            MainForm parent = (MainForm)this.MdiParent;
            if (!parent.IsFormOpen(typeof(BHHTInvCountHeaderForm)))
            {
                BHHTInvCountHeaderForm form = new BHHTInvCountHeaderForm();
                parent.OpenMDIWindow("BHHTInvCountFormTitle", form);
                // subscribe to form's FormClosing event, so we can update data when it closes
                form.FormClosing += new FormClosingEventHandler(DataFormClosing);
            }
            else
            {
                MessageBox.Show(db.GetLangString("ImportBHHTForm.CloseInventoryWindowFirstMsg"));
            }

        }

        private void btnInvAdjustW_Click_1(object sender, EventArgs e)
        {

            // open BHHT Inventory Adjust form with
            // waste data fileter on
            MainForm parent = (MainForm)this.MdiParent;
            if (!parent.IsFormOpen(typeof(BHHTInvAdjustForm)))
            {
                BHHTInvAdjustForm form = new BHHTInvAdjustForm('w');
                parent.OpenMDIWindow("BHHTInvAdjustForm.Title", form);
                // subscribe to form's FormClosing event, so we can update data when it closes
                form.FormClosing += new FormClosingEventHandler(DataFormClosing);
            }
            else
            {
                MessageBox.Show(db.GetLangString("ImportBHHTForm.CloseAdjustmentWindowFirst"));
            }

        }
        private void btnInvAdjustR_Click_2(object sender, EventArgs e)
        {

            // open BHHT Inventory Adjust form with
            // waste data fileter on
            MainForm parent = (MainForm)this.MdiParent;
            if (!parent.IsFormOpen(typeof(BHHTInvAdjustForm)))
            {
                BHHTInvAdjustForm form = new BHHTInvAdjustForm('A');
                parent.OpenMDIWindow("BHHTInvAdjustForm.Title", form);
                // subscribe to form's FormClosing event, so we can update data when it closes
                form.FormClosing += new FormClosingEventHandler(DataFormClosing);
            }
            else
            {
                MessageBox.Show(db.GetLangString("ImportBHHTForm.CloseAdjustmentWindowFirst"));
            }

        }

      
    }
}
