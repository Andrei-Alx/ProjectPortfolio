using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    public class NormalExpense
    {
        //Attributes
        UserManager userManager;
        public readonly int expenseID;
        private double total;
        private User payee;
        private string title;
        private List<User> members;
        private double amountToBePaidPerMember;
        private double amountLeftToBePaid;
        private List<User> membersWhoPaid;
        private DateTime created_at;

        private int soapIndex = 0;
        private int paperIndex = 0;
        private int bathIndex = 0;
        private int kitchenIndex = 0;

        //Constructors
        public NormalExpense(UserManager userManager)
        {
            this.userManager = userManager;
        }
        
        public NormalExpense(int expenseID, double total, User payee, string title, List<User> members)
        {
            this.expenseID = expenseID;
            this.total = total;
            this.payee = payee;
            this.title = title;
            this.members = members;
            this.amountLeftToBePaid = total - ComputeAmountToBePaidPerMember();
            this.amountToBePaidPerMember = ComputeAmountToBePaidPerMember();
            this.membersWhoPaid = new List<User>() { payee };
            this.created_at = DateTime.Now.Date;
        }

        //Properties

        public double Total { get { return this.total; } }
        public User Payee {get {return this.payee; } }
        public string Title { get { return this.title; } }
        public List<User> Members {get { return this.members; } }
        public double AmountToBePaidPerMember {get {return this.amountToBePaidPerMember; } }
        public double AmountLeftToBePaid {get {return this.amountLeftToBePaid; } }
        public List<User> MembersWhoPaid { get { return this.membersWhoPaid ; } }
        public DateTime CreatedAt { get { return this.created_at;} }

        public int SoapIndex { get { return this.soapIndex; } set { this.soapIndex = value; } }
        public int PaperIndex { get { return this.paperIndex; } set { this.paperIndex = value; } }
        public int KitchenIndex { get { return this.kitchenIndex; } set { this.kitchenIndex = value; } }
        public int BathIndex { get { return this.bathIndex; } set { this.bathIndex = value; } }

        //Methods

        public string AddTenants(int index)
        {
            if (index >= userManager.GetUsers().Length)
            {
                index = index % userManager.GetUsers().Length;
            }
            return userManager.getUserByIndex(index).Username;
        }

        private double ComputeAmountToBePaidPerMember() => total / members.Count;

        public void Pay(User payer)
        {
            if (!membersWhoPaid.Contains(payer))
            {
                this.amountLeftToBePaid -= this.amountToBePaidPerMember;
                membersWhoPaid.Add(payer);
            }
        }
    }
}
