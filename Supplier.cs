using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace RBOS
{
	/// <summary>
	/// Summary description for Suppliers.
	/// </summary>
	public class Supplier : System.Windows.Forms.Form
    {
        #region Private variables

        // list of loaded supplier IDs from db
		private ArrayList suppliers = null;

		// read by cancel button click event,
		// set by new and edit buttons click events
		private int lastCancelIndex = -1;

		private System.Windows.Forms.ComboBox ddSupplier;
		private System.Windows.Forms.Label lbSelectSupplier;
		private System.Windows.Forms.Label lbDescription;
		private System.Windows.Forms.Label lbSupplierID;
		private System.Windows.Forms.Label lbContact;
		private System.Windows.Forms.Label lbFaxNumber;
		private System.Windows.Forms.Label lbPhoneNumber;
		private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtContact;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnSaveClose;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private Label lbSendMode;
        private ComboBox comboSendMode;
        private Label lbOrderFileFormat;
        private ComboBox comboOrderFileFormat;
        private ComboBox comboFTPAccount;
        private Label lbFTPAccount;
        private AdminDataSet dsAdmin;
        private BindingSource bindingLookupFTPAccounts;
        private RBOS.AdminDataSetTableAdapters.LookupFTPAccountsTableAdapter adapterLookupFTPAccounts;
        private Label lbLLSupplierNo;
        private TextBox txtLLSupplierNo;
        private TextBox txtSupplierID;
        private TextBox txtPhone;
        private TextBox txtFax;
        private IContainer components;

        #endregion

        #region Constructor
        public Supplier()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
        }
        #endregion

        #region Dispose
        /// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
        }
        #endregion

        #region Windows Form Designer generated code
        /// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Supplier));
            this.ddSupplier = new System.Windows.Forms.ComboBox();
            this.lbSelectSupplier = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbSupplierID = new System.Windows.Forms.Label();
            this.lbContact = new System.Windows.Forms.Label();
            this.lbFaxNumber = new System.Windows.Forms.Label();
            this.lbPhoneNumber = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lbSendMode = new System.Windows.Forms.Label();
            this.comboSendMode = new System.Windows.Forms.ComboBox();
            this.lbOrderFileFormat = new System.Windows.Forms.Label();
            this.comboOrderFileFormat = new System.Windows.Forms.ComboBox();
            this.comboFTPAccount = new System.Windows.Forms.ComboBox();
            this.bindingLookupFTPAccounts = new System.Windows.Forms.BindingSource(this.components);
            this.dsAdmin = new RBOS.AdminDataSet();
            this.lbFTPAccount = new System.Windows.Forms.Label();
            this.adapterLookupFTPAccounts = new RBOS.AdminDataSetTableAdapters.LookupFTPAccountsTableAdapter();
            this.lbLLSupplierNo = new System.Windows.Forms.Label();
            this.txtLLSupplierNo = new System.Windows.Forms.TextBox();
            this.txtSupplierID = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtFax = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupFTPAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAdmin)).BeginInit();
            this.SuspendLayout();
            // 
            // ddSupplier
            // 
            this.ddSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddSupplier.Location = new System.Drawing.Point(18, 31);
            this.ddSupplier.Name = "ddSupplier";
            this.ddSupplier.Size = new System.Drawing.Size(384, 24);
            this.ddSupplier.TabIndex = 0;
            this.ddSupplier.SelectedIndexChanged += new System.EventHandler(this.ddSupplier_SelectedIndexChanged);
            // 
            // lbSelectSupplier
            // 
            this.lbSelectSupplier.AutoSize = true;
            this.lbSelectSupplier.Location = new System.Drawing.Point(14, 10);
            this.lbSelectSupplier.Name = "lbSelectSupplier";
            this.lbSelectSupplier.Size = new System.Drawing.Size(107, 17);
            this.lbSelectSupplier.TabIndex = 1;
            this.lbSelectSupplier.Text = "[select supplier]";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(142, 111);
            this.txtDescription.MaxLength = 50;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(260, 22);
            this.txtDescription.TabIndex = 2;
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(142, 141);
            this.txtContact.MaxLength = 50;
            this.txtContact.Name = "txtContact";
            this.txtContact.ReadOnly = true;
            this.txtContact.Size = new System.Drawing.Size(260, 22);
            this.txtContact.TabIndex = 3;
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(19, 114);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(85, 17);
            this.lbDescription.TabIndex = 7;
            this.lbDescription.Text = "[description]";
            this.lbDescription.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbSupplierID
            // 
            this.lbSupplierID.Location = new System.Drawing.Point(19, 81);
            this.lbSupplierID.Name = "lbSupplierID";
            this.lbSupplierID.Size = new System.Drawing.Size(115, 23);
            this.lbSupplierID.TabIndex = 8;
            this.lbSupplierID.Text = "[supplier id]";
            this.lbSupplierID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbContact
            // 
            this.lbContact.AutoSize = true;
            this.lbContact.Location = new System.Drawing.Point(19, 144);
            this.lbContact.Name = "lbContact";
            this.lbContact.Size = new System.Drawing.Size(62, 17);
            this.lbContact.TabIndex = 9;
            this.lbContact.Text = "[contact]";
            this.lbContact.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbFaxNumber
            // 
            this.lbFaxNumber.Location = new System.Drawing.Point(19, 201);
            this.lbFaxNumber.Name = "lbFaxNumber";
            this.lbFaxNumber.Size = new System.Drawing.Size(115, 23);
            this.lbFaxNumber.TabIndex = 10;
            this.lbFaxNumber.Text = "[fax number]";
            this.lbFaxNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbPhoneNumber
            // 
            this.lbPhoneNumber.Location = new System.Drawing.Point(19, 171);
            this.lbPhoneNumber.Name = "lbPhoneNumber";
            this.lbPhoneNumber.Size = new System.Drawing.Size(115, 23);
            this.lbPhoneNumber.TabIndex = 11;
            this.lbPhoneNumber.Text = "[phone number]";
            this.lbPhoneNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.Location = new System.Drawing.Point(320, 318);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 26);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "[close]";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(224, 318);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 26);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.Text = "[edit]";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveClose.Location = new System.Drawing.Point(224, 330);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(87, 28);
            this.btnSaveClose.TabIndex = 9;
            this.btnSaveClose.Text = "[saveclose]";
            this.btnSaveClose.Visible = false;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(320, 330);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 27);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "[cancel]";
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(128, 318);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 26);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "[delete]";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(31, 318);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(90, 26);
            this.btnNew.TabIndex = 13;
            this.btnNew.Text = "[new]";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lbSendMode
            // 
            this.lbSendMode.AutoSize = true;
            this.lbSendMode.Location = new System.Drawing.Point(19, 234);
            this.lbSendMode.Name = "lbSendMode";
            this.lbSendMode.Size = new System.Drawing.Size(86, 17);
            this.lbSendMode.TabIndex = 15;
            this.lbSendMode.Text = "[send mode]";
            // 
            // comboSendMode
            // 
            this.comboSendMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSendMode.Enabled = false;
            this.comboSendMode.FormattingEnabled = true;
            this.comboSendMode.Items.AddRange(new object[] {
            "FAX",
            "FTP"});
            this.comboSendMode.Location = new System.Drawing.Point(142, 231);
            this.comboSendMode.Name = "comboSendMode";
            this.comboSendMode.Size = new System.Drawing.Size(67, 24);
            this.comboSendMode.TabIndex = 6;
            this.comboSendMode.SelectedIndexChanged += new System.EventHandler(this.comboSendMode_SelectedIndexChanged);
            // 
            // lbOrderFileFormat
            // 
            this.lbOrderFileFormat.AutoSize = true;
            this.lbOrderFileFormat.Location = new System.Drawing.Point(19, 265);
            this.lbOrderFileFormat.Name = "lbOrderFileFormat";
            this.lbOrderFileFormat.Size = new System.Drawing.Size(116, 17);
            this.lbOrderFileFormat.TabIndex = 17;
            this.lbOrderFileFormat.Text = "[order file format]";
            // 
            // comboOrderFileFormat
            // 
            this.comboOrderFileFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOrderFileFormat.Enabled = false;
            this.comboOrderFileFormat.FormattingEnabled = true;
            this.comboOrderFileFormat.Items.AddRange(new object[] {
            "NOR"});
            this.comboOrderFileFormat.Location = new System.Drawing.Point(142, 262);
            this.comboOrderFileFormat.Name = "comboOrderFileFormat";
            this.comboOrderFileFormat.Size = new System.Drawing.Size(67, 24);
            this.comboOrderFileFormat.TabIndex = 7;
            // 
            // comboFTPAccount
            // 
            this.comboFTPAccount.DataSource = this.bindingLookupFTPAccounts;
            this.comboFTPAccount.DisplayMember = "AccountName";
            this.comboFTPAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFTPAccount.Enabled = false;
            this.comboFTPAccount.FormattingEnabled = true;
            this.comboFTPAccount.Location = new System.Drawing.Point(142, 293);
            this.comboFTPAccount.Name = "comboFTPAccount";
            this.comboFTPAccount.Size = new System.Drawing.Size(260, 24);
            this.comboFTPAccount.TabIndex = 8;
            this.comboFTPAccount.ValueMember = "ID";
            // 
            // bindingLookupFTPAccounts
            // 
            this.bindingLookupFTPAccounts.DataMember = "LookupFTPAccounts";
            this.bindingLookupFTPAccounts.DataSource = this.dsAdmin;
            // 
            // dsAdmin
            // 
            this.dsAdmin.DataSetName = "AdminDataSet";
            this.dsAdmin.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lbFTPAccount
            // 
            this.lbFTPAccount.AutoSize = true;
            this.lbFTPAccount.Location = new System.Drawing.Point(19, 297);
            this.lbFTPAccount.Name = "lbFTPAccount";
            this.lbFTPAccount.Size = new System.Drawing.Size(86, 17);
            this.lbFTPAccount.TabIndex = 19;
            this.lbFTPAccount.Text = "[ftp account]";
            // 
            // adapterLookupFTPAccounts
            // 
            this.adapterLookupFTPAccounts.ClearBeforeFill = true;
            // 
            // lbLLSupplierNo
            // 
            this.lbLLSupplierNo.Location = new System.Drawing.Point(19, 324);
            this.lbLLSupplierNo.Name = "lbLLSupplierNo";
            this.lbLLSupplierNo.Size = new System.Drawing.Size(115, 23);
            this.lbLLSupplierNo.TabIndex = 21;
            this.lbLLSupplierNo.Text = "[ll supplier no]";
            this.lbLLSupplierNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLLSupplierNo
            // 
            this.txtLLSupplierNo.Location = new System.Drawing.Point(142, 325);
            this.txtLLSupplierNo.MaxLength = 50;
            this.txtLLSupplierNo.Name = "txtLLSupplierNo";
            this.txtLLSupplierNo.ReadOnly = true;
            this.txtLLSupplierNo.Size = new System.Drawing.Size(67, 22);
            this.txtLLSupplierNo.TabIndex = 22;
            // 
            // txtSupplierID
            // 
            this.txtSupplierID.Location = new System.Drawing.Point(142, 81);
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.ReadOnly = true;
            this.txtSupplierID.Size = new System.Drawing.Size(44, 22);
            this.txtSupplierID.TabIndex = 23;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(142, 171);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(67, 22);
            this.txtPhone.TabIndex = 24;
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(142, 201);
            this.txtFax.Name = "txtFax";
            this.txtFax.ReadOnly = true;
            this.txtFax.Size = new System.Drawing.Size(67, 22);
            this.txtFax.TabIndex = 25;
            // 
            // Supplier
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(426, 352);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtSupplierID);
            this.Controls.Add(this.txtLLSupplierNo);
            this.Controls.Add(this.lbLLSupplierNo);
            this.Controls.Add(this.comboFTPAccount);
            this.Controls.Add(this.lbFTPAccount);
            this.Controls.Add(this.comboOrderFileFormat);
            this.Controls.Add(this.lbOrderFileFormat);
            this.Controls.Add(this.comboSendMode);
            this.Controls.Add(this.lbSendMode);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lbSelectSupplier);
            this.Controls.Add(this.ddSupplier);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.lbSupplierID);
            this.Controls.Add(this.lbContact);
            this.Controls.Add(this.lbFaxNumber);
            this.Controls.Add(this.lbPhoneNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(432, 323);
            this.Name = "Supplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[supplier]";
            this.Load += new System.EventHandler(this.Suppliers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingLookupFTPAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAdmin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        #region ENUM: Mode
        enum Mode
		{
			View,
            Edit,
            New
        }
        #endregion

        #region METHOD: SetControlsMode
        /// <summary>
		/// Sets edit mode on/off
		/// </summary>
		/// <param name="editMode"></param>
		private void SetControlsMode(Mode mode)
		{
			bool viewMode = (mode == Mode.View);
			bool editMode = (mode == Mode.Edit);
			bool newMode = (mode == Mode.New);

			// data fields
			txtContact.ReadOnly = viewMode;
			txtDescription.ReadOnly = viewMode;
			txtFax.ReadOnly = viewMode;
			txtPhone.ReadOnly = viewMode;
			txtSupplierID.ReadOnly = (viewMode || editMode);
            txtLLSupplierNo.ReadOnly = viewMode;
            comboSendMode.Enabled = !viewMode;

            ToggleSendModeRelatedCombos();

			// buttons
			btnEdit.Visible = viewMode;
			btnEdit.Enabled = (viewMode && ddSupplier.SelectedIndex != -1);
			btnClose.Visible = viewMode;
            btnSaveClose.Location = btnEdit.Location;
            btnCancel.Location = btnClose.Location;
			btnSaveClose.Visible = (editMode || newMode);
			btnCancel.Visible = (editMode || newMode);
			btnDelete.Enabled = viewMode && (ddSupplier.SelectedIndex != -1);
			btnNew.Enabled = viewMode;
		
			// drop-down list
			ddSupplier.Enabled = viewMode;
        }
        #endregion

        #region METHOD: LoadSupplierList
        /// <summary>
		/// Loads internal list of supplierIDs from database and
		/// fills supplier list drop-down box with descriptions
		/// </summary>
		private void LoadSupplierList()
		{			
			// load supplier IDs from database into a local list
			suppliers = dbSupplier.GetSupplierIDs();

			// fill drop-down box with supplier id and descriptions (keeping same indexes as local list of ids)
			ddSupplier.Items.Clear();
			foreach(object o in suppliers)
			{
				int supplierID = int.Parse(o.ToString());
				DataRow row = dbSupplier.GetSupplier(supplierID);
				// text is formatted so id has at least 3 characters (at the moment with prepended zeros)
				// followed by a space and then comes the description
				//string formattedDesc = String.Format("{0,3:d} {1}",row["SupplierID"],row["Description"]);
				string formattedDesc = String.Format("{0:000} {1}",row["SupplierID"],row["Description"]);
				ddSupplier.Items.Add(formattedDesc);
			}
        }
        #endregion

        #region METHOD: NoSupplierSelected
        /// <summary>
        /// Sets selected index of supplier drop-down list to -1
        /// and clears all edit fields on the form
        /// </summary>
        private void NoSupplierSelected()
        {
            ddSupplier.SelectedIndex = -1;
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = "";
                else if (ctrl is ComboBox)
                    ((ComboBox)ctrl).SelectedIndex = -1;
            }
        }
        #endregion

        #region METHOD: ValidateFields
        /// <summary>
        /// 
        /// </summary>
        /// <param name="editing"></param>
        /// <returns></returns>
        private string ValidateFields(bool editing)
        {
            // some fields already have input masks and basic validation set by control properties

            string msg = "";
            if (editing)
            {
            }
            else
            {
                // SupplierID must be greater than zero
                if (tools.object2int(txtSupplierID.Text) <= 0)
                    msg += db.GetLangString("SupplierForm.Validate.SupplierIDGreaterThanZero") + "\n";
                // SupplierID may not already exist in database
                if (dbSupplier.SupplierExists(tools.object2int(txtSupplierID.Text)))
                    msg += db.GetLangString("SupplierForm.Validate.SupplierIDAlreadyExists") + "\n";
            }

            // description cannot be empty
            if (txtDescription.Text == "")
                msg += db.GetLangString("SupplierForm.Validate.DescriptionEmpty") + "\n";
            // sendmode must be selected
            if (comboSendMode.SelectedItem == null)
                msg += db.GetLangString("SupplierForm.Validate.SendModeMustBeSpecified");
            if (tools.object2string(comboSendMode.SelectedItem) == "FTP")
            {
                // if selected sendmode is FTP,
                // OrderFileFormat and FTPAccound must be selected
                if (comboOrderFileFormat.SelectedItem == null)
                    msg += db.GetLangString("SupplierForm.Validate.OFFMustBeSpecified");
                if (comboFTPAccount.SelectedItem == null)
                    msg += db.GetLangString("SupplierForm.Validate.FTPAccountMustBeSpecified");
            }

            // display any errors and return whether errors occured
            return msg;
        }
        #endregion

        #region METHOD: ToggleSendModeRelatedCombos
        /// <summary>
        /// Toggle enabled and values on comboboxes
        /// OrderFileFormat and FTPAccount according
        /// to the state of the SendMode combobox
        /// </summary>
        private void ToggleSendModeRelatedCombos()
        {
            if ((comboSendMode.SelectedItem == null) ||
                (tools.object2string(comboSendMode.SelectedItem) != "FTP"))
            {
                // FTP not selected
                comboOrderFileFormat.SelectedIndex = -1;
                comboOrderFileFormat.Enabled = false;
                comboFTPAccount.SelectedIndex = -1;
                comboFTPAccount.Enabled = false;
            }
            else
            {
                // FTP selected

                comboOrderFileFormat.Enabled = comboSendMode.Enabled;
                comboFTPAccount.Enabled = comboSendMode.Enabled;

                // if only one OrderFileFormat exists
                // automatically select that format
                if (comboOrderFileFormat.Items.Count == 1)
                    comboOrderFileFormat.SelectedIndex = 0;

                // if only one FTPAccount exists
                // automatically select that account
                if (comboFTPAccount.Items.Count == 1)
                    comboFTPAccount.SelectedIndex = 0;
            }
        }
        #endregion

        // form load event
		private void Suppliers_Load(object sender, System.EventArgs e)
		{
            // load FTP accounts lookup
            adapterLookupFTPAccounts.Connection = db.Connection;
            adapterLookupFTPAccounts.Fill(dsAdmin.LookupFTPAccounts);

			try
			{
				this.SuspendLayout();

				// localize controls
				lbSelectSupplier.Text = db.GetLangString("SupplierForm.SelectSupplierLabel");
				lbSupplierID.Text = db.GetLangString("SupplierForm.SupplierIDLabel");
				lbDescription.Text = db.GetLangString("SupplierForm.DescriptionLabel");
				lbContact.Text = db.GetLangString("SupplierForm.ContactLabel");
				lbPhoneNumber.Text = db.GetLangString("SupplierForm.PhoneLabel");
				lbFaxNumber.Text = db.GetLangString("SupplierForm.FaxLabel");
                lbSendMode.Text = db.GetLangString("SupplierForm.SendModeLabel");
                lbOrderFileFormat.Text = db.GetLangString("SupplierForm.OrderFileFormat");
                lbFTPAccount.Text = db.GetLangString("SupplierForm.FTPAccount");
				btnClose.Text = db.GetLangString("Application.Close");
				btnEdit.Text = db.GetLangString("Application.Edit");
				btnSaveClose.Text = db.GetLangString("Application.SaveClose");
				btnCancel.Text = db.GetLangString("Application.Cancel");
				btnDelete.Text = db.GetLangString("Application.Delete");
				btnNew.Text = db.GetLangString("Application.New");
                lbLLSupplierNo.Text = db.GetLangString("SupplierForm.lbLLSupplierNo");

				LoadSupplierList();
			}
			finally
			{
				this.ResumeLayout();
			}
        }

        // supplier drop-down index changed event - load supplier data from database
		private void ddSupplier_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// only try to load supplier data if a valid supplier is selected
			if(ddSupplier.SelectedIndex == -1) return;

			// use local list of supplier IDs and the index of the selected supplier in the dropdown box
			int supplierID = int.Parse(suppliers[ddSupplier.SelectedIndex].ToString());
			DataRow row = dbSupplier.GetSupplier(supplierID);
			if(row != null)
			{
				txtSupplierID.Text = row["SupplierID"].ToString();
				txtDescription.Text = row["Description"].ToString();
				txtContact.Text = row["Contact"].ToString();
				txtPhone.Text = row["PhoneNumber"].ToString();
				txtFax.Text = row["FaxNumber"].ToString();
                comboSendMode.SelectedItem = row["SendMode"].ToString();
                comboOrderFileFormat.SelectedItem = row["OrderFileFormat"].ToString();
                comboFTPAccount.SelectedValue = tools.object2int(row["FTPAccountID"]);
                txtLLSupplierNo.Text = row["LLSupplierNo"].ToString();
			}

			SetControlsMode(Mode.View);
		}

		// close button click event
		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		// edit button click event
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			// keep the last selected supplier index, as
			// this is need if user cancels the new action
			lastCancelIndex = ddSupplier.SelectedIndex;
			// set edit mode
			SetControlsMode(Mode.Edit);
		}

		// cancel button click event
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			// when user clicks the cancel button, we want to reset the
			// entered data to whatever the current suppliers data are.
			// this is done by deslecting and reselecting the supplier in
			// the dropdown list, so data are re-read from database
			NoSupplierSelected();
			ddSupplier.SelectedIndex = lastCancelIndex;
			SetControlsMode(Mode.View);
        }

        // saveclose button click event
		private void btnSaveClose_Click(object sender, System.EventArgs e)
		{

			// validate fields for both edit and new

			if(ddSupplier.SelectedIndex != -1)
			{
				// edit mode - supplier is selected in drop-down box

				string msg = ValidateFields(true);
				if(msg != "")
				{
					MessageBox.Show(this,msg,"",MessageBoxButtons.OK);
					if(txtDescription.CanFocus)
						txtDescription.Focus();
					return;
				}

				// fields validated so continue to edit data in database

				// save data from all fields
				dbSupplier.UpdateSupplier(
					tools.object2int(txtSupplierID.Text),
					txtDescription.Text,
					txtContact.Text,
					txtPhone.Text,
					txtFax.Text,
                    comboSendMode.SelectedItem.ToString(),
                    tools.object2string(comboOrderFileFormat.SelectedItem),
                    tools.object2int(comboFTPAccount.SelectedValue),
                    tools.object2int(txtLLSupplierNo.Text));

				// if the supplier description has changed, reload drop-down box
				DataRow row = dbSupplier.GetSupplier(tools.object2int(txtSupplierID.Text));
				if((row != null) && (row["Description"].ToString() != ddSupplier.Text))
				{
					int i = ddSupplier.SelectedIndex;
					LoadSupplierList();
					// restore selected index after rebuilding the drop-down list
					ddSupplier.SelectedIndex = i;
				}
			}
			else
			{
				// new mode - no supplier is selected in drop-down list

				// validate fields before attempting to insert new supplier
				string msg = ValidateFields(false);
				if(msg != "")
				{
					MessageBox.Show(this,msg,"",MessageBoxButtons.OK);
					if(txtSupplierID.CanFocus)
						txtSupplierID.Focus();
					return;
				 }

				// fields validated so continue to insert data in database

				// save data from all fields
				dbSupplier.NewSupplier(
					tools.object2int(txtSupplierID.Text),
					txtDescription.Text,
					txtContact.Text,
					txtPhone.Text,
					txtFax.Text,
                    comboSendMode.SelectedItem.ToString(),
                    tools.object2string(comboOrderFileFormat.SelectedItem),
                    tools.object2int(comboFTPAccount.SelectedValue),
                    tools.object2int(txtLLSupplierNo.Text));

				// reload drop-down list
				LoadSupplierList();

				// select the new supplier in the drop-down list
				for(int i=0; i<suppliers.Count; i++)
				{
					if(int.Parse(suppliers[i].ToString()) == tools.object2int(txtSupplierID.Text))
					{
						ddSupplier.SelectedIndex = i;
						break;
					}
				}
			}

			// set view mode
			SetControlsMode(Mode.View);
		}

		// delete button click event
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			// user is asked to confirm the delete
			if(MessageBox.Show(this,db.GetLangString("SupplierForm.DeleteConfirmMsg"),"",MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				dbSupplier.DeleteSupplier(tools.object2int(txtSupplierID.Text));
				LoadSupplierList();
				NoSupplierSelected();
				SetControlsMode(Mode.View);
			}
		}

		// new button click event
		private void btnNew_Click(object sender, System.EventArgs e)
		{
			// keep the last selected supplier index, as
			// this is need if user cancels the new action
			lastCancelIndex = ddSupplier.SelectedIndex;

			// clear fields and deselect supplier in drop-down list
			NoSupplierSelected();

			// focus the first editable field
			if(txtSupplierID.CanFocus)
				txtSupplierID.Focus();
			
			// set new mode
			SetControlsMode(Mode.New);
		}
        
        // comboSendMode selected index changed event
        private void comboSendMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToggleSendModeRelatedCombos();
        }
    }
}
