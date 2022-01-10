using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class DateTimeDialog : Form
    {
        private DateTime _SelectedDateTime = DateTime.MinValue;
        public DateTime SelectedDateTime
        {
            get { return _SelectedDateTime; }
            set
            {
                if (value == DateTime.MinValue)
                    value = DateTime.Now.Date;
                _SelectedDateTime = value;
                calendar.SelectionStart = _SelectedDateTime;
                calendar.SelectionEnd = _SelectedDateTime;
            }
        }

        public DateTime MinDate
        {
            get { return calendar.MinDate; }
            set { calendar.MinDate = value; }
        }

        public DateTime MaxDate
        {
            get { return calendar.MaxDate; }
            set { calendar.MaxDate = value; }
        }

        public DateTimeDialog()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;

            // localization
            this.Text = " " + db.GetLangString("DateTimeDialog.Title");
        }

        private void DateTimeDialog_Load(object sender, EventArgs e)
        {
            Point p = Cursor.Position;
            p.X = p.X - 40;
            p.Y = p.Y - 10;
            this.Location = p;
        }

        private void calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            _SelectedDateTime = e.Start;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void DateTimeDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}