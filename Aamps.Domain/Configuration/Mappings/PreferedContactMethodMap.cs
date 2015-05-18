using Aamps.Domain.Model.Master;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Configuration.Mappings
{
    public class PreferedContactMethodMap : EntityTypeConfiguration<PreferedContactMethod>
    {
        public PreferedContactMethodMap()
        {
            // Primary Key
            this.HasKey(t => t.PreferedContactMethodID);

            // Properties
            this.Property(t => t.PreferedContactMethodDescription)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PreferedContactMethod", "Master");
            this.Property(t => t.PreferedContactMethodID).HasColumnName("PreferedContactMethodID");
            this.Property(t => t.PreferedContactMethodDescription).HasColumnName("PreferedContactMethodDescription");
        }
    }
}
