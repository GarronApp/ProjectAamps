using Aamps.Domain.Model.Master;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Configuration.Mappings
{
    public class DevelopmentTypeMap : EntityTypeConfiguration<DevelopmentType>
    {
        public DevelopmentTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.DevelopmentTypeID);

            // Properties
            this.Property(t => t.DevelopmentTypeDescription)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("DevelopmentType", "Master");
            this.Property(t => t.DevelopmentTypeID).HasColumnName("DevelopmentTypeID");
            this.Property(t => t.DevelopmentTypeDescription).HasColumnName("DevelopmentTypeDescription");
        }
    }
}
