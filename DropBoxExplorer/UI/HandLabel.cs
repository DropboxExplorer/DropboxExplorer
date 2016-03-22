using System;
using System.Windows.Forms;

namespace DropboxExplorer
{
    internal class HandLabel : Label
    {
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WinAPI.WM_SETCURSOR)
            {
                WinAPI.SetHandCursor();
                m.Result = IntPtr.Zero;
                return;
            }
            base.WndProc(ref m);
        }
    }
}