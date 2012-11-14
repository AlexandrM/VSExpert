using System;
using System.Collections.Generic;
using System.Text;

using EnvDTE;
using EnvDTE80;

using ASEExpertVS2005;

namespace ASEExpertVS2005.CodeKeeper
{
    public class Keep : ASEExpertVS2005.Plugin
    {
        #region Plugin Members

        public string CommandName
        {
            get { return "KeepSelection"; }
        }

        public string Caption
        {
            get { return "Keep code"; }
        }

        public string Description
        {
            get { return "Keep selected text to database"; }
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
                return new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("ASEExpertVS2005.CodeKeeper.iconKeep.bmp"));
            }
        }

        public void Execute(EnvDTE.vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
        {
            TextSelection selection = (TextSelection)IDE.ApplicationObject.ActiveDocument.Selection;
            if (selection == null) 
                return;

            ASEExpertVS2005.CodeKeeper.FmMain.DoDialog(selection.Text);
        }

        public bool ComandState(EnvDTE.vsCommandStatusTextWanted neededText, ref EnvDTE.vsCommandStatus status, ref object commandText)
        {
            TextSelection selection = (TextSelection)IDE.ApplicationObject.ActiveDocument.Selection;
            status = vsCommandStatus.vsCommandStatusUnsupported;
            if (selection == null)
                return true;
            else if (selection.Text == "")
                return true;

            return false;
        }

        #endregion
    }
}
