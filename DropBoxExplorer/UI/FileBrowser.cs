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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DropboxExplorer
{
    /// <summary>
    /// A full file browser control with navigation toolbar
    /// </summary>
    /// <remarks>
    /// Initialise must be called to initially show the login panel
    /// Once logged in for a session, it can be used to jump directly to a dropbox folder
    /// </remarks>
    public partial class FileBrowser : UserControl
    {
        #region Public properties
        public Options Options
        {
            get { return listing?.Options; }
        }

        internal string Path { get; private set; } = "";
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
        public async void Initialise(string initialPath = "")
        {
            Path = initialPath;
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
        public string GetSelectedFilePath()
        {
            return listing.SelectedItem;
        }

        /// <summary>
        /// Clears the current selection
        /// </summary>
        public void ClearSelection()
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
            switch (e.Item.ItemType)
            {
                case FileSystemObjectType.File:
                    if (FileSelected != null)
                    {
                        FileSelected(this, new ItemSelectedArgs(e.Item.Path));
                    }
                    break;
            }
        }

        private async void listing_ItemDoubleClicked(object sender, FileListing.ItemSelectedArgs e)
        {
            switch (e.Item.ItemType)
            {
                case FileSystemObjectType.Folder:
                    await NavigateToFolder(e.Item.Path);
                    break;

                case FileSystemObjectType.File:
                    if (FileDoubleClicked != null)
                    {
                        FileDoubleClicked(this, new ItemSelectedArgs(e.Item.Path));
                    }
                    break;
            }
        }
        #endregion

        #region NavigationBar
        private async void toolbar_PathSelected(object sender, NavigationBar.PathSelectedArgs e)
        {
            await NavigateToFolder(e.Path);
        }
        #endregion
        #endregion

        #region Private methods
        private async Task ShowFileListing()
        {
            listing.Show();
            login.Hide();
            toolbar.Enabled = true;

            await NavigateToFolder(Path);
        }

        private async Task NavigateToFolder(string path)
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