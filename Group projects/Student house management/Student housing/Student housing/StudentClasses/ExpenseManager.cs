using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    public class ExpenseManager
    {
        //Attribute
        List<NormalExpense> expenses;


        //Constructor
        public ExpenseManager()
        {
            expenses = new List<NormalExpense>();
        }

        //Methods
        public void AddExpense(NormalExpense e)
        {
            this.expenses.Add(e);
        }

        public List<NormalExpense> GetExpenses()
        {
            return this.expenses;
        }

        public void SetExpenses(List<NormalExpense> expenses)
        {
            this.expenses = expenses;
        }
    }
}
