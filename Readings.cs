using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class Readings : Form
    {
        private DateTime RegDate = DateTime.MinValue;

        public Readings()
        {
            InitializeComponent();
            LoadData();

            dsEOD.Readings.ColumnChanged += new DataColumnChangeEventHandler(Readings_ColumnChanged);
        }

        void Readings_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            bindingReadings.ResetCurrentItem();
        }

        private void LoadData()
        {
            // get the current open eod bookdate
            DataRow rowEOD = EODDataSet.EODReconcileDataTable.GetCurrentOpenDay();
            if (rowEOD != null)
            {
                RegDate = tools.object2datetime(rowEOD["BookDate"]);
                lbBookDate.Text = RegDate.ToString("dd-MM-yyyy");
            }
            else
            {
                return;
            }

            // attempt to load an existing record,
            // and if none found, create a new record
            adapterReadings.Connection = db.Connection;
            adapterReadings.Fill(dsEOD.Readings, RegDate);
            if (dsEOD.Readings.Rows.Count <= 0)
            {
                dsEOD.Readings.CreateRecord(RegDate);
                bindingReadings.ResetCurrentItem();
            }

            // enable/disable txtWashWaterReading field
            txtWashWaterReading.ReadOnly = !db.GetConfigStringAsBool("Readings.SeperateWashReadings");

            // if ultimo readings last month does not exist,
            // the fields are writable, except wash primo which also depends on a config setting
            if (!dsEOD.Readings.ReadingsExistForPreviousMonth(RegDate))
            {
                txtMainWaterPrimo.ReadOnly = dsEOD.Readings.MainWaterPrimo != 0;
                txtKWPrimo.ReadOnly = dsEOD.Readings.KiloWattPrimo != 0;
                txtWashWaterPrimo.ReadOnly = (dsEOD.Readings.WashWaterPrimo != 0) ||
                    (!db.GetConfigStringAsBool("Readings.SeperateWashReadings"));
            }

            // localization
            groupWaterReadings.Text = db.GetLangString("Readings.groupWaterReadings");
            lbMainWater.Text = db.GetLangString("Readings.lbMainWater");
            lbWashWater.Text = db.GetLangString("Readings.lbWashWater");
            lbMainWaterPrimo.Text = db.GetLangString("Readings.lbMainWaterPrimo");
            lbMainWaterReading.Text = db.GetLangString("Readings.lbMainWaterReading");
            lbMainWaterUse.Text = db.GetLangString("Readings.lbMainWaterUse");
            lbWashWaterPrimo.Text = db.GetLangString("Readings.lbWashWaterPrimo");
            lbWashWaterReading.Text = db.GetLangString("Readings.lbWashWaterReading");
            lbWashWaterUse.Text = db.GetLangString("Readings.lbWashWaterUse");
            groupPowerReadings.Text = db.GetLangString("Readings.groupPowerReadings");
            lbKW.Text = db.GetLangString("Readings.lbKW");
            lbKWPrimo.Text = db.GetLangString("Readings.lbKWPrimo");
            lbKWReading.Text = db.GetLangString("Readings.lbKWReading");
            lbKWUse.Text = db.GetLangString("Readings.lbKWUse");
            btnSaveAndClose.Text = db.GetLangString("Application.SaveClose");
            btnCancel.Text = db.GetLangString("Application.Cancel");
        }

        private void SaveAndClose()
        {
            bindingReadings.EndEdit();
            adapterReadings.Update(dsEOD.Readings);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            SaveAndClose();
        }

        private void txtMainWaterReading_Validated(object sender, EventArgs e)
        {
        }

        private void txtWashWaterReading_Validated(object sender, EventArgs e)
        {
        }

        private void txtKWReading_Validated(object sender, EventArgs e)
        {
        }

        private void Readings_Load(object sender, EventArgs e)
        {
        }
    }
}