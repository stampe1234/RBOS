using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Resources;
using System.Globalization;
using System.Drawing.Drawing2D;

namespace RBOS
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		#region Attributes, constructor and Dispose

		private TreeNode rightSelectedNodeTreeview = null;
		private TreeNode rightSelectedNodeFavorites = null;
		private System.Windows.Forms.TreeView twMenu;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.ContextMenu contextTreeview;
		private System.Windows.Forms.MenuItem contextTreeviewExpandAll;
		private System.Windows.Forms.MenuItem contextTreeviewCollapseAll;
		private System.Windows.Forms.Splitter splitterTreeFav;
		private System.Windows.Forms.Splitter splitterMain;
		private System.Windows.Forms.Panel panelTreeFav;
		private System.Windows.Forms.TreeView favorites;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.ContextMenu contextFavorites;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.ImageList treeviewImages;
        private ToolStripContainer toolStripContainer1;
        private ToolStrip toolStripShortcuts;
        private MenuStrip menuStripMain;
        private ToolStripMenuItem filesToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem langToolStripMenuItem;
        private ToolStripMenuItem langenToolStripMenuItem;
        private ToolStripMenuItem langdaToolStripMenuItem;
        private ToolStripMenuItem supportMenu;
        private ToolStripMenuItem subCategoryToolStripMenuItem;
        private ToolStripMenuItem importEPDataToolStripMenuItem;
        private ToolStrip toolStripDummy;
        private ToolStripMenuItem rSMMSMImportedToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem1;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Timer timerStatusBarMsgClearing;
        private ToolStripMenuItem testFormToolStripMenuItem1;
        private ToolStripMenuItem resetbarsToolStripMenuItem;
        private ToolStripMenuItem sætProgrammetTil1024x768ToolStripMenuItem;
        private ToolStripMenuItem payrollModuleConfigurationToolStripMenuItem;
        private ToolStripMenuItem menuitemSkiftStation;
        private System.ComponentModel.IContainer components;

		public MainForm()
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
				if (components != null) 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.treeviewImages = new System.Windows.Forms.ImageList(this.components);
            this.twMenu = new System.Windows.Forms.TreeView();
            this.contextTreeview = new System.Windows.Forms.ContextMenu();
            this.contextTreeviewExpandAll = new System.Windows.Forms.MenuItem();
            this.contextTreeviewCollapseAll = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.panelTreeFav = new System.Windows.Forms.Panel();
            this.splitterTreeFav = new System.Windows.Forms.Splitter();
            this.favorites = new System.Windows.Forms.TreeView();
            this.contextFavorites = new System.Windows.Forms.ContextMenu();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.splitterMain = new System.Windows.Forms.Splitter();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.langToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.langenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.langdaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supportMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.payrollModuleConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rSMMSMImportedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importEPDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testFormToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.resetbarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sætProgrammetTil1024x768ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemSkiftStation = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripShortcuts = new System.Windows.Forms.ToolStrip();
            this.toolStripDummy = new System.Windows.Forms.ToolStrip();
            this.timerStatusBarMsgClearing = new System.Windows.Forms.Timer(this.components);
            this.panelTreeFav.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeviewImages
            // 
            this.treeviewImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeviewImages.ImageStream")));
            this.treeviewImages.TransparentColor = System.Drawing.Color.Transparent;
            this.treeviewImages.Images.SetKeyName(0, "");
            this.treeviewImages.Images.SetKeyName(1, "");
            this.treeviewImages.Images.SetKeyName(2, "");
            this.treeviewImages.Images.SetKeyName(3, "");
            this.treeviewImages.Images.SetKeyName(4, "window.gif");
            this.treeviewImages.Images.SetKeyName(5, "print.gif");
            this.treeviewImages.Images.SetKeyName(6, "printfolder.gif");
            this.treeviewImages.Images.SetKeyName(7, "");
            this.treeviewImages.Images.SetKeyName(8, "");
            this.treeviewImages.Images.SetKeyName(9, "window_greyscale.gif");
            this.treeviewImages.Images.SetKeyName(10, "print_greyscale.gif");
            this.treeviewImages.Images.SetKeyName(11, "printfolder_greyscale.gif");
            // 
            // twMenu
            // 
            this.twMenu.ContextMenu = this.contextTreeview;
            this.twMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.twMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.twMenu.ImageIndex = 0;
            this.twMenu.ImageList = this.treeviewImages;
            this.twMenu.Indent = 19;
            this.twMenu.ItemHeight = 16;
            this.twMenu.Location = new System.Drawing.Point(0, 0);
            this.twMenu.Name = "twMenu";
            this.twMenu.SelectedImageIndex = 0;
            this.twMenu.Size = new System.Drawing.Size(357, 444);
            this.twMenu.TabIndex = 0;
            this.twMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.twMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.twMenu_MouseDown);
            // 
            // contextTreeview
            // 
            this.contextTreeview.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.contextTreeviewExpandAll,
            this.contextTreeviewCollapseAll,
            this.menuItem1});
            this.contextTreeview.Popup += new System.EventHandler(this.contextTreeview_Popup);
            // 
            // contextTreeviewExpandAll
            // 
            this.contextTreeviewExpandAll.Index = 0;
            this.contextTreeviewExpandAll.Text = "[expand all]";
            this.contextTreeviewExpandAll.Click += new System.EventHandler(this.contextTreeviewExpandAll_Click);
            // 
            // contextTreeviewCollapseAll
            // 
            this.contextTreeviewCollapseAll.Index = 1;
            this.contextTreeviewCollapseAll.Text = "[collapse all]";
            this.contextTreeviewCollapseAll.Click += new System.EventHandler(this.contextTreeviewCollapseAll_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 2;
            this.menuItem1.Text = "[add to favorites]";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.statusBar1.Location = new System.Drawing.Point(0, 680);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(1012, 31);
            this.statusBar1.TabIndex = 7;
            // 
            // panelTreeFav
            // 
            this.panelTreeFav.Controls.Add(this.splitterTreeFav);
            this.panelTreeFav.Controls.Add(this.favorites);
            this.panelTreeFav.Controls.Add(this.twMenu);
            this.panelTreeFav.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTreeFav.Location = new System.Drawing.Point(0, 75);
            this.panelTreeFav.Name = "panelTreeFav";
            this.panelTreeFav.Size = new System.Drawing.Size(357, 605);
            this.panelTreeFav.TabIndex = 9;
            // 
            // splitterTreeFav
            // 
            this.splitterTreeFav.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.splitterTreeFav.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterTreeFav.Location = new System.Drawing.Point(0, 444);
            this.splitterTreeFav.Name = "splitterTreeFav";
            this.splitterTreeFav.Size = new System.Drawing.Size(357, 5);
            this.splitterTreeFav.TabIndex = 3;
            this.splitterTreeFav.TabStop = false;
            // 
            // favorites
            // 
            this.favorites.ContextMenu = this.contextFavorites;
            this.favorites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.favorites.ImageIndex = 0;
            this.favorites.ImageList = this.treeviewImages;
            this.favorites.Location = new System.Drawing.Point(0, 444);
            this.favorites.Name = "favorites";
            this.favorites.SelectedImageIndex = 0;
            this.favorites.Size = new System.Drawing.Size(357, 161);
            this.favorites.TabIndex = 2;
            this.favorites.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.favorites_AfterSelect);
            this.favorites.MouseDown += new System.Windows.Forms.MouseEventHandler(this.favorites_MouseDown);
            // 
            // contextFavorites
            // 
            this.contextFavorites.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem3,
            this.menuItem4,
            this.menuItem2});
            this.contextFavorites.Popup += new System.EventHandler(this.contextFavorites_Popup);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 0;
            this.menuItem3.Text = "[move up]";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.Text = "[move down]";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.Text = "[remove from favorites]";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // splitterMain
            // 
            this.splitterMain.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.splitterMain.Location = new System.Drawing.Point(357, 75);
            this.splitterMain.Name = "splitterMain";
            this.splitterMain.Size = new System.Drawing.Size(6, 605);
            this.splitterMain.TabIndex = 10;
            this.splitterMain.TabStop = false;
            this.splitterMain.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitterMain_SplitterMoved);
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1012, 0);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(1012, 75);
            this.toolStripContainer1.TabIndex = 16;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStripMain);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripShortcuts);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripDummy);
            // 
            // menuStripMain
            // 
            this.menuStripMain.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStripMain.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 50);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1012, 33);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.filesToolStripMenuItem.Text = "[files]";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(151, 34);
            this.exitToolStripMenuItem.Text = "[exit]";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.langToolStripMenuItem,
            this.supportMenu,
            this.menuitemSkiftStation});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(78, 29);
            this.toolsToolStripMenuItem.Text = "[tools]";
            // 
            // langToolStripMenuItem
            // 
            this.langToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.langenToolStripMenuItem,
            this.langdaToolStripMenuItem});
            this.langToolStripMenuItem.Name = "langToolStripMenuItem";
            this.langToolStripMenuItem.Size = new System.Drawing.Size(214, 34);
            this.langToolStripMenuItem.Text = "[lang]";
            // 
            // langenToolStripMenuItem
            // 
            this.langenToolStripMenuItem.Name = "langenToolStripMenuItem";
            this.langenToolStripMenuItem.Size = new System.Drawing.Size(185, 34);
            this.langenToolStripMenuItem.Text = "[lang-en]";
            this.langenToolStripMenuItem.Click += new System.EventHandler(this.langenToolStripMenuItem_Click);
            // 
            // langdaToolStripMenuItem
            // 
            this.langdaToolStripMenuItem.Name = "langdaToolStripMenuItem";
            this.langdaToolStripMenuItem.Size = new System.Drawing.Size(185, 34);
            this.langdaToolStripMenuItem.Text = "[lang-da]";
            this.langdaToolStripMenuItem.Click += new System.EventHandler(this.langdaToolStripMenuItem_Click);
            // 
            // supportMenu
            // 
            this.supportMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.payrollModuleConfigurationToolStripMenuItem,
            this.subCategoryToolStripMenuItem,
            this.rSMMSMImportedToolStripMenuItem,
            this.importEPDataToolStripMenuItem,
            this.testFormToolStripMenuItem1,
            this.resetbarsToolStripMenuItem,
            this.sætProgrammetTil1024x768ToolStripMenuItem});
            this.supportMenu.Name = "supportMenu";
            this.supportMenu.Size = new System.Drawing.Size(214, 34);
            this.supportMenu.Text = "[Support]";
            // 
            // payrollModuleConfigurationToolStripMenuItem
            // 
            this.payrollModuleConfigurationToolStripMenuItem.Name = "payrollModuleConfigurationToolStripMenuItem";
            this.payrollModuleConfigurationToolStripMenuItem.Size = new System.Drawing.Size(282, 34);
            this.payrollModuleConfigurationToolStripMenuItem.Text = "Administration";
            this.payrollModuleConfigurationToolStripMenuItem.Click += new System.EventHandler(this.payrollModuleConfigurationToolStripMenuItem_Click);
            // 
            // subCategoryToolStripMenuItem
            // 
            this.subCategoryToolStripMenuItem.Name = "subCategoryToolStripMenuItem";
            this.subCategoryToolStripMenuItem.Size = new System.Drawing.Size(282, 34);
            this.subCategoryToolStripMenuItem.Text = "SubCategory";
            this.subCategoryToolStripMenuItem.Click += new System.EventHandler(this.subCategoryToolStripMenuItem_Click);
            // 
            // rSMMSMImportedToolStripMenuItem
            // 
            this.rSMMSMImportedToolStripMenuItem.Name = "rSMMSMImportedToolStripMenuItem";
            this.rSMMSMImportedToolStripMenuItem.Size = new System.Drawing.Size(282, 34);
            this.rSMMSMImportedToolStripMenuItem.Text = "RSM_MSM_Imported";
            this.rSMMSMImportedToolStripMenuItem.Click += new System.EventHandler(this.rSMMSMImportedToolStripMenuItem_Click);
            // 
            // importEPDataToolStripMenuItem
            // 
            this.importEPDataToolStripMenuItem.Enabled = false;
            this.importEPDataToolStripMenuItem.Name = "importEPDataToolStripMenuItem";
            this.importEPDataToolStripMenuItem.Size = new System.Drawing.Size(282, 34);
            this.importEPDataToolStripMenuItem.Text = "Import EP data";
            this.importEPDataToolStripMenuItem.Visible = false;
            this.importEPDataToolStripMenuItem.Click += new System.EventHandler(this.importEPDataToolStripMenuItem_Click);
            // 
            // testFormToolStripMenuItem1
            // 
            this.testFormToolStripMenuItem1.Name = "testFormToolStripMenuItem1";
            this.testFormToolStripMenuItem1.Size = new System.Drawing.Size(282, 34);
            this.testFormToolStripMenuItem1.Text = "TestForm";
            this.testFormToolStripMenuItem1.Click += new System.EventHandler(this.testFormToolStripMenuItem1_Click);
            // 
            // resetbarsToolStripMenuItem
            // 
            this.resetbarsToolStripMenuItem.Name = "resetbarsToolStripMenuItem";
            this.resetbarsToolStripMenuItem.Size = new System.Drawing.Size(282, 34);
            this.resetbarsToolStripMenuItem.Text = "Reset Bars";
            this.resetbarsToolStripMenuItem.Visible = false;
            // 
            // sætProgrammetTil1024x768ToolStripMenuItem
            // 
            this.sætProgrammetTil1024x768ToolStripMenuItem.Name = "sætProgrammetTil1024x768ToolStripMenuItem";
            this.sætProgrammetTil1024x768ToolStripMenuItem.Size = new System.Drawing.Size(282, 34);
            this.sætProgrammetTil1024x768ToolStripMenuItem.Text = "1024x768";
            this.sætProgrammetTil1024x768ToolStripMenuItem.Visible = false;
            // 
            // menuitemSkiftStation
            // 
            this.menuitemSkiftStation.Name = "menuitemSkiftStation";
            this.menuitemSkiftStation.Size = new System.Drawing.Size(214, 34);
            this.menuitemSkiftStation.Text = "[Skift Station";
            this.menuitemSkiftStation.Click += new System.EventHandler(this.menuitemSkiftStation_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(72, 29);
            this.helpToolStripMenuItem.Text = "[help]";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(171, 34);
            this.helpToolStripMenuItem1.Text = "[help]";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(171, 34);
            this.aboutToolStripMenuItem.Text = "[about]";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripShortcuts
            // 
            this.toolStripShortcuts.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripShortcuts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripShortcuts.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripShortcuts.Location = new System.Drawing.Point(64, 0);
            this.toolStripShortcuts.Name = "toolStripShortcuts";
            this.toolStripShortcuts.Size = new System.Drawing.Size(102, 25);
            this.toolStripShortcuts.TabIndex = 1;
            this.toolStripShortcuts.Text = "toolStrip2";
            this.toolStripShortcuts.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripShortcuts_ItemClicked);
            // 
            // toolStripDummy
            // 
            this.toolStripDummy.AutoSize = false;
            this.toolStripDummy.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripDummy.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripDummy.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripDummy.Location = new System.Drawing.Point(6, 25);
            this.toolStripDummy.Name = "toolStripDummy";
            this.toolStripDummy.Size = new System.Drawing.Size(43, 25);
            this.toolStripDummy.TabIndex = 2;
            // 
            // timerStatusBarMsgClearing
            // 
            this.timerStatusBarMsgClearing.Interval = 10000;
            this.timerStatusBarMsgClearing.Tick += new System.EventHandler(this.timerStatusBarMsgClearing_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1012, 711);
            this.Controls.Add(this.splitterMain);
            this.Controls.Add(this.panelTreeFav);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retail-BOS";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelTreeFav.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        #region METHOD: IsFormOpen
        /// <summary>
        /// Tells whether a form is open.
        /// </summary>
        public bool IsFormOpen(string formName)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == formName)
                    return true;
            }

            return false;
        }
        #endregion

        #region METHOD: IsFormOpen
        /// <summary>
        /// Tells whether a form is open.
        /// </summary>
        public bool IsFormOpen(System.Type formType)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == formType)
                    return true;
            }

            return false;
        }
        #endregion

        #region METHOD: CreateNode
        /// <summary>
		/// @@@ TO DOCUMENT
		/// </summary>
		/// <param name="text"></param>
		/// <param name="tag">
		/// A hexidecimal string value and a prefixed string "TreeMenu". The hex numbers signifies where in the
		/// tree the node is placed. For each pair of numbers, starting from left,
		/// these numbers represent a sequence per level. For instance, "TreeMenu01" means
		/// level 1 first item. "TreeMenu0103" means level 2 third item, below level 1 first item.
		/// The value is used to determine what action to perform when clicking on the node
		/// and to determine the access level for a user group.
		/// As a side-effect, the value can be used to tell where in the treeview the node is placed.
		/// The tag value is written to the node's Tag property.
		///	</param>
		/// <param name="imageIndex"></param>
		/// <param name="selectedImageIndex"></param>
		/// <returns></returns>
		private TreeNode CreateNode(string text, string tag, int imageIndex, int selectedImageIndex)
		{
			TreeNode n = new TreeNode(text,imageIndex,selectedImageIndex);
			n.Tag = tag;
			return n;
        }
        #endregion

        #region METHOD: BuildTreeMenu
        public void BuildTreeMenu(string lang)
		{
			twMenu.Nodes.Clear();
			int L0,L1,L2;
			
			// build root
#if RBA 
            L0 = twMenu.Nodes.Add(CreateNode(db.GetLangString("TreeMenu0.RBA"),"TreeMenu0.RBA",2,2));
#elif FSD
            L0 = twMenu.Nodes.Add(CreateNode(db.GetLangString("TreeMenu0.FSD"),"TreeMenu0.FSD",2,2));
#else
			L0 = twMenu.Nodes.Add(CreateNode(db.GetLangString("TreeMenu0"),"TreeMenu0",2,2));
#endif

			// build Løn
			L1 = twMenu.Nodes[L0].Nodes.Add(CreateNode(db.GetLangString("TreeMenu01"),"TreeMenu01",0,1)); // Løn
            if (db.GetConfigStringAsBool("PayrollModuleActive"))
            {
                L2 = twMenu.Nodes[L0].Nodes[L1].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Loen.Stamdata"), "TreeMenu.Loen.Stamdata", 0, 1));
                 twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Loen.Stamdata.Medarbejder"), "TreeMenu.Loen.Stamdata.Medarbejder", 4, 4));
                 twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Loen.Stamdata.Loenperioder"), "TreeMenu.Loen.Stamdata.Loenperioder", 4, 4));
                L2 = twMenu.Nodes[L0].Nodes[L1].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Loen.Indrapportering"), "TreeMenu.Loen.Indrapportering", 0, 1));
                 twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Loen.Indrapportering.Loenreg"), "TreeMenu.Loen.Indrapportering.Loenreg", 4, 4));
                 twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Loen.Indrapportering.Fravaersreg"), "TreeMenu.Loen.Indrapportering.Fravaersreg", 4, 4));
                 twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Loen.Indrapportering.Withdraw"), "TreeMenu.Loen.Indrapportering.Withdraw", 4, 4));
                L2 = twMenu.Nodes[L0].Nodes[L1].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Loen.ImportExport"), "TreeMenu.Loen.ImportExport", 0, 1));
                 twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Loen.ImportExport.DanLeverance"), "TreeMenu.Loen.ImportExport.DanLeverance", 4, 4));
                 twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Loen.Import.TimeReg"), "TreeMenu.Loen.Import.TimeReg", 4, 4));
                L2 = twMenu.Nodes[L0].Nodes[L1].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Loen.Udskrifter"), "TreeMenu.Loen.Udskrifter", 6, 6));
                 twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Loen.Udskrifter.Medarbejder"), "TreeMenu.Loen.Udskrifter.Medarbejder", 5, 5));
                 twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Loen.Udskrifter.SalEmployee"), "TreeMenu.Loen.Udskrifter.SalEmployee", 5, 5));
                 twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Loen.Udskrifter.SalAllEmp"), "TreeMenu.Loen.Udskrifter.SalAllEmp", 5, 5));
                 twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Loen.Udskrifter.SalAlLEmpWeek"), "TreeMenu.Loen.Udskrifter.SalAlLEmpWeek", 5, 5));
                 twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Loen.Udskrifter.SalPerDate"), "TreeMenu.Loen.Udskrifter.SalPerDate", 5, 5));
                 twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Loen.Udskrifter.AbsenseEmp"), "TreeMenu.Loen.Udskrifter.AbsenseEmp", 5, 5));
                 twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Loen.Udskrifter.Withdraw"), "TreeMenu.Loen.Udskrifter.Withdraw", 5, 5));
                 twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Loen.Udskrifter.SalReg"), "TreeMenu.Loen.Udskrifter.SalReg", 5, 5));
                 twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Loen.Udskrifter.LentOutEmp"), "TreeMenu.Loen.Udskrifter.LentOutEmp", 5, 5));
                 twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Loen.Udskrifter.AvgHrsPerWeek"), "TreeMenu.Loen.Udskrifter.AvgHrsPerWeek", 5, 5));
            }

			// build daglig
            if (db.GetConfigStringAsBool("Daily.Enabled"))
            {
                L1 = twMenu.Nodes[L0].Nodes.Add(CreateNode(db.GetLangString("TreeMenu02"), "TreeMenu02", 0, 1));
                L2 = twMenu.Nodes[L0].Nodes[L1].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.EODReconcile"), "TreeMenu.EODReconcile", 4, 4)); // Dagsopgørelse
                L2 = twMenu.Nodes[L0].Nodes[L1].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.EODDebitor"), "TreeMenu.EODDebitor", 4, 4)); // Debitor
#if RBA
             L2 = twMenu.Nodes[L0].Nodes[L1].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.EOD.Readings"), "TreeMenu.EOD.Readings", 0, 1)); // Aflæsninger
              twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.EOD.Readings.WaterPower"), "TreeMenu.EOD.Readings.WaterPower", 4, 4)); // Vand/EL
              twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.EOD.Readings.Wash"), "TreeMenu.EOD.Readings.Wash", 4, 4)); // Vask
             L2 = twMenu.Nodes[L0].Nodes[L1].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.WasteRegistration"), "TreeMenu.WasteRegistration", 4, 4)); // Registrering af afskrivninger
             L2 = twMenu.Nodes[L0].Nodes[L1].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.ForbrugsvareRegistrering"), "TreeMenu.ForbrugsvareRegistrering", 4, 4)); // Registrering af forbrugsvarer
#endif
#if DETAIL
                L2 = twMenu.Nodes[L0].Nodes[L1].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.WasteRegistration"), "TreeMenu.WasteRegistration", 4, 4)); // Registrering af afskrivninger
#endif
                L2 = twMenu.Nodes[L0].Nodes[L1].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.EODReports"), "TreeMenu.EODReports", 6, 6));
                if (db.GetConfigString("RegnskabIF_flag") == "service") // only allow salgsrapport if drs has regnskabs service on this site
                {

                    if (db.GetConfigStringAsBool("DanskeSpil.Enabled"))
                    {
                        twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Item.Reports.DanskeSpil"), "TreeMenu.Item.Reports.DanskeSpil", 5, 5)); // Danske spil rapport
                    }
                    if (db.GetConfigStringAsBool("ShellRecharge.Enabled"))
                    {
                        twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Item.Reports.ShellRecharge"), "TreeMenu.Item.Reports.ShellRecharge", 5, 5)); // Ladedata spil rapport
                    }

                    twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.EOD.Reports.SalesReport"), "TreeMenu.EOD.Reports.SalesReport", 5, 5));
#if DETAIL
                    twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.EOD.Reports.SalesStatReport"), "TreeMenu.EOD.Reports.SalesStatReportDetail", 5, 5));
                    twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.EOD.Reports.AddInfoRpt"), "TreeMenu.EOD.Reports.AddInfoRpt", 5, 5));
#else
                    //20230329
                   

                    twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.EOD.Reports.SalesStatReport"), "TreeMenu.EOD.Reports.SalesStatReport", 5, 5));
#endif
                    //twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.EOD.Reports.SalesStatReport"), "TreeMenu.EOD.Reports.SalesStatReport", 5, 5));
                    //twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.EOD.Reports.SalesDaily"), "TreeMenu.EOD.Reports.SalesDaily", 5, 5));
                }

                twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.EOD.Reports.Debitorlist"), "TreeMenu.EOD.Reports.Debitorlist", 5, 5));
                twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.EOD.Reports.DebStatement"), "TreeMenu.EOD.Reports.DebStatement", 5, 5));
#if RBA
            twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Reports.ItemTransactionsRBA"), "TreeMenu.Reports.ItemTransactionsRBA", 5, 5));
            twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Reports.ItemTransactionsForbrugsvarer"), "TreeMenu.Reports.ItemTransactionsForbrugsvarer", 5, 5));
#endif
            }

#if !DETAIL
            if (db.GetConfigStringAsBool("Items.Enabled"))
            {
#if !RBA
                // build varer
                L1 = twMenu.Nodes[L0].Nodes.Add(CreateNode(db.GetLangString("TreeMenu03"), "TreeMenu03", 0, 1));
                L2 = twMenu.Nodes[L0].Nodes[L1].Nodes.Add(CreateNode(db.GetLangString("TreeMenu0301"), "TreeMenu0301", 4, 4)); // Varekartotek
                L2 = twMenu.Nodes[L0].Nodes[L1].Nodes.Add(CreateNode(db.GetLangString("TreeMenu0302"), "TreeMenu0302", 0, 1));
                twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu030201"), "TreeMenu030201", 4, 4));    // RBOS Bestillinger
                twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu030202"), "TreeMenu030202", 4, 4)); // Bestillingskladde
                L2 = twMenu.Nodes[L0].Nodes[L1].Nodes.Add(CreateNode(db.GetLangString("TreeMenu0303"), "TreeMenu0303", 4, 4));          // Lageroptælling  
                L2 = twMenu.Nodes[L0].Nodes[L1].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Item.InvCountBooked"), "TreeMenu.Item.InvCountBooked", 4, 4)); // InvCountBooked
                L2 = twMenu.Nodes[L0].Nodes[L1].Nodes.Add(CreateNode(db.GetLangString("TreeMenu0304"), "TreeMenu0304", 4, 4));              // Lagerreguleringer
                //20231110              

                bool DOSite2 = (db.GetConfigStringAsBool("DOVersion"));
                if (DOSite2 == false)
                {
                    L2 = twMenu.Nodes[L0].Nodes[L1].Nodes.Add(CreateNode(db.GetLangString("TreeMenu0310"), "TreeMenu0310", 4, 4)); // 'Food/Bakeoff skemaer'
                }
                L2 = twMenu.Nodes[L0].Nodes[L1].Nodes.Add(CreateNode(db.GetLangString("TreeMenu0305"), "TreeMenu0305", 4, 4));              // Leverandører
                L2 = twMenu.Nodes[L0].Nodes[L1].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.SalesPackFuturePricesPrompt"), "TreeMenu.SalesPackFuturePricesPrompt", 4, 4));              // Future Prices Prompt
#endif
#if !RBA
                L2 = twMenu.Nodes[L0].Nodes[L1].Nodes.Add(CreateNode(db.GetLangString("TreeMenu0307"), "TreeMenu0307", 0, 1));            // Import / Eksport
#if !FSD
                twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu030701"), "TreeMenu030701", 4, 4)); // UpdateRSM
#else
              twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu030701_FSD"), "TreeMenu030701_FSD", 4, 4)); // UpdateRCM
#endif
                twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu030702"), "TreeMenu030702", 4, 4)); // Import ISM
                twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu030703"), "TreeMenu030703", 4, 4)); // Export BHHT
                twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu030704"), "TreeMenu030704", 4, 4)); // Import BHHT
#if FSD
              twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.ImportFromLL"), "TreeMenu.ImportFromLL", 4, 4)); // Import Lekkerland
              twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.ImportKampagner"), "TreeMenu.ImportKampagner", 4, 4)); // Import kampagner
              twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.ExportToFVD"), "TreeMenu.ExportToFVD", 4, 4)); // Export FVD
              twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.ExportFVDHeader"), "TreeMenu.ExportFVDHeader", 4, 4)); // Export FVD
              twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.ImportItemsCSV"), "TreeMenu.ImportItemsCSV", 4, 4)); // Import items CSV
#else
                twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.ImportFromFVD"), "TreeMenu.ImportFromFVD", 4, 4)); // Import FSD
#endif
                twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.ExportACN"), "TreeMenu.ExportACN", 4, 4)); // Export ACN
#if FSD
              twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.ExportBFI"), "TreeMenu.ExportBFI", 4, 4)); // Export BFI
#endif

                L2 = twMenu.Nodes[L0].Nodes[L1].Nodes.Add(CreateNode(db.GetLangString("TreeMenu0309"), "TreeMenu0309", 6, 6));
                twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu030901"), "TreeMenu030901", 5, 5)); // Print ItemBasicData
                twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu030902"), "TreeMenu030902", 5, 5)); // Print ItemTransactions
                twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu030903"), "TreeMenu030903", 5, 5)); // Print SalesMargin
                twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu030904"), "TreeMenu030904", 5, 5)); // Print Salg Top/Bund
                //twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu030905"),"TreeMenu030905",5,5));
                twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu030906"), "TreeMenu030906", 5, 5)); // Print Hyldeforkanter
                //twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu030907"),"TreeMenu030907",5,5));
                twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu030908"), "TreeMenu030908", 5, 5)); // Print Lageroptælling
                //twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu030909"),"TreeMenu030909",5,5));
                twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Item.Reports.SubCat"), "TreeMenu.Item.Reports.SubCat", 5, 5)); // Print subcats
                twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Item.Reports.OnHand"), "TreeMenu.Item.Reports.OnHand", 5, 5)); // On-Hand Report
#if !FSD
                twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Item.Reports.DisktilbudSolgt"), "TreeMenu.Item.Reports.DisktilbudSolgt", 5, 5)); // Disktilbud solgt rapport


               
#endif
#endif
#endif
            }


            // build system
            L1 = twMenu.Nodes[L0].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.System.Folder"), "TreeMenu.System.Folder", 0, 1)); // System root
#if DETAIL
             L2 = twMenu.Nodes[L0].Nodes[L1].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.System.Sitedata.Butik"), "TreeMenu.System.Sitedata.Butik", 4, 4)); // Butik
#else
             L2 = twMenu.Nodes[L0].Nodes[L1].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.System.Sitedata"), "TreeMenu.System.Sitedata", 4, 4)); // Station
#endif

             L2 = twMenu.Nodes[L0].Nodes[L1].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.System.SetupFolder"), "TreeMenu.System.SetupFolder", 0, 1)); // Opsætning folder
               twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.System.Setup.Users"), "TreeMenu.System.Setup.Users", 4, 4)); // Brugere
#if !RBA
#if !DETAIL
               if (db.GetConfigStringAsBool("Items.Enabled"))
               {
                   twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.System.PakningsTyper"), "TreeMenu.System.PakningsTyper", 4, 4)); // PakningsTyper
                   twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.System.Setup.KolliSizes"), "TreeMenu.System.Setup.KolliSizes", 4, 4)); // LookupKolliSize
                   twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.System.Setup.BHHTWS"), "TreeMenu.System.Setup.BHHTWS", 4, 4)); // BHHT Worksheets
               }
               twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.System.Setup.FTPAccounts"), "TreeMenu.System.Setup.FTPAccounts", 4, 4)); // FTPAccounts
#endif // if !DETAIL
#endif // if !RBA
               twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.System.Setup.Updates"), "TreeMenu.System.Setup.Updates", 4, 4)); // Updates

#if DETAIL
            twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.System.Setup.SalesStatColumns"), "TreeMenu.System.Setup.SalesStatColumns", 4, 4)); // Sales stat columns editor
            twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.WasteSheets"), "TreeMenu.WasteSheets", 4, 4)); // Afskrivningsark med stregkoder
#endif
               if (db.GetConfigStringAsBool("Items.Enabled"))
               {
                   if (db.GetConfigString("RegnskabIF_flag") == "service")
                       twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.System.Setup.SalesStatColumns"), "TreeMenu.System.Setup.SalesStatColumns", 4, 4)); // Sales stat columns editor

                   twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.WasteSheets"), "TreeMenu.WasteSheets", 4, 4)); // Afskrivningsark med stregkoder
               }

#if FSD
               twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.System.Setup.BFIStations"), "TreeMenu.System.Setup.BFIStations", 4, 4)); // BFI stations
#endif
#if !RBA
               twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.System.CashierAdmin"), "TreeMenu.System.CashierAdmin", 4, 4)); // CashierAdmin (operatør)
#endif
            bool DOSite = (db.GetConfigStringAsBool("DOVersion"));
            if (DOSite)
            {
                L2 = twMenu.Nodes[L0].Nodes[L1].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.System.PeriodicFolder"), "TreeMenu.System.PeriodicFolder", 0, 1)); // Periodisk folder
            }
               //twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.System.Periodic.CleanUp"), "TreeMenu.System.Periodic.CleanUp", 4, 4)); // Oprydning
              // twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.System.Backup"), "TreeMenu.System.Backup", 4, 4)); // Backup Fjernet pn20200603
#if RBA
               twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.System.StockCountRegistrationRBA"), "TreeMenu.System.StockCountRegistrationRBA", 4, 4)); // Optællinger RBA              
               twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.System.ItemTransStockCountReportRBA"), "TreeMenu.System.ItemTransStockCountReportRBA", 4, 4)); // Optællinger rapport RBA              
#endif
#if !RBA && !DETAIL
               if (db.GetConfigStringAsBool("Economics.Enabled"))
               {
                   twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.Economics"), "TreeMenu.Economics", 4, 4)); // Economics
               }
#endif

#if !RBA
#if !DETAIL
               if (db.GetConfigStringAsBool("Items.Enabled"))
                {                  
                   
                        twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.InactiveItems"), "TreeMenu.InactiveItems", 4, 4)); // Inaktiv Varekartotek
                        twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.ItemsDelete"), "TreeMenu.ItemsDelete", 4, 4)); // Slette varer
                   
                }
#endif // if !DETAIL
#endif // if !RBA

             L2 = twMenu.Nodes[L0].Nodes[L1].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.System.SupportFolder"), "TreeMenu.System.SupportFolder", 0, 1)); // Support folder
               twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.System.Support.ViewLog"), "TreeMenu.System.Support.ViewLog", 4, 4)); // View log file

             //L2 = twMenu.Nodes[L0].Nodes[L1].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.System.ReportFolder"), "TreeMenu.System.ReportFolder", 6, 6)); // Rapport folder
               //twMenu.Nodes[L0].Nodes[L1].Nodes[L2].Nodes.Add(CreateNode(db.GetLangString("TreeMenu.System.Reports.SalesGL"), "TreeMenu.System.Reports.SalesGL", 5, 5)); // Salgskonti rapport
         
            // expand the root node
			twMenu.Nodes[L0].Expand();

            // restrict access to treenodes for logged on user
            AdminDataSet.TreeviewProhibitionsDataTable.RestrictAccessToTreeNodes(twMenu.Nodes[0]);
        }
        #endregion

        #region METHOD: AddToFavorites
        /// <summary>
		/// Add the provided treeview item to the favorite list.
		/// Note: this must be a clone of a treeview menu items, so the Tag id can be used to open the node's window.
		/// </summary>
		/// <param name="node">A TreeNode clone from the treeview menu</param>
		private void AddToFavorites(TreeNode node)
		{
			// check that node does not have any children (is not an end-point)
			if(node.GetNodeCount(true) > 0)
			{
				MessageBox.Show(db.GetLangString("MainForm.AddFavoritesNotEndPoint"));
				return;
			}

			// check that the node does not already exist in the favorites (below root node)
			foreach(TreeNode n in favorites.Nodes[0].Nodes)
			{
				if(n.Tag.ToString() == node.Tag.ToString())
				{
					MessageBox.Show(db.GetLangString("MainForm.AddFavoriteAlreadyExist"));
					return;
				}
			}
			// if the node not already exist in the favorites list, add it
			favorites.Nodes[0].Nodes.Add(node);

			favorites.ExpandAll();
        }
        #endregion

        #region METHOD: RemoveFromFavorites
        /// <summary>
		/// Finds the node in the favorites list, that has the given Tag, and removes it.
		/// If the node is not found, nothing happens. Below root node.
		/// </summary>
		/// <param name="nodeTag">A TreeNode's Tag string</param>
		private void RemoveFromFavorites(string nodeTag)
		{
			foreach(TreeNode n in favorites.Nodes[0].Nodes)
			{
				if(n.Tag.ToString() == nodeTag)
				{
					favorites.Nodes[0].Nodes.Remove(n);
					favorites.ExpandAll();
					return;
				}
			}
        }
        #endregion

        #region METHOD: SetLanguage
        /// <summary>
		/// 
		/// </summary>
		/// <param name="lang"></param>
		private void SetLanguage(string lang)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				
				/// tell database to get new language strings.
				/// this only gives meaning when changing the language runtime,
				/// as when the application starts, the given language will be
				/// the same as the database is already set to.
				db.Language = lang;

				// localize controls on form (labels, button etc.)
				foreach(Control ctrl in this.Controls)
				{
					if((ctrl is Label) || (ctrl is Button))
						ctrl.Text = db.GetLangString(ctrl.Name);
				}

				// localize menu
                filesToolStripMenuItem.Text = db.GetLangString("MenuFiles");
                exitToolStripMenuItem.Text = db.GetLangString("MenuFilesExit");
				//editToolStripMenuItem.Text = db.GetLangString("MenuEdit");
				//showToolStripMenuItem.Text = db.GetLangString("MenuShow");
				helpToolStripMenuItem.Text = db.GetLangString("MenuHelp");
				toolsToolStripMenuItem.Text = db.GetLangString("MenuTools");
				langToolStripMenuItem.Text = db.GetLangString("MenuLanguage");
				langenToolStripMenuItem.Text = db.GetLangString("MenuLanguageEnglish");
				langdaToolStripMenuItem.Text = db.GetLangString("MenuLanguageDanish");
				resetbarsToolStripMenuItem.Text = db.GetLangString("MainForm.Menu.Tools.ResetBar");
                supportMenu.Text = db.GetLangString("MenuSupport");
                aboutToolStripMenuItem.Text = db.GetLangString("MainForm.Menu.About");
                helpToolStripMenuItem1.Text = db.GetLangString("MainForm.Menu.Help");

				// localize favorites menu
				if(favorites.Nodes.Count > 0)
				{
					favorites.Nodes[0].Text = db.GetLangString(favorites.Nodes[0].Tag.ToString());
					foreach(TreeNode n in favorites.Nodes[0].Nodes)
						n.Text = db.GetLangString(n.Tag.ToString());
				}

				// localize treeview menu
				BuildTreeMenu(lang);

				// localize treeview context menu
				contextTreeview.MenuItems[0].Text = db.GetLangString("MainForm.TreeviewContextMenu.ExpandAll");
				contextTreeview.MenuItems[1].Text = db.GetLangString("MainForm.TreeviewContextMenu.CollapseAll");
				contextTreeview.MenuItems[2].Text = db.GetLangString("MainForm.TreeviewContextMenu.AddToFavorites");
				
				// localize favorites context menu
				contextFavorites.MenuItems[0].Text = db.GetLangString("MainForm.TreeviewContextMenu.MoveUp");
				contextFavorites.MenuItems[1].Text = db.GetLangString("MainForm.TreeviewContextMenu.MoveDown");
				contextFavorites.MenuItems[2].Text = db.GetLangString("MainForm.TreeviewContextMenu.RemoveFromFavorites");
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
        }
        #endregion

        #region METHOD: SetLanguageConfirm
        /// <summary>
		/// @@@ TO DOCUMENT
		/// </summary>
		/// <returns></returns>
		private bool SetLanguageConfirm()
		{
			DialogResult res = MessageBox.Show(this,db.GetLangString(this.Name+".ChangeLanguageDialog"),"",MessageBoxButtons.YesNo);
			if(res == DialogResult.Yes)
			{
				foreach(System.Windows.Forms.Form f in this.MdiChildren)
					f.Close();
			}
			return (res == DialogResult.Yes);
        }
        #endregion

        #region METHOD: OpenMenuWindow
        /// <summary>
		/// @@@ TO DOCUMENT
		/// </summary>
		/// <param name="id"></param>
		public void OpenMenuWindow(string id)
		{
			System.Windows.Forms.Form form = null;

			// detect which form to open
			switch(id)
			{
                case "TreeMenu.Loen.Stamdata.Medarbejder":
					form = new PrlEmployee();
					break;
                case "TreeMenu.Loen.Stamdata.Loenperioder":
                    form = new PrlSalaryPeriods();
                    break;
                case "TreeMenu.Loen.Indrapportering.Loenreg":
                    // check if there is an active salary period before opening the window
                    if (!Payroll.PrlSalaryPeriodsDataTable.DoesAnActiveSalaryPeriodExistThatIsNotApproved())
                    {
                        MessageBox.Show(db.GetLangString("MainForm.NoActiveSalaryPeriod"));
                        PrlSalaryPeriods periods = new PrlSalaryPeriods();
                        periods.ShowDialog();
                        // re-check if user has selected an active salary period
                        if (!Payroll.PrlSalaryPeriodsDataTable.DoesAnActiveSalaryPeriodExistThatIsNotApproved())
                        {
                            MessageBox.Show(db.GetLangString("MainForm.StillNoActiveSalaryPeriod"));
                            return;
                        }   
                    }
                    // open the salary registration window
                    form = new PrlSalaryReg();
                    break;
                case "TreeMenu.Loen.Indrapportering.Fravaersreg":
                    // check if there is an active salary period before opening the window
                    if (!Payroll.PrlSalaryPeriodsDataTable.DoesAnActiveSalaryPeriodExistThatIsNotApproved())
                    {
                        MessageBox.Show(db.GetLangString("MainForm.NoActiveSalaryPeriod"));
                        PrlSalaryPeriods periods = new PrlSalaryPeriods();
                        periods.ShowDialog();
                        // re-check if user has selected an active salary period
                        if (!Payroll.PrlSalaryPeriodsDataTable.DoesAnActiveSalaryPeriodExistThatIsNotApproved())
                        {
                            MessageBox.Show(db.GetLangString("MainForm.StillNoActiveSalaryPeriodAbsense"));
                            return;
                        }
                    }
                    // open the absense window
                    form = new PrlAbsense();
                    break;
                case "TreeMenu.Loen.Indrapportering.Withdraw":
                    // check if there is an active salary period before opening the window
                    if (!Payroll.PrlSalaryPeriodsDataTable.DoesAnActiveSalaryPeriodExistThatIsNotApproved())
                    {
                        MessageBox.Show(db.GetLangString("MainForm.NoActiveSalaryPeriod"));
                        PrlSalaryPeriods periods = new PrlSalaryPeriods();
                        periods.ShowDialog();
                        // re-check if user has selected an active salary period
                        if (!Payroll.PrlSalaryPeriodsDataTable.DoesAnActiveSalaryPeriodExistThatIsNotApproved())
                        {
                            MessageBox.Show(db.GetLangString("MainForm.StillNoActiveSalaryPeriodWithdraw"));
                            return;
                        }
                    }
                    form = new PrlWithdraw();
                    break;
                case "TreeMenu.Loen.Udskrifter.Medarbejder":
                    form = new PrlRptEmployeeFrm();
                    break;
                case "TreeMenu.Loen.Udskrifter.SalEmployee":
                    form = new PrlRptSalaryEmpFrm();
                    break;
                case "TreeMenu.Loen.Udskrifter.SalAllEmp":
                    form = new PrlRptSalarySumFrm();
                    break;
                case "TreeMenu.Loen.Udskrifter.SalAlLEmpWeek":
                    form = new PrlRptSalarySumFrmWk();
                    break;
                case "TreeMenu.Loen.Udskrifter.SalPerDate":
                    form = new PrlRptSalaryDateFrm();
                    break;
                case "TreeMenu.Loen.Udskrifter.AbsenseEmp":
                    form = new PrlRptAbsenseFrm();
                    break;
                case "TreeMenu.Loen.Udskrifter.Withdraw":
                    form = new PrlRptWithdrawFrm();
                    break;
                case "TreeMenu.Loen.Udskrifter.SalReg":
                    form = new PrlRptSalRegFrm();
                    break;
                case "TreeMenu.Loen.Udskrifter.LentOutEmp":
                    form = new PrlRptLentOutFrm();
                    break;
                case "TreeMenu.Loen.Udskrifter.AvgHrsPerWeek":
                    form = new PrlRptAvgHrsWeekFrm();
                    break;
                case "TreeMenu.Loen.ImportExport.DanLeverance":
                    if (Payroll.PrlSalaryPeriodsDataTable.AreAnyPeriodsExportable())
                        form = new PrlExportFrm();
                    else
                    {
                        MessageBox.Show(db.GetLangString("MainForm.NoExportableSalaryPeriods"));
                        return;
                    }
                    break;
                case "TreeMenu.Loen.Import.TimeReg":
                    //skal ikke vises hvis eGruppe
                    if (db.GetConfigStringAsBool("eGruppe.Active"))
                    {
                        ImportRegistrationEGrp importSalaryHoursEGrp = new ImportRegistrationEGrp();
                        importSalaryHoursEGrp.ShowDialog();
                    }
                    else
                    {
                        ImportSalaryHours importSalaryHours = new ImportSalaryHours();
                        importSalaryHours.ShowDialog();
                    }                   
                    break;
                case "TreeMenu.EODReconcile":
                    form = new EODOverview();
                    break;
                case "TreeMenu.EODDebitor":
                    form = new EODDebtor();
                    break;
                case "TreeMenu.EOD.Reports.SalesReport":
                    form = new SalesReportFrm();
                    break;
                case "TreeMenu.EOD.Reports.SalesStatReport":
                    form = new SalesStatRptFrm();
                    break;
                case "TreeMenu.EOD.Reports.AddInfoRpt":
                    form = new AddInfoFrm();
                    break; 
                    
                case "TreeMenu.EOD.Reports.SalesStatReportDetail":
                    form = new SalesStatDetailRptFrm();
                    break;
                case "TreeMenu.EOD.Reports.Debitorlist":
                    form = new EODDebtorListPF();
                    break;
                case "TreeMenu.EOD.Reports.DebStatement":
                    form = new EODDebtorTransPF();
                    break;
                  /*  
                case "TreeMenu.System.Setup.Users":
					form = new Users();
					break;
                  */
                case "TreeMenu.System.Setup.BFIStations":
                    form = new BFIStations();
                    break;
				case "TreeMenu0305":
					form = new Supplier();
					break;
                case "TreeMenu0301":
                    form = new ItemForm();
                    break;
                case "TreeMenu.InactiveItems":
                    form = new InactiveItemList();
                    break;
                case "TreeMenu.WasteSheets":
                    form = new WasteSheetHeader();
                    break;
                case "TreeMenu.ItemsDelete":
                    form = new ItemsDelete();
                    break;
                case "TreeMenu030201":
                    form = new OrderHeaderForm();
                    break;
                case "TreeMenu030202":
                    form = new OrderDraftForm();
                    break;
                case "TreeMenu0303":
                    form = new BHHTInvCountHeaderForm();
                    break;
                case "TreeMenu.Item.InvCountBooked":
                    form = new BookedInvCount();
                    break;
                case "TreeMenu.Item.Reports.SubCat":
                    form = new SubcatRptFrm();
                    break;
                case "TreeMenu.Item.Reports.OnHand":
                    form = new OnHandRptFrm();
                    break;
                case "TreeMenu0304":
                    form = new BHHTInvAdjustForm('x');
                    break;                         
                case "TreeMenu030701":
                case "TreeMenu030701_FSD":
                    form = new ExportRadiantForm();
                    break;
                case "TreeMenu030702":
                    form = new ImportRSMForm();
                    break;
                case "TreeMenu030703":

                    if (db.GetConfigStringAsBool("DelfiAktiv"))//pn20200617
                    {

                        if (MessageBox.Show("Export til Delfi", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            this.Refresh();
                            ExportBHHT export = new ExportBHHT();
                            if (export.ExportDelfi())
                                MessageBox.Show(db.GetLangString("MainForm.BHHTExportDoneMsg"));
                            else
                                MessageBox.Show(export.ErrorMessage);
                        }
                        
                    }

                    else  if (MessageBox.Show(db.GetLangString("MainForm.ExportToBHHTMsg"), "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.Refresh();
                        ExportBHHT export = new ExportBHHT();
                        if (export.ExportBHI())
                            MessageBox.Show(db.GetLangString("MainForm.BHHTExportDoneMsg"));
                        else
                            MessageBox.Show(export.ErrorMessage);
                    }
                    break;
                case "TreeMenu030704":
                    if (db.GetConfigStringAsBool("DelfiAktiv"))//pn20201023
                        form = new ImportRHTForm();
                    else
                        form = new ImportBHHTForm();
                    break;
                case "TreeMenu.ImportFromLL":
                case "TreeMenu.ImportFromFVD":
                    form = new ItemUpdates();
                    break;
                //case "TreeMenu.ExportACN":
                //    form = new ExportACNFrm();
                //    break;
                case "TreeMenu.ExportBFI":
                    form = new BFIExportFrm();
                    break;
                case "TreeMenu030901":
                    form = new ReportFormItemBasicData(ReportFormItemBasicData.ReportMode.BasicData);
                    break;
                case "TreeMenu030902":
                    form = new ItemTransReportForm();
                    break;
                case "TreeMenu030903":
                    form = new SalesMarginRptFrm();
                    break;
                case "TreeMenu030904":
                    form = new ItemSalesSumForm();
                    break;
                case "TreeMenu030906":
                    form = new ReportFormItemBasicData(ReportFormItemBasicData.ReportMode.ShelfLabels);
                    break;
                case "TreeMenu030908":
                    form = new BkdInvCountIntvFrm();
                    break;
                case "TreeMenu.System.Sitedata":
                    form = new SiteInformationForm();
                    break;
                case "TreeMenu.System.Sitedata.Butik":
                    form = new SiteInformationForm();
                    break;
                case "TreeMenu.System.Setup.Users":
                    form = new UserAdminForm();
                    break;
                case "TreeMenu.System.Support.ViewLog":
                    log.ViewLog();
                    break;
                case "TreeMenu.System.PakningsTyper":
                    form = new PackSizeForm();
                    break;
                case "TreeMenu.System.Setup.KolliSizes":
                    form = new LookupKolliSizeForm();
                    break;
                case "TreeMenu.System.Setup.BHHTWS":
                    form = new BHHTWorksheet();
                    break;
                case "TreeMenu.System.Setup.FTPAccounts":
                    form = new FTPAccountsForm();
                    break;
                case "TreeMenu.System.Setup.Updates":
                    form = new ManualUpdatesForm();
                    if (!(form as ManualUpdatesForm).ManualUpdatesPresent)
                    {
                        MessageBox.Show(db.GetLangString("MainForm.NoUpdates"));
                        return;
                    }
                    break;
                case "TreeMenu.System.Setup.SalesStatColumns":
                    form = new SalesStatColumns();
                    break;
                case "TreeMenu.System.Backup":
                    form = new BackupFrm();
                    break;
                case "TreeMenu.EOD.Readings.WaterPower":
                    // readings form is only allowed to be displayed,
                    // if there is an open reconcile record
                    if (EODDataSet.EODReconcileDataTable.GetCurrentOpenDay() != null)
                        form = new Readings();
                    else
                    {
                        MessageBox.Show(db.GetLangString("MainForm.OpenEODDayFirst"));
                        return;
                    }
                    break;
                case "TreeMenu.EOD.Readings.Wash":
                    // wash form is only allowed to be displayed,
                    // if there is an open reconcile record and if checkmark
                    // is set on siteinfo
                    if (EODDataSet.EODReconcileDataTable.GetCurrentOpenDay() == null)
                    {
                        MessageBox.Show(db.GetLangString("MainForm.OpenEODDayFirst"));
                        return;
                    }
                    else if (!db.GetConfigStringAsBool("Readings.StationHasWash"))
                    {
                        MessageBox.Show(db.GetLangString("MainForm.StationDoesntHaveWash"));
                        return;
                    }
                    else
                    {
                        form = new Wash();
                    }
                    break;
                case "TreeMenu.ExportToFVD":
                    form = new ExportFVDFrm();
                    break;
                case "TreeMenu.ExportFVDHeader":
                    form = new ExportFVDHeader();
                    break;
                case "TreeMenu.ImportKampagner":
                    ImportKampagner.ShowDialog();
                    break;
                case "TreeMenu.ImportItemsCSV":
                    form = new ImportItemsCSVFrm();
                    break;
                case "TreeMenu.WasteRegistration":
                    // dissallow waste registration if
                    // no open day in eod.
                    if (EODDataSet.EODReconcileDataTable.GetCurrentOpenDay() != null)
                        form = new WasteRegistrationRBA();
                    else
                        MessageBox.Show(db.GetLangString("MainForm.WasteRegistrationRBA.NoOpenDay"));
                    break;
                case "TreeMenu.ForbrugsvareRegistrering":
                    // dissallow forbrugsvare registration if
                    // no open day in eod.
                    if (EODDataSet.EODReconcileDataTable.GetCurrentOpenDay() != null)
                        form = new ForbrugsvareRegistrering();
                    else
                        MessageBox.Show(db.GetLangString("MainForm.ForbrugsvareRegistrering.NoOpenDay"));
                    break;
                case "TreeMenu.Reports.ItemTransactionsRBA":
                    form = new ItemTransReportFormRBA();
                    break;
                case "TreeMenu.Reports.ItemTransactionsForbrugsvarer":
                    form = new ItemTransForbrugsvareReportFrm();
                    break;
                case "TreeMenu.SalesPackFuturePricesPrompt":
                    if (ItemDataSet.SalesPackFuturePricesPromptDataTable.CheckIfAnySalesPacksAreDue())
                        form = new SalesPackFuturePricesPrompt();
                    else
                        MessageBox.Show(this, db.GetLangString("SalesPackFuturePricesPrompt.NothingToDo"));
                    break;
                case "TreeMenu.System.CashierAdmin":
                    form = new CashierAdmin();
                    break;
                case "TreeMenu.Item.Reports.DisktilbudSolgt":
                    form = new DisktilbudSolgtRptFrm();
                    break;
                case "TreeMenu.System.StockCountRegistrationRBA":
                    form = new StockCountRegistrationRBA();
                    break;
                case "TreeMenu.System.ItemTransStockCountReportRBA":
                    form = new ItemTransStockCountReportFormRBA();
                    break;
                case "TreeMenu.Economics":
                    form = new ImportEconomicsForm();
                    break;
                default:
					break;
                case "TreeMenu.Item.Reports.DanskeSpil":
                    form = new DanskeSpilReportFrm();
                    break;
                case "TreeMenu.Item.Reports.ShellRecharge":
                    form = new LadeDataReportForm();
                    break;

                //20231110
                case "TreeMenu0310":
                    form = new WasteSheetHeader();
                    break;

            }

            // check if form is not already open
            if (form != null)
			{
				foreach(System.Windows.Forms.Form f in  this.MdiChildren)
				{
					if(f.Name == form.Name)
					{
						// form already open, activate it
						if(f.WindowState == FormWindowState.Minimized)
							f.WindowState = FormWindowState.Normal;
						f.BringToFront();
						form = null;
						break;
					}
				}
			}

			// if form not open then open it
			if(form != null)
			{
                OpenMDIWindow(id, form);
			}
        }
        #endregion

        #region METHOD: OpenMDIWindow
        /// <summary>
        /// Opens a MDI window and adds a shortcut button to it.
        /// </summary>
        /// <param name="langStringTitle">Title string found in lang table.</param>
        /// <param name="form">Form to open.</param>
        public void OpenMDIWindow(string langStringTitle, System.Windows.Forms.Form form)
        {
            // first check if conflicting windows are already open
            // (the method displays a message to the user if conflicting windows exists)
            if (ConflictingWindows.ConflictingWindowsAreOpen(this, form)) return;

            // subscribe to the MDI child's Closing event,
            // so we can do special processing at that time
            form.Closing += new CancelEventHandler(mdiChild_Closing);

            // subscribe to the MDI child's Activated event,
            // so we can do special processing at that time
            form.Activated += new EventHandler(mdiChild_Activated);

            // get localized title for the window
            string title = db.GetLangString(langStringTitle);

            // add a shortcut button's seperator, if some buttons already exist
            if (toolStripShortcuts.Items.Count > 0)
            {
                ToolStripSeparator sep = new ToolStripSeparator();
                toolStripShortcuts.Items.Add(sep);
            }

            // add a shortcut button for this window (title has a max length)
            string shortcutTitle = (title.Length > 15) ? title.Remove(15, title.Length - 15) + "..." : title;
            ToolStripButton btn = new ToolStripButton();
            btn.Name = langStringTitle;
            btn.Tag = langStringTitle;
            btn.Text = shortcutTitle;
            btn.ToolTipText = title;
            toolStripShortcuts.Items.Add(btn);

            // continue to set up MDI child and show it
            form.Text = title;
            form.Tag = langStringTitle;
            form.MdiParent = this;
            form.Show();
        }
        #endregion

        #region METHOD: PlaceToolStrips
        /// <summary>
        /// Positions shortcuts and dummy toolstrips
        /// and sets the width of dummy toolstrip
        /// </summary>
        private void PlaceToolStrips()
        {
            // set the dummy toolstrip position and width
            toolStripDummy.Left = 0;
            toolStripDummy.Width = panelTreeFav.Width;

            // set the shortcuts toolstrip position
            toolStripShortcuts.Left = splitterMain.Left;
        }
        #endregion

        #region OpenHelp
        private void OpenHelp()
        {
            // open online help with it's simple key
#if !RBA
            tools.ExecuteProcess("http://www.danskretail.dk/rbosmanual/default.aspx?key=57148V2N8RQJ8HUTP9AKKD3ODA01FC3E");
#else
            tools.ExecuteProcess("http://www.danskretail.dk/rbamanual/default.aspx?key=57148V2N8RQJ8HUTP9AKKD3ODA01FC3E");
#endif
        }
        #endregion

        // Treeview after select event - what happens when user selects a node in the treeview.
		// Note: this is different from select a plus or minus sign in the treeview.
		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			OpenMenuWindow(e.Node.Tag.ToString());
		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			SetLanguage(db.Language);

#if RBA
            this.Text = this.Text + " RBA";
#endif
#if FSD
            this.Text = this.Text + " BFI";
#endif
#if DETAIL
            this.Text = this.Text + " DETAIL";
#endif

            // set DataError string for DRS_DataGridView component
            // (must be done after language has been set)
            DRS.Extensions.DRS_DataGridView.DataErrorString = db.GetLangString("DRS_DataGridView_DataError");

			try
			{
				// load position and size
				if(bool.Parse(db.GetConfigString("MainForm.Maximized","False")))
					this.WindowState = FormWindowState.Maximized;
				else
				{
					int defLeft=10, defTop=10, defWidth=900, defHeight=600;
					this.Left = int.Parse(db.GetConfigString("MainForm.Left",defLeft.ToString()));
					this.Top = int.Parse(db.GetConfigString("MainForm.Top",defTop.ToString()));
					this.Width = int.Parse(db.GetConfigString("MainForm.Width",defWidth.ToString()));
					this.Height = int.Parse(db.GetConfigString("MainForm.Height",defHeight.ToString()));
					// if any edges of the application is beyond the screen edges, reset the position and size
					System.Drawing.Rectangle rect = Screen.PrimaryScreen.WorkingArea;
					if( ((this.Left < 0) || (this.Left > rect.Right)) ||
						((this.Top < 0) || (this.Top > rect.Bottom)) ||
						((this.Width+this.Left > rect.Right)) ||
						((this.Height+this.Top > rect.Bottom)) )
					{
						this.Left = defLeft;
						this.Top = defTop;
						this.Width = defWidth;
						this.Height = defHeight;
					}
				}

                // panelTreeFav's width is dependent on splitterMain's X position
				panelTreeFav.Width = int.Parse(db.GetConfigString("MainForm.SplitterMain",225.ToString()));
                // twMenu's height is dependent on splitterTreeFav's Y position
				twMenu.Height = int.Parse(db.GetConfigString("MainForm.SplitterTreeFav",300.ToString()));

                // position toolstrips
                PlaceToolStrips();

				// add favorites root node and load favorites from db (inserted as children to root)
				favorites.Nodes.Add(CreateNode(db.GetLangString("MainMenu.Favorites"),"MainMenu.Favorites",3,3));
				favorites.Nodes[0].Nodes.AddRange(db.GetFavorites());
				favorites.ExpandAll();

                /// Only allow user drs to access the support menu
                supportMenu.Visible = (UserLogon.ProfileID == AdminDataSet.UserProfilesDataTable.ProfileID.drs);//20191113
                supportMenu.Visible = true;
            } 
			catch (Exception) {}

			// set the background color of the MDI container,
			// as the background is covered by a MdiClient control
			foreach (Control ctl in this.Controls)
			{
				if (ctl is MdiClient) 
				{
					ctl.BackColor = Color.WhiteSmoke;
					break;
				}
			}

            // if any manual updates are present, show ManualUpdatesForm
            //ManualUpdatesForm muf = new ManualUpdatesForm();
            //if (muf.ManualUpdatesPresent)
            //    muf.ShowDialog();

            // imports that user is not prompted about
            //ImportSafePay.ImportFiles();
#if DETAIL
            if (!ImportConcernoPOS.ImportFiles())
                MessageBox.Show(ImportConcernoPOS.LastError);
#endif

            // check for due future prices
            if (ItemDataSet.SalesPackFuturePricesPromptDataTable.CheckIfAnySalesPacksAreDue())
            {
                string msg = db.GetLangString("AskUserWhenFuturePricesAreDue");
                if (MessageBox.Show(this, msg, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    this.OpenMenuWindow("TreeMenu.SalesPackFuturePricesPrompt");
            }
            //peter20190430
            //check for due future cost prices

            if (ItemDataSet.FutureCostPricesDataTable.CheckIfAnyCostPricesAreDue())
            {
                ItemDataSet ds = new ItemDataSet();
                ItemDataSetTableAdapters.FutureCostPricesTableAdapter adapter =
                    new ItemDataSetTableAdapters.FutureCostPricesTableAdapter();

                adapter.Connection = db.Connection;
                adapter.Fill(ds.FutureCostPrices);

                DataRow[] rows = ds.FutureCostPrices.Select();

                // setup progress form
                ProgressForm progress = new ProgressForm(db.GetLangString("ItemUpdLines.ProgressCostPrices"));

                progress.ProgressMax = rows.Length;
                progress.Show();

                // loop all ActionNewCostPrice records and perform action
                int count = 0;
                foreach (DataRow row in rows)
                {
                    
                   ++count;
                   ItemDataSet.SupplierItemDataTable.UpdateCostPrice(
                   tools.object2double(row["PackageCost"]),
                   tools.object2int(row["SupplierNo"]),
                   tools.object2double(row["OrderingNumber"]));
                   progress.StatusText = "Indlæser kostpriser"; 
                }

                progress.Close();
                adapter.UpdateQuery();
               // dataGridView1.Refresh();

                string msg = string.Format(db.GetLangString("ItemUpdLines.msgNewCostPricesSet"), count);
                MessageBox.Show(msg);




                
            }
            
            /// If LL updater has not updated anything this time
            /// and data are ready (from last run) and a config value
            /// says that we should give user a message about this, display the message.
            if (ImportDataSet.ItemUpdatesDataTable.UpdatesPresent() &&
                db.GetConfigStringAsBool("AskUserWhenLLUpdatesNotTreatedYet"))
            {
#if FSD
                string msg = db.GetLangString("MainForm.LLUpdatesReadyForTreatment").Replace("\\n", "\n");
                if (MessageBox.Show(this, msg, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.OpenMenuWindow("TreeMenu.ImportFromLL");
                }
#else
                string msg = db.GetLangString("MainForm.FVDUpdatesReadyForTreatment").Replace("\\n", "\n");
                if (MessageBox.Show(this, msg, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.OpenMenuWindow("TreeMenu.ImportFromFVD");
                }
#endif
            }

		}

        // event handler for displaying message in statusbar after autobackup have completed
        private void AsyncBackupCompleteEvent()
        {
            statusBar1.Text = Backup.LastMessage;
            timerStatusBarMsgClearing.Start();
        }

		// MainForm closing event
		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
            // check if an autobackup is running, we need to wait for that to complete
            if (Backup.BackupRunning)
            {
                MessageBox.Show(db.GetLangString("MainForm.AutoBackupRunningPleaseWait"));
                e.Cancel = true;
                return;
            }

            // save application settings
			db.SetConfigString("MainForm.Left",this.Left.ToString());
			db.SetConfigString("MainForm.Top",this.Top.ToString());
			db.SetConfigString("MainForm.Width",this.Width.ToString());
			db.SetConfigString("MainForm.Height",this.Height.ToString());
			db.SetConfigString("MainForm.Maximized",((bool)(this.WindowState == FormWindowState.Maximized)).ToString());
			db.SetConfigString("MainForm.SplitterMain",splitterMain.Left.ToString());
			db.SetConfigString("MainForm.SplitterTreeFav",splitterTreeFav.Top.ToString());
			db.SetFavorites(favorites.Nodes[0].Nodes); // don't save the root node
        }

		// treeview context menu expand all click event
		private void contextTreeviewExpandAll_Click(object sender, System.EventArgs e)
		{
			twMenu.ExpandAll();
		}

		// treeview context menu collapse all click event
		private void contextTreeviewCollapseAll_Click(object sender, System.EventArgs e)
		{
			twMenu.CollapseAll();
			twMenu.Nodes[0].Expand(); // keep root node expaned
		}

		// treeview context menu add to favorites click event
		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			// the node is selected in the context menu's Popup event
			if(rightSelectedNodeTreeview != null)
				AddToFavorites((TreeNode)rightSelectedNodeTreeview.Clone());
		}

		// favorites context menu remove from favorites click event
		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			// the node is selected in the context menu's popup event
			if(rightSelectedNodeFavorites != null)
			{
				string tag = rightSelectedNodeFavorites.Tag.ToString();
				if(tag != "")
				{
					if(MessageBox.Show(this,db.GetLangString("MainForm.RemoveFavoriteMsg"),"",MessageBoxButtons.YesNo) == DialogResult.Yes)
						RemoveFromFavorites(tag);
				}
			}
		}

		// treeview context menu popup event
		private void contextTreeview_Popup(object sender, System.EventArgs e)
		{
			// to get the node selected with right click, we have to use GetNodeAt, as the TreeView does
			// not have a property called HighlightedNode. The SelectedNode property is only for selecting
			// with left click. Further, when using GetNodeAt, the mouse is dected to be at some position, but
			// this position is moved away from the desired node when clicking the context menu, so we have to
			// grab the mouse's position when the context menu was popped up.
			rightSelectedNodeTreeview = null;
			try { rightSelectedNodeTreeview = (TreeNode)twMenu.GetNodeAt(twMenu.PointToClient(Cursor.Position)); }
			catch(Exception) {}
		}

		// favorites context menu popup event
		private void contextFavorites_Popup(object sender, System.EventArgs e)
		{
			// to get the node selected with right click, we have to use GetNodeAt, as the TreeView does
			// not have a property called HighlightedNode. The SelectedNode property is only for selecting
			// with left click. Further, when using GetNodeAt, the mouse is dected to be at some position, but
			// this position is moved away from the desired node when clicking the context menu, so we have to
			// grab the mouse's position when the context menu was popped up.
			rightSelectedNodeFavorites = null;
			try { rightSelectedNodeFavorites = (TreeNode)favorites.GetNodeAt(favorites.PointToClient(Cursor.Position)); }
			catch(Exception) {}
		}

		// favorites context menu move up click event
		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			if(rightSelectedNodeFavorites != null)
			{
				int i = favorites.Nodes[0].Nodes.IndexOf(rightSelectedNodeFavorites);
				if(i>0)
				{
					// we have to remove the current and previous nodes from the
					// collection and then insert them swapped. if we just swap them,
					// they get added, that is, the indexer favorites.Nodes[i] seems to add them
					TreeNode prevNodeClone = (TreeNode)rightSelectedNodeFavorites.PrevNode.Clone();
					TreeNode currNodeClone = (TreeNode)rightSelectedNodeFavorites.Clone();
					favorites.Nodes[0].Nodes.Remove(rightSelectedNodeFavorites.PrevNode);
					favorites.Nodes[0].Nodes.Insert(i-1,currNodeClone);
					favorites.Nodes[0].Nodes.Remove(rightSelectedNodeFavorites);
					favorites.Nodes[0].Nodes.Insert(i,prevNodeClone);
					favorites.SelectedNode = currNodeClone;
				}
			}
		}

		// favorites context menu move down click event
		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			if(rightSelectedNodeFavorites != null)
			{
				int i = favorites.Nodes[0].Nodes.IndexOf(rightSelectedNodeFavorites);
				if(i<favorites.Nodes[0].Nodes.Count-1)
				{
					// we have to remove the current and next nodes from the
					// collection and then insert them swapped. if we just swap them,
					// they get added, that is, the indexer favorites.Nodes[i] seems to add them
					TreeNode nextNodeClone = (TreeNode)rightSelectedNodeFavorites.NextNode.Clone();
					TreeNode currNodeClone = (TreeNode)rightSelectedNodeFavorites.Clone();
					favorites.Nodes[0].Nodes.Remove(rightSelectedNodeFavorites.NextNode);
					favorites.Nodes[0].Nodes.Insert(i+1,currNodeClone);
					favorites.Nodes[0].Nodes.Remove(rightSelectedNodeFavorites);
					favorites.Nodes[0].Nodes.Insert(i,nextNodeClone);
					favorites.SelectedNode = currNodeClone;
				}
			}
		}

		// custom event used for catching when a mdi child is closing, and
		// do special processing at that time. this event is subscribing
		// to the mdi child window's Closing event.
		private void mdiChild_Closing(object sender, CancelEventArgs e)
		{
			// get the MDI child id
			string id = ((System.Windows.Forms.Form)sender).Tag.ToString();

            ToolStripItem prevSeperator = null;

			// remove the shortcut button for this window
            foreach(ToolStripItem item in toolStripShortcuts.Items)
            {
                // remove the button and its seperator
                if (item is ToolStripButton)
                {
                    ToolStripButton b = (ToolStripButton)item;
                    if (b.Name == id)
                    {
                        // remove the seperator
                        if (prevSeperator != null)
                            toolStripShortcuts.Items.Remove(prevSeperator);

                        // remove the button
                        toolStripShortcuts.Items.Remove(b);
                        break;
                    }
                }

                // keep reference to the next button's seperator
                if(item is ToolStripSeparator)
                    prevSeperator = item;
			}

            // check if the first shortcut toopstripitem is a seperator, and remove it if so
            if ((toolStripShortcuts.Items.Count > 0) &&
                (toolStripShortcuts.Items[0] is ToolStripSeparator))
            {
                toolStripShortcuts.Items.RemoveAt(0);
            }
		}

		// custom event used for catching when a mdi child is activated,
		// and do special processing at that time: this event is subscribing
		// to the mdi child window's Activated event.
		private void mdiChild_Activated(object sender, EventArgs e)
		{
			// press the shortcut button for this window, and deselect all other
            string id = ((System.Windows.Forms.Form)sender).Tag.ToString();
            foreach(ToolStripItem item in toolStripShortcuts.Items)
			{
                if (item is ToolStripButton)
                {
                    ToolStripButton b = (ToolStripButton)item;
                    b.Checked = false;
                    if (b.Name == id) b.Checked = true;
                }
			}
		}

		// favorites after select event - when user select a node
		private void favorites_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			OpenMenuWindow(e.Node.Tag.ToString());
		}

		// treemenu mouse down event - deselect any node so selection works
		private void twMenu_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(twMenu.SelectedNode != null)
				twMenu.SelectedNode = null;
		}

		// favorites mouse down event - deselect any node so selection works
		private void favorites_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(favorites.SelectedNode != null)
				favorites.SelectedNode = null;
		}

		// menu click event - close application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Close();
        }

		// menuclick event for resetting the bars
        private void resetbarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
			if(MessageBox.Show(this,db.GetLangString("MainForm.ResetBars.Message"),"",MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				//@@@rebar1.LoadState(rebar1.ResetState);
			}
        }

		// menu click event - set danish language
        private void langenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SetLanguageConfirm())
                SetLanguage("en");
        }

		// menu click event - set english language
        private void langdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SetLanguageConfirm())
                SetLanguage("da");
        }

		// click event for shortcut buttons
        private void toolStripShortcuts_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
			// activate the window corresponding to the shortcut button
			string id = e.ClickedItem.Name;
			foreach(System.Windows.Forms.Form f in this.MdiChildren)
			{
				if(f.Tag.ToString() == id)
				{
					if(f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					break;
				}
			}
        }

        // menu click event - show test form
        private void testformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestForm form = new TestForm();
            //ImportEconomicsForm  form = new ImportEconomicsForm(); 20191113
            //form.MdiParent = this;
            form.Show();
        }

        // menu click event - set application to 1024x768 @@@ to be removed
        private void sætProgrammetTil1024x768ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 1024;
            this.Height = 768;
        }

        // menu click event - import test data for Item and SubCategory
        private void itemAndSubCategoryTestdataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("All data in tables Item, SubCategory and Barcode will be deleted first, continue?","",MessageBoxButtons.YesNo) == DialogResult.Yes)
                ImportEP.ImportItemTestData();
        }

        // menu click event - open subcategory form
        private void subCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            SubCategoryForm form = new SubCategoryForm();
            form.MdiParent = this;
            form.Show();

        }

        // menu import ep data click event
        private void importEPDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportEP.ImportEPdata();
        }

        // splitter main moved event
        private void splitterMain_SplitterMoved(object sender, SplitterEventArgs e)
        {
            PlaceToolStrips();
        }

        private void rSMMSMImportedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RSM_MSM_Imported form = new RSM_MSM_Imported();
            form.ShowDialog();
        }

        // open about box
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog(this);
        }

        // open help
        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenHelp();
        }

        private void timerStatusBarMsgClearing_Tick(object sender, EventArgs e)
        {
            // the timerStatusBarMsgClearing will be invoked
            // when some code needs to write a message to the user
            // in the StatusBar (a pretty quiet notice) and then
            // the message needs to be cleared after some time
            statusBar1.Text = "";
            timerStatusBarMsgClearing.Stop();
        }

        private void testFormToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TestForm form = new TestForm();//Peter20191113
            //ImportEconomicsForm form = new ImportEconomicsForm();
            form.ShowDialog();
        }

        private void payrollModuleConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // open payroll module configuration form
            if (UserLogon.ProfileID == AdminDataSet.UserProfilesDataTable.ProfileID.drs)
            {
                Administration support = new Administration();
                support.ShowDialog(this);
            }
        }

        
        private void menuitemSkiftStation_Click(object sender, EventArgs e)
        {
            // close any open windows first
            if (this.MdiChildren.Length > 0)
            {
                // check with user that it's ok to close the windows
                string msg = dbOleDb.GetLangString("MainForm.SkiftStation.ConfirmCloseWindows");
                if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // close the windows
                    tools.ApplicationNeedsToForceQuit = true; // allow closing the non-closable windows
                    foreach (System.Windows.Forms.Form f in this.MdiChildren)
                        f.Close();
                    tools.ApplicationNeedsToForceQuit = false;

                    // check that all windows were closed
                    if (this.MdiChildren.Length > 0)
                    {
                        msg = dbOleDb.GetLangString("MainForm.SkiftStation.CouldNotCloseAllWindows");
                        MessageBox.Show(msg);
                        return;
                    }
                }
                else
                    return; // user do not want to close the windows
            }

            // ok we are ready to continue
            string OldSiteCode = AdminDataSet.SiteInformationDataTable.GetSiteCode();
            int idxOldSiteCodeAndSpace = this.Text.LastIndexOf(OldSiteCode) - 2;

            // save the favorites now before we change database
            dbOleDb.SetFavorites(favorites.Nodes[0].Nodes); // don't save the root node

            if (UserLogon.VerifyUserAndSelectDatabase(null, null, false))
            {
                // re-initialize database
                dbOleDb.ReInitialize();

                // run version updater (must be done after initializing db)
                if (!Version.VersionUpdater())
                {
                    // display update error to user
                    MessageBox.Show(Version.LastError);
                    UserLogon.SelectPrevDatabase();
                    return;
                }

                // remove the current site code from window title and set the new one
                if (idxOldSiteCodeAndSpace >= 0)
                    this.Text = this.Text.Remove(idxOldSiteCodeAndSpace);
                this.Text = this.Text + "  " + AdminDataSet.SiteInformationDataTable.GetSiteCode();

                // build treemenu
                BuildTreeMenu(dbOleDb.Language);

                // load favorites
                favorites.Nodes.Clear();
                favorites.Nodes.Add(CreateNode(dbOleDb.GetLangString("MainMenu.Favorites"), "MainMenu.Favorites", 3, 3));
                favorites.Nodes[0].Nodes.AddRange(dbOleDb.GetFavorites());
                favorites.ExpandAll();

                // load language string
                //Version.Upd_Lang();
            }
            else
            {
                if (UserLogon.LastMessage != "")
                    MessageBox.Show(UserLogon.LastMessage);
            }
        }

    }
}
