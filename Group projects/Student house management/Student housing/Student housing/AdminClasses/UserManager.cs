using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    [Serializable]
    public class UserManager
    {
        //Attributes
        private  List<User> users = new List<User>();
        private  List<Admin> admins = new List<Admin>();

        //Methods
        public User getUser(string username, string password)
        {
            User foundUser = new User(username, password);
            foreach (User user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return foundUser;
                } 
            }

            return null;
        }

        public User getUser(string username)
        {
            foreach (User user in users)
            {
                if (user.Username == username)
                {
                    return user;
                }
            }

            return null;
        }

        public User getUserByIndex(int index)
        {
            User foundUser;
            for(int i = 0; i<= users.Count; i++)
            {
                if (index == i)
                {
                    foundUser = users[i];
                    return foundUser;
                }
            }
            return null;
        }

        public User[] GetUsers()
        {
            return this.users.ToArray();
        }

        public Admin getAdmin(string username, string password)
        {
            Admin foundAdmin = new Admin(username, password);
            foreach (Admin admin in admins)
            {
                if (admin.Username == username && admin.Password == password)
                {
                    return foundAdmin;
                }
            }

            return null;
        }

        public void addUser(User user)
        {
            users.Add(user);
        }

        public void removeUser(User user)
        {
            users.Remove(user);
        }

        public void modifyUser(User user, string newUsername, string newPassword)
        {
            user.Username = newUsername;
            user.Password = newPassword;
        }

        public bool CheckUser(string username, string password)
        {
            if (users.Count != 0)
            {
                foreach (User user in users)
                {
                    if (user.Username == username && user.Password == password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public bool CheckUserAdmin(string username, string password)
        {
            if (admins.Count != 0)
            {
                foreach (Admin admin in admins)
                {
                    if (admin.Username == username && admin.Password == password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public string GetUserInfo(User u)
        {
            return u.Username + " " + u.Password;
        }

    }
}
