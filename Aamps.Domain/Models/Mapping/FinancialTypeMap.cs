using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Models.Mapping
{
    public class FinancialTypeMap : EntityTypeConfiguration<FinancialType>
    {
        public FinancialTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.FinancialTypeID);

            // Properties
            this.Property(t => t.FinancialTypeDescription)
                .IsRequired()
                .HasMaxLength(65);

            // Table & Column Mappings
            this.ToTable("FinancialType", "Transactions");
            this.Property(t => t.FinancialTypeID).HasColumnName("FinancialTypeID");
            this.Property(t => t.FinancialTypeDescription).HasColumnName("FinancialTypeDescription");
        }
    }
}
