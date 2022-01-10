using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class Wash : Form
    {
        private DateTime RegDate = DateTime.MinValue;

        public Wash()
        {
            InitializeComponent();
            LoadData();

            // subscribe to Wash db events
            dsEOD.Wash.OnUltimoTaellerBeregnetUpdated +=
                new EODDataSet.WashDataTable.UltimoTaellerBeregnetUpdated(Wash_OnUltimoTaellerBeregnetUpdated);
            dsEOD.Wash.OnSamletDifferenceUpdated += new EODDataSet.WashDataTable.SamletDifferenceUpdated(Wash_OnSamletDifferenceUpdated);
        }

        private void LoadData()
        {
            // get the current open eod bookdate
            DataRow rowEOD = EODDataSet.EODReconcileDataTable.GetCurrentOpenDay();
            if (rowEOD != null)
            {
                RegDate = tools.object2datetime(rowEOD["BookDate"]);
            }
            else
            {
                return;
            }

            // attempt to load an existing wash record,
            // and if none found, create a new record
            adapterWash.Connection = db.Connection;
            adapterWash.Fill(dsEOD.Wash, RegDate.Date);
            if (dsEOD.Wash.Rows.Count <= 0)
            {
                dsEOD.Wash.CreateRecord(RegDate);
                bindingWash.ResetCurrentItem();
            }

            // if wash does not exist for previous month,
            // the Primo field has to be opened for edit.
            // this scenario will only occur the very
            // first month washes are registered.
            txtVaskeTaellerPrimo.ReadOnly = dsEOD.Wash.WashExistsForPreviousMonth(RegDate);
            txtVaskeTaellerPrimo2.ReadOnly = !(!txtVaskeTaellerPrimo.ReadOnly && db.GetConfigStringAsBool("Readings.Vaskeafstemning2"));
            txtVaskeTaellerPrimo3.ReadOnly = !(!txtVaskeTaellerPrimo.ReadOnly && db.GetConfigStringAsBool("Readings.Vaskeafstemning3"));

            // the two fields txtTaellerUltimoAflaest2 and txtTaellerUltimoAflaest3
            // only opened for input, if their corresponding checkmarks has been
            // set in the siteinfo form.
            txtTaellerUltimoAflaest2.ReadOnly = !db.GetConfigStringAsBool("Readings.Vaskeafstemning2");
            txtTaellerUltimoAflaest3.ReadOnly = !db.GetConfigStringAsBool("Readings.Vaskeafstemning3");

            // localization
            btnCancel.Text = db.GetLangString("Application.Cancel");
            btnSaveAndClose.Text = db.GetLangString("Application.SaveClose");
            lbReadingTitle1.Text = db.GetLangString("Wash.lbReadingTitle1");
            lbReadingTitle2.Text = db.GetLangString("Wash.lbReadingTitle2");
            lbReadingTitle3.Text = db.GetLangString("Wash.lbReadingTitle3");
            lbRegDate.Text = db.GetLangString("Wash.lbRegDate");
            lbVaskeTaellerPrimo.Text = db.GetLangString("Wash.lbVaskeTaellerPrimo");
            lbLuxusMedLakforsegler.Text = db.GetLangString("Wash.lbLuxusMedLakforsegler");
            lbLuksusVask.Text = db.GetLangString("Wash.lbLuksusVask");
            lbVaskA.Text = db.GetLangString("Wash.lbWashA");
            lbVaskB.Text = db.GetLangString("Wash.lbWashB");
            lbVaskC.Text = db.GetLangString("Wash.lbWashC");
            lbVolumenVask.Text = db.GetLangString("Wash.lbVolumenVask");
            lbTeknikerVask.Text = db.GetLangString("Wash.lbTeknikerVask");
            lbTaellerUltimoBeregnet.Text = db.GetLangString("Wash.lbTaellerUltimoBeregnet");
            lbTaellerUltimoAflaest.Text = db.GetLangString("Wash.lbTaellerUltimoAflaest");
            lbSamletDifference.Text = db.GetLangString("Wash.lbSamletDifference");
        }

        private void SaveAndClose()
        {
            bindingWash.EndEdit();
            adapterWash.Update(dsEOD.Wash);
            Close();
        }

        void Wash_OnUltimoTaellerBeregnetUpdated()
        {
            bindingWash.ResetCurrentItem();
        }

        void Wash_OnSamletDifferenceUpdated()
        {
            bindingWash.ResetCurrentItem();
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