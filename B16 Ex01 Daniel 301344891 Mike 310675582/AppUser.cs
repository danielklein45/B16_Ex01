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

        public AppUser(User i_FacebookUser)
        {
            FacebookWrapper.FacebookService.s_CollectionLimit = 500;
            m_FacebookUser = i_FacebookUser;
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

        public string GetUserProfilePicture()
        {
            return m_FacebookUser.PictureNormalURL;
        }
            
        public string Name
        {
            get
            {
                return m_FacebookUser.Name;
            }
        }
    }
}
