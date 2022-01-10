using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class PrlEmployee : Form
    {
        public PrlEmployee()
        {
            InitializeComponent();
            LoadData();

            // localization
            lbEmpList.Text = db.GetLangString("PrlEmployee.lbEmpList");
            groupGeneral.Text = db.GetLangString("PrlEmployee.tabGeneral");
            groupEmployment.Text = db.GetLangString("PrlEmployee.tabEmployment");
            lbEmpNo.Text = db.GetLangString("PrlEmployee.lbEmpNo");
            lbFirstName.Text = db.GetLangString("PrlEmployee.lbFirstName");
            lbLastName.Text = db.GetLangString("PrlEmployee.lbLastName");
            lbAddress1.Text = db.GetLangString("PrlEmployee.lbAddress1");
            lbZipCodeCity.Text = db.GetLangString("PrlEmployee.lbZipCodeCity");
            lbPhone.Text = db.GetLangString("PrlEmployee.lbPhone");
            lbContactPhone.Text = db.GetLangString("PrlEmployee.lbContactPhone");
            lbCPR.Text = db.GetLangString("PrlEmployee.lbCPR");
            lbPost.Text = db.GetLangString("PrlEmployee.lbPost");
            lbStartDate.Text = db.GetLangString("PrlEmployee.StartDate");
            lbEndDate.Text = db.GetLangString("PrlEmployee.EndDate");
            lbEmpType.Text = db.GetLangString("PrlEmployee.EmpType");
            lbFuncHours.Text = db.GetLangString("PrlEmployee.FuncHours");
            chkEducation.Text = db.GetLangString("PrlEmployee.chkEducation");
            lbInactiveFrom.Text = db.GetLangString("PrlEmployee.lbInactiveFrom");
            chkIncludeInactive.Text = db.GetLangString("PrlEmployee.chkIncludeInactive");
            btnClose.Text = db.GetLangString("Application.Close");
        }

        private void LoadData()
        {
            prlEmployeeDropDownTableAdapter.Connection = db.Connection;
            if (chkIncludeInactive.Checked)
                prlEmployeeDropDownTableAdapter.FillAll(dsPayroll.PrlEmployeeDropDown);
            else
                prlEmployeeDropDownTableAdapter.FillActiveInSalaryPeriod(dsPayroll.PrlEmployeeDropDown);
            LoadEmployee();
        }

        private void LoadEmployee()
        {
            int EmployeeNo = tools.object2int(comboEmpList.SelectedValue);
            adapterPrlEmployee.Connection = db.Connection;
            adapterPrlEmployee.Fill(dsPayroll.PrlEmployee, EmployeeNo);

            // obfuscate CPR number if not drs user
            if (dsPayroll.PrlEmployee.Rows.Count > 0)
            {
                string cpr = tools.object2string(dsPayroll.PrlEmployee.Rows[0]["CPR"]);
                if (UserLogon.ProfileID == AdminDataSet.UserProfilesDataTable.ProfileID.drs)
                {
                    if (cpr.Length > 9)
                        dsPayroll.PrlEmployee.Rows[0]["CPR"] = cpr.Substring(0, 6) + "-" + cpr.Substring(6, 4);
                }
                else
                {
                    if (cpr.Length > 6)
                        dsPayroll.PrlEmployee.Rows[0]["CPR"] = cpr.Substring(0, 6) + "-xxxx";
                }
            }
        }

        private void PrlEmployee_Load(object sender, EventArgs e)
        {
        }

        private void comboEmployeeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEmployee();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkIncludeInactive_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}