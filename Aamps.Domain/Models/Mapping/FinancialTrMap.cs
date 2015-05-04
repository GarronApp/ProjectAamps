using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Models.Mapping
{
    public class FinancialTrMap : EntityTypeConfiguration<FinancialTr>
    {
        public FinancialTrMap()
        {
            // Primary Key
            this.HasKey(t => t.FinancialTrID);

            // Properties
            this.Property(t => t.FinancialTrComment)
                .HasMaxLength(65);

            // Table & Column Mappings
            this.ToTable("FinancialTr", "Transactions");
            this.Property(t => t.FinancialTrID).HasColumnName("FinancialTrID");
            this.Property(t => t.FinancialTypeID).HasColumnName("FinancialTypeID");
            this.Property(t => t.FinancialTrAmount).HasColumnName("FinancialTrAmount");
            this.Property(t => t.FinancialTrDueDt).HasColumnName("FinancialTrDueDt");
            this.Property(t => t.FinancialTrEffectiveDt).HasColumnName("FinancialTrEffectiveDt");
            this.Property(t => t.FinancialTrComment).HasColumnName("FinancialTrComment");
            this.Property(t => t.FinancialTrAddedDt).HasColumnName("FinancialTrAddedDt");
            this.Property(t => t.FinancialTrModifiedDt).HasColumnName("FinancialTrModifiedDt");
            this.Property(t => t.FinancialTrAddedByUser).HasColumnName("FinancialTrAddedByUser");
            this.Property(t => t.FinancialTrModifiedByUser).HasColumnName("FinancialTrModifiedByUser");
            this.Property(t => t.SaleID).HasColumnName("SaleID");
            this.Property(t => t.TransAttID).HasColumnName("TransAttID");

            // Relationships
            this.HasRequired(t => t.Sale)
                .WithMany(t => t.FinancialTrs)
                .HasForeignKey(d => d.SaleID);
            this.HasRequired(t => t.FinancialType)
                .WithMany(t => t.FinancialTrs)
                .HasForeignKey(d => d.FinancialTypeID);
            this.HasRequired(t => t.TransAtt)
                .WithMany(t => t.FinancialTrs)
                .HasForeignKey(d => d.TransAttID);

        }
    }
}
