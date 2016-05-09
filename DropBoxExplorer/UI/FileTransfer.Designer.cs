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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblRemaining = new System.Windows.Forms.Label();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.lblRemainingC = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblSource = new System.Windows.Forms.Label();
            this.lblDestination = new System.Windows.Forms.Label();
            this.lblAction = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblRemaining, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.progress, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblRemainingC, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblFileName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFrom, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblSource, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDestination, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblAction, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 78);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 144);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblRemaining
            // 
            this.lblRemaining.AutoEllipsis = true;
            this.lblRemaining.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRemaining.Location = new System.Drawing.Point(113, 82);
            this.lblRemaining.Name = "lblRemaining";
            this.lblRemaining.Size = new System.Drawing.Size(174, 13);
            this.lblRemaining.TabIndex = 7;
            this.lblRemaining.Text = "Calculating...";
            // 
            // progress
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.progress, 2);
            this.progress.Dock = System.Windows.Forms.DockStyle.Top;
            this.progress.Location = new System.Drawing.Point(16, 109);
            this.progress.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(268, 13);
            this.progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progress.TabIndex = 8;
            // 
            // lblRemainingC
            // 
            this.lblRemainingC.AutoSize = true;
            this.lblRemainingC.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRemainingC.Location = new System.Drawing.Point(13, 82);
            this.lblRemainingC.Name = "lblRemainingC";
            this.lblRemainingC.Size = new System.Drawing.Size(94, 13);
            this.lblRemainingC.TabIndex = 6;
            this.lblRemainingC.Text = "Remaining:";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoEllipsis = true;
            this.lblFileName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFileName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.Location = new System.Drawing.Point(113, 10);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(174, 13);
            this.lblFileName.TabIndex = 1;
            this.lblFileName.Text = "?";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFrom.Location = new System.Drawing.Point(13, 34);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(94, 13);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.Text = "From:";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTo.Location = new System.Drawing.Point(13, 58);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(94, 13);
            this.lblTo.TabIndex = 4;
            this.lblTo.Text = "To:";
            // 
            // lblSource
            // 
            this.lblSource.AutoEllipsis = true;
            this.lblSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSource.Location = new System.Drawing.Point(113, 34);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(174, 13);
            this.lblSource.TabIndex = 3;
            this.lblSource.Text = "?";
            // 
            // lblDestination
            // 
            this.lblDestination.AutoEllipsis = true;
            this.lblDestination.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDestination.Location = new System.Drawing.Point(113, 58);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(174, 13);
            this.lblDestination.TabIndex = 5;
            this.lblDestination.Text = "?";
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAction.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAction.Location = new System.Drawing.Point(13, 10);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(94, 13);
            this.lblAction.TabIndex = 0;
            this.lblAction.Text = "Downloading:";
            // 
            // FileTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FileTransfer";
            this.Size = new System.Drawing.Size(300, 300);
            this.Resize += new System.EventHandler(this.FileTransfer_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label lblRemaining;
        private System.Windows.Forms.Label lblRemainingC;
    }
}
