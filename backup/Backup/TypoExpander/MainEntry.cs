using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using gma.System.Windows;
using SendKeys;
using System.Text;
//using ImgBtn;
namespace RSH.TypoExpander
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		[DllImport("user32.dll")]
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
		IntPtr hOwn;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private TD.SandBar.MenuBar menuBar1;
		private TD.SandBar.MenuBarItem menuBarItem1;
		private TD.SandBar.MenuBarItem menuBarItem5;
		private TD.SandBar.MenuButtonItem menuButtonItem1;
		private TD.SandBar.MenuButtonItem menuButtonItem3;
		private TD.SandBar.MenuButtonItem menuButtonItem4;
		private TD.SandBar.MenuButtonItem menuButtonItem5;
		private TD.SandBar.MenuButtonItem menuButtonItem2;
		private TD.SandBar.MenuButtonItem menuButtonItem6;
		private TD.SandBar.MenuButtonItem menuButtonItem7;
		private TD.SandBar.MenuButtonItem menuButtonItem8;
		private TD.SandBar.MenuButtonItem menuButtonItem9;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Button button9;
		private UserActivityHook gh=new UserActivityHook();
		public static string val="";
		string st="";
		private System.Windows.Forms.ComboBox cboWindows;
		private System.Windows.Forms.LinkLabel lnkRefresh;
		ArrayList subs;
		//private PicButton AddBtn;
		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.tabControl1.SelectedIndexChanged+=new EventHandler(OnTabChange);			
			
