using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace RSH.TypoExpander
{
	/// <summary>
	/// Summary description for Dictionaries.
	/// </summary>
	public class Dictionaries : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button AddButton;
		private System.Windows.Forms.Button EditButton;
		private System.Windows.Forms.Button DeleteButton;
		private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TextBox textBox1;
        private Label label1;
        private Button UpdateButton;
        public ListView DictionaryList;
        private ColumnHeader columnHeader1;
        private DataGridView dg;
        private AppMain AM;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Dictionaries(AppMain Apm)
		{
			InitializeComponent();
            RefreshDicts();
            AM = Apm;
		}
        private void RefreshDicts()
        {
            if (DictionaryList.Items.Count > 0)
                DictionaryList.Items.Clear();
            ListViewItem li;
            for (int i = 0; i < Dictionary.ds.Tables["Categories"].Rows.Count; i++)
            {
                li = new ListViewItem((string)Dictionary.ds.Tables["Categories"].Rows[i][1]);
                li.Tag = (int)Dictionary.ds.Tables["Categories"].Rows[i][0];
                li.ToolTipText = "ID:"+(int)Dictionary.ds.Tables["Categories"].Rows[i][0];
                if(!AlreadyExist(li.Text))
                DictionaryList.Items.Add(li);

            }
        }
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
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
            this.AddButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.DictionaryList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Enabled = false;
            this.AddButton.Location = new System.Drawing.Point(239, 24);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 24);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Add";
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Enabled = false;
            this.EditButton.Location = new System.Drawing.Point(239, 62);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 24);
            this.EditButton.TabIndex = 0;
            this.EditButton.Text = "Edit";
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Enabled = false;
            this.DeleteButton.Location = new System.Drawing.Point(239, 138);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 24);
            this.DeleteButton.TabIndex = 0;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(239, 176);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 24);
            this.CancelButton.TabIndex = 0;
            this.CancelButton.Text = "Cancel";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(208, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dictionary Title:";
            // 
            // UpdateButton
            // 
            this.UpdateButton.Enabled = false;
            this.UpdateButton.Location = new System.Drawing.Point(240, 100);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 24);
            this.UpdateButton.TabIndex = 4;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // DictionaryList
            // 
            this.DictionaryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.DictionaryList.FullRowSelect = true;
            this.DictionaryList.GridLines = true;
            this.DictionaryList.Location = new System.Drawing.Point(12, 50);
            this.DictionaryList.MultiSelect = false;
            this.DictionaryList.Name = "DictionaryList";
            this.DictionaryList.ShowGroups = false;
            this.DictionaryList.ShowItemToolTips = true;
            this.DictionaryList.Size = new System.Drawing.Size(208, 152);
            this.DictionaryList.TabIndex = 8;
            this.DictionaryList.UseCompatibleStateImageBehavior = false;
            this.DictionaryList.View = System.Windows.Forms.View.Details;
            this.DictionaryList.SelectedIndexChanged += new System.EventHandler(this.DictionaryList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Dictionaries Already Added";
            this.columnHeader1.Width = 201;
            // 
            // Dictionaries
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(327, 214);
            this.Controls.Add(this.DictionaryList);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.CancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dictionaries";
            this.ShowInTaskbar = false;
            this.Text = "Dictionaries";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                AddButton.Enabled = false;
            
            else
                AddButton.Enabled = true;
            
        }

        private void DictionaryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DictionaryList.SelectedItems.Count > 0)
            {
                EditButton.Enabled = true;
                DeleteButton.Enabled = true;
                textBox1.Text = DictionaryList.SelectedItems[0].Text;
                
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            int ID = 0;
            if (!AlreadyExist(textBox1.Text))
                if((ID=Dictionary.AlterDictionary("insert into gen_Categories(CategoryTitle) values('"+textBox1.Text+"')",true))>0)
                {
                    Dictionary.ds.Tables["Categories"].Rows.Add(ID, textBox1.Text);
                    Dictionary.ds.Tables["Categories"].AcceptChanges();
                    RefreshDicts();
                    AddDictionaryView(ID, textBox1.Text);
                    UpdateCategoriesList();
                    
                }
            

        }
        private void UpdateCategoriesList()
        {
            Dictionary.CategoryIDs = new int[Dictionary.ds.Tables["Categories"].Rows.Count];
            
			for(int i=0;i<Dictionary.ds.Tables["Categories"].Rows.Count;i++)
                Dictionary.CategoryIDs[i] = (int)Dictionary.ds.Tables["Categories"].Rows[i].ItemArray[0];
			
        }
        private bool AlreadyExist(string DictTitle)
        {
            for (int i = 0; i < DictionaryList.Items.Count; i++)
                if (DictionaryList.Items[i].Text == DictTitle)
                    return true;
            return false;


        }
        public void AddDictionaryView(int ID,string Title)
        {
            DataTable dt = new DataTable("Dictionaries");
            dt = Dictionary.ds.Tables["Dictionaries"].Clone();
            

            TabPage tp = new TabPage();

            tp.Text = Title;
            tp.Name = "Tab Page";

            tp.Tag = ID;
            dg = new DataGridView();

            dg.Dock = DockStyle.Fill;
            dg.Location = new Point(8, 8);
            dg.Size = new Size(408, 224);
            dg.TabIndex = 0;
            dg.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            dg.SelectionChanged += new EventHandler(AM.DataGridViewChange);

            CreateGridStyles(dg);

            dg.DataSource = dt;
            //MessageBox.Show("Still Alive " + dg.Rows.Count);

            tp.UseVisualStyleBackColor = true;
            tp.AutoScroll = true;
            dg.BackgroundColor = tp.BackColor;


            tp.Size = new System.Drawing.Size(400, 200);
            
            
            tp.Controls.Add(dg);

            AM.tabControl1.Controls.Add(tp);


        }
        public void CreateGridStyles(DataGridView dg)
        {

            dg.EnableHeadersVisualStyles = true;
            dg.RowHeadersVisible = false;
            this.dg.AllowUserToAddRows = false;
            this.dg.AllowUserToDeleteRows = false;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.ReadOnly = true;
            dg.MultiSelect = false; ;

            dg.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            DataGridViewCellStyle style = new DataGridViewCellStyle();


            dg.DefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue;
            dg.DefaultCellStyle.DataSourceNullValue = "";
            dg.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Blue;
            dg.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            dg.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            DataGridViewTextBoxColumn word = new DataGridViewTextBoxColumn();
            word.HeaderText = "Word";

            word.DataPropertyName = "UserWord";

            word.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            word.ReadOnly = true;
            word.SortMode = DataGridViewColumnSortMode.NotSortable;
            DataGridViewTextBoxColumn shtcut = new DataGridViewTextBoxColumn();
            shtcut.HeaderText = "ShortCut";

            shtcut.DataPropertyName = "Shortcut";

            shtcut.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            shtcut.ReadOnly = true;
            shtcut.SortMode = DataGridViewColumnSortMode.NotSortable;
            DataGridViewTextBoxColumn repl = new DataGridViewTextBoxColumn();
            repl.HeaderText = "Replacement Text";

            repl.DataPropertyName = "Replacement";

            repl.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            repl.ReadOnly = true;
            repl.SortMode = DataGridViewColumnSortMode.NotSortable;



            //dg.AlternatingRowsDefaultCellStyle = style;

            //            dg.DefaultCellStyle = style;
            dg.BorderStyle = BorderStyle.Fixed3D;
            dg.ScrollBars = ScrollBars.Both;

            DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
            id.DataPropertyName = "UserWordID";

            DataGridViewTextBoxColumn cat = new DataGridViewTextBoxColumn();
            cat.DataPropertyName = "CategoryID";

            dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;



            dg.Columns.AddRange(new DataGridViewColumn[] { word, shtcut, repl, id, cat });


            dg.Columns[3].Visible = false;
            dg.Columns[4].Visible = false;



        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you really want to delete","Confirmation",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
            if ((Dictionary.AlterDictionary("delete from gen_Categories where CategoryID=" + (int)DictionaryList.SelectedItems[0].Tag,false))>0)
            {
               
                Dictionary.ds.Tables["Categories"].Rows.Find((int)DictionaryList.SelectedItems[0].Tag).Delete();
                Dictionary.ds.Tables["Categories"].AcceptChanges();

                AM.DelTab((int)DictionaryList.SelectedItems[0].Tag);
                
                
                //DictionaryList.SelectedItems[0].Remove();
                RefreshDicts();

            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            UpdateButton.Enabled = true;
            EditButton.Enabled = false;
            AddButton.Enabled = false;
            DeleteButton.Enabled = false;
            textBox1.Select(0, textBox1.Text.Length);
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if ((Dictionary.AlterDictionary("update gen_Categories set CategoryTitle='" + textBox1.Text + "' where CategoryID=" + (int)DictionaryList.SelectedItems[0].Tag, false)) > 0)
            {

                Dictionary.ds.Tables["Categories"].Rows.Find((int)DictionaryList.SelectedItems[0].Tag)[1]=textBox1.Text;
                Dictionary.ds.Tables["Categories"].AcceptChanges();

                AM.UpdateTab((int)DictionaryList.SelectedItems[0].Tag,textBox1.Text);
                textBox1.Focus();
                textBox1.Text = "";
                EditButton.Enabled = true;
                UpdateButton.Enabled = false;
                AddButton.Enabled = true;
                DeleteButton.Enabled = true;
                //DictionaryList.SelectedItems[0].Remove();
                RefreshDicts();
            }
            
        }

        

	}
}
