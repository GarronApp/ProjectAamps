using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class PreferedContactMethod
    {
        public PreferedContactMethod()
        {
            this.Individuals = new List<Individual>();
        }
        [DataMember]
        public int PreferedContactMethodID { get; set; }
        [DataMember]
        public string PreferedContactMethodDescription { get; set; }
        [DataMember]
        public virtual ICollection<Individual> Individuals { get; set; }
    }
}
