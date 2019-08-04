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
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox TextBoxInputTitle;
        public System.Windows.Forms.TextBox TextBoxName;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.RadioButton RadioText;
        public System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.RadioButton RadioDate;
		public System.Windows.Forms.RadioButton RadioLongDate;
		public System.Windows.Forms.RadioButton RadioShortDate;
		public System.Windows.Forms.RadioButton RadioCustomDate;
		public System.Windows.Forms.TextBox TextBoxCustomDate;
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.Button CancelButton;
        
        public string VarName;
        public string Var;
        
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public InputVariables()
		{
			InitializeComponent();

		}
        public InputVariables(string vname,string var)
        {
            InitializeComponent();
            this.VarName = vname;
            this.Var = var;

            SetControls();
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
            this.TextBoxInputTitle = new System.Windows.Forms.TextBox();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RadioText = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TextBoxCustomDate = new System.Windows.Forms.TextBox();
            this.RadioLongDate = new System.Windows.Forms.RadioButton();
            this.RadioShortDate = new System.Windows.Forms.RadioButton();
            this.RadioCustomDate = new System.Windows.Forms.RadioButton();
            this.RadioDate = new System.Windows.Forms.RadioButton();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input Title:";
            // 
            // TextBoxInputTitle
            // 
            this.TextBoxInputTitle.Location = new System.Drawing.Point(95, 18);
            this.TextBoxInputTitle.Name = "TextBoxInputTitle";
            this.TextBoxInputTitle.Size = new System.Drawing.Size(264, 20);
            this.TextBoxInputTitle.TabIndex = 1;
            // 
            // TextBoxName
            // 
            this.TextBoxName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBoxName.Location = new System.Drawing.Point(95, 50);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size(264, 20);
            this.TextBoxName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Variable Name:";
            // 
            // RadioText
            // 
            this.RadioText.Checked = true;
            this.RadioText.Location = new System.Drawing.Point(113, 77);
            this.RadioText.Name = "RadioText";
            this.RadioText.Size = new System.Drawing.Size(104, 21);
            this.RadioText.TabIndex = 3;
            this.RadioText.TabStop = true;
            this.RadioText.Text = "Text Variable";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TextBoxCustomDate);
            this.groupBox1.Controls.Add(this.RadioLongDate);
            this.groupBox1.Controls.Add(this.RadioShortDate);
            this.groupBox1.Controls.Add(this.RadioCustomDate);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(95, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 104);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date Type";
            // 
            // TextBoxCustomDate
            // 
            this.TextBoxCustomDate.Location = new System.Drawing.Point(128, 72);
            this.TextBoxCustomDate.Name = "TextBoxCustomDate";
            this.TextBoxCustomDate.Size = new System.Drawing.Size(130, 20);
            this.TextBoxCustomDate.TabIndex = 7;
            // 
            // RadioLongDate
            // 
            this.RadioLongDate.Checked = true;
            this.RadioLongDate.Location = new System.Drawing.Point(32, 24);
            this.RadioLongDate.Name = "RadioLongDate";
            this.RadioLongDate.Size = new System.Drawing.Size(120, 24);
            this.RadioLongDate.TabIndex = 6;
            this.RadioLongDate.TabStop = true;
            this.RadioLongDate.Text = "Long Date Format";
            // 
            // RadioShortDate
            // 
            this.RadioShortDate.Location = new System.Drawing.Point(32, 48);
            this.RadioShortDate.Name = "RadioShortDate";
            this.RadioShortDate.Size = new System.Drawing.Size(128, 24);
            this.RadioShortDate.TabIndex = 6;
            this.RadioShortDate.Text = "Short Date Format";
            // 
            // RadioCustomDate
            // 
            this.RadioCustomDate.Location = new System.Drawing.Point(32, 72);
            this.RadioCustomDate.Name = "RadioCustomDate";
            this.RadioCustomDate.Size = new System.Drawing.Size(104, 24);
            this.RadioCustomDate.TabIndex = 6;
            this.RadioCustomDate.Text = "Custom Format";
            this.RadioCustomDate.CheckedChanged += new System.EventHandler(this.RadioCustomDate_CheckedChanged);
            // 
            // RadioDate
            // 
            this.RadioDate.Location = new System.Drawing.Point(223, 80);
            this.RadioDate.Name = "RadioDate";
            this.RadioDate.Size = new System.Drawing.Size(104, 18);
            this.RadioDate.TabIndex = 5;
            this.RadioDate.Text = "Date Variable";
            this.RadioDate.CheckedChanged += new System.EventHandler(this.RadioDate_CheckedChanged);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(192, 209);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(84, 24);
            this.OKButton.TabIndex = 6;
            this.OKButton.Text = "OK";
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(280, 209);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(84, 24);
            this.CancelButton.TabIndex = 6;
            this.CancelButton.Text = "Cancel";
            // 
            // InputVariables
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(370, 239);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RadioDate);
            this.Controls.Add(this.RadioText);
            this.Controls.Add(this.TextBoxName);
            this.Controls.Add(this.TextBoxInputTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputVariables";
            this.ShowInTaskbar = false;
            this.Text = "InputVariables";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private void RadioDate_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioDate.Checked)
             groupBox1.Enabled = true; 
            else
            groupBox1.Enabled = false;
            TextBoxCustomDate.Enabled = false;
        }

        private void RadioCustomDate_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioCustomDate.Checked)
                TextBoxCustomDate.Enabled = true;
            else
                TextBoxCustomDate.Enabled = false;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (TextBoxInputTitle.Text == "")
            {MessageBox.Show("Input Title cannot be left blank", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;}
            if (TextBoxName.Text == "")
            { MessageBox.Show("Variable Name cannot be left blank", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            this.VarName = this.TextBoxName.Text;
            if (RadioText.Checked)
              Var = "{%TEXTVAR$" + TextBoxName.Text + "$" + TextBoxInputTitle.Text + "}";
            
            else if (RadioDate.Checked)
            {
                string DateType = "DATELONGVAR";
                if (RadioLongDate.Checked)
                    DateType = "DATELONGVAR";
                else if (RadioShortDate.Checked)
                    DateType = "DATESHORTVAR";
                else if (RadioCustomDate.Checked)
                    DateType = "DATEVAR";
                
                if (RadioCustomDate.Checked)
                    Var = "{%" + DateType + "$" + TextBoxCustomDate.Text + "$" + TextBoxName.Text + "$" + TextBoxInputTitle.Text + "}";
                else
                    Var = "{%" + DateType + "$" + TextBoxName.Text + "$" + TextBoxInputTitle.Text + "}";
                
            }
            this.DialogResult = DialogResult.OK;
           //this.Hide();
        }

        private void SetControls()
        {
            TextBoxName.Enabled = false;
            string[] Vparts=Var.Split('$');
            switch (Vparts[0])
            {
                case "{%TEXTVAR":
                    RadioText.Checked = true;
                    groupBox1.Enabled = false;
                    TextBoxName.Text = Vparts[1];
                    TextBoxInputTitle.Text = Vparts[2];
                break;
                case "{%DATELONGVAR":
                RadioText.Checked = false;
                groupBox1.Enabled = true;
                RadioDate.Checked = true;
                RadioLongDate.Checked = true;
                TextBoxName.Text = Vparts[1];
                TextBoxInputTitle.Text = Vparts[2];
                break;
                case "{%DATESHORTVAR":
                RadioText.Checked = false;
                groupBox1.Enabled = true;
                RadioDate.Checked = true;
                RadioShortDate.Checked = true;
                TextBoxName.Text = Vparts[1];
                TextBoxInputTitle.Text = Vparts[2];
                break;
                case "{%DATEVAR":
                RadioText.Checked = false;
                groupBox1.Enabled = true;
                RadioDate.Checked = true;
                RadioCustomDate.Checked = true;
                TextBoxCustomDate.Enabled = true;
                TextBoxCustomDate.Text = Vparts[1];
                TextBoxName.Text = Vparts[2];
                TextBoxInputTitle.Text = Vparts[3];
                break;
            }
        }
	}
}
