using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAMPS.Web.Models.ViewModels.Reports.Sales
{
    public class SalesReportViewModel
    {
        public string Development { get; set; }
        public string UnitNo { get; set; }
        public string Phase { get; set; }
        public double? Price { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Agency { get; set; }
        public string Agent { get; set; }
        public string Purchaser { get; set; }
        public double? Deposit { get; set; }
        public Nullable<System.DateTime> DepositDate { get; set; }
        public string Proof { get; set; }
        public Nullable<System.DateTime> CntrSigned { get; set; }
        public string Bond { get; set; }
        public double? BondReq { get; set; }
        public double? BondAmountGrant { get; set; }
        public Nullable<System.DateTime> Granted { get; set; }
        public double? AmountDue { get; set; }

    }
}