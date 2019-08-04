namespace RSH.TypoExpander
{
    partial class Chains
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ChainedList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.RestList = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.AddToChain = new System.Windows.Forms.Button();
            this.AddAll = new System.Windows.Forms.Button();
            this.RemoveAll = new System.Windows.Forms.Button();
            this.RemoveChain = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // ChainedList
            // 
            this.ChainedList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.ChainedList.FullRowSelect = true;
            this.ChainedList.GridLines = true;
            this.ChainedList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ChainedList.Location = new System.Drawing.Point(259, 10);
            this.ChainedList.MultiSelect = false;
            this.ChainedList.Name = "ChainedList";
            this.ChainedList.ShowGroups = false;
            this.ChainedList.ShowItemToolTips = true;
            this.ChainedList.Size = new System.Drawing.Size(176, 242);
            this.ChainedList.TabIndex = 0;
            this.ChainedList.UseCompatibleStateImageBehavior = false;
            this.ChainedList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Dictionaries Already In Chains";
            this.columnHeader1.Width = 172;
            // 
            // RestList
            // 
            this.RestList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.RestList.FullRowSelect = true;
            this.RestList.GridLines = true;
            this.RestList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.RestList.Location = new System.Drawing.Point(12, 10);
            this.RestList.MultiSelect = false;
            this.RestList.Name = "RestList";
            this.RestList.ShowGroups = false;
            this.RestList.ShowItemToolTips = true;
            this.RestList.Size = new System.Drawing.Size(176, 242);
            this.RestList.TabIndex = 1;
            this.RestList.UseCompatibleStateImageBehavior = false;
            this.RestList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Dictionaries Available for Chains";
            this.columnHeader2.Width = 172;
            // 
            // AddToChain
            // 
            this.AddToChain.BackColor = System.Drawing.Color.AliceBlue;
            this.AddToChain.Font = new System.Drawing.Font("Wingdings 2", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.AddToChain.Location = new System.Drawing.Point(203, 10);
            this.AddToChain.Name = "AddToChain";
            this.AddToChain.Size = new System.Drawing.Size(45, 45);
            this.AddToChain.TabIndex = 2;
            this.AddToChain.Text = "E";
            this.AddToChain.UseVisualStyleBackColor = false;
            this.AddToChain.Click += new System.EventHandler(this.AddToChain_Click);
            // 
            // AddAll
            // 
            this.AddAll.BackColor = System.Drawing.Color.AliceBlue;
            this.AddAll.Font = new System.Drawing.Font("Wingdings 3", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.AddAll.Location = new System.Drawing.Point(203, 61);
            this.AddAll.Name = "AddAll";
            this.AddAll.Size = new System.Drawing.Size(45, 45);
            this.AddAll.TabIndex = 3;
            this.AddAll.Text = "[";
            this.AddAll.UseVisualStyleBackColor = false;
            this.AddAll.Click += new System.EventHandler(this.AddAll_Click);
            // 
            // RemoveAll
            // 
            this.RemoveAll.BackColor = System.Drawing.Color.AliceBlue;
            this.RemoveAll.Font = new System.Drawing.Font("Wingdings 3", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.RemoveAll.Location = new System.Drawing.Point(203, 207);
            this.RemoveAll.Name = "RemoveAll";
            this.RemoveAll.Size = new System.Drawing.Size(45, 45);
            this.RemoveAll.TabIndex = 4;
            this.RemoveAll.Text = "\\";
            this.RemoveAll.UseVisualStyleBackColor = false;
            this.RemoveAll.Click += new System.EventHandler(this.RemoveAll_Click);
            // 
            // RemoveChain
            // 
            this.RemoveChain.BackColor = System.Drawing.Color.AliceBlue;
            this.RemoveChain.Font = new System.Drawing.Font("Wingdings 2", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.RemoveChain.Location = new System.Drawing.Point(203, 156);
            this.RemoveChain.Name = "RemoveChain";
            this.RemoveChain.Size = new System.Drawing.Size(45, 45);
            this.RemoveChain.TabIndex = 5;
            this.RemoveChain.Text = "D";
            this.RemoveChain.UseVisualStyleBackColor = false;
            this.RemoveChain.Click += new System.EventHandler(this.RemoveChain_Click);
            // 
            // Chains
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(447, 263);
            this.Controls.Add(this.RemoveChain);
            this.Controls.Add(this.RemoveAll);
            this.Controls.Add(this.AddAll);
            this.Controls.Add(this.AddToChain);
            this.Controls.Add(this.RestList);
            this.Controls.Add(this.ChainedList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Chains";
            this.Text = "Chains";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ChainedList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView RestList;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button AddToChain;
        private System.Windows.Forms.Button AddAll;
        private System.Windows.Forms.Button RemoveAll;
        private System.Windows.Forms.Button RemoveChain;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}