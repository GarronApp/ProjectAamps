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
        public int UserListID { get; set; }
        [DataMember]
        public int UserTypeID { get; set; }
        [DataMember]
        public int DevelopmentID { get; set; }
        
    }
}
