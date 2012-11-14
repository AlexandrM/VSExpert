using System;
using System.Collections.Generic;
using System.Text;

using EnvDTE;
using EnvDTE80;

namespace ASEExpertVS2005.About
{
    public class Main : ASEExpertVS2005.Plugin
    {
        public string CommandName
        {
            get { return "About"; }
        }

        public string Caption
        {
            get { return "About ASE Expert VS2005"; }
        }

        public string Description
        {
            get { return "Show dialog about ASE Expert VS2005"; }
        }

        public string Toolbar
        {
            get { return "Tools.ASE_Expert_VS2005_Tool_Popup"; }
        }

        public string ToolbarName
        {
            get { return "Tools.ASE Expert 2005"; }
        }

        public int Position
        {
            get { return 4; }
        }

        public string Bindings
        {
            get { return ""; }
        }

        public System.Drawing.Bitmap Image
        {
            get
            {
                return new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("ASEExpertVS2005.About.icon.bmp"));
            }
        }

        private FmAbout fmAbout = new FmAbout();
        public void Execute(vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
        {
            fmAbout.ShowDialog();
        }

        public bool ComandState(vsCommandStatusTextWanted neededText, ref vsCommandStatus status, ref object commandText)
        {
            return false;
        }
    }
}
