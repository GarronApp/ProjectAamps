using Aamps.Domain.Model.UserCompanies;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Configuration.Mappings
{
    public class CompanyMap : EntityTypeConfiguration<Company>
    {
        public CompanyMap()
        {
            // Primary Key
            this.HasKey(t => t.CompanyID);

            // Properties
            this.Property(t => t.CompanyDescription)
                .IsRequired()
                .HasMaxLength(65);

            // Table & Column Mappings
            this.ToTable("Company", "UserCompanies");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.CompanyDescription).HasColumnName("CompanyDescription");
            this.Property(t => t.UserGroupID).HasColumnName("UserGroupID");

            // Relationships
            this.HasRequired(t => t.UserGroup)
                .WithMany(t => t.Companies)
                .HasForeignKey(d => d.UserGroupID);

        }
    }
}
