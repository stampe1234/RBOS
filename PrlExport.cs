using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace RBOS
{
    class PrlExport
    {
        #region GeneratePRLFile
        /// <summary>
        /// Generates the PRL file.
        /// In case of any errors and file was not generated, user is informed and false is returned.
        /// True is returned if no errors occured and file was generated.
        /// </summary>
        public static bool GeneratePRLFile(DataRow SalaryPeriod)
        {
            #region Introductory stuff and file header

            // check input data
            if (SalaryPeriod == null)
                return false;

            // check if payroll module is active
            if (!db.GetConfigStringAsBool("PayrollModuleActive"))
                return false;

            // extract values from salary period record
            int PeriodYear = tools.object2int(SalaryPeriod["PeriodYear"]);
            int Period = tools.object2int(SalaryPeriod["Period"]);
            DateTime StartDate = tools.object2datetime(SalaryPeriod["StartDate"]).Date;
            DateTime EndDate = tools.object2datetime(SalaryPeriod["EndDate"]).Date;

            // build path
            string path = string.Format("{0}\\{1}_{2}{3}.PRL",
                db.GetConfigString("DRS_FTP_client_depart_dir"),
                GetSiteCodeFormatted(),
                PeriodYear.ToString().PadLeft(4, '0'),
                Period.ToString().PadLeft(2, '0')).Replace("\\\\", "\\");

            // check if file already exists
            if (File.Exists(path))
            {
                // check if user wants to overwrite file or abort file generation
                string msg = db.GetLangString("ExportPayroll.OverwriteAlreadyExistingExportFile");
                if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return false; // abort file generation
            }

            // open file
            StreamWriter file = new StreamWriter(path, false, tools.Encoding());

            // write file header
            int lineno = 1;
            string header =
                "1000" +
                GetSiteCodeFormatted() +
                FormatDate(StartDate) +
                FormatDate(EndDate) +
                FormatDate(DateTime.Now) +
                FormatString(Version.ExeVersion, 12, Padding.PrependedZeros) +
                (tools.object2bool(db.GetConfigString("Payroll.ExportFileEncrypted")) ? "E" : "N");
            file.WriteLine(header);

            #endregion

            // export data
            Write1010(StartDate, EndDate, file, ref lineno, header);
            Write1020(PeriodYear, Period, file, ref lineno, header);
            Write1030(StartDate, EndDate, file, ref lineno, header);
            Write1040(EndDate, file, ref lineno, header);
            Write1050(EndDate, file, ref lineno, header);

            // close file
            file.Close();

            // set a mark in config what was exported and when
            db.SetConfigString ("Payroll.ExportFileCreated.Timestamp", DateTime.Now);
            db.SetConfigString("Payroll.ExportFileCreated.Period", Period);
            db.SetConfigString("Payroll.ExportFileCreated.PeriodYear", PeriodYear);

            // file was generated
            return true;
        }
        #endregion

        #region Write1010 (lønregistreringer summeret)
        private static void Write1010(DateTime StartDate, DateTime EndDate, StreamWriter file, ref int lineno, string header)
        {
            // get a list of (ikke indlånte) employees and traverse the data
            DataTable table = db.GetDataTable(string.Format(@"
                select EmployeeNo, Education
                from PrlEmployee
                where EmployeeNo <> {0}
                order by EmployeeNo
                ", Payroll.PrlEmployeeDataTable.LentEmployeeNo));
            foreach (DataRow row in table.Rows)
            {
                // extract values from employee row
                int EmployeeNo = tools.object2int(row["EmployeeNo"]);
                bool Education = tools.object2bool(row["Education"]);

                // load data into the Payroll.PrlSalaryRegistration
                // datatable, as it has a method for calculating totals
                Payroll.PrlSalaryRegistrationDataTable salTable =
                    new Payroll.PrlSalaryRegistrationDataTable();
                PayrollTableAdapters.PrlSalaryRegistrationTableAdapter salAdapter =
                    new RBOS.PayrollTableAdapters.PrlSalaryRegistrationTableAdapter();
                salAdapter.Connection = db.Connection;
                salAdapter.Fill(salTable, StartDate.Date, EndDate.Date, EmployeeNo);

                // calculate the totals for this employee
                DataRow rowTotals = salTable.CalculateTotals();

                double Sum = 0;

                // output hours
                Sum = tools.object2double(rowTotals["Hours"]);
                if (Sum != 0)
                {
                    file.Write("1010"); // this not the 1010 rbos code
                    file.WriteLine(Encrypt(
                        FormatEmployeeNo(EmployeeNo) +
                        FormatPayCode(3000) +
                        FormatNumberOf(Sum),
                        ++lineno, header));
                }

                // output aftentillæg
                Sum = tools.object2double(rowTotals["Bonus1010"]);
                if (Sum != 0)
                {
                    file.Write("1010"); // this not the 1010 rbos code
                    file.WriteLine(Encrypt(
                        FormatEmployeeNo(EmployeeNo) +
                        FormatPayCode(Education ? 3105 : 3101) +
                        FormatNumberOf(Sum),
                        ++lineno, header));
                }

                // output nattillæg
                Sum = tools.object2double(rowTotals["Bonus1020"]);
                if (Sum != 0)
                {
                    file.Write("1010"); // this not the 1010 rbos code
                    file.WriteLine(Encrypt(
                        FormatEmployeeNo(EmployeeNo) +
                        FormatPayCode(Education ? 3106 : 3102) +
                        FormatNumberOf(Sum),
                        ++lineno, header));
                }

                // output lørdagstillæg
                Sum = tools.object2double(rowTotals["Bonus1030"]);
                if (Sum != 0)
                {
                    file.Write("1010"); // this not the 1010 rbos code
                    file.WriteLine(Encrypt(
                        FormatEmployeeNo(EmployeeNo) +
                        FormatPayCode(Education ? 3107 : 3103) +
                        FormatNumberOf(Sum),
                        ++lineno, header));
                }

                // output søn- og helligdagstillæg
                Sum = tools.object2double(rowTotals["Bonus1040"]);
                if (Sum != 0)
                {
                    file.Write("1010"); // this not the 1010 rbos code
                    file.WriteLine(Encrypt(
                        FormatEmployeeNo(EmployeeNo) +
                        FormatPayCode(Education ? 3108 : 3104) +
                        FormatNumberOf(Sum),
                        ++lineno, header));
                }

                // output søn- og helligdag nat tillæg
                Sum = tools.object2double(rowTotals["Bonus1050"]);
                if (Sum != 0)
                {
                    file.Write("1010"); // this not the 1010 rbos code
                    file.WriteLine(Encrypt(
                        FormatEmployeeNo(EmployeeNo) +
                        FormatPayCode(3109) + // only education
                        FormatNumberOf(Sum),
                        ++lineno, header));
                }

                // output overtime
                Sum = tools.object2double(rowTotals["Overtime"]);
                if (Sum != 0)
                {
                    file.Write("1010"); // this not the 1010 rbos code
                    file.WriteLine(Encrypt(
                        FormatEmployeeNo(EmployeeNo) +
                        FormatPayCode(Education ? 3165 : 3160) +
                        FormatNumberOf(Sum),
                        ++lineno, header));
                }

                // output taketimeoff
                Sum = tools.object2double(rowTotals["TakeTimeOff"]);
                if (Sum != 0)
                {
                    file.Write("1010"); // this not the 1010 rbos code
                    file.WriteLine(Encrypt(
                        FormatEmployeeNo(EmployeeNo) +
                        FormatPayCode(Education ? 3166 : 3161) +
                        FormatNumberOf(Sum),
                        ++lineno, header));
                }
            } // foreach
        }
        #endregion

        #region Write1020 (fraværsregistreringer)
        private static void Write1020(int PeriodYear, int Period, StreamWriter file, ref int lineno, string header)
        {
            /// Note: selvom man i brugergrænsefladen kan se og registrere 1½ måned
            /// ad gangen for funktionærer, exporterer vi samme interval som for ikke-funktionærer,
            /// dvs. vi følger lønperioden.

            // get a list of employees and traverse data
            DataTable tableEmp = db.GetDataTable(
                " select EmployeeNo, Education, IsFunc " +
                " from PrlEmployee " +
                " order by EmployeeNo ");
            foreach (DataRow rowEmp in tableEmp.Rows)
            {
                int EmployeeNo = tools.object2int(rowEmp["EmployeeNo"]);

                // get a list of absense registrations and traverse the data
                DataTable table = db.GetDataTable(string.Format(
                    " select EmployeeNo, Days, Hours, AbsenseCode, FromDateAsDateTime, ToDateAsDateTime " +
                    " from PrlAbsense " +
                    " where (EmployeeNo = {0}) " +
                    " and (PeriodYear = {1}) " +
                    " and (Period = {2}) " +
                    " order by EmployeeNo, FromDateAsDateTime, ToDateAsDateTime ",
                    EmployeeNo, PeriodYear, Period));
                foreach (DataRow row in table.Rows)
                {
                    // detect days/hours registration and get numberof
                    string HoursRegistered = "0";
                    double NumberOf = tools.object2double(row["Days"]);
                    if (tools.object2double(row["Hours"]) != 0)
                    {
                        HoursRegistered = "1";
                        NumberOf = tools.object2double(row["Hours"]);
                    }

                    file.Write("1020");
                    file.WriteLine(Encrypt(
                        FormatEmployeeNo(row["EmployeeNo"]) +
                        FormatPayCode(row["AbsenseCode"]) +
                        FormatDate(tools.object2datetime(row["FromDateAsDateTime"])) +
                        FormatDate(tools.object2datetime(row["ToDateAsDateTime"])) +
                        FormatNumberOf(NumberOf) +
                        HoursRegistered,
                        ++lineno, header));
                }
            }
        }
        #endregion

        #region Write1030 (udlånt personale)
        private static void Write1030(DateTime StartDate, DateTime EndDate, StreamWriter file, ref int lineno, string header)
        {
            #region SQL1030
            string SQL1030 = string.Format(@"
select
  sal.SiteCode,
  sum(sal.Hours) as HoursSum,
  sum(sal.Bonus1010) as Bonus1010Sum,
  sum(sal.Bonus1020) as Bonus1020Sum,
  sum(sal.Bonus1030) as Bonus1030Sum,
  sum(sal.Bonus1040) as Bonus1040Sum,
  sum(sal.Bonus1050) as Bonus1050Sum,
  sum(sal.Overtime) as OvertimeSum,
  sum(sal.TakeTimeOff) as TakeTimeOffSum
from PrlSalaryRegistration sal
inner join PrlEmployee emp
on sal.EmployeeNo = emp.EmployeeNo
where ((sal.SiteCode is not null)
and (sal.SiteCode <> ''))
and (sal.RegDateAsDateTime >= '{0}')
and (sal.RegDateAsDateTime <= '{1}')
and (sal.EmployeeNo <> {2})
group by sal.SiteCode
order by sal.SiteCode
", StartDate.Date, EndDate.Date, Payroll.PrlEmployeeDataTable.LentEmployeeNo);
            #endregion

            // get the salary registrations on other stations and traverse data
            DataTable table = db.GetDataTable(SQL1030);
            foreach (DataRow row in table.Rows)
            {
                // write hours
                if (tools.object2double(row["HoursSum"]) != 0)
                {
                    file.Write("1030");
                    file.WriteLine(Encrypt(
                        FormatSiteNo(row["SiteCode"]) +
                        FormatPayCode(3100) +
                        FormatNumberOf(row["HoursSum"]),
                        ++lineno, header));
                }

                // write aftentillæg
                if (tools.object2double(row["Bonus1010Sum"]) != 0)
                {
                    file.Write("1030");
                    file.WriteLine(Encrypt(
                        FormatSiteNo(row["SiteCode"]) +
                        FormatPayCode(3101) +
                        FormatNumberOf(row["Bonus1010Sum"]),
                        ++lineno, header));
                }

                // write nattillæg
                if (tools.object2double(row["Bonus1020Sum"]) != 0)
                {
                    file.Write("1030");
                    file.WriteLine(Encrypt(
                        FormatSiteNo(row["SiteCode"]) +
                        FormatPayCode(3102) +
                        FormatNumberOf(row["Bonus1020Sum"]),
                        ++lineno, header));
                }

                // write lørdagstillæg
                if (tools.object2double(row["Bonus1030Sum"]) != 0)
                {
                    file.Write("1030");
                    file.WriteLine(Encrypt(
                        FormatSiteNo(row["SiteCode"]) +
                        FormatPayCode(3103) +
                        FormatNumberOf(row["Bonus1030Sum"]),
                        ++lineno, header));
                }

                // write søn/hellig tillæg
                if (tools.object2double(row["Bonus1040Sum"]) != 0)
                {
                    file.Write("1030");
                    file.WriteLine(Encrypt(
                        FormatSiteNo(row["SiteCode"]) +
                        FormatPayCode(3104) +
                        FormatNumberOf(row["Bonus1040Sum"]),
                        ++lineno, header));
                }

                // write søn/hellig nat tillæg
                if (tools.object2double(row["Bonus1050Sum"]) != 0)
                {
                    file.Write("1030");
                    file.WriteLine(Encrypt(
                        FormatSiteNo(row["SiteCode"]) +
                        FormatPayCode(3109) +
                        FormatNumberOf(row["Bonus1050Sum"]),
                        ++lineno, header));
                }

                // write overtime
                if (tools.object2double(row["OvertimeSum"]) != 0)
                {
                    file.Write("1030");
                    file.WriteLine(Encrypt(
                        FormatSiteNo(row["SiteCode"]) +
                        FormatPayCode(3160) +
                        FormatNumberOf(row["OvertimeSum"]),
                        ++lineno, header));
                }

                // write taketimeoff
                if (tools.object2double(row["TakeTimeOffSum"]) != 0)
                {
                    file.Write("1030");
                    file.WriteLine(Encrypt(
                        FormatSiteNo(row["SiteCode"]) +
                        FormatPayCode(3161) +
                        FormatNumberOf(row["TakeTimeOffSum"]),
                        ++lineno, header));
                }
            }
        }
        #endregion

        #region Write1040 (benzinkøb)
        private static void Write1040(DateTime EndDate, StreamWriter file, ref int lineno, string header)
        {
            DateTime StartDateToUse, EndDateToUse;
            tools.GetStartEndDatesInMonth(EndDate, out StartDateToUse, out EndDateToUse);

            DataTable table = db.GetDataTable(string.Format(
                " select w.EmployeeNo, sum(w.Amount) as AmountSum " +
                " from PrlWithdraw w " +
                " inner join PrlEmployee e " +
                " on w.EmployeeNo = e.EmployeeNo " +
                " where (w.WithdrawType = 2) " +
                " and (w.DateReg >= '{0}') " +
                " and (w.DateReg <= '{1}') " +
                " group by w.EmployeeNo " +
                " order by w.EmployeeNo ",
                StartDateToUse.Date, EndDateToUse.Date));

            foreach (DataRow row in table.Rows)
            {
                file.Write("1040");
                file.WriteLine(Encrypt(
                    FormatEmployeeNo(row["EmployeeNo"]) +
                    FormatAmount(row["AmountSum"]),
                    ++lineno, header));
            }
        }
        #endregion

        #region Write1050 (løntræk)
        private static void Write1050(DateTime EndDate, StreamWriter file, ref int lineno, string header)
        {
            DateTime StartDateToUse, EndDateToUse;
            tools.GetStartEndDatesInMonth(EndDate, out StartDateToUse, out EndDateToUse);

            DataTable table = db.GetDataTable(string.Format(
                " select w.EmployeeNo, sum(w.Amount) as AmountSum " +
                " from PrlWithdraw w " +
                " inner join PrlEmployee e " +
                " on w.EmployeeNo = e.EmployeeNo " +
                " where (w.WithdrawType = 1) " +
                " and (w.DateReg >= '{0}') " +
                " and (w.DateReg <= '{1}') " +
                " group by w.EmployeeNo " +
                " order by w.EmployeeNo ",
                StartDateToUse.Date, EndDateToUse.Date));

            foreach (DataRow row in table.Rows)
            {
                file.Write("1050");
                file.WriteLine(Encrypt(
                    FormatEmployeeNo(row["EmployeeNo"]) +
                    FormatAmount(row["AmountSum"]),
                    ++lineno, header));
            }
        }
        #endregion

        #region GetSiteCodeFormatted
        private static string GetSiteCodeFormatted()
        {
            return AdminDataSet.SiteInformationDataTable.GetSiteCode().PadLeft(4, '0');
        }
        #endregion

        #region FormatAmount
        private static string FormatAmount(object o)
        {
            double dAmount = tools.object2double(o);
            string sAmount = (dAmount * 100).ToString("00000000000");
            if (dAmount >= 0) sAmount = "+" + sAmount;
            return sAmount;
        }
        #endregion

        #region FormatNumberOf
        private static string FormatNumberOf(object o)
        {
            double dNumberOf = tools.object2double(o);
            string sNumberOf = (dNumberOf * 100).ToString("000000000");
            if (dNumberOf >= 0) sNumberOf = "+" + sNumberOf;
            return sNumberOf;
        }
        #endregion

        #region FormatString
        private enum Padding { PrependedZeros, AppendedBlanks }
        private static string FormatString(object o, int length, Padding padding)
        {
            string s = tools.object2string(o);
            if (s.Length > length)
                s = s.Remove(length);
            if (padding == Padding.PrependedZeros)
                return s.PadLeft(length, '0');
            else // padding == StringPadding.AppendedBlanks
                return s.PadRight(length, ' ');
        }
        #endregion

        #region FormatEmployeeNo
        private static string FormatEmployeeNo(object o)
        {
            return tools.object2int(o).ToString("0000000");
        }
        #endregion

        #region FormatNumberID
        private static string FormatNumberID(object o)
        {
            return tools.object2int(o).ToString("0000000000");
        }
        #endregion

        #region FormatSiteNo
        private static string FormatSiteNo(object o)
        {
            return tools.object2string(o).PadLeft(4,'0');
        }
        #endregion

        #region FormatDate
        private static string FormatDate(DateTime datetime)
        {
            return datetime.ToString("yyyyMMdd");
        }
        #endregion

        #region FormatPayCode
        private static string FormatPayCode(object o)
        {
            return tools.object2int(o).ToString().PadLeft(4, '0');
        }
        #endregion

        #region Encrypt
        private static string Encrypt(string s, int lineno, string header)
        {
            if (db.GetConfigStringAsBool("Payroll.ExportFileEncrypted"))
                return EncryptionAccounting.EncryptString(s, lineno, header);
            else
                return s;
        }
        #endregion
    }
}
