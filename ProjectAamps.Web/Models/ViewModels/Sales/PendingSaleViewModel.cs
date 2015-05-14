using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAMPS.Web.Models.ViewModels.Sales
{
    public class PendingSaleViewModel
    {
        public int SaleStatusId { get; set; }
        public int UnitStatusId { get; set; }
        public int SaleTypeID { get; set; }
        public string CurrentSalesStatus { get; set; }
        public int BondOriginatorID { get; set; }
        public double SalesBondAmount { get; set; }
        public double SalesTotalDepositAmount { get; set; }
        public float SalesBondInterestRate { get; set; }
        public string SalesBondAccountNo { get; set; }
        public string SalesBondClientContactedDt { get; set; }
        public string SalesBondBondDocsRecDt { get; set; }
        public string SalesBondGrantedDt { get; set; }
        public string SalesBondClientAcceptDt { get; set; }
        public int SalesBondCommDueBt { get; set; }
        public string SaleContractSignedSellerDt { get; set; }
        public int SalesBondRequiredBt { get; set; }
        public string SalesBondRequiredDt { get; set; }
        public float SaleBondRequiredAmount { get; set; }
        public string SaleContractSignedPurchaserDt { get; set; }
        public string SaleBondDueTimeDt { get; set; }
        public string SaleBondDueExpiryDt { get; set; }
        public int CurrentPurchaserID { get; set; }

        



    }
}