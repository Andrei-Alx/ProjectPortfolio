using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    public class Technical
    {
        //Attributes
        private string techicalText;
        private User user;
        private Nullable <DateTime> date;

        //Methods
        public Technical(string text, User user)
        {
            this.techicalText = text;
            this.user = user;
            this.date = null;
        }

        public Technical(DateTime date)
        {
            this.techicalText = null;
            this.user = null;
            this.date = date;
        }

        public string GetTechnicalInfo()
        {
            return $"'{this.techicalText}' sent by {this.user.Username}.";
        }

        public string GetReturningTechnicalInfo()
        {
            return $"Next technical visit is on {this.date}.";
        }
    }
}
