using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    public class Events
    {
        //Attributes
        private DateTime date;
        private User user;
        private string description;

        //Constructors
        public Events(string description)
        {
            this.description = description;
            this.user = null;
        }

        public Events(DateTime date, User user)
        {
            this.date = date;
            this.user = user;
            this.description = "No description";
        }

        public Events(DateTime date, User user, string description)
        {
            this.date = date;
            this.user = user;
            this.description = description;
        }

        //Method
        public string GetEventInfo()
        {
            string message = "Event on: " + this.date.Date.Day +"/"+ this.date.Date.Month +"/" + this.date.Date.Year + " created by: " + this.user.Username + " " + this.description;
            return message;
        }
    }
}
