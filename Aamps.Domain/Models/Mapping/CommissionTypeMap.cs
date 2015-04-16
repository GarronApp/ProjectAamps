using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Models.Mapping
{
    public class CommissionTypeMap : EntityTypeConfiguration<CommissionType>
    {
        public CommissionTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.CommissionTypeID);

            // Properties
            this.Property(t => t.CommissionTypeDescription)
                .IsRequired()
                .HasMaxLength(65);

            // Table & Column Mappings
            this.ToTable("CommissionType", "Transactions");
            this.Property(t => t.CommissionTypeID).HasColumnName("CommissionTypeID");
            this.Property(t => t.CommissionTypeDescription).HasColumnName("CommissionTypeDescription");
        }
    }
}
