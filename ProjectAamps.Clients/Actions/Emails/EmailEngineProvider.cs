using AAMPS.Clients.ViewModels.Emails;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using App.Common;
using App.Extentions;
using App.Common.Exceptions;
using AAMPS.Clients.Actions.Emails;
using AAMPS.Clients.Actions.Base;

namespace AAMPS.Clients.Actions.Emails
{
    public class EmailEngineProvider : BaseActionProvider
    {
        public EmailTypeViewModelInfo ViewModelInfo { get; set; }

        public string SessionPath { get; set; }
        public string EmailType { get; set; } 
        public EmailEngineProvider()
        {

        }

        public EmailEngineProvider(string emailType,EmailTypeViewModelInfo info)
        {
            EmailType = emailType;
            ViewModelInfo = info;
            SetupEmailType(emailType);
        }

        public void SetUpEmailConfiguration(MailMessage message)
        {
            try
            {
                NetworkCredential basicCredential = new NetworkCredential(EmailSettings.SMTPUser, EmailSettings.SMTPPassword);
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = EmailSettings.SMTPHost;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential;
                client.Send(message);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                throw;
            }
        }

        public void BuildEmail(string template)
        {
            try
            {
                MailMessage message = new MailMessage();

                string templatePath = AbsolutePath + template;
                string htmlMessage = string.Empty;

                using (StreamReader htmltemplate = new StreamReader(templatePath))
                {
                    htmlMessage = htmltemplate.ReadToEnd().ToString();

                    var htmlMessageInfo = new EmailSetupHelper(htmlMessage, ViewModelInfo);
                    
                }
                message.To.Add(new MailAddress(EmailSettings.EmailTestRecipient));
                message.From = new MailAddress(EmailSettings.EmailSender);
                message.Subject = EmailSettings.EmailSubject;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;
                message.Body = EmailMessage.IsNotNullOrEmpty() ? EmailMessage : null;

                if(message.IsNotNull())
                {
                    MapEmailInformation();
                    SetUpEmailConfiguration(message);
                }
                
               
            }
            catch (Exception ex)
            {
                App.Common.Exceptions.ExceptionHandler.HandleException(ex);
            }
        }

        public void SetupEmailType(string emailtype)
        {
            if(emailtype.IsNotNullOrEmpty())
            {
                if(emailtype == EmailScenario.Sale_Reserved_Scenario)
                {
                    foreach (var template in ReservedStatusEmailTriggers)
                    {
                        BuildEmail(template);
                    }
                }
            }
        }


        public void MapEmailInformation()
        {
            var ViewModelInfo = new EmailTypeViewModelInfo()
            {
                DevelopmentName = DevelopmentInfo.DevelopmentDescription,
                DevelopmentImage = DevelopmentInfo.DevelopmentUrlImage,
                EstateName = EstateName,
                DeveloperName = DeveloperName,
                AgentName = UserInfo.UserListName,
                AgentSurname = UserInfo.UserListSurname,
                EmailAddress = UserInfo.UserListEmail,
                PurchaserName = IndividualInfo.IndividualName,
                PurchaserSurname = IndividualInfo.IndividualSurname,
                UnitNumber = UnitInfo.UnitNumber,
                Price = UnitInfo.UnitPrice,
                LapseDate = SaleInfo.SaleReservationDt,
                LapseTime = SaleInfo.SaleReservationExpiryDt
            };
        }
    }
}
