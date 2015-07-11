using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAMPS.Clients.ViewModels.Emails
{
    public class PurchaserReservationCapturedVM
    {
        public string PurchaserName { get; set; }
        public string PurchaserSurname { get; set; }
        public string EmailAddress { get; set; }
        public string UnitNumber { get; set; }
        public string DevelopmentName { get; set; }
        public string DevelopmentImage { get; set; }
        public string DeveloperName { get; set; }
        public double Price { get; set; }
        public string AgentName { get; set; }
        public string AgentSurname { get; set; }
        public Nullable<DateTime> LapseTime { get; set; }
        public Nullable<DateTime> LapseDate { get; set; }
    }
}
