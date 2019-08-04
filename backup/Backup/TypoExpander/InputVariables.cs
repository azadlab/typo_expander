using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace RSH.TypoExpander
{
	/// <summary>
	/// Summary description for InputVariables.
	/// </summary>
	public class InputVariables : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public InputVariables()
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
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Input Title:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(112, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(240, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(112, 56);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(240, 20);
			this.textBox2.TabIndex = 2;
			this.textBox2.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Variable Name:";
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(112, 96);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.TabIndex = 3;
			this.radioButton1.Text = "Text Variable";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.textBox3,
																					this.radioButton3,
																					this.radioButton2,
																					this.radioButton4,
																					this.radioButton5});
			this.groupBox1.Location = new System.Drawing.Point(80, 136);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(272, 104);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(128, 72);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(136, 20);
			this.textBox3.TabIndex = 7;
			this.textBox3.Text = "";
			// 
			// radioButton3
			// 
			this.radioButton3.Location = new System.Drawing.Point(32, 24);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(120, 24);
			this.radioButton3.TabIndex = 6;
			this.radioButton3.Text = "Long Date Format";
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(24, -6);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.TabIndex = 5;
			this.radioButton2.Text = "Date Variable";
			// 
			// radioButton4
			// 
			this.radioButton4.Location = new System.Drawing.Point(32, 48);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(128, 24);
			this.radioButton4.TabIndex = 6;
			this.radioButton4.Text = "Short Date Format";
			// 
			// radioButton5
			// 
			this.radioButton5.Location = new System.Drawing.Point(32, 72);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.TabIndex = 6;
			this.radioButton5.Text = "Custom Format";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(160, 256);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(88, 24);
			this.button1.TabIndex = 6;
			this.button1.Text = "OK";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(256, 256);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(88, 24);
			this.button2.TabIndex = 6;
			this.button2.Text = "Cancel";
			// 
			// InputVariables
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(368, 294);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button1,
																		  this.groupBox1,
																		  this.radioButton1,
																		  this.textBox2,
																		  this.textBox1,
																		  this.label1,
																		  this.label2,
																		  this.button2});
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "InputVariables";
			this.ShowInTaskbar = false;
			this.Text = "InputVariables";
			this.TopMost = true;
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
