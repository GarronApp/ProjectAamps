using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Models.Mapping
{
    public class BankMap : EntityTypeConfiguration<Bank>
    {
        public BankMap()
        {
            // Primary Key
            this.HasKey(t => t.BankID);

            // Properties
            this.Property(t => t.BankDescription)
                .IsRequired()
                .HasMaxLength(65);

            // Table & Column Mappings
            this.ToTable("Bank", "Master");
            this.Property(t => t.BankID).HasColumnName("BankID");
            this.Property(t => t.BankDescription).HasColumnName("BankDescription");
        }
    }
}
