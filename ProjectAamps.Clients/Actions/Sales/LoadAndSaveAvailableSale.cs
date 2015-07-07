using AAMPS.Clients.Queries.Sales;
using AAMPS.Clients.ViewModels.Sales;
using App.Common.Controllers.Actions;
using App.Common.Security;
using ProjectAamps.Clients.Actions.Emails;
using ProjectAamps.Clients.ViewModels.Emails;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Extentions;
using ProjectAamps.Clients.Actions.Base;

namespace AAMPS.Clients.Actions.Sales
{
    public class LoadAndSaveAvailableSale : BaseActionProvider
    {
        public int Id { get; set; }
        public LoadSalesQuery query { get; set; }
        public ReservationViewModel avaialableReservationVM { get; set; }
        public AAMPS.Clients.AampService.AampServiceClient _repoService { get; set; }
        public LoadAndSaveAvailableSale()
         {

         }

        public LoadAndSaveAvailableSale(LoadSalesQuery _query)
              : base(_query)
        {
            query = _query;
            OnBindModel();
        }

        public override void OnBindModel()
        {
            _repoService = new AampService.AampServiceClient();

            Id = query.UnitId;
            avaialableReservationVM = query.AvailableReservationVM;
            OnExecute();
        }

        public override object OnExecute()
        {


            var _currentUnit = new AAMPS.Clients.AampService.AampServiceClient().GetUnitById(Id);
            if(_currentUnit.IsNotNull())
            {
                SessionHandler.SessionContext("UnitInfo", _currentUnit);
            }

            var _availableSale = new AAMPS.Clients.AampService.Sale();

            _availableSale.SaleActiveStatusID = (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Reserved;
            avaialableReservationVM.SaleStatusId = (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Reserved;
            avaialableReservationVM.CurrentSalesStatus = _repoService.GetSaleActiveStatus((int)_availableSale.SaleActiveStatusID).SaleActiveStatusDescription;

            var _linkedUnit = _repoService.GetUnitById(int.Parse(SessionHandler.GetSessionContext("CurrentUnit")));

            _linkedUnit.UnitStatusID = (int)AAMPS.Clients.AampService.GetUnitStatusType.Reserved;
            avaialableReservationVM.UnitStatusId = (int)AAMPS.Clients.AampService.GetUnitStatusType.Reserved;
           //_repoService.UpdateUnit(_linkedUnit);

            _availableSale.UnitID = _linkedUnit.UnitID;
            _availableSale.SaleStatusID = (int)AAMPS.Clients.AampService.GetSaleStatusType.Active;
            _availableSale.SaleReservationDt = avaialableReservationVM.SaleReservationDt != null ? DateTime.ParseExact(avaialableReservationVM.SaleReservationDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
            _availableSale.SaleReservationExpiryDt = avaialableReservationVM.SaleReservationExpiryDt != null ? DateTime.ParseExact(avaialableReservationVM.SaleReservationExpiryDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
            _availableSale.SaleReservationExtentionDt = avaialableReservationVM.SaleReservationExtentionDt != null ? DateTime.ParseExact(avaialableReservationVM.SaleReservationExtentionDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
            _availableSale.IndividualID = avaialableReservationVM.CurrentIndividualID;
            _availableSale.SaleAddedDt = DateTime.Now;
            _availableSale.SaleModifiedDt = DateTime.Now;

            var userIdentity = int.Parse(SessionHandler.GetSessionContext("CurrentUserId"));
            if (userIdentity != null)
            {
                _availableSale.SaleModifiedByUser = userIdentity;
                _availableSale.SalePrimAgentID = userIdentity;
                _availableSale.SaleAddedByUser = userIdentity;
            }
            
            _availableSale.SaleDepositPaidBt = false;
            _availableSale.SalesBondRequiredBt = false;
            _availableSale.SalesReferalCommDueBt = false;
            _availableSale.SalesBondCommDueBt = false;
            _availableSale.SaleBondRequiredAmount = 0;

           //_repoService.AddSale(_availableSale);

            if(_availableSale.IsNotNull())
            {
                SessionHandler.SessionContext("SaleInfo", _availableSale);
            }

            query.AvailableReservationVM = avaialableReservationVM;

            var purchaserReservationCapturedVM = new PurchaserReservationCapturedVM()
            {
                DevelopmentName = DevelopmentInfo.DevelopmentDescription,
                DevelopmentImage = DevelopmentInfo.DevelopmentUrlImage,
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

            var triggerMail = new EmailEngineProvider()  { ViewModelInfo = purchaserReservationCapturedVM};
             
            triggerMail.BuildEmail();

            return avaialableReservationVM;
        }
    }
}
