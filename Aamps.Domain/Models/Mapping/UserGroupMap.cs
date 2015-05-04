using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Models.Mapping
{
    public class UserGroupMap : EntityTypeConfiguration<UserGroup>
    {
        public UserGroupMap()
        {
            // Primary Key
            this.HasKey(t => t.UserGroupID);

            // Properties
            this.Property(t => t.UserGroupDescription)
                .IsRequired()
                .HasMaxLength(65);

            // Table & Column Mappings
            this.ToTable("UserGroup", "UserCompanies");
            this.Property(t => t.UserGroupID).HasColumnName("UserGroupID");
            this.Property(t => t.UserGroupDescription).HasColumnName("UserGroupDescription");
        }
    }
}
