using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Models.Mapping
{
    public class SaleDepositProofMap : EntityTypeConfiguration<SaleDepositProof>
    {
        public SaleDepositProofMap()
        {
            // Primary Key
            this.HasKey(t => t.SaleDepositProofID);

            // Properties
            this.Property(t => t.SaleDepositProofDescription)
                .IsRequired()
                .HasMaxLength(65);

            // Table & Column Mappings
            this.ToTable("SaleDepositProof", "Sales");
            this.Property(t => t.SaleDepositProofID).HasColumnName("SaleDepositProofID");
            this.Property(t => t.SaleDepositProofDescription).HasColumnName("SaleDepositProofDescription");
        }
    }
}
