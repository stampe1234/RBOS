using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class EOD_LocalCredit : Form
    {
        private DateTime BookDate;
        private TransTypeLocalCred TransType;

        public EOD_LocalCredit(DateTime BookDate, TransTypeLocalCred TransType)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.BookDate = BookDate;
            this.TransType = TransType;
            dsEOD.EOD_LocalCred.OnFieldValidationError += new EODDataSet.EOD_LocalCredDataTable.FieldValidationError(EOD_LocalCred_OnFieldValidationError);
        }

        void EOD_LocalCred_OnFieldValidationError(string Msg)
        {
            MessageBox.Show(Msg);
        }

        private void EOD_LocalCredit_Load(object sender, EventArgs e)
        {
            // load data
            adapterEODDebtorPopup.Connection = db.Connection;
            adapterEODDebtorPopup.Fill(dsEOD.EOD_DebtorPopup);
            adapterLocalCredit.Connection = db.Connection;
            adapterLocalCredit.Fill(dsEOD.EOD_LocalCred, BookDate, (short)TransType);

            if(TransType == TransTypeLocalCred.LocalCredit)
                this.Text = db.GetLangString("EODLocalCreditForm.HeaderLbl");
            else
                this.Text = db.GetLangString("EODLocalCredPayForm.HeaderLbl");

            colCustNo.DisplayIndex = 0;
            colDebtorPopup.DisplayIndex = 1;
            colCustName.DisplayIndex = 2;
            colRemark.DisplayIndex = 3;
            colAmount.DisplayIndex = 4;

            colCustNo.HeaderText = db.GetLangString("EODLocalCreditForm.CustNoLbl");
            colCustName.HeaderText = db.GetLangString("EODLocalCreditForm.CustNameLbl");
            colRemark.HeaderText = db.GetLangString("EODLocalCreditForm.RemarkLbl");
            colAmount.HeaderText = db.GetLangString("EODLocalCreditForm.AmountLbl");
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
            bindingLocalCredit.EndEdit();
            adapterLocalCredit.Update(dsEOD.EOD_LocalCred);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (bindingLocalCredit.Current == null) return;
            DataRowView row = (DataRowView)bindingLocalCredit.Current;

            // write key values
            if (tools.IsNullOrDBNull(row["LineNo"]))
            {
                row["BookDate"] = BookDate;
                row["LineNo"] = dsEOD.EOD_LocalCred.GetNextLineNo();
                row["TransType"] = TransType;
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // render lookupform image on button for opening debtor lookupform
            ImageButtonRender.OnCellPainting(e, colDebtorPopup.Index, ImageButtonRender.Images.LookupForm);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bindingLocalCredit.Current == null) return;
            DataRowView row = (DataRowView)bindingLocalCredit.Current;

            // select debtor from lookup form
            if (e.ColumnIndex == colDebtorPopup.Index)
            {
                EODDebtorPopup debtor = new EODDebtorPopup(false);
                debtor.SelectedDebtorNo = tools.object2int(row["CustomerNo"]);
                if (debtor.ShowDialog(this) == DialogResult.OK)
                {
                    if (debtor.SelectedDebtorNo.HasValue)
                    {
                        row["CustomerNo"] = debtor.SelectedDebtorNo.Value;
                        dataGridView1.Refresh();
                    }
                }
            }
        }

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (bindingLocalCredit.Current == null) return;
            DataRowView row = (DataRowView)bindingLocalCredit.Current;

            // if user has selected a debtor, check that an amount has been entered
            if ((row["CustomerNo"] != DBNull.Value) && (row["Amount"] == DBNull.Value))
            {
                MessageBox.Show(db.GetLangString("EOD_LocalCredit.YouMustEnterAnAmount"));
                e.Cancel = true;
            }
            // else if amount has been entered and no debtor has been selected, just remove the record
            else if ((row["CustomerNo"] == DBNull.Value) && (row["Amount"] != DBNull.Value))
            {
                dataGridView1.CancelEdit();
            }
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            // when leaving the CustNo cell, make CustName cell repaint and display value
            if ((e.ColumnIndex == colCustNo.Index) && (e.RowIndex >= 0))
                dataGridView1.InvalidateCell(colCustName.Index, e.RowIndex);
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
        }       
    }
}