//			if(libbtn.BackImage!=null&&libbtn.Hover!=null)
//				libbtn.SetImage(libbtn.BackImage,libbtn.Hover,libbtn.BackImage,libbtn.BackImage,libbtn.BackImage,ImageButton.Alignment.Center);			

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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.menuBar1 = new TD.SandBar.MenuBar();
			this.menuBarItem1 = new TD.SandBar.MenuBarItem();
			this.menuButtonItem1 = new TD.SandBar.MenuButtonItem();
			this.menuButtonItem2 = new TD.SandBar.MenuButtonItem();
			this.menuButtonItem3 = new TD.SandBar.MenuButtonItem();
			this.menuButtonItem4 = new TD.SandBar.MenuButtonItem();
			this.menuButtonItem5 = new TD.SandBar.MenuButtonItem();
			this.menuButtonItem6 = new TD.SandBar.MenuButtonItem();
			this.menuButtonItem7 = new TD.SandBar.MenuButtonItem();
			this.menuBarItem5 = new TD.SandBar.MenuBarItem();
			this.menuButtonItem8 = new TD.SandBar.MenuButtonItem();
			this.menuButtonItem9 = new TD.SandBar.MenuButtonItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button9 = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.cboWindows = new System.Windows.Forms.ComboBox();
			this.lnkRefresh = new System.Windows.Forms.LinkLabel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.DarkSlateBlue;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.GhostWhite;
			this.button1.Image = ((System.Drawing.Bitmap)(resources.GetObject("button1.Image")));
			this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.button1.Location = new System.Drawing.Point(0, 24);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 64);
			this.button1.TabIndex = 0;
			this.button1.Text = "Add Word";
			this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.DarkSlateBlue;
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button2.ForeColor = System.Drawing.Color.GhostWhite;
			this.button2.Image = ((System.Drawing.Bitmap)(resources.GetObject("button2.Image")));
			this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.button2.Location = new System.Drawing.Point(82, 24);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(80, 64);
			this.button2.TabIndex = 0;
			this.button2.Text = "Modify Word";
			this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.Color.DarkSlateBlue;
			this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button3.ForeColor = System.Drawing.Color.GhostWhite;
			this.button3.Image = ((System.Drawing.Bitmap)(resources.GetObject("button3.Image")));
			this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.button3.Location = new System.Drawing.Point(164, 24);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(80, 64);
			this.button3.TabIndex = 0;
			this.button3.Text = "Delete Word";
			this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// button4
			// 
			this.button4.BackColor = System.Drawing.Color.DarkSlateBlue;
			this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button4.ForeColor = System.Drawing.Color.GhostWhite;
			this.button4.Image = ((System.Drawing.Bitmap)(resources.GetObject("button4.Image")));
			this.button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.button4.Location = new System.Drawing.Point(246, 24);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(80, 64);
			this.button4.TabIndex = 0;
			this.button4.Text = "Dictioinaries";
			this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// button5
			// 
			this.button5.BackColor = System.Drawing.Color.DarkSlateBlue;
			this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button5.ForeColor = System.Drawing.Color.GhostWhite;
			this.button5.Image = ((System.Drawing.Bitmap)(resources.GetObject("button5.Image")));
			this.button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.button5.Location = new System.Drawing.Point(328, 24);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(80, 64);
			this.button5.TabIndex = 0;
			this.button5.Text = "Options";
			this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// button6
			// 
			this.button6.BackColor = System.Drawing.Color.DarkSlateBlue;
			this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button6.ForeColor = System.Drawing.Color.GhostWhite;
			this.button6.Image = ((System.Drawing.Bitmap)(resources.GetObject("button6.Image")));
			this.button6.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.button6.Location = new System.Drawing.Point(410, 24);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(80, 64);
			this.button6.TabIndex = 0;
			this.button6.Text = "OnLine Help";
			this.button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// button7
			// 
			this.button7.BackColor = System.Drawing.Color.DarkSlateBlue;
			this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button7.ForeColor = System.Drawing.Color.GhostWhite;
			this.button7.Image = ((System.Drawing.Bitmap)(resources.GetObject("button7.Image")));
			this.button7.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.button7.Location = new System.Drawing.Point(492, 24);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(80, 64);
			this.button7.TabIndex = 0;
			this.button7.Text = "About";
			this.button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// button8
			// 
			this.button8.BackColor = System.Drawing.Color.DarkSlateBlue;
			this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button8.ForeColor = System.Drawing.Color.GhostWhite;
			this.button8.Image = ((System.Drawing.Bitmap)(resources.GetObject("button8.Image")));
			this.button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.button8.Location = new System.Drawing.Point(574, 24);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(80, 64);
			this.button8.TabIndex = 0;
			this.button8.Text = "Exit";
			this.button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// menuBar1
			// 
			this.menuBar1.Guid = new System.Guid("042eedf0-abc0-4d96-95c8-e3c1c6c00a33");
			this.menuBar1.Items.AddRange(new TD.SandBar.ToolbarItemBase[] {
																			  this.menuBarItem1,
																			  this.menuBarItem5});
			this.menuBar1.Movable = false;
			this.menuBar1.Name = "menuBar1";
			this.menuBar1.OwnerForm = this;
			this.menuBar1.Size = new System.Drawing.Size(656, 22);
			this.menuBar1.TabIndex = 1;
			this.menuBar1.Text = "menuBar1";
			// 
			// menuBarItem1
			// 
			this.menuBarItem1.Items.AddRange(new TD.SandBar.ToolbarItemBase[] {
																				  this.menuButtonItem1,
																				  this.menuButtonItem2,
																				  this.menuButtonItem3,
																				  this.menuButtonItem4,
																				  this.menuButtonItem5,
																				  this.menuButtonItem6,
																				  this.menuButtonItem7});
			this.menuBarItem1.Text = "&File";
			// 
			// menuButtonItem1
			// 
			this.menuButtonItem1.BeginGroup = true;
			this.menuButtonItem1.Icon = ((System.Drawing.Icon)(resources.GetObject("menuButtonItem1.Icon")));
			this.menuButtonItem1.Text = "Add Word to Dictionary";
			// 
			// menuButtonItem2
			// 
			this.menuButtonItem2.Icon = ((System.Drawing.Icon)(resources.GetObject("menuButtonItem2.Icon")));
			this.menuButtonItem2.Text = "Modify Word from Dictionary";
			// 
			// menuButtonItem3
			// 
			this.menuButtonItem3.Icon = ((System.Drawing.Icon)(resources.GetObject("menuButtonItem3.Icon")));
			this.menuButtonItem3.Text = "Delete Word from Dictionaries";
			// 
			// menuButtonItem4
			// 
			this.menuButtonItem4.BeginGroup = true;
			this.menuButtonItem4.Icon = ((System.Drawing.Icon)(resources.GetObject("menuButtonItem4.Icon")));
			this.menuButtonItem4.Text = "Dictionaries";
			// 
			// menuButtonItem5
			// 
			this.menuButtonItem5.BeginGroup = true;
			this.menuButtonItem5.Icon = ((System.Drawing.Icon)(resources.GetObject("menuButtonItem5.Icon")));
			this.menuButtonItem5.Text = "Make Chain of Dictionaries";
			// 
			// menuButtonItem6
			// 
			this.menuButtonItem6.Icon = ((System.Drawing.Icon)(resources.GetObject("menuButtonItem6.Icon")));
			this.menuButtonItem6.Text = "Options";
			// 
			// menuButtonItem7
			// 
			this.menuButtonItem7.BeginGroup = true;
			this.menuButtonItem7.Icon = ((System.Drawing.Icon)(resources.GetObject("menuButtonItem7.Icon")));
			this.menuButtonItem7.Text = "Exit";
			// 
			// menuBarItem5
			// 
			this.menuBarItem5.Items.AddRange(new TD.SandBar.ToolbarItemBase[] {
																				  this.menuButtonItem8,
																				  this.menuButtonItem9});
			this.menuBarItem5.Text = "&Help";
			// 
			// menuButtonItem8
			// 
			this.menuButtonItem8.Icon = ((System.Drawing.Icon)(resources.GetObject("menuButtonItem8.Icon")));
			this.menuButtonItem8.Text = "OnLine Help";
			// 
			// menuButtonItem9
			// 
			this.menuButtonItem9.Icon = ((System.Drawing.Icon)(resources.GetObject("menuButtonItem9.Icon")));
			this.menuButtonItem9.Text = "About";
			// 
			// panel1
			// 
			this.panel1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.panel1.BackColor = System.Drawing.Color.AliceBlue;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.lnkRefresh,
																				 this.cboWindows,
																				 this.button9,
																				 this.tabControl1,
																				 this.textBox2,
																				 this.label1,
																				 this.textBox1});
			this.panel1.Location = new System.Drawing.Point(0, 86);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(656, 312);
			this.panel1.TabIndex = 2;
			// 
			// button9
			// 
			this.button9.BackColor = System.Drawing.Color.White;
			this.button9.ForeColor = System.Drawing.Color.Black;
			this.button9.Location = new System.Drawing.Point(8, 272);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(200, 23);
			this.button9.TabIndex = 4;
			this.button9.Text = "Start Magic Typing";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.tabControl1.Location = new System.Drawing.Point(216, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(432, 288);
			this.tabControl1.TabIndex = 3;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(8, 56);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox2.Size = new System.Drawing.Size(200, 208);
			this.textBox2.TabIndex = 2;
			this.textBox2.Text = "";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "word:";
			// 
			// textBox1
			// 
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox1.Location = new System.Drawing.Point(54, 8);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(152, 20);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "";
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// cboWindows
			// 
			this.cboWindows.Location = new System.Drawing.Point(8, 32);
			this.cboWindows.Name = "cboWindows";
			this.cboWindows.Size = new System.Drawing.Size(144, 21);
			this.cboWindows.TabIndex = 5;
			this.cboWindows.Text = "Select Window To send Replacement";
			// 
			// lnkRefresh
			// 
			this.lnkRefresh.Location = new System.Drawing.Point(160, 32);
			this.lnkRefresh.Name = "lnkRefresh";
			this.lnkRefresh.Size = new System.Drawing.Size(48, 16);
			this.lnkRefresh.TabIndex = 6;
			this.lnkRefresh.TabStop = true;
			this.lnkRefresh.Text = "Refresh";
			this.lnkRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRefresh_LinkClicked);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.DarkSlateBlue;
			this.ClientSize = new System.Drawing.Size(656, 398);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel1,
																		  this.menuBar1,
																		  this.button1,
																		  this.button2,
																		  this.button3,
																		  this.button4,
																		  this.button5,
																		  this.button6,
																		  this.button7,
																		  this.button8});
			this.ForeColor = System.Drawing.Color.LightGray;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "TypoExpander";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
		
		private void RefreshWindows()
		{
			cboWindows.Items.Clear();
			GetTaskWindows();
		}

		private void GetTaskWindows()
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
		}



		private void Form1_Load(object sender, System.EventArgs e)
		{
			RefreshWindows();
			this.LoadDicts();
			new ProgKeys();
			hOwn=this.Handle;
			//gh.OnMouseActivity+=new MouseEventHandler(MouseMoved);
			gh.KeyDown+=new KeyEventHandler(GlobalKeyDown);
			
			gh.KeyPress+=new KeyPressEventHandler(GlobalKeyPress);
			gh.KeyUp+=new KeyEventHandler(GlobalKeyUp);
			Dictionary.ctyping="";
		}
		private void OnTabChange(object sender,EventArgs e)
		{
			Dictionary.currentCategory=Dictionary.CategoryIDs[this.tabControl1.SelectedIndex];
		}
		
		private void GlobalKeyPress(object sender,KeyPressEventArgs e)
		{
			ProgKeys.ckeychar=e.KeyChar;
			Dictionary dct=new Dictionary();
			if(!ProgKeys.IsCtrlPressed&&!ProgKeys.IsAltPressed&&!ProgKeys.IsShiftPressed)
			{
				Dictionary.ctyping+=e.KeyChar;		
				MessageBox.Show(this,"Still Alive "+Dictionary.ctyping);
				dct=Dictionary.GetReplacement(Dictionary.ctyping,this);
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
		private void GlobalKeyUp(object sender,KeyEventArgs e)
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
		}

		
		private void button1_Click(object sender, System.EventArgs e)
		{
			AddDialog ad=new AddDialog();
			ad.ShowDialog(this);
			Dictionary dct=ad.GetEntry();
			dct.ParentForm=this;
			
			ad.ShowDialog(this);		
			this.textBox2.Text=st;
			
		}
		
		public void LoadDicts()
		{
			string[] select={"Select * from Data_Dictionary","select * from gen_Categories","select * from data_Chains","select * from gen_Options","select * from gen_Keys"};
			string[] Tnames={"Dictionaries","Categories","Chains","Options","Keys"};
			Dictionary.ds=new DataSet();
			/*DataSet ds1=Dictionary.GetFromDB(select,"Dictionaries");
			Dictionary.ds.Tables.Add(ds1.Tables["Dictionaries"].Copy());
			//MessageBox.Show(this,"Alive");
			select="select * from gen_Categories";
			
			DataSet ds2=Dictionary.GetFromDB(select,"Categories");
			Dictionary.ds.Tables.Add(ds2.Tables["Categories"].Copy());
			DataSet ds=Dictionary.GetFromDB("select * from data_Chains","Chains");
			Dictionary.ds.Tables.Add(ds.Tables["Chains"].Copy());
			ds=Dictionary.GetFromDB("select * from gen_Options","Options");
			Dictionary.ds.Tables.Add(ds.Tables["Options"].Copy());
			*/
			DataSet ds=Dictionary.GetFromDB(select,Tnames);
			Dictionary.ds=ds;
			//MessageBox.Show(this,ds.Tables["Keys"].Rows[1].ItemArray[1].ToString());

			DataViewManager dvm;
			Dictionary.CategoryIDs=new int[ds.Tables["Categories"].Rows.Count];
			for(int i=0;i<ds.Tables["Categories"].Rows.Count;i++)
			{	
				dvm=new DataViewManager(ds);
				dvm.DataViewSettings["Dictionaries"].RowFilter="CategoryID='"+ds.Tables["Categories"].Rows[i].ItemArray[0]+"'";				
				//MessageBox.Show(this,""+ds2.Tables["Categories"].Rows[i].ItemArray[0]);				
				//dataGrid1.DataBindings.Clear();
				//dataGrid1.SetDataBinding(dvm,"Dictionaries");
				AddDictionaryView(dvm,ds.Tables["Categories"].Rows[i].ItemArray[1].ToString());
				Dictionary.CategoryIDs[i]=(int)ds.Tables["Categories"].Rows[i].ItemArray[0];
			}
			Dictionary.currentCategory=(int)ds.Tables["Categories"].Rows[0].ItemArray[0];
		}
		
		
		public void AddDictionaryView(DataViewManager dvm,string txt)
		{
			TabPage tp=new TabPage(txt);
			tp.BackColor=System.Drawing.Color.AliceBlue;
			DataGrid dg=new DataGrid();
			dg.BeginInit();
			dg.Location=new Point(8,8);
			dg.Size=new Size(408,224);
			dg.TabIndex=0;
			dg.Anchor=AnchorStyles.Top|AnchorStyles.Left|AnchorStyles.Right|AnchorStyles.Bottom;			
			
			//dvm.DataViewSettings["Dictionaries"].Table.Columns.Remove("
			CreateGridStyles(dg);
			dg.SetDataBinding(dvm,"Dictionaries");
			dg.RowHeadersVisible=false;dg.CaptionVisible=false;
			tp.Controls.Add(dg);
			
			tabControl1.Controls.Add(tp);
		}
		public void CreateGridStyles(DataGrid dg)
		{
			DataGridTableStyle style=new DataGridTableStyle();
			style.MappingName="Dictionaries";
			style.AlternatingBackColor=System.Drawing.Color.Bisque;
			DataGridTextBoxColumn word=new DataGridTextBoxColumn();
			word.HeaderText="Word";
			word.MappingName="UserWord";
			word.Width=50;
			word.ReadOnly=true;
			word.NullText="";
			DataGridTextBoxColumn shtcut=new DataGridTextBoxColumn();
			shtcut.HeaderText="ShortCut";
			shtcut.MappingName="Shortcut";
			shtcut.Width=50;
			shtcut.ReadOnly=true;
			shtcut.NullText="";
			DataGridTextBoxColumn repl=new DataGridTextBoxColumn();
			repl.HeaderText="Replacement Text";
			repl.MappingName="Replacement";
			repl.Width=300;
			repl.ReadOnly=true;
			repl.NullText="";
			style.GridColumnStyles.AddRange(new DataGridColumnStyle[]{word,shtcut,repl});
			dg.TableStyles.Add(style);
		}

		private void textBox1_TextChanged(object sender, System.EventArgs e)
		{
			Dictionary.ctyping=this.textBox1.Text;
			this.textBox2.Text="";
			Dictionary dct=Dictionary.GetReplacement(Dictionary.ctyping,this);
			//MessageBox.Show(this,"Still Alive");
			if(dct!=null)
			this.textBox2.Text=dct.replacement;
		}

		private void lnkRefresh_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			RefreshWindows();

		}


		/*protected void SizeColumns(DataGrid grid)
		{
			Graphics g = CreateGraphics();  

			DataTable dataTable = (DataTable)grid.DataSource;

			DataGridTableStyle dataGridTableStyle = new DataGridTableStyle();

			dataGridTableStyle.MappingName = dataTable.TableName;

			foreach(DataColumn dataColumn in dataTable.Columns)
			{
				int maxSize = 0;

				SizeF size = g.MeasureString(
					dataColumn.ColumnName,
					grid.Font
					);

				if(size.Width > maxSize)
					maxSize = (int)size.Width;

				foreach(DataRow row in dataTable.Rows)
				{
					size = g.MeasureString(
						row[dataColumn.ColumnName].ToString(),
						grid.Font
						);

					if(size.Width > maxSize)
						maxSize = (int)size.Width;
				}

				DataGridColumnStyle dataGridColumnStyle =  new DataGridTextBoxColumn();
				dataGridColumnStyle.MappingName = dataColumn.ColumnName;
				dataGridColumnStyle.HeaderText = dataColumn.ColumnName;
				dataGridColumnStyle.Width = maxSize + 5;
				dataGridTableStyle.GridColumnStyles.Add(dataGridColumnStyle);
			}
			grid.TableStyles.Add(dataGridTableStyle);          

			g.Dispose();
		}*/
		

	}
}
