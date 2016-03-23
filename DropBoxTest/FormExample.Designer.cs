namespace DropboxExplorer.Test
{
    partial class FormExample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExample));
            this.btnOpenDialogAutoDownload = new System.Windows.Forms.Button();
            this.btnDownloadFolder = new System.Windows.Forms.Button();
            this.txtDownloadFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDownloadSource = new System.Windows.Forms.TextBox();
            this.lblDownloadSource = new System.Windows.Forms.Label();
            this.btnOpenDialogManualDownload = new System.Windows.Forms.Button();
            this.btnSaveDialogManualUpload = new System.Windows.Forms.Button();
            this.txtUploadTarget = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveDialogAutoUpload = new System.Windows.Forms.Button();
            this.btnUploadFile = new System.Windows.Forms.Button();
            this.txtUploadFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAppKey = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenDialogAutoDownload
            // 
            this.btnOpenDialogAutoDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenDialogAutoDownload.Location = new System.Drawing.Point(20, 82);
            this.btnOpenDialogAutoDownload.Name = "btnOpenDialogAutoDownload";
            this.btnOpenDialogAutoDownload.Size = new System.Drawing.Size(711, 45);
            this.btnOpenDialogAutoDownload.TabIndex = 14;
            this.btnOpenDialogAutoDownload.Text = "Show Open Dialog";
            this.btnOpenDialogAutoDownload.UseVisualStyleBackColor = true;
            this.btnOpenDialogAutoDownload.Click += new System.EventHandler(this.btnOpenDialogAutoDownload_Click);
            // 
            // btnDownloadFolder
            // 
            this.btnDownloadFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadFolder.Location = new System.Drawing.Point(708, 35);
            this.btnDownloadFolder.Name = "btnDownloadFolder";
            this.btnDownloadFolder.Size = new System.Drawing.Size(23, 22);
            this.btnDownloadFolder.TabIndex = 10;
            this.btnDownloadFolder.Text = "…";
            this.btnDownloadFolder.UseVisualStyleBackColor = true;
            this.btnDownloadFolder.Click += new System.EventHandler(this.btnDownloadFolder_Click);
            // 
            // txtDownloadFolder
            // 
            this.txtDownloadFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDownloadFolder.Location = new System.Drawing.Point(20, 35);
            this.txtDownloadFolder.Name = "txtDownloadFolder";
            this.txtDownloadFolder.Size = new System.Drawing.Size(682, 22);
            this.txtDownloadFolder.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Automatically download Dropbox file to this local folder";
            // 
            // txtDownloadSource
            // 
            this.txtDownloadSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDownloadSource.Location = new System.Drawing.Point(17, 102);
            this.txtDownloadSource.Name = "txtDownloadSource";
            this.txtDownloadSource.ReadOnly = true;
            this.txtDownloadSource.Size = new System.Drawing.Size(711, 22);
            this.txtDownloadSource.TabIndex = 13;
            // 
            // lblDownloadSource
            // 
            this.lblDownloadSource.AutoSize = true;
            this.lblDownloadSource.Location = new System.Drawing.Point(17, 86);
            this.lblDownloadSource.Name = "lblDownloadSource";
            this.lblDownloadSource.Size = new System.Drawing.Size(549, 13);
            this.lblDownloadSource.TabIndex = 12;
            this.lblDownloadSource.Text = "The path to the selected Dropbox file which can be downloaded with the DownloadSe" +
    "lectedFile function";
            // 
            // btnOpenDialogManualDownload
            // 
            this.btnOpenDialogManualDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenDialogManualDownload.Location = new System.Drawing.Point(17, 19);
            this.btnOpenDialogManualDownload.Name = "btnOpenDialogManualDownload";
            this.btnOpenDialogManualDownload.Size = new System.Drawing.Size(711, 45);
            this.btnOpenDialogManualDownload.TabIndex = 14;
            this.btnOpenDialogManualDownload.Text = "Show Open Dialog";
            this.btnOpenDialogManualDownload.UseVisualStyleBackColor = true;
            this.btnOpenDialogManualDownload.Click += new System.EventHandler(this.btnOpenDialogManualDownload_Click);
            // 
            // btnSaveDialogManualUpload
            // 
            this.btnSaveDialogManualUpload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveDialogManualUpload.Location = new System.Drawing.Point(17, 19);
            this.btnSaveDialogManualUpload.Name = "btnSaveDialogManualUpload";
            this.btnSaveDialogManualUpload.Size = new System.Drawing.Size(711, 45);
            this.btnSaveDialogManualUpload.TabIndex = 14;
            this.btnSaveDialogManualUpload.Text = "Show Open Dialog";
            this.btnSaveDialogManualUpload.UseVisualStyleBackColor = true;
            this.btnSaveDialogManualUpload.Click += new System.EventHandler(this.btnSaveDialogManualUpload_Click);
            // 
            // txtUploadTarget
            // 
            this.txtUploadTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUploadTarget.Location = new System.Drawing.Point(17, 102);
            this.txtUploadTarget.Name = "txtUploadTarget";
            this.txtUploadTarget.ReadOnly = true;
            this.txtUploadTarget.Size = new System.Drawing.Size(711, 22);
            this.txtUploadTarget.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(642, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "The path to the selected Dropbox target where a local file can be uploaded to wit" +
    "h the UploadFileToCurrentFolder function";
            // 
            // btnSaveDialogAutoUpload
            // 
            this.btnSaveDialogAutoUpload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveDialogAutoUpload.Location = new System.Drawing.Point(20, 82);
            this.btnSaveDialogAutoUpload.Name = "btnSaveDialogAutoUpload";
            this.btnSaveDialogAutoUpload.Size = new System.Drawing.Size(711, 45);
            this.btnSaveDialogAutoUpload.TabIndex = 14;
            this.btnSaveDialogAutoUpload.Text = "Show Save Dialog";
            this.btnSaveDialogAutoUpload.UseVisualStyleBackColor = true;
            this.btnSaveDialogAutoUpload.Click += new System.EventHandler(this.btnSaveDialogAutoUpload_Click);
            // 
            // btnUploadFile
            // 
            this.btnUploadFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUploadFile.Location = new System.Drawing.Point(708, 35);
            this.btnUploadFile.Name = "btnUploadFile";
            this.btnUploadFile.Size = new System.Drawing.Size(23, 22);
            this.btnUploadFile.TabIndex = 10;
            this.btnUploadFile.Text = "…";
            this.btnUploadFile.UseVisualStyleBackColor = true;
            this.btnUploadFile.Click += new System.EventHandler(this.btnUploadFile_Click);
            // 
            // txtUploadFile
            // 
            this.txtUploadFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUploadFile.Location = new System.Drawing.Point(20, 35);
            this.txtUploadFile.Name = "txtUploadFile";
            this.txtUploadFile.Size = new System.Drawing.Size(682, 22);
            this.txtUploadFile.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(348, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Automatically upload this local file to the selected Dropbox target.";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(23, 170);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(762, 176);
            this.tabControl1.TabIndex = 18;
            this.tabControl1.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnOpenDialogAutoDownload);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnDownloadFolder);
            this.tabPage1.Controls.Add(this.txtDownloadFolder);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(754, 150);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Open Dialog - Auto Download";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnOpenDialogManualDownload);
            this.tabPage2.Controls.Add(this.txtDownloadSource);
            this.tabPage2.Controls.Add(this.lblDownloadSource);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(754, 150);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Open Dialog - Manual Download";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnSaveDialogAutoUpload);
            this.tabPage3.Controls.Add(this.txtUploadFile);
            this.tabPage3.Controls.Add(this.btnUploadFile);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(754, 150);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Save Dialog - Auto Upload";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnSaveDialogManualUpload);
            this.tabPage4.Controls.Add(this.txtUploadTarget);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(754, 150);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Save Dialog - Manual Upload";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(103)))), ((int)(((byte)(140)))));
            this.label4.Location = new System.Drawing.Point(434, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(366, 117);
            this.label4.TabIndex = 20;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // lblAppKey
            // 
            this.lblAppKey.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(103)))), ((int)(((byte)(140)))));
            this.lblAppKey.Location = new System.Drawing.Point(23, 170);
            this.lblAppKey.Name = "lblAppKey";
            this.lblAppKey.Size = new System.Drawing.Size(762, 176);
            this.lblAppKey.TabIndex = 21;
            this.lblAppKey.Text = "Before using this demonstration form, you must provide an application key for the" +
    " Dropbox API.\r\n\r\nSet the DropboxExplorer.Configuration.DropboxAppKey value to yo" +
    "ur app key.";
            this.lblAppKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAppKey.Visible = false;
            // 
            // FormExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(809, 369);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblAppKey);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormExample";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DropboxExplorer Test Application";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDownloadFolder;
        private System.Windows.Forms.TextBox txtDownloadFolder;
        private System.Windows.Forms.Button btnOpenDialogAutoDownload;
        private System.Windows.Forms.TextBox txtDownloadSource;
        private System.Windows.Forms.Label lblDownloadSource;
        private System.Windows.Forms.Button btnOpenDialogManualDownload;
        private System.Windows.Forms.Button btnUploadFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUploadFile;
        private System.Windows.Forms.Button btnSaveDialogAutoUpload;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUploadTarget;
        private System.Windows.Forms.Button btnSaveDialogManualUpload;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAppKey;
    }
}

