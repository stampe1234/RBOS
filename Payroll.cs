using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections.Generic;

namespace RBOS.PayrollTableAdapters
{
    partial class PrlEmployeeTableAdapter
    {
    }

    partial class PrlSalaryPeriodsTableAdapter
    {
    }
    #region Partial class PrlSalaryRegistrationTableAdapter
    /// <summary>
    /// Custom addons for the PrlSalaryRegistrationTableAdapter.
    /// </summary>
    public partial class PrlSalaryRegistrationTableAdapter : System.ComponentModel.Component
    {
        /// <summary>
        /// Custom property for getting the UpdateCommand.
        /// </summary>
        public OleDbCommand UpdateCommand
        {
            get { return this._adapter.UpdateCommand; }
        }

        /// <summary>
        /// Custom property for getting the InsertCommand.
        /// </summary>
        public OleDbCommand InsertCommand
        {
            get { return this._adapter.InsertCommand; }
        }
    }
    #endregion

    #region Partial class PrlAbsenseTableAdapter
    /// <summary>
    /// Custom addons for the PrlAbsenseTableAdapter.
    /// </summary>
    public partial class PrlAbsenseTableAdapter : System.ComponentModel.Component
    {
        /// <summary>
        /// Custom property for getting the UpdateCommand.
        /// </summary>
        public OleDbCommand UpdateCommand
        {
            get { return this._adapter.UpdateCommand; }
        }

        /// <summary>
        /// Custom property for getting the InsertCommand.
        /// </summary>
        public OleDbCommand InsertCommand
        {
            get { return this._adapter.InsertCommand; }
        }
    }
    #endregion
}

namespace RBOS
{
    partial class Payroll
    {
        partial class PrlEmployeeDropDownDataTable
        {
        }

        partial class PrlRptLentOutFrm_EmployeesComboDataTable
        {
        }

        partial class PrlRptWithdrawDataTable
        {
        }
        #region Partial class PrlLookupAbsenseCodesDataTable
        partial class PrlLookupAbsenseCodesDataTable
        {
            public static bool AbsenseCodeExists(int Code)
            {
                return (tools.object2int(db.ExecuteScalar(string.Format(
                    " select count(*) from PrlLookupAbsenseCodes " +
                    " where AbsenseCode = {0} ", Code))) > 0);
            }
        }
        #endregion

        #region Partial class PrlWithdrawDataTable
        partial class PrlWithdrawDataTable
        {
            private bool SettingInitialRecordValues = false;

            private bool _DataWasAutoCalculated = false;
            public bool DataWasAutoCalculated
            {
                get { return _DataWasAutoCalculated; }
                set { _DataWasAutoCalculated = value; }
            }

            protected override void OnColumnChanging(DataColumnChangeEventArgs e)
            {
                _DataWasAutoCalculated = true;

                if (SettingInitialRecordValues)
                    return;

                // get the active salary period
                DataRow rowActiveSalaryPeriod = PrlSalaryPeriodsDataTable.GetActiveSalaryPeriod();

                // if not setting DateReg and it has not been set yet,
                // insert the last date in the active salaryperiod
                if ((e.Column != DateRegColumn) &&
                    tools.IsNullOrDBNull(e.Row["DateReg"]) &&
                    (rowActiveSalaryPeriod != null))
                {
                    SettingInitialRecordValues = true;
                    _DataWasAutoCalculated = true;
                    e.Row["DateReg"] = tools.object2datetime(rowActiveSalaryPeriod["EndDate"]);
                }

                // if not setting WithdrawType and it has not been set yet,
                // insert the previous record's WithdrawType or
                // if now other records exists, insert default type withdraw (1)
                if ((e.Column != WithdrawTypeColumn) &&
                    tools.IsNullOrDBNull(e.Row["WithdrawType"]))
                {
                    SettingInitialRecordValues = true;
                    _DataWasAutoCalculated = true;
                    if (this.Rows.Count <= 0)
                    {
                        // this is the first row, assume salary withdraw
                        e.Row["WithdrawType"] = 1;
                    }
                    else
                    {
                        // this is not the first row, use previous valid record's withdrawtype
                        int index = this.Rows.Count - 1;
                        while (index >= 0)
                        {
                            DataRow prevRow = this.Rows[index];
                            if ((prevRow.RowState != DataRowState.Deleted) &&
                                (prevRow.RowState != DataRowState.Detached))
                            {
                                e.Row["WithdrawType"] = prevRow["WithdrawType"];
                                index = -1; // stop loop
                            }
                            --index;
                        }
                    }
                }

                SettingInitialRecordValues = false;
                base.OnColumnChanging(e);
            }

            #region CheckRequiredFields
            /// <summary>
            /// Checks if required fields have been filled in the given row.
            /// Returns true if all required fields are filled in, false if not.
            /// </summary>
            /// <returns></returns>
            public static bool CheckRequiredFields(DataRow row)
            {
                if (row == null) return false;
                if (tools.IsNullOrDBNull(row["EmployeeNo"]) ||
                    tools.IsNullOrDBNull(row["WithdrawType"]) ||
                    tools.IsNullOrDBNull(row["Amount"]) ||
                    tools.IsNullOrDBNull(row["DateReg"]))
                    return false; // some required data misssing
                else
                    return true; // all required data present
            }
            #endregion
        }
        #endregion

        #region Partial class PrlEmployeeDataTable
        partial class PrlEmployeeDataTable
        {
            #region IsFunc
            public static bool IsFunc(int EmployeeNo)
            {
                return tools.object2bool(db.ExecuteScalar(string.Format(
                    " select IsFunc from PrlEmployee " +
                    " where EmployeeNo = {0} ", EmployeeNo)));
            }
            #endregion

            #region IsUnder18
            public static bool IsUnder18(int EmployeeNo, DateTime DateToCheck)
            {
                // get string cpr from base
                string sCPR = tools.object2string(db.ExecuteScalar(string.Format(
                    " select CPR from PrlEmployee " +
                    " where (EmployeeNo = {0})",
                    EmployeeNo)));

                // check we have data
                if (sCPR != "")
                {
                    // the string must be 10 digits
                    if (sCPR.Length != 10)
                        return false;

                    DateTime dtCPR = DateTime.MinValue;
                    try
                    {
                        // cpr year only contains 2 digits, so fix to contain 4 digits
                        int year = tools.object2int(sCPR.Substring(4, 2));
                        year += (DateTime.Now.Year - (DateTime.Now.Year % 100));
                        if (year > DateTime.Now.Year)
                            year -= 100;

                        // make a cpr datetime object
                        dtCPR = new DateTime(year,
                            tools.object2int(sCPR.Substring(2, 2)),
                            tools.object2int(sCPR.Substring(0, 2)));

                        // make a date 18 years after cpr
                        DateTime Age18YearsAfter = new DateTime(
                            dtCPR.Year + 18,
                            dtCPR.Month,
                            dtCPR.Day);

                        // check if employee is under 18
                        return (Age18YearsAfter > DateToCheck);
                    }
                    catch
                    {
                        // an error occured
                        return false;
                    }
                }
                else
                {
                    // not enough digits in the string cpr
                    return false;
                }
            }
            #endregion

            #region IsUnderEducation
            public static bool IsUnderEducation(int EmployeeNo)
            {
                return tools.object2bool(db.ExecuteScalar(string.Format(
                    " select Education " +
                    " from PrlEmployee " +
                    " where EmployeeNo = {0} ",
                    EmployeeNo)));
            }
            #endregion

            #region GetFuncHours
            /// <summary>
            /// Returns the employee's FuncHours.
            /// </summary>
            public static double GetFuncHours(int EmployeeNo)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(@"
                    select FuncHours from PrlEmployee 
                    where EmployeeNo = {0}
                    ", EmployeeNo)));
            }
            #endregion

            #region CalcDayHoursFactor
            /// <summary>
            /// Calculates how many hours a func employee has per day.
            /// This is based on: (number of func hours / how many weeks in a month) / 5.
            /// </summary>
            public static double CalcDayHoursFactor(int EmployeeNo)
            {
                double FuncHours = GetFuncHours(EmployeeNo);
                if (FuncHours == 0)
                    FuncHours = db.GetConfigStringAsDouble("FullTimeHours");
                double WeekFactor = db.GetConfigStringAsDouble("WeekFactor");
                return ((FuncHours / WeekFactor) / 5);
            }
            #endregion

