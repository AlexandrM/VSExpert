using System;
using System.Collections.Generic;
using System.Text;

using EnvDTE;
using EnvDTE80;

namespace ASEExpertVS2005.AddProperty
{
    public class AddProperty : ASEExpertVS2005.Plugin
    {
        public string CommandName
        {
            get { return "AddProperty"; }
        }

        public string Caption
        {
            get { return "Add property"; }
        }

        public string Description
        {
            get { return "Add property"; }
        }

        public string Toolbar
        {
            get { return "Code Window.ASE_Expert_VS2005_CodeWindow_Popup"; }
        }

        public string ToolbarName
        {
            get { return "Code Window.ASE Expert 2005"; }
        }

        public int Position
        {
            get { return 1; }
        }

        public string Bindings
        {
            get { return ""; }
        }

        public System.Drawing.Bitmap Image
        {
            get 
            {
                return new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("ASEExpertVS2005.AddProperty.icon.bmp")); 
            }
        }

        private FmAddProperty fmAddProperty = new FmAddProperty();
        public void Execute(vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
        {
            fmAddProperty.ShowDialog();
        }

        public bool ComandState(vsCommandStatusTextWanted neededText, ref vsCommandStatus status, ref object commandText)
        {
            return false;
        }
    }
}
