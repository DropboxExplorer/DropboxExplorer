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
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Dropbox.Api.Files;

namespace DropboxExplorer
{
    /// <summary>
    /// Provides a simple file list control using a ListView
    /// </summary>
    internal partial class FileListing : UserControl
    {
        private string _CurrentPath = "";

        #region Public events
        public class ItemSelectedArgs : EventArgs
        {
            public enum SelectedItemType
            {
                Folder,
                File
            }

            /// <summary>
            /// The type of the item selected
            /// </summary>
            public SelectedItemType ItemType { get; internal set; }

            /// <summary>
            /// The path to the selected item
            /// </summary>
            public string Path { get; internal set; }
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

            filetypes16.Images.Clear();
            filetypes16.Images.Add("Folder", Properties.Resources.Folder);
            filetypes16.Images.Add("File", Properties.Resources.File);

            filetypes48.Images.Clear();
            filetypes48.Images.Add("Folder", Properties.Resources.Folder48);
            filetypes48.Images.Add("File", Properties.Resources.File48);

            listview.Columns.Add("Name");
            listview.Columns.Add("Type");
            listview.Columns.Add("Size");
            listview.Columns.Add("Date");

            FillColumnsToWidth();
            WinAPI.ConfigureListView(listview);
        }
        
        /// <summary>
        /// Gets the full path to the selected item
        /// </summary>
        internal string SelectedItem
        {
            get
            {
                Metadata item = GetSelectedObject();
                if (item != null)
                {
                    return item.PathLower;
                }
                return "";
            }
        }

        /// <summary>
        /// Navigates to the required folder
        /// </summary>
        /// <param name="path">The path to navigate to</param>
        /// <returns>The result of the asynchronous operation</returns>
        internal async Task NavigateToFolder(string path)
        {
            _CurrentPath = path;
            if (path == null) path = "";
            if (path.Length > 0 && !path.StartsWith("/")) path = "/" + path;
            if (path == "/") path = "";

            busyIcon1.Show();
            busyIcon1.BringToFront();
            
            try
            {
                listview.Items.Clear();

                using (var dropbox = new DropboxFiles())
                {
                    var list = await dropbox.GetFolderContents(path);

                    foreach (var folder in list.Entries.Where(i => i.IsFolder))
                    {
                        var item = AddItem(folder.Name, "Folder", "", "File folder", "");
                        item.Tag = folder;
                    }

                    foreach (var file in list.Entries.Where(i => i.IsFile))
                    {
                        var task = AddFile(dropbox, file.AsFile);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorPanel.ShowError(this, "A problem occurred retrieving folder contents.", ex);
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

        private void menuBrowser_Opening(object sender, CancelEventArgs e)
        {
            View view = listview.View;
            menuTiles.Checked = (view == View.Tile);
            menuLargeIcons.Checked = (view == View.LargeIcon);
            menuSmallIcons.Checked = (view == View.SmallIcon);
            menuList.Checked = (view == View.List);
            menuDetails.Checked = (view == View.Details);
        }

        private async void menuBrowserRefresh_Click(object sender, EventArgs e)
        {
            await NavigateToFolder(_CurrentPath);
        }

        private void menuTiles_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            listview.View = (View)int.Parse(item.Tag.ToString());
        }
        #endregion

        #region Private methods
        private void FillColumnsToWidth()
        {
            int width = this.Width / listview.Columns.Count;
            foreach (ColumnHeader col in listview.Columns)
            {
                col.Width = width;
            }
        }

        private Metadata GetSelectedObject()
        {
            if (listview.SelectedItems.Count > 0)
            {
                var item = listview.SelectedItems[0];
                return item.Tag as Metadata;
            }
            return null;
        }

        private ItemSelectedArgs GetSelectedItemArgs()
        {
            Metadata item = GetSelectedObject();
            if (item != null)
            {
                ItemSelectedArgs args = new ItemSelectedArgs();
                args.ItemType = (item.IsFolder ? ItemSelectedArgs.SelectedItemType.Folder : ItemSelectedArgs.SelectedItemType.File);
                args.Path = item.PathLower;
                return args;
            }
            return null;
        }

        private async Task AddFile(DropboxFiles dropbox, FileMetadata file)
        {
            const string THUMBNAILS = ".jpg.jpeg.png.tiff.tif.gif.bmp";

            string ext = System.IO.Path.GetExtension(file.Name);
            string imageKey = ext;

            if (filetypes16.Images.ContainsKey(file.PathLower))
            {
                imageKey = file.PathLower;
            }
            else if (!filetypes16.Images.ContainsKey(ext))
            {
                filetypes16.Images.Add(ext, WinAPI.GetFileSmallIcon(file.Name));
                filetypes48.Images.Add(ext, WinAPI.GetFileExtraLargeIcon(file.Name));
            }

            var item = AddItem(file.Name, imageKey, file.AsFile.ClientModified.ToString(), WinAPI.GetFileTypeName(ext), WinAPI.FormatBytes(file.AsFile.Size));
            item.Tag = file;

            // If current image is based on extension, get the thumbnail
            if (THUMBNAILS.Contains(ext) && imageKey == ext)
            {
                var task = await dropbox.GetThumbnail(file.PathLower);
                using (var stream = task.GetContentAsStreamAsync())
                {
                    using (Bitmap image = new Bitmap(stream.Result))
                    {
                        Image thumbnail = GetThumbnail(image, filetypes48.ImageSize.Width);
                        filetypes16.Images.Add(file.PathLower, WinAPI.GetFileSmallIcon(file.Name));
                        filetypes48.Images.Add(file.PathLower, thumbnail);
                        item.ImageKey = file.PathLower;
                    }
                }
            }
        }

        private ListViewItem AddItem(string name, string icon, string date, string type, string size)
        {
            var item = listview.Items.Add(name, icon);
            item.SubItems.Add(type);
            item.SubItems.Add(size);
            item.SubItems.Add(date);
            return item;
        }

        private Image GetThumbnail(Image source, int size)
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
                TargetRect.Y = ThumbRect.Height - TargetRect.Height;
            }
            else if (source.Width < source.Height)
            {
                TargetRect.Width = (int)((double)source.Width * (double)size / (double)source.Height);
                TargetRect.X = ThumbRect.Width - TargetRect.Width;
            }

            // Create the thumbnail
            Image thumb = new Bitmap(ThumbRect.Width, ThumbRect.Height);
            using (Graphics g = Graphics.FromImage(thumb))
            {
                g.Clear(Color.FromKnownColor(KnownColor.Window));
                if (source != null)
                    g.DrawImage(source, TargetRect);
            }
            return thumb;
        }
        #endregion
    }
}
