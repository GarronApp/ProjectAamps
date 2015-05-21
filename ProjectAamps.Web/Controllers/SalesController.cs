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
using ProjectAamps.Clients.Actions.Sales;


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
                    var _individual = new Individual();

                    _individual.IndividualName = individual.IndividualName;
                    _individual.IndividualSurname = individual.IndividualSurname;
                    _individual.IndividualContactCell = individual.IndividualContactCell;
                    _individual.IndividualContactHome = individual.IndividualContactHome;
                    _individual.IndividualContactWork = individual.IndividualContactWork;
                    _individual.IndividualEmail = individual.IndividualEmail;
                    var contactMethod = individual.PreferedContactMethodID.ToString();
                    SetPreferedMethod(contactMethod, _individual);
                    individual.PreferedContactMethodID = _individual.PreferedContactMethodID;

                    var result = _repoService.SavePerson(_individual);
                    individual.IndividualID = result.IndividualID;

                    return Json(individual, JsonRequestBehavior.AllowGet);
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
                    
                    return Json(purchaser, JsonRequestBehavior.AllowGet);
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
                    
                    var newSale = new Sale();
                   
                    var _linkedUnit = _repoService.GetUnitById(int.Parse(SessionHandler.GetSessionContext("CurrentUnit")));

                    newSale.SaleActiveStatusID = (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Reserved;
                    reservation.SaleStatusId = (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Reserved;   
                    reservation.CurrentSalesStatus = _repoService.GetSaleActiveStatus((int)newSale.SaleActiveStatusID).SaleActiveStatusDescription;

                    _linkedUnit.UnitStatusID = (int)AAMPS.Clients.AampService.GetUnitStatusType.Reserved;
                    reservation.UnitStatusId = (int)AAMPS.Clients.AampService.GetUnitStatusType.Reserved;
                    _repoService.UpdateUnit(_linkedUnit);

                    newSale.UnitID = _linkedUnit.UnitID;
                    newSale.SaleStatusID = (int)AAMPS.Clients.AampService.GetSaleStatusType.Active;   
                    newSale.SaleReservationDt = reservation.SaleReservationDt != null ? DateTime.ParseExact(reservation.SaleReservationDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
                    newSale.SaleReservationExpiryDt = reservation.SaleReservationExpiryDt != null ? DateTime.ParseExact(reservation.SaleReservationExpiryDt, "dd/MM/yyyy", CultureInfo.InvariantCulture): (DateTime?)null;
                    newSale.SaleReservationExtentionDt = reservation.SaleReservationExtentionDt != null ? DateTime.ParseExact(reservation.SaleReservationExtentionDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
                    newSale.IndividualID = reservation.CurrentIndividualID;
                    newSale.SaleAddedDt = DateTime.Now;
                    newSale.SaleModifiedDt = DateTime.Now;
                    newSale.SaleAddedByUser = 1;
                    newSale.SaleModifiedByUser = 1;
                    newSale.SaleDepositPaidBt = false;
                    newSale.SalesBondRequiredBt = false;
                    newSale.SalesReferalCommDueBt = false;
                    newSale.SalesBondCommDueBt = false;
                    newSale.SaleBondRequiredAmount = 0;

                    _repoService.AddSale(newSale);
                    return Json(reservation, JsonRequestBehavior.AllowGet);
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
                var _currentSale = _repoService.GetSaleById(int.Parse(SessionHandler.GetSessionContext("CurrentSaleId")));
                var _linkedUnit = _repoService.GetUnitById(int.Parse(SessionHandler.GetSessionContext("CurrentUnit")));

                if (_currentSale.SaleActiveStatusID == (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Reserved)
                    {
                        _currentSale.SaleActiveStatusID = (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Pending;
                        sale.SaleStatusId = (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Pending;
                        sale.CurrentSalesStatus = _repoService.GetSaleActiveStatus((int)_currentSale.SaleActiveStatusID).SaleActiveStatusDescription;
                    }

                if (_linkedUnit.UnitStatusID == (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Reserved)
                    {
                        _linkedUnit.UnitStatusID = (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Pending;
                        sale.UnitStatusId = (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Pending;
                        _repoService.UpdateUnit(_linkedUnit);
                    }

                    _currentSale.SaleContractSignedPurchaserDt = sale.SaleContractSignedPurchaserDt != null ? DateTime.ParseExact(sale.SaleContractSignedPurchaserDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
                    _currentSale.SalesDepositProofID = sale.SalesDepositProofID;
                    _currentSale.SaleDepositPaidBt = sale.SaleDepositPaidBt == 1 ? true : false;
                    _currentSale.SalesDepoistPaidDt = sale.SalesDepoistPaidDt != null ? DateTime.ParseExact(sale.SalesDepoistPaidDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
                    _currentSale.SalesDepositProofDt = sale.SalesDepositProofDt != null ? DateTime.ParseExact(sale.SalesDepositProofDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
                    //_currentSale.SalesTotalDepositAmount = sale.SalesTotalDepositAmount != null ? (double)sale.SalesTotalDepositAmount : 0.0;
                    _currentSale.SalesTotalDepositAmount = sale.SalesTotalDepositAmount;
                    _currentSale.SaleModifiedDt = DateTime.Now;
                    _currentSale.SaleModifiedByUser = 1;

                    _repoService.SaveUpdateReservation(_currentSale);
                    return Json(sale, JsonRequestBehavior.AllowGet);
                
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
                var _currentSale = _repoService.GetSaleById(int.Parse(SessionHandler.GetSessionContext("CurrentSaleId")));
                var _linkedUnit = _repoService.GetUnitById(int.Parse(SessionHandler.GetSessionContext("CurrentUnit")));
                if (_currentSale.SaleActiveStatusID == (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Pending)
                {
                    _currentSale.SaleActiveStatusID = (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Sold;
                    sale.SaleStatusId = (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Sold;
                    sale.CurrentSalesStatus = _repoService.GetSaleActiveStatus((int)_currentSale.SaleActiveStatusID).SaleActiveStatusDescription;
                }
                if (_linkedUnit.UnitStatusID == (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Pending)
                {
                    _linkedUnit.UnitStatusID = (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Sold;
                    sale.UnitStatusId = (int)AAMPS.Clients.AampService.GetSaleActiveStatusType.Sold;
                    _repoService.UpdateUnit(_linkedUnit);
                }

                _currentSale.PurchaserID = sale.CurrentPurchaserID;
                _currentSale.SaleContractSignedSellerDt = sale.SaleContractSignedSellerDt != null ? DateTime.ParseExact(sale.SaleContractSignedSellerDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
                _currentSale.SalesBondRequiredBt = sale.SalesBondRequiredBt == 1 ? true : false;
                _currentSale.SalesBondRequiredDt = sale.SalesBondRequiredDt != null ? DateTime.ParseExact(sale.SalesBondRequiredDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
                _currentSale.SaleBondDueTimeDt = sale.SaleBondDueTimeDt != null ? DateTime.ParseExact(sale.SaleBondDueTimeDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
                _currentSale.SaleBondDueExpiryDt = sale.SaleBondDueExpiryDt != null ? DateTime.ParseExact(sale.SaleBondDueExpiryDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
                _currentSale.SaleBondRequiredAmount = sale.SaleBondRequiredAmount != null ? (float)sale.SaleBondRequiredAmount : 0.00;
                _currentSale.SaleTypeID = sale.SaleTypeID == 0 ? 1 : 2;
                _currentSale.SalesBondGrantedDt = sale.SalesBondGrantedDt != null ? DateTime.ParseExact(sale.SalesBondGrantedDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
                _currentSale.SalesBondClientAcceptDt = sale.SalesBondClientAcceptDt != null ? DateTime.ParseExact(sale.SalesBondClientAcceptDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
                _currentSale.SalesBondAmount = sale.SalesBondAmount != null ? (double)sale.SalesBondAmount : 0.0;
                _currentSale.SalesBondClientContactedDt = sale.SalesBondClientContactedDt != null ? DateTime.ParseExact(sale.SalesBondClientContactedDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
                _currentSale.SalesBondBondDocsRecDt = sale.SalesBondBondDocsRecDt != null ? DateTime.ParseExact(sale.SalesBondBondDocsRecDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
                _currentSale.SalesBondCommDueBt = sale.SalesBondCommDueBt == 1 ? true : false;
                _currentSale.SalesBondInterestRate = sale.SalesBondInterestRate;
                _currentSale.SaleModifiedDt = DateTime.Now;
                _currentSale.SaleModifiedByUser = 1;

                _repoService.SaveUpdateReservation(_currentSale);
                return Json(sale, JsonRequestBehavior.AllowGet);

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
                    _repoService.SavePerson(person);
                    return Json(person, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException);
            }

            return null;

        }


        public void SetPreferedMethod(string method, Individual individual)
        {
            switch (method)
            {
                case "0":
                    {
                        individual.PreferedContactMethodID = 1;
                        break;
                    }

                case "1":
                    {
                        individual.PreferedContactMethodID = 4;
                        break;
                    }
                case "2":
                    {
                        individual.PreferedContactMethodID = 2;
                        break;
                    }
                case "3":
                    {
                        individual.PreferedContactMethodID = 3;
                        break;

                    }
                default:
                    break;


            }
        }
	}
}