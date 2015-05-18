using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Models.Mapping
{
    public class TransAttMap : EntityTypeConfiguration<TransAtt>
    {
        public TransAttMap()
        {
            // Primary Key
            this.HasKey(t => t.TransAttID);

            // Properties
            // Table & Column Mappings
            this.ToTable("TransAtt", "TransferAttornies");
            this.Property(t => t.TransAttID).HasColumnName("TransAttID");
            this.Property(t => t.TransAttInstRecDt).HasColumnName("TransAttInstRecDt");
            this.Property(t => t.TransAttDocsDraftedDt).HasColumnName("TransAttDocsDraftedDt");
            this.Property(t => t.TransAttSellerSignedDt).HasColumnName("TransAttSellerSignedDt");
            this.Property(t => t.TransAttPurchaserSignedDt).HasColumnName("TransAttPurchaserSignedDt");
            this.Property(t => t.TransAttCostsPaidBt).HasColumnName("TransAttCostsPaidBt");
            this.Property(t => t.TransAttCostsPaidDt).HasColumnName("TransAttCostsPaidDt");
            this.Property(t => t.TransAttTDRecDt).HasColumnName("TransAttTDRecDt");
            this.Property(t => t.TransAttRatesClearanceRecDt).HasColumnName("TransAttRatesClearanceRecDt");
            this.Property(t => t.TransAttLodgedDt).HasColumnName("TransAttLodgedDt");
            this.Property(t => t.TransAttRegisteredDt).HasColumnName("TransAttRegisteredDt");
            this.Property(t => t.TransAttAgencyCommPaidDt).HasColumnName("TransAttAgencyCommPaidDt");
            this.Property(t => t.TransAttReferalCommPaidDt).HasColumnName("TransAttReferalCommPaidDt");
            this.Property(t => t.TransAttAAMPSCommPaidDt).HasColumnName("TransAttAAMPSCommPaidDt");
            this.Property(t => t.SaleID).HasColumnName("SaleID");
            this.Property(t => t.TransAttAddedDt).HasColumnName("TransAttAddedDt");
            this.Property(t => t.TransAttModifiedDt).HasColumnName("TransAttModifiedDt");
            this.Property(t => t.TransAttAddedByUser).HasColumnName("TransAttAddedByUser");
            this.Property(t => t.TransAttModifiedByUser).HasColumnName("TransAttModifiedByUser");

            // Relationships
            this.HasRequired(t => t.Sale)
                .WithMany(t => t.TransAtts)
                .HasForeignKey(d => d.SaleID);

        }
    }
}
