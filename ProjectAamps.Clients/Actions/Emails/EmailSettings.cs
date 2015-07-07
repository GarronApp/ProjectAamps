using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAamps.Clients.Actions.Emails
{
    public static class EmailSettings
    {
        //SMTP Settings
        public static string SMTPHost = System.Configuration.ConfigurationManager.AppSettings["SMTPHost"];
        public static string SMTPUser = System.Configuration.ConfigurationManager.AppSettings["SMTPUser"];
        public static string SMTPPassword = System.Configuration.ConfigurationManager.AppSettings["SMTPPassword"];

        public static string EmailSender = System.Configuration.ConfigurationManager.AppSettings["EmailSender"];
        public static string EmailTestRecipient = System.Configuration.ConfigurationManager.AppSettings["EmailTestRecipient"];
        public static string EmailSubject = System.Configuration.ConfigurationManager.AppSettings["EmailSubject"];
        public static string EmailTemplate = System.Configuration.ConfigurationManager.AppSettings["PurchaserReservationCaptured"];
    }
}
