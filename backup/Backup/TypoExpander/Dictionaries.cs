using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace RSH.TypoExpander
{
	/// <summary>
	/// Summary description for Dictionaries.
	/// </summary>
	public class Dictionaries : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Dictionaries()
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
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(256, 47);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 24);
			this.button1.TabIndex = 0;
			this.button1.Text = "Add";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(256, 79);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 24);
			this.button2.TabIndex = 0;
			this.button2.Text = "Edit";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(256, 111);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 24);
			this.button3.TabIndex = 0;
			this.button3.Text = "Delete";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(256, 143);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 24);
			this.button4.TabIndex = 0;
			this.button4.Text = "Cancel";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(24, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(208, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(24, 56);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(208, 144);
			this.textBox2.TabIndex = 1;
			this.textBox2.Text = "";
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader2,
																						this.columnHeader3});
			this.listView1.GridLines = true;
			this.listView1.Location = new System.Drawing.Point(352, 32);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(144, 152);
			this.listView1.TabIndex = 2;
			// 
			// Dictionaries
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(512, 214);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.listView1,
																		  this.textBox1,
																		  this.button1,
																		  this.button2,
																		  this.button3,
																		  this.button4,
																		  this.textBox2});
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Dictionaries";
			this.ShowInTaskbar = false;
			this.Text = "Dictionaries";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
