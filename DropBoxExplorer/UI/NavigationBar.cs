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
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DropboxExplorer
{
    /// <summary>
    /// Wraps a ToolStrip to provide basic folder navigation including a multi-level Back, an Up button and a crumbbar for quick ancestor selection
    /// </summary>
    internal class NavigationBar : ToolStrip
    {
        #region Custom renderer
        private class BorerlessRenderer : ToolStripSystemRenderer
        {
            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {
                // We don't want a border so don't draw anything
                //base.OnRenderToolStripBorder(e);
            }
            
            protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
            {
                e.Graphics.Clear(Color.White);
                //base.OnRenderToolStripBackground(e);
            }
        }
        #endregion

        #region Public events
        internal class PathSelectedArgs : EventArgs
        {
            /// <summary>
            /// The path requested
            /// </summary>
            public string Path { get; internal set; }

            /// <summary>
            /// True if the source of the selection was the back button
            /// </summary>
            public bool BackButton { get; internal set; }
        }

        /// <summary>
        /// A new path has been selected
        /// </summary>
        public event EventHandler<PathSelectedArgs> PathSelected;

        private void OnPathSelected(string path, bool backButton)
        {
            if (PathSelected == null) return;

            PathSelectedArgs args = new PathSelectedArgs();
            args.Path = path;
            args.BackButton = backButton;
            PathSelected(this, args);
        }

        public event EventHandler<EventArgs> NewFolder;
        #endregion

        #region Member variables
        private ToolStripItem _ButtonBack = null;
        private ToolStripDropDown _BackDropDown = null;
        private ToolStripItem _ButtonUp = null;
        private ToolStripItem _SeparatorNew = null;
        private ToolStripItem _ButtonNew = null;
        private ToolStripItem _SeparatorPath = null;
        private ToolStripItem _ButtonRoot = null;

        private List<ToolStripItem> _BreadcrumbButtons = new List<ToolStripItem>();
        private List<string> _PreviousPaths = new List<string>();
        private string _CurrentPath = "";
        #endregion

        #region Constructor
        public NavigationBar()
            : base()
        {
            this.GripStyle = ToolStripGripStyle.Hidden;
            this.Renderer = new BorerlessRenderer();

            _ButtonBack = AddSplitButton("Back", "Back to previous folder", Properties.Resources.Back, false, _ButtonBack_Click, "", _BackDropDown = new ToolStripDropDown());
            _ButtonBack.Margin = new Padding(2, 1, 0, 2);
            _ButtonUp = AddButton("Up", "Up to parent folder", Properties.Resources.Up, false, _ButtonUp_Click, "");

            this.Items.Add(_SeparatorNew = new ToolStripLabel(" "));
            _ButtonNew = AddButton("New Folder", "Create a new folder in  the current folder", Properties.Resources.FolderNew, true, _ButtonNew_Click, "");

            this.Items.Add(_SeparatorPath = new ToolStripLabel(" "));
            _ButtonRoot = AddButton("Dropbox", "Return to root folder", Properties.Resources.Dropbox, true, _ButtonRoot_Click, "");
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Show or hide the New Folder button
        /// </summary>
        public bool ShowNewFolderButton
        {
            get
            {
                return _ButtonNew.Visible;
            }
            set
            {
                _SeparatorNew.Visible = value;
                _ButtonNew.Visible = value;
            }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Sets the current path
        /// </summary>
        /// <param name="path">The path to configure the control for</param>
        internal void SetPath(string path, bool addToBackButton)
        {
            // Remember existing path in previous stack
            if (addToBackButton && string.Compare(path, _CurrentPath, true) != 0)
            {
                // Add previous path to start of list
                if (_CurrentPath.Length > 1 && _CurrentPath.StartsWith("/"))
                    _PreviousPaths.Insert(0, _CurrentPath.Substring(1));
                else
                    _PreviousPaths.Insert(0, _CurrentPath);
            }
            
            // Remove old buttons
            foreach (var btn in _BreadcrumbButtons)
                this.Items.Remove(btn);
            _BreadcrumbButtons.Clear();

            // If this isn't the root level, add a button for each folder in the path
            if (!string.IsNullOrEmpty(path))
            {
                string fullPath = "";
                string[] parts = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string part in parts)
                {
                    fullPath += "/" + part;
                    string caption = (part.Length > 1 ? part.Substring(0, 1).ToUpper() + part.Substring(1) : part.ToUpper());

                    ToolStripItem breadcrumbButton = AddButton(caption, string.Format("Return to '{0}' folder", fullPath.Substring(1)), Properties.Resources.Folder, true, breadcrumbButton_Click, fullPath);
                    
                    _BreadcrumbButtons.Add(breadcrumbButton);
                    this.Items.Add(breadcrumbButton);
                }
            }

            RebuildDropBackPaths();

            _CurrentPath = path;

            _ButtonRoot.Enabled = true;
            _ButtonBack.Enabled = (_PreviousPaths.Count > 0);
            _ButtonUp.Enabled = !DropboxFiles.IsRootPath(_CurrentPath);
        }
        #endregion

        #region Event handlers
        private void _ButtonBack_Click(object sender, EventArgs e)
        {
            if (_PreviousPaths.Count == 0) return;
            string path = _PreviousPaths[0];
            _PreviousPaths.RemoveAt(0);

            ButtonClick(_ButtonBack, path, true);
        }

        private void _ButtonUp_Click(object sender, EventArgs e)
        {
            if (DropboxFiles.IsRootPath(_CurrentPath)) return;
            string path = System.IO.Path.GetDirectoryName(_CurrentPath);
            path = path.Replace('\\', '/');
            if (path == "/") path = "";

            ButtonClick(_ButtonUp, path, false);
        }

        private void _ButtonRoot_Click(object sender, EventArgs e)
        {
            ButtonClick(_ButtonRoot, "", false);
        }

        private void _ButtonNew_Click(object sender, EventArgs e)
        {
            if (NewFolder != null)
            {
                NewFolder(this, new EventArgs());
            }
        }

        private void breadcrumbButton_Click(object sender, EventArgs e)
        {
            string path = ((ToolStripButton)sender).Tag.ToString();
            ButtonClick((ToolStripButton)sender, path, false);
        }
        private void backButtonMenuItem_Click(object sender, EventArgs e)
        {
            string path = ((ToolStripButton)sender).Tag.ToString();
            ButtonClick((ToolStripButton)sender, path, true);
        }
        #endregion

        #region Helper methods
        private ToolStripItem AddButton(string caption, string tooltip, Image icon, bool showCaption, EventHandler eventHandler, string tag)
        {
            ToolStripButton button = new ToolStripButton();
            button.Click += eventHandler;
            ConfigureItem(button, caption, tooltip, icon, showCaption, tag);
            this.Items.Add(button);
            return button;
        }

        private ToolStripItem AddSplitButton(string caption, string tooltip, Image icon, bool showCaption, EventHandler eventHandler, string tag, ToolStripDropDown dropDown)
        {
            dropDown.Renderer = this.Renderer;

            ToolStripSplitButton button = new ToolStripSplitButton();
            button.ButtonClick += eventHandler;
            button.DropDown = dropDown;
            ConfigureItem(button, caption, tooltip, icon, showCaption, tag);
            this.Items.Add(button);
            return button;
        }

        private void ConfigureItem(ToolStripItem button, string caption, string tooltip, Image icon, bool showCaption, string tag)
        {
            button.Text = caption;
            button.Image = icon;
            button.DisplayStyle = (showCaption ? ToolStripItemDisplayStyle.ImageAndText : ToolStripItemDisplayStyle.Image);
            button.ToolTipText = tooltip;
            button.AutoToolTip = !string.IsNullOrEmpty(tooltip);
            button.Tag = tag;
            button.Padding = new Padding(2, 0, 2, 3);
        }

        private void ButtonClick(ToolStripItem button, string path, bool backButton)
        {
            button.Enabled = false;
            OnPathSelected(path, backButton);
        }

        private void RebuildDropBackPaths()
        {
            _BackDropDown.Items.Clear();
            for(int i = 0; i < _PreviousPaths.Count; i++)
            {
                // Only allow 10 items on menu at any one time
                if (i >= 10) break;

                ToolStripButton button = new ToolStripButton();
                button.Click += backButtonMenuItem_Click;

                string path = _PreviousPaths[i];

                if (string.IsNullOrEmpty(path))
                    ConfigureItem(button, _ButtonRoot.Text, "", _ButtonRoot.Image, true, "");
                else
                    ConfigureItem(button, path, "", Properties.Resources.Folder, true, path);

                _BackDropDown.Items.Add(button);
            }            
        }
        #endregion
    }
}
