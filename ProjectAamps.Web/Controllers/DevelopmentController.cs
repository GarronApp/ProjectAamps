using AAMPS.Clients.AampService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Common.Security;
using AAMPS.Clients.ViewModels.Development;
using App.Common.Exceptions;


namespace AAMPS.Web.Controllers
{
    public class DevelopmentController : Controller
    {

        AampServiceClient aampService = new AampServiceClient();

        [AampsAuthorize]
        public ActionResult HomePage()
        {
            return View();
        }

        public JsonResult GetTotals()
        {
            var units = aampService.GetAllUnits().ToList();
            var items = new List<SummaryViewModel>();
            var model = new SummaryViewModel();

            var totalUnitsReserved = units.Count(x => x.UnitStatusID == 2);
            var totalUnitsPending = units.Count(x => x.UnitStatusID == 6);
            var totalUnitsSold = units.Count(x => x.UnitStatusID == 3);


            items.Add(new SummaryViewModel(){
               series = "Available",
               data = units.Where(x => x.UnitStatusID == 1).Count()
            });
              items.Add(new SummaryViewModel(){
               series = "Pending",
               data = units.Where(x => x.UnitStatusID == 3).Count()
            });
              items.Add(new SummaryViewModel(){
               series = "Reserved",
               data = units.Where(x => x.UnitStatusID == 2).Count()
            });
              items.Add(new SummaryViewModel(){
               series = "Sold",
               data = units.Where(x => x.UnitStatusID == 4).Count()
            });

              return Json(items, JsonRequestBehavior.AllowGet);

        }

        // GET: Development
        [AampsAuthorize]
        public ActionResult Dashboard()
        {
            try
            {
                Session.Remove("CurrentUnit");

                var units = aampService.GetAllUnits().ToList();

                //var development = units.
                var totalUnits = units.Count();
                var totalUnitsPrice = units.Sum(x => x.UnitPriceIncluding);
                var totalUnitsAvailable = units.Count(x => x.UnitStatusID == 1);
                var totalUnitsAvailablePrice = units.Where(x => x.UnitStatusID == 1).Sum(x => x.UnitPriceIncluding);
                var totalUnitsReserved = units.Count(x => x.UnitStatusID == 2);
                var totalUnitsReservedPrice = units.Where(x => x.UnitStatusID == 2).Sum(x => x.UnitPriceIncluding);
                var totalUnitsPending = units.Count(x => x.UnitStatusID == 3);
                var totalUnitsPendingPrice = units.Where(x => x.UnitStatusID == 3).Sum(x => x.UnitPriceIncluding);
                var totalUnitsSold = units.Count(x => x.UnitStatusID == 4);
                var totalUnitsSoldPrice = units.Where(x => x.UnitStatusID == 4).Sum(x => x.UnitPriceIncluding);

                Session.Add("TotalUnits", totalUnits);
                Session.Add("TotalUnitsPrice", totalUnitsPrice * totalUnits);
                Session.Add("TotalUnitsAvailable", totalUnitsAvailable);
                Session.Add("TotalUnitsAvailablePrice", totalUnitsAvailablePrice * totalUnitsAvailable);
                Session.Add("TotalUnitsSold", totalUnitsSold);
                Session.Add("totalUnitsSoldPrice", totalUnitsSoldPrice * totalUnitsSold);
                Session.Add("TotalUnitsPending", totalUnitsPending);
                Session.Add("TotalUnitsPendingPrice", totalUnitsPendingPrice * totalUnitsPending);
                Session.Add("TotalUnitsReserved", totalUnitsReserved);
                Session.Add("totalUnitsReservedPrice", totalUnitsReservedPrice * totalUnitsReserved);
               

                List<DevelopmentViewModel> list = new List<DevelopmentViewModel>();

                foreach (var item in units)
                {
                    DevelopmentViewModel viewModel = new DevelopmentViewModel()
                    {
                        UnitId = item.UnitID,
                        UnitStatusId = item.UnitStatusID,
                        UnitNumber = item.UnitNumber,
                        UnitSize = item.UnitSize,
                        UnitBlock = item.UnitBlock,
                        UnitFloor = item.UnitFloor,
                        UnitPrice = item.UnitPrice,
                        UnitPriceIncluding = item.UnitPriceIncluding,
                        UnitActiveDate = item.UnitActiveDate,
                        UnitStatusID = aampService.GetUnitStatusById(item.UnitStatusID).UnitStatusDescription,
                        DevelopmentDescription = aampService.GetDevelopmentById(item.DevelopmentID).DevelopmentDescription

                    };

                  

                    list.Add(viewModel);
                }

                Session.Add("DevelopmentName", list.FirstOrDefault().DevelopmentDescription);
           
              return View(list);

            }
            catch (Exception ex)
            {
              
            }

            return View();
        }
        [HttpGet]
        public JsonResult GetCurrentUnitDetails(int id)
        {
            var development = aampService.GetDevelopmentById(id);

            var _currentUnit = aampService.GetUnitByDevelopmentId(development.DevelopmentID).FirstOrDefault();

            var viewModel = new DevelopmentViewModel()
            {
                UnitId = _currentUnit.UnitID,
                UnitNumber = _currentUnit.UnitNumber,
                UnitSize = _currentUnit.UnitSize,
                UnitFloor = _currentUnit.UnitFloor,
                UnitBlock = _currentUnit.UnitBlock,
                UnitPhase = _currentUnit.UnitPhase,
                UnitPriceIncluding = _currentUnit.UnitPriceIncluding,
                UnitActiveDate = _currentUnit.UnitActiveDate,
                UnitStatusID = aampService.GetUnitStatusById(_currentUnit.UnitStatusID).UnitStatusDescription,
                DevelopmentDescription = aampService.GetDevelopmentById(_currentUnit.DevelopmentID).DevelopmentDescription,
               
            };
           

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void UpdateUnit(DevelopmentViewModel viewModel)
        {
            if (viewModel != null)
            {
                var currentUnit = aampService.GetUnitById(viewModel.UnitId);
                currentUnit.UnitNumber = viewModel.UnitNumber;
                currentUnit.UnitSize = viewModel.UnitSize;
                currentUnit.UnitFloor = viewModel.UnitFloor;
                currentUnit.UnitBlock = viewModel.UnitBlock;
                currentUnit.UnitPhase = viewModel.UnitPhase;
                currentUnit.UnitPriceIncluding = viewModel.UnitPriceIncluding;
                currentUnit.UnitActiveDate = viewModel.UnitActiveDate;

                aampService.UpdateUnit(currentUnit);
               
            }
               
        }

        public JsonResult GetDevelopmentSummary()
        {
            var development = aampService.GetDevelopmentById(1);

            var units = aampService.GetUnitByDevelopmentId(development.DevelopmentID).Count();

            var viewModel = new DevelopmentUnitViewModel()
            {
                DevelopmentDescription = development.DevelopmentDescription,
                EstateName = aampService.GetEstateByDevelopment(development.EstateID).EstateDescription,
                TotalUnits = units

            };

           // Session.Add("DevelopmentName", viewModel.DevelopmentDescription);


            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

   
	}
}