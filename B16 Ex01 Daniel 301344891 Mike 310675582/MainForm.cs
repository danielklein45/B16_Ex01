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

namespace FacebookSmartView
{
    public partial class MainForm : Form
    {
        private AppUser m_AppUser;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            fetchUserInfo();
        }

        private void fetchUserInfo()
        {
            fetchUserPrivateDetails();
            fetchNewsFeed();
        }

        private void fetchNewsFeed()
        {
            listBoxNewsFeed.DataSource = m_AppUser.GetNewsFeed();
            listBoxNewsFeed.DisplayMember = "Message";
            listBoxNewsFeed.ValueMember = "UpdateTime";
        }

        private void fetchUserPrivateDetails()
        {
            lblUserName.Text = m_AppUser.Name;
            lblBirthdayValue.Text = m_AppUser.Birthay;
            lblGenderValue.Text = m_AppUser.Gender;
            pbUserPicture.LoadAsync(m_AppUser.GetUserProfilePicture());
        }

        private void buttonPostQuickStatus_Click(object sender, EventArgs e)
        {
            string statusMessage = m_AppUser.Post(textBoxPostMessage.Text);
            MessageBox.Show(statusMessage);
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
