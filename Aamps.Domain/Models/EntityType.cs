using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class EntityType
    {
        public EntityType()
        {
            this.Purchasers = new List<Purchaser>();
        }
        [DataMember]
        public int EntityTypeID { get; set; }
        [DataMember]
        public string EntityTypeDescription { get; set; }
        [DataMember]
        public virtual ICollection<Purchaser> Purchasers { get; set; }
    }
}
