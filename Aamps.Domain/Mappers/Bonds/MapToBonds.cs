using Aamps.Domain.Models;
using Aamps.Domain.ViewModels.Sales;
using AAMPS.Domain.ViewModels.Bonds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.Mappers.Bonds
{
    public class MapToBonds : Mapper<BondsViewModel>
    {
        #region Properties

        public int UnitId { get; set; }
        public Sale currentSalesAgent { get; set; }
        public object _currentUnit { get; set; }
        public object orginators { get; set; }
        
        #endregion Properties


        public MapToBonds()
        {
        }

        public override BondsViewModel Map()
        {
            var saleAgent = new SalesViewModel();
            
            Session.Add("CurrentSaleId", currentSalesAgent.SaleID);

            var _currentUnit = _repoService.GetUnitByDevelopmentId(currentSalesAgent.Unit.DevelopmentID).FirstOrDefault();

            
            var orginators = _repoService.GetOriginatorBySalesId(int.Parse(Session["CurrentSaleId"].ToString()));

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

                SalesDepoistPaidDt = currentSalesAgent.SalesDepoistPaidDt.HasValue ? currentSalesAgent.SalesDepoistPaidDt.GetValueOrDefault().ToString("dd/MM/yyyy") : currentSalesAgent.SalesDepoistPaidDt.GetValueOrDefault().ToString(),
                SaleContractSignedPurchaserDt = currentSalesAgent.SaleContractSignedPurchaserDt.HasValue ? currentSalesAgent.SaleContractSignedPurchaserDt.GetValueOrDefault().ToString("dd/MM/yyyy") : currentSalesAgent.SaleContractSignedPurchaserDt.GetValueOrDefault().ToString(),
                SaleBondRequiredAmount = currentSalesAgent.SalesBondAmount.HasValue ? currentSalesAgent.SalesBondAmount.GetValueOrDefault() : currentSalesAgent.SalesBondAmount.GetValueOrDefault(),
                SalesBondRequiredDt = currentSalesAgent.SalesBondRequiredDt.HasValue ? currentSalesAgent.SalesBondRequiredDt.GetValueOrDefault().ToString("dd/MM/yyyy") : currentSalesAgent.SalesBondRequiredDt.GetValueOrDefault().ToString(),
                SalesBondRequiredBt = currentSalesAgent.SalesBondRequiredBt == true ? "Yes" : "No",
                SalesBondGrantedDt = currentSalesAgent.SalesBondGrantedDt.HasValue ? currentSalesAgent.SalesBondGrantedDt.GetValueOrDefault().ToString("dd/MM/yyyy") : currentSalesAgent.SalesBondGrantedDt.GetValueOrDefault().ToString(),
                SalesBondClientContactedDt = currentSalesAgent.SalesBondClientContactedDt.HasValue ? currentSalesAgent.SalesBondClientContactedDt.GetValueOrDefault().ToString("dd/MM/yyyy") : currentSalesAgent.SalesBondClientContactedDt.GetValueOrDefault().ToString(),
                SalesBondClientContactedBt = currentSalesAgent.SalesBondClientContactedDt.HasValue ? 1 : 0,
                SalesBondBondDocsRecDt = currentSalesAgent.SalesBondBondDocsRecDt.HasValue ? currentSalesAgent.SalesBondBondDocsRecDt.GetValueOrDefault().ToString("dd/MM/yyyy") : currentSalesAgent.SalesBondBondDocsRecDt.GetValueOrDefault().ToString(),
                SalesBondBondDocsRecBt = currentSalesAgent.SalesBondBondDocsRecDt.HasValue ? 1 : 0,
                SalesBondAccountNo = currentSalesAgent.SalesBondAccountNo,
                Orginators = LoadOrginators()
            };

            return viewModel;
        }
    }
}
