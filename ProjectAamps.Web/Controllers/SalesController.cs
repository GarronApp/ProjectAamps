using AAMPS.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AAMPS.Clients.AampService;
using App.Common.Security;
using AAMPS.Web.Models.ViewModels.Sales;
using System.Globalization;
using App.Extentions;
using Aamps.Domain.ValueObjects;
using Aamps.Domain.Converters;

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

        //[AampsAuthorize]
        //[HttpGet]
        //public ActionResult Details()
        //{
        //    SessionHandler.SessionContext("NewSale","true");
        //    return View();
        //}

        [AampsAuthorize]
        public ActionResult Details(int id)
        {
            var currentUnit = _repoService.GetUnitById(id);
            var currentUnitStatus = currentUnit.UnitStatusID;

            if (Session["NewSale"] != null)
            {
                Session.Remove("NewSale");
            }

            if(currentUnitStatus == (int)UnitStatusType.GetUnitStatusType.Available)
            {
                SessionHandler.SessionContext("CurrentUnitStatus", "Available");
                SessionHandler.SessionContext("NewSale", "true");
            }
            
            SessionHandler.SessionContext("CurrentUnit", id);
            var units = _repoService.GetAllUnits().ToList();

            var totalUnits = units.Count();
            var totalUnitsPrice = units.Sum(x => x.UnitPriceIncluding);
            var totalUnitsAvailable = units.Count(x => x.UnitStatusID == (int)UnitStatusType.GetUnitStatusType.Available);
            var totalUnitsAvailablePrice = units.Where(x => x.UnitStatusID == (int)UnitStatusType.GetUnitStatusType.Available).Sum(x => x.UnitPriceIncluding);
            var totalUnitsReserved = units.Count(x => x.UnitStatusID == (int)UnitStatusType.GetUnitStatusType.Reserved);
            var totalUnitsReservedPrice = units.Where(x => x.UnitStatusID == (int)UnitStatusType.GetUnitStatusType.Reserved).Sum(x => x.UnitPriceIncluding);
            var totalUnitsPending = units.Count(x => x.UnitStatusID == (int)UnitStatusType.GetUnitStatusType.Pending);
            var totalUnitsPendingPrice = units.Where(x => x.UnitStatusID == (int)UnitStatusType.GetUnitStatusType.Pending).Sum(x => x.UnitPriceIncluding);
            var totalUnitsSold = units.Count(x => x.UnitStatusID == (int)UnitStatusType.GetUnitStatusType.Sold);
            var totalUnitsSoldPrice = units.Where(x => x.UnitStatusID == (int)UnitStatusType.GetUnitStatusType.Sold).Sum(x => x.UnitPriceIncluding);

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
                    SalesAgentViewModel saleAgent = new SalesAgentViewModel();
                    int _currentUnitId = int.Parse(SessionHandler.GetSessionContext("CurrentUnit"));
                    var currentSalesAgent = _repoService.GetSaleByUnitId(_currentUnitId);
                    SessionHandler.SessionContext("CurrentSaleId", currentSalesAgent.SaleID);
                    int saleActiveStatus = (int)currentSalesAgent.SaleActiveStatusID;
                    saleAgent.CurrentSalesStatusId = _repoService.GetSaleActiveStatus(saleActiveStatus).SaleActiveStatusID;
                    saleAgent.CurrentSalesStatus = _repoService.GetSaleActiveStatus(saleActiveStatus).SaleActiveStatusDescription;
                    saleAgent.ReservationLapses = currentSalesAgent.SaleReservationDt;
                    saleAgent.ReservationTimeExtention = currentSalesAgent.SaleReservationExtentionDt;
                    saleAgent.ContractSigned = false;
                    saleAgent.DepositPaid = currentSalesAgent.SaleDepositPaidBt;
                    saleAgent.DateSignedBySeller = currentSalesAgent.SaleContractSignedSellerDt;
                    saleAgent.Development = _repoService.GetDevelopmentById(currentSalesAgent.Unit.DevelopmentID).DevelopmentDescription;
                    saleAgent.UnitNumber = currentSalesAgent.Unit.UnitNumber;
                    saleAgent.UnitSize = currentSalesAgent.Unit.UnitSize;
                    saleAgent.UnitPrice = currentSalesAgent.Unit.UnitPrice;
                    saleAgent.UnitPhase = currentSalesAgent.Unit.UnitPhase;
                    saleAgent.UnitFloor = currentSalesAgent.Unit.UnitFloor;
                    saleAgent.PlotSize = currentSalesAgent.Unit.UnitErfSize;
                    saleAgent.IndividualFirstName = currentSalesAgent.Individual.IndividualName;
                    saleAgent.IndividualLastName = currentSalesAgent.Individual.IndividualSurname;
                    saleAgent.IndividualCellNo = currentSalesAgent.Individual.IndividualContactCell;
                    saleAgent.IndividualWorkNo = currentSalesAgent.Individual.IndividualContactWork;
                    saleAgent.IndividualEmailAddress = currentSalesAgent.Individual.IndividualEmail;
                    saleAgent.IndividualContactMethod = currentSalesAgent.Individual.PreferedContactMethodID;

                    saleAgent.SaleContractSignedPurchaserDt = currentSalesAgent.SaleContractSignedPurchaserDt != null ? currentSalesAgent.SaleContractSignedPurchaserDt.Value.ToString("") : string.Empty;
                    saleAgent.SaleContractSignedSellerDt = currentSalesAgent.SaleContractSignedSellerDt.AsString();
                    saleAgent.SalesBondClientContactedDt = currentSalesAgent.SalesBondClientContactedDt.AsString();
                    saleAgent.SalesBondBondDocsRecDt = currentSalesAgent.SalesBondBondDocsRecDt.AsString();
                    saleAgent.SalesBondGrantedDt = currentSalesAgent.SalesBondGrantedDt.AsString();
                    saleAgent.SalesBondClientAcceptDt = currentSalesAgent.SalesBondClientAcceptDt.AsString();
                    saleAgent.SalesBondRequiredDt = currentSalesAgent.SalesBondRequiredDt.AsString();
                    saleAgent.SaleBondDueTimeDt = currentSalesAgent.SaleBondDueTimeDt.AsString();
                    saleAgent.SaleBondDueExpiryDt = currentSalesAgent.SaleBondDueExpiryDt.AsString();
                    saleAgent.SalesBondClientAcceptDt = currentSalesAgent.SalesBondClientAcceptDt.AsString();
                    saleAgent.SalesBondCommDueBt = currentSalesAgent.SalesBondCommDueBt == true ? 1 : 0;
                    saleAgent.SalesBondAmount = currentSalesAgent.SalesBondAmount != null ? (double)currentSalesAgent.SalesBondAmount : 0.0;
                    saleAgent.SalesBondInterestRate = currentSalesAgent.SalesBondInterestRate != null ? (float)currentSalesAgent.SalesBondInterestRate : 0;

                    return Json(saleAgent, JsonRequestBehavior.AllowGet);
                }
                return Json("NewSale", JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(ex);
            }

        }

        [HttpPost]
        public JsonResult SaveIndividual(Individual person)
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

        [HttpPost]
        public JsonResult SaveAvailableReservation(ReservationViewModel reservation)
        {
            try
            {
                if (reservation != null)
                {
                    
                    var _currentSale = _repoService.GetSaleById(int.Parse(SessionHandler.GetSessionContext("CurrentSaleId")));
                    var _linkedUnit = _repoService.GetUnitById(int.Parse(SessionHandler.GetSessionContext("CurrentUnit")));

                    if (_currentSale.SaleActiveStatusID == UnitSaleStatusConverter.SaleActiveStatusConverter(SaleActiveStatusType.GetSaleActiveStatusType.Available))
                    {
                        _currentSale.SaleActiveStatusID = UnitSaleStatusConverter.SaleActiveStatusConverter(SaleActiveStatusType.GetSaleActiveStatusType.Reserved);
                        reservation.SaleStatusId = UnitSaleStatusConverter.SaleActiveStatusConverter(SaleActiveStatusType.GetSaleActiveStatusType.Reserved);
                        reservation.CurrentSalesStatus = _repoService.GetSaleActiveStatus((int)_currentSale.SaleActiveStatusID).SaleActiveStatusDescription;
                    }

                    if (_linkedUnit.UnitStatusID == UnitSaleStatusConverter.UnitStatusConverter(UnitStatusType.GetUnitStatusType.Available))
                    {
                        _linkedUnit.UnitStatusID = UnitSaleStatusConverter.UnitStatusConverter(UnitStatusType.GetUnitStatusType.Reserved);
                        reservation.UnitStatusId = UnitSaleStatusConverter.UnitStatusConverter(UnitStatusType.GetUnitStatusType.Reserved);
                        _repoService.UpdateUnit(_linkedUnit);
                    } 

                    _currentSale.SaleReservationDt = DateTime.ParseExact(reservation.SaleReservationDt, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    _currentSale.SaleReservationExpiryDt = DateTime.ParseExact(reservation.SaleReservationExpiryDt, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    _currentSale.SaleReservationExtentionDt = DateTime.ParseExact(reservation.SaleReservationExtentionDt, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    _repoService.SaveUpdateReservation(_currentSale);
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

                if (_currentSale.SaleActiveStatusID == UnitSaleStatusConverter.SaleActiveStatusConverter(SaleActiveStatusType.GetSaleActiveStatusType.Reserved))
                    {
                        _currentSale.SaleActiveStatusID = UnitSaleStatusConverter.SaleActiveStatusConverter(SaleActiveStatusType.GetSaleActiveStatusType.Pending);
                        sale.SaleStatusId = UnitSaleStatusConverter.SaleActiveStatusConverter(SaleActiveStatusType.GetSaleActiveStatusType.Pending);
                        sale.CurrentSalesStatus = _repoService.GetSaleActiveStatus((int)_currentSale.SaleActiveStatusID).SaleActiveStatusDescription;
                    }

                if (_linkedUnit.UnitStatusID == UnitSaleStatusConverter.SaleActiveStatusConverter(SaleActiveStatusType.GetSaleActiveStatusType.Reserved))
                    {
                        _linkedUnit.UnitStatusID = UnitSaleStatusConverter.SaleActiveStatusConverter(SaleActiveStatusType.GetSaleActiveStatusType.Pending);
                        sale.UnitStatusId = UnitSaleStatusConverter.SaleActiveStatusConverter(SaleActiveStatusType.GetSaleActiveStatusType.Pending);
                        _repoService.UpdateUnit(_linkedUnit);
                    } 

                    _currentSale.SaleContractSignedPurchaserDt = DateTime.ParseExact(sale.SalesDepoistPaidDt, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    _currentSale.SaleDepositPaidBt = sale.SaleDepositPaidBt == 1 ? true : false;
                    _currentSale.SalesDepoistPaidDt = DateTime.ParseExact(sale.SalesDepoistPaidDt, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    _currentSale.SalesDepositProofDt = DateTime.ParseExact(sale.SalesDepoistPaidDt, "dd/MM/yyyy", CultureInfo.InvariantCulture);
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
                if (_currentSale.SaleActiveStatusID == UnitSaleStatusConverter.SaleActiveStatusConverter(SaleActiveStatusType.GetSaleActiveStatusType.Pending))
                {
                    _currentSale.SaleActiveStatusID = UnitSaleStatusConverter.SaleActiveStatusConverter(SaleActiveStatusType.GetSaleActiveStatusType.Sold);
                    sale.SaleStatusId = UnitSaleStatusConverter.SaleActiveStatusConverter(SaleActiveStatusType.GetSaleActiveStatusType.Sold);
                    sale.CurrentSalesStatus = _repoService.GetSaleActiveStatus((int)_currentSale.SaleActiveStatusID).SaleActiveStatusDescription;
                }
                if (_linkedUnit.UnitStatusID == UnitSaleStatusConverter.SaleActiveStatusConverter(SaleActiveStatusType.GetSaleActiveStatusType.Pending))
                {
                    _linkedUnit.UnitStatusID = UnitSaleStatusConverter.SaleActiveStatusConverter(SaleActiveStatusType.GetSaleActiveStatusType.Sold);
                    sale.UnitStatusId = UnitSaleStatusConverter.SaleActiveStatusConverter(SaleActiveStatusType.GetSaleActiveStatusType.Sold);
                    _repoService.UpdateUnit(_linkedUnit);
                }
                _currentSale.SaleContractSignedPurchaserDt = sale.SaleContractSignedPurchaserDt != null ? DateTime.ParseExact(sale.SaleContractSignedPurchaserDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
                _currentSale.SaleContractSignedSellerDt = sale.SaleContractSignedSellerDt != null ? DateTime.ParseExact(sale.SaleContractSignedSellerDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
                _currentSale.SalesBondClientContactedDt = sale.SalesBondClientContactedDt != null ? DateTime.ParseExact(sale.SalesBondClientContactedDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
                _currentSale.SalesBondBondDocsRecDt = sale.SalesBondBondDocsRecDt != null ? DateTime.ParseExact(sale.SalesBondBondDocsRecDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
                _currentSale.SalesBondGrantedDt = sale.SalesBondGrantedDt != null ? DateTime.ParseExact(sale.SalesBondGrantedDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
                _currentSale.SalesBondClientAcceptDt = sale.SalesBondClientAcceptDt != null ? DateTime.ParseExact(sale.SalesBondClientAcceptDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
                _currentSale.SalesBondRequiredDt = sale.SalesBondRequiredDt != null ? DateTime.ParseExact(sale.SalesBondRequiredDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
                _currentSale.SaleBondDueTimeDt = sale.SaleBondDueTimeDt != null ? DateTime.ParseExact(sale.SaleBondDueTimeDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
                _currentSale.SaleBondDueExpiryDt = sale.SaleBondDueExpiryDt != null ? DateTime.ParseExact(sale.SaleBondDueExpiryDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
                _currentSale.SalesBondClientAcceptDt = sale.SalesBondClientAcceptDt != null ? DateTime.ParseExact(sale.SalesBondClientAcceptDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
                _currentSale.SalesBondCommDueBt = sale.SalesBondCommDueBt == 1 ? true : false;
                _currentSale.SalesBondAmount = sale.SalesBondAmount;
                _currentSale.SalesBondInterestRate = sale.SalesBondInterestRate;

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
	}
}