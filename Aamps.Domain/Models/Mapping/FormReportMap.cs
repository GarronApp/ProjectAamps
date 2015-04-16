using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Aamps.Domain.Models.Mapping
{
    public class FormReportMap : EntityTypeConfiguration<FormReport>
    {
        public FormReportMap()
        {
            // Primary Key
            this.HasKey(t => t.FormReportID);

            // Properties
            this.Property(t => t.FormReportDescription)
                .IsRequired()
                .HasMaxLength(65);

            // Table & Column Mappings
            this.ToTable("FormReport", "UserCompanies");
            this.Property(t => t.FormReportID).HasColumnName("FormReportID");
            this.Property(t => t.FormReportDescription).HasColumnName("FormReportDescription");
            this.Property(t => t.FormReportIsForm).HasColumnName("FormReportIsForm");
        }
    }
}
