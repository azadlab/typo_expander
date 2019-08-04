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
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox3;
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
			this.label1 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
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
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.GhostWhite;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(136, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(200, 48);
			this.label1.TabIndex = 1;
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// checkBox1
			// 
			this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.checkBox1.Location = new System.Drawing.Point(24, 20);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.TabIndex = 2;
			this.checkBox1.Text = "CTRL";
			// 
			// checkBox2
			// 
			this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.checkBox2.Location = new System.Drawing.Point(24, 46);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.TabIndex = 2;
			this.checkBox2.Text = "ALT";
			// 
			// checkBox3
			// 
			this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.checkBox3.Location = new System.Drawing.Point(24, 72);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.TabIndex = 2;
			this.checkBox3.Text = "SHIFT";
			// 
			// ShortCut
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.AliceBlue;
			this.ClientSize = new System.Drawing.Size(368, 158);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.checkBox1,
																		  this.label1,
																		  this.button1,
																		  this.button2,
																		  this.checkBox2,
																		  this.checkBox3});
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ShortCut";
			this.ShowInTaskbar = false;
			this.Text = "ShortCut";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
