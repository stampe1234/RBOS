using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RBOS
{
    public partial class ImportItemsCSVFrm : Form
    {
        #region Constructor
        public ImportItemsCSVFrm()
        {
            InitializeComponent();
        }
        #endregion

        #region SelectFile
        private void SelectFile()
        {
            // attempt to set the previously used directory
            string dir = db.GetConfigString("ImportItemsCSVFrm.LastUsedDir");
            if (Directory.Exists(dir))
                openFileDialog1.InitialDirectory = dir;

            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                // copy filepath to textbox and save directory for next time
                txtFilepath.Text = openFileDialog1.FileName;
                db.SetConfigString("ImportItemsCSVFrm.LastUsedDir",
                    tools.StripFilenameFromPath(openFileDialog1.FileName));
            }
        }
        #endregion

        #region ImportFile
        private void ImportFile()
        {
            if (ImportItemsCSV.ImportFile(txtFilepath.Text, chkIncludeNewItems.Checked))
            {
                MainForm mainform = this.MdiParent as MainForm;
                if (mainform != null)
                {
                    mainform.OpenMenuWindow("TreeMenu.ImportFromLL");
                    Close();
                }
            }
            else
                MessageBox.Show(ImportItemsCSV.LastMessage);
        }
        #endregion

        #region LoadData
        private void LoadData()
        {
            chkIncludeNewItems.Checked = db.GetConfigStringAsBool("ImportItemsCSVFrm.IncludeNewItems");

            // localization
            btnClose.Text = db.GetLangString("Application.Close");
            lbFilepath.Text = db.GetLangString("ImportItemsCSVFrm.lbFilepath");
            btnImport.Text = db.GetLangString("ImportItemsCSVFrm.btnImport");
            chkIncludeNewItems.Text = db.GetLangString("ImportItemsCSVFrm.chkIncludeNewItems");
        }
        #endregion

        private void ImportItemsCSV_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            SelectFile();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ImportFile();
        }

        private void chkIncludeNewItems_CheckedChanged(object sender, EventArgs e)
        {
            db.SetConfigString("ImportItemsCSVFrm.IncludeNewItems", chkIncludeNewItems.Checked);
        }
   }
}