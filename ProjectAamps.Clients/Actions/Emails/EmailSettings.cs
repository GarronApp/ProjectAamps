using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAMPS.Clients.Actions.Emails
{
    public static class EmailSettings
    {
        //SMTP Settings
        public static string DomainURL = System.Configuration.ConfigurationManager.AppSettings["DomainURL"];
        public static string SMTPHost = System.Configuration.ConfigurationManager.AppSettings["SMTPHost"];
        public static string SMTPUser = System.Configuration.ConfigurationManager.AppSettings["SMTPUser"];
        public static string SMTPPassword = System.Configuration.ConfigurationManager.AppSettings["SMTPPassword"];

        public static string EmailSender = System.Configuration.ConfigurationManager.AppSettings["EmailSender"];
        public static string EmailTestRecipient = System.Configuration.ConfigurationManager.AppSettings["EmailTestRecipient"];
        public static string EmailSubject = System.Configuration.ConfigurationManager.AppSettings["EmailSubject"];
        public static string PurchaserReservationCapturedTemplate = System.Configuration.ConfigurationManager.AppSettings["PurchaserReservationCaptured"];
        public static string AgentReservationCapturedTemplate = System.Configuration.ConfigurationManager.AppSettings["AgentReservationCaptured"];


    }

    public static class EmailScenario
    {
        //Email Queue Settings
        public static string Sale_Reserved_Scenario = "Sale_Reserved_Scenario";
        public static string Purchaser_Signed_Pending_Scenario = "Purchaser_Signed_Pending_Scenario";
        public static string Deposit_Paid_Pending_Scenario = "Deposit_Paid_Pending_Scenario";
        public static string Sale_Sold_Scenario = "Sale_Sold_Scenario";
        public static string SP_Captured_Data_Scenario = "SP_Captured_Data_Scenario";
    }
}
