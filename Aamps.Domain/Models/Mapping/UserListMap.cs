using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Models.Mapping
{
    public class UserListMap : EntityTypeConfiguration<UserList>
    {
        public UserListMap()
        {
            // Primary Key
            this.HasKey(t => t.UserListID);

            // Properties
            this.Property(t => t.UserListName)
                .IsRequired()
                .HasMaxLength(65);

            this.Property(t => t.UserListSurname)
                .IsRequired()
                .HasMaxLength(65);

            this.Property(t => t.UserListPassword)
                .IsRequired()
                .HasMaxLength(12);

            this.Property(t => t.UserListEmail)
                .HasMaxLength(65);

            // Table & Column Mappings
            this.ToTable("UserList", "UserCompanies");
            this.Property(t => t.UserListID).HasColumnName("UserListID");
            this.Property(t => t.UserListName).HasColumnName("UserListName");
            this.Property(t => t.UserListSurname).HasColumnName("UserListSurname");
            this.Property(t => t.UserListPassword).HasColumnName("UserListPassword");
            this.Property(t => t.UserListEmail).HasColumnName("UserListEmail");
            this.Property(t => t.UserTypeID).HasColumnName("UserTypeID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.UserGroupID).HasColumnName("UserGroupID");
            this.Property(t => t.UserListAddedby).HasColumnName("UserListAddedby");
            this.Property(t => t.UserListLastModifiedby).HasColumnName("UserListLastModifiedby");
            this.Property(t => t.UserListDateAdded).HasColumnName("UserListDateAdded");
            this.Property(t => t.UserListDateModified).HasColumnName("UserListDateModified");
            this.Property(t => t.UserListInActive).HasColumnName("UserListInActive");

            // Relationships
            this.HasRequired(t => t.Company)
                .WithMany(t => t.UserLists)
                .HasForeignKey(d => d.CompanyID);


        }
    }
}
