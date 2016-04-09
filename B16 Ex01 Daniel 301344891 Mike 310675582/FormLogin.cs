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
        private static bool s_RememberMe = false;

        public static bool RememberMe { get { return s_RememberMe; } set { s_RememberMe = value; } }

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
            bool v_Autologin = true;
            loginFunction(!v_Autologin);
        }

        private void loginFunction(bool i_AutoLogin)
        {
            LoginResult result = login(i_AutoLogin);

            if ((result != null) && (result.AccessToken != null))
            {
                m_LoginLoginFunctions.SaveRememberBox(cbRememberMe.Checked);
                s_RememberMe = cbRememberMe.Checked;
        
                m_MainForm = new FormMain();
                m_MainForm.LoginUser = result.LoggedInUser;
                m_MainForm.Closed += (s, args) => this.Close();
                m_MainForm.ehMainFormLoad += new EventHandler<MainFormLoadEventArgs>(mainForm_ehMainFormLoad);
                
                m_FormLoader.Shown += (s, args) => this.Hide();
                m_FormLoader.Shown += new EventHandler(initiateForm);
                m_FormLoader.FormClosed += m_FormLoader_FormClosed;
                m_FormLoader.Show();
            }
        }

        void m_FormLoader_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_MainForm.ShowDialog();
        }

        private void initiateForm(object sender, EventArgs e)
        {
            Thread thread = new Thread(m_MainForm.InitiateForm);
            thread.Start();
        }

        private void mainForm_ehMainFormLoad(object sender, MainFormLoadEventArgs e)
        {
            if (e != null)
            {
                if ((e.Message != null) && (e.Message.Length > 0))
                {
                    m_FormLoader.LoadingLabel = e.Message;
                }

                if (e.FinishedLoading)
                {
                    m_FormLoader.FinishLoading();
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
            if ((result != null) && (string.IsNullOrEmpty(result.AccessToken)))
            {
                MessageBox.Show(result.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.RememberMe)
            {
                bool v_AutoLogin = true;
                loginFunction(v_AutoLogin);
                this.Opacity = 0;
            }
        }

        private void loginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((cbRememberMe.Checked) && (!s_RememberMe))
            {
                s_RememberMe = false;
            }
                
            Properties.Settings.Default.RememberMe = s_RememberMe;
            Properties.Settings.Default.Save();
        }
    }
}
