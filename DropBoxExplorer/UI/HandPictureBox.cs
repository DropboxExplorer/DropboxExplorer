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
using System.Windows.Forms;

namespace DropboxExplorer
{
    /// <summary>
    /// A standard picturebox with the correct system defined 'hand' cursor instead of the standard WinForms hand cursor
    /// </summary>
    internal class HandPictureBox : PictureBox
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
