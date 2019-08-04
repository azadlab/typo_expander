using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace RSH.TypoExpander
{
	/// <summary>
	/// Summary description for ShortCut.
	/// </summary>
	public class ShortCut : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public Label Key_label;
        public CheckBox Ctrl_checkbox;
        public CheckBox Alt_checkbox;
        public CheckBox Shift_checkbox;
        public string ParsedKeys;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ShortCut()
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Key_label = new System.Windows.Forms.Label();
            this.Ctrl_checkbox = new System.Windows.Forms.CheckBox();
            this.Alt_checkbox = new System.Windows.Forms.CheckBox();
            this.Shift_checkbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(196, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cancel";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(92, 112);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 24);
            this.button2.TabIndex = 0;
            this.button2.Text = "OK";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Key_label
            // 
            this.Key_label.BackColor = System.Drawing.Color.GhostWhite;
            this.Key_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Key_label.Location = new System.Drawing.Point(136, 32);
            this.Key_label.Name = "Key_label";
            this.Key_label.Size = new System.Drawing.Size(200, 48);
            this.Key_label.TabIndex = 1;
            this.Key_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Ctrl_checkbox
            // 
            this.Ctrl_checkbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ctrl_checkbox.Location = new System.Drawing.Point(24, 20);
            this.Ctrl_checkbox.Name = "Ctrl_checkbox";
            this.Ctrl_checkbox.Size = new System.Drawing.Size(104, 24);
            this.Ctrl_checkbox.TabIndex = 2;
            this.Ctrl_checkbox.Text = "CTRL";
            // 
            // Alt_checkbox
            // 
            this.Alt_checkbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Alt_checkbox.Location = new System.Drawing.Point(24, 46);
            this.Alt_checkbox.Name = "Alt_checkbox";
            this.Alt_checkbox.Size = new System.Drawing.Size(104, 24);
            this.Alt_checkbox.TabIndex = 2;
            this.Alt_checkbox.Text = "ALT";
            // 
            // Shift_checkbox
            // 
            this.Shift_checkbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Shift_checkbox.Location = new System.Drawing.Point(24, 72);
            this.Shift_checkbox.Name = "Shift_checkbox";
            this.Shift_checkbox.Size = new System.Drawing.Size(104, 24);
            this.Shift_checkbox.TabIndex = 2;
            this.Shift_checkbox.Text = "SHIFT";
            // 
            // ShortCut
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(368, 158);
            this.Controls.Add(this.Ctrl_checkbox);
            this.Controls.Add(this.Key_label);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Alt_checkbox);
            this.Controls.Add(this.Shift_checkbox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShortCut";
            this.ShowInTaskbar = false;
            this.Text = "ShortCut";
            this.ResumeLayout(false);

		}
		#endregion

        private void button2_Click(object sender, EventArgs e)
        {
            ParseKeys();
        }
        public void ParseKeys()
        {
            ParsedKeys = "{%KS$";
            if (Ctrl_checkbox.Checked)
                this.ParsedKeys += "{Ctrl}";
            if (Shift_checkbox.Checked)
                this.ParsedKeys += "{Shift}";
            if (Alt_checkbox.Checked)
                this.ParsedKeys += "{Alt}";
            ParsedKeys += Key_label.Text + "}";
            this.Hide();
        }
	}
}
