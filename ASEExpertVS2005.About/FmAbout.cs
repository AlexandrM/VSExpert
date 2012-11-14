using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ASEExpertVS2005.About
{
    public partial class FmAbout : Form
    {
        public FmAbout()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FmAbout_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "Version: " + IDE.Version.ToString();
            foreach(ASEExpertVS2005.Plugin plugin in IDE.Plugins)
                lwPlugins.Items.Add(new ListViewItem(new string[] { plugin.Caption, plugin.Bindings, plugin.Description }, -1));
        }

        [DllImport("shell32.dll")]
        static extern IntPtr ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShellExecute(this.Handle, "open", linkLabel1.Text, "", "", 5);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShellExecute(this.Handle, "open", linkLabel2.Text, "", "", 5);
        }
    }
}