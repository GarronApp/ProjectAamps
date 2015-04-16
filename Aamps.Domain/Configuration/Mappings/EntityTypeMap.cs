using Aamps.Domain.Model.Master;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Configuration.Mappings
{
    public class EntityTypeMap : EntityTypeConfiguration<EntityType>
    {
        public EntityTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.EntityTypeID);

            // Properties
            this.Property(t => t.EntityTypeDescription)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("EntityType", "Master");
            this.Property(t => t.EntityTypeID).HasColumnName("EntityTypeID");
            this.Property(t => t.EntityTypeDescription).HasColumnName("EntityTypeDescription");
        }
    }
}
