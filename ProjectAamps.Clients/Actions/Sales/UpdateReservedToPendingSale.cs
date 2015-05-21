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

namespace AAMPS.Clients.Actions.Sales
{
    public class UpdateReservedToPendingSale : ControllerAction
    {
        public int Id { get; set; }
        public int SaleId{ get; set; }
        public LoadSalesQuery query { get; set; }
        public ReservedSaleViewModel ReservedSaleVM { get; set; }
        public AAMPS.Clients.AampService.AampServiceClient _repoService { get; set; }
        public UpdateReservedToPendingSale()
         {

         }

        public UpdateReservedToPendingSale(LoadSalesQuery _query)
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
            ReservedSaleVM = query.ReservedSaleVM;

            OnExecute();
        }

        public override object OnExecute()
        {
            var _currentSale = _repoService.GetSaleById(SaleId);
            var _linkedUnit = _repoService.GetUnitById(Id);

            _currentSale.SaleContractSignedPurchaserDt = ReservedSaleVM.SaleContractSignedPurchaserDt != null ? DateTime.ParseExact(ReservedSaleVM.SaleContractSignedPurchaserDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
            _currentSale.SalesDepositProofID = ReservedSaleVM.SalesDepositProofID;
            _currentSale.SaleDepositPaidBt = ReservedSaleVM.SaleDepositPaidBt == 1 ? true : false;
            _currentSale.SalesDepoistPaidDt = ReservedSaleVM.SalesDepoistPaidDt != null ? DateTime.ParseExact(ReservedSaleVM.SalesDepoistPaidDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
            _currentSale.SalesDepositProofDt = ReservedSaleVM.SalesDepositProofDt != null ? DateTime.ParseExact(ReservedSaleVM.SalesDepositProofDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
            //_currentSale.SalesTotalDepositAmount = sale.SalesTotalDepositAmount != null ? (double)sale.SalesTotalDepositAmount : 0.0;
            _currentSale.SalesTotalDepositAmount = ReservedSaleVM.SalesTotalDepositAmount;
            _currentSale.SaleModifiedDt = DateTime.Now;
            _currentSale.SaleModifiedByUser = 1;

            if (_currentSale.SaleActiveStatusID == (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Reserved)
            {
                _currentSale.SaleActiveStatusID = (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Pending;
                ReservedSaleVM.SaleStatusId = (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Pending;
                ReservedSaleVM.CurrentSalesStatus = _repoService.GetSaleActiveStatus((int)_currentSale.SaleActiveStatusID).SaleActiveStatusDescription;
            }

            if (_linkedUnit.UnitStatusID == (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Reserved)
            {
                _linkedUnit.UnitStatusID = (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Pending;
                ReservedSaleVM.UnitStatusId = (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Pending;
                _repoService.UpdateUnit(_linkedUnit);
            }

            _repoService.SaveUpdateReservation(_currentSale);

            query.ReservedSaleVM = ReservedSaleVM;

            return ReservedSaleVM;
        }
    }
}
