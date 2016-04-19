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
using System.Windows.Forms;
using Microsoft.Win32;

namespace DropboxExplorer.Test
{
    /// <summary>
    /// A form demonstrating how to use the Open and Save common dialogs in the different modes
    /// </summary>
    public partial class FormExample : Form
    {
        public FormExample()
        {
            InitializeComponent();

            txtDownloadFolder.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

            Configuration.DropboxAppKey = GetAppKeyFromReg();

            if (string.IsNullOrEmpty(Configuration.DropboxAppKey))
                lblAppKey.Show();
            else
                tabControl1.Show();
        }

        /// <summary>
        /// Function allows local AppKey to not be in GitHub
        /// </summary>
        /// <returns></returns>
        private static string GetAppKeyFromReg()
        {
            try
            {
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"Software\Dropbox Explorer", false);
                if (regKey != null)
                {
                    object value = regKey.GetValue("AppKey", "");
                    return value.ToString();
                }
            }
            catch { }

            return "";
        }

        #region Open Dialog - Auto Download
        private void btnDownloadFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.SelectedPath = txtDownloadFolder.Text;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    txtDownloadFolder.Text = dlg.SelectedPath;
            }
        }

        private void btnOpenDialogAutoDownload_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtDownloadFolder.Text))
            {
                using (DropboxDialogBase dlg = new OpenDropboxDialog(OpenDialogType.File))
                {
                    dlg.DownloadFolder = txtDownloadFolder.Text;
                    //dlg.Filter = "Word Documents (*.docx)|*.docx|All Files (*.*)|*.*";
                    //dlg.Filter = "Office Documents (*.docx, *.xlsx)|*.docx; *.xlsx|All Files (*.*)|*.*";

                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        MessageBox.Show(this, "File downloaded", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Directory '" + txtDownloadFolder.Text + "' doesn't exist", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Open Dialog - Manual Download
        private void btnOpenDialogManualDownload_Click(object sender, EventArgs e)
        {
            using (DropboxDialogBase dlg = new OpenDropboxDialog(OpenDialogType.File))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    txtDownloadSource.Text = dlg.SelectedFile;

                    MessageBox.Show(this, "File selected for download", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // The file can be downloaded using the DownloadSelectedFile function
                    //dlg.DownloadSelectedFile(myLocalFilePath);
                }
            }
        }
        #endregion

        #region Save Dialog - Auto Upload
        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.FileName = txtUploadFile.Text;
                dlg.InitialDirectory = txtUploadFile.Text;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    txtUploadFile.Text = dlg.FileName;
            }
        }

        private void btnSaveDialogAutoUpload_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtUploadFile.Text))
            {
                using (DropboxDialogBase dlg = new SaveDropboxDialog())
                {
                    dlg.UploadFile = txtUploadFile.Text;
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        MessageBox.Show(this, "File uploaded", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "File '" + txtUploadFile.Text + "' doesn't exist", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Save Dialog - Manual Upload
        private void btnSaveDialogManualUpload_Click(object sender, EventArgs e)
        {
            using (DropboxDialogBase dlg = new SaveDropboxDialog())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    txtUploadTarget.Text = dlg.SelectedFile;

                    MessageBox.Show(this, "File selected as upload target", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // The file can be uploaded using the UploadFileToCurrentFolder function
                    //dlg.UploadFileToCurrentFolder(myLocalFilePath);
                }
            }
        }
        #endregion
    }
}
