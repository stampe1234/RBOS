using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace RBOS
{
    class ImportSalaryHours
    {
        #region LastMsg property
        private string _LastMsg = "";
        /// <summary>
        /// Will contain the last error message produced, if any.
        /// </summary>
        public string LastMsg
        {
            get { return _LastMsg; }
        }
        #endregion

        #region ShowDialog
        /// <summary>
        /// This method gives a user interface for importing salary hours.
        /// It calls the Import method upon succesful criterias. After
        /// succesful import, a report is shown for preview with what was done.
        /// </summary>
        public void ShowDialog()
        {
            // check if user wants to perform the import
            string msg = db.GetLangString("ImportSalaryHours.DoYouWantToImport");
            if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            // check if there is an active salary period before importing
            if (!Payroll.PrlSalaryPeriodsDataTable.DoesAnActiveSalaryPeriodExistThatIsNotApproved())
            {
                MessageBox.Show(db.GetLangString("ImportSalaryHours.NoActiveSalaryPeriodChoose"));
                PrlSalaryPeriods periods = new PrlSalaryPeriods();
                periods.ShowDialog();
                // re-check if user has selected an active salary period
                if (!Payroll.PrlSalaryPeriodsDataTable.DoesAnActiveSalaryPeriodExistThatIsNotApproved())
                {
                    MessageBox.Show(db.GetLangString("ImportSalaryHours.SecondTimeNoActiveSalaryPeriod"));
                    return;
                }
            }
            
            // import and print
            ImportDataSet.ImportSalaryHoursDataTable table;
            if (!Import(Payroll.PrlSalaryPeriodsDataTable.GetActiveSalaryPeriod(), out table, true, true))
            {
                MessageBox.Show(_LastMsg);
                log.Write("Error importing salary hours. Message: " + _LastMsg);
                return;
            }
        }
        #endregion

        #region Import
        /// <summary>
        /// Imports the salary hours file.
        /// At the moment we support Tamigo (.TAM) and EGruppen (.EGR) files.
        /// <param name="ActiveSalaryPeriod">
        /// The active salary period to match against the import file.
        /// The salary data for this salary period is deleted before import for each employee found.
        /// </param>
        /// <param name="Table">Will be filled with imported data for further printing.</param>
        /// </summary>
        public bool Import(
            DataRow ActiveSalaryPeriod,
            out ImportDataSet.ImportSalaryHoursDataTable Table,
            bool ShowReport,
            bool ShowProgress)
        {
            Table = new ImportDataSet.ImportSalaryHoursDataTable();
            ProgressForm progress = new ProgressForm("");
            db.StartTransaction();
            try
            {
                _LastMsg = "";
                if (ActiveSalaryPeriod == null)
                {
                    _LastMsg = db.GetLangString("ImportSalaryHours.NoActiveSalaryPeriod");
                    return false;
                }

                string SiteCode = AdminDataSet.SiteInformationDataTable.GetSiteCode();
                int PeriodYear = tools.object2int(ActiveSalaryPeriod["PeriodYear"]);
                int Period = tools.object2int(ActiveSalaryPeriod["Period"]);
                List<int> EmployeesToDeleteSalaryRegistrationsOn = new List<int>();
                string NameOf3rdParty = "Ukendt";

                // build path to import file
                string path = string.Format(@"{0}\{1}_{2:0000}{3:00}",
                    db.GetConfigString("DRS_FTP_client_arrive_dir") + "\\",
                    SiteCode, PeriodYear, Period).Replace(@"\\", @"\");
                if (File.Exists(path + ".TAM"))
                {
                    path += ".TAM";
                    NameOf3rdParty = "Tamigo";
                }
                else if (File.Exists(path + ".EGR"))
                {
                    path += ".EGR";
                    NameOf3rdParty = "eGruppe";
                }
                else
                {
                    _LastMsg = db.GetLangString("ImportSalaryHours.ImportFileNotFound") +
                        "\n\n" + path + ".TAM/.EGR";
                    return false;
                }

                progress.Title = string.Format(db.GetLangString("ImportSalaryHours.ImportSalaryHoursFrom"), NameOf3rdParty);
                if (ShowProgress)
                    progress.Show();

                // we read the file's lines into an array of strings,
                // as we want to know how many lines exist before starting the
                // import. this is used for displaying progress.
                StreamReader reader = new StreamReader(path, Encoding.GetEncoding("iso-8859-1"));
                List<string> lines = new List<string>();
                while (!reader.EndOfStream)
                    lines.Add(reader.ReadLine());
                reader.Close();

                // loop content
                progress.ProgressMax = lines.Count;
                int Num1010RecordsFound = 0;
                int recordcount = 0;
                foreach (string line in lines)
                {
                    ++recordcount;
                    progress.StatusText = string.Format(db.GetLangString("ImportSalaryHours.ImportingLineNofM"), recordcount, lines.Count);
                    if (line.Length > 4)
                    {
                        string RecordID = line.Substring(0, 4);
                        int ExpectedLineLength;
                        switch (RecordID)
                        {
                            case "1000": // header record

                                /// this is the header record. we use it to perform various checks.

                                ExpectedLineLength = 36;
                                if (line.Length == ExpectedLineLength)
                                {
                                    // read and verify sitecode
                                    string SiteNo = line.Substring(4, 4).Trim();
                                    if (SiteNo != SiteCode)
                                    {
                                        _LastMsg = db.GetLangString("ImportSalaryHours.FileSiteNoMismatch");
                                        return false;
                                    }

                                    // read and verify salary period
                                    DateTime StartDate = tools.object2datetime(line.Substring(8, 8).Trim());
                                    DateTime EndDate = tools.object2datetime(line.Substring(16, 8).Trim());
                                    if ((StartDate != tools.object2datetime(ActiveSalaryPeriod["StartDate"])) ||
                                        (EndDate != tools.object2datetime(ActiveSalaryPeriod["EndDate"])))
                                    {
                                        _LastMsg = db.GetLangString("ImportSalaryHours.FileNotActiveSalaryPeriod");
                                        return false;
                                    }

                                    // read file creation date and time
                                    DateTime FileCreated = tools.object2datetime(line.Substring(24, 8).Trim()).Date;
                                    FileCreated = FileCreated.AddHours(tools.object2int(line.Substring(32, 2).Trim()));
                                    FileCreated = FileCreated.AddMinutes(tools.object2int(line.Substring(34, 2).Trim()));
                                }
                                else
                                {
                                    // not enough characters in header record
                                    _LastMsg = string.Format(
                                        db.GetLangString("ImportSalaryHours.FileHeaderTooFewCharacters"),
                                        ExpectedLineLength);
                                    return false;
                                }

                                // header record has been read and verified ok

                                break;
                            case "1010": // registration record

                                /// this is the hours registration record.

                                ++Num1010RecordsFound;
                                ExpectedLineLength = 30;
                                if (line.Length == ExpectedLineLength)
                                {
                                    // read values
                                    string CPR = tools.object2string(line.Substring(4, 10).Trim());
                                    DateTime RegDate = tools.object2datetime(line.Substring(14, 8).Trim());
                                    TimeSpan StartTime = new TimeSpan(
                                        tools.object2int(line.Substring(22, 2).Trim()),
                                        tools.object2int(line.Substring(24, 2).Trim()), 0);
                                    TimeSpan EndTime = new TimeSpan(
                                        tools.object2int(line.Substring(26, 2).Trim()),
                                        tools.object2int(line.Substring(28, 2).Trim()), 0);

                                    // get name and employeeno if possible
                                    string Name = "";
                                    int EmployeeNo = 0;
                                    DataRow employee = Payroll.PrlEmployeeDataTable.GetActiveEmployee(CPR);
                                    if (employee != null)
                                    {
                                        Name = tools.object2string(employee["FirstName"]) +
                                            " " + tools.object2string(employee["LastName"]);
                                        EmployeeNo = tools.object2int(employee["EmployeeNo"]);
                                    }
                                    else
                                    {
                                        // for print so don't translate
                                        Name = string.Format("Ukendt medarbejder cpr. {0}", CPR);
                                    }

                                    // create record in table
                                    Table.AddImportSalaryHoursRow(
                                        CPR, EmployeeNo, Name, RegDate, StartTime, EndTime, "","");

                                    // mark this employee to have it's salary registrations deleted for the period
                                    if ((EmployeeNo != 0) && (!EmployeesToDeleteSalaryRegistrationsOn.Contains(EmployeeNo)))
                                        EmployeesToDeleteSalaryRegistrationsOn.Add(EmployeeNo);

                                    // mark inactive EmployeeNo's for this CPR that has salary registrations in the given period,
                                    // to have their salary registrations deleted for that period
                                    List<int> tmp = Payroll.PrlEmployeeDataTable.GetInactiveEmployeeNosWithSalaryRegistrations(CPR, ActiveSalaryPeriod);
                                    foreach (int empno in tmp)
                                    {
                                        if ((empno != 0) && (!EmployeesToDeleteSalaryRegistrationsOn.Contains(empno)))
                                            EmployeesToDeleteSalaryRegistrationsOn.Add(empno);
                                    }                                    
                                }
                                else
                                {
                                    // not enough characters in registration record
                                    _LastMsg = string.Format(
                                        db.GetLangString("ImportSalaryHours.FileRegTooFewCharacters"),
                                        ExpectedLineLength);
                                    return false;
                                }
                                break;
                            case "1030": // footer record

                                /// this is the footer record. it contains an
                                /// integer for checking the number of 1010 records read.

                                ExpectedLineLength = 8;
                                if (line.Length == ExpectedLineLength)
                                {
                                    int NumExpected = tools.object2int(line.Substring(4, 4).Trim());
                                    if (NumExpected != Num1010RecordsFound)
                                    {
                                        _LastMsg = db.GetLangString("ImportSalaryHours.FileRecCountMismatch");
                                        return false;
                                    }
                                }
                                else
                                {
                                    _LastMsg = string.Format(
                                        db.GetLangString("ImportSalaryHours.FileFooterTooFewCharacters"),
                                        ExpectedLineLength);
                                    return false;
                                }
                                break;
                            default:
                                // if we enter here, this means the record id is unknown
                                _LastMsg = string.Format(
                                    db.GetLangString("ImportSalaryHours.UnknownRecordID"),
                                    RecordID);
                                return false;
                        }
                    }
                    else
                    {
                        // line does not contain enough characters for any type of record
                        _LastMsg = db.GetLangString("ImportSalaryHours.TooFewCharacters");
                        return false;
                    }
                }

                progress.ProgressMax = Table.Rows.Count;
                progress.StatusText = db.GetLangString("ImportSalaryHours.UpdatingEmployees");

                // delete salary registrations for the employees to be imported in the active salary period
                // AND for inactive employeenos that might errornously have records for the given salary period
                // if they have been found to have an active employeeno already.
                foreach (int EmployeeNo in EmployeesToDeleteSalaryRegistrationsOn)
                    Payroll.PrlSalaryRegistrationDataTable.DeleteRecords(ActiveSalaryPeriod, EmployeeNo);

                // create objects to access the PrlSalaryRegistration table
                // and to use the already coded OnColumnChanging event handler
                PayrollTableAdapters.PrlSalaryRegistrationTableAdapter adapterSalReg =
                    new RBOS.PayrollTableAdapters.PrlSalaryRegistrationTableAdapter();
                adapterSalReg.Connection = db.Connection;
                adapterSalReg.InsertCommand.Transaction = db.CurrentTransaction;
                Payroll.PrlSalaryRegistrationDataTable tableSalReg = new Payroll.PrlSalaryRegistrationDataTable();
                tableSalReg.Migrating = true;

                // opdatér medarbejdere timereg ud fra indlæste data
                foreach (DataRow row in Table.Rows)
                {
                    progress.StatusText = string.Format(
                        db.GetLangString("ImportSalaryHours.SalRegFor"),
                        row["Navn"],
                        tools.object2datetime(row["RegDate"]).ToString("dd-MM-yyyy"),
                        tools.object2timespan(row["StartTime"]).Hours.ToString("00"),
                        tools.object2timespan(row["StartTime"]).Minutes.ToString("00"),
                        tools.object2timespan(row["EndTime"]).Hours.ToString("00"),
                        tools.object2timespan(row["EndTime"]).Minutes.ToString("00"));

                    DataRow r = tableSalReg.NewRow();
                    int EmployeeNo = tools.object2int(row["MedarbejderNr"]);
                    if (EmployeeNo != 0)
                    {
                        r["EmployeeNo"] = EmployeeNo;
                        r["RegDateAsString"] = tools.object2datetime(row["RegDate"]).ToString("ddMMyyyy");
                        r["FromTimeAsString"] = tools.object2timespan(row["StartTime"]).ToString();
                        r["ToTimeAsString"] = tools.object2timespan(row["EndTime"]).ToString();
                        tableSalReg.Rows.Add(r);

                        // after row has been added to PrlSalaryReg table,
                        // remarks might have been added, such as "Overlap".
                        // we want to show this in the report.
                        if (!tools.IsNullOrDBNull(r["Remarks"]))
                            row["Remarks"] = r["Remarks"];
                    }
                }

                // save data to disk
                adapterSalReg.Update(tableSalReg);
                db.CommitTransaction();

                if (ShowReport)
                {
                    // create and setup report
                    ImportSalaryHoursRpt rpt = new ImportSalaryHoursRpt();
                    tools.SetReportObjectText(rpt, "txtTitle", "Løntimer indlæsning fra " + NameOf3rdParty);
                    tools.SetReportObjectText(rpt, "txtFilename", path);
                    rpt.SetDataSource((DataTable)Table);
                    tools.SetReportSiteInformation(rpt);
                    tools.Print(rpt, true);
                }

                // delete/rename file after import
                tools.RemoveFileWriteProtection(path);
                if (db.GetConfigStringAsBool("ImportSalaryHours.RenameInsteadOfDelete"))
                {
                    string newpath = (path.Contains(".TAM") ? path.Replace(".TAM", ".TA_") : path.Replace(".EGR", ".EG_"));
                    if (File.Exists(path))
                        File.Move(path, newpath);
                }
                else
                {
                    if (File.Exists(path))
                        File.Delete(path);
                }

                // all ok, return succes
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                _LastMsg = log.WriteException("Import af løntimer fil.", ex.Message, ex.StackTrace);
                return false;
            }
            finally
            {
                if (db.CurrentTransaction != null)
                    db.RollbackTransaction();
                progress.Close();
            }
        }
        #endregion
    }
}
