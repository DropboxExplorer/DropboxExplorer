using System;
using System.Windows.Forms;

namespace DropboxExplorerTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            DropboxExplorer.Configuration.DropboxAppKey = "7su6xqsuh1msl4w";

            Application.Run(new DropboxExplorer.Test.FormExample());
        }
    }
}
