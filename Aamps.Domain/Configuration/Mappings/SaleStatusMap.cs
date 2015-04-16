using Aamps.Domain.Model.Sales;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Configuration.Mappings
{
    public class SaleStatusMap : EntityTypeConfiguration<SaleStatus>
    {
        public SaleStatusMap()
        {
            // Primary Key
            this.HasKey(t => t.SaleStatusID);

            // Properties
            this.Property(t => t.SaleStatusDescription)
                .IsRequired()
                .HasMaxLength(65);

            // Table & Column Mappings
            this.ToTable("SaleStatus", "Sales");
            this.Property(t => t.SaleStatusID).HasColumnName("SaleStatusID");
            this.Property(t => t.SaleStatusDescription).HasColumnName("SaleStatusDescription");
        }
    }
}
