using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Models.Mapping
{
    public class UserRightMap : EntityTypeConfiguration<UserRight>
    {
        public UserRightMap()
        {
            // Primary Key
            this.HasKey(t => t.UserRightID);

            // Properties
            // Table & Column Mappings
            this.ToTable("UserRight", "UserCompanies");
            this.Property(t => t.UserRightID).HasColumnName("UserRightID");
            this.Property(t => t.UserListID).HasColumnName("UserListID");
            this.Property(t => t.FormReportID).HasColumnName("FormReportID");
            this.Property(t => t.UserRightFull).HasColumnName("UserRightFull");
            this.Property(t => t.UserRightView).HasColumnName("UserRightView");
            this.Property(t => t.UserRightEdit).HasColumnName("UserRightEdit");
            this.Property(t => t.UserRightAdd).HasColumnName("UserRightAdd");
            this.Property(t => t.UserRightDelete).HasColumnName("UserRightDelete");
            this.Property(t => t.UserRightDateAdded).HasColumnName("UserRightDateAdded");
            this.Property(t => t.UserRightDateModified).HasColumnName("UserRightDateModified");

            // Relationships
            this.HasRequired(t => t.FormReport)
                .WithMany(t => t.UserRights)
                .HasForeignKey(d => d.FormReportID);
            this.HasRequired(t => t.UserList)
                .WithMany(t => t.UserRights)
                .HasForeignKey(d => d.UserListID);

        }
    }
}
