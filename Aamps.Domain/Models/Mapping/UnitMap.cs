using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Models.Mapping
{
    public class UnitMap : EntityTypeConfiguration<Unit>
    {
        public UnitMap()
        {
            // Primary Key
            this.HasKey(t => t.UnitID);

            // Properties
            this.Property(t => t.UnitNumber)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.UnitFloor)
                .HasMaxLength(10);

            this.Property(t => t.UnitBlock)
                .HasMaxLength(10);

            this.Property(t => t.UnitPhase)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Unit", "Units");
            this.Property(t => t.UnitID).HasColumnName("UnitID");
            this.Property(t => t.UnitNumber).HasColumnName("UnitNumber");
            this.Property(t => t.DevelopmentID).HasColumnName("DevelopmentID");
            this.Property(t => t.UnitFloor).HasColumnName("UnitFloor");
            this.Property(t => t.UnitBlock).HasColumnName("UnitBlock");
            this.Property(t => t.UnitTypeID).HasColumnName("UnitTypeID");
            this.Property(t => t.UnitSize).HasColumnName("UnitSize");
            this.Property(t => t.UnitErfSize).HasColumnName("UnitErfSize");
            this.Property(t => t.UnitPrice).HasColumnName("UnitPrice");
            this.Property(t => t.UnitPriceVat).HasColumnName("UnitPriceVat");
            this.Property(t => t.UnitPriceIncluding).HasColumnName("UnitPriceIncluding");
            this.Property(t => t.UnitStatusID).HasColumnName("UnitStatusID");
            this.Property(t => t.UnitActiveDate).HasColumnName("UnitActiveDate");
            this.Property(t => t.UnitDateAdded).HasColumnName("UnitDateAdded");
            this.Property(t => t.UnitDateModified).HasColumnName("UnitDateModified");
            this.Property(t => t.UnitAddedByUser).HasColumnName("UnitAddedByUser");
            this.Property(t => t.UnitModifiedByUser).HasColumnName("UnitModifiedByUser");
            this.Property(t => t.UnitAgentID).HasColumnName("UnitAgentID");
            this.Property(t => t.UnitPhase).HasColumnName("UnitPhase");

            // Relationships
            this.HasRequired(t => t.Development)
                .WithMany(t => t.Units)
                .HasForeignKey(d => d.DevelopmentID);
            this.HasRequired(t => t.UnitStatu)
                .WithMany(t => t.Units)
                .HasForeignKey(d => d.UnitStatusID);
            this.HasRequired(t => t.UnitType)
                .WithMany(t => t.Units)
                .HasForeignKey(d => d.UnitTypeID);

        }
    }
}
