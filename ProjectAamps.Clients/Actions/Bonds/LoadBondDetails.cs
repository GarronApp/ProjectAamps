using AAMPS.Clients.Mappers.Bonds;
using App.Common.Controllers.Actions;
using AAMPS.Clients.Queries.Bonds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ProjectAamps.Clients.Actions.Base;


namespace AAMPS.Clients.Actions.Bonds
{
    public class LoadBondDetails : ControllerAction
    {
        public AAMPS.Clients.AampService.AampServiceClient _repoService = new AampService.AampServiceClient();
        public int Id { get; set; }
        public LoadBondsQuery query { get; set; }

        public LoadBondDetails() 
        {
        }
        public LoadBondDetails(LoadBondsQuery _query) : base(_query)
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
            var currentSale = new AampService.AampServiceClient().GetSaleByUnitId(Id);

           // var _currentUnit = _repoService.GetUnitByDevelopmentId(currentSale.Unit.DevelopmentID).FirstOrDefault();
            
            var result = new MapToBonds(new MapBondsQuery() { Sale = currentSale, Unit = currentSale.Unit});
            query.Result = result.Result;
            return result.Result;
        }

     
    }
}
