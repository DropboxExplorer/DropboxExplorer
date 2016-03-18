using Microsoft.Win32;
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


            DropboxExplorer.Configuration.DropboxAppKey = GetAppKey();

            Application.Run(new DropboxExplorer.Test.FormExample());
        }

        /// <summary>
        /// Function allows local AppKey to not be in GitHub
        /// </summary>
        /// <returns></returns>
        private static string GetAppKey()
        {
            try
            {
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"Software\Dropbox Explorer", false);
                if (regKey != null)
                {
                    object value = regKey.GetValue("AppKey", "");
                    return value.ToString();
                }
            }
            catch { }

            return "";
        }
    }
}
