﻿/* Copyright 2016 dropboxexplorer.com

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
        #region Member variables
        private OpenDialogType _DialogType = OpenDialogType.File;
        private string _SearchTerm = "";
        #endregion

        #region Public properties
        internal string Path { get; private set; } = "";
        
        public bool ShowNewFolderButton
        {
            get
            {
                if (toolbar == null)
                    return false;
                else
                    return toolbar.ShowNewFolderButton;
            }
            set
            {
                if (toolbar != null)
                    toolbar.ShowNewFolderButton = value;
                if (listing != null)
                    listing.ShowNewFolderButton = value;
            }
        }

        public async void SetFilter(string filter)
        {
            listing.SetFilter(filter);
            if (listing.Visible)
                await listing.ForceRefresh();
        }
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
        public async void Initialise(OpenDialogType dialogType, string initialPath = "", string searchTerm = "")
        {
            _DialogType = dialogType;
            Path = initialPath;
            _SearchTerm = searchTerm;

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
        /// Gets the selected item
        /// </summary>
        /// <returns>The selected item</returns>
        public FileSystemObject GetSelectedItem()
        {
            return listing.GetSelectedItem();
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
                    await NavigateToFolder(e.Item.Path, true);
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
        private void toolbar_NewFolder(object sender, EventArgs e)
        {
            listing.NewFolder();
        }

        private async void toolbar_PathSelected(object sender, NavigationBar.PathSelectedArgs e)
        {
            await NavigateToFolder(e.Path, !e.BackButton);
        }

        private void toolbar_SearchChanged(object sender, NavigationBar.SearchChangedArgs e)
        {
            timerSearch.Stop();
            _SearchTerm = e.SearchTerm;
            timerSearch.Start();
        }
        #endregion

        #region Timer
        private async void timerSearch_Tick(object sender, EventArgs e)
        {
            timerSearch.Stop();
            await NavigateToFolder(Path, false);
        }
        #endregion
        #endregion

        #region Private methods
        private async Task ShowFileListing()
        {
            listing.Show();
            login.Hide();
            toolbar.Enabled = true;

            await NavigateToFolder(Path, true);

            using (var dropbox = new DropboxUsers())
            {
                Task<UserAccount> account = dropbox.GetUser();
                await account;
                toolbar.SetUserAccount(account.Result);
            }
        }

        private async Task NavigateToFolder(string path, bool addToBackButton)
        {
            Path = path;
            toolbar.SetPath(path, addToBackButton);
            await listing.NavigateToFolder(_DialogType, path, _SearchTerm);

            if (PathChanged != null)
            {
                PathChanged(this, new ItemSelectedArgs(path));
            }
        }

        internal bool CurrentPathContains(string fileName)
        {
            return listing.CurrentPathContains(fileName);
        }
        #endregion
    }
}