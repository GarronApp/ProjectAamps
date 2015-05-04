using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class CommissionType
    {
        public CommissionType()
        {
            this.CommissionTrs = new List<CommissionTr>();
        }
        [DataMember]
        public int CommissionTypeID { get; set; }
        [DataMember]
        public string CommissionTypeDescription { get; set; }
        [DataMember]
        public virtual ICollection<CommissionTr> CommissionTrs { get; set; }
    }
}
