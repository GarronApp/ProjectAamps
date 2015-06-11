using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AAMPS.Clients.AampService;
using App.Common.Security;
using System.Globalization;
using App.Extentions;
using Aamps.Domain.Converters;
using AAMPS.Clients.ViewModels.Individual;
using AAMPS.Clients.ViewModels.Purchaser;
using AAMPS.Clients.ViewModels.Sales;
using Aamps.Domain.ValueObjects;
using AAMPS.Clients.Actions.Sales;
using AAMPS.Clients.Queries.Sales;
using AAMPS.Clients.Actions.Development;
using AAMPS.Clients.Queries.Development;
using AAMPS.Clients.Actions.Sales;
using App.Common.Exceptions;


namespace AAMPS.Web.Controllers
{
    public class SalesController : Controller
    {
        AampServiceClient _repoService = new AampServiceClient();
        //
        // GET: /Sales/

        public int SalesId { get; set; }

        [AampsAuthorize]
        [HttpGet]
        public ActionResult GetSaleTypes()
        {
           var salesTypeList = new List<string>();
           var salesTypes = _repoService.GetSaleTypes();
           foreach (var item in salesTypes)
           {
             salesTypeList.Add(item.SaleTypeDescription);
           }

           return Json(salesTypeList, JsonRequestBehavior.AllowGet);

        }

        [AampsAuthorize]
        [HttpGet]
        public ActionResult GetPreferedContactMethods()
        {
            var contactTypeList = new List<string>();
            var contactTypes = _repoService.GetAllPreferedContactMethods();
            foreach (var item in contactTypes)
            {
                contactTypeList.Add(item.PreferedContactMethodDescription);
            }
            return Json(contactTypeList, JsonRequestBehavior.AllowGet);

        }

        [AampsAuthorize]
        [HttpGet]
        public ActionResult GetPurchaserEntityTypes()
        {
            var purchaserEntityTypesList = new List<string>();
            var purchaserEntityTypes = _repoService.GetPurchaserEntityTypes();
            foreach (var item in purchaserEntityTypes)
            {
                purchaserEntityTypesList.Add(item.EntityTypeDescription);
            }
            return Json(purchaserEntityTypesList, JsonRequestBehavior.AllowGet);
        }

        [AampsAuthorize]
        [HttpGet]
        public ActionResult GetSaleDepositProofs()
        {
            var salesDepositProofList = new List<string>();
            var depositProofs = _repoService.GetDepositTypes();
            foreach (var item in depositProofs)
            {
                salesDepositProofList.Add(item.SaleDepositProofDescription);
            }
            return Json(salesDepositProofList, JsonRequestBehavior.AllowGet);
        }

        [AampsAuthorize]
        [HttpGet]
        public ActionResult GetCompanyOriginator()
        {
            var originatorTypeList = new List<string>();
            var originators = _repoService.GetCompanies();
            foreach (var item in originators.Where(x=> x.UserGroupID == 5))
            {
                originatorTypeList.Add(item.CompanyDescription);
            }
            return Json(originatorTypeList, JsonRequestBehavior.AllowGet);

        }

        [AampsAuthorize]
        [HttpGet]
        public ActionResult Index()
        {
            SessionHandler.SessionContext("NewSale", "true");
            return View();
        }

        [AampsAuthorize]
        public ActionResult Details(int id)
        {

            SessionHandler.SessionContext("CurrentUnit", id);

            var unitId = int.Parse(SessionHandler.GetSessionContext("CurrentUnit"));

            var result = new LoadDevelopmentSummaryTotals(new LoadDevelopmentSummaryTotalsQuery() { UnitId = id });

            return View();
        }

