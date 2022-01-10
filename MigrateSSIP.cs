using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace RBOS
{
    public class MigrateSSIP
    {
        #region Variables
        protected OleDbConnection ssipConnection = null;
        protected string SSIPdbFilename = "";
        #endregion

        #region Constructor
        public MigrateSSIP(string SSIPdbFilename)
        {
            this.SSIPdbFilename = SSIPdbFilename;
        }
        #endregion

        #region LastMsg property
        protected string _LastMsg = "";
        public string LastMsg
        {
            get { return _LastMsg; }
        }
        #endregion

        #region MigratePayroll
        /// <summary>
        /// This migration basically imports
        /// salary and absense registration data.
        /// For this we also need the corresponding
        /// employee data that the registrations were
        /// registered upon.
        /// </summary>
        public bool MigratePayroll()
        {
            ProgressForm progress = null;

            try
            {
                #region Various introductory stuff

                _LastMsg = "";

                // setup progress form
                progress = new ProgressForm("Migrerer løndata");
                progress.StatusText = "Tjekker diverse ting før migrering";
                progress.Show();

                // check that SSIP db file exists
                if (!File.Exists(SSIPdbFilename))
                {
                    _LastMsg = "SSIP db filen kunne ikke findes";
                    return false;
                }

                // (we only check those tables that will be affected)
                bool PrlEmployeeDataExists = (tools.object2int(db.ExecuteScalar(string.Format(
                    " select count(*) from PrlEmployee "))) > 0);
                bool PrlSalaryRegistrationDataExists = (tools.object2int(db.ExecuteScalar(string.Format(
                    " select count(*) from PrlSalaryRegistration "))) > 0);
                bool PrlAbsenseDataExists = (tools.object2int(db.ExecuteScalar(string.Format(
                    " select count(*) from PrlAbsense "))) > 0);
                if (PrlEmployeeDataExists || PrlSalaryRegistrationDataExists || PrlAbsenseDataExists)
                {
                    progress.Hide();
                    string msg = "Der eksisterer allerede lønmodul data i RBOS. Vil du slette dem og importere data fra SSIP?";
                    if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        _LastMsg = "Lønmigrering annulleret. Ingen løndata er ændret i RBOS.";
                        return false;
                    }
                    progress.Show();
                }

                // connect to SSIP db
                OpenConnection(SSIPdbFilename);

                // variables used a couple of times below
                OleDbDataAdapter ssipAdapter;
                DataTable ssipTable;
                int ActiveYear;
                int ActivePeriod;
                DataRow activeSalaryPeriod;

                // detect any missing salary periods or holidays
                ssipTable = LoadSSIPData(" select distinct year(Dato) as PeriodYear from LonData ");
                string MissingSalaryPeriodYears = "";
                string MissingHolidayYears = "";
                foreach (DataRow row in ssipTable.Rows)
                {
                    int year = tools.object2int(row["PeriodYear"]);

                    // everything before 2006 is ignored
                    if (year >= 2006)
                    {
                        // detect missing salary period years
                        if (tools.object2int(db.ExecuteScalar(string.Format(
                            " select count(*) from PrlSalaryPeriods " +
                            " where PeriodYear = {0} ", year))) <= 0)
                        {
                            if (MissingSalaryPeriodYears != "")
                                MissingSalaryPeriodYears += ", ";
                            MissingSalaryPeriodYears += year.ToString();
                        }

                        // detect missing holiday years
                        if (tools.object2int(db.ExecuteScalar(string.Format(
                            " select count(*) from PrlHolidays " +
                            " where year(HolidayDate) = {0} ", year))) <= 0)
                        {
                            if (MissingHolidayYears != "")
                                MissingHolidayYears += ", ";
                            MissingHolidayYears += year.ToString();
                        }
                    }
                }
                // if missing salary periods or holidays, display message and abort migration
                if ((MissingSalaryPeriodYears != "") || (MissingHolidayYears != ""))
                {
                    _LastMsg = "Der mangler at blive importeret:\n";
                    if (MissingSalaryPeriodYears != "")
                        _LastMsg += string.Format("\nLønperioder for {0}.", MissingSalaryPeriodYears);
                    if (MissingHolidayYears != "")
                        _LastMsg += string.Format("\nHelligdage for {0}.", MissingHolidayYears);
                    _LastMsg += "\n\nLønmigrering annulleret. Ingen løndata er ændret i RBOS.";
                    db.RollbackTransaction();
                    return false;
                }

                #endregion

                #region Migrate data for PrlEmployee

                progress.ProgressMax = 0;
                progress.StatusText = "Migrerer medarbejdere";

                // empty PrlEmployee table
                db.ExecuteNonQuery(" delete from PrlEmployee ");

                // copy data
                ssipTable = LoadSSIPData(" select * from Medarbejder ");
                progress.ProgressMax = ssipTable.Rows.Count;
                foreach (DataRow row in ssipTable.Rows)
                {
                    // insert record in PrlEmployee
                    db.ExecuteNonQuery(string.Format(
                        " insert into PrlEmployee " +
                        " (EmployeeNo,FirstName,LastName,Address1,Address2,ZipCode,City,Phone,ContactPhone," +
                        "  CPR,Post,StartDate,EndDate,EmployeeType,FuncHours,Education,NotIncludedInReg,IsFunc) " +
                        " values ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17}) ",
                        tools.object2int(row["Medarbejder nummer"]),
                        tools.string4sql(row["Fornavn"], 50),
                        tools.string4sql(row["Efternavn"], 50),
                        tools.string4sql(row["Adresse"], 100),
                        tools.string4sql(row["Adresse2"], 100),
                        tools.string4sql(row["Postnr"], 10),
                        tools.string4sql(row["Bynavn"], 50),
                        tools.string4sql(row["Telefon"], 20),
                        tools.string4sql(row["KontaktTelefon"], 20),
                        tools.string4sql(row["CPR-nr"], 20),
                        tools.string4sql(row["Stilling"], 50),
                        tools.datetime4sql(row["Ansættelsesdato"]),
                        tools.datetime4sql(row["Fratrædelsesdato"]),
                        tools.string4sql(row["MedarbejderType"], 20),
                        tools.decimalnumber4sql(row["FunkTimer"]),
                        (tools.object2bool(row["SIDUnderUdd"]) || tools.object2bool(row["HKUnderUdd"])),
                        tools.object2bool(row["MedtagesIkke"]),
                        (tools.object2string(row["MedarbejderType"]).ToLower() == "funktionær")));
                    progress.StatusText = "Migrerer medarbejdere";
                }

                #endregion

                #region Migrate data for PrlSalaryRegistration

                progress.ProgressMax = 0;
                progress.StatusText = "Migrerer lønregistreringer";

                // empty PrlSalaryRegistration table
                db.ExecuteNonQuery(" delete from PrlSalaryRegistration ");

                // load ssip salary registration data
                ssipAdapter = new OleDbDataAdapter(
                    " select MedarbejderID, Dato, FraKl, TilKl, Bemærkninger, Overtid from LonData ",
                    ssipConnection);
                ssipTable = new DataTable();
                ssipAdapter.Fill(ssipTable);

                // save the current active salary period
                ActiveYear = 0;
                ActivePeriod = 0;
                activeSalaryPeriod = Payroll.PrlSalaryPeriodsDataTable.GetActiveSalaryPeriod();
                if (activeSalaryPeriod != null)
                {
                    ActiveYear = tools.object2int(activeSalaryPeriod["PeriodYear"]);
                    ActivePeriod = tools.object2int(activeSalaryPeriod["Period"]);
                }

                // create objects to access the PrlSalaryRegistration table
                // and to use the already coded OnColumnChanging event handler
                PayrollTableAdapters.PrlSalaryRegistrationTableAdapter adapterSalReg =
                    new RBOS.PayrollTableAdapters.PrlSalaryRegistrationTableAdapter();
                adapterSalReg.Connection = db.Connection;
                adapterSalReg.InsertCommand.Transaction = db.CurrentTransaction;
                Payroll.PrlSalaryRegistrationDataTable tableSalReg = new Payroll.PrlSalaryRegistrationDataTable();

                // suppress dialogs in PrlSalaryRegistration.OnColumnChanging event
                tableSalReg.Migrating = true;

                // loop ssip salary registration data
                progress.ProgressMax = ssipTable.Rows.Count;
                foreach (DataRow row in ssipTable.Rows)
                {
                    // get the salary registration date
                    DateTime RegDate = tools.object2datetime(row["Dato"]).Date;

                    // get the salary period and check that we have a salary period for this date
                    DataRow SalaryPeriod = Payroll.PrlSalaryPeriodsDataTable.GetSalaryPeriod(RegDate);
                    if (SalaryPeriod != null)
                    {
                        // activate the needed salary period
                        int PeriodYear = tools.object2int(SalaryPeriod["PeriodYear"]);
                        int Period = tools.object2int(SalaryPeriod["Period"]);
                        Payroll.PrlSalaryPeriodsDataTable.SetActiveSalaryPeriod(PeriodYear, Period);

                        // import data using existing event handler code
                        /// DayNo, RegDateAsDateTime, Hours, Overtime, TakeTimeOff,
                        /// Remarks and the Bonus fields are calculated in the
                        /// PrlSalaryPeriodsDataTable.OnColumnChanging event
                        DataRow r = tableSalReg.NewRow();
                        r["EmployeeNo"] = tools.object2int(row["MedarbejderID"]);
                        r["RegDateAsString"] = RegDate.ToString("dd");
                        r["FromTimeAsString"] = tools.object2timespan(row["Frakl"]);
                        r["ToTimeAsString"] = tools.object2timespan(row["TilKl"]);
                        r["Remarks"] = row["Bemærkninger"]; // they have the same size
                        r["Overtime"] = tools.object2double(row["Overtid"]);
                        tableSalReg.Rows.Add(r);
                    }
                    progress.StatusText = "Migrerer lønregistreringer";
                }

                // re-enable dialogs in PrlSalaryRegistration.OnColumnChanging event
                tableSalReg.Migrating = false;

                // save data to disk
                adapterSalReg.Update(tableSalReg);

                // restore current active salary period
                Payroll.PrlSalaryPeriodsDataTable.SetActiveSalaryPeriod(ActiveYear, ActivePeriod);

                #endregion

                #region Migrate data for PrlAbsense

                progress.ProgressMax = 0;
                progress.StatusText = "Migrerer fraværsregistreringer";

                // empty PrlAbsense table
                db.ExecuteNonQuery(" delete from PrlAbsense ");

                // load ssip absense data
                ssipAdapter = new OleDbDataAdapter(
                    " select MedarbejderID, Dato, TilDato, FravaerKode, Timer, AntalDage from FraværsData ",
                    ssipConnection);
                ssipTable = new DataTable();
                ssipAdapter.Fill(ssipTable);

                // loop ssip absense data
                progress.ProgressMax = ssipTable.Rows.Count;
                foreach (DataRow row in ssipTable.Rows)
                {
                    // get various values
                    int EmployeeNo = tools.object2int(row["MedarbejderID"]);
                    DateTime FromDate = tools.object2datetime(row["Dato"]).Date;
                    DateTime ToDate = tools.object2datetime(row["TilDato"]).Date;

                    // get absense code
                    int AbsenseCode = tools.object2int(row["FravaerKode"]);
                    if (!Payroll.PrlLookupAbsenseCodesDataTable.AbsenseCodeExists(AbsenseCode))
                        AbsenseCode = 50; // Andet fravær

                    // get hours and days
                    object Hours = DBNull.Value;
                    object Days = DBNull.Value;
                    if (FromDate == ToDate)
                        Hours = tools.object2double(row["Timer"]);
                    else
                        Days = tools.object2int(row["AntalDage"]);

                    // check validity of data
                    if ((FromDate != DateTime.MinValue) &&
                        (ToDate != DateTime.MinValue) &&
                        (tools.object2int(Hours) >= 0) &&
                        (tools.object2int(Days) >= 0))
                    {
                        db.ExecuteNonQuery(string.Format(
                            " insert into PrlAbsense " +
                            " (EmployeeNo,DayNo,FromDateAsString,FromDateAsDateTime," +
                            "  ToDateAsString,ToDateAsDateTime,AbsenseCode,Hours,Days) " +
                            " values ({0},{1},{2},{3},{4},{5},{6},{7},{8}) ",
                            EmployeeNo,
                            tools.DayOfWeek2DayNo(FromDate.DayOfWeek),
                            tools.string4sql(FromDate.ToString("dd-MM-yyyy"), 10),
                            tools.datetime4sql(FromDate),
                            tools.string4sql(ToDate.ToString("dd-MM-yyyy"), 10),
                            tools.datetime4sql(ToDate),
                            AbsenseCode,
                            tools.decimalnumber4sql(Hours),
                            tools.wholenumber4sql(Days)));
                    }

                    // show progress
                    progress.StatusText = "Migrerer fraværsregistreringer";
                }

                #endregion

                #region Migrate status on salary periods

                progress.StatusText = "Migrerer status på lønperioder";

                // load ssip salary periods table
                ssipTable = LoadSSIPData(@"
                    select
                      LonPeriode as Period,
                      year(DatoStop) as PeriodYear,
                      AktivLønperiode as Active,
                      PeriodeDataGodkendt as Approved,
                      DataUdtrukket as Sent
                    from LonPeriode
                    ");

                progress.ProgressMax = ssipTable.Rows.Count;

                // update salary periods statuses
                foreach (DataRow rowLonperiod in ssipTable.Rows)
                {
                    Payroll.PrlSalaryPeriodsDataTable.UpdateSalaryPeriod(
                        tools.object2int(rowLonperiod["PeriodYear"]),
                        tools.object2int(rowLonperiod["Period"]),
                        tools.object2bool(rowLonperiod["Active"]),
                        tools.object2bool(rowLonperiod["Approved"]),
                        tools.object2bool(rowLonperiod["Sent"]));
                    progress.StatusText = "Migrerer status på lønperioder";
                }

                #endregion

                // migration succeeded
                _LastMsg = "Migrering fuldført";
                db.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                /// A crash while running through the SSIP tables
                /// could mean that a table does not exist or that
                /// the table has a different structure than expected.
                /// This might not be the correct database.
                _LastMsg = log.WriteException("Fejl under kopiering af løndata.", ex.Message, ex.StackTrace);
                return false;
            }
            finally
            {
                CloseConnection();
                if (progress != null)
                    progress.Close();
            }
        }

        #endregion

        #region MigrateEOD
        /// <summary>
        /// Migrerer SSIP EOD data fra 01-01-2006 og frem.
        /// Det er de data, der fyldes i RBOS' EOD tabeller.
        /// Der migreres også data til GLBudget.
        /// </summary>
        public bool MigrateEOD()
        {
            ProgressForm progress = new ProgressForm("Migrerer dagsopgørelsesdata");
            progress.Show();
            try
            {
                _LastMsg = "";

                OpenConnection(SSIPdbFilename);

                // tabeller der skal cleares først
                progress.StatusText = "Sletter RBOS dagsopgørelsesdata";
                db.ExecuteNonQuery("delete from EODReconcile");
                db.ExecuteNonQuery("delete from EODReconcileEx");
                db.ExecuteNonQuery("delete from EOD_BankDep");
                db.ExecuteNonQuery("delete from EOD_ForeignCurrency");
                db.ExecuteNonQuery("delete from EOD_ManualCards");
                db.ExecuteNonQuery("delete from EOD_PayinPayout");
                db.ExecuteNonQuery("delete from EOD_LocalCred");
                db.ExecuteNonQuery("delete from EOD_Sales");

                // hent dagsopgørelsesdata fra ssip tabellen
                progress.StatusText = "Henter SSIP dagsopgørelsesdata";
                DataTable tableDagsopgoerelse = this.LoadSSIPData(@"
                    select * from [DagsOpgørelse]
                    where Bogfdato >= cdate('01-01-2006')
                    order by Bogfdato
                    ");

                progress.ProgressMax = tableDagsopgoerelse.Rows.Count;

                // loop DagsOpgørelse og kopier forskellige data
                foreach (DataRow rowDagsopgoerelse in tableDagsopgoerelse.Rows)
                {
                    int DagsOpgId = tools.object2int(rowDagsopgoerelse["DagsOpgId"]);
                    DateTime Bogfdato = tools.object2datetime(rowDagsopgoerelse["Bogfdato"]).Date;

                    progress.StatusText = "Kopierer data for døgn: " + Bogfdato.ToString("dd-MM-yyyy");

                    // kopiér data fra DagsOpgørelse til EODReconcile
                    EODDataSet.EODReconcileDataTable.CreateNewRecordWhenMigratingFromRBA(
                        Bogfdato,
                        rowDagsopgoerelse["IaltIndsatBank"],
                        rowDagsopgoerelse["ManuelleKort"],
                        rowDagsopgoerelse["KontantRabatten"],
                        rowDagsopgoerelse["BilagKreditBeløb"],
                        rowDagsopgoerelse["BilagKreditIndBeløb"],
                        rowDagsopgoerelse["ValutaDKK"],
                        rowDagsopgoerelse["Indbetalinger"],
                        rowDagsopgoerelse["Udbetalinger"],
                        rowDagsopgoerelse["SolgtVask"]);

                    // kopiér kundeantal fra DagsOpgørelse til EODReconcileEx
                    EODDataSet.EODReconcileExDataTable.InsertOrUpdateRecord(
                        Bogfdato,
                        tools.object2int(rowDagsopgoerelse["KunderKontantAntal"]));

                    // kopiér data fra BilagKredit, der hører til
                    // denne DagsOpgørelse record, til EOD_LocalCred
                    DataTable tableBilagKredit = this.LoadSSIPData(string.Format(@"
                        select * from BilagKredit
                        where DagsOpgId = {0}
                        ", DagsOpgId));
                    foreach (DataRow rowBilagKredit in tableBilagKredit.Rows)
                    {
                        EODDataSet.EOD_LocalCredDataTable.CreateNewRecord(
                            Bogfdato,
                            TransTypeLocalCred.LocalCredit,
                            tools.object2int(rowBilagKredit["Kundenr"]),
                            tools.object2string(rowBilagKredit["Bemærkning"]),
                            tools.object2double(rowBilagKredit["Beløb"]));
                    }

                    // kopiér data fra BilagKreditIndbet, der hører til
                    // denne DagsOpgørelse record, til EOD_LocalCred
                    DataTable tableBilagKreditIndbet = this.LoadSSIPData(string.Format(@"
                        select * from BilagKreditIndbet
                        where DagsOpgId = {0}
                        ", DagsOpgId));
                    foreach (DataRow rowBilagKreditIndbet in tableBilagKreditIndbet.Rows)
                    {
                        EODDataSet.EOD_LocalCredDataTable.CreateNewRecord(
                            Bogfdato,
                            TransTypeLocalCred.LocalCreditPayin,
                            tools.object2int(rowBilagKreditIndbet["Kundenr"]),
                            tools.object2string(rowBilagKreditIndbet["Bemærkning"]),
                            tools.object2double(rowBilagKreditIndbet["Beløb"]));
                    }

                    // kopiér data fra BilagBank, der hører til
                    // denne Dagsopgørelse record, til EOD_BankDep
                    DataTable tableBilagBank = this.LoadSSIPData(string.Format(@"
                        select * from BilagBank
                        where DagsOpgId = {0}
                        ", DagsOpgId));
                    foreach (DataRow rowBilagBank in tableBilagBank.Rows)
                    {
                        EODDataSet.EOD_BankDepDataTable.CreateNewRecord(                                                
                            Bogfdato,
                            tools.object2string(rowBilagBank["Tekst"]),
                            tools.object2double(rowBilagBank["Beløb"]));
                    }

                    // kopiér data fra BilagManKort, der hører til
                    // denne DagsOpgørelse record, til EOD_ManualCards
                    DataTable tableBilagManKort = this.LoadSSIPData(string.Format(@"
                        select * from BilagManKort
                        where DagsOpgId = {0}
                        ", DagsOpgId));
                    foreach (DataRow rowBilagManKort in tableBilagManKort.Rows)
                    {
                        EODDataSet.EOD_ManualCardsDataTable.CreateNewRecord(
                            Bogfdato,
                            tools.object2string(rowBilagManKort["Tekst"]),
                            tools.object2double(rowBilagManKort["Beløb"]));
                    }

                    // kopiér data fra BilagValutaDKK, der hører til
                    // denne DagsOpgørelse record, til EOD_ForeignCurrency
                    DataTable tableBilagValutaDKK = this.LoadSSIPData(string.Format(@"
                        select * from BilagValutaDKK
                        where DagsOpgId = {0}
                        ", DagsOpgId));
                    foreach (DataRow rowBilagValutaDKK in tableBilagValutaDKK.Rows)
                    {
                        EODDataSet.EOD_ForeignCurrencyDataTable.CreateNewRecord(
                            Bogfdato,
                            tools.object2string(rowBilagValutaDKK["Tekst"]),
                            tools.object2double(rowBilagValutaDKK["Beløb"]));
                    }

                    // kopiér data fra BilagIndbet, der hører til
                    // denne DagsOpgørelse record, til EOD_PayinPayout
                    DataTable tableBilagIndbet = this.LoadSSIPData(string.Format(@"
                        select * from BilagIndbet
                        where DagsOpgId = {0}
                        ", DagsOpgId));
                    foreach (DataRow rowBilagIndbet in tableBilagIndbet.Rows)
                    {
                        EODDataSet.EOD_PayinPayoutDataTable.CreateNewRecord(
                            Bogfdato,
                            TransTypePayinPayout.Payin,
                            tools.object2string(rowBilagIndbet["Tekst"]),
                            tools.object2double(rowBilagIndbet["Beløb"]),
                            false);
                    }

                    // kopiér data fra BilagUdbet, der hører til
                    // denne DagsOpgørelse record, til EOD_PayinPayout
                    DataTable tableBilagUdbet = this.LoadSSIPData(string.Format(@"
                        select * from BilagUdbet
                        where DagsOpgId = {0}
                        ", DagsOpgId));
                    foreach (DataRow rowBilagUdbet in tableBilagUdbet.Rows)
                    {
                        EODDataSet.EOD_PayinPayoutDataTable.CreateNewRecord(
                            Bogfdato,
                            TransTypePayinPayout.Payout,
                            tools.object2string(rowBilagUdbet["Tekst"]),
                            tools.object2double(rowBilagUdbet["Beløb"]),
                            false);
                    }

                    // kopiér data fra BilagVaresalgRap, der hører til
                    // denne DagsOpgørelse record, til EOD_Sales
                    DataTable tableBilagVaresalgRap = this.LoadSSIPData(string.Format(@"
                        select * from BilagVaresalgRap
                        where DagsOpgId = {0}
                        ", DagsOpgId));
                    foreach (DataRow rowBilagVaresalgRap in tableBilagVaresalgRap.Rows)
                    {
                        string GLCode = tools.object2string(rowBilagVaresalgRap["Konto"]);
                        string SubCatID = ItemDataSet.SubCategoryDataTable.GetSubCategoryIDFromGLCode(GLCode);
                        if (SubCatID != "")
                        {
                            EODDataSet.EOD_SalesDataTable.CreateRecord(
                                Bogfdato,
                                TransTypeSales.POSSales,
                                GLCode,
                                tools.object2double(rowBilagVaresalgRap["Antal"]),
                                tools.object2double(rowBilagVaresalgRap["Beløb"]));
                        }
                        else
                        {
                            log.Write(string.Format("Kan ikke finde subkategori til konto {0}", GLCode));
                        }
                    }
                } // foreach DagsOpgørelse record

                CloseConnection();
                _LastMsg = "Migrering fuldført";
                return true;
            }
            catch (Exception ex)
            {
                _LastMsg = log.WriteException(
                    "Fejl under kopiering af dagsopgørelsesdata",
                    ex.Message,
                    ex.StackTrace);
                return false;
            }
            finally
            {
                progress.Close();
            }
        }
        #endregion

        #region MigrateBudget
        public bool MigrateBudget()
        {
            ProgressForm progress = new ProgressForm("Migrerer budget");
            progress.Show();
            try
            {
                _LastMsg = "";

                OpenConnection(SSIPdbFilename);

                // kopiér data fra Budget til GLBudget
                progress.StatusText = "Kopierer budgetdata";
                db.ExecuteNonQuery("delete from GLBudget");
                DataTable tableBudget = this.LoadSSIPData(string.Format(@"
                    select * from Budget
                    where BudgetAar >= 2006
                    order by ID
                    "));
                progress.ProgressMax = tableBudget.Rows.Count;
                foreach (DataRow rowBudget in tableBudget.Rows)
                {
                    string GLCode = tools.object2string(rowBudget["KontoNr"]);
                    int BudgetYear = tools.object2int(rowBudget["BudgetAar"]);
                    for (int BudgetMonth = 1; BudgetMonth <= 12; BudgetMonth++)
                    {
                        string VolumeField = string.Format("StkPer{0}", BudgetMonth);
                        string AmountField = string.Format("KrPer{0}", BudgetMonth);
                        double Volume = tools.object2double(rowBudget[VolumeField]);
                        double Amount = tools.object2double(rowBudget[AmountField]);
                        EODDataSet.GLBudgetDataTable.CreateRecord(
                            GLCode, BudgetYear, BudgetMonth, Volume, Amount);
                        progress.StatusText = string.Format("Kopierer data for år {0} måned {1}", BudgetYear, BudgetMonth);
                    }
                }

                CloseConnection();
                _LastMsg = "Migrering fuldført";
                return true;
            }
            catch (Exception ex)
            {
                _LastMsg = log.WriteException(
                    "Fejl under kopiering af budget",
                    ex.Message,
                    ex.StackTrace);
                return false;
            }
            finally
            {
                progress.Close();
            }
        }
        #endregion

        #region MigrateDebtor
        public bool MigrateDebtor()
        {
            ProgressForm progress = new ProgressForm("Migrerer debitor");
            progress.Show();
            try
            {
                _LastMsg = "";

                OpenConnection(SSIPdbFilename);

                // slet RBOS debitor stamdata
                db.ExecuteNonQuery("delete from EOD_Debtor");

                // slet RBOS debitorposter
                db.ExecuteNonQuery("delete from EOD_LocalCred");

                // hent debitor stamdata fra SSIP
                DataTable tableDebitor = LoadSSIPData(string.Format(@"
                    select * from Debitor
                    order by Fornavn,Efternavn
                    "));

                progress.ProgressMax = tableDebitor.Rows.Count;

                // kopiér debitor stamdata
                foreach (DataRow rowDebitor in tableDebitor.Rows)
                {
                    progress.StatusText = string.Format("Kopierer data for {0} {1}",
                        tools.object2string(rowDebitor["Fornavn"]),
                        tools.object2string(rowDebitor["Efternavn"]));

                    //int DebtorNo = EODDataSet.EOD_DebtorDataTable.GetNextUniqueDebtorNo();
                    int KundeNr = tools.object2int(rowDebitor["KundeNr"]);
                    EODDataSet.EOD_DebtorDataTable.CreateNewRecord(
                        KundeNr,
                        tools.object2string(rowDebitor["Fornavn"]) + " " + tools.object2string(rowDebitor["Efternavn"]),
                        "",
                        tools.object2string(rowDebitor["Adresse1"]),
                        tools.object2string(rowDebitor["Adresse2"]),
                        tools.object2string(rowDebitor["Postnr"]),
                        tools.object2string(rowDebitor["Bynavn"]),
                        tools.object2string(rowDebitor["Telefon"]),
                        tools.object2string(rowDebitor["Att"]),
                        "");

                    // hent debitorposter fra SSIP for denne debitor
                    DataTable tableDebitorBevaegelser = LoadSSIPData(string.Format(@"
                        select * from DebitorBevægelser
                        where KundeNr = {0}
                        ", KundeNr));

                    // kopiér debitorposter for denne debitor
                    foreach (DataRow row in tableDebitorBevaegelser.Rows)
                    {
                        // gæt en SSIP transktionstype
                        int status = tools.object2int(row["Status"]);
                        double amount = tools.object2double(row["Beløb"]);
                        TransTypeLocalCred transtype;
                        if (status != 1)
                        {
                          transtype = TransTypeLocalCred.LocalCreditManual;
                          amount = amount * -1; // RBOS bruger modsat fortegn ifht. SSIP på manuelle poster
                        }
                        else if (amount < 0)
                        {
                          transtype = TransTypeLocalCred.LocalCreditPayin;
                          amount = Math.Abs(amount); // fordi vi ikke har fortegn på beløbet ved kredit typen
                        }
                        else
                        {
                          transtype = TransTypeLocalCred.LocalCredit;
                          amount = Math.Abs(amount); // fordi vi ikke har fortegn på beløbet ved payint typen
                        }

                        // opret transaktion
                        EODDataSet.EOD_LocalCredDataTable.CreateNewRecord(
                            tools.object2datetime(row["BevDato"]),
                            transtype,
                            KundeNr,
                            tools.object2string(row["Bemærkning"]),
                            amount);
                    }
                }

                CloseConnection();
                _LastMsg = "Migrering fuldført";
                return true;
            }
            catch (Exception ex)
            {
                _LastMsg = log.WriteException(
                    "Fejl under kopiering af debitor",
                    ex.Message,
                    ex.StackTrace);
                return false;
            }
            finally
            {
                progress.Close();
            }
        }
        #endregion

        #region MigrateReadings
        public bool MigrateReadings()
        {
            ProgressForm progress = new ProgressForm("Migrerer el- og vandaflæsninger");
            progress.Show();
            try
            {
                _LastMsg = "";

                OpenConnection(SSIPdbFilename);

                // slet RBOS aflæsninger
                db.ExecuteNonQuery("delete from Readings");

                // hent aflæsninger fra SSIP
                DataTable tableAflaesninger = LoadSSIPData(string.Format(@"
                    select * from Aflaesninger
                    where (Aflaesningsdato is not null)
                    and (Aflaesningsdato >= cdate('01-01-2006'))
                    order by Aflaesningsdato
                    "));

                progress.ProgressMax = tableAflaesninger.Rows.Count;

                // kopiér aflæsninger
                foreach (DataRow rowAflaesninger in tableAflaesninger.Rows)
                {
                    EODDataSet.ReadingsDataTable.CreateRecordWhenMigratingFromSSIP(
                        tools.object2datetime(rowAflaesninger["Aflaesningsdato"]),
                        tools.object2int(rowAflaesninger["HovedVandAflaesning"]),
                        tools.object2int(rowAflaesninger["HovedVandmaalerPrimo"]),
                        tools.object2int(rowAflaesninger["VaskVandAflaesning"]),
                        tools.object2int(rowAflaesninger["VandmaalerVaskPrimo"]),
                        tools.object2int(rowAflaesninger["KilowattAflaesning"]),
                        tools.object2int(rowAflaesninger["KiloWattPrimo"]));
                }

                CloseConnection();
                _LastMsg = "Migrering fuldført";
                return true;
            }
            catch (Exception ex)
            {
                _LastMsg = log.WriteException(
                    "Fejl under kopiering af el- og vandaflæsninger",
                    ex.Message,
                    ex.StackTrace);
                return false;
            }
            finally
            {
                progress.Close();
            }
        }
        #endregion

        #region MigrateWash
        public bool MigrateWash()
        {
            ProgressForm progress = new ProgressForm("Migrerer vask");
            progress.Show();
            try
            {
                _LastMsg = "";

                OpenConnection(SSIPdbFilename);

                // slet RBOS vask
                db.ExecuteNonQuery("delete from Wash");

                // hent vask fra SSIP
                DataTable tableVask = LoadSSIPData(string.Format(@"
                    select * from Vask
                    where (BogfDatoOpgjort is not null)
                    and (BogfDatoOpgjort >= cdate('01-01-2006'))
                    order by BogfDatoOpgjort
                    "));

                progress.ProgressMax = tableVask.Rows.Count;

                // kopiér vask
                foreach (DataRow rowVask in tableVask.Rows)
                {
                    EODDataSet.WashDataTable.CreateRecordWhenMigratingFromSSIP(
                        tools.object2datetime(rowVask["BogfDatoOpgjort"]),
                        tools.object2int(rowVask["VasketaellerPrimo"]),
                        tools.object2int(rowVask["VasketaellerPrimo2"]),
                        tools.object2int(rowVask["VasketaellerPrimo3"]),
                        tools.object2int(rowVask["VaskLuksusMedLakforsegler"]),
                        tools.object2int(rowVask["VaskLuksus"]),
                        tools.object2int(rowVask["VaskA"]),
                        tools.object2int(rowVask["VaskB"]),
                        tools.object2int(rowVask["VaskC"]),
                        tools.object2int(rowVask["VaskVolumen"]),
                        tools.object2int(rowVask["VaskTekniker"]),
                        tools.object2int(rowVask["TaellerUltimoAflaest"]),
                        tools.object2int(rowVask["TaellerUltimoAflaest2"]),
                        tools.object2int(rowVask["TaellerUltimoAflaest3"]));
                }

                CloseConnection();
                _LastMsg = "Migrering fuldført";
                return true;
            }
            catch (Exception ex)
            {
                _LastMsg = log.WriteException(
                    "Fejl under kopiering af vask",
                    ex.Message,
                    ex.StackTrace);
                return false;
            }
            finally
            {
                progress.Close();
            }
        }
        #endregion

        #region MigrateStationAndConfig
        public bool MigrateStationAndConfig()
        {
            ProgressForm progress = new ProgressForm("Migrerer station og config");
            progress.StatusText = "Vent venligst...";
            progress.Show();
            try
            {
                _LastMsg = "";

                OpenConnection(SSIPdbFilename);

                DataTable tableStation = LoadSSIPData("select * from Station");
                if (tableStation.Rows.Count > 0)
                {
                    DataRow row = tableStation.Rows[0];

                    db.SetConfigString("Readings.SeperateWashReadings", tools.object2bool(row["HarVaskeVandmaaler"]));
                    db.SetConfigString("Readings.StationHasWash", tools.object2bool(row["HarVask"]));
                    db.SetConfigString("Readings.VaskeAfstemning2", tools.object2bool(row["HarVaskeafstemning2"]));
                    db.SetConfigString("Readings.VaskeAfstemning3", tools.object2bool(row["HarVaskeafstemning3"]));

                    AdminDataSet.SiteInformationDataTable.SetSiteCode(tools.object2string(row["Afdeling"]));
                    AdminDataSet.SiteInformationDataTable.SetAddress1(tools.object2string(row["Adresse1"]));
                    AdminDataSet.SiteInformationDataTable.SetAddress2(tools.object2string(row["Adresse2"]));
                    AdminDataSet.SiteInformationDataTable.SetZipCode(tools.object2string(row["Postnr"]));
                    AdminDataSet.SiteInformationDataTable.SetCity(tools.object2string(row["Bynavn"]));
                    AdminDataSet.SiteInformationDataTable.SetTelephone(tools.object2string(row["Telefon"]));
                    AdminDataSet.SiteInformationDataTable.SetFaxNo(tools.object2string(row["Telefax"]));
                }

                CloseConnection();
                _LastMsg = "Migrering fuldført";
                return true;
            }
            catch (Exception ex)
            {
                _LastMsg = log.WriteException(
                    "Fejl under kopiering af station og config",
                    ex.Message,
                    ex.StackTrace);
                return false;
            }
            finally
            {
                progress.Close();
            }
        }
        #endregion

        #region LoadSSIPData
        protected DataTable LoadSSIPData(string sql)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, ssipConnection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        #endregion

        #region OpenConnection
        protected void OpenConnection(string SSIPdbFilename)
        {
            ssipConnection = new OleDbConnection(
                    "Data Source=" + SSIPdbFilename + ";" +
                    "Provider='Microsoft.Jet.OLEDB.4.0';" +
                    "Jet OLEDB:Engine Type=5;");
            ssipConnection.Open();
        }
        #endregion

        #region CloseConnection
        protected void CloseConnection()
        {
            if ((ssipConnection != null) && (ssipConnection.State == ConnectionState.Open))
                ssipConnection.Close();
        }
        #endregion
    }
}
