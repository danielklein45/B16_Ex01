using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FacebookWrapper.ObjectModel;
using System.Threading;

namespace FacebookSmartView
{
    public partial class MainForm : Form
    {
        private AppUser m_AppUser;
		private PostFilter m_PostFilter;
        private TopPhotosFeature m_TopPhotosFeature;
        private PopularPanelMgt m_PopPanelMgt;
        public event EventHandler<MainFormLoadEventArgs> ehMainFormLoad;

        public MainForm()
        {
            InitializeComponent();
            m_PopPanelMgt = PopularPanelMgt.Instance;
            PopularPanelMgt.Instance.setPanels(panelMostPopular, gpTopPhotosInfoBox);
            m_PopPanelMgt.InformationLabel = lblMetaDataAboutPicture;
            m_PopPanelMgt.InformationTextbox = txtPostCommentOnPhoto;

            txtPostCommentOnPhoto.Text = GeneralVars.K_MessageOnTxtboxCommentPhoto;

			m_PostFilter = new PostFilter();
        }

        public virtual void onMainFormUpdateStatus(MainFormLoadEventArgs i_mainFormArgs)
        {
            if (ehMainFormLoad != null)
            {
                ehMainFormLoad(this, i_mainFormArgs);
            }
        }
        public void initiateForm()
        {
            MainFormLoadEventArgs mflEs = new MainFormLoadEventArgs();
            
            m_PopPanelMgt.tryAddToPanel(new SpecialPictureBox(panelMostPopular));
            m_PopPanelMgt.tryAddToPanel(new SpecialPictureBox(panelMostPopular));
            m_PopPanelMgt.tryAddToPanel(new SpecialPictureBox(panelMostPopular));
            m_PopPanelMgt.tryAddToPanel(new SpecialPictureBox(panelMostPopular));

            List<SpecialPictureBox> lstSpBoxFromPopPanel = m_PopPanelMgt.PictureObjectList;
            m_TopPhotosFeature = new TopPhotosFeature(m_AppUser, ref lstSpBoxFromPopPanel);

            mflEs.FinishedLoading = false;
            mflEs.Message = "Loading User info...";
            onMainFormUpdateStatus(mflEs);

            fetchUserInfo();


            mflEs.FinishedLoading = false;
            mflEs.Message = "Ranking User Photos...";
            onMainFormUpdateStatus(mflEs);

            m_TopPhotosFeature.rankUserPhotos();

            mflEs.FinishedLoading = false;
            mflEs.Message = "Loading User Photos...";
            onMainFormUpdateStatus(mflEs);

            m_TopPhotosFeature.loadTopPhotos();

            mflEs.FinishedLoading = true;
            mflEs.Message = "Form Loaded.";
            onMainFormUpdateStatus(mflEs);
            
        }

        private void fetchUserInfo()
        {
            fetchUserPrivateDetails();
            fetchNewsFeed();
        }

        private void fetchNewsFeed()
        {
			PostFilter filter = null;

			if (checkBoxFilterPosts.Checked)
			{
				filter = m_PostFilter;
			}

			listBoxNewsFeed.DataSource = m_AppUser.GetNewsFeed(filter);
            listBoxNewsFeed.DisplayMember = "Message";
            listBoxNewsFeed.ValueMember = "UpdateTime";
        }

        private void fetchUserPrivateDetails()
        {
            lblUserName.Text = m_AppUser.Name + "!";
            lblPersonalInfo.Text = buildUserPrivateAbout();
            pbUserPicture.LoadAsync(m_AppUser.GetUserProfilePicture());

        }

        private string buildUserPrivateAbout()
        {
            string k_firstPart;
            if (m_AppUser.Age > 0)
            {
                k_firstPart = "You are a " + m_AppUser.Age + " years old " + m_AppUser.Gender + ".";
            }
            else
            {
                k_firstPart = "You are a " + m_AppUser.Gender + " and were born in " + m_AppUser.Birthday + ".";
            }

            string str_secondPart = "";
            string str_thirdPart = "";

            if (m_AppUser.UserLivesIn != "")
            {
                str_secondPart = "You live in " + m_AppUser.UserLivesIn + ".";
            }
            else
            {
                str_secondPart = "";
            }

            if (m_AppUser.LastEducationStudyPlace != "")
            {
                str_thirdPart += "You studied at " + m_AppUser.LastEducationStudyPlace + ".";
            }
            else
                str_thirdPart += "You should add more information about yourself...";

            return k_firstPart + str_secondPart + str_thirdPart;
        }

        private void buttonPostQuickStatus_Click(object sender, EventArgs e)
        {
            string statusMessage = m_AppUser.PostToUserWall(textBoxPostMessage.Text);
            MessageBox.Show(statusMessage);
        }

        public User LoginUser
        {
            set
            {
                if (m_AppUser == null)
                {
                    m_AppUser = new AppUser(value);
                }
			   
			}
		}

		private void buttonFilterPostSettings_Click(object sender, EventArgs e)
		{
			PostFilterSettingsForm filterSettingsDialog = new PostFilterSettingsForm();
			filterSettingsDialog.PostFilter = m_PostFilter;
			filterSettingsDialog.ShowDialog();
			fetchNewsFeed();
			m_PostFilter.Save();
		}

		private void checkBoxFilterPosts_CheckedChanged(object sender, EventArgs e)
		{
			fetchNewsFeed();
		}

		private void listBoxNewsFeed_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listBoxNewsFeed.SelectedItems.Count == 1)
			{
				Post selectedPost = listBoxNewsFeed.SelectedItem as Post;

				if (selectedPost != null)
				{
					pictureBoxPostImage.LoadAsync(selectedPost.PictureURL);
					string postDetails = string.Format("Posted by: {0}\nOn Date: {1}", selectedPost.From.Name, selectedPost.CreatedTime.ToString());
					lblPostDetails.Text = postDetails;
				}
            }
        }

        private void buttonLikePicture_Click(object sender, EventArgs e)
        {
            if (m_PopPanelMgt.CurrentObjectID != "")
            {
                if (m_AppUser.LikePhoto(m_PopPanelMgt.CurrentObjectID))
                {
                    MessageBox.Show("You successfully liked that photo.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                {
                    MessageBox.Show("Oops, something went wrong trying to like that photo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a one of the pictures.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCommentPicture_Click(object sender, EventArgs e)
        {
            if (m_PopPanelMgt.CurrentObjectID != "")
            {
                if (txtPostCommentOnPhoto.Text.Length > 0 && txtPostCommentOnPhoto.Text != GeneralVars.K_MessageOnTxtboxCommentPhoto)
                {
                    if (m_AppUser.CommentPhoto(m_PopPanelMgt.CurrentObjectID, txtPostCommentOnPhoto.Text))
                    {
                        MessageBox.Show("You successfully liked that photo.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Oops, something went wrong trying to comment that photo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Oops, did you forget to write a comment?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else
            {
                MessageBox.Show("Please select a one of the pictures.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtPostCommentOnPhoto.Text = GeneralVars.K_MessageOnTxtboxCommentPhoto;
        }

        private void buttonSignOff_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.RememberMe = GeneralVars.k_FALSE;
           // this.Close();
        }


        

    }
}
