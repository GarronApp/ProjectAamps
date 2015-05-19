using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.ValueObjects
{
    [DataContract]
    public class UnitStatusType
    {
        [DataMember]
        public GetUnitStatusType GetUnitStatusTypes;
    }

    [DataContract]
    public enum GetUnitStatusType
    {
        [EnumMember]
        Available = 1,
        [EnumMember]
        Reserved = 2,
        [EnumMember]
        Pending = 3,
        [EnumMember]
        Sold = 4,
        [EnumMember]
        Occupied = 5,
        [EnumMember]
        Bankable = 6,
        [EnumMember]
        Registered = 7,
        [EnumMember]
        Unavailable = 8
    }
}
