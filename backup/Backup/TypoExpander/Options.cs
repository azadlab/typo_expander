using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace RSH.TypoExpander
{
	/// <summary>
	/// Summary description for Options.
	/// </summary>
	public class Options : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Options()
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.button1,
																					this.checkBox1,
																					this.radioButton1,
																					this.radioButton2,
																					this.checkBox2,
																					this.checkBox3});
			this.groupBox1.Location = new System.Drawing.Point(24, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(368, 160);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Word Expansion Options";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.comboBox1,
																					this.label1,
																					this.radioButton3,
																					this.radioButton4,
																					this.radioButton5});
			this.groupBox2.Location = new System.Drawing.Point(16, 184);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(376, 160);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Dictionary Selection Options";
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(32, 16);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.TabIndex = 0;
			this.radioButton1.Text = "Auto Expand";
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(64, 48);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(168, 24);
			this.checkBox1.TabIndex = 1;
			this.checkBox1.Text = "Show Replacement Window";
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(32, 80);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(120, 24);
			this.radioButton2.TabIndex = 0;
			this.radioButton2.Text = "Expand by Hot key";
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(32, 104);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(200, 24);
			this.checkBox2.TabIndex = 1;
			this.checkBox2.Text = "Auto Insert space After Expanding";
			// 
			// checkBox3
			// 
			this.checkBox3.Location = new System.Drawing.Point(32, 128);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(176, 24);
			this.checkBox3.TabIndex = 1;
			this.checkBox3.Text = "Expand In Same Case...";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(232, 48);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(120, 24);
			this.button1.TabIndex = 2;
			this.button1.Text = "Hot Key";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Default Dictionary:";
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(144, 32);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(200, 21);
			this.comboBox1.TabIndex = 1;
			this.comboBox1.Text = "Sample";
			// 
			// radioButton3
			// 
			this.radioButton3.Location = new System.Drawing.Point(96, 64);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(160, 24);
			this.radioButton3.TabIndex = 0;
			this.radioButton3.Text = "Use Only Active Dictionary";
			// 
			// radioButton4
			// 
			this.radioButton4.Location = new System.Drawing.Point(96, 96);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(152, 24);
			this.radioButton4.TabIndex = 0;
			this.radioButton4.Text = "Use Chained Dictionaries";
			// 
			// radioButton5
			// 
			this.radioButton5.Location = new System.Drawing.Point(96, 128);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(136, 24);
			this.radioButton5.TabIndex = 0;
			this.radioButton5.Text = "Use All dictionaries";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(200, 360);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(88, 24);
			this.button2.TabIndex = 1;
			this.button2.Text = "OK";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(296, 360);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(88, 24);
			this.button3.TabIndex = 1;
			this.button3.Text = "Cancel";
			// 
			// Options
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(400, 398);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button2,
																		  this.groupBox1,
																		  this.groupBox2,
																		  this.button3});
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Options";
			this.ShowInTaskbar = false;
			this.Text = "Options";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
