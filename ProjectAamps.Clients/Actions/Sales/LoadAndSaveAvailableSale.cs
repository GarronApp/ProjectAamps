﻿using AAMPS.Clients.Queries.Sales;
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
    public class LoadAndSaveAvailableSale : ControllerAction
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

            var _availableSale = new AAMPS.Clients.AampService.Sale();

            _availableSale.SaleActiveStatusID = (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Reserved;
            avaialableReservationVM.SaleStatusId = (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Reserved;
            avaialableReservationVM.CurrentSalesStatus = _repoService.GetSaleActiveStatus((int)_availableSale.SaleActiveStatusID).SaleActiveStatusDescription;

            var _linkedUnit = _repoService.GetUnitById(int.Parse(SessionHandler.GetSessionContext("CurrentUnit")));

            _linkedUnit.UnitStatusID = (int)AAMPS.Clients.AampService.GetUnitStatusType.Reserved;
            avaialableReservationVM.UnitStatusId = (int)AAMPS.Clients.AampService.GetUnitStatusType.Reserved;
            _repoService.UpdateUnit(_linkedUnit);

            _availableSale.UnitID = _linkedUnit.UnitID;
            _availableSale.SaleStatusID = (int)AAMPS.Clients.AampService.GetSaleStatusType.Active;
            _availableSale.SaleReservationDt = avaialableReservationVM.SaleReservationDt != null ? DateTime.ParseExact(avaialableReservationVM.SaleReservationDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
            _availableSale.SaleReservationExpiryDt = avaialableReservationVM.SaleReservationExpiryDt != null ? DateTime.ParseExact(avaialableReservationVM.SaleReservationExpiryDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
            _availableSale.SaleReservationExtentionDt = avaialableReservationVM.SaleReservationExtentionDt != null ? DateTime.ParseExact(avaialableReservationVM.SaleReservationExtentionDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
            _availableSale.IndividualID = avaialableReservationVM.CurrentIndividualID;
            _availableSale.SaleAddedDt = DateTime.Now;
            _availableSale.SaleModifiedDt = DateTime.Now;
            _availableSale.SaleAddedByUser = 1;
            _availableSale.SaleModifiedByUser = 1;
            _availableSale.SaleDepositPaidBt = false;
            _availableSale.SalesBondRequiredBt = false;
            _availableSale.SalesReferalCommDueBt = false;
            _availableSale.SalesBondCommDueBt = false;
            _availableSale.SaleBondRequiredAmount = 0;

            _repoService.AddSale(_availableSale);

            query.AvailableReservationVM = avaialableReservationVM;

            return avaialableReservationVM;
        }
    }
}