        [HttpGet]
        public JsonResult GetAgentSaleDetails()
        {
            try
            {
                var IsNewSale = SessionHandler.GetSessionContext("NewSale");

                if (IsNewSale != "true")
                {
                    var unitId = int.Parse(SessionHandler.GetSessionContext("CurrentUnit"));

                    var response = new LoadSaleDetails(new LoadSalesQuery() { UnitId = unitId });

                    return Json(response.query.QueryResult, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var unitId = int.Parse(SessionHandler.GetSessionContext("CurrentUnit"));

                    var response = new LoadNewSale(new LoadSalesQuery() { UnitId = unitId });

                    return Json(response.query.QueryResult, JsonRequestBehavior.AllowGet);
                   
                }

            }
            catch (Exception ex)
            {
              
                return Json(ex);
            }

        }

        [HttpGet]
        public JsonResult GetIndividual()
        {
            try
            {
                int _currentUnitId = int.Parse(SessionHandler.GetSessionContext("CurrentUnit"));
                var _individual = _repoService.GetSaleByUnitId(_currentUnitId).Individual;

                if (_individual != null)
                {
                    return Json(_individual, JsonRequestBehavior.AllowGet);
                }
                    
            }
            catch (Exception ex)
            {
              
                return Json(ex.InnerException);
            }

            return null;

        }

        [HttpPost]
        public JsonResult SaveIndividual(IndividualViewModel individual)
        {
            try
            {
                if (individual != null)
                {
                    var _newIndividual = new SaveIndividual(individual);

                    return Json(_newIndividual.IndividualViewModel, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
              
                return Json(ex.InnerException);
            }

            return null;
            
        }


        [HttpPost]
        public JsonResult SavePurchaser(PurchaserViewModel purchaser)
        {
            try
            {
                if (purchaser != null)
                {
                    var _newPurchaser = new SavePurchaser(purchaser);

                    return Json(_newPurchaser.newPurchaserViewModel, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
              
                return Json(ex.InnerException);
            }

            return null;

        }

        [HttpPost]
        public JsonResult SaveAvailableReservation(ReservationViewModel reservation)
        {
            try
            {
                if (reservation != null)
                {
                    var unitId = int.Parse(SessionHandler.GetSessionContext("CurrentUnit"));

                    var response = new LoadAndSaveAvailableSale(new LoadSalesQuery() { UnitId = unitId, AvailableReservationVM = reservation });
                                       
                    return Json(response.avaialableReservationVM, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
              
                return Json(ex.InnerException);
            }

            return null;

        }

        [HttpPost]
        public JsonResult UpdateReservedSale(ReservedSaleViewModel sale)
        {
            try
            {
                var _currentSale = int.Parse(SessionHandler.GetSessionContext("CurrentSaleId"));
                var _linkedUnit = int.Parse(SessionHandler.GetSessionContext("CurrentUnit"));

                var response = new UpdateReservedToPendingSale(new LoadSalesQuery()
                {
                    UnitId = _linkedUnit,
                    SaleId = _currentSale,
                    ReservedSaleVM = sale
                });

                return Json(response.ReservedSaleVM, JsonRequestBehavior.AllowGet);
                
            }
            catch (Exception ex)
            {
              
                return Json(ex.InnerException);
            }

        }

        [HttpPost]
        public JsonResult UpdatePendingSale(PendingSaleViewModel sale)
        {
            try
            {
                var _currentSale = int.Parse(SessionHandler.GetSessionContext("CurrentSaleId"));
                var _linkedUnit =  int.Parse(SessionHandler.GetSessionContext("CurrentUnit"));

                var response = new UpdatePendingToSoldSale(new LoadSalesQuery()
                {
                    UnitId = _linkedUnit,
                    SaleId = _currentSale,
                    PendingSaleViewVM = sale
                });

                return Json(response.PendingSaleVM, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
              
                return Json(ex.InnerException);
            }

        }

        [HttpPost]
        public JsonResult SaveReservation(Individual person)
        {
            try
            {
                if (person != null)
                {
                    _repoService.SaveIndividual(person);
                    return Json(person, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                
                return Json(ex.InnerException);
            }

            return null;

        }


       
	}
}