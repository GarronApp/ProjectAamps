using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Models.Mapping
{
    public class PurchaserMap : EntityTypeConfiguration<Purchaser>
    {
        public PurchaserMap()
        {
            // Primary Key
            this.HasKey(t => t.PurchaserID);

            // Properties
            this.Property(t => t.PurchaserDescription)
                .IsRequired()
                .HasMaxLength(65);

            this.Property(t => t.PurchaserRegID)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.PurchaserContactPerson)
                .IsRequired()
                .HasMaxLength(65);

            this.Property(t => t.PurchaserContactCell)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.PurchaserContactHome)
                .HasMaxLength(20);

            this.Property(t => t.PurchaserContactWork)
                .HasMaxLength(20);

            this.Property(t => t.PurchaserEmail)
                .IsRequired()
                .HasMaxLength(65);

            this.Property(t => t.PurchaserAddress)
                .HasMaxLength(65);

            this.Property(t => t.PurchaserAddress1)
                .HasMaxLength(65);

            this.Property(t => t.PurchaserAddress2)
                .HasMaxLength(65);

            this.Property(t => t.PurchaserAddress3)
                .HasMaxLength(65);

            this.Property(t => t.PurchaserPostalCode)
                .HasMaxLength(5);

            this.Property(t => t.PurchaserSuburb)
                .HasMaxLength(65);

            // Table & Column Mappings
            this.ToTable("Purchaser", "Master");
            this.Property(t => t.PurchaserID).HasColumnName("PurchaserID");
            this.Property(t => t.EntityTypeID).HasColumnName("EntityTypeID");
            this.Property(t => t.PurchaserDescription).HasColumnName("PurchaserDescription");
            this.Property(t => t.PurchaserRegID).HasColumnName("PurchaserRegID");
            this.Property(t => t.PurchaserContactPerson).HasColumnName("PurchaserContactPerson");
            this.Property(t => t.PurchaserContactCell).HasColumnName("PurchaserContactCell");
            this.Property(t => t.PurchaserContactHome).HasColumnName("PurchaserContactHome");
            this.Property(t => t.PurchaserContactWork).HasColumnName("PurchaserContactWork");
            this.Property(t => t.PurchaserEmail).HasColumnName("PurchaserEmail");
            this.Property(t => t.PurchaserAddress).HasColumnName("PurchaserAddress");
            this.Property(t => t.PurchaserAddress1).HasColumnName("PurchaserAddress1");
            this.Property(t => t.PurchaserAddress2).HasColumnName("PurchaserAddress2");
            this.Property(t => t.PurchaserAddress3).HasColumnName("PurchaserAddress3");
            this.Property(t => t.PurchaserPostalCode).HasColumnName("PurchaserPostalCode");
            this.Property(t => t.PurchaserSuburb).HasColumnName("PurchaserSuburb");

            // Relationships
            this.HasRequired(t => t.EntityType)
                .WithMany(t => t.Purchasers)
                .HasForeignKey(d => d.EntityTypeID);

        }
    }
}
