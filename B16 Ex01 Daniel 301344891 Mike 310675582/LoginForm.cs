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
    public partial class LoginForm : Form
    {

        // Private variables
        private LoginLogic m_llFunctions; // Class To handle login form 
        private MainForm m_MainForm;
        private FormLoader m_FormLoader;
        private static Boolean m_RememberMe = GeneralVars.k_FALSE;

        public static Boolean RememberMe { get { return m_RememberMe; } set { m_RememberMe = value; } }

        public LoginForm()
        {
            InitializeComponent();
            m_llFunctions = new LoginLogic();
            m_FormLoader = new FormLoader();

            cbRememberMe.Checked = m_llFunctions.GetRememberBoxCheckedValue();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            LoginFunction(GeneralVars.k_FALSE);
        }

        private void LoginFunction(Boolean i_bAutoLogin)
        {
            LoginResult result = login(i_bAutoLogin);

            if ((result != GeneralVars.k_NULL) && (result.AccessToken != GeneralVars.k_NULL))
            {
                m_llFunctions.SaveRememberBox(cbRememberMe.Checked);
                m_RememberMe = cbRememberMe.Checked;
                
                this.Hide();

                m_MainForm = new MainForm();
                
                m_MainForm.LoginUser = result.LoggedInUser;
                m_MainForm.Closed += (s, args) => this.Close();

                m_MainForm.ehMainFormLoad += new EventHandler<MainFormLoadEventArgs>(mainForm_ehMainFormLoad);
                m_FormLoader.Shown += new EventHandler(initiateForm);
                m_FormLoader.Show();
                

            }
        }

        private void initiateForm(object sender, EventArgs e)
        {
            m_MainForm.initiateForm();
        }

        void mainForm_ehMainFormLoad(object sender, MainFormLoadEventArgs e)
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

        private LoginResult login(Boolean i_bautoLogin)
        {
            LoginResult result = null;

            string lastAccessToken = m_llFunctions.GetSavedAccessToken();

            //first login attemt
            if (String.IsNullOrEmpty(lastAccessToken))
            {
                result = m_llFunctions.LoginToFacbookAndSaveToken();
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
                            result = m_llFunctions.ConnectToFacebook(lastAccessToken);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    //login as a new user
                    else
                    {
                        result = m_llFunctions.LoginToFacbookAndSaveToken();
                    }
                }
                

            if ((result != GeneralVars.k_NULL) && (string.IsNullOrEmpty(result.AccessToken)))
            {
                MessageBox.Show(result.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show(Properties.Settings.Default.RememberMe.ToString());
            if (Properties.Settings.Default.RememberMe == GeneralVars.k_TRUE)
            {
                LoginFunction(GeneralVars.k_TRUE);
                this.Opacity = GeneralVars.k_Zero;
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cbRememberMe.Checked == GeneralVars.k_TRUE && m_RememberMe == GeneralVars.k_FALSE)
                m_RememberMe = GeneralVars.k_FALSE;

            Properties.Settings.Default.RememberMe = m_RememberMe;
            Properties.Settings.Default.Save();
        }

       
       
        
        
    }
}
