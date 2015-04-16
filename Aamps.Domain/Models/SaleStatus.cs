using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class SaleStatus
    {
        public SaleStatus()
        {
            this.Sales = new List<Sale>();
        }
        [DataMember]
        public int SaleStatusID { get; set; }
        [DataMember]
        public string SaleStatusDescription { get; set; }
        [DataMember]
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
