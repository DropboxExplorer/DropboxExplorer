namespace DropboxExplorer
{
    partial class WebLogin
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebLogin));
            this.browser = new System.Windows.Forms.WebBrowser();
            this.busyIcon1 = new DropboxExplorer.BusyIcon();
            this.workerTest = new System.ComponentModel.BackgroundWorker();
            this.timerTimeout = new System.Windows.Forms.Timer(this.components);
            this.lblTimeout = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.busyIcon1)).BeginInit();
            this.SuspendLayout();
            // 
            // browser
            // 
            this.browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browser.Location = new System.Drawing.Point(0, 0);
            this.browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(300, 300);
            this.browser.TabIndex = 1;
            this.browser.Visible = false;
            this.browser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.browser_Navigated);
            // 
            // busyIcon1
            // 
            this.busyIcon1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.busyIcon1.Image = ((System.Drawing.Image)(resources.GetObject("busyIcon1.Image")));
            this.busyIcon1.Location = new System.Drawing.Point(139, 81);
            this.busyIcon1.Name = "busyIcon1";
            this.busyIcon1.Size = new System.Drawing.Size(24, 24);
            this.busyIcon1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.busyIcon1.TabIndex = 8;
            this.busyIcon1.TabStop = false;
            // 
            // workerTest
            // 
            this.workerTest.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerTest_DoWork);
            this.workerTest.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerTest_RunWorkerCompleted);
            // 
            // timerTimeout
            // 
            this.timerTimeout.Interval = 30000;
            this.timerTimeout.Tick += new System.EventHandler(this.timerTimeout_Tick);
            // 
            // lblTimeout
            // 
            this.lblTimeout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTimeout.Location = new System.Drawing.Point(0, 0);
            this.lblTimeout.Name = "lblTimeout";
            this.lblTimeout.Size = new System.Drawing.Size(300, 300);
            this.lblTimeout.TabIndex = 9;
            this.lblTimeout.Text = "dropbox.com is not responding.\r\n\r\nCheck the DropBox status page or try again late" +
    "r.";
            this.lblTimeout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTimeout.Visible = false;
            // 
            // WebLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.busyIcon1);
            this.Controls.Add(this.browser);
            this.Controls.Add(this.lblTimeout);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "WebLogin";
            this.Size = new System.Drawing.Size(300, 300);
            ((System.ComponentModel.ISupportInitialize)(this.busyIcon1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser browser;
        private BusyIcon busyIcon1;
        private System.ComponentModel.BackgroundWorker workerTest;
        private System.Windows.Forms.Timer timerTimeout;
        private System.Windows.Forms.Label lblTimeout;
    }
}
