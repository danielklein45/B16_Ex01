using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Facebook;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace FacebookSmartView
{
	public partial class LoginForm : Form
	{
		private const string k_AppID = "1222488951112730";

		private readonly string[] r_RequiredPermissions = 
		{
			"user_about_me",
			"user_posts",
			"public_profile", 
			"user_education_history",
            "user_work_history",
			"user_birthday",
			"user_friends",
			"publish_actions",
			"user_likes",
			"user_photos",
			"user_posts",
			"user_relationships",
            "user_location"
		};

		public LoginForm()
		{
			InitializeComponent();
		}

		private void buttonExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        private void LoginFunction(Boolean i_bAutoLogin)
        {
            LoginResult result = login(i_bAutoLogin);

            if ((result != null) && (result.AccessToken != null))
            {
                saveRememberBox(cbRememberMe.Checked);
                MainForm mainForm = new MainForm();

                mainForm.LoginUser = result.LoggedInUser;
                this.Hide();
                mainForm.Closed += (s, args) => this.Close();
                mainForm.Show();
            }
        }

		private void buttonLogin_Click(object sender, EventArgs e)
		{
            LoginFunction(false);
		}

		private string getSavedAccessToken()
		{
			return Properties.Settings.Default.SavedAccessToken;
		}

		private void saveAccessToken(string i_AccessToken)
		{
			Properties.Settings.Default.SavedAccessToken = i_AccessToken;
			Properties.Settings.Default.Save();
		}
        private void saveRememberBox(bool i_bCheckBoxValue)
        {
            Properties.Settings.Default.RememberMe = i_bCheckBoxValue;
            Properties.Settings.Default.Save();
        }

		private LoginResult loginToFacbookAndSaveToken()
		{
			LoginResult result = FacebookService.Login(k_AppID, r_RequiredPermissions);
			saveAccessToken(result.AccessToken);

			return result;
		}

        private LoginResult preformAutoLogin()
        {
            return FacebookService.Login(k_AppID, r_RequiredPermissions);
        }

		private LoginResult login(Boolean i_bautoLogin)
		{
			LoginResult result = null;

			string lastAccessToken = getSavedAccessToken();

			//first login attemt
			if (String.IsNullOrEmpty(lastAccessToken))
			{
				result = loginToFacbookAndSaveToken();
			}
			//quicklogin using saved settings
			else
			{
                if (!i_bautoLogin)
                {
                    DialogResult loginDialogResult = MessageBox.Show
                        ("The Application noticed that you have logged in before.\nWould you like to use the same user?", "Quick Login",
                        MessageBoxButtons.YesNo);

                    //login as a last used user
                    if (loginDialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            result = FacebookService.Connect(lastAccessToken);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    //login as a new user
                    else
                    {
                        result = loginToFacbookAndSaveToken();
                    }
                }
                else
                {
                    result = preformAutoLogin();
                }
			}

			if ((result != null) && (string.IsNullOrEmpty(result.AccessToken)))
			{
				MessageBox.Show(result.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return result;
		}

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.RememberMe == true)
            {
                LoginFunction(Properties.Settings.Default.RememberMe);
            }
        }
	}
}
