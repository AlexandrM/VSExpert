using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace ASE.Expert.VS.Setup._2012
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void cbVS2005_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = (sender as CheckBox);
            if (!c.Focus())
                return;

            if (c.Checked)
                Install(int.Parse(c.Tag.ToString()));
            else
                UnInstall(int.Parse(c.Tag.ToString()));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string docs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            cbVS2005.Checked = (File.Exists(docs + @"\Visual Studio 2005\Addins\ASEExpertVS2005.AddIn"));
            cbVS2008.Checked = (File.Exists(docs + @"\Visual Studio 2008\Addins\ASEExpertVS2005.AddIn"));
            cbVS2010.Checked = (File.Exists(docs + @"\Visual Studio 2010\Addins\ASEExpertVS2005.AddIn"));
            cbVS2012.Checked = (File.Exists(docs + @"\Visual Studio 2012\Addins\ASEExpertVS2005.AddIn"));
        }

        private void UnInstall(int version)
        {
            string xmlF = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            xmlF = xmlF + String.Format(@"\Visual Studio {0}\Addins\ASEExpertVS2005.AddIn", version);

            if (File.Exists(xmlF))
                File.Delete(xmlF);
        }

        private void Install(int version)
        {
            string inF = Application.StartupPath + @"\ASEExpertVS2005.AddIn";
            string xmlF = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            xmlF = xmlF + String.Format(@"\Visual Studio {0}\Addins", version);

            if (!Directory.Exists(xmlF))
                Directory.CreateDirectory(xmlF);

            xmlF = xmlF + @"\ASEExpertVS2005.AddIn";
            File.Copy(inF, xmlF);

            XmlDocument xml = new XmlDocument();
            xml.Load(xmlF);
            if (version == 2005)
            {
                xml["Extensibility"]["HostApplication"]["Name"].InnerText = "Microsoft Visual Studio Macros";
                xml["Extensibility"]["HostApplication"]["Version"].InnerText = "8.0";
            }
            if (version == 2008)
            {
                xml["Extensibility"]["HostApplication"]["Name"].InnerText = "Microsoft Visual Studio Macros";
                xml["Extensibility"]["HostApplication"]["Version"].InnerText = "9.0";
            }
            if (version == 2010)
            {
                xml["Extensibility"]["HostApplication"]["Name"].InnerText = "Microsoft Visual Studio Macros";
                xml["Extensibility"]["HostApplication"]["Version"].InnerText = "10.0";
            }
            if (version == 2012)
            {
                xml["Extensibility"]["HostApplication"]["Name"].InnerText = "Microsoft Visual Studio";
                xml["Extensibility"]["HostApplication"]["Version"].InnerText = "11.0";
            }

            xml["Extensibility"]["Addin"]["Assembly"].InnerText = Application.StartupPath + @"\ASEExpertVS2005.dll";
            xml.Save(xmlF);
        }
    }
}
