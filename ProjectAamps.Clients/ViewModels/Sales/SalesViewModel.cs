using AAMPS.Clients.AampService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAMPS.Clients.ViewModels.Sales
{
    public partial class SalesViewModel
    {
        public SalesViewModel()
        {
            PreferedContactMethods = new List<PreferedContactMethod>();
        }
        
        public string Agent { get; set; }
        
        public string Agency { get; set; }
        
        public string AgentContactNo { get; set; }
        
        public string AgentEmailNo { get; set; }
        
        public string AgentIdNumber { get; set; }
        
        public int CurrentSalesStatusId { get; set; }
        
        public string CurrentSalesStatus { get; set; }
        
        public virtual List<PreferedContactMethod> PreferedContactMethods { get; set; }
        
        public DateTime? ReservationLapses { get; set; }
        
        public DateTime? ReservationTimeExtention { get; set; }
        
        public string CommentOnExtention { get; set; }
        
        public bool ReferralDue { get; set; }
        
        public bool DepositPaid { get; set; }
        
        public string DepositAmountPaid { get; set; }
        
        public bool ContractSigned { get; set; }
        
        public DateTime? PendingLapses { get; set; }
        
        public float SellingPriceInclVAT { get; set; }
        
        public float CommissionDue { get; set; }
        
        public DateTime? DateSignedBySeller { get; set; }
        
        public string BondRequired { get; set; }
        
        public float CashPayment { get; set; }
        
        public string IndividualFirstName { get; set; }
        
        public string IndividualLastName { get; set; }
        
        public string IndividualCellNo { get; set; }
        
        public string IndividualWorkNo { get; set; }
        
        public int IndividualContactMethod { get; set; }
        
        public string IndividualEmailAddress { get; set; }
        
        public int SaleStatusId { get; set; }
        
        public int UnitStatusId { get; set; }
        
        public int SaleTypeID { get; set; }
        
        public int MortgageOriginatorID { get; set; }
        
        public double SalesBondAmount { get; set; }
        
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

        public string OriginatorTrSubmittedDt { get; set; }

        public string OriginatorTrAIPDt { get; set; }

        public string OriginatorTrGrantDt { get; set; }

        public int OriginatorTrAcceptedBt { get; set; }

        public string OriginatorTrAcceptDt { get; set; }

        public double OriginatorTrBondAmount { get; set; }

        public double OriginatorTrIntRate { get; set; }

        public string OriginatorTrAddedDt { get; set; }

        public string OriginatorTrModifiedDt { get; set; }
        
        public string Development { get; set; }
        
        public string UnitNumber { get; set; }
        
        public double PlotSize { get; set; }
        
        public double UnitPrice { get; set; }
        
        public double UnitSize { get; set; }
        
        public string UnitPhase { get; set; }
        
        public string UnitFloor { get; set; }

    }
}
