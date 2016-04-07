using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FacebookWrapper.ObjectModel;

namespace FacebookSmartView
{
    class AppUser
    {
        private User m_FacebookUser;
        private int m_UserAge;
        private string m_UserLastEduStudyPlace;
        private string m_UserLivesIn;
        private int k_FacebookWrapperCollectionLimit = 500;

        public AppUser(User i_FacebookUser)
        {
            FacebookWrapper.FacebookService.s_CollectionLimit = k_FacebookWrapperCollectionLimit;
            m_FacebookUser = i_FacebookUser;

            m_UserAge = calcUserAge(m_FacebookUser.Birthday);
            m_UserLastEduStudyPlace = getLastEdu(m_FacebookUser.Educations);
            m_UserLivesIn = getUserLivePlace(m_FacebookUser.Location);
        }

        public FacebookObjectCollection<Post> GetNewsFeed(PostFilter i_PostFilter)
        {
            FacebookObjectCollection<Post> postToDisplay = new FacebookObjectCollection<Post>();

            IEnumerable<Post> queryPostToDisplay;

            if (i_PostFilter != GeneralVars.k_NULL)
            {
                queryPostToDisplay = m_FacebookUser.NewsFeed.Where(post => !i_PostFilter.IsMatch(post) && post.Message != null);
            }
            else
            {
                queryPostToDisplay = m_FacebookUser.NewsFeed.Where(post => post.Message != GeneralVars.k_NULL);
            }
            

            foreach (Post post in queryPostToDisplay)
            {
                postToDisplay.Add(post);
            }

            return postToDisplay;
        }
       
        private string getLastEdu(Education[] i_EducationForUser)
        {
            string strSchool;

            try
            {
                strSchool = i_EducationForUser.Last<Education>().School.Name;
            }
            catch
            {
                strSchool = GeneralVars.k_EmptyString;
            }

            return strSchool;
        }

        private string getUserLivePlace(City i_UserLocation)
        {
            string location;
            try
            {
                location = m_FacebookUser.Location.Name;
            }
            catch
            {
                location = GeneralVars.k_EmptyString;
            }

            return location;
        }

        public FacebookObjectCollection<Album> GetUserAlbums()
        {
            return m_FacebookUser.Albums;
        }

        private int calcUserAge(string i_Birthday)
        {
            DateTime dtCurrentDay = DateTime.Today;
            DateTime dtUserBirthday;
            try
            {
                dtUserBirthday = Convert.ToDateTime(i_Birthday);
            }
            catch 
            { 
                dtUserBirthday = dtCurrentDay;
            }

            return (dtCurrentDay.Year - dtUserBirthday.Year);
        }

        public string GetUserProfilePicture()
        {
            return m_FacebookUser.PictureNormalURL;
        }

        public string PostToUserWall(string i_PostText)
        {
            string statusMessage = string.Empty;

            if (!string.IsNullOrEmpty(i_PostText))
            {
                Status status = m_FacebookUser.PostStatus(i_PostText);
                statusMessage = "Status Posted! ID: " + status.Id;
            }

            return statusMessage;
        }

        public bool LikePhoto(string i_ObjectId)
        {
            Photo phTargetPhoto;

            if (i_ObjectId != GeneralVars.k_EmptyString && i_ObjectId.Length > GeneralVars.k_Zero)
            {
                try
                {
                    phTargetPhoto = FacebookWrapper.FacebookService.GetObject<Photo>(i_ObjectId);
                }
                catch
                {
                    phTargetPhoto = null;
                }

                if (phTargetPhoto != GeneralVars.k_NULL)
                {
                    return phTargetPhoto.Like();
                }
            }

            return GeneralVars.k_FALSE;
        }

        public bool CommentPhoto(string i_ObjectId, string i_CommentText)
        {
            bool retValue = GeneralVars.k_FALSE;
            Photo phTargetPhoto;

            if (i_ObjectId != GeneralVars.k_EmptyString && i_ObjectId.Length > GeneralVars.k_Zero)
            {
                if (i_CommentText != GeneralVars.k_EmptyString && i_CommentText.Length > GeneralVars.k_Zero)
                {
                    try
                    {
                        phTargetPhoto = FacebookWrapper.FacebookService.GetObject<Photo>(i_ObjectId);
                    }
                    catch
                    {
                        phTargetPhoto = null;
                    }

                    if (phTargetPhoto != GeneralVars.k_NULL)
                    {
                        Comment cmmToPost = phTargetPhoto.Comment(i_CommentText);
                        retValue = (cmmToPost.Id.Length > GeneralVars.k_Zero ? GeneralVars.k_TRUE : GeneralVars.k_FALSE);
                    }
                }
            }

            return retValue;
        }

        public string Name
        {
            get
            {
                return m_FacebookUser.Name;
            }
        }

        public string Birthday
        {
            get
            {
                return m_FacebookUser.Birthday;
            }
        }

        public string Gender
        {
            get
            {
                return m_FacebookUser.Gender.ToString();
            }
        }

        public int Age
        {
            get
            {
                return m_UserAge;
            }
        }

        public string UserLivesIn
        {
            get
            {
                return (m_FacebookUser.Location.Name != GeneralVars.k_NULL) ? m_FacebookUser.Location.Name : GeneralVars.k_EmptyString;
            }
        }

        public string LastEducationStudyPlace
        {
            get
            {
                return m_UserLastEduStudyPlace;
            }
        }
    }
}
