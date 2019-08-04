using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace RSH.TypoExpander
{
	/// <summary>
	/// Summary description for Dictionary.
	/// </summary>
	public class Dictionary
	{
		public string word;
		public string replacement;
		public string shortcut;
		public static int currentCategory;
		public static int[] CategoryIDs;
		/*public static DataSet dicts;
		public static DataSet chains;
		public static DataSet Categories;
		public static DataSet options;*/
		public static string ctyping;
		public static DataSet ds;
		public Form ParentForm;

		public Dictionary()
		{
			this.word="";
			this.replacement="";
			this.shortcut="";
		}
		public Dictionary(string w,string r,string s)
		{
			this.word=w;
			this.replacement=r;
			this.shortcut=s;
			
		}
		public string[] TextParser(Form f)
		{   
			//char[] dlimits={'|'};
			string[] cmds=this.replacement.Split('|');
			int[] Vindexes=new int[cmds.Length];
			VariableInput vi=new VariableInput();
			vi.RefreshControls();
			int top=10;
			int v=0;
			string[] NT;
			//MessageBox.Show(f,cmds[cmds.Length-1]);
			for(int i=0;i<cmds.Length-1;i++)
			{
				
					switch(cmds[i].Substring(0,7))
					{
						//default:
				//MessageBox.Show(f,cmds[i].Substring(0,6));
				//			break;
						case "?CSTDT?":
						
							break;

						case "?VLGDT?":
						
							cmds[i]=cmds[i].Remove(0,7);
							//MessageBox.Show(f,cmds[i]);
							Vindexes[v]=i;v++;
							NT=cmds[i].Split('?');
							
							vi.AddControl(new Label(),new Point(25,top),new Size(125,20),NT[1],0,"");					
							
							vi.AddControl(new DateTimePicker(),new Point(195,top),new Size(145,20),NT[1],0,"datetime"+vi.GetTotalControls(new DateTimePicker()));
							
							top+=20;
							break;
						case "?VSTDT?":
							
							cmds[i]=cmds[i].Remove(0,7);
							//MessageBox.Show(f,cmds[i]);
							Vindexes[v]=i;v++;
							
							break;
						case "?VTEXT?":
							cmds[i]=cmds[i].Remove(0,7);
							//MessageBox.Show(f,cmds[i]);
							Vindexes[v]=i;v++;
							NT=cmds[i].Split('?');
							//MessageBox.Show(f,NT[0]);
							
							vi.AddControl(new Label(),new Point(25,top),new Size(125,20),NT[1],0,"");					
							vi.AddControl(new TextBox(),new Point(195,top),new Size(145,20),NT[1],0,"textBox"+vi.GetTotalControls(new TextBox()));
							top+=20;
							
							break;
						case "?KEYST?":
							break;
						case "?SVLDT?":

							break;
						case "?SVSDT?":
							break;
						case "?DELAY?":
							cmds[i]=cmds[i].Remove(0,7);
							System.Threading.Thread.Sleep(int.Parse(cmds[i]));
						break;

							
					}
					
							
				
			}
			//cmds=GetVariableInput(cmds,Vindexes);
			vi.ShowDialog(f);
			//SendInput(cmds);
			return cmds;
		}
		public string[] GetVariableInput(string[] cmds,int[] Vindexes)
		{
			return cmds;
		}
		public void SendInput(string s)
		{
			/*System.Threading.Thread.Sleep(100);
			while(!IsWindow(hWnd)){}
			while(hWnd!=GetForegroundWindow()&&hWnd!=GetActiveWindow())
			{SetActiveWindow(hWnd);SetForegroundWindow(hWnd);SetFocus(hWnd);}
			System.Windows.Forms.SendKeys.Send("abc"+val);
			System.Threading.Thread.Sleep(100);*/
		}
		public ArrayList SubString()
		{
			string tmp;
			ArrayList subs=new ArrayList();
			int oBrace=-1,cBrace=0,BIndex=0,subIndex=0;
			char[] schar=replacement.ToCharArray();
			
			for(int i=0;i<schar.Length;i++)
			{
				if(schar[i]=='{')
				{
					if(oBrace==-1&&schar[i+1]=='%')
					{oBrace=1;BIndex=i;}
					else
						oBrace++;
				}
				else if(schar[i]=='}'&&oBrace>0)
				cBrace++;
				if(oBrace==cBrace)
				{
					
					tmp=replacement.Substring(BIndex,(i-BIndex+1));
						
					try
					{
						//MessageBox.Show(f,tmp+" "+BIndex+" "+(i-BIndex+1)+"\n"+tmp.Length+" "+subIndex);
					InputCommands ics=new InputCommands(BIndex,tmp.Length,tmp,tmp);
					subs.Add(ics);
					oBrace=-1;cBrace=0;
						
					}
					catch(Exception ex){MessageBox.Show(ParentForm,ex.Message+"\n"+oBrace+" "+cBrace+" "+BIndex+ " "+i);}
				}

			}
			
			return subs;
		}
		public int GetVariableCount(ArrayList subs)
		{
			InputCommands IC;
			int cn=0;
			for(int i=0;i<subs.Count;i++)
			{
				IC=(InputCommands)subs[i];
				if(IC.IsVariable(IC.oldCmd))
					cn++;
			}
			return cn;
		}
		public string ReplaceSpecialKeys(string s)
		{
			for(int i=0;i<Dictionary.ds.Tables["Keys"].Rows.Count;i++)
			{
				//MessageBox.Show(ParentForm,Dictionary.ds.Tables["Keys"].Rows[i].ItemArray[3].ToString()+"\n"+Dictionary.ds.Tables["Keys"].Rows[i].ItemArray[1].ToString());
				if(s.IndexOf(Dictionary.ds.Tables["Keys"].Rows[i].ItemArray[3].ToString())>-1)
					s=s.Replace(Dictionary.ds.Tables["Keys"].Rows[i].ItemArray[3].ToString(),Dictionary.ds.Tables["Keys"].Rows[i].ItemArray[1].ToString());
				/*else if(s.IndexOf("{Alt}")>-1)
					s=s.Replace("{Alt}","%");
				else if(s.IndexOf("{Shift}")>-1)
					s=s.Replace("{Shift}","+");*/
			}
			return s;
	}

		public ArrayList GetValues(ArrayList subs)
		{
			InputCommands IC;
			string[] sparts;
			DateTime dt;
			for(int i=0;i<subs.Count;i++)
			{
				dt=DateTime.Now;
				IC=(InputCommands)subs[i];
				if(IC.oldCmd.StartsWith("{%KS$"))
				{
					sparts=IC.oldCmd.Split('$');
					if(sparts[1].EndsWith("}"))
						sparts[1]=sparts[1].Remove(sparts[1].Length-1,1);
					//MessageBox.Show(f,""+sparts[1]);
					sparts[1]=ReplaceSpecialKeys(sparts[1]);
					
					IC.cmdReplacement=sparts[1];
				}
				else if(IC.oldCmd=="{%DATELONG}")
					IC.cmdReplacement=dt.ToLongDateString();
				else if(IC.oldCmd=="{%DATESHORT}")
					IC.cmdReplacement=dt.ToShortDateString();
				
				else if(IC.oldCmd.StartsWith("{%DATELONGAFTER$"))
				{
					sparts=IC.oldCmd.Split('$');
					if(sparts[1].EndsWith("}"))
						sparts[1]=sparts[1].Remove(sparts[1].Length-1,1);
					
					IC.cmdReplacement=dt.AddDays(int.Parse(sparts[1])).ToLongDateString();
				}
				else if(IC.oldCmd.StartsWith("{%DATESHORTAFTER$"))
				{
					sparts=IC.oldCmd.Split('$');
					if(sparts[1].EndsWith("}"))
						sparts[1]=sparts[1].Remove(sparts[1].Length-1,1);
					
					IC.cmdReplacement=dt.AddDays(int.Parse(sparts[1])).ToShortDateString();
				}
				
				else if(IC.oldCmd=="{%TIMELONG}")
					IC.cmdReplacement=dt.ToLongTimeString();
				else if(IC.oldCmd=="{%TIMESHORT}")
					IC.cmdReplacement=dt.ToShortTimeString();
				else if(IC.oldCmd.StartsWith("{%DATE$"))
				{
					try
					{
						
						sparts=IC.oldCmd.Split('$');
						if(sparts[1].EndsWith("}"))
							sparts[1]=sparts[1].Remove(sparts[1].Length-1,1);
					
						sparts[1]=sparts[1].Replace(",","/");
						
						IC.cmdReplacement=dt.ToString(sparts[1]);
						//MessageBox.Show(ParentForm,IC.cmdReplacement);
					}
					catch(Exception ex){MessageBox.Show(ParentForm,"Invalid Custom DateTime Format"+ex.Message);}
				}
				else if(IC.oldCmd.StartsWith("{%DATEAFTER$"))
				{
					try{

					sparts=IC.oldCmd.Split('$');
					if(sparts[2].EndsWith("}"))
						sparts[2]=sparts[2].Remove(sparts[2].Length-1,1);
					sparts[1]=sparts[1].Replace(",","/");
						//MessageBox.Show(ParentForm,sparts[2]);
					dt.AddDays(int.Parse(sparts[2]));
						
					IC.cmdReplacement=dt.ToString(sparts[1]);
						
				}
				catch(Exception ex){MessageBox.Show(ParentForm,"Invalid DateTime Format"+ex.Message);}
				}
			}
			return subs;
		}
		public string ReplaceMainString(ArrayList subs,string Mainstr)
		{
			InputCommands IC;
			//string[] sparts;			
			for(int i=0;i<subs.Count;i++)
			{
				IC=(InputCommands)subs[i];
				Mainstr=Mainstr.Replace(IC.oldCmd,IC.cmdReplacement);
			}
			return Mainstr;
		}
		public ArrayList BreakByDelays(string Mainstr)
		{
			
			int oBrace=-1,cBrace=0,sBIndex=0,cBIndex=0,subIndex=0;
			char[] schar=Mainstr.ToCharArray();
			ArrayList tmp=new ArrayList();
			//MessageBox.Show(ParentForm,Mainstr);
			for(int i=0;i<schar.Length;i++)
			{
				
				if(schar[i]=='{')
				{
					if(oBrace==-1&&schar[i+1]=='%')
					{oBrace=1;sBIndex=i;}
					//else
						//oBrace++;
				}
				else if(schar[i]=='}'&&oBrace>0)
				{cBrace++;cBIndex=i;}
				if(oBrace==cBrace)
				{
										
					try
					{	
						
						tmp.Add(Mainstr.Substring(subIndex,(sBIndex-subIndex)));						
						tmp.Add(Mainstr.Substring(sBIndex,(cBIndex-sBIndex)));						
						oBrace=-1;cBrace=0;subIndex=cBIndex+1;
				
						
					}
					catch(Exception ex){MessageBox.Show(ParentForm,ex.Message+"\n"+sBIndex+" "+cBIndex+" "+i+" SubIndex="+subIndex);}
					//MessageBox.Show(ParentForm,"Opening Brace:"+sBIndex+" Closing Brace:"+cBIndex+" SubIndex:"+subIndex+"\noBrace="+oBrace+" cBrace:"+cBrace);
				}

			}
			tmp.Add(Mainstr.Substring(subIndex,Mainstr.Length-subIndex));
			return tmp;
		}

		public static DataSet GetFromDB(string[] querys,string[] Tnames)
		{
			DataSet ds=new DataSet();
			System.Data.OleDb.OleDbDataAdapter da;
			try
			{	
				using(OleDbConnection conn=new System.Data.OleDb.OleDbConnection(MyConnection.source))
				{
						
					conn.Open();					
					//string select="Select * from Data_Dictionary";
					for(int i=0;i<querys.Length;i++)
					{
					da=new OleDbDataAdapter(querys[i],conn);					
					da.Fill(ds,Tnames[i]);
					}		
					conn.Close();
				}
				return ds;
			}
	
			catch(OleDbException ex){MessageBox.Show(ex.Message+"\nState:"+ex.Message,"DataBase Error",MessageBoxButtons.OK,MessageBoxIcon.Stop);return null;}
			catch(Exception excep)
			{
				MessageBox.Show("System Has been unable to perform the required task\n and will be shuttdown\n"+excep.Message,"Internal Error",MessageBoxButtons.OK,MessageBoxIcon.Stop);
				Application.Exit();
			}
			return ds;
		}
		public static Dictionary GetReplacement(string wrd,Form f)
		{
			wrd=wrd.Replace("'","\'");
			int cdict=Dictionary.currentCategory;
			DataRow[] chains=GetChains(cdict);
			DataTable dict=Dictionary.ds.Tables["Dictionaries"];
			DataRow[] dr;
			bool UseChain=IsChained(f);
			
			string select;
			/*try
			{	
				using(OleDbConnection conn=new System.Data.OleDb.OleDbConnection(MyConnection.source))
				{*/
						
					//conn.Open();
			
				dr=dict.Select("CategoryID="+cdict+"and UserWord='"+wrd+"'");
			
				MessageBox.Show(f,"problem ");

			if(dr.Length>0)
			{//MessageBox.Show(f,"Inside IF "+dr[0].ItemArray[3]);						
				return(new Dictionary((string)dr[0].ItemArray[2],(string)dr[0].ItemArray[4],dr[0].ItemArray[3].ToString()));}
				//return(new Dictionary((string)reader[0],(string)reader[2],(string)reader[1]));
				
			else if(chains.Length>0&&UseChain)
			//MessageBox.Show(f,"Else part");
				
				for(int i=0;i<chains.Length;i++)
				{
					
					cdict=(int)chains[i].ItemArray[2];
					dr=dict.Select("CategoryID="+cdict+"and UserWord='"+wrd+"'");
					//MessageBox.Show(f,"Chains "+chains[i].ItemArray[2]);
					if(dr.Length>0)
					{//MessageBox.Show(f,"Inside IF "+dr[0].ItemArray[3]);						
						return(new Dictionary((string)dr[0].ItemArray[2],(string)dr[0].ItemArray[4],dr[0].ItemArray[3].ToString()));}
				}
				//	conn.Close();
				/*}
				return null;
			}
	
			catch(OleDbException ex){MessageBox.Show(ex.Message+"\nState:"+ex.Message,"DataBase Error",MessageBoxButtons.OK,MessageBoxIcon.Stop);return null;}
			catch(Exception excep)
			{
				MessageBox.Show("System Has been unable to perform the required task\n and will be shuttdown\n"+excep.Message,"Internal Error",MessageBoxButtons.OK,MessageBoxIcon.Stop);
				Application.Exit();
			}*/
			return null;
		}
		public static DataRow[] GetChains(int cdict)
		{
			
			
					string select="CurrentCategoryID="+cdict;
					DataRow[] dr=Dictionary.ds.Tables["Chains"].Select(select);
					
					
			return dr;
			
		}
		public static bool IsChained(Form f)
		{
			DataSet data=new DataSet();
			data=Dictionary.ds;
			
			for(int i=0;i<data.Tables["Options"].Rows.Count;i++)
				if((string)ds.Tables["Options"].Rows[i].ItemArray[1]=="Use Chained Dictionaries"){
				return true;}
			
			return false;
		}

	}

	class InputCommands
	{
		public int StartIndex;
		public int Length;
		public string oldCmd;
		public string cmdReplacement;
		public bool IsDLngVar=false;
		public bool IsDShtVar=false;
		public bool IsTxtVar=false;
		public bool IsDCstVar=false;
		public bool IsSpValLngDT=false;
		public bool IsSpValShtDT=false;
		public bool IsSpValCstDT=false;
		public bool IsSpValLngAfter=false;
		public bool IsSpValShtAfter=false;
		public bool IsSpValCstAfter=false;
		public bool IsSpValShtTime=false;
		public bool IsSpValLngTime=false;
		public bool IsKeyStroke=false;

		public InputCommands()
		{
			StartIndex=0;
			Length=0;
			oldCmd="";
			cmdReplacement="";

		}
		public InputCommands(int i,int l,string s,string cRepl)
		{
			StartIndex=i;
			Length=l;
			oldCmd=s;
			cmdReplacement=cRepl;
			SetTypeOfCmd(s);
		}
		
		public void SetTypeOfCmd(string s)
		{
			if(s.StartsWith("{%TEXTVAR$"))
				IsTxtVar=true;
			else if(s.StartsWith("{%DATELONGVAR$"))
				IsDLngVar=true;
			else if(s.StartsWith("{%DATESHORTVAR$"))
				IsDShtVar=true;
			else if(s.StartsWith("{%DATEVAR$"))
				IsDCstVar=true;
			else if(s=="{%DATELONG}")
				IsSpValLngDT=true;
			else if(s=="{%DATESHORT}")
				IsSpValShtDT=true;
			else if(s.StartsWith("{%DATE$"))
				IsSpValCstDT=true;
			else if(s.StartsWith("{%DATELONGAFTER$"))
				IsSpValLngAfter=true;
			else if(s.StartsWith("{%DATESHORTAFTER$"))
				IsSpValShtAfter=true;
			else if(s.StartsWith("{%DATEAFTER$"))
				IsSpValCstAfter=true;
			else if(s=="{%TIMELONG}")
				IsSpValShtTime=true;
			else if(s=="{%TIMESHORT}")
				IsSpValShtTime=true;
			else if(s.StartsWith("{%KS$"))
				IsKeyStroke=true;
			
			
		}
		public bool IsVariable(string s)
		{
			if(s.StartsWith("{%TEXTVAR$")||s.StartsWith("{%DATELONGVAR$")||s.StartsWith("{%DATESHORTVAR$")||s.StartsWith("{%DATEVAR$"))
				return true;
			return false;
		}
		public bool IsDateVariable(string s)
		{
			if(s.StartsWith("{%DATELONGVAR$")||s.StartsWith("{%DATESHORTVAR$")||s.StartsWith("{%DATEVAR$"))
				return true;
			return false;
		}
		public bool IsSpecialValue(string s)
		{
			if(s=="{%DATELONG}"||s=="{%DATESHORT}"||s.StartsWith("{%DATE$")||s.StartsWith("{%DATELONGAFTER$")||s.StartsWith("{%DATESHORTAFTER$")||s.StartsWith("{%DATEAFTER$")||s=="{%TIMELONG}"||s=="{%TIMESHORT}")
				return true;
			return false;
		}
		

	}
}
