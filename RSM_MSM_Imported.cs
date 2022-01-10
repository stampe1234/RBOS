using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class RSM_MSM_Imported : Form
    {
        public RSM_MSM_Imported()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DataTable table = db.GetDataTable(string.Format(
                        " select details.*, config.ModifierDesc, config.IncludeCode " +
                        " from Import_RPOS_MSM_Details details " +
                        " left outer join Import_RPOS_MSM_Config config " +
                        " on config.SummaryCode = details.SummaryCode " +
                        " and config.SubCode = details.SubCode " +
                        " and config.Modifier = details.Modifier " +
                        " where (details.BookDate = cdate('{0}')) " +
                        " order by details.SummaryCode, details.SubCode, details.Modifier ",
                        comboDate.Value.Date));

            // lookup missing descriptions due to strange Modifier key
            foreach (DataRow row in table.Rows)
            {
                if (row["ModifierDesc"].ToString() == "")
                {
                    row["ModifierDesc"] = db.ExecuteScalar(string.Format(
                        " select ModifierDesc from Import_RPOS_MSM_Config " +
                        " where (SummaryCode = {0}) " +
                        " and (SubCode = {1}) ",
                        row["SummaryCode"],
                        row["SubCode"]));
                }
            }

            grid.DataSource = table;
            count.Text = table.Rows.Count.ToString();
        }
    }
}