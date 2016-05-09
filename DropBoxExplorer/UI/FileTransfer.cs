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
using System.IO;
using System.Threading;
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
        
        private CancellationTokenSource _cancellationTokenSource = null;

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
                lblAction.Text = "Downloading:";
                lblFileName.Text = Path.GetFileName(localFilePath);
                lblSource.Text = Path.GetDirectoryName(dropboxFilePath);
                lblDestination.Text = Path.GetDirectoryName(localFilePath);
                this.Show();
                this.BringToFront();

                DateTime timeout = DateTime.Now.AddMilliseconds(FileTransferMinTimeMS);
                _cancellationTokenSource = new CancellationTokenSource();

                using (var dropbox = new DropboxFiles())
                {
                    dropbox.FileTransferProgress += Dropbox_FileTransferProgress;
                    await dropbox.DownloadFile(dropboxFilePath, localFilePath, _cancellationTokenSource.Token);
                }

                _cancellationTokenSource = null;

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
        internal async Task UploadFileUI(string dropboxFilePath, string localFilePath, bool overwrite)
        {
            try
            {
                lblAction.Text = "Uploading:";
                lblFileName.Text = Path.GetFileName(localFilePath);
                lblSource.Text = Path.GetDirectoryName(localFilePath);
                lblDestination.Text = dropboxFilePath.Substring(0, dropboxFilePath.Length - lblFileName.Text.Length);
                this.Show();
                this.BringToFront();
                DateTime timeout = DateTime.Now.AddMilliseconds(FileTransferMinTimeMS);
                _cancellationTokenSource = new CancellationTokenSource();

                using (var dropbox = new DropboxFiles())
                {
                    dropbox.FileTransferProgress += Dropbox_FileTransferProgress;
                    await dropbox.UploadFile(dropboxFilePath, localFilePath, overwrite, _cancellationTokenSource.Token);
                }

                _cancellationTokenSource = null;

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
        /// Cancels any pending transfer
        /// </summary>
        internal void Cancel()
        {
            try
            {
                // Rather than locking across threads, we'll just ignore any null errors
                _cancellationTokenSource.Cancel();
            }
            catch { }
        }

        private void Dropbox_FileTransferProgress(object sender, DropboxFiles.FileTransferProgressArgs e)
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(() => { UpdateProgress(e); }));
            else
                UpdateProgress(e);
        }

        private void UpdateProgress(DropboxFiles.FileTransferProgressArgs e)
        {
            progress.Value = e.Percentage;
            lblRemaining.Text = e.Remaining;
        }

        private void FileTransfer_Resize(object sender, EventArgs e)
        {
            const int MAX_WIDTH = 400;

            // Fit within parent to maximum width
            tableLayoutPanel1.Width = Math.Min(this.Width, MAX_WIDTH);

            // Make sure controls are centered due to being unreliable with font scalling in Windows
            tableLayoutPanel1.Left = (this.Width - tableLayoutPanel1.Width) / 2;
        }
    }
}
