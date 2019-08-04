using System;
using System.Text;
using System.Data;
using System.Collections.Specialized;
namespace RSH.TypoExpander
{
	/// <summary>
	/// Summary description for ProgKeys.
	/// </summary>
	public class ProgKeys
	{
		public static bool IsCtrlPressed;
		public static bool IsAltPressed;
		public static bool IsShiftPressed;
		public static string CurrentKeys;
		public static char ckeychar;
        public static string[] keys = { "{Insert}","{Home}","{PgUp}",
                                "{PgDown}","{End}","{Delete}",
                                "{Backspace}","{Tab}","{Up}",
                                "{Down}","{Left}","{Right}",
                                "{Space}","{Esc}","{Pause/Break}",
						//"{Ctrl}","{Alt}","{Shift}",
                        "{F1}","{F2}","{F3}",
                        "{F4}","{F5}","{F6}",
                        "{F7}","{F8}","{F9}",
                        "{F10}","{F11}","{F12}",
					"~", "`", "1", "2", "3", "4", "5",
                             "6", "7", "8", "9", "0", "-", "_", 
                                "=", "+", "[", "]", "{", "}", ";", 
                                ":", "'", "\"", "\\", "|", ",", "<", 
                                ".", ">","/","?","(",")","*","&",
                                "^","%","$","#","@","!"};
        public static string[] values = { "Insert","Home","PageUp",
                                "PageDown","End","Delete",
                                "Backspace","Tab","CursorUp",
                                "CursorDown","CursorLeft","CursorRight",
                                "Space","Escape","Pausekey",
					//"Ctrl","Alt","Shift",
                    "F1","F2","F3",
                        "F4","F5","F6",
                        "F7","F8","F9",
                        "F10","F11","F12",
					"Tilde", "BackTick", "D1", "D2", "D3", "D4", "D5",
                         	   "D6", "D7", "D8", "D9", "D0", "Hyphen", "Underscore", 
                                "Equals", "Plus", "OpenBracket", "CloseBracket", "OpenBrace", "CloseBrace", "SemiColon", 
                                "Colon", "Apostrophe", "Quotes", "Backslash", "Pipe", "Comma", "LessThan", 
                                "Period", "GreaterThan","Slash","Question","OpenParentheses","CloseParentheses","Asterisk","Ampersand",
                                "Caret","Percent","Dollar","Pound","AtSign","Exclamation"};
		static ProgKeys()
		{
			IsCtrlPressed=false;
			IsAltPressed=false;
			IsShiftPressed=false;
			CurrentKeys="";
			ckeychar='A';
		}
        public static StringDictionary GetKeyToValueTable()
        {
            StringDictionary sd = new StringDictionary();
            
            for (int i = 0; i < keys.Length; i++)
              sd.Add(keys[i], values[i]);
            
            return sd;
        }
	}
}
