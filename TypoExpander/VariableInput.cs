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
        private TableLayoutPanel LayoutPanel;
        private Label label1;
        private Label label2;
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
		public void AddControl(Control aControl,Point Location,Size size,String strText,int TabIndex,string strName,int row,int column)
		{
			
			//aControl.Location=Location;
			aControl.Size=size;
			if(!(aControl.GetType()==new DateTimePicker().GetType()))				
			aControl.Text=strText;
			aControl.TabIndex=TabIndex;
			aControl.Name=strName;
			//this.Controls.Add(aControl);
            LayoutPanel.Controls.Add(aControl, column, row);
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
            this.LayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.AutoSize = true;
            this.LayoutPanel.BackColor = System.Drawing.Color.AliceBlue;
            this.LayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.LayoutPanel.ColumnCount = 2;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.LayoutPanel.Controls.Add(this.label2, 1, 0);
            this.LayoutPanel.Controls.Add(this.label1, 0, 0);
            this.LayoutPanel.Location = new System.Drawing.Point(11, 5);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 1;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LayoutPanel.Size = new System.Drawing.Size(432, 231);
            this.LayoutPanel.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Variable Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(262, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Variable Value";
            // 
            // VariableInput
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(452, 243);
            this.Controls.Add(this.LayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VariableInput";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "VariableInput";
            this.TopMost = true;
            this.LayoutPanel.ResumeLayout(false);
            this.LayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
                            
                            LayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
                            LayoutPanel.RowCount++;
                            
							AddControl(new Label(),new Point(25,top),new Size(125,30),NT[2].TrimEnd('}'),0,"",LayoutPanel.RowCount-1,0);
                            AddControl(new DateTimePicker(), new Point(195, top), new Size(145, 30), NT[1], 0, "datetime" + GetTotalControls(new DateTimePicker()), LayoutPanel.RowCount - 1, 1);
							top+=30;
						}
						else 
						{
							Vindexes[v]=i;v++;
							NT=IC.oldCmd.Split('$');
							NT[3]=NT[3].TrimEnd('}');

                            LayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
                            LayoutPanel.RowCount++;

                            AddControl(new Label(), new Point(25, top), new Size(125, 30), NT[3].TrimEnd('}'), 0, "", LayoutPanel.RowCount - 1, 0);
                            AddControl(new DateTimePicker(), new Point(195, top), new Size(145, 30), NT[2], 0, "datetime" + GetTotalControls(new DateTimePicker()), LayoutPanel.RowCount - 1, 1);
							top+=30;
						}
					}
					else if(IC.oldCmd.StartsWith("{%TEXTVAR$"))
					{
						Vindexes[v]=i;v++;
						NT=IC.oldCmd.Split('$');
						NT[2]=NT[2].TrimEnd('}');

                        LayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
                        LayoutPanel.RowCount++;


                        AddControl(new Label(), new Point(25, top), new Size(125, 30), NT[2], 0, "", LayoutPanel.RowCount - 1, 0);
                        AddControl(new TextBox(), new Point(195, top), new Size(145, 30), NT[2], 0, "textBox" + GetTotalControls(new TextBox()), LayoutPanel.RowCount - 1, 1);
						top+=30;
					}
				}//End of For IF

				}//End of Loop
			

			Button OkButton=new Button();
			Button CancelButton=new Button();
			OkButton.Click+=new EventHandler(this.Ok_press);
			CancelButton.Click+=new EventHandler(Cancel_press);

            LayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));            
            LayoutPanel.RowCount++;

			AddControl(OkButton,new Point(25,top+10),new Size(125,25),"OK",0,"",LayoutPanel.RowCount - 1,0);
            AddControl(CancelButton, new Point(195, top + 10), new Size(145, 25), "Cancel", 0, "textBox" + GetTotalControls(new TextBox()), LayoutPanel.RowCount - 1,1);

			//if(this.Height<top+10)
			//	this.Size=new Size(this.Width,top+100);
            //this.Size = new Size(this.Width, LayoutPanel.Height+20);

            if (this.LayoutPanel.Controls.Count > 2)
            {
                this.ShowDialog(f);
                //MessageBox.Show(this,"Size"+this.Size.ToString()+"\nTop:"+top);
                int k = 1;
                //MessageBox.Show(this,"Length:"+Controls.Count);
                for (int i = 0; i < Vindexes.Length; i++)
                {
                    IC = (InputCommands)subs[Vindexes[i]];
                    if (LayoutPanel.Controls[i + k].GetType() == new TextBox().GetType())
                        IC.cmdReplacement = "{{" + LayoutPanel.Controls[i + k].Text + "}}";
                    else if (LayoutPanel.Controls[i + k].GetType() == new DateTimePicker().GetType())
                        IC.cmdReplacement = "{{" + ((DateTimePicker)LayoutPanel.Controls[i + k]).Value.ToString() + "}}";
                    subs[Vindexes[i]] = IC;
                    k++;

                }
            }
            else
                this.Dispose();
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
