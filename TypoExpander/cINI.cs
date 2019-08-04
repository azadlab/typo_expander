/*==============================================================================================================
AejW.com - INI Handler
----------------------
Build:			0017
Author:			Adam ej Woods
Modified:		21/02/2004
Ownership:		Copyright (c)2004 Adam ej Woods
Source:			http://www.aejw.com/
EULA:			In no way can this class be disturbed without my permission, this means reposting on a
				web site, cdrom, or any other form of media. The code can be used for commercial or
				personal purposes, as long as credit is given to the author. The header (this information)
				can not be modified or removed. www.CodeProject.com has permission to disturbe this class.
==============================================================================================================*/
using System;
using System.Text;
using System.Runtime.InteropServices;

namespace aejw.Ini
{
	public class cIni
	{
		[DllImport("kernel32", SetLastError=true)] private static extern int WritePrivateProfileString(string psSection, string psKey, string psValue, string psFile);		
		[DllImport("kernel32", SetLastError=true)] private static extern int GetPrivateProfileString(string psSection, string psKey, string psDefault, byte[] psrReturn, int piBufferLen, string psFile);

		private string lsIniFilename;
		private int liBufferLen = 255;		

		/// <summary>
		/// Declare INI Class
		/// </summary>
		public cIni(string psIniFilename)
		{
			lsIniFilename = psIniFilename;
		}

		/// <summary>
		/// INI Path and Filename
		/// </summary>
		public string IniFile
		{
			get{return lsIniFilename;}
			set{lsIniFilename=value;}
		}

		/// <summary>
		/// Max return length when reading data
		/// </summary>
		public int BufferLen
		{
			get{return liBufferLen;}
			set{liBufferLen=value;}
		}

		/// <summary>
		/// Read value from INI File
		/// </summary>
		public string ReadValue(string psSection, string psKey, string psDefault)
		{
			byte[] sGetBuffer = new byte[this.liBufferLen];
			ASCIIEncoding oAscii = new ASCIIEncoding();
			int i = GetPrivateProfileString(psSection, psKey, psDefault, sGetBuffer, this.liBufferLen, this.lsIniFilename);
			return oAscii.GetString(sGetBuffer,0,i);
		}

		/// <summary>
		/// Write value to INI File
		/// </summary>
		public void WriteValue(string psSection, string psKey, string psValue)
		{
			WritePrivateProfileString(psSection, psKey, psValue, this.lsIniFilename);			
		}

		/// <summary>
		/// Remove value from INI File
		/// </summary>
		public void RemoveValue(string psSection, string psKey)
		{
			WritePrivateProfileString(psSection, psKey, null, this.lsIniFilename);			
		}

		/// <summary>
		/// Read values in a section from INI File
		/// </summary>
		public void ReadValues(string psSection, ref Array poValues)
		{		
			byte[] sGetBuffer = new byte[this.liBufferLen];
			int i = GetPrivateProfileString(psSection, null, null, sGetBuffer, this.liBufferLen, this.lsIniFilename);			
			if(i!=0)
			{
				ASCIIEncoding oAscii = new ASCIIEncoding();			
				poValues = oAscii.GetString(sGetBuffer, 0, i-1).Split((char) 0);
			}
		}

		/// <summary>
		/// Read sections from INI File
		/// </summary>
		public void ReadSections(ref Array poSections)
		{		
			byte[] sGetBuffer = new byte[this.liBufferLen];
			int i = GetPrivateProfileString(null, null, null, sGetBuffer, this.liBufferLen, this.lsIniFilename);
			if(i!=0)
			{
				ASCIIEncoding oAscii = new ASCIIEncoding();			
				poSections = oAscii.GetString(sGetBuffer, 0, i-1).Split((char) 0);			
			}
		}

		/// <summary>
		/// Remove section from INI File
		/// </summary>
		public void RemoveSection(string psSection)
		{
			WritePrivateProfileString(psSection, null, null, this.lsIniFilename);			
		}

	}
}
