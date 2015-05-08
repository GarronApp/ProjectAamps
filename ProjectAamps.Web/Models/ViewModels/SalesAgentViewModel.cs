using Aamps.Domain.Models;
using AAMPS.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAMPS.Web.Models.ViewModels
{
    public class SalesAgentViewModel
    {
        public SalesAgentViewModel()
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
        public string IsNewSale { get; set; }

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

        public string IndividualName { get; set; }
        public string IndividualSurname { get; set; }
        public string IndividualContactCell { get; set; }
        public string IndividualContactWork { get; set; }
        public int PreferedContactMethodID { get; set; }
        public string IndividualEmail { get; set; }

        public int SaleStatusId { get; set; }
        public int UnitStatusId { get; set; }
        public int SaleTypeID { get; set; }
        public int BondOriginatorID { get; set; }
        public float SalesBondInterestRate { get; set; }
        public string SalesBondAccountNo { get; set; }
        public DateTime? SalesBondClientContactedDt { get; set; }
        public DateTime? SalesBondBondDocsRecDt { get; set; }
        public DateTime? SalesBondGrantedDt { get; set; }
        public DateTime? SalesBondClientAcceptDt { get; set; }
        public int SalesBondCommDueBt { get; set; }
        public DateTime? SaleContractSignedSellerDt { get; set; }
        public int SalesBondRequiredBt { get; set; }
        public DateTime? SalesBondRequiredDt { get; set; }
        public double SaleBondRequiredAmount { get; set; }
        public DateTime? SaleBondDueTimeDt { get; set; }
        public DateTime? SaleBondDueExpiryDt { get; set; }

        public DateTime? SaleContractSignedPurchaserDt { get; set; }
        public int SalesDepositProofID { get; set; }
        public int SalesDepositProofBt { get; set; }
        public DateTime? SalesDepositProofDt { get; set; }
        public double SalesBondAmount { get; set; }
        public DateTime? SalesDepoistPaidDt { get; set; }
        public int SaleDepositPaidBt { get; set; }


        public string Development { get; set; }
        public string UnitNumber { get; set; }
        public double PlotSize { get; set; }
        public double UnitPrice { get; set; }
        public double UnitSize { get; set; }
        public string UnitPhase { get; set; }
        public string UnitFloor { get; set; }

        




    }
}