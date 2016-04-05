using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Facebook;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace FacebookSmartView
{
	class LoginLogic
	{
		// Private Variables
		private const string k_AppID = "1222488951112730";
		private readonly string[] r_RequiredPermissions = 
		{
			"user_about_me",
			"user_posts",
			"public_profile", 
			"user_education_history",
			"user_birthday",
			"user_friends",
			"publish_actions",
			"user_likes",
			"user_photos",
			"user_posts",
			"user_relationships"
            //daniel klein
		};

		// Public Functions

		public string getSavedAccessToken()
		{
			return Properties.Settings.Default.SavedAccessToken;
		}

		public void saveAccessToken(string i_AccessToken)
		{
			Properties.Settings.Default.SavedAccessToken = i_AccessToken;
			Properties.Settings.Default.Save();
		}

		public LoginResult loginToFacebook()
		{
			return FacebookService.Login(k_AppID, r_RequiredPermissions);
		}

		public LoginResult loginToFacbookAndSaveToken()
		{
			LoginResult result = loginToFacebook();
			saveAccessToken(result.AccessToken);

			return result;
		}

		public LoginResult connectToFacebook(string i_LastAccToken)
		{
			return FacebookService.Connect(i_LastAccToken);
		}

		public void saveRememberBox(bool i_bCheckBoxValue)
		{
			Properties.Settings.Default.RememberMe = i_bCheckBoxValue;
			Properties.Settings.Default.Save();
		}

		public bool getRememberBoxCheckedValue()
		{
			return Properties.Settings.Default.RememberMe;
		}
	}

}