using ProjectAamps.Clients.ViewModels.Emails;
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
using App.Common.Exceptions;

namespace ProjectAamps.Clients.Actions.Emails
{
    public class EmailEngineProvider : IEmailEngineProvider
    {
        public PurchaserReservationCapturedVM ViewModelInfo { get; set; } 
        public EmailEngineProvider()
        {
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


        public void BuildEmail()
        {
            try
            {
                MailMessage message = new MailMessage();

                string templatePath = HttpContext.Current.Server.MapPath("~/") + EmailSettings.EmailTemplate;
                string htmlMessage = string.Empty;

                using (StreamReader htmltemplate = new StreamReader(templatePath))
                {
                    htmlMessage = htmltemplate.ReadToEnd().ToString();

                    htmlMessage = AttachDataInfo(htmlMessage);
                }

                message.To.Add(new MailAddress(EmailSettings.EmailTestRecipient));
                message.From = new MailAddress(EmailSettings.EmailSender);
                message.Subject = EmailSettings.EmailSubject;
                message.Body = htmlMessage;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;

                SetUpEmailConfiguration(message);
               
            }
            catch (Exception ex)
            {
                App.Common.Exceptions.ExceptionHandler.HandleException(ex);
            }
        }

        private string AttachDataInfo(string message)
        {
            message = message.Replace("[PURCHASERNAME]", ViewModelInfo.PurchaserName);
            message = message.Replace("[PURCHASERSURNAME]", ViewModelInfo.PurchaserSurname);
            message = message.Replace("[PURCHASEREMAIL]", ViewModelInfo.EmailAddress);
            message = message.Replace("[NO]", ViewModelInfo.UnitNumber);
            message = message.Replace("[PRICE]", ViewModelInfo.Price.ToString());
            message = message.Replace("[AGENTNAME]", ViewModelInfo.AgentName.ToString());
            message = message.Replace("[AGENTSURNAME]", ViewModelInfo.AgentSurname.ToString());
            message = message.Replace("[TIME]", ViewModelInfo.LapseTime.GetValueOrDefault().ToShortDateString());
            message = message.Replace("[DATE]", ViewModelInfo.LapseDate.GetValueOrDefault().ToShortDateString());
            message = message.Replace("[DEVELOPMENTIMAGE]", HttpContext.Current.Server.MapPath("~/Images/") + ViewModelInfo.DevelopmentImage);
            message = message.Replace("[DEVELOPMENTNAME]", ViewModelInfo.DevelopmentName);

            return message;
        }

        public void ApplySettings()
        {
          
        }
    }
}
