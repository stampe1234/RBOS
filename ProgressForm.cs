using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    /// <summary>
    /// A progress form to be used where extensive process has to be done.
    /// It makes most sense if you have a set of data to be looped where you
    /// have some information to be displayed for each item looped or if you
    /// have a total number and then can count each item.
    /// 
    /// Quick usage guide:
    /// Displaying a title for the form is done using Title.
    /// Displaying text is done using StatusText.
    /// Making the progress bar working is done using ProgressMax and StatusText.
    /// </summary>
    public partial class ProgressForm : Form
    {
        #region Constructor
        public ProgressForm(string Title)
        {
            InitializeComponent();
            this.Title = Title;
        }
        #endregion

        #region StatusText
        /// <summary>
        /// Sets the shown text. If the ProgressMax
        /// property has previously been set to a positive
        /// value, the progress bar is advanced too.
        /// </summary>
        public string StatusText
        {
            set
            {
                this.label1.Text = value;
                this.label1.Refresh();
                if (progressBar1.Visible)
                {
                    progressBar1.Increment(1);
                    this.Refresh();
                }
            }
        }
        #endregion

        #region Title
        public string Title
        {
            set { this.Text = "  " + value; }
        }
        #endregion

        #region ProgressMax
        /// <summary>
        /// Sets and enables/disables the progress bar.
        /// If set to 0 (or below), the progress bar is hidden.
        /// If set to a positive value, the progress bar is shown,
        /// and each time the StatusText property is set, the
        /// progress bar advances.
        /// </summary>
        public int ProgressMax
        {
            set
            {
                if (value < 0) value = 0;
                progressBar1.Visible = (value > 0);
                progressBar1.Maximum = value;
                progressBar1.Value = 0;
            }
        }
        #endregion
    }
}