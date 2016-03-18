using System.Windows.Forms;

namespace DropboxExplorer
{
    /// <summary>
    /// Shows a busy icon to indicate something is happening
    /// </summary>
    internal class BusyIcon : PictureBox
    {
        public BusyIcon()
        {
            this.Image = Properties.Resources.Working24;
            this.SizeMode = PictureBoxSizeMode.AutoSize;
        }
    }
}
