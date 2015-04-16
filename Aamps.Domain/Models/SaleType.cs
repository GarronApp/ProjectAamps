using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class SaleType
    {
        public SaleType()
        {
            this.Sales = new List<Sale>();
        }
        [DataMember]
        public int SaleTypeID { get; set; }
        [DataMember]
        public string SaleTypeDescription { get; set; }
        [DataMember]
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
