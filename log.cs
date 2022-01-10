using System;
using System.IO;

namespace RBOS
{
	public class log
    {
        private static string LogHistoryDir = "log-history";
        private static int MaxLogHistoryFiles = 50;

        #region LogFile
        private static string logfile = "log.txt";
		public static string LogFile
		{
			get { return logfile; }
        }
        #endregion

        #region Constructor (private)
        // no instance allowed
		private log()
		{
        }
        #endregion

        #region NewLog
        /// <summary>
		/// Deletes the log file
		/// </summary>
		public static void NewLog()
		{
            if (File.Exists(logfile))
            {
                // make sure the log-history dir is present
                if (!Directory.Exists(LogHistoryDir))
                    Directory.CreateDirectory(LogHistoryDir);

                // use the last log file's write datetime
                // to generate a log history file of the last
                // logfile so no current logfile is present
                DateTime timestamp = File.GetLastWriteTime(logfile);
                string historyFilename = LogHistoryDir + "\\log-" + timestamp.ToString("yyyy-MM-ddTHHmmss") + ".txt";
                if (File.Exists(historyFilename))
                    File.Delete(historyFilename);
                File.Move(logfile, historyFilename);

                // limit number of logfiles to MaxLogHistoryFiles
                string[] logfiles = Directory.GetFiles(LogHistoryDir, "log*.txt", SearchOption.TopDirectoryOnly);
                if (logfiles.Length > MaxLogHistoryFiles)
                {
                    Array.Sort(logfiles);
                    Array.Reverse(logfiles);
                    for (int i = MaxLogHistoryFiles; i < logfiles.Length; i++)
                    {
                        string file = logfiles[i];
                        if (File.Exists(file))
                            File.Delete(file);
                    }
                }
            }
        }
        #endregion

        #region Write

        /// <summary>
		/// Writes a message to the logfile with a timestamp
		/// </summary>
		/// <param name="msg">String to write to log file</param>
        /// <returns>
        /// The message passed in. Useful for one-liners that
        /// both write in the log and displays the message to the user.
        /// </returns>
		public static string Write(string msg)
		{
			StreamWriter writer = new StreamWriter(logfile,true);
            writer.WriteLine(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + ": " + msg);
			writer.Close();
            return msg;
        }

        // private overload of Write, that does not write the timestamp
        private static void Write(string msg, bool displaytimestamp)
        {
            StreamWriter writer = new StreamWriter(logfile, true);
            writer.WriteLine(msg);
            writer.Close();
        }

        #endregion

        #region WriteException
        /// <summary>
        /// Writes an exception to the logfile with a timestamp.
        /// </summary>
        /// <param name="Context">A description the problem in the context it occured.</param>
        /// <param name="ExceptionMessage">The ex.Message passed in.</param>
        /// <param name="StackTrace">The ex.StackTrace passed in.</param>
        /// <returns>
        /// A dialog-friendly version of the exception written to log is
        /// returned so it can be displayed in a dialog to the user.
        /// </returns>
        public static string WriteException(string Context, string ExceptionMessage, string StackTrace)
        {
            Write("------------------------------------", false);
            Write("Exception:");
            Write("Context: " + Context, false);
            Write("Message: " + ExceptionMessage, false);
            Write("StackTrace:\r\n" + StackTrace, false);
            Write("------------------------------------", false);

            return
                "Error occured in the program. Please contact support.\n\n" +
                "Context: " + Context + "\n" +
                "Message: " + ExceptionMessage + "\n\n" +
                "The logfile has more detailed information.\n" +
                "It is accessible from the left menu under Support\n" +
                "or physically in the application folder.";
        }
        #endregion

        #region ViewLog
        public static void ViewLog()
        {
            tools.ExecuteProcess("notepad.exe", logfile);
        }
        #endregion
    }
}
