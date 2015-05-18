using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class Sale
    {
        public Sale()
        {
            this.BondAtts = new List<BondAtt>();
            this.Comments = new List<Comment>();
            this.BondConditionTrs = new List<BondConditionTr>();
            this.CommissionTrs = new List<CommissionTr>();
            this.FinancialTrs = new List<FinancialTr>();
            this.OriginatorTrs = new List<OriginatorTr>();
            this.TransAtts = new List<TransAtt>();
        }
        [DataMember]
        public int SaleID { get; set; }
        [DataMember]
        public int UnitID { get; set; }
        [DataMember]
        public Nullable<int> SaleTypeID { get; set; }
        [DataMember]
        public int SaleStatusID { get; set; }
        [DataMember]
        public Nullable<int> SaleActiveStatusID { get; set; }
        [DataMember]
        public System.DateTime SaleAddedDt { get; set; }
        [DataMember]
        public System.DateTime SaleModifiedDt { get; set; }
        [DataMember]
        public int SaleAddedByUser { get; set; }
        [DataMember]
        public int SaleModifiedByUser { get; set; }
        [DataMember]
        public Nullable<System.DateTime> SaleReservationDt { get; set; }
        [DataMember]
        public Nullable<System.DateTime> SaleReservationExpiryDt { get; set; }
        [DataMember]
        public Nullable<System.DateTime> SaleReservationExtentionDt { get; set; }
        [DataMember]
        public Nullable<System.DateTime> SaleContractSignedPurchaserDt { get; set; }
        [DataMember]
        public Nullable<System.DateTime> SaleContractSignedSellerDt { get; set; }
        [DataMember]
        public bool SaleDepositPaidBt { get; set; }
        [DataMember]
        public bool SalesBondRequiredBt { get; set; }
        [DataMember]
        public double SaleBondRequiredAmount { get; set; }
        [DataMember]
        public Nullable<System.DateTime> SaleBondDueTimeDt { get; set; }
        [DataMember]
        public Nullable<System.DateTime> SaleBondDueExpiryDt { get; set; }
        [DataMember]
        public bool SalesReferalCommDueBt { get; set; }
        [DataMember]
        public Nullable<int> BondOriginatorID { get; set; }
        [DataMember]
        public Nullable<int> BankID { get; set; }
        [DataMember]
        public string SalesBondAccountNo { get; set; }
        [DataMember]
        public Nullable<double> SalesBondInterestRate { get; set; }
        [DataMember]
        public Nullable<double> SalesBondAmount { get; set; }
        [DataMember]
        public Nullable<double> SalesTotalDepositAmount { get; set; }
        [DataMember]
        public Nullable<System.DateTime> SalesBondGrantedDt { get; set; }
        [DataMember]
        public Nullable<System.DateTime> SalesBondClientAcceptDt { get; set; }
        [DataMember]
        public bool SalesBondCommDueBt { get; set; }
        [DataMember]
        public Nullable<int> SalesTransferAttAssignedID { get; set; }
        [DataMember]
        public Nullable<int> SalesBondAttAssignedID { get; set; }
        [DataMember]
        public Nullable<int> SalePrimAgentID { get; set; }
        [DataMember]
        public Nullable<int> IndividualID { get; set; }
        [DataMember]
        public Nullable<int> PurchaserID { get; set; }
        [DataMember]
        public Nullable<System.DateTime> SalesBondClientContactedDt { get; set; }
        [DataMember]
        public Nullable<System.DateTime> SalesBondBondDocsRecDt { get; set; }
        [DataMember]
        public Nullable<System.DateTime> SalesDepoistPaidDt { get; set; }
        [DataMember]
        public Nullable<int> SalesDepositProofID { get; set; }
        [DataMember]
        public Nullable<System.DateTime> SalesDepositProofDt { get; set; }
        [DataMember]
        public Nullable<System.DateTime> SalesBondRequiredDt { get; set; }
        [DataMember]
        public virtual ICollection<BondAtt> BondAtts { get; set; }
        [DataMember]
        public virtual Bank Bank { get; set; }
        [DataMember]
        public virtual ICollection<Comment> Comments { get; set; }
        [DataMember]
        public virtual Individual Individual { get; set; }
        [DataMember]
        public virtual Purchaser Purchaser { get; set; }
        [DataMember]
        public virtual ICollection<BondConditionTr> BondConditionTrs { get; set; }
        [DataMember]
        public virtual ICollection<CommissionTr> CommissionTrs { get; set; }
        [DataMember]
        public virtual ICollection<FinancialTr> FinancialTrs { get; set; }
        [DataMember]
        public virtual ICollection<OriginatorTr> OriginatorTrs { get; set; }
        [DataMember]
        public virtual SaleActiveStatus SaleActiveStatus { get; set; }
        [DataMember]
        public virtual SaleDepositProof SaleDepositProof { get; set; }
        [DataMember]
        public virtual SaleStatus SaleStatus { get; set; }
        [DataMember]
        public virtual SaleType SaleType { get; set; }
        [DataMember]
        public virtual Unit Unit { get; set; }
        [DataMember]
        public virtual ICollection<TransAtt> TransAtts { get; set; }
    }
    
}
