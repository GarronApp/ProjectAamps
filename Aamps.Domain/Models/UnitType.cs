using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class UnitType
    {
        public UnitType()
        {
            this.Units = new List<Unit>();
        }
        [DataMember]
        public int UnitTypeID { get; set; }
        [DataMember]
        public string UnitTypeDescription { get; set; }
        [DataMember]
        public virtual ICollection<Unit> Units { get; set; }
    }
}
