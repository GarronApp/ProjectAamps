using Aamps.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.ViewModels.Sales
{
    public partial class SalesViewModel
    {
         public SalesViewModel()
        {
            PreferedContactMethods = new List<PreferedContactMethod>();
        }
        [DataMember]
        public string Agent { get; set; }
        [DataMember]
        public string Agency { get; set; }
        [DataMember]
        public string AgentContactNo { get; set; }
        [DataMember]
        public string AgentEmailNo { get; set; }
        [DataMember]
        public string AgentIdNumber { get; set; }
        [DataMember]
        public int CurrentSalesStatusId { get; set; }
        [DataMember]
        public string CurrentSalesStatus { get; set; }
        [DataMember]
        public virtual List<PreferedContactMethod> PreferedContactMethods { get; set; }
        [DataMember]
        public DateTime? ReservationLapses { get; set; }
        [DataMember]
        public DateTime? ReservationTimeExtention { get; set; }
        [DataMember]
        public string CommentOnExtention { get; set; }
        [DataMember]
        public bool ReferralDue { get; set; }
        [DataMember]
        public bool DepositPaid { get; set; }
        [DataMember]
        public string DepositAmountPaid { get; set; }
        [DataMember]
        public bool ContractSigned { get; set; }
        [DataMember]
        public DateTime? PendingLapses { get; set; }
        [DataMember]
        public float SellingPriceInclVAT { get; set; }
        [DataMember]
        public float CommissionDue { get; set; }
        [DataMember]
        public DateTime? DateSignedBySeller { get; set; }
        [DataMember]
        public string BondRequired { get; set; }
        [DataMember]
        public float CashPayment { get; set; }
        [DataMember]
        public string IndividualFirstName { get; set; }
        [DataMember]
        public string IndividualLastName { get; set; }
        [DataMember]
        public string IndividualCellNo { get; set; }
        [DataMember]
        public string IndividualWorkNo { get; set; }
        [DataMember]
        public int IndividualContactMethod { get; set; }
        [DataMember]
        public string IndividualEmailAddress { get; set; }
        [DataMember]
        public int SaleStatusId { get; set; }
        [DataMember]
        public int UnitStatusId { get; set; }
        [DataMember]
        public int SaleTypeID { get; set; }
        [DataMember]
        public int MortgageOriginatorID { get; set; }
        [DataMember]
        public double SalesBondAmount { get; set; }
        [DataMember]
        public float SalesBondInterestRate { get; set; }
        [DataMember]
        public string SalesBondAccountNo { get; set; }
        [DataMember]
        public string SalesBondClientContactedDt { get; set; }
        [DataMember]
        public string SalesBondBondDocsRecDt { get; set; }
        [DataMember]
        public string SalesBondGrantedDt { get; set; }
        [DataMember]
        public string SalesBondClientAcceptDt { get; set; }
        [DataMember]
        public int SalesBondCommDueBt { get; set; }
        [DataMember]
        public string SaleContractSignedSellerDt { get; set; }
        [DataMember]
        public int SalesBondRequiredBt { get; set; }
        [DataMember]
        public string SalesBondRequiredDt { get; set; }
        [DataMember]
        public float SaleBondRequiredAmount { get; set; }
        [DataMember]
        public string SaleContractSignedPurchaserDt { get; set; }
        [DataMember]
        public string SaleBondDueTimeDt { get; set; }
        [DataMember]
        public string SaleBondDueExpiryDt { get; set; }
        [DataMember]
        public string Development { get; set; }
        [DataMember]
        public string UnitNumber { get; set; }
        [DataMember]
        public double PlotSize { get; set; }
        [DataMember]
        public double UnitPrice { get; set; }
        [DataMember]
        public double UnitSize { get; set; }
        [DataMember]
        public string UnitPhase { get; set; }
        [DataMember]
        public string UnitFloor { get; set; }

    }
 
}
