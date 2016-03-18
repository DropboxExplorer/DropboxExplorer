namespace DropboxExplorer
{
    partial class FileBrowser
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
            this.login = new DropboxExplorer.WebLogin();
            this.listing = new DropboxExplorer.FileListing();
            this.toolbar = new DropboxExplorer.UI.NavigationBar();
            this.SuspendLayout();
            // 
            // login
            // 
            this.login.BackColor = System.Drawing.Color.White;
            this.login.Dock = System.Windows.Forms.DockStyle.Fill;
            this.login.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login.Location = new System.Drawing.Point(0, 25);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(300, 275);
            this.login.TabIndex = 1;
            this.login.Visible = false;
            this.login.Authenticated += new System.EventHandler<System.EventArgs>(this.login_Authenticated);
            // 
            // listing
            // 
            this.listing.BackColor = System.Drawing.SystemColors.Window;
            this.listing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listing.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listing.Location = new System.Drawing.Point(0, 25);
            this.listing.Name = "listing";
            this.listing.Size = new System.Drawing.Size(300, 275);
            this.listing.TabIndex = 8;
            this.listing.Visible = false;
            this.listing.ItemSelected += new System.EventHandler<DropboxExplorer.FileListing.ItemSelectedArgs>(this.listing_ItemSelected);
            this.listing.ItemDoubleClicked += new System.EventHandler<DropboxExplorer.FileListing.ItemSelectedArgs>(this.listing_ItemDoubleClicked);
            // 
            // toolbar
            // 
            this.toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(300, 25);
            this.toolbar.TabIndex = 9;
            this.toolbar.Text = "toolbar";
            this.toolbar.PathSelected += new System.EventHandler<DropboxExplorer.UI.NavigationBar.PathSelectedArgs>(this.toolbar_PathSelected);
            // 
            // FileBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.listing);
            this.Controls.Add(this.login);
            this.Controls.Add(this.toolbar);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FileBrowser";
            this.Size = new System.Drawing.Size(300, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private WebLogin login;
        private FileListing listing;
        private UI.NavigationBar toolbar;
    }
}
