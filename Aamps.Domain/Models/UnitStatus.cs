using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class UnitStatus
    {
        public UnitStatus()
        {
            this.Units = new List<Unit>();
        }
        [DataMember]
        public int UnitStatusID { get; set; }
        [DataMember]
        public string UnitStatusDescription { get; set; }
        [DataMember]
        public virtual ICollection<Unit> Units { get; set; }
    }
}
