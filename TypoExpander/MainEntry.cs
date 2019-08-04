using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using gma.System.Windows;
using System.Timers;
using SendKeys;
using System.Text;
using MiniTools.UI.Input;

namespace RSH.TypoExpander
{
	/// <summary>
	/// Summary description for AppMain.
	/// </summary>
	public class AppMain : System.Windows.Forms.Form
	{
        private IContainer components;
        /*[DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        private static extern Int32 SetForegroundWindow(IntPtr hwnd);
        [DllImport("user32.dll")]
        private static extern IntPtr GetActiveWindow();
        [DllImport("user32.dll")]
        private static extern Int32 SetActiveWindow(IntPtr hwnd);
        [DllImport("user32.dll")]
        private static extern Int32 SetFocus(IntPtr hwnd);
        [DllImport("user32.dll")]
        public  static extern bool  IsWindow(IntPtr hwnd);
        IntPtr hWnd;
        IntPtr hOwn;*/
        private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button StartTyping;
		//private UserActivityHook gh=new UserActivityHook();
        public MtKeyboardGlobalHook Ghook;
		public static string val="";
        string st = "";
        private DataGridView dg;
        private SplitContainer splitContainer1;
        private GroupBox groupBox1;
        private SplitContainer splitContainer2;
        private GroupBox AppGroupBox;
        public ListView ListView_Windows;
        private ColumnHeader columnHeader1;
        private GroupBox groupBox2;
        private LinkLabel lnkRefresh;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel4;
        private LinkLabel linkLabel3;
        private LinkLabel linkLabel2;
        public TabControl tabControl1;
        private LinkLabel SendLink;
        private StatusStrip KeysStatus;
        private ToolStripStatusLabel CtrlStatus;
        private ToolStripStatusLabel ShiftStatus;
        private ToolStripStatusLabel AltStatus;
        private ToolStrip TypoToolBar;
        private ToolStripButton AddWrdBtn;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton ModifyButton;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton DelButton;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton DictButton;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton OptionsButton;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripButton HelpButton;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton AboutButton;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton ExitButton;
        private ToolStripSeparator toolStripSeparator7;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem addWordToDictionaryToolStripMenuItem;
        private ToolStripMenuItem deleteWordFromDictionaryToolStripMenuItem;
        private ToolStripMenuItem modifyWordFromDictionaryToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem dictionariesToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripMenuItem makeChainsToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem onLineHelpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripStatusLabel CapsStatus;
        private ToolStripStatusLabel NumStatus;
        private ToolStripStatusLabel ScrollStatus;
        private ToolStripStatusLabel DefinitionStatus;
		ArrayList subs;
        private NotifyIcon TraySender;
        private bool IsLoaded=false;
		//private PicButton AddBtn;
		public AppMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            this.InitializeTimer();
			this.tabControl1.SelectedIndexChanged+=new EventHandler(OnTabChange);
            this.Ghook.MultiThreaded = true;
            this.Ghook.KeyEvent += new MtKeyEventHandler(KeyboardEvent);
            this.Resize += new EventHandler(AppMain_Resize);
            //this.LoadDicts();
//			if(libbtn.BackImage!=null&&libbtn.Hover!=null)
//				libbtn.SetImage(libbtn.BackImage,libbtn.Hover,libbtn.BackImage,libbtn.BackImage,libbtn.BackImage,ImageButton.Alignment.Center);			
            if (File.Exists(Application.StartupPath + "\\Settings.ini"))
                AppSettings.RetrieveOptions();
            else
                AppSettings.SaveDefaultOptions();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

