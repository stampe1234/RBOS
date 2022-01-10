using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    /// <summary>
    /// Provides functionality to check whether a conflicting window is open
    /// when opening a window on the MainForm. Add windows to a list internally
    /// to make the class check them.
    /// 
    /// The reason we have to add the windows in code and not in db, is that if
    /// we just used a list of form names from db, if we then later changed a
    /// form's name, the name would no longer exist. Adding the windows in code
    /// makes the compiler catch such errors for us at compile time.
    /// </summary>
    class ConflictingWindows
    {
        #region Helper class WindowPair
        /// <summary>
        /// Helper class for the class ConflictingWindows.
        /// </summary>
        class WindowPair
        {
            public System.Type Window1 = null;
            public System.Type Window2 = null;
            public string Message = "";

            public WindowPair(System.Type Window1, System.Type Window2, string Message)
            {
                this.Window1 = Window1;
                this.Window2 = Window2;
                this.Message = Message;
            }
        }
        #endregion

        private static List<WindowPair> list = null;

        private static void BuildList()
        {
            // first create a new list
            if (list != null)
                list.Clear();
            list = new List<WindowPair>();

            // add items to list
            list.Add(new WindowPair(typeof(ItemForm), typeof(OrderHeaderForm), db.GetLangString("ConflictingWindows.ItemFormOrderHeaderForm")));
            list.Add(new WindowPair(typeof(PrlSalaryPeriods), typeof(PrlAbsense), db.GetLangString("ConflictingWindows.SalaryPeriodAbsense")));
            list.Add(new WindowPair(typeof(PrlSalaryPeriods), typeof(PrlSalaryReg), db.GetLangString("ConflictingWindows.SalaryPeriodSalaryReg")));
            list.Add(new WindowPair(typeof(PrlSalaryPeriods), typeof(PrlWithdraw), db.GetLangString("ConflictingWindows.SalaryPeriodWithdraw")));
            list.Add(new WindowPair(typeof(PrlSalaryPeriods), typeof(PrlRptSalaryEmpFrm), db.GetLangString("ConflictingWindows.SalaryPeriodRptSalEmp")));
            list.Add(new WindowPair(typeof(PrlSalaryPeriods), typeof(PrlRptSalarySumFrm), db.GetLangString("ConflictingWindows.SalaryPeriodRptSalAllEmp")));
            //@@@TODO: når de to sidste lønmodul rapporter fravær og benzinkøb er lavet, skal de også på
        }

        /// <summary>
        /// Checks if a conflicting window is already open on the main form.
        /// </summary>
        /// <param name="MainWindow">Reference to the main form.</param>
        /// <param name="form">The form to open.</param>
        public static bool ConflictingWindowsAreOpen(MainForm MainWindow, Form form)
        {
            // always allow drs profile to open any window
            // at the same time as other windows
            if (UserLogon.ProfileID == AdminDataSet.UserProfilesDataTable.ProfileID.drs)
                return false;

            if (list == null)
                BuildList();

            foreach(WindowPair pair in list)
            {
                if (pair.Window1 == form.GetType())
                {
                    if(MainWindow.IsFormOpen(pair.Window2))
                    {
                        MessageBox.Show(pair.Message);
                        return true;
                    }
                }
                else if (pair.Window2 == form.GetType())
                {
                    if (MainWindow.IsFormOpen(pair.Window1))
                    {
                        MessageBox.Show(pair.Message);
                        return true;
                    }
                }
            }

            // no conflicting windows are open
            return false;
        }
    }
}
