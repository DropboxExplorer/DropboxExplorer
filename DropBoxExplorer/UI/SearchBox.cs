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
using System.Drawing;
using System.Windows.Forms;

namespace DropboxExplorer
{
    /// <summary>
    /// Provides a themed search box with label prompt when un-used
    /// </summary>
    public partial class SearchBox : UserControl
    {
        public SearchBox()
        {
            InitializeComponent();
        }

        public override string Text
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }

        private void lblPrompt_Click(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            lblPrompt.Hide();
            this.BackColor = Color.FromArgb(204, 232, 255);
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromKnownColor(KnownColor.Control);
            lblPrompt.Visible = (txtSearch.Text.Length == 0);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            base.OnTextChanged(e);
        }
    }
}
