using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class SalesCoDevLink
    {
        [DataMember]
        public int SalesCoDevLinkID { get; set; }
        [DataMember]
        public Nullable<int> DevelopmentID { get; set; }
        [DataMember]
        public Nullable<int> SalesCoID { get; set; }
        [DataMember]
        public bool SalesCoDevLinkDefault { get; set; }
        [DataMember]
        public virtual Development Development { get; set; }
    }
}
