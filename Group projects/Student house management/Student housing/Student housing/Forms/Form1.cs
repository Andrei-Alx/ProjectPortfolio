using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Student_housing
{
    public partial class LOGIN : Form
    {
        User currentUser;
        Admin currentAdmin;
        ClassesManager classesManager;
        List<string> CardIDs = new List<string>();
        bool isLoggedInAsAdmin = false;


        //Constructor(s)
        public LOGIN()
        {
            classesManager = new ClassesManager();
            CardIDs.Add("2458546972");
            InitializeComponent();

            if (serialPort.IsOpen)
            {
                serialPort.Open();
            }
            
            timer1.Start();
        }

        public LOGIN(User currentUser, UserManager userManager, ClassesManager classesManager)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            this.classesManager = classesManager;
        }
        public LOGIN(Admin currentAdmin, UserManager userManager, ClassesManager classesManager)
        {
            InitializeComponent();
            this.currentAdmin = currentAdmin;
            this.classesManager = classesManager;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            serialPort.Close();
        }

        private void btLogIn_Click(object sender, EventArgs e)
        {
            string username = Convert.ToString(tbxUsername.Text);
            string password = Convert.ToString(tbxPassword.Text);

            
            if (classesManager.UserManager.CheckUser(username, password) == true)
            {
                User currentUser = classesManager.UserManager.getUser(username, password);
                STUDENT studentForm = new STUDENT(classesManager.UserManager, currentUser, classesManager);
                studentForm.Show();
                Hide();
                
            }
            else if (classesManager.UserManager.CheckUserAdmin(username, password) == true )
            {
                Admin currentAdmin = classesManager.UserManager.getAdmin(username, password);
                ADMIN adminForm = new ADMIN(classesManager.UserManager, currentAdmin, classesManager);
                adminForm.Show();
                Hide();
            }
            else if (isLoggedInAsAdmin == true)
            {
                Admin currentAdmin = classesManager.UserManager.getAdmin("Admin", "1234");
                ADMIN adminForm = new ADMIN(classesManager.UserManager, currentAdmin, classesManager);
                adminForm.Show();
                Hide();
            }
            else
                MessageBox.Show("Incorrect password or username");


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(serialPort.IsOpen == true)
            {
                if (serialPort.BytesToRead > 0)
                {
                    string input = serialPort.ReadLine();
                    input = input.Trim();
                    for (int i = 0; i < CardIDs.Count; i++)
                    {
                        if (input == CardIDs[i])
                        {
                            string message = "AccesGranted";
                            isLoggedInAsAdmin = true;
                            serialPort.WriteLine(message);
                            MessageBox.Show($"{message}");
                            if (isLoggedInAsAdmin == true)
                            {
                                Admin currentAdmin = classesManager.UserManager.getAdmin("Admin", "1234");
                                ADMIN adminForm = new ADMIN(classesManager.UserManager, currentAdmin, classesManager);
                                adminForm.Show();
                                Hide();
                            }
                        }
                        else
                        {
                            string message = "AccesDenied";
                            isLoggedInAsAdmin = false;
                            serialPort.WriteLine(message);
                            MessageBox.Show($"{message}");
                        }
                    }
                }
            }
            else
            {
                serialPort.Close();
                
            }
        }
    }
}
