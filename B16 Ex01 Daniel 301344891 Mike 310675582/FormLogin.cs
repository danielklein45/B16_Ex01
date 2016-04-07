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
using System.Threading;

namespace FacebookSmartView
{
    public partial class FormLogin : Form
    {
        // Private variables
        private LoginLogic m_LoginLoginFunctions; // Class To handle login form 
        private FormMain m_MainForm;
        private FormLoader m_FormLoader;
        private static bool m_RememberMe = GeneralVars.k_FALSE;

        public static bool RememberMe { get { return m_RememberMe; } set { m_RememberMe = value; } }

        public FormLogin()
        {
            InitializeComponent();
            m_LoginLoginFunctions = new LoginLogic();
            m_FormLoader = new FormLoader();

            cbRememberMe.Checked = m_LoginLoginFunctions.GetRememberBoxCheckedValue();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            loginFunction(GeneralVars.k_FALSE);
        }

        private void loginFunction(bool i_AutoLogin)
        {
            LoginResult result = login(i_AutoLogin);

            if ((result != GeneralVars.k_NULL) && (result.AccessToken != GeneralVars.k_NULL))
            {
                m_LoginLoginFunctions.SaveRememberBox(cbRememberMe.Checked);
                m_RememberMe = cbRememberMe.Checked;
        
                m_MainForm = new FormMain();
                m_MainForm.LoginUser = result.LoggedInUser;
                m_MainForm.Closed += (s, args) => this.Close();
                m_MainForm.ehMainFormLoad += new EventHandler<MainFormLoadEventArgs>(mainForm_ehMainFormLoad);
                
                m_FormLoader.Shown += (s, args) => this.Hide();
                m_FormLoader.Shown += new EventHandler(initiateForm);
                m_FormLoader.Show();
            }
        }

        private void initiateForm(object sender, EventArgs e)
        {
            m_MainForm.InitiateForm();
        }

        private void mainForm_ehMainFormLoad(object sender, MainFormLoadEventArgs e)
        {
            if (e != GeneralVars.k_NULL )
            {
                if (e.Message.Length > GeneralVars.k_Zero)
                {
                    m_FormLoader.LoadingLabel = e.Message;
                    MessageBox.Show(e.Message);
                }

                if (e.FinishedLoading == GeneralVars.k_TRUE)
                {
                    m_FormLoader.Close();
                    m_MainForm.Show();
                }
            }
        }

        private LoginResult login(bool i_AutoLogin)
        {
            LoginResult result = null;

            string lastAccessToken = m_LoginLoginFunctions.GetSavedAccessToken();

            //first login attempt
            if (String.IsNullOrEmpty(lastAccessToken))
            {
                result = m_LoginLoginFunctions.LoginToFacbookAndSaveToken();
            }
            //quicklogin using saved settings
            else
            {
                 DialogResult loginDialogResult = DialogResult.None;
                 if (!i_AutoLogin)
                {
                    loginDialogResult = MessageBox.Show
                       ("The Application noticed that you have logged in before.\nWould you like to use the same user?", "Quick Login",
                       MessageBoxButtons.YesNo);
                }
                //login as a last used user
                 if (loginDialogResult == DialogResult.Yes || i_AutoLogin)
                {
                    try
                    {
                        result = m_LoginLoginFunctions.ConnectToFacebook(lastAccessToken);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //login as a new user
                else
                {
                    result = m_LoginLoginFunctions.LoginToFacbookAndSaveToken();
                }
            }
            if ((result != GeneralVars.k_NULL) && (string.IsNullOrEmpty(result.AccessToken)))
            {
                MessageBox.Show(result.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.RememberMe == GeneralVars.k_TRUE)
            {
                loginFunction(GeneralVars.k_TRUE);
                this.Opacity = GeneralVars.k_Zero;
            }
        }

        private void loginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cbRememberMe.Checked == GeneralVars.k_TRUE && m_RememberMe == GeneralVars.k_FALSE)
            {
                m_RememberMe = GeneralVars.k_FALSE;
            }
                
            Properties.Settings.Default.RememberMe = m_RememberMe;
            Properties.Settings.Default.Save();
        }
    }
}
