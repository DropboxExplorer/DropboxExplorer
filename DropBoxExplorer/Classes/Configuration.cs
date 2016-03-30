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
        public static string DropboxAppKey { get; set; } = "";

        /// <summary>
        /// The Dropbbox redirect URL after an authorization as defined for the 'app' in the Dropbox developers portal
        /// </summary>
        public static string DropboxAuthorizationUrl { get; set; } = "https://www.dropbox.com/1/oauth2/redirect_receiver";
    }
    
    /// <summary>
    /// Determines which mode the Open Dialog works in
    /// Either provides direct access to files or accesses the share URLs associated with those files
    /// </summary>
    public enum OpenDialogType
    {
        File,
        TeamShare,
        PublicShare
    }
}
