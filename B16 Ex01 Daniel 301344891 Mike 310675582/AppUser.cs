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
        private int m_userAge;
        private string m_userLastEduStudyPlace;
        private string m_userLivesIn;

        public AppUser(User i_FacebookUser)
        {
            FacebookWrapper.FacebookService.s_CollectionLimit = 500;
            m_FacebookUser = i_FacebookUser;

            m_userAge = calcUserAge(m_FacebookUser.Birthday);
            m_userLastEduStudyPlace = getLastEdu(m_FacebookUser.Educations);
            m_userLivesIn = getUserLivePlace(m_FacebookUser.Location);
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
        private string getLastEdu(Education[] i_eduForUser)
        {

            string strSchool;
            try
            {
                strSchool = i_eduForUser.Last<Education>().School.Name;
            }
            catch
            {
                strSchool = "";
            }

            return strSchool;
        }


        private string getUserLivePlace(City i_userLoc)
        {

            string strLocation;
            try
            {
                strLocation = m_FacebookUser.Location.Name;
            }
            catch
            {
                strLocation = "";
            }

            return strLocation;
        }

        public FacebookObjectCollection<Album> getUserAlbums()
        {
            return m_FacebookUser.Albums;
        }

        private int calcUserAge(string i_strBirthday)
        {
            DateTime dtCurrentDay = DateTime.Today;
            DateTime dtUserBirthday;
            try
            {
                dtUserBirthday = Convert.ToDateTime(i_strBirthday);
            }
            catch { dtUserBirthday = dtCurrentDay; }


            return dtCurrentDay.Year - dtUserBirthday.Year;
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
            if (i_ObjectId != "" && i_ObjectId.Length > 0)
            {
                Photo phTargetPhoto = null;
                try
                {
                    phTargetPhoto = FacebookWrapper.FacebookService.GetObject<Photo>(i_ObjectId);
                }
                catch { }
                if (phTargetPhoto != null)
                {
                    return phTargetPhoto.Like();
                }
                else
                {
                    return GeneralVars.k_FALSE;

                }
            }
            return false;
        }

        public bool CommentPhoto(string i_ObjectId, string i_strCommentText)
        {
            if (i_ObjectId != "" && i_ObjectId.Length > 0)
            {
                if (i_strCommentText != "" && i_strCommentText.Length > 0)
                {
                    Photo phTargetPhoto = null;
                    try
                    {
                        phTargetPhoto = FacebookWrapper.FacebookService.GetObject<Photo>(i_ObjectId);
                    }
                    catch { }
                    if (phTargetPhoto != null)
                    {
                        Comment cmmToPost = phTargetPhoto.Comment(i_strCommentText);
                        return (cmmToPost.Id.Length > 0 ? GeneralVars.k_TRUE : GeneralVars.k_FALSE);
                    }
                    else
                    {
                        return GeneralVars.k_FALSE;

                    }

                }
                return false;

            }

            return false;
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
                return m_userAge;
            }
        }

        public string UserLivesIn
        {
            get
            {

                return (m_FacebookUser.Location.Name != null) ? m_FacebookUser.Location.Name : "";
            }
        }

        public string LastEducationStudyPlace
        {
            get
            {
                return m_userLastEduStudyPlace;
            }

        }
    }
}
