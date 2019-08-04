using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace RSH.TypoExpander
{
	/// <summary>
	/// Summary description for VariableInput.
	/// </summary>
	public class VariableInput : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public VariableInput()
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
		public void AddControl(Control aControl,Point Location,Size size,String strText,int TabIndex,string strName)
		{
			
			aControl.Location=Location;
			aControl.Size=size;
			if(!(aControl.GetType()==new DateTimePicker().GetType()))				
			aControl.Text=strText;
			aControl.TabIndex=TabIndex;
			aControl.Name=strName;
			this.Controls.Add(aControl);
		}
		public void RefreshControls()
		{
			Controls.Clear();
			InitializeComponent();
		}
		public int GetTotalControls(Control aControl)
		{
			int cn=0;
			
			for(int i=0;i<Controls.Count;i++)
			{
				if(Controls[i].GetType()==(new TextBox()).GetType())
					cn++;
						else if(Controls[i].GetType()==(new DateTimePicker()).GetType())
						cn++;
			}
		return Controls.Count;
		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// VariableInput
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(456, 266);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "VariableInput";
			this.ShowInTaskbar = false;
			this.Text = "VariableInput";

		}
		#endregion
	
		public ArrayList GetVariableInput(ArrayList subs,int vcn,Form f)
		{
			
			InputCommands IC;
			int[] Vindexes=new int[vcn];
			
			RefreshControls();
			string[] NT;
			int top=10,v=0;
			
			for(int i=0;i<subs.Count;i++)
			{
				IC=(InputCommands)subs[i];
				if(IC.IsVariable(IC.oldCmd))
				{
					if(IC.IsDateVariable(IC.oldCmd))
					{
						if(!IC.oldCmd.StartsWith("{%DATEVAR$"))
						{
							Vindexes[v]=i;v++;
							NT=IC.oldCmd.Split('$');
							NT[2]=NT[2].TrimEnd('}');
							AddControl(new Label(),new Point(25,top),new Size(125,30),NT[2].TrimEnd('}'),0,"");											
							AddControl(new DateTimePicker(),new Point(195,top),new Size(145,30),NT[1],0,"datetime"+GetTotalControls(new DateTimePicker()));
							top+=30;
						}
						else 
						{
							Vindexes[v]=i;v++;
							NT=IC.oldCmd.Split('$');
							NT[3]=NT[3].TrimEnd('}');
							AddControl(new Label(),new Point(25,top),new Size(125,30),NT[3].TrimEnd('}'),0,"");											
							AddControl(new DateTimePicker(),new Point(195,top),new Size(145,30),NT[2],0,"datetime"+GetTotalControls(new DateTimePicker()));
							top+=30;
						}
					}
					else if(IC.oldCmd.StartsWith("{%TEXTVAR$"))
					{
						Vindexes[v]=i;v++;
						NT=IC.oldCmd.Split('$');
						NT[2]=NT[2].TrimEnd('}');
						AddControl(new Label(),new Point(25,top),new Size(125,30),NT[2],0,"");
						AddControl(new TextBox(),new Point(195,top),new Size(145,30),NT[2],0,"textBox"+GetTotalControls(new TextBox()));
						top+=30;
					}
				}//End of For IF

				}//End of Loop
			

			Button OkButton=new Button();
			Button CancelButton=new Button();
			OkButton.Click+=new EventHandler(this.Ok_press);
			CancelButton.Click+=new EventHandler(Cancel_press);
			AddControl(OkButton,new Point(25,top+10),new Size(125,25),"OK",0,"");
			AddControl(CancelButton,new Point(195,top+10),new Size(145,25),"Cancel",0,"textBox"+GetTotalControls(new TextBox()));

			if(this.Height<top+10)
				this.Size=new Size(this.Width,top+100);
			
			if(this.Controls.Count>2)
			this.ShowDialog(f);
			//MessageBox.Show(this,"Size"+this.Size.ToString()+"\nTop:"+top);
			int k=1;
			//MessageBox.Show(this,"Length:"+Controls.Count);
			for(int i=0;i<Vindexes.Length;i++)
			{
				IC=(InputCommands)subs[Vindexes[i]];
				if(Controls[i+k].GetType()==new TextBox().GetType())
				IC.cmdReplacement=Controls[i+k].Text;
				else if(Controls[i+k].GetType()==new DateTimePicker().GetType())
				IC.cmdReplacement=((DateTimePicker)Controls[i+k]).Value.ToString();
				subs[Vindexes[i]]=IC;
				k++;

			}
			
			return subs;
		}
		//public Control GetControlIndex(
		public void Ok_press(object sender,EventArgs e)
		{
			this.Hide();
		}
		public void Cancel_press(object sender,EventArgs e)
		{
			this.Hide();
		}

	}
}
