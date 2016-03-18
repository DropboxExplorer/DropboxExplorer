namespace DropboxExplorer
{
    partial class DropboxDialogBase
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DropboxDialogBase));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.lblFilename = new System.Windows.Forms.Label();
            this.fileBrowser1 = new DropboxExplorer.FileBrowser();
            this.fileTransfer1 = new DropboxExplorer.FileTransfer();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(516, 15);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(597, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.txtFilename);
            this.panelBottom.Controls.Add(this.lblFilename);
            this.panelBottom.Controls.Add(this.btnOK);
            this.panelBottom.Controls.Add(this.btnCancel);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 610);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(684, 51);
            this.panelBottom.TabIndex = 1;
            // 
            // txtFilename
            // 
            this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilename.Enabled = false;
            this.txtFilename.Location = new System.Drawing.Point(77, 15);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(349, 22);
            this.txtFilename.TabIndex = 1;
            this.txtFilename.TextChanged += new System.EventHandler(this.txtFilename_TextChanged);
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Enabled = false;
            this.lblFilename.Location = new System.Drawing.Point(12, 18);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(59, 13);
            this.lblFilename.TabIndex = 0;
            this.lblFilename.Text = "File name:";
            // 
            // fileBrowser1
            // 
            this.fileBrowser1.BackColor = System.Drawing.SystemColors.Window;
            this.fileBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileBrowser1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileBrowser1.Location = new System.Drawing.Point(0, 0);
            this.fileBrowser1.Name = "fileBrowser1";
            this.fileBrowser1.Size = new System.Drawing.Size(684, 610);
            this.fileBrowser1.TabIndex = 0;
            this.fileBrowser1.FileSelected += new System.EventHandler<DropboxExplorer.FileBrowser.ItemSelectedArgs>(this.fileBrowser1_FileSelected);
            this.fileBrowser1.FileDoubleClicked += new System.EventHandler<DropboxExplorer.FileBrowser.ItemSelectedArgs>(this.fileBrowser1_FileDoubleClicked);
            // 
            // fileTransfer1
            // 
            this.fileTransfer1.BackColor = System.Drawing.SystemColors.Window;
            this.fileTransfer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileTransfer1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileTransfer1.Location = new System.Drawing.Point(0, 0);
            this.fileTransfer1.Name = "fileTransfer1";
            this.fileTransfer1.Size = new System.Drawing.Size(684, 610);
            this.fileTransfer1.TabIndex = 2;
            this.fileTransfer1.Visible = false;
            // 
            // DropboxDialogBase
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(684, 661);
            this.Controls.Add(this.fileBrowser1);
            this.Controls.Add(this.fileTransfer1);
            this.Controls.Add(this.panelBottom);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "DropboxDialogBase";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dropbox";
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FileBrowser fileBrowser1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label lblFilename;
        private FileTransfer fileTransfer1;
    }
}