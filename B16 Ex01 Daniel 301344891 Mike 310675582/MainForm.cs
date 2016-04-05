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

namespace FacebookSmartView
{
	public partial class MainForm : Form
	{
		private AppUser m_AppUser;
		private PostFilter m_PostFilter;
		private TopPhotosFeature m_TopPhotosFeature;
		private PopularPanelMgt m_PopPanelMgt;

		public MainForm()
		{
			InitializeComponent();
			m_PopPanelMgt = PopularPanelMgt.Instance;
			PopularPanelMgt.Instance.setPanels(panelMostPopular, gpTopPhotosInfoBox);
			m_PopPanelMgt.InformationLabel = lblMetaDataAboutPicture;
			m_PopPanelMgt.InformationTextbox = txtPostCommentOnPhoto;
			m_PostFilter = new PostFilter();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			m_PopPanelMgt.tryAddToPanel(new SpecialPictureBox(panelMostPopular));
			m_PopPanelMgt.tryAddToPanel(new SpecialPictureBox(panelMostPopular));
			m_PopPanelMgt.tryAddToPanel(new SpecialPictureBox(panelMostPopular));
			m_PopPanelMgt.tryAddToPanel(new SpecialPictureBox(panelMostPopular));

			List<SpecialPictureBox> lstSpBoxFromPopPanel =  m_PopPanelMgt.PictureObjectList;
			m_TopPhotosFeature = new TopPhotosFeature(m_AppUser, ref lstSpBoxFromPopPanel);


			fetchUserInfo();
			m_TopPhotosFeature.rankUserPhotos();
			m_TopPhotosFeature.loadTopPhotos();

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
			string k_firstPart = "You are a " + m_AppUser.Age + " years old " + m_AppUser.Gender;
			string str_secondPart = "";
			string str_thirdPart = "";

			if(m_AppUser.UserLivesIn != ""){
				str_secondPart = " that lives in " +m_AppUser.UserLivesIn + ".";
			}
			else{
				str_secondPart =".";
			}

			if(m_AppUser.LastEducationStudyPlace != ""){
				str_thirdPart += "You studied at " + m_AppUser.LastEducationStudyPlace + ".";
			}
			else
				str_thirdPart += "You should add more information about yourself...";

			return k_firstPart + str_secondPart + str_thirdPart;
		}

		private void buttonPostQuickStatus_Click(object sender, EventArgs e)
		{
			string statusMessage = m_AppUser.Post(textBoxPostMessage.Text);
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

	}
}
