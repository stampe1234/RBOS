using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace RBOS
{
    public partial class ImportBHHTForm : Form
    {
        // constructor
        public ImportBHHTForm()
        {
            InitializeComponent();
            ResetLabels();
            CalculateOpenRecords();
        }

        #region METHOD: ResetLabels
        /// <summary>
        /// Resets all labels on the form
        /// </summary>
        private void ResetLabels()
        {
            status.Text = "";

            // count fields
            txtOrder.Text = "0";
            txtInvAdjustA.Text = "0";
            txtInvAdjustR.Text = "0";
            txtInvAdjustT.Text = "0";
            txtInvAdjustW.Text = "0";
            txtInvCount.Text = "0";
            txtShelfLabels.Text = "0";

            // open fields
            txtOrderOpen.Text = "0";
            txtInvAdjustAOpen.Text = "0";
            txtInvAdjustROpen.Text = "0";
            txtInvAdjustTOpen.Text = "0";
            txtInvAdjustWOpen.Text = "0";
            txtInvCountOpen.Text = "0";
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

            // inventory adjustmentA
            cmd.CommandText =
                " select count(AdjustID) from BHHTInvAdjustHeader " +
                " where (ReasonCode = 'a') and (Status = 'OPN')";
            txtInvAdjustAOpen.Text = tools.object2string(cmd.ExecuteScalar());

            // inventory adjustmentR
            cmd.CommandText =
                " select count(AdjustID) from BHHTInvAdjustHeader " +
                " where (ReasonCode = 'r') and (Status = 'OPN')";
            txtInvAdjustROpen.Text = tools.object2string(cmd.ExecuteScalar());

            // inventory adjustmentT
            cmd.CommandText =
                " select count(AdjustID) from BHHTInvAdjustHeader " +
                " where (ReasonCode = 't') and (Status = 'OPN')";
            txtInvAdjustTOpen.Text = tools.object2string(cmd.ExecuteScalar());

            // inventory adjustmentW
            cmd.CommandText =
                " select count(AdjustID) from BHHTInvAdjustHeader " +
                " where (ReasonCode = 'w') and (Status = 'OPN')";
            txtInvAdjustWOpen.Text = tools.object2string(cmd.ExecuteScalar());

            // order
            cmd.CommandText =
                " select count(OrderID) from BHHTOrderHeader " +
                " where Status = 'OPN'";
            txtOrderOpen.Text = tools.object2string(cmd.ExecuteScalar());

            // inventory count
            cmd.CommandText =
                " select count(CountID) from BHHTInvCountHeader " +
                " where Status = 'OPN'";
            txtInvCountOpen.Text = tools.object2string(cmd.ExecuteScalar());
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
            // before importing, check that no related data forms are open
            MainForm parent = (MainForm)this.MdiParent;
            if (parent.IsFormOpen(typeof(BHHTInvAdjustForm)))
            {
                MessageBox.Show(db.GetLangString("ImportBHHTForm.CloseAdjWindowFirstMsg"));
                return;
            }
            if (parent.IsFormOpen(typeof(BHHTOrderHeaderForm)))
            {                
                MessageBox.Show(db.GetLangString("ImportBHHTForm.CloseOrderWindowsFirstMsg"));
                return;
            }
            if (parent.IsFormOpen(typeof(BHHTInvCountHeaderForm)))
            {                
                MessageBox.Show(db.GetLangString("ImportBHHTForm.CloseInventoryWindowFirstMsg"));
                return;
            }

            ResetLabels();

            ImportBHHT importer = new ImportBHHT();
            if (importer.ImportBHE(this))
            {
                txtOrder.Text = importer.ImportedOrders.ToString();
                txtInvAdjustA.Text = importer.ImportedInvAdjustA.ToString();
                txtInvAdjustR.Text = importer.ImportedInvAdjustR.ToString();
                txtInvAdjustT.Text = importer.ImportedInvAdjustT.ToString();
                txtInvAdjustW.Text = importer.ImportedInvAdjustW.ToString();
                txtInvCount.Text = importer.ImportedInvCount.ToString();
                txtShelfLabels.Text = importer.ImportedShelfLabel.ToString();
                MessageBox.Show(db.GetLangString("ImportBHHTForm.BHHTImportDoneMsg"));
            }
            else
                MessageBox.Show(importer.LastError);

            CalculateOpenRecords();
        }

        // inventory adjust 'a' click event
        private void btnInvAdjustA_Click(object sender, EventArgs e)
        {
            // open BHHT Inventory Adjust form with
            // adjustment data fileter on
            MainForm parent = (MainForm)this.MdiParent;
            if (!parent.IsFormOpen(typeof(BHHTInvAdjustForm)))
            {
                BHHTInvAdjustForm form = new BHHTInvAdjustForm('a');
                parent.OpenMDIWindow("BHHTInvAdjustForm.Title", form);
                // subscribe to form's FormClosing event, so we can update data when it closes
                form.FormClosing += new FormClosingEventHandler(DataFormClosing);
            }
            else
            {                
                MessageBox.Show(db.GetLangString("ImportBHHTForm.CloseAdjustmentWindowFirst"));
            }
        }

        // inventory adjust 'r' click event
        private void btnInvAdjustR_Click(object sender, EventArgs e)
        {
            // open BHHT Inventory Adjust form with
            // receiving data fileter on
            MainForm parent = (MainForm)this.MdiParent;
            if (!parent.IsFormOpen(typeof(BHHTInvAdjustForm)))
            {
                BHHTInvAdjustForm form = new BHHTInvAdjustForm('r');
                parent.OpenMDIWindow("BHHTInvAdjustForm.Title", form);
                // subscribe to form's FormClosing event, so we can update data when it closes
                form.FormClosing += new FormClosingEventHandler(DataFormClosing);
            }
            else
            {
                MessageBox.Show(db.GetLangString("ImportBHHTForm.CloseAdjustmentWindowFirst"));
            }
        }

        // inventory adjust 't' click event
        private void btnInvAdjustT_Click(object sender, EventArgs e)
        {
            // open BHHT Inventory Adjust form with
            // transfer data fileter on
            MainForm parent = (MainForm)this.MdiParent;
            if (!parent.IsFormOpen(typeof(BHHTInvAdjustForm)))
            {
                BHHTInvAdjustForm form = new BHHTInvAdjustForm('t');
                parent.OpenMDIWindow("BHHTInvAdjustForm.Title", form);
                // subscribe to form's FormClosing event, so we can update data when it closes
                form.FormClosing += new FormClosingEventHandler(DataFormClosing);
            }
            else
            {
                MessageBox.Show(db.GetLangString("ImportBHHTForm.CloseAdjustmentWindowFirst"));
            }
        }

        // inventory adjust 'w' click event
        private void btnInvAdjustW_Click(object sender, EventArgs e)
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

        // order button click event
        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (db.GetConfigStringAsBool("AutoCreateRBOSOrdersFromBHHT") &&
                (!ImportDataSet.BHHTOrderHeaderDataTable.HasIncompleteOrders()))
            {
                // open RBOS Order form
                MainForm parent = (MainForm)this.MdiParent;
                if (!parent.IsFormOpen(typeof(OrderHeaderForm)))
                {
                    OrderHeaderForm form = new OrderHeaderForm();
                    parent.OpenMDIWindow("TreeMenu030201", form);
                    // subscribe to form's FormClosing event, so we can update data when it closes
                    form.FormClosing += new FormClosingEventHandler(DataFormClosing);
                }
                else
                {
                    MessageBox.Show(db.GetLangString("ImportBHHTForm.CloseOrderWindowsFirstMsg"));
                }
            }
            else
            {
                // open BHHT Order form
                MainForm parent = (MainForm)this.MdiParent;
                if (!parent.IsFormOpen(typeof(BHHTOrderHeaderForm)))
                {
                    BHHTOrderHeaderForm form = new BHHTOrderHeaderForm();
                    parent.OpenMDIWindow("BHHTOrderFormTitle", form);
                    // subscribe to form's FormClosing event, so we can update data when it closes
                    form.FormClosing += new FormClosingEventHandler(DataFormClosing);
                }
                else
                {
                    MessageBox.Show(db.GetLangString("ImportBHHTForm.CloseOrderWindowsFirstMsg"));
                }
            }
        }

        // inventory count click event
        private void btnInvCount_Click(object sender, EventArgs e)
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

        private void ImportBHHTForm_Load(object sender, EventArgs e)
        {
            
            lbOrder.Text = db.GetLangString("BHHTImportForm.OrderLbl");
            lbImportData.Text = db.GetLangString("BHHTImportForm.ImportColHeadLbl");
            lbInvCount.Text = db.GetLangString("BHHTImportForm.InvCountLbl");
            lbInvAdjust.Text = db.GetLangString("BHHTImportForm.InvAdjustmentsLbl");
            lbInvAdjustA.Text = db.GetLangString("BHHTImportForm.AdjustmentLbl");
            lbInvAdjustR.Text = db.GetLangString("BHHTImportForm.ReceivingLbl");
            lbInvAdjustT.Text = db.GetLangString("BHHTImportForm.TranfersLbl");
            lbInvAdjustW.Text = db.GetLangString("BHHTImportForm.WastageLbl");
            lbShelfLabels.Text = db.GetLangString("BHHTImportForm.ShelfLabelsLbl");

            btnOrder.Text = db.GetLangString("BHHTImportForm.OrderBtn");
            btnInvCount.Text = db.GetLangString("BHHTImportForm.InvCountBtn");
            btnInvAdjustA.Text = db.GetLangString("BHHTImportForm.AdjustmentBtn");
            btnInvAdjustR.Text = db.GetLangString("BHHTImportForm.ReceivingBtn");
            btnInvAdjustT.Text = db.GetLangString("BHHTImportForm.TranfersBtn");
            btnInvAdjustW.Text = db.GetLangString("BHHTImportForm.WastageBtn");

            lbImportedCount.Text = db.GetLangString("BHHTImportForm.ImportCountLbl");
            txtOpen.Text = db.GetLangString("BHHTImportForm.OpenCountLbl");
            btnClose.Text = db.GetLangString("Application.Close");
            btnImport.Text = db.GetLangString("BHHTImportForm.ImportBtn");
            btnPrintShelfLabels.Text = db.GetLangString("BHHTImportForm.btnPrintShelfLabel");


        }

        private void btnPrintShelfLabels_Click(object sender, EventArgs e)
        {
            ReportFormItemBasicData print = new ReportFormItemBasicData(ReportFormItemBasicData.ReportMode.ShelfLabels);
            print.ShowDialog();
        }
               
    }
}