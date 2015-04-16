using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class DevelopmentType
    {
        public DevelopmentType()
        {
            this.Developments = new List<Development>();
        }
        [DataMember]
        public int DevelopmentTypeID { get; set; }
        [DataMember]
        public string DevelopmentTypeDescription { get; set; }
        [DataMember]
        public virtual ICollection<Development> Developments { get; set; }
    }
}
