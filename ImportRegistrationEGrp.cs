using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.IO;

namespace RBOS
{
    class ImportRegistrationEGrp
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
        /// This method gives a user interface for importing salary and absense hours from egruppe webservice.        
        /// </summary>
        public void ShowDialog()
        {
            // check if user wants to perform the import
            //string msg = dbOleDb.GetLangString("ImportSalaryHours.DoYouWantToImport");
            string msg = "Ønsker du at importere løn og fraværsregistrering fra egruppe ?";
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

            // import Salary
            ImportDataSet.ImportSalaryHoursDataTable table;
            if (!ImportSalary(Payroll.PrlSalaryPeriodsDataTable.GetActiveSalaryPeriod(), out table, false, true))
            {
                MessageBox.Show(_LastMsg);
                log.Write("Error importing salary hours. Message: " + _LastMsg);
                return;
            }
            //import absense

            ImportDataSet.ImportAbsenseHoursDataTable table2;
            if (!ImportAbsense(Payroll.PrlSalaryPeriodsDataTable.GetActiveSalaryPeriod(), out table2, true))
            {
                MessageBox.Show(_LastMsg);
                log.Write("Error importing Absense hours. Message: " + _LastMsg);
                return;
            }


        }
        #endregion

        #region ImportSalary
        /// <summary>
        /// Imports the salary registratiom from egruppe webservice
        
        /// </summary>
        public bool ImportSalary(
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
                string CompID   = db.GetConfigString("eGruppe.CompID");
                string username =  db.GetConfigString("eGruppe.UserID");
                string password = db.GetConfigString("eGruppe.Password");                        
                
                int PeriodYear = tools.object2int(ActiveSalaryPeriod["PeriodYear"]);
                int Period = tools.object2int(ActiveSalaryPeriod["Period"]);
                //find start og slut dato 
                DataRow SalaryPeriod = Payroll.PrlSalaryPeriodsDataTable.GetActiveSalaryPeriod();
                if (SalaryPeriod == null)
                {
                    MessageBox.Show("ingen aktiv lønperiode");                 
                }
                DateTime PeriodStart = tools.object2datetime(SalaryPeriod["StartDate"]);
                DateTime PeriodEnd = tools.object2datetime(SalaryPeriod["EndDate"]);             
                progress.Title = string.Format(db.GetLangString("ImportSalaryHours.ImportSalaryHoursFrom"), "egruppe");
                if (ShowProgress)
                  progress.Show();
                // we read the file's lines into an array of strings,
                string HentReg = db.GetConfigString("eGruppe.TimeRegURL");                
                //("https://secure.egruppe.net/sync/getRegistrations.php?id={0}&from={1}&to={2}&departmentCode={3}&locked=1"               
                string HentRegUrl = string.Format(HentReg,CompID, PeriodStart.ToString("yyyy-MM-dd"), PeriodEnd.ToString("yyyy-MM-dd"), SiteCode);                
                Uri uri = new Uri(HentRegUrl);
                var webRequest = WebRequest.Create(uri);
                webRequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(username + ":" + password));
                webRequest.Method = "POST";                   
                HttpWebResponse Webresponse = (HttpWebResponse)webRequest.GetResponse();
                Stream resStream = Webresponse.GetResponseStream();
                StreamReader reader = new StreamReader(resStream);
                string regtext = reader.ReadToEnd();            
                string[] lines = regtext.Split(new Char[] { '\n'});
                int arraylen = lines.Length;
                // loop content
                progress.ProgressMax = arraylen;
                
