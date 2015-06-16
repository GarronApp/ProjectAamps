﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAMPS.Clients.Security
{
    [Flags]
    public enum Permissions
    {
        View = (1 << 0),
        Add = (1 << 1),
        Edit = (1 << 2),
        Delete = (1 << 3),
        Admin = (View | Add | Edit | Delete)
    }
}
