using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Logic;

namespace Logic
{
    public class LoginManager
    {
        private readonly IDbUserHelper IDbUserHelper = new DbUserHelper();

        public LoginManager()
        {
        }

        public User? Login(string name, string password)
        {
            User user;
            if(IDbUserHelper.FindUser(name, password) != null)
            {
				return user = new User(IDbUserHelper.FindUser(name, password));
			}
            else 
            {
                return null;
            }
            
        }
    }
}
