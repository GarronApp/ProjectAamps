using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class PurchaserIndividualLink
    {
        [DataMember]
        public int PurchaserIndividualLinkID { get; set; }
        [DataMember]
        public Nullable<int> PurchaserID { get; set; }
        [DataMember]
        public Nullable<int> IndividualID { get; set; }
        [DataMember]
        public bool PurchaserIndividualLinkMainContact { get; set; }
        [DataMember]
        public virtual Individual Individual { get; set; }
        [DataMember]
        public virtual Purchaser Purchaser { get; set; }
    }
}
