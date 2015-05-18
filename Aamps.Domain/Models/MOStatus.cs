using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class MOStatus
    {
        public MOStatus()
        {
            this.OriginatorTrs = new List<OriginatorTr>();
        }
        [DataMember]
        public int MOStatusID { get; set; }
        [DataMember]
        public string MOStatusDescription { get; set; }
        [DataMember]
        public virtual ICollection<OriginatorTr> OriginatorTrs { get; set; }
    }
}
