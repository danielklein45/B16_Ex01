namespace FacebookSmartView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listBoxNewsFeed = new System.Windows.Forms.ListBox();
            this.textBoxPostMessage = new System.Windows.Forms.TextBox();
            this.pbUserPicture = new System.Windows.Forms.PictureBox();
            this.lblHello = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblBasicInfo = new System.Windows.Forms.Label();
            this.buttonPostQuickStatus = new System.Windows.Forms.Button();
            this.panelMostPopular = new System.Windows.Forms.Panel();
            this.gpTopPhotosInfoBox = new System.Windows.Forms.Panel();
            this.lblMetaDataAboutPicture = new System.Windows.Forms.Label();
            this.buttonLikePicture = new System.Windows.Forms.Button();
            this.buttonCommentPicture = new System.Windows.Forms.Button();
            this.txtPostCommentOnPhoto = new System.Windows.Forms.TextBox();
            this.panelBriefNews = new System.Windows.Forms.Panel();
            this.lblTopHeaderEvents = new System.Windows.Forms.Label();
            this.lblTopHeaderTopPhotos = new System.Windows.Forms.Label();
            this.panelPost = new System.Windows.Forms.Panel();
            this.gpInfo = new System.Windows.Forms.Panel();
            this.lblPersonalInfo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserPicture)).BeginInit();
            this.panelMostPopular.SuspendLayout();
            this.gpTopPhotosInfoBox.SuspendLayout();
            this.panelBriefNews.SuspendLayout();
            this.panelPost.SuspendLayout();
            this.gpInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxNewsFeed
            // 
            this.listBoxNewsFeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxNewsFeed.FormattingEnabled = true;
            this.listBoxNewsFeed.Location = new System.Drawing.Point(3, 32);
            this.listBoxNewsFeed.Name = "listBoxNewsFeed";
            this.listBoxNewsFeed.Size = new System.Drawing.Size(428, 394);
            this.listBoxNewsFeed.TabIndex = 0;
            // 
            // textBoxPostMessage
            // 
            this.textBoxPostMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPostMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPostMessage.Location = new System.Drawing.Point(3, 9);
            this.textBoxPostMessage.Name = "textBoxPostMessage";
            this.textBoxPostMessage.Size = new System.Drawing.Size(587, 26);
            this.textBoxPostMessage.TabIndex = 3;
            this.textBoxPostMessage.Text = "Hmm what\'s on your mind...";
            // 
            // pbUserPicture
            // 
            this.pbUserPicture.Location = new System.Drawing.Point(12, 12);
            this.pbUserPicture.Name = "pbUserPicture";
            this.pbUserPicture.Size = new System.Drawing.Size(179, 178);
            this.pbUserPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUserPicture.TabIndex = 4;
            this.pbUserPicture.TabStop = false;
            // 
            // lblHello
            // 
            this.lblHello.AutoSize = true;
            this.lblHello.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHello.Location = new System.Drawing.Point(197, 12);
            this.lblHello.Name = "lblHello";
            this.lblHello.Size = new System.Drawing.Size(37, 20);
            this.lblHello.TabIndex = 5;
            this.lblHello.Text = "Hey";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(231, 12);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(118, 20);
            this.lblUserName.TabIndex = 6;
            this.lblUserName.Text = "<User Name>";
            // 
            // lblBasicInfo
            // 
            this.lblBasicInfo.AutoSize = true;
            this.lblBasicInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBasicInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBasicInfo.Location = new System.Drawing.Point(197, 36);
            this.lblBasicInfo.Name = "lblBasicInfo";
            this.lblBasicInfo.Size = new System.Drawing.Size(155, 20);
            this.lblBasicInfo.TabIndex = 7;
            this.lblBasicInfo.Text = "Some introduction";
            // 
            // buttonPostQuickStatus
            // 
            this.buttonPostQuickStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPostQuickStatus.Location = new System.Drawing.Point(596, 10);
            this.buttonPostQuickStatus.Name = "buttonPostQuickStatus";
            this.buttonPostQuickStatus.Size = new System.Drawing.Size(83, 26);
            this.buttonPostQuickStatus.TabIndex = 8;
            this.buttonPostQuickStatus.Text = "Post!";
            this.buttonPostQuickStatus.UseVisualStyleBackColor = true;
            this.buttonPostQuickStatus.Click += new System.EventHandler(this.buttonPostQuickStatus_Click);
            // 
            // panelMostPopular
            // 
            this.panelMostPopular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMostPopular.Controls.Add(this.gpTopPhotosInfoBox);
            this.panelMostPopular.Location = new System.Drawing.Point(3, 247);
            this.panelMostPopular.Name = "panelMostPopular";
            this.panelMostPopular.Size = new System.Drawing.Size(731, 239);
            this.panelMostPopular.TabIndex = 9;
            // 
            // gpTopPhotosInfoBox
            // 
            this.gpTopPhotosInfoBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gpTopPhotosInfoBox.Controls.Add(this.lblMetaDataAboutPicture);
            this.gpTopPhotosInfoBox.Controls.Add(this.buttonLikePicture);
            this.gpTopPhotosInfoBox.Controls.Add(this.buttonCommentPicture);
            this.gpTopPhotosInfoBox.Controls.Add(this.txtPostCommentOnPhoto);
            this.gpTopPhotosInfoBox.Location = new System.Drawing.Point(3, 176);
            this.gpTopPhotosInfoBox.Name = "gpTopPhotosInfoBox";
            this.gpTopPhotosInfoBox.Size = new System.Drawing.Size(721, 60);
            this.gpTopPhotosInfoBox.TabIndex = 5;
            // 
            // lblMetaDataAboutPicture
            // 
            this.lblMetaDataAboutPicture.AutoSize = true;
            this.lblMetaDataAboutPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetaDataAboutPicture.Location = new System.Drawing.Point(6, 8);
            this.lblMetaDataAboutPicture.Name = "lblMetaDataAboutPicture";
            this.lblMetaDataAboutPicture.Size = new System.Drawing.Size(311, 18);
            this.lblMetaDataAboutPicture.TabIndex = 6;
            this.lblMetaDataAboutPicture.Tag = "InfoLabel";
            this.lblMetaDataAboutPicture.Text = "Click on one of the pictures to get information.";
            // 
            // buttonLikePicture
            // 
            this.buttonLikePicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLikePicture.Location = new System.Drawing.Point(598, 27);
            this.buttonLikePicture.Name = "buttonLikePicture";
            this.buttonLikePicture.Size = new System.Drawing.Size(118, 29);
            this.buttonLikePicture.TabIndex = 4;
            this.buttonLikePicture.Text = "Like";
            this.buttonLikePicture.UseVisualStyleBackColor = true;
            // 
            // buttonCommentPicture
            // 
            this.buttonCommentPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCommentPicture.Location = new System.Drawing.Point(450, 26);
            this.buttonCommentPicture.Name = "buttonCommentPicture";
            this.buttonCommentPicture.Size = new System.Drawing.Size(142, 29);
            this.buttonCommentPicture.TabIndex = 3;
            this.buttonCommentPicture.Text = "Comment";
            this.buttonCommentPicture.UseVisualStyleBackColor = true;
            // 
            // txtPostCommentOnPhoto
            // 
            this.txtPostCommentOnPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPostCommentOnPhoto.Location = new System.Drawing.Point(3, 31);
            this.txtPostCommentOnPhoto.Name = "txtPostCommentOnPhoto";
            this.txtPostCommentOnPhoto.Size = new System.Drawing.Size(441, 26);
            this.txtPostCommentOnPhoto.TabIndex = 0;
            this.txtPostCommentOnPhoto.Text = "Write a comment...";
            // 
            // panelBriefNews
            // 
            this.panelBriefNews.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBriefNews.Controls.Add(this.listBoxNewsFeed);
            this.panelBriefNews.Location = new System.Drawing.Point(737, 62);
            this.panelBriefNews.Name = "panelBriefNews";
            this.panelBriefNews.Size = new System.Drawing.Size(434, 429);
            this.panelBriefNews.TabIndex = 10;
            // 
            // lblTopHeaderEvents
            // 
            this.lblTopHeaderEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTopHeaderEvents.AutoSize = true;
            this.lblTopHeaderEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopHeaderEvents.Location = new System.Drawing.Point(481, 62);
            this.lblTopHeaderEvents.Name = "lblTopHeaderEvents";
            this.lblTopHeaderEvents.Size = new System.Drawing.Size(240, 20);
            this.lblTopHeaderEvents.TabIndex = 12;
            this.lblTopHeaderEvents.Text = "Here is a brief of your news feed:";
            // 
            // lblTopHeaderTopPhotos
            // 
            this.lblTopHeaderTopPhotos.AutoSize = true;
            this.lblTopHeaderTopPhotos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopHeaderTopPhotos.Location = new System.Drawing.Point(8, 224);
            this.lblTopHeaderTopPhotos.Name = "lblTopHeaderTopPhotos";
            this.lblTopHeaderTopPhotos.Size = new System.Drawing.Size(347, 20);
            this.lblTopHeaderTopPhotos.TabIndex = 11;
            this.lblTopHeaderTopPhotos.Text = "These are the top 4 most popular photos of you:";
            // 
            // panelPost
            // 
            this.panelPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPost.Controls.Add(this.textBoxPostMessage);
            this.panelPost.Controls.Add(this.buttonPostQuickStatus);
            this.panelPost.Location = new System.Drawing.Point(482, 12);
            this.panelPost.Name = "panelPost";
            this.panelPost.Size = new System.Drawing.Size(686, 44);
            this.panelPost.TabIndex = 19;
            // 
            // gpInfo
            // 
            this.gpInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gpInfo.Controls.Add(this.lblPersonalInfo);
            this.gpInfo.Location = new System.Drawing.Point(197, 59);
            this.gpInfo.Name = "gpInfo";
            this.gpInfo.Size = new System.Drawing.Size(213, 131);
            this.gpInfo.TabIndex = 20;
            // 
            // lblPersonalInfo
            // 
            this.lblPersonalInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonalInfo.Location = new System.Drawing.Point(4, 9);
            this.lblPersonalInfo.Name = "lblPersonalInfo";
            this.lblPersonalInfo.Size = new System.Drawing.Size(205, 120);
            this.lblPersonalInfo.TabIndex = 0;
            this.lblPersonalInfo.Text = "label2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(435, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(277, 111);
            this.panel1.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "News Feed actions";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1173, 498);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gpInfo);
            this.Controls.Add(this.panelPost);
            this.Controls.Add(this.lblTopHeaderEvents);
            this.Controls.Add(this.lblTopHeaderTopPhotos);
            this.Controls.Add(this.panelBriefNews);
            this.Controls.Add(this.panelMostPopular);
            this.Controls.Add(this.lblBasicInfo);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblHello);
            this.Controls.Add(this.pbUserPicture);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facebook Smart View";
            ((System.ComponentModel.ISupportInitialize)(this.pbUserPicture)).EndInit();
            this.panelMostPopular.ResumeLayout(false);
            this.gpTopPhotosInfoBox.ResumeLayout(false);
            this.gpTopPhotosInfoBox.PerformLayout();
            this.panelBriefNews.ResumeLayout(false);
            this.panelPost.ResumeLayout(false);
            this.panelPost.PerformLayout();
            this.gpInfo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxNewsFeed;
        private System.Windows.Forms.TextBox textBoxPostMessage;
        private System.Windows.Forms.PictureBox pbUserPicture;
        private System.Windows.Forms.Label lblHello;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblBasicInfo;
        private System.Windows.Forms.Button buttonPostQuickStatus;
        private System.Windows.Forms.Panel panelMostPopular;
        private System.Windows.Forms.Panel panelBriefNews;
        private System.Windows.Forms.Label lblTopHeaderTopPhotos;
        private System.Windows.Forms.Label lblTopHeaderEvents;
        private System.Windows.Forms.Panel gpTopPhotosInfoBox;
        private System.Windows.Forms.Button buttonLikePicture;
        private System.Windows.Forms.Button buttonCommentPicture;
        private System.Windows.Forms.TextBox txtPostCommentOnPhoto;
        private System.Windows.Forms.Panel panelPost;
        private System.Windows.Forms.Panel gpInfo;
        private System.Windows.Forms.Label lblPersonalInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMetaDataAboutPicture;
    }
}

