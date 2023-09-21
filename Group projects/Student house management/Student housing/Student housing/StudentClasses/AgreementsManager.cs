using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    public class AgreementsManager
    {
        //Attributes
        private List<Agreement> agreements = new List<Agreement>();
        private Agreement agreement;
        private static AgreementsManager instance = null;

        //Constructor
        private AgreementsManager() { }

        //Singleton
        public static AgreementsManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AgreementsManager();
                }
                return instance;
            }
        }

        //Methods
        public void CreateAgreement(DateTime currentDate, string involvedStudents, string agreementDesc)
        {
            agreement = new Agreement(currentDate, involvedStudents, agreementDesc);
            AddAgreementToList(agreement);
        }

        private void AddAgreementToList(Agreement agreement)
        {
            agreements.Add(agreement);
        }

        public List<Agreement> GetAgreementsList()
        {
            return agreements;
        }

        public void RemoveAgreementById(int id)
        {
            for (int i = 0; i < agreements.Count; i++)
            {
                if (agreements[i].Id == id)
                {
                    agreements.Remove(agreements[i]);
                }
            }
        }

        public void SendAcceptToPrivateAgreement(int id)
        {
            for (int i = 0; i < agreements.Count; i++)
            {
                if (agreements[i].Id == id)
                {
                    agreements[i].UpdateStatus("Accepted");
                }
            }
        }

        public void SendRejectToPrivateAgreement(int id)
        {
            for (int i = 0; i < agreements.Count; i++)
            {
                if (agreements[i].Id == id)
                {
                    agreements[i].UpdateStatus("Rejected");
                }
            }
        }

        public void SendAcceptToPublicAgreement(int id, string studentWhoVoted)
        {
            for (int i = 0; i < agreements.Count; i++)
            {
                if (agreements[i].Id == id)
                {
                    string voters = agreements[i].VoterList;
                    if (!voters.Contains(studentWhoVoted))
                    {
                        agreements[i].IncreaseVotes(studentWhoVoted);
                        agreements[i].UpdateStatusVotes();
                    }
                }
            }
        }

        public void SendRejectToPublicAgreement(int id, string studentWhoVoted)
        {
            for (int i = 0; i < agreements.Count; i++)
            {
                if (agreements[i].Id == id)
                {
                    string voters = agreements[i].VoterList;
                    if (!voters.Contains(studentWhoVoted))
                    {
                        agreements[i].DecreaseVotes(studentWhoVoted);
                        agreements[i].UpdateStatusVotes();
                    }
                }
            }
        }

        public int GetAgreementVoters(int id)
        {
            int voters = 0;
            for (int i = 0; i < agreements.Count; i++)
            {
                if (agreements[i].Id == id)
                {
                    voters = agreements[i].GetVoters();
                }
            }
            return voters;
        }

        public int GetAgreementVotesPercentage(int id)
        {
            int percentage = 0;
            for (int i = 0; i < agreements.Count; i++)
            {
                if (agreements[i].Id == id)
                {
                    percentage = agreements[i].CalculatePercentageVotes();
                }
            }
            return percentage;
        }

        public void EditAgreementDescription(int id, string newDescription)
        {
            for (int i = 0; i < agreements.Count; i++)
            {
                if (agreements[i].Id == id)
                {
                    agreements[i].UpdateDescription(newDescription);
                }
            }
        }
    }
}

