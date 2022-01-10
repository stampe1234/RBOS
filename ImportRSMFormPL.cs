using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class ImportRSMFormPL : Form
    {
        #region Constructor
        public ImportRSMFormPL(DateTime BookDate, string FileType)
        {
            InitializeComponent();
            grid.AutoGenerateColumns = false;
            adapterProblemLines.Connection = db.Connection;
            adapterProblemLines.Fill(dsImport.Import_RPOS_24H_ProblemLines, BookDate, FileType);
        }
        #endregion

        // form load event
        private void ImportRSMFormProblemLines_Load(object sender, EventArgs e)
        {
            // localization
            this.Text = db.GetLangString("ImportRSMFormPL.Title");
            btnClose.Text = db.GetLangString("Application.Close");
            colLine.HeaderText = db.GetLangString("ImportRSMFormPL.colLine");
            colProblemDesc.HeaderText = db.GetLangString("ImportRSMFormPL.colProblemDesc");
            colDataExtract.HeaderText = db.GetLangString("ImportRSMFormPL.colDataExtract");
        }

        // close button click event
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}