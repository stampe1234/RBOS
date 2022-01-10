using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class BookedInvCount : Form
    {
        public BookedInvCount()
        {
            InitializeComponent();
        }

        private void Print()
        {
            if (bindingBookedInvCount.Current == null) return;
            DataRowView row = (DataRowView)bindingBookedInvCount.Current;

            // show print form
            BookedInvCountReportF report = new BookedInvCountReportF(tools.object2int(row["ID"]));
            report.ShowDialog();
        }

        private void BookedInvCount_Load(object sender, EventArgs e)
        {
            adapterBookedInvCount.Connection = db.Connection;
            adapterBookedInvCount.Fill(dsItem.BookedInvCountHeader);

            colBookDate.DisplayIndex = 0;
            colSubCategory.DisplayIndex = 1;
            colSubCatDescr.DisplayIndex = 2;
            colStockValue.DisplayIndex = 3;
            colDiffValue.DisplayIndex = 4;
            colExportedAcc.DisplayIndex = 5;

            colBookDate.HeaderText = db.GetLangString("BookedInvCountForm.BookDateLbl");
            colSubCategory.HeaderText = db.GetLangString("BookedInvCountForm.SubCatLbl");
            colSubCatDescr.HeaderText = db.GetLangString("BookedInvCountForm.CatDescLbl");
            colStockValue.HeaderText = db.GetLangString("BookedInvCountForm.StockValueLbl");
            colDiffValue.HeaderText = db.GetLangString("BookedInvCountForm.CountDiffLbl");
            colExportedAcc.HeaderText = db.GetLangString("BookedInvCountForm.ExportedLbl");
            btnClose.Text = db.GetLangString("Application.Close");
            btnReport.Text = db.GetLangString("BookedInvCountForm.ReportBtn");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Print();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}