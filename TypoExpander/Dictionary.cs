using System;
using System.Drawing;
using System.Collections;
using System.Collections.Specialized;
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
		/*public string[] TextParser(Form f)
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
		}*/
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
            bool CmdFound = false;
            

			for(int i=0;i<schar.Length;i++)
			{
				if(schar[i]=='{')
                {

                    if (CmdFound)
                        oBrace++;
                    if(oBrace == -1&&schar[i+1]=='%')
                    { oBrace = 1; BIndex = i; CmdFound = true;  }

                    
                   
				}
                else if (schar[i] == '}' && oBrace > 0)
                 cBrace++;
				if(oBrace==cBrace)
				{
                    CmdFound = false;
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
        public StringDictionary GetVariables()
        {
            StringDictionary Vars=new StringDictionary();
            ArrayList subs=this.SubString();
            InputCommands IC;
            string[] Sparts;
            for (int i = 0; i < subs.Count; i++)
            {
                IC = (InputCommands)subs[i];
                Sparts = IC.oldCmd.Split('$');
                
                
                if (IC.IsVariable(IC.oldCmd))
                {
                    
                    if (Sparts[0] == "{%DATEVAR")
                    {
                        Sparts[2] = Sparts[2].ToUpper();
                        Sparts[2] = Sparts[2].Trim('}');
                        if (!KeyAlreadyExists(Vars, Sparts[2]))
                            Vars.Add(Sparts[2], IC.oldCmd);

                    }
                    else
                    {
                        Sparts[1] = Sparts[1].ToUpper();
                        Sparts[2] = Sparts[1].Trim('}');
                        if (!KeyAlreadyExists(Vars, Sparts[1]))
                        Vars.Add(Sparts[1], IC.oldCmd);
                    }
                }
            }
            return Vars;
        }
        private bool KeyAlreadyExists(StringDictionary vars,string name)
        {

            foreach (DictionaryEntry de in vars)
              if (((string)de.Key).ToUpper() == name.ToUpper())
                return true;
                
              
            return false;
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
					/*sparts=IC.oldCmd.Split('$');
					if(sparts[1].EndsWith("}"))
						sparts[1]=sparts[1].Remove(sparts[1].Length-1,1);
					//MessageBox.Show(f,""+sparts[1]);
					sparts[1]=ReplaceSpecialKeys(sparts[1]);
					
					IC.cmdReplacement=sparts[1];*/
				}
				else if(IC.oldCmd=="{%DATELONG}")
					IC.cmdReplacement="{{"+dt.ToLongDateString()+"}}";
				else if(IC.oldCmd=="{%DATESHORT}")
					IC.cmdReplacement="{{"+dt.ToShortDateString()+"}}";
				
				else if(IC.oldCmd.StartsWith("{%DATELONGAFTER$"))
				{
					sparts=IC.oldCmd.Split('$');
					if(sparts[1].EndsWith("}"))
						sparts[1]=sparts[1].Remove(sparts[1].Length-1,1);
					
					IC.cmdReplacement="{{"+dt.AddDays(int.Parse(sparts[1])).ToLongDateString()+"}}";
				}
				else if(IC.oldCmd.StartsWith("{%DATESHORTAFTER$"))
				{
					sparts=IC.oldCmd.Split('$');
					if(sparts[1].EndsWith("}"))
						sparts[1]=sparts[1].Remove(sparts[1].Length-1,1);
					
					IC.cmdReplacement="{{"+dt.AddDays(int.Parse(sparts[1])).ToShortDateString()+"}}";
				}
				
				else if(IC.oldCmd=="{%TIMELONG}")
					IC.cmdReplacement="{{"+dt.ToLongTimeString()+"}}";
				else if(IC.oldCmd=="{%TIMESHORT}")
					IC.cmdReplacement="{{"+dt.ToShortTimeString()+"}}";
				else if(IC.oldCmd.StartsWith("{%DATE$"))
				{
					try
					{
						
						sparts=IC.oldCmd.Split('$');
						if(sparts[1].EndsWith("}"))
							sparts[1]=sparts[1].Remove(sparts[1].Length-1,1);
					
						sparts[1]=sparts[1].Replace(",","/");
						
						IC.cmdReplacement="{{"+dt.ToString(sparts[1])+"}}";
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
						
					IC.cmdReplacement="{{"+dt.ToString(sparts[1])+"}}";
						
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
		public static Dictionary GetReplacement(string wrd,bool IsShortCut,int ActiveORChainORAll)
		{
			wrd=wrd.Replace("'","\"");
			int cdict=Dictionary.currentCategory;
			DataRow[] chains=GetChains(cdict);
			DataTable dict=Dictionary.ds.Tables["Dictionaries"];
			DataRow[] dr;
            bool UseChain=false;
            
            if (ActiveORChainORAll==0)
                UseChain = false;
            else if (ActiveORChainORAll == 1)
                UseChain = IsChained();

            //MessageBox.Show("Word:"+wrd+"\nIsShortCut"+IsShortCut.ToString()+"\nActive|Chained|All:"+ActiveORChainORAll.ToString());
			string select;
			/*try
			{	
				using(OleDbConnection conn=new System.Data.OleDb.OleDbConnection(MyConnection.source))
				{*/
						
					//conn.Open();
            if (IsShortCut)
            {
                dr = dict.Select("CategoryID=" + cdict + "and Shortcut='" + wrd + "'");
                if (ActiveORChainORAll == 2)
                    dr = dict.Select("Shortcut='" + wrd + "'");
            }
            else
            {
                dr = dict.Select("CategoryID=" + cdict + "and UserWord='" + wrd + "'");
                if (ActiveORChainORAll == 2)
                    dr = dict.Select("UserWord='" + wrd + "'");
            }

				
			    
                
				//MessageBox.Show(f,"problem ");

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
		public static bool IsChained()
		{
			DataSet data=new DataSet();
			data=Dictionary.ds;
			
			for(int i=0;i<data.Tables["Options"].Rows.Count;i++)
				if((string)ds.Tables["Options"].Rows[i].ItemArray[1]=="Use Chained Dictionaries"){
				return true;}
			
			return false;
		}
        public static int SaveWord(Dictionary dct)
        {
            DataSet data = new DataSet();
            System.Data.OleDb.OleDbDataAdapter da;
            dct.replacement=dct.replacement.Replace('\'','\"');
            dct.word = dct.word.Replace('\'', '\"');
            dct.shortcut = dct.shortcut.Replace('\'', '\"');
            try
            {
                using (OleDbConnection conn = new System.Data.OleDb.OleDbConnection(MyConnection.source))
                {

                    conn.Open();
                    string Qinsert = "insert into data_Dictionary(CategoryID,UserWord,Shortcut,Replacement) values("+Dictionary.currentCategory+",'"+dct.word+"','"+dct.shortcut+"','"+dct.replacement+"')";

                    OleDbCommand cmd = new OleDbCommand(Qinsert, conn);
                    if (!AlreadyExists(dct))
                    {
                        
                        int af = cmd.ExecuteNonQuery();
                        if (af <= 0)
                        { MessageBox.Show("Error occured while adding record to database", "Insertion Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return -1; }
                        else
                        {
                            cmd.CommandText = "select @@IDENTITY";
                            int ID= (int)cmd.ExecuteScalar();                            
                            Dictionary.ds.Tables["Dictionaries"].Rows.Add(ID, Dictionary.currentCategory, dct.word, dct.shortcut, dct.replacement);
                            
                            return ID;
                        }
                    }
                    else
                    { MessageBox.Show("A Word with name '" + dct.word + "' Already Exisits", "Insertion Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return -1; }
                    conn.Close();
                    
                }

            }

            catch (OleDbException ex) { MessageBox.Show(ex.Message + "\nState:" + ex.Message, "DataBase Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
            catch (Exception excep)
            {
                MessageBox.Show("System Has been unable to perform the required task\n and will be shuttdown\n" + excep.Message, "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }
            return -1;
        }
        private static bool AlreadyExists(Dictionary dct)
        {
            DataTable dt=Dictionary.ds.Tables["Dictionaries"];
            try
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                    if ((int)dt.Rows[i].ItemArray[1] == Dictionary.currentCategory)
                        if ((string)dt.Rows[i].ItemArray[2] == dct.word)
                            return true;
                return false;
            }

            catch (Exception excep)
            {
                MessageBox.Show("System Has been unable to perform the required task\n and will be shuttdown\n" + excep.Message, "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }
            return false;
        }
        public static bool UpdateWord(Dictionary dct)
        {
            
            
            dct.replacement = dct.replacement.Replace('\'', '\"');
            dct.word = dct.word.Replace('\'', '\"');
            dct.shortcut = dct.shortcut.Replace('\'', '\"');
            try
            {
                using (OleDbConnection conn = new System.Data.OleDb.OleDbConnection(MyConnection.source))
                {

                    conn.Open();
                    string Qupdate = "update data_Dictionary set Shortcut='" + dct.shortcut + "',Replacement='" + dct.replacement + "' where CategoryID="+Dictionary.currentCategory+" and UserWord='"+dct.word+"'";

                    OleDbCommand cmd = new OleDbCommand(Qupdate, conn);
                    
                        int af = cmd.ExecuteNonQuery();
                        if (af <= 0)
                        { MessageBox.Show("Error occured while updating record to database", "Updation Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
                        else
                        {
                            UpdateLocalTable(dct);
                            return true;
                        }
                    
                    conn.Close();

                }

            }

            catch (OleDbException ex) { MessageBox.Show(ex.Message + "\nState:" + ex.Message, "DataBase Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
            catch (Exception excep)
            {
                MessageBox.Show("System Has been unable to perform the required task\n and will be shuttdown\n" + excep.Message, "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }
            return false;
        }
        private static void UpdateLocalTable(Dictionary dct)
        {

            for (int i = 0; i < Dictionary.ds.Tables["Dictionaries"].Rows.Count; i++)
            {
                if (Dictionary.currentCategory == (int)Dictionary.ds.Tables["Dictionaries"].Rows[i][1])
                   if (dct.word ==(string) Dictionary.ds.Tables["Dictionaries"].Rows[i][2])
                {
                    Dictionary.ds.Tables["Dictionaries"].Rows[i][3] = dct.shortcut;
                    Dictionary.ds.Tables["Dictionaries"].Rows[i][4] = dct.replacement;
                    Dictionary.ds.Tables["Dictionaries"].AcceptChanges();
                }
            }
        }
        public static int AlterDictionary(string query,bool IsInsert)
        {
            
            try
            {
                using (OleDbConnection conn = new System.Data.OleDb.OleDbConnection(MyConnection.source))
                {

                    conn.Open();
                    

                    OleDbCommand cmd = new OleDbCommand(query, conn);

                    int af = cmd.ExecuteNonQuery();
                    if (af <= 0)
                    { MessageBox.Show("Error occured while Altering record of database", "Record Manipulation Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return -1; }
                    else
                    {
                        if (IsInsert)
                        {
                            cmd.CommandText = "select @@IDENTITY";
                            int ID = (int)cmd.ExecuteScalar();
                            return ID;
                        }
                        return 1;
                    }
                    conn.Close();

                }

            }

            catch (OleDbException ex) { MessageBox.Show(ex.Message + "\nState:" + ex.Message, "DataBase Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
            catch (Exception excep)
            {
                MessageBox.Show("System Has been unable to perform the required task\n and will be shuttdown\n" + excep.Message, "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }
            return -1;
        }
        public static bool DeleteWord(int ID)
        {
            
            
            try
            {
                using (OleDbConnection conn = new System.Data.OleDb.OleDbConnection(MyConnection.source))
                {

                    conn.Open();
                    string Qdelete = "delete from data_Dictionary where UserWordID=" + ID;

                    OleDbCommand cmd = new OleDbCommand(Qdelete, conn);

                    int af = cmd.ExecuteNonQuery();
                    if (af <= 0)
                    { MessageBox.Show("Error occured while deleting record from database", "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
                    else
                    {
                        DeleteFromLocalTable(ID);
                        return true;
                    }

                    conn.Close();

                }

            }

            catch (OleDbException ex) { MessageBox.Show(ex.Message + "\nState:" + ex.Message, "DataBase Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
            catch (Exception excep)
            {
                MessageBox.Show("System Has been unable to perform the required task\n and will be shuttdown\n" + excep.Message, "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }
            return false;
        }
        private static void DeleteFromLocalTable(int ID)
        {

            /*for (int i = 0; i < Dictionary.ds.Tables["Dictionaries"].Rows.Count; i++)
            {
                if (ID ==(int) Dictionary.ds.Tables["Dictionaries"].Rows[i][0])
              */      {
                        //Dictionary.ds.Tables["Dictionaries"].Rows[i].Delete();
                          Dictionary.ds.Tables["Dictionaries"].Rows.Find(ID).Delete();
                        Dictionary.ds.Tables["Dictionaries"].AcceptChanges();
                    }
            //}
        }
        public void ConvertOldDB()
        {
            DataSet data = new DataSet();
            System.Data.OleDb.OleDbDataAdapter da;
            try
            {
                using (OleDbConnection conn = new System.Data.OleDb.OleDbConnection(MyConnection.source))
                {

                    conn.Open();
                    string select="Select * from data_Dictionary";
                    
                        da = new OleDbDataAdapter(select, conn);
                        OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                        da.Fill(data, "data_Dictionary");
                        
                        for (int i = 0; i < data.Tables["data_Dictionary"].Rows.Count; i++)
                        {
                            
                            UpdateReplacement(data.Tables["data_Dictionary"].Rows[i]["Replacement"].ToString());
                            //MessageBox.Show(replacement);
                            data.Tables["data_Dictionary"].Rows[i]["Replacement"] = replacement;
                            
                            if (data.Tables["data_Dictionary"].Rows[i]["Shortcut"].ToString() != "")
                                data.Tables["data_Dictionary"].Rows[i]["Shortcut"] = ReplaceKeys(data.Tables["data_Dictionary"].Rows[i]["Shortcut"].ToString());

                            
                        }
                        da.Update(data, "data_Dictionary");
                        
                    conn.Close();
                }
                
            }

            catch (OleDbException ex) { MessageBox.Show(ex.Message + "\nState:" + ex.Message, "DataBase Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);  }
            catch (Exception excep)
            {
                MessageBox.Show("System Has been unable to perform the required task\n and will be shuttdown\n" + excep.Message, "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }
        }
        public void UpdateReplacement(string wrepl)
        {
            
            this.replacement=wrepl;
            
            InputCommands IC;
            ArrayList substrs = this.SubString();
            int cur = 0;
            if (substrs.Count <= 0 && replacement.Length > 0)
                replacement = "{{"+replacement+"}}";
            
            for (int i = 0; i < substrs.Count; i++)
            {
                
                IC = (InputCommands)substrs[i];

                
                cur = IC.StartIndex + IC.Length;

                if (replacement.Substring(cur).IndexOf("{%")>=0)
                {

                    if (replacement.Substring(cur).IndexOf("{%") + cur != cur)
                    {

                        //MessageBox.Show(replacement.Substring(cur));
                        replacement = replacement.Insert(cur, "{{");
                        replacement = this.replacement.Insert(replacement.Substring(cur).IndexOf("{%") + cur, "}}");
                        if (i + 1 < substrs.Count)
                            for (int n = i + 1; n < substrs.Count; n++)
                            {
                                IC = (InputCommands)substrs[n];
                                IC.StartIndex += 4;
                                substrs[n] = IC;
                            }
                    }
                    
                }
                else if (replacement.Substring(cur).Length > 0 && substrs.Count == i + 1)
                {
                    //MessageBox.Show(replacement.Substring(cur));
                    replacement = replacement.Insert(cur, "{{");
                    replacement = replacement.Insert(replacement.Length, "}}");
                }
                    
                
            }
            if(substrs.Count>0)
            {
            IC = (InputCommands)substrs[0];
            if (IC.StartIndex > 0)
                {

                
                replacement = replacement.Insert(IC.StartIndex, "}}");
                replacement = replacement.Insert(0, "{{");

                }
            }
            
            ReplaceByKey(substrs);
            //ParentForm.textBox2.Text = tmp;
        }

        public void ReplaceByKey(ArrayList substrs)
        {
            
            InputCommands IC;
            string[] parts;
            for (int i = 0; i < substrs.Count; i++)
            {
                IC = (InputCommands)substrs[i];
                
                if (IC.oldCmd.StartsWith("{%KS$"))
                {
                    
                    IC.cmdReplacement = IC.cmdReplacement.Remove(0, 5);
                    IC.cmdReplacement = IC.cmdReplacement.Remove(IC.cmdReplacement.Length - 1, 1);
                    
                    //IC.cmdReplacement = ReplaceByKey(IC.cmdReplacement, f);
                    
                    IC.cmdReplacement = ReplaceKeys(IC.cmdReplacement);
                    
                    replacement = replacement.Replace(IC.oldCmd, "{"+IC.cmdReplacement+"}");
                }
                else if (IC.oldCmd.StartsWith("{%DELAY$"))
                {
                    IC.cmdReplacement =IC.oldCmd.TrimEnd('}');
                    parts = IC.cmdReplacement.Split('$');
                    IC.cmdReplacement = "{Pause:" + (int.Parse(parts[1]) / 100) + "}";
                    replacement = replacement.Replace(IC.oldCmd, IC.cmdReplacement);
                }
               // f.textBox2.Text += IC.cmdReplacement + "       \n";
               
            }
           
            
            
            
        }
        public string ReplaceKeys(string s)
        {
            
            s = s.Replace("{Ctrl}", "Ctrl");
            s = s.Replace("{Shift}", "Shift");
            s = s.Replace("{Alt}", "Alt");
            
            for (int j = 0; j < ProgKeys.keys.Length; j++)
            {
                
                if (s.IndexOf(ProgKeys.keys[j]) >= 0)
                {
                    
                    s = s.Replace(ProgKeys.keys[j], ProgKeys.values[j]);
                    break;
                }
            }

            s = s.Replace("Ctrl", "Ctrl+");
            s = s.Replace("Shift", "Shift+");
            s = s.Replace("Alt", "Alt+");
            return s;
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
