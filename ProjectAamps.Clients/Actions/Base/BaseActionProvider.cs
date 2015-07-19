using AAMPS.Clients.AampService;
using AAMPS.Clients.Actions.Concepts;
using AAMPS.Clients.Actions.Emails;
using AAMPS.Clients.ViewModels.Emails;
using App.Common.Security;
using App.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AAMPS.Clients.Actions.Base
{
    public class BaseActionProvider: ControllerAction
    {
        public AAMPS.Clients.AampService.AampServiceClient _service;
         #region Constructors
        public BaseActionProvider(object query)
        {

        }
        public BaseActionProvider()
        {

        }
        #endregion Constructors

        public UserList UserInfo
        {
            get
            {
                var user = SessionHandler.GetSessionObject("USER");

                if (user.IsNotNull())
                {
                    return user as UserList;
                }

                return null;
            }

        }

        //public AAMPS.Clients.AampService.Development DevelopmentInfo
        //{
        //    get
        //    {
        //        var developmentId =  int.Parse(SessionHandler.GetSessionContext("DevelopmentID"));

        //        if (developmentId.IsNotNull())
        //        {
        //            var development = _serviceProvider.GetDevelopmentById(developmentId);

        //            return development as AAMPS.Clients.AampService.Development;
        //        }

        //        return null;
        //    }

        //}

        public AAMPS.Clients.AampService.Development DevelopmentInfo
        {
            get
            {
                var development = SessionHandler.GetSessionObject("DevelopmentInfo");

                if (development.IsNotNull())
                {
                    return development as AAMPS.Clients.AampService.Development;
                }

                return null;
            }

        }

        public string EstateName
        {
            get
            {
                var estateId = int.Parse(SessionHandler.GetSessionObject("EstateInfo").ToString());

                if (estateId.IsNotNull())
                {
                    return _serviceProvider.GetEstateById(estateId).EstateDescription;
                }

                return string.Empty;
            }
        }

        public string DeveloperName
        {
            get
            {
                var developerInfo = int.Parse(SessionHandler.GetSessionContext("DeveloperInfo").ToString());

                if (developerInfo.IsNotNull())
                {
                    return _serviceProvider.GetCompanyById(developerInfo).CompanyDescription;

                }
                return string.Empty;
            }

        }

        public Unit UnitInfo
        {
            get
            {
                var unitInfo = SessionHandler.GetSessionObject("UnitInfo");

                if (unitInfo.IsNotNull())
                {
                    return unitInfo as Unit;
                }

                return null;
            }

        }

        public Sale SaleInfo
        {
            get
            {
                var saleInfo = SessionHandler.GetSessionObject("SaleInfo");

                if (saleInfo.IsNotNull())
                {
                    return saleInfo as Sale;
                }

                return null;
            }

        }

        public Individual IndividualInfo
        {
            get
            {
                var individualInfo = SessionHandler.GetSessionObject("IndividualInfo");

                if (individualInfo.IsNotNull())
                {
                    return individualInfo as Individual;
                }

                return null;
            }

        }

        public Purchaser PurchaserInfo
        {
            get
            {
                var purchaserInfo = SessionHandler.GetSessionObject("PurchaserInfo");

                if (purchaserInfo.IsNotNull())
                {
                    return purchaserInfo as Purchaser;
                }

                return null;
            }

        }

        public string EmailMessage
        {
            get
            {
                var message = SessionHandler.GetSessionContext("EmailMessage");
                if(message.IsNotNull())
                {
                    return message;
                }
                return string.Empty;
            }
        }

        public AAMPS.Clients.AampService.AampServiceClient _serviceProvider
        {
            get
            {
                return _service = new AampServiceClient();
            }
        }

        public List<string> ReservedStatusEmailTriggers
        {
            get
            {
                List<string> queuedEmails = new List<string>();
                queuedEmails.Add(EmailSettings.PurchaserReservationCapturedTemplate);
                queuedEmails.Add(EmailSettings.AgentReservationCapturedTemplate);
                return queuedEmails;
            }
        }

        public string AbsolutePath
        {
            get
            {
                var message = SessionHandler.GetSessionContext("AbsolutePathInfo");
                if (message.IsNotNull())
                {
                    return message;
                }
                return string.Empty;
            }
        }

        public EmailTypeViewModelInfo EmailDataModel
        {
            get
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

                return EmailDataModel;
            }
        }
        

    }
}
