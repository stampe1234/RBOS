using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace DRS.Extensions
{
    /// <summary>
    /// TextBox control that allows displaying a lookup value for a given value.
    /// It works by having a BindingSource and a column name to look for in the binding source.
    /// When the current changes in the binding source, the display value is lookup in the lookup table.
    /// To use this component, set 5 propeties:
    /// 1) SourceBinding
    /// 2) SourceColumnName
    /// 3) LookupTable
    /// 4) LookupColumnValueName
    /// 5) LookupColumnDisplayName
    /// You must also fill the lookup table with data.
    /// </summary>
    class DRS_LookupTextBox : TextBox
    {
        #region Constructor and private variables

        private BindingSource sourceBinding = null;
        private string sourceColumnName = null;
        private DataTable lookupTable = null;
        private string lookupColumnValueName = "";
        private string lookupColumnDisplayName = "";
        private string lookupColumnDisplayFormat = "";

        /// <summary>
        /// DRS_LookupTextBox constructor
        /// </summary>
        public DRS_LookupTextBox() : base()
        {
            this.ReadOnly = true;
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Name of column found in the SourceBinding
        /// </summary>
        public string SourceColumnName
        {
            get { return sourceColumnName; }
            set
            {
                sourceColumnName = value;
                UpdateText();
            }
        }

        /// <summary>
        /// Table to use for looking up the display value
        /// </summary>
        public DataTable LookupTable
        {
            get { return lookupTable; }
            set
            { 
                lookupTable = value;
                UpdateText();
            }
        }

        /// <summary>
        /// Name of column in lookup table used for the lookup.
        /// This is matched with the value in SourceColumnName.
        /// </summary>
        public string LookupColumnValueName
        {
            get { return lookupColumnValueName; }
            set 
            {
                lookupColumnValueName = value;
                UpdateText();
            }
        }

        /// <summary>
        /// Name of the column in lookup table used for display value.
        /// </summary>
        public string LookupColumnDisplayName
        {
            get { return lookupColumnDisplayName; }
            set
            {
                lookupColumnDisplayName = value;
                UpdateText();
            }
        }

        /// <summary>
        /// Display format. n = numeric (25.000,00) etc. see MSDN.
        /// </summary>
        public string LookupColumnDisplayFormat
        {
            get { return lookupColumnDisplayFormat; }
            set { lookupColumnDisplayFormat = value; }
        }

        /// <summary>
        /// The BindingSource for the source data bind - usually your main data
        /// </summary>
        public BindingSource SourceBinding
        {
            get { return sourceBinding; }
            set
            {
                // unsubscribe from already subscribed binding source events
                if (sourceBinding != null)
                {
                    sourceBinding.CurrentItemChanged -= sourceBinding_CurrentItemChanged;
                    sourceBinding.AddingNew -= sourceBinding_AddingNew;
                }

                // store reference to binding source
                sourceBinding = value;

                if (sourceBinding != null)
                {
                    // subscribe to binding source events
                    sourceBinding.CurrentItemChanged += new EventHandler(sourceBinding_CurrentItemChanged);
                    sourceBinding.AddingNew += new System.ComponentModel.AddingNewEventHandler(sourceBinding_AddingNew);
                }

                UpdateText();
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// SourceBinding current changed event handler
        /// </summary>

        private void sourceBinding_AddingNew(object sender, System.ComponentModel.AddingNewEventArgs e)
        {
            this.Text = "";
        }

        private void sourceBinding_CurrentItemChanged(object sender, EventArgs e)
        {
            UpdateText();
        }

        private void UpdateText()
        {
            this.Text = "";

            // check that we have the needed properties filled out
            if ((sourceBinding == null) ||
                (lookupTable == null) ||
                (lookupColumnValueName == "") ||
                (lookupColumnDisplayName == "") ||
                (sourceBinding.Current == null))
                return;

            // update text (with or without formatting)
            DataRowView row = (DataRowView)sourceBinding.Current;
            //2018103
            if (sourceColumnName == "VatRate")
            {
                if (row[sourceColumnName].ToString() == "")
                    row[sourceColumnName] = '0';
            }  
            string filter = string.Format(
                "{0} = '{1}'",
                lookupColumnValueName,
                row[sourceColumnName]);
            DataRow[] rows = lookupTable.Select(filter);
            if (rows.Length > 0)
            {
                object o = rows[0][LookupColumnDisplayName];
                if(lookupColumnDisplayFormat.Length > 0)
                    this.Text = String.Format("{0:"+lookupColumnDisplayFormat+"}", o);
                else
                    this.Text = o.ToString();
            }
        }

        #endregion
    }
}
