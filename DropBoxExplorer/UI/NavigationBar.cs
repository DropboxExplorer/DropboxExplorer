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

namespace DropboxExplorer.UI
{
    /// <summary>
    /// Wraps a ToolStrip to provide basic folder navigation including a multi-level Back, an Up button and a crumbbar for quick ancestor selection
    /// </summary>
    internal class NavigationBar : ToolStrip
    {
        #region Custom renderer
        private class BorerlessRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {
                // We don't want a border so don't draw anything
                //base.OnRenderToolStripBorder(e);
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
        }

        /// <summary>
        /// A new path has been selected
        /// </summary>
        public event EventHandler<PathSelectedArgs> PathSelected;

        private void OnPathSelected(string path)
        {
            if (PathSelected == null) return;

            PathSelectedArgs args = new PathSelectedArgs();
            args.Path = path;
            PathSelected(this, args);
        }
        #endregion

        #region Member variables
        private ToolStripItem _ButtonBack = null;
        private ToolStripItem _ButtonUp = null;
        private ToolStripItem _ButtonRoot = null;

        private List<ToolStripItem> _BreadcrumbButtons = new List<ToolStripItem>();
        private Stack<string> _PreviousPaths = new Stack<string>();
        private string _CurrentPath = "";
        #endregion

        #region Constructor
        public NavigationBar()
            : base()
        {
            this.GripStyle = ToolStripGripStyle.Hidden;
            this.Renderer = new BorerlessRenderer();

            _ButtonBack = AddButton("Back", "Back to previous folder", Properties.Resources.Back, false, _ButtonBack_Click);
            _ButtonUp = AddButton("Up", "Up to parent folder", Properties.Resources.Up, false, _ButtonUp_Click);
            this.Items.Add(new ToolStripSeparator());
            _ButtonRoot = AddButton("Dropbox", "Return to root folder", Properties.Resources.Dropbox, true, _ButtonRoot_Click);
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Sets the current path
        /// </summary>
        /// <param name="path">The path to configure the control for</param>
        internal void SetPath(string path)
        {
            // Remember existing path in previous stack
            if (string.Compare(path, _CurrentPath, true) != 0)
                _PreviousPaths.Push(_CurrentPath);

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

            _CurrentPath = path;

            _ButtonBack.Enabled = (_PreviousPaths.Count > 0);
            _ButtonUp.Enabled = !DropboxFiles.IsRootPath(_CurrentPath);
        }
        #endregion
        
        #region Event handlers
        private ToolStripItem AddButton(string caption, string tooltip, Image icon, bool showCaption, EventHandler eventHandler, string tag = "")
        {
            ToolStripButton button = new ToolStripButton(caption, icon, eventHandler);
            button.DisplayStyle = (showCaption ? ToolStripItemDisplayStyle.ImageAndText : ToolStripItemDisplayStyle.Image);
            button.ToolTipText = tooltip;
            button.Tag = tag;

            this.Items.Add(button);
            return button;
        }
        
        private void _ButtonBack_Click(object sender, EventArgs e)
        {
            if (_PreviousPaths.Count == 0) return;
            string path = _PreviousPaths.Pop();

            ButtonClick(_ButtonBack, path);
        }

        private void _ButtonUp_Click(object sender, EventArgs e)
        {
            if (DropboxFiles.IsRootPath(_CurrentPath)) return;
            string path = System.IO.Path.GetDirectoryName(_CurrentPath);
            path = path.Replace('\\', '/');

            ButtonClick(_ButtonUp, path);
        }

        private void _ButtonRoot_Click(object sender, EventArgs e)
        {
            ButtonClick(_ButtonRoot, "");
        }

        private void breadcrumbButton_Click(object sender, EventArgs e)
        {
            string path = ((ToolStripButton)sender).Tag.ToString();
            ButtonClick((ToolStripButton)sender, path);
        }
        #endregion

        #region Helper methods
        private void ButtonClick(ToolStripItem button, string path)
        {
            button.Enabled = false;
            OnPathSelected(path);
        }
        #endregion
    }
}
