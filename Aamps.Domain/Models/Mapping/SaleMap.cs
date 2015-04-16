using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Models.Mapping
{
    public class SaleMap : EntityTypeConfiguration<Sale>
    {
        public SaleMap()
        {
            // Primary Key
            this.HasKey(t => t.SaleID);

            // Properties
            this.Property(t => t.SalesBondAccountNo)
                .HasMaxLength(65);

            // Table & Column Mappings
            this.ToTable("Sale", "Sales");
            this.Property(t => t.SaleID).HasColumnName("SaleID");
            this.Property(t => t.UnitID).HasColumnName("UnitID");
            this.Property(t => t.SaleTypeID).HasColumnName("SaleTypeID");
            this.Property(t => t.SaleStatusID).HasColumnName("SaleStatusID");
            this.Property(t => t.SaleActiveStatusID).HasColumnName("SaleActiveStatusID");
            this.Property(t => t.SaleAddedDt).HasColumnName("SaleAddedDt");
            this.Property(t => t.SaleModifiedDt).HasColumnName("SaleModifiedDt");
            this.Property(t => t.SaleAddedByUser).HasColumnName("SaleAddedByUser");
            this.Property(t => t.SaleModifiedByUser).HasColumnName("SaleModifiedByUser");
            this.Property(t => t.SaleReservationDt).HasColumnName("SaleReservationDt");
            this.Property(t => t.SaleReservationExpiryDt).HasColumnName("SaleReservationExpiryDt");
            this.Property(t => t.SaleReservationExtentionDt).HasColumnName("SaleReservationExtentionDt");
            this.Property(t => t.SaleContractSignedPurchaserDt).HasColumnName("SaleContractSignedPurchaserDt");
            this.Property(t => t.SaleContractSignedSellerDt).HasColumnName("SaleContractSignedSellerDt");
            this.Property(t => t.SaleDepositPaidBt).HasColumnName("SaleDepositPaidBt");
            this.Property(t => t.SalesBondRequiredBt).HasColumnName("SalesBondRequiredBt");
            this.Property(t => t.SaleBondRequiredAmount).HasColumnName("SaleBondRequiredAmount");
            this.Property(t => t.SaleBondDueTimeDt).HasColumnName("SaleBondDueTimeDt");
            this.Property(t => t.SaleBondDueExpiryDt).HasColumnName("SaleBondDueExpiryDt");
            this.Property(t => t.SalesReferalCommDueBt).HasColumnName("SalesReferalCommDueBt");
            this.Property(t => t.BondOriginatorID).HasColumnName("BondOriginatorID");
            this.Property(t => t.BankID).HasColumnName("BankID");
            this.Property(t => t.SalesBondAccountNo).HasColumnName("SalesBondAccountNo");
            this.Property(t => t.SalesBondInterestRate).HasColumnName("SalesBondInterestRate");
            this.Property(t => t.SalesBondAmount).HasColumnName("SalesBondAmount");
            this.Property(t => t.SalesBondGrantedDt).HasColumnName("SalesBondGrantedDt");
            this.Property(t => t.SalesBondClientAcceptDt).HasColumnName("SalesBondClientAcceptDt");
            this.Property(t => t.SalesBondCommDueBt).HasColumnName("SalesBondCommDueBt");
            this.Property(t => t.SalesTransferAttAssignedID).HasColumnName("SalesTransferAttAssignedID");
            this.Property(t => t.SalesBondAttAssignedID).HasColumnName("SalesBondAttAssignedID");
            this.Property(t => t.SalePrimAgentID).HasColumnName("SalePrimAgentID");
            this.Property(t => t.IndividualID).HasColumnName("IndividualID");
            this.Property(t => t.PurchaserID).HasColumnName("PurchaserID");
            this.Property(t => t.SalesBondClientContactedDt).HasColumnName("SalesBondClientContactedDt");
            this.Property(t => t.SalesBondBondDocsRecDt).HasColumnName("SalesBondBondDocsRecDt");
            this.Property(t => t.SalesDepoistPaidDt).HasColumnName("SalesDepoistPaidDt");
            this.Property(t => t.SalesDepositProofID).HasColumnName("SalesDepositProofID");
            this.Property(t => t.SalesDepositProofDt).HasColumnName("SalesDepositProofDt");
            this.Property(t => t.SalesBondRequiredDt).HasColumnName("SalesBondRequiredDt");

            // Relationships
            this.HasOptional(t => t.Bank)
                .WithMany(t => t.Sales)
                .HasForeignKey(d => d.BankID);
            //this.HasOptional(t => t.Individual)
            //    .WithMany(t => t.Sales)
            //    .HasForeignKey(d => d.IndividualID);
            this.HasOptional(t => t.Purchaser)
                .WithMany(t => t.Sales)
                .HasForeignKey(d => d.PurchaserID);
            this.HasOptional(t => t.SaleActiveStatus)
                .WithMany(t => t.Sales)
                .HasForeignKey(d => d.SaleActiveStatusID);
            this.HasOptional(t => t.SaleDepositProof)
                .WithMany(t => t.Sales)
                .HasForeignKey(d => d.SalesDepositProofID);
            this.HasRequired(t => t.SaleStatus)
                .WithMany(t => t.Sales)
                .HasForeignKey(d => d.SaleStatusID);
            this.HasOptional(t => t.SaleType)
                .WithMany(t => t.Sales)
                .HasForeignKey(d => d.SaleTypeID);
            //this.HasRequired(t => t.Unit)
            //    .WithMany(t => t.Sales)
            //    .HasForeignKey(d => d.UnitID);

        }
    }
}
