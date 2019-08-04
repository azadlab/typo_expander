using System;

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

		static ProgKeys()
		{
			IsCtrlPressed=false;
			IsAltPressed=false;
			IsShiftPressed=false;
			CurrentKeys="";
			ckeychar='A';
		}
	}
}
