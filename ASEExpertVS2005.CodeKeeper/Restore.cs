using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using EnvDTE;
using EnvDTE80;

using ASEExpertVS2005;

namespace ASEExpertVS2005.CodeKeeper
{
    class Restore: ASEExpertVS2005.Plugin
    {
        #region Plugin Members

        public string CommandName
        {
            get { return "RestoreCode"; }
        }

        public string Caption
        {
            get { return "Restore code"; }
        }

        public string Description
        {
            get { return "Restore code"; }
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
            get { return 2; }
        }

        public string Bindings
        {
            get { return ""; }
        }

        public System.Drawing.Bitmap Image
        {
            get
            {
                return new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("ASEExpertVS2005.CodeKeeper.iconRestore.bmp"));
            }
        }

        public void Execute(EnvDTE.vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
        {
            if (FmMain.DoDialog("") == DialogResult.OK)
            {
                (IDE.ApplicationObject.ActiveDocument.Selection as TextSelection).Text = FmMain.Code;
            }
        }

        public bool ComandState(EnvDTE.vsCommandStatusTextWanted neededText, ref EnvDTE.vsCommandStatus status, ref object commandText)
        {
            return false;
        }

        #endregion
    }
}
