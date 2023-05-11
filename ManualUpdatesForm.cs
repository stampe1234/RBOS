using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using GenericParsing;

namespace RBOS
{
    public partial class ManualUpdatesForm : Form
    {
        #region Private variables

        private bool manualUpdatesPresent = false;
        private string arriveDir = "";
        private string fileMSM = "";
        private string fileGLSubcatRel = "";
        private string fileGLBudget = "";
        private List<string> filesLL = null;
        private List<string> filesFVD = null;
        private string fileLLSubcatRel = "";
        private string filePrlEmployee = "";
        private string filePrlAbsense = "";
        private string filePrlAgreement = "";
        private string filePrlHolidays = "";
        private string filePrlSalaryPeriods = "";
        private string filePrlClusterSites = "";
        private string fileRRDebitorData = "";
        private string fileSubCatSetup = "";
        private ImportWPF importWPF = null;
        private List<string> filesDS = null; 

        #endregion

        #region Constructor
        public ManualUpdatesForm()
        {
            InitializeComponent();

            // prepare files
            arriveDir = db.GetConfigString("DRS_FTP_client_arrive_dir") + "\\";
            PrepareFileMSM();
            PrepareFileGLSubcatRel();
            PrepareFileGLBudget();
            PrepareFileLLSubcatRel();
#if FSD
            PrepareFileLL();
#else
            PrepareFileFVD();
#endif
            PrepareSubCatSetup();
            PrepareDS();
#if RBA
            PrepareEPD();
            PrepareWPF();
#endif

            // only load værksted program data
            // if VPRG.Enabled flag is true
            if (db.GetConfigStringAsBool("VPRG.Enabled"))
            {
                PrepareRRDebitorData();
            }

            // only allow loading payroll module files
            // if payroll module is active for the station
            if (db.GetConfigStringAsBool("PayrollModuleActive"))
            {
                PreparePrlEmployee();
                PreparePrlAbsense();
                PreparePrlAgreement();
                PreparePrlHolidays();
                PreparePrlSalaryPeriods();
                PreparePrlClusterSites();
            }
            else
            {
                // hide payroll module checkboxes and resize
                // form if payroll module is not active
                chkPrlAbsense.Visible = false;
                chkPrlAgreement.Visible = false;
                chkPrlClusterSites.Visible = false;
                chkPrlEmployee.Visible = false;
                chkPrlHolidays.Visible = false;
                chkPrlSalaryPeriods.Visible = false;
                Width = Width - 70;
                ProgressBar.Width = ProgressBar.Width - 70;
            }

            // localization
            btnOk.Text = db.GetLangString("Application.Ok");
            btnCancel.Text = db.GetLangString("Application.Cancel");
            chkMSM.Text = db.GetLangString("ManualUpdatesForm.chkMSM");
            chkGLSubcatRel.Text = db.GetLangString("ManualUpdatesForm.chkGLSubcatRel");
            chkBudget.Text = db.GetLangString("ManualUpdatesForm.chkGLBudget");
#if FSD
            chkLL.Text = db.GetLangString("ManualUpdatesForm.chkLL");
#else
            chkLL.Text = db.GetLangString("ManualUpdatesForm.chkFVD");
#endif
            chkLLSubcatRel.Text = db.GetLangString("ManualUpdatesForm.chkLLSubcatRel");
            this.Text = db.GetLangString("ManualUpdatesForm.Title");
            chkPrlAbsense.Text = db.GetLangString("ManualUpdatesForm.chkPrlAbsense");
            chkPrlAgreement.Text = db.GetLangString("ManualUpdatesForm.chkPrlAgreement");
            chkPrlClusterSites.Text = db.GetLangString("ManualUpdatesForm.chkPrlClusterSites");
            chkPrlEmployee.Text = db.GetLangString("ManualUpdatesForm.chkPrlEmployee");
            chkPrlHolidays.Text = db.GetLangString("ManualUpdatesForm.chkPrlHolidays");
            chkPrlSalaryPeriods.Text = db.GetLangString("ManualUpdatesForm.chkPrlSalaryPeriods");
            chkRRDebitorData.Text = db.GetLangString("ManualUpdatesForm.chkRRDebitorData");
            chkSubCatSetup.Text = db.GetLangString("ManualUpdatesForm.chkSubCatSetup");
            chkEPD.Text = db.GetLangString("ManualUpdatesForm.chkEPD");
            chkWPF.Text = db.GetLangString("ManualUpdatesForm.chkWPF");
        }
        #endregion

        #region ManualUpdatesPresent property
        /// <summary>
        /// Tells if manual update files are present.
        /// This is set in the constructor.
        /// </summary>
        public bool ManualUpdatesPresent
        {
            get { return manualUpdatesPresent; }
        }
        #endregion

        #region LLJustUpdated property

        private bool _XVDUpdaterHasRun = false;
        public bool XVDUpdaterHasRun
        {
            get { return _XVDUpdaterHasRun; }
        }
        #endregion

        #region PrepareFileGLBudget
        private void PrepareFileGLBudget()
        {
            fileGLBudget = arriveDir + AdminDataSet.SiteInformationDataTable.GetSiteCode() + "GLBudget.csv";
            chkBudget.Checked = File.Exists(fileGLBudget);
            chkBudget.Enabled = chkBudget.Checked;
            if (chkBudget.Checked) manualUpdatesPresent = true;
        }
        #endregion

        #region PrepareFileGLSubcatRel
        private void PrepareFileGLSubcatRel()
        {
            fileGLSubcatRel = arriveDir + "GLSubcatRel.csv";
            chkGLSubcatRel.Checked = File.Exists(fileGLSubcatRel);
            chkGLSubcatRel.Enabled = chkGLSubcatRel.Checked;
            if (chkGLSubcatRel.Checked) manualUpdatesPresent = true;
        }
        #endregion

        #region PrepareFileMSM
        private void PrepareFileMSM()
        {
            fileMSM = arriveDir + "rpos_msm_config.csv";
            chkMSM.Checked = File.Exists(fileMSM);
            chkMSM.Enabled = chkMSM.Checked;
            if (chkMSM.Checked) manualUpdatesPresent = true;
        }
        #endregion

        #region PrepareFileLL
        private void PrepareFileLL()
        {
            _XVDUpdaterHasRun = false;

            // get list of LL files, prepend arrive dir to path then sort the list
            filesLL = new List<string>(Directory.GetFiles(arriveDir, "LL*.LVD"));
            filesLL.Sort();

            // don't import files we already have imported,
            // this is checked by the datetime in the filename
            List<string> tmpFilesLL = new List<string>();
            tmpFilesLL.AddRange(filesLL);
            foreach (string file in tmpFilesLL)
            {
                DateTime datetime = GetXVDFileDateTime(file, XVD_filepattern.LVD);
                if (datetime == DateTime.MinValue)
                {
                    // remove wrongly named file
                    filesLL.Remove(file);
                }
                else if (ImportDataSet.ItemUpdatesDataTable.RecordWithDateTimeAlreadyExists(datetime))
                {
                    // remove and delete already imported file
                    filesLL.Remove(file);
                    if (File.Exists(file))
                    {
                        tools.RemoveFileWriteProtection(file);
                        File.Delete(file);
                    }
                }
            }
            
            // check if LL files are present
            chkLL.Checked = (filesLL.Count > 0);
            chkLL.Enabled = chkLL.Checked;
            if (chkLL.Checked) manualUpdatesPresent = true;
        }
        #endregion

        #region PrepareFileFVD
        private void PrepareFileFVD()
        {
            _XVDUpdaterHasRun = false;

            // get list of FVD files, prepend arrive dir to path then sort the list
            filesFVD = new List<string>(Directory.GetFiles(arriveDir, "FSD*.FVD"));
            filesFVD.Sort();

            // don't import files we already have imported,
            // this is checked by the datetime in the filename
            List<string> tmpFilesFVD = new List<string>();
            tmpFilesFVD.AddRange(filesFVD);
            foreach (string file in tmpFilesFVD)
            {
                DateTime datetime = GetXVDFileDateTime(file, XVD_filepattern.FVD);
                if (datetime == DateTime.MinValue)
                {
                    // remove wrongly named file
                    filesFVD.Remove(file);
                }
                else if (ImportDataSet.ItemUpdatesDataTable.RecordWithDateTimeAlreadyExists(datetime))
                {
                    // remove and delete already imported file
                    filesFVD.Remove(file);
                    if (File.Exists(file))
                    {
                        tools.RemoveFileWriteProtection(file);
                        File.Delete(file);
                    }
                }
            }

            // check if FVD files are present
            chkLL.Checked = (filesFVD.Count > 0);
            chkLL.Enabled = chkLL.Checked;
            if (chkLL.Checked) manualUpdatesPresent = true;
        }
        #endregion

        #region PrepareFileLLSubcatRel
        private void PrepareFileLLSubcatRel()
        {
            fileLLSubcatRel = arriveDir + "LLSubcatRel.csv";
            chkLLSubcatRel.Checked = File.Exists(fileLLSubcatRel);
            chkLLSubcatRel.Enabled = chkLLSubcatRel.Checked;
            if (chkLLSubcatRel.Checked) manualUpdatesPresent = true;
        }
        #endregion

        #region PreparePrlEmployee
        private void PreparePrlEmployee()
        {
            filePrlEmployee = arriveDir + "Meda" + AdminDataSet.SiteInformationDataTable.GetSiteCode() + ".lon";
            chkPrlEmployee.Checked = File.Exists(filePrlEmployee);
            chkPrlEmployee.Enabled = chkPrlEmployee.Checked;
            if (chkPrlEmployee.Checked) manualUpdatesPresent = true;
        }
        #endregion

        #region PreparePrlAbsense
        private void PreparePrlAbsense()
        {
            filePrlAbsense = arriveDir + "absense.csv";
            chkPrlAbsense.Checked = File.Exists(filePrlAbsense);
            chkPrlAbsense.Enabled = chkPrlAbsense.Checked;
            if (chkPrlAbsense.Checked) manualUpdatesPresent = true;
        }
        #endregion

        #region PreparePrlAgreement
        private void PreparePrlAgreement()
        {
            filePrlAgreement = arriveDir + "agreement.csv";
            chkPrlAgreement.Checked = File.Exists(filePrlAgreement);
            chkPrlAgreement.Enabled = chkPrlAgreement.Checked;
            if (chkPrlAgreement.Checked) manualUpdatesPresent = true;
        }
        #endregion

        #region PreparePrlHolidays
        private void PreparePrlHolidays()
        {
            filePrlHolidays = arriveDir + "HolliDay.csv";
            chkPrlHolidays.Checked = File.Exists(filePrlHolidays);
            chkPrlHolidays.Enabled = chkPrlHolidays.Checked;
            if (chkPrlHolidays.Checked) manualUpdatesPresent = true;
        }
        #endregion

        #region PreparePrlSalaryPeriods
        private void PreparePrlSalaryPeriods()
        {
            filePrlSalaryPeriods = arriveDir + "PayPer.csv";
            chkPrlSalaryPeriods.Checked = File.Exists(filePrlSalaryPeriods);
            chkPrlSalaryPeriods.Enabled = chkPrlSalaryPeriods.Checked;
            if (chkPrlSalaryPeriods.Checked) manualUpdatesPresent = true;
        }
        #endregion

        #region PreparePrlClusterSites
        private void PreparePrlClusterSites()
        {
            filePrlClusterSites = arriveDir + "ClusterSites.csv";
            chkPrlClusterSites.Checked = File.Exists(filePrlClusterSites);
            chkPrlClusterSites.Enabled = chkPrlClusterSites.Checked;
            if (chkPrlClusterSites.Checked) manualUpdatesPresent = true;
        }
        #endregion

        #region PrepareRRDebitorData
        private void PrepareRRDebitorData()
        {
            fileRRDebitorData = arriveDir + "RRDebitorData.rrd";
            chkRRDebitorData.Checked = File.Exists(fileRRDebitorData);
            chkRRDebitorData.Enabled = chkRRDebitorData.Checked;
            if (chkRRDebitorData.Checked) manualUpdatesPresent = true;
        }
        #endregion

        #region PrepareSubCatSetup
        private void PrepareSubCatSetup()
        {
            fileSubCatSetup = arriveDir + "SubCatSetup.csv";
            chkSubCatSetup.Checked = File.Exists(fileSubCatSetup);
            chkSubCatSetup.Enabled = chkSubCatSetup.Checked;
            if (chkSubCatSetup.Checked) manualUpdatesPresent = true;
        }
        #endregion

        #region PrepareEPD (only RBA)
#if RBA
        private void PrepareEPD()
        {
            string SiteCode = AdminDataSet.SiteInformationDataTable.GetSiteCode();
            filesEPD = new List<string>(Directory.GetFiles(arriveDir, string.Format("{0}*.epd", SiteCode)));
            chkEPD.Checked = (filesEPD.Count > 0);
            chkEPD.Enabled = chkEPD.Checked;
            if (chkEPD.Checked) manualUpdatesPresent = true;
        }
#endif
        #endregion

        #region PrepareWPF (only RBA)
        private void PrepareWPF()
        {
            if (importWPF == null)
                importWPF = new ImportWPF();
            chkWPF.Checked = importWPF.FilesPresent(arriveDir);
            chkWPF.Enabled = chkWPF.Checked;
            if (chkWPF.Checked)
                manualUpdatesPresent = true;
        }
        #endregion

