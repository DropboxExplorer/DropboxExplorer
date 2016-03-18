namespace DropboxExplorer
{
    /// <summary>
    /// Static configuration data for Dropbox Explorer
    /// </summary>
    public static class Configuration
    {
        /// <summary>
        /// The Dropbox AppKey unique to each 'app' in the Dropbox developers portal
        /// </summary>
        public static string DropboxAppKey { get; set; }

        /// <summary>
        /// The Dropbbox redirect URL after an authorization as defined for the 'app' in the Dropbox developers portal
        /// </summary>
        public static string DropboxAuthorizationUrl { get; set; }

        static Configuration()
        {
            DropboxAppKey = "";
            DropboxAuthorizationUrl = "https://www.dropbox.com/1/oauth2/redirect_receiver";
        }
    }
}
