using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Models.Mapping
{
    public class EstateMap : EntityTypeConfiguration<Estate>
    {
        public EstateMap()
        {
            // Primary Key
            this.HasKey(t => t.EstateID);

            // Properties
            this.Property(t => t.EstateDescription)
                .IsRequired()
                .HasMaxLength(65);

            // Table & Column Mappings
            this.ToTable("Estate", "Master");
            this.Property(t => t.EstateID).HasColumnName("EstateID");
            this.Property(t => t.EstateDescription).HasColumnName("EstateDescription");
        }
    }
}
