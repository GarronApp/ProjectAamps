using Aamps.Domain.Model.UserCompanies;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Configuration.Mappings
{
    public class UserTypeMap : EntityTypeConfiguration<UserType>
    {
        public UserTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.UserTypeID);

            // Properties
            this.Property(t => t.UserTypeDescription)
                .IsRequired()
                .HasMaxLength(65);

            // Table & Column Mappings
            this.ToTable("UserType", "UserCompanies");
            this.Property(t => t.UserTypeID).HasColumnName("UserTypeID");
            this.Property(t => t.UserTypeDescription).HasColumnName("UserTypeDescription");
        }
    }
}
