using AAMPS.Clients.AampService;
using App.Common.Controllers.Actions;
using App.Common.Security;
using App.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAamps.Clients.Actions.Base
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

        public Development DevelopmentInfo
        {
            get
            {

                var developmentId =  int.Parse(SessionHandler.GetSessionContext("DevelopmentID"));

                if (developmentId.IsNotNull())
                {
                    var development = _serviceProvider.GetDevelopmentById(developmentId);

                    return development as Development;
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

        public AAMPS.Clients.AampService.AampServiceClient _serviceProvider
        {
            get
            {
                return _service = new AampServiceClient();
            }
        }
    }
}
