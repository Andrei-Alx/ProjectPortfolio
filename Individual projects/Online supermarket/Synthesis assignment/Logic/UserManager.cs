using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Data;
using Logic;

namespace Logic
{
    public class UserManager
    {
        private List<User> users;
        private readonly IDbUserHelper IdbUserHelper;
		private readonly EmailValidation emailValidation;

        public UserManager(IDbUserHelper IdbUserHelper)
        {
            this.IdbUserHelper = IdbUserHelper
                ?? throw new ArgumentNullException(nameof(IdbUserHelper));
            users = new List<User>();
            emailValidation= new EmailValidation();
        }

        public IEnumerable<User> GetAll()
        {
            IEnumerable<UserDTO> userDTOs = IdbUserHelper.GetUsers();
            List<User> users = new List<User>();
            foreach (UserDTO u in userDTOs)
            {
                User user = new User(u);
                users.Add(user);
            }
            return users;
        }

        public User FindUser(string name, string password)
        {
            User foundUser;
            foundUser = new User(IdbUserHelper.FindUser(name, password));
            return foundUser;
        }

		public User FindUser(string name)
		{
			User foundUser;
			foundUser = new User(IdbUserHelper.FindUser(name));
			return foundUser;
		}

		public bool CreateUser(string name, string password, UserRoles role)
        {
            try
            {
                if(name != String.Empty && password != String.Empty && password != null &&  role.ToString() != String.Empty)
                {
                    if(EmailValidation.IsValidUsername(name) == false)
                    {
                        throw new Exception("Invalid username!");
                    }
                    if(IdbUserHelper.GetUserByName(name) == null)
                    {
                        IdbUserHelper.CreateUser(name, password, role.ToString());
                        return true;
                    }
                    else
                    {
                        throw new Exception("Username is already taken!");
                    }
                }
                else
                {
					throw new Exception("Please fill in every field!");
				}
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return false;
        }
        public User GetUserByID(int ID)
        {
            User user = new User(IdbUserHelper.GetUserByID(ID));
            return user;
        }
    }
}
