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
    /// Provides a testbox with a custom border to match the theme of the other controls
    /// </summary>
    internal class TextBoxThemedBorder : Panel
    {
        #region Member variables
        private const int TextboxWidth = 120;
        private const int HorizontalTextOffset = 4;
        private const int VerticalTextOffset = 5;
        private readonly Color BorderColor = Color.FromArgb(204, 232, 255);

        private TextBox _TextBox = null;
        #endregion

        /// <summary>
        /// Gets and sets the text of the text box
        /// </summary>
        public override string Text
        {
            get { return _TextBox.Text; }
            set { _TextBox.Text = value; }
        }

        #region Constructor
        public TextBoxThemedBorder()
        {
            _TextBox = new TextBox();
            _TextBox.TextChanged += _TextBox_TextChanged;
            _TextBox.BorderStyle = BorderStyle.None;
            _TextBox.Multiline = false;
            _TextBox.Location = new Point(HorizontalTextOffset, VerticalTextOffset);
            _TextBox.Width = TextboxWidth - 8;
            _TextBox.BackColor = Color.White;
            _TextBox.ForeColor = Color.Black;

            this.BackColor = _TextBox.BackColor;
            this.Controls.Add(_TextBox);
            this.Width = TextboxWidth;
        }
        #endregion

        #region Event handlers
        private void _TextBox_TextChanged(object sender, EventArgs e)
        {
            base.OnTextChanged(e);
        }
        #endregion

        #region Base overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle safeRect = new Rectangle(0, 0, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);
            using (Brush brush = new SolidBrush(_TextBox.BackColor))
            {
                e.Graphics.FillRectangle(brush, safeRect);
            }
            using (Pen pen = new Pen(BorderColor, 1F))
            {
                e.Graphics.DrawRectangle(pen, safeRect);
            }
            base.OnPaint(e);
        }
        #endregion
    }
}