            public static DataRow GetActiveEmployee(string CPR)
            {
                return db.GetDataRow(string.Format(@"
                    select * from PrlEmployee
                    where CPR = '{0}'
                    and InactiveDate is null
                    ", CPR.Replace("'", "")));
            }

            public static int GetNumEmployees(string CPR)
            {
                return tools.object2int(db.ExecuteScalar(string.Format(@"
                    select count(*) from PrlEmployee
                    where CPR = {0}
                    ", tools.string4sql(CPR, 20))));
            }

            public static DataRow GetEmployee(int EmployeeNo)
            {
                return db.GetDataRow(string.Format(@"
                    select * from PrlEmployee
                    where EmployeeNo = {0}
                    ", EmployeeNo));
            }

            public static int LentEmployeeNo
            {
                get { return 9999999; }
            }

            /// <summary>
            /// Returns a list with inactive EmployeeNo's
            /// that belongs to the given CPR and that has
            /// salary registrations. The list will
            /// only be filled in if there is at least one
            /// EmployeeNo that is inactive and if there is
            /// an active EmployeeNo.
            /// </summary>
            public static List<int> GetInactiveEmployeeNosWithSalaryRegistrations(string CPR, DataRow SalaryPeriod)
            {
                CPR = CPR.Replace("-", "").Trim();
                DateTime StartDate = tools.object2datetime(SalaryPeriod["StartDate"]).Date;
                DateTime EndDate = tools.object2datetime(SalaryPeriod["EndDate"]).Date;
                List<int> list = new List<int>();

                // there must be an active employeno and
                // and least one inactive employeeno before
                // the list will be filled in
                if (GetNumEmployees(CPR) < 2)
                    return list;
                if (GetActiveEmployee(CPR) == null)
                    return list;

                string sql = string.Format(@"
                    select distinct reg.EmployeeNo from PrlSalaryRegistration reg
                    where reg.RegDateAsDateTime >= {1}
                    and reg.RegDateAsDateTime <= {2}
                    and reg.EmployeeNo in
                    (
                      select distinct emp.EmployeeNo from PrlEmployee emp
                      where emp.CPR = {0}
                      and emp.InactiveDate is not null
                    )
                    ",
                     tools.string4sql(CPR, 20),
                     tools.datetime4sql(StartDate),
                     tools.datetime4sql(EndDate));
                DataTable table = db.GetDataTable(sql);

                // convert the result to a list of integers
                foreach (DataRow row in table.Rows)
                    list.Add(tools.object2int(row["EmployeeNo"]));

                return list;
            }
        }
        #endregion

        #region Partial class PrlSalaryPeriodsDataTable
        partial class PrlSalaryPeriodsDataTable
        {
            /// <summary>
            /// Null is returned if no active period was found.
            /// </summary>
            public static DataRow GetActiveSalaryPeriod()
            {
                return db.GetDataRow(string.Format(
                    " select * from PrlSalaryPeriods " +
                    " where Active = 1 "));
            }

            #region DoesAnActiveSalaryPeriodExistThatIsNotApproved
            /// <summary>
            /// Returns whether an active salary period exist
            /// that is not approved.
            /// </summary>
            public static bool DoesAnActiveSalaryPeriodExistThatIsNotApproved()
            {
                DataRow ActiveSalaryPeriod = Payroll.PrlSalaryPeriodsDataTable.GetActiveSalaryPeriod();
                return ((ActiveSalaryPeriod != null) && (!tools.object2bool(ActiveSalaryPeriod["Approved"])));
            }
            #endregion

            /// <summary>
            /// Returns the salary period which the given date falls within,
            /// that is, the given date has to be greater than or equal to StartDate
            /// and lesser than or equal to EndDate in a salary period.
            /// If no salary period was found or an error occurs, null is returned.
            /// </summary>
            public static DataRow GetSalaryPeriod(DateTime Date)
            {
                return db.GetDataRow(string.Format(
                    " select * from PrlSalaryPeriods " +
                    " where (StartDate <= {0}') " +
                    " and (EndDate >= '{0}') ", Date.Date));
            }

            /// <summary>
            /// Returns the salary period record that has the PeriodYear and Period.
            /// If no salary period was found, null is returned.
            /// </summary>
            public static DataRow GetSalaryPeriod(int PeriodYear, int Period)
            {
                return db.GetDataRow(string.Format(
                    " select * from PrlSalaryPeriods " +
                    " where (PeriodYear = {0}) " +
                    " and (Period = {1}) ",
                    PeriodYear, Period));
            }

            /// <summary>
            /// Returns the currently active salary period as a string.
            /// If no active salary period exist, "" is returned.
            /// </summary>
            public static string GetActiveSalaryPeriodString()
            {
                DataRow row = GetActiveSalaryPeriod();
                if (row != null)
                    return BuildSalaryPeriodString(row);

                return "";
            }

            /* TO BE DELETED
            public static string GetSalaryPeriodStringFunc(int Period, DateTime StartDate, DateTime EndDate)
            {
                return BuildSalaryPeriodString(Period, StartDate, EndDate);
            }
             * */

            /// <summary>
            /// Fills the PeriodString column with data.
            /// </summary>
            public void FillPeriodStringColumn()
            {
                // just making this check to ensure the PeriodString
                // column is not removed from the designer later
                if (this.PeriodStringColumn == null) { }

                foreach (DataRow row in this.Rows)
                {
                    row["PeriodString"] = BuildSalaryPeriodString(row);
                }
            }

            /// <summary>
            /// Sets the given year and period as the active salary period.
            /// You can pass in zeros, but as no periods contain that,
            /// the result will be, that no periods are active.
            /// </summary>
            public static void SetActiveSalaryPeriod(int Year, int Period)
            {
                db.ExecuteNonQuery(" update PrlSalaryPeriods set Active = 0 where (Active = 1) ");
                if ((Year != 0) || (Period != 0))
                {
                    db.ExecuteNonQuery(string.Format(
                        " update PrlSalaryPeriods " +
                        " set Active = 1 " +
                        " where (PeriodYear = {0}) " +
                        " and (Period = {1}) ",
                        Year, Period));
                }
            }

            #region BuildSalaryPeriodString (2 overloads)

            /// <summary>
            /// Internal helper method for this class.
            /// Builds the salary period string from a given
            /// PrlSalaryPeriods row.
            /// </summary>
            private static string BuildSalaryPeriodString(DataRow row)
            {
                int Period = tools.object2int(row["Period"]);
                DateTime StartDate = tools.object2datetime(row["StartDate"]);
                DateTime EndDate = tools.object2datetime(row["EndDate"]);
                return BuildSalaryPeriodString(Period, StartDate, EndDate);
            }

            private static string BuildSalaryPeriodString(int Period, DateTime StartDate, DateTime EndDate)
            {
                string s = Period.ToString("00") + "  " + StartDate.ToString("dddd") + "  " + StartDate.ToString("dd. MMM yyyy") + "  ->  " + EndDate.ToString("dddd") + "  " + EndDate.ToString("dd. MMM yyyy");
                return s;
            }

            #endregion

            public static bool AreAnyPeriodsExportable()
            {
                PayrollTableAdapters.PrlSalaryPeriodsTableAdapter adapter =
                    new RBOS.PayrollTableAdapters.PrlSalaryPeriodsTableAdapter();
                adapter.Connection = db.Connection;
                PrlSalaryPeriodsDataTable table = new PrlSalaryPeriodsDataTable();
                adapter.FillExportable(table);
                return (table.Rows.Count > 0);
            }

            #region SetSalaryPeriodExported (2 overloads)

            public static void SetSalaryPeriodExported(DataRow SalaryPeriod)
            {
                int PeriodYear = tools.object2int(SalaryPeriod["PeriodYear"]);
                int Period = tools.object2int(SalaryPeriod["Period"]);
                SetSalaryPeriodExported(PeriodYear, Period);
            }

            public static void SetSalaryPeriodExported(int PeriodYear, int Period)
            {
                db.ExecuteNonQuery(string.Format(
                    " update PrlSalaryPeriods set" +
                    " Active = 0, " +
                    " Sent = 1 " +
                    " where (PeriodYear = {0}) " +
                    " and (Period = {1}) ",
                    PeriodYear, Period));
            }

            #endregion

            public static void SelectActiveSalaryPeriod(BindingSource BindingSalaryPeriods)
            {
                if (GetActiveSalaryPeriod() != null)
                {
                    // active salary period exists in database,
                    // so attempt to position on in in the list, if found
                    int pos = -1;
                    foreach (DataRowView row in BindingSalaryPeriods)
                    {
                        ++pos;
                        if (tools.object2bool(row["Active"]))
                        {
                            // found active salary period
                            BindingSalaryPeriods.Position = pos;
                            return;
                        }
                    }
                }
                else
                {
                    // an active salary period does not exist,
                    // so position the given bindingsource on
                    // the last approved salary period, if any
                    for (int i = BindingSalaryPeriods.Count - 1; i >= 0; i--)
                    {
                        DataRowView row = (DataRowView)BindingSalaryPeriods[i];
                        if (tools.object2bool(row["Approved"]))
                        {
                            // found last approved salary period
                            BindingSalaryPeriods.Position = i;
                            return;
                        }
                    }
                }
            }

            public static void UpdateSalaryPeriod(
                int PeriodYear, int Period, bool Active, bool Approved, bool Sent)
            {
                db.ExecuteNonQuery(string.Format(@"
                    update PrlSalaryPeriods set
                    Active = {2}, Approved = {3}, Sent = {4}
                    where (PeriodYear = {0})
                    and (Period = {1})
                    ", PeriodYear, Period, Active, Approved, Sent));
            }

            #region GetActiveSalaryPeriodStartDate
            /// <summary>
            /// A shortcut to get the startdate from the active salary period.
            /// Note: Getting the enddate from the active salary period varies
            /// on what you want to do. If you need it for registering on absense,
            /// there is a shortcut method i the PrlAbsenseDataTable class for this
            /// purpose. See this method's documentation for why it is different from
            /// just getting the salary period's enddate when dealing with absense.
            /// </summary>
            /// <returns></returns>
            public static DateTime GetActiveSalaryPeriodStartDate()
            {
                DataRow ActiveSalaryPeriod = GetActiveSalaryPeriod();
                if (ActiveSalaryPeriod != null)
                    return tools.object2datetime(ActiveSalaryPeriod["StartDate"]);
                else
                    return DateTime.MinValue;
            }
            #endregion

        }
        #endregion

        #region Enum BonusCodes
        public enum BonusCodes : int
        {
            None = 0,
            Bonus1010 = 1010, // aften
            Bonus1020 = 1020, // nat
            Bonus1030 = 1030, // lørdag
            Bonus1040 = 1040, // søn- og helligdage
            Bonus1050 = 1050  // søn- og helligdage nat
        }
        #endregion

        #region IsWeekendOrHoliday
        /// <summary>
        /// Checks for saturday or sunday or if the day
        /// is represented in PrlHolidays.
        /// </summary>
        /// <param name="DateAndTime"></param>
        /// <returns></returns>
        public static bool IsWeekendOrHoliday(DateTime DateAndTime)
        {
            return (IsHoliday(DateAndTime) == 1) ||
                (DateAndTime.DayOfWeek == DayOfWeek.Saturday) ||
                (DateAndTime.DayOfWeek == DayOfWeek.Sunday);
        }
        #endregion

        #region Method IsThisDayAHoliday
        /// <summary>
        /// Returns whether the given date and time is a holiday
        /// according to table PrlHolidays.
        /// Static method that only works with on-disk data.
        /// (The reason why wo don't have a class for that table is
        /// that data is only gotten from that table in this method.)
        /// </summary>
        public static int IsHoliday(DateTime DateAndTime)
        {
            // sunday is always considered a holiday
            if (DateAndTime.DayOfWeek == DayOfWeek.Sunday)
                return 1;

            // check PrlHoliday
            //return (tools.object2int(db.ExecuteScalar(string.Format(
            //    " select count(*) from PrlHolidays " +
            //    " where (HolidayDate = '{0}') " +
            //    " and ('{1}' >= FromTime) " +
            //    " and ('{1}' <= ToTime) ",
            //    DateAndTime.Date, DateAndTime.TimeOfDay))) > 0);

            return tools.object2int(db.ExecuteScalar(string.Format(
                " select count(*) from PrlHolidays " +
                " where ((HolidayDate = '{0}') " +
                " and ('{1}' >=  (CONVERT(VARCHAR, FromTime, 108)) ) " +
                " and ('{1}' <= (CONVERT(VARCHAR, ToTime, 108) )) )",
                DateAndTime.Date, DateAndTime.TimeOfDay)));


        }
        #endregion

        #region Method GetBonusCode
        public static int GetBonusCode(DateTime DateAndTime, bool UnderEducation)
        {
            string AgreementCode = db.GetConfigString("AgreementCode");
            int DayNo = tools.DayOfWeek2DayNo(DateAndTime.DayOfWeek);
            int Holiday = IsHoliday(DateAndTime);

            int BonusCode = tools.object2int(db.ExecuteScalar(string.Format(
                " select p1.BonusCode " +
                " from PrlAgreement p1 " +
                " inner join PrlAgreementStatic p2 " +
                " on p1.BonusCode = p2.BonusCode " +
                " where (p1.AgreementCode = '{0}') " + // ex. "HK", "SID", "STD", "CUST"
                " and (Day{1} = 1) " + // ex. 1,2,3,4,5,6,7
                " and ('{2}' >= (CONVERT(VARCHAR, FromTime, 108))) " + // ex. 22:00
                " and ('{2}' <= (CONVERT(VARCHAR, ToTime, 108))) " + // ex. :22:00
                " and (Holiday = {3}) ", // ex. true,
                AgreementCode, DayNo, DateAndTime.TimeOfDay, Holiday)));

            /// Employees that does not have the flag Education set to true
            /// does not get a 1050 bonus, instead they get the 1040 bonus
            if ((!UnderEducation) && (BonusCode == 1050))
                BonusCode = 1040;

            return BonusCode;
        }
        #endregion

        #region GetGLBudgetEmployeeHours
        /// <summary>
        /// Returns the budget employee hours.
        /// This is the GLCode 2000 in table
        /// GLBudget for the given year and month.
        /// </summary>
        public static double GetGLBudgetEmployeeHours(int Year, int Month)
        {
            // return with omvendt fortegn as the volume comes reversed from navision
            return Math.Abs(tools.object2double(db.ExecuteScalar(string.Format(
                " select Volume from GLBudget " +
                " where (BudgetYear = {0}) " +
                " and (BudgetMonth = {1}) " +
                " and (GLCode = '2000') ",
                Year, Month))));
        }
        #endregion

        #region Method PrintEmployeeSalarySum

        /// <summary>
        /// Print employee salary sum on salary period basis.
        /// Remember to call Payroll.PrlSalaryPeriods.FillPeriodStringColumn() first,
        /// so the column SalaryPeriods will be filled in.
        /// </summary>
        public void PrintEmployeeSalarySum(bool Preview, DataRow RowSalaryPeriod)
        {
            string PeriodString = "Lønperiode: " + tools.object2string(RowSalaryPeriod["PeriodString"]);
            DateTime StartDate = tools.object2datetime(RowSalaryPeriod["StartDate"]);
            DateTime EndDate = tools.object2datetime(RowSalaryPeriod["EndDate"]);
            PrintEmployeeSalarySum(Preview, StartDate, EndDate, PeriodString, false);
        }

        /// <summary>
        /// Print employee salary sum on week basis.
        /// </summary>
        public void PrintEmployeeSalarySum(bool Preview, int Week, int Year)
        {
            if ((Week == 0) || (Year == 0)) return;
            DateTime EndDate = tools.GetDateFromISOWeekNumber(Year, Week, DayOfWeek.Sunday);
            DateTime StartDate = EndDate.AddDays(-6);
            string PeriodString = string.Format(
                "Uge: {0}-{1} : {2}..{3}",
                Week, Year,
                StartDate.ToString("dd-MM-yyyy"),
                EndDate.ToString("dd-MM-yyyy"));
            PrintEmployeeSalarySum(Preview, StartDate, EndDate, PeriodString, true);
        }

        /// <summary>
        /// Prints the report for the two forms PrlRptSalarySumFrm and PrlRptSalarySumFrmWk.
        /// This method is private, as the forms will use the two public overloads.
        /// When the WeekInterval is true, some figures will be divided by a week interval factor.
        /// </summary>
        private void PrintEmployeeSalarySum(bool Preview, DateTime StartDate, DateTime EndDate, string PeriodString, bool WeekInterval)
        {
            PrlRptSalarySumRpt Report = new PrlRptSalarySumRpt();
            double WeekFactor = db.GetConfigStringAsDouble("WeekFactor");

            // fill data into Payroll.PrlRptSalarySum_func table
            PayrollTableAdapters.PrlRptSalarySum_funcTableAdapter adapterFunc =
                new RBOS.PayrollTableAdapters.PrlRptSalarySum_funcTableAdapter();
            adapterFunc.Connection = db.Connection;
            adapterFunc.Fill(this.PrlRptSalarySum_func, EndDate, StartDate); // yes, reversed

            bool SubtractAbsenseOnFuncWith0Hours = db.GetConfigStringAsBool("SubtractAbsenseOnFuncWith0Hours");

            // modify some values in Payroll.PrlRptSalarySum_func data
            foreach (DataRow row in this.PrlRptSalarySum_func.Rows)
            {
                double funchours = tools.object2double(row["FuncHours"]);
                int EmployeeNo = tools.object2int(row["EmployeeNo"]);

                // if using weekinterval, divide func hours by week factor
                if (WeekInterval)
                {
                    funchours = funchours / WeekFactor;
                    row["FuncHours"] = funchours;
                }

                // determine if we will subtract absense for this func
                bool SubtractAbsense = false;
                if (funchours > 0)
                    SubtractAbsense = true;
                else if (SubtractAbsenseOnFuncWith0Hours)
                    SubtractAbsense = true;

                if (SubtractAbsense)
                {
                    // if the func employee has absense within the period
                    DateTime AbsenseStart = StartDate;
                    DateTime AbsenseEnd = EndDate;
                    if (!WeekInterval && !db.GetConfigStringAsBool("Payroll.AbsensePrintFollowPayrollPeriod"))
                        tools.GetStartEndDatesInMonth(EndDate, out AbsenseStart, out AbsenseEnd);
                    double absense = PrlAbsenseDataTable.CalculateEmployeeAbsense(EmployeeNo, AbsenseStart, AbsenseEnd);
                    if (absense > 0)
                    {
                        // build absense string
                        row["AbsenseString"] = string.Format(
                            "Normaltimer: {0} - Fravær: {1}",
                            funchours.ToString("n2"),
                            absense.ToString("n2"));

                        // subtract the absense from FuncHours
                        row["FuncHours"] = funchours - absense;
                    }
                }
            }

            // fill data into Payroll.PrlRptSalarySum_reg table,
            // that is, we load salary registrations for the selected salary period
            PayrollTableAdapters.PrlRptSalarySum_regTableAdapter adapterReg =
                new RBOS.PayrollTableAdapters.PrlRptSalarySum_regTableAdapter();
            adapterReg.Connection = db.Connection;
            adapterReg.Fill(this.PrlRptSalarySum_reg, StartDate, EndDate);

            // calculate total hours and total under 18 hours
            double TotalHoursCluster = 0; // the only figure for entire cluster
            double TotalBonus1010Cluster = 0;
            double TotalBonus1020Cluster = 0;
            double TotalBonus1030Cluster = 0;
            double TotalBonus1040Cluster = 0;
            double TotalBonus1050Cluster = 0;
            double TotalOvertimeCluster = 0;
            double TotalTakeTimeOffCluster = 0;
            double TotalLentOutHours = 0;
            double TotalUnder18Hours = 0;
            foreach (DataRow row in this.PrlRptSalarySum_func.Rows)
            {
                // calculate total hours
                TotalHoursCluster += tools.object2double(row["FuncHours"]);
            }
            foreach (DataRow row in this.PrlRptSalarySum_reg.Rows)
            {
                // calculate total hours
                TotalHoursCluster += tools.object2double(row["Hours"]);

                // calculate bonuses and other
                TotalBonus1010Cluster += tools.object2double(row["Bonus1010"]);
                TotalBonus1020Cluster += tools.object2double(row["Bonus1020"]);
                TotalBonus1030Cluster += tools.object2double(row["Bonus1030"]);
                TotalBonus1040Cluster += tools.object2double(row["Bonus1040"]);
                TotalBonus1050Cluster += tools.object2double(row["Bonus1050"]);
                TotalOvertimeCluster += tools.object2double(row["Overtime"]);
                TotalTakeTimeOffCluster += tools.object2double(row["TakeTimeOff"]);

                // sums only done for site
                if (tools.object2string(row["SiteCode"]) == "")
                {
                    /// calculate under 18 hours
                    /// By agreement with AN, we check whether the employee is under 18 at the
                    /// first day of the month (not the salary period). If so, the employee
                    /// gets under 18 hours for the entire salary period.
                    DateTime FirstDayInMonth = new DateTime(EndDate.Year, EndDate.Month, 1);
                    if (Payroll.PrlEmployeeDataTable.IsUnder18(tools.object2int(row["EmployeeNo"]), FirstDayInMonth))
                        TotalUnder18Hours += tools.object2double(row["Hours"]);
                }
                else // sums only done for other sites in cluster
                {
                    // exclude those that have been registered on lent in employee
                    if (tools.object2int(row["EmployeeNo"]) != PrlEmployeeDataTable.LentEmployeeNo)
                        TotalLentOutHours += tools.object2double(row["Hours"]);
                }
            }

            // calculate total hours site
            double TotalHoursSite = TotalHoursCluster - TotalLentOutHours;

            // calculate total under 18 hours percentage
            double TotalUnder18HoursPercentage = ((TotalUnder18Hours / TotalHoursSite) * 100);

            // get budget employee hours
            double TotalBudgetHours = Payroll.GetGLBudgetEmployeeHours(EndDate.Year, EndDate.Month);

            // if using week interval, divide
            // budget hours by week factor
            if ((WeekInterval) && (WeekFactor != 0))
            {
                TotalBudgetHours = TotalBudgetHours / WeekFactor;
            }

            // calculate total diff hours
            double TotalDiffHours = TotalHoursSite - TotalBudgetHours;

            // check we have data
            if ((this.PrlRptSalarySum_func.Rows.Count > 0) ||
                (this.PrlRptSalarySum_reg.Rows.Count > 0))
            {
                // assign data to report
                Report.SetDataSource(this);

                // set report title
                if (WeekInterval)
                    tools.SetReportObjectText(Report, "txtTitle", "Løndata alle medarbejdere, uge");
                else
                {
                    string title = "Løndata alle medarbejdere - " + EndDate.ToString("MMMM");
                    tools.SetReportObjectText(Report, "txtTitle", title);
                }

                // set report site information
                tools.SetReportSiteInformation(Report);

                // set report period string
                tools.SetReportObjectText(Report, "txtSalaryPeriod", PeriodString);

                // set report absense period type
                string txtAbsensePeriodType = "";
                if (WeekInterval)
                    txtAbsensePeriodType = "Ugen";
                else if (db.GetConfigStringAsBool("Payroll.AbsensePrintFollowPayrollPeriod"))
                    txtAbsensePeriodType = "Lønperioden";
                else
                    txtAbsensePeriodType = "Måneden-";
                tools.SetReportObjectText(Report, "txtAbsensePeriod", txtAbsensePeriodType);

                // set report totals
                tools.SetReportObjectText(Report, "txtTotalHoursCluster", TotalHoursCluster.ToString("n2"));
                tools.SetReportObjectText(Report, "txtTotalBonus1010Cluster", (TotalBonus1010Cluster == 0) ? "" : TotalBonus1010Cluster.ToString("n2"));
                tools.SetReportObjectText(Report, "txtTotalBonus1020Cluster", (TotalBonus1020Cluster == 0) ? "" : TotalBonus1020Cluster.ToString("n2"));
                tools.SetReportObjectText(Report, "txtTotalBonus1030Cluster", (TotalBonus1030Cluster == 0) ? "" : TotalBonus1030Cluster.ToString("n2"));
                tools.SetReportObjectText(Report, "txtTotalBonus1040Cluster", (TotalBonus1040Cluster == 0) ? "" : TotalBonus1040Cluster.ToString("n2"));
                tools.SetReportObjectText(Report, "txtTotalBonus1050Cluster", (TotalBonus1050Cluster == 0) ? "" : TotalBonus1050Cluster.ToString("n2"));
                tools.SetReportObjectText(Report, "txtTotalOvertimeCluster", (TotalOvertimeCluster == 0) ? "" : TotalOvertimeCluster.ToString("n2"));
                tools.SetReportObjectText(Report, "txtTotalTakeTimeOffCluster", (TotalTakeTimeOffCluster == 0) ? "" : TotalTakeTimeOffCluster.ToString("n2"));
                tools.SetReportObjectText(Report, "txtTotalLentOutHours", TotalLentOutHours.ToString("n2"));
                tools.SetReportObjectText(Report, "txtTotalHoursSite", TotalHoursSite.ToString("n2"));
                tools.SetReportObjectText(Report, "txtTotalBudgetHours", TotalBudgetHours.ToString("n2"));
                tools.SetReportObjectText(Report, "txtTotalDiffHours", TotalDiffHours.ToString("n2"));
                tools.SetReportObjectText(Report, "txtTotalDiffHours", TotalDiffHours.ToString("n2"));
                tools.SetReportObjectText(Report, "txtTotalUnder18Hours", TotalUnder18Hours.ToString("n2"));
                tools.SetReportObjectText(Report, "txtTotalUnder18HoursPercentage", TotalUnder18HoursPercentage.ToString("n2") + "%");

#if RBA
                // in RBA mode, if Overtime/TakeTimeOff is disabled, don't show
                if (!db.GetConfigStringAsBool("Payroll.TakeTimeOffVisible"))
                    tools.SetReportObjectText(Report, "txtTakeTimeOff", "");
                if (!db.GetConfigStringAsBool("Payroll.OvertimeVisible"))
                    tools.SetReportObjectText(Report, "txtOvertime", "");
#endif

                // print report
                tools.Print(Report, Preview);
            }
            else
            {
                MessageBox.Show(db.GetLangString("Application.NoDataToPrint"));
            }
        }

        #endregion

        #region Partial class PrlSalaryRegistrationDataTable
        partial class PrlSalaryRegistrationDataTable
        {
            #region Migrating
            private bool _Migrating = false;
            public bool Migrating
            {
                set { _Migrating = value; }
            }
            #endregion

            #region OnColumnChanging
            protected override void OnColumnChanging(System.Data.DataColumnChangeEventArgs e)
            {
                // if changing values in columns RegDateAsString, FromTimeAsString and ToTimeAsString
                if ((e.Column == columnRegDateAsString) ||
                    (e.Column == columnFromTimeAsString) ||
                    (e.Column == columnToTimeAsString))
                {
                    /// Now we want to calculate the bonuses for the day
                    /// as changes to the three columns RegDateAsString, FromTimeAsString
                    /// and ToTimeAsString will cause the bonuses to be recalculated.

                    // Get the already existing values from the record.
                    // If a proposed value is present for a given value,
                    // the variable will get the proposed value assigned.
                    DateTime RegDate = tools.object2datetime(e.Row["RegDateAsString"]).Date;
                    TimeSpan FromTime = tools.object2timespan(e.Row["FromTimeAsString"]);
                    TimeSpan ToTime = tools.object2timespan(e.Row["ToTimeAsString"]);

                    // fix FromTime and ToTime proposed values
                    if ((e.Column == columnFromTimeAsString) ||
                        (e.Column == columnToTimeAsString))
                    {
                        string proposedValue = tools.object2string(e.ProposedValue);
                        if (proposedValue != "")
                        {
                            // remove any non-digits
                            string tmpProposedValue = "";
                            string p = "^([0-9])$";
                            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(p);
                            for (int i = 0; i < proposedValue.Length; i++)
                            {
                                if (regex.IsMatch(proposedValue[i].ToString()))
                                    tmpProposedValue += proposedValue[i];
                            }
                            proposedValue = tmpProposedValue;

                            // ensure nn:nn format
                            if (proposedValue.Length == 0)
                                proposedValue = "00:00";
                            else if (proposedValue.Length == 1)
                                proposedValue = "0" + proposedValue + ":00";
                            else if (proposedValue.Length == 2)
                                proposedValue = proposedValue + ":00";
                            else if (proposedValue.Length == 3)
                                proposedValue = "0" + proposedValue.Insert(1, ":");
                            else if (proposedValue.Length == 4)
                                proposedValue = proposedValue.Insert(2, ":");
                            else
                            {
                                proposedValue = proposedValue.Substring(0, 4);
                                proposedValue = proposedValue.Insert(2, ":");
                            }

                            // read out hours and minutes from proposed value
                            string[] sProposedValue = proposedValue.Split(':');
                            int hours = tools.object2int(sProposedValue[0]);
                            int mins = tools.object2int(sProposedValue[1]);

                            // hours above 24 converts to 00
                            if (hours >= 24)
                                hours = 00;

                            // minutes are rounded enforced to quarters
                            if ((mins >= 0) && (mins <= 7)) mins = 0;
                            else if ((mins >= 8) && (mins <= 22)) mins = 15;
                            else if ((mins >= 23) && (mins <= 37)) mins = 30;
                            else mins = 45;

                            // save the time in ensured correct format
                            proposedValue = hours.ToString("00") + ":" + mins.ToString("00");

                            // use the modified proposed value
                            e.ProposedValue = proposedValue;
                        }
                    }

                    // variable used to flag that a proposed
                    // value was actually different from its
                    // already entered counterpart in the record,
                    // thus causing code to recalculate the bonuses.
                    bool DataWasChanged = false;

                    if (e.Column == columnRegDateAsString)
                    {
                        // get active salary period
                        DataRow ActiveSalaryPeriod = PrlSalaryPeriodsDataTable.GetActiveSalaryPeriod();
                        if (ActiveSalaryPeriod != null)
                        {
                            // get the proposed day
                            string proposedDay = tools.object2string(e.ProposedValue);

                            // remove any non-digits
                            string tmpProposedDay = "";
                            string p = "^([0-9])$";
                            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(p);
                            for (int i = 0; i < proposedDay.Length; i++)
                            {
                                if (regex.IsMatch(proposedDay[i].ToString()))
                                    tmpProposedDay += proposedDay[i];
                            }
                            proposedDay = tmpProposedDay;

                            // 0 is not accepted
                            if (proposedDay == "0")
                                proposedDay = "";

                            if (proposedDay != "")
                            {
                                // only have 1 or 2 digits, and after this, we have the day of month
                                if (proposedDay.Length > 2)
                                    proposedDay = proposedDay.Substring(0, 2);

                                // convert proposed day to integer
                                int iProposedDay = tools.object2int(proposedDay);

                                // get the active salary period's startdate and enddate
                                DateTime PeriodStartDate = tools.object2datetime(ActiveSalaryPeriod["StartDate"]).Date;
                                DateTime PeriodEndDate = tools.object2datetime(ActiveSalaryPeriod["EndDate"]).Date;

                                // figure out if we are going to use the first or the second
                                // period date, when creating dates from user's input
                                DateTime DateToUse = PeriodStartDate;
                                if (iProposedDay < PeriodStartDate.Day)
                                    DateToUse = PeriodEndDate;

                                // make sure proposed day is not greater than number of days in month
                                int daysInMonth = DateTime.DaysInMonth(DateToUse.Year, DateToUse.Month);
                                if (iProposedDay > daysInMonth)
                                {
                                    iProposedDay = daysInMonth;
                                    // if someone happens to use the
                                    // proposedDay value later, we assign
                                    // the corrected value to it
                                    proposedDay = iProposedDay.ToString();
                                }

                                // build the proposed regdate as a datetime
                                DateTime dtProposedRegDate = new DateTime(
                                    DateToUse.Year,
                                    DateToUse.Month,
                                    iProposedDay);

                                // use the modified regdate as a string
                                e.ProposedValue = dtProposedRegDate.Date.ToString("d");

                                if (dtProposedRegDate != RegDate)
                                {
                                    // save proposed regdate in variable
                                    // RegDate and flag data was changed
                                    RegDate = dtProposedRegDate;
                                    DataWasChanged = true;

                                    // resolve and save DayNo in record
                                    e.Row["DayNo"] = tools.DayOfWeek2DayNo(RegDate.DayOfWeek);
                                }
                            }
                            else
                            {
                                e.ProposedValue = DBNull.Value;
                                e.Row["DayNo"] = DBNull.Value;
                            }
                        }
                        else
                        {
                            // no active salary period
                            e.ProposedValue = DBNull.Value;
                            e.Row["DayNo"] = DBNull.Value;
                            MessageBox.Show(db.GetLangString("Payroll.NoActiveSalaryPeriod"));
                        }
                    }
                    else if (e.Column == columnFromTimeAsString)
                    {
                        TimeSpan proposedFromTime = tools.object2timespan(e.ProposedValue);
                        if (proposedFromTime != FromTime)
                        {
                            // save proposed fromtime in variable
                            // FromTime and flag data was changed
                            FromTime = proposedFromTime;
                            DataWasChanged = true;
                        }
                    }
                    else if (e.Column == columnToTimeAsString)
                    {
                        TimeSpan proposedToTime = tools.object2timespan(e.ProposedValue);
                        if (proposedToTime != ToTime)
                        {
                            // save proposed totime in variable
                            // ToTime and flag data was changed
                            ToTime = proposedToTime;
                            DataWasChanged = true;
                        }
                    }

                    if (DataWasChanged)
                    {
                        if (e.Column == columnRegDateAsString)
                        {
                            if (tools.object2datetime(e.ProposedValue) != DateTime.MinValue)
                                e.Row["RegDateAsDateTime"] = tools.object2datetime(e.ProposedValue);
                            else
                                e.Row["RegDateAsDateTime"] = DBNull.Value;
                        }
                    }

                    // if some data was changed, perform
                    // calculations if we have enough values
                    if (DataWasChanged &&
                        (RegDate != DateTime.MinValue) &&
                        (FromTime != TimeSpan.MinValue) &&
                        (ToTime != TimeSpan.MinValue))
                    {
                        // variables needed
                        TimeSpan BonusCode1010count = new TimeSpan();
                        TimeSpan BonusCode1020count = new TimeSpan();
                        TimeSpan BonusCode1030count = new TimeSpan();
                        TimeSpan BonusCode1040count = new TimeSpan();
                        TimeSpan BonusCode1050count = new TimeSpan();
                        TimeSpan TimeToAdvance = new TimeSpan(0, 15, 0);

                        /// Build FromDateTime and ToDateTime,
                        /// which are used for looping through times.
                        /// Note that if ToDateTime is smaller than FromDateTime,
                        /// this means that the ToDateTime is in the next day,
                        /// thus we just increment the ToDateTime's day by 1.
                        DateTime FromDateTime = RegDate + FromTime;
                        DateTime ToDateTime = RegDate + ToTime;
                        if (ToTime < FromTime) ToDateTime += (new TimeSpan(1, 0, 0, 0));

                        double TotalHours = 0;
                        int EmployeeNo = tools.object2int(e.Row["EmployeeNo"]);

                        // loop through times from FromDateTime to ToDateTime
                        for (DateTime DateAndTime = FromDateTime; DateAndTime < ToDateTime; DateAndTime += TimeToAdvance)
                        {
                            // resolve which bonus code is applied (if any)
                            bool UnderEducation = PrlEmployeeDataTable.IsUnderEducation(EmployeeNo);
                            int BonusCode = GetBonusCode(DateAndTime, UnderEducation);

                            // add 15 minutes to the found bonus code counter
                            switch (BonusCode)
                            {
                                case (int)BonusCodes.Bonus1010: BonusCode1010count += TimeToAdvance; break;
                                case (int)BonusCodes.Bonus1020: BonusCode1020count += TimeToAdvance; break;
                                case (int)BonusCodes.Bonus1030: BonusCode1030count += TimeToAdvance; break;
                                case (int)BonusCodes.Bonus1040: BonusCode1040count += TimeToAdvance; break;
                                case (int)BonusCodes.Bonus1050: BonusCode1050count += TimeToAdvance; break;
                            }

                            // collect total time in hours
                            TotalHours += TimeToAdvance.TotalHours;
                        }

                        // now the BonusCode<code>count variables contain data, insert this in db
                        e.Row["Bonus1010"] = BonusCode1010count.TotalHours;// BonusCode1010count.Hours.ToString("00") + ":" + BonusCode1010count.Minutes.ToString("00");
                        e.Row["Bonus1020"] = BonusCode1020count.TotalHours;// BonusCode1020count.Hours.ToString("00") + ":" + BonusCode1020count.Minutes.ToString("00");
                        e.Row["Bonus1030"] = BonusCode1030count.TotalHours;// BonusCode1030count.Hours.ToString("00") + ":" + BonusCode1030count.Minutes.ToString("00");
                        e.Row["Bonus1040"] = BonusCode1040count.TotalHours;// BonusCode1040count.Hours.ToString("00") + ":" + BonusCode1040count.Minutes.ToString("00");
                        e.Row["Bonus1050"] = BonusCode1050count.TotalHours;// BonusCode1050count.Hours.ToString("00") + ":" + BonusCode1050count.Minutes.ToString("00");

                        // total hours has been collected, insert this in db
                        e.Row["Hours"] = TotalHours;

                        #region Checking overlap

                        // check if FromDateTime or ToDateTime
                        // exist within an already registered interval
                        bool FoundOverlap = false;
                        // do not check the record itself. also, when migrating or importing
                        // we have loaded data for all employees, so we must check for this.
                        int MyID = tools.object2int(e.Row["ID"]);
                        DataRow[] rows = this.Select(string.Format(@"
                            (ID <> {0}) and (EmployeeNo = {1})
                            ", MyID, EmployeeNo));
                        // we loop instead of using a query, as it is
                        // easier to handle totime which is actually a
                        // time in the next day
                        foreach (DataRow row in rows)
                        {
                            if ((row.RowState != DataRowState.Deleted) &&
                                (row.RowState != DataRowState.Detached))
                            {
                                // get db fromdatetime
                                DateTime dbFromDateTime =
                                    tools.object2datetime(row["RegDateAsString"]) +
                                    tools.object2timespan(row["FromTimeAsString"]);
                                // get db todatetime
                                DateTime dbToDateTime =
                                    tools.object2datetime(row["RegDateAsString"]) +
                                    tools.object2timespan(row["ToTimeAsString"]);
                                // a smaller totime means the next day
                                if (dbToDateTime < dbFromDateTime) dbToDateTime += (new TimeSpan(1, 0, 0, 0));
                                // check if we have an overlap
                                if (!(((FromDateTime <= dbFromDateTime) && (ToDateTime <= dbFromDateTime)) ||
                                      ((FromDateTime >= dbToDateTime) && (ToDateTime >= dbToDateTime))))
                                {
                                    FoundOverlap = true;
                                }
                            }
                        }
                        if (FoundOverlap)
                        {
                            if (!_Migrating)
                                MessageBox.Show(db.GetLangString("Payroll.DateTimeOverlap"));
                            else
                                e.Row["Remarks"] = "Overlap";
                        }

                        #endregion // checking overlap
                    }
                }
                else if ((e.Column == columnOvertime) ||
                         (e.Column == columnTakeTimeOff))
                {
                    double ProposedValue = tools.object2double(e.ProposedValue);
                    if ((ProposedValue < 0) || (ProposedValue > 24))
                    {
                        if (!_Migrating)
                        {
                            MessageBox.Show(db.GetLangString("Payroll.MustBeBetween0And24"));
                            e.ProposedValue = DBNull.Value;
                        }
                    }
                }

                base.OnColumnChanging(e);
            }
            #endregion

            #region CalculateTotals
            /// <summary>
            /// Calculates the various totals for the current set of data,
            /// that is, the data for the currently selected employee in the
            /// active salary period.
            /// A prerequisite for using this method is that any pending edit
            /// data has been posted down to the in-memory dataset with an EndEdit.
            /// </summary>
            /// <returns></returns>
            public DataRow CalculateTotals()
            {
                DataRow newRow = this.NewRow();
                foreach (DataRow row in this.Rows)
                {
                    if ((row.RowState != DataRowState.Deleted) &&
                        (row.RowState != DataRowState.Detached))
                    {
                        newRow["Bonus1010"] = tools.object2double(newRow["Bonus1010"]) + tools.object2double(row["Bonus1010"]);
                        newRow["Bonus1020"] = tools.object2double(newRow["Bonus1020"]) + tools.object2double(row["Bonus1020"]);
                        newRow["Bonus1030"] = tools.object2double(newRow["Bonus1030"]) + tools.object2double(row["Bonus1030"]);
                        newRow["Bonus1040"] = tools.object2double(newRow["Bonus1040"]) + tools.object2double(row["Bonus1040"]);
                        newRow["Bonus1050"] = tools.object2double(newRow["Bonus1050"]) + tools.object2double(row["Bonus1050"]);
                        newRow["Hours"] = tools.object2double(newRow["Hours"]) + tools.object2double(row["Hours"]);
                        newRow["Overtime"] = tools.object2double(newRow["Overtime"]) + tools.object2double(row["Overtime"]);
                        newRow["TakeTimeOff"] = tools.object2double(newRow["TakeTimeOff"]) + tools.object2double(row["TakeTimeOff"]);
                    }
                }
                return newRow;
            }
            #endregion

            #region CalculateTotalHoursAcrossEmployees
            public static double CalculateTotalHoursAcrossEmployees(DateTime StartDate, DateTime EndDate)
            {
                return tools.object2double(db.ExecuteScalar(string.Format(@"
                    select sum(sal.Hours)
                    from (PrlSalaryRegistration sal
                    inner join PrlEmployee emp
                    on sal.EmployeeNo = emp.EmployeeNo)
                    where (sal.RegDateAsDateTime >= '{0}')
                    and (sal.RegDateAsDateTime <= '{1}')
                    ", StartDate.Date, EndDate.Date)));
            }
            #endregion

            public static void DeleteRecords(DataRow SalaryPeriod, int EmployeeNo)
            {
                DateTime StartDate = tools.object2datetime(SalaryPeriod["StartDate"]).Date;
                DateTime EndDate = tools.object2datetime(SalaryPeriod["EndDate"]).Date;
                db.ExecuteNonQuery(string.Format(@"
                    delete from PrlSalaryRegistration
                    where (RegDateAsDateTime >= '{0}')
                    and (RegDateAsDateTime <= '{1}')
                    and (EmployeeNo = {2})
                    ", StartDate.Date, EndDate.Date, EmployeeNo));
            }
            public static void DeleteRecordsPeriod(DataRow SalaryPeriod)
            {
                DateTime StartDate = tools.object2datetime(SalaryPeriod["StartDate"]).Date;
                DateTime EndDate = tools.object2datetime(SalaryPeriod["EndDate"]).Date;
                db.ExecuteNonQuery(string.Format(@"
                    delete from PrlSalaryRegistration
                    where (RegDateAsDateTime >= '{0}')
                    and (RegDateAsDateTime <= '{1}')
                    ", StartDate.Date, EndDate.Date));
            }

        }
        #endregion

        #region Partial class PrlAbsenseDataTable
        partial class PrlAbsenseDataTable
        {
            #region HoursAndDaysLocked
            /// <summary>
            /// Tells if the Hours and Days fields should be locked in the gui on the given row.
            /// </summary>
            public static bool HoursAndDaysLocked(DataRow row)
            {
                // the Hours and Days fields should be locked if
                // they are unequal and non of them are null
                DateTime FromDate = tools.object2datetime(row["FromDateAsDateTime"]);
                DateTime ToDate = tools.object2datetime(row["ToDateAsDateTime"]);
                if ((FromDate != DateTime.MinValue) &&
                    (ToDate != DateTime.MinValue) &&
                    (FromDate != ToDate))
                    return true;
                else
                    return false;
            }
            #endregion

            #region OnColumnChanging
            protected override void OnColumnChanging(System.Data.DataColumnChangeEventArgs e)
            {
                // if changing values in columns FromDateAsString or ToDatAsString
                if ((e.Column == columnFromDateAsString) ||
                    (e.Column == columnToDateAsString))
                {
                    // get active salary period
                    DataRow ActiveSalaryPeriod = PrlSalaryPeriodsDataTable.GetActiveSalaryPeriod();
                    if (ActiveSalaryPeriod != null)
                    {
                        // if not done yet, bind the record to the active salary period 
                        if (tools.IsNullOrDBNull(e.Row[PeriodYearColumn]))
                            e.Row[PeriodYearColumn] = tools.object2int(ActiveSalaryPeriod["PeriodYear"]);
                        if (tools.IsNullOrDBNull(e.Row[PeriodColumn]))
                            e.Row[PeriodColumn] = tools.object2int(ActiveSalaryPeriod["Period"]);

                        // figure out if input is from text field (non-funkionær)
                        // or from datetime picker (funktionær)
                        int EmployeeNo = tools.object2int(e.Row["EmployeeNo"]);
                        bool UsingTextInput = !PrlEmployeeDataTable.IsFunc(EmployeeNo) || db.GetConfigStringAsBool("Payroll.InputFuncAbsenseWithText");

                        // this date will be set to a valid date
                        // in the below if/else statement, or will
                        // be left alone if no valid date could be made
                        DateTime dtProposedDate = DateTime.MinValue;

                        if (UsingTextInput)
                        {
                            // get the proposed day
                            string proposedDay = tools.object2string(e.ProposedValue);

                            // remove any non-digits
                            string tmpProposedDay = "";
                            string p = "^([0-9])$";
                            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(p);
                            for (int i = 0; i < proposedDay.Length; i++)
                            {
                                if (regex.IsMatch(proposedDay[i].ToString()))
                                    tmpProposedDay += proposedDay[i];
                            }
                            proposedDay = tmpProposedDay;

                            // 0 is not accepted
                            if (proposedDay == "0")
                                proposedDay = "";

                            if (proposedDay != "")
                            {
                                // only have 1 or 2 digits, and after this, we have the day of month
                                if (proposedDay.Length > 2)
                                    proposedDay = proposedDay.Substring(0, 2);

                                // convert proposed day to integer
                                int iProposedDay = tools.object2int(proposedDay);

                                // get the active salary period's startdate and enddate
                                DateTime PeriodStartDate = tools.object2datetime(ActiveSalaryPeriod["StartDate"]).Date;
                                DateTime PeriodEndDate = tools.object2datetime(ActiveSalaryPeriod["EndDate"]).Date;

                                // figure out if we are going to use the first or the second
                                // period date, when creating dates from user's input
                                DateTime DateToUse = PeriodStartDate;
                                if (iProposedDay < PeriodStartDate.Day)
                                    DateToUse = PeriodEndDate;

                                // make sure proposed day is not greater than number of days in month
                                int daysInMonth = DateTime.DaysInMonth(DateToUse.Year, DateToUse.Month);
                                if (iProposedDay > daysInMonth)
                                {
                                    iProposedDay = daysInMonth;
                                    // if someone happens to use the
                                    // proposedDay value later, we assign
                                    // the corrected value to it
                                    proposedDay = iProposedDay.ToString();
                                }

                                // build the proposed date as a datetime
                                dtProposedDate = new DateTime(
                                    DateToUse.Year,
                                    DateToUse.Month,
                                    iProposedDay);
                            }
                        }
                        else
                        {
                            // input comes from datetimepicker and should be valid
                            dtProposedDate = tools.object2datetime(e.ProposedValue).Date;

                            // valid period is active salary period's startdate to
                            // the last date in active salary periods enddate month,
                            // in other words, the salary period + 14 days.
                            DateTime StartDate = tools.object2datetime(ActiveSalaryPeriod["StartDate"]).Date;
                            DateTime DummyStartDate, EndDate;
                            tools.GetStartEndDatesInMonth(
                                tools.object2datetime(ActiveSalaryPeriod["EndDate"]).Date,
                                out DummyStartDate,
                                out EndDate);

                            // make sure the proposed date is within the range
                            if (dtProposedDate < StartDate)
                                dtProposedDate = StartDate;
                            else if (dtProposedDate > EndDate)
                                dtProposedDate = EndDate;
                        }

                        // now dtProposedDate is either valid or DateTime.MinValue
                        if (dtProposedDate != DateTime.MinValue)
                        {
                            // assign the modified date to the proposed value
                            e.ProposedValue = dtProposedDate.Date.ToString("d");

                            // get the already existing date
                            DateTime ExistingDate;
                            if (e.Column == columnFromDateAsString)
                                ExistingDate = tools.object2datetime(e.Row["FromDateAsString"]).Date;
                            else
                                ExistingDate = tools.object2datetime(e.Row["ToDateAsString"]).Date;

                            // if data was changed, assign the new value
                            // to the corresponding DateTime field too
                            if (dtProposedDate != ExistingDate)
                            {
                                // make sure that todate is later than or equal to fromdate
                                if (e.Column == columnFromDateAsString)
                                {
                                    if ((!tools.IsNullOrDBNull(e.Row["ToDateAsString"])) &&
                                        (tools.object2datetime(e.Row["ToDateAsString"]) < dtProposedDate))
                                    {
                                        MessageBox.Show(db.GetLangString("Payroll.Absense.FromDateCannotBeAfterToDate"));
                                        // nulling the new value
                                        e.ProposedValue = DBNull.Value;
                                        dtProposedDate = DateTime.MinValue;
                                    }
                                }
                                else
                                {
                                    if ((!tools.IsNullOrDBNull(e.Row["FromDateAsString"])) &&
                                        (tools.object2datetime(e.Row["FromDateAsString"]) > dtProposedDate))
                                    {
                                        MessageBox.Show(db.GetLangString("Payroll.Absense.ToDateCannotBeAfterToDate"));
                                        // nulling the new value
                                        e.ProposedValue = DBNull.Value;
                                        dtProposedDate = DateTime.MinValue;
                                    }
                                }

                                // save the changed date in datetime field too
                                if (e.Column == columnFromDateAsString)
                                {
                                    if (tools.object2datetime(e.ProposedValue) != DateTime.MinValue)
                                        e.Row["FromDateAsDateTime"] = dtProposedDate;
                                    else
                                        e.Row["FromDateAsDateTime"] = DBNull.Value;
                                }
                                else
                                {
                                    if (tools.object2datetime(e.ProposedValue) != DateTime.MinValue)
                                        e.Row["ToDateAsDateTime"] = dtProposedDate;
                                    else
                                        e.Row["ToDateAsDateTime"] = DBNull.Value;
                                }

                                // if setting fromdate, also set todate if it is null
                                if (e.Column == columnFromDateAsString)
                                {
                                    if (tools.IsNullOrDBNull(e.Row["ToDateAsDateTime"]))
                                    {
                                        e.Row["ToDateAsString"] = e.ProposedValue;
                                        e.Row["ToDateAsDateTime"] = tools.object2datetime(e.ProposedValue);
                                    }
                                }

                                // if setting todate, also set fromdate if it is null
                                if (e.Column == columnToDateAsString)
                                {
                                    if (tools.IsNullOrDBNull(e.Row["FromDateAsDateTime"]))
                                    {
                                        e.Row["FromDateAsString"] = e.ProposedValue;
                                        e.Row["FromDateAsDateTime"] = tools.object2datetime(e.ProposedValue);
                                    }
                                }

                                // from now on the datetime versions of the fields can be used
                                DateTime dtFromDate = tools.object2datetime(e.Row["FromDateAsDateTime"]);
                                DateTime dtToDate = tools.object2datetime(e.Row["ToDateAsDateTime"]);

                                // if both dates are null, null both hours and days
                                if ((dtFromDate == DateTime.MinValue) &&
                                    (dtToDate == DateTime.MinValue))
                                {
                                    e.Row["Days"] = DBNull.Value;
                                    e.Row["Hours"] = DBNull.Value;
                                }
                                // if one of the dates are null, null days but leave hours
                                else if ((dtFromDate == DateTime.MinValue) ||
                                         (dtToDate == DateTime.MinValue))
                                {
                                    e.Row["Days"] = DBNull.Value;
                                }
                                // if the two dates are equal, set hours to 0 and days to 1
                                else if (dtFromDate == dtToDate)
                                {
                                    if (tools.IsNullOrDBNull(e.Row["Hours"]))
                                        e.Row["Hours"] = 0;
                                    e.Row["Days"] = 1;
                                }
                                // if the two dates are unequal,
                                // set hours to null and days to num of days,
                                // subtracting saturday,s, sundays and holydays.
                                else
                                {
                                    e.Row["Hours"] = DBNull.Value;

                                    /// Count weekdays and holidays. If there
                                    /// are any weekdays in the interval and there are
                                    /// holidays too, those holidays are ignored and user
                                    /// is informed.
                                    int NumWeekDays = 0;
                                    int NumHolidays = 0;
                                    for (DateTime dt = dtFromDate; dt <= dtToDate; dt = dt.AddDays(1))
                                    {
                                        if (!Payroll.IsWeekendOrHoliday(dt))
                                            ++NumWeekDays;
                                        else
                                            ++NumHolidays;
                                    }
                                    e.Row["Days"] = NumWeekDays > 0 ? NumWeekDays : NumHolidays;
                                    if ((NumWeekDays > 0) && (NumHolidays > 0))
                                    {
                                        string days = NumHolidays > 1 ? db.GetLangString("Payroll.Absense.HolidaysSubtracted.Days") : db.GetLangString("Payroll.Absense.HolidaysSubtracted.Day");
                                        MessageBox.Show(string.Format(db.GetLangString("Payroll.Absense.HolidaysSubtracted"), NumHolidays.ToString() + " " + days));
                                    }
                                }
                            }
                        }
                        else
                        {
                            // proposed date not valid
                            e.ProposedValue = DBNull.Value;
                        }
                    }
                    else
                    {
                        // no active salary period
                        e.ProposedValue = DBNull.Value;
                        MessageBox.Show(db.GetLangString("Payroll.Absense.NoActiveSalaryPeriod"));
                    }
                }
                // if user enters a value in the Hours field
                else if (e.Column == columnHours)
                {
                    // verify propiosed hours value
                    double ProposedValue = tools.object2double(e.ProposedValue);
                    if ((ProposedValue < 0) || (ProposedValue > 24))
                    {
                        MessageBox.Show(db.GetLangString("Payroll.Absense.HoursBetween0And24"));
                        e.ProposedValue = DBNull.Value;
                    }
                    else
                    {
                        // hours value ok

                        // if user has entered a hours value, null days
                        if (ProposedValue != 0)
                        {
                            e.Row["Days"] = DBNull.Value;
                        }
                        else
                        {
                            // reset days and hours if user entered 0 or null hours
                            e.Row["Days"] = 1;
                            if (tools.IsNullOrDBNull(e.ProposedValue))
                                e.Row["Hours"] = 0;
                        }
                    }
                }

                // resolve and save DayNo in record
                if ((e.Column == columnFromDateAsString) ||
                    (e.Column == columnFromDateAsDateTime))
                {
                    DateTime dtProposedValue = tools.object2datetime(e.ProposedValue);
                    if (dtProposedValue != DateTime.MinValue)
                    {
                        int dayno = tools.DayOfWeek2DayNo(dtProposedValue.DayOfWeek);
                        if (dayno != tools.object2int(e.Row["DayNo"]))
                            e.Row["DayNo"] = dayno;
                    }
                    else
                        e.Row["DayNo"] = DBNull.Value;
                }

                base.OnColumnChanging(e);
            }
            #endregion

            #region CalculateEmployeeAbsense
            /// <summary>
            /// Calculates the absense an employee has in a given period.
            /// Absense can be registered as hours on a single day or as a series of days,
            /// or if the employee is func and is not employed in some days.
            /// Calculating the hours on single days within the period is easy.
            /// Calculating the hours on a series of days involves figuring out
            /// which of the days in the registration actually falls within the period
            /// and the multiplying that number of days with a factor to get hours.
            /// The combined hours are returned.
            /// </summary>
            public static double CalculateEmployeeAbsense(int EmployeeNo, DateTime StartDate, DateTime EndDate)
            {
                double absense = 0;

                // calculate any absense HOURS within the period
                DataRow rHours = db.GetDataRow(string.Format(
                    " select sum(Hours) as Absense " +
                    " from PrlAbsense " +
                    " where (EmployeeNo = {0}) " +
                    " and (FromDateAsDateTime >= '{1}') " +
                    " and (ToDateAsDateTime <= '{2}') " +
                    " and (FromDateAsDateTime = ToDateAsDateTime) " +
                    " and (EjRefunderet <> 1) ",
                    EmployeeNo, StartDate.Date, EndDate.Date));
                if ((rHours != null) && (tools.object2double(rHours["Absense"]) != 0))
                    absense += tools.object2double(rHours["Absense"]);

                // get a table with absense DAYS within the period
                // we only look at records where:
                /// - the given employee is the one we handle now
                /// - absense from and to dates are different (across days)
                /// - absense from and to dates are not both outside the selected period
                /// - interval does not have weekdays
                DataTable tableDays = db.GetDataTable(string.Format(
                    " select * from PrlAbsense " +
                    " where (EmployeeNo = {0}) " +
                    " and ((Hours = 0) or (Hours is null)) " + // see note below (*)
                    " and (not((FromDateAsDateTime < '{1}') and (ToDateAsDateTime <'{1}'))) " +
                    " and (not((FromDateAsDateTime > '{2}') and (ToDateAsDateTime > '{2}'))) " +
                    " and (EjRefunderet <> 1) ",
                    EmployeeNo, StartDate, EndDate));
                foreach (DataRow rDays in tableDays.Rows)
                {
                    // some of the registered absense days fall within the
                    // selected period. for each day we add the number of
                    // hours for a day to absense
                    DateTime absenseStartDate = tools.object2datetime(rDays["FromDateAsDateTime"]);
                    DateTime absenseEndDate = tools.object2datetime(rDays["ToDateAsDateTime"]);
                    double NumWeekDays = 0;
                    double NumHolidays = 0;
                    for (DateTime dt = absenseStartDate; dt <= absenseEndDate; dt = dt.AddDays(1))
                    {
                        if ((dt >= StartDate) && (dt <= EndDate))
                        {
                            // this registered absense day falls within the selected period,
                            // so gather both day types (so we can check if there are any weekdays in the interval)
                            if (!Payroll.IsWeekendOrHoliday(dt))
                                NumWeekDays += PrlEmployeeDataTable.CalcDayHoursFactor(EmployeeNo);
                            else
                                NumHolidays += PrlEmployeeDataTable.CalcDayHoursFactor(EmployeeNo);
                        }
                    }
                    // if any weekdays in the interval, ignore holidays
                    absense += NumWeekDays > 0 ? NumWeekDays : NumHolidays;
                }

                /// (*) we do that check as a record with hours entered is already
                /// registered in the previous HOURS check. we cannot check for start/end
                /// dates being different, as a single day without hours entered means 1 day
                /// to be registered in this DAYS check. that's why a simple check for if hours
                /// has been entered is enough for checking if a record needs to be included in
                /// the DAYS check.

                // also calculate amount hours func is not employed in the period...
                // first we get the emplyee's fratrædelsesdato
                if (PrlEmployeeDataTable.IsFunc(EmployeeNo))
                {
                    DataRow empRow = PrlEmployeeDataTable.GetEmployee(EmployeeNo);
                    if (empRow != null)
                    {
                        if (!tools.IsNullOrDBNull(empRow["EndDate"]))
                        {
                            DateTime FratraedelsesDato = tools.object2datetime(empRow["EndDate"]);
                            if ((FratraedelsesDato >= StartDate) && (FratraedelsesDato <= EndDate))
                            {
                                // find out how many weekend days is from the FratraedelsesDato to period EndDate
                                int WeekendDays = 0;
                                for (DateTime dt = FratraedelsesDato; dt <= EndDate; dt = dt.AddDays(1))
                                {
                                    if ((tools.DayOfWeek2DayNo(dt.DayOfWeek) == 6) || (tools.DayOfWeek2DayNo(dt.DayOfWeek) == 7))
                                        ++WeekendDays;
                                }

                                int days = ((TimeSpan)(EndDate - FratraedelsesDato)).Days - WeekendDays;
                                double hours = days * PrlEmployeeDataTable.CalcDayHoursFactor(EmployeeNo);
                                absense += hours;
                            }
                        }

                        if (!tools.IsNullOrDBNull(empRow["StartDate"]))
                        {
                            DateTime TiltraedelsesDato = tools.object2datetime(empRow["StartDate"]);
                            if ((TiltraedelsesDato >= StartDate) && (TiltraedelsesDato <= EndDate))
                            {
                                // find out how many weekend days is from the period StartDate to TiltraedelsesDato
                                int WeekendDays = 0;
                                for (DateTime dt = StartDate; dt <= TiltraedelsesDato; dt = dt.AddDays(1))
                                {
                                    if ((tools.DayOfWeek2DayNo(dt.DayOfWeek) == 6) || (tools.DayOfWeek2DayNo(dt.DayOfWeek) == 7))
                                        ++WeekendDays;
                                }

                                int days = ((TimeSpan)(TiltraedelsesDato - StartDate)).Days - WeekendDays;
                                double hours = days * PrlEmployeeDataTable.CalcDayHoursFactor(EmployeeNo);
                                absense += hours;
                            }
                        }
                    }
                }

                return absense;
            }
            #endregion

            #region GetActiveSalaryPeriodEndDate
            /// <summary>
            /// When dealing with absense, the active salary period's enddate
            /// varies according to if we have a func or not. A func's enddate
            /// is 14 days later that a non-func, thus opening a window of 6 weeks.
            /// </summary>
            public static DateTime GetActiveSalaryPeriodEndDate(bool IsFunc)
            {
                DataRow ActiveSalaryPeriod = PrlSalaryPeriodsDataTable.GetActiveSalaryPeriod();
                if (ActiveSalaryPeriod != null)
                {
                    DateTime EndDate;
                    if (IsFunc)
                    {
                        DateTime tmp;
                        tools.GetStartEndDatesInMonth(
                            tools.object2datetime(ActiveSalaryPeriod["EndDate"]),
                            out tmp, out EndDate);
                    }
                    else
                        EndDate = tools.object2datetime(ActiveSalaryPeriod["EndDate"]);
                    return EndDate;
                }
                else
                    return DateTime.MinValue;
            }
            #endregion
            public static void DeleteRecordsPeriod(DataRow SalaryPeriod)
            {
                DateTime StartDate = tools.object2datetime(SalaryPeriod["StartDate"]).Date;
                DateTime EndDate = tools.object2datetime(SalaryPeriod["EndDate"]).Date;
                db.ExecuteNonQuery(string.Format(@"
                    delete from PrlAbsense
                    where (FromDateAsDateTime >= '{0}')
                    and (FromDateAsDateTime <= '{1}')", StartDate, EndDate));
            }

        }
        #endregion
    }
}
