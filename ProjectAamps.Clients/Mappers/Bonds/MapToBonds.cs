using AAMPS.Clients.AampService;
using App.Common.Security;
using AAMPS.Clients.Queries.Bonds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AAMPS.Clients.ViewModels.Bonds;
using AAMPS.Clients.ViewModels.Sales;
using AAMPS.Clients.ViewModels.Originator;


namespace AAMPS.Clients.Mappers.Bonds
{
    public class MapToBonds : Mapper<BondsViewModel>
    {
        public AAMPS.Clients.AampService.AampServiceClient _repoService = new AampServiceClient();
        #region Properties
        
        public Sale currentSalesAgent { get; set; }
        public Unit _currentUnit { get; set; }
        public OriginatorTr orginators { get; set; }
        public BondsViewModel Result { get; set; }

        #endregion Properties
        public MapToBonds()
        {
        }
        public MapToBonds(MapBondsQuery query)
        {
            currentSalesAgent = query.Sale;
            _currentUnit = query.Unit;
            CollectBondsViewModel();
        }

        public BondsViewModel CollectBondsViewModel()
        {
            var result = Map();
            if (result != null)
                Result = result;
            return result;
        }

        #region Virtual Methods
        public override BondsViewModel Map()
        {
            var saleAgent = new SalesViewModel();

            SessionHandler.SessionContext("CurrentSaleId", currentSalesAgent.SaleID);

            var orginators = _repoService.GetOriginatorBySalesId(int.Parse(SessionHandler.GetSessionContext("CurrentSaleId")));

            var viewModel = new BondsViewModel()
            {
                UnitId = _currentUnit.UnitID,
                UnitNumber = _currentUnit.UnitNumber,
                UnitSize = _currentUnit.UnitSize,
                UnitFloor = _currentUnit.UnitFloor,
                UnitBlock = _currentUnit.UnitBlock,
                UnitPhase = _currentUnit.UnitPhase,
                UnitPriceIncluding = _currentUnit.UnitPriceIncluding,
                UnitActiveDate = _currentUnit.UnitActiveDate,
                UnitStatusID = _repoService.GetUnitStatusById(_currentUnit.UnitStatusID).UnitStatusDescription,
                DevelopmentDescription = _repoService.GetDevelopmentById(_currentUnit.DevelopmentID).DevelopmentDescription,

                IndividualFirstName = currentSalesAgent.Individual.IndividualName,
                IndividualLastName = currentSalesAgent.Individual.IndividualSurname,
                IndividualCellNo = currentSalesAgent.Individual.IndividualContactCell,
                IndividualEmailAddress = currentSalesAgent.Individual.IndividualEmail,

                DepositPaid = currentSalesAgent.SaleDepositPaidBt == true ? "Yes" : "No",

                SalesDepoistPaidDt = currentSalesAgent.SalesDepoistPaidDt.HasValue ? currentSalesAgent.SalesDepoistPaidDt.GetValueOrDefault().ToString("dd/MM/yyyy") : null,
                SaleContractSignedPurchaserDt = currentSalesAgent.SaleContractSignedPurchaserDt.HasValue ? currentSalesAgent.SaleContractSignedPurchaserDt.GetValueOrDefault().ToString("dd/MM/yyyy") : currentSalesAgent.SaleContractSignedPurchaserDt.GetValueOrDefault().ToString(),
                SaleBondRequiredAmount = currentSalesAgent.SaleBondRequiredAmount,
                SalesTotalDepositAmount = currentSalesAgent.SalesTotalDepositAmount.HasValue ? currentSalesAgent.SalesTotalDepositAmount.GetValueOrDefault() : currentSalesAgent.SalesTotalDepositAmount.GetValueOrDefault(),
                SalesBondRequiredDt = currentSalesAgent.SalesBondRequiredDt.HasValue ? currentSalesAgent.SalesBondRequiredDt.GetValueOrDefault().ToString("dd/MM/yyyy") : currentSalesAgent.SalesBondRequiredDt.GetValueOrDefault().ToString(),
                SalesBondRequiredBt = currentSalesAgent.SalesBondRequiredBt == true ? "Yes" : "No",
                SalesBondGrantedDt = currentSalesAgent.SalesBondGrantedDt.HasValue ? currentSalesAgent.SalesBondGrantedDt.GetValueOrDefault().ToString("dd/MM/yyyy") : currentSalesAgent.SalesBondGrantedDt.GetValueOrDefault().ToString(),
                SalesBondClientContactedDt = currentSalesAgent.SalesBondClientContactedDt.HasValue ? currentSalesAgent.SalesBondClientContactedDt.GetValueOrDefault().ToString("dd/MM/yyyy") : currentSalesAgent.SalesBondClientContactedDt.GetValueOrDefault().ToString(),
                SalesBondClientContactedBt = currentSalesAgent.SalesBondClientContactedDt.HasValue ? 1 : 0,
                SalesBondBondDocsRecDt = currentSalesAgent.SalesBondBondDocsRecDt.HasValue ? currentSalesAgent.SalesBondBondDocsRecDt.GetValueOrDefault().ToString("dd/MM/yyyy") : currentSalesAgent.SalesBondBondDocsRecDt.GetValueOrDefault().ToString(),
                SalesBondBondDocsRecBt = currentSalesAgent.SalesBondBondDocsRecDt.HasValue && currentSalesAgent.SalesBondClientContactedDt.HasValue ? 1 : 0,
                SalesBondAccountNo = currentSalesAgent.SalesBondAccountNo,
                Orginators = LoadOrginators()
            };

            return viewModel;
        }
        #endregion Virtual Methods

