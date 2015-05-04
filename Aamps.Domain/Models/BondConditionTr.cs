using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class BondConditionTr
    {
        [DataMember]
        public int BondConditionTrID { get; set; }
        [DataMember]
        public int BondConditionDescription { get; set; }
        [DataMember]
        public System.DateTime BondConditionTrAddedDt { get; set; }
        [DataMember]
        public System.DateTime BondConditionTrModifiedDt { get; set; }
        [DataMember]
        public int BondConditionTrAddedByUser { get; set; }
        [DataMember]
        public int BondConditionTrModifiedByUser { get; set; }
        [DataMember]
        public int SaleID { get; set; }
        [DataMember]
        public int BondAttID { get; set; }
        [DataMember]
        public virtual BondAtt BondAtt { get; set; }
        [DataMember]
        public virtual Sale Sale { get; set; }
    }
}
