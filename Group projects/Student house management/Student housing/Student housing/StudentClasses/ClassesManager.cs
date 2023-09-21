using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Student_housing
{
    public class ClassesManager
    {
        Cleaning cleaning;
        ComplaintManager complaintManager;
        EventManager eventManager;
        Trash trash;
        ExpenseManager expenseManager;
        NormalExpense normalExpense;
        UserManager userManager;
        TechnicalManager technicalManager;
        NotificationManager notificationManager;
        AgreementsManager agreementsManager;

        public ClassesManager()
        {
            DeSerializeObject();
            this.cleaning = new Cleaning(userManager);
            this.complaintManager = new ComplaintManager();
            this.eventManager = new EventManager();
            this.trash = new Trash(userManager);
            this.expenseManager = new ExpenseManager();
            this.normalExpense = new NormalExpense(userManager);
            this.technicalManager = new TechnicalManager();
            this.notificationManager = new NotificationManager();
            this.agreementsManager = AgreementsManager.Instance;
            
        }

        #region <Serialization of Files>
        public void SerializeObject()
        {
            FileStream fs = null;
            BinaryFormatter bf = null;
            try
            {
                fs = new FileStream("../../Resources/SaveData", FileMode.OpenOrCreate, FileAccess.Write);
                bf = new BinaryFormatter();
                bf.Serialize(fs, this.userManager);
            }
            catch (Exception ex)
            { System.Windows.Forms.MessageBox.Show( ex.Message); }
            finally
            { if (fs != null) fs.Close(); }
        }

        public void DeSerializeObject()
        {
            FileStream fs = null;
            BinaryFormatter bf = null;
            try
            {
                fs = new FileStream("../../Resources/SaveData", FileMode.Open, FileAccess.Read);
                bf = new BinaryFormatter();
                this.userManager = (UserManager)bf.Deserialize(fs);

            }
            catch (Exception ex)
            {
            }
            finally
            { if (fs != null) fs.Close(); }
        }

        #endregion <Serialization of Files>

        public Cleaning Cleaning { get { return this.cleaning; } }
        public ComplaintManager ComplaintManager { get { return this.complaintManager; } }
        public EventManager EventManager { get { return this.eventManager; } }
        public Trash Trash { get { return this.trash; } }
        public ExpenseManager ExpenseManager { get { return this.expenseManager; } }
        public NormalExpense NormalExpense { get { return this.normalExpense; } }
        public UserManager UserManager { get { return this.userManager; } }
        public TechnicalManager TechnicalManager { get { return this.technicalManager; } }
        public NotificationManager NotificationManager { get { return this.notificationManager; } }
        public AgreementsManager AgreementsManager { get { return this.agreementsManager; } }
    }   

}
