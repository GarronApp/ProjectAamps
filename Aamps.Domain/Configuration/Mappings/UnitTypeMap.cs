using Aamps.Domain.Model.Units;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Configuration.Mappings
{
    public class UnitTypeMap : EntityTypeConfiguration<UnitType>
    {
        public UnitTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.UnitTypeID);

            // Properties
            this.Property(t => t.UnitTypeDescription)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("UnitType", "Units");
            this.Property(t => t.UnitTypeID).HasColumnName("UnitTypeID");
            this.Property(t => t.UnitTypeDescription).HasColumnName("UnitTypeDescription");
        }
    }
}
