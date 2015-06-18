using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.Queries.Developments
{
    public class SelectRelevantDevelopmentQuery
    {
        [DataMember]
        public int DevelopmentID { get; set; }
        [DataMember]
        public string DevelopmentDescription { get; set; }
        [DataMember]
        public int EstateID { get; set; }
        [DataMember]
        public string DevelopmentUrlImage { get; set; }

    }
}
