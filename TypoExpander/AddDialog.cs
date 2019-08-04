using System;
using System.Drawing;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Forms;
using MiniTools.UI.Input;

namespace RSH.TypoExpander
{
	/// <summary>
	/// Summary description for AddDialog.
	/// </summary>
	public class AddDialog : System.Windows.Forms.Form
	{
        private System.Windows.Forms.TextBox WordText;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button ShortcutKeyButton;
        private System.Windows.Forms.Button ClearButton;
		private System.Windows.Forms.Button SpecialValueButton;
		private System.Windows.Forms.Button KeyStrokeButton;
		private System.Windows.Forms.Button EditButton;
		private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        public Dictionary dct;
        private Button Button_Insert;
        private ContextMenu ContextMenu_Insert;
        private MenuItem MenuItem_InsertText;
        private MenuItem MenuItem_InsertSep2;
        private MenuItem MenuItem_InsertCommand;
        private MenuItem MenuItem_CommandRun;
        private MenuItem MenuItem_CommandSep1;
        private MenuItem MenuItem_CommandBeep;
        private MenuItem MenuItem_CommandBeep2;
        private MenuItem MenuItem_CommandSound;
        private MenuItem MenuItem_InsertWin;
        private MenuItem MenuItem_WinActivate;
        private MenuItem MenuItem_WinClose;
        private MenuItem MenuItem_WinSep1;
        private MenuItem MenuItem_WinMove;
        private MenuItem MenuItem_WinResize;
        private MenuItem MenuItem_WinTitle;
        private MenuItem MenuItem_WinSep2;
        private MenuItem MenuItem_WinMaximize;
        private MenuItem MenuItem_WinMinimize;
        private MenuItem MenuItem_WinRestore;
        private MenuItem MenuItem_WinSep3;
        private MenuItem MenuItem_WinFront;
        private MenuItem MenuItem_WinBack;
        private MenuItem MenuItem_InsertPause;
        private MenuItem MenuItem_PausePointOne;
        private MenuItem MenuItem_PausePointFive;
        private MenuItem MenuItem_PauseSep1;
        private MenuItem MenuItem_PauseOne;
        private MenuItem MenuItem_PauseTwo;
        private MenuItem MenuItem_PauseFive;
        private MenuItem MenuItem_PauseSep2;
        private MenuItem MenuItem_PauseMin;
        private MenuItem MenuItem_InsertSep3;
        private MenuItem MenuItem_InsertCursor;
        private MenuItem MenuItem_CursorLeft;
        private MenuItem MenuItem_CursorRight;
        private MenuItem MenuItem_CursorUp;
        private MenuItem MenuItem_CursorDown;
        private MenuItem MenuItem_CursorSep1;
        private MenuItem MenuItem_CursorLeft5;
        private MenuItem MenuItem_CursorCtrlShiftRight;
        private MenuItem MenuItem_InsertEdit;
        private MenuItem MenuItem_EditEnter;
        private MenuItem MenuItem_EditEscape;
        private MenuItem MenuItem_EditTab;
        private MenuItem MenuItem_EditSep1;
        private MenuItem MenuItem_EditSpace;
        private MenuItem MenuItem_EditBackspace;
        private MenuItem MenuItem_EditDelete;
        private MenuItem MenuItem_EditInsert;
        private MenuItem MenuItem_EditSep2;
        private MenuItem MenuItem_EditHome;
        private MenuItem MenuItem_EditEnd;
        private MenuItem MenuItem_EditPageUp;
        private MenuItem MenuItem_EditPageDown;
        private MenuItem MenuItem_InsertLock;
        private MenuItem MenuItem_LockCapsOn;
        private MenuItem MenuItem_LockCapsOff;
        private MenuItem MenuItem_LockCapsToggle;
        private MenuItem MenuItem_LockSep1;
        private MenuItem MenuItem_LockNumOn;
        private MenuItem MenuItem_LockNumOff;
        private MenuItem MenuItem_LockNumToggle;
        private MenuItem MenuItem_LockSep2;
        private MenuItem MenuItem_LockScrollOn;
        private MenuItem MenuItem_LockScrollOff;
        private MenuItem MenuItem_LockScrollToggle;
        private MenuItem MenuItem_InsertMod;
        private MenuItem MenuItem_ModAltDown;
        private MenuItem MenuItem_ModCtrlDown;
        private MenuItem MenuItem_ModShiftDown;
        private MenuItem MenuItem_ModSep1;
        private MenuItem MenuItem_ModAltUp;
        private MenuItem MenuItem_ModCtrlUp;
        private MenuItem MenuItem_ModShiftUp;
        private MenuItem MenuItem_ModSep2;
        private MenuItem MenuItem_ModCASDown;
        private MenuItem MenuItem_InsertSpecial;
        private MenuItem MenuItem_SpecialApp;
        private MenuItem MenuItem_SpecialBraceClose;
        private MenuItem MenuItem_SpecialBraceOpen;
        private MenuItem MenuItem_SpecialClear;
        private MenuItem MenuItem_SpecialFunction;
        private MenuItem MenuItem_SpecialPause;
        private MenuItem MenuItem_SpecialPrint;
        private MenuItem MenuItem_SpecialWinLeft;
        private MenuItem MenuItem_SpecialWinRight;
        private MenuItem MenuItem_InsertSep4;
        private MenuItem MenuItem_InsertMouse;
        private MenuItem MenuItem_MouseLeft;
        private MenuItem MenuItem_MouseMiddle;
        private MenuItem MenuItem_MouseRight;
        private MenuItem MenuItem_MouseSep1;
        private MenuItem MenuItem_MouseLeft2;
        private MenuItem MenuItem_MouseMiddle2;
        private MenuItem MenuItem_MouseRight2;
        private MenuItem MenuItem_MouseSep2;
        private MenuItem MenuItem_MouseMoveWin;
        private MenuItem MenuItem_MouseMoveScreen;
        private MenuItem MenuItem_MouseMove;
        private MenuItem MenuItem_MouseSep3;
        private MenuItem MenuItem_MouseScrollUp;
        private MenuItem MenuItem_MouseScrollDown;
        private ContextMenu ContextMenu_Edit;
        private MenuItem MenuItem_EditingUndo;
        private MenuItem MenuItem_EditingClear;
        private MenuItem MenuItem_Editing_Sep1;
        private MenuItem MenuItem_EditingCut;
        private MenuItem MenuItem_EditingCopy;
        private MenuItem MenuItem_EditingPaste;
        private MenuItem MenuItem_EditingSep2;
        private MenuItem MenuItem_EditingCopyAll;
        private MenuItem MenuItem_EditingPasteAll;
        private MenuItem menuItem1;
        private MenuItem MenuItem_Variable;
        public ListView VariableList;
        private ColumnHeader columnHeader1;
        private MenuItem MenuItem_SpecialValue;
        private MenuItem MenuItem_KeyStroke;
        public TextBox ReplaceText;
        private bool IsModify = false;
        public int ID;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AddDialog()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            //this.CHook.KeyEvent += new MtKeyEventHandler( this.HandleKeyEvent );
            VariableList.KeyDown += new KeyEventHandler(VariableList_KeyDown);
            dct = new Dictionary();
            VariableList.DoubleClick += new EventHandler(VariableList_DoubleClick);
            
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
        public AddDialog(Dictionary Dicts)
        {
            
            InitializeComponent();
            //this.CHook.KeyEvent += new MtKeyEventHandler( this.HandleKeyEvent );
            VariableList.KeyDown += new KeyEventHandler(VariableList_KeyDown);
            dct = Dicts;
            VariableList.DoubleClick += new EventHandler(VariableList_DoubleClick);
            
            WordText.Text = dct.word;
            ReplaceText.Text = dct.replacement;
            ShortcutKeyButton.Text = dct.shortcut;
            
            StringDictionary vars = dct.GetVariables();
            
            ListViewItem li;
            if(vars.Count>0)
            foreach(DictionaryEntry de in vars)
            {
                li = new ListViewItem((string)de.Key);
                li.Tag = (string)de.Value;
                li.ToolTipText = (string)de.Value;
                if (!ListItemExists(li))
                VariableList.Items.Add(li);
                
            }
            WordText.Enabled = false;
            IsModify = true;
        }
        private bool ListItemExists(ListViewItem li)
        {
            for (int i = 0; i < VariableList.Items.Count;i++ )
                if (li.Text == VariableList.Items[i].Text)
                    return true;
            return false;
        }

        void VariableList_KeyDown(object sender, KeyEventArgs e)
        {

            string text=ReplaceText.Text;
            string repl=(string)VariableList.SelectedItems[0].Tag;
            if (e.KeyCode == Keys.Delete)
            {

                if (VariableList.Items.Count > 0)
                {
                    ReplaceText.Text = text.Remove(text.IndexOf(repl), repl.Length);
                    VariableList.SelectedItems[0].Remove();
                }
            }
        }
       
