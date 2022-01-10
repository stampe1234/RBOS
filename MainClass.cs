using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace RBOS
{
    /// <summary>
    /// MainClass contains the Main() function - the main entry point for the application.
    /// </summary>
    public class MainClass
    {
        public MainClass()
        {
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread] 
        static void MainOld(string[] CmdArgs)
        {
            log.NewLog();
            log.Write("Starting application.");

            // save command line arguments
            tools.SetCmdArgs(CmdArgs);

            // detect already running application and quit if so
            //Process currProcess = Process.GetCurrentProcess();
            //Process[] allProcesses = Process.GetProcessesByName(currProcess.ProcessName);
            //foreach (Process prc in allProcesses)
            //{
            //    string searchedFilename = tools.StripFilenameFromPath(prc.MainModule.FileName);
            //    string myFilename = tools.StripFilenameFromPath(currProcess.MainModule.FileName);

            //  if ((prc.Id != currProcess.Id) &&
            //      (searchedFilename == myFilename))
            //  {
            //    log.Write("An instance of the application was already running, quitting.");
            //    MessageBox.Show("The application is already running.\nExiting now. Please use the running application.");
            //    return;
            //  }
            //}



            // register Neodynamic license
            Neodynamic.WinControls.BarcodeProfessional.BarcodeProfessional.LicenseOwner = "Dansk Retail-Standard Edition-OEM Developer License";
            Neodynamic.WinControls.BarcodeProfessional.BarcodeProfessional.LicenseKey = "423CRH6L9ME77GDP34QAJUVN5TQB33WD8WSVG9VQM62A63CZHV8Q";

            // set up database so it is ready for use
            if (!db.Initialize())
            {
                MessageBox.Show("Error initializing database, please see log file for details.");
                return;
            }


            // run version updater
            // (must be done after initializing db)
            //if (!Version.VersionUpdater())
            //{
            //  // display update error to user
            //  MessageBox.Show(Version.LastError);
            //  return;
            //}

            //// if no new exe is needed, start application
            //if (!Version.NeedNewExe)
            //{
            Application.EnableVisualStyles();

            // load objects while displaying progress
            Splash s = new Splash();
            Application.Run(s);
            s.Dispose(); // must be done, otherwise styles won't work on the next form

            //  // check if we have to display the logon window (is set in database)
            ////if (!UserLogon.LogonOverridden)
            ////{
            // show logon window
            // LogonForm l = new LogonForm();
            //  Application.Run(l);
            //  l.Dispose(); // must be done, otherwise styles won't work on the next form
            //}

            // start application
            if (UserLogon.LoggedOn)
            {
                Application.Run(new MainForm());
            }
            
                //// shut down database in a good manner

                db.Shutdown();

                log.Write("Application ended normally");
            
        

        
    }
        static void Main(string[] CmdArgs)
        {

            bool ConnectionError = false;
           
            try
            {
                log.NewLog();
                log.Write("Starting application.");

                // save command line arguments
                tools.SetCmdArgs(CmdArgs);

                // detect already running application and quit if so
                Process currProcess = Process.GetCurrentProcess();
                Process[] allProcesses = Process.GetProcessesByName(currProcess.ProcessName);
                //foreach (Process prc in allProcesses)
                //{
                //    string searchedFilename = tools.StripFilenameFromPath(prc.MainModule.FileName);
                //    string myFilename = tools.StripFilenameFromPath(currProcess.MainModule.FileName);

                //    if ((prc.Id != currProcess.Id) &&
                //        (searchedFilename == myFilename))
                //    {
                //        log.Write("An instance of the application was already running, quitting.");
                //        MessageBox.Show("The application is already running.\nExiting now. Please use the running application.");
                //        return;
                //    }
                //}

                // register Neodynamic license  //Pn20191007
               // Neodynamic.WinControls.BarcodeProfessional.BarcodeProfessional.LicenseOwner = "Dansk Retail Services-Team License";
              //  Neodynamic.WinControls.BarcodeProfessional.BarcodeProfessional.LicenseKey = "38F93C9D831723E5";


                Neodynamic.WinControls.BarcodeProfessional.BarcodeProfessional.LicenseOwner = "Dansk Retail-Standard Edition-OEM Developer License";
                Neodynamic.WinControls.BarcodeProfessional.BarcodeProfessional.LicenseKey = "423CRH6L9ME77GDP34QAJUVN5TQB33WD8WSVG9VQM62A63CZHV8Q";


                Application.EnableVisualStyles();

                
                // check that the initial setup has been completed after installation
                //if (!UserLogon.InitialSetupCompleted())
                //{
                //    InitialSetup setup = new InitialSetup();
                //    setup.ShowDialog();

                //    // check again if the initial setup has been completed, and if not, exit program
                //    if (!UserLogon.InitialSetupCompleted())
                //        return;
                //}

                // logon before initializing database,
                // so we have the connection strings
                //LogonForm l = new LogonForm();
                //l.ShowDialog();

                // check that user was logged on
                if (!UserLogon.LoggedOn)
                {
                    log.Write("Application ended normally");
                    return;
                }

                // set up database so it is ready for use
                // (must be done after loggin on so we have the connection strings)
                if (!db.Initialize())
                {
                    MessageBox.Show("Error initializing database, please see log file for details.");
                    return;
                }

                // run version updater (must be done after initializing db)
                if (!Version.VersionUpdater())
                {
                    // display update error to user
                    MessageBox.Show(Version.LastError);
                    return;
                }

                // if no new exe is needed, start application
                if (!Version.NeedNewExe)
                {
                    // load objects while displaying progress
                    Splash s = new Splash();
                    Application.Run(s);
                    s.Dispose(); // must be done, otherwise styles won't work on the next form

                    // start application
                    Application.Run(new MainForm());
                }

                log.Write("Application ended normally");
            }
            catch (Exception ex)
            {
                if (ex is System.Data.OleDb.OleDbException || ex is System.Data.SqlClient.SqlException)
                {
                    ConnectionError = true;
                    string msg = "RBOS har mistet forbindelsen til databasen og lukkes nu.\r\n\r\nPrøv venligst igen senere eller tjek forbindelsen til internettet.\r\nKontakt support hvis fejlen bliver ved med at opstå.";
                    log.Write(msg);
                    log.WriteException("Application", ex.Message, ex.StackTrace);
                    MessageBox.Show(msg);
                }
                else
                {
                    MessageBox.Show(log.WriteException("Application", ex.Message, ex.StackTrace));
                }
            }
            finally
            {
                string UnlockRequestedBy = "";

                if (!ConnectionError)
                {
                    if (UnlockPrompt.AutoClosingRBOS)
                        UnlockRequestedBy = UserLogon.UnlockRequetedBy();
                    UserLogon.UnlockCurrentDatabase();
                }
                dbOleDb.Shutdown();

                // check if RBOS has been autoclosed because a multiuser requested
                // the database and nobody responded no from this installation
                if (UnlockPrompt.AutoClosingRBOS)
                {
                    string msg = string.Format(
                        "RBOS er blevet lukket ned automatisk fordi {0} har overtaget databasen og der ikke blevet svaret fra denne installation",
                        UnlockRequestedBy);
                    MessageBox.Show(msg);
                }

                //if (IdleCheckPrompt.AutoClosingRBOS)
                //{
                //    MessageBox.Show("RBOS er blevet lukket ned automatisk fordi der ingen aktivitet var i lang tid.");
                //}
            }
        }


    }
}
