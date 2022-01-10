using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class EOD_Payout : Form
    {
        private DateTime BookDate;
        private int TransType = (int)TransTypePayinPayout.Payout;

        public EOD_Payout(DateTime BookDate)
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
            if (!db.GetConfigStringAsBool("EOD.Payout.DETAIL.UnlockFields"))
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

        private void EOD_Payout_Load(object sender, EventArgs e)
        {
            adapterPayinPayout.Connection = db.Connection;
            adapterPayinPayout.Fill(dsEOD.EOD_PayinPayout, BookDate, (short)TransType);

            this.Text = db.GetLangString("EODPayoutForm.HeaderLbl");

            colDescription.HeaderText = db.GetLangString("EODPayoutForm.DescriptionLbl");
            colAmount.HeaderText = db.GetLangString("EODPayoutForm.AmountLbl");
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
            if (tools.IsNullOrDBNull(row["LineNo"]))
            {
                row["BookDate"] = BookDate;
                row["LineNo"] = dsEOD.EOD_PayinPayout.GetNextLineNo();
                row["TransType"] = TransType;
            }
        }

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {          
            #if DETAIL
                string InputMask = db.GetConfigString("EOD.Payout.DETAIL.InputMask");
                if (InputMask !="" )
                
                {
                    DataRowView row = (DataRowView)bindingPayinPayout.Current;
                    String test1 = row[4].ToString();
                    if ((test1 != null) && (test1!=""))
                    {
                        test1 = row[3].ToString();
                        if (test1 == "")
                        {
                            MessageBox.Show("Udfyld tekst");
                            e.Cancel = true;
                        }
                        else
                        {
                            String Messagestring = "Start teksten med en disse værdier " + InputMask;
                            int test3 = test1.Length;
                            if (test3 < 2)
                            {
                                MessageBox.Show(Messagestring);
                                e.Cancel = true;
                            }


                            string test2 = test1.Substring(0, 2);
                            test3 = InputMask.IndexOf(test2);
                           
                            if (test3 < 0)
                            {                                
                                MessageBox.Show(Messagestring);
                                e.Cancel = true;                            
                            }

                        }
                    }
                }
            #endif   
            

        }

               
    }
}