        #region PrepareDS 

        private void PrepareDS()
        {
            string SiteCode = AdminDataSet.SiteInformationDataTable.GetSiteCode();
            filesDS = new List<string>(Directory.GetFiles(arriveDir, string.Format("{0}*.DS", SiteCode)));
            chkDanskeSpil.Checked = (filesDS.Count > 0);
            chkDanskeSpil.Enabled = chkDanskeSpil.Checked;
            if (chkDanskeSpil.Checked) manualUpdatesPresent = true;
        }

        #endregion

        #region UpdateMSM
        /// <summary>
        /// Imports rpos_msm_config.csv file if existing in upd directory.
        /// </summary>
        /// <returns></returns>
        private bool UpdateMSM()
        {
            // start db transaction
            db.StartTransaction();

            try
            {
                // check if file exist
                if (File.Exists(fileMSM))
                {
                    OleDbCommand cmd = new OleDbCommand("", db.Connection);
                    cmd.Transaction = db.CurrentTransaction;

                    // setup progress bar
                    SetupProgressBar(db.GetLangString("ManualUpdatesForm.Progress.MSMConfig"), fileMSM);

                    // create csv parser
                    GenericParser parser = tools.CreateCSVParser(fileMSM, ';', true);

                    // empty table in database
                    cmd.CommandText = " delete from Import_RPOS_MSM_Config ";
                    cmd.ExecuteNonQuery();

                    // parse file and insert data in database
                    while (parser.Read())
                    {
                        // get data
                        int SummaryCode = tools.object2int(parser["Misc Sum Code"]);
                        int SubCode = tools.object2int(parser["Sub-Code"]);
                        string Modifier = CorrectedMSMString(parser["Modifier"], 8);
                        string Description = CorrectedMSMString(parser["Description"], 50);
                        string ModifierDesc = CorrectedMSMString(parser["Mod Description"], 50);
                        string TenderCode = CorrectedMSMString(parser["TenderCode"], 4);
                        string TenderSubCode = CorrectedMSMString(parser["TenderSubCode"], 4);
                        bool IncludeInImport = tools.object2bool(parser["IncludeInImport"]);
                        string IncludeAction = CorrectedMSMString(parser["IncludeAction"], 4);
                        string IncludeCode = CorrectedMSMString(parser["IncludeCode"], 10);

                        // build and execute sql
                        cmd.CommandText = string.Format(
                            " insert into Import_RPOS_MSM_Config " +
                            " (SummaryCode,SubCode,Modifier,Description,ModifierDesc,TenderCode,TenderSubCode,IncludeInImport,IncludeAction,IncludeCode) " +
                            " values ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9}) ",
                            SummaryCode,
                            SubCode,
                            Modifier,
                            Description,
                            ModifierDesc,
                            TenderCode,
                            TenderSubCode,
                            IncludeInImport,
                            IncludeAction,
                            IncludeCode);
                        cmd.ExecuteNonQuery();
                        ProgressBar.PerformStep();
                    }

                    // import done, delete the file
                    tools.RemoveFileWriteProtection(fileMSM);
                    File.Delete(fileMSM);

                    // remove checkmark so user can see update is done
                    chkMSM.Checked = false;
                    chkMSM.Refresh();
                }

                // commit db transaction
                db.CommitTransaction();

                // report success
                return true;
            }
            catch (Exception ex)
            {
                // rollback db transaction
                db.RollbackTransaction();

                // error import rpos_msm_config.csv
                MessageBox.Show(log.WriteException("Error loading rpos_msm_config.csv", ex.Message, ex.StackTrace));
                return false;
            }
        }
        #endregion

        #region UpdateGLSubcatRel
        /// <summary>
        /// Imports GLSubcatRel.csv file if existing in upd directory.
        /// </summary>
        /// <returns></returns>
        private bool UpdateGLSubcatRel()
        {
            // start db transaction
            db.StartTransaction();

            try
            {
                // check if file exist
                if (File.Exists(fileGLSubcatRel))
                {
                    // setup progress bar
                    SetupProgressBar(db.GetLangString("ManualUpdatesForm.Progress.GLSubcatRel"), fileGLSubcatRel);

                    // create csv parser
                    GenericParser parser = tools.CreateCSVParser(fileGLSubcatRel, ';', true);

                    // empty table GLAccount
                    db.ExecuteNonQuery(" delete from GLAccount ");

                    // parse file and insert data in database
                    while (parser.Read())
                    {
                        // get data
                        string GLCode = tools.string4sql(parser["GL code"], 8);
                        if (tools.object2string(parser["GL code"]) != "") // do not check GLCode variable
                        {
                            string Description = tools.string4sql(parser["RBOS GL Description"], 25);
                            bool ShowLitres = (parser["ShowLiters"] != "");
                            bool ShowInReport = (parser["NotInReport"] == "");

                            // check that this GLCode has not already been imported
                            if (tools.IsNullOrDBNull(db.ExecuteScalar(string.Format(
                                " select GLCode from GLAccount where GLCode = {0} ", GLCode))))
                            {
                                // GLCode not found so insert record
                                db.ExecuteNonQuery(string.Format(
                                    " insert into GLAccount " +
                                    " (GLCode,Description,ShowLitres,ShowInReport) " +
                                    " values ({0},{1},{2},{3}) ",
                                    GLCode,
                                    Description,
                                    ShowLitres,
                                    ShowInReport));
                            }
                        }

                        // make reference in SubCategory to this GLCode record
                        // (put here as some subcats have the same glcode)
                        string SubCategory = "'" + parser["SubCategory"] + "'";
                        db.ExecuteNonQuery(string.Format(
                            " update SubCategory " +
                            " set GLCode = {0} " +
                            " where SubCategoryID = {1} ",
                            GLCode, SubCategory));

                        ProgressBar.PerformStep();
                    }

                    // import done, delete the file
                    tools.RemoveFileWriteProtection(fileGLSubcatRel);
                    File.Delete(fileGLSubcatRel);

                    // remove checkmark so user can see update is done
                    chkGLSubcatRel.Checked = false;
                    chkGLSubcatRel.Refresh();
                }

                // commit db transaction
                db.CommitTransaction();

                // report success
                return true;
            }
            catch (Exception ex)
            {
                // rollback db transaction
                db.RollbackTransaction();

                // error import rpos_msm_config.csv
                MessageBox.Show(log.WriteException("Error loading GLSubcatRel.csv:", ex.Message, ex.StackTrace));
                return false;
            }
        }
        #endregion

        #region UpdateGLBudget
        /// <summary>
        /// Imports GLBudget.csv file if existing in upd directory.
        /// </summary>
        /// <returns></returns>
        private bool UpdateGLBudget()
        {
            // start db transaction
            db.StartTransaction();

            try
            {
                // check if file exist
                if (File.Exists(fileGLBudget))
                {
                    // setup progress bar
                    SetupProgressBar(db.GetLangString("ManualUpdatesForm.Progress.GLBudget"), fileGLBudget);

                    // create csv parser
                    GenericParser parser = tools.CreateCSVParser(fileGLBudget, ',', false);

                    // used when deleting records for a year
                    bool yearDeleted = false;

                    // parse file and insert data in database
                    while (parser.Read())
                    {
                        string GLCode = parser[0];
                        string Year = parser[1];

                        if (!yearDeleted)
                        {
                            db.ExecuteNonQuery(string.Format(
                                " delete from GLBudget " +
                                " where BudgetYear = {0} ",
                                tools.object2int(Year)));
                            yearDeleted = true;
                        }

                        for (int i = 2; i < 14; i++)
                        {
                            db.ExecuteNonQuery(string.Format(
                                " insert into GLBudget " +
                                " (GLCode,BudgetYear,BudgetMonth,Amount,Volume) " +
                                " values ('{0}',{1},{2},'{3}','{4}') ",
                                GLCode,
                                Year,
                                i - 1,
                                parser[i],
                                parser[i + 12]));
                        }

                        ProgressBar.PerformStep();
                    }

                    // import done, delete the file
                    tools.RemoveFileWriteProtection(fileGLBudget);
                    File.Delete(fileGLBudget);

                    // remove checkmark so user can see update is done
                    chkBudget.Checked = false;
                    chkBudget.Refresh();
                }

                // commit db transaction
                db.CommitTransaction();

                // report success
                return true;
            }
            catch (Exception ex)
            {
                // rollback db transaction
                db.RollbackTransaction();

                // error import rpos_msm_config.csv
                MessageBox.Show(log.WriteException("Error loading GLBudget.csv:", ex.Message, ex.StackTrace));
                return false;
            }
        }
        #endregion

