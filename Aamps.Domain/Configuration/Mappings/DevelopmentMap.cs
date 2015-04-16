using Aamps.Domain.Model.Master;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Configuration.Mappings
{
    public class DevelopmentMap : EntityTypeConfiguration<Development>
    {
        public DevelopmentMap()
        {
            // Primary Key
            this.HasKey(t => t.DevelopmentID);

            // Properties
            this.Property(t => t.DevelopmentDescription)
                .IsRequired()
                .HasMaxLength(65);

            // Table & Column Mappings
            this.ToTable("Development", "Master");
            this.Property(t => t.DevelopmentID).HasColumnName("DevelopmentID");
            this.Property(t => t.DevelopmentDescription).HasColumnName("DevelopmentDescription");
            this.Property(t => t.EstateID).HasColumnName("EstateID");
            this.Property(t => t.DevelopmentTypeID).HasColumnName("DevelopmentTypeID");
            this.Property(t => t.DevelopmentInActive).HasColumnName("DevelopmentInActive");

            // Relationships
            this.HasRequired(t => t.DevelopmentType)
                .WithMany(t => t.Developments)
                .HasForeignKey(d => d.DevelopmentTypeID);
            this.HasRequired(t => t.Estate)
                .WithMany(t => t.Developments)
                .HasForeignKey(d => d.EstateID);

        }
    }
}
