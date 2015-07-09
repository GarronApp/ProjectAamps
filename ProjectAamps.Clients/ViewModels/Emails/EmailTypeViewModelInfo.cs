using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAMPS.Clients.ViewModels.Emails
{
    public class EmailTypeViewModelInfo
    {
        public string PurchaserName { get; set; }
        public string PurchaserSurname { get; set; }
        public string EmailAddress { get; set; }
        public string PurchaserEmailAddress { get; set; }
        public string AgentEmailAddress { get; set; }
        public string AgencyEmailAddress { get; set; }
        public string AgentCellPhone { get; set; }
        public string PrincipleName { get; set; }
        public string PrincipleSurname { get; set; }
        public string PrincipleEmailAddress { get; set; }
        public string UnitNumber { get; set; }
        public string DevelopmentName { get; set; }
        public string DevelopmentImage { get; set; }
        public string DeveloperName { get; set; }
        public string EstateName { get; set; }
        public string TransferAttorneyName { get; set; }
        public string TransferAttorneyFirmName { get; set; }
        public string TransferAttorneyEmail { get; set; }
        public string AgentName { get; set; }
        public string AgentSurname { get; set; }
        public string BondCompany { get; set; }
        public string Entity { get; set; }
        public string ProofOfPayment { get; set; }
        public double Price { get; set; }
        public double SellingPrice { get; set; }
        public double DepositAmount { get; set; }
        public double BondAmount { get; set; }
        public double ReferralCommissionAmount { get; set; }
        public Nullable<DateTime> Time { get; set; }
        public Nullable<DateTime> Date { get; set; }
        public Nullable<DateTime> LapseTime { get; set; }
        public Nullable<DateTime> LapseDate { get; set; }
        public Nullable<DateTime> BondDueDate { get; set; }
    }
}
