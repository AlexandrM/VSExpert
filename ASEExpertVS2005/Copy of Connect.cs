using System;
using Extensibility;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.CommandBars;
using System.Resources;
using System.Reflection;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Collections;
using System.Reflection.Emit;
using System.Drawing;

//using ASE.VS.Core;
//using ASEExpertVS2005.Actions;

namespace ASEExpertVS2005
{
	/// <summary>The object for implementing an Add-in.</summary>
	/// <seealso class='IDTExtensibility2' />
	public class Connect : IDTExtensibility2, IDTCommandTarget
	{
        /// <summary>Implements the OnConnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being loaded.</summary>
		/// <param term='application'>Root object of the host application.</param>
		/// <param term='connectMode'>Describes how the Add-in is being loaded.</param>
		/// <param term='addInInst'>Object representing this Add-in.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
		{
            string[] files = System.IO.Directory.GetFiles(IDE.LibPath, "*.dll");

            if (IDE.plugins.Count == 0)
            {
                AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

                AssemblyName asn = new AssemblyName("ASEExpertVS2005.resources");
                asn.CultureInfo = new CultureInfo("en-US");
                AssemblyBuilder asb = AppDomain.CurrentDomain.DefineDynamicAssembly(asn,
                    AssemblyBuilderAccess.Save, IDE.LibPath + "en-US\\");

                ModuleBuilder myModuleBuilder = asb.DefineDynamicModule("ASEExpertVS2005.resources.dll", "ASEExpertVS2005.resources.dll");

                IResourceWriter rw = null;
                try
                {
                    rw = myModuleBuilder.DefineResource("ResourceUI.resources", "My Description", ResourceAttributes.Public);
                }
                catch (Exception exc)
                {
                    IDE.Debug("OnConnection <DefineResource>!! ", exc);
                }
                int resourceID = 0;

                foreach (string file in files)
                {
                    try
                    {
                        Assembly asm = Assembly.LoadFile(file);
                        Type[] types = asm.GetTypes();

                        foreach (Type type in types)
                        {
                            TypeFilter myFilter = new TypeFilter(MyInterfaceFilter);
                            Type[] myInterfaces = type.FindInterfaces(myFilter, "ASEExpertVS2005.Plugin");


                            if (myInterfaces.Length != 0)
                            {
                                Plugin plugin = (Plugin)Activator.CreateInstance(type);
                                IDE.plugins.Add(plugin);
                                Bitmap bmp = null;
                                try
                                {
                                    bmp = plugin.Image;
                                }
                                catch { }

                                if (bmp != null)
                                {
                                    resourceID++;
                                    rw.AddResource(resourceID.ToString(), bmp);
                                    IDE.pluginsImages.Add(plugin, resourceID);
                                }
                            }
                        }
                    }
                    catch (Exception exc)
                    {
                        IDE.Debug("OnConnection <Load plugin>!! ", exc);
                    }
                }
                try
                {
                    AssemblyName sn = new AssemblyName(Assembly.GetExecutingAssembly().FullName);
                    asb.DefineVersionInfoResource("ASEExpertVS2005", sn.Version.ToString(), "", "", "");
                    asb.Save("ASEExpertVS2005.resources.dll");
                    rw.Close();
                }
                catch (Exception exc)
                {
                    IDE.Debug("OnConnection <Save resource assembly>!! ", exc);
                }
            }
 		}
	}
}