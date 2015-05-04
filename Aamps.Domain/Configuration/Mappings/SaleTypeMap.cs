using Aamps.Domain.Model.Sales;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Configuration.Mappings
{
    public class SaleTypeMap : EntityTypeConfiguration<SaleType>
    {
        public SaleTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.SaleTypeID);

            // Properties
            this.Property(t => t.SaleTypeDescription)
                .IsRequired()
                .HasMaxLength(65);

            // Table & Column Mappings
            this.ToTable("SaleType", "Sales");
            this.Property(t => t.SaleTypeID).HasColumnName("SaleTypeID");
            this.Property(t => t.SaleTypeDescription).HasColumnName("SaleTypeDescription");
        }
    }
}
