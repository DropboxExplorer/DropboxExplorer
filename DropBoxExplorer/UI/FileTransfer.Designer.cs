namespace DropboxExplorer
{
    partial class FileTransfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileTransfer));
            this.busyIcon1 = new DropboxExplorer.BusyIcon();
            this.lblTransfer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.busyIcon1)).BeginInit();
            this.SuspendLayout();
            // 
            // busyIcon1
            // 
            this.busyIcon1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.busyIcon1.Image = ((System.Drawing.Image)(resources.GetObject("busyIcon1.Image")));
            this.busyIcon1.Location = new System.Drawing.Point(139, 81);
            this.busyIcon1.Name = "busyIcon1";
            this.busyIcon1.Size = new System.Drawing.Size(24, 24);
            this.busyIcon1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.busyIcon1.TabIndex = 7;
            this.busyIcon1.TabStop = false;
            // 
            // lblTransfer
            // 
            this.lblTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTransfer.AutoEllipsis = true;
            this.lblTransfer.Location = new System.Drawing.Point(13, 125);
            this.lblTransfer.Name = "lblTransfer";
            this.lblTransfer.Size = new System.Drawing.Size(275, 162);
            this.lblTransfer.TabIndex = 6;
            this.lblTransfer.Text = "Transfer";
            this.lblTransfer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FileTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.busyIcon1);
            this.Controls.Add(this.lblTransfer);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FileTransfer";
            this.Size = new System.Drawing.Size(300, 300);
            ((System.ComponentModel.ISupportInitialize)(this.busyIcon1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTransfer;
        private BusyIcon busyIcon1;
    }
}
