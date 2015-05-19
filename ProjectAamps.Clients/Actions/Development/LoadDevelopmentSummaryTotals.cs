using App.Common.Controllers.Actions;
using App.Common.Security;
using AAMPS.Clients.Queries.Development;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAMPS.Clients.Actions.Development
{
    public class LoadDevelopmentSummaryTotals : ControllerAction
    {
        public AAMPS.Clients.AampService.AampServiceClient _repoService = new AAMPS.Clients.AampService.AampServiceClient();

        public int Id { get; set; }
        public LoadDevelopmentSummaryTotalsQuery query { get; set; }

        public LoadDevelopmentSummaryTotals()
        { 

        }

        public LoadDevelopmentSummaryTotals(LoadDevelopmentSummaryTotalsQuery _query)
            : base(_query)
        {
            Id = _query.UnitId;
            OnExecute();
        }

        public override object OnExecute()
        {
            var currentUnit = _repoService.GetUnitById(Id);
            var currentUnitStatus = currentUnit.UnitStatusID;
            
            if (HttpContext.Current.Session["NewSale"] != null)
            {
                HttpContext.Current.Session.Remove("NewSale");
            }
            
            if (currentUnitStatus == _repoService.GetUnitStatusTypes(AampService.GetUnitStatusType.Available))
            {
                SessionHandler.SessionContext("CurrentUnitStatus", "Available");
                SessionHandler.SessionContext("NewSale", "true");
            }

            SessionHandler.SessionContext("CurrentUnit", Id);
            var units = _repoService.GetAllUnits().ToList();

            var totalUnits = units.Count();
            var totalUnitsPrice = units.Sum(x => x.UnitPriceIncluding);
            var totalUnitsAvailable = units.Count(x => x.UnitStatusID == (int)AampService.GetUnitStatusType.Available);
            var totalUnitsAvailablePrice = units.Where(x => x.UnitStatusID == (int)AampService.GetUnitStatusType.Available).Sum(x => x.UnitPriceIncluding);
            var totalUnitsReserved = units.Count(x => x.UnitStatusID == (int)AampService.GetUnitStatusType.Reserved);
            var totalUnitsReservedPrice = units.Where(x => x.UnitStatusID == (int)AampService.GetUnitStatusType.Reserved).Sum(x => x.UnitPriceIncluding);
            var totalUnitsPending = units.Count(x => x.UnitStatusID == (int)AampService.GetUnitStatusType.Pending);
            var totalUnitsPendingPrice = units.Where(x => x.UnitStatusID == (int)AampService.GetUnitStatusType.Pending).Sum(x => x.UnitPriceIncluding);
            var totalUnitsSold = units.Count(x => x.UnitStatusID == (int)AampService.GetUnitStatusType.Sold);
            var totalUnitsSoldPrice = units.Where(x => x.UnitStatusID == (int)AampService.GetUnitStatusType.Sold).Sum(x => x.UnitPriceIncluding);

            HttpContext.Current.Session.Add("TotalUnits", totalUnits);
            HttpContext.Current.Session.Add("TotalUnitsPrice", totalUnitsPrice * totalUnits);
            HttpContext.Current.Session.Add("TotalUnitsAvailable", totalUnitsAvailable);
            HttpContext.Current.Session.Add("TotalUnitsAvailablePrice", totalUnitsAvailablePrice * totalUnitsAvailable);
            HttpContext.Current.Session.Add("TotalUnitsSold", totalUnitsSold);
            HttpContext.Current.Session.Add("totalUnitsSoldPrice", totalUnitsSoldPrice * totalUnitsSold);
            HttpContext.Current.Session.Add("TotalUnitsPending", totalUnitsPending);
            HttpContext.Current.Session.Add("TotalUnitsPendingPrice", totalUnitsPendingPrice * totalUnitsPending);
            HttpContext.Current.Session.Add("TotalUnitsReserved", totalUnitsReserved);
            HttpContext.Current.Session.Add("totalUnitsReservedPrice", totalUnitsReservedPrice * totalUnitsReserved);

            return string.Empty;
        }

    }
}
