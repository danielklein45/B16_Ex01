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
        private string m_aboutString = "";

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
            lblUserName.Text = m_AppUser.Name + "!";
            lblPersonalInfo.Text = buildUserPrivateAbout();
            pbUserPicture.LoadAsync(m_AppUser.GetUserProfilePicture());
            
        }

        private string buildUserPrivateAbout()
        {
            string k_firstPart = "You are a " + m_AppUser.Age + " years old" + m_AppUser.Gender;
            string str_secondPart = "";
            string str_thirdPart = "";

            if(m_AppUser.UserLivesIn != ""){
                str_secondPart = " that lives in " +m_AppUser.UserLivesIn + ".";
            }
            else{
                str_secondPart =".";
            }

            if(m_AppUser.LastEducationStudyPlace != ""){
                str_thirdPart += "You studied at " + m_AppUser.LastEducationStudyPlace + ".";
            }
            else
                str_thirdPart += "You should add more information about yourself...";

            return k_firstPart + str_secondPart + str_thirdPart;
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
