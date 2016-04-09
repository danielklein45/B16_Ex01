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

            if (i_PostFilter != null)
            {
                queryPostToDisplay = m_FacebookUser.NewsFeed.Where(post => !i_PostFilter.IsMatch(post) && post.Message != null);
            }
            else
            {
                queryPostToDisplay = m_FacebookUser.NewsFeed.Where(post => post.Message != null);
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
                strSchool = string.Empty;
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
                location = string.Empty;
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
            bool isLike = false;
            Photo phTargetPhoto;

            if (i_ObjectId != string.Empty && i_ObjectId.Length > 0)
            {
                try
                {
                    phTargetPhoto = FacebookWrapper.FacebookService.GetObject<Photo>(i_ObjectId);
                }
                catch
                {
                    phTargetPhoto = null;
                }

                if (phTargetPhoto != null)
                {
                    isLike =  phTargetPhoto.Like();
                }
            }

            return isLike;
        }

        public bool CommentPhoto(string i_ObjectId, string i_CommentText)
        {
            bool retValue = false;
            Photo phTargetPhoto;

            if (i_ObjectId != string.Empty && i_ObjectId.Length > 0)
            {
                if (i_CommentText != string.Empty && i_CommentText.Length > 0)
                {
                    try
                    {
                        phTargetPhoto = FacebookWrapper.FacebookService.GetObject<Photo>(i_ObjectId);
                    }
                    catch
                    {
                        phTargetPhoto = null;
                    }

                    if (phTargetPhoto != null)
                    {
                        Comment cmmToPost = phTargetPhoto.Comment(i_CommentText);
                        retValue = (cmmToPost.Id.Length > 0 ? true : false);
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
                return (m_FacebookUser.Location.Name != null) ? m_FacebookUser.Location.Name : string.Empty;
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
