using AAMPS.Clients.AampService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Common.Security;
using App.Extentions;

namespace AAMPS.Web.Providers
{
    public abstract class BaseController : Controller
    {
        public AAMPS.Clients.AampService.AampServiceClient _service;

        public AAMPS.Clients.AampService.AampServiceClient _serviceProvider
        {
            get
            {
                return _service = new AampServiceClient();
            }
        }
        public UserList USER
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