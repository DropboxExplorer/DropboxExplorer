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
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DropboxExplorer
{
    /// <summary>
    /// Provides a simple file list control using a ListView
    /// </summary>
    internal partial class FileListing : UserControl
    {
        private string _CurrentPath = "";
        private OpenDialogType _DialogType = OpenDialogType.File;

        #region Public events
        public class ItemSelectedArgs : EventArgs
        {
            public FileSystemObject Item { get; set; }

            public ItemSelectedArgs(FileSystemObject item)
            {
                Item = item;
            }
        }

        /// <summary>
        /// An item has been selected
        /// </summary>
        public event EventHandler<ItemSelectedArgs> ItemSelected;

        /// <summary>
        /// An item has been double clicked
        /// </summary>
        public event EventHandler<ItemSelectedArgs> ItemDoubleClicked;
        #endregion

        #region Public interface
        public FileListing()
        {
            InitializeComponent();

            InitialiseImageLists();

            listview.Columns.Add("Name");
            listview.Columns.Add("Type");
            listview.Columns.Add("Size");
            listview.Columns.Add("Date");
            
            WinAPI.ConfigureListView(listview);
        }

        /// <summary>
        /// Show or hide the New Folder button
        /// </summary>
        public bool ShowNewFolderButton
        {
            get
            {
                return menuNewFolder.Visible;
            }
            set
            {
                menuNewFolder.Visible = value;
                menuSepNewFolder.Visible = value;
            }
        }

        /// <summary>
        /// Gets the selected item
        /// </summary>
        public FileSystemObject GetSelectedItem()
        {
            if (listview.SelectedItems.Count > 0)
            {
                var item = listview.SelectedItems[0];
                return item.Tag as FileSystemObject;
            }
            return null;
        }

        /// <summary>
        /// Navigates to the required folder
        /// </summary>
        /// <param name="path">The path to navigate to</param>
        /// <returns>The result of the asynchronous operation</returns>
        internal async Task NavigateToFolder(OpenDialogType dialogType, string path)
        {
            _CurrentPath = DropboxFiles.FixPath(path);
            _DialogType = dialogType;

            busyIcon1.Show();
            busyIcon1.BringToFront();
            
            try
            {
                // Clear the list for for common code path to make UI look correct
                listview.Items.Clear();

                using (var dropbox = new DropboxFiles())
                {
                    var items = await dropbox.GetFolderContents(_CurrentPath, _DialogType);

                    // We might have ended up in the async method multiple times so lets clear again just in case
                    listview.Items.Clear();

                    foreach (var item in items)
                    {
                        switch (item.ItemType)
                        {
                            case FileSystemObjectType.Folder:
                                var folder = CreateItem(item.Name, "Folder", "", "File folder", "", item);
                                listview.Items.Add(folder);
                                break;

                            case FileSystemObjectType.File:
                                var task = AddFile(dropbox, item);
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorPanel.ShowError(this, ex);
            }
            
            busyIcon1.Hide();
        }

        /// <summary>
        /// Clears the current selection
        /// </summary>
        internal void ClearSelection()
        {
            while (listview.SelectedItems.Count > 0)
                listview.SelectedItems[0].Selected = false;
        }

        internal void NewFolder()
        {
            ListViewItem folder = CreateItem("New folder", "Folder", "", "File folder", "", null);
            listview.Items.Add(folder);
            listview.LabelEdit = true;
            folder.BeginEdit();
        }
        
        internal bool CurrentPathContains(string fileName)
        {
            foreach(ListViewItem item in listview.Items)
            {
                if (item.Text.Equals(fileName, StringComparison.CurrentCultureIgnoreCase))
                    return true;
            }

            return false;
        }
        #endregion

        #region Event handlers
        private void listview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ItemSelected == null) return;

            ItemSelectedArgs args = GetSelectedItemArgs();
            if (args == null) return;

            ItemSelected(this, args);
        }

        private void listview_DoubleClick(object sender, EventArgs e)
        {
            if (ItemDoubleClicked == null) return;

            ItemSelectedArgs args = GetSelectedItemArgs();
            if (args == null) return;

            ItemDoubleClicked(this, args);
        }

        private async void listview_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            try
            {
                listview.LabelEdit = false;
                if (e.Label == null)
                {
                    listview.Items.RemoveAt(e.Item);
                }
                else
                {
                    string path = _CurrentPath;
                    if (!path.EndsWith("/"))
                        path += "/";
                    path += e.Label;

                    using (var dropbox = new DropboxFiles())
                    {
                        await dropbox.CreateFolder(path);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorPanel.ShowError(this, ex);
            }
        }

        private async void listview_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                await ForceRefresh();
            }
        }

        private void menuBrowser_Opening(object sender, CancelEventArgs e)
        {
            View view = listview.View;
            menuTiles.Checked = (view == View.Tile);
            menuLargeIcons.Checked = (view == View.LargeIcon);
            menuSmallIcons.Checked = (view == View.SmallIcon);
            menuList.Checked = (view == View.List);
            menuDetails.Checked = (view == View.Details);
        }

        private async void menuRefresh_Click(object sender, EventArgs e)
        {
            await ForceRefresh();
        }

        private void menuView_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            listview.View = (View)int.Parse(item.Tag.ToString());

            if (listview.View == View.Details)
                FillColumnsToWidth();
        }

        private void menuNewFolder_Click(object sender, EventArgs e)
        {
            NewFolder();
        }
        #endregion

        #region Private methods
        private async Task ForceRefresh()
        {
            InitialiseImageLists();
            await NavigateToFolder(_DialogType, _CurrentPath);
        }

        private void InitialiseImageLists()
        {
            filetypes16.Images.Clear();
            filetypes16.Images.Add("Folder", Properties.Resources.Folder);
            filetypes16.Images.Add("File", Properties.Resources.File);

            filetypes48.Images.Clear();
            filetypes48.Images.Add("Folder", Properties.Resources.Folder48);
            filetypes48.Images.Add("File", Properties.Resources.File48);
        }

        private void FillColumnsToWidth()
        {
            int width = this.Width / listview.Columns.Count;
            foreach (ColumnHeader col in listview.Columns)
            {
                col.Width = width;
            }
        }

        private ItemSelectedArgs GetSelectedItemArgs()
        {
            FileSystemObject item = GetSelectedItem();
            if (item != null)
            {
                ItemSelectedArgs args = new ItemSelectedArgs(item);
                return new ItemSelectedArgs(item);
            }
            return null;
        }
        
        private async Task AddFile(DropboxFiles dropbox, FileSystemObject file)
        {
            const string THUMBNAILS = ".jpg.jpeg.png.tiff.tif.gif.bmp";

            string ext = System.IO.Path.GetExtension(file.Name);
            string imageKey = ext;
            
            if (filetypes16.Images.ContainsKey(file.Path))
            {
                imageKey = file.Path;
            }
            else if (!filetypes16.Images.ContainsKey(imageKey))
            {
                Bitmap small = WinAPI.GetFileSmallIcon(file.Name);
                filetypes16.Images.Add(imageKey, small);

                Bitmap large = WinAPI.GetFileExtraLargeIcon(file.Name);
                filetypes48.Images.Add(imageKey, large);
            }

            var item = CreateItem(file.Name, imageKey, file.ClientModified.ToString(), WinAPI.GetFileTypeName(ext), WinAPI.FormatBytes(file.Size), file);
            listview.Items.Add(item);

            // If current image is based on extension, get the thumbnail
            if (THUMBNAILS.Contains(ext) && imageKey.StartsWith(ext))
            {
                using (var image = await dropbox.GetThumbnail(file.Path))
                {
                    Bitmap thumbnail = GetThumbnail(image, filetypes48.ImageSize.Width);

                    Bitmap small = WinAPI.GetFileSmallIcon(file.Name);
                    filetypes16.Images.Add(file.Path, small);
                    
                    filetypes48.Images.Add(file.Path, thumbnail);

                    item.ImageKey = file.Path;
                }
            }
        }

        private ListViewItem CreateItem(string name, string icon, string date, string type, string size, object tag)
        {
            ListViewItem item = new ListViewItem();
            item.Text = name;
            item.ImageKey = icon;
            item.Tag = tag;
            item.SubItems.Add(type);
            item.SubItems.Add(size);
            item.SubItems.Add(date);
            return item;
        }

        private Bitmap GetThumbnail(Image source, int size)
        {
            // Calculate our thumbnail size
            Rectangle ThumbRect = new Rectangle(0, 0, size, size);
            Rectangle TargetRect = new Rectangle(0, 0, size, size);
            if (source == null)
            {
                // default size
            }
            else if (source.Width > source.Height)
            {
                TargetRect.Height = (int)((double)source.Height * (double)size / (double)source.Width);
                TargetRect.Y = (ThumbRect.Height - TargetRect.Height) / 2;
            }
            else if (source.Width < source.Height)
            {
                TargetRect.Width = (int)((double)source.Width * (double)size / (double)source.Height);
                TargetRect.X = (ThumbRect.Width - TargetRect.Width) / 2;
            }

            // Create the thumbnail
            Bitmap thumb = new Bitmap(ThumbRect.Width, ThumbRect.Height);
            using (Graphics g = Graphics.FromImage(thumb))
            {
                g.Clear(Color.FromKnownColor(KnownColor.Window));
                if (source != null)
                    g.DrawImage(source, TargetRect);
            }
            return thumb;
        }

        private void AddShareOverlay(Bitmap image, Image overlay)
        {
            using (Graphics g = Graphics.FromImage(image))
            {
                g.DrawImageUnscaled(overlay, 0, 0);
            }
        }
        #endregion
    }
}
