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
using System.Threading.Tasks;
using Dropbox.Api;
using Dropbox.Api.Files;
using Dropbox.Api.Babel;

namespace DropboxExplorer
{
    /// <summary>
    /// Wraps the Dropbox authorisation functions
    /// </summary>
    internal class DropboxAuthorization
    {
        private string _Oauth2State = "";

        /// <summary>
        /// Get authorisation URL generated from the AppKey
        /// </summary>
        internal Uri URI { get; private set; }

        /// <summary>
        /// The access token following authorization
        /// </summary>
        internal static string AccessToken = "";

        /// <summary>
        /// Instantiates the authorization class and calculates the login URL
        /// </summary>
        internal DropboxAuthorization()
        {
            _Oauth2State = Guid.NewGuid().ToString("N");
            URI = DropboxOAuth2Helper.GetAuthorizeUri(OAuthResponseType.Token, Configuration.DropboxAppKey, new Uri(Configuration.DropboxAuthorizationUrl), state: _Oauth2State);
        }

        /// <summary>
        /// Validates the login attempt
        /// If successful the AccessToken is populated
        /// </summary>
        /// <param name="uri">The URL the login attempt navigated to</param>
        /// <returns>True if login successful</returns>
        internal bool Validate(Uri uri)
        {
            AccessToken = "";

            OAuth2Response result = DropboxOAuth2Helper.ParseTokenFragment(uri);
            if (result.State == _Oauth2State)
            {
                AccessToken = result.AccessToken;
                return true;
            }

            return false;
        }
    }

    /// <summary>
    /// Wraps the functionality to navigate around the files system and upload/download files
    /// </summary>
    internal class DropboxFiles : IDisposable
    {
        private DropboxClient _Dropbox = null;

        /// <summary>
        /// Creates a new DropboxFiles class
        /// </summary>
        internal DropboxFiles()
        {
            _Dropbox = new DropboxClient(DropboxAuthorization.AccessToken);
        }

        /// <summary>
        /// Gets the contents of a folder
        /// </summary>
        /// <param name="path">The folder to get contents of</param>
        /// <returns>A collection of file and folder items</returns>
        public Task<ListFolderResult> GetFolderContents(string path)
        {
            return _Dropbox.Files.ListFolderAsync(path);
        }

        /// <summary>
        /// Gets the thumbnail for an item
        /// </summary>
        /// <param name="path">The path to the item</param>
        /// <returns>The thumbnail</returns>
        public Task<IDownloadResponse<FileMetadata>> GetThumbnail(string path)
        {
            return _Dropbox.Files.GetThumbnailAsync(path);
        }

        /// <summary>
        /// Downloads a file from Dropbox
        /// </summary>
        /// <param name="dropboxFilePath">The path to the dropbox file to download</param>
        /// <param name="localFilePath">The local path to save the file as</param>
        /// <returns>The result of the asynchronous operation</returns>
        public async Task DownloadFile(string dropboxFilePath, string localFilePath)
        {
            var download = await _Dropbox.Files.DownloadAsync(dropboxFilePath);
            var bytes = await download.GetContentAsByteArrayAsync();
            System.IO.File.WriteAllBytes(localFilePath, bytes);
        }

        /// <summary>
        /// Uploads a file to Dropbox
        /// </summary>
        /// <param name="dropboxFilePath">The path to save the upload as within Dropbox</param>
        /// <param name="localFilePath">The local file to upload</param>
        /// <returns>The result of the asynchronous operation</returns>
        public async Task UploadFile(string dropboxFilePath, string localFilePath)
        {
            using (System.IO.FileStream stream = new System.IO.FileStream(localFilePath, System.IO.FileMode.Open))
            {
                await _Dropbox.Files.UploadAsync(dropboxFilePath, Dropbox.Api.Files.WriteMode.Add.Instance, true, body: stream);
            }
        }

        /// <summary>
        /// Disposed the object
        /// </summary>
        void IDisposable.Dispose()
        {
            if (_Dropbox != null)
            {
                _Dropbox.Dispose();
                _Dropbox = null;
            }
        }
    }
}