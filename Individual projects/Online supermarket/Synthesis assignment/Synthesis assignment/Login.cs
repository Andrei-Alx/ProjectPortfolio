using Logic;
using Data;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data;
using System.Net;
using User = Logic.User;

namespace Synthesis_assignment
{
    public partial class Login : Form
    {
        private LoginManager loginManager;
        private UserManager userManager;
        private IDbUserHelper dbUserHelper = new DbUserHelper();
        public Login()
        {
            InitializeComponent();
            userManager = new UserManager(dbUserHelper);
            loginManager = new LoginManager();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User? user = new User();
            try
            {
                if (EmailValidation.IsValidUsername(tbUsername.Text) == true)
                {
                    user = loginManager.Login(tbUsername.Text, tbPassword.Text);
                }
                else
                {
                    user = null;
                    MessageBox.Show("Email is in the wrong format");
                }
                if (user != null)
                {
                    if (user.GetType(user.Role) == "ShopWorker")
                    {
                        tbPassword.Text = String.Empty;

                        WorkerDashboard productManagementForm = new WorkerDashboard();
                        productManagementForm.Show();
                        this.Hide();
                    }
                    else if (user.GetType(user.Role) == "Customer")
                    {
                        throw new Exception("You are not authorized to access the desktop application");
                    }
                    else
                    {
                        throw new Exception("Invalid Credentials");
                    }
                }
                else
                {
                    throw new Exception("Invalid Credentials");
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (userManager.CreateUser(tbUsername.Text, tbPassword.Text, UserRoles.ShopWorker) == true)
                {
                    MessageBox.Show("New account succesfully created!");
                }
                else 
                {
                    MessageBox.Show("Invalid credentials!");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
	}
}