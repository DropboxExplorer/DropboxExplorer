namespace DropboxExplorer
{
    /// <summary>
    /// Displays a standard dialog box that prompts the user to open a file from Dropbox
    /// </summary>
    public class OpenDropboxDialog : DropboxDialogBase
    {
        /// <summary>
        /// Initializes an instance of the DropboxExplorer.OpenDropboxDialog class.
        /// </summary>
        /// <param name="appKey">The Dropbox App Key as defined in a Dropbox app</param>
        public OpenDropboxDialog()
            : base(DialogMode.Open)
        {
        }
    }
}
