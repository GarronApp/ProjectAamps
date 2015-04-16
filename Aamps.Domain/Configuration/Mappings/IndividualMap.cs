using Aamps.Domain.Model.Master;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Configuration.Mappings
{
    public class IndividualMap : EntityTypeConfiguration<Individual>
    {
        public IndividualMap()
        {
            // Primary Key
            this.HasKey(t => t.IndividualID);

            // Properties
            this.Property(t => t.IndividualName)
                .HasMaxLength(65);

            this.Property(t => t.IndividualSurname)
                .HasMaxLength(65);

            this.Property(t => t.IndividualIDNumber)
                .HasMaxLength(12);

            this.Property(t => t.IndividualContactCell)
                .HasMaxLength(20);

            this.Property(t => t.IndividualContactHome)
                .HasMaxLength(20);

            this.Property(t => t.IndividualContactWork)
                .HasMaxLength(20);

            this.Property(t => t.IndividualEmail)
                .HasMaxLength(65);

            this.Property(t => t.IndividualCountryofOriginan)
                .HasMaxLength(65);

            // Table & Column Mappings
            this.ToTable("Individual", "Master");
            this.Property(t => t.IndividualID).HasColumnName("IndividualID");
            this.Property(t => t.IndividualName).HasColumnName("IndividualName");
            this.Property(t => t.IndividualSurname).HasColumnName("IndividualSurname");
            this.Property(t => t.IndividualIDNumber).HasColumnName("IndividualIDNumber");
            this.Property(t => t.IndividualContactCell).HasColumnName("IndividualContactCell");
            this.Property(t => t.IndividualContactHome).HasColumnName("IndividualContactHome");
            this.Property(t => t.IndividualContactWork).HasColumnName("IndividualContactWork");
            this.Property(t => t.IndividualEmail).HasColumnName("IndividualEmail");
            this.Property(t => t.PreferedContactMethodID).HasColumnName("PreferedContactMethodID");
            this.Property(t => t.IndividualCountryofOriginan).HasColumnName("IndividualCountryofOriginan");

            // Relationships
            this.HasRequired(t => t.PreferedContactMethod)
                .WithMany(t => t.Individuals)
                .HasForeignKey(d => d.PreferedContactMethodID);

        }
    }
}
