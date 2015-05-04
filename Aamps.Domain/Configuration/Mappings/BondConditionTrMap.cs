using Aamps.Domain.Model.Transactions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Configuration.Mappings
{
    public class BondConditionTrMap : EntityTypeConfiguration<BondConditionTransaction>
    {
        public BondConditionTrMap()
        {
            // Primary Key
            this.HasKey(t => t.BondConditionTrID);

            // Properties
            // Table & Column Mappings
            this.ToTable("BondConditionTr", "Transactions");
            this.Property(t => t.BondConditionTrID).HasColumnName("BondConditionTrID");
            this.Property(t => t.BondConditionDescription).HasColumnName("BondConditionDescription");
            this.Property(t => t.BondConditionTrAddedDt).HasColumnName("BondConditionTrAddedDt");
            this.Property(t => t.BondConditionTrModifiedDt).HasColumnName("BondConditionTrModifiedDt");
            this.Property(t => t.BondConditionTrAddedByUser).HasColumnName("BondConditionTrAddedByUser");
            this.Property(t => t.BondConditionTrModifiedByUser).HasColumnName("BondConditionTrModifiedByUser");
            this.Property(t => t.SaleID).HasColumnName("SaleID");
            this.Property(t => t.BondAttID).HasColumnName("BondAttID");

            // Relationships
            this.HasRequired(t => t.BondAtt)
                .WithMany(t => t.BondConditionTransactions)
                .HasForeignKey(d => d.BondAttID);
            this.HasRequired(t => t.Sale)
                .WithMany(t => t.BondConditionTransactions)
                .HasForeignKey(d => d.SaleID);
            this.HasRequired(t => t.UserList)
                .WithMany(t => t.BondConditionTransactions)
                .HasForeignKey(d => d.BondConditionTrAddedByUser);
            this.HasRequired(t => t.UserList)
                .WithMany(t => t.BondConditionTransactions)
                .HasForeignKey(d => d.BondConditionTrModifiedByUser);

        }
    }
}
