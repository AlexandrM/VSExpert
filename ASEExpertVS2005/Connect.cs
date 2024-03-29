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
using System.IO;
using System.Security.AccessControl;

//using ASE.VS.Core;
//using ASEExpertVS2005.Actions;

namespace ASEExpertVS2005
{
	/// <summary>The object for implementing an Add-in.</summary>
	/// <seealso class='IDTExtensibility2' />
	public class Connect : IDTExtensibility2, IDTCommandTarget
	{
		/// <summary>Implements the constructor for the Add-in object. Place your initialization code within this method.</summary>
		public Connect()
		{
		}

        public static bool MyInterfaceFilter(Type typeObj, Object criteriaObj)
        {
            if (typeObj.ToString() == criteriaObj.ToString())
                return true;
            else
                return false;
        }

        private class PluginsComparer : System.Collections.Generic.IComparer<Plugin>
        {
            public int Compare(Plugin x, Plugin y)
            {
                if (x.Position < y.Position)
                    return -1;

                if (x.Position == y.Position)
                    return 0;

                return 1;
            }
        }

        /// <summary>Implements the OnConnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being loaded.</summary>
		/// <param term='application'>Root object of the host application.</param>
		/// <param term='connectMode'>Describes how the Add-in is being loaded.</param>
		/// <param term='addInInst'>Object representing this Add-in.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
		{
            try
            {
                IDE._applicationObject = (DTE2)application;
                IDE._addInInstance = (AddIn)addInInst;

                IDE._libPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).Replace(@"file:\", "") + "\\";

                AppDomain.CurrentDomain.SetupInformation.PrivateBinPath = AppDomain.CurrentDomain.SetupInformation.PrivateBinPath + ";" + IDE.LibPath;

                #region Load plugins Assembly

                IDE.plugins.Clear();
                AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

                AssemblyBuilder asb = null;
                IResourceWriter rw = null;
                int resourceID = 0;
                bool rebuildResource = false;

                string[] files = Directory.GetFiles(IDE.LibPath, "*.dll");

                if (!Directory.Exists(IDE.LibPath + "en-US"))
                    Directory.CreateDirectory(IDE.LibPath + "en-US");

                if (connectMode == ext_ConnectMode.ext_cm_UISetup)
                    rebuildResource = true;
                else if (!System.IO.File.Exists(IDE.LibPath + "en-US\\ASEExpertVS2005.resources.dll"))
                    rebuildResource = true;

                if (!rebuildResource)
                    foreach (string file in files)
                    {
                        Assembly asm = null;
                        try
                        {
                            asm = Assembly.LoadFile(file);
                        }
                        catch 
                        {
                            continue;
                        }

                        Type[] types = asm.GetTypes();

                        foreach (Type type in types)
                        {
                            TypeFilter myFilter = new TypeFilter(MyInterfaceFilter);
                            Type[] myInterfaces = type.FindInterfaces(myFilter, "ASEExpertVS2005.Plugin");

                            if (myInterfaces.Length != 0)
                                if (ASE.Xml.XmlIniStatic.ReadInt("Plugins/p_" + type, "inited", 0) == 0)
                                    rebuildResource = true;
                        }
                    }

                if (rebuildResource)
                {
                    AssemblyName asn = new AssemblyName("ASEExpertVS2005.resources");
                    asn.CultureInfo = new CultureInfo("en-US");
                    asb = AppDomain.CurrentDomain.DefineDynamicAssembly(asn,
                        AssemblyBuilderAccess.Save, IDE.LibPath + "en-US\\");

                    ModuleBuilder myModuleBuilder = asb.DefineDynamicModule("ASEExpertVS2005.resources.dll", "ASEExpertVS2005.resources.dll");

                    try
                    {
                        rw = myModuleBuilder.DefineResource("ResourceUI.resources", "My Description", ResourceAttributes.Public);
                    }
                    catch (Exception exc)
                    {
                        IDE.Debug("OnConnection <DefineResource>!! ", exc);
                    }
                }

                files = System.IO.Directory.GetFiles(IDE.LibPath, "*.dll");

                foreach (string file in files)
                {
                    try
                    {
                        Assembly asm = null;
                        try
                        {
                            asm = Assembly.LoadFile(file);
                        }
                        catch
                        {
                            continue;
                        }

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
                                catch
                                {
                                }

                                if (bmp != null)
                                {
                                    resourceID++;
                                    IDE.pluginsImages.Add(plugin, resourceID);

                                    if (rebuildResource)
                                    {
                                        rw.AddResource(resourceID.ToString(), bmp);
                                        ASE.Xml.XmlIniStatic.WriteInt("Plugins/p_" + type, "inited", resourceID);
                                    }
                                }
                                else
                                {
                                    IDE.pluginsImages.Add(plugin, 0);
                                    ASE.Xml.XmlIniStatic.WriteInt("Plugins/p_" + type, "inited", 0);
                                }
                            }
                        }
                    }
                    catch (Exception exc)
                    {
                        IDE.Debug("OnConnection <Load plugin>!! ", exc, file);
                    }
                }

