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
    /// Displays a standard dialog box that prompts the user to open a file from Dropbox
    /// </summary>
    public class OpenDropboxDialog : DropboxDialogBase
    {
        /// <summary>
        /// Initializes an instance of the DropboxExplorer.OpenDropboxDialog class.
        /// </summary>
        /// <param name="dialogType">Specifies the type of open dialog. Either working with files directly and downloading them or working with shared links to those files.</param>
        public OpenDropboxDialog(OpenDialogType dialogType = OpenDialogType.File)
            : base(DialogMode.Open, dialogType)
        {
        }
    }
}