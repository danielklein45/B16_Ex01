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

namespace B16_Ex01_Daniel_301344891_Mike_310675582
{
    public partial class MainForm : Form
    {
        private AppUser m_AppUser;

        public MainForm()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 10;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            fetchUserInfo();
        }

        private void fetchUserInfo()
        {
            listBoxNewsFeed.DataSource = m_AppUser.GetNewsFeed();
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
    }
}
