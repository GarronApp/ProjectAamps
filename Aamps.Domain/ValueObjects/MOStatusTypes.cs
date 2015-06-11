using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.ValueObjects
{
    [DataContract]
    public enum MOStatusTypes
    {
        [EnumMember]
        Submitted = 1,
        [EnumMember]
        ApproveInPrincipal = 2,
        [EnumMember]
        Granted = 3,
        [EnumMember]
        ClientAccepted = 4,
        [EnumMember]
        Declined = 5,
        [EnumMember]
        Incomplete = 6

    }
}
