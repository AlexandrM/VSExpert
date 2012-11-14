using System;
using System.Collections.Generic;
using System.Text;

using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.CommandBars;

namespace ASEExpertVS2005
{
    public interface Plugin
    {
        string CommandName
        {
            get;
        }

        string Caption
        {
            get;
        }
        
        string Description
        {
            get;
        }
        
        string Toolbar
        {
            get;
        }

        string ToolbarName
        {
            get;
        }
        
        int Position
        {
            get;
        }
        
        string Bindings
        {
            get;
        }

        System.Drawing.Bitmap Image
        {
            get;
        }

        void Execute(vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled);

        bool ComandState(vsCommandStatusTextWanted neededText, ref vsCommandStatus status, ref object commandText);
    }
}
