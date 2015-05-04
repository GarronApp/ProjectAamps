using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace App.Common.Mails
{
    public class EmailProvider
    {
         //SMTP Settings
        public string SMTPHost = System.Configuration.ConfigurationManager.AppSettings["SMTPHost"];
        public string SMTPUser = System.Configuration.ConfigurationManager.AppSettings["SMTPUser"];
        public string SMTPPassword = System.Configuration.ConfigurationManager.AppSettings["SMTPPassword"];

        public string EmailSender = System.Configuration.ConfigurationManager.AppSettings["EmailSender"];
        public string EmailSubject = System.Configuration.ConfigurationManager.AppSettings["EmailSubject"];
        public string EmailTemplate = System.Configuration.ConfigurationManager.AppSettings["EmailTemplate"];

        public void SendEmail()
        {
            try
            {
                MailMessage message = new MailMessage();

                string templatePath = HttpContext.Current.Server.MapPath("~/") + EmailTemplate;

                string htmlMessage = string.Empty;

                using (StreamReader htmltemplate = new StreamReader(templatePath))
                {
                    htmlMessage = htmltemplate.ReadToEnd().ToString();

                    htmlMessage = htmlMessage.Replace("[parameter]", "[parameter]");
                    htmlMessage = htmlMessage.Replace("[parameter]", "[parameter]");
                    htmlMessage = htmlMessage.Replace("[parameter]", "[parameter]");
                    htmlMessage = htmlMessage.Replace("[parameter]", "[parameter]");
                    htmlMessage = htmlMessage.Replace("[parameter]", "[parameter]");
                }

                message.To.Add(new MailAddress(EmailTemplate));
                message.From = new MailAddress(EmailSender);
                message.Subject = EmailSubject;
                message.Body = htmlMessage;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;

                NetworkCredential basicCredential = new NetworkCredential(SMTPUser, SMTPPassword);

                SmtpClient client = new SmtpClient();
                client.Port = 25;
                client.Host = SMTPHost;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential;
                client.Send(message);
            }
            catch(Exception ex)
            {
                Exceptions.ExceptionHandler.HandleException(ex);
            }
        }
              
    }
}
