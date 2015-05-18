using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Models.Mapping
{
    public class UnitStatusMap : EntityTypeConfiguration<UnitStatus>
    {
        public UnitStatusMap()
        {
            // Primary Key
            this.HasKey(t => t.UnitStatusID);

            // Properties
            this.Property(t => t.UnitStatusDescription)
                .IsRequired()
                .HasMaxLength(65);

            // Table & Column Mappings
            this.ToTable("UnitStatus", "Units");
            this.Property(t => t.UnitStatusID).HasColumnName("UnitStatusID");
            this.Property(t => t.UnitStatusDescription).HasColumnName("UnitStatusDescription");
        }
    }
}
