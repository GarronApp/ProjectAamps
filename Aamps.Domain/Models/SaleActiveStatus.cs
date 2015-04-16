using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class SaleActiveStatus
    {
        public SaleActiveStatus()
        {
            this.Sales = new List<Sale>();
        }
        [DataMember]
        public int SaleActiveStatusID { get; set; }
        [DataMember]
        public string SaleActiveStatusDescription { get; set; }
        [DataMember]
        public virtual ICollection<Sale> Sales { get; set; }
    }
}

