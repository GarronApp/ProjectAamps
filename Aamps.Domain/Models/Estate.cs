using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class Estate
    {
        public Estate()
        {
            this.Developments = new List<Development>();
        }
        [DataMember]
        public int EstateID { get; set; }
        [DataMember]
        public string EstateDescription { get; set; }
        [DataMember]
        public virtual ICollection<Development> Developments { get; set; }
    }
}
