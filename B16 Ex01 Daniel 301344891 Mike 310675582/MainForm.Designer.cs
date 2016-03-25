namespace B16_Ex01_Daniel_301344891_Mike_310675582
{
    partial class MainForm
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
            this.listBoxNewsFeed = new System.Windows.Forms.ListBox();
            this.labelPostMessage = new System.Windows.Forms.Label();
            this.textBoxPostMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBoxNewsFeed
            // 
            this.listBoxNewsFeed.FormattingEnabled = true;
            this.listBoxNewsFeed.Location = new System.Drawing.Point(475, 94);
            this.listBoxNewsFeed.Name = "listBoxNewsFeed";
            this.listBoxNewsFeed.Size = new System.Drawing.Size(498, 160);
            this.listBoxNewsFeed.TabIndex = 0;
            // 
            // labelPostMessage
            // 
            this.labelPostMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPostMessage.AutoSize = true;
            this.labelPostMessage.Location = new System.Drawing.Point(472, 18);
            this.labelPostMessage.Name = "labelPostMessage";
            this.labelPostMessage.Size = new System.Drawing.Size(198, 13);
            this.labelPostMessage.TabIndex = 2;
            this.labelPostMessage.Text = "What Do You Have In Mind Right Now?";
            this.labelPostMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxPostMessage
            // 
            this.textBoxPostMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPostMessage.Location = new System.Drawing.Point(475, 55);
            this.textBoxPostMessage.Name = "textBoxPostMessage";
            this.textBoxPostMessage.Size = new System.Drawing.Size(498, 20);
            this.textBoxPostMessage.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 316);
            this.Controls.Add(this.textBoxPostMessage);
            this.Controls.Add(this.labelPostMessage);
            this.Controls.Add(this.listBoxNewsFeed);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Facebook";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxNewsFeed;
        private System.Windows.Forms.Label labelPostMessage;
        private System.Windows.Forms.TextBox textBoxPostMessage;
    }
}

