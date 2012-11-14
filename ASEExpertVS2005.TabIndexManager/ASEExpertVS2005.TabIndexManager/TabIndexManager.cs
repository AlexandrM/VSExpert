using System;
using System.Collections.Generic;
using System.Text;

using EnvDTE;
using EnvDTE80;

namespace ASEExpertVS2005.TabIndexManager
{
    public class TabIndexManager: ASEExpertVS2005.Plugin
    {
        #region Plugin Members

        public string Bindings
        {
            get { return ""; }
        }

        public string Caption
        {
            get { return "Tab Index manager"; }
        }

        public bool ComandState(EnvDTE.vsCommandStatusTextWanted neededText, ref EnvDTE.vsCommandStatus status, ref object commandText)
        {
            return false;
        }

        public string CommandName
        {
            get { return "TabIndexManager"; }
        }

        public string Description
        {
            get { return "Form 'Tab Index' manager"; }
        }

        public void Execute(EnvDTE.vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
        {
            FmMain.DoDialog();
        }

        public System.Drawing.Bitmap Image
        {
            get { return null; }
        }

        public int Position
        {
            get { return 0; }
        }

        public string Toolbar
        {
            get 
            {
                return "Container"; 
            }
        }

        public string ToolbarName
        {
            get { return "Container"; ; }
        }

        #endregion
    }
}
