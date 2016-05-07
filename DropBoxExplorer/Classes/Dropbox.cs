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
using System.Linq;
using System.Threading.Tasks;

using Dropbox.Api;
using Dropbox.Api.Files;
using Dropbox.Api.Sharing;
using System.Collections.Generic;
using System.IO;

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

        #region Public events
        public class FileTransferProgressArgs : EventArgs
        {
            /// <summary>
            /// The dropbox file path
            /// </summary>
            public string DropboxFilePath { get; private set; }

            /// <summary>
            /// The local file path
            /// </summary>
            public string LocalFilePath { get; private set; }

            /// <summary>
            /// The total size of the file
            /// </summary>
            public ulong FileSize { get; private set; }

            /// <summary>
            /// The current numbers of bytes trasnfered
            /// </summary>
            public ulong BytesTrasnfered { get; internal set; }

            /// <summary>
            /// Calculate transfer progress as percentage
            /// </summary>
            public int Percentage
            {
                get
                {
                    return (int)Math.Round(100F * BytesTrasnfered / FileSize);
                }
            }

            internal FileTransferProgressArgs(string dropboxFilePath, string localFilePath, ulong fileSize, ulong bytesTrasnfered)
            {
                DropboxFilePath = dropboxFilePath;
                LocalFilePath= localFilePath;
                FileSize = fileSize;
                BytesTrasnfered = bytesTrasnfered;
            }
        }

        /// <summary>
        /// The path has been changed
        /// </summary>
        public event EventHandler<FileTransferProgressArgs> FileTransferProgress;
        #endregion

        /// <summary>
        /// Creates a new DropboxFiles class
        /// </summary>
        internal DropboxFiles()
        {
            if (string.IsNullOrEmpty(DropboxAuthorization.AccessToken))
                throw new AuthorizationException();

            _Dropbox = new DropboxClient(DropboxAuthorization.AccessToken);
        }

        #region Static helper methods
        /// <summary>
        /// Fixes a path so it is compatible with the Dropbox APIs
        /// </summary>
        /// <param name="path">The path to fix</param>
        /// <returns>The fixed path</returns>
        public static string FixPath(string path)
        {
            if (path == null) path = "";
            if (path.Length > 0 && !path.StartsWith("/")) path = "/" + path;
            if (path == "/") path = "";

            return path;
        }

        /// <summary>
        /// Return true if the given path is the root folder
        /// </summary>
        /// <param name="path">The folder to check</param>
        /// <returns>True if the path is the root folder</returns>
        internal static bool IsRootPath(string path)
        {
            if (string.IsNullOrEmpty(path))
                return true;
            if (path == "/")
                return true;

            return false;
        }
        #endregion

        /// <summary>
        /// Gets the contents of a folder
        /// </summary>
        /// <param name="path">The folder to get contents of</param>
        /// <returns>A collection of file and folder items</returns>
        public async Task<FileSystemObjects> GetFolderContents(string path, OpenDialogType dialogType)
        {            
            #region Get all file system items
            IList<Metadata> entries = null;
            var operationContents = Task.Factory.StartNew(() =>
            {
                Task<ListFolderResult> results = _Dropbox.Files.ListFolderAsync(path);
                if (results.Exception != null)
                    throw results.Exception;

                if (results.Result != null)
                    entries = results.Result.Entries;
            });
            await operationContents;
            #endregion

            Task<FileSystemObjects> objects = MetadataToFileSystemObjects(entries, dialogType);
            return objects.Result;
        }

        /// <summary>
        /// Gets the thumbnail for an item
        /// </summary>
        /// <param name="path">The path to the item</param>
        /// <returns>The thumbnail</returns>
        public async Task<Image> GetThumbnail(string path)
        {
            var task = await _Dropbox.Files.GetThumbnailAsync(path);
            using (var stream = task.GetContentAsStreamAsync())
            {
                return new Bitmap(stream.Result);
            }
        }

        /// <summary>
        /// Creates a new folder
        /// </summary>
        /// <param name="path">The full path of the folder to create</param>
        /// <returns>The result of the asynchronous operation</returns>
        public async Task CreateFolder(string path)
        {
            var task = await _Dropbox.Files.CreateFolderAsync(path);
        }

        /// <summary>
        /// Downloads a file from Dropbox
        /// </summary>
        /// <param name="dropboxFilePath">The path to the dropbox file to download</param>
        /// <param name="localFilePath">The local path to save the file as</param>
        /// <returns>The result of the asynchronous operation</returns>
        public async Task DownloadFile(string dropboxFilePath, string localFilePath)
        {
            //var download = await _Dropbox.Files.DownloadAsync(dropboxFilePath);
            //var bytes = await download.GetContentAsByteArrayAsync();
            //System.IO.File.WriteAllBytes(localFilePath, bytes);

            if (File.Exists(localFilePath))
                File.Delete(localFilePath);

            var download = await _Dropbox.Files.DownloadAsync(dropboxFilePath);
            ulong fileSize = download.Response.Size;

            FileTransferProgressArgs args = new FileTransferProgressArgs(dropboxFilePath, localFilePath, fileSize, 0);

            const int bufferSize = 1024 * 1024;
            var buffer = new byte[bufferSize];

            // Open the stream and download a small chunk at a time so we can report proress
            using (var stream = await download.GetContentAsStreamAsync())
            {
                using (var file = new FileStream(localFilePath, FileMode.OpenOrCreate))
                {
                    var asyncDownload = Task.Factory.StartNew(() =>
                    {
                        var length = stream.Read(buffer, 0, bufferSize);

                        while (length > 0)
                        {
                            file.Write(buffer, 0, length);

                            // Calculate and report progress
                            args.BytesTrasnfered = (ulong)file.Length;
                            if (FileTransferProgress != null)
                            {
                                FileTransferProgress(this, args);
                            }

                            length = stream.Read(buffer, 0, bufferSize);
                        }
                    });
                    await asyncDownload;
                }
            }
        }

        /// <summary>
        /// Uploads a file to Dropbox
        /// </summary>
        /// <param name="dropboxFilePath">The path to save the upload as within Dropbox</param>
        /// <param name="localFilePath">The local file to upload</param>
        /// <returns>The result of the asynchronous operation</returns>
        public async Task UploadFile(string dropboxFilePath, string localFilePath, bool overwrite)
        {
            using (System.IO.FileStream stream = new System.IO.FileStream(localFilePath, System.IO.FileMode.Open))
            {
                await _Dropbox.Files.UploadAsync(dropboxFilePath, WriteMode.Add.Instance, !overwrite, body: stream);
            }
        }

        /// <summary>
        /// Searches a path for an item
        /// </summary>
        /// <param name="folder">The folder to begin the search in</param>
        /// <param name="query">The item to search for</param>
        /// <returns>The result of the asynchronous operation</returns>
        public async Task<FileSystemObjects> Search(string folder, OpenDialogType dialogType, string query)
        {
            await _Dropbox.Files.SearchAsync(folder, query);

            IList<Metadata> entries = new List<Metadata>();
            var operationContents = Task.Factory.StartNew(() =>
            {
                Task<SearchResult> results = _Dropbox.Files.SearchAsync(folder, query);
                if (results.Exception != null)
                    throw results.Exception;

                foreach (var match in results.Result.Matches)
                {
                    if (match.Metadata.IsFile)
                        entries.Add(match.Metadata);
                }
            });
            await operationContents;

            Task<FileSystemObjects> objects = MetadataToFileSystemObjects(entries, dialogType);
            return objects.Result;
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

        /// <summary>
        /// Converts a collection Dropbox Metadata objects to our own file system type
        /// </summary>
        /// <param name="entries"></param>
        /// <param name="dialogType"></param>
        /// <returns></returns>
        private async Task<FileSystemObjects> MetadataToFileSystemObjects(IList<Metadata> entries, OpenDialogType dialogType)
        {
            FileSystemObjects items = new FileSystemObjects();

            Dictionary<string, SharedLinkMetadata> shares = new Dictionary<string, SharedLinkMetadata>();

            #region Get all shares if required
            if (dialogType != OpenDialogType.File)
            {
                IList<SharedLinkMetadata> links = null;
                var operationShares = Task.Factory.StartNew(() =>
                {
                    Task<ListSharedLinksResult> results = _Dropbox.Sharing.ListSharedLinksAsync(null);
                    links = results.Result.Links;
                });
                await operationShares;

                foreach (var link in links)
                {
                    // Only add one share per item
                    if (!shares.ContainsKey(link.PathLower))
                    {
                        // If we want public links and this is a public link then add it
                        if (dialogType == OpenDialogType.PublicShare && link.LinkPermissions.ResolvedVisibility.IsPublic)
                        {
                            shares.Add(link.PathLower, link);
                        }

                        // If we want team links and this is a public or team link then add it
                        else if (dialogType == OpenDialogType.TeamShare && (link.LinkPermissions.ResolvedVisibility.IsPublic || link.LinkPermissions.ResolvedVisibility.IsTeamOnly))
                        {
                            shares.Add(link.PathLower, link);
                        }
                    }
                }
            }
            #endregion

            #region Process folders
            foreach (var result in entries.Where(i => i.IsFolder))
            {
                FileSystemObject item = new FileSystemObject();
                item.ItemType = FileSystemObjectType.Folder;
                item.Name = result.Name;
                item.Path = result.PathLower;
                item.ShareUrl = "";
                items.Add(item);
            }
            #endregion

            #region Process files
            foreach (var result in entries.Where(i => i.IsFile))
            {
                FileSystemObject item = new FileSystemObject();
                item.ItemType = FileSystemObjectType.File;
                item.Name = result.Name;
                item.Path = result.PathLower;
                item.ClientModified = result.AsFile.ClientModified;
                item.Size = result.AsFile.Size;

                if (dialogType == OpenDialogType.File)
                {
                    item.ShareUrl = "";
                    items.Add(item);
                }
                else if (shares.ContainsKey(result.PathLower))
                {
                    item.ShareUrl = shares[result.PathLower].Url;
                    items.Add(item);
                }
            }
            #endregion

            return items;
        }
    }
}