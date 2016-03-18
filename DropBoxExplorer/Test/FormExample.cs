using System;
using System.IO;
using System.Windows.Forms;

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

            if (string.IsNullOrEmpty(Configuration.DropboxAppKey))
                lblAppKey.Show();
            else
                tabControl1.Show();
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
                using (DropboxDialogBase dlg = new OpenDropboxDialog())
                {
                    dlg.DownloadFolder = txtDownloadFolder.Text;

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
            using (DropboxDialogBase dlg = new OpenDropboxDialog())
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
