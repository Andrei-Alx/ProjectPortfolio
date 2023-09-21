using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    public class Cleaning
    {
        //Attributes
        private UserManager userManager;
        private int bathIndex = 0;
        private int kitchenIndex = 0;
        private int sharedIndex = 0;
        private int toiletIndex = 0;

        //Constructor
        public Cleaning(UserManager userManager)
        {
            this.userManager = userManager;
        }

        //Methods
        public string AddUsers(int index)
        {
            if (index >= userManager.GetUsers().Length)
            {
                index = index % userManager.GetUsers().Length;
            }
            return userManager.getUserByIndex(index).Username;
        }

        //Properties
        public int BathIndex { get { return this.bathIndex; } set { this.bathIndex = value; } }
        public int KitchenIndex { get { return this.kitchenIndex; } set { this.kitchenIndex = value; } }
        public int SharedIndex { get { return this.sharedIndex; } set { this.sharedIndex = value; } }
        public int ToiletIndex { get { return this.toiletIndex; } set { this.toiletIndex = value; } }

    }
}
