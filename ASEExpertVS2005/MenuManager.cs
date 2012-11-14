using System;
using Extensibility;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.CommandBars;
using System.Resources;
using System.Reflection;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Collections;
using System.IO;
using System.Drawing;

namespace ASEExpertVS2005
{
    public class MenuManager
    {

        public delegate void ExecuteComand(vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled);
        public delegate void ComandState(vsCommandStatusTextWanted neededText, ref vsCommandStatus status, ref object commandText);

        public static string GetLocalizeName(string name)
        {
            try
            {
                if (IDE.ApplicationObject.Version == "10.0")
                {
                    return name;
                }
                else
                {
                    ResourceManager resourceManager = new ResourceManager("ASEExpertVS2005.CommandBar", Assembly.GetExecutingAssembly());
                    CultureInfo cultureInfo = new System.Globalization.CultureInfo(IDE.ApplicationObject.LocaleID);
                    string ret = resourceManager.GetString(String.Concat(cultureInfo.TwoLetterISOLanguageName, name));
                    if (ret != null)
                        name = ret;
                }
            }
            catch(Exception exc)
            {
                IDE.Debug("GetLocalizeName!! " + name, exc);
            }

            return name;
        }

        private static Hashtable commands = new Hashtable();

        public static void InitCommand(
            string name, 
            string caption, 
            string description,
            string toolbar, 
            int position, 
            string bindings, 
            int imageIndex,
            ExecuteComand mExecute, 
            ComandState mState, 
            bool create,
            string[] names)
        {
            IDE.Debug("InitCommand " + name);
            try
            {
                CreateCommand(name, caption, description, bindings, imageIndex);
                InitCommandInMenus(caption, name, toolbar, position, names);
            }
            catch (Exception exc)
            {
                IDE.Debug("InitCommand!! " , exc);
            }
        }

        public static void CreateCommand(string name, string caption, string description, string bindings, int imageIndex)
        {
            IDE.Debug("CreateCommand " + name);
            try
            {
                Command cmd = null;
                try
                {
                    cmd = IDE.Commands.Item(IDE.AddInInstance.ProgID + "." + name, -1);
                }
                catch(Exception exc)
                {
                    IDE.Debug("CreateCommand", exc, name);
                }
                if (cmd != null)
                    return;

                object[] contextGUIDS = new object[] { };

                Command command = IDE.Commands.AddNamedCommand2(IDE.AddInInstance, name, caption, description, false, imageIndex, ref contextGUIDS,
                   (int)vsCommandStatus.vsCommandStatusSupported + 
                   (int)vsCommandStatus.vsCommandStatusEnabled + 
                   (int)vsCommandStatusTextWanted.vsCommandStatusTextWantedStatus,
                    3, 
                    vsCommandControlType.vsCommandControlTypeButton);

                if (bindings != "")
                    command.Bindings = bindings;
            }
            catch (Exception exc)
            {
                IDE.Debug("CreateCommand!! " , exc);
            }
        }

        public static void InitCommandBarPopup(string name, string caption, string parent, int position)
        {
            try
            {
                if (IDE.ApplicationObject.Version == "10.01")
                {
                }
                else
                {
                    CommandBarPopup temporaryCommandBarPopup = (CommandBarPopup)((CommandBars)IDE.ApplicationObject.CommandBars)[parent].Controls.Add(MsoControlType.msoControlPopup,
                        System.Type.Missing, System.Type.Missing, position, true);

                    temporaryCommandBarPopup.CommandBar.Name = name;
                    temporaryCommandBarPopup.Caption = caption;
                    temporaryCommandBarPopup.Visible = true;
                }
            }
            catch (Exception exc)
            {
                IDE.Debug("InitCommandBarPopup!! " , exc);
            }
        }