        void VariableList_DoubleClick(object sender, EventArgs e)
        {
                        
            InputVariables IV = new InputVariables(VariableList.SelectedItems[0].Text,(string)VariableList.SelectedItems[0].Tag);
            
            int caret=0;
            
            if (IV.ShowDialog() == DialogResult.OK)
            {
                if (VariableList.Items.Count > 0)
                {
                    
                    caret =ReplaceText.SelectionStart;
                    this.ReplaceText.Text = this.ReplaceText.Text.Replace((string)VariableList.SelectedItems[0].Tag, IV.Var);
                    this.VariableList.SelectedItems[0].Tag = IV.Var;
                    this.VariableList.SelectedItems[0].ToolTipText = IV.Var;
                    ReplaceText.SelectionStart = caret;
                    ReplaceText.Select();
                }    
                    
            }
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
            this.WordText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ShortcutKeyButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SpecialValueButton = new System.Windows.Forms.Button();
            this.KeyStrokeButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.Button_Insert = new System.Windows.Forms.Button();
            this.ContextMenu_Insert = new System.Windows.Forms.ContextMenu();
            this.MenuItem_InsertText = new System.Windows.Forms.MenuItem();
            this.MenuItem_InsertSep2 = new System.Windows.Forms.MenuItem();
            this.MenuItem_InsertCommand = new System.Windows.Forms.MenuItem();
            this.MenuItem_CommandRun = new System.Windows.Forms.MenuItem();
            this.MenuItem_CommandSep1 = new System.Windows.Forms.MenuItem();
            this.MenuItem_CommandBeep = new System.Windows.Forms.MenuItem();
            this.MenuItem_CommandBeep2 = new System.Windows.Forms.MenuItem();
            this.MenuItem_CommandSound = new System.Windows.Forms.MenuItem();
            this.MenuItem_InsertWin = new System.Windows.Forms.MenuItem();
            this.MenuItem_WinActivate = new System.Windows.Forms.MenuItem();
            this.MenuItem_WinClose = new System.Windows.Forms.MenuItem();
            this.MenuItem_WinSep1 = new System.Windows.Forms.MenuItem();
            this.MenuItem_WinMove = new System.Windows.Forms.MenuItem();
            this.MenuItem_WinResize = new System.Windows.Forms.MenuItem();
            this.MenuItem_WinTitle = new System.Windows.Forms.MenuItem();
            this.MenuItem_WinSep2 = new System.Windows.Forms.MenuItem();
            this.MenuItem_WinMaximize = new System.Windows.Forms.MenuItem();
            this.MenuItem_WinMinimize = new System.Windows.Forms.MenuItem();
            this.MenuItem_WinRestore = new System.Windows.Forms.MenuItem();
            this.MenuItem_WinSep3 = new System.Windows.Forms.MenuItem();
            this.MenuItem_WinFront = new System.Windows.Forms.MenuItem();
            this.MenuItem_WinBack = new System.Windows.Forms.MenuItem();
            this.MenuItem_InsertPause = new System.Windows.Forms.MenuItem();
            this.MenuItem_PausePointOne = new System.Windows.Forms.MenuItem();
            this.MenuItem_PausePointFive = new System.Windows.Forms.MenuItem();
            this.MenuItem_PauseSep1 = new System.Windows.Forms.MenuItem();
            this.MenuItem_PauseOne = new System.Windows.Forms.MenuItem();
            this.MenuItem_PauseTwo = new System.Windows.Forms.MenuItem();
            this.MenuItem_PauseFive = new System.Windows.Forms.MenuItem();
            this.MenuItem_PauseSep2 = new System.Windows.Forms.MenuItem();
            this.MenuItem_PauseMin = new System.Windows.Forms.MenuItem();
            this.MenuItem_InsertSep3 = new System.Windows.Forms.MenuItem();
            this.MenuItem_InsertCursor = new System.Windows.Forms.MenuItem();
            this.MenuItem_CursorLeft = new System.Windows.Forms.MenuItem();
            this.MenuItem_CursorRight = new System.Windows.Forms.MenuItem();
            this.MenuItem_CursorUp = new System.Windows.Forms.MenuItem();
            this.MenuItem_CursorDown = new System.Windows.Forms.MenuItem();
            this.MenuItem_CursorSep1 = new System.Windows.Forms.MenuItem();
            this.MenuItem_CursorLeft5 = new System.Windows.Forms.MenuItem();
            this.MenuItem_CursorCtrlShiftRight = new System.Windows.Forms.MenuItem();
            this.MenuItem_InsertEdit = new System.Windows.Forms.MenuItem();
            this.MenuItem_EditEnter = new System.Windows.Forms.MenuItem();
            this.MenuItem_EditEscape = new System.Windows.Forms.MenuItem();
            this.MenuItem_EditTab = new System.Windows.Forms.MenuItem();
            this.MenuItem_EditSep1 = new System.Windows.Forms.MenuItem();
            this.MenuItem_EditSpace = new System.Windows.Forms.MenuItem();
            this.MenuItem_EditBackspace = new System.Windows.Forms.MenuItem();
            this.MenuItem_EditDelete = new System.Windows.Forms.MenuItem();
            this.MenuItem_EditInsert = new System.Windows.Forms.MenuItem();
            this.MenuItem_EditSep2 = new System.Windows.Forms.MenuItem();
            this.MenuItem_EditHome = new System.Windows.Forms.MenuItem();
            this.MenuItem_EditEnd = new System.Windows.Forms.MenuItem();
            this.MenuItem_EditPageUp = new System.Windows.Forms.MenuItem();
            this.MenuItem_EditPageDown = new System.Windows.Forms.MenuItem();
            this.MenuItem_InsertLock = new System.Windows.Forms.MenuItem();
            this.MenuItem_LockCapsOn = new System.Windows.Forms.MenuItem();
            this.MenuItem_LockCapsOff = new System.Windows.Forms.MenuItem();
            this.MenuItem_LockCapsToggle = new System.Windows.Forms.MenuItem();
            this.MenuItem_LockSep1 = new System.Windows.Forms.MenuItem();
            this.MenuItem_LockNumOn = new System.Windows.Forms.MenuItem();
            this.MenuItem_LockNumOff = new System.Windows.Forms.MenuItem();
            this.MenuItem_LockNumToggle = new System.Windows.Forms.MenuItem();
            this.MenuItem_LockSep2 = new System.Windows.Forms.MenuItem();
            this.MenuItem_LockScrollOn = new System.Windows.Forms.MenuItem();
            this.MenuItem_LockScrollOff = new System.Windows.Forms.MenuItem();
            this.MenuItem_LockScrollToggle = new System.Windows.Forms.MenuItem();
            this.MenuItem_InsertMod = new System.Windows.Forms.MenuItem();
            this.MenuItem_ModAltDown = new System.Windows.Forms.MenuItem();
            this.MenuItem_ModCtrlDown = new System.Windows.Forms.MenuItem();
            this.MenuItem_ModShiftDown = new System.Windows.Forms.MenuItem();
            this.MenuItem_ModSep1 = new System.Windows.Forms.MenuItem();
            this.MenuItem_ModAltUp = new System.Windows.Forms.MenuItem();
            this.MenuItem_ModCtrlUp = new System.Windows.Forms.MenuItem();
            this.MenuItem_ModShiftUp = new System.Windows.Forms.MenuItem();
            this.MenuItem_ModSep2 = new System.Windows.Forms.MenuItem();
            this.MenuItem_ModCASDown = new System.Windows.Forms.MenuItem();
            this.MenuItem_InsertSpecial = new System.Windows.Forms.MenuItem();
            this.MenuItem_SpecialApp = new System.Windows.Forms.MenuItem();
            this.MenuItem_SpecialBraceClose = new System.Windows.Forms.MenuItem();
            this.MenuItem_SpecialBraceOpen = new System.Windows.Forms.MenuItem();
            this.MenuItem_SpecialClear = new System.Windows.Forms.MenuItem();
            this.MenuItem_SpecialFunction = new System.Windows.Forms.MenuItem();
            this.MenuItem_SpecialPause = new System.Windows.Forms.MenuItem();
            this.MenuItem_SpecialPrint = new System.Windows.Forms.MenuItem();
            this.MenuItem_SpecialWinLeft = new System.Windows.Forms.MenuItem();
            this.MenuItem_SpecialWinRight = new System.Windows.Forms.MenuItem();
            this.MenuItem_InsertSep4 = new System.Windows.Forms.MenuItem();
            this.MenuItem_InsertMouse = new System.Windows.Forms.MenuItem();
            this.MenuItem_MouseLeft = new System.Windows.Forms.MenuItem();
            this.MenuItem_MouseMiddle = new System.Windows.Forms.MenuItem();
            this.MenuItem_MouseRight = new System.Windows.Forms.MenuItem();
            this.MenuItem_MouseSep1 = new System.Windows.Forms.MenuItem();
            this.MenuItem_MouseLeft2 = new System.Windows.Forms.MenuItem();
            this.MenuItem_MouseMiddle2 = new System.Windows.Forms.MenuItem();
            this.MenuItem_MouseRight2 = new System.Windows.Forms.MenuItem();
            this.MenuItem_MouseSep2 = new System.Windows.Forms.MenuItem();
            this.MenuItem_MouseMoveWin = new System.Windows.Forms.MenuItem();
            this.MenuItem_MouseMoveScreen = new System.Windows.Forms.MenuItem();
            this.MenuItem_MouseMove = new System.Windows.Forms.MenuItem();
            this.MenuItem_MouseSep3 = new System.Windows.Forms.MenuItem();
            this.MenuItem_MouseScrollUp = new System.Windows.Forms.MenuItem();
            this.MenuItem_MouseScrollDown = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.MenuItem_Variable = new System.Windows.Forms.MenuItem();
            this.MenuItem_SpecialValue = new System.Windows.Forms.MenuItem();
            this.MenuItem_KeyStroke = new System.Windows.Forms.MenuItem();
            this.ContextMenu_Edit = new System.Windows.Forms.ContextMenu();
            this.MenuItem_EditingUndo = new System.Windows.Forms.MenuItem();
            this.MenuItem_EditingClear = new System.Windows.Forms.MenuItem();
            this.MenuItem_Editing_Sep1 = new System.Windows.Forms.MenuItem();
            this.MenuItem_EditingCut = new System.Windows.Forms.MenuItem();
            this.MenuItem_EditingCopy = new System.Windows.Forms.MenuItem();
            this.MenuItem_EditingPaste = new System.Windows.Forms.MenuItem();
            this.MenuItem_EditingSep2 = new System.Windows.Forms.MenuItem();
            this.MenuItem_EditingCopyAll = new System.Windows.Forms.MenuItem();
            this.MenuItem_EditingPasteAll = new System.Windows.Forms.MenuItem();
            this.VariableList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ReplaceText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // WordText
            // 
            this.WordText.Location = new System.Drawing.Point(24, 19);
            this.WordText.Name = "WordText";
            this.WordText.Size = new System.Drawing.Size(208, 20);
            this.WordText.TabIndex = 0;
            this.WordText.TextChanged += new System.EventHandler(this.WordText_TextChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Word:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Replacement:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(392, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Variables:";
            // 
            // ShortcutKeyButton
            // 
            this.ShortcutKeyButton.Enabled = false;
            this.ShortcutKeyButton.Location = new System.Drawing.Point(248, 16);
            this.ShortcutKeyButton.Name = "ShortcutKeyButton";
            this.ShortcutKeyButton.Size = new System.Drawing.Size(160, 23);
            this.ShortcutKeyButton.TabIndex = 4;
            this.ShortcutKeyButton.Text = "Assign ShortCut Key";
            this.ShortcutKeyButton.Click += new System.EventHandler(this.ShortcutKeyButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Enabled = false;
            this.ClearButton.Location = new System.Drawing.Point(424, 16);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(112, 23);
            this.ClearButton.TabIndex = 4;
            this.ClearButton.Text = "Clear Shorcut";
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // SpecialValueButton
            // 
            this.SpecialValueButton.Enabled = false;
            this.SpecialValueButton.Location = new System.Drawing.Point(219, 336);
            this.SpecialValueButton.Name = "SpecialValueButton";
            this.SpecialValueButton.Size = new System.Drawing.Size(88, 23);
            this.SpecialValueButton.TabIndex = 4;
            this.SpecialValueButton.Text = "Special Value";
            this.SpecialValueButton.Click += new System.EventHandler(this.SpecialValueButton_Click);
            // 
            // KeyStrokeButton
            // 
            this.KeyStrokeButton.Enabled = false;
            this.KeyStrokeButton.Location = new System.Drawing.Point(319, 336);
            this.KeyStrokeButton.Name = "KeyStrokeButton";
            this.KeyStrokeButton.Size = new System.Drawing.Size(88, 23);
            this.KeyStrokeButton.TabIndex = 4;
            this.KeyStrokeButton.Text = "KeyStroke";
            this.KeyStrokeButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // EditButton
            // 
            this.EditButton.Enabled = false;
            this.EditButton.Location = new System.Drawing.Point(119, 336);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(88, 23);
            this.EditButton.TabIndex = 4;
            this.EditButton.Text = "Edit";
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Enabled = false;
            this.OKButton.Location = new System.Drawing.Point(336, 368);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(112, 23);
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "OK";
            this.OKButton.Click += new System.EventHandler(this.button7_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(448, 368);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(112, 23);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.Click += new System.EventHandler(this.button8_Click);
            // 
            // Button_Insert
            // 
            this.Button_Insert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_Insert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Insert.Enabled = false;
            this.Button_Insert.Location = new System.Drawing.Point(27, 336);
            this.Button_Insert.Name = "Button_Insert";
            this.Button_Insert.Size = new System.Drawing.Size(80, 23);
            this.Button_Insert.TabIndex = 6;
            this.Button_Insert.Text = "Insert...";
            this.Button_Insert.Click += new System.EventHandler(this.Button_Insert_Click);
            // 
            // ContextMenu_Insert
            // 
            this.ContextMenu_Insert.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem_InsertText,
            this.MenuItem_InsertSep2,
            this.MenuItem_InsertCommand,
            this.MenuItem_InsertWin,
            this.MenuItem_InsertPause,
            this.MenuItem_InsertSep3,
            this.MenuItem_InsertCursor,
            this.MenuItem_InsertEdit,
            this.MenuItem_InsertLock,
            this.MenuItem_InsertMod,
            this.MenuItem_InsertSpecial,
            this.MenuItem_InsertSep4,
            this.MenuItem_InsertMouse,
            this.menuItem1,
            this.MenuItem_Variable,
            this.MenuItem_SpecialValue,
            this.MenuItem_KeyStroke});
            // 
            // MenuItem_InsertText
            // 
            this.MenuItem_InsertText.Index = 0;
            this.MenuItem_InsertText.Text = "Text";
            this.MenuItem_InsertText.Click += new System.EventHandler(this.MenuItem_InsertText_Click);
            // 
            // MenuItem_InsertSep2
            // 
            this.MenuItem_InsertSep2.Index = 1;
            this.MenuItem_InsertSep2.Text = "-";
            // 
            // MenuItem_InsertCommand
            // 
            this.MenuItem_InsertCommand.Index = 2;
            this.MenuItem_InsertCommand.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem_CommandRun,
            this.MenuItem_CommandSep1,
            this.MenuItem_CommandBeep,
            this.MenuItem_CommandBeep2,
            this.MenuItem_CommandSound});
            this.MenuItem_InsertCommand.Text = "Commands";
            // 
            // MenuItem_CommandRun
            // 
            this.MenuItem_CommandRun.Index = 0;
            this.MenuItem_CommandRun.Text = "Run Program";
            this.MenuItem_CommandRun.Click += new System.EventHandler(this.MenuItem_CommandRun_Click);
            // 
            // MenuItem_CommandSep1
            // 
            this.MenuItem_CommandSep1.Index = 1;
            this.MenuItem_CommandSep1.Text = "-";
            // 
            // MenuItem_CommandBeep
            // 
            this.MenuItem_CommandBeep.Index = 2;
            this.MenuItem_CommandBeep.Text = "Beep";
            this.MenuItem_CommandBeep.Click += new System.EventHandler(this.MenuItem_CommandBeep_Click);
            // 
            // MenuItem_CommandBeep2
            // 
            this.MenuItem_CommandBeep2.Index = 3;
            this.MenuItem_CommandBeep2.Text = "Beep #2";
            this.MenuItem_CommandBeep2.Click += new System.EventHandler(this.MenuItem_CommandBeep2_Click);
            // 
            // MenuItem_CommandSound
            // 
            this.MenuItem_CommandSound.Index = 4;
            this.MenuItem_CommandSound.Text = "Play Sound";
            this.MenuItem_CommandSound.Click += new System.EventHandler(this.MenuItem_CommandSound_Click);
            // 
            // MenuItem_InsertWin
            // 
            this.MenuItem_InsertWin.Index = 3;
            this.MenuItem_InsertWin.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem_WinActivate,
            this.MenuItem_WinClose,
            this.MenuItem_WinSep1,
            this.MenuItem_WinMove,
            this.MenuItem_WinResize,
            this.MenuItem_WinTitle,
            this.MenuItem_WinSep2,
            this.MenuItem_WinMaximize,
            this.MenuItem_WinMinimize,
            this.MenuItem_WinRestore,
            this.MenuItem_WinSep3,
            this.MenuItem_WinFront,
            this.MenuItem_WinBack});
            this.MenuItem_InsertWin.Text = "Window Commands";
            // 
            // MenuItem_WinActivate
            // 
            this.MenuItem_WinActivate.Index = 0;
            this.MenuItem_WinActivate.Text = "Activate";
            this.MenuItem_WinActivate.Click += new System.EventHandler(this.MenuItem_WinActivate_Click);
            // 
            // MenuItem_WinClose
            // 
            this.MenuItem_WinClose.Index = 1;
            this.MenuItem_WinClose.Text = "Close";
            this.MenuItem_WinClose.Click += new System.EventHandler(this.MenuItem_WinClose_Click);
            // 
            // MenuItem_WinSep1
            // 
            this.MenuItem_WinSep1.Index = 2;
            this.MenuItem_WinSep1.Text = "-";
            // 
            // MenuItem_WinMove
            // 
            this.MenuItem_WinMove.Index = 3;
            this.MenuItem_WinMove.Text = "Move";
            this.MenuItem_WinMove.Click += new System.EventHandler(this.MenuItem_WinMove_Click);
            // 
            // MenuItem_WinResize
            // 
            this.MenuItem_WinResize.Index = 4;
            this.MenuItem_WinResize.Text = "Resize";
            this.MenuItem_WinResize.Click += new System.EventHandler(this.MenuItem_WinResize_Click);
            // 
            // MenuItem_WinTitle
            // 
            this.MenuItem_WinTitle.Index = 5;
            this.MenuItem_WinTitle.Text = "Set Title";
            this.MenuItem_WinTitle.Click += new System.EventHandler(this.MenuItem_WinTitle_Click);
            // 
            // MenuItem_WinSep2
            // 
            this.MenuItem_WinSep2.Index = 6;
            this.MenuItem_WinSep2.Text = "-";
            // 
            // MenuItem_WinMaximize
            // 
            this.MenuItem_WinMaximize.Index = 7;
            this.MenuItem_WinMaximize.Text = "Maximize";
            this.MenuItem_WinMaximize.Click += new System.EventHandler(this.MenuItem_WinMaximize_Click);
            // 
            // MenuItem_WinMinimize
            // 
            this.MenuItem_WinMinimize.Index = 8;
            this.MenuItem_WinMinimize.Text = "Minimize";
            this.MenuItem_WinMinimize.Click += new System.EventHandler(this.MenuItem_WinMinimize_Click);
            // 
            // MenuItem_WinRestore
            // 
            this.MenuItem_WinRestore.Index = 9;
            this.MenuItem_WinRestore.Text = "Restore";
            this.MenuItem_WinRestore.Click += new System.EventHandler(this.MenuItem_WinRestore_Click);
            // 
            // MenuItem_WinSep3
            // 
            this.MenuItem_WinSep3.Index = 10;
            this.MenuItem_WinSep3.Text = "-";
            // 
            // MenuItem_WinFront
            // 
            this.MenuItem_WinFront.Index = 11;
            this.MenuItem_WinFront.Text = "Bring To Front";
            this.MenuItem_WinFront.Click += new System.EventHandler(this.MenuItem_WinFront_Click);
            // 
            // MenuItem_WinBack
            // 
            this.MenuItem_WinBack.Index = 12;
            this.MenuItem_WinBack.Text = "Send To Back";
            this.MenuItem_WinBack.Click += new System.EventHandler(this.MenuItem_WinBack_Click);
            // 
            // MenuItem_InsertPause
            // 
            this.MenuItem_InsertPause.Index = 4;
            this.MenuItem_InsertPause.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem_PausePointOne,
            this.MenuItem_PausePointFive,
            this.MenuItem_PauseSep1,
            this.MenuItem_PauseOne,
            this.MenuItem_PauseTwo,
            this.MenuItem_PauseFive,
            this.MenuItem_PauseSep2,
            this.MenuItem_PauseMin});
            this.MenuItem_InsertPause.Text = "Pause";
            // 
            // MenuItem_PausePointOne
            // 
            this.MenuItem_PausePointOne.Index = 0;
            this.MenuItem_PausePointOne.Text = "0.1 Seconds";
            this.MenuItem_PausePointOne.Click += new System.EventHandler(this.MenuItem_PausePointOne_Click);
            // 
            // MenuItem_PausePointFive
            // 
            this.MenuItem_PausePointFive.Index = 1;
            this.MenuItem_PausePointFive.Text = "0.5 Seconds";
            this.MenuItem_PausePointFive.Click += new System.EventHandler(this.MenuItem_PausePointFive_Click);
            // 
            // MenuItem_PauseSep1
            // 
            this.MenuItem_PauseSep1.Index = 2;
            this.MenuItem_PauseSep1.Text = "-";
            // 
            // MenuItem_PauseOne
            // 
            this.MenuItem_PauseOne.Index = 3;
            this.MenuItem_PauseOne.Text = "1 Second";
            this.MenuItem_PauseOne.Click += new System.EventHandler(this.MenuItem_PauseOne_Click);
            // 
            // MenuItem_PauseTwo
            // 
            this.MenuItem_PauseTwo.Index = 4;
            this.MenuItem_PauseTwo.Text = "2 Seconds";
            this.MenuItem_PauseTwo.Click += new System.EventHandler(this.MenuItem_PauseTwo_Click);
            // 
            // MenuItem_PauseFive
            // 
            this.MenuItem_PauseFive.Index = 5;
            this.MenuItem_PauseFive.Text = "5 Seconds";
            this.MenuItem_PauseFive.Click += new System.EventHandler(this.MenuItem_PauseFive_Click);
            // 
            // MenuItem_PauseSep2
            // 
            this.MenuItem_PauseSep2.Index = 6;
            this.MenuItem_PauseSep2.Text = "-";
            // 
            // MenuItem_PauseMin
            // 
            this.MenuItem_PauseMin.Index = 7;
            this.MenuItem_PauseMin.Text = "1 Minute";
            this.MenuItem_PauseMin.Click += new System.EventHandler(this.MenuItem_PauseMin_Click);
            // 
            // MenuItem_InsertSep3
            // 
            this.MenuItem_InsertSep3.Index = 5;
            this.MenuItem_InsertSep3.Text = "-";
            // 
            // MenuItem_InsertCursor
            // 
            this.MenuItem_InsertCursor.Index = 6;
            this.MenuItem_InsertCursor.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem_CursorLeft,
            this.MenuItem_CursorRight,
            this.MenuItem_CursorUp,
            this.MenuItem_CursorDown,
            this.MenuItem_CursorSep1,
            this.MenuItem_CursorLeft5,
            this.MenuItem_CursorCtrlShiftRight});
            this.MenuItem_InsertCursor.Text = "Cursor Keys";
            // 
            // MenuItem_CursorLeft
            // 
            this.MenuItem_CursorLeft.Index = 0;
            this.MenuItem_CursorLeft.Text = "Left";
            this.MenuItem_CursorLeft.Click += new System.EventHandler(this.MenuItem_CursorLeft_Click);
            // 
            // MenuItem_CursorRight
            // 
            this.MenuItem_CursorRight.Index = 1;
            this.MenuItem_CursorRight.Text = "Right";
            this.MenuItem_CursorRight.Click += new System.EventHandler(this.MenuItem_CursorRight_Click);
            // 
            // MenuItem_CursorUp
            // 
            this.MenuItem_CursorUp.Index = 2;
            this.MenuItem_CursorUp.Text = "Up";
            this.MenuItem_CursorUp.Click += new System.EventHandler(this.MenuItem_CursorUp_Click);
            // 
            // MenuItem_CursorDown
            // 
            this.MenuItem_CursorDown.Index = 3;
            this.MenuItem_CursorDown.Text = "Down";
            this.MenuItem_CursorDown.Click += new System.EventHandler(this.MenuItem_CursorDown_Click);
            // 
            // MenuItem_CursorSep1
            // 
            this.MenuItem_CursorSep1.Index = 4;
            this.MenuItem_CursorSep1.Text = "-";
            // 
            // MenuItem_CursorLeft5
            // 
            this.MenuItem_CursorLeft5.Index = 5;
            this.MenuItem_CursorLeft5.Text = "Left 5 Times";
            this.MenuItem_CursorLeft5.Click += new System.EventHandler(this.MenuItem_CursorLeft5_Click);
            // 
            // MenuItem_CursorCtrlShiftRight
            // 
            this.MenuItem_CursorCtrlShiftRight.Index = 6;
            this.MenuItem_CursorCtrlShiftRight.Text = "Ctrl+Shift+Right";
            this.MenuItem_CursorCtrlShiftRight.Click += new System.EventHandler(this.MenuItem_CursorCtrlShiftRight_Click);
            // 
            // MenuItem_InsertEdit
            // 
            this.MenuItem_InsertEdit.Index = 7;
            this.MenuItem_InsertEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem_EditEnter,
            this.MenuItem_EditEscape,
            this.MenuItem_EditTab,
            this.MenuItem_EditSep1,
            this.MenuItem_EditSpace,
            this.MenuItem_EditBackspace,
            this.MenuItem_EditDelete,
            this.MenuItem_EditInsert,
            this.MenuItem_EditSep2,
            this.MenuItem_EditHome,
            this.MenuItem_EditEnd,
            this.MenuItem_EditPageUp,
            this.MenuItem_EditPageDown});
            this.MenuItem_InsertEdit.Text = "Edit Keys";
            // 
            // MenuItem_EditEnter
            // 
            this.MenuItem_EditEnter.Index = 0;
            this.MenuItem_EditEnter.Text = "Enter";
            this.MenuItem_EditEnter.Click += new System.EventHandler(this.MenuItem_EditEnter_Click);
            // 
            // MenuItem_EditEscape
            // 
            this.MenuItem_EditEscape.Index = 1;
            this.MenuItem_EditEscape.Text = "Escape";
            this.MenuItem_EditEscape.Click += new System.EventHandler(this.MenuItem_EditEscape_Click);
            // 
            // MenuItem_EditTab
            // 
            this.MenuItem_EditTab.Index = 2;
            this.MenuItem_EditTab.Text = "Tab";
            this.MenuItem_EditTab.Click += new System.EventHandler(this.MenuItem_EditTab_Click);
            // 
            // MenuItem_EditSep1
            // 
            this.MenuItem_EditSep1.Index = 3;
            this.MenuItem_EditSep1.Text = "-";
            // 
            // MenuItem_EditSpace
            // 
            this.MenuItem_EditSpace.Index = 4;
            this.MenuItem_EditSpace.Text = "Space";
            this.MenuItem_EditSpace.Click += new System.EventHandler(this.MenuItem_EditSpace_Click);
            // 
            // MenuItem_EditBackspace
            // 
            this.MenuItem_EditBackspace.Index = 5;
            this.MenuItem_EditBackspace.Text = "Backspace";
            this.MenuItem_EditBackspace.Click += new System.EventHandler(this.MenuItem_EditBackspace_Click);
            // 
            // MenuItem_EditDelete
            // 
            this.MenuItem_EditDelete.Index = 6;
            this.MenuItem_EditDelete.Text = "Delete";
            this.MenuItem_EditDelete.Click += new System.EventHandler(this.MenuItem_EditDelete_Click);
            // 
            // MenuItem_EditInsert
            // 
            this.MenuItem_EditInsert.Index = 7;
            this.MenuItem_EditInsert.Text = "Insert";
            this.MenuItem_EditInsert.Click += new System.EventHandler(this.MenuItem_EditInsert_Click);
            // 
            // MenuItem_EditSep2
            // 
            this.MenuItem_EditSep2.Index = 8;
            this.MenuItem_EditSep2.Text = "-";
            // 
            // MenuItem_EditHome
            // 
            this.MenuItem_EditHome.Index = 9;
            this.MenuItem_EditHome.Text = "Home";
            this.MenuItem_EditHome.Click += new System.EventHandler(this.MenuItem_EditHome_Click);
            // 
            // MenuItem_EditEnd
            // 
            this.MenuItem_EditEnd.Index = 10;
            this.MenuItem_EditEnd.Text = "End";
            this.MenuItem_EditEnd.Click += new System.EventHandler(this.MenuItem_EditEnd_Click);
            // 
            // MenuItem_EditPageUp
            // 
            this.MenuItem_EditPageUp.Index = 11;
            this.MenuItem_EditPageUp.Text = "Page Up";
            this.MenuItem_EditPageUp.Click += new System.EventHandler(this.MenuItem_EditPageUp_Click);
            // 
            // MenuItem_EditPageDown
            // 
            this.MenuItem_EditPageDown.Index = 12;
            this.MenuItem_EditPageDown.Text = "Page Down";
            this.MenuItem_EditPageDown.Click += new System.EventHandler(this.MenuItem_EditPageDown_Click);
            // 
            // MenuItem_InsertLock
            // 
            this.MenuItem_InsertLock.Index = 8;
            this.MenuItem_InsertLock.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem_LockCapsOn,
            this.MenuItem_LockCapsOff,
            this.MenuItem_LockCapsToggle,
            this.MenuItem_LockSep1,
            this.MenuItem_LockNumOn,
            this.MenuItem_LockNumOff,
            this.MenuItem_LockNumToggle,
            this.MenuItem_LockSep2,
            this.MenuItem_LockScrollOn,
            this.MenuItem_LockScrollOff,
            this.MenuItem_LockScrollToggle});
            this.MenuItem_InsertLock.Text = "Lock Keys";
            // 
            // MenuItem_LockCapsOn
            // 
            this.MenuItem_LockCapsOn.Index = 0;
            this.MenuItem_LockCapsOn.Text = "Caps Lock On";
            this.MenuItem_LockCapsOn.Click += new System.EventHandler(this.MenuItem_LockCapsOn_Click);
            // 
            // MenuItem_LockCapsOff
            // 
            this.MenuItem_LockCapsOff.Index = 1;
            this.MenuItem_LockCapsOff.Text = "Caps Lock Off";
            this.MenuItem_LockCapsOff.Click += new System.EventHandler(this.MenuItem_LockCapsOff_Click);
            // 
            // MenuItem_LockCapsToggle
            // 
            this.MenuItem_LockCapsToggle.Index = 2;
            this.MenuItem_LockCapsToggle.Text = "Caps Lock Toggle";
            this.MenuItem_LockCapsToggle.Click += new System.EventHandler(this.MenuItem_LockCapsToggle_Click);
            // 
            // MenuItem_LockSep1
            // 
            this.MenuItem_LockSep1.Index = 3;
            this.MenuItem_LockSep1.Text = "-";
            // 
            // MenuItem_LockNumOn
            // 
            this.MenuItem_LockNumOn.Index = 4;
            this.MenuItem_LockNumOn.Text = "Num Lock On";
            this.MenuItem_LockNumOn.Click += new System.EventHandler(this.MenuItem_LockNumOn_Click);
            // 
            // MenuItem_LockNumOff
            // 
            this.MenuItem_LockNumOff.Index = 5;
            this.MenuItem_LockNumOff.Text = "Num Lock Off";
            this.MenuItem_LockNumOff.Click += new System.EventHandler(this.MenuItem_LockNumOff_Click);
            // 
            // MenuItem_LockNumToggle
            // 
            this.MenuItem_LockNumToggle.Index = 6;
            this.MenuItem_LockNumToggle.Text = "Num Lock Toggle";
            this.MenuItem_LockNumToggle.Click += new System.EventHandler(this.MenuItem_LockNumToggle_Click);
            // 
            // MenuItem_LockSep2
            // 
            this.MenuItem_LockSep2.Index = 7;
            this.MenuItem_LockSep2.Text = "-";
            // 
            // MenuItem_LockScrollOn
            // 
            this.MenuItem_LockScrollOn.Index = 8;
            this.MenuItem_LockScrollOn.Text = "Scroll Lock On";
            this.MenuItem_LockScrollOn.Click += new System.EventHandler(this.MenuItem_LockScrollOn_Click);
            // 
            // MenuItem_LockScrollOff
            // 
            this.MenuItem_LockScrollOff.Index = 9;
            this.MenuItem_LockScrollOff.Text = "Scroll Lock Off";
            this.MenuItem_LockScrollOff.Click += new System.EventHandler(this.MenuItem_LockScrollOff_Click);
            // 
            // MenuItem_LockScrollToggle
            // 
            this.MenuItem_LockScrollToggle.Index = 10;
            this.MenuItem_LockScrollToggle.Text = "Scroll Lock Toggle";
            this.MenuItem_LockScrollToggle.Click += new System.EventHandler(this.MenuItem_LockScrollToggle_Click);
            // 
            // MenuItem_InsertMod
            // 
            this.MenuItem_InsertMod.Index = 9;
            this.MenuItem_InsertMod.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem_ModAltDown,
            this.MenuItem_ModCtrlDown,
            this.MenuItem_ModShiftDown,
            this.MenuItem_ModSep1,
            this.MenuItem_ModAltUp,
            this.MenuItem_ModCtrlUp,
            this.MenuItem_ModShiftUp,
            this.MenuItem_ModSep2,
            this.MenuItem_ModCASDown});
            this.MenuItem_InsertMod.Text = "Modifer Keys";
            // 
            // MenuItem_ModAltDown
            // 
            this.MenuItem_ModAltDown.Index = 0;
            this.MenuItem_ModAltDown.Text = "Alt Down";
            this.MenuItem_ModAltDown.Click += new System.EventHandler(this.MenuItem_ModAltDown_Click);
            // 
            // MenuItem_ModCtrlDown
            // 
            this.MenuItem_ModCtrlDown.Index = 1;
            this.MenuItem_ModCtrlDown.Text = "Ctrl Down";
            this.MenuItem_ModCtrlDown.Click += new System.EventHandler(this.MenuItem_ModCtrlDown_Click);
            // 
            // MenuItem_ModShiftDown
            // 
            this.MenuItem_ModShiftDown.Index = 2;
            this.MenuItem_ModShiftDown.Text = "Shift Down";
            this.MenuItem_ModShiftDown.Click += new System.EventHandler(this.MenuItem_ModShiftDown_Click);
            // 
            // MenuItem_ModSep1
            // 
            this.MenuItem_ModSep1.Index = 3;
            this.MenuItem_ModSep1.Text = "-";
            // 
            // MenuItem_ModAltUp
            // 
            this.MenuItem_ModAltUp.Index = 4;
            this.MenuItem_ModAltUp.Text = "Alt Up";
            this.MenuItem_ModAltUp.Click += new System.EventHandler(this.MenuItem_ModAltUp_Click);
            // 
            // MenuItem_ModCtrlUp
            // 
            this.MenuItem_ModCtrlUp.Index = 5;
            this.MenuItem_ModCtrlUp.Text = "Ctrl Up";
            this.MenuItem_ModCtrlUp.Click += new System.EventHandler(this.MenuItem_ModCtrlUp_Click);
            // 
            // MenuItem_ModShiftUp
            // 
            this.MenuItem_ModShiftUp.Index = 6;
            this.MenuItem_ModShiftUp.Text = "Shift Up";
            this.MenuItem_ModShiftUp.Click += new System.EventHandler(this.MenuItem_ModShiftUp_Click);
            // 
            // MenuItem_ModSep2
            // 
            this.MenuItem_ModSep2.Index = 7;
            this.MenuItem_ModSep2.Text = "-";
            // 
            // MenuItem_ModCASDown
            // 
            this.MenuItem_ModCASDown.Index = 8;
            this.MenuItem_ModCASDown.Text = "Ctrl+Alt+Shift Down";
            this.MenuItem_ModCASDown.Click += new System.EventHandler(this.MenuItem_ModCASDown_Click);
            // 
            // MenuItem_InsertSpecial
            // 
            this.MenuItem_InsertSpecial.Index = 10;
            this.MenuItem_InsertSpecial.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem_SpecialApp,
            this.MenuItem_SpecialBraceClose,
            this.MenuItem_SpecialBraceOpen,
            this.MenuItem_SpecialClear,
            this.MenuItem_SpecialFunction,
            this.MenuItem_SpecialPause,
            this.MenuItem_SpecialPrint,
            this.MenuItem_SpecialWinLeft,
            this.MenuItem_SpecialWinRight});
            this.MenuItem_InsertSpecial.Text = "Special Keys";
            // 
            // MenuItem_SpecialApp
            // 
            this.MenuItem_SpecialApp.Index = 0;
            this.MenuItem_SpecialApp.Text = "Application";
            this.MenuItem_SpecialApp.Click += new System.EventHandler(this.MenuItem_SpecialApp_Click);
            // 
            // MenuItem_SpecialBraceClose
            // 
            this.MenuItem_SpecialBraceClose.Index = 1;
            this.MenuItem_SpecialBraceClose.Text = "Brace (Close)";
            this.MenuItem_SpecialBraceClose.Click += new System.EventHandler(this.MenuItem_SpecialBraceClose_Click);
            // 
            // MenuItem_SpecialBraceOpen
            // 
            this.MenuItem_SpecialBraceOpen.Index = 2;
            this.MenuItem_SpecialBraceOpen.Text = "Brace (Open)";
            this.MenuItem_SpecialBraceOpen.Click += new System.EventHandler(this.MenuItem_SpecialBraceOpen_Click);
            // 
            // MenuItem_SpecialClear
            // 
            this.MenuItem_SpecialClear.Index = 3;
            this.MenuItem_SpecialClear.Text = "Clear";
            this.MenuItem_SpecialClear.Click += new System.EventHandler(this.MenuItem_SpecialClear_Click);
            // 
            // MenuItem_SpecialFunction
            // 
            this.MenuItem_SpecialFunction.Index = 4;
            this.MenuItem_SpecialFunction.Text = "Function Key";
            this.MenuItem_SpecialFunction.Click += new System.EventHandler(this.MenuItem_SpecialFunction_Click);
            // 
            // MenuItem_SpecialPause
            // 
            this.MenuItem_SpecialPause.Index = 5;
            this.MenuItem_SpecialPause.Text = "Pause Key";
            this.MenuItem_SpecialPause.Click += new System.EventHandler(this.MenuItem_SpecialPause_Click);
            // 
            // MenuItem_SpecialPrint
            // 
            this.MenuItem_SpecialPrint.Index = 6;
            this.MenuItem_SpecialPrint.Text = "Print Screen";
            this.MenuItem_SpecialPrint.Click += new System.EventHandler(this.MenuItem_SpecialPrint_Click);
            // 
            // MenuItem_SpecialWinLeft
            // 
            this.MenuItem_SpecialWinLeft.Index = 7;
            this.MenuItem_SpecialWinLeft.Text = "Windows (Left)";
            this.MenuItem_SpecialWinLeft.Click += new System.EventHandler(this.MenuItem_SpecialWinLeft_Click);
            // 
            // MenuItem_SpecialWinRight
            // 
            this.MenuItem_SpecialWinRight.Index = 8;
            this.MenuItem_SpecialWinRight.Text = "Windows (Right)";
            this.MenuItem_SpecialWinRight.Click += new System.EventHandler(this.MenuItem_SpecialWinRight_Click);
            // 
            // MenuItem_InsertSep4
            // 
            this.MenuItem_InsertSep4.Index = 11;
            this.MenuItem_InsertSep4.Text = "-";
            // 
            // MenuItem_InsertMouse
            // 
            this.MenuItem_InsertMouse.Index = 12;
            this.MenuItem_InsertMouse.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem_MouseLeft,
            this.MenuItem_MouseMiddle,
            this.MenuItem_MouseRight,
            this.MenuItem_MouseSep1,
            this.MenuItem_MouseLeft2,
            this.MenuItem_MouseMiddle2,
            this.MenuItem_MouseRight2,
            this.MenuItem_MouseSep2,
            this.MenuItem_MouseMoveWin,
            this.MenuItem_MouseMoveScreen,
            this.MenuItem_MouseMove,
            this.MenuItem_MouseSep3,
            this.MenuItem_MouseScrollUp,
            this.MenuItem_MouseScrollDown});
            this.MenuItem_InsertMouse.Text = "Mouse Events";
            // 
            // MenuItem_MouseLeft
            // 
            this.MenuItem_MouseLeft.Index = 0;
            this.MenuItem_MouseLeft.Text = "Left Click";
            this.MenuItem_MouseLeft.Click += new System.EventHandler(this.MenuItem_MouseLeft_Click);
            // 
            // MenuItem_MouseMiddle
            // 
            this.MenuItem_MouseMiddle.Index = 1;
            this.MenuItem_MouseMiddle.Text = "Middle Click";
            this.MenuItem_MouseMiddle.Click += new System.EventHandler(this.MenuItem_MouseMiddle_Click);
            // 
            // MenuItem_MouseRight
            // 
            this.MenuItem_MouseRight.Index = 2;
            this.MenuItem_MouseRight.Text = "Right Click";
            this.MenuItem_MouseRight.Click += new System.EventHandler(this.MenuItem_MouseRight_Click);
            // 
            // MenuItem_MouseSep1
            // 
            this.MenuItem_MouseSep1.Index = 3;
            this.MenuItem_MouseSep1.Text = "-";
            // 
            // MenuItem_MouseLeft2
            // 
            this.MenuItem_MouseLeft2.Index = 4;
            this.MenuItem_MouseLeft2.Text = "Left Double Click";
            this.MenuItem_MouseLeft2.Click += new System.EventHandler(this.MenuItem_MouseLeft2_Click);
            // 
            // MenuItem_MouseMiddle2
            // 
            this.MenuItem_MouseMiddle2.Index = 5;
            this.MenuItem_MouseMiddle2.Text = "Middle Double Click";
            this.MenuItem_MouseMiddle2.Click += new System.EventHandler(this.MenuItem_MouseMiddle2_Click);
            // 
            // MenuItem_MouseRight2
            // 
            this.MenuItem_MouseRight2.Index = 6;
            this.MenuItem_MouseRight2.Text = "Right Double Click";
            this.MenuItem_MouseRight2.Click += new System.EventHandler(this.MenuItem_MouseRight2_Click);
            // 
            // MenuItem_MouseSep2
            // 
            this.MenuItem_MouseSep2.Index = 7;
            this.MenuItem_MouseSep2.Text = "-";
            // 
            // MenuItem_MouseMoveWin
            // 
            this.MenuItem_MouseMoveWin.Index = 8;
            this.MenuItem_MouseMoveWin.Text = "Move To Window Position";
            this.MenuItem_MouseMoveWin.Click += new System.EventHandler(this.MenuItem_MouseMoveWin_Click);
            // 
            // MenuItem_MouseMoveScreen
            // 
            this.MenuItem_MouseMoveScreen.Index = 9;
            this.MenuItem_MouseMoveScreen.Text = "Move To Screen Position";
            this.MenuItem_MouseMoveScreen.Click += new System.EventHandler(this.MenuItem_MouseMoveScreen_Click);
            // 
            // MenuItem_MouseMove
            // 
            this.MenuItem_MouseMove.Index = 10;
            this.MenuItem_MouseMove.Text = "Move Relative";
            this.MenuItem_MouseMove.Click += new System.EventHandler(this.MenuItem_MouseMove_Click);
            // 
            // MenuItem_MouseSep3
            // 
            this.MenuItem_MouseSep3.Index = 11;
            this.MenuItem_MouseSep3.Text = "-";
            // 
            // MenuItem_MouseScrollUp
            // 
            this.MenuItem_MouseScrollUp.Index = 12;
            this.MenuItem_MouseScrollUp.Text = "Wheel Up";
            this.MenuItem_MouseScrollUp.Click += new System.EventHandler(this.MenuItem_MouseWheelUp_Click);
            // 
            // MenuItem_MouseScrollDown
            // 
            this.MenuItem_MouseScrollDown.Index = 13;
            this.MenuItem_MouseScrollDown.Text = "Wheel Down 5 Times";
            this.MenuItem_MouseScrollDown.Click += new System.EventHandler(this.MenuItem_MouseWheelDown_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 13;
            this.menuItem1.Text = "-";
            // 
            // MenuItem_Variable
            // 
            this.MenuItem_Variable.Index = 14;
            this.MenuItem_Variable.Text = "Variable";
            this.MenuItem_Variable.Click += new System.EventHandler(this.MenuItem_Variable_Click);
            // 
            // MenuItem_SpecialValue
            // 
            this.MenuItem_SpecialValue.Index = 15;
            this.MenuItem_SpecialValue.Text = "Special Value";
            this.MenuItem_SpecialValue.Click += new System.EventHandler(this.MenuItem_SpecialValue_Click);
            // 
            // MenuItem_KeyStroke
            // 
            this.MenuItem_KeyStroke.Index = 16;
            this.MenuItem_KeyStroke.Text = "KeyStroke";
            this.MenuItem_KeyStroke.Click += new System.EventHandler(this.MenuItem_KeyStroke_Click);
            // 
            // ContextMenu_Edit
            // 
            this.ContextMenu_Edit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem_EditingUndo,
            this.MenuItem_EditingClear,
            this.MenuItem_Editing_Sep1,
            this.MenuItem_EditingCut,
            this.MenuItem_EditingCopy,
            this.MenuItem_EditingPaste,
            this.MenuItem_EditingSep2,
            this.MenuItem_EditingCopyAll,
            this.MenuItem_EditingPasteAll});
            // 
            // MenuItem_EditingUndo
            // 
            this.MenuItem_EditingUndo.Index = 0;
            this.MenuItem_EditingUndo.Text = "Undo";
            this.MenuItem_EditingUndo.Click += new System.EventHandler(this.MenuItem_EditingUndo_Click);
            // 
            // MenuItem_EditingClear
            // 
            this.MenuItem_EditingClear.Index = 1;
            this.MenuItem_EditingClear.Text = "Clear";
            this.MenuItem_EditingClear.Click += new System.EventHandler(this.MenuItem_EditingClear_Click);
            // 
            // MenuItem_Editing_Sep1
            // 
            this.MenuItem_Editing_Sep1.Index = 2;
            this.MenuItem_Editing_Sep1.Text = "-";
            // 
            // MenuItem_EditingCut
            // 
            this.MenuItem_EditingCut.Index = 3;
            this.MenuItem_EditingCut.Text = "Cut";
            this.MenuItem_EditingCut.Click += new System.EventHandler(this.MenuItem_EditingCut_Click);
            // 
            // MenuItem_EditingCopy
            // 
            this.MenuItem_EditingCopy.Index = 4;
            this.MenuItem_EditingCopy.Text = "Copy";
            this.MenuItem_EditingCopy.Click += new System.EventHandler(this.MenuItem_EditingCopy_Click);
            // 
            // MenuItem_EditingPaste
            // 
            this.MenuItem_EditingPaste.Index = 5;
            this.MenuItem_EditingPaste.Text = "Paste";
            this.MenuItem_EditingPaste.Click += new System.EventHandler(this.MenuItem_EditingPaste_Click);
            // 
            // MenuItem_EditingSep2
            // 
            this.MenuItem_EditingSep2.Index = 6;
            this.MenuItem_EditingSep2.Text = "-";
            // 
            // MenuItem_EditingCopyAll
            // 
            this.MenuItem_EditingCopyAll.Index = 7;
            this.MenuItem_EditingCopyAll.Text = "Copy All";
            this.MenuItem_EditingCopyAll.Click += new System.EventHandler(this.MenuItem_EditingCopyAll_Click);
            // 
            // MenuItem_EditingPasteAll
            // 
            this.MenuItem_EditingPasteAll.Index = 8;
            this.MenuItem_EditingPasteAll.Text = "Paste All";
            this.MenuItem_EditingPasteAll.Click += new System.EventHandler(this.MenuItem_EditingPasteAll_Click);
            // 
            // VariableList
            // 
            this.VariableList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.VariableList.FullRowSelect = true;
            this.VariableList.GridLines = true;
            this.VariableList.Location = new System.Drawing.Point(424, 72);
            this.VariableList.MultiSelect = false;
            this.VariableList.Name = "VariableList";
            this.VariableList.ShowGroups = false;
            this.VariableList.ShowItemToolTips = true;
            this.VariableList.Size = new System.Drawing.Size(138, 251);
            this.VariableList.TabIndex = 7;
            this.VariableList.UseCompatibleStateImageBehavior = false;
            this.VariableList.View = System.Windows.Forms.View.Details;
            this.VariableList.SelectedIndexChanged += new System.EventHandler(this.VariableList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Current Variables";
            this.columnHeader1.Width = 134;
            // 
            // ReplaceText
            // 
            this.ReplaceText.Enabled = false;
            this.ReplaceText.Location = new System.Drawing.Point(24, 72);
            this.ReplaceText.Multiline = true;
            this.ReplaceText.Name = "ReplaceText";
            this.ReplaceText.Size = new System.Drawing.Size(384, 251);
            this.ReplaceText.TabIndex = 1;
            // 
            // AddDialog
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(576, 398);
            this.Controls.Add(this.VariableList);
            this.Controls.Add(this.Button_Insert);
            this.Controls.Add(this.ShortcutKeyButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ReplaceText);
            this.Controls.Add(this.WordText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.SpecialValueButton);
            this.Controls.Add(this.KeyStrokeButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddDialog";
            this.ShowInTaskbar = false;
            this.Text = "AddDialog";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        #region MENUS
        #region COMMAND
        private void MenuItem_CommandBeep_Click(object sender, System.EventArgs e)
        {
            this.InsertBeep(1);
        }
        private void MenuItem_CommandBeep2_Click(object sender, System.EventArgs e)
        {
            this.InsertBeep(2);
        }
        
        private void MenuItem_CommandRun_Click(object sender, System.EventArgs e)
        {
            this.InsertRun("notepad.exe");
        }
        private void MenuItem_CommandSound_Click(object sender, System.EventArgs e)
        {
            this.InsertSound("applause.wav");
        }
        
        #endregion COMMAND
        #region CURSOR
        private void MenuItem_CursorCtrlShiftRight_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.Control | Keys.Shift | Keys.Right);
        }
        private void MenuItem_CursorDown_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.Down);
        }
        private void MenuItem_CursorLeft_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.Left);
        }
        private void MenuItem_CursorLeft5_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.Left, 5);
        }
        private void MenuItem_CursorRight_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.Right);
        }
        private void MenuItem_CursorUp_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.Up);
        }
        #endregion CURSOR
        #region EDIT
        private void MenuItem_EditBackspace_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.Back);
        }
        private void MenuItem_EditDelete_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.Delete);
        }
        private void MenuItem_EditEnd_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.End);
        }
        private void MenuItem_EditEnter_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.Enter);
        }
        private void MenuItem_EditEscape_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.Escape);
        }
        private void MenuItem_EditHome_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.Home);
        }
        private void MenuItem_EditInsert_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.Insert);
        }
        private void MenuItem_EditPageDown_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.PageDown);
        }
        private void MenuItem_EditPageUp_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.PageUp);
        }
        private void MenuItem_EditSpace_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.Space);
        }
        private void MenuItem_EditTab_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.Tab);
        }
        #endregion EDIT

        #region EDITING
        private void MenuItem_EditingClear_Click(object sender, System.EventArgs e)
        {
            this.InsertClear();
            this.InsertFocus();
        }
        private void MenuItem_EditingCopy_Click(object sender, System.EventArgs e)
        {
            this.ReplaceText.Copy();
            this.InsertFocus();
        }
        private void MenuItem_EditingCopyAll_Click(object sender, System.EventArgs e)
        {
            this.ReplaceText.SelectAll();
            this.ReplaceText.Copy();
            this.InsertFocus();
        }
        private void MenuItem_EditingCut_Click(object sender, System.EventArgs e)
        {
            this.ReplaceText.Cut();
            this.InsertFocus();
        }
        private void MenuItem_EditingPaste_Click(object sender, System.EventArgs e)
        {
            this.ReplaceText.Paste();
            this.InsertFocus();
        }
        private void MenuItem_EditingPasteAll_Click(object sender, System.EventArgs e)
        {
            this.ReplaceText.SelectAll();
            this.ReplaceText.Paste();
            this.InsertFocusEnd();
        }
        private void MenuItem_EditingUndo_Click(object sender, System.EventArgs e)
        {
            this.SendUndo();
            this.InsertFocusEnd();
        }
        #endregion EDITING
        #region UNDO
        #region TEXT
        private string m_SendUndoText;
        #endregion TEXT

        #region SAVE
        private void SendUndoSave()
        {
            //			Console.WriteLine( "SendUndoSave text={0} textBox={1}",
            //				this.m_SendUndoText, this.TextBox_Send.Text );
            this.m_SendUndoText = this.ReplaceText.Text;
        }
        #endregion SAVE

        #region UNDO
        /// <summary>
        /// Undoes any change to the macro to be sent.
        /// </summary>
        private void SendUndo()
        {
            // if the text was modified by the user
            if (MtInputUtils.StringsAreEqual(
                this.m_SendUndoText, this.ReplaceText.Text))
            {
                // let the TextBox handle the undo
                this.ReplaceText.Undo();
            }
            else
            {
                // otherwise we need to handle the Undo;
                // this is because the TextBox doesn't consider changes to the
                // Text property as events that need to be saved in undo
                string text = this.ReplaceText.Text;
                this.ReplaceText.Text = this.m_SendUndoText;
                this.m_SendUndoText = text;
            }
        }
        #endregion UNDO
        #endregion UNDO
        #region INSERT
        
        private void MenuItem_InsertText_Click(object sender, System.EventArgs e)
        {
            this.InsertText("enter any text");
        }
        #endregion INSERT
        #region PAUSE
        private void MenuItem_PausePointOne_Click(object sender, System.EventArgs e)
        {
            this.InsertPause(100);
        }
        private void MenuItem_PausePointFive_Click(object sender, System.EventArgs e)
        {
            this.InsertPause(500);
        }
        private void MenuItem_PauseOne_Click(object sender, System.EventArgs e)
        {
            this.InsertPause(1000);
        }
        private void MenuItem_PauseTwo_Click(object sender, System.EventArgs e)
        {
            this.InsertPause(2000);
        }
        private void MenuItem_PauseFive_Click(object sender, System.EventArgs e)
        {
            this.InsertPause(5000);
        }
        private void MenuItem_PauseMin_Click(object sender, System.EventArgs e)
        {
            this.InsertPause(60000);
        }
        #endregion PAUSE
        #region LOCK
        private void MenuItem_LockCapsOn_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.CapsLock, MtKeyCmdTypes.On);
        }
        private void MenuItem_LockCapsOff_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.CapsLock, MtKeyCmdTypes.Off);
        }
        private void MenuItem_LockCapsToggle_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.CapsLock);
        }
        private void MenuItem_LockNumOn_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.NumLock, MtKeyCmdTypes.On);
        }
        private void MenuItem_LockNumOff_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.NumLock, MtKeyCmdTypes.Off);
        }
        private void MenuItem_LockNumToggle_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.NumLock);
        }
        private void MenuItem_LockScrollOn_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.Scroll, MtKeyCmdTypes.On);
        }
        private void MenuItem_LockScrollOff_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.Scroll, MtKeyCmdTypes.Off);
        }
        private void MenuItem_LockScrollToggle_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.Scroll);
        }
        #endregion LOCK

        #region MODIFIER
        private void MenuItem_ModAltDown_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.Menu, MtKeyCmdTypes.Down);
        }
        private void MenuItem_ModAltUp_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.Menu, MtKeyCmdTypes.Up);
        }
        private void MenuItem_ModCASDown_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.Control | Keys.Alt | Keys.Shift, MtKeyCmdTypes.Down);
        }
        private void MenuItem_ModCtrlDown_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.ControlKey, MtKeyCmdTypes.Down);
        }
        private void MenuItem_ModCtrlUp_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.ControlKey, MtKeyCmdTypes.Up);
        }
        private void MenuItem_ModShiftDown_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.ShiftKey, MtKeyCmdTypes.Down);
        }
        private void MenuItem_ModShiftUp_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.ShiftKey, MtKeyCmdTypes.Up);
        }
        #endregion MODIFIER

        #region MOUSE
        private void MenuItem_MouseLeft_Click(object sender, System.EventArgs e)
        {
            this.InsertMouse(MouseButtons.Left, 1);
        }
        private void MenuItem_MouseMiddle_Click(object sender, System.EventArgs e)
        {
            this.InsertMouse(MouseButtons.Middle, 1);
        }
        private void MenuItem_MouseRight_Click(object sender, System.EventArgs e)
        {
            this.InsertMouse(MouseButtons.Right, 1);
        }
        private void MenuItem_MouseLeft2_Click(object sender, System.EventArgs e)
        {
            this.InsertMouse(MouseButtons.Left, 2);
        }
        private void MenuItem_MouseMiddle2_Click(object sender, System.EventArgs e)
        {
            this.InsertMouse(MouseButtons.Middle, 2);
        }
        private void MenuItem_MouseRight2_Click(object sender, System.EventArgs e)
        {
            this.InsertMouse(MouseButtons.Right, 2);
        }
        private void MenuItem_MouseMove_Click(object sender, System.EventArgs e)
        {
            this.InsertMouse(MtMouseCmdTypes.MoveRelative, 0, 0);
        }
        private void MenuItem_MouseMoveWin_Click(object sender, System.EventArgs e)
        {
            this.InsertMouse(MtMouseCmdTypes.MoveWindow, 0, 0);
        }
        private void MenuItem_MouseMoveScreen_Click(object sender, System.EventArgs e)
        {
            this.InsertMouse(MtMouseCmdTypes.MoveScreen, 0, 0);
        }
        private void MenuItem_MouseWheelUp_Click(object sender, System.EventArgs e)
        {
            this.InsertMouseWheel(true, 1);
        }
        private void MenuItem_MouseWheelDown_Click(object sender, System.EventArgs e)
        {
            this.InsertMouseWheel(false, 5);
        }
        #endregion MOUSE

        #region SPECIAL
        private void MenuItem_SpecialApp_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.Apps);
        }
        private void MenuItem_SpecialBraceClose_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.OemCloseBrackets | Keys.Shift);
        }
        private void MenuItem_SpecialBraceOpen_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.OemOpenBrackets | Keys.Shift);
        }
        private void MenuItem_SpecialClear_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.Clear);
        }
        private void MenuItem_SpecialFunction_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.F1);
        }
        private void MenuItem_SpecialPause_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.Pause);
        }
        private void MenuItem_SpecialPrint_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.PrintScreen);
        }
        private void MenuItem_SpecialWinLeft_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.LWin);
        }
        private void MenuItem_SpecialWinRight_Click(object sender, System.EventArgs e)
        {
            this.InsertKey(Keys.RWin);
        }
        #endregion SPECIAL

        #region WINDOW
        private void MenuItem_WinActivate_Click(object sender, System.EventArgs e)
        {
            this.InsertWindow(MtWindowCommands.Activate, "Title");
        }
        private void MenuItem_WinBack_Click(object sender, System.EventArgs e)
        {
            this.InsertWindow(MtWindowCommands.SendToBack, "Title");
        }
        private void MenuItem_WinFront_Click(object sender, System.EventArgs e)
        {
            this.InsertWindow(MtWindowCommands.BringToFront, "Title");
        }
        private void MenuItem_WinClose_Click(object sender, System.EventArgs e)
        {
            this.InsertWindow(MtWindowCommands.Close);
        }
        private void MenuItem_WinMaximize_Click(object sender, System.EventArgs e)
        {
            this.InsertWindow(MtWindowCommands.Maximize);
        }
        private void MenuItem_WinMinimize_Click(object sender, System.EventArgs e)
        {
            this.InsertWindow(MtWindowCommands.Minimize);
        }
        private void MenuItem_WinMove_Click(object sender, System.EventArgs e)
        {
            this.InsertWindow(MtWindowCommands.Move, 0, 0);
        }
        private void MenuItem_WinResize_Click(object sender, System.EventArgs e)
        {
            this.InsertWindow(MtWindowCommands.Resize, 0, 0);
        }
        private void MenuItem_WinRestore_Click(object sender, System.EventArgs e)
        {
            this.InsertWindow(MtWindowCommands.Restore);
        }
        private void MenuItem_WinTitle_Click(object sender, System.EventArgs e)
        {
            this.InsertWindow(MtWindowCommands.Title, "Title");
        }
        #endregion WINDOW
        #endregion MENUS

        #region INSERT
        #region RUN
        private void InsertBeep(int beep)
        {
            this.SendUndoSave();
            MtBeepCmd.InsertCmd(beep,this.ReplaceText);
        }
        #endregion RUN

        #region CLEAR
        private void InsertClear()
        {
            this.SendUndoSave();
            this.ReplaceText.Clear();
        }
        #endregion CLEAR

        #region FOCUS
        /// <summary>
        /// Focuses the Send textbox.
        /// </summary>
        private void InsertFocus()
        {
            this.InsertFocusEnd();
        }
        /// <summary>
        /// Focuses the Send textbox, moving the cursor to the end.
        /// </summary>
        private void InsertFocusEnd()
        {
            TextBox textBox = this.ReplaceText;

            textBox.Focus();
            textBox.SelectionStart = textBox.Text.Length;
        }
        #endregion FOCUS

        #region KEY
        private void InsertKey(Keys key)
        {
            this.SendUndoSave();
            MtKeyCmd.InsertCmd(key, this.ReplaceText);
        }
        private void InsertKey(Keys key, int numPresses)
        {
            this.SendUndoSave();
            MtKeyCmd.InsertCmd(key, numPresses, this.ReplaceText);
        }
        private void InsertKey(Keys key, MtKeyCmdTypes keyCmdType)
        {
            this.SendUndoSave();
            MtKeyCmd.InsertCmd(key, keyCmdType, this.ReplaceText);
        }
        #endregion KEY

        #region MOUSE
        private void InsertMouse(MouseButtons mouseButton, int clicks)
        {
            this.SendUndoSave();
            MtMouseCmd.InsertCmd(mouseButton, clicks, this.ReplaceText);
        }
        private void InsertMouse(MtMouseCmdTypes moveCommand,
            int x, int y)
        {
            this.SendUndoSave();
            MtMouseCmd.InsertCmd(moveCommand, x, y, this.ReplaceText);
        }
        private void InsertMouseWheel(bool wheelUp, int clicks)
        {
            this.SendUndoSave();
            MtMouseCmd.InsertWheelCmd(wheelUp, clicks, this.ReplaceText);
        }
        #endregion MOUSE

        #region PAUSE
        private void InsertPause(int delayMS)
        {
            this.SendUndoSave();
            MtPauseCmd.InsertCmd(delayMS, this.ReplaceText);
        }
        #endregion PAUSE

        #region RUN
        private void InsertRun(string path)
        {
            this.SendUndoSave();
            MtRunCmd.InsertCmd(path, this.ReplaceText);
        }
        #endregion RUN

        #region SOUND
        private void InsertSound(string path)
        {
            this.SendUndoSave();
            MtSoundCmd.InsertCmd(path, this.ReplaceText);
        }
        #endregion SOUND

        #region TEXT
        private void InsertText(string text)
        {
            this.SendUndoSave();
            MtTextCmd.InsertCmd(text, this.ReplaceText);
        }
        private void InsertTextAll(string text)
        {
            this.SendUndoSave();
            this.ReplaceText.Text = text;
        }
        #endregion TEXT

        

        #region WINDOW
        private void InsertWindow(MtWindowCommands windowCommand)
        {
            this.SendUndoSave();
            MtWindowCmd.InsertCmd(windowCommand, this.ReplaceText);
        }
        private void InsertWindow(MtWindowCommands windowCommand,
            int x, int y)
        {
            this.SendUndoSave();
            MtWindowCmd.InsertCmd(windowCommand, x, y, this.ReplaceText);
        }
        private void InsertWindow(MtWindowCommands windowCommand,
            string title)
        {
            this.SendUndoSave();
            MtWindowCmd.InsertCmd(windowCommand, title,
                this.ReplaceText);
        }
        #endregion WINDOW
        #endregion INSERT
        private void button3_Click(object sender, System.EventArgs e)
		{
		
		}
		public void SetReplacementTextBox(string s)
		{
			this.ReplaceText.Text=s;
		}
		private void button7_Click(object sender, System.EventArgs e)
		{
            if (WordText.Text == "")
            { MessageBox.Show("Pease Enter Word First", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (ReplaceText.Text == "")
            { MessageBox.Show("Pease Enter Replacement First", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            dct.word = WordText.Text;
            dct.shortcut = ShortcutKeyButton.Text;
            dct.replacement = ReplaceText.Text;
            if (IsModify)
            {
                Dictionary.UpdateWord(dct);
                DialogResult = DialogResult.OK;
            }
            else
            {
                if ((ID=Dictionary.SaveWord(dct) )> 0)
                
                    DialogResult = DialogResult.OK;
                
            }
			//this.Hide();
		}
        
		private void button8_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}
		public Dictionary GetEntry()
		{
			Dictionary dct=new Dictionary(this.WordText.Text,this.ReplaceText.Text,this.ShortcutKeyButton.Text);
			
			return dct;
		}

        private void button5_Click(object sender, EventArgs e)
        {
            KeyListener kl = new KeyListener(false);
            kl.ShowDialog();
            string Text="{" + kl.ShortCut + "}";
            //this.ReplaceText.Text+=kl.sc.ParsedKeys;
            //this.ReplaceText.Text += "{"+kl.ShortCut+"}";
            int caret=ReplaceText.SelectionStart+Text.Length;
            this.ReplaceText.Text = this.ReplaceText.Text.Insert(ReplaceText.SelectionStart,Text);
            ReplaceText.SelectionStart = caret;
            ReplaceText.Select();
            kl.Dispose();
        }

        private void WordText_TextChanged(object sender, EventArgs e)
        {
            if (WordText.Text != "")
            {
                for (int i = 0; i < Controls.Count; i++)
                    if (Controls[i].Name != "WordText")
                        Controls[i].Enabled = true;
                
            }
            else
            {
                for (int i = 0; i < Controls.Count; i++)
                    if (Controls[i].Name != "WordText")
                        Controls[i].Enabled = false;
            }
        }

        private void ShortcutKeyButton_Click(object sender, EventArgs e)
        {
            KeyListener kl = new KeyListener(false);
            kl.ShowDialog();
            ShortcutKeyButton.Text = "{"+kl.ShortCut+"}";
            dct.shortcut = "{"+kl.ShortCut+"}";
            kl.Dispose();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ShortcutKeyButton.Text = "Assign Shortcut Key";
            dct.shortcut = "";
        }

        private void SpecialValueButton_Click(object sender, EventArgs e)
        {
            SpecialValues spv = new SpecialValues();
            int caret=0;
            if (spv.ShowDialog() == DialogResult.OK)
            {
                caret = ReplaceText.SelectionStart + spv.SpecialValue.Length;
                this.ReplaceText.Text = this.ReplaceText.Text.Insert(this.ReplaceText.SelectionStart, spv.SpecialValue);
            }
            ReplaceText.SelectionStart = caret;
            ReplaceText.Select();
        }

        private void Button_Insert_Click(object sender, EventArgs e)
        {
            this.ContextMenu_Insert.Show(this.Button_Insert,
                new Point(this.Button_Insert.Width, 0));
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            this.ContextMenu_Edit.Show(this.EditButton,
                new Point(this.EditButton.Width, 0));
        }

        private void MenuItem_Variable_Click(object sender, EventArgs e)
        {
            
            InputVariables IV = new InputVariables();
            if (IV.ShowDialog() == DialogResult.OK)
            {
                
                if (!AlreadyExists(IV.VarName))
                {
                    ListViewItem Listitem = new ListViewItem(IV.VarName);
                    Listitem.Tag = IV.Var;
                    Listitem.ToolTipText = IV.Var; 
                    this.VariableList.Items.Add(Listitem);
                    int caret = ReplaceText.SelectionStart+((string)Listitem.Tag).Length;
                    this.ReplaceText.Text = this.ReplaceText.Text.Insert(ReplaceText.SelectionStart,(string)Listitem.Tag);
                    ReplaceText.SelectionStart = caret;
                    ReplaceText.Select();
                }
                else
                    MessageBox.Show("Variable Already Exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            IV.Dispose();
        }

        private void MenuItem_SpecialValue_Click(object sender, EventArgs e)
        {
            SpecialValues spv = new SpecialValues();
            int caret=0;
            if (spv.ShowDialog() == DialogResult.OK)
            {
                caret = ReplaceText.SelectionStart + spv.SpecialValue.Length;
                this.ReplaceText.Text = this.ReplaceText.Text.Insert(ReplaceText.SelectionStart, spv.SpecialValue);
            }
            ReplaceText.SelectionStart = caret;
            ReplaceText.Select();
        }

        private void MenuItem_KeyStroke_Click(object sender, EventArgs e)
        {
            KeyListener kl = new KeyListener(false);
            kl.ShowDialog();
            //this.ReplaceText.Text+=kl.sc.ParsedKeys;
            string Text = "{" + kl.ShortCut + "}";
            int caret = ReplaceText.SelectionStart+Text.Length;
            this.ReplaceText.Text =ReplaceText.Text.Insert(ReplaceText.SelectionStart,Text);
            ReplaceText.SelectionStart = caret;
            ReplaceText.Select();
            kl.Dispose();
        }
        private bool AlreadyExists(string var)
        {
            for (int i = 0; i < this.VariableList.Items.Count; i++)
                if (this.VariableList.Items[i].Text == var)
                    return true;

            return false;
        }

        private void VariableList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
	}
}
