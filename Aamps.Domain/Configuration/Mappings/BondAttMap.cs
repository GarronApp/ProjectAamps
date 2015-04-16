using Aamps.Domain.Model.BondAttornies;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Configuration.Mappings
{
    public class BondAttMap : EntityTypeConfiguration<BondAtt>
    {
        public BondAttMap()
        {
            // Primary Key
            this.HasKey(t => t.BondAttID);

            // Properties
            // Table & Column Mappings
            this.ToTable("BondAtt", "BondAttornies");
            this.Property(t => t.BondAttID).HasColumnName("BondAttID");
            this.Property(t => t.BondAttInstRecDt).HasColumnName("BondAttInstRecDt");
            this.Property(t => t.BondAttBankRecDt).HasColumnName("BondAttBankRecDt");
            this.Property(t => t.BondAttConditionsBt).HasColumnName("BondAttConditionsBt");
            this.Property(t => t.BondAttClientSignedDt).HasColumnName("BondAttClientSignedDt");
            this.Property(t => t.BondAttCostPaidBt).HasColumnName("BondAttCostPaidBt");
            this.Property(t => t.BondAttCostPaidDt).HasColumnName("BondAttCostPaidDt");
            this.Property(t => t.SaleID).HasColumnName("SaleID");
            this.Property(t => t.BondAttAddedDt).HasColumnName("BondAttAddedDt");
            this.Property(t => t.BondAttModifiedDt).HasColumnName("BondAttModifiedDt");
            this.Property(t => t.BondAttAddedByUser).HasColumnName("BondAttAddedByUser");
            this.Property(t => t.BondAttModifiedByUser).HasColumnName("BondAttModifiedByUser");

            // Relationships
            this.HasRequired(t => t.UserList)
                .WithMany(t => t.BondAtts)
                .HasForeignKey(d => d.BondAttAddedByUser);
            this.HasRequired(t => t.UserList)
                .WithMany(t => t.BondAtts)
                .HasForeignKey(d => d.BondAttModifiedByUser);
            this.HasRequired(t => t.Sale)
                .WithMany(t => t.BondAtts)
                .HasForeignKey(d => d.SaleID);

        }
    }
}
