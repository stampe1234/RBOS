using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void btnCalculateWeekNumber_Click(object sender, EventArgs e)
        {
            monthCalendar1.SelectionEnd = monthCalendar1.SelectionStart;
            int year, week;
            tools.GetISOWeekNumberFromDate(monthCalendar1.SelectionStart, out year, out week);
            txtCalculatedYear.Text = year.ToString();
            txtCalculatedMonth.Text = week.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExportACNFile_Click(object sender, EventArgs e)
        {
            monthCalendar1.SelectionEnd = monthCalendar1.SelectionStart;
            //ExportACN.ExportACNFile(monthCalendar1.SelectionStart, false);
        }

        private void btnBCalculate_Click(object sender, EventArgs e)
        {
            int Year = tools.object2int(txtBYear.Text);
            int Week = tools.object2int(txtBWeek.Text);
            DateTime Result = tools.GetDateFromISOWeekNumber(Year, Week, DayOfWeek.Sunday);
            txtBResult.Text = Result.ToString("dd-MM-yyyy");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImportReitan test = new ImportReitan();
        }

        private void btnDummyValuesInEODReconcileEx_Click(object sender, EventArgs e)
        {
            // autogenerer dummy datoer og kundeantal i EODReconcileEx tabellen

            if (MessageBox.Show("Alle data slettes fra EODReconcileEx tabellen først. Fortsæt?","",MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            db.ExecuteNonQuery("delete from EODReconcileEx");

            DateTime start = new DateTime(tools.object2int(txtEODReconcileEx_fromyear.Text),1,1);
            DateTime end = new DateTime(tools.object2int(txtEODReconcileEx_toyear.Text),12,31);
            int i = 0;
            for (DateTime dt = start; dt <= end; dt = dt.AddDays(1))
            {
                Random rand = new Random((int)DateTime.Now.Ticks);
                int CustomerCount = rand.Next(50, 300) + ++i;
                db.ExecuteNonQuery(string.Format(@"
                    insert into EODReconcileEx
                    (BookDate,CustomerCount)
                    values ('{0}',{1})
                    ", dt, CustomerCount));
            }

            MessageBox.Show("Færdig");
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            txtEODReconcileEx_fromyear.Text = DateTime.Now.Year.ToString();
            txtEODReconcileEx_toyear.Text = DateTime.Now.Year.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ImportRHTForm test = new ImportRHTForm();
            test.Show();
           
        }
    }
}