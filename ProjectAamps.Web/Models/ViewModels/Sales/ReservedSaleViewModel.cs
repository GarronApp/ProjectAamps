using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAMPS.Web.Models.ViewModels.Sales
{
    public class ReservedSaleViewModel
    {
        public int SaleStatusId { get; set; }
        public int UnitStatusId { get; set; }
        public string CurrentSalesStatus { get; set; }
        public string SaleContractSignedPurchaserDt { get; set; }
        public string SalesDepoistPaidDt { get; set; }
        public int SaleDepositPaidBt { get; set; }
        public string SalesDepositProofDt { get; set; }
        
        
    }
}