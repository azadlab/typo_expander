using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;

namespace RSH.TypoExpander
{
    public partial class Chains : Form
    {
        private int ID = -1;
        public Chains()
        {
            InitializeComponent();
            
            LoadChains();
            //this.Text += "         Adding Chains for <>";
            
            
            
            
        }
        private void LoadChains()
        {
            ListViewItem li;
            DataRow dr=Dictionary.ds.Tables["Categories"].Rows.Find(Dictionary.currentCategory);
            this.Text = "         Adding Chains for <"+(string)dr[1]+">";
            DataRow[] rows=dr.GetChildRows("chains");
            foreach(DataRow d in rows)
                {
                    dr = Dictionary.ds.Tables["Categories"].Rows.Find((int)d[2]);
                    li = new ListViewItem((string)dr[1]);
                    li.Tag = (int)d[0];
                    li.ToolTipText = ""+(int)d[0];
                    ChainedList.Items.Add(li);
                    
                }
            LoadUnChained(rows);
        }

        private void LoadUnChained(DataRow[] rows)
        {
            bool flag=true;
            ListViewItem li;
            
            foreach (DataRow cat in Dictionary.ds.Tables["Categories"].Rows)
            {
                foreach (DataRow chain in rows)
                {
                    
                    if ((int)cat[0] == (int)chain[2])
                        flag = false;
                }
                if (flag)
                 if((int)cat[0]!=Dictionary.currentCategory)
                {
                    
                    li = new ListViewItem((string)cat[1]);
                    li.Tag = (int)cat[0];
                    li.ToolTipText = "" + (int)cat[0];
                    this.RestList.Items.Add(li);
                }
                flag = true;
            }
        }

        private void AddToChain_Click(object sender, EventArgs e)
        {
            ListViewItem li;
            
            if (RestList.SelectedItems.Count > 0)
            {
                
                if(!AlreadyExist((string)RestList.SelectedItems[0].Text))
                    if ((ID = AlterChains("insert into data_Chains(CurrentCategoryID,ChainCategoryID) values(" + Dictionary.currentCategory + "," + (int)RestList.SelectedItems[0].Tag + ")", true)) > 0)
                    {
                        Dictionary.ds.Tables["Chains"].Rows.Add(ID, Dictionary.currentCategory, (int)RestList.SelectedItems[0].Tag);
                        Dictionary.ds.Tables["Chains"].AcceptChanges();
                        li = new ListViewItem(RestList.SelectedItems[0].Text);
                        li.Tag = ID;
                        li.ToolTipText = "" + ID;
                        ChainedList.Items.Add(li);
                        RestList.SelectedItems[0].Remove();
                    }
            }
        }
        private bool AlreadyExist(string CatTitle)
        {
            
            if(ChainedList.Items.Count>0)
            for (int i = 0; i < ChainedList.Items.Count; i++)
                if ((string)ChainedList.Items[i].Text == CatTitle)
                    
                    return true;
                
            
            return false;


        }
        private void AddAll_Click(object sender, EventArgs e)
        {
            ListViewItem li;
            
            if(RestList.Items.Count>0)
            for (int i = 0; i < RestList.Items.Count;i++ )
            {
                
                if (!AlreadyExist((string)RestList.Items[i].Text))
                {
                     
                    if ((ID = AlterChains("insert into data_Chains(CurrentCategoryID,ChainCategoryID) values(" + Dictionary.currentCategory + "," + (int)RestList.Items[i].Tag + ")", true)) > 0)
                    {

                        Dictionary.ds.Tables["Chains"].Rows.Add(ID, Dictionary.currentCategory, (int)RestList.Items[i].Tag);
                        Dictionary.ds.Tables["Chains"].AcceptChanges();
                        li = new ListViewItem(RestList.Items[i].Text);
                        li.Tag = ID;
                        li.ToolTipText = "" + ID;
                        ChainedList.Items.Add(li);
                        
                    }
                }
                
            }
            RestList.Items.Clear();
        }

        private void RemoveChain_Click(object sender, EventArgs e)
        {
            ListViewItem li;
            if (ChainedList.SelectedItems.Count > 0)
            {
                
                if ((ID = AlterChains("delete from data_Chains where ChainID=" + (int)ChainedList.SelectedItems[0].Tag, false)) > 0)
                    
                    {
                        DataRow dr = Dictionary.ds.Tables["Chains"].Rows.Find((int)ChainedList.SelectedItems[0].Tag);                        
                        li = new ListViewItem((string)ChainedList.SelectedItems[0].Text);
                        li.Tag = (int)dr[2];
                        li.ToolTipText = "" + (int)dr[2];
                        this.RestList.Items.Add(li);
                        Dictionary.ds.Tables["Chains"].Rows.Find((int)ChainedList.SelectedItems[0].Tag).Delete();
                        Dictionary.ds.Tables["Chains"].AcceptChanges();
                        ChainedList.SelectedItems[0].Remove();
                    }
                
            }
            
        }

        private void RemoveAll_Click(object sender, EventArgs e)
        {
            ListViewItem li;

                    if ((ID = AlterChains("delete from data_Chains where CurrentCategoryID=" + Dictionary.currentCategory, false)) > 0)
                    {
                        if (ChainedList.Items.Count > 0)
                        {
                            for (int i =0 ; i <ChainedList.Items.Count ; i++)
                            {
                                
                                DataRow dr = Dictionary.ds.Tables["Chains"].Rows.Find((int)ChainedList.Items[i].Tag);
                                li = new ListViewItem((string)ChainedList.Items[i].Text);
                                li.Tag = (int)dr[2];
                                li.ToolTipText = "" + (int)dr[2];
                                this.RestList.Items.Add(li);
                               
                                Dictionary.ds.Tables["Chains"].AcceptChanges();
                                
                                //ChainedList.Items[i].Remove();


                            }
                            foreach (DataRow d in Dictionary.ds.Tables["Chains"].Rows)
                                if ((int)d[1] == Dictionary.currentCategory)
                                    d.Delete();
                            ChainedList.Items.Clear();
                        }
                        
                       
                }
            
        }
        public static int AlterChains(string query, bool IsInsert)
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
    }
}