        #region UpdateLL
        /// <summary>
        /// Imports LL files if existing in upd directory.
        /// Note that the prepare method for this method
        /// takes care of that a file is not re-imported.
        /// </summary>
        /// <returns></returns>
        private bool UpdateLL()
        {
            // start db transaction
            db.StartTransaction();

            // if exception occurs when importing a
            // file, this is used to report the file
            string exCatchFile = "";

            try
            {
                // setup progress bar to count all lines in all files
                int max = 0;
                foreach (string file in filesLL)
                {
                    if(File.Exists(file))
                        max += File.ReadAllLines(file).Length;
                }
                SetupProgressBar(db.GetLangString("ManualUpdatesForm.Progress.LL"), max);

                // import each LL file
                foreach (string file in filesLL)
                {
                    exCatchFile = file;

                    // check if file exist
                    if (File.Exists(file))
                    {
                        // retrieve datetime from filename
                        DateTime datetime = GetXVDFileDateTime(file, XVD_filepattern.LVD);

                        // create header record in table ItemUpdates
                        db.ExecuteNonQuery(string.Format(
                            " insert into ItemUpdates " +
                            " (UpdDate,Origin) " +
                            " values ('{0}','LVD') ",
                            datetime));

                        // counters to be inserted in header record when details are done
                        int NoOfLines = 0;
                        int NoOfOpen = 0;

                        // extract autogenerated header ID
                        int ID = tools.object2int(db.ExecuteScalar(" select max(ID) from ItemUpdates "));

                        // parse each line in the file and insert records in database
                        StreamReader reader = new StreamReader(file, Encoding.GetEncoding("iso-8859-1"));
                        while (!reader.EndOfStream)
                        {
                            // read the line and get value BEGIVENHEDSKODE
                            string line = reader.ReadLine();
                            string BEGIVENHEDSKODE = line.Substring(0, 2).Trim().ToUpper();

                            // check that this is a LL line we support importing
                            if ((BEGIVENHEDSKODE == "NV") || // new item
                                (BEGIVENHEDSKODE == "UV") || // discarded item
                                (BEGIVENHEDSKODE == "NK") || // new cost price
                                (BEGIVENHEDSKODE == "EP") || // new own price = new sales price
                                (BEGIVENHEDSKODE == "VU"))   // new sales price
                            {
                                // get the remaining needed values
                                double EANNR = tools.object2double(line.Substring(2, 13).Trim());
                                int VARENR = tools.object2int(line.Substring(19, 7).Trim());
                                string LAGTXT = line.Substring(38, 25).Trim();
                                int STKENH = tools.object2int(line.Substring(63, 5).Trim());
                                string ENHSTR = line.Substring(68, 6).Trim();
                                //assume Stk always//string ENHBET = line.Substring(74, 3).Trim();
                                string VarenavnEkstraSpec = line.Substring(68, 4).Trim() + " " + line.Substring(72, 2).Trim() + " " + line.Substring(74, 2).Trim();
                                int BOGFGRP = tools.object2int(line.Substring(77, 4).Trim());
                                bool FASTPRIS = ((line.Substring(82, 1).Trim().ToUpper() == "J") ? true : false);
                                double ENHPRIS = (tools.object2double(line.Substring(91, 6).Trim()) / 1000);
                                double E_PRIS = (tools.object2double(line.Substring(97, 6).Trim()) / 100);
                                double VEJLUDS = (tools.object2double(line.Substring(103, 6).Trim()) / 100);
                                string SUBVNR = line.Substring(109, 7).Trim();
                                int LEVERANDOER = tools.object2int(line.Substring(134,6).Trim());

                                // Lekkerland has made a mistake, as
                                // "VU" actually should have been "UV"
                                if (BEGIVENHEDSKODE == "VU")
                                    BEGIVENHEDSKODE = "UV";

                                // if E_PRIS != 0, used E_PRIS for SalesPrice, otherwise use VEJLUDS
                                double SalesPrice = ((E_PRIS != 0) ? E_PRIS : VEJLUDS);
                                
                                // for now supplierno is set to 4 (Lekkerland)
                                LEVERANDOER = dbSupplier.GetSupplierID(LEVERANDOER);

                                // variable FoundBarcode used in criteria checks
                                // (true if the barcode exists in the database)
                                bool FoundBarcode = !tools.IsNullOrDBNull(db.ExecuteScalar(string.Format(
                                    " select Barcode from Barcode " +
                                    " where Barcode = {0} ", EANNR)));

                                // variable FoundSupplierRow is used to get data for the found supplier row,
                                // and to tell whether the combination of OrderingNumber and SupplierNo exists
                                // in the database. if the combination does not exist, the variable is null.
                                DataRow FoundSupplierItemRow = db.GetDataRow(string.Format(
                                        " select * from SupplierItem " +
                                        " where (OrderingNumber = {0}) " +
                                        " and (SupplierNo = {1}) ",
                                        VARENR,
                                        LEVERANDOER));

                                // if set to true, the record is
                                // not included for update
                                bool SkipRecord = false;

                                // check for a special condition where:
                                // criteria: if CostPrice or SalesPrice are 0
                                // criteria: we already have the item
                                // then do not include the record for import
                                if (((ENHPRIS == 0) || (SalesPrice == 0)) &&
                                    (FoundBarcode || (FoundSupplierItemRow != null) ||
                                    ItemDataSet.XVDDataFoundInInactiveItems(EANNR, VARENR, LEVERANDOER)))
                                {
                                    // this is an item we already have
                                    // and that LL does not have the costprice
                                    // or salesprice for, and therefore must
                                    // be an item that is from another supplier
                                    SkipRecord = true;
                                }


                                // detect action Item Discarded
                                // criteria: BEGIVENHEDSKODE == "UV"
                                // criteria: barcode or supplier info found
                                // criteria: if not found, do not import, SkipRecord = true
                                bool ActionItemDiscarded = false;
                                if (!SkipRecord)
                                {
                                    if (BEGIVENHEDSKODE == "UV")
                                    {
                                        // check that barcode or supplier info was found
                                        if (FoundBarcode || (FoundSupplierItemRow != null))
                                            ActionItemDiscarded = true;
                                        else
                                        {
                                            ItemDataSet.DeleteXVDDataInInactiveItems(EANNR, VARENR, LEVERANDOER);
                                            SkipRecord = true;
                                        }
                                    }
                                }

                                if (!SkipRecord)
                                {
                                    // detect ActionNewItem.
                                    // criteria: neither barcode nor supplier info can be found in db.
                                    bool ActionNewItem = false;
                                    if (!ActionItemDiscarded)
                                        ActionNewItem = (!FoundBarcode && (FoundSupplierItemRow == null));

                                    // detect ActionNewCostPrice.
                                    // criteria: supplier info can be found in db.
                                    // criteria: costprice must be different.
                                    bool ActionNewCostPrice = false;
                                    double dbCostPrice = 0;
                                    double dbSalesPrice = 0; // can be set in both CostPrice and SalesPrice changes
                                    if (!ActionItemDiscarded)
                                    {
                                        if (FoundSupplierItemRow != null)
                                        {
                                            // check that costprice is different
                                            dbCostPrice = tools.object2double(FoundSupplierItemRow["PackageUnitCost"]);
                                            if (Math.Round(dbCostPrice, 3) != ENHPRIS)
                                            {
                                                // also get the existing salesprice
                                                // on the item to show to user
                                                int tmpItemID = tools.object2int(FoundSupplierItemRow["ItemID"]);
                                                dbSalesPrice = ItemDataSet.ItemDataTable.GetPOSSalesPrice(tmpItemID);

                                                // now we can flag new costprice action
                                                ActionNewCostPrice = true;
                                            }
                                        }
                                    }

                                    // detect action New Sales Price.
                                    // criteria: either barcode or supplier info must be found in db.
                                    // criteria: only 1 supplieritem and 1 salespack must exist.
                                    // criteria: salesprice must be different than on disk.
                                    // criteria: salesprice must be different that 0
                                    // NOTE: use variable SalesPrice, NOT E_PRIS/VEJLUDS
                                    bool ActionNewSalesPrice = false;
                                    if (!ActionItemDiscarded && (SalesPrice != 0))
                                    {
                                        if (FoundBarcode || (FoundSupplierItemRow != null))
                                        {
                                            // get the ItemID either via barcode or supplieritem info
                                            int tmpItemID = 0;
                                            if (FoundBarcode)
                                                tmpItemID = ItemDataSet.ItemDataTable.GetItemIDFromBarcode(EANNR);
                                            else if (FoundSupplierItemRow != null)
                                                tmpItemID = ItemDataSet.ItemDataTable.GetItemIDFromSupplierItem(
                                                    tools.object2int(FoundSupplierItemRow["SupplierNo"]),
                                                    tools.object2double(FoundSupplierItemRow["OrderingNumber"]));

                                            // only set ActionNewSalesPrice if
                                            // only one salespack exists on the item
                                            if (ItemDataSet.ItemDataTable.NumSalesPacksOnItem(tmpItemID) == 1)
                                            {
                                                // check that salesprice is different
                                                dbSalesPrice = tools.object2double(db.ExecuteScalar(string.Format(
                                                    " select SalesPrice " +
                                                    " from SalesPack " +
                                                    " where ItemID = {0} ",
                                                    tmpItemID)));
                                                if (Math.Round(dbSalesPrice, 2) != SalesPrice)
                                                {
                                                    // now we can flag new salesprice action
                                                    ActionNewSalesPrice = true;
                                                }
                                            }
                                        }
                                    }

                                    // detect action New Barcode.
                                    // criteria: barcode not 0
                                    // criteria: barcode not found but supplier info found
                                    // criteria: barcode is different
                                    bool ActionNewBarcode = false;
                                    if (!ActionItemDiscarded && (EANNR != 0))
                                    {
                                        if (!FoundBarcode && (FoundSupplierItemRow != null))
                                        {
                                            // check that barcode is different
                                            // (assumes that a barcode can only exists once in the Barcode table)
                                            int tmpNumBarcodes = tools.object2int(db.ExecuteScalar(string.Format(
                                                " select count(*) " +
                                                " from Barcode " +
                                                " where Barcode = {0} ",
                                                EANNR)));
                                            if (tmpNumBarcodes < 1)
                                            {
                                                // now we can flag new barcode action
                                                ActionNewBarcode = true;
                                            }
                                        }
                                    }

                                    // attempt to find ItemID on existing item
                                    int ItemID = 0;
                                    if (FoundBarcode)
                                    {
                                        ItemID = tools.object2int(db.ExecuteScalar(string.Format(
                                            " select ItemID from Barcode " +
                                            " where Barcode = {0} ",
                                            EANNR)));
                                    }
                                    else if (FoundSupplierItemRow != null)
                                    {
                                        ItemID = tools.object2int(FoundSupplierItemRow["ItemID"]);
                                    }

                                    // detect action New Supplier Item Number.
                                    // criteria: barcode found but supplier info not found
                                    bool ActionNewSupplierItemNo = false;
                                    if (!ActionItemDiscarded)
                                    {
                                        // use ealier declared variable dbCostPrice to
                                        // insert the latest cost price from item so it is not empty to user
                                        ActionNewSupplierItemNo = (FoundBarcode && (FoundSupplierItemRow == null));
                                        if (ActionNewSupplierItemNo)
                                        {
                                            int tmpItemID = ItemDataSet.ItemDataTable.GetItemIDFromBarcode(EANNR);
                                            dbCostPrice = ItemDataSet.ItemDataTable.GetCostPriceLatest(tmpItemID);
                                        }
                                    }

                                    // detect action No Change
                                    bool ActionNoChange = false;
                                    string ActionSummary = ItemUpdLines.BuildActionSummary(
                                        ActionNewItem,
                                        ActionNewCostPrice,
                                        ActionNewSalesPrice,
                                        ActionNewBarcode,
                                        ActionNewSupplierItemNo,
                                        ActionItemDiscarded,
                                        ref ActionNoChange);

                                    // get the correct subcategory
                                    string SubCategory = "";
                                    if (ItemID > 0)
                                    {
                                        // it's an existing item, so take the subcategory from RBOS (not from import file)
                                        SubCategory = ItemDataSet.ItemDataTable.GetSubCategory(ItemID);
                                    }
                                    else
                                    {
                                        /// Lookup the RBOS subcategory via LLSubcatRel.
                                        SubCategory = tools.object2string(db.ExecuteScalar(string.Format(
                                            " select SubCategory from LLSubcatRel " +
                                            " where LLCat = {0} ", BOGFGRP)));
                                    }

                                    // if SubCategory was not found, set Skip flag to true
                                    bool SkipFlag = (SubCategory == "");

                                    // get the next lineno for this detail records in table ItemUpdLines
                                    int LineNo = tools.object2int(db.ExecuteScalar(string.Format(
                                        " select max(LineNo) " +
                                        " from ItemUpdLines " +
                                        " where ID = {0} ", ID))) + 1;

                                    ImportDataSet.LookupLLStatusDataTable.LLStatus Status = ((ActionNoChange || SkipFlag) ? ImportDataSet.LookupLLStatusDataTable.LLStatus.Closed : ImportDataSet.LookupLLStatusDataTable.LLStatus.Open);


                                    // if action is new item, use LL item name
                                    // otherwise use our itemname, so user can reconize it
                                    string Name = "";
                                    if (ActionNewItem)
                                        Name = LAGTXT + " " + VarenavnEkstraSpec;
                                    else
                                    {
                                        int tmpItemID = 0;
                                        if (FoundBarcode)
                                        {
                                            tmpItemID = tools.object2int(db.ExecuteScalar(string.Format(
                                                " select ItemID from Barcode " +
                                                " where Barcode = {0} ",
                                                EANNR)));
                                        }
                                        else if (FoundSupplierItemRow != null)
                                        {
                                            tmpItemID = tools.object2int(FoundSupplierItemRow["ItemID"]);
                                        }
                                        Name = tools.object2string(db.ExecuteScalar(string.Format(
                                            " select ItemName from Item " +
                                            " where ItemID = {0} ",
                                            tmpItemID)));
                                    }

                                    // if action is discarded,
                                    // 0 the cost and sales price,
                                    // so use sees zeroes
                                    if (ActionItemDiscarded)
                                    {
                                        ENHPRIS = 0;
                                        SalesPrice = 0;
                                    }
                                    else
                                    {
                                        // in any other action type than discarded,
                                        // if costprice is 0, handle something
                                        if (ENHPRIS == 0)
                                        {
                                            // if both costprice and salesprice
                                            // are zero, set costprice to 1.0
                                            if (SalesPrice == 0)
                                                ENHPRIS = 1.0;
                                            else
                                            {
                                                // salesprice is different from zero,
                                                // attempt to calculate the costprice
                                                // using margin and salesprice
                                                double BudgetMargin = ItemDataSet.SubCategoryDataTable.GetBudgetMargin(SubCategory);
                                                if (BudgetMargin != 0)
                                                    ENHPRIS = tools.CalcCostPrice(BudgetMargin, SalesPrice);
                                                else
                                                    ENHPRIS = 1.0;
                                            }
                                        }
                                    }

                                    // if ActionNewItem or ActionNewSupplierItemNo,
                                    // disable any possible actions on
                                    // NewBarcode, NewCostPrice and NewSalesPrice
                                    if (ActionNewItem || ActionNewSupplierItemNo)
                                    {
                                        ActionNewBarcode = false;
                                        ActionNewCostPrice = false;
                                        ActionNewSalesPrice = false;
                                    }

                                    /// if marked as a new item here,
                                    /// check if it can be found in inactive items.
                                    /// if so, do not insert the item here but
                                    /// update the inactive item instead.
                                    bool FoundInInactiveItems = false;
                                    if (ActionNewItem)
                                    {
                                        FoundInInactiveItems = ItemDataSet.UpdateXVDDataInInactiveItems(
                                            EANNR, VARENR, LEVERANDOER, ENHPRIS, SalesPrice, STKENH, 0, 0, 0);
                                    }

                                    if (!FoundInInactiveItems)
                                    {
                                        // insert ItemUpdLines record
                                        db.ExecuteNonQuery(string.Format(
                                            " insert into ItemUpdLines " +
                                            " (ID,LineNo,LLAction,Name,Category,PackType,LLSalesPr,SalesPrice,Barcode," +
                                            "  SupplierNo,OrderingNumber,Kolli,CostPrice,FixedPrice,SubstNr,EnhBeteg,ActionSummary," +
                                            "  ActionNewItem,ActionNewCostPrice,ActionNewSalesPrice," +
                                            "  ActionNewSupplierItemNo,ActionNewBarcode,ActionItemDiscarded,Skip,Status," +
                                            "  SubCat,LogCost,LogSales,NoChSales) " +
                                            " values ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}," +
                                            " {11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}," +
                                            " {22},{23},{24},{25},{26},{27},{28}) ",
                                            ID,
                                            LineNo,
                                            tools.string4sql(BEGIVENHEDSKODE, 2),       // field LLAction
                                            tools.string4sql(Name, 50),                 // field Name
                                            BOGFGRP,                                    // field Category (LL category)
                                            1,                                          // field PackType set to Stk
                                            tools.decimalnumber4sql(VEJLUDS),           // field LLSalesPr
                                            tools.decimalnumber4sql(SalesPrice),        // field SalesPrice
                                            tools.decimalnumber4sql(EANNR),             // field Barcode
                                            LEVERANDOER,                                // field SupplierNo
                                            VARENR,                                     // field OrderingNumber
                                            STKENH,                                     // field Kolli
                                            tools.decimalnumber4sql(ENHPRIS),           // field CostPrice
                                            FASTPRIS,                                   // field FixedPrice
                                            SUBVNR,                                     // field SubstNr
                                            tools.string4sql(ENHSTR, 6),                // field EnhBeteg
                                            tools.string4sql(ActionSummary, 30),        // field ActionSummary
                                            ActionNewItem,
                                            ActionNewCostPrice,
                                            ActionNewSalesPrice,
                                            ActionNewSupplierItemNo,
                                            ActionNewBarcode,
                                            ActionItemDiscarded,
                                            SkipFlag,                                   // field Skip
                                            (int)Status,                                // field Status
                                            tools.string4sql(SubCategory, 25),          // field SubCat
                                            tools.decimalnumber4sql(dbCostPrice),       // field LogCost
                                            tools.decimalnumber4sql(dbSalesPrice),      // field LogSales
                                            false));                                    // field NoChSales

                                        // increment counters for header record
                                        ++NoOfLines;
                                        if (Status != ImportDataSet.LookupLLStatusDataTable.LLStatus.Closed)
                                            ++NoOfOpen;
                                    }

                                    // flag that LL updater has run
                                    _XVDUpdaterHasRun = true;

                                } // if !SkipRecord
                            } // if supported BEGIVENHEDSKODE

                            // show progress
                            ProgressBar.PerformStep();
                        }
                        reader.Close();

                        // update header records with counters
                        db.ExecuteNonQuery(string.Format(
                            " update ItemUpdates set " +
                            " NoOfLines = {0}, " +
                            " NoOfOpen = {1} " +
                            " where ID = {2} ",
                            NoOfLines, NoOfOpen, ID));

                        // import done, delete the file
                        tools.RemoveFileWriteProtection(file);
                        File.Delete(file);
                    }
                }

                // remove checkmark so user can see update is done
                chkLL.Checked = false;
                chkLL.Refresh();

                // commit db transaction
                db.CommitTransaction();

                // report success
                return true;
            }
            catch (Exception ex)
            {
                // rollback db transaction
                db.RollbackTransaction();

                // error importing LL files
                MessageBox.Show(
                    log.WriteException("Error loading LL file: " + exCatchFile,
                    ex.Message, ex.StackTrace));
                return false;
            }
        }
        #endregion

