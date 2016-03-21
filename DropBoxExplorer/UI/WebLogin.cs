/*
Copyright 2016 dropboxexplorer.com

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
    /// Provides functionality to Login to Dropbox and obtain an AccessCode
    /// </summary>
    internal partial class WebLogin : UserControl
    {
        private DropboxAuthorization _Authorization = null;
        
        /// <summary>
        /// The control has authenticated the user with Dropbox
        /// </summary>
        public event EventHandler<EventArgs> Authenticated;

        public WebLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialises the control by navigating to the Dropbox login page
        /// </summary>
        internal void Initialise()
        {
            busyIcon1.Show();
            _Authorization = new DropboxAuthorization();
            browser.Navigate(_Authorization.URI);
        }

        private void browser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (!string.IsNullOrEmpty(DropboxAuthorization.AccessToken))
                return;

            busyIcon1.Hide();
            browser.Show();
            
            if (!e.Url.ToString().StartsWith(Configuration.DropboxAuthorizationUrl, StringComparison.OrdinalIgnoreCase))
            {
                // we need to ignore all navigation that isn't to the redirect uri.
                browser.Focus();
                return;
            }
            
            try
            {
                if (_Authorization.Validate(e.Url))
                {
                    Authenticated(this, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                ErrorPanel.ShowError(this, "Unable to login to Dropbox", ex);
            }
        }
    }
}