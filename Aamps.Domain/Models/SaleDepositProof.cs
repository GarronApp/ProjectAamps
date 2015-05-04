using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class SaleDepositProof
    {
        public SaleDepositProof()
        {
            this.Sales = new List<Sale>();
        }
        [DataMember]
        public int SaleDepositProofID { get; set; }
        [DataMember]
        public string SaleDepositProofDescription { get; set; }
        [DataMember]
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
