using AAMPS.Clients.Queries.Sales;
using AAMPS.Clients.ViewModels.Sales;
using App.Common.Controllers.Actions;
using App.Common.Security;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AAMPS.Clients.Actions.Sales
{
    public class UpdatePendingToSoldSale : ControllerAction
    {
        public int Id { get; set; }
        public int SaleId{ get; set; }
        public LoadSalesQuery query { get; set; }
        public PendingSaleViewModel PendingSaleVM { get; set; }
        public AAMPS.Clients.AampService.AampServiceClient _repoService { get; set; }
        public UpdatePendingToSoldSale()
         {

         }

        public UpdatePendingToSoldSale(LoadSalesQuery _query)
              : base(_query)
        {
            query = _query;
            OnBindModel();
        }

        public override void OnBindModel()
        {
            _repoService = new AampService.AampServiceClient();

            Id = query.UnitId;
            SaleId = query.SaleId;
            PendingSaleVM = query.PendingSaleViewVM;

            OnExecute();
        }

        public override object OnExecute()
        {
            var _currentSale = _repoService.GetSaleById(SaleId);
            var _linkedUnit = _repoService.GetUnitById(Id);

            _currentSale.PurchaserID = PendingSaleVM.CurrentPurchaserID;
            _currentSale.SaleContractSignedSellerDt = PendingSaleVM.SaleContractSignedSellerDt != null ? DateTime.ParseExact(PendingSaleVM.SaleContractSignedSellerDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
            _currentSale.SalesBondRequiredBt = PendingSaleVM.SalesBondRequiredBt == 1 ? true : false;
            _currentSale.SalesBondRequiredDt = PendingSaleVM.SalesBondRequiredDt != null ? DateTime.ParseExact(PendingSaleVM.SalesBondRequiredDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
            _currentSale.SaleBondDueTimeDt = PendingSaleVM.SaleBondDueTimeDt != null ? DateTime.ParseExact(PendingSaleVM.SaleBondDueTimeDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
            _currentSale.SaleBondDueExpiryDt = PendingSaleVM.SaleBondDueExpiryDt != null ? DateTime.ParseExact(PendingSaleVM.SaleBondDueExpiryDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
            _currentSale.SaleBondRequiredAmount = PendingSaleVM.SaleBondRequiredAmount != null ? (float)PendingSaleVM.SaleBondRequiredAmount : 0.00;
            _currentSale.SaleTypeID = ResolveSaleTypeId(PendingSaleVM.SaleTypeID);
            _currentSale.SalesBondGrantedDt = PendingSaleVM.SalesBondGrantedDt != null ? DateTime.ParseExact(PendingSaleVM.SalesBondGrantedDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
            _currentSale.SalesBondClientAcceptDt = PendingSaleVM.SalesBondClientAcceptDt != null ? DateTime.ParseExact(PendingSaleVM.SalesBondClientAcceptDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
            _currentSale.SalesBondAmount = PendingSaleVM.SalesBondAmount != null ? (double)PendingSaleVM.SalesBondAmount : 0.0;
            _currentSale.SalesBondClientContactedDt = PendingSaleVM.SalesBondClientContactedDt != null ? DateTime.ParseExact(PendingSaleVM.SalesBondClientContactedDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
            _currentSale.SalesBondBondDocsRecDt = PendingSaleVM.SalesBondBondDocsRecDt != null ? DateTime.ParseExact(PendingSaleVM.SalesBondBondDocsRecDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
            _currentSale.SalesBondCommDueBt = PendingSaleVM.SalesBondCommDueBt == 1 ? true : false;
            _currentSale.SalesBondInterestRate = PendingSaleVM.SalesBondInterestRate;
            _currentSale.SaleModifiedDt = DateTime.Now;
            _currentSale.SaleModifiedByUser = 1;

            if(_currentSale.SaleBondRequiredAmount != null && _currentSale.SaleBondRequiredAmount > 0)
            {
                HttpContext.Current.Session.Add("SalesRequiredBondAmount", _currentSale.SaleBondRequiredAmount);
            }

            if (PendingSaleVM.PendingFormCompleteAndValid != 0 && PendingSaleVM.PendingFormCompleteAndValid != null)
            {
                if (PendingSaleVM.SaleContractSignedSellerDt != null && PendingSaleVM.SaleTypeID == 0 || PendingSaleVM.SaleTypeID == 1)
                {
                    if (_currentSale.SaleActiveStatusID == (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Pending)
                    {
                        _currentSale.SaleActiveStatusID = (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Sold;
                        PendingSaleVM.SaleStatusId = (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Sold;
                        PendingSaleVM.CurrentSalesStatus = _repoService.GetSaleActiveStatus((int)_currentSale.SaleActiveStatusID).SaleActiveStatusDescription;
                    }
                    if (_linkedUnit.UnitStatusID == (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Pending)
                    {
                        _linkedUnit.UnitStatusID = (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Sold;
                        PendingSaleVM.UnitStatusId = (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Sold;
                        _repoService.UpdateUnit(_linkedUnit);
                    }
                }

                    _repoService.SaveUpdateReservation(_currentSale);
                
            }

            PendingSaleVM.PendingFormCompleteAndValid = PendingSaleVM.PendingFormCompleteAndValid;
            
            query.PendingSaleViewVM = PendingSaleVM;
            

            return PendingSaleVM;
        }

        private int ResolveSaleTypeId(int saleTypeID)
        {
            switch (saleTypeID)
            {
                case 0:
                    return 1;
                case 1:
                    return 2;
                case 2:
                    return 3;
                default:
                    break;
            }
            return 0;
        }


    }
}
