using System;

namespace DropboxExplorer
{
    public class AuthorizationException : Exception
    {
        public AuthorizationException() : base("Not authorized for this operation") { }
    }

    public class NoFileSelectedException : Exception
    {
        public NoFileSelectedException() : base("No file selected") { }
    }
}
