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
using System.Collections.Generic;

namespace DropboxExplorer
{
    /// <summary>
    /// The types of file system object
    /// </summary>
    public enum FileSystemObjectType
    {
        Folder,
        File
    }

    /// <summary>
    /// Encapsulates an item in a file system
    /// </summary>
    public class FileSystemObject
    {
        /// <summary>
        /// The type of the item
        /// </summary>
        public FileSystemObjectType ItemType { get; internal set; }

        public string Name { get; internal set; }

        /// <summary>
        /// The path to the item
        /// </summary>
        public string Path { get; internal set; }

        public DateTime ClientModified { get; internal set; }
        
        public ulong Size { get; internal set; }

        public string ShareUrl { get; internal set; }
    }

    /// <summary>
    /// Encapsulates an item in a file system
    /// </summary>
    internal class FileSystemObjects : List<FileSystemObject>
    {
    }
}
