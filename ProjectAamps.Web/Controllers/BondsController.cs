using AAMPS.Clients.AampService;
using App.Common.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Extentions;
using AAMPS.Clients.Actions.Bonds;
using AAMPS.Clients.Queries.Bonds;
using System.Globalization;
using AAMPS.Clients.ViewModels.Sales;
using AAMPS.Clients.ViewModels.Originator;
using AAMPS.Clients.ViewModels.Bonds;


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

            var response = new LoadBondDetails(new LoadBondsQuery(){ UnitId = id });

            return View(response.query.Result);
        }

        [HttpGet]
        public JsonResult GetDetails()
        {
            SalesViewModel saleAgent = new SalesViewModel();

            int _currentUnitId = int.Parse(SessionHandler.GetSessionContext("CurrentUnit"));
            var currentSalesAgent = _repoService.GetSaleByUnitId(_currentUnitId);

            SessionHandler.SessionContext("CurrentSaleId", currentSalesAgent.SaleID);

            //var _currentUnit = _repoService.GetUnitByDevelopmentId(currentSalesAgent.Unit.DevelopmentID).FirstOrDefault();
            var _currentUnit = _repoService.GetUnitById(_currentUnitId);
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
        public JsonResult SaveSalesBondDetails(SalesViewModel sale)
        {
            try
            {

                var _linkedSale = _repoService.GetSaleById(int.Parse(SessionHandler.GetSessionContext("CurrentSaleId")));
                if (_linkedSale != null)
                {
                    _linkedSale.SalesBondAccountNo = sale.SalesBondAccountNo;
                    _linkedSale.SalesBondBondDocsRecDt = sale.SalesBondBondDocsRecDt != null ? DateTime.ParseExact(sale.SalesBondBondDocsRecDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
                    _linkedSale.SalesBondClientContactedDt = sale.SalesBondClientContactedDt != null ? DateTime.ParseExact(sale.SalesBondClientContactedDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;

                    _linkedSale.SaleModifiedDt = DateTime.Now;
                    _linkedSale.SaleModifiedByUser = 1;

                    _repoService.UpdateSale(_linkedSale);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return Json(sale, JsonRequestBehavior.AllowGet);
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

                        Invariant.IsNotNull(currentOrginator.OriginatorTrID, () => "MOStatus ID is null");

                        switch (currentOrginator.MOStatusID)
	                    { 
                            case 1:
                                {
                          
                                    currentOrginator.OriginatorTrBondAmount = orginator.OriginatorTrBondAmount;
                                    currentOrginator.OriginatorTrIntRate = orginator.OriginatorTrIntRate;
                                     currentOrginator.OriginatorTrSubmittedDt = orginator.OriginatorTrSubmittedDt != null ? DateTime.ParseExact(orginator.OriginatorTrSubmittedDt, "dd/MM/yyyy", CultureInfo.InvariantCulture):  (DateTime?)null;
                                    currentOrginator.OriginatorTrModifiedDt = DateTime.Now;
                                    currentOrginator.SaleID = int.Parse(SessionHandler.GetSessionContext("CurrentSaleId"));

                                    if(orginator.OriginatorTrAIPDt != null)
                                    {
                                        currentOrginator.OriginatorTrAIPDt =  DateTime.ParseExact(orginator.OriginatorTrAIPDt, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                        currentOrginator.MOStatusID = 2;
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    currentOrginator.OriginatorTrBondAmount = orginator.OriginatorTrBondAmount;
                                    currentOrginator.OriginatorTrIntRate = orginator.OriginatorTrIntRate;
                                    currentOrginator.OriginatorTrSubmittedDt = orginator.OriginatorTrSubmittedDt != null ? DateTime.ParseExact(orginator.OriginatorTrSubmittedDt, "dd/MM/yyyy", CultureInfo.InvariantCulture):  (DateTime?)null;
                                    currentOrginator.OriginatorTrAIPDt = orginator.OriginatorTrAIPDt != null ? DateTime.ParseExact(orginator.OriginatorTrAIPDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) :  (DateTime?)null;
                                    currentOrginator.OriginatorTrModifiedDt = DateTime.Now;
                                    currentOrginator.SaleID = int.Parse(SessionHandler.GetSessionContext("CurrentSaleId"));

                                    if(orginator.OriginatorTrGrantDt != null)
                                    {
                                        currentOrginator.OriginatorTrGrantDt = DateTime.ParseExact(orginator.OriginatorTrGrantDt, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                        currentOrginator.MOStatusID = 3;
                                    }

                                    break;
                                }
                            case 3:
                                {
                                    currentOrginator.OriginatorTrBondAmount = orginator.OriginatorTrBondAmount;
                                    currentOrginator.OriginatorTrIntRate = orginator.OriginatorTrIntRate;
                                    currentOrginator.OriginatorTrSubmittedDt = orginator.OriginatorTrSubmittedDt != null ?DateTime.ParseExact(orginator.OriginatorTrSubmittedDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) :(DateTime?)null;
                                    currentOrginator.OriginatorTrAIPDt = orginator.OriginatorTrAIPDt != null ? DateTime.ParseExact(orginator.OriginatorTrAIPDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) :(DateTime?)null;
                                    currentOrginator.OriginatorTrGrantDt = orginator.OriginatorTrGrantDt != null ? DateTime.ParseExact(orginator.OriginatorTrGrantDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) :(DateTime?)null;
                                    currentOrginator.OriginatorTrModifiedDt = DateTime.Now;
                                    currentOrginator.SaleID = int.Parse(SessionHandler.GetSessionContext("CurrentSaleId"));
                            
                                    if(orginator.OriginatorTrAcceptDt != null)
                                    {
                                        currentOrginator.OriginatorTrAcceptDt =  DateTime.ParseExact(orginator.OriginatorTrAcceptDt, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                        currentOrginator.MOStatusID = 4;
                                    }
                                      break;
                                
                                }
		                    default:
                                  break;
	                    }

                        SetBankType(orginator.BankName, currentOrginator);
                        SetMOStatus(orginator.MOStatus, currentOrginator);

                         _repoService.UpdateOrginator(currentOrginator);

                         if (currentOrginator.MOStatusID == 4)
                         {
                             UpdateSaleBondDetails(currentOrginator);
                         }

                        return Json(orginator, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var newOrginator = new OriginatorTr();
                        newOrginator.OriginatorTrBondAmount = orginator.OriginatorTrBondAmount;
                        newOrginator.OriginatorTrIntRate = orginator.OriginatorTrIntRate;
                        newOrginator.OriginatorTrSubmittedDt = orginator.OriginatorTrSubmittedDt != null ? DateTime.ParseExact(orginator.OriginatorTrSubmittedDt, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
                        newOrginator.OriginatorTrAcceptedBt = false;
                        newOrginator.OriginatorTrModifiedDt = DateTime.Now;
                        newOrginator.OriginatorTrAddedDt = DateTime.Now;
                        newOrginator.OriginatorTrAddedByUser = 1;
                        newOrginator.OriginatorTrModifiedByUser = 1;

                        newOrginator.SaleID = int.Parse(SessionHandler.GetSessionContext("CurrentSaleId"));
                        SetBankType(orginator.BankName, newOrginator);
                        newOrginator.MOStatusID = 1;  

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
            var viewModel = new BondsViewModel();

            if(_currentOrginators != null)
            {
                switch (_currentOrginators.MOStatusID)
                {
                    case 1:
                        {
                            viewModel.BankName = _repoService.GetBankById((int)_currentOrginators.BankID).BankDescription;
                            viewModel.MOStatus = _repoService.GetMOStatusById((int)_currentOrginators.MOStatusID).MOStatusDescription;
                            viewModel.OriginatorTrBondAmount = _currentOrginators.OriginatorTrBondAmount;
                            viewModel.OriginatorTrIntRate = _currentOrginators.OriginatorTrIntRate;
                            viewModel.OriginatorTrSubmittedDt = _currentOrginators.OriginatorTrSubmittedDt != null ? _currentOrginators.OriginatorTrSubmittedDt.Value.ToString("dd/MM/yyyy") : string.Empty;
                            break;
                        }
                    case 2:
                        {
                            viewModel.BankName = _repoService.GetBankById((int)_currentOrginators.BankID).BankDescription;
                            viewModel.MOStatus = _repoService.GetMOStatusById((int)_currentOrginators.MOStatusID).MOStatusDescription;
                            viewModel.OriginatorTrBondAmount = _currentOrginators.OriginatorTrBondAmount;
                            viewModel.OriginatorTrIntRate = _currentOrginators.OriginatorTrIntRate;
                            viewModel.OriginatorTrSubmittedDt = _currentOrginators.OriginatorTrSubmittedDt != null ? _currentOrginators.OriginatorTrSubmittedDt.Value.ToString("dd/MM/yyyy") : string.Empty;
                            viewModel.OriginatorTrAIPDt = _currentOrginators.OriginatorTrAIPDt != null ? _currentOrginators.OriginatorTrAIPDt.Value.ToString("dd/MM/yyyy") : string.Empty;
                            break;
                        }
                    case 3:
                        {
                            viewModel.BankName = _repoService.GetBankById((int)_currentOrginators.BankID).BankDescription;
                            viewModel.MOStatus = _repoService.GetMOStatusById((int)_currentOrginators.MOStatusID).MOStatusDescription;
                            viewModel.OriginatorTrBondAmount = _currentOrginators.OriginatorTrBondAmount;
                            viewModel.OriginatorTrIntRate = _currentOrginators.OriginatorTrIntRate;
                            viewModel.OriginatorTrSubmittedDt = _currentOrginators.OriginatorTrSubmittedDt != null ? _currentOrginators.OriginatorTrSubmittedDt.Value.ToString("dd/MM/yyyy") : string.Empty;
                            viewModel.OriginatorTrAIPDt = _currentOrginators.OriginatorTrAIPDt != null ? _currentOrginators.OriginatorTrAIPDt.Value.ToString("dd/MM/yyyy") : string.Empty;
                            viewModel.OriginatorTrGrantDt = _currentOrginators.OriginatorTrGrantDt != null ? _currentOrginators.OriginatorTrGrantDt.Value.ToString("dd/MM/yyyy") : string.Empty;
                            break;
                        }
                    case 4:
                        {
                            viewModel.BankName = _repoService.GetBankById((int)_currentOrginators.BankID).BankDescription;
                            viewModel.MOStatus = _repoService.GetMOStatusById((int)_currentOrginators.MOStatusID).MOStatusDescription;
                            viewModel.OriginatorTrBondAmount = _currentOrginators.OriginatorTrBondAmount;
                            viewModel.OriginatorTrIntRate = _currentOrginators.OriginatorTrIntRate;
                            viewModel.OriginatorTrSubmittedDt = _currentOrginators.OriginatorTrSubmittedDt != null ? _currentOrginators.OriginatorTrSubmittedDt.Value.ToString("dd/MM/yyyy") : string.Empty;
                            viewModel.OriginatorTrAIPDt = _currentOrginators.OriginatorTrAIPDt != null ? _currentOrginators.OriginatorTrAIPDt.Value.ToString("dd/MM/yyyy") : string.Empty;
                            viewModel.OriginatorTrGrantDt = _currentOrginators.OriginatorTrGrantDt != null ? _currentOrginators.OriginatorTrGrantDt.Value.ToString("dd/MM/yyyy") : string.Empty;
                            viewModel.OriginatorTrAcceptDt = _currentOrginators.OriginatorTrAcceptDt != null ? _currentOrginators.OriginatorTrAcceptDt.Value.ToString("dd/MM/yyyy") : string.Empty;
                            break;
                        }
                    default:
                        break;
                }
            }

            return Json(viewModel, JsonRequestBehavior.AllowGet);

        }

        public void UpdateSaleBondDetails(OriginatorTr orginator)
        {
            try
            {
                var _linkedSale = _repoService.GetSaleById(orginator.SaleID);
                _linkedSale.SalesBondAmount = orginator.OriginatorTrBondAmount;
                _linkedSale.SalesBondInterestRate = orginator.OriginatorTrIntRate;
                _linkedSale.SalesBondGrantedDt = orginator.OriginatorTrGrantDt;
                _linkedSale.SalesBondClientAcceptDt = orginator.OriginatorTrAcceptDt;
                _linkedSale.BankID = orginator.BankID;

                _linkedSale.SaleModifiedDt = DateTime.Now;
                _linkedSale.SaleModifiedByUser = 1;

                _repoService.UpdateSale(_linkedSale);
            }
            catch (Exception)
            {
                
                throw;
            }
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