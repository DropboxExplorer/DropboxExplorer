using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DropboxExplorer
{
    /// <summary>
    /// A full file browser control with navigation toolbar
    /// </summary>
    internal partial class FileBrowser : UserControl
    {
        #region Public properties
        internal string Path { get; private set; }

        internal Exception LastException { get; private set; }
        #endregion

        #region Public events
        public class ItemSelectedArgs : EventArgs
        {
            /// <summary>
            /// The path of the item
            /// </summary>
            public string Path { get; private set; }

            internal ItemSelectedArgs(string path)
            {
                Path = path;
            }
        }

        /// <summary>
        /// The path has been changed
        /// </summary>
        public event EventHandler<ItemSelectedArgs> PathChanged;

        /// <summary>
        /// A file has been selected
        /// </summary>
        public event EventHandler<ItemSelectedArgs> FileSelected;

        /// <summary>
        /// A file has been double clicked
        /// </summary>
        public event EventHandler<ItemSelectedArgs> FileDoubleClicked;
        #endregion

        #region Constructor
        public FileBrowser()
        {
            InitializeComponent();
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Initialises the control by navigating to the Dropbox login page or the root folder if already authorized
        /// </summary>
        internal async void Initialise()
        {
            if (string.IsNullOrEmpty(DropboxAuthorization.AccessToken))
            {
                login.Initialise();
                login.Show();
                login.Focus();
            }
            else
            {
                await ShowFileListing();
            }
        }

        /// <summary>
        /// Gets the full path to the selected item
        /// </summary>
        /// <returns>The full path to the selected item</returns>
        internal string GetSelectedFilePath()
        {
            return listing.SelectedItem;
        }

        /// <summary>
        /// Clears the current selection
        /// </summary>
        internal void ClearSelection()
        {
            listing.ClearSelection();
        }
        #endregion
        
        #region Event handlers
        #region Login panel
        private async void login_Authenticated(object sender, EventArgs e)
        {
            await ShowFileListing();
        }
        #endregion

        #region File listing
        private void listing_ItemSelected(object sender, FileListing.ItemSelectedArgs e)
        {
            switch (e.ItemType)
            {
                case FileListing.ItemSelectedArgs.SelectedItemType.File:
                    if (FileSelected != null)
                    {
                        FileSelected(this, new ItemSelectedArgs(e.Path));
                    }
                    break;
            }
        }

        private void listing_ItemDoubleClicked(object sender, FileListing.ItemSelectedArgs e)
        {
            switch (e.ItemType)
            {
                case FileListing.ItemSelectedArgs.SelectedItemType.Folder:
                    NavigateToFolder(e.Path);
                    break;

                case FileListing.ItemSelectedArgs.SelectedItemType.File:
                    if (FileDoubleClicked != null)
                    {
                        FileDoubleClicked(this, new ItemSelectedArgs(e.Path));
                    }
                    break;
            }
        }
        #endregion

        #region NavigationBar
        private void toolbar_PathSelected(object sender, UI.NavigationBar.PathSelectedArgs e)
        {
            NavigateToFolder(e.Path);
        }
        #endregion
        #endregion

        #region Private methods
        private async Task ShowFileListing()
        {
            listing.Show();
            login.Hide();

            await listing.NavigateToFolder("");
        }

        private async void NavigateToFolder(string path)
        {
            Path = path;
            toolbar.SetPath(path);
            await listing.NavigateToFolder(path);

            if (PathChanged != null)
            {
                PathChanged(this, new ItemSelectedArgs(path));
            }
        }
        #endregion
    }
}