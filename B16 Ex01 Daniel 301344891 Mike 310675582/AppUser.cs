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

        public FacebookObjectCollection<Post> GetNewsFeed()
        {
            FacebookObjectCollection<Post> mostUpdatedPost = new FacebookObjectCollection<Post>();

            IEnumerable<Post> queryAllPostsWithoutNullMessage = m_FacebookUser.NewsFeed.Where(post => post.Message != null);

            foreach (Post post in queryAllPostsWithoutNullMessage)
            {
                mostUpdatedPost.Add(post);
            }

            return mostUpdatedPost;
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
            DateTime dtUserBirthday = Convert.ToDateTime(i_strBirthday);

            return dtCurrentDay.Year - dtUserBirthday.Year;
        }

        public string GetUserProfilePicture()
        {
            return m_FacebookUser.PictureNormalURL;
        }

        public string Post(string i_PostText)
        {
            string statusMessage = string.Empty;

            if (!string.IsNullOrEmpty(i_PostText))
            {
                Status status = m_FacebookUser.PostStatus(i_PostText);
                statusMessage = "Status Posted! ID: " + status.Id;
            }

            return statusMessage;
        }

        public string Name
        {
            get
            {
                return m_FacebookUser.Name;
            }
        }

        public string Birthay
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
