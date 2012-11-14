using System;
using System.Collections.Generic;
using System.Text;

using EnvDTE;
using EnvDTE80;

namespace ASEExpertVS2005.RebindShortcuts
{
    public class RebindShortcuts : ASEExpertVS2005.Plugin
    {
        public string CommandName
        {
            get { return "RebindShortcuts"; }
        }

        public string Caption
        {
            get { return "Rebind shortcuts to default"; }
        }

        public string Description
        {
            get { return "Rebind shortcuts to default"; }
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
            get { return 3; }
        }

        public string Bindings
        {
            get { return ""; }
        }

        public System.Drawing.Bitmap Image
        {
            get 
            {
                return new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("ASEExpertVS2005.RebindShortcuts.icon.bmp")); 
            }
        }

        public void Execute(vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
        {
            foreach(Plugin plugin in IDE.Plugins)
            {
                if (plugin.Bindings == "")
                    continue;

                Command command = IDE.Commands.Item(IDE.AddInInstance.ProgID + ".ASEExpertVS2005_" + plugin.CommandName, -1);
                command.Bindings = plugin.Bindings;
            }
        }

        public bool ComandState(vsCommandStatusTextWanted neededText, ref vsCommandStatus status, ref object commandText)
        {
            return false;
        }
    }
}
