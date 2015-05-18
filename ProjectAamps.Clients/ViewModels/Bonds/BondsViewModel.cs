using AAMPS.Clients.AampService;
using AAMPS.Clients.ViewModels.Originator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAMPS.Clients.ViewModels.Bonds
{
    public class BondsViewModel
    {
        public string IndividualFirstName { get; set; }
        public string IndividualLastName { get; set; }
        public string IndividualCellNo { get; set; }
        public string IndividualWorkNo { get; set; }
        public int IndividualContactMethod { get; set; }
        public string IndividualEmailAddress { get; set; }

        public DateTime? SaleReservationDt { get; set; }
        public DateTime? ReservationTimeExtention { get; set; }
        public string CommentOnExtention { get; set; }
        public bool ReferralDue { get; set; }
        public string DepositPaid { get; set; }
        public string SalesDepoistPaidDt { get; set; }
        public string SaleContractSignedPurchaserDt { get; set; }
        public string SaleContractSignedSellerDt { get; set; }
        public float SellingPriceInclVAT { get; set; }
        public float CommissionDue { get; set; }
        public string DateSignedBySeller { get; set; }
        public string SalesBondGrantedDt { get; set; }
        public string SaleBondDueExpiryDt { get; set; }
        public string SalesBondRequiredBt { get; set; }
        public string SalesBondRequiredDt { get; set; }
        public string SalesBondBondDocsRecDt { get; set; }
        public string SalesBondClientContactedDt { get; set; }
        public int SalesBondClientContactedBt { get; set; }
        public int SalesBondBondDocsRecBt { get; set; }
        public string SalesBondAccountNo { get; set; }
        public double SaleBondRequiredAmount { get; set; }
        public double SalesTotalDepositAmount { get; set; }
        public IEnumerable<OrginatorViewModel> Orginators { get; set; }
        public string BankName { get; set; }
        public string MOStatus { get; set; }
        public string OriginatorTrSubmittedDt { get; set; }
        public string OriginatorTrAIPDt { get; set; }
        public string OriginatorTrGrantDt { get; set; }
        public int OriginatorTrAcceptedBt { get; set; }
        public string OriginatorTrAcceptDt { get; set; }
        public double OriginatorTrBondAmount { get; set; }
        public double OriginatorTrIntRate { get; set; }
        public string OriginatorTrAddedDt { get; set; }
        public string OriginatorTrModifiedDt { get; set; }

        public int DevelopmentID { get; set; }
        public string DevelopmentDescription { get; set; }
        public int EstateID { get; set; }
        public int UnitStatusId { get; set; }
        public int DevelopmentTypeID { get; set; }
        public bool DevelopmentInActive { get; set; }
        public int DevelopmentDevID { get; set; }
        public int DevelopmentTransAttID { get; set; }
        public int DevelopmentSalesCoID { get; set; }
        public virtual DevelopmentType DevelopmentType { get; set; }
        public virtual Estate Estate { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
        public int UnitId { get; set; }
        public string UnitNumber { get; set; }
        public string UnitFloor { get; set; }
        public string UnitBlock { get; set; }
        public string UnitPhase { get; set; }
        public int UnitTypeID { get; set; }
        public double UnitSize { get; set; }
        public double UnitErfSize { get; set; }
        public double UnitPrice { get; set; }
        public double UnitPriceVat { get; set; }
        public double UnitPriceIncluding { get; set; }
        public string UnitStatusID { get; set; }
        public int AvailableStatusCount { get; set; }
        public int PendingStatusCount { get; set; }
        public int ReservedStatusCount { get; set; }
        public int SoldStatusCount { get; set; }
        public int TotalUnitsCount { get; set; }
        public Nullable<System.DateTime> UnitActiveDate { get; set; }
    }
}
