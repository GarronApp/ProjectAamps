using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Models.Mapping
{
    public class MOStatusMap : EntityTypeConfiguration<MOStatus>
    {
        public MOStatusMap()
        {
            // Primary Key
            this.HasKey(t => t.MOStatusID);

            // Properties
            this.Property(t => t.MOStatusDescription)
                .IsRequired()
                .HasMaxLength(65);

            // Table & Column Mappings
            this.ToTable("MOStatus", "Transactions");
            this.Property(t => t.MOStatusID).HasColumnName("MOStatusID");
            this.Property(t => t.MOStatusDescription).HasColumnName("MOStatusDescription");
        }
    }
}
