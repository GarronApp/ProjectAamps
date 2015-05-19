using AAMPS.Clients.ViewModels.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAMPS.Clients.Queries.Sales
{
    public class LoadSalesQuery
    {
        public int UnitId { get; set; }

        public SalesViewModel QueryResult { get; set; }
    }
}
