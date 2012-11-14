using System;
using System.Collections.Generic;
using System.Text;

using EnvDTE;
using EnvDTE80;

namespace ASEExpertVS2005.Sample
{
    /// <summary>
    /// This is class realize ASEExpertVS2005.Plugin interface
    /// </summary>
    public class Main : ASEExpertVS2005.Plugin
    {
        /// <summary>
        /// Name command for add in IDE commands
        /// 
        /// FullCommand name is:
        ///  "ASEExpertVS2005.Connect.ASEExpertVS2005_" + CommandName
        /// 
        /// For this CommandName:
        ///  "ASEExpertVS2005.Connect.ASEExpertVS2005_Sample"
        /// </summary>
        public string CommandName
        {
            get { return "Sample"; }
        }
        /// <summary>
        /// Caption on menu button for this command
        /// </summary>
        public string Caption
        {
            get { return "Sample"; }
        }
        /// <summary>
        /// Description for this command
        /// </summary>
        public string Description
        {
            get { return "Sample"; }
        }
        /// <summary>
        /// Toolbar for command
        /// 
        /// Toolbar must be format (coma separated):
        ///  parent.subparent.subsubparent.MyBar
        /// 
        /// For this Toolbar in main menu "Tools" will be created 
        /// submenu "ASE_Expert_VS2005_Tool_Popup"
        /// </summary>
        public string Toolbar
        {
            get { return "Tools.ASE_Expert_VS2005_Tool_Popup"; }
        }
        /// Caption of toolbar for command
        /// 
        /// Caption of toolbar must be format (coma separated):
        ///  parent.subparent.subsubparent.MyBar
        /// 
        /// For this Toolbar in main menu "Tools" 
        /// sesubmenu "ASE_Expert_VS2005_Tool_Popup"
        /// be have caption "ASE Expert 2005"
        public string ToolbarName
        {
            get { return "Tools.ASE Expert 2005"; }
        }
        /// <summary>
        /// Position command in menu
        /// ASE Expert can change position:
        /// - ASE Expert loaded plugins sort by plugin name
        /// - after ASE Expert load all plugin ASE Expert sort list by Position value
        /// - after ASE Expert add Command by order
        /// </summary>
        public int Position
        {
            get { return 5; }
        }
        /// <summary>
        /// Key binding 
        /// Sample:
        ///  "Text Editor::Alt+G"
        ///  "Global::Ctrl+F12"
        /// </summary>
        public string Bindings
        {
            get { return ""; }
        }
        /// <summary>
        /// Image for command in menu
        /// Image must be:
        /// - bitmap
        /// - 16x16
        /// - 16bit or 24bit
        /// - transparent color is 0,254,0
        /// </summary>
        public System.Drawing.Bitmap Image
        {
            get 
            {
                return new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("ASEExpertVS2005.Sample.icon.bmp")); 
            }
        }
        /// <summary>
        /// Called on execute command
        /// </summary>
        /// <param name="executeOption">See MSDN</param>
        /// <param name="varIn">See MSDN</param>
        /// <param name="varOut">See MSDN</param>
        /// <param name="handled">See MSDN</param>
        public void Execute(vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
        {
            System.Windows.Forms.MessageBox.Show("Hello from Sample plugin for ASE Expert VS2005.\r\nCurrent Solution: " + IDE.ApplicationObject.Solution.FullName);
        }

        /// <summary>
        /// Called on get info about command state
        /// </summary>
        /// <param name="neededText">See MSDN</param>
        /// <param name="status">See MSDN</param>
        /// <param name="commandText">See MSDN</param>
        /// <returns>See MSDN</returns>
        public bool ComandState(vsCommandStatusTextWanted neededText, ref vsCommandStatus status, ref object commandText)
        {
            return false;
        }
    }
}
