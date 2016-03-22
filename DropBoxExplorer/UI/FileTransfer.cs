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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DropboxExplorer
{
    /// <summary>
    /// Provides a UI during a file transfer
    /// </summary>
    internal partial class FileTransfer : UserControl
    {
        // Controls the minimum time the control will be visible
        // Small files can transfer very fast and hence this control would othewrwise flicker visible and invisible
        private const int FileTransferMinTimeMS = 2000;

        public FileTransfer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Downloads a file
        /// </summary>
        /// <param name="dropboxFilePath">The file to download</param>
        /// <param name="localFilePath">The local path to save the file to</param>
        /// <returns>The result of the asynchronous operation</returns>
        internal async Task DownloadFileUI(string dropboxFilePath, string localFilePath)
        {
            try
            {
                lblAction.Text = "Downloading file";
                lblSource.Text = dropboxFilePath;
                lblDestination.Text = localFilePath;
                this.Show();
                this.BringToFront();

                DateTime timeout = DateTime.Now.AddMilliseconds(FileTransferMinTimeMS);

                using (var dropbox = new DropboxFiles())
                {
                    await dropbox.DownloadFile(dropboxFilePath, localFilePath);
                }

                while (DateTime.Now < timeout)
                {
                    System.Threading.Thread.Sleep(100);
                    Application.DoEvents();
                }
            }
            catch (Exception ex)
            {
                ErrorPanel.ShowError(this, ex);
            }
        }

        /// <summary>
        /// Uploads a file
        /// </summary>
        /// <param name="dropboxFilePath">The target location for the upload</param>
        /// <param name="localFilePath">The local file to upload</param>
        /// <returns>The result of the asynchronous operation</returns>
        internal async Task UploadFileUI(string dropboxFilePath, string localFilePath)
        {
            try
            {
                lblAction.Text = "Uploading file";
                lblSource.Text = localFilePath;
                lblDestination.Text = dropboxFilePath;
                this.Show();
                this.BringToFront();
                DateTime timeout = DateTime.Now.AddMilliseconds(FileTransferMinTimeMS);

                using (var dropbox = new DropboxFiles())
                {
                    await dropbox.UploadFile(dropboxFilePath, localFilePath);
                }

                while (DateTime.Now < timeout)
                {
                    System.Threading.Thread.Sleep(100);
                    Application.DoEvents();
                }
            }
            catch (Exception ex)
            {
                ErrorPanel.ShowError(this, ex);
            }
        }
    }
}
