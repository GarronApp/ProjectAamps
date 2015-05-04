using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Models.Mapping
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            // Primary Key
            this.HasKey(t => t.CommentID);

            // Properties
            this.Property(t => t.CommentDetails)
                .HasMaxLength(65);

            // Table & Column Mappings
            this.ToTable("Comment", "Master");
            this.Property(t => t.CommentID).HasColumnName("CommentID");
            this.Property(t => t.CommentDetails).HasColumnName("CommentDetails");
            this.Property(t => t.CommentAddedDt).HasColumnName("CommentAddedDt");
            this.Property(t => t.CommentAddedByUser).HasColumnName("CommentAddedByUser");
            this.Property(t => t.CommentGroupID).HasColumnName("CommentGroupID");
            this.Property(t => t.SaleID).HasColumnName("SaleID");
            this.Property(t => t.BondAttID).HasColumnName("BondAttID");
            this.Property(t => t.TransAttID).HasColumnName("TransAttID");

            // Relationships
            this.HasOptional(t => t.BondAtt)
                .WithMany(t => t.Comments)
                .HasForeignKey(d => d.BondAttID);
            this.HasRequired(t => t.CommentGroup)
                .WithMany(t => t.Comments)
                .HasForeignKey(d => d.CommentGroupID);
            this.HasOptional(t => t.Sale)
                .WithMany(t => t.Comments)
                .HasForeignKey(d => d.SaleID);
            this.HasOptional(t => t.TransAtt)
                .WithMany(t => t.Comments)
                .HasForeignKey(d => d.TransAttID);

        }
    }
}
