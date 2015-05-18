using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class FinancialType
    {
        public FinancialType()
        {
            this.FinancialTrs = new List<FinancialTr>();
        }
        [DataMember]
        public int FinancialTypeID { get; set; }
        [DataMember]
        public string FinancialTypeDescription { get; set; }
        [DataMember]
        public virtual ICollection<FinancialTr> FinancialTrs { get; set; }
    }
}
