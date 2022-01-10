using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class SubCategoryForm : Form
    {
        public SubCategoryForm()
        {
            InitializeComponent();
        }

        private void SubCategoryForm_Load(object sender, EventArgs e)
        {
            this.subCategoryTableAdapter.Connection = db.Connection;
            this.subCategoryTableAdapter.Fill(this.adminDataSet.SubCategory);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            subCategoryTableAdapter.Update(adminDataSet.SubCategory);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}