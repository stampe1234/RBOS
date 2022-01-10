using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;

namespace RBOS
{
    /// <summary>
    /// The purpose of this class is to give a multiuser a means to request an unlock of a database in use by another user.
    /// </summary>

    public partial class UserLogonUnlockDB : Form
    {
        string DatabaseToLock = ""; // is accessed threaded, so use locks
        BackgroundWorker worker = null;
        
        public UserLogonUnlockDB(string database)
        {
           // InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.DatabaseToLock = database; // no need to lock it here
            int min1 = (int)Math.Floor((double)dbCentralRBOS.GetConfigStringAsInteger("CheckUnlockRequestInterval") / (double)60);
            int min2 = min1 + 1;
           // lbInfo.Text = string.Format(lbInfo.Text, min1, min2);
            UserLogon.RequestDatabaseUnlock(DatabaseToLock);
            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.RunWorkerAsync();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!worker.CancellationPending)
            {
                // accessing class variable from threaded method, so use lock while reading the value
                string database = "";
                lock (DatabaseToLock)
                {
                    database = DatabaseToLock;
                }

                // checking for valid lock on the database.
                // if database does not have a valid lock, 
                // take ownership and close the form with dialog result OK.
                if (!UserLogon.DatabaseHasValidLock(database))
                {
                    UserLogon.RemoveRequestDatabaseUnlock(database);
                    UserLogon.LockDatabase(database);
                    this.Invoke(new MethodInvoker(delegate
                    {
                        // do stuff in the form's thread
                        this.DialogResult = DialogResult.OK;
                    }));
                    worker.CancelAsync();
                }
                // check if our unlock flag has been removed.
                // this means that the station removed it (user said no).
                else if (!UserLogon.DatabaseUnlockRequested(database))
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        // do stuff in the form's thread
                        MessageBox.Show("Stationen har afvist din anmodning");
                        this.DialogResult = DialogResult.Cancel;
                    }));
                    worker.CancelAsync();
                }
                else
                {
                    Thread.Sleep(5000);
                }
            }
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            lock (worker)
            {
                worker.CancelAsync();
            }
            Close();
        }

        private void UserLogonUnlockDB_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserLogon.RemoveRequestDatabaseUnlock(DatabaseToLock);
        }
    }
}