        void AppMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                MtInputTimer.Enabled = false;
                Ghook.Enabled = true;
            }
            else if (this.WindowState == FormWindowState.Maximized || this.WindowState == FormWindowState.Normal)
            {
                MtInputTimer.Enabled = true;
                Ghook.Enabled = false;
            }
            
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
            this.Ghook.Uninstall();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.AppGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SendLink = new System.Windows.Forms.LinkLabel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lnkRefresh = new System.Windows.Forms.LinkLabel();
            this.ListView_Windows = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.StartTyping = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Ghook = new MiniTools.UI.Input.MtKeyboardGlobalHook();
            this.KeysStatus = new System.Windows.Forms.StatusStrip();
            this.AltStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ShiftStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.CtrlStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.CapsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.NumStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ScrollStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.DefinitionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addWordToDictionaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteWordFromDictionaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyWordFromDictionaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.dictionariesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.makeChainsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onLineHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TypoToolBar = new System.Windows.Forms.ToolStrip();
            this.AddWrdBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ModifyButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.DelButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.DictButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.OptionsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.HelpButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.AboutButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.TraySender = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.AppGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ghook)).BeginInit();
            this.KeysStatus.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.TypoToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Location = new System.Drawing.Point(0, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 306);
            this.panel1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.AppGroupBox);
            this.splitContainer1.Panel1.Controls.Add(this.StartTyping);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(698, 284);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 8;
            // 
            // AppGroupBox
            // 
            this.AppGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.AppGroupBox.Controls.Add(this.groupBox2);
            this.AppGroupBox.Controls.Add(this.ListView_Windows);
            this.AppGroupBox.Location = new System.Drawing.Point(6, 8);
            this.AppGroupBox.Name = "AppGroupBox";
            this.AppGroupBox.Size = new System.Drawing.Size(191, 239);
            this.AppGroupBox.TabIndex = 12;
            this.AppGroupBox.TabStop = false;
            this.AppGroupBox.Text = "Choose Application";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SendLink);
            this.groupBox2.Controls.Add(this.linkLabel4);
            this.groupBox2.Controls.Add(this.linkLabel3);
            this.groupBox2.Controls.Add(this.linkLabel2);
            this.groupBox2.Controls.Add(this.linkLabel1);
            this.groupBox2.Controls.Add(this.lnkRefresh);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(185, 44);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // SendLink
            // 
            this.SendLink.AutoSize = true;
            this.SendLink.Location = new System.Drawing.Point(101, 28);
            this.SendLink.Name = "SendLink";
            this.SendLink.Size = new System.Drawing.Size(32, 13);
            this.SendLink.TabIndex = 12;
            this.SendLink.TabStop = true;
            this.SendLink.Text = "Send";
            this.SendLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SendLink_LinkClicked);
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Location = new System.Drawing.Point(55, 28);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(44, 13);
            this.linkLabel4.TabIndex = 11;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "Restore";
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(6, 28);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(47, 13);
            this.linkLabel3.TabIndex = 10;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Minimize";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(96, 11);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(50, 13);
            this.linkLabel2.TabIndex = 9;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Maximize";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(57, 11);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(33, 13);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Close";
            // 
            // lnkRefresh
            // 
            this.lnkRefresh.Location = new System.Drawing.Point(3, 11);
            this.lnkRefresh.Name = "lnkRefresh";
            this.lnkRefresh.Size = new System.Drawing.Size(48, 16);
            this.lnkRefresh.TabIndex = 7;
            this.lnkRefresh.TabStop = true;
            this.lnkRefresh.Text = "Refresh";
            this.lnkRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRefresh_LinkClicked_1);
            // 
            // ListView_Windows
            // 
            this.ListView_Windows.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ListView_Windows.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.ListView_Windows.FullRowSelect = true;
            this.ListView_Windows.HideSelection = false;
            this.ListView_Windows.Location = new System.Drawing.Point(0, 19);
            this.ListView_Windows.MultiSelect = false;
            this.ListView_Windows.Name = "ListView_Windows";
            this.ListView_Windows.Size = new System.Drawing.Size(188, 167);
            this.ListView_Windows.TabIndex = 11;
            this.ListView_Windows.UseCompatibleStateImageBehavior = false;
            this.ListView_Windows.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Please select your desired Applications";
            this.columnHeader1.Width = 360;
            // 
            // StartTyping
            // 
            this.StartTyping.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.StartTyping.BackColor = System.Drawing.Color.White;
            this.StartTyping.ForeColor = System.Drawing.Color.Black;
            this.StartTyping.Location = new System.Drawing.Point(13, 253);
            this.StartTyping.Name = "StartTyping";
            this.StartTyping.Size = new System.Drawing.Size(174, 23);
            this.StartTyping.TabIndex = 4;
            this.StartTyping.Text = "Start Magic Typing";
            this.StartTyping.UseVisualStyleBackColor = false;
            this.StartTyping.Click += new System.EventHandler(this.StartTyping_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Size = new System.Drawing.Size(494, 284);
            this.splitContainer2.SplitterDistance = 119;
            this.splitContainer2.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 119);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Word Replacement";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(1, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "word:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(49, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(439, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(6, 42);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(482, 71);
            this.textBox2.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(494, 161);
            this.tabControl1.TabIndex = 0;
            // 
            // Ghook
            // 
            this.Ghook.Control = this;
            this.Ghook.HostingControl = this;
            this.Ghook.Name = "Ghook";
            // 
            // KeysStatus
            // 
            this.KeysStatus.BackColor = System.Drawing.Color.LightSteelBlue;
            this.KeysStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AltStatus,
            this.ShiftStatus,
            this.CtrlStatus,
            this.CapsStatus,
            this.NumStatus,
            this.ScrollStatus,
            this.DefinitionStatus});
            this.KeysStatus.Location = new System.Drawing.Point(0, 380);
            this.KeysStatus.Name = "KeysStatus";
            this.KeysStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.KeysStatus.Size = new System.Drawing.Size(702, 22);
            this.KeysStatus.TabIndex = 14;
            this.KeysStatus.Text = "statusStrip1";
            // 
            // AltStatus
            // 
            this.AltStatus.AutoSize = false;
            this.AltStatus.BackColor = System.Drawing.Color.LightSteelBlue;
            this.AltStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.AltStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.AltStatus.ForeColor = System.Drawing.Color.Gray;
            this.AltStatus.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.AltStatus.Name = "AltStatus";
            this.AltStatus.Size = new System.Drawing.Size(36, 17);
            this.AltStatus.Text = "Alt";
            this.AltStatus.ToolTipText = "Alt Key Status";
            // 
            // ShiftStatus
            // 
            this.ShiftStatus.AutoSize = false;
            this.ShiftStatus.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ShiftStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.ShiftStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.ShiftStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ShiftStatus.ForeColor = System.Drawing.Color.Gray;
            this.ShiftStatus.Image = ((System.Drawing.Image)(resources.GetObject("ShiftStatus.Image")));
            this.ShiftStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ShiftStatus.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.ShiftStatus.Name = "ShiftStatus";
            this.ShiftStatus.Size = new System.Drawing.Size(36, 17);
            this.ShiftStatus.Text = "Shift";
            this.ShiftStatus.ToolTipText = "Shift KEY STATUS";
            // 
            // CtrlStatus
            // 
            this.CtrlStatus.AutoSize = false;
            this.CtrlStatus.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CtrlStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.CtrlStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.CtrlStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CtrlStatus.ForeColor = System.Drawing.Color.Gray;
            this.CtrlStatus.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.CtrlStatus.Name = "CtrlStatus";
            this.CtrlStatus.Size = new System.Drawing.Size(36, 17);
            this.CtrlStatus.Text = "CTRL";
            this.CtrlStatus.ToolTipText = "CTRL KEY STATUS";
            // 
            // CapsStatus
            // 
            this.CapsStatus.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CapsStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.CapsStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.CapsStatus.ForeColor = System.Drawing.Color.Gray;
            this.CapsStatus.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.CapsStatus.Name = "CapsStatus";
            this.CapsStatus.Size = new System.Drawing.Size(66, 17);
            this.CapsStatus.Text = "CAPS LOCK";
            this.CapsStatus.ToolTipText = "CapsLock Status";
            this.CapsStatus.Click += new System.EventHandler(this.CapsStatus_Click);
            // 
            // NumStatus
            // 
            this.NumStatus.AutoSize = false;
            this.NumStatus.BackColor = System.Drawing.Color.LightSteelBlue;
            this.NumStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.NumStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.NumStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.NumStatus.ForeColor = System.Drawing.Color.Gray;
            this.NumStatus.Image = ((System.Drawing.Image)(resources.GetObject("NumStatus.Image")));
            this.NumStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NumStatus.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.NumStatus.Name = "NumStatus";
            this.NumStatus.Size = new System.Drawing.Size(66, 17);
            this.NumStatus.Text = "NUM LOCK";
            this.NumStatus.ToolTipText = "NumLock KEY STATUS";
            this.NumStatus.Click += new System.EventHandler(this.NumStatus_Click);
            // 
            // ScrollStatus
            // 
            this.ScrollStatus.AutoSize = false;
            this.ScrollStatus.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ScrollStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.ScrollStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.ScrollStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ScrollStatus.ForeColor = System.Drawing.Color.Gray;
            this.ScrollStatus.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.ScrollStatus.Name = "ScrollStatus";
            this.ScrollStatus.Size = new System.Drawing.Size(75, 17);
            this.ScrollStatus.Text = "SCROLL LOCK";
            this.ScrollStatus.ToolTipText = "ScrollLock KEY STATUS";
            this.ScrollStatus.Click += new System.EventHandler(this.ScrollStatus_Click);
            // 
            // DefinitionStatus
            // 
            this.DefinitionStatus.BackColor = System.Drawing.Color.LightSteelBlue;
            this.DefinitionStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DefinitionStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefinitionStatus.ForeColor = System.Drawing.Color.Black;
            this.DefinitionStatus.Margin = new System.Windows.Forms.Padding(110, 3, 0, 2);
            this.DefinitionStatus.Name = "DefinitionStatus";
            this.DefinitionStatus.Size = new System.Drawing.Size(77, 17);
            this.DefinitionStatus.Text = "0 Definitions";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(702, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addWordToDictionaryToolStripMenuItem,
            this.deleteWordFromDictionaryToolStripMenuItem,
            this.modifyWordFromDictionaryToolStripMenuItem,
            this.toolStripSeparator9,
            this.dictionariesToolStripMenuItem,
            this.toolStripSeparator11,
            this.makeChainsToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolStripSeparator10,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addWordToDictionaryToolStripMenuItem
            // 
            this.addWordToDictionaryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addWordToDictionaryToolStripMenuItem.Image")));
            this.addWordToDictionaryToolStripMenuItem.Name = "addWordToDictionaryToolStripMenuItem";
            this.addWordToDictionaryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.addWordToDictionaryToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.addWordToDictionaryToolStripMenuItem.Text = "Add Word to Dictionary";
            this.addWordToDictionaryToolStripMenuItem.Click += new System.EventHandler(this.addWordToDictionaryToolStripMenuItem_Click);
            // 
            // deleteWordFromDictionaryToolStripMenuItem
            // 
            this.deleteWordFromDictionaryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteWordFromDictionaryToolStripMenuItem.Image")));
            this.deleteWordFromDictionaryToolStripMenuItem.Name = "deleteWordFromDictionaryToolStripMenuItem";
            this.deleteWordFromDictionaryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.deleteWordFromDictionaryToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.deleteWordFromDictionaryToolStripMenuItem.Text = "Delete Word From Dictionary";
            this.deleteWordFromDictionaryToolStripMenuItem.Click += new System.EventHandler(this.deleteWordFromDictionaryToolStripMenuItem_Click);
            // 
            // modifyWordFromDictionaryToolStripMenuItem
            // 
            this.modifyWordFromDictionaryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("modifyWordFromDictionaryToolStripMenuItem.Image")));
            this.modifyWordFromDictionaryToolStripMenuItem.Name = "modifyWordFromDictionaryToolStripMenuItem";
            this.modifyWordFromDictionaryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.modifyWordFromDictionaryToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.modifyWordFromDictionaryToolStripMenuItem.Text = "Modify Word From Dictionary";
            this.modifyWordFromDictionaryToolStripMenuItem.Click += new System.EventHandler(this.modifyWordFromDictionaryToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(256, 6);
            // 
            // dictionariesToolStripMenuItem
            // 
            this.dictionariesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dictionariesToolStripMenuItem.Image")));
            this.dictionariesToolStripMenuItem.Name = "dictionariesToolStripMenuItem";
            this.dictionariesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.dictionariesToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.dictionariesToolStripMenuItem.Text = "Dictionaries";
            this.dictionariesToolStripMenuItem.Click += new System.EventHandler(this.dictionariesToolStripMenuItem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(256, 6);
            // 
            // makeChainsToolStripMenuItem
            // 
            this.makeChainsToolStripMenuItem.Checked = true;
            this.makeChainsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.makeChainsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("makeChainsToolStripMenuItem.Image")));
            this.makeChainsToolStripMenuItem.Name = "makeChainsToolStripMenuItem";
            this.makeChainsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.makeChainsToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.makeChainsToolStripMenuItem.Text = "Make Chains of Dictionaries";
            this.makeChainsToolStripMenuItem.Click += new System.EventHandler(this.makeChainsToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("optionsToolStripMenuItem.Image")));
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(256, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onLineHelpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // onLineHelpToolStripMenuItem
            // 
            this.onLineHelpToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("onLineHelpToolStripMenuItem.Image")));
            this.onLineHelpToolStripMenuItem.Name = "onLineHelpToolStripMenuItem";
            this.onLineHelpToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.onLineHelpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.onLineHelpToolStripMenuItem.Text = "OnLine Help";
            this.onLineHelpToolStripMenuItem.Click += new System.EventHandler(this.onLineHelpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // TypoToolBar
            // 
            this.TypoToolBar.AutoSize = false;
            this.TypoToolBar.BackColor = System.Drawing.Color.AliceBlue;
            this.TypoToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddWrdBtn,
            this.toolStripSeparator1,
            this.ModifyButton,
            this.toolStripSeparator2,
            this.DelButton,
            this.toolStripSeparator3,
            this.DictButton,
            this.toolStripSeparator4,
            this.OptionsButton,
            this.toolStripSeparator8,
            this.HelpButton,
            this.toolStripSeparator5,
            this.AboutButton,
            this.toolStripSeparator6,
            this.ExitButton,
            this.toolStripSeparator7});
            this.TypoToolBar.Location = new System.Drawing.Point(0, 24);
            this.TypoToolBar.Name = "TypoToolBar";
            this.TypoToolBar.Size = new System.Drawing.Size(702, 65);
            this.TypoToolBar.TabIndex = 17;
            // 
            // AddWrdBtn
            // 
            this.AddWrdBtn.AutoSize = false;
            this.AddWrdBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddWrdBtn.ForeColor = System.Drawing.Color.DarkCyan;
            this.AddWrdBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddWrdBtn.Image")));
            this.AddWrdBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddWrdBtn.ImageTransparentColor = System.Drawing.Color.White;
            this.AddWrdBtn.Name = "AddWrdBtn";
            this.AddWrdBtn.Size = new System.Drawing.Size(80, 62);
            this.AddWrdBtn.Text = "Add Word";
            this.AddWrdBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.AddWrdBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddWrdBtn.Click += new System.EventHandler(this.AddWrdBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 65);
            // 
            // ModifyButton
            // 
            this.ModifyButton.AutoSize = false;
            this.ModifyButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModifyButton.ForeColor = System.Drawing.Color.DarkCyan;
            this.ModifyButton.Image = ((System.Drawing.Image)(resources.GetObject("ModifyButton.Image")));
            this.ModifyButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ModifyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ModifyButton.Name = "ModifyButton";
            this.ModifyButton.Size = new System.Drawing.Size(80, 62);
            this.ModifyButton.Text = "Modify Word";
            this.ModifyButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ModifyButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ModifyButton.Click += new System.EventHandler(this.ModifyButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 65);
            // 
            // DelButton
            // 
            this.DelButton.AutoSize = false;
            this.DelButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DelButton.ForeColor = System.Drawing.Color.DarkCyan;
            this.DelButton.Image = ((System.Drawing.Image)(resources.GetObject("DelButton.Image")));
            this.DelButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DelButton.Name = "DelButton";
            this.DelButton.Size = new System.Drawing.Size(80, 62);
            this.DelButton.Text = "Delete Word";
            this.DelButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.DelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.DelButton.Click += new System.EventHandler(this.DelButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 65);
            // 
            // DictButton
            // 
            this.DictButton.AutoSize = false;
            this.DictButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DictButton.ForeColor = System.Drawing.Color.DarkCyan;
            this.DictButton.Image = ((System.Drawing.Image)(resources.GetObject("DictButton.Image")));
            this.DictButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DictButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DictButton.Name = "DictButton";
            this.DictButton.Size = new System.Drawing.Size(80, 62);
            this.DictButton.Text = "Dictionaries";
            this.DictButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.DictButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.DictButton.Click += new System.EventHandler(this.DictButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 65);
            // 
            // OptionsButton
            // 
            this.OptionsButton.AutoSize = false;
            this.OptionsButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptionsButton.ForeColor = System.Drawing.Color.DarkCyan;
            this.OptionsButton.Image = ((System.Drawing.Image)(resources.GetObject("OptionsButton.Image")));
            this.OptionsButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.OptionsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(80, 62);
            this.OptionsButton.Text = "Options";
            this.OptionsButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.OptionsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 65);
            // 
            // HelpButton
            // 
            this.HelpButton.AutoSize = false;
            this.HelpButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton.ForeColor = System.Drawing.Color.DarkCyan;
            this.HelpButton.Image = ((System.Drawing.Image)(resources.GetObject("HelpButton.Image")));
            this.HelpButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HelpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(80, 62);
            this.HelpButton.Text = "Help";
            this.HelpButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.HelpButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 65);
            // 
            // AboutButton
            // 
            this.AboutButton.AutoSize = false;
            this.AboutButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutButton.ForeColor = System.Drawing.Color.DarkCyan;
            this.AboutButton.Image = ((System.Drawing.Image)(resources.GetObject("AboutButton.Image")));
            this.AboutButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AboutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(80, 62);
            this.AboutButton.Text = "About";
            this.AboutButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.AboutButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 65);
            // 
            // ExitButton
            // 
            this.ExitButton.AutoSize = false;
            this.ExitButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.ForeColor = System.Drawing.Color.DarkCyan;
            this.ExitButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitButton.Image")));
            this.ExitButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ExitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(80, 62);
            this.ExitButton.Text = "Exit";
            this.ExitButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 65);
            // 
            // TraySender
            // 
            this.TraySender.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TraySender.BalloonTipText = "TypoExpander";
            this.TraySender.Icon = ((System.Drawing.Icon)(resources.GetObject("TraySender.Icon")));
            this.TraySender.Visible = true;
            this.TraySender.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TraySender_MouseDoubleClick);
            // 
            // AppMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(702, 402);
            this.Controls.Add(this.TypoToolBar);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.KeysStatus);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.LightGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AppMain";
            this.Text = "TypoExpander";
            this.Load += new System.EventHandler(this.AppMain_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.AppGroupBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ghook)).EndInit();
            this.KeysStatus.ResumeLayout(false);
            this.KeysStatus.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.TypoToolBar.ResumeLayout(false);
            this.TypoToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
            XPStyle.EnableVisualStyles();
			Application.Run(new AppMain());
            
		}
        private Dictionary dct = null;
        private bool ExpandByHotKey = false;
        private void KeyboardEvent(MtHook hook, MtKeyEventArgs e)
        {

            try
            {
                if (e.KeyPress)
                {
                    if (!MtKeyboard.IsControl(e.Modifiers) && !MtKeyboard.IsShift(e.Modifiers) && !MtKeyboard.IsAlt(e.Modifiers))
                    {
                        if (MtKeyboard.IsTypeable(e.KeyCode))
                        {

                            Dictionary.ctyping += e.KeyChar;
                            dct = Dictionary.GetReplacement(Dictionary.ctyping, false, (int)AppSettings.AppOptions["Active|Chained|All"]);
                            
                        }
                    }
                    else
                    {
                        if (ExpandByHotKey)
                        {

                            if (e.KeyText == AppSettings.AppOptions["HotKey"].ToString())
                                TypingControl.ProcessAndSend(dct, false, this);
                            
                            ExpandByHotKey = false;
                        }
                        else
                        {
                            dct = Dictionary.GetReplacement(e.KeyText, true, (int)AppSettings.AppOptions["Active|Chained|All"]);
                            if (dct != null)
                                TypingControl.ProcessAndSend(dct, true, this);
                        }
                        Dictionary.ctyping = "";
                        dct = null;
                    }
                }
                if (e.KeyDown)
                {

                    if (e.KeyCode == Keys.Space)
                    {

                        
                        if (dct != null)
                        {
                            if ((int)AppSettings.AppOptions["AutoExpand"] == 1)
                            { TypingControl.ProcessAndSend(dct, false, this);dct = null;Dictionary.ctyping = "";}
                            else if ((int)AppSettings.AppOptions["ExpandByHotKey"] == 1)
                            {
                                if ((int)AppSettings.AppOptions["ShowReplacementWindow"] == 1)
                                   
                                    TraySender.ShowBalloonTip(100, "Please make selection", dct.replacement + "\n Press '" + AppSettings.AppOptions["HotKey"].ToString() + "' to replace or any other key to cancel", ToolTipIcon.Info);
                               ExpandByHotKey = true;
                            }
                        }
      
                        
                        
                    }
                    if (e.KeyCode == Keys.Back)
                        if (Dictionary.ctyping.Length > 0)
                            Dictionary.ctyping = Dictionary.ctyping.Remove(Dictionary.ctyping.Length - 1);
                }
                //if (MtKeyboard.IsControl(e.Modifiers) || MtKeyboard.IsShift(e.Modifiers) || MtKeyboard.IsAlt(e.Modifiers))

                if (MtWindow.ActiveWindow.Text == "TypoExpander")
                    this.LogKeyModifiers(e);
            }
            catch(Exception ex) {}
        }


		/*private void GetTaskWindows()
		{
			// Get the desktopwindow handle
			int nDeshWndHandle = NativeWin32.GetDesktopWindow();
			// Get the first child window
			int nChildHandle = NativeWin32.GetWindow(nDeshWndHandle, NativeWin32.GW_CHILD);
                    	
			while (nChildHandle != 0)
			{
				//If the child window is this (SendKeys) application then ignore it.
				if (nChildHandle == this.Handle.ToInt32())
				{
					nChildHandle = NativeWin32.GetWindow(nChildHandle, NativeWin32.GW_HWNDNEXT);
				}

				// Get only visible windows
				if (NativeWin32.IsWindowVisible(nChildHandle) != 0)
				{
					StringBuilder sbTitle = new StringBuilder(1024);
					// Read the Title bar text on the windows to put in combobox
					NativeWin32.GetWindowText(nChildHandle, sbTitle, sbTitle.Capacity);
					String sWinTitle = sbTitle.ToString();
				{
					if (sWinTitle.Length > 0)
					{
						cboWindows.Items.Add(sWinTitle);
					}
				}
				}
				// Look for the next child.
				nChildHandle = NativeWin32.GetWindow(nChildHandle, NativeWin32.GW_HWNDNEXT);
			}
		}*/



		private void AppMain_Load(object sender, System.EventArgs e)
        {
            Dictionary.ctyping = "";
            Dictionary dc = new Dictionary();
            XPStyle.ApplyVisualStyles(this);
            //dc.ConvertOldDB();
            
			this.LoadDicts();
            
			new ProgKeys();
            RefreshSelection();
            TypingControl.RefreshWindows(this);

            this.InitializeEvents(false, true, true);
            Ghook.Install();
            Ghook.Enabled = false;
            
            IsLoaded = true;
            
		}
		private void OnTabChange(object sender,EventArgs e)
		{
            RefreshSelection();
		}
        private void RefreshSelection()
        {
            DataGridView dgv = (DataGridView)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
            Dictionary.currentCategory = (int)tabControl1.SelectedTab.Tag;//Dictionary.CategoryIDs[this.tabControl1.SelectedIndex];
            
            this.DefinitionStatus.Text = dgv.Rows.Count + " Definitions";
        }
        private void DataGrid_Click(object sender, EventArgs e)
        {
            dg = (DataGridView)sender;
            DataViewManager dvm = (DataViewManager)dg.Tag;
            DataSet dataset = dvm.DataSet;
           // MessageBox.Show(dataset.Tables["Dictionaries"].Rows[dg.CurrentRowIndex].ItemArray[4].ToString());  
        }
		private void GlobalKeyPress(object sender,KeyPressEventArgs e)
		{
			ProgKeys.ckeychar=e.KeyChar;
			Dictionary dct=new Dictionary();
			if(!ProgKeys.IsCtrlPressed&&!ProgKeys.IsAltPressed&&!ProgKeys.IsShiftPressed)
			{
				Dictionary.ctyping+=e.KeyChar;		
				//MessageBox.Show(this,"Still Alive "+Dictionary.ctyping);
				//dct=Dictionary.GetReplacement(Dictionary.ctyping,this);
			}
			
			
			
			if(dct!=null)
			{
				//MessageBox.Show(this,"dct not null");
				/*subs=dct.SubString();
				VariableInput vi=new VariableInput();
				
				
				hWnd=GetForegroundWindow();
				System.Threading.Thread.Sleep(100);
				while(!IsWindow(hWnd)){}
				while(hWnd!=GetForegroundWindow()&&hWnd!=GetActiveWindow())
				{SetActiveWindow(hWnd);SetForegroundWindow(hWnd);SetFocus(hWnd);}
				System.Threading.Thread.Sleep(100);


				subs=vi.GetVariableInput(subs,dct.GetVariableCount(subs),this);				
				subs=dct.GetValues(subs);				
				ArrayList finalstrings=dct.BreakByDelays(dct.ReplaceMainString(subs,dct.replacement));
				
				for(int i=0;i<finalstrings.Count;i++)
				{
					if(finalstrings[i].ToString().StartsWith("{%DELAY"))
						System.Threading.Thread.Sleep(int.Parse((string)finalstrings[i].ToString().Split('$').GetValue(1)));
					else
					{
						
						SendKeys.Send(finalstrings[i].ToString());
						//MessageBox.Show(this,"Sent");
					}
				}
				//ad.listBox1.Items.Add((string)finalstrings[i]);
				//ad.SetReplacementTextBox(dct.ReplaceMainString(subs,dct.replacement));
			*/
			}
			
		}
		/*private void GlobalKeyUp(object sender,KeyEventArgs e)
		{
			if(e.KeyCode==Keys.ControlKey)
				ProgKeys.IsCtrlPressed=false;
			else if(e.KeyCode==Keys.Alt)
				ProgKeys.IsAltPressed=false;
			else if(e.KeyCode==Keys.Shift)
				ProgKeys.IsShiftPressed=false;
		}
		private void GlobalKeyDown(object sender,KeyEventArgs e)
		{
            
			//MessageBox.Show(this,""+e.KeyData.ToString());
			if(e.KeyCode==Keys.Space)
			{	
				
				ProcessAndSend();
				
			}
			else if(e.Control)
				ProgKeys.IsCtrlPressed=true;
			else if(e.Alt)
				ProgKeys.IsAltPressed=true;
			else if(e.Shift)
				ProgKeys.IsShiftPressed=true;
			else
			{	
				if(ProgKeys.IsCtrlPressed)
				ProgKeys.CurrentKeys="{Ctrl}"+GetKeyDesc(e);
				
				else if(ProgKeys.IsAltPressed)
				ProgKeys.CurrentKeys="{Alt}"+GetKeyDesc(e);
				
				else if(ProgKeys.IsShiftPressed)
				ProgKeys.CurrentKeys="{Shift}"+GetKeyDesc(e);
				
			}
			
		}

		private string GetKeyDesc(KeyEventArgs e)
		{
			for(int i=0;i<Dictionary.ds.Tables["Keys"].Rows.Count;i++)
			if((int)Dictionary.ds.Tables["Keys"].Rows[i].ItemArray[2]==e.KeyValue)
			return Dictionary.ds.Tables["Keys"].Rows[i].ItemArray[3].ToString();
			return ""+ProgKeys.ckeychar;
		}

		private void ProcessAndSend()
		{Dictionary dct=Dictionary.GetReplacement(Dictionary.ctyping,this);
			if(dct!=null)
			{
				subs=dct.SubString();
				VariableInput vi=new VariableInput();

				subs=vi.GetVariableInput(subs,dct.GetVariableCount(subs),this);				
				subs=dct.GetValues(subs);				
				string tmp=dct.ReplaceMainString(subs,dct.replacement);
				//MessageBox.Show(this,tmp);

				ArrayList finalstrings=dct.BreakByDelays(tmp);
				
				for(int i=0;i<finalstrings.Count;i++)
				{
					//MessageBox.Show(this,finalstrings[i].ToString());
					if(finalstrings[i].ToString().StartsWith("{%DELAY"))
						System.Threading.Thread.Sleep(int.Parse((string)finalstrings[i].ToString().Split('$').GetValue(1)));
					else
					{
						int iHandle = NativeWin32.FindWindow(null, cboWindows.Text);
            
						NativeWin32.SetForegroundWindow(iHandle);
            
						
						System.Windows.Forms.SendKeys.SendWait(finalstrings[i].ToString());
						
					}
				}
			}
		}*/

		
		private void button1_Click(object sender, System.EventArgs e)
		{
			
			/*Dictionary dct=ad.GetEntry();
			dct.ParentForm=this;
			
			ad.ShowDialog(this);		
			this.textBox2.Text=st;*/
			
		}
		
		public void LoadDicts()
        {
            
			string[] select={"Select * from Data_Dictionary","select * from gen_Categories","select * from data_Chains","select * from gen_Options","select * from gen_Keys"};
			string[] Tnames={"Dictionaries","Categories","Chains","Options","Keys"};
			Dictionary.ds=new DataSet();
			
			DataSet ds=Dictionary.GetFromDB(select,Tnames);
            
			Dictionary.ds=ds;
            Dictionary.ds.Tables["Categories"].PrimaryKey =new DataColumn[]{ Dictionary.ds.Tables["Categories"].Columns[0]};
            Dictionary.ds.Tables["Dictionaries"].PrimaryKey =new DataColumn[]{ Dictionary.ds.Tables["Dictionaries"].Columns[0]};
            Dictionary.ds.Tables["Chains"].PrimaryKey = new DataColumn[] { Dictionary.ds.Tables["Chains"].Columns[0] };
            Dictionary.ds.Relations.Add("chains", Dictionary.ds.Tables["Categories"].Columns[0], Dictionary.ds.Tables["Chains"].Columns[1]);
			DataViewManager dvm;
			Dictionary.CategoryIDs=new int[ds.Tables["Categories"].Rows.Count];
            
			for(int i=0;i<ds.Tables["Categories"].Rows.Count;i++)
			{
                
				dvm=new DataViewManager(ds);
				dvm.DataViewSettings["Dictionaries"].RowFilter="CategoryID='"+ds.Tables["Categories"].Rows[i].ItemArray[0]+"'";

                AddDictionaryView(ds.Tables["Dictionaries"].Select("CategoryID='" + ds.Tables["Categories"].Rows[i].ItemArray[0] + "'"), ds.Tables["Categories"].Rows[i].ItemArray[1].ToString(), (int)ds.Tables["Categories"].Rows[i].ItemArray[0]);
                
				Dictionary.CategoryIDs[i]=(int)ds.Tables["Categories"].Rows[i].ItemArray[0];
			}
            
            Dictionary.currentCategory=(int)ds.Tables["Categories"].Rows[0].ItemArray[0];
            
            //tabControl1.ResumeLayout(false);
            //this.PerformLayout();
            
		}
		
		
		public void AddDictionaryView(DataRow[] dr,string txt,int CID)
		{
            DataTable dt=new DataTable("Dictionaries");
            dt = Dictionary.ds.Tables["Dictionaries"].Clone();
            foreach (DataRow d in dr)
                dt.ImportRow(d);
            
			TabPage tp=new TabPage();
           
            tp.Text = txt;
            tp.Name = "Tab Page";
            
            tp.Tag = CID;
            dg = new DataGridView();
            
            dg.Dock = DockStyle.Fill;
			dg.Location=new Point(8,8);
			dg.Size=new Size(408,224);
			dg.TabIndex=0;
			dg.Anchor=AnchorStyles.Top|AnchorStyles.Left;
            
            dg.SelectionChanged+=new EventHandler(DataGridViewChange);
			
			CreateGridStyles(dg);
			
            dg.DataSource = dt;
            //MessageBox.Show("Still Alive " + dg.Rows.Count);
            
            tp.UseVisualStyleBackColor = true;
            tp.AutoScroll = true;
            dg.BackgroundColor = tp.BackColor;

            
            tp.Size = new System.Drawing.Size(400, 200);
            
		    tp.Controls.Add(dg);
            
            tabControl1.Controls.Add(tp);
            
            
		}
		public void CreateGridStyles(DataGridView dg)
        {

            dg.EnableHeadersVisualStyles = true;
            dg.RowHeadersVisible = false;
            this.dg.AllowUserToAddRows = false;
            this.dg.AllowUserToDeleteRows = false;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.ReadOnly = true;
            dg.MultiSelect = false; ;
            
            dg.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            DataGridViewCellStyle style = new DataGridViewCellStyle();


            dg.DefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue;
            dg.DefaultCellStyle.DataSourceNullValue = "";
            dg.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Blue;
            dg.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            dg.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			DataGridViewTextBoxColumn word=new DataGridViewTextBoxColumn();
			word.HeaderText="Word";
		
            word.DataPropertyName = "UserWord";
			
            word.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
			word.ReadOnly=true;
            word.SortMode = DataGridViewColumnSortMode.NotSortable;
			DataGridViewTextBoxColumn shtcut=new DataGridViewTextBoxColumn();
			shtcut.HeaderText="ShortCut";
		
            shtcut.DataPropertyName = "Shortcut";
			
            shtcut.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
			shtcut.ReadOnly=true;
            shtcut.SortMode = DataGridViewColumnSortMode.NotSortable;
			DataGridViewTextBoxColumn repl=new DataGridViewTextBoxColumn();
			repl.HeaderText="Replacement Text";
		
            repl.DataPropertyName = "Replacement";
			
            repl.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
			repl.ReadOnly=true;
            repl.SortMode=DataGridViewColumnSortMode.NotSortable;
            
                        

                        //dg.AlternatingRowsDefaultCellStyle = style;
                        
                        //            dg.DefaultCellStyle = style;
                                    dg.BorderStyle = BorderStyle.Fixed3D;
                                    dg.ScrollBars = ScrollBars.Both;
                        
                        DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
                        id.DataPropertyName = "UserWordID";
            
                        DataGridViewTextBoxColumn cat = new DataGridViewTextBoxColumn();
                        cat.DataPropertyName = "CategoryID";

                        dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            
                        dg.Columns.AddRange(new DataGridViewColumn[] {word,shtcut,repl,id,cat });
                        
            
            dg.Columns[3].Visible = false;
            dg.Columns[4].Visible = false;
            
                
               
		}
        public void DataGridViewChange(object sender, System.EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
           // dgv.CurrentRow.Selected=true;
            try
            {
                this.textBox1.Text = dgv.SelectedRows[0].Cells[2].Value.ToString();
            }
            catch (Exception ex) { }
        }

		private void textBox1_TextChanged(object sender, System.EventArgs e)
		{
			
			this.textBox2.Text="";
            if(IsLoaded)
            {
                
                Dictionary dct = Dictionary.GetReplacement(this.textBox1.Text,false,(int)AppSettings.AppOptions["Active|Chained|All"]);

                if (dct != null)
                    this.textBox2.Text = dct.replacement;
            }
		}

		private void lnkRefresh_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			//RefreshWindows();

		}

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SendLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TypingControl.Appmain = this;
            if (this.textBox2.Text != "")
            {
                TypingControl.ProcessAndSend(new Dictionary(this.textBox1.Text,this.textBox2.Text,""),false,this);
                //dct.ReplaceByKey(subs);
            }
        }

        private void lnkRefresh_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

            TypingControl.RefreshWindows(this);
        }
        #region MODIFIERS
        private void LogKeyModifiers(MtKeyEventArgs e)
        {
            this.LogKeyModifiers(e.Modifiers);
        }
        private void LogKeyModifiers()
        {
            this.LogKeyModifiers(MtKeyboard.Modifiers);
        }
        private void LogKeyModifiers(Keys modifiers)
        {
            Color off_color = Color.Gray;
            Color on_color = Color.Black;

            this.CtrlStatus.ForeColor = MtKeyboard.IsControl(modifiers) ?
                on_color : off_color;
            AltStatus.ForeColor = MtKeyboard.IsAlt(modifiers) ?
                on_color : off_color;
            ShiftStatus.ForeColor = MtKeyboard.IsShift(modifiers) ?
                on_color : off_color;

            this.CapsStatus.ForeColor = MtKeyboard.CapsLock ?
                on_color : off_color;
            NumStatus.ForeColor = MtKeyboard.NumLock ?
                on_color : off_color;
            ScrollStatus.ForeColor = MtKeyboard.ScrollLock ?
                on_color : off_color;
        }
        #endregion MODIFIERS
        #region TIMER
        #region INITIALIZE

        
        private void InitializeTimer()
        {
            MtInputTimer.Tick += new MtInputTimerHandler(this.TimerTick);
            MtInputTimer.Enabled = true;
            
        }
        #endregion INITIALIZE

        #region TICK
        private void TimerTick()
        {
            // we use a timer here to update the modifiers
            // because if all hooks are turned off, then we won't get
            // any events that cause us to update the modifiers

            //if (MtWindow.ActiveWindow.Text == "TypoExpander")
                this.LogKeyModifiers();
                
          
        }
        
        #endregion TICK
        #endregion TIMER
        private void CapsStatus_Click(object sender, EventArgs e)
        {
            MtKeyboard.CapsLock = !MtKeyboard.CapsLock;
            this.LogKeyModifiers();
        }

        private void NumStatus_Click(object sender, EventArgs e)
        {
            MtKeyboard.NumLock = !MtKeyboard.NumLock;
            this.LogKeyModifiers();
        }

        private void ScrollStatus_Click(object sender, EventArgs e)
        {
            MtKeyboard.ScrollLock = !MtKeyboard.ScrollLock;
            this.LogKeyModifiers();
        }
        private void InitializeEvents(bool up, bool down, bool press)
        {
            if(down)
            this.Ghook.EnabledEventTypes |= MtKeyEventTypes.Down;
            else
            this.Ghook.EnabledEventTypes &= ~MtKeyEventTypes.Down;
            if (up)
            this.Ghook.EnabledEventTypes |= MtKeyEventTypes.Up;
            else
            this.Ghook.EnabledEventTypes &= ~MtKeyEventTypes.Up;
            if (press)
            this.Ghook.EnabledEventTypes |= MtKeyEventTypes.Press;
            else
            this.Ghook.EnabledEventTypes &= ~MtKeyEventTypes.Press;
        }

        private void TraySender_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!this.Visible)
            {
                this.Show();
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void StartTyping_Click(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void AddWrdBtn_Click(object sender, EventArgs e)
        {
            AddWordToDictionary();
        }
        
        public TabPage GetTab(int CID)
        {
            foreach (TabPage tb in tabControl1.TabPages)
                if ((int)tb.Tag == CID)
                    return tb;
            return null;
        }
        public void DelTab(int CID)
        {
            foreach (TabPage tb in tabControl1.TabPages)
                if ((int)tb.Tag == CID)
                    tabControl1.TabPages.RemoveAt(tabControl1.TabPages.IndexOf(tb));
            
        }
        public void UpdateTab(int CID,string title)
        {
            foreach (TabPage tb in tabControl1.TabPages)
                if ((int)tb.Tag == CID)
                    tb.Text = title;

        }
        private void OptionsButton_Click(object sender, EventArgs e)
        {
            ShowOptions();
        }

        private void ModifyButton_Click(object sender, EventArgs e)
        {

            ModifyWord();

        }

        private void DelButton_Click(object sender, EventArgs e)
        {
            DeleteWordFromDictionary();
        }

        private void DictButton_Click(object sender, EventArgs e)
        {
            ShowDictionaries();
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            Process.Start("http:\\www.google.com.pk");
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Do you really want to close the application", "Confirming", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation))
                Application.Exit();
        }
        private void AddWordToDictionary()
        {
            AddDialog ad = new AddDialog();
            TabPage tp;
            if (ad.ShowDialog(this) == DialogResult.OK)
            {
                tp = GetTab(Dictionary.currentCategory);
                //MessageBox.Show("Still Working");
                dg = (DataGridView)tp.Controls[0];

                DataTable dt = (DataTable)dg.DataSource;
                dt.ImportRow(Dictionary.ds.Tables["Dictionaries"].Rows.Find(ad.ID));
                dg.DataSource = dt;
                dg.Refresh();


                //MessageBox.Show("OK Clicked");
            }
        }
        private void DeleteWordFromDictionary()
        {
            TabPage tp = GetTab(Dictionary.currentCategory);
            dg = (DataGridView)tp.Controls[0];
            if (MessageBox.Show("Do you really want to delete", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                if (dg.Rows.Count > 0)
                {
                    int IDRecord = (int)dg.SelectedRows[0].Cells[0].Value;
                    if (Dictionary.DeleteWord(IDRecord))
                    {
                        dg.Rows.Remove(dg.SelectedRows[0]);
                        dg.Refresh();
                    }
                }
        }
        private void ModifyWord()
        {
            dg = (DataGridView)tabControl1.TabPages[Dictionary.currentCategory - 1].Controls[0];
            //MessageBox.Show("Word:" + (string)dg.SelectedRows[0].Cells[2].Value + "\nReplacement:" +(string) dg.SelectedRows[0].Cells[4].Value + "\nShortCut" + (string)dg.SelectedRows[0].Cells[3].Value);

            string sht = "";
            if (!(dg.SelectedRows[0].Cells[3].Value == DBNull.Value))
                sht = (string)dg.SelectedRows[0].Cells[3].Value;
            Dictionary dict = new Dictionary((string)dg.SelectedRows[0].Cells[2].Value, (string)dg.SelectedRows[0].Cells[4].Value, sht);
            AddDialog ad = new AddDialog(dict);
            DataRow dr;
            if (ad.ShowDialog(this) == DialogResult.OK)
            {


                DataTable dt = (DataTable)dg.DataSource;
                dt.AcceptChanges();
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    //if ((int)dt.Rows[i].ItemArray[1] == Dictionary.currentCategory)
                    if ((string)dt.Rows[i].ItemArray[2] == ad.dct.word)
                    {

                        dt.Rows[i][3] = ad.dct.shortcut;
                        dt.Rows[i][4] = ad.dct.replacement;


                        dt.AcceptChanges();


                    }
                }

                dg.DataSource = dt;
                dg.Refresh();


                //MessageBox.Show("OK Clicked");
            }
        }
        private void ShowDictionaries()
        {
            new Dictionaries(this).ShowDialog();
        }
        private void ShowOptions()
        {
            Options op = new Options();
            op.ShowDialog(this);
        }
        private void addWordToDictionaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddWordToDictionary();
        }

        private void deleteWordFromDictionaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteWordFromDictionary();
        }

        private void modifyWordFromDictionaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifyWord();
        }

        private void dictionariesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDictionaries();
        }

        private void makeChainsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Chains().ShowDialog();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOptions();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to Close the Application", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Application.Exit();
        }

        private void onLineHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http:\\www.google.com.pk");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        

	}


     public class XPStyle  
     {  
         /// <summary>  
         /// Gets a value indicating whether XP themes feature is present.  
         /// </summary>  
         /// <value><c>true</c> if XP themes feature is present; otherwise, <c>false</c>.</value>  
         public static bool IsXPThemesPresent {  
             get { return OSFeature.Feature.IsPresent(OSFeature.Themes); }  
         }  
   
         /// <summary>  
         /// Enables the visual styles for application.  
         /// </summary>  
         public static void EnableVisualStyles() {  
             if (!IsXPThemesPresent) return;  
             Application.EnableVisualStyles();  
             Application.DoEvents();       
         }  
   
         /// <summary>  
         /// Applies the visual styles for some control.  
         /// </summary>  
         /// <param name="control">The control.</param>  
         public static void ApplyVisualStyles(Control control) {  
             if (!IsXPThemesPresent) return;  
             ChangeControlFlatStyleToSystem(control);  
         }  
   
         private static void ChangeControlFlatStyleToSystem(Control control) {  
             // If the control derives from ButtonBase,   
             // set its FlatStyle property to FlatStyle.System.  
             if(control.GetType().BaseType == typeof(ButtonBase)&&control.GetType()!=typeof(Button)) {  
                 ((ButtonBase)control).FlatStyle = FlatStyle.System;   
             }  
   
             // If the control holds other controls, iterate through them also.  
             for(int i = 0; i < control.Controls.Count; i++) {  
                 ChangeControlFlatStyleToSystem(control.Controls[i]);  
             }  
         }  
   
     }  

}
