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
        private LoginLogic llFunctions; // Class To handle login form 

        public LoginForm()
        {
            InitializeComponent();
            llFunctions = new LoginLogic();
            cbRememberMe.Checked = llFunctions.getRememberBoxCheckedValue();
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
                llFunctions.saveRememberBox(cbRememberMe.Checked);
                MainForm mainForm = new MainForm();

                this.Hide();
                mainForm.LoginUser = result.LoggedInUser;
                mainForm.Closed += (s, args) => this.Close();
                mainForm.Show();
            }
        }

        private LoginResult login(Boolean i_bautoLogin)
        {
            LoginResult result = null;

            string lastAccessToken = llFunctions.getSavedAccessToken();

            //first login attemt
            if (String.IsNullOrEmpty(lastAccessToken))
            {
                result = llFunctions.loginToFacbookAndSaveToken();
            }
            //quicklogin using saved settings
            else
            {

                if (!i_bautoLogin)
                {
                    DialogResult loginDialogResult = MessageBox.Show
                       ("The Application noticed that you have logged in before.\nWould you like to use the same user?", "Quick Login",
                       MessageBoxButtons.YesNo);

                    //login as a last used user
                    if (loginDialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            result = llFunctions.connectToFacebook(lastAccessToken);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    //login as a new user
                    else
                    {
                        result = llFunctions.loginToFacbookAndSaveToken();
                    }
                }
                else
                {
                    result = llFunctions.loginToFacebook();
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
             //   LoginFunction(GeneralVars.k_TRUE);
              //  this.Opacity = 0;
            }
        }
        
        
    }
}
