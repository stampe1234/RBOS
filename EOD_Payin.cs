using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class EOD_Payin : Form
    {
        private DateTime BookDate;
        private short TransType = (short)TransTypePayinPayout.Payin;

        public EOD_Payin(DateTime BookDate)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.BookDate = BookDate;

            // setup grid
            int idx = 0;
            colDescription.DisplayIndex = idx++;
            colAmount.DisplayIndex = idx++;
            colTidspunkt_DETAIL.DisplayIndex = idx++;

#if DETAIL
            if (!db.GetConfigStringAsBool("EOD.Payin.DETAIL.UnlockFields"))
            {
                // in DETAIL version user is only allowed to
                // edit descriptions of imported records
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                colAmount.ReadOnly = true;
                colAmount.DefaultCellStyle.BackColor = SystemColors.ButtonFace;
            }
#else
            colTidspunkt_DETAIL.Visible = false;
#endif
        }

        private void EOD_Payin_Load(object sender, EventArgs e)
        {
            adapterPayinPayout.Connection = db.Connection;
            adapterPayinPayout.Fill(dsEOD.EOD_PayinPayout, BookDate, (TransType));

            // localization
            this.Text = db.GetLangString("EODPayinForm.HeaderLbl");
            colDescription.HeaderText = db.GetLangString("EODPayinForm.DescriptionLbl");
            colAmount.HeaderText = db.GetLangString("EODPayinForm.AmountLbl");
            btnCancel.Text = db.GetLangString("Application.Cancel");
            btnSaveClose.Text = db.GetLangString("Application.SaveClose");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            // save data and return ok when closing
            bindingPayinPayout.EndEdit();
            adapterPayinPayout.Update(dsEOD.EOD_PayinPayout);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (bindingPayinPayout.Current == null) return;
            DataRowView row = (DataRowView)bindingPayinPayout.Current;

            // write key values
            if (tools.IsNullOrDBNull(row["LineNo"]))
            {
                row["BookDate"] = BookDate;
                row["LineNo"] = dsEOD.EOD_PayinPayout.GetNextLineNo();
                row["TransType"] = TransType;
            }
        }


       
    }
}