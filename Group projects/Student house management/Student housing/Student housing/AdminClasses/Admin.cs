using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    [Serializable]
    public class Admin
    {
        //Atributes
        private string username;
        private string password;

        //Constructor
        public Admin(string username, string password)
        {
            this.username = username;
            this.password = password;
        }


        //Properties
        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }
    }
}
