using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Models.Mapping
{
    public class CommentGroupMap : EntityTypeConfiguration<CommentGroup>
    {
        public CommentGroupMap()
        {
            // Primary Key
            this.HasKey(t => t.CommentGroupID);

            // Properties
            this.Property(t => t.CommentGroupDescription)
                .IsRequired()
                .HasMaxLength(65);

            // Table & Column Mappings
            this.ToTable("CommentGroup", "Master");
            this.Property(t => t.CommentGroupID).HasColumnName("CommentGroupID");
            this.Property(t => t.CommentGroupDescription).HasColumnName("CommentGroupDescription");
        }
    }
}
