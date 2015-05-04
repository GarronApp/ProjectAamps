using Aamps.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AAMPS.Domain.ViewModels.Bonds
{
    public partial class BondsViewModel
    {
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
        public DateTime? SaleReservationDt { get; set; }
        [DataMember]
        public DateTime? ReservationTimeExtention { get; set; }
        [DataMember]
        public string CommentOnExtention { get; set; }
        [DataMember]
        public bool ReferralDue { get; set; }
        [DataMember]
        public string DepositPaid { get; set; }
        [DataMember]
        public string SalesDepoistPaidDt { get; set; }
        [DataMember]
        public string SaleContractSignedPurchaserDt { get; set; }
        [DataMember]
        public string SaleContractSignedSellerDt { get; set; }
        [DataMember]
        public float SellingPriceInclVAT { get; set; }
        [DataMember]
        public float CommissionDue { get; set; }
        [DataMember]
        public string DateSignedBySeller { get; set; }
        [DataMember]
        public string SalesBondGrantedDt { get; set; }
        [DataMember]
        public string SaleBondDueExpiryDt { get; set; }
        [DataMember]
        public string SalesBondRequiredBt { get; set; }
        [DataMember]
        public string SalesBondRequiredDt { get; set; }
        [DataMember]
        public string SalesBondBondDocsRecDt { get; set; }
        [DataMember]
        public string SalesBondClientContactedDt { get; set; }
        [DataMember]
        public int SalesBondClientContactedBt { get; set; }
        [DataMember]
        public int SalesBondBondDocsRecBt { get; set; }
        [DataMember]
        public string SalesBondAccountNo { get; set; }
        [DataMember]
        public double SaleBondRequiredAmount { get; set; }
        [DataMember]
        public IEnumerable<OrginatorViewModel> Orginators { get; set; }
        [DataMember]
        public string BankName { get; set; }
        [DataMember]
        public string MOStatus { get; set; }
        [DataMember]
        public string OriginatorTrSubmittedDt { get; set; }
        [DataMember]
        public string OriginatorTrAIPDt { get; set; }
        [DataMember]
        public string OriginatorTrGrantDt { get; set; }
        [DataMember]
        public int OriginatorTrAcceptedBt { get; set; }
        [DataMember]
        public string OriginatorTrAcceptDt { get; set; }
        [DataMember]
        public double OriginatorTrBondAmount { get; set; }
        [DataMember]
        public double OriginatorTrIntRate { get; set; }
        [DataMember]
        public string OriginatorTrAddedDt { get; set; }
        [DataMember]
        public string OriginatorTrModifiedDt { get; set; }
        [DataMember]
        public int DevelopmentID { get; set; }
        [DataMember]
        public string DevelopmentDescription { get; set; }
        [DataMember]
        public int EstateID { get; set; }
        [DataMember]
        public int UnitStatusId { get; set; }
        [DataMember]
        public int DevelopmentTypeID { get; set; }
        [DataMember]
        public bool DevelopmentInActive { get; set; }
        [DataMember]
        public int DevelopmentDevID { get; set; }
        [DataMember]
        public int DevelopmentTransAttID { get; set; }
        [DataMember]
        public int DevelopmentSalesCoID { get; set; }
        [DataMember]
        public virtual DevelopmentType DevelopmentType { get; set; }
        [DataMember]
        public virtual Estate Estate { get; set; }
        [DataMember]
        public virtual ICollection<Unit> Units { get; set; }
        [DataMember]
        public int UnitId { get; set; }
        [DataMember]
        public string UnitNumber { get; set; }
        [DataMember]
        public string UnitFloor { get; set; }
        [DataMember]
        public string UnitBlock { get; set; }
        [DataMember]
        public string UnitPhase { get; set; }
        [DataMember]
        public int UnitTypeID { get; set; }
        [DataMember]
        public double UnitSize { get; set; }
        [DataMember]
        public double UnitErfSize { get; set; }
        [DataMember]
        public double UnitPrice { get; set; }
        [DataMember]
        public double UnitPriceVat { get; set; }
        [DataMember]
        public double UnitPriceIncluding { get; set; }
        [DataMember]
        public string UnitStatusID { get; set; }
        [DataMember]
        public int AvailableStatusCount { get; set; }
        [DataMember]
        public int PendingStatusCount { get; set; }
        [DataMember]
        public int ReservedStatusCount { get; set; }
        [DataMember]
        public int SoldStatusCount { get; set; }
        [DataMember]
        public int TotalUnitsCount { get; set; }
        [DataMember]
        public Nullable<System.DateTime> UnitActiveDate { get; set; }
        
    }

}