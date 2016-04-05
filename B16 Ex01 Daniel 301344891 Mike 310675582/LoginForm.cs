using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Facebook;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace FacebookSmartView
{
    public partial class LoginForm : Form
    {

        // Private variables
        private LoginLogic m_llFunctions; // Class To handle login form 
       

        public LoginForm()
        {
            InitializeComponent();
            m_llFunctions = new LoginLogic();
            cbRememberMe.Checked = m_llFunctions.getRememberBoxCheckedValue();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            LoginFunction(false);
        }

        private void LoginFunction(Boolean i_bAutoLogin)
        {
            LoginResult result = login(i_bAutoLogin);

            if ((result != GeneralVars.k_NULL) && (result.AccessToken != GeneralVars.k_NULL))
            {
                m_llFunctions.saveRememberBox(cbRememberMe.Checked);
                MainForm mainForm = new MainForm();

                this.Hide();
                mainForm.LoginUser = result.LoggedInUser;
                mainForm.Closed += (s, args) => this.Close();
                
                mainForm.Show();

                mainForm.ehMainFormLoad += new EventHandler<MainFormLoadEventArgs>()
    fnf.FirstNameUpdated += new EventHandler<NameUpdatedEventArgs>(fnf_FirstNameUpdated);

            }
        }

        void mainForm_ehMainFormLoad(object sender, MainFormLoadEventArgs e)
        {
            throw new NotImplementedException();
        }

        private LoginResult login(Boolean i_bautoLogin)
        {
            LoginResult result = null;

            string lastAccessToken = m_llFunctions.getSavedAccessToken();

            //first login attemt
            if (String.IsNullOrEmpty(lastAccessToken))
            {
                result = m_llFunctions.loginToFacbookAndSaveToken();
            }
            //quicklogin using saved settings
            else
            {
                 DialogResult loginDialogResult = DialogResult.None;
                if (!i_bautoLogin)
                {
                    loginDialogResult = MessageBox.Show
                       ("The Application noticed that you have logged in before.\nWould you like to use the same user?", "Quick Login",
                       MessageBoxButtons.YesNo);
                }
                 //login as a last used user
                 if (loginDialogResult == DialogResult.Yes || i_bautoLogin)
                    {
                        try
                        {
                            result = m_llFunctions.connectToFacebook(lastAccessToken);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    //login as a new user
                    else
                    {
                        result = m_llFunctions.loginToFacbookAndSaveToken();
                    }
                }
                

            if ((result != null) && (string.IsNullOrEmpty(result.AccessToken)))
            {
                MessageBox.Show(result.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.RememberMe == GeneralVars.k_TRUE)
            {
                LoginFunction(GeneralVars.k_TRUE);
                this.Opacity = 0;
            }
        }

       
       
        
        
    }
}
