using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    public class Complaint
    {
        UserManager userManager;
        //Attributes
        private string complaintTxt;
        private User complaintUser;
        private User whosentUser;

        //Constructor
        public Complaint(User suggestedUser, string complaintTxt, UserManager userManager): this(suggestedUser,complaintTxt,null,userManager)
        {

        }

        public Complaint(User suggestedUser, string complaintTxt,User whosentUser, UserManager userManager) 
        {
            this.userManager = userManager;
            this.complaintUser = suggestedUser;
            this.complaintTxt = complaintTxt;
            this.whosentUser = whosentUser;
        }

        //Properties
        public User ComplaintUser { get { return this.complaintUser; } }


        //Methods

        public string GetInfo()
        {
            return $"Complaint towards {this.complaintUser.Username} : {this.complaintTxt} sent by {this.whosentUser.Username}.";
        }

        public string GetRevisedInfo()
        {
            return $"Complaint towards {this.complaintUser.Username} : {this.complaintTxt}.";
        }

    }
}
