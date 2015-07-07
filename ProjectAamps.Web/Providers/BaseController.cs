using AAMPS.Clients.AampService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Common.Security;
using App.Extentions;
using System.Configuration;
using ProjectAamps.Clients.ViewModels.Emails;

namespace AAMPS.Web.Providers
{
    public abstract class BaseController : Controller
    {
        public AAMPS.Clients.AampService.AampServiceClient _service;

        protected string strAppTitle = ConfigurationSettings.AppSettings["AppRoute"];

        public AAMPS.Clients.AampService.AampServiceClient _serviceProvider
        {
            get
            {
                return _service = new AampServiceClient();
            }
        }
        public UserList UserInfo
        {
            get
            {
                var user = SessionHandler.GetSessionObject("USER");
                
                if(user.IsNotNull())
                {
                    return user as UserList;
                }

                return null;
            }
           
        }

        public Development DevelopmentInfo
        {
            get
            {
                var development = HttpContext.Request.QueryString["DevelopmentID"];
                
                if(development.IsNotNull())
                {
                    SessionHandler.SessionContext("DevelopmentInfo", development);
                }

                var developmentInfo = SessionHandler.GetSessionObject("DevelopmentInfo");

                if (developmentInfo.IsNotNull())
                {
                    return developmentInfo as Development;
                }

                return null;
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

        public int DevelopmentID
        {
            get
            {
                var development = HttpContext.Request.QueryString["DevelopmentID"];

                if (!String.IsNullOrEmpty(development))
                {
                    SessionHandler.SessionContext("DevelopmentID", development);
                }

                int id = int.Parse(SessionHandler.GetSessionContext("DevelopmentID"));

                return id;
            }
        }

        public int? UnitID
        {
            get
            {
                var unitId = int.Parse(SessionHandler.GetSessionContext("CurrentUnit"));

                if(unitId.IsNotNull())
                {
                    return unitId;
                }

                return null;
            }
        }

        public int? SaleID
        {
            get
            {
                var saleId = int.Parse(SessionHandler.GetSessionContext("CurrentSaleId"));

                if (saleId.IsNotNull())
                {
                    return saleId;
                }

                return null;
            }
        }



        public string DevelopmentImage
        {
            get
            {
                var developmentLogo = _serviceProvider.GetDevelopmentById(DevelopmentID).DevelopmentUrlImage;
                
                return developmentLogo;
            }
        }

       
    }
}