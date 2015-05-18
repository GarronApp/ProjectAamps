using Aamps.Domain.Model.UserCompanies;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Configuration.Mappings
{
    public class GroupRightMap : EntityTypeConfiguration<GroupRight>
    {
        public GroupRightMap()
        {
            // Primary Key
            this.HasKey(t => t.GroupRightID);

            // Properties
            // Table & Column Mappings
            this.ToTable("GroupRight", "UserCompanies");
            this.Property(t => t.GroupRightID).HasColumnName("GroupRightID");
            this.Property(t => t.UserGroupID).HasColumnName("UserGroupID");
            this.Property(t => t.FormReportID).HasColumnName("FormReportID");
            this.Property(t => t.GroupRightFull).HasColumnName("GroupRightFull");
            this.Property(t => t.GroupRightView).HasColumnName("GroupRightView");
            this.Property(t => t.GroupRightEdit).HasColumnName("GroupRightEdit");
            this.Property(t => t.GroupRightAdd).HasColumnName("GroupRightAdd");
            this.Property(t => t.GroupRightDelete).HasColumnName("GroupRightDelete");
            this.Property(t => t.GroupRightDateAdded).HasColumnName("GroupRightDateAdded");
            this.Property(t => t.GroupRightDateModified).HasColumnName("GroupRightDateModified");

            // Relationships
            this.HasRequired(t => t.FormReport)
                .WithMany(t => t.GroupRights)
                .HasForeignKey(d => d.FormReportID);
            this.HasRequired(t => t.UserGroup)
                .WithMany(t => t.GroupRights)
                .HasForeignKey(d => d.UserGroupID);

        }
    }
}
