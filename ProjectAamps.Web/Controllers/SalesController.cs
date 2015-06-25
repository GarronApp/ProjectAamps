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
using App.Common.Exceptions;
using AAMPS.Clients.Security;
using AAMPS.Web.Providers;
using ProjectAamps.Clients.Security;


namespace AAMPS.Web.Controllers
{
    public class SalesController : BaseController
    {
        //
        // GET: /Sales/

        public int SalesId { get; set; }

        [HttpGet]
        [AampsAuthorize]
        public ActionResult GetSaleTypes()
        {
           var salesTypeList = new List<string>();
           var salesTypes = _serviceProvider.GetSaleTypes();
           foreach (var item in salesTypes)
           {
             salesTypeList.Add(item.SaleTypeDescription);
           }

           return Json(salesTypeList, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        [AampsAuthorize]
        public ActionResult GetPreferedContactMethods()
        {
            var contactTypeList = new List<string>();
            var contactTypes = _serviceProvider.GetAllPreferedContactMethods();
            foreach (var item in contactTypes)
            {
                contactTypeList.Add(item.PreferedContactMethodDescription);
            }
            return Json(contactTypeList, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        [AampsAuthorize]
        public ActionResult GetPurchaserEntityTypes()
        {
            var purchaserEntityTypesList = new List<string>();
            var purchaserEntityTypes = _serviceProvider.GetPurchaserEntityTypes();
            foreach (var item in purchaserEntityTypes)
            {
                purchaserEntityTypesList.Add(item.EntityTypeDescription);
            }
            return Json(purchaserEntityTypesList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AampsAuthorize]
        public ActionResult GetSaleDepositProofs()
        {
            var salesDepositProofList = new List<string>();
            var depositProofs = _serviceProvider.GetDepositTypes();
            foreach (var item in depositProofs)
            {
                salesDepositProofList.Add(item.SaleDepositProofDescription);
            }
            return Json(salesDepositProofList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AampsAuthorize]
        public ActionResult GetCompanyOriginator()
        {
            var originatorTypeList = new List<string>();
            var originators = _serviceProvider.GetCompanies();
            foreach (var item in originators.Where(x=> x.UserGroupID == 5))
            {
                originatorTypeList.Add(item.CompanyDescription);
            }
            return Json(originatorTypeList, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        [AampsAuthorize]
        public ActionResult Index()
        {
            SessionHandler.SessionContext("NewSale", "true");
            return View();
        }

        [AampsAuthorize]
        public ActionResult Details(int id)
        {

            SessionHandler.SessionContext("CurrentUnit", id);

            var result = new LoadDevelopmentSummaryTotals(new LoadDevelopmentSummaryTotalsQuery() { UnitId = UnitID.GetValueOrDefault()});

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
                    var response = new LoadSaleDetails(new LoadSalesQuery() { UnitId = UnitID.GetValueOrDefault()});

                    return Json(response.query.QueryResult, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var response = new LoadNewSale(new LoadSalesQuery() { UnitId = UnitID.GetValueOrDefault() });

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
                var _individual = _serviceProvider.GetSaleByUnitId(UnitID.GetValueOrDefault()).Individual;

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
        [AampsAuthorize(Permissions.Add)]
        public JsonResult SaveIndividual(IndividualViewModel individual)
        {
            try
            {
                if (individual != null)
                {
                    var _newIndividual = new SaveIndividual(individual);

                    //DUPLICATION SECTION TO BE COMPLETED*

                    if (_newIndividual.DuplicationIndividuals.Count > 0)
                    {

                        return Json(_newIndividual.DuplicationIndividuals, JsonRequestBehavior.AllowGet);
                    }

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
        [AampsAuthorize(Permissions.Add)]
        public JsonResult SavePurchaser(PurchaserViewModel purchaser)
        {
            try
            {
                if (purchaser.IsNotNull())
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
        [AampsAuthorize(Permissions.Add)]
        public JsonResult SaveAvailableReservation(ReservationViewModel reservation)
        {
            try
            {   
                if (reservation != null)
                {
                    var response = new LoadAndSaveAvailableSale(new LoadSalesQuery() { UnitId = UnitID.GetValueOrDefault(), AvailableReservationVM = reservation });
                                       
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
        [AampsAuthorize(Permissions.Edit)]
        public JsonResult UpdateReservedSale(ReservedSaleViewModel sale)
        {
            try
            {
                var _currentSale = SaleID.GetValueOrDefault();
                var _linkedUnit = UnitID.GetValueOrDefault();

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
        [AampsAuthorize(Permissions.Edit)]
        public JsonResult UpdatePendingSale(PendingSaleViewModel sale)
        {
            try
            {
                var _currentSale = SaleID.GetValueOrDefault();
                var _linkedUnit = UnitID.GetValueOrDefault();

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
        [AampsAuthorize(Permissions.Add)]
        public JsonResult SaveReservation(Individual person)
        {
            try
            {
                if (person != null)
                {
                    _serviceProvider.SaveIndividual(person);
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