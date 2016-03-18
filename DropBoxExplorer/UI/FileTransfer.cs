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
                lblTransfer.Text = string.Format("Downloading file '{0}'\r\n\r\nTo '{1}'", dropboxFilePath, localFilePath);
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
                ErrorPanel.ShowError(this, "A problem occurred downloading the file.", ex);
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
                lblTransfer.Text = string.Format("Uploading file '{0}'\r\n\r\nTo 'Dropbox{1}'", localFilePath, dropboxFilePath);
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
                ErrorPanel.ShowError(this, "A problem occurred uploading the file.", ex);
            }
        }
    }
}
