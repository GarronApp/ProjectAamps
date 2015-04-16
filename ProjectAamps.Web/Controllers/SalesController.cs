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

namespace AAMPS.Web.Controllers
{
    public class SalesController : Controller
    {
        AampServiceClient _repoService = new AampServiceClient();
        //
        // GET: /Sales/

        public int SalesId { get; set; }

        [AampsAuthorize]
        public ActionResult Details(int id)
        {
            Session.Remove("CurrentUnit");

            Session.Add("CurrentUnit", id);

            var units = _repoService.GetAllUnits().ToList();

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

            return View();
        }

        [HttpGet]
        public JsonResult GetAgentSaleDetails()
        {
            try
            {
                SalesAgentViewModel saleAgent = new SalesAgentViewModel();
                int _currentUnitId = int.Parse(Session["CurrentUnit"].ToString());
                var currentSalesAgent = _repoService.GetSaleByUnitId(_currentUnitId);
                
                saleAgent.ReservationLapses = currentSalesAgent.SaleReservationDt;
                saleAgent.ReservationTimeExtention = currentSalesAgent.SaleReservationExtentionDt;
                saleAgent.ContractSigned = false;
                saleAgent.DepositPaid = currentSalesAgent.SaleDepositPaidBt;
                saleAgent.DateSignedBySeller = currentSalesAgent.SaleContractSignedSellerDt;
                saleAgent.BondRequired = currentSalesAgent.SalesBondRequiredBt;
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


                return Json(saleAgent, JsonRequestBehavior.AllowGet);

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
        public JsonResult SaveReservedReservation(ReservationViewModel reservation)
        {
            try
            {
                if (reservation != null)
                {
                    Sale _currentSale = new Sale();
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