                int recordcount = 0;
                foreach (string line in lines)
                {
                    ++recordcount;
                    progress.StatusText = string.Format(db.GetLangString("ImportSalaryHours.ImportingLineNofM"), recordcount, lines.Length);
                    string[] lineArray = line.Split(new Char[] { ';' });
                    // read values
                    if (lineArray.Length > 1 )
                    {
                        int EmployeeNo          = tools.object2int(lineArray[0]);
                        string CPR              = tools.object2string(lineArray[1]);
                        string Name             = tools.object2string(lineArray[2]) + " " + tools.object2string(lineArray[3]);
                        DateTime FromDate       = tools.object2datetime(lineArray[4]);
                        DateTime ToDate         = tools.object2datetime(lineArray[5]);
                        string Department       = tools.object2string(lineArray[6]);
                        string DepartmentLentTo = tools.object2string(lineArray[7]);
                        DateTime RegDate = FromDate.Date ;
                        TimeSpan StartTime = FromDate.TimeOfDay;
                        TimeSpan EndTime = ToDate.TimeOfDay;
                        String Remark = "";
                        if (Name == "")
                        {
                            // for print so don't translate
                            Name = string.Format("Ukendt medarbejder nr. {0}", EmployeeNo);
                        }

                        //udlån
                        if (Department != DepartmentLentTo)
                        {

                            if (Department == SiteCode) //Medarbejder er udlånt til anden station 
                            {
                                

                            }
                            else //Medarbejder er udlånt fra anden station 
                            {
                                EmployeeNo = 9999999;
                                Remark = Department + " " + Name;
                                DepartmentLentTo = Department;
                            }

                        }
                        else
                        {
                            DepartmentLentTo = null;
                        }
                        
                        // create record in table
                        Table.AddImportSalaryHoursRow(
                            CPR, EmployeeNo, Name, RegDate, StartTime, EndTime,Remark,DepartmentLentTo);                                      
                                                                        
                    }
                }

