using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.Queries.Units
{
    public class SelectRelevantUnitsQuery
    {
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
    }
}
