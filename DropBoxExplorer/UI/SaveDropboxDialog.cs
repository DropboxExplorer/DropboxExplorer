namespace DropboxExplorer
{
    /// <summary>
    /// Displays a standard dialog box that prompts the user to save a file to Dropbox
    /// </summary>
    public class SaveDropboxDialog : DropboxDialogBase
    {
        /// <summary>
        /// Initializes an instance of the DropboxExplorer.SaveDropboxDialog class.
        /// </summary>
        /// <param name="appKey">The Dropbox App Key as defined in a Dropbox app</param>
        public SaveDropboxDialog()
            : base(DialogMode.Save)
        {
        }
    }
}