                if (rebuildResource)
                {
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

                #endregion Load plugins Assembly

                IDE.plugins.Sort(new PluginsComparer());

                #region Create toolbars

                try
                {
                    #region VS2008

                    if (IDE.ApplicationObject.Version == "9.0")
                        foreach (Plugin plugin in IDE.plugins)
                        {
                            object cb = null;
                            string[] names = plugin.ToolbarName.Split('.');
                            string[] pathes = plugin.Toolbar.Split('.');
                            for (int i = 0; i < names.Length; i++)
                            {
                                try
                                {
                                    cb = ((CommandBars)IDE.ApplicationObject.CommandBars)[pathes[i]];
                                }
                                catch(Exception exc)
                                {
                                    IDE.Debug("Seek CommandBars 9.0!! " + names[i], exc);
                                    CommandBarPopup temporaryCommandBarPopup = (CommandBarPopup)(cb as CommandBar).Controls.Add(MsoControlType.msoControlPopup,
                                        System.Type.Missing, System.Type.Missing, 1, true);

                                    temporaryCommandBarPopup.CommandBar.Name = pathes[i];
                                    temporaryCommandBarPopup.Caption = names[i];
                                    temporaryCommandBarPopup.Visible = true;
                                }
                            }
                        }

                    #endregion VS2008

                    #region VS2010 2012

                    if ((IDE.ApplicationObject.Version == "10.0") || (IDE.ApplicationObject.Version == "11.0"))
                        foreach (Plugin plugin in IDE.plugins)
                        {
                            object cb = null;
                            string[] names = plugin.ToolbarName.Split('.');
                            for (int i = 0; i < names.Length; i++)
                            {
                                try
                                {
                                    if (cb == null)
                                        cb = ((CommandBars)IDE.ApplicationObject.CommandBars)[names[i]];
                                    else
                                        cb = (cb as CommandBar).Controls[names[i]];
                                }
                                catch (Exception exc)
                                {
                                    IDE.Debug(String.Format("Seek CommandBars 10.0 - 11.0!! [{0}\\{1}]", (cb as CommandBar).accName, names[i]), exc);
                                    CommandBarPopup temporaryCommandBarPopup = (CommandBarPopup)(cb as CommandBar).Controls.Add(MsoControlType.msoControlPopup,
                                        System.Type.Missing, System.Type.Missing, 1, true);

                                    temporaryCommandBarPopup.CommandBar.Name = names[i];
                                    temporaryCommandBarPopup.Caption = names[i];
                                    temporaryCommandBarPopup.Visible = true;
                                }
                            }
                        }
                    #endregion VS2010 2012
                }
                catch (Exception exc)
                {
                    IDE.Debug("OnConnection <Create toolbars>!! ", exc);
                }

                #endregion Create toolbars

                #region Create Commands

                //bool install = !ASE.Xml.XmlIniStatic.ReadBoolean("Plugins." + IDE._applicationObject.Version, "Installed", false);

                try
                {
                    Hashtable pos = new Hashtable();
                    foreach (Plugin plugin in IDE.plugins)
                    {
                        string[] pathes = plugin.Toolbar.Split('.');
                        string[] names = plugin.ToolbarName.Split('.');
                        
                        if (pos[pathes[pathes.Length - 1]] == null)
                            pos[pathes[pathes.Length - 1]] = 0;
                        if (pos[names[names.Length - 1]] == null)
                            pos[names[names.Length - 1]] = 0;

                        pos[pathes[pathes.Length - 1]] = (int)pos[pathes[pathes.Length - 1]] + 1;
                        pos[names[names.Length - 1]] = (int)pos[names[names.Length - 1]] + 1;

                        MenuManager.InitCommand(
                            "ASEExpertVS2005_" + plugin.CommandName,
                            plugin.Caption,
                            plugin.Description,
                            pathes[pathes.Length - 1],
                            (int)pos[pathes[pathes.Length - 1]],
                            plugin.Bindings,
                            (int)IDE.pluginsImages[plugin],
                            null,
                            null,
                            rebuildResource,
                            names);

                        //ASE.Xml.XmlIniStatic.WriteBoolean("Plugins." + IDE._applicationObject.Version, "Installed", true);
                    }
                }
                catch (Exception exc)
                {
                    IDE.Debug("OnConnection <Init commands>!! ", exc);
                }

                #endregion Create Commands
            }
            catch (Exception exc)
            {
                IDE.Debug("OnConnection!! ", exc);
            }
		}

