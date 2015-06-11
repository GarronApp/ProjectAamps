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

        public int SaleId { get; set; }

        public SalesViewModel QueryResult { get; set; }

        public ReservationViewModel AvailableReservationVM { get; set; }

        public ReservedSaleViewModel ReservedSaleVM { get; set; }

        public PendingSaleViewModel PendingSaleViewVM { get; set; }
    }
}
