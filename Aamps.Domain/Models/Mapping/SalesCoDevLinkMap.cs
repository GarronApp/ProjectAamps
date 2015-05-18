using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Models.Mapping
{
    public class SalesCoDevLinkMap : EntityTypeConfiguration<SalesCoDevLink>
    {
        public SalesCoDevLinkMap()
        {
            // Primary Key
            this.HasKey(t => t.SalesCoDevLinkID);

            // Properties
            // Table & Column Mappings
            this.ToTable("SalesCoDevLink", "Master");
            this.Property(t => t.SalesCoDevLinkID).HasColumnName("SalesCoDevLinkID");
            this.Property(t => t.DevelopmentID).HasColumnName("DevelopmentID");
            this.Property(t => t.SalesCoID).HasColumnName("SalesCoID");
            this.Property(t => t.SalesCoDevLinkDefault).HasColumnName("SalesCoDevLinkDefault");

            // Relationships
            this.HasOptional(t => t.Development)
                .WithMany(t => t.SalesCoDevLinks)
                .HasForeignKey(d => d.DevelopmentID);

        }
    }
}
