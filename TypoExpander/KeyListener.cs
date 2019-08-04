using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using MiniTools.UI.Input;

namespace RSH.TypoExpander
{
	/// <summary>
	/// Summary description for KeyListener.
	/// </summary>
	public class KeyListener : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
        private MiniTools.UI.Input.MtKeyboardGlobalHook mtKeyboardGlobalHook;
        public RSH.TypoExpander.ShortCut sc;
        private bool IsKeyEditable;
        public string ShortCut;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public KeyListener()
		{
			
			InitializeComponent();
            IsKeyEditable = true;
			
		}
        public KeyListener(bool IsKeyEdit)
        {
            
            InitializeComponent();
            IsKeyEditable = false;
            
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
                    this.mtKeyboardGlobalHook.Uninstall();
                    if(sc!=null)
                        sc.Dispose();
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mtKeyboardGlobalHook = new MiniTools.UI.Input.MtKeyboardGlobalHook();
            ((System.ComponentModel.ISupportInitialize)(this.mtKeyboardGlobalHook)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Location = new System.Drawing.Point(67, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cancel";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Miriam Transparent", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Waiting For Key or KeyStroke Combination";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mtKeyboardGlobalHook
            // 
            this.mtKeyboardGlobalHook.Control = this;
            this.mtKeyboardGlobalHook.HostingControl = this;
            this.mtKeyboardGlobalHook.Name = "mtKeyboardGlobalHook1";
            this.mtKeyboardGlobalHook.KeyEvent += new MiniTools.UI.Input.MtKeyEventHandler(this.HandleKeyEvent);
            // 
            // KeyListener
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(261, 90);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KeyListener";
            this.ShowInTaskbar = false;
            this.Text = "KeyListener";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.mtKeyboardGlobalHook)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        #region KEYBOARD
        public void HandleKeyEvent(MtHook hook, MtKeyEventArgs e)
        {
            //MessageBox.Show("Key:"+e.KeyText);
            
            if (e.KeyPress)
            {
                if (IsKeyEditable)
                {
                    sc = new ShortCut();
                    if (e.Control)
                        sc.Ctrl_checkbox.Checked = true;
                    if (e.Shift)
                        sc.Shift_checkbox.Checked = true;
                    if (e.Alt)
                        sc.Alt_checkbox.Checked = true;
                    string[] parts = e.KeyText.Split('+');
                    sc.Key_label.Text = parts[parts.Length - 1];
                    this.Hide();
                    sc.ShowDialog();
                    e.Handled = true;
                    
                }
                else
                {
                    ShortCut = e.KeyText;
                    this.Hide();
                }

            }
          
        }
        
        #endregion KEYBOARD

        
    }
    
}
