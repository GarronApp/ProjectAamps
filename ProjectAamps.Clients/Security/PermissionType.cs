using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AAMPS.Clients.Security
{
    [Flags]
    public enum Permissions
    {
        View = 1,
        Add = 2,
        Edit = 4,
        Delete = 6,
        Admin = (View | Add | Edit | Delete)
    }
}
