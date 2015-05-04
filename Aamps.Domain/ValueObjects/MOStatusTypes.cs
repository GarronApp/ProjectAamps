using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.ValueObjects
{
    public enum MOStatusTypes
    {
        Submitted = 1,
        ApproveInPrincipal = 2,
        Granted = 3,
        ClientAccepted = 4,
        Declined = 5,
        Incomplete = 6

    }
}
