namespace DropboxExplorer
{
    partial class FileListing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileListing));
            this.listview = new System.Windows.Forms.ListView();
            this.filetypes48 = new System.Windows.Forms.ImageList(this.components);
            this.filetypes16 = new System.Windows.Forms.ImageList(this.components);
            this.menuBrowser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuBrowserRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBrowserSep0 = new System.Windows.Forms.ToolStripSeparator();
            this.menuTiles = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLargeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSmallIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.menuList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.busyIcon1 = new DropboxExplorer.BusyIcon();
            this.menuBrowser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.busyIcon1)).BeginInit();
            this.SuspendLayout();
            // 
            // listview
            // 
            this.listview.AllowColumnReorder = true;
            this.listview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listview.FullRowSelect = true;
            this.listview.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listview.LargeImageList = this.filetypes48;
            this.listview.Location = new System.Drawing.Point(0, 0);
            this.listview.MultiSelect = false;
            this.listview.Name = "listview";
            this.listview.Size = new System.Drawing.Size(300, 300);
            this.listview.SmallImageList = this.filetypes16;
            this.listview.TabIndex = 1;
            this.listview.UseCompatibleStateImageBehavior = false;
            this.listview.View = System.Windows.Forms.View.Tile;
            this.listview.SelectedIndexChanged += new System.EventHandler(this.listview_SelectedIndexChanged);
            this.listview.DoubleClick += new System.EventHandler(this.listview_DoubleClick);
            // 
            // filetypes48
            // 
            this.filetypes48.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.filetypes48.ImageSize = new System.Drawing.Size(48, 48);
            this.filetypes48.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // filetypes16
            // 
            this.filetypes16.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.filetypes16.ImageSize = new System.Drawing.Size(16, 16);
            this.filetypes16.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // menuBrowser
            // 
            this.menuBrowser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBrowserRefresh,
            this.menuBrowserSep0,
            this.menuTiles,
            this.menuLargeIcons,
            this.menuSmallIcons,
            this.menuList,
            this.menuDetails});
            this.menuBrowser.Name = "menu";
            this.menuBrowser.Size = new System.Drawing.Size(153, 164);
            this.menuBrowser.Opening += new System.ComponentModel.CancelEventHandler(this.menuBrowser_Opening);
            // 
            // menuBrowserRefresh
            // 
            this.menuBrowserRefresh.Name = "menuBrowserRefresh";
            this.menuBrowserRefresh.Size = new System.Drawing.Size(152, 22);
            this.menuBrowserRefresh.Text = "Refresh";
            this.menuBrowserRefresh.Click += new System.EventHandler(this.menuBrowserRefresh_Click);
            // 
            // menuBrowserSep0
            // 
            this.menuBrowserSep0.Name = "menuBrowserSep0";
            this.menuBrowserSep0.Size = new System.Drawing.Size(149, 6);
            // 
            // menuTiles
            // 
            this.menuTiles.Name = "menuTiles";
            this.menuTiles.Size = new System.Drawing.Size(152, 22);
            this.menuTiles.Tag = "4";
            this.menuTiles.Text = "Tiles";
            this.menuTiles.Click += new System.EventHandler(this.menuTiles_Click);
            // 
            // menuLargeIcons
            // 
            this.menuLargeIcons.Name = "menuLargeIcons";
            this.menuLargeIcons.Size = new System.Drawing.Size(152, 22);
            this.menuLargeIcons.Tag = "0";
            this.menuLargeIcons.Text = "Large Icons";
            // 
            // menuSmallIcons
            // 
            this.menuSmallIcons.Name = "menuSmallIcons";
            this.menuSmallIcons.Size = new System.Drawing.Size(152, 22);
            this.menuSmallIcons.Tag = "2";
            this.menuSmallIcons.Text = "Small Icons";
            // 
            // menuList
            // 
            this.menuList.Name = "menuList";
            this.menuList.Size = new System.Drawing.Size(152, 22);
            this.menuList.Tag = "3";
            this.menuList.Text = "List";
            // 
            // menuDetails
            // 
            this.menuDetails.Name = "menuDetails";
            this.menuDetails.Size = new System.Drawing.Size(152, 22);
            this.menuDetails.Tag = "1";
            this.menuDetails.Text = "Details";
            // 
            // busyIcon1
            // 
            this.busyIcon1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.busyIcon1.Image = ((System.Drawing.Image)(resources.GetObject("busyIcon1.Image")));
            this.busyIcon1.Location = new System.Drawing.Point(139, 81);
            this.busyIcon1.Name = "busyIcon1";
            this.busyIcon1.Size = new System.Drawing.Size(24, 24);
            this.busyIcon1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.busyIcon1.TabIndex = 9;
            this.busyIcon1.TabStop = false;
            // 
            // FileListing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.busyIcon1);
            this.Controls.Add(this.listview);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FileListing";
            this.Size = new System.Drawing.Size(300, 300);
            this.menuBrowser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.busyIcon1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listview;
        private System.Windows.Forms.ContextMenuStrip menuBrowser;
        private System.Windows.Forms.ToolStripMenuItem menuBrowserRefresh;
        private System.Windows.Forms.ToolStripSeparator menuBrowserSep0;
        private System.Windows.Forms.ToolStripMenuItem menuTiles;
        private System.Windows.Forms.ToolStripMenuItem menuLargeIcons;
        private System.Windows.Forms.ToolStripMenuItem menuSmallIcons;
        private System.Windows.Forms.ToolStripMenuItem menuList;
        private System.Windows.Forms.ToolStripMenuItem menuDetails;
        private System.Windows.Forms.ImageList filetypes48;
        private System.Windows.Forms.ImageList filetypes16;
        private BusyIcon busyIcon1;
    }
}
