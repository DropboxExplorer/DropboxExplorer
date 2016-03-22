/* Copyright 2016 dropboxexplorer.com

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DropboxExplorer
{
    /// <summary>
    /// Wraps all calls to the Windows API
    /// </summary>
    internal static class WinAPI
    {
        #region File association icons
        private const uint SHGFI_ICON = 0x100;
        private const uint SHGFI_SMALLICON = 0x1;

        private const uint SHIL_EXTRALARGE = 0x2;
        private const int SHIL_JUMBO = 0x4;

        private const uint SHGFI_USEFILEATTRIBUTES = 0x10;
        private const uint SHGFI_SYSICONINDEX = 0x4000;
        private const uint FILE_ATTRIBUTE_NORMAL = 0x80;
        #region Types

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public static implicit operator System.Drawing.Point(POINT p)
            {
                return new System.Drawing.Point(p.X, p.Y);
            }

            public static implicit operator POINT(System.Drawing.Point p)
            {
                return new POINT(p.X, p.Y);
            }
        }

        [Serializable, StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public RECT(int left_, int top_, int right_, int bottom_)
            {
                Left = left_;
                Top = top_;
                Right = right_;
                Bottom = bottom_;
            }

            public int Height { get { return Bottom - Top; } }
            public int Width { get { return Right - Left; } }
            public Size Size { get { return new Size(Width, Height); } }

            public Point Location { get { return new Point(Left, Top); } }

            // Handy method for converting to a System.Drawing.Rectangle
            public Rectangle ToRectangle()
            { return Rectangle.FromLTRB(Left, Top, Right, Bottom); }

            public static RECT FromRectangle(Rectangle rectangle)
            {
                return new RECT(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
            }

            public override int GetHashCode()
            {
                return Left ^ ((Top << 13) | (Top >> 0x13))
                  ^ ((Width << 0x1a) | (Width >> 6))
                  ^ ((Height << 7) | (Height >> 0x19));
            }

            #region Operator overloads

            public static implicit operator Rectangle(RECT rect)
            {
                return rect.ToRectangle();
            }

            public static implicit operator RECT(Rectangle rect)
            {
                return FromRectangle(rect);
            }

            #endregion
        }

        #pragma warning disable 649
        private struct IMAGELISTDRAWPARAMS
        {
            public int cbSize;
            public IntPtr himl;
            public int i;
            public IntPtr hdcDst;
            public int x;
            public int y;
            public int cx;
            public int cy;
            public int xBitmap;        // x offest from the upperleft of bitmap
            public int yBitmap;        // y offset from the upperleft of bitmap
            public int rgbBk;
            public int rgbFg;
            public int fStyle;
            public int dwRop;
            public int fState;
            public int Frame;
            public int crEffect;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct IMAGEINFO
        {
            public IntPtr hbmImage;
            public IntPtr hbmMask;
            public int Unused1;
            public int Unused2;
            public RECT rcImage;
        }

        [ComImportAttribute()]
        [GuidAttribute("46EB5926-582E-4017-9FDF-E8998DAA0950")]
        [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        //helpstring("Image List"),
        interface IImageList
        {
            [PreserveSig]
            int Add(
                IntPtr hbmImage,
                IntPtr hbmMask,
                ref int pi);

            [PreserveSig]
            int ReplaceIcon(
                int i,
                IntPtr hicon,
                ref int pi);

            [PreserveSig]
            int SetOverlayImage(
                int iImage,
                int iOverlay);

            [PreserveSig]
            int Replace(
                int i,
                IntPtr hbmImage,
                IntPtr hbmMask);

            [PreserveSig]
            int AddMasked(
                IntPtr hbmImage,
                int crMask,
                ref int pi);

            [PreserveSig]
            int Draw(
                ref IMAGELISTDRAWPARAMS pimldp);

            [PreserveSig]
            int Remove(
            int i);

            [PreserveSig]
            int GetIcon(
                int i,
                int flags,
                ref IntPtr picon);

            [PreserveSig]
            int GetImageInfo(
                int i,
                ref IMAGEINFO pImageInfo);

            [PreserveSig]
            int Copy(
                int iDst,
                IImageList punkSrc,
                int iSrc,
                int uFlags);

            [PreserveSig]
            int Merge(
                int i1,
                IImageList punk2,
                int i2,
                int dx,
                int dy,
                ref Guid riid,
                ref IntPtr ppv);

            [PreserveSig]
            int Clone(
                ref Guid riid,
                ref IntPtr ppv);

            [PreserveSig]
            int GetImageRect(
                int i,
                ref RECT prc);

            [PreserveSig]
            int GetIconSize(
                ref int cx,
                ref int cy);

            [PreserveSig]
            int SetIconSize(
                int cx,
                int cy);

            [PreserveSig]
            int GetImageCount(
            ref int pi);

            [PreserveSig]
            int SetImageCount(
                int uNewCount);

            [PreserveSig]
            int SetBkColor(
                int clrBk,
                ref int pclr);

            [PreserveSig]
            int GetBkColor(
                ref int pclr);

            [PreserveSig]
            int BeginDrag(
                int iTrack,
                int dxHotspot,
                int dyHotspot);

            [PreserveSig]
            int EndDrag();

            [PreserveSig]
            int DragEnter(
                IntPtr hwndLock,
                int x,
                int y);

            [PreserveSig]
            int DragLeave(
                IntPtr hwndLock);

            [PreserveSig]
            int DragMove(
                int x,
                int y);

            [PreserveSig]
            int SetDragCursorImage(
                ref IImageList punk,
                int iDrag,
                int dxHotspot,
                int dyHotspot);

            [PreserveSig]
            int DragShowNolock(
                int fShow);

            [PreserveSig]
            int GetDragImage(
                ref POINT ppt,
                ref POINT pptHotspot,
                ref Guid riid,
                ref IntPtr ppv);

            [PreserveSig]
            int GetItemFlags(
                int i,
                ref int dwFlags);

            [PreserveSig]
            int GetOverlayImage(
                int iOverlay,
                ref int piIndex);
        };
        #endregion

        private struct SHFILEINFO
        {
            // Handle to the icon representing the file
            public IntPtr hIcon;
            // Index of the icon within the image list
            public int iIcon;
            // Various attributes of the file
            public uint dwAttributes;
            // Path to the file
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string szDisplayName;
            // File type
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };

        [DllImport("Shell32.dll")]
        private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, int cbFileInfo, uint uFlags);

        [DllImport("shell32.dll", EntryPoint = "#727")]
        private extern static int SHGetImageList(uint iImageList, ref Guid riid, out IImageList ppv);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool DestroyIcon(IntPtr hIcon);

        /// <summary>
        /// Gets the 16x16 icon for a file
        /// </summary>
        /// <param name="path">The file to get the icon for</param>
        /// <returns>the file icon</returns>
        internal static Bitmap GetFileSmallIcon(string path)
        {
            return GetFileIcon(path, SHGFI_SMALLICON);
        }

        /// <summary>
        /// Gets the 32x32 icon for a file
        /// </summary>
        /// <param name="path">The file to get the icon for</param>
        /// <returns>the file icon</returns>
        internal static Bitmap GetFileLargeIcon(string path)
        {
            return GetFileIcon(path, SHGFI_ICON);
        }

        private static Bitmap GetFileIcon(string path, uint size)
        {
            Bitmap bmp = null;

            SHFILEINFO info = new SHFILEINFO();
            IntPtr icon = SHGetFileInfo(path, 0, ref info, Marshal.SizeOf(info), SHGFI_ICON | SHGFI_USEFILEATTRIBUTES | size);

            using (Icon ico = System.Drawing.Icon.FromHandle(info.hIcon))
            {
                bmp = ico.ToBitmap();
            }

            DestroyIcon(info.hIcon);

            return bmp;
        }

        /// <summary>
        /// Gets the 48x48 icon for a file
        /// </summary>
        /// <param name="path">The file to get the icon for</param>
        /// <returns>the file icon</returns>
        internal static Bitmap GetFileExtraLargeIcon(string path)
        {
            return GetFileLargeIcon(path, SHIL_EXTRALARGE);
        }

        /// <summary>
        /// Gets the 256x256 icon for a file
        /// </summary>
        /// <param name="path">The file to get the icon for</param>
        /// <returns>the file icon</returns>
        internal static Bitmap GetFileJumboIcon(string path)
        {
            return GetFileLargeIcon(path, SHIL_JUMBO);
        }

        private static Bitmap GetFileLargeIcon(string path, uint size)
        {
            Bitmap bmp = null;

            SHFILEINFO shinfo = new SHFILEINFO();
            var res = SHGetFileInfo(path, FILE_ATTRIBUTE_NORMAL, ref shinfo, Marshal.SizeOf(shinfo), SHGFI_SYSICONINDEX | SHGFI_USEFILEATTRIBUTES);

            Guid iidImageList = new Guid("46EB5926-582E-4017-9FDF-E8998DAA0950");

            IImageList iml;
            var hres = SHGetImageList(size, ref iidImageList, out iml);

            IntPtr hIcon = IntPtr.Zero;
            int ILD_TRANSPARENT = 1;
            hres = iml.GetIcon(shinfo.iIcon, ILD_TRANSPARENT, ref hIcon);

            using (Icon ico = System.Drawing.Icon.FromHandle(hIcon))
            {
                bmp = ico.ToBitmap();
            }

            DestroyIcon(hIcon);

            return bmp;
        }
        #endregion

        #region File types
        [Flags]
        private enum AssocF : uint
        {
            None = 0,
            Init_NoRemapCLSID = 0x1,
            Init_ByExeName = 0x2,
            Open_ByExeName = 0x2,
            Init_DefaultToStar = 0x4,
            Init_DefaultToFolder = 0x8,
            NoUserSettings = 0x10,
            NoTruncate = 0x20,
            Verify = 0x40,
            RemapRunDll = 0x80,
            NoFixUps = 0x100,
            IgnoreBaseClass = 0x200,
            Init_IgnoreUnknown = 0x400,
            Init_FixedProgId = 0x800,
            IsProtocol = 0x1000,
            InitForFile = 0x2000,
        }

        private enum AssocStr
        {
            Command = 1,
            Executable,
            FriendlyDocName,
            FriendlyAppName,
            NoOpen,
            ShellNewValue,
            DDECommand,
            DDEIfExec,
            DDEApplication,
            DDETopic,
            InfoTip,
            QuickTip,
            TileInfo,
            ContentType,
            DefaultIcon,
            ShellExtension,
            DropTarget,
            DelegateExecute,
            SupportedUriProtocols,
            Max,
        }

        [DllImport("Shlwapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern uint AssocQueryString(AssocF flags, AssocStr str, string pszAssoc, string pszExtra, [Out] StringBuilder pszOut, ref uint pcchOut);

        /// <summary>
        /// Gets the friendly file type name for an extension
        /// </summary>
        /// <param name="doctype">The file extension prefixed with the '.'</param>
        /// <returns>The friendly file type name</returns>
        internal static string GetFileTypeName(string doctype)
        {
            if ((doctype.Length <= 1) || !doctype.StartsWith(".")) return "";

            uint pcchOut = 0;
            AssocQueryString(AssocF.Verify, AssocStr.FriendlyDocName, doctype, null, null, ref pcchOut);

            if (pcchOut == 0) return (doctype.Trim('.').ToUpper() + " File");

            StringBuilder pszOut = new StringBuilder((int)pcchOut);
            AssocQueryString(AssocF.Verify, AssocStr.FriendlyDocName, doctype, null, pszOut, ref pcchOut);
            return pszOut.ToString();
        }
        #endregion

        #region File sizes
        /// <summary>
        /// Formats a number of bytes to a friendly display format
        /// </summary>
        /// <param name="bytes">The raw size</param>
        /// <returns>The friendly size</returns>
        internal static string FormatBytes(ulong bytes)
        {
            double b = bytes;
            if (b < 1024) return b.ToString("0") + " bytes"; // Bytes
            b = b / 1024;
            if (b < 1024) return b.ToString("0.0") + " KB"; // Kilobytes
            b = b / 1024;
            if (b < 1024) return b.ToString("0.0") + " MB"; // Megabytes
            b = b / 1024;
            if (b < 1024) return b.ToString("0.0") + " GB"; // Gigabytes
            b = b / 1024;
            if (b < 1024) return b.ToString("0.0") + " TB"; // Terrabyte
            b = b / 1024;
            if (b < 1024) return b.ToString("0.0") + " PB"; // Pettabyte
            b = b / 1024;
            if (b < 1024) return b.ToString("0.0") + " EB"; // Exabyte
            b = b / 1024;
            if (b < 1024) return b.ToString("0.0") + " ZB"; // Zettabyte
            b = b / 1024;
            return b.ToString("0.0") + " YB"; // Yottabyte
        }
        #endregion

        #region ListView
        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int SetWindowTheme(IntPtr hWnd, string appName, string partList);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_CHANGEUISTATE = 0x127;
        private const int UIS_SET = 1;
        private const int UISF_HIDEFOCUS = 0x1;

        /// <summary>
        /// Configures a ListView to have the modern look
        /// </summary>
        /// <param name="listView">The ListView to configure</param>
        internal static void ConfigureListView(ListView listView)
        {
            SetWindowTheme(listView.Handle, "explorer", null);
            listView.HideSelection = true;
            SendMessage(listView.Handle, WM_CHANGEUISTATE, MakeLong(UIS_SET, UISF_HIDEFOCUS), 0);
        }

        private static int MakeLong(int wLow, int wHigh)
        {
            int low = (int)IntLoWord(wLow);
            short high = IntLoWord(wHigh);
            int product = 0x10000 * (int)high;
            int mkLong = (int)(low | product);
            return mkLong;
        }

        private static short IntLoWord(int word)
        {
            return (short)(word & short.MaxValue);
        }
        #endregion

        #region Cursors
        internal const int WM_SETCURSOR = 0x0020;
        private const int IDC_HAND = 32649;

        [DllImport("user32.dll")]
        private static extern int LoadCursor(int hInstance, int lpCursorName);

        [DllImport("user32.dll")]
        private static extern int SetCursor(int hCursor);

        internal static void SetHandCursor()
        {
            SetCursor(LoadCursor(0, IDC_HAND));
        }
        #endregion
    }
}
