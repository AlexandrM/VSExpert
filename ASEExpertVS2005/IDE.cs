using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using EnvDTE;
using EnvDTE80;
using Extensibility;

#if VS2003
 using Microsoft.Office.Core;
#elif VS2005
 using Microsoft.VisualStudio.CommandBars;
#endif

namespace ASEExpertVS2005
{
	/// <summary>
	/// Summary description for IDE.
	/// </summary>
	public class IDE
	{
        internal static AddIn _addInInstance = null;
        public static AddIn AddInInstance
        {
            get
            {
                return _addInInstance;
            }
        }

#if VS2003
        internal static _DTE _applicationObject = null;
        public static _DTE ApplicationObject
        {
            get
            {
                return _applicationObject;
            }
        }
#elif VS2005
        internal static DTE2 _applicationObject = null;
        public static DTE2 ApplicationObject
        {
            get
            {
                return _applicationObject;
            }
        }
#endif
        internal static string _libPath = "";
        public static string LibPath
        {
            get
            {
                return _libPath;
            }
        }

        public static CommandBars CommandBars
        {
            get
            {
                return (IDE.ApplicationObject.CommandBars as CommandBars);
            }
        }

        public static Commands2 Commands
        {
            get
            {
                return (Commands2) ApplicationObject.Commands;
            }
        }

        internal static List<ASEExpertVS2005.Plugin> plugins = new List<ASEExpertVS2005.Plugin>();
        public static List<ASEExpertVS2005.Plugin> Plugins
        {
            get
            {
                return plugins;
            }
        }

        internal static Hashtable pluginsImages = new Hashtable();
        
        private static AssemblyName assemblyName = new AssemblyName(Assembly.GetExecutingAssembly().FullName);

        public static Version Version
        {
            get
            {
                return assemblyName.Version;
            }
        }

        public static void Debug(object value)
        {
            Debug(value, null, null);
        }

        public static void Debug(object value, Exception exc)
        {
            Debug(value, exc, null);
        }

        public static void Debug(object value, Exception exc, object data)
        {
            try
            {
                if (!System.IO.File.Exists(LibPath + "debug.st"))
                    return;

                string s = value.ToString();
                if (data != null)
                    s = s + " " + data.ToString();
                if (exc != null)
                    s = s + " " + exc.Message + exc.InnerException + exc;

                StreamWriter sw = new StreamWriter(LibPath + "debug.log", true);
                sw.WriteLine("[" + DateTime.Now.ToString() + "] " + s);
                sw.Close();
            }
            catch
            {
            }
        }
    }
}