        #region Private Methods
        public List<OrginatorViewModel> LoadOrginators()
        {
            List<OrginatorViewModel> orginatorList = new List<OrginatorViewModel>();

            var currentSalesAgent = _repoService.GetSaleByUnitId(int.Parse(SessionHandler.GetSessionContext("CurrentUnit")));
            var orginators = _repoService.GetOriginatorBySalesId(int.Parse(SessionHandler.GetSessionContext("CurrentSaleId")));

            foreach (var item in orginators)
            {
                OrginatorViewModel viewModel = new OrginatorViewModel()
                {
                    OriginatorTrID = item.OriginatorTrID,
                    BankName = _repoService.GetBankById((int)item.BankID).BankDescription,
                    MOStatus = _repoService.GetMOStatusById((int)item.MOStatusID).MOStatusDescription,
                    //OriginatorTrAcceptDt = item.OriginatorTrAcceptDt.HasValue ? item.OriginatorTrAcceptDt.GetValueOrDefault().ToString("dd/MM/yyyy") : item.OriginatorTrAcceptDt.GetValueOrDefault().ToString(),
                    OriginatorTrAcceptDt = item.OriginatorTrAcceptDt.HasValue ? item.OriginatorTrAcceptDt.GetValueOrDefault().ToString("dd/MM/yyyy") : null,
                    OriginatorTrAddedDt = item.OriginatorTrAddedDt != null ? item.OriginatorTrAddedDt.ToShortDateString() : item.OriginatorTrAddedDt.ToString(),
                    //OriginatorTrSubmittedDt = item.OriginatorTrSubmittedDt.HasValue ? item.OriginatorTrSubmittedDt.GetValueOrDefault().ToString("dd/MM/yyyy") : item.OriginatorTrSubmittedDt.GetValueOrDefault().ToString(),
                    OriginatorTrSubmittedDt = item.OriginatorTrSubmittedDt.HasValue ? item.OriginatorTrSubmittedDt.GetValueOrDefault().ToString("dd/MM/yyyy") : null,
                    //OriginatorTrAIPDt = item.OriginatorTrAIPDt.HasValue ? item.OriginatorTrAIPDt.GetValueOrDefault().ToString("dd/MM/yyyy") : item.OriginatorTrAIPDt.GetValueOrDefault().ToString(),
                    OriginatorTrAIPDt = item.OriginatorTrAIPDt.HasValue ? item.OriginatorTrAIPDt.GetValueOrDefault().ToString("dd/MM/yyyy") : null,
                    OriginatorTrBondAmount = item.OriginatorTrBondAmount,
                    OriginatorTrIntRate = item.OriginatorTrIntRate,
                    //OriginatorTrGrantDt = item.OriginatorTrGrantDt.HasValue ? item.OriginatorTrGrantDt.GetValueOrDefault().ToString("dd/MM/yyyy") : item.OriginatorTrGrantDt.GetValueOrDefault().ToString()
                    OriginatorTrGrantDt = item.OriginatorTrGrantDt.HasValue ? item.OriginatorTrGrantDt.GetValueOrDefault().ToString("dd/MM/yyyy") : null
                };

                orginatorList.Add(viewModel);

            }

            return orginatorList;
        }
        #endregion Private Methods
    }
}
