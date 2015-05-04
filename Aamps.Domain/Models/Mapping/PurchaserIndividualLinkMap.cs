using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Models.Mapping
{
    public class PurchaserIndividualLinkMap : EntityTypeConfiguration<PurchaserIndividualLink>
    {
        public PurchaserIndividualLinkMap()
        {
            // Primary Key
            this.HasKey(t => t.PurchaserIndividualLinkID);

            // Properties
            // Table & Column Mappings
            this.ToTable("PurchaserIndividualLink", "Master");
            this.Property(t => t.PurchaserIndividualLinkID).HasColumnName("PurchaserIndividualLinkID");
            this.Property(t => t.PurchaserID).HasColumnName("PurchaserID");
            this.Property(t => t.IndividualID).HasColumnName("IndividualID");
            this.Property(t => t.PurchaserIndividualLinkMainContact).HasColumnName("PurchaserIndividualLinkMainContact");

            // Relationships
            this.HasOptional(t => t.Individual)
                .WithMany(t => t.PurchaserIndividualLinks)
                .HasForeignKey(d => d.IndividualID);
            this.HasOptional(t => t.Purchaser)
                .WithMany(t => t.PurchaserIndividualLinks)
                .HasForeignKey(d => d.PurchaserID);

        }
    }
}
