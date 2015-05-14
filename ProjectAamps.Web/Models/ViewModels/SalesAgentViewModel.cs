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

        public int PurchaserID { get; set; }
        public int EntityTypeID { get; set; }
        public string PurchaserDescription { get; set; }
        public string PurchaserRegID { get; set; }
        public string PurchaserContactPerson { get; set; }
        public string PurchaserContactCell { get; set; }
        public string PurchaserContactHome { get; set; }
        public string PurchaserContactWork { get; set; }
         public string PurchaserEmail { get; set; }
        public string PurchaserAddress { get; set; }
        public string PurchaserAddress1 { get; set; }
        public string PurchaserAddress2 { get; set; }
        public string PurchaserAddress3 { get; set; }
        public string PurchaserPostalCode { get; set; }
        public string PurchaserSuburb { get; set; }

        public int SaleStatusId { get; set; }
        public int UnitStatusId { get; set; }
        public int SaleTypeID { get; set; }
        public int BondOriginatorID { get; set; }
        public float SalesBondInterestRate { get; set; }
        public float SalesTotalDepositAmount {get;set;}
        public string SalesBondAccountNo { get; set; }
        public string SalesBondClientContactedDt { get; set; }
        public string SalesBondBondDocsRecDt { get; set; }
        public string SalesBondGrantedDt { get; set; }
        public string SalesBondClientAcceptDt { get; set; }
        public int SalesBondCommDueBt { get; set; }
        public string SaleContractSignedSellerDt { get; set; }
        public int SalesBondRequiredBt { get; set; }
        public string SalesBondRequiredDt { get; set; }
        public double SaleBondRequiredAmount { get; set; }
        public string SaleBondDueTimeDt { get; set; }
        public string SaleBondDueExpiryDt { get; set; }

        public int SalesBondBondDocsRecBt { get; set; }
        public int SalesBondClientContactedBt { get; set; }
        public int SalesBondClientAcceptBt { get; set; }
        public int SalesBondGrantedBt { get; set; }


        public string SaleBondBank { get; set; }
        public int OriginatorTrSubmittedBt { get; set; }
        public string OriginatorTrSubmittedDt { get; set; }
        public int OriginatorTrAIPBt { get; set; }
        public string OriginatorTrAIPDt { get; set; }
        public int OriginatorTrGrantBt { get; set; }
        public string OriginatorTrGrantDt { get; set; }

        public int OriginatorTrAcceptedBt { get; set; }
        public string OriginatorTrAcceptDt { get; set; }
        public int OriginatorTrBondAmountBt { get; set; }
        public double OriginatorTrBondAmount { get; set; }
        public int OriginatorTrIntRateBt { get; set; }
        public double OriginatorTrIntRate { get; set; }
        public int OriginatorTrAddedBt { get; set; }
        public string OriginatorTrAddedDt { get; set; }
        public string OriginatorTrModifiedDt { get; set; }

        public string SaleContractSignedPurchaserDt { get; set; }
        public int SalesDepositProofID { get; set; }
        public int SalesDepositProofBt { get; set; }
        public string SalesDepositProofDt { get; set; }
        public double SalesBondAmount { get; set; }
        public string SalesDepoistPaidDt { get; set; }
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