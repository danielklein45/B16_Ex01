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
            m_FacebookUser = i_FacebookUser;
        }

        public FacebookObjectCollection<Post> GetNewsFeed()
        {
            return m_FacebookUser.NewsFeed;
        }
    }
}
