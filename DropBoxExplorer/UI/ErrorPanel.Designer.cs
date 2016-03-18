namespace DropboxExplorer
{
    partial class ErrorPanel
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
            this.picWarning = new System.Windows.Forms.PictureBox();
            this.lblMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picWarning)).BeginInit();
            this.SuspendLayout();
            // 
            // picWarning
            // 
            this.picWarning.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picWarning.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picWarning.Image = global::DropboxExplorer.Properties.Resources.Exclamation;
            this.picWarning.Location = new System.Drawing.Point(32, 100);
            this.picWarning.Name = "picWarning";
            this.picWarning.Size = new System.Drawing.Size(16, 16);
            this.picWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picWarning.TabIndex = 0;
            this.picWarning.TabStop = false;
            this.picWarning.Click += new System.EventHandler(this.Error_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMessage.AutoEllipsis = true;
            this.lblMessage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMessage.Location = new System.Drawing.Point(54, 100);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(198, 154);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "A problem occurred communicating with Dropbox";
            this.lblMessage.Click += new System.EventHandler(this.Error_Click);
            // 
            // ErrorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.picWarning);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ErrorPanel";
            this.Size = new System.Drawing.Size(300, 300);
            ((System.ComponentModel.ISupportInitialize)(this.picWarning)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picWarning;
        private System.Windows.Forms.Label lblMessage;
    }
}
