using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AAMPS.Clients.AampService;
using AAMPS.Clients.ViewModels.Bonds;


namespace AAMPS.Clients.Queries.Bonds
{
    public class LoadBondsQuery
    {
        public int UnitId { get; set; }

        public BondsViewModel Result { get; set; }
    }
}
