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
		public event EventHandler<MainFormLoadEventArgs> ehMainFormLoad;

		public FormMain()
		{
			InitializeComponent();
			m_PopPanelMgt = PopularPanelMgt.Instance;
			PopularPanelMgt.Instance.SetPanels(panelMostPopular, gpTopPhotosInfoBox);
			m_PopPanelMgt.InformationLabel = lblMetaDataAboutPicture;
			m_PopPanelMgt.InformationTextbox = txtPostCommentOnPhoto;

			txtPostCommentOnPhoto.Text = GeneralVars.K_MessageOnTxtboxCommentPhoto;
			m_PostFilter = new PostFilter();
		}

		protected virtual void OnMainFormUpdateStatus(MainFormLoadEventArgs i_MainFormArgs)
		{
			if (ehMainFormLoad != GeneralVars.k_NULL)
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
			MainFormLoadEventArgs mflEs = new MainFormLoadEventArgs();

			m_PopPanelMgt.TryAddToPanel(new SpecialPictureBox(panelMostPopular));
			m_PopPanelMgt.TryAddToPanel(new SpecialPictureBox(panelMostPopular));
			m_PopPanelMgt.TryAddToPanel(new SpecialPictureBox(panelMostPopular));
			m_PopPanelMgt.TryAddToPanel(new SpecialPictureBox(panelMostPopular));

			List<SpecialPictureBox> lstSpBoxFromPopPanel = m_PopPanelMgt.PictureObjectList;
			m_TopPhotosFeature = new TopPhotosFeature(m_AppUser, ref lstSpBoxFromPopPanel);
			
			updateFormLoader(GeneralVars.k_FALSE, "Loading User info...");
			fetchUserInfo();

			updateFormLoader(GeneralVars.k_FALSE, "Ranking User Photos...");
			m_TopPhotosFeature.RankUserPhotos();

			updateFormLoader(GeneralVars.k_FALSE, "Loading User Photos...");
			m_TopPhotosFeature.LoadTopPhotos();

			updateFormLoader(GeneralVars.k_TRUE,GeneralVars.k_EmptyString );
			OnMainFormUpdateStatus(mflEs);
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
			if (m_AppUser.Age > GeneralVars.k_Zero)
			{
				firstPart = "You are a " + m_AppUser.Age + " years old " + m_AppUser.Gender + ".";
			}
			else
			{
				firstPart = "You are a " + m_AppUser.Gender + " and were born in " + m_AppUser.Birthday + ".";
			}

			string secondPart = GeneralVars.k_EmptyString;
			string thirdPart = GeneralVars.k_EmptyString;

			if (m_AppUser.UserLivesIn != GeneralVars.k_EmptyString)
			{
				secondPart = "You live in " + m_AppUser.UserLivesIn + ".";
			}
			else
			{
				secondPart = GeneralVars.k_EmptyString;
			}

			if (m_AppUser.LastEducationStudyPlace != GeneralVars.k_EmptyString)
			{
				thirdPart += "You studied at " + m_AppUser.LastEducationStudyPlace + ".";
			}
			else
			{
				thirdPart += "You should add more information about yourself...";
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
				if (m_AppUser == GeneralVars.k_NULL)
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

				if (selectedPost != GeneralVars.k_NULL)
				{
					pictureBoxPostImage.Load(selectedPost.PictureURL);
					string postDetails = string.Format("Posted by: {0}\nOn Date: {1}", selectedPost.From.Name, selectedPost.CreatedTime.ToString());
					lblPostDetails.Text = postDetails;
				}
			}
		}

		private void buttonLikePicture_Click(object sender, EventArgs e)
		{
			if (m_PopPanelMgt.CurrentObjectID != GeneralVars.k_EmptyString)
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
			if (m_PopPanelMgt.CurrentObjectID != GeneralVars.k_EmptyString)
			{
				if (txtPostCommentOnPhoto.Text.Length > GeneralVars.k_Zero && txtPostCommentOnPhoto.Text != GeneralVars.K_MessageOnTxtboxCommentPhoto)
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
			FormLogin.RememberMe = GeneralVars.k_FALSE;
			this.Close();
		}
	}
}
