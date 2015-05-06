using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.ValueObjects
{
    public class SaleActiveStatusType
    {
       public enum GetSaleActiveStatusType
        {
            Available = 1,
            Reserved = 2,
            Pending = 3,
            Sold = 4,
            Bankable = 5,
            Registered = 6
        }

       public enum GetSaleStatusType
       {
           Active = 1,
           Cancelled = 2,
           Declined = 3,
           InActive = 4
       }

    }
}
