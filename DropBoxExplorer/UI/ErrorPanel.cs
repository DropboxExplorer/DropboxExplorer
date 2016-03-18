using System;
using System.Windows.Forms;

namespace DropboxExplorer
{
    /// <summary>
    /// A standard error panel
    /// </summary>
    internal partial class ErrorPanel : UserControl
    {
        internal Exception Exception { get; set; }

        public ErrorPanel()
        {
            InitializeComponent();
        }

        private void Error_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, Exception.ToString(), "Dropbox Explorer Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// Adds the error panel to a control
        /// </summary>
        /// <param name="parent">The parent control to add the panel to</param>
        /// <param name="message">The message to display</param>
        /// <param name="ex">The initial exception</param>
        internal static void ShowError(Control parent, string message, Exception ex)
        {
            foreach (Control ctl in parent.Controls)
                ctl.Hide();

            ErrorPanel err = new ErrorPanel();
            err.Exception = ex;
            err.lblMessage.Text = message;
            err.Dock = DockStyle.Fill;
            parent.Controls.Add(err);
        }
    }
}
