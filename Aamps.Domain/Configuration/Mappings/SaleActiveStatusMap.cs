using Aamps.Domain.Model.Sales;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Configuration.Mappings
{
    public class SaleActiveStatusMap : EntityTypeConfiguration<SaleActiveStatus>
    {
        public SaleActiveStatusMap()
        {
            // Primary Key
            this.HasKey(t => t.SaleActiveStatusID);

            // Properties
            this.Property(t => t.SaleActiveStatusDescription)
                .IsRequired()
                .HasMaxLength(65);

            // Table & Column Mappings
            this.ToTable("SaleActiveStatus", "Sales");
            this.Property(t => t.SaleActiveStatusID).HasColumnName("SaleActiveStatusID");
            this.Property(t => t.SaleActiveStatusDescription).HasColumnName("SaleActiveStatusDescription");
        }
    }
}
