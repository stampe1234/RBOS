using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class PrlWithdraw : Form
    {
        private bool OkToClose = false;

        public PrlWithdraw()
        {
            InitializeComponent();
            LoadData();

            // localization
            btnClose.Text = db.GetLangString("Application.Close");
            lbSalaryPeriod.Text = db.GetLangString("PrlWithdraw.lbSalaryPeriod");
            colEmployeeNo.HeaderText = db.GetLangString("PrlWithdraw.colEmployeeNo");
            colEmployeeName.HeaderText = db.GetLangString("PrlWithdraw.colEmployeeName");
            colWithdrawType.HeaderText = db.GetLangString("PrlWithdraw.colWithdrawType");
            colRemark.HeaderText = db.GetLangString("PrlWithdraw.colRemark");
            colNumberOf.HeaderText = db.GetLangString("PrlWithdraw.colNumberOf");
            colAmount.HeaderText = db.GetLangString("PrlWithdraw.colAmount");
            colDateReg.HeaderText = db.GetLangString("PrlWithdraw.colDateReg");

            // position grid columns
            int index = 0;
            colEmployeeNo.DisplayIndex = index++;
            colEmployeeButton.DisplayIndex = index++;
            colEmployeeName.DisplayIndex = index++;
            colWithdrawType.DisplayIndex = index++;
            colRemark.DisplayIndex = index++;
            colNumberOf.DisplayIndex = index++;
            colAmount.DisplayIndex = index++;
            colDateReg.DisplayIndex = index++;
        }

        private void LoadData()
        {
            // load active salary period string
            txtSalaryPeriod.Text = Payroll.PrlSalaryPeriodsDataTable.GetActiveSalaryPeriodString();

            // load PrlLookupEmployeeName data
            adapterLookupEmployeeName.Connection = db.Connection;
            adapterLookupEmployeeName.FillAll(dsPayroll.PrlLookupEmployeeName);

            // load PrlWithdrawType data
            adapterWithdrawType.Connection = db.Connection;
            adapterWithdrawType.Fill(dsPayroll.PrlWithdrawType);

            // load PrlWithdraw data
            adapterWithdraw.Connection = db.Connection;
            adapterWithdraw.Fill(dsPayroll.PrlWithdraw);
        }

        private void SaveData()
        {
            bindingWithdraw.EndEdit();
            adapterWithdraw.Update(dsPayroll.PrlWithdraw);
        }

        private void PrlWithdraw_Load(object sender, EventArgs e)
        {
        }

        private void PrlWithdraw_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!OkToClose)
            {
                MessageBox.Show(db.GetLangString("Application.UseCloseButton"));
                e.Cancel = true;
            }

            // save data
            SaveData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OkToClose = true;
            Close();
        }

        private void drS_DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bindingWithdraw.Current == null) return;
            DataRowView row = (DataRowView)bindingWithdraw.Current;

            if (e.ColumnIndex == colEmployeeButton.Index)
            {
                // user has clicked on the employee button,
                // so open employee popup to select an employee
                PrlEmployeePopup popup = new PrlEmployeePopup();
                popup.SelectedEmployeeNo = tools.object2int(row["EmployeeNo"]);
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    row["EmployeeNo"] = popup.SelectedEmployeeNo;
                    
                    // make sure the changes are reflected in gui
                    // (they weren't always updated before)
                    gridWithdraw.Refresh();
                }
            }
        }

        private void gridWithdraw_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            ImageButtonRender.OnCellPainting(e, colEmployeeButton.Index, ImageButtonRender.Images.LookupForm);
        }

        private void gridWithdraw_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (bindingWithdraw.Current == null) return;
            DataRowView row = (DataRowView)bindingWithdraw.Current;
            if (!Payroll.PrlWithdrawDataTable.CheckRequiredFields(row.Row))
            {
                gridWithdraw.CancelEdit();
                bindingWithdraw.CancelEdit();
            }
        }

        private void gridWithdraw_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // whenever a cell ends its edit,
            // refresh the grid as data might have
            // been automatically calculated in base code
            if (dsPayroll.PrlWithdraw.DataWasAutoCalculated)
                gridWithdraw.Refresh();
        }
    }
}