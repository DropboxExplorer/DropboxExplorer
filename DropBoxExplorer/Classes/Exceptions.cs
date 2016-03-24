using System;

namespace DropboxExplorer
{
    public class NoFileSelectedException : Exception
    {
        public NoFileSelectedException() : base("No file selected") { }
    }
}
