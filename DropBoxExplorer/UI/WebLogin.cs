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

            // Run background test to check we have connectivity to dropbox url
            workerTest.RunWorkerAsync();
        }

        private void workerTest_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                _Authorization = new DropboxAuthorization();

                System.Net.WebRequest myRequest = System.Net.WebRequest.Create(_Authorization.URI);
                System.Net.WebResponse myResponse = myRequest.GetResponse();

                e.Result = null;
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        private void workerTest_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            // If test was successful then navigate browser to dropbox login url
            if (e.Result == null)
            {
                browser.Navigate(_Authorization.URI);
            }
            else
            {
                ErrorPanel.ShowError(this, e.Result as Exception);
            }
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
                ErrorPanel.ShowError(this, ex);
            }
        }
    }
}