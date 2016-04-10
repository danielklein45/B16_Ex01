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
	public partial class FormMain : Form
	{
		private AppUser m_AppUser;
		private PostFilter m_PostFilter;
		private TopPhotosFeature m_TopPhotosFeature;
		private PopularPanelMgt m_PopPanelMgt;
		private const int k_NumberOfSpecialPictures = 4;
		private const string k_MessageOnTxtboxCommentPhoto = "Write a comment...";
		public event EventHandler<MainFormLoadEventArgs> ehMainFormLoad;

		public FormMain()
		{
			InitializeComponent();
			m_PopPanelMgt = PopularPanelMgt.Instance;
			PopularPanelMgt.Instance.SetPanels(panelMostPopular, gpTopPhotosInfoBox);
			m_PopPanelMgt.InformationLabel = lblMetaDataAboutPicture;
			m_PopPanelMgt.InformationTextbox = txtPostCommentOnPhoto;

			txtPostCommentOnPhoto.Text = k_MessageOnTxtboxCommentPhoto;
			m_PostFilter = new PostFilter();
		}

		protected virtual void OnMainFormUpdateStatus(MainFormLoadEventArgs i_MainFormArgs)
		{
			if (ehMainFormLoad != null)
			{
				ehMainFormLoad(this, i_MainFormArgs);
			}
		}

		private void updateFormLoader(bool i_IsFinishedLoading, string i_Message)
		{
			MainFormLoadEventArgs e = new MainFormLoadEventArgs();

			e.FinishedLoading = i_IsFinishedLoading;
			e.Message = i_Message;
			OnMainFormUpdateStatus(e);
		}

		public void InitiateForm()
		{
			bool v_FinishedLoading = true;
			
			for (int i = 0; i < k_NumberOfSpecialPictures; ++i )
			{
				m_PopPanelMgt.TryAddToPanel(new SpecialPictureBox(panelMostPopular));
			}

			List<SpecialPictureBox> lstSpBoxFromPopPanel = m_PopPanelMgt.PictureObjectList;
			m_TopPhotosFeature = new TopPhotosFeature(m_AppUser, ref lstSpBoxFromPopPanel);

			updateFormLoader(!v_FinishedLoading, "Loading User info...");
			fetchUserInfo();

			updateFormLoader(!v_FinishedLoading, "Ranking User Photos...");
			m_TopPhotosFeature.RankUserPhotos();

			updateFormLoader(!v_FinishedLoading, "Loading User Photos...");
			m_TopPhotosFeature.LoadTopPhotos();

			updateFormLoader(v_FinishedLoading,string.Empty );
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
			pbUserPicture.Load(m_AppUser.GetUserProfilePicture());
		}

		private string buildUserPrivateAbout()
		{
			string firstPart;
			if (m_AppUser.Age > 0)
			{
				firstPart = "You are a " + m_AppUser.Age + " years old " + m_AppUser.Gender + ".\n";
			}
			else
			{
				firstPart = "You are a " + m_AppUser.Gender + " and were born in " + m_AppUser.Birthday + ".\n";
			}

			string secondPart = string.Empty;
			string thirdPart = string.Empty;

			if (m_AppUser.UserLivesIn != string.Empty)
			{
				secondPart = "You live in " + m_AppUser.UserLivesIn + ".\n";
			}
			else
			{
				secondPart = string.Empty;
			}

			if (m_AppUser.LastEducationStudyPlace != string.Empty)
			{
				thirdPart += "You studied at " + m_AppUser.LastEducationStudyPlace + ".\n";
			}
			else
			{
				thirdPart += "You should add more information about yourself...\n";
			}
				
			return firstPart + secondPart + thirdPart;
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
			FormPostFilterSettings filterSettingsDialog = new FormPostFilterSettings();
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
				string postDetails = string.Empty;

				if (selectedPost != null)
				{
					if (selectedPost.PictureURL != null)
					{
						pictureBoxPostImage.Load(selectedPost.PictureURL);
						postDetails = string.Format("Posted by: {0}\nOn Date: {1}", selectedPost.From.Name, selectedPost.CreatedTime.ToString());
					}
					else
					{
						pictureBoxPostImage.Image = null;
						postDetails = "No picture available";
					}
				}

				lblPostDetails.Text = postDetails;
			}
		}

		private void buttonLikePicture_Click(object sender, EventArgs e)
		{
			if (m_PopPanelMgt.CurrentObjectID != string.Empty)
			{
				if (m_AppUser.LikePhoto(m_PopPanelMgt.CurrentObjectID))
				{
					MessageBox.Show("You successfully liked that photo.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("Can't Like again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show("Please select a one of the pictures.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void buttonCommentPicture_Click(object sender, EventArgs e)
		{
			if (m_PopPanelMgt.CurrentObjectID != string.Empty)
			{
				if (txtPostCommentOnPhoto.Text.Length > 0 && txtPostCommentOnPhoto.Text != k_MessageOnTxtboxCommentPhoto)
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

			txtPostCommentOnPhoto.Text = k_MessageOnTxtboxCommentPhoto;
		}

		private void buttonSignOff_Click(object sender, EventArgs e)
		{
			FormLogin.RememberMe = false;
			this.Close();
		}
	}
}
