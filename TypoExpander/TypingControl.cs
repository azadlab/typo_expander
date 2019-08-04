using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using MiniTools.UI.Input;

namespace RSH.TypoExpander
{
    class TypingControl
    {
        private const string c_DesktopWindows = "Desktop Windows";
        public static AppMain Appmain;
        private static string m_CommandText;
        private static MtMacro m_Macro;                               

        public static void RefreshWindows(AppMain AM)
        {
            Appmain = AM;
            AM.ListView_Windows.Items.Clear();
            
            TreeNode parentNode = new TreeNode(c_DesktopWindows);


            AddWindowsToList(parentNode, MtWindow.OpenWindows);
        }

        private static void AddWindowsToList(TreeNode parentNode, MtWindow[] windows)
        {
            if (windows != null)
            {
                foreach (MtWindow window in windows)
                {
                    string text = window.Text;
                    if (text == null || text.Length == 0)
                        text = String.Format("[{0}]", window.ClassName);

                    ListViewItem li = new ListViewItem(text);
                    li.Tag = window;
                    Appmain.ListView_Windows.Items.Add(li);
                }
            }
        }

        private static ListViewItem SelectedWindowItem
        {
            get
            {
                ListViewItem selectedItem = null;
                // if there are any items selected in the list view
                if (Appmain.ListView_Windows.SelectedItems.Count > 0)
                {
                    // we only care about the first selected item
                    selectedItem = Appmain.ListView_Windows.SelectedItems[0];
                }
                return selectedItem;
            }
            set
            {
                Appmain.ListView_Windows.SelectedItems[0].Tag = value;
            }
        }
        private static MtWindow SelectedWindow
        {
            get
            {
                MtWindow selectedWindow = null;
                TreeNode selectedNode = null;

                // if the list view has a selected item, use that
                ListViewItem selectedItem = SelectedWindowItem;

                // if we didn't get our selected node from the list view
                /*if (selectedNode == null)
                    // just grab it from the tree view
                    selectedNode = this.SelectedWindowNode;
                */
                // if we have a selected node
                if (selectedItem != null)
                {
                    // the tag should be a reference to the associated window
                    object obj = selectedItem.Tag;
                    if (obj != null && obj is MtWindow)
                        selectedWindow = (MtWindow)obj;
                }

                return selectedWindow;
            }
            set
            {
                SelectWindow(Appmain.ListView_Windows.Items[Appmain.ListView_Windows.SelectedIndices[0]], value);
            }
        }

        private static bool SelectWindow(ListViewItem node, MtWindow window)
        {
            bool selected = false;
            if (node != null)
            {
                object obj = node.Tag;
                if (obj != null && obj is MtWindow)
                {
                    MtWindow nodeWindow = (MtWindow)obj;
                    if (window.Handle == nodeWindow.Handle)
                    {
                        Appmain.ListView_Windows.Items[Appmain.ListView_Windows.SelectedIndices[0]].Tag = node;
                        selected = true;
                    }
                }

                
            }
            return selected;
        }

        public static void SendInput(string TextToSend,string WordOrShortcut,bool IsShortcut)
        {
            MtWindow selectedWindow = SelectedWindow;
            if (selectedWindow == null)
            {
                MessageBox.Show("Please select a window to receive input.",
                    "No Window Selected");
            }
            else if (!selectedWindow.IsValid)
            {
                MessageBox.Show(
                    "The selected window no longer exists.\nClick the \"Refresh\" button and select another window.",
                    "Selected Window Closed");
            }
            else
            {

                string commandText;
                if(IsShortcut)
                    commandText = TextToSend;
                else
                commandText = "{Backspace:" + (WordOrShortcut.Length + 1) + "}" + TextToSend;

                if ((int)AppSettings.AppOptions["AutoInsertSpace"] == 1)
                    commandText += "{Space}";
                if (commandText != null)
                    commandText = commandText.Trim();
                if (commandText == null || commandText.Length == 0)
                {
                    MessageBox.Show("Please enter text or commands to send.",
                        "No Input to Send");
                }
                else
                {
                    // if the user changed the command text
                    if (String.Compare(m_CommandText, commandText) != 0)
                    {
                        // create a new macro
                        
                        m_Macro = new MtMacro(commandText);
                       
                    }

                    try
                    {
                        // execute the macro
                        m_Macro.CapsLockOff = true;
                        m_Macro.Execute(selectedWindow, false);
                        
                        
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("An exception occurred:\n" + e.Message,
                            "Execution Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
           
                    // add this command to the history
                    // this.AddToSendHistory(this.m_CommandText);
                }
            }
        }

        public static void ProcessAndSend(Dictionary dct,bool IsShortcut,AppMain AM)
        {
            try
            {

                AM.Ghook.Enabled = false;

                ArrayList subs;
                string Word="";
                if (dct.word != "")
                    Word = dct.word;
                subs = dct.SubString();

                VariableInput vi = new VariableInput();

                subs = vi.GetVariableInput(subs, dct.GetVariableCount(subs), AM);
                subs = dct.GetValues(subs);
                string finalstring = dct.ReplaceMainString(subs, dct.replacement);

                Thread.Sleep(200);
                
                if(IsShortcut)
                    TypingControl.SendInput(finalstring,dct.shortcut,true);
                else
                TypingControl.SendInput(finalstring, Word,false);



                AM.Ghook.Enabled = true;

            }
            catch (Exception e) { MessageBox.Show("Error Sending the Input to Desired Application","Error In Sending",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }
        
    }

    
}
