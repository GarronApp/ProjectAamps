using AAMPS.Clients.AampService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Common.Security;
using AAMPS.Clients.ViewModels.Development;
using App.Common.Exceptions;
using AAMPS.Clients.Security;
using App.Extentions;
using AAMPS.Web.Providers;
using AAMPS.Clients.Security;


namespace AAMPS.Web.Controllers
{
    public class DevelopmentController : BaseController
    {
        [AampsAuthorize]
        public ActionResult HomePage()
        {
            try
            {

                if (USER.IsNotNull())
                {
                    var developments = _serviceProvider.GetDevelopmentsByAgent(new SelectRelevantDevelopmentQuery()
                    {
                        UserListID = USER.UserListID,
                        UserGroupID = USER.UserGroupID,
                        UserTypeID = USER.UserTypeID,
                        CompanyID = USER.CompanyID
                    });

                    return View(developments);
                }

            }
            catch (Exception ex)
            {

                ExceptionHandler.HandleException(ex);
            }

            return View();
        }

        public JsonResult GetTotals()
        {
            var units = _serviceProvider.GetUnitsByDevelopment(DevelopmentID);
            
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
        public ActionResult Dashboard()
        {
            try
            {
                Session.Remove("CurrentUnit");
               
                 var units = _serviceProvider.GetDevelopmentUnits(new SelectRelevantUnitsQuery()
                 {
                     DevelopmentID = DevelopmentID,
                     UserListID = USER.UserListID,
                     UserTypeID = USER.UserTypeID
                 });

                 SessionHandler.SessionContext("DevelopmentImage", DevelopmentImage);

                 if (units.IsNotNull() && units.HasItems())
                 {
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
                 }

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
                        UnitStatusID = _serviceProvider.GetUnitStatusById(item.UnitStatusID).UnitStatusDescription,
                        DevelopmentDescription = _serviceProvider.GetDevelopmentById(item.DevelopmentID).DevelopmentDescription,

                    };

                    list.Add(viewModel);
                }

                Session.Add("DevelopmentName", list.FirstOrDefault().DevelopmentDescription);
           
              return View(list);

            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }

            return View();
        }
        [HttpGet]
        [AampsAuthorize(Permissions.View)]
        public JsonResult GetCurrentUnitDetails(int id)
        {
            var development = _serviceProvider.GetDevelopmentById(id);

            Invariant.IsNotNull(development, () => "development does not exist");

            var _currentUnit = _serviceProvider.GetUnitByDevelopmentId(development.DevelopmentID).FirstOrDefault();

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
                UnitStatusID = _serviceProvider.GetUnitStatusById(_currentUnit.UnitStatusID).UnitStatusDescription,
                DevelopmentDescription = _serviceProvider.GetDevelopmentById(_currentUnit.DevelopmentID).DevelopmentDescription,
               
            };
           

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void UpdateUnit(DevelopmentViewModel viewModel)
        {
            try
            {
                if (viewModel.IsNotNull())
                {
                    var currentUnit = _serviceProvider.GetUnitById(viewModel.UnitId);
                    currentUnit.UnitNumber = viewModel.UnitNumber;
                    currentUnit.UnitSize = viewModel.UnitSize;
                    currentUnit.UnitFloor = viewModel.UnitFloor;
                    currentUnit.UnitBlock = viewModel.UnitBlock;
                    currentUnit.UnitPhase = viewModel.UnitPhase;
                    currentUnit.UnitPriceIncluding = viewModel.UnitPriceIncluding;
                    currentUnit.UnitActiveDate = viewModel.UnitActiveDate;

                    _serviceProvider.UpdateUnit(currentUnit);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
               
        }

        public JsonResult GetDevelopmentSummary()
        {
            var development = _serviceProvider.GetDevelopmentById(1);

            var units = _serviceProvider.GetUnitByDevelopmentId(development.DevelopmentID).Count();

            var viewModel = new DevelopmentUnitViewModel()
            {
                DevelopmentDescription = development.DevelopmentDescription,
                EstateName = _serviceProvider.GetEstateByDevelopment(development.EstateID).EstateDescription,
                TotalUnits = units

            };
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

   
	}
}