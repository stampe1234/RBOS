using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class PrlEmployeePopup : Form
    {
        private int _SelectedEmployeeNo = 0;

        // constructor
        public PrlEmployeePopup()
        {
            InitializeComponent();

            // load data
            adapterLookupEmployeeName.Connection = db.Connection;
            adapterLookupEmployeeName.FillActiveInSalaryPeriod(dsPayroll.PrlLookupEmployeeName);

            // default dialogresult to cancel
            this.DialogResult = DialogResult.Cancel;

            // set column order (bug in vs2005)
            colEmployeeNo.DisplayIndex = 0;
            colEmployeeName.DisplayIndex = 1;
        }

        /// <summary>
        /// Returns the selected employee no
        /// 0 is returned if nothing selected or cancel clicked.
        /// </summary>
        public int SelectedEmployeeNo
        {
            get { return _SelectedEmployeeNo; }
            set
            {
                // attempt to find the employee no
                _SelectedEmployeeNo = 0;
                if (value == 0) return;
                int index = bindingLookupEmployeeName.Find("EmployeeNo", value);
                if ((index >= 0) && (index < bindingLookupEmployeeName.Count))
                {
                    bindingLookupEmployeeName.Position = index;
                    _SelectedEmployeeNo = value;
                }
            }
        }

        /// <summary>
        /// Returns the selected employee name.
        /// "" is returned if nothing selected or cancel clicked.
        /// </summary>
        public string SelectedEmployeeName
        {
            get
            {
                if (_SelectedEmployeeNo != 0)
                {
                    int index = bindingLookupEmployeeName.Find("EmployeeNo", _SelectedEmployeeNo);
                    if ((index >= 0) && (index < bindingLookupEmployeeName.Count))
                        return tools.object2string(((DataRowView)bindingLookupEmployeeName[index])["Name"]);
                }
                return "";
            }
        }

        /// <summary>
        /// Closes the form and returns the selected
        /// employee no by putting it in a property
        /// </summary>
        private void CloseAndReturn()
        {
            // get the selected employee no
            if (bindingLookupEmployeeName.Current != null)
            {
                DataRowView row = (DataRowView)bindingLookupEmployeeName.Current;
                _SelectedEmployeeNo = tools.object2int(row["EmployeeNo"]);
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }

        // form load event
        private void PrlEmployeePopup_Load(object sender, EventArgs e)
        {
            this.Text = db.GetLangString("PrlEmployeePopup.Title");
            btnOk.Text = db.GetLangString("Application.Ok");
            btnCancel.Text = db.GetLangString("Application.Cancel");
            colEmployeeNo.HeaderText = db.GetLangString("PrlEmployeePopup.colEmployeeNo");
            colEmployeeName.HeaderText = db.GetLangString("PrlEmployeePopup.colName");
        }

        // grid mouse double click event
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CloseAndReturn();
        }

        // ok button click event
        private void btnOk_Click(object sender, EventArgs e)
        {
            CloseAndReturn();
        }

        // cancel button click event
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // grid key down
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CloseAndReturn();
        }
    }
}