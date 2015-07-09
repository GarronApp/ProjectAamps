using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.Models.Mapping
{
    public class DocumentDtlMap : EntityTypeConfiguration<DocumentDtl>
    {
        public DocumentDtlMap()
        {
            // Primary Key
            this.HasKey(t => t.DocumentDtlID);

            // Properties
            this.Property(t => t.DocumentDtlPath)
                .HasMaxLength(255);

            this.Property(t => t.DocumentDtlName)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("DocumentDtl", "Documents");
            this.Property(t => t.DocumentDtlID).HasColumnName("DocumentDtlID");
            this.Property(t => t.DocumentDtlGUID).HasColumnName("DocumentDtlGUID");
            this.Property(t => t.DocumentDtlPath).HasColumnName("DocumentDtlPath");
            this.Property(t => t.DocumentDtlName).HasColumnName("DocumentDtlName");
            this.Property(t => t.SalesID).HasColumnName("SalesID");
            this.Property(t => t.IndividualID).HasColumnName("IndividualID");
            this.Property(t => t.PurchaserID).HasColumnName("PurchaserID");
            this.Property(t => t.OriginatorID).HasColumnName("OriginatorID");
            this.Property(t => t.FinancialTr).HasColumnName("FinancialTr");
            this.Property(t => t.UnitID).HasColumnName("UnitID");
            this.Property(t => t.TransferID).HasColumnName("TransferID");
            this.Property(t => t.DocumentDtlAddedDt).HasColumnName("DocumentDtlAddedDt");
            this.Property(t => t.DocumenDtltAddedUserID).HasColumnName("DocumenDtltAddedUserID");
        }
    }
}
