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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSource = new System.Windows.Forms.Label();
            this.lblDestination = new System.Windows.Forms.Label();
            this.lblAction = new System.Windows.Forms.Label();
            this.busyIcon1 = new DropboxExplorer.BusyIcon();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.busyIcon1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblSource, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDestination, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblAction, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(26, 127);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(417, 135);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(13, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(13, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Destination:";
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSource.Location = new System.Drawing.Point(95, 48);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(309, 13);
            this.lblSource.TabIndex = 2;
            this.lblSource.Text = "?";
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDestination.Location = new System.Drawing.Point(95, 86);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(309, 13);
            this.lblDestination.TabIndex = 3;
            this.lblDestination.Text = "?";
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblAction, 2);
            this.lblAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAction.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAction.Location = new System.Drawing.Point(13, 10);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(391, 13);
            this.lblAction.TabIndex = 4;
            this.lblAction.Text = "Downloading file...";
            // 
            // busyIcon1
            // 
            this.busyIcon1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.busyIcon1.Image = ((System.Drawing.Image)(resources.GetObject("busyIcon1.Image")));
            this.busyIcon1.Location = new System.Drawing.Point(223, 81);
            this.busyIcon1.Name = "busyIcon1";
            this.busyIcon1.Size = new System.Drawing.Size(24, 24);
            this.busyIcon1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.busyIcon1.TabIndex = 7;
            this.busyIcon1.TabStop = false;
            // 
            // FileTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.busyIcon1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FileTransfer";
            this.Size = new System.Drawing.Size(468, 279);
            this.Resize += new System.EventHandler(this.FileTransfer_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.busyIcon1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BusyIcon busyIcon1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.Label lblAction;
    }
}
