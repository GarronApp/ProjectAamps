using App.Common.Controllers.Actions;
using AAMPS.Clients.Mappers.Sales;
using AAMPS.Clients.Queries.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAMPS.Clients.Actions.Sales
{
    public class LoadSaleDetails : ControllerAction
    {
        public AAMPS.Clients.AampService.AampServiceClient _repoService = new AAMPS.Clients.AampService.AampServiceClient();

        public int Id { get; set; }
        public LoadSalesQuery query { get; set; }

         public LoadSaleDetails()
         {

         }

         public LoadSaleDetails(LoadSalesQuery _query) : base(_query)
        {
            query = _query;
            OnBindModel();
        }

         public override void OnBindModel()
         {
             Id = query.UnitId;
             OnExecute();
         }

         public override object OnExecute()
         {
             var currentSale = new AAMPS.Clients.AampService.AampServiceClient().GetSaleByUnitId(Id);

             var result = new MapToSaleDetails(new MapToSaleDetailsQuery() { Sale = currentSale});

             query.QueryResult = result.SalesViewModelResult;

             return result.SalesViewModelResult;
         }
    }
}

