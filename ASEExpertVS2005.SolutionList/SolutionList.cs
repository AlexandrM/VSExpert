using System;
using System.Collections.Generic;
using System.Text;

using EnvDTE;
using EnvDTE80;

namespace ASEExpertVS2005.SolutionList
{
    /// <summary>
    /// ��������� Plugin
    /// </summary>
    public class SolutionList : ASEExpertVS2005.Plugin
    {
        /// <summary>
        /// ���������� ��� ������� � VS
        /// </summary>
        public string CommandName
        {
            get { return "SolutionItems"; }
        }
        /// <summary>
        /// ���������� ��� toolbar � ������� ����� �������� ����� ����
        /// </summary>
        public string Toolbar
        {
            get { return "Tools.ASE_Expert_VS2005_Tool_Popup"; }
        }
        /// <summary>
        /// ����� ��������� toolbar
        /// </summary>
        public string ToolbarName
        {
            get { return "Tools.ASE Expert 2005"; }
        }
        /// <summary>
        /// ����� ������ ����
        /// </summary>
        public string Caption
        {
            get { return "Show solution items"; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string Description
        {
            get { return "Show dialog with solution items"; }
        }
        /// <summary>
        /// ������� � toolbar
        /// </summary>
        public int Position
        {
            get { return 1; }
        }
        /// <summary>
        /// ����������� ��� ������ ����
        /// </summary>
        public System.Drawing.Bitmap Image
        {
            get 
            {
                return new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("ASEExpertVS2005.SolutionList.icon.bmp")); 
            }
        }

        /// <summary>
        /// ������� �������
        /// </summary>
        public string Bindings
        {
            get { return "Global::Ctrl+F12"; }
        }

        private FmList fmList = new FmList();
        /// <summary>
        /// ������ ��������
        /// </summary>
        /// <param name="executeOption"></param>
        /// <param name="varIn"></param>
        /// <param name="varOut"></param>
        /// <param name="handled"></param>
        public void Execute(vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
        {
            fmList.DoDialog();
        }

        public bool ComandState(vsCommandStatusTextWanted neededText, ref vsCommandStatus status, ref object commandText)
        {
            return false;
        }
    }
}