                progress.ProgressMax = Table.Rows.Count;
                progress.StatusText = db.GetLangString("ImportSalaryHours.UpdatingEmployees");                
                Payroll.PrlSalaryRegistrationDataTable.DeleteRecordsPeriod(ActiveSalaryPeriod);

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
                        r["SiteCode"] = row["SiteCode"];
                        r["Remarks"] = row["Remarks"];
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
                    tools.SetReportObjectText(rpt, "txtTitle", "Løntimer indlæsning fra egruppe" );
                   // tools.SetReportObjectText(rpt, "txtFilename", path);
                    rpt.SetDataSource((DataTable)Table);
                    tools.SetReportSiteInformation(rpt);
                    tools.Print(rpt, true);
                }
               

                // all ok, return succes
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                _LastMsg = log.WriteException("Import af løntimer Web service", ex.Message, ex.StackTrace);
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

        #region ImportAbsense
        /// <summary>
        /// Imports the absense registratiom from egruppe webservice

        /// </summary>
        public bool ImportAbsense(
            DataRow ActiveSalaryPeriod,
            out ImportDataSet.ImportAbsenseHoursDataTable Table, bool ShowProgress)
        {
            Table = new ImportDataSet.ImportAbsenseHoursDataTable();
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
                string CompID = db.GetConfigString("eGruppe.CompID");
                string username = db.GetConfigString("eGruppe.UserID");
                string password = db.GetConfigString("eGruppe.Password");

                int PeriodYear = tools.object2int(ActiveSalaryPeriod["PeriodYear"]);
                int Period = tools.object2int(ActiveSalaryPeriod["Period"]);
                //find start og slut dato 
                DataRow SalaryPeriod = Payroll.PrlSalaryPeriodsDataTable.GetActiveSalaryPeriod();
                if (SalaryPeriod == null)
                {
                    MessageBox.Show("ingen aktiv lønperiode");
                }
                DateTime PeriodStart = tools.object2datetime(SalaryPeriod["StartDate"]);
                DateTime PeriodEnd = tools.object2datetime(SalaryPeriod["EndDate"]);
                progress.Title = string.Format(db.GetLangString("ImportSalaryHours.ImportSalaryHoursFrom"), "egruppe");
                if (ShowProgress)
                    progress.Show();
                //// we read the file's lines into an array of strings,
                string HentReg = db.GetConfigString("eGruppe.AbsenseRegURL");
                //"https://secure.egruppe.net/sync/getAbsence.php?id={0}&from={1}&to={2}&departmentCode={3}&locked=0"                
                string HentRegUrl = string.Format(HentReg,CompID, PeriodStart.ToString("yyyy-MM-dd"), PeriodEnd.ToString("yyyy-MM-dd"), SiteCode);               
                Uri uri = new Uri(HentRegUrl);
                var webRequest = WebRequest.Create(uri);
                webRequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(username + ":" + password));
                webRequest.Method = "POST";
                HttpWebResponse Webresponse = (HttpWebResponse)webRequest.GetResponse();
                Stream resStream = Webresponse.GetResponseStream();
                StreamReader reader = new StreamReader(resStream);
                string regtext = reader.ReadToEnd();
                string[] lines = regtext.Split(new Char[] { '\n' });
                int arraylen = lines.Length;
                // loop content
                progress.ProgressMax = arraylen;
                int recordcount = 0;
                foreach (string line in lines)
                {
                    ++recordcount;
                    progress.StatusText = string.Format(db.GetLangString("ImportSalaryHours.ImportingLineNofM"), recordcount, lines.Length);
                    string[] lineArray = line.Split(new Char[] { ';' });
                    // read values
                    if (lineArray.Length > 1)
                    {
                        int EmployeeNo = tools.object2int(lineArray[0]);                    
                        DateTime FromDate = tools.object2datetime(lineArray[4]);
                        DateTime ToDate = tools.object2datetime(lineArray[5]);
                        int AbsenseCode = tools.object2int(lineArray[6]); 
                        TimeSpan StartTime = FromDate.TimeOfDay;
                        TimeSpan EndTime = ToDate.TimeOfDay;
                        TimeSpan diffDays;
                        TimeSpan diffHours;                      
                        int NoOffdays = 0;
                        decimal NoOffHours = 0;
                        if (FromDate.Date != ToDate.Date) //Der skal registreres dage
                        {
                            diffDays = ToDate - FromDate;
                            NoOffdays = diffDays.Days;
                        }

                        else  // Der skal registreres timer
                        {
                            diffHours = ToDate.TimeOfDay - FromDate.TimeOfDay;
                            NoOffHours = diffHours.Hours + (diffHours.Minutes / 60);                        
                        }

                         
                        if (FromDate == ToDate)
                        {
                            NoOffdays = 1;
                        }

                        // create record in table
                        Table.AddImportAbsenseHoursRow(EmployeeNo, FromDate, ToDate, NoOffdays,NoOffHours, AbsenseCode);

                    }
                }

                // create objects to access the PrlSalaryRegistration table
                // and to use the already coded OnColumnChanging event handler
                PayrollTableAdapters.PrlAbsenseTableAdapter adapterAbsense =
                    new RBOS.PayrollTableAdapters.PrlAbsenseTableAdapter();
                adapterAbsense.Connection = db.Connection;
                Payroll.PrlAbsenseDataTable.DeleteRecordsPeriod(ActiveSalaryPeriod);
                adapterAbsense.InsertCommand.Transaction = db.CurrentTransaction;
                Payroll.PrlAbsenseDataTable tableAbsenseReg = new Payroll.PrlAbsenseDataTable();
                // opdatér medarbejdere fravær ud fra indlæste data
                foreach (DataRow row in Table.Rows)
                {
                    DataRow r = tableAbsenseReg.NewRow();
                    int EmployeeNo = tools.object2int(row["MedarbejderNr"]);
                    if (EmployeeNo != 0)
                    {
                        r["EmployeeNo"] = EmployeeNo;
                        r["FromDateAsString"] = tools.object2datetime(row["FromDate"]).ToString("ddMMyyyy");
                        r["FromDateAsDateTime"] = tools.object2datetime(row["FromDate"]);
                        r["ToDateAsString"] = tools.object2datetime(row["ToDate"]).ToString("ddMMyyyy");
                        r["ToDateAsDateTime"] = tools.object2datetime(row["ToDate"]);                       
                        r["AbsenseCode"] = tools.object2int(row["AbsenseCode"]);
                        r["Hours"] = tools.object2double(row["Hours"]);
                        r["Days"] = tools.object2int(row["Days"]);
                        tableAbsenseReg.Rows.Add(r);                        
                    }
                }

                // save data to disk
                adapterAbsense.Update(tableAbsenseReg);
                db.CommitTransaction();
                // all ok, return succes
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                _LastMsg = log.WriteException("Import af fravær Web service", ex.Message, ex.StackTrace);
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
