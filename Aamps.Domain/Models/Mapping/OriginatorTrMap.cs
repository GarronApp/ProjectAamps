using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Models.Mapping
{
    public class OriginatorTrMap : EntityTypeConfiguration<OriginatorTr>
    {
        public OriginatorTrMap()
        {
            // Primary Key
            this.HasKey(t => t.OriginatorTrID);

            // Properties
            // Table & Column Mappings
            this.ToTable("OriginatorTr", "Transactions");
            this.Property(t => t.OriginatorTrID).HasColumnName("OriginatorTrID");
            this.Property(t => t.MOStatusID).HasColumnName("MOStatusID");
            this.Property(t => t.BankID).HasColumnName("BankID");
            this.Property(t => t.OriginatorTrSubmittedDt).HasColumnName("OriginatorTrSubmittedDt");
            this.Property(t => t.OriginatorTrAIPDt).HasColumnName("OriginatorTrAIPDt");
            this.Property(t => t.OriginatorTrGrantDt).HasColumnName("OriginatorTrGrantDt");
            this.Property(t => t.OriginatorTrAcceptedBt).HasColumnName("OriginatorTrAcceptedBt");
            this.Property(t => t.OriginatorTrAcceptDt).HasColumnName("OriginatorTrAcceptDt");
            this.Property(t => t.OriginatorTrBondAmount).HasColumnName("OriginatorTrBondAmount");
            this.Property(t => t.OriginatorTrIntRate).HasColumnName("OriginatorTrIntRate");
            this.Property(t => t.OriginatorTrAddedDt).HasColumnName("OriginatorTrAddedDt");
            this.Property(t => t.OriginatorTrModifiedDt).HasColumnName("OriginatorTrModifiedDt");
            this.Property(t => t.OriginatorTrAddedByUser).HasColumnName("OriginatorTrAddedByUser");
            this.Property(t => t.OriginatorTrModifiedByUser).HasColumnName("OriginatorTrModifiedByUser");
            this.Property(t => t.SaleID).HasColumnName("SaleID");

            // Relationships
            this.HasRequired(t => t.Bank)
                .WithMany(t => t.OriginatorTrs)
                .HasForeignKey(d => d.BankID);
            this.HasRequired(t => t.Sale)
                .WithMany(t => t.OriginatorTrs)
                .HasForeignKey(d => d.SaleID);
            this.HasRequired(t => t.MOStatu)
                .WithMany(t => t.OriginatorTrs)
                .HasForeignKey(d => d.MOStatusID);

        }
    }
}
