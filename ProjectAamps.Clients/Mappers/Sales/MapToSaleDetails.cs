using AAMPS.Clients.AampService;
using AAMPS.Clients.ViewModels.Sales;
using AAMPS.Clients.Queries.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Common.Security;

namespace AAMPS.Clients.Mappers.Sales
{
    public class MapToSaleDetails : Mapper<SalesViewModel>
    {
        public AAMPS.Clients.AampService.AampServiceClient _repoService = new AampServiceClient();

        #region Properties

        public Sale _currentSale { get; set; }
        public Unit _currentUnit { get; set; }
        public SalesViewModel SalesViewModelResult { get; set; }

        #endregion Properties

        #region Constructors
        public MapToSaleDetails()
        {
        }
        public MapToSaleDetails(MapToSaleDetailsQuery query)
        {
            _currentSale = query.Sale;

            CollectSalesViewModel();
        }

        #endregion Constructors

        #region Public Methods
        public SalesViewModel CollectSalesViewModel()
        {
            var mappingResult = Map();

            if (mappingResult != null)
                return SalesViewModelResult = mappingResult;
            else
                return null;
        }
        #endregion Public Methods

        #region Virtual Methods
        public override SalesViewModel Map()
        {
            SalesViewModel viewModel = new SalesViewModel();

            SessionHandler.SessionContext("CurrentSaleId", _currentSale.SaleID);

            int saleActiveStatus = (int)_currentSale.SaleActiveStatusID;
            viewModel.CurrentSalesStatusId = _repoService.GetSaleActiveStatus(saleActiveStatus).SaleActiveStatusID;
            viewModel.CurrentSalesStatus = _repoService.GetSaleActiveStatus(saleActiveStatus).SaleActiveStatusDescription;
            viewModel.ReservationLapses = _currentSale.SaleReservationDt;
            viewModel.ReservationTimeExtention = _currentSale.SaleReservationExtentionDt;
            viewModel.ContractSigned = false;
            viewModel.DepositPaid = _currentSale.SaleDepositPaidBt;
            viewModel.DateSignedBySeller = _currentSale.SaleContractSignedSellerDt;
            viewModel.Development = _repoService.GetDevelopmentById(_currentSale.Unit.DevelopmentID).DevelopmentDescription;
            viewModel.UnitNumber = _currentSale.Unit.UnitNumber;
            viewModel.UnitSize = _currentSale.Unit.UnitSize;
            viewModel.UnitPrice = _currentSale.Unit.UnitPrice;
            viewModel.UnitPriceIncluding = _currentSale.Unit.UnitPriceIncluding;
            viewModel.UnitPhase = _currentSale.Unit.UnitPhase;
            viewModel.UnitFloor = _currentSale.Unit.UnitFloor;
            viewModel.PlotSize = _currentSale.Unit.UnitErfSize;

            SessionHandler.SessionContext("CurrentIndividualId", _currentSale.Individual.IndividualID);
            MapIndividual(viewModel, _currentSale);

            if (_currentSale.Purchaser != null)
            {
                MapPurchaser(viewModel, _currentSale);
            }

            viewModel.SaleContractSignedPurchaserDt = _currentSale.SaleContractSignedPurchaserDt.HasValue ? _currentSale.SaleContractSignedPurchaserDt.Value.ToString() : null;
            viewModel.SalesDepositProofID = _currentSale.SalesDepositProofID != null ? (int)_currentSale.SalesDepositProofID : 0;
            viewModel.SalesDepositProofDt = _currentSale.SalesDepositProofDt.HasValue ? _currentSale.SalesDepositProofDt.Value.ToString() : string.Empty;
            viewModel.SalesDepoistPaidDt = _currentSale.SalesDepoistPaidDt.HasValue ? _currentSale.SalesDepoistPaidDt.Value.ToString() : string.Empty;
            viewModel.SalesBondAmount = _currentSale.SalesBondAmount != null ? (double)_currentSale.SalesBondAmount : 0.0;
            viewModel.SaleDepositPaidBt = _currentSale.SaleDepositPaidBt == true ? 1 : 0;
            viewModel.SaleTypeID = _currentSale.SaleTypeID != null ? (int)_currentSale.SaleTypeID : 0;
            viewModel.SalesBondAccountNo = _currentSale.SalesBondAccountNo;
            viewModel.SalesBondInterestRate = _currentSale.SalesBondInterestRate != null ? (float)_currentSale.SalesBondInterestRate : 0;
            viewModel.SalesTotalDepositAmount = _currentSale.SalesTotalDepositAmount != null ? (float)_currentSale.SalesTotalDepositAmount : 0;
            viewModel.SalesBondGrantedDt = _currentSale.SalesBondGrantedDt.HasValue ? _currentSale.SalesBondGrantedDt.Value.ToString() : string.Empty;
            viewModel.SalesBondGrantedBt = _currentSale.SalesBondGrantedDt.HasValue ? 1 : 0;
            viewModel.SalesBondClientAcceptDt = _currentSale.SalesBondClientAcceptDt.HasValue ? _currentSale.SalesBondClientAcceptDt.Value.ToString() : string.Empty;
            viewModel.SalesBondClientAcceptBt = _currentSale.SalesBondClientAcceptDt.HasValue ? 1 : 0;
            viewModel.SalesBondClientContactedDt = _currentSale.SalesBondClientContactedDt.HasValue ? _currentSale.SalesBondClientContactedDt.Value.ToString() : string.Empty;
            viewModel.SalesBondClientContactedBt = _currentSale.SalesBondClientContactedDt.HasValue ? 1 : 0;
            viewModel.SalesBondBondDocsRecDt = _currentSale.SalesBondBondDocsRecDt.HasValue ? _currentSale.SalesBondBondDocsRecDt.Value.ToString() : string.Empty;
            viewModel.SalesBondBondDocsRecBt = _currentSale.SalesBondBondDocsRecDt.HasValue ? 1 : 0;

            viewModel.SaleContractSignedSellerDt = _currentSale.SaleContractSignedSellerDt.HasValue ? _currentSale.SaleContractSignedSellerDt.Value.ToString() : string.Empty;
            viewModel.SalesBondRequiredDt = _currentSale.SalesBondRequiredDt.HasValue ? _currentSale.SalesBondRequiredDt.Value.ToString() : string.Empty;
            viewModel.SaleBondDueTimeDt = _currentSale.SaleBondDueTimeDt.HasValue ? _currentSale.SaleBondDueTimeDt.Value.ToString() : string.Empty;
            viewModel.SaleBondDueExpiryDt = _currentSale.SaleBondDueExpiryDt.HasValue ? _currentSale.SaleBondDueExpiryDt.Value.ToString() : string.Empty;
            viewModel.SalesBondCommDueBt = _currentSale.SalesBondCommDueBt == true ? 1 : 0;
            viewModel.SaleBondRequiredAmount = _currentSale.SaleBondRequiredAmount;

            if (_currentSale.BankID != null)
            {
                viewModel.SaleBondBank = _repoService.GetBankById((int)_currentSale.BankID).BankDescription;
            }

            if (_currentSale.BondOriginatorID != null)
            {
                var currentOrginator = _repoService.GetOriginatorById((int)_currentSale.BondOriginatorID);
                if (currentOrginator != null)
                {
                    viewModel.SaleBondBank = _repoService.GetBankById(currentOrginator.BankID).BankDescription;
                }
            }

            return viewModel;
        }

