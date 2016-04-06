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
            this.label2 = new System.Windows.Forms.Label();
            this.panelNewsFeedActions = new System.Windows.Forms.Panel();
            this.checkBoxFilterPosts = new System.Windows.Forms.CheckBox();
            this.buttonFilterPostSettings = new System.Windows.Forms.Button();
            this.lblNewsFeedActions = new System.Windows.Forms.Label();
            this.panelPostDetails = new System.Windows.Forms.Panel();
            this.lblHeaderPostDetails = new System.Windows.Forms.Label();
            this.lblPostDetails = new System.Windows.Forms.Label();
            this.pictureBoxPostImage = new System.Windows.Forms.PictureBox();
            this.buttonSignOff = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserPicture)).BeginInit();
            this.panelMostPopular.SuspendLayout();
            this.gpTopPhotosInfoBox.SuspendLayout();
            this.panelBriefNews.SuspendLayout();
            this.panelPost.SuspendLayout();
            this.gpInfo.SuspendLayout();
            this.panelNewsFeedActions.SuspendLayout();
            this.panelPostDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPostImage)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxNewsFeed
            // 
            this.listBoxNewsFeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxNewsFeed.FormattingEnabled = true;
            this.listBoxNewsFeed.HorizontalScrollbar = true;
            this.listBoxNewsFeed.Location = new System.Drawing.Point(3, 32);
            this.listBoxNewsFeed.Name = "listBoxNewsFeed";
            this.listBoxNewsFeed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listBoxNewsFeed.Size = new System.Drawing.Size(428, 394);
            this.listBoxNewsFeed.TabIndex = 0;
            this.listBoxNewsFeed.SelectedIndexChanged += new System.EventHandler(this.listBoxNewsFeed_SelectedIndexChanged);
            // 
            // textBoxPostMessage
            // 
            this.textBoxPostMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPostMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBoxPostMessage.Location = new System.Drawing.Point(3, 12);
            this.textBoxPostMessage.Name = "textBoxPostMessage";
            this.textBoxPostMessage.Size = new System.Drawing.Size(531, 24);
            this.textBoxPostMessage.TabIndex = 3;
            this.textBoxPostMessage.Text = "Hmm what\'s on your mind...";
            // 
            // pbUserPicture
            // 
            this.pbUserPicture.Location = new System.Drawing.Point(12, 18);
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
            this.buttonPostQuickStatus.Location = new System.Drawing.Point(540, 10);
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
            this.panelMostPopular.Location = new System.Drawing.Point(3, 320);
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
            this.buttonLikePicture.Location = new System.Drawing.Point(598, 26);
            this.buttonLikePicture.Name = "buttonLikePicture";
            this.buttonLikePicture.Size = new System.Drawing.Size(118, 29);
            this.buttonLikePicture.TabIndex = 4;
            this.buttonLikePicture.Text = "Like";
            this.buttonLikePicture.UseVisualStyleBackColor = true;
            this.buttonLikePicture.Click += new System.EventHandler(this.buttonLikePicture_Click);
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
            this.buttonCommentPicture.Click += new System.EventHandler(this.buttonCommentPicture_Click);
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
            this.panelBriefNews.Controls.Add(this.lblTopHeaderEvents);
            this.panelBriefNews.Location = new System.Drawing.Point(734, 132);
            this.panelBriefNews.Name = "panelBriefNews";
            this.panelBriefNews.Size = new System.Drawing.Size(434, 429);
            this.panelBriefNews.TabIndex = 10;
            // 
            // lblTopHeaderEvents
            // 
            this.lblTopHeaderEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTopHeaderEvents.AutoSize = true;
            this.lblTopHeaderEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopHeaderEvents.Location = new System.Drawing.Point(95, 6);
            this.lblTopHeaderEvents.Name = "lblTopHeaderEvents";
            this.lblTopHeaderEvents.Size = new System.Drawing.Size(240, 20);
            this.lblTopHeaderEvents.TabIndex = 12;
            this.lblTopHeaderEvents.Text = "Here is a brief of your news feed:";
            // 
            // lblTopHeaderTopPhotos
            // 
            this.lblTopHeaderTopPhotos.AutoSize = true;
            this.lblTopHeaderTopPhotos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopHeaderTopPhotos.Location = new System.Drawing.Point(8, 297);
            this.lblTopHeaderTopPhotos.Name = "lblTopHeaderTopPhotos";
            this.lblTopHeaderTopPhotos.Size = new System.Drawing.Size(347, 20);
            this.lblTopHeaderTopPhotos.TabIndex = 11;
            this.lblTopHeaderTopPhotos.Text = "These are the top 4 most popular photos of you:";
            // 
            // panelPost
            // 
            this.panelPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPost.Controls.Add(this.textBoxPostMessage);
            this.panelPost.Controls.Add(this.buttonPostQuickStatus);
            this.panelPost.Location = new System.Drawing.Point(435, 9);
            this.panelPost.Name = "panelPost";
            this.panelPost.Size = new System.Drawing.Size(634, 44);
            this.panelPost.TabIndex = 19;
            // 
            // gpInfo
            // 
            this.gpInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gpInfo.Controls.Add(this.lblPersonalInfo);
            this.gpInfo.Location = new System.Drawing.Point(197, 59);
            this.gpInfo.Name = "gpInfo";
            this.gpInfo.Size = new System.Drawing.Size(232, 137);
            this.gpInfo.TabIndex = 20;
            // 
            // lblPersonalInfo
            // 
            this.lblPersonalInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonalInfo.Location = new System.Drawing.Point(4, 9);
            this.lblPersonalInfo.Name = "lblPersonalInfo";
            this.lblPersonalInfo.Size = new System.Drawing.Size(223, 127);
            this.lblPersonalInfo.TabIndex = 0;
            this.lblPersonalInfo.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Post Details";
            // 
            // panelNewsFeedActions
            // 
            this.panelNewsFeedActions.Controls.Add(this.checkBoxFilterPosts);
            this.panelNewsFeedActions.Controls.Add(this.buttonFilterPostSettings);
            this.panelNewsFeedActions.Controls.Add(this.lblNewsFeedActions);
            this.panelNewsFeedActions.Location = new System.Drawing.Point(734, 74);
            this.panelNewsFeedActions.Name = "panelNewsFeedActions";
            this.panelNewsFeedActions.Size = new System.Drawing.Size(434, 55);
            this.panelNewsFeedActions.TabIndex = 21;
            // 
            // checkBoxFilterPosts
            // 
            this.checkBoxFilterPosts.AutoSize = true;
            this.checkBoxFilterPosts.Location = new System.Drawing.Point(95, 29);
            this.checkBoxFilterPosts.Name = "checkBoxFilterPosts";
            this.checkBoxFilterPosts.Size = new System.Drawing.Size(105, 17);
            this.checkBoxFilterPosts.TabIndex = 2;
            this.checkBoxFilterPosts.Text = "Filter News Feed";
            this.checkBoxFilterPosts.UseVisualStyleBackColor = true;
            this.checkBoxFilterPosts.CheckedChanged += new System.EventHandler(this.checkBoxFilterPosts_CheckedChanged);
            // 
            // buttonFilterPostSettings
            // 
            this.buttonFilterPostSettings.Location = new System.Drawing.Point(220, 26);
            this.buttonFilterPostSettings.Name = "buttonFilterPostSettings";
            this.buttonFilterPostSettings.Size = new System.Drawing.Size(163, 23);
            this.buttonFilterPostSettings.TabIndex = 1;
            this.buttonFilterPostSettings.Text = "Filter Settings";
            this.buttonFilterPostSettings.UseVisualStyleBackColor = true;
            this.buttonFilterPostSettings.Click += new System.EventHandler(this.buttonFilterPostSettings_Click);
            // 
            // lblNewsFeedActions
            // 
            this.lblNewsFeedActions.AutoSize = true;
            this.lblNewsFeedActions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewsFeedActions.Location = new System.Drawing.Point(146, 6);
            this.lblNewsFeedActions.Name = "lblNewsFeedActions";
            this.lblNewsFeedActions.Size = new System.Drawing.Size(140, 16);
            this.lblNewsFeedActions.TabIndex = 0;
            this.lblNewsFeedActions.Text = "News Feed actions";
            this.lblNewsFeedActions.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelPostDetails
            // 
            this.panelPostDetails.Controls.Add(this.lblHeaderPostDetails);
            this.panelPostDetails.Controls.Add(this.lblPostDetails);
            this.panelPostDetails.Controls.Add(this.pictureBoxPostImage);
            this.panelPostDetails.Location = new System.Drawing.Point(433, 74);
            this.panelPostDetails.Name = "panelPostDetails";
            this.panelPostDetails.Size = new System.Drawing.Size(291, 240);
            this.panelPostDetails.TabIndex = 22;
            // 
            // lblHeaderPostDetails
            // 
            this.lblHeaderPostDetails.AutoSize = true;
            this.lblHeaderPostDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderPostDetails.Location = new System.Drawing.Point(104, 6);
            this.lblHeaderPostDetails.Name = "lblHeaderPostDetails";
            this.lblHeaderPostDetails.Size = new System.Drawing.Size(92, 16);
            this.lblHeaderPostDetails.TabIndex = 2;
            this.lblHeaderPostDetails.Text = "Post Details";
            // 
            // lblPostDetails
            // 
            this.lblPostDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblPostDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblPostDetails.Location = new System.Drawing.Point(13, 29);
            this.lblPostDetails.Name = "lblPostDetails";
            this.lblPostDetails.Size = new System.Drawing.Size(266, 58);
            this.lblPostDetails.TabIndex = 1;
            this.lblPostDetails.Text = "<details>";
            this.lblPostDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBoxPostImage
            // 
            this.pictureBoxPostImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pictureBoxPostImage.Location = new System.Drawing.Point(116, 90);
            this.pictureBoxPostImage.Name = "pictureBoxPostImage";
            this.pictureBoxPostImage.Size = new System.Drawing.Size(172, 147);
            this.pictureBoxPostImage.TabIndex = 0;
            this.pictureBoxPostImage.TabStop = false;
            // 
            // buttonSignOff
            // 
            this.buttonSignOff.Location = new System.Drawing.Point(1078, 20);
            this.buttonSignOff.Name = "buttonSignOff";
            this.buttonSignOff.Size = new System.Drawing.Size(83, 26);
            this.buttonSignOff.TabIndex = 22;
            this.buttonSignOff.Text = "Sign Off";
            this.buttonSignOff.UseVisualStyleBackColor = true;
            this.buttonSignOff.Click += new System.EventHandler(this.buttonSignOff_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1173, 575);
            this.Controls.Add(this.panelPostDetails);
            this.Controls.Add(this.panelNewsFeedActions);
            this.Controls.Add(this.buttonSignOff);
            this.Controls.Add(this.gpInfo);
            this.Controls.Add(this.panelPost);
            this.Controls.Add(this.lblTopHeaderTopPhotos);
            this.Controls.Add(this.panelBriefNews);
            this.Controls.Add(this.panelMostPopular);
            this.Controls.Add(this.lblBasicInfo);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblHello);
            this.Controls.Add(this.pbUserPicture);
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
            this.panelBriefNews.PerformLayout();
            this.panelPost.ResumeLayout(false);
            this.panelPost.PerformLayout();
            this.gpInfo.ResumeLayout(false);
            this.panelNewsFeedActions.ResumeLayout(false);
            this.panelNewsFeedActions.PerformLayout();
            this.panelPostDetails.ResumeLayout(false);
            this.panelPostDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPostImage)).EndInit();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelNewsFeedActions;
        private System.Windows.Forms.Label lblNewsFeedActions;
        private System.Windows.Forms.Label lblMetaDataAboutPicture;
        private System.Windows.Forms.Button buttonFilterPostSettings;
        private System.Windows.Forms.CheckBox checkBoxFilterPosts;
        private System.Windows.Forms.Panel panelPostDetails;
        private System.Windows.Forms.PictureBox pictureBoxPostImage;
        private System.Windows.Forms.Label lblHeaderPostDetails;
        private System.Windows.Forms.Label lblPostDetails;
        private System.Windows.Forms.Button buttonSignOff;
    }
}

