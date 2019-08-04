using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

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
        private int[] options=new int[6];
        private string KeyShortcut="Ctrl+H";
        private string SelDictionary="Sample";

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
            this.Load += new EventHandler(Options_Load);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

        void Options_Load(object sender, EventArgs e)
        {
            
            this.radioButton1.Checked = ((int)AppSettings.AppOptions["AutoExpand"]==1)?true:false;
            
            this.radioButton2.Checked = ((int)AppSettings.AppOptions["ExpandByHotKey"]==1) ?true : false;
            
            this.checkBox1.Checked = ((int)AppSettings.AppOptions["ShowReplacementWindow"] == 1) ? true : false;
            this.checkBox2.Checked = ((int)AppSettings.AppOptions["AutoInsertSpace"] == 1) ? true : false;
            this.checkBox3.Checked = ((int)AppSettings.AppOptions["SameCase"] == 1) ? true : false;
            this.radioButton3.Checked = ((int)AppSettings.AppOptions["Active|Chained|All"] == 0) ? true : false;
            this.radioButton4.Checked = ((int)AppSettings.AppOptions["Active|Chained|All"] == 1) ? true : false;
            this.radioButton5.Checked = ((int)AppSettings.AppOptions["Active|Chained|All"] == 2) ? true : false;            
            this.button1.Text = (string)AppSettings.AppOptions["HotKey"];

            
            for (int i = 0; i < Dictionary.ds.Tables["Categories"].Rows.Count; i++)
                this.comboBox1.Items.Add(Dictionary.ds.Tables["Categories"].Rows[i].ItemArray[1].ToString());


            comboBox1.SelectedItem = comboBox1.Items[(int)AppSettings.AppOptions["SelectedDictionary"]];
            

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
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Location = new System.Drawing.Point(12, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Word Expansion Options";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(149, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 24);
            this.button1.TabIndex = 2;
            this.button1.Text = "Hot Key";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(53, 37);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(168, 24);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Show Replacement Window";
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(32, 16);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(104, 24);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "Auto Expand";
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(32, 62);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(120, 24);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.Text = "Expand by Hot key";
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(32, 88);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(200, 24);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Auto Insert space After Expanding";
            // 
            // checkBox3
            // 
            this.checkBox3.Location = new System.Drawing.Point(32, 112);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(176, 24);
            this.checkBox3.TabIndex = 1;
            this.checkBox3.Text = "Expand In Same Case...";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Controls.Add(this.radioButton5);
            this.groupBox2.Location = new System.Drawing.Point(10, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(332, 140);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dictionary Selection Options";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.ItemHeight = 13;
            this.comboBox1.Location = new System.Drawing.Point(119, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Default Dictionary:";
            // 
            // radioButton3
            // 
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(97, 61);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(160, 24);
            this.radioButton3.TabIndex = 0;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Use Only Active Dictionary";
            // 
            // radioButton4
            // 
            this.radioButton4.Location = new System.Drawing.Point(98, 85);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(152, 24);
            this.radioButton4.TabIndex = 0;
            this.radioButton4.Text = "Use Chained Dictionaries";
            // 
            // radioButton5
            // 
            this.radioButton5.Location = new System.Drawing.Point(98, 109);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(136, 24);
            this.radioButton5.TabIndex = 0;
            this.radioButton5.Text = "Use All dictionaries";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(160, 302);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 24);
            this.button2.TabIndex = 1;
            this.button2.Text = "OK";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Location = new System.Drawing.Point(256, 302);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 24);
            this.button3.TabIndex = 1;
            this.button3.Text = "Cancel";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Options
            // 
            this.AcceptButton = this.button2;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.CancelButton = this.button3;
            this.ClientSize = new System.Drawing.Size(352, 333);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button3);
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

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (this.radioButton1.Checked)
                AppSettings.AppOptions["AutoExpand"] = 1;
            else
                AppSettings.AppOptions["AutoExpand"] = 0;
            if(this.radioButton2.Checked) 
                AppSettings.AppOptions["ExpandByHotKey"] = 1;
            else AppSettings.AppOptions["ExpandByHotKey"] = 0;
            if (this.checkBox1.Checked)
                AppSettings.AppOptions["ShowReplacementWindow"] = 1;
            else 
                AppSettings.AppOptions["ShowReplacementWindow"] = 0;
            if (this.checkBox2.Checked)
                AppSettings.AppOptions["AutoInsertSpace"] = 1;
            else 
                AppSettings.AppOptions["AutoInsertSpace"] = 0;
            if (this.checkBox3.Checked)
                AppSettings.AppOptions["SameCase"] = 1;
            else 
                AppSettings.AppOptions["SameCase"] = 0;
            if(this.radioButton3.Checked)
            AppSettings.AppOptions["Active|Chained|All"] = 0 ;
            else if (this.radioButton4.Checked)
                AppSettings.AppOptions["Active|Chained|All"] = 1;
            else if (this.radioButton5.Checked)
                AppSettings.AppOptions["Active|Chained|All"] = 2;
            AppSettings.AppOptions["HotKey"] = this.button1.Text;
            AppSettings.AppOptions["SelectedDictionary"] = this.comboBox1.SelectedIndex;
            
            AppSettings.SaveOptions();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //if(radioButton1.Checked)
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KeyListener kl = new KeyListener(false);
            kl.ShowDialog();
            this.button1.Text = kl.ShortCut;
            kl.Dispose();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }
	}
}