        #endregion Virtual Methods

        #region Private Methods
        private void MapPurchaser(SalesViewModel viewModel, Sale _currentSale)
        {
            viewModel.EntityTypeID = _currentSale.Purchaser.EntityTypeID;
            viewModel.PurchaserDescription = _currentSale.Purchaser.PurchaserDescription;
            viewModel.PurchaserContactPerson = _currentSale.Purchaser.PurchaserContactPerson;
            viewModel.PurchaserContactCell = _currentSale.Purchaser.PurchaserContactCell;
            viewModel.PurchaserContactHome = _currentSale.Purchaser.PurchaserContactHome;
            viewModel.PurchaserContactWork = _currentSale.Purchaser.PurchaserContactWork;
            viewModel.PurchaserEmail = _currentSale.Purchaser.PurchaserEmail;
            viewModel.PurchaserAddress = _currentSale.Purchaser.PurchaserAddress;
            viewModel.PurchaserAddress1 = _currentSale.Purchaser.PurchaserAddress1;
            viewModel.PurchaserAddress2 = _currentSale.Purchaser.PurchaserAddress2;
            viewModel.PurchaserAddress3 = _currentSale.Purchaser.PurchaserAddress3;
            viewModel.PurchaserSuburb = _currentSale.Purchaser.PurchaserSuburb;
            viewModel.PurchaserPostalCode = _currentSale.Purchaser.PurchaserPostalCode;
        }

        private void MapIndividual(SalesViewModel viewModel, Sale _currentSale)
        {
            viewModel.IndividualID = _currentSale.Individual.IndividualID;
            viewModel.IndividualName = _currentSale.Individual.IndividualName;
            viewModel.IndividualSurname = _currentSale.Individual.IndividualSurname;
            viewModel.IndividualContactCell = _currentSale.Individual.IndividualContactCell;
            viewModel.IndividualContactWork = _currentSale.Individual.IndividualContactWork;
            viewModel.IndividualEmail = _currentSale.Individual.IndividualEmail;
            viewModel.PreferedContactMethodID = _currentSale.Individual.PreferedContactMethodID;
        }

        #endregion

    }
}
