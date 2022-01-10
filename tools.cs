using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Data.OleDb;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Collections.Generic;
using System.Xml;
using CrystalDecisions.CrystalReports.Engine;
using GenericParsing;
using Neodynamic.WinControls.BarcodeProfessional;

namespace RBOS
{
	public class tools
    {
        #region CmdArgs
        private static Dictionary<string, string> _CmdArgs = new Dictionary<string, string>();
        public static void SetCmdArgs(string[] CmdArgs)
        {
            foreach (string s in CmdArgs)
            {
                string[] splitted = s.Split('=');
                if (splitted.Length == 2)
                {
                    string key = splitted[0];
                    string val = splitted[1];
                    _CmdArgs.Add(key, val);
                }
            }
        }
        public static string GetCmdArg(string key)
        {
            if (_CmdArgs.ContainsKey(key))
                return _CmdArgs[key];
            else
                return "";
        }
        #endregion

        #region Constructor
        // constructor made protected, so nobody
		// can create an instance of the class (Singleton Pattern)
		private tools()
		{
        }
        #endregion

        #region RadiantXmlDateAndTime2DateTime
        /// <summary>
        /// Takes a yyyy-MM-dd HH:mm:ss date and coverts to a DateTime.
        /// If any failure occures, DateTime.MinValue is returned.
        /// </summary>
        public static DateTime RadiantXmlDateAndTime2DateTime(string xmlDate, string xmlTime)
        {
            try
            {
                string[] dateSplitted = xmlDate.Split('-');
                int year = int.Parse(dateSplitted[0]);
                int month = int.Parse(dateSplitted[1]);
                int day = int.Parse(dateSplitted[2]);

                string[] timeSplitted = xmlTime.Split(':');
                int hour = int.Parse(timeSplitted[0]);
                int min = int.Parse(timeSplitted[1]);
                int sec = int.Parse(timeSplitted[2]);

                return new DateTime(year, month, day, hour, min, sec);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
        #endregion

        #region RadiantXmlDateTime2DateTime
        /// <summary>
        /// Takes a yyyy-MM-ddTHH:mm:ss or a yyyy-MM-dd HH:mm:ss date and coverts to a DateTime.
        /// If any failure occures, DateTime.MinValue is returned.
        /// </summary>
        public static DateTime RadiantXmlDateTime2DateTime(string xmlDateTime)
        {
            try
            {
                // attempt to split by 'T' then by ' '
                string[] dateSplitted;
                if (xmlDateTime.Contains("T"))
                    dateSplitted = xmlDateTime.Split('T');
                else
                    dateSplitted = xmlDateTime.Split(' ');
                return RadiantXmlDateAndTime2DateTime(dateSplitted[0], dateSplitted[1]);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
        #endregion

        #region RadiantDate2DateTime
        /// <summary>
        /// Takes a yyyy-MM-dd date and converts it to a DateTime.
        /// If any failure occures, DateTime.MinValue is returned.
        /// </summary>
        public static DateTime RadiantDate2DateTime(string xmlDate)
        {
            return RadiantXmlDateAndTime2DateTime(xmlDate, "00:00:00");
        }
        #endregion

        #region USStringNumberToFloat
        /// <summary>
        /// Parses the string as a float, and if the decimal seperator is
        /// a "." it will be converted to the locale decimal seperator before parsing.
        /// </summary>
        public static float USStringNumberToFloat(string val)
        {
            return float.Parse(val.Replace(".", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
        }
        #endregion

        #region USStringNumberToDouble
        /// <summary>
        /// Parses the string as a double, and if the decimal seperator is
        /// a "." it will be converted to the locale decimal seperator before parsing.
        /// </summary>
        public static double USStringNumberToDouble(string val)
        {
            return double.Parse(val.Replace(".", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
        }
        #endregion

        #region RadiantXmlFilename2DateTime
        /// <summary>
        /// Converts a Radiant XML filename to a DateTime.
        /// </summary>
        /// <param name="XmlFilename">
        /// Radiant XML filename with naming format NNNvvvyyyyMMddHHmmss.XML
        /// with version included or NNNyyyyMMddHHmmss.XML with no version included.
        /// Note that prepeneded directory is ignored,
        /// for instance c:\\testdir\\NNNvvvyyyyMMddHHmmss.XML. It still works.
        /// </param>
        /// <returns>The parsed DateTime object or DateTime.MinValue if error occured.</returns>
        public static DateTime RadiantXmlFilename2DateTime(string XmlFilename)
        {
            try
            {
                int startIndex = XmlFilename.Length - 18;
                int length = 14;
                string sDateTime = XmlFilename.Substring(startIndex, length);
                int year = tools.object2int(sDateTime.Substring(0, 4));
                int month = tools.object2int(sDateTime.Substring(4, 2));
                int day = tools.object2int(sDateTime.Substring(6, 2));
                int hours = tools.object2int(sDateTime.Substring(8, 2));
                int minutes = tools.object2int(sDateTime.Substring(10, 2));
                int seconds = tools.object2int(sDateTime.Substring(12, 2));
                return new DateTime(year, month, day, hours, minutes, seconds);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
        #endregion

        #region object2bool
        /// <summary>
        /// Anything that does not evaluate to
        /// true is returned as false.
        /// </summary>
        public static bool object2bool(object o)
        {
            if ((o == null) || (o == DBNull.Value))
                return false;
            else if (o is bool)
                return (bool)o;
            else if (o is string)
            {
                string s = o.ToString().ToLower().Trim();
                return
                    ((s == "true") || (s == "yes") || (s == "1") ||
                    (s == "ja") || (s == "sand") || (s == "on"));
            }
            else
            {
                try { return bool.Parse(o.ToString()); }
                catch { }
            }
            return false;
        }
        #endregion

        #region object2double
        /// <summary>
        /// Checks if o is a double.
        /// If so, the double value is returned.
        /// If not, 0 is returned.
        /// The double can have decimal seperator as "." or ","
        /// and cannot have a thousand seperator.
        /// </summary>
        public static double object2double(object o)
        {
            if ((o == null) || (o == DBNull.Value))
                return 0;
            else if (o is double)
                return (double)o;
            else if (o is float)
                return (float)o;
            else if (o is string)
            {
                try
                {
                    string s = o.ToString();
                    string decSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                    if (s.Contains(",") && s.Contains("."))
                    {
                        // convert US number format 10,000.50 to 10000,50
                        if (s.IndexOf(",") < s.IndexOf("."))
                        {
                            s = s.Replace(",", "");
                            s = s.Replace(".", decSeparator);
                        }
                        // convert number format 10.000,50 to 10000,50
                        else
                        {
                            s = s.Replace(".", "");
                            s = s.Replace(",", decSeparator);
                        }
                    }
                    else if (s.Contains(","))
                        s = s.Replace(",", decSeparator);
                    else if (s.Contains("."))
                        s = s.Replace(".", decSeparator);

                    // parse number of format 10000,50
                    return double.Parse(s);
                }
                catch { }
            }
            else
            {
                try { return double.Parse(o.ToString()); }
                catch { }

                /*try { return USStringNumberToDouble(o.ToString()); }
                catch { }*/
            }
            return 0;
        }
        #endregion

        #region object2int
        /// <summary>
        /// Checks if o is a int.
        /// If so, the int value is returned.
        /// If not, 0 is returned.
        /// </summary>
        public static int object2int(object o)
        {
            if ((o == null) || (o == DBNull.Value))
                return 0;
            else if (o is int)
                return (int)o;
            else if (o is float)
            {
                try { return (int)((float)o); }
                catch { }
            }
            else if (o is double)
            {
                try { return (int)((double)o); }
                catch { }
            }
            else
            {
                try { return int.Parse(o.ToString()); }
                catch { }
            }
            return 0;
        }
        #endregion

        #region object2long
        /// <summary>
        /// Checks if o is a long.
        /// If so, the long value is returned.
        /// If not, 0 is returned.
        /// </summary>
        public static long object2long(object o)
        {
            if ((o == null) || (o == DBNull.Value))
                return 0;
            else if (o is long)
                return (long)o;
            else if (o is float)
            {
                try { return (long)((float)o); }
                catch { }
            }
            else if (o is double)
            {
                try { return (long)((double)o); }
                catch { }
            }
            else
            {
                try { return long.Parse(o.ToString()); }
                catch { }
            }
            return 0;
        }
        #endregion

        #region object2byte
        /// <summary>
        /// Checks if o is a byte.
        /// If so, the byte value is returned.
        /// If not, 0 is returned.
        /// </summary>
        public static byte object2byte(object o)
        {
            if ((o == null) || (o == DBNull.Value))
                return 0;
            else if (o is byte)
                return (byte)o;
            else if (o is float)
            {
                try { return (byte)((float)o); }
                catch { }
            }
            else if (o is double)
            {
                try { return (byte)((double)o); }
                catch { }
            }
            else
            {
                try { return byte.Parse(o.ToString()); }
                catch { }
            }
            return 0;
        }
        #endregion

        #region object2string
        /// <summary>
        /// Casts the object to a string.
        /// If the object null, the string returned is "".
        /// </summary>
        public static string object2string(object o)
        {
            if ((o == null) || (o == DBNull.Value)) return "";
            else return o.ToString();
        }
        #endregion

        #region object2char
        /// <summary>
        /// Tries to convert the object to a char.
        /// If any failure, the value (char)0 is returned.
        /// </summary>
        public static char object2char(object o)
        {
            if ((o == null) || (o == DBNull.Value))
                return (char)0;
            else if (o is char)
                return (char)o;
            else
            {
                try { return char.Parse(o.ToString()); }
                catch { }
            }
            return (char)0;
        }
        #endregion

        #region object2datetime
        /// <summary>
        /// Tries to convert the object to a DateTime.
        /// If any failure, the value DateTime.MinValue is returned.
        /// </summary>
        public static DateTime object2datetime(object o)
        {
            if ((o == null) || (o == DBNull.Value))
                return DateTime.MinValue;
            else
            {
                try { return DateTime.Parse(o.ToString()); }
                catch
                {
                    try
                    {
                        // maybe date is in format yyyyMMdd (and not yyyy-MM-dd)
                        string s = o.ToString();
                        if (s.Length == 8)
                        {
                            s = s.Insert(4, "-").Insert(7, "-");
                            return DateTime.Parse(s);
                        }
                        else if (s.Length == 14)
                        {
                            Regex regex = new Regex(@"\b[0-9]{14}\b");
                            if (regex.IsMatch(s))                             
                            {
                                // assuming the format is yyyyMMddHHmmss so convert that to yyyy-MM-dd HH:mm:ss
                                s = s.Insert(4, "-").Insert(7, "-").Insert(10, " ").Insert(13, ":").Insert(16, ":");
                                return DateTime.Parse(s);
                            }
                        }
                    }
                    catch { }
                }
            }
            return DateTime.MinValue;
        }
        #endregion

        #region string2datetime_short
        /// <summary>
        /// Assumed that date has format dd-MM-yy.
        /// If any failure, the value DateTime.MinValue is returned.
        /// </summary>
        public static DateTime string2datetime_short(string s)
        {            
            if ((s is string) &&
                (!IsNullOrDBNull(s)) &&
                (s != ""))
            {
                try
                {
                    
                    return new DateTime(
                        object2int(s.Substring(6, 4)),
                        object2int(s.Substring(3, 2)),
                        object2int(s.Substring(0, 2)));
                }
                catch { }
            }

            // fallback value
            return DateTime.MinValue;
        }
        #endregion

        #region object2timespan
        /// <summary>
        /// Tries to convert the object to a TimeSpan.
        /// If any failure, the value TimeSpan.MinValue is returned.
        /// </summary>
        public static TimeSpan object2timespan(object o)
        {
            if ((o == null) || (o == DBNull.Value))
                return TimeSpan.MinValue;
            else
            {
                try
                {
                    // assume format ddMMyyyy HH:mm
                    string s = o.ToString().Split(' ')[1];
                    return TimeSpan.Parse(s);
                }
                catch
                {
                    try
                    {
                        // assume format HH:mm or HHmm
                        return TimeSpan.Parse(o.ToString());
                    }
                    catch { }

                }
            }
            return TimeSpan.MinValue;
        }
        #endregion

        #region PaintStatusCell
        /// <summary>
        /// Paints the color column. Multiple statuses are supported.
        /// "OPN" and "1" are colored green.
        /// "SNT" is colored orange
        /// "BKD" and "2" are colored dark gray
        /// Unsupported status is colored white
        /// </summary>
        /// <param name="Grid">The grid to be processed.</param>
        /// <param name="ColumnIndex">The current column index.</param>
        /// <param name="RowIndex">The current row index.</param>
        /// <param name="StatusColumnIndex">The index of the column containing the status text.</param>
        /// <param name="ColorColumnIndex">The index of the column to be painted.</param>
        public static void PaintStatusCell(
            DataGridView Grid,
            int ColumnIndex,
            int RowIndex,
            int StatusColumnIndex,
            int ColorColumnIndex)
        {
            if ((ColumnIndex == ColorColumnIndex) && (RowIndex >= 0) && (RowIndex < Grid.Rows.Count))
            {
                DataGridViewCell cellStatus = Grid[StatusColumnIndex, RowIndex];
                DataGridViewCell cell = Grid[ColorColumnIndex, RowIndex];

                // set font and display symbol
                DataGridViewCellStyle style = Grid.Columns[ColorColumnIndex].DefaultCellStyle;
                if (!style.NullValue.Equals("g"))
                {
                    style.Font = new Font("Webdings", 8.25f);
                    style.NullValue = "g";
                }

                // set color for Open status
                if ((cellStatus.Value.ToString() == "OPN") ||
                    (cellStatus.Value.ToString() == "1"))
                {
                    cell.Style.ForeColor = Color.Green;
                    cell.Style.SelectionForeColor = Color.Green;
                    cell.ToolTipText = db.GetLangString("Tools.PaintStatusCell.Open");
                }
                // set color for Sent status
                else if (cellStatus.Value.ToString() == "SNT")
                {
                    cell.Style.ForeColor = Color.Orange;
                    cell.Style.SelectionForeColor = Color.Orange;
                    cell.ToolTipText = db.GetLangString("Tools.PaintStatusCell.Sent");
                }
                // set color for Booked status
                else if (cellStatus.Value.ToString() == "BKD")
                {
                    cell.Style.ForeColor = Color.DarkGray;
                    cell.Style.SelectionForeColor = Color.DarkGray;
                    cell.ToolTipText = db.GetLangString("Tools.PaintStatusCell.Booked");
                }
                // set color for Closed status
                else if (cellStatus.Value.ToString() == "2")
                {
                    cell.Style.ForeColor = Color.DarkGray;
                    cell.Style.SelectionForeColor = Color.DarkGray;
                    cell.ToolTipText = db.GetLangString("Tools.PaintStatusCell.Closed");
                }
                else if (cellStatus.Value.ToString() == "True")
                {
                    cell.Style.ForeColor = Color.Green;
                    cell.Style.SelectionForeColor = Color.Green;
                    cell.ToolTipText = "";
                }
                else if (cellStatus.Value.ToString() == "False")
                {
                    cell.Style.ForeColor = Color.Red;
                    cell.Style.SelectionForeColor = Color.Red;
                    cell.ToolTipText = "";
                }
                // set fallback color
                else
                {
                    cell.Style.ForeColor = Color.White;
                    cell.Style.SelectionForeColor = Color.White;
                    cell.ToolTipText = "Status";
                }

                // set colors used when calling this method from ItemUpdLines form

            }
        }
        #endregion

        #region LookupValue
        /// <summary>
        /// Looks up a value. Call this method from a TextBox's TextChanged property,
        /// setting its Text property to the return value of this method.
        /// Whenever a databound TextBox gets its value from a data table,
        /// a looked up value is displayed instead.
        /// </summary>
        /// <param name="SourceBinding">The binder that contains source data.</param>
        /// <param name="LookupBinding">The binder that contains lookup data.</param>
        /// <param name="SourceValueColumnName">The column name of the source value.</param>
        /// <param name="LookupValueColumnName">The column name of the lookup value.</param>
        /// <param name="LookupDisplayColumnName">The column name of the lookup display text.</param>
        /// <returns>The lookup display text or "" if not found or error.</returns>
        public static string LookupValue(
            BindingSource SourceBinding,
            BindingSource LookupBinding,
            string SourceValueColumnName,
            string LookupValueColumnName,
            string LookupDisplayColumnName)
        {
            try
            {
                DataRowView srcRow = (DataRowView)SourceBinding.Current;
                int index = LookupBinding.Find(LookupValueColumnName, srcRow[SourceValueColumnName]);
                if (index >= 0)
                    return ((DataRowView)LookupBinding[index])[LookupDisplayColumnName].ToString();
            }
            catch { }
            return "";
        }
        #endregion

        #region ReAssignBindingSourceData
        /// <summary>
        /// Re-assigns the BindingSource's DataSource to ds
        /// and DataMember to a clone string of DataMember.
        /// This is useful when you transfer a dataset from one
        /// form to another, and want to use that dataset in the
        /// second form instead of the dataset already used on that form.
        /// DataBinders on the second form needs to know about the change.
        /// </summary>
        /// <param name="Components">
        /// The component collection on the form.
        /// Found by using this.components.Components.</param>
        /// <param name="ds">The dataset to be reassigned.</param>
        public static void ReAssignBindingSourceData(ComponentCollection Components, DataSet ds)
        {
            foreach (Component ctrl in Components)
            {
                if (ctrl is BindingSource)
                {
                    BindingSource bs = (BindingSource)ctrl;
                    bs.DataSource = ds;
                    string dm = bs.DataMember.Clone().ToString();
                    bs.DataMember = dm;
                }
            }
        }
        #endregion

        #region EnterAsTab
        /// <summary>
        /// This method is supposed to be used from KeyDown
        /// events on controls, where you want the Enter key
        /// to behave like the Tab key.
        /// It checks if e.KeyCode == Keys.Enter. If so
        /// a Tab key is simulated and e.SuppressKeyPress
        /// is set to true, making sure not beep sound occurs.
        /// If e.KeyCode != Keys.Enter, nothing is done.
        /// </summary>
        /// <param name="e"></param>
        /// <returns>True if KeyCode was Enter and something was done. False if nothing was done.</returns>
        public static bool EnterAsTab(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
                return true;
            }
            else
                return false;
        }
        #endregion

        #region Print

        public static void Print(CrystalDecisions.CrystalReports.Engine.ReportClass report, bool preview)
        {
            Print(report, preview, true);
        }

        /// <summary>
        /// Prints the given CrystalReport, using either preview or direct print.
        /// </summary>
        /// <param name="report">The CrystalReport with data (use it's property SetDataSource).</param>
        /// <param name="preview">If true, preview is used. If false, direct print is used.</param>
        public static void Print(CrystalDecisions.CrystalReports.Engine.ReportClass report, bool preview, bool portrait)
        {
            if (portrait)
                report.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
            else
                report.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;

            if(preview)
            {
                ReportPreview printForm = new ReportPreview(report);
                printForm.ShowDialog();
            }
            else
            {
                // show print dialog, and if user clicks Print,
                // take the settings from the dialog and setup the
                // report to print directly to the printer using the
                // user's selections
                PrintDialog printDialog = new PrintDialog();
                printDialog.AllowPrintToFile = false;
                printDialog.PrinterSettings.DefaultPageSettings.Landscape = !portrait;
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    // use selected printer
                    report.PrintOptions.PrinterName =
                        printDialog.PrinterSettings.PrinterName;

                    // use selected paper orientation (portrait/landscape)
                    if (printDialog.PrinterSettings.DefaultPageSettings.Landscape)
                        report.PrintOptions.PaperOrientation =
                            CrystalDecisions.Shared.PaperOrientation.Landscape;
                    else
                        report.PrintOptions.PaperOrientation =
                            CrystalDecisions.Shared.PaperOrientation.Portrait;

                    report.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

                    // finally collect the user's selection of
                    // number of copies, collation, to/from page,
                    // and print the page to the printer
                    report.PrintToPrinter(
                        printDialog.PrinterSettings.Copies,
                        printDialog.PrinterSettings.Collate,
                        printDialog.PrinterSettings.FromPage,
                        printDialog.PrinterSettings.ToPage);
                }
            }
        }
        #endregion

        #region IsFileReadOnly
        /// <summary>
        /// Checks if the file is readonly. If it is,
        /// errmsg is assigned an error message and this
        /// error message is written to the log too.
        /// </summary>
        /// <param name="filename">The file to check for readonly.</param>
        /// <returns>True if file is readonly, false if it is not readonly.</returns>
        public static bool IsFileReadOnly(string filename)
        {
            return ((File.GetAttributes(filename) & FileAttributes.ReadOnly) != 0);
        }
        #endregion

        #region RemoveFileWriteProtection
        /// <summary>
        /// Removes all attributes on the given file,
        /// including the readonly attribute.
        /// </summary>
        /// <param name="filename"></param>
        public static void RemoveFileWriteProtection(string filename)
        {
            if (File.Exists(filename))
                File.SetAttributes(filename, FileAttributes.Normal);
        }
        #endregion

        #region StripDirectoryFromPath
        /// <summary>
        /// Removes the directory part of a path that
        /// include both directory and filename.
        /// </summary>
        public static string StripDirectoryFromPath(string path)
        {
            // The most safest way to accomplish this task,
            // is to scan for \\ or / characters from the back
            // of the string. Anything right of such a character,
            // is the filename.
            string filename = "";
            int i = path.Length - 1;
            while(i >= 0)
            {
                if ((path[i] == '\\') || (path[i] == '/'))
                {
                    for (++i; i < path.Length; i++)
                        filename += path[i];
                    return filename;
                }
                --i;
            }
            return path; // was already only a filename or empty
        }
        #endregion

        #region StripFilenameFromPath
        /// <summary>
        /// Removes the filename part of a path that
        /// include both directory and filename.
        /// </summary>
        public static string StripFilenameFromPath(string path)
        {
            return Directory.GetParent(path).FullName;
        }
        #endregion

        #region ExecuteProcess (2 overloads)
        public static void ExecuteProcess(string filename)
        {
            ExecuteProcess(filename, "");
        }
        public static void ExecuteProcess(string filename, string arguments)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = filename;
            psi.Arguments = arguments;
            Process process = new Process();
            process.StartInfo = psi;
            process.Start();
        }
        #endregion

        #region CleanupSEMfiles
        /// <summary>
        /// Scans all SEM files in the given directory for the given file entries.
        /// Each entry found in a semaphore file is deleted from the semaphore file.
        /// When done, any semaphore file that has no file referenced anymore, is deleted.
        /// </summary>
        public static void CleanupSEMfiles(string directory, List<string> entries)
        {
            // scan and traverse all semaphore files in the given directory
            string[] semaphoreFiles = Directory.GetFiles(directory, "SEM*.xml", SearchOption.TopDirectoryOnly);
            foreach (string file in semaphoreFiles)
            {
                // open the semaphore xml document
                XmlDocument xml = new XmlDocument();
                xml.Load(file);

                /// extract and traverse all File elements in the semaphore file
                XmlNodeList list = xml.SelectNodes("FileList/File");
                foreach (XmlElement e in list)
                {
                    // compare all File elements with the given entries
                    foreach (string entry in entries)
                    {
                        // if element is reference the current entry,
                        // remove file reference in semaphore file
                        if (e.InnerText == tools.StripDirectoryFromPath(entry))
                            xml.SelectSingleNode("FileList").RemoveChild(e);
                    }
                }

                /// save the document, as entries has been removed
                xml.Save(file);
            }

            // delete empty semaphore files
            foreach (string file in semaphoreFiles)
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(file);
                XmlNodeList list = xml.SelectNodes("FileList/File");
                if (list.Count <= 0)
                    File.Delete(file);
            }
        }
        #endregion

        #region TruncString
        /// <summary>
        /// Truncates the string safely. If the string
        /// does not contain enough characters, the string
        /// is just returned. The reason for this method is
        /// the standard Remove method on string will throw
        /// an exception if trying to remove characters from
        /// an index higher that it contains.
        /// </summary>
        /// <param name="Str">The string to truncate.</param>
        /// <param name="IndexToCutFrom">
        /// Index in the string to truncate from.
        /// Any character af this index is removed.
        /// </param>
        /// <returns>The truncated string.</returns>
        public static string TruncString(string Str, int IndexToCutFrom)
        {
            try
            {
                if (Str.Length > IndexToCutFrom)
                    Str = Str.Remove(IndexToCutFrom);
                return Str;
            }
            catch
            {
                return Str;
            }
        }
        #endregion

        #region RegExCheckValue_int
        /// <summary>
        /// Checks the given value with a regular expression.
        /// If it evaluates to an integer, true is returned.
        /// False is returned if it does not evaluate to an
        /// integer or if null or DBNull was passed in.
        /// </summary>
        /// <param name="val">A value to be checked if it can evaluate to an integer.</param>
        public static bool RegExCheckValue_int(object Value, bool NullIsOk)
        {
            if ((NullIsOk) && ((Value == null) || (Value == DBNull.Value) || (Value.Equals(""))))
                return true;
            else if ((!NullIsOk) && ((Value == null) || (Value == DBNull.Value) || (Value.Equals(""))))
                return false;
            Regex regex = new Regex("^([-0-9]+)$");
            return (regex.Match(Value.ToString()).Success);
        }
        #endregion

        #region IsNullOrDBNull
        /// <summary>
        /// Returns true if the object is null or DBNull.Value. False if not.
        /// </summary>
        public static bool IsNullOrDBNull(object o)
        {
            return ((o == null) || (o == DBNull.Value));
        }
        #endregion

        #region CalcCostPrice
        public static double CalcCostPrice(double budgetmargin, double salesprice)
        {
            return ((100 - budgetmargin) / 100) * salesprice;
        }

        public static string CalcCostPriceAsSQLString()
        {
            return " ((100 - BudgetMargin) / 100) * POSSalesPrice ";
        }
        #endregion

        #region CalcMargin
        public static double CalcMargin(double salesprice, double costprice)
        {
            if (salesprice == 0) return 0;
            return Math.Round((((salesprice - costprice) / salesprice) * 100),2);
        }
        #endregion

        #region CalcDB
        /// <summary>
        /// Calculates dækningsbidrag (contribution margin).
        /// </summary>
        public static double CalcDB(double salesprice, double costprice)
        {
            return (salesprice - costprice);
        }
        #endregion

        #region CalcDGDiff
        public static double CalcDGDiff(double dg, double margin)
        {
            return (dg - margin);
        }
        #endregion

        #region CalcDBDiff
        public static double CalcDBDiff(double Sales, double DiffDG)
        {
            return ((Sales / 100) * DiffDG);
        }
        #endregion

        #region GetSubCategoryVAT
        /// <summary>
        /// Looks up the VAT for the given SubCategory.
        /// </summary>
        public static double GetSubCategoryVAT(string SubCategory)
        {
            return tools.object2double(db.ExecuteScalar(string.Format(@"
                select TaxPct
                from SubCategory
                inner join LookupTaxID
                on SubCategory.VatRate = LookupTaxID.TaxID
                where (SubCategory.SubCategoryID = '{0}')
                ", SubCategory.Replace("'", ""))));
        }
        #endregion

        #region DeductVAT
        /// <summary>
        /// Deducts the VAT from the figure and returns the result.
        /// </summary>
        public static double DeductVAT(double figure, double vat)
        {
            return figure / ((vat + 100) / 100);
        }
        public static double DeductVAT(double figure, string SubCategoryID)
        {
            double vat = GetSubCategoryVAT(SubCategoryID);
            return figure / ((vat + 100) / 100);
        }
        /// <summary>
        /// Returns the formula to be used in SQL queries when it is
        /// not practical to call the DeductVAT method.
        /// </summary>
        public static string DeductVATsqlString(string FigureField, string VATField)
        {
            return string.Format("{0} / (({1} + 100) / 100)", FigureField, VATField);
        }
        #endregion

        #region wholenumber4sql
        /// <summary>
        /// If o == DBNull.Value, "NULL" is returned.
        /// Otherwise o is returned as is.
        /// </summary>
        public static object wholenumber4sql(object wholenumber)
        {
            if (IsNullOrDBNull(wholenumber))
                return "NULL";
            else
                return wholenumber;
        }
        #endregion

        #region decimalnumber4sql
        /// <summary>
        /// If o == DBNull.Value, "NULL" is returned.
        /// Otherwise o is returned converted to
        /// a double with object2double and embraced in ''
        /// </summary>
         public static string decimalnumber4sql(object decimalnumber)
        {
            if (IsNullOrDBNull(decimalnumber))
                return "NULL";
            else
                return object2double(decimalnumber).ToString().Replace(",",".");
        }
        
        
        #endregion

        #region datetime4sql
        /// <summary>
        /// If datetime is anything else that a valid date (including DateTime.MinValue and null/DBNull), "NULL" is returned.
        /// Otherwise datetime is returned converted to a DateTime with object2datetime and embraced in ''
        /// </summary>
        public static string datetime4sql(object datetime)
        {
            DateTime dt = object2datetime(datetime);
            if (dt == DateTime.MinValue)
                return "NULL";
            else
                return "'" + dt.ToString() + "'";
        }
        #endregion

        #region string4sql
        /// <summary>
        /// If str == DBNull.Value, "NULL" is returned.
        /// Otherwise the string is truncated and any " inside the string
        /// is replaced with ', then the string is returned embraced in "".
        /// </summary>
        public static string string4sql(object str, int IndexToCutFrom)
        //{
        //    if(IsNullOrDBNull(str) || (str.ToString() == ""))
        //        return "NULL";
        //    else
        //        return "\"" + tools.TruncString(str.ToString(), IndexToCutFrom).Replace("\"", "'") + "\"";

        //     public static string string4sql(object str, int IndexToCutFrom)
        {
            if(IsNullOrDBNull(str) || (str.ToString() == ""))
                return "NULL";
            else
                return "'" + tools.TruncString(str.ToString(), IndexToCutFrom).Replace("'", "''") + "'";
        //}
        //#endregion
        }
        #endregion

        #region bool4sql
        public static string bool4sql(object boolean)
        //{
        //    if (IsNullOrDBNull(boolean))
        //        return "NULL";
        //    else
        //        return boolean.ToString();
        //}
        {
            if (IsNullOrDBNull(boolean))
                return "NULL";
            else
                return object2bool(boolean) ? "1" : "0";
        }
        #endregion

        #region timespan4sql
        public static string timespan4sql(object timespan)
        {
            TimeSpan ts = object2timespan(timespan);
            if (ts == TimeSpan.MinValue)
                return "NULL";
            else
                return "'" + ts.ToString() + "'";
        }
        #endregion

        #region SetReportObjectText
        /// <summary>
        /// Sets the specified textobject's Text property in the given report.
        /// </summary>
        /// <param name="Report">The Crystal Report instance.</param>
        /// <param name="ObjectName">The name given to the object in the report designer.</param>
        /// <param name="Value">The value to be assigned to the object's Text property.</param>
        public static void SetReportObjectText(CrystalDecisions.CrystalReports.Engine.ReportClass Report, string ObjectName, string Value)
        {
            ReportObjects reportObjects = Report.ReportDefinition.ReportObjects;
            TextObject obj = (TextObject)reportObjects[ObjectName];
            obj.Text = Value;
        }
        #endregion

        #region SetReportSiteInformation
        /// <summary>
        /// Assumes a formula field exists on the given report. This formula
        /// MUST be given the name SiteInformation when prompted by the designer.
        /// Note: This is not the Name property of the field, which will be set to
        /// SiteInformation1. This formula fields must either have "Can Grow" set or
        /// be high enough for 5 lines to fit (1300 units with a font of 9.75pt).
        /// Data from AdminDataSet.SiteInfomation is used to populate the field.
        /// </summary>
        public static void SetReportSiteInformation(CrystalDecisions.CrystalReports.Engine.ReportClass Report)
        {
            try
            {
                /// Crystal Reports have a known bug in version 10 for .Net,
                /// so a special newline character must be used when working
                /// with multiline text in a field. Remember to use a formula field.
                /// See articles here:
                /// http://tim.mackey.ie/CrystalReportsTextObjectIgnoresNewlineCarriageReturnRn.aspx
                /// http://support.businessobjects.com/library/kbase/articles/c2015089.asp
                /// Basically a text string must be surrounded with '' and all \r\n must
                /// be replaced with "' + chr(10) + '".
                string crNewLine = "' + chr(10) + '";

                // load siteinformation data
                AdminDataSet ds = new AdminDataSet();
                AdminDataSetTableAdapters.SiteInformationTableAdapter adapter =
                    new RBOS.AdminDataSetTableAdapters.SiteInformationTableAdapter();
                adapter.Connection = db.Connection;
                adapter.Fill(ds.SiteInformation);
                if (ds.SiteInformation.Rows.Count > 0)
                {
                    DataRow row = ds.SiteInformation.Rows[0];
                    Report.DataDefinition.FormulaFields["SiteInformation"].Text =
                        "'" +
                        /*"Stationsnr.\t\t" + */    row["SiteCode"] + crNewLine +
                        /*"Navn\t\t\t" + */         row["SiteName"] + crNewLine +
                        /*"Adresse\t\t" + */        row["Adress1"] + crNewLine +
                        /*"Postnr./By\t\t" + */     row["ZipCode"] + " " + row["City"] + crNewLine +
                        /*"Telefon\t\t\t" + */      "Tlf. " + row["Telephone"] +
                        "'";
                }
            }
            catch { }
        }
        #endregion

        #region CreateCSVParser

        public static GenericParser CreateCSVParser(string filename, char seperator, bool hasHeader)
        {
            GenericParser parser = new GenericParsing.GenericParser(filename);
            char[] delimiter = { seperator };
            parser.ColumnDelimiter = delimiter;
            parser.FirstRowHasHeader = hasHeader;
            parser.TrimResults = true;
            return parser;
        }

        public static GenericParser CreateCSVParser(TextReader reader, char seperator, bool hasHeader)
        {
            GenericParser parser = new GenericParsing.GenericParser(reader);
            char[] delimiter = { seperator };
            parser.ColumnDelimiter = delimiter;
            parser.FirstRowHasHeader = hasHeader;
            parser.TrimResults = true;
            return parser;
        }

        #endregion

        #region CalcIndex
        public static double CalcIndex(double Actual, double Target)
        {
            double Index = 0;
            if (Target != 0)
                Index = Actual / Target * 100;
            if (Index != 0)
            {
                if (Index >= 100)
                    Index -= 100;
                else
                    Index = -(100 - Index);
            }
            return Index;
        }
        #endregion

        #region Encoding
        /// <summary>
        /// Returns encoding iso-8859-1
        /// </summary>
        public static System.Text.Encoding Encoding()
        {
            return System.Text.Encoding.GetEncoding("iso-8859-1");
        }
        #endregion

        #region DayOfWeek2DayNo
        /// <summary>
        /// Returns the dayno of the weekday.
        /// Monday is the first day.
        /// Instead of this method, you could rely
        /// on the DayOfWeek propety of DateTime,
        /// but that would be specific to the locale
        /// settings, so if sunday was day 1, the lookup
        /// into our table PrlLookupDays would fail as
        /// in that table it is assumes that monday is day 1.
        /// </summary>
        public static int DayOfWeek2DayNo(DayOfWeek d)
        {
            switch (d)
            {
                case DayOfWeek.Monday: return 1;
                case DayOfWeek.Tuesday: return 2;
                case DayOfWeek.Wednesday: return 3;
                case DayOfWeek.Thursday: return 4;
                case DayOfWeek.Friday: return 5;
                case DayOfWeek.Saturday: return 6;
                case DayOfWeek.Sunday: return 7;
                default: return 0;
            }
        }
        #endregion

        #region ForceGarbageCollectionNow
        public static void ForceGarbageCollectionNow()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        #endregion

        #region GetStartEndDatesInMonth
        /// <summary>
        /// Fills StartDate and EndDate with the first and last date
        /// in the same month as in Date.
        /// </summary>
        /// <param name="Date">The Date to generate the StartDate and EndDate from</param>
        /// <param name="StartDate">The first date in the month</param>
        /// <param name="EndDate">The last date in the month</param>
        public static void GetStartEndDatesInMonth(DateTime Date, out DateTime StartDate, out DateTime EndDate)
        {
            StartDate = new DateTime(Date.Year, Date.Month, 1);
            EndDate = new DateTime(Date.Year, Date.Month, DateTime.DaysInMonth(Date.Year, Date.Month));
        }
        #endregion

        #region GetFirstDateInMonth
        /// <summary>
        /// Returns the first date in the month in which the provided date falls in.
        /// </summary>
        public static DateTime GetFirstDateInMonth(DateTime Date)
        {
            return new DateTime(Date.Year, Date.Month, 1);
        }
        #endregion

        #region GetLastDateInMonth
        /// <summary>
        /// Returns the last date in the month in which the provided date falls in.
        /// </summary>
        public static DateTime GetLastDateInMonth(DateTime Date)
        {
            return new DateTime(Date.Year, Date.Month, DateTime.DaysInMonth(Date.Year, Date.Month));
        }
        #endregion

        #region IsDateLastDateInMonth
        public static bool IsDateLastDateInMonth(DateTime date)
        {
            DateTime LastDateInMonth = GetLastDateInMonth(date);
            return date == LastDateInMonth;
        }
        #endregion

        #region StringArray2StringList
        public static List<string> StringArray2StringList(string [] array)
        {
            List<string> list = new List<string>();
            foreach (string s in array)
                list.Add(s);
            return list;
        }
        #endregion

        #region SubStringSafe
        public static string SubStringSafe(string str, int startindex, int length)
        {
            if (str == null)
                return "";
            else if ((startindex < str.Length) && ((startindex + str.Length) >= length))
                return str.Substring(startindex, length);
            else
                return str;
        }
        #endregion

        #region GetISOWeekNumberFromDate
        /// <summary>
        /// Returns the date's actual year and week.
        /// The date can actually lie the then previous
        /// year's last week. The returned value is a
        /// compund value of yyyyww.
        /// </summary>
        public static void GetISOWeekNumberFromDate(DateTime dt, out int year, out int week)
        {
            /// This code is taken from Julian M. Bucknall's excellent article on
            /// http://www.boyet.com/Articles/PublishedArticles/CalculatingtheISOweeknumb.html
            /// and modyfied a bit.

            DateTime week1;
            int IsoYear = dt.Year;
            if (dt >= new DateTime(IsoYear, 12, 29))
            {
                week1 = GetMondayOf1stWeek(IsoYear + 1);
                if (dt < week1)
                {
                    week1 = GetMondayOf1stWeek(IsoYear);
                }
                else
                {
                    IsoYear++;
                }
            }
            else
            {
                week1 = GetMondayOf1stWeek(IsoYear);
                if (dt < week1)
                {
                    week1 = GetMondayOf1stWeek(--IsoYear);
                }
            }

            //return (IsoYear * 100) + ((dt - week1).Days / 7 + 1);
            year = IsoYear;
            week = ((dt - week1).Days / 7 + 1);
        }
        #endregion

        #region GetDateFromISOWeekNumber
        /// <summary>
        /// Gets the date of a given year, week and weekday.
        /// </summary>
        /// <param name="Year">The year.</param>
        /// <param name="Week">The week number.</param>
        /// <param name="WeekDay">The weekday.</param>
        /// <returns></returns>
        public static DateTime GetDateFromISOWeekNumber(int Year, int Week, DayOfWeek WeekDay)
        {
            /// This code is taken from the article by Julian M. Bucknall
            /// at http://www.boyet.com/Articles/IsoDateToDate.html
            return GetMondayOf1stWeek(Year).AddDays((Week - 1) * 7 + ( DayOfWeek2DayNo(WeekDay) - 1));
        }
        #endregion

        #region GetMondayOf1stWeek
        // private helper method for GetISOWeekNumberFromDate and GetDateFromISOWeekNumber
        private static DateTime GetMondayOf1stWeek(int Year)
        {
            /// This code is taken from Julian M. Bucknall's excellent article on
            /// http://www.boyet.com/Articles/PublishedArticles/CalculatingtheISOweeknumb.html
            /// and modyfied a bit.

            // get the date for the 4-Jan for this year
            DateTime dt = new DateTime(Year, 1, 4);

            // get the ISO day number for this date
            int dayNumber = DayOfWeek2DayNo(dt.DayOfWeek);

            // return the date of the Monday that is less than or equal to this date
            return dt.AddDays(1 - dayNumber);
        }
        #endregion

        #region GetLastCalendarDay
        /// <summary>
        /// Gets the last day in the calendar
        /// looking from today. So if today is
        /// for instance wednesday 20-dec-2006,
        /// and you pass in Monday, the return
        /// value will be 18-dec-2006, that is,
        /// the monday before todays day.
        /// If today is the same weekday as passed
        /// in, todays date is returned.
        /// </summary>
        public static DateTime GetLastCalendarDay(DayOfWeek WeekDay)
        {
            DateTime Today = DateTime.Now.Date;
            while (Today.DayOfWeek != WeekDay)
                Today = Today.AddDays(-1);
            return Today;
        }
        #endregion

        #region GetLastWeekDay
        /// <summary>
        /// Gets the date of the last weekday from the given date.
        /// </summary>
        public static DateTime GetLastWeekDay(DateTime Date, DayOfWeek WeekDay)
        {
            if (Date == DateTime.MinValue)
                return DateTime.MinValue;
            while (Date.DayOfWeek != WeekDay)
                Date = Date.AddDays(-1);
            return Date;
        }
        #endregion

        #region CompactAndRepairDatabase
        /// <summary>
        /// Compacts and repairs the RBOS20.accdb file.
        /// IMPORTANT: No active connections to the database may exists.
        /// </summary>
        public static void CompactAndRepairDatabase()
        {
            try
            {
                // initialize database to access config strings
                db.Initialize();

                // check that compact and repair is enabled
                if (!db.GetConfigStringAsBool("CompactAndRepair.Enabled"))
                {
                    db.Shutdown();
                    return;
                }

                // this is only done in a specified interval
                DateTime LastDone = db.GetConfigStringAsDateTime("CompactAndRepair.LastDone");
                int Interval = db.GetConfigStringAsInt("CompactAndRepair.Interval");
                if (Interval <= 0)
                {
                    // if interval is 0, this means CompactAndRepair.Interval
                    // config value has not yet been written. it is not written
                    // to config in the version updater, as the version updater
                    // runs after this code. same scenario applies to the
                    // CompactAndRepair.LastDone config value.
                    Interval = 30;
                    db.SetConfigString("CompactAndRepair.Interval", Interval);                    
                }
                
                // shutdown database after accessing config strings
                db.Shutdown();

                // check if it is time to perform the compact and repair
                if (LastDone.Date < DateTime.Now.Date.AddDays(-Interval))
                {
                    log.Write("Starting compact and repair of database");

                    // create an inctance of a Jet Replication Object
                    log.Write("Create instance of Jet Replication Object");
                    object objJRO = Activator.CreateInstance(Type.GetTypeFromProgID("JRO.JetEngine"));

                    // create parameters array
                    string NewConnectionString = db.ConnectionString.Replace("RBOS20.accdb", "RBOS20_compacted.accdb");
                    object[] oParams = new object[] { db.ConnectionString, NewConnectionString };

                    //invoke CompactDatabase method of the JRO object and pass it the parameters array
                    log.Write("Invoke CompactDatabase method on the JRO object");
                    objJRO.GetType().InvokeMember("CompactDatabase",
                        System.Reflection.BindingFlags.InvokeMethod,
                        null,
                        objJRO,
                        oParams);

                    // clean up
                    log.Write("Release JRO COM object");
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objJRO);
                    objJRO = null;

                    // rename original database file
                    log.Write("Rename original file to RBOS20_orig.accdb");
                    RemoveFileWriteProtection("RBOS20.accdb");
                    System.IO.File.Move("RBOS20.accdb", "RBOS20_orig.accdb");

                    // rename compacted database file
                    log.Write("Rename compacted file to RBOS20.accdb");
                    RemoveFileWriteProtection("RBOS20_compacted.accdb");
                    System.IO.File.Move("RBOS20_compacted.accdb", "RBOS20.accdb");

                    // check we can read something from the new compacted database
                    log.Write("Check we can read something from the new compacted database");
                    db.GetConfigString("CompactAndRepair.Interval");

                    // if all ok, delete the original database file
                    log.Write("All should be ok, delete RBOS20_orig.accdb");
                    System.IO.File.Delete("RBOS20_orig.accdb");

                    // set datetime in config for when this was done
                    log.Write("Update CompactAndRepair.LastDone in database");
                    db.Initialize();
                    db.SetConfigString("CompactAndRepair.LastDone", DateTime.Now.Date);
                    db.Shutdown();

                    log.Write("Compact and repair done");
                }
            }
            catch (Exception ex)
            {
                // something went wrong. check if we were in the
                // middle of checking if we could read from the
                // new compacted database
                log.Write("Something went wrong. Restoring the original database");
                if (File.Exists("RBOS20_orig.accdb"))
                {
                    // remove the corrupt compacted database
                    RemoveFileWriteProtection("RBOS20.accdb");
                    System.IO.File.Delete("RBOS20.accdb");

                    // restore the original database
                    RemoveFileWriteProtection("RBOS20_orig.accdb");
                    System.IO.File.Move("RBOS20_orig.accdb", "RBOS20.accdb");
                }

                // if something goes wrong, just report it in the log, don't show to user
                log.WriteException("CompactAndRepairDatabase()", ex.Message, ex.StackTrace);
            }
        }
        #endregion

        #region IsLastDayInMonth

        /// <summary>
        /// Tells if the provided date is on the last day
        /// in the month, in which the date is.
        /// </summary>
        public static bool IsLastDayInMonth(DateTime date)
        {
            int DaysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            return (date.Day == DaysInMonth);
        }

        #endregion

        #region GetNumLinesInFile
        public static int GetNumLinesInFile(string path)
        {
            int num = 0;
            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                reader.ReadLine();
                ++num;
            }
            reader.Close();
            return num;
        }
        #endregion

        #region METHOD: GetFTPArriveDir
        public static string GetFTPArriveDir()
        {
            return (db.GetConfigString("DRS_FTP_client_arrive_dir") + "\\").Replace("\\\\", "\\");
        }
        #endregion

        #region Funktioner til at nød-håndtere en fejl i brændstof rabatter
        public static void FuelDiscountFix_CopyMSM2DRS(string file)
        {
            try
            {
                if (db.GetConfigStringAsBool("COPY_RSM_TO_DRS"))
                {
                    string dest = db.GetConfigString("DRS_FTP_client_depart_dir") + "\\" + StripDirectoryFromPath(file);
                    dest = dest.Replace("\\\\", "\\");
                    if (File.Exists(dest))
                    {
                        RemoveFileWriteProtection(dest);
                        File.Delete(dest);
                    }
                    File.Copy(file, dest);
                }
            }
            catch (Exception ex)
            {
                log.WriteException(string.Format("FuelDiscountFix_CopyMSM2DRS({0})", file), ex.Message, ex.StackTrace);
            }
        }
        public static void FuelDiscountFix_CopyPEJ2DRS(string file)
        {
            try
            {
                if (db.GetConfigStringAsBool("COPY_PEJ_TO_DRS"))
                {
                    string dest = db.GetConfigString("DRS_FTP_client_depart_dir") + "\\" + StripDirectoryFromPath(file);
                    dest = dest.Replace("\\\\", "\\");
                    if (File.Exists(dest))
                    {
                        RemoveFileWriteProtection(dest);
                        File.Delete(dest);
                    }
                    File.Copy(file, dest);
                }
            }
            catch (Exception ex)
            {
                log.WriteException(string.Format("FuelDiscountFix_CopyPEJ2DRS({0})", file), ex.Message, ex.StackTrace);
            }
        }
        #endregion

        #region ApplicationNeedsToForceQuit
        private static bool _ApplicationNeedsToForceQuit = false;
        /// <summary>
        /// If this returns true, nothing in RBOS may prevent closing the application.
        /// For instance, we have some forms that requires user to click on the close button,
        /// but if this value is true, the forms must close no matter what.
        /// </summary>
        public static bool ApplicationNeedsToForceQuit
        {
            get { return _ApplicationNeedsToForceQuit; }
            set { _ApplicationNeedsToForceQuit = value; }
        }
        #endregion
    }
}
