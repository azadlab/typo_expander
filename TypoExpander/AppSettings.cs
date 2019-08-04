using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using aejw.Ini;

namespace RSH.TypoExpander
{
    
    class AppSettings
    {
        public static Hashtable AppOptions;        
        
 private static string[] OptionTexts = { "AutoExpand",
                                 "ShowReplacementWindow",
                                 "ExpandByHotKey",
                                 "AutoInsertSpace",
                                 "SameCase",
                                 "Active|Chained|All",
                                 "SelectedDictionary",
                                  "HotKey"};
 private static string[] DefaultValues = { "1",
                                           "0",
                                           "0",
                                           "1",
                                           "1",
                                           "1",
                                           "0",
                                           "Ctrl+H"
                                           };

        AppSettings()
        {

        }
        public static void SaveDefaultOptions()
        {
            cIni IniHandle = new cIni(Application.StartupPath+"\\Settings.ini");

            for (int i = 0; i < OptionTexts.Length; i++)
                IniHandle.WriteValue("Options", OptionTexts[i], DefaultValues[i]);
            AppOptions = new Hashtable();
            SetOptions(new int[]{1,0,0,1,1,1,0},"Ctrl+H");
         
        }

        public static bool SetOptions(int[] options,string keys)
        {
            if (options.Length == OptionTexts.Length-1)
            {
                for (int i = 0; i < options.Length; i++)
                AppOptions.Add(OptionTexts[i], options[i]);
                AppOptions.Add("HotKey", keys);
                //AppOptions.Add("SelectedDictionary", selectedDictionary);
                
            }
            else
            return false;
            
            return true;
            
        }
        public static Hashtable GetOptions()
        {
            return AppOptions;
        }
        public static void SaveOptions()
        {
            
            cIni IniHandle = new cIni(Application.StartupPath + "\\Settings.ini");
            ArrayList OptionKeys = new ArrayList(AppOptions.Keys);
            for (int i = 0; i < AppOptions.Count; i++)
            IniHandle.WriteValue("Options", OptionKeys[i].ToString(), AppOptions[OptionKeys[i]].ToString());
            
        }
        public static void RetrieveOptions()
        {
            cIni IniHandle = new cIni(Application.StartupPath + "\\Settings.ini");
            
            AppOptions = new Hashtable();
            
            string val;
            for (int i = 0; i < OptionTexts.Length; i++)
            {

                val=IniHandle.ReadValue("Options", OptionTexts[i],"");
                if (i < OptionTexts.Length - 1)
                    AppOptions.Add(OptionTexts[i], int.Parse(val));
                else
                    AppOptions.Add(OptionTexts[i], val);
            }
            //MessageBox.Show(AppSettings.AppOptions["Active|Chained|All"].ToString());
        }
    }
}
