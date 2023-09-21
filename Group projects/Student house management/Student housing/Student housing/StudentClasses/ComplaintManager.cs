using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    public class ComplaintManager
    {
        //Attributes
        private List<Complaint> complaints;
        private List<Complaint> revisedComplaints;

        //Constructor
        public ComplaintManager()
        {
            this.complaints = new List<Complaint>();
            this.revisedComplaints = new List<Complaint>();
        }

        //Properties
        public List<Complaint> Complaints
        {
            get { return this.complaints; }
        }

        public List<Complaint> RevisedComplaints
        {
            get { return this.revisedComplaints; }
        }

        //Methods
        public void AddNewComplaint(Complaint complaint)
        {
            complaints.Add(complaint);
        }

        public void AddRevisedComplaint(Complaint complaint)
        {
            revisedComplaints.Add(complaint);
        }

        public void RemoveComplaint(int i)
        {
            complaints.RemoveAt(i);
        }
    }
}
