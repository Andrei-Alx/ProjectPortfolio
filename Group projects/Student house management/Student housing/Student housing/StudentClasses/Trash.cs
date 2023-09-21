using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    
    public class Trash
    {
        //Attributes
        UserManager userManager;
        private int index = 0;

        //Constructor
        public Trash(UserManager userManager)
        {
            this.userManager = userManager;
        }

        //Methods
        public string GetUser()
        {
            return userManager.getUserByIndex(index).Username;
        }

        public void NextUser()
        {
            index++;
            if (index == userManager.GetUsers().Length)
            {
                index = 0;
            }
        }
    }
}
