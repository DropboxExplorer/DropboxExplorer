using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DropboxExplorer
{
    /// <summary>
    /// The base class used for displaying Dropbox dialog boxes on the screen.
    /// </summary>
    public abstract partial class DropboxDialogBase : Form
    {
        #region Enums
        internal enum DialogMode
        {
            Open,
            Save
        }
        #endregion
        
        #region Member variables
        private DialogMode _Mode = DialogMode.Open;

        private string _UploadFile = "";
        #endregion

        #region Public interface
        /// <summary>
        /// The full Dropbox path to the currently selected file.
        /// </summary>
        public string SelectedFile { get; private set; }

        /// <summary>
        /// If set, the Open dialog will automatically download the chosen file to this local folder
        /// </summary>
        public string DownloadFolder { get; set; }

        /// <summary>
        /// The full local path to the downloaded file. If a file with the same name already exists, a new unique name will be generated.
        /// </summary>
        public string DownloadedFile { get; private set; }

        /// <summary>
        /// The full local path of a file the Save dialog should uploaded to the chosen location.
        /// </summary>
        public string UploadFile
        {
            get { return _UploadFile; }
            set
            {
                _UploadFile = value;
                txtFilename.Text = System.IO.Path.GetFileName(_UploadFile);
            }
        }

        /// <summary>
        /// Downloads the selected Dropbox file to the provided local path. If the file exists it will be overwritten.
        /// </summary>
        /// <param name="localFilePath">The full local path to download the file to.</param>
        /// <returns>An asynchronous operation result.</returns>
        public async Task DownloadSelectedFile(string localFilePath)
        {
            if (string.IsNullOrEmpty(this.SelectedFile))
                throw new Exception("No file selected");
            
            await fileTransfer1.DownloadFileUI(this.SelectedFile, localFilePath);
        }

        /// <summary>
        /// Uploads the provided local file to the selected Dropbox target.
        /// </summary>
        /// <param name="localFilePath">The full local path to the file to upload to the current Dropbox target. Dropbox will generate a new file name if required.</param>
        /// <returns>An asynchronous operation result.</returns>
        public async Task UploadFileToCurrentFolder(string localFilePath)
        {
            if (string.IsNullOrEmpty(localFilePath))
                throw new Exception("No file provided");
            if (!System.IO.File.Exists(localFilePath))
                throw new Exception("Local file not found");
            
            string dropboxFilePath = System.IO.Path.Combine(fileBrowser1.Path, txtFilename.Text);
            dropboxFilePath = dropboxFilePath.Replace(@"\", "/");

            if (!dropboxFilePath.StartsWith("/"))
                dropboxFilePath = "/" + dropboxFilePath;
            
            await fileTransfer1.UploadFileUI(dropboxFilePath, localFilePath);
        }
        #endregion

        #region Constructor
        internal DropboxDialogBase(DialogMode mode)
        {
            SelectedFile = "";
            _Mode = mode;

            InitializeComponent();
            this.Text = _Mode.ToString();
            btnOK.Text = _Mode.ToString();

            SetFormState(false);

            fileBrowser1.Initialise();
        }
        #endregion

        #region Event handlers
        #region File Browser
        private void fileBrowser1_FileSelected(object sender, FileBrowser.ItemSelectedArgs e)
        {
            txtFilename.Text = System.IO.Path.GetFileName(e.Path);
        }

        private void fileBrowser1_FileDoubleClicked(object sender, FileBrowser.ItemSelectedArgs e)
        {
            FileSelected();
        }
        #endregion
        
        #region Buttons
        private void btnOK_Click(object sender, EventArgs e)
        {
            FileSelected();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region File name textbox
        private void txtFilename_TextChanged(object sender, EventArgs e)
        {
            string file = System.IO.Path.GetFileName(fileBrowser1.GetSelectedFilePath());
            if (txtFilename.Text != file)
                fileBrowser1.ClearSelection();
        }
        #endregion
        #endregion

        #region Private methods
        private async Task DownloadSelectedFile()
        {
            if (string.IsNullOrEmpty(this.DownloadFolder))
                return;

            if (string.IsNullOrEmpty(this.SelectedFile))
                throw new Exception("No file selected");

            fileTransfer1.Show();
            fileBrowser1.Hide();

            SetFormState(false);
            this.DownloadedFile = GetUniqueLocalFileName();
            await DownloadSelectedFile(this.DownloadedFile);
            SetFormState(true);
        }

        private async Task UploadSelectedFile()
        {
            if (string.IsNullOrEmpty(this.UploadFile))
                return;
            
            fileTransfer1.Show();
            fileBrowser1.Hide();

            SetFormState(false);
            await UploadFileToCurrentFolder(this.UploadFile);
            SetFormState(true);
        }

        private async void FileSelected()
        {
            SelectedFile = fileBrowser1.GetSelectedFilePath();
            if (_Mode == DialogMode.Open && !string.IsNullOrEmpty(SelectedFile))
            {
                await DownloadSelectedFile();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Mode == DialogMode.Save && txtFilename.Text.Length > 0)
            {
                await UploadSelectedFile();
                this.DialogResult = DialogResult.OK;
            }
        }

        private string GetUniqueLocalFileName()
        {
            string fileName = System.IO.Path.GetFileName(this.SelectedFile);
            string localFilePath = System.IO.Path.Combine(this.DownloadFolder, fileName);

            string name = System.IO.Path.GetFileNameWithoutExtension(localFilePath);
            string ext = System.IO.Path.GetExtension(localFilePath);

            int index = 0;
            while (true)
            {
                if (!System.IO.File.Exists(localFilePath))
                    break;

                index++;
                fileName = string.Format("{0} ({1}){2}", name, index, ext);
                localFilePath = System.IO.Path.Combine(this.DownloadFolder, fileName);
            }

            return localFilePath;
        }

        private void SetFormState(bool enabled)
        {
            lblFilename.Enabled = enabled;
            txtFilename.Enabled = enabled;
            btnOK.Enabled = enabled;
        }
        #endregion
    }
}