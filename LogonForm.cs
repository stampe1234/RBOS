using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace RBOS
{
	/// <summary>
	/// Summary description for Logon.
	/// </summary>
	public class LogonForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lbUser;
		private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbHeader;
        private TextBox txtUsername;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public LogonForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogonForm));
            this.lbUser = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbHeader = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Location = new System.Drawing.Point(72, 48);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(59, 13);
            this.lbUser.TabIndex = 0;
            this.lbUser.Text = "[username]";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(72, 96);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(58, 13);
            this.lbPassword.TabIndex = 1;
            this.lbPassword.Text = "[password]";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(75, 112);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(152, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(247, 73);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "[ok]";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(247, 102);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "[cancel]";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // lbHeader
            // 
            this.lbHeader.AutoSize = true;
            this.lbHeader.Location = new System.Drawing.Point(72, 24);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(46, 13);
            this.lbHeader.TabIndex = 7;
            this.lbHeader.Text = "[header]";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(75, 64);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(152, 20);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsername_KeyDown);
            // 
            // LogonForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(344, 150);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lbHeader);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LogonForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retail-BOS";
            this.Load += new System.EventHandler(this.LogonForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		// Logon form's load event
		private void LogonForm_Load(object sender, System.EventArgs e)
		{
#if RBA
            this.Text = this.Text + " RBA";
#endif
#if FSD
            this.Text = this.Text + " BFI";
#endif

            // localize controls
			this.Text = this.Text + " " + db.GetLangString("LogonForm.Title");
			lbUser.Text = db.GetLangString("LogonForm.UserLabel");
			lbPassword.Text = db.GetLangString("LogonForm.PasswordLabel");
			btnOk.Text = db.GetLangString("Application.Ok");
			btnCancel.Text = db.GetLangString("Application.Cancel");
			lbHeader.Text = db.GetLangString("LogonForm.HeaderLabel");
		}

		// cancel button click event - will cancel the starting of the application
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		// ok button click event - verify the user
		private void btnOk_Click(object sender, System.EventArgs e)
		{
			if(UserLogon.VerifyUserAndSelectDatabase(txtUsername.Text,txtPassword.Text))
				Close(); // user approved, so close the logon form
			else
				MessageBox.Show(db.GetLangString("LogonForm.ErrorLoginMsg"));
		}

		// username keydown event
		private void txtUsername_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			// if Enter key is hit, focus password field
			if((txtUsername.Text != "") && (e.KeyCode == Keys.Enter) && (txtPassword.CanFocus))
				txtPassword.Focus();
		}

		// password keydown event
		private void txtPassword_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			// if Enter key is hit and both username and password
			// fields are filled in, try to login
			if((e.KeyCode == Keys.Enter) && (txtUsername.Text != "") && (txtPassword.Text != ""))
			{
				if(UserLogon.VerifyUserAndSelectDatabase(txtUsername.Text,txtPassword.Text))
					Close(); // user approed, so close the logon form
				else
				{
					MessageBox.Show(db.GetLangString("LogonForm.ErrorLoginMsg"));
					if(txtPassword.CanFocus)
						txtPassword.Focus();
					txtPassword.SelectAll();
				}
			}
		}
	}
}