        private AssemblyName mysn = new AssemblyName(Assembly.GetExecutingAssembly().FullName);

        Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            try
            {
                AssemblyName sn = new AssemblyName(args.Name);

                if (mysn.Name == sn.Name)
                    if (mysn.Version.Major == mysn.Version.Major)
                        if (mysn.Version.Minor == mysn.Version.Minor)
                            return Assembly.GetExecutingAssembly();

                if (System.IO.File.Exists(IDE.LibPath + sn.Name + ".dll"))
                    return Assembly.LoadFrom(IDE.LibPath + sn.Name + ".dll");
            }
            catch
            {
            }

            return null;
        }

		/// <summary>Implements the OnDisconnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being unloaded.</summary>
		/// <param term='disconnectMode'>Describes how the Add-in is being unloaded.</param>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom)
		{
		}

		/// <summary>Implements the OnAddInsUpdate method of the IDTExtensibility2 interface. Receives notification when the collection of Add-ins has changed.</summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />		
		public void OnAddInsUpdate(ref Array custom)
		{
		}

		/// <summary>Implements the OnStartupComplete method of the IDTExtensibility2 interface. Receives notification that the host application has completed loading.</summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnStartupComplete(ref Array custom)
		{
		}

		/// <summary>Implements the OnBeginShutdown method of the IDTExtensibility2 interface. Receives notification that the host application is being unloaded.</summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnBeginShutdown(ref Array custom)
		{
		}
		
		/// <summary>Implements the QueryStatus method of the IDTCommandTarget interface. This is called when the command's availability is updated</summary>
		/// <param term='commandName'>The name of the command to determine state for.</param>
		/// <param term='neededText'>Text that is needed for the command.</param>
		/// <param term='status'>The state of the command in the user interface.</param>
		/// <param term='commandText'>Text requested by the neededText parameter.</param>
		/// <seealso class='Exec' />
		public void QueryStatus(string commandName, vsCommandStatusTextWanted neededText, ref vsCommandStatus status, ref object commandText)
		{
            foreach (Plugin plugin in IDE.plugins)
            {
                if (commandName == IDE.AddInInstance.ProgID + ".ASEExpertVS2005_" + plugin.CommandName)
                    if (!plugin.ComandState(neededText, ref status, ref commandText))
                        if (neededText == vsCommandStatusTextWanted.vsCommandStatusTextWantedNone)
                        {
                            if (commandName.IndexOf(IDE.AddInInstance.ProgID) == 0)
                            {
                                status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                                return;
                            }
                        }
            }
		}

		/// <summary>Implements the Exec method of the IDTCommandTarget interface. This is called when the command is invoked.</summary>
		/// <param term='commandName'>The name of the command to execute.</param>
		/// <param term='executeOption'>Describes how the command should be run.</param>
		/// <param term='varIn'>Parameters passed from the caller to the command handler.</param>
		/// <param term='varOut'>Parameters passed from the command handler to the caller.</param>
		/// <param term='handled'>Informs the caller if the command was handled or not.</param>
		/// <seealso class='Exec' />
		public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
		{
			handled = false;
            foreach (Plugin plugin in IDE.plugins)
            {
                if (commandName == IDE.AddInInstance.ProgID + ".ASEExpertVS2005_" + plugin.CommandName)
                    plugin.Execute(executeOption, ref varIn, ref varOut, ref handled);
            }
		}
	}
}