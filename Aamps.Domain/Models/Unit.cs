using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Aamps.Domain.Models
{
    public partial class Unit
    {
        public Unit()
        {
            //this.Sales = new List<Sale>();
        }
        [DataMember]
        public int UnitID { get; set; }
        [DataMember]
        public string UnitNumber { get; set; }
        [DataMember]
        public int DevelopmentID { get; set; }
        [DataMember]
        public string UnitFloor { get; set; }
        [DataMember]
        public string UnitBlock { get; set; }
        [DataMember]
        public int UnitTypeID { get; set; }
        [DataMember]
        public double UnitSize { get; set; }
        [DataMember]
        public double UnitErfSize { get; set; }
        [DataMember]
        public double UnitPrice { get; set; }
        [DataMember]
        public double UnitPriceVat { get; set; }
        [DataMember]
        public double UnitPriceIncluding { get; set; }
        [DataMember]
        public int UnitStatusID { get; set; }
        [DataMember]
        public Nullable<System.DateTime> UnitActiveDate { get; set; }
        [DataMember]
        public System.DateTime UnitDateAdded { get; set; }
        [DataMember]
        public System.DateTime UnitDateModified { get; set; }
        [DataMember]
        public int UnitAddedByUser { get; set; }
        [DataMember]
        public int UnitModifiedByUser { get; set; }
        [DataMember]
        public Nullable<int> UnitAgentID { get; set; }
        [DataMember]
        public string UnitPhase { get; set; }
        [DataMember]
        public virtual Development Development { get; set; }
        [DataMember]
        //public virtual ICollection<Sale> Sales { get; set; }
        public virtual UnitStatus UnitStatu { get; set; }
        [DataMember]
        public virtual UnitType UnitType { get; set; }
    }

}
