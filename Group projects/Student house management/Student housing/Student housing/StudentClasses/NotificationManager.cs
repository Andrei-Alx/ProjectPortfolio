using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    public class NotificationManager
    {
        //Attribute
        private List<string> notifications = new List<string>();

        public DateTime dateOfCreation { get; private set; }
        //Methods
        public string[] GetNotificationList()
        {
            return notifications.ToArray();
        }

        public void AddNotification(string notification)
        {
            dateOfCreation = DateTime.Today;
            notifications.Add(dateOfCreation.ToString("MM/dd/yyyy") + " " + notification);
        }
    }
}
