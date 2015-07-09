using AAMPS.Clients.ViewModels.Emails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Extentions;
using App.Common.Security;

namespace AAMPS.Clients.Actions.Emails
{
    public class EmailSetupHelper
    {
        #region Properties
        public EmailTypeViewModelInfo ViewModelInfo { get; set; }

        public string Message { get; set; }

        #endregion Properties
        public EmailSetupHelper(string message, EmailTypeViewModelInfo _viewModelInfo)
        {
            Message = message;
            ViewModelInfo = _viewModelInfo;

            if (Message.IsNotNullOrEmpty())
            {
               LoadEmailInformationData(Message);
            }
        }

        public string LoadEmailInformationData(string message)
        {
            message = message.Replace("[PURCHASERNAME]", ViewModelInfo.PurchaserName);
            message = message.Replace("[PURCHASERSURNAME]", ViewModelInfo.PurchaserSurname);
            message = message.Replace("[PURCHASEREMAIL]", ViewModelInfo.EmailAddress);
            message = message.Replace("[NO]", ViewModelInfo.UnitNumber);
            message = message.Replace("[ESTATE]", ViewModelInfo.EstateName);
            message = message.Replace("[PRICE]", ViewModelInfo.Price.ToString());
            message = message.Replace("[AGENTNAME]", ViewModelInfo.AgentName.ToString());
            message = message.Replace("[AGENTSURNAME]", ViewModelInfo.AgentSurname.ToString());
            message = message.Replace("[AGENTEMAILADDRESS]", ViewModelInfo.AgentEmailAddress.ToString()); 
            message = message.Replace("[TIME]", ViewModelInfo.LapseTime.GetValueOrDefault().ToShortDateString());
            message = message.Replace("[DATE]", ViewModelInfo.LapseDate.GetValueOrDefault().ToShortDateString());
            message = message.Replace("[DEVELOPMENTIMAGE]", ViewModelInfo.DevelopmentImage);
            message = message.Replace("[DEVELOPMENTNAME]", ViewModelInfo.DevelopmentName);
            message = message.Replace("[DEVELOPERNAME]", ViewModelInfo.DeveloperName);

            SessionHandler.SessionContext("EmailMessage", message);
            return message;
        }
    }
}
