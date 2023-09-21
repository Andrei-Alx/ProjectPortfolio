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
    public partial class ADMIN : Form
    {
        UserManager userManager;
        Admin admin;
        ClassesManager classesManager;

        //Constructor(s)
        public ADMIN(UserManager userManager, Admin admin, ClassesManager classesManager)
        {
            InitializeComponent();
            this.admin = admin;
            this.userManager = userManager;
            this.classesManager = classesManager;
        }

        private void ADMIN_Load(object sender, EventArgs e)
        {
            tcAdmin.Appearance = TabAppearance.FlatButtons;
            tcAdmin.ItemSize = new Size(0, 1);
            tcAdmin.SizeMode = TabSizeMode.Fixed;
            buttonPannelAdmin.Height = btnUsersAdminTab.Height;
            buttonPannelAdmin.Top = btnUsersAdminTab.Top;

            lblTitle.Text = "Welcome back, " + admin.Username + "!";
            LoadFromFile("../../Resources/Rules");
            LoadFromFile("../../Resources/Guidelines");
            FillComplaintLbx();
            FillComplaintCbx();
            ShowVisits();
            FillTechnicalLbx();
            FillUserData();
        }

        #region <User Manager>

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.ToString();
            string password = textBox2.Text.ToString();
            User newUser = new User(username, password);
            userManager.addUser(newUser);
            classesManager.SerializeObject();
            lbxAllUsers.Items.Clear();
            foreach(User u in userManager.GetUsers())
            {
                lbxAllUsers.Items.Add(u.Username + " " + u.Password);
            }
        }

        public void FillUserData()
        {
            lbxAllUsers.Items.Clear();
            foreach(User u in classesManager.UserManager.GetUsers())
            {
                lbxAllUsers.Items.Add(userManager.GetUserInfo(u));
            }
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            int selectedIndex = lbxAllUsers.SelectedIndex;
            for (int i = 0; i < lbxAllUsers.Items.Count; i++)
            {
                if (selectedIndex == i)
                {
                    lbxAllUsers.Items.RemoveAt(i);
                    userManager.removeUser(userManager.getUserByIndex(i));
                }
            }
            classesManager.SerializeObject();
        }

        private void lbxAllUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = lbxAllUsers.SelectedIndex;
            int i = 0;
            foreach (User user in userManager.GetUsers())
            {
                if (selectedIndex == i)
                {
                    tbModifyUsername.Text = user.Username;
                    tbModifyPassword.Text = user.Password;
                }
                i++;
            }

        }
        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            int selectedIndex = lbxAllUsers.SelectedIndex;
            int i = 0;
            foreach (User user in userManager.GetUsers())
            {
                if (selectedIndex == i)
                {
                    userManager.modifyUser(user, tbModifyUsername.Text, tbModifyPassword.Text);
                }
                i++;
            }
            classesManager.SerializeObject();
            FillUserData();
        }

        #endregion <User Manager>

        #region <Tab control design>

        private void btnUsersAdminTab_Click(object sender, EventArgs e)
        {
            tcAdmin.SelectedTab = tpAdminUsers;
            buttonPannelAdmin.Height = btnUsersAdminTab.Height;
            buttonPannelAdmin.Top = btnUsersAdminTab.Top;
        }

        private void btnComplaintsAdminTab_Click(object sender, EventArgs e)
        {
            tcAdmin.SelectedTab = tpAdminComplaints;
            buttonPannelAdmin.Height = btnComplaintsAdminTab.Height;
            buttonPannelAdmin.Top = btnComplaintsAdminTab.Top;
        }

        private void btnTechnicalAdminTab_Click(object sender, EventArgs e)
        {
            tcAdmin.SelectedTab = tpAdminTechnical;
            buttonPannelAdmin.Height = btnTechnicalAdminTab.Height;
            buttonPannelAdmin.Top = btnTechnicalAdminTab.Top;
        }

        private void btnRuesAdminTab_Click(object sender, EventArgs e)
        {
            tcAdmin.SelectedTab = tpAdminRules;
            buttonPannelAdmin.Height = btnRulesAdminTab.Height;
            buttonPannelAdmin.Top = btnRulesAdminTab.Top;
        }
        #endregion

        #region <Rules and guidelines>
        public void LoadFromFile(string filename)
        {
            FileStream fs = null;
            StreamReader sr = null;

            try
            {
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                fs.Seek(0, SeekOrigin.Begin);
                sr = new StreamReader(fs);
                if(filename == "../../Resources/Rules")
                {
                        rtbRules.Text = sr.ReadToEnd();
                }
                else if (filename == "../../Resources/Guidelines")
                {
                        rtbGuidelines.Text = sr.ReadToEnd();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
        }

        public void WriteToFile(string filename, string text)
        {
            FileStream fs = null;
            StreamWriter sw = null;

            try
            {
                fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
                fs.SetLength(0);
                sw = new StreamWriter(fs);
                sw.WriteLine(text);
            }
            catch (IOException exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string rules = rtbRules.Text.ToString();
            string guidelines = rtbGuidelines.Text.ToString();
            WriteToFile("../../Resources/Rules", rules);
            WriteToFile("../../Resources/Guidelines", guidelines);
        }

        #endregion

        #region <Complaints>

        public void FillComplaintLbx()
        {
            if(classesManager.ComplaintManager != null)
            {
                foreach (Complaint complaint in classesManager.ComplaintManager.Complaints)
                {
                    lbxAllComplaints.Items.Add(complaint.GetInfo());
                }
            }
            
        }

        public void FillComplaintCbx()
        {
            foreach (User user in userManager.GetUsers())
            {
                cbxComplaintUser.Items.Add(user.Username);
            }
        }

        private void btnRemoveComplaint_Click(object sender, EventArgs e)
        {
            int selectedIndex = lbxAllComplaints.SelectedIndex;
            if(selectedIndex != -1)
            {
                for (int i = 0; i <= lbxAllComplaints.Items.Count; i++)
                {
                    if (selectedIndex == i)
                    {
                        lbxAllComplaints.Items.RemoveAt(i);
                        for (int index = 0; index < classesManager.ComplaintManager.Complaints.Count;)
                        {
                            if (index == i)
                            {
                                classesManager.ComplaintManager.RemoveComplaint(index);
                            }
                        }
                    }
                }
            }
            else
                MessageBox.Show("Please select a complaint!");
        }

        private void btnSendWarning_Click(object sender, EventArgs e)
        {
            string complaintUser = cbxComplaintUser.SelectedItem.ToString();
            string warningText = rtxCreateWarning.Text.ToString();

            if(rtxCreateWarning.Text == "")
            {
                MessageBox.Show("No complaint written");
            }
            else if(cbxComplaintUser.SelectedIndex == -1)
            {
                MessageBox.Show("No user selected");
            }
            else
            {
                Complaint revisedComplaint = new Complaint(userManager.getUser(complaintUser), warningText, userManager);
                classesManager.ComplaintManager.AddRevisedComplaint(revisedComplaint);
                MessageBox.Show("Warning sent to " + complaintUser);
                rtxCreateWarning.Clear();

            }
        }

        #endregion <Complaints>

        #region <Technical Issues>

        public void FillTechnicalLbx()
        {
            if (classesManager.TechnicalManager != null)
            {
                foreach (Technical technical in classesManager.TechnicalManager.GetTechnical())
                {
                    lbxAllTechnicalIssues.Items.Add(technical.GetTechnicalInfo());
                }
            }

        }

        private void btnRemoveIssue_Click(object sender, EventArgs e)
        {
            int selectedIndex = lbxAllTechnicalIssues.SelectedIndex;
            if (selectedIndex != -1)
            {
                for (int i = 0; i <= lbxAllTechnicalIssues.Items.Count; i++)
                {
                    if (selectedIndex == i)
                    {
                        lbxAllTechnicalIssues.Items.RemoveAt(i);
                        for(int index = 0; index < classesManager.TechnicalManager.GetTechnical().Length;)
                        {
                            if (index == i)
                            {
                                classesManager.TechnicalManager.RemoveTechnical(index);
                            }
                        }
                    }
                }
            }
            else
                MessageBox.Show("Please select an issue!");
        }
        private void btnScheduleVisit_Click(object sender, EventArgs e)
        {
            int day = Convert.ToInt32(dudVisitDay.Text);
            int month = Convert.ToInt32(dudVisitMonth.Text);
            int year = Convert.ToInt32(dudVisitYear.Text);

            if (month == 2 && day > 28)
            {
                MessageBox.Show("Please select a valid date");
            }
            else if ((month == 4 || month == 6 || month == 9 || month == 11) && day > 30)
            {
                MessageBox.Show("Please select a valid date");
            }
            else
            {
                DateTime date = new DateTime(year, month, day);
                Technical newVisit;
                newVisit = new Technical(date);
                classesManager.TechnicalManager.AddTechnicalVisit(newVisit);
            }
            ShowVisits();
        }

        private void ShowVisits()
        {
            lbxAllScheduledVisits.Items.Clear();
            foreach (Technical visit in classesManager.TechnicalManager.GetTechnicalVisits())
            {
                lbxAllScheduledVisits.Items.Add(visit.GetReturningTechnicalInfo());
            }
        }

        private void btnRemoveVisit_Click(object sender, EventArgs e)
        {
            int selectedIndex = lbxAllScheduledVisits.SelectedIndex;
            if (selectedIndex != -1)
            {
                for (int i = 0; i <= lbxAllScheduledVisits.Items.Count; i++)
                {
                    if (selectedIndex == i)
                    {
                        lbxAllScheduledVisits.Items.RemoveAt(i);
                        for (int index = 0; index < classesManager.TechnicalManager.GetTechnicalVisits().Length;)
                        {
                            if (index == i)
                            {
                                classesManager.TechnicalManager.RemoveTechnicalVisit(index);
                            }
                        }
                    }
                }
            }
            else
                MessageBox.Show("Please select a vist!");
        }

        #endregion <Technical Issues>

        private void pbxLogOut_Click(object sender, EventArgs e)
        {
            LOGIN loginform = new LOGIN(admin, userManager, classesManager);
            loginform.Show();
            this.Hide();
        }
    }
}
