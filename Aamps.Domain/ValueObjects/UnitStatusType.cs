using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.ValueObjects
{
    
    public class UnitStatusType
    {
        public enum GetUnitStatusType
        {
            Available = 1,
            Reserved = 2,
            Pending = 3,
            Sold = 4,
            Occupied = 5,
            Bankable = 6,
            Registered = 7,
            Unavailable = 8
        }
    }
}