        [ComImport,
          Guid("6D5140C1-7436-11CE-8034-00AA006009FA"),
          InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IOleServiceProvider
        {
            [PreserveSig]
            int QueryService([In]ref Guid guidService, [In]ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out System.Object obj);
        }

        public static void InitCommandInMenus(string caption, string name, string toolbar, int position, string[] names)
        {
            IDE.Debug("InitCommandInMenus " + name);
            try
            {
                Command cmd = IDE.Commands.Item(IDE.AddInInstance.ProgID + "." + name, -1);
                object bar = null;
                if (IDE.ApplicationObject.Version == "9.0")
                {
                    bar = ((CommandBars)IDE.ApplicationObject.CommandBars)[toolbar];
                    cmd.AddControl(bar, position);
                }
                if ((IDE.ApplicationObject.Version == "10.0") || (IDE.ApplicationObject.Version == "11.0"))
                {
                    for (int i = 0; i < names.Length; i++)
                    {
                        if (bar == null)
                            bar = ((CommandBars)IDE.ApplicationObject.CommandBars)[names[i]];
                        else
                            bar = (bar as CommandBar).Controls[names[i]];
                    }
                    cmd.AddControl((bar as CommandBarPopup).CommandBar, position);
                }
            }
            catch (Exception exc)
            {
                IDE.Debug("InitCommandInMenus!! " , exc);
            }
        }

        [DllImport("oleaut32.dll", CharSet = CharSet.Unicode, PreserveSig = true, EntryPoint = "OleLoadPictureFile")]
        static extern void _OleLoadPictureFile(object file, [MarshalAs(UnmanagedType.IDispatch)] out object picture);

        public static stdole.StdPicture LoadPicture(string file)
        {
            object picture = null;
            _OleLoadPictureFile((object)file, out picture);
            return (stdole.StdPicture)picture;
        }

        [DllImport("olepro32.dll", PreserveSig = false)]
        public static extern void OleCreatePictureIndirect(ref PICTDESC pPictDesc, ref Guid riid, bool fOwn, out stdole.StdPicture ppvObj);

        [DllImport("comctl32.dll", PreserveSig = false)]
        private static extern long CreateMappedBitmap(ref long hInstance, ref long idBitmap, ref long wFlags, System.Drawing.Imaging.ColorMap lpColorMap, ref long iNumMaps);

        public static stdole.StdPicture LoadPictureRes(string name)
        {
            Bitmap bmp = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream(name));
            //for (int i = 0; i < bmp.Palette.Entries.Length; i++ )
                //bmp.Palette.Entries[i] = Color.FromArgb(0, 254, 0);

            //CreateMappedBitmap(IDE.AddInInstance, BMP_ID, 0, g_map, 1)

            PICTDESC pPictDesc = new PICTDESC(bmp);
            Guid riid = new Guid("7BF80980-BF32-101A-8BBB-00AA00300CAB");
            stdole.StdPicture ppvObj = null;
            OleCreatePictureIndirect(ref pPictDesc, ref riid, true, out ppvObj);

            bmp.Dispose();
            return ppvObj;
        }

        public struct PICTDESC
        {
            int cbSizeOfStruct;
            int picType;
            IntPtr hbitmap;
            IntPtr hpalette;
            int unused;

            public PICTDESC(Bitmap bmp)
            {
                this.cbSizeOfStruct = Marshal.SizeOf(typeof(PICTDESC));
                this.picType = 1;
                this.hpalette = IntPtr.Zero;
                this.unused = 0;
                this.hbitmap = bmp.GetHbitmap();
            }
        }

        /*
        public static void SetTabPicture(Window toolWindow, Bitmap toolWindowPicture)
        {
            if (toolWindow == null)
                throw new ArgumentNullException("toolWindow");

            if (toolWindowPicture == null)
                throw new ArgumentNullException("toolWindowPicture");

            Guid riid = new Guid("7BF80980-BF32-101A-8BBB-00AA00300CAB");
            PICTDESC pPictDesc = new PICTDESC(toolWindowPicture);
            IPictureDisp ppvObj = null;
            OlePro32.OleCreatePictureIndirect(ref pPictDesc, ref riid, true, out ppvObj);
            toolWindow.SetTabPicture(ppvObj);
        }*/
    }
}
