using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class Bank
    {
        public Bank()
        {
            this.OriginatorTrs = new List<OriginatorTr>();
            this.Sales = new List<Sale>();
        }
        [DataMember]
        public int BankID { get; set; }
        [DataMember]
        public string BankDescription { get; set; }
        [DataMember]
        public virtual ICollection<OriginatorTr> OriginatorTrs { get; set; }
        [DataMember]
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
