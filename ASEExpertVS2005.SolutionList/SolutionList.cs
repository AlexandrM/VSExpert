using System;
using System.Collections.Generic;
using System.Text;

using EnvDTE;
using EnvDTE80;

namespace ASEExpertVS2005.SolutionList
{
    /// <summary>
    /// Наследник Plugin
    /// </summary>
    public class SolutionList : ASEExpertVS2005.Plugin
    {
        /// <summary>
        /// Уникальное имя команды в VS
        /// </summary>
        public string CommandName
        {
            get { return "SolutionItems"; }
        }
        /// <summary>
        /// Уникальное имя toolbar в котором будет размещен пункт меню
        /// </summary>
        public string Toolbar
        {
            get { return "Tools.ASE_Expert_VS2005_Tool_Popup"; }
        }
        /// <summary>
        /// Текст закгловка toolbar
        /// </summary>
        public string ToolbarName
        {
            get { return "Tools.ASE Expert 2005"; }
        }
        /// <summary>
        /// Текст пункта меню
        /// </summary>
        public string Caption
        {
            get { return "Show solution items"; }
        }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description
        {
            get { return "Show dialog with solution items"; }
        }
        /// <summary>
        /// Позиция в toolbar
        /// </summary>
        public int Position
        {
            get { return 1; }
        }
        /// <summary>
        /// Изображение для пункта меню
        /// </summary>
        public System.Drawing.Bitmap Image
        {
            get 
            {
                return new System.Drawing.Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("ASEExpertVS2005.SolutionList.icon.bmp")); 
            }
        }

        /// <summary>
        /// Горячие клавиши
        /// </summary>
        public string Bindings
        {
            get { return "Global::Ctrl+F12"; }
        }

        private FmList fmList = new FmList();
        /// <summary>
        /// Запуск комманды
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
