using AAMPS.Clients.AampService;
using AAMPS.Web.Models.ViewModels;
using AAMPS.Web.Models.ViewModels.Bonds;
using App.Common.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Extentions;
using AAMPS.Clients.Actions.Bonds;
using AAMPS.Domain;
using AAMPS.Clients.Queries.Bonds;
using Aamps.Domain.ValueObjects;
using System.Globalization;


namespace AAMPS.Web.Controllers
{
    public class BondsController : Controller
    {
        AampServiceClient _repoService = new AampServiceClient();
        // GET: Bonds
        [AampsAuthorize]
        public ActionResult Details(int id)
        {
            SessionHandler.SessionContext("CurrentUnit", id);

            var unitId = int.Parse(SessionHandler.GetSessionContext("CurrentUnit"));

            var result = new LoadBondDetails(new LoadBondsQuery(){ UnitId = id });
           
            return View(result.query.Result);
        }

        [HttpGet]
        public JsonResult GetDetails()
        {
            SalesAgentViewModel saleAgent = new SalesAgentViewModel();
            int _currentUnitId = int.Parse(SessionHandler.GetSessionContext("CurrentUnit"));
            var currentSalesAgent = _repoService.GetSaleByUnitId(_currentUnitId);

            SessionHandler.SessionContext("CurrentSaleId", currentSalesAgent.SaleID);

            var _currentUnit = _repoService.GetUnitByDevelopmentId(currentSalesAgent.Unit.DevelopmentID).FirstOrDefault();
            var viewModel = new BondsViewModel()
            {
                UnitId = _currentUnit.UnitID,
                UnitNumber = _currentUnit.UnitNumber,
                UnitSize = _currentUnit.UnitSize,
                UnitFloor = _currentUnit.UnitFloor,
                UnitBlock = _currentUnit.UnitBlock,
                UnitPhase = _currentUnit.UnitPhase,
                UnitPriceIncluding = _currentUnit.UnitPriceIncluding,
                UnitActiveDate = _currentUnit.UnitActiveDate,
                UnitStatusID = _repoService.GetUnitStatusById(_currentUnit.UnitStatusID).UnitStatusDescription,
                DevelopmentDescription = _repoService.GetDevelopmentById(_currentUnit.DevelopmentID).DevelopmentDescription,
                              
            };

            return Json(viewModel, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult SaveUpdateOrginator(OrginatorViewModel orginator)
        {
            try
            {
                if (orginator != null)
                {
                    if (orginator.ApplicationStatus != "NewApplication")
                    {
                        Invariant.IsNotNull(orginator.OriginatorTrID, () => "orginator id is null");


                        var currentOrginator = _repoService.GetOriginatorById(orginator.OriginatorTrID);
                        currentOrginator.OriginatorTrBondAmount = orginator.OriginatorTrBondAmount;
                        currentOrginator.OriginatorTrIntRate = orginator.OriginatorTrIntRate;
                        currentOrginator.OriginatorTrSubmittedDt = DateTime.ParseExact(orginator.OriginatorTrSubmittedDt, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        currentOrginator.OriginatorTrGrantDt = DateTime.ParseExact(orginator.OriginatorTrGrantDt, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        currentOrginator.OriginatorTrAcceptDt = DateTime.ParseExact(orginator.OriginatorTrAcceptDt, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        currentOrginator.OriginatorTrAIPDt = DateTime.ParseExact(orginator.OriginatorTrAIPDt, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        currentOrginator.OriginatorTrModifiedDt = DateTime.Now;
                        currentOrginator.SaleID = int.Parse(SessionHandler.GetSessionContext("CurrentSaleId"));
                        SetBankType(orginator.BankName, currentOrginator);
                        SetMOStatus(orginator.MOStatus, currentOrginator);

                            _repoService.UpdateOrginator(currentOrginator);
                            return Json(orginator, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var newOrginator = new OriginatorTr();
                        newOrginator.OriginatorTrBondAmount = orginator.OriginatorTrBondAmount;
                        newOrginator.OriginatorTrIntRate = orginator.OriginatorTrIntRate;
                        newOrginator.OriginatorTrSubmittedDt = DateTime.ParseExact(orginator.OriginatorTrSubmittedDt, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        newOrginator.OriginatorTrGrantDt = DateTime.ParseExact(orginator.OriginatorTrGrantDt, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        newOrginator.OriginatorTrAcceptDt = DateTime.ParseExact(orginator.OriginatorTrAcceptDt, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        newOrginator.OriginatorTrAIPDt = DateTime.ParseExact(orginator.OriginatorTrAIPDt, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        newOrginator.OriginatorTrAcceptedBt = true;
                        newOrginator.OriginatorTrModifiedDt = DateTime.Now;
                        newOrginator.OriginatorTrAddedDt = DateTime.Now;
                        newOrginator.OriginatorTrAddedByUser = 1;
                        newOrginator.OriginatorTrModifiedByUser = 1;

                        newOrginator.SaleID = int.Parse(SessionHandler.GetSessionContext("CurrentSaleId"));
                        SetBankType(orginator.BankName, newOrginator);
                        SetMOStatus(orginator.MOStatus, newOrginator);

                        _repoService.SaveOrginator(newOrginator);
                        return Json(orginator, JsonRequestBehavior.AllowGet);
                    }

                }
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException);
            }

            return null;

        }

        [HttpPost]
        public JsonResult LoadData(int id)
        {
            Invariant.IsNotNull(id, () => "orginator id is null");
            var _currentOrginators = _repoService.GetOriginatorById(id);
            var viewModel = new BondsViewModel()
            {
                BankName = _repoService.GetBankById((int)_currentOrginators.BankID).BankDescription,
                MOStatus = _repoService.GetMOStatusById((int)_currentOrginators.MOStatusID).MOStatusDescription,
                OriginatorTrAcceptDt = _currentOrginators.OriginatorTrAcceptDt != null ? _currentOrginators.OriginatorTrAcceptDt.Value.ToString("dd/MM/yyyy") : string.Empty,
                OriginatorTrAddedDt = _currentOrginators.OriginatorTrAddedDt != null ? _currentOrginators.OriginatorTrAddedDt.ToShortDateString() : string.Empty,
                OriginatorTrSubmittedDt = _currentOrginators.OriginatorTrSubmittedDt != null ? _currentOrginators.OriginatorTrSubmittedDt.Value.ToString("dd/MM/yyyy") : string.Empty,
                OriginatorTrAIPDt = _currentOrginators.OriginatorTrAIPDt != null ? _currentOrginators.OriginatorTrAIPDt.Value.ToString("dd/MM/yyyy") : string.Empty,
                OriginatorTrBondAmount = _currentOrginators.OriginatorTrBondAmount,
                OriginatorTrIntRate = _currentOrginators.OriginatorTrIntRate,
                OriginatorTrGrantDt = _currentOrginators.OriginatorTrGrantDt != null ? _currentOrginators.OriginatorTrGrantDt.Value.ToString("dd/MM/yyyy") : string.Empty
            };

            return Json(viewModel, JsonRequestBehavior.AllowGet);

        }



        
        [AampsAuthorize]
        [HttpGet]
        public ActionResult GetBanks()
        {
            var bankTypeList = new List<string>();
            var banks = _repoService.GetAllBanks();
            foreach (var item in banks)
            {
                bankTypeList.Add(item.BankDescription);
            }
            return Json(bankTypeList, JsonRequestBehavior.AllowGet);

        }

        [AampsAuthorize]
        [HttpGet]
        public ActionResult GetMOStatus()
        {
            var MOStatusTypeList = new List<string>();
            var mosStatus = _repoService.GetAllMOStatus();
            foreach (var item in mosStatus)
            {
                MOStatusTypeList.Add(item.MOStatusDescription);
            }
            return Json(MOStatusTypeList, JsonRequestBehavior.AllowGet);

        }

        public void SetMOStatus(string status, OriginatorTr orginator)
        {
            switch (status)
            {
                case "0":
                    {
                        orginator.MOStatusID = 2;
                        break;
                    }

                case "1":
                    {
                        orginator.MOStatusID = 4;
                        break;
                    }
                case "2":
                    {
                        orginator.MOStatusID = 5;
                        break;
                    }
                case "3":
                    {
                        orginator.MOStatusID = 3;
                        break;

                    }
                case "4":
                    {
                        orginator.MOStatusID = 6;
                        break;

                    }
                case "5":
                    {
                        orginator.MOStatusID = 1;
                        break;

                    }
                default:
                    break;


            }
        }

        public void SetBankType(string status, OriginatorTr orginator)
        {
            switch (status)
            {
                case "0":
                    {
                        orginator.BankID = 1;
                        break;
                    }

                case "1":
                    {
                        orginator.BankID = 2;
                        break;
                    }
                case "2":
                    {
                        orginator.BankID = 3;
                        break;
                    }
                case "3":
                    {
                        orginator.BankID = 4;
                        break;

                    }
                default:
                    break;


            }
        }
    }
}