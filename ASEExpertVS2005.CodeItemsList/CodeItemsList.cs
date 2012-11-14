using System;
using System.Collections.Generic;
using System.Text;

using EnvDTE;
using EnvDTE80;

namespace ASEExpertVS2005.CodeItemsList
{
    public class CodeItemsList : ASEExpertVS2005.Plugin
    {
        public string CommandName
        {
            get { return "CodeItems"; }
        }

        public string Caption
        {
            get { return "Show code items"; }
        }

        public string Description
        {
            get { return "Show dialog with code items"; }
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
            get { return 2; }
        }

        public string Bindings
        {
            get { return "Text Editor::Alt+G"; }
        }

        public System.Drawing.Bitmap Image
        {
            get
            {
                return new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("ASEExpertVS2005.CodeItemsList.icon.bmp"));
            }
        }

        private FmCodeItems fmCodeItems = new FmCodeItems();
        public void Execute(vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
        {
            fmCodeItems.DoDialog();
        }

        public bool ComandState(vsCommandStatusTextWanted neededText, ref vsCommandStatus status, ref object commandText)
        {
            commandText = Caption;

            if (IDE.ApplicationObject.ActiveDocument != null)
                commandText = Caption + " [" + IDE.ApplicationObject.ActiveDocument.Name + "]";

            return false;
        }
    }
}
