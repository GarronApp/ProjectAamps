using Aamps.Domain.Model.Transactions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Configuration.Mappings
{
    public class CommissionTrMap : EntityTypeConfiguration<CommissionTransaction>
    {
        public CommissionTrMap()
        {
            // Primary Key
            this.HasKey(t => t.CommissionTrID);

            // Properties
            // Table & Column Mappings
            this.ToTable("CommissionTr", "Transactions");
            this.Property(t => t.CommissionTrID).HasColumnName("CommissionTrID");
            this.Property(t => t.CommissionTypeID).HasColumnName("CommissionTypeID");
            this.Property(t => t.UserListID).HasColumnName("UserListID");
            this.Property(t => t.CommissionTrBondAmount).HasColumnName("CommissionTrBondAmount");
            this.Property(t => t.CommissionTrRate).HasColumnName("CommissionTrRate");
            this.Property(t => t.CommissionTrAddedDt).HasColumnName("CommissionTrAddedDt");
            this.Property(t => t.CommissionTrModifiedDt).HasColumnName("CommissionTrModifiedDt");
            this.Property(t => t.CommissionTrAddedByUser).HasColumnName("CommissionTrAddedByUser");
            this.Property(t => t.CommissionTrModifiedByUser).HasColumnName("CommissionTrModifiedByUser");
            this.Property(t => t.SaleID).HasColumnName("SaleID");

            // Relationships
            this.HasRequired(t => t.Sale)
                .WithMany(t => t.CommissionTransactions)
                .HasForeignKey(d => d.SaleID);
            this.HasRequired(t => t.CommissionType)
                .WithMany(t => t.CommissionTransactions)
                .HasForeignKey(d => d.CommissionTypeID);
            this.HasRequired(t => t.UserList)
                .WithMany(t => t.CommissionTransactionans)
                .HasForeignKey(d => d.CommissionTrAddedByUser);
            this.HasRequired(t => t.UserList)
                .WithMany(t => t.CommissionTransactionans)
                .HasForeignKey(d => d.CommissionTrModifiedByUser);
            this.HasRequired(t => t.UserList)
                .WithMany(t => t.CommissionTransactionans)
                .HasForeignKey(d => d.UserListID);

        }
    }
}
