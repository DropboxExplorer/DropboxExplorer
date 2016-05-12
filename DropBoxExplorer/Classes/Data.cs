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

    /// <summary>
    /// Encapsulates the progress of a file transfer operation
    /// </summary>
    public class FileTransferProgressArgs : EventArgs
    {
        #region Public properties
        /// <summary>
        /// The source file path
        /// </summary>
        public string Source { get; private set; }

        /// <summary>
        /// The destination file path
        /// </summary>
        public string Destination { get; private set; }

        /// <summary>
        /// The total size of the file
        /// </summary>
        public ulong FileSize { get; private set; }

        /// <summary>
        /// The current numbers of bytes trasnfered
        /// </summary>
        public ulong BytesTransfered { get; internal set; }

        /// <summary>
        /// The timestamp when the transfer started
        /// </summary>
        public DateTime Started { get; private set; }

        /// <summary>
        /// Calculates transfer progress as percentage (0% to 100%)
        /// </summary>
        public int Percentage
        {
            get
            {
                return (int)Math.Round(100F * BytesTransfered / FileSize);
            }
        }

        /// <summary>
        /// Generates a textual description of the estimates time remaining
        /// </summary>
        public string Remaining
        {
            get
            {
                if (BytesTransfered == FileSize)
                    return "Finishing";

                double ellapsedMS = (DateTime.Now - Started).TotalMilliseconds;
                double percentage = (double)BytesTransfered / (double)FileSize;
                if (ellapsedMS < 2000)
                    return "Calculating...";

                int remainingMS = (int)((ellapsedMS / percentage) - ellapsedMS);
                return FormatMS(remainingMS + 1000);
            }
        }
        #endregion

        #region Helper methods
        private static string FormatMS(int ms)
        {
            string s = "";
            TimeSpan diff = new TimeSpan(0, 0, 0, 0, ms);

            if (diff.TotalSeconds < 2.0)
                s = "1 second";
            else if (diff.TotalSeconds <= 55.0)
                s = FormatNumber(RoundTime(diff.TotalSeconds), "second");
            else if (diff.TotalSeconds <= 65.0)
                s = "1 minute";
            else if (diff.TotalMinutes < 10.0 && diff.Seconds < 3)
                s = FormatNumber(diff.Minutes, "minute");
            else if (diff.TotalMinutes < 10.0 && diff.Seconds > 57)
                s = FormatNumber(diff.Minutes + 1, "minute");
            else if (diff.TotalMinutes < 10.0)
                s = FormatNumber(diff.Minutes, "minute") + " " + FormatNumber(RoundTime(diff.Seconds), "second");
            else if (diff.TotalHours <= 1.0)
                s = FormatNumber((int)Math.Round(diff.TotalMinutes), "minute");
            else
                s = FormatNumber((int)Math.Round(diff.TotalHours), "hour");

            return s;
        }

        private static string FormatNumber(int number, string description)
        {
            return string.Format("{0} {1}{2}", number, description, (number == 1 ? "" : "s"));
        }
        
        private static int RoundTime(double time)
        {
            int rounded = (int)(Math.Round(time / 5.0) * 5);
            return Math.Max(1, rounded);
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a FileTransferProgressArgs item
        /// </summary>
        /// <param name="source">The source file to transfer</param>
        /// <param name="destination">The destination file for the transfer</param>
        /// <param name="fileSize">The size of the file to transfer</param>
        internal FileTransferProgressArgs(string source, string destination, ulong fileSize)
        {
            Source = source;
            Destination = destination;
            FileSize = fileSize;
            BytesTransfered = 0;
            Started = DateTime.Now;
        }
        #endregion
    }
}
