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
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.lblFilename = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.fileTransfer1 = new DropboxExplorer.FileTransfer();
            this.fileBrowser1 = new DropboxExplorer.FileBrowser();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(500, 15);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 26);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(581, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtFilename
            // 
            this.txtFilename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilename.Enabled = false;
            this.txtFilename.Location = new System.Drawing.Point(80, 16);
            this.txtFilename.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(314, 22);
            this.txtFilename.TabIndex = 1;
            this.txtFilename.TextChanged += new System.EventHandler(this.txtFilename_TextChanged);
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilename.Enabled = false;
            this.lblFilename.Location = new System.Drawing.Point(15, 12);
            this.lblFilename.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(59, 26);
            this.lblFilename.TabIndex = 0;
            this.lblFilename.Text = "File name:";
            this.lblFilename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFilename, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtFilename, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOK, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 655);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(12);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(671, 56);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // fileTransfer1
            // 
            this.fileTransfer1.BackColor = System.Drawing.SystemColors.Window;
            this.fileTransfer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileTransfer1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileTransfer1.Location = new System.Drawing.Point(0, 0);
            this.fileTransfer1.Name = "fileTransfer1";
            this.fileTransfer1.Size = new System.Drawing.Size(671, 655);
            this.fileTransfer1.TabIndex = 2;
            this.fileTransfer1.Visible = false;
            // 
            // fileBrowser1
            // 
            this.fileBrowser1.BackColor = System.Drawing.SystemColors.Window;
            this.fileBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileBrowser1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileBrowser1.Location = new System.Drawing.Point(0, 0);
            this.fileBrowser1.Name = "fileBrowser1";
            this.fileBrowser1.Size = new System.Drawing.Size(671, 655);
            this.fileBrowser1.TabIndex = 0;
            this.fileBrowser1.PathChanged += new System.EventHandler<DropboxExplorer.FileBrowser.ItemSelectedArgs>(this.fileBrowser1_PathChanged);
            this.fileBrowser1.FileSelected += new System.EventHandler<DropboxExplorer.FileBrowser.ItemSelectedArgs>(this.fileBrowser1_FileSelected);
            this.fileBrowser1.FileDoubleClicked += new System.EventHandler<DropboxExplorer.FileBrowser.ItemSelectedArgs>(this.fileBrowser1_FileDoubleClicked);
            // 
            // DropboxDialogBase
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(671, 711);
            this.Controls.Add(this.fileTransfer1);
            this.Controls.Add(this.fileBrowser1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "DropboxDialogBase";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dropbox";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FileBrowser fileBrowser1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label lblFilename;
        private FileTransfer fileTransfer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}