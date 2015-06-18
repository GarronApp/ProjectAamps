using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AAMPS.Clients.Security
{
    [DataContract]
    [Flags]
    public enum Permissions
    {
        [EnumMember]
        View = (1 << 0),
        [EnumMember]
        Add = (1 << 1),
        [EnumMember]
        Edit = (1 << 2),
        [EnumMember]
        Delete = (1 << 3),
        [EnumMember]
        Admin = (View | Add | Edit | Delete)
    }
}
