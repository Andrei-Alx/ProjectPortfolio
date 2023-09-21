using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    public class TechnicalManager
    {
        //Attributes
        private List<Technical> technicalIssues = new List<Technical>();
        private List<Technical> technicalVisits = new List<Technical>();

        //Methods
        public void AddTechnical(Technical technical)
        {
            technicalIssues.Add(technical);
        }

        public void RemoveTechnical(int index)
        {
            technicalIssues.RemoveAt(index);
        }

        public Technical[] GetTechnical()
        {
            return technicalIssues.ToArray();
        }

        public void AddTechnicalVisit(Technical technical)
        {
            technicalVisits.Add(technical);
        }

        public void RemoveTechnicalVisit(int index)
        {
            technicalVisits.RemoveAt(index);
        }

        public Technical[] GetTechnicalVisits()
        {
            return technicalVisits.ToArray();
        }
    }
}
