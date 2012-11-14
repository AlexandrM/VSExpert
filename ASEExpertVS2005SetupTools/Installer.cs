using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.IO;
using System.Reflection;

using System.Security.Principal;
using System.Security.AccessControl;

namespace ASEExpertVS2005SetupTools
{
    [RunInstaller(true)]
    public partial class MyInstaller : Installer
    {
        public MyInstaller()
        {
            InitializeComponent();

            this.AfterInstall += new InstallEventHandler(MyInstaller_AfterInstall);
            this.AfterUninstall += new InstallEventHandler(MyInstaller_AfterUninstall);
        }

        void MyInstaller_AfterUninstall(object sender, InstallEventArgs e)
        {
            StringBuilder path = new StringBuilder(260);
            SHGetSpecialFolderPath(IntPtr.Zero, path, 5, false);

            string p_addin2005 = path.ToString() + @"\Visual Studio 2005\Addins\ASEExpertVS2005.AddIn";
            string p_addin2008 = path.ToString() + @"\Visual Studio 2008\Addins\ASEExpertVS2005.AddIn";
            string p_addin2010 = path.ToString() + @"\Visual Studio 2010\Addins\ASEExpertVS2005.AddIn";

            if (File.Exists(p_addin2005))
                File.Delete(p_addin2005);
            if (File.Exists(p_addin2008))
                File.Delete(p_addin2008);
            if (File.Exists(p_addin2010))
                File.Delete(p_addin2010);

            try
            {
                Directory.Delete(this.Context.Parameters["path"], true);
            }
            catch//(Exception exc)
            {
                //System.Windows.Forms.MessageBox.Show(exc.Message + exc.InnerException + exc);
            }
        }

        void MyInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            StringBuilder path = new StringBuilder(260);
            SHGetSpecialFolderPath(IntPtr.Zero, path, 5, false);

            string p_addinOrg = this.Context.Parameters["path"] + @"ASEExpertVS2005.AddIn";
            string p_addin2005 = path.ToString() + @"\Visual Studio 2005\Addins\ASEExpertVS2005.AddIn";
            string p_addin2008 = path.ToString() + @"\Visual Studio 2008\Addins\ASEExpertVS2005.AddIn";
            string p_addin2010 = path.ToString() + @"\Visual Studio 2010\Addins\ASEExpertVS2005.AddIn";
            string p_dll = this.Context.Parameters["path"] + "ASEExpertVS2005.dll";
            XmlDocument xd;
            XmlNode node;

            try
            {
                if (this.Context.Parameters["cboxval1"].ToString() == "1")
                {
                    if (!Directory.Exists(path.ToString() + @"\Visual Studio 2005\Addins\"))
                        Directory.CreateDirectory(path.ToString() + @"\Visual Studio 2005\Addins");

                    if (File.Exists(p_addin2005))
                        File.Delete(p_addin2005);

                    System.IO.File.Copy(p_addinOrg, p_addin2005);
                    xd = new XmlDocument();
                    xd.Load(p_addin2005);
                    node = xd["Extensibility"]["Addin"]["Assembly"];
                    node.InnerText = p_dll;
                    xd.Save(p_addin2005);
                }
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show("Exception #1: " + exc.Message);
            }
            
            try
            {
                if (this.Context.Parameters["cboxval2"].ToString() == "1")
                {
                    if (!Directory.Exists(path.ToString() + @"\Visual Studio 2008\Addins\"))
                        Directory.CreateDirectory(path.ToString() + @"\Visual Studio 2008\Addins");

                    if (File.Exists(p_addin2008))
                        File.Delete(p_addin2008);

                    System.IO.File.Copy(p_addinOrg, p_addin2008);
                    xd = new XmlDocument();
                    xd.Load(p_addin2008);
                    node = xd["Extensibility"]["Addin"]["Assembly"];
                    node.InnerText = p_dll;
                    foreach (XmlNode item in xd["Extensibility"].ChildNodes)
                        if (item.Name == "HostApplication")
                            item["Version"].InnerText = "9.0";
                    xd.Save(p_addin2008);
                }
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show("Exception #2: " + exc.Message);
            }

            try
            {
                if (this.Context.Parameters["cboxval3"].ToString() == "1")
                {
                    if (!Directory.Exists(path.ToString() + @"\Visual Studio 2010\Addins\"))
                        Directory.CreateDirectory(path.ToString() + @"\Visual Studio 2010\Addins");

                    if (File.Exists(p_addin2010))
                        File.Delete(p_addin2010);

                    System.IO.File.Copy(p_addinOrg, p_addin2010);
                    xd = new XmlDocument();
                    xd.Load(p_addin2010);
                    node = xd["Extensibility"]["Addin"]["Assembly"];
                    node.InnerText = p_dll;
                    foreach (XmlNode item in xd["Extensibility"].ChildNodes)
                        if (item.Name == "HostApplication")
                            item["Version"].InnerText = "10.0";
                    xd.Save(p_addin2010);
                }
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show("Exception #3: " + exc.Message);
            }

            try
            {
                Assembly asm = Assembly.LoadFile(p_dll);

                string csp = File.ReadAllText(this.Context.Parameters["path"] + @"ASEExpertVS2005.Sample\ASEExpertVS2005.Sample.csproj", Encoding.UTF8);
                csp = csp.Replace("ASEExpertVS2005, Version=1.0.2904.23426", "ASEExpertVS2005, Version=" + asm.GetName().Version.ToString());
                csp = csp.Replace(@"<HintPath>..\ASEExpertVS2005\bin\ASEExpertVS2005.dll</HintPath>",
                    "<HintPath>" + p_dll + "</HintPath>");

                File.WriteAllText(this.Context.Parameters["path"] + @"ASEExpertVS2005.Sample\ASEExpertVS2005.Sample.csproj", csp, Encoding.UTF8);
                //<Reference Include="ASEExpertVS2005, Version=1.0.2904.23426, Culture=neutral, processorArchitecture=MSIL">
                //  <SpecificVersion>False</SpecificVersion>
                //  <HintPath>..\..\..\Program Files\ASE\ASE Expert VS2005\ASEExpertVS2005.dll</HintPath>
                //</Reference>

                DirectorySecurity ds = new DirectorySecurity();
                FileSystemAccessRule ar = new FileSystemAccessRule(
                    Environment.UserName, 
                    FileSystemRights.FullControl, 
                    AccessControlType.Allow);

                ds.SetAccessRule(ar);
                System.IO.Directory.CreateDirectory(this.Context.Parameters["path"] + "en-US", ds);

                FileSecurity fs = new FileSecurity();
                fs.SetAccessRule(ar);
                FileStream fsm = File.Create(this.Context.Parameters["path"] + "user.config", 1, FileOptions.None, fs);
                fsm.Close();
                StreamWriter tw = new StreamWriter(this.Context.Parameters["path"] + "user.config");
                tw.WriteLine("<ASE.Tools.XmlIni>");
                tw.WriteLine("  <Plugins>");
                tw.WriteLine("  </Plugins>");
                tw.WriteLine("</ASE.Tools.XmlIni>");
                tw.Close();
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show("Exception #4: " + exc.Message);
            }
        }

        [DllImport("shell32.dll")]
        static extern bool SHGetSpecialFolderPath(IntPtr hwndOwner, [Out] StringBuilder lpszPath, int nFolder, bool fCreate);
    }
}