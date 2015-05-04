using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class Development
    {
        public Development()
        {
            this.SalesCoDevLinks = new List<SalesCoDevLink>();
            this.Units = new List<Unit>();
        }
        [DataMember]
        public int DevelopmentID { get; set; }
        [DataMember]
        public string DevelopmentDescription { get; set; }
        [DataMember]
        public int EstateID { get; set; }
        [DataMember]
        public int DevelopmentTypeID { get; set; }
        [DataMember]
        public bool DevelopmentInActive { get; set; }
        [DataMember]
        public int DevelopmentDevID { get; set; }
        [DataMember]
        public int DevelopmentTransAttID { get; set; }
        [DataMember]
        public int DevelopmentSalesCoID { get; set; }
        [DataMember]
        public string DevelopmentUrlImage { get; set; }
        [DataMember]
        public virtual DevelopmentType DevelopmentType { get; set; }
        [DataMember]
        public virtual Estate Estate { get; set; }
        [DataMember]
        public virtual ICollection<SalesCoDevLink> SalesCoDevLinks { get; set; }
        [DataMember]
        public virtual ICollection<Unit> Units { get; set; }
    }
}