        #region UpdateFVD
        /// <summary>
        /// Imports FVD files if existing in upd directory.
        /// Note that the prepare method for this method
        /// takes care of that a file is not re-imported.
        /// </summary>
        /// <returns></returns>
        public bool UpdateFVD()
        {
            bool FSD_IDsWerePreventedBecauseAlreadyOnAnotherItem = false;

            // start db transaction
            db.StartTransaction();

            // if exception occurs when importing a
            // file, this is used to report the file
            string exCatchFile = "";

            try
            {
                // setup progress bar to count all lines in all files
                int max = 0;
                foreach (string file in filesFVD)
                {
                    if (File.Exists(file))
                        max += File.ReadAllLines(file).Length;
                }
                SetupProgressBar(db.GetLangString("ManualUpdatesForm.Progress.FVD"), max);

                // import each FVD file
                foreach (string file in filesFVD)
                {
                    exCatchFile = file;

                    // check if file exist
                    if (File.Exists(file))
                    {
                        // retrieve datetime from filename
                        DateTime datetime = GetXVDFileDateTime(file, XVD_filepattern.FVD);

                        // create header record in table ItemUpdates
                        db.ExecuteNonQuery(string.Format(
                            " insert into ItemUpdates " +
                            " (UpdDate) " +
                            " values ('{0}') ",
                            datetime));

                        // counters to be inserted in header record when details are done
                        int NoOfLines = 0;
                        int NoOfOpen = 0;

                        // extract autogenerated header ID
                        int ID = tools.object2int(db.ExecuteScalar(" select max(ID) from ItemUpdates "));

                        /// variable used when counting how many imported items that
                        /// was coming with a FSD_ID that already existed on another item.
                        /// This we will show to the user after import.
                        Dictionary<int, int> ItemsWithFSD_IDsAlreadyOnAnotherItem = new Dictionary<int,int>();

                        // parse each line in the file and insert records in database
                        GenericParser parser = tools.CreateCSVParser(file, ';', true);
                        while (parser.Read())
                        {
                            // read the line and get value BEGIVENHEDSKODE
                            string Aktion = parser["Aktion"];

                            // check that this is a FVD line we support importing
                            if ((Aktion == "10") ||    // new/edit item
                                (Aktion == "20"))      // discarded item
                            {
                                // get the remaining needed values
                                double EANNR = tools.object2double(parser["Stregkode"].Trim());
                                double VARENR = tools.object2double(parser["Bestillnr"].Trim());
                                string LAGTXT = parser["Varetekst"].Trim();
                                int ENHSTR = tools.object2int(parser["Kolli"].Trim());
                                string SubCategory = parser["Subcat"].Trim();
                                double ENHPRIS = (tools.object2double(parser["Kostpris"].Trim()));
                                double SalesPrice = (tools.object2double(parser["Salgspris"].Trim()));
                                int LEVERANDOER = tools.object2int(parser["Leverandørnr"].Trim());
                                int KampagneID = tools.object2int(parser["KampagneID"].Trim());
                                int FSD_ID = tools.object2int(parser["FSD_ID"].Trim());
                                Nullable<DateTime> FutureSalesPriceDate = null;
                                if (parser.GetColumnIndex("FremtidigSalgsprisDato") >= 0)
                                    FutureSalesPriceDate = tools.object2datetime(parser["FremtidigSalgsprisDato"]);
                                byte PackType = 0;
                                if (parser.GetColumnIndex("PackType") >= 0)
                                    PackType = tools.object2byte(parser["PackType"]);
                                DateTime DisktilbudFraDato = parser.GetColumnIndex("DisktilbudFraDato") >= 0 ? tools.object2datetime(parser["DisktilbudFraDato"]).Date : DateTime.MinValue;
                                DateTime DisktilbudTilDato = parser.GetColumnIndex("DisktilbudTilDato") >= 0 ? tools.object2datetime(parser["DisktilbudTilDato"]).Date : DateTime.MinValue;
                                int DisktilbudThreshold = parser.GetColumnIndex("DisktilbudThreshold") >= 0 ? tools.object2int(parser["DisktilbudThreshold"]) : 0;

                                int ItemID = 0;
                                LEVERANDOER = dbSupplier.GetSupplierID(LEVERANDOER);

                                // variable FoundBarcode used in criteria checks
                                // (true if the barcode exists in the database)
                                bool FoundBarcode = !tools.IsNullOrDBNull(db.ExecuteScalar(string.Format(
                                    " select Barcode from Barcode " +
                                    " where Barcode = {0} ", EANNR)));

                                // variable FoundSupplierRow is used to get data for the found supplier row,
                                // and to tell whether the combination of OrderingNumber and SupplierNo exists
                                // in the database. if the combination does not exist, the variable is null.
                                DataRow FoundSupplierItemRow = db.GetDataRow(string.Format(
                                        " select * from SupplierItem " +
                                        " where (OrderingNumber = {0}) " +
                                        " and (SupplierNo = {1}) ",
                                        VARENR,
                                        LEVERANDOER));

                                // if set to true, the record is
                                // not included for update
                                bool SkipRecord = false;

                                // check for a special condition where:
                                // criteria: if CostPrice or SalesPrice are 0
                                // criteria: we already have the item
                                // then do not include the record for import
                                if (((ENHPRIS == 0) || (SalesPrice == 0)) &&
                                    (FoundBarcode || (FoundSupplierItemRow != null) ||
                                    ItemDataSet.XVDDataFoundInInactiveItems(EANNR, VARENR, LEVERANDOER)))
                                {
                                    // this is an item we already have
                                    // and that LL does not have the costprice
                                    // or salesprice for, and therefore must
                                    // be an item that is from another supplier
                                    SkipRecord = true;
                                }


                                // detect action Item Discarded
                                // criteria: BEGIVENHEDSKODE == "UV"
                                // criteria: barcode or supplier info found
                                // criteria: if not found, do not import, SkipRecord = true
                                bool ActionItemDiscarded = false;
                                if (!SkipRecord)
                                {
                                    if (Aktion == "20")
                                    {
                                        // check that barcode or supplier info was found
                                        if (FoundBarcode || (FoundSupplierItemRow != null))
                                            ActionItemDiscarded = true;
                                        else
                                        {
                                            ItemDataSet.DeleteXVDDataInInactiveItems(EANNR, VARENR, LEVERANDOER);
                                            SkipRecord = true;
                                        }
                                    }
                                }

                                if (!SkipRecord)
                                {
                                    // detect ActionNewItem.
                                    // criteria: neither barcode nor supplier info can be found in db.
                                    bool ActionNewItem = false;
                                    if (!ActionItemDiscarded)
                                        ActionNewItem = (!FoundBarcode && (FoundSupplierItemRow == null));

                                    // detect ActionNewCostPrice.
                                    // criteria: supplier info can be found in db.
                                    // criteria: costprice must be different.
                                    bool ActionNewCostPrice = false;
                                    double dbCostPrice = 0;
                                    double dbSalesPrice = 0; // can be set in both CostPrice and SalesPrice changes
                                    if (!ActionItemDiscarded)
                                    {
                                        if (FoundSupplierItemRow != null)
                                        {
                                            // check that costprice is different
                                            dbCostPrice = tools.object2double(FoundSupplierItemRow["PackageUnitCost"]);
                                            if (Math.Round(dbCostPrice, 3) != ENHPRIS)
                                            {
                                                // also get the existing salesprice
                                                // on the item to show to user
                                                ItemID = tools.object2int(FoundSupplierItemRow["ItemID"]);
                                                dbSalesPrice = ItemDataSet.ItemDataTable.GetPOSSalesPrice(ItemID);

                                                // now we can flag new costprice action
                                                ActionNewCostPrice = true;
                                            }
                                        }
                                    }

                                    // detect action New Sales Price.
                                    // criteria: either barcode or supplier info must be found in db.
                                    // criteria: only 1 supplieritem and 1 salespack must exist.
                                    // criteria: salesprice must be different than on disk.
                                    // criteria: salesprice must be different that 0
                                    // NOTE: use variable SalesPrice, NOT E_PRIS/VEJLUDS
                                    bool ActionNewSalesPrice = false;
                                    if (!ActionItemDiscarded && (SalesPrice != 0))
                                    {
                                        if (FoundBarcode || (FoundSupplierItemRow != null))
                                        {
                                            // get the ItemID either via barcode or supplieritem info
                                            if (FoundBarcode)
                                                ItemID = ItemDataSet.ItemDataTable.GetItemIDFromBarcode(EANNR);
                                            else if (FoundSupplierItemRow != null)
                                                ItemID = ItemDataSet.ItemDataTable.GetItemIDFromSupplierItem(
                                                    tools.object2int(FoundSupplierItemRow["SupplierNo"]),
                                                    tools.object2double(FoundSupplierItemRow["OrderingNumber"]));

                                            if (PackType == 0) // old file format without PackType
                                            {
                                                // only set ActionNewSalesPrice if
                                                // only one salespack exists on the item
                                                if (ItemDataSet.ItemDataTable.NumSalesPacksOnItem(ItemID) == 1)
                                                {
                                                    // check that salesprice is different
                                                    dbSalesPrice = tools.object2double(db.ExecuteScalar(string.Format(
                                                        " select SalesPrice " +
                                                        " from SalesPack " +
                                                        " where ItemID = {0} ",
                                                        ItemID)));
                                                    if (Math.Round(dbSalesPrice, 2) != SalesPrice)
                                                    {
                                                        // now we can flag new salesprice action
                                                        ActionNewSalesPrice = true;
                                                    }
                                                }
                                            }
                                            else // new file format with PackType
                                            {
                                                // only set ActionNewSalesPrice if the
                                                // PackType in the file can be found in the database
                                                if (ItemDataSet.SalesPackDataTable.RecordExist(ItemID, PackType))
                                                {
                                                    // check that salesprice is different
                                                    dbSalesPrice = tools.object2double(db.ExecuteScalar(string.Format(
                                                        " select SalesPrice " +
                                                        " from SalesPack " +
                                                        " where ItemID = {0} and PackType = {1} ",
                                                        ItemID, PackType)));
                                                    if (Math.Round(dbSalesPrice, 2) != SalesPrice)
                                                    {
                                                        // now we can flag new salesprice action
                                                        ActionNewSalesPrice = true;
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    // detect action New Barcode.
                                    // criteria: barcode not 0
                                    // criteria: barcode not found but supplier info found
                                    // criteria: barcode is different
                                    bool ActionNewBarcode = false;
                                    if (!ActionItemDiscarded && (EANNR != 0))
                                    {
                                        if (!FoundBarcode && (FoundSupplierItemRow != null))
                                        {
                                            // check that barcode is different
                                            // (assumes that a barcode can only exists once in the Barcode table)
                                            int tmpNumBarcodes = tools.object2int(db.ExecuteScalar(string.Format(
                                                " select count(*) " +
                                                " from Barcode " +
                                                " where Barcode = {0} ",
                                                EANNR)));
                                            if (tmpNumBarcodes < 1)
                                            {
                                                // now we can flag new barcode action
                                                ActionNewBarcode = true;
                                            }
                                        }
                                    }

                                    // detect action New Supplier Item Number.
                                    // criteria: barcode found but supplier info not found
                                    bool ActionNewSupplierItemNo = false;
                                    if (!ActionItemDiscarded)
                                    {
                                        // use ealier declared variable dbCostPrice to
                                        // insert the latest cost price from item so it is not empty to user
                                        ActionNewSupplierItemNo = (FoundBarcode && (FoundSupplierItemRow == null) && (VARENR > 0));
                                        if (ActionNewSupplierItemNo)
                                        {
                                            ItemID = ItemDataSet.ItemDataTable.GetItemIDFromBarcode(EANNR);
                                            dbCostPrice = ItemDataSet.ItemDataTable.GetCostPriceLatest(ItemID);
                                        }
                                    }


                                    // detect action No Change
                                    bool ActionNoChange = false;
                                    string ActionSummary = ItemUpdLines.BuildActionSummary(
                                        ActionNewItem,
                                        ActionNewCostPrice,
                                        ActionNewSalesPrice,
                                        ActionNewBarcode,
                                        ActionNewSupplierItemNo,
                                        ActionItemDiscarded,
                                        ref ActionNoChange);

                                    // if this is not a Udmelding and
                                    // SubCategory was not found, set Skip flag to true
                                    bool SkipFlag = false;
                                    if ((Aktion != "20") && (SubCategory == ""))
                                        SkipFlag = true;

                                    // get the next lineno for this detail records in table ItemUpdLines
                                    int LineNo = tools.object2int(db.ExecuteScalar(string.Format(
                                        " select max(LineNo) " +
                                        " from ItemUpdLines " +
                                        " where ID = {0} ", ID))) + 1;

                                    ImportDataSet.LookupLLStatusDataTable.LLStatus Status = ((ActionNoChange || SkipFlag) ? ImportDataSet.LookupLLStatusDataTable.LLStatus.Closed : ImportDataSet.LookupLLStatusDataTable.LLStatus.Open);


                                    // if action is new item, use LL item name
                                    // otherwise use our itemname, so user can reconize it
                                    string Name = "";
                                    if (ActionNewItem)
                                        Name = LAGTXT;
                                    else
                                    {
                                        if (FoundBarcode)
                                        {
                                            ItemID = tools.object2int(db.ExecuteScalar(string.Format(
                                                " select ItemID from Barcode " +
                                                " where Barcode = {0} ",
                                                EANNR)));
                                        }
                                        else if (FoundSupplierItemRow != null)
                                        {
                                            ItemID = tools.object2int(FoundSupplierItemRow["ItemID"]);
                                        }
                                        Name = tools.object2string(db.ExecuteScalar(string.Format(
                                            " select ItemName from Item " +
                                            " where ItemID = {0} ",
                                            ItemID)));
                                    }

                                    // if action is discarded,
                                    // 0 the cost and sales price,
                                    // so use sees zeroes
                                    if (ActionItemDiscarded)
                                    {
                                        ENHPRIS = 0;
                                        SalesPrice = 0;
                                    }
                                    else
                                    {
                                        // in any other action type than discarded,
                                        // if costprice is 0, handle something
                                        if (ENHPRIS == 0)
                                        {
                                            // if both costprice and salesprice
                                            // are zero, set costprice to 1.0
                                            if (SalesPrice == 0)
                                                ENHPRIS = 1.0;
                                            else
                                            {
                                                // salesprice is different from zero,
                                                // attempt to calculate the costprice
                                                // using margin and salesprice
                                                double BudgetMargin = ItemDataSet.SubCategoryDataTable.GetBudgetMargin(SubCategory);
                                                if (BudgetMargin != 0)
                                                    ENHPRIS = tools.CalcCostPrice(BudgetMargin, SalesPrice);
                                                else
                                                    ENHPRIS = 1.0;
                                            }
                                        }
                                    }

                                    // if ActionNewItem or ActionNewSupplierItemNo,
                                    // disable any possible actions on
                                    // NewBarcode, NewCostPrice and NewSalesPrice
                                    if (ActionNewItem || ActionNewSupplierItemNo)
                                    {
                                        ActionNewBarcode = false;
                                        ActionNewCostPrice = false;
                                        ActionNewSalesPrice = false;
                                    }

                                    /// if marked as a new item here,
                                    /// check if it can be found in inactive items.
                                    /// if so, do not insert the item here but
                                    /// update the inactive item instead.
                                    bool FoundInInactiveItems = false;
                                    if (ActionNewItem)
                                    {
                                        /// Only check in inactive items if this
                                        /// item does not have a KampagneID.                                        
                                        if (KampagneID <= 0)
                                        {
                                            /// What happens if we don't go in here
                                            /// (that is, if the item did have a KampagneID):
                                            /// The item will be created as a new item,
                                            /// and if the station already had the item as
                                            /// an inactive item, that inactive item is principally
                                            /// a doublet of what has now been created, but that is okay
                                            /// as we support this.

                                            FoundInInactiveItems = ItemDataSet.UpdateXVDDataInInactiveItems(
                                                EANNR, VARENR, LEVERANDOER, ENHPRIS, SalesPrice, ENHSTR, KampagneID, FSD_ID, PackType);
                                        }
                                    }

                                    if (!FoundInInactiveItems)
                                    {
                                        // insert ItemUpdLines record
                                        db.ExecuteNonQuery(string.Format(
                                            " insert into ItemUpdLines " +
                                            " (ID,LineNo,LLAction,Name,PackType,SalesPrice,Barcode," +
                                            "  SupplierNo,OrderingNumber,Kolli,CostPrice,EnhBeteg,ActionSummary," +
                                            "  ActionNewItem,ActionNewCostPrice,ActionNewSalesPrice," +
                                            "  ActionNewSupplierItemNo,ActionNewBarcode,ActionItemDiscarded,Skip,Status," +
                                            "  SubCat,LogCost,LogSales,NoChSales,FSD_ID,KampagneID,FutureSalesPriceDate,DisktilbudFraDato,DisktilbudTilDato,DisktilbudThreshold) " +
                                            " values ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}," +
                                            " {11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}," +
                                            " {22},{23},{24},{25},{26},{27},{28},{29},{30}) ",
                                            ID,
                                            LineNo,
                                            tools.string4sql(Aktion, 2),                // field LLAction
                                            tools.string4sql(Name, 25),                 // field Name
                                            tools.wholenumber4sql(PackType),            // field PackType
                                            tools.decimalnumber4sql(SalesPrice),        // field SalesPrice
                                            tools.decimalnumber4sql(EANNR),             // field Barcode
                                            LEVERANDOER,                                // field SupplierNo
                                            tools.decimalnumber4sql(VARENR),            // field OrderingNumber
                                            tools.wholenumber4sql(ENHSTR),              // field Kolli
                                            tools.decimalnumber4sql(ENHPRIS),           // field CostPrice
                                            tools.wholenumber4sql(ENHSTR),              // field Kolli (@@@ doublet but I dont know which I use in the interface)
                                            tools.string4sql(ActionSummary, 30),        // field ActionSummary
                                            ActionNewItem,
                                            ActionNewCostPrice,
                                            ActionNewSalesPrice,
                                            ActionNewSupplierItemNo,
                                            ActionNewBarcode,
                                            ActionItemDiscarded,
                                            SkipFlag,                                   // field Skip
                                            (int)Status,                                // field Status
                                            tools.string4sql(SubCategory, 25),          // field SubCat
                                            tools.decimalnumber4sql(dbCostPrice),       // field LogCost
                                            tools.decimalnumber4sql(dbSalesPrice),      // field LogSales
                                            false,                                      // field NoChSales
                                            FSD_ID,
                                            KampagneID,
                                            tools.datetime4sql(FutureSalesPriceDate),
                                            tools.datetime4sql(DisktilbudFraDato),
                                            tools.datetime4sql(DisktilbudTilDato),
                                            tools.wholenumber4sql(DisktilbudThreshold)));

                                        // increment counters for header record
                                        ++NoOfLines;
                                        if (Status != ImportDataSet.LookupLLStatusDataTable.LLStatus.Closed)
                                            ++NoOfOpen;

                                        #region Changes directly to db that user is not asked about

                                        /// Nedenstående kode, der udføres direkte på varen,
                                        /// må IKKE udføres hvis det er en udmelding, da
                                        /// der ikke er data og en masse værdier ville blive slettet.

                                        if (Aktion != "20")
                                        {
                                            /// If FSD_ID is not already in use on another item, perform some updates
                                            /// @@@ TODO: Spørg AN om det var meningen, at ItemID KUN må bestemmes ud fra Barcode?
                                            if ((FSD_ID == 0) || (ItemDataSet.ItemDataTable.FSD_ID_AlreadyInUseOnOtherItem(ItemID, FSD_ID) == ""))
                                            {
                                                // directly update item with KampagneID, if needed
                                                // (for inactive item, it is updated ealier in this function)
                                                if (ItemID > 0)
                                                {
                                                    if (ItemDataSet.ItemDataTable.UpdateKampagneIDIfChanged(ItemID, KampagneID))
                                                    {
                                                        if (ItemDataSet.ItemDataTable.GetFSD_ID(ItemID) != FSD_ID)
                                                            ItemDataSet.ItemDataTable.UpdateFSD_ID(ItemID, FSD_ID, KampagneID);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                /// FSD_ID is in use on another item, so we write in the item log
                                                /// and send it to DRS. We also notify the user about this, after all items
                                                /// have been imported.                
                                                if (!ItemsWithFSD_IDsAlreadyOnAnotherItem.ContainsKey(ItemID))
                                                {
                                                    ItemsWithFSD_IDsAlreadyOnAnotherItem.Add(ItemID, FSD_ID);
                                                    FSD_IDsWerePreventedBecauseAlreadyOnAnotherItem = true;
                                                }
                                            }

                                            // directly update KolliSize on supplieritem,
                                            // if it is different from what is found
                                            // on the current item.
                                            if ((FoundSupplierItemRow != null) &&
                                                (ENHSTR > 0) &&
                                                (tools.object2int(FoundSupplierItemRow["KolliSize"]) != ENHSTR))
                                            {
                                                int KolliSize = ENHSTR;
                                                int SupplierNo = tools.object2int(FoundSupplierItemRow["SupplierNo"]);
                                                double OrderingNumber = tools.object2double(FoundSupplierItemRow["OrderingNumber"]);
                                                ItemDataSet.SupplierItemDataTable.UpdateKolliSize(
                                                    KolliSize, SupplierNo, OrderingNumber);
                                            }

                                            /// directly update SubCategory on item
                                            /// if it is different on disk than in db
                                            /// and if allowed by a config setting
                                            if (db.GetConfigStringAsBool("ImportFVD.AllowAutoUpdateSubCategory"))
                                            {
                                                if (ItemID > 0)
                                                    ItemDataSet.ItemDataTable.UpdateSubCategoryIfChanged(
                                                        ItemID, SubCategory);
                                            }

                                            /// if we have a barcode, but no supplierinfo AND
                                            /// we have a new costprice, we just set this on the item's CostPriceLatest field
                                            /// (this is not supported in the GUI interface)
                                            if (FoundBarcode && (FoundSupplierItemRow == null) && (ENHPRIS != 0))
                                            {
                                                ItemID = ItemDataSet.ItemDataTable.GetItemIDFromBarcode(EANNR);
                                                if (ItemID > 0)
                                                {
                                                    if (ItemDataSet.ItemDataTable.GetCostPriceLatest(ItemID) != ENHPRIS)
                                                        ItemDataSet.ItemDataTable.UpdateCostPriceLatest(ItemID, ENHPRIS);
                                                }
                                            }

                                            /// directly update Disktilbud til/fra dates on item (which means not new items)
                                            if (ItemID > 0)
                                            {
                                                ItemDataSet.ItemDataTable.UpdateDisktilbud(ItemID, DisktilbudFraDato, DisktilbudTilDato, DisktilbudThreshold);

                                                // also create a history record of this disktilbud
                                                EODDataSet.DisktilbudHistorikDataTable.CreateRecord(ItemID, FSD_ID, DisktilbudFraDato, DisktilbudTilDato, DisktilbudThreshold, KampagneID, db.CurrentTransaction);
                                            }
                                        }

                                        #endregion
                                    }

                                    // flag that FVD updater has run
                                    _XVDUpdaterHasRun = true;

                                } // if !SkipRecord
                            } // if supported BEGIVENHEDSKODE

                            // show progress
                            ProgressBar.PerformStep();
                        }
                        parser.Close();

                        // update header records with counters
                        db.ExecuteNonQuery(string.Format(
                            " update ItemUpdates set " +
                            " NoOfLines = {0}, " +
                            " NoOfOpen = {1} " +
                            " where ID = {2} ",
                            NoOfLines, NoOfOpen, ID));

                        // import done, delete the file
                        tools.RemoveFileWriteProtection(file);
                        if (db.GetConfigStringAsBool("BackupFVDFilesActive"))
                        {
                            // backing up the file is activated
                            string backupdir = db.GetConfigString("Backup_LocalDir").Replace("/","\\");
                            if (!backupdir.EndsWith("\\"))
                                backupdir += "\\";
                            string destpath = backupdir + tools.StripDirectoryFromPath(file);
                            File.Copy(file, destpath);
                        }
                        File.Delete(file);

                        // if FSD_IDs were prevented, write a drs item log entry
                        if (ItemsWithFSD_IDsAlreadyOnAnotherItem.Count > 0)
                            ItemDataSet.ItemDataTable.UpdateFVD_WriteDRSItemLog_PreventedDuplicateFSD_ID(ItemsWithFSD_IDsAlreadyOnAnotherItem, file);
                    }
                }

                // remove checkmark so user can see update is done
                chkLL.Checked = false;
                chkLL.Refresh();

                // commit db transaction
                db.CommitTransaction();

                // if FSD_IDs were prevented in any of the imported files, notify user
                if (FSD_IDsWerePreventedBecauseAlreadyOnAnotherItem)
                    MessageBox.Show(db.GetLangString("ImportFVD.ErrorFSD_IDAlreadyOnAnotherItem"));

                // report success
                return true;
            }
            catch (Exception ex)
            {
                // rollback db transaction
                db.RollbackTransaction();

                // error importing LL files
                MessageBox.Show(
                    log.WriteException("Error loading FVD file: " + exCatchFile,
                    ex.Message, ex.StackTrace));
                return false;
            }
        }
        #endregion

        #region UpdateLLSubcatRel
        /// <summary>
        /// Updates data from LLSubcatRel.csv file.
        /// </summary>
        /// <returns></returns>
        private bool UpdateLLSubcatRel()
        {
            // start db transaction
            db.StartTransaction();

            try
            {
                // check if file exists
                if (File.Exists(fileLLSubcatRel))
                {
                    // setup progress bar
                    SetupProgressBar(db.GetLangString("ManualUpdatesForm.Progress.LLSubcatRel"), fileLLSubcatRel);

                    // create csv parser
                    GenericParser parser = tools.CreateCSVParser(fileLLSubcatRel, ';', true);

                    // empty table
                    db.ExecuteNonQuery(" delete from LLSubcatRel ");

                    // parse file and insert data in database
                    while(parser.Read())
                    {
                        int LLCat = tools.object2int(parser["LL Cat"]);
                        string SubCategory = parser["SubCategory"];

                        db.ExecuteNonQuery(string.Format(
                            " insert into LLSubcatRel " +
                            " (LLCat,SubCategory) " +
                            " values ({0},{1}) ",
                            LLCat, tools.string4sql(SubCategory,20)));

                        ProgressBar.PerformStep();
                    }

                    // import done, delete the file
                    tools.RemoveFileWriteProtection(fileLLSubcatRel);
                    File.Delete(fileLLSubcatRel);

                    // remove checkmark so user can see update is done
                    chkLLSubcatRel.Checked = false;
                    chkLLSubcatRel.Refresh();
                }

                // commit db transaction
                db.CommitTransaction();

                // report succes
                return true;
            }
            catch (Exception ex)
            {
                // rollback db transaction
                db.RollbackTransaction();

                // error import LLSubcatRel.csv
                MessageBox.Show(log.WriteException("Error loading LLSubcatRel.csv:", ex.Message, ex.StackTrace));
                return false;
            }

        }
        #endregion

        #region UpdatePrlEmployee
        private bool UpdatePrlEmployee()
        {
            db.StartTransaction();

            try
            {
                // check if file exists
                if (File.Exists(filePrlEmployee))
                {
                    // setup progress bar
                    SetupProgressBar(db.GetLangString("ManualUpdatesForm.PayrollEmployeeData"), filePrlEmployee);

                    // set all existing employees in db to inactive except lent employee
                    // and where inactivedate has not been filled in (if we set it again and again,
                    // the employee keeps getting inactivated as though it just happened)
                    db.ExecuteNonQuery(string.Format("update PrlEmployee set InactiveDate = GETDATE() where EmployeeNo <> {0} and InactiveDate is null ",
                        Payroll.PrlEmployeeDataTable.LentEmployeeNo));

                    // parse file and insert data in database
                    StreamReader reader = new StreamReader(filePrlEmployee, System.Text.Encoding.GetEncoding(850));
                    while (!reader.EndOfStream)
                    {
                        // get all data for one employee
                        string line = reader.ReadLine();

                        // first read out the site code, and verify that this
                        // employee data belongs to the current station
                        string SiteCode = line.Substring(0, 10).Trim();
                        if (SiteCode == AdminDataSet.SiteInformationDataTable.GetSiteCode())
                        {
                            // read out all values
                            int EmployeeNo = tools.object2int(line.Substring(10, 20).Trim());
                            if (EmployeeNo != Payroll.PrlEmployeeDataTable.LentEmployeeNo)
                            {
                                string FirstName = line.Substring(30, 30).Trim();
                                string LastName = line.Substring(60, 30).Trim();
                                string Address1 = line.Substring(90, 30).Trim();
                                string Address2 = line.Substring(120, 30).Trim();
                                string City = line.Substring(150, 30).Trim();
                                string ZipCode = line.Substring(180, 20).Trim();
                                string Phone = line.Substring(200, 10).Trim();
                                string CPR = line.Substring(210, 20).Trim();
                                string Post = line.Substring(230, 30).Trim();
                                bool Education = (line.Substring(270, 10).Trim().ToLower() == "ja");
                                DateTime StartDate = tools.string2datetime_short(line.Substring(281, 11).Trim());  //20200311
                                DateTime EndDate = tools.string2datetime_short(line.Substring(292, 13).Trim());
                                string EmployeeType = line.Substring(305, 20).Trim();
                                double FuncHours = tools.object2double(line.Substring(325, 10).Trim());

                                // if EmployeeType is "Funktionær", set flag IsFunc to true
                                bool IsFunc = (EmployeeType == "Funktionær");

                                // most employees will not have an enddate,
                                // so instead of inserting default DateTime.MinValue
                                // we want to insert NULL in the database.
                                string sEndDate = tools.datetime4sql(EndDate);
                                if (EndDate == DateTime.MinValue)
                                    sEndDate = "NULL";

                                // get if employee already exists
                                bool ExistsAlready = tools.object2int(db.ExecuteScalar(string.Format(@"
                                    select count(*) from PrlEmployee
                                    where EmployeeNo = {0}
                                    ", EmployeeNo))) > 0;

                                if (ExistsAlready)
                                {
                                    // update existing employee (and activate)
                                    db.ExecuteNonQuery(string.Format(@"
                                        update PrlEmployee set
                                        FirstName={1},LastName={2},Address1={3},Address2={4},City={5},ZipCode={6},
                                        Phone={7},CPR={8},Post={9},Education={10},StartDate={11},EndDate={12},
                                        EmployeeType={13},FuncHours={14},IsFunc={15},InactiveDate=NULL
                                        where EmployeeNo = {0}
                                        ",
                                        EmployeeNo,
                                        tools.string4sql(FirstName, 50),
                                        tools.string4sql(LastName, 50),
                                        tools.string4sql(Address1, 100),
                                        tools.string4sql(Address2, 100),
                                        tools.string4sql(City, 50),
                                        tools.string4sql(ZipCode, 10),
                                        tools.string4sql(Phone, 20),
                                        tools.string4sql(CPR, 20),
                                        tools.string4sql(Post, 50),
                                        tools.bool4sql(Education),
                                        tools.datetime4sql(StartDate),
                                        sEndDate,
                                        tools.string4sql(EmployeeType, 50),
                                        tools.decimalnumber4sql(FuncHours),
                                        tools.bool4sql(IsFunc)));
                                }
                                else
                                {
                                    // create new employee record
                                    db.ExecuteNonQuery(string.Format(
                                        " insert into PrlEmployee " +
                                        " (EmployeeNo,FirstName,LastName,Address1,Address2,City,ZipCode, " +
                                        "  Phone,CPR,Post,Education,StartDate,EndDate,EmployeeType,FuncHours,IsFunc) " +
                                        " values ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}) ",
                                        EmployeeNo,
                                        tools.string4sql(FirstName, 50),
                                        tools.string4sql(LastName, 50),
                                        tools.string4sql(Address1, 100),
                                        tools.string4sql(Address2, 100),
                                        tools.string4sql(City, 50),
                                        tools.string4sql(ZipCode, 10),
                                        tools.string4sql(Phone, 20),
                                        tools.string4sql(CPR, 20),
                                        tools.string4sql(Post, 50),
                                        tools.bool4sql(Education),
                                        tools.datetime4sql(StartDate),
                                        sEndDate,
                                        tools.string4sql(EmployeeType, 50),
                                        tools.decimalnumber4sql(FuncHours),
                                        tools.bool4sql(IsFunc)));
                                }
                            }
                        }

                        ProgressBar.PerformStep();
                    }
                    reader.Close();

                    /// for emplyees that have been inactivated and that for some reason does not
                    /// have EndDate filled out, we set the enddate to the last day of the previous
                    /// salary period, looking from today.
                    DateTime ActiveSalaryPeriodeStartDate = Payroll.PrlSalaryPeriodsDataTable.GetActiveSalaryPeriodStartDate();
                    if (ActiveSalaryPeriodeStartDate != DateTime.MinValue)
                    {
                        DateTime LastDayInPrevSalaryPeriod = ActiveSalaryPeriodeStartDate.AddDays(-1).Date;
                       
                        db.ExecuteNonQuery(string.Format(@"
                            update PrlEmployee set EndDate = '{1}'  where EmployeeNo <> {0} and EndDate is null and InactiveDate is not null
                            ", Payroll.PrlEmployeeDataTable.LentEmployeeNo, LastDayInPrevSalaryPeriod));  //pn20200311
                    }
                    else
                    {
                        /// there was no active salary period or there was no
                        /// salary periode before the curret salary period, so
                        /// instead we set EndDate to InactiveDate on the relevant rows
                        db.ExecuteNonQuery(string.Format(@"
                            update PrlEmployee set EndDate = InactiveDate
                            where EmployeeNo <> {0} and EndDate is null and InactiveDate is not null
                            ", Payroll.PrlEmployeeDataTable.LentEmployeeNo));
                    }

                    // import done, delete the file
                    tools.RemoveFileWriteProtection(filePrlEmployee);
                    File.Delete(filePrlEmployee);

                    // remove checkmark so user can see update is done
                    chkPrlEmployee.Checked = false;
                    chkPrlEmployee.Refresh();
                }

                // update succceded
                db.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                MessageBox.Show(
                    log.WriteException(
                    "Error loading payroll employee data",
                    ex.Message,
                    ex.StackTrace));
                return false;
            }
        }
        #endregion

        #region UpdatePrlAbsense
        private bool UpdatePrlAbsense()
        {
            db.StartTransaction();

            try
            {
                // check if file exists
                if (File.Exists(filePrlAbsense))
                {
                    // setup progress bar
                    SetupProgressBar(db.GetLangString("ManualUpdatesForm.PayrollAbsenseData"), filePrlAbsense);

                    // empty absense table
                    db.ExecuteNonQuery(" delete from PrlLookupAbsenseCodes ");

                    // parse file and insert data in database
                    GenericParser parser = tools.CreateCSVParser(filePrlAbsense, ';', true);
                    while (parser.Read())
                    {
                        // retrieve values from row in file
                        int AbsenseCode = tools.object2int(parser["Kode"]);
                        string Description = tools.object2string(parser["Beskrivelse"]);
                        bool OnlyFunc = tools.object2bool(parser["Kun Funktionærer"]);

                        // insert into table
                        db.ExecuteNonQuery(string.Format(
                            " insert into PrlLookupAbsenseCodes " +
                            " (AbsenseCode,Description,OnlyFunc) " +
                            " values ({0},{1},{2}) ",
                            AbsenseCode,
                            tools.string4sql(Description,50),
                            OnlyFunc));

                        ProgressBar.PerformStep();
                    }
                    parser.Close();

                    // import done, delete the file
                    tools.RemoveFileWriteProtection(filePrlAbsense);
                    File.Delete(filePrlAbsense);

                    // remove checkmark so user can see update is done
                    chkPrlAbsense.Checked = false;
                    chkPrlAbsense.Refresh();
                }

                // update succceded
                db.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                MessageBox.Show(
                    log.WriteException(
                    "Error loading payroll absense data",
                    ex.Message,
                    ex.StackTrace));
                return false;
            }
        }
        #endregion

        #region UpdatePrlAgreement
        /// <summary>
        /// Imports data for tables PrlAgreement and PrlAgreementStatic
        /// from file agreement.csv.
        /// </summary>
        private bool UpdatePrlAgreement()
        {
            db.StartTransaction();

            try
            {
                // check if file exists
                if (File.Exists(filePrlAgreement))
                {
                    // setup progress bar
                    SetupProgressBar(db.GetLangString("ManualUpdatesForm.PayrollAgreementData"), filePrlAgreement);

                    // delete all dynamic agreement data
                    db.ExecuteNonQuery(" delete from PrlAgreement ");

                    // parse file and insert data in database
                    GenericParser parser = tools.CreateCSVParser(filePrlAgreement, ';', true);
                    while (parser.Read())
                    {
                        // read out data for agreement record
                        string AgreementCode = tools.object2string(parser["AgreementCode"]);
                        int BonusCode = tools.object2int(parser["BonusCode"]);
                        DateTime FromTime = tools.object2datetime(parser["FromTime"]);
                        DateTime ToTime = tools.object2datetime(parser["ToTime"]);
                        string SiteCode = tools.object2string(parser["SiteCode"]);

                        // subtract 1 second from ToTime so for instance
                        // 00:00 gets to 23:59 and a given time can then
                        // be considered less than 00:00.
                        // (00:00 is considered the starting time of the day)
                        ToTime = ToTime.Subtract(new TimeSpan(0, 0, 1));

                        // create agreement record
                        db.ExecuteNonQuery(string.Format(
                            " insert into PrlAgreement " +
                            " (AgreementCode,BonusCode,FromTime,ToTime) " +
                            " values ({0},{1},{2},{3}) ",
                            tools.string4sql(AgreementCode,4),
                            BonusCode,
                            "'" + FromTime.TimeOfDay + "'",
                            "'" + ToTime.TimeOfDay + "'"));

                        // Detect if we are changing agreement for the station.
                        // If SiteCode in file matches the station's SiteCode,
                        // this record's AgreementCode applies to this station.
                        if (SiteCode == AdminDataSet.SiteInformationDataTable.GetSiteCode())
                        {
                            db.SetConfigString("AgreementCode", AgreementCode);
                        }
                        
                        ProgressBar.PerformStep();
                    }
                    parser.Close();

                    // import done, delete the file
                    tools.RemoveFileWriteProtection(filePrlAgreement);
                    File.Delete(filePrlAgreement);

                    // remove checkmark so user can see update is done
                    chkPrlAgreement.Checked = false;
                    chkPrlAgreement.Refresh();
                }

                // update succceded
                db.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                MessageBox.Show(
                    log.WriteException(
                    "Error loading payroll agreement data",
                    ex.Message,
                    ex.StackTrace));
                return false;
            }
        }
        #endregion

        #region UpdatePrlHolidays
        /// <summary>
        /// Imports data for table PrlHolidays
        /// from file HolliDay.txt
        /// </summary>
        private bool UpdatePrlHolidays()
        {
            db.StartTransaction();

            try
            {
                // check if file exists
                if (File.Exists(filePrlHolidays))
                {
                    // setup progress bar
                    SetupProgressBar(db.GetLangString("ManualUpdatesForm.PayrollHolidaysData"), filePrlHolidays);

                    // delete all holidays data
                    db.ExecuteNonQuery(" delete from PrlHolidays ");

                    // parse file and insert data in database
                    GenericParser parser = tools.CreateCSVParser(filePrlHolidays, ';', true);
                    while (parser.Read())
                    {
                        // read out data for holiday record
                        DateTime HolidayDate = tools.object2datetime(parser["Date"]);
                        DateTime FromTime = tools.object2datetime(parser["FromTime"]);
                        DateTime ToTime = tools.object2datetime(parser["ToTime"]);

                        // subtract 1 second from ToTime so for instance
                        // 00:00 gets to 23:59 and a given time can then
                        // be considered less than 00:00.
                        // (00:00 is considered the starting time of the day)
                        ToTime = ToTime.Subtract(new TimeSpan(0, 0, 1));

                        // create holiday record
                        db.ExecuteNonQuery(string.Format(
                            " insert into PrlHolidays " +
                            " (HolidayDate,FromTime,ToTime) " +
                            " values ({0},{1},{2}) ",
                            "'" + HolidayDate + "'",
                            "'" + FromTime.TimeOfDay + "'",
                            "'" + ToTime.TimeOfDay + "'"));

                        ProgressBar.PerformStep();
                    }
                    parser.Close();

                    // import done, delete the file
                    tools.RemoveFileWriteProtection(filePrlHolidays);
                    File.Delete(filePrlHolidays);

                    // remove checkmark so user can see update is done
                    chkPrlHolidays.Checked = false;
                    chkPrlHolidays.Refresh();
                }

                // update succceded
                db.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                MessageBox.Show(
                    log.WriteException(
                    "Error loading payroll holiday data",
                    ex.Message,
                    ex.StackTrace));
                return false;
            }
        }
        #endregion

        #region UpdatePrlSalaryPeriods
        /// <summary>
        /// Imports data for table PrlSalaryPeriods
        /// from file payper.txt.
        /// </summary>
        private bool UpdatePrlSalaryPeriods()
        {
            db.StartTransaction();

            try
            {
                // check if file exists
                if (File.Exists(filePrlSalaryPeriods))
                {
                    // setup progress bar
                    SetupProgressBar(db.GetLangString("ManualUpdatesForm.PayrollSalaryPeriodsData"), filePrlSalaryPeriods);

                    // parse file and insert data in database
                    GenericParser parser = tools.CreateCSVParser(filePrlSalaryPeriods, ';', true);
                    while (parser.Read())
                    {
                        // read out data for one period
                        int PeriodYear = tools.object2int(parser["Year"]);
                        int Period = tools.object2int(parser["Period"]);
                        DateTime StartDate = tools.object2datetime(parser["FromDate"]);
                        DateTime EndDate = tools.object2datetime(parser["ToDate"]);

                        // delete any record existing for this period
                        db.ExecuteNonQuery(string.Format(
                            " delete from PrlSalaryPeriods " +
                            " where (PeriodYear = {0}) " +
                            " and (Period = {1}) ",
                            PeriodYear, Period));

                        // create salary period record
                        db.ExecuteNonQuery(string.Format(
                            " insert into PrlSalaryPeriods " +
                            " (PeriodYear,Period,StartDate,EndDate) " +
                            " values ({0},{1},{2},{3}) ",
                            PeriodYear,
                            Period,
                            "'" + StartDate + "'",
                            "'" + EndDate + "'"));

                        ProgressBar.PerformStep();
                    }
                    parser.Close();

                    // import done, delete the file
                    tools.RemoveFileWriteProtection(filePrlSalaryPeriods);
                    File.Delete(filePrlSalaryPeriods);

                    // remove checkmark so user can see update is done
                    chkPrlSalaryPeriods.Checked = false;
                    chkPrlSalaryPeriods.Refresh();
                }

                // update succceded
                db.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                MessageBox.Show(
                    log.WriteException(
                    "Error loading payroll salary periods data",
                    ex.Message,
                    ex.StackTrace));
                return false;
            }
        }
        #endregion

        #region UpdatePrlClusterSites
        /// <summary>
        /// Imports data for table PrlClusterSites
        /// from file ClusterSites.csv.
        /// </summary>
        private bool UpdatePrlClusterSites()
        {
            db.StartTransaction();

            try
            {
                // check if file exists
                if (File.Exists(filePrlClusterSites))
                {
                    // setup progress bar
                    SetupProgressBar(db.GetLangString("ManualUpdatesForm.PayrollClusterSitesData"), filePrlClusterSites);

                    // create temporary table to import data into and work with
                    DataTable table = new DataTable();
                    table.Columns.Add("Station", typeof(string));
                    table.Columns.Add("StationsNavn", typeof(string));
                    table.Columns.Add("Selskab", typeof(string));

                    // parse file and insert data in temporary table
                    GenericParser parser = tools.CreateCSVParser(filePrlClusterSites, ';', true);
                    while (parser.Read())
                    {
                        // read out values into table row
                        DataRow row = table.NewRow();
                        row["Station"] = tools.object2string(parser["Station"]);
                        row["StationsNavn"] = tools.object2string(parser["StationsNavn"]);
                        row["Selskab"] = tools.object2string(parser["Selskab"]);
                        table.Rows.Add(row);

                        ProgressBar.PerformStep();
                    }
                    parser.Close();

                    // now we have imported the entire ClusterSites files into
                    // a temporary table. we now want to extract the stations
                    // that belong to the same selskab as this station

                    // find this station's row
                    string SiteCode = AdminDataSet.SiteInformationDataTable.GetSiteCode();
                    DataRow[] rows = table.Select("Station = '" + SiteCode + "'");
                    if (rows.Length > 0)
                    {
                        // get this station's Selskab value
                        string Selskab = tools.object2string(rows[0]["Selskab"]);
                        
                        // get all the stations within this Selskab except this station
                        DataRow[] rowsInCluster = table.Select(string.Format(
                            " (Selskab = '{0}') and (Station <> '{1}') ",
                            Selskab, SiteCode));
                        if (rowsInCluster.Length > 0)
                        {
                            // empty table PrlClusterSites
                            db.ExecuteNonQuery(" delete from PrlClusterSites ");

                            // import stations into PrlClusterSites
                            foreach (DataRow row in rowsInCluster)
                            {
                                db.ExecuteNonQuery(string.Format(
                                    " insert into PrlClusterSites " +
                                    " (SiteCode,SiteName) " +
                                    " values ('{0}','{1}') ",
                                    row["Station"], row["StationsNavn"]));
                            }
                        }
                    }

                    // import done, delete the file
                    tools.RemoveFileWriteProtection(filePrlClusterSites);
                    File.Delete(filePrlClusterSites);

                    // remove checkmark so user can see update is done
                    chkPrlClusterSites.Checked = false;
                    chkPrlClusterSites.Refresh();
                }

                // update succceded
                db.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                MessageBox.Show(
                    log.WriteException(
                    "Error loading payroll clustersites data",
                    ex.Message,
                    ex.StackTrace));
                return false;
            }
        }
        #endregion

        #region UpdateRRDebitorData
        public bool UpdateRRDebitorData()
        {
            int test = 0;

            db.StartTransaction();

            try
            {
                // check if file exists
                if (File.Exists(fileRRDebitorData))
                {
                    // setup progress bar
                    SetupProgressBar(db.GetLangString("ManualUpdatesForm.RRDebtors"), fileRRDebitorData);

                    // parse file
                    GenericParser parser = tools.CreateCSVParser(fileRRDebitorData, ';', false);
                    parser.ColumnDelimiter = "||".ToCharArray();
                    while (parser.Read())
                    {
                        ++test;
                        // file has no header, so columns are indexed
                        string Nummer = tools.TruncString(tools.object2string(parser[0]), 20);
                        string Navn1 = tools.TruncString(tools.object2string(parser[1]), 255);
                        string Navn2 = tools.TruncString(tools.object2string(parser[2]), 255);
                        string Adresse1 = tools.TruncString(tools.object2string(parser[3]), 255);
                        string Adresse2 = tools.TruncString(tools.object2string(parser[4]), 255);
                        string Postnr = tools.TruncString(tools.object2string(parser[5]), 10);
                        string By = tools.TruncString(tools.object2string(parser[6]), 255);
                        string Attention = tools.TruncString(tools.object2string(parser[7]), 255);
                        string Telefon = tools.TruncString(tools.object2string(parser[8]), 20);
                        //string Mobil = tools.object2string(parser[9]);
                        //string Faxnr = tools.object2string(parser[10]);
                        //string Spaerret = tools.object2string(parser[11]);
                        //string SE = tools.object2string(parser[12]);
                        string Email = tools.object2string(parser[13]);
                        string Website = tools.object2string(parser[14]);
                        //string VPrgID = tools.object2string(parser[15]);

                        /// figure out if this debtor already exists in rbos.
                        /// this is done by checking if Nummer exists in either
                        /// DebtorNo or in RRNumber
                        int DebtorNo = EODDataSet.EOD_DebtorDataTable.GetDebtor(Nummer);
                        if (DebtorNo != 0)
                        {
                            // debtor already exists, update record
                            EODDataSet.EOD_DebtorDataTable.UpdateRecord(
                                DebtorNo, Navn1, Navn2, Adresse1, Adresse2, Postnr, By, Telefon, Attention, Nummer, true);
                        }
                        else
                        {
                            // debtor is new to RBOS, create new record

                            // attempt to cast Nummer to an integer
                            DebtorNo = tools.object2int(Nummer);
                            if (DebtorNo == 0)
                            {
                                // couldn't cast to integer, so find a new unique number automatically
                                DebtorNo = EODDataSet.EOD_DebtorDataTable.GetNextUniqueDebtorNo();
                            }

                            // create new record
                            EODDataSet.EOD_DebtorDataTable.CreateNewRecord(
                                DebtorNo, Navn1, Navn2, Adresse1, Adresse2, Postnr, By, Telefon, Attention, Nummer);
                        }

                        ProgressBar.PerformStep();
                    }
                    parser.Close();

                    // import done, delete the file
                    tools.RemoveFileWriteProtection(fileRRDebitorData);
                    File.Delete(fileRRDebitorData);

                    // remove checkmark so user can see update is done
                    chkRRDebitorData.Checked = false;
                    chkRRDebitorData.Refresh();
                }

                // update succceded
                db.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                MessageBox.Show(
                    log.WriteException(
                    "Error loading RRDebitorData",
                    ex.Message,
                    ex.StackTrace));
                return false;
            }
        }
        #endregion

        #region UpdateSubCatSetup
        private bool UpdateSubCatSetup()
        {
            db.StartTransaction();

            try
            {
                // check if file exists
                if (File.Exists(fileSubCatSetup))
                {
                    // setup progress bar
                    SetupProgressBar(db.GetLangString("ManualUpdatesForm.SubCatSetup"), fileSubCatSetup);

                    // parse file
                    GenericParser parser = tools.CreateCSVParser(fileSubCatSetup, ';', false);
                    while (parser.Read())
                    {
                        // read out action
                        string action = parser[0];

                        switch (action)
                        {
                            case "10": // update subcategory
                                ItemDataSet.SubCategoryDataTable.UpdateSubCategory(
                                    parser[1],
                                    parser[2],
                                    tools.object2int(parser[3]),
                                    tools.object2double(parser[4]),
                                    parser[5],
                                    parser[6],
                                    tools.object2int(parser[7]),
                                    tools.object2int(parser[8]),
                                    parser[9],
                                    tools.object2double(parser[10]),
                                    tools.object2int(parser[11]),
                                    tools.object2bool(parser[12]),
                                    tools.object2bool(parser[13]),
                                    parser[14],
                                    tools.object2bool(parser[15]));
                                break;
                            case "20": // create subcategory
                                ItemDataSet.SubCategoryDataTable.CreateSubCategory(
                                    parser[1],
                                    parser[2],
                                    tools.object2int(parser[3]),
                                    tools.object2double(parser[4]),
                                    parser[5],
                                    parser[6],
                                    tools.object2int(parser[7]),
                                    tools.object2int(parser[8]),
                                    parser[9],
                                    tools.object2double(parser[10]),
                                    tools.object2int(parser[11]),
                                    tools.object2bool(parser[12]),
                                    tools.object2bool(parser[13]),
                                    parser[14],
                                    tools.object2bool(parser[15]));
                                break;
                            case "30": // move items to another subcategory
                                ItemDataSet.SubCategoryDataTable.MoveItems(
                                    parser[1], parser[2]);
                                break;
                        }

                        ProgressBar.PerformStep();
                    }
                    parser.Close();

                    // import done, delete the file
                    tools.RemoveFileWriteProtection(fileSubCatSetup);
                    File.Delete(fileSubCatSetup);

                    // remove checkmark so user can see update is done
                    chkSubCatSetup.Checked = false;
                    chkSubCatSetup.Refresh();
                }

                // update succceded
                db.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                MessageBox.Show(
                    log.WriteException(
                    "Error loading SubCatSetup",
                    ex.Message,
                    ex.StackTrace));
                return false;
            }
        }
        #endregion

        #region UpdateEPD (only RBA)
#if RBA
        private bool UpdateEPD()
        {
            foreach (string file in filesEPD)
            {
                try
                {
                    // check if file exists
                    if (File.Exists(file))
                    {
                        // setup progress bar
                        SetupProgressBar(db.GetLangString("ManualUpdatesForm.UpdateEPD.Progress"), file);

                        // get bookdate and sitecode from filename
                        string fileStrippedOfPath = tools.StripDirectoryFromPath(file);
                        DateTime BookDate = tools.object2datetime(fileStrippedOfPath.Substring(4, 8));
                        string SiteCode = fileStrippedOfPath.Substring(0, 4);

                        // double check that this file belongs to this station
                        if (AdminDataSet.SiteInformationDataTable.GetSiteCode() == SiteCode)
                        {
                            db.StartTransaction();

                            // erase any sales records already existing on that date and zero customercount
                            EODDataSet.EOD_SalesDataTable.DeleteRecords(BookDate);
                            EODDataSet.EODReconcileExDataTable.InsertOrUpdateRecord(BookDate, 0);

                            // parse file
                            GenericParser parser = tools.CreateCSVParser(file, ';', false);
                            while (parser.Read())
                            {
                                // read out record type
                                string RecType = parser[0];

                                switch (RecType)
                                {
                                    case "1000": // header

                                        // read out sitecode and bookdate,
                                        // we use them to check that they
                                        // fit with the filename
                                        string headerSiteCode = parser[1];
                                        DateTime headerBookDate = tools.object2datetime(parser[2]).Date;

                                        // if header information does not fit with filename information,
                                        // throw an exception as something is really wrong and this file's data
                                        // may not be comitted to the database
                                        if ((headerSiteCode != SiteCode) ||
                                            (headerBookDate.Date != BookDate.Date))
                                        {
                                            throw new Exception("Header information stemmer ikke overens med filinformation i filen " + file);
                                        }

                                        break;
                                    case "1010": // records
                                        if (AdminDataSet.SiteInformationDataTable.GetSiteCode() == SiteCode)
                                        {
                                            // read out values
                                            string GLFinance = parser[1];
                                            double NumberOf = tools.object2double(parser[2]);
                                            double Amount = tools.object2double(parser[3]);

                                            // create EOD_Sales record
                                            EODDataSet.EOD_SalesDataTable.CreateRecord(
                                                BookDate,
                                                TransTypeSales.POSSales,
                                                GLFinance,
                                                NumberOf,
                                                Amount);
                                        }
                                        break;
                                    case "1020": // footer
                                        if (AdminDataSet.SiteInformationDataTable.GetSiteCode() == SiteCode)
                                        {
                                            // read out customer count
                                            int CustomerCount = tools.object2int(parser[1]);

                                            // insert or update eodreconcileex record
                                            EODDataSet.EODReconcileExDataTable.InsertOrUpdateRecord(
                                                BookDate, CustomerCount);
                                        }
                                        break;
                                }

                                ProgressBar.PerformStep();
                            } // end loopling each line in the file
                            parser.Close();

                            // import done, commit transaction and delete the file
                            db.CommitTransaction();
                            tools.RemoveFileWriteProtection(file);
                            File.Delete(file);

                        } // end checking if the file belongs to this station
                    } // end checking if file exist
                }
                catch (Exception ex)
                {
                    db.RollbackTransaction();
                    MessageBox.Show(
                        log.WriteException(
                        "Error loading EPD",
                        ex.Message,
                        ex.StackTrace));
                    return false;
                }

            } // end looping the epd files found

            // remove checkmark so user can see update is done
            chkEPD.Checked = false;
            chkEPD.Refresh();

            return true;
        }
#endif
        #endregion

        #region UpdateDS

        private bool UpdateDS()
        {
            foreach (string file in filesDS)
            {
                try
                {
                    // check if file exists
                    if (File.Exists(file))
                    {
                        // setup progress bar
                        SetupProgressBar(db.GetLangString("ManualUpdatesForm.UpdateEPD.Progress"), file);

                        // get bookdate and sitecode from filename
                        string fileStrippedOfPath = tools.StripDirectoryFromPath(file);
                        DateTime BookDate = tools.object2datetime(fileStrippedOfPath.Substring(4, 8));
                        string SiteCode = fileStrippedOfPath.Substring(0, 4);

                        // double check that this file belongs to this station
                        if (AdminDataSet.SiteInformationDataTable.GetSiteCode() == SiteCode)
                        {
                            db.StartTransaction();

                            // erase Danske spil record
                            DanskeSpilDataSet.Danske_SpilDataTable.Delete(BookDate);
                            

                            // parse file
                            GenericParser parser = tools.CreateCSVParser(file, ';', false);
                            while (parser.Read())
                            {
                                // read out record type
                                string RecType = parser[0];

                                switch (RecType)
                                {
                            
                                    case "1010": // records
                                        if (AdminDataSet.SiteInformationDataTable.GetSiteCode() == SiteCode)
                                        {
                                            // read out values
                                            double OnlineSalgTerminal = tools.object2double(parser[1]);
                                            double OnlineGevinstTerminal = tools.object2double(parser[2]);
                                            double QuickClearetTerminal = tools.object2double(parser[3]);

                                            // create Danske_Spil record
                                            DanskeSpilDataSet.Danske_SpilDataTable.CreateNewRecord(
                                                BookDate,                                                
                                                OnlineSalgTerminal,
                                                OnlineGevinstTerminal,
                                                QuickClearetTerminal);
                                        }
                                        break;
                           
                               // ProgressBar.PerformStep();
                                }
                            } // end loopling each line in the file
                            parser.Close();

                            //// import done, commit transaction and delete the file
                            db.CommitTransaction();
                            tools.RemoveFileWriteProtection(file);
                            File.Delete(file);

                        } // end checking if the file belongs to this station
                    } // end checking if file exist
                }
                catch (Exception ex)
                {
                    db.RollbackTransaction();
                    MessageBox.Show(
                        log.WriteException(
                        "Error loading DS",
                        ex.Message,
                        ex.StackTrace));
                    return false;
                }

            } // end looping the epd files found

            // remove checkmark so user can see update is done
            chkEPD.Checked = false;
            chkEPD.Refresh();

            return true;
            
        }

        #endregion

        #region GetXVDFileDateTime
        /// <summary>
        /// Scans out the DateTime from LVD/FVD file.
        /// If an error occurs DateTime.MinValue is returned (wrongly named file)
        /// </summary>
        /// <param name="pattern">
        /// Use the const values LVD or FVD.
        /// </param>
        enum XVD_filepattern
        {
            LVD,
            FVD
        }
        private DateTime GetXVDFileDateTime(string filename, XVD_filepattern pattern)
        {
            try
            {
                string sDatetime = tools.StripDirectoryFromPath(filename);

                string p = "";
                if (pattern == XVD_filepattern.LVD)
                    p = @"^(LL[0-9]{12}\.LVD)$";
                else if (pattern == XVD_filepattern.FVD)
                    p = @"^(FSD[0-9]{12}\.FVD)$";
                else
                    return DateTime.MinValue;

                // verify correct file format LLyyyyMMddhhmm.LVD (uppercase characters)
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(p);
                if (!regex.IsMatch(sDatetime.ToUpper()))
                    return DateTime.MinValue;

                int offset = 0;
                if (pattern == XVD_filepattern.LVD)
                    offset = 2;
                else if (pattern == XVD_filepattern.FVD)
                    offset = 3;

                // scan out datetime
                string year = sDatetime.Substring(offset, 4);
                string month = sDatetime.Substring(offset + 4, 2);
                string day = sDatetime.Substring(offset + 6, 2);
                string hour = sDatetime.Substring(offset + 8, 2);
                string minute = sDatetime.Substring(offset + 10, 2);
                DateTime datetime = new DateTime(
                    tools.object2int(year),
                    tools.object2int(month),
                    tools.object2int(day),
                    tools.object2int(hour),
                    tools.object2int(minute), 0);
                return datetime;
            }
            catch
            {
                // wrongly named file
                return DateTime.MinValue;
            }
        }
        #endregion

        #region SetupProgressBar
        private void SetupProgressBar(string statustext, string filename)
        {
            ProgressBar.Maximum = File.ReadAllLines(filename).Length;
            SetupProgressBar(statustext, ProgressBar.Maximum);
        }
        public void SetupProgressBar(string statustext, int maximum)
        {
            ProgressBar.Visible = true;
            ProgressBar.Maximum = maximum;
            ProgressBar.Value = 0;
            StatusText.Visible = true;
            StatusText.Text = statustext;
            statusStrip1.Refresh();
        }
        #endregion

        #region CorrectedMSMString
        /// <summary>
        /// Takes a string and makes sure it is not longer than MaxLength.
        /// If the string is empty, NULL is written to the string.
        /// if the string is not empty, the string is embraced in "".
        /// </summary>
        private static string CorrectedMSMString(string Value, int MaxLength)
        {
            // check for null string
            if (Value == null)
            {
                Value = "NULL";
                return Value;
            }

            // check for max length
            if (Value.Length > MaxLength)
                Value = Value.Remove(MaxLength);

            // check for empty string
            if (Value == "")
            {
                Value = "NULL";
                return Value;
            }

            // embrace non-null value in ""
            if (Value != "NULL")
                Value = "\"" + Value + "\"";

            return Value;
        }
        #endregion

        #region PerformUpdate
        private bool PerformUpdate()
        {
            // update MSM config data
            if (chkMSM.Checked)
            {
                if (!UpdateMSM())
                    return false;
            }

            // update GLSubcatRel data
            if (chkGLSubcatRel.Checked)
            {
                if (!UpdateGLSubcatRel())
                    return false;
            }

            // update GLBudget data
            if (chkBudget.Checked)
            {
                if (!UpdateGLBudget())
                    return false;
            }

            // update LLSubcatRel data
            if (chkLLSubcatRel.Checked)
            {
                if (!UpdateLLSubcatRel())
                    return false;
            }

            // update subcategory setup
            if (chkSubCatSetup.Checked)
            {
                if (!UpdateSubCatSetup())
                    return false;
            }

            // Danske spil
            if (chkDanskeSpil.Checked)
            {
                if (!UpdateDS())
                    return false;
            }

#if FSD
            // update LVD data
            if (chkLL.Checked)
            {
                if (!UpdateLL())
                    return false;
            }
#else
            // update FVD data
            if (chkLL.Checked)
            {
                if (!UpdateFVD())
                    return false;
            }
#endif

            // update RR debitor data
            if (chkRRDebitorData.Checked)
            {
                if (!UpdateRRDebitorData())
                    return false;
            }

            /// PAYROLL COLUMN OF CHECKBOXES

            // update payroll employee data
            if (chkPrlEmployee.Checked)
            {
                if (!UpdatePrlEmployee())
                    return false;
            }

            // update payroll agreement data (overenskomst)
            if (chkPrlAgreement.Checked)
            {
                if (!UpdatePrlAgreement())
                    return false;
            }

            // update payroll holidays data
            if (chkPrlHolidays.Checked)
            {
                if (!UpdatePrlHolidays())
                    return false;
            }

            // update payroll salary periods data (lønperioder)
            if (chkPrlSalaryPeriods.Checked)
            {
                if (!UpdatePrlSalaryPeriods())
                    return false;
            }

            // update payroll clustersites data
            if (chkPrlClusterSites.Checked)
            {
                if (!UpdatePrlClusterSites())
                    return false;
            }

            // update payroll absense data
            if (chkPrlAbsense.Checked)
            {
                if (!UpdatePrlAbsense())
                    return false;
            }

#if RBA
            // update EOD_Sales data (EPD file)
            if (chkEPD.Checked)
            {
                if (!UpdateEPD())
                    return false;
            }

            // update RBA wastage catalog
            if (chkWPF.Checked)
            {
                if (!importWPF.ImportFiles())
                    return false;
            }
#endif

            // all updates successful
            return true;
        }

        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(PerformUpdate())
                Close();
        }
    }
}