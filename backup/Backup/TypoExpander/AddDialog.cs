using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace RSH.TypoExpander
{
	/// <summary>
	/// Summary description for AddDialog.
	/// </summary>
	public class AddDialog : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		public System.Windows.Forms.ListBox listBox1;
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(24, 19);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(208, 20);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(24, 72);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(384, 256);
			this.textBox2.TabIndex = 1;
			this.textBox2.Text = "";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(24, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Shortcut:";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(24, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Replacement:";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(392, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "Variables:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(248, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(160, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "Assign ShortCut Key";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(424, 16);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(112, 23);
			this.button2.TabIndex = 4;
			this.button2.Text = "Clear Shorcut";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(24, 336);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(88, 23);
			this.button3.TabIndex = 4;
			this.button3.Text = "Input Variable";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(120, 336);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(88, 23);
			this.button4.TabIndex = 4;
			this.button4.Text = "Special Value";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(216, 336);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(88, 23);
			this.button5.TabIndex = 4;
			this.button5.Text = "KeyStroke";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(320, 336);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(88, 23);
			this.button6.TabIndex = 4;
			this.button6.Text = "From .TXT File";
			// 
			// button7
			// 
			this.button7.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button7.Location = new System.Drawing.Point(336, 368);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(112, 23);
			this.button7.TabIndex = 4;
			this.button7.Text = "OK";
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button8
			// 
			this.button8.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button8.Location = new System.Drawing.Point(448, 368);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(112, 23);
			this.button8.TabIndex = 4;
			this.button8.Text = "Cancel";
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// listBox1
			// 
			this.listBox1.Location = new System.Drawing.Point(424, 72);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(144, 238);
			this.listBox1.TabIndex = 5;
			// 
			// AddDialog
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.AliceBlue;
			this.ClientSize = new System.Drawing.Size(576, 398);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.listBox1,
																		  this.button1,
																		  this.label1,
																		  this.textBox2,
																		  this.textBox1,
																		  this.label2,
																		  this.label3,
																		  this.button2,
																		  this.button3,
																		  this.button4,
																		  this.button5,
																		  this.button6,
																		  this.button7,
																		  this.button8});
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddDialog";
			this.ShowInTaskbar = false;
			this.Text = "AddDialog";
			this.ResumeLayout(false);

		}
		#endregion

		private void button3_Click(object sender, System.EventArgs e)
		{
		
		}
		public void SetReplacementTextBox(string s)
		{
			this.textBox2.Text=s;
		}
		private void button7_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}

		private void button8_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}
		public Dictionary GetEntry()
		{
			Dictionary dct=new Dictionary(this.textBox1.Text,this.textBox2.Text,this.button1.Text);
			
			return dct;
		}
	}
}
