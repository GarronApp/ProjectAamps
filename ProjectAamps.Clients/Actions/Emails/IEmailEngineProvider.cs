using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAamps.Clients.Actions.Emails
{
    public interface IEmailEngineProvider
    {
        void SetUpEmailConfiguration(MailMessage message);

        void BuildEmail();

        void ApplySettings();

    }
}
