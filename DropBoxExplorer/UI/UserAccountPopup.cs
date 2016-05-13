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
using System.Windows.Forms;

namespace DropboxExplorer
{
    /// <summary>
    /// Provides a popup form showing account details
    /// </summary>
    internal partial class UserAccountPopup : Form
    {
        private static UserAccountPopup _Form = null;

        internal static void ShowPopup(Rectangle parentRect, UserAccount account)
        {
            ClosePopup();

            _Form = new UserAccountPopup(account);
            _Form.Location = new Point(parentRect.Right - _Form.Width - 1, parentRect.Bottom);
            WinAPI.ShowInactiveTopmostForm(_Form);
        }

        internal static void ClosePopup()
        {
            if (_Form != null)
                _Form.Close();
        }

        public UserAccountPopup(UserAccount account)
        {
            InitializeComponent();

            picImage.Image = account.Image;
            lblUsername.Text = account.Username;
            lblEmail.Text = account.Email;
            lblLevel.Text = account.Level + " plan";
            
            this.Width = Math.Max(lblUsername.Right, Math.Max(lblEmail.Right, lblLevel.Right)) + 8;
        }
